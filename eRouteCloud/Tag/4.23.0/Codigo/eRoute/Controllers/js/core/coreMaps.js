(function () {
    'use strict';
    angular
        .module('eRouteApp', ['ngMaterial', 'ngRoute', 'ngMap', 'angularTreeview', 'angular-loading-bar', 'ngAnimate', 'loginApp'])
        .config(['cfpLoadingBarProvider', function (cfpLoadingBarProvider) {
            cfpLoadingBarProvider.includeSpinner = false;
            cfpLoadingBarProvider.includeBar = true;
        }])
})();