app.controller('r131LiquidacionController', ['$scope', 'valorReferencia', '$http', 'cfpLoadingBar', function ($scope, valorReferencia, $http, cfpLoadingBar) {
    var url = window.sessionStorage.getItem('URL');
    var self = this;
    self.todayDate = new Date();

    $scope.EstablecerReporte = function (VAVClave) {
        valorReferencia.obtenerValorClave('REPORTEW', VAVClave, function (result) {
            self.titulo = result[0].Descripcion;
            self.GetSellers();
            self.GetDates();
        });
    }

    //Fechas
    self.GetDates = function () {
        self.showErrorForm = false;
        self.State = undefined;
        self.date = undefined;
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
            self.date = self.todayDate;
        });
    }

    //Llenar Vendedores
    self.GetSellers = function (state) {
        self.selectedSeller = undefined;
        $scope.querySeller = '';
        self.sellers = null;
        if (!$scope.inactSellers) {
            state = 1;
        }
        $http({
            url: url + '/API/GetReportFilters/GetSellers?estado=' + state,
            method: 'GET',
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-Type': 'application/json'
            },
        }).then(function successCallBack(response) {
            self.sellers = response.data;
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
        var sellers = GetArrayValues(self.sellers, self.selectedSeller);
        if (self.selectedSeller === undefined) {
            ErrorMessage("*Seleccione un Vendedor");
        } else if (self.date === undefined) {
            ErrorMessage("*Seleccione una fecha");
        } else {
            var data = {
                ReportName: self.titulo,
                InitialDate: moment(self.date).format('YYYY-MM-DD'),
                VAVClave: self.VAVClave,
                Sellers: sellers,
                ObjectName: sellers
            }
            $http.post(url + '/Reports/SetCondition', data, { ignoreLoadingBar: true })
            .then(function () {
                window.open(url + "/Reports/Ver");
                cfpLoadingBar.complete();
            });
        }
    }
}]);