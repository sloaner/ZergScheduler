<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<ZergScheduler.Models.Class>>" %>
<table>
    <tr>
        <th>
        </th>
        <th>
            Course Number
        </th>
        <th>
            Title
        </th>
        <th>
            Time
        </th>
        <th>
            Instructor
        </th>
        <th>
            Room Number
        </th>
        <th>
            Section Number
        </th>
    </tr>
    <% foreach (var item in Model)
       { %>
    <tr id="row-<%: item.class_id %>">
        <td>
            <%: Ajax.ActionLink("Drop", "Drop", new { class_id = item.class_id, semester_id = item.semster_id }, new AjaxOptions { HttpMethod="Post", Confirm="Are you sure you want to drop this class?", OnSuccess="handleUpdate" })%>
        </td>
        <td>
            <%: item.course_id %>
        </td>
        <td>
            <%: item.Course.title %>
        </td>
        <td>
            <%if (item.Timeslot != null)
              { %>
            <%: item.Timeslot.start_time.ToShortTimeString() %>
            -
            <%: item.Timeslot.end_time.ToShortTimeString() %>
            <%} %>
        </td>
        <td>
            <%: item.User.first_name %>
            <%: item.User.last_name %>
        </td>
        <td>
            <%: item.room_id %>
        </td>
        <td>
            <%: item.sect_id %>
        </td>
    </tr>
    <% } %>
</table>
<%: Html.ActionLink("Calendar View", "Calendar", new { id = ViewData["id"] })%>
