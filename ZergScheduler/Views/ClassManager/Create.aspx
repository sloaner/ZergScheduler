<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ZergScheduler.ViewModels.ClassManagerCreateViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Create
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Create</h2>
    <% using (Html.BeginForm())
       {%>
    <%: Html.ValidationSummary(true) %>
    <fieldset>
        <legend>Fields</legend>
        <div class="editor-label">
            <%: Html.LabelFor(model => model.Classes.semster_id) %>
        </div>
        <div class="editor-field">
            <%: Html.DropDownList("sem_list", new SelectList(Model.Semesters.ToList(), "semester_id", "semester_id"))%>
            <%: Html.ValidationMessageFor(model => model.Classes.semster_id) %>
        </div>
        <div class="editor-label">
            <%: Html.LabelFor(model => model.Classes.course_id) %>
        </div>
        <div class="editor-field">
            <%: Html.DropDownList("course_list", new SelectList(Model.Courses.ToList(), "course_id", "course_id"))%>
            <%: Html.ValidationMessageFor(model => model.Classes.course_id)%>
        </div>
        <div class="editor-label">
            <%: Html.LabelFor(model => model.Classes.sect_id)%>
        </div>
        <div class="editor-field">
            <%: Html.TextBoxFor(model => model.Classes.sect_id)%>
            <%: Html.ValidationMessageFor(model => model.Classes.sect_id)%>
            <%: ViewData["IDerror"] %>
        </div>
        <div class="editor-label">
            <%: Html.LabelFor(model => model.Classes.room_id)%>
        </div>
        <div class="editor-field">
            <%: Html.TextBoxFor(model => model.Classes.room_id)%>
            <%: Html.ValidationMessageFor(model => model.Classes.room_id)%>
        </div>
        <div class="editor-label">
            <%: Html.LabelFor(model => model.Classes.inst_id)%>
        </div>
        <div class="editor-field">
            <% List<object> names = new List<object>();
               foreach (var inst in Model.Users)
                   names.Add(new
                   {
                       Name = inst.last_name + ", " + inst.first_name,
                       Id = inst.user_id
                   });%>
            <%: Html.DropDownList("inst_list", new SelectList(names, "Id", "Name","TBA"))%>
            <%: Html.ValidationMessageFor(model => model.Classes.inst_id)%>
        </div>
        <div class="editor-label">
            <%: Html.LabelFor(model => model.Classes.capacity)%>
        </div>
        <div class="editor-field">
            <%: Html.TextBoxFor(model => model.Classes.capacity)%>
            <%: Html.ValidationMessageFor(model => model.Classes.capacity)%>
        </div>
        <div class="editor-label">
            <%: Html.LabelFor(model => model.Classes.waitlist_capacity)%>
        </div>
        <div class="editor-field">
            <%: Html.TextBoxFor(model => model.Classes.waitlist_capacity)%>
            <%: Html.ValidationMessageFor(model => model.Classes.waitlist_capacity)%>
        </div>
        <div class="editor-label">
            <%: Html.LabelFor(model => model.Classes.days)%>
        </div>
        <div class="editor-field">
            <%: Html.CheckBoxList("days_chk", new MultiSelectList(new []{new{Name=" Monday",ID="32"},
                                              new{Name=" Tuesday",ID="16"},
                                              new{Name=" Wednesday",ID="8"},
                                              new{Name=" Thursday",ID="4"},
                                              new{Name=" Friday", ID="2"},
                                              new{Name=" Saturday",ID="1"}
                                          }, "ID", "Name")) %>
            <%: Html.ValidationMessageFor(model => model.Classes.days)%>
        </div>
        <div class="editor-label">
            <%: Html.LabelFor(model => model.Classes.timeslot_id)%>
        </div>
        <div class="editor-field">
            <% List<object> times = new List<object>();
               foreach (var tm in Model.Times)
                   times.Add(new
                   {
                       Name = tm.start_time.ToShortTimeString() + " to " + tm.end_time.ToShortTimeString(),
                       Id = tm.timeslot_id.ToString()
                   });%>
            <%: Html.DropDownList("time_list", new SelectList(times, "Id", "Name"))%>
            <%: Html.ValidationMessageFor(model => model.Classes.timeslot_id)%>
        </div>
        <p>
            <input type="submit" value="Create" />
        </p>
    </fieldset>
    <% } %>
    <div>
        <%: Html.ActionLink("Back to List", "Index") %>
    </div>
</asp:Content>
