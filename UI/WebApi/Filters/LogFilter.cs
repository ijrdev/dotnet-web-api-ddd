using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace UI.WebApi.Core.Filters
{
    public class LogFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine(
                @$"Web API Logs - ({context.RouteData.Values["controller"]} - {context.RouteData.Values["action"]}) executing at {DateTime.Now}."
            );
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine(
                @$"Web API Logs - ({context.RouteData.Values["controller"]} - {context.RouteData.Values["action"]}) executed at {DateTime.Now}."
            );
        }
    }
}
