using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCCoreDemo.Areas.Dashboard.Data;
using MVCCoreDemo.Areas.Dashboard.Models;
using MVCCoreDemo.Areas.MasterSettings.Models;
using MVCCoreDemo.Models;

namespace MVCCoreDemo.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [CustomErrorHandling]
    public class DashboardController : Controller
    {
        private IDashboardService _IDashboardService;
        public DashboardController(IDashboardService IDashboardService)
        {
            _IDashboardService = IDashboardService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public JsonResult GetAllCount(AllCount model)
        {
            model.USER_ID =  Convert.ToInt32(HttpContext.Session.GetString("USER_ID"));
            AllCount Results = _IDashboardService.GetAllCount(0);
            return Json(Results);
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Account");
        }
        public JsonResult GetYearlyMonthyFeesDetailsChart(YearMonthlyChart model)
        {
            model.USER_ID = Convert.ToInt32(HttpContext.Session.GetString("USER_ID"));
            YearMonthlyChart Results = _IDashboardService.GetYearlyMonthyFeesDetailsChart(model.USER_ID);
            return Json(Results);
        }
        public JsonResult GetYearlyMonthyAdmissionDetailsChart(YearMonthlyChart model)
        {
            model.USER_ID = Convert.ToInt32(HttpContext.Session.GetString("USER_ID"));
            YearMonthlyChart Results = _IDashboardService.GetYearlyMonthyAdmissionDetailsChart(model.USER_ID);
            return Json(Results);
        }
        public JsonResult GetBirthday(DataTableAjaxPostModel model, Birthday _model)
        {

            BirthdayPagingation _Results = _IDashboardService.GetBirthday(0, model);
            return Json(new
            {
                draw = model.draw,
                recordsTotal = _Results.filteredCount,
                recordsFiltered = _Results.filteredCount,
                data = _Results.BirthdayList
            });
        }
        public JsonResult GetMember(DataTableAjaxPostModel model, MemberRegistration _model) //Gets the todo Lists.  
        {
            MemberRegistrationPagingation _Results = _IDashboardService.GetMemberToday(0, model);
            return Json(new
            {
                draw = model.draw,
                recordsTotal = _Results.filteredCount,
                recordsFiltered = _Results.filteredCount,
                data = _Results.MemberList
            });
        }
        public JsonResult GetUnPaidDetails(DataTableAjaxPostModel model, Unpaid _model) //Gets the todo Lists.  
        {
            UnpaidPagingation _Results = _IDashboardService.GetUnPaidDetails(0, model);
            return Json(new
            {
                draw = model.draw,
                recordsTotal = _Results.filteredCount,
                recordsFiltered = _Results.filteredCount,
                data = _Results.UnpaidList
            });
        }
    }
}