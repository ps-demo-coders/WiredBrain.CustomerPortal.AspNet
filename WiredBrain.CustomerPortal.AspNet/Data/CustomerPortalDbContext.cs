﻿using System.Data.Common;
using System.Data.Entity;

namespace WiredBrain.CustomerPortal.Web.Data
{
    public class CustomerPortalDbContext : DbContext
    {
        public CustomerPortalDbContext(DbConnection connection): base(connection, false)
        {
        }

        public DbSet<Customer> Customers { get; set; }

        public void Seed()
        {
            Customers.Add(new Customer { Name = "Roland", FavoriteDrink = "Latte Macchiato extra strong, no sugar, extra milk", LoyaltyNumber = 5932, Points = 831, FreeCoffees = 1 });
            Customers.Add(new Customer { Name = "David", FavoriteDrink = "Expresso", LoyaltyNumber = 4832, Points = 164, FreeCoffees = 0 });
            SaveChanges();
        }
    }
}
