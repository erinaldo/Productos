var app = angular.module('configuracion', ['directivas']);

app.factory('lenguaje', ["$http", "$q", function ($http, $q) {

    return {
        get: function (){
            var deferred = $q.defer();
            var url = window.sessionStorage.getItem('URL');

            $http({
                url: url + '/api/Configuracion/ObtenerLenguaje',
                method: 'GET',
                headers: {
                    Authorization: window.sessionStorage.getItem('Token'),
                    'Content-Type': 'application/json'
                },
            }).then(function (data) {               
                deferred.resolve(data.data);
            }).catch(function (error, status) {
                deferred.reject(error.data);
            });
            return deferred.promise;
          
        }
    }
}]);

app.controller("ctrConfiguracion", ["$scope", "$http", "valorReferencia", "messageBox", "translationService", function ($scope, $http, valorReferencia, messageBox, translationService) {

    var ctrl = this;
    var url = window.sessionStorage.getItem('URL');

    ObtenerValores();
    ObtenerMonedas();
    ObtenerSPNormalizacion();
    ObtenerSPExportarCarga();
    translationService.getTranslation($scope); //agregar en todos los controllers de las actividades para que se llenen las etiquetas con los mensajes

    function ObtenerValores() {
        valorReferencia.obtenerValores('BLENGUA', function (result) {
            $scope.blengua = result;
        });
        valorReferencia.obtenerValores('TDATO', function (result) {
            $scope.tdato = result;
        });
        valorReferencia.obtenerValores('ACTLCRE', function (result) {
            $scope.actlcre = result;
        });
        valorReferencia.obtenerValores('TIPOCOB', function (result) {
            $scope.tipocob = result;
        });
        valorReferencia.obtenerValores('TTICKET', function (result) {
            $scope.tticket = result;
        });
        valorReferencia.obtenerValores('TENVCAR', function (result) {
            $scope.tenvcar = result;
        });
    }

    function ObtenerMonedas() {
        $http({
            url: url + '/api/Monedas/ObtenerMonedas',
            method: 'GET',
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-Type': 'application/json'
            }
        }).then(function (data, status) {
            $scope.monedas = data;
        }).catch(function (error, status) {

        });
    }

    function ObtenerSPNormalizacion() {
        $http({
            url: url + '/api/Configuracion/ObtenerSPNormalizacion',
            method: 'GET',
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-Type': 'application/json'
            }
        }).then(function (data, status) {
            $scope.procNormalizacion = data;
        }).catch(function (error, status) {

        });
    }

    function ObtenerSPExportarCarga() {
        $http({
            url: url + '/api/Configuracion/ObtenerSPExportarCarga',
            method: 'GET',
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-Type': 'application/json'
            }
        }).then(function (data, status) {
            $scope.procExportarCarga = data;
        }).catch(function (error, status) {

        });
    }

    $scope.AsignarPermisos = function (Permiso) {
        $scope.Permiso = Permiso;
    }

    $scope.EditarConfiguracion = function (Permiso, SoloLectura) {
        $scope.Permiso = Permiso;
        if (SoloLectura.toUpperCase() == "TRUE") {
            $scope.SoloLectura = true;
        }
        else {
            $scope.SoloLectura = false;
        }

        $http({
            url: url + '/api/Configuracion/ObtenerConfiguracion',
            method: 'GET',
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-Type': 'application/json'
            },
        }).then(function (data, status) {
            if (data != null) {
                //Generales
                $scope.LogotipoBase64 = data.LogotipoBase64;
                $scope.NombreEmpresa = data.config.NombreEmpresa;
                $scope.RFC = data.config.RFC;
                $scope.Telefono = data.config.Telefono;
                $scope.Calle = data.config.Calle;
                $scope.Numero = data.config.Numero;
                $scope.NumeroInterior = data.config.NumeroInterior;
                $scope.Colonia = data.config.Colonia;
                $scope.CodigoPostal = data.config.CodigoPostal;
                $scope.ReferenciaDom = data.config.ReferenciaDom;
                $scope.Localidad = data.config.Localidad;
                $scope.Ciudad = data.config.Ciudad;
                $scope.Region = data.config.Region;
                $scope.Pais = data.config.Pais;
                $scope.Contrato = data.config.Contrato;
                $scope.TipoLenguaje = data.conhist.TipoLenguaje;
                $scope.MonedaID = data.conhist.MonedaID;
                $scope.MostrarLogo = data.conhist.MostrarLogo;
                //Productos
                $scope.TipoClaveProducto = data.conhist.TipoClaveProducto.toString();
                $scope.DigitoClaveProd = data.conhist.DigitoClaveProd;
                $scope.DiasSurtido = data.conhist.DiasSurtido;
                $scope.DiasMaxSurtido = data.conhist.DiasMaxSurtido;
                $scope.CambioProducto = data.conhist.CambioProducto;
                $scope.ConversionKg = data.conhist.ConversionKg;
                $scope.ActualizarEdoProducto = data.conhist.ActualizarEdoProducto;
                $scope.FiltroProductos = data.conhist.FiltroProductos;
                //Venta
                $scope.VariosPedidos = data.conhist.VariosPedidos;
                $scope.AbonoProgramado = data.conhist.AbonoProgramado;
                $scope.VenderApartado = data.conhist.VenderApartado;
                $scope.CalcPromoAuto = data.conhist.CalcPromoAuto;
                $scope.PagoAutomatico = data.conhist.PagoAutomatico;
                $scope.VentaSinSurtir = data.conhist.VentaSinSurtir;
                $scope.CancConsigLiqui = data.conhist.CancConsigLiqui;
                $scope.ExcederAbono = data.conhist.ExcederAbono;
                $scope.MostrarCEDI = data.conhist.MostrarCEDI;
                $scope.DecimalesImporte = data.conhist.DecimalesImporte;
                $scope.TicketConfigurado = data.conhist.TicketConfigurado.toString();
                $scope.PorcentajeRiesgo = data.conhist.PorcentajeRiesgo;
                $scope.TicketConfigCobranza = data.conhist.TicketConfigCobranza.toString();
                $scope.ProductosVenta = data.conhist.ProductosVenta;
                $scope.TicketConfigFactura = data.conhist.TicketConfigFactura.toString();
                $scope.TipoLimiteCredito = data.conhist.TipoLimiteCredito.toString();
                $scope.FormatoNotaVenta = data.conhist.FormatoNotaVenta.toString();
                $scope.TipoCobranza = data.conhist.TipoCobranza.toString();
                //Visita
                $scope.ClienteVariasRutas = data.conhist.ClienteVariasRutas;
                $scope.DatosCteNuevo = data.conhist.DatosCteNuevo;
                $scope.ValidaInv = data.conhist.ValidaInv;
                $scope.ConsignaSaldada = data.conhist.ConsignaSaldada;
                $scope.ConsignaContado = data.conhist.ConsignaContado;
                $scope.DiasAnteriores = data.conhist.DiasAnteriores;
                $scope.DiasPosteriores = data.conhist.DiasPosteriores;
                $scope.MaximoVisitasRDI = data.conhist.MaximoVisitasRDI;
                //Comunicacion
                $scope.DirectorioSDF = data.conhist.DirectorioSDF;
                $scope.DirInterfaz = data.conhist.DirInterfaz;
                $scope.SpNormalizacionBD = data.conhist.SpNormalizacionBD;
                $scope.TipoEnvioCarga = data.conhist.TipoEnvioCarga.toString();
                $scope.DiferenciaPreliqui = data.conhist.DiferenciaPreliqui;
                $scope.CantidadSerAct = data.conhist.CantidadSerAct;
                $scope.InterfazTXT = data.conhist.InterfazTXT;
                $scope.IntUnidadVta = data.conhist.IntUnidadVta;
                $scope.Inventario = data.conhist.Inventario;
                $scope.AuditarCarga = data.conhist.AuditarCarga;
                $scope.ProductoCarga = data.conhist.ProductoCarga;
                $scope.PreLiquidacion = data.conhist.PreLiquidacion;
                $scope.EnvioParcial = data.conhist.EnvioParcial;
                $scope.EliminaEnviado = data.conhist.EliminaEnviado;
                $scope.ActualizaCliente = data.conhist.ActualizaCliente;
                //Correo electrónico
                $scope.ServidorSMTP = data.conhist.ServidorSMTP;
                $scope.SSL = data.conhist.SSL;
                $scope.Puerto = data.conhist.Puerto;
                $scope.Correo = data.conhist.Correo;
                $scope.Password = data.conhist.Password;
                //Cargas
                $scope.SemanasCargaPromedio = data.conhist.SemanasCargaPromedio;
                $scope.ExpCargaSugerida = data.conhist.ExpCargaSugerida;
                $scope.SpCargaSugerida = data.conhist.SpCargaSugerida;
                $scope.FolioAutCarga = data.conhist.FolioAutCarga;
                //Inventario
                $scope.HabilitaInventario = data.conhist.HabilitaInventario;
                $scope.TicketConfigKardex = data.conhist.TicketConfigKardex.toString();
                //Licenciamiento
                $scope.FechaVencimiento = data.FechaVencimiento;
                //Ajuste
                $scope.AjusteSalidaBE = data.conhist.AjusteSalidaBE;
                $scope.AjusteSalidaME = data.conhist.AjusteSalidaME;
                $scope.AjusteEntradaBE = data.conhist.AjusteEntradaBE;
                $scope.AjusteEntradaME = data.conhist.AjusteEntradaME;
               
                $scope.Nuevo = false;
                $scope.Action = "Edit";
            }
        }).catch(function (error, status) {
        });
    }

    $scope.ValidarCancelar = function () {
        if (!$scope.form.$pristine) {
            $scope.Action = "Cancel";
            messageBox.MostrarSiNo($scope.translation.XCancelar, $scope.translation.BP0002);
        }
        else {
            window.location.href = '/Menu/Index';
        }
    }

    $scope.AceptarYesNoMsgBox = function () {
        messageBox.Cerrar();
        if ($scope.Action == "Cancel") {
            window.location.href = '/Menu/Index';
        }
    }

    $scope.ValidarSerial = function () {
        if ($scope.Serial1 != "" && $scope.Serial2 != "" && $scope.Serial3 != "" && $scope.Serial4 != "") {
            $http({
                url: url + '/api/Configuracion/ValidarSerial?serial=' + $scope.Serial1 + $scope.Serial2 + $scope.Serial3 + $scope.Serial4 + '&contrato=' + $scope.Contrato,
                method: 'GET',
                headers: {
                    Authorization: window.sessionStorage.getItem('Token'),
                    'Content-Type': 'application/json'
                },
            }).then(function (data, status) {
                if (data != "") {
                    $scope.FechaVencimiento = data
                    messageBox.Mostrar($scope.translation.XMensajeI, $scope.translation.I0255);
                    console.log("Serial valido");
                }
                else {
                    messageBox.Mostrar($scope.translation.XMensajeE, $scope.translation.E0899);
                    console.log("Serial invalido");
                }
            }).catch(function (error, status) {
                messageBox.Mostrar($scope.translation.XMensajeE, $scope.translation.E0896);
                console.log("Serial invalido");
            });
        }
    }

    //quita titulo de la imagen
    function toBase64(msg) {
        var existsComma = false;
        angular.forEach(msg, function (it, index) {
            if (!existsComma)
                if (it == ",") {
                    msg = msg.substr(index + 1, msg.length);
                    existsComma = true;
                }
        });
        return msg;
    }

    $scope.GuardarConfiguracion = function () {
        if (!$scope.form.$valid) {
            $scope.form.submitted = true;
            $event.preventDefault();
        } else {
            $scope.data === undefined ? $scope.data = $scope.LogotipoBase64 : $scope.data = $scope.data;
            var cfg = {
                LogotipoBase64: toBase64($scope.data),
                NombreEmpresa: $scope.NombreEmpresa,
                RFC: $scope.RFC,
                Pais: $scope.Pais,
                Region: $scope.Region,
                Localidad: $scope.Localidad,
                ReferenciaDom: $scope.ReferenciaDom,
                Ciudad: $scope.Ciudad,
                Colonia: $scope.Colonia,
                Calle: $scope.Calle,
                Numero: $scope.Numero,
                NumeroInterior: $scope.NumeroInterior,
                CodigoPostal: $scope.CodigoPostal,                
                Telefono: $scope.Telefono,
                Contrato: $scope.Contrato,
                MUsuarioID: window.sessionStorage.getItem('USUId')
            }

            var cnh = {
                TipoLenguaje: $scope.TipoLenguaje,
                MonedaID: $scope.MonedaID,
                MostrarLogo: $scope.MostrarLogo,
                //Productos
                TipoClaveProducto: $scope.TipoClaveProducto,
                DigitoClaveProd: $scope.DigitoClaveProd,
                DiasSurtido: $scope.DiasSurtido,
                DiasMaxSurtido: $scope.DiasMaxSurtido,
                CambioProducto: $scope.CambioProducto,
                ConversionKg: $scope.ConversionKg,
                ActualizarEdoProducto: $scope.ActualizarEdoProducto,
                FiltroProductos: $scope.FiltroProductos,
                //Venta
                VariosPedidos: $scope.VariosPedidos,
                AbonoProgramado: $scope.AbonoProgramado,
                VenderApartado: $scope.VenderApartado,
                CalcPromoAuto: $scope.CalcPromoAuto,
                PagoAutomatico: $scope.PagoAutomatico,
                VentaSinSurtir: $scope.VentaSinSurtir,
                CancConsigLiqui: $scope.CancConsigLiqui,
                ExcederAbono: $scope.ExcederAbono,
                MostrarCEDI: $scope.MostrarCEDI,
                DecimalesImporte: $scope.DecimalesImporte,
                TicketConfigurado: $scope.TicketConfigurado,
                PorcentajeRiesgo: $scope.PorcentajeRiesgo,
                TicketConfigCobranza: $scope.TicketConfigCobranza,
                ProductosVenta: $scope.ProductosVenta,
                TicketConfigFactura: $scope.TicketConfigFactura,
                TipoLimiteCredito: $scope.TipoLimiteCredito,
                FormatoNotaVenta: $scope.FormatoNotaVenta,
                TipoCobranza: $scope.TipoCobranza,
                //Visita
                ClienteVariasRutas: $scope.ClienteVariasRutas,
                DatosCteNuevo: $scope.DatosCteNuevo,
                ValidaInv: $scope.ValidaInv,
                ConsignaSaldada: $scope.ConsignaSaldada,
                ConsignaContado: $scope.ConsignaContado,
                DiasAnteriores: $scope.DiasAnteriores,
                DiasPosteriores: $scope.DiasPosteriores,
                MaximoVisitasRDI: $scope.MaximoVisitasRDI,
                //Comunicacion
                DirectorioSDF: $scope.DirectorioSDF,
                DirInterfaz: $scope.DirInterfaz,
                SpNormalizacionBD: $scope.SpNormalizacionBD,
                TipoEnvioCarga: $scope.TipoEnvioCarga,
                DiferenciaPreliqui: $scope.DiferenciaPreliqui,
                CantidadSerAct: $scope.CantidadSerAct,
                InterfazTXT: $scope.InterfazTXT,
                IntUnidadVta: $scope.IntUnidadVta,
                Inventario: $scope.Inventario,
                AuditarCarga: $scope.AuditarCarga,
                ProductoCarga: $scope.ProductoCarga,
                PreLiquidacion: $scope.PreLiquidacion,
                EnvioParcial: $scope.EnvioParcial,
                EliminaEnviado: $scope.EliminaEnviado,
                ActualizaCliente: $scope.ActualizaCliente,
                //Correo electrónico
                ServidorSMTP: $scope.ServidorSMTP,
                SSL: $scope.SSL,
                Puerto: $scope.Puerto,
                Correo: $scope.Correo,
                Password: $scope.Password,
                //Cargas
                SemanasCargaPromedio: $scope.SemanasCargaPromedio,
                ExpCargaSugerida: $scope.ExpCargaSugerida,
                SpCargaSugerida: $scope.SpCargaSugerida,
                FolioAutCarga: $scope.FolioAutCarga,
                //Inventario
                HabilitaInventario: $scope.HabilitaInventario,
                TicketConfigKardex: $scope.TicketConfigKardex,
                //Ajustes
                AjusteSalidaBE: $scope.AjusteSalidaBE,
                AjusteSalidaME: $scope.AjusteSalidaME,
                AjusteEntradaBE: $scope.AjusteEntradaBE,
                AjusteEntradaME: $scope.AjusteEntradaME,
                MUsuarioID: window.sessionStorage.getItem('USUId')
            }

            $http({
                url: url + '/api/Configuracion/Grabar?cfg=' + cfg,
                method: 'post',
                data: JSON.stringify(cfg),
                dataType: "json",
                headers: {
                    Authorization: window.sessionStorage.getItem('Token'),
                    'Content-Type': 'application/json'
                },
            }).then(function (data, status) {
                $http({
                    url: url + '/api/Configuracion/GrabarCONHist?cnh=' + cnh,
                    method: 'post',
                    data: JSON.stringify(cnh),
                    dataType: "json",
                    headers: {
                        Authorization: window.sessionStorage.getItem('Token'),
                        'Content-Type': 'application/json'
                    },
                }).then(function (data, status) {
                    window.location.href = '../Menu/Index';
                }).catch(function (error, status) {
                });
            }).catch(function (error, status) {
            });

            debugger;
        }
    }

}])


