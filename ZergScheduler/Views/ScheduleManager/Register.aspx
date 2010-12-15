<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<ZergScheduler.Models.Cart>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Register
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        function toggleCheck(id) {
            var row = $('#row-' + id);

            if ($('#check-' + id + ':checked').val() == null)
                row.fadeTo('fast', .5);
            else
                row.fadeTo('fast', 1);
        }
    </script>
    <h2>
        Register
    </h2>
    <% using (Html.BeginForm()) {%>
    <table>
        <tr>
            <th>
            </th>
            <th>
                Course Number
            </th>
            <th>
                Semester
            </th>
            <th>
                Instructor
            </th>
        </tr>
        <% foreach (var item in Model) { %>
        <tr id="row-<%: item.record_id %>">
            <td style="width:auto;">
                <%: Html.CheckBox("check-" + item.record_id, true, new { onclick = "javascript:toggleCheck(" + item.record_id + ");" }) %>
            </td>
            <td>
                <%: item.Class.course_id %>
            </td>
            <td>
                <%: item.semester_id %>
            </td>
            <td>
                <%: item.Class.User.first_name + " " + item.Class.User.last_name %>
            </td>
        </tr>
        <% } %>
    </table>
    <p>
        <input type="submit" value="Register for selected classes" />
    </p>
    <% } %>
</asp:Content>
