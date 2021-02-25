var app = angular.module('perfil', ['valorReferencia', 'messageBox', 'ngResource', 'translation', 'ui.tree']);

app.controller("ctrPerfil", ["$scope", "$http", "valorReferencia", "messageBox", "translationService", function ($scope, $http, valorReferencia, messageBox, translationService) {

    var ctrl = this;
    var url = window.sessionStorage.getItem('URL');
   
    ObtenerPerfiles();
    ObtenerValores();
    translationService.getTranslation($scope); //agregar en todos los controllers de las actividades para que se llenen las etiquetas con los mensajes

    //For sorting according to columns
    $scope.sort = function (keyname) {
        $scope.sortKey = keyname;
        $scope.reverse = !$scope.reverse;
    }

    $scope.AsignarPermisos = function(Permiso) {
        $scope.Permiso = Permiso;
    }

    //To Get All Records  
    function ObtenerPerfiles() {
        $http({
            url: url + '/api/Perfil/ObtenerPerfiles',
            method: 'GET',
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-Type': 'application/json'
            },
        }).success(function (data, status) {
            $scope.perfiles = data;
            var tam = $scope.perfiles.length;
            $scope.tamPag = tamano(tam);
        }).error(function (error, status) {
        });                
    }

     
    function ObtenerValores() {             
        valorReferencia.obtenerValores('BINTERF', function (result) {
            $scope.BINTERF = result;
        });
    }
     
    $scope.ObtenerDisponibles = function (PERClave, TipoInterfaz) {
        $http({
            url: url + '/api/Perfil/ObtenerModulos?PERClave=' + PERClave + '&TipoInterfaz=' + TipoInterfaz + '&Disponibles=' + true,
            method: 'GET',
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-Type': 'application/json'
            },
        }).success(function (data, status) {
            $scope.modulosDisponibles = data;            
        }).error(function (error, status) {
        });
    }

    $scope.ObtenerAsignadas = function (PERClave, TipoInterfaz) {
        $http({
            url: url + '/api/Perfil/ObtenerModulos?PERClave=' + PERClave + '&TipoInterfaz=' + TipoInterfaz + '&Disponibles=' + false,
            method: 'GET',
            method: 'GET',
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-Type': 'application/json'
            },
        }).success(function (data, status) {
            $scope.modulosAsignados = data;
        }).error(function (error, status) {
        });
    }

    $scope.treeOptions = {
        accept: function (sourceNodeScope, destNodesScope, destIndex) {
            return true;
        },
    };

    $scope.toggle = function (scope) {
        scope.toggle();
    };

    $scope.GuardarPerfil = function () {
        if (!$scope.form.$valid) 
        {
            $scope.form.submitted = true;
            $event.preventDefault();
        }
        else{
           
            var nCont = 0;
           
            var IntPer = new Array();
            angular.forEach($scope.modulosAsignados, function (value, key) {
                var nSecuencia = 1;
                angular.forEach(value.Actividades, function (value2, key2)
                {
                    var permiso = "";
                    if (value2.Create)
                        permiso = permiso.concat("C");
                    if (value2.Read)
                        permiso = permiso.concat("R");
                    if (value2.Update)
                        permiso = permiso.concat("U");
                    if (value2.Delete)
                        permiso = permiso.concat("D");
                    if (value2.Execute)
                        permiso = permiso.concat("E");
                    if (value2.Others)
                        permiso = permiso.concat("O");
                    if (value2.Print)
                        permiso = permiso.concat("P");
                    if (value2.Sign)
                        permiso = permiso.concat("S");

                    var ip = {
                        ACTId: value2.ACTId,
                        INTTipoInterfaz: value.TipoInterfaz,
                        PERClave: $scope.PERClave,
                        MODId: value.MODId,
                        Permiso: permiso,
                        Secuencia: nSecuencia
                    };
                    IntPer.push(ip);
                    nSecuencia ++;
                    nCont ++;
                }, this);
            }, this);
            
            var perfil = {
                PERClave: $scope.PERClave,
                Descripcion: $scope.Descripcion,
                Activo: $scope.Activo,
                MUsuarioId: window.sessionStorage.getItem('USUId'),
                IntPer: IntPer
            };

            $http({
                url: url + '/api/Perfil/Grabar?perfil=' + perfil,
                method: 'post',
                data: JSON.stringify(perfil),
                dataType: "json",
                headers: {
                    Authorization: window.sessionStorage.getItem('Token'),
                    'Content-Type': 'application/json'
                },
            }).success(function (data, status) {
                window.location.href = '../Perfil/Index?Permiso=' + $scope.Permiso;
            }).error(function (error, status) {
            });

            debugger;
        }
    }

    $scope.EditarPerfil = function (PERClave, Permiso, SoloLectura) {
        $scope.Permiso = Permiso;
        if (SoloLectura.toUpperCase() == "TRUE") {
            $scope.SoloLectura = true;
        }
        else {
            $scope.SoloLectura = false;
        }
        
        if (PERClave != "") {
            $http({
                url: url + '/api/Perfil/ObtenerPerfil?PERClave=' + PERClave,
                method: 'GET',
                headers: {
                    Authorization: window.sessionStorage.getItem('Token'),
                    'Content-Type': 'application/json'
                },
            }).success(function (data, status) {
                if (data != null) {
                    $scope.PERClave = data.PERClave;
                    $scope.Descripcion = data.Descripcion;
                    $scope.Activo = data.Activo;
                    $scope.Nuevo = false;
                    $scope.Action = "Edit";
                }
            }).error(function (error, status) {
            });
        }
        else {
            //$scope.MENClave = "";
            $scope.Nuevo = true;
            $scope.Action = "Create";
            $scope.Activo = true;
            $scope.INTTipoInterfaz = "1";
            $scope.Read = true;

        }              
    }

    $scope.ValidarCancelar = function () {
        if (!$scope.form.$pristine && !$scope.SoloLectura) {
            $scope.Action = "Cancel";
            messageBox.MostrarSiNo($scope.translation.XCancelar, $scope.translation.BP0002);
        }
        else {
            window.location.href = '../Perfil/Index?Permiso=' + $scope.Permiso;
        }
    }

    $scope.AceptarYesNoMsgBox = function () {
        messageBox.Cerrar();
        if ($scope.Action == "Cancel") {
            window.location.href = '../Perfil/Index?Permiso=' + $scope.Permiso;
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
        return 5;
    }

}])

app.directive('perfilClaveUnica', validarClaveUnicaFunc)

function validarClaveUnicaFunc($http, $q, $timeout) {
    return {
        restrict: 'A',
        require: 'ngModel',
        link: function ($scope, element, attr, ngModel) {
            // fetch the call address from directives 'checkIfAvailable' attribute
            var validar = attr.perfilClaveUnica;

            ngModel.$asyncValidators.claveRepetida = function (modelValue, viewValue) {
                var deferred = $q.defer();

                if ($scope.Action == 'Create') {
                    var clave = viewValue;
                    var url = window.sessionStorage.getItem('URL');

                    $http({
                        url: url + '/api/Perfil/ValidarClaveUnica?PERClave=' + clave,
                        method: 'GET',
                        headers: {
                            Authorization: window.sessionStorage.getItem('Token'),
                            'Content-Type': 'application/json'
                        },
                    }).success(function (data, status) {
                        if (data == false)
                            deferred.resolve();
                        else
                            deferred.reject();
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