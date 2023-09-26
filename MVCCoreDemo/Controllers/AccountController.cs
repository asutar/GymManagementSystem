using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCCoreDemo.Models;
using MVCCoreDemo.Services;

namespace MVCCoreDemo.Controllers
{
    public class AccountController : Controller
    {
        string _ApiKeyService = Startup.ApiKeyService;
        private ILoginService _loginService;
        public AccountController(ILoginService loginService)
        {
            _loginService = loginService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index([Bind] LoginModel loginModel)
        {
         
            if (loginModel.USER_NAME != null || loginModel.USER_NAME != "")
            {
                LoginModel _loginModel= _loginService.IsUserValidate(loginModel.USER_NAME, loginModel.PASSWORD);

                if (_loginModel.USER_NAME == null || _loginModel.USER_NAME == "")
                {
                    return Json(false);
                }
                else
                {
                    MenuDetails menuDetails = _loginService.GetUserMenuByRole(_loginModel.USER_ID);
                    //Session["Home_Page"] = menuDetails.MENU_ACCESS;
                    HttpContext.Session.SetObjectInSession("Home_Page", menuDetails.MENU_ACCESS);
                    HttpContext.Session.SetObjectInSession("UserMenus", menuDetails.MENU_MODEL_LIST);
                    HttpContext.Session.SetObjectInSession("USER_ID", _loginModel.USER_ID);
                    HttpContext.Session.SetObjectInSession("ApiKey", _ApiKeyService);
                    // HttpContext.Session.Set<List<MenuModel>>("UserMenus", menuDetails.MENU_MODEL_LIST);


                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, _loginModel.USER_NAME)
                        // ... add other claims as needed
                    };
                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    var authProperties = new AuthenticationProperties
                    {
                        ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30), // Set cookie expiration time
                        IsPersistent = loginModel.REMEMBER, // 
                    };
                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

                    return Json(true);
                    //return RedirectToAction("Index", "Account", "");
                }
            }
            else
            {
                //ViewBag.error = "Invalid Account";
                //return View("Index");
                return Json(false);
            }
        }
    }
}