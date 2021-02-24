
<%@ page import="mx.elephantworks.iselling.Descuento" %>
<!DOCTYPE html>
<html>
	<head>
		<meta name="layout" content="main">
		<g:set var="entityName" value="${message(code: 'descuento.label', default: 'Descuento')}" />
		<title><g:message code="default.list.label" args="[entityName]" /></title>
	</head>
	<body>
		<a href="#list-descuento" class="skip" tabindex="-1"><g:message code="default.link.skip.label" default="Skip to content&hellip;"/></a>
		<div class="nav" role="navigation">
			<ul>
				<li><a class="home" href="${createLink(uri: '/')}"><g:message code="default.home.label"/></a></li>
				<li><g:link class="create" action="create"><g:message code="default.new.label" args="[entityName]" /></g:link></li>
			</ul>
		</div>
		<div id="list-descuento" class="content scaffold-list" role="main">
			<h1><g:message code="default.list.label" args="[entityName]" /></h1>
			<g:if test="${flash.message}">
				<div class="message" role="status">${flash.message}</div>
			</g:if>
			<table>
			<thead>
					<tr>
					
						<g:sortableColumn property="codigo" title="${message(code: 'descuento.codigo.label', default: 'Codigo')}" />
					
						<g:sortableColumn property="porcentajeDescuento" title="${message(code: 'descuento.porcentajeDescuento.label', default: 'Porcentaje Descuento')}" />
					
						<g:sortableColumn property="cantidad" title="${message(code: 'descuento.cantidad.label', default: 'Cantidad')}" />
					
						<g:sortableColumn property="utilidades" title="${message(code: 'descuento.utilidades.label', default: 'Utilidades')}" />
					
						<g:sortableColumn property="vigenciaInicio" title="${message(code: 'descuento.vigenciaInicio.label', default: 'Vigencia Inicio')}" />
					
						<g:sortableColumn property="vigenciaFin" title="${message(code: 'descuento.vigenciaFin.label', default: 'Vigencia Fin')}" />
					
					</tr>
				</thead>
				<tbody>
				<g:each in="${descuentoInstanceList}" status="i" var="descuentoInstance">
					<tr class="${(i % 2) == 0 ? 'even' : 'odd'}">
					
						<td><g:link action="show" id="${descuentoInstance.id}">${fieldValue(bean: descuentoInstance, field: "codigo")}</g:link></td>
					
						<td>${fieldValue(bean: descuentoInstance, field: "porcentajeDescuento")}</td>
					
						<td>${fieldValue(bean: descuentoInstance, field: "cantidad")}</td>
					
						<td>${fieldValue(bean: descuentoInstance, field: "utilidades")}</td>
					
						<td><g:formatDate date="${descuentoInstance.vigenciaInicio}" /></td>
					
						<td><g:formatDate date="${descuentoInstance.vigenciaFin}" /></td>
					
					</tr>
				</g:each>
				</tbody>
			</table>
			<div class="pagination">
				<g:paginate total="${descuentoInstanceCount ?: 0}" />
			</div>
		</div>
	</body>
</html>
