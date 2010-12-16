<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ZergScheduler.Models.Semester>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit Semester
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script src="/Scripts/MicrosoftAjax.js" type="text/javascript"></script>
    <script src="/Scripts/MicrosoftMvcValidation.js" type="text/javascript"></script>

    <h2>Edit Semester <%: Model.semester_id %></h2>

    <% Html.EnableClientValidation(); %>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>
        
        <fieldset>
            <legend>Fields</legend>
            
            <div class="display-label">semester_id</div>
            <div class="display-field"><b><%: Model.semester_id %></b></div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.start_date) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.start_date, String.Format("{0:g}", Model.start_date)) %>
                <%: Html.ValidationMessageFor(model => model.start_date) %>
                <%: ViewData["StartVal"] %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.drop_date) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.drop_date, String.Format("{0:g}", Model.drop_date)) %>
                <%: Html.ValidationMessageFor(model => model.drop_date) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.withdraw_date) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.withdraw_date, String.Format("{0:g}", Model.withdraw_date)) %>
                <%: Html.ValidationMessageFor(model => model.withdraw_date) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.reg_start_date) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.reg_start_date, String.Format("{0:g}", Model.reg_start_date)) %>
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
                <input type="submit" value="Save" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%: Html.ActionLink("Back to List", "Index") %>
    </div>

</asp:Content>

