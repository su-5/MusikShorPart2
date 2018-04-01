(function () {
    "use strict";

    // controller class definintion
    var orderFormController = function ($scope, $rootScope) {

    };

    // register your controller into a dependent module 
    angular
        .module("Web.Controllers")
        .controller("orderFormController", ["$scope", "$rootScope", orderFormController]);

})();