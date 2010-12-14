using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZergScheduler.Models;

namespace ZergScheduler.ViewModels
{
	public class ShoppingCartAlterViewModel
	{
		public string Message { get; set; }
		public decimal CartCount { get; set; }
		public int AlterId { get; set; }
		public string AlterSemester { get; set; }
	}
}