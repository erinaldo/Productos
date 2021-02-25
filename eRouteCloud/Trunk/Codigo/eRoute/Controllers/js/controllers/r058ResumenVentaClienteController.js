app.controller('r058ResumenVentaClienteController', ['$scope', 'valorReferencia', '$http', 'cfpLoadingBar', function ($scope, valorReferencia, $http, cfpLoadingBar) {
    var url = window.sessionStorage.getItem('URL');
    var self = this;
    var countRoute = false;
    self.showCEDI = false;
    self.showList = false;
    self.showSelect = undefined;
    self.OnSelectChange = OnSelectChange;
    self.nShowLists = nShowLists;
    self.selectedItem = undefined;
    self.minDate = undefined;
    self.maxDate = new Date();
    self.GETSeller = GETSeller;
    self.SubmitForm = SubmitForm;
    self.State = undefined;
    self.date1 = undefined;
    self.date2 = undefined;
    self.VAVClave = undefined;

    $scope.EstablecerReporte = function (VAVClave) {
        valorReferencia.obtenerValorClave('REPORTEW', VAVClave, function (result) {
            self.titulo = result[0].Descripcion;
            self.showCEDI = (self.titulo == undefined ? false : true);
            self.VAVClave = VAVClave;
        });
        GetCEDIS();
        GetDates();
        //GetRoutes();
    }

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

    self.querySearch = function querySearch(query) {
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

    function nShowLists(cedi) {
        self.showList = (cedi == undefined ? false : true);
    }

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
            self.State = self.dateState[0].Nombre;
        }, function errorCallBack(response) {
        });
    }

    function OnSelectChange(state) {
        if (state == 'Entre') {
            self.showSelect = 'true';
        }
        else {
            self.showSelect = undefined;
            self.date2 = undefined;
        }
    }

    self.OnChangeRutVen = function (selectedItem) {
        self.ResetItems();
        if (self.selectedSwitchRutVen) {
            self.selectAllRoutes = false;
            self.queryRoute = '';
            self.routes = undefined;
            self.textSwitchRutVen = 'Ruta';
            self.GETSeller(selectedItem);
        } else {
            self.selectedSeller = undefined;
            self.querySeller = '';
            self.inactSellers = false;
            self.sellers = undefined;
            self.textSwitchRutVen = 'Vendedor';
            self.GetRoutes(selectedItem);
        }
    }

    self.ResetItems = function () {
        self.showErrorForm = false;
        self.querySchemes = '';
        self.selectedClientScheme = undefined;
    }

    $scope.$watch("ctrl.date1", function () {
        if (self.date1 != undefined) {
            self.minDate = new Date(self.date1.getFullYear(), (self.date1.getMonth()), (self.date1.getDate() + 1));
        }
        if (self.State == "Entre" && self.date2 != undefined) {
            if (self.date1 >= self.date2) {
                self.date2 = undefined;
            }
        }
        if (self.showErrorForm) {
            self.showErrorForm = false;
        }
    });

    $scope.$watch("ctrl.date2", function () {
        if (self.State == "Entre" && self.date1 != undefined) {
            self.showErrorForm = false;
        }

    });

    $scope.$watch("VendedorId", function () {
        if (self.showErrorForm && $scope.VendedorId != undefined) {
            self.showErrorForm = false;
        }
    });

    function GETSeller(selectedItem) {
        if (selectedItem != undefined) {
            $http({
                url: url + '/API/GetReportFilters/GetSellers',
                method: 'GET',
                headers: {
                    Authorization: window.sessionStorage.getItem('Token'),
                    'Content-Type': 'application/json'
                },
                params: { cedis: selectedItem }
            }).then(function successCallBack(response) {
                self.seller = response.data;
            }, function errorCallBack(response) {

            });
        }
    }

    self.GetRoutes = GetRoutes;
    function GetRoutes(selectedItem) {
        $http({
            url: url + '/API/GetReportFilters/GetRoutes?cedis=' + selectedItem.replace(/\+/g, "%2B"),
            method: 'GET',
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-Type': 'application/json'
            },
        }).then(function successCallBack(response) {
            self.routes = response.data;
        }, function errorCallBack(response) { });
    }

    self.GetSchemesClients = function (selectedItem) {
        self.selectedClientScheme = undefined;
        self.querySchemes = '';
        self.queryClients = '';
        self.selectAllClients = false;
        $http({
            url: url + '/API/GetReportFilters/GetSchemes?cedis=' + selectedItem.replace(/\+/g, '%2B') + '&types=' + 1 + '&levels=' + '0,1,2',
            method: 'GET',
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-Type': 'application/json'
            }
        }).then(function successCallBack(response) {
            self.schemes = response.data;
        });
    }

    self.SelectAllChekboxesRoutes = SelectAllChekboxesRoutes;
    function SelectAllChekboxesRoutes(selectAll) {
        checkedAllCombo(self.routes, selectAll);
    }

    self.CountRoutes = function () {
        self.showErrorForm = false;
        var coun = countComboBoxElements($scope.selectAllRoutes, $scope.queryRoute, self.routes);
        $scope.selectAllRoutes = coun[0];
        $scope.queryRoute = coun[1];
    }

    self.resetSeller = function (value) {
        if (value != undefined && countRoute) {
            $scope.VendedorId = undefined;
        }
    }

    self.startbar = function () {
        cfpLoadingBar.start();
    };

    function SubmitForm() {
        var vendedor = [];
        var Esquemas = [];
        var rutas = GetArrayValues(self.routes);

        if (self.VendedorId != undefined) {
            vendedor = GetArrayValues(self.seller, self.VendedorId);
        }

        if (self.selectedClientScheme != undefined) {
            Esquemas = GetArrayValues(self.schemes, self.selectedClientScheme);
        }

        if (rutas.length <= 0 && self.VendedorId == undefined) {
            muestraError("Seleccione una Ruta o Vendedor");
        }
        else if (self.State == undefined) {
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
                ReportName: self.titulo,
                VAVClave: self.VAVClave,
                CEDIS: self.selectedItem.Clave,
                NameCEDIS: self.selectedItem.Nombre,
                StatusDate: self.State,
                InitialDate: moment(self.date1).format('YYYY-MM-DD'),
                FinalDate: self.date2 ? moment(self.date2).format('YYYY-MM-DD') : self.date2,
                Sellers: vendedor,
                Routes: rutas,
                CustomerSchemes: Esquemas
            }
            $http.post(url + '/Reports/SetCondition', data, { ignoreLoadingBar: true })
                .then(function () {
                    window.open(url + "/Reports/Ver");
                    cfpLoadingBar.complete();
                });
        }
    }

    function muestraError(cadena) {
        self.ErrorEnviar = cadena;
        self.showErrorForm = true;
        cfpLoadingBar.complete();
    }

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
        if (count > 0) {
            countRoute = true;
        } else {
            countRoute = false;
        }
        return [modelAll, queryFilter];
    }

    function GetArrayValues(Array, Clave) {
        var newArray = [];
        angular.forEach(Array, function (item) {
            if (Clave == undefined) {
                if (item.Checked == true) {
                    newArray.push({ Clave: item.Clave, Nombre: item.Nombre, Checked: item.Checked, Disabled: item.Disabled });
                }
            }
            else {
                if (item.Clave == Clave) {
                    newArray.push({ Clave: item.Clave, Nombre: item.Nombre, Checked: true, Disabled: false });
                }
            }
        });
        return newArray;
    }
}]);