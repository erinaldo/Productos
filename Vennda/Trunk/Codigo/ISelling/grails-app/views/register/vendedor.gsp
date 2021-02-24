<%@ page import="mx.elephantworks.iselling.TipoCuenta" %>
<html>
	<head>
		<meta name="layout" content="main"/>
        <title><g:message code='spring.security.ui.register.title'/></title>
	</head>
	<body>
        <g:hasErrors bean="${command}">
            <ul class="errors" role="alert">
                <g:eachError bean="${command}" var="error">
                    <li <g:if test="${error in org.springframework.validation.FieldError}">data-field-id="${error.field}"</g:if>><g:message error="${error}"/></li>
                </g:eachError>
            </ul>
        </g:hasErrors>
        <g:form action='registrarVendedor' name='registrarVendedorForm'>
            <br/>
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <h2 class="panel-title"><g:message code="spring.security.ui.register.title" default="Registro"/></h2>
                </div>

                <div class="panel-body">
                    <g:if test='${emailSent}'>
                        <div class="alert alert-info" role="alert">
                            <g:message code='spring.security.ui.register.sent'/>
                            <a class="home" href="${createLink(uri: '/')}"><g:message code="default.home.label"/></a>
                        </div>
                    </g:if>
                    <g:else>

                        <div class="panel panel-default">

                            <div class="panel-heading">
                                <h3 class="panel-title"><g:message code="vendedor.header.datosduenio" default="Datos del Vendedor"/></h3>
                            </div>

                            <div class="panel-body">

                                <div class="form-group ${hasErrors(bean: command, field: 'username', 'error')} required">
                                    <label for="username">
                                        <g:message code="vendedor.email.label" default="Email" />
                                        <span class="required-indicator">*</span>
                                    </label>
                                    <g:textField name="username" required="" value="${command?.username}" class="form-control"/>

                                </div>

                                <div class="form-group ${hasErrors(bean: command, field: 'nombre', 'error')}">
                                    <label for="nombre">
                                        <g:message code="vendedor.nombre.label" default="Nombre" />
                                    </label>
                                    <g:textField name="nombre" value="${command?.nombre}" class="form-control"/>

                                </div>

                                <div class="form-group ${hasErrors(bean: command, field: 'apellidoPaterno', 'error')}">
                                    <label for="apellidoPaterno">
                                        <g:message code="vendedor.apellidoPaterno.label" default="Apellido Paterno" />
                                    </label>
                                    <g:textField name="apellidoPaterno" value="${command?.apellidoPaterno}" class="form-control"/>

                                </div>

                                <div class="form-group ${hasErrors(bean: command, field: 'apellidoMaterno', 'error')}">
                                    <label for="apellidoMaterno">
                                        <g:message code="vendedor.apellidoMaterno.label" default="Apellido Materno" />
                                    </label>
                                    <g:textField name="apellidoMaterno" value="${command?.apellidoMaterno}" class="form-control"/>

                                </div>

                                <div class="form-group ${hasErrors(bean: command, field: 'porcentajeMaxDescuento', 'error')} required">
                                    <label for="porcentajeMaxDescuento">
                                        <g:message code="vendedor.porcentajeMaxDescuento.label" default="Porcentaje Máximo Descuento" />
                                        <span class="required-indicator">*</span>
                                    </label>
                                    <g:textField name="porcentajeMaxDescuento" value="${command?.porcentajeMaxDescuento}" class="form-control"/>

                                </div>

                            </div>


                        </div>

                        <div class="form-group text-center">

                            <input type="submit" value="${message(code: "spring.security.ui.register.submit", default: "Crear Cuenta")}" id="button_submit" class="btn btn-primary">
                        </div>

                    </g:else>
                </div>
            </div>
        </g:form>
	</body>
</html>
