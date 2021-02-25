app.controller('pedidosConfirmadosPRSController', ['$scope', '$mdToast', '$q', '$timeout', 'valorReferencia', '$http', 'cfpLoadingBar', function ($scope, $mdToast, $q, $timeout, valorReferencia, $http, cfpLoadingBar) {
    var url = window.sessionStorage.getItem('URL');
    var self = this;

    self.SubmitForm = SubmitForm;
    self.date1 = undefined;
    self.VAVClave = undefined;
    $scope.Group1 = "Rutas";
    self.RoutesFilters = true;
    self.SellersFilters = false;
    $scope.Group2 = "EsquemaClientes";
    self.SchemesClientsFilters = true;
    self.ClientsFilters = false;

    self.showList = false;
    self.showSelect = undefined;
    self.nShowLists = nShowLists;
    self.selectedItem = self.selectedItem;
    self.OnSelectChange = OnSelectChange;
    self.minDate = new Date();

    function OnSelectChange(state) {
        if (state == 'Entre') {
            self.showSelect = 'true';
        }
        else {
            self.showSelect = undefined;
        }
    }

    function nShowLists(state) {
        if (state == undefined) {
            self.showList = undefined;
        }
        else {
            self.showList = 'true';
        }
    }

    $scope.EstablecerReporte = function (VAVClave) {
        valorReferencia.obtenerValorClave('REPORTEW', VAVClave, function (result) {
            self.titulo = result[0].Descripcion;
        });
    }

    //Llenar CEDIS
    self.cedis = GetCEDIS();
    self.querySearch = querySearch;
    function GetCEDIS() {
        $http({
            url: url + '/API/GetReportFilters/GetCEDIS',
            method: 'GET',
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-Type': 'application/json'
            },
            params: { USUId: window.sessionStorage.getItem('USUId') }
        }).then(function successCallBack(response) {
            self.cedis = response.data;
        }, function errorCallBack(response) {
        });
    }

    function querySearch(query) {
        var results = query ? self.cedis.filter(createFilterFor(query)) : self.cedis,
            deferred;
        return results;
    }

    function createFilterFor(query) {
        var lowercaseQuery = query.toLowerCase();
        return function filterFn(cedis) {
            var dis = cedis.Nombre;
            var lowercaseDispley = dis.toLowerCase();
            return (lowercaseDispley.indexOf(lowercaseQuery) === 0);
        };
    }

    //Fechas
    self.State = undefined;
    self.dateState = GetDates();
    function GetDates() {
        $http({
            url: url + '/API/GetReportFilters/GetDateStatus',
            method: 'GET',
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-Type': 'application/json'
            },
        }).then(function successCallBack(response) {
            self.dateState = response.data;
        }, function errorCallBack(response) {
        });
    }

    //Llenar Rutas
    self.routes = GetRoutes();
    self.GetRoutes = GetRoutes;
    function GetRoutes(selectedItem) {
        (selectedItem == undefined ? null : selectedItem.replace(/\+/g, "%2B"));

        $http({
            url: url + '/API/GetReportFilters/GetRoutes',
            method: 'GET',
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-Type': 'application/json'
            },
            params: { cedis: selectedItem, estado: null, type: "1,3" }
        }).then(function successCallBack(response) {
            self.routes = response.data;
        }, function errorCallBack(response) { });
    }

    ////Seleccionar todas las Rutas
    self.SelectAllChekboxesRoutes = SelectAllChekboxesRoutes;
    function SelectAllChekboxesRoutes(selectAll) {
        checkedAllCombo(self.routes, selectAll);
    }

    self.CountRoutes = function () {
        var coun = countComboBoxElements($scope.selectAllRoutes, $scope.queryRoute, self.routes);
        $scope.selectAllRoutes = coun[0];
        $scope.queryRoute = coun[1];
    }

    ////LLENAR VENDEDORES
    self.seller = GETSeller();
    self.GETSeller = GETSeller;
    function GETSeller(selectedItem) {
        (selectedItem == undefined ? null : selectedItem.replace(/\+/g, "%2B"));

        $http({
            url: url + '/API/GetReportFilters/GetSellers',
            method: 'GET',
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-Type': 'application/json'
            },
            params: { cedis: selectedItem, estado: null }
        }).then(function successCallBack(response) {
            self.seller = response.data;
        }, function errorCallBack(response) { });
    }

    ////Seleccionar todos los Vendedores
    self.SelectAllChekboxesSellers = SelectAllChekboxesSellers;
    function SelectAllChekboxesSellers(selectAll) {
        checkedAllCombo(self.seller, selectAll);
    }

    self.CountSeller = function () {
        var coun = countComboBoxElements($scope.selectAllSeller, $scope.querySeller, self.seller);
        $scope.selectAllSeller = coun[0];
        $scope.querySeller = coun[1];
    }

    //ESQUEMAS CLIENTES
    self.GetEsquemas = GetEsquemas();
    function GetEsquemas(selectedItem) {
        (selectedItem == undefined ? null : selectedItem.replace(/\+/g, "%2B"));

        $http({
            url: url + '/API/GetReportFilters/GetSchemes',
            method: 'GET',
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-Type': 'application/json'
            },
            params: { cedis: selectedItem, state: 1, types: 1, levels: 2, schemesID: 'CAN' }
        }).then(function successCallBack(response) {
            self.schemes = response.data;
        }, function errorCallBack(response) { });
    }

    ////Seleccionar todos los Esquemas de CLientes
    self.SelectAllChekboxesSchemesCli = SelectAllChekboxesSchemesCli;
    function SelectAllChekboxesSchemesCli(selectAll) {
        checkedAllCombo(self.schemes, selectAll);
    }

    self.CountSchemesClients = function () {
        var coun = countComboBoxElements($scope.selectAllSchemesCli, $scope.querySchemesCli, self.schemes);
        $scope.selectAllSchemesCli = coun[0];
        $scope.querySchemesCli = coun[1];
    }

    //ESQUEMAS PRODUCTOS
    self.GetEsquemasPro = GetEsquemasPro();
    function GetEsquemasPro(selectedItem) {
        (selectedItem == undefined ? null : selectedItem.replace(/\+/g, "%2B"));

        $http({
            url: url + '/API/GetReportFilters/GetSchemes',
            method: 'GET',
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-Type': 'application/json'
            },
            params: { cedis: selectedItem, state: 1, types: 2, levels: 2, schemesID: null }
        }).then(function successCallBack(response) {
            self.schemesPro = response.data;
        }, function errorCallBack(response) { });

    }

    ////Seleccionar todos los Esquemas de Productos
    self.SelectAllChekboxesSchemesPro = SelectAllChekboxesSchemesPro;
    function SelectAllChekboxesSchemesPro(selectAll) {
        checkedAllCombo(self.schemesPro, selectAll);
    }

    self.CountSchemesProducts = function () {
        var coun = countComboBoxElements($scope.selectAllSchemesPro, $scope.querySchemesPro, self.schemesPro);
        $scope.selectAllSchemesPro = coun[0];
        $scope.querySchemesPro = coun[1];
    }

    //Llenar Clientes
    self.clients = getClientes();
    self.getClientes = getClientes;
    function getClientes(selectedItem) {
        (selectedItem == undefined ? null : selectedItem.replace(/\+/g, "%2B"));

        var routeString = "";
        angular.forEach(self.routes, function (item) {
            if (item.Checked == true) {
                routeString = routeString + item.Clave + ",";
            }
        });

        var routeFilter = routeString.substring(0, routeString.length - 1);

        $http({
            url: url + '/API/GetReportFilters/GetClients',
            method: 'GET',
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-Type': 'application/json'
            },
            params: { cedis: selectedItem, state: null, clientScheme: null, routes: routeFilter }
        }).then(function successCallBack(response) {
            self.clients = response.data;
        }, function errorCallBack(response) { });
    }

    ////Seleccionar todos los Clientes
    self.SelectAllChekboxesClients = SelectAllChekboxesClients;
    function SelectAllChekboxesClients(selectAll) {
        checkedAllCombo(self.clients, selectAll);
    }

    self.CountClients = function () {
        var coun = countComboBoxElements($scope.selectAllClients, $scope.queryClients, self.clients);
        $scope.selectAllClients = coun[0];
        $scope.queryClients = coun[1];
    }

    self.ResetValues = function myfunction() {
        checkedAllCombo(self.schemesPro, false);
    }

    self.GroupFilter1 = function (valor) {
        if (valor == "Rutas") {
            self.RoutesFilters = true;
            self.SellersFilters = false;
            $scope.selectAllSeller = false;
            checkedAllCombo(self.seller, false);
        }
        else if (valor = "Vendedores") {
            self.SellersFilters = true;
            self.RoutesFilters = false;
            $scope.selectAllRoutes = false;
            checkedAllCombo(self.routes, false);
        }
    }

    self.GroupFilter2 = function (valor) {
        if (valor == "Clientes") {
            self.ClientsFilters = true;
            self.SchemesClientsFilters = false;
            $scope.selectAllClients = false;
            checkedAllCombo(self.clients, false);
        }
        else if (valor = "EsquemaClientes") {
            self.SchemesClientsFilters = true;
            self.ClientsFilters = false;
            $scope.selectAllSchemesCli = false;
            checkedAllCombo(self.schemes, false);
        }
    }

    $scope.$watch("ctrl.date1", function () {
        if (self.State == "Igual") {
            self.showErrorForm = false;
        }
    });

    //Envia formulario completo
    function SubmitForm(Cedis) {

        var CEDI = (Cedis == undefined ? "" : Cedis);
        var nomCedi = (Cedis == undefined ? "" : self.selectedItem.Nombre);
        var vendedores = GetArrayValues(self.seller);

        if (self.State == undefined) {
            muestraError("Seleccione rango de fechas");
        }
        else if (self.State == 'Entre' && (self.date1 == undefined || self.date2 == undefined)) {
            muestraError("Seleccione las fechas");
        }
        else if (self.State == 'Entre' && (self.date1 > self.date2)) {
            muestraError("Rango de fechas erróneo");
        }
        else if (self.date1 == undefined || self.date1 == "") {
            muestraError("Seleccione una fecha");
        }
        else {
            var data = {
                nombreReport: self.titulo,
                CEDIS: CEDI,
                NameCEDIS: nomCedi,
                StatusDate: self.State,
                InitialDate: moment(self.date1).format('YYYY-MM-DD'),
                FinalDate: moment(self.date2).format('YYYY-MM-DD'),
                Sellers: vendedores,
                VAVClave: self.VAVClave,
                ReportName: self.titulo,
            }

            $http.post(url + '/Reports/SetCondition', data, { ignoreLoadingBar: true })
                .then(function () {
                    window.open(url + '/Reports/Ver');
                    cfpLoadingBar.complete();
                });
        }
    }

    function GetArrayValues(Array) {
        var newArray = [];
        angular.forEach(Array, function (item) {
            if (item.Checked == true) {
                newArray.push({ Clave: item.Clave, Nombre: item.Nombre, Checked: item.Checked, Disabled: item.Disabled });
            }
        });
        return newArray;
    }

    //MUESTRA UN MENSAJE DE ERROR
    function muestraError(cadena) {
        self.ErrorEnviar = cadena;
        self.showErrorForm = true;
        cfpLoadingBar.complete();
    }

    //Seleccionar todos los elementos del Combo (TRUE OR FALSE)
    function checkedAllCombo(Array, selectAll) {
        if (selectAll == undefined) {
            selectAll = false;
        }
        angular.forEach(Array, function (item) {
            item.Checked = selectAll;
        });
    }

    function countComboBoxElements(modelAll, queryFilter, Array) {
        queryFilter = "";
        var count = 0;
        angular.forEach(Array, function (item) {
            if (item.Checked) {
                count++;
            }
        });
        if (count != Array.length) {
            modelAll = false;
        } else if (count == Array.length) {
            modelAll = true;
        }
        return [modelAll, queryFilter];
    }
}]);