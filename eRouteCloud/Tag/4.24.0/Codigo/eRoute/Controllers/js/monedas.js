var app = angular.module('monedas', ['valorReferencia', 'messageBox', 'ngResource', 'translation', 'defaultBox', 'ngMaterial', 'ngMessages']);

app.controller('MonedasCtrl', ["$scope", "$http", "$filter", 'valorReferencia', "messageBox", "translationService", "defaultBox", function ($scope, $http, $filter, valorReferencia, messageBox, translationService, defaultBox) {

    var url = window.sessionStorage.getItem('URL');
    translationService.getTranslation($scope);
    ObtenerMonedas();
    obtenerEstados();
    this.myDate = new Date();
    this.isOpen = false;

    //Ordenar las columnas de la tabla TERMINAL
    $scope.sort = function (keyname) {
        $scope.sortKey = keyname;
        $scope.reverse = !$scope.reverse;
    }
    //claves de acceso
    $scope.AsignarPermisoMoneda = function (Permiso, SoloLectura) {
        $scope.Permiso = Permiso;
        $scope.SoloLectura = SoloLectura;
    }

    //Vigencia
    $scope.SeleccionCl = function (Fecha, Usuario) {
        $scope.fe = Fecha;
        $scope.ad = Usuario;
    };

    //peticion para obtener datos SELECT(mostrando tabla)
    function ObtenerMonedas() {
        $http({
            url: url + '/api/Monedas/ObtenerMonedas',
            metohod: 'GET',
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-Type': 'application/json'
            }
        }).success(function (data, status) {
            $scope.cMonedas = data;
            var tam = $scope.cMonedas.length;
            $scope.tamPag = tamano(tam);
        }
            ).error(function (error, status) {
                $scope.error = { message: error, status: status };
            });
    }

    function obtenerEstados() {
        valorReferencia.obtenerValores('EDOREG', function (result) {
            $scope.edoreg = result;
        });
        valorReferencia.obtenerValores('CDGOMON', function (result) {
            $scope.cdgomon = result;
        });
    }

    //BotonGuardarCamiones
    $scope.GuardarMoneda = function () {
        if (!$scope.form.$valid) {
            $scope.form.submitted = true;
        } else {
            var moneda = {
                Nombre: $scope.Nombre,
                TipoCodigo: $scope.TipoCodigo,
                Simbolo: $scope.Simbolo,
                TipoEstado: $scope.TipoEstado,
                FechaInicial: $scope.FechaInicial,
                valor: $scope.valor,
                MUsuarioID: window.sessionStorage.getItem('USUId'),
                MonedaID: $scope.MonedaID
            };
            $http({
                url: url + '/api/Monedas/Grabar?moneda=' + moneda,
                method: 'post',
                data: JSON.stringify(moneda),
                dataType: "json",
                headers: {
                    Authorization: window.sessionStorage.getItem('Token'),
                    'Content-Type': 'application/json'
                },
            }).success(function (data, status) {
                if (data) {
                    window.location.href = '../Monedas/Index?Permiso=' + $scope.Permiso;
                } else {
                }
            }).error(function (error, status) { });
        }
    }
    //Editar
    $scope.EditarMonedas = function (TipoCodigo, Permiso, SoloLectura) {
        $scope.Permiso = Permiso;
        if (SoloLectura.toUpperCase() === "TRUE") {
            $scope.SoloLectura = true;
        } else {
            $scope.SoloLectura = false;
        }
        if (TipoCodigo !== "") {
            $http({
                url: url + '/api/Monedas/ObtenerValorMoneda?TipoCodigo=' + TipoCodigo,
                method: 'GET',
                headers: {
                    Authorization: window.sessionStorage.getItem('Token'),
                    'Content-Type': 'application/json'
                },
            }).success(function (data, status) {
                angular.forEach(data, function (it) {
                    $scope.Action = "Edit";
                    $scope.Nuevo = false;
                    $scope.Nombre = it.Nombre;
                    $scope.TipoCodigo = it.TipoCodigo;
                    $scope.Simbolo = it.Simbolo;
                    $scope.TipoEstado = it.TipoEstado;
                    $scope.FechaInicial = it.FechaInicial;
                    $scope.FechaInicial = new Date(it.FechaInicial);
                    $scope.valor = it.valor;
                    $scope.t2 = it.TipoCodigo;
                    $scope.MonedaID = it.MonedaID;
                    $scope.ValidarTipoEstado();
                });
            }).error(function (error, status) { });

        } else {
            $scope.Action = "Create";
            $scope.Nuevo = true;
            $scope.TipoEstado = "1";
            $scope.valor = "0.00";
            $scope.FechaInicial = new Date();
        }
    }

    //BotonCancelar
    $scope.ValidarCancelar = function () {
        if (!$scope.form.$pristine) {
            $scope.Action = "Cancel";
            messageBox.MostrarSiNo($scope.translation.XCancelar, $scope.translation.BP0002);
        } else {
            window.location.href = '../Monedas/Index?Permiso=' + $scope.Permiso;
            consol.log($scope.Permiso);
        }
    }

    //Mensaje YES NO
    $scope.AceptarYesNoMsgBox = function () {
        messageBox.Cerrar();
        if ($scope.Action == "Delete") {
            $http({
                url: url + '/api/Monedas/Eliminar?Placa=' + $scope.Placa,
                method: 'GET',
                headers: {
                    Authorization: window.sessionStorage.getItem('Token'),
                    'Content-Type': 'application/json'
                },
            }).success(function (data, status) {
                window.location.href = '../Monedas/Index?Permiso=' + $scope.Permiso;
            }).error(function (error, status) { });
        } else if ($scope.Action == "Cancel") {
            window.location.href = '../Monedas/Index?Permiso=' + $scope.Permiso;
        }
    }

    //BtnVigencias
    $scope.VigenciaMoneda = function () {
        var TipoCodigo = $scope.TipoCodigo;
        defaultBox.Mostrar('Vigencias de Tipo de Cambio', 'otro', 'VigenciaMonedasBox');
        $http({
            url: url + '/api/Monedas/ObtenerVigenciaMonedas?TipoCodigo=' + TipoCodigo,
            metohod: 'GET',
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-Type': 'application/json'
            }
        }).success(function (data, status) {
            $scope.cVigenciaM = data;
        }).error(function (error, status) { $scope.error = { message: error, status: status }; });
    }

    //Valida que la moneda no este asignada a la configuracion general del sistema
    $scope.ValidarTipoEstado = function () {
        var codigo = $scope.TipoCodigo;
        $http({
            url: url + '/api/Monedas/ValidarTipoEstado?codigo=' + codigo,
            method: 'get',
            headers: {
                Authorization: window.sessionStorage.getItem("Token"),
                'Content-Type': 'Aplication/json'
            }
        }).success(function (data, state) {
            if (data == true) {
                $scope.MsgEstado = data;
            }
        }).error(function (error, state) { })
    };

    function tamano(tam) {
        var tamPag = 0;
        if (tam <= 100)
            tamPag = 20;
        else if (tam <= 1000 && tam > 100)
            tamPag = Math.floor(tam / 3);
        else if (tam <= 10000 && tam > 1000)
            tamPag = Math.floor(tam / 10);
        else if (tam <= 100000 && tam > 10000)
            tamPag = Math.floor(tam / 40);
        else if (tam <= 200000 && tam > 100000)
            tamPag = Math.floor(tam / 70);
        else if (tam <= 300000 && tam > 200000)
            tamPag = Math.floor(tam / 80);
        else if (tam <= 400000 && tam > 300000)
            tamPag = Math.floor(tam / 90);
        else if (tam <= 500000 && tam > 400000)
            tamPag = Math.floor(tam / 100);
        else if (tam <= 600000 && tam > 500000)
            tamPag = Math.floor(tam / 60);
        else if (tam <= 1000000 && tam > 600000)
            tamPag = Math.floor(tam / 40);
        else
            tamPag = Math.floor(tam / 40);
        return tamPag;
    }
}]);

//Validando si ya esta moneda creada
app.directive('validarCodigoMoneda', validarCodigoM);
function validarCodigoM($http, $q, $timeout) {
    return {
        restrict: 'A',
        require: 'ngModel',
        link: function ($scope, element, attr, ngModel) {
            ngModel.$asyncValidators.codigoMonedaRepetido = function (modelValue, viewValue) {
                var deferred = $q.defer();
                if ($scope.Action == 'Create') {
                    var codigo = viewValue;
                    var url = window.sessionStorage.getItem('URL');
                    $http({
                        url: url + '/api/Monedas/ValidarCodigoMoneda?codigo=' + codigo,
                        method: 'GET',
                        headers: {
                            Authorization: window.sessionStorage.getItem('Token'),
                            'Content-Type': 'application/json'
                        },
                    }).success(function (data, status) {
                        if (data == false) {
                            deferred.resolve();
                        } else {
                            deferred.reject();
                        }
                    }).error(function (error, status) { deferred.resolve(); });
                } else {
                    deferred.resolve();
                }
                return deferred.promise;
            }
        }
    }
}

app.directive('validarTipoCodigoCambiado', ValidarTC);
function ValidarTC($http, $q, $timeout) {
    return {
        restrict: 'A',
        require: 'ngModel',
        link: function ($scope, element, attr, ngModel) {
            element.bind('focus', function () {
                ngModel.$asyncValidators.tCodigoCambiado = function (modelValue, viewValue) {
                    var deferred = $q.defer();
                    var Nombre = $scope.Nombre;
                    var Simbolo = $scope.Simbolo;
                    var TipoEstado = $scope.TipoEstado;
                    var TipoCodigo = modelValue;
                    if (ngModel.$pristine == false && $scope.Action == "Edit") {
                        var url = window.sessionStorage.getItem('URL');
                        $http({
                            url: url + '/api/Monedas/ValidarCcambiado?TipoCodigo=' + TipoCodigo + '&Nombre=' + Nombre + '&Simbolo=' + Simbolo + '&TipoEstado=' + TipoEstado,
                            method: 'GET',
                            headers: {
                                Authorization: window.sessionStorage.getItem('Token'),
                                'Content-Type': 'application/json'
                            },
                        }).success(function (data, status) {
                            if (data == false) {
                                deferred.resolve();
                            } else {
                                deferred.reject();
                            }
                        }).error(function (error, status) { deferred.resolve(); });
                    } else {
                        deferred.resolve();
                    }
                    return deferred.promise;
                }
            });
        }
    }
}

//ValidandoFehca Min  
app.directive('validarFechaMinMax', validarfechaMin);
function validarfechaMin($http, $q, $timeout) {
    return {
        restrict: 'A',
        require: 'ngModel',
        link: function ($scope, element, attr, ngModel) {
            element.ready(function () {
                ngModel.$asyncValidators.fechaMin = function (modelValue, viewValue) {
                    var deferred = $q.defer();
                    var Fecha = new Date(modelValue);
                    var FechaActual = new Date();
                    var Consultado = attr.consu;
                    Fecha.setHours(0, 0, 0, 0);
                    FechaActual.setHours(0, 0, 0, 0);
                    if (Fecha >= FechaActual) {

                        deferred.resolve();
                    } else {
                        deferred.reject();
                    } return deferred.promise;
                }
            });
        }
    }
}

//Solo Numeros
app.directive('validNumber', function () {
    return {
        require: '?ngModel',
        link: function (scope, element, attrs, ngModelCtrl) {
            if (!ngModelCtrl) {
                return;
            }
            ngModelCtrl.$parsers.push(function (val) {
                if (angular.isUndefined(val)) {
                    var val = '';
                }
                var clean = val.replace(/[^-0-9\.]/g, '');
                var negativeCheck = clean.split('-');
                var decimalCheck = clean.split('.');
                if (!angular.isUndefined(negativeCheck[1])) {
                    negativeCheck[1] = negativeCheck[1].slice(0, negativeCheck[1].length);
                    clean = negativeCheck[0] + '-' + negativeCheck[1];
                    if (negativeCheck[0].length > 0) {
                        clean = negativeCheck[0];
                    }
                }
                if (!angular.isUndefined(decimalCheck[1])) {
                    decimalCheck[1] = decimalCheck[1].slice(0, 2);
                    clean = decimalCheck[0] + '.' + decimalCheck[1];
                }
                if (val !== clean) {
                    ngModelCtrl.$setViewValue(clean);
                    ngModelCtrl.$render();
                }
                return clean;
            });
            element.bind('keypress', function (event) {
                if (event.keyCode === 32) {
                    event.preventDefault();
                }
            });
        }
    };
});

//asignacion de Formato Moneda $0.00
app.controller('myMon', function ($scope) {
}).directive('bToCury', function ($filter) {
    return {
        scope: {
            amount: '='
        },
        link: function (scope, el, attrs) {
            el.bind('focus', function () {
                el.val($filter('number')(scope.amount));
            });
            el.bind('input', function () {
                scope.amount = el.val();
                scope.$apply();
            });
            el.bind('blur', function () {
                el.val($filter('number')(scope.amount, 2));
            });
        }
    }
});

//Fecha
app.directive('datepicker', function () {
    return {
        link: function (scope, el, attr) {
            $(el).datepicker({
                onSelect: function (dateText) {
                }
            });
        }
    };
});