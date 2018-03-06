(function () {
    "use strict";

    // controller class definintion
    var loginController = function ($scope, $rootScope) {
       
    };

    // register your controller into a dependent module 
    angular
        .module("Web.Controllers")
        .controller("loginController", ["$scope", "$rootScope", loginController]);

})();