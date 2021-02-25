//Primera versión
var app = angular.module("promociones", ["translation", "valorReferencia", "defaultBox", "messageBoxAux", "messageBox"])

app.controller("promocionesCtrl", ["$scope", "$http", "translationService", "valorReferencia", "defaultBox", "messageBoxAux", "messageBox", function ($scope, $http, translationService, valorReferencia, defaultBox, messageBoxAux, messageBox) {

    //Variables para los tree-grid////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    $scope.Opcion = "";

    //Clientes
    $scope.EsquemasClientes = [];
    $scope.EsquemasCliNuevo = [];
    $scope.EsquemasCliElimi = [];

    //Modulos
    $scope.EsquemasModulos = [];
    $scope.EsquemasModNuevo = [];
    $scope.EsquemasModElimi = [];

    //Productos
    $scope.EsquemasProductos = [];
    $scope.AllProducts = [];

    $scope.reverseEC = true;
    $scope.reverseEM = true;

    //Modulo Anterior
    $scope.ModuloAnterior = "";
    $scope.NombreAnterior = "";

    //Reglas
    $scope.EsquemasReglas = [];
    $scope.AllReglas = [];

    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    $scope.Clave = "";
    $scope.Estado = "";
    $scope.Nombre = "";
    $scope.Obligatoria = "";
    $scope.FechaI = "";
    $scope.FechaF = "";
    $scope.Tipo = "";
    $scope.Aplicacion = "";
    $scope.TipoRegla = "";
    $scope.PCascada = "";
    $scope.Rango = "";
    $scope.SeleccionP = "";
    $scope.CapturaC = "";
    $scope.BackOrder = "";
    $scope.InventarioP = "";
    $scope.NDProducto = "";
    $scope.ValidarEC = "";

    //Variables de solo lectura///////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    $scope.SLO = false;
    $scope.SLP = false;
    $scope.SLTR = false;
    $scope.SLR = false;
    $scope.SLSP = true;
    $scope.SLCC = true;
    $scope.SLBO = true;
    $scope.SLNDP = true;
    $scope.SLVEC = false;
    $scope.SLT = false;

    $scope.EsquemaCliente = true;
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    //Variables de seleccion///////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    $scope.OcultarT = "!-1";
    $scope.OcultarR = "!-1";
    $scope.OCA = false;
    $scope.CKO = false;
    $scope.CKP = false;
    $scope.CKSP = false;
    $scope.CKCC = false;
    $scope.CKBO = false;
    $scope.CKNDP = false;
    $scope.CKVEC = false;

    //$scope.MPE = false;
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    //Crear/Modificar/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    $scope.CM = true;
    $scope.CreateUpdate = function () {
        if ($scope.CM === true) {
            $scope.Estado = "1";
        }
    };
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    //Date Pickers/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    $scope.hoy = new Date();
    $scope.hoy.setDate($scope.hoy.getDate() - 1);
    $scope.FechaI = new Date();
    $scope.FechaF = new Date();
    $scope.FechaF.setDate($scope.FechaF.getDate() + 1);

    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    //Tree-grid///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    $scope.myTreeControl = {};
    $scope.myTreeControl.click = function (branch) {
        console.log("You clicked this branch:", branch)
        //alert("clicked:"+branch.Cla);
    }
    $scope.myTreeControl.MarcadaC = function (branch) {
        $scope.ActivoC = false;
        for (var i = 0; i < $scope.EsquemasCliNuevo.length; i++) {
            if ($scope.EsquemasCliNuevo[i].Clave === branch.Clave) {
                $scope.ActivoC = true;
            }
        }
        return $scope.ActivoC;
    }

    //$scope.myTreeControl.CambiarEsquema = function (branch) {
    //    $scope.EsquemaID = branch.Clave + "OR F10004";
    //}
    $scope.myTreeControl.CambiarEsquema = function (branch) {
        $scope.EsquemaID = branch.Clave
        $scope.ObtenerProductosE();
    }
    $scope.myTreeControl.scope = this;

    //Inicializacion de variables para esquemas Productos
    $scope.tree_productos = [];
    $scope.expanding_property = {
        field: "Nombre"
        //cellTemplate: '<span style="opacity: 0;">Sp</span><input type="checkbox" ng-visible = "treeControl.CambiarEsquema()" ng-checked = "" ng-click="" ng-model="row.branch.Checked"><span style="opacity: 0;">Extra Space</span>'
    }
    $scope.col_defs = [];

    //Inicializacion de variables para esquemas Clientes
    $scope.esquemaDisponible_EC = true;
    $scope.tree_EC = [];
    $scope.expanding_property_EC = {
        field: "EsquemaID",
        displayName: " ",
        cellTemplate: '<span style="opacity: 0;">Sp</span><input type="checkbox" ng-checked = "treeControl.MarcadaC(row.branch)" ng-click="treeControl.click(row.branch.$index);" ng-model="row.branch.Checked"><span style="opacity: 0;">Extra Space</span>'
    };
    //$scope.tree_EC = [];
    //$scope.expanding_property_EC = {
    //    field: "EsquemaID"
    //};
    $scope.NombreEstatusEsquema = "";
    $scope.col_defs_EC = [
        { field: "Nombre" },
        { field: "Abreviatura" },
        { field: "Orden" },
        { field: "Clave" },
        { field: "Tipo" },
        { field: "Clasificacion" },
        { field: "TipoEstado", displayName: "Estado" }
    ];
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    //Inicializacion de variables para esquemas Modulos
    $scope.esquemaDisponible_EM = true;
    $scope.tree_EM = [];
    $scope.expanding_property_EM = {
        field: "EsquemaID",
        displayName: " ",
        cellTemplate: '<span style="opacity: 0;">Sp</span><input type="checkbox" ng-checked = "treeControl.MarcadaM(row.branch)" ng-click="treeControl.click(row.branch.$index);" ng-model="row.branch.Checked"><span style="opacity: 0;">Extra Space</span>'
    };
    $scope.NombreEstatusEsquema = "";
    $scope.col_defs_EC = [
        { field: "Nombre" },
        { field: "Abreviatura" },
        { field: "Orden" },
        { field: "Clave" },
        { field: "Tipo" },
        { field: "Clasificacion" },
        { field: "TipoEstado", displayName: "Estado" }
    ];

    $scope.Iniciar = false;
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    //Ordenar las columnas de la tabla
    $scope.sort = function (keyname) {
        $scope.sortKey = keyname;
        $scope.reverse = !$scope.reverse;
    };

    //Obtener Esquemas
    $scope.Esquemas = function () {
        $http({
            url: url + '/api/Promociones/ObtenerEsquemas',
            metohod: 'GET',
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-Type': 'application/json'
            }
        }).then(function successCallback(response) {
            $scope.treeViewEsquema = response.data;
            $scope.tree_productos = response.data;
        }, function errorCallback(response) {
            $scope.error = { message: response.error, status: response.status };
            console.log($scope.error);
        });
    }

    ////Obtener Esquemas
    //$scope.EsquemasCli = function () {
    //    $http({
    //        url: url + '/api/Promociones/ObtenerEsquemasCli',
    //        metohod: 'GET',
    //        headers: {
    //            Authorization: window.sessionStorage.getItem('Token'),
    //            'Content-Type': 'application/json'
    //        }
    //    }).then(function successCallback(response) {
    //        $scope.treeViewEsquema = response.data;
    //        $scope.tree_EC = response.data;
    //    }, function errorCallback(response) {
    //        $scope.error = { message: error, status: status };
    //        console.log($scope.error);
    //    });
    //}
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    //Inicializacion de variables para promociones
    translationService.getTranslation($scope);
    var url = window.sessionStorage.getItem('URL');

    //Permisos
    $scope.AsignarPermisoPromociones = function (Permiso) {
        $scope.Permiso = Permiso;
    };

    //Ordenar las columnas de la tabla Esquema Clientes
    $scope.sortEC = function (keyname) {
        $scope.Lock = "Editable";
        $scope.sortKeyEC = keyname;
        $scope.reverseEC = !$scope.reverseEC;
    };

    //Ordenar las columnas de la tabla Esquema Clientes
    $scope.sortEM = function (keyname) {
        $scope.Lock = "Editable";
        $scope.sortKeyEM = keyname;
        $scope.reverseEM = !$scope.reverseEM;
    };

    //Obtener promociones
    $scope.ObtenerPromociones = function () {
        $http({
            url: url + '/api/Promociones/ObtenerPromociones',
            method: 'get',
            headers: {
                Authorization: window.sessionStorage.getItem("Token"),
                'Content-Type': 'Aplication/json'
            }
        }).then(function successCallback(response) {
            $scope.promociones = response.data;
        }, function errorCallback(response) {
        })
    };

    $scope.CadenaEntrada = function () {
        $scope.x = $scope.FechaI;
    };

    //Obtener Estado
    $scope.ObtenerEstado = function () {
        valorReferencia.obtenerValores('EDOREG', function (result) {
            $scope.edoreg = result;
        })
    };

    //Obtener Tipo
    $scope.ObtenerTipo = function () {
        valorReferencia.obtenerValores('TPROM', function (result) {
            $scope.tprom = result;
        })
    };

    //Obtener Aplicacion
    $scope.ObtenerAplicacion = function () {
        valorReferencia.obtenerValores('TAPPROM', function (result) {
            $scope.tapprom = result;
        })
    };

    //Obtener Regla
    $scope.ObtenerTipoRegla = function () {
        valorReferencia.obtenerValores('APLRANGO', function (result) {
            $scope.aplrango = result;
        })
    };

    //Obtener Rango
    $scope.ObtenerRango = function () {
        valorReferencia.obtenerValores('PRMRAN', function (result) {
            $scope.prmran = result;
        })
    };

    //Transformar fecha para comparar
    $scope.yyyymmdd = function (dateIn) {
        var yyyy = dateIn.getFullYear();
        var mm = dateIn.getMonth() + 1; // getMonth() is zero-based
        var dd = dateIn.getDate();
        return String(10000 * yyyy + 100 * mm + dd); // Leading zeros for mm and dd
    };

    //Validar Fecha Fin
    $scope.ValidarFin = function () {
        if ($scope.yyyymmdd($scope.FechaF) < $scope.yyyymmdd($scope.FechaI)) {
            $scope.FechaAux = $scope.FechaI;
            $scope.FechaAux.setDate($scope.FechaAux.getDate() + 1);
            $scope.FechaF = $scope.FechaAux;
        }
    };

    //Tipo
    $scope.SoloLecturaF = function () {
        $scope.OcultarT = "!-1";
        $scope.OcultarR = "!-1";
        $scope.SLO = false;
        $scope.SLP = false;
        $scope.SLTR = false;
        $scope.SLR = false;
        $scope.CKO = false;
        $scope.CKP = false;
        $scope.SLSP = true;
        $scope.CKSP = false;
        $scope.SLCC = true;
        $scope.CKCC = false;
        $scope.SLBO = true;
        $scope.CKBO = false;
        $scope.SLNDP = true;
        $scope.CKNDP = false;
        $scope.SLVEC = false;
        $scope.CKVEC = false;
        $scope.BackOrder = false;
        $scope.SLT = false;
        $scope.OCA = false;
        //$scope.MPE = false;
        $scope.EsquemaCliente = true;
        if ($scope.Tipo === "1") {
            $scope.SLVEC = true;
            //$scope.ValidarEC = false;
        }
        if ($scope.Tipo === "3") {
            $scope.SLO = true;
            $scope.OcultarT = '4';
            $scope.SLTR = true;
            $scope.TipoRegla = "2";
            $scope.SLR = true;
            $scope.Rango = "1";
        }
        if ($scope.Tipo === "4") {
            $scope.SLP = true;
            $scope.OcultarT = '!3';
            $scope.PCascada = false;
            if ($scope.TipoRegla === '2') {
                $scope.OCA = true;
            }
        }
        if ($scope.Tipo === "5") {
            $scope.SLO = true;
            $scope.SLP = true;
            $scope.CKO = true;
            $scope.CKP = true;
            $scope.OcultarT = '2';
            $scope.SLR = true;
            $scope.Rango = "1";
            $scope.MostrarPE = true;
        }
        if ($scope.Tipo === "2" || $scope.Tipo === "3" || $scope.Tipo === "4" || $scope.Tipo === "5" || $scope.Tipo === "6") {
            $scope.EsquemaCliente = false;
        }
        if ($scope.Aplicacion === "4") {
            $scope.SLO = true;
            $scope.SLSP = false;
            $scope.SLBO = false;
            $scope.CKBO = true;
            $scope.BackOrder = true;
        }
        if ($scope.Aplicacion !== "4") {
            //Limpiar variables
            $scope.SeleccionP = false;
        }
        if ($scope.TipoRegla === "2") {
            $scope.OcultarR = '!3'
        }
        if ($scope.SeleccionP === true) {
            $scope.SLCC = false;
            $scope.SLNDP = false;
        }
        if ($scope.SeleccionP === false) {
            //Limpiar variables
            $scope.CapturaC = false;
            $scope.NDProducto = false;
        }
        if ($scope.EsquemasClientes.length > 0) {
            $scope.SLT = true;
        }
        else {
            $scope.SLT = false;
        }
    };

    //Boton Cancelar
    $scope.ValidarCancelar = function () {
        if (!$scope.form.$pristine && !$scope.SoloLectura) {
            $scope.Action = "Cancel";
            $scope.lblMsgTitulo = $scope.translation.XCancelar;
            $scope.lblMsgMensaje = $scope.translation.BP0001;
            messageBoxAux.MostrarSiNo();
        }
        else {
            window.location.href = '../Promociones/Index?Permiso=' + $scope.Permiso;
        }
    };

    //MsgBoxAux
    $scope.MsgBoxAux = function () {
        messageBoxAux.Cerrar();
    };

    //AceptarYesNoMsgBox
    $scope.AceptarYesNoMsgBox = function () {
        messageBoxAux.Cerrar();
        if ($scope.Action === "Cancel") {
            window.location.href = '../Promociones/Index?Permiso=' + $scope.Permiso;
        }
    };

    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    //Esquemas Clientes//////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //Remover Elemento de la lista y agregarlo a la final
    $scope.RemoverCliente = function (index, Clave, Permiso) {
        if (!Permiso) {
            $scope.EsquemasCliElimi.splice(0, 0, Clave);
            $scope.EsquemasClientes.splice(index, 1);
            if ($scope.EsquemasClientes.length > 0) {
                if ($scope.EsquemasClientes[$scope.EsquemasClientes.length - 1].Nombre === "") {
                    $scope.EsquemasClientes.splice($scope.EsquemasClientes.length - 1, 1);
                }
            }
            $scope.SoloLecturaF();
        }
    };

    //Agregar desde la tabla -> Clientes
    $scope.NuevoEC = function () {
        var aux = false;
        if ($scope.EsquemasClientes.length > 0) {
            for (var i = 0; i < $scope.EsquemasClientes.length - 1; i++) {
                if ($scope.EsquemasClientes[i].Nombre === "") {
                    $scope.RecuperarEC($scope.EsquemasClientes[i]);
                    if ($scope.EsquemasClientes[i].Nombre !== "") {

                    }
                    else {
                        aux = true;
                    }
                }
            }
            if (aux === true) {
                if ($scope.EsquemasClientes[$scope.EsquemasClientes.length - 1].Nombre === "") {
                    $scope.EsquemasClientes.splice($scope.EsquemasClientes.length - 1, 1);
                }
            }
            else {
                //$scope.Almacenar = false;
                if ($scope.EsquemasClientes[$scope.EsquemasClientes.length - 1].Nombre === "") {
                    if ($scope.EsquemasClientes[$scope.EsquemasClientes.length - 1].Clave !== "null" && $scope.EsquemasClientes[$scope.EsquemasClientes.length - 1].Clave !== null && $scope.EsquemasClientes[$scope.EsquemasClientes.length - 1].Clave !== "") {
                        $scope.CrearC = true;
                        $scope.RecuperarEC($scope.EsquemasClientes[$scope.EsquemasClientes.length - 1]);
                    }
                }
                else {
                    $scope.EsquemasClientes.push({ 'Clave': "", 'Nombre': "", 'EsquemaID': "", 'Estado': "", 'Editable': "0", 'Modificar': false });
                }
            }
        }
        else {
            $scope.EsquemasClientes.push({ 'Clave': "", 'Nombre': "", 'EsquemaID': "", 'Estado': "", 'Editable': "0", 'Modificar': false });
        }
        $scope.SoloLecturaF();
    };

    //Validar clave ingresada
    $scope.ValidarEC = function (event, EC) {
        //var aux = "";
        if (event.which === 13) {
            //$scope.CrearC = false;
            //$scope.RecuperarEC(EC);
            $scope.NuevoEC();
        }
    };

    //Recuperar Registro
    $scope.RecuperarEC = function (EC) {
        var Cliente = EC.Clave;
        $http({
            url: url + '/api/Promociones/ObtCliente?Clave=' + Cliente,
            method: 'get',
            headers: {
                Authorization: window.sessionStorage.getItem("Token"),
                'Content-Type': 'Aplication/json'
            }
        }).then(function successCallback(response) {
            if (Cliente !== "null" && Cliente !== null && Cliente !== "") {
                if (response.data.length > 0) {
                    angular.forEach(response.data, function (v, k) {
                        var aux = false;
                        for (var j = 0; j < $scope.EsquemasClientes.length; j++) {
                            if (v.Clave === $scope.EsquemasClientes[j].Clave && $scope.EsquemasClientes[j] !== EC) {
                                aux = true;
                            }
                        }
                        if (!aux) {
                            $scope.DeleteLast(EC);
                            if (v.TipoEstado === "1") {
                                EC.Clave = v.Clave;
                                EC.Nombre = v.Nombre;
                                EC.EsquemaID = v.EsquemaID;
                                EC.TipoEstado = v.TipoEstado;
                                EC.Editable = v.Editable;
                                if ($scope.CrearC === true) {
                                    $scope.NuevoEC();
                                }
                            }
                            else {
                                $scope.lblMsgTitulo = $scope.translation.XMensajeE;
                                $scope.lblMsgMensaje = $scope.translation.E0574;
                                messageBoxAux.Mostrar();
                            }
                        }
                        else {
                            $scope.lblMsgTitulo = $scope.translation.XMensajeE;
                            $scope.lblMsgMensaje = $scope.translation.BE0002;
                            messageBoxAux.Mostrar();
                            EC.Clave = "";
                        }
                    })
                }
                else {
                    $scope.Crear = false;
                    $scope.lblMsgTitulo = $scope.translation.XMensajeE;
                    $scope.lblMsgMensaje = $scope.translation.E0013;
                    messageBoxAux.Mostrar();
                }
            }
            else {
                $scope.CrearC = false;
            }
        }, function errorCallback(response) {
        })
    };

    $scope.DeleteLast = function (EC) {
        if ($scope.EsquemasClientes[$scope.EsquemasClientes.length - 1] !== EC) {
            if ($scope.EsquemasClientes[$scope.EsquemasClientes.length - 1].Nombre === "") {
                $scope.EsquemasClientes.splice($scope.EsquemasClientes.length - 1, 1);
            }
        }
    };

    //Seleccionar Esquemas Clientes
    $scope.SeleccionarClientes = function () {
        if ($scope.EsquemasClientes.length > 0) {
            if ($scope.EsquemasClientes[$scope.EsquemasClientes.length - 1].Nombre === "") {
                $scope.EsquemasClientes.splice($scope.EsquemasClientes.length - 1, 1);
            }
        }
        defaultBox.Mostrar('', '', 'EsquemaClientesBox');
    };

    //Obtener Esquemas Cliente
    $scope.Esquema_EC = function () {
        $http({
            url: url + '/api/Promociones/EsquemaCliente',
            metohod: 'GET',
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-Type': 'application/json'
            }
        }).then(function successCallback(response) {
            $scope.treeViewEsquema = response.data;
            $scope.tree_EC = response.data;
        }, function errorCallback(response) {
            $scope.error = { message: response.error, status: response.status };
            console.log($scope.error);
        });
    };

    //Agregar cliente nuevo a la tabla donde se llamo
    $scope.AddCliente = function (Clave, Nombre, EsquemaID) {
        var aux = false;
        for (var i = 0; i < $scope.EsquemasCliNuevo.length; i++) {
            if ($scope.EsquemasCliNuevo[i].Clave === Clave) {
                aux = true;
            }
        }
        if (!aux) {
            $scope.EsquemasCliNuevo.push({ 'Clave': Clave, 'Nombre': Nombre, 'EsquemaID': EsquemaID, 'Estado': 1, 'Editable': "1" });
        }
        else {
            angular.forEach($scope.EsquemasCliNuevo, function (value, key) {
                if (value.Clave === Clave) {
                    $scope.EsquemasCliNuevo.splice(key, 1);
                }
            });
        }
    };

    //Agregar productos a la lista final
    $scope.AddFinalC = function () {
        for (var i = 0; i < $scope.EsquemasCliNuevo.length; i++) {
            var aux = false;
            for (var j = 0; j < $scope.EsquemasClientes.length; j++) {
                if ($scope.EsquemasCliNuevo[i].Clave === $scope.EsquemasClientes[j].Clave) {
                    aux = true;
                }
            }
            if (!aux) {
                $scope.EsquemasClientes.push({ 'Clave': $scope.EsquemasCliNuevo[i].Clave, 'Nombre': $scope.EsquemasCliNuevo[i].Nombre, 'EsquemaID': $scope.EsquemasCliNuevo[i].EsquemaID, 'Estado': 1, 'Editable': "1", 'Modificar': false });
            }
        }
        //$scope.Ordenar();
        $scope.EsquemasCliNuevo = [];
    };
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    //////Esquemas Modulos/////////////////////////////////////////////////////////////////////////////////////////////////////////
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////Remover Elemento de la lista y agregarlo a la final
    $scope.RemoverModulo = function (index, Clave, Permiso) {
        if (!Permiso) {
            $scope.EsquemasModElimi.splice(0, 0, Clave);
            $scope.EsquemasModulos.splice(index, 1);
            if ($scope.EsquemasModulos.length > 0) {
                if ($scope.EsquemasModulos[$scope.EsquemasModulos.length - 1].Modulo === "") {
                    $scope.EsquemasModulos.splice($scope.EsquemasModulos.length - 1, 1);
                }
            }
            $scope.SoloLecturaF();
        }
    };

    //Agregar desde la tabla
    $scope.NuevoEM = function () {
        var aux = false;
        if ($scope.EsquemasModulos.length > 0) {
            for (var i = 0; i < $scope.EsquemasModulos.length - 1; i++) {
                if ($scope.EsquemasModulos[i].Nombre === "") {
                    $scope.RecuperarEM($scope.EsquemasModulos[i]);
                    if ($scope.EsquemasModulos[i].Nombre !== "") {

                    }
                    else {
                        aux = true;
                    }
                }
            }
            if (aux === true) {
                if ($scope.EsquemasModulos[$scope.EsquemasModulos.length - 1].Nombre === "") {
                    $scope.EsquemasModulos.splice($scope.EsquemasModulos.length - 1, 1);
                }
            }
            else {
                //$scope.Almacenar = false;
                if ($scope.EsquemasModulos[$scope.EsquemasModulos.length - 1].Nombre === "") {
                    if ($scope.EsquemasModulos[$scope.EsquemasModulos.length - 1].Modulo !== "null" && $scope.EsquemasModulos[$scope.EsquemasModulos.length - 1].Modulo !== null && $scope.EsquemasModulos[$scope.EsquemasModulos.length - 1].Modulo !== "") {
                        $scope.CrearM = true;
                        $scope.RecuperarEM($scope.EsquemasModulos[$scope.EsquemasModulos.length - 1]);
                    }
                }
                else {
                    $scope.EsquemasModulos.push({ 'Modulo': "", 'Nombre': "", 'Estado': "", 'AplicaDescuento': "0", 'Editable': "0", 'Modificar': false });
                }
            }
        }
        else {
            $scope.EsquemasModulos.push({ 'Modulo': "", 'Nombre': "", 'Estado': "", 'AplicaDescuento': "0", 'Editable': "0", 'Modificar': false });
        }
        $scope.SoloLecturaF();
    };

    ////Obtener Esquemas Hijos
    //$scope.ObtenerHijos = function () {
    //    $http({
    //        url: url + '/api/Promociones/ObtenerHijos',
    //        method: 'get',
    //        headers: {
    //            Authorization: window.sessionStorage.getItem("Token"),
    //            'Content-Type': 'Aplication/json'
    //        }
    //    }).then(function successCallback(response) {
    //            $scope.EsquemaID = "in";
    //            for (var i = 0; i < response.data.length; i++) {
    //                if (i + 1 === response.data.length) {
    //                    $scope.EsquemaID += "";
    //                }
    //                else {
    //                    $scope.EsquemaID += "";
    //                }
    //            };
    //            //$scope.modulos = response.data;
    //        }, function errorCallback(response) {
    //        })
    //};

    //Obtener promociones
    $scope.ObtenerModulos = function () {
        $http({
            url: url + '/api/Promociones/ObtenerModulos',
            method: 'get',
            headers: {
                Authorization: window.sessionStorage.getItem("Token"),
                'Content-Type': 'Aplication/json'
            }
        }).then(function successCallback(response) {
            $scope.modulos = response.data;
        }, function errorCallback(response) {
        })
    };

    //Recuperar Registro
    $scope.RecuperarEM = function (EM) {
        var Modulo = EM.Modulo
        $http({
            url: url + '/api/Promociones/ObtModulo?Clave=' + Modulo,
            method: 'get',
            headers: {
                Authorization: window.sessionStorage.getItem("Token"),
                'Content-Type': 'Aplication/json'
            }
        }).then(function successCallback(response) {
            if (Modulo !== "null" && Modulo !== null && Modulo !== "") {
                if (response.data.length > 0) {
                    angular.forEach(response.data, function (v, k) {
                        var aux = false;
                        for (var j = 0; j < $scope.EsquemasModulos.length; j++) {
                            if (v.ModuloMovDetalleClave === $scope.EsquemasModulos[j].Modulo && $scope.EsquemasModulos[j] !== EM) {
                                aux = true;
                            }
                        }
                        if (!aux) {
                            $scope.DeleteLastM(EM);
                            if (v.TipoEstado === "1") {
                                EM.Modulo = v.ModuloMovDetalleClave;
                                EM.Nombre = v.Nombre;
                                EM.Estado = v.Estado;
                                EM.Editable = "1";
                                EM.AplicaDescuento = "0";
                                if ($scope.CrearM === true) {
                                    $scope.NuevoEM();
                                }
                            }
                            else {
                                $scope.lblMsgTitulo = $scope.translation.XMensajeE;
                                $scope.lblMsgMensaje = $scope.translation.E0574;
                                messageBoxAux.Mostrar();
                            }
                        }
                        else {
                            $scope.lblMsgTitulo = $scope.translation.XMensajeE;
                            $scope.lblMsgMensaje = $scope.translation.BE0002;
                            messageBoxAux.Mostrar();
                            EM.Modulo = "";
                        }
                    })
                }
                else {
                    $scope.Crear = false;
                    $scope.lblMsgTitulo = $scope.translation.XMensajeE;
                    $scope.lblMsgMensaje = $scope.translation.E0013;
                    messageBoxAux.Mostrar();
                }
            }
            else {
                $scope.CrearM = false;
            }
        }, function errorCallback(response) {
        })
    };

    $scope.DeleteLastM = function (EM) {
        if ($scope.EsquemasModulos[$scope.EsquemasModulos.length - 1] !== EM) {
            if ($scope.EsquemasModulos[$scope.EsquemasModulos.length - 1].Modulo === "") {
                $scope.EsquemasModulos.splice($scope.EsquemasModulos.length - 1, 1);
            }
        }
    };

    //Seleccionar Esquemas Modulos
    $scope.SeleccionarModulos = function () {
        if ($scope.EsquemasModulos.length > 0) {
            if ($scope.EsquemasModulos[$scope.EsquemasModulos.length - 1].Nombre === "") {
                $scope.EsquemasModulos.splice($scope.EsquemasModulos.length - 1, 1);
            }
        }
        defaultBox.Mostrar('', '', 'ModulosBox');
    };

    //Agregar modulo nuevo a la tabla donde se llamo
    $scope.AddModulo = function (Modulo, Nombre, Estado) {
        var aux = false;
        for (var i = 0; i < $scope.EsquemasModNuevo.length; i++) {
            if ($scope.EsquemasModNuevo[i].Modulo === Modulo) {
                aux = true;
            }
        }
        if (!aux) {
            $scope.EsquemasModNuevo.push({ 'Modulo': Modulo, 'Nombre': Nombre, 'Estado': Estado, 'AplicaDescuento': "0", 'Editable': "1" });
        }
        else {
            angular.forEach($scope.EsquemasModNuevo, function (value, key) {
                if (value.Modulo === Modulo) {
                    $scope.EsquemasModNuevo.splice(key, 1);
                }
            });
        }
    };

    //Agregar productos a la lista final
    $scope.AddFinalM = function () {
        for (var i = 0; i < $scope.EsquemasModNuevo.length; i++) {
            var aux = false;
            for (var j = 0; j < $scope.EsquemasModulos.length; j++) {
                if ($scope.EsquemasModNuevo[i].Modulo === $scope.EsquemasModulos[j].Modulo) {
                    aux = true;
                }
            }
            if (!aux) {
                $scope.EsquemasModulos.push({ 'Modulo': $scope.EsquemasModNuevo[i].Modulo, 'Nombre': $scope.EsquemasModNuevo[i].Nombre, 'Estado': $scope.EsquemasModNuevo[i].Estado, 'AplicaDescuento': "0", 'Editable': "1", 'Modificar': false });
            }
        }
        //$scope.Ordenar();
        $scope.EsquemasModNuevo = [];
    };
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    //////Tab Productos////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    $scope.subempresa = [];
    $scope.SubEmpresaID = "";
    $scope.EsquemaID = "Z";

    $scope.ObtenerSubEmpresa = function () {
        $http({
            url: url + '/api/Promociones/ObtenerSubEmpresa',
            method: 'get',
            headers: {
                Authorization: window.sessionStorage.getItem("Token"),
                'Content-Type': 'Aplication/json'
            }
        }).then(function successCallback(response) {
            $scope.subempresa = response.data;
            $scope.IniciarSE();
        }, function errorCallback(response) {
        })
    };

    $scope.IniciarSE = function () {
        $scope.SubEmpresa = $scope.subempresa[0].SubEmpresaId;
        $scope.SubEmpresaID = $scope.SubEmpresa;
    }

    $scope.CambiarSE = function () {
        $scope.SubEmpresaID = $scope.SubEmpresa;
    }

    $scope.ObtenerProductos = function () {
        $http({
            url: url + '/api/Promociones/ObtenerProductos',
            method: 'get',
            headers: {
                Authorization: window.sessionStorage.getItem("Token"),
                'Content-Type': 'Aplication/json'
            }
        }).then(function successCallback(response) {
            $scope.AllProducts = response.data;
        }, function errorCallback(response) {
        })
    };

    $scope.ObtenerProductosE = function () {
        $http({
            url: url + '/api/Promociones/ObtenerProductosE?Condicion=' + $scope.EsquemaID,
            method: 'get',
            headers: {
                Authorization: window.sessionStorage.getItem("Token"),
                'Content-Type': 'Aplication/json'
            }
        }).then(function successCallback(response) {
            $scope.AllProducts = response.data;
            $scope.CargarProductos();
        }, function errorCallback(response) {
        })
    };

    //Agregar producto nuevo a la tabla donde se llamo
    $scope.addProducto = function (ProductoClave, Estado) {
        var status = '1';
        if (Estado === "YES") {
            $scope.EsquemasProductos.push({ 'ProductoClave': ProductoClave, 'Cantidad': 0, 'Jerarquia': 0, 'TipoEstado': 1 });
            return status;
        }
        else {
            status = '0';
            angular.forEach($scope.EsquemasProductos, function (value, key) {
                $scope.EsquemasProductos.splice(key, 1);
            });
            return status;
        }
    };

    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    //////Tab Reglas///////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    /////Editar Prom.//////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    //Editar Promoción
    $scope.EditarPromocion = function (Clave, Permiso, SoloLectura, Opcion) {
        $scope.Permiso = Permiso;
        if (Clave !== "") {
            $http({
                url: window.sessionStorage.getItem("URL") + '/api/Promociones/CargarPromocion?Clave=' + Clave,
                method: 'GET',
                headers: {
                    Authorization: window.sessionStorage.getItem("Token"),
                    'Content-Type': 'Aplication/json'
                }
            }).then(function successCallback(response) {
                angular.forEach(response.data, function (v, k) {
                    $scope.Clave = v.PromocionClave;
                    $scope.Estado = v.TipoEstado.toString();
                    $scope.Nombre = v.Nombre;
                    $scope.Obligatoria = v.Obligatoria;
                    $scope.FechaI = new Date(v.FechaInicial);
                    $scope.FechaF = new Date(v.FechaFinal);
                    $scope.Tipo = v.Tipo.toString();
                    $scope.Aplicacion = v.TipoAplicacion.toString();
                    $scope.TipoRegla = v.TipoRegla.toString();
                    $scope.PCascada = v.PermiteCascada;
                    $scope.Rango = v.TipoRango.toString();
                    $scope.SeleccionP = v.SeleccionProducto;
                    $scope.CapturaC = v.CapturaCantidad;
                    $scope.BackOrder = v.PendienteEntrega;
                    $scope.InventarioP = v.InventarioPromocion;
                    $scope.NDProducto = v.NoDisminuirProducto;
                    $scope.ValidarEC = v.ValidaMultiplesEsquemas;
                    $scope.SoloLecturaF();
                    $scope.ObtenerProductos();
                    $scope.ObtPromocionDetalle($scope.Clave);
                    $scope.ObtPromocionModulo($scope.Clave);
                    $scope.ObtPromocionProducto($scope.Clave);
                    $scope.ObtPromocionRegla($scope.Clave);
                })
            }, function errorCallback(response) {
            })
            $scope.Action = "Edit";
            $scope.SoloLectura = true;
            $scope.Opcion = Opcion;
        }
        else {
            $scope.Action = "Create";
            $scope.SoloLectura = false;
        }
        //Titulos
        if ($scope.Action === "Create") {
            $scope.ModCreate = true;
        }
        else {
            $scope.ModCreate = false;
        }
    };

    //Cargar Promocion Detalle
    $scope.ObtPromocionDetalle = function (Clave) {
        $http({
            url: url + '/api/Promociones/CargarPromocionDetalle?Clave=' + Clave,
            method: 'get',
            headers: {
                Authorization: window.sessionStorage.getItem("Token"),
                'Content-Type': 'Aplication/json'
            }
        }).then(function successCallback(response) {
            $scope.PromocionDetalle = response.data;
            $scope.LlenarPromocionDetalle();
        }, function errorCallback(response) {
        })
    };

    //Agregar productos a la lista final
    $scope.LlenarPromocionDetalle = function () {
        for (var i = 0; i < $scope.PromocionDetalle.length; i++) {
            $scope.EsquemasClientes.push({ 'Clave': $scope.PromocionDetalle[i].Clave, 'Nombre': $scope.PromocionDetalle[i].Nombre, 'EsquemaID': $scope.PromocionDetalle[i].EsquemaID, 'Estado': 1, 'Editable': "1", 'Modificar': true });
        }
    };

    //Cargar Promocion Detalle
    $scope.ObtPromocionModulo = function (Clave) {
        $http({
            url: url + '/api/Promociones/CargarPromocionModulo?Clave=' + Clave,
            method: 'get',
            headers: {
                Authorization: window.sessionStorage.getItem("Token"),
                'Content-Type': 'Aplication/json'
            }
        }).then(function successCallback(response) {
            $scope.PromocionModulo = response.data;
            $scope.LlenarPromocionModulo();
        }, function errorCallback(response) {
        })
    };

    //Agregar productos a la lista final
    $scope.LlenarPromocionModulo = function () {
        for (var i = 0; i < $scope.PromocionModulo.length; i++) {
            $scope.EsquemasModulos.push({ 'Modulo': $scope.PromocionModulo[i].ModuloMovDetalleClave, 'Nombre': $scope.PromocionModulo[i].Nombre, 'Estado': $scope.PromocionModulo[i].TipoEstado, 'AplicaDescuento': $scope.PromocionModulo[i].AplicaDescuento, 'Editable': "1", 'Modificar': true });
        }
    };

    //Cargar Promocion Detalle
    $scope.ObtPromocionProducto = function (Clave) {
        $http({
            url: url + '/api/Promociones/CargarPromocionProducto?Clave=' + Clave,
            method: 'get',
            headers: {
                Authorization: window.sessionStorage.getItem("Token"),
                'Content-Type': 'Aplication/json'
            }
        }).then(function successCallback(response) {
            $scope.PromocionProducto = response.data;
            $scope.LlenarPromocionProducto();
            $scope.CargarProductos();
        }, function errorCallback(response) {
        })
    };

    $scope.ObtPromocionRegla = function (Clave) {
        $http({
            url: url + '/api/Promociones/CargarPromocionRegla?Clave=' + Clave,
            method: 'get',
            headers: {
                Authorization: window.sessionStorage.getItem("Token"),
                'Content-Type': 'Aplication/json'
            }
        }).then(function successCallback(response) {
            $scope.EsquemasReglas = response.data;
            if ($scope.Opcion === "Copy") {
                $scope.Action = "Edit";
                $scope.SoloLectura = false;
                $scope.Clave = $scope.Clave + "_";
            }
        }, function errorCallback(response) {
        })
    };

    //Agregar productos a la lista final
    $scope.LlenarPromocionProducto = function () {
        for (var i = 0; i < $scope.PromocionProducto.length; i++) {
            $scope.EsquemasProductos.push({ 'ProductoClave': $scope.PromocionProducto[i].ProductoClave, 'Cantidad': $scope.PromocionProducto[i].Cantidad, 'Jerarquia': $scope.PromocionProducto[i].Jerarquia, 'TipoEstado': $scope.PromocionProducto[i].TipoEstado });
        }
    };

    $scope.CargarProductos = function () {
        for (var i = 0; i < $scope.EsquemasProductos.length; i++) {
            for (var j = 0; j < $scope.AllProducts.length; j++) {
                if ($scope.EsquemasProductos[i].ProductoClave === $scope.AllProducts[j].ProductoClave) {
                    $scope.AllProducts[j].Checked = true;
                    $scope.AllProducts[j].Estado = '1';
                    $scope.AllProducts[j].Cantidad = $scope.EsquemasProductos[i].Cantidad
                }
            }
        }
    };
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    //////Guardar///////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    //Boton Aceptar
    $scope.ValidarAceptar = function () {
        if (!$scope.form.$valid) {
            $scope.form.submitted = true;
        }
            //Funciona
        else if (($scope.Tipo === 2 || $scope.Tipo === 3 || $scope.Tipo === 4 || $scope.Tipo === 5 || $scope.Tipo === 6) && $scope.EsquemasClientes === "" && $scope.Estado === 1) {
            $scope.lblMsgTitulo = $scope.translation.XMensajeA;
            $scope.lblMsgMensaje = $scope.translation.E0006;
            messageBoxAux.Mostrar();
        }
            //Funciona
        else if ($scope.EsquemasModulos === "" && $scope.Estado === 1) {
            $scope.lblMsgTitulo = $scope.translation.XMensajeA;
            $scope.lblMsgMensaje = $scope.translation.E0021;
            messageBoxAux.Mostrar();
        }
            //Funciona
        else {
            $scope.Guardar();
        }
    };

    //Almacenar Promoción
    $scope.Guardar = function () {
        var promocion = {
            PromocionClave: $scope.Clave,
            TipoEstado: $scope.Estado,
            Nombre: $scope.Nombre,
            Obligatoria: $scope.Obligatoria,
            FechaInicial: $scope.FechaI,
            FechaFinal: $scope.FechaF,
            Tipo: $scope.Tipo,
            TipoAplicacion: $scope.Aplicacion,
            TipoRegla: $scope.TipoRegla,
            PermiteCascada: $scope.PCascada,
            TipoRango: $scope.Rango,
            SeleccionProducto: $scope.SeleccionP,
            CapturaCantidad: $scope.CapturaC,
            PendienteEntrega: $scope.BackOrder,
            InventarioPromocion: $scope.InventarioP,
            NoDisminuirProducto: $scope.NDProducto,
            ValidaMultiplesEsquemas: $scope.ValidarEC,
            MUsuarioID: window.sessionStorage.getItem("USUId"),
            PromocionProducto: $scope.EsquemasProductos
        };
        $http({
            url: window.sessionStorage.getItem("URL") + '/api/Promociones/GuardarPromocion?Promocion=' + promocion,
            method: 'POST',
            data: JSON.stringify(promocion),
            dataType: "json",
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-type': 'application/json'
            }
        }).then(function successCallback(response) {
            for (var i = 0; i < $scope.EsquemasClientes.length; i++) {
                $scope.GuardarPD($scope.EsquemasClientes[i]);
            };
            for (var i = 0; i < $scope.EsquemasModulos.length; i++) {
                $scope.GuardarPM($scope.EsquemasModulos[i]);
            };
            window.location.href = '../Promociones/Index?Permiso=CRUDEOP';
        }, function errorCallback(response) {
            console.log(response.error);
        })
    };

    //Almacenar Promoción Clientes
    $scope.GuardarPD = function (PromocionDetalle) {
        var promocionD = {
            PromocionClave: $scope.Clave,
            EsquemaId: PromocionDetalle.EsquemaID,
            TipoEstado: PromocionDetalle.Estado,
            MUsuarioID: window.sessionStorage.getItem("USUId")
        };
        $http({
            url: window.sessionStorage.getItem("URL") + '/api/Promociones/GuardarPromocionD?PromocionD=' + promocionD,
            method: 'POST',
            data: JSON.stringify(promocionD),
            dataType: "json",
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-type': 'application/json'
            }
        }).then(function successCallback(response) {
            //window.location.href = '../Promociones/Index?Permiso=CRUDEOP';
        }, function errorCallback(response) {
            console.log(response.error);
        })
    };

    //Almacenar Promoción Modulos
    $scope.GuardarPM = function (PromocionModulo) {
        var promocionM = {
            PromocionClave: $scope.Clave,
            ModuloMovDetalleClave: PromocionModulo.Modulo,
            AplicaDescuento: PromocionModulo.AplicaDescuento,
            TipoEstado: PromocionModulo.Estado,
            MUsuarioID: window.sessionStorage.getItem("USUId")
        };
        $http({
            url: window.sessionStorage.getItem("URL") + '/api/Promociones/GuardarPromocionM?PromocionM=' + promocionM,
            method: 'POST',
            data: JSON.stringify(promocionM),
            dataType: "json",
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-type': 'application/json'
            }
        }).then(function successCallback(response) {
            //window.location.href = '../Promociones/Index?Permiso=CRUDEOP';
        }, function errorCallback(response) {
            console.log(response.error);
        })
    };
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
}]);

//Validar Clave de promoción no duplicado
app.directive('validarPromocion', function ($http, $q) {
    return {
        restrict: 'A',
        require: 'ngModel',
        link: function ($scope, element, attr, ngModel) {
            var validar = attr.validarPromocion;
            var index = attr.index;
            var url = window.sessionStorage.getItem('URL');
            if (validar === "true") {
                element.ready(function () {
                    ngModel.$asyncValidators.ValidarPromocion = function (modelValue, viewValue) {
                        var deferred = $q.defer();
                        $http({
                            url: url + '/api/Promociones/ValidarPromocion?Clave=' + modelValue,
                            method: 'get',
                            headers: {
                                Authorization: window.sessionStorage.getItem('Token'),
                                'Content-type': 'application/JSON'
                            }
                        }).then(function successCallback(response) {
                            if (response.data === true) {
                                deferred.reject();
                            } else {
                                deferred.resolve();
                            }
                        }, function errorCallback(response) {
                        });
                        return deferred.promise;
                    };
                });
            }
        }
    }
});

//Validar Fecha inicial mayor o igual a fecha actual
app.directive('validarFechaIni', function ($http, $q) {
    return {
        restrict: 'A',
        require: 'ngModel',
        link: function ($scope, element, attr, ngModel) {
            var validar = attr.validarFechaIni;
            var index = attr.index;
            var url = window.sessionStorage.getItem('URL');
            if (validar === "true") {
                element.ready(function () {
                    ngModel.$asyncValidators.ValidarFechaIni = function (modelValue, viewValue) {
                        var deferred = $q.defer();
                        if (modelValue >= $scope.hoy) {
                            deferred.resolve();
                        }
                        else {
                            deferred.reject();
                        }
                        return deferred.promise;
                    };
                });
            }
        }
    }
});

//Validar Fecha final mayor o igual a fecha inicial
app.directive('validarFechaFin', function ($http, $q) {
    return {
        restrict: 'A',
        require: 'ngModel',
        link: function ($scope, element, attr, ngModel) {
            var validar = attr.validarFechaFin;
            var index = attr.index;
            var url = window.sessionStorage.getItem('URL');
            if (validar === "true") {
                element.ready(function () {
                    ngModel.$asyncValidators.ValidarFechaFin = function (modelValue, viewValue) {
                        var deferred = $q.defer();
                        if ($scope.yyyymmdd(modelValue) >= $scope.yyyymmdd($scope.FechaI)) {
                            deferred.resolve();
                        }
                        else {
                            deferred.reject();
                        }
                        return deferred.promise;
                    };
                });
            }
        }
    }
});