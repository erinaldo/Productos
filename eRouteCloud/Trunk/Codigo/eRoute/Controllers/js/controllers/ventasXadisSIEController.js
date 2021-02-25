app.controller('ventasXadisSIEController', ['$scope', '$mdToast', '$q', '$timeout', 'valorReferencia', '$http', 'cfpLoadingBar', function ($scope, $mdToast, $q, $timeout, valorReferencia, $http, cfpLoadingBar) {
    var self = this;
    var url = window.sessionStorage.getItem('URL');

    self.showSelect = undefined;
    self.OnSelectChange = OnSelectChange;
    self.minDate = undefined;
    self.maxDate = new Date();
    self.SubmitForm = SubmitForm;
    self.date1 = undefined;
    self.date2 = undefined;
    self.VAVClave = undefined;
    GetDates();

    $scope.EstablecerReporte = function (VAVClave) {
        valorReferencia.obtenerValorClave('REPORTEW', VAVClave, function (result) {
            self.titulo = result[0].Descripcion;
        });
    }

    //Fechas
    function GetDates() {
        $http({
            url: url + '/API/GetReportFilters/GetDateStatus',
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

    function OnSelectChange(state) {
        if (state == 'Entre') {
            self.showSelect = 'true';
        }
        else {
            self.showSelect = undefined;
            self.date2 = undefined;
        }
    }

    $scope.$watch("ctrl.date1", function () {
        if (self.date1 != undefined) {
            self.minDate = new Date(self.date1.getFullYear(), (self.date1.getMonth()), (self.date1.getDate() + 1));
        }
        if (self.State == "Entre" && self.date2 != undefined) {
            if (self.date1 >= self.date2) {
                self.date2 = undefined;
            }
        }
        if (self.showErrorForm) {
            self.showErrorForm = false;
        }
    });

    $scope.$watch("ctrl.date2", function () {
        if (self.State == "Entre" && self.date1 != undefined) {
            self.showErrorForm = false;
        }

    });

    self.startbar = function () {
        cfpLoadingBar.start();
    };

    function SubmitForm(VAVClave) {
        if (self.State == undefined) {
            muestraError("Seleccione rango de fechas");
        }
        else if (self.State == 'Entre' && (self.date1 == undefined || self.date2 == undefined)) {
            muestraError("Seleccione las fechas");
        }
        else if (self.State == 'Entre' && (self.date1 > self.date2)) {
            muestraError("Rango de fechas erróneo");
        }
        else if (self.date1 == undefined || self.date1 == "") {
            muestraError("Seleccione una fecha");
        }
        else {
            var data = {
                StatusDate: self.State,
                InitialDate: moment(self.date1).format('YYYY-MM-DD'),
                FinalDate: moment(self.date2).format('YYYY-MM-DD'),
                VAVClave: VAVClave,
                ReportName: self.titulo,
            }
            $http.post(url + '/Reports/SetCondition', data, { ignoreLoadingBar: true })
                .then(function () {
                    window.open(url + '/Reports/Ver');
                    cfpLoadingBar.complete();
                });
        }
    }

    function muestraError(cadena) {
        self.ErrorEnviar = cadena;
        self.showErrorForm = true;
        cfpLoadingBar.complete();
    }
}]);