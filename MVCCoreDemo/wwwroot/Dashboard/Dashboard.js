
function GetAllCount() {
    var ddlId = '#batch';
    _model = {
        "ID": 0,
    }
    $.ajax({
        type: "POST",
        url: "Dashboard/GetAllCount",
        dataType: 'json',
        async: true,
        data: {
            model: _model
        },
        success: function (response) {
            $('#divEnquery').html(response.DAILY_ENQUIRY);
            $('#divTodayRegisterMember').html(response.TODAY_REGISTERED_MEMBER);
            $('#spanMembers').html(response.REGISTERED_MEMBER);
            $('#divBirthday').html(response.TODAYS_BIRTHDAY);
            $('#spanTodayCollection').html(response.TODAY_FEES_COLLECTION);
            $('#_PresentMember').html(response.PRESENT_MEMBER);
            $('#divTrainers').html(response.TOTAL_TRAINERS);
            $('#divPlans').html(response.TOTAL_PACKAGE);
            $('#divBatch').html(response.TOTAL_BATCHES);
            $('#spanUnpaid').html(response.FEES_UNPAID);
        }
    });
}
function RenderCharts()
{

    _model = {
        "YEAR": 0,
    }
    $.ajax({
        type: "POST",
        url: "Dashboard/GetYearlyMonthyFeesDetailsChart",
        dataType: 'json',
        // async: true,
        data: {
            model: _model
        },
        success: function (response) {
            var colorDanger = "#FF1744";
            Morris.Donut({
                element: 'piechart',
                resize: true,
                colors: [
                    '#E0F7FA',
                    '#B2EBF2',
                    '#80DEEA',
                    '#4DD0E1',
                    '#26C6DA',
                    '#00BCD4',
                    '#00ACC1',
                    '#0097A7',
                    '#00838F',
                    '#006064'
                ],
                //labelColor:"#cccccc", // text color
                //backgroundColor: '#333333', // border color
                data: [
                    { label: "January", value: response.January, color: colorDanger },
                    { label: "February", value: response.February },
                    { label: "March", value: response.March },
                    { label: "April", value: response.April },
                    { label: "May", value: response.May },
                    { label: "June", value: response.June },
                    { label: "July", value: response.July },
                    { label: "August", value: response.August },
                    { label: "September", value: response.September },
                    { label: "October", value: response.October },
                    { label: "November", value: response.November },
                    { label: "December", value: response.December },
                ]
            });

        }
    });




    _model = {
        "YEAR": 0,
    }
    $.ajax({
        type: "POST",
        url: "Dashboard/GetYearlyMonthyAdmissionDetailsChart",
        dataType: 'json',
        // async: true,
        data: {
            model: _model
        },
        success: function (response) {
            var data = [
                {
                    month: "January",
                    count: response.January
                },
                { month: "February", count: response.February },
                { month: "March", count: response.March },
                { month: "April", count: response.April },
                { month: "May", count: response.May },
                { month: "June", count: response.June },
                { month: "July", count: response.July },
                { month: "August", count: response.August },
                { month: "September", count: response.September },
                { month: "October", count: response.October },
                { month: "November", count: response.November },
                { month: "December", count: response.December },
                // Add more months and counts as needed
            ];

            // Initialize the Morris.js bar chart
            new Morris.Bar({
                element: 'bar-chart', // ID of the HTML element where the chart will be rendered
                data: data,
                xkey: 'month', // Data property for the X-axis (month)
                ykeys: ['count'], // Data property for the Y-axis (count)
                labels: ['Member Admissions Count'], // Label for the Y-axis
                xLabelAngle: 45, // Rotate X-axis labels for better readability (optional)
                barColors: ['#3498db'], // Bar color
                resize: true // Enable chart resizing (optional)
            });
        }
    });


}
function BatchCountPopup() {
   
    $('#BatchCountPopup').modal('show');
    LoadBatchList();
}
function PlanCountPopup() {

    $('#PlanCountPopup').modal('show');
    LoadPackage();
}
function BirthdayPopup() {

    $('#BirthdayPopup').modal('show');
    LoadBirthday();
}
function TrainersPopup() {

    $('#TrainersPopup').modal('show');
    LoadTrainerList();
}
function TodayMemberPopup() {
    //debugger;
    $('#TodayMemberPopup').modal('show');
    LoadMemberList();
}
function TotalMemberPopup() {
    $('#TotalMemberPopup').modal('show');
    LoadTotalMemberList();
}
function UnPaidMemberPopup() {
    $('#UnPaidMemberPopup').modal('show');
    LoadUnPaidMemberList();
}
function TodayCollectionPopup() {
    $('#TodayCollectionPopup').modal('show');
    LoadPayFeesDetails();
}
function InActiveMemberPopup() {
    $('#InActiveMemberPopup').modal('show');
    LoadInActiveMemberList();
}
function LoadBatchList() {
    var webUrl = $('#WebUrl').val();
    webUrl = webUrl.replace(/"/g, '');

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
            url: "../MasterSettings/MasterSetting/GetBatch",
            "data": function (d) {

                DRIVER_ID = "0"
            },
            "language": {
                'processing': '<i class="fa fa-spinner fa-spin fa-3x fa-fw"></i><span class="sr-only">Loading...</span>'
            },
            type: 'POST'
        },
        "columns": [
            { "data": "BATCH_ID", "width": '100px' },
            { "data": "NAME", "width": '200px' },
            { "data": "DESCRIPTION", "width": '200px' },
            { "data": "FROM_DATE", "width": '200px' },
            { "data": "TO_DATE", "width": '200px' },
            { "data": "AMOUNT", "width": '200px' },
            { "data": "TAX_NAME", "width": '200px' },
            { "data": "GST_AMOUNT", "width": '200px' },
            { "data": "TOTAL_AMOUNT", "width": '200px' },
            { "data": "NO_OF_DAYS", "width": '200px' },
        ],
        //"order": [[1, "asc"]],
    });
}
function LoadPackage(PACKAGE_ID) {
    

    var model = {

        "PACKAGE_ID": "0"
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
            url: "../MasterSettings/MasterSetting/GetPackage",
            "language": {
                'processing': '<i class="fa fa-spinner fa-spin fa-3x fa-fw"></i><span class="sr-only">Loading...</span>'
            },
            data: {
                _model: model
            },
            type: 'POST'
        },
        "columns": [
            { "data": "PACKAGE_ID", "width": '200px' },
            { "data": "TITLE", "width": '200px' },
            { "data": "DESCRIPTION", "width": '100px' },
            { "data": "FEES", "width": '100px' },
            { "data": "TAX_NAME", "width": '50px' },
            { "data": "TOTAL_FEES", "width": '50px' }
        ],
    });
}
function LoadBirthday() {
    
    $("#BirthdayGrid").DataTable().clear();
    $("#BirthdayGrid").dataTable().fnDestroy();

    var table = $('#BirthdayGrid').DataTable({
        "proccessing": true,
        "serverSide": true,
        //"scrollX": true,
        //"scrollY": '50vh',
        //scroller: true,

        "ajax": {
            complete: function (data) {
                //  $(".MasterLoader").fadeOut();
            },
            url: "../Dashboard/Dashboard/GetBirthday",
            "data": function (d) {

                DRIVER_ID = "0"
            },
            "language": {
                'processing': '<i class="fa fa-spinner fa-spin fa-3x fa-fw"></i><span class="sr-only">Loading...</span>'
            },
            type: 'POST'
        },
        "columns": [
            { "data": "NAME", "width": '100px' },
            { "data": "GENDER", "width": '200px' },
            { "data": "DATEOFBIRTH", "width": '200px' },
            { "data": "CONTACTNUMBER", "width": '200px' },
            { "data": "EMAIL", "width": '200px' },
            { "data": "TYPE", "width": '200px' }
        ],
        //"order": [[1, "asc"]],
    });
}
function LoadTrainerList() {

    $("#TrainerGrid").DataTable().clear();
    $("#TrainerGrid").dataTable().fnDestroy();

    var table = $('#TrainerGrid').DataTable({
        "proccessing": true,
        "serverSide": true,
        //"scrollX": true,
        //"scrollY": '50vh',
        //scroller: true,

        "ajax": {
            complete: function (data) {
                //  $(".MasterLoader").fadeOut();
            },
            url: "../MasterSettings/MasterSetting/GetTrainer",
            "data": function (d) {

                DRIVER_ID = "0"
            },
            type: 'POST'
        },
        "columns": [
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
function LoadMemberList() {
    
    $("#MemberGrid").DataTable().clear();
    $("#MemberGrid").dataTable().fnDestroy();

    var table = $('#MemberGrid').DataTable({
        "proccessing": true,
        "serverSide": true,
        //"scrollX": true,
        //"scrollY": '50vh',
        //scroller: true,

        "ajax": {
            complete: function (data) {
                //  $(".MasterLoader").fadeOut();
            },
            url: "../Dashboard/Dashboard/GetMember",
            "data": function (d) {

                DRIVER_ID = "0"
            },
            type: 'POST'
        },
        "columns": [
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
    });
}
function LoadTotalMemberList() {

    $("#TotalMemberGrid").DataTable().clear();
    $("#TotalMemberGrid").dataTable().fnDestroy();

    var table = $('#TotalMemberGrid').DataTable({
        "proccessing": true,
        "serverSide": true,
        //"scrollX": true,
        //"scrollY": '50vh',
        //scroller: true,

        "ajax": {
            complete: function (data) {
                //  $(".MasterLoader").fadeOut();
            },
            url: "../MasterSettings/MasterSetting/GetMember",
            "data": function (d) {

                DRIVER_ID = "0"
            },
            type: 'POST'
        },
        "columns": [
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
    });
}
function LoadUnPaidMemberList() {

    $("#UnPaidGrid").DataTable().clear();
    $("#UnPaidGrid").dataTable().fnDestroy();

    var table = $('#UnPaidGrid').DataTable({
        "proccessing": true,
        "serverSide": true,
        //"scrollX": true,
        //"scrollY": '50vh',
        //scroller: true,

        "ajax": {
            complete: function (data) {
                //  $(".MasterLoader").fadeOut();
            },
            url: "../Dashboard/Dashboard/GetUnPaidDetails",
            "data": function (d) {

                MEMBER_ID = "0"
            },
            type: 'POST'
        },
        "columns": [
            { "data": "MEMBER_ID", "width": '100px' },
            { "data": "BATCH_ID", "width": '100px' },
            { "data": "NEXT_FEES_DATETIME", "width": '100px' },
            { "data": "NAME", "width": '100px' },
            { "data": "GENDER", "width": '100px' },
            { "data": "PENDING_AMOUNT", "width": '100px' },
            { "data": "CONTACTNUMBER", "width": '100px' },
        ],
    });
}
function LoadPayFeesDetails() {

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
            url: "../PaymentDetails/Payment/GetTodayPayFeesHistory",
            "data": function (d) {

                DRIVER_ID = "0"
            },
            type: 'POST'
        },
        "columns": [
            {
            render: function (data, type, row) {

                var strAction = '';
               
                    strAction += '<button id="btnEdit" class="btn btn-success btn-sm rounded-0" data-original-title="Edit"  onclick="OpenBillingPopup(\'' + encodeURIComponent(row.TRASACTION_NO)
                        + '\',\'' + encodeURIComponent(row.TRANSATION_DATETIME)
                        + '\',\'' + encodeURIComponent(row.MEMBER_NAME)
                        + '\',\'' + encodeURIComponent(row.PAID_AMOUNT)
                        + '\',\'' + encodeURIComponent(row.PENDING_AMOUNT)
                        + '\',\'' + encodeURIComponent(row.TOTAL_AMOUNT)
                        + '\',\'' + encodeURIComponent(row.TYPE_NAME)
                    + '\')"><i class="fa fa-file" aria-hidden="true"></i></button>';

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
    });
}
function LoadInActiveMemberList() {

    $("#InActiveMemberGrid").DataTable().clear();
    $("#InActiveMemberGrid").dataTable().fnDestroy();

    var table = $('#InActiveMemberGrid').DataTable({
        "proccessing": true,
        "serverSide": true,
        //"scrollX": true,
        //"scrollY": '50vh',
        //scroller: true,

        "ajax": {
            complete: function (data) {
                //  $(".MasterLoader").fadeOut();
            },
            url: "../Dashboard/Dashboard/GetInActiveMember",
            "data": function (d) {

                DRIVER_ID = "0"
            },
            type: 'POST'
        },
        "columns": [
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
            },
            {
                render: function (data, type, row) {
                    return (row.IS_ON_HOLD == 0 ? '<span class="badge bg-danger">In Active</span>' : '<span class="badge bg-success"> On Hold</span>')
                }
            },
            { "data": "IS_NO_HOLD_DATETIME", "width": '100px' },
        ],
    });
}