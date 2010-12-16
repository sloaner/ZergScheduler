<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<ZergScheduler.Models.Class>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        function hideDefault() {
            $('#classResults').html = "";
        }
        function handleUpdate(context)
        {
            var json = context.get_data();
            var data = Sys.Serialization.JavaScriptSerializer.deserialize(json);

            $('#row-' + data).fadeOut('fast');
        }
    </script>
    <p>
        <%using (Ajax.BeginForm("partIndex", new AjaxOptions { UpdateTargetId = "classResults", OnBegin = "hideDefault" }))
          { %>
        <%--<%: Html.DropDownList("sem_list", new SelectList(ViewData["Semester"] as IEnumerable, "semester_id", "semester_id"))%>--%>
        <%: Html.DropDownList("semester_id", new SelectList(ViewData["Semesters"] as IEnumerable, "semester_id", "semester_id"), "Select Semester")%>
        <input type="submit" value="Select" />
        <%} %>
    </p>
    <div id="classResults">
        <% Html.RenderAction("partIndex"); %>
    </div>
    <%-- --%>
</asp:Content>
