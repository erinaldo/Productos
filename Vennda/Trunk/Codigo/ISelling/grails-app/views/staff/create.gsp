<!DOCTYPE html>
<html>
	<head>
		<meta name="layout" content="main">
		<g:set var="entityName" value="${message(code: 'staff.label', default: 'Staff')}" />
		<title><g:message code="default.create.label" args="[entityName]" /></title>
	</head>
	<body>
	<div style="margin-top: 3%">
		<g:link action="index">
			<image width="30px" class="imageInButton" src="${resource(dir: "images", file: "volver.png")}"></image>
			<label class="mensaje">volver</label>
		</g:link>
	</div>
	<div id="create-cliente" class="row" style="margin-top: 3%" role="main">
		<div class="col-md-8 col-md-offset-2">
			<div class="panel panel-primary" style="border-color: #48BFE6">
				<div class="panel-heading encabezadoPanelFormulario" style="background-color: #48BFE6;border-color: #48BFE6;">
					<image width="25px" class="imageInButton" src="${resource(dir: "images", file: "Staff/staffBlanco.png")}"></image>
					<g:message code="default.create.label" args="[entityName]" />
				</div>
				<g:if test="${flash.message}">
					<div class="alert alert-info alert-dismissible" role="alert">
						<button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
						<strong>Aviso!</strong> ${flash.message}
					</div>
				</g:if>
				<g:hasErrors bean="${staffInstance}">
					<div class="alert alert-danger alert-dismissible" role="alert">
						<button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
						<ul class="errors" role="alert">
							<g:eachError bean="${staffInstance}" var="error">
								<li <g:if test="${error in org.springframework.validation.FieldError}">data-field-id="${error.field}"</g:if>><g:message error="${error}"/></li>
							</g:eachError>
						</ul>
					</div>
				</g:hasErrors>

				<div id="create-staff"  class="contenedor" style="margin-top: 3%; margin-bottom: 3%" role="main">
					<g:form url="[resource:staffInstance, action:'save']" onsubmit="return validaFormulario()" >
						<fieldset class="form">
							<g:render template="form" />
						</fieldset>
						<fieldset class="buttons" style="text-align: right">
							<g:submitButton name="create" class="btn btn-primary color-vennda" value="${message(code: 'default.button.create.label', default: 'Create')}" />
						</fieldset>
					</g:form>
				</div>
			</div>
		</div>
	</div>
	</div>


	<g:javascript>

		function validaFormulario(){
			var pasa = true;
			var correo = $("#email").val();
			var regularEmail = /^(?:[^<>()[\].,;:\s@"]+(\.[^<>()[\].,;:\s@"]+)*|"[^\n"]+")@(?:[^<>()[\].,;:\s@"]+\.)+[^<>()[\]\.,;:\s@"]{2,63}$/i;
			if(!regularEmail.test(correo))
			{
				alert("El correo electronico es invalido, por favor cheque sus datos.");
				pasa = false;
				event.preventDefault();
			}

			return pasa;
		}


	</g:javascript>

	</body>
</html>
