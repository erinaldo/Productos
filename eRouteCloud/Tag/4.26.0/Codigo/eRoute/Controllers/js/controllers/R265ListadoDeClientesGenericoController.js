app.controller('R265ListadoDeClientesGenericoController', ['$scope', '$mdToast', '$q', '$timeout', 'valorReferencia', '$http', 'cfpLoadingBar', function ($scope, $mdToast, $q, $timeout, valorReferencia, $http, cfpLoadingBar) {
    var url = window.sessionStorage.getItem('URL');
    var self = this;
    self.showList = false;
    self.clients = 'false';
    self.switch = '';

    $scope.EstablecerReporte = function (VAVClave) {
        valorReferencia.obtenerValorClave('REPORTEW', VAVClave, function (result) {
            self.titulo = result[0].Descripcion;
            GetCEDIS();
        });
    }

    self.onChange = function (cbState) {
        if (cbState) {
            self.clients = '';
        } else {
            self.clients = cbState;
        }
    };

    //Llenar Almacenes
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
        }, function errorCallBack() {
        });
    }

    self.CountCedis = function () {
        $scope.queryCedi = '';
        var count = 0;
        var cedis = [];
        angular.forEach(self.cedis, function (item) {
            if (item.Checked) {
                count++;
                cedis.push(item.Clave);
            }
        });
        if (count !== 0) {
            if (count !== self.cedis.length) {
                self.GetRoutes(self.cedis);
                $scope.selectAllCedis = false;
            } else if (count === self.cedis.length) {
                self.GetRoutes(self.cedis);
                $scope.selectAllCedis = true;
            }
            self.showList = true;
        } else {
            $scope.selectAllCedis = false;
            self.showList = false;
        }
    }

    //Seleccionar todos los Almacenes
    self.SelectAllCheckboxesCedis = function (selectAllCedis) {
        $scope.queryCedi = '';
        if (selectAllCedis === undefined || selectAllCedis === false) {
            angular.forEach(self.cedis, function (item) {
                item.Checked = true;
            });
            self.showList = true;
            self.GetRoutes(self.cedis);
        } else {
            angular.forEach(self.cedis, function (item) {
                item.Checked = false;
            });
            self.showList = false;
            self.routes = undefined;
        }
    }

    //Llenar Rutas
    self.GetRoutes = function (cedis) {
        $scope.queryRoute = '';
        self.routes = undefined;
        $scope.selectAll = false;
        $http.post(url + '/Reports/GetObjectString', {
            Object: GetArrayValues(cedis)
        }).then(function (dataCedis, headers) {
            $http({
                url: url + '/API/GetReportFilters/GetRoutes?cedis=' + dataCedis.data.replace(/\+/g, "%2B"),
                method: 'GET',
                headers: {
                    Authorization: window.sessionStorage.getItem('Token'),
                    'Content-Type': 'application/json'
                },
            }).then(function successCallBack(response) {
                self.routes = response.data;
            }, function errorCallBack() {
            });
        });
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
        if (count !== 0) {
            if (count !== self.routes.length) {
                $scope.selectAll = false;
            } else if (count === self.routes.length) {
                $scope.selectAll = true;
            }
        } else {
            $scope.selectAll = false;
        }
    }

    //Seleccionar todas las Rutas
    self.SelectAllCheckboxesRoutes = function (selectAll) {
        $scope.queryRoute = '';
        if (selectAll === undefined || selectAll === false) {
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
            if (otro !== undefined) {
                if (item.Clave === otro) {
                    newArray.push({ Clave: item.Clave, Nombre: item.Nombre, Checked: true, Disabled: false });
                }
            } else {
                if (item.Checked === true) {
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
        var almacenes = [];

        if (!$scope.selectAllCedis) {
            almacenes = GetArrayValues(self.cedis);
        }

        if (!$scope.selectAll) {
            rutas = GetArrayValues(self.routes);
        }

        if (rutas.length <= 0 && !$scope.selectAll) {
            ErrorMessage("*Seleccione una Ruta");
        } else {
            rutas = ($scope.selectAll ? null : rutas);
            almacenes = ($scope.selectAllCedis ? null : almacenes);
            var data = {
                dataListObject: [almacenes, rutas],
                dataList: [self.clients],
                ReportName: self.titulo,
                VAVClave: self.VAVClave
            }
            $http.post(url + '/Reports/SetCondition', data, { ignoreLoadingBar: true })
            .then(function () {
                window.open(url + "/Reports/Ver");
                cfpLoadingBar.complete();
            });
        }
    }
}]);