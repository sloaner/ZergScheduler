<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<ZergScheduler.Models.Course>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table id="SortTable">
        <tr>
            <th></th>
            <th>Course ID</th>
            <th>Title</th>
            <th>Department</th>
        </tr>
        <% foreach (var item in Model)
           { %>
        <tr>
            <td>
                <%: Html.ActionLink("Edit", "Edit", new { id=item.course_id }) %>
                |
                <%: Html.ActionLink("Delete", "Delete", new { id=item.course_id })%>
            </td>
            <td>
                <%: item.course_id %>
            </td>
            <td>
                <%: Html.Truncate(item.title, 60) %>
            </td>
            <td>
                <%: item.dept_id %>
            </td>
        </tr>
        <% } %>
    </table>
    <p>
        <%: Html.ActionLink("Create New", "Create") %>
    </p>
</asp:Content>
