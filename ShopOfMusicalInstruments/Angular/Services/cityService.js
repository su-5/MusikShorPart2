(function () {
    "use strict";

    function cityService($cookies, $http, $rootScope, $q) {
        this.getCityByRegion = function (id) {
            var deferred = $q.defer();
            $http.get(`api/City/getCityByRegion?id=${id}`)
                .then(function (response) {
                    deferred.resolve(response.data);
                }).catch(function onError(response) {
                    deferred.reject(response.data);
                });
            return deferred.promise;
        };
    };

    angular
        .module("Web.Services")
        .service("cityService", ["$cookies", "$http", "$rootScope", "$q", cityService]);
})();