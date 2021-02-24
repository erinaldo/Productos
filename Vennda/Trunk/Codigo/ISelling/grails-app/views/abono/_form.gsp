<%@ page import="mx.elephantworks.iselling.Abono" %>

<style>
.row{
	margin-bottom: .5em;
}
</style>

<g:hiddenField name="cobranza" value="${cobranzaInstance.id}"/>

<div class="row">
	<div class="col-md-12">
		<div class="form-group ${hasErrors(bean: abonoInstance, field: 'metodoPago', 'error')} required">
			<label for="metodoPago">
				<g:message code="cobranza.folio.label" default="Folio" />
			</label>
			<g:textField  name="folio" value="${cobranzaInstance.folio}" class="form-control" readonly="true"/>
		</div>
	</div>
</div>

<div class="row">
	<div class="col-md-12">
		<div class="form-group ${hasErrors(bean: abonoInstance, field: 'metodoPago', 'error')} required">
			<label for="metodoPago">
				<g:message code="cobranza.saldo.label" default="Saldo" />
			</label>
			<g:textField id="saldo" name="saldo" value="${cobranzaInstance.saldo}" class="form-control" readonly="true"/>

		</div>
	</div>
</div>


<div class="row">
	<div class="col-md-12">
		<div class="form-group ${hasErrors(bean: abonoInstance, field: 'metodoPago', 'error')} required">
			<label for="metodoPago">
				<g:message code="abono.metodoPago.label" default="Metodo Pago" />
				<span class="required-indicator">*</span>
			</label>
			<%--<g:select type="number" name='metodoPago' value="${abonoInstance.metodoPago}" required="" class="form-control"
					  from="${['Efectivo', 'Cheque', 'T.Credito','T.Debito','Transferencia']}"
					  ></g:select>--%>
			    <g:select name="metodoPago" value="${abonoInstance.metodoPago}" required="" class="form-control"
					  from="${mx.elephantworks.iselling.ValoresReferencia.findAllByClave('MPAGO')}" optionValue="descripcion" optionKey="valor"	/>
		</div>
	</div>
</div>

<div class="row">
	<div class="col-md-12">
		<div class="form-group ${hasErrors(bean: abonoInstance, field: 'referencia', 'error')}">
			<label for="referencia">
				<g:message code="abono.referencia.label" default="Referencia" />
			</label>
			<g:textField name="referencia" value="${abonoInstance?.referencia}" class="form-control"/>
		</div>
	</div>
</div>

<div class="row">
	<div class="col-md-12">
		<div class="form-group ${hasErrors(bean: abonoInstance, field: 'monto', 'error')} required">
			<label for="monto">
				<g:message code="abono.monto.label" default="Monto" />
				<span class="required-indicator">*</span>
			</label>
			<g:textField id="monto" name="monto" value="${fieldValue(bean: abonoInstance, field: 'monto')}" required="" class="form-control" onkeypress="return soloNumerosPunto(event);"/>
		</div>
	</div>
</div>

