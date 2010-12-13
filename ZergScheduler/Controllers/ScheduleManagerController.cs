using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZergScheduler.Models;

namespace ZergScheduler.Controllers
{
	[Authorize(Roles = "Student")]
	public class ScheduleManagerController : Controller
	{
		ZergRushEntities courseDB = new ZergRushEntities();

		public ActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Register(Class reg_class)
		{
			if (reg_class != null)
				courseDB.RegisterForClass(User.Identity.Name, reg_class.class_id, reg_class.semster_id, false);
			return View();
		}

	}
}
