(function () {
    angular
        .module('eRouteApp')
        .controller('clientesSinVentaMapController', clientesSinVentaMapController)
    clientesSinVentaMapController.$inject = ['$scope', 'NgMap'];

    function clientesSinVentaMapController($scope, NgMap) {

        var ctrl = this;
        var url = window.sessionStorage.getItem('URL');
        ctrl.rutas;
        ctrl.showRutas = false;


        

        

        //console.log(ctrl.rutas);

        ctrl.lat = 23.5309891;
        ctrl.long = -104.5345101;
        ctrl.zoom = 11;

        cargarRutas();
        function cargarRutas() {
            ctrl.rutasTotales = window.opener.rutasTotales;
            ctrl.rutas = window.opener.rutas;
            ctrl.coordenadas = window.opener.coordenadas;
            ctrl.lat = ctrl.coordenadas.CoordenadaY;
            ctrl.long = ctrl.coordenadas.CoordenadaX;
            ctrl.showRutas = true;
        }

        NgMap.getMap().then(function (map) {
            ctrl.map = map;

        });

        ctrl.mycallback = function (map) {
            ctrl.mymap = map;
            ctrl.$apply();
        };

        ctrl.refreshMap = function () {
            google.maps.event.trigger($scope.map, 'resize');//este evento redimensiona el mapa al ser llamado
        }

        ctrl.ShowInfo = function (evt, cliente) {
            //ctrl.infoWindowPosition = ctrl.mapFrequencyList[id];
            ctrl.infoWindowPosition = cliente;
            ctrl.map.showInfoWindow('bar', 'custom-marker-' + cliente.Clave);
        };

        ctrl.ShowInfoClientes = function (evt, cliente) {
            //ctrl.infoWindowPosition = ctrl.mapFrequencyList[id];
            ctrl.infoWindowPosition = cliente;
            ctrl.map.showInfoWindow('bar', 'custom-cliente-marker-' + cliente.Clave);
        };

        //ctrl.showList = false;
        //ctrl.showSelect = undefined;
        //ctrl.nShowLists = nShowLists;
        //ctrl.selectedItem = ctrl.selectedItem;
        //ctrl.OnSelectChange = OnSelectChange;
        //ctrl.minDate = new Date();

        ////muestra el segundo datepicker cuando el estado de la fecha es 'Entre'
        //function OnSelectChange(state) {
        //    if (state == 'Entre') {
        //        ctrl.showSelect = 'true';
        //    }
        //    else {
        //        ctrl.showSelect = undefined;
        //    }
        //}

        //function nShowLists(state) {
        //    if (state == undefined) {
        //        ctrl.showList = undefined;
        //    }
        //    else {
        //        ctrl.showList = 'true';
        //    }
        //}


        ////Cedis config
        //var load = [GetCedis()]
        ////var load = [GetActivityList()]

        //$q.all(load).then(function () {
        //})

        //var self = this;
        //self.simulateQuery = false;
        //self.isDisabled = false;
        //self.querySearch = querySearch;
        //self.selectedItemChange = selectedItemChange;
        //self.searchTextChange = searchTextChange;

        ////load maps on sidebar menu

        //function querySearch(query) {

        //    var results = query ? self.states.filter(createFilterFor(query)) : self.states,
        //        deferred;

        //    if (self.simulateQuery) {
        //        deferred = $q.defer();
        //        $timeout(function () { deferred.resolve(results); }, Math.random() * 1000, false);
        //        return deferred.promise;
        //    } else {
        //        return results;
        //    }
        //}

        //function createFilterFor(query) {
        //    var lowercaseQuery = angular.lowercase(query);
        //    return function filterFn(state) {
        //        return (state.value.indexOf(lowercaseQuery) === 0);
        //    };
        //}

        //function searchTextChange(text) {
        //    //console.log('Text changed to ' + text);
        //}

        //function selectedItemChange(item) {
        //    $log.info('Item changed to ' + JSON.stringify(item));
        //}

        //function loadAll(s) {
        //    var allstates = s;
        //    return allstates.toString().split(',').map(function (state) {
        //        return {
        //            value: state.toString().substr(0, state.indexOf(' ')),
        //            display: state
        //        };
        //    });
        //}

        //function GetCedis() {
        //    $http({
        //        url: url + '/api/GetCedis?USUId=' + window.sessionStorage.getItem('USUId'),
        //        method: 'GET',
        //        headers: {
        //            Authorization: window.sessionStorage.getItem('Token'),
        //            'Content-Type': 'application/json'
        //        },
        //    }).then(function successCallBack(response) {
        //        self.states = loadAll(response.data);
        //    }, function errorCallBack(response) {

        //    });
        //}



        ////routes functions
        //ctrl.routes = GetRoutes();
        //ctrl.GetRoutes = GetRoutes;

        //function GetRoutes(selectedItem) {
        //    $http({
        //        url: url + '/api/GetRoutes?Cedis=' + selectedItem,
        //        method: 'GET',
        //        headers: {
        //            Authorization: window.sessionStorage.getItem('Token'),
        //            'Content-Type': 'application/json'
        //        },
        //    }).then(function successCallBack(response) {
        //        ctrl.routes = response.data;
        //    }, function errorCallBack(response) {


        //    });
        //}

        ////dates state functions
        //ctrl.State = undefined;
        //ctrl.dateState = GetDates();

        //function GetDates() {
        //    $http({
        //        url: url + '/api/GetDateStatus',
        //        method: 'GET',
        //        headers: {
        //            Authorization: window.sessionStorage.getItem('Token'),
        //            'Content-Type': 'application/json'
        //        },
        //    }).then(function successCallBack(response) {
        //        ctrl.dateState = response.data;
        //    }, function errorCallBack(response) {

        //    });
        //}

        //ctrl.SubmitForm = SubmitForm;
        //ctrl.date1 = undefined;
        //ctrl.date2 = undefined;
        //ctrl.pvEsFecha = false;
        //ctrl.VAVClave = undefined;
        //ctrl.ReportType = false;
        //ctrl.UnidadMedida = "Cartones";

        //ctrl.startbar = function () {
        //    cfpLoadingBar.start();
        //};

        //ctrl.completebar = function () {
        //    cfpLoadingBar.complete();
        //};

        ////envia el formulario completo
        //function SubmitForm(Cedis, dateStatus, Routes, Clientes, pvEsFecha, campoFecha) {
        //    //console.log(ctrl.State);
        //    var countRoutes;
        //    angular.forEach(ctrl.routes, function (item) {

        //        if (item.Checked == true) {
        //            countRoutes++;
        //        }
        //    });

        //    var countSellers;
        //    angular.forEach(ctrl.sellers, function (item) {

        //        if (item.Checked == true) {
        //            countSellers++;
        //        }
        //    });

        //    if (countRoutes <= 0 || countSellers <= 0) {
        //        alert("Seleccione ruta o vendedor");
        //        cfpLoadingBar.complete();
        //    }
        //    else if (ctrl.State == undefined) {
        //        alert("Seleccione rango de fechas");
        //        cfpLoadingBar.complete();
        //    }
        //    else if (ctrl.State == 'Entre' && (ctrl.date1 == undefined || ctrl.date2 == undefined)) {
        //        alert("Seleccion rango de fechas");
        //        cfpLoadingBar.complete();
        //    }
        //    else if (ctrl.date1 == undefined) {
        //        alert("Seleccion fecha");
        //        cfpLoadingBar.complete();
        //    }
        //    else {
        //        var data = {
        //            Cedis: ctrl.selectedItem.value,
        //            nombreCedis: ctrl.selectedItem.display,
        //            dateStatus: ctrl.State,
        //            Seller: ctrl.sellers,
        //            init: moment(ctrl.date1).format('YYYY-MM-DD'),
        //            end:moment(ctrl.date2).format('YYYY-MM-DD'),
        //            vavclave: ctrl.VAVClave,
        //            reportType: ctrl.ReportType,
        //        }

        //        $http.post(url + '/Reports/GetCondition', data, { ignoreLoadingBar: true })
        //        .success(function (data, status, headers, config) {
        //            window.open(url + "/Reports/Ver?VAVClave=" + data.VAVClave + "&Cedis=" + data.Cedis + "&nombreReport=" + data.nombreReport + "&nombreCedis=" + data.nombreCedis + "&FechaInicial=" + data.FechaInicial + "&FechaFinal=" + data.FechaFinal + "&dateStatus=" + data.Rango + "&Rutas=" + data.Rutas + "&Clientes=" + data.Clientes + "&Vendedor=" + data.Vendedor + "&detallado=" + data.reportType + "&unidadMedida=" + data.unidadMedida, "_blank");
        //            cfpLoadingBar.complete();
        //        })
        //        .error(function (error, status, headers, config) {
        //        });
        //    }
        //}

        //ctrl.SelectAllChekboxesRoutes = SelectAllChekboxesRoutes;




        //function SelectAllChekboxesRoutes(selectAll) {
        //    if (selectAll == undefined || selectAll == false) {
        //        angular.forEach(ctrl.routes, function (item) {
        //            item.Checked = true;
        //        });
        //    }

        //    else {
        //        angular.forEach(ctrl.routes, function (item) {
        //            item.Checked = false;
        //        });
        //    }
        //}


 



        ////bloquea  el listado de vendedores cuando se selecciona una ruta
        //ctrl.ClearRouteCheckBoxes = ClearAllRouteCheckBoxes;
        //function ClearAllRouteCheckBoxes() {
        //    $scope.fil = [];

        //    angular.forEach(ctrl.sellers, function (item) {
        //        if (item.Checked == true) {
        //            $scope.fil.push(item.Checked);
        //        }
        //    });

        //    if ($scope.fil.length > 0) {
        //        angular.forEach(ctrl.routes, function (item) {
        //            item.Checked = false;
        //            item.Disabled = true;

        //        });
        //        $scope.RoutesSelectallCheckBox = true;
        //        $scope.selectAll = false;
        //    }
        //    else if ($scope.fil.length == 0) {
        //        angular.forEach(ctrl.routes, function (item) {
        //            item.Checked = false;
        //            item.Disabled = false;

        //        });
        //        $scope.RoutesSelectallCheckBox = false;
        //        $scope.selectAll = false;
        //    }
        //}


        //var last = { bottom: true, top: false, left: true, right: false };


        ////toast
        //$scope.toastPosition = angular.extend({}, last);

        //$scope.getToastPosition = function () {
        //    sanitizePosition();
        //    return Object.keys($scope.toastPosition)
        //      .filter(function (pos) { return $scope.toastPosition[pos]; })
        //      .join(' ');
        //};

        //function sanitizePosition() {
        //    var current = $scope.toastPosition;
        //    if (current.bottom && last.top) current.top = false;
        //    if (current.top && last.bottom) current.bottom = false;
        //    if (current.right && last.left) current.left = false;
        //    if (current.left && last.right) current.right = false;
        //    last = angular.extend({}, current);
        //}

        //function showSimpleToast(Message) {
        //    var pinTo = $scope.getToastPosition();
        //    $mdToast.show(
        //      $mdToast.simple()
        //        .textContent(Message)
        //        .position(pinTo)
        //        .hideDelay(3000)
        //    );
        //};

    }
})();