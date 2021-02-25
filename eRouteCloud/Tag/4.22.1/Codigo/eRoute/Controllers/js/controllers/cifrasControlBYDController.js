(function () {
    angular
        .module('eRouteApp')
        .controller('cifrasControlBYDController', cifrasControlBYDController)
    cifrasControlBYDController.$inject = ['$scope', '$http', '$mdToast', '$q', '$timeout', 'NgMap', 'cfpLoadingBar', '$filter', "menuServices", "reportServices", "valorReferencia"];

    function cifrasControlBYDController($scope, $http, $mdToast, $q, $timeout, NgMap, cfpLoadingBar, $filter, menuServices, reportServices, valorReferencia) {
        var url = window.sessionStorage.getItem('URL');
        var self = this;
        self.showList = false;
        self.minDate = new Date();

        $scope.EstablecerReporte = function (VAVClave) {
            valorReferencia.obtenerValorClave('REPORTEW', VAVClave, function (result) {
                self.titulo = result[0].Descripcion;
                GetCEDIS();
                self.GetDates();
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

        //Fechas
        self.GetDates = function () {
            self.showErrorForm = false;
            self.State = undefined;
            self.date1 = undefined;
            self.date2 = undefined;
            self.showSelect = false;
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
            if (self.State == undefined) {
                ErrorMessage("*Seleccione rango de fechas");
            } else if (self.State == 'Entre' && (self.date1 == undefined || self.date2 == undefined)) {
                ErrorMessage("*Seleccione las fechas");
            } else if (self.State == 'Entre' && (self.date2 <= self.date1)) {
                ErrorMessage("*Rango de fechas erróneo");
            } else if (self.date1 == undefined) {
                ErrorMessage("*Seleccione la fecha");
            } else {
                var CEDIS = null;
                var NameCEDIS = null;
                if (self.selectedItem != undefined || self.selectedItem != null) {
                    CEDIS = self.selectedItem.Clave;
                    NameCEDIS = self.selectedItem.Nombre;
                }
                var data = {
                    CEDIS: CEDIS,
                    NameCEDIS: NameCEDIS,
                    StatusDate: self.State,
                    ReportName: self.titulo,
                    InitialDate: self.date1.toJSON(),
                    FinalDate: self.date2.toJSON(),
                    VAVClave: self.VAVClave
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