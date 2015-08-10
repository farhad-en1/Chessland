app.controller('EditProfileController', function ($scope, chlanservice) {
    $scope.FirstName = $('#FirstName').val();
    $scope.LastName = $('#LastName').val();
    $scope.Email = $('#Email').val();

    $scope.editinfouser = function () {
        var infodata ={
            FirstName: $scope.FirstName,
            LastName: $scope.LastName,
            Email: $scope.Email,
            Gender: $scope.account.Gender
        };
        var response = chlanservice.edituser(infodata);
        response.then(function (m) {
            $('#result').removeClass();
            $("#result").text(m.data.message);
            if (m.data.Valid) {
                empty('.e2');
                $("#result").addClass("label label-success");
                $("#welcomemessage").text(m.data.data);
            } else {
                $('#result').addClass("label label-warning");
            }
        });
    };
});