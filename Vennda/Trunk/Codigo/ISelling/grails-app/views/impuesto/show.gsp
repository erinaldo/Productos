
<%@ page import="mx.elephantworks.iselling.Impuesto" %>
<!DOCTYPE html>
<html>
	<head>
		<meta name="layout" content="main">
		<g:set var="entityName" value="${message(code: 'impuesto.label', default: 'Impuesto')}" />
		<title><g:message code="default.show.label" args="[entityName]" /></title>
	</head>
	<body>
		<a href="#show-impuesto" class="skip" tabindex="-1"><g:message code="default.link.skip.label" default="Skip to content&hellip;"/></a>
		<div class="nav" role="navigation">
			<ul>
				<li><a class="home" href="${createLink(uri: '/')}"><g:message code="default.home.label"/></a></li>
				<li><g:link class="list" action="index"><g:message code="default.list.label" args="[entityName]" /></g:link></li>
				<li><g:link class="create" action="create"><g:message code="default.new.label" args="[entityName]" /></g:link></li>
			</ul>
		</div>
		<div id="show-impuesto" class="content scaffold-show" role="main">
			<h1><g:message code="default.show.label" args="[entityName]" /></h1>
			<g:if test="${flash.message}">
			<div class="message" role="status">${flash.message}</div>
			</g:if>
			<ol class="property-list impuesto">


		<g:if test="${impuestoInstance?.identificador}">
			<li class="fieldcontain">
				<span id="identificador-label" class="property-label"><g:message code="impuesto.identificador.label" default="Identificador" /></span>

				<span class="property-value" aria-labelledby="identificador-label"><g:fieldValue bean="${impuestoInstance}" field="identificador"/></span>

			</li>
		</g:if>

		<g:if test="${impuestoInstance?.tipoAplicacion}">
			<li class="fieldcontain">
				<span id="tipoAplicacion-label" class="property-label"><g:message code="impuesto.tipoAplicacion.label" default="Tipo Aplicacion" /></span>

				<span class="property-value" aria-labelledby="tipoAplicacion-label"><g:fieldValue bean="${impuestoInstance}" field="tipoAplicacion"/></span>

			</li>
		</g:if>

		<g:if test="${impuestoInstance?.activo}">
			<li class="fieldcontain">
				<span id="activo-label" class="property-label"><g:message code="impuesto.activo.label" default="Activo" /></span>

				<span class="property-value" aria-labelledby="activo-label"><g:formatBoolean boolean="${impuestoInstance?.activo}" /></span>

			</li>
		</g:if>

		<g:if test="${impuestoInstance?.despuesDeImpuesto}">
			<li class="fieldcontain">
				<span id="despuesDeImpuesto-label" class="property-label"><g:message code="impuesto.despuesDeImpuesto.label" default="Despues De Impuesto" /></span>

				<span class="property-value" aria-labelledby="despuesDeImpuesto-label"><g:formatBoolean boolean="${impuestoInstance?.despuesDeImpuesto}" /></span>

			</li>
		</g:if>

		<g:if test="${impuestoInstance?.jerarquia}">
			<li class="fieldcontain">
				<span id="jerarquia-label" class="property-label"><g:message code="impuesto.jerarquia.label" default="Jerarquia" /></span>

				<span class="property-value" aria-labelledby="jerarquia-label"><g:fieldValue bean="${impuestoInstance}" field="jerarquia"/></span>

			</li>
		</g:if>

		<g:if test="${impuestoInstance?.valores}">
			<li class="fieldcontain">
				<span id="valores-label" class="property-label"><g:message code="impuesto.valores.label" default="Valores" /></span>

				<g:each in="${impuestoInstance.valores}" var="v">
					<g:if test="${v?.activo}">
						<span class="property-value" aria-labelledby="valores-label">
							${v?.encodeAsHTML()}
						</span>
					</g:if>
				</g:each>

			</li>
		</g:if>

			</ol>
			<g:form url="[resource:impuestoInstance, action:'delete']" method="DELETE">
				<fieldset class="buttons">
					<g:link class="edit" action="edit" resource="${impuestoInstance}"><g:message code="default.button.edit.label" default="Edit" /></g:link>
					<g:actionSubmit class="delete" action="delete" value="${message(code: 'default.button.delete.label', default: 'Delete')}" onclick="return confirm('${message(code: 'default.button.delete.confirm.message', default: 'Are you sure?')}');" />
				</fieldset>
			</g:form>
		</div>
	</body>
</html>
