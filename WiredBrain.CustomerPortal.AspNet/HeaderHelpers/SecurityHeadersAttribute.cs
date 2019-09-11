using System.Web.Mvc;

namespace WiredBrain.CustomerPortal.AspNet.HeaderHelpers
{
    public class SecurityHeadersAttribute : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            var result = context.Result;

            if (result is ViewResult)
            {
                context.HttpContext.Response.Headers.Add("HeaderType", "HeaderValue");
            }
        }
    }
}