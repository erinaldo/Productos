(function () {
    angular
        .module('eRouteApp')
        .controller('libroRutaVitereController', libroRutaVitereController)
    libroRutaVitereController.$inject = ['$scope', '$http', '$mdToast', '$q', '$timeout', 'NgMap', 'cfpLoadingBar', '$filter', "menuServices", "reportServices", "valorReferencia"];

    function libroRutaVitereController($scope, $http, $mdToast, $q, $timeout, NgMap, cfpLoadingBar, $filter, menuServices, reportServices, valorReferencia) {
        var url = window.sessionStorage.getItem('URL');
        var self = this;
        self.showList = false;
        self.nShowLists = nShowLists;
        self.selectedItem = undefined;
        self.minDate = new Date();
        self.SubmitForm = SubmitForm;
        self.date1 = undefined;
        self.VAVClave = undefined;
        self.ReportType = false;
        self.showErrorForm = false;

        $scope.EstablecerReporte = function (VAVClave) {
            valorReferencia.obtenerValorClave('REPORTEW', VAVClave, function (result) {
                self.titulo = result[0].Descripcion;
            });           
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

        ////Seleccionar todas las Rutas
        self.SelectAllChekboxesRoutes = SelectAllChekboxesRoutes;
        function SelectAllChekboxesRoutes(selectAll) {
            if (selectAll == undefined || selectAll == false) {
                selectAll = true;
                angular.forEach(self.routes, function (item) {
                    item.Checked = true;
                });
            }

            else {
                selectAll = false;
                angular.forEach(self.routes, function (item) {
                    item.Checked = false;
                });
            }
            //self.getAllClientes = GetClients;
        }

        //RutasInactivas
        self.inactivosClic = function (selectedItem) {
            var c = !$scope.inactR;

            if (selectedItem == undefined) {
                $http({
                    url: url + '/api/GetAllRoutes?inactivos=' + c,
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
            else {
                $http({
                    url: url + '/api/GetRoutes?Cedis=' + selectedItem.replace(/\+/g, "%2B") + "&inactivos=" + c,
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

        //Llenar Rutas
        self.routes = GetRoutes();
        self.GetRoutes = GetRoutes;
        function GetRoutes(selectedItem) {
            var c = true;

            if (selectedItem == undefined) {
                $http({
                    url: url + '/api/GetAllRoutes',
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
            else {
                $http({
                    url: url + '/api/GetRoutes?Cedis=' + selectedItem.replace(/\+/g, "%2B"),
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

        function nShowLists(cedi) {
            if (cedi == undefined) {
                self.showList = undefined;
            }
            else {
                self.showList = 'true';
            }
        }

        self.mostrarCEDI = mostrarCEDIselect;
        function mostrarCEDIselect(value) {
            if (!value) {
                self.selectedItem = null;
                self.searchText = null;
            }
        }

        //self.bloquearRutas = bloquearRutasCheckBox;
        //function bloquearRutasCheckBox() {
        //    self.showErrorForm = false;
        //    $scope.fillRoutes = [];

        //    angular.forEach(self.routes, function (item) {
        //        if (item.Checked == true) {
        //            $scope.fillRoutes.push(item.Checked);
        //        }
        //    });

        //    if ($scope.fillRoutes.length > 0) {
        //        angular.forEach(self.routes, function (item) {
        //            if (item.Checked == true) {
        //                item.Disabled = false;
        //            }
        //            else {
        //                item.Disabled = true;
        //            }
        //        });
        //    }
        //    else if ($scope.fillRoutes == 0) {
        //        angular.forEach(self.routes, function (item) {
        //            item.Checked = false;
        //            item.Disabled = false;
        //        });
        //    }
        //}

        //MUESTRA UN MENSAJE DE ERROR
        function muestraError(cadena) {
            self.ErrorEnviar = cadena;
            self.showErrorForm = true;
            cfpLoadingBar.complete();
        }

        function SubmitForm(Cedis, dateStatus, Routes, Clientes, pvEsFecha, campoFecha) {
            var countRoutes = 0;
            angular.forEach(self.routes, function (item) {

                if (item.Checked == true) {
                    countRoutes++;
                }
            });

            if (countRoutes <= 0) {
                muestraError("Seleccione una ruta");
            }

            else if (self.State == undefined) {
                muestraError("Seleccione rango de fechas");
            }
            else if (self.date1 == undefined) {
                muestraError("Seleccione una fecha");
            }
            else {
                var data;
                if (self.showList) {
                    data = {
                        nombreReport: self.titulo,
                        Cedis: self.selectedItem.value,
                        nombreCedis: self.selectedItem.display,
                        dateStatus: self.State,
                        Routes: Routes,
                        init: self.date1,
                        vavclave: self.VAVClave,
                        reportType: self.ReportType,
                    }
                }
                else {
                    data = {
                        nombreReport: self.titulo,
                        Cedis: '',
                        nombreCedis: '',
                        dateStatus: self.State,
                        Routes: Routes,
                        init: self.date1,
                        vavclave: self.VAVClave,
                        reportType: self.ReportType,
                    }
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