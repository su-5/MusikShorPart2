(function () {
    "use strict";

    // controller class definintion
    var adminController = function ($scope, $rootScope, $uibModal, adminService, countryService, numberstringService, subcategoryService) {

        //Modal Window для брендов 
        $scope.openList = function () {
            $scope.asideState = {
                open: true
            };

            function postClose() {
                $scope.asideState.open = false;
            }

            $uibModal.open({
                templateUrl: function () {
                    return 'Angular/ModalWindows/ControlBrendModalMindow.html';
                },
                size: 'lg',
                controller: [
                    '$rootScope', '$scope', '$uibModalInstance', function ($rootScope, $scope, $uibModalInstance) {
                       // bootbox.alert("This is the default alert!");
                        $scope.gridBrands = {  
                            enableColumnResizing: true,
                            showGridFooter: true,
                            enableHorizontalScrollbar: 0,
                            enableVerticalScrollbar: 1,
                            enableColumnMenus: false,
                            showColumnFooter: false,
                            enableFiltering: false,
                            gridColumnFooterHeight: 20,
                            enableRowSelection: true,
                            enableRowHeaderSelection: false,
                            noUnselect: false,
                            multiSelect: false,
                            rowHeight: 22,
                            columnDefs: [
                                {
                                    field: 'Name',
                                    width: '50%',
                                    displayName: 'Название',
                                    cellTemplate: '<p style="margin-left:15px;">{{row.entity.Name}}</p>'
                                },
                                {
                                    field: 'Description',
                                    width: '45%',
                                  //  enableCellEdit: false,
                                    displayName: 'Описание',
                                    cellTemplate: '<p style="margin-left:15px;" >{{row.entity.Description}}</p>'
                                },
                                {
                                    field: 'buttons_edit_del',
                                    displayName: '',
                                    visible: true,
                                    cellTemplate: "<div class=\"ui-grid-cell-contents\" align=\"center\">" +
                                                        //"<button type=\"button\" class=\"btn btn-default btn-xs\" style=\"height: 20px; width: 24px;\" ng-click=\"grid.appScope.update(row.entity)\" uib-tooltip=\"{{grid.appScope.placement.update}}\" ng-disabled=\"isAdding\"><span class=\"ng-buttons glyphicon glyphicon-pencil\"></span></button>" +
                                        "<button type='button' class='btn btn-danger btn-xs' style='margin-left: 2px; margin-right: 2px; height: 22px; width: 29px;padding: 0px 5px;font-size: 12px;' ng-click='grid.appScope.deleteBrand(row.entity.Id)'tooltip-placement ='left' uib-tooltip='Удалить запись'><i style='font-size: 15px;' class='fa fa-trash'></i></button>" +
                                                  "</div>",
                                  //  filterHeaderTemplate: "<div align=\"center\"style=\"margin-top: -21px;\"><button \"  type=\"button\" class=\"btn btn-xs btn-primary\" style=\"margin-left: 4px;\" tooltip-placement=\"left\" uib-tooltip=\"Добавить запись\" ng-click=\"grid.appScope.addNewDocument('newGroupDoks')\" ><span class=\"glyphicon glyphicon-plus\"></span></button></div>",
                                    enableCellEdit: false,
                                    enableFiltering: true,
                                    enableSorting: false,
                                    showSortMenu: false,
                                    enableColumnMenu: false
                                }
                            ],
                            onRegisterApi: function (gridApi) {
                                $scope.gridApi = gridApi;
                                $scope.gridApi.selection.on.rowSelectionChanged($scope,
                                    function (row) {
                                    });
                            }
                        };

                        //запрос на список брендов
                        function getAllBrends() {
                            $rootScope.loadingShow();
                            adminService.getAll().then(function (value) {
                                $scope.listBrends = angular.copy(value);
                                $scope.gridBrands.data = $scope.listBrends;

                            },
                                function (errorObject) {

                                }).finally(function () {
                                    $rootScope.loadingHide();
                                });
                        }

                        //удаление бренда
                        $scope.deleteBrand = function (brandId) {
                            adminService.delete(brandId).then(function () {
                                    getAllBrends();
                                },
                                function (errorObject) {

                                }).finally(function () {
                            });
                        }

                        $scope.cancel = function () {
                            $uibModalInstance.dismiss({ $value: 'cancel' });
                        };

                        //открытие блока для добавления бренда
                        $scope.openWindowAdd = function (openModel) {
                            $scope.openWindow = openModel; 
                        };
                        //закрытие блока для добавления бренда
                        $scope.closeAddWindow = function(flag) {
                            $scope.openWindow = flag;
                        }

                        //добавление бренда
                        $scope.addBrang = function (brand, formBrand) {
                            if (!formBrand.$valid) {
                                return;
                            }
                            adminService.add(brand).then(function (value) {
                                getAllBrends();
                              //  $scope.brand = { Name: "", Description: "" };
                                    $scope.openWindow = false;
                                },
                                function (errorObject) {

                                }).finally(function () {

                                });
                        };

                        //Редактирование бренда
                        $scope.SaveEdit = function () {                           
                            adminService.edit($scope.gridBrands.data).then(function () {
                                    getAllBrends();
                                },
                                function (errorObject) {

                                }).finally(function () {
                            });
                        };
                        getAllBrends();
                    }
                ]
            }).result.then(postClose, postClose);
        };


        //Modal Window для стран

        $scope.openCountry = function () {
            $scope.asideState = {
                open: true
            };

            function postClose() {
                $scope.asideState.open = false;
            }

            $uibModal.open({
                templateUrl: function () {
                    return 'Angular/ModalWindows/ControlCountryModalWindow.html';
                },
                size: 'lg',
                controller: [
                    '$rootScope', '$scope', '$uibModalInstance', function ($rootScope, $scope, $uibModalInstance) {

                        $scope.country = { Name: "", Description: "" };
                        $scope.gridCountries = {
                            enableColumnResizing: true,
                            showGridFooter: true,
                            enableHorizontalScrollbar: 0,
                            enableVerticalScrollbar: 1,
                            enableColumnMenus: false,
                            showColumnFooter: false,
                            enableFiltering: false,
                            gridColumnFooterHeight: 20,
                            enableRowSelection: true,
                            enableRowHeaderSelection: false,
                            noUnselect: false,
                            multiSelect: false,
                            rowHeight: 22,
                            columnDefs: [
                                {
                                    field: 'Name',
                                    width: '50%',
                                    displayName: 'Название',
                                    cellTemplate: '<p style="margin-left:15px;">{{row.entity.Name}}</p>'
                                },
                                {
                                    field: 'Description',
                                    width: '50%',
                                    displayName: 'Описание',
                                    cellTemplate: '<p style="margin-left:15px;" >{{row.entity.Description}}</p>'
                                }
                            ],
                            onRegisterApi: function (gridApi) {
                                $scope.gridApi = gridApi;
                                $scope.gridApi.selection.on.rowSelectionChanged($scope,
                                    function (row) {
                                    });
                            }
                        };

                        //запрос на список стран
                        function getAllCountries() {
                            $rootScope.loadingShow();
                            countryService.getAll().then(function (value) {
                                $scope.listCountry = angular.copy(value);
                                $scope.gridCountries.data = $scope.listCountry;
                            },
                                function (errorObject) {

                                }).finally(function () {
                                    $rootScope.loadingHide();
                                });
                        }

                        $scope.cancel = function () {
                            $uibModalInstance.dismiss({ $value: 'cancel' });
                        };

                        //открытие блока для добавления страны 
                        $scope.openWindowAdd = function (openModel) {
                            $scope.openWindow = openModel;
                        };

                        //добавление страны
                        $scope.addCountry = function () {

                            countryService.add($scope.country).then(function (value) {
                                getAllCountries();
                            },
                                function (errorObject) {

                                }).finally(function () {

                                });
                        };
                        getAllCountries();
                    }
                ]
            }).result.then(postClose, postClose);
        };

        //Modal Window для струн

        $scope.openNumberString = function () {
            $scope.asideState = {
                open: true
            };

            function postClose() {
                $scope.asideState.open = false;
            }

            $uibModal.open({
                templateUrl: function () {
                    return 'Angular/ModalWindows/ControlNumberStringModalWindow.html';
                },
                size: 'lg',
                controller: [
                    '$rootScope', '$scope', '$uibModalInstance', function ($rootScope, $scope, $uibModalInstance) {

                        $scope.numberStr = { Number: "" };
                        $scope.gridNumberStrings = {
                            enableColumnResizing: true,
                            showGridFooter: true,
                            enableHorizontalScrollbar: 0,
                            enableVerticalScrollbar: 1,
                            enableColumnMenus: false,
                            showColumnFooter: false,
                            enableFiltering: false,
                            gridColumnFooterHeight: 20,
                            enableRowSelection: true,
                            enableRowHeaderSelection: false,
                            noUnselect: false,
                            multiSelect: false,
                            rowHeight: 22,
                            columnDefs: [

                                {
                                    field: 'Number',
                                    width: '100%',
                                    displayName: 'Номер',
                                    cellTemplate: '<p style="margin-left:150px;" >{{row.entity.Number}}</p>'
                                }
                            ],
                            onRegisterApi: function (gridApi) {
                                $scope.gridApi = gridApi;
                                $scope.gridApi.selection.on.rowSelectionChanged($scope,
                                    function (row) {
                                    });
                            }
                        };

                        //запрос на список струн
                        function getAllNumberStrings() {
                            $rootScope.loadingShow();
                            numberstringService.getAll().then(function (value) {
                                $scope.listNumberString = angular.copy(value);
                                $scope.gridNumberStrings.data = $scope.listNumberString;
                            },
                                function (errorObject) {

                                }).finally(function () {
                                    $rootScope.loadingHide();
                                });
                        }

                        $scope.cancel = function () {
                            $uibModalInstance.dismiss({ $value: 'cancel' });
                        };

                        //открытие блока для добавления струны 
                        $scope.openWindowAdd = function (openModel) {
                            $scope.openWindow = openModel;
                        };

                        //добавление струны
                        $scope.addNumberString = function () {
                            debugger;
                            numberstringService.add($scope.numberStr).then(function (value) {
                                getAllNumberStrings();
                            },
                                function (errorObject) {

                                }).finally(function () {

                                });
                        };
                        getAllNumberStrings();
                    }
                ]
            }).result.then(postClose, postClose);
        };


        //Modal Window для подкатегорий

        $scope.openSubcategory = function () {
            $scope.asideState = {
                open: true
            };

            function postClose() {
                $scope.asideState.open = false;
            }

            $uibModal.open({
                templateUrl: function () {
                    return "Angular/ModalWindows/ControlSubcategoryModalWindows.html";
                },
                size: 'lg',
                controller: [
                    '$rootScope', '$scope', '$uibModalInstance', function ($rootScope, $scope, $uibModalInstance) {

                        $scope.subcategory = { Name: "", Description: "" , IDcategory: "" };
                        $scope.gridSubcategories = {
                            enableColumnResizing: true,
                            showGridFooter: true,
                            enableHorizontalScrollbar: 0,
                            enableVerticalScrollbar: 1,
                            enableColumnMenus: false,
                            showColumnFooter: false,
                            enableFiltering: false,
                            gridColumnFooterHeight: 20,
                            enableRowSelection: true,
                            enableRowHeaderSelection: false,
                            noUnselect: false,
                            multiSelect: false,
                            rowHeight: 22,
                            columnDefs: [

                                {
                                    field: 'Category',
                                    displayName: "Категория",
                                    cellTemplate: '<p style="margin-left:15px;" >{{row.entity.Category.Name}}</p>'
                                },

                                {
                                    field: 'Name',
                                    width: "30%",
                                    displayName: "Подкатегория",
                                    cellTemplate: '<p style="margin-left:15px;" >{{row.entity.Name}}</p>'
                                },
                                {
                                    field: 'Description',
                                    width: "30%",
                                    displayName: 'Описание подкатегории',
                                    cellTemplate: '<p style="margin-left:15px;" >{{row.entity.Description}}</p>'
                                }
                               
                            ],
                            onRegisterApi: function (gridApi) {
                                $scope.gridApi = gridApi;
                                $scope.gridApi.selection.on.rowSelectionChanged($scope,
                                    function (row) {
                                    });
                            }
                        };

                        //запрос на список подкатегорий
                        function getAllSubcategories() {
                            $rootScope.loadingShow();
                            subcategoryService.getAll().then(function (value) {
                                $scope.listsubcategory = angular.copy(value);
                                $scope.gridSubcategories.data = $scope.listsubcategory;
                            },
                                function (errorObject) {

                                }).finally(function () {
                                    $rootScope.loadingHide();
                                });
                        }

                        $scope.cancel = function () {
                            $uibModalInstance.dismiss({ $value: 'cancel' });
                        };

                        //открытие блока для добавления подкатегории
                        $scope.openWindowAdd = function (openModel) {
                            $scope.openWindow = openModel;
                        };

                        //добавление подкатегории
                        $scope.addSubcategory = function () {
                            debugger;
                            subcategoryService.add($scope.subcategory).then(function (value) {
                                getAllSubcategories();
                            },
                                function (errorObject) {

                                }).finally(function () {

                                });
                        };
                        getAllSubcategories();
                    }
                ]
            }).result.then(postClose, postClose);
        };

    }
    // register your controller into a dependent module 
    angular
        .module("Web.Controllers")
        .controller("adminController",
        ["$scope", "$rootScope", "$uibModal", "adminService", "countryService", 'numberstringService', "subcategoryService", adminController]);

})();



