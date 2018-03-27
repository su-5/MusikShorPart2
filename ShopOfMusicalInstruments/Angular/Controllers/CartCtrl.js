(function () {
    "use strict";

    // controller class definintion
    var cartController = function ($scope, $rootScope, $cookies, cartService) {
        var productsCookie = $cookies.getObject("productToCart");
        $rootScope.loadingShow();
        cartService.getAllToCart(productsCookie).then(function (value) {
                debugger;
            $scope.dataProducts = angular.copy(value);
        },
            function (errorObject) {

            }).finally(function () {
                $rootScope.loadingHide();
            });

       
    };
    angular
        .module("Web.Controllers")
        .controller("cartController", ["$scope", "$rootScope", "$cookies", "cartService", cartController]);
})();