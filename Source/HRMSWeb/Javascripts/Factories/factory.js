HRMSWeb.factory('mainService', function ($http, $q, base64) {
    return {
        PostData: function (URL, param, userinfo) {
            var deferred = $q.defer();
            $http.defaults.headers.common['Authorization'] = 'Basic ' + base64.encode(userinfo);
            $http({
                url: URL,
                method: "POST",
                data: param, //Data sent to server
                contentType: "application/json; charset=utf-8",
                dataType: "json"
            }).success(function (data) {
                deferred.resolve(data);
            }).error(function (e) {
                deferred.reject();
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