using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZergScheduler.Models
{
	public partial class ShoppingCart
	{
		ZergRushEntities db = new ZergRushEntities();
		string shopping_cart_id { get; set; }
		public const string cart_session_key = "CartId";

		public static ShoppingCart GetCart(HttpContextBase context)
		{
			var cart = new ShoppingCart();
			cart.shopping_cart_id = cart.GetCartId(context);
			return cart;
		}

		public void AddToCart(Class class_add)
		{
			var cart_item = db.Carts.SingleOrDefault(c => c.user_id == shopping_cart_id && c.class_id == class_add.class_id && c.semester_id == class_add.semster_id);

			if (cart_item == null) {
				cart_item = new Cart
				{
					class_id = class_add.class_id,
					semester_id = class_add.semster_id,
					user_id = shopping_cart_id
				};
				db.AddToCarts(cart_item);

			}
			db.SaveChanges();
		}

		public void RemoveFromCart(int id)
		{
			var cart_item = db.Carts.Single(c => c.user_id == shopping_cart_id && c.record_id == id);
			if (cart_item != null) {
				db.Carts.DeleteObject(cart_item);
				db.SaveChanges();
			}
		}

		public void EmptyCart()
		{
			var cart_items = db.Carts.Where(cart => cart.user_id == shopping_cart_id);

			foreach (var cart_item in cart_items) {
				db.DeleteObject(cart_item);
			}

			db.SaveChanges();
		}
		public List<Cart> GetCartItems()
		{
			var cartItems = (from cart in db.Carts
							 where cart.user_id == shopping_cart_id
							 select cart).ToList();
			return cartItems;
		}

		public int GetCount()
		{
			return GetCartItems().Count;
		}

		private string GetCartId(HttpContextBase context)
		{
			if (context.Session[cart_session_key] == null)
				if (!string.IsNullOrWhiteSpace(context.User.Identity.Name))
					context.Session[cart_session_key] = context.User.Identity.Name;
				else
					context.Session[cart_session_key] = Guid.NewGuid().ToString();
			return context.Session[cart_session_key].ToString();
		}

		public void MigrateCart(string user_id)
		{
			var shopping_cart = db.Carts.Where(c => c.user_id == shopping_cart_id);
			foreach (Cart item in shopping_cart) {
				item.user_id = user_id;
			}
			db.SaveChanges();
		}
	}
}