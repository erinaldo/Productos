(function () {
    angular
        .module('eRouteApp')
        .controller('proximidadRIPController', proximidadRIPController)
    proximidadRIPController.$inject = ['$scope', '$http', '$mdToast', '$q', '$timeout', 'NgMap', 'cfpLoadingBar', '$filter', "menuServices", "reportServices", "valorReferencia"];

    function proximidadRIPController($scope, $http, $mdToast, $q, $timeout, NgMap, cfpLoadingBar, $filter, menuServices, reportServices, valorReferencia) {
        var url = window.sessionStorage.getItem('URL');
        var self = this;
        self.showList = false;
        self.minDate = new Date();

        $scope.EstablecerReporte = function (VAVClave) {
            valorReferencia.obtenerValorClave('REPORTEW', VAVClave, function (result) {
                self.titulo = result[0].Descripcion;
            });

            GetCEDIS();
        }

        //Llenar CEDIS
        //GetCEDIS();
        function GetCEDIS() {
            $http({
                url: url + '/api/GetCedis',
                method: 'GET',
                headers: {
                    Authorization: window.sessionStorage.getItem('Token'),
                    'Content-Type': 'application/json'
                },
                params: { USUId: window.sessionStorage.getItem('USUId') }
            }).then(function successCallBack(response) {
                self.cedis = response.data;
            }, function errorCallBack(response) {
            });
        }

        self.QuerySearch = function (query) {
            var results = query ? self.cedis.filter(createFilterFor(query)) : self.cedis,
                deferred;
            return results;
        }

        function createFilterFor(query) {
            var lowercaseQuery = query.toLowerCase();
            return function filterFn(cedis) {
                var dis = cedis.display;
                var lowercaseDispley = dis.toLowerCase();
                return (lowercaseDispley.indexOf(lowercaseQuery) === 0);
            };
        }

        //Fechas
        self.GetDates = function () {
            self.showErrorForm = false;
            self.date1 = undefined;
            self.showSelect = false;
            self.dateState = null;
            $http({
                url: url + '/api/GetDateStatus',
                method: 'GET',
                headers: {
                    Authorization: window.sessionStorage.getItem('Token'),
                    'Content-Type': 'application/json'
                },
            }).then(function successCallBack(response) {
                self.dateState = response.data;
            }, function errorCallBack(response) {
            });
        }

        self.ShowItems = function (selectedItem) {
            self.showErrorForm = false;
            if (selectedItem == undefined) {
                self.showList = false;
            } else {
                self.showList = true;
            }
        }

        //Seleccionar todos los Esquemas de Productos
        self.SelectAllChekboxesSchemes = function (selectAllSchemes) {
            $scope.querySchemes = '';
            if (selectAllSchemes == undefined || selectAllSchemes == false) {
                angular.forEach(self.schemes, function (item) {
                    item.Checked = true;
                });
            } else {
                angular.forEach(self.schemes, function (item) {
                    item.Checked = false;
                });
            }
        }

        //Llenar Esquemas Productos
        self.GetSchemesProducts = function () {
            $scope.querySchemes = '';
            self.schemes = null;
            $scope.selectAllSchemes = false;
            $http({
                url: url + '/api/GetProductsScheme/GETProductsScheme?level=' + 1,
                method: 'GET',
                headers: {
                    Authorization: window.sessionStorage.getItem('Token'),
                    'Content-Type': 'application/json'
                }
            }).then(function successCallBack(response) {
                self.schemes = response.data;
            }, function errorCallBack(response) {
            });
        }

        self.startbar = function () {
            cfpLoadingBar.start();
        };

        function ErrorMessage(cadena) {
            self.ShowError = cadena;
            self.showErrorForm = true;
            cfpLoadingBar.complete();
        }

        self.CountSchemes = function () {
            $scope.querySchemes = '';
            var count = 0;
            angular.forEach(self.schemes, function (item) {
                if (item.Checked) {
                    count++;
                }
            });
            if (count != self.schemes.length) {
                $scope.selectAllSchemes = false;
            } else if (count == self.schemes.length) {
                $scope.selectAllSchemes = true;
            }
        }

        //Envia formulario completo
        self.SubmitForm = function () {
            var countSchemes = 0;
            angular.forEach(self.schemes, function (item) {
                if (item.Checked == true) {
                    countSchemes++;
                }
            });
            if (countSchemes <= 0) {
                ErrorMessage("*Seleccione un Esquema");
            } else if (self.date1 == undefined) {
                ErrorMessage("*Seleccione la fecha");
            } else {
                var data;
                data = {
                    Cedis: self.selectedItem.value,
                    nombreCedis: self.selectedItem.display,
                    dateStatus: self.State,
                    init: self.date1.toJSON(),
                    end: self.date2,
                    vavclave: self.VAVClave,
                    nombreReport: self.titulo,
                    Products: self.schemes
                }
                $http.post(url + '/Reports/GetCondition', data, { ignoreLoadingBar: true })
                .success(function (data, status, headers, config) {
                    window.open(url + "/Reports/Ver", "_blank");
                    cfpLoadingBar.complete();
                })
                .error(function (error, status, headers, config) {
                });
            }
        }
    }
})();