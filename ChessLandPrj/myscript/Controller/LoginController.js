app.controller('LoginController', function ($scope, chlanservice) {
    $scope.signIn = function () {
        var logindata = $scope.login;
        $("#result").text("");
        var response = chlanservice.usercheck(logindata);
        response.then(function(m) {
            if (m.data.Valid) {
                $("#welcomemessage").text(m.data.message);
                $(location).attr('href', '/');
            } else {
                $("#result").text(m.data.message);
                empty(".e4");
            };
        });
    };
    $scope.logout=function() {
        var response = chlanservice.logout();
        response.then(function(m)
        {
            if (m.data.valid) {
                $("#welcomemessage").text(" میهمان عزیز خوش امدید");
                window.location = '/';
            }
        })
    }
});