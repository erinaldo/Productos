
<%@ page import="mx.elephantworks.iselling.PuntoVenta" %>
<!DOCTYPE html>
<html>
	<head>
		<meta name="layout" content="main">
		<g:set var="entityName" value="${message(code: 'puntoVenta.label', default: 'PuntoVenta')}" />
		<title><g:message code="default.show.label" args="[entityName]" /></title>
	</head>
	<body>
		<a href="#show-puntoVenta" class="skip" tabindex="-1"><g:message code="default.link.skip.label" default="Skip to content&hellip;"/></a>
		<div class="nav" role="navigation">
			<ul>
				<li><a class="home" href="${createLink(uri: '/')}"><g:message code="default.home.label"/></a></li>
				<li><g:link class="list" action="index"><g:message code="default.list.label" args="[entityName]" /></g:link></li>
				<li><g:link class="create" action="create"><g:message code="default.new.label" args="[entityName]" /></g:link></li>
			</ul>
		</div>
		<div id="show-puntoVenta" class="content scaffold-show" role="main">
			<h1><g:message code="default.show.label" args="[entityName]" /></h1>
			<g:if test="${flash.message}">
			<div class="message" role="status">${flash.message}</div>
			</g:if>
			<ol class="property-list puntoVenta">
			
				<g:if test="${puntoVentaInstance?.numeroNegocio}">
				<li class="fieldcontain">
					<span id="numeroNegocio-label" class="property-label"><g:message code="puntoVenta.numeroNegocio.label" default="Numero Negocio" /></span>
					
						<span class="property-value" aria-labelledby="numeroNegocio-label"><g:fieldValue bean="${puntoVentaInstance}" field="numeroNegocio"/></span>
					
				</li>
				</g:if>
			
				<g:if test="${puntoVentaInstance?.nombreNegocio}">
				<li class="fieldcontain">
					<span id="nombreNegocio-label" class="property-label"><g:message code="puntoVenta.nombreNegocio.label" default="Nombre Negocio" /></span>
					
						<span class="property-value" aria-labelledby="nombreNegocio-label"><g:fieldValue bean="${puntoVentaInstance}" field="nombreNegocio"/></span>
					
				</li>
				</g:if>
			
				<g:if test="${puntoVentaInstance?.calle}">
				<li class="fieldcontain">
					<span id="calle-label" class="property-label"><g:message code="puntoVenta.calle.label" default="Calle" /></span>
					
						<span class="property-value" aria-labelledby="calle-label"><g:fieldValue bean="${puntoVentaInstance}" field="calle"/></span>
					
				</li>
				</g:if>
			
				<g:if test="${puntoVentaInstance?.noExterior}">
				<li class="fieldcontain">
					<span id="noExterior-label" class="property-label"><g:message code="puntoVenta.noExterior.label" default="No Exterior" /></span>
					
						<span class="property-value" aria-labelledby="noExterior-label"><g:fieldValue bean="${puntoVentaInstance}" field="noExterior"/></span>
					
				</li>
				</g:if>
			
				<g:if test="${puntoVentaInstance?.colonia}">
				<li class="fieldcontain">
					<span id="colonia-label" class="property-label"><g:message code="puntoVenta.colonia.label" default="Colonia" /></span>
					
						<span class="property-value" aria-labelledby="colonia-label"><g:fieldValue bean="${puntoVentaInstance}" field="colonia"/></span>
					
				</li>
				</g:if>
			
				<g:if test="${puntoVentaInstance?.codigoPostal}">
				<li class="fieldcontain">
					<span id="codigoPostal-label" class="property-label"><g:message code="puntoVenta.codigoPostal.label" default="Codigo Postal" /></span>
					
						<span class="property-value" aria-labelledby="codigoPostal-label"><g:fieldValue bean="${puntoVentaInstance}" field="codigoPostal"/></span>
					
				</li>
				</g:if>
			
				<g:if test="${puntoVentaInstance?.pais}">
				<li class="fieldcontain">
					<span id="pais-label" class="property-label"><g:message code="puntoVenta.pais.label" default="Pais" /></span>
					
						<span class="property-value" aria-labelledby="pais-label"><g:link controller="pais" action="show" id="${puntoVentaInstance?.pais?.id}">${puntoVentaInstance?.pais?.encodeAsHTML()}</g:link></span>
					
				</li>
				</g:if>
			
				<g:if test="${puntoVentaInstance?.entidad}">
				<li class="fieldcontain">
					<span id="entidad-label" class="property-label"><g:message code="puntoVenta.entidad.label" default="Entidad" /></span>
					
						<span class="property-value" aria-labelledby="entidad-label"><g:link controller="entidad" action="show" id="${puntoVentaInstance?.entidad?.id}">${puntoVentaInstance?.entidad?.encodeAsHTML()}</g:link></span>
					
				</li>
				</g:if>
			
				<g:if test="${puntoVentaInstance?.ciudad}">
				<li class="fieldcontain">
					<span id="ciudad-label" class="property-label"><g:message code="puntoVenta.ciudad.label" default="Ciudad" /></span>
					
						<span class="property-value" aria-labelledby="ciudad-label"><g:link controller="ciudad" action="show" id="${puntoVentaInstance?.ciudad?.id}">${puntoVentaInstance?.ciudad?.encodeAsHTML()}</g:link></span>
					
				</li>
				</g:if>
			
				<g:if test="${puntoVentaInstance?.baja}">
				<li class="fieldcontain">
					<span id="baja-label" class="property-label"><g:message code="puntoVenta.baja.label" default="Baja" /></span>
					
						<span class="property-value" aria-labelledby="baja-label"><g:formatBoolean boolean="${puntoVentaInstance?.baja}" /></span>
					
				</li>
				</g:if>
			
				<g:if test="${puntoVentaInstance?.celular}">
				<li class="fieldcontain">
					<span id="celular-label" class="property-label"><g:message code="puntoVenta.celular.label" default="Celular" /></span>
					
						<span class="property-value" aria-labelledby="celular-label"><g:fieldValue bean="${puntoVentaInstance}" field="celular"/></span>
					
				</li>
				</g:if>
			
				<g:if test="${puntoVentaInstance?.cerrado}">
				<li class="fieldcontain">
					<span id="cerrado-label" class="property-label"><g:message code="puntoVenta.cerrado.label" default="Cerrado" /></span>
					
						<span class="property-value" aria-labelledby="cerrado-label"><g:formatBoolean boolean="${puntoVentaInstance?.cerrado}" /></span>
					
				</li>
				</g:if>
			
				<g:if test="${puntoVentaInstance?.correoElectronico}">
				<li class="fieldcontain">
					<span id="correoElectronico-label" class="property-label"><g:message code="puntoVenta.correoElectronico.label" default="Correo Electronico" /></span>
					
						<span class="property-value" aria-labelledby="correoElectronico-label"><g:fieldValue bean="${puntoVentaInstance}" field="correoElectronico"/></span>
					
				</li>
				</g:if>
			
				<g:if test="${puntoVentaInstance?.impresora}">
				<li class="fieldcontain">
					<span id="impresora-label" class="property-label"><g:message code="puntoVenta.impresora.label" default="Impresora" /></span>
					
						<span class="property-value" aria-labelledby="impresora-label"><g:link controller="impresoraHomologadas" action="show" id="${puntoVentaInstance?.impresora?.id}">${puntoVentaInstance?.impresora?.encodeAsHTML()}</g:link></span>
					
				</li>
				</g:if>
			
				<g:if test="${puntoVentaInstance?.impresoraActivo}">
				<li class="fieldcontain">
					<span id="impresoraActivo-label" class="property-label"><g:message code="puntoVenta.impresoraActivo.label" default="Impresora Activo" /></span>
					
						<span class="property-value" aria-labelledby="impresoraActivo-label"><g:formatBoolean boolean="${puntoVentaInstance?.impresoraActivo}" /></span>
					
				</li>
				</g:if>
			
				<g:if test="${puntoVentaInstance?.inventario}">
				<li class="fieldcontain">
					<span id="inventario-label" class="property-label"><g:message code="puntoVenta.inventario.label" default="Inventario" /></span>
					
						<span class="property-value" aria-labelledby="inventario-label"><g:formatBoolean boolean="${puntoVentaInstance?.inventario}" /></span>
					
				</li>
				</g:if>
			
				<g:if test="${puntoVentaInstance?.latitud}">
				<li class="fieldcontain">
					<span id="latitud-label" class="property-label"><g:message code="puntoVenta.latitud.label" default="Latitud" /></span>
					
						<span class="property-value" aria-labelledby="latitud-label"><g:fieldValue bean="${puntoVentaInstance}" field="latitud"/></span>
					
				</li>
				</g:if>
			
				<g:if test="${puntoVentaInstance?.longitud}">
				<li class="fieldcontain">
					<span id="longitud-label" class="property-label"><g:message code="puntoVenta.longitud.label" default="Longitud" /></span>
					
						<span class="property-value" aria-labelledby="longitud-label"><g:fieldValue bean="${puntoVentaInstance}" field="longitud"/></span>
					
				</li>
				</g:if>
			
				<g:if test="${puntoVentaInstance?.noInterior}">
				<li class="fieldcontain">
					<span id="noInterior-label" class="property-label"><g:message code="puntoVenta.noInterior.label" default="No Interior" /></span>
					
						<span class="property-value" aria-labelledby="noInterior-label"><g:fieldValue bean="${puntoVentaInstance}" field="noInterior"/></span>
					
				</li>
				</g:if>
			
				<g:if test="${puntoVentaInstance?.telefono}">
				<li class="fieldcontain">
					<span id="telefono-label" class="property-label"><g:message code="puntoVenta.telefono.label" default="Telefono" /></span>
					
						<span class="property-value" aria-labelledby="telefono-label"><g:fieldValue bean="${puntoVentaInstance}" field="telefono"/></span>
					
				</li>
				</g:if>
			
				<g:if test="${puntoVentaInstance?.urlLogotipo}">
				<li class="fieldcontain">
					<span id="urlLogotipo-label" class="property-label"><g:message code="puntoVenta.urlLogotipo.label" default="Url Logotipo" /></span>
					
						<span class="property-value" aria-labelledby="urlLogotipo-label"><g:fieldValue bean="${puntoVentaInstance}" field="urlLogotipo"/></span>
					
				</li>
				</g:if>
			
			</ol>
			<g:form url="[resource:puntoVentaInstance, action:'delete']" method="DELETE">
				<fieldset class="buttons">
					<g:link class="edit" action="edit" resource="${puntoVentaInstance}"><g:message code="default.button.edit.label" default="Edit" /></g:link>
					<g:actionSubmit class="delete" action="delete" value="${message(code: 'default.button.delete.label', default: 'Delete')}" onclick="return confirm('${message(code: 'default.button.delete.confirm.message', default: 'Are you sure?')}');" />
				</fieldset>
			</g:form>
		</div>
	</body>
</html>
