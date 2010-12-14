using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZergScheduler.Models;
using ZergScheduler.ViewModels;

namespace ZergScheduler.Controllers
{
    [Authorize(Roles = "Student")]
    public class ScheduleManagerController : Controller
    {
        ZergRushEntities db = new ZergRushEntities();

        public ActionResult Index()
        {
            return View();
        }

		public ActionResult Register()
		{
			var cart = ShoppingCart.GetCart(this.HttpContext);

			return View(cart.GetCartItems());
		}

        [HttpPost]
        public void Register(FormCollection collection)
        {
			var cart = ShoppingCart.GetCart(this.HttpContext);
			List<Cart> classes = cart.GetCartItems();

			foreach (var item in classes) {
				if ((collection["check-" + item.record_id] ?? "false").Contains("true")) {
					//db.RegisterForClass(User.Identity.Name, item.class_id, item.semester_id, false);
				}
			}
        }

    }
}
