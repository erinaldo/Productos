(function () {
    angular
        .module('eRouteApp')
        .controller('ventasParaInterfazController', ventasParaInterfazController)
    ventasParaInterfazController.$inject = ['$scope', '$http', '$mdToast', '$q', '$timeout', 'NgMap', 'cfpLoadingBar', '$filter', "menuServices", "reportServices", "valorReferencia"];

    function ventasParaInterfazController($scope, $http, $mdToast, $q, $timeout, NgMap, cfpLoadingBar, $filter, menuServices, reportServices, valorReferencia) {

        var ctrl = this;
        var url = window.sessionStorage.getItem('URL');

        ctrl.showList = false;
        ctrl.showSelect = undefined;
        ctrl.nShowLists = nShowLists;
        ctrl.selectedItem = ctrl.selectedItem;
        ctrl.OnSelectChange = OnSelectChange;
        ctrl.minDate = new Date();

        ctrl.RUTClave = "";
        ctrl.VendedorId = "";
        ctrl.Lock = false;
        ctrl.Todos = false;

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

        $scope.EstablecerReporte = function (VAVClave) {
            valorReferencia.obtenerValorClave('REPORTEW', VAVClave, function (result) {
                ctrl.titulo = result[0].Descripcion;
            });

            GetCedis();
        }

        ////Cedis config
        //var load = [GetCedis()]
        ////var load = [GetActivityList()]

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

        //seller functions
        ctrl.sellers = GetSellers();
        function GetSellers(selectedItem) {
            if (selectedItem == undefined)
                selectedItem = "";
            $http({
                url: url + '/api/GetSeller?Cedis=' + selectedItem.replace(/\+/g, "%2B"),
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

        //Obtener Clientes por Ruta
        ctrl.clients = GetClientsR();
        ctrl.GetClientsR = GetClientsR;
        function GetClientsR(Route) {
            Route = "'" + Route + "'";
            $http({
                url: url + '/api/GetClients?Id=Todos&Routes=' + Route + '&Cedis=' + "",
                method: 'GET',
                headers: {
                    Authorization: window.sessionStorage.getItem('Token'),
                    'Content-Type': 'application/json'
                },
            }).then(function successCallBack(response) {
                ctrl.clients = response.data;
            }, function errorCallBack(response) {

            });
        }

            //Obtener Clientes por Vendedor
            ctrl.GetClientsS = GetClientsS;
            function GetClientsS(Seller) {
                Route = "'" + Seller + "'";
                $http({
                    url: url + '/api/GetClients?Sellers=' + Seller + '&Cedis=' + "",
                    method: 'GET',
                    headers: {
                        Authorization: window.sessionStorage.getItem('Token'),
                        'Content-Type': 'application/json'
                    },
                }).then(function successCallBack(response) {
                    ctrl.clients = response.data;
                }, function errorCallBack(response) {

                });
        }

        ctrl.SubmitForm = SubmitForm;
        ctrl.date1 = undefined;
        ctrl.date2 = undefined;
        ctrl.VAVClave = undefined;
        ctrl.ReportType = false;

        ctrl.startbar = function () {
            cfpLoadingBar.start();
        };

        ctrl.completebar = function () {
            cfpLoadingBar.complete();
        };

        //envia el formulario completo
        function SubmitForm(Cedis, dateStatus, Routes, Clientes, pvEsFecha, campoFecha, Sellers) {
            var countRoutes = 0;

            //verifica la cantidad de checkbox marcados
            var countclientes = 0;
            angular.forEach(ctrl.clients, function (item) {
                if (item.Checked == true)
                    countclientes++;
            });
            if (countclientes == ctrl.clients.length)
                ctrl.Todos = true;

            angular.forEach(ctrl.routes, function (item) {

                if (item.Checked == true) {
                    countRoutes++;
                }
            });

            var countSellers=0;
            angular.forEach(ctrl.sellers, function (item) {

                if (item.Checked == true) {
                    countSellers++;
                }
            });

            if (ctrl.selectedItem == undefined || ctrl.selectedItem == null) {
                ctrl.selectedItem = {};
            }

            if (ctrl.State != "Entre")
                ctrl.date2 = ctrl.date1;

            if (ctrl.State == undefined) {
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
                var data = {
                    nombreReport: ctrl.titulo,
                    Cedis: ctrl.selectedItem.value,
                    nombreCedis: ctrl.selectedItem.display,
                    dateStatus: ctrl.State,
                    Routes: Routes,
                    Seller: ctrl.sellers,
                    init: ctrl.date1,
                    end: ctrl.date2,
                    vavclave: ctrl.VAVClave,
                    reportType: ctrl.ReportType
                }

                $http.post(url + '/Reports/GetCondition', data, { ignoreLoadingBar: true })
                    .success(function (data, status, headers, config) {
                        window.open(url + "/Reports/Ver?VAVClave=" + data.VAVClave + "&Cedis=" + data.Cedis.replace(/\+/g, "%2B") + "&nombreReport=" + data.nombreReport + "&nombreCedis=" + data.nombreCedis + "&FechaInicial=" + data.FechaInicial + "&FechaFinal=" + data.FechaFinal + "&dateStatus=" + data.Rango + "&Rutas=" + ctrl.RUTClave + "&Vendedor=" + data.Vendedor + "&detallado=" + data.reportType + "&unidadMedida=" + data.unidadMedida, "_blank");
                        cfpLoadingBar.complete();
                    })
                    .error(function (error, status, headers, config) {
                        //console.log(error);
                    });
            }
        }

        ctrl.SelectAllCheckboxesClients = SelectAllCheckboxesClients;

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

        function SelectAllChekboxesAllRoutes(selectAll) {
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

        function SelectAllChekboxesSeller(selectAll) {
            if (selectAll == undefined || selectAll == false) {
                angular.forEach(ctrl.sellers, function (item) {
                    item.Checked = true;
                });
            }

            else {
                angular.forEach(ctrl.sellers, function (item) {
                    item.Checked = false;
                });
            }
        }

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

        //bloquea  el listado de rutas cuando se selecciona un vendedor
        ctrl.ClearRouteCheckBoxes = ClearAllRouteCheckBoxes;
        ctrl.ClearClientCheckBoxes = ClearClientCheckBoxes;

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

        //bloquea  el listado de vendedores cuando se selecciona una ruta
        ctrl.ClearSellersCheckBoxes = ClearAllSellersCheckBoxes;
        function ClearAllSellersCheckBoxes() {
            $scope.fillSellers = [];

            angular.forEach(ctrl.routes, function (item) {
                if (item.Checked == true) {
                    $scope.fillSellers.push(item.Checked);
                }
            });

            if ($scope.fillSellers.length > 0) {
                angular.forEach(ctrl.sellers, function (item) {
                    item.Checked = false;
                    item.Disabled = true;

                });
                $scope.SellerSelectallCheckBox = true;
                $scope.selectAllSeller = false;
            }
            else if ($scope.fillSellers.length == 0) {
                angular.forEach(ctrl.sellers, function (item) {
                    item.Checked = false;
                    item.Disabled = false;

                });
                $scope.SellerSelectallCheckBox = false;
                $scope.selectAllSeller = false;
            }
        }

        //clients tree function
        //GetSchemeClients();
        ctrl.call = GetSchemeClients;

        function GetSchemeClients() {
            $http({
                url: url + '/api/GetClientScheme',
                method: 'GET',
                headers: {
                    Authorization: window.sessionStorage.getItem('Token'),
                    'Content-Type': 'application/json'
                },
            }).then(function successCallBack(response) {
                $scope.treedata = JSON.parse(response.data);
            }, function errorCallBack(response) {

            });
        }

        //llenar seccion clientes
        ctrl.getAllClientes = GetClients;
        ctrl.ListClients = ctrl.ListClients;

        function GetClients(Routes) {
            $http.post(url + '/Reports/GetRoutesStiring', {
                Routes: Routes
            }).success(function (data, status, headers, config) {
                $http({
                    url: url + '/api/GetClients?Id=' + $scope.abc.currentNode.id + "&Routes=" + data + '&Cedis=' + "",
                    method: 'GET',
                    headers: {
                        Authorization: window.sessionStorage.getItem('Token'),
                        'Content-Type': 'application/json'
                    },
                }).then(function successCallBack(response) {
                    ctrl.ListClients = response.data;
                }, function errorCallBack(response) {

                });
            }).error(function (error, status, headers, config) {

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