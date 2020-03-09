using System;
using System.ComponentModel.DataAnnotations;

namespace WiredBrain.CustomerPortal.Web.Data
{
    public class Customer
    {
        public int Id { get; set; }
        public int LoyaltyNumber { get; set; }

        [StringLength(200)]
        public string Name { get; set; }
        public int Points { get; set; }
        public int FreeCoffees { get; set; }

        [StringLength(400)]
        public string FavoriteDrink { get; set; }

        [StringLength(200)]
        public string Address { get; set; }
        [StringLength(10)]
        public string Zip { get; set; }
        [StringLength(50)]
        public string City { get; set; }
        [StringLength(200)]
        public string EmailAddress { get; set; }

        public DateTime BirthDate { get; set; }
        public bool AddLiquor { get; set; }
    }
}
