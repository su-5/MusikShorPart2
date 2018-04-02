(function () {
    "use strict";

    // controller class definintion
    var registrationController = function ($scope, $rootScope, registerService, $window, $state) {

        $scope.registration = function (data, form) {
            if (!form.$valid) {
                return;
            }
            $rootScope.loadingShow();
            registerService.registration(data).then(function (value) {
                $rootScope.toaster('success', 'Регистрация успешно выполнена', 5000);
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
        .controller("registrationController", ["$scope", "$rootScope", "registerService", "$window","$state", registrationController]);

})();