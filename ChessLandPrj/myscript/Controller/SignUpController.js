(function() {
    app.controller('SignUpController', function ($scope, chlanservice) {
        
        $scope.registernewuser = function() {
            $("#signupbtn").addClass("hide");
            $("#loading").removeClass("hide");

            $('#result').removeClass();
            $('#result').text('');
            var udata = $scope.account;
            var re = chlanservice.createuser(udata);
            re.then(function(messagefromController) {
                $("#signupbtn").removeClass("hide");
                $("#loading").addClass("hide");
                if (messagefromController.data.Valid) {
                    $('#result').addClass("label label-success");
                    $('#result').text("حساب کاربری برای شما ایجاد گردید");
                    empty(".e1");
                    $scope.province = '';
                    $scope.cites = '';
                } else {
                    $(".field-validation-valid").text("");
                    $.each(messagefromController.data.Error, function(key, value) {
                        $('#result').addClass("label label-warning");
                        if (key == 'error') {
                            $('#result').text(value);
                        } else {
                            $(".field-validation-valid[data-valmsg-for='" + key + "']").text(value[0].ErrorMessage);

                            $('#result').text("عملیات با موفقیت انجام نشد");
                        }
                    });
                }
            }, function() {
                alert('Save Permission Error');
            });

        };

        var x = chlanservice.getContries();
        x.then(function(messagefromController) {
            $scope.countries = messagefromController.data;
        });

        $scope.getprivoices = function (coid) {
            $scope.province = '';
            var prs = chlanservice.getProvinces(coid);
            prs.then(function (m) {
                $scope.province = m.data;
            });
        };
        $scope.getcities = function(provid) {
            $scope.cites = '';
            var prs = chlanservice.getcites(provid);
            prs.then(function (m) {
                $scope.cites = m.data;
            });

        };

    });
}());
