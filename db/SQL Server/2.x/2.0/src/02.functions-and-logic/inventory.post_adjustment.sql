﻿IF OBJECT_ID('inventory.post_adjustment') IS NOT NULL
DROP PROCEDURE inventory.post_adjustment;

GO


CREATE PROCEDURE inventory.post_adjustment
(
    @office_id                              integer,
    @user_id                                integer,
    @login_id                               bigint,
    @store_id                               integer,
    @value_date                             date,
    @book_date                              date,
    @reference_number                       national character varying(24),
    @statement_reference                    national character varying(2000),
    @details                                inventory.adjustment_type READONLY
)
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    DECLARE @transaction_master_id          bigint;
    DECLARE @checkout_id                    bigint;
    DECLARE @book_name                      national character varying(1000)='Inventory Adjustment';
    DECLARE @is_periodic                    bit = inventory.is_periodic_inventory(@office_id);
    DECLARE @default_currency_code          national character varying(12);

    DECLARE @can_post_transaction           bit;
    DECLARE @error_message                  national character varying(MAX);

    SELECT
        @can_post_transaction   = can_post_transaction,
        @error_message          = error_message
    FROM finance.can_post_transaction(@login_id, @user_id, @office_id, @book_name, @value_date);

    IF(@can_post_transaction = 0)
    BEGIN
        RAISERROR(@error_message, 10, 1);
        RETURN;
    END;
    
    DECLARE @temp_stock_details TABLE
    (
        tran_type                       national character varying(2),
        store_id                        integer,
        item_id                         integer,
        item_code                       national character varying(12),
        unit_id                         integer,
        base_unit_id                    integer,
        unit_name                       national character varying(50),
        quantity                        decimal(30, 6),
        base_quantity                   decimal(30, 6),                
        price                           decimal(30, 6),
        cost_of_goods_sold              decimal(30, 6) DEFAULT(0),
        inventory_account_id            integer,
        cost_of_goods_sold_account_id   integer
    ) 
    ; 

    DECLARE @temp_transaction_details TABLE
    (
        tran_type                   national character varying(2), 
        account_id                  integer, 
        statement_reference         national character varying(2000), 
        cash_repository_id          integer, 
        currency_code               national character varying(12), 
        amount_in_currency          decimal(30, 6), 
        local_currency_code         national character varying(12), 
        er                          decimal(30, 6), 
        amount_in_local_currency    decimal(30, 6)
    ) ;

    INSERT INTO @temp_stock_details(tran_type, store_id, item_code, unit_name, quantity)
    SELECT tran_type, @store_id, item_code, unit_name, quantity 
    FROM @details;

    IF EXISTS
    (
        SELECT * FROM @temp_stock_details
        WHERE tran_type = 'Dr'
    )
    BEGIN
        RAISERROR('A stock adjustment entry can not contain debit item(s).', 10, 1);
    END;

    IF EXISTS
    (
        SELECT 1 FROM @temp_stock_details
        GROUP BY item_code
        HAVING COUNT(item_code) <> 1
    )
    BEGIN
        RAISERROR('An item can appear only once in a store.', 10, 1);
    END;

    UPDATE @temp_stock_details 
    SET 
        item_id         = inventory.get_item_id_by_item_code(item_code),
        unit_id         = inventory.get_unit_id_by_unit_name(unit_name);

    IF EXISTS
    (
        SELECT * FROM @temp_stock_details
        WHERE item_id IS NULL OR unit_id IS NULL OR store_id IS NULL
    )
    BEGIN
        RAISERROR('Invalid data supplied.', 10, 1);
    END;

    UPDATE @temp_stock_details 
    SET
        tran_type                       = 'Cr',
        base_quantity                   = inventory.get_base_quantity_by_unit_id(unit_id, quantity),
        base_unit_id                    = inventory.get_root_unit_id(unit_id),
        price                           = inventory.get_item_cost_price(item_id, unit_id),
        inventory_account_id            = inventory.get_inventory_account_id(item_id),
        cost_of_goods_sold_account_id   = inventory.get_cost_of_goods_sold_account_id(item_id);


    IF EXISTS
    (
            SELECT 1
            FROM 
            inventory.stores
            WHERE inventory.stores.store_id
            IN
            (
                SELECT store_id
                FROM @temp_stock_details
            )
            HAVING COUNT(DISTINCT inventory.stores.office_id) > 1

    )
    BEGIN
        RAISERROR('Access is denied!\nA stock adjustment transaction cannot references multiple branches.', 10, 1);
    END;

    IF EXISTS
    (
            SELECT 1
            FROM 
            @temp_stock_details
            WHERE tran_type = 'Cr'
            AND quantity > inventory.count_item_in_stock(item_id, unit_id, store_id)
    )
    BEGIN
        RAISERROR('Negative stock is not allowed.', 10, 1);
    END;

    --No accounting treatment is needed for periodic accounting system.
    IF(@is_periodic = 0)
    BEGIN
        SET @default_currency_code  = core.get_currency_code_by_office_id(@office_id);

        UPDATE @temp_stock_details 
        SET 
            cost_of_goods_sold = inventory.get_cost_of_goods_sold(item_id, unit_id, store_id, quantity);
    
        INSERT INTO @temp_transaction_details(tran_type, account_id, statement_reference, currency_code, amount_in_currency, er, local_currency_code, amount_in_local_currency)
        SELECT 'Dr', cost_of_goods_sold_account_id, @statement_reference, @default_currency_code, SUM(COALESCE(cost_of_goods_sold, 0)), 1, @default_currency_code, SUM(COALESCE(cost_of_goods_sold, 0))
        FROM @temp_stock_details
        GROUP BY cost_of_goods_sold_account_id;

        INSERT INTO @temp_transaction_details(tran_type, account_id, statement_reference, currency_code, amount_in_currency, er, local_currency_code, amount_in_local_currency)
        SELECT 'Cr', inventory_account_id, @statement_reference, @default_currency_code, SUM(COALESCE(cost_of_goods_sold, 0)), 1, @default_currency_code, SUM(COALESCE(cost_of_goods_sold, 0))
        FROM @temp_stock_details
        GROUP BY inventory_account_id;
    END;
    
    INSERT INTO finance.transaction_master
    (
        transaction_counter,
        transaction_code,
        book,
        value_date,
        book_date,
        login_id,
        user_id,
        office_id,
        reference_number,
        statement_reference
    )
    SELECT
        finance.get_new_transaction_counter(@value_date), 
        finance.get_transaction_code(@value_date, @office_id, @user_id, @login_id),
        @book_name,
        @value_date,
        @book_date,
        @login_id,
        @user_id,
        @office_id,
        @reference_number,
        @statement_reference;

    SET @transaction_master_id = SCOPE_IDENTITY();

    INSERT INTO finance.transaction_details(office_id, value_date, book_date, transaction_master_id, tran_type, account_id, statement_reference, cash_repository_id, currency_code, amount_in_currency, local_currency_code, er, amount_in_local_currency)
    SELECT @office_id, @value_date, @book_date, @transaction_master_id, tran_type, account_id, statement_reference, cash_repository_id, currency_code, amount_in_currency, local_currency_code, er, amount_in_local_currency
    FROM @temp_transaction_details
    ORDER BY tran_type DESC;



    INSERT INTO inventory.checkouts(transaction_master_id, value_date, book_date, transaction_book, posted_by, office_id)
    SELECT @transaction_master_id, @value_date, @book_date, @book_name, @user_id, @office_id;

    SET @checkout_id                = SCOPE_IDENTITY();


    INSERT INTO inventory.checkout_details(checkout_id, value_date, book_date, transaction_type, store_id, item_id, quantity, unit_id, base_quantity, base_unit_id, price)
    SELECT @checkout_id, @value_date, @book_date, tran_type, store_id, item_id, quantity, unit_id, base_quantity, base_unit_id, price
    FROM @temp_stock_details;

    EXECUTE finance.auto_verify @transaction_master_id, @office_id;
    
    SELECT @transaction_master_id;
END;




-- SELECT * FROM inventory.post_adjustment(1, 1, 1, 1, CAST(GETDATE() AS date), CAST(GETDATE() AS date), '22', 'Test', 
-- ARRAY[
-- ROW('Cr', 'RMBP', 'Piece', 1),
-- ROW('Cr', '11MBA', 'Piece', 1)
-- ]
-- );



GO
