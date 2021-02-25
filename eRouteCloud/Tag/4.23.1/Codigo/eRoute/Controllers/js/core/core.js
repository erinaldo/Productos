(function () {
    'use strict';
    angular
        .module('eRouteApp', ['ngMaterial', 'ngRoute', 'ngMap', 'angularTreeview', 'angular-loading-bar', 'ngAnimate', 'loginApp', 'angularUtils.directives.dirPagination', 'mensaje', 'translation', 'perfil', 'usuario', 'almacen', 'terminales', 'camiones', 'subEmpresa', 'producto', 'listasdeprecios', 'segmento', 'monedas', 'vendedores', 'rutas', 'cliente', 'frecuenciadeRutas', 'configParametro', 'promociones', 'mdbMensaje', 'folios', 'cargas', 'configuracionRecibo','frecuencias'])
        .config(['cfpLoadingBarProvider', function (cfpLoadingBarProvider) {
            cfpLoadingBarProvider.includeSpinner = false;
            cfpLoadingBarProvider.includeBar = true;
        }])
})();