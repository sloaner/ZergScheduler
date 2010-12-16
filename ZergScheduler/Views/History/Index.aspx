<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<ZergScheduler.Models.Take>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Index</h2>

    <% if (Model.Count() == 0)
       { %> <h2>No classes on record.</h2> <% }
       else
       { %>
    <table id="SortTable">
        <thead>
        <tr>
            <th>
                Course
            </th>
            <th>
                Title
            </th>
            <th>
                Semester
            </th>
            <th>
                Grade
            </th>
            <th>
                Credits
            </th>
        </tr>
        </thead>

    <% foreach (var item in Model)
       { %>
    
        <tr>
            <td>
                <%: item.Class.course_id%>
            </td>
            <td>
                <%: item.Class.Course.title%>
            </td>
            <td>
                <%: item.semester_id%>
            </td>
            <td>
                <%: item.grade%>
            </td>
            <td>
                <%: item.Class.Course.credits%>
            </td>
        </tr>
    
    <% } %>

    </table>

    <% int totalcred = 0; int credearned = 0;
       foreach (var item in Model)
       {
           if (item.grade >= 70)
               credearned += (int)item.Class.Course.credits;
           totalcred += (int)item.Class.Course.credits;
       }%>
    <br />
    <p>Total Classes Taken: <%: Model.Count()%><br />
    Total Credits Taken: <%: totalcred%><br />
    Total Credits Earned: <%: credearned%></p>

    <%} %>

</asp:Content>

