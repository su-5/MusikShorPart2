(function() {
    "use strict";

    angular.module("Web.Services", []);
    angular.module("Web.Controllers", []);
    angular.module("Web.Directives", []);
    angular.module("Web.Externals", ["ui.router", "ngCookies", "ngTouch", "ngAnimate", "toaster", "ui.grid", "ui.grid.selection", 'ui.grid.resizeColumns', 'ui.grid.moveColumns', 'ui.grid.cellNav', 'ui.grid.autoResize', 'ui.grid.pagination', 'ui.grid.grouping', 'ui.grid.expandable', 'ui.grid.edit', 'ui.grid.rowEdit']);

    var app = angular.module("Web", ["Web.Services", "Web.Directives", "Web.Externals", "Web.Controllers", "ui.bootstrap"]);

    app.run(["$rootScope", "$location", "$http", "$state", "$stateParams", "$sce", "loadingService", "toaster", "$cookies", "productService",
        function($rootScope, $location, $http, $state, $stateParams, $sce, loadingService, toaster, $cookies, productService) {
            $rootScope.loadingShow = function() {
                $rootScope.loadingIsShow = loadingService.show(); // loading
            };

            $rootScope.loadingHide = function() {
                $rootScope.loadingIsShow = loadingService.hide();
            };

            $rootScope.toaster = function(type, message, timeout, clickHandler) {
                toaster.pop(type, null, message, timeout, null, clickHandler);
            };

            $rootScope.lengthCartProducts = function() {
                var cookies = $cookies.getObject('productToCart');
                if (cookies === undefined) {
                    $rootScope.lengthCart = 0;
                } else {
                    if (cookies !== null) {
                        $rootScope.lengthCart = cookies.length;
                    }

                }
            }

            $rootScope.filterData = function(categoryId, subCategoryId, flag) {
                $rootScope.loadingShow();
                productService.getProductById(categoryId, subCategoryId, flag).then(function(value) {
                    $rootScope.Produkts = value;
                    $rootScope.ProduktsFilter = flag;
                }, function(errorObject) {
                    //    alert(errorObject);
                }).finally(function() {
                    $rootScope.loadingHide();
                });
            }

            //вызываем функцию, которая считывает куки и выводит их кол-во id в корзину
            $rootScope.lengthCartProducts();
            $rootScope.ProduktsFilter = false;
            $rootScope.siteFilter = true;
        }
    ]);

})();