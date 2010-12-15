<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<script type="text/javascript">
    function handleUpdate(context) {
        alert(context);
        var json = context.get_data();
        var data = Sys.Serialization.JavaScriptSerializer.deserialize(json);
        $('#add-' + data.AlterId).fadeOut('slow');
        $('#cart-status').text('Cart (' + data.CartCount + ')');
        $('#update-message').text(data.Message);
    }
</script>
