// create the controller and inject Angular's $scope

HRMSWeb.controller('mainController', function ($scope) {

    $scope.message = 'Everyone come and see how good I look!';
});

HRMSWeb.controller('aboutController', function ($scope) {

    $scope.message = 'What about page!';
});

HRMSWeb.controller('contactController', function ($scope) {

    $scope.message = 'Contact Us!';
});

HRMSWeb.controller('EmployeeController', ['$scope', '$routeParams', 'mainService', function ($scope, $routeParams, mainService) {
    //deployed URI service 
    //$scope.URL = "http://localhost/HRMSService/EmployeeService/GetEmployeeById";
    
    //for debugging
    $scope.URL = "http://localhost:55640/EmployeeService/GetEmployeeById";
    $scope.param = $routeParams.employeeId;
    mainService.PostData($scope.URL, $scope.param).then(function (data) {
        $scope.Employee = data;
    });

}]);

HRMSWeb.controller('EmployeesController', ['$scope', 'mainService', function ($scope, mainService) {
    //deployed URI service 
    //$scope.URL = "http://localhost/HRMSService/EmployeeService/GetEmployees";

    //for debugging
    $scope.URL = "http://localhost:55640/EmployeeService/GetEmployees";
    mainService.PostData($scope.URL, $scope.param).then(function (data) {
        $scope.Employees = data;
    });

}]);


