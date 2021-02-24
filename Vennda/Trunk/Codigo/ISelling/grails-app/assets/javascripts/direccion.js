//= require jquery

function cargarEntidades(data,textStatus){
    if (data) {

        var datos = data.toString().replace("[","").replace("]","");
        var lista = datos.toString().split(",");
        console.log(lista);
        var rselect = document.getElementById('entidad')

        // limpiar combo estados
        $("#entidad").find('option').remove();
        $("#entidad").append('<option value = "0" selected>Selecciona...</option>')
        $("#entidad").val('0').trigger("change");

        //limpiar combo ciudades
        $("#ciudad").find('option').remove();
        $("#ciudad").append('<option value = "0" selected>Selecciona...</option>')
        $("#ciudad").val('0').trigger("change");

        for (var i=0; i < lista.length; i++){
            var estados = lista[i].toString().split(".");
            var id = estados[0].toString().replace("'","");
            var nombre = estados[1].toString().replace("'","");
            var opt = document.createElement('option');
            opt.text = nombre;
            opt.value = id;
            try {
                rselect.add(opt, null); // standards compliant; doesn't work in IE
            }
            catch(ex) {
                rselect.add(opt); // IE only
            }
        }
    }
}

function cargarCiudades(data,textStatus){

    if (data) {

        var datos = data.toString().replace("[","").replace("]","");
        var lista = datos.toString().split(",");

        var rselect = document.getElementById('ciudad')

        // limpiar combo ciudades
        $("#ciudad").find('option').remove();
        $("#ciudad").append('<option value = "0" selected>Selecciona...</option>')
        $("#ciudad").val('0').trigger("change");

        $("#ciudad option[value=0]").attr("selected",true);

        for (var i=0; i < lista.length; i++){
            var estados = lista[i].toString().split(".");
            var id = estados[0].toString().replace("'","");
            var nombre = estados[1].toString().replace("'","");
            var opt = document.createElement('option');
            opt.text = nombre;
            opt.value = id;
            try {
                rselect.add(opt, null); // standards compliant; doesn't work in IE
            }
            catch(ex) {
                rselect.add(opt); // IE only
            }
        }
    }
}


