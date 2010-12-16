<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ZergScheduler.Models.Semester>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Details</h2>

    <fieldset>
        <legend>Fields</legend>
        
        <div class="display-label"><b>Semester ID</b></div>
        <div class="display-field"><%: Model.semester_id %></div>
        
        <div class="display-label"><b>Start Date</b></div>
        <div class="display-field"><%: String.Format("{0:g}", Model.start_date) %></div>
        
        <div class="display-label"><b>Drop Date</b></div>
        <div class="display-field"><%: String.Format("{0:g}", Model.drop_date) %></div>
        
        <div class="display-label"><b>Withdraw Date</b></div>
        <div class="display-field"><%: String.Format("{0:g}", Model.withdraw_date) %></div>
        
        <div class="display-label"><b>Registration Start Date</b></div>
        <div class="display-field"><%: String.Format("{0:g}", Model.reg_start_date) %></div>
        
        <div class="display-label"><b>Credit Step</b></div>
        <div class="display-field"><%: Model.credit_step %></div>
        
        <div class="display-label"><b>Day Step</b></div>
        <div class="display-field"><%: Model.day_step %></div>
        
    </fieldset>
    <p>

        <%: Html.ActionLink("Edit", "Edit", new { id=Model.semester_id }) %> |
        <%: Html.ActionLink("Back to List", "Index") %>
    </p>

</asp:Content>

