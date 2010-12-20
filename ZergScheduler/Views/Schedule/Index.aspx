<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ZergScheduler.ViewModels.ScheduleIndexViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        function hideDefault() {
            $('#classResults').html = "";
        }
        function handleUpdate(context) {
            var json = context.get_data();
            var data = Sys.Serialization.JavaScriptSerializer.deserialize(json);

            $('#row-' + data).fadeOut('fast');
        }
        function updateCal() {
            $.ajax({
                url: '/ZergScheduler/Schedule/updateCalendar',
                type: 'POST',
                dataType: 'json',
                data: { semester_id: $('#semester_id').val() },
                beforeSend: function (data) {
                    $('#calendar').fullCalendar('removeEvents');
                },
                success: function (data) {
                    $('#calendar').fullCalendar('gotoDate', new Date(data.start));
                    $('#calendar').fullCalendar('addEventSource', data.events);
                }
            });
        }
        $(function () {
            $('#semester_submit').click(updateCal);
            $('#viewSwitcher').toggle(
                function () {
                    updateCal();
                    $('#classResults').hide();
                    $('#calendar').show();
                    $('#viewSwitcher').html('Switch to List View');
                }, function () {
                    $('#classResults').show();
                    $('#calendar').hide();
                    $('#viewSwitcher').html('Switch to Calendar View');
                });

            $('#calendar').hide().fullCalendar({
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
        <%using (Ajax.BeginForm("partIndex", new AjaxOptions { UpdateTargetId = "classResults", OnBegin = "hideDefault" })) { %>
        <%: Html.DropDownList("semester_id", new SelectList(Model.Semesters, "semester_id", "semester_id"), "Select Semester")%>
        <input type="submit" value="Select" id="semester_submit" />
        <%} %>
    </p>
    <h3 id="viewSwitcher">
        Switch to Calendar View</h3>
    <div id="classResults">
        <% Html.RenderAction("partIndex"); %>
    </div>
    <div id="calendar">
    </div>
</asp:Content>
