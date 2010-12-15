<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ZergScheduler.ViewModels.ShoppingCartViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Shopping Cart
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server"><script src="/Scripts/MicrosoftAjax.js" type="text/javascript"></script>
    <script src="/Scripts/MicrosoftMvcAjax.js" type="text/javascript"></script>
    <script src="/Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
 
    <script type="text/javascript">
        function handleUpdate(context) {
            var json = context.get_data();
            var data = Sys.Serialization.JavaScriptSerializer.deserialize(json);
            
            $('#row-' + data.AlterId).fadeOut('fast');
            $('#cart-status').text('Cart (' + data.CartCount + ')');
        }
    </script>
    <h3>
        <em>Review</em> your cart:
    </h3>
    <div id="update-message">
    </div>
    <table>
        <tr>
            <th>
            </th>
            <th>
                Course Number
            </th>
            <th>
                Semester
            </th>
            <th>
                Instructor
            </th>
        </tr>
        <% foreach (var item in Model.CartItems) { %>
        <tr id="row-<%: item.record_id %>">
            <td>
                <%= Ajax.ActionLink("[Replaceme]", "RemoveFromCart", new { id = item.record_id }, new AjaxOptions() { HttpMethod = "Post", OnSuccess="handleUpdate" }).ToHtmlString().Replace("[Replaceme]", @"<img alt=""Remove"" src=""" + Url.Content("~/Content/Images/delete.png") + "\" />")%>
            </td>
            <td>
                <%: Html.ActionLink(item.Class.course_id, "SingleClassFilter", "Search", new { class_id = item.class_id, semester_id = item.semester_id }, null) %>
            </td>
            <td>
                <%: item.semester_id %>
            </td>
            <td>
                <%: item.Class.User.first_name + " " + item.Class.User.last_name%>
            </td>
        </tr>
        <% } %>
    </table>
    <p class="button">
        <%: Html.ActionLink("Register >>", "Register", "ScheduleManager") %>
    </p>
</asp:Content>
