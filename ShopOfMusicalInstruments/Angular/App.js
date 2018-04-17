(function () {
    "use strict";

    angular.module("Web.Services", []);
    angular.module("Web.Controllers", []);
    angular.module("Web.Directives", []);
    angular.module("Web.Externals", ["ui.router", "ngCookies", "ngTouch", "ngAnimate", "toaster", "ui.grid", "ui.grid.selection", 'ui.grid.resizeColumns', 'ui.grid.moveColumns', 'ui.grid.cellNav', 'ui.grid.autoResize', 'ui.grid.pagination', 'ui.grid.grouping', 'ui.grid.expandable', 'ui.grid.edit', 'ui.grid.rowEdit']);

    var app = angular.module("Web", ["Web.Services", "Web.Directives", "Web.Externals", "Web.Controllers", "ui.bootstrap"]);

    app.run(["$rootScope", "$location", "$http", "$state", "$stateParams", "$sce", "loadingService", "toaster", "$cookies", "productService", "$window", "cartService","userService",
        function ($rootScope, $location, $http, $state, $stateParams, $sce, loadingService, toaster, $cookies, productService, $window, cartService, userService) {
            $rootScope.loadingShow = function () {
                $rootScope.loadingIsShow = loadingService.show(); // loading
            };

            $rootScope.loadingHide = function () {
                $rootScope.loadingIsShow = loadingService.hide();
            };

            $rootScope.toaster = function (type, message, timeout, clickHandler) {
                toaster.pop(type, null, message, timeout, null, clickHandler);
            };

            $rootScope.lengthCartProducts = function () {
                var cookies = $cookies.getObject('productToCart');
                if (cookies === undefined) {
                    $rootScope.lengthCart = 0;
                } else {
                    if (cookies !== null) {
                        $rootScope.lengthCart = cookies.length;
                    }

                }
            }

            $rootScope.filterData = function (categoryId, subCategoryId, flag) {
                $rootScope.loadingShow();
                productService.getProductById(categoryId, subCategoryId, flag).then(function (value) {
                    $rootScope.Produkts = value;
                    $rootScope.ProduktsFilter = flag;
                }, function (errorObject) {
                }).finally(function () {
                    $rootScope.loadingHide();
                });
            }

            $rootScope.exitSystem = function () {
                productService.exitSystem().then(function (value) {
                    resetCart();
                    $window.location.reload();
                    $state.go("mainPage/Catalog");
                }, function (errorObject) {

                }).finally(function () {
                    $rootScope.loadingHide();
                });
            }

            function resetCart() {
                $cookies.remove('productToCart');
            }

            $rootScope.authenticationUser = function () {
                $rootScope.authenticationUserName = angular.element('#userName').val();
                getUserName();
                $rootScope.authentication = angular.element('#authentication').val();
                if ($rootScope.authentication === 'value') {
                    $rootScope.auchUser = true;
                } else {
                    $rootScope.auchUser = false;
                }
            }

            function getUserName() {
                userService.getUserName($rootScope.authenticationUserName).then(function(value) {
                        $rootScope.userName = value;
                    },
                    function(errorObject) {
                        $rootScope.toaster('error', errorObject.Message, 9000);
                        for (var i = 0; i < errorObject.ModelState.error.length; i++) {
                            $rootScope.toaster('error', errorObject.ModelState.error[i], 9000);
                        }
                    }).finally(function() {
                   // $rootScope.loadingHide();
                });
            }

            //считываем текущие куки и записываем из в БД
                $rootScope.cookiesRecordDb = function () {
                    var productsCookie = $cookies.getObject('productToCart');
                    cookiesRecordDb(productsCookie);
                }
                // считываем продукты в корзину из БД
                $rootScope.getAllProductCartInDataBase = function () {
                    $rootScope.loadingShow();
                    cartService.getAllProductCartInDataBase($rootScope.authenticationUserName).then(function (value) {

                    },
                        function (errorObject) {
                            $rootScope.toaster('error', errorObject.Message, 9000);
                            for (var i = 0; i < errorObject.ModelState.error.length; i++) {
                                $rootScope.toaster('error', errorObject.ModelState.error[i], 9000);
                            }
                        }).finally(function () {
                            $rootScope.loadingHide();
                        });
                }

                function cookiesRecordDb(cookies) {
                    //$rootScope.loadingShow();
                    //cartService.cookiesRecordDb(cookies, $rootScope.authenticationUserName).then(function (value) {
                    //    if (value) {
                    //        resetCart();
                    //        $rootScope.getAllProductCartInDataBase();
                    //    }

                    //},
                    //    function (errorObject) {
                    //        $rootScope.toaster('error', errorObject.Message, 9000);
                    //        for (var i = 0; i < errorObject.ModelState.error.length; i++) {
                    //            $rootScope.toaster('error', errorObject.ModelState.error[i], 9000);
                    //        }
                    //    }).finally(function () {
                    //        $rootScope.loadingHide();
                    //    });
                }

                $rootScope.numberOrder = "";

                //вызываем функцию, которая считывает куки и выводит их кол-во id в корзину
                $rootScope.lengthCartProducts();
                $rootScope.authenticationUser();
                $rootScope.ProduktsFilter = false;
                $rootScope.siteFilter = true;
                //запись куки в бд
                $rootScope.cookiesRecordDb();
            }
    ]);

})();