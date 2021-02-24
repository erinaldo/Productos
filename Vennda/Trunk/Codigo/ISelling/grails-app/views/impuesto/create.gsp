<!DOCTYPE html>
<html>
	<head>
		<meta name="layout" content="main">
		<g:set var="entityName" value="${message(code: 'impuesto.label', default: 'Impuesto')}" />
		<title><g:message code="default.create.label" args="[entityName]" /></title>
		<style>
		input[type='radio']:checked:after {
			width: 15px;
			height: 15px;
			border-radius: 15px;
			top: -2px;
			left: -1px;
			position: relative;
			background-color: #1c94c4;
			content: '';
			display: inline-block;
			visibility: visible;
			border: 2px solid white;
		}
		</style>
		<%--
		<script type="text/javascript">
            $(document).ready(function() {
                $('#divRadioSi').click(function(e) {
                    $('#lblSi').css('color','#f2f2f2');
                    $('#lblNo').css('color','#000000');
                    $('#divRadioNo').css('background-color','#f2f2f2');
                    $('#divRadioSi').css('background-color','#1c94c4');

                });
                $('#divRadioNo').click(function(e) {
                    $('#lblNo').css('color','#f2f2f2');
                    $('#lblSi').css('color','#000000');
                    $('#divRadioNo').css('background-color','#1c94c4');
                    $('#divRadioSi').css('background-color','#f2f2f2');
                });
            });
		</script>
		--%>

	</head>
	<body>
	<g:if test="${flash.message}">
		<div class="alert alert-info alert-dismissible" role="alert">
			<button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
			<strong>Aviso!</strong> ${flash.message}
		</div>
	</g:if>
	<g:hasErrors bean="${impuestoInstance}">
		<div class="alert alert-info alert-dismissible" role="alert">
			<button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
			<ul class="alert alert-info" role="alert">
				<g:eachError bean="${impuestoInstance}" var="error">
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
	<div id="create-cliente" class="row" style="margin-top: 3%" role="main">
		<div class="col-md-8 col-md-offset-2">
			<div class="panel panel-primary" style="border-color: #48BFE6">
				<div class="panel-heading encabezadoPanelFormulario" style="background-color: #48BFE6;border-color: #48BFE6;">
					<image width="25px" class="imageInButton" src="${resource(dir: "images", file: "Impuesto/impuestoBlanco.png")}"></image>
					<g:message code="default.create.label" args="[entityName]" />
				</div>
				<div class="contenedor" style="margin-top: 3%; margin-bottom: 3%">
					<g:form url="[resource:impuestoInstance, action:'save']" >
						<fieldset class="form">
							<g:render template="form" model="[editable: false]"/>
						</fieldset>
						<fieldset class="buttons" style="text-align: right">
							<g:submitButton name="create" class="btn btn-primary color-vennda" value="${message(code: 'default.button.create.label', default: 'Create')}" />
						</fieldset>
					</g:form>
				</div>
			</div>
		</div>
	</div>
	</body>
</html>
