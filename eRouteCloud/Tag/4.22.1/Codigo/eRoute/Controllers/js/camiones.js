var app = angular.module('camiones', ['valorReferencia', 'messageBox', 'ngResource', 'translation']);

app.controller('CamionCtrl', ["$scope", "$http", 'valorReferencia', "messageBox", "translationService", function ($scope, $http, valorReferencia, messageBox, translationService) {
    
    var url = window.sessionStorage.getItem('URL');
    translationService.getTranslation($scope);    
    ObtenerCamiones();
    ObtenerEstado();
    obtCentros();

    
    //Ordenar las columnas de la tabla TERMINAL
    $scope.sort = function (keyname) {
        $scope.sortKey = keyname;
        $scope.reverse = !$scope.reverse;
    }
     //claves de acceso
    $scope.AsignarPermisoCamion = function (Permiso, SoloLectura) {
        $scope.Permiso = Permiso;
        $scope.SoloLectura = SoloLectura;
    }
   
    //peticion para obtener datos SELECT(mostrando tabla)
    function ObtenerCamiones() {
       
        $http({

            url: url + '/api/Camiones/ObtenerCamiones?usu=' + window.sessionStorage.getItem('USUId').replace(/\+/g, "%2B"),
            metohod: 'GET',
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-Type': 'application/json'
            }
        }).success(function (data, status) {
            $scope.cCamion = data;
            var tam = $scope.cCamion.length;
            $scope.tamPag = tamano(tam);
        }
            ).error(function (error, status) {
                $scope.error = { message: error, status: status };
                console.log($scope.error);
            });
    }

    //Obtener Estado VAlor Por referencia ESTADOS,TIPOCAMION
    function ObtenerEstado() {
        
        valorReferencia.obtenerValores('EDOREG', function (result) {
           
            $scope.edoreg = result;
            //console.log(JSON.stringify(result));
        });

        valorReferencia.obtenerValores('TIPOCAM', function (result) {

            $scope.tipocam = result;
            //console.log(JSON.stringify(result));
        });
    }

    //Obteniendo Centros de Distribucion
    function obtCentros() {
        $http({
            url: url + '/api/Camiones/ObtCentroDistribucion',
            method: 'GET',
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-Type': 'application/json'
            },
        }).success(function (data, status) {
            $scope.btipouso = data;
        }).error(function (error, status) {
            console.log("DATOS: " + error);
        });
    }

    //BotonGuardarCamiones
    $scope.GuardarCamion = function (cap,caj) {

        if (!$scope.form.$valid) {
            $scope.form.submitted = true;
        } else {
            var a = $scope.CapacidadKg;
            var b = $scope.Caja;
            var camiones = {

                
                Placa: $scope.Placa,
                Clave: $scope.Clave,                
                Descripcion: $scope.Descripcion,
                CapacidadKg: $scope.CapacidadKg,
                Cajas: $scope.Cajas,
                TipoEstado: $scope.TipoEstado,
                AlmacenIDCEDI: $scope.AlmacenIDCEDI,
                TipoCamion: $scope.TipoCamion,
                MUsuarioID: window.sessionStorage.getItem('USUId')

            };
            $http({
                url: url + '/api/Camiones/Grabar?camiones=' + camiones,
                method: 'post',
                data: JSON.stringify(camiones),
                dataType: "json",
                headers: {
                    Authorization: window.sessionStorage.getItem('Token'),
                    'Content-Type': 'application/json'
                },
            }).success(function (data, status) {

                if (data) {
                    window.location.href = '../Camiones/Index?Permiso=' + $scope.Permiso;

                } else {

                    console.log("Error");
                }


            }).error(function (error, status) {
            });
        }

    } 

    //BotonCancelar
    $scope.ValidarCancelar = function () {
        if (!$scope.form.$pristine) {
            $scope.Action = "Cancel";
            messageBox.MostrarSiNo($scope.translation.XCancelar, $scope.translation.BP0002);
        }
        else {
            window.location.href = '../Camiones/Index?Permiso=' + $scope.Permiso;
            consol.log($scope.Permiso);
        }
    }

    //Mensaje YES NO
    $scope.AceptarYesNoMsgBox = function () {
        messageBox.Cerrar();
        if ($scope.Action == "Delete") {
            $http({
                url: url + '/api/Camiones/Eliminar?Placa=' + $scope.Placa,
                method: 'GET',


                headers: {
                    Authorization: window.sessionStorage.getItem('Token'),
                    'Content-Type': 'application/json'
                },
            }).success(function (data, status) {
                window.location.href = '../Camiones/Index?Permiso=' + $scope.Permiso;
            }).error(function (error, status) {
            });
        }
        else if ($scope.Action == "Cancel") {
            window.location.href = '../Camiones/Index?Permiso=' + $scope.Permiso;
        }
    }

    //BotonEditar
    $scope.EditarCamion = function (Placa, Permiso, SoloLectura) {
       
        $scope.Permiso = Permiso;
        if (SoloLectura.toUpperCase() == "TRUE") {
            $scope.SoloLectura = true;
        }
        else {
            $scope.SoloLectura = false;
        }

        if (Placa != "") {
            $http({
                url: url + '/api/Camiones/ObtenerValorCamion?Placa=' + Placa,
                method: 'GET',
                headers: {
                    Authorization: window.sessionStorage.getItem('Token'),
                    'Content-Type': 'application/json'
                },
            }).success(function (data, status) {
                angular.forEach(data, function (it) {
                    $scope.Placa = it.Placa;
                    $scope.TipoEstado = it.TipoEstado;
                    $scope.Clave = it.Clave;
                    $scope.AlmacenIDCEDI = it.AlmacenIDCEDI;
                    $scope.Descripcion = it.Descripcion;
                    $scope.TipoCamion = it.TipoCamion;
                    $scope.CapacidadKg = it.CapacidadKg;
                    $scope.Cajas = it.Cajas;
                    $scope.AlmacenId = it.AlmacenId;
                    $scope.Nuevo = false;
                    $scope.Action = "Edit";


                });
            }).error(function (error, status) {
                console.log(" ERRORES ");
            });

        } else {
            $scope.Nuevo = true;
            $scope.Action = "Create";
            $scope.CapacidadKg = "0.00";
            $scope.Cajas = "0.00";
            $scope.TipoCamion = "1";
            $scope.TipoEstado ="1";
            
        }
    }


    //**Define las páginas que se utilizaran al mostrar los registros del cliente**//
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

app.directive('validarClaveC', validarClaveC);
function validarClaveC($http, $q, $timeout) {
    return {
        restrict: 'A',
        require: 'ngModel',
        link: function ($scope, element, attr, ngModel) {
            var validar = attr.validarClaveC;
           
            if (validar == "true") {
                ngModel.$asyncValidators.claveRepetida = function (modelValue, viewValue) {
                    var deferred = $q.defer();

                    if ($scope.Action == 'Create') { //Descomentar hasta llegar edit
                        //   if (true) {
                        var clave = viewValue;

                        element.bind('blur', function () {


                       
                        var url = window.sessionStorage.getItem('URL');

                        $http({
                            url: url + '/api/Camiones/ValidarCamionClave?Placa=' + clave,
                            method: 'GET',
                            headers: {
                                Authorization: window.sessionStorage.getItem('Token'),
                                'Content-Type': 'application/json'
                            },
                        }).success(function (data, status) {
                            if (data == false) {

                                deferred.resolve();
                            }

                            else {

                                deferred.reject();
                            }

                        }).error(function (error, status) {
                            deferred.resolve();
                        });
                     });//blur
                    }
                    else {

                        deferred.resolve();
                    }


                    // return the promise of the asynchronous validator
                    return deferred.promise;
                }
            } else {

            }
        }
    }
}

app.directive('validaInt', function () {
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


//asignacion de Formato separando con comas
app.controller('Ctapa', function ($scope) {

}).directive('camionApa', function ($filter) {
    return {
        scope: {
            amount: '='
        },
        link: function (scope, el, attrs) {
            // el.val($filter('currency')(scope.amount));

            el.bind('focus', function () {
                // el.val(scope.amount);
                //var s = new Intl.NumberFormat('es-MX').format(scope.amount);
                el.val($filter('number')(scope.amount));

            });

            el.bind('input', function () {

                scope.amount = el.val();
                scope.$apply();
            });
            el.bind('blur', function () {
                el.val($filter('number')(scope.amount,2));

               
            });
        }
    }
});


app.controller('Ctapes', function ($scope) {

}).directive('camionApes', function ($filter) {
    return {
        scope: {
            amount2: '='
        },
        link: function (scope, el, attrs) {
            // el.val($filter('currency')(scope.amount));

            el.bind('focus', function () {
                // el.val(scope.amount);
                el.val($filter('number')(scope.amount2));

            });

            el.bind('input', function () {

                scope.amount2 = el.val();
                scope.$apply();
            });
            el.bind('blur', function () {
              
                el.val($filter('number')(scope.amount2, 2));
            });
        }
    }
});


//Validar kilogramos < 0

//validnado Campo kilo No debe ir > 0
app.directive('kiloMenorCero', validarKiloMenor);
function validarKiloMenor($http, $q, $timeout) {
    return {
        restrict: 'A',
        require: 'ngModel',
        link: function ($scope, element, attr, ngModel) {
            element.ready(function () {
                element.bind('focus', function () {
                    ngModel.$asyncValidators.kiloMenorCero = function (modelValue, viewValue) {
                        var deferred = $q.defer();
                     

                        var kilogramo = modelValue;

                        if (kilogramo < 0) {
                            deferred.reject();
                        } else {
                            deferred.resolve();
                        }

                        return deferred.promise;
                    }
                });
            });
        }
    }
}

//validnado Campo caja No debe ir > 0
app.directive('cajaMenorCero', validarCajaMenor);
function validarCajaMenor($http, $q, $timeout) {
    return {
        restrict: 'A',
        require: 'ngModel',
        link: function ($scope, element, attr, ngModel) {
            element.ready(function () {
                element.bind('focus', function () {
                    ngModel.$asyncValidators.cajaMenorCero = function (modelValue, viewValue) {
                        var deferred = $q.defer();
                       

                        var caja = modelValue;

                        if (caja < 0) {
                            deferred.reject();
                        } else {
                            deferred.resolve();
                        }

                        return deferred.promise;
                    }
                });
            });
        }
    }
}


