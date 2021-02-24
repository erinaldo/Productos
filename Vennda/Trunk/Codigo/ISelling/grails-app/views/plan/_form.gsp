<%@ page import="mx.elephantworks.iselling.Plan" %>
<style>
.row{
	margin-bottom: .5em;
}
thead{
	background-color: #1c94c4;
	text-align: center;

}
thead tr th{
	font-family: "Arial";
	font-size: 14px;
	color:#FFF;
	text-align: center;
}
tbody tr{
	background-color: #D8DFE5;
	font-family: "Arial";
	font-size: 12px;
	color:#000;
	text-align: center;
}
tbody tr td{
	border-bottom: 1px solid #9B9B9B;
}
</style>
<script>
    $( function() {
        $("#fechaInicio").datepicker({
                dateFormat: "dd-mm-yy"
            });
        $("#fechaFin").datepicker({
            dateFormat: "dd-mm-yy"
        });
    });
</script>


<div class="row">
	<div class="col-md-12">
		<div class="form-group ${hasErrors(bean: planInstance, field: 'identificador', 'error')} required">
			<label for="identificador">
				<g:message code="plan.identificador.label" default="Identificador" />
				<span class="required-indicator">*</span>
			</label>
			<g:textField name="identificador" maxlength="50" required="" value="${planInstance?.identificador}" class="form-control" autocomplete="false"/>
		</div>
	</div>
</div>

<div class="row">
	<div class="col-md-6">
		<div class="form-group ${hasErrors(bean: planInstance, field: 'fechaInicio', 'error')} required">
			<label for="fechaInicio">
				<g:message code="plan.fechaInicio.label" default="Fecha Inicio" />
				<span class="required-indicator">*</span>
			</label><br>
			<g:textField id="fechaInicio" name="fechaInicio" required="" value="${formatDate(format:'dd-mm-yyyy',date:planInstance?.fechaInicio)}" class="form-control" />
		</div>
	</div>
	<div class="col-md-6">
		<div class="form-group ${hasErrors(bean: planInstance, field: 'fechaFin', 'error')} required">
			<label for="fechaFin">
				<g:message code="plan.fechaFin.label" default="Fecha Fin" />
				<span class="required-indicator">*</span>
			</label><br>
			<g:textField id="fechaFin" name="fechaFin" required="" value="${formatDate(format:'dd-mm-yyyy',date:planInstance?.fechaFin)}" class="form-control" />
		</div>
	</div>
</div>

<div class="row">
	<div class="col-md-6">
		<label for="fechaInicio">
			<g:message code="plan.descrioción.label" default="Descripción" />
			<span class="required-indicator">*</span>
		</label><br>
		<g:textArea id="descripcion" name="descripcion" required="" value="${planInstance?.descripcion}" class="form-control" style="height: 100px; resize: none;" />
	</div>

	<div class="col-md-6">
		<label for="fechaInicio">
			<g:message code="plan.color.label" default="Color (Hexadecimal)" />
			<span class="required-indicator">*</span>
		</label><br>
		<g:textField id="color" name="color" required="" value="${planInstance?.color}" class="form-control" />
	</div>
</div>

<div class="row">
	<div class="col-md-12">
		<div class="input-group ${hasErrors(bean: planInstance, field: 'precio', 'error')} required">
			<label for="precio">
				<g:message code="plan.precio.label" default="Precio" />
				<span class="required-indicator">*</span>
			</label>
			<div class="input-group">
				<span class="input-group-addon">$</span>
				<g:textField name="precio" value="${fieldValue(bean: planInstance, field: 'precio')}" required="" class="form-control" onkeypress="return soloNumeros(event);" autocomplete="false" style="z-index: 0;"/>
				<span class="input-group-addon">.00</span>
			</div>
		</div>
	</div>
</div>



<div class="row" style="margin-right:0px;margin-left:0px">
	<div class="col-md-3">
		<div class="form-group ${hasErrors(bean: planInstance, field: 'cobroTarjeta', 'error')} ">
			<label for="cobroTarjeta">
				<g:message code="plan.cobroTarjeta.label" default="Cobro Tarjeta" />
			</label>
			<br>
			<label class="switch">
				<g:checkBox name="cobroTarjeta" value="${planInstance?.cobroTarjeta}" class="form-control" />
				<div class="slider round"></div>
			</label>
		</div>
	</div>
	<div class="col-md-3">
		<div class="form-group ${hasErrors(bean: planInstance, field: 'impresionTicket', 'error')} ">
			<label for="impresionTicket">
				<g:message code="plan.impresionTicket.label" default="Impresion Ticket" />
			</label>
			<br>
			<label class="switch">
				<g:checkBox name="impresionTicket" value="${planInstance?.impresionTicket}" class="form-control" />
				<div class="slider round"></div>
			</label>
		</div>
	</div>
	<div class="col-md-3">
		<div class="form-group ${hasErrors(bean: planInstance, field: 'inventario', 'error')} ">
			<label for="inventario">
				<g:message code="plan.inventario.label" default="Inventario" />
			</label>
			<br>
			<label class="switch">
				<g:checkBox name="inventario" value="${planInstance?.inventario}"  class="form-control"/>
				<div class="slider round"></div>
			</label>
		</div>
	</div>
	<div class="col-md-3">
		<div class="form-group ${hasErrors(bean: planInstance, field: 'autoFactura', 'error')} ">
			<label for="autoFactura">
				<g:message code="plan.autoFactura.label" default="Auto Factura" />
			</label>
			<br>
			<label class="switch">
				<g:checkBox name="autoFactura" value="${planInstance?.autoFactura}" class="form-control"/>
				<div class="slider round"></div>
			</label>
		</div>
	</div>
</div>

<g:if test="${editable}">

<div class="row" style="text-align: right">
	<div class="col-md-6 col-md-offset-6">
		<g:link action="crearDescuentos" id="${planInstance.id}" class="btn btn-primary color-vennda buttonImage">
			<image class="imageInButton" src="${resource(dir: "images", file: "anadirBlanco.png")}" style="width: 20px"></image>
			Código
		</g:link>
	</div>
</div>

<div class="table-responsive" style="margin-top: 3%">
	<div class="table table-hover" id="list-cliente" role="main">
		<table id="tablaDescuentos" class="table table-hover">
			<thead>
			<tr>

				<th>${message(code: 'descuento.codigo.label', default: 'Codigo')}</th>

				<th>${message(code: 'descuento.porcentajeDescuento.label', default: '% Descuento')}</th>

				<th>${message(code: 'descuento.cantidad.label', default: 'Cantidad')}</th>

				<th>${message(code: 'descuento.utilidades.label', default: 'Utilidades')}</th>

				<th>${message(code: 'descuento.vigenciaInicio.label', default: 'Inicio')}</th>

				<th>${message(code: 'descuento.vigenciaFin.label', default: 'Fin')}</th>

				<th>${message(code: 'default.edit.label', default: 'Editar', args: [""])}</th>

			</tr>
			</thead>
			<tbody>
			<g:each in="${planInstance.codigo}" status="i" var="descuentoInstance">
				<tr class="${(i % 2) == 0 ? 'even' : 'odd'}">

					<td>${fieldValue(bean: descuentoInstance, field: "codigo")}</td>

					<td>${fieldValue(bean: descuentoInstance, field: "porcentajeDescuento")}</td>

					<td>${fieldValue(bean: descuentoInstance, field: "cantidad")}</td>

					<td>${fieldValue(bean: descuentoInstance, field: "utilidades")}</td>

					<td>
						<g:formatDate format="dd-mm-yyyy" date="${descuentoInstance.vigenciaInicio}"/>
					</td>

					<td><g:formatDate format="dd-mm-yyyy" date="${descuentoInstance.vigenciaFin}" /></td>

					<td>
						<g:link action="editarDescuentos"  id="${planInstance.id}">
							<image class="imageInButton" src="${resource(dir: "images", file: "editar.png")}" width="30px"></image>
						</g:link>
					</td>
				</tr>
			</g:each>
			</tbody>
		</table>
		<g:javascript>

		$(document).ready(function () {
			var tablaPuntoVenta = $("#tablaDescuentos").dataTable({
			   "sPaginationType": "full_numbers",
				"iDisplayLengthChange": 10,
				"bLengthChange": false,
				"bStateSave": true,
				"language": {
			       "url": "${resource(dir: 'javascripts', file:'spanish.json')}"
				}
			});
		});

		</g:javascript>

</g:if>

