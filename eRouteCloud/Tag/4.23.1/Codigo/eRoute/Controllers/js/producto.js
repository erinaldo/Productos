angular.module('producto', ['valorReferencia', 'messageBox', 'ngResource', 'translation', 'defaultBox'])

.controller('productosController', ["$scope", "$rootScope", "$http", 'valorReferencia', "messageBox", "translationService", "defaultBox", function ($scope, $rootScope, $http, valorReferencia, messageBox, translationService, defaultBox) {
    var url = window.sessionStorage.getItem('URL');
    translationService.getTranslation($scope);
    //obtenerLenguaje();
    //ObtenerValoresProducto();
    //obtenerProductos();
    //ObtenerImpuestos();
    //ObtenerEmpresas();

    obtenerProductosRelacionados();

    var vm = $scope;
    var lenguaje = "";
    /*INICIALIZACIÓN DE VARIABLES*/
    vm.TipoFase = "1";
    vm.ventaBloq = true;
    vm.impList = [];
    vm.esquema = [];
    vm.cEsquemaList = [];
    vm.TiposSeleccionado = [];
    vm.ProductoDetalle = [];
    vm.EsquemasList = [];
    vm.prodRelacionado = false;
    var canje = false;
    vm.cProContenedorList = [];
    var indexContenedor = 0;

    vm.tipoVacio = false;
    vm.productoEquivalente = [];
    //vm.productoCompetencia = [];
    // vm.cUnidadesList = [{ PRUTipoUnidad: '', CodigoBarras: '', TipoEstado: '', KgLts: 0, Volumen: 0, PorcentajeVariacion: 0, DecimalProducto: 0}];
    vm.cUnidadesList = [];
    vm.cUnidadesListDetalle = [];

    $scope.selectedRow = 0;
    //////////////////////
    function ObtenerValoresProducto() {
        valorReferencia.obtenerValores('PROFASE', function (result) {
            $scope.profase = result;
        });
        valorReferencia.obtenerValores('PROTIPO', function (result) {
            $scope.protipo = result;
        });
        valorReferencia.obtenerValores('TIPADQ', function (result) {
            $scope.tipadq = result;

        });
        valorReferencia.obtenerValores('UNIDADV', function (result) {
            $scope.unidadv = result;
        });
        valorReferencia.obtenerValores('PRUEDO', function (result) {
            $scope.pruedo = result;
        });
        valorReferencia.obtenerValores('EDOREG', function (result) {
            $scope.edoreg = result;
        });
    }

    /**OBTENER LENGUAJE*/
    //function obtenerLenguaje() {
    //      $http({
    //            url: url + '/api/Configuracion/ObtenerLenguaje',
    //            method: 'GET',
    //            headers: {
    //                Authorization: window.sessionStorage.getItem('Token'),
    //                'Content-Type': 'application/json'
    //            },
    //        }).success(function (data, status) {               
    //            //deferred.resolve(data);
    //            lenguaje = data;
    //        }).error(function (error, status) {
    //            console.log("Error: " + JSON.stringify(error));
    //        });
    //}

    vm.AsignarPermisoProductos = function (Permiso) {
        $scope.Permiso = Permiso;
    }

    /**OBTENER LA LISTA COMPLETA DE PRODUCTOS*/
    vm.obtenerProductos = function () {
        $http({
            url: url + '/api/Producto/ObtenerProductos',
            method: 'GET',
            header: {
                Autorization: window.sessionStorage.getItem('Token'),
                'Content-Type': 'application/json'
            }
        }).success(function (data, status) {
            vm.cProductoList = data;
            var tam = $scope.cProductoList.length;
            $scope.tamPag = tamano(tam);
            //console.log(JSON.stringify("tam = " + tam));
        }).error(function (error, status) {
            console.log("Error: " + JSON.stringify(error));
        });
    }

    //MÉTODO DE ORDENACIÓN
    $scope.sort = function (keyname) {
        $scope.sortKey = keyname;
        $scope.reverse = !$scope.reverse;
    }

    vm.EditarProducto = function (sProductoClave, sPermiso, sSoloLectura) {
        ObtenerEmpresas();
        ObtenerValoresProducto();
        $scope.Permiso = sPermiso;
        ObtenerImpuestos();

        if (sSoloLectura.toUpperCase() == "TRUE") {
            $scope.SoloLectura = true;
        }
        else {
            $scope.SoloLectura = false;
        }
        if (sProductoClave != "") {
            $http({
                url: url + '/api/Producto/ObtenerProducto?ProductoClave=' + sProductoClave,
                method: 'GET',
                header: {
                    Autorization: window.sessionStorage.getItem('Token'),
                    'Content-Type': 'application/json'
                }
            }).success(function (data, status) {
                angular.forEach(data, function (pro) {
                    vm.ProductoClavePRO = pro.ProductoClave;
                    vm.TipoFase = pro.TipoFase;
                    vm.Id = pro.Id;
                    vm.ClaveSAT = pro.ClaveSAT;
                    vm.Tipo = pro.Tipo;
                    vm.SubEmpresaID = pro.SubEmpresaID,
                    vm.Nombre = pro.Nombre;
                    vm.NombreLargo = pro.NombreLargo;
                    vm.LimiteDescuento = pro.LimiteDescuento;
                    vm.CaducoPermitido = pro.CaducoPermitido;
                    vm.TipoAdquisicion = pro.TipoAdquisicion;
                    vm.Contenido = pro.Contenido;
                    vm.Venta = pro.Venta;
                    vm.DecimalProducto = pro.DecimalProducto;
                    vm.Nota = pro.Nota;

                    vm.CantidadProduccion = pro.CantidadProduccion
                    vm.PRUTipoUnidad = pro.UnidadProduccion

                    if (vm.Contenido == '1') {
                        vm.prodRelacionado = true;
                    }

                });
                //console.log("Producto: " + JSON.stringify(data));

                $scope.Action = "Edit";
                $scope.Nuevo = false;
            }).error(function (error, status) {

            });
        } else {
            $scope.Nuevo = true;
            $scope.Action = "Create";
            $scope.validacion = false;
            vm.DecimalProducto = 0;
            //vm.CaducoPermitido = 0;
            vm.Tipo = "1";
            //vm.SubEmpresaId = angular.element(ddlSubEmpresaID).push();
            //vm.SubEmpresaId = "3HE1XZOGAFZ3XKL";
            //console.log("Edit Empresa: " + vm.cEmpresasList);
        }
    }

    function ObtenerEmpresas() {
        $http({
            url: url + '/api/Producto/ObtenerEmpresas',
            method: 'GET',
            header: {
                Autorization: window.sessionStorage.getItem('Token'),
                'Content-Type': 'application/json'
            }
        }).success(function (data, status) {
            vm.cEmpresasList = data;
            //console.log(data);

            if ($scope.Action == "Create") {
                //var emp = JSON.stringify(vm.cEmpresasList[0].NombreCorto).toString();
                //var element = angular.element(ddlTipoFase)[0].value;
                //angular.element(ddlTipoFase)[0].value.substring(7);

                //vm.SubEmpresaID = emp;
                //console.log("valor por ID: " + angular.element(ddlSubEmpresaID)[1].value);
                //console.log("Edit Empresa: " + JSON.stringify(vm.cEmpresasList[0].NombreCorto));
                //vm.SubEmpresaID = angular.element(ddlSubEmpresaID).push();
            }

            //console.log("Empresa: " + JSON.stringify(data));
        }).error(function (error, status) {
            console.log("Error: " + JSON.stringify(error));
        });
    }

    vm.actualizarDatosTipo = function () {
        if (vm.Tipo == '2' || vm.Tipo == '3') {
            vm.canje = true;
            //console.log("Tipo cambiado a Canje o Linea\Canje");
        } else {
            vm.canje = false;
        }
    }

    vm.validarLimiteDescuento = function () {
        //console.log("Limite: " + vm.LimiteDescuento);
        if (vm.LimiteDescuento <= 0 || vm.LimiteDescuento > 100) {
            vm.LimiteDescuento = 0;
        }
        //console.log("Despues: " + vm.LimiteDescuento);
    }
    vm.validarCaducoPermitido = function () {
        //console.log("Limite2: " + vm.CaducoPermitido);
        if (vm.CaducoPermitido < 0 || vm.CaducoPermitido > 100) {
            vm.CaducoPermitido = 0;
        }
    }
    vm.validarDecimalesPermitido = function () {
        //console.log("Limite3: " + vm.DecimalProducto);
        if (vm.DecimalProducto < 0 || vm.DecimalProducto > 4) {
            vm.DecimalProducto = 0;
        }
    }

    vm.habilitarVenta = function (content) {
        (vm.Venta === undefined) ? "" : (content == false) ? vm.Venta = false : ""
        vm.ventaBloq = !content;
    }

    //FUNCION PARA MOSTRAR EL CUADRO DE ESQUEMAS
    vm.agregarEsquema = function () {
        if (vm.ProductoClavePRO === undefined) {
            vm.mostrarError = true;
        } else {
            if (vm.ProductoClavePRO == "") {
                vm.mostrarError = true;
            } else {
                ObtenerEsquema();
                $(".camposInput").attr('checked', false);
                defaultBox.Mostrar('Esquema', '', 'EsquemaBox');
            }
        }
    }

    //OBTENER LOS ESQUEMAS DE PRODUCTOS
    function ObtenerEsquema() {
        $http({
            url: url + '/api/Producto/ObtenerEsquema',
            method: 'GET',
            header: {
                Autorization: window.sessionStorage.getItem('Token'),
                'Content-Type': 'application/json'
            }
        }).success(function (data, status) {
            vm.esquema = data;
            //vm.cEsquemaList = data;
        }).error(function (error, status) {
            console.log("Error: " + JSON.stringify(error));
        });
    }

    vm.minusPlus = function (scope, esquemaId) {
        scope.toggle();
        if ($('#esquema' + esquemaId).hasClass('glyphicon-minus')) {
            $('#esquema' + esquemaId).removeClass('glyphicon-minus');
            $('#esquema' + esquemaId).addClass('glyphicon-plus');
        } else {
            $('#esquema' + esquemaId).removeClass('glyphicon-plus');
            $('#esquema' + esquemaId).addClass('glyphicon-minus');
        }
    }

    vm.startToogle = function (scope) {
        scope.toggle();
    }
    //MUESTRA LOS ESQUEMAS
    vm.checar = function (EsquemaID, Nombre, Clave /*Abreviatura*/) {
        var existe = false;

        if (vm.cEsquemaList <= 0) {
            /*vm.cEsquemaList.push({ EsquemaID: EsquemaID, Nombre: Nombre, Clave: Clave, ProductoClave: vm.ProductoClavePRO, Abreviatura: Abreviatura, });*/
            vm.cEsquemaList.unshift({ EsquemaID: EsquemaID, Nombre: Nombre, Clave: Clave, ProductoClave: vm.ProductoClavePRO, /*Abreviatura: Abreviatura,*/ });
        } else {
            //console.log("cEsquemaList: " + vm.cEsquemaList.length);
            angular.forEach(vm.cEsquemaList, function (value, key) {
                if (value.EsquemaID == EsquemaID) {
                    existe = true;
                    vm.cEsquemaList.splice(key, 1);
                }
            });
            if (!existe) {
                //console.log("No Existe");
                /*vm.cEsquemaList.push({ EsquemaID: EsquemaID, Nombre: Nombre, Clave: Clave, ProductoClave: vm.ProductoClavePRO, Abreviatura: Abreviatura, });*/
                vm.cEsquemaList.unshift({ EsquemaID: EsquemaID, Nombre: Nombre, Clave: Clave, ProductoClave: vm.ProductoClavePRO, /*Abreviatura: Abreviatura,*/ });
            }
            //console.log(vm.cEsquemaList);
        }
        //console.log("EsquemaID: " + EsquemaID + " Nombre: " + Nombre + " Clave: " + Clave);
    }

    vm.ObtenerDetalleEsquemaProducto = function (ProductoClave) {
        //console.log("INICIA DETALLE ESQUEMA: " + ProductoClave);
        if (ProductoClave != "") {
            //console.log("ES UN EDIT");
            //Es un Edit
            $http({
                url: url + '/api/Producto/ObtenerDetalleEsquemaProducto?ProductoClave=' + ProductoClave,
                method: 'GET',
                headers: {
                    Authorization: window.sessionStorage.getItem('Token'),
                    'Content-type': 'application/json'
                }
            }).success(function (data) {
                vm.cEsquemaList = data;
                //vm.cEsquemaList = data;
            }).error(function (error) {
                console.log(error);
            });
            //Manda llamar el detalle de los impuestos mediante su clave del producto
            vm.ObtenerDetalleImpuestoProducto(ProductoClave);
            vm.ObtenerDetalleProductoUnidad(ProductoClave);
            vm.ObtenerDetalleProductoEquivalente(ProductoClave);
        }
    }

    vm.validarEliminarEsquema = function (index, EsquemaID) {
        angular.forEach(vm.cEsquemaList, function (value, key) {
            if (value.EsquemaID == EsquemaID) {
                vm.cEsquemaList.splice(key, 1);
                //   $("input[id='" + clave + "']").attr('checked', false);
            }
        });
    }

    //ABRE LA VISTA DE IMPUESTOS
    vm.AgregarImpuesto = function () {
        if (vm.ProductoClavePRO === undefined) {
            vm.mostrarErrorImpuesto = true;
        } else {
            if (vm.ProductoClavePRO == "") {
                vm.mostrarErrorImpuesto = true;
            } else {
                $(".impInput").attr('checked', false);
                defaultBox.Mostrar('titulo', '', 'ProdBox');
            }
        }
    }

    //OBTENER EL ARREGLO DE IMPUESTOS
    function ObtenerImpuestos() {
        $http({
            url: url + '/api/Producto/ObtenerImpuestos',
            method: 'GET',
            header: {
                Autorization: window.sessionStorage.getItem('Token'),
                'Content-Type': 'application/json'
            }
        }).success(function (data, status) {
            vm.cImpuestoList = data;
        }).error(function (error, status) {
            console.log("Error: " + JSON.stringify(error));
        });
    }

    //AÑADE EL IMPUESTO AL SELECCONARLO
    vm.addImpuesto = function (clave, abbr, nombre, activo) {
        var existe = false;
        if (vm.impList <= 0) {
            vm.impList.push({ eliminar: true, ImpuestoClave: clave, Abreviatura: abbr, Nombre: nombre, TipoEstado: activo });
        } else {
            angular.forEach(vm.impList, function (value, key) {
                if (value.ImpuestoClave == clave) {
                    existe = true;
                }
            });
            if (!existe) {
                vm.impList.push({ eliminar: true, ImpuestoClave: clave, Abreviatura: abbr, Nombre: nombre, TipoEstado: activo });
            }
        }
        //console.log(vm.impList);
    }

    vm.UpdateEstadoImpuesto = function (index) {
        //console.log(vm.impList);
        //vm.impList.forEach(function (el) {
        //    el.TipoEstado = angular.element(ddlEstadoImpuesto)[0].value.substring(7);
        //    console.log("TipoEstado: " + el.TipoEstado + " Impuesto");
        //    console.log(vm.impList);
        //});
    }

    //Agregar unidad de venta
    vm.AgregarUnidadVenta = function () {
        //console.log("Dentro de agregar unidad de venta");
        if (vm.ProductoClavePRO === undefined) {
            //console.log("Producto clave vació");
            vm.mostrarErrorUniVenta = true;
        } else {
            if (vm.ProductoClavePRO == "") {
                vm.mostrarErrorUniVenta = true;
            } else {
                if (vm.cUnidadesList.length < vm.unidadv.length) {
                    //console.log("Validación del tamaño de unidades");
                    //console.log("Tamaño antes: " + vm.cUnidadesList.length);
                    vm.cUnidadesList.push(
                        {
                            eliminar: true,
                            PRUTipoUnidad: '',
                            CodigoBarras: '',
                            TipoEstado: '1',
                            KgLts: 0,
                            Volumen: 0,
                            PorcentajeVariacion: 0,
                            DecimalProducto: 0,
                            ValorPuntos: 0,
                            Contenedor: '',
                            NombreContenedor: null,
                            Editable: true,
                            ProductoDetalle: []
                        });

                    var indexPush = 0;
                    indexPush = vm.cUnidadesList.length - 1;
                    //console.log("INDEXPUSH: " + indexPush);
                    //console.log("NUEVO: " + JSON.stringify(vm.cUnidadesList[indexPush].ProductoDetalle));

                    vm.cUnidadesList[indexPush].ProductoDetalle.push({ ProductoClave: vm.ProductoClavePRO, PRUTipoUnidad: '', ProductoDetClave: vm.ProductoClavePRO, NombreProducto: vm.Nombre, Prestamo: '', Factor: '1' });

                    //console.log(JSON.stringify(vm.cUnidadesList));
                }
            }
        }
    }

    vm.actualizarPRUTipoUnidad = function (index, PRUTipoUnidad) {
        var detalle = vm.cUnidadesList[index].ProductoDetalle.length;
        //alert(PRUTipoUnidad + " " + detalle);
        //vm.cUnidadesList[0].ProductoDetalle.length
        for (var i = 0; i < detalle; i++) {
            vm.cUnidadesList[index].ProductoDetalle[i].PRUTipoUnidad = PRUTipoUnidad;
        }
    }

    //ELIMINAR UNA UNIDAD DE VENTA
    vm.EliminarUnidad = function (index, tipoUni) {
        angular.forEach(vm.cUnidadesList, function (value, key) {
            if (index == key) {
                vm.cUnidadesList.splice(index, 1);
                vm.selectedRow = 0;
                vm.cUnidadesListDetalle = vm.cUnidadesList[0].ProductoDetalle;
            }
        });
        debugger;
        angular.forEach(vm.TiposSeleccionado, function (value, key) {
            debugger;
            if (tipoUni == value.VAVClave) {
                debugger;
                vm.TiposSeleccionado.splice(key, 1);
            }
        });
        if (vm.cUnidadesList.length == 0) {
            angular.forEach(vm.TiposSeleccionado, function (value, key) {
                vm.TiposSeleccionado.splice(key, 1);
            });
        }
    }

    //vm.selectedRow = null;
    vm.setClickedRow = function (index) {
        $scope.selectedRow = index;
        //alert(index);
        //console.log("Unidades de Venta para filtro: " + JSON.stringify(vm.cUnidadesList[index]));
        vm.cUnidadesListDetalle = vm.cUnidadesList[index].ProductoDetalle;
        //console.log("lista cUnidadesListDetalle");
        //console.log(JSON.stringify(vm.cUnidadesListDetalle));
    }

    //   ABRE UNA VISTA PARA SELECCIONAR UN PRODUCTO COMO CONTENEDOR
    $scope.BuscarProductoContenedor = function (sProductoClave, index) {
        $scope.loading = true;
        //console.log("CONTENEDOR DIFERENTE PARA: " + sProductoClave);
        indexContenedor = index;
        //alert(indexContenedor);

        $http({
            url: url + '/api/Producto/BuscarProductoContenedor?ProductoClave=' + sProductoClave,
            method: 'GET',
            header: {
                Autorization: window.sessionStorage.getItem('Token'),
                'Content-Type': 'application/json'
            }
        }).success(function (data, status) {
            vm.cProContenedorList = data;
            //console.log("cProContenedorList: " + vm.cProContenedorList.length);
        }).error(function (error, status) {
            console.log("Hubo un error" + JSON.stringify(error));
            console.log("Status: " + JSON.stringify(status));
            $scope.loading = false;
        }).finally(function (e) {
            defaultBox.Mostrar("Seleccionar Producto", "", "ProdContenedor");
            $scope.loading = false;
            var tam = $scope.cProContenedorList.length;
            $scope.contenedorPag = tamano(tam);
            //alert($scope.contenedorPag);
            //console.log("contenedor paginado: " + $scope.contenedorPag);
        });;
    }

    //   AGREGA EL PRODUCTO COMO CONTENIDO
    vm.addContenedor = function (productoClave, nombre) {
        //cUnidadesList[indexContenedor].ProductoDetalle
        vm.cUnidadesList[indexContenedor].Contenedor = productoClave;
        vm.cUnidadesList[indexContenedor].NombreContenedor = nombre;
        //alert(indexContenedor + " " + vm.cUnidadesList[indexContenedor].Contenedor + " " + vm.cUnidadesList[indexContenedor].NombreContenedor);
        //alert(productoClave + " " + nombre);
    }

    //  UNIDADES DE VENTAS - BUSCAR PRODUCTO RELACIONADO
    vm.BuscarProductoRelacionado = function (index) {
        if (!vm.prodRelacionado) {
            //$(".impInput").attr('checked', false);
            //defaultBox.Mostrar('titulo', '', 'ProdRelBox');

            var tipo = $('select[id="PRUTipoUnidad' + index + '"]').val();
            if (tipo == "") {
                vm.tipoVacio = true;
            } else {
                vm.tipoVacio = false;
                var PRUTipo = tipo.substring(7, tipo.length)
                $scope.PRUTipoAux = PRUTipo;
                $scope.PRUTipoIndexAux = index;
                $('.impInput').attr('checked', false);
                defaultBox.Mostrar('Productos equivalentes', '', 'ProdRelBox');
            }
        }
    }

    //  AGREGA EL PRODUCTO RELACIONADO DESDE LA INTERFAZ
    vm.addProdRel = function (ProductoClave, Nombre, PRUTipo, indexTipo) {
        if (vm.ProductoClavePRO === undefined) {
            //console.log("No se ha creado la clave");
        } else {
            if (vm.ProductoClavePRO == "") {
                //console.log("La clave del producto está vacia.");
            } else {
                angular.forEach($scope.cUnidadesList, function (value, key) {
                    if (PRUTipo == "" || PRUTipo === undefined) {
                        $scope.claveVacia = false;
                    } else {
                        if (value.PRUTipoUnidad == PRUTipo) {
                            $scope.claveVacia = true;
                            var existe = false;
                            angular.forEach(value.ProductoDetalle, function (v, k) {
                                if (v.ProductoDetClave == ProductoClave) {
                                    existe = true;
                                }
                            });
                            if (existe == false) {
                                if (value.ProductoDetalle.length <= 0) {
                                    value.ProductoDetalle.push({ Index: $scope.PRUTipoIndexAux, NombreProducto: Nombre, ProductoClave: vm.ProductoClavePRO, PRUTipoUnidad: PRUTipo, ProductoDetClave: vm.ProductoClavePRO, Prestamo: '', Factor: value.ProductoDetalle.length + 1 });
                                }
                                value.ProductoDetalle.push({ eliminar: true, Index: $scope.PRUTipoIndexAux, NombreProducto: Nombre, ProductoClave: vm.ProductoClavePRO, PRUTipoUnidad: PRUTipo, ProductoDetClave: ProductoClave, Prestamo: '', Factor: value.ProductoDetalle.length + 1 });
                            }

                        }
                    }
                }, this);
            }
        }
    }

    //  ELIMINAR UN PRODUCTO RELACIONADO
    vm.validarEliminarProductoRelacionado = function (row, index, ProductoDetClave, NombreProducto) {
        //alert("Row: " + row + " Index: " + index + " Producto: " + ProductoDetClave + " Nombre: " + NombreProducto);

        vm.cUnidadesListDetalle.splice(index, 1)
    }

    //BUSCAR PRODUCTOS EQUIVALENTES
    vm.BuscarProductosEquivalentes = function () {
        $http({
            url: url + '/api/Producto/BuscarProductosEquivalentes',
            method: 'GET',
            header: {
                Autorization: window.sessionStorage.getItem('Token'),
                'Content-Type': 'application/json'
            }
        }).success(function (data, status) {
            vm.cProductoListEq = data;
        }).error(function (error, status) {
            console.log("Error: " + JSON.stringify(error));
        }).finally(function (e) {
            defaultBox.Mostrar('Productos Equivalentes', '', 'ProdEquivBox');
            $(".camposInput").attr('checked', false);
            var tam = $scope.cProductoListEq.length;
            $scope.tamPagEq = tamano(tam);
            //console.log(JSON.stringify("tamEq = " + tam + " Dividido = " + $scope.tamPagEq));
        });;
    }


    //Agregar Productos Equivalentes
    //vm.agregarProductoEquivalente = function () {
    //    // obtenerProductos();
    //    //vm.BuscarProductosEquivalentes();
    //    $(".camposInput").attr('checked', false);
    //    defaultBox.Mostrar('Productos Equivalentes', '', 'ProdEquivBox');
    //}
    //Agregar Producto a la lista
    vm.addProductoEquivalente = function (clave, nombre, estado) {
        var existe = false;
        if (vm.productoEquivalente <= 0) {
            vm.productoEquivalente.push({ ProductoClave: clave, Nombre: nombre, TipoFase: estado });
        } else {
            angular.forEach(vm.productoEquivalente, function (value, key) {
                if (value.ProductoClave == clave) {
                    existe = true;
                }
            });
            if (!existe) {
                vm.productoEquivalente.push({ ProductoClave: clave, Nombre: nombre, TipoFase: estado });
            }
        }

        console.log("Clave: " + clave + " Nombre: " + nombre + " estado: " + estado);

    }
    //Eliminar producto equivalente
    vm.EliminarProductoEquivalente = function (index, productoClave) {
        angular.forEach(vm.productoEquivalente, function (value, key) {
            if (value.ProductoClave == productoClave) {
                vm.productoEquivalente.splice(key, 1);
                //   $("input[id='" + clave + "']").attr('checked', false);
            }
        });
    }

    function obtenerProductosRelacionados() {
        $http({
            url: url + '/api/Producto/obtenerProductosRelacionados',
            method: 'GET',
            header: {
                Autorization: window.sessionStorage.getItem('Token'),
                'Content-Type': 'application/json'
            }
        }).success(function (data, status) {

            vm.cProductoRelList = data;
        }).error(function (error, status) {
            console.log("Error: " + JSON.stringify(error));
        });
    }

    vm.UpdateProductoEquiv = function () {
        vm.productoEquivalente.forEach(function (el) {
            el.Estado = angular.element(ddlEstadoProductoEq)[0].value.substring(7);
            //console.log("Estado: " + el.Estado + " pRODUCTO eQUIVALENTE");
        })
    }


    vm.GuardarProducto = function () {
        if (!$scope.form.$valid) {
            $scope.form.submitted = true;
            console.log("Existen campos vacios");
            console.log("venta: " + vm.enta);
        } else {

            var producto = {
                ProductoClave: vm.ProductoClavePRO,
                TipoFase: vm.TipoFase,
                Id: vm.Id,
                ClaveSAT: vm.ClaveSAT,
                Tipo: vm.Tipo,
                SubEmpresaID: vm.SubEmpresaID,
                Nombre: vm.Nombre,
                NombreLargo: vm.NombreLargo,
                LimiteDescuento: vm.LimiteDescuento,
                CaducoPermitido: vm.CaducoPermitido,
                TipoAdquisicion: vm.TipoAdquisicion,
                Contenido: vm.Contenido,
                Venta: vm.Venta,
                DecimalProducto: vm.DecimalProducto,
                Nota: vm.Nota,

                ProductoEsquema: vm.cEsquemaList,
                ProductoImpuesto: vm.impList,
                ProductoUnidad: vm.cUnidadesList,
                ProductoEquivalente: vm.productoEquivalente,

                //  ProductoDetalle: vm.productoFormado,
                CantidadProduccion: vm.CantidadProduccion,
                UnidadProduccion: vm.PRUTipoUnidad,

                MFechaHora: vm.MFechaHora,
                MUsuarioID: window.sessionStorage.getItem('USUId')

            };
            //console.log("Producto: " + JSON.stringify(producto));
            //console.log("Esquema: " + vm.cEsquemaList);
            //console.log("Impuesto: " + vm.impList);
            //console.log("Unidad: " + vm.cUnidadesList);
            //console.log("Producto: " + vm.productoEquivalente);

            $http({
                url: url + '/api/Producto/GuardarProducto?producto=' + producto,
                method: 'post',
                data: JSON.stringify(producto),
                dataType: "json",
                headers: {
                    Authorization: window.sessionStorage.getItem('Token'),
                    'Content-type': 'application/json'
                }
            }).success(function (data) {
                window.location.href = '../Producto/Index?Permiso=' + $scope.Permiso;
            }).error(function (error) {
                console.log(error);
            });
        }
    }

    //BotonCancelar
    vm.ValidarCancelar = function () {
        if (!$scope.form.$pristine) {
            $scope.Action = "Cancel";
            messageBox.MostrarSiNo($scope.translation.XCancelar, $scope.translation.BP0002);
        }
        else {
            window.location.href = '../Producto/Index?Permiso=' + $scope.Permiso;
            console.log($scope.Permiso);
        }
    }

    vm.AceptarYesNoMsgBox = function () {
        messageBox.Cerrar();
        if (vm.Action == "Cancel") {
            window.location.href = '../Producto/Index?Permiso=' + $scope.Permiso;
        }
    }

    //Remover esquema
    //$scope.Remove = function (index, Clave) {
    //    $scope.Delete.splice(0, 0, Clave);
    //    $scope.EsquemasList.splice(index, 1);
    //    if ($scope.EsquemasList[$scope.EsquemasList.length - 1].Nombre == "") {
    //        $scope.EsquemasList.splice($scope.EsquemasList.length - 1, 1);
    //    }
    //    //$scope.ROrden();
    //};

    vm.ValidarEliminarImpuesto = function (index, clave) {
        angular.forEach(vm.impList, function (value, key) {
            if (value.ImpuestoClave == clave) {
                vm.impList.splice(key, 1);
                $("input[id='" + clave + "']").attr('checked', false);
            }
        });
    }


    /***UNIDADES DE VENTA**/

    //Agregar unidad de venta
    vm.addUnidadVenta = function () {

        if (vm.ProductoClavePRO !== undefined) {
            if (vm.ProductoClavePRO != "") {
                if (vm.cUnidadesList.length < vm.unidadv.length)
                    vm.cUnidadesList.push(
                        {
                            PRUTipoUnidad: '',
                            CodigoBarras: '',
                            TipoEstado: '',
                            KgLts: 0,
                            Volumen: 0,
                            PorcentajeVariacion: 0,
                            DecimalProducto: 0,
                            ValorPuntos: 0,
                            ProductoDetalle: [
                            vm.ProductoDetalle.push()
                            ]
                        });
            } else {
                vm.mostrarError = true;
            }
        } else {
            vm.mostrarError = true;
        }
    }

    //
    vm.addProductoRelacionado = function (index) {
        var tipo = $('select[id="PRUTipoUnidad' + index + '"]').val();
        if (tipo == "") {
            vm.tipoVacio = true;
        } else {
            vm.tipoVacio = false;
            var PRUTipo = tipo.substring(7, tipo.length)
            $scope.PRUTipoAux = PRUTipo;
            $scope.PRUTipoIndexAux = index;
            $('.impInput').attr('checked', false);
            defaultBox.Mostrar('Productos equivalentes', '', 'ProdRelBox');
        }
    }

    vm.agregarNuevoTipo = function (index, tipo) {
        angular.forEach(vm.unidadv, function (it) {
            if (it.VAVClave == tipo) {
                vm.TiposSeleccionado.push({ "Index": index, "VAVClave": it.VAVClave, "Descripcion": it.Descripcion, "Grupo": it.Grupo });
            }
        });
        //Se elimina el producto y se añade nuevamente
        vm.ProductoDetalle.splice(0, 1);
        vm.ProductoDetalle.push({ Index: index, NombreProducto: "", ProductoClave: vm.ProductoClavePRO, PRUTipoUnidad: '', ProductoDetClave: '', Prestamo: 1, Factor: 1 });
    }
    //Productos que lo forman
    vm.agregarProductoForma = function () {
        vm.ProductoDetalle.push({ Index: "", NombreProducto: "", ProductoClave: 'hnfghnfgh', PRUTipoUnidad: '', ProductoDetClave: '', Prestamo: '', Factor: 1 });
    }
    
    //Agregar Productos Equivalentes
    /**
    vm.agregarProductoCompetencia = function () {
        $(".camposInput").attr('checked', false);
        defaultBox.Mostrar('Productos equivalentes de la competencia', '', 'ProdCompBox');
    }
    //Agregar producto de la competencia
    vm.addProductoCompetencia = function (clave, nombre, estado, activo) {
        var existe = false;
        if (vm.productoCompetencia <= 0) {
            vm.productoCompetencia.push({ ProductoClave: clave, Nombre: nombre, Tipo: estado });
        } else {
            angular.forEach(vm.productoCompetencia, function (value, key) {
                if (value.ProductoClave == clave) {
                    existe = true;
                }
            });
            if (!existe) {
                vm.productoCompetencia.push({ ProductoClave: clave, Nombre: nombre, Tipo: estado });
            }
        }
    }

    //Eliminar producto competencia
    vm.EliminarProductoCompetencia = function (index, productoClave) {
        angular.forEach(vm.productoCompetencia, function (value, key) {
            if (value.ProductoClave == productoClave) {
                vm.productoCompetencia.splice(key, 1);
                //   $("input[id='" + clave + "']").attr('checked', false);
            }
        });
    }*/
    //Validar el cambio de un caracter en el limite descuento

    //vi.onlyNumberKey(event) = function () {
    //    return (event.charCode == 8 || event.charCode == 0) ? null : event.charCode >= 48 && event.charCode <= 57;
    //}

    vm.prueba = function () {
        console.log("VM");
    }



    vm.ObtenerDetalleProductoEquivalente = function (ProductoClave) {
        if (ProductoClave != "") {
            //Es un Edit
            $http({
                url: url + '/api/Producto/ObtenerDetalleProductoEquivalente?ProductoClave=' + ProductoClave,
                method: 'GET',
                headers: {
                    Authorization: window.sessionStorage.getItem('Token'),
                    'Content-type': 'application/json'
                }
            }).success(function (data) {
                vm.productoEquivalente = data;
                angular.forEach(data, function (proEquiv) {
                    vm.TipoEstadoEquiv = proEquiv.Estado;
                })
            }).error(function (error) {
                console.log(error);
            });
            //Manda llamar el detalle de los impuestos mediante su clave del producto
        }
    }
    vm.ObtenerDetalleImpuestoProducto = function (ProductoClave) {
        if (ProductoClave != "") {
            //Es un Edit
            $http({
                url: url + '/api/Producto/ObtenerDetalleImpuestoProducto?ProductoClave=' + ProductoClave,
                method: 'GET',
                headers: {
                    Authorization: window.sessionStorage.getItem('Token'),
                    'Content-type': 'application/json'
                }
            }).success(function (data, status) {
                var imp = [];
                imp = data;

                for (var i = 0; i < imp.length; i++) {
                    vm.impList.push({
                        "eliminar": false,
                        "ImpuestoClave": imp[i].ImpuestoClave,
                        "Abreviatura": imp[i].Abreviatura,
                        "Nombre": imp[i].Nombre,
                        "TipoEstado": imp[i].TipoEstado
                    })
                }

                //console.log("Impuesto: " + JSON.stringify(data));

            }).error(function (error, status) {

            });
        }
    }

    vm.ObtenerDetalleProductoUnidad = function (ProductoClave) {
        if (ProductoClave != "") {
            //Es un Edit
            $http({
                url: url + '/api/Producto/ObtenerDetalleProductoUnidad?ProductoClave=' + ProductoClave,
                method: 'GET',
                headers: {
                    Authorization: window.sessionStorage.getItem('Token'),
                    'Content-type': 'application/json'
                }
            }).success(function (data) {
                vm.cUnidadesList = data;
                //console.log("JSON: " + JSON.stringify(data));

                if (vm.Tipo == '2' || vm.Tipo == '3') {
                    canje = true;
                    //console.log("Es canjeable");
                }

                angular.forEach($scope.unidadv, function (value, key) {
                    //console.log("Dentro del primer foreach");
                    angular.forEach(data, function (v, k) {
                        (value.VAVClave == v.PRUTipoUnidad) ? vm.TiposSeleccionado.push({ "Index": k, "VAVClave": value.VAVClave, "Descripcion": value.Descripcion, "Grupo": value.Grupo }) : "";
                    });
                });
            }).error(function (error) {
                console.log(error);
            });
        }
    }

    //**Define las páginas que se utilizaran al mostrar los registros de Productos**//
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

}])
.directive("validarVacio", function ($http, $q, $timeout) {
    return {
        restrict: 'A',
        require: 'ngModel',
        link: function ($scope, element, attr, ngModel) {
            var validar = attr.validarVacio;
            var index = attr.index;
            if (validar == "true") {
                element.ready(function () {
                    ngModel.$asyncValidators.validaVacio = function (modelValue, viewValue) {
                        var deferred = $q.defer(), tipo = modelValue, valido = true;
                        // if ($scope.Action == 'Create') { //Descomentar hasta llegar edit
                        angular.forEach($scope.cUnidadesList, function (it) {
                            if (it.PRUTipoUnidad == tipo) {
                                valido = false;
                            }
                        });
                        if (valido) {
                            var inicio = false, existe = false, indexTipo = 0;
                            /** Validar sí tipo seleccionado se encuentra vacio
                            **  Si el array "TiposSeleccionado" ya contiene un valor con el index especificado
                            **  Revisar sí ya existe el elemento, sí existe no se hace nada, sí no existe el elemento se elimina el anterior y se inserta el nuevo **/

                            if ($scope.TiposSeleccionado.length > 0) {
                                //El array ya contine minimo un elemento
                                var ar = 0;
                                angular.forEach($scope.TiposSeleccionado, function (t, k) {
                                    //Sí el index del elemento ya existe se elimina y se inserta el nuevo
                                    if (t.Index == index) {
                                        existe = true;
                                        indexTipo = k;
                                    }
                                });
                                if (existe) {
                                    $scope.TiposSeleccionado.splice(indexTipo, 1);
                                    $scope.agregarNuevoTipo(index, tipo);
                                } else {
                                    $scope.agregarNuevoTipo(index, tipo);
                                }
                            } else {
                                //El array no contien ningun elemento en su lista
                                $scope.agregarNuevoTipo(index, tipo);
                            }
                            deferred.resolve();
                            $scope.creado = true;
                        } else {
                            deferred.reject();
                            $scope.creado = false;
                        }
                        //} else {

                        //metodo al editar
                        //   console.log("VECES REPETIDO LO MISMO");

                        //    deferred.resolve();
                        //  }
                        // return the promise of the asynchronous validator
                        return deferred.promise;
                    }
                });

            }
        }
    }
})
.directive("validarClaveProducto", function ($http, $q, $timeout) {
    return {
        restrict: 'A',
        require: 'ngModel',
        link: function ($scope, element, attr, ngModel) {
            var validar = attr.validarClaveProducto;
            var url = window.sessionStorage.getItem('URL');
            //console.log("Validando...");
            if (validar == "true") {
                ngModel.$asyncValidators.productoClaveRepetida = function (modelValue, viewValue) {
                    var deferred = $q.defer(), clave = modelValue, valido = true;
                    if ($scope.Action == 'Create') { //Descomentar hasta llegar edit
                        $http({
                            url: url + '/api/Producto/ValidarClaveProducto?ProductoClave=' + clave,
                            method: 'GET',
                            headers: {
                                Authorization: window.sessionStorage.getItem('Token'),
                                'Content-type': 'application/json'
                            }
                        }).success(function (data, status) {
                            if (data == true) {
                                deferred.reject();
                            } else {
                                deferred.resolve();
                            }
                        }).error(function (error, status) {
                            console.log("Error: " + JSON.stringify(error));
                        });

                    } else {
                        deferred.resolve();
                    }

                    // return the promise of the asynchronous validator
                    return deferred.promise;
                }
            } else {

            }
        }
    }
})
    /*ESTA DIRECTIVA SE UTILIZA PARA CAMBIAR EL TipoUnidad dentro de los productos relacionados**/
.directive("cambiarTipoUnidad", function ($http, $q, $timeout) {
    return {
        restrict: 'A',
        require: 'ngModel',
        link: function ($scope, element, attr, ngModel) {
            //Se obtiene el valor del atributo que respresenta la directiva
            var validar = attr.cambiarTipoUnidad;
            //Se obtiene el index del elemento, con el cual se calculará cuales son los elementos que se cambiarán
            var indexTipo = attr.index;
            //Se espera que cargue la página para evitar resultados no deseados, como la duplicación del método
            element.ready(function () {
                //Se accede al evento 'change' para esperar que se efectue un cambio para realizar los cambios
                element.bind("change", function () {
                    //Se recorre todo la lista de unidades creadas para acceder a la que se desea
                    angular.forEach($scope.cUnidadesList, function (value, key) {
                        //Se recorren todos los productos formados para encontrar los que se desean
                        angular.forEach(value.ProductoDetalle, function (v, k) {
                            //Al recorrerlo se compara el index al cual pertenece este elemento y se compara con lo que encuentre en la lista
                            if (v.Index == indexTipo) {
                                //Una vez que haya coincidencia se modifica los valores con el nuevo tipo que se ha elegido
                                $scope.$apply(function () {
                                    v.PRUTipoUnidad = ngModel.$modelValue;
                                });

                            }
                        });
                    }, this);
                });
            });
        }
    }
})
.directive("validarFactor", function ($http, $q, $timeout) {
    return {
        restrict: 'A',
        require: 'ngModel',
        link: function ($scope, element, attr, ngModel) {
            var TipoUnidad = attr.validarFactor;
            var ProductoClave = attr.productoClave;
            element.ready(function () {
                ngModel.$asyncValidators.factorRepetido = function (modelValue, viewValue) {
                    var deferred = $q.defer();

                    var existe = false;
                    angular.forEach($scope.cUnidadesList, function (value, key) {
                        existe = false;
                        if ($scope.cUnidadesList.length > 1 && value.PRUTipoUnidad != TipoUnidad) {
                            angular.forEach(value.ProductoDetalle, function (v, k) {
                                if (ProductoClave == v.ProductoDetClave) {
                                    if (v.Factor == modelValue) {
                                        console.log("Ya existe ese factor en otra unidad");
                                        existe = true;
                                    }
                                }
                            });
                        }

                    }, this);
                    if (existe == true) {
                        deferred.reject();
                    } else {
                        deferred.resolve();
                    }
                    // return the promise of the asynchronous validator
                    return deferred.promise;
                }
            });

        }
    }
})

//Validacion de numeros
.directive('validaNumeroEntero', function () {
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

                var clean = val.replace(/[^0-9]/g, '');
                var negativeCheck = clean.split('-');
                var decimalCheck = clean.split('.');
             

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
})

//Validacion de numeros y decimales 
.directive('validaNumber', function () {
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
})

    //Validacion de numeros con centenares
.directive('validaNumberCent', function () {
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

                var clean = val.replace(/[^0-9\.]/g, '');
                var negativeCheck = clean.split('-');
                var decimalCheck = clean.split('.');
          

                if (!angular.isUndefined(decimalCheck[1])) {
                    decimalCheck[1] = decimalCheck[1].slice(0, 3);
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
})
//Solo Numeros
//Validacion de numeros y decimales 
.directive('validaNumberInt1', function () {
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
})

.directive('updateEstadoImp', function () {
    return function (scope, element) {
        element.bind('change', function () {
            //alert('change on ' + element[0].value);
        });
    };
})



//  VALIDAR CAMBIO TIPOFASE DEL PRODUCTO
app.directive('estadoProduct', estadoProduct);
function estadoProduct($http, $q, $timeout) {
    return {
        restrict: 'A',
        require: 'ngModel',
        link: function ($scope, element, attr, ngModel) {

            var validar = attr.estadoProduct;
            var estadoInicial = $scope.TipoFase;
            //console.log("Estado: " + validar + " Estado Inicial: " + estadoInicial);

            if (validar == "true") {
                ngModel.$asyncValidators.cambioProducto = function (modelValue, viewValue) {
                    var deferred = $q.defer();

                    if ($scope.Action == 'Edit') { //Descomentar hasta llegar edit
                        //   if (true) {producto
                        var clave = $scope.ProductoClavePRO;

                        var claveProducto = attr.producto;

                        var url = window.sessionStorage.getItem('URL');
                        var es = angular.element(ddlTipoFase)[0].value.substring(7);
                        //console.log("Estado: " + estadoInicial + " sel: " + es)
                        if (estadoInicial != angular.element(ddlTipoFase)[0].value.substring(7)) {

                            $http({
                                url: url + '/api/Producto/ValidarEstadoProducto?ProductoClave=' + clave,
                                method: 'GET',
                                header: {
                                    Autorization: window.sessionStorage.getItem('Token'),
                                    'Content-Type': 'application/json'
                                },
                            }).success(function (data, status) {
                                if (data == false) {

                                    deferred.resolve();
                                }
                                else {
                                    deferred.reject();
                                    var camp = "";
                                    angular.forEach(data, function (v, k) {//aqui estan los que se estan agregando a la lista
                                        camp += " " + v;
                                        //camp += v.split(" ");
                                    });
                                    $scope.mensaje = camp;
                                }
                            }).error(function (error, status) {
                                deferred.resolve();
                            });
                        }
                    }
                    else {
                        deferred.resolve();
                    }
                    // return the promise of the asynchronous validator
                    return deferred.promise;
                }
            } else {

            }
        }
    }
}

app.directive('arrowSelectorUniventa', ['$document', function ($document) {
    return {
        restrict: 'A',
        link: function (scope, elem, attrs, ctrl) {
            var elemFocus = false;
            // CUANDO EL MOUSE ESTA DENTRO DEL ELEMENTO ENFOCADO
            elem.on('mouseenter', function () {
                elemFocus = true;
                //console.log(elemFocus);
            });
            // CUANDO EL MOUSE ESTA FUERA DEL ELEMENTO ENFOCADO
            elem.on('mouseleave', function () {
                elemFocus = false;
                //console.log(elemFocus);
            });
            $document.bind('keydown', function (e) {
                if (elemFocus) {
                    //  JAVASCRIPT KEY CODE (UP ARROW)
                    if (e.keyCode == 38) {
                        //console.log(scope.selectedRow);
                        if (scope.selectedRow == 0) {
                            return;
                        }
                        scope.selectedRow--;
                        scope.$apply();
                        e.preventDefault();
                    }
                    //  JAVASCRIPT KEY CODE (DOWN ARROW)
                    if (e.keyCode == 40) {
                        if (scope.selectedRow == scope.cUnidadesList.length - 1) {
                            return;
                        }
                        scope.selectedRow++;
                        scope.$apply();
                        e.preventDefault();
                    }
                    //console.log("FILTRO POR TECLADO");
                }
            });
        }
    }
}]);


//.directive('isNumber', ['$compile', function ($compile) {
//    return {
//        restrict: 'E',
//        scope: {
//            myNgModel: '='
//        },
//        compile: function (element, attrs) {

//            var e = angular.element('<input type="Number" ng-model="' + attrs.myNgModel + '" size="20" />');
//            element.append(e);

//            return function (scope, element, attrs) {
//                $compile(e)(scope);

//                var maxLength = 6;
//                // var hasDecimal = false;
//                var enableNegative = false;

//                if (attrs.enableNegative) {
//                    enableNegative = (attrs.enableNegative === 'true');
//                }

//                if (attrs.max) {
//                    maxLength = attrs.max;
//                }

//                if (attrs.value) {
//                    if (maxLength < attrs.value.length) {
//                        attrs.value = attrs.value.substring(0, maxLength);
//                    }
//                    scope.myNgModel = attrs.value;
//                }


//                scope.$watch('myNgModel', function (newValue, oldValue) {
//                    if (newValue !== undefined) {

//                        var arr = String(newValue).split('');

//                        if (arr.length === 0) {
//                            return;
//                        }

//                        if (enableNegative && arr.length === 1 && arr[0] === '-') {
//                            return;
//                        }

//                        if (isNaN(newValue) || (arr.length > maxLength) || (arr.indexOf('.') !== -1)) {
//                            scope.myNgModel = oldValue;
//                        }
//                    }
//                });
//            };

//        }
//    };
//}])