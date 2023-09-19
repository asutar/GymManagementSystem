var selectedRoleId = 0;
var SelectedUserId = 0;
var Toast;
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
    });
    $("#ddlUserRole").change(function () {
        GetRoleWise($('option:selected', this).val());
    });
});
function loadMenuSettings() {
    //?RoleId=' + RoleId
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

        'plugins': ['checkbox']
    });
};
function GetUserRoles() {
    var token = $("[name='__RequestVerificationToken']").val();

    var mod = {
        RoleId: '',
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
        //contentType: "application/json; charset=utf-8",
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
function GetRoleWise(radioButtonId) {

    var token = $("[name='__RequestVerificationToken']").val();

    selectedRoleId = radioButtonId;
    $('#menuList').jstree("deselect_all");
    try {
        $('#modal_loading').modal('show');
        $.ajax({
            url: "UserOperationAccess/GetRoleMenuSetting",
            type: "POST",
            //contentType: "application/json; charset=utf-8",
            data: {
                __RequestVerificationToken: token,
                "RoleId": radioButtonId
            },
            dataType: "JSON",
            success: function (response) {
                $("#menuList").jstree('open_all');
                $('#menuList').jstree("deselect_all");
                for (var i = 0; i < response.length; i++) {
                    if (response[i].isEnable) {
                        if (response[i].activeChilds == 0) {
                            $('#menuList').jstree('select_node', response[i].menuId);
                        }
                    }
                }
                $('#modal_loading').modal('hide');
            }
        });
    } catch (e) {

    }
};
function SaveRoleMenuMapping() {
    debugger;
    if ($('#ddlUserRole').val() === '0') {
        Swal.fire({
            type: 'error',
            title: 'Oops...',
            text: 'Select User Role.'
        });

        return;
    }


    if (selectedRoleId != 0) {
        var SettingList = [];
        var SettingSingle = [];
        var EnabledList = $("#menuList").jstree("get_checked", null, true);
        for (var i = 0; i < EnabledList.length; i++) {
            SettingSingle = new Menudata(EnabledList[i], selectedRoleId, true);
            SettingList.push(SettingSingle);
        }

        var token = $("[name='__RequestVerificationToken']").val();

        $.ajax({
            type: "POST",
            url: "UserOperationAccess/UpdateRoleMenuMap",
            data: {
                __RequestVerificationToken: token,
                roleMenuMaps: SettingList,
                RoleId: $('#ddlUserRole').val()
            },
            dataType: "JSON",
            success: function (response) {
                if (response) {
                    $('#ddlUserRole').val(0).change();
                    //Swal.fire("Menu updated Successfully")
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
        Swal.fire("Please Select role.");
    }

}
function Menudata(MenuId, RoleId, IsEnable) {
    this.MenuId = MenuId;
    this.RoleId = RoleId;
    this.IsEnable = IsEnable
}

function GetUserWise() {
    SelectedUserId = $("#ddlUserName").val();
    selectedRoleId = $("#ddlUserName option:selected").attr("data-RoleId");
    var token = $("[name='__RequestVerificationToken']").val();

    $('#menuList').jstree("deselect_all");
    try {
        $.ajax({
            url: "UserOperationAccess/GetUserMenuSetting",
            type: "POST",
            data: {
                __RequestVerificationToken: token,
                "UserId": SelectedUserId,
                "RoleId": selectedRoleId
            },
            dataType: "JSON",
            success: function (response) {
                $("#menuList").jstree('open_all');
                $('#menuList').jstree("deselect_all");
                for (var i = 0; i < response.Data.length; i++) {
                    if (response.Data[i].IsEnable) {
                        $('#menuList').jstree('select_node', response.Data[i].MenuId);
                    }
                }
            }
        });
    } catch (e) {

    }
};
$('#ddlUserName').on('change', function () {
    if ($('#ddlUserName').val() != "-") {
        loadMenuSettings();
        GetUserWise();
    }
});