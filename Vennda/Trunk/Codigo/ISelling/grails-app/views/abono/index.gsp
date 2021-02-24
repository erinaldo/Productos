
<%@ page import="mx.elephantworks.iselling.Abono" %>
<!DOCTYPE html>
<html>
	<head>
		<meta name="layout" content="main">
		<g:set var="entityName" value="${message(code: 'abono.label', default: 'Abono')}" />
		<title><g:message code="default.list.label" args="[entityName]" /></title>
	</head>
	<body>
		<a href="#list-abono" class="skip" tabindex="-1"><g:message code="default.link.skip.label" default="Skip to content&hellip;"/></a>
		<div class="nav" role="navigation">
			<ul>
				<li><a class="home" href="${createLink(uri: '/')}"><g:message code="default.home.label"/></a></li>
				<li><g:link class="create" action="create"><g:message code="default.new.label" args="[entityName]" /></g:link></li>
			</ul>
		</div>
		<div id="list-abono" class="content scaffold-list" role="main">
			<h1><g:message code="default.list.label" args="[entityName]" /></h1>
			<g:if test="${flash.message}">
				<div class="message" role="status">${flash.message}</div>
			</g:if>
			<table>
			<thead>
					<tr>
					
						<g:sortableColumn property="metodoPago" title="${message(code: 'abono.metodoPago.label', default: 'Metodo Pago')}" />
					
						<g:sortableColumn property="referencia" title="${message(code: 'abono.referencia.label', default: 'Referencia')}" />
					
						<g:sortableColumn property="monto" title="${message(code: 'abono.monto.label', default: 'Monto')}" />
					
					</tr>
				</thead>
				<tbody>
				<g:each in="${abonoInstanceList}" status="i" var="abonoInstance">
					<tr class="${(i % 2) == 0 ? 'even' : 'odd'}">
					
						<td><g:link action="show" id="${abonoInstance.id}">${fieldValue(bean: abonoInstance, field: "metodoPago")}</g:link></td>
					
						<td>${fieldValue(bean: abonoInstance, field: "referencia")}</td>
					
						<td>${fieldValue(bean: abonoInstance, field: "monto")}</td>
					
					</tr>
				</g:each>
				</tbody>
			</table>
			<div class="pagination">
				<g:paginate total="${abonoInstanceCount ?: 0}" />
			</div>
		</div>
	</body>
</html>
