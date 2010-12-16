<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ZergScheduler.ViewModels.ClassManagerIndexViewModel>" %>

    <p>
        <%: Html.ActionLink("Create New Class", "Create") %>
    </p>

     <% if(Model.Classes.ToList().Count() == 0){ %> <p>No results were returned.</p><%} else{ %>
    <table id="SortTable">
        <thead>
        <tr>
            <th id="blnk"></th>
            <th>
                Class ID
            </th>
            <th>
                Semester ID
            </th>
            <th>
                Course ID
            </th>
            <th>
                Section ID
            </th>
            <th>
                Room
            </th>
            <th>
                Instructor
            </th>
            <th style="border-right-color:#000">
                Capacity
            </th>
        </tr>
        </thead>
        <tbody>
    <% foreach (var item in Model.Classes.ToList()) { %>
    
        <tr>
           <td>
                <%: Html.ActionLink("Edit", "Edit", new { id = item.class_id })%> |
                <%: Html.ActionLink("Delete", "Delete", new { id = item.class_id })%>
            </td>
            <td>
                <%: item.class_id %>
            </td>
            <td>
                 <%: item.semster_id %>
            </td>
            <td>
                 <%: item.course_id %>
            </td>
            <td>
                <%: item.sect_id %>
            </td>
            <td>
                <%: item.room_id %>
            </td>
            <td>
               <%: item.User.last_name %>, <%: item.User.first_name %>
            </td>
            <td>
                <%: item.capacity %>
            </td>
        </tr>
    
    <% } %>
    </tbody>
    </table>
   <%} %>




