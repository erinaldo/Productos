//Primera versión
var app = angular.module("rutas", ["translation", "valorReferencia", "defaultBox", "messageBoxAux", "messageBox"])

app.controller("rutasCtrl", ["$scope", "$http", "translationService", "valorReferencia", "defaultBox", "messageBoxAux", "messageBox", function ($scope, $http, translationService, valorReferencia, defaultBox, messageBoxAux, messageBox) {

    $scope.Control = false;
    $scope.rutaC = "";
    $scope.auxClave = "";
    $scope.auxDesc = "";
    $scope.auxCam = "";
    $scope.auxCamNm = "";
    $scope.Mensaje53 = false;
    $scope.Mensaje54 = false;
    $scope.Delete = [];
    $scope.Add = [];
    $scope.Activo = false;
    $scope.EsquemasList = [];
    $scope.ListaEsquemas = [];
    $scope.Crear = false;
    $scope.Almacenar = false;
    $scope.reverse = true;
    $scope.UsuarioA = [];

    //Prueba para funciones del tree-grid
    $scope.myTreeControl = {};
    $scope.myTreeControl.click = function (branch) {
        console.log("You clicked this branch:", branch)
        //alert("clicked");
    }
    $scope.myTreeControl.Marcada = function (branch) {
        $scope.Activo = false;
        for (var i = 0; i < $scope.Add.length; i++) {
            if ($scope.Add[i].Clave === branch.Clave) {
                $scope.Activo = true;
            }
        }
        return $scope.Activo;
    }
    //$scope.myTreeControl.Change = function (branch) {
    //    $scope.addProducto(branch['Clave'], branch['Nombre'], branch['EsquemaID']);
    //}
    $scope.myTreeControl.scope = this;
    /////////////////////////////////////

    //Inicializacion de variables para esquemas
    $scope.cProductoPriorList = [];
    $scope.tree_data = [];
    $scope.esquemaDisponible = true;
    $scope.expanding_property = {
        field: "EsquemaID",
        displayName: " ",
        //cellTemplate: '<span style="opacity: 0;">Sp</span><input type="checkbox" ng-checked = "treeControl.Marcada(row.branch)" ng-click="treeControl.click(row.branch.$index);" ng-model="row.branch.$index"><span style="opacity: 0;">Extra Space</span>'
        //cellTemplate: '<span style="opacity: 0;">Sp</span><input type="checkbox" ng-checked = "treeControl.Marcada(row.branch)" ng-click="treeControl.click(row.branch.$index);" ng-model="row.branch.Checked" ng-change = "treeControl.Change(row.branch)"><span style="opacity: 0;">Extra Space</span>'
        cellTemplate: '<span style="opacity: 0;">Sp</span><input type="checkbox" ng-checked = "treeControl.Marcada(row.branch)" ng-click="treeControl.click(row.branch.$index);" ng-model="row.branch.Checked"><span style="opacity: 0;">Extra Space</span>'
    };
    $scope.NombreEstatusEsquema = "";
    $scope.col_defs = [
        { field: "Nombre" },
        { field: "Abreviatura" },
        { field: "Orden" },
        { field: "Clave" },
        { field: "Tipo" },
        { field: "Clasificacion" },
        { field: "TipoEstado", displayName: "Estado" }
    ];

    //Inicializacion de variables para camiones
    translationService.getTranslation($scope);
    var url = window.sessionStorage.getItem('URL');

    //Permisos
    $scope.AsignarPermisoRutas = function (Permiso) {
        $scope.Permiso = Permiso;
    };

    //Ordenar las columnas de la tabla
    $scope.sort = function (keyname) {
        $scope.Lock = "Editable";
        $scope.sortKey = keyname;
        $scope.reverse = !$scope.reverse;
    };

    $scope.ObtenerRutas = function () {
        $http({
            url: url + '/api/Rutas/ObtenerRutas',
            method: 'get',
            headers: {
                Authorization: window.sessionStorage.getItem("Token"),
                'Content-Type': 'Aplication/json'
            }
        })
            .success(function (data, state) {
                $scope.rutas = data;
            })
            .error(function (error, state) {
            })
    };

    //Obtener el Tipo de ruta
    $scope.TipoRutas = function () {
        valorReferencia.obtenerValores('TINDMOD', function (result) {
            $scope.tindmod = result;
        });
    };

    //Obtener Estado
    $scope.ObtenerEstado = function () {
        valorReferencia.obtenerValores('EDOREG', function (result) {
            $scope.edoreg = result;
        })
    };

    //Obtener Centros de distribucion
    $scope.ObtCentros = function () {
        $http({
            url: url + '/api/Rutas/ObtCentros?Usuario=' + window.sessionStorage.getItem("USUId"),
            method: 'GET',
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-Type': 'application/json'
            }
        })
            .success(function (data, status) {
                $scope.btipouso = data;
                $scope.ValidarUsuario();
            })
            .error(function (error, status) {
                $scope.lblMsgTitulo = "Advertencia";
                $scope.lblMsgMensaje = "El Usuario no Cuenta con CEDIS Asignados para el Filtro";
                messageBoxAux.Mostrar();
            })
    };

    //Obtener Camiones
    $scope.ObtCamiones = function () {
        $http({
            url: url + '/api/Rutas/ObtCamiones',
            method: 'get',
            headers: {
                Authorization: window.sessionStorage.getItem("Token"),
                'Content-Type': 'Aplication/json'
            }
        })
            .success(function (data, state) {
                $scope.CamList = data;
            })
            .error(function (error, state) {
            })
    };

    //Obtener todos los datos de un camión
    $scope.ObtCam = function () {
        var Placa = $scope.Camiones.trim();
        $http({
            url: url + '/api/Rutas/ObtCam?Placa=' + Placa,
            method: 'get',
            headers: {
                Authorization: window.sessionStorage.getItem("Token"),
                'Content-Type': 'Aplication/json'
            }
        })
            .success(function (data, state) {
                angular.forEach(data, function (v, k) {
                    $scope.Camiones = v.Clave;
                    $scope.CamionesNombre = v.Placa;
                })
            })
            .error(function (error, state) {
            })
    };

    //Boton Aceptar/Validar Camion asignado
    $scope.CamionDisponible = function () {
        var Placa = $scope.Camiones;
        $scope.auxClave = "";
        $scope.auxDesc = "";
        $http({
            url: url + '/api/Rutas/CamionDisponible?Placa=' + Placa,
            method: 'get',
            headers: {
                Authorization: window.sessionStorage.getItem("Token"),
                'Content-Type': 'Aplication/json'
            }
        })
            .success(function (data, state) {
                angular.forEach(data, function (v, k) {
                    $scope.auxClave = v.RUTClave;
                    $scope.auxDesc = v.Descripcion;
                    $scope.auxCam = $scope.Camiones;
                    $scope.auxCamNm = v.Placa;
                })
                if ($scope.auxClave != "") {
                    if ($scope.Clave != $scope.auxClave) {
                        if ($scope.Action == "Create") {
                            $scope.lblMsgTitulo = $scope.translation.ERMRUTESC_MGeneralC;
                        }
                        else {
                            $scope.lblMsgTitulo = $scope.translation.ERMRUTESC_MGeneralM;
                        }
                        $scope.lblMsgMensaje = ($scope.translation.P0255.replace('$0$', $scope.Camiones)).replace('$1$', $scope.auxClave);

                        $scope.Camiones = "";
                        $scope.CamionesNombre = "";
                        messageBoxAux.MostrarSiNo();
                    }
                    else {
                        $scope.CamionesNombre = $scope.auxCamNm;
                    }
                }
                else if (Placa != "" && ($scope.auxClave == "" || $scope.auxClave == null)) {
                    $scope.ObtCam();
                }
                else if (Placa == "") {
                    $scope.CamionesNombre = "";
                }
            })
            .error(function (error, state) {
            })
    };

    //Boton Cancelar
    $scope.ValidarUsuario = function () {
        if ($scope.btipouso.length > 0) {
            
        }
        else {
            $scope.lblMsgTitulo = "Advertencia";
            $scope.lblMsgMensaje = "El Usuario no Cuenta con CEDIS Asignados para el Filtro";
            messageBoxAux.Mostrar();
        }
    };
    //    var Usuario = {
    //        MUsuarioID: window.sessionStorage.getItem("USUId")
    //    };
    //    $http({
    //        url: window.sessionStorage.getItem("URL") + '/api/Rutas/UsuarioAlmacen?Usuario=' + Usuario.MUsuarioID,
    //        method: 'GET',
    //        headers: {
    //            Authorization: window.sessionStorage.getItem("Token"),
    //            'Content-Type': 'Aplication/json'
    //        }
    //    }).success(function (data, state) {
    //        $scope.UsuarioA = data;
    //        console.log($scope.UsuarioA.length);
    //    }).error(function (error, state) {
    //        console.log(error);
    //        })
    //};
    //.success(function (data) {
    //        $scope.lblMsgTitulo = "Advertencia";
    //        $scope.lblMsgMensaje = "El Usuario no Cuenta con CEDIS Asignados para el Filtro";
    //        messageBoxAux.Mostrar();
    //    }).error(function (error) {
    //        console.log(error);
    //    })
    //};

    //Boton Cancelar
    $scope.ValidarCancelar = function () {
        if (!$scope.form.$pristine && !$scope.SoloLectura) {
            $scope.Action = "Cancel";
            $scope.lblMsgTitulo = $scope.translation.XCancelar;
            $scope.lblMsgMensaje = $scope.translation.BP0001;
            messageBoxAux.MostrarSiNo();
        }
        else {
            window.location.href = '../Rutas/Index?Permiso=' + $scope.Permiso;
        }
    };

    //AceptarYesNoMsgBox
    $scope.AceptarYesNoMsgBox = function () {
        messageBoxAux.Cerrar();
        if ($scope.Action == "Cancel") {
            window.location.href = '../Rutas/Index?Permiso=' + $scope.Permiso;
        }
        else {
            $scope.Camiones = $scope.auxCam;
            $scope.CamionesNombre = $scope.auxCamNm;
        }
    };

    //Limpiar CAMplaca
    $scope.CAMPlacaClean = function () {
        if (Camiones == "")
            $scope.form.Camiones.$valid = true;
        if (!$scope.form.$valid) {
            $scope.form.submitted = true;
        }
        else {
            var Ruta = {
                RUTClave: $scope.auxClave
            };

            $http({
                url: window.sessionStorage.getItem("URL") + '/api/Rutas/CAMPlacaClean?Ruta=' + Ruta,
                method: 'POST',
                data: JSON.stringify(Ruta),
                dataType: "json",
                headers: {
                    Authorization: window.sessionStorage.getItem('Token'),
                    'Content-type': 'application/json'
                }
            }).success(function (data) {
                $scope.GuardarRuta();
            }).error(function (error) {
                console.log(error);
            });

        }
    };

    //Almacenar Rutas
    $scope.GuardarRuta = function () {
        if (!$scope.form.$valid) {
            $scope.form.submitted = true;
        }
        else {
            var Ruta = {
                RUTClave: $scope.Clave,
                Descripcion: $scope.Descripcion,
                Tipo: $scope.Tipo,
                TipoEstado: $scope.TipoEstado,
                Inventario: $scope.Inventario,
                AlmacenID: $scope.AlmacenIDCEDI,
                CAMPlaca: $scope.Camiones,
                MUsuarioID: window.sessionStorage.getItem("USUId")
            };

            $http({
                url: window.sessionStorage.getItem("URL") + '/api/Rutas/GuardarRuta?Ruta=' + Ruta,
                method: 'POST',
                data: JSON.stringify(Ruta),
                dataType: "json",
                headers: {
                    Authorization: window.sessionStorage.getItem('Token'),
                    'Content-type': 'application/json'
                }
            }).success(function (data) {
                for (var i = 0; i < $scope.Delete.length; i++) {
                    $scope.Eliminar($scope.Clave, $scope.Delete[i]);
                };
                for (var i = 0; i < $scope.EsquemasList.length; i++) {
                    if ($scope.EsquemasList[i].EsquemaID != "" && $scope.EsquemasList[i].EsquemaID != "null" && $scope.EsquemasList[i].EsquemaID != null) {
                        $scope.Agregar($scope.Clave, $scope.EsquemasList[i].EsquemaID);
                    }
                };
                window.location.href = '../Rutas/Index?Permiso=CRUDEOP';
            }).error(function (error) {
                console.log(error);
            });

        }
    };

    //Editar Ruta
    $scope.EditarRuta = function (Clave, Permiso, SoloLectura) {
        $scope.Permiso = Permiso;
        if (Clave != "") {
            $http({
                url: window.sessionStorage.getItem("URL") + '/api/Rutas/CargarRuta?rutaC=' + Clave,
                method: 'GET',
                headers: {
                    Authorization: window.sessionStorage.getItem("Token"),
                    'Content-Type': 'Aplication/json'
                }
            })
                .success(function (data, state) {
                    angular.forEach(data, function (v, k) {
                        $scope.Clave = v.RUTClave;
                        $scope.Descripcion = v.Descripcion;
                        $scope.Tipo = v.Tipo;
                        $scope.TipoEstado = v.TipoEstado;
                        $scope.Inventario = v.Inventario;
                        $scope.AlmacenIDCEDI = v.AlmacenID;
                        $scope.Camiones = v.CAMPlaca;
                        $scope.CamionesNombre = v.Clave;
                        $scope.Estado = v.Inventario;
                        $scope.ValidarRutaAsignada();
                    })
                })
                .error(function (error, state) {
                })
            $scope.ObtEsquemas(Clave);
            $scope.ObtListaEsquemas(Clave);
            $scope.Action = "Edit";
            $scope.SoloLectura = true;
        }
        else {
            $scope.Action = "Create";
            $scope.SoloLectura = false;
            $scope.Estado = false;
        }
        //Titulos
        if ($scope.Action == "Create") {
            $scope.ModCreate = true;
        }
        else {
            $scope.ModCreate = false;
        }
    };

    //Obtener los esquemas de producto relacionados a la Ruta actual
    $scope.ObtEsquemas = function (Clave) {
        $http({
            url: url + '/api/Rutas/ObtEsquemas?Ruta=' + Clave,
            method: 'get',
            headers: {
                Authorization: window.sessionStorage.getItem("Token"),
                'Content-Type': 'Aplication/json'
            }
        })
            .success(function (data, state) {
                $scope.EsquemasList = data;
            })
            .error(function (error, state) {
            })
    };

    //Obtener los esquemas de producto relacionados a la Ruta actual
    $scope.ObtListaEsquemas = function (Clave) {
        $http({
            url: url + '/api/Rutas/ObtEsquemas?Ruta=' + Clave,
            method: 'get',
            headers: {
                Authorization: window.sessionStorage.getItem("Token"),
                'Content-Type': 'Aplication/json'
            }
        })
            .success(function (data, state) {
                $scope.ListaEsquemas = data;
            })
            .error(function (error, state) {
            })
    };

    //Remover Elemento de la lista y agregarlo a la final
    $scope.Remove = function (index, Clave) {
        $scope.Delete.splice(0, 0, Clave);
        $scope.EsquemasList.splice(index, 1);
        if ($scope.EsquemasList[$scope.EsquemasList.length - 1].Nombre == "") {
            $scope.EsquemasList.splice($scope.EsquemasList.length - 1, 1);
        }
        //$scope.ROrden();
    };

    //Eliminar Productos de la ruta
    $scope.Eliminar = function (Ruta, Clave) {
        var Borrar = {
            RUTClave: Ruta,
            EsquemaID: Clave
        };

        $http({
            url: window.sessionStorage.getItem("URL") + '/api/Rutas/Eliminar?Borrar=' + Borrar,
            method: 'POST',
            data: JSON.stringify(Borrar),
            dataType: "json",
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-type': 'application/json'
            }
        }).success(function (data) {
        }).error(function (error) {
        });
    };

    //Guardar Productos de la ruta
    $scope.Agregar = function (Ruta, Clave) {
        var Producto = {
            RUTClave: Ruta,
            EsquemaID: Clave,
            MUsuarioID: window.sessionStorage.getItem("USUId")
        };

        $http({
            url: window.sessionStorage.getItem("URL") + '/api/Rutas/Agregar?Producto=' + Producto,
            method: 'POST',
            data: JSON.stringify(Producto),
            dataType: "json",
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-type': 'application/json'
            }
        }).success(function (data) {
        }).error(function (error) {
        });
    };

    //Obtener Esquemas
    $scope.Esquemas = function () {
        $http({
            url: url + '/api/Rutas/Esquemas',
            metohod: 'GET',
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-Type': 'application/json'
            }
        }).success(function (data, status) {
            $scope.treeViewEsquema = data;
            $scope.tree_data = data;
        }).error(function (error, status) {
            $scope.error = { message: error, status: status };
            console.log($scope.error);
        });
    };

    //Agregar cliente nuevo a la tabla donde se llamo
    $scope.addProducto = function (Clave, Nombre, EsquemaID) {
        var aux = false;
        for (var i = 0; i < $scope.Add.length; i++) {
            if ($scope.Add[i].Clave === Clave) {
                aux = true;
            }
        }
        if (!aux) {
            $scope.Add.push({ 'Clave': Clave, 'Nombre': Nombre, 'EsquemaID': EsquemaID });
        }
        else {
            angular.forEach($scope.Add, function (value, key) {
                if (value.Clave == Clave) {
                    $scope.Add.splice(key, 1);
                }
            });
        }
    };

    //Agregar desde la tabla
    $scope.Nuevo = function () {
        if ($scope.EsquemasList.length > 0) {
            $scope.Almacenar = false;
            if ($scope.EsquemasList[$scope.EsquemasList.length - 1].Nombre == "") {
                if ($('.Edit:last').text().trim() != "null" && $('.Edit:last').text().trim() != null && $('.Edit:last').text().trim() != "") {
                    $scope.Crear = true;
                    $scope.Recuperar();
                }
            }
            else {
                $scope.EsquemasList.push({ 'Clave': "", 'Nombre': "", 'EsquemaID': "", 'Editable': "0" });
            }
        }
        else {
            $scope.EsquemasList.push({ 'Clave': "", 'Nombre': "", 'EsquemaID': "", 'Editable': "0" });
        }
        //$scope.ROrden();
    };

    ////Reordenar
    //$scope.ROrden = function () {
    //    for (var i = 0; i < $scope.EsquemasList.length; i++) {
    //        var e = true;
    //        for (var j = 0; j < $scope.ListaEsquemas.length; j++) {
    //            if ($('.Edit' + i).text().trim() == $scope.ListaEsquemas[j].Clave) {
    //                e = false;
    //            }
    //        }
    //        $('.Edit' + i).attr('contenteditable', e);
    //    }
    //};

    //Verificar tabla antes de guardar la información
    $scope.Save = function () {
        if ($scope.EsquemasList.length > 0) {
            if ($scope.EsquemasList[$scope.EsquemasList.length - 1].Nombre == "") {
                if ($('.Edit:last').text().trim() != "null" && $('.Edit:last').text().trim() != null && $('.Edit:last').text().trim() != "") {
                    $scope.Almacenar = true;
                    $scope.Crear = false;
                    $scope.Recuperar();
                }
                else {
                    $scope.CAMPlacaClean();
                }
            }
            else {
                $scope.CAMPlacaClean();
            }
        }
        else {
            $scope.CAMPlacaClean();
        }
    };

    //Agregar productos a la lista final
    $scope.addEsquema = function () {
        for (var i = 0; i < $scope.Add.length; i++) {
            var aux = false;
            for (var j = 0; j < $scope.EsquemasList.length; j++) {
                if ($scope.Add[i].Clave === $scope.EsquemasList[j].Clave) {
                    aux = true;
                }
            }
            if (!aux) {
                $scope.EsquemasList.push({ 'Clave': $scope.Add[i].Clave, 'Nombre': $scope.Add[i].Nombre, 'EsquemaID': $scope.Add[i].EsquemaID });
            }
        }
        $scope.Ordenar();
        $scope.Add = [];
    };

    //Ordenar EsquemasList
    $scope.Ordenar = function () {
        var auxCla = "";
        var auxNom = "";
        var auxEsq = "";
        for (var i = 1; i < $scope.EsquemasList.length; i++) {
            for (var j = 0; j < $scope.EsquemasList.length - 1; j++) {
                if ($scope.EsquemasList[j].Clave > $scope.EsquemasList[j + 1].Clave) {
                    auxCla = $scope.EsquemasList[j].Clave;
                    auxNom = $scope.EsquemasList[j].Nombre;
                    auxEsq = $scope.EsquemasList[j].EsquemaID;
                    $scope.EsquemasList[j].Clave = $scope.EsquemasList[j + 1].Clave;
                    $scope.EsquemasList[j].Nombre = $scope.EsquemasList[j + 1].Nombre;
                    $scope.EsquemasList[j].EsquemaID = $scope.EsquemasList[j + 1].EsquemaID;
                    $scope.EsquemasList[j + 1].Clave = auxCla;
                    $scope.EsquemasList[j + 1].Nombre = auxNom;
                    $scope.EsquemasList[j + 1].EsquemaID = auxEsq;
                }
            }
        }
    };

    //Verificar si una celda es o no editable
    $scope.Editable = function (Clave) {
        $('.Edit').attr('contenteditable', 'false');
        if (Clave == "") {
            $('.Edit:last').attr('contenteditable', 'true')
        }
    };

    //Prueba keypress
    $scope.prueba = function () {
        var aux = "";
        $scope.Almacenar = false;
        if (event.which === 13) {
            $scope.Crear = false;
            $scope.Recuperar();
        }
    }

    //Recuperar Registro
    $scope.Recuperar = function () {
        var Producto = $('.Edit:last').text().trim();
        $http({
            url: url + '/api/Rutas/ObtProducto?Clave=' + Producto,
            method: 'get',
            headers: {
                Authorization: window.sessionStorage.getItem("Token"),
                'Content-Type': 'Aplication/json'
            }
        })
            .success(function (data, state) {
                if (Producto != "null" && Producto != null && Producto != "") {
                    if (data.length > 0) {
                        angular.forEach(data, function (v, k) {
                            var aux = false;
                            for (var j = 0; j < $scope.EsquemasList.length; j++) {
                                if (v.Clave === $scope.EsquemasList[j].Clave) {
                                    aux = true;
                                }
                            }
                            if (!aux) {
                                $scope.EsquemasList[$scope.EsquemasList.length - 1].Clave = v.Clave;
                                $scope.EsquemasList[$scope.EsquemasList.length - 1].Nombre = v.Nombre;
                                $scope.EsquemasList[$scope.EsquemasList.length - 1].EsquemaID = v.EsquemaID;
                                $scope.EsquemasList[$scope.EsquemasList.length - 1].Editable = v.Editable;
                                $('.Edit:last').text(v.Clave);
                                $('.Edit').attr('contenteditable', 'false');
                                if ($scope.Crear === true) {
                                    $scope.Nuevo();
                                }
                                if ($scope.Almacenar === true) {
                                    $scope.Save();
                                }
                            }
                            else {
                                $scope.lblMsgTitulo = $scope.translation.XMensajeE;
                                $scope.lblMsgMensaje = $scope.translation.BE0002;
                                messageBoxAux.Mostrar();
                                $('.Edit:last').text("");
                            }
                        })
                    }
                    else {
                        $scope.Crear = false;
                        $scope.lblMsgTitulo = $scope.translation.XMensajeE;
                        $scope.lblMsgMensaje = $scope.translation.E0026;
                        messageBoxAux.Mostrar();
                    }
                }
                else {
                    $scope.Crear = false;
                }
            })
            .error(function (error, state) {
            })
    };

    //MsgBoxAux
    $scope.MsgBoxAux = function () {
        messageBoxAux.Cerrar();
    };

    //Seleccionar Productos Relacionados
    $scope.SeleccionarProductos = function () {
        if ($scope.EsquemasList.length > 0) {
            if ($scope.EsquemasList[$scope.EsquemasList.length - 1].Nombre == "") {
                $scope.EsquemasList.splice($scope.EsquemasList.length - 1, 1);
            }
        }
        defaultBox.Mostrar('', '', 'RutaProductoBox');
    };

    //Seleccionar vehiculo
    $scope.SeleccionarVehiculo = function () {
        defaultBox.Mostrar('', '', 'VehiculoBox');
    };

    //Enviar Seleccion
    $scope.Seleccion = function (Placa, Nombre) {
        $scope.Camiones = Placa;
        $scope.CamionesNombre = Nombre;
    };

    //Valida que la ruta no este asignada
    $scope.ValidarRutaAsignada = function () {
        var Ruta = $scope.Clave;
        $http({
            url: url + '/api/Rutas/ValidarRutaAsignada?Ruta=' + Ruta,
            method: 'get',
            headers: {
                Authorization: window.sessionStorage.getItem("Token"),
                'Content-Type': 'Aplication/json'
            }
        })
            .success(function (data, state) {
                angular.forEach(data, function (v, k) {
                    $scope.TipoAux = v.TipoEstado;
                    if ($scope.TipoAux == "1") {
                        $scope.ValidarRutaVarios();
                    }
                    else {
                        $scope.Mensaje53 = false;
                        $scope.Mensaje54 = false;
                    }
                })
            })
            .error(function (error, state) {
            })
    };

    //Valida que la ruta no este asignada CONHist.ClienteVariasRutas Activo
    $scope.ValidarRutaVarios = function () {
        $http({
            url: url + '/api/Rutas/ValidarRutaVarios',
            method: 'get',
            headers: {
                Authorization: window.sessionStorage.getItem("Token"),
                'Content-Type': 'Aplication/json'
            }
        })
            .success(function (data, state) {
                angular.forEach(data, function (v, k) {
                    $scope.TipoAux = v.ClienteVariasRutas;
                    if ($scope.TipoAux == "0") {
                        $scope.Mensaje54 = false;
                        $scope.Mensaje53 = true;
                    }
                    else {
                        $scope.Mensaje54 = true;
                        $scope.Mensaje53 = false;
                    }
                })
            })
            .error(function (error, state) {
            })
    };

    //Funciones para seleccionar todos los checkboxes (Pruebas)
    ///////////////////////////////////////////////////////////
    //$scope.Inicializar = function SelectAllChekboxesRoutes() {
    //    angular.forEach($scope.tree_data, function (item) {
    //        item.Checked = true;
    //        $scope.addProducto(item['Clave'], item['Nombre'], item['EsquemaID'])
    //    });
    //    //angular.forEach($scope.tree_data, function (item) {
    //    //    angular.forEach(item.children, function (node) {
    //    //        node.Checked = true;
    //    //    });
    //    //});
    //}
    ///////////////////////////////////////////////////////////
    ///////////////////////////////////////////////////////////
}]);

app.directive('validarClaveRuta', function ($http, $q) {
    return {
        restrict: 'A',
        require: 'ngModel',
        link: function ($scope, element, attr, ngModel) {
            var validar = attr.validarClaveRuta;
            var index = attr.index;
            var url = window.sessionStorage.getItem('URL');
            if (validar == "true") {
                element.ready(function () {
                    if ($scope.Action == "Create") {
                        ngModel.$asyncValidators.ValidarRuta = function (modelValue, viewValue) {
                            var deferred = $q.defer();
                            $http({
                                url: url + '/api/Rutas/ValidarClaveRuta?ClaveRuta=' + modelValue,

                                method: 'get',
                                headers: {
                                    Authorization: window.sessionStorage.getItem('Token'),
                                    'Content-type': 'application/JSON'
                                }
                            }).success(function (data, staus) {
                                if (data == true) {
                                    deferred.reject();
                                } else {
                                    deferred.resolve();
                                }
                            }).error(function (error, status) {
                            });
                            return deferred.promise;
                        };
                    }
                });
            }
        }
    }
});

app.directive('validarClaveCamion', function ($http, $q) {
    return {
        restrict: 'A',
        require: 'ngModel',
        link: function ($scope, element, attr, ngModel) {
            var validar = attr.validarClaveCamion;
            var index = attr.index;
            var url = window.sessionStorage.getItem('URL');
            if (validar == "true") {
                element.ready(function () {
                    ngModel.$asyncValidators.ValidarCamion = function (modelValue, viewValue) {
                        var deferred = $q.defer();
                        $http({
                            url: url + '/api/Rutas/ValidarClaveCamion?ClaveCamion=' + modelValue,
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