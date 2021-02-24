<!DOCTYPE html>
<html>
	<head>
		<meta name="layout" content="main">
		<g:set var="entityName" value="${message(code: 'inventario.label', default: 'Inventario')}" />
		<title><g:message code="default.create.label" args="[entityName]" /></title>
	</head>
	<body>

		<div style="margin-top: 3%">
			<g:link action="index">
				<image width="30px" class="imageInButton" src="${resource(dir: "images", file: "volver.png")}"></image>
				<label class="mensaje">volver</label>
			</g:link>
		</div>


	<div class="row" style="margin-top: 3%">
		<div class="col-md-8 col-md-offset-2">
			<div class="panel panel-primary" style="border-color: #48BFE6">
				<div class="panel-heading encabezadoPanelFormulario" style="background-color: #48BFE6;border-color: #48BFE6;">
					<image width="25px" class="imageInButton" src="${resource(dir: "images", file: "Inventario/EnvioBlanco.png")}"></image>
					<g:message code="inventario.crear.label" default="Crear Inventario"/>
				</div>

				<g:if test="${flash.message}">
					<div class="alert alert-info" role="status">${flash.message}</div>
				</g:if>

				<g:if test="${flash.error}">
					<div class="alert alert-info" role="status">${flash.error}</div>
				</g:if>

				<g:hasErrors bean="${inventarioInstance}">
					<ul class="alert alert-info" role="alert">
						<g:eachError bean="${inventarioInstance}" var="error">
							<li <g:if test="${error in org.springframework.validation.FieldError}">data-field-id="${error.field}"</g:if>><g:message error="${error}"/></li>
						</g:eachError>
					</ul>
				</g:hasErrors>

				<div class="contenedor" style="margin-top: 3%; margin-bottom: 3%">
					<g:form url="[resource:inventarioInstance, action:'save']" >
						<fieldset class="form">
							<g:render template="form"/>
						</fieldset>
						<fieldset class="buttons" style="text-align: right; padding-top: 10px;">
							<g:submitButton name="create" class="save" class="btn btn-primary color-vennda" value="${message(code: 'default.button.create.label', default: 'Create')}" />
						</fieldset>
					</g:form>
				</div>

			</div>
		</div>
	</div>




	</body>
</html>
