angular
    .module("eRouteApp")
    .factory("reportServices", reportServices)
reportServices.$inject = ['$http']
function reportServices($http) {
    vm = this;

    var funciones = {
        getCedis: getCedis,
        getRoutes: getRoutes,
        getAllRoutes: getAllRoutes,
        getSellers: getSellers,
        getDates: getDates,
        getSchemeClients: getSchemeClients,
        getRoutesString: getRoutesString,
        getClientes: getClientes
    };
    return funciones


    function getCedis() {
        var url = window.sessionStorage.getItem('URL');
        return $http({
            url: url + '/api/GetCedis',
            method: 'GET',
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-Type': 'application/json'
            },
            params: {USUId : window.sessionStorage.getItem('USUId')}
        });
    }

    function getRoutes(selectedItem) {
        if (selectedItem == undefined)
            selectedItem = "";
        var url = window.sessionStorage.getItem('URL');
        return $http({
            url: url + '/api/GetRoutes?Cedis=' + selectedItem.replace(/\+/g, "%2B"),
            method: 'GET',
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-Type': 'application/json'
            }
        });
    }

    function getAllRoutes() {
        var url = window.sessionStorage.getItem('URL');
        return $http({
            url: url + '/api/GetAllRoutes',
            method: 'GET',
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-Type': 'application/json'
            }
        });
    }

    function getSellers(selectedItem) {
        if (selectedItem == undefined)
            selectedItem = "";
        var url = window.sessionStorage.getItem('URL');
        return $http({
            url: url + '/api/GetSeller?Cedis=' + selectedItem.replace(/\+/g, "%2B"),
            method: 'GET',
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-Type': 'application/json'
            }
        });
    }

    function getDates() {
        var url = window.sessionStorage.getItem('URL');
        return $http({
            url: url + '/api/GetDateStatus',
            method: 'GET',
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-Type': 'application/json'
            }
        });
    }

    function getSchemeClients() {
        var url = window.sessionStorage.getItem('URL');
        return $http({
            url: url + '/api/GetClientScheme',
            method: 'GET',
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-Type': 'application/json'
            }
        });
    }

    function getRoutesString() {
        var url = window.sessionStorage.getItem('URL');
        return $http.post(url + '/Reports/GetRoutesStiring', {
            Routes: Routes
        });
    }

    function getClientes() {
        var url = window.sessionStorage.getItem('URL');
        return $http({
            url: url + '/api/GetClients?Id=' + $scope.abc.currentNode.id + "&Routes=" + data + '&Cedis=' + "",
            method: 'GET',
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-Type': 'application/json'
            }
        });
    }
}