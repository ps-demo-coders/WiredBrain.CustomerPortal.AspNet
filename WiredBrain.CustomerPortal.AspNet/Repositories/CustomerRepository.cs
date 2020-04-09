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
            var customer = dbContext.Customers.SingleOrDefault(c => c.LoyaltyNumber == loyaltyNumber);
            return customer;
        }

        public async Task SetFavorite(int loyaltyNumber, string favorite)
        {
            var customer = dbContext.Customers.SingleOrDefault(c => c.LoyaltyNumber == loyaltyNumber);

            customer.FavoriteDrink = favorite;
            await dbContext.SaveChangesAsync();
        }
    }
}
