(function () {
    "use strict";

    function regionService($cookies, $http, $rootScope, $q) {
        this.getRegionByCountry = function (id) {
            var deferred = $q.defer();
            $http.get(`api/Region/getRegionByCountry?id=${id}`)
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
        .service("regionService", ["$cookies", "$http", "$rootScope", "$q", regionService]);
})();