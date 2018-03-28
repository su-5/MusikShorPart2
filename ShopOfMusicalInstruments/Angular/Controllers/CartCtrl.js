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
            enableFiltering: true,
            gridColumnFooterHeight: 20,
            enableRowSelection: false,
            enableRowHeaderSelection: true,
            enableSelectAll: true,
            noUnselect: false,
            multiSelect: true,
            columnDefs: [
                {
                    field: 'Brand.Name',
                    width: "15%",
                    displayName: 'Бренд',
                    cellTemplate: '<p style="margin-left:15px;">{{row.entity.Brand.Name}}</p>'
                },
                {
                    field: 'Name',
                    width: "15%",
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
                    width: "10%",
                    displayName: "Категория",
                    cellTemplate: '<p style="margin-left:15px;">{{row.entity.Subcategory.Category.Name}}</p>'
                },
                {
                    field: 'NumberProduct',
                    width: "15%",
                    displayName: 'Количество (шт)',
                    cellTemplate: 'Angular/Templates/NumberProductCart.html'
                },
                {
                    field: 'Price',
                    width: "9%",
                    displayName: 'Цена',
                    cellTemplate: '<p style="margin-left:15px;">{{row.entity.Price}}</p>'
                },
                //{
                //    field: 'buttons_edit_del',
                //    displayName: "Количество",
                //    width: "12%",
                //    visible: true,
                //    cellTemplate: "",
                //},
                {
                    field: 'selectProduct',
                    width: "15%",
                    displayName: 'Включено в заказ',
                    cellTemplate: 'Angular/Templates/WindowCheckBox.html'
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

            }).finally(function () {
                $rootScope.loadingHide();
            });



    };
    angular
        .module("Web.Controllers")
        .controller("cartController", ["$scope", "$rootScope", "$cookies", "cartService", cartController]);
})();