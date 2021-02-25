var app = angular.module('messageBox', []);

app.factory('messageBox', ["$http", function ($http) {

    return {
        'MostrarSiNo': function (titulo, mensaje) {
            $("#lblYNMsgTitulo").text(titulo);
            $("#lblYNMsgMensaje").text(mensaje);
            $("#YesNoMsgBox").modal('show');           
        },
        'Mostrar': function (titulo, mensaje)
        {
            $("#lblMsgTitulo").text(titulo);
            $("#lblMsgMensaje").text(mensaje);
            $("#MsgBox").modal('show');
            
        },
        'Cerrar': function ()
        {
            $("#YesNoMsgBox").modal('hide');
            //AceptarYesNoMsgBox();
        }
    }
}]);

app.factory('centroBox', ["$http", function ($http) {

    return {
        'Mostrar': function (titulo, mensaje) {
            $("#lblMsgTitulo").text(titulo);
            $("#lblMsgMensaje").text(mensaje);
            $("#CentroBox").modal('show');

        },
        'Cerrar': function () {
            $("#CentroBox").modal('hide');
            //AceptarYesNoMsgBox();
        }
    }
}]);