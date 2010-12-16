<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ZergScheduler.Models.Semester>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Delete
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Delete Confirmation</h2>

    <h3>Are you sure you want to delete the semester <strong><%: Model.semester_id %></strong>?</h3>
    <fieldset>
        <legend>Fields</legend>
        
        <div class="display-label"><b>Semester ID</b></div>
        <div class="display-field"><%: Model.semester_id %></div>
        
        <div class="display-label"><b>Start Date</b></div>
        <div class="display-field"><%: String.Format("{0:g}", Model.start_date) %></div>
        
        <div class="display-label"><b>Registration Start Date</b></div>
        <div class="display-field"><%: String.Format("{0:g}", Model.reg_start_date) %></div>
        
    </fieldset>
    <% using (Html.BeginForm()) { %>
        <p>
		    <input type="submit" value="Delete" /> | <%: Html.ActionLink("Back to list", "Index") %>
        </p>
    <% } %>

</asp:Content>

