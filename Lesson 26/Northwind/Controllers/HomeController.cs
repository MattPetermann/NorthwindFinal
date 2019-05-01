using System;
using System.Linq;
using System.Web.Mvc;
using Northwind.Models;
using System.Web.Security;
using FormData.DataLayer;

namespace Northwind.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home/Index
        //[CustomAuthorization(LoginPage = "~/Home/Login1")]
        public ActionResult Index()
        {
            using (NorthwndEntities db = new NorthwndEntities())
            {
                // Filter by date
                DateTime now = DateTime.Now;
                var Dis = (from d in db.Discounts.Where(s => s.StartTime <= now && s.EndTime > now)
                           orderby Guid.NewGuid()
                           select new DiscountDTO
                           {
                               Code = d.Code,
                               Title = d.Title,
                               Description = d.Description,
                               DiscountPercent = d.DiscountPercent,
                               EndTime = d.EndTime
                           }).Take(3).ToList();
                return View(Dis);
            }
        }
        // GET: Home/SignOut
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction(actionName: "SignedOut", controllerName: "Home");
        }
        // GET: Home/SignedOut
        public ActionResult SignedOut()
        {
            return View();
        }

    }
}