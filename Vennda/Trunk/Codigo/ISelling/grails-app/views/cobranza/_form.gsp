<%@ page import="mx.elephantworks.iselling.Cobranza" %>



<div class="fieldcontain ${hasErrors(bean: cobranzaInstance, field: 'folio', 'error')} required">
	<label for="folio">
		<g:message code="cobranza.folio.label" default="Folio" />
		<span class="required-indicator">*</span>
	</label>
	<g:textField name="folio" maxlength="15" required="" value="${cobranzaInstance?.folio}"/>

</div>

<div class="fieldcontain ${hasErrors(bean: cobranzaInstance, field: 'fecha', 'error')} required">
	<label for="fecha">
		<g:message code="cobranza.fecha.label" default="Fecha" />
		<span class="required-indicator">*</span>
	</label>
	<g:datePicker name="fecha" precision="day"  value="${cobranzaInstance?.fecha}"  />

</div>

<div class="fieldcontain ${hasErrors(bean: cobranzaInstance, field: 'importe', 'error')} required">
	<label for="importe">
		<g:message code="cobranza.importe.label" default="Importe" />
		<span class="required-indicator">*</span>
	</label>
	<g:field name="importe" value="${fieldValue(bean: cobranzaInstance, field: 'importe')}" required=""/>

</div>

<div class="fieldcontain ${hasErrors(bean: cobranzaInstance, field: 'saldo', 'error')} required">
	<label for="saldo">
		<g:message code="cobranza.saldo.label" default="Saldo" />
		<span class="required-indicator">*</span>
	</label>
	<g:field name="saldo" value="${fieldValue(bean: cobranzaInstance, field: 'saldo')}" required=""/>

</div>

