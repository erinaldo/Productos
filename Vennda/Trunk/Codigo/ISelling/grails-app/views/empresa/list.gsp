
<%@ page import="mx.elephantworks.iselling.Empresa" %>
<!DOCTYPE html>
<html>
	<head>
		<meta name="layout" content="main">
		<g:set var="entityName" value="${message(code: 'empresa.label', default: 'Empresa')}" />
		<title><g:message code="default.list.label" args="[entityName]" /></title>
	</head>
	<body>
		<a href="#list-empresa" class="skip" tabindex="-1"><g:message code="default.link.skip.label" default="Skip to content&hellip;"/></a>
		<div class="nav" role="navigation">
			<ul>
				<li><a class="home" href="${createLink(uri: '/')}"><g:message code="default.home.label"/></a></li>
			</ul>
		</div>
		<div id="list-empresa" class="content scaffold-list" role="main">
			<h1><g:message code="default.list.label" args="[entityName]" /></h1>
			<g:if test="${flash.message}">
				<div class="message" role="status">${flash.message}</div>
			</g:if>
			<table>
			<thead>
					<tr>
					
						<g:sortableColumn property="username" title="${message(code: 'empresa.username.label', default: 'Username')}" />
					
						<g:sortableColumn property="password" title="${message(code: 'empresa.password.label', default: 'Password')}" />
					
						<g:sortableColumn property="nombreEmpresa" title="${message(code: 'empresa.nombreEmpresa.label', default: 'Nombre Empresa')}" />

						<g:sortableColumn property="rfc" title="${message(code: 'empresa.rfc.label', default: 'RFC')}" />

						<th><g:message code="empresa.tipoCuenta.label" default="Tipo Cuenta" /></th>

					</tr>
				</thead>
				<tbody>
				<g:each in="${empresaInstanceList}" status="i" var="empresaInstance">
					<tr class="${(i % 2) == 0 ? 'even' : 'odd'}">
					
						<td><g:link action="show" id="${empresaInstance.id}">${fieldValue(bean: empresaInstance, field: "username")}</g:link></td>
					
						<td>${fieldValue(bean: empresaInstance, field: "password")}</td>
					
						<td>${fieldValue(bean: empresaInstance, field: "nombreEmpresa")}</td>

						<td>${fieldValue(bean: empresaInstance, field: "rfc")}</td>

						<td>${fieldValue(bean: empresaInstance, field: "tipoCuenta")}</td>
						
					</tr>
				</g:each>
				</tbody>
			</table>
			<div class="pagination">
				<g:paginate total="${empresaInstanceCount ?: 0}" />
			</div>
		</div>
	</body>
</html>
