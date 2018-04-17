(function () {
    "use strict";

    // controller class definintion
    var orderFormController = function ($scope, $rootScope, regionService, orderFormService, countryService, cityService, paymentSystemService, $window, $state, $uibModal) {

        var scope = $scope;
        $scope.order = {
            address: "",
            requisites: ""
        }
        var adress = {};
        var paymentSystem = {};

        $scope.send = function (order, orderform) {
            if (!orderform.$valid) {
                return;
            }
            $rootScope.loadingShow();
            var paidOrder = {
                AddressDelivery: adress,
                PaymentRequisite: paymentSystem,
                NumberOrder: $rootScope.numberOrder
            }
            orderFormService.send(paidOrder).then(function (value) {
                if (value) {
                    $rootScope.toaster('success', 'Ваш заказ обработан', 5000);
                    $state.go("mainPage/Catalog");
                    $rootScope.loadingHide();
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

        $scope.openModalAddress = function () {
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
                        $scope.$watch('Address.Country', function (newValue, oldValue) {
                            if (newValue !== undefined) {
                                regionService.getRegionByCountry(newValue.Id).then(function (value) {
                                    $scope.listRegion = angular.copy(value);
                                },
                                    function (errorObject) {

                                    }).finally(function () {
                                        $rootScope.loadingHide();
                                    });
                            }
                        });
                        //получение всех городов
                        $scope.$watch('Address.Region', function (newValue, oldValue) {
                            if (newValue !== undefined) {
                                cityService.getCityByRegion(newValue.Id).then(function (value) {
                                    $scope.listCity = angular.copy(value);
                                },
                                    function (errorObject) {

                                    }).finally(function () {
                                        $rootScope.loadingHide();
                                    });
                            }
                        });

                        $scope.AddAddressForm = function (Address, addressForm) {
                            if (!addressForm.$valid) {
                                return;
                            }
                            adress = Address;
                            scope.order.address = Address.Country.Name + " ;" + Address.Region.Name + " ;"
                                + Address.City.Name + " ;" + Address.Street + " ;" + Address.House + " ;" + Address.Flat;
                            $scope.cancel();
                        }
                    }
                ]
            }).result.then(postClose, postClose);
        }


        $scope.openPaymentRequisites = function () {
            $scope.asideState = {
                open: true
            };

            function postClose() {
                $scope.asideState.open = false;
            }

            $uibModal.open({
                templateUrl: function () {
                    return "Angular/ModalWindows/ControlOpenPaymentRequisites.html";
                },
                controller: [
                    '$rootScope', '$scope', '$uibModalInstance', function ($rootScope, $scope, $uibModalInstance) {
                        $rootScope.loadingShow();
                        // закрытие модалки
                        $scope.cancel = function () {
                            $uibModalInstance.dismiss({ $value: 'cancel' });
                        };
                        //получение всех платежных систем
                        paymentSystemService.getAll().then(function (value) {
                            $scope.listPaymentSystem = angular.copy(value);
                        },
                            function (errorObject) {

                            }).finally(function () {
                                $rootScope.loadingHide();
                            });

                        $scope.AddPaymentForm = function (Payment, paymentForm) {
                            debugger;
                            if (!paymentForm.$valid) {
                                return;
                            }
                            paymentSystem = Payment;
                            scope.order.requisites = Payment.PaymentSystems.NamePaymentSystems + ";" + Payment.NumberAccount + ";" +
                                Payment.NumberCard + ";" + Payment.UserName;
                            $scope.cancel();
                        };
                    }
                ]
            }).result.then(postClose, postClose);
        };
    };


    // register your controller into a dependent module 
    angular
        .module("Web.Controllers")
        .controller("orderFormController", ["$scope", "$rootScope", "regionService", "orderFormService", "countryService", "cityService", "paymentSystemService", "$window", "$state", "$uibModal", orderFormController]);

})();