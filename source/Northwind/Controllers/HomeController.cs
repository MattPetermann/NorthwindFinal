using System.Web.Mvc;

namespace Northwind.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
		{
			ViewBag.Message = "15% Off Today!";

			return View();
        }

		public ActionResult Order()
		{
			ViewBag.Message = "Place an Order";

			return View();
		}

        public ActionResult Products()
		{
			ViewBag.Message = "Your product page.";

			return View();
        }

        public ActionResult Account()
        {
            ViewBag.Message = "Your account page.";

            return View();
        }

        public ActionResult Cart()
        {
            ViewBag.Message = "Your cart page.";

            return View();
        }
    }
}