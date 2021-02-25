//Primera versión
var app = angular.module("configParametro", ["translation", "valorReferencia", "defaultBox", "messageBoxAux", "messageBox"])

app.controller("configParametroCtrl", ["$scope", "$http", "translationService", "valorReferencia", "defaultBox", "messageBoxAux", "messageBox", function ($scope, $http, translationService, valorReferencia, defaultBox, messageBoxAux, messageBox) {

    //Inicializacion de variables para camiones
    translationService.getTranslation($scope);
    var url = window.sessionStorage.getItem('URL');

    //Variables Auxiliares
    $scope.auxParametro = "";
    $scope.auxIdentificador = "";
    $scope.Nivel = "";
    $scope.Parametro = "";
    $scope.Identificador = "";
    $scope.Observaciones = "";
    $scope.Activo = true;
    $scope.Orden = false;

    //Permisos
    $scope.AsignarPermisoConfigParametro = function (Permiso) {
        $scope.Permiso = Permiso;
    };

    //Ordenar las columnas de la tabla
    $scope.sort = function (keyname) {
        $scope.sortKey = keyname;
        $scope.reverse = !$scope.reverse;
    };

    //Obtener parámetros actualmente activos
    $scope.ObtenerParametros = function () {
        $http({
            url: url + '/api/ConfigParametro/ObtenerParametros',
            method: 'get',
            headers: {
                Authorization: window.sessionStorage.getItem("Token"),
                'Content-Type': 'Aplication/json'
            }
        })
            .success(function (data, state) {
                $scope.ListaParametros = data;
            })
            .error(function (error, state) {
            })
    };

    //Obtener parámetros desde tabla de mensajes
    $scope.MensajeParametros = function () {
        $http({
            url: url + '/api/ConfigParametro/MensajeParametros',
            method: 'get',
            headers: {
                Authorization: window.sessionStorage.getItem("Token"),
                'Content-Type': 'Aplication/json'
            }
        })
            .success(function (data, state) {
                $scope.ListMensaje = data;
            })
            .error(function (error, state) {
            })
    };

    //Obtener identificadores relacionados al nivel seleccionado
    $scope.ObtenerIdentificadores = function () {
        $http({
            url: url + '/api/ConfigParametro/ObtenerIdentificadores?Nivel=' + $scope.Nivel,
            method: 'get',
            headers: {
                Authorization: window.sessionStorage.getItem("Token"),
                'Content-Type': 'Aplication/json'
            }
        })
            .success(function (data, state) {
                $scope.ListIdentificador = data;
            })
            .error(function (error, state) {
            })
    };

    //Obtener Niveles de Parametro dados de alta
    $scope.TipoNivel = function () {
        valorReferencia.obtenerValores('NIPA', function (result) {
            $scope.nipa = result;
        });
    };

    //Obtener Tipos de aplicacion dados de alta
    $scope.TipoAplicacion = function () {
        valorReferencia.obtenerValores('BMENAPL', function (result) {
            $scope.bmenapl = result;
        });
    };

    //Boton Cancelar
    $scope.ValidarCancelar = function () {
        if (!$scope.form.$pristine && !$scope.SoloLectura && $scope.Parametro != "" && $scope.Identificador != "") {
            $scope.Action = "Cancel";
            $scope.lblMsgTitulo = $scope.translation.XCancelar;
            $scope.lblMsgMensaje = $scope.translation.BP0001;
            messageBoxAux.MostrarSiNo();
        }
        else {
            window.location.href = '../ConfigParametro/Index?Permiso=' + $scope.Permiso;
        }
    };

    //AceptarYesNoMsgBox
    $scope.AceptarYesNoMsgBox = function () {
        messageBoxAux.Cerrar();
        if ($scope.Action == "Delete") {
            console.log("Eliminando valor por referencia");
            $scope.Eliminar();
        }
        else if ($scope.Action == "Cancel") {
            window.location.href = '../ConfigParametro/Index?Permiso=' + $scope.Permiso;
        }
    };

    //Enviar Seleccion
    $scope.Seleccion = function (Parametro, Observaciones) {
        $scope.Parametro = Parametro;
        $scope.Observaciones = Observaciones;
    };

    //Enviar seleccion de identificador
    $scope.SeleccionIdentificador = function (Identificador) {
        $scope.Identificador = Identificador;
    };

    //Obtiene la Descripcion del parametro si este se ingresa manualmente
    $scope.ObtenerDescripcion = function () {
        var Clave = $scope.Parametro;
        $http({
            url: url + '/api/ConfigParametro/ObtenerDescripcion?Clave=' + Clave,
            method: 'get',
            headers: {
                Authorization: window.sessionStorage.getItem("Token"),
                'Content-Type': 'Aplication/json'
            }
        })
            .success(function (data, state) {
                angular.forEach(data, function (v, k) {
                    $scope.Parametro = v.MENClave;
                    $scope.Observaciones = v.Descripcion;
                })
            })
            .error(function (error, state) {
            })
    };

    //Almacenar Parámetro
    $scope.AlmacenarParametro = function () {
        var Parametros = {
            Parametro: $scope.Parametro,
            Identificador: $scope.Identificador,
            Valor: $scope.Valor,
            Nivel: $scope.Nivel,
            TipoAplicacion: $scope.Aplicacion
        };
        $http({
            url: window.sessionStorage.getItem("URL") + '/api/ConfigParametro/AlmacenarParametro?parametro=' + Parametros,
            method: 'POST',
            data: JSON.stringify(Parametros),
            dataType: "json",
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-type': 'application/json'
            }
        }).success(function (data) {
            window.location.href = '../ConfigParametro/Index?Permiso=' + $scope.Permiso;
        }).error(function (error) {
        })
    };

    $scope.ValidarEliminar = function (parametro, identificador) {
        $scope.auxParametro = parametro;
        $scope.auxIdentificador = identificador;
        $scope.Action = "Delete";
        $scope.lblMsgTitulo = $scope.translation.XEliminar;
        $scope.lblMsgMensaje = $scope.translation.P0001;
        messageBoxAux.MostrarSiNo();
    };

    //Eliminar Parámetro
    $scope.Eliminar = function () {
        var Parametros = {
            Parametro: $scope.auxParametro ,
            Identificador: $scope.auxIdentificador,
            Valor: '',
            Nivel: 0,
            TipoAplicacion: 0
        };
        $http({
            url: window.sessionStorage.getItem("URL") + '/api/ConfigParametro/EliminarParametro?parametro=' + Parametros,
            method: 'POST',
            data: JSON.stringify(Parametros),
            dataType: "json",
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-type': 'application/json'
            }
        }).success(function (data) {
            window.location.href = '../ConfigParametro/Index?Permiso=' + $scope.Permiso;
        }).error(function (error) {
        })
    };

    //Boton Aceptar
    $scope.ValidarAceptar = function () {
        if (!$scope.form.$valid) {
            $scope.form.submitted = true;
        }
        else {
            $scope.AlmacenarParametro();
        }
    };

    //MsgBoxAux
    $scope.MsgBoxAux = function () {
        messageBoxAux.Cerrar();
    };

    //Seleccionar Parametro
    $scope.SeleccionarParametro = function () {
        defaultBox.Mostrar('', '', 'ParametrosBox');
    };

    //Seleccionar Identificador
    $scope.SeleccionarIdentificador = function () {
        defaultBox.Mostrar('', '', 'IdentificadorBox');
    };

    //Cambiar el estado del boton para seleccionar el identificador
    $scope.ValidarActivo = function () {
        if ($scope.Nivel == "2" || $scope.Nivel == "3") {
            $scope.Activo = false;
            $scope.Identificador = "";
        }
        else {
            $scope.Activo = true;
        }
    };

    //Generador de claves aleatorias
    $scope.KeyGen = function () {
        var vlDateTime = "";
        var vlNumeric = 0;
        var vlString = "";
        var vlStringl = "";
        var vlTimeNow = "";
        var vlKey = "";
        var vlBase = "";
        var vlModulo = "";

        var fecha = new Date();
        var año = fecha.getFullYear().toString();
        var mes = fecha.getMonth().toString();
        if (mes.length < 2) {
            mes = "0" + mes;
        }
        var dia = fecha.getDate().toString();
        if (dia.length < 2) {
            dia = "0" + dia;
        }
        var hora = fecha.getHours().toString();
        if (hora.length < 2) {
            hora = "0" + hora;
        }
        var minutos = fecha.getMinutes().toString();
        if (minutos.length < 2) {
            minutos = "0" + minutos;
        }
        var segundos = fecha.getSeconds().toString();
        if (segundos.length < 2) {
            segundos = "0" + segundos;
        }
        var milisegundos = fecha.getMilliseconds().toString();
        if (segundos.milisegundos < 2) {
            milisegundos = "0" + milisegundos;
        }
        var vcFechaHora = año + mes + dia + milisegundos + segundos + minutos + hora;
        var vcSemilla = 0;
        var vlBase = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ+"

        vlDateTime = vcFechaHora;
        vlNumeric = parseInt(vlDateTime);
        vlNumeric = vlNumeric - 3899000000000000;
        vlDateTime = vlNumeric.toString();
        vlDateTime = vlDateTime.substr(1, 13);

        vlNumeric = new Date().getHours();
        vlNumeric = vlNumeric + 100;
        vlString = vlNumeric.toString();
        vlTimeNow = vlTimeNow + vlString.substr(1);

        vlNumeric = new Date().getMinutes();
        vlNumeric = vlNumeric + 100;
        vlString = vlNumeric.toString();
        vlTimeNow = vlTimeNow + vlString.substr(1);

        vlNumeric = new Date().getSeconds();
        vlNumeric = vlNumeric + 100;
        vlString = vlNumeric.toString();
        vlTimeNow = vlTimeNow + vlString.substr(1);

        vlNumeric = new Date().getMilliseconds();
        vlNumeric = vlNumeric + 1000;
        vlString = vlNumeric.toString();
        vlTimeNow = vlTimeNow + vlString.substr(1, 2);

        vlNumeric = vcSemilla;
        vlNumeric = vlNumeric + 100;
        vlString = vlNumeric.toString();
        vlKey = vlDateTime + vlTimeNow + vlString.substr(1);
        if (vcSemilla == 99) {
            vcSemilla = 0;
        }
        else {
            vcSemilla = vcSemilla + 1;
        }

        vlNumeric = vlKey;
        vlString = "";

        while (vlNumeric > 0) {
            vlModulo = (vlNumeric % 36) + 1;
            vlNumeric = vlNumeric / 76;
            vlNumeric = parseInt(vlNumeric);
            vlString1 = vlBase.substr(vlModulo, 1);
            vlString = vlString1+vlString;
        }
        $scope.NewKey = vlString;
    };
}]);

//Directivas Propias---------------------------------------------------------------------------------------------------------------------------------------------------------

//Validar Parametro ingresado
app.directive('validarParametro', function ($http, $q) {
    return {
        restrict: 'A',
        require: 'ngModel',
        link: function ($scope, element, attr, ngModel) {
            var validar = attr.validarParametro;
            var index = attr.index;
            var url = window.sessionStorage.getItem('URL');
            if (validar == "true") {
                element.ready(function () {
                    ngModel.$asyncValidators.ValidarParametro = function (modelValue, viewValue) {
                        var deferred = $q.defer();
                        $http({
                            url: url + '/api/ConfigParametro/ValidarParametro?Parametro=' + modelValue,
                            method: 'get',
                            headers: {
                                Authorization: window.sessionStorage.getItem('Token'),
                                'Content-type': 'application/JSON'
                            }
                        }).success(function (data, staus) {
                            if (data == true) {
                                deferred.resolve();
                            } else {
                                deferred.reject();
                            }
                        }).error(function (error, status) {
                        });
                        return deferred.promise;
                    };
                });
            }
        }
    }
});

//Validar Identificador
app.directive('validarIdentificador', function ($http, $q) {
    return {
        restrict: 'A',
        require: 'ngModel',
        link: function ($scope, element, attr, ngModel) {
            var validar = attr.validarIdentificador;
            var index = attr.index;
            var url = window.sessionStorage.getItem('URL');
            if (validar == "true") {
                element.ready(function () {
                    ngModel.$asyncValidators.ValidarIdentificador = function (modelValue, viewValue) {
                        var deferred = $q.defer();
                        $http({
                            url: url + '/api/ConfigParametro/ValidarIdentificador?Identificador=' + modelValue + '&Nivel=' + $scope.Nivel,
                            method: 'get',
                            headers: {
                                Authorization: window.sessionStorage.getItem('Token'),
                                'Content-type': 'application/JSON'
                            }
                        }).success(function (data, staus) {
                            if (data == true) {
                                deferred.resolve();
                            } else {
                                deferred.reject();
                            }
                        }).error(function (error, status) {
                        });
                        return deferred.promise;
                    };
                });
            }
        }
    }
});

////Validar Identificador
//app.directive('validarIdentificadorNivel', function ($http, $q) {
//    return {
//        restrict: 'A',
//        require: 'ngModel',
//        link: function ($scope, element, attr, ngModel) {
//            var validar = attr.validarIdentificadorNivel;
//            var index = attr.index;
//            var url = window.sessionStorage.getItem('URL');
//            if (validar == "true") {
//                element.ready(function () {
//                    ngModel.$asyncValidators.ValidarIdentificadorNivel = function (modelValue, viewValue) {
//                        var deferred = $q.defer();
//                        $http({
//                            url: url + '/api/ConfigParametro/ValidarIdentificador?Identificador=' + $scope.Identificador + '&Nivel=' + modelValue,
//                            method: 'get',
//                            headers: {
//                                Authorization: window.sessionStorage.getItem('Token'),
//                                'Content-type': 'application/JSON'
//                            }
//                        }).success(function (data, staus) {
//                            if (data == true) {
//                                deferred.resolve();
//                            } else {
//                                deferred.reject();
//                            }
//                        }).error(function (error, status) {
//                        });
//                        return deferred.promise;
//                    };
//                });
//            }
//        }
//    }
//});