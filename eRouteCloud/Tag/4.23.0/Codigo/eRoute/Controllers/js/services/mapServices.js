angular
    .module("eRouteApp")
    .factory("mapServices", mapServices)
menuServices.$inject = ['$http']
function mapServices($http) {
    vm = this;

    var funciones = {
        getMapData: getMapData,
        getEsquemas:getEsquemas,
        getProductos:getProductos
    };
    return funciones


    function getMapData(data) {
        var url = window.sessionStorage.getItem('URL');
        return $http({
            url: url + '/Maps/getMapData',
            method: 'POST',
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-Type': 'application/json'
            },
            data: {
                Cedis:data.Cedis,
                dateStatus: data.dateStatus,
                Routes: data.Routes,
                init: data.init,
                end: data.end,
                vavclave: data.vavclave,
                tipo: data.tipo,
                esquemaId: data.esquemaId,
                productoClave: data.productoClave
            }
        });
    }

    function getEsquemas() {
        var url = window.sessionStorage.getItem('URL');
        return $http({
            url: url + '/Maps/getEsquemas',
            method: 'GET',
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-Type': 'application/json'
            }
        });
    }

    function getProductos() {
        var url = window.sessionStorage.getItem('URL');
        return $http({
            url: url + '/Maps/getProductos',
            method: 'GET',
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-Type': 'application/json'
            }
        });
    }

}
