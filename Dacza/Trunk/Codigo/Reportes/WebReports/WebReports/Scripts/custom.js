$(function () {
    $('#dtpFecha').datetimepicker({
        dayViewHeaderFormat: 'MMMM YYYY',
        format: 'DD/MM/YYYY',
        showTodayButton: true,
        useCurrent: true
    });
});

$(function () {
    $('#dtpFechaIni').datetimepicker({
        dayViewHeaderFormat: 'MMMM YYYY',
        format: 'DD/MM/YYYY',
        showTodayButton: true,
        useCurrent: true
    });
    $('#dtpFechaFin').datetimepicker({
        dayViewHeaderFormat: 'MMMM YYYY',
        format: 'DD/MM/YYYY',
        showTodayButton: true,
        useCurrent: true
    });
    $("#dtpFechaIni").on("dp.change", function (e) {
        $('#dtpFechaFin').data("DateTimePicker").minDate(e.date);
    });
    $("#dtpFechaFin").on("dp.change", function (e) {
        $('#dtpFechaIni').data("DateTimePicker").maxDate(e.date);
    });
    
});

function CargarTalleres() {
    var sucursalId = $('#ddlSucursal').find(":selected").val();
    if (sucursalId != null) {
        if (sucursalId.length > 0) {
            $.getJSON('ObtenerTalleres', { sucursalId: sucursalId }, function (data) {
                $('#ddlTalleres option').remove();
                $('#ddlTalleres').append('<option value="-999">Todos</option');
                for (i = 0; i < data.length; i++) {
                    $('#ddlTalleres').append('<option value="' +
                            data[i].TallerId + '">' + data[i].Descripcion + '</option');
                }
            });
        }
    } else {
        $('#ddlTalleres option').remove();
        $('#ddlTalleres').append('<option value=""></option');
    }
}

$(function () {
    $('input[name=Seleccion]:radio').change(function (event) {
        event.preventDefault();
        if ($('#rbtTaller').is(":checked")) {
            $('#ddlTalleres').prop('disabled', false);
        }
        else {
            $('#ddlTalleres').prop('disabled', 'disabled');
        }
        if ($('#rbtVin').is(":checked")) {
            $('#txtVin').prop('disabled', false);
        }
        else {
            $('#txtVin').prop('disabled', 'disabled');
        }
        if ($('#rbtParte').is(":checked")) {
            $('#txtParte').prop('disabled', false);
        }
        else {
            $('#txtParte').prop('disabled', 'disabled');
        }
    });
});

function MostrarImagen(detalleId) {
    $.getJSON('ObtenerImagen', { detalleId: detalleId }, function (data) {
        if (data) {
            var newSrc = "data:image/jpg;base64," + data.imagen;
            $('#RECDetalleImg').attr("src", newSrc);
            $("#myModalLabel").text(data.titulo);

        } else {
            alert('Sorry, there is some error.');
        }
    });
}

function CargarAlmacenes(almacenId) {
    var sucursalId = $('#ddlSucursal').find(":selected").val();
    if (sucursalId != null) {
        if (sucursalId.length > 0) {
            $.getJSON('ObtenerAlmacenes', { sucursalId: sucursalId }, function (data) {
                $('#ddlAlmacenes option').remove();                
                for (i = 0; i < data.length; i++) {
                    $('#ddlAlmacenes').append('<option value="' +
                            data[i].AlmacenId + '">' + data[i].Descripcion + '</option');                    
                }
                if (almacenId != '')
                {
                    $('#ddlAlmacenes').val(almacenId);
                }
            });
        }
    } else {
        $('#ddlAlmacenes option').remove();
        $('#ddlAlmacenes').append('<option value=""></option');
    }
}



    function SeleccionarAgente() {
        $.getJSON('ObtenerAgentes', null, function (data) {
            $('#ddlAgentes option').remove();
            for (i = 0; i < data.length; i++) {
                $('#ddlAgentes').append('<option value="' +
                        data[i].UsuarioId + '">' + data[i].Clave + ' - ' + data[i].Nombre + '</option');
            }
        });
    }

    function AgregarAgente() {
        var usuarioId = $('#ddlAgentes').find(":selected").val();
        if (usuarioId != null) {
            var html = '';
            $.getJSON('ObtenerAgente', { usuarioId: usuarioId }, function (data) {
                if (data) {
                    var Usuario = data[0];
                    html += '<tr>';                 
                    html += '<td class="width-30">' + Usuario.Clave + '</td>'
                    html += '<td class="width-60">' + Usuario.Nombre + '</td>'
                    html += '<td class="width-10">' + Usuario.Comando + '</td>'
                    html += '</tr>';
                
                    $('#tblAgenteDetalle tr:last').after(html);
                }
            });
        }
    }

    function CambiarFase(recargaId) {
        var label = document.getElementById('recargaIdActual');
        label.innerText = recargaId;    
    }

    function ActualizarFase() {
        var label = document.getElementById('recargaIdActual');
        var recargaId = label.innerText;
        var fase = $('#ddlFase').find(":selected").val();
        var html = '';
        if (fase == 0)
            html = 'Fase: Cancelada';
        if (fase == 3)
            html = 'Fase: Surtida';

        $.getJSON('ActualizarFase', { recargaId: recargaId, fase: fase }, function (data) {
            if (data) {
            
            }
        });   
    
        var th = document.getElementById('th' + recargaId);
        th.innerHTML = html;
    }

    function CambiarFaseOrden(ordenId) {
        var label = document.getElementById('ordenIdActual');
        label.innerText = ordenId;
    }

    function ActualizarFaseOrden() {
        var label = document.getElementById('ordenIdActual');
        var ordenId = label.innerText;
        var fase = $('#ddlFase').find(":selected").val();
        var html = '';
        if (fase == 0)
            html = 'Fase: Cancelada';
        
        $.getJSON('ActualizarFaseOrden', { ordenId: ordenId, fase: fase }, function (data) {
            if (data) {

            }
        });

        var th = document.getElementById('th' + ordenId);
        th.innerHTML = html;
    }