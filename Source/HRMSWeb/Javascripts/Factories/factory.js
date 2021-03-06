﻿HRMSWeb.factory('mainService', function ($http, $q, base64) {
    return {
        PostAuthorization: function (URL, param, authorization) {
            var deferred = $q.defer();
            $http({
                url: URL,
                method: "POST",
                data: param, //Data sent to server
                contentType: "application/json; charset=utf-8",
                headers: { 'Authorization': base64.encode(authorization) },
                dataType: "json"
            }).success(function (data) {
                deferred.resolve(data);
            }).error(function (response, status) {
                deferred.reject("Status Code: " + status);
            });

            return deferred.promise;
        },
        PostData: function (URL, param, token) {
            var deferred = $q.defer();
            $http({
                url: URL,
                method: "POST",
                data: param, //Data sent to server
                contentType: "application/json; charset=utf-8",
                headers: { 'Token': base64.encode(token) },
                dataType: "json"
            }).success(function (data) {
                deferred.resolve(data);
            }).error(function (response, status) {
                deferred.reject("Status Code: " + status);
            });

            return deferred.promise;
        }
    }
});

HRMSWeb.factory('menuSelectorService', function () {    

    return {
        MenuSelector:  function (menu) {

            $("#noDataFound").hide();
            $("#errorMessage").hide();
            $('[id^="mainmenu"]').each(function () {

                if ($(this).html().indexOf('#' + menu) > 0) {
                    $(this).addClass("active");
                }
                else {
                    $(this).removeClass("active");
                }
            })
        }
    }    
    
});

HRMSWeb.factory('navMenuControllerService', function () {

    return {
        ToggleMenu: function (show) {

            $('[id^="mainmenu"]').each(function () {
                if (show)
                {
                    if ($(this).attr("id") != "mainmenu0") {
                        $(this).show();
                    }
                    else {
                        $(this).hide();
                    }
                }
                else
                {
                    if ($(this).attr("id") != "mainmenu0") {
                        $(this).hide();
                    }
                    else {
                        $(this).show();
                    }
                }
            })
        },
        HideAllMenu: function () {

            $("#noDataFound").hide();
            $("#errorMessage").hide();
            $('[id^="mainmenu"]').each(function () {
                $(this).hide();
            })
        }
    }

});