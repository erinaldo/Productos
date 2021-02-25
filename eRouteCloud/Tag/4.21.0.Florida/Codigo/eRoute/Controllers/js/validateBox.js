var app = angular.module('validateBox', []);

app.factory('validateBox', ["$http", function ($http) {

    return {
        'MostrarSiNo': function (titulo, mensaje) {
            $("#lblYNMsgTitulo").text(titulo);
            $("#lblYNMsgMensaje").text(mensaje);
            $("#ValidateBox").modal('show');
        },
        'Mostrar': function (titulo, mensaje) {
            $("#lblMsgTitulo").text(titulo);
            $("#lblMsgMensaje").text(mensaje);
            $("#CentroBox").modal('show');

        },
        'Cerrar': function () {
            $("#ValidateBox").modal('hide');
            //AceptarYesNoMsgBox();
        }
    }
}]);