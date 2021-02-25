//Primera versión
var app = angular.module("frecuenciadeRutas", ["translation", "valorReferencia", "defaultBox", "messageBoxAux", "messageBox"])

app.controller("frecuenciadeRutasCtrl", ["$scope", "$http", "translationService", "valorReferencia", "defaultBox", "messageBoxAux", "messageBox", function ($scope, $http, translationService, valorReferencia, defaultBox, messageBoxAux, messageBox) {

    //Variable para Titulos
    $scope.ModCreate = false;

    //Inicializacion de variables para camiones
    translationService.getTranslation($scope);
    var url = window.sessionStorage.getItem('URL');

    //Variables Auxiliares
    $scope.ExisteCombinacion = false;
    $scope.Combo = false;
    $scope.TipoFrecuencia = "1";
    $scope.RutClave = "";
    $scope.FreClave = "";
    $scope.Orden = 0;
    $scope.NuevosList = "";
    $scope.ClienteList = "";
    $scope.EliminarList = "";
    $scope.CambiarList = "";
    $scope.ReordenList = "";
    $scope.Seleccion = "";
    $scope.Asignar = false;
    $scope.NewKey = "";
    $scope.SecList = "";
    $scope.Delete = "";
    $scope.Ocultar = false;
    $scope.Mod = false;
    $scope.ClientesMod = "";
    //$scope.ClienteAux = "";

    //Permisos
    $scope.AsignarPermisoFrecuenciadeRutas = function (Permiso) {
        $scope.Permiso = Permiso;
    };

    //Ordenar las columnas de la tabla
    $scope.sort = function (keyname) {
        $scope.sortKey = keyname;
        $scope.reverse = !$scope.reverse;
    };

    //Obtener la Consulta para Frecuencia de Rutas
    $scope.ObtenerFrecuenciaRutas = function () {
        $http({
            url: url + '/api/FrecuenciadeRutas/ObtenerFrecuenciaRutas',
            method: 'get',
            headers: {
                Authorization: window.sessionStorage.getItem("Token"),
                'Content-Type': 'Aplication/json'
            }
        })
            .success(function (data, state) {
                $scope.Frecuencias = data;
            })
            .error(function (error, state) {
            })
    };

    //Obtener Rutas disponibles
    $scope.ObtenerRutas = function () {
        $http({
            url: url + '/api/FrecuenciadeRutas/ObtenerRutas',
            method: 'get',
            headers: {
                Authorization: window.sessionStorage.getItem("Token"),
                'Content-Type': 'Aplication/json'
            }
        })
            .success(function (data, state) {
                $scope.RutList = data;
            })
            .error(function (error, state) {
            })
    };

    //Obtener Frecuencias disponibles
    $scope.ObtenerFrecuencias = function () {
        $http({
            url: url + '/api/FrecuenciadeRutas/ObtenerFrecuencias',
            method: 'get',
            headers: {
                Authorization: window.sessionStorage.getItem("Token"),
                'Content-Type': 'Aplication/json'
            }
        })
            .success(function (data, state) {
                $scope.FreList = data;
            })
            .error(function (error, state) {
            })
    };

    //Verificar Ruta
    $scope.VerificarRuta = function () {
        var Clave = $scope.RutClave;
        $http({
            url: url + '/api/FrecuenciadeRutas/VerificarRuta?Clave=' + Clave,
            method: 'get',
            headers: {
                Authorization: window.sessionStorage.getItem("Token"),
                'Content-Type': 'Aplication/json'
            }
        })
            .success(function (data, state) {
                angular.forEach(data, function (v, k) {
                    $scope.RutClave = v.RUTClave;
                    $scope.RutDescripcion = v.Descripcion;
                    $scope.RutTipo = v.Tipo;
                })
            })
            .error(function (error, state) {
            })
    };

    //Verificar Clave Combinada
    $scope.ValidarClaveCombo = function () {
        if ($scope.Action != "Change") {
            if (($scope.FreClave == null || $scope.FreClave == "" || $scope.FreClave == " ") && $scope.Combo == true) {
                $scope.SeleccionFre($scope.FreList[0].FrecuenciaClave, $scope.FreList[0].Descripcion);
            }
            var ClaveR = $scope.RutClave;
            var ClaveF = $scope.FreClave;
            $http({
                url: url + '/api/FrecuenciadeRutas/ValidarClaveCombo?ClaveFrecuencia=' + ClaveF + '&ClaveRuta=' + ClaveR,
                method: 'get',
                headers: {
                    Authorization: window.sessionStorage.getItem("Token"),
                    'Content-Type': 'Aplication/json'
                }
            })
                .success(function (data, state) {
                    if (data == true) {
                        $scope.ExisteCombinacion = true;
                        $scope.Asignar = false;
                        $scope.ClienteList = undefined;
                    }
                    else {
                        $scope.ExisteCombinacion = false;
                        if ($scope.FreClave != null && $scope.FreClave != "" && $scope.RutClave != null && $scope.RutClave != "")
                            $scope.Asignar = true;
                        $scope.ObtenerClientes(ClaveR, ClaveF);
                    }
                    $scope.form.$pristine = false;
                })
                .error(function (error, state) {
                })
        }
    };

    //Agregar cliente nuevo a la tabla donde se llamo
    $scope.addCliente = function (Clave, ClienteClave, RazonSocial, NombreCorto, NombreContacto, ClienteDomicilioID, Calle, Colonia, Poblacion, SECId, Estado) {
        if (Estado == "YES") {
            $scope.Orden++;
            if (SECId == "") {
                SECId = $scope.NewKey;
            }
            $scope.ClienteList.push({ 'Orden': $scope.Orden, 'Clave': Clave, 'ClienteClave': ClienteClave, 'RazonSocial': RazonSocial, 'NombreCorto': NombreCorto, 'NombreContacto': NombreContacto, 'ClienteDomicilioID': ClienteDomicilioID, 'Calle': Calle, 'Colonia': Colonia, 'Poblacion': Poblacion, 'SECId': SECId });
        }
        else {
            angular.forEach($scope.ClienteList, function (value, key) {
                if (value.Clave == Clave) {
                    $scope.Orden--;
                    $scope.ClienteList.splice(key, 1);
                }
            });
        }
        $scope.Mod = true
    };

    //Cambiar Frecuencia del cliente
    $scope.CambioCliente = function (Clave, ClienteClave, RazonSocial, NombreCorto, NombreContacto, ClienteDomicilioID, Calle, Colonia, Poblacion, SECId, Estado) {
        if (Estado == "YES") {
            $scope.ClienteList.push({ 'Orden': $scope.Orden, 'Clave': Clave, 'ClienteClave': ClienteClave, 'RazonSocial': RazonSocial, 'NombreCorto': NombreCorto, 'NombreContacto': NombreContacto, 'ClienteDomicilioID': ClienteDomicilioID, 'Calle': Calle, 'Colonia': Colonia, 'Poblacion': Poblacion, 'SECId': SECId });
        }
        else {
            angular.forEach($scope.ClienteList, function (value, key) {
                if (value.Clave == Clave) {
                    $scope.ClienteList.splice(key, 1);
                }
            });
        }
    };

    //Seleccionar Rutas
    $scope.SeleccionarRutas = function () {
        defaultBox.Mostrar('', '', 'SeleccionarRutaBox');
    };

    //Enviar Seleccion
    $scope.Seleccion = function (RUTClave, Descripcion, Tipo) {
        $scope.RutClave = RUTClave;
        $scope.RutDescripcion = Descripcion;
        $scope.RutTipo = Tipo;
    };

    //Verificar Frecuencia
    $scope.VerificarFrecuencia = function () {
        var Clave = $scope.FreClave;
        $http({
            url: url + '/api/FrecuenciadeRutas/VerificarFrecuencia?Clave=' + Clave,
            method: 'get',
            headers: {
                Authorization: window.sessionStorage.getItem("Token"),
                'Content-Type': 'Aplication/json'
            }
        })
            .success(function (data, state) {
                angular.forEach(data, function (v, k) {
                    $scope.FreClave = v.FrecuenciaClave;
                    $scope.FreDescripcion = v.Descripcion;
                })
            })
            .error(function (error, state) {
            })
    };

    //Verificar Frecuencia de Destino
    $scope.VerificarFrecuenciaDestino = function () {
        var Clave = $scope.FreClaveDestino;
        $http({
            url: url + '/api/FrecuenciadeRutas/VerificarFrecuencia?Clave=' + Clave,
            method: 'get',
            headers: {
                Authorization: window.sessionStorage.getItem("Token"),
                'Content-Type': 'Aplication/json'
            }
        })
            .success(function (data, state) {
                angular.forEach(data, function (v, k) {
                    $scope.FreClaveDestino = v.FrecuenciaClave;
                    $scope.FreDescripcionDestino = v.Descripcion;
                })
            })
            .error(function (error, state) {
            })
    };

    //Seleccionar Frecuencias
    $scope.SeleccionarFrecuencias = function () {
        defaultBox.Mostrar('', '', 'SeleccionarFrecuenciaBox');
    };

    //Enviar Seleccion
    $scope.SeleccionFre = function (FrecuenciaClave, FrecuenciaDescripcion) {
        if ($scope.Action != "Change") {
            $scope.FreClave = FrecuenciaClave;
            $scope.FreDescripcion = FrecuenciaDescripcion;
        }
        else {
            $scope.FreClaveDestino = FrecuenciaClave;
            $scope.FreDescripcionDestino = FrecuenciaDescripcion;
        }
    };

    //Boton Cancelar
    $scope.ValidarCancelar = function () {
        if ((!$scope.form.$pristine && !$scope.SoloLectura) || $scope.Mod != false) {
            $scope.Action = "Cancel";
            $scope.lblMsgTitulo = $scope.translation.XCancelar;
            $scope.lblMsgMensaje = $scope.translation.BP0001;
            messageBoxAux.MostrarSiNo();
        }
        else {
            window.location.href = '../FrecuenciadeRutas/Index?Permiso=' + $scope.Permiso;
        }
    };

    //AceptarYesNoMsgBox
    $scope.AceptarYesNoMsgBox = function () {
        messageBoxAux.Cerrar();
        if ($scope.Action == "Cancel") {
            window.location.href = '../FrecuenciadeRutas/Index?Permiso=' + $scope.Permiso;
        }
        else if ($scope.Action == "Limpiar") {
            $scope.Eliminar();
        }
        else {
            
        }
    };

    //Verificar clave secuencia
    $scope.VerificarSecuencia = function () {
        $http({
            url: url + '/api/FrecuenciadeRutas/VerificarSecuencia?Clave=' + $scope.NewKey,
            method: 'get',
            headers: {
                Authorization: window.sessionStorage.getItem("Token"),
                'Content-Type': 'Aplication/json'
            }
        })
            .success(function (data, state) {
                $scope.SecList = data;
                if ($scope.SecList.length == 0) {
                    var lock = true;
                    for (var i = 0; i < $scope.ClienteList.length; i++) {
                        if ($scope.NewKey == $scope.ClienteList[i].SECId) {
                            lock = false;
                        }
                    }
                    if (lock == false) {
                        $scope.KeyGen();
                    }
                }
                else {
                    $scope.KeyGen();
                }
            })
            .error(function (error, state) {
            })
    };

    //Editar Frecuencia
    $scope.EditarFrecuencia = function (Clave, Permiso, SoloLectura) {
        $scope.Permiso = Permiso;
        if (Clave != "") {
            $scope.RutClave = Clave.split("?")[0];
            $scope.VerificarRuta();
            $scope.FreClave = Clave.split("?")[1];
            $scope.VerificarFrecuencia();
            $scope.Asignar = true;
            $scope.ObtenerClientes($scope.RutClave, $scope.FreClave);
            $scope.ObtenerClientesMod($scope.RutClave, $scope.FreClave);
            $scope.ExisteCombinacion = false;
            $scope.Action = "Edit";
            $scope.SoloLectura = true;
            $scope.Modificar = true;
            $scope.ObtenerEliminar($scope.RutClave, $scope.FreClave);
            $scope.ModCreate = true;
        }
        else {
            $scope.Action = "Create";
            $scope.SoloLectura = false;
            $scope.Estado = false;
            $scope.Modificar = false;
            $scope.ModCreate = false;
        }
    };

    //Cambiar Frecuencia
    $scope.CambiarFrecuencia = function (Clave, Permiso, SoloLectura) {
        $scope.Permiso = Permiso;
        if (Clave != "") {
            $scope.RutClave = Clave.split("?")[0];
            $scope.VerificarRuta();
            $scope.FreClave = Clave.split("?")[1];
            $scope.VerificarFrecuencia();
            $scope.Asignar = true;
            $scope.ExisteCombinacion = false;
            $scope.Action = "Change";
            $scope.SoloLectura = true;
            $scope.Modificar = true;
            $scope.Ocultar = true;
            $scope.ObtenerClientes($scope.RutClave, "");
            $scope.ObtenerCambios($scope.RutClave, $scope.FreClave);
        }
    };

    //Almacenar Ruta
    $scope.Guardar = function () {
        for (var z = 0; z < $scope.ClienteList.length; z++) {
            if ($scope.ClienteList[z].SECId != "") {
                $scope.NewKey = $scope.ClienteList[z].SECId;
            }
        }
        var Ruta = {
            RUTClave: $scope.RutClave,
            Descripcion: $scope.FreClave,
            Tipo: $scope.Tipo,
            TipoEstado: $scope.TipoEstado,
            Inventario: $scope.Inventario,
            AlmacenID: $scope.AlmacenIDCEDI,
            CAMPlaca: $scope.Camiones,
            MUsuarioID: window.sessionStorage.getItem("USUId"),
            Secuencia: $scope.ClienteList
        };
        $http({
            url: window.sessionStorage.getItem("URL") + '/api/FrecuenciadeRutas/GuardarFrecuencia?Ruta=' + Ruta,
            method: 'POST',
            data: JSON.stringify(Ruta),
            dataType: "json",
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-type': 'application/json'
            }
        }).success(function (data) {
            window.location.href = '../FrecuenciadeRutas/Index?Permiso=CRUDEOP';
        }).error(function (error) {
            console.log(error);
        })
    };

    //Cambiar Frecuencias
    $scope.GuardarCambios = function () {
        for (var i = 0; i < $scope.ClienteList.length; i++) {
            $scope.KeyGen();
            if ($scope.ClienteList[i].SECId != "") {
                $scope.NewKey = $scope.ClienteList[i].SECId;
            }
            $scope.ClienteList[i].Orden = $scope.Orden + (i + 1);
        }
        var Ruta = {
            RUTClave: $scope.RutClave,
            Descripcion: $scope.FreClaveDestino,
            Tipo: $scope.Tipo,
            TipoEstado: $scope.TipoEstado,
            Inventario: $scope.Inventario,
            AlmacenID: $scope.AlmacenIDCEDI,
            CAMPlaca: $scope.Camiones,
            MUsuarioID: window.sessionStorage.getItem("USUId"),
            Secuencia: $scope.ClienteList
        };
        $http({
            url: window.sessionStorage.getItem("URL") + '/api/FrecuenciadeRutas/GuardarFrecuencia?Ruta=' + Ruta,
            method: 'POST',
            data: JSON.stringify(Ruta),
            dataType: "json",
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-type': 'application/json'
            }
        }).success(function (data) {
            $scope.ObtenerReorden($scope.RutClave, $scope.FreClave);
        }).error(function (error) {
            console.log(error);
        })
    };

    //Eliminar Clientes de la Frecuencia
    $scope.Eliminar = function () {
        angular.forEach($scope.EliminarList, function (value, key) {
            for (var i = 0; i < $scope.ClienteList.length; i++) {
                if (value.SECId == $scope.ClienteList[i].SECId) {
                    $scope.EliminarList.splice(key, 1);
                }
            }
        })

        var Ruta = {
            RUTClave: $scope.RutClave,
            Descripcion: $scope.FreClave,
            Tipo: $scope.Tipo,
            TipoEstado: $scope.TipoEstado,
            Inventario: $scope.Inventario,
            AlmacenID: $scope.AlmacenIDCEDI,
            CAMPlaca: $scope.Camiones,
            MUsuarioID: window.sessionStorage.getItem("USUId"),
            Secuencia: $scope.EliminarList
        };
        $http({
            url: window.sessionStorage.getItem("URL") + '/api/FrecuenciadeRutas/EliminarFrecuencia?Ruta=' + Ruta,
            method: 'POST',
            data: JSON.stringify(Ruta),
            dataType: "json",
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-type': 'application/json'
            }
        }).success(function (data) {
            $scope.Guardar();
        }).error(function (error) {
            console.log(error);
        })
    };

    //Boton Aceptar
    $scope.ValidarAceptar = function () {
        if (!$scope.form.$valid) {
            $scope.form.submitted = true;
        }
        //Funciona
        else if ($scope.ClienteList == "" && $scope.Action == "Create") {
            $scope.lblMsgTitulo = $scope.translation.XMensajeA;
            $scope.lblMsgMensaje = $scope.translation.E0634;
            messageBoxAux.Mostrar();
        }
        //Funciona
        else if ($scope.ClienteList != "" && $scope.Action == "Create") {
            $scope.Guardar();
        }
        //Funciona
        else if ($scope.ClienteList != "" && $scope.Action == "Edit") {
            $scope.ObtenerEliminar($scope.RutClave, $scope.FreClave);
            $scope.Eliminar();
        }
        //Funciona
        else if ($scope.ClienteList == "" && $scope.Action == "Edit") {
            $scope.Action = "Limpiar";
            $scope.lblMsgTitulo = $scope.translation.XMensajeA;
            $scope.lblMsgMensaje = $scope.translation.P0110;
            messageBoxAux.MostrarSiNo();
        }
        //Pruebas
        else if ($scope.Action == "Change") {
            if ($scope.FreClave == $scope.FreClaveDestino || $scope.ClienteList.length <= 0) {
                window.location.href = '../FrecuenciadeRutas/Index?Permiso=' + $scope.Permiso;
            }
            $scope.ObtenerEliminar($scope.RutClave, $scope.FreClaveDestino);
        }
    };

    //MsgBoxAux
    $scope.MsgBoxAux = function () {
        messageBoxAux.Cerrar();
    };

    //Obtener Clientes
    $scope.ObtenerClientesMod = function (RUTClave, FreClave) {
        $http({
            url: url + '/api/FrecuenciadeRutas/ObtenerClientes?RUTClave=' + RUTClave + '&Frecuencia=' + FreClave,
            method: 'get',
            headers: {
                Authorization: window.sessionStorage.getItem("Token"),
                'Content-Type': 'Aplication/json'
            }
        })
            .success(function (data, state) {
                $scope.ClientesMod = data;
            })
            .error(function (error, state) {
            })
    };

    //Obtener Clientes
    $scope.ObtenerClientes = function (RUTClave, FreClave) {
        $http({
            url: url + '/api/FrecuenciadeRutas/ObtenerClientes?RUTClave=' + RUTClave + '&Frecuencia=' + FreClave,
            method: 'get',
            headers: {
                Authorization: window.sessionStorage.getItem("Token"),
                'Content-Type': 'Aplication/json'
            }
        })
            .success(function (data, state) {
                $scope.ClienteList = data;
                $scope.Orden = $scope.ClienteList.length;
            })
            .error(function (error, state) {
            })
    };

    //Obtener Clientes a eliminar
    $scope.ObtenerEliminar = function (RUTClave, FreClave) {
        $http({
            url: url + '/api/FrecuenciadeRutas/ObtenerClientesEliminar?RUTClave=' + RUTClave + '&Frecuencia=' + FreClave,
            method: 'get',
            headers: {
                Authorization: window.sessionStorage.getItem("Token"),
                'Content-Type': 'Aplication/json'
            }
        })
            .success(function (data, state) {
                $scope.EliminarList = data;
                if ($scope.Action == "Change") {
                    $scope.Orden = $scope.EliminarList.length;
                    $scope.GuardarCambios();
                }
            })
            .error(function (error, state) {
            })
    };

    //Obtener Clientes para los cambios
    $scope.ObtenerCambios = function (RUTClave, FreClave) {
        $http({
            url: url + '/api/FrecuenciadeRutas/ObtenerClientes?RUTClave=' + RUTClave + '&Frecuencia=' + FreClave,
            method: 'get',
            headers: {
                Authorization: window.sessionStorage.getItem("Token"),
                'Content-Type': 'Aplication/json'
            }
        })
            .success(function (data, state) {
                $scope.CambiarList = data;
                $scope.Orden = $scope.CambiarList.length;
            })
            .error(function (error, state) {
            })
    };

    //Obtener el nuevo orden de los clientes correspondientes a la ruta donde se cambiaron frecuencias
    $scope.ObtenerReorden = function (RUTClave, FreClave) {
        $http({
            url: url + '/api/FrecuenciadeRutas/ObtenerClientes?RUTClave=' + RUTClave + '&Frecuencia=' + FreClave,
            method: 'get',
            headers: {
                Authorization: window.sessionStorage.getItem("Token"),
                'Content-Type': 'Aplication/json'
            }
        })
            .success(function (data, state) {
                $scope.ReordenList = data;
                if ($scope.ReordenList.length != 0) {
                    $scope.ReOrden();
                }
            })
            .error(function (error, state) {
            })
    };

    //Obtener Clientes Nuevos
    $scope.AsignarClientesNuevos = function (TipoFrecuencia) {
        $http({
            url: url + '/api/FrecuenciadeRutas/AsignarClientesNuevos?RUTClave=' + $scope.RutClave + '&Frecuencia=' + $scope.FreClave + '&Opcion=' + TipoFrecuencia,
            method: 'get',
            headers: {
                Authorization: window.sessionStorage.getItem("Token"),
                'Content-Type': 'Aplication/json'
            }
        })
            .success(function (data, state) {
                $scope.NuevosList = data;
                $scope.Actualizar();
            })
            .error(function (error, state) {
            })
    };

    //Actualizar Frecuencias
    $scope.ReOrden = function () {
        for (var i = 0; i < $scope.ReordenList.length; i++) {
            $scope.ReordenList[i].Orden = (i + 1);
        }
        var Ruta = {
            RUTClave: $scope.RutClave,
            Descripcion: $scope.FreClave,
            Tipo: $scope.Tipo,
            TipoEstado: $scope.TipoEstado,
            Inventario: $scope.Inventario,
            AlmacenID: $scope.AlmacenIDCEDI,
            CAMPlaca: $scope.Camiones,
            MUsuarioID: window.sessionStorage.getItem("USUId"),
            Secuencia: $scope.ReordenList
        };
        $http({
            url: window.sessionStorage.getItem("URL") + '/api/FrecuenciadeRutas/GuardarFrecuencia?Ruta=' + Ruta,
            method: 'POST',
            data: JSON.stringify(Ruta),
            dataType: "json",
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-type': 'application/json'
            }
        }).success(function (data) {
            window.location.href = '../FrecuenciadeRutas/Index?Permiso=' + $scope.Permiso;
        }).error(function (error) {
            console.log(error);
        })
    };

    //Seleccionar clientes
    $scope.AsignarClientes = function () {
        //$scope.ObtenerClientesMod($scope.RutClave, $scope.FreClave);
        defaultBox.Mostrar('', '', 'AsignarClientesBox');
    };

    //Vaciar clientes
    $scope.VaciarClientes = function () {
        $scope.ClientesMod.length = 0;
        for (var i = 0; i < $scope.ClienteList.length; i++) {
            $scope.ClientesMod[i] = $scope.ClienteList[i];
        }
        //$scope.ClienteMod = $scope.ClienteList.slice;
    };

    //Actualizar Checkboxes
    $scope.Actualizar = function () {
        for (var i = 0; i < $scope.Orden; i++) {
            angular.forEach($scope.NuevosList, function (value, key) {
                if (value.Clave == $scope.ClienteList[i].Clave) {
                    value.Checked = true;
                }
            });
        }
    };

    //Reordenar
    $scope.Reordenar = function () {
        for (var i = 0; i < $scope.Orden; i++) {
            $scope.ClienteList[i].Orden = i + 1;
        }
    };

    //Reordenar
    $scope.ReordenarCam = function () {
        for (var i = 0; i < $scope.Orden; i++) {
            $scope.CambiarList[i].Orden = i + 1;
        }
    };

    $scope.Seleccionar = function (Orden) {
        $scope.Seleccion = Orden - 1;
    }

    $scope.EliminarSeleccion = function () {
        $scope.ClienteList.splice($scope.Seleccion, 1);
        $scope.Orden--;
        $scope.Reordenar();
        $scope.Mod = true;
    }

    $scope.SubirPrioridad = function () {
        if ($scope.Seleccion > 0) {
            var aux = $scope.ClienteList[$scope.Seleccion - 1];
            $scope.ClienteList[$scope.Seleccion - 1] = $scope.ClienteList[$scope.Seleccion];
            $scope.ClienteList[$scope.Seleccion] = aux;
            $scope.Seleccion = $scope.Seleccion - 1;
            $scope.Reordenar();
            $scope.Mod = true;
        }
    };

    $scope.SubirPrioridadCam = function () {
        if ($scope.Seleccion > 0) {
            var aux = $scope.CambiarList[$scope.Seleccion - 1];
            $scope.CambiarList[$scope.Seleccion - 1] = $scope.CambiarList[$scope.Seleccion];
            $scope.CambiarList[$scope.Seleccion] = aux;
            $scope.Seleccion = $scope.Seleccion - 1;
            $scope.ReordenarCam();
            $scope.Mod = true;
        }
    };

    $scope.BajarPrioridadCam = function () {
        if ($scope.Seleccion < $scope.Orden - 1) {
            var aux = $scope.CambiarList[$scope.Seleccion + 1];
            $scope.CambiarList[$scope.Seleccion + 1] = $scope.CambiarList[$scope.Seleccion];
            $scope.CambiarList[$scope.Seleccion] = aux;
            $scope.Seleccion = $scope.Seleccion + 1;
            $scope.ReordenarCam();
            $scope.Mod = true;
        }
    };

    $scope.BajarPrioridad = function () {
        if ($scope.Seleccion < $scope.Orden - 1) {
            var aux = $scope.ClienteList[$scope.Seleccion + 1];
            $scope.ClienteList[$scope.Seleccion + 1] = $scope.ClienteList[$scope.Seleccion];
            $scope.ClienteList[$scope.Seleccion] = aux;
            $scope.Seleccion = $scope.Seleccion + 1;
            $scope.Reordenar();
            $scope.Mod = true;
        }
    };

    //Cancelar selección de clientes
    $scope.Cancelar = function () {
        $scope.ClienteList.length = 0;
        for (var i = 0; i < $scope.ClientesMod.length; i++) {
            $scope.ClientesMod[i][0] = i;
            $scope.ClienteList[i] = $scope.ClientesMod[i];
            //$scope.ClienteList[i][]
        }
        //$scope.ClienteList = $scope.ClientesMod.slice;
    };

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
        $scope.VerificarSecuencia();
    };
}]);

//Directivas Propias

//Clave Ruta
app.directive('validarRuta', function ($http, $q) {
    return {
        restrict: 'A',
        require: 'ngModel',
        link: function ($scope, element, attr, ngModel) {
            var validar = attr.validarRuta;
            var index = attr.index;
            var url = window.sessionStorage.getItem('URL');
            if (validar == "true") {
                element.ready(function () {
                    ngModel.$asyncValidators.ValidarRuta = function (modelValue, viewValue) {
                        var deferred = $q.defer();
                        $http({
                            url: url + '/api/FrecuenciadeRutas/ValidarClaveRuta?ClaveRuta=' + modelValue,
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


//Vigencia Frecuencia
app.directive('validarVigenciaFrecuencia', function ($http, $q) {
    return {
        restrict: 'A',
        require: 'ngModel',
        link: function ($scope, element, attr, ngModel) {
            var validar = attr.validarVigenciaFrecuencia;
            var index = attr.index;
            var url = window.sessionStorage.getItem('URL');
            if (validar == "true") {
                element.ready(function () {
                    ngModel.$asyncValidators.ValidarVigenciaFrecuencia = function (modelValue, viewValue) {
                        var deferred = $q.defer();
                        $http({
                            url: url + '/api/FrecuenciadeRutas/ValidarVigenciaFrecuencia?ClaveFrecuencia=' + modelValue,
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

//Clave Frecuencia
app.directive('validarClaveFrecuencia', function ($http, $q) {
    return {
        restrict: 'A',
        require: 'ngModel',
        link: function ($scope, element, attr, ngModel) {
            var validar = attr.validarClaveFrecuencia;
            var index = attr.index;
            var url = window.sessionStorage.getItem('URL');
            if (validar == "true") {
                element.ready(function () {
                    ngModel.$asyncValidators.ValidarClaveFrecuencia = function (modelValue, viewValue) {
                        var deferred = $q.defer();
                        $http({
                            url: url + '/api/FrecuenciadeRutas/ValidarClaveFrecuencia?ClaveFrecuencia=' + modelValue,
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