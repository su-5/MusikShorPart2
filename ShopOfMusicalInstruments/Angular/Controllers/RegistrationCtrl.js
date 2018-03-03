(function () {
    "use strict";

    // controller class definintion
    var registrationController = function ($scope, $rootScope) {

    };

    // register your controller into a dependent module 
    angular
        .module("Web.Controllers")
        .controller("registrationController", ["$scope", "$rootScope", registrationController]);

})();