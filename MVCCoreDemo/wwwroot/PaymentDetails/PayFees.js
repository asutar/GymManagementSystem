function LoadMemberList() {
    //debugger;
    var ddlId = '#member';
    _model = {
        "MEMBERID": 0,
    }
    $.ajax({
        type: "POST",
        url: "../MasterSettings/MasterSetting/GetMemberList",
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
            //$(ddlId).select2({
            //    dropdownParent: $("#MemberRegitrationModel")
            //});
        }
    });
}
function GetPendingFeesAmount() {
    //Clear();
    _model = {
        "MEMBER_ID": $('#member').val(),
        "BATCH_ID": $('#batch').val(),
    }
    $.ajax({
        type: "POST",
        url: "Payment/GetPendingAmount",
        dataType: 'json',
        data: {
            model: _model
        },
        success: function (response) {
            //debugger;
            $('#pendingAmount').val(response.PENDING_AMOUNT);
        }
    });
}

function AmountPandingAmount()
{
    debugger

    var amount = parseFloat($("#amount").val());
    var pendingAmount = parseFloat($("#pendingAmount").val());

    if (pendingAmount != 0) {
        if (pendingAmount < amount) {
            Toast.fire({
                icon: 'error',
                title: 'Amount cannot be greater than Pending Total Amount.'
            });
            $("#amount").val(0);
            $("#amount").focus();
        }
    }
}
function Clear() {
    $('#amount').val('');
}
function Pay() {

    var Member = $('#member').val();
    var PendingAmount = $('#pendingAmount').val();
    var Amount = $('#amount').val();
    var PaymentMethod = $('#paymentMethod').val();
    var batch = $('#batch').val();

    if (Member == '-' || Member == null || Member == '' || Member == undefined || Member == 'undefined') {
        Toast.fire({
            icon: 'error',
            title: 'Please select Member'
        });
        $('#member').focus();
        return false;
    }
    if (Amount == '-' || Amount == null || Amount == '' || Amount == undefined || Amount == 'undefined' || Amount == '0' || Amount == 0) {
        Toast.fire({
            icon: 'error',
            title: 'Please enter Amount'
        });
        $('#amount').focus();
        return false;
    }
    if (PaymentMethod == '-' || PaymentMethod == null || PaymentMethod == '' || PaymentMethod == undefined || PaymentMethod == 'undefined') {
        Toast.fire({
            icon: 'error',
            title: 'Please select Payment Method'
        });
        $('#amount').focus();
        return false;
    }

    Swal.fire({
        title: "Are you sure you want to Process Payment?",
        text: "",
        type: "warning",
        showCancelButton: true, confirmButtonClass: "btn-danger", confirmButtonText: "Yes, approve it!",
        cancelButtonText: "No, cancel it!", closeOnConfirm: false, closeOnCancel: false

    }).then((result) => {

        if (result.value === true) {
            
            _model = {
                "MEMBER_ID": Member,
                "PAID_AMOUNT": Amount,
                "PAYMENT_ID": PaymentMethod,
                "TOTAL_AMOUNT": PendingAmount,
                "BATCH_ID": batch
            }
            $.ajax({
                type: 'POST',
                url: 'Payment/PayFees',
                data: {
                    model: _model
                },
                dataType: 'JSON',
                success: function (result) {
                    Toast.fire({
                        icon: result.RESPONSETYPE == "0" ? 'error' : 'success',
                        title: result.RESPONSEMESSAGE
                    });
                    //LoadPackage();
                    if (result.RESPONSETYPE == "1") {
                        $('#PackageModel').modal('hide');
                    }

                },
                error: function (xhr, textStatus, error) {

                }
            });
          
        }
        else {
            Swal.fire("Cancelled", "Your record is safe.", "error");
        }

    })
   
}
function LoadPayTypeList() {
    //debugger;
    var ddlId = '#paymentMethod';
    _model = {
        "PAYMENT_ID": 0,
    }
    $.ajax({
        type: "POST",
        url: "Payment/GetPaymentTypeList",
        dataType: 'json',
        data: {
            model: _model
        },
        success: function (response) {

            $(ddlId).empty();

            $(ddlId).append($('<option/>').val('-').text('Select Pay Type'));

            $.each(response, function (i, item) {

                $(ddlId).append($('<option data-RoleId = "' + item.PAYMENT_ID + '"/>').val(item.PAYMENT_ID).text(item.TYPE_NAME));

            });
            $(ddlId).select2();
        }
    });
}
function LoadBatchList() {
    var ddlId = '#batch';
    _model = {
        "MEMBERID": $('#member').val(),
    }
    $.ajax({
        type: "POST",
        url: "Payment/GetBatchByMember",
        dataType: 'json',
        async: true,
        data: {
            model: _model
        },
        success: function (response) {

            $(ddlId).empty();

            $(ddlId).append($('<option/>').val('-').text('Select Batch'));

            $.each(response, function (i, item) {

                $(ddlId).append($('<option data-RoleId = "' + item.BATCH_ID + '"/>').val(item.BATCH_ID).text(item.BATCH_NAME));
            });
            $(ddlId).select2();
        }
    });
}