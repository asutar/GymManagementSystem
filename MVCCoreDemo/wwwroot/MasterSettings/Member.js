var TempData='';
function LoadMemberList() {

    var IsEdit = document.getElementById("Edit_Member").innerHTML;
    var IsDelete = document.getElementById("Delete_Member").innerHTML;
    var IsAdd = document.getElementById("Add_Member").innerHTML;
    //debugger;
    $("#MemberGrid").DataTable().clear();
    $("#MemberGrid").dataTable().fnDestroy();

    var table = $('#MemberGrid').DataTable({
        "proccessing": true,
        "serverSide": true,
        "scrollX": true,
        "scrollY": '50vh',
        scroller: true,

        "ajax": {
            complete: function (data) {
              //  $(".MasterLoader").fadeOut();
            },
            url: "MasterSetting/GetMember",
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
                        strAction += '<button id="btnEdit" class="btn btn-success btn-sm rounded-0" data-original-title="Edit"  onclick="EditMember(\'' + encodeURIComponent(row.MEMBERID)
                            + '\',\'' + encodeURIComponent(row.FIRSTNAME)
                            + '\',\'' + encodeURIComponent(row.LASTNAME)
                            + '\',\'' + encodeURIComponent(row.GENDER_ID)
                            + '\',\'' + encodeURIComponent(row.DATEOFBIRTH)
                            + '\',\'' + encodeURIComponent(row.CONTACTNUMBER)
                            + '\',\'' + encodeURIComponent(row.EMAIL)
                            + '\',\'' + encodeURIComponent(row.ADDRESS)
                            + '\',\'' + encodeURIComponent(row.ADDED_DATE)
                            + '\',\'' + encodeURIComponent(row.IMAGEDATA)
                            + '\')"><i class="fa fa-edit"></i></button >';
                    }

                    return strAction;
                },
            },
            {
                render: function (data, type, row) {
                    //debugger;
                    return (row.IMAGEDATA == null || row.IMAGEDATA == undefined || row.IMAGEDATA == '-') ? '<img style="width:73px;height:80px;" src="/images/images.jpeg" alt="">' : '<img style="width:73px;height:80px;" onclick="OpenImage('+ row.IMAGEDATA +');" src=' + row.IMAGEDATA + ' alt="">'
                   // return '<img src=' + row.IMAGEDATA + ' alt="">';
                }
            },
            { "data": "MEMBERID", "width": '100px' },
            { "data": "FIRSTNAME", "width": '100px' },
            { "data": "LASTNAME", "width": '100px' },
            { "data": "GENDER", "width": '100px' },
            { "data": "DATEOFBIRTH", "width": '100px' },
            { "data": "CONTACTNUMBER", "width": '100px' },
            { "data": "EMAIL", "width": '100px' },
            { "data": "ADDRESS", "width": '100px' },
            { "data": "ADDED_DATE", "width": '100px' },
            {
                render: function (data, type, row) {
                    return (row.IS_ACTIVE == 0 ? '<span class="badge bg-danger">In Active</span>' : '<span class="badge bg-success"> Active</span>')
                }
            }
        ],
        //"order": [[1, "asc"]],
    });
}
function OpenImage(IMAGEDATA) {
    //debugger;
    $('#PhotoViewModal').modal('show');
    $("#ImageShow").attr("src", IMAGEDATA);
}
function OpenCreateMember() {
    Clear();
    $('#MemberRegitrationModel').modal('show');
    SetBackGroundImage();
}
function AddMember() {

    var firstName = $('#firstName').val();
    var lastName = $('#lastName').val();
    var gender = $('#gender').val();
    var birthDate = $('#birthDate').val();
    var contact = $('#contact').val();
    var email = $('#email').val();
    var address = $('#address').val();

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
    //debugger;
    _model = {
        "MEMBERID": ($('#hdnMemberId').val() == null ? 0 : $('#hdnMemberId').val()) || ($('#hdnMemberId').val() == '' ? 0 : $('#hdnMemberId').val()) || ($('#hdnMemberId').val() == "" ? 0 : $('#hdnMemberId').val()) || ($('#hdnMemberId').val() == undefined ? 0 : $('#hdnMemberId').val()),
        "FIRSTNAME": firstName,
        "LASTNAME": lastName,
        "GENDER_ID": gender,
        "DATEOFBIRTH": birthDate,
        "CONTACTNUMBER": contact,
        "EMAIL": email,
        "ADDRESS": address,
        "IMAGEDATA": TempData,
        "OPERATION_STATUS": ($('#hdnMemberId').val() === '' ? "ADD" : "UPDATE"),
            //($('#hdnMemberId').val() == null ? "ADD" : "UPDATE") || ($('#hdnMemberId').val() === '' ? "ADD" : "UPDATE") || ($('#hdnMemberId').val() == "" ? "ADD" : "UPDATE") || ($('#hdnMemberId').val() == undefined ? "ADD" : "UPDATE"),
    }

    $.ajax({
        type: 'POST',
        url: 'MasterSetting/CreateMember',
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
            LoadMemberList();
            if (result.RESPONSETYPE == "1") {
                $('#MemberRegitrationModel').modal('hide');
            }
            TempData = '';
        },
        error: function (xhr, textStatus, error) {

        }
    });
}
function EditMember(MEMBERID, FIRSTNAME, LASTNAME, GENDER_ID, DATEOFBIRTH, CONTACTNUMBER, EMAIL, ADDRESS, ADDED_DATE, IMAGEDATA) {
    //debugger;
    Clear();
    $('#MemberRegitrationModel').modal('show');
    $('#hdnMemberId').val(decodeURIComponent(MEMBERID));
    $('#firstName').val(decodeURIComponent(FIRSTNAME));
    $('#lastName').val(decodeURIComponent(LASTNAME));
    $('#gender').val(decodeURIComponent(GENDER_ID));
    $("#birthDate").val(decodeURIComponent(DATEOFBIRTH));
    $('#contact').val(decodeURIComponent(CONTACTNUMBER));
    $('#email').val(decodeURIComponent(EMAIL));
    $('#address').val(decodeURIComponent(ADDRESS));
    document.getElementById('finalresults').innerHTML = '<img  style="width:164px;height:186px;" src="' + decodeURIComponent(IMAGEDATA) + '"/>';
    TempData = decodeURIComponent(IMAGEDATA);
}
function Clear() {
    $('#hdnMemberId').val('');
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
        // Send image data to the controller to store locally or in database
        //Webcam.upload(data,
        //    '/WebCam/CaptureImage',
        //    function (code, text) {
        //        alert('Snapshot/Image captured successfully...');
        //    })
    });
    Webcam.reset();
}
function Reset() {
    //debugger;
    $("#results").empty();
    Webcam.set({
        width: 300,
        height: 320,
        image_format: 'png',
        jpeg_quality: 100
    });
    Webcam.attach('#LiveCamera');

}

function DisplayTempImage()
{
    //debugger;
    document.getElementById('finalresults').innerHTML = '<img style="width:164px;height:186px;" src="' + TempData + '"/>';
    $('#CaptureImageModel').modal('hide');
    Webcam.reset();
}

function UploadImage() {
   
  
    _model = {
        "IMAGEDATA": TempData,
        "OPERATION_STATUS": ($('#hdnMemberId').val() === '' ? "ADD" : "UPDATE"),
    }

    $.ajax({
        type: 'POST',
        url: 'MasterSetting/CaptureImage',
        data: {
            model: _model
        },
        dataType: 'JSON',
        success: function (result) {

            Toast.fire({
                icon: result.RESPONSETYPE == "0" ? 'error' : 'success',
                title: result.RESPONSEMESSAGE
            });
            TempData = '';
        },
        error: function (xhr, textStatus, error) {

        }
    });

}