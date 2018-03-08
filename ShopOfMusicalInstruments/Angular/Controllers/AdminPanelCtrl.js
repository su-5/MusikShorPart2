(function () {
    "use strict";

    // controller class definintion
    var adminController = function ($scope, $rootScope, $uibModal, adminService, countryService, numberstringService, subcategoryService, productService) {

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
                    return "Angular/ModalWindows/ControlBrendModalMindow.html";
                },
                size: 'lg',
                controller: [
                    '$rootScope', '$scope', '$uibModalInstance', function ($rootScope, $scope, $uibModalInstance) {
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
                                    displayName: 'Описание',
                                    cellTemplate: '<p style="margin-left:15px;" >{{row.entity.Description}}</p>'
                                },
                                {
                                    field: 'buttons_edit_del',
                                    displayName: "",
                                    visible: true,
                                    cellTemplate: "<div class=\"ui-grid-cell-contents\" align=\"center\">" +

                                        "<button type='button' class='btn btn-danger btn-xs' style='margin-left: 2px; margin-right: 2px; height: 22px; width: 29px;padding: 0px 5px;font-size: 12px;' ng-click='grid.appScope.deleteBrand(row.entity.Id)'tooltip-placement ='left' uib-tooltip='Удалить запись'><i style='font-size: 15px;' class='fa fa-trash'></i></button>" +
                                        "</div>",

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
                                return $scope.listBrends;
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
                        $scope.closeAddWindow = function (flag) {
                            $scope.openWindow = flag;
                        }

                        //добавление бренда
                        $scope.addBrang = function (brand, formBrand) {
                            if (!formBrand.$valid) {
                                return;
                            }
                            adminService.add(brand).then(function (value) {
                                getAllBrends();
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
                                    width: '45%',
                                    displayName: 'Описание',
                                    cellTemplate: '<p style="margin-left:15px;" >{{row.entity.Description}}</p>'
                                },
                                {
                                    field: 'buttons_edit_del',
                                    displayName: "",
                                    visible: true,
                                    cellTemplate: "<div class=\"ui-grid-cell-contents\" align=\"center\">" +
                                        "<button type='button' class='btn btn-danger btn-xs' style='margin-left: 2px; margin-right: 2px; height: 22px; width: 29px;padding: 0px 5px;font-size: 12px;' ng-click='grid.appScope.deleteBrand(row.entity.Id)'tooltip-placement ='left' uib-tooltip='Удалить запись'><i style='font-size: 15px;' class='fa fa-trash'></i></button>" +
                                        "</div>",
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

                        //удаление стран 
                        $scope.deleteCountry = function (countryId) {
                            countryService.delete(countryId).then(function () {
                                getAllCountries();
                            },
                                function (errorObject) {

                                }).finally(function () {
                                });
                        }

                        $scope.cancel = function () {
                            $uibModalInstance.dismiss({ $value: 'cancel' });
                        };



                        //открытие блока для добавления страны 
                        $scope.openWindowAdd = function (openModel) {
                            $scope.openWindow = openModel;
                        };

                        //закрытие блока для добавления страны
                        $scope.closeAddWindow = function (flag) {
                            $scope.openWindow = flag;
                        }

                        //добавление страны
                        $scope.addCountry = function (country, formCountry) {
                            if (!formCountry.$valid) {
                                return;
                            }

                            countryService.add(country).then(function (value) {
                                getAllCountries();
                                $scope.openWindow = false;
                            },
                                function (errorObject) {

                                }).finally(function () {

                                });
                        };

                        //Редактирование страны 
                        $scope.SaveEdit = function () {
                            countryService.edit($scope.gridCountries.data).then(function () {
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
                size: 'md',
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
                                    width: '70%',
                                    displayName: 'Номер',
                                    cellTemplate: '<p style="margin-left:80px;" >{{row.entity.Number}}</p>'
                                },
                                {
                                    field: 'buttons_edit_del',
                                    displayName: "",
                                    visible: true,
                                    cellTemplate: "<div class=\"ui-grid-cell-contents\" align=\"center\">" +
                                        "<button type='button' class='btn btn-danger btn-xs' style='margin-left: 2px; margin-right: 2px; height: 22px; width: 29px;padding: 0px 5px;font-size: 12px;' ng-click='grid.appScope.deleteBrand(row.entity.Id)'tooltip-placement ='left' uib-tooltip='Удалить запись'><i style='font-size: 15px;' class='fa fa-trash'></i></button>" +
                                        "</div>",
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

                        //удаление струн
                        $scope.deleteNumberString = function (numberStringId) {
                            numberstringService.delete(numberStringId).then(function () {
                                getAllNumberStrings();
                            },
                                function (errorObject) {

                                }).finally(function () {
                                });
                        }

                        $scope.cancel = function () {
                            $uibModalInstance.dismiss({ $value: 'cancel' });
                        };



                        //открытие блока для добавления струны 
                        $scope.openWindowAdd = function (openModel) {
                            $scope.openWindow = openModel;
                        };

                        //закрытие блока для добавления струны
                        $scope.closeAddWindow = function (flag) {
                            $scope.openWindow = flag;
                        }

                        //добавление струны
                        $scope.addNumberString = function (numberStr, formNumberString) {
                            if (!formNumberString.$valid) {
                                return;
                            }

                            numberstringService.add(number).then(function (value) {
                                getAllNumberStrings();
                                $scope.openWindow = false;
                            },
                                function (errorObject) {

                                }).finally(function () {

                                });
                        };

                        //Редактирование струны 
                        $scope.SaveEdit = function () {
                            numberstringService.edit($scope.gridNumberStrings.data).then(function () {
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

                        $scope.subcategory = { Name: "", Description: "", IDcategory: "" };
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
                                    width: "30%",
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
                                },
                                {
                                    field: 'buttons_edit_del',
                                    displayName: "",
                                    visible: true,
                                    cellTemplate: "<div class=\"ui-grid-cell-contents\" align=\"center\">" +
                                        "<button type='button' class='btn btn-danger btn-xs' style='margin-left: 2px; margin-right: 2px; height: 22px; width: 29px;padding: 0px 5px;font-size: 12px;' ng-click='grid.appScope.deleteBrand(row.entity.Id)'tooltip-placement ='left' uib-tooltip='Удалить запись'><i style='font-size: 15px;' class='fa fa-trash'></i></button>" +
                                        "</div>",
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

                        //удаление подкатегорий
                        $scope.deleteSubcategory = function (subcategoryId) {
                            subcategoryService.delete(subcategoryId).then(function () {
                                getAllSubcategories();
                            },
                                function (errorObject) {

                                }).finally(function () {
                                });
                        }

                        $scope.cancel = function () {
                            $uibModalInstance.dismiss({ $value: 'cancel' });
                        };



                        //открытие блока для добавления подкатегории
                        $scope.openWindowAdd = function (openModel) {
                            $scope.openWindow = openModel;
                        };

                        //закрытие блока для добавления подкатегории
                        $scope.closeAddWindow = function (flag) {
                            $scope.openWindow = flag;
                        }

                        //добавление подкатегории
                        $scope.addSubcategory = function (subcategory, formSubcategory) {
                            if (!formSubcategory.$valid) {
                                return;
                            }

                            subcategoryService.add(subcategory).then(function (value) {
                                getAllSubcategories();
                                $scope.openWindow = false;
                            },
                                function (errorObject) {

                                }).finally(function () {

                                });
                        };

                        //Редактирование подкатегории
                        $scope.SaveEdit = function () {
                            subcategoryService.edit($scope.gridSubcategories.data).then(function () {
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


        //Modal Window для продуктов

        $scope.openProduct = function () {
            $scope.asideState = {
                open: true
            };

            function postClose() {
                $scope.asideState.open = false;
            }

            $uibModal.open({
                templateUrl: function () {
                    return "Angular/ModalWindows/ControlProductModalWindow.html";
                },
                size: 'lg',
                controller: [
                    '$rootScope', '$scope', '$uibModalInstance', function ($rootScope, $scope, $uibModalInstance) {

                        $scope.product = { Name: "", Price: "", CountryId: "", BrandId: "", NumberStringId: "", SubcategoriesId: "" };
                        $scope.gridProducts = {
                            enableColumnResizing: true,
                            showGridFooter: false,
                            enableHorizontalScrollbar: 0,
                            enableVerticalScrollbar: 1,
                            enableColumnMenus: false,
                            showColumnFooter: false,
                            enableFiltering: true,
                            gridColumnFooterHeight: 20,
                            enableRowSelection: false,
                            enableRowHeaderSelection: false,
                            enableSelectAll: false,
                            noUnselect: false,
                            multiSelect: false,
                            columnDefs: [
                                {
                                    field: 'Brand.Name',
                                    width: "10%",
                                    displayName: 'Бренд'
                                },
                                {
                                    field: 'Name',
                                    width: "10%",
                                    displayName: "Название инструмента",
                                    cellTemplate: '<p style="margin-left:15px;" >{{row.entity.Name}}</p>'
                                },
                                {
                                    field: 'Window',
                                    width: "7%",
                                    enableCellEdit: false,
                                    displayName: 'Витрина',
                                    cellTemplate: 'Angular/Templates/WindowCheckBox.html'
                                },
                                {
                                    field: 'Country.Name',
                                    width: "10%",
                                    displayName: 'Страна'
                                },
                                {
                                    field: 'Subcategory.Name',
                                    width: "10%",
                                    displayName: "Подкатегория"
                                },
                                {
                                    field: 'Subcategory.Category.Name',
                                    width: "10%",
                                    displayName: "Категория"
                                },
                                {
                                    field: 'Price',
                                    width: "10%",
                                    displayName: 'Цена',
                                    cellTemplate: '<p style="margin-left:15px;" >{{row.entity.Price}}</p>'
                                },
                                {
                                    field: 'NumberProduct',
                                    width: "10%",
                                    displayName: 'Количество на складе',
                                    cellTemplate: '<p style="margin-left:15px;" >{{row.entity.NumberProduct}}</p>'
                                },
                                {
                                    field: 'DateManufacture',
                                    width: "15%",
                                    displayName: 'Дата выпуска',
                                    cellTemplate: "<p style='margin-left:15px;'>{{row.entity.DateManufacture | date:'MM/dd/yyyy'}}</p>"
                                },

                                {
                                    field: 'buttons_edit_del',
                                    displayName: "",
                                    visible: true,
                                    cellTemplate: "<div class=\"ui-grid-cell-contents\" align=\"center\">" +
                                        "<button type='button' class='btn btn-danger btn-xs' style='margin-left: 2px; margin-right: 2px; height: 22px; width: 29px;padding: 0px 5px;font-size: 12px;' ng-click='grid.appScope.deleteBrand(row.entity.Id)'tooltip-placement ='left' uib-tooltip='Удалить запись'><i style='font-size: 15px;' class='fa fa-trash'></i></button>" +
                                        "</div>",
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

                        //запрос на список продуктов
                        function getAllProducts() {
                            $rootScope.loadingShow();
                            productService.getAll().then(function (value) {
                                $scope.listproduct = angular.copy(value);
                                $scope.gridProducts.data = $scope.listproduct;
                            },
                                function (errorObject) {

                                }).finally(function () {
                                    $rootScope.loadingHide();
                                });
                        }

                        $scope.cancel = function () {
                            $uibModalInstance.dismiss({ $value: 'cancel' });
                        };

                        //удаление продуктов
                        $scope.deleteProduct = function (productId) {
                            subcategoryService.delete(productId).then(function () {
                                getAllProducts();
                            },
                                function (errorObject) {

                                }).finally(function () {
                                });
                        }

                        $scope.cancel = function () {
                            $uibModalInstance.dismiss({ $value: 'cancel' });
                        };



                        //открытие блока для добавления продуктов
                        $scope.openWindowAdd = function (openModel) {
                            $scope.openWindow = openModel;
                        };

                        //закрытие блока для добавления продуктов
                        $scope.closeAddWindow = function (flag) {
                            $scope.openWindow = flag;
                        }

                        //добавление продуктов
                        $scope.addProduct = function (product, formProduct) {
                            if (!formProduct.$valid) {
                                return;
                            }

                            productService.add(product).then(function (value) {
                                getAllProducts();
                                $scope.openWindow = false;
                            },
                                function (errorObject) {

                                }).finally(function () {

                                });
                        };


                        //Добавление нового продукта
                        $scope.openWindowAdd = function (e) {
                            $scope.asideState = {
                                open: true
                            };

                            function postClose() {
                                $scope.asideState.open = false;
                            }

                            $uibModal.open({
                                templateUrl: function () {
                                    return "Angular/ModalWindows/ControlAddNewProductModalWindow.html";
                                },
                                size: 'md',
                                controller: [
                                    '$rootScope', '$scope', '$uibModalInstance', function ($rootScope, $scope, $uibModalInstance) {
                                        $rootScope.loadingShow();
                                        adminService.getAll().then(function (value) {
                                            $scope.listBrends = angular.copy(value);
                                            $scope.allBrands = $scope.listBrends;
                                        },
                                            function (errorObject) {

                                            }).finally(function () {
                                                $rootScope.loadingHide();
                                            });

                                        $scope.cancel = function () {
                                            $uibModalInstance.dismiss({ $value: 'cancel' });
                                        };
                                    }
                                ]
                            }).result.then(postClose, postClose);
                        };


                        //Редактирование продуктов
                        $scope.SaveEdit = function () {
                            productService.edit($scope.gridProducts.data).then(function () {
                                getAllProducts();
                            },
                                function (errorObject) {

                                }).finally(function () {
                                });
                        };
                        getAllProducts();
                    }
                ]
            }).result.then(postClose, postClose);
        };

    }
    // register your controller into a dependent module 
    angular
        .module("Web.Controllers")
        .controller("adminController",
        ["$scope", "$rootScope", "$uibModal", "adminService", "countryService", 'numberstringService', "subcategoryService", "productService", adminController]);

})();



