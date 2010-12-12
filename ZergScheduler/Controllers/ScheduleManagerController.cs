using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZergScheduler.Models;

namespace ZergScheduler.Controllers
{
	[Authorize(Roles="Student")]
    public class ScheduleManagerController : Controller
    {
        //
        // GET: /ScheduleManager/

        public ActionResult Index()
        {
            return View();
        }

		public ActionResult Register(Class add)
		{

			return View();
		}

    }
}
