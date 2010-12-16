using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZergScheduler.Models;
using ZergScheduler.ViewModels;

//by Alex Nathan
namespace ZergScheduler.Controllers
{
    [Authorize(Roles="Administrator")]    //only accessable by administrators
    public class ClassManagerController : Controller
    {
        ZergRushEntities db = new ZergRushEntities();


        //Index of Class Manager
        public ActionResult Index()
        {

            var viewModel = new ClassManagerIndexViewModel
            {
                Semesters = db.Semesters.ToList(),
                Classes = db.Classes.ToList()
            };


            return View(viewModel);
        }

        //Partial index that returns list of classes
        public ActionResult partIndex(FormCollection collection)
        {
            var sem = collection["sem_list"] ?? "";


                var viewModel = new ClassManagerIndexViewModel
                {
                    Semesters = db.Semesters.ToList(),
                    Classes = db.Classes.Where(c => sem == "" || c.semster_id == sem).ToList()
                };

            return PartialView(viewModel);
        }

        //Create a class
        public ActionResult Create()
        {
            //only allow classes to be created for current semester or later
            var cur = db.Semesters.Single(s => s.semester_id == db.Current_Semester.FirstOrDefault().semester_id);
           
            var viewModel = new ClassManagerCreateViewModel
            {
                Semesters = db.Semesters.Where(c=> c.start_date.CompareTo(cur.start_date) >= 0).ToList(),
                Classes = new Class(),
                Times = db.Timeslots.ToList(),
                Courses = db.Courses.ToList(),
                Depts = db.Departments.ToList(),
                Users = db.Users.Where(u => u.Role_Type.Any(r=>r.role_name == "Instructor")).OrderBy(u=> u.last_name).ToList()
            };

            return View(viewModel);
        }

        //Save a class to the database
        [HttpPost]
        public ActionResult Create(Class newClass, FormCollection collection)
        {
            //error message for section id uniqueness
            ViewData["IDerror"] = "";

            try
            {
                newClass.semster_id = collection["sem_list"];
                newClass.course_id = collection["course_list"];
                newClass.sect_id = int.Parse(collection["Classes.sect_id"]?? "0");
                newClass.room_id = collection["Classes.room_id"];
                newClass.inst_id = collection["inst_list"];
                newClass.capacity = int.Parse(collection["Classes.capacity"]);
                newClass.waitlist_capacity = int.Parse(collection["Classes.waitlist_capacity"]);
                newClass.days = (collection["days_chk"] ?? "0").Split(',').Sum(x => Int32.Parse(x));
                newClass.timeslot_id = int.Parse(collection["time_list"]);
                newClass.has_children = false;
                newClass.parent_class_id = null;

                if (db.Classes.Any(c => c.sect_id == newClass.sect_id && c.semster_id == newClass.semster_id && c.course_id == newClass.course_id))
                {
                    ViewData["IDerror"] = "Section IDs must be unique for each course ID and semester.";
                    throw new Exception();
                }

                //add new class to database and save changes
                db.AddToClasses(newClass);
                db.SaveChanges();

                //return to Index
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                var cur = db.Semesters.Single(s => s.semester_id == db.Current_Semester.FirstOrDefault().semester_id);

                var viewModel = new ClassManagerCreateViewModel
                {
                    Semesters = db.Semesters.Where(c => c.start_date.CompareTo(cur.start_date) >= 0).ToList(),
                    Classes = new Class(),
                    Times = db.Timeslots.ToList(),
                    Courses = db.Courses.ToList(),
                    Depts = db.Departments.ToList(),
                    Users = db.Users.Where(u => u.Role_Type.Any(r => r.role_name == "Instructor")).OrderBy(u => u.last_name).ToList()
                };

                return View(viewModel);
            }
        }

                //Create a class
        public ActionResult Edit(int id)
        {
            var cur = db.Semesters.Single(s => s.semester_id == db.Current_Semester.FirstOrDefault().semester_id);
           
            var viewModel = new ClassManagerCreateViewModel
            {
                Semesters = db.Semesters.Where(c=> c.start_date.CompareTo(cur.start_date) >= 0).ToList(),
                Classes = db.Classes.Single(c=> c.class_id == id),
                Times = db.Timeslots.ToList(),
                Courses = db.Courses.ToList(),
                Depts = db.Departments.ToList(),
                Users = db.Users.Where(u => u.Role_Type.Any(r=>r.role_name == "Instructor")).OrderBy(u=> u.last_name).ToList()
            };

            return View(viewModel);
        }

        //Save an edited class to the database
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            ViewData["IDerror"] = "";
            Class oldClass = db.Classes.Single(c=> c.class_id == id);

            try
            {
                oldClass.semster_id = collection["sem_list"];
                oldClass.course_id = collection["course_list"];
                oldClass.sect_id = int.Parse(collection["Classes.sect_id"] ?? "0");
                oldClass.room_id = collection["Classes.room_id"];
                oldClass.inst_id = collection["inst_list"];
                oldClass.capacity = int.Parse(collection["Classes.capacity"]);
                oldClass.waitlist_capacity = int.Parse(collection["Classes.waitlist_capacity"]);
                oldClass.days = (collection["days_chk"] ?? "0").Split(',').Sum(x => Int32.Parse(x));
                oldClass.timeslot_id = int.Parse(collection["time_list"]);
                oldClass.has_children = false;
                oldClass.parent_class_id = null;

                UpdateModel(oldClass);

                if (db.Classes.Any(c => c.class_id != id && c.sect_id == oldClass.sect_id && c.semster_id == oldClass.semster_id && c.course_id == oldClass.course_id))
                {
                    ViewData["IDerror"] = "Section IDs must be unique for each course ID and semester.";
                    throw new Exception();
                }

                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                var cur = db.Semesters.Single(s => s.semester_id == db.Current_Semester.FirstOrDefault().semester_id);

                var viewModel = new ClassManagerCreateViewModel
                {
                    Semesters = db.Semesters.Where(c => c.start_date.CompareTo(cur.start_date) >= 0).ToList(),
                    Classes = oldClass,
                    Times = db.Timeslots.ToList(),
                    Courses = db.Courses.ToList(),
                    Depts = db.Departments.ToList(),
                    Users = db.Users.Where(u => u.Role_Type.Any(r => r.role_name == "Instructor")).OrderBy(u => u.last_name).ToList()
                };

                return View(viewModel);
            }
        }

        //Presents a page confirming that the user does indeed wish to delete the class.
        public ActionResult Delete(int id)
        {
            Class cl = db.Classes.Single(c => c.class_id == id);

            return View(cl);
        }

        //Deletes the class from the database.
        [HttpPost]
        public ActionResult Delete(int id, string confirmButton)
        {
            var cl = db.Classes.Single(c=> c.class_id == id);

            db.DeleteObject(cl);
            db.SaveChanges();

            return View("Deleted");
        }
    }
}
