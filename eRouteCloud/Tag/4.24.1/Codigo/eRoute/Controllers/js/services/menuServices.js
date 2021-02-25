angular
    .module("eRouteApp")
    .factory("menuServices", menuServices)
menuServices.$inject = ['$http']
function menuServices($http) {
    vm = this;

    var funciones = {
        logout: logout,
        LogoutDelete: LogoutDelete,
        getReportList: getReportList,
        getMapList: getMapList
    };
    return funciones


    function logout(LogoutModel) {
        var url = window.sessionStorage.getItem('URL');
        return $http({
            url: url + '/api/Logout',
            method: 'POST',
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-Type': 'application/json'
            },
            data: JSON.stringify(LogoutModel)
        });
    }

    function LogoutDelete() {
        var url = window.sessionStorage.getItem('URL');
        return $http({
            method: "GET",
            url: url + 'Login/DeleteSession'
        });
    }

    function getReportList() {
        var url = window.sessionStorage.getItem('URL');
        return $http({
            url: url + '/api/FilterReports',
            method: 'GET',
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-Type': 'application/json'
            },
            params: { PERClave: window.sessionStorage.getItem('PERClave'), USUId: window.sessionStorage.getItem('USUId') }
        });
    }

    function getMapList() {
        var url = window.sessionStorage.getItem('URL');
        return $http({
            url: url + '/api/GetMapList',
            method: 'GET',
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-Type': 'application/json'
            }
        });
    }

}
