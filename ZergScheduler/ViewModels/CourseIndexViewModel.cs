﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZergScheduler.Models;

namespace ZergScheduler.ViewModels
{
	public class CourseIndexViewModel
	{
		public int NumberOfDepartments { get; set; }
		public List<Department> Departments { get; set; }
	}
}