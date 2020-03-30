using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WiredBrain.CustomerPortal.AspNet.Validations;
using WiredBrain.CustomerPortal.Web.Validations;

namespace WiredBrain.CustomerPortal.AspNet
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            DataAnnotationsModelValidatorProvider
                .RegisterAdapter(typeof(ZipAttribute), typeof(ZipAttributeAdapter));
        }
    }
}
