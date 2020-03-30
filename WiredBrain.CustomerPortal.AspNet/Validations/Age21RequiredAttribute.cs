using System;
using System.ComponentModel.DataAnnotations;
using WiredBrain.CustomerPortal.Web.Models;

namespace WiredBrain.CustomerPortal.AspNet.Validations
{
    public class Age21RequiredAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value,
            ValidationContext validationContext)
        {
            if (!(value is bool addLiquor))
                throw new ArgumentException("Age21Required can only be used on a property of type bool");

            var model = (ProfileModel)validationContext.ObjectInstance;

            if (addLiquor && (DateTime.Now.Year - model.BirthDate.Year < 21))
                return new ValidationResult("Must be 21 to purchase liquor");

            return ValidationResult.Success;
        }
    }
}