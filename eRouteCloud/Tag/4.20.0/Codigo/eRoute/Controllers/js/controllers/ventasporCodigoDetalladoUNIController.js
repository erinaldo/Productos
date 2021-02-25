(function () {
    angular
        .module('eRouteApp')
        .controller('ventasporCodigoDetalladoUNIController', ventasporCodigoDetalladoUNIController)
    ventasporCodigoDetalladoUNIController.$inject = ['$scope', '$http', '$mdToast', '$q', '$timeout', 'NgMap', 'cfpLoadingBar', '$filter', "menuServices", "reportServices"];

    function ventasporCodigoDetalladoUNIController($scope, $http, $mdToast, $q, $timeout, NgMap, cfpLoadingBar, $filter, menuServices, reportServices) {

        //Inicialización de variables
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
        ctrl.FLock = false;
        ctrl.RLock = false;
        ctrl.TiLock = false;

        ctrl.SubmitForm = SubmitForm;
        ctrl.date1 = undefined;
        ctrl.date2 = undefined;
        ctrl.pvEsFecha = false;
        ctrl.VAVClave = undefined;
        ctrl.ReportType = false;
        ctrl.UnidadMedida = "Piezas";
        ctrl.TipoReporte = true;

        var self = this;
        self.simulateQuery = false;
        self.isDisabled = false;
        self.querySearch = querySearch;
        self.selectedItemChange = selectedItemChange;
        self.searchTextChange = searchTextChange;

        ctrl.SelectedRoute = false;

        //Carga la lista de CEDIS
        var load = [GetCedis()]
        $q.all(load).then(function () {
        })

        GetList();
        function GetList() {
            menuServices.getReportList()
                .then(function successCallback(response) {
                    ctrl.GetList = response.data;
                },
                function errorCallback(response) {
                    if (response.status === 401) {
                        window.sessionStorage.clear();
                        window.location = url + '/Login';
                    }
                });
        }

        function OnSelectChange(state) {
            if (state === 'Entre') {
                ctrl.showSelect = 'true';
            }
            else {
                ctrl.showSelect = undefined;
            }
        }

        function nShowLists(state) {
            if (state === undefined) {
                ctrl.showList = undefined;
            }
            else {
                ctrl.showList = 'true';
            }
        }

        //products functions
        ctrl.products = GetProducts();
        function GetProducts() {
            $http({
                url: url + '/api/GetProducts',
                method: 'GET',
                headers: {
                    Authorization: window.sessionStorage.getItem('Token'),
                    'Content-Type': 'application/json'
                }
            }).then(function successCallBack(response) {
                ctrl.products = response.data;
            }, function errorCallBack(response) {


            });
        }

        //dates state functions
        ctrl.State = undefined;
        ctrl.dateState = GetDates();

        //Obtiene las fechas
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

        //Obtiene los centros de distribucion (CEDIS)
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
                self.states = response.data;
            }, function errorCallBack(response) {

            });
        }

        //Ayudan a manipular la barra de carga
        ctrl.startbar = function () {
            cfpLoadingBar.start();
        };

        ctrl.completebar = function () {
            cfpLoadingBar.complete();
        };

        //Obtiene las rutas relacionadas al CEDIS ya seleccionado
        ctrl.routes = GetRoutes();
        ctrl.GetRoutes = GetRoutes;

        function GetRoutes(selectedItem) {
            if (selectedItem === undefined)
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

        ctrl.RUTClave = "";
        ctrl.EsquemaId = "";
        ctrl.productschemes = undefined;

        //seller functions
        ctrl.group = 'ProductScheme';
        ctrl.GetProductsSchemes = GetProductsSchemes;

        function GetProductsSchemes(EsquemaID) {
            $http({
                url: url + '/api/GetProductsScheme?Productos='+EsquemaID,
                method: 'GET',
                headers: {
                    Authorization: window.sessionStorage.getItem('Token'),
                    'Content-Type': 'application/json'
                },
            }).then(function successCallBack(response) {
                ctrl.productschemes = response.data;
            }, function errorCallBack(response) {
                });
        }
        

        ctrl.SelectAllCheckboxesProductsSchemes = SelectAllCheckboxesProductsSchemes;
        function SelectAllCheckboxesProductsSchemes(selectAll) {
            if (selectAll == undefined || selectAll == false) {
                angular.forEach(ctrl.productschemes, function (item) {
                    item.Checked = true;
                });
            }

            else {
                angular.forEach(ctrl.productschemes, function (item) {
                    item.Checked = false;
                });
            }
        }

        //Envia el formulario completo
        function SubmitForm(Cedis, dateStatus, Routes, Esquema, Productos, pvEsFecha, campoFecha) {
            if (ctrl.TiLock == false) {
                alert("Elija un tipo de Reporte");
                cfpLoadingBar.complete();
            }
            else if (ctrl.RLock == false) {
                alert("Seleccione una Ruta");
                cfpLoadingBar.complete();
            }
            else if (ctrl.FLock == false) {
                alert("Seleccione Familia de Producto");
                cfpLoadingBar.complete();
            }
            else if (ctrl.State === undefined) {
                alert("Seleccione rango de fechas");
                cfpLoadingBar.complete();
            }
            else if (ctrl.State === 'Entre' && (ctrl.date1 === undefined || ctrl.date2 === undefined)) {
                alert("Seleccion rango de fechas");
                cfpLoadingBar.complete();
            }
            else if (ctrl.date1 === undefined) {
                alert("Seleccion fecha");
                cfpLoadingBar.complete();
            }
            else {
                //Modificar esto una vez entienda la estructura***************************************************************************************************************
                var data = {
                    nombreReport: ctrl.nombreReport,
                    Cedis: ctrl.selectedItem.value,
                    nombreCedis: ctrl.selectedItem.display,
                    dateStatus: ctrl.State,
                    Routes: Routes,
                    Products: ctrl.products,
                    ProductsSchema: ctrl.productschemes,
                    init: ctrl.date1,
                    end: ctrl.date2,
                    vavclave: ctrl.VAVClave,
                    reportType: ctrl.TipoReporte,
                    unidadMedida: ctrl.UnidadMedida
                }

                $http.post(url + '/Reports/GetCondition', data, { ignoreLoadingBar: true })
                    .success(function (data, status, headers, config) {
                        window.open(url + "/Reports/Ver?VAVClave=" + data.VAVClave + "&Cedis=" + data.Cedis.replace(/\+/g, "%2B") + "&nombreReport=" + data.nombreReport + "&nombreCedis=" + data.nombreCedis + "&FechaInicial=" + data.FechaInicial + "&FechaFinal=" + data.FechaFinal + "&dateStatus=" + data.Rango + "&Rutas='" + ctrl.RUTClave + "'&Clientes=" + data.Clientes + "&Vendedor=" + data.Vendedor + "&detallado=" + ctrl.Radio + "&unidadMedida=" + data.unidadMedida + "&CENClave=" + data.CENClave + "&promocion=" + data.promocion + "&nombreProductos=" + data.ProductosScheme + "&Presupuesto=" + data.Presupuesto + "&Productos='" + ctrl.EsquemaId + "'", "_blank")
                        cfpLoadingBar.complete();
                    })
                    .error(function (error, status, headers, config) {
                    });
                //************************************************************************************************************************************************************
            }
        }

        //No se que hacen   
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