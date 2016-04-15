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

HRMSWeb.controller('EmployeeController', ['$scope', 'mainService', function ($scope, mainService) {

    $scope.URL = "http://localhost/HRMSService/EmployeeService/GetEmployeeById";
    $scope.param = 2; //maybe a json string data
    mainService.PostData($scope.URL, $scope.param).then(function (data) {

        //You will get "data" as a response from DTHTopup service
    });

    $scope.Employee = {
        FirstName: "Edsel",
        LastName: "Palmon",
        MiddleName: "Villanueva"
    };

}]);


