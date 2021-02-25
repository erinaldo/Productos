(function () {
    angular
        .module('eRouteApp')
        .controller('reporteLiquidacionEfectivoDIVController', reporteLiquidacionEfectivoDIVController)
    reporteLiquidacionEfectivoDIVController.$inject = ['$scope', '$http', 'cfpLoadingBar', '$filter', "valorReferencia"];

    function reporteLiquidacionEfectivoDIVController($scope, $http, cfpLoadingBar, $filter, valorReferencia) {
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
                url: url + '/API/GetReportFilters/GetCEDIS',
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
                url: url + '/API/GetReportFilters/GetDateStatus',
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
            self.date2 = self.date1;
            if (state == 'Entre') {
                self.showSelect = true;
            } else {
                self.showSelect = false;
            }
        }

        self.RutaVendedor = function (selectedItem) {
            self.ResetItems();
            if (self.ReportFilter) {
                $scope.selectAll = false;
                $scope.queryRoute = '';
                self.routes = undefined;
                self.RutSell = "Rutas";
                self.GetRoutes(selectedItem);
            } else {
                $scope.selectAll = false;
                $scope.queryRoute = '';
                self.routes = undefined;
                self.RutSell = "Rutas";
                self.GetRoutes(selectedItem);
            }
        }

        //Llenar Vendedores
        self.GetSellers = function (selectedItem, estado) {
            if (selectedItem != undefined) {
                self.ResetItems();
                $scope.VendedorId = undefined;
                $scope.querySeller = '';
                self.sellers = null;
                if (!$scope.inactSellers) {
                    estado = 1;
                }
                $http({
                    url: url + '/API/GetReportFilters/GetSellers?cedis=' + selectedItem.replace(/\+/g, "%2B") + "&estado=" + estado,
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

        //seller functions
        self.group = 'Client';
        self.GetClients = GetClients;

        function GetClients(Route) {
            Route = "'" + Route + "'";
            $http({
                url: url + '/api/GetClients?Id=Todos&Routes=' + Route + '&Cedis=' + "",
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

        //Llenar Rutas
        self.GetRoutes = function (selectedItem) {
            if (selectedItem != undefined) {
                self.ResetItems();
                $scope.queryRoute = '';
                self.routes = undefined;
                $scope.selectAll = false;
                $http({
                    url: url + '/API/GetReportFilters/GetRoutes?cedis=' + selectedItem.replace(/\+/g, "%2B"),
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
        }

        self.CountRoutes = function () {
            self.ResetItems();
            $scope.queryRoute = '';
            var count = 0;
            var routes = [];
            angular.forEach(self.routes, function (item) {
                if (item.Checked) {
                    count++;
                    routes.push(item.Clave);
                }
            });
            if (count != 0) {
                if (count != self.routes.length) {
                    $scope.selectAll = false;
                } else if (count == self.routes.length) {
                    $scope.selectAll = true;
                }
            }
        }

        self.CountSellers = function () {
            self.ResetItems();
            $scope.querySeller = '';
            var count = 0;
            var sellers = [];
            angular.forEach(self.sellers, function (item) {
                if (item.Checked) {
                    count++;
                    sellers.push(item.VendedorId);
                }
            });
            if (count != 0) {
                if (count != self.sellers.length) {
                    $scope.selectAll = false;
                } else if (count == self.sellers.length) {
                    $scope.selectAll = true;
                }
            }
        }

        self.CountClients = function () {
            self.ResetItems();
            $scope.queryClients = '';
            var count = 0;
            var clients = [];
            angular.forEach(self.clients, function (item) {
                if (item.Checked) {
                    count++;
                    clients.push(item.Clave);
                }
            });
            if (count != 0) {
                if (count != self.clients.length) {
                    $scope.selectAll = false;
                } else if (count == self.clients.length) {
                    $scope.selectAll = true;
                }
            }
        }

        //Seleccionar todas las Rutas
        self.SelectAllCheckboxesRoutes = function (selectAll) {
            self.ResetItems();
            $scope.queryRoute = '';
            if (selectAll == undefined || selectAll == false) {
                angular.forEach(self.routes, function (item) {
                    item.Checked = false;
                });
            } else {
                angular.forEach(self.routes, function (item) {
                    item.Checked = true;
                });
                self.clients = undefined;
            }
        }

        self.SelectAllCheckboxesSellers = function (selectAll) {
            self.ResetItems();
            $scope.querySeller = '';
            if (selectAll == undefined || selectAll == false) {
                angular.forEach(self.sellers, function (item) {
                    item.Checked = true;
                });                
            } else {
                angular.forEach(self.sellers, function (item) {
                    item.Checked = false;
                });
                self.clients = undefined;
            }
        }

        self.SelectAllCheckboxesClients = function (selectAll) {
            self.ResetItems();
            $scope.queryClients = '';
            if (selectAll == undefined || selectAll == false) {
                angular.forEach(self.clients, function (item) {
                    item.Checked = true;
                });
            } else {
                angular.forEach(self.clients, function (item) {
                    item.Checked = false;
                });
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
                        newArray.push({ Clave: item.Clave, Nombre: item.RazonSocial, Checked: true, Disabled: false });
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
            //var clientes = [];
            var rutas = [];
            rutas = GetArrayValues(self.routes, $scope.Clave);
            if (!$scope.selectAll) {
                clientes = GetArrayValues(self.clients);
            }
            else {
                clientes = 'Todos'
            }

            if (rutas.length <= 0 && !$scope.selectAll) {
                ErrorMessage("*Seleccione una ruta");
            } else if (self.State == undefined) {
                ErrorMessage("*Seleccione rango de fechas");
            } else if (self.State == 'Entre' && (self.date1 == undefined || self.date2 == undefined)) {
                ErrorMessage("*Seleccione las fechas");
            } else if (self.State == 'Entre' && (self.date2 <= self.date1)) {
                ErrorMessage("*La Fecha Final debe ser mayor a la Fecha Inicial");
            } else if (self.date1 == undefined) {
                ErrorMessage("*Seleccione la fecha");
            } else {
                var data = {
                    CEDIS: self.selectedItem.Clave,
                    NameCEDIS: self.selectedItem.Nombre,
                    ReportName: self.titulo,
                    StatusDate: self.State,
                    InitialDate: moment(self.date1).format('YYYY-MM-DD'),
                    FinalDate: moment(self.date2).format('YYYY-MM-DD'),
                    ReportType: self.ReportType,
                    ReportFilter: self.ReportFilter,
                    VAVClave: self.VAVClave,
                    Routes: rutas,
                }
                $http.post(url + '/Reports/SetCondition', data, { ignoreLoadingBar: true })
                .then(function () {
                window.open(url + "/Reports/Ver");
                cfpLoadingBar.complete();
            });
            }
        }
    }
})();