<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TradeBook.aspx.cs" Inherits="PushR.TradeBook" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Trade Book</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h3>Trade Book</h3>
        <div id="receiver"></div>
        
        <link rel="stylesheet" href="XStyle.css" />
        <script src="/Scripts/jquery-1.6.4.min.js" ></script>
        <script src="/Scripts/jquery.signalR-1.0.0-rc2.js"></script>
        <script src="/signalr/hubs"></script>
        <script type="text/javascript">
            $(function () {
                //TODO:
                //Move the bulk of this out to a seperate JS file...
                var pushHub = $.connection.pushHub;
                pushHub.client.receiveData = function (data) {
                    $("#receiver").append("<b>" + data.DataType + "</b> - " + data.Content + "<br />");
                };

                $.connection.hub.start().done(function () {
                    pushHub.server.joinGroup($.connection.hub.id, "TradeBook");
                });
            });
        </script>
    </div>
    </form>
</body>
</html>
