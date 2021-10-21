/*CREATE BY :Maduwantha Hettiarachchi
DATE : 12/16/2019**/

//ALL TYPE SHOULD BE HERE

// 1=Employee

var type;// this is globle value for the popup
var SubItemCode; //CompPramDetail && wagerate
var InstitueCode;
var arrController = [];

function getSearch(companyId, PageIndex) {
    debugger;
    switch (this.type) {
        case 1:
            GetEmployees(this.arrController, companyId, PageIndex, this.type);
            break;
        case 2:
            GetLeaveCodes(this.arrController, companyId, PageIndex, this.type);
            break;
        default:
        // code block
    }
}

function GetEmployees(arrController, companyId, PageIndex, type) {
    debugger;
    this.arrController = arrController;
    this.type = type;
    $.ajax({
        type: "POST",
        url: "Common.aspx/GetEmployees/",
        data: "{ 'key': '" + key + "' }",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            if (response.d.DataSource.length > 0) {
                setModalTable(response.d);
            }
        },
        failure: function (r) {
            alert(r.d);
        },
        error: function (r) {
            alert(r.d);
        }
    });
}

function GetLeaveCodes(arrController, companyId, PageIndex, type) {
    debugger;
    this.arrController = arrController;
    this.type = type;
    $.ajax({
        type: "POST",
        url: "Common.aspx/GetLeaveCodes/",
        data: "{ 'key': '" + key + "' }",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            if (response.d.DataSource.length > 0) {
                setModalTable(response.d);
            }
        },
        failure: function (r) {
            alert(r.d);
        },
        error: function (r) {
            alert(r.d);
        }
    });
}

//Using HTML table
function setModalTable(data) {
    debugger;
    var xmlDoc = $.parseXML(data.DataSource);
    var xml = $(xmlDoc);
    var EmployeeDEs = xml.find("dsSearch");
    var table_body = '<table class="table table-bordered table-hover">';
    table_body += '<tr><th>Value</th><th>Description</th><th></th></tr>';
    $.each(EmployeeDEs, function () {
        var de = $(this);
        table_body += '<tr>';
        table_body += '<td style="width:25%">';
        table_body += $(this).find("Value").text();
        table_body += '</td>';
        table_body += '<td style="width:65%">';
        table_body += $(this).find("Text").text();
        table_body += '</td>';
        table_body += '<td style="width:10%">';
        table_body += '<button type="button"  onclick="Select(this)" class="use-address btn btn-block btn-info btn-xs"><span class="btn-label"><i class="icon-options"></i></span></button>';
        table_body += '</td>';
        table_body += '</tr>';
    });
    table_body += '</table>';
    $('#tableModal').html(table_body);
    $(".Pager").ASPSnippets_Pager({
        ActiveCssClass: "current",
        PagerCssClass: "pager",
        PageIndex: parseInt(data.PageIndex),
        PageSize: parseInt(data.PageSize),
        RecordCount: parseInt(data.RecordCount)
    });
    $('#txtModalSearch').focus();
}

$('.use-address').click(function () {
    var value = $(this).closest("tr").find('td:eq(0)').text();
    var text = $(this).closest("tr").find('td:eq(1)').text();
    document.getElementById(arrController[0]).value = value;
    $(arrController[1]).text(text);
    $('#exampleModal').modal('hide');
});

//Dynamic table for front page

//Table Header Description
function GetTableColumns() {
    var Designation = { DesignationCode: "Designation Code", Name: "Name", NameLng1: "Name (Sinhala)", NameLng2: "Name (Tamil)", Edit: "Edit", Delete: "Delete" };
    return Designation;
}

function GetDesignationTable() {
    $.ajax({
        type: "POST",
        url: "Designation.aspx/GetDesignationTable",
        data: "",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            if (response.d.length > 0) {
                $('#tableDesignation').html(GetTable(response.d));
            }
        },
        failure: function (r) {
            alert(r.d);
        },
        error: function (r) {
            alert(r.d);
        }
    });
}

function GetCommonTable(response, method) {
    var xmlDoc = $.parseXML(response.d.DataSource);
    var xml = $(xmlDoc);
    var dsSearch = xml.find("dsSearch");
    var table_body = '<table class="table table-bordered table-hover">';
    table_body += '<tr><th>Value</th><th>Description</th><th></th></tr>';
    $.each(dsSearch, function () {
        var de = $(this);
        table_body += '<tr>';
        table_body += '<td style="width:25%">';
        table_body += $(this).find("Value").text();
        table_body += '</td>';
        table_body += '<td style="width:65%">';
        table_body += $(this).find("Text").text();
        table_body += '</td>';
        table_body += '<td style="width:10%">';
        table_body += '<button type="button"  ' + method + ' class="use-address btn btn-block btn-info btn-xs"><span class="btn-label"><i class="fa fa-youtube-play"></i></span></button>';
        table_body += '</td>';
        table_body += '</tr>';
    });
    table_body += '</table>';
    $('#tableCommonModal').html(table_body);
    $(".Pager").ASPSnippets_Pager({
        ActiveCssClass: "current",
        PagerCssClass: "pager",
        PageIndex: parseInt(response.d.PageIndex),
        PageSize: parseInt(response.d.PageSize),
        RecordCount: parseInt(response.d.RecordCount)
    });
}




