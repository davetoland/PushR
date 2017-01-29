<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PushR.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Overview</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h3>Overview</h3>
        <div id="receiver"></div>
        
        <link rel="stylesheet" href="XStyle.css" />
        <script src="/Scripts/jquery-1.6.4.min.js" ></script>
        <script src="/Scripts/jquery.signalR-1.0.0-rc2.js"></script>
        <script src="/signalr/hubs"></script>

        <script type="text/javascript">
            $(function () {

                var pushHub = $.connection.pushHub;
                var token = "<%=PushR.Push.SecurityManager.Instance.Crypt("abc123")%>";

                pushHub.client.receiveData = function (data) {
                    $("#receiver").append("<b>" + data.DataType + "</b> - " + data.Content + "<br />");
                };

                $.connection.hub.start().done(function () {
                    pushHub.server.joinGroup($.connection.hub.id, "Alerts", token);
                    pushHub.server.joinGroup($.connection.hub.id, "Requests", token);
                    pushHub.server.joinGroup($.connection.hub.id, "Quoted", token);
                    pushHub.server.joinGroup($.connection.hub.id, "TradeBook", token);
                    pushHub.server.joinGroup($.connection.hub.id, "TradeHistory", token);
                });
            });
        </script>
    </div>
    </form>
</body>
</html>
