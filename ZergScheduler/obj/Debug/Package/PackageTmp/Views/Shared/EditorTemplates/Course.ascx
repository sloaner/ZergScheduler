<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ZergScheduler.Models.Course>" %>
<div class="editor-label">
    <%: Html.LabelFor(model => model.dept_id) %>
</div>
<div class="editor-field">
    <%: Html.DropDownList("dept_id", new SelectList(ViewData["Departments"] as IEnumerable,"dept_id", "dept_title", Model.dept_id)) %>
    <%: Html.ValidationMessageFor(model => model.dept_id) %>
</div>

<div class="editor-label">
    <%: Html.LabelFor(model => model.course_no) %>
</div>
<div class="editor-field">
    <%: Html.TextBoxFor(model => model.course_no) %>
    <%: Html.ValidationMessageFor(model => model.course_no) %>
</div>

<div class="editor-label">
    <%: Html.LabelFor(model => model.title) %>
</div>
<div class="editor-field">
    <%: Html.TextBoxFor(model => model.title) %>
    <%: Html.ValidationMessageFor(model => model.title) %>
</div>

<div class="editor-label">
    <%: Html.LabelFor(model => model.description) %>
</div>
<div class="editor-field">
    <%: Html.TextAreaFor(model => model.description) %>
    <%: Html.ValidationMessageFor(model => model.description) %>
</div>

<div class="editor-label">
    <%: Html.LabelFor(model => model.credits) %>
</div>
<div class="editor-field">
    <%: Html.TextBoxFor(model => model.credits) %>
    <%: Html.ValidationMessageFor(model => model.credits) %>
</div>

<div class="editor-label">
    <%: Html.LabelFor(model => model.career) %>
</div>
<div class="editor-field">
    <%: Html.TextBoxFor(model => model.career) %>
    <%: Html.ValidationMessageFor(model => model.career) %>
</div>

<div class="editor-label">
    <%: Html.LabelFor(model => model.gfr) %>
</div>
<div class="editor-field">
    <% var gfr = ViewData["GFRs"] as List<ZergScheduler.Models.GFR>; %>
    <% var selectedGFRs = gfr.FindAll(x => ((x.value & Model.gfr) != 0)).Select(x => x.value); %>
    <%: Html.CheckBoxList("Course.gfr", new MultiSelectList(gfr, "value", "name", selectedGFRs))%>
    <%: Html.ValidationMessageFor(model => model.gfr) %>
</div>

<div class="editor-label">
    <%: Html.LabelFor(model => model.gep) %>
</div>
<div class="editor-field">
    <% var gep = ViewData["GEPs"] as List<ZergScheduler.Models.GEP>; %>
    <% var selectedGEPs = gep.FindAll(x => ((x.value & Model.gep) != 0)).Select(x => x.value); %>
    <%: Html.CheckBoxList("Course.gep", new MultiSelectList(gep,"value", "name", selectedGEPs)) %>
    <%: Html.ValidationMessageFor(model => model.gep) %>
</div>
