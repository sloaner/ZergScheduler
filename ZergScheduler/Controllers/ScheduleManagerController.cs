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
					string class_info = string.Format("{0}-{1:00} ({2})", item.Class.course_id, item.Class.sect_id, item.class_id);
					if (db.Takes.Any(t => t.student_id == User.Identity.Name && t.Class.course_id == item.Class.course_id && t.semester_id == item.semester_id)) {
						regs.Add(new RegistrationViewModel() { class_info = class_info, successful = "error", message = "You are already registered for that course." });
					} else if (item.Class.Takes.Count(t => !t.waitlist_status) >= item.Class.capacity) {
						if (item.Class.Takes.Count(t => t.waitlist_status) >= item.Class.waitlist_capacity) {
							regs.Add(new RegistrationViewModel() { class_info = class_info, successful = "error", message = "Class is full." });
						} else {
							db.RegisterForClass(User.Identity.Name, item.class_id, item.semester_id, true);
							regs.Add(new RegistrationViewModel() { class_info = class_info, successful = "warning", message = "Added to the waitlist." });
						}
					} else if (db.Takes.Any(t => t.student_id == User.Identity.Name && t.semester_id == item.semester_id && ((t.Class.days ^ item.Class.days) != t.Class.days) && ((t.Class.Timeslot.start_time <= item.Class.Timeslot.start_time && t.Class.Timeslot.end_time > item.Class.Timeslot.start_time) || (item.Class.Timeslot.start_time <= t.Class.Timeslot.start_time && item.Class.Timeslot.end_time > t.Class.Timeslot.start_time)))) {
						regs.Add(new RegistrationViewModel() { class_info = class_info, successful = "error", message = "This course conflicts with another course." });
					} else if (!prereqsSatisfied(item)) {
						regs.Add(new RegistrationViewModel() { class_info = class_info, successful = "error", message = "Some prerequisites are not satisfied." });
					} else {
						db.RegisterForClass(User.Identity.Name, item.class_id, item.semester_id, false);
						regs.Add(new RegistrationViewModel() { class_info = class_info, successful = "success", message = "Registered successfully." });
					}
					cart.RemoveFromCart(item.record_id);
				}
			}
			return View("Complete", regs);
		}

		private bool prereqsSatisfied(Cart item)
		{
			var student = db.Users.SingleOrDefault(s=>s.user_id==User.Identity.Name);
			return item.Class.Course.Prereqs.All(c => student.Takes.Any(t => t.Class.course_id == c.course_id));
			//return db.Takes.Any(t => t.student_id == User.Identity.Name && t.semester_id == item.semester_id && ((t.Class.days ^ item.Class.days) != 0) && !checkForOverlap(t.Class.Timeslot, item.Class.Timeslot));
			//return true;
		}

		private bool checkForOverlap(Timeslot ts1, Timeslot ts2)
		{
			return (ts1.start_time <= ts2.start_time && ts1.end_time > ts2.start_time) || (ts2.start_time <= ts1.start_time && ts2.end_time > ts1.start_time);
		}
	}
}
