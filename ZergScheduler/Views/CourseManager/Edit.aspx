﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ZergScheduler.ViewModels.CourseManagerViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Edit
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Edit -
        <%: Model.Course.course_id.ToUpper() %></h2>
    <% using (Html.BeginForm()) {%>
    <%: Html.ValidationSummary(true) %>
    <fieldset>
        <legend>Edit Course</legend>
        <%: Html.EditorFor(model => model.Course,
            new { Departments = Model.Departments, GEPs = Model.GEPs, GFRs = Model.GFRs })%>
        <p>
            <input type="submit" value="Save" />
        </p>
    </fieldset>
    <% } %>
    <div>
        <%: Html.ActionLink("Back to List", "Index") %>
    </div>
</asp:Content>
