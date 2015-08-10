app.controller('OnlineChatController',['$http', '$scope', function ($http, $scope) {
   
    $(function () {
        
       // $.connection.hub.logging = true;
        var objHub = $.connection.myHub;
        loadClientMethods(objHub);
        $.connection.hub.start().done(function () {

            loadEvents(objHub);

        });

    });
    function loadClientMethods(objHub) {
        objHub.client.NoExistAdmin = function() {
            $("#result").text("پشتیبانی جهت پاسخگوویی وجود ندارد");
        };
        objHub.client.getMessages = function(userName, message) {
            $("#message").append("<li>" + userName + ":" + message + "</li>");
        };
        objHub.client.onConnected = function (id, userName, UserID, userGroup) {
            var strWelcome = 'Welcome' + +userName;
            $('#welcome').append('<div><p>Welcome:' + userName + '</p></div>');

            $('#hId').val(id);
            $('#hUserId').val(UserID);
            $('#hUserName').val(userName);
            $('#hGroup').val(userGroup);

            $("#divChat").show();
            $("#divLogin").hide();

        }


    }

    function loadEvents(objHub) {
        $scope.connect = function () {

                objHub.server.connect();

        };


        $scope.sendmessage=function () {

            var msg = $("#txtMessage").val();

            if (msg.length > 0) {

                var userName = $('#hUserName').val();
                // <<<<<-- ***** Return to Server [  SendMessageToGroup  ] *****
                objHub.server.sendMessageToGroup(userName, msg);

            }
        };
    }

}]);