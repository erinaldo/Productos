
<%@ page import="mx.elephantworks.iselling.Plan" %>
<!DOCTYPE html>
<html>
	<head>
		<meta name="layout" content="main">
		<g:set var="entityName" value="${message(code: 'plan.label', default: 'Plan')}" />
		<title><g:message code="default.show.label" args="[entityName]" /></title>
	</head>
	<body>
		<a href="#show-plan" class="skip" tabindex="-1"><g:message code="default.link.skip.label" default="Skip to content&hellip;"/></a>
		<div class="nav" role="navigation">
			<ul>
				<li><a class="home" href="${createLink(uri: '/')}"><g:message code="default.home.label"/></a></li>
				<li><g:link class="list" action="index"><g:message code="default.list.label" args="[entityName]" /></g:link></li>
				<li><g:link class="create" action="create"><g:message code="default.new.label" args="[entityName]" /></g:link></li>
			</ul>
		</div>
		<div id="show-plan" class="content scaffold-show" role="main">
			<h1><g:message code="default.show.label" args="[entityName]" /></h1>
			<g:if test="${flash.message}">
			<div class="message" role="status">${flash.message}</div>
			</g:if>
			<ol class="property-list plan">
			
				<g:if test="${planInstance?.identificador}">
				<li class="fieldcontain">
					<span id="identificador-label" class="property-label"><g:message code="plan.identificador.label" default="Identificador" /></span>
					
						<span class="property-value" aria-labelledby="identificador-label"><g:fieldValue bean="${planInstance}" field="identificador"/></span>
					
				</li>
				</g:if>
			
				<g:if test="${planInstance?.fechaInicio}">
				<li class="fieldcontain">
					<span id="fechaInicio-label" class="property-label"><g:message code="plan.fechaInicio.label" default="Fecha Inicio" /></span>
					
						<span class="property-value" aria-labelledby="fechaInicio-label"><g:formatDate date="${planInstance?.fechaInicio}" /></span>
					
				</li>
				</g:if>
			
				<g:if test="${planInstance?.fechaFin}">
				<li class="fieldcontain">
					<span id="fechaFin-label" class="property-label"><g:message code="plan.fechaFin.label" default="Fecha Fin" /></span>
					
						<span class="property-value" aria-labelledby="fechaFin-label"><g:formatDate date="${planInstance?.fechaFin}" /></span>
					
				</li>
				</g:if>
			
				<g:if test="${planInstance?.precio}">
				<li class="fieldcontain">
					<span id="precio-label" class="property-label"><g:message code="plan.precio.label" default="Precio" /></span>
					
						<span class="property-value" aria-labelledby="precio-label"><g:fieldValue bean="${planInstance}" field="precio"/></span>
					
				</li>
				</g:if>
			
				<g:if test="${planInstance?.cobroTarjeta}">
				<li class="fieldcontain">
					<span id="cobroTarjeta-label" class="property-label"><g:message code="plan.cobroTarjeta.label" default="Cobro Tarjeta" /></span>
					
						<span class="property-value" aria-labelledby="cobroTarjeta-label"><g:formatBoolean boolean="${planInstance?.cobroTarjeta}" /></span>
					
				</li>
				</g:if>
			
				<g:if test="${planInstance?.impresionTicket}">
				<li class="fieldcontain">
					<span id="impresionTicket-label" class="property-label"><g:message code="plan.impresionTicket.label" default="Impresion Ticket" /></span>
					
						<span class="property-value" aria-labelledby="impresionTicket-label"><g:formatBoolean boolean="${planInstance?.impresionTicket}" /></span>
					
				</li>
				</g:if>
			
				<g:if test="${planInstance?.inventario}">
				<li class="fieldcontain">
					<span id="inventario-label" class="property-label"><g:message code="plan.inventario.label" default="Inventario" /></span>
					
						<span class="property-value" aria-labelledby="inventario-label"><g:formatBoolean boolean="${planInstance?.inventario}" /></span>
					
				</li>
				</g:if>
			
				<g:if test="${planInstance?.autoFactura}">
				<li class="fieldcontain">
					<span id="autoFactura-label" class="property-label"><g:message code="plan.autoFactura.label" default="Auto Factura" /></span>
					
						<span class="property-value" aria-labelledby="autoFactura-label"><g:formatBoolean boolean="${planInstance?.autoFactura}" /></span>
					
				</li>
				</g:if>
			
				<g:if test="${planInstance?.codigo}">
				<li class="fieldcontain">
					<span id="codigo-label" class="property-label"><g:message code="plan.codigo.label" default="Codigo" /></span>
					
						<g:each in="${planInstance.codigo}" var="c">
						<span class="property-value" aria-labelledby="codigo-label"><g:link controller="descuento" action="show" id="${c.id}">${c?.encodeAsHTML()}</g:link></span>
						</g:each>
					
				</li>
				</g:if>

			
			</ol>
			<g:form url="[resource:planInstance, action:'delete']" method="DELETE">
				<fieldset class="buttons">
					<g:link class="edit" action="edit" resource="${planInstance}"><g:message code="default.button.edit.label" default="Edit" /></g:link>
					<g:actionSubmit class="delete" action="delete" value="${message(code: 'default.button.delete.label', default: 'Delete')}" onclick="return confirm('${message(code: 'default.button.delete.confirm.message', default: 'Are you sure?')}');" />
				</fieldset>
			</g:form>
		</div>
	</body>
</html>
