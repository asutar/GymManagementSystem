function OpenBatchTiming() {
    Clear();
    $('#batchModal').modal('show');
    $('#hdnBatchId').val('');
}
function OpenCreateBatchTiming() {
    $('#CreatebatchTImeModal').modal('show');
    $('#hdnBatchId').val('');
    $('#batch').attr("disabled", false);
    $('#batch').val(0);
    $('#batch').change();
    $('#trainer').attr("disabled", false);
    $('#trainer').val(0);
    $('#trainer').change();
    $('#fromDate').val('');
    $('#toDate').val('');
    $('#fromTime').val('');
    $('#toTime').val('');
}
function LoadBatchList() {
    var ddlId = '#batch';
    _model = {
        "BATCH_ID": 0,
    }
    $.ajax({
        type: "POST",
        url: "MasterSetting/GetBatchList",
        dataType: 'json',
        async: true,
        data: {
            model: _model
        },
        success: function (response) {

            $(ddlId).empty();

            $(ddlId).append($('<option/>').val('-').text('Select Batch'));

            $.each(response, function (i, item) {

                $(ddlId).append($('<option data-RoleId = "' + item.BATCH_ID + '"/>').val(item.BATCH_ID).text(item.NAME));

            });
            $(ddlId).select2();
            $(ddlId).select2({
                dropdownParent: $("#CreatebatchTImeModal")
            });
        }
    });
}
function LoadTrainerList() {
    var ddlId = '#trainer';
    _model = {
        "TRAINER_ID": 0,
    }
    $.ajax({
        type: "POST",
        url: "MasterSetting/GetTrainerList",
        dataType: 'json',
        async: true,
        data: {
            model: _model
        },
        success: function (response) {

            $(ddlId).empty();

            $(ddlId).append($('<option/>').val('-').text('Select Trainer'));

            $.each(response, function (i, item) {

                $(ddlId).append($('<option data-RoleId = "' + item.TRAINER_ID + '"/>').val(item.TRAINER_ID).text(item.TRAINER_NAME));

            });
            $(ddlId).select2();
            $(ddlId).select2({
                dropdownParent: $("#CreatebatchTImeModal")
            });
        }
    });
}
function Clear() {
    $('#hdnBatchId').val('');
    $('#name').val('');
    $('#description').val('');
}
function LoadBatchTimingCount(BATCH_ID) {
    var IsEdit = document.getElementById("Edit_BatchTiming").innerHTML;
    var IsDelete = document.getElementById("Delete_BatchTiming").innerHTML;
    var IsAdd = document.getElementById("Add_BatchTiming").innerHTML;

    $("#BatchTimingGrid").DataTable().clear();
    $("#BatchTimingGrid").dataTable().fnDestroy();

    var table = $('#BatchTimingGrid').DataTable({
        "proccessing": true,
        "serverSide": true,
        "scrollX": true,
        "scrollY": '50vh',
        scroller: true,

        "ajax": {
            complete: function (data) {
                //  $(".MasterLoader").fadeOut();
            },
            url: "MasterSetting/GetBatchTimingCount",
            "data": function (d) {

                BATCH_ID = (BATCH_ID == null ? "0" : BATCH_ID) || (BATCH_ID == '' ? "0" : BATCH_ID) || (BATCH_ID == undefined ? "0" : BATCH_ID) || (BATCH_ID == "" ? "0" : BATCH_ID) || (BATCH_ID == null ? '-' : BATCH_ID)
            },
            type: 'POST'
        },
        "columns": [
            {
                render: function (data, type, row) {

                    var strAction = '';
                    if (IsEdit == 'true' || IsEdit == 'True') {
                        strAction += '<button id="btnEdit" class="btn btn-success btn-sm rounded-0" data-original-title="Edit"  onclick="EditBatchTimingCount(\'' + encodeURIComponent(row.BATCH_TIMING_ID)
                            + '\',\'' + encodeURIComponent(row.TRAINER_ID)
                            + '\',\'' + encodeURIComponent(row.BATCH_ID)
                            + '\',\'' + encodeURIComponent(row.FROM_DATE)
                            + '\',\'' + encodeURIComponent(row.TO_DATE)
                            + '\',\'' + encodeURIComponent(row.FROM_TIME)
                            + '\',\'' + encodeURIComponent(row.TO_TIME)
                            + '\')"><i class="fa fa-edit"></i></button >';

                        strAction += '<button id="btnDelete" class="btn btn-danger  btn-sm rounded-0" data-original-title="Edit"  onclick="DeleteBatchTimingCount(\'' + encodeURIComponent(row.BATCH_TIMING_ID)
                            + '\')"><i class="fa fa-trash"></i></button >';
                    }

                    return strAction
                },
                width: '100px'
            },
            { "data": "BATCH_NAME", "width": '200px' },
            { "data": "TRAINER_NAME", "width": '200px' },
            { "data": "_NO_OF_BATCH_COUNT", "width": '100px' }
        ],
        //"order": [[1, "asc"]],
    });
}
function LoadBatchTimingDetails(BATCH_ID) {
    var IsEdit = document.getElementById("Edit_BatchTiming").innerHTML;
    var IsDelete = document.getElementById("Delete_BatchTiming").innerHTML;
    var IsAdd = document.getElementById("Add_BatchTiming").innerHTML;
    var model = {

        "BATCH_ID": (BATCH_ID == null ? "0" : BATCH_ID) || (BATCH_ID == '' ? "0" : BATCH_ID) || (BATCH_ID == undefined ? "0" : BATCH_ID) || (BATCH_ID == "" ? "0" : BATCH_ID) || (BATCH_ID == null ? '-' : BATCH_ID)
    };
    $("#BatchTimingDetailsGrid").DataTable().clear();
    $("#BatchTimingDetailsGrid").dataTable().fnDestroy();

    var table = $('#BatchTimingDetailsGrid').DataTable({
        "proccessing": true,
        "serverSide": true,
        "scrollX": true,
        "scrollY": '50vh',
        scroller: true,

        "ajax": {
            complete: function (data) {
                //  $(".MasterLoader").fadeOut();
            },
            url: "MasterSetting/GetBatchTiming",
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
                        strAction += '<button id="btnEdit" class="btn btn-success btn-sm rounded-0" data-original-title="Edit"  onclick="EditBatchTiming(\'' + encodeURIComponent(row.BATCH_TIMING_ID)
                            + '\',\'' + encodeURIComponent(row.TRAINER_ID)
                            + '\',\'' + encodeURIComponent(row.BATCH_ID)
                            + '\',\'' + encodeURIComponent(row.FROM_DATE)
                            + '\',\'' + encodeURIComponent(row.TO_DATE)
                            + '\',\'' + encodeURIComponent(row.FROM_TIME)
                            + '\',\'' + encodeURIComponent(row.TO_TIME)
                            + '\')"><i class="fa fa-edit"></i></button >';

                        strAction += '<button id="btnDelete" class="btn btn-danger  btn-sm rounded-0" data-original-title="Edit"  onclick="DeleteBatchTiming(\'' + encodeURIComponent(row.BATCH_TIMING_ID)
                            + '\')"><i class="fa fa-trash"></i></button >';
                    }

                    return strAction
                },
                width: '100px'
            },
            //{ "data": "BATCH_TIMING_ID", "width": '50px' },
            { "data": "BATCH_NAME", "width": '200px' },
            { "data": "TRAINER_NAME", "width": '200px' },
            { "data": "FROM_DATE", "width": '100px' },
            { "data": "TO_DATE", "width": '100px' },
            { "data": "FROM_TIME", "width": '50px' },
            { "data": "TO_TIME", "width": '50px' }
        ],
        //"order": [[1, "asc"]],
    });
}
function CreateBatchTiming() {
    debugger;
    var trainer = $('#trainer').val();
    var batch = $('#batch').val();
    $('#hdnBatchId').val(batch);
    var startdate = $('#fromDate').val();
    var enddate = $('#toDate').val();
    var fromTime = $('#fromTime').val();
    var toTime = $('#toTime').val();

    if (trainer == '-' || trainer == null || trainer == '' || trainer == undefined || trainer == 'undefined') {
        Toast.fire({
            icon: 'error',
            title: 'Please select trainer'
        });
        $('#trainer').focus();
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
    //if (startdate == null || startdate == '' || startdate == undefined || startdate == 'undefined') {
    //    Toast.fire({
    //        icon: 'error',
    //        title: 'Please select start date'
    //    });
    //    $('#toDate').focus();
    //    return false;
    //}
    //if (enddate == null || enddate == '' || enddate == undefined || enddate == 'undefined') {
    //    Toast.fire({
    //        icon: 'error',
    //        title: 'Please select start date'
    //    });
    //    $('#enddate').focus();
    //    return false;
    //}
    //if (fromTime == null || fromTime == '' || fromTime == undefined || fromTime == 'undefined') {
    //    Toast.fire({
    //        icon: 'error',
    //        title: 'Please select from time'
    //    });
    //    $('#fromTime').focus();
    //    return false;
    //}
    //if (toTime == null || toTime == '' || toTime == undefined || toTime == 'undefined') {
    //    Toast.fire({
    //        icon: 'error',
    //        title: 'Please select to time'
    //    });
    //    $('#toTime').focus();
    //    return false;
    //}

    _model = {
        "BATCH_TIMING_ID": ($('#hdnBatchTimingId').val() == null ? 0 : $('#hdnBatchTimingId').val()) || ($('#hdnBatchTimingId').val() == '' ? 0 : $('#hdnBatchTimingId').val()) || ($('#hdnBatchTimingId').val() == "" ? 0 : $('#hdnBatchTimingId').val()) || ($('#hdnBatchTimingId').val() == undefined ? 0 : $('#hdnBatchTimingId').val()),
        "TRAINER_ID": trainer,
        "BATCH_ID": batch,
        //"FROM_DATE": startdate,
        //"TO_DATE": enddate,
        //"FROM_TIME": fromTime,
        //"TO_TIME": toTime,
        "OPERATION_STATUS": ($('#hdnBatchTimingId').val() === '' ? "ADD" : "UPDATE")
    }

    $.ajax({
        type: 'POST',
        url: 'MasterSetting/CreateBatchTiming',
        data: {
            model: _model
        },
        dataType: 'JSON',
        success: function (result) {
            Toast.fire({
                icon: result.RESPONSETYPE == "0" ? 'error' : 'success',
                title: result.RESPONSEMESSAGE
            });
            //debugger;
            $('#CreatebatchTImeModal').modal('hide');
            $('#CreatebatchTImeModal').hide();
            //LoadBatchTimingDetails();
            LoadBatchTimingCount();
            if (result.RESPONSETYPE == "1") {
                $('#CreatebatchTImeModal').modal('hide');
            }

        },
        error: function (xhr, textStatus, error) {

        }
    });
}
function EditBatchTiming(BATCH_TIMING_ID, TRAINER_ID, BATCH_ID, FROM_DATE, TO_DATE, FROM_TIME, TO_TIME) {
    debugger;
    var BATCH_TIMING_ID = decodeURIComponent(BATCH_TIMING_ID);
    $('#hdnBatchTimingId').val(BATCH_TIMING_ID);
    var TRAINER_ID = decodeURIComponent(TRAINER_ID);
    var BATCH_ID = decodeURIComponent(BATCH_ID);
    $('#hdnBatchId').val(batch);
    var FROM_DATE = decodeURIComponent(FROM_DATE);
    var TO_DATE = decodeURIComponent(TO_DATE);
    var FROM_TIME = decodeURIComponent(FROM_TIME);
    var TO_TIME = decodeURIComponent(TO_TIME);

    $('#trainer').val(TRAINER_ID);
    $('#trainer').change();
    $('#batch').val(BATCH_ID);
    $('#batch').change();
    $('#batch').attr("disabled","disabled");
    $('#fromDate').val(FROM_DATE);
    $('#toDate').val(TO_DATE);
    $('#fromTime').val(FROM_TIME);
    $('#toTime').val(TO_TIME);
    $('#CreatebatchTImeModal').modal('show');
}
function EditBatchTimingCount(BATCH_TIMING_ID, TRAINER_ID, BATCH_ID, FROM_DATE, TO_DATE, FROM_TIME, TO_TIME) {
    debugger;
    var BATCH_TIMING_ID = encodeURIComponent(BATCH_TIMING_ID);
    var TRAINER_ID = encodeURIComponent(TRAINER_ID);
    var BATCH_ID = encodeURIComponent(BATCH_ID);
    $('#hdnBatchTimingId').val(BATCH_TIMING_ID);
    //var FROM_DATE = encodeURIComponent(FROM_DATE);
    //var TO_DATE = encodeURIComponent(TO_DATE);
    //var FROM_TIME = encodeURIComponent(FROM_TIME);
    //var TO_TIME = encodeURIComponent(TO_TIME);

    $('#trainer').val(TRAINER_ID);
    $('#trainer').change();
    $('#batch').val(BATCH_ID);
    $('#batch').change();
    //$('#fromDate').val(FROM_DATE);
    //$('#toDate').val(TO_DATE);
    //$('#fromTime').val(FROM_TIME);
    //$('#toTime').val(TO_TIME);
    //$('#batchModal').modal('show');
    $('#CreatebatchTImeModal').modal('show');
    //LoadBatchTimingDetails(BATCH_ID);
}
function DeleteBatchTiming(BATCH_TIMING_ID) {
    var BATCH_TIMING_ID = decodeURIComponent(BATCH_TIMING_ID);
    Swal.fire({
        title: "Are you sure you want to delete?",
        text: "",
        type: "warning",
        showCancelButton: true, confirmButtonClass: "btn-danger", confirmButtonText: "Yes, reject it!",
        cancelButtonText: "No, cancel it!", closeOnConfirm: false, closeOnCancel: false

    }).then((result) => {

        if (result.value === true) {

            _model = {
                'BATCH_TIMING_ID': BATCH_TIMING_ID
            };

            $.ajax({
                type: 'POST',
                url: 'MasterSetting/DeleteBatchTiming',
                data: {
                    model : _model
                },
                dataType: 'JSON',
                async: true,
                success: function (result) {

                    Toast.fire({
                        icon: result.RESPONSETYPE == "0" ? 'error' : 'success',
                        title: result.RESPONSEMESSAGE
                    });
                    LoadBatchTimingDetails();
                },
                error: function (xhr, textStatus, error) {
                    Toast.fire({
                        icon: 'error',
                        title: "Enabled to delete batch Timing"
                    });
                }
            });
        }
    })
}
function DeleteBatchTimingCount(BATCH_TIMING_ID) {
    var BATCH_TIMING_ID = decodeURIComponent(BATCH_TIMING_ID);
    Swal.fire({
        title: "Are you sure you want to delete?",
        text: "",
        type: "warning",
        showCancelButton: true, confirmButtonClass: "btn-danger", confirmButtonText: "Yes, reject it!",
        cancelButtonText: "No, cancel it!", closeOnConfirm: false, closeOnCancel: false

    }).then((result) => {

        if (result.value === true) {

            _model = {
                'BATCH_TIMING_ID': BATCH_TIMING_ID
            };

            $.ajax({
                type: 'POST',
                url: 'MasterSetting/DeleteBatchTiming',
                data: {
                    model: _model
                },
                dataType: 'JSON',
                async: true,
                success: function (result) {

                    Toast.fire({
                        icon: result.RESPONSETYPE == "0" ? 'error' : 'success',
                        title: result.RESPONSEMESSAGE
                    });
                    LoadBatchTimingDetails();
                },
                error: function (xhr, textStatus, error) {
                    Toast.fire({
                        icon: 'error',
                        title: "Enabled to delete batch Timing"
                    });
                }
            });
        }
    })
}