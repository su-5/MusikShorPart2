(function () {
    "use strict";

    angular
        .module("Web")
        .config(["$stateProvider", "$urlRouterProvider", "$locationProvider", function ($stateProvider, $urlRouterProvider) {
           
            $stateProvider.state("mainPage/Catalog", {
                url: "/catalog",
                templateUrl: "Angular/Views/Catalog.html",
                controller: "catalogController"
            });

            $stateProvider.state("mainPage/AdminPanel", {
                url: "/adminPanel",
                templateUrl: "Angular/Views/AdminPanel.html",
                controller: "adminController"
            });

            $stateProvider.state("mainPage/Login", {
                url: "/login",
                templateUrl:"Angular/Views/Login.html",
                controller: "loginController"
            });

            $stateProvider.state("mainPage/Registration", {
                url: "/registration",
                templateUrl:"Angular/Views/Registration.html",
                controller: "registrationController"
            });

        
            $urlRouterProvider.otherwise("/catalog");
        }]);
})();