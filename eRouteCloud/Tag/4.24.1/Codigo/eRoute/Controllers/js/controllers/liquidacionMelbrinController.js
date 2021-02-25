(function () {
    angular
        .module('eRouteApp')
        .controller('liquidacionMelbrinController', liquidacionMelbrinController)
    liquidacionMelbrinController.$inject = ['$scope', '$http', '$mdToast', '$q', '$timeout', 'NgMap', 'cfpLoadingBar', '$filter', "menuServices", "reportServices", "valorReferencia"];

    function liquidacionMelbrinController($scope, $http, $mdToast, $q, $timeout, NgMap, cfpLoadingBar, $filter, menuServices, reportServices, valorReferencia) {

        var ctrl = this;
        var url = window.sessionStorage.getItem('URL');

        ctrl.showList = false;
        ctrl.showSelect = undefined;
        ctrl.nShowLists = nShowLists;
        ctrl.selectedItem = ctrl.selectedItem;
        ctrl.OnSelectChange = OnSelectChange;
        ctrl.minDate = new Date();

        //muestra el segundo datepicker cuando el estado de la fecha es 'Entre'
        function OnSelectChange(state) {
            if (state == 'Entre') {
                //ctrl.showSelect = 'true';
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
        var load = [GetSellers()]
        //var load = [GetActivityList()]

        $q.all(load).then(function () {
        })

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


        function GetSellers() {
            $http({
                url: url + '/api/GetSeller?Cedis=' + "",
                method: 'GET',
                headers: {
                    Authorization: window.sessionStorage.getItem('Token'),
                    'Content-Type': 'application/json'
                },
            }).then(function successCallBack(response) {
                ctrl.sellers = response.data;
            }, function errorCallBack(response) {


            });
        }
        //dates state functions
        ctrl.State = undefined;
        ctrl.dateState = GetDates();


        function GetDates() {
            valorReferencia.obtenerValorClave('BFNUMERI', '1', function (result) {
                ctrl.State = 1;
                ctrl.dateState = result;

            });
        }


        ctrl.SubmitForm = SubmitForm;
        ctrl.Fecha = undefined;
        ctrl.VAVClave = undefined;
        ctrl.ReportType = false;

        ctrl.startbar = function () {
            cfpLoadingBar.start();
        };

        ctrl.completebar = function () {
            cfpLoadingBar.complete();
        };

        //envia el formulario completo
        function SubmitForm(VendedorId) {
            //console.log(ctrl.State);
            var countSellers;

            countSellers = 0;
            angular.forEach(ctrl.sellers, function (item) {
                if (item.VendedorId == VendedorId) {
                    item.Checked = true;
                    countSellers++;
                }
                else {
                    item.Checked = false;
                }
            });

            if (countSellers <= 0) {
                alert("Seleccione un Vendedor");
                cfpLoadingBar.complete();
            }
            else if (ctrl.date1 == undefined) {
                alert("Seleccione fecha");
                cfpLoadingBar.complete();
            }
            else {
                var data = {
                    dateStatus: ctrl.State,
                    Seller: ctrl.sellers,
                    init: ctrl.date1,
                    vavclave: ctrl.VAVClave,
                    reportType: ctrl.ReportType
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

        ctrl.SelectAllCheckboxesClients = SelectAllCheckboxesClients;
        function SelectAllCheckboxesClients(selectAll) {
            if (selectAll == undefined || selectAll == false) {
                angular.forEach(ctrl.clients, function (item) {
                    item.Checked = true;
                });
            }

            else {
                angular.forEach(ctrl.clients, function (item) {
                    item.Checked = false;
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