HRMSWeb.factory('mainService', function ($http, $q) {
    return {
        PostData: function (URL, param) {
            var deferred = $q.defer();
            $http({
                url: URL,
                crossDomain: true,
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