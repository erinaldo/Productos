app.controller('r266ListaDePreciosGenericoController', ['$scope', '$mdToast', '$q', '$timeout', 'valorReferencia', '$http', 'cfpLoadingBar', function ($scope, $mdToast, $q, $timeout, valorReferencia, $http, cfpLoadingBar) {
    var url = window.sessionStorage.getItem('URL');
    var self = this;
    self.date1 = '';

    $scope.EstablecerReporte = function (VAVClave) {
        valorReferencia.obtenerValorClave('REPORTEW', VAVClave, function (result) {
            self.titulo = result[0].Descripcion;
            GetPriceList();
        });
    }

    self.onChange = function (cbState) {
        if (!cbState) {
            self.date1 = '';
        } else {
            self.date1 = cbState;
        }
    };

    //Llenar Lista De Precios
    function GetPriceList() {
        $scope.ListaPreciosId = undefined;
        $scope.queryPriceList = '';
        self.priceList = null;
        $http({
            url: url + '/API/GetReportFilters/GetPriceList',
            method: 'GET',
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-Type': 'application/json'
            },
        }).then(function successCallBack(response) {
            self.priceList = response.data;
        }, function errorCallBack() {
        });
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
        var listaprecios = GetArrayValues(self.priceList, $scope.ListaPreciosId);
        if ($scope.ListaPreciosId === undefined) {
            ErrorMessage("*Seleccione una Lista De Precios");
        } else {
            var data = {
                dataListObject: [listaprecios],
                dataList: [self.date1],
                ReportName: self.titulo,
                VAVClave: self.VAVClave
            }
            $http.post(url + '/Reports/SetCondition', data, { ignoreLoadingBar: true })
            .then(function () {
                window.open(url + "/Reports/Ver");
                cfpLoadingBar.complete();
            });
        }
    }
}]);