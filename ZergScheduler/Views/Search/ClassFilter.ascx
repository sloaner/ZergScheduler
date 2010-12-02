<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ZergScheduler.ViewModels.SearchViewModel>" %>
<div>
<% using (Ajax.BeginForm("Index", "Search", new AjaxOptions { UpdateTargetId = "details" }))
   { %>
   <p>Department: <%: Html.DropDownList("dept_id", new SelectList(Model.Departments, "dept_id", "dept_title")) %></p>
   <p>Course Number: <%: Html.TextBoxFor(model => model.Course.course_no)%></p>
   <p><input type="submit" value="Search" /></p>
<% } %>
</div>
<div id="details">
</div>