using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZergScheduler.Models;
using ZergScheduler.ViewModels;

namespace ZergScheduler.Controllers
{
	public class ShoppingCartController : Controller
	{
		ZergRushEntities db = new ZergRushEntities();

		public ActionResult Index()
		{
			var cart = ShoppingCart.GetCart(this.HttpContext);
			var viewModel = new ShoppingCartViewModel
			{
				CartItems = cart.GetCartItems(),
				CartCount = cart.GetCount()
			};
			return View(viewModel);
		}

		[HttpPost]
		public ActionResult AddToCart(int class_id, string semester_id)
		{
			var addedClass = db.Classes.Single(c => c.class_id == class_id && c.semster_id == semester_id);
			var cart = ShoppingCart.GetCart(this.HttpContext);
			cart.AddToCart(addedClass);

			var results = new ShoppingCartAlterViewModel
			{
				Message = Server.HtmlEncode(addedClass.course_id) + " has been added to your cart.",
				CartCount = cart.GetCount(),
				AlterId = class_id,
				AlterSemester = semester_id
			};
			return Json(results);
		}

		[HttpPost]
		public ActionResult RemoveFromCart(int id)
		{
			var cart = ShoppingCart.GetCart(this.HttpContext);

			string course_id = db.Carts.Single(item => item.record_id == id).Class.course_id;

			cart.RemoveFromCart(id);

			var results = new ShoppingCartAlterViewModel
			{
				Message = Server.HtmlEncode(course_id) + " has been removed from your cart.",
				CartCount = cart.GetCount(),
				AlterId = id
			};

			return Json(results);
		}

		[ChildActionOnly]
		public ActionResult CartSummary()
		{
			var cart = ShoppingCart.GetCart(this.HttpContext);
			ViewData["CartCount"] = cart.GetCount();
			return PartialView("CartSummary");
		}
	}
}
