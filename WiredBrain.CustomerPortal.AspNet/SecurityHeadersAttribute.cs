using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WiredBrain.CustomerPortal.AspNet
{
    public class SecurityHeadersAttribute : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            var result = context.Result;

            if (result is ViewResult)
            {
                context.HttpContext.Response.Headers
                    .Add("content-security-policy", "default-src 'self'; style-src https://stackpath.bootstrapcdn.com;");
            }
        }
    }
}