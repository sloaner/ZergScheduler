<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ZergScheduler.ViewModels.CourseBrowseViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Browse
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        $(function () {
            $('#courseList h3').live('click', function () {
                $(this).next().slideToggle('fast');
                return false;
            });
        });
    </script>
    <h2>
        Browsing Department:
        <%: Model.Department.dept_id %>
    </h2>
    <ul id="courseList">
        <% foreach (var course in Model.Courses) { %>
        <li>
            <h3><%: course.course_id + " - " + course.title %></h3>
            <fieldset style="display:none;">
                <legend>
                    <%: course.title %>&nbsp;(<%: course.credits%>
                    credits)
                </legend>
                <p>
                    <%: course.description%>
                </p>
            </fieldset>
        </li>
        <% } %>
    </ul>
</asp:Content>
