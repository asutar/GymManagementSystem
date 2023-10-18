using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCCoreDemo.Areas.UserAccess.Models;
using MVCCoreDemo.Models;
using Newtonsoft.Json;

namespace MVCCoreDemo.Areas.UserAccess.Controllers
{
    [Area("UserAccess")]
    [CustomErrorHandling]
    public class UserOperationAccessController : Controller
    {
        private IUserAccessService _UserAccessService;
        public UserOperationAccessController(IUserAccessService UserAccessService)
        {
            _UserAccessService = UserAccessService;
        }
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult UserOperationAccess(string val)
        {
            if (val == "RoleWiseMenu")
            {
                return PartialView("_RoleWiseMenu");
            }
            else if (val == "RoleMenuOperationAccess")
            {
                return PartialView("_RoleMenuOperationAccess");
            }
            else
            {
                List<MenuModel> _List = HttpContext.Session.GetCustomObjectFromSession<List<MenuModel>>("UserMenus");
                ViewBag.MenuModel = _List;
                return View();
            }
            //if (val == "1")
            //{
            //    ViewBag.MenuModel = null;
            //}
            //else
            //{
            //    List<MenuModel> _List = HttpContext.Session.GetCustomObjectFromSession<List<MenuModel>>("UserMenus");
            //    ViewBag.MenuModel = _List;
            //}
            //List<MenuModel> _List= HttpContext.Session.GetCustomObjectFromSession<List<MenuModel>>("UserMenus");
            //ViewBag.MenuModel= _List;
           // return View();
        }
        public PartialViewResult RoleWiseMenu()
        {
            return PartialView("_RoleWiseMenu");
        }
        public PartialViewResult RoleMenuOperationAccess()
        {
            return PartialView("_RoleMenuOperationAccess");
        }
        public PartialViewResult CreatUser()
        {
            return PartialView("_CreatUser");
        }
        [HttpGet]
        public IActionResult GeAllMenu(string RoleId)
        {
            List<MenusForTree> _MenusForTree = new List<MenusForTree>();
            List<MenuModel> menuModels=  _UserAccessService.GetRoleWiseMenu_GetAllMenu(RoleId);

            _MenusForTree = menuModels.Select(x => new MenusForTree
            {
                id = x.MenuId.ToString(),
                parent = x.ParentMenuId.ToString() == "-1" ? "#" : x.ParentMenuId.ToString(),
                text = x.MenuName,
                icon = x.IconCssName
            }).ToList();

            return Json(_MenusForTree);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult GetRole(RoleModel _rolemodel)
        {
            List<UserRole> lstrole = new List<UserRole>();
            try
            {
              lstrole = _UserAccessService.UpdateRepositoryForIDAsync(Convert.ToInt32(_rolemodel.RoleId));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Json(lstrole);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult GetRoleMenuSetting(string RoleId)
        {
            List<RoleMenuMap> lstrole = new List<RoleMenuMap>();
            try
            {
                lstrole = _UserAccessService.GetRoleWiseMenuList(RoleId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Json(lstrole);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult UpdateRoleMenuMap(List<RoleMenuMap> roleMenuMaps, int RoleId)
        {
            roleMenuMaps[0].LastUpdateBy = Convert.ToString(HttpContext.Session.GetString("USER_ID"));
         
            bool ReturnVal = false;
            try
            {
              
                ReturnVal = _UserAccessService.UpdateRoleMenuMapList(roleMenuMaps, roleMenuMaps[0].LastUpdateBy);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Json(ReturnVal);
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public JsonResult GetUserMenuSetting(int UserId, int RoleId)
        //{
        //    List<RoleMenuMap> lstrole = new List<RoleMenuMap>();
        //    try
        //    {
        //        lstrole = _UserAccessService.GetRoleWiseMenuList(RoleId);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return Json(lstrole);
        //}
        public JsonResult UpdateRoleMenuOperationAccess(List<RoleMenuMap> roleMenuMaps)
        {

            roleMenuMaps[0].LastUpdateBy = Convert.ToString(HttpContext.Session.GetString("USER_ID"));

            bool ReturnVal = false;
            try
            {

                ReturnVal = _UserAccessService.UpdateRoleMenuOperationAccess(roleMenuMaps, roleMenuMaps[0].LastUpdateBy);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Json(ReturnVal);
        }
        public JsonResult GetSubClinet(DataTableAjaxPostModel model, User _model)
        {
             UserPagingation _Results = _UserAccessService.GetSubClientAsync(0, model);

            return Json(new
            {
                draw = model.draw,
                recordsTotal = _Results.filteredCount,
                recordsFiltered = _Results.filteredCount,
                data = _Results.UserList
            });
        }
        [HttpPost]
        public JsonResult CreateSubClient(User model)
        {
            int USER_ID = Convert.ToInt32(HttpContext.Session.GetString("USER_ID"));
           
            model.SUB_CLIENT_ID = USER_ID;
            model.USER_ID = USER_ID;
            model.ADDED_BY_ID = USER_ID;
            ReturnResponse returnResponse = new ReturnResponse();

            model.ADDED_BY = USER_ID;
            if (model.OPERATION_STATUS == "UPDATE")
            {
                returnResponse = _UserAccessService.UpdateSubClient(model);
            }
            else
            {
                returnResponse = _UserAccessService.AddSubClient(model);
            }

            return Json(returnResponse);

        }
    }
}