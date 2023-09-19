$(function () {
    debugger;
    $("#grid").jqGrid
        ({
            url: "MasterSetting/GetProject",
            datatype: 'json',
            mtype: 'Get',
            //table header name   
            colNames: ['Id', 'Name', 'Description'],
            //colModel takes the data from controller and binds to grid   
            colModel: [
                {
                    key: true,
                    hidden: true,
                    name: 'PROJECT_ID',
                    index: 'PROJECT_ID',
                    editable: true
                }, {
                    key: false,
                    name: 'Name',
                    index: 'Name',
                    editable: true
                }, {
                    key: false,
                    name: 'Description',
                    index: 'Description',
                    editable: true
                }],

            pager: jQuery('#pager'),
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
            multiselect: false
            //pager-you have to choose here what icons should appear at the bottom  
            //like edit,create,delete icons  
        }).navGrid('#pager',
            {
                edit: true,
                add: true,
                del: true,
                search: false,
                refresh: true
            }, {
                // edit options  
                zIndex: 100,
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
                zIndex: 100,
                url: "/MasterSettings/MasterSetting/CreateProject",
                closeOnEscape: true,
                closeAfterAdd: true,
                afterComplete: function (response) {
                    if (response.responseText) {
                        alert(response.responseText);
                    }
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
            });

});  