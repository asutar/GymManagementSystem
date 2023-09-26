using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCCoreDemo.Areas.MasterSettings.Data;
using MVCCoreDemo.Areas.MasterSettings.Models;
using MVCCoreDemo.Models;

namespace MVCCoreDemo.Areas.MasterSettings.Controllers
{
    [Area("MasterSettings")]
    [CustomErrorHandling]
    public class MasterSettingController : Controller
    {
        private IMasterSettingService _MasterSettingService;
        private IHostingEnvironment _hostingEnvironment;
        public MasterSettingController(IMasterSettingService MasterSettingService, IHostingEnvironment hostingEnvironment)
        {
            _MasterSettingService = MasterSettingService;
            _hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }
        public PartialViewResult Project()
        {
            return PartialView("_Project");
        }
        public PartialViewResult Member()
        {
            return PartialView("_Member");
        }
        public PartialViewResult Batch()
        {
            return PartialView("_Batch");
        }
        public PartialViewResult BatchMember()
        {
            return PartialView("_BatchMember");
        }
        public PartialViewResult Trainer()
        {
            return PartialView("_Trainer");
        }
        public PartialViewResult BatchTiming()
        {
            return PartialView("_BatchTiming");
        }
        public PartialViewResult Package()
        {
            return PartialView("_Package");
        }
        public JsonResult GetProject(string sidx, string sord, int page, int rows) //Gets the todo Lists.  
        {
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;
            //var Results = _MasterSettingService.GetProject(0);
            IEnumerable<Project>  Results = _MasterSettingService.GetProject(0);
            int totalRecords = Results.Count();
            var totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);
            if (sord.ToUpper() == "DESC")
            {
                Results = Results.OrderByDescending(s => s.PROJECT_ID);
                Results = Results.Skip(pageIndex * pageSize).Take(pageSize);
            }
            else
            {
                Results = Results.OrderBy(s => s.PROJECT_ID);
                Results = Results.Skip(pageIndex * pageSize).Take(pageSize);
            }
            var jsonData = new
            {
                total = totalPages,
                page,
                records = totalRecords,
                rows = Results
            };
            return Json(jsonData);
        }
        public JsonResult GetMember(DataTableAjaxPostModel model, MemberRegistration _model) //Gets the todo Lists.  
        {
            MemberRegistrationPagingation _Results = _MasterSettingService.GetMember(0, model);
            return Json(new
            {
                draw = model.draw,
                recordsTotal = _Results.filteredCount,
                recordsFiltered = _Results.filteredCount,
                data = _Results.MemberList
            });
        }
        public JsonResult GetGender(Gender model) //Gets the todo Lists.  
        {
            IEnumerable<Gender> Results = _MasterSettingService.GetGender(0);
            return Json(Results);
        }
        [HttpPost]
        public JsonResult CreateMember(MemberRegistration model)
        {
            int USER_ID =Convert.ToInt32(HttpContext.Session.GetString("USER_ID"));
            ReturnResponse returnResponse = new ReturnResponse();

            model.ADDED_BY = USER_ID;
            if (model.OPERATION_STATUS == "UPDATE")
            {
                returnResponse = _MasterSettingService.UpdateMember(model);
            }
            else {
                returnResponse = _MasterSettingService.AddMember(model);
            }
           
            return Json(returnResponse);

        }
        public JsonResult GetBatch(DataTableAjaxPostModel model, BATCH _model) //Gets the todo Lists.  
        {
           
            BATCHPagingation _Results = _MasterSettingService.GetBatch(0, model);
            return Json(new
            {
                draw = model.draw,
                recordsTotal = _Results.filteredCount,
                recordsFiltered = _Results.filteredCount,
                data = _Results.BatchList
            });
        }
        [HttpPost]
        public JsonResult CreateBatch(BATCH model)
        {
            int USER_ID = Convert.ToInt32(HttpContext.Session.GetString("USER_ID"));
            ReturnResponse returnResponse = new ReturnResponse();

            model.ADDED_BY = USER_ID;
            if (model.OPERATION_STATUS == "UPDATE")
            {
                returnResponse = _MasterSettingService.UpdateBatch(model);
            }
            else
            {
                returnResponse = _MasterSettingService.AddBatch(model);
            }

            return Json(returnResponse);

        }
        public JsonResult GetBatchMember(DataTableAjaxPostModel model, BatchMember _model) //Gets the todo Lists.  
        { 
            BatchMemberPagingation _Results = _MasterSettingService.GetBatchMember(0, model);
           
            return Json(new
            {
                draw = model.draw,
                recordsTotal = _Results.filteredCount,
                recordsFiltered = _Results.filteredCount,
                data = _Results.BatchMemberList
            });
        }
        [HttpPost]
        public JsonResult CreateBatchMember(BatchMember model)
        {
            int USER_ID = Convert.ToInt32(HttpContext.Session.GetString("USER_ID"));
            ReturnResponse returnResponse = new ReturnResponse();

            model.ADDED_BY = USER_ID;
            if (model.OPERATION_STATUS == "UPDATE")
            {
                returnResponse = _MasterSettingService.UpdateBatchMember(model);
            }
            else
            {
                returnResponse = _MasterSettingService.AddBatchMember(model);
            }

            return Json(returnResponse);

        }
        public JsonResult GetMemberList(MemberList model) //Gets the todo Lists.  
        {
            IEnumerable<MemberList> Results = _MasterSettingService.GetMemberList(0);
            return Json(Results);
        }
        public JsonResult GetBatchList(BatchList model) //Gets the todo Lists.  
        {
            IEnumerable<BatchList> Results = _MasterSettingService.GetBatchList(0);
            return Json(Results);
        }
        [HttpPost]
        public JsonResult CreateTrainer(Trainer model)
        {
            int USER_ID = Convert.ToInt32(HttpContext.Session.GetString("USER_ID"));
            ReturnResponse returnResponse = new ReturnResponse();

            model.ADDED_BY = USER_ID;
            if (model.OPERATION_STATUS == "UPDATE")
            {
                returnResponse = _MasterSettingService.UpdateTrainer(model);
            }
            else
            {
                returnResponse = _MasterSettingService.AddTrainer(model);
            }

            return Json(returnResponse);

        }
        public JsonResult GetTrainer(DataTableAjaxPostModel model, BatchMember _model) //Gets the todo Lists.  
        {
            TrainerPagingation _Results = _MasterSettingService.GetTrainerList(0, model);

            return Json(new
            {
                draw = model.draw,
                recordsTotal = _Results.filteredCount,
                recordsFiltered = _Results.filteredCount,
                data = _Results.MemberList
            });
        }
        public JsonResult GetSpecilisationList(Specialisation model) //Gets the todo Lists.  
        {
            IEnumerable<Specialisation> Results = _MasterSettingService.GetSpecialisationList(0);
            return Json(Results);
        }
        public JsonResult GetBatchTiming(DataTableAjaxPostModel model, BatchTiming _model) //Gets the todo Lists.  
        {
            BatchTimingPagingation _Results = _MasterSettingService.GetBatchTiming(_model.BATCH_ID, model);

            return Json(new
            {
                draw = model.draw,
                recordsTotal = _Results.filteredCount,
                recordsFiltered = _Results.filteredCount,
                data = _Results.BatchTimingList
            });
        }
        public JsonResult GetTrainerList(BatchList model) //Gets the todo Lists.  
        {
            IEnumerable<TrainerList> Results = _MasterSettingService.GetTrainerList(0);
            return Json(Results);
        }
        [HttpPost]
        public JsonResult CreateBatchTiming(BatchTiming model)
        {
            int USER_ID = Convert.ToInt32(HttpContext.Session.GetString("USER_ID"));
            ReturnResponse returnResponse = new ReturnResponse();

            model.ADDED_BY = USER_ID;
            if (model.OPERATION_STATUS == "UPDATE")
            {
                returnResponse = _MasterSettingService.UpdateBatchTiming(model);
            }
            else
            {
                returnResponse = _MasterSettingService.AddBatchTiming(model);
            }

            return Json(returnResponse);

        }
        [HttpPost]
        public JsonResult DeleteBatchTiming(BatchTiming model)
        {
            int USER_ID = Convert.ToInt32(HttpContext.Session.GetString("USER_ID"));
            ReturnResponse returnResponse = new ReturnResponse();

            model.ADDED_BY = USER_ID;
            returnResponse = _MasterSettingService.DeleteBatchTiming(model.BATCH_TIMING_ID);
            
            return Json(returnResponse);

        }
        public JsonResult GetBatchTimingCount(DataTableAjaxPostModel model, BatchTiming _model) //Gets the todo Lists.  
        {
            BatchTimingPagingation _Results = _MasterSettingService.GetBatchTimingCount(0, model);

            return Json(new
            {
                draw = model.draw,
                recordsTotal = _Results.filteredCount,
                recordsFiltered = _Results.filteredCount,
                data = _Results.BatchTimingList
            });
        }
        public JsonResult GetBatchScheduledDateTimeList(BatchScheduledDateTime model) //Gets the todo Lists.  
        {
            IEnumerable<BatchScheduledDateTime> Results = _MasterSettingService.GetBatchScheduledDateTimeList(0);
            return Json(Results);
        }
        public JsonResult GetPackage(DataTableAjaxPostModel model, Package _model) //Gets the todo Lists.  
        {

            PackagePagingation _Results = _MasterSettingService.GetPackage(0, model);
            return Json(new
            {
                draw = model.draw,
                recordsTotal = _Results.filteredCount,
                recordsFiltered = _Results.filteredCount,
                data = _Results.PackageList
            });
        }
        [HttpPost]
        public JsonResult CreatePackage(Package model)
        {
            int USER_ID = Convert.ToInt32(HttpContext.Session.GetString("USER_ID"));
            ReturnResponse returnResponse = new ReturnResponse();

            model.ADDED_BY = USER_ID;
            if (model.OPERATION_STATUS == "UPDATE")
            {
                model.UPDATED_BY = USER_ID;
                returnResponse = _MasterSettingService.UpdatePackage(model);
            }
            else
            {
                returnResponse = _MasterSettingService.AddPackage(model);
            }

            return Json(returnResponse);

        }
        public JsonResult GetTaxList(Tax model)
        {
            IEnumerable<Tax> Results = _MasterSettingService.GetTaxList(0);
            return Json(Results);
        }
        public JsonResult GetPackageList(PackageList model)
        {
            IEnumerable<PackageList> Results = _MasterSettingService.GetPackageList(0);
            return Json(Results);
        }
        public JsonResult GetBatchNoOfDays(BATCH model)
        {
            int NoOfDays = _MasterSettingService.GetBatchNoOfDays(model.BATCH_ID);

            return Json(NoOfDays);
        }
        [HttpPost]
        public IActionResult CaptureImage(string name)
        {
            try
            {
                var files = HttpContext.Request.Form.Files;
                if (files != null)
                {
                    foreach (var file in files)
                    {
                        if (file.Length > 0)
                        {
                            var fileName = file.FileName;
                            var fileNameToStore = string.Concat(Convert.ToString(Guid.NewGuid()), Path.GetExtension(fileName));
                            //  Path to store the snapshot in local folder
                            var filepath = Path.Combine(_hostingEnvironment.WebRootPath, "Photos") + $@"\{fileNameToStore}";

                            // Save image file in local folder
                            if (!string.IsNullOrEmpty(filepath))
                            {
                                using (FileStream fileStream = System.IO.File.Create(filepath))
                                {
                                    file.CopyTo(fileStream);
                                    fileStream.Flush();
                                }
                            }

                            // Save image file in database
                            var imgBytes = System.IO.File.ReadAllBytes(filepath);
                            if (imgBytes != null)
                            {
                                if (imgBytes != null)
                                {
                                    string base64String = Convert.ToBase64String(imgBytes, 0, imgBytes.Length);
                                    string imageUrl = string.Concat("data:image/jpg;base64,", base64String);

                                    // Code to store into database
                                    // save filename and image url(base 64 string) to the database
                                }
                            }
                        }
                    }
                    return Json(true);
                }
                else
                {
                    return Json(false);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}