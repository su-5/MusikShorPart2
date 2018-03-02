(function () {
    "use strict";

    // controller class definintion
    var loginController = function ($scope, $rootScope) {
        //productService.getAllCatalog().then(function (value) {
        //    $rootScope.loadingShow();
        //    $scope.result = angular.copy(value);
        //}, function (errorObject) {
        //    alert(errorObject);
        //}).finally(function () {
        //    $rootScope.loadingHide();
        //});
    };

    // register your controller into a dependent module 
    angular
        .module("Web.Controllers")
        .controller("loginController", ["$scope", "$rootScope", loginController]);

})();