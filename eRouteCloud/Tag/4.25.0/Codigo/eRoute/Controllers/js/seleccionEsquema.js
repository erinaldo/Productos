var app = angular.module('seleccionEsquema', []);

app.factory('seleccionEsquema', ["$http", "$q", function ($http, $q) {

    return {
        Cargar: function (Tipo) {
            var deferred = $q.defer();
            var url = window.sessionStorage.getItem('URL');

            $http({
                url: url + '/API/Segmento/ObtenerEsquemasActivos?Tipo=' + Tipo,
                method: 'GET',
                headers: {
                    Authorization: window.sessionStorage.getItem('Token'),
                    'Content-Type': 'application/json'
                },
            }).then(function successCallback(response) {
                deferred.resolve(response.data);
            }, function errorCallback(response) {
                deferred.reject(response.error);
            });
            return deferred.promise;
        },
        Seleccionar: function () {
            //var sOptions = 'dialogWidth:500px; dialogHeight:500px; dialogLeft:100px; dialogTop:100px; status:no; scroll:yes; help:no; resizable:yes';

            //Open dialog
            $("#SeleccionEsquema").modal('show'); //, null, sOptions);
        }
    }
}]);