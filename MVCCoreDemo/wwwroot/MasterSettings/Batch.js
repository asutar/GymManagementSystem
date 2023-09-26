function LoadBatchList() {

    var IsEdit = document.getElementById("Edit_Batch").innerHTML;
    var IsDelete = document.getElementById("Delete_Batch").innerHTML;
    var IsAdd = document.getElementById("Add_Batch").innerHTML;

    $("#BatchGrid").DataTable().clear();
    $("#BatchGrid").dataTable().fnDestroy();

    var table = $('#BatchGrid').DataTable({
        "proccessing": true,
        "serverSide": true,
        //"scrollX": true,
        //"scrollY": '50vh',
        //scroller: true,

        "ajax": {
            complete: function (data) {
                //  $(".MasterLoader").fadeOut();
            },
            url: "MasterSetting/GetBatch",
            "data": function (d) {

                DRIVER_ID = "0"
            },
            "language": {
                'processing': '<i class="fa fa-spinner fa-spin fa-3x fa-fw"></i><span class="sr-only">Loading...</span>'
            },
            type: 'POST'
        },
        "columns": [
            {
                render: function (data, type, row) {

                    var strAction = '';
                    if (IsEdit == 'true' || IsEdit == 'True') {
                        strAction += '<button id="btnEdit" class="btn btn-success btn-sm rounded-0" data-original-title="Edit"  onclick="EditBatch(\'' + encodeURIComponent(row.BATCH_ID)
                            + '\',\'' + encodeURIComponent(row.NAME)
                            + '\',\'' + encodeURIComponent(row.DESCRIPTION)
                            + '\',\'' + encodeURIComponent(row.FROM_DATE)
                            + '\',\'' + encodeURIComponent(row.TO_DATE)
                            + '\',\'' + encodeURIComponent(row.AMOUNT)
                            + '\',\'' + encodeURIComponent(row.TAX_ID)
                            + '\',\'' + encodeURIComponent(row.GST_AMOUNT)
                            + '\',\'' + encodeURIComponent(row.TOTAL_AMOUNT)
                            + '\',\'' + encodeURIComponent(row.NO_OF_DAYS)
                            + '\')"><i class="fa fa-edit"></i></button >';
                    }

                    return strAction;
                },
            },
            { "data": "BATCH_ID", "width": '100px' },
            { "data": "NAME", "width": '200px' },
            { "data": "DESCRIPTION", "width": '200px' },
            //{ "data": "FROM_DATE", "width": '200px' },
            //{ "data": "TO_DATE", "width": '200px' },
            { "data": "AMOUNT", "width": '200px' },
            { "data": "TAX_NAME", "width": '200px' },
            { "data": "GST_AMOUNT", "width": '200px' },
            { "data": "TOTAL_AMOUNT", "width": '200px' },
            { "data": "NO_OF_DAYS", "width": '200px' },
        ],
        //"order": [[1, "asc"]],
    });
}
function OpenCreateBatch() {
    setTimeout(function () {
        $("#overlay").fadeOut(300);
    }, 500);
    Clear();
    $('#MemberRegitrationModel').modal('show');
}
function AddBatch() {

    var name = $('#name').val();
    var Description = $('#description').val();
    var FromDate = $('#FromDate').val();
    var ToDate = $('#ToDate').val();
    var Amount = $('#Amount').val();
    var TaxType = $('#TaxType').val();
    var GSTAmount = $('#GSTAmount').val();
    var TotalAmount = $('#TotalAmount').val();
    var NoOfDays = $('#NoOfDays').val();

    if (name == null || name == '' || name == undefined || name == 'undefined') {
        Toast.fire({
            icon: 'error',
            title: 'Please enter Name'
        });
        $('#firstName').focus();
        return false;
    }
    if (Description == null || Description == '' || Description == undefined || Description == 'undefined') {
        Toast.fire({
            icon: 'error',
            title: 'Please enter description'
        });
        $('#lastName').focus();
        return false;
    }
    if (Amount == null || Amount == '' || Amount == undefined || Amount == 'undefined') {
        Toast.fire({
            icon: 'error',
            title: 'Please enter Amount'
        });
        $('#Amount').focus();
        return false;
    }
    if (TaxType == null || TaxType == '' || TaxType == undefined || TaxType == 'undefined') {
        Toast.fire({
            icon: 'error',
            title: 'Please select Tax Type'
        });
        $('#TaxType').focus();
        return false;
    }
    if (GSTAmount == null || GSTAmount == '' || GSTAmount == undefined || GSTAmount == 'undefined') {
        Toast.fire({
            icon: 'error',
            title: 'Please enter GST Amount'
        });
        $('#GSTAmount').focus();
        return false;
    }
    if (TotalAmount == null || TotalAmount == '' || TotalAmount == undefined || TotalAmount == 'undefined') {
        Toast.fire({
            icon: 'error',
            title: 'Please enter Total Amount'
        });
        $('#TotalAmount').focus();
        return false;
    }

    _model = {
        "BATCH_ID": ($('#hdnBatchId').val() == null ? 0 : $('#hdnBatchId').val()) || ($('#hdnBatchId').val() == '' ? 0 : $('#hdnBatchId').val()) || ($('#hdnBatchId').val() == "" ? 0 : $('#hdnBatchId').val()) || ($('#hdnBatchId').val() == undefined ? 0 : $('#hdnBatchId').val()),
        "NAME": name,
        "DESCRIPTION": Description,
        //"FROM_DATE": FromDate,
        //"TO_DATE": ToDate,
        "AMOUNT": Amount,
        "TAX_ID": TaxType,
        "GST_AMOUNT": GSTAmount,
        "TOTAL_AMOUNT": TotalAmount,
        "NO_OF_DAYS": NoOfDays,
        "OPERATION_STATUS": ($('#hdnBatchId').val() === '' ? "ADD" : "UPDATE")
    }
    $('#mySpinner').addClass('spinner');
    $.ajax({
        type: 'POST',
        url: 'MasterSetting/CreateBatch',
        data: {
            model: _model
        },
        dataType: 'JSON',
        success: function (result) {
            $('#mySpinner').removeClass('spinner');
            Toast.fire({
                icon: result.RESPONSETYPE == "0" ? 'error' : 'success',
                title: result.RESPONSEMESSAGE
            });
            LoadBatchList();
            if (result.RESPONSETYPE == "1") {
                $('#MemberRegitrationModel').modal('hide');
            }

        },
        error: function (xhr, textStatus, error) {

        }
    });
}
function EditBatch(BATCH_ID, NAME, DESCRIPTION, FROM_DATE, TO_DATE, AMOUNT, TAX_ID, GST_AMOUNT, TOTAL_AMOUNT, NO_OF_DAYS) {
    //debugger;
    Clear();
    $('#MemberRegitrationModel').modal('show');
    $('#hdnBatchId').val(decodeURIComponent(BATCH_ID));
    $('#name').val(decodeURIComponent(NAME));
    $('#description').val(decodeURIComponent(DESCRIPTION));
    //$('#FromDate').val(decodeURIComponent(FROM_DATE));
    //$('#ToDate').val(decodeURIComponent(TO_DATE));
    $('#Amount').val(decodeURIComponent(AMOUNT));
    $('#GSTAmount').val(decodeURIComponent(GST_AMOUNT));
    $('#TaxType').val(decodeURIComponent(TAX_ID));
    $('#TaxType').change();
    $('#TotalAmount').val(decodeURIComponent(TOTAL_AMOUNT));
    $('#NoOfDays').val(decodeURIComponent(NO_OF_DAYS));
}
function Clear() {
    $('#hdnBatchId').val('');
    $('#name').val('');
    $('#description').val('');
    $('#FromDate').val('');
    $('#ToDate').val('');
    $('#Amount').val('');
    $('#GSTAmount').val('');
    $('#TaxType').val('');
    $('#TotalAmount').val('');
}
var itemsArray = [];
function LoadTaxList() {
    var ddlId = '#TaxType';
    _model = {
        "TAX_ID": 0,
    }
    $.ajax({
        type: "POST",
        url: "MasterSetting/GetTaxList",
        dataType: 'json',
        async: true,
        data: {
            model: _model
        },
        success: function (response) {

            $(ddlId).empty();

            $(ddlId).append($('<option/>').val('-').text('Select Tax'));

            $.each(response, function (i, item) {

                $(ddlId).append($('<option data-RoleId = "' + item.TAX_ID + '" />').val(item.TAX_ID).text(item.TAX_NAME));
                var newItem = {
                    id: item.TAX_ID,
                    tax: item.DEDUCATION_PERCENT
                };
                itemsArray.push(newItem);
            });

            $(ddlId).select2();
            $(ddlId).select2({
                dropdownParent: $("#MemberRegitrationModel")
            });
        }
    });
}
function CalculateFees() {
    debugger;
    var fees = $('#Amount').val();
    var tax_id = $('#TaxType').val();
    if (fees != null || fees != '' || fees != 0 || fees != "" || fees != '-' || fees != undefined) {

        var list = itemsArray.filter(x => x.id == tax_id);
        var calPercent = (fees / 100) * list[0].tax;
        var caltotal = parseFloat(fees) + parseFloat(calPercent);
        $('#GSTAmount').val(calPercent);
        $('#TotalAmount').attr('disabled', 'disabled');
        $('#TotalAmount').val(caltotal);
    }
}