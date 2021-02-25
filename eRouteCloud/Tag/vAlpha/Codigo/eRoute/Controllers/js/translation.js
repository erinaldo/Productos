var app = angular.module('translation', ['ngResource', 'configuracion']);

app.service('translationService', ['$resource', 'lenguaje', function ($resource, lenguaje) {
    this.getTranslation = function ($scope) {

        lenguaje.get().then(function (data) {
            var language = data;

            var path = 'Translations/Translation_' + language + '.json';
            var ssid = 'languajeID_' + language;

            if (sessionStorage) {
                if (sessionStorage.getItem(ssid)) {
                    $scope.translation = JSON.parse(sessionStorage.getItem(ssid));
                } else {
                    $resource(path).get(function (data) {
                        $scope.translation = data;
                        sessionStorage.setItem(ssid, JSON.stringify($scope.translation));
                    });
                };
            } else {
                $resource(path).get(function (data) {
                    $scope.translation = data;
                });
            }
        });
        
    };
}]);