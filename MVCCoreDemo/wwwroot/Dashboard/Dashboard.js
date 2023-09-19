
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
function RenderCharts() {

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
           // debugger;
            var data = [
                { month: "January", count: response.January },
                { month: "February", count: response.February },
                { month: "March", count: response.March  },
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


    
    var data = [
        { month: "January", collection: 1000 },
        { month: "February", collection: 1500 },
        { month: "March", collection: 2000 },
        { month: "April", collection: 1800 },
        { month: "May", collection: 2500 },
        { month: "June", collection: 2200 },
        // Add more months and collections as needed
    ];
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
            { label: "Dato Ej.1", value: 123, color: colorDanger },
            { label: "Dato Ej.2", value: 369 },
            { label: "Dato Ej.3", value: 246 },
            { label: "Dato Ej.4", value: 159 },
            { label: "Dato Ej.5", value: 357 }
        ]
    });
}