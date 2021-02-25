app.controller('r064TiemposEnRutaController', ['valorReferencia', '$http', 'cfpLoadingBar', function (valorReferencia, $http, cfpLoadingBar) {
    var url = window.sessionStorage.getItem('URL');
    var self = this;
    self.todayDate = new Date();

    self.StartReport = function (VAVClave) {
        valorReferencia.obtenerValorClave('REPORTEW', VAVClave, function (result) {
            self.title = result[0].Descripcion;
            self.VAVClave = VAVClave;
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

    //Fechas
    self.GetDates = function () {
        self.showErrorForm = false;
        self.State = undefined;
        self.startDate = undefined;
        self.endDate = undefined;
        self.showSelect = false;
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
            self.OnSelectChange(self.State, 0);
        });
    }

    //Estado del rango de fecha
    self.OnSelectChange = function (state, date) {
        self.showErrorForm = false;
        if (date === 0) {
            self.startDate = self.todayDate;
        }
        if (state === 'Entre') {
            self.showSelect = true;
        } else {
            self.showSelect = false;
        }
        self.endDate = self.startDate;
    }

    //Llenar Vendedores
    self.GetSellers = function (selectedItem, state) {
        if (selectedItem !== undefined) {
            self.selectedSeller = undefined;
            self.querySeller = '';
            self.sellers = undefined;
            if (!self.inactSellers) {
                state = 1;
            }
            $http({
                url: url + '/API/GetReportFilters/GetSellers?cedis=' + selectedItem.replace(/\+/g, "%2B") + "&state=" + state,
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
        } else if (self.State === undefined) {
            ErrorMessage("*Seleccione rango de fechas");
        } else if (self.State === 'Entre' && (self.startDate === undefined || self.endDate === undefined)) {
            ErrorMessage("*Seleccione las fechas");
        } else if (self.State === 'Entre' && (self.endDate <= self.startDate)) {
            ErrorMessage("*Rango de fechas erróneo");
        } else if (self.startDate === undefined) {
            ErrorMessage("*Seleccione la fecha");
        } else {
            var data = {
                CEDIS: self.selectedItem.Clave,
                NameCEDIS: self.selectedItem.Nombre,
                ReportName: self.title,
                InitialDate: moment(self.startDate).format('YYYY-MM-DD'),
                FinalDate: moment(self.endDate).format('YYYY-MM-DD'),
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