using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WiredBrain.CustomerPortal.AspNet.Resources;

namespace WiredBrain.CustomerPortal.Web.Validations
{
    public class ZipAttribute: RegularExpressionAttribute
    {
        public ZipAttribute(): base(@"^\d{5}$")
        {
            ErrorMessageResourceType = typeof(ValidationMessages);
            ErrorMessageResourceName = "Zip";
        }
    }
}
