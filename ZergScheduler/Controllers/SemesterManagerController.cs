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
    [Authorize(Roles="Administrator")]
    public class SemesterManagerController : Controller
    {
        //Zerg Scheduler database
        ZergRushEntities db = new ZergRushEntities();

        //Returns a View of a list of all semesters in the database and shows the current semester
        public ActionResult Index()
        {
            var semesters = from s in db.Semesters
                            select s;
            var viewModel = new SemesterIndexViewModel{
                Semesters = semesters.ToList(),
                Current = db.Current_Semester.First()
            };

            return View(viewModel);
        }

        //Returns a blank form for which can be filled to create a semester
        public ActionResult Create()
        {   
            return View();
        }

        //Creates the semester with the values entered in the form. There are numerous
        //steps for error checking and client/server data validation.
        [HttpPost]
        public ActionResult Create(Semester newSemester, FormCollection collection)
        {
            try
            {

                Boolean error = false;
                if (ModelState.IsValid)
                {
                    ViewData["SemesterVal"] = "";
                    ViewData["RegVal"] = "";
                    ViewData["StartVal"] = "";

                    newSemester.semester_id = collection["sem_id"] + collection["sem_year"];

                    //check strat and registration dates for validity
                    if(db.Semesters.Any(a => a.semester_id == newSemester.semester_id))
                    {
                        error = true;
                        ViewData["SemesterVal"] = "Semester ID must be unique.";
                    }
                    
                    if (newSemester.start_date.CompareTo(newSemester.drop_date) >= 0 ||
                        newSemester.start_date.CompareTo(newSemester.withdraw_date) >= 0 ||
                        newSemester.start_date.CompareTo(newSemester.reg_start_date) <= 0)
                    {
                        //report error if start date is invalid
                        error = true;
                        ViewData["StartVal"]= "Start date must come after the registration date and before drop and withdraw dates.";
                    }

                    if (newSemester.reg_start_date.CompareTo(newSemester.drop_date) >= 0 ||
                        newSemester.reg_start_date.CompareTo(newSemester.withdraw_date) >= 0 ||
                        newSemester.reg_start_date.CompareTo(newSemester.start_date) >= 0)
                    {
                        //report error if registration date is invalid
                        error = true;
                        ViewData["RegVal"] = "Registration date must come before all other dates.";
                    }

                    if (error == true)
                    {
                        //return view again if there was an error
                        return View(newSemester);
                    }

                    //add semester to database and save
                    db.AddToSemesters(newSemester);
                    db.SaveChanges();

                    //return to index
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(newSemester);
                }
            }
            catch (Exception ex)
            {
                return View(newSemester);
            }
        }

        //Returns a form with the selected semester's data, which can be edited by the user.
        public ActionResult Edit(String id)
        {
            Semester semester = db.Semesters.Single(a => a.semester_id == id);

            return View(semester);
        }


        //Edited semester information is saved to the database.
        [HttpPost]
        public ActionResult Edit(String id, FormCollection formValues)
        {
            Semester semester = db.Semesters.Single(a => a.semester_id == id);
            Boolean error = false;
            ViewData["RegVal"] = "";
            ViewData["StartVal"] = "";

            try
            {
                UpdateModel(semester);

                //check strat and registration dates for validity
                if (semester.start_date.CompareTo(semester.drop_date) >= 0 ||
                    semester.start_date.CompareTo(semester.withdraw_date) >= 0 ||
                    semester.start_date.CompareTo(semester.reg_start_date) <= 0)
                {
                    error = true;
                    ViewData["StartVal"] = "Start date must come after the registration date and before drop and withdraw dates.";
                }

                if (semester.reg_start_date.CompareTo(semester.drop_date) >= 0 ||
                    semester.reg_start_date.CompareTo(semester.withdraw_date) >= 0 ||
                    semester.reg_start_date.CompareTo(semester.start_date) >= 0)
                {
                    error = true;
                    ViewData["RegVal"] = "Registration date must come before all other dates.";
                }

                if (error == true)
                {
                    return View(semester);
                }

                //Save Semester
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                //Error occurred – so redisplay the form

                return View(semester);
            }
        }

        //Returns a detailed list of the semester information.
        public ActionResult Details(String id)
        {
            Semester semester = db.Semesters.Single(a => a.semester_id == id);

            return View(semester);
        }

        //Presents a page confirming that the user does indeed wish to delete the semester.
        public ActionResult Delete(String id)
        {
            Semester semester = db.Semesters.Single(a => a.semester_id == id);

            return View(semester);
        }

        //Deletes the semester from the database if it does not have any current classes attached. Returns a view
        //that confirms whether or not the semester was/could be deleted.
        [HttpPost]
        public ActionResult Delete(String id, string confirmButton)
        {
            var semester = db.Semesters.Single(a => a.semester_id == id);
            if (db.Classes.Any(c => c.semster_id == semester.semester_id))
            {
                ViewData["Message"] = "Semester " + semester.semester_id + " could not be deleted because there are classes associated with it.";
            }
            else
            {
                ViewData["Message"] = "Semester " + id + " was successfully deleted.";
                db.DeleteObject(semester);
                db.SaveChanges();
            }

            return View("Deleted");
        }

        //Returns a view that allows the user to set the current semester.
        public ActionResult EditCurrent()
        {
            var viewModel = new SemesterIndexViewModel
            {
                Semesters = db.Semesters.ToList(),
                Current = db.Current_Semester.First()
            };

            return View(viewModel);
        }

        //Saves the selected semester as the current semester in the database.
        [HttpPost]
        public ActionResult EditCurrent(FormCollection collection)
        {
            db.SetCurrentSemester(collection["sem_list"]);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }

}
