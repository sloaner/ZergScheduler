<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ZergScheduler.ViewModels.SemesterIndexViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	UMBC Semesters
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Current Semester</h2>
    <p>The current semester is set as: <strong style="font-size:1.5em"> <%:Model.Current.semester_id %></strong> | <%: Html.ActionLink("Change","EditCurrent") %></p>

    <br />
    <h2>UMBC Semesters</h2>

    <table id="SortTable">
        <thead>
        <tr>
            <th id="blnk"></th>
            <th>
                Semester ID
            </th>
            <th>
                Start Date
            </th>
            <th>
                Drop Date
            </th>
            <th>
                Withdraw Date
            </th>
            <th>
                Reg. Start Date
            </th>
            <th>
                Credit Step
            </th>
            <th style="border-right-color:#000">
                Day Step
            </th>
        </tr>
        </thead>
        <tbody>
    <% foreach (var item in Model.Semesters){ %>
    
        <tr>
            <td>
                <%: Html.ActionLink("Edit", "Edit", new { id=item.semester_id }) %> |
                <%: Html.ActionLink("Details", "Details", new { id=item.semester_id })%> |
                <%: Html.ActionLink("Delete", "Delete", new { id=item.semester_id })%>
            </td>
            <td>
                <%: item.semester_id %>
            </td>
            <td>
                <%: String.Format("{0:d}", item.start_date) %>
            </td>
            <td>
                <%: String.Format("{0:d}", item.drop_date) %>
            </td>
            <td>
                <%: String.Format("{0:d}", item.withdraw_date) %>
            </td>
            <td>
                <%: String.Format("{0:d}", item.reg_start_date) %>
            </td>
            <td>
                <%: item.credit_step %>
            </td>
            <td>
                <%: item.day_step %>
            </td>
        </tr>
    
    <% } %>
    </tbody>
    </table>

    <p>
        <%: Html.ActionLink("Create New Semester", "Create") %>
    </p>

</asp:Content>

