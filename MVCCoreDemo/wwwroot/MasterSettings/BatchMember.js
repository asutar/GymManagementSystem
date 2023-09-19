
function LoadBatchMemberList() {

    var IsEdit = document.getElementById("Edit_BatchMember").innerHTML;
    var IsDelete = document.getElementById("Delete_BatchMember").innerHTML;
    var IsAdd = document.getElementById("Add_BatchMember").innerHTML;

    $("#BatchMemberGrid").DataTable().clear();
    $("#BatchMemberGrid").dataTable().fnDestroy();

    var table = $('#BatchMemberGrid').DataTable({
        "proccessing": true,
        "serverSide": true,
        //"scrollX": true,
        //"scrollY": '50vh',
        //scroller: true,

        "ajax": {
            complete: function (data) {
                //  $(".MasterLoader").fadeOut();
            },
            url: "MasterSetting/GetBatchMember",
            "data": function (d) {

                DRIVER_ID = "0"
            },
            type: 'POST'
        },
        "columns": [
            {
                render: function (data, type, row) {

                    var strAction = '';
                    if (IsEdit == 'true' || IsEdit == 'True') {
                        strAction += '<button id="btnEdit" class="btn btn-success btn-sm rounded-0" data-original-title="Edit"  onclick="EditBatchMember(\'' + encodeURIComponent(row.BATCH_MEMBER_MAPPING_ID)
                            + '\',\'' + encodeURIComponent(row.MEMBERID)
                            + '\',\'' + encodeURIComponent(row.BATCH_ID)
                            + '\',\'' + encodeURIComponent(row.START_DATE)
                            + '\',\'' + encodeURIComponent(row.END_DATE)
                            + '\',\'' + encodeURIComponent(row.PACKAGE_ID)
                            + '\',\'' + encodeURIComponent(row.IS_ON_HOLD)
                            + '\')"><i class="fa fa-edit"></i></button >';
                    }

                    return strAction;
                },
            },
            { "data": "BATCH_MEMBER_MAPPING_ID", "width": '50px' },
            { "data": "MEMBERNAME", "width": '200px' },
            { "data": "BATCHNAME", "width": '200px' },
            { "data": "START_DATE", "width": '100px' },
            { "data": "END_DATE", "width": '100px' },
            {
                render: function (data, type, row) {
                    return (row.IS_ACTIVE == 0 ? '<span class="badge bg-danger">In Active</span>' : '<span class="badge bg-success"> Active</span>')
                }
            }
        ],
        //"order": [[1, "asc"]],
    });
}
function OpenCreateBatch() {
    Clear();
    $('#startdate').val('');
    LoadMemberList();
    LoadBatchList();
    //$('#startdate').attr('disabled', false);
    $('#enddate').attr('disabled', true);
    $('#member').attr('disabled', false);
    $('#MemberRegitrationModel').modal('show');
    $('#NextFeesDate').val('');

}
function AddBatchMember() {
    //debugger;
    var member = $('#member').val();
    var batch = $('#batch').val();
    var startdate = $('#startdate').val();
    var enddate = $('#enddate').val();
    var package = $('#package').val();
    var chkOnHold = $('#chkOnHold').is(':checked');
    var NextFeesDate = $('#NextFeesDate').val();

    if (member == '-' || member == null || member == '' || member == undefined || member == 'undefined') {
        Toast.fire({
            icon: 'error',
            title: 'Please select member'
        });
        $('#member').focus();
        return false;
    }
    if (batch == '-' ||batch == null || batch == '' || batch == undefined || batch == 'undefined') {
        Toast.fire({
            icon: 'error',
            title: 'Please select batch'
        });
        $('#batch').focus();
        return false;
    }
    if (startdate == null || startdate == '' || startdate == undefined || startdate == 'undefined') {
        Toast.fire({
            icon: 'error',
            title: 'Please select start date'
        });
        $('#startdate').focus();
        return false;
    }
    if (enddate == null || enddate == '' || enddate == undefined || enddate == 'undefined') {
        Toast.fire({
            icon: 'error',
            title: 'Please select start date'
        });
        $('#enddate').focus();
        return false;
    }
    if (NextFeesDate == null || NextFeesDate == '' || NextFeesDate == undefined || NextFeesDate == 'undefined') {
        Toast.fire({
            icon: 'error',
            title: 'Please select next fees date'
        });
        $('#NextFeesDate').focus();
        return false;
    }

    _model = {
        "BATCH_MEMBER_MAPPING_ID": ($('#hdnBatchId').val() == null ? 0 : $('#hdnBatchId').val()) || ($('#hdnBatchId').val() == '' ? 0 : $('#hdnBatchId').val()) || ($('#hdnBatchId').val() == "" ? 0 : $('#hdnBatchId').val()) || ($('#hdnBatchId').val() == undefined ? 0 : $('#hdnBatchId').val()),
        "MEMBERID": member,
        "BATCH_ID": batch,
        "START_DATE": startdate,
        "END_DATE": enddate,
        "PACKAGE_ID": package,
        "IS_ON_HOLD": chkOnHold,
        "NEXT_FEES_DATETIME": NextFeesDate,
        "OPERATION_STATUS": ($('#hdnBatchId').val() === '' ? "ADD" : "UPDATE")
    }

    $.ajax({
        type: 'POST',
        url: 'MasterSetting/CreateBatchMember',
        data: {
            model: _model
        },
        dataType: 'JSON',
        success: function (result) {
            Toast.fire({
                icon: result.RESPONSETYPE == "0" ? 'error' : 'success',
                title: result.RESPONSEMESSAGE
            });
            LoadBatchMemberList();
            if (result.RESPONSETYPE == "1") {
                $('#MemberRegitrationModel').modal('hide');
            }

        },
        error: function (xhr, textStatus, error) {

        }
    });
}
function UpdateBatchMember() {
    debugger;
    var member = $('#member').val();
    var batch = $('#batch').val();
    var startdate = $('#startdate').val();
    var enddate = $('#enddate').val();

    if (member == '-' || member == null || member == '' || member == undefined || member == 'undefined') {
        Toast.fire({
            icon: 'error',
            title: 'Please select member'
        });
        $('#member').focus();
        return false;
    }
    if (batch == '-' || batch == null || batch == '' || batch == undefined || batch == 'undefined') {
        Toast.fire({
            icon: 'error',
            title: 'Please select batch'
        });
        $('#batch').focus();
        return false;
    }
    if (startdate == null || startdate == '' || startdate == undefined || startdate == 'undefined') {
        Toast.fire({
            icon: 'error',
            title: 'Please select start date'
        });
        $('#startdate').focus();
        return false;
    }
    if (enddate == null || enddate == '' || enddate == undefined || enddate == 'undefined') {
        Toast.fire({
            icon: 'error',
            title: 'Please select start date'
        });
        $('#enddate').focus();
        return false;
    }

    _model = {
        "BATCH_MEMBER_MAPPING_ID": ($('#hdnBatchId').val() == null ? 0 : $('#hdnBatchId').val()) || ($('#hdnBatchId').val() == '' ? 0 : $('#hdnBatchId').val()) || ($('#hdnBatchId').val() == "" ? 0 : $('#hdnBatchId').val()) || ($('#hdnBatchId').val() == undefined ? 0 : $('#hdnBatchId').val()),
        "BATCH_ID": batch,
        "START_DATE": startdate,
        "END_DATE": enddate,
        "OPERATION_STATUS": ($('#hdnBatchId').val() === '' ? "ADD" : "UPDATE")
    }

    $.ajax({
        type: 'POST',
        url: 'MasterSetting/UpdateBatchMember',
        data: {
            model: _model
        },
        dataType: 'JSON',
        success: function (result) {
            Toast.fire({
                icon: result.RESPONSETYPE == "0" ? 'error' : 'success',
                title: result.RESPONSEMESSAGE
            });
            LoadBatchMemberList();
            if (result.RESPONSETYPE == "1") {
                $('#MemberRegitrationModel').modal('hide');
            }

        },
        error: function (xhr, textStatus, error) {

        }
    });
}
function LoadMemberList() {
    var ddlId = '#member';
    _model = {
        "MEMBERID": 0,
    }
    $.ajax({
        type: "POST",
        url: "MasterSetting/GetMemberList",
        dataType: 'json',
        async: true,
        data: {
            model: _model
        },
        success: function (response) {

            $(ddlId).empty();

            $(ddlId).append($('<option/>').val('-').text('Select Member'));

            $.each(response, function (i, item) {

                $(ddlId).append($('<option data-RoleId = "' + item.MEMBERID + '"/>').val(item.MEMBERID).text(item.NAME));

            });
            $(ddlId).select2();
            $(ddlId).select2({
                dropdownParent: $("#MemberRegitrationModel")
            });
        }
    });
}
function LoadBatchList() {
    var ddlId = '#batch';
    _model = {
        "BATCH_TIMING_ID": 0,
    }
    $.ajax({
        type: "POST",
        url: "MasterSetting/GetBatchScheduledDateTimeList",
        dataType: 'json',
        async: true,
        data: {
            model: _model
        },
        success: function (response) {

            $(ddlId).empty();

            $(ddlId).append($('<option/>').val('-').text('Select Batch'));

            $.each(response, function (i, item) {

                $(ddlId).append($('<option data-RoleId = "' + item.BATCH_TIMING_ID + '"/>').val(item.BATCH_TIMING_ID).text(item.BATCH_NAME));

            });
            $(ddlId).select2();
            $(ddlId).select2({
                dropdownParent: $("#MemberRegitrationModel")
            });
        }
    });
}
function LoadPackageList() {
    var ddlId = '#package';
    _model = {
        "PACKAGE_ID": 0,
    }
    $.ajax({
        type: "POST",
        url: "MasterSetting/GetPackageList",
        dataType: 'json',
        async: true,
        data: {
            model: _model
        },
        success: function (response) {

            $(ddlId).empty();

            $(ddlId).append($('<option/>').val('-').text('Select Package'));

            $.each(response, function (i, item) {

                $(ddlId).append($('<option data-RoleId = "' + item.PACKAGE_ID + '"/>').val(item.PACKAGE_ID).text(item.TITLE));

            });
            $(ddlId).select2();
            $(ddlId).select2({
                dropdownParent: $("#MemberRegitrationModel")
            });
        }
    });
}
function EditBatchMember(BATCH_MEMBER_MAPPING_ID, MEMBERID, BATCH_ID, START_DATE, END_DATE, PACKAGE_ID, IS_ON_HOLD) {
    //debugger;
    Clear();
    $('#enddate').attr('disabled', true);
    $('#MemberRegitrationModel').modal('show');
    $('#hdnBatchId').val(decodeURIComponent(BATCH_MEMBER_MAPPING_ID));
    $('#member').val(decodeURIComponent(MEMBERID));
    $('#member').change();
    $('#member').attr('disabled','disabled');
    $('#batch').val(decodeURIComponent(BATCH_ID));
    $('#batch').change();
    $('#startdate').val(decodeURIComponent(START_DATE));
    //$('#startdate').attr('disabled', 'disabled');
    $('#enddate').val(decodeURIComponent(END_DATE));
    $('#package').val(decodeURIComponent(PACKAGE_ID));
    $('#package').change();
    //$('#chkOnHold').val(decodeURIComponent(IS_ON_HOLD));
    if (IS_ON_HOLD == 'true') {
        $('#chkOnHold').prop('checked', true);
    } else {
        $('#chkOnHold').prop('unchecked', false);
    }
   
    //$('#enddate').attr('disabled', 'disabled');
}
function Clear() {
    $('#hdnBatchId').val('');
    $('#member').val('');
    $('#batch').val('');
    $('#package').val('');
    $('#startdate').val('');
    $('#enddate').val('');
}
