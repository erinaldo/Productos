(function () {
    angular
        .module('eRouteApp')
        .controller('puntosPorClienteController', puntosPorClienteController)
    puntosPorClienteController.$inject = ['$scope', '$http', '$mdToast', '$q', '$timeout', 'NgMap', 'cfpLoadingBar', '$filter', "menuServices", "reportServices"];

    function puntosPorClienteController($scope, $http, $mdToast, $q, $timeout, NgMap, cfpLoadingBar, $filter, menuServices, reportServices) {

        var ctrl = this;
        var url = window.sessionStorage.getItem('URL');

        ctrl.showList = false;
        ctrl.showSelect = undefined;
        ctrl.nShowLists = nShowLists;
        ctrl.selectedItem = ctrl.selectedItem;

        function nShowLists(state) {
            if (state == undefined) {
                ctrl.showList = undefined;
            }
            else {
                ctrl.showList = 'true';
            }
        }


        //Cedis config
        var load = [GetCedis()]
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

        function GetCedis() {
            $http({
                url: url + '/api/GetCedis',
                method: 'GET',
                headers: {
                    Authorization: window.sessionStorage.getItem('Token'),
                    'Content-Type': 'application/json'
                },
                params: { USUId: window.sessionStorage.getItem('USUId') }
            }).then(function successCallBack(response) {
                //self.states = loadAll(response.data);
                self.states = response.data;
            }, function errorCallBack(response) {

            });
        }

        ctrl.State = undefined;
        ctrl.date1 = undefined;
        ctrl.date2 = undefined;
        ctrl.VAVClave = undefined;
        ctrl.ReportType = false;
        ctrl.SubmitForm = SubmitForm;

        ctrl.startbar = function () {
            cfpLoadingBar.start();
        };

        ctrl.completebar = function () {
            cfpLoadingBar.complete();
        };

        //envia el formulario completo
        function SubmitForm(Cedis, Clientes) {            
            if (ctrl.selectedItem == undefined || ctrl.selectedItem == null) {
                ctrl.selectedItem = {};
            }
            else {
                var data = {
                    VAVClave: ctrl.VAVClave,
                    Cedis: ctrl.selectedItem.value,
                    nombreCedis: ctrl.selectedItem.display,
                    Clientes: Clientes,
                    reportType: ctrl.ReportType,
                    
                }
                
                $http.post(url + '/Reports/GetCondition', data, { ignoreLoadingBar: true })
                .success(function (data, status, headers, config) {
                    //console.log(data);
                    //window.location = url + "/Reports/Ver?VAVClave=" + data.VAVClave + "&Cedis=" + data.Cedis + "&FechaInicial=" + data.FechaInicial + "&FechaFinal=" + data.FechaFinal + "&dateStatus=" + data.Rango + "&Rutas=" + data.Rutas + "&Clientes=" + data.Clientes + "&Vendedor=" + data.Vendedor;
                    window.open(url + "/Reports/Ver?VAVClave=" + data.VAVClave, "_blank");

                    cfpLoadingBar.complete();
                })
                .error(function (error, status, headers, config) {
                    console.log(error);
                });
            }
        }

        ctrl.SelectAllChekboxesClients = SelectAllCheckboxesClients;
        function SelectAllCheckboxesClients(selectAll) {
            if (selectAll == undefined || selectAll == false) {
                angular.forEach(ctrl.ListClients, function (item) {
                    item.Checked = true;
                });
            }

            else {
                angular.forEach(ctrl.ListClients, function (item) {
                    item.Checked = false;
                });
            }
        }

        ctrl.ClearClientCheckBoxes = ClearClientCheckBoxes;
        function ClearClientCheckBoxes() {
            $scope.fil = [];

            angular.forEach(ctrl.ListClients, function (item) {
                if (item.Checked == true) {
                    $scope.fil.push(item.Checked);
                }
            });

            if ($scope.fil.length > 0) {
                angular.forEach(ctrl.ListClients, function (item) {
                    item.Checked = false;
                    item.Disabled = true;

                });
                $scope.selectAllClients = true;
                $scope.selectAll = false;
            }
            else if ($scope.fil.length == 0) {
                angular.forEach(ctrl.ListClients, function (item) {
                    item.Checked = false;
                    item.Disabled = false;

                });
                $scope.selectAllClients = false;
                $scope.selectAll = false;
            }
        }
        
        //llenar seccion clientes

        ctrl.ListClients = GetClients();
        ctrl.GetClients = GetClients;

        function GetClients(selectedItem) {
            if (selectedItem == undefined)
                selectedItem = "";
            $http({
                //' + window.sessionStorage.getItem('USUId').replace(/\+/g, "%2B"),                
                url: url + '/api/GetClients?Id=Todos&Routes=' + "" + '&Cedis=' + selectedItem.replace(/\+/g, "%2B"),
                method: 'GET',
                headers: {
                    Authorization: window.sessionStorage.getItem('Token'),
                    'Content-Type': 'application/json'
                },
            }).then(function successCallBack(response) {
                ctrl.ListClients = response.data;
            }, function errorCallBack(response) {


            });
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