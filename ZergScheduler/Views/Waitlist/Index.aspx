<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ZergScheduler.ViewModels.TeacherViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Waitlist
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <form id="form1" runat="server">

    <h2>Waitlisted Students</h2>
    <h3>Select students to add from waitlist.</h3>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>
        <%foreach (var item in Model.classes) { %>
            <% if (Model.roster[item.class_id].Count > 0) { %>
            <fieldset>
                
                <legend><%: item.Course.Department.dept_title + " " + item.Course.course_no%></legend>
            
                <table width="410">
                    <tr><th></th><th>Student Name</th></tr>

                    <% foreach (var takes in Model.roster[item.class_id])
                       { %>
                        <tr>
                            <td><%: Html.CheckBox(item.class_id + "/" + takes.student_id) %></td>
                            <td><%: takes.User.first_name + " " + takes.User.last_name%></td>
                        </tr>
                    <% } %>
                </table>
                <p>
                    <input type="submit" value="Update" />
                </p>
            </fieldset>
            <% } %>
        <% } %>

    <% } %>

    <div>
        <%: Html.ActionLink("Reset", "Index") %>
    </div>

    </form>

</asp:Content>
