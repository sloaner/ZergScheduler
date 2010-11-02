<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ZergScheduler.ViewModels.CourseIndexViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Browse Courses</h2>
    <p>
        Select from
        <%: Model.NumberOfDepartments %>
        departments:</p>
    <ul>
        <% foreach (string departmentName in Model.Departments)
           { %>
        <li>
            <%: departmentName%>
        </li>
        <% } %>
    </ul>
</asp:Content>
