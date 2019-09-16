using System.Web.Mvc;
using WiredBrain.CustomerPortal.AspNet.HeaderHelpers;

namespace WiredBrain.CustomerPortal.AspNet
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(
            GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            //filters.Add(new SecurityHeadersAttribute());
        }
    }
}
