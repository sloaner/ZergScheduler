<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Course Deleted
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Course Deleted</h2>
    <p>
        The course was successfully deleted.</p>
    <p>
        <%: Html.ActionLink("Click here", "Index") %>
        to return to the course list.
    </p>
</asp:Content>
