using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using ZergScheduler.Models;

namespace ZergScheduler.Controllers
{

	[HandleError]
	public class AccountController : Controller
	{

		public IFormsAuthenticationService FormsService { get; set; }
		public IMembershipService MembershipService { get; set; }

		protected override void Initialize(RequestContext requestContext)
		{
			if (FormsService == null) { FormsService = new FormsAuthenticationService(); }
			if (MembershipService == null) { MembershipService = new AccountMembershipService(); }

			base.Initialize(requestContext);
		}

		// **************************************
		// URL: /Account/LogOn
		// **************************************

		public ActionResult LogOn()
		{
			return View();
		}

		[HttpPost]
		public ActionResult LogOn(LogOnModel model, string returnUrl)
		{
			if (ModelState.IsValid) {
				if (MembershipService.ValidateUser(model.UserName, model.Password)) {

					MigrateShoppingCart(model.UserName);
					FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);

					if (!String.IsNullOrEmpty(returnUrl))
						return Redirect(returnUrl);
					else
						return RedirectToAction("Index", "Home");

				} else {
					ModelState.AddModelError("", "The user name or password provided is incorrect.");
				}
			}
			return View(model);
		}

		// **************************************
		// URL: /Account/LogOff
		// **************************************

		public ActionResult LogOff()
		{
			FormsService.SignOut();

			return RedirectToAction("Index", "Home");
		}

		private void MigrateShoppingCart(string user_id)
		{
			var cart = ShoppingCart.GetCart(this.HttpContext);
			cart.MigrateCart(user_id);
			Session[ShoppingCart.cart_session_key] = user_id;
		}
	}
}
