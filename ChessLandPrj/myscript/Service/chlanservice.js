
app.service("chlanservice", function ($http) {
    // function for create a new user
    this.createuser = function(userdata) {
        var response = $http({
            method: "post",
            url: "/account/createaccount",
            data: JSON.stringify(userdata),
            dataType: "json",
        });
        return response;
    };
    //function for check user is valid
    this.usercheck = function(userdata) {
        var response = $http({
            method: "post",
            url: "/Account/Signin",
            data: JSON.stringify(userdata),
            dataType: "json",
        }); 
        return response;
    };
    this.logout=function() {
        var response = $http({
            method: "post",
            url: "/acc/Logout",
        });
        return response;
    }

    //function for edit profile
    this.edituser = function(userdata) {
        var response = $http({
            method: "post",
            url: "/Account/EditProfile",
            data: JSON.stringify(userdata),
            dataType: "json",
        });
        return response;
    };

    //function for send question
    this.sendticket = function(userdata) {
        var response = $http({
            method: "post",
            url: "/Ticket/SaveQstion",
            data: JSON.stringify(userdata),
            dataType: "json",
        });
        return response;
    };
    //functopin fo add comment user
    this.insertcomment = function(userdata) {
        var response = $http({
            method: "post",
            url: "/Account/InsertComment",
            data: JSON.stringify(userdata),
            dataType: "json",
        });
        return response;
    };
    // function download chesslan.exe
    this.download = function() {
        window.open($http.get("/DownloadGame/Download"));
    };


    //Function to Read All Employees
    this.getContries = function () {
        return $http.get("/account/GetAllCountries");
    };
    this.getProvinces = function(c) {
        return $http.get("/account/GetProvibyCountryId/"+c);
    };
    this.getcites = function(id) {
        return $http.get("/account/GetCityByProvId/" + id);
    };



    //Fundction to Read Employee based upon id
    this.getEmployee = function (id) {
        return $http.get("/api/EmployeeInfoAPI/" + id);
    };
   
    //Function to create new Employee
    this.post = function (Employee) {
        var request = $http({
            method: "post",
            url: "/api/EmployeeInfoAPI",
            data: Employee
        });
        return request;
    };
    //Function  to Edit Employee based upon id 
    this.put = function (id, Employee) {
        var request = $http({
            method: "put",
            url: "/api/EmployeeInfoAPI/" + id,
            data: Employee
        });
        return request;
    };

    //Function to Delete Employee based upon id
    this.delete = function (id) {
        var request = $http({
            method: "delete",
            url: "/api/EmployeeInfoAPI/" + id
        });
        return request;
    };
});