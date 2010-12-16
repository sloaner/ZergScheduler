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
            ViewData["Semesters"] = student.Takes.Select(s => s.Class.Semester).Distinct().ToList();
            return View(classes);
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
            if(student != null)
            {
                db.Takes.DeleteObject(student);
                db.SaveChanges();
            }
            return Json(class_id);
        }
    }
}
