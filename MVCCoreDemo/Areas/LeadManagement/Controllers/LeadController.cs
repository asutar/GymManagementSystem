using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCCoreDemo.Models;

namespace MVCCoreDemo.Areas.LeadManagement.Controllers
{
    [Area("Lead")]
    [CustomErrorHandling]
    public class LeadController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public PartialViewResult CreateLead()
        {
            return PartialView("_CreateLead");
        }
    }
}