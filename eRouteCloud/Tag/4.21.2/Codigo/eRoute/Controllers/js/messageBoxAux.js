var app = angular.module('messageBoxAux', []);

app.factory('messageBoxAux', ["$http", function ($http) {

    return {
        'MostrarSiNo': function () {
          
            $("#YesNoMsgBoxAux").modal('show');           
        },
        'Mostrar': function ()
        {
            
            $("#MsgBoxAux").modal('show');
            
        },
        'Cerrar': function ()
        {
            $("#YesNoMsgBoxAux").modal('hide');
            //AceptarYesNoMsgBox();
        }
    }
}]);
