using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Text;
using ZergScheduler.Models;

namespace ZergScheduler.Helpers
{
	public static class HtmlHelpers
	{
		public static string Truncate(this HtmlHelper helper, string input, int length)
		{
			if (input.Length <= length)
				return input;
			return input.Substring(0, length) + "...";
		}

		public static string IntToDay(this HtmlHelper helper, int days)
		{
			string week = "SuMoTuWeThFrSa";
			for (int i = 0; i < 7; i++) {
				if ((days & (1 << i)) == 0) {
					week = week.Remove((6 - i) * 2, 2);
				}
			}
			return week;
		}

		public static string GetClassStatus(this HtmlHelper helper, int class_id, string semester_id, int class_capacity, int waitlist_capacity)
		{
			ZergRushEntities courseDB = new ZergRushEntities();
			int class_enrollment = courseDB.GetClassEnrollment(class_id, semester_id).FirstOrDefault() ?? 0;
			if (class_enrollment < class_capacity)
				return "Open (" + (class_capacity - class_enrollment) + " seats)";

			int waitlist_enrollment = courseDB.GetClassWaitlist(class_id, semester_id).FirstOrDefault() ?? 0;
			if (waitlist_enrollment < waitlist_capacity)
				return "Waitlist (" + (waitlist_capacity - waitlist_enrollment) + " seats)";

			return "Closed";
		}

		public static MvcHtmlString CheckBoxList(this HtmlHelper htmlHelper, string name, MultiSelectList listInfo)
		{
			return htmlHelper.CheckBoxList(name, listInfo, ((IDictionary<string, object>)null));
		}

		public static MvcHtmlString CheckBoxList(this HtmlHelper htmlHelper, string name, MultiSelectList listInfo, object htmlAttributes)
		{
			return htmlHelper.CheckBoxList(name, listInfo, ((IDictionary<string, object>)new RouteValueDictionary(htmlAttributes)));
		}

		public static MvcHtmlString CheckBoxList(this HtmlHelper htmlHelper, string name, MultiSelectList listInfo, IDictionary<string, object> htmlAttributes)
		{
			if (String.IsNullOrEmpty(name))
				throw new ArgumentException("The argument must have a value", "name");
			if (listInfo == null)
				throw new ArgumentNullException("listInfo");
			if (listInfo.Count() < 1)
				throw new ArgumentException("The list must contain at least one value", "listInfo");

			StringBuilder sb = new StringBuilder();

			int id = 0;
			foreach (SelectListItem info in listInfo) {
				TagBuilder check_builder = new TagBuilder("input");
				if (info.Selected) check_builder.MergeAttribute("checked", "checked");
				check_builder.MergeAttributes<string, object>(htmlAttributes);
				check_builder.MergeAttribute("type", "checkbox");
				check_builder.MergeAttribute("value", info.Value);
				check_builder.MergeAttribute("name", name);
				check_builder.MergeAttribute("id", name + id);
				sb.Append(check_builder.ToString(TagRenderMode.Normal));

				TagBuilder label_builder = new TagBuilder("label");
				label_builder.MergeAttribute("for", name + id);
				label_builder.InnerHtml = info.Text;
				sb.Append(label_builder.ToString(TagRenderMode.Normal));

				id++;
				sb.Append("<br />");
			}
			return MvcHtmlString.Create(sb.ToString());
		}
	}

	// This the information that is needed by each checkbox in the
	// CheckBoxList helper.
	public class CheckBoxListInfo
	{
		public CheckBoxListInfo(string value, string displayText, bool isChecked)
		{
			this.Value = value;
			this.DisplayText = displayText;
			this.IsChecked = isChecked;
		}

		public string Value { get; private set; }
		public string DisplayText { get; private set; }
		public bool IsChecked { get; private set; }
	}
}