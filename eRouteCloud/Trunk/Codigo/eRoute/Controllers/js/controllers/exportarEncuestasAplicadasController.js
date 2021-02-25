app.controller('exportarEncuestasAplicadasController', ['$scope', '$mdToast', '$q', '$timeout', 'valorReferencia', '$http', 'cfpLoadingBar', function ($scope, $mdToast, $q, $timeout, valorReferencia, $http, cfpLoadingBar) {
    var url = window.sessionStorage.getItem('URL');
    var self = this;
    self.showList = false;
    self.minDate = new Date();

    $scope.EstablecerReporte = function (VAVClave) {
        valorReferencia.obtenerValorClave('REPORTEW', VAVClave, function (result) {
            self.titulo = result[0].Descripcion;
            GetDates();
            GetPolls();
            GetCEDIS();
        });
    }

    //Llenar Fechas
    function GetDates() {
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

    //Estado del Rango de Fecha
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

    //Llenar Encuestas
    function GetPolls() {
        $scope.EncuestaId = undefined;
        $scope.queryPolls = '';
        self.polls = undefined;
        $http({
            url: url + '/API/GetReportFilters/GetPolls',
            method: 'GET',
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-Type': 'application/json'
            },
        }).then(function successCallBack(response) {
            self.polls = response.data;
        }, function errorCallBack(response) {
        });
    }

    //Llenar CEDIS
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

    self.CountCEDIS = function () {
        self.showErrorForm = false;
        $scope.queryCEDIS = '';
        $scope.queryRoutes = '';
        $scope.queryPolls = '';
        self.routes = undefined;
        $scope.selectAllRoutes = false;
        $scope.selectAllCEDIS = false;
        var count = 0;
        var routes = [];
        angular.forEach(self.cedis, function (item) {
            if (item.Checked) {
                count++;
                routes.push(item.Clave);
            }
        });
        if (count != 0) {
            if (count != self.cedis.length) {
                self.GetRoutes(self.cedis);
                $scope.selectAllCEDIS = false;
            } else if (count == self.cedis.length) {
                self.GetRoutes(self.cedis);
                $scope.selectAllCEDIS = true;
            }
        }
    }

    //Seleccionar todos los CEDIS
    self.SelectAllCheckboxesCEDIS = function (selectAll) {
        self.showErrorForm = false;
        $scope.queryCEDIS = '';
        $scope.queryRoutes = '';
        $scope.queryPolls = '';
        self.routes = undefined;
        $scope.selectAllRoutes = false;
        if (selectAll == undefined || selectAll == false) {
            angular.forEach(self.cedis, function (item) {
                item.Checked = true;
            });
            self.GetRoutes(self.cedis);
        }
        else {
            angular.forEach(self.cedis, function (item) {
                item.Checked = false;
            });
            self.routes = undefined;
        }
    }

    //Llenar Rutas
    self.GetRoutes = function (cedis) {
        self.showErrorForm = false;
        $scope.queryRoutes = '';
        $scope.queryPolls = '';
        self.routes = undefined;
        $scope.selectAllRoutes = false;
        $http.post(url + '/Reports/GetObjectString', {
            Object: GetArrayValues(cedis)
        }).then(function (dataCEDIS) {
            $http({
                url: url + '/API/GetReportFilters/GetRoutes?cedis=' + dataCEDIS.data.replace(/\+/g, "%2B"),
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

    self.CountRoutes = function () {
        self.showErrorForm = false;
        $scope.queryRoutes = '';
        $scope.queryPolls = '';
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
                $scope.selectAllRoutes = false;
            } else if (count == self.routes.length) {
                $scope.selectAllRoutes = true;
            }
        }
    }

    //Seleccionar todas las Rutas
    self.SelectAllCheckboxesRoutes = function (selectAll) {
        self.showErrorForm = false;
        $scope.queryRoutes = '';
        $scope.queryPolls = '';
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
        var cedis = [];
        if (!$scope.selectAllRoutes) {
            rutas = GetArrayValues(self.routes);
        }

        if (!$scope.selectAllCEDIS) {
            cedis = GetArrayValues(self.cedis);
        }

        var encuestas = GetArrayValues(self.polls, $scope.EncuestaId);
        if ($scope.EncuestaId == undefined) {
            ErrorMessage("*Seleccione una Encuesta");
        } else if (cedis.length <= 0 && !$scope.selectAllCEDIS) {
            ErrorMessage("*Seleccione un Centro de Distribución");
        } else if (rutas.length <= 0 && !$scope.selectAllRoutes) {
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
            rutas = ($scope.selectAllRoutes ? null : rutas);
            var data = {
                StatusDate: self.State,
                ReportName: self.titulo,
                InitialDate: moment(self.date1).format('YYYY-MM-DD'),
                FinalDate: moment(self.date2).format('YYYY-MM-DD'),
                ReportFilter: self.ReportFilter,
                VAVClave: self.VAVClave,
                Routes: rutas,
                Polls: encuestas,
                ObjectName: encuestas
            }
            $http.post(url + '/Reports/SetCondition', data, { ignoreLoadingBar: true })
                .then(function () {
                    window.open(url + '/Reports/Ver');
                    cfpLoadingBar.complete();
                });
        }
    }
}]);