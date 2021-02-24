<%@ page import="mx.elephantworks.iselling.PuntoVenta" %>

<div class="row">
    <div class="col-md-3" style="padding: 10px;">
        <div class="fieldcontain ${hasErrors(bean: puntoVentaInstance, field: 'cerrado', 'error')} ">
            <label for="cerrado">
                <g:message code="puntoVenta.cerrado.label" default="Cerrado:" />
            </label>
        </div>
    </div>

    <div class="col-md-9">
        <label class="switch">
            <g:checkBox name="cerrado" value="${puntoVentaInstance?.cerrado}" />
            <div class="slider round"></div>
        </label>
    </div>
</div>


<div class="row">
    <div class="col-md-3" style="padding: 10px;">
        <div class="fieldcontain ${hasErrors(bean: puntoVentaInstance, field: 'inventario', 'error')} ">
            <label for="inventario">
                <g:message code="puntoVenta.inventario.label" default="Inventario:" />
            </label>
        </div>
    </div>

    <div class="col-md-9">
        <label class="switch">
            <g:checkBox name="inventario" value="${puntoVentaInstance?.inventario}" />
            <div class="slider round"></div>
        </label>
    </div>
</div>





<div class="row">
    <div class="col-md-3" style="padding: 10px;">
        <div class="fieldcontain ${hasErrors(bean: puntoVentaInstance, field: 'impresoraActivo', 'error')} ">
            <label for="impresoraActivo">
                <g:message code="puntoVenta.impresoraActivo.label" default="Impresora:" />
            </label>
        </div>
    </div>

    <div class="col-md-9">
        <label class="switch">
            <g:checkBox name="impresoraActivo" id="impresoraActivo" value="${puntoVentaInstance?.impresoraActivo}" />
            <div class="slider round"></div>
        </label>
    </div>
</div>


<div class="row">
    <div class="col-md-3">
        <div class="fieldcontain ${hasErrors(bean: puntoVentaInstance, field: 'impresora', 'error')} required">
            <label for="impresora">
                <g:message code="puntoVenta.impresora.label" default="Modelo impresora:" />
            </label>
        </div>
    </div>
    <div class="col-md-9">
        <g:select id="impresora" name="impresora.id" from="${mx.elephantworks.iselling.ImpresoraHomologadas.list()}" optionKey="id" optionValue="nombreImpresora" noSelection="['0':'Seleccionar...']" value="${puntoVentaInstance?.impresora?.id}" class="many-to-one form-control"/>
    </div>
</div>


<g:javascript>

    $( document ).ready(function() {
        $("#impresora").prop('disabled', true);

        $('#impresoraActivo').change(function() {
            if($(this).is(":checked")) {
                $("#impresora").prop('disabled', false);
                $("#impresora option[value=0]").attr("selected",true);
            }else{
                $("#impresora").prop('disabled', true);
            }
        });
    });

</g:javascript>

