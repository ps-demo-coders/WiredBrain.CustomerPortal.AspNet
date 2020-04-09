using System.Threading.Tasks;
using WiredBrain.CustomerPortal.Web.Data;

namespace WiredBrain.CustomerPortal.Web.Repositories
{
    public interface ICustomerRepository
    {
        Task<Customer> GetCustomerByLoyaltyNumber(int loyaltyNumber);
        Task SetFavorite(int loyaltyNumber, string favorite);
    }
}