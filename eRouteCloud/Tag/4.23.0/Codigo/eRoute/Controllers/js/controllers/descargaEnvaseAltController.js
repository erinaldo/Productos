(function () {
    angular
        .module('eRouteApp')
        .controller('descargaEnvaseAltController', descargaEnvaseAltController)
    descargaEnvaseAltController.$inject = ['$scope', '$http', '$mdToast', '$q', '$timeout', 'NgMap', 'cfpLoadingBar', '$filter', "menuServices", "reportServices", "valorReferencia"];

    function descargaEnvaseAltController($scope, $http, $mdToast, $q, $timeout, NgMap, cfpLoadingBar, $filter, menuServices, reportServices, valorReferencia) {

        var ctrl = this;
        var url = window.sessionStorage.getItem('URL');

        ctrl.showSelect = undefined;
        ctrl.selectedItem = ctrl.selectedItem;
        ctrl.OnSelectChange = OnSelectChange;
        ctrl.minDate = new Date();
        ctrl.GetList;

        ctrl.tipoPromociones = [{ "Name": "Promociones Activas", "Checked": true, "Value": "Activas" }, { "Name": "Promociones Inactivas", "Checked": false, "Value": "Inactivas" }];
        ctrl.stringPromociones = "";



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
            //if (state == 'Entre') {
            //    ctrl.showSelect = 'true';
            //}
            //else {
            //    ctrl.showSelect = undefined;
            //}
            ctrl.showSelect = state == 'Entre';
        }


        var self = this;
        self.simulateQuery = false;
        self.isDisabled = false;
        self.querySearch = querySearch;
        self.selectedItemChange = selectedItemChange;
        self.searchTextChange = searchTextChange;

        $scope.EstablecerReporte = function (VAVClave) {
            valorReferencia.obtenerValorClave('REPORTEW', VAVClave, function (result) {
                ctrl.titulo = result[0].Descripcion;
            });
        }


        function querySearch(query) {

            var results = query ? self.states.filter(createFilterFor(query)) : self.states,
                deferred;

            if (self.simulateQuery) {
                deferred = $q.defer();
                $timeout(function () { deferred.resolve(results); }, Math.random() * 1000, false);
                return deferred.promise;
            } else {
                return results;
            }
        }

        function createFilterFor(query) {
            var lowercaseQuery = angular.lowercase(query);
            return function filterFn(state) {
                return (state.value.indexOf(lowercaseQuery) === 0);
            };
        }

        function searchTextChange(text) {
            //console.log('Text changed to ' + text);
        }

        function selectedItemChange(item) {
            $log.info('Item changed to ' + JSON.stringify(item));
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


        //routes functions
        ctrl.routes = GetRoutes();
        ctrl.GetRoutes = GetRoutes;

        function GetRoutes(selectedItem) {
            $http({
                url: url + '/api/GetRoutes?Cedis=',
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

        //rutas autocomplete
        ctrl.filtraBusqueda = filtraBusqueda;
        function filtraBusqueda(busqueda, lista) {// realiza buscado en listado de estados
            var ret = ""
            if (!_.isNil(busqueda)) {
                ret = _.filter(lista, function (d) {
                    return (d.Descripcion).toLowerCase().indexOf(busqueda.toLowerCase()) !== -1 || busqueda == "";
                });
            }
            return ret;
        }

        ctrl.SubmitForm = SubmitForm;
        ctrl.date1 = undefined;
        ctrl.date2 = undefined;
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
        function SubmitForm(Cedis, dateStatus, Routes, Clientes, pvEsFecha, campoFecha) {
            if (ctrl.selectedItem == undefined || ctrl.selectedItem == null) {
                ctrl.selectedItem = {};
            }

            if (_.isNil(ctrl.ruta)) {
                alert("Seleccione una ruta");
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
            else if (ctrl.date1 == undefined) {
                alert("Seleccion fecha");
                cfpLoadingBar.complete();
            }
            else {
                ctrl.nombreReport = $filter("filter")(ctrl.GetList, { VAVClave: ctrl.VAVClave })[0].Descripcion;
                ctrl.ruta.Checked = true;
                _.forEach(ctrl.routes, function (singleRoute) {
                    if (singleRoute != ctrl.ruta) {
                        singleRoute.Checked = false;
                    }
                });
                if (ctrl.tipoPromociones[0].Checked) {
                    ctrl.stringPromociones = ctrl.tipoPromociones[0].Value;
                    if (ctrl.tipoPromociones[1].Checked) {
                        ctrl.stringPromociones += ", " + ctrl.tipoPromociones[1].Value;
                    }
                } else if (ctrl.tipoPromociones[1].Checked) {
                    ctrl.stringPromociones = ctrl.tipoPromociones[1].Value;
                }
                var data = {
                    nombreReport: ctrl.titulo,
                    Cedis: ctrl.selectedItem.value,
                    nombreCedis: ctrl.selectedItem.display,
                    dateStatus: ctrl.State,
                    Routes: ctrl.routes,
                    init: ctrl.date1,
                    end: ctrl.date2,
                    vavclave: ctrl.VAVClave,
                    reportType: ctrl.ReportType,
                    promocion: ctrl.stringPromociones
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