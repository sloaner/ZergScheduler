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
    public class GradeController : Controller
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

            //create dictionary of students in each class
            Dictionary<int, List<Take>> roster = buildDictionary(classes);

            //pass data to View
            var viewModel = new TeacherViewModel()
            {
                classes = classes.ToList(),
                roster = roster
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
            foreach (String id in formValues.Keys)
            {
                int class_id = Convert.ToInt32(id.Split('/')[0]);
                String student_id = id.Split('/')[1];

                try
                {
                    int new_grade = Convert.ToInt32(formValues[id]);
                    if (new_grade < 0 || new_grade > 100) { throw new Exception(); }
                    db.Takes.First(a => a.class_id == class_id && a.student_id == student_id && a.semester_id == semester).grade =
                        new_grade;
                } catch { }
            }
            db.SaveChanges();

            return RedirectToAction("Index");
            
        }
        
        protected List<Class> getClasses(string inst_id, string semester_id)
        {
            var classes = from c in db.Classes
                          where c.inst_id == inst_id && c.semster_id == semester_id
                          select c;
            return classes.ToList();
        }

        private Dictionary<int, List<Take>> buildDictionary(List<Class> classes)
        {
            Dictionary<int, List<Take>> roster = new Dictionary<int, List<Take>>();
            foreach (Class c in classes) { roster.Add(c.class_id, new List<Take>()); }

            //find students in the teacher's classes and add them to the appropriate list
            foreach (Take t in db.Takes)
            {
                if (classes.Any(a => a.class_id == t.class_id && a.semster_id == t.semester_id)) roster[t.class_id].Add(t);
            }

            return roster;
        }

        private int AddInts(int a, int b) { return a + b; }
    }
}
