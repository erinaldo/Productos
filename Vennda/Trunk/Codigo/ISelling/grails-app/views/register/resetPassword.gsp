<html>
	<head>
		<meta name="layout" content="main"/>
        <title><g:message code='spring.security.ui.resetPassword.title'/></title>
        <style>
        body{
            background-color: #F5F5F5;
            /*#31708f*/
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
            <g:form action='resetPassword' name="resetPasswordForm">
                <g:hiddenField name='t' value='${token}'/>
                <br>

                <div class="panel panel-primary">

                    <div class="panel-heading encabezadoPanelFormulario" style="background-color: #48BFE6; border-color: #48BFE6;">
                        <g:message code='spring.security.ui.resetPassword.title'/>
                    </div>

                    <div class="panel-body">

                        <ul class="errors" role="alert" style="padding: 1em 1em 0em 1em;">
                            <g:eachError bean="${command}" var="error">
                                <div class="alert alert-danger alert-dismissible" role="alert">
                                    <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                    <li style="margin-left: 1em;"><g:message error="${error}"/></li>
                                </div>

                            </g:eachError>
                        </ul>

                        <div class="contenedor">
                            <div class="form-group ${hasErrors(bean: command, field: 'password', 'error')} required">
                                <label for="password">
                                    <g:message code="resetPasswordCommand.password.label" default="Contraseña" />
                                    <span class="required-indicator">*</span>
                                </label>
                                <input type="password" name="password" required="" class="form-control"/>
                            </div>

                            <div class="form-group ${hasErrors(bean: command, field: 'password2', 'error')} required">
                                <label for="password2">
                                    <g:message code="resetPasswordCommand.password2.label" default="Contraseña (nuevamente)" />
                                    <span class="required-indicator">*</span>
                                </label>
                                <input type="password" name="password2" required="" class="form-control"/>
                            </div>

                            <div class="form-group texto-derecha">
                                <input type="submit" value="${message(code: "spring.security.ui.resetPassword.submit", default: "Modificar contraseña")}" id="button_submit" class="btn btn-primary color-vennda">
                            </div>
                        </div>
                    </div>
                </div>
            </g:form>
        </div>
    </div>

	</body>
</html>
