(function () {
    "use strict";

    // controller class definintion
    var loginController = function ($scope, $rootScope, registerService, $state) {
        $scope.login = function (data, form) {
            if (!form.$valid) {
                return;
            }
            $rootScope.loadingShow();
            registerService.login(data).then(function (value) {
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
        .controller("loginController", ["$scope", "$rootScope", "registerService","$state", loginController]);

})();