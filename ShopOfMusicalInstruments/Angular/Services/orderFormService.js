(function () {
    "use strict";

    function orderFormService($cookies, $http, $rootScope, $q) {
        this.send = function (process) {
            var data = process;
            var deferred = $q.defer();
            $http.post("api/Orders/order", data)
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
        .service("orderFormService", ["$cookies", "$http", "$rootScope", "$q", orderFormService]);
})();