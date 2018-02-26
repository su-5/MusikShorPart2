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

            $urlRouterProvider.otherwise("/catalog");
        }]);
})();