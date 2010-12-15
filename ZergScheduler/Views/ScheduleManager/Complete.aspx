<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<ZergScheduler.ViewModels.RegistrationViewModel>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Complete
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Complete</h2>

    <table>
        <tr>
            <th></th>
            <th>
                Course
            </th>
            <th>
                Message
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <img src="<%: Url.Content("~/Content/Images/" + item.successful + ".png") %>" alt="<%: item.successful %>" />
            </td>
            <td>
                <%: item.class_info %>
            </td>
            <td>
                <%: item.message %>
            </td>
        </tr>
    
    <% } %>

    </table>
</asp:Content>

