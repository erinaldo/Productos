app.controller('r190KardexDeExistenciaController', ['valorReferencia', '$http', 'cfpLoadingBar', function (valorReferencia, $http, cfpLoadingBar) {
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

    function ErrorMessage(message) {
        self.ShowError = message;
        self.showErrorForm = true;
        cfpLoadingBar.complete();
    }

    //Envia formulario completo
    self.Submit = function () {
        cfpLoadingBar.start();
       
        var data = {
            CEDIS: self.selectedItem.Clave,
            NameCEDIS: self.selectedItem.Nombre,
            ReportName: self.title,
            VAVClave: self.VAVClave
        }
        $http.post(url + '/Reports/SetCondition', data, { ignoreLoadingBar: true })
        .then(function () {
            window.open(url + "/Reports/Ver");
            cfpLoadingBar.complete();
        });
    }
}]);