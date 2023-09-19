function LoadPayFeesDetails() {

    var IsEdit = document.getElementById("Edit_PayFeesDetails").innerHTML;
    var IsDelete = document.getElementById("Delete_PayFeesDetails").innerHTML;
    var IsAdd = document.getElementById("Add_PayFeesDetails").innerHTML;

    $("#PayfessDetails").DataTable().clear();
    $("#PayfessDetails").dataTable().fnDestroy();

    var table = $('#PayfessDetails').DataTable({
        "proccessing": true,
        "serverSide": true,
        "scrollX": true,
        "scrollY": '50vh',
        scroller: true,

        "ajax": {
            complete: function (data) {
                //  $(".MasterLoader").fadeOut();
            },
            url: "Payment/GetPayFeesDetailsHistory",
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
                        strAction += '<button id="btnEdit" class="btn btn-success btn-sm rounded-0" data-original-title="Edit"  onclick="OpenBillingPopup(\'' + encodeURIComponent(row.TRASACTION_NO)
                            + '\',\'' + encodeURIComponent(row.TRANSATION_DATETIME)
                            + '\',\'' + encodeURIComponent(row.MEMBER_NAME)
                            + '\',\'' + encodeURIComponent(row.PAID_AMOUNT)
                            + '\',\'' + encodeURIComponent(row.PENDING_AMOUNT)
                            + '\',\'' + encodeURIComponent(row.TOTAL_AMOUNT)
                            + '\',\'' + encodeURIComponent(row.TYPE_NAME)
                            + '\')"><i class="fa fa-file" aria-hidden="true"></i></button>';
                    }

                    return strAction;
                },
            },
            { "data": "TRASACTION_NO", "width": '100px' },
            { "data": "TRANSATION_DATETIME", "width": '100px' },
            { "data": "MEMBER_NAME", "width": '200px' },
            { "data": "PAID_AMOUNT", "width": '50px' },
            { "data": "PENDING_AMOUNT", "width": '50px' },
            { "data": "TOTAL_AMOUNT", "width": '50px' },
            { "data": "TYPE_NAME", "width": '50px' }
        ],
        //"order": [[1, "asc"]],
    });
}

function OpenBillingPopup(TRASACTION_NO, TRANSATION_DATETIME, MEMBER_NAME, PAID_AMOUNT, PENDING_AMOUNT, TOTAL_AMOUNT, TYPE_NAME)
{
    $('#PdfPopup').modal('show');
    $('#span_MemberName').text(decodeURIComponent(MEMBER_NAME));
    $('#span_TransactionNumber').text(decodeURIComponent(TRASACTION_NO));
    $('#span_TransactionDate').text(decodeURIComponent(TRANSATION_DATETIME));
    $('#span_TotalAmount').text(decodeURIComponent(TOTAL_AMOUNT));
    $('#span_PaidAmount').text(decodeURIComponent(PAID_AMOUNT));
    $('#span_PendingAmount').text(decodeURIComponent(PENDING_AMOUNT));
}