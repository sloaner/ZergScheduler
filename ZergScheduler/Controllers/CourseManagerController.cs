using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZergScheduler.Models;
using ZergScheduler.ViewModels;

namespace ZergScheduler.Controllers
{
	public class CourseManagerController : Controller
	{
		ZergRushEntities courseDB = new ZergRushEntities();

		// GET: /CourseManager/
		public ActionResult Index()
		{
			var courses = courseDB.Courses.Include("Department").ToList();

			return View(courses);
		}

		// GET: /CourseManager/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}

		// GET: /CourseManager/Create
		public ActionResult Create()
		{
			var viewModel = new CourseManagerViewModel
			{
				Course = new Course(),
				Departments = courseDB.Departments.ToList(),
				GFRs = courseDB.GFRs.ToList(),
				GEPs = courseDB.GEPs.ToList()
			};

			return View(viewModel);
		}

		// POST: /CourseManager/Create
		[HttpPost]
		public ActionResult Create(Course course, FormCollection collection)
		{
			if (ModelState.IsValid)
			{
				course.course_id = course.dept_id + course.course_no;
				course.gfr = (collection["Course.gfr"] ?? "0").Split(',').Sum(x => Int32.Parse(x));
				course.gep = (collection["Course.gep"] ?? "0").Split(',').Sum(x => Int32.Parse(x));
				courseDB.AddToCourses(course);
				courseDB.SaveChanges();

				return RedirectToAction("Index");
			}

			// Invalid – redisplay with errors
			var viewModel = new CourseManagerViewModel
			{
				Course = course,
				Departments = courseDB.Departments.ToList(),
				GFRs = courseDB.GFRs.ToList(),
				GEPs = courseDB.GEPs.ToList()
			};

			return View(viewModel);
		}

		// GET: /CourseManager/Edit/5
		public ActionResult Edit(string id)
		{
			var viewModel = new CourseManagerViewModel
			{
				Course = courseDB.Courses.Single(c => c.course_id == id),
				Departments = courseDB.Departments.ToList(),
				GFRs = courseDB.GFRs.ToList(),
				GEPs = courseDB.GEPs.ToList()

			};

			return View(viewModel);
		}

		// POST: /CourseManager/Edit/5
		[HttpPost]
		public ActionResult Edit(string id, FormCollection collection)
		{
			var course = courseDB.Courses.Single(c => c.course_id == id);
			try
			{
				collection["Course.gfr"] = (collection["Course.gfr"] ?? "0").Split(',').Sum(x => Int32.Parse(x)) + "";
				collection["Course.gep"] = (collection["Course.gep"] ?? "0").Split(',').Sum(x => Int32.Parse(x)) + "";
				//collection["Course.course_id"] = collection["Course.dept_id"] + collection["Course.course_no"];
				UpdateModel(course, "Course", collection.ToValueProvider());
				courseDB.SaveChanges();

				return RedirectToAction("Index");
			}
			catch
			{
				var viewModel = new CourseManagerViewModel
				{
					Course = courseDB.Courses.Single(c => c.course_id == id),
					Departments = courseDB.Departments.ToList(),
					GFRs = courseDB.GFRs.ToList(),
					GEPs = courseDB.GEPs.ToList()
				};

				return View(viewModel);
			}
		}

		// GET: /CourseManager/Delete/5
		public ActionResult Delete(string id)
		{
			var course = courseDB.Courses.Single(c => c.course_id == id);
			return View(course);
		}

		// POST: /CourseManager/Delete/5
		[HttpPost]
		public ActionResult Delete(string id, string confirmButton)
		{
			var course = courseDB.Courses.Single(c => c.course_id == id);

			courseDB.DeleteObject(course);
			courseDB.SaveChanges();

			return View("Deleted");
		}
	}
}
