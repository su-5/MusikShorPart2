(function () {
    "use strict";

    // controller class definintion
    var catalogController = function ($scope, $rootScope, productService) {
        productService.getListProduct().then(function (value) {
           $rootScope.loadingShow();
            $scope.result = angular.copy(value);
        }, function (errorObject) {
            alert(errorObject);
        }).finally(function () {
          $rootScope.loadingHide();
        });
    };

    // register your controller into a dependent module 
    angular
        .module("Web.Controllers")
        .controller("catalogController", ["$scope", "$rootScope","ProductService", catalogController]);

})();