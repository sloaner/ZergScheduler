using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZergScheduler.Models;

namespace ZergScheduler.ViewModels
{
    public class TeacherViewModel
    {
        public Dictionary<int, List<Take>> roster = new Dictionary<int, List<Take>>();
        public List<Class> classes = new List<Class>();
    }
}