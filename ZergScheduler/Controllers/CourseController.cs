using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZergScheduler.ViewModels;

namespace ZergScheduler.Controllers
{
	public class CourseController : Controller
	{
		//
		// GET: /Course/
		public ActionResult Index()
		{
			// Create a list of genres
			var departments = new List<string> { "CMSC", "CHEM", "DANC", "ARCH", "CMPE" };

			// Create our view model
			var viewModel = new CourseIndexViewModel
			{
				NumberOfDepartments = departments.Count(),
				Departments = departments
			};

			return View(viewModel);
		}

		//
		// GET: /Course/Browse?department=CMSC
		public string Browse(string department)
		{
			return HttpUtility.HtmlEncode("Course.Browse, Department = " + department);
		}

		//
		// GET: /Course/Details/CMSC345
		public string Details(string id)
		{
			return "Course.Details, ID = " + id;
		}
	}
}
