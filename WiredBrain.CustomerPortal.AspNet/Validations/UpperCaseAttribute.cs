using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace WiredBrain.CustomerPortal.Web.Validations
{
    public class UpperCaseAttribute : ValidationAttribute, IClientValidatable
    {
        private readonly int minLength;

        public UpperCaseAttribute(int minLength)
        {
            ErrorMessage = "Must be upper case";
            this.minLength = minLength;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(
            ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule()
            {
                ErrorMessage = this.ErrorMessage,
                ValidationType = "uppercase"
            };

            rule.ValidationParameters.Add("minlength", minLength);
            yield return rule;
        }

        public override bool IsValid(object value)
        {
            if (!(value is string s))
                throw new ArgumentException("Not a string!");
            if (s.Length < minLength)
                return true;
            return s == s.ToUpper();
        }
    }
}
