
function LoadPackage(PACKAGE_ID) {

    var IsEdit = document.getElementById("Edit_Package").innerHTML;
    var IsDelete = document.getElementById("Delete_Package").innerHTML;
    var IsAdd = document.getElementById("Add_Package").innerHTML;

    var model = {

        "PACKAGE_ID": (PACKAGE_ID == null ? "0" : PACKAGE_ID) || (PACKAGE_ID == '' ? "0" : PACKAGE_ID) || (PACKAGE_ID == undefined ? "0" : PACKAGE_ID) || (PACKAGE_ID == "" ? "0" : BATCH_ID) || (PACKAGE_ID == null ? '-' : PACKAGE_ID)
    };
    $("#PackageGrid").DataTable().clear();
    $("#PackageGrid").dataTable().fnDestroy();

    var table = $('#PackageGrid').DataTable({
        "proccessing": true,
        "serverSide": true,
        //"scrollX": true,
        //"scrollY": '50vh',
        //scroller: true,

        "ajax": {
            complete: function (data) {
                //  $(".MasterLoader").fadeOut();
            },
            url: "MasterSetting/GetPackage",
            "language": {
                'processing': '<i class="fa fa-spinner fa-spin fa-3x fa-fw"></i><span class="sr-only">Loading...</span>'
            },
            data: {
                _model: model
            },
            type: 'POST'
        },
        "columns": [
            {
                render: function (data, type, row) {

                    var strAction = '';
                    if (IsEdit == 'true' || IsEdit == 'True') {
                        strAction += '<button id="btnEdit" class="btn btn-success btn-sm rounded-0" data-original-title="Edit"  onclick="EditPackage(\'' + encodeURIComponent(row.PACKAGE_ID)
                            + '\',\'' + encodeURIComponent(row.TITLE)
                            + '\',\'' + encodeURIComponent(row.DESCRIPTION)
                            + '\',\'' + encodeURIComponent(row.FEES)
                            + '\',\'' + encodeURIComponent(row.TAX_ID)
                            + '\',\'' + encodeURIComponent(row.TOTAL_FEES)
                            + '\')"><i class="fa fa-edit"></i></button >';

                        strAction += '<button id="btnDelete" class="btn btn-danger  btn-sm rounded-0" data-original-title="Edit"  onclick="DeletePackage(\'' + encodeURIComponent(row.PACKAGE_ID)
                            + '\')"><i class="fa fa-trash"></i></button >';
                    }

                    return strAction
                },
                width: '100px'
            },
            { "data": "PACKAGE_ID", "width": '200px' },
            { "data": "TITLE", "width": '200px' },
            { "data": "DESCRIPTION", "width": '100px' },
            { "data": "FEES", "width": '100px' },
            { "data": "TAX_NAME", "width": '50px' },
            { "data": "TOTAL_FEES", "width": '50px' }
        ],
    });
}
function AddPackage() {

    //var PACKAGE_ID = $('#').val();
    var title = $('#title').val();
    var description = $('#description').val();
    var fees = $('#fees').val();
    var tax = $('#tax').val();
    var totalfees = $('#totalfees').val();

    if (title == '-' || title == null || title == '' || title == undefined || title == 'undefined') {
        Toast.fire({
            icon: 'error',
            title: 'Please enter title'
        });
        $('#title').focus();
        return false;
    }
    if (description == '-' || description == null || description == '' || description == undefined || description == 'undefined') {
        Toast.fire({
            icon: 'error',
            title: 'Please enter description'
        });
        $('#description').focus();
        return false;
    }
    if (fees == '-' || fees == null || fees == '' || fees == undefined || fees == 'undefined') {
        Toast.fire({
            icon: 'error',
            title: 'Please enter fees'
        });
        $('#fees').focus();
        return false;
    }
    if (tax == '-' || tax == null || tax == '' || tax == undefined || tax == 'undefined') {
        Toast.fire({
            icon: 'error',
            title: 'Please enter tax'
        });
        $('#tax').focus();
        return false;
    }
    if (totalfees == '-' || totalfees == null || totalfees == '' || totalfees == undefined || totalfees == 'undefined') {
        Toast.fire({
            icon: 'error',
            title: 'Please enter totalfees'
        });
        $('#totalfees').focus();
        return false;
    }

    _model = {
        "PACKAGE_ID": ($('#hdnPackageId').val() == null ? 0 : $('#hdnPackageId').val()) || ($('#hdnPackageId').val() == '' ? 0 : $('#hdnPackageId').val()) || ($('#hdnPackageId').val() == "" ? 0 : $('#hdnPackageId').val()) || ($('#hdnPackageId').val() == undefined ? 0 : $('#hdnPackageId').val()),
        "TITLE": title,
        "DESCRIPTION": description,
        "FEES": fees,
        "TAX_ID": tax,
        "TOTAL_FEES": totalfees,
        "OPERATION_STATUS": ($('#hdnPackageId').val() === '' ? "ADD" : "UPDATE")
    }

    $.ajax({
        type: 'POST',
        url: 'MasterSetting/CreatePackage',
        data: {
            model: _model
        },
        dataType: 'JSON',
        success: function (result) {
            Toast.fire({
                icon: result.RESPONSETYPE == "0" ? 'error' : 'success',
                title: result.RESPONSEMESSAGE
            });
            LoadPackage();
            if (result.RESPONSETYPE == "1") {
                $('#PackageModel').modal('hide');
            }

        },
        error: function (xhr, textStatus, error) {

        }
    });

}
function EditPackage(PACKAGE_ID, TITLE, DESCRIPTION, FEES, TAX_ID, TOTAL_FEES) {
    debugger;
    var PACKAGE_ID = decodeURIComponent(PACKAGE_ID);
    $('#hdnPackageId').val(PACKAGE_ID);
    var TITLE = decodeURIComponent(TITLE);
    var DESCRIPTION = decodeURIComponent(DESCRIPTION);
    var FEES = decodeURIComponent(FEES);
    var TAX_ID = decodeURIComponent(TAX_ID);
    var TOTAL_FEES = decodeURIComponent(TOTAL_FEES);
    $('#PackageModel').modal('show');
    $('#title').val(TITLE);
    $('#description').val(DESCRIPTION);
    $('#fees').val(FEES);
    $('#tax').val(TAX_ID);
    $('#tax').change();
    $('#totalfees').val(TOTAL_FEES);

}
function DeletePackage(PACKAGE_ID) {
    var PACKAGE_ID = decodeURIComponent(PACKAGE_ID);

}

function OpenCreatePackage() {
    $('#PackageModel').modal('show');
    $('#hdnPackageId').val('');
}
var itemsArray = [];
function LoadTaxList() {
    var ddlId = '#tax';
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

            $(ddlId).append($('<option/>').val('-').text('Select Trainer'));

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
                dropdownParent: $("#PackageModel")
            });
        }
    });
}
function CalculateFees() {
    debugger;
    var fees = $('#fees').val();
    var tax_id = $('#tax').val();
    if (fees != null || fees != '' || fees != 0 || fees != "" || fees != '-' || fees != undefined) {
       
        var list = itemsArray.filter(x => x.id == tax_id);
        var calPercent = (fees / 100) * list[0].tax;
        var caltotal = parseFloat(fees) + parseFloat(calPercent);
        $('#totalfees').attr('disabled','disabled');
        $('#totalfees').val(caltotal);
    }
}