var quoteHelper = {

    date: '',
    amount: '',
    originator: '',
    team: '',
    data: '',

    createRow: function (quote) {
        date = "<td>" + new Date(quote.Date).toGMTString() + "</td>";
        amount = "<td>" + quote.Amount + "</td>";
        originator = "<td>" + quote.Originator + "</td>";
        team = "<td>" + quote.Team + "</td>";
        data = "<td>" + quote.Data + "</td>";
        action = "<td><button type=\"button\" class=\"btn btn-mini btn-primary\">Accept</button>&nbsp;<button type=\"button\" class=\"btn btn-mini\">Reject</button></td>";
        return "<tr class='flasher'>" + date + amount + originator + team + data + action + "</tr>";
    }
}

var gridHelper = {

    appendRow: function (gridId, row, cssClass) {

        //remove the default row if it's present
        var defaultRow = $("#" + gridId + " tbody tr td[colspan=6]");
        if (defaultRow != undefined && defaultRow.text() == "No data to display") {
            defaultRow.remove();
        }

        //add the new row
        $("#" + gridId + " > tbody:last").append(row);

        //flash the new row (once)
        $("." + cssClass).animate({ backgroundColor: '#fbe87e' }, 500);
        $("." + cssClass).animate({ backgroundColor: '#fff' }, 1000);
        $("." + cssClass).removeClass(cssClass);
    }
}

$(function () {
    var pushHub = $.connection.pushHub;

    pushHub.client.receiveData = function (data) {
        //create new row
        var row = quoteHelper.createRow(data.Content);

        //insert it into the table
        gridHelper.appendRow("quotes", row, "flasher");

        //hook up event handler
        $(".btn").click(function () {
            switch ($(this).text()){
                case "Accept":
                    $(this).parent().parent()
                        .animate({ backgroundColor: '#81F781' }, 500)
                        .fadeOut(500);
                    break;

                case "Reject":
                    $(this).parent().parent()
                        .animate({ backgroundColor: '#F78181' }, 500)
                        .fadeOut(500);
                    break;
            }
        });
    };

    $.connection.hub.start().done(function () {
        pushHub.server.joinGroup($.connection.hub.id, "Requests", token);
    });
});