// create the controller and inject Angular's $scope

HRMSWeb.controller('loginController', ['$scope', '$location', 'menuSelectorService', 'mainService', 'userData', '$rootScope',
    function ($scope, $location, menuSelectorService, mainService, userData, $rootScope) {

    $scope.AppPath = 'login';
    menuSelectorService.MenuSelector($scope.AppPath);

    $scope.UserLogin = function () {

        $("#loadProgress").show();

        $scope.URL = "http://localhost:55640/EmployeeService/Authenticate";
        $scope.param = "";
        mainService.PostData($scope.URL, $scope.param)
        .then(function (data) {
            if (data.UserRole != "") {

                $rootScope.User = data
                //userData.SetUser(data);

                $("#userInfo").show();
            }
            else {
                $("#noDataFound").show();
            }
        }, function () {
            $("#errorMessage").show();
        })
        .finally(function () {
            $("#loadProgress").hide();
        });


        var appPath = 'home';
        $location.path('/' + appPath);
        menuSelectorService.MenuSelector(appPath);
    };

   
}]);

HRMSWeb.controller('mainController', ['$scope', 'menuSelectorService', 'userData', '$rootScope',
    function ($scope, menuSelectorService, userData, $rootScope) {

    $scope.AppPath = 'home';
    menuSelectorService.MenuSelector($scope.AppPath);

    $scope.message = 'Everyone come and see how good I look!';

}]);

HRMSWeb.controller('aboutController', ['$scope', 'menuSelectorService', function ($scope, menuSelectorService) {

    $scope.AppPath = 'about';
    menuSelectorService.MenuSelector($scope.AppPath);
    $scope.message = 'What about page!';
}]);

HRMSWeb.controller('contactController', ['$scope', 'menuSelectorService', function ($scope, menuSelectorService) {

    $scope.AppPath = 'contact';
    menuSelectorService.MenuSelector($scope.AppPath);

    $scope.message = 'Contact Us!';
}]);

HRMSWeb.controller('EmployeeController', ['$scope', '$routeParams', 'mainService', 'menuSelectorService', function ($scope, $routeParams, mainService, menuSelectorService) {

    $scope.AppPath = 'employeedetail';
    menuSelectorService.MenuSelector($scope.AppPath);

    //deployed URI service 
    //$scope.URL = "https://localhost/HRMSService/EmployeeService/GetEmployeeById";
    
    $("#loadProgress").show();

    $scope.URL = "http://localhost:55640/EmployeeService/GetEmployeeById";
    $scope.param = $routeParams.employeeId;
    mainService.PostData($scope.URL, $scope.param)
        .then(function (data) {
            $scope.Employee = data;
            if (data.EmployeeId > 0) {
                $("#employeeDetail").show();
            }
            else {
                $("#noDataFound").show();
            } 
        }, function() {
            $("#errorMessage").show();
        })
        .finally(function () {
            $("#loadProgress").hide();
        });

}]);

HRMSWeb.controller('EmployeesController', ['$scope', 'mainService', 'menuSelectorService', function ($scope, mainService, menuSelectorService) {

    $scope.AppPath = 'employeelist';
    menuSelectorService.MenuSelector($scope.AppPath);

    //deployed URI service 
    //$scope.URL = "https://localhost/HRMSService/EmployeeService/GetEmployees";

    $("#loadProgress").show();

    $scope.URL = "http://localhost:55640/EmployeeService/GetEmployees";
    mainService.PostData($scope.URL, $scope.param)
        .then(function (data) {
            $scope.Employees = data;
            if(data != null)
            {
                $("#employeeList").show();
            }
            else
            {
                $("#noDataFound").show();
            }
        }, function() {
            $("#errorMessage").show();
        })
        .finally(function () {
            $("#loadProgress").hide();                      
        });

}]);


