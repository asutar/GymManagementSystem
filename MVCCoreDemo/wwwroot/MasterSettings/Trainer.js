
function LoadTrainerList() {

    var IsEdit = document.getElementById("Edit_Trainer").innerHTML;
    var IsDelete = document.getElementById("Delete_Trainer").innerHTML;
    var IsAdd = document.getElementById("Add_Trainer").innerHTML;

    $("#TrainerGrid").DataTable().clear();
    $("#TrainerGrid").dataTable().fnDestroy();

    var table = $('#TrainerGrid').DataTable({
        "proccessing": true,
        "serverSide": true,
        "scrollX": true,
        "scrollY": '50vh',
        scroller: true,

        "ajax": {
            complete: function (data) {
                //  $(".MasterLoader").fadeOut();
            },
            url: "MasterSetting/GetTrainer",
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
                        strAction += '<button id="btnEdit" class="btn btn-success btn-sm rounded-0" data-original-title="Edit"  onclick="EditTrainer(\'' + encodeURIComponent(row.TRAINER_ID)
                            + '\',\'' + encodeURIComponent(row.FIRSTNAME)
                            + '\',\'' + encodeURIComponent(row.LASTNAME)
                            + '\',\'' + encodeURIComponent(row.GENDER_ID)
                            + '\',\'' + encodeURIComponent(row.DATEOFBIRTH)
                            + '\',\'' + encodeURIComponent(row.CONTACTNUMBER)
                            + '\',\'' + encodeURIComponent(row.EMAIL)
                            + '\',\'' + encodeURIComponent(row.ADDRESS)
                            + '\',\'' + encodeURIComponent(row.ADDED_DATE)
                            + '\',\'' + encodeURIComponent(row.SPECIALIZATION_ID)
                            + '\')"><i class="fa fa-edit"></i></button >';
                    }

                    return strAction;
                },
            },
            {
                render: function (data, type, row) {
                    //debugger;
                    return (row.IMAGEDATA == null || row.IMAGEDATA == undefined || row.IMAGEDATA == '-') ? '<img style="width:73px;height:80px;" src="/images/images.jpeg" alt="">' : '<img style="width:73px;height:80px;" src=' + row.IMAGEDATA + ' alt="">'
                }
            },
            { "data": "TRAINER_ID", "width": '100px' },
            { "data": "FIRSTNAME", "width": '100px' },
            { "data": "LASTNAME", "width": '100px' },
            { "data": "GENDER_NAME", "width": '100px' },
            { "data": "DATEOFBIRTH", "width": '100px' },
            { "data": "CONTACTNUMBER", "width": '100px' },
            { "data": "EMAIL", "width": '100px' },
            { "data": "ADDRESS", "width": '100px' },
            { "data": "ADDED_DATE", "width": '100px' }
        ],
        //"order": [[1, "asc"]],
    });
}
function OpenCreateTrainer() {
    Clear();
    $('#TrainerModel').modal('show');
}
function AddTrainer() {

    var firstName = $('#firstName').val();
    var lastName = $('#lastName').val();
    var gender = $('#gender').val();
    var birthDate = $('#birthDate').val();
    var contact = $('#contact').val();
    var email = $('#email').val();
    var address = $('#address').val();
    var specialization = $('#specialization').val();

    if (firstName == null || firstName == '' || firstName == undefined || firstName == 'undefined') {
        Toast.fire({
            icon: 'error',
            title: 'Please enter First Name'
        });
        $('#firstName').focus();
        return false;
    }
    if (lastName == null || lastName == '' || lastName == undefined || lastName == 'undefined') {
        Toast.fire({
            icon: 'error',
            title: 'Please enter Last Name'
        });
        $('#lastName').focus();
        return false;
    }
    if (gender == null || gender == '' || gender == undefined || gender == 'undefined') {
        Toast.fire({
            icon: 'error',
            title: 'Please select Gender'
        });
        $('#gender').focus();
        return false;
    }
    if (birthDate == null || birthDate == '' || birthDate == undefined || birthDate == 'undefined') {
        Toast.fire({
            icon: 'error',
            title: 'Please select Birth Date'
        });
        $('#birthDate').focus();
        return false;
    }
    if (contact == null || contact == '' || contact == undefined || contact == 'undefined') {
        Toast.fire({
            icon: 'error',
            title: 'Please enter Contact'
        });
        $('#contact').focus();
        return false;
    }
    if (specialization == null || specialization == '' || specialization == undefined || specialization == 'undefined') {
        Toast.fire({
            icon: 'error',
            title: 'Please select specialization'
        });
        $('#specialization').focus();
        return false;
    }
    if (email == null || email == '' || email == undefined || email == 'undefined') {
        Toast.fire({
            icon: 'error',
            title: 'Please enter email'
        });
        $('#email').focus();
        return false;
    } else {

        if (ValidateEmail(email)) {

        } else {
            Toast.fire({
                icon: 'error',
                title: 'Please enter correct email'
            });
            $('#email').focus();
            return false;
        }
    }

    if (address == null || address == '' || address == undefined || address == 'undefined') {
        Toast.fire({
            icon: 'error',
            title: 'Please enter address'
        });
        $('#address').focus();
        return false;
    }

    _model = {
        "TRAINER_ID": ($('#hdnTrainerId').val() == null ? 0 : $('#hdnTrainerId').val()) || ($('#hdnTrainerId').val() == '' ? 0 : $('#hdnTrainerId').val()) || ($('#hdnTrainerId').val() == "" ? 0 : $('#hdnTrainerId').val()) || ($('#hdnTrainerId').val() == undefined ? 0 : $('#hdnTrainerId').val()),
        "FIRSTNAME": firstName,
        "LASTNAME": lastName,
        "GENDER_ID": gender,
        "DATEOFBIRTH": birthDate,
        "CONTACTNUMBER": contact,
        "EMAIL": email,
        "ADDRESS": address,
        "SPECIALIZATION_ID": specialization,
        "OPERATION_STATUS": ($('#hdnTrainerId').val() === '' ? "ADD" : "UPDATE"),
    }

    $.ajax({
        type: 'POST',
        url: 'MasterSetting/CreateTrainer',
        data: {
            model: _model
        },
        dataType: 'JSON',
        success: function (result) {
            //if (result.RESPONSEMESSAGE) {

            Toast.fire({
                icon: result.RESPONSETYPE == "0" ? 'error' : 'success',
                title: result.RESPONSEMESSAGE
            });
            LoadTrainerList();
            if (result.RESPONSETYPE == "1") {
                $('#TrainerModel').modal('hide');
            }

        },
        error: function (xhr, textStatus, error) {

        }
    });
}
function EditTrainer(MEMBERID, FIRSTNAME, LASTNAME, GENDER_ID, DATEOFBIRTH, CONTACTNUMBER, EMAIL, ADDRESS, ADDED_DATE, SPECIALIZATION_ID) {
    debugger;
    Clear();
    $('#TrainerModel').modal('show');
    $('#hdnTrainerId').val(decodeURIComponent(MEMBERID));
    $('#firstName').val(decodeURIComponent(FIRSTNAME));
    $('#lastName').val(decodeURIComponent(LASTNAME));
    $('#gender').val(decodeURIComponent(GENDER_ID));
    var date = decodeURIComponent(DATEOFBIRTH);
    $("#birthDate").val(decodeURIComponent(DATEOFBIRTH));
    $('#contact').val(decodeURIComponent(CONTACTNUMBER));
    $('#email').val(decodeURIComponent(EMAIL));
    $('#address').val(decodeURIComponent(ADDRESS));
    $('#specialization').val(decodeURIComponent(SPECIALIZATION_ID));
    $('#specialization').change();
}
function Clear() {
    $('#hdnTrainerId').val('');
    $('#firstName').val('');
    $('#lastName').val('');
    $('#gender').val('');
    $('#birthDate').val('');
    $('#contact').val('');
    $('#email').val('');
    $('#address').val('');
}
function ValidateEmail(emailInput) {

    var emailPattern = /^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$/;

    if (emailPattern.test(emailInput)) {
        return true;
    } else {
        return false;
    }
}
function LoadSpecilisationList() {
    var ddlId = '#specialization';
    _model = {
        "SPECIALIZATION_ID": 0,
    }
    $.ajax({
        type: "POST",
        url: "MasterSetting/GetSpecilisationList",
        dataType: 'json',
        async: true,
        data: {
            model: _model
        },
        success: function (response) {

            $(ddlId).empty();

            $(ddlId).append($('<option/>').val('-').text('Select Specialization'));

            $.each(response, function (i, item) {

                $(ddlId).append($('<option data-RoleId = "' + item.SPECIALIZATION_ID + '"/>').val(item.SPECIALIZATION_ID).text(item.NAME));

            });
            $(ddlId).select2();
            $(ddlId).select2({
                dropdownParent: $("#TrainerModel")
            });
        }
    });
}