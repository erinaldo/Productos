var app = angular.module('listasdeprecios', ['valorReferencia', 'messageBoxAux', 'ngResource', 'translation', 'defaultBox', 'ngMaterial', 'ngMessages']);
app.controller('PrecioCtrl', ["$scope", "$http", "$filter", 'valorReferencia', "messageBoxAux", "translationService", "defaultBox", function ($scope, $http, $filter, valorReferencia, messageBoxAux, translationService, defaultBox) {
    function fecha1() {
        $scope.PPVFechaInicio = new Date();
    }

    $scope.changeSave = false;
    $scope.PrecioAux = [];
    $scope.PrecioAux2 = [];
    $scope.ProPreList = [];
    $scope.filterOpts = function (selindex) {
        return function (item) {
            var ind = $scope.selects.indexOf(item);
            return ind == selindex || ind < 0;
        }
    };

    var url = window.sessionStorage.getItem('URL');
    translationService.getTranslation($scope);
    fecha1();
    ObtenerPrecios();
    ObtenerEstado();
    ObtenerProductos();
    // ObtenerVigencia();

    //Asignacion de Precio
    $scope.validarPrecio = function (index) {
        // var value = Globalize.parseFloat($(this).val());
        var precioEstandar = $('input[name="Precio' + index + '"]').val();
        if (precioEstandar <= 0) {
            $scope.PreciosV = false;
        } else {
            $scope.PreciosV = true;
        }
    }

    $scope.validarPrecioSugerido = function (index) {
        // var value = Globalize.parseFloat($(this).val());
        var precioEstandar = $('input[name="Precio' + index + '"]').val();
        var precioMinimo = $('input[name="PrecioMinimo' + index + '"]').val();
        if (precioMinimo <= precioEstandar) {
            $scope.PreciosM = true;
        } else {
            $scope.PreciosM = false;
        }
        /*  angular.forEach($scope.ProPreList, function (value,key) {
              if
          });*/
    }

    //Ordenar las columnas de la tabla TERMINAL
    $scope.sort = function (keyname) {
        $scope.sortKey = keyname;
        $scope.reverse = !$scope.reverse;
    }

    //claves de acceso
    $scope.AsignarPermisoPrecio = function (Permiso) {
        $scope.Permiso = Permiso;
    }

    //peticion para obtener datos TPRECIOS SELECT(mostrando tabla)**
    function ObtenerPrecios() {
        $http({
            url: url + '/api/ListasdePrecios/ObtenerPrecios',
            metohod: 'GET',
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-Type': 'application/json'
            }
        }).success(function (data, status) {
            $scope.cPrecio = data;
            // $scope.Jerarquia = 0.0;
        }
            ).error(function (error, status) {
                $scope.error = { message: error, status: status };
                //console.log($scope.error);
            });
    }

    //peticion para obtener datos TPRODUCTO SELECT(mostrando tabla)**
    function ObtenerProductos() {
        $http({
            url: url + '/api/ListasdePrecios/ObtenerProductos',
            metohod: 'GET',
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-Type': 'application/json'
            }
        }).success(function (data, status) {
            $scope.cProducto = data;

            console.log(JSON.stringify(cProducto));

        }
            ).error(function (error, status) {
                $scope.error = { message: error, status: status };
                //console.log($scope.error);
                console.log("Error");
            });
    }

    //Obtener Estado VAlor Por referencia ESTADOS,Forma de Venta**
    function ObtenerEstado() {
        valorReferencia.obtenerValores('EDOREG', function (result) {
            $scope.edoreg = result;
        });
        valorReferencia.obtenerValores('FVENTA', function (result) {
            $scope.fventa = result;
        });
        valorReferencia.obtenerValores('EDOREG', function (result) {
            $scope.edoreg = result;
            //console.log(JSON.stringify(result));
        });
        valorReferencia.obtenerValores('UNIDADV', function (result) {
            $scope.unidadv = result;
        });
    }

    //mostrando pantalla emergete Agregar Producto (PrecioBox)
    $scope.AgregarPrecio = function () {
        $('.cPrecioModal').attr('checked', false);
        defaultBox.Mostrar('Seleccionar Producto', 'otro', 'PrecioBox');
        //agregar translation arriba
    }

    //Agregando Producto
    //aqui se agregan a la pantalla principal solo los datos importantes 
    $scope.addProducto = function (product, checked, Nombre) {
        var Existe = false, LP = false;
        if (true) {
            //Deshabilita el boton Calendario
            // $scope.showResult = true;
            var des = "";
            $scope.numero = "$0.0";
            $http({
                url: url + '/api/ListasdePrecios/ObtenerUNIDADV?ProductoClave=' + product,
                method: 'GET',
                headers: {
                    Authorization: window.sessionStorage.getItem('Token'),
                    'Content-Type': 'application/json'
                },
            }).success(function (data, status) {
                $scope.ProPreList.push({
                    'ProductoClave': product,
                    'Nombre': Nombre,
                    'PRUTipoUnidad': data,
                    'id': getId(product),
                    'PPVFechaInicio': new Date(),
                    'Precio': "",
                    'PrecioMinimo': "",
                    'PrecioSugerido': "",
                    'TipoEstado': "1",
                    'FechaAux': new Date(),
                    'MUsuarioID': window.sessionStorage.getItem('USUId')
                });

                $scope.PrecioAux2.push({
                    'ProductoClave': product,
                    'PRUTipoUnidad': data,
                    'id': 0,
                    'PPVFechaInicio': 0,
                    'Precio': "",
                    'PrecioMinimo': "",
                    'PrecioSugerido': "",
                    'TipoEstado': 0,
                    'FechaAux': new Date(),
                    'MUsuarioID': window.sessionStorage.getItem('USUId'),

                    FechaFin: '9999-12-31 00:00:00.000',
                    Exclusion: 0,
                    PrecioClave: 0
                });
            }).error(function (error, status) {
                console.log("DATOS: " + error);
            });

        } else {

        }
    }

    function getId(clave) {
        var fecha = new Date();
        return clave + "-" + Math.floor((Math.random() * 900000) + 100000).toString() + "-" + fecha.getDate() + "-" + fecha.getMonth() + "-" + Math.floor((Math.random() * 90000) + 10000).toString() + "-" + fecha.getFullYear();

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

    $scope.change = function (id) {
        //  if ($scope.changeSave == false) {
        var tipo = $('select[id="' + id + '"]').val();
        if (tipo == "") {
            $scope.ValidarEliminarProducto(id, false);
        }
        // }
    }

    //BotonGuardarPrecio
    $scope.GuardarPrecio = function () {
        debugger;
        //var aux = $scope.PrecioAux2;
        if (!$scope.form.$valid) {
            $scope.form.submitted = true;
        } else {
            debugger;
            $scope.changeSave = true;
            var ListaCompleta = false;
            $scope.ListaValida = false;
            //console.log("AUX: " + JSON.stringify($scope.PrecioAux2));

            angular.forEach($scope.PrecioAux2, function (value, key) {//AUX2

                angular.forEach($scope.ProPreList, function (va, ke) {
                    debugger;

                    if (key == ke) {
                        var FechaN = new Date(va.PPVFechaInicio);//se trae la fecha
                        FechaN.setHours(0, 0, 0, 0);
                        value.PPVFechaInicio = FechaN;
                        debugger;
                        value.Precio = va.Precio;
                        value.PrecioMinimo = va.PrecioMinimo;
                        value.PrecioSugerido = va.PrecioSugerido;
                        value.TipoEstado = va.TipoEstado;
                        value.PrecioClave = $('input:text[name=PrecioClave]').val();
                        value.FechaAux = new Date(va.PPVFechaInicio - 1);
                        console.log("sssss: " + value.FechaAux);
                    }
                    angular.forEach($scope.PrecioAux, function (v, k) {
                        if (key == k) {
                            value.PRUTipoUnidad = v.PRUTipoUnidad;
                        }
                    });
                });
            });
            console.log("PorpeLIst:" + JSON.stringify($scope.PrecioAux2));
            //console.log("AUX: " + JSON.stringify(aux));

            if ($scope.ProPreList.length > 0) {
                debugger;
                ListaCompleta = true;
                $scope.ListaValida = true;
                //console.log("PorpeLIst:" + JSON.stringify($scope.ProPreList));
            }

            if (!$scope.form.$valid || !ListaCompleta) {
                $scope.form.submitted = true;
            } else {
                //ListadePrecios
                var listaPrecios = {
                    PrecioProductoVig: $scope.PrecioAux2,
                    PrecioClave: $scope.PrecioClave,
                    Jerarquia: $scope.Jerarquia,
                    Nombre: $scope.Nombre,
                    CFVtipo: $scope.CFVtipo,
                    TipoEstado: $scope.TipoEstado,
                    MUsuarioID: window.sessionStorage.getItem('USUId')
                };
                debugger;
                //PreProductoVig    

                $http({
                    url: url + '/api/ListasdePrecios/Grabar?listaPrecios=' + listaPrecios,
                    method: 'post',
                    data: JSON.stringify(listaPrecios),
                    dataType: "json",
                    headers: {
                        Authorization: window.sessionStorage.getItem('Token'),
                        'Content-Type': 'application/json'
                    },
                }).success(function (data, status) {
                    if (data) {
                        window.location.href = '../ListasdePrecios/Index?Permiso=' + $scope.Permiso;
                    } else {
                        console.log("Error");
                    }
                }).error(function (error, status) {
                });
            }
        }

    }

    //Eliminar Productos
    $scope.ValidarEliminarProducto = function (id, eliminarCompleto) {
        if (eliminarCompleto == true) {
            angular.forEach($scope.ProPreList, function (value, key) {

                //elimina Calendario
                /*  if ($scope.ProPreList.length == 1) {
                      $scope.showResult = false;
  
  
                  }*/

                if (value.id == id) {
                    $scope.ProPreList.splice(key, 1);
                    $scope.PrecioAux2.splice(key, 1);
                }
            });
        }

        angular.forEach($scope.PrecioAux, function (value, key) {
            if (value.id == id) {
                $scope.PrecioAux.splice(key, 1);
                // $scope.PrecioAux2.splice(key, 1);
            }
        });
    }

    //Vigencia solo se abre en Edit Y con productos traidos
    $scope.VigenciaProducto = function (producto, unidad, nombre) {
        var prec = $scope.PrecioClave;
        var productoC = producto;
        var unidadP = unidad;
        var nombre = nombre;
        debugger;

        //ClienteModelo
        $scope.SeleccionCl = function (Fecha, Usuario) {
            $scope.fe = Fecha;
            $scope.ad = Usuario;
        };


        $('.cPrecioModal').attr('checked', false);
        defaultBox.Mostrar('Vigencia de Precios del Producto', 'otro', 'ListasVigenciaBox');

        //console.log("PEPEPEPE: " + id);
        debugger;
        $http({

            url: url + '/api/ListasdePrecios/ObtenerVigencia?PrecioClave=' + prec + '&ProductoClave=' + productoC + '&PRUTipoUnidad=' + unidadP + '&Nombre=' + nombre,
            metohod: 'GET',
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-Type': 'application/json'
            }
        }).success(function (data, status) {
            debugger;
            $scope.cVigencia = data;

            //console.log(JSON.stringify(cProducto));

        }
            ).error(function (error, status) {
                $scope.error = { message: error, status: status };
                //console.log($scope.error);
                console.log("Error");
            });
    }

    //Editar
    $scope.EditarPrecio = function (PrecioClave, Permiso, SoloLectura) {
        debugger;

        $scope.Permiso = Permiso;
        if (SoloLectura.toUpperCase() == "TRUE") {
            $scope.SoloLectura = true;
        }
        else {
            $scope.SoloLectura = false;
        }

        if (PrecioClave != "") {
            debugger;
            $http({
                url: url + '/api/ListasdePrecios/ObtenerValorPrecio?PrecioClave=' + PrecioClave,
                method: 'GET',
                headers: {
                    Authorization: window.sessionStorage.getItem('Token'),
                    'Content-Type': 'application/json'
                },
            }).success(function (data, status) {
                angular.forEach(data, function (it) {
                    $scope.Action = "Edit";
                    $scope.Nuevo = false;
                    $scope.PrecioClave = it.PrecioClave;
                    $scope.Jerarquia = it.Jerarquia;
                    $scope.Nombre = it.Nombre;
                    $scope.CFVtipo = it.CFVtipo;
                    $scope.TipoEstado = it.TipoEstado;
                    debugger;
                });
            }).error(function (error, status) {
                console.log(" ERRORES ");
            });
        } else {
            debugger;
            $scope.Action = "Create";
            $scope.Nuevo = true;
            $scope.TipoEstado = "1";
            $scope.Jerarquia = 0.0;
        }
    }

    //Copiar
    $scope.CopiarPrecio = function (PrecioClave, Permiso, SoloLectura) {
        debugger;

        $scope.Permiso = Permiso;
        if (SoloLectura.toUpperCase() == "TRUE") {
            $scope.SoloLectura = true;
        }
        else {
            $scope.SoloLectura = false;
        }

        if (PrecioClave != "") {

            debugger;
            $http({
                url: url + '/api/ListasdePrecios/ObtenerValorPrecio?PrecioClave=' + PrecioClave,
                method: 'GET',
                headers: {
                    Authorization: window.sessionStorage.getItem('Token'),
                    'Content-Type': 'application/json'
                },
            }).success(function (data, status) {
                angular.forEach(data, function (it) {

                    $scope.Action = "Copy";

                    $scope.Nuevo = false;


                    $scope.CFVtipo = it.CFVtipo;
                    $scope.TipoEstado = it.TipoEstado;
                    debugger;
                });
            }).error(function (error, status) {
                console.log(" ERRORES ");
            });

        } else {

        }
    }

    //BotonCancelar
    $scope.ValidarCancelar = function () {
        debugger;
        if (!$scope.form.$pristine) {
            //$scope.Action = "Cancel";
            debugger;
            $scope.lblMsgTitulo = $scope.translation.XCancelar;
            $scope.lblMsgMensaje = $scope.translation.BP0002;
            messageBoxAux.MostrarSiNo();
        }
        else {
            window.location.href = '../ListasdePrecios/Index?Permiso=' + $scope.Permiso;
        }
    }

    //BotonGuardar
    $scope.ValidarGuardar = function () {
        ListaCompleta = false;

        if ($scope.ProPreList.length > 0) {
            debugger;
            ListaCompleta = true;
            $scope.ListaValida = true;
            //console.log("PorpeLIst:" + JSON.stringify($scope.ProPreList));
        }
        debugger;
        if (!$scope.form.$pristine) {
            $scope.Action = "Update";
            debugger;
            $scope.lblMsgTitulo = $scope.translation.BTGuardar;
            $scope.lblMsgMensaje = $scope.translation.P0004;
            messageBoxAux.MostrarSiNo();
        }
        else {
            window.location.href = '../ListasdePrecios/Index?Permiso=' + $scope.Permiso;

        }
    }

    //Mensaje YES NO
    $scope.AceptarYesNoMsgBox = function () {
        messageBoxAux.Cerrar();
        if ($scope.Action == "Delete") {
            $http({
                url: url + '/api/ListasdePrecios/Eliminar?Placa=' + $scope.Placa,
                method: 'GET',
                headers: {
                    Authorization: window.sessionStorage.getItem('Token'),
                    'Content-Type': 'application/json'
                },
            }).success(function (data, status) {
                window.location.href = '../ListasdePrecios/Index?Permiso=' + $scope.Permiso;
            }).error(function (error, status) {
            });
        }
        else if ($scope.Action == "Cancel") {
            window.location.href = '../ListasdePrecios/Index?Permiso=' + $scope.Permiso;
        }
        else if ($scope.Action == "Update") {
            $scope.GuardarPrecio();
        }
    }

    $scope.ObtenerlistasdePrecios = function (PrecioClave) {

        $http({
            url: url + '/api/ListasdePrecios/ObtenerlistaDetalle?PrecioClave=' + PrecioClave,
            method: 'GET',
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-Type': 'application/json'
            },
        }).success(function (data, status) {
            if (data.length > 0) {
                $scope.ProPreList = data;
                angular.forEach($scope.ProPreList, function (v, k) {
                    v.id = getId(v.ProductoClave);
                    v.PPVFechaInicio = new Date(v.PPVFechaInicio);
                });
            }
            debugger;
        }).error(function (error, status) {
        });
        $http({
            url: url + '/api/ListasdePrecios/ObtenerlistaDetalle?PrecioClave=' + PrecioClave,
            method: 'GET',
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-Type': 'application/json'
            },
        }).success(function (response, status) {
            if (response.length > 0) {
                $scope.PrecioAux = response;
            }
            debugger;
        }).error(function (error, status) {
        });

        $http({
            url: url + '/api/ListasdePrecios/ObtenerlistaDetalle?PrecioClave=' + PrecioClave,
            method: 'GET',
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-Type': 'application/json'
            },
        }).success(function (response2, status) {
            if (response2.length > 0) {
                $scope.PrecioAux2 = response2;
            }
            debugger;
        }).error(function (error, status) {
        });
    }

}]);

//Crear ListasdePreciosl
app.directive('validarClavePrecio', validarClaveP);
function validarClaveP($http, $q, $timeout) {
    return {
        restrict: 'A',
        require: 'ngModel',
        link: function ($scope, element, attr, ngModel) {
            ngModel.$asyncValidators.clavePrecioRepetida = function (modelValue, viewValue) {
                var deferred = $q.defer();
                if ($scope.Action == 'Create' || $scope.Action == 'Copy') { //Descomentar hasta llegar edit
                    //if (true) {
                    var clave = viewValue;
                    element.bind('blur', function () {
                        var url = window.sessionStorage.getItem('URL');
                        $http({
                            url: url + '/api/ListasdePrecios/ValidarTerminalClave?TerminalClave=' + clave,
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
        }
    }
}

//validnado Campo Precio No debe ir 0
app.directive('validarPrecioCero', validarPrecioCeroFunct);
function validarPrecioCeroFunct($http, $q, $timeout) {
    return {
        restrict: 'A',
        require: 'ngModel',
        link: function ($scope, element, attr, ngModel) {
            element.ready(function () {
                element.bind('focus', function () {
                    ngModel.$asyncValidators.precioMinimoCero = function (modelValue, viewValue) {
                        var deferred = $q.defer();
                        debugger;

                        var precioEstandar = modelValue;

                        if (precioEstandar <= 0) {
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

//Validando PrecioMinimo Iguial o menor a Precio
app.directive('validarPrecioMinimo', validarPrecioM);
function validarPrecioM($http, $q, $timeout) {
    return {
        restrict: 'A',
        require: 'ngModel',
        link: function ($scope, element, attr, ngModel) {
            element.ready(function () {
                element.bind('focus', function () {
                    ngModel.$asyncValidators.precioMinimoIgual = function (modelValue, viewValue) {
                        var deferred = $q.defer();
                        var Precio = attr.precio;
                        var precioMinimimo = modelValue;

                        debugger;
                        if (precioMinimimo > Precio) {
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


//ValidandoFehcas y precios modificados
app.directive('validarPrecioCambiado', validarPrecioC);
function validarPrecioC($http, $q, $timeout) {
    return {

        restrict: 'A',
        require: 'ngModel',
        link: function ($scope, element, attr, ngModel) {
            debugger;
            element.ready(function () {
                // element.bind('focus', function () {
                ngModel.$asyncValidators.precioCambio = function (modelValue, viewValue) {
                    var deferred = $q.defer();
                    var PrecioClave = $scope.PrecioClave;
                    var ProductoClave = attr.pc;
                    var Unidad = attr.pu;
                    var consultado = attr.pn;
                    var Precio = modelValue;


                    debugger;
                    if (ngModel.$pristine == false && $scope.Action == "Edit" && consultado == "1") {
                        debugger;
                        var url = window.sessionStorage.getItem('URL');
                        $http({
                            url: url + '/api/ListasdePrecios/ValidarPcambiado?PrecioClave=' + PrecioClave + '&ProductoClave=' + ProductoClave + '&Unidad=' + Unidad + '&Precio=' + Precio,
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
                                debugger;
                                deferred.reject();

                            }

                        }).error(function (error, status) {
                            deferred.resolve();
                        });



                    } else {
                        deferred.resolve();
                    }

                    return deferred.promise;
                }
                // });
            });
        }
    }
}


app.directive('validarFechaCambiada', validarfechaC);//validar cuando se Garde ;)
function validarfechaC($http, $q, $timeout) {
    return {

        restrict: 'A',
        require: 'ngModel',
        link: function ($scope, element, attr, ngModel) {
            debugger;
            element.ready(function () {
                // element.bind('focus', function () {
                ngModel.$asyncValidators.fechaCambiada = function (modelValue, viewValue) {
                    var deferred = $q.defer();
                    var Fecha = new Date(modelValue);//se trae la fecha
                    var FechaActual = new Date();
                    Fecha.setHours(0, 0, 0, 0);
                    FechaActual.setHours(0, 0, 0, 0);
                    var Consultado = attr.consu;
                    debugger;
                    var d = new Date(FechaActual - 1);
                    console.log("CONCHA " + d);
                    /*
                                        if ($scope.Action == "Edit" && ngModel.$pristine == false  && Consultado == "1") {
                                            debugger;
                    
                                            var url = window.sessionStorage.getItem('URL');
                                            $http({
                                                url: url + '/api/ListasdePrecios/ValidarFcambiada?PrecioClave=' + Precio,
                                                method: 'GET',
                                                headers: {
                                                    Authorization: window.sessionStorage.getItem('Token'),
                                                    'Content-Type': 'application/json'
                                                },
                                            }).success(function(data, status) {
                                                if (data == false) {
                                                    deferred.resolve();
                    
                                                }
                    
                                                else {
                                                    debugger;
                                                    deferred.reject();
                    
                                                }
                    
                                            }).error(function(error, status) {
                                                deferred.resolve();
                                            });
                    
                    
                    
                                        } else {
                                              deferred.resolve();
                                            
                    
                                        }
                                        */
                    return deferred.promise;
                }
                // });
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
            debugger;
            element.ready(function () {
                // element.bind('focus', function () {
                ngModel.$asyncValidators.fechaMin = function (modelValue, viewValue) {
                    var deferred = $q.defer();
                    var Fecha = new Date(modelValue);//se trae la fecha
                    var FechaActual = new Date();
                    var Consultado = attr.consu;

                    Fecha.setHours(0, 0, 0, 0);
                    FechaActual.setHours(0, 0, 0, 0);
                    debugger;

                    if (Fecha >= FechaActual) {

                        deferred.resolve();
                    }
                    else {
                        deferred.reject();
                    }
                    return deferred.promise;
                }

            });
        }
    }
}



//Vaalidar Clave Repetida y Unidad
app.directive('validarUnidad', validarUnidadRepetida)
function validarUnidadRepetida($http, $q, $timeout) {
    return {
        restrict: 'A',
        require: 'ngModel',
        link: function ($scope, elem, attr, ngModel) {
            var claveProducto = attr.unidad;
            var Precio = attr.precio;
            var id = attr.id;
            $scope.$parent.changeSave = false;
            debugger;
            elem.ready(function () {
                ngModel.$asyncValidators.unidadRepetida = function (modelValue, viewValue) {

                    var deferred = $q.defer();
                    var detalles = $scope.$parent.ProPreList;
                    var repetido = 0;
                    var tipo = modelValue;


                    //console.log("Detalles: " + JSON.stringify(detalles));
                    debugger;


                    for (var i = 0; i < detalles.length; i++) {
                        //
                        debugger;
                        var primero = false;
                        var tipoAx = $('select[indexName="' + i + '"]').val();
                        var clave = $('select[indexName="' + i + '"]').attr("unidad");
                        var idAx = $('select[indexName="' + i + '"]').attr("id");
                        debugger;
                        if (tipoAx.toString().substring(7, tipoAx.toString().length) != "") {

                            if (id != idAx) {
                                //console.log("No es el mismo producto");
                            } else {



                                obj = {
                                    id: id,
                                    ProductoClave: claveProducto,
                                    PRUTipoUnidad: tipo
                                };

                                if ($scope.$parent.PrecioAux.length <= 0) {
                                    $scope.$parent.PrecioAux.push(obj);
                                    // $scope.$parent.PrecioAux2.push(obj);
                                    //console.log("=====SE AGREGA PRODUCTOA====="+i);


                                } else {


                                    $scope.$parent.PrecioAux.push(obj);
                                    //  $scope.$parent.PrecioAux2.push(obj);
                                    //debugger;

                                    angular.forEach($scope.PrecioAux, function (v, k) {//aqui estan los que se estan agregando a la lista
                                        //debugger;

                                        if (v.id == id) {
                                            //debugger;

                                            if (v.ProductoClave == clave) {
                                                // 

                                                if (v.PRUTipoUnidad == tipo) {
                                                    //debugger;

                                                    deferred.resolve();

                                                } else {
                                                    v.PRUTipoUnidad = tipo;//cambia con el ciclo
                                                    var cam = $scope.$parent.PrecioAux.length;
                                                    $scope.$parent.PrecioAux.splice(cam - 1, 1);
                                                    //  $scope.$parent.PrecioAux2.splice(cam - 1, 1);
                                                    deferred.resolve();

                                                    1

                                                }
                                            }

                                        } if (v.ProductoClave == clave) {
                                            // 
                                            if (v.PRUTipoUnidad == tipo) {
                                                deferred.reject();

                                            }
                                        }

                                    });

                                }
                            }
                        }


                    }

                    deferred.resolve();
                    return deferred.promise;

                };

            });
        }
    }
}



//Validacion de numeros y decimales 
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


//Solo Numeros
//Validacion de numeros y decimales 
app.directive('validNumberInt', function () {
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
                    clean = decimalCheck[0] + decimalCheck[1];
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
app.controller('myCtrl', function ($scope) {

}).directive('blurToCurrency', function ($filter) {
    return {
        scope: {
            amount: '='
        },
        link: function (scope, el, attrs) {
            // el.val($filter('currency')(scope.amount));

            el.bind('focus', function () {
                // el.val(scope.amount);
                el.val($filter('currency')(scope.amount));

            });

            el.bind('input', function () {

                scope.amount = el.val();
                scope.$apply();
            });
            el.bind('blur', function () {
                el.val($filter('currency')(scope.amount));
            });
        }
    }
});

