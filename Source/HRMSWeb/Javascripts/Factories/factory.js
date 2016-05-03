HRMSWeb.factory('mainService', function ($http, $q) {
    return {
        PostData: function (URL, param) {
            var deferred = $q.defer();
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

HRMSWeb.factory('userData', function () {

    var userdata;
    return {
        SetUser: function (data) {
            console.log(data);
            userdata = data;
        },
        GetUser: function(){
            console.log("asasasa:" + userdata);
            return userdata;
        }
    }

});