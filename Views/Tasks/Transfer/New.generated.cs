﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ASP
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Web;
    using System.Web.Helpers;
    using System.Web.Mvc;
    using System.Web.Mvc.Ajax;
    using System.Web.Mvc.Html;
    using System.Web.Routing;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.WebPages;
    
    #line 1 "..\..\Views\Tasks\Transfer\New.cshtml"
    using Frapid.ApplicationState.Cache;
    
    #line default
    #line hidden
    using Frapid.Configuration;
    using Frapid.Dashboard;
    using Frapid.DataAccess;
    using Frapid.DbPolicy;
    using Frapid.Framework;
    using Frapid.i18n;
    using Frapid.Messaging;
    using Frapid.WebsiteBuilder;
    using MixERP.Inventory;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Tasks/Transfer/New.cshtml")]
    public partial class _Views_Tasks_Transfer_New_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Views_Tasks_Transfer_New_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 4 "..\..\Views\Tasks\Transfer\New.cshtml"
  
    ViewBag.Title = "Inventory";
    Layout = ViewBag.InventoryLayoutPath;

            
            #line default
            #line hidden
WriteLiteral("\r\n<div");

WriteLiteral(" class=\"ui attached page segment\"");

WriteLiteral(" style=\"min-height: 100%;padding:3em;display:none;\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"ui huge header\"");

WriteLiteral(">Inventory Transfer</div>\r\n    <div");

WriteLiteral(" class=\"ui divider\"");

WriteLiteral("></div>\r\n\r\n    <div");

WriteLiteral(" class=\"ui form\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"inline fields\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"small field\"");

WriteLiteral(">\r\n                <label");

WriteLiteral(" for=\"ValueDateTextBox\"");

WriteLiteral(">Value Date</label>\r\n                <input");

WriteLiteral(" id=\"ValueDateTextBox\"");

WriteLiteral(" class=\"date\"");

WriteLiteral(" type=\"date\"");

WriteLiteral(">\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"small field\"");

WriteLiteral(">\r\n                <label");

WriteLiteral(" for=\"BookDateTextBox\"");

WriteLiteral(">Book Date</label>\r\n                <input");

WriteLiteral(" id=\"BookDateTextBox\"");

WriteLiteral(" class=\"date\"");

WriteLiteral(" type=\"date\"");

WriteLiteral(">\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"small field\"");

WriteLiteral(">\r\n                <label");

WriteLiteral(" for=\"ReferenceNumberInputText\"");

WriteLiteral(">Ref#</label>\r\n                <input");

WriteLiteral(" id=\"ReferenceNumberInputText\"");

WriteLiteral(" maxlength=\"24\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(">\r\n            </div>\r\n        </div>\r\n    </div>\r\n    <div>\r\n        <table");

WriteLiteral(" id=\"TransferGridView\"");

WriteLiteral(" class=\"ui table segment\"");

WriteLiteral(" style=\"min-width:1000px;max-width:2000px;\"");

WriteLiteral(">\r\n            <thead>\r\n                <tr>\r\n                    <th");

WriteLiteral(" style=\"width:150px\"");

WriteLiteral(">\r\n                        <label");

WriteLiteral(" for=\"TransactionTypeSelect\"");

WriteLiteral(">Type</label>\r\n                    </th>\r\n                    <th");

WriteLiteral(" style=\"width:200px\"");

WriteLiteral(">\r\n                        <label");

WriteLiteral(" for=\"StoreSelect\"");

WriteLiteral(">Store</label>\r\n                    </th>\r\n                    <th");

WriteLiteral(" style=\"width:200px\"");

WriteLiteral(">\r\n                        <label");

WriteLiteral(" for=\"ItemCodeInputText\"");

WriteLiteral(">Item Code</label>\r\n                    </th>\r\n                    <th>\r\n        " +
"                <label");

WriteLiteral(" for=\"ItemSelect\"");

WriteLiteral(">Item Name</label>\r\n                    </th>\r\n                    <th");

WriteLiteral(" style=\"width:200px;\"");

WriteLiteral(">\r\n                        <label");

WriteLiteral(" for=\"UnitSelect\"");

WriteLiteral(">Unit</label>\r\n                    </th>\r\n                    <th");

WriteLiteral(" style=\"width:100px\"");

WriteLiteral(" class=\"text-right\"");

WriteLiteral(">\r\n                        <label");

WriteLiteral(" for=\"QuantityInputText\"");

WriteLiteral(">Quantity</label>\r\n                    </th>\r\n                    <th>Action</th>" +
"\r\n                </tr>\r\n            </thead>\r\n            <tbody>\r\n            " +
"    <tr");

WriteLiteral(" class=\"footer-row ui form\"");

WriteLiteral(">\r\n                    <td>\r\n                        <select");

WriteLiteral(" class=\"ui fluid dropdown\"");

WriteLiteral(" id=\"TransactionTypeSelect\"");

WriteLiteral(">\r\n                            <option");

WriteLiteral(" value=\"Cr\"");

WriteLiteral(">OUT</option>\r\n                            <option");

WriteLiteral(" value=\"Dr\"");

WriteLiteral(">IN</option>\r\n                        </select>\r\n                    </td>\r\n     " +
"               <td>\r\n                        <select");

WriteLiteral(" id=\"StoreSelect\"");

WriteLiteral(" class=\"ui fluid dropdown\"");

WriteLiteral("></select>\r\n                    </td>\r\n                    <td>\r\n                " +
"        <input");

WriteLiteral(" id=\"ItemCodeInputText\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(">\r\n                    </td>\r\n                    <td>\r\n                        <" +
"select");

WriteLiteral(" id=\"ItemSelect\"");

WriteLiteral(" class=\"ui fluid dropdown\"");

WriteLiteral("></select>\r\n                    </td>\r\n                    <td>\r\n                " +
"        <select");

WriteLiteral(" id=\"UnitSelect\"");

WriteLiteral(" class=\"ui fluid dropdown\"");

WriteLiteral("></select>\r\n                    </td>\r\n                    <td>\r\n                " +
"        <input");

WriteLiteral(" id=\"QuantityInputText\"");

WriteLiteral(" class=\"text-right integer\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(">\r\n                    </td>\r\n                    <td>\r\n                        <" +
"input");

WriteLiteral(" id=\"AddButton\"");

WriteLiteral(" value=\"Add\"");

WriteLiteral(" class=\"ui small red button\"");

WriteLiteral(" type=\"button\"");

WriteLiteral(">\r\n                    </td>\r\n                </tr>\r\n            </tbody>\r\n      " +
"  </table>\r\n    </div>\r\n    <div");

WriteLiteral(" id=\"ErrorLabel\"");

WriteLiteral(" class=\"big error vpad16\"");

WriteLiteral("></div>\r\n    <div");

WriteLiteral(" class=\"ui form\"");

WriteLiteral(" style=\"width:290px;\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"small field\"");

WriteLiteral(">\r\n            <label");

WriteLiteral(" for=\"StatementReferenceTextArea\"");

WriteLiteral(">Statement Reference</label>\r\n            <textarea");

WriteLiteral(" id=\"StatementReferenceTextArea\"");

WriteLiteral(" rows=\"4\"");

WriteLiteral("></textarea>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"ui buttons\"");

WriteLiteral(">\r\n            <button");

WriteLiteral(" id=\"SaveButton\"");

WriteLiteral(" class=\"ui green button\"");

WriteLiteral(" type=\"button\"");

WriteLiteral(">\r\n                Save\r\n            </button>\r\n            <a");

WriteLiteral(" href=\"/dashboard/inventory/tasks/inventory-transfers\"");

WriteLiteral(" class=\"ui blue button\"");

WriteLiteral(">Back</a>            \r\n        </div>\r\n    </div>\r\n\r\n    <input");

WriteLiteral(" id=\"ItemIdHidden\"");

WriteLiteral(" value=\"\"");

WriteLiteral(" type=\"hidden\"");

WriteLiteral(">\r\n</div>\r\n\r\n<script>\r\n    var addButton = $(\"#AddButton\");\r\n    var dateTextBox " +
"= $(\"#DateTextBox\");\r\n    var errorLabel = $(\"#ErrorLabel\");\r\n    var itemIdHidd" +
"en = $(\"#ItemIdHidden\");\r\n    var itemCodeInputText = $(\"#ItemCodeInputText\");\r\n" +
"    var itemSelect = $(\"#ItemSelect\");\r\n    var quantityInputText = $(\"#Quantity" +
"InputText\");\r\n    var saveButton = $(\"#SaveButton\");\r\n    var storeSelect = $(\"#" +
"StoreSelect\");\r\n    var transactionTypeSelect = $(\"#TransactionTypeSelect\");\r\n  " +
"  var transferGridView = $(\"#TransferGridView\");\r\n    var unitSelect = $(\"#UnitS" +
"elect\");\r\n    var storeServiceUrl = \"/api/forms/inventory/stores/display-fields\"" +
";\r\n\r\n    var url = \"\";\r\n    var data = \"\";\r\n\r\n    $(document).ready(function () " +
"{\r\n        loadStores();\r\n        loadItems();\r\n    });\r\n\r\n    addButton.click(f" +
"unction () {\r\n        addRow();\r\n    });\r\n\r\n    var addRow = function () {\r\n    " +
"    itemCodeInputText.val(itemSelect.getSelectedValue());\r\n\r\n        const tranT" +
"ype = transactionTypeSelect.getSelectedValue();\r\n        const storeName = store" +
"Select.getSelectedText();\r\n        const itemCode = itemCodeInputText.val();\r\n  " +
"      const itemName = itemSelect.getSelectedText();\r\n        const unitName = u" +
"nitSelect.getSelectedText();\r\n        const quantity = parseInt(quantityInputTex" +
"t.val() || 0);\r\n\r\n        if (transactionTypeSelect.length) {\r\n            if (w" +
"indow.isNullOrWhiteSpace(tranType) || tranType === \"Select\") {\r\n                " +
"window.makeDirty(transactionTypeSelect);\r\n                return;\r\n            }" +
";\r\n        };\r\n\r\n        if (window.isNullOrWhiteSpace(storeName) || storeName =" +
"== \"Select\") {\r\n            window.makeDirty(storeSelect);\r\n            return;\r" +
"\n        };\r\n\r\n        if (window.isNullOrWhiteSpace(itemCode)) {\r\n            w" +
"indow.makeDirty(itemCodeInputText);\r\n            return;\r\n        };\r\n\r\n        " +
"if (window.isNullOrWhiteSpace(itemName) || itemName === \"Select\") {\r\n           " +
" window.makeDirty(itemSelect);\r\n            return;\r\n        };\r\n\r\n        if (w" +
"indow.isNullOrWhiteSpace(unitName) || unitName === \"Select\") {\r\n            wind" +
"ow.makeDirty(unitSelect);\r\n            return;\r\n        };\r\n\r\n        if (quanti" +
"ty <= 0) {\r\n            window.makeDirty(quantityInputText);\r\n            return" +
";\r\n        };\r\n\r\n        window.removeDirty(transactionTypeSelect);\r\n        win" +
"dow.removeDirty(storeSelect);\r\n        window.removeDirty(itemCodeInputText);\r\n " +
"       window.removeDirty(itemSelect);\r\n        window.removeDirty(unitSelect);\r" +
"\n        window.removeDirty(quantityInputText);\r\n\r\n        appendToTable(tranTyp" +
"e, storeName, itemCode, itemName, unitName, quantity);\r\n        itemCodeInputTex" +
"t.val(\"\");\r\n        quantityInputText.val(\"\");\r\n\r\n        if (transactionTypeSel" +
"ect.length) {\r\n            transactionTypeSelect.focus();\r\n            return;\r\n" +
"        };\r\n\r\n        storeSelect.attr(\"disabled\", \"disabled\");\r\n        itemCod" +
"eInputText.focus();\r\n    };\r\n\r\n    function appendToTable(tranType, storeName, i" +
"temCode, itemName, unitName, quantity) {\r\n        const rows = transferGridView." +
"find(\"tbody tr:not(:last-child)\");\r\n        var match = false;\r\n        var html" +
";\r\n\r\n        if (transactionTypeSelect.length) {\r\n            rows.each(function" +
" () {\r\n                const row = $(this);\r\n                if (window.getColum" +
"nText(row, 0) !== tranType &&\r\n                    window.getColumnText(row, 1) " +
"=== storeName &&\r\n                    window.getColumnText(row, 2) === itemCode)" +
" {\r\n                    window.displayMessage(\"Duplicate entry\");\r\n\r\n           " +
"         window.makeDirty(itemSelect);\r\n                    match = true;\r\n     " +
"           };\r\n\r\n                if (window.getColumnText(row, 0) === tranType &" +
"&\r\n                    window.getColumnText(row, 1) === storeName &&\r\n          " +
"          window.getColumnText(row, 2) === itemCode &&\r\n                    wind" +
"ow.getColumnText(row, 4) === unitName) {\r\n                    window.setColumnTe" +
"xt(row, 5, window.getFormattedNumber(window.parseFloat2(window.getColumnText(row" +
", 5)) + quantity));\r\n\r\n                    window.addDanger(row);\r\n             " +
"       match = true;\r\n                    return;\r\n                }\r\n          " +
"  });\r\n\r\n            if (!match) {\r\n                html = \"<tr class=\'grid2-row" +
"\'><td>\" + tranType + \"</td><td>\" + storeName + \"</td><td>\" + itemCode + \"</td><t" +
"d>\" + itemName + \"</td><td>\" + unitName + \"</td><td class=\'text-right\'>\" + getFo" +
"rmattedNumber(quantity) + \"</td>\"\r\n                    + \"</td><td><a class=\'poi" +
"nter\' onclick=\'removeRow($(this));\'><i class=\'ui delete icon\'></i></a><a class=\'" +
"pointer\' onclick=\'toggleDanger($(this));\'><i class=\'ui pointer check mark icon\'>" +
"</a></i><a class=\'pointer\' onclick=\'toggleSuccess($(this));\'><i class=\'ui pointe" +
"r thumbs up icon\'></i></a></td></tr>\";\r\n                transferGridView.find(\"t" +
"r:last\").before(html);\r\n            };\r\n\r\n            return;\r\n        };\r\n\r\n   " +
"     rows.each(function () {\r\n            const row = $(this);\r\n            if (" +
"window.getColumnText(row, 0) === storeName &&\r\n                window.getColumnT" +
"ext(row, 1) === itemCode) {\r\n                window.displayMessage(\"Duplicate En" +
"try\");\r\n\r\n                window.makeDirty(itemSelect);\r\n                match =" +
" true;\r\n            };\r\n\r\n            if (window.getColumnText(row, 0) === store" +
"Name &&\r\n                window.getColumnText(row, 1) === itemCode &&\r\n         " +
"       window.getColumnText(row, 3) === unitName) {\r\n                window.setC" +
"olumnText(row, 4, window.getFormattedNumber(window.parseFloat2(window.getColumnT" +
"ext(row, 4)) + quantity));\r\n\r\n                window.addDanger(row);\r\n          " +
"      match = true;\r\n                return;\r\n            }\r\n        });\r\n\r\n    " +
"    if (!match) {\r\n            html = \"<tr class=\'grid2-row\'><td>\" + storeName +" +
" \"</td><td>\" + itemCode + \"</td><td>\" + itemName + \"</td><td>\" + unitName + \"</t" +
"d><td class=\'text-right\'>\" + getFormattedNumber(quantity) + \"</td>\"\r\n           " +
"     + \"</td><td><a class=\'pointer\' onclick=\'removeRow($(this));\'><i class=\'ui d" +
"elete icon\'></i></a><a class=\'pointer\' onclick=\'toggleDanger($(this));\'><i class" +
"=\'ui pointer check mark icon\'></a></i><a class=\'pointer\' onclick=\'toggleSuccess(" +
"$(this));\'><i class=\'ui pointer thumbs up icon\'></i></a></td></tr>\";\r\n          " +
"  transferGridView.find(\"tr:last\").before(html);\r\n        };\r\n    };\r\n\r\n    save" +
"Button.click(function () {\r\n        function request(model) {\r\n            const" +
" url = \"/dashboard/inventory/tasks/inventory-transfers\";\r\n            const data" +
" = JSON.stringify(model);\r\n            return window.getAjaxRequest(url, \"POST\"," +
" data);\r\n        };\r\n\r\n        function getModel() {\r\n            function getDe" +
"tails() {\r\n                var model = [];\r\n                const rows = $(\"#Tra" +
"nsferGridView tbody tr:not(:last-child)\");\r\n\r\n                $.each(rows, funct" +
"ion() {\r\n                    const row = $(this);\r\n                    const tra" +
"nsferType = row.find(\"td:nth-child(1)\").html();\r\n                    const store" +
"Name = row.find(\"td:nth-child(2)\").html();\r\n                    const itemCode =" +
" row.find(\"td:nth-child(3)\").html();\r\n                    const itemName = row.f" +
"ind(\"td:nth-child(4)\").html();\r\n                    const unitName = row.find(\"t" +
"d:nth-child(5)\").html();\r\n                    const quantity = window.parseFloat" +
"2(row.find(\"td:nth-child(6)\").html());\r\n\r\n                    model.push({\r\n    " +
"                    ItemCode: itemCode,\r\n                        ItemName: itemN" +
"ame,\r\n                        Quantity: quantity,\r\n                        Store" +
"Name: storeName,\r\n                        TransferTypeEnum: transferType,\r\n     " +
"                   UnitName: unitName\r\n                    });\r\n                " +
"});\r\n\r\n                return model;\r\n            };\r\n\r\n            const valueD" +
"ate = window.parseLocalizedDate($(\"#ValueDateTextBox\").val());\r\n            cons" +
"t bookDate = window.parseLocalizedDate($(\"#BookDateTextBox\").val());\r\n          " +
"  const referenceNumber = $(\"#ReferenceNumberInputText\").val();\r\n            con" +
"st statementReference = $(\"#StatementReferenceTextArea\").val();\r\n            con" +
"st details = getDetails();\r\n\r\n            if (!window.isDate(valueDate)) {\r\n    " +
"            window.makeDirty($(\"#ValueDateTextBox\"));\r\n                errorLabe" +
"l.html(\"Invalid date!\");\r\n                return false;\r\n            };\r\n\r\n     " +
"       if (!window.isDate(bookDate)) {\r\n                window.makeDirty($(\"#Boo" +
"kDateTextBox\"));\r\n                errorLabel.html(\"Invalid date!\");\r\n           " +
"     return false;\r\n            };\r\n\r\n            if (!details || details.length" +
" === 0) {\r\n                errorLabel.html(\"Nothing to transfer!\");\r\n           " +
"     return false;\r\n            };\r\n\r\n            return {\r\n                Valu" +
"eDate: valueDate,\r\n                BookDate: bookDate,\r\n                Referenc" +
"eNumber: referenceNumber,\r\n                StatementReference: statementReferenc" +
"e,\r\n                Details: details\r\n            };\r\n        };\r\n\r\n        \r\n\r\n" +
"        errorLabel.html(\"\");\r\n\r\n        if (transferGridView.find(\"tr\").length =" +
"== 2) {\r\n            errorLabel.html(\"Gridview is empty!\");\r\n            return " +
"false;\r\n        };\r\n\r\n        const model = getModel();\r\n        const ajax = re" +
"quest(model);\r\n\r\n        ajax.success(function(response) {\r\n            const ur" +
"l = \"/dashboard/inventory/tasks/transfers/checklist/\" + response;\r\n            d" +
"ocument.location = url;\r\n        });\r\n\r\n        ajax.fail(function (xhr) {\r\n    " +
"        window.logAjaxErrorMessage(xhr);\r\n        });\r\n    });\r\n\r\n    itemSelect" +
".change(function () {\r\n        itemCodeInputText.val(itemSelect.getSelectedValue" +
"());\r\n        loadUnits();\r\n    });\r\n\r\n    itemSelect.blur(function () {\r\n      " +
"  itemCodeInputText.val(itemSelect.getSelectedValue());\r\n        loadUnits();\r\n " +
"   });\r\n\r\n    itemCodeInputText.blur(function () {\r\n        if (!window.isNullOr" +
"WhiteSpace(itemCodeInputText.val())) {\r\n            itemSelect.val(itemCodeInput" +
"Text.val());\r\n        };\r\n    });\r\n\r\n    function loadStores() {\r\n        window" +
".displayFieldBinder(storeSelect, \"/api/forms/inventory/stores/display-fields\");\r" +
"\n    };\r\n\r\n\r\n    function loadItems() {\r\n        function request() {\r\n         " +
"   const url = \"/dashboard/inventory/items/stockable\";\r\n            return windo" +
"w.getAjaxRequest(url);\r\n        };\r\n\r\n        const ajax = request();\r\n        a" +
"jax.success(function (response) {\r\n            var options = \"<option>Select</op" +
"tion>\";\r\n\r\n            $.each(response, function () {\r\n                var optio" +
"n = \"<option value=\'{key}\'>{value}</option>\";\r\n                option = option.r" +
"eplace(\"{key}\", this.ItemCode);\r\n                option = option.replace(\"{value" +
"}\", this.ItemName);\r\n\r\n                options += option;\r\n            });\r\n\r\n  " +
"          itemSelect.html(options);\r\n        });\r\n    };\r\n\r\n    function loadUni" +
"ts() {\r\n        function request(itemCode) {\r\n            var url = \"/dashboard/" +
"inventory/get-associated-units/{*itemCode}\";\r\n            url = url.replace(\"{*i" +
"temCode}\", itemCode);\r\n\r\n            return window.getAjaxRequest(url);\r\n       " +
" };\r\n\r\n        const itemCode = itemCodeInputText.val();\r\n        const ajax = r" +
"equest(itemCode);\r\n        ajax.success(function (response) {\r\n            var o" +
"ptions = \"<option>Select</option>\";\r\n\r\n            $.each(response, function () " +
"{\r\n                var option = \"<option value=\'{key}\'>{value}</option>\";\r\n     " +
"           option = option.replace(\"{key}\", this.UnitId);\r\n                optio" +
"n = option.replace(\"{value}\", this.UnitName);\r\n\r\n                options += opti" +
"on;\r\n            });\r\n\r\n            unitSelect.html(options);\r\n        });\r\n    " +
"};\r\n\r\n    shortcut.add(\"CTRL+ENTER\", function () {\r\n        addButton.trigger(\'c" +
"lick\');\r\n    });\r\n\r\n    //$(\"select\").dropdown();\r\n    window.overridePath = \"/d" +
"ashboard/inventory/tasks/inventory-transfers\";\r\n\r\n    var visible = false;\r\n\r\n  " +
"  $(document).ajaxStop(function () {\r\n        setTimeout(function () {\r\n        " +
"    if (!visible) {\r\n                visible = true;\r\n\r\n                $(\".page" +
".segment\").fadeIn(300);\r\n            };\r\n        }, 200);\r\n    });\r\n</script>");

        }
    }
}
#pragma warning restore 1591
