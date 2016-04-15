// configure our routes
HRMSWeb.config(['$httpProvider', '$routeProvider', function ($httpProvider, $routeProvider) {
    //$httpProvider.defaults.headers.common = {};
    //$httpProvider.defaults.headers.post = {};
    //$httpProvider.defaults.headers.put = {};
    //$httpProvider.defaults.headers.patch = {};

    $routeProvider

        // route for the home page
        .when('/', {
            templateUrl: 'Views/home.html',
            controller: 'mainController',
        })

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
    
        // route for the contact page
        .when('/employeeinfo', {
            templateUrl: 'Views/employee.html',
            controller: 'EmployeeController'
        });
}]);