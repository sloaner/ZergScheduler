using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZergScheduler.ViewModels;
using ZergScheduler.Models;

namespace ZergScheduler.Controllers
{
	public class SearchController : Controller
	{
		ZergRushEntities courseDB = new ZergRushEntities();

		// GET: /Search/
		public ActionResult Index()
		{
			var viewModel = new SearchViewModel
			{
				Class = new Class(),
				Course = new Course(),
				Departments = courseDB.Departments.ToList(),
				GFRs = courseDB.GFRs.ToList(),
				GEPs = courseDB.GEPs.ToList(),
				Semester = courseDB.Semesters.ToList()
			};
			return View(viewModel);
		}

		[HttpPost]
		public ActionResult Index(FormCollection fc)
		{

			return View();
		}

		[ChildActionOnly]
		public ActionResult Browse()
		{
			return View();
		}

		[ChildActionOnly]
		public ActionResult ClassFilter()
		{
			var viewModel = new SearchViewModel
			{
				Class = new Class(),
				Course = new Course(),
				Departments = courseDB.Departments.ToList(),
				GFRs = courseDB.GFRs.ToList(),
				GEPs = courseDB.GEPs.ToList(),
				Semester = courseDB.Semesters.ToList()
			};
			return View(viewModel);
		}
	}
}
