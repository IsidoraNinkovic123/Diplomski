using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;

namespace Presentation.Providers
{
    public class AddCustomHeaderFilter : ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            actionExecutedContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            //actionExecutedContext.Response.Headers.Add("Access-Control-Allow-Headers", "Authorization, Content-Type");
            //actionExecutedContext.Response.Headers.Add("Access-Control-Allow-Methods", "POST, PUT");
        }
    }
}