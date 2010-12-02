using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZergScheduler.Models
{
	public class AccountRepository
	{
		private ZergRushEntities db = new ZergRushEntities();

		public User GetUserByUserID(string uid)
		{
			return db.Users.SingleOrDefault(d => d.user_id.ToLower() == uid.ToLower());
		}

		public IQueryable<Role_Type> GetRolesForUser(string uid)
		{
			User user = db.Users.SingleOrDefault(d => d.user_id.ToLower() == uid.ToLower());
			if (user == null)
				return null;
			return user.Role_Type.AsQueryable();
		}
	}
}