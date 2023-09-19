var selectedRoleId = 0;
var SelectedUserId = 0;
var SelectedMenu = [];
var IsTreeActive = false;
$(document).ready(function () {
    Toast = Swal.mixin({
        toast: true,
        position: 'top-end',
        showConfirmButton: false,
        timer: 3000,
        timerProgressBar: true,
        didOpen: (toast) => {
            toast.addEventListener('mouseenter', Swal.stopTimer)
            toast.addEventListener('mouseleave', Swal.resumeTimer)
        }
    })
});
function loadMenuSettings() {

    var RoleId = $("#ddlUserName option:selected").attr("data-RoleId") == null ? 0 : $("#ddlUserName option:selected").attr("data-RoleId");
    $('#menuList').jstree({
        'core': {
            'data': {
                'url': 'UserOperationAccess/GeAllMenu?RoleId=' + RoleId,
                'type': "GET",
                'data':
                    function (node) {

                        return {
                            'id': node.id
                        };
                    }
            }
        },
        'plugins': ['contextmenu']
    });

    $('#menuList')
        // listen for event
        .on('select_node.jstree', function (e, data) {

            debugger;
            var i, j, r = [];
            for (i = 0, j = data.selected.length; i < j; i++) {
                //r.push(data.instance.get_node(data.selected[i]).text);
                NodeClick(data.instance.get_node(data.selected[i]).id, data.instance.get_node(data.selected[i]).text, data.instance.get_node(data.selected[i]).parent);
            }
        })
        // create the instance
        .jstree();
};

function GetUserRoles() {
    var token = $("[name='__RequestVerificationToken']").val();

    $.ajax({
        url: "UserOperationAccess/GetRole",
        type: "POST",
        //contentType: "application/json; charset=utf-8",
        dataType: "JSON",
        data: {
            __RequestVerificationToken: token
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

function GetRoleWise(radioButtonId) {
    debugger
    var token = $("[name='__RequestVerificationToken']").val();

    selectedRoleId = radioButtonId;
    IsTreeActive = false;
    SelectedMenu = [];
    $('#menuList').jstree("deselect_all");
    try {
        //$('#modal_loading').modal('show');
        $.ajax({
            url: "UserOperationAccess/GetRoleMenuSetting",// GetRoleMenuOperationAccessMenuSetting",
            type: "POST",
            //contentType: "application/json; charset=utf-8",
            data: {
                __RequestVerificationToken: token,
                "RoleId": radioButtonId
            },
            dataType: "JSON",
            success: function (response) {

                SelectedMenu = response;
                $("#menuList").jstree('open_all');
                for (var i = 0; i < response.length; i++) {
                    if (response[i].isEnable) {
                        if (response[i].activeChilds > 0) {
                            $('#menuList').jstree('select_node', response[i].menuId);
                        }
                        else {
                            if (response[i].activeChilds == 0) { //&& (response.Data[i].IsAddAccess == true || response.Data[i].IsDeleteAccess == true || response.Data[i].IsEditAccess == true)) {
                                $('#menuList').jstree('select_node', response[i].menuId);
                            }
                        }
                    }
                    else if (response[i].activeChilds >= 1) {
                        $('#menuList').jstree('select_node', response[i].menuId);
                    }
                }

                var $tree = $('#menuList');
                $($tree.jstree().get_json($tree, {
                    flat: true
                })).each(function (index, value) {
                    var node = $("#menuList").jstree().get_node(this.id);
                    if (node.state.selected)
                        $("#menuList").jstree(true).show_node(node);
                    else
                        $("#menuList").jstree(true).hide_node(node);
                });

                IsTreeActive = true;
                $('#SelectedMenuText').html('');
                $('#divOperationAccess').hide();
                //$('#modal_loading').modal('hide');
            }
        });
    } catch (e) {

    }
};

function NodeClick(MenuID, MenuName, parent) {
    debugger;

    $('#SelectedMenuText').html('');
    $('#divOperationAccess').hide();
    $('#RoleMenuMapID').val('');
    $('#RoleID').val('');
    $('#MenuID').val('');

    if (IsTreeActive) {
        for (var i = 0; i < SelectedMenu.length; i++) {
            if (SelectedMenu[i].menuId == MenuID && SelectedMenu[i].activeChilds <= 0 && parent != "#") {


                $('#RoleMenuMapID').val(SelectedMenu[i].roleMenuMapId);
                $('#RoleID').val(SelectedMenu[i].roleId);
                $('#MenuID').val(SelectedMenu[i].menuId);
                //var Edit = SelectedMenu[i].IsEditAccess;
                //var Delete = SelectedMenu[i].IsDeleteAccess;
                //var Add = SelectedMenu[i].IsAddAccess;

                var Edit = SelectedMenu[i].iS_EDIT;
                var Delete = SelectedMenu[i].iS_DELETE;
                var Add = SelectedMenu[i].iS_ADD;



                if ((Add == false && Delete == false && Edit == false) || (Add == 0 && Delete == 0 && Edit == 0)) {
                    $('#divOperationAccess').hide();
                }
                else {
                    $('#divOperationAccess').show();
                }

                $('#SelectedMenuText').html('Menu Name : ' + MenuName );

                if (MenuID == '112') {
                    $('#Lbl_Add').text("Approve Uptime");
                }

                else if (parent == '161') {
                    $('#Lbl_Add').text("Approve Request");
                    $('#Lbl_Edit').text("Reject Request");
                }
                else {
                    $('#Lbl_Add').text("Add Access");
                    $('#Lbl_Edit').text("Edit Access");
                }

                if ((Add == false) || (Add == 0)) {
                    $('#chkIS_ADD_ACCESS').prop('unchecked', SelectedMenu[i].isAddAccess);
                    $('#chkIS_ADD_ACCESS').hide();
                    $('#Lbl_Add').hide();
                }
                if ((Edit == false) || (Edit == 0)) {

                    $('#chkIS_EDIT_ACCESS').prop('unchecked', SelectedMenu[i].isEditAccess);
                    $('#chkIS_EDIT_ACCESS').hide();
                    $('#Lbl_Edit').hide();
                }
                if ((Delete == false) || (Delete == 0)) {

                    $('#chkIS_DELETE_ACCESS').prop('unchecked', SelectedMenu[i].isDeleteAccess);
                    $('#chkIS_DELETE_ACCESS').hide();
                    $('#Lbl_Delete').hide();
                }

                if ((Add == true) || (Add == 1)) {
                    $('#chkIS_ADD_ACCESS').prop('checked', SelectedMenu[i].isAddAccess);
                    $('#chkIS_ADD_ACCESS').show();
                    $('#Lbl_Add').show();
                }
                if ((Edit == true) || (Edit == 1)) {

                    $('#chkIS_EDIT_ACCESS').prop('checked', SelectedMenu[i].isEditAccess);
                    $('#chkIS_EDIT_ACCESS').show();
                    $('#Lbl_Edit').show();
                }
                if ((Delete == true) || (Delete == 1)) {

                    $('#chkIS_DELETE_ACCESS').prop('checked', SelectedMenu[i].isDeleteAccess);
                    $('#chkIS_DELETE_ACCESS').show();
                    $('#Lbl_Delete').show();
                }

                //$('#divOperationAccess').show();
                //$('#SelectedMenuText').html('<strong> Menu Name : ' + MenuName + '</strong >');

                //$('#chkIS_ADD_ACCESS').prop('checked', SelectedMenu[i].IsAddAccess);
                //$('#chkIS_EDIT_ACCESS').prop('checked', SelectedMenu[i].IsEditAccess);
                //$('#chkIS_DELETE_ACCESS').prop('checked', SelectedMenu[i].IsDeleteAccess);
            }
        }

    }
}

function MenuOperationAccessdata(RoleMenuMapID, MenuId, RoleId, IsAddAccess, IsEditAccess, IsDeleteAccess) {
    this.RoleMenuMapID = RoleMenuMapID;
    this.MenuId = MenuId;
    this.RoleId = RoleId;
    this.IsAddAccess = IsAddAccess;
    this.IsEditAccess = IsEditAccess;
    this.IsDeleteAccess = IsDeleteAccess;


}

function saveRoleMenuOperationAccess() {
    try {
        var token = $("[name='__RequestVerificationToken']").val();

        var selectedRoleMenuMapID = $('#RoleMenuMapID').val();
        if (selectedRoleMenuMapID != 0) {
            var SettingList = [];
            SettingList.push(new MenuOperationAccessdata(selectedRoleMenuMapID, $('#MenuID').val(), $('#RoleID').val(),
                $('#chkIS_ADD_ACCESS').prop('checked'),
                $('#chkIS_EDIT_ACCESS').prop('checked'),
                $('#chkIS_DELETE_ACCESS').prop('checked')));
            $.ajax({
                type: "POST",
                url: "UserOperationAccess/UpdateRoleMenuOperationAccess",
                //contentType: "application/json; charset=utf-8",
                data: {
                    __RequestVerificationToken: token,
                    roleMenuMaps: SettingList
                },
                dataType: "JSON",
                success: function (response) {
                    ClearData($('#RoleID').val());
                    if (response) {
                        Toast.fire({
                            icon: 'success',
                            title: 'Menu updated Successfully'
                        });
                    } else {
                        Toast.fire({
                            icon: 'error',
                            title: 'Enabled to updated menu'
                        })
                    }

                }
            });
        }
        else {
            swal("Please Select Menu.");
        }
    } catch (e) {

    }
};

function ClearData(RoleID) {
    GetRoleWise($('#RoleID').val());
    $('#SelectedMenuText').html('');
    $('#divOperationAccess').hide();
    $('#RoleMenuMapID').val('');
    $('#RoleID').val('');
    $('#MenuID').val('');
}