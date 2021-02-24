<html>
<head>
	<meta name="layout" content="main"/>
	<g:set var="entityName" value="${message(code: 'usuario.label', default: 'Usuario')}" />
	<title><g:message code="spring.security.ui.resetPassword.title" /></title>
	<style>
	body{
		background-color: #F5F5F5;
	}
	.texto-derecha{
		text-align: right;
	}
	</style>
</head>
<body>

<br><br>

<div class="row">
	<div class="col-md-8 col-md-offset-2">
		<div class="panel panel-primary" style="border-color: #48BFE6;">

			<div class="panel-heading encabezadoPanelFormulario" style="background-color: #48BFE6; border-color: #48BFE6;">
					<g:message code="spring.security.ui.resetPassword.title" />
			</div>

			<br>

			<g:if test="${flash.message}">
				<div class="message" role="status">${flash.message}</div>
			</g:if>

			<g:hasErrors bean="${command}">
				<ul class="errors" role="alert">
					<g:eachError bean="${command}" var="error">
						<li <g:if test="${error in org.springframework.validation.FieldError}">data-field-id="${error.field}"</g:if>><g:message error="${error}"/></li>
					</g:eachError>
				</ul>
			</g:hasErrors>

			<div class="contenedor">


				<g:form controller="usuarios" action="resetPassword" method="POST">

					<div class="form-group ${hasErrors(bean: command, field: 'password', 'error')} required">
						<label for="password">
							<g:message code="usuario.password.label" default="Password" />
							<span class="required-indicator">*</span>
						</label>

						<g:field type="password" name="password" class="form-control" required="" value="${command?.password}"/>
					</div>

					<div class="form-group ${hasErrors(bean: command, field: 'password2', 'error')} required">
						<label for="password2">
							<g:message code="usuario.password2.label" default="Password (again)" />
							<span class="required-indicator">*</span>
						</label>

						<g:field type="password" name="password2" class="form-control" required="" value="${command?.password2}"/>
					</div>



					<fieldset class="buttons texto-derecha">
						<g:actionSubmit class="btn btn-primary color-vennda" action="resetPassword" value="${message(code: 'default.button.update.label', default: 'Update')}" />
					</fieldset>
				</g:form>
			</div>
			<br>
		</div>
	</div>
</div>





</body>
</html>