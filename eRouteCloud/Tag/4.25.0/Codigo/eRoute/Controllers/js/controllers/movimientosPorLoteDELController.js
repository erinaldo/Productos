app.controller('movimientosPorLoteDELController', ['$scope', '$mdToast', '$q', '$timeout', 'valorReferencia', '$http', 'cfpLoadingBar', function ($scope, $mdToast, $q, $timeout, valorReferencia, $http, cfpLoadingBar) {
    var url = window.sessionStorage.getItem('URL');
    var self = this;
    self.showList = false;
    self.minDate = new Date();

    $scope.EstablecerReporte = function (VAVClave) {
        valorReferencia.obtenerValorClave('REPORTEW', VAVClave, function (result) {
            self.titulo = result[0].Descripcion;
            self.GetLotes();
            self.GetDates();
        });
    }

    //Llenar Lotes
    self.GetLotes = function (estado) {
        self.showErrorForm = false;
        $scope.queryLote = '';
        self.lotes = null;
        $scope.selectAll = false;
        if (!$scope.inactLotes || $scope.inactLotes == undefined) {
            estado = 1;
        }
        $http({
            url: url + '/API/GetReportFilters/GetLots?estado=' + estado,
            method: 'GET',
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-Type': 'application/json'
            },
        }).then(function successCallBack(response) {
            self.lotes = response.data;
        }, function errorCallBack(response) {
        });
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

    self.SelectAllCheckboxesLotes = function (selectAll) {
        self.showErrorForm = false;
        $scope.queryLote = '';
        if (selectAll == undefined || selectAll == false) {
            angular.forEach(self.lotes, function (item) {
                item.Checked = true;
            });
        } else {
            angular.forEach(self.lotes, function (item) {
                item.Checked = false;
            });
        }
    }

    self.CountLotes = function () {
        self.showErrorForm = false;
        $scope.queryLote = '';
        var count = 0;
        angular.forEach(self.lotes, function (item) {
            if (item.Checked) {
                count++;
            }
        });
        if (count != self.lotes.length) {
            $scope.selectAll = false;
        } else if (count == self.lotes.length) {
            $scope.selectAll = true;
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

    //Envia formulario completo
    self.SubmitForm = function () {
        var lotes = [];
        if (!$scope.selectAll) {
            lotes = GetArrayValues(self.lotes);
        }
        if (lotes.length <= 0 && !$scope.selectAll) {
            ErrorMessage("*Seleccione un Lote");
        } else if (self.State == undefined) {
            ErrorMessage("*Seleccione rango de fechas");
        } else if (self.State == 'Entre' && (self.date1 == undefined || self.date2 == undefined)) {
            ErrorMessage("*Seleccione las fechas");
        } else if (self.State == 'Entre' && (self.date2 <= self.date1)) {
            ErrorMessage("*Rango de fechas erróneo");
        } else if (self.date1 == undefined) {
            ErrorMessage("*Seleccione la fecha");
        } else {
            lotes = ($scope.selectAll ? null : lotes);
            var data = {
                VAVClave: self.VAVClave,
                Lots: lotes,
                StatusDate: self.State,
                InitialDate: moment(self.date1).format('YYYY-MM-DD'),
                FinalDate: moment(self.date2).format('YYYY-MM-DD'),
                ReportName: self.titulo
            }
            $http.post(url + '/Reports/SetCondition', data, { ignoreLoadingBar: true })
                .then(function () {
                    window.open(url + '/Reports/Ver');
                    cfpLoadingBar.complete();
                });
        }
    }
}]);