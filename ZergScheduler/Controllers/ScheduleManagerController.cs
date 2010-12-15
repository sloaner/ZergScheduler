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
		public ActionResult Register(FormCollection collection)
		{
			var cart = ShoppingCart.GetCart(this.HttpContext);
			List<Cart> classes = cart.GetCartItems();
			List<RegistrationViewModel> regs = new List<RegistrationViewModel>();

			foreach (var item in classes) {
				if ((collection["check-" + item.record_id] ?? "false").Contains("true")) {
					if (db.Takes.Any(t => t.student_id == User.Identity.Name && t.Class.course_id == item.Class.course_id && t.semester_id == item.semester_id)) {
						regs.Add(new RegistrationViewModel() { cart_item = item, successful = "error", message = "You are already registered for that course." });
					} else if (item.Class.Takes.Count(t => !t.waitlist_status) >= item.Class.capacity) {
						if (item.Class.Takes.Count(t => t.waitlist_status) >= item.Class.waitlist_capacity) {
							regs.Add(new RegistrationViewModel() { cart_item = item, successful = "error", message = "Class is full." });
						} else {
							db.RegisterForClass(User.Identity.Name, item.class_id, item.semester_id, true);
							regs.Add(new RegistrationViewModel() { cart_item = item, successful = "warning", message = "Added to the waitlist." });
						}
					} else {
						db.RegisterForClass(User.Identity.Name, item.class_id, item.semester_id, false);
						regs.Add(new RegistrationViewModel() { cart_item = item, successful = "success", message = "Registered successfully." });
					}
					cart.RemoveFromCart(item.record_id);
				}
			}
			return RedirectToAction("Complete", regs);
		}

		public ActionResult Complete(IEnumerable<RegistrationViewModel> regs)
		{
			return View(regs);
		}
	}
}
