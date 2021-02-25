(function () {
    angular
        .module('eRouteApp')
        .controller('ventasBYDController', ventasBYDController)
    ventasBYDController.$inject = ['$scope', '$http', '$mdToast', '$q', '$timeout', 'cfpLoadingBar', '$filter', "menuServices", "reportServices", "valorReferencia"];

    function ventasBYDController($scope, $http, $mdToast, $q, $timeout, cfpLoadingBar, $filter, menuServices, reportServices, valorReferencia) {
        var url = window.sessionStorage.getItem('URL');
        var self = this;
        self.showList = false;
        self.minDate = new Date();

        $scope.EstablecerReporte = function (VAVClave) {
            valorReferencia.obtenerValorClave('REPORTEW', VAVClave, function (result) {
                self.titulo = result[0].Descripcion;
                GetCEDIS();
            });
        }

        function GetCEDIS() {
            $http({
                url: url + '/API/GetModel/GetCEDIS',
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
                var dis = cedis.Nombre;
                var lowercaseDispley = dis.toLowerCase();
                return (lowercaseDispley.indexOf(lowercaseQuery) === 0);
            };
        }

        self.ShowItems = function (selectedItem) {
            self.showErrorForm = false;
            if (selectedItem == undefined) {
                self.showList = false;
            } else {
                self.showList = true;
            }
        }

        //Fechas
        self.GetDates = function () {
            self.showErrorForm = false;
            self.State = undefined;
            self.date1 = undefined;
            self.date2 = undefined;
            self.showSelect = false;
            self.dateState = null;
            $http({
                url: url + '/API/GetModel/GetDateStatus',
                method: 'GET',
                headers: {
                    Authorization: window.sessionStorage.getItem('Token'),
                    'Content-Type': 'application/json'
                },
            }).then(function successCallBack(response) {
                self.dateState = response.data;
                self.State = self.dateState[0].Nombre;
                self.OnSelectChange(self.State, 0);
            }, function errorCallBack(response) {
            });
        }

        //Estado del rango de fecha
        self.OnSelectChange = function (state, date) {
            self.showErrorForm = false;
            if (date == 0) {
                self.date1 = self.minDate;
            }
            if (state == 'Entre') {
                self.date2 = undefined;
                self.showSelect = true;
            } else {
                self.date2 = self.date1;
                self.showSelect = false;
            }
        }

        self.RutaVendedor = function (selectedItem) {
            if (self.ReportFilter) {
                $scope.selectAll = false;
                $scope.queryRoute = '';
                self.routes = undefined;
                self.RutSell = "Vendedores";
                self.GetSellers(selectedItem);
            } else {
                $scope.VendedorId = undefined;
                $scope.querySeller = '';
                $scope.inactSellers = false;
                self.sellers = undefined;
                self.RutSell = "Rutas";
                self.GetRoutes(selectedItem);
            }
        }

        //Llenar Vendedores
        self.GetSellers = function (selectedItem) {
            if (selectedItem != undefined) {
                $scope.VendedorId = undefined;
                $scope.querySeller = '';
                self.sellers = null;
                $http({
                    url: url + '/API/GetModel/GetSellers?cedis=' + selectedItem.replace(/\+/g, "%2B"),
                    method: 'GET',
                    headers: {
                        Authorization: window.sessionStorage.getItem('Token'),
                        'Content-Type': 'application/json'
                    },
                }).then(function successCallBack(response) {
                    self.sellers = response.data;
                }, function errorCallBack(response) {
                });
            }
        }

        //Llenar Rutas
        self.GetRoutes = function (selectedItem) {
            if (selectedItem != undefined) {
                $scope.RutaId = undefined;
                $scope.queryRoute = '';
                self.routes = undefined;
                $http({
                    url: url + '/API/GetModel/GetRoutes?cedis=' + selectedItem.replace(/\+/g, "%2B"),
                    method: 'GET',
                    headers: {
                        Authorization: window.sessionStorage.getItem('Token'),
                        'Content-Type': 'application/json'
                    },
                }).then(function successCallBack(response) {
                    self.routes = response.data;
                }, function errorCallBack(response) {
                });
            }
        }

        self.ResetItems = function () {
            self.showErrorForm = false;
            self.clients = undefined;
            $scope.queryClients = '';
            $scope.selectAllClients = false;
        }

        //Llenar Clientes
        self.GetClients = function (routes, sellers) {
            self.showErrorForm = false;
            self.clients = undefined;
            $scope.queryClients = '';
            $scope.selectAllClients = false;
            $http({
                url: url + '/API/GetModel/GetClients?routes=' + routes + '&sellers=' + sellers,
                method: 'GET',
                headers: {
                    Authorization: window.sessionStorage.getItem('Token'),
                    'Content-Type': 'application/json'
                },
            }).then(function successCallBack(response) {
                self.clients = response.data;
            }, function errorCallBack(response) {
            });
        }

        //Seleccionar todos los Clientes
        self.SelectAllCheckboxesClients = function (selectAll) {
            $scope.queryClients = '';
            if (selectAll == undefined || selectAll == false) {
                angular.forEach(self.clients, function (item) {
                    item.Checked = true;
                });
            }
            else {
                angular.forEach(self.clients, function (item) {
                    item.Checked = false;
                });
            }
        }

        self.CountClients = function () {
            $scope.queryClients = '';
            var count = 0;
            angular.forEach(self.clients, function (item) {
                if (item.Checked) {
                    count++;
                }
            });
            if (count != self.clients.length) {
                $scope.selectAllClients = false;
            } else if (count == self.clients.length) {
                $scope.selectAllClients = true;
            }
        }

        function GetArrayValues(Array, otro) {
            var newArray = [];
            angular.forEach(Array, function (item) {
                if (otro != undefined) {
                    if (item.Clave == otro) {
                        newArray.push({ Clave: item.Clave, Nombre: item.Nombre, Checked: true, Disabled: false });
                    }
                } else {
                    if (item.Checked == true) {
                        newArray.push({ Clave: item.Clave, Nombre: item.Nombre, Checked: item.Checked, Disabled: item.Disabled });
                    }
                }
            });
            return newArray;
        }

        self.startbar = function () {
            cfpLoadingBar.start();
        };

        function ErrorMessage(cadena) {
            self.ShowError = cadena;
            self.showErrorForm = true;
            cfpLoadingBar.complete();
        }

        //Envia formulario completo
        self.SubmitForm = function () {
            var clientes = [];
            if (!$scope.selectAllClients) {
                clientes = GetArrayValues(self.clients);
            }
            var rutas = GetArrayValues(self.routes, $scope.RutaId);
            var vendedores = GetArrayValues(self.sellers, $scope.VendedorId);
            if ($scope.RutaId == undefined && $scope.VendedorId == undefined) {
                ErrorMessage("*Seleccione una Ruta o un Vendedor");
            } else if (self.State == undefined) {
                ErrorMessage("*Seleccione rango de fechas");
            } else if (self.State == 'Entre' && (self.date1 == undefined || self.date2 == undefined)) {
                ErrorMessage("*Seleccione las fechas");
            } else if (self.State == 'Entre' && (self.date2 <= self.date1)) {
                ErrorMessage("*Rango de fechas erróneo");
            } else if (self.date1 == undefined) {
                ErrorMessage("*Seleccione la fecha");
            } else {
                clientes = ($scope.selectAllClients ? null : clientes);
                var data = {
                    CEDIS: self.selectedItem.Clave,
                    NameCEDIS: self.selectedItem.Nombre,
                    StatusDate: self.State,
                    ReportName: self.titulo,
                    InitialDate: self.date1.toJSON(),
                    FinalDate: self.date2.toJSON(),
                    ReportType: self.ReportType,
                    ReportFilter: self.ReportFilter,
                    VAVClave: self.VAVClave,
                    Sellers: vendedores,
                    Routes: rutas,
                    ObjectName: (self.ReportFilter ? vendedores : rutas)
                }
                $http.post(url + '/Reports/SetCondition', data, { ignoreLoadingBar: true })
                .success(function (data, status, headers, config) {
                    window.open(url + "/Reports/Ver");
                    cfpLoadingBar.complete();
                })
                .error(function (error, status, headers, config) {
                });
            }
        }
    }
})();