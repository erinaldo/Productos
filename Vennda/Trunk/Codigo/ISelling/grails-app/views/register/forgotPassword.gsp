<html>
	<head>
        <title><g:message code='spring.security.ui.forgotPassword.title'/></title>
		<meta name="layout" content="main"/>
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

        <div class="row">
            <div class="col-md-8 col-md-offset-2">
                <br>
                <g:form action='forgotPassword' name="forgotPasswordForm" autocomplete='off'>
                    <br>

                    <div class="panel panel-primary">

                        <div class="panel-heading encabezadoPanelFormulario" style="background-color: #48BFE6; border-color: #48BFE6;">
                            <g:message code='spring.security.ui.forgotPassword.title'/>
                        </div>

                        <div class="panel-body">

                            <g:if test="${flash.error}">
                                <div class="alert alert-danger alert-dismissible" role="alert" style="margin: 1em 1em 1em 1em;">
                                    <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                    <strong>Aviso!</strong> ${flash.error}
                                </div>
                            </g:if>

                            <g:if test='${emailSent}'>
                                <div class="alert alert-info alert-dismissible" role="alert" style="margin: 1em 1em 1em 1em;">
                                    <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                    <strong>Aviso!</strong>  <g:message code= 'spring.olvidasteContrasena.exito.label' default= 'Se envio un correo electronico a su cuenta para reiniciar la contraseña.'/>
                                </div>
                            </g:if>
                            <g:else>

                                <div class="contenedor">

                                    <div class="form-group ${hasErrors(bean: command, field: 'username', 'error')} required">
                                        <label for="username">
                                            <g:message code="usuario.username.label" default="Email" />
                                            <span class="required-indicator">*</span>
                                        </label>
                                        <g:textField name="username" required="" value="${command?.username}" class="form-control"/>
                                        <span id="helpBlock" class="help-block">
                                            <g:message code='spring.security.ui.forgotPassword.description'/>
                                        </span>
                                    </div>

                                    <div class="form-group texto-derecha">
                                        <input type="submit" value="${message(code: "spring.security.ui.forgotPassword.submit", default: "Recuperar contraseña")}" id="button_submit" class="btn btn-primary color-vennda">
                                    </div>

                                </div>

                            </g:else>
                        </div>

                    </div>
                </g:form>
            </div>
        </div>

	</body>
</html>
