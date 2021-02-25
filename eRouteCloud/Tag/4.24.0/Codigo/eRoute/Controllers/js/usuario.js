var app = angular.module('usuario', ['valorReferencia', 'messageBox', 'ngMaterial', 'ngResource', 'translation', 'centroBox', 'rutaBox', 'validateBox', 'messageBoxAux']);

app.controller('usuarioCtrl', ["$scope", "$http", 'valorReferencia', "messageBox", "translationService", "centroBox", "rutaBox", "validateBox", "messageBoxAux", function ($scope, $http, valorReferencia, messageBox, translationService, centroBox, rutaBox, validateBox, messageBoxAux) {

    var url = window.sessionStorage.getItem('URL');
    translationService.getTranslation($scope);
    ObtenerValoresUsuario();
    // obtCentros();

    $scope.FechaMod = new Date();

    obtPoliticas();
    obtPerfil();
    ObtenerUsuarios();

    //Valida si la contraseña es obligatoria
    $scope.contValida = true;
    $scope.centroData = [];
    $scope.rutaHabilitada = true;
    $scope.rutasSupervisadas = [];
    $scope.AsignarPermisoUsuario = function (Permiso) {
        $scope.Permiso = Permiso;   
    }

    

    //Ordenar las columnas de la tabla
    $scope.sort = function (keyname) {
        $scope.sortKey = keyname;
        $scope.reverse = !$scope.reverse;
    }
    function ObtenerValoresUsuario() {

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

        valorReferencia.obtenerValores('BINTERF', function (result) {
            $scope.binterf = result;
        });

        valorReferencia.obtenerValores('TINDMOD', function (result) {
            $scope.tindmod = result;
        });

        

        


    }

    function obtCentros() {
        $http({
            url: url + '/api/Usuario/obtCentroDistribucion?USUId=' + $scope.USUIDTemp + "&Action="+$scope.Action,
            method: 'GET',
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-Type': 'application/json'
            },
        }).success(function (data, status) {
            $scope.centroDist = data;
        }).error(function (error, status) {
            console.log("DATOS: " + error);
        });
    }

    function obtPoliticas() {
        $http({
            url: url + '/api/Usuario/obtPoliticas',
            method: 'GET',
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-Type': 'application/json'
            },
        }).success(function (data, status) {
            $scope.politicasPriv = data;
        }).error(function (error, status) {
            console.log("DATOS: " + error);
        });
    }

    function obtPerfil() {
        $http({
            url: url + '/api/Usuario/obtPerfil',
            method: 'GET',
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-Type': 'application/json'
            },
        }).success(function (data, status) {
            $scope.perfilData = data;
        }).error(function (error, status) {
            console.log("DATOS: " + error);
        });
    }
    
    $scope.EditarUsuario = function (USUId, Permiso, SoloLectura) {
        $scope.Permiso = Permiso;
        if (SoloLectura.toUpperCase() == "TRUE") {
            $scope.SoloLectura = true;
        }
        else {
            $scope.SoloLectura = false;
        }

        if (USUId != "") {
            $http({
                url: url + '/api/Usuario/ObtenerUsuario?USUId=' + USUId,
                method: 'GET',
                headers: {
                    Authorization: window.sessionStorage.getItem('Token'),
                    'Content-Type': 'application/json'
                },
            }).success(function (data, status) {
                console.log("JSON: " + JSON.stringify(data));
                angular.forEach(data, function (user) {
                    $scope.USUId = user.USUId,

                    $scope.USUClave = user.Clave;
                    $scope.Nombre = user.Nombre;
                    $scope.Tipo = user.Tipo;
                    $scope.DiasLimite = user.DiasLimite;
                    $scope.ClaveAcceso = user.ClaveAcceso;
                    $scope.AlmacenID = user.AlmacenID;
                    $scope.FechaMod = user.FechaMod;
                    $scope.PoliticaId = user.PoliticaId;
                    $scope.PERClave = user.PERClave;
                    $scope.TipoAplicacion = user.TipoAplicacion;
                    $scope.ConfTerminal = user.ConfTerminal;
                    $scope.ConfRuta = user.ConfRuta;

                    ($scope.ConfRuta == 1) ? $scope.rutaHabilitada = false: ""; 

                    $scope.TipoRuta = user.TipoRuta;
                    //Carga las rutas disponibles del almacen seleccionado
                    RutasDisponibles($scope.AlmacenID);

                    //AlmacenIdAux = Se utiliza para conocer el AlmacenID original del usuario

                    $scope.AlmacenIdAux = $scope.AlmacenID;
                    $scope.TipoAux = $scope.Tipo;
                    if ($scope.Tipo == 3) {
                        $scope.tab = true;
                    }


                    $scope.Action = "Edit";
                    $scope.Nuevo = false;
                  //  $scope.priReg = false;
                   // $scope.validacion = true;

                });
            }).error(function (error, status) {
                console.log(" ERRORES ");
            });
        } else {
            $scope.Action = "Create";
           // $scope.priReg = true;
        //    $scope.validacion = false;
        }


    }

    $scope.AgregarCentro = function () {
        centroBox.Mostrar($scope.translation.XCancelar, $scope.translation.BP0002);
    }

    $scope.addCentro = function (centro, checked, nombre, AlmacenID) {
        if(checked == "YES"){
            $scope.centroData.push({ 'AlmacenID': AlmacenID, 'Clave': centro, 'Nombre': nombre, 'TipoEstado': '', 'Tipo': '', 'NombreCompuesto': '' });
        } else {
            angular.forEach($scope.centroData, function (value, key) {
                if (value.Clave == centro) {
                    $scope.centroData.splice(key, 1);
                } 
            });
        }
    }

    $scope.ValidarEliminarCentro = function (index, codigo) {
        angular.forEach($scope.centroDist, function (value, key) {
            if (value.Clave == codigo) {
                if ($("input[name='Clave" + key + "']").is(":checked")) {
                    $scope.centroData.splice(index, 1);
                    $("input[name='Clave" + key + "']").attr('checked', false);
                }
            }
        });
    }
    $scope.ValidarCancelar = function () {
        if (!$scope.form.$pristine && !$scope.SoloLectura) {
            $scope.Action = "Cancel";
            $scope.lblMsgTitulo = $scope.translation.XCancelar;
            $scope.lblMsgMensaje = $scope.translation.BP0002;
            messageBoxAux.MostrarSiNo();
        }
        else {
            window.location.href = '../Usuario/Index?Permiso=' + $scope.Permiso;
        }
    }

    $scope.AceptarYesNoMsgBox = function () {
        messageBoxAux.Cerrar();

        if ($scope.Action == "Cancel") {
            window.location.href = '../Usuario/Index?Permiso=' + $scope.Permiso;
        }
    }

   
    $scope.GuardarUsuario = function () {
        if (!$scope.form.$valid) {
            $scope.form.submitted = true;
        }
        else {

            var nCont = 0;

            var IntUsu = new Array();
            angular.forEach($scope.modulosAsignados, function (value, key) {
                var nSecuencia = 1;
                angular.forEach(value.Actividades, function (value2, key2) {
                    var permiso = "";
                    if (value2.Create)
                        permiso = permiso.concat("C");
                    if (value2.Read)
                        permiso = permiso.concat("R");
                    if (value2.Update)
                        permiso = permiso.concat("U");
                    if (value2.Delete)
                        permiso = permiso.concat("D");
                    if (value2.Execute)
                        permiso = permiso.concat("E");
                    if (value2.Others)
                        permiso = permiso.concat("O");
                    if (value2.Print)
                        permiso = permiso.concat("P");
                    if (value2.Sign)
                        permiso = permiso.concat("S");
                    var iu = {
                        ACTId: value2.ACTId,
                        INTTipoInterfaz: value.TipoInterfaz,
                        Clave: $scope.USUClave,
                        MODId: value.MODId,
                        Permiso: permiso,
                        Secuencia: nSecuencia,
                        PERAct: value2.PERAct
                    };
                    IntUsu.push(iu);
                    nSecuencia++;
                    nCont++;
                }, this);
            }, this);

            var usuario = {
                Nombre: $scope.Nombre,
                Tipo: $scope.Tipo,
                DiasLimite: $scope.DiasLimite,
                ClaveAcceso: $scope.ClaveAcceso,
                AlmacenID: $scope.AlmacenID,
                Activo: $scope.Activo,
                FechaMod: $scope.FechaMod,
                PoliticaId: $scope.PoliticaId,
                PERClave: $scope.PERClave,
                Clave: $scope.USUClave,
                USUId: $scope.USUId,

                ConfVendedor: $scope.ConfVendedor,
                ConfTerminal: $scope.ConfTerminal,
                ConfRuta: $scope.ConfRuta,
                TipoRuta: $scope.TipoRuta,
                ConfAlmacen: $scope.ConfAlmacen,

                SupervisorRuta: $scope.rutasSupervisadas,

                IntUsu: IntUsu,

                MUsuarioId: window.sessionStorage.getItem('USUId'),
                UsuarioAlmacen: $scope.centroData

            };
            $http({
                url: url + '/api/Usuario/Grabar?usuario=' + usuario,
                method: 'post',
                data: JSON.stringify(usuario),
                dataType: "json",
                headers: {
                    Authorization: window.sessionStorage.getItem('Token'),
                    'Content-Type': 'application/json'
                },
            }).success(function (data, status) {
               window.location.href = '/Usuario/Index?Permiso=' + $scope.Permiso;
            }).error(function (error, status) {
            });
            debugger;
        }
    }


    $scope.checarTodos = function(){


      //  ($scope.ConfRuta == 0) ? $scope.rutaHabilitada = true : $scope.rutaHabilitada = false;
        //($scope.ConfRuta == 0) ? $scope.rutaHabilitada = true : $scope.rutaHabilitada = false;




        if ($scope.todos == 'YES') {
            $('#conf-vendedor').prop('checked', true);
            $('#conf-terminal').prop('checked', true);
            $('#conf-ruta').prop('checked', true);
            $('#conf-almacen').prop('checked', true);
            $scope.idTipoRuta="1";
            
         //   $scope.rutaHabilitada = false;

        } else {
           // $scope.rutaHabilitada = true;
            $('#conf-vendedor').prop('checked', false);
            $('#conf-terminal').prop('checked', false);
            $('#conf-ruta').prop('checked', false);
            $('#conf-almacen').prop('checked', false);
        }
    }


    function ObtenerUsuarios() {

        $http({
            //  url: 'https://jsonplaceholder.typicode.com/posts',
            url: url + '/api/Usuario/ObtenerUsuarios',
            metohod: 'GET',
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-Type': 'application/json'
            }
        }).success(function (data, status) {
            $scope.cUsuariosList = data;
            var tam = $scope.cUsuariosList.length;
            $scope.tamPag = tamano(tam);
        }
            ).error(function (error, status) {
                $scope.error = { message: error, status: status };
                console.log($scope.error);
            });


    }

    //*****TAB PARA AGREGAR RUTAS SUPERVISADAS****///

    $scope.AgregarRuta = function () {
       // RutasDisponibles($scope.AlmacenID);
        rutaBox.Mostrar($scope.translation.ERMSECESC_MRutasM);
    }

    $scope.addRuta = function (RUTClave, Descripcion, checked) {
        if (checked == "YES") {
            $scope.rutasSupervisadas.push({ 'RUTClave': RUTClave, 'Descripcion': Descripcion });
        } else {
            angular.forEach($scope.rutasSupervisadas, function (value, key) {
                if (value.RUTClave == RUTClave) {
                    $scope.rutasSupervisadas.splice(key, 1);
                }
            });
        }
    }



    $scope.ValidarEliminarRutaSupervisada = function (index, RUTClave, tipo, Descripcion) {

        if (tipo === undefined) {
            angular.forEach($scope.rutasDisp, function (value, key) {
                if (value.RUTClave == RUTClave) {
                    if ($("input[name='Clave" + key + "']").is(":checked")) {
                        $scope.rutasSupervisadas.splice(index, 1);
                        $("input[name='Clave" + key + "']").attr('checked', false);
                    }
                }
            });
        } else {

            console.log("Tipo: " + tipo);
            $scope.rutasSupervisadas.splice(index, 1);
            $scope.rutasDisp.push({ 'RUTClave': RUTClave, 'Descripcion': Descripcion });

        }




  }


    //Obtiene el detalle de usuarios
    $scope.ObtenerDetalleUsuario = function (USUId) {
        $http({
            url: url + '/api/Usuario/ObtenerDetalleUsuario?USUId=' + USUId,
            //  url: url + '/api/ValorReferencia/Detalles',
            method: 'GET',
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-Type': 'application/json'
            },
        }).success(function (data, status) {
            $scope.centroData = data;
            $scope.USUIDTemp = USUId;
            obtCentros();
        }).error(function (error, status) {
            console.log("DATOS: " + error);
        });
    }

    $scope.ObtenerRutasSuper = function (USUId) {


        $http({
            url: url + '/api/Usuario/ObtenerRutasSuper?USUId=' + USUId,
            //  url: url + '/api/ValorReferencia/Detalles',
            method: 'GET',
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-Type': 'application/json'
            },
        }).success(function (data, status) {
            $scope.rutasSupervisadas = data;

        }).error(function (error, status) {
            console.log("DATOS: " + error);
        });
    }


    //Devuelve todas las rutas activas que no hayan sido asignadas a un usuario
    function RutasDisponibles(AlmacenID) {
        $http({
            url: url + '/api/Usuario/RutasDisponibles?AlmacenId='+AlmacenID,
            method: 'GET',
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-Type': 'application/json'
            },
        }).success(function (data, status) {
            $scope.rutasDisp = data;
        }).error(function (error, status) {
            console.log(" ERRORES ");
        });
    }

    //Configuracion del ComboBox de Almacenes
    $scope.configAlmacen = function () {
        $scope.ActionTab = "AlmacenCambiado";
        if ($scope.Action == "Edit") {
            //Pantalla editar
            if ($scope.AlmacenID != $scope.AlmacenIdAux) {
                if ($scope.rutasSupervisadas.length > 0) {
                    validateBox.MostrarSiNo($scope.translation.XEliminar, "[I0289] – Ya existen Rutas asignadas, los registros serán eliminados ¿Desea continuar?");
                    //  validateBox.MostrarSiNo($scope.translation.XEliminar, $scope.translation.I0289);//Validar si se deja ese mensaje o se cambia por "¿Está seguro de eliminar la descripción?"
                } else {
                    RutasDisponibles($scope.AlmacenID);
                    console.log("No hay rutas asignadas puede continuar");
                }
            } 
        } else {
            //Pantalla crear
            if ($scope.AlmacenIdAux === undefined) {
                RutasDisponibles($scope.AlmacenID);
                $scope.AlmacenIdAux = $scope.AlmacenID;
            } else {
                if ($scope.rutasSupervisadas.length > 0) {
                    validateBox.MostrarSiNo($scope.translation.XEliminar, "[I0289] – Ya existen Rutas asignadas, los registros serán eliminados ¿Desea continuar?");
                    //  validateBox.MostrarSiNo($scope.translation.XEliminar, $scope.translation.I0289);//Validar si se deja ese mensaje o se cambia por "¿Está seguro de eliminar la descripción?"
                } else {
                    RutasDisponibles($scope.AlmacenID);
                }
            }
        }
    }

    function ConfigTipo() {
        $scope.ActionTab = "TipoCambiado";
        if ($scope.Action == "Edit") {
            //Pantalla editar
            console.log("EDIT");
            if ($scope.Tipo != $scope.TipoAux) {
                if ($scope.rutasSupervisadas.length > 0) {
                    validateBox.MostrarSiNo($scope.translation.XEliminar, "[I0289] – Ya existen Rutas asignadas, los registros serán eliminados ¿Desea continuar?");
                } else {
                    console.log("No hay rutas asignadas puede continuar");
                }
            }
        } else {
            if ($scope.TipoAux == 3) {
                if ($scope.rutasSupervisadas.length > 0) {
                    validateBox.MostrarSiNo($scope.translation.XEliminar, "[I0289] – Ya existen Rutas asignadas, los registros serán eliminados ¿Desea continuar?");
                }
            }
        }
    }
    $scope.habilitarRuta = function () {
        if ($scope.ConfRuta !== undefined) {

         //   ($scope.rutaHabilitada == false) ? $scope.rutaHabilitada = true : $scope.rutaHabilitada = false;

            $scope.rutaHabilitada = !$scope.rutaHabilitada;
        } else {
            $scope.rutaHabilitada = true;
        }
    }
    $scope.ValidateYesNoMsgBox = function (confirm) {
        messageBox.Cerrar();
        if (confirm == "YES") {
            if ($scope.ActionTab == "AlmacenCambiado") {
                $scope.AlmacenIdAux = $scope.AlmacenID;
            }
            $scope.rutasSupervisadas = [];
            RutasDisponibles($scope.AlmacenID);

            if ($scope.ActionTab == "TipoCambiado") {
                $scope.tab = false;
                $scope.Cambiado = true;
            }
        }
        else {
            if ($scope.ActionTab == "TipoCambiado") {
                $scope.tab = true;
                $scope.Tipo = $scope.TipoFinal;
            } else {
                $scope.AlmacenID = $scope.AlmacenIdAux;
            }
        }
    }



    //Valida si la contraseña es obligatoria
    $scope.validarPass = function () {

        //La contraseña es obligatoria
        if ($scope.PoliticaId == null) {
            $scope.contValida = true;
        } else {
           // Consultar la tabla politicaContraseña y extraer el campo ContrasenaBlanco
                $http({
                    url: url + '/api/Usuario/ContrasenaBlanco?PoliticaId=' + $scope.PoliticaId,
                method: 'GET',
                headers: {
                    Authorization: window.sessionStorage.getItem('Token'),
                    'Content-Type': 'application/json'
                },
            }).success(function (data, status) {
                angular.forEach(data, function (index) {
                    $scope.ContrasenaBlanco = index.ContrasenaBlanco;
                });
                //Si es true es igual vacio
                if ($scope.ContrasenaBlanco == true) {
                    //La contraseña es opcional
                    $scope.contValida = false;

                } else {
                    //Sí es igual a false debe de tener un valor
                    $scope.contValida = true;
                }
            }).error(function (error, status) {
                console.log(" ERRORES ");
            });
        }
    }
    $scope.newTab = function () {


        $scope.TipoFinal = $scope.TipoAux;
        $scope.Cambiado = false;
        if ($scope.TipoAux === undefined) {
            console.log("1: " + $scope.Tipo);
            console.log("1: " + $scope.TipoAux);

            //Se toma el tipo para saber cual es el último
            $scope.TipoAux = $scope.Tipo;
            if ($scope.Tipo == 3) {
                $scope.tab = true;
                console.log("2: " + $scope.Tipo);
                console.log("2: " + $scope.TipoAux);
            }
        } else {
            if ($scope.Tipo == 3) {
                $scope.tab = true;
            } else {
                $scope.tab = false;
            }
            ConfigTipo();
        }
        if ($scope.Cambiado == true) {
            $scope.TipoAux = $scope.Tipo;
        }


    }

    //Excepciones de Usuario
    $scope.treeOptions = {
        accept: function (sourceNodeScope, destNodesScope, destIndex) {
            return true;
        },
    };

    $scope.toggle = function (scope) {
        scope.toggle();
    };

    $scope.ObtenerDisponibles = function (Clave, TipoInterfaz) {
        console.log("clave");
        //Obtener PERClave
        $http({
            url: url + '/api/Usuario/ObtenerPERClave?USUId=' + Clave,
            method: 'GET',
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-Type': 'application/json'
            },
        }).success(function (data, status) {
            angular.forEach(data, function (user) {

                $scope.PERClaveAux = user.PERClave;
            });

            $http({
                url: url + '/api/Usuario/ObtenerModulos?Clave=' + Clave + '&TipoInterfaz=' + TipoInterfaz + '&Disponibles=' + true + '&PERClave=' + $scope.PERClaveAux,
                method: 'GET',
                headers: {
                    Authorization: window.sessionStorage.getItem('Token'),
                    'Content-Type': 'application/json'
                },
            }).success(function (data, status) {
                $scope.modulosDisponibles = data;
            }).error(function (error, status) {
            });

        }).error(function (error, status) {
            console.log(" ERRORES ");
        });


    }

    $scope.ObtenerAsignadas = function (Clave, TipoInterfaz) {

        $http({
            url: url + '/api/Usuario/ObtenerPERClave?USUId=' + Clave,
            method: 'GET',
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-Type': 'application/json'
            },
        }).success(function (data, status) {
            angular.forEach(data, function (user) {
                $scope.PERClaveAux = user.PERClave;
            });

            $http({
                url: url + '/api/Usuario/ObtenerModulos?Clave=' + Clave + '&TipoInterfaz=' + TipoInterfaz + '&Disponibles=' + false + '&PERClave=' + $scope.PERClaveAux,
                method: 'GET',
                headers: {
                    Authorization: window.sessionStorage.getItem('Token'),
                    'Content-Type': 'application/json'
                },
            }).success(function (data, status) {
                $scope.modulosAsignados = data;
            }).error(function (error, status) {
            });

        }).error(function (error, status) {
            console.log(" ERRORES ");
        });


    }

    $scope.prueba = function () {
        console.log("Agregar centro");
    }

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

app.directive('validarClaveUsuario', function ($http, $q) {
    return {
        restrict: 'A',
        require: 'ngModel',
        link: function ($scope, element, attr, ngModel) {
            var validar = attr.validarClaveUsuario;
            var index = attr.index;
            var url = window.sessionStorage.getItem('URL');
            if (validar == "true") {
                element.ready(function () {
                    if ($scope.Action == "Create") {
                        ngModel.$asyncValidators.claveUsuarioRepetida = function (modelValue, viewValue) {
                            var deferred = $q.defer();
                            $http({
                                url: url + '/api/Usuario/ValidarClaveUsuario?ClaveUsuario=' + modelValue,
                             
                                method: 'get',
                                headers: {
                                    Authorization: window.sessionStorage.getItem('Token'),
                                    'Content-type':'application/JSON'
                                }
                            }).success(function (data, staus) {
                                if (data == true) {
                                    deferred.reject();
                                } else {
                                    deferred.resolve();
                                }
                            }).error(function (error,status) {
                            });
                            return deferred.promise;
                        };
                    }
                });
            }
        }
    }
});