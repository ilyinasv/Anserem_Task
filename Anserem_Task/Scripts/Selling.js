
$(document).ready(function () {
    loadData();
});

function loadData() {
    $.ajax({
        url: "/Home/List",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = '';
            $.each(result, function (key, item) {
                html += '<tr>';
                html += '<td>' + item.Name + '</td>';
                html += '<td>' + item.SellingContact + '</td>';
                html += '<td>' + item.ContractorName + '</td>';
                html += '<td>' + item.ContractorContactPerson + '</td>';
                html += '<td>' + item.ContractorCity + '</td>';
                html += '<td><a href="#" onclick="return getbyID(' + item.SellingId + ')">Edit</a> | <a href="#" onclick="Delele(' + item.SellingId + ')">Delete</a> | <a href="#" onclick="Copy(' + item.SellingId + ')">Copy</a></td>';
                html += '</tr>';
            });
            $('.tbody').html(html);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

function Add() {
    var selObj = {
        SellingId: $('#SellingId').val(),
        Name: $('#Name').val(),
        SellingContact: $('#SellingContact').val(),
        ContractorName: $('#ContractorName').val(),
        ContractorContactPerson: $('#ContractorContactPerson').val(),
        ContractorCity: $('#ContractorCity').val()
    };
    $.ajax({
        url: "/Home/Add",
        data: JSON.stringify(selObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadData();
            $('#myModal').modal('hide');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

function Copy(ID) {
    $.ajax({
        url: "/Home/Copy/" + ID,
        type: "POST",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            loadData();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });

}

function getbyID(ID) {
    $('#Name').css('border-color', 'lightgrey');
    $('#Age').css('border-color', 'lightgrey');
    $('#State').css('border-color', 'lightgrey');
    $('#Country').css('border-color', 'lightgrey');
    $.ajax({
        url: "/Home/GetByID/" + ID,
        typr: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            $('#SellingId').val(result.SellingId);
            $('#Name').val(result.Name);
            $('#SellingContact').val(result.SellingContact);
            $('#ContractorName').val(result.ContractorName);
            $('#ContractorContactPerson').val(result.ContractorContactPerson);
            $('#ContractorCity').val(result.ContractorCity);

            $('#myModal').modal('show');
            $('#btnUpdate').show();
            $('#btnAdd').hide();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}

function Update() {
    var selObj = {
        SellingId: $('#SellingId').val(),
        Name: $('#Name').val(),
        SellingContact: $('#SellingContact').val(),
        ContractorName: $('#ContractorName').val(),
        ContractorContactPerson: $('#ContractorContactPerson').val(),
        ContractorCity: $('#ContractorCity').val()
    };
    $.ajax({
        url: "/Home/Update",
        data: JSON.stringify(selObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadData();
            $('#myModal').modal('hide');
            $('#SellingId').val("");
            $('#Name').val("");
            $('#SellingContact').val("");
            $('#ContractorName').val("");
            $('#ContractorContactPerson').val("");
            $('#ContractorCity').val("");
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

function Delele(ID) {
    var ans = confirm("Delete selling?");
    if (ans) {
        $.ajax({
            url: "/Home/Delete/" + ID,
            type: "POST",
            contentType: "application/json;charset=UTF-8",
            dataType: "json",
            success: function (result) {
                loadData();
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
}

function clearTextBox() {
    $('#SellingId').val("");
    $('#Name').val("");
    $('#SellingContact').val("");
    $('#ContractorName').val("");
    $('#ContractorContactPerson').val("");
    $('#ContractorCity').val("");
    $('#btnUpdate').hide();
    $('#btnAdd').show();
    $('#Name').css('border-color', 'lightgrey');
    $('#Age').css('border-color', 'lightgrey');
    $('#State').css('border-color', 'lightgrey');
    $('#Country').css('border-color', 'lightgrey');
}
