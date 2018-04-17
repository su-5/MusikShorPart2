(function () {
    "use strict";

    // controller class definintion
    var cartController = function ($scope, $rootScope, $cookies, cartService, $window, $state, orderService) {
        var productsCookie = $cookies.getObject('productToCart');
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


        $scope.totalBYNProduct = function () {
            $scope.totalBYN = 0;
            angular.forEach($scope.gridCart.data,
                function (value) {
                    if (value.SelectProductForCart) {
                        $scope.totalBYN += value.SelectNumber * value.Price;
                    }

                });
        };

        $scope.selectProductForCartCheckBox = function () {
            $scope.countingProducts();
            $scope.totalBYNProduct();// общая сумма
        }

        $scope.incWork = function (value, row) {
            if (value) {
                row.entity.SelectNumber = row.entity.SelectNumber + 1;
            } else {
                row.entity.SelectNumber = row.entity.SelectNumber - 1;
            }
            $scope.totalBYNProduct();// общая сумма
            $scope.countingProducts();
        }

        $scope.deleteRowInCart = function (id) {
            $rootScope.loadingShow();
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
            $rootScope.loadingShow();
            if (cookies === undefined) {
                $state.go("mainPage/Catalog");
            }
            if (cookies.length === 0) {
                $state.go("mainPage/Catalog");
            }

            cartService.getAllToCart(cookies).then(function (value) {
                $scope.gridCart.data = value;
                $scope.countingProducts();// кол-во товара
                $scope.totalBYNProduct();// общая сумма
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

        $scope.countingProducts = function () {
            $scope.totalProduct = 0;
            for (var i = 0; i < $scope.gridCart.data.length; i++) {
                if ($scope.gridCart.data[i].SelectProductForCart) {
                    $scope.totalProduct += $scope.gridCart.data[i].SelectNumber;
                }
            }
        }

        $scope.returnToCatalog = function () {
            $state.go("mainPage/Catalog");
        }

        $scope.orderForm = function () {
            $rootScope.loadingShow();
            if ($rootScope.authentication === "value") {
                preOrder();
                $state.go("mainPage/OrderForm");
            } else {
                $rootScope.toaster('info', 'Вы не зарегистрированы.  Только зарегистрированые пользователи могут совершать покупки.', 0);
                $state.go("mainPage/Registration");
                $rootScope.loadingHide();
            }
        }

        function preOrder() {
            var masProdukt = [];
            // формируем масив выбраных товаров
            for (var i = 0; i < $scope.gridCart.data.length; i++) {
                if ($scope.gridCart.data[i].SelectProductForCart) {
                    masProdukt.push({
                        ProductId: $scope.gridCart.data[i].Id,
                        AmountProduct: $scope.gridCart.data[i].SelectNumber
                    });
                }
            }

            // формируем обьект preOrder для отправки на сервер
            var preOrder = {
                Amount: $scope.totalProduct, // кол-во выбраных товаров
                OrderSum: $scope.totalBYN, // иговая сумма
                TypeOrdersId: 1, // Ожидание оплаты
                DateShapingOrders: new Date(),
                OrderListProducts: masProdukt,
                UserEmail: $rootScope.authenticationUserName
            }

            //передача данных preOrder на сервер
            orderService.savePreOrder(preOrder).then(function (value) {
                if (value !== 0) {

                    $rootScope.toaster('info', "Ваш заказ № " + value + " успешно сформирован со статусом неоплачен", 3000);
                    debugger;
                    $rootScope.numberOrder = value;
                }
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
        .controller("cartController", ["$scope", "$rootScope", "$cookies", "cartService", "$window", "$state", "orderService", cartController]);
})();