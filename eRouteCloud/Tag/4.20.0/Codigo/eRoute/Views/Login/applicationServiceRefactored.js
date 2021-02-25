(function () {
    'use strict';
    angular
        .module('menuRoute')
        .factory("applicationsService", applicationsService)

    function applicationsService($http, rootUrl) {

        var getApplications = function () {
            return $http.get(rootUrl + "/api/applications");
        };

        return {
            getApplications: getApplications,
        };
    };


})();