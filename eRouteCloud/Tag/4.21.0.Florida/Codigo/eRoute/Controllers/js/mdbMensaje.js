var app = angular.module('mdbMensaje', ['valorReferencia', 'messageBox', 'ngResource', 'translation']);

app.controller("mdbMensajeCtrl", ["$scope", "$http", "valorReferencia", "messageBox", "translationService", function ($scope, $http, valorReferencia, messageBox, translationService) {

    var ctrl = this;
    var url = window.sessionStorage.getItem('URL');
    ObtenerValores();
    translationService.getTranslation($scope); //agregar en todos los controllers de las actividades para que se llenen las etiquetas con los mensajes
    
    $scope.AsignarPermisos = function(Permiso) {
        $scope.Permiso = Permiso;
    }

    function ObtenerValores() {             
        valorReferencia.obtenerValores('MDBMENT', function (result) {
            $scope.mdbment = result;
        });
        valorReferencia.obtenerValores('EDOREG', function (result) {
            $scope.edoreg = result;
        });
    }

    $scope.IniciarMDBMensaje = function (scopePadre) {
        var idMsg = "";
        $scope.scopePadre = scopePadre;
        $http({            
            url: url + '/api/MDBMensaje/ObtenerModuloMensaje?MDBMensajeID=' + idMsg,
            method: 'GET',
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-Type': 'application/json'
            },
        }).success(function (data, status) {

            $scope.MDBMensajeID = ""
            $scope.MDBMensajeTipo = "";
            $scope.TipoEstado = "1";
            $scope.Numero = "";
            $scope.Asunto = "";
            $scope.Descripcion = "";
            $scope.ModuloMensaje = data;

        }).error(function (error, status) {
        });
    }

    $scope.ObtenerSiguienteNumero = function () {
        $http({
            url: url + '/api/MDBMensaje/ObtenerSiguienteNumero?MDBMensajeTipo=' + $scope.MDBMensajeTipo,
            method: 'GET',
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-Type': 'application/json'
            },
        }).success(function (data, status) {

            $scope.Numero = data;

        }).error(function (error, status) {
        });
    }

    $scope.FiltroClientes = ['2', '3'];

    $scope.FiltroMDBTipoMensaje = function (Valor) {
        return ($scope.FiltroClientes.indexOf(Valor.VAVClave) != -1);
    };

    $scope.GuardarMDBMensaje = function () {
        if (!$scope.subForm.$valid) {
            $scope.subForm.submitted = true;
        }
        else {
            var mdbMensaje = {
                MDBMensajeID: "",
                MDBMensajeTipo: $scope.MDBMensajeTipo,
                Numero: $scope.Numero,
                Asunto: $scope.Asunto,
                Descripcion: $scope.Descripcion,
                TipoEstado: $scope.TipoEstado,
                MUsuarioId: window.sessionStorage.getItem('USUId'),
                ModuloMensaje: $scope.ModuloMensaje
            };

            $http({
                url: url + '/api/MDBMensaje/Grabar?msg=' + mdbMensaje,
                method: 'post',

                data: JSON.stringify(mdbMensaje),
                dataType: "json",
                headers: {
                    Authorization: window.sessionStorage.getItem('Token'),
                    'Content-Type': 'application/json'
                },
            }).success(function (data, status) {
                if (data != "")
                    $scope.scopePadre.AgregarMDBMensajeNuevo(data);
            }).error(function (error, status) {
            });

            debugger;
        }
    }

    $scope.ObtenerMDBMensajesCliente = function (scopePadre) {
        $scope.scopePadre = scopePadre;
        $http({
            url: url + '/api/MDBMensaje/ObtenerMDBMensajesCliente',
            method: 'GET',
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-Type': 'application/json'
            }
        }).success(function (data, status) {
            $scope.mdbMensajes = data;
        }).error(function (error, status) {

        });
    }

    $scope.AgregarMDBMensajes = function () {
        var seleccionados = [];
        angular.forEach($scope.mdbMensajes, function (v, k) {
            if (v.Seleccionado) {
                seleccionados.push({
                    'MDBMensajeID': v.MDBMensajeID,
                    'Numero': v.Numero,
                    'Asunto': v.Asunto,
                    'TipoMensaje': v.TipoMensaje,
                    'Descripcion': v.Descripcion,
                    'TipoEstado': v.TipoEstado,
                    'Modulos': v.Modulos
                });
            }
        });
        if (seleccionados.length > 0)
            $scope.scopePadre.AgregarMDBMensajes(seleccionados);
    }
    
}])