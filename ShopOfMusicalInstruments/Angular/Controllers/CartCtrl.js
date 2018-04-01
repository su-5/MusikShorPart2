(function () {
    "use strict";

    // controller class definintion
    var cartController = function ($scope, $rootScope, $cookies, cartService, $window, $state) {
        var productsCookie = $cookies.getObject("productToCart");
        $rootScope.loadingShow();
        $rootScope.siteFilter = false;

        angular.element($window).bind('resize', function () {

            $scope.mh = $window.innerHeight - 110 + 'px';
            // manuall $digest required as resize event
            // is outside of angular
            $scope.$digest();
        });

        $scope.gridCart = {
            enableColumnResizing: true,
            showGridFooter: false,
            enableHorizontalScrollbar: 0,
            enableVerticalScrollbar: 1,
            enableColumnMenus: false,
            showColumnFooter: false,
            enableFiltering: false,
            gridColumnFooterHeight: 20,
            enableRowSelection: false,
            enableRowHeaderSelection: false,
            enableSelectAll: false,
            noUnselect: false,
            multiSelect: false,
            columnDefs: [
                {
                    field: 'Brand.Name',
                    width: "18%",
                    displayName: 'Бренд',
                    cellTemplate: '<p style="margin-left:15px;">{{row.entity.Brand.Name}}</p>'
                },
                {
                    field: 'Name',
                    width: "22%",
                    displayName: "Название инструмента",
                    cellTemplate: '<p style="margin-left:15px;">{{row.entity.Name}}</p>'
                },
                {
                    field: 'Country.Name',
                    width: "10%",
                    displayName: 'Страна',
                    cellTemplate: '<p style="margin-left:15px;">{{row.entity.Country.Name}}</p>'
                },
                {
                    field: 'Subcategory.Name',
                    width: "13%",
                    displayName: "Подкатегория",
                    cellTemplate: '<p style="margin-left:15px;">{{row.entity.Subcategory.Name}}</p>'
                },
                {
                    field: 'Subcategory.Category.Name',
                    filter: true,
                    width: "10%",
                    displayName: "Категория",
                    cellTemplate: '<p style="margin-left:15px;">{{row.entity.Subcategory.Category.Name}}</p>'
                },
                {
                    field: 'NumberProduct',
                    width: "13%",
                    displayName: 'Количество (шт)',
                    cellTemplate: 'Angular/Templates/NumberProductCart.html'
                },
                {
                    field: 'Price',
                    width: "5%",
                    displayName: 'Цена',
                    cellTemplate: '<p style="margin-left:15px;">{{row.entity.Price}}</p>'
                },

                {
                    field: 'selectProduct',
                    width: "6%",
                    displayName: 'В заказе',
                    cellTemplate: 'Angular/Templates/WindowCheckBox.html'
                },
                {
                    field: 'deleteCart',
                    width: "5%",
                    displayName: '',
                    cellTemplate: 'Angular/Templates/DeleteCart.html'
                }
            ],
            onRegisterApi: function (gridApi) {
                $scope.gridApi = gridApi;
                $scope.gridApi.selection.on.rowSelectionChanged($scope,
                    function (row) {
                    });
            }

        };

        $scope.total = function () {
            var total = 0;
            angular.forEach($scope.NumberProduct,
                function (value) {
                    total += value.NumberProduct * value.Price;
                });
            return total;
        };

        $scope.incWork = function (value,inc) {
            if (value) {
                $scope.inc = inc + 1;
            } else {
                $scope.inc = inc - 1; 
            }
        }

        $scope.deleteRowInCart = function (id) {
            var index = 0;
            for (var i = 0; i < productsCookie.length; i++) {
                if (productsCookie[i].id === id) {
                    index = i;
                    break;
                } 
            }

            productsCookie.splice(index, 1);
            $cookies.putObject('productToCart', productsCookie);
            getProductForCookies(productsCookie);
        }

        function getProductForCookies(cookies) {
            if (cookies === undefined) {
                $state.go("mainPage/Catalog");
            }
            if (cookies.length === 0) {
                $state.go("mainPage/Catalog");
            }
           
            cartService.getAllToCart(cookies).then(function (value) {
                    $scope.gridCart.data = value;
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


        getProductForCookies(productsCookie);

    };
    angular
        .module("Web.Controllers")
        .controller("cartController", ["$scope", "$rootScope", "$cookies", "cartService", "$window","$state", cartController]);
})();