(function () {
    "use strict";

    function registerService($cookies, $http, $rootScope, $q) {

        this.registration = function (dataUser) {
            var model = dataUser;
            var deferred = $q.defer();
            $http.post("api/Account/Register", model)
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
        .service("registerService", ["$cookies", "$http", "$rootScope", "$q", registerService]);

})();