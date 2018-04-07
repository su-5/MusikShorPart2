(function () {
    "use strict";

    function orderService($cookies, $http, $rootScope, $q) {
        this.savePreOrder = function (preData) {
            var data = preData;
            var deferred = $q.defer();
            $http.post("api/Orders/savePreOrder", data)
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
        .service("orderService", ["$cookies", "$http", "$rootScope", "$q", orderService]);
})();