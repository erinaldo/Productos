var app = angular.module('almacen', ['valorReferencia', 'messageBox', 'ngResource', 'translation', 'centroBox', 'autoBox']);

app.controller('almacenCtrl', ["$scope", "$rootScope", "$http", "$window",'valorReferencia', "messageBox", "translationService", "centroBox", "autoBox", function ($scope, $rootScope, $http, $window, valorReferencia, messageBox, translationService, centroBox, autoBox) {
    var url = window.sessionStorage.getItem('URL');
    var marker = 0;
    var todoOk = null;
    var map;
    ObtenerValoresAlmacen();
    $scope.tipoRequerido = false;
    obtCentros();
    $scope.CodigoBarrasBloque = true;
    $scope.blockTipo = false;

    $scope.bloqueos = function () {
        debugger;
        var bloquear = $scope.Tipo;
        if (bloquear =="1") {

            $scope.blockTipo = true;
            $scope.AlmacenPadreId = "";
            $scope.requerido = true;

        } else {

            $scope.blockTipo = false;
            $scope.requerido = false;
        }
    }


    function ObtenerValoresAlmacen() {

        valorReferencia.obtenerValores('ALMTIPO', function (result) {
            $scope.almTipo = result;
        });

        valorReferencia.obtenerValores('EDOREG', function (result) {
            $scope.edoreg = result;
        });


    }
    //
    function obtCentros() {
        $http({
            url: url + '/api/Terminales/ObtCentroDistribucion',
            method: 'GET',
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-Type': 'application/json'
            },
        }).success(function (data, status) {
            $scope.btipouso = data;
            if ($scope.Action == "Create") {
                $scope.AlmacenPadreBloq = true;
                

            } else {
                $scope.AlmacenPadreBloq = false;

            }
        }).error(function (error, status) {
            console.log("DATOS: " + error);
        });
    }


    translationService.getTranslation($scope);
    ObtenerAlmacenes();


    $scope.camionData = [];
    $scope.camionList = [];

    $scope.AsignarPermisoAlmacen = function (Permiso) {
        $scope.Permiso = Permiso;
    }
    $scope.sort = function (keyname) {
        $scope.sortKey = keyname;
        $scope.reverse = !$scope.reverse;
    }



    function ObtenerAlmacenes() {
        $http({
            url: url + '/api/Almacen/ObtenerAlmacenes',
            metohod: 'GET',
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-Type': 'application/json'
            }
        }).success(function (data, status) {
            $scope.cAlmacenesList = data;
            $scope.TipoEstado = "1";
        }
        ).error(function (error, status) {
            $scope.error = { message: error, status: status };
            console.log($scope.error);
        });


    }
    function ObtenerCamiones() {
        $http({
            url: url + '/api/Almacen/ObtenerCamiones?AlmacenID=' + $scope.TmpAlmacenID.replace(/\+/g, "%2B") + '&Action=' + $scope.Action,
            metohod: 'GET',
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-Type': 'application/json'
            }
        }).success(function (data, status) {
            $scope.camionesList = data;
        }
         ).error(function (error, status) {
             $scope.error = { message: error, status: status };
             console.log($scope.error);
         });
    }

    $scope.GuardarAlmacen = function () {
        debugger;
        if (!$scope.form.$valid) {
            $scope.form.submitted = true;
        } else {
            var almacen = {
                AlmacenId: $scope.AlmacenID,
                AlmacenPadreId: $scope.AlmacenPadreId,
                Clave: $scope.Clave,
                Nombre: $scope.Nombre,
                Domicilio: $scope.Domicilio,
                Telefono: $scope.Telefono,
                Tipo: $scope.Tipo,
                TipoEstado: $scope.TipoEstado,
                CodigoBarras: $scope.CodigoBarras,
                Latitud: $scope.Latitud,
                Longitud: $scope.Longitud,
                Camion: $scope.camionData,
                MUsuarioId: window.sessionStorage.getItem('USUId'),
            };
            $http({
                url: url + '/api/Almacen/GuardarAlmacen?almacen=' + almacen,
                method: 'post',
                data: JSON.stringify(almacen),
                dataType: "json",
                headers: {
                    Authorization: window.sessionStorage.getItem('Token'),
                    'Content-type': 'application/json'
                }
            }).success(function (data) {
                window.location.href = '../Almacen/Index?Permiso=' + $scope.Permiso;
            }).error(function (error) {
                console.log(error);
            });
        }
    }

    $scope.AgregarAutomovil = function () {
        autoBox.Mostrar($scope.translation.ERMCAMESC_IGeneral);
    }

    function obtVehiculos() {
        $http({
            url: url + '/api/Almacen/obtVehiculos?USUId=' + $scope.USUIDTemp.replace(/\+/g, "%2B") + "&Action=" + $scope.Action,
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

    $scope.EditarAlmacen = function (AlmacenID, Permiso, SoloLectura) {
      
        //asignar permiso
        $scope.Permiso = Permiso;

      if (SoloLectura.toUpperCase() == "TRUE") {
            $scope.SoloLectura = true;
        }
        else {
            $scope.SoloLectura = false;
        }
      if (AlmacenID != "") {
            $http({
                url: url + '/api/Almacen/ObtenerAlmacen?AlmacenID=' + AlmacenID.replace(/\+/g, "%2B"),
                method: 'GET',
                headers: {
                    Authorization: window.sessionStorage.getItem('Token'),
                    'Content-Type': 'application/json'
                },
            }).success(function (data, status) {
                angular.forEach(data,function(value){
                    $scope.AlmacenID = value.AlmacenID,
                    $scope.AlmacenPadreId = value.AlmacenPadreId,
                    $scope.Clave = value.Clave,
                    $scope.Estado = value.Estado,
                    $scope.Nombre = value.Nombre,
                    $scope.Domicilio = value.Domicilio,
                    $scope.Telefono = value.Telefono,
                    $scope.Tipo = value.Tipo,
                    $scope.TipoEstado = value.TipoEstado,
                    $scope.CodigoBarras = value.CodigoBarras,
                    $scope.Latitud = value.Latitud,
                    $scope.Longitud = value.Longitud


                });
                $scope.TipoBloque = true;
                AlmacenPadreBloq = false;
                $scope.Tipo == "2" ? $scope.tipoRequerido = true : $scope.tipoRequerido = false;
                $scope.Action = "Edit";
                mapa($scope.Latitud, $scope.Longitud, $scope.Domicilio);
            }).error(function (error, status) {
                console.log(" ERRORES ");
            });
        } else {
            $scope.Action = "Create";
        }

    }

    function mapa(latitude, longitude, domicilio) {
        console.log("Función mapa");
        var lng = longitude;
        var lat = latitude;
        map = new google.maps.Map(document.getElementById('map'), {
            center: { lat: lat, lng: lng },
            zoom: 14
        });
        console.log("Pruebas");
        var myLatLng = { lat: lat, lng: lng };
        marker = new google.maps.Marker({
            position: myLatLng,
            map: map,
            title: 'Hello World!'
        });
        $scope.mapa = true;
        var ubicacionVacante = new google.maps.Geocoder();
        if (marker !== 0)
            marker.setMap(null);
        //Generamos el circulo en el mapa

        ubicacionVacante.geocode({ "address": domicilio }, function (results, status) {
            //console.log(google.maps.GeocoderStatus);
            if (status === google.maps.GeocoderStatus.OK) {
                map.setCenter(results[0].geometry.location);
                map.setZoom(14);
                marker = new google.maps.Marker({
                    position: results[0].geometry.location, //new google.maps.LatLng((21.688099074804537 + 1), -101.49809649999997),
                    map: map,
                    draggable: false
                });

                $scope.mapa = true;
                getCoords(marker.position.lat(), marker.position.lng(), results[0].formatted_address);
                console.log("Se ha creado el mapa d");
                google.maps.event.addListener(marker, 'dragend', function () {
                    getCoords(marker.position.lat(), marker.position.lng(), results[0].formatted_address);
                    getNewAddress(marker.position.lat(), marker.position.lng(), map.zoom);
                });
                console.log("Se ha creado el mapa d");
                return true;
            } else {
                // generarUbicacionSecundaria();
                $scope.mapa = false;
                console.log("No se ha podido crear el mapa");
                //No sé puede determinar la ubicacion por un error
            }
        });
    }

    $scope.CrearMapa = function () {
        
        if ($scope.Domicilio ) {

            ///prueba
            var lng = 0;
            var lat = 0;
            if (!$scope.mapa) {
                
                lng = -103.3661475;
                lat = 20.6678657;
                console.log("Aun no tiene valor el mapa");
            } else {
                lng = $scope.Longitud;
                lat = $scope.Latitud;
                console.log("Ya fue creado el mapa");
            }
        
            map = new google.maps.Map(document.getElementById('map'), {
                center: { lat: lat, lng: lng },
                zoom: 14
            });
            console.log("Pruebas" + "15" + $scope.Domicilio);
            var myLatLng = { lat: lat, lng: lng };
            marker = new google.maps.Marker({
                position: myLatLng,
                map: map,
                title: 'Hello World!'
            });
            $scope.mapa = true;
            var ubicacionVacante = new google.maps.Geocoder();
            if (marker !== 0)
                marker.setMap(null);
            //Generamos el circulo en el mapa

            ubicacionVacante.geocode({ "address": $scope.Domicilio }, function (results, status) {
                //console.log(google.maps.GeocoderStatus);
                if (status === google.maps.GeocoderStatus.OK) {
                    map.setCenter(results[0].geometry.location);
                    map.setZoom(14);
                    marker = new google.maps.Marker({
                        position: results[0].geometry.location, //new google.maps.LatLng((21.688099074804537 + 1), -101.49809649999997),
                        map: map,
                        draggable: false,
                        disableDefaultUI: true
                    });
                    $scope.mapa = true;
                    getCoords(marker.position.lat(), marker.position.lng(), results[0].formatted_address);
                    console.log("Se ha creado el mapa d");
                    google.maps.event.addListener(marker, 'dragend', function () {
                        getCoords(marker.position.lat(), marker.position.lng(), results[0].formatted_address);
                        getNewAddress(marker.position.lat(), marker.position.lng(), map.zoom);
                    });
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
        }
    }

    function getNewAddress(lat, lng, zoom) {
        console.log("Soy un fantasma");
        map = new google.maps.Map(document.getElementById('map'), {
            center: { lat: lat, lng: lng },
            zoom: zoom
        });
        var myLatLng = { lat: lat, lng: lng };
        marker = new google.maps.Marker({
            position: myLatLng,
            map: map,
            title: 'Hello World!'
        });

        var ubicacionVacante = new google.maps.Geocoder();
        if (marker !== 0)
            marker.setMap(null);
        //Generamos el circulo en el mapa
        ubicacionVacante.geocode({ "location": myLatLng }, function (results, status) {
            //console.log(google.maps.GeocoderStatus);
            if (status === google.maps.GeocoderStatus.OK) {
                map.setCenter(results[0].geometry.location);
                map.setZoom(zoom);
                marker = new google.maps.Marker({
                    position: results[0].geometry.location, //new google.maps.LatLng((21.688099074804537 + 1), -101.49809649999997),
                    map: map,
                    draggable: true
                });
          

                $scope.Latitud = marker.position.lat();
                $scope.Longitud = marker.position.lng();

                        $scope.$apply(function () {
                            $scope.Domicilio = results[0].formatted_address;
                            console.log("Mapa aplicado");
                        });

                google.maps.event.addListener(marker, 'dragend', function () {
                console.log("fantasmita; " + results[0].formatted_address);
                    //Define la direccion exacta del punto
                   // console.log("Results: " + results[0].formatted_address);
                    getCoords(marker.position.lat(), marker.position.lng(), results[0].formatted_address);
                    getNewAddress(marker.position.lat(), marker.position.lng(), map.zoom);
           
                });
                return true;
            } else {
                // generarUbicacionSecundaria();
                $scope.mapa = false;
                console.log("No se ha podido crear el mapa");
                //No sé puede determinar la ubicacion por un error
            }
        });
    }
  
    function getCoords(lat, lng,direccion) {

        $scope.$apply(function () {
            $rootScope.uva = "UVAf" + lat;
            console.log("Direccion: " + direccion);
            $scope.Domicilio = direccion;
            $scope.Latitud = lat;
            $scope.Longitud = lng;
       
        });

    }


    /**CAMIONES**/
    $scope.addCamion = function (placa,clave,desc,checked) {
        if (checked == "YES") {
            $scope.camionData.push({ "Placa": placa, "Clave": clave, "Descripcion": desc });
        } else {
            angular.forEach($scope.camionData, function (value, key) {
                if (value.Placa == placa) {
                    $scope.camionData.splice(key, 1);
                }
            });
        }  


       
    }

    //Obtener el detalle de los camiones
    $scope.ObtenerDetalleAlmacen = function (AlmacenID, Placa) {
        $http({
            url: url + '/api/Almacen/ObtenerDetalleAlmacen?AlmacenID=' + AlmacenID.replace(/\+/g, "%2B"),
            method: "GET",
            headers: {
                Authorization: sessionStorage.getItem('Token'),
                'Content-Type':'application/json'
            }
        }).success(function (data, status) {
            $scope.TmpAlmacenID = AlmacenID;
            ObtenerCamiones();



            if(data == true)
                $scope.camionData = [];
            else
                $scope.camionData = data;
        }).error(function () {
            
        });
    }

    $scope.tipoAlm = function () {
        debugger;
        if ($scope.Tipo !== undefined) {
            if ($scope.Tipo != null) {
                console.log("Tipo: " + $scope.Tipo);
                console.log("PRUEBA MASTER: " + $scope.Tipo);
                if ($scope.Tipo == 2 || $scope.Tipo == 3 ) {
                    $scope.tipoRequerido = true;
                    $scope.AlmacenPadreBloq = false;
                    console.log("Se activa la opción Add Camion");
                    $scope.CodigoBarrasBloque = true;
                } else {
                    $scope.tipoRequerido = false;
                    $scope.AlmacenPadreBloq = true;
                    $scope.CodigoBarrasBloque = false;


                    console.log("Se desactiva la opción Add Camion");
                }
            } else {
                $scope.tipoRequerido = true;
                $scope.AlmacenPadreBloq = true;
                $scope.CodigoBarrasBloque = true;

                console.log("Tipo no contiene valor ");
            }
        } else {
            $scope.tipoRequerido = false;
            $scope.AlmacenPadreBloq = true;
            $scope.CodigoBarrasBloque = true;

            console.log("Tipo no está definida");
        }
    }

    //Eliminar camion
    $scope.ValidarEliminarCamion = function (index, placa) {
        console.log("Nuevas Acciones: " + index + " : " + placa);
        $scope.Action = "EliminarCamion";
        $scope.IndexCamion = index;
        $scope.Placa = placa;
        
        //messageBox.MostrarSiNo($scope.translation.XEliminar, $scope.translation.P0001);//Validar si se deja ese mensaje o se cambia por "¿Está seguro de eliminar la descripción?"
        angular.forEach($scope.camionData, function (v, k) {
            if (v.Placa == placa) {
                $scope.camionData.splice(k, 1);
                
            }
        })


    }

    $scope.ValidarEliminarAlmacen = function (IdAlmacen) {
        console.log("AlamacenID" + IdAlmacen);
        $scope.Action = "EliminarAlmacen";
        $scope.AlmacenIDAux = IdAlmacen;

        messageBox.MostrarSiNo($scope.translation.XEliminar, $scope.translation.P0001);//Validar si se deja ese mensaje o se cambia por "¿Está seguro de eliminar la descripción?"
    }




    //BTN cancelar 
    $scope.ValidarCancelar = function () {
        if (!$scope.form.$pristine) {
            $scope.Action = "Cancel";
            messageBox.MostrarSiNo($scope.translation.XCancelar, $scope.translation.BP0002);
        }
        else {
            window.location.href = '../Almacen/Index?Permiso=' + $scope.Permiso;
            consol.log($scope.Permiso);
        }
    }


    $scope.AceptarYesNoMsgBox = function () {
        messageBox.Cerrar();
        if ($scope.Action == "Delete") {
            $http({
                url: url + '/api/Almacen/Eliminar?Clave=' + $scope.Clave,
                method: 'GET',


                headers: {
                    Authorization: window.sessionStorage.getItem('Token'),
                    'Content-Type': 'application/json'
                },
            }).success(function (data, status) {
                window.location.href = '../Almacen/Index?Permiso=' + $scope.Permiso;
            }).error(function (error, status) {
            });
        }
        else if ($scope.Action == "Cancel") {
            window.location.href = '../Almacen/Index?Permiso=' + $scope.Permiso;
        }
    }

    
 
}]);

app.directive('validarClaveAl', validarClaveAlm);
function validarClaveAlm($http, $q, $timeout) {
    return {
        restrict: 'A',
        require: 'ngModel',
        link: function ($scope, element, attr, ngModel) {
            ngModel.$asyncValidators.claveRepetidaAlmacen = function (modelValue, viewValue) {
                var deferred = $q.defer();
                debugger;
                if ($scope.Action == 'Create') { //Descomentar hasta llegar edit
                    //   if (true) {
                    var clave = viewValue;


                    var url = window.sessionStorage.getItem('URL');
                    debugger;
                    $http({
                        url: url + '/api/Almacen/ValidarAlmacenClave?clave=' + clave,
                        method: 'GET',
                        headers: {
                            Authorization: window.sessionStorage.getItem('Token'),
                            'Content-Type': 'application/json'
                        },
                    }).success(function (data, status) {
                        debugger;
                        if (data == false) {

                            deferred.resolve();
                        }

                        else {

                            deferred.reject();
                        }

                    }).error(function (error, status) {
                        deferred.resolve();
                    });
                }
                else {

                    deferred.resolve();
                }


                // return the promise of the asynchronous validator
                return deferred.promise;
            }
        }
    }
}

