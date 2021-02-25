var app = angular.module('frecuencias', ['valorReferencia', 'messageBox', 'ngResource', 'translation']);

app.controller('FrecuenciaCtrl', ["$scope", "$http", 'valorReferencia', "messageBox", "translationService", function ($scope, $http, valorReferencia, messageBox, translationService) {
    
    var url = window.sessionStorage.getItem('URL');
    translationService.getTranslation($scope);    
    ObtenerFrecuencias();
    ObtenerValoresReferencia();
    $scope.fechaFinalStatus = true;
    $scope.Intervalo = 0;
    $scope.Repeticion = 0;
    $scope.tip = false;
    $scope.tip2 = false;
    $scope.errorRep = false;
    $scope.statusClave = false;
    $scope.statusEditar = false;
   
    //obtiene los estados para los folios del index
    function ObtenerValoresReferencia() {
       
        valorReferencia.obtenerValores('FRETIPO', function (result) {
            $scope.fretipo = result;
        });
       
    }
    $scope.AsignarPermisoFrecuencia = function (Permiso) {
        $scope.Permiso = Permiso;
        console.log("Permiso " + $scope.Permiso);
    }

    function crearFecha(dias) {
        
        var numDia = parseInt(dias);
        var mes;
        if (numDia <=365 && numDia>334) {
            numDia = numDia - 334;
            mes = " De Diciembre";
        } else if (numDia <= 334 && numDia > 304) {
            numDia = numDia - 304;
            mes = " De Noviembre";
        } else if (numDia <= 304 && numDia > 273) {
            numDia = numDia - 273;
            mes = " De Octubre";
        } else if (numDia <= 273 && numDia > 243) {
            numDia = numDia - 243;
            mes = " De Septiembre";
        } else if (numDia <= 243 && numDia > 212) {
            numDia = numDia - 212;
            mes = " De Agosto";
        } else if (numDia <= 212 && numDia > 181) {
            numDia = numDia - 181;
            mes = " De Julio";
        } else if (numDia <= 181 && numDia > 151) {
            numDia = numDia - 151;
            mes = " De Junio";
        } else if (numDia <= 151 && numDia > 120) {
            numDia = numDia - 120;
            mes = " De Mayo";
        } else if (numDia <= 120 && numDia > 90) {
            numDia = numDia - 90;
            mes = " De Abril";
        } else if (numDia <= 90 && numDia > 59) {
            numDia = numDia - 59;
            mes = " De Marzo";
        } else if (numDia <= 59 && numDia > 31) {
            numDia = numDia - 31;
            mes = " De Febrero";
        } else if (numDia <= 31 && numDia > 0) {
            mes = " De Enero";
        }



        return ""+numDia + mes;
    }
    function crearFechaUnidadInicio(dias) {
        var numDia = parseInt(dias);
        var mes;
        if (numDia <= 365 && numDia > 334) {
            numDia = numDia - 334;
            mes = 11;
        } else if (numDia <= 334 && numDia > 304) {
            numDia = numDia - 304;
            mes = 10;
        } else if (numDia <= 304 && numDia > 273) {
            numDia = numDia - 273;
            mes = 9;
        } else if (numDia <= 273 && numDia > 243) {
            numDia = numDia - 243;
            mes = 8;
        } else if (numDia <= 243 && numDia > 212) {
            numDia = numDia - 212;
            mes = 7;
        } else if (numDia <= 212 && numDia > 181) {
            numDia = numDia - 181;
            mes = 6;
        } else if (numDia <= 181 && numDia > 151) {
            numDia = numDia - 151;
            mes = 5;
        } else if (numDia <= 151 && numDia > 120) {
            numDia = numDia - 120;
            mes = 4;
        } else if (numDia <= 120 && numDia > 90) {
            numDia = numDia - 90;
            mes =3;
        } else if (numDia <= 90 && numDia > 59) {
            numDia = numDia - 59;
            mes = 2;
        } else if (numDia <= 59 && numDia > 31) {
            numDia = numDia - 31;
            mes = 1;
        } else if (numDia <= 31 && numDia > 0) {
            mes = 0;
        }


        var arr = [];
        arr[0] = numDia;
        arr[1] = mes;
        return arr;
    }
    function convertirFechaDias(fecha) {
        var unidadIn = 0;
        var arr = fecha.toString().split(" ");
        switch(arr[1]){
            case "Jan":
                unidadIn = parseInt(arr[2]);
                break;
            case "Feb":
                unidadIn = 31 + parseInt(arr[2]);
                break;
            case "Mar":
                unidadIn = 59 + parseInt(arr[2]);
                break;
            case "Apr":
                unidadIn = 90 + parseInt(arr[2]);
                break;
            case "May":
                unidadIn = 120 + parseInt(arr[2]);
                break;
            case "Jun":
                unidadIn = 151 + parseInt(arr[2]);
                break;
            case "Jul":
                unidadIn = 181 + parseInt(arr[2]);
                break;
            case "Aug":
                unidadIn = 212 + parseInt(arr[2]);
                break;
            case "Sep":
                unidadIn = 243 + parseInt(arr[2]);
                break;
            case "Oct":
                unidadIn = 273 + parseInt(arr[2]);
                break;
            case "Nov":
                unidadIn = 304 + parseInt(arr[2]);
                break;
            case "Dec":
                unidadIn = 334 + parseInt(arr[2]);
                break;
        }
        return unidadIn;
    }


    $scope.iniciarFechaFinal = function () {
        if ($scope.fechaFinalStatus == false) {
            if ($scope.FechaInicio.getTime() > $scope.FechaFinal.getTime()) {
                $scope.FechaFinal = $scope.FechaInicio;
            }
           

            
        } else {
            $scope.fechaFinalStatus = false;
            $scope.FechaFinal = $scope.FechaInicio;
        }
        
    }

    function Validaciones() {
        if ($scope.Nuevo) {
            for (var i = 0; i < $scope.cFrecList.length; i++) {
                if ($scope.cFrecList[i].FrecuenciaClave == $scope.FrecuenciaClave) {
                    $scope.statusClave = true;
                    return false;
                }
            }
            $scope.statusClave = false;
        }

        if ($scope.Tipo == "3"){
            if(!$scope.form.UnidadInicio2.$valid){
                return false;
            }
        } else if(!$scope.form.UnidadInicio.$valid){
            return false;
        }
        if (!($scope.form.FrecuenciaClave.$valid &&
            $scope.form.Descripcion.$valid &&
            $scope.form.Tipo.$valid &&
            $scope.form.FechaInicio.$valid &&
            $scope.form.FechaFinal.$valid &&
            $scope.form.Repeticion.$valid &&
            $scope.form.Intervalo.$valid)) {
            return false;
        }

        
        

        if ($scope.Tipo == "1") {
            if (parseInt($scope.Intervalo) > 6) {
                $scope.cantDias = 7;
                $scope.banRep = true;
                return false;
            } else {
                $scope.banRep = false;
            }
        }
        if ($scope.Tipo == "2") {
            if (parseInt($scope.Intervalo) > 30) {
                $scope.banRep = true;
                $scope.cantDias = 31;
                return false;
            } else {
                $scope.banRep = false;
            }
        }
         if ($scope.Tipo == "3") {
            if (parseInt($scope.Intervalo) > 364) {
                $scope.banRep = true;
                $scope.cantDias = 365;
                return false;
            } else {
                $scope.banRep = false;
            }
         }
        if ($scope.Repeticion=="" || $scope.Intervalo=="") {
                     return false;
         }
         switch ($scope.Tipo) {
             case "1":
                 if ((parseInt($scope.Repeticion)*parseInt($scope.Intervalo))>=7) {
                     $scope.errorRep=true;
                     return false;
                 } else {
                     $scope.errorRep = false;
                 }
                 break;
             case "2":
                 if ((parseInt($scope.Repeticion) * parseInt($scope.Intervalo)) >= 31) {
                     $scope.errorRep = true;
                     return false;
                 } else {
                     $scope.errorRep = false;
                 }

                 break;
             case "3":
                 if ((parseInt($scope.Repeticion) * parseInt($scope.Intervalo)) >= 365) {
                     $scope.errorRep = true;
                     return false;
                 } else {
                     $scope.errorRep = false;
                 }

                 break;

        }
         return true;
        
    }
   
    $scope.iniciarInputs = function () {
        
        if ($scope.Tipo == "1") {
            valorReferencia.obtenerValores('FREDIA', function (result) {
                $scope.fredia = result;
                $scope.tip = true;
                $scope.tip2 = false;
            });
        } else if ($scope.Tipo == "2"){
            $scope.tip = true;
            $scope.tip2 = false;
            var arr = [];
            for (var i = 1; i <= 31; i++) {
                arr.push({
                    'VAVClave': i,
                    'Descripcion': i
                });
            }
            $scope.fredia = arr;
        } else if ($scope.Tipo == "3") {
            $scope.tip = false;
            $scope.tip2 = true;
            $scope.minFecha = new Date(new Date().getFullYear(), "0", "1");
            $scope.maxFecha = new Date(new Date().getFullYear(), "11", "31");

        }
         

    }
   
    //mostrar la tabla de Folios en el index
    function ObtenerFrecuencias() {
        $http({

            url: url + '/api/Frecuencias/ObtenerFrecuencias',
            metohod: 'GET',
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-Type': 'application/json'
            }
        }).success(function (data, status) {
            var lista = [];
            lista = data;
            valorReferencia.obtenerValores('FREDIA', function (result) {
                for (var i = 0; i < lista.length; i++) {
                    var arr = lista[i].FechaInicio.split("T");
                    var arr2 = arr[0].split("-");
                    lista[i].FechaInicio = (arr2[2] + "/" + arr2[1] + "/" + arr2[0]);
                    arr = lista[i].FechaFinal.split("T");
                    arr2 = arr[0].split("-");
                    lista[i].FechaFinal = (arr2[2] + "/" + arr2[1] + "/" + arr2[0]);
                    if (lista[i].tip == 1) {
                        for (var j = 0; j < result.length; j++) {
                            if (lista[i].UnidadInicio == result[j].VAVClave) {
                                lista[i].UnidadInicio = result[j].Descripcion;
                                break;

                            }
                        }
                    }
                    if(lista[i].tip == 3){
                        lista[i].UnidadInicio=crearFecha(lista[i].UnidadInicio);                    }
                }
                $scope.cFrecList = lista;
                    var tam = $scope.cFrecList.length;
                    $scope.tamPag = tamano(tam);
                });
           
           
            }).error(function (error, status) {
                $scope.error = { message: error, status: status };
                console.log($scope.error);
            });
        }
        
    

    //BotonGuardar
    $scope.GuardarFrecuencia = function () {
        if (Validaciones()) {
           
            var unidadIn;
            if ($scope.Tipo == 3) {
                unidadIn = convertirFechaDias($scope.UnidadInicio2);
            }else{
                unidadIn=$scope.UnidadInicio;
            }
            if ($scope.Intervalo==0 || $scope.Repeticion==0) {
                $scope.Intervalo = 0;
                $scope.Repeticion = 0;
            }

            var frec = {
            FrecuenciaClave : $scope.FrecuenciaClave,
            Descripcion : $scope.Descripcion,
            Tipo : $scope.Tipo,
            FechaInicio : $scope.FechaInicio,
            FechaFinal : $scope.FechaFinal,
            UnidadInicio: unidadIn,
            Repeticion : $scope.Repeticion,
            Intervalo : $scope.Intervalo,
            MUsuarioID: window.sessionStorage.getItem('USUId')
            };
            
            


            $http({
                url: url + '/api/Frecuencias/Grabar?frecuencia=' + frec,
                method: 'post',
                data: JSON.stringify(frec),
                dataType: "json",
                headers: {
                    Authorization: window.sessionStorage.getItem('Token'),
                    'Content-Type': 'application/json'
                },
            }).success(function (data, status) {
                if (data) {
                    window.location.href = '../Frecuencias/Index?Permiso=' + $scope.Permiso;
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
            window.location.href = '../Frecuencias/Index?Permiso=' + $scope.Permiso;
            console.log($scope.Permiso);
        }
    }
    $scope.AceptarYesNoMsgBox = function () {
        messageBox.Cerrar();
        
        if ($scope.Action == "Cancel") {
            window.location.href = '../Frecuencias/Index?Permiso=' + $scope.Permiso;
        }
    }


    //BotonEditar
    $scope.EditarFrecuencia = function (FrecuenciaClave, Permiso, SoloLectura) {
        $scope.Permiso = Permiso;
        if (SoloLectura.toUpperCase() == "TRUE") {
            $scope.SoloLectura = true;
        }
        else {
            $scope.SoloLectura = false;
        }

        if (FrecuenciaClave != "") {
            $http({
                url: url + '/api/Frecuencias/ObtenerValorFrecuencia?clave=' + FrecuenciaClave,
                method: 'GET',
                headers: {
                    Authorization: window.sessionStorage.getItem('Token'),
                    'Content-Type': 'application/json'
                },
            }).success(function (data, status) {
                angular.forEach(data, function (it) {
                    $scope.FrecuenciaClave=it.FrecuenciaClave;
                    $scope.Descripcion = it.Descripcion;
                    
                    valorReferencia.obtenerValores('FRETIPO', function (result) {
                        $scope.fretipo = result;
                        for (var i = 0; i < result.length; i++) {
                            if(it.Tipo==result[i].VAVClave){
                                $scope.Tipo = result[i].VAVClave;
                                break;
                            }
                        }
                        $scope.iniciarInputs();
                    });
                    

                    var arrFecha, arrFecha2;
                    arrFecha = it.FechaInicio.split("T");
                    arrFecha2=arrFecha[0].split("-");
                    $scope.FechaInicio = new Date(arrFecha2[0], parseInt(arrFecha2[1])-1, arrFecha2[2]);
                    arrFecha = it.FechaFinal.split("T");
                    arrFecha2 = arrFecha[0].split("-");
                    $scope.FechaFinal = new Date(arrFecha2[0], parseInt(arrFecha2[1]) - 1, arrFecha2[2]);
                    $scope.fechaFinalStatus = false;

                    if (it.Tipo == 1) {
                        valorReferencia.obtenerValores('FREDIA', function (result) {
                            $scope.fredia = result;
                            $scope.tip = true;
                            $scope.tip2 = false;
                            for (var i = 0; i < $scope.fredia.length;i++){
                           if($scope.fredia[i].VAVClave==it.UnidadInicio) {
                            $scope.UnidadInicio=$scope.fredia[i].VAVClave;
                           }
                        }
                        });
                          
                    } else if (it.Tipo == 3) {
                        $scope.tip = false;
                        $scope.tip2 = true;
                        var fechaUnidadInicio = crearFechaUnidadInicio(it.UnidadInicio);
                        $scope.UnidadInicio2 = new Date(new Date().getFullYear(), fechaUnidadInicio[1], fechaUnidadInicio[0]);
                    } else {
                        $scope.tip = true;
                        $scope.tip2 = false;
                      $scope.UnidadInicio = it.UnidadInicio;
                   }
                   

                    $scope.Repeticion = it.Repeticion;
                    $scope.Intervalo = it.Intervalo;
                    $scope.statusEditar = true;
                });
                $scope.Nuevo = false;
                $scope.Action = "Edit";

            }).error(function (error, status) {
                console.log(" ERRORES ");
            });

        } else {
            $scope.statusEditar = false;
            $scope.Nuevo = true;
            $scope.Action = "Create";
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

