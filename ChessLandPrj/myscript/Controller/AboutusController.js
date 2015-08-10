app.controller('AboutusController', function ($scope, chlanservice) {
    $scope.sendmessage = function() {
        var userdata = $scope.comment;
        var response = chlanservice.insertcomment(userdata);
        response.then(function (m) {
            $('#result').removeClass();
            $('#result').text("");
            if (m.data.valid) {
                $('#result').addClass("label label-success");
                $('#result').text("پیغام شما با موفقیت برای مدیریت ارسال گردید");
                $scope.comment = '';
            } else {
                $(".field-validation-valid").text("");
                $.each(m.data.Error, function (key, value) {
                    $('#result').addClass("label label-warning");
                    if (key == 'error') {
                        $('#result').text(value);
                    } else {
                        $(".field-validation-valid[data-valmsg-for='" + key + "']").text(value[0].ErrorMessage);

                        $('#result').text("عملیات با موفقیت انجام نشد");
                    }
                });
            }
        });
    };
});