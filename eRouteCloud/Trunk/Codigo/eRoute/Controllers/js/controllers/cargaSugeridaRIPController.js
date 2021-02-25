app.controller('cargaSugeridaRIPController', ['$scope', '$mdToast', '$q', '$timeout', 'valorReferencia', '$http', 'cfpLoadingBar', function ($scope, $mdToast, $q, $timeout, valorReferencia, $http, cfpLoadingBar) {
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

    //Llenar Rutas
    self.GetRoutes = function (selectedItem, estado) {
        if (selectedItem != undefined) {
            $scope.queryRoute = '';
            self.routes = null;
            if (!$scope.inactRoutes) {
                estado = 1;
            }
            $http.post(url + '/Reports/GetCedisString', {
                Cedis: selectedItem
            }).then(function (response) {
                $http({
                    url: url + '/api/GetRoutes/GETRoutes?cedis=' + response.data + "&estado=" + estado,
                    method: 'GET',
                    headers: {
                        Authorization: window.sessionStorage.getItem('Token'),
                        'Content-Type': 'application/json'
                    },
                }).then(function successCallBack(response) {
                    self.routes = response.data;
                }, function errorCallBack(response) {
                });
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

    self.startbar = function () {
        cfpLoadingBar.start();
    };

    function ErrorMessage(cadena) {
        self.ShowError = cadena;
        self.showErrorForm = true;
        cfpLoadingBar.complete();
    }

    //Envia formulario completo
    self.SubmitForm = function (Routes) {
        if ($scope.RUTClave == undefined) {
            ErrorMessage("*Seleccione una Ruta");
        } else if (self.State == undefined) {
            ErrorMessage("*Seleccione rango de fechas");
        } else if (self.State == 'Entre' && (self.date1 == undefined || self.date2 == undefined)) {
            ErrorMessage("*Seleccione las fechas");
        } else if (self.State == 'Entre' && (self.date2 <= self.date1)) {
            ErrorMessage("*Rango de fechas erróneo");
        } else if (self.date1 == undefined) {
            ErrorMessage("*Seleccione la fecha");
        } else {
            var nameRoute;
            angular.forEach(self.routes, function (item) {
                if (item.RUTClave == Routes) {
                    nameRoute = item.Descripcion;
                }
            });
            var data = {
                Cedis: self.selectedItem.value,
                nombreCedis: self.selectedItem.display,
                dateStatus: self.State,
                Routes: Routes,
                nombreProductos: nameRoute,
                init: moment(self.date1).format('YYYY-MM-DD'),
                end: moment(self.date2).format('YYYY-MM-DD'),
                vavclave: self.VAVClave,
                nombreReport: self.titulo,
            }
            $http.post(url + '/Reports/GetCondition', data, { ignoreLoadingBar: true })
                .then(function () {
                    window.open(url + '/Reports/Ver');
                    cfpLoadingBar.complete();
                });
        }
    }
}]);