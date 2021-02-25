angular.module('cargas', ['valorReferencia', 'messageBox', 'ngResource', 'translation', 'defaultBox'])

.controller('cargasController', ["$scope", "$rootScope", "$http", 'valorReferencia', "messageBox", "translationService", "defaultBox", function ($scope, $rootScope, $http, valorReferencia, messageBox, translationService, defaultBox) {
    var url = window.sessionStorage.getItem('URL');
    translationService.getTranslation($scope);
    ObtenerValoresProducto();
    ObtenerCargas();
    ObtenerCONHIST();
    ObtenerAlmacenes();
    ObtenerModulo();
    
    //ObtenerImpuestos();
    //ObtenerEmpresas();
   
    //obtenerProductosRelacionados();

    
    /*INICIALIZACIÓN DE VARIABLES*/
    var vm = $scope;

    $scope.DiaTrabajo = new Date();
    //this.minDate = new Date("10/09/2017");

    vm.vendedorBloq = true;
    vm.botonVendedorBloq = true;
    vm.moduloList = [];
    //vm.moduloID = "Cargas";
    vm.datosCargaBloq = true;
    vm.preventaInicioBloq = false;
    vm.preventaFinBloq = false;
    vm.semanasCargaBloq = true;
    vm.allRutasBloq = true;


    //vm.tipoVacio = false;

    //////////////////////
    
    function ObtenerValoresProducto() {
        valorReferencia.obtenerValores('TRPFASE', function (result) {
            $scope.trpfase = result;

        });
        valorReferencia.obtenerValores('UNIDADV', function (result) {
            $scope.unidadv = result;
        });
        valorReferencia.obtenerValores('TCARSU', function (result) {
            $scope.tcarsu = result;
        });
    }

    vm.AsignarPermisoCargas = function (Permiso) {
        $scope.Permiso = Permiso;
    }
    $scope.sort = function (keyname) {
        $scope.sortKey = keyname;
        $scope.reverse = !$scope.reverse;
    }

    /** OBTENER LA LISTA COMPLETA DE CARGAS */
    function ObtenerCargas() {
        $http({
            url: url + '/api/Cargas/ObtenerCargas',
            method: 'GET',
            header: {
                Autorization: window.sessionStorage.getItem('Token'),
                'Content-Type': 'application/json'
            }
        }).success(function (data, status) {
            vm.CargasList = data;
            var tam = $scope.CargasList.length;
            $scope.tamPag = tamano(tam);
            console.log(JSON.stringify("tam = " + tam));
        }).error(function (error, status) {
            console.log("Error: " + JSON.stringify(error));
        });
    }

    function ObtenerCONHIST() {
        $http({
            url: url + '/api/Cargas/ObtenerCONHIST?USUId=' + window.sessionStorage.getItem('USUId'),
            method: 'GET',
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-Type': 'application/json'
            },
        }).success(function (data, status) {
            var FolioAut = "";
            angular.forEach(data, function (it) {
                //console.log("Folio Automatico: " + it);
                FolioAut = it;
            });
            console.log("Folio Automatico: " + FolioAut);
            document.getElementById("FolioID").disabled = FolioAut;
            //var nom = JSON.stringify(data);
            //var nom = data[0];
            //console.log("DATA: " + nom);
        }).error(function (error, status) {
            console.log("DATOS: " + error);
        });
    }

    function ObtenerAlmacenes() {
        $http({
            url: url + '/api/Cargas/ObtenerCentroDistribucion',
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

    function ObtenerModulo() {
        $http({
            url: url + '/api/Cargas/ObtenerModulo',
            method: 'GET',
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-Type': 'application/json'
            },
        }).success(function (data, status) {
            $scope.moduloList = data;
            //$scope.moduloID = "Cargas";
            //var nom = JSON.stringify(data[0].Nombre);
            //console.log("Modulo: " + JSON.stringify(data) + " prueba: " + JSON.stringify(data[0]) + " " + nom);
            
            //$scope.ModuloID = "Cargas";
            //element.all.(by.model('ModuloID')).first().click();
            //$scope.ModuloID = $scope.moduloList['Cargas'];
        }).error(function (error, status) {
            console.log("DATOS: " + error);
        });
    }

    vm.ObtenerRutas = function () {
        var selectCargas = vm.TipoCarga;
        if (selectCargas != "1") {
            vm.datosCargaBloq = false;
            if (selectCargas == "3") {
                vm.preventaInicioBloq = false;
                vm.preventaFinBloq = false;
                vm.semanasCargaBloq = true;
                ObtenerRutasPreventa();
                vm.allRutasBloq = false;
            }
            else {
                vm.allRutas = false;
                vm.allRutasBloq = true;
                vm.rutaPreventaList = [];
            }
            if (selectCargas == "4") {
                vm.preventaInicioBloq = false;
                vm.preventaFinBloq = true;
                vm.semanasCargaBloq = true;
            }
            if (selectCargas == "5") {
                vm.preventaInicioBloq = true;
                vm.preventaFinBloq = true;
                vm.semanasCargaBloq = false;
            }
            if (selectCargas == "6" | selectCargas == "8") {
                vm.preventaInicioBloq = true;
                vm.preventaFinBloq = true;
                vm.semanasCargaBloq = true;
            }
        }
        else {
            vm.datosCargaBloq = true;
            vm.allRutas = false;
            vm.allRutasBloq = true;
            vm.rutaPreventaList = [];
        }
        //if (selectCargas == "3") {
        //    ObtenerRutasPreventa();
        //    vm.allRutasBloq = false;
        //}
        //else {
        //    vm.rutaPreventaList = [];
        //    vm.allRutasBloq = true;
        //    vm.allRutas = false;
        //}

    }

    function ObtenerRutasPreventa() {
        $http({
            url: url + '/api/Cargas/ObtenerRutasPreventa',
            method: 'GET',
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-Type': 'application/json'
            },
        }).success(function (data, status) {
            $scope.rutaPreventaList = data;
            //console.log("Rutas: " + JSON.stringify(data));
            //console.log("Rutas Tam: " + $scope.rutaPreventaList.length);
        }).error(function (error, status) {
            console.log("DATOS: " + error);
        });
    }

    //vm.ObtenerModulo = function () {
    //    $http({
    //        url: url + 'api/Cargas/ObtenerModulo',
    //        method: 'GET',
    //        headers: {
    //            Autorization: window.sessionStorage.getItem('Token'),
    //            'Content-type': 'application/json'
    //        },
    //    }).success(function (data, status) {
    //        vm.moduloList = data;
    //    }).error(function (error, status) {
    //        console.log("MODULOS: " + error);
    //    })
    //}

    vm.LimpiarVendedor = function () {
        $scope.VendedorId = '';
        $scope.VENNombre = '';
        $scope.ObtenerVendedores();
    }

    vm.SeleccionarVendedor = function () {
        defaultBox.Mostrar('', '', 'SeleccionVendedor');
    }

    vm.ObtenerVendedores = function() {
        $http({
            url: url + '/api/Vendedores/ObtenerVendedoresCedi?CEDI=' + $scope.AlmacenID,
            method: 'GET',
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-Type': 'application/json'
            }
        }).success(function (data, status) {
            $scope.vendedores = data;
        }).error(function (error, status) {

        });
    }

    vm.AgregarVendedor = function () {
        for (var i = 0; i < $scope.vendedores.length; i++) {
            if ($scope.vendedores[i].Seleccionado) {
                $scope.VendedorId = $scope.vendedores[i].VendedorId;
                $scope.VENNombre = $scope.vendedores[i].Nombre;
            }
        }
    }

    vm.EditarCargas = function (sFolio, sPermiso, sSoloLectura) {
        $scope.Permiso = sPermiso;

        if (sSoloLectura.toUpperCase() == "TRUE") {
            $scope.SoloLectura = true;
        }
        else {
            $scope.SoloLectura = false;
        }
        if (sFolio != "") {
            //$http({
            //    url: url + '/api/Producto/ObtenerProducto?ProductoClave=' + sFolio,
            //    method: 'GET',
            //    header: {
            //        Autorization: window.sessionStorage.getItem('Token'),
            //        'Content-Type': 'application/json'
            //    }
            //}).success(function (data, status) {
            //    angular.forEach(data, function (pro) {
            //        vm.ProductoClavePRO = pro.ProductoClave;
            //        vm.TipoFase = pro.TipoFase;
            //        vm.Id = pro.Id;
            //        vm.ClaveSAT = pro.ClaveSAT;
            //        vm.Tipo = pro.Tipo;
            //        vm.SubEmpresaID = pro.SubEmpresaID,
            //        vm.Nombre = pro.Nombre;
            //        vm.NombreLargo = pro.NombreLargo;
            //        vm.LimiteDescuento = pro.LimiteDescuento;
            //        vm.CaducoPermitido = pro.CaducoPermitido;
            //        vm.TipoAdquisicion = pro.TipoAdquisicion;
            //        vm.Contenido = pro.Contenido;
            //        vm.Venta = pro.Venta;
            //        vm.DecimalProducto = pro.DecimalProducto;
            //        vm.Nota = pro.Nota;

            //        vm.CantidadProduccion = pro.CantidadProduccion
            //        vm.PRUTipoUnidad = pro.UnidadProduccion

            //    });
            //    console.log("Producto: " + JSON.stringify(data));

            //    $scope.Action = "Edit";
            //    $scope.Nuevo = false;
            //}).error(function (error, status) {

            //});
        } else {
            $scope.Nuevo = true;
            $scope.Action = "Create";
            $scope.TipoFase = "5";
            $scope.TipoCarga = "1";
        }
    }

    //BotonCancelar
    vm.ValidarCancelar = function () {
        if (!$scope.form.$pristine) {
            $scope.Action = "Cancel";
            messageBox.MostrarSiNo($scope.translation.XCancelar, $scope.translation.BP0002);
        }
        else {
            window.location.href = '../Cargas/Index?Permiso=' + $scope.Permiso;
            console.log($scope.Permiso);
        }
    }

    //vm.startToogle = function (scope) {
    //    scope.toggle();
    //}
    //vm.minusPlus = function (scope, esquemaId) {
    //    scope.toggle();
    //    if ($('#esquema' + esquemaId).hasClass('glyphicon-minus')) {
    //        $('#esquema' + esquemaId).removeClass('glyphicon-minus');
    //        $('#esquema' + esquemaId).addClass('glyphicon-plus');
    //    } else {
    //        $('#esquema' + esquemaId).removeClass('glyphicon-plus');
    //        $('#esquema' + esquemaId).addClass('glyphicon-minus');
    //    }

    //}
    
    
   


    //BotonCancelar
    //vm.ValidarCancelar = function () {
    //    if (!$scope.form.$pristine) {
    //        $scope.Action = "Cancel";
    //        messageBox.MostrarSiNo($scope.translation.XCancelar, $scope.translation.BP0002);
    //    }
    //    else {
    //        window.location.href = '../Producto/Index?Permiso=' + $scope.Permiso;
    //        consol.log($scope.Permiso);
    //    }
    //}

    //vm.AceptarYesNoMsgBox = function () {
    //    messageBox.Cerrar();
    //    if (vm.Action == "Cancel") {
    //        window.location.href = '../Producto/Index?Permiso=' + $scope.Permiso;
    //    }
    //}



    /***UNIDADES DE VENTA**/

  
    
    
    vm.prueba = function () {
        console.log("VM");
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