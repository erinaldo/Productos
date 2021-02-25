app.controller('efectividadPorRutaController', ['$scope', '$mdToast', '$q', '$timeout', 'valorReferencia', '$http', 'cfpLoadingBar', function ($scope, $mdToast, $q, $timeout, valorReferencia, $http, cfpLoadingBar) {
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

    //Llenar CEDIS
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

    //Llenar Rutas
    self.GetRoutes = function (selectedItem, estado) {
        if (selectedItem != undefined) {
            self.showErrorForm = false;
            $scope.queryRoute = '';
            self.routes = null;
            $scope.selectAllRoutes = false;
            if (!$scope.inactRoutes || $scope.inactRoutes == undefined) {
                estado = 1;
            }
            $http({
                url: url + '/API/GetReportFilters/GetRoutes?cedis=' + selectedItem + "&estado=" + estado,
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
        }, function errorCallBack(response) {
        });
    }

    //Estado del rango de fecha
    self.OnSelectChange = function (state, date) {
        self.showErrorForm = false;
        if (date == 0) {
            self.date1 = self.minDate;
        }
        if (state == 'Entre') {
            self.date2 = undefined;
            self.showSelect = true;
        } else {
            self.date2 = self.date1;
            self.showSelect = false;
        }
    }

    self.SelectAllCheckboxesRoutes = function (selectAll) {
        self.showErrorForm = false;
        $scope.queryRoute = '';
        if (selectAll == undefined || selectAll == false) {
            angular.forEach(self.routes, function (item) {
                item.Checked = true;
            });
        } else {
            angular.forEach(self.routes, function (item) {
                item.Checked = false;
            });
        }
    }

    self.CountRoutes = function () {
        self.showErrorForm = false;
        $scope.queryRoute = '';
        var count = 0;
        angular.forEach(self.routes, function (item) {
            if (item.Checked) {
                count++;
            }
        });
        if (count != self.routes.length) {
            $scope.selectAllRoutes = false;
        } else if (count == self.routes.length) {
            $scope.selectAllRoutes = true;
        }
    }

    self.DetalladoGeneral = function () {
        if (self.ReportType) {
            self.DetGen = "Detallado";
        } else {
            self.DetGen = "General";
        }
    }

    self.startbar = function () {
        cfpLoadingBar.start();
    };

    function ErrorMessage(cadena) {
        self.ShowError = cadena;
        self.showErrorForm = true;
        cfpLoadingBar.complete();
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
    //envia el formulario completo
    function SubmitForm(Cedis, dateStatus, Routes, Clientes, pvEsFecha, campoFecha) {
        var countRoutes;
        angular.forEach(ctrl.routes, function (item) {

            if (item.Checked == true) {
                countRoutes++;
            }
        });

        var countSellers;
        angular.forEach(ctrl.sellers, function (item) {

            if (item.Checked == true) {
                countSellers++;
            }
        });

        if (ctrl.selectedItem == undefined || ctrl.selectedItem == null) {
            ctrl.selectedItem = {};
        }

        if (countRoutes <= 0 || countSellers <= 0) {
            alert("Seleccione ruta o vendedor");
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
                nombreReport: ctrl.titulo,
                Cedis: ctrl.selectedItem.value,
                nombreCedis: ctrl.selectedItem.display,
                dateStatus: ctrl.State,
                Routes: Routes,
                Clientes: Clientes,
                Seller: ctrl.sellers,
                init: moment(ctrl.date1).format('YYYY-MM-DD'),
                end:moment(ctrl.date2).format('YYYY-MM-DD'),
                vavclave: ctrl.VAVClave,
                reportType: ctrl.ReportType
            }

            $http.post(url + '/Reports/GetCondition', data, { ignoreLoadingBar: true })
                .then(function () {
                    window.open(url + '/Reports/Ver');
                    cfpLoadingBar.complete();
                });
        }
    }
}]);