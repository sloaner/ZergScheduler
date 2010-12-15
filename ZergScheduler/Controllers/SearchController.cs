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
		ZergRushEntities db = new ZergRushEntities();

		// GET: /Search/
		public ActionResult Index()
		{
			var viewModel = new SearchViewModel
			{
				Class = new Class(),
				Course = new Course(),
				Departments = db.Departments.ToList(),
				GFRs = db.GFRs.ToList(),
				GEPs = db.GEPs.ToList(),
				Semesters = db.Semesters.ToList(),
				CurrentSemester = db.Current_Semester.First().semester_id
			};
			return View(viewModel);
		}

		[HttpPost]
		public ActionResult Index(FormCollection fc)
		{
			return View();
		}
		
		public ActionResult SingleClassFilter(int class_id, string semester_id)
		{
			var courses = from course in db.Courses
						  where course.Classes.Any(c => c.class_id == class_id && c.semster_id == semester_id)
						  select course;

			ViewData["semester"] = semester_id;
			ViewData["filter_class_id"] = true;
			ViewData["class_id"] = class_id;
			return View("ClassFilter", courses);
		}

		public ActionResult ClassFilter(FormCollection collection)
		{
			var comp_list = "<=>";
			var semester_id = collection["semester_id"] ?? "SP11";
			var depts = (collection["dept_id"] ?? "").Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
			var course_no_comp = comp_list.IndexOf(collection["course_no_comp"]) - 1;
			var course_no = collection["Course.course_no"] ?? "";

			var class_id = int.Parse("0" + collection["Class.class_id"]);
			var credits = int.Parse("0" + collection["Course.credits"]);
			var keyword = collection["keyword"] ?? "";
			var gfrs = (collection["gfrs"] ?? "0").Split(',').Sum(x => Int32.Parse(x));
			var geps = (collection["geps"] ?? "0").Split(',').Sum(x => Int32.Parse(x));

			var start_time_comp = comp_list.IndexOf(collection["start_time_comp"]) - 1;
			var start_time = DateTime.Parse("1/1/1900 " + (collection["Class.Timeslot.start_time"] ?? "0:00"));
			var end_time_comp = comp_list.IndexOf(collection["end_time_comp"]) - 1;
			var end_time = DateTime.Parse("1/1/1900 " + (collection["Class.Timeslot.end_time"] ?? "0:00"));
			var date_zero = DateTime.Parse("1/1/1900 0:00");
						
			var show_open = collection["show_open"].Contains("true");
			var show_offered = collection["show_offered"].Contains("true");
			var courses = from course in db.Courses
						  where (depts.Count() < 1 || depts.Contains(course.dept_id))
						  && (course_no == "" || course.course_no.CompareTo(course_no) == course_no_comp)
						  && (!show_offered || course.Classes.Any(c => c.semster_id == semester_id))
						  && (class_id == 0 || course.Classes.Any(c => c.class_id == class_id))
						  && (credits == 0 || course.credits == credits)
						  && (keyword == "" || course.description.Contains(keyword) || course.title.Contains(keyword))
						  && (gfrs == 0 || (course.gfr & gfrs) != 0)
						  && (geps == 0 || (course.gep & geps) != 0)
						  && (start_time == date_zero || course.Classes.Any(c => c.Timeslot.start_time.CompareTo(start_time) == start_time_comp))
						  && (end_time == date_zero || course.Classes.Any(c => c.Timeslot.end_time.CompareTo(end_time) == end_time_comp))
						  select course;

			ViewData["semester"] = semester_id;
			ViewData["filter_class_id"] = (class_id == 0);
			ViewData["class_id"] = class_id;
			ViewData["start_time"] = start_time;
			ViewData["end_time"] = end_time;
			return PartialView(courses.AsEnumerable());
		}
	}
}
