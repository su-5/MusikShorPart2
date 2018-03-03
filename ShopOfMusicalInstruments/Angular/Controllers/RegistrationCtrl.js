(function () {
    "use strict";

    // controller class definintion
    var registrationController = function ($scope, $rootScope, registerService) {

        $scope.registration = function (data, form) {
            if (!form.$valid) {
                return;
            }
            $rootScope.loadingShow();
            registerService.registration(data).then(function (value) {

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
        .controller("registrationController", ["$scope", "$rootScope", "registerService", registrationController]);

})();