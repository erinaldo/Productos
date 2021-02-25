(function () {
    angular
        .module('eRouteApp')
        .controller('informeVentasROVController', informeVentasROVController)
    informeVentasROVController.$inject = ['$scope', '$http', '$mdToast', '$q', '$timeout', 'NgMap', 'cfpLoadingBar', '$filter', "menuServices", "reportServices", "valorReferencia"];

    function informeVentasROVController($scope, $http, $mdToast, $q, $timeout, NgMap, cfpLoadingBar, $filter, menuServices, reportServices, valorReferencia) {
        var url = window.sessionStorage.getItem('URL');
        var self = this;
        self.showList = false;
        self.showSelect = undefined;
        self.nShowLists = nShowLists;
        self.selectedItem = undefined;
        self.OnSelectChange = OnSelectChange;
        self.minDate = new Date();
        self.SubmitForm = SubmitForm;
        self.date1 = undefined;
        self.VAVClave = undefined;
        self.ReportType = false;
        
        

        $scope.Group1 = "Rutas";
        self.RoutesFilters = true;
        self.SellersFilters = false;
        $scope.Group2 = "EsquemaClientes";
        self.SchemesClientsFilters = true;
        self.ClientsFilters = false;
        
        var Todasrutas = false;
        //var TodosClientes = false;

        $scope.EstablecerReporte = function (VAVClave) {
            valorReferencia.obtenerValorClave('REPORTEW', VAVClave, function (result) {
                self.titulo = result[0].Descripcion;
            });
        }


        //$scope.InicializarValores = function (VAVClave) {

        //    valorReferencia.obtenerValorClave('REPORTEW', VAVClave, function (result) {
        //        self.titulo = result[0].Descripcion;
        //    });

            

        //    //self.getAllClientes();
        //}

        

        //Llenar CEDIS
        self.cedis = GetCEDIS();
        self.querySearch = querySearch;
        function GetCEDIS() {
            $http({
                url: url + '/API/GetCedis',
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
                var dis = cedis.display;
                var lowercaseDispley = dis.toLowerCase();
                return (lowercaseDispley.indexOf(lowercaseQuery) === 0);
            };
        }

        //Fechas
        self.State = undefined;
        self.dateState = GetDates();
        function GetDates() {
            $http({
                url: url + '/API/GetModel/GetDateStatus',
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

            //if (selectedItem == undefined) {
            //    selectedItem = null;
            //}
            //else if (selectedItem != undefined) {
            //    selectedItem = selectedItem.replace(/\+/g, "%2B");
            //}

            //console.log("CEDI: " + selectedItem);
            $http({
                url: url + '/API/GetModel/GetRoutes',
                method: 'GET',
                headers: {
                    Authorization: window.sessionStorage.getItem('Token'),
                    'Content-Type': 'application/json'
                },
                params: { cedis: selectedItem, estado: null, type: "1,3" }
            }).then(function successCallBack(response) {
                self.routes = response.data;
                //console.log("RUTAS");
                //console.log(self.routes);
            }, function errorCallBack(response) { });
        }

        ////    LLENAR RUTAS
        //self.routes = GetRoutes();
        //self.GetRoutes = GetRoutes;
        //function GetRoutes(selectedItem, estado) {

        //    if (selectedItem == undefined) {
        //        selectedItem = null;
        //    }
        //    else if (selectedItem != undefined) {
        //        selectedItem = selectedItem.replace(/\+/g, "%2B");
        //    }

            
        //    $http({
        //        url: url + '/api/GetRoutes',
        //        method: 'GET',
        //        headers: {
        //            Authorization: window.sessionStorage.getItem('Token'),
        //            'Content-Type': 'application/json'
        //        },
        //        params: { Cedis: selectedItem, inactivos: false }
        //    }).then(function successCallBack(response) {
        //        self.routes = response.data;
        //    }, function errorCallBack(response) {

        //    });
        //}

        ////Seleccionar todas las Rutas
        self.SelectAllChekboxesRoutes = SelectAllChekboxesRoutes;
        function SelectAllChekboxesRoutes(selectAll) {
            checkedAllCombo(self.routes, selectAll);


            //if (selectAll == undefined || selectAll == false) {
            //    //Todasrutas = true;
            //    angular.forEach(self.routes, function (item) {
            //        item.Checked = true;
            //    });
            //}

            //else {
            //    //Todasrutas = false;
            //    angular.forEach(self.routes, function (item) {
            //        item.Checked = false;
            //    });
            //}
            //self.getAllClientes = GetClients;
        }

        self.CountRoutes = function () {
            var coun = countComboBoxElements($scope.selectAllRoutes, $scope.queryRoute, self.routes);
            $scope.selectAllRoutes = coun[0];
            $scope.queryRoute = coun[1];
        }

        self.ResetItems = function () {
            self.showErrorForm = false;
            self.ListClients = null;
            $scope.querySchemes = '';
            $scope.queryClients = '';
            $scope.selectAllClients = false;
            //$scope.inactClients = false;
            $scope.IdEsquema = "";
        }

        ////LLENAR VENDEDORES
        self.seller = GETSeller();
        self.GETSeller = GETSeller;
        function GETSeller(selectedItem) {
            (selectedItem == undefined ? null : selectedItem.replace(/\+/g, "%2B"));
            //debugger;
            //if (selectedItem == undefined) {
            //    selectedItem = null;
            //}
            //else if (selectedItem != undefined) {
            //    selectedItem = selectedItem.replace(/\+/g, "%2B");
            //}

            $http({
                url: url + '/API/GetModel/GetSellers',
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

        ////    LLENAR VENDEDORES
        //self.seller = GETSeller();
        //self.GETSeller = GETSeller;
        //function GETSeller(selectedItem) {

        //    if (selectedItem == undefined) {
        //        selectedItem = null;
        //    }
        //    else if (selectedItem != undefined) {
        //        selectedItem = selectedItem.replace(/\+/g, "%2B");
        //    }

        //    $http({
        //        url: url + '/api/GETSeller',
        //        method: 'GET',
        //        headers: {
        //            Authorization: window.sessionStorage.getItem('Token'),
        //            'Content-Type': 'application/json'
        //        },
        //        params: { Cedis: selectedItem }
        //    }).then(function successCallBack(response) {
        //        self.seller = response.data;
        //    }, function errorCallBack(response) {

        //    });
        //}





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
        self.schemes = GetEsquemas();
        self.GetEsquemas = GetEsquemas();
        function GetEsquemas(selectedItem) {
            (selectedItem == undefined ? null : selectedItem.replace(/\+/g, "%2B"));

            //if (selectedItem == undefined) {
            //    selectedItem = null;
            //}
            //else if (selectedItem != undefined) {
            //    selectedItem = selectedItem.replace(/\+/g, "%2B");
            //}

            $http({
                url: url + '/API/GetModel/GetSchemes',
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



        ////    LLENAR ESQUEMAS
        //self.schemes = GetEsquemas();
        //self.GetEsquemas = GetEsquemas;
        //function GetEsquemas(selectedItem, estado) {

        //    if (selectedItem == undefined) {
        //        selectedItem = null;
        //    }
        //    else if (selectedItem != undefined) {
        //        selectedItem = selectedItem.replace(/\+/g, "%2B");
        //    }

        //    $http({
        //        url: url + '/api/GetClientScheme/ObtenerEsquemaClientes',
        //        method: 'GET',
        //        headers: {
        //            Authorization: window.sessionStorage.getItem('Token'),
        //            'Content-Type': 'application/json'
        //        },
        //        params: { cedis: selectedItem, estado: null, types: 1, levels: 2, schemesID: 'CAN' }
        //    }).then(function successCallBack(response) {
        //        self.schemes = response.data;
        //    }, function errorCallBack(response) {

        //    });
        //}













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
        self.schemesPro = GetEsquemasPro();
        self.GetEsquemasPro = GetEsquemasPro();
        function GetEsquemasPro(selectedItem) {
            (selectedItem == undefined ? null : selectedItem.replace(/\+/g, "%2B"));

            //if (selectedItem == undefined) {
            //    selectedItem = null;
            //}
            //else if (selectedItem != undefined) {
            //    selectedItem = selectedItem.replace(/\+/g, "%2B");
            //}

            $http({
                url: url + '/API/GetModel/GetSchemes',
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
                    routeString = routeString + item.Clave + "," ;
                }
            });

            var routeFilter = routeString.substring(0, routeString.length - 1);



            //if (selectedItem == undefined) {
            //    selectedItem = null;
            //}
            //else if (selectedItem != undefined) {
            //    selectedItem = selectedItem.replace(/\+/g, "%2B");
            //}

            //console.log("CEDI: " + selectedItem);
            $http({
                url: url + '/API/GetModel/GetClients',
                method: 'GET',
                headers: {
                    Authorization: window.sessionStorage.getItem('Token'),
                    'Content-Type': 'application/json'
                },
                params: { cedis: selectedItem, state: null, clientScheme: null, routes: routeFilter }
            }).then(function successCallBack(response) {
                self.clients = response.data;
                //console.log("RUTAS");
                //console.log(self.routes);
            }, function errorCallBack(response) { });
        }




        //  LLENAR CLIENTES
        //self.getAllClientes = GetClients;
        //self.clients = self.ListClients;
        //function GetClients(Routes) {
        //    selectedItem = self.selectedItem;
        //    if (selectedItem == undefined) {
        //        selectedItem = null;
        //    }
        //    else if (selectedItem != undefined) {
        //        selectedItem = selectedItem.replace(/\+/g, "%2B");
        //    }

        //    debugger;
        //    self.showErrorForm = false;
        //    self.clients = [];

        //    var esquemaId = "";

        //    angular.forEach(self.schemes, function (item) {
        //        if (item.Checked) {
        //            esquemaId = item.EsquemaID;
        //        }
        //    });

        //    var rutas = "";
        //    if (esquemaId == "") {
        //        esquemaId = "Ninguno";
        //    }
        //    $http.post(url + '/Reports/GetRoutesStiring', {
        //        Routes: Routes
        //    }).success(function (data, status, headers, config) {
        //        if (data.length == 0) {
        //            rutas = "Ninguna";
        //        } else {
        //            rutas = data;
        //        }
        //        if (!(self.showList == undefined)) {
        //            $http({
        //                url: url + '/api/GetClients/ObtenerListaClientes',
        //                method: 'GET',
        //                headers: {
        //                    Authorization: window.sessionStorage.getItem('Token'),
        //                    'Content-Type': 'application/json'
        //                },
        //                params: { IdEsquema: esquemaId, Routes: rutas, Cedis: selectedItem }
        //            }).then(function successCallBack(response) {
        //                self.clients = response.data;
        //            }, function errorCallBack(response) {
        //            });
        //        }
        //    }).error(function (error, status, headers, config) {
        //    });
        //}
















        ////Llenar Clientes filtrado por rutas
        //self.getAllClients = GetClients;
        //function GetClients(Routes) {
        //    debugger;
        //    self.showErrorForm = false;
        //    //var esquemaId = $scope.IdEsquema;
        //    var esquemaId = "";
        //    var rutas = "";
        //    if (esquemaId == "") {
        //        esquemaId = "Ninguno";
        //    }
        //    $http.post(url + '/Reports/GetRoutesStiring', {
        //        Routes: Routes
        //    }).success(function (data, status, headers, config) {
        //        if (data.length == 0) {
        //            rutas = "Ninguna";
        //        } else {
        //            rutas = data;
        //        }
        //        if (!(self.showList == undefined)) {
        //            $http({
        //                url: url + '/api/GetClients/ObtenerListaClientes?IdEsquema=' + esquemaId + "&Routes=" + rutas + '&Cedis=' + self.selectedItem.value,
        //                method: 'GET',
        //                headers: {
        //                    Authorization: window.sessionStorage.getItem('Token'),
        //                    'Content-Type': 'application/json'
        //                },
        //            }).then(function successCallBack(response) {
        //                self.clients = response.data;
        //            }, function errorCallBack(response) {
        //            });
        //        }
        //    }).error(function (error, status, headers, config) {
        //    });
        //}












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
            //alert($scope.selectedItem.value);
            checkedAllCombo(self.schemesPro, false);
            //GetEsquemasPro()
        }

        $scope.$watch("Ctrl.Group1", function () {
            if (self.Group1 == "Rutas") {
                console.log("Por Rutas");
            }
        });

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
            //console.log(valor);
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

        































        
        //self.filtroClientesPorEsquema = filtroClientesPorEsquema;
        //function filtroClientesPorEsquema() {
        //    GetClients(self.routes);
        //}





        

        

        //////Llenar Esquemas
        //self.schemes = GetSchemesClients();
        //self.GetSchemesClients = GetSchemesClients;
        //function GetSchemesClients(selectedItem, estado) {
        //    //console.log("inactRoutes: " + $scope.inactRoutes);
        //    if (selectedItem != undefined) {
        //        //console.log("CEDI: " + selectedItem);
        //        $http({
        //            url: url + '/api/GetClientScheme/ObtenerEsquemaClientes?cedis=' + selectedItem.replace(/\+/g, "%2B") + "&estado=" + "1",
        //            method: 'GET',
        //            headers: {
        //                Authorization: window.sessionStorage.getItem('Token'),
        //                'Content-Type': 'application/json'
        //            },
        //        }).then(function successCallBack(response) {
        //            self.schemes = response.data;
        //            //console.log("ESQUEMAS");
        //            //console.log(self.schemes);
        //        }, function errorCallBack(response) {

        //        });
        //    }
        //}

        //SELECCIONAR SOLO UN ESQUEMA
        //self.bloquearEsquemas = bloquearEsquemas;
        //function bloquearEsquemas() {
        //    //console.log("Dentro de la funcion bloquear");
        //    $scope.fillScheme = [];
        //    angular.forEach(self.schemes, function (item) {
        //        if (item.Checked == true) {
        //            $scope.fillScheme.push(item.Checked);
        //            //console.log("Item.Checked");
        //        }
        //    });

        //    if ($scope.fillScheme.length > 0) {
        //        //console.log("fillScheme > 0");
        //        //console.log(self.schemes);
        //        angular.forEach(self.schemes, function (item) {
        //            if (item.Checked == true) {
        //                item.Disabled = false;
        //                $scope.IdEsquema = item.EsquemaID;
        //                //console.log($scope.IdEsquema + " " + item.EsquemaID);
        //            }
        //            else {
        //                item.Disabled = true;
        //            }
        //        });
        //    }
        //    else if ($scope.fillScheme.length == 0) {
        //        angular.forEach(self.schemes, function (item) {
        //            item.Checked = false;
        //            item.Disabled = false;
        //            $scope.IdEsquema = "";
        //        });
        //    }
        //}



        $scope.$watch("ctrl.date1", function () {
            if (self.State == "Igual") {
                self.showErrorForm = false;
            }
        });

        //$scope.$watch("ctrl.date2", function () {
        //    if (self.State == "Entre") {
        //        self.showErrorForm = false;
        //    }

        //});

        //Estado del rango de fecha
        function OnSelectChange(state) {
            if (state == 'Entre') {
                self.showSelect = 'true';
            }
            else {
                self.showSelect = undefined;
            }
        }

        function nShowLists(cedi) {
            $scope.IdEsquema = "";
            if (cedi == undefined) {
                self.showList = undefined;
            }
            else {
                self.showList = 'true';
            }
        }

        

        //Seleccionar todos los Clientes
        //self.SelectAllChekboxesClients = SelectAllCheckboxesClients;
        //function SelectAllCheckboxesClients(selectAll) {
        //    if (selectAll == undefined || selectAll == false) {
        //        TodosClientes = true;
        //        angular.forEach(self.ListClients, function (item) {
        //            item.Checked = true;
        //        });
        //    }

        //    else {
        //        TodosClientes = false;
        //        angular.forEach(self.ListClients, function (item) {
        //            item.Checked = false;
        //        });
        //    }
        //}

        //Llenar Esquema Clientes
        //self.call = GetSchemeClients();
        //self.GetSchemeClients = GetSchemeClients();
        //function GetSchemeClients() {
        //    $http({
        //        url: url + '/api/GetClientScheme',
        //        method: 'GET',
        //        headers: {
        //            Authorization: window.sessionStorage.getItem('Token'),
        //            'Content-Type': 'application/json'
        //        },
        //    }).then(function successCallBack(response) {
        //        $scope.treedata = JSON.parse(response.data);
        //    }, function errorCallBack(response) {
        //    });
        //}

        //Llenar Clientes
        //self.getAllClientes = GetClients;
        //self.ListClients = self.ListClients;
        //function GetClients(Routes) {
        //    self.showErrorForm = false;
        //    self.ListClients = [];
        //    var esquemaId = $scope.IdEsquema;
        //    var rutas = "";
        //    if (esquemaId == "") {
        //        esquemaId = "Ninguno";
        //    }
        //    $http.post(url + '/Reports/GetRoutesStiring', {
        //        Routes: Routes
        //    }).success(function (data, status, headers, config) {
        //        if (data.length == 0) {
        //            rutas = "Ninguna";
        //        } else {
        //            rutas = data;
        //        }
        //        if (!(self.showList == undefined)) {
        //            $http({
        //                url: url + '/api/GetClients/ObtenerListaClientes?IdEsquema=' + esquemaId + "&Routes=" + rutas + '&Cedis=' + self.selectedItem.value,
        //                method: 'GET',
        //                headers: {
        //                    Authorization: window.sessionStorage.getItem('Token'),
        //                    'Content-Type': 'application/json'
        //                },
        //            }).then(function successCallBack(response) {
        //                self.ListClients = response.data;
        //            }, function errorCallBack(response) {
        //            });
        //        }
        //    }).error(function (error, status, headers, config) {
        //    });
        //}

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

        //Envia formulario completo
        function SubmitForm(Cedis, VAVClave) {

            var CEDI = (Cedis == undefined ? "" : Cedis);
            var nomCedi = (Cedis == undefined ? "" : self.selectedItem.display);
            var rutas = GetArrayValues(self.routes);
            var vendedores = GetArrayValues(self.seller);
            var EsquemaCli = GetArrayValues(self.schemes);
            var Clientes = GetArrayValues(self.clients);
            var EsquemaPro = GetArrayValues(self.schemesPro);

            //var rutas = [];
            //angular.forEach(self.routes, function (item) {
            //    if (item.Checked == true) {
            //        rutas.push({ RUTClave: item.RUTClave, Descripcion: item.Descripcion, Checked: item.Checked, Disabled: item.Disabled });
            //    }
            //});
            //var vendedores = []
            //angular.forEach(self.seller, function (item) {
            //    if (item.Checked == true) {
            //        vendedores.push({ VendedorId: item.VendedorId, Nombre: item.Nombre, Checked: item.Checked, Disabled: item.Disabled });
            //    }
            //});

            //var EsquemaCli = [];
            //angular.forEach(self.schemes, function (item) {
            //    if (item.Checked == true) {
            //        EsquemaCli.push({ EsquemaID: item.EsquemaID, Nombre: item.Nombre, Checked: item.Checked, Disabled: item.Disabled });
            //    }
            //});

            //var Clientes = [];
            //angular.forEach(self.clients, function (item) {
            //    if (item.Checked == true) {
            //        Clientes.push({ Clave: item.Clave, RazonSocial: item.Nombre, Checked: item.Checked, Disabled: item.Disabled });
            //    }
            //});

            //var EsquemaPro = [];
            //angular.forEach(self.schemesPro, function (item) {
            //    if (item.Checked == true) {
            //        EsquemaPro.push({ Clave: item.EsquemaID, Nombre: item.Nombre, Checked: item.Checked, Disabled: item.Disabled });
            //    }
            //});

            

            if (self.State == undefined) {
                muestraError("Seleccione rango de fechas");
            }
            else if (self.date1 == undefined) {
                muestraError("Seleccione una fecha");
            }
            else {
                if (Clientes.length > 0) {
                    self.ReportType = true;
                }

                var data = {
                    Cedis: CEDI,
                    nombreCedis: nomCedi,
                    dateStatus: self.State,
                    init: self.date1,
                    vavclave: self.VAVClave,
                    Routes: rutas,
                    Seller: vendedores,
                    Clientes: Clientes,
                    //Clientes: (EsquemaCli.length == 0 ? Clientes : EsquemaCli),
                    ClientsSchema: EsquemaCli,
                    ProductsSchema: EsquemaPro,
                    reportType: self.ReportType
                }

                $http.post(url + '/Reports/GetCondition1', data, { ignoreLoadingBar: true })
                .success(function (data, status, headers, config) {
                    window.open(url + "/Reports/Ver?VAVClave=" + self.VAVClave, "_blank");
                    cfpLoadingBar.complete();
                })
                .error(function (error, status, headers, config) {

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
    }
})();