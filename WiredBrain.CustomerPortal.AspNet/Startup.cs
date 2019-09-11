using Microsoft.Owin;
using Owin;
using WiredBrain.CustomerPortal.AspNet.HeaderHelpers;

[assembly: OwinStartup(typeof(WiredBrain.CustomerPortal.AspNet.Startup))]

namespace WiredBrain.CustomerPortal.AspNet
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //app.Use(async (context, next) =>
            //{
            //    context.Response.Headers.Add("HeaderType", new[] { "HeaderValue" });
            //    await next();
            //});

            //app.UseSecurityHeaders();
        }
    }
}
