using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Text;

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

			foreach (SelectListItem info in listInfo)
			{
				TagBuilder builder = new TagBuilder("input");
				if (info.Selected) builder.MergeAttribute("checked", "checked");
				builder.MergeAttributes<string, object>(htmlAttributes);
				builder.MergeAttribute("type", "checkbox");
				builder.MergeAttribute("value", info.Value);
				builder.MergeAttribute("name", name);
				builder.InnerHtml = info.Text;
				sb.Append(builder.ToString(TagRenderMode.Normal));
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