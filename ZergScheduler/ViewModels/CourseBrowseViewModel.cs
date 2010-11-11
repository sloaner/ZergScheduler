using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZergScheduler.Models;

namespace ZergScheduler.ViewModels
{
	public class CourseBrowseViewModel
	{
		public Department Department { get; set; }
		public List<Course> Courses { get; set; }

	}
}