<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ZergScheduler.ViewModels.TeacherViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Student Grades
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <form id="form1" runat="server">

    <h2>Grade Listings</h2>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>
        <%foreach (var item in Model.classes) { %>
            <% if (Model.roster[item.class_id].Count > 0) { %>
            <fieldset>
                
                <legend><%: item.Course.Department.dept_title + " " + item.Course.course_no%></legend>
            
                <table width="410">
                    <tr><th>Student Name</th><th>Current Grade</th><th>New Grade</th></tr>

                    <% foreach (var takes in Model.roster[item.class_id])
                       { %>
                        <tr>
                            <td><%: takes.User.first_name + " " + takes.User.last_name%></td>
                            <td><%: takes.grade%></td>
                            <td><%: Html.TextBox(item.class_id + "/" + takes.student_id)%></td>
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
        <%: Html.ActionLink("Clear", "Index") %>
    </div>

    </form>

</asp:Content>

