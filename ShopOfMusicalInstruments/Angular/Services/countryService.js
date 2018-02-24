(function () {
    "use strict";

    function countryService($cookies, $http, $rootScope, $q) {
        this.getAll = function () {
            var deferred = $q.defer();
            $http.get('api/Countries')
                .then(function (response) {
                    deferred.resolve(response.data);
                }).catch(function onError(response) {
                    deferred.reject(response.data);
                });
            return deferred.promise;
        };

        this.add = function (country) {
            var newCountry = { Name: country.Name, Description: country.Description };
            var deferred = $q.defer();
            $http.post("api/Countries", newCountry)
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
        .service("countryService", ["$cookies", "$http", "$rootScope", "$q", countryService]);

})(); 