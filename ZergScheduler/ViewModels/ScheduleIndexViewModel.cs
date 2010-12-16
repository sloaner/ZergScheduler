using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZergScheduler.Models;

namespace ZergScheduler.ViewModels
{
    public class ScheduleIndexViewModel
    {
        //public List<System.Web.Mvc.SelectListItem> Items {get; set;}
        //public List<Semester> Semesters { get; set; }
        public List<Class> Courses { get; set; }
    }
}
