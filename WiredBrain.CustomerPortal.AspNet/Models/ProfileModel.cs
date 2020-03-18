using System;
using System.ComponentModel.DataAnnotations;
using System.Web.ModelBinding;
using WiredBrain.CustomerPortal.AspNet.Resources;
using WiredBrain.CustomerPortal.Web.Data;

namespace WiredBrain.CustomerPortal.Web.Models
{
    public class ProfileModel
    {
        public int LoyaltyNumber { get; set; }
        [Display(Name = "Favorite drink")]
        public string Favorite { get; set; }
        [Required]
        public string Name { get; set; }
        public string Address { get; set; }
        [RegularExpression(@"^\d{5}$",
            ErrorMessageResourceType = typeof(ValidationMessages),
            ErrorMessageResourceName = "Zip")]
        public string Zip { get; set; }
        [StringLength(50)]
        public string City { get; set; }

        [Display(Name = "Email address")]
        [EmailAddress]
        [Required]
        public string EmailAddress { get; set; }
        [Display(Name = "Email address repeated")]
        [Compare("EmailAddress")]
        public string EmailAddressRepeated { get; set; }

        public DateTime BirthDate { get; set; }
        [Display(Name = "Add liquor to your coffee?")]
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
    }
}
