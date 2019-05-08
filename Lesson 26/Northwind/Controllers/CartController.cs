using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using FormData.DataLayer;
using Northwind.Models;

namespace Northwind.Controllers
{
    public class CartController : Controller
    {

        public string TestMethod()
        {
            return "This is a test";
        }

        public JsonResult TestJson()
        {
            return Json("{ Greeting: Hi }", JsonRequestBehavior.AllowGet);
        }

        // POST: Cart/AddToCart
        [HttpPost]
        public JsonResult AddToCart(CartDTO cartDTO)
        {
            if (!ModelState.IsValid)
            {
                Response.StatusCode = 400;
                return Json(new { }, JsonRequestBehavior.AllowGet);
            }

            Cart sc = new Cart();
            sc.ProductID = cartDTO.ProductID;
            sc.CustomerID = cartDTO.CustomerID;

            using (NorthwndEntities db = new NorthwndEntities())
            {
                Cart cart = db.Carts.SingleOrDefault(c => c.ProductID == cartDTO.ProductID 
                                                        && c.CustomerID == cartDTO.CustomerID);
                if (cart != null)
                {
                    // cart exists
                    cart.Quantity += cartDTO.Quantity;
                }
                else
                {
                    // cart does not exist
                    sc.Quantity = cartDTO.Quantity;
                    db.Carts.Add(sc);
                }

                db.SaveChanges();
                return Json(sc, JsonRequestBehavior.AllowGet);
            }
        }

        // POST: Cart/DeleteCart
        [HttpPost]
        public JsonResult DeleteCart(CartDTO cartDTO)
        {
            if (!ModelState.IsValid)
            {
                Response.StatusCode = 400;
                return Json(new { }, JsonRequestBehavior.AllowGet);
            }

            Cart sc = new Cart();
            sc.CustomerID = cartDTO.CustomerID;

            using (NorthwndEntities db = new NorthwndEntities())
            {
                Cart cart = db.Carts.SingleOrDefault(c => c.ProductID == cartDTO.ProductID 
                                                        && c.CustomerID == cartDTO.CustomerID);
                if (cart != null)
                {
					// cart exists
					db.Carts.Remove(cart);
                }

                db.SaveChanges();
                return Json(sc, JsonRequestBehavior.AllowGet);
            }
        }

        // POST: Cart/ClearCart
        [HttpPost]
        public JsonResult ClearCart(CartDTO cartDTO)
        {
            if (!ModelState.IsValid)
            {
                Response.StatusCode = 400;
                return Json(new { }, JsonRequestBehavior.AllowGet);
            }

            Cart sc = new Cart();
            sc.CustomerID = cartDTO.CustomerID;

            using (NorthwndEntities db = new NorthwndEntities())
            {
                List<Cart> carts = db.Carts.Where(c => c.CustomerID == cartDTO.CustomerID).ToList();
                if (carts != null)
                {
					foreach (Cart c in carts)
						db.Carts.Remove(c);
                }

                db.SaveChanges();
                return Json(sc, JsonRequestBehavior.AllowGet);
            }
        }

        // POST: Cart/EditCart
        [HttpPost]
        public JsonResult EditCart(CartDTO cartDTO)
        {
            if (!ModelState.IsValid)
            {
                Response.StatusCode = 400;
                return Json(new { }, JsonRequestBehavior.AllowGet);
            }

            Cart sc = new Cart();
            sc.CustomerID = cartDTO.CustomerID;

            using (NorthwndEntities db = new NorthwndEntities())
            {
                Cart cart = db.Carts.SingleOrDefault(c => c.ProductID == cartDTO.ProductID 
                                                        && c.CustomerID == cartDTO.CustomerID);
                if (cart != null)
                {
                    // cart exists
                    cart.Quantity = cartDTO.Quantity;
                }

                db.SaveChanges();
                return Json(sc, JsonRequestBehavior.AllowGet);
            }
        }

		// POST: Cart/ViewCart
		[HttpPost]
		public JsonResult ViewCart(CartDTO cartDTO)
		{
			Cart sc = new Cart();
			sc.CustomerID = cartDTO.CustomerID;

			using (NorthwndEntities db = new NorthwndEntities())
			{
				var carts = db.Carts.Where(c => c.CustomerID == cartDTO.CustomerID)
					.Join(db.Products, c => c.ProductID, p => p.ProductID, 
					(c, p) => new
					{
						c.Quantity,
						c.ProductID,
						p.ProductName
					}).ToList();

				return Json(carts, JsonRequestBehavior.AllowGet);
			}
		}

		public ActionResult ViewCart()
		{
			return View();
		}
	}
}