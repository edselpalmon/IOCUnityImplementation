// create the controller and inject Angular's $scope

HRMSWeb.controller('loginController', ['$scope', '$location', 'menuSelectorService', 'mainService', '$window', 'base64', 'myConstant',
function ($scope, $location, menuSelectorService, mainService, $window, base64, myConstant) {

    $scope.AppPath = 'login';
    menuSelectorService.MenuSelector($scope.AppPath);

    $scope.UserLogin = function () {

        $("#loadProgress").show();
        $scope.URL = myConstant.baseurl2 + "/AuthenticationService/Authenticate";
        $scope.param = null;
        if ($scope.User != null && $scope.User.UserName != "" && $scope.User.Password != "") {
            mainService.PostAuthorization($scope.URL, $scope.param, $scope.User.UserName + ':' + $scope.User.Password)
            .then(function (data) {
                if (data.UserRole != "") {

                    $window.sessionStorage.setItem('UserData', JSON.stringify($scope.User));
                    $window.sessionStorage.setItem('UserInfo', JSON.stringify(data));
                    $("#userInfo").show();

                    var appPath = 'home';
                    $location.path('/' + appPath);
                    menuSelectorService.MenuSelector(appPath);
                }
                else {
                    $("#noDataFound").show();
                }
            }, function (response) {
                if (response == "Status Code: 401") {
                    $("#errorMessage").text("Invalid Login... Please try again...");
                }
                else {
                    $("#errorMessage").text("An Error occured while loading...");
                }
                $("#errorMessage").show();
            })
            .finally(function () {
                $("#loadProgress").hide();
                $("#noDataFound").text("No data found..");
                $("#noDataFound").hide();
            });
        }
        else {
            $("#errorMessage").text("User Name and Password is required.");
            $("#errorMessage").show();
            $("#loadProgress").hide();
            $("#noDataFound").hide();
        }
    };


}]);

HRMSWeb.controller('mainController', ['$scope', 'menuSelectorService', '$window', 'navMenuControllerService',
    function ($scope, menuSelectorService, $window, navMenuControllerService) {

        $scope.CurrentUser = JSON.parse($window.sessionStorage.getItem('UserInfo'));

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

HRMSWeb.controller('EmployeeController', ['$scope', '$routeParams', 'mainService', 'menuSelectorService', '$window', 'myConstant',
    function ($scope, $routeParams, mainService, menuSelectorService, $window, myConstant) {

        $scope.User = JSON.parse($window.sessionStorage.getItem('UserInfo'));
        $scope.AppPath = 'employeedetail';
        menuSelectorService.MenuSelector($scope.AppPath);

        $("#loadProgress").show();

        $scope.URL = myConstant.baseurl2 + "/HRMSService/GetEmployeeById";
        $scope.param = $routeParams.employeeId;
        mainService.PostData($scope.URL, $scope.param, $scope.User.UserToken)
            .then(function (data) {
                $scope.Employee = data;
                if (data.EmployeeId > 0) {
                    $("#employeeDetail").show();
                }
                else {
                    $("#noDataFound").show();
                }
            }, function (response) {
                $("#errorMessage").show();
            })
            .finally(function () {
                $("#loadProgress").hide();
            });

    }]);

HRMSWeb.controller('EmployeesController', ['$scope', 'mainService', 'menuSelectorService', '$window', 'myConstant',
    function ($scope, mainService, menuSelectorService, $window, myConstant) {

        $scope.AppPath = 'employeelist';
        menuSelectorService.MenuSelector($scope.AppPath);
        $scope.User = JSON.parse($window.sessionStorage.getItem('UserInfo'));
        $("#loadProgress").show();

        $scope.URL = myConstant.baseurl2 + "/HRMSService/GetEmployees";

        mainService.PostData($scope.URL, $scope.param, $scope.User.UserToken)
        .then(function (data) {
            $scope.Employees = data;
            if (data != null) {
                $("#employeeList").show();
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

    }]);


HRMSWeb.controller('logOutController', ['$scope', '$location', '$window', 'mainService', 'myConstant',
    function ($scope, $location, $window, mainService, myConstant) {

        $scope.URL = myConstant.baseurl2 + "/AuthenticationService/Logout";
        $scope.User = JSON.parse($window.sessionStorage.getItem('UserInfo'));

        mainService.PostData($scope.URL, $scope.param, $scope.User.UserToken)
       .then(function () {

           $("#noDataFound").text("You have been successfully logged off from the system...");
           $("#noDataFound").show();

       }, function (response) {
           $("#errorMessage").text("An Error occured while loading...");
           $("#errorMessage").show();
       })
       .finally(function () {
           $("#loadProgress").hide();
       });

        delete $window.sessionStorage.clear();
        $location.path('/login');
    }]);

HRMSWeb.controller('errorPageController', ['$scope', '$location', '$window',
    function ($scope, $location, $window) {
        $location.path('/error');
    }]);



