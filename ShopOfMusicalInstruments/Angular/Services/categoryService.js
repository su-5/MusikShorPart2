(function () {
    "use strict";

    function categoryService($cookies, $http, $rootScope, $q) {
        this.getAll = function () {
            var deferred = $q.defer();
            $http.get("api/Categories")
                .then(function (response) {
                    deferred.resolve(response.data);
                }).catch(function onError(response) {
                    deferred.reject(response.data);
                });
            return deferred.promise;
        };

        this.add = function (category) {
            var newCategory = {Name:category.Name};
            var deferred = $q.defer();
            $http.post("api/Categories", newCategory)
                .then(function (response) {
                    deferred.resolve(response.data);
                }).catch(function onError(response) {
                    deferred.reject(response.data);
                });
            return deferred.promise;
        };

        this.edit = function (gridData) {
            var data = gridData;
            var deferred = $q.defer();
            $http.put("api/Categories", data)
                .then(function (response) {
                    deferred.resolve(response.data);
                }).catch(function onError(response) {
                    deferred.reject(response.data);
                });
            return deferred.promise;
        };

        this.delete = function (categoryId) {
            var id = categoryId;
            var deferred = $q.defer();
            $http.delete("api/Categories?Id=" + id)
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
        .service("categoryService", ["$cookies", "$http", "$rootScope", "$q", categoryService]);

})();