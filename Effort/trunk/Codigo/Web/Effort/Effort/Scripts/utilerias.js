function SoloNumerosDecimales(e, valInicial, nEntero, nDecimal)
{
    var obj = e.srcElement || e.target;
    var tecla_codigo = (document.all) ? e.keyCode : e.which;
    var tecla_valor = String.fromCharCode(tecla_codigo);
    var patron2 = /[\d,]/;
    var control = (tecla_codigo === 46 && (/[,]/).test(obj.value)) ? false : true;
    var existePto = (/[,]/).test(obj.value);

    //el tab
    if (tecla_codigo === 8)
        return true;

    if (valInicial !== obj.value) {
        var TControl = obj.value.length;
        if (existePto === false && tecla_codigo !== 46) {
            if (TControl === nEntero) {
                obj.value = obj.value + ",";
            }
        }

        if (existePto === true) {
            var subVal = obj.value.substring(obj.value.indexOf(",") + 1, obj.value.length);

            if (subVal.length > 1) {
                return false;
            }
        }

        return patron2.test(tecla_valor) && control;
    }
    else {
        if (valInicial === obj.value) {
            obj.value = '';
        }
        return patron2.test(tecla_valor) && control;
    }
}

function soloNumeros(e)
{
    var key = window.Event ? e.which : e.keyCode
    return (key >= 48 && key <= 57)
}

function soloTexto(e)
{
    //32 - 65
    if ((e.keyCode != 32) && (e.keyCode < 48) || (e.keyCode > 57) && (e.keyCode < 65) || (e.keyCode > 90) && (e.keyCode < 97) || (e.keyCode > 122))
        e.returnValue = false;
}