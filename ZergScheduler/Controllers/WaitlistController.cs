using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZergScheduler.Models;
using ZergScheduler.ViewModels;

namespace ZergScheduler.Controllers
{
    [Authorize(Roles="Instructor")]
    public class WaitlistController : Controller
    {
        ZergRushEntities db = new ZergRushEntities();

        public ActionResult Index()
        {
            //get the user's id
            String inst_id = User.Identity.Name;

            //get the current semester
            //String semester = db.Current_Semester
            String semester = "SP11";

            //get the teacher's classes
            var classes = getClasses(inst_id, semester);

            //get students on teacher's waitlists
            Dictionary<int, List<Take>> waitlist = buildDictionary(classes.ToList());

            //pass data to View
            var viewModel = new TeacherViewModel()
            {
                classes = classes.ToList(),
                roster = waitlist
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Index(FormCollection formValues)
        {
            formValues.Remove(formValues.Keys[0]);

            //get the current semester
            //String semester = db.Current_Semester
            String semester = "SP11";

            //update the database
            foreach (String key in formValues.Keys)
            {
                if (formValues[key].Contains("true"))
                {
                    int class_id = Convert.ToInt32(key.Split('/')[0]);
                    String student_id = key.Split('/')[1];
                    try
                    {
                        db.Takes.First(a => a.class_id == class_id && a.student_id == student_id && a.semester_id == semester).waitlist_status = false;
                    }
                    catch { }
                }
            }
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        private List<Class> getClasses(string inst_id, string semester_id)
        {
            var classes = from c in db.Classes
                          where c.inst_id == inst_id && c.semster_id == semester_id
                          select c;
            return classes.ToList();
        }

        private Dictionary<int, List<Take>> buildDictionary(List<Class> classes)
        {
            Dictionary<int, List<Take>> list = new Dictionary<int, List<Take>>();
            foreach (Class c in classes)
            {
                list.Add(c.class_id, new List<Take>());
            }

            foreach (Take t in db.Takes)
            {
                if (classes.Any(a => a.class_id == t.class_id && a.semster_id == t.semester_id) && t.waitlist_status) list[t.class_id].Add(t);
            }

            return list;
        }

    }
}
