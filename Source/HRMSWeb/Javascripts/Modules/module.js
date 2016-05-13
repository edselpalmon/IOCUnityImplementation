// create the module and name HRMSWeb
//var HRMSWeb = angular.module('HRMSWeb', ['ngRoute', 'angular-loading-bar'])
var HRMSWeb = angular.module('HRMSWeb', ['ngRoute','utf8-base64'])
.constant("myConstant", {
    "baseurl1": "https://localhost",
    "baseurl2": "https://localhost:9990",
    "baseurl3": "http://localhost:9999",
    "baseurl4": "http://localhost:55640"
})

.run(function ($rootScope, $window, $location, menuSelectorService, navMenuControllerService) {

    $rootScope.$on("$routeChangeStart", function (event, next, current) {

        var userInfo = JSON.parse($window.sessionStorage.getItem('UserInfo'));
        if (!userInfo) {
            var AppPath = 'login';
            menuSelectorService.MenuSelector(AppPath)
            $location.path('/' + AppPath);
            navMenuControllerService.ToggleMenu(false);
        }
        else {
            
            if (typeof next.originalPath == 'undefined' || next.originalPath == '/error') {
                $location.path('/error');
                navMenuControllerService.HideAllMenu();
            }
            else if (next.originalPath == '/login' || next.originalPath == '' || next.originalPath == '/') {
                $location.path('/home');
                navMenuControllerService.ToggleMenu(true);
            }
            else {

                navMenuControllerService.ToggleMenu(true);
            }

        }
    });

});