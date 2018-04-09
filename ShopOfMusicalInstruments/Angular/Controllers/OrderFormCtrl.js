(function () {
    "use strict";

    // controller class definintion
    var orderFormController = function ($scope, $rootScope, orderFormService, $window, $state) {
        $scope.send = function (data,form) {
            if (!form.$valid) {
                return;
            }
            $rootScope.loadingShow();
            orderFormService.send(data).then(function (value) {
                $rootScope.toaster('success', 'Ваш заказ обработан', 5000);
                $window.location.reload();
                $state.go("mainPage/Catalog");
            },
                function (errorObject) {

                }).finally(function () {
                    $rootScope.loadingHide();
                });
        }
    };


    // register your controller into a dependent module 
    angular
        .module("Web.Controllers")
        .controller("orderFormController", ["$scope", "$rootScope", "orderFormService", "$window", "$state", orderFormController]);

})();