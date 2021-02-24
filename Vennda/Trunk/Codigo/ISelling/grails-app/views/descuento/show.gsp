
<%@ page import="mx.elephantworks.iselling.Descuento" %>
<!DOCTYPE html>
<html>
	<head>
		<meta name="layout" content="main">
		<g:set var="entityName" value="${message(code: 'descuento.label', default: 'Descuento')}" />
		<title><g:message code="default.show.label" args="[entityName]" /></title>
	</head>
	<body>
		<a href="#show-descuento" class="skip" tabindex="-1"><g:message code="default.link.skip.label" default="Skip to content&hellip;"/></a>
		<div class="nav" role="navigation">
			<ul>
				<li><a class="home" href="${createLink(uri: '/')}"><g:message code="default.home.label"/></a></li>
				<li><g:link class="list" action="index"><g:message code="default.list.label" args="[entityName]" /></g:link></li>
				<li><g:link class="create" action="create"><g:message code="default.new.label" args="[entityName]" /></g:link></li>
			</ul>
		</div>
		<div id="show-descuento" class="content scaffold-show" role="main">
			<h1><g:message code="default.show.label" args="[entityName]" /></h1>
			<g:if test="${flash.message}">
			<div class="message" role="status">${flash.message}</div>
			</g:if>
			<ol class="property-list descuento">
			
				<g:if test="${descuentoInstance?.codigo}">
				<li class="fieldcontain">
					<span id="codigo-label" class="property-label"><g:message code="descuento.codigo.label" default="Codigo" /></span>
					
						<span class="property-value" aria-labelledby="codigo-label"><g:fieldValue bean="${descuentoInstance}" field="codigo"/></span>
					
				</li>
				</g:if>
			
				<g:if test="${descuentoInstance?.porcentajeDescuento}">
				<li class="fieldcontain">
					<span id="porcentajeDescuento-label" class="property-label"><g:message code="descuento.porcentajeDescuento.label" default="Porcentaje Descuento" /></span>
					
						<span class="property-value" aria-labelledby="porcentajeDescuento-label"><g:fieldValue bean="${descuentoInstance}" field="porcentajeDescuento"/></span>
					
				</li>
				</g:if>
			
				<g:if test="${descuentoInstance?.cantidad}">
				<li class="fieldcontain">
					<span id="cantidad-label" class="property-label"><g:message code="descuento.cantidad.label" default="Cantidad" /></span>
					
						<span class="property-value" aria-labelledby="cantidad-label"><g:fieldValue bean="${descuentoInstance}" field="cantidad"/></span>
					
				</li>
				</g:if>
			
				<g:if test="${descuentoInstance?.utilidades}">
				<li class="fieldcontain">
					<span id="utilidades-label" class="property-label"><g:message code="descuento.utilidades.label" default="Utilidades" /></span>
					
						<span class="property-value" aria-labelledby="utilidades-label"><g:fieldValue bean="${descuentoInstance}" field="utilidades"/></span>
					
				</li>
				</g:if>
			
				<g:if test="${descuentoInstance?.vigenciaInicio}">
				<li class="fieldcontain">
					<span id="vigenciaInicio-label" class="property-label"><g:message code="descuento.vigenciaInicio.label" default="Vigencia Inicio" /></span>
					
						<span class="property-value" aria-labelledby="vigenciaInicio-label"><g:formatDate date="${descuentoInstance?.vigenciaInicio}" /></span>
					
				</li>
				</g:if>
			
				<g:if test="${descuentoInstance?.vigenciaFin}">
				<li class="fieldcontain">
					<span id="vigenciaFin-label" class="property-label"><g:message code="descuento.vigenciaFin.label" default="Vigencia Fin" /></span>
					
						<span class="property-value" aria-labelledby="vigenciaFin-label"><g:formatDate date="${descuentoInstance?.vigenciaFin}" /></span>
					
				</li>
				</g:if>
			
			</ol>
			<g:form url="[resource:descuentoInstance, action:'delete']" method="DELETE">
				<fieldset class="buttons">
					<g:link class="edit" action="edit" resource="${descuentoInstance}"><g:message code="default.button.edit.label" default="Edit" /></g:link>
					<g:actionSubmit class="delete" action="delete" value="${message(code: 'default.button.delete.label', default: 'Delete')}" onclick="return confirm('${message(code: 'default.button.delete.confirm.message', default: 'Are you sure?')}');" />
				</fieldset>
			</g:form>
		</div>
	</body>
</html>
