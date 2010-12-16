<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ZergScheduler.Models.Class>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Delete
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Delete</h2>

    <h3>Are you sure you want to delete this class?</h3>
    <fieldset>
        <legend>Fields</legend>
        
        <div class="display-label"><b>Class ID</b></div>
        <div class="display-field"><%: Model.class_id %></div>
        
        <div class="display-label"><b>Semester ID</b></div>
        <div class="display-field"><%: Model.semster_id %></div>
        
        <div class="display-label"><b>Course ID</b></div>
        <div class="display-field"><%: Model.course_id %></div>
        
        <div class="display-label"><b>Section ID</b></div>
        <div class="display-field"><%: Model.sect_id %></div>
        
    </fieldset>
    <% using (Html.BeginForm()) { %>
        <p>
		    <input type="submit" value="Delete" /> |
		    <%: Html.ActionLink("Back to List", "Index") %>
        </p>
    <% } %>

</asp:Content>

