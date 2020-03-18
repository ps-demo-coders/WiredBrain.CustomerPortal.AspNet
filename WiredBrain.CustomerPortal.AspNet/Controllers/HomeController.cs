using System.Configuration;
using System.Threading.Tasks;
using System.Web.Mvc;
using WiredBrain.CustomerPortal.Web.Models;
using WiredBrain.CustomerPortal.Web.Repositories;

namespace WiredBrain.CustomerPortal.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICustomerRepository repo;

        public HomeController()
        {
            repo = new CustomerRepository();
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Enter loyalty number";
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Index(int loyaltyNumber)
        {
            var customer = await repo.GetCustomerByLoyaltyNumber(loyaltyNumber);
            if (customer == null)
            {
                ModelState.AddModelError(string.Empty, "Unknown loyalty number");
                return View();
            }
            return RedirectToAction("LoyaltyOverview", new { loyaltyNumber });
        }

        public async Task<ActionResult> LoyaltyOverview(int loyaltyNumber)
        {
            ViewBag.Title = "Your points";

            var customer = await repo.GetCustomerByLoyaltyNumber(loyaltyNumber);
            var pointsNeeded = int.Parse(ConfigurationManager.AppSettings["CustomerPortalSettings:PointsNeeded"]);

            var loyaltyModel = LoyaltyModel.FromCustomer(customer, pointsNeeded);

            return View(loyaltyModel);
        }

        public async Task<ActionResult> EditProfile(int loyaltyNumber)
        {
            ViewBag.Title = "Edit profile";

            var customer = await repo.GetCustomerByLoyaltyNumber(loyaltyNumber);
            return View(ProfileModel.FromCustomer(customer));
        }

        [HttpPost]
        public async Task<ActionResult> EditProfile(ProfileModel model)
        {
            if (ModelState.IsValid)
            {
                await repo.SetProfile(model);
                return RedirectToAction("LoyaltyOverview", new { loyaltyNumber = model.LoyaltyNumber });
            }
            return View(model);
        }
    }
}
