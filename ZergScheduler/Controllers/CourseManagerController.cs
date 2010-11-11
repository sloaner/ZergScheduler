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
			return View();
		}

		// POST: /CourseManager/Create
		[HttpPost]
		public ActionResult Create(FormCollection collection)
		{
			try
			{
				// TODO: Add insert logic here

				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
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
				collection["gfr"] = collection["gfr"].Split(',').Sum(x => Int32.Parse(x)) + "";
				collection["gep"] = collection["gep"].Split(',').Sum(x => Int32.Parse(x)) + "";
				UpdateModel(course,collection.ToValueProvider());
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
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: /CourseManager/Delete/5
		[HttpPost]
		public ActionResult Delete(int id, FormCollection collection)
		{
			try
			{
				// TODO: Add delete logic here

				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}
	}
}
