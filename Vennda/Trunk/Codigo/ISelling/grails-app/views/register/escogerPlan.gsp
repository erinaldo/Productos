<%--
  Created by IntelliJ IDEA.
  User: Elephant
  Date: 30/04/17
  Time: 19:55
--%>

<%@ page contentType="text/html;charset=UTF-8" %>
<html>
<head>
    <meta name="layout" content="main">
    <g:set var="entityName" value="${message(code: 'resgistro.planes.label', default: 'Planes')}" />
    <title><g:message code="resgistro.escogerPlanes.label" default="Escoge tu Plan"/></title>
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
            <br/>
            <div class="panel panel-primary" style="border-color: #48BFE6;">
                <div class="panel-heading encabezadoPanelFormulario" style="background-color: #48BFE6; border-color: #48BFE6;">
                    <g:message code="resgistro.escogerPlanes.label" default="Escoge tu Plan"/>
                </div>
                <br>

                <div class="contenedor">

                        <g:each in="${planes}" var="plan">
                            <div class="panel panel-default" style=" border-color: ${plan.color};">
                                <div class="panel-heading" style="background-color: ${plan.color}; color: #FFFFFF; font-size: xx-large;">Plan ${plan.identificador}</div>
                                <div class="panel-body">
                                    <div style="text-align: right;">Vigente Hasta: <g:formatDate date="${plan.fechaFin}" format="dd-mm-yyyy" /></div>
                                    <br>
                                    <p style="font-size: large;">${plan.descripcion}</p>
                                    <br>
                                    <center>
                                        <b style="font-size: x-large;">Precio: $${plan.precio}</b>
                                        <br>
                                        <br>
                                        <g:form action="guardarPlan" id="${empresaInstance.id}" >
                                            <g:hiddenField name="idPlan" value="${plan.id}"/>
                                            <g:submitButton name="create" class="btn btn-primary btn-lg btn-block" style="background-color: ${plan.color}; border-color: ${plan.color};" value="Comprar"/>
                                        </g:form>
                                    </center>

                                </div>
                            </div>
                        </g:each>


                </div>

            </div>
        </div>
    </div>
</body>
</html>