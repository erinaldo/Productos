app.controller('r010DevolucionesYCambiosDelClienteController', ['$scope', '$mdToast', '$q', '$timeout', 'valorReferencia', '$http', 'cfpLoadingBar', function ($scope, $mdToast, $q, $timeout, valorReferencia, $http, cfpLoadingBar) {
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
        }, function errorCallBack(response) {
        });
    }

    self.QuerySearch = function (query) {
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

    self.ShowItems = function (selectedItem) {
        self.showErrorForm = false;
        if (selectedItem == undefined) {
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
        }, function errorCallBack(response) {
        });
    }

    //Estado del rango de fecha
    self.OnSelectChange = function (state, date) {
        self.showErrorForm = false;
        if (date == 0) {
            self.date1 = self.minDate;
        }
        self.date2 = self.date1;
        if (state == 'Entre') {
            self.showSelect = true;
        } else {
            self.showSelect = false;
        }
    }

    //Llenar Rutas
    self.GetRoutes = function (selectedItem) {
        if (selectedItem != undefined) {
            self.ResetItems();
            $scope.queryRoutes = '';
            self.routes = undefined;
            $scope.selectAllRoutes = false;
            $http({
                url: url + '/API/GetReportFilters/GetRoutes?cedis=' + selectedItem.replace(/\+/g, "%2B"),
                method: 'GET',
                headers: {
                    Authorization: window.sessionStorage.getItem('Token'),
                    'Content-Type': 'application/json'
                },
            }).then(function successCallBack(response) {
                self.routes = response.data;
            }, function errorCallBack(response) {
            });
        }
    }

    self.CountRoutes = function () {
        self.ResetItems();
        $scope.queryRoutes = '';
        var count = 0;
        var routes = [];
        angular.forEach(self.routes, function (item) {
            if (item.Checked) {
                count++;
                routes.push(item.Clave);
            }
        });
        if (count != 0) {
            if (count != self.routes.length) {
                self.GetCustomers(null, self.routes);
                $scope.selectAllRoutes = false;
            } else if (count == self.routes.length) {
                self.GetCustomers(null, self.routes);
                $scope.selectAllRoutes = true;
            }
        }
    }

    //Seleccionar todas las Rutas
    self.SelectAllCheckboxesRoutes = function (selectAllRoutes) {
        self.ResetItems();
        $scope.queryRoutes = '';
        if (selectAllRoutes == undefined || selectAllRoutes == false) {
            angular.forEach(self.routes, function (item) {
                item.Checked = true;
            });
            self.GetCustomers(null, self.routes);
        } else {
            angular.forEach(self.routes, function (item) {
                item.Checked = false;
            });
            self.customers = undefined;
        }
    }

    self.ResetItems = function () {
        self.showErrorForm = false;
        self.customers = undefined;
        $scope.queryCustomerSchemes = '';
        $scope.queryCustomers = '';
        $scope.selectAllCustomers = false;
        $scope.EsquemaId = undefined;
    }

    //Llenar Esquemas de Clientes
    self.GetCustomerSchemes = function (selectedItem) {
        if (selectedItem != undefined) {
            $scope.queryCustomerSchemes = '';
            $scope.queryCustomers = '';
            $scope.selectAllCustomers = false;
            $http({
                url: url + '/API/GetReportFilters/GetSchemes?cedis=' + selectedItem.replace(/\+/g, "%2B") + '&types=' + 1 + '&levels=' + '0,1,2',
                method: 'GET',
                headers: {
                    Authorization: window.sessionStorage.getItem('Token'),
                    'Content-Type': 'application/json'
                }
            }).then(function successCallBack(response) {
                self.customerSchemes = response.data;
            }, function errorCallBack(response) {
            });
        }
    }

    //Llenar Clientes
    self.GetCustomers = function (clientScheme, routes) {
        self.showErrorForm = false;
        self.customers = undefined;
        $scope.queryCustomerSchemes = '';
        $scope.queryCustomers = '';
        $scope.selectAllCustomers = false;
        $http.post(url + '/Reports/GetObjectString', {
            Object: GetArrayValues(routes)
        }).then(function (dataRoutes) {
            $http({
                url: url + '/API/GetReportFilters/GetClients?clientScheme=' + clientScheme + '&routes=' + dataRoutes.data,
                method: 'GET',
                headers: {
                    Authorization: window.sessionStorage.getItem('Token'),
                    'Content-Type': 'application/json'
                },
            }).then(function successCallBack(response) {
                self.customers = response.data;
            }, function errorCallBack(response) {
            });
        });
    }

    //Seleccionar todos los Clientes
    self.SelectAllCheckboxesCustomers = function (selectAllCustomers) {
        $scope.queryCustomers = '';
        if (selectAllCustomers == undefined || selectAllCustomers == false) {
            angular.forEach(self.customers, function (item) {
                item.Checked = true;
            });
        }
        else {
            angular.forEach(self.customers, function (item) {
                item.Checked = false;
            });
        }
    }

    self.CountCustomers = function () {
        $scope.queryCustomers = '';
        var count = 0;
        angular.forEach(self.customers, function (item) {
            if (item.Checked) {
                count++;
            }
        });
        if (count != self.customers.length) {
            $scope.selectAllCustomers = false;
        } else if (count == self.customers.length) {
            $scope.selectAllCustomers = true;
        }
    }

    //Llenar Esquemas de Productos
    self.GetProductSchemes = function (selectedItem) {
        self.showErrorForm = false;
        self.productSchemes = undefined;
        $scope.queryProductSchemes = '';
        $scope.queryProducts = '';
        $scope.selectAllProductSchemes = false;
        $http({
            url: url + '/API/GetReportFilters/GetSchemes?cedis=' + selectedItem.replace(/\+/g, "%2B") + '&types=' + 2 + '&levels=' + '0,1,2',
            method: 'GET',
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-Type': 'application/json'
            },
        }).then(function successCallBack(response) {
            self.productSchemes = response.data;
        }, function errorCallBack(response) {
        });
    }

    //Seleccionar todos los Productos
    self.SelectAllCheckboxesProductSchemes = function (selectAllProductSchemes) {
        $scope.queryProductSchemes = '';
        $scope.queryProducts = '';
        if (selectAllProductSchemes == undefined || selectAllProductSchemes == false) {
            angular.forEach(self.productSchemes, function (item) {
                item.Checked = true;
            });
            self.GetProducts(self.productSchemes);
        }
        else {
            angular.forEach(self.productSchemes, function (item) {
                item.Checked = false;
            });
            self.products = undefined;
        }
    }

    self.CountProductSchemes = function () {
        $scope.queryProductSchemes = '';
        $scope.queryProducts = '';
        var count = 0;
        angular.forEach(self.productSchemes, function (item) {
            if (item.Checked) {
                count++;
            }
        });
        if (count != 0) {
            if (count != self.productSchemes.length) {
                self.GetProducts(self.productSchemes);
                $scope.selectAllProductSchemes = false;
            } else if (count == self.productSchemes.length) {
                self.GetProducts(self.productSchemes);
                $scope.selectAllProductSchemes = true;
            }
        }
    }

    //Llenar Productos
    self.GetProducts = function (productSchemes) {
        self.showErrorForm = false;
        self.products = undefined;
        $scope.queryProductSchemes = '';
        $scope.queryProducts = '';
        $scope.selectAllProducts = false;
        $http.post(url + '/Reports/GetObjectString', {
            Object: GetArrayValues(productSchemes)
        }).then(function (dataProductSchemes) {
            $http({
                url: url + '/API/GetReportFilters/GetProducts?productSchemes=' + dataProductSchemes.data,
                method: 'GET',
                headers: {
                    Authorization: window.sessionStorage.getItem('Token'),
                    'Content-Type': 'application/json'
                },
            }).then(function successCallBack(response) {
                self.products = response.data;
            }, function errorCallBack(response) {
            });
        });
    }

    //Seleccionar todos los Productos
    self.SelectAllCheckboxesProducts = function (selectAllProducts) {
        $scope.queryProducts = '';
        if (selectAllProducts == undefined || selectAllProducts == false) {
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
        if (count != self.products.length) {
            $scope.selectAllProducts = false;
        } else if (count == self.products.length) {
            $scope.selectAllProducts = true;
        }
    }

    function GetArrayValues(Array, otro) {
        var newArray = [];
        angular.forEach(Array, function (item) {
            if (otro != undefined) {
                if (item.Clave == otro) {
                    newArray.push({ Clave: item.Clave, Nombre: item.Nombre, Checked: true, Disabled: false });
                }
            } else {
                if (item.Checked == true) {
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
        var rutas = [];
        var clientes = [];
        var esquemasProductos = [];
        var productos = [];
        if (!$scope.selectAllRoutes) {
            rutas = GetArrayValues(self.routes);
        }

        if (!$scope.selectAllCustomers) {
            clientes = GetArrayValues(self.customers);
        }

        if (!$scope.selectAllProductSchemes) {
            esquemasProductos = GetArrayValues(self.productSchemes);
        }

        if (!$scope.selectAllProducts) {
            productos = GetArrayValues(self.products);
        }

        if (rutas.length <= 0 && !$scope.selectAllRoutes) {
            ErrorMessage("*Seleccione una Ruta");
        } else if (self.State == undefined) {
            ErrorMessage("*Seleccione rango de fechas");
        } else if (self.State == 'Entre' && (self.date1 == undefined || self.date2 == undefined)) {
            ErrorMessage("*Seleccione las fechas");
        } else if (self.State == 'Entre' && (self.date2 <= self.date1)) {
            ErrorMessage("*Rango de fechas erróneo");
        } else if (self.date1 == undefined) {
            ErrorMessage("*Seleccione la fecha");
        } else {
            rutas = ($scope.selectAllRoutes ? null : rutas);
            clientes = ($scope.selectAllCustomers ? null : clientes);
            productos = ($scope.selectAllProducts ? null : productos);
            esquemasProductos = ($scope.selectAllCustomers ? null : esquemasProductos);
            var data = {
                CEDIS: self.selectedItem.Clave,
                NameCEDIS: self.selectedItem.Nombre,
                ReportName: self.titulo,
                InitialDate: moment(self.date1).format('YYYY-MM-DD'),
                FinalDate: moment(self.date2).format('YYYY-MM-DD'),
                VAVClave: self.VAVClave,
                Routes: rutas,
                Customers: clientes,
                ProductSchemes: esquemasProductos,
                Products: productos,
            }
            $http.post(url + '/Reports/SetCondition', data, { ignoreLoadingBar: true })
                .then(function () {
                    window.open(url + '/Reports/Ver');
                    cfpLoadingBar.complete();
                });
        }
    }
}]);