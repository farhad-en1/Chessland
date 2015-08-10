app.controller('TicketController', function ($scope, chlanservice) {
    $scope.sendticket=function() {
        $("#result").text("");
        var userdata = $scope.Qstion;
        var response = chlanservice.sendticket(userdata);
        response.then(function (m) {
            $("#result").text(m.data.message);
            if (m.data.valid) {
                empty(".e3");
            }
        });

    }

});