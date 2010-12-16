<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>

<%: Html.ActionLink("Cart (" + ViewData["CartCount"] + ")", "Index", "ShoppingCart", null, new { id = "cart-status", @class = "nav menu-label" })%>