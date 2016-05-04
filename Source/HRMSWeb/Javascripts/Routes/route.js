// configure our routes
HRMSWeb.config(['$routeProvider', function ($routeProvider) {

    $routeProvider

        // route for the home page
        .when('/', {
            templateUrl: 'Views/Login/login.html',
            controller: 'loginController',
        })

        .when('/login', {
            templateUrl: 'Views/Login/login.html',
            controller: 'loginController',
        })

        // route for the home page
        .when('/home', {
            templateUrl: 'Views/home.html',
            controller: 'mainController'
        })

        // route for the about page
        .when('/about', {
            templateUrl: 'Views/about.html',
            controller: 'aboutController'
        })

        // route for the contact page
        .when('/contact', {
            templateUrl: 'Views/contact.html',
            controller: 'contactController'
        })

        .when('/employeedetail', {
            templateUrl: 'Views/Employee/employee_detail.html',
            controller: 'EmployeeController'
        })

        .when('/employeelist', {
            templateUrl: 'Views/Employee/employees.html',
            controller: 'EmployeesController'
        })

        .when('/logout', {
            templateUrl: 'Views/Login/login.html',
            controller: 'logOutController'
        })

        //error handling for invalid URL
        .when('/error', {
            templateUrl: 'Views/ErrorPage/error.html',
            controller: 'errorPageController'
        })

        .otherwise({ redirectTo: '/' });
}]);
