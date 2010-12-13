<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ZergScheduler.Models.Course>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Details
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Model.course_id %></h2>
    <fieldset>
        <legend><%: Model.title %>&nbsp;(<%: Model.credits %> credits)</legend>
        <p><%: Model.description %></p>
    </fieldset>
    <p>
        <%: Html.ActionLink("Back to List", "Browse", new { dept = Model.dept_id })%>
    </p>
</asp:Content>
