using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZergScheduler.ViewModels;
using ZergScheduler.Models;

namespace ZergScheduler.Controllers
{
	public class CourseController : Controller
	{
		ZergRushEntities db = new ZergRushEntities();

		// GET: /Course/
		public ActionResult Index()
		{
			var viewModel = new CourseIndexViewModel
			{
				NumberOfDepartments = db.Departments.Count(),
				Departments = db.Departments.OrderBy(d => d.dept_title).ToList()
			};

			return View(viewModel);
		}

		// GET: /Course/Browse?department=CMSC
		public ActionResult Browse(string dept)
		{
			var departmentModel = db.Departments.Include("Courses").Single(g => g.dept_id == dept);

			var viewModel = new CourseBrowseViewModel
			{
				Department = departmentModel,
				Courses = departmentModel.Courses.ToList()
			};

			return View(viewModel);
		}

		// GET: /Course/Details/CMSC345
		public ActionResult Details(string id)
		{
			var course = db.Courses.Single(a => a.course_id == id);

			return View(course);
		}

		[ChildActionOnly]
		public ActionResult CourseFilter()
		{
			var viewModel = new SearchViewModel
			{
				Class = new Class(),
				Course = new Course(),
				Departments = db.Departments.ToList(),
				GFRs = db.GFRs.ToList(),
				GEPs = db.GEPs.ToList(),
				Semesters = db.Semesters.ToList()
			};
			return View(viewModel);
		}
	}
}
