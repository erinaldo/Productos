<%--
  Created by IntelliJ IDEA.
  User: Elephant
  Date: 01/05/17
  Time: 14:46
--%>

<%@ page contentType="text/html;charset=UTF-8" %>
<html>
<head>
    <meta name="layout" content="main">
    <g:set var="entityName" value="${message(code: 'resgistro.formaPago.label', default: 'Forma de Pago')}" />
    <title><g:message code="resgistro.formaPago.label" default="Forma de Pago"/></title>
</head>

<body>

    <div class="row">
        <div class="col-md-8 col-md-offset-2">
            <br/>
            <div class="panel panel-primary" style="border-color: #48BFE6;">
                <div class="panel-heading encabezadoPanelFormulario" style="background-color: #48BFE6; border-color: #48BFE6;">
                    <g:message code="resgistro.formaPago.label" default="Forma de Pago"/>
                </div>
                <br>
                <g:if test="${flash.error}">
                    <div class="alert alert-danger" style="margin-left: 10px; margin-right: 10px;" role="status">${flash.error}</div>
                </g:if>

                <div class="contenedor">
                    <center>
                        <b style="font-size: x-large;">Plan: ${empresaInstance.plan.identificador}</b>
                    </center>
                    <br>

                    <div class="panel panel-default" style=" border-color: #48BFE6;">
                        <div class="panel-heading" style="background-color: #48BFE6; border-color: #48BFE6; color: #FFFFFF; font-size: large;">Pagos Recurrentes</div>
                        <div class="panel-body">
                            <div class="alert alert-info alert-dismissible" role="alert">
                                <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                <strong>Los pagos recurrentes son</strong> una forma de pagar mensualmente bajo el registro de una trajeta de debito o credito ya que se
                                hace desde VENNDA automaticamente.
                            </div>
                            <fieldset class="form">
                                <%--<g:render template="form" model="[editable:false]"/>--%>
                                <g:form action="pagoTarjeta" id="${empresaInstance.id}" >
                                    <g:render template="formPagosRecurrentes"/>
                                    <div class="form-group" style="text-align: right;">
                                        <button type="submit" class="btn btn-primary color-vennda" id="confirm-purchase">Confirmar</button>
                                    </div>
                                </g:form>
                            </fieldset>

                        </div>
                    </div>

                    <div class="panel panel-default" style=" border-color: #48BFE6;">
                        <div class="panel-heading" style="background-color: #48BFE6; border-color: #48BFE6; color: #FFFFFF; font-size: large;">Pagos Mesuales</div>
                        <div class="panel-body">
                            <div class="alert alert-info alert-dismissible" role="alert">
                                <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                <strong>Los pagos mensuales se</strong> se ralizan fisicamente en los siguientes establecimientos:
                            </div>

                            <fieldset class="form">
                                <%--<g:render template="form" model="[editable:false]"/>--%>
                                <g:render template="formPagosEfectivo" model="[empresaInstance: empresaInstance]"/>
                            </fieldset>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</body>
</html>