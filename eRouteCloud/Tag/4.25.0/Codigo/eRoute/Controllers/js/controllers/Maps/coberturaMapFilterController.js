(function () {
    angular
        .module('eRouteApp')
        .controller('coberturaMapFilterController', coberturaMapFilterController)
    coberturaMapFilterController.$inject = ['$scope', '$http', '$mdToast', '$q', '$timeout', 'cfpLoadingBar', "mapServices"];

    function coberturaMapFilterController($scope, $http, $mdToast, $q, $timeout, cfpLoadingBar, mapServices) {

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
        ctrl.esquemas = [];
        ctrl.productos = [];

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

        //obtiene los registros de esquemas de bd
        getEsquemas();
        function getEsquemas() {
            mapServices.getEsquemas()
                .then(function successCallBack(response) {
                    ctrl.esquemas = response.data;
            }, function errorCallBack(response) {


            });
        }

        //obtiene los registros de productos de bd
        getProductos();
        function getProductos() {
            mapServices.getProductos()
                .then(function successCallBack(response) {
                    ctrl.productos = response.data;
                }, function errorCallBack(response) {


                });
        }


        //esquema autocomplete
        ctrl.filtraBusqueda = filtraBusqueda;
        function filtraBusqueda(busqueda, lista) {// realiza buscado en listado de estados
            var ret = ""
            if (!_.isNil(busqueda)) {
                ret = _.filter(lista, function (d) {
                    return (d.Nombre).toLowerCase().indexOf(busqueda.toLowerCase()) !== -1 ||busqueda == "";
                });
            }
            return ret;
        }

        //inicializa el autocomplete
        ctrl.initProductos = initProductos;
        function initProductos() {
            ctrl.esquema = undefined;
            ctrl.producto = undefined;
            ctrl.busquedaProducto = undefined;
            $timeout(function () {
                $('#producto md-autocomplete-wrap input').focus();
            }, 100);
        }

        ctrl.initEsquema = initEsquema;
        function initEsquema() {
            ctrl.producto = undefined;
            ctrl.esquema = undefined;
            ctrl.busquedaEsquema = undefined;
            $timeout(function () {
                $('#esquema md-autocomplete-wrap input').focus();
            }, 100);
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
        ctrl.Tipo = 1;
        ctrl.tipoFiltro;

        ctrl.startbar = function () {
            cfpLoadingBar.start();
        };

        ctrl.completebar = function () {
            cfpLoadingBar.complete();
        };

        //envia el formulario completo
        function SubmitForm() {
            //console.log(ctrl.State);
            var countRoutes = 0;
            angular.forEach(ctrl.routes, function (item) {
                if (item.Checked == true) {
                    countRoutes++;
                }
            });
            if (countRoutes <= 0) {
                alert("Seleccione ruta");
                cfpLoadingBar.complete();
            }
            else if (_.isNil(ctrl.tipoFiltro)) {
                alert("Seleccione un esquema o producto");
                cfpLoadingBar.complete();
            }
            else if (_.isNil(ctrl.producto) && _.isNil(ctrl.esquema)) {
                alert("Seleccione un esquema o producto");
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
                var data = {
                    Cedis: ctrl.selectedItem.value,
                    dateStatus: ctrl.State,
                    Routes: ctrl.routes,
                    init: moment(ctrl.date1).format('YYYY-MM-DD'),
                    end:moment(ctrl.date2).format('YYYY-MM-DD'),
                    vavclave: ctrl.VAVClave,
                    tipo: ctrl.Tipo,
                    esquemaId: _.isNil(ctrl.esquema) ? "" : ctrl.esquema.EsquemaID,
                    productoClave: _.isNil(ctrl.producto) ? "" : ctrl.producto.ProductoClave
                }

                mapServices.getMapData(data)
                .then(function successCallback(response) {
                    console.log(response);
                    if (response.data.Rutas.length > 0 || response.data.RutasTotales.length > 0) {
                        window.rutasTotales = response.data.RutasTotales;
                        window.rutas = response.data.Rutas;
                        window.coordenadas = { CoordenadaX: response.data.CoordenadaX, CoordenadaY: response.data.CoordenadaY };
                        window.open(url + "/Maps/Ver", "_blank");
                    } else {
                        window.open(url + "/Maps/NoRegistros", "_blank");
                    }
                }, function errorCallback(response) {

                });
            }
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






        //bloquea  el listado de vendedores cuando se selecciona una ruta
        ctrl.ClearRouteCheckBoxes = ClearAllRouteCheckBoxes;
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