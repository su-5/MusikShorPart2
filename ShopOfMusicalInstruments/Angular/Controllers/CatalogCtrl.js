(function () {
    "use strict";

    // controller class definintion
    var catalogController = function ($scope, $rootScope, productService, $cookies, $uibModal) {
        $rootScope.loadingShow();
        productService.getAllCatalog().then(function (value) {
            $rootScope.Produkts = value;// angular.copy(value);
            $rootScope.toaster('success', 'Данные загружены', 2000);
            $rootScope.ProduktsFilter = false;
        }, function (errorObject) {
            alert(errorObject);
        }).finally(function () {
            $rootScope.loadingHide();
        });


        $scope.addProductToCart = function (productId) {
            addProductToCart(productId);
        }

        function addProductToCart(productId) {
            //формируем новый json объект
            var newProductId = { id: productId };
            //считываем куки из хранилища productToCart
            var products = $cookies.getObject('productToCart');
            //проверка на наличие данных в куках, если данных нет - возвращается undefined
            if (products === undefined) {
                //если нет данных в куках, то указываем, что products является массивом
                products = [];
            }
            //вызываем функцию checkIsDouble, передаем 2 параметра: массив объектов и новый productId
            if (checkIsDouble(products, productId)) {
                return;
            }
            //проверяем что products не равен null
            if (products !== null) {
                //добавляем новый объект в массив products
                products.push(newProductId);
            }
            //записываем массив в куки
            $cookies.putObject('productToCart', products);
            //вызываем функцию, которая считывает куки и выводит их кол-во id в корзину
            $rootScope.lengthCartProducts();
        }

        function checkIsDouble(products, productId) {
            //узнаем длину массива, если массив пустой, возвращаем false  и работа ф-ции завершается
            if (products.length === 0) {
                return false;
            } else {
                //иначе, делаем цикл переборки элемнтов массива
                for (var i = 0; i < products.length; i++) {
                    //проверяем на дубли
                    if (products[i].id === productId) {
                        $rootScope.toaster("warning", "Этот товар уже в корзине", 2500);
                        return true;
                    }
                }
            }

            return false;
        }


        $scope.FullDesc = function (value) {
            $uibModal.open({
                templateUrl: function () {
                    return 'Angular/ModalWindows/ControlFullDescModalWindow.html';
                },
                size: 'md',
                controller: [
                    '$rootScope', '$scope', '$uibModalInstance', function ($rootScope, $scope, $uibModalInstance) {
                        $scope.product = value;
                        $scope.cancel = function () {
                            $uibModalInstance.dismiss({ $value: 'cancel' });
                        };

                        $scope.addProductToCart = function (productId) {
                            addProductToCart(productId);
                        }
                    }
                ]
            }).result.then();
        }

    };

    // register your controller into a dependent module 
    angular
        .module("Web.Controllers")
        .controller("catalogController", ["$scope", "$rootScope", "productService", "$cookies", "$uibModal", catalogController]);

})();