using Owin;

namespace WiredBrain.CustomerPortal.AspNet.HeaderHelpers
{
    public static class IAppBuilderExtensions
    {
        public static void UseSecurityHeaders(this IAppBuilder app)
        {
            app.Use(async (context, next) =>
            {
                context.Response.Headers.Add(
                    "Content-Security-Policy", new[] {"style-src 'self' " +
                    "https://stackpath.bootstrapcdn.com;" +
                    "frame-ancestors 'none'" });
                context.Response.Headers.Add(
                    "Feature-Policy", new[] { "camera 'none'" });
                context.Response.Headers.Add(
                    "X-Content-Type-Options", new[] { "nosniff" });
                context.Response.Headers.Add(
                    "Referrer-Policy", new[] { "no-referrer" });
                await next();
            });
        }
    }
}