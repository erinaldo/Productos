var app = angular.module('valorReferencia', ['valorReferencia', 'messageBox', 'ngResource', 'translation']);


app.directive('validarCodigoUnico', validarCodigoUnicoFunc)
app.directive('validarClaveUnicaV', validarClaveUnicaVFunc)
app.directive('validarRepetido', validarValorRepetido)
app.directive('lenguajeRepetidoB', validarLenguajeRepetido)
app.directive('bloquearLenguaje', bloquearLenguajeFunct)

function validarCodigoUnicoFunc($http, $q, $timeout) {
    return {
        restrict: 'A',
        require: 'ngModel',
        link: function ($scope, element, attr, ngModel) {
            // fetch the call address from directives 'checkIfAvailable' attribute
            var validar = attr.validarCodigoUnico;
            ngModel.$asyncValidators.codigoRepetido = function (modelValue, viewValue) {
                var deferred = $q.defer();
                console.log("action: " + $scope.Action);
                if ($scope.Action == 'Create') {
                    var clave = viewValue;
                    console.log("clave: " + clave);

                    var url = window.sessionStorage.getItem('URL');

                    $http({
                        url: url + '/api/ValorReferencia/ValidarCodigoUnico?VARCodigo=' + clave,
                        method: 'GET',
                        headers: {
                            Authorization: window.sessionStorage.getItem('Token'),
                            'Content-Type': 'application/json'
                        },
                    }).success(function (data, status) {
                        if (data == false) {
                            console.log("no hay coincidencia");
                            deferred.resolve();
                        }

                        else {
                            console.log("Hay coincidencia");
                            deferred.reject();
                        }

                    }).error(function (error, status) {
                        deferred.resolve();
                    });
                }
                else {
                    console.log("OTRO METODO" + $scope.Action);
                    deferred.resolve();
                }

                console.log("Hola mundo directiva 3" + $scope.Action);
                // return the promise of the asynchronous validator
                return deferred.promise;
            }
        }
    }
}


function validarClaveUnicaVFunc($http, $q, $timeout) {
    return {
        restrict: 'A',
        require: 'ngModel',
        link: function ($scope, element, attr, ngModel) {
            // fetch the call address from directives 'checkIfAvailable' attribute
            var validar = attr.validarClaveUnicaV;
            ngModel.$asyncValidators.claveRepetida = function (modelValue, viewValue) {
                var deferred = $q.defer();
                if ($scope.Action == 'Create') {
                    var clave = viewValue;

                    var url = window.sessionStorage.getItem('URL');

                    $http({
                        url: url + '/api/ValorReferencia/ValidarClave?VAVClave=' + clave + '&VARCodigo=' + $scope.VARCodigo,
                        method: 'GET',
                        headers: {
                            Authorization: window.sessionStorage.getItem('Token'),
                            'Content-Type': 'application/json'
                        },
                    }).success(function (data, status) {
                        if (data == false) {
                            console.log("no hay coincidencia");
                            deferred.resolve();
                        }

                        else {
                            console.log("Hay coincidencia");
                            deferred.reject();
                        }

                    }).error(function (error, status) {
                        deferred.resolve();
                    });
                }
                else {
                    console.log("OTRO METODO" + $scope.Action);
                    deferred.resolve();
                }

                console.log("Hola mundo directiva 3" + $scope.Action);
                // return the promise of the asynchronous validator
                return deferred.promise;
            }
        }
    }
}


function validarLenguajeRepetido($http, $q, $timeout) {
    return {
        restrict: 'A',
        require: 'ngModel',
        link: function ($scope, elem, attrs, ngModel) {

            elem.ready(function () {
                ngModel.$asyncValidators.lenguajeRepetido = function (modelValue, viewValue) {
                    var deferred = $q.defer();
                    var detalles = $scope.$parent.vardetalle;
                    var repetido = 0;
                    var clave = $scope.det.VAVClave;
                    var lenguajeRepetido = false;
                    //console.log("VAVClave " + $scope.det.VAVClave);
                    //console.log("ModelValue " + modelValue);
                    console.log("BLENGUA: " + JSON.stringify($scope.$parent.blengua.length));

                    angular.forEach(detalles, function (value, key) {
                        if (value.VAVClave == clave) {
                            angular.forEach(value.VAVDescripcion, function (v, k) {
                                if (v.VADTipoLenguaje == modelValue) {
                                    console.log("Lenguaje repetido");
                                    lenguajeRepetido = true;
                                }
                            });
                        }
                    });
                    if (lenguajeRepetido == true) {
                        deferred.reject();
                    } else {
                        deferred.resolve();
                    }

                    return deferred.promise;
                };
            });


        }
    }
}

function validarValorRepetido($http, $q, $timeout) {
    return {
        restrict: 'A',
        require: 'ngModel',
        link: function ($scope, elem, attrs, ngModel) {
            elem.ready(function () {
                ngModel.$asyncValidators.valorRepetido = function (modelValue, viewValue) {
                    // return the promise of the asynchronous validator
                    var deferred = $q.defer();
                    var detalles = $scope.$parent.vardetalle;
                    var repetido = 0;


                    // console.log("Detalle: " + JSON.stringify(detalles));
                    angular.forEach(detalles, function (value) {
                        /*  console.log("Value: " + value.Grupo);
                          console.log("haskey det: " + $scope.det.$$hashKey);
                          console.log("haskey value: " + value.$$hashKey);
                          console.log(value.VAVClave + " == "+ modelValue); */

                        if ($scope.det.$$hashKey != value.$$hashKey) {
                            if (value.VAVClave == modelValue) {
                                //   console.log("valores: " + value.VAVClave);
                                repetido += 1;
                            }
                        }
                    }, this);
                    //console.log("repetido: " + repetido);
                    if (repetido > 0) {

                        deferred.reject();
                    }
                    else {
                        deferred.resolve();
                    }

                    return deferred.promise;
                };
            });
        }
    }
}

function bloquearLenguajeFunct($http, $q, $timeout) {
    return {
        restrict: 'A',
        require: 'ngModel',
        link: function ($scope, elem, attrs, ngModel) {

            ngModel.$asyncValidators.valorLeguajeRepetidoClave = function (modelValue, viewValue) {
                var deferred = $q.defer();
                elem.ready(function () {
                    var hashKey = $scope.det.$$hashKey;
                    if (modelValue === undefined) {
                        $('select[clase="descrip' + hashKey + '"]').attr('disabled', true);
                    } else {
                        console.log("Disabled");
                        $('select[clase="descrip' + hashKey + '"]').attr('disabled', false);
                    }
                });
                deferred.resolve();
                return deferred.promise;
            }
        }
    }
}

app.controller('crtlValorReferencia', ["$scope", "$http", 'valorReferencia', "messageBox", "translationService", function ($scope, $http, valorReferencia, messageBox, translationService) {


    var url = window.sessionStorage.getItem('URL');
    ObtenerValores();
    ObtenerValoresLeg();

    $scope.momento = true;
    $scope.ListaElementos = [];
    translationService.getTranslation($scope); //agregar en todos los controllers de las actividades para que se llenen las etiquetas con los mensajes

    //Declara los dos grupos de tipos de los radio buttons
    $scope.tipo = {
        modificable: '0',
        nulo: '0'
    };
    $scope.claveVacia = true;
    $scope.AsignarPermiso = function (Permiso) {
        $scope.Permiso = Permiso;
    }

    $scope.EditarValor = function (VARCodigo, Permiso, SoloLectura) {
        $scope.Permiso = Permiso;



        if (VARCodigo != "") {
            $http({
                url: url + '/api/ValorReferencia/ObtenerValor?varCodigo=' + VARCodigo,
                method: 'GET',
                headers: {
                    Authorization: window.sessionStorage.getItem('Token'),
                    'Content-Type': 'application/json'
                },
            }).success(function (data, status) {
                angular.forEach(data, function (it) {
                    $scope.VARCodigo = it.VARCodigo;
                    $scope.Descripcion = it.Descripcion;
                    $scope.TipoDato = it.TipoDato;
                    $scope.TipoAplicacion = it.TipoAplicacion;
                    //$scope.TipoNulo = it.TipoNulo;
                    //$scope.TipoModificable = it.TipoModificable;
                    $scope.Action = "Edit";
                    $scope.Nuevo = false;
                    $scope.tipo.nulo = it.TipoNulo;
                    $scope.tipo.modificable = it.TipoModificable;
                    $scope.SoloLectura = true;
                    $scope.priReg = false;
                    $scope.validacion = true;

                });
            }).error(function (error, status) {
                console.log(" ERRORES ");
            });

        } else {

            $scope.SoloLectura = false;
            $scope.Action = "Create";
            $scope.priReg = true;
            $scope.validacion = false;
        }
    }

    //Ordenar las columnas de la tabla
    $scope.sort = function (keyname) {
        $scope.sortKey = keyname;
        $scope.reverse = !$scope.reverse;
    }

    //Obtener valores ¿Como funciona?
    function ObtenerValoresLeg() {
        valorReferencia.obtenerValores('BMENSAJE', function (result) {
            $scope.bmensaje = result;
        });
        valorReferencia.obtenerValores('BMENAPL', function (result) {
            $scope.bmenapl = result;
        });
        valorReferencia.obtenerValores('BPROYECT', function (result) {
            $scope.bproyect = result;
        });
        valorReferencia.obtenerValores('BLENGUA', function (result) {
            $scope.blengua = result;
        });
        valorReferencia.obtenerValores('EDOREG', function (result) {
            $scope.edoreg = result;
        });

        valorReferencia.obtenerValores('BMENAPL', function (result) {
            $scope.bmenapl = result;
        });

        valorReferencia.obtenerValores('BTDATO', function (result) {
            $scope.bdato = result;
        });
        valorReferencia.obtenerValores('BTIPUSO', function (result) {
            $scope.btipouso = result;
        });
    }

    //Recoge los valores para enviarlos a la API de ValoresReferenciaController como un arreglo de datos
    $scope.GuardarValores = function () {
        if (!$scope.form.$valid) {
            console.log("Existen valores vacios");
            $scope.form.submitted = true;
            //    $event.preventDefault();
        }
        else {
            console.log("Guardando...");
            var valor = {
                VARCodigo: $scope.VARCodigo,
                Descripcion: $scope.Descripcion,
                TipoDato: $scope.TipoDato,
                TipoAplicacion: $scope.TipoAplicacion,
                TipoNulo: $scope.tipo.nulo,
                TipoModificable: $scope.tipo.modificable,
                MUsuarioId: window.sessionStorage.getItem('USUId'),
                VARValor: $scope.vardetalle
                //  VAVDescripcion: $scope.vavdescripcion
            };
            $http({
                url: url + '/api/ValorReferencia/Grabar?valor=' + valor,
                method: 'post',
                data: JSON.stringify(valor),
                dataType: "json",
                headers: {
                    Authorization: window.sessionStorage.getItem('Token'),
                    'Content-Type': 'application/json'
                },
            }).success(function (data, status) {
                window.location.href = '../ValorReferencia/Index?Permiso=' + $scope.Permiso;
            }).error(function (error, status) {
            });
            debugger;
        }
    }

    //Obtiene el detalle de Valor de Referencia
    $scope.ObtenerDetalleValores = function (VARCodigo) {
        $http({
            url: url + '/api/ValorReferencia/ObtenerDetalleValores?VARCodigo=' + VARCodigo,
            //  url: url + '/api/ValorReferencia/Detalles',
            method: 'GET',
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-Type': 'application/json'
            },
        }).success(function (data, status) {

            $scope.vardetalle = data;

        }).error(function (error, status) {
            console.log("DATOS: " + error);
        });
    }

    function getId() {
        var fecha = new Date();
        return Math.floor((Math.random() * 900) + 100).toString() + "-" + Math.floor((Math.random() * 900000) + 100000).toString() + "-" + fecha.getDate() + "-" + fecha.getMonth() + "-" + Math.floor((Math.random() * 90000) + 10000).toString() + "-" + fecha.getFullYear();

    }

    //Agrega los campos 'Clave' 'Grupo' 'Estado' de la tabla "VARValor"
    $scope.AgregarDescripcion = function () {

        $scope.validacion = true;

        $scope.vardetalle.push({ nuevo: true, 'VAVClave': '', 'ClaveSAT': '', 'Grupo': '', 'Estado': '', 'VAVDescripcion': [{ 'VADTipoLenguaje': '', 'Descripcion': '' }] });
        if ($scope.priReg == true) {
            $scope.vardetalle.splice(1, 1);

        }
        $scope.priReg = false;


    }

    //bloquearLenguaje
    $scope.bloquearLenguaje = function (value, hashKey) {
        // console.log("vardetalle: " + JSON.stringify($scope.$parent.vardetalle));
        console.log("hasKey: " + hashKey);

        if (value === undefined) {
            console.log("La clave está vacia");
            $('select[clase="descrip' + hashKey + '"]').attr('disabled', true);
        } else {
            console.log("Disabled");
            $('select[clase="descrip' + hashKey + '"]').attr('disabled', false);
        }
    }

    //Eliminar Valor de referencia
    $scope.EliminarValor = function (value) {
        $http({
            //  url: 'https://jsonplaceholder.typicode.com/posts',
            url: url + '/api/ValorReferencia/EliminarValor?VARCodigo=' + value,
            metohod: 'GET',
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-Type': 'application/json'
            }
        }).success(function (data, status) {
            window.location.href = '../ValorReferencia/Index?Permiso=' + $scope.Permiso;
        }
    ).error(function (error, status) {
        $scope.error = { message: error, status: status };
        console.log($scope.error);
    });
    }

    //Añade un lenguaje a cada VARValor
    $scope.ValorAgregarLenguaje = function (VAVClave) {
        angular.forEach($scope.vardetalle, function (value, key) {
            if (VAVClave == "" || VAVClave === undefined) {
                $scope.claveVacia = false;
                $('.valor-table').css('margin-bottom', 0);
            } else {
                $('.valor-table').css('margin-bottom', '20px');
                if (value.VAVClave == VAVClave) {
                    $scope.claveVacia = true;
                    value.VAVDescripcion.push({ 'VADTipoLenguaje': '', 'Descripcion': '', 'DescripcionSAT': '' });
                }
            }
        }, this);
    }
    //Validar cancelar 
    $scope.ValidarCancelar = function () {
        if (!$scope.form.$pristine) {
            $scope.Action = "Cancel";
            messageBox.MostrarSiNo($scope.translation.XCancelar, $scope.translation.BP0002);
        }
        else {
            window.location.href = '../ValorReferencia/Index?Permiso=' + $scope.Permiso;
        }
    }
    ///Eliminar lenguaje
    $scope.EliminarLenguaje = function (index, vad, VAVClave) {
        angular.forEach($scope.vardetalle, function (value, key) {
            //Añadir segundo index de lista
            if (VAVClave == "" || VAVClave === undefined) {
                $scope.claveVacia = false;
                $('.valor-table').css('margin-bottom', 0);
            } else {



                console.log("Tam: " + value.VAVDescripcion.length);

                $('.valor-table').css('margin-bottom', '20px');


                if (value.VAVDescripcion.length <= 1) {

                    console.log("No se puede eliminar " + "Tam: " + value.VAVDescripcion.length);
                } else {
                    if (value.VAVClave == VAVClave) {
                        $scope.claveVacia = true;
                        value.VAVDescripcion.splice(index, 1);
                        //value.VAVDescripcion.push({ 'VADTipoLenguaje': '', 'Descripcion': '' });
                    }
                }


            }
        }, this);
    }

    function tamano(tam) {
        var tamPag = 0;
        if (tam <= 100)
            tamPag = 20;
        else if (tam <= 1000 && tam > 100)
            tamPag = Math.floor(tam / 5);
        else if (tam <= 10000 && tam > 1000)
            tamPag = Math.floor(tam / 30);
        else if (tam <= 100000 && tam > 10000)
            tamPag = Math.floor(tam / 50);
        else if (tam <= 200000 && tam > 100000)
            tamPag = Math.floor(tam / 80);
        else if (tam <= 300000 && tam > 200000)
            tamPag = Math.floor(tam / 90);
        else if (tam <= 400000 && tam > 300000)
            tamPag = Math.floor(tam / 100);
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

    $scope.ValidarEliminarVARvalor = function (index) {

        console.log("1" + $scope.vardetalle.length);

        if ($scope.vardetalle.length >= 1) {
            console.log("2");
            $scope.Action = "DeleteVarvalor";
            $scope.IndexVarValor = index;
            messageBox.MostrarSiNo($scope.translation.XEliminar, $scope.translation.P0001);//Validar si se deja ese mensaje o se cambia por "¿Está seguro de eliminar la descripción?"
        }
        else {
            console.log("3");
            messageBox.Mostrar($scope.translation.XEliminar, $scope.translation.E0968);
        }
    }

    $scope.ValidarEliminarValorReferencia = function (index) {
        $scope.Action = "Delete";
        $scope.IndexValorReferencia = index;
        messageBox.MostrarSiNo($scope.translation.XEliminar, $scope.translation.P0001);//Validar si se deja ese mensaje o se cambia por "¿Está seguro de eliminar la descripción?"


        console.log("molestas 2");
    }


    $scope.EliminarVARvalor = function (index) {
        if ($scope.vardetalle.length >= 1) {
            $scope.vardetalle.splice(index, 1);
        }
    }


    $scope.AceptarYesNoMsgBox = function () {
        messageBox.Cerrar();
        if ($scope.Action == "Delete") {
            console.log("Eliminando valor por referencia");
            console.log($scope.Permiso);
            $scope.EliminarValor($scope.IndexValorReferencia);
        }
        else if ($scope.Action == "DeleteVarvalor") {
            //VarvalorEliminado
            console.log("BORAANDO VAR VALOR 1");
            $scope.EliminarVARvalor($scope.IndexVarValor);
        }
        else if ($scope.Action == "Cancel") {
            window.location.href = '../ValorReferencia/Index?Permiso=' + $scope.Permiso;
        }
    }

    function ObtenerValores() {

        $http({
            //  url: 'https://jsonplaceholder.typicode.com/posts',
            url: url + '/api/ValorReferencia/ObtenerValores',
            metohod: 'GET',
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-Type': 'application/json'
            }
        }).success(function (data, status) {
            $scope.valoresReferencia = data;
        }
            ).error(function (error, status) {
                $scope.error = { message: error, status: status };
                console.log($scope.error);
            });


    }

    //****//
    //PRUEBAS



    $scope.valoresReferencia = function () {
        $http(
          {
              url: url + '/api/ValorReferencia/ValoresReferencia',
              method: 'GET',
              headers: {
                  Authorization: window.sessionStorage.getItem('Token'),
                  'Content-Type': 'application/json'
              }
          }
        ).success(function (data, status) {

            $scope.valorRef = data;
            $scope.varValores = VarValores();
            $scope.vavDescripcion = VavDescripcion();
            console.log("Valores Referecia" + data);

            console.log("User = " + JSON.stringify(data));
        }

        ).error(function (error, status) {
            console.log("Error" + error);
        }

        );
    }




}]);

//Preguntar como hacer la referencia con otro nombre
app.factory('valorReferencia', ["$http", function ($http) {

    return {
        'obtenerValores': function (VARCodigo, callback) {
            var url = window.sessionStorage.getItem('URL');
            $http({
                url: url + '/api/ValorReferencia/ObtenerValores?VARCodigo=' + VARCodigo,
                method: 'GET',
                headers: {
                    Authorization: window.sessionStorage.getItem('Token'),
                    'Content-Type': 'application/json'
                },
            }).success(function (data, status) {
                callback(data);
            }).error(function (error, status) {
                if (status == 401) {
                    window.sessionStorage.clear();
                    window.location = url + '/Login'
                }
            });
        },
        'obtenerValorClave': function (VARCodigo, VAVClave, callback) {
            var url = window.sessionStorage.getItem('URL');
            $http({
                url: url + '/api/ValorReferencia/ObtenerValorClave?VARCodigo=' + VARCodigo + '&VAVClave=' + VAVClave,
                method: 'GET',
                method: 'GET',
                headers: {
                    Authorization: window.sessionStorage.getItem('Token'),
                    'Content-Type': 'application/json'
                },
            }).success(function (data, status) {
                callback(data);
            }).error(function (error, status) {
                if (status == 401) {
                    window.sessionStorage.clear();
                    window.location = url + '/Login'
                }
            });
        }
    }
}]);

