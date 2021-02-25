var app = angular.module('cliente', ['valorReferencia', 'ngResource', 'translation', 'angularTreeview', 'defaultBox', 'seleccionEsquema', 'messageBox', 'directivas']);

app.controller('clienteCtrl', ["$scope", "$rootScope", "$http", 'valorReferencia', "translationService", "defaultBox", "seleccionEsquema", "messageBox", function ($scope, $rootScope, $http, valorReferencia, translationService, defaultBox, seleccionEsquema, messageBox) {
    var url = window.sessionStorage.getItem('URL');
    var map, marker, geocoder;
    ObtenerValoresCliente();
    ObtenerZonas();
    ObtenerAlmacenes();
    ObtenerSubEmpresas();
    $scope.TipoImpuesto = "1";
    $scope.TipoCamion = "1";
    $scope.requeridosSubForm = false;
    $scope.segData = [];
    $scope.DomicilioCompleto = "";
    $scope.clickBtnPress = false;
    $scope.cDirList = [];
    $scope.Numero = 0;
    $scope.bloqMensajes = true;
    $scope.listMod = [
        {
            'VAVClave': 2,
            'Descripcion': 'Cliente'
        }, {
            'VAVClave': 3,
            'Descripcion': 'Felicitaciones'
        }
    ]
    //LifeCycle
    this.$onInit = function () {
        //Se obtienen los esquemas

    }

    $scope.expanding_property = "EsquemaID";
    //Inicializar variables
    $scope.FechaRegistroSistema = new Date();
    $scope.FechaNacimiento = new Date();
    $scope.FechaFactura = new Date(2100, 0, 1);
    $scope.TipoEstado = "1";
    $scope.SaldoEfectivo = 0
    $scope.SaldoPrestamo = 0;
    $scope.CobranzaPendiente = false;

    $scope.vigBloq = true;
    $scope.venBloq = true;
    $scope.exBloq = true;
    $scope.limiBloq = true;
    $scope.maxDate = new Date();

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
    $scope.Activo = false;
    $scope.clienteEsquema = [];

    //VALIDACIONES
    $scope.claveCodigoRepetido = "";
    $scope.esquemaRequerido = false;
    $scope.domicilioRequerido = false;
    $scope.fiscalRequerido = false;
    //$scope.tipoBancoRequerido = false;
    $scope.formaVentaRequerida = false;
    $scope.formaVentaInicialRequerida = false;
    //$scope.translation = undefined;
    //$scope.claveRepetida = false;

    translationService.getTranslation($scope);
    $scope.GetDescripcion = function (MENClave, Descripcion) {
        if ($scope.translation === undefined)
            return Descripcion;
        else {
            if ($scope.translation[MENClave] === undefined)
                return Descripcion;
            else
                return $scope.translation[MENClave]
        }

    }

    $scope.AsignarPermisoCliente = function (Permiso) {
        $scope.Permiso = Permiso;
    }



    $scope.sort = function (keyname) {
        $scope.sortKey = keyname;
        $scope.reverse = !$scope.reverse;
    }

    //Llamar metodos al correr la app
    function ObtenerValoresCliente() {
        valorReferencia.obtenerValores('EDOREG', function (result) {
            $scope.edoreg = result;
        });
        valorReferencia.obtenerValores('EDOMSJ', function (result) {
            $scope.edomsj = result;
        });
        valorReferencia.obtenerValores('DOCFISC', function (result) {
            $scope.docfisc = result;
        });
        valorReferencia.obtenerValores('TIPOCAM', function (result) {
            $scope.tipocam = result;
        });
        valorReferencia.obtenerValores('IMPCTE', function (result) {
            $scope.impcte = result;
        });
        valorReferencia.obtenerValores('DOMTIPO', function (result) {
            $scope.domtipo = result;
        });
        valorReferencia.obtenerValores('TIPMOTIN', function (result) {
            $scope.tipmotin = result;
        });
        valorReferencia.obtenerValores('TUSOCFDI', function (result) {
            $scope.tusocfdi = result;
        });
        valorReferencia.obtenerValores('PAGO', function (result) {
            $scope.pago = result;
        });
        valorReferencia.obtenerValores('TBANCO', function (result) {
            $scope.tbanco = result;
        });
        valorReferencia.obtenerValores('FVENTA', function (result) {
            $scope.fventa = result;
        });
        valorReferencia.obtenerValores('TEXCEP', function (result) {
            $scope.texcep = result;
        });
        valorReferencia.obtenerValores('CONFCTA', function (result) {
            $scope.confcta = result;
        });
        valorReferencia.obtenerValores('FRETIPO', function (result) {
            $scope.fretipo = result;
        });
        valorReferencia.obtenerValores('FREDIA', function (result) {
            $scope.fredia = result;
        });
    }

    function ObtenerAlmacenes() {
        $http({
            url: url + '/api/Cliente/ObtenerCentroDistribucion',
            method: 'GET',
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-Type': 'application/json'
            },
        }).then(function successCallback(response) {
            $scope.centroDist = response.data;
        }, function errorCallback(response) {
            console.log("DATOS: " + response.error);
        });
    }

    function ObtenerZonas() {
        $http({
            url: url + '/api/Cliente/ObtenerZonas',
            method: 'GET',
            headers: {
                'Content-Type': 'application/json',
                'Authorization': window.sessionStorage.getItem('Token')
            }

        }).then(function successCallback(response) {
            $scope.cZonas = response.data;
        }, function errorCallback(response) {

        });
    };

    function ObtenerSubEmpresas() {
        $http({
            url: url + '/api/Cliente/ObtenerSubEmpresas',
            method: 'GET',
            headers: {
                'Content-Type': 'application/json',
                'Authorization': window.sessionStorage.getItem('Token')
            }

        }).then(function successCallback(response) {
            $scope.cSubEmpresas = response.data;
        }, function errorCallback(response) {

        });
    };

    $scope.ObtenerClientes = function () {
        $http({
            url: url + '/api/Cliente/ObtenerClientes?USUId=' + window.sessionStorage.getItem('USUId').replace(/\+/g, "%2B"),
            method: 'GET',
            headers: {
                'Content-Type': 'application/json',
                'Authorization': window.sessionStorage.getItem('Token')
            }

        }).then(function successCallback(response) {
            $scope.cClientes = response.data;
            var tam = $scope.cClientes.length;
            $scope.tamPag = tamano(tam);
        }, function errorCallback(response) {

        });
    }

    $scope.EditarCliente = function (ClienteClave, Permiso, SoloLectura) {
        $scope.Permiso = Permiso;
        document.getElementById('btnAceptar').value = $scope.GetDescripcion("BTAceptar", "Aceptar");
        document.getElementById('btnCancelar').value = $scope.GetDescripcion("BTCancelar", "Cancelar");

        if (SoloLectura.toUpperCase() === "TRUE") {
            $scope.SoloLectura = true;
        }
        else {
            $scope.SoloLectura = false;
        }

        if (ClienteClave !== "") {
            $http({
                url: url + '/api/Cliente/ObtenerCliente?ClienteClave=' + ClienteClave,
                method: 'GET',
                headers: {
                    Authorization: window.sessionStorage.getItem('Token'),
                    'Content-Type': 'application/json'
                },
            }).then(function successCallback(response) {
                var data = response.data;
                if (data !== null) {
                    $scope.ClienteClave = data.ClienteClave;
                    $scope.Clave = data.Clave;
                    $scope.FechaRegistroSistema = new Date(data.FechaRegistroSistema);
                    $scope.TipoEstado = data.TipoEstado;
                    $scope.IdElectronico = data.IdElectronico;
                    $scope.FechaInactivacion = new Date(data.FechaInactivacion);
                    $scope.MotivoInactivacion = data.MotivoInactivacion;
                    $scope.RazonSocial = data.RazonSocial;
                    $scope.IdFiscal = data.IdFiscal;
                    $scope.FechaNacimiento = new Date(data.FechaNacimiento);
                    $scope.NombreCorto = data.NombreCorto;
                    $scope.NumeroSAP = data.NumeroSAP;
                    $scope.AlmacenID = data.AlmacenID;
                    $scope.DatosExtra = data.DatosExtra;
                    $scope.NombreContacto = data.NombreContacto;
                    $scope.TelefonoContacto = data.TelefonoContacto;
                    $scope.CorreoElectronico = data.CorreoElectronico;
                    $scope.PublicoGeneral = data.PublicoGeneral;
                    $scope.AseguramientoGPS = data.AseguramientoGPS;
                    $scope.TipoFiscal = data.TipoFiscal;
                    $scope.ActualizaSaldoCheque = data.ActualizaSaldoCheque;
                    $scope.Exclusividad = data.Exclusividad;
                    $scope.VigExclusividad = new Date(data.VigExclusividad);
                    $scope.ExigirOrdenCompra = data.ExigirOrdenCompra;
                    $scope.ExigirPedidoAdicional = data.ExigirPedidoAdicional;
                    $scope.FormatoPedidoAdicional = data.FormatoPedidoAdicional;
                    $scope.ValidaFolNeg = data.ValidaFolNeg;
                    $scope.VencimientoVenta = data.VencimientoVenta;
                    $scope.DiasVencimiento = data.DiasVencimiento;
                    $scope.Prestamo = data.Prestamo;
                    $scope.ValidarLimEnvase = data.ValidarLimEnvase;
                    $scope.LimiteEnvase = data.LimiteEnvase;
                    $scope.ExigirTomaInvMer = data.ExigirTomaInvMer;
                    $scope.BonificacionMasiva = data.BonificacionMasiva;
                    $scope.TipoCamion = data.TipoCamion;
                    $scope.ZonaClave = data.ZonaClave;
                    $scope.SaldoEfectivo = data.SaldoEfectivo;
                    $scope.FechaFactura = new Date(data.FechaFactura);
                    $scope.SaldoPrestamo = data.SaldoPrestamo;
                    $scope.DesgloseImpuesto = data.DesgloseImpuesto;
                    $scope.FacturacionMasiva = data.FacturacionMasiva;
                    $scope.FacturaFolioVenta = data.FacturaFolioVenta;
                    $scope.FacturaVentasMensual = data.FacturaVentasMensual;
                    $scope.GrabarDecXML = data.GrabarDecXML;
                    $scope.TipoImpuesto = data.TipoImpuesto;
                    $scope.UsoCFDI = data.UsoCFDI;
                    $scope.SitioWeb = data.SitioWeb;
                    $scope.SolicitarCapturaCompensacion = data.SolicitarCapturaCompensacion;
                    $scope.TipoEstado === 0 ? $scope.Inactivacion = true : $scope.Inactivacion = false;
                    $scope.CobranzaPendiente = data.CobranzaPendiente;
                    $scope.Nuevo = false;
                    $scope.Action = "Edit";
                }
            }, function errorCallback(response) {
            });
        }
        else {
            $http({
                url: url + '/api/Cliente/ObtenerNuevoID',
                method: 'GET',
                headers: {
                    Authorization: window.sessionStorage.getItem('Token'),
                    'Content-Type': 'application/json'
                }
            }).then(function successCallback(response) {
                $scope.ClienteClave = response.data;
                $scope.Nuevo = true;
                $scope.Action = "Create";
            }, function errorCallback(response) {

            });
        }
    }

    $scope.ValidarCliente = function () {
        $scope.esquemaRequerido = false;
        $scope.domicilioRequerido = false;
        $scope.fiscalRequerido = false;
        $scope.formaVentaRequerida = false;
        $scope.formaVentaInicialRequerida = false;
        //$scope.ordenRequerido = false;

        if ($scope.clienteEsquema.length === 0)
            $scope.esquemaRequerido = true;
        else {
            var activo = false;
            angular.forEach($scope.clienteEsquema, function (v, k) {
                if (v.TipoEstado === 1)
                    activo = true;
            });
            if (!activo)
                $scope.esquemaRequerido = true;
        }

        if ($scope.clienteDomicilio.length === 0)
            $scope.domicilioRequerido = true;
        else {
            if ($scope.DesgloseImpuesto) {
                var fiscal = false
                angular.forEach($scope.clienteDomicilio, function (v, k) {
                    if (v.Tipo === 1)
                        fiscal = true;
                });
                if (!fiscal)
                    $scope.fiscalRequerido = true;
            }
        }

        if ($scope.cliFormaVenta.length === 0)
            $scope.formaVentaRequerida = true;
        else {
            var inicial = false;
            angular.forEach($scope.cliFormaVenta, function (v, k) {
                if (v.Inicial)
                    inicial = true;
            });
            if (!inicial)
                $scope.formaVentaInicialRequerida = true;
        }

        /*if ($scope.DesgloseImpuesto) {
            angular.forEach($scope.cliConfNumCta, function (v, k) {

                if (v.Seleccionado && v.Orden === undefined) {
                }
            });
        }*/

        if ($scope.esquemaRequerido || $scope.domicilioRequerido || $scope.fiscalRequerido || $scope.formaVentaRequerida || $scope.formaVentaInicialRequerida || !$scope.form.$valid) {
            $scope.form.submitted = true;
            messageBox.Mostrar($scope.GetDescripcion("XMensajeE", "Error"), $scope.GetDescripcion("E1005", "[E1005] Existen datos inválidos que tienen que ser verificados para poder continuar"));
        }
        else
            $scope.GuardarCliente();
    }

    $scope.GuardarCliente = function () {
        //$scope.subForm.$valid = true;
        //$scope.subForm2.$valid = true;
        //$scope.bloqMensajes = false;
        if (!$scope.form.$valid) {
            $scope.form.submitted = true;
            $event.preventDefault();
        } else {
            //angular.forEach($scope.cliConfNumCta, function (v, k) {
            //    if (!v.Seleccionado)
            //        v.Orden = -1;
            //});

            var cliente = {
                ClienteClave: $scope.ClienteClave,
                Clave: $scope.Clave,
                FechaRegistroSistema: $scope.FechaRegistroSistema,
                TipoEstado: $scope.TipoEstado,
                IdElectronico: $scope.IdElectronico,
                FechaInactivacion: $scope.FechaInactivacion,
                MotivoInactivacion: $scope.MotivoInactivacion,
                RazonSocial: $scope.RazonSocial,
                IdFiscal: $scope.IdFiscal,
                FechaNacimiento: $scope.FechaNacimiento,
                NombreCorto: $scope.NombreCorto,
                NumeroSAP: $scope.NumeroSAP,
                AlmacenID: $scope.AlmacenID,
                DatosExtra: $scope.DatosExtra,
                NombreContacto: $scope.NombreContacto,
                TelefonoContacto: $scope.TelefonoContacto,
                CorreoElectronico: $scope.CorreoElectronico,
                PublicoGeneral: $scope.PublicoGeneral,
                AseguramientoGPS: $scope.AseguramientoGPS,
                TipoFiscal: $scope.TipoFiscal,
                ActualizaSaldoCheque: $scope.ActualizaSaldoCheque,
                Exclusividad: $scope.Exclusividad,
                VigExclusividad: $scope.VigExclusividad,
                ExigirOrdenCompra: $scope.ExigirOrdenCompra,
                ExigirPedidoAdicional: $scope.ExigirPedidoAdicional,
                FormatoPedidoAdicional: $scope.FormatoPedidoAdicional,
                ValidaFolNeg: $scope.ValidaFolNeg,
                VencimientoVenta: $scope.VencimientoVenta,
                DiasVencimiento: $scope.DiasVencimiento,
                Prestamo: $scope.Prestamo,
                ValidarLimEnvase: $scope.ValidarLimEnvase,
                LimiteEnvase: $scope.LimiteEnvase,
                ExigirTomaInvMer: $scope.ExigirTomaInvMer,
                BonificacionMasiva: $scope.BonificacionMasiva,
                TipoCamion: $scope.TipoCamion,
                ZonaClave: $scope.ZonaClave,
                SaldoEfectivo: $scope.SaldoEfectivo,
                FechaFactura: $scope.FechaFactura,
                DesgloseImpuesto: $scope.DesgloseImpuesto,
                FacturacionMasiva: $scope.FacturacionMasiva,
                FacturaFolioVenta: $scope.FacturaFolioVenta,
                FacturaVentasMensual: $scope.FacturaVentasMensual,
                GrabarDecXML: $scope.GrabarDecXML,
                TipoImpuesto: $scope.TipoImpuesto,
                UsoCFDI: $scope.UsoCFDI,
                SitioWeb: $scope.SitioWeb,
                SolicitarCapturaCompensacion: $scope.SolicitarCapturaCompensacion,
                ClienteEsquema: $scope.clienteEsquema,
                ClienteDomicilio: $scope.clienteDomicilio,
                ClienteMensaje: $scope.clienteMensaje,
                ClientePago: $scope.clientePago,
                CLIFormaVenta: $scope.cliFormaVenta,
                CLINoDesImp: $scope.cliNoDesImp,
                CLIConfNumCta: $scope.cliConfNumCta,
                ExcepcionFac: $scope.excepcionFac,
                ExcepcionProductoPri: $scope.excepcionProductoPri,
                MUsuarioID: window.sessionStorage.getItem('USUId')
            }

            $http({
                url: url + '/api/Cliente/Grabar?cliente=' + cliente,
                method: 'post',
                data: JSON.stringify(cliente),
                dataType: "json",
                headers: {
                    Authorization: window.sessionStorage.getItem('Token'),
                    'Content-Type': 'application/json'
                },
            }).then(function successCallback(response) {
                window.location.href = '../Cliente/Index?Permiso=' + $scope.Permiso;
            }, function errorCallback(response) {
            });

            debugger;
        }
    }

    $scope.HabilitarInactivacion = function () {
        $scope.TipoEstado === 0 ? $scope.Inactivacion = true : $scope.Inactivacion = false;
    }

    $scope.ValidarCancelar = function () {
        if (!$scope.form.$pristine) {
            $scope.Action = "Cancelar";
            messageBox.MostrarSiNo($scope.GetDescripcion("XCancelar", "Cancelar"), $scope.GetDescripcion("BP0002", "[BP0002]Se perderán los cambios. ¿Está seguro de regresar?"));
        }
        else {
            window.location.href = '../Cliente/Index?Permiso=' + $scope.Permiso;
        }
    }

    //ESQUEMAS DE CLIENTE
    $scope.myTreeControl = {};
    $scope.myTreeControl.Marcada = function (branch) {
        $scope.Activo = false;
        for (var i = 0; i < $scope.esquemasAgregar.length; i++) {
            if ($scope.esquemasAgregar[i].Clave === branch.Clave) {
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
        }).then(function successCallback(response) {
            $scope.clienteEsquema = response.data;
        }, function errorCallback(response) {

        });
    }

    $scope.AgregarClienteEsquema = function () {
        //if ($scope.EsquemasList.length > 0) {
        //    if ($scope.EsquemasList[$scope.EsquemasList.length - 1].Nombre === "") {
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
            if ($scope.esquemasAgregar[i].Clave === Clave) {
                aux = true;
            }
        }
        if (!aux) {
            $scope.esquemasAgregar.push({ 'Clave': Clave, 'Nombre': Nombre, 'EsquemaID': EsquemaID });
        }
        else {
            angular.forEach($scope.esquemasAgregar, function (value, key) {
                if (value.Clave === Clave) {
                    $scope.esquemasAgregar.splice(key, 1);
                }
            });
        }
    };

    $scope.AgregarEsquemas = function () {
        for (var i = 0; i < $scope.esquemasAgregar.length; i++) {
            var aux = false;
            if ($scope.Action === "AgregarClienteEsquema") {
                for (var j = 0; j < $scope.clienteEsquema.length; j++) {
                    if ($scope.esquemasAgregar[i].EsquemaID === $scope.clienteEsquema[j].EsquemaID) {
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
                    if ($scope.esquemasAgregar[i].EsquemaID === $scope.excepcionFac[j].EsquemaID && $scope.excepcionFac[j].SubEmpresaId === '') {
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
                if (v.EsquemaID === clave) {
                    existe = true;
                }
            });

            if (existe === false) {
                $scope.segData.push({
                    EsquemaID: clave, Nombre: nombre, TipoEstado: estado
                })
            }
        }
    }

    $scope.EliminarClienteEsquema = function (EsquemaID) {
        angular.forEach($scope.clienteEsquema, function (v, k) {
            if (v.EsquemaID === EsquemaID) {
                $scope.clienteEsquema.splice(k, 1);
            }
        })
    }

    //DOMICILIOS
    $scope.ObtenerClienteDomicilio = function (ClienteClave) {
        $http({
            url: url + '/api/Cliente/ObtenerClienteDomicilio?ClienteClave=' + ClienteClave,
            method: 'GET',
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-Type': 'application/json'
            }
        }).then(function successCallback(response) {
            $scope.clienteDomicilio = response.data;
            angular.forEach($scope.clienteDomicilio, function (v, k) {
                $http({
                    url: url + '/api/Cliente/ObtenerSecuenciaVisita?ClienteClave=' + ClienteClave + '&ClienteDomicilioID=' + v.ClienteDomicilioID.replace(/\+/g, "%2B"),
                    method: 'GET',
                    headers: {
                        Authorization: window.sessionStorage.getItem('Token'),
                        'Content-Type': 'application/json'
                    }
                }).then(function successCallback(response) {
                    v.Secuencia = response.data;
                }, function errorCallback(response) {

                });
            });

        }, function errorCallback(response) {

        });
    }

    function IniciarDomicilio() {
        $scope.Domicilio = {
            ClienteDomicilioID: "",
            Tipo: "",
            Calle: "",
            Numero: "",
            NumInt: "",
            CodigoPostal: "",
            ReferenciaDom: "",
            Colonia: "",
            Localidad: "",
            Poblacion: "",
            Entidad: "",
            Pais: "",
            CoordenadaX: "",
            CoordenadaY: "",
            GLN: "",
            CrTienda: "",
            NombreTienda: "",
            Sucursal: "",
            TipoEstado: "",
            Direccion: "",
            Secuencia: []
        };
        $scope.DomicilioNuevo = true;
        $scope.FiscalRepetido = false;
        $scope.VisitaRepetido = false;
        $scope.ActualizarDomicilio = true;
    }

    function GenerarDireccion() {
        //Se valida que exista la calle
        var calle = $scope.Domicilio.Calle === null ? "" : $scope.Domicilio.Calle;
        var numExt = $scope.Domicilio.Numero === null ? "" : $scope.Domicilio.Numero;
        var numInt = $scope.Domicilio.NumInt === null ? "" : $scope.Domicilio.NumInt;
        var colonia = $scope.Domicilio.Colonia === null ? "" : $scope.Domicilio.Colonia;
        var localidad = $scope.Domicilio.Localidad === null ? "" : $scope.Domicilio.Localidad;
        var municipio = $scope.Domicilio.Poblacion === null ? "" : $scope.Domicilio.Poblacion;
        var estado = $scope.Domicilio.Entidad === null ? "" : $scope.Domicilio.Entidad;
        var pais = $scope.Domicilio.Pais === null ? "" : $scope.Domicilio.Pais;
        domicilio = calle.toString() + " " + numExt.toString() + ", " + numInt.toString() + ", " + colonia.toString() + ", " + localidad.toString() + ", " + municipio.toString() + ", " + estado.toString() + ", " + pais.toString();
        $scope.Domicilio.Direccion = domicilio;
    }

    $scope.AgregarClienteDomicilio = function () {
        IniciarDomicilio();
        $scope.Action = "CreateDomicilio";
        defaultBox.Mostrar('', '', 'EdicionDomicilio');
    }

    $scope.EditarClienteDomicilio = function (ClienteDomicilioID, SoloLectura) {

        if (ClienteDomicilioID !== "") {
            IniciarDomicilio();
            for (var i = 0; i < $scope.clienteDomicilio.length; i++) {
                if ($scope.clienteDomicilio[i].ClienteDomicilioID === ClienteDomicilioID) {
                    $scope.Domicilio.ClienteDomicilioID = $scope.clienteDomicilio[i].ClienteDomicilioID;
                    $scope.Domicilio.Tipo = $scope.clienteDomicilio[i].Tipo;

                    $scope.Domicilio.CoordenadaX = $scope.clienteDomicilio[i].CoordenadaX;
                    $scope.Domicilio.CoordenadaY = $scope.clienteDomicilio[i].CoordenadaY;
                    mapa($scope.Domicilio.CoordenadaY, $scope.Domicilio.CoordenadaX);

                    $scope.Domicilio.Calle = $scope.clienteDomicilio[i].Calle;
                    $scope.Domicilio.Numero = $scope.clienteDomicilio[i].Numero;
                    $scope.Domicilio.NumInt = $scope.clienteDomicilio[i].NumInt;
                    $scope.Domicilio.CodigoPostal = $scope.clienteDomicilio[i].CodigoPostal;
                    $scope.Domicilio.ReferenciaDom = $scope.clienteDomicilio[i].ReferenciaDom;
                    $scope.Domicilio.Colonia = $scope.clienteDomicilio[i].Colonia;
                    $scope.Domicilio.Localidad = $scope.clienteDomicilio[i].Localidad;
                    $scope.Domicilio.Poblacion = $scope.clienteDomicilio[i].Poblacion;
                    $scope.Domicilio.Entidad = $scope.clienteDomicilio[i].Entidad;
                    $scope.Domicilio.Pais = $scope.clienteDomicilio[i].Pais;
                    $scope.Domicilio.GLN = $scope.clienteDomicilio[i].GLN;
                    $scope.Domicilio.CrTienda = $scope.clienteDomicilio[i].CrTienda;
                    $scope.Domicilio.NombreTienda = $scope.clienteDomicilio[i].NombreTienda;
                    $scope.Domicilio.Sucursal = $scope.clienteDomicilio[i].Sucursal;
                    $scope.Domicilio.TipoEstado = $scope.clienteDomicilio[i].TipoEstado;
                    GenerarDireccion();

                    $scope.Domicilio.Secuencia = $scope.clienteDomicilio[i].Secuencia;
                    //$scope.ObtenerSecuenciaVisita($scope.ClienteClave, $scope.clienteDomicilio[i].ClienteDomicilioID);
                    $TipoNoPermitido = ''; //($scope.Domicilio.Tipo === '1' || $scope.Domicilio.Tipo === '2' ? '1' : '')
                    $scope.DomicilioNuevo = false;
                    $scope.Action = "EditDomicilio";
                }
            }
            defaultBox.Mostrar('', '', 'EdicionDomicilio');
        }
    }

    $scope.GuardarClienteDomicilio = function () {
        if ($scope.Domicilio.ClienteDomicilioID !== "") {
            for (var i = 0; i < $scope.clienteDomicilio.length; i++) {
                if ($scope.clienteDomicilio[i].ClienteDomicilioID === $scope.Domicilio.ClienteDomicilioID) {
                    $scope.clienteDomicilio[i].Tipo = $scope.Domicilio.Tipo;
                    $scope.clienteDomicilio[i].Calle = $scope.Domicilio.Calle;
                    $scope.clienteDomicilio[i].Numero = $scope.Domicilio.Numero;
                    $scope.clienteDomicilio[i].NumInt = $scope.Domicilio.NumInt;
                    $scope.clienteDomicilio[i].CodigoPostal = $scope.Domicilio.CodigoPostal;
                    $scope.clienteDomicilio[i].ReferenciaDom = $scope.Domicilio.ReferenciaDom;
                    $scope.clienteDomicilio[i].Colonia = $scope.Domicilio.Colonia;
                    $scope.clienteDomicilio[i].Localidad = $scope.Domicilio.Localidad;
                    $scope.clienteDomicilio[i].Poblacion = $scope.Domicilio.Poblacion;
                    $scope.clienteDomicilio[i].Entidad = $scope.Domicilio.Entidad;
                    $scope.clienteDomicilio[i].Pais = $scope.Domicilio.Pais;
                    $scope.clienteDomicilio[i].CoordenadaX = $scope.Domicilio.CoordenadaX;
                    $scope.clienteDomicilio[i].CoordenadaY = $scope.Domicilio.CoordenadaY;
                    $scope.clienteDomicilio[i].GLN = $scope.Domicilio.GLN;
                    $scope.clienteDomicilio[i].CrTienda = $scope.Domicilio.CrTienda;
                    $scope.clienteDomicilio[i].NombreTienda = $scope.Domicilio.NombreTienda;
                    $scope.clienteDomicilio[i].Sucursal = $scope.Domicilio.Sucursal;
                    $scope.clienteDomicilio[i].TipoEstado = $scope.Domicilio.TipoEstado;
                    $scope.clienteDomicilio[i].Secuencia = $scope.Domicilio.Secuencia,
                    $scope.DomicilioNuevo = false;
                    $scope.Action = "EditDomicilio";
                }
            }
        }
        else {
            $http({
                url: url + '/api/Cliente/ObtenerNuevoID',
                method: 'GET',
                headers: {
                    Authorization: window.sessionStorage.getItem('Token'),
                    'Content-Type': 'application/json'
                }
            }).then(function successCallback(response) {
                var TipoDescripcion = '';
                valorReferencia.obtenerValorClave('DOMTIPO', $scope.Domicilio.Tipo, function (result) {
                    TipoDescripcion = result[0].Descripcion;
                    $scope.clienteDomicilio.push({
                        'ClienteDomicilioID': response.data,
                        'Tipo': $scope.Domicilio.Tipo,
                        'Calle': $scope.Domicilio.Calle,
                        'Numero': $scope.Domicilio.Numero,
                        'NumInt': $scope.Domicilio.NumInt,
                        'CodigoPostal': $scope.Domicilio.CodigoPostal,
                        'ReferenciaDom': $scope.Domicilio.ReferenciaDom,
                        'Colonia': $scope.Domicilio.Colonia,
                        'Localidad': $scope.Domicilio.Localidad,
                        'Poblacion': $scope.Domicilio.Poblacion,
                        'Entidad': $scope.Domicilio.Entidad,
                        'Pais': $scope.Domicilio.Pais,
                        'CoordenadaX': $scope.Domicilio.CoordenadaX,
                        'CoordenadaY': $scope.Domicilio.CoordenadaY,
                        'GLN': $scope.Domicilio.GLN,
                        'CrTienda': $scope.Domicilio.CrTienda,
                        'NombreTienda': $scope.Domicilio.NombreTienda,
                        'Sucursal': $scope.Domicilio.Sucursal,
                        'TipoEstado': $scope.Domicilio.TipoEstado,
                        'TipoDescripcion': TipoDescripcion,
                        'Secuencia': $scope.Domicilio.Secuencia,
                        'Nuevo': true
                    });
                });

            }, function errorCallback(response) {

            });
        }

    }

    $scope.CopiarClienteDomicilio = function () {
        var copiaDir = $scope.Domicilio.TipoCopia;

        if (copiaDir !== undefined) {
            //$http({
            //    url: url + '/api/Cliente/ObtenerNuevoID',
            //    method: 'GET',
            //    headers: {
            //        Authorization: window.sessionStorage.getItem('Token'),
            //        'Content-Type': 'application/json'
            //    }
            //}).then(function successCallback(response) {
            angular.forEach($scope.clienteDomicilio, function (v, k) {
                if (v.Tipo === copiaDir) {
                    $scope.Domicilio.ClienteDomicilioID = "";
                    //$scope.Domicilio.Tipo = '';

                    $scope.Domicilio.CoordenadaX = v.CoordenadaX;
                    $scope.Domicilio.CoordenadaY = v.CoordenadaY;
                    mapa($scope.Domicilio.CoordenadaY, $scope.Domicilio.CoordenadaX);

                    $scope.Domicilio.Calle = v.Calle;
                    $scope.Domicilio.Numero = v.Numero;
                    $scope.Domicilio.NumInt = v.NumInt;
                    $scope.Domicilio.CodigoPostal = v.CodigoPostal;
                    $scope.Domicilio.ReferenciaDom = v.ReferenciaDom;
                    $scope.Domicilio.Colonia = v.Colonia;
                    $scope.Domicilio.Localidad = v.Localidad;
                    $scope.Domicilio.Poblacion = v.Poblacion;
                    $scope.Domicilio.Entidad = v.Entidad;
                    $scope.Domicilio.Pais = v.Pais;

                    $scope.Domicilio.GLN = v.GLN;
                    $scope.Domicilio.CrTienda = v.CrTienda;
                    $scope.Domicilio.Sucursal = v.Sucursal;
                    $scope.Domicilio.NombreTienda = v.NombreTienda;
                    $scope.Domicilio.TipoEstado = v.TipoEstado;
                    GenerarDireccion();

                    $scope.DomicilioNuevo = true;
                }
            });
            //});            

        } else {
            console.log("El tipo no se ha seleccionado");
            //El tipo no se ha seleccionado por ende no se puede copiar
        }
    }

    $scope.ValidarEliminarClienteDomicilio = function (ClienteDomicilioID) {
        $scope.Action = "EliminarClienteDomicilio";
        $scope.IdEliminar = ClienteDomicilioID;
        messageBox.MostrarSiNo($scope.GetDescripcion("XEliminar", "Eliminar"), $scope.GetDescripcion("P0001", "[P0001] ¿Desea eliminar el registro seleccionado?"));

    }

    $scope.EliminarClienteDomicilio = function () {
        if ($scope.IdEliminar !== undefined) {
            angular.forEach($scope.clienteDomicilio, function (v, k) {
                if (v.ClienteDomicilioID === $scope.IdEliminar) {
                    $scope.clienteDomicilio.splice(k, 1);
                }
            });
        }
    }

    $scope.ObtenerSecuenciaVisita = function (ClienteClave, ClienteDomicilioID) {
        $http({
            url: url + '/api/Cliente/ObtenerSecuenciaVisita?ClienteClave=' + ClienteClave + '&ClienteDomicilioID=' + ClienteDomicilioID.replace(/\+/g, "%2B"),
            method: 'GET',
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-Type': 'application/json'
            }
        }).then(function successCallback(response) {
            $scope.Domicilio.Secuencia = response.data;
            //$scope.TipoSeleccionado = Tipo;
        }, function errorCallback(response) {

        });
    }

    //----MAPA----
    function mapa(latitude, longitude) {
        console.log("Función mapa");
        var myLatLng = new google.maps.LatLng(latitude, longitude);
        if (map === undefined) {
            map = new google.maps.Map(document.getElementById('map'), {
                center: myLatLng,
                zoom: 14
            });

            marker = new google.maps.Marker({
                position: myLatLng,
                map: map,
                draggable: true
            });
            geocoder = new google.maps.Geocoder();

            google.maps.event.addListener(marker, 'dragend', function () {
                myLatLng = new google.maps.LatLng(marker.position.lat(), marker.position.lng());
                geocoder.geocode({ 'location': myLatLng }, function (results, status) {
                    if (status === 'OK') {
                        if (results[1]) {
                            getCoords(marker.position.lat(), marker.position.lng(), results[0].address_components);
                            map.setCenter(myLatLng);
                        }
                    }
                });
            });
        }
        else {
            map.setCenter(myLatLng);
            marker.setPosition(myLatLng);
            //updateCoords(marker.position.lat(), marker.position.lng());
            $scope.mapa = true;
        }
        $scope.mapa = true;
    }

    $scope.CrearMapa = function () {
        GenerarDireccion();
        if ($scope.Domicilio.Direccion !== "") {
            if (geocoder === undefined)
                geocoder = new google.maps.Geocoder();

            geocoder.geocode({ "address": $scope.Domicilio.Direccion }, function (results, status) {
                if (status === google.maps.GeocoderStatus.OK) {
                    if (map === undefined) {
                        map = new google.maps.Map(document.getElementById('map'), {
                            center: results[0].geometry.location,
                            zoom: 14
                        });

                        marker = new google.maps.Marker({
                            position: results[0].geometry.location,
                            map: map,
                            draggable: true
                        });

                        google.maps.event.addListener(marker, 'dragend', function () {
                            myLatLng = new google.maps.LatLng(marker.position.lat(), marker.position.lng());
                            geocoder.geocode({ 'location': myLatLng }, function (results, status) {
                                if (status === 'OK') {
                                    if (results[1]) {
                                        getCoords(marker.position.lat(), marker.position.lng(), results[0].address_components);
                                        map.setCenter(myLatLng);
                                    }
                                }
                            });
                        });
                    }

                    map.setCenter(results[0].geometry.location);
                    marker.setPosition(results[0].geometry.location)
                    getCoords(marker.position.lat(), marker.position.lng(), results[0].address_components);
                    $scope.mapa = true;
                    return true;
                } else {
                    // generarUbicacionSecundaria();
                    $scope.mapa = false;
                    console.log("No se ha podido crear el mapa");
                    //No sé puede determinar la ubicacion por un error
                }
            });
        }


        /*if ($scope.Domicilio.Direccion !== "") {            
            
            geocoder.geocode({ "address": $scope.Domicilio.Direccion }, function (results, status) {
                //console.log(google.maps.GeocoderStatus);
                if (status === google.maps.GeocoderStatus.OK) {
                    map.setCenter(results[0].geometry.location);
                    marker.setPosition(results[0].geometry.location)                    
                    getCoords(marker.position.lat(), marker.position.lng(), results[0].address_components);
                    $scope.mapa = true;
                    return true;
                } else {
                    // generarUbicacionSecundaria();
                    $scope.mapa = false;
                    console.log("No se ha podido crear el mapa");
                    //No sé puede determinar la ubicacion por un error
                }
            });

        } else {
            console.log("No se ha ingresado una dirección");
            $scope.mapa = false;
        }*/
    }

    function updateCoords(lat, lng) {

        $scope.$apply(function () {
            $rootScope.uva = "UVAf" + lat;
            $scope.Domicilio.CoordenadaY = lat;
            $scope.Domicilio.CoordenadaX = lng;
        });

    }

    function getCoords(lat, lng, address_components) {

        $scope.$apply(function () {
            $rootScope.uva = "UVAf" + lat;
            ActualizarDireccion(address_components);
            $scope.Domicilio.CoordenadaY = lat;
            $scope.Domicilio.CoordenadaX = lng;
        });

    }

    function ActualizarDireccion(address_components) {
        for (var i = 0; i < address_components.length; i++) {
            for (var j = 0; j < address_components[i].types.length; j++) {
                if (address_components[i].types[j] === "street_number")
                    $scope.Domicilio.Numero = address_components[i].long_name;
                else if (address_components[i].types[j] === "route")
                    $scope.Domicilio.Calle = address_components[i].long_name;
                else if (address_components[i].types[j] === "sublocality")
                    $scope.Domicilio.Colonia = address_components[i].long_name;
                else if (address_components[i].types[j] === "locality")
                    $scope.Domicilio.Localidad = address_components[i].long_name;
                else if (address_components[i].types[j] === "administrative_area_level_2")
                    $scope.Domicilio.Poblacion = address_components[i].long_name;
                else if (address_components[i].types[j] === "administrative_area_level_1")
                    $scope.Domicilio.Entidad = address_components[i].long_name;
                else if (address_components[i].types[j] === "country")
                    $scope.Domicilio.Pais = address_components[i].long_name;
                else if (address_components[i].types[j] === "postal_code")
                    $scope.Domicilio.CodigoPostal = address_components[i].long_name;
            }
        }
    }

    //MENSAJES
    $scope.ObtenerClienteMensaje = function (ClienteClave) {
        $http({
            url: url + '/api/Cliente/ObtenerClienteMensaje?ClienteClave=' + ClienteClave,
            method: 'GET',
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-Type': 'application/json'
            }
        }).then(function successCallback(response) {
            $scope.clienteMensaje = response.data;
        }, function errorCallback(response) {

        });
    }

    $scope.CrearMDBMensaje = function () {
        var scope = angular.element($('#CreacionMDBMensaje')).scope();
        scope.IniciarMDBMensaje($scope);
        defaultBox.Mostrar('', '', 'CreacionMDBMensaje');
    }

    $scope.AgregarMDBMensajeNuevo = function (MDBMensajeID) {
        $http({
            url: url + '/api/MDBMensaje/ObtenerMDBMensaje?MDBMensajeID=' + MDBMensajeID.replace(/\+/g, "%2B"),
            method: 'GET',
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-Type': 'application/json'
            }
        }).then(function successCallback(response) {
            var data = response.data;
            $scope.clienteMensaje.push({
                'MDBMensajeID': data.MDBMensajeID,
                'Numero': data.Numero,
                'Asunto': data.Asunto,
                'TipoMensaje': data.TipoMensaje,
                'Descripcion': data.Descripcion,
                'TipoEstado': "1",
                'Modulos': data.Modulos,
                'Nuevo': true
            });
        }, function errorCallback(response) {

        });
    }

    $scope.BuscarMDBMensaje = function () {
        var scope = angular.element($('#SeleccionMDBMensaje')).scope();
        scope.ObtenerMDBMensajesCliente($scope);
        defaultBox.Mostrar('', '', 'SeleccionMDBMensaje');
    }

    $scope.AgregarMDBMensajes = function (seleccionados) {
        for (var i = 0; i < seleccionados.length; i++) {
            var agregar = true;
            for (var j = 0; j < $scope.clienteMensaje.length; j++) {
                if (seleccionados[i].MDBMensajeID === $scope.clienteMensaje[j].MDBMensajeID) {
                    agregar = false;
                }
            }

            if (agregar) {
                $scope.clienteMensaje.push({
                    'MDBMensajeID': seleccionados[i].MDBMensajeID,
                    'Numero': seleccionados[i].Numero,
                    'Asunto': seleccionados[i].Asunto,
                    'TipoMensaje': seleccionados[i].TipoMensaje,
                    'Descripcion': seleccionados[i].Descripcion,
                    'TipoEstado': "1",
                    'Modulos': seleccionados[i].Modulos,
                    'Nuevo': true
                });
            }
        }
    }

    $scope.EliminarClienteMensaje = function (MDBMensajeID) {
        angular.forEach($scope.clienteMensaje, function (v, k) {
            if (v.MDBMensajeID === MDBMensajeID && v.Nuevo) {
                $scope.clienteMensaje.splice(k, 1);
            }
        });
    }

    //CLIENTE PAGO
    $scope.ObtenerClientePago = function (ClienteClave) {
        $http({
            url: url + '/api/Cliente/ObtenerClientePago?ClienteClave=' + ClienteClave,
            method: 'GET',
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-Type': 'application/json'
            }
        }).then(function successCallback(response) {
            $scope.clientePago = response.data;
        }, function errorCallback(response) {

        });
    }

    $scope.AgregarClientePago = function () {
        $http({
            url: url + '/api/Cliente/ObtenerNuevoID',
            method: 'GET',
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-Type': 'application/json'
            }
        }).then(function successCallback(response) {
            $scope.clientePago.push({
                'ClientePagoID': response.data,
                'Tipo': '0',
                'TipoBanco': '0',
                'Cuenta': '',
                'TipoEstado': '1',
                'Nuevo': true
            });
        });
    }

    $scope.EliminarClientePago = function (ClientePagoID) {
        angular.forEach($scope.clientePago, function (v, k) {
            if (v.ClientePagoID === ClientePagoID) {
                $scope.clientePago.splice(k, 1);
            }
        });
    }

    $scope.ValidarEfectivo = function () {
        angular.forEach($scope.clientePago, function (v, k) {
            if (v.Tipo === 1) {
                v.Efectivo = true;
                v.TipoBanco = '0';
                v.Cuenta = '';
            }
            else
                v.Efectivo = false;
        });
    }

    //CLIFormaVenta
    $scope.ObtenerCLIFormaVenta = function (ClienteClave) {
        $http({
            url: url + '/api/Cliente/ObtenerCLIFormaVenta?ClienteClave=' + ClienteClave,
            method: 'GET',
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-Type': 'application/json'
            }
        }).then(function successCallback(response) {
            $scope.cliFormaVenta = response.data;
        }, function errorCallback(response) {

        });
    }

    $scope.AgregarCLIFormaVenta = function () {
        $scope.cliFormaVenta.push({
            'CFVTipo': '0',
            'LimiteCredito': '',
            'DiasCredito': '',
            'Inicial': false,
            'CapturaDias': false,
            'ValidaLimite': false,
            'ValidaPago': false,
            'Estado': '1',
            'Nuevo': true
        });
    }

    $scope.EliminarCLIFormaVenta = function (CFVTipo) {
        angular.forEach($scope.cliFormaVenta, function (v, k) {
            if (v.CFVTipo === CFVTipo && v.Nuevo) {
                $scope.cliFormaVenta.splice(k, 1);
            }
        });
    }

    $scope.ValidarCLIFormaVentaInicial = function (CFVTipo, Inicial) {
        if (Inicial) {
            angular.forEach($scope.cliFormaVenta, function (v, k) {
                if (v.CFVTipo !== CFVTipo) {
                    v.Inicial = false;
                }
            });
        }
    }

    //SALDOS
    $scope.ObtenerProductoPrestamoCLI = function (ClienteClave) {
        $http({
            url: url + '/api/Cliente/ObtenerProductoPrestamoCLI?ClienteClave=' + ClienteClave,
            method: 'GET',
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-Type': 'application/json'
            }
        }).then(function successCallback(response) {
            $scope.productoPrestamoCLI = response.data;
        }, function errorCallback(response) {

        });
    }

    //FACTURACION   

    //---CLINoDesImp---
    $scope.ObtenerCLINoDesImp = function (ClienteClave) {
        $http({
            url: url + '/api/Cliente/ObtenerCLINoDesImp?ClienteClave=' + ClienteClave,
            method: 'GET',
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-Type': 'application/json'
            }
        }).then(function successCallback(response) {
            $scope.cliNoDesImp = response.data;
        }, function errorCallback(response) {

        });
    }

    $scope.ObtenerImpuestos = function () {
        $http({
            url: url + '/api/Impuesto/ObtenerImpuestosActivos',
            method: 'GET',
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-Type': 'application/json'
            }
        }).then(function successCallback(response) {
            $scope.impuestos = response.data;
        }, function errorCallback(response) {

        });
    }

    $scope.AgregarCLINoDesImp = function () {
        defaultBox.Mostrar('', '', 'SeleccionImpuesto');
    }

    $scope.AgregarImpuestos = function () {
        for (var i = 0; i < $scope.impuestos.length; i++) {
            if ($scope.impuestos[i].Seleccionado) {
                var agregar = true;
                for (var j = 0; j < $scope.cliNoDesImp.length; j++) {
                    if ($scope.impuestos[i].ImpuestoClave === $scope.cliNoDesImp[j].ImpuestoClave) {
                        agregar = false;
                    }
                }

                if (agregar) {
                    $scope.cliNoDesImp.push({
                        'CNDIID': '',
                        'ImpuestoClave': $scope.impuestos[i].ImpuestoClave,
                        'Nombre': $scope.impuestos[i].Nombre,
                        'Abreviatura': $scope.impuestos[i].Abreviatura
                    });
                }
            }
        }
    }

    $scope.EliminarCLINoDesImp = function (ImpuestoClave) {
        angular.forEach($scope.cliNoDesImp, function (v, k) {
            if (v.ImpuestoClave === ImpuestoClave) {
                $scope.cliNoDesImp.splice(k, 1);
            }
        });
    }

    //CliConfNumCta
    $scope.ObtenerCliConfNumCta = function (ClienteClave) {
        $http({
            url: url + '/api/Cliente/ObtenerCliConfNumCta?ClienteClave=' + ClienteClave,
            method: 'GET',
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-Type': 'application/json'
            }
        }).then(function successCallback(response) {
            $scope.cliConfNumCta = response.data;
        }, function errorCallback(response) {

        });
    }

    //---ExcepcionFac---
    $scope.ObtenerExcepcionFac = function (ClienteClave) {
        $http({
            url: url + '/api/Cliente/ObtenerExcepcionFac?ClienteClave=' + ClienteClave,
            method: 'GET',
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-Type': 'application/json'
            }
        }).then(function successCallback(response) {
            $scope.excepcionFac = response.data;
        }, function errorCallback(response) {

        });
    }

    $scope.AgregarExcepcionFac = function () {
        seleccionEsquema.Cargar(2).then(function (data) {
            $scope.treeViewEsquema = data;
            $scope.tree_data = data;
            $scope.Action = "AgregarExcepcionFac";
            seleccionEsquema.Seleccionar();
        });
    }

    $scope.EliminarExcepcionFac = function (EsquemaID, SubEmpresaId) {
        angular.forEach($scope.excepcionFac, function (v, k) {
            if (v.EsquemaID === EsquemaID && v.SubEmpresaId === SubEmpresaId) {
                $scope.excepcionFac.splice(k, 1);
            }
        });
    }

    //PRODUCTOS PRIORITARIOS
    $scope.ObtenerExcepcionProductoPri = function (ClienteClave) {
        $http({
            url: url + '/api/Cliente/ObtenerExcepcionProductoPri?ClienteClave=' + ClienteClave,
            method: 'GET',
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-Type': 'application/json'
            }
        }).then(function successCallback(response) {
            $scope.excepcionProductoPri = response.data;
        }, function errorCallback(response) {

        });
    }

    $scope.ObtenerProductos = function () {
        $http({
            url: url + '/api/Producto/ObtenerProductosPrioritarios',
            method: 'GET',
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-Type': 'application/json'
            }
        }).then(function successCallback(response) {
            $scope.productos = response.data;
        }, function errorCallback(response) {

        });
    }

    $scope.AgregarExcepcionProductoPri = function () {
        defaultBox.Mostrar('', '', 'SeleccionProducto');
    }

    $scope.AgregarProductos = function () {
        for (var i = 0; i < $scope.productos.length; i++) {
            if ($scope.productos[i].Seleccionado) {
                var agregar = true;
                for (var j = 0; j < $scope.excepcionProductoPri.length; j++) {
                    if ($scope.productos[i].ProductoClave === $scope.excepcionProductoPri[j].ProductoClave) {
                        agregar = false;
                    }
                }

                if (agregar) {
                    $scope.excepcionProductoPri.push({
                        'ProductoClave': $scope.productos[i].ProductoClave,
                        'Nombre': $scope.productos[i].Nombre,
                        'TipoExcepcion': '0'
                    });
                }
            }
        }
    }

    $scope.EliminarExcepcionProductoPri = function (ProductoClave) {
        angular.forEach($scope.excepcionProductoPri, function (v, k) {
            if (v.ProductoClave === ProductoClave) {
                $scope.excepcionProductoPri.splice(k, 1);
            }
        });
    }

    //VALIDACIONES
    //$scope.ValidarClaveRepetida = function ($event) {
    //    $scope.claveRepetida = false;
    //    if ($scope.Clave =! "") {
    //        $http({
    //            url: url + '/api/Cliente/validarClaveCliente?clave=' + $scope.Clave + '&clienteClave=' + $scope.ClienteClave,
    //            method: 'GET',
    //            headers: {
    //                Authorization: window.sessionStorage.getItem('Token'),
    //                'Content-Type': 'application/json'
    //            }
    //        }).then(function successCallback(response) {
    //            if (data === true) {                    
    //                $scope.claveRepetida = true;
    //            }
    //        }, function errorCallback(response) {

    //        });
    //    }
    //}

    //RESULTADO MENSAJES SISTEMA
    $scope.AceptarYesNoMsgBox = function () {
        messageBox.Cerrar();
        if ($scope.Action === "EliminarClienteDomicilio") {
            $scope.EliminarClienteDomicilio();
        }
        else if ($scope.Action === "Cancelar") {
            window.location.href = '../Cliente/Index?Permiso=' + $scope.Permiso;
        }
    }

    //Botón Cancelar
    $scope.btnCancelar = function () {

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

app.directive("validarClaveNueva", function ($http, $q) {
    return {
        restrict: 'A',
        require: 'ngModel',
        link: function ($scope, element, attrs, ngModel) {
            ngModel.$asyncValidators.claveNueva = function (modelValue, viewValue) {
                var defer = $q.defer();
                var clave = modelValue;
                //Sí la clave comienza con "Nuevo" entonces se hace envia el mensaje
                if (clave.toUpperCase().startsWith("NUEVO")) {
                    defer.reject();
                } else {
                    defer.resolve();
                }
                return defer.promise;
            }
        }
    }
});

app.directive("validarCodigoRepetido", function ($http, $q) {
    return {
        restrict: 'A',
        require: 'ngModel',
        link: function ($scope, element, attrs, ngModel) {
            var url = window.sessionStorage.getItem('URL');
            element.ready(function () {
                ngModel.$asyncValidators.codigoClienteRepetido = function (modelValue, viewValue) {
                    var codigo = modelValue;
                    var deferred = $q.defer();
                    var repetido = false;

                    if (codigo !== "" && codigo !== null) {
                        deferred.resolve();
                        element.bind('blur', function () {
                            $http({
                                url: url + '/api/Cliente/validarCodigo?codigo=' + codigo + '&clienteClave=' + $scope.ClienteClave,
                                method: 'GET',
                                headers: {
                                    Authorization: window.sessionStorage.getItem('Token'),
                                    'Content-Type': 'application/json'
                                }
                            }).then(function successCallback(response) {
                                if (response.data === "")
                                    deferred.resolve();
                                else
                                    deferred.reject();

                            }, function errorCallback(response) {
                                deferred.resolve();
                            });
                        });
                    }
                    else {
                        deferred.resolve();
                    }

                    return deferred.promise;

                }
            });
        }
    }
});

app.directive("validarClaveRepetida", function ($http, $q) {
    return {
        restrict: 'A',
        require: 'ngModel',
        link: function ($scope, element, attrs, ngModel) {
            var url = window.sessionStorage.getItem('URL');
            element.ready(function () {
                ngModel.$asyncValidators.claveClienteRepetida = function (modelValue, viewValue) {
                    var clave = modelValue;
                    var repetido = false;
                    var defer = $q.defer();
                    //defer.resolve();
                    //element.bind('blur', function () {
                    if (clave = ! "" && clave !== null) {
                        $http({
                            url: url + '/api/Cliente/validarClaveCliente?clave=' + modelValue + '&clienteClave=' + $scope.ClienteClave,
                            method: 'GET',
                            headers: {
                                Authorization: window.sessionStorage.getItem('Token'),
                                'Content-Type': 'application/json'
                            }
                        }).then(function successCallback(response) {
                            if (response.data === true) {
                                defer.reject();
                                repetido = true;
                            } else {
                                defer.resolve();
                            }
                        }, function errorCallback(response) {

                        });
                    }
                    //});
                    return defer.promise;
                }
            });
        }
    }
});

app.directive("validarFormato", function ($http, $q) {
    return {
        restrict: 'A',
        require: 'ngModel',
        link: function ($scope, element, attrs, ngModel) {
            element.ready(function () {
                ngModel.$asyncValidators.formatoInvalido = function (modelValue, viewValue) {
                    var defer = $q.defer();
                    if (modelValue !== "" && modelValue !== null) {
                        if (/^[aAxXz9]+[\*]*$/i.test(modelValue)) {
                            defer.resolve();
                        } else {
                            defer.reject();
                        }
                    } else {
                        defer.resolve();
                    }
                    return defer.promise;
                }
            });
        }
    }
})

app.directive("validarTipoDomicilio", function ($http, $q) {
    return {
        restrict: 'A',
        require: 'ngModel',
        link: function ($scope, element, attrs, ngModel) {
            var url = window.sessionStorage.getItem('URL');
            element.ready(function () {
                ngModel.$asyncValidators.existeTipoDomicilio = function (modelValue, viewValue) {
                    var defer = $q.defer();
                    $scope.TipoSeleccionado = modelValue;
                    if ($scope.DomicilioNuevo && (modelValue === "1" || modelValue === "2")) {
                        $http({
                            url: url + '/api/Cliente/ValidarExisteTipoDomicilio?ClienteClave=' + $scope.ClienteClave + '&Tipo=' + modelValue,
                            method: 'GET',
                            headers: {
                                Authorization: window.sessionStorage.getItem('Token'),
                                'Content-Type': 'application/json'
                            }
                        }).then(function successCallback(response) {
                            if (response.data === true) {
                                defer.reject();
                            } else {
                                defer.resolve();
                            }
                        }, function errorCallback(response) {

                        });
                    } else
                        defer.resolve();

                    return defer.promise;
                }
            });
        }
    }
});

app.controller('myCurrency', function ($scope) {

}).directive('bToCurrency', function ($filter) {
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