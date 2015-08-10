app.controller('DownloadController', function ($scope, chlanservice) {
    $scope.chessdownload = function () {
        var downloadPath = "/chessgamefile/test.zip";
        window.open(downloadPath, '_blank', '');
    };
});
