var app = angular.module('centroBox', []);

app.factory('centroBox', ["$http", function ($http) {

    return {
        'Mostrar': function (titulo, mensaje) {
       //     $("#lblMsgTitulo").text(titulo);
         //   $("#lblMsgMensaje").text(mensaje);
          
      //      console.log("Mensaje:" + mensaje);
           // $('#lblMsgMensaje').html("<span>ddfsg</span>");
            $("#CentroBox").modal('show');

        },
        'Cerrar': function () {
            $("#CentroBox").modal('hide');
            //AceptarYesNoMsgBox();
        }
    }
}]);