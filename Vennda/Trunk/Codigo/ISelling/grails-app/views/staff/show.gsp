
<%@ page import="mx.elephantworks.iselling.Staff" %>
<!DOCTYPE html>
<html>
	<head>
		<meta name="layout" content="main">
		<g:set var="entityName" value="${message(code: 'staff.label', default: 'Staff')}" />
		<title><g:message code="default.show.label" args="[entityName]" /></title>
	</head>
	<body>
		<a href="#show-staff" class="skip" tabindex="-1"><g:message code="default.link.skip.label" default="Skip to content&hellip;"/></a>
		<div class="nav" role="navigation">
			<ul>
				<li><a class="home" href="${createLink(uri: '/')}"><g:message code="default.home.label"/></a></li>
				<li><g:link class="list" action="index"><g:message code="default.list.label" args="[entityName]" /></g:link></li>
				<li><g:link class="create" action="create"><g:message code="default.new.label" args="[entityName]" /></g:link></li>
			</ul>
		</div>
		<div id="show-staff" class="content scaffold-show" role="main">
			<h1><g:message code="default.show.label" args="[entityName]" /></h1>
			<g:if test="${flash.message}">
			<div class="message" role="status">${flash.message}</div>
			</g:if>
			<ol class="property-list staff">
			
				<g:if test="${staffInstance?.numEmpleado}">
				<li class="fieldcontain">
					<span id="numEmpleado-label" class="property-label"><g:message code="staff.numEmpleado.label" default="Num Empleado" /></span>
					
						<span class="property-value" aria-labelledby="numEmpleado-label"><g:fieldValue bean="${staffInstance}" field="numEmpleado"/></span>
					
				</li>
				</g:if>
			
				<g:if test="${staffInstance?.nombre}">
				<li class="fieldcontain">
					<span id="nombre-label" class="property-label"><g:message code="staff.nombre.label" default="Nombre" /></span>
					
						<span class="property-value" aria-labelledby="nombre-label"><g:fieldValue bean="${staffInstance}" field="nombre"/></span>
					
				</li>
				</g:if>
			
				<g:if test="${staffInstance?.apellidos}">
				<li class="fieldcontain">
					<span id="apellidos-label" class="property-label"><g:message code="staff.apellidos.label" default="Apellidos" /></span>
					
						<span class="property-value" aria-labelledby="apellidos-label"><g:fieldValue bean="${staffInstance}" field="apellidos"/></span>
					
				</li>
				</g:if>
			
				<g:if test="${staffInstance?.pin}">
				<li class="fieldcontain">
					<span id="pin-label" class="property-label"><g:message code="staff.pin.label" default="Pin" /></span>
					
						<span class="property-value" aria-labelledby="pin-label"><g:fieldValue bean="${staffInstance}" field="pin"/></span>
					
				</li>
				</g:if>
			
				<g:if test="${staffInstance?.email}">
				<li class="fieldcontain">
					<span id="email-label" class="property-label"><g:message code="staff.email.label" default="Email" /></span>
					
						<span class="property-value" aria-labelledby="email-label"><g:fieldValue bean="${staffInstance}" field="email"/></span>
					
				</li>
				</g:if>
			
				<g:if test="${staffInstance?.baja}">
				<li class="fieldcontain">
					<span id="baja-label" class="property-label"><g:message code="staff.baja.label" default="Baja" /></span>
					
						<span class="property-value" aria-labelledby="baja-label"><g:formatBoolean boolean="${staffInstance?.baja}" /></span>
					
				</li>
				</g:if>
			
				<g:if test="${staffInstance?.autorizaCancelacion}">
				<li class="fieldcontain">
					<span id="autorizaCancelacion-label" class="property-label"><g:message code="staff.autorizaCancelacion.label" default="Autoriza Cancelacion" /></span>
					
						<span class="property-value" aria-labelledby="autorizaCancelacion-label"><g:formatBoolean boolean="${staffInstance?.autorizaCancelacion}" /></span>
					
				</li>
				</g:if>
			
				<g:if test="${staffInstance?.porcentajeDescuento}">
				<li class="fieldcontain">
					<span id="porcentajeDescuento-label" class="property-label"><g:message code="staff.porcentajeDescuento.label" default="Porcentaje Descuento" /></span>
					
						<span class="property-value" aria-labelledby="porcentajeDescuento-label"><g:fieldValue bean="${staffInstance}" field="porcentajeDescuento"/></span>
					
				</li>
				</g:if>
			
				<g:if test="${staffInstance?.idCuenta}">
				<li class="fieldcontain">
					<span id="idCuenta-label" class="property-label"><g:message code="staff.idCuenta.label" default="Id Cuenta" /></span>
					
						<span class="property-value" aria-labelledby="idCuenta-label"><g:fieldValue bean="${staffInstance}" field="idCuenta"/></span>
					
				</li>
				</g:if>
			
				<g:if test="${staffInstance?.idStaff}">
				<li class="fieldcontain">
					<span id="idStaff-label" class="property-label"><g:message code="staff.idStaff.label" default="Id Staff" /></span>
					
						<span class="property-value" aria-labelledby="idStaff-label"><g:fieldValue bean="${staffInstance}" field="idStaff"/></span>
					
				</li>
				</g:if>
			
			</ol>
			<g:form url="[resource:staffInstance, action:'delete']" method="DELETE">
				<fieldset class="buttons">
					<g:link class="edit" action="edit" resource="${staffInstance}"><g:message code="default.button.edit.label" default="Edit" /></g:link>
					<g:actionSubmit class="delete" action="delete" value="${message(code: 'default.button.delete.label', default: 'Delete')}" onclick="return confirm('${message(code: 'default.button.delete.confirm.message', default: 'Are you sure?')}');" />
				</fieldset>
			</g:form>
		</div>
	</body>
</html>
