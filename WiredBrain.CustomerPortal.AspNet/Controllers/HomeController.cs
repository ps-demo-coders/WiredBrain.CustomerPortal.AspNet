using System;
using System.Configuration;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WiredBrain.CustomerPortal.Web.Models;
using WiredBrain.CustomerPortal.Web.Repositories;

namespace WiredBrain.CustomerPortal.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICustomerRepository repo;
        private const string cookieName = "LoyaltyNumber";

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
            var cookie = new HttpCookie(cookieName, $"{loyaltyNumber}")
            { SameSite = SameSiteMode.Lax };
            Response.Cookies.Add(cookie);
            return RedirectToAction("LoyaltyOverview", new { loyaltyNumber });
        }

        public async Task<ActionResult> LoyaltyOverview()
        {
            ViewBag.Title = "Your points";

            var customer = await repo.GetCustomerByLoyaltyNumber(GetLoyaltyNumberFromCookie());
            var pointsNeeded = int.Parse(ConfigurationManager.AppSettings["CustomerPortalSettings:PointsNeeded"]);

            var loyaltyModel = LoyaltyModel.FromCustomer(customer, pointsNeeded);
            return View(loyaltyModel);
        }

        public async Task<ActionResult> EditFavorite()
        {
            ViewBag.Title = "Edit favorite";

            var customer = await repo.GetCustomerByLoyaltyNumber(GetLoyaltyNumberFromCookie());
            return View(new EditFavoriteModel
            {
                LoyaltyNumber = customer.LoyaltyNumber,
                Favorite = customer.FavoriteDrink
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditFavorite(EditFavoriteModel model)
        {
            await repo.SetFavorite(GetLoyaltyNumberFromCookie(), model.Favorite);
            return RedirectToAction("LoyaltyOverview", new { loyaltyNumber = model.LoyaltyNumber });
        }

        public async Task<ActionResult> SetFavorite(string favorite)
        {
            await repo.SetFavorite(GetLoyaltyNumberFromCookie(), favorite);
            return RedirectToAction("LoyaltyOverview");
        }

        private int GetLoyaltyNumberFromCookie()
        {
            var cookie = Request.Cookies[cookieName];
            if (cookie == null)
                throw new ArgumentException("No cookie found");

            return int.Parse(Request.Cookies[cookieName].Value);
        }
    }
}
