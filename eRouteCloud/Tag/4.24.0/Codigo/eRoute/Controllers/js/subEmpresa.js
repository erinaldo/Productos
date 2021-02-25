var app = angular.module('subEmpresa', ['valorReferencia', 'messageBox', 'ngResource', 'translation', 'defaultBox']);


app.controller('subEmpresaCtrl', ["$scope", "$rootScope", "$http", 'valorReferencia', "messageBox", "translationService", "defaultBox", function ($scope, $rootScope, $http, valorReferencia, messageBox, translationService, defaultBox) {

    var vm = $scope;
    var url = window.sessionStorage.getItem('URL');
    translationService.getTranslation($scope);
    ObtenerValoresSubEmpresa();
    ObtenerSubEmpresa();
    // $scope.grupoCFD = "CFDi";
    $scope.disponible = false;

    vm.versionCFDBloq = true;
    vm.folioFiscalBloq = true;
    vm.formatoComprobanteBloq = true;
    vm.clienteGenericoBloq = true;
    vm.botonClienteBloq = true;
    vm.directorioReportesBloq = true;
    vm.directorioDocumentosBloq = true;
    vm.archivosKeyCerBloq = true;
    vm.contrasenaBloq = true;
    vm.confirmacionContrasenaBloq = true;
    vm.proveedorBloq = true;
    vm.custIdBloq = true;
    vm.custKeyBloq = true;
    vm.servidorTimbreBloq = true;
    vm.servidorCancelBloq = true;
    $scope.confirmPassReq = false;
    vm.reciboElectronicoBloq = true;
    vm.FormatoNotaCreditoBloq = true;

    vm.inicioBloq = false;

    function ObtenerValoresSubEmpresa() {
        valorReferencia.obtenerValores('EDOREG', function (result) {
            $scope.edoreg = result;
        });
        valorReferencia.obtenerValores('VERFACTE', function (result) {
            $scope.verfacte = result;

        });
        valorReferencia.obtenerValores('FRMFAC', function (result) {
            $scope.frmfac = result;
            $scope.frmfacAux = result;
        });
        valorReferencia.obtenerValores('PROTIMB', function (result) {
            $scope.protimb = result;
        });
        valorReferencia.obtenerValores('FRMNC', function (result) {
            $scope.frmnc = result;
        });


    }
    $scope.sort = function (keyname) {
        $scope.sortKey = keyname;
        $scope.reverse = !$scope.reverse;
    }

    $scope.AsignarPermisoSubEmpresa = function (Permiso) {
        console.log("Permiso: " + Permiso);
        $scope.Permiso = Permiso;
    }

    /*SUB EMPRESA**/
    //Obtener todos los registros de subempresa
    function ObtenerSubEmpresa() {
        $http({
            url: url + '/api/SubEmpresa/ObtenerSubEmpresa',
            method: 'GET',
            headers: {
                Autorization: window.sessionStorage.getItem('Token'),
                'Content-type': 'application/json'
            }
        }).success(function (data, status) {
            $scope.cSubEmpresaList = data;
            var tam = $scope.cSubEmpresaList.length;
            $scope.tamPag = tamano(tam);
            //console.log(JSON.stringify("tam = " + tam + " Dividido = " + $scope.tamPag));
        }).error(function (error, status) {
            console.log("Hubo un error" + JSON.stringify(error));
        })
    };


    /*GUARDAR SUBEMPRESA*/
    $scope.GuardarSubEmpresa = function () {
        console.log("GuardarSubEmpresa");

        if (vm.Action == "Edit") {
            console.log("1");
            if (vm.BaseImg == "") {
                vm.lleno = false;
                console.log("2");
            } else {
                vm.lleno = true;
                console.log("3");
            }
        } else {
            console.log("4");
            if (vm.data === undefined) {
                console.log("5");
                vm.lleno = false;
            } else {
                console.log("6");
                vm.lleno = true;
            }
        }
        console.log("dfsjhdfkjsdfkjh: " + vm.rutaValidaDir);
        console.log("ComprobanteDig: " + $scope.ComprobanteDig);

        if ($scope.ComprobanteDig === undefined) {
            if (!$scope.ComprobanteDig) {
                if (vm.rutaValidaDir === undefined) {
                    vm.rutaValidaDir = false;
                } else {
                    vm.rutaValidaDir = false;
                }
            }
        }
        console.log("Pass: " + !$scope.form.$valid + " || " + vm.lleno + " || " + vm.rutaValidaDir);
        //!$scope.form.$valid | vm.lleno == false || vm.rutaValidaDir == true
        if (!$scope.form.$valid) {
            console.log("No valido");
            $scope.form.submitted = true;
        }
        else {

            $scope.data === undefined ? $scope.data = $scope.BaseImg : $scope.data = $scope.data;
            var factura = [
               {
                   ComprobanteDig: $scope.ComprobanteDig,
                   FoliosTerminal: $scope.FoliosTerminal,
                   VersionCFD: $scope.VersionCFD,
                   FormatoFactura: $scope.FormatoFactura,
                   ReciboElectronico: $scope.ReciboElectronico,
                   FormatoNC: $scope.FormatoNC,
                   ClienteClave: $scope.ClaveCliente,
                   DirRepMensual: $scope.DirRepMensual,
                   DirDocXML: $scope.DirDocXML,

                   DirArchivosFacElec: $scope.DirArchivosFacElec,
                   ContrasenaClave: $scope.ContrasenaClave,
                   ProveedorTimbre: $scope.ProveedorTimbre,
                   CustomerId: $scope.CustomerId,
                   CustomerKey: $scope.CustomerKey,
                   ServidorTimbre: $scope.ServidorTimbre,
                   ServidorCancelacion: $scope.ServidorCancelacion,
                   MUsuarioID: window.sessionStorage.getItem('USUId')
               }
            ];
            var subEm = {
                SubEmpresaId: $scope.SubEmpresaId,
                ClaveSubEmpresa: $scope.ClaveSubEmpresa,
                BaseImg: toBase64($scope.data),
                NombreEmpresa: $scope.NombreEmpresa,
                NombreCorto: $scope.NombreCorto,
                RFC: $scope.RFC,
                Telefono: $scope.Telefono,
                Calle: $scope.Calle,
                Numero: $scope.Numero,
                NumeroInterior: $scope.NumeroInterior,
                Colonia: $scope.Colonia,
                CodigoPostal: $scope.CodigoPostal,
                ReferenciaDom: $scope.ReferenciaDom,
                Localidad: $scope.Localidad,
                Ciudad: $scope.Ciudad,
                Factura: factura,
                FacturaActiva: $scope.ComprobanteDig,
                SEMHist: factura,
                Region: $scope.Region,
                Pais: $scope.Pais,
                TipoEstado: $scope.TipoEstado,
                MUsuarioID: window.sessionStorage.getItem('USUId')
            };

            console.log("SubEm: " + JSON.stringify(subEm));


            $http({
                url: url + '/api/SubEmpresa/Guardar?subEm=' + subEm,
                method: 'POST',
                data: JSON.stringify(subEm),
                dataType: "json",
                headers: {
                    Autorization: window.sessionStorage.getItem('TOKEN'),
                    'Content-Type': 'Application/json'
                }
            }).success(function (data, status) {
                window.location.href = '../SubEmpresa/Index?Permiso=' + $scope.Permiso;
            }).error(function (error, status) {

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

    $scope.EditarSubEmpresa = function (subEmpresaId, Permiso, SoloLectura) {
        $scope.Permiso = Permiso;
        if (SoloLectura.toUpperCase() == "TRUE") {
            $scope.SoloLectura = true;
        }
        else {
            $scope.SoloLectura = false;
        }

        if (subEmpresaId != "") {
            $http({
                url: url + '/api/SubEmpresa/ObtenerSubEmpresa?sub=' + subEmpresaId,
                method: 'GET',
                headers: {
                    Authorization: window.sessionStorage.getItem('Token'),
                    'Content-Type': 'application/json'
                },
            }).success(function (data, status) {
                angular.forEach(data, function (subEm) {
                    $scope.SubEmpresaId = subEm.SubEmpresaId;
                    $scope.ClaveSubEmpresa = subEm.ClaveSubEmpresa;
                    $scope.NombreCorto = subEm.NombreCorto;
                    $scope.NombreEmpresa = subEm.NombreEmpresa;
                    $scope.BaseImg = subEm.BaseImg
                    $scope.RFC = subEm.RFC;
                    $scope.Pais = subEm.Pais;
                    $scope.Region = subEm.Region;
                    $scope.Localidad = subEm.Localidad;
                    $scope.ReferenciaDom = subEm.ReferenciaDom;
                    vm.cFacturaList = subEm.Factura;
                    $scope.Ciudad = subEm.Ciudad;
                    $scope.Colonia = subEm.Colonia;
                    $scope.Calle = subEm.Calle;
                    $scope.Numero = subEm.Numero;
                    $scope.NumeroInterior = subEm.NumeroInterior;
                    $scope.CodigoPostal = subEm.CodigoPostal;
                    $scope.Telefono = subEm.Telefono;
                    $scope.TipoEstado = subEm.TipoEstado;
                    vm.facturas = subEm.factura;

                });

                angular.forEach(vm.cFacturaList, function (se) {
                    vm.ClaveCliente = se.ClienteClave;
                    vm.ComprobanteDig = se.ComprobanteDig;
                    vm.FormatoFactura = se.FormatoFactura;
                    vm.ReciboElectronico = se.ReciboElectronico;
                    vm.FormatoNC = "" + se.FormatoNC;
                    vm.FoliosTerminal = se.FoliosTerminal;
                    vm.RfcCliente = se.RfcCliente;
                    vm.NombreCliente = se.NombreCliente;
                    vm.DirRepMensual = se.DirRepMensual;
                    vm.DirDocXML = se.DirDocXML;
                    vm.DirArchivosFacElec = se.DirArchivosFacElec;
                    vm.ContrasenaClave = se.ContrasenaClave;
                    vm.confirmacionContrasena = se.confirmacionContrasena;
                    vm.ArchivoPEM = se.ArchivoPEM;
                    vm.VersionCFD = se.VersionCFD;
                    vm.ProveedorTimbre = se.ProveedorTimbre;
                    vm.CustomerId = se.CustomerId;
                    vm.CustomerKey = se.CustomerKey;
                    vm.ServidorTimbre = se.ServidorTimbre;
                    vm.ServidorCancelacion = se.ServidorCancelacion;
                });

                //  vm.ComprobanteDig ? vm.bloquearCampos() : "";
                if (vm.ComprobanteDig) {
                    vm.bloquearCampos();
                    vm.inicioBloq = true;
                    vm.confirmacionContrasena = vm.ContrasenaClave;
                    vm.proveedorBloq = false;
                    vm.custIdBloq = false;
                    vm.custKeyBloq = false;
                    vm.servidorTimbreBloq = false;
                    vm.servidorCancelBloq = false;

                }
                else {
                    vm.inicioBloq = false;
                    vm.proveedorBloq = true;
                    vm.custIdBloq = true;
                    vm.custKeyBloq = true;
                    vm.servidorTimbreBloq = true;
                    vm.servidorCancelBloq = true;
                    vm.versionCFDBloq = true;
                    vm.folioFiscalBloq = true;
                    vm.clienteGenericoBloq = true;
                    vm.botonClienteBloq = true;
                    vm.directorioDocumentosBloq = true;
                    vm.archivosKeyCerBloq = true;
                    vm.contrasenaBloq = true;
                    vm.confirmacionContrasenaBloq = true;
                    vm.confirmPassReq = false;
                    vm.dirRequerido = false;
                    vm.directorioReportesBloq = true;
                    vm.formatoComprobanteBloq = true;
                    vm.FormatoNotaCreditoBloq = true;
                }


                $scope.Action = "Edit";
                $scope.Nuevo = false;
            }).error(function (error, status) {
                console.log(" ERRORES ");
            });
        } else {
            $scope.Action = "Create";
            $scope.Nuevo = true;
            $scope.TipoEstado = "1";
            $scope.FormatoNC = "1";
        }


    }
    $scope.ValidarEliminarSubEmpresa = function (SubEmpresaId) {
        console.log("SubEmpresaId: " + SubEmpresaId);
        $scope.Action = "Delete";
        $scope.IndexSubEmpresa = SubEmpresaId;
        messageBox.MostrarSiNo($scope.translation.XEliminar, $scope.translation.P0001);//Validar si se deja ese mensaje o se cambia por "¿Está seguro de eliminar la descripción?"
    }


    $scope.ValidarCancelar = function () {

        if (!$scope.form.$pristine) {
            $scope.Action = "Cancel";
            messageBox.MostrarSiNo($scope.translation.XCancelar, $scope.translation.BP0002);
        }
        else {
            window.location.href = '../SubEmpresa/Index?Permiso=' + $scope.Permiso;
        }
    }
    $scope.AceptarYesNoMsgBox = function () {
        messageBox.Cerrar();
        if ($scope.Action == "Delete") {
            console.log("Eliminando SubEmpresa: (ID) " + $scope.IndexSubEmpresa);
            $http({
                url: url + '/api/SubEmpresa/EliminarSubEmpresa?SubEmpresaId=' + $scope.IndexSubEmpresa,
                method: 'GET',
                headers: {
                    Authorization: window.sessionStorage.getItem('Token'),
                    'ContentType': 'Application/json'
                }
            }).success(function (data, status) {
                console.log("Eliminado");
                window.location.href = '../SubEmpresa/Index?Permiso=' + $scope.Permiso;
            }).error(function () {
                console.log("Hubo un error al intentar eliminar.");
            });
        } else if ($scope.Action == "Cancel") {
            window.location.href = '../SubEmpresa/Index?Permiso=' + $scope.Permiso;
        }

    }
    //Solo es una prueba
    $scope.prueba = function () {

        vm.holaMundo = "Funciona como Scope";
        console.log("Soy una prueba");
    }



    //*******FACTURA ELECTRONICA********/
    /*verifica si la ruta de la carpeta existe en el equipo*/
    $scope.VerificarRuta = function () {
        var ruta = $scope.DirDocXML;

        if ($scope.DirDocXML != undefined) {
            if ($scope.DirDocXML != "") {
                ruta = ruta.replace("\\", "\\")
            }
        } else {
            console.log("Ocurrió un error");
        }


        $http({
            url: url + '/api/SubEmpresa/VerificarRuta?ruta=' + ruta,
            method: 'GET',
            header: {
                Authorization: window.sessionStorage.getItem('Token'),
                'ContentType': 'Application/octet-stream'
            }
        }).success(function (data, status) {

            if (data) {
                console.log("Ruta valida...");
            } else {
                console.log("Ruta Invalida...");
            }

        }).error(function (error, status) {
            console.log("Hubo un error");
        });

    }
    //  VER HISTORIAL CFD
    $scope.verHistorial = function (SubEmpresaID) {
        // verHistorial();

        $http({
            url: url + '/api/SubEmpresa/ObtenerHistorialSemHist?SubEmpresaID=' + SubEmpresaID,
            method: 'GET',
            headers: {
                Autorization: window.sessionStorage.getItem('Token'),
                'Content-type': 'application/json'
            }
        }).success(function (data, status) {
            $scope.HistorialList = data;

            $scope.UserHist = data[0].MUsuarioID;
            //console.log("SEMHistorial: " + JSON.stringify(data) + " User: " + $scope.UserHist);
        }).error(function (error, status) {
            console.log("Hubo un error" + JSON.stringify(error));
            $scope.loading = false;
        }).finally(function (e) {
            defaultBox.Mostrar("Historico de Configuracion", 'Hola', "HistorialBox");
            $scope.loading = false;
            var tam = $scope.HistorialList.length;
            $scope.tamPagEq = tamano(tam);
        });;

        //$(".camposInput").attr('checked', false);
        //defaultBox.Mostrar('Histórico de Configuración', '', 'HistorialBox');
    }

    /**Agrega los clientes para hacer la seleccion de uno*/
    $scope.AgregarCliente = function () {
        //Mostrar(titulo, mensaje, IdModal)
        //ObtenerClientes();

        $scope.loading = true;

        $http({
            url: url + '/api/SubEmpresa/ObtenerClientes',
            method: 'GET',
            headers: {
                Autorization: window.sessionStorage.getItem('Token'),
                'Content-type': 'application/json'
            }
        }).success(function (data, status) {
            $scope.cClientesList = data;

        }).error(function (error, status) {
            console.log("Hubo un error" + JSON.stringify(error));
            $scope.loading = false;
        }).finally(function (e) {
            defaultBox.Mostrar("Clientes", "", "ClientesBox");
            $scope.loading = false;
            var tam = $scope.cClientesList.length;
            $scope.clientePag = tamano(tam);
        });;


    }
    $scope.addClienteGenerico = function (rfc, nombre, clave) {
        debugger;
        //console.log("Cliente generico");
        $scope.RfcCliente = rfc;
        $scope.NombreCliente = nombre;
        $scope.ClaveCliente = clave;
        defaultBox.Cerrar("ClientesBox");
        $scope.cClientesList = [];
    }
    $scope.Cancelar = function () {
        defaultBox.Cerrar("ClientesBox");
        $scope.cClientesList = [];
    }
    $scope.GuardarFacturacion = function () {


        if (!$scope.formFact.$valid) {
            console.log("hola 1");
            $scope.form.submitted = true;
        } else {

            var factura = {
                ComprobanteDig: $scope.ComprobanteDig,
                FoliosTerminal: $scope.FoliosTerminal,
                VersionCFD: $scope.VersionCFD,
                FormatoFactura: $scope.FormatoFactura,
                ClienteClave: $scope.ClienteClave,
                IdFiscal: $scope.RfcCliente,
                DirRepMensual: $scope.DirRepMensual,
                DirDocXML: $scope.DirDocXML,
                DirArchivosFacElec: $scope.DirArchivosFacElec,
                ContrasenaClave: $scope.ContrasenaClave,
                ProveedorTimbre: $scope.ProveedorTimbre,
                CustomerId: $scope.CustomerId,
                CustomerKey: $scope.CustomerKey,
                ServidorTimbre: $scope.ServidorTimbre,
                ServidorCancelacion: $scope.ServidorCancelacion
            }
            console.log("hola 2" + JSON.stringify(factura));
            $http({
                url: url + '/api/SubEmpresa/GuardarFactura?factura=' + factura,
                method: 'POST',
                data: JSON.stringify(factura),
                dataType: 'json',
                headers: {
                    Authorization: window.sessionStorage.getItem('Token'),
                    'Data-Type': 'Application/json'
                }
            }).success(function (data, status) {
                console.log("Datos guardados correctamente.");
            }).error(function (error, status) {
                console.log("Hub un error!");
            });
        }

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

    //ObtnerFormatos
    $scope.ObtenerFormatos = function () {
        debugger;
        var version = $scope.VersionCFD;
        //console.log("Dentro de ObtenerFormatos: " + version + " Comprobante: " + $scope.ComprobanteDig);
        if ($scope.ComprobanteDig != undefined) {
            debugger;
            if ($scope.ComprobanteDig) {
                if (version === undefined) {
                    debugger;
                    $scope.frmfac = [];
                    vm.formatoComprobanteBloq = true;
                    vm.directorioReportesBloq = true;
                    vm.proveedorBloq = true;
                    vm.custIdBloq = true;
                    vm.custKeyBloq = true;
                    vm.servidorTimbreBloq = true;
                    vm.servidorCancelBloq = true;
                    vm.dirRequerido = false;
                } else {
                    vm.formatoComprobanteBloq = false;
                    vm.dirRequerido = true;
                    $scope.frmfac = $scope.frmfacAux;

                    $http({
                        url: url + '/api/SubEmpresa/ObtenerGrupo?vavclave=' + version,
                        method: "GET",
                        headers: {
                            Authorization: sessionStorage.getItem('Token'),
                            'Content-Type': 'application/json'
                        }
                    }).success(function (data, status) {
                        angular.forEach(data, function (it) {
                            $scope.grupoCFD = it.Grupo
                            NombreGrupo = it.Grupo
                        });

                        //console.log("Grupo: " + $scope.grupoCFD);
                        //console.log("Grupo: " + NombreGrupo);
                        //if (NombreGrupo == "PREF") {
                        //    $scope.grupoCFD
                        //}

                        if (vm.grupoCFD == "CFD") {
                            vm.directorioReportesBloq = false;
                            vm.dirRequerido = true;
                            //vm.directorioDocumentosBloq = false;
                            //vm.archivosKeyCerBloq = false;
                            vm.proveedorBloq = true;
                            vm.custKeyBloq = true;
                            vm.servidorTimbreBloq = true;
                            vm.servidorCancelBloq = true;
                        }
                        if (vm.grupoCFD == "CFDi") {
                            vm.directorioReportesBloq = true;
                            vm.proveedorBloq = false;
                            //vm.custIdBloq = false;
                            vm.custKeyBloq = false;
                            vm.servidorTimbreBloq = false;
                            vm.servidorCancelBloq = false;
                            vm.dirRequerido = false;
                        } else {

                        }


                    }).error(function (error, status) {
                        console.log("Error: ");
                    });
                }
            }
        }
    }
    //ObtenerVersionNC
    $scope.ObtenerVersionNC = function () {
        debugger;
        var version = $scope.VersionCFD;
        if ($scope.ComprobanteDig != undefined) {
            debugger;
            if ($scope.ComprobanteDig) {
                if (version === undefined) {
                    debugger;
                    var versionDescripcion;
                } else {
                    $http({
                        url: url + '/api/SubEmpresa/ObtenerVersionNC?vavclave=' + version,
                        method: "GET",
                        headers: {
                            Authorization: sessionStorage.getItem('Token'),
                            'Content-Type': 'application/json'
                        }
                    }).success(function (data, status) {
                        angular.forEach(data, function (it) {
                            //$scope.grupoCFD = it.Grupo
                            versionDescripcion = it.Descripcion
                        });
                        //console.log("Grupo: " + $scope.grupoCFD);
                        //console.log("Version: " + versionDescripcion);

                        if (versionDescripcion == "3.2" | versionDescripcion == "3.3") {
                            vm.FormatoNotaCreditoBloq = false;
                            if (versionDescripcion == "3.3") {
                                vm.reciboElectronicoBloq = false;
                            }
                            else {
                                vm.reciboElectronicoBloq = true;
                            }
                        }
                        else {
                            vm.FormatoNotaCreditoBloq = true;
                            vm.reciboElectronicoBloq = true;
                        }
                    }).error(function (error, status) {
                        console.log("Error: ");
                    });
                }
            }
        }
    }
    //ObtenerProveedorTimbre
    $scope.ObtenerProveedorTimbre = function () {
        //debugger;
        var version = $scope.ProveedorTimbre;
        if ($scope.ComprobanteDig != undefined) {
            //debugger;
            if ($scope.ComprobanteDig) {
                if (version === undefined) {
                    //debugger;
                    var proveedorDescripcion;
                } else {
                    $http({
                        url: url + '/api/SubEmpresa/ObtenerProveedorTimbre?vavclave=' + version,
                        method: "GET",
                        headers: {
                            Authorization: sessionStorage.getItem('Token'),
                            'Content-Type': 'application/json'
                        }
                    }).success(function (data, status) {
                        angular.forEach(data, function (it) {
                            //$scope.grupoCFD = it.Grupo
                            proveedorDescripcion = it.Descripcion
                        });
                        //console.log("Grupo: " + $scope.grupoCFD);
                        //console.log("Proveedor Timbre: " + proveedorDescripcion);

                        if (proveedorDescripcion != "") {
                            if (proveedorDescripcion == "iTimbre" | proveedorDescripcion == "FEL" | proveedorDescripcion == "eDoc") {
                                vm.custIdBloq = false;
                                vm.servidorTimbreBloq = false;
                                vm.servidorCancelBloq = true;
                            }
                            if (proveedorDescripcion == "Digital Invoice" | proveedorDescripcion == "Finkok") {
                                vm.servidorTimbreBloq = true;
                                vm.servidorCancelBloq = true;
                                vm.custIdBloq = false;
                            }
                            if (proveedorDescripcion == "Tralix") {
                                vm.custIdBloq = true;
                                vm.servidorTimbreBloq = false;
                                vm.servidorCancelBloq = false;
                            }

                        }
                        else {
                            
                        }
                    }).error(function (error, status) {
                        console.log("Error: ");
                    });
                }
            }
        }
    }


    //Bloquea todos los campos
    $scope.bloquearCampos = function () {
        debugger;
        var activo = vm.ComprobanteDig;
        vm.versionCFDBloq = !activo;
        vm.folioFiscalBloq = !activo;
        vm.clienteGenericoBloq = !activo;
        vm.botonClienteBloq = !activo;
        vm.directorioDocumentosBloq = !activo;
        vm.archivosKeyCerBloq = !activo;
        vm.contrasenaBloq = !activo;
        vm.inicioBloq = activo;

        vm.dirRequerido = false;
        vm.directorioReportesBloq = true;
        vm.proveedorBloq = true;
        vm.custIdBloq = true;
        vm.custKeyBloq = true;
        vm.servidorTimbreBloq = true;
        vm.servidorCancelBloq = true;

        if (activo) {
            //console.log("VersionCFD: " + $scope.VersionCFD + " activo");

            if ($scope.VersionCFD != "0") {
                console.log("Valor de la Version: " + $scope.VersionCFD);
            }

            //Si no se ha seleccionado nada el directorio no es requerido y se mantiene bloqueado
            if ($scope.VersionCFD === undefined) {
                vm.dirRequerido = false;
                vm.directorioReportesBloq = true;
                vm.proveedorBloq = true;
                vm.custIdBloq = true;
                vm.custKeyBloq = true;
                vm.servidorTimbreBloq = true;
                vm.servidorCancelBloq = true;
                vm.formatoComprobanteBloq = true;

            } else {

                //Sí se seleccionó una versión entonces el directorio es requerido y se desbloquea.
                if ($scope.VersionCFD === null) {
                    vm.dirRequerido = false;
                    vm.formatoComprobanteBloq = true;
                    vm.directorioReportesBloq = true;
                    vm.proveedorBloq = true;
                    vm.custIdBloq = true;
                    vm.custKeyBloq = true;
                    vm.servidorTimbreBloq = true;
                    vm.servidorCancelBloq = true;
                } else {
                    //console.log("kjkjhkjh");
                    vm.dirRequerido = true;
                    vm.formatoComprobanteBloq = false;
                    vm.directorioReportesBloq = false;
                    vm.proveedorBloq = true;
                    vm.custIdBloq = true;
                    vm.custKeyBloq = true;
                    vm.servidorTimbreBloq = true;
                    vm.servidorCancelBloq = true;

                }
            }
        } else {
            //console.log("Comprobante: " + $scope.ComprobanteDig + " se desactiva");

            

            //Cuando se desactiva la factura
            debugger;

            vm.inicioBloq = false;
            vm.versionCFDBloq = true;
            vm.folioFiscalBloq = true;
            vm.clienteGenericoBloq = true;
            vm.botonClienteBloq = true;
            vm.formatoComprobanteBloq = true;
            vm.reciboElectronicoBloq = true;
            vm.FormatoNotaCreditoBloq = true;

            //  DIRECTORIOS
            vm.directorioReportesBloq = true;
            vm.directorioDocumentosBloq = true;
            vm.archivosKeyCerBloq = true;
            vm.dirRequerido = false;

            //  CONTRASEÑA
            vm.contrasenaBloq = true;
            vm.confirmacionContrasenaBloq = true;
            vm.confirmPassReq = false;

            //  CFD V3
            vm.proveedorBloq = true;
            vm.custIdBloq = true;
            vm.custKeyBloq = true;
            vm.servidorTimbreBloq = true;
            vm.servidorCancelBloq = true;
        }
    }

    vm.validaRutaDir = function () {
        if (vm.DirRepMensual === undefined) {
            vm.rutaValidaDir = false;
        } else {
            $http({
                url: url + '/api/SubEmpresa/VerificarRuta?ruta=' + vm.DirRepMensual,
                method: 'GET',
                header: {
                    Authorization: window.sessionStorage.getItem('Token'),
                    'ContentType': 'Application/octet-stream'
                }
            }).success(function (data, status) {
                if (data) {
                    vm.rutaValidaDir = false;
                } else {
                    vm.rutaValidaDir = true;
                }
            }).error(function (error, status) {
                console.log("Hubo un error");
                vm.rutaValidaDir = true;
            });
        }
    }

    //**Define las páginas que se utilizaran al mostrar los registros de SubEmpresa**//
    //function tamano(tam) {
    //    var tamPag = 0;
    //    if (tam <= 100)
    //        tamPag = 20;
    //    else if (tam <= 1000 && tam > 100)
    //        tamPag = Math.floor(tam / 3);
    //    else if (tam <= 10000 && tam > 1000)
    //        tamPag = Math.floor(tam / 10);
    //    else if (tam <= 100000 && tam > 10000)
    //        tamPag = Math.floor(tam / 40);
    //    else if (tam <= 200000 && tam > 100000)
    //        tamPag = Math.floor(tam / 70);
    //    else if (tam <= 300000 && tam > 200000)
    //        tamPag = Math.floor(tam / 80);
    //    else if (tam <= 400000 && tam > 300000)
    //        tamPag = Math.floor(tam / 90);
    //    else if (tam <= 500000 && tam > 400000)
    //        tamPag = Math.floor(tam / 100);
    //    else if (tam <= 600000 && tam > 500000)
    //        tamPag = Math.floor(tam / 60);
    //    else if (tam <= 1000000 && tam > 600000)
    //        tamPag = Math.floor(tam / 40);
    //    else
    //        tamPag = Math.floor(tam / 40);
    //    return tamPag;
    //}

}]);

app.directive('validarClave', function ($http, $q, $timeout) {
    return {
        restrict: 'A',
        require: 'ngModel',
        link: function ($scope, element, attr, ngModel) {
            var validar = attr.validarClave;
            var url = window.sessionStorage.getItem('URL');
            //Model Value : refleja el valor real que existe en el modelo
            //View Value : refleja una cadena del valor del modelo
            ngModel.$asyncValidators.clienteEncontrado = function (modelValue, viewValue) {
                var def = $q.defer();
                var claveCliente = viewValue, rfc, nombre;

                $http({
                    url: url + '/api/SubEmpresa/ValidarClaveCliente?ClienteClave=' + claveCliente,
                    method: 'GET',
                    headers: {
                        Autorization: window.sessionStorage.getItem('Token'),
                        'Data-Type': 'Application/json'
                    }
                }).success(function (data, status) {

                    if (data) {
                        if (data.length > 0) {
                            angular.forEach(data, function (it) {
                                rfc = it.IdFiscal;
                                nombre = it.NombreContacto;
                            });

                            $scope.RfcCliente = rfc;
                            $scope.NombreCliente = nombre;

                        } else {
                            $scope.RfcCliente = "";
                            $scope.NombreCliente = "";
                            def.reject();
                        }
                    } else {
                        def.reject();
                    }
                }).error(function () {
                    def.reject();
                });

                def.resolve();
                return def.promise;
            }
        }
    }
});


app.directive('fileSelect', ['$window', function ($window) {
    return {
        restrict: 'A',
        require: 'ngModel',
        link: function (scope, el, attr, ctrl) {
            var fileReader = new $window.FileReader();
            fileReader.onload = function () {
                ctrl.$setViewValue(fileReader.result);

                if ('fileLoaded' in attr) {
                    scope.$eval(attr['fileLoaded']);
                }
            };

            fileReader.onprogress = function (event) {
                console.log("3");
                if ('fileProgress' in attr) {
                    scope.$eval(attr['fileProgress'],
                    { '$total': event.total, '$loaded': event.loaded });
                    console.log("4");
                }
            };

            fileReader.onerror = function () {
                console.log("5");
                if ('fileError' in attr) {
                    scope.$eval(attr['fileError'],
                    { '$error': fileReader.error });
                    console.log("6");
                }
            };

            // var fileType = attr['fileSelect'];
            var fileType = attr['fileSelect'];

            el.bind('change', function (e) {
                var fileName = e.target.files[0];

                if (fileName === undefined) {
                    console.log("Error: No selecciono ninguna imagen!");
                } else {
                    if (/\.(gif|jpg|jpeg|tiff|png)$/i.test(fileName.name)) {
                        if (fileType === '' || fileType === 'text') {
                            fileReader.readAsText(fileName);
                            console.log("7");
                        } else if (fileType === 'data') {
                            fileReader.readAsDataURL(fileName);
                            console.log("8");
                        }
                    } else {
                        console.log("Error: No se ha podido cargar el archivo");
                    }
                }
            });
        }
    };
}]);


app.directive('uploaderModel', ["$parse", function ($parse) {
    return {
        restrict: 'A',
        link: function (scope, iElement, iAttrs) {
            iElement.on("change", function () {
                $parse(iAttrs.uploaderModel).assign(scope, iElement[0].files[0]);
            });
        }
    }
}

]);

/*VALIDAR RUTAS**/

app.directive('validarRutaCompleta', function ($http, $q, $timeout) {
    return {
        restrict: 'A',
        require: 'ngModel',
        link: function ($scope, element, attr, ngModel) {
            var validar = attr.ValidarRutaCompleta;
            var url = window.sessionStorage.getItem('URL');
            //Model Value : refleja el valor real que existe en el modelo
            //View Value : refleja una cadena del valor del modelo
            ngModel.$asyncValidators.rutaValida = function (modelValue, viewValue) {
                var defer = $q.defer();
                    ruta = viewValue;
                if ($scope.ComprobanteDig != undefined) {
                    if ($scope.ComprobanteDig) {
                        if (viewValue != undefined) {
                            if (viewValue != "") {
                                ruta = ruta.replace("\\", "\\")
                            }
                        } else {
                            console.log("Ocurrió un error");
                        }

                        $http({
                            url: url + '/api/SubEmpresa/VerificarRuta?ruta=' + ruta,
                            method: 'GET',
                            header: {
                                Authorization: window.sessionStorage.getItem('Token'),
                                'ContentType': 'Application/octet-stream'
                            }
                        }).success(function (data, status) {

                            if (data) {
                                //console.log("Ruta valida...");
                                defer.resolve();
                            } else {
                                //console.log("Ruta Invalida...");
                                defer.reject();
                            }

                        }).error(function (error, status) {
                            console.log("Hubo un error");
                            defer.reject();
                        });
                    } else {
                        defer.resolve();
                    }
                } else {
                    defer.resolve();
                }
                return defer.promise;
            }
        }
    }
});





///***VALIDA QUE LAS CONTRASEÑAS COINCIDAN***///

app.directive('pwdMatch', function ($http, $q, $timeout) {
    return {
        restrict: 'A',
        require: 'ngModel',
        link: function ($scope, element, attr, ngModel) {
            element.bind("keyup", function () {
                var validar = attr.pwdMatch;
                //Model Value : refleja el valor real que existe en el modelo
                //View Value : refleja una cadena del valor del modelo
                if (validar == "true") {
                    ngModel.$asyncValidators.matchPass = function (modelValue, viewValue) {
                        var defer = $q.defer(), passMatch = viewValue, pass = $scope.ContrasenaClave;
                        //$scope.ComprobanteDig != undefined
                        if ($scope.ComprobanteDig != undefined) {
                            //console.log("contraseña: " + pass + " Confirmar: " + passMatch);
                            if ($scope.ComprobanteDig) {
                                //if (passMatch === pass) {
                                //    defer.resolve();
                                //} else {
                                //    defer.reject();
                                //}
                                if (passMatch != pass) {
                                    defer.reject();
                                }
                                else {
                                    defer.resolve();
                                }
                            }
                            else {
                                delete $scope.confirmacionContrasena;
                                $scope.confirmacionContrasenaBloq = true;
                                $scope.confirmPassReq = false;
                                $scope.contrasenaBloq = true;
                                defer.resolve();
                            }
                        }
                        return defer.promise;
                    }
                }
            });
        }
    }
});

app.directive('validarPass', function ($http, $q, $timeout) {
    return {
        restrict: 'A',
        require: 'ngModel',
        link: function ($scope, element, attr, ngModel) {
            //keyup
            element.bind("keyup", function () {
                var validar = attr.validarPass;
                //Model Value : refleja el valor real que existe en el modelo
                //View Value : refleja una cadena del valor del modelo
                if (validar) {
                    debugger;
                    ngModel.$asyncValidators.validPass = function (modelValue, viewValue) {
                        debugger;

                        var defer = $q.defer(), pass = viewValue;
                        if ($scope.ComprobanteDig != undefined) {
                            debugger;

                            //console.log("Dentro de validarPass: " + $scope.ComprobanteDig);
                            if ($scope.ComprobanteDig) {
                                var exp = /[^a-zA-Z0-9@#$]/;
                                if (!exp.test(pass)) {
                                    $scope.confirmacionContrasenaBloq = false;
                                    $scope.confirmPassReq = true;
                                    defer.resolve();
                                } else {
                                    debugger;
                                    $scope.confirmacionContrasenaBloq = true;
                                    //$scope.confirmPassReq = false;
                                    defer.reject();
                                }
                            }
                            else {
                                //$scope.ContrasenaClave = null;
                                delete $scope.ContrasenaClave;
                                $scope.confirmacionContrasenaBloq = true;
                                $scope.confirmPassReq = false;
                                $scope.contrasenaBloq = true;
                                defer.resolve();
                            }
                        }
                        return defer.promise;
                    }
                }
            });
        }
    }
});


