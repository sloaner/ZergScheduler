using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZergScheduler.Models;

namespace ZergScheduler.ViewModels
{
    public class ClassManagerCreateViewModel
    {
        public List<Semester> Semesters { get; set; }
        public Class Classes { get; set; }
        public List<Timeslot> Times { get; set; }
        public List<Department> Depts { get; set; }
        public List<Course> Courses { get; set; }
        public List<User> Users { get; set; }
    }
}