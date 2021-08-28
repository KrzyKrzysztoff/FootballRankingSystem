using Microsoft.ApplicationInsights;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace FootballRankingSystemMVC
{
    public class ExceptionActionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            context.HttpContext.Response.ContentType = "application/json";
            context.Result = new JsonResult(context.Exception.Message);
            var result = new RedirectToActionResult("error", "home", null);
            context.ExceptionHandled = true;
            context.Result = result;
        }





    }
}
