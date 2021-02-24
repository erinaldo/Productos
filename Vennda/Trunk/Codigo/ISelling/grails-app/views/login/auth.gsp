<g:set var='securityConfig' value='${applicationContext.springSecurityService.securityConfig}'/>
<html>
    <head>
        <meta name="layout" content="main"/>
        <title><g:message code='spring.security.ui.login.title'/></title>
        <style>
            .todo-derecha{
                text-align: right;
            }

            .estilo-form{
                width: 55%;
                margin: auto;
            }
        </style>
    </head>
    <body>
    <div class="semi-circulo-arriba color-vennda" style="height: 1em;"></div>

        <g:if test="${flash.message}">
            <div class="alert alert-danger alert-dismissible" role="alert" style="margin: 1em 1em 1em 1em;">
                <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                <strong>Error!</strong> ${flash.message}
            </div>
        </g:if>

        <div class="panel-default" style="border-color: #fff; color: #31708f; margin-top: 3em;">

            <div class="panel-body">

                <div class="row">

                    <div class="col-md-6" style="border-right:1px solid #ccc;">

                        <form action='${postUrl}' method='POST' id="loginForm" name="loginForm" autocomplete='off' class="estilo-form">

                            <div class="form-group">
                                <center><h3>Inicio de Sesión</h3></center>
                            </div>
                            <br>
                            <br>

                            <div class="form-group">
                                <label for="username"><g:message code='usuario.username.label'/></label>
                                <input type="text" class="form-control" name="${securityConfig.apf.usernameParameter}" id="username"/>
                            </div>

                            <div class="form-group">
                                <label for="password"><g:message code='usuario.password.label'/></label>
                                <input type="password" class="form-control" name="${securityConfig.apf.passwordParameter}" id="password"/>
                            </div>

                            <div class="form-group todo-derecha">
                                <span class="forgotPassword-link">
                                    <g:link controller='register' action='forgotPassword' class="btn btn-link btn-xs">
                                        <g:message code='spring.security.ui.login.forgotPassword'/>
                                    </g:link>
                                </span>
                                <br>
                                <span class="register-link">
                                    <g:link controller='register' class="btn btn-link btn-xs">
                                        <g:message code='spring.security.ui.login.register'/>
                                    </g:link>
                                </span>
                            </div>

                            <div class="form-group todo-derecha">
                                <input type="submit" value="${message(code: "spring.security.ui.login.login", default: "Login")}" id="loginButton_submit" class="btn btn-primary color-vennda" style="background-color: #48BFE6;">
                            </div>

                        </form>

                    </div>

                    <div class="col-md-6">
                        <asset:image src="230x230.png" alt="Grails" class="img-responsive center-block" style="width: 50%;"/>
                    </div>

                </div>

            </div>

        </div>

    <footer class="semi-circulo-abajo" style="background-color: #48BFE6; height: 1em;"></footer>

        <style type="text/css">
            #grailsLogo{
                /*display: none;*/
            }
            .register-link a,
            .forgotPassword-link a{
                color: #999999;
            }
        </style>

    </body>
</html>
