var selectedRoleId = 0;
var SelectedUserId = 0;

function loadMenuSettings() {
    //?RoleId=' + RoleId
    var RoleId = $("#ddlUserName option:selected").attr("data-RoleId") == null ? 0 : $("#ddlUserName option:selected").attr("data-RoleId");

    $('#menuList').jstree({
        'core': {
            'data': {
                'url': 'UserAccess/UserOperationAccess/GeAllMenu?RoleId=' + RoleId,
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
    var token = '@Html.AntiForgeryToken()'; // $("[name='__RequestVerificationToken']").val();

    var mod = {
        RoleId: '',
        RoleName: '',
        RoleDescription: '',
        IsInUse: '',
        LastUpdateBy: '',
        LastUpdateTime: '',
        UserID: ''
    };
    debugger;
    $.ajax({
        url: "UserAccess/UserOperationAccess/GetRole",
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
            $.each(response.Data, function (i, item) {
                $('#ddlUserRole').append($('<option/>').val(item.RoleId).text(item.RoleName));
            });
            $('#ddlUserRole').select2();
        }
    });
};