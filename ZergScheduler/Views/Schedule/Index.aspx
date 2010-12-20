<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ZergScheduler.ViewModels.ScheduleIndexViewModel>" %>

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
        function updateCal() {
            var json = new Object();
            json.sem = $('#semester_id').val();
            $.ajax({
                url: '/Schedule/updateCalendar',
                type: 'POST',
                dataType: 'json',
                data: { semester_id: $('#semester_id').val() },
                beforeSend: function (data) {
                    $('#calendar').fullCalendar('removeEvents');
                },
                success: function (data) {
                    $('#calendar').toggle(true);
                    $('#calendar').fullCalendar('gotoDate', new Date(data.start));
                    $('#calendar').fullCalendar('addEventSource', data.events);
                }
            });
        }
        $(function () {
            $('#semester_id').change(updateCal);

            $('#calendar').toggle(false).fullCalendar({
                weekends: false,
                editable: false,
                defaultView: 'agendaWeek',
                header: false,
                allDaySlot: false,
                allDayDefault: false,
                minTime: 8,
                maxTime: 22
            });
        });
    </script>
    <p>
        <%using (Ajax.BeginForm("partIndex", new AjaxOptions { UpdateTargetId = "classResults", OnBegin = "hideDefault" }))
          { %>
        <%--<%: Html.DropDownList("sem_list", new SelectList(ViewData["Semester"] as IEnumerable, "semester_id", "semester_id"))%>--%>
        <%: Html.DropDownList("semester_id", new SelectList(Model.Semesters, "semester_id", "semester_id"), "Select Semester")%>
        <input type="submit" value="Select" />
        <%} %>
    </p>
    <div id="classResults">
        <% Html.RenderAction("partIndex"); %>
    </div>
    <div id="calendar"></div>
    
</asp:Content>
