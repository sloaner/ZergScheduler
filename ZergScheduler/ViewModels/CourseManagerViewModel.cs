using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZergScheduler.Models;

namespace ZergScheduler.ViewModels
{
	public class CourseManagerViewModel
	{
		public Course Course { get; set; }
		public List<Department> Departments { get; set; }
		public List<GFR> GFRs { get; set; }
		public List<GEP> GEPs { get; set; }
	}
}