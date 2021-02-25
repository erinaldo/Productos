var app = angular.module('mensaje', ['valorReferencia', 'messageBox', 'ngResource', 'translation']);

app.controller("ctrMensaje", ["$scope", "$http", "valorReferencia", "messageBox", "translationService", function ($scope, $http, valorReferencia, messageBox, translationService) {

    var ctrl = this;
    var url = window.sessionStorage.getItem('URL');
   
    ObtenerMensajes();
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
    function ObtenerMensajes() {
        $http({
            url: url + '/api/Mensaje/ObtenerMensajes',
            method: 'GET',
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-Type': 'application/json'
            },
        }).success(function (data, status) {
            $scope.mensajes = data;
            var tam = $scope.mensajes.length;
            $scope.tamPag = tamano(tam);
            console.log(JSON.stringify("tam = " + tam + " dividido: " + $scope.tamPag));
        }).error(function (error, status) {
        });                
    }    

    function ObtenerValores() {             
        valorReferencia.obtenerValores('BMENSAJE', function (result) {
            $scope.bmensaje = result;
        });
        valorReferencia.obtenerValores('BMENAPL', function (result) {
            $scope.bmenapl = result;
        });
        valorReferencia.obtenerValores('BPROYECT', function (result) {
            $scope.bproyect = result;
        });
        valorReferencia.obtenerValores('BLENGUA', function (result) {
            $scope.blengua = result;
        });
    }

    $scope.ObtenerDetalle = function (MENClave) {    
        $http({
            url: url + '/api/Mensaje/ObtenerDetalle?MENClave=' + MENClave,
            method: 'GET',
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-Type': 'application/json'
            },
        }).success(function (data, status) {
            $scope.mendetalle = data;            
        }).error(function (error, status) {
        });
    }

    $scope.GuardarMensaje = function () {
        if (!$scope.form.$valid) 
        {
            $scope.form.submitted = true;
        //    $event.preventDefault();
        }
        else{
            var mensaje = {
                MENClave: $scope.MENClave,
                TipoAplicacion: $scope.TipoAplicacion,
                TipoMensaje: $scope.TipoMensaje,
                TipoProyecto: $scope.TipoProyecto,
                MUsuarioId: window.sessionStorage.getItem('USUId'),
                MENDetalle: $scope.mendetalle
            };
            
            $http({
                url: url + '/api/Mensaje/Grabar?msg=' + mensaje,
                method: 'post',
                data: JSON.stringify(mensaje),
                dataType: "json",
                headers: {
                    Authorization: window.sessionStorage.getItem('Token'),
                    'Content-Type': 'application/json'
                },
            }).success(function (data, status) {
                window.location.href = '../Mensaje/Index?Permiso=' + $scope.Permiso;
            }).error(function (error, status) {
            });

            debugger;
        }
    }

    $scope.AgregarLenguaje = function () {
        $scope.mendetalle.push({ 'MEDTipoLenguaje': '', 'Descripcion': '' });
    }

    $scope.ValidarEliminarLenguaje = function (index) {
        if ($scope.mendetalle.length > 1) {
            $scope.Action = "DeleteLanguaje";
            $scope.IndexLenguaje = index;
            messageBox.MostrarSiNo($scope.translation.XEliminar, $scope.translation.P0001);//Validar si se deja ese mensaje o se cambia por "¿Está seguro de eliminar la descripción?"
        }
        else {
            messageBox.Mostrar($scope.translation.XEliminar, $scope.translation.E0968);
        }
    }

    $scope.EliminarLenguaje = function (index) {
        if ($scope.mendetalle.length > 1) {
            $scope.mendetalle.splice(index, 1);
        }
    }

    $scope.EditarMensaje = function (MENClave, Permiso, SoloLectura) {
        $scope.Permiso = Permiso;
        if (SoloLectura.toUpperCase() == "TRUE") {
            $scope.SoloLectura = true;
        }
        else {
            $scope.SoloLectura = false;
        }
        
        if (MENClave != "") {
            $http({
                url: url + '/api/Mensaje/ObtenerMensaje?MENClave=' + MENClave,
                method: 'GET',
                headers: {
                    Authorization: window.sessionStorage.getItem('Token'),
                    'Content-Type': 'application/json'
                },
            }).success(function (data, status) {
                if (data != null) {
                    $scope.MENClave = data.MENClave;
                    $scope.TipoAplicacion = data.TipoAplicacion;
                    $scope.TipoMensaje = data.TipoMensaje;
                    $scope.TipoProyecto = data.TipoProyecto;
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
        }              
    }

    $scope.ValidarEliminarMensaje = function (mensaje) {
        $scope.Action = "Delete";
        $scope.MENClave = mensaje.MENClave;
        messageBox.MostrarSiNo($scope.translation.XEliminar, $scope.translation.P0001); //Validar si se cambia el mensaje por "¿Esta seguró de eliminar el mensaje ' + mensaje.MENClave + '?");
    }

    $scope.ValidarCancelar = function () {
        if (!$scope.form.$pristine) {
            $scope.Action = "Cancel";
            messageBox.MostrarSiNo($scope.translation.XCancelar, $scope.translation.BP0002);
        }
        else {
            window.location.href = '../Mensaje/Index?Permiso=' + $scope.Permiso;
        }
    }

    $scope.AceptarYesNoMsgBox = function () {
        messageBox.Cerrar();
        if ($scope.Action == "Delete") {
            $http({
                url: url + '/api/Mensaje/Eliminar?MENClave=' + $scope.MENClave,
                method: 'GET',
                headers: {
                    Authorization: window.sessionStorage.getItem('Token'),
                    'Content-Type': 'application/json'
                },
            }).success(function (data, status) {
                window.location.href = '../Mensaje/Index?Permiso=' + $scope.Permiso;
            }).error(function (error, status) {
            });
        }
        else if ($scope.Action == "DeleteLanguaje") {
            $scope.EliminarLenguaje($scope.IndexLenguaje);
        }
        else if ($scope.Action == "Cancel") {
            window.location.href = '../Mensaje/Index?Permiso=' + $scope.Permiso;
        }       
    }

    $scope.GenerarDiccionario = function() {
        $http({
            url: url + '/api/Mensaje/GenerarDiccionario',
            method: 'GET',
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-Type': 'application/json'
            },
        }).success(function (data, status) {
            if (data)
                messageBox.Mostrar($scope.translation.BTDiccionario, $scope.translation.I0310);
            else
                messageBox.Mostrar($scope.translation.BTDiccionario, $scope.translation.E0969);
            
        }).error(function (error, status) {
            messageBox.Mostrar($scope.translation.BTDiccionario, $scope.translation.E0969);
        });
    }

    //**Define las páginas que se utilizaran al mostrar los registros de Mensajes**//
    function tamano(tam) {
        var tamPag = 0;
        if (tam <= 100)
            tamPag = 20;
        else if (tam <= 1000 && tam > 100)
            tamPag = Math.floor(tam / 5);
        else if (tam <= 10000 && tam > 1000)
            tamPag = Math.floor(tam / 30);
        else if (tam <= 100000 && tam > 10000)
            tamPag = Math.floor(tam / 50);
        else if (tam <= 200000 && tam > 100000)
            tamPag = Math.floor(tam / 80);
        else if (tam <= 300000 && tam > 200000)
            tamPag = Math.floor(tam / 90);
        else if (tam <= 400000 && tam > 300000)
            tamPag = Math.floor(tam / 100);
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

app.directive('validarClaveUnica', validarClaveUnicaFunc)
app.directive('validarLenguaje', validarLenguajeFunc)

function validarClaveUnicaFunc($http, $q, $timeout) {
    return {
        restrict: 'A',
        require: 'ngModel',
        link: function($scope, element, attr, ngModel) {
            // fetch the call address from directives 'checkIfAvailable' attribute
            var validar = attr.validarClaveUnica;
      
            ngModel.$asyncValidators.claveRepetida = function (modelValue, viewValue) {
                var deferred = $q.defer();

                if ($scope.Action == 'Create') {
                    var clave = viewValue;
                    var url = window.sessionStorage.getItem('URL');

                    $http({
                        url: url + '/api/Mensaje/ValidarClaveUnica?MENClave=' + clave,
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

function validarLenguajeFunc($http, $q, $timeout) {
    return {
        restrict: 'A',
        require: 'ngModel',
        //scope: true,
        link: function ($scope, element, attr, ngModel) {
            // fetch the call address from directives 'checkIfAvailable' attribute
            var validar = attr.validarLenguaje;

            ngModel.$asyncValidators.lenguajeRepetido = function (modelValue, viewValue) {

                if (!$scope.$parent.form.$pristine) {
                    var clave = viewValue;
                    var deferred = $q.defer();
                    var detalles = $scope.$parent.mendetalle;              
                    console.log("valores: " + JSON.stringify(detalles));
                
                    var repetido = 0;
                    angular.forEach(detalles, function (value, key) {
                        console.log("valores: " + JSON.stringify(value));
                        if ($scope.det.$$hashKey != value.$$hashKey){
                            if (value.MEDTipoLenguaje == modelValue) {
                                console.log("valores: " + value.MEDTipoLenguaje);
                                repetido += 1;
                            }
                        }
                    }, this);

                    if (repetido > 0) {
                        deferred.reject();
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
}

