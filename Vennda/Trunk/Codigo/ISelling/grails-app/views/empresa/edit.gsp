<%@ page import="mx.elephantworks.iselling.Empresa" %>
<!DOCTYPE html>
<html>
	<head>
		<meta name="layout" content="main">
		<g:set var="entityName" value="${message(code: 'empresa.label', default: 'Empresa')}" />
		<title><g:message code="default.edit.label" args="[entityName]" /></title>
		<style>

		.texto-derecha{
			text-align: right;
		}

		.color-blanco{
				color: #FFFFFF;
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
	<br><br>


	<div class="row">
		<div class="col-md-8 col-md-offset-2">
			<div class="panel panel-primary" style="border-color: #48BFE6;">

				<div class="panel-heading encabezadoPanelFormulario" style="background-color: #48BFE6; border-color: #48BFE6;">
					<div class="row">
						<div class="col-md-6">
							<g:message code="default.perfil.label" default="Perfil de mi empresa"/>
						</div>
						<div class="col-md-6 texto-derecha">
							<g:link action="create" class="btn btn-primary color-vennda" data-toggle="modal" data-target=".bs-example-modal-lg">
								<image class="imageInButton" src="${resource(dir: "images", file: "editar-documento.png")}" width="20"></image>
								${message(code: 'empresa.modificarPin.labe', default: 'Modificar PIN')}
							</g:link>
							<g:link action="create" class="btn btn-primary color-vennda" data-toggle="modal" data-target=".modal-contrasena">
								<image class="imageInButton" src="${resource(dir: "images", file: "editar-documento.png")}" width="20"></image>
								${message(code: 'spring.security.ui.resetPassword.title')}
							</g:link>

						</div>
					</div>
				</div>

				<br>


				<g:if test="${flash.message}">
					<div class="alert alert-info alert-dismissible" role="alert" style="margin: 1em 1em 1em 1em;">
						<button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
						<strong>Aviso!</strong> ${flash.message}
					</div>
				</g:if>

				<g:if test="${flash.error}">
					<div class="alert alert-danger alert-dismissible" role="alert" style="margin: 1em 1em 1em 1em;">
						<button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
						<strong>Error!</strong> ${flash.error}
					</div>
				</g:if>

				<g:hasErrors bean="${command}">
					<ul class="errors" role="alert" style="padding: 1em 1em 0em 1em;">
						<g:eachError bean="${command}" var="error">
							<div class="alert alert-danger alert-dismissible" role="alert">
								<button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
								<li style="margin-left: 1em;"><g:message error="${error}"/></li>
							</div>

						</g:eachError>
					</ul>
				</g:hasErrors>

				<div class="contenedor">

					<g:form url="[resource:empresaInstance, action:'uploadImage']" method="POST" enctype="multipart/form-data">
					<div class="row">
						<div class="col-md-12 col-md-offset-4">
							<div class="custom-input-file">
								<input type="file" id="fileInput" name="fileInput" class="input-file">
								<image id="imgDiv" src="${resource(dir: 'imgLogo', file: empresaInstance?.logo)}" style="width: 65px"/>
							</div>

						</div>
					</div>
						<g:actionSubmitImage  id="btnUpload" value="Editar"  action="uploadImage" />
					</g:form>

					<g:form url="[resource:empresaInstance, action:'update']" method="PUT"  >

						<g:hiddenField name="version" value="${empresaInstance?.version}" />
						<fieldset class="form">
							<g:render template="formEmpresa"/>
						</fieldset>
						<br>
						<fieldset class="buttons texto-derecha">

							<%--<g:link controller="usuarios" class="btn btn-primary color-vennda" action="resetPassword">${message(code: 'spring.security.ui.resetPassword.title')}</g:link> --%>
							<g:if test="${empresaInstance?.formaPago == 2}">
								<a target="_blank" href="${empresaInstance?.urlPagoEfectivoPAYU}" class="btn btn-primary color-vennda">Formato de Pago</a>
							</g:if>
							<g:actionSubmit id="actualizarPerfil" class="btn btn-primary color-vennda" action="update" value="${message(code: 'default.button.update.label', default: 'Update')}" />
						</fieldset>
						<br><br>
					</g:form>
				</div>
			</div>
		</div>
	</div>

	<%-- inicia modal PIN --%>
	<div class="modal fade bs-example-modal-lg" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel">
		<div class="modal-dialog" role="document">
			<div class="modal-content">
				<div class="modal-header color-vennda">
					<button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
					<h4 class="modal-title color-blanco">Modificar PIN</h4>
				</div>
				<g:form controller="empresa" action="modificarPIN" method="POST">
					<div class="modal-body">
						<div class="contenedor">
							  <div class="row">
								  <div class="col-md-6">
									  <div class="form-group">
										  <label for="pin">
											  <g:message code="empresa.pin.label" default="PIN" />
											  <span class="required-indicator">*</span>
										  </label>
										  <g:passwordField name="pin" required="" minlength="4" maxlength="4" value="${command?.pin}" class="form-control" onkeypress="return soloNumeros(event);"/>
									  </div>
								  </div>
								  <div class="col-md-6">
									  <div class="form-group">
										  <label for="confirmarPin">
											  <g:message code="empresa.confirmarpin.label" default="Confirmar PIN" />
											  <span class="required-indicator">*</span>
										  </label>
										  <g:passwordField name="confirmarPin" required="" minlength="4" maxlength="4" value="${command?.pin}" class="form-control" onkeypress="return soloNumeros(event);"/>
									  </div>
								  </div>
							  </div>
						</div>
					</div>
					<div class="modal-footer">
						<button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
						<g:actionSubmit class="btn btn-primary color-vennda" action="modificarPIN" value="Guardar" />
					</div>
				</g:form>
			</div>
		</div>
	</div>

	<%-- Fin modal PIN --%>


	<%-- inicia modal Password --%>
	<div class="modal fade modal-contrasena" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel">
		<div class="modal-dialog" role="document">
			<div class="modal-content">
				<div class="modal-header color-vennda">
					<button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
					<h4 class="modal-title color-blanco">Modificar Contraseña</h4>
				</div>
				<g:form controller="empresa" action="cambiarContrsena" method="POST">
					<div class="modal-body">
						<div class="contenedor" style="width: 80%;">
							<div class="row">
								<div class="col-md-6">
									<div class="form-group ${hasErrors(bean: command, field: 'password', 'error')} required">
										<label for="password">
											<g:message code="usuario.password.label" default="Contraseña" />
											<span class="required-indicator">*</span>
										</label>

										<g:field type="password" id="password" name="password" class="form-control" required="" value="${command?.password}"/>
									</div>
								</div>

								<div class="col-md-6">
									<div class="form-group ${hasErrors(bean: command, field: 'password2', 'error')} required">
										<label for="password2">
											<g:message code="usuario.password2.label" default="Confirmar Contraseña" />
											<span class="required-indicator">*</span>
										</label>
										<g:field type="password" id="password2" name="password2" class="form-control" required="" value="${command?.password2}"/>
									</div>
								</div>
							</div>
						</div>
					</div>
					<div class="modal-footer">
						<button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
						<g:actionSubmit class="btn btn-primary color-vennda" action="cambiarContrsena" value="Guardar" />
					</div>
				</g:form>
			</div>
		</div>
	</div>
	</body>
</html>
