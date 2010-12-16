using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZergScheduler.Models;
using ZergScheduler.ViewModels;

namespace ZergScheduler.Controllers
{
    [Authorize(Roles="Student")]
    public class HistoryController : Controller
    {
        //
        // GET: /History/
        ZergRushEntities db = new ZergRushEntities();

        public ActionResult Index()
        {
            
            var student = db.Users.Single(s => s.user_id == User.Identity.Name);

            var history = from h in student.Takes
                          select h;

            return View(history.ToList());
        }
    }
}
