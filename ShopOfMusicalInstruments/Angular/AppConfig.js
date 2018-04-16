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

            $stateProvider.state("mainPage/Cart", {
                url: "/cart",
                templateUrl: "Angular/Views/Cart.html",
                controller: "cartController"
            });

            $stateProvider.state("mainPage/OrderForm", {
                url: "/orderForm",
                templateUrl: "Angular/Views/OrderForm.html",
                controller: "orderFormController"
            });

            $stateProvider.state("mainPage/UserRoom", {
                url: "/userRoom",
                templateUrl: "Angular/Views/UserRoom.html",
                controller: "userRoomController"
            });
        
            $urlRouterProvider.otherwise("/catalog");
        }]);
})();