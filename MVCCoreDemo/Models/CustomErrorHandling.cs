using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCoreDemo.Models
{
    public class CustomErrorHandling : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext exceptionContext)
        {
            if (!exceptionContext.ExceptionHandled)
            {
                string controllerName = (string)exceptionContext.RouteData.Values["controller"];
                string actionName = (string)exceptionContext.RouteData.Values["action"];

                Exception custException = new Exception("There is some error");

                exceptionContext.Result = new ViewResult
                {
                    ViewName = "~/Views/Error/Index.cshtml",
                    ViewData = new ViewDataDictionary(new EmptyModelMetadataProvider(), exceptionContext.ModelState)
                    {
                        ["ErrorMessage"] = exceptionContext.Exception.Message,
                        ["controllerName"] = controllerName,
                        ["actionName"] = actionName
                    }
                };

                exceptionContext.ExceptionHandled = true;

            }
        }
    }
}
