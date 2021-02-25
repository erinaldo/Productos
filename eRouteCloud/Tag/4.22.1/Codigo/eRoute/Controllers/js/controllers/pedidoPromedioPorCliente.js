(function () {
    angular
        .module('eRouteApp')
        .controller('pedidoPromedioPorCliente', pedidoPromedioPorCliente)
    pedidoPromedioPorCliente.$inject = ['$scope', '$http', '$mdToast', '$q', '$timeout', 'NgMap', 'cfpLoadingBar', '$filter', "menuServices", "reportServices"];

    function pedidoPromedioPorCliente($scope, $http, $mdToast, $q, $timeout, NgMap, cfpLoadingBar, $filter, menuServices, reportServices) {
        var url = window.sessionStorage.getItem('URL');
        var self = this;
        self.showList = false;
        self.showSelect = undefined;
        self.nShowLists = nShowLists;
        self.selectedItem = undefined;
        self.OnSelectChange = OnSelectChange;
        self.minDate = new Date();
        self.SubmitForm = SubmitForm;
        self.date1 = undefined;
        self.date2 = undefined;
        self.VAVClave = undefined;
        self.ReportType = false;
        $scope.inactRoutes = false;
        $scope.IdEsquema = "";
        $scope.TipoReporte = "Surtido";
        var Todasrutas = false;
        var TodosClientes = false;

        //esquemas Clientes
        self.esquemasCliente = [];
        function GetEsquemas(cedis) {

            $http({
                url: url + '/api/GetClientScheme/ObtenerEsquemaClientes?cedis=' + cedis,
                method: 'GET',
                headers: {
                    Authorization: window.sessionStorage.getItem('Token'),
                    'Content-Type': 'application/json'
                }
            }).then(function successCallBack(response) {
                self.esquemasCliente = response.data;
            }, function errorCallBack(response) {
            });


        }
        self.filtroClientesPorEsquema = filtroClientesPorEsquema;
        function filtroClientesPorEsquema() {
            GetClients(self.routes);
        }

        //Llenar CEDIS
        self.cedis = GetCEDIS();
        self.querySearch = querySearch;
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

        function querySearch(query) {
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

        ////Llenar Rutas
        self.routes = GetRoutes();
        self.GetRoutes = GetRoutes;
        function GetRoutes(selectedItem, estado) {
            //console.log("inactRoutes: " + $scope.inactRoutes);
            var inactivos = $scope.inactRoutes;
            debugger;
            if (selectedItem != undefined) {
                //console.log("CEDI: " + selectedItem);
                $http({
                    url: url + '/api/GetRoutes?Cedis=' + selectedItem.replace(/\+/g, "%2B") + "&inactivos=" + inactivos,
                    method: 'GET',
                    headers: {
                        Authorization: window.sessionStorage.getItem('Token'),
                        'Content-Type': 'application/json'
                    },
                }).then(function successCallBack(response) {
                    self.routes = response.data;
                    //console.log("RUTAS");
                    //console.log(self.routes);
                }, function errorCallBack(response) {

                });
            }
        }

        self.CountRoutes = function () {
            self.ResetItems();
            $scope.queryRoute = '';
            var count = 0;
            angular.forEach(self.routes, function (item) {
                if (item.Checked) {
                    count++;
                }
            });
            if (count == 0) {
                self.ListClients = null;
            } else if (count != self.routes.length) {
                self.GetClients(null, null, self.routes);
                $scope.selectAll = false;
            } else if (count == self.routes.length) {
                self.GetClients(null, null, self.routes);
                $scope.selectAll = true;
            }
        }

        self.ResetItems = function () {
            self.showErrorForm = false;
            self.ListClients = null;
            $scope.querySchemes = '';
            $scope.queryClients = '';
            $scope.selectAllClients = false;
            //$scope.inactClients = false;
            $scope.IdEsquema = "";
        }

        ////Llenar Esquemas
        self.schemes = GetSchemesClients();
        self.GetSchemesClients = GetSchemesClients;
        function GetSchemesClients(selectedItem, estado) {
            //console.log("inactRoutes: " + $scope.inactRoutes);
            if (selectedItem != undefined) {
                //console.log("CEDI: " + selectedItem);
                $http({
                    url: url + '/api/GetClientScheme/ObtenerEsquemaClientes?cedis=' + selectedItem.replace(/\+/g, "%2B") + "&estado=" + "1",
                    method: 'GET',
                    headers: {
                        Authorization: window.sessionStorage.getItem('Token'),
                        'Content-Type': 'application/json'
                    },
                }).then(function successCallBack(response) {
                    self.schemes = response.data;
                    //console.log("ESQUEMAS");
                    //console.log(self.schemes);
                }, function errorCallBack(response) {

                });
            }
        }

        //SELECCIONAR SOLO UN ESQUEMA
        self.bloquearEsquemas = bloquearEsquemas;
        function bloquearEsquemas() {
            //console.log("Dentro de la funcion bloquear");
            $scope.fillScheme = [];
            angular.forEach(self.schemes, function (item) {
                if (item.Checked == true) {
                    $scope.fillScheme.push(item.Checked);
                    //console.log("Item.Checked");
                }
            });

            if ($scope.fillScheme.length > 0) {
                //console.log("fillScheme > 0");
                //console.log(self.schemes);
                angular.forEach(self.schemes, function (item) {
                    if (item.Checked == true) {
                        item.Disabled = false;
                        $scope.IdEsquema = item.EsquemaID;
                        //console.log($scope.IdEsquema + " " + item.EsquemaID);
                    }
                    else {
                        item.Disabled = true;
                    }
                });
            }
            else if ($scope.fillScheme.length == 0) {
                angular.forEach(self.schemes, function (item) {
                    item.Checked = false;
                    item.Disabled = false;
                    $scope.IdEsquema = "";
                });
            }
        }

        //Fechas
        self.State = undefined;
        self.dateState = GetDates();
        function GetDates() {
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

        $scope.$watch("ctrl.date1", function () {
            if (self.State == "Igual") {
                self.showErrorForm = false;
            }
        });

        $scope.$watch("ctrl.date2", function () {
            if (self.State == "Entre") {
                self.showErrorForm = false;
            }

        });

        //Estado del rango de fecha
        function OnSelectChange(state) {
            if (state == 'Entre') {
                self.showSelect = 'true';
            }
            else {
                self.showSelect = undefined;
            }
        }

        function nShowLists(cedi) {
            $scope.IdEsquema = "";
            if (cedi == undefined) {
                self.showList = undefined;
            }
            else {
                self.showList = 'true';
            }
        }

        ////Seleccionar todas las Rutas
        self.SelectAllChekboxesRoutes = SelectAllChekboxesRoutes;
        function SelectAllChekboxesRoutes(selectAll) {
            if (selectAll == undefined || selectAll == false) {
                Todasrutas = true;
                angular.forEach(self.routes, function (item) {
                    item.Checked = true;
                });
            }

            else {
                Todasrutas = false;
                angular.forEach(self.routes, function (item) {
                    item.Checked = false;
                });
            }
            self.getAllClientes = GetClients;
        }

        //Seleccionar todos los Clientes
        self.SelectAllChekboxesClients = SelectAllCheckboxesClients;
        function SelectAllCheckboxesClients(selectAll) {
            if (selectAll == undefined || selectAll == false) {
                TodosClientes = true;
                angular.forEach(self.ListClients, function (item) {
                    item.Checked = true;
                });
            }

            else {
                TodosClientes = false;
                angular.forEach(self.ListClients, function (item) {
                    item.Checked = false;
                });
            }
        }

        //Llenar Esquema Clientes
        self.call = GetSchemeClients();
        self.GetSchemeClients = GetSchemeClients();
        function GetSchemeClients() {
            $http({
                url: url + '/api/GetClientScheme',
                method: 'GET',
                headers: {
                    Authorization: window.sessionStorage.getItem('Token'),
                    'Content-Type': 'application/json'
                },
            }).then(function successCallBack(response) {
                $scope.treedata = JSON.parse(response.data);
            }, function errorCallBack(response) {
            });
        }

        //Llenar Clientes
        self.getAllClientes = GetClients;
        self.ListClients = self.ListClients;
        function GetClients(Routes) {
            self.showErrorForm = false;
            self.ListClients = [];
            var esquemaId = $scope.IdEsquema;
            var rutas = "";
            if (esquemaId == "") {
                esquemaId = "Ninguno";
            }
            $http.post(url + '/Reports/GetRoutesStiring', {
                Routes: Routes
            }).success(function (data, status, headers, config) {
                if (data.length == 0) {
                    rutas = "Ninguna";
                } else {
                    rutas = data;
                }
                if (!(self.showList == undefined)) {
                    $http({
                        url: url + '/api/GetClients/ObtenerListaClientes?IdEsquema=' + esquemaId + "&Routes=" + rutas + '&Cedis=' + self.selectedItem.value,
                        method: 'GET',
                        headers: {
                            Authorization: window.sessionStorage.getItem('Token'),
                            'Content-Type': 'application/json'
                        },
                    }).then(function successCallBack(response) {
                        self.ListClients = response.data;
                    }, function errorCallBack(response) {
                    });
                }
            }).error(function (error, status, headers, config) {
            });
        }

        //MUESTRA UN MENSAJE DE ERROR
        function muestraError(cadena) {
            self.ErrorEnviar = cadena;
            self.showErrorForm = true;
            cfpLoadingBar.complete();
        }

        //Envia formulario completo
        function SubmitForm(Cedis, dateStatus, Routes, Clientes, pvEsFecha, campoFecha) {
            var countRoutes = 0;
            angular.forEach(self.routes, function (item) {
                if (item.Checked == true) {
                    countRoutes++;
                }
            });

            var esquemaClientes = "";
            angular.forEach(self.schemes, function (item) {
                if (item.Checked == true) {
                    esquemaClientes = item.EsquemaID;
                }
            });

            if (countRoutes <= 0 && $scope.IdEsquema == "") {
                muestraError("Seleccione una ruta, Esquema o un Cliente");
            }

            else if (self.State == undefined) {
                muestraError("Seleccione rango de fechas");
            }
            else if (self.State == 'Entre' && (self.date1 == undefined || self.date2 == undefined)) {
                muestraError("Seleccione las fechas");
            }
            else if (self.State == 'Entre' && (self.date1 > self.date2)) {
                muestraError("Rango de fechas erróneo");
            }
            else if (self.date1 == undefined) {
                muestraError("Seleccione una fecha");
            }
            else {
                if (TodosClientes) {
                    Clientes = null;
                }
                var data = {
                    nombreReport: $scope.TipoReporte,
                    //Cedis: self.selectedItem.value,
                    Cedis: esquemaClientes,
                    nombreCedis: self.selectedItem.display,
                    dateStatus: self.State,
                    Routes: Routes,
                    Clientes: Clientes,
                    init: self.date1,
                    end: self.date2,
                    vavclave: self.VAVClave,
                    reportType: self.ReportType,
                }

                $http.post(url + '/Reports/GetCondition', data, { ignoreLoadingBar: true })
                .success(function (data, status, headers, config) {
                    window.open(url + "/Reports/Ver?VAVClave=" + data.VAVClave + "&Cedis=" + data.Cedis.replace(/\+/g, "%2B") + "&nombreReport=" + data.nombreReport + "&nombreCedis=" + data.nombreCedis + "&FechaInicial=" + data.FechaInicial + "&FechaFinal=" + data.FechaFinal + "&dateStatus=" + data.Rango + "&Rutas=" + data.Rutas + "&Clientes=" + data.Clientes + "&Vendedor=" + data.Vendedor + "&detallado=" + data.reportType + "&unidadMedida=" + data.unidadMedida, "_blank");
                    cfpLoadingBar.complete();
                })
                .error(function (error, status, headers, config) {

                });
            }
        }
    }
})();