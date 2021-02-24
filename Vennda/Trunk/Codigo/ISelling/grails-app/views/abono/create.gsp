<!DOCTYPE html>
<html>
	<head>
		<meta name="layout" content="main">
		<g:set var="entityName" value="${message(code: 'abono.label', default: 'Abono')}" />
		<title><g:message code="default.create.label" args="[entityName]" /></title>
	</head>
	<body>
	<div style="margin-top: 3%">
		<g:link controller="cobranza" action="index">
			<image width="30px" class="imageInButton" src="${resource(dir: "images", file: "volver.png")}"></image>
			<label class="mensaje"><g:message code="volver.title.label" default="Volver"></g:message></label>
		</g:link>
	</div>
	<div id="create-cliente" class="row" style="margin-top: 3%" role="main">
		<div class="col-md-8 col-md-offset-2">
			<div class="panel panel-primary" style="border-color: #48BFE6">
				<div class="panel-heading encabezadoPanelFormulario" style="background-color: #48BFE6;border-color: #48BFE6;">
					<image width="25px" class="imageInButton" src="${resource(dir: "images", file: "Abono/abonoBlanco.png")}"></image>
					<g:message code="default.create.label" args="[entityName]" />
				</div>
				<g:if test="${flash.message}">
					<div class="alert alert-info alert-dismissible" role="alert">
						<button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
						<strong><g:message code="alerta.title.label" default="Aviso!"></g:message></strong> ${flash.message}
					</div>
				</g:if>
				<g:hasErrors bean="${abonoInstance}">
					<div class="alert alert-danger alert-dismissible" role="alert">
						<button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
						<ul role="alert">
							<g:eachError bean="${abonoInstance}" var="error">
								<li <g:if test="${error in org.springframework.validation.FieldError}">data-field-id="${error.field}"</g:if>><g:message error="${error}"/></li>
							</g:eachError>
						</ul>
					</div>
				</g:hasErrors>

				<div class="contenedor" style="margin-top: 3%; margin-bottom: 3%">
					<g:form url="[resource:abonoInstance, action:'save']" onsubmit="return validaFormulario()" >
						<fieldset class="form">
							<g:render template="form"/>
						</fieldset>
						<fieldset class="buttons" style="text-align: right">
							<g:submitButton name="create" class="btn btn-primary color-vennda" value="${message(code: 'default.button.pagar.label', default: 'Pagar')}" />
						</fieldset>
					</g:form>
				</div>
			</div>
		</div>
	</div>

	<g:javascript>
		function validaFormulario(){
			var pasa = true;
			var saldo, monto;
			try {
				 saldo = parseFloat($("#saldo").val()).toFixed(2);
				 monto = parseFloat($("#monto").val()).toFixed(2);
			}
			catch(err) {

				alert("El monto no es valido");
			}

			console.log(saldo +" es igual a "+monto);
			if(monto > saldo){
			    pasa = false;
			    alert("El monto no puede ser mayor al saldo.")
			}

			return pasa;
		}
	</g:javascript>
	</body>
</html>
