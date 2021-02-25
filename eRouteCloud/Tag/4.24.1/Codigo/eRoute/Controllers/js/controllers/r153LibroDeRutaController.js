(function () {
    angular
        .module('eRouteApp')
        .controller('r153LibroDeRutaController', r153LibroDeRutaController)
    r153LibroDeRutaController.$inject = ['$scope', '$http', 'cfpLoadingBar', '$filter', "valorReferencia"];

    function r153LibroDeRutaController($scope, $http, cfpLoadingBar, $filter, valorReferencia) {
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
                self.date1 = self.minDate;
            }, function errorCallBack(response) {
            });
        }

        //Llenar Rutas
        self.GetRoutes = function (selectedItem, estado) {
            if (selectedItem != undefined) {
                $scope.queryRoute = '';
                self.routes = undefined;
                $scope.selectAll = false;
                if (!$scope.inactRoutes) {
                    estado = 1;
                }
                $http({
                    url: url + '/API/GetModel/GetRoutes?cedis=' + selectedItem.replace(/\+/g, "%2B") + "&estado=" + estado,
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

        self.CountRoutes = function () {
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

        //Seleccionar todas las Rutas
        self.SelectAllCheckboxesRoutes = function (selectAll) {
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
            var rutas = [];
            if (!$scope.selectAll) {
                rutas = GetArrayValues(self.routes);
            }
            if (rutas.length <= 0 && !$scope.selectAll) {
                ErrorMessage("*Seleccione una Ruta");
            } else if (self.date1 == undefined) {
                ErrorMessage("*Seleccione la fecha");
            } else {
                rutas = ($scope.selectAll ? null : rutas);
                var data = {
                    CEDIS: self.selectedItem.Clave,
                    NameCEDIS: self.selectedItem.Nombre,
                    ReportName: self.titulo,
                    InitialDate: self.date1.toJSON(),
                    VAVClave: self.VAVClave,
                    Routes: rutas,
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