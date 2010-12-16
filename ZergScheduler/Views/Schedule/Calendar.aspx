<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<%: Html.ActionLink("List View", "Index")%>
<head id="Head1" runat="server">
    <title>Index</title>
    <script src="/Scripts/dhtmlxscheduler.js" type="text/javascript"></script>
    <link href="/Scripts/dhtmlxscheduler.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        html, body
        {
            height: 100%;
            padding: 0px;
            margin: 0px;
        }
    </style>
    <script type="text/javascript">
//            var date = '<%: ViewData["start_date"].ToString() %>';
	    function init() {
	        scheduler.config.hour_date = "%h:%i %A";
	        scheduler.config.xml_date = "%m/%d/%Y %h:%i";
	        scheduler.config.drag_move = false;
	        scheduler.config.readonly = true;
	        scheduler.config.show_loading = true;
	        scheduler.config.first_hour = 8;
	        scheduler.config.last_hour = 21;
	        scheduler.config.time_step = 30;
	        scheduler.init("scheduler_here", null, "week");
	        scheduler.load("/Schedule/Data");

	        //var dp = new dataProcessor("/Calendar/Save");
	        //dp.init(scheduler);
	        //dp.setTransactionMode("POST", false);
	    }
    </script>
</head>
<body onload="init()">
    <div id="scheduler_here" class="dhx_cal_container" style='width: 100%; height: 100%;'>
        <div class="dhx_cal_navline">
            <div class="dhx_cal_date">
            </div>
            <div class="dhx_cal_tab" name="week_tab" style="right: 140px;">
            </div>
        </div>
        <div class="dhx_cal_header">
        </div>
        <div class="dhx_cal_data">
        </div>
    </div>
</body>
</html>
