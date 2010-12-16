<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ZergScheduler.ViewModels.ClassManagerIndexViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        function hideDefault() {
            $('#classResults').html = "";
        }
        function enableSorting() {
            $("#SortTable").tablesorter({ sortList: [[0, 0]] });
        }
    </script>
    <h2> Class Manager </h2>

    <%using (Ajax.BeginForm("partIndex", new AjaxOptions { UpdateTargetId = "classResults", OnBegin = "hideDefault", OnSuccess="enableSorting" }))
      { %>
        <h2>Select Semester: <%: Html.DropDownList("sem_list", new SelectList(Model.Semesters.ToList(), "semester_id", "semester_id"),"All")%>
        <input type="submit" value="Select" /></h2>
        <%} %>

    <div id="classResults">
        <% Html.RenderPartial("partIndex"); %>
    </div>
   <%-- --%>
</asp:Content>