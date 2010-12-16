<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<ZergScheduler.Models.Course>>" %>
<%if (Model.Count() == 0) { %>
<h3>
    Nothing found.
</h3>
<%} else { %>
<% foreach (var item in Model) { %>
<div id="courseResult">
    <fieldset>
        <legend>
            <%: item.course_id + " " + item.title %>&nbsp;(<%: item.credits %>&nbsp;credits) </legend>
        <div <%=(Model.Count() > 1) ? "style=\"display: none;\"": ""%>>
            <p>
                <%: item.description %>
            </p>
            <% var classes = item.Classes.Where(c => c.semster_id == ViewData["semester"].ToString()
                   && (bool.Parse(ViewData["filter_class_id"].ToString()) || c.class_id == int.Parse(ViewData["class_id"].ToString())));
               if (classes.Count() == 0) { %>
            <h3>
                No classes offered this semester.
            </h3>
            <% } else { %>
            <table id="classResult">
                <% foreach (var classResult in classes) {
                       if (!classResult.parent_class_id.HasValue) {%>
                <tbody>
                    <tr class="classParentRow">
                        <td id="add-<%: classResult.class_id %>" class="addClass">
                            <%= Ajax.ActionLink("[Replaceme]", "AddToCart", "ShoppingCart", new { class_id = classResult.class_id, semester_id = classResult.semster_id }, new AjaxOptions() { HttpMethod = "Post", OnSuccess = "handleUpdate" }).ToHtmlString().Replace("[Replaceme]", @"<img src=""" + Url.Content("~/Content/Images/add.png") + "\" />")%>
                            <img style="display: none" src="<%: Url.Content("~/Content/Images/accept.png") %>" />
                        </td>
                        <td>
                            <b><%: classResult.sect_id %>
                            (<%:classResult.class_id %>)</b>
                        </td>
                        <td>
                        </td>
                        <td>
                            Status:
                            <b><%: Html.GetClassStatus(classResult.class_id, classResult.semster_id, classResult.capacity, classResult.waitlist_capacity, Url.Content("~/Content/Images"))%></b>
                        </td>
                    </tr>
                    <tr class="classParentRow">
                        <td colspan="2">
                            <b><%: classResult.User.first_name + " " + classResult.User.last_name%></b>
                        </td>
                        <td>
                            <b><%: (classResult.days == null||classResult.Timeslot == null) ? "TBA" : Html.IntToDay(classResult.days.Value) +" "+ classResult.Timeslot.start_time.ToShortTimeString() + " - " + classResult.Timeslot.end_time.ToShortTimeString()%></b>
                        </td>
                        <td>
                            <b><%: classResult.room_id %></b>
                        </td>
                    </tr>
                    <tr class="classParentRow">
                        <td colspan="2">
                        </td>
                        <td>
                            Class Capacity:
                            <b><%: classResult.capacity %></b>
                        </td>
                        <td>
                            Waitlist capacity: <b><%: classResult.waitlist_capacity %></b>
                        </td>
                    </tr>
                    <tr class="classParentRow">
                        <td colspan="2">
                        </td>
                        <td>
                            Enrollment Total:
                            <b><%: classResult.Takes.Count(t => t.waitlist_status == false) %></b>
                        </td>
                        <td>
                            Waitlist Total: <b><%: classResult.Takes.Count(t => t.waitlist_status == true)%></b>
                        </td>
                    </tr>
                </tbody>
                <% } else { %>
                <tbody>
                    <tr class="classChildRow">
                        <td>
                        </td>
                        <td>
                            <%: classResult.sect_id %>
                            (<%:classResult.class_id %>)
                        </td>
                        <td>
                        </td>
                        <td>
                            Status:
                            <%: Html.GetClassStatus(classResult.class_id, classResult.semster_id, classResult.capacity, classResult.waitlist_capacity, Url.Content("~/Content/Images"))%>
                        </td>
                    </tr>
                    <tr class="classChildRow">
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                            <%: (classResult.days == null||classResult.Timeslot == null) ? "TBA" : Html.IntToDay(classResult.days.Value) +" "+ classResult.Timeslot.start_time.ToShortTimeString() + " - " + classResult.Timeslot.end_time.ToShortTimeString()%>
                        </td>
                        <td>
                            <%: classResult.room_id %>
                        </td>
                    </tr>
                    <tr class="classChildRow">
                        <td colspan="2">
                        </td>
                        <td>
                            Class Capacity:
                            <%: classResult.capacity %>
                        </td>
                        <td>
                            Waitlist capacity:<%: classResult.waitlist_capacity %>
                        </td>
                    </tr>
                    <tr class="classChildRow">
                        <td colspan="2">
                        </td>
                        <td>
                            Enrollment Total:
                            <%: classResult.Takes.Count(t => t.waitlist_status == false) %>
                        </td>
                        <td>
                            Waitlist Total:<%: classResult.Takes.Count(t => t.waitlist_status == true)%>
                        </td>
                    </tr>
                </tbody>
                <% }
                   } %>
            </table>
            <%} %>
        </div>
    </fieldset>
    <% } %>
</div>
<% } %>