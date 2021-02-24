
<%@ page import="mx.elephantworks.iselling.Cliente" %>
<!DOCTYPE html>
<html>
	<head>
		<meta name="layout" content="main">
		<g:set var="entityName" value="${message(code: 'cliente.label', default: 'Cliente')}" />
		<title><g:message code="default.show.label" args="[entityName]" /></title>
	</head>
	<body>
		<a href="#show-cliente" class="skip" tabindex="-1"><g:message code="default.link.skip.label" default="Skip to content&hellip;"/></a>
		<div class="nav" role="navigation">
			<ul>
				<li><a class="home" href="${createLink(uri: '/')}"><g:message code="default.home.label"/></a></li>
				<li><g:link class="list" action="index"><g:message code="default.list.label" args="[entityName]" /></g:link></li>
				<li><g:link class="createCliente" action="create"><g:message code="default.new.label" args="[entityName]" /></g:link></li>
			</ul>
		</div>
		<div id="show-cliente" class="content scaffold-show" role="main">
			<h1><g:message code="default.show.label" args="[entityName]" /></h1>
			<g:if test="${flash.message}">
			<div class="message" role="status">${flash.message}</div>
			</g:if>
			<ol class="property-list cliente">
			
				<g:if test="${clienteInstance?.clave}">
				<li class="fieldcontain">
					<span id="clave-label" class="property-label"><g:message code="cliente.clave.label" default="Clave" /></span>
					
						<span class="property-value" aria-labelledby="clave-label"><g:fieldValue bean="${clienteInstance}" field="clave"/></span>
					
				</li>
				</g:if>
			
				<g:if test="${clienteInstance?.razonSocial}">
				<li class="fieldcontain">
					<span id="razonSocial-label" class="property-label"><g:message code="cliente.razonSocial.label" default="Razon Social" /></span>
					
						<span class="property-value" aria-labelledby="razonSocial-label"><g:fieldValue bean="${clienteInstance}" field="razonSocial"/></span>
					
				</li>
				</g:if>
			
				<g:if test="${clienteInstance?.rfc}">
				<li class="fieldcontain">
					<span id="rfc-label" class="property-label"><g:message code="cliente.rfc.label" default="Rfc" /></span>
					
						<span class="property-value" aria-labelledby="rfc-label"><g:fieldValue bean="${clienteInstance}" field="rfc"/></span>
					
				</li>
				</g:if>
			
				<g:if test="${clienteInstance?.domicilio}">
				<li class="fieldcontain">
					<span id="domicilio-label" class="property-label"><g:message code="cliente.domicilio.label" default="Domicilio" /></span>
					
						<span class="property-value" aria-labelledby="domicilio-label"><g:fieldValue bean="${clienteInstance}" field="domicilio"/></span>
					
				</li>
				</g:if>
			
				<g:if test="${clienteInstance?.estado}">
				<li class="fieldcontain">
					<span id="estado-label" class="property-label"><g:message code="cliente.estado.label" default="Estado" /></span>
					
						<span class="property-value" aria-labelledby="estado-label"><g:fieldValue bean="${clienteInstance}" field="estado"/></span>
					
				</li>
				</g:if>
			
				<g:if test="${clienteInstance?.municipio}">
				<li class="fieldcontain">
					<span id="municipio-label" class="property-label"><g:message code="cliente.municipio.label" default="Municipio" /></span>
					
						<span class="property-value" aria-labelledby="municipio-label"><g:fieldValue bean="${clienteInstance}" field="municipio"/></span>
					
				</li>
				</g:if>
			
				<g:if test="${clienteInstance?.colonia}">
				<li class="fieldcontain">
					<span id="colonia-label" class="property-label"><g:message code="cliente.colonia.label" default="Colonia" /></span>
					
						<span class="property-value" aria-labelledby="colonia-label"><g:fieldValue bean="${clienteInstance}" field="colonia"/></span>
					
				</li>
				</g:if>
			
				<g:if test="${clienteInstance?.cp}">
				<li class="fieldcontain">
					<span id="cp-label" class="property-label"><g:message code="cliente.cp.label" default="Cp" /></span>
					
						<span class="property-value" aria-labelledby="cp-label"><g:fieldValue bean="${clienteInstance}" field="cp"/></span>
					
				</li>
				</g:if>
			
				<g:if test="${clienteInstance?.listaPrecio}">
				<li class="fieldcontain">
					<span id="listaPrecio-label" class="property-label"><g:message code="cliente.listaPrecio.label" default="Lista Precio" /></span>
					
						<span class="property-value" aria-labelledby="listaPrecio-label"><g:link controller="listaPrecio" action="show" id="${clienteInstance?.listaPrecio?.id}">${clienteInstance?.listaPrecio?.encodeAsHTML()}</g:link></span>
					
				</li>
				</g:if>
			
				<g:if test="${clienteInstance?.limiteCredito}">
				<li class="fieldcontain">
					<span id="limiteCredito-label" class="property-label"><g:message code="cliente.limiteCredito.label" default="Limite Credito" /></span>
					
						<span class="property-value" aria-labelledby="limiteCredito-label"><g:fieldValue bean="${clienteInstance}" field="limiteCredito"/></span>
					
				</li>
				</g:if>
			
				<g:if test="${clienteInstance?.email}">
				<li class="fieldcontain">
					<span id="email-label" class="property-label"><g:message code="cliente.email.label" default="Email" /></span>
					
						<span class="property-value" aria-labelledby="email-label"><g:fieldValue bean="${clienteInstance}" field="email"/></span>
					
				</li>
				</g:if>
			
				<g:if test="${clienteInstance?.diasCredito}">
				<li class="fieldcontain">
					<span id="diasCredito-label" class="property-label"><g:message code="cliente.diasCredito.label" default="Dias Credito" /></span>
					
						<span class="property-value" aria-labelledby="diasCredito-label"><g:fieldValue bean="${clienteInstance}" field="diasCredito"/></span>
					
				</li>
				</g:if>
			
			</ol>
			<g:form url="[resource:clienteInstance, action:'delete']" method="DELETE">
				<fieldset class="buttons">
					<g:link class="edit" action="edit" resource="${clienteInstance}"><g:message code="default.button.edit.label" default="Edit" /></g:link>
					<g:actionSubmit class="delete" action="delete" value="${message(code: 'default.button.delete.label', default: 'Delete')}" onclick="return confirm('${message(code: 'default.button.delete.confirm.message', default: 'Are you sure?')}');" />
				</fieldset>
			</g:form>
		</div>
	</body>
</html>
