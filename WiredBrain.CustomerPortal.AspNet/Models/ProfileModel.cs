using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.ModelBinding;
using System.Web.Mvc;
using WiredBrain.CustomerPortal.AspNet.Resources;
using WiredBrain.CustomerPortal.AspNet.Validations;
using WiredBrain.CustomerPortal.Web.Data;
using WiredBrain.CustomerPortal.Web.Validations;

namespace WiredBrain.CustomerPortal.Web.Models
{
    public class ProfileModel//: IValidatableObject
    {
        public int LoyaltyNumber { get; set; }
        [Display(Name = "Favorite drink")]
        public string Favorite { get; set; }
        [Required]
        public string Name { get; set; }
        public string Address { get; set; }
        [Zip]
        [Remote(action: "CheckZip", controller: "Home", AdditionalFields = nameof(Address))]
        public string Zip { get; set; }
        [StringLength(50)]
        [Required]
        [UpperCase(3)]
        public string City { get; set; }

        [Display(Name = "Email address")]
        [EmailAddress]
        [Required]
        public string EmailAddress { get; set; }
        [Display(Name = "Email address repeated")]
        [System.ComponentModel.DataAnnotations.Compare("EmailAddress")]
        public string EmailAddressRepeated { get; set; }

        public DateTime BirthDate { get; set; }
        [Display(Name = "Add liquor to your coffee?")]
        //[Age21Required]
        public bool AddLiquor { get; set; }
        [Display(Name = "Number of sugar lumps")]
        [Range(0, 10)]
        public int SugarLumps { get; set; }

        public static ProfileModel FromCustomer(Customer customer)
        {
            return new ProfileModel
            {
                LoyaltyNumber = customer.LoyaltyNumber,
                Favorite = customer.FavoriteDrink,
                Name = customer.Name,
                Address = customer.Address,
                Zip = customer.Zip,
                City = customer.City,
                EmailAddress = customer.EmailAddress,
                BirthDate = customer.BirthDate,
                AddLiquor = customer.AddLiquor
            };
        }

        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
            //if (AddLiquor && (DateTime.Now.Year - BirthDate.Year < 21))
            //    yield return new ValidationResult("Must be 21 to purchase liquor")
            //    {

            //    };
        //}
    }
}
