using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZergScheduler.Models;
using ZergScheduler.ViewModels;

namespace ZergScheduler.Controllers
{
	public class ScheduleController : Controller
	{
		ZergRushEntities db;
		String semester;

		public ScheduleController()
		{
			db = new ZergRushEntities();
			semester = db.Current_Semester.First().semester_id.ToString();
		}

		//
		// GET: /Schedule/
		public ActionResult Index()
		{
			var student = db.Users.Single(s => s.user_id == User.Identity.Name);
			var classes = student.Takes.Select(c => c.Class).Distinct().ToList();
			var semesters = student.Takes.Select(s => s.Class.Semester).Distinct().ToList();
			ViewData["Semesters"] = semesters;
			var viewModel = new ScheduleIndexViewModel()
			{
				Semesters = semesters,
				Classes = classes
			};
			return View(viewModel);
		}

		public ActionResult partIndex(FormCollection collection)
		{
			var curr_sem = db.Current_Semester.First().semester_id;
			var sem = collection["semester_id"] ?? curr_sem;
			ViewData["id"] = sem;
			semester = sem;
			var student = db.Users.Single(s => s.user_id == User.Identity.Name);
			var classes = student.Takes.Select(c => c.Class).Distinct().ToList();
			var filter = classes.Where(f => f.semster_id == sem);

			return PartialView(filter);
		}

		[HttpPost]
		public ActionResult updateCalendar(string semester_id)
		{
			var student = db.Users.SingleOrDefault(s => s.user_id == User.Identity.Name);
			if (student == null || string.IsNullOrWhiteSpace(semester_id)) return Json(null);

			var semester_start_date = db.Semesters.SingleOrDefault(s => s.semester_id == semester_id).start_date.Date;
			student.Takes.Select(c => c.Class).Distinct().ToList();
			var classes = from t in student.Takes
						  where t.semester_id == semester_id
						  select new
						  {
							  c = t.Class,
							  days = t.Class.days
						  };

			var allClasses = new List<dynamic>();

			foreach (var item in classes) {
				if (item.days != null) {
					int d = item.days.Value;
					for (int i = 32; i > 0; i /= 2) {
						if ((d & i) != 0) {
							allClasses.Add(new
							{
								title = item.c.course_id,
								start = semester_start_date.Add(item.c.Timeslot.start_time.TimeOfDay).AddDays(5 - Math.Log(i, 2)).ToString(),
								end = semester_start_date.Add(item.c.Timeslot.end_time.TimeOfDay).AddDays(5 - Math.Log(i, 2)).ToString()
							});
						}
					}
				}
			}

			var json = new { start = semester_start_date.ToString(), events = allClasses.ToArray() };
			return Json(json);
		}


		public ActionResult Calendar(String id)
		{
			semester = id;
			ViewData["start_date"] = db.Semesters.Where(s => s.semester_id == id).First().start_date.ToString();
			return View();
		}


		public ActionResult Data()
		{
			var student = db.Users.Single(s => s.user_id == User.Identity.Name);
			var classes = student.Takes.Select(c => c.Class).Distinct().ToList();
			var filter = classes.Where(f => f.semster_id == semester);

			var events = new EventViewModel[] {
                new EventViewModel { id = 1, text = "CMSC100", start_date = new DateTime(2010, 12, 13, 13, 30, 0), end_date = new DateTime(2010, 12, 13, 14, 45, 0) },
                new EventViewModel { id = 2, text = "CMSC100", start_date = new DateTime(2010, 12, 15, 13, 30, 0), end_date = new DateTime(2010, 12, 15, 14, 45, 0) }, 
                new EventViewModel { id = 3, text = "CMSC104", start_date = new DateTime(2010, 12, 16, 16, 0, 0), end_date = new DateTime(2010, 12, 16, 17, 15, 0) },
                new EventViewModel { id = 4, text = "CMSC104", start_date = new DateTime(2010, 12, 14, 16, 0, 0), end_date = new DateTime(2010, 12, 14, 17, 15, 0) }
            };

			return View(events);
		}

		[HttpPost]
		public ActionResult Drop(int class_id, String semester_id)
		{
			var student = db.Takes.Single(t => t.student_id == User.Identity.Name && t.class_id == class_id && t.semester_id == semester_id);
			if (student != null) {
				db.Takes.DeleteObject(student);
				db.SaveChanges();
			}
			return Json(class_id);
		}
	}
}
