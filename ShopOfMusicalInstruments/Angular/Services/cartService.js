(function () {
    "use strict";

    function cartService($cookies, $http, $rootScope, $q) {//cookiesRecordDb
        this.getAllToCart = function (productId) {
            var data = productId ;
            var deferred = $q.defer();
            $http.post("api/Cart/GetAllToCart", data)
                .then(function (response) {
                    deferred.resolve(response.data);
                }).catch(function onError(response) {
                    deferred.reject(response.data);
                });
            return deferred.promise;
        };

        this.cookiesRecordDb = function (productId,userMail) {
            var data = {}
            var deferred = $q.defer();
            $http.post("api/Cart/cookiesRecordDb", data)
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
        .service("cartService", ["$cookies", "$http", "$rootScope", "$q", cartService]);
})();