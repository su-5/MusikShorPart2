(function () {
    "use strict";

    // controller class definintion
    var userRoomController = function ($scope, $rootScope, $window, userRoomService) {
        angular.element($window).bind('resize', function () {

            $scope.mh = $window.innerHeight - 110 + "px";
            $scope.$digest();
        });
        $scope.gridUserRoom = {
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
                    width: "18%",
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
                    width: "9%",
                    displayName: 'Цена за 1(шт)',
                    cellTemplate: '<div align="center">{{row.entity.Price}}</div>'
                },

                {
                    field: 'SelectProductForCart',
                    width: "6%",
                    displayName: 'В заказе',
                    cellTemplate: 'Angular/Templates/SelectProductForCart.html'
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
    };

    // register your controller into a dependent module 
    angular
        .module("Web.Controllers")
        .controller("userRoomController", ["$scope", "$rootScope", "$window", "userRoomService", userRoomController]);

})();