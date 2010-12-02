using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZergScheduler.Models;

namespace ZergScheduler.ViewModels
{
	public class SearchViewModel
	{
		public Class Class { get; set; }
		public Course Course { get; set; }
		public List<Department> Departments { get; set; }
		public List<GFR> GFRs { get; set; }
		public List<GEP> GEPs { get; set; }
		public List<Semester> Semester { get; set; }
	}
}