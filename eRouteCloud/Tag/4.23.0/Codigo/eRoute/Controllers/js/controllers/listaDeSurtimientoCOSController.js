(function () {
    angular
        .module('eRouteApp')
        .controller('listaDeSurtimientoCOSController', listaDeSurtimientoCOSController)
    listaDeSurtimientoCOSController.$inject = ['$scope', '$http', '$mdToast', '$q', '$timeout', 'NgMap', 'cfpLoadingBar', '$filter', "menuServices", "reportServices", "valorReferencia"];

    function listaDeSurtimientoCOSController($scope, $http, $mdToast, $q, $timeout, NgMap, cfpLoadingBar, $filter, menuServices, reportServices, valorReferencia) {

        var url = window.sessionStorage.getItem('URL');
        var self = this;
        self.showList = false;
        self.minDate = new Date();
        self.ReportType = false;
        self.ReportFilter = false;

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

        //Llenar Rutas
        self.GetRoutes = function (selectedItem, estado) {
            if (selectedItem != undefined) {
                $scope.queryRoute = '';
                self.routes = null;
                $scope.selectAll = false;
                if (!$scope.inactRoutes) {
                    estado = 1;
                }
                $http.post(url + '/Reports/GetCedisString', {
                    Cedis: selectedItem
                }).success(function (data, status, headers, config) {
                    $http({
                        url: url + '/api/GetRoutes/GETRoutes?cedis=' + data + "&estado=" + estado,
                        method: 'GET',
                        headers: {
                            Authorization: window.sessionStorage.getItem('Token'),
                            'Content-Type': 'application/json'
                        },
                    }).then(function successCallBack(response) {
                        self.routes = response.data;
                    }, function errorCallBack(response) {
                    });
                }).error(function (error, status, headers, config) {
                });
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

        //Estado del rango de fecha
        self.OnSelectChange = function (state) {
            self.showErrorForm = false;
            if (state == 'Entre') {
                self.showSelect = true;
            } else {
                self.showSelect = false;
                self.date2 = undefined;
            }
            self.date1 = self.minDate;
        }

        self.ShowItems = function (selectedItem) {
            self.showErrorForm = false;
            if (selectedItem == undefined) {
                self.showList = false;
            } else {
                self.showList = true;
            }
        }

        //Seleccionar todas las Rutas
        self.SelectAllChekboxesRoutes = function (selectAll) {
            $scope.queryRoute = '';
            if (selectAll == undefined || selectAll == false) {
                angular.forEach(self.routes, function (item) {
                    item.Checked = true;
                });
            } else {
                angular.forEach(self.routes, function (item) {
                    item.Checked = false;
                });
            }
        }

        self.startbar = function () {
            cfpLoadingBar.start();
        };

        function ErrorMessage(cadena) {
            self.ShowError = cadena;
            self.showErrorForm = true;
            cfpLoadingBar.complete();
        }

        self.CountRoutes = function () {
            self.showErrorForm = false;
            $scope.queryRoute = '';
            var count = 0;
            angular.forEach(self.routes, function (item) {
                if (item.Checked) {
                    count++;
                }
            });
            if (count != self.routes.length) {
                $scope.selectAll = false;
            } else if (count == self.routes.length) {
                $scope.selectAll = true;
            }
        }

        //Envia formulario completo
        self.SubmitForm = function () {
            var countRoutes = 0;
            angular.forEach(self.routes, function (item) {
                if (item.Checked == true) {
                    countRoutes++;
                }
            });
            if (countRoutes <= 0) {
                ErrorMessage("*Seleccione una Ruta");
            } else if (self.date1 == undefined) {
                ErrorMessage("*Seleccione la fecha");
            } else {
                var data;
                data = {
                    Routes: self.routes
                }

                $http.post(url + '/Reports/GetCondition', data, { ignoreLoadingBar: true })
                .success(function (data, status, headers, config) {
                    window.open(url + "/Reports/Ver?VAVClave=" + self.VAVClave + "&Cedis=" + self.selectedItem.value.replace(/\+/g, "%2B") + "&nombreCedis=" + self.selectedItem.display + "&FechaInicial=" + self.date1.toJSON() + "&dateStatus=" + self.State + "&Rutas=" + data.Rutas, "_blank");
                    cfpLoadingBar.complete();
                })
                .error(function (error, status, headers, config) {
                });
            }
        }
    }
})(); (function () {
    angular
        .module('eRouteApp')
        .controller('listaDeSurtimientoCOSController', listaDeSurtimientoCOSController)
    listaDeSurtimientoCOSController.$inject = ['$scope', '$http', '$mdToast', '$q', '$timeout', 'NgMap', 'cfpLoadingBar', '$filter', "menuServices", "reportServices", "valorReferencia"];

    function listaDeSurtimientoCOSController($scope, $http, $mdToast, $q, $timeout, NgMap, cfpLoadingBar, $filter, menuServices, reportServices, valorReferencia) {

        var url = window.sessionStorage.getItem('URL');
        var self = this;
        self.showList = false;
        self.minDate = new Date();
        self.ReportType = false;
        self.ReportFilter = false;

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

        //Llenar Rutas
        self.GetRoutes = function (selectedItem, estado) {
            if (selectedItem != undefined) {
                $scope.queryRoute = '';
                self.routes = null;
                $scope.selectAll = false;
                if (!$scope.inactRoutes) {
                    estado = 1;
                }
                $http.post(url + '/Reports/GetCedisString', {
                    Cedis: selectedItem
                }).success(function (data, status, headers, config) {
                    $http({
                        url: url + '/api/GetRoutes/GETRoutes?cedis=' + data + "&estado=" + estado,
                        method: 'GET',
                        headers: {
                            Authorization: window.sessionStorage.getItem('Token'),
                            'Content-Type': 'application/json'
                        },
                    }).then(function successCallBack(response) {
                        self.routes = response.data;
                    }, function errorCallBack(response) {
                    });
                }).error(function (error, status, headers, config) {
                });
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

        //Estado del rango de fecha
        self.OnSelectChange = function (state) {
            self.showErrorForm = false;
            if (state == 'Entre') {
                self.showSelect = true;
            } else {
                self.showSelect = false;
                self.date2 = undefined;
            }
            self.date1 = self.minDate;
        }

        self.ShowItems = function (selectedItem) {
            self.showErrorForm = false;
            if (selectedItem == undefined) {
                self.showList = false;
            } else {
                self.showList = true;
            }
        }

        //Seleccionar todas las Rutas
        self.SelectAllChekboxesRoutes = function (selectAll) {
            $scope.queryRoute = '';
            if (selectAll == undefined || selectAll == false) {
                angular.forEach(self.routes, function (item) {
                    item.Checked = true;
                });
            } else {
                angular.forEach(self.routes, function (item) {
                    item.Checked = false;
                });
            }
        }

        self.startbar = function () {
            cfpLoadingBar.start();
        };

        function ErrorMessage(cadena) {
            self.ShowError = cadena;
            self.showErrorForm = true;
            cfpLoadingBar.complete();
        }

        self.CountRoutes = function () {
            self.showErrorForm = false;
            $scope.queryRoute = '';
            var count = 0;
            angular.forEach(self.routes, function (item) {
                if (item.Checked) {
                    count++;
                }
            });
            if (count != self.routes.length) {
                $scope.selectAll = false;
            } else if (count == self.routes.length) {
                $scope.selectAll = true;
            }
        }

        //Envia formulario completo
        self.SubmitForm = function () {
            var countRoutes = 0;
            angular.forEach(self.routes, function (item) {
                if (item.Checked == true) {
                    countRoutes++;
                }
            });
            if (countRoutes <= 0) {
                ErrorMessage("*Seleccione una Ruta");
            } else if (self.date1 == undefined) {
                ErrorMessage("*Seleccione la fecha");
            } else {
                var data;
                data = {
                    Cedis: self.selectedItem.value,
                    nombreCedis: self.selectedItem.display,
                    dateStatus: self.State,
                    Routes: self.routes,
                    init: self.date1,
                    end: self.date2,
                    vavclave: self.VAVClave,
                    nombreReport: self.titulo,
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