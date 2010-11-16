<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ZergScheduler.ViewModels.CourseBrowseViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Browse
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
    <!-- chris test commit -->
        Browsing Department:
        <%: Model.Department.dept_id %></h2>
    <ul>
        <% foreach (var course in Model.Courses)
           { %>
        <li>
            <%: Html.ActionLink(course.course_id + " - " + course.title, "Details", new { id = course.course_id })%></li>
        <% } %>
    </ul>
</asp:Content>
