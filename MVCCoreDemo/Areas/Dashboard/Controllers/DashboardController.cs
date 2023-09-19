using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCCoreDemo.Areas.Dashboard.Data;
using MVCCoreDemo.Areas.Dashboard.Models;
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
            YearMonthlyChart Results = _IDashboardService.GetYearlyMonthyFeesDetailsChart("0");
            return Json(Results);
        }
    }
}