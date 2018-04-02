(function () {
    "use strict";

    // controller class definintion
    var loginController = function ($scope, $rootScope, registerService, $state, $window) {
        $scope.login = function (data, form) {
            if (!form.$valid) {
                return;
            }
            $rootScope.loadingShow();
            registerService.login(data).then(function (value) {
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
        .controller("loginController", ["$scope", "$rootScope", "registerService", "$state","$window", loginController]);

})();