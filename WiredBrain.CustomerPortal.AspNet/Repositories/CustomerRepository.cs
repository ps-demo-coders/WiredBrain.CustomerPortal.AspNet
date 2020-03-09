using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using WiredBrain.CustomerPortal.Web.Data;
using WiredBrain.CustomerPortal.Web.Models;

namespace WiredBrain.CustomerPortal.Web.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerPortalDbContext dbContext;

        public CustomerRepository()
        {
            var connection = Effort.DbConnectionFactory.CreateTransient();
            dbContext = new CustomerPortalDbContext(connection);
            if (!dbContext.Customers.Any())
                dbContext.Seed();
        }

        public async Task<Customer> GetCustomerByLoyaltyNumber(int loyaltyNumber)
        {
            var customer = await dbContext.Customers.SingleOrDefaultAsync(c => c.LoyaltyNumber == loyaltyNumber);
            return customer;
        }

        public async Task SetProfile(ProfileModel model)
        {
            var customer = dbContext.Customers.SingleOrDefault(c => c.LoyaltyNumber == model.LoyaltyNumber);

            customer.Name = model.Name;
            customer.Address = model.Address;
            customer.Zip = model.Zip;
            customer.City = model.City;
            customer.AddLiquor = model.AddLiquor;
            customer.BirthDate = model.BirthDate;
            customer.EmailAddress = model.EmailAddress;
            customer.FavoriteDrink = model.Favorite;
            await dbContext.SaveChangesAsync();
        }
    }
}
