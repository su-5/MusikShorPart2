(function () {
    "use strict";

    // controller class definintion
    var registrationController = function ($scope, $rootScope, registerService, $state) {

        $scope.registration = function (data, form) {
            if (!form.$valid) {
                return;
            }
            $rootScope.loadingShow();
            registerService.registration(data).then(function (value) {
                $rootScope.toaster('success', 'Регистрация успешно выполнена', 5000);
                    $rootScope.authentication = angular.element('#authentication').val();
                    $state.go("mainPage/OrderForm"); 
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
        .controller("registrationController", ["$scope", "$rootScope", "registerService","$state", registrationController]);

})();