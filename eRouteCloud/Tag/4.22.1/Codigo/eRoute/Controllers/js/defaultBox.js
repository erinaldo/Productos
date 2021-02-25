var app = angular.module('defaultBox', []);

app.factory('defaultBox', ["$http", function ($http) {

    return {
        'Mostrar': function (titulo, mensaje, IdModal) {
            $("#lblMsgTitulo").text(titulo);
            $("#lblMsgMensaje").text(mensaje);
            $("#" + IdModal).modal('show');

        },
        'Cerrar': function (IdModal) {
            $("#" + IdModal).modal('hide');
            //AceptarYesNoMsgBox();
        }
    }
}]);