using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZergScheduler.Models;

namespace ZergScheduler.ViewModels
{
    public class SemesterIndexViewModel
    {
        public List<Semester> Semesters { get; set; }
        public Current_Semester Current { get; set; }
    }
}