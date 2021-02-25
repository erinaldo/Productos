var app = angular.module('terminales', ['valorReferencia', 'messageBox', 'ngResource', 'translation']);

app.controller('TerminalCtrl', ["$scope", "$http", 'valorReferencia', "messageBox", "translationService", function ($scope, $http, valorReferencia, messageBox, translationService) {
    
    var url = window.sessionStorage.getItem('URL');
    translationService.getTranslation($scope);
    ObtenerTerminales();
    ObtenerValoresTerminal();
    obtCentros();
    //Ordenar las columnas de la tabla TERMINAL
    $scope.sort = function (keyname) {
        $scope.sortKey = keyname;
        $scope.reverse = !$scope.reverse;
    }


    $scope.AsignarPermisoTerminal = function (Permiso, SoloLectura) {
        $scope.Permiso = Permiso;
        $scope.SoloLectura = SoloLectura;
    }
    


    function ObtenerValoresTerminal() {

        valorReferencia.obtenerValores('TERFASE', function (result) {
            $scope.terfase = result;
        }); 
    }

    function obtCentros() {
        $http({
            url: url + '/api/Terminales/ObtCentroDistribucion' ,
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

    function ObtenerTerminales() {

        $http({
            
            url: url + '/api/Terminales/ObtenerTerminales?usu=' + window.sessionStorage.getItem('USUId'),
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

    function ObtenerFase() {

        $http({


            url: url + '/api/Terminales/ObtenerFase',
            metohod: 'GET',
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-Type': 'application/json'
            }
        }).success(function (data, status) {
            $scope.vfase = data;
        }
            ).error(function (error, status) {
                $scope.error = { message: error, status: status };
                console.log($scope.error);
            });

    }

    $scope.GuardarTerminal = function () {
      
        if (!$scope.form.$valid) {
            $scope.form.submitted = true;
        } else {

            var terminales = {

                TerminalClave: $scope.TerminalClave,
                TipoFase: $scope.TipoFase,
                Descripcion: $scope.Descripcion,
                NumeroSerie: $scope.NumeroSerie,
                Comentario: $scope.Comentario,
                GPS: $scope.GPS,
                AlmacenID: $scope.AlmacenID,
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

   
    //Editar
    $scope.EditarTerminal = function (TerminalClave, Permiso, SoloLectura) {
        $scope.Permiso = Permiso;
        if (SoloLectura.toUpperCase() == "TRUE") {
            $scope.SoloLectura = true;
        }
        else {
            $scope.SoloLectura = false;
        }

        if (TerminalClave != "") {
            $http({
                url: url + '/api/Terminales/ObtenerValorTerminal?TerminalClave=' + TerminalClave,
                method: 'GET',
                headers: {
                    Authorization: window.sessionStorage.getItem('Token'),
                    'Content-Type': 'application/json'
                },
            }).success(function (data, status) {
                angular.forEach(data, function (it) {
                    $scope.TerminalClave = it.TerminalClave;
                    $scope.TipoFase = it.TipoFase;//preguntar AD
                    $scope.Descripcion = it.Descripcion;
                    $scope.NumeroSerie = it.NumeroSerie;
                    $scope.Comentario = it.Comentario;
                    $scope.GPS = it.GPS;
                    $scope.AlmacenID = it.AlmacenID;
                    $scope.Nuevo = false;
                   

                });
            }).error(function (error, status) {
                console.log(" ERRORES " );
            });

        } else {
            $scope.Action = "Create";
            $scope.Nuevo = true;
            
        }
    }

    //BTN cancelar 
    $scope.ValidarCancelar = function () {
        if (!$scope.form.$pristine) {
            $scope.Action = "Cancel";
            messageBox.MostrarSiNo($scope.translation.XCancelar, $scope.translation.BP0002);
        }
        else {
            window.location.href = '../Terminales/Index?Permiso=' + $scope.Permiso;
            consol.log($scope.Permiso);
        }
    }


    $scope.ActualizarTerminal = function (index, permiso) {
        permiso = "CRUDEOP";
        var terminales = {

                TerminalClave: index,
                NumeroSerie: "", 
                MUsuarioID: window.sessionStorage.getItem('USUId')

            };
            $http({
                url: url + '/api/Terminales/Actualizar?TerminalClave=' + $scope.TerminalClave,
                method: 'post',
                data: JSON.stringify(terminales),
                dataType: "json",
                headers: {
                    Authorization: window.sessionStorage.getItem('Token'),
                    'Content-Type': 'application/json'
                },
            }).success(function (data, status) {

                if (data) {
                    //window.location.href = '../Menu';
                    window.location.href = '../Terminales/Index?Permiso=' + permiso;

                } else {

                    console.log("Error");
                }


            }).error(function (error, status) {
            });

    }


    $scope.AceptarYesNoMsgBox = function () {
        messageBox.Cerrar();
        if ($scope.Action == "Delete") {
            $http({
                url: url + '/api/Terminales/Eliminar?TerminalClave=' + $scope.TerminalClave,
                method: 'GET',


                headers: {
                    Authorization: window.sessionStorage.getItem('Token'),
                    'Content-Type': 'application/json'
                },
            }).success(function (data, status) {
                window.location.href = '../Terminales/Index?Permiso=' + $scope.Permiso;
            }).error(function (error, status) {
            });
        }
        else if ($scope.Action == "Cancel") {
            window.location.href = '../Terminales/Index?Permiso=' + $scope.Permiso;
        }
    }


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


app.directive('validarClaveT', validarClaveT);
function validarClaveT($http, $q, $timeout) {
    return {
        restrict: 'A',
        require: 'ngModel',
        link: function ($scope, element, attr, ngModel) {
            ngModel.$asyncValidators.claveRepetida = function (modelValue, viewValue) {
                var deferred = $q.defer();
                
             if ($scope.Action == 'Create') { //Descomentar hasta llegar edit
             //   if (true) {
                    var clave = viewValue;
                   

                    var url = window.sessionStorage.getItem('URL');

                    $http({
                        url: url + '/api/Terminales/ValidarTerminalClave?TerminalClave=' + clave,
                        method: 'GET',
                        headers: {
                            Authorization: window.sessionStorage.getItem('Token'),
                            'Content-Type': 'application/json'
                        },
                    }).success(function (data, status) {
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


