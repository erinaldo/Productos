(function () {
    angular
        .module('eRouteApp')
        .controller('vendedorClienteModelListPreBYDController', vendedorClienteModelListPreBYDController)
    vendedorClienteModelListPreBYDController.$inject = ['$scope', '$http', '$mdToast', '$q', '$timeout', 'NgMap', 'cfpLoadingBar', '$filter', "menuServices", "reportServices"];

    function vendedorClienteModelListPreBYDController($scope, $http, $mdToast, $q, $timeout, NgMap, cfpLoadingBar, $filter, menuServices, reportServices) {
        var url = window.sessionStorage.getItem('URL');
        var self = this;
        //self.showList = false;
        //self.nShowLists = nShowLists;
        self.selectedItem = undefined;
        self.OnSelectChange = OnSelectChange;
        self.minDate = new Date();
        self.SubmitForm = SubmitForm;
        self.date1 = undefined;
        self.date2 = undefined;
        self.VAVClave = undefined;
        self.ReportType = false;
        self.showErrorForm = false;

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

        $scope.$watch("ctrl.date2", function () {
            if (self.State == "Entre") {
                self.showErrorForm = false;
            }
        });

        //Estado del rango de fecha
        function OnSelectChange(state) {
            if (state == 'Entre') {
                //console.log("Fecha Entre");
                self.showSelect = 'true';
            }
            else if (state == 'Igual') {
                //console.log("Fecha Igual");
                self.showSelect = undefined;
                self.date2 = '';
            }
        }

        self.mostrarCEDI = mostrarCEDIselect;
        function mostrarCEDIselect(value) {
            if (!value) {
                self.selectedItem = null;
                self.searchText = null;
            }
        }

        //MUESTRA UN MENSAJE DE ERROR
        function muestraError(cadena) {
            self.ErrorEnviar = cadena;
            self.showErrorForm = true;
            cfpLoadingBar.complete();
        }

        function SubmitForm(Cedis, dateStatus, Routes, Clientes, pvEsFecha, campoFecha) {
            debugger;
            if (self.State == undefined) {
                muestraError("Seleccione rango de fechas");
            }
            else if (self.State == 'Entre' && (self.date1 == undefined || self.date2 == undefined)) {
                muestraError("Seleccione las fechas");
            }
            else if (self.State == 'Entre' && (self.date1 > self.date2)) {
                muestraError("Rango de fechas erróneo");
            }
            else if (self.date1 == undefined) {
                muestraError("Seleccione una fecha");
            }
            else {
                var nomCEDI = ''
                if (Cedis === undefined) {
                    Cedis = '';
                } else if (Cedis != '') {
                    nomCEDI = self.selectedItem.display;
                }

                var data = {
                    nombreReport: "Vendedor Cliente Modelo Lista",
                    Cedis: Cedis,
                    nombreCedis: nomCEDI,
                    dateStatus: self.State,
                    init: self.date1,
                    end: self.date2,
                    vavclave: self.VAVClave,
                    reportType: self.ReportType,
                }

                $http.post(url + '/Reports/GetCondition', data, { ignoreLoadingBar: true })
                .success(function (data, status, headers, config) {
                    window.open(url + "/Reports/Ver?VAVClave=" + data.VAVClave + "&Cedis=" + data.Cedis.replace(/\+/g, "%2B") + "&nombreReport=" + data.nombreReport + "&nombreCedis=" + data.nombreCedis + "&FechaInicial=" + data.FechaInicial + "&FechaFinal=" + data.FechaFinal + "&dateStatus=" + data.Rango + "&Rutas=" + data.Rutas + "&Clientes=" + data.Clientes + "&Vendedor=" + data.Vendedor + "&detallado=" + data.reportType + "&unidadMedida=" + data.unidadMedida, "_blank");
                    cfpLoadingBar.complete();
                })
                .error(function (error, status, headers, config) {

                });
            }
        }
    }
})();