var TempData = '';
function LoadUserList() {
    //debugger;
    //var IsEdit = document.getElementById("Edit_CreateUser").innerHTML;
    //var IsDelete = document.getElementById("Delete_CreateUser").innerHTML;
    //var IsAdd = document.getElementById("Add_CreateUser").innerHTML;
   
    $("#CreateUserGrid").DataTable().clear();
    $("#CreateUserGrid").dataTable().fnDestroy();

    var table = $('#CreateUserGrid').DataTable({
        "proccessing": true,
        "serverSide": true,
        "scrollX": true,
        "scrollY": '50vh',
        scroller: true,

        "ajax": {
            complete: function (data) {
                //  $(".MasterLoader").fadeOut();
            },
            url: "UserOperationAccess/GetSubClinet",
            "data": function (d) {

                DRIVER_ID = "0"
            },
            type: 'POST'
        },
        "columns": [
            {
                render: function (data, type, row) {

                    var strAction = '';
                    //if (IsEdit == 'true' || IsEdit == 'True') {
                        strAction += '<button id="btnEdit" class="btn btn-success btn-sm rounded-0" data-original-title="Edit"  onclick="EditUser(\'' + encodeURIComponent(row.USER_ID)
                            + '\',\'' + encodeURIComponent(row.USER_NAME)
                            + '\',\'' + encodeURIComponent(row.FIRST_NAME)
                            + '\',\'' + encodeURIComponent(row.MIDDLE_NAME)
                            + '\',\'' + encodeURIComponent(row.LAST_NAME)
                            + '\',\'' + encodeURIComponent(row.SEX_ID)
                            + '\',\'' + encodeURIComponent(row.BIRTH_DATE)
                            + '\',\'' + encodeURIComponent(row.MOBILE_NO)
                            + '\',\'' + encodeURIComponent(row.EMAIL_ID)
                            + '\',\'' + encodeURIComponent(row.ADDRESS)
                            + '\',\'' + encodeURIComponent(row.ADDED_BY_DATETIME)
                            + '\',\'' + encodeURIComponent(row.PASSWORD)
                            + '\',\'' + encodeURIComponent(row.ROLE_ID)
                            + '\',\'' + encodeURIComponent(row.IMAGEDATA)
                            + '\')"><i class="fa fa-edit"></i></button >';
                    //}

                    return strAction;
                },
            },
            { "data": "USER_NAME", "width": '100px' },
            { "data": "FIRST_NAME", "width": '100px' },
            { "data": "MIDDLE_NAME", "width": '100px' },
            { "data": "LAST_NAME", "width": '100px' },
            { "data": "GENDER", "width": '100px' },
            { "data": "BIRTH_DATE", "width": '100px' },
            { "data": "MOBILE_NO", "width": '100px' },
            { "data": "EMAIL_ID", "width": '100px' },
            { "data": "ADDRESS", "width": '100px' },
            { "data": "ADDED_BY_DATETIME", "width": '100px' },
            {
                render: function (data, type, row) {
                    return (row.IS_ACTIVE == 0 ? '<span class="badge bg-danger">In Active</span>' : '<span class="badge bg-success"> Active</span>')
                }
            }
        ],
        //"order": [[1, "asc"]],
    });
}
function AddUser() {

    var firstName = $('#firstName').val();
    var lastName = $('#lastName').val();
    var middleName = $('#middleName').val();
    var gender = $('#gender').val();
    var birthDate = $('#birthDate').val();
    var contact = $('#contact').val();
    var email = $('#email').val();
    var address = $('#address').val();
    var UserName = $('#UserName').val();
    var Password = $('#Password').val();
    var UserRole = $('#ddlUserRole').val();

    if (firstName == null || firstName == '' || firstName == undefined || firstName == 'undefined') {
        Toast.fire({
            icon: 'error',
            title: 'Please enter First Name'
        });
        $('#firstName').focus();
        return false;
    }
    if (middleName == null || middleName == '' || middleName == undefined || middleName == 'undefined') {
        Toast.fire({
            icon: 'error',
            title: 'Please enter Middle Name'
        });
        $('#middleName').focus();
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
    if (UserName == null || UserName == '' || UserName == undefined || UserName == 'undefined') {
        Toast.fire({
            icon: 'error',
            title: 'Please enter User Name'
        });
        $('#UserName').focus();
        return false;
    }
    if (Password == null || Password == '' || Password == undefined || Password == 'undefined') {
        Toast.fire({
            icon: 'error',
            title: 'Please enter Password'
        });
        $('#Password').focus();
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
    debugger;
    _model = {
        "USER_ID": ($('#hdnMemberId').val() == null ? 0 : $('#hdnMemberId').val()) || ($('#hdnMemberId').val() == '' ? 0 : $('#hdnMemberId').val()) || ($('#hdnMemberId').val() == "" ? 0 : $('#hdnMemberId').val()) || ($('#hdnMemberId').val() == undefined ? 0 : $('#hdnMemberId').val()),
        "FIRST_NAME": firstName,
        "MIDDLE_NAME": middleName,
        "LAST_NAME": lastName,
        "USER_NAME": UserName,
        "PASSWORD": Password,
        "SEX_ID": gender,
        "BIRTH_DATE": birthDate,
        "MOBILE_NO": contact,
        "EMAIL_ID": email,
        "ADDRESS": address,
        "IMAGEDATA": TempData,
        "ROLE_ID": UserRole,
        "OPERATION_STATUS": ($('#hdnMemberId').val() === '' ? "ADD" : "UPDATE"),
    }

    $.ajax({
        type: 'POST',
        url: 'UserOperationAccess/CreateSubClient',
        data: {
            model: _model
        },
        dataType: 'JSON',
        success: function (result) {

            Toast.fire({
                icon: result.RESPONSETYPE == "0" ? 'error' : 'success',
                title: result.RESPONSEMESSAGE
            });
            LoadUserList();
            if (result.RESPONSETYPE == "1") {
                $('#CreateUserModel').modal('hide');
            }
            TempData = '';
        },
        error: function (xhr, textStatus, error) {

        }
    });
}
function OpenCreateUser() {
    Clear();
    $('#CreateUserModel').modal('show');
    SetBackGroundImage();
}
function EditUser(USER_ID, USER_NAME, FIRST_NAME, MIDDLE_NAME, LAST_NAME, SEX_ID, BIRTH_DATE, MOBILE_NO, EMAIL_ID, ADDRESS, ADDED_BY_DATETIME, PASSWORD, ROLE_ID, IMAGEDATA) {
    debugger;
    //Clear();
    $('#CreateUserModel').modal('show');
    $('#hdnMemberId').val(decodeURIComponent(USER_ID));
    $('#firstName').val(decodeURIComponent(FIRST_NAME));
    $('#middleName').val(decodeURIComponent(MIDDLE_NAME));
    $('#lastName').val(decodeURIComponent(LAST_NAME));
    $('#UserName').val(decodeURIComponent(USER_NAME));
    $('#Password').val(decodeURIComponent(PASSWORD));
    $('#gender').val(decodeURIComponent(SEX_ID));
    $("#birthDate").val(decodeURIComponent(BIRTH_DATE));
    $('#contact').val(decodeURIComponent(MOBILE_NO));
    $('#email').val(decodeURIComponent(EMAIL_ID));
    $('#address').val(decodeURIComponent(ADDRESS));
    $('#ddlUserRole').val(decodeURIComponent(ROLE_ID));
    $('#ddlUserRole').change();
    document.getElementById('finalresults').innerHTML = '<img  style="width:164px;height:186px;" src="' + decodeURIComponent(IMAGEDATA) + '"/>';
    TempData = decodeURIComponent(IMAGEDATA);
}
function OpenCaptureSnapModal() {
    $('#CaptureImageModel').modal('show');
    Webcam.set({
        width: 300,
        height: 320,
        image_format: 'png',
        jpeg_quality: 100
    });
    Webcam.attach('#LiveCamera');
}
function CaptureSnapshot() {
    Webcam.snap(function (data) {
        // display results in page
        TempData = data;
        document.getElementById('results').innerHTML = '<img style=width:300px,height:320;"" src="' + data + '"/>';
    });
    Webcam.reset();
}
function Reset() {
    debugger;
    $("#results").empty();
    Webcam.set({
        width: 300,
        height: 320,
        image_format: 'png',
        jpeg_quality: 100
    });
    Webcam.attach('#LiveCamera');

}

function DisplayTempImage() {
    debugger;
    document.getElementById('finalresults').innerHTML = '<img style="width:164px;height:186px;" src="' + TempData + '"/>';
    $('#CaptureImageModel').modal('hide');
    Webcam.reset();
}
function ValidateEmail(emailInput) {

    var emailPattern = /^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$/;

    if (emailPattern.test(emailInput)) {
        return true;
    } else {
        return false;
    }
}

function GetUserRoles() {
    var token = $("[name='__RequestVerificationToken']").val();

    var mod = {
        RoleId: '0',
        RoleName: '',
        RoleDescription: '',
        IsInUse: '',
        LastUpdateBy: '',
        LastUpdateTime: '',
        UserID: ''
    };

    $.ajax({
        url: "UserOperationAccess/GetRole",
        type: "POST",
        dataType: "JSON",
        data: {
            __RequestVerificationToken: token,
            _rolemodel: mod
        },
        success: function (response) {
            $('#ddlUserRole').empty();
            $('#ddlUserRole').append($('<option/>').val(0).text('Select User Role'));
            $.each(response, function (i, item) {
                $('#ddlUserRole').append($('<option/>').val(item.roleId).text(item.roleName));
            });
            $('#ddlUserRole').select2();
        }
    });
};

function Clear() {
    $('#finalresults').val('');
    $('#firstName').val('');
    $('#middleName').val('');
    $('#lastName').val('');
    $('#UserName').val('');
    $('#Password').val('');
    $('#gender').val(1);
    $('#birthDate').val('');
    $('#contact').val('');
    $('#email').val('');
    $('#ddlUserRole').change('');
    $('#address').val('');
    $('#hdnMemberId').val('');
}