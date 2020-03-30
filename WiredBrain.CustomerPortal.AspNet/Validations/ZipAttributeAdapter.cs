using System.Collections.Generic;
using System.Web.Mvc;
using WiredBrain.CustomerPortal.Web.Validations;

namespace WiredBrain.CustomerPortal.AspNet.Validations
{
    public class ZipAttributeAdapter : DataAnnotationsModelValidator<ZipAttribute>
    {
        private readonly string message;
        private readonly ZipAttribute attribute;

        public ZipAttributeAdapter(
            ModelMetadata metadata,
            ControllerContext context,
            ZipAttribute attribute)
            : base(metadata, context, attribute)
        {
            message = attribute.FormatErrorMessage(metadata.PropertyName);
            this.attribute = attribute;
        }

        public override IEnumerable<ModelClientValidationRule>
            GetClientValidationRules()
        {
            var rule = new ModelClientValidationRule()
            {
                ErrorMessage = message,
                ValidationType = "regex"
            };

            rule.ValidationParameters.Add("pattern", attribute.Pattern);
            yield return rule;
        }
    }
}