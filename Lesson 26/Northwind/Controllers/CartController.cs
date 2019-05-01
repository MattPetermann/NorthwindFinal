﻿using System.Collections.Generic;
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

		// POST: Cart/ViewCart
		[HttpPost]
		public JsonResult ViewCart(CartDTO cartDTO)
		{
			Cart sc = new Cart();
			sc.CustomerID = cartDTO.CustomerID;

			using (NorthwndEntities db = new NorthwndEntities())
			{
				var carts = db.Carts.Where(c => c.CustomerID == cartDTO.CustomerID).Select(
					c => new
					{
						//Change to qty and product id vs product table
						c.CustomerID,
						c.CartID
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