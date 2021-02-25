app.controller('carteraMensualXRutaPDRController', ['$scope', '$mdToast', '$q', '$timeout', 'valorReferencia', '$http', 'cfpLoadingBar', function ($scope, $mdToast, $q, $timeout, valorReferencia, $http, cfpLoadingBar) {
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
        if (state == 'Entre') {
            self.date2 = undefined;
            self.showSelect = true;
        } else {
            self.date2 = self.date1;
            self.showSelect = false;
        }
    }

    //Llenar Rutas
    self.GetRoutes = function (selectedItem) {
        if (selectedItem != undefined) {
            $scope.RutaId = undefined;
            $scope.queryRoute = '';
            self.routes = undefined;
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
        var rutas = GetArrayValues(self.routes, $scope.RutaId);
        if ($scope.RutaId == undefined) {
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
            var data = {
                CEDIS: self.selectedItem.Clave.replace(/\+/g, "%2B"),
                NameCEDIS: self.selectedItem.Nombre,
                StatusDate: self.State,
                ReportName: self.titulo,
                InitialDate: moment(self.date1).format('YYYY-MM-DD'),
                FinalDate: moment(self.date2).format('YYYY-MM-DD'),
                ReportType: self.ReportType,
                ReportFilter: self.ReportFilter,
                VAVClave: self.VAVClave,
                Routes: rutas,
                ObjectName: rutas
            }
            $http.post(url + '/Reports/SetCondition', data, { ignoreLoadingBar: true })
                .then(function () {
                    window.open(url + '/Reports/Ver');
                    cfpLoadingBar.complete();
                });
        }
    }
}]);