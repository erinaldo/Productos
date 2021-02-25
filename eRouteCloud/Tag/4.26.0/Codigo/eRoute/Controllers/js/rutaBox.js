var app = angular.module('rutaBox', []);

app.factory('rutaBox', ["$http", function ($http) {

    return {
        'Mostrar': function (titulo, mensaje) {
            $("#lblMsgTitulo").text(titulo);
            $("#lblMsgMensaje").text(mensaje);
          
      //      console.log("Mensaje:" + mensaje);
           // $('#lblMsgMensaje').html("<span>ddfsg</span>");
         //   $('#lblMsgMensaje').html("<span>ddfsg</span>");
            $("#RutaBox").modal('show');

        },
        'Cerrar': function () {
            $("#RutaBox").modal('hide');
            //AceptarYesNoMsgBox();
        }
    }
}]);