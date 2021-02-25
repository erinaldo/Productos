(function () {
    angular
        .module('eRouteApp')
        .controller('ctrReporte', ctrReporte)
    ctrReporte.$inject = ['$scope', '$http', '$mdToast', '$q', '$timeout', 'NgMap', 'cfpLoadingBar', '$filter', "menuServices", "reportServices", "valorReferencia"];

    function ctrReporte($scope, $http, $mdToast, $q, $timeout, NgMap, cfpLoadingBar, $filter, menuServices, reportServices, valorReferencia) {

        var ctrl = this;
        var url = window.sessionStorage.getItem('URL');

        ctrl.url = undefined;
        ctrl.showList = false;
        ctrl.showSelect = undefined;
        ctrl.nShowLists = nShowLists;
        ctrl.selectedItem = ctrl.selectedItem;
        ctrl.OnSelectChange = OnSelectChange;
        ctrl.GetList = GetList();

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

        function GetList() {

            $http({
                url: url + '/api/FilterReports',
                method: 'GET',
                headers: {
                    Authorization: window.sessionStorage.getItem('Token'),
                    'Content-Type': 'application/json'
                },
                params: { PERClave : window.sessionStorage.getItem('PERClave'), USUId: window.sessionStorage.getItem('USUId') }
            }).success(function (data, status) {
                ctrl.GetList = data;
            }).error(function (error, status) {
                if (status == 401) {
                    window.sessionStorage.clear();
                    window.location = url + '/Login';
                }
            });
        }

        $scope.EstablecerReporte = function (VAVClave) {
            ctrl.VAVClave = VAVClave;
            valorReferencia.obtenerValorClave('MAPAW', VAVClave, function (result) {
                ctrl.titulo = result[0].Descripcion;
            });

            GetCedis();
        }

        //Cedis config
        //var load = [GetCedis()]
        //var load = [GetActivityList()]

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
        ctrl.GetAllRoutes = GetAllRoutes();

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

        function GetAllRoutes() {
            $http({
                url: url + '/api/GetAllRoutes',
                method: 'GET',
                headers: {
                    Authorization: window.sessionStorage.getItem('Token'),
                    'Content-Type': 'application/json'
                },
            }).then(function successCallBack(response) {
                ctrl.GetAllRoutes = response.data;
            }, function errorCallBack(response) {

            });
        }

        //seller functions
        ctrl.group = 'Seller';
        ctrl.GetSellers = GetSellers;

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

        ctrl.SubmitForm = SubmitForm;
        ctrl.date1 = undefined;
        ctrl.date2 = undefined;
        ctrl.pvEsFecha = false;
        ctrl.VAVClave = undefined;
        ctrl.ReportType = false;
        ctrl.UnidadMedida = "Cartones";

        ctrl.startbar = function () {
            cfpLoadingBar.start();
        };

        ctrl.completebar = function () {
            cfpLoadingBar.complete();
        };

        //envia el formulario completo
        function SubmitForm(Cedis, dateStatus, Routes, Clientes, pvEsFecha, campoFecha) {
            //console.log(ctrl.State);
            var countRoutes;
            angular.forEach(ctrl.routes, function (item) {

                if (item.Checked == true) {
                    countRoutes++;
                }
            });

            var countSellers;
            angular.forEach(ctrl.sellers, function (item) {

                if (item.Checked == true) {
                    countSellers++;
                }
            });

            if (ctrl.selectedItem == undefined || ctrl.selectedItem == null) {
                ctrl.selectedItem = {};
            }

            if (countRoutes <= 0 || countSellers <= 0) {
                alert("Seleccione ruta o vendedor");
                cfpLoadingBar.complete();
            }
            else if (ctrl.State == undefined) {
                alert("Seleccione rango de fechas");
                cfpLoadingBar.complete();
            }
            else if (ctrl.State == 'Entre' && (ctrl.date1 == undefined || ctrl.date2 == undefined)) {
                //console.log("1");
                //if (ctrl.date1 == undefined || ctrl.date2 == undefined) {
                alert("Seleccion rango de fechas");
                cfpLoadingBar.complete();
                //}
            }
            else if (ctrl.date1 == undefined) {
                alert("Seleccion fecha");
                cfpLoadingBar.complete();
            }
            else {
                ctrl.nombreReport = $filter("filter")(ctrl.GetList, { VAVClave: ctrl.VAVClave })[0].Descripcion;
                var data = {
                    nombreReport: ctrl.nombreReport,
                    Cedis: ctrl.selectedItem.value,
                    nombreCedis: ctrl.selectedItem.display,
                    dateStatus: ctrl.State,
                    Routes: Routes,
                    Clientes: Clientes,
                    Seller: ctrl.sellers,
                    init: ctrl.date1,
                    end: ctrl.date2,
                    pvEsFecha: pvEsFecha,
                    campoFecha: campoFecha,
                    vavclave: ctrl.VAVClave,
                    reportType: ctrl.ReportType,
                    unidadMedida: ctrl.UnidadMedida
                }

                $http.post(url + '/Reports/GetCondition', data, { ignoreLoadingBar: true })
                .success(function (data, status, headers, config) {
                    //console.log(data);
                    //window.location = url + "/Reports/Ver?VAVClave=" + data.VAVClave + "&Cedis=" + data.Cedis + "&FechaInicial=" + data.FechaInicial + "&FechaFinal=" + data.FechaFinal + "&dateStatus=" + data.Rango + "&Rutas=" + data.Rutas + "&Clientes=" + data.Clientes + "&Vendedor=" + data.Vendedor;
                    window.open(url + "/Reports/Ver?VAVClave=" + data.VAVClave + "&Cedis=" + data.Cedis.replace(/\+/g, "%2B") + "&nombreReport=" + data.nombreReport + "&nombreCedis=" + data.nombreCedis + "&FechaInicial=" + data.FechaInicial + "&FechaFinal=" + data.FechaFinal + "&dateStatus=" + data.Rango + "&Rutas=" + data.Rutas + "&Clientes=" + data.Clientes + "&Vendedor=" + data.Vendedor + "&detallado=" + data.reportType + "&unidadMedida=" + data.unidadMedida, "_blank");
                    cfpLoadingBar.complete();
                })
                .error(function (error, status, headers, config) {
                    //console.log(error);
                });
            }
        }

        ctrl.SelectAllChekboxesRoutes = SelectAllChekboxesRoutes;
        ctrl.SelectAllChekboxesSeller = SelectAllChekboxesSeller;
        ctrl.SelectAllChekboxesClients = SelectAllCheckboxesClients;
        ctrl.SelectAllChekboxesAllRoutes = SelectAllChekboxesAllRoutes;

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

        //bloquea  el listado de rutas cuando se selecciona un vendedor
        ctrl.ClearRouteCheckBoxes = ClearAllRouteCheckBoxes;
        ctrl.ClearAllRoutesCheckBoxes = ClearAllRoutesCheckBoxes;
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

        function ClearAllRoutesCheckBoxes() {
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


        //vista de los mapas
        ctrl.minDate = new Date();
        ctrl.mapListCoordinates = ctrl.mapListCoordinates;
        ctrl.GetMapCoordinates = GetMapCoordinates;
        ctrl.RouteSelected = "Route";
        ctrl.mapDate = undefined;
        ctrl.test = ctrl.test;
        ctrl.lat = 23.5309891;
        ctrl.long = -104.5345101;
        ctrl.zoom = 11;

        NgMap.getMap().then(function (map) {
            ctrl.map = map;

        });

        $timeout(function () { $('#direOarea').focus(); });

        $scope.refreshMap = function () {
            google.maps.event.trigger($scope.map, 'resize');
        }

        $scope.mycallback = function (map) {
            $scope.mymap = map;
            $scope.$apply();
        };

        function GetMapCoordinates(route, date) {
            if (ctrl.VAVClave == 1) {
                $http.post(url + '/api/GetMapGenData', {
                    Route: route,
                    Date: ctrl.mapDate
                }).then(function successCallBack(response) {
                    window.data = response.data;
                    window.open(url + "/Maps/VerLogisticoGen", "_blank");
                }, function errorCallBack(response) {
                    if (response.status == 400) {
                        alert(response.data.Message);
                    }
                    if (response.status == 500) {
                        alert("Ha ocurrido un error");
                        //console.log(response.data.Message);
                    }
                });
            }
            else {
                $http.post(url + '/api/GetMapData', {
                    Route: route,
                    Date: ctrl.mapDate
                }).then(function successCallBack(response) {
                    window.data = response.data;
                    window.open(url + "/Maps/VerLogistico", "_blank");
                }, function errorCallBack(response) {
                    if (response.status == 400) {
                        alert(response.data.Message);
                    }
                    if (response.status == 500) {
                        alert("Ha ocurrido un error");
                        //console.log(response.data.Message);
                    }
                });
            }

        };

        ctrl.u = true;
        ctrl.e = true;
        ctrl.t = true;
        ctrl.k = true;
        ctrl.l = true;
        ctrl.p = true;

        ctrl.filter1 = filter1;
        ctrl.filter2 = filter2;
        ctrl.filter3 = filter3;
        ctrl.filter4 = filter4;
        ctrl.filter5 = filter5;
        ctrl.filter6 = filter6;
        ctrl.ResetPolilynes = ResetLines;

        function filter1() {
            if (ctrl.u == true) {
                ctrl.mapFrequencyList = null;
                //ctrl.map.shapes.foo.setMap(null);
            }
            else {
                //ctrl.map.shapes.foo.setMap(ctrl.map);
                ctrl.mapFrequencyList = ctrl.mapListCoordinates.ListFreq;
            }
        }

        function filter2() {
            if (ctrl.e == true) {
                ctrl.mapNoFrequencyList = null;
                //ctrl.map.shapes.foo2.setMap(null);
            }
            else {
                //ctrl.map.shapes.foo2.setMap(ctrl.map);
                ctrl.mapNoFrequencyList = ctrl.mapListCoordinates.ListOutFreq;
            }
        }

        function filter3() {
            if (ctrl.t == true) {
                ctrl.nVisit = null;
                //ctrl.map.shapes.foo3.setMap(null);
            }
            else {
                //ctrl.map.shapes.foo3.setMap(ctrl.map);
                ctrl.nVisit = ctrl.mapListCoordinates.ListNoVisit;
            }
        }

        function filter4() {
            if (ctrl.k == true) {
                ctrl.Real = null;
                ctrl.map.shapes.foo4.setMap(null);
            }
            else {
                ctrl.map.shapes.foo4.setMap(ctrl.map);
                ctrl.Real = ctrl.mapListCoordinates.ListReal;
            }
        }

        function filter5() {
            if (ctrl.l == true) {
                ctrl.Config = null;
                ctrl.map.shapes.foo5.setMap(null);
            }
            else {
                ctrl.map.shapes.foo5.setMap(ctrl.map);
                ctrl.Config = ctrl.mapListCoordinates.ListAgenda;
            }
        }

        function filter6() {
            if (ctrl.p == true) {
                ctrl.OutRange = null;
                //ctrl.map.shapes.foo6.setMap(null);
            }
            else {
                //ctrl.map.shapes.foo6.setMap(ctrl.map);
                ctrl.OutRange = ctrl.mapListCoordinates.ListOutRange;
            }
        }

        function ResetLines() {
            ctrl.testtest = [{ CoordenadaX: 0, CoordenadaY: 0 }, { CoordenadaX: 0, CoordenadaY: 0 }];

            ctrl.abcd = ctrl.testtest.map(function (marker) {
                return [marker.CoordenadaY, marker.CoordenadaX];
            })

            ctrl.map.shapes.foo.setMap(null);
            ctrl.map.shapes.foo.setMap(null);
            ctrl.map.shapes.foo2.setMap(null);
            //ctrl.map.shapes.foo3.setMap(null);
            ctrl.map.shapes.foo4.setMap(null);
            ctrl.map.shapes.foo5.setMap(null);
            //ctrl.map.shapes.foo6.setMap(null);
        }

        ctrl.ShowInfo = function (evt, id) {
            ctrl.infoWindowPosition = ctrl.mapFrequencyList[id];
            ctrl.map.showInfoWindow('bar', 'custom-marker-' + id);
        };

        ctrl.ShowInfoOutFreq = function (evt, id) {
            ctrl.infoWindowPosition = ctrl.mapNoFrequencyList[id];
            ctrl.map.showInfoWindow('OutFreq', 'custom-marker2-' + id);
        };

    }
})();