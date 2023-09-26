using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCCoreDemo.Areas.MasterSettings.Models;
using MVCCoreDemo.Areas.PaymentDetails.Data;
using MVCCoreDemo.Areas.PaymentDetails.Models;
using MVCCoreDemo.Models;

namespace MVCCoreDemo.Areas.PaymentDetails.Controllers
{
    [Area("PaymentDetails")]
    [CustomErrorHandling]
    public class PaymentController : Controller
    {
        private IPaymentService _IPaymentService;
        public PaymentController(IPaymentService IPaymentService)
        {
            _IPaymentService = IPaymentService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public PartialViewResult PayFees()
        {
            return PartialView("_PayFees");
        }
        public PartialViewResult PayFeesDetails()
        {
            return PartialView("_PayFeesDetails");
        }
        public JsonResult GetPaymentTypeList(PaymentTypeList model)
        {
            IEnumerable<PaymentTypeList> Results = _IPaymentService.GetPaymentType(0);
            return Json(Results);
        }
        public JsonResult GetPayFees(DataTableAjaxPostModel model, PayFees _model) //Gets the todo Lists.  
        {
            PayFeesPagingation _Results = _IPaymentService.GetPayFees(0, model);
            return Json(new
            {
                draw = model.draw,
                recordsTotal = _Results.filteredCount,
                recordsFiltered = _Results.filteredCount,
                data = _Results.PayFeesList
            });
        }
        public JsonResult GetPendingAmount(PayFees model)
        {
            PayFees Results = _IPaymentService.GetPendingAmount(model.MEMBER_ID, model.BATCH_ID);
            return Json(Results);
        }
        [HttpPost]
        public JsonResult PayFees(PayFees model)
        {
            model.ADDED_BY = Convert.ToInt32(HttpContext.Session.GetString("USER_ID"));
            ReturnResponse Results = _IPaymentService.PayFees(model);
            return Json(Results);
        }
        public JsonResult GetPayFeesDetailsHistory(DataTableAjaxPostModel model, PayFees _model) //Gets the todo Lists.  
        {
            PayFeesPagingation _Results = _IPaymentService.GetPayFeesDetails(0, model);
            return Json(new
            {
                draw = model.draw,
                recordsTotal = _Results.filteredCount,
                recordsFiltered = _Results.filteredCount,
                data = _Results.PayFeesList
            });
        }
        public JsonResult GetBatchByMember(MemberList model)
        {
            List<BatchScheduledDateTime> Results = _IPaymentService.GetBatchByMember(model.MEMBERID);
            return Json(Results);
        }
        public JsonResult GetTodayPayFeesHistory(DataTableAjaxPostModel model, PayFees _model)
        {
            PayFeesPagingation _Results = _IPaymentService.GetTodayPayFeesHistory(0, model);
            return Json(new
            {
                draw = model.draw,
                recordsTotal = _Results.filteredCount,
                recordsFiltered = _Results.filteredCount,
                data = _Results.PayFeesList
            });
        }
    }
}