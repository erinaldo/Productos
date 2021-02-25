(function () {
    angular
        .module('eRouteApp')
        .controller('exportarEncuestasAplicadasController', exportarEncuestasAplicadasController)
    exportarEncuestasAplicadasController.$inject = ['$scope', '$http', '$mdToast', '$q', '$timeout', 'NgMap', 'cfpLoadingBar', '$filter', "menuServices", "reportServices", "valorReferencia"];

    function exportarEncuestasAplicadasController($scope, $http, $mdToast, $q, $timeout, NgMap, cfpLoadingBar, $filter, menuServices, reportServices, valorReferencia) {

        var ctrl = this;
        var url = window.sessionStorage.getItem('URL');

        ctrl.url = undefined;
        ctrl.showList = false;
        ctrl.showSelect = undefined;
        ctrl.nShowLists = nShowLists;
        ctrl.selectedItem = ctrl.selectedItem;
        ctrl.OnSelectChange = OnSelectChange;
        ctrl.minDate = new Date();
        ctrl.GetList;


        GetList();
        function GetList() {
            menuServices.getReportList()
                .then(function successCallback(response) {
                    ctrl.GetList = response.data;
                },
                function errorCallback(response) {
                    if (response.status == 401) {
                        window.sessionStorage.clear();
                        window.location = url + '/Login';
                    }
                });
        }

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

        function loadAll(s) {
            var allstates = s;
            return allstates.toString().split(',').map(function (state) {
                return {
                    value: state.toString().substr(0, state.indexOf(' ')),
                    display: state
                };
            });
        }

        $scope.EstablecerReporte = function (VAVClave) {
            valorReferencia.obtenerValorClave('REPORTEW', VAVClave, function (result) {
                ctrl.titulo = result[0].Descripcion;
            });
            GetEncuestas()
        }

        //dates state functions
        ctrl.State = undefined;
        ctrl.dateState = GetDates();

        function GetDates() {
            $http({
                url: url + '/api/GetDateStatus',
                method: 'GET',
                headers: {
                    Authorization: window.sessionStorage.getItem('Token'),
                    'Content-Type': 'application/json'
                },
            }).then(function successCallBack(response) {
                ctrl.dateState = response.data;
            }, function errorCallBack(response) {

            });
        }

        //cedis functions
        $scope.GetCediss = function () {
            $http({
                url: url + '/api/GetCedis',
                method: 'GET',
                headers: {
                    Authorization: window.sessionStorage.getItem('Token'),
                    'Content-Type': 'application/json'
                },
                params: { USUId: window.sessionStorage.getItem('USUId') }
            }).then(function successCallBack(response) {
                ctrl.cediss = response.data;
            }, function errorCallBack(response) {
            });
        }

        ctrl.SelectAllChekboxesCediss = SelectAllChekboxesCediss;

        function SelectAllChekboxesCediss(selectAll) {
            if (selectAll == undefined || selectAll == false) {
                angular.forEach(ctrl.cediss, function (item) {
                    item.Checked = true;
                });
            }

            else {
                angular.forEach(ctrl.cediss, function (item) {
                    item.Checked = false;
                });
            }
        }

        //routes functions
        ctrl.routes = GetRoutes();
        ctrl.GetRoutes = GetRoutes;

        function GetRoutes(selectedItem) {
            if (selectedItem == undefined)
                selectedItem = "";
            if (selectedItem != undefined) {
                $http({
                    url: url + '/api/GetRoutes?Cedis=' + selectedItem.replace(/\+/g, "%2B"),
                    method: 'GET',
                    headers: {
                        Authorization: window.sessionStorage.getItem('Token'),
                        'Content-Type': 'application/json'
                    },
                }).then(function successCallBack(response) {
                    ctrl.routes = response.data;
                }, function errorCallBack(response) {

                });
            }
        }

        ctrl.getAllRoutes = GetRoutess;
        ctrl.ListCedis = ctrl.ListCedis;

        function GetRoutess(Cedis, Varios) {
            var Centro = "";
            angular.forEach(ctrl.cediss, function (item) {
                if (item.Checked == true) {
                    Centro = Centro + "'" + item.value + "',";
                }
            });
            Centro = Centro.substr(0, Centro.length - 1);
            $http({
                url: url + '/api/GetRoutes?Cedis=' + Centro + '&Varios=' + true,
                method: 'GET',
                headers: {
                    Authorization: window.sessionStorage.getItem('Token'),
                    'Content-Type': 'application/json'
                },
            }).then(function successCallBack(response) {
                ctrl.routes = response.data;
            }, function errorCallBack(response) {

            });
        }

        ctrl.encuestas = GetEncuestas();
        ctrl.GetEncuestas = GetEncuestas;

        function GetEncuestas() {
            $http({
                url: url + '/api/GetEncuestas',
                method: 'GET',
                headers: {
                    Authorization: window.sessionStorage.getItem('Token'),
                    'Content-Type': 'application/json'
                },
            }).then(function successCallBack(response) {
                ctrl.encuestas = response.data;
            }, function errorCallBack(response) {

            });
        }

        ctrl.SelectAllChekboxesRoutes = SelectAllChekboxesRoutes;

        function SelectAllChekboxesRoutes(selectAll) {
            if (selectAll == undefined || selectAll == false) {
                angular.forEach(ctrl.routes, function (item) {
                    item.Checked = true;
                });
            }

            else {
                angular.forEach(ctrl.routes, function (item) {
                    item.Checked = false;
                });
            }
        }

        ctrl.SubmitForm = SubmitForm;
        ctrl.date1 = undefined;
        ctrl.date2 = undefined;
        ctrl.pvEsFecha = false;
        ctrl.VAVClave = undefined;
        ctrl.ReportType = false;
        ctrl.CENClave = undefined;

        ctrl.startbar = function () {
            cfpLoadingBar.start();
        };

        ctrl.completebar = function () {
            cfpLoadingBar.complete();
        };

        //envia el formulario completo
        function SubmitForm(Cedis, dateStatus, Routes, CENClave, pvEsFecha, campoFecha) {
            var countRoutes = 0;
            angular.forEach(ctrl.routes, function (item) {

                if (item.Checked === true) {
                    countRoutes++;
                }
            });
            var countCedis = 0;
            angular.forEach(ctrl.cediss, function (item) {

                if (item.Checked === true) {
                    countCedis++;
                }
            });
            if (CENClave == undefined) {
                alert("Seleccione una Encuesta");
                cfpLoadingBar.complete();
            }
            else if (countCedis <= 0) {
                alert("Seleccione centro de distribución");
                cfpLoadingBar.complete();
            }
            else if (countRoutes <= 0) {
                alert("Seleccione ruta");
                cfpLoadingBar.complete();
            }
            else if (ctrl.State == undefined) {
                alert("Seleccione rango de fechas");
                cfpLoadingBar.complete();
            }
            else if (ctrl.State == 'Entre' && (ctrl.date1 == undefined || ctrl.date2 == undefined)) {
                alert("Seleccion rango de fechas");
                cfpLoadingBar.complete();
            }
            else if (ctrl.State == 'Entre' && (ctrl.date2 < ctrl.date1)) {
                alert("Rango de fechas erroneo");
                cfpLoadingBar.complete();
            }
            else if (ctrl.date1 == undefined) {
                alert("Seleccion fecha");
                cfpLoadingBar.complete();
            }
            else {
                ctrl.nombreReport = $filter("filter")(ctrl.GetList, { VAVClave: ctrl.VAVClave })[0].Descripcion;
                var data = {
                    nombreReport: ctrl.nombreReport,
                    Cedis: '',
                    nombreCedis: '',
                    dateStatus: ctrl.State,
                    Routes: Routes,
                    Products: ctrl.products,
                    init: ctrl.date1,
                    end: ctrl.date2,
                    vavclave: ctrl.VAVClave,
                    reportType: ctrl.ReportType,
                    unidadMedida: ctrl.UnidadMedida,
                    CENClave: ctrl.CENClave
                }

                $http.post(url + '/Reports/GetCondition', data, { ignoreLoadingBar: true })
                    .success(function (data, status, headers, config) {
                        window.open(url + "/Reports/Ver?VAVClave=" + data.VAVClave + "&Cedis=" + data.Cedis.replace(/\+/g, "%2B") + "&nombreReport=" + data.nombreReport + "&nombreCedis=" + data.nombreCedis + "&FechaInicial=" + data.FechaInicial + "&FechaFinal=" + data.FechaFinal + "&dateStatus=" + data.Rango + "&Rutas=" + data.Rutas + "&Clientes=" + data.Clientes + "&Vendedor=" + data.Vendedor + "&Productos=" + data.Productos + "&nombreProductos=" + data.NombreProductos + "&detallado=" + data.reportType + "&unidadMedida=" + data.unidadMedida + "&CENClave=" + data.CENClave, "_blank");
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