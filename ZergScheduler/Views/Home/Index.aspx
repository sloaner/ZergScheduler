<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Home
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="body">
        <h2>
            Welcome to the UMBC Registration System.
        </h2>
        You can:
        <ul>
            <li><%: Html.ActionLink("Search", "Index", "Search") %> for offered classes. </li>
            <li><%: Html.ActionLink("Browse", "Index", "Course") %> the course catalog. </li>

            <% if (User.IsInRole("Student")) { %>
            <li><%: Html.ActionLink("Review", "Index", "Schedule") %> your current schedule. </li>
            <li><%: Html.ActionLink("View", "Index", "History") %> your past classes. </li>

            <% } if (User.IsInRole("Administrator")) { %>
            <li><%: Html.ActionLink("Manage", "Index", "CourseManager") %> the courses. </li>
            <li><%: Html.ActionLink("Manage", "Index", "ClassManager") %> the classes. </li>
            <li><%: Html.ActionLink("Manage", "Index", "SemesterManager") %> the semesters. </li>

            <% } if (User.IsInRole("Instructor")) { %>
            <li><%: Html.ActionLink("Manage", "Index", "Grade") %> grades for your classes. </li>
            <li><%: Html.ActionLink("Manage", "Index", "Waitlist") %>  the waitlist for your classes. </li>
            <% } %>
        </ul>
    </div>
</asp:Content>
