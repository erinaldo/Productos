app.controller('ventasvsAnioAnteriorController', ['$scope', '$mdToast', '$q', '$timeout', 'valorReferencia', '$http', 'cfpLoadingBar', function ($scope, $mdToast, $q, $timeout, valorReferencia, $http, cfpLoadingBar) {

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
    ctrl.maxDate = new Date();
    ctrl.GetList;
    ctrl.Mostrar = false;

    ctrl.SubmitForm = SubmitForm;
    ctrl.date1 = undefined;
    ctrl.date2 = undefined;
    ctrl.pvEsFecha = false;
    ctrl.VAVClave = undefined;
    ctrl.ReportType = false;
    ctrl.UnidadMedida = "Piezas";

    var self = this;
    self.simulateQuery = false;
    self.isDisabled = false;
    self.querySearch = querySearch;
    self.selectedItemChange = selectedItemChange;
    self.searchTextChange = searchTextChange;

    //Establece el limite de fecha
    ctrl.Limit = function () {
        if (ctrl.date1.getFullYear() == ctrl.maxDate.getFullYear()) {
            ctrl.maxDate = new Date();
        }
        else {
            ctrl.maxDate = new Date(
                ctrl.date1.getFullYear(),
                11,
                31
            );
        }
    };

    $scope.EstablecerReporte = function (VAVClave) {
        valorReferencia.obtenerValorClave('REPORTEW', VAVClave, function (result) {
            ctrl.titulo = result[0].Descripcion;
        });

        GetCedis();
    }

    ////Carga la lista de CEDIS
    //var load = [GetCedis()]
    //$q.all(load).then(function () {
    //})

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

    //Seleccionar todas las rutas a la vez
    ctrl.SelectAllChekboxesRoutes = SelectAllChekboxesRoutes;

    function SelectAllChekboxesRoutes(selectAll) {
        if (selectAll === undefined || selectAll === false) {
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

    //Obtiene los vendedores relacionadas al CEDIS ya seleccionado
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

    //Selecciona todos los vendedores
    ctrl.SelectAllChekboxesSeller = SelectAllChekboxesSeller;

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

    //bloquea  el listado de rutas cuando se selecciona un vendedor
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

    //Envia el formulario completo
    function SubmitForm(Cedis, dateStatus, Routes, Clientes, pvEsFecha, campoFecha) {
        if (ctrl.date1 == undefined) {
            alert("Seleccion fecha");
            cfpLoadingBar.complete();
        }
        else {
            if (ctrl.showList) {
                var data = {
                    nombreReport: ctrl.titulo,
                    Cedis: ctrl.selectedItem.value,
                    nombreCedis: ctrl.selectedItem.display,
                    Seller: ctrl.sellers,
                    vavclave: ctrl.VAVClave,
                    init: moment(ctrl.date1).format('YYYY-MM-DD'),
                    end:moment(ctrl.date2).format('YYYY-MM-DD'),
                    reportType: ctrl.ReportType,
                    unidadMedida: ctrl.UnidadMedida
                }
            }
            else {
                var data = {
                    nombreReport: ctrl.titulo,
                    Cedis: '',
                    nombreCedis: '',
                    Seller: ctrl.sellers,
                    vavclave: ctrl.VAVClave,
                    init: moment(ctrl.date1).format('YYYY-MM-DD'),
                    end:moment(ctrl.date2).format('YYYY-MM-DD'),
                    reportType: ctrl.ReportType,
                    unidadMedida: ctrl.UnidadMedida
                }
            }

            $http.post(url + '/Reports/GetCondition', data, { ignoreLoadingBar: true })
                .then(function () {
                    window.open(url + '/Reports/Ver');
                    cfpLoadingBar.complete();
                });
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
}]);