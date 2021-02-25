(function () {
    angular
        .module('eRouteApp')
        .controller('concentradoMovAlmacenALTController', concentradoMovAlmacenALTController)
    concentradoMovAlmacenALTController.$inject = ['$scope', '$http', '$mdToast', '$q', '$timeout', 'NgMap', 'cfpLoadingBar', '$filter', "menuServices", "reportServices", "valorReferencia"];

    function concentradoMovAlmacenALTController($scope, $http, $mdToast, $q, $timeout, NgMap, cfpLoadingBar, $filter, menuServices, reportServices, valorReferencia) {

        var ctrl = this;
        var url = window.sessionStorage.getItem('URL');

        ctrl.showList = false;
        ctrl.showSelect = undefined;
        ctrl.nShowLists = nShowLists;
        ctrl.selectedItem = ctrl.selectedItem;
        ctrl.OnSelectChange = OnSelectChange;

        ctrl.maxDate = new Date();

        ctrl.minDate = new Date(
          ctrl.maxDate.getFullYear(),
          ctrl.maxDate.getMonth() - 6,
          ctrl.maxDate.getDate()
        );

        //muestra el segundo datepicker cuando el estado de la fecha es 'Entre'
        function OnSelectChange(state) {
            if (state == 'Entre') {
                ctrl.showSelect = 'true';
            }
            else {
                ctrl.showSelect = undefined;
            }
        }

        function nShowLists(state) {
            if (state == undefined) {
                ctrl.showList = undefined;
            }
            else {
                ctrl.showList = 'true';
            }
        }


        var self = this;
        self.simulateQuery = false;
        self.isDisabled = false;       
        
        $scope.EstablecerReporte = function (VAVClave) {
            valorReferencia.obtenerValorClave('REPORTEW', VAVClave, function (result) {
                ctrl.titulo = result[0].Descripcion;
            });
        }


        //dates state functions
        ctrl.State = undefined;
        ctrl.dateState = GetDates();

        function GetDates() {
            valorReferencia.obtenerValorClave('BFNUMERI', '1', function (result) {
                ctrl.State = '1';
                ctrl.dateState = result;
            });
        }

        ctrl.SubmitForm = SubmitForm;
        ctrl.date1 = undefined;
        ctrl.pvEsFecha = false;
        ctrl.VAVClave = undefined;
        ctrl.ReportType = false;

        ctrl.startbar = function () {
            cfpLoadingBar.start();
        };

        ctrl.completebar = function () {
            cfpLoadingBar.complete();
        };

        //envia el formulario completo
        function SubmitForm(Cedis, dateStatus, Routes, pvEsFecha, campoFecha) {
            if (ctrl.date1 == undefined) {
                alert("Seleccione una fecha");
                cfpLoadingBar.complete();
            }
            else if (ctrl.date1 > ctrl.maxDate)
            {
                alert("La fecha inicial debe ser menor o igual a la fecha actual");
                cfpLoadingBar.complete();
            }
            else {
                var data;
                data = {
                    nombreReport: ctrl.titulo,
                    dateStatus: ctrl.State,
                    init: ctrl.date1,
                    //end: ctrl.date1,
                    vavclave: ctrl.VAVClave,
                    reportType: ctrl.ReportType,
                }
                if (data.Cedis == undefined)
                    data.Cedis = "";

                $http.post(url + '/Reports/GetCondition', data, { ignoreLoadingBar: true })
                .success(function (data, status, headers, config) {
                    window.open(url + "/Reports/Ver", "_blank");
                    cfpLoadingBar.complete();
                })
                .error(function (error, status, headers, config) {
                });
            }
        }      

        var last = { bottom: true, top: false, left: true, right: false };

        //toast
        $scope.toastPosition = angular.extend({}, last);

        $scope.getToastPosition = function () {
            sanitizePosition();
            return Object.keys($scope.toastPosition)
              .filter(function (pos) { return $scope.toastPosition[pos]; })
              .join(' ');
        };

        function sanitizePosition() {
            var current = $scope.toastPosition;
            if (current.bottom && last.top) current.top = false;
            if (current.top && last.bottom) current.bottom = false;
            if (current.right && last.left) current.left = false;
            if (current.left && last.right) current.right = false;
            last = angular.extend({}, current);
        }

        function showSimpleToast(Message) {
            var pinTo = $scope.getToastPosition();
            $mdToast.show(
              $mdToast.simple()
                .textContent(Message)
                .position(pinTo)
                .hideDelay(3000)
            );
        };

    }
})();