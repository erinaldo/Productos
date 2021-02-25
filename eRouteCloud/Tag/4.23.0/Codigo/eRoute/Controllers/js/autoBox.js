var app = angular.module('autoBox', []);

app.factory('autoBox', ["$http", function ($http) {

    return {
        'Mostrar': function (titulo, mensaje) {
            $("#lblMsgTitulo").text(titulo);
            $("#lblMsgMensaje").text(mensaje);
            $("#AutoBox").modal('show');

        },
        'Cerrar': function () {
            $("#AutoBox").modal('hide');
            //AceptarYesNoMsgBox();
        }
    }
}]);