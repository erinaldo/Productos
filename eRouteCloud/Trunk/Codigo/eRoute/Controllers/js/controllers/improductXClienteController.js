app.controller('improductXClienteController', ['$scope', '$mdToast', '$q', '$timeout', 'valorReferencia', '$http', 'cfpLoadingBar', function ($scope, $mdToast, $q, $timeout, valorReferencia, $http, cfpLoadingBar) {
    var ctrl = this;
    var url = window.sessionStorage.getItem('URL');

    ctrl.isDisabled = false;
    ctrl.showList = false;
    ctrl.showSelect = undefined;
    ctrl.nShowLists = nShowLists;
    ctrl.selectedItem = ctrl.selectedItem;
    ctrl.OnSelectChange = OnSelectChange;
    ctrl.minDate = new Date();
    ctrl.date1 = undefined;
    ctrl.date2 = undefined;
    ctrl.VAVClave = undefined;
    ctrl.ReportType = false;
    ctrl.showErrorForm = false;

    ctrl.RUTClave = "";
    ctrl.VendedorId = "";

    $scope.EstablecerReporte = function (VAVClave) {
        valorReferencia.obtenerValorClave('REPORTEW', VAVClave, function (result) {
            ctrl.titulo = result[0].Descripcion;
        });

        GetCedis();
    }

    //Cedis config
    //var load = [GetCedis()]
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

    //seller functions
    ctrl.sellers = GetSellers();
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

    function nShowLists(state) {
        if (state == undefined) {
            ctrl.showList = undefined;
        }
        else {
            ctrl.showList = 'true';
        }
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

    //BUSCAR CEDI POR FILTRO
    ctrl.querySearch = querySearch;
    function querySearch(query) {
        var results = query ? self.states.filter(createFilterFor(query)) : self.states,
            deferred;
        return results;
    }
    function createFilterFor(query) {
        var lowercaseQuery = query.toLowerCase();
        return function filterFn(states) {
            var dis = states.display;
            var lowerCaseDisplay = dis.toLowerCase();
            return (lowerCaseDisplay.indexOf(lowercaseQuery) === 0);
        };
    }

    //SELECCION PARA TODAS LAS RUTAS
    ctrl.SelectAllChekboxesAllRoutes = SelectAllChekboxesAllRoutes;
    function SelectAllChekboxesAllRoutes(selectAll) {
        if (selectAll == undefined || selectAll == false) {
            angular.forEach(ctrl.routes, function (item) {
                item.Checked = true;
            });
        }
        else {
            angular.forEach(ctrl.routes, function (item) {
                item.Checked = false;
            })
        }
    }

    //BLOQUEA  EL LISTADO DE VENDEDORES CUANDO SE SELECCIONA UNA RUTA
    ctrl.ClearSellersCheckBoxes = ClearAllSellersCheckBoxes;
    function ClearAllSellersCheckBoxes() {
        ctrl.showErrorForm = false;
        $scope.fillSellers = [];

        angular.forEach(ctrl.routes, function (item) {
            if (item.Checked == true) {
                $scope.fillSellers.push(item.Checked);
            }
        });

        if ($scope.fillSellers.length > 0) {
            ctrl.VendedorId = "";
        }
    }

    //BLOQUEA  EL LISTADO DE RUTAS CUANDO SE SELECCIONA UN VENDEDOR
    ctrl.ClearRouteCheckBoxes = ClearAllRouteCheckBoxes;
    function ClearAllRouteCheckBoxes(seller) {
        ctrl.showErrorForm = false;
        $scope.fillRoutes = [];

        if (seller) {
            $scope.fillRoutes.push(seller);
        }

        if ($scope.fillRoutes.length > 0) {
            angular.forEach(ctrl.routes, function (item) {
                item.Checked = false;
            });
            $scope.selectAll = false;
        }
        else if ($scope.fillRoutes.length = 0) {
            angular.forEach(ctrl.routes, function (item) {
                item.Checked = false;
            });
            $scope.RoutesSelectallCheckBox = false;
            $scope.selectAll = false;
        }
    }

    //HABILITA RANGO DE FECHAS
    function OnSelectChange(state) {
        ctrl.showErrorForm = false;
        if (state == 'Entre') {
            ctrl.showSelect = 'true';
        }
        else {
            ctrl.date2 = '';
            ctrl.showSelect = undefined;
        }
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

    $scope.$watch("ctrl.date1", function () {
        if (ctrl.State == "Igual") {
            ctrl.showErrorForm = false;
        }
        else if (ctrl.State == 'Entre' && (ctrl.date1 != undefined && ctrl.date2 != undefined)) {
            ctrl.showErrorForm = false;
        }

    });

    $scope.$watch("ctrl.date2", function () {

        if (ctrl.State == 'Entre' && (ctrl.date1 != undefined && ctrl.date2 != undefined)) {
            ctrl.showErrorForm = false;
        }
    });

    //INICIA UNA BARRA DE CARGA
    ctrl.startbar = function () {
        cfpLoadingBar.start();
    };

    //MUESTRA UN MENSAJE DE ERROR
    function muestraError(cadena) {
        ctrl.ErrorEnviar = cadena;
        ctrl.showErrorForm = true;
        cfpLoadingBar.complete();
    }

    ctrl.SubmitForm = SubmitForm;
    //ENVIA EL FORMULARIO COMPLETO
    function SubmitForm(Cedi, dateStatus, Routes, Sellers, VAVClave) {

        var countRoutes = 0;

        //VERIFICA LA CANTIDAD DE CHECKBOX MARCADOS PARA RUTAS
        angular.forEach(ctrl.routes, function (item) {
            if (item.Checked == true) {
                countRoutes++;
            }
        });

        if (countRoutes <= 0 && ctrl.VendedorId == "") {
            muestraError("Seleccione una ruta o un Vendedor");
        }
        else if (ctrl.State == undefined) {
            muestraError("Seleccione rango de fechas");
        }
        else if (ctrl.State == 'Entre' && (ctrl.date1 == undefined || ctrl.date2 == undefined)) {
            muestraError("Seleccione las fechas");
        }
        else if (ctrl.State == 'Entre' && (ctrl.date2 <= ctrl.date1)) {
            muestraError("Rango de fechas erróneo");
        }
        else if (ctrl.date1 == undefined) {
            muestraError("Seleccione la fecha");
        }
        else {
            var ven = "";
            if (ctrl.VendedorId != "") {
                angular.forEach(ctrl.sellers, function (item) {
                    if (item.VendedorId == ctrl.VendedorId) {
                        ven = item.Nombre;
                    }
                });
            }

            var data = {
                nombreReport: ctrl.titulo,
                Cedis: Cedi,
                nombreCedis: ctrl.selectedItem.display,
                dateStatus: ctrl.State,
                Routes: Routes,
                Seller: Sellers,
                init: moment(ctrl.date1).format('YYYY-MM-DD'),
                end:moment(ctrl.date2).format('YYYY-MM-DD'),
                vavclave: ctrl.VAVClave,
                reportType: ctrl.ReportType,
                NombreProductos: ven
            }

            $http.post(url + '/Reports/GetCondition', data, { ignoreLoadingBar: true })
                .then(function () {
                    window.open(url + '/Reports/Ver');
                    cfpLoadingBar.complete();
                });
        }
    }
}]);