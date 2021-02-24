<!DOCTYPE html>
<html>
	<head>
		<meta name="layout" content="main">
		<g:set var="entityName" value="${message(code: 'descuento.label', default: 'Descuento')}" />
		<title><g:message code="default.create.label" args="[entityName]" /></title>
	</head>
	<body>
	<g:if test="${flash.message}">
		<div class="alert alert-info alert-dismissible" role="alert">
			<button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
			<strong>Aviso!</strong> ${flash.message}
		</div>
	</g:if>
	<g:hasErrors bean="${descuentoInstance}">
		<div class="alert alert-info alert-dismissible" role="alert">
			<button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
			<ul class="alert alert-info" role="alert">
				<g:eachError bean="${descuentoInstance}" var="error">
					<li <g:if test="${error in org.springframework.validation.FieldError}">data-field-id="${error.field}"</g:if>><g:message error="${error}"/></li>
				</g:eachError>
			</ul>
		</div>
	</g:hasErrors>
	<div style="margin-top: 3%">
		<g:link action="index">
			<image width="30px" class="imageInButton" src="${resource(dir: "images", file: "volver.png")}"></image>
			<label class="mensaje">volver</label>
		</g:link>
	</div>
	<div id="create-descuento" class="row" style="margin-top: 3%" role="main">
		<div class="col-md-8 col-md-offset-2">
			<div class="panel panel-primary" style="border-color: #48BFE6">
				<div class="panel-heading encabezadoPanelFormulario" style="background-color: #48BFE6;border-color: #48BFE6;">
					<image width="25px" class="imageInButton" src="${resource(dir: "images", file: "Descuento/descuentoBlanco.png")}"></image>
					<g:message code="default.create.label" args="[entityName]" />
				</div>
				<div class="contenedor" style="margin-top: 3%; margin-bottom: 3%;">
			<g:form url="[resource:descuentoInstance, action:'save']" >
				<fieldset class="form">
					<g:render template="form"/>
					<g:hiddenField name="plan" value="${plan}"/>
				</fieldset>
				<fieldset class="buttons" style="text-align: right">
					<g:submitButton name="create" class="btn btn-primary color-vennda"  value="${message(code: 'default.button.create.label', default: 'Create')}" />
				</fieldset>
			</g:form>
				</div>
			</div>
		</div>
	</div>
	</body>
</html>
