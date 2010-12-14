using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZergScheduler.Models;

namespace ZergScheduler.ViewModels
{
	public class ShoppingCartViewModel
	{
		public List<Cart> CartItems { get; set; }
		public decimal CartCount { get; set; }
	}
}