(function () {
    "use strict";

    // controller class definintion
    var cartController = function ($scope, $rootScope, $cookies, cartService) {
        var productsCookie = $cookies.getObject("productToCart");
        $rootScope.loadingShow();
        $rootScope.siteFilter = false;

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
                    width: "24%",
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
                    width: "11%",
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

        cartService.getAllToCart(productsCookie).then(function (value) {
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



    };
    angular
        .module("Web.Controllers")
        .controller("cartController", ["$scope", "$rootScope", "$cookies", "cartService", cartController]);
})();