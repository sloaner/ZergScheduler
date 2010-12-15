using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZergScheduler.Models;

namespace ZergScheduler.ViewModels
{
	public class RegistrationViewModel
	{
		public Cart cart_item { get; set; }
		public string successful { get; set; }
		public string message { get; set; }
	}
}