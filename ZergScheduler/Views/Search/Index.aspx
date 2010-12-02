<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ZergScheduler.ViewModels.SearchViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Index</h2>
    <% using (Html.BeginForm())
       {%>
    <%: Html.ValidationSummary(true) %>
    <fieldset>
        <legend>Fields</legend>
        <div class="editor-label">
            <%: Html.LabelFor(model => model.Course.dept_id) %>
        </div>
        <div class="editor-field">
            <%: Html.DropDownList("dept_id", new SelectList(Model.Departments,"dept_id", "dept_title")) %>
        </div>
        <div class="editor-label">
            <%: Html.LabelFor(model => model.Course.course_no) %>
        </div>
        <div class="editor-field">
            <%: Html.TextBoxFor(model => model.Course.course_no)%>
            <%: Html.ValidationMessageFor(model => model.Course.course_no)%>
        </div>
        <p>
            <input type="submit" value="Search" />
        </p>
    </fieldset>
    <% } %>
    <div>
        <%: Html.ActionLink("Back to List", "Index") %>
    </div>
</asp:Content>
