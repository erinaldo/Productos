<%@ page import="mx.elephantworks.iselling.Descuento" %>

<style>
.row{
	margin-bottom: .5em;
}
</style>
<script>
    $( function() {
        $("#vigenciaInicio").datepicker({
            dateFormat: "dd-mm-yy"
        });
        $("#vigenciaFin").datepicker({
            dateFormat: "dd-mm-yy"
        });
    });
</script>

<div class="row">
	<div class="col-md-6">
		<div class="form-group ${hasErrors(bean: descuentoInstance, field: 'codigo', 'error')} required">
			<label for="codigo">
				<g:message code="descuento.codigo.label" default="Codigo" />
				<span class="required-indicator">*</span>
			</label>
			<g:textField name="codigo" maxlength="50" required="" value="${descuentoInstance?.codigo}" class="form-control"/>
		</div>
	</div>
	<div class="col-md-6">
		<div class="form-group ${hasErrors(bean: descuentoInstance, field: 'porcentajeDescuento', 'error')} required">
			<label for="porcentajeDescuento">
				<g:message code="descuento.porcentajeDescuento.label" default="Porcentaje Descuento" />
				<span class="required-indicator">*</span>
			</label>
			<div class="input-group">
				<span class="input-group-addon">%</span>
				<g:textField name="porcentajeDescuento" value="${fieldValue(bean: descuentoInstance, field: 'porcentajeDescuento')}" required="" class="form-control" style="z-index: 0;"/>
			</div>
		</div>
	</div>
</div>


<div class="row">
	<div class="col-md-6">
		<div class="form-group ${hasErrors(bean: descuentoInstance, field: 'cantidad', 'error')} required">
			<label for="cantidad">
				<g:message code="descuento.cantidad.label" default="Cantidad" />
				<span class="required-indicator">*</span>
			</label>
			<g:textField name="cantidad" value="${fieldValue(bean: descuentoInstance, field: 'cantidad')}" required="" class="form-control"/>
		</div>
	</div>
	<div class="col-md-6">
		<div class="form-group ${hasErrors(bean: descuentoInstance, field: 'utilidades', 'error')} required">
			<label for="utilidades">
				<g:message code="descuento.utilidades.label" default="Utilidades" />
				<span class="required-indicator">*</span>
			</label>
			<g:textField name="utilidades" value="${fieldValue(bean: descuentoInstance, field: 'utilidades')}" required="" class="form-control"/>
		</div>
	</div>
</div>


<div class="row">
	<div class="col-md-6">
		<div class="form-group ${hasErrors(bean: descuentoInstance, field: 'vigenciaInicio', 'error')} required">
			<label for="vigenciaInicio">
				<g:message code="descuento.vigenciaInicio.label" default="Vigencia Inicio" />
				<span class="required-indicator">*</span>
			</label>
			<g:textField id="vigenciaInicio" name="vigenciaInicio" required="" value="${formatDate(format:'dd-mm-yyyy',date:descuentoInstance?.vigenciaInicio)}" class="form-control"  />
		</div>
	</div>
	<div class="col-md-6">
		<div class="form-group ${hasErrors(bean: descuentoInstance, field: 'vigenciaFin', 'error')} required">
			<label for="vigenciaFin">
				<g:message code="descuento.vigenciaFin.label" default="Vigencia Fin" />
				<span class="required-indicator">*</span>
			</label>
			<g:textField id="vigenciaFin" name="vigenciaFin" required=""  value="${formatDate(format:'dd-mm-yyyy',date:descuentoInstance?.vigenciaFin)}"  class="form-control" />
		</div>
	</div>

</div>
