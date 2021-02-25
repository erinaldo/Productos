//vendedores
//vendedorCtrl
var app = angular.module('vendedores', ['valorReferencia', 'messageBoxAux', 'ngResource', 'translation', 'angularTreeview', 'defaultBox', 'seleccionEsquema', 'messageBox', 'ngMaterial', 'ngMessages','directivas']);

app.controller('vendedorCtrl', ["$scope", "$rootScope", "$http", "$filter", 'valorReferencia', "messageBoxAux", "translationService", "defaultBox", "seleccionEsquema", "messageBox", function ($scope, $rootScope, $http, $filter, valorReferencia, messageBoxAux, translationService, defaultBox, seleccionEsquema, messageBox) {
    var url = window.sessionStorage.getItem('URL');
    ObtenerVendedores();
    centros();
    ObtModulo();
    ObtLista();
    ObtenerEstado();




    $scope.Descuentos = [];
    $scope.DeleteDescuentos = [];
    Nuevomo();

    //translation sino no aparecen las etiketas
    translationService.getTranslation($scope);
    $scope.GetDescripcion = function (MENClave, Descripcion) {
        if ($scope.translation == undefined)
            return Descripcion;
        else {
            if ($scope.translation[MENClave] == undefined)
                return Descripcion;
            else
                return $scope.translation[MENClave]
        }

    }

    //pasar cuando este el Edit
    $scope.VCHFechaInicial = new Date;
    $scope.TipoEstado = "1";
    $scope.TipoEstadoBlock = true;
    $scope.JornadaTradeTrabajo = true;
    $scope.CapturarFolioFactura = true;
    $scope.MostrarCoutas = true;
    $scope.MantenerPromocion = true;
    $scope.Tipo = "1";
    $scope.Modificar = "0";

    $scope.blockU = true;
    $scope.blockT = true;
    $scope.blockA = true;
    $scope.blockC = true;
    //Ordenar las columnas de la tabla TERMINAL
    $scope.sort = function (keyname) {
        $scope.sortKey = keyname;
        $scope.reverse = !$scope.reverse;
    }
    //claves de acceso
    $scope.AsignarPermisoVendedor = function (Permiso, SoloLectura) {
        $scope.Permiso = Permiso;
        $scope.SoloLectura = SoloLectura;
    }

    //peticion para obtener datos SELECT(mostrando tabla) INDEX
    function ObtenerVendedores() {

        $http({

            url: url + '/api/Vendedores/ObtenerVendedores?usu=' + window.sessionStorage.getItem('USUId'),
            metohod: 'GET',
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-Type': 'application/json'
            }
        }).success(function (data, status) {
            $scope.cVendedores = data;
            var tam = $scope.cVendedores.length;
            $scope.tamPag = tamano(tam);

            console.log("MUsuarioID: " + window.sessionStorage.getItem('USUId'));

        }
            ).error(function (error, status) {
                $scope.error = { message: error, status: status };
                console.log($scope.error);
            });
    }


    //Vista de Vendedor----------------------------------------------------------------------------------------------------------------------------------------------------
    //Obtener Estado VAlor Por referencia ESTADOS
    function ObtenerEstado() {

        valorReferencia.obtenerValores('EDOREG', function (result) {
            $scope.edoreg = result;
        });

        valorReferencia.obtenerValores('TVEND', function (result) {
            $scope.tvend = result;
        });

        valorReferencia.obtenerValores('VENEXP', function (result) {
            $scope.venexp = result;
        });

        valorReferencia.obtenerValores('TPAPEL', function (result) {
            $scope.tpapel = result;
        });

        valorReferencia.obtenerValores('MODPRE', function (result) {
            $scope.modpre = result;
        });



    }

    //obtener centros de distribucion
    function centros() {
        $http({
            url: url + '/api/Vendedores/ObtCentroDistribucion?usu=' + window.sessionStorage.getItem('USUId'),
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

    //obtener Vendedores
    function ObterAlmacen() {

        $http({

            url: url + '/api/Vendedores/ObtenerVendedores',
            metohod: 'GET',
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-Type': 'application/json'
            }
        }).success(function (data, status) {
            $scope.cVendedor = data;

        }
            ).error(function (error, status) {
                $scope.error = { message: error, status: status };
                console.log($scope.error);
            });
    }

    //Almacen
    $scope.AlmacenID = function () {

        $http({

            url: url + '/api/Vendedores/Almacen?almacenid=' + $scope.AlmacenIDAux,
            metohod: 'GET',
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-Type': 'application/json'
            }
        }).success(function (data, status) {
            $scope.cAlmacen = data;

        }
          ).error(function (error, status) {
              $scope.error = { message: error, status: status };
              console.log($scope.error);
          });

    }

    //usuario )
    $scope.usuario = function () {

        $http({

            url: url + '/api/Vendedores/VenUsuario?almacenid=' + $scope.AlmacenIDAux,
            metohod: 'GET',
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-Type': 'application/json'
            }
        }).success(function (data, status) {
            $scope.cUsuario = data;
            //console.log(JSON.stringify(cUsuario));
            var tam = $scope.cUsuario.length;
            $scope.tamPag = tamano(tam);

        }
          ).error(function (error, status) {
              $scope.error = { message: error, status: status };
              console.log($scope.error);
          });

    }


    //Terminal
    $scope.terminal = function () {

        $http({

            url: url + '/api/Vendedores/VenTerminal?almacenid=' + $scope.AlmacenIDAux,
            metohod: 'GET',
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-Type': 'application/json'
            }
        }).success(function (data, status) {
            $scope.cTerminal = data;
            var tam = $scope.cTerminal.length;
            $scope.tamPag = tamano(tam);

        }
          ).error(function (error, status) {
              $scope.error = { message: error, status: status };
              console.log($scope.error);
          });

    }

    $scope.change = function (modulo) {



        var aux = false;
        for (var j = 0; j < $scope.Descuentos.length; j++) {
            if (modulo.Modulo.nombre === $scope.Descuentos[j].Modulo.nombre && $scope.Descuentos[j] != modulo) {
                aux = true;

                break;
            }
        }
        if (aux) {
            //$scope.lblMsgTitulo = $scope.translation.XMensajeE;
            //$scope.lblMsgMensaje = $scope.translation.BE0002;
            //messageBoxAux.Mostrar();
            angular.forEach($scope.Descuentos, function (value, key) {
                if (value == modulo) {
                    $scope.Descuentos.splice(key, 1);
                }
            });
            //  $scope.Descuentos[($scope.Descuentos.length)-1]="";
        }

    }

    //MsgBoxAux
    $scope.MsgBoxAux = function () {
        messageBoxAux.Cerrar();
    };

    //cliente
    $scope.cliente = function () {

        $http({

            url: url + '/api/Vendedores/VenCliente?almacenid=' + $scope.AlmacenIDAux,
            metohod: 'GET',
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-Type': 'application/json'
            }
        }).success(function (data, status) {
            $scope.cCliente = data;
            //console.log(JSON.stringify(data));
            var tam = $scope.cCliente.length;
            $scope.tamPag = tamano(tam);

        }
          ).error(function (error, status) {
              $scope.error = { message: error, status: status };
              console.log($scope.error);
          });

    }
    $scope.clienteEsquema = [];

    //ESQUEMAS DE CLIENTE
    $scope.myTreeControl = {};
    $scope.myTreeControl.Marcada = function (branch) {
        $scope.Activo = false;
        for (var i = 0; i < $scope.esquemasAgregar.length; i++) {
            if ($scope.esquemasAgregar[i].Clave == branch.Clave) {
                $scope.Activo = true;
            }
        }
        return $scope.Activo;
    }
    $scope.myTreeControl.scope = this;

    ObtenerClienteEsquema();

    function ObtenerClienteEsquema(ClienteClave) {
        $http({
            url: url + '/api/Cliente/ObtenerClienteEsquema?ClienteClave=' + ClienteClave,
            method: 'GET',
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-Type': 'application/json'
            }
        }).success(function (data, status) {
            $scope.clienteEsquema = data;
        }).error(function (error, status) {

        });
    }

    $scope.AgregarClienteEsquema = function () {
        //if ($scope.EsquemasList.length > 0) {
        //    if ($scope.EsquemasList[$scope.EsquemasList.length - 1].Nombre == "") {
        //        $scope.EsquemasList.splice($scope.EsquemasList.length - 1, 1);
        //    }
        //}
        seleccionEsquema.Cargar(1).then(function (data) {
            $scope.treeViewEsquema = data;
            $scope.tree_data = data;
            $scope.Action = "AgregarClienteEsquema";
            seleccionEsquema.Seleccionar();
        });

    };

    $scope.AgregarEsquema = function (Clave, Nombre, EsquemaID) {
        var aux = false;
        for (var i = 0; i < $scope.esquemasAgregar.length; i++) {
            if ($scope.esquemasAgregar[i].Clave == Clave) {
                aux = true;
            }
        }
        if (!aux) {
            $scope.esquemasAgregar.push({ 'Clave': Clave, 'Nombre': Nombre, 'EsquemaID': EsquemaID });
        }
        else {
            angular.forEach($scope.esquemasAgregar, function (value, key) {
                if (value.Clave == Clave) {
                    $scope.esquemasAgregar.splice(key, 1);
                }
            });
        }
    };

    $scope.AgregarEsquemas = function () {
        for (var i = 0; i < $scope.esquemasAgregar.length; i++) {
            var aux = false;
            if ($scope.Action == "AgregarClienteEsquema") {
                for (var j = 0; j < $scope.clienteEsquema.length; j++) {
                    if ($scope.esquemasAgregar[i].EsquemaID == $scope.clienteEsquema[j].EsquemaID) {
                        aux = true;
                    }
                }
                if (!aux) {
                    $scope.clienteEsquema.push({
                        'Clave': $scope.esquemasAgregar[i].Clave,
                        'Nombre': $scope.esquemasAgregar[i].Nombre,
                        'EsquemaID': $scope.esquemasAgregar[i].EsquemaID,
                        'TipoEstado': '1',
                        'Nuevo': true
                    });
                }
            }
            else { //AgregarExcepcionFac
                for (var j = 0; j < $scope.excepcionFac.length; j++) {
                    if ($scope.esquemasAgregar[i].EsquemaID == $scope.excepcionFac[j].EsquemaID && $scope.excepcionFac[j].SubEmpresaId == '') {
                        aux = true;
                    }
                }
                if (!aux) {
                    $scope.excepcionFac.push({
                        'Clave': $scope.esquemasAgregar[i].Clave,
                        'Nombre': $scope.esquemasAgregar[i].Nombre,
                        'EsquemaID': $scope.esquemasAgregar[i].EsquemaID,
                        'SubEmpresaId': '',
                        'Nuevo': true
                    });
                }
            }
        }
        $scope.esquemasAgregar = [];
        //$scope.Ordenar();

    };

    $scope.anadirNuevoEsq = function (clave, nombre, estado) {

        if ($scope.segData.length < 1) {
            $scope.segData.push({
                EsquemaID: clave, Nombre: nombre, TipoEstado: estado
            })
        } else {
            var existe = false;
            angular.forEach($scope.segData, function (v, k) {
                if (v.EsquemaID == clave) {
                    existe = true;
                }
            });

            if (existe == false) {
                $scope.segData.push({
                    EsquemaID: clave, Nombre: nombre, TipoEstado: estado
                })
            }
        }
    }

    $scope.EliminarClienteEsquema = function (EsquemaID) {
        angular.forEach($scope.clienteEsquema, function (v, k) {
            if (v.EsquemaID == EsquemaID) {
                $scope.clienteEsquema.splice(k, 1);
            }
        })
    }

    //Botones Ventana Modal
    $scope.SeleccionarSegmento = function () {
        defaultBox.Mostrar('Seleccion de Configuración', 'otro', 'VenSegmentos');
    };

    $scope.SeleccionarVehiculo = function () {
        defaultBox.Mostrar('Seleccion de Configuración', 'otro', 'VendedoresBox');
    };

    $scope.SeleccionarUsuario = function () {
        defaultBox.Mostrar('Seleccionar Usuario', 'otro', 'VenUsuarioBox');
    };

    $scope.SeleccionarTerminal = function () {
        defaultBox.Mostrar('Seleccionar Terminal', 'otro', 'VenTerminalBox');
    };

    $scope.SeleccionarCliente = function () {
        defaultBox.Mostrar('Seleccionar Cliente', 'otro', 'VenClienteMBox');
    };

    $scope.SeleccionarLista = function () {
        defaultBox.Mostrar('Seleccionar Lista de Precios', 'otro', 'VenListaPreciosBox');
    };

    //Obtener Modulo
    function ObtModulo() {
        $http({
            url: url + '/api/Vendedores/VenConf?almacenid=' + $scope.AlmacenIDAux,
            method: 'get',
            headers: {
                Authorization: window.sessionStorage.getItem("Token"),
                'Content-Type': 'Aplication/json'
            }
        })
            .success(function (data, state) {
                $scope.cModulo = data;
                //  console.log(JSON.stringify(data));
            })
            .error(function (error, state) {
            })
    };

    //Obtener Modulo
    function ObtLista() {
        $http({
            url: url + '/api/Vendedores/VenLista',
            method: 'get',
            headers: {
                Authorization: window.sessionStorage.getItem("Token"),
                'Content-Type': 'Aplication/json'
            }
        })
            .success(function (data, state) {
                $scope.cLista = data;
                var tam = $scope.cLista.length;
                $scope.tamPag = tamano(tam);
                // console.log(JSON.stringify(data));
            })
            .error(function (error, state) {
            })
    };

    //Enviando seleccion Modulo
    $scope.SeleccionMo = function (Clave) {
        $scope.MCNClave = Clave;
    };

    //Enviando Listade precios
    $scope.SeleccionLi = function (Clave, Nombre) {
        $scope.Precio = Clave;
        $scope.PrecioNombre = Nombre;
    };

    //Usuario
    $scope.SeleccionUs = function (Clave, Nombre) {
        $scope.Usuario = Clave;
        $scope.Usuario2 = Nombre;
    };


    //Terminal
    $scope.SeleccionTe = function (Clave, Nombre) {
        $scope.Terminal = Clave;
        $scope.Terminal2 = Nombre;
    };


    //ClienteModelo
    $scope.SeleccionCl = function (Clave, Nombre) {
        $scope.ClienteModelo = Clave;
        $scope.ClienteModelo2 = Nombre;
    };





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


    //bloqueos
    $scope.bloqueos = function () {
        debugger;
        var bloquear = $scope.AlmacenIDAux;
        if (bloquear != undefined) {


            $scope.blockU = false;
            $scope.blockT = false;
            $scope.blockA = false;
            $scope.blockC = false;

        } else {

            $scope.blockU = true;
            $scope.blockT = true;
            $scope.blockA = true;
            $scope.blockC = true;

        }
    }

    //Seccion Descuento
    //Agregar desde la tabla
    $scope.NuevoDes = function () {
        var aux = false;
        if ($scope.Descuentos.length > 0) {
            for (var i = 0; i < $scope.Descuentos.length; i++) {
                if ($scope.Descuentos[i].Modulo == "") {
                    aux = true;
                } else {

                }
            }
            if (!aux) {
                $scope.Descuentos.push({ 'Modulo': "", 'Vandedor': "", 'Cliente': "", 'Producto': "", 'Estado': "", 'Editable': "0" });

            }



        } else {

            $scope.Descuentos.push({ 'Modulo': "", 'Vandedor': "", 'Cliente': "", 'Producto': "", 'Estado': "", 'Editable': "0" });


        }




    };

    //traelos datos del Mòdulo 
    function Nuevomo() {


        $http({

            url: url + '/api/Vendedores/ObtenerModulos',
            metohod: 'GET',
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-Type': 'application/json'
            }

        }).success(function (data, status) {
            debugger;
            $scope.Cmodulos = data;

            //console.log(JSON.stringify(cProducto));

        }




            ).error(function (error, status) {
                $scope.error = { message: error, status: status };
                //console.log($scope.error);
                console.log("Error");
                debugger;
            });


        //SUBMODULOS
        $http({

            url: url + '/api/Vendedores/ObtenerSubModulos',
            metohod: 'GET',
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-Type': 'application/json'
            }

        }).success(function (data, status) {
            debugger;
            $scope.CSubmodulos = data;

            //console.log(JSON.stringify(cProducto));

        }




            ).error(function (error, status) {
                $scope.error = { message: error, status: status };
                //console.log($scope.error);
                console.log("Error");
                debugger;
            });

        //Hijos
        $http({

            url: url + '/api/Vendedores/ObtenerHijos',
            metohod: 'GET',
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-Type': 'application/json'
            }

        }).success(function (data, status) {
            debugger;
            $scope.CHijos = data;

            //console.log(JSON.stringify(cProducto));

        }




            ).error(function (error, status) {
                $scope.error = { message: error, status: status };
                //console.log($scope.error);
                console.log("Error");
                debugger;
            });

    };


    $scope.reverseDes = true;
    //Ordenar las columnas de la tabla Esquema Clientes
    $scope.sortDes = function (keyname) {
        //if (keyname != "" && keyname != "null" && keyname != null) {
        $scope.Lock = "Editable";
        $scope.sortKeyDes = keyname;
        $scope.reverseDes = !$scope.reverseDes;
        //}
    };

    $scope.EliminarDescuento = function (index, Clave) {
        $scope.DeleteDescuentos.splice(0, 0, Clave);
        $scope.Descuentos.splice(index, 1);
        if ($scope.Descuentos.length > 0) {
            if ($scope.Descuentos[$scope.Descuentos.length - 1].Nombre == "") {
                $scope.Descuentos.splice($scope.Descuentos.length - 1, 1);
            }
        }

    };




    //BorrarCon cambio de Centro
    $scope.borrar = function () {
        $scope.Usuario = "";
        $scope.Usuario2 = "";
        $scope.Terminal = "";
        $scope.Terminal2 = "";
        $scope.ClienteModelo = "";
        $scope.ClienteModelo2 = "";

    }


    //BtnVigencias
    $scope.VigenciaVendedores = function () {
        //VendedorID
        var TipoCodigo = $scope.TipoCodigo;
        debugger;

        defaultBox.Mostrar('Consultar Histórico', 'otro', 'VenVigenciaBox');


        debugger;
        $http({

            url: url + '/api/Monedas/ObtenerVigenciaVendedores?TipoCodigo=' + TipoCodigo,
            metohod: 'GET',
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-Type': 'application/json'
            }

        }).success(function (data, status) {
            debugger;
            $scope.cVigenciaM = data;

            //console.log(JSON.stringify(cProducto));

        }

            ).error(function (error, status) {
                $scope.error = { message: error, status: status };
                //console.log($scope.error);
                console.log("Error");
                debugger;
            });
    }


    //bloqueos
    $scope.bloqueoTipo = function () {
        debugger;
        var bloquear = $scope.Tipo;
        if (bloquear != "2") {


            $scope.CModuloT = false;
            $scope.NExperienciaT = false;
            $scope.Nivel = "1";
            $scope.TerminalT = false;
            $scope.uno = false;
            $scope.dos = false;
            $scope.tres = false;
            $scope.cinco = false;
            $scope.seis = false;
            $scope.siete = false;
            $scope.ocho = false;

            $scope.JornadaTradeTrabajo = true;
            $scope.CapturarFolioFactura = true;
            $scope.MostrarCoutas = true;
            $scope.MantenerPromocion = true;

            $scope.nueve = false;
            $scope.dies = false;
            $scope.once = false;
            $scope.doce = false;
        } else {

            $scope.CModuloT = true;
            $scope.NExperienciaT = true;
            $scope.TerminalT = true;
            $scope.uno = true;
            $scope.dos = true;
            $scope.tres = true;
            $scope.cinco = true;
            $scope.seis = true;
            $scope.siete = true;
            $scope.ocho = true;

            $scope.JornadaTradeTrabajo = false;
            $scope.CapturarFolioFactura = false;
            $scope.MostrarCoutas = false;
            $scope.MantenerPromocion = false;

            $scope.nueve = true;
            $scope.dies = true;
            $scope.once = true;
            $scope.doce = true;
        }
    }




    //guardar Vendedor
    $scope.GuardarVendedor = function () {

        if (!$scope.form.$valid) {
            $scope.form.submitted = true;
        } else {

            var General = {

                Estado: $scope.TerminalClave,
                FechaInicial: $scope.TipoFase,
                CentrodeDistribucion: $scope.Descripcion,
                NumeroSerie: $scope.NumeroSerie,
                Nombre: $scope.Comentario,
                Tipo: $scope.GPS,
                ConfiguracionModulo: $scope.AlmacenID,
                NiveldeExperiencia: $scope.AlmacenID,
                LimitedeDescuentos: $scope.AlmacenID,
                Usuario: $scope.AlmacenID,
                Terminal: $scope.AlmacenID,
                Almacen: $scope.AlmacenID,
                Impresora: $scope.AlmacenID,
                DirecctorioInterfacesdeSalida: $scope.AlmacenID,
                ClienteModelo: $scope.AlmacenID,
                ListadePReciosBase: $scope.AlmacenID,
                ActualizarEsquemas: $scope.AlmacenID,
                CapturarPrecios: $scope.AlmacenID,
                MostrarEsquemas: $scope.AlmacenID,
                Baja: $scope.AlmacenID,
                JornadadeTrabajo: $scope.AlmacenID,
                CapturaFolioFactura: $scope.AlmacenID,
                MostrarCuotas: $scope.AlmacenID,
                MantenerPromocion: $scope.AlmacenID,
                EditarDatosFiscales: $scope.AlmacenID,
                Kilometraje: $scope.AlmacenID,
                TiemposMuertos: $scope.AlmacenID,
                ModificarPrecios: $scope.AlmacenID,
                MUsuarioID: window.sessionStorage.getItem('USUId')

            };
            $http({
                url: url + '/api/Terminales/Grabar?terminales=' + terminales,
                method: 'post',
                data: JSON.stringify(terminales),
                dataType: "json",
                headers: {
                    Authorization: window.sessionStorage.getItem('Token'),
                    'Content-Type': 'application/json'
                },
            }).success(function (data, status) {

                if (data) {
                    window.location.href = '../Terminales/Index?Permiso=' + $scope.Permiso;

                } else {

                    console.log("Error");
                }


            }).error(function (error, status) {
            });
        }

    }


    //SCOPE PARA ESQUEMAS DE CLIENTE
    $scope.tree_data = [];
    $scope.esquemaDisponible = true;
    $scope.expanding_property = {
        field: "EsquemaID",
        displayName: " ",
        cellTemplate: '<span style="opacity: 0;">Sp</span><input type="checkbox" ng-checked = "treeControl.Marcada(row.branch)" ng-click="treeControl.click(row.branch.$index);" ng-model="row.branch.Checked"><span style="opacity: 0;">Extra Space</span>'
    };
    $scope.col_defs = [
       { field: "Nombre" },
       { field: "Abreviatura" },
       { field: "Orden" },
       { field: "Clave" },
       { field: "Clasificacion", displayName: "Clasificación" }
    ];
    $scope.esquemasEliminar = [];
    $scope.esquemasAgregar = [];
    $scope.clienteEsquema = [];

    

        if ($scope.clienteEsquema.length == 0)
            $scope.esquemaRequerido = true;
        else {
            var activo = false;
            angular.forEach($scope.clienteEsquema, function (v, k) {
                if (v.TipoEstado == 1)
                    activo = true;
            });
            if (!activo)
                $scope.esquemaRequerido = true;
        }

       

      



    //ESQUEMAS DE CLIENTE
    $scope.myTreeControl = {};
    $scope.myTreeControl.Marcada = function (branch) {
        $scope.Activo = false;
        for (var i = 0; i < $scope.esquemasAgregar.length; i++) {
            if ($scope.esquemasAgregar[i].Clave == branch.Clave) {
                $scope.Activo = true;
            }
        }
        return $scope.Activo;
    }
    $scope.myTreeControl.scope = this;

    $scope.ObtenerClienteEsquema = function (ClienteClave) {
        $http({
            url: url + '/api/Cliente/ObtenerClienteEsquema?ClienteClave=' + ClienteClave,
            method: 'GET',
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-Type': 'application/json'
            }
        }).success(function (data, status) {
            $scope.clienteEsquema = data;
        }).error(function (error, status) {

        });
    }

    $scope.AgregarClienteEsquema = function () {
        //if ($scope.EsquemasList.length > 0) {
        //    if ($scope.EsquemasList[$scope.EsquemasList.length - 1].Nombre == "") {
        //        $scope.EsquemasList.splice($scope.EsquemasList.length - 1, 1);
        //    }
        //}
        seleccionEsquema.Cargar(1).then(function (data) {
            $scope.treeViewEsquema = data;
            $scope.tree_data = data;
            $scope.Action = "AgregarClienteEsquema";
            seleccionEsquema.Seleccionar();
        });

    };

    $scope.AgregarEsquema = function (Clave, Nombre, EsquemaID) {
        var aux = false;
        for (var i = 0; i < $scope.esquemasAgregar.length; i++) {
            if ($scope.esquemasAgregar[i].Clave == Clave) {
                aux = true;
            }
        }
        if (!aux) {
            $scope.esquemasAgregar.push({ 'Clave': Clave, 'Nombre': Nombre, 'EsquemaID': EsquemaID });
        }
        else {
            angular.forEach($scope.esquemasAgregar, function (value, key) {
                if (value.Clave == Clave) {
                    $scope.esquemasAgregar.splice(key, 1);
                }
            });
        }
    };

    $scope.AgregarEsquemas = function () {
        for (var i = 0; i < $scope.esquemasAgregar.length; i++) {
            var aux = false;
            if ($scope.Action == "AgregarClienteEsquema") {
                for (var j = 0; j < $scope.clienteEsquema.length; j++) {
                    if ($scope.esquemasAgregar[i].EsquemaID == $scope.clienteEsquema[j].EsquemaID) {
                        aux = true;
                    }
                }
                if (!aux) {
                    $scope.clienteEsquema.push({
                        'Clave': $scope.esquemasAgregar[i].Clave,
                        'Nombre': $scope.esquemasAgregar[i].Nombre,
                        'EsquemaID': $scope.esquemasAgregar[i].EsquemaID,
                        'TipoEstado': '1',
                        'Nuevo': true
                    });
                }
            }
            else { //AgregarExcepcionFac
                for (var j = 0; j < $scope.excepcionFac.length; j++) {
                    if ($scope.esquemasAgregar[i].EsquemaID == $scope.excepcionFac[j].EsquemaID && $scope.excepcionFac[j].SubEmpresaId == '') {
                        aux = true;
                    }
                }
                if (!aux) {
                    $scope.excepcionFac.push({
                        'Clave': $scope.esquemasAgregar[i].Clave,
                        'Nombre': $scope.esquemasAgregar[i].Nombre,
                        'EsquemaID': $scope.esquemasAgregar[i].EsquemaID,
                        'SubEmpresaId': '',
                        'Nuevo': true
                    });
                }
            }
        }
        $scope.esquemasAgregar = [];
        //$scope.Ordenar();

    };

    $scope.anadirNuevoEsq = function (clave, nombre, estado) {

        if ($scope.segData.length < 1) {
            $scope.segData.push({
                EsquemaID: clave, Nombre: nombre, TipoEstado: estado
            })
        } else {
            var existe = false;
            angular.forEach($scope.segData, function (v, k) {
                if (v.EsquemaID == clave) {
                    existe = true;
                }
            });

            if (existe == false) {
                $scope.segData.push({
                    EsquemaID: clave, Nombre: nombre, TipoEstado: estado
                })
            }
        }
    }

    $scope.EliminarClienteEsquema = function (EsquemaID) {
        angular.forEach($scope.clienteEsquema, function (v, k) {
            if (v.EsquemaID == EsquemaID) {
                $scope.clienteEsquema.splice(k, 1);
            }
        })
    }


   
}]);



//Solo Numeros
app.directive('validNumVen', function () {
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

}).directive('bToCuryven', function ($filter) {
    return {
        scope: {
            amount: '='
        },
        link: function (scope, el, attrs) {
            // el.val($filter('currency')(scope.amount));

            el.bind('focus', function () {
                // el.val(scope.amount);
                el.val($filter('number')(scope.amount));

            });

            el.bind('input', function () {

                scope.amount = el.val();
                scope.$apply();
            });
            el.bind('blur', function () {
                var a;

                if (scope.amount <= 100) {
                    a = scope.amount;
                } else {
                    a = "";
                }


                el.val($filter('number')(a, 2));


            });
        }
    }
});


