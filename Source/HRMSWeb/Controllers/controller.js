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

HRMSWeb.controller('EmployeeController', function ($scope) {

    $scope.Employee = {
        FirstName: "Edsel",
        LastName: "Palmon",
        MiddleName: "Villanueva"
    };

});