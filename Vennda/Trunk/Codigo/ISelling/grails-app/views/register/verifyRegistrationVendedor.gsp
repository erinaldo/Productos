<html>
	<head>
		<meta name="layout" content="main"/>
        <title><g:message code='spring.security.ui.resetPassword.title'/></title>
	</head>
	<body>
        <g:form action='resetPassword' name="resetPasswordForm">
            <g:hiddenField name='t' value='${token}'/>
            </br>
            <g:hasErrors bean="${command}">
                <ul class="errors" role="alert">
                    <g:eachError bean="${command}" var="error">
                        <li <g:if test="${error in org.springframework.validation.FieldError}">data-field-id="${error.field}"</g:if>><g:message error="${error}"/></li>
                    </g:eachError>
                </ul>
            </g:hasErrors>

            <div class="panel panel-primary">

                <div class="panel-heading">
                    <h3 class="panel-title"><g:message code='spring.security.ui.resetPassword.title'/></h3>
                </div>

                <div class="panel-body">

                    <div class="form-group ${hasErrors(bean: command, field: 'password', 'error')} required">
                        <label for="password">
                            <g:message code="resetPasswordCommand.password.label" default="Contraseña" />
                            <span class="required-indicator">*</span>
                        </label>
                        <input type="password" name="password" required="" class="form-control"/>
                        <span id="helpBlock" class="help-block">
                            <g:message code='spring.security.ui.resetPassword.description'/>
                        </span>
                    </div>

                    <div class="form-group ${hasErrors(bean: command, field: 'password2', 'error')} required">
                        <label for="password2">
                            <g:message code="resetPasswordCommand.password2.label" default="Contraseña (nuevamente)" />
                            <span class="required-indicator">*</span>
                        </label>
                        <input type="password" name="password2" required="" class="form-control"/>
                        <span id="helpBlock2" class="help-block">
                            <g:message code='spring.security.ui.resetPassword.description'/>
                        </span>
                    </div>

                    <div class="form-group text-center">
                        <input type="submit" value="${message(code: "spring.security.ui.resetPassword.submit", default: "Modificar contraseña")}" id="button_submit" class="btn btn-primary">
                    </div>

                </div>

            </div>
        </g:form>
	</body>
</html>
