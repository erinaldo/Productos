app.controller('r194VentasPorProductoController', ['$scope', 'valorReferencia', '$http', 'cfpLoadingBar', function ($scope, valorReferencia, $http, cfpLoadingBar) {
    var url = window.sessionStorage.getItem('URL');
    var self = this;
    self.showList = false;
    self.minDate = new Date();

    $scope.EstablecerReporte = function (VAVClave) {
        valorReferencia.obtenerValorClave('REPORTEW', VAVClave, function (result) {
            self.titulo = result[0].Descripcion;
            GetCEDIS();
        });
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
        });
    }

    self.QuerySearch = function (query) {
        var results = query ? self.cedis.filter(createFilterFor(query)) : self.cedis;
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

    self.ShowItems = function (selectedItem) {
        self.showErrorForm = false;
        if (selectedItem === undefined) {
            self.showList = false;
        } else {
            self.showList = true;
        }
    }

    //Fechas
    self.GetDates = function () {
        self.showErrorForm = false;
        self.State = undefined;
        self.date1 = undefined;
        self.date2 = undefined;
        self.showSelect = false;
        self.dateState = null;
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
            self.OnSelectChange(self.State, 0);
        });
    }

    //Estado del rango de fecha
    self.OnSelectChange = function (state, date) {
        self.showErrorForm = false;
        if (date === 0) {
            self.date1 = self.minDate;
        }
        if (state === 'Entre') {
            self.date2 = undefined;
            self.showSelect = true;
        } else {
            self.date2 = self.date1;
            self.showSelect = false;
        }
    }

    //Llenar Vendedores
    self.GetSellers = function (selectedItem, estado) {
        if (selectedItem !== undefined) {
            self.ResetItems();
            self.selectedSeller = undefined;
            $scope.querySeller = '';
            self.sellers = null;
            if (!$scope.inactSellers) {
                estado = 1;
            }
            $http({
                url: url + '/API/GetReportFilters/GetSellers?cedis=' + selectedItem.replace(/\+/g, "%2B") + "&estado=" + estado,
                method: 'GET',
                headers: {
                    Authorization: window.sessionStorage.getItem('Token'),
                    'Content-Type': 'application/json'
                },
            }).then(function successCallBack(response) {
                self.sellers = response.data;
            });
        }
    }

    self.ResetItems = function () {
        self.showErrorForm = false;
        self.clients = undefined;
        $scope.querySchemes = '';
        $scope.queryClients = '';
        $scope.selectAllClients = false;
        $scope.EsquemaId = undefined;
    }

    //Llenar Esquema Clientes
    self.GetSchemesClients = function (selectedItem) {
        if (selectedItem !== undefined) {
            $scope.querySchemes = '';
            $scope.queryClients = '';
            $scope.selectAllClients = false;
            $http({
                url: url + '/API/GetReportFilters/GetSchemes?cedis=' + selectedItem.replace(/\+/g, "%2B") + '&types=' + 1 + '&levels=' + '0,1,2',
                method: 'GET',
                headers: {
                    Authorization: window.sessionStorage.getItem('Token'),
                    'Content-Type': 'application/json'
                }
            }).then(function (response) {
                self.schemes = response.data;
            });
        }
    }

    //Llenar Clientes
    self.GetClients = function (clientScheme, sellers) {
        self.showErrorForm = false;
        self.clients = undefined;
        $scope.querySchemes = '';
        $scope.queryClients = '';
        $scope.selectAllClients = false;
        $http({
            url: url + '/API/GetReportFilters/GetClients?clientScheme=' + clientScheme + '&sellers=' + sellers,
            method: 'GET',
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-Type': 'application/json'
            },
        }).then(function (response) {
            self.clients = response.data;
        });
    }

    //Seleccionar todos los Clientes
    self.SelectAllCheckboxesClients = function (selectAll) {
        if (selectAll === undefined || selectAll === false) {
            angular.forEach(self.clients, function (item) {
                item.Checked = true;
            });
        }
        else {
            angular.forEach(self.clients, function (item) {
                item.Checked = false;
            });
        }
    }

    self.CountClients = function () {
        $scope.queryClients = '';
        var count = 0;
        angular.forEach(self.clients, function (item) {
            if (item.Checked) {
                count++;
            }
        });
        if (count !== self.clients.length) {
            $scope.selectAllClients = false;
        } else if (count === self.clients.length) {
            $scope.selectAllClients = true;
        }
    }

    //Llenar Productos
    self.GetProducts = function () {
        self.showErrorForm = false;
        self.products = undefined;
        $scope.queryProducts = '';
        $scope.selectAllProducts = false;
        $http({
            url: url + '/API/GetReportFilters/GetProducts',
            method: 'GET',
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-Type': 'application/json'
            },
        }).then(function successCallBack(response) {
            self.products = response.data;
        });
    }

    //Seleccionar todos los Productos
    self.SelectAllCheckboxesProducts = function (selectAllProducts) {
        $scope.queryProducts = '';
        if (selectAllProducts === undefined || selectAllProducts === false) {
            angular.forEach(self.products, function (item) {
                item.Checked = true;
            });
        }
        else {
            angular.forEach(self.products, function (item) {
                item.Checked = false;
            });
        }
    }

    self.CountProducts = function () {
        $scope.queryProducts = '';
        var count = 0;
        angular.forEach(self.products, function (item) {
            if (item.Checked) {
                count++;
            }
        });
        if (count !== self.products.length) {
            $scope.selectAllProducts = false;
        } else if (count === self.products.length) {
            $scope.selectAllProducts = true;
        }
    }

    function GetArrayValues(Array, otro) {
        var newArray = [];
        angular.forEach(Array, function (item) {
            if (otro !== undefined) {
                if (item.Clave === otro) {
                    newArray.push({ Clave: item.Clave, Nombre: item.Nombre, Checked: true, Disabled: false });
                }
            } else {
                if (item.Checked === true) {
                    newArray.push({ Clave: item.Clave, Nombre: item.Nombre, Checked: item.Checked, Disabled: item.Disabled });
                }
            }
        });
        return newArray;
    }

    self.startbar = function () {
        cfpLoadingBar.start();
    };

    function ErrorMessage(cadena) {
        self.ShowError = cadena;
        self.showErrorForm = true;
        cfpLoadingBar.complete();
    }

    //Envia formulario completo
    self.SubmitForm = function () {
        var clientes = [];
        if (!$scope.selectAllClients) {
            clientes = GetArrayValues(self.clients);
        }
        var productos = [];
        if (!$scope.selectAllProducts) {
            productos = GetArrayValues(self.products);
        }
        var vendedores = GetArrayValues(self.sellers, self.selectedSeller);
        if (self.selectedSeller === undefined) {
            ErrorMessage("*Seleccione un Vendedor");
        } else if (self.State === undefined) {
            ErrorMessage("*Seleccione rango de fechas");
        } else if (self.State === 'Entre' && (self.date1 === undefined || self.date2 === undefined)) {
            ErrorMessage("*Seleccione las fechas");
        } else if (self.State === 'Entre' && (self.date2 <= self.date1)) {
            ErrorMessage("*Rango de fechas erróneo");
        } else if (self.date1 === undefined) {
            ErrorMessage("*Seleccione la fecha");
        } else {
            clientes = ($scope.selectAllClients ? null : clientes);
            productos = ($scope.selectAllProducts ? null : productos);
            var data = {
                CEDIS: self.selectedItem.Clave,
                NameCEDIS: self.selectedItem.Nombre,
                ReportName: self.titulo,
                InitialDate: moment(self.date1).format('YYYY-MM-DD'),
                FinalDate: moment(self.date2).format('YYYY-MM-DD'),
                VAVClave: self.VAVClave,
                Customers: clientes,
                Products: productos,
                Sellers: vendedores,
                ObjectName: vendedores
            }
            $http.post(url + '/Reports/SetCondition', data, { ignoreLoadingBar: true })
            .then(function () {
                window.open(url + "/Reports/Ver");
                cfpLoadingBar.complete();
            });
        }
    }
}]);