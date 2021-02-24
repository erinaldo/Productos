<!DOCTYPE html>
<html>
	<head>
		<meta name="layout" content="main">
		<g:set var="entityName" value="${message(code: 'categoria.label', default: 'Categoria')}" />
		<title><g:message code="default.create.label" args="[entityName]" /></title>
		<style>
			body{
				background-color: #F5F5F5;
			}
			link
			{
				text-decoration: none;
			}
			 label.filebutton {

				 overflow:hidden;
				 position:relative;

			 }
			.custom-input-file .input-file{
				width: 65px;
				height: 65px;
				margin: 0px;
				padding: 0px;
				outline: 0;
				position: absolute;
				opacity: 0;
				filter: alpha(opacity=0);
			}
		</style>
	</head>
	<body>
	<div style="margin-top: 3%">
		<g:link action="index">
			<image width="30px" class="imageInButton" src="${resource(dir: "images", file: "volver.png")}"></image>
			<label class="mensaje"><g:message code="volver.title.label" default="Volver"></g:message> </label>
		</g:link>
	</div>
		<div class="row" style="margin-top: 3%">
			<div class="col-md-8 col-md-offset-2">
				<div class="panel panel-primary" style="border-color: #48BFE6">
					<div class="panel-heading encabezadoPanelFormulario" style="background-color: #48BFE6;border-color: #48BFE6;">
						<image width="25px" class="imageInButton" src="${resource(dir: "images", file: "Categoria/categoriaBlanco.png")}"></image>
						<g:message code="default.create.label" args="[entityName]" />
					</div>
					<g:if test="${flash.message}">
						<div class="alert alert-info alert-dismissible" role="alert">
							<button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
							<strong><g:message code="alerta.title.label" default="Aviso!"></g:message> </strong> ${flash.message}
						</div>
					</g:if>
					<g:hasErrors bean="${categoriaInstance}">
						<div class="alert alert-info alert-dismissible" role="alert">
							<button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
							<ul role="alert">
								<g:eachError bean="${categoriaInstance}" var="error">
									<li <g:if test="${error in org.springframework.validation.FieldError}">data-field-id="${error.field}"</g:if>><g:message error="${error}"/></li>
								</g:eachError>
							</ul>
						</div>
					</g:hasErrors>
					<div class="contenedor" style="margin-top: 3%; margin-bottom: 3%">

						<g:form url="[resource:categoriaInstance, action:'uploadImage']"  method="POST" enctype="multipart/form-data">
							<div class="row">
								<g:hiddenField name="txtIdentificador" id="txtIdentificador" value="yfyf" class="form-control"></g:hiddenField>
								<div class="col-md-12 col-md-offset-4">
									<div class="custom-input-file">
										<input type="file" id="fileInput" name="fileInput" class="input-file">
										<image id="imgDiv" src="${resource(dir: 'imgCategorias', file: categoriaInstance?.imagen)}" style="width: 65px;"/>
									</div>
									<g:actionSubmitImage  id="btnUpload" value="Editar"  action="uploadImage"  />
								</div>
							</div>
						</g:form>

						<g:form url="[resource:categoriaInstance, action:'save']"  enctype="multipart/form-data" >
							<fieldset class="form">
								<g:render template="form"/>
							</fieldset>
							<fieldset class="buttons" style="text-align: right">
								<g:submitButton id="actualizarPerfil" name="create" class="btn btn-primary color-vennda" value="${message(code: 'default.button.create.label', default: 'Create')}" />
							</fieldset>
						</g:form>
					</div>
					</div>
				</div>
			</div>
		</div>

	</body>
</html>
