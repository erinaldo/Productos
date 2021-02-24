<%@ page import="mx.elephantworks.iselling.Usuario" %>



<div class="form-group ${hasErrors(bean: usuarioInstance, field: 'username', 'error')} required">
	<label for="username">
		<g:message code="usuario.username.label" default="Username" />
		<span class="required-indicator">*</span>
	</label>
	<g:textField name="username" required="" value="${usuarioInstance?.username}" class="form-control"/>

</div>

<div class="form-group ${hasErrors(bean: usuarioInstance, field: 'password', 'error')} required">
	<label for="password">
		<g:message code="usuario.password.label" default="Password" />
		<span class="required-indicator">*</span>
	</label>

	<g:link controller="usuarios" action="resetPassword">${message(code: 'spring.security.ui.resetPassword.title')}</g:link>
</div>
