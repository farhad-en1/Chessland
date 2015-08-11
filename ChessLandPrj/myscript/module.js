var app = angular.module("ApplicationModule", ["ngRoute"]);
app.config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {
    $routeProvider.when('/signup',
                        {
                            templateUrl: 'Account',
                            controller: 'SignUpController'
                        });
    $routeProvider.when('/login',
                        {
                            templateUrl: 'Account/Login',
                            controller: 'LoginController'
                        });
    $routeProvider.when('/sendticket',
        {
            templateUrl: 'Ticket/SendQstion',
            controller: 'TicketController'
        });

    $routeProvider.when('/viewticet',
    {
        templateUrl: 'Ticket/ViewQstionWithAnswer'
    }); 

    $routeProvider.when('/gallery',
{
    templateUrl: 'Home/ViewAllGallery'
});

    $routeProvider.when('/editprofile',
    {
        templateUrl: 'Account/EditProfile',
        controller: 'EditProfileController'
    });
    
    $routeProvider.when('/download',
{
    templateUrl: 'Home/DownloadIndex',
    controller: 'DownloadController'
}); 
    $routeProvider.when('/aboutus',
{
    templateUrl: 'Home/Aboutus',
    controller: 'AboutusController'
});
    $routeProvider.when('/preamble',
{
    templateUrl: 'Home/Preamble',
    controller: 'PreambleController'
});


    $routeProvider.when('/onlinechat',
{
    templateUrl: 'Home/Aboutus',
    controller: 'AboutusController'
}); 


    



    $routeProvider.otherwise(
                    {
                        redirectTo: '/'
                    });
    // $locationProvider.html5Mode(true);
    $locationProvider.html5Mode(true).hashPrefix('!')
}]);
