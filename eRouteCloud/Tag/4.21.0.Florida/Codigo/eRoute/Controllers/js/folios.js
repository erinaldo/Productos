var app = angular.module('folios', ['valorReferencia', 'messageBox', 'ngResource', 'translation']);

app.controller('FolioCtrl', ["$scope", "$http", 'valorReferencia', "messageBox", "translationService", function ($scope, $http, valorReferencia, messageBox, translationService) {
    
    var url = window.sessionStorage.getItem('URL');
    translationService.getTranslation($scope);    
    ObtenerFolios();
    ObtenerValoresReferencia();
    $scope.FoliosDetalle = [];
    $scope.banderaFolioUsuario = false;
    var ModuloMovDetalleClave = null;
    var Fiscal =null;
    var SubEmpresaId=null;
    var FolioID = null;
    var Fiscal = null;
    
   
    //obtiene los estados para los folios del index
    function ObtenerValoresReferencia() {
       
        valorReferencia.obtenerValores('EDOREG', function (result) {
            $scope.edoreg = result;
        });
        valorReferencia.obtenerValores('TFOLCONT', function (result) {
            var resultado = [];
            for (var i = 0; i < result.length; i++) {
                resultado.push({
                    'Descripcion':result[i].Descripcion,
                    'Grupo':result[i].Grupo,
                    'VAVClave': result[i].VAVClave,
                    'disponible': false
                });
            }
            $scope.cTipCont = resultado;
        });
    }
   
    $scope.accionSelect = function (contenido,index) {
        switch (contenido.VAVClave) {
            case "4":
                $scope.FoliosDetalle[index].disabledContenido = true;
                $scope.FoliosDetalle[index].Formato = "00000000";
                break;
            case "5":
                $scope.FoliosDetalle[index].disabledContenido = true;
                $scope.FoliosDetalle[index].Formato = "00";
                break;
            case "6":
                $scope.FoliosDetalle[index].disabledContenido = true;
                $scope.FoliosDetalle[index].Formato = "00";
                break;
            case "7":
                $scope.FoliosDetalle[index].disabledContenido = true;
                $scope.FoliosDetalle[index].Formato = "0000";
                break;
            default:
                $scope.FoliosDetalle[index].disabledContenido = false;
                $scope.FoliosDetalle[index].Formato = "";
                break;
        }
        obtenerTiposContenido();
    }

   
    //mostrar la tabla de Folios en el index
    function ObtenerFolios() {
        $http({

            url: url + '/api/Folios/ObtenerFolios?usu=' + window.sessionStorage.getItem('USUId').replace(/\+/g, "%2B"),
            metohod: 'GET',
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-Type': 'application/json'
            }
        }).success(function (data, status) {
            $scope.cFolList = data;
            var tam = $scope.cFolList.length;
            $scope.tamPag = tamano(tam);
        }
            ).error(function (error, status) {
                $scope.error = { message: error, status: status };
                console.log($scope.error);
            });
    }

    function ObtenerFolioDet(FolioID) {
        $http({

            url: url + '/api/Folios/ObtenerFolioDet?folId='+FolioID+'&usu=' + window.sessionStorage.getItem('USUId').replace(/\+/g, "%2B"),
            metohod: 'GET',
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-Type': 'application/json'
            }
        }).success(function (data, status) {
            var fsds = [];
            fsds=data;
            var tipCon;
            var tipEst;
            for(var i=0;i<fsds.length;i++){
                
                for (var j = 0; j < $scope.cTipCont.length; j++) {
                    if ($scope.cTipCont[j].VAVClave == fsds[i].TipoContenido) {
                        tipCon = $scope.cTipCont[j];
                        $scope.cTipCont[j].disponible = true;
                        break;
                    }
                }
                for (var j = 0; j < $scope.edoreg.length; j++) {
                    if ($scope.edoreg[j].VAVClave == fsds[i].TipoEstado) {
                        tipEst = $scope.edoreg[j].VAVClave;
                        break;
                    }
                }
                var banCont=false;
                if(fsds[i].TipoContenido>=4){
                    banCont = true;
                }
                
                $scope.FoliosDetalle.push({
                    'TipoContenido': tipCon,
                    'Formato': fsds[i].Formato,
                    'TipoEstado': tipEst,
                    "Editable": $scope.banderaFolioUsuario,
                    "msjCont": false,
                    "msjAI": false,
                    "msjFormato": false,
                    "msjEstado": false,
                    "eliminar": false,
                    "disabledContenido": banCont 
                });
                
            }
        }
            ).error(function (error, status) {
                $scope.error = { message: error, status: status };
                console.log($scope.error);
            });
    }
    function contenidoAutoincRequerido() {
        $scope.msjAIrequired = false;
        var ban = false;
        if ($scope.FoliosDetalle.length == 0 && $scope.Estado == 1) {
            ban = true;
        }else if ($scope.Estado == 1) {
            for (var i = 0; i < $scope.FoliosDetalle.length; i++) {
                if (!(($scope.FoliosDetalle[i].TipoContenido.VAVClave == "2" || $scope.FoliosDetalle[i].TipoContenido.VAVClave == "3") && $scope.FoliosDetalle[i].TipoEstado=="1")) {
                    ban = true;
                } else {
                    ban = false;
                    break;
                }
            }
        }
        if(ban){
            $scope.msjAIrequired = true;
            return false;
        }
        return true;
    }
    function obtenerTiposContenido() {
        var tiposContenido=[];
        for (var i = 0;i<$scope.FoliosDetalle.length;i++){
            tiposContenido[i] = $scope.FoliosDetalle[i].TipoContenido;
        }
        for (var i = 0; i < $scope.cTipCont.length; i++) {
            if (tiposContenido.includes($scope.cTipCont[i])) {
                $scope.cTipCont[i].disponible=true;
            } else {
                $scope.cTipCont[i].disponible = false;
            }
        }

    }
    function validaciones() {
        
        var aux = true;
        for (var i = 0; i < $scope.FoliosDetalle.length; i++) {
            if ($scope.FoliosDetalle[i].TipoContenido == "") {
                aux = false;
                $scope.FoliosDetalle[i].msjCont = true;
                $scope.FoliosDetalle[i].msjFormato = false;
                $scope.FoliosDetalle[i].msjEstado = false;
                break;
            } else if ($scope.FoliosDetalle[i].Formato == "" || $scope.FoliosDetalle[i].Formato == undefined) {
                aux = false;
                $scope.FoliosDetalle[i].msjFormato = true;
                $scope.FoliosDetalle[i].msjCont = false;
                $scope.FoliosDetalle[i].msjEstado = false;
                break;
            } else if ($scope.FoliosDetalle[i].TipoEstado == "" || $scope.FoliosDetalle[i].TipoEstado == null) {
                aux = false;
                $scope.FoliosDetalle[i].msjEstado = true;
                $scope.FoliosDetalle[i].msjCont = false;
                $scope.FoliosDetalle[i].msjFormato = false;
                break;
            } else {
                aux = true;
                $scope.FoliosDetalle[i].msjCont = false;
                $scope.FoliosDetalle[i].msjFormato = false;
                $scope.FoliosDetalle[i].msjEstado = false;
            }
        }
        if (!aux) {
            return false;
        }


        //tamaño total del formato actual
        var total = 0;
        for (var i = 0; i < $scope.FoliosDetalle.length; i++) {
            $scope.FoliosDetalle[i].msjCont = false;
            $scope.FoliosDetalle[i].msjFormato = false;
            $scope.FoliosDetalle[i].msjEstado = false;
            if ($scope.FoliosDetalle[i].TipoEstado == 1){ 
                total += $scope.FoliosDetalle[i].Formato.length;
            }
        }
        $scope.msjError = false;
        //validar formato maximo total
        if (!(total <= 16)) {
            $scope.msjError = true;
            return false;
        }

        //validar autoincremental cadenas de 00000's
        for (var i = 0; i < $scope.FoliosDetalle.length; i++) {
            $scope.FoliosDetalle[i].msjAI = false;
            if ($scope.FoliosDetalle[i].TipoContenido.VAVClave == 2) {
                var arr = $scope.FoliosDetalle[i].Formato.split("");
                for (var j = 0; j < arr.length; j++) {
                    if (arr[j] != "0") {
                        $scope.FoliosDetalle[i].msjAI = true;
                        return false;
                    } else {
                        $scope.FoliosDetalle[i].msjAI = false;
                    }
                }
            }
        }

        
        return true;
    }

  $scope.AddFolioDetalle = function () {
      obtenerTiposContenido();
 
      if ($scope.FoliosDetalle.length > 0 ) {
          if (validaciones()){
              $scope.FoliosDetalle.push({ 'TipoContenido': "", 'Formato': "", 'TipoEstado': "", "Editable": false, "msjCont": false, "msjAI": false, "msjFormato": false, "msjEstado": false, "eliminar" :true,"disabledContenido":false});
          }
      }else{
          $scope.FoliosDetalle.push({ 'TipoContenido': "", 'Formato': "", 'TipoEstado': "", "Editable": false, "msjCont": false, "msjAI": false, "msjFormato": false, "msjEstado": false, "eliminar": true, "disabledContenido":false });
      }
  
  }

  $scope.EliminarFolioDet = function (index) {
      $scope.FoliosDetalle.splice(index, 1);
      obtenerTiposContenido();
      }
  

    //BotonGuardar
  $scope.GuardarFolio = function () {
      if (validaciones() && $scope.form.Descripcion.$valid && $scope.form.valInicial.$valid && contenidoAutoincRequerido()) {
          var foliosDet=[];
          for (var i = 0; i < $scope.FoliosDetalle.length; i++) {
              foliosDet.push({
                  'TipoContenido': $scope.FoliosDetalle[i].TipoContenido.VAVClave,
                  'Formato': $scope.FoliosDetalle[i].Formato,
                  'TipoEstado': $scope.FoliosDetalle[i].TipoEstado,
                  'MUsuarioID': window.sessionStorage.getItem('USUId')
              });
          }
          var folio = {
              FolioID: FolioID,
              ModuloMovDetalleClave:ModuloMovDetalleClave,
              Descripcion :$scope.Descripcion,
              ValorInicial :$scope.valInicial,
              TipoEstado: $scope.Estado,
              Fiscal: Fiscal,
              SubEmpresaId: SubEmpresaId,
              MUsuarioID: window.sessionStorage.getItem('USUId'),
              FolioDetalle: foliosDet
          };
          
            $http({
                url: url + '/api/Folios/Grabar?folio=' + folio,
                method: 'post',
                data: JSON.stringify(folio),
                dataType: "json",
                headers: {
                    Authorization: window.sessionStorage.getItem('Token'),
                    'Content-Type': 'application/json'
                },
            }).success(function (data, status) {
                if (data) {
                    window.location.href = '../Folios/Index?Permiso=' + $scope.Permiso;
                } else {
                    console.log("Error");
                }
            }).error(function (error, status) {
            });
        }

    } 

    //BotonCancelar
    $scope.ValidarCancelar = function () {

        if ($scope.form.$dirty) {
            $scope.Action = "Cancel";
            messageBox.MostrarSiNo($scope.translation.XCancelar, $scope.translation.BP0002);
        }
        else {
            window.location.href = '../Folios/Index?Permiso=' + $scope.Permiso;
            console.log($scope.Permiso);
        }
    }
    $scope.AceptarYesNoMsgBox = function () {
        messageBox.Cerrar();
        
        if ($scope.Action == "Cancel") {
            window.location.href = '../Folios/Index?Permiso=' + $scope.Permiso;
        }
    }

    function folioUsuario(id) {
        $http({
            url: url + '/api/Folios/ObtenerFolioUsuario?folioID=' +id,
            metohod: 'GET',
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-Type': 'application/json'
            }
        }).success(function (data, status) {
            $scope.banderaFolioUsuario = data;
            ObtenerFolioDet(id);
            }).error(function (error, status) {
            $scope.error = { message: error, status: status };
            console.log($scope.error);
        });
    }

    function accionEditarEstado(it) {
        valorReferencia.obtenerValores('EDOREG', function (result) {
            $scope.edoreg = result;
            for (var j = 0; j < $scope.edoreg.length; j++) {
                if ($scope.edoreg[j].VAVClave == it.TipoEstado) {
                    $scope.Estado = $scope.edoreg[j].VAVClave;
                    break;
                }
            }
        });
        
    }

    //BotonEditar
    $scope.EditarFolio = function (FolioId, Permiso, SoloLectura) {
        $scope.Permiso = Permiso;
        if (SoloLectura.toUpperCase() == "TRUE") {
            $scope.SoloLectura = true;
        }
        else {
            $scope.SoloLectura = false;
        }

        if (FolioId != "") {
            $http({
                url: url + '/api/Folios/ObtenerValorFolio?FolioID=' + FolioId,
                method: 'GET',
                headers: {
                    Authorization: window.sessionStorage.getItem('Token'),
                    'Content-Type': 'application/json'
                },
            }).success(function (data, status) {
                angular.forEach(data, function (it) {
                    $scope.Descripcion = it.Descripcion;
                    $scope.valInicial = it.ValorInicial;
                    ModuloMovDetalleClave = it.ModuloMovDetalleClave;
                    FolioID = it.FolioID;
                    Fiscal = it.Fiscal;
                    SubEmpresaId = it.SubEmpresaId;
                    accionEditarEstado(it);
                });
                $scope.Nuevo = false;
                $scope.Action = "Edit";
                folioUsuario(FolioId);

            }).error(function (error, status) {
                console.log(" ERRORES ");
            });

        } else{
            $scope.Nuevo = true;
            $scope.Action = "Create";
            $scope.valInicial = "0";
            $scope.Estado = "1";
            FolioID = null;
            ObtenerFolioDet(FolioId);
        }
        
    }


    //**Define las páginas que se utilizaran al mostrar los registros del index de Folios**//
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

