(function () {
    angular
        .module('eRouteApp')
        .controller('cumplimientoVisitaGHRController', cumplimientoVisitaGHRController)
    cumplimientoVisitaGHRController.$inject = ['$scope', '$http', '$mdToast', '$q', '$timeout', 'NgMap', 'cfpLoadingBar', '$filter', "menuServices", "reportServices", "valorReferencia"];

    function cumplimientoVisitaGHRController($scope, $http, $mdToast, $q, $timeout, NgMap, cfpLoadingBar, $filter, menuServices, reportServices, valorReferencia) {

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


        //Cedis config
        //var load = [GetCedis()]

        //$q.all(load).then(function () {
        //})

        var self = this;
        self.simulateQuery = false;
        self.isDisabled = false;
        self.querySearch = querySearch;
        self.selectedItemChange = selectedItemChange;
        self.searchTextChange = searchTextChange;

        //load maps on sidebar menu

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

        $scope.EstablecerReporte = function (VAVClave) {
            //ctrl.VAVClave = VAVClave;

            if (VAVClave == 202)
                ctrl.titulo = 'Cumplimiento de Visita General';
            else if (VAVClave == 203)
                ctrl.titulo = 'Cumplimiento de Visita por Ruta';
            else if (VAVClave == 204)
                ctrl.titulo = 'Cumplimiento de Visita por Cliente';

            //valorReferencia.obtenerValorClave('REPORTEW', VAVClave, function (result) {
            //    ctrl.titulo = result[0].Descripcion;
            //});

            GetCedis();
            //valorReferencia.obtenerValorClave('REPORTEW', VAVClave, function (result) {
            //    ctrl.titulo = result.Descripcion;
            //});
        }

        function GetCedis() {
            

            $http({                
                url: url + '/api/GetCedis?USUId=' + window.sessionStorage.getItem('USUId').replace(/\+/g, "%2B"),
                method: 'GET',
                headers: {
                    Authorization: window.sessionStorage.getItem('Token'),
                    'Content-Type': 'application/json'
                },
            }).then(function successCallBack(response) {
                //  self.states = loadAll(response.data);
                self.states = response.data;
            }, function errorCallBack(response) {

            });
        }

        //routes functions
        ctrl.routes = GetRoutes();
        ctrl.GetRoutes = GetRoutes;

        function GetRoutes(selectedItem) {
            if (selectedItem == undefined)
                selectedItem = "";
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
                ctrl.State = '7';
                ctrl.dateState = response.data;
            }, function errorCallBack(response) {

            });
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
        function SubmitForm(Cedis, dateStatus, Routes, pvEsFecha, campoFecha) {
            //console.log(ctrl.State);

            var countRoutes = 1;
            if (ctrl.VAVClave == 203) {
                countRoutes = 0;
                angular.forEach(ctrl.routes, function (item) {
                    countRoutes++;
                });
            }
            
            if (countRoutes <= 0) {
                alert("Seleccione una Ruta");
                cfpLoadingBar.complete();
            }
            else if (ctrl.date1 == undefined || ctrl.date2 == undefined) {
                alert("Seleccione un rango de fechas");
                cfpLoadingBar.complete();
            }
            else if (ctrl.date1 > ctrl.date2)
            {
                alert("La fecha inicial debe ser menor o igual a la fecha final");
                cfpLoadingBar.complete();
            }
            else {
                var data;
                if (ctrl.VAVClave == 202) {
                    data = {
                        dateStatus: ctrl.State,
                        init: ctrl.date1,
                        end: ctrl.date2,
                        vavclave: ctrl.VAVClave,
                        reportType: ctrl.ReportType,
                    }
                }
                else {
                    data = {
                        Cedis: ctrl.selectedItem.value,
                        nombreCedis: ctrl.selectedItem.display,
                        dateStatus: ctrl.State,
                        Routes: Routes,
                        init: ctrl.date1,
                        end: ctrl.date2,
                        vavclave: ctrl.VAVClave,
                        reportType: ctrl.ReportType,
                    }
                }                   

                $http.post(url + '/Reports/GetCondition', data, { ignoreLoadingBar: true })
                .success(function (data, status, headers, config) {
                    if (data.Cedis == undefined)
                        data.Cedis = "";
                    window.open(url + "/Reports/Ver?VAVClave=" + data.VAVClave + "&Cedis=" + data.Cedis.replace(/\+/g, "%2B") + "&nombreReport=" + data.nombreReport + "&nombreCedis=" + data.nombreCedis + "&FechaInicial=" + data.FechaInicial + "&FechaFinal=" + data.FechaFinal + "&dateStatus=" + data.Rango + "&Rutas=" + data.Rutas + "&Clientes=" + data.Clientes + "&Vendedor=" + data.Vendedor + "&detallado=" + data.reportType + "&unidadMedida=" + data.unidadMedida, "_blank");
                    cfpLoadingBar.complete();
                })
                .error(function (error, status, headers, config) {
                });
            }
        }

        ctrl.SelectAllCheckBoxesRoutes = SelectAllCheckBoxesRoutes;
        //ctrl.SelectAllChekboxesClients = SelectAllCheckboxesClients;

        function SelectAllCheckBoxesRoutes(selectAll) {
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

        function SelectAllCheckBoxesAllRoutes(selectAll) {
            if (selectAll == undefined || selectAll == false) {
                angular.forEach(ctrl.GetAllRoutes, function (item) {
                    item.Checked = true;
                });
            }

            else {
                angular.forEach(ctrl.GetAllRoutes, function (item) {
                    item.Checked = false;
                });
            }
        }
       
        //bloquea  el listado de rutas cuando se selecciona un vendedor
        ctrl.ClearRouteCheckBoxes = ClearAllRouteCheckBoxes;
        //ctrl.ClearClientCheckBoxes = ClearClientCheckBoxes;

        function ClearAllRouteCheckBoxes() {
            $scope.fil = [];

            angular.forEach(ctrl.sellers, function (item) {
                if (item.Checked == true) {
                    $scope.fil.push(item.Checked);
                }
            });

            if ($scope.fil.length > 0) {
                angular.forEach(ctrl.routes, function (item) {
                    item.Checked = false;
                    item.Disabled = true;

                });
                $scope.RoutesSelectallCheckBox = true;
                $scope.selectAll = false;
            }
            else if ($scope.fil.length == 0) {
                angular.forEach(ctrl.routes, function (item) {
                    item.Checked = false;
                    item.Disabled = false;

                });
                $scope.RoutesSelectallCheckBox = false;
                $scope.selectAll = false;
            }
        }


        //function ClearClientCheckBoxes() {
        //    $scope.fil = [];

        //    angular.forEach(ctrl.ListClients, function (item) {
        //        if (item.Checked == true) {
        //            $scope.fil.push(item.Checked);
        //        }
        //    });

        //    if ($scope.fil.length > 0) {
        //        angular.forEach(ctrl.ListClients, function (item) {
        //            item.Checked = false;
        //            item.Disabled = true;

        //        });
        //        $scope.selectAllClients = true;
        //        $scope.selectAll = false;
        //    }
        //    else if ($scope.fil.length == 0) {
        //        angular.forEach(ctrl.ListClients, function (item) {
        //            item.Checked = false;
        //            item.Disabled = false;

        //        });
        //        $scope.selectAllClients = false;
        //        $scope.selectAll = false;
        //    }
        //}        

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