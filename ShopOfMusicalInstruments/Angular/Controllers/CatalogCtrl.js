(function () {
    "use strict";

    // controller class definintion
    var catalogController = function ($scope, $rootScope, productService, $cookies) {
        productService.getAllCatalog().then(function (value) {
           $rootScope.loadingShow();
            $scope.result = angular.copy(value);
            $rootScope.toaster('success','Данные загружены',15000);
        }, function (errorObject) {
            alert(errorObject);
        }).finally(function () {
          $rootScope.loadingHide();
            });

        $scope.addProductToCart = function (produkt) {
            //0 считывает текущие куки productToCart
            var productsId = $cookies.getObject('productToCart');
            //1 сравление на дубоикаты id-шников
            //2 сфотмировать json obj из 2-х и болеее добавляемых позиций (id-щников)
            //3 записать сфотмированый json obj в куки.
            var event = {
                title: "erwewtwet",
                date: "11111"
            };
           
         var x =   $cookies.putObject('productToCart', event);

           
        }
    };

    // register your controller into a dependent module 
    angular
        .module("Web.Controllers")
        .controller("catalogController", ["$scope", "$rootScope", "productService","$cookies", catalogController]);

})();