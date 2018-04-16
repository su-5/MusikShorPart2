(function () {
    "use strict";

    // controller class definintion
    var orderFormController = function ($scope, $rootScope, regionService, orderFormService, countryService, $window, $state, $uibModal) {
        $scope.send = function (data,form) {
            if (!form.$valid) {
                return;
            }
            $rootScope.loadingShow();
            orderFormService.send(data).then(function (value) {
                $rootScope.toaster('success', 'Ваш заказ обработан', 5000);
                $window.location.reload();
                $state.go("mainPage/Catalog");
            },
                function (errorObject) {

                }).finally(function () {
                    $rootScope.loadingHide();
                });
        }

        $scope.openModalAddress = function() {
            $scope.asideState = {
                open: true
            };

            function postClose() {
                $scope.asideState.open = false;
            }

            $uibModal.open({
                templateUrl: function () {
                    return "Angular/ModalWindows/ControlOpenModalAddress.html";
                },
                controller: [
                    '$rootScope', '$scope', '$uibModalInstance', function ($rootScope, $scope, $uibModalInstance) {
                        $rootScope.loadingShow();
                        // закрытие модалки
                        $scope.cancel = function () {
                            $uibModalInstance.dismiss({ $value: 'cancel' });
                        };
                        //получение всех стран
                        countryService.getAll().then(function (value) {
                                $scope.listCountry = angular.copy(value);
                            },
                            function (errorObject) {

                            }).finally(function () {
                            $rootScope.loadingHide();
                            });
                        //watch для countryID
                        $scope.$watch('Address.CountryId', function (newValue, oldValue) {
                            if (newValue !== undefined) {
                                regionService.getRegionByCountry(newValue).then(function (value) {
                                        $scope.listRegion = angular.copy(value);
                                    },
                                    function (errorObject) {

                                    }).finally(function () {
                                    $rootScope.loadingHide();
                                });
                            }
                        });
                      //получение всех городов
                        cityService.getAll().then(function (value) {
                                $scope.listCity = angular.copy(value);
                            },
                            function (errorObject) {

                            }).finally(function () {
                            $rootScope.loadingHide();
                        });
                    }
                ]
            }).result.then(postClose, postClose);
        }
    };


    // register your controller into a dependent module 
    angular
        .module("Web.Controllers")
        .controller("orderFormController", ["$scope", "$rootScope", "regionService", "orderFormService","countryService", "$window", "$state","$uibModal", orderFormController]);

})();