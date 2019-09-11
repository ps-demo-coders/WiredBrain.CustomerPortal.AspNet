using Owin;

namespace WiredBrain.CustomerPortal.AspNet.HeaderHelpers
{
    public static class IAppBuilderExtensions
    {
        public static void UseSecurityHeaders(this IAppBuilder app)
        {
            app.Use(async (context, next) =>
            {
                context.Response.Headers.Add("HeaderType", new[] { "HeaderValue" });
                await next();
            });
        }
    }
}