<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ZergScheduler.ViewModels.SearchViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        function hideResults() {
            $('#searchDetails').hide();
        };
        function showResults() {
            $('#searchDetails').show();
        };
        $(function () {
            $('#extraOptionsHead').click(function () {
                $(this).next().slideToggle('fast');
                $(this).toggleClass('expanded');
                return false;
            }).next().hide();
        });
        $(function () {
            $('#courseResult legend').live('click', function () {
                $(this).next().slideToggle('fast');
                return false;
            });
        });
    </script>
    <div>
        <div id="searchPanel">
            <% using (Ajax.BeginForm("ClassFilter", "Search", new AjaxOptions { UpdateTargetId = "searchDetails", LoadingElementId = "loading", OnBegin = "hideResults", OnComplete = "showResults" })) { %>
            <p class="inline_form">
                <label>Semester:</label>
                <%: Html.DropDownList("semester_id", new SelectList(Model.Semesters.OrderByDescending(s => s.start_date), "semester_id", "semester_id", Model.CurrentSemester))%>
            </p>
            <div>
                Department:
                <div class="checkBox">
                    <%: Html.CheckBoxList("dept_id", new MultiSelectList(Model.Departments.OrderBy(d=>d.dept_title), "dept_id", "dept_title"))%>
                </div>
            </div>
            <br />
            <p class="inline_form">
                <label>Course&nbsp;Number:</label>
                <%: Html.TextBoxFor(model => model.Course.course_no)%>
            </p>
            <h4 id="extraOptionsHead">
                Extra Options</h4>
            <div id="extraOptions">
                <p class="inline_form">
                    <label>Number&nbsp;of&nbsp;Credits:</label>
                    <%: Html.TextBoxFor(x => x.Course.credits) %>
                </p>
                <div style="float: right;">
                    GFRs:
                    <div>
                        <%: Html.CheckBoxList("gfrs", new MultiSelectList(Model.GFRs, "value", "name", null))%>
                    </div>
                </div>
                <div>
                    GEPs:
                    <div>
                        <%: Html.CheckBoxList("geps", new MultiSelectList(Model.GEPs, "value", "name", null))%>
                    </div>
                </div>
                <br />
                <p class="inline_form">
                    <label>Start&nbsp;Time:</label>
                    <%: Html.DropDownList("start_time_comp", new SelectList(new[] { "<", ">", "=" }), new { @class = "comparer" })%>
                    <%: Html.TextBoxFor(m => m.Class.Timeslot.start_time, new { @class = "time" })%>
                </p>
                <p class="inline_form">
                    <label>End&nbsp;Time:</label>
                    <%: Html.DropDownList("end_time_comp", new SelectList(new[] { "<", ">", "=" }), new { @class = "comparer" })%>
                    <%: Html.TextBoxFor(m => m.Class.Timeslot.end_time, new { @class = "time" })%>
                </p>
                <p>
                    <%: Html.CheckBox("show_open", false) %>
                    <label for="show_open">Show only open classes</label>
                </p>
                <p>
                    <%: Html.CheckBox("show_offered", true) %>
                    <label for="show_offered">
                        Show only offered courses</label>
                </p>
            </div>
            <p>
                <input type="submit" value="Search" /></p>
            <% } %>
        </div>
        <img id="loading" src="../../Content/Images/loading.gif" style="display: none;" alt="Loading..." />
        <div id="searchDetails">
        </div>
    </div>
</asp:Content>
