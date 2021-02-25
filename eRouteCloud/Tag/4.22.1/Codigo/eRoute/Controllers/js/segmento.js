angular.module('segmento', ['valorReferencia', 'messageBox', 'ngResource', 'translation', 'defaultBox', 'angularTreeview', 'treeGrid', 'messageBoxAux'])

.controller('segmentosController', ["$scope", "$rootScope", "$http", "$window", 'valorReferencia', "messageBox", "translationService", "defaultBox", "messageBoxAux", function ($scope, $rootScope, $http, $window, valorReferencia, messageBox, translationService, defaultBox, messageBoxAux) {
    var url = window.sessionStorage.getItem('URL');
    translationService.getTranslation($scope);
    ObtenerValoresProducto();
    obtenerProductosPrioritarios();


    var vm = $scope;
    vm.PorCambios = false;
   
    /*INICIALIZACIÓN DE VARIABLES*/
    vm.cProductoPriorList = [];
    $scope.tree_data = [];
    vm.esquemaDisponible = true;
    vm.dirDel = "Prueba DIR DEL";
    $scope.expanding_property = "EsquemaID";
    vm.NombreEstatusEsquema = "";
    $scope.col_defs = [
    	{ field: "Abreviatura" },
    	{ field: "Orden" },
    	{ field: "EsquemaIDPadre" },
    	{ field: "TipoEstado", displayName: "Tipo" }
    ];

    esquemas();
    //////////////////////
    function ObtenerValoresProducto() {
        valorReferencia.obtenerValores('EDOREG', function (result) {
            $scope.edoreg = result;

        });
        valorReferencia.obtenerValores('TESQUEMA', function (result) {
            $scope.tesquema = result;
        });
        valorReferencia.obtenerValores('CESQUEMA', function (result) {
            $scope.cesquema = result;
        });
        

    }

    //Verifica sí el paramtro PorCambios está activo
    vm.verificarPorcentajeCambios = function () {
        $http({
            url: url + '/api/Segmento/verificarPorcentajeCambios',
            method: 'GET',
            header: {
                Autorization: window.sessionStorage.getItem('Token'),
                'Content-Type': 'application/json'
            }
        }).success(function (data, status) {
            if (data == true) {
                //El parametro "PorCambios" está activo
                console.log("TRUE");
                vm.PorCambios = true;
            } else {
                console.log("FALSE");
                vm.PorCambios = false;
            }
        }).error(function (error, status) {

        });
    }

    vm.AsignarPermisoSegmentos = function (Permiso, Action) {
        $scope.ActionUrl = Action;
        $scope.Permiso = Permiso;
    }
    $scope.sort = function (keyname) {
        $scope.sortKey = keyname;
        $scope.reverse = !$scope.reverse;
    }

    vm.GuardarEsquema = function () {
        if (!$scope.form.$valid) {
            $scope.form.submitted = true;
        } else {

            var esquema = {
                EsquemaID: $scope.EsquemaID,
                Clave: $scope.Clave,
                EsquemaIDPadre: $scope.EsquemaIDPadre,
                Nombre: $scope.Nombre,
                Abreviatura: $scope.Abreviatura,
                Orden: $scope.Orden,
                Tipo: $scope.Tipo,
                TipoEstado: $scope.TipoEstado,
                Baja: $scope.Baja,
                ProductoPrioritarioEsq: vm.cProductoPriorList,
                Clasificacion: $scope.Clasificacion,
                PorCambiosCaduco: $scope.PorCambiosCaduco,
                MUsuarioID: window.sessionStorage.getItem('USUId')
            };
            console.log("Producto: " + JSON.stringify(esquema));

            $http({
                url: url + '/api/Segmento/GuardarEsquema?esquema=' + esquema,
                method: 'post',
                data: JSON.stringify(esquema),
                dataType: "json",
                headers: {
                    Authorization: window.sessionStorage.getItem('Token'),
                    'Content-type': 'application/json'
                }
            }).success(function (data) {
                window.location.href = '../Segmento/Index?Permiso=' + $scope.Permiso;
            }).error(function (error) {
                console.log(error);
            });
        }
    }
    vm.EditarEsquema = function (sEsquemaId, sPermiso, sSoloLectura,Action) {
        $scope.Permiso = sPermiso;
        $scope.ActionUrl = Action;
        if (sSoloLectura.toUpperCase() == "TRUE") {
            $scope.SoloLectura = true;
        }
        else {
            $scope.SoloLectura = false;
        }
        if (sEsquemaId != "") {
            $http({
                url: url + '/api/Segmento/verificarEsquema?esquemaId=' + sEsquemaId,
                method: 'GET',
                header: {
                    Autorization: window.sessionStorage.getItem('Token'),
                    'Content-Type': 'application/json'
                }
            }).success(function (data, status) {
                angular.forEach(data, function (pro) {
                    $scope.EsquemaID = pro.EsquemaID;
                    $scope.Clave = pro.Clave;
                    $scope.EsquemaIDPadre = pro.EsquemaIDPadre;
                    $scope.Nombre = pro.Nombre;
                    vm.EsquemaIDPadreNombre =pro.Nombre,

                    $scope.Abreviatura = pro.Abreviatura;
                    $scope.Orden = pro.Orden;
                    $scope.Tipo = pro.Tipo;
                    $scope.TipoEstado = pro.TipoEstado;
                    $scope.Baja = pro.Baja;
                    $scope.Clasificacion = pro.Clasificacion;

                });

                $scope.Action = "Edit";

                $scope.Nuevo = false;
            }).error(function (error, status) {

            });
        } else {

            $scope.Action = "Create";
            $scope.validacion = false;
        }
    }

    vm.agregarSegmento = function () {
        if (vm.EsquemaIDPadre !== undefined) {

            if (vm.EsquemaIDPadre == "" || vm.EsquemaIDPadreNombre == "") {
                vm.EsquemaIDPadreNombre = "";
                vm.AbreviaturaPadre = "";
            }

        } else {
            vm.EsquemaIDPadreNombre = "";
            vm.AbreviaturaPadre = "";
        }
        vm.esquemaDisponible = true;
        defaultBox.Mostrar('titulo', 'otro', 'SegmentoPadre');
    }

    vm.agregarProductoPrioritario = function () {
        $(".impInput").attr('checked', false);
        defaultBox.Mostrar('', '', 'ProdPrioritario');
    }

    $scope.ValidarCancelar = function () {
        if (!$scope.form.$pristine && !$scope.SoloLectura) {
            $scope.Action = "Cancel";
            vm.lblMsgTitulo = $scope.translation.XCancelar;
            vm.lblMsgMensaje = $scope.translation.BP0002;
            messageBoxAux.MostrarSiNo();
        }
        else {
            window.location.href = '../Segmento/Index?Permiso=' + $scope.Permiso;
        }
    }
    $scope.ValidarEliminarProductos = function (ProductoClave) {
        $scope.Action = "EliminarProducto";
        vm.ProductoClave = ProductoClave;
        vm.lblMsgTitulo = $scope.translation.XEliminar;
        vm.lblMsgMensaje = $scope.translation.P0001;
        messageBoxAux.MostrarSiNo();
    }

   vm.AceptarYesNoMsgBox = function () {
        messageBoxAux.Cerrar();

        if ($scope.Action == "EliminarProducto") {
            angular.forEach(vm.cProductoPriorList, function (value, key) {
                if (value.ProductoClave == vm.ProductoClave) {
                    vm.cProductoPriorList.splice(key, 1);
                }
            });
        } else if ($scope.Action == "EliminarEsquema") {
            $http({
                url: url + '/api/Segmento/verificarEliminarEsquema?esquemaId=' + vm.EsquemaIdSeg,
                method: 'GET',
                headers: {
                    Authorization: window.sessionStorage.getItem('Token'),
                    'Content-type': 'application/json'
                }
            }).success(function (data, status) {
                angular.forEach(data, function (v, k) {
                    console.log("v.Disponible: " + v.Disponible);
                    if (v.Disponible == true) {
                        $scope.Action = "";
                        window.location.href = '../Segmento/Index?Permiso=' + $scope.Permiso;
                    } else {
                        $scope.Action = "";
                        vm.lblMsgMensaje = 'No se pudo eliminar el esquema "' + vm.EsquemaIdSeg + '" porque se encuentra asignado a "' + v.Nombre + '"';
                        messageBoxAux.Mostrar();
                    }
                });


            }).error(function (error, status) {
                console.log("Error: " + JSON.stringify(error));
            });

        }
        else if ($scope.Action == "Cancel") {
            window.location.href = '../Segmento/Index?Permiso=' + $scope.Permiso;
        }
    }
    vm.EliminarProductoPrioritario = function (ProductoClave) {
        angular.forEach(vm.cProductoPriorList, function (value, key) {
            if (value.ProductoClave == ProductoClave) {
                vm.cProductoPriorList.splice(key, 1);
            }
        });
    }
    vm.addProdPrior = function (ProductoClave, Nombre) {
        var existe = false;
        if (vm.cProductoPriorList <= 0) {
            vm.cProductoPriorList.push({ ProductoClave: ProductoClave, Nombre: Nombre });
        } else {
            angular.forEach(vm.cProductoPriorList, function (value, key) {
                if (value.ProductoClave == ProductoClave) {
                    existe = true;
                }
            });
            if (!existe) {
                vm.cProductoPriorList.push({ ProductoClave: ProductoClave, Nombre: Nombre });
            }
        }
    }

    vm.prueba = function () {
        vm.EsquemaIDPadre = esquemaID;
        vm.EsquemaIDPadreNombre = nombre;
        vm.AbreviaturaPadre = abrev;
        vm.Tipo = (tipo !== undefined ? "" : tipo.toString());
    }

    $scope.dbl_click = function (ProductoClave) {
        $window.location.href = '../Segmento/Edit?ProductoClave=' + ProductoClave + '&Permiso=' + $scope.Permiso;
    }
    vm.verificarEsquemasExistentes = function (esquemaID, nombre, tipo, abrev) {
        if (vm.Action == "Create") {
            vm.EsquemaIDPadre = esquemaID;
            vm.EsquemaIDPadreNombre = nombre;
            vm.AbreviaturaPadre = abrev;
            vm.Tipo = (tipo !== undefined ? "" : tipo.toString());
        } else {
            //Sí se modifica se hacen validaciones
  

            if (vm.EsquemaIDPadre !== undefined) {
                if (vm.EsquemaIDPadre != "") {
                    console.log("Pantalla Editar");
                    $http({
                        url: url + '/api/Segmento/esquemasUtilizados?esquemaId=' + vm.EsquemaID,
                        method: 'GET',
                        headers: {
                            Authorization: window.sessionStorage.getItem('Token'),
                            'Content-type': 'application/json'
                        }
                    }).success(function (data, status) {
                        angular.forEach(data, function (v, k) {
                            debugger;
                            (v.Disponible == true) ? vm.esquemaDisponible = true : vm.esquemaDisponible = false;
                            if (v.Disponible == true) {
                                vm.EsquemaIDPadre = esquemaID;
                                vm.EsquemaIDPadreNombre = nombre;
                                vm.AbreviaturaPadre = abrev;
                                vm.Tipo = (tipo !== undefined ? "" : tipo.toString());
                            }
                             vm.NombreEstatusEsquema = v.Nombre;
                        });
                    }).error(function (error, status) {
                        console.log("Error: " + JSON.stringify(error));
                    });
                }
            }

        }

    }

    
    function esquemas() {
        $http({
            url: url + '/api/Segmento/ObtenerEsquemas',
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

    }
    function obtenerProductosPrioritarios() {
        $http({
            url: url + '/api/Segmento/obtenerProductosPrioritarios',
            metohod: 'GET',
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-Type': 'application/json'
            }
        }).success(function (data, status) {
            $scope.productoPrioritarioList = data;
        }).error(function (error, status) {
            $scope.error = { message: error, status: status };
            console.log($scope.error);
        });
    }
    vm.obtenerProductosDetalle = function(EsquemaID) {
  
        $http({
            url: url + '/api/Segmento/obtenerProductosDetalle?EsquemaID= ' + EsquemaID,
            metohod: 'GET',
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-Type': 'application/json'
            }
        }).success(function (data, status) {
            console.log(JSON.stringify(data));
            $scope.cProductoPriorList = data;
        }).error(function (error, status) {
            $scope.error = { message: error, status: status };
            console.log($scope.error);
        });
    }

    $scope.validarEliminarEsquema = function (EsquemaId) {
        $scope.Action = "EliminarEsquema";
        vm.EsquemaIdSeg = EsquemaId;
        vm.lblMsgTitulo = $scope.translation.XEliminar;
        vm.lblMsgMensaje = $scope.translation.P0001;
        messageBoxAux.MostrarSiNo();
    }

}])


.directive("verificarEsquema", function ($http,$q,$timeout) {
    return {
        restrict: 'A',
        require: 'ngModel',
        link: function ($scope, element, attr, ngModel) {
            var url = window.sessionStorage.getItem('URL');
            element.ready(function () {
                ngModel.$asyncValidators.esquemaExistente = function (modelValue, viewValue) {
                    var deferred = $q.defer();

                    var existe = false;
    
                    if (viewValue == "" || modelValue == "") {
                        $scope.Tipo = "";
                        $scope.EsquemaIDPadreNombre = "";
                        deferred.resolve();
                    } else {
                        $http({
                            url: url + '/api/Segmento/verificarEsquema?esquemaId=' + viewValue,
                            method: 'GET',
                            headers: {
                                Authorization: window.sessionStorage.getItem('Token'),
                                'Content-type': 'application/json'
                            }
                        }).success(function (data, status) {
                            if (data.length > 0) {

                                angular.forEach(data, function (value,key) {
                                    $scope.EsquemaIDPadreNombre = value.Nombre;
                                    $scope.Tipo = value.Tipo.toString();
                                });
                                deferred.resolve();
                            } else {
                                $scope.Tipo = "";
                                $scope.EsquemaIDPadreNombre = "";
                                deferred.reject();
                            }
                        }).error(function (error, status) {
                            console.log("Error: " + JSON.stringify(error));
                        });
                    }

                    // return the promise of the asynchronous validator
                    return deferred.promise;
                }
            });
        }

    }
})


