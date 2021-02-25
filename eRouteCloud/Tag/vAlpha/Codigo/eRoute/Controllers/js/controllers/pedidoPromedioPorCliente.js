(function () {
    angular
        .module('eRouteApp')
        .controller('pedidoPromedioPorCliente', pedidoPromedioPorCliente)
    pedidoPromedioPorCliente.$inject = ['$scope', '$http', '$mdToast', '$q', '$timeout', 'NgMap', 'cfpLoadingBar', '$filter', "menuServices", "reportServices", "valorReferencia"];

    function pedidoPromedioPorCliente($scope, $http, $mdToast, $q, $timeout, NgMap, cfpLoadingBar, $filter, menuServices, reportServices, valorReferencia) {
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

        $scope.EstablecerReporte = function (VAVClave) {
            valorReferencia.obtenerValorClave('REPORTEW', VAVClave, function (result) {
                self.titulo = result[0].Descripcion;
            });
        }


        //  LLENAR CEDIS
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

        //  HABILITA LOS FILTROS
        function nShowLists(cedi) {
            $scope.IdEsquema = "";
            if (cedi == undefined) {
                self.showList = undefined;
            }
            else {
                self.showList = 'true';
            }
        }

        ////    LLENAR RUTAS
        self.routes = GetRoutes();
        self.GetRoutes = GetRoutes;
        function GetRoutes(selectedItem, estado) {
            self.ListClients = [];
            //console.log("inactRoutes: " + $scope.inactRoutes);
            var inactivos = $scope.inactRoutes;
            //debugger;
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
                }, function errorCallBack(response) {

                });
            }
        }

        ////    LLENAR ESQUEMAS
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
                }, function errorCallBack(response) {

                });
            }
        }

        //  LLENAR CLIENTES
        self.getAllClientes = GetClients;
        self.ListClients = self.ListClients;
        function GetClients(Routes) {
            self.showErrorForm = false;
            self.ListClients = [];

            var esquemaId = "";

            angular.forEach(self.schemes, function (item) {
                if (item.Checked) {
                    esquemaId = item.EsquemaID;
                }
            });

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

        //  ESTADO DEL RANGO DE FECHA
        function OnSelectChange(state) {
            if (state == 'Entre') {
                self.showSelect = 'true';
            }
            else if (state == 'Igual') {
                self.showSelect = undefined;
                self.date2 = '';
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

        ////    SELECCIONAR TODAS LAS RUTAS
        self.SelectAllChekboxesRoutes = SelectAllChekboxesRoutes;
        function SelectAllChekboxesRoutes(selectAll) {
            if (selectAll == undefined || selectAll == false) {
                Todasrutas = true;
            }
            else {
                Todasrutas = false;
            }

            angular.forEach(self.routes, function (item) {
                item.Checked = Todasrutas;
            });

            self.getAllClientes = GetClients;
        }

        self.CountRoutes = function () {
            self.ResetItems();
            $scope.queryRoute = '';
            var count = 0;
            var ciclo = true;

            angular.forEach(self.routes, function (item) {
                if (ciclo) {
                    if (item.Checked) {
                        count++;
                    }
                    else {
                        ciclo = false;
                    }
                }
            });
            
            if (count == 0) {
                self.ListClients = null;
            } else if (count != self.routes.length) {
                $scope.selectAllRoutes = false;
                //self.GetClients(null, null, self.routes);
                self.GetClients;
            } else if (count == self.routes.length) {
                $scope.selectAllRoutes = true;
                //self.GetClients(null, null, self.routes);
                self.GetClients;
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

        //  SELECCIONAR SOLO UN ESQUEMA
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

        //  OBTENER LISTA DE CLIENTES CON ESQUEMA
        self.filtroClientesPorEsquema = filtroClientesPorEsquema;
        function filtroClientesPorEsquema(esquema) {
            $scope.IdEsquema = esquema;
            GetClients(self.routes);
            $scope.selectAllClients = false;
        }

        //  SELECCIONAR TODOS LOS CLIENTES
        self.SelectAllChekboxesClients = SelectAllCheckboxesClients;
        function SelectAllCheckboxesClients(selectAll) {
            cfpLoadingBar.start();
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
            cfpLoadingBar.complete();
        }

        self.CountClients = function () {
            $scope.queryClients = '';
            var count = 0;
            var ciclo = true;

            angular.forEach(self.ListClients, function (item) {
                if (ciclo) {
                    if (item.Checked) {
                        count++;
                    }
                    else {
                        ciclo = false;
                    }
                }
            });

            if (count == self.ListClients.length) {
                $scope.selectAllClients = true;
            } else {
                $scope.selectAllClients = false;
            }
        }

        self.startbar = function () {
            cfpLoadingBar.start();
        };

        self.completebar = function () {
            cfpLoadingBar.complete();
        };

        //  ENVIA FORMULARIO COMPLETO
        function SubmitForm(Cedis, dateStatus, Routes, Clientes, Vavclave) {
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
                muestraError("Seleccione una Ruta, Esquema o un Cliente");
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
                var data = {
                    nombreReport: self.titulo,
                    VAVClave: self.VAVClave,
                    //Cedis: self.selectedItem.value,
                    Cedis: esquemaClientes,
                    nombreCedis: self.selectedItem.display,
                    dateStatus: self.State,
                    Routes: Routes,
                    Clientes: Clientes,
                    init: self.date1,
                    end: self.date2,
                    promocion: $scope.TipoReporte,
                }

                $http.post(url + '/Reports/GetCondition', data, { ignoreLoadingBar: true })
                .success(function (data, status, headers, config) {
                    //window.open(url + "/Reports/Ver?VAVClave=" + data.VAVClave + "&Cedis=" + data.Cedis.replace(/\+/g, "%2B") + "&nombreReport=" + data.nombreReport + "&nombreCedis=" + data.nombreCedis + "&FechaInicial=" + data.FechaInicial + "&FechaFinal=" + data.FechaFinal + "&dateStatus=" + data.Rango + "&Rutas=" + data.Rutas + "&Clientes=" + data.Clientes + "&Vendedor=" + data.Vendedor + "&detallado=" + data.reportType + "&unidadMedida=" + data.unidadMedida, "_blank");
                    window.open(url + "/Reports/Ver", "_blank");
                    cfpLoadingBar.complete();
                })
                .error(function (error, status, headers, config) {

                });
            }
        }

        //MUESTRA UN MENSAJE DE ERROR
        function muestraError(cadena) {
            self.ErrorEnviar = cadena;
            self.showErrorForm = true;
            cfpLoadingBar.complete();
        }

    }
})();