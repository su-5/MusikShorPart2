(function () {
    "use strict";

    function subcategoryService($cookies, $http, $rootScope, $q) {
        this.getAll = function () {
            var deferred = $q.defer();
            $http.get("api/Subcategories")
                .then(function (response) {
                    deferred.resolve(response.data);
                }).catch(function onError(response) {
                    deferred.reject(response.data);
                });
            return deferred.promise;
        };

        this.add = function (subcategory) {
            var newSubcategory = { Name: subcategory.Name, Description: subcategory.Description, CategoriesId: subcategory.IDcategory};
            var deferred = $q.defer();
            $http.post("api/Subcategories", newSubcategory)
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
        .service("subcategoryService", ["$cookies", "$http", "$rootScope", "$q", subcategoryService]);

})(); 