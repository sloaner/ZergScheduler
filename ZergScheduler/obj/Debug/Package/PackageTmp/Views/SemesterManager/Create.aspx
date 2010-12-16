<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ZergScheduler.Models.Semester>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Create Semester
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script src="/Scripts/MicrosoftAjax.js" type="text/javascript"></script>
    <script src="/Scripts/MicrosoftMvcValidation.js" type="text/javascript"></script>

    <h2>Create Semester</h2>

    <% Html.EnableClientValidation(); %>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>

        <fieldset>
            <legend>Fields</legend>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.semester_id) %>
            </div>
            <div class="editor-field">
                <%: Html.DropDownList("sem_id", new SelectList(new[] {new{Name="FALL",ID="FA"},
                                              new{Name="WINTER",ID="WI"},
                                              new{Name="SPRING",ID="SP"},
                                              new{Name="SUMMER",ID="SU"}
                                          }, "ID", "Name", "Select Semester"))%>
                <%: Html.DropDownList("sem_year", new SelectList(Enumerable.Range(0, 100).Select(i => i.ToString("00"))))%>
                <%: Html.ValidationMessageFor(model => model.semester_id) %>
                <%: ViewData["SemesterVal"] %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.start_date) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.start_date) %>
                <%: Html.ValidationMessageFor(model => model.start_date) %>
                <%: ViewData["StartVal"] %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.drop_date) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.drop_date) %>
                <%: Html.ValidationMessageFor(model => model.drop_date) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.withdraw_date) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.withdraw_date) %>
                <%: Html.ValidationMessageFor(model => model.withdraw_date) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.reg_start_date) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.reg_start_date) %>
                <%: Html.ValidationMessageFor(model => model.reg_start_date) %>
                <%: ViewData["RegVal"] %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.credit_step) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.credit_step) %>
                <%: Html.ValidationMessageFor(model => model.credit_step) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.day_step) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.day_step) %>
                <%: Html.ValidationMessageFor(model => model.day_step) %>
            </div>
            
            <p>
                <input type="submit" value="Create" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%: Html.ActionLink("Back to List", "Index") %>
    </div>

</asp:Content>

