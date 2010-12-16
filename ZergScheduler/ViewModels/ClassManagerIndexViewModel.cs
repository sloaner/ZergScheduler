using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZergScheduler.Models;

namespace ZergScheduler.ViewModels
{
    public class ClassManagerIndexViewModel
    {
        public List<Semester> Semesters { get; set; }
        public List<Class> Classes { get; set; }
    }
}