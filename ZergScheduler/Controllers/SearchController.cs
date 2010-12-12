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
				Semesters = courseDB.Semesters.ToList(),
				CurrentSemester = courseDB.Current_Semester.First().semester_id
			};
			return View(viewModel);
		}

		[HttpPost]
		public ActionResult Index(FormCollection fc)
		{
			return View();
		}

		public ActionResult ClassFilter(FormCollection collection)
		{
			var semester_id = collection["semester_id"] ?? "SP11";
			var depts = (collection["dept_id"] ?? "").Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
			var course_no = collection["Course.course_no"] ?? "";

			var credits = 0;// int.Parse(collection["Course.credits"] ?? "0");
			var gfrs = (collection["gfrs"] ?? "0").Split(',').Sum(x => Int32.Parse(x));
			var geps = (collection["geps"] ?? "0").Split(',').Sum(x => Int32.Parse(x));

			var start_time_comp = (collection["start_time_comp"] ?? "<");
			var start_time = DateTime.Parse(collection["Course.Timeslot.start_time"] ?? "0:00");
			var end_time_comp = (collection["end_time_comp"] ?? "<");
			var end_time = DateTime.Parse(collection["Course.Timeslot.end_time"] ?? "0:00");

			var show_open = collection["show_open"].Contains("true");
			var show_offered = collection["show_offered"].Contains("true");

			var courses = from course in courseDB.Courses
						  where (depts.Count() < 1 || depts.Contains(course.dept_id))
						  && (course_no == "" || course.description.Contains(course_no))
						  && (!show_offered || course.Classes.Any(c => c.semster_id == semester_id))
						  && (credits == 0 || course.credits == credits)
						  && (gfrs == 0 || (course.gfr & gfrs) != 0)
						  && (geps == 0 || (course.gep & geps) != 0)
						  //&& (course.Classes.Any(c => c.Timeslot.start_time.CompareTo(
						  select course;

			ViewData["semester"] = semester_id;
			return PartialView(courses.AsEnumerable());
		}
	}
}
