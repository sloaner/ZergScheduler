<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Semester Deleted
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Semester Deleted?</h2>

    <p> <%: ViewData["Message"] %></p>

    <p> <%: Html.ActionLink("Back to list", "Index") %>
    </p>

</asp:Content>
