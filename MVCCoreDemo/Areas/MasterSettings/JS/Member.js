$(function () {

$("#MemberGrid").jqGrid
    ({
        url: "MasterSetting/GetMember",
        datatype: 'json',
        mtype: 'GET',
        //table header name
        colNames: ['Member Id', 'First Name', 'Last Name'],
        //colModel takes the data from controller and binds to grid
        colModel: [
            {
                key: true,
                hidden: true,
                name: 'MEMBERID',
                index: 'MEMBERID',
                editable: true
            }, {
                key: false,
                name: 'FIRSTNAME',
                index: 'FIRSTNAME',
                editable: true
            }, {
                key: false,
                name: 'LASTNAME',
                index: 'LASTNAME',
                editable: true
            }],

        pager: jQuery('#Memberpager'),
        rowNum: 10,
        rowList: [10, 20, 30, 40],
        height: '100%',
        viewrecords: true,
        caption: 'Jq grid sample Application',
        emptyrecords: 'No records to display',
        jsonReader:
        {
            root: "rows",
            page: "page",
            total: "total",
            records: "records",
            repeatitems: false,
            Id: "0"
        },
        autowidth: true,
        multiselect: false,
        iconSet: "fontAwesome",
        //pager-you have to choose here what icons should appear at the bottom
        //like edit,create,delete icons
    }).navGrid('#Memberpager',
        {
            edit: true,
            add: true,
            del: true,
            search: false,
            refresh: true
        }, {
            // edit options
            zIndex: 200,
            url: '/Jqgrid/Edit',
            closeOnEscape: true,
            closeAfterEdit: true,
            recreateForm: true,
            afterComplete: function (response) {
                if (response.responseText) {
                    alert(response.responseText);
                }
            }
        }, {
            // add options
            zIndex: 200,
            url: "/MasterSettings/MasterSetting/CreateProject",
            closeOnEscape: true,
            closeAfterAdd: true,
            afterComplete: function (response) {
                if (response.responseText) {
                    alert(response.responseText);
                }
            },
            beforeShowForm: function (response) {
                debugger;
            }

        }, {
            // delete options
            zIndex: 100,
            url: "/Jqgrid/Delete",
            closeOnEscape: true,
            closeAfterDelete: true,
            recreateForm: true,
            msg: "Are you sure you want to delete this task?",
            afterComplete: function (response) {
                if (response.responseText) {
                    alert(response.responseText);
                }
            }
        })
});  