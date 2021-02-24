<style>
.row{
	margin-bottom: .5em;
}
</style>

<div class="row">
    <div class="col-md-12">

            <label for="cantidad">
                <g:message code="inventario.cantidadActual.label" default="Cantidad Actual" />
                <span class="required-indicator">*</span>
            </label>
            <g:field class="form-control" id="cantidadActual" name="cantidadActual" type="number" value="${inventarioInstance.cantidad}" required="" disabled=""/>

    </div>
</div>

<div class="row">
    <div class="col-md-12">

            <label for="cantidad">
                <g:message code="inventario.cantidadAgregar.label" default="Cantidad Agregar (+) / Restar (-)" />
                <span class="required-indicator">*</span>
            </label>
            <g:field class="form-control" id="cantidadAgregar" name="cantidadAgregar" type="number" value="" required="" />

    </div>
</div>

<hr>

<div class="row">
    <div class="col-md-12">
        <div class="fieldcontain ${hasErrors(bean: inventarioInstance, field: 'cantidad', 'error')} required">
            <label for="cantidad">
                <g:message code="inventario.cantidadTotal.label" default="Cantidad Total" />
                <span class="required-indicator">*</span>
            </label>
            <g:field class="form-control" id="cantidad" name="cantidad" type="number" value="" required="" disabled="" />
        </div>
    </div>
</div>


<g:javascript>
    $( document ).ready(function() {
        $("#cantidadAgregar").focusout(function () {
            sumarCantidades();
        });
    });


    function sumarCantidades() {

        var cantidadActual = $("#cantidadActual").val();
        var cantidadAgregar =  $("#cantidadAgregar").val();
        cantidadAgregar = (cantidadAgregar == null || cantidadAgregar == undefined || cantidadAgregar == "") ? 0 : cantidadAgregar;

        var total = parseInt(cantidadActual) + parseInt(cantidadAgregar);
        $("#cantidad").val(total.toString());
    }
</g:javascript>