app.controller('r103VentaDiarioController', ['valorReferencia', '$http', 'cfpLoadingBar', function (valorReferencia, $http, cfpLoadingBar) {
    var url = window.sessionStorage.getItem('URL');
    var self = this;
    self.todayDate = new Date();

    self.StartReport = function (VAVClave) {
        valorReferencia.obtenerValorClave('REPORTEW', VAVClave, function (result) {
            self.title = result[0].Descripcion;
            self.VAVClave = VAVClave;
            GetSellers();
            GetDates();
        });
    }

    //Fechas
    function GetDates() {
        self.showErrorForm = false;
        self.State = undefined;
        self.startDate = undefined;
        self.dateState = undefined;
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
            self.startDate = self.todayDate;
        });
    }

    //Llenar Vendedores
    function GetSellers(state) {
        self.selectedSeller = undefined;
        self.querySeller = '';
        self.sellers = undefined;
        if (!self.inactSellers) {
            state = 1;
        }
        $http({
            url: url + '/API/GetReportFilters/GetSellers?state=' + state,
            method: 'GET',
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-Type': 'application/json'
            },
        }).then(function successCallBack(response) {
            self.sellers = response.data;
        });
    }

    function ErrorMessage(message) {
        self.ShowError = message;
        self.showErrorForm = true;
        cfpLoadingBar.complete();
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

    //Envia formulario completo
    self.Submit = function () {
        cfpLoadingBar.start();
        var sellers = GetArrayValues(self.sellers, self.selectedSeller);
        if (self.selectedSeller === undefined) {
            ErrorMessage("*Seleccione un Vendedor");
        } else if (self.startDate === undefined) {
            ErrorMessage("*Seleccione la fecha");
        } else {
            var data = {
                ReportName: self.title,
                InitialDate: moment(self.startDate).format('YYYY-MM-DD'),
                VAVClave: self.VAVClave,
                Sellers: sellers,
                ObjectName: sellers,
                Budget: self.budget
            }
            $http.post(url + '/Reports/SetCondition', data, { ignoreLoadingBar: true })
            .then(function () {
                window.open(url + "/Reports/Ver");
                cfpLoadingBar.complete();
            });
        }
    }
}]);