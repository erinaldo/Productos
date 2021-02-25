app.factory('reportServices', function ($http) {
    return {
        GetCEDI: function () {
            var url = window.sessionStorage.getItem('URL');
            return $http({
                url: url + '/API/GetReportFilters/GetCEDIS',
                method: 'GET',
                headers: {
                    Authorization: window.sessionStorage.getItem('Token'),
                    'Content-Type': 'application/json'
                },
                params: { USUId: window.sessionStorage.getItem('USUId') }
            }).then(function (response) {
                return response.data;
            }).catch(function (error) {
                console.log('Error: ' + error.data + ' Status: ' + error.status);
            });
        },
        GetRUTA: function (parameters) {
            var url = window.sessionStorage.getItem('URL');
            return $http({
                url: url + '/API/GetReportFilters/GetRoutes' + parameters,
                method: 'GET',
                headers: {
                    Authorization: window.sessionStorage.getItem('Token'),
                    'Content-Type': 'application/json'
                }
            }).then(function (response) {
                return response.data;
            }).catch(function (error) {
                console.log('Error: ' + error.data + ' Status: ' + error.status);
            });
        },
        GetVENDEDOR: function (parameters) {
            var url = window.sessionStorage.getItem('URL');
            return $http({
                url: url + '/API/GetReportFilters/GetSellers' + parameters,
                method: 'GET',
                headers: {
                    Authorization: window.sessionStorage.getItem('Token'),
                    'Content-Type': 'application/json'
                }
            }).then(function (response) {
                return response.data;
            }).catch(function (error) {
                console.log('Error: ' + error.data + ' Status: ' + error.status);
            });
        },
        GetESQCLI: function (parameters) {
            var url = window.sessionStorage.getItem('URL');
            return $http({
                url: url + '/API/GetReportFilters/GetSchemes' + parameters + '&types=' + 1 + '&levels=' + '0,1,2',
                method: 'GET',
                headers: {
                    Authorization: window.sessionStorage.getItem('Token'),
                    'Content-Type': 'application/json'
                }
            }).then(function (response) {
                return response.data;
            }).catch(function (error) {
                console.log('Error: ' + error.data + ' Status: ' + error.status);
            });
        },
        GetCLIENTE: function (parameters) {
            var url = window.sessionStorage.getItem('URL');
            return $http({
                url: url + '/API/GetReportFilters/GetClients' + parameters,
                method: 'GET',
                headers: {
                    Authorization: window.sessionStorage.getItem('Token'),
                    'Content-Type': 'application/json'
                }
            }).then(function (response) {
                return response.data;
            }).catch(function (error) {
                console.log('Error: ' + error.data + ' Status: ' + error.status);
            });
        },
        GetESQPROD: function (parameters) {
            var url = window.sessionStorage.getItem('URL');
            return $http({
                url: url + '/API/GetReportFilters/GetSchemes' + parameters + '&types=' + 2 + '&levels=' + '0,1,2',
                method: 'GET',
                headers: {
                    Authorization: window.sessionStorage.getItem('Token'),
                    'Content-Type': 'application/json'
                }
            }).then(function (response) {
                return response.data;
            }).catch(function (error) {
                console.log('Error: ' + error.data + ' Status: ' + error.status);
            });
        },
        GetPRODUCTO: function (parameters) {
            var url = window.sessionStorage.getItem('URL');
            return $http({
                url: url + '/API/GetReportFilters/GetProducts' + parameters,
                method: 'GET',
                headers: {
                    Authorization: window.sessionStorage.getItem('Token'),
                    'Content-Type': 'application/json'
                }
            }).then(function (response) {
                return response.data;
            }).catch(function (error) {
                console.log('Error: ' + error.data + ' Status: ' + error.status);
            });
        },
        GetENCUESTA: function () {
            var url = window.sessionStorage.getItem('URL');
            return $http({
                url: url + '/API/GetReportFilters/GetPolls',
                method: 'GET',
                headers: {
                    Authorization: window.sessionStorage.getItem('Token'),
                    'Content-Type': 'application/json'
                }
            }).then(function (response) {
                return response.data;
            }).catch(function (error) {
                console.log('Error: ' + error.data + ' Status: ' + error.status);
            });
        },
        GetSUPERVISOR: function (parameters) {
            var url = window.sessionStorage.getItem('URL');
            return $http({
                url: url + '/API/GetReportFilters/GetSupervisors' + parameters,
                method: 'GET',
                headers: {
                    Authorization: window.sessionStorage.getItem('Token'),
                    'Content-Type': 'application/json'
                }
            }).then(function (response) {
                return response.data;
            }).catch(function (error) {
                console.log('Error: ' + error.data + ' Status: ' + error.status);
            });
        },
        GetFECHA: function () {
            var url = window.sessionStorage.getItem('URL');
            return $http({
                url: url + '/API/GetReportFilters/GetDateStatus',
                method: 'GET',
                headers: {
                    Authorization: window.sessionStorage.getItem('Token'),
                    'Content-Type': 'application/json'
                }
            }).then(function (response) {
                return response.data;
            }).catch(function (error) {
                console.log('Error: ' + error.data + ' Status: ' + error.status);
            });
        },
        GetLISTPRE: function () {
            var url = window.sessionStorage.getItem('URL');
            return $http({
                url: url + '/API/GetReportFilters/GetPriceList',
                method: 'GET',
                headers: {
                    Authorization: window.sessionStorage.getItem('Token'),
                    'Content-Type': 'application/json'
                }
            }).then(function (response) {
                return response.data;
            }).catch(function (error) {
                console.log('Error: ' + error.data + ' Status: ' + error.status);
            });
        },
        GetPRECIOVIG: function () {
            response = {
                Clave: '',
                Nombre: 'Mostrar Solo Precios Vigentes',
                Otro: '',
                Extra: '',
                Checked: '',
                Disabled: ''
            };
            return response;
        }
    }
});