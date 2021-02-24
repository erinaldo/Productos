<%@ page import="mx.elephantworks.iselling.TipoCuenta" %>
<html>
	<head>
		<meta name="layout" content="main"/>
        <title><g:message code='spring.security.ui.register.title'/></title>
        <style>
            body{
                background-color: #F5F5F5;
            }
            .texto-derecha{
                text-align: right;
            }
        </style>

        <script>
            // Solo permite ingresar numeros.
            function soloNumeros(e){
                var key = window.Event ? e.which : e.keyCode;
                return (key <= 57)
            }
        </script>

	</head>
	<body>

    <br>

    <div class="row">
        <div class="col-md-8 col-md-offset-2">
            <g:form action='register' name='registerForm'>
                <br/>
                <div class="panel panel-primary" style="border-color: #48BFE6;">

                    <div class="panel-heading encabezadoPanelFormulario" style="background-color: #48BFE6; border-color: #48BFE6;">
                        <g:message code="spring.security.ui.register.title" default="Registro"/>
                    </div>

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

                    <g:if test='${emailSent}'>
                        <div class="alert alert-info alert-dismissible" role="alert" style="margin: 1em 1em 1em 1em;">
                            <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                            <strong>Aviso!</strong> <g:message code='spring.security.ui.register.sent'/>
                        </div>
                    </g:if>
                    <g:else>
                        <br>

                        <div class="contenedor">

                            <div class="form-group">
                                <label for="tipoCuenta">
                                    <g:message code="empresa.tipoCuenta.label" default="Tipo de Cuenta" />

                                </label>
                                <g:select id="tipoCuenta"
                                          name="tipoCuenta.id"
                                          from="${TipoCuenta.list()}"
                                          optionKey="id"
                                          optionValue="descripcion"
                                          value="${command?.tipoCuenta?.id}"
                                          class="many-to-one form-control"/>
                            </div>

                            <div class="form-group">
                                <label for="nombreEmmpres">
                                    <g:message code="empresa.nombreEmpresa.label" default="Nombre de la Empresa" />
                                </label>
                                <g:textField name="nombreEmpresa" value="${command?.nombreEmpresa}" class="form-control"/>

                            </div>

                            <div class="form-group">
                                <label for="nombre">
                                    <g:message code="empresa.nombre.label" default="Nombre" />
                                </label>
                                <g:textField name="nombre" value="${command?.nombre}" class="form-control"/>

                            </div>

                            <div class="form-group">
                                <label for="apellidoPaterno">
                                    <g:message code="empresa.apellidoPaterno.label" default="Apellido Paterno" />
                                </label>
                                <g:textField name="apellidoPaterno" value="${command?.apellidoPaterno}" class="form-control"/>
                            </div>

                            <div class="form-group">
                                <label for="apellidoMaterno">
                                    <g:message code="empresa.apellidoMaterno.label" default="Apellido Materno" />
                                </label>
                                <g:textField name="apellidoMaterno" value="${command?.apellidoMaterno}" class="form-control"/>
                            </div>

                            <div class="form-group">
                                <label for="username">
                                    <g:message code="empresa.email.label" default="Email" />
                                    <span class="required-indicator">*</span>
                                </label>
                                <g:textField name="username" required="" value="${command?.username}" class="form-control"/>

                            </div>

                            <div class="form-group">
                                <label for="username">
                                    <g:message code="empresa.email2.label" default="Repetir Email" />
                                    <span class="required-indicator">*</span>
                                </label>
                                <g:textField name="username2" required="" value="${command?.username2}" class="form-control"/>
                            </div>

                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="password">
                                            <g:message code="empresa.password.label" default="Contraseña" />
                                            <span class="required-indicator">*</span>
                                        </label>
                                        <g:passwordField name="password" required="" value="${command?.password}" class="form-control"/>
                                    </div>

                                </div>

                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="password">
                                            <g:message code="empresa.pin.label" default="PIN" />
                                            <span class="required-indicator">*</span>
                                        </label>
                                        <g:passwordField name="pin" required="" minlength="4" maxlength="4" value="${command?.pin}" class="form-control" onkeypress="return soloNumeros(event);"/>
                                    </div>
                                </div>
                            </div>



                            <div class="form-group texto-derecha">
                                <input type="submit" value="${message(code: "spring.security.ui.register.submit", default: "Crear Cuenta")}" id="button_submit" class="btn btn-primary color-vennda">
                            </div>

                        </div>

                    </g:else>


                </div>
            </g:form>
        </div>
    </div>


	</body>


</html>
