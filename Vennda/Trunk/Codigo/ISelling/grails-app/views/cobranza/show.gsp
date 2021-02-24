<%@ page import="mx.elephantworks.iselling.Cobranza" %>
<!DOCTYPE html>
<html>
	<head>
		<meta name="layout" content="main">
		<g:set var="entityName" value="${message(code: 'cobranza.label', default: 'Cobranza')}" />
		<title><g:message code="default.show.label" args="[entityName]" /></title>
		<style>
		.imageInButton{
			width:30px;
		}
		.buttonImage{
			background-color: #48BFE6;
		}
		thead{
			background-color: #1c94c4;
			text-align: center;

		}
		thead tr th{
			font-family: "Arial";
			font-size: 14px;
			color:#FFF;
			text-align: center;
		}
		tbody tr{
			background-color: #D8DFE5;
			font-family: "Arial";
			font-size: 12px;
			color:#000;
			text-align: center;
		}
		tbody tr td{
			border-bottom: 1px solid #9B9B9B;
		}
		.semi-circulo-abajo
		{
			display: none;
		}
		.semi-circulo-arriba
		{
			display: none;
		}
		</style>
	</head>
	<body>
	<div style="margin-top: 3%">
		<g:link action="index" params="[clienteId: datosCliente.id]">
			<image width="30px" class="imageInButton" src="${resource(dir: "images", file: "volver.png")}"></image>
			<label class="mensaje"><g:message code="volver.title.label" default="Volver"></g:message></label>
		</g:link>
	</div>

	<div class="table-responsive" style="margin-top: 3%">
		<div id="list-cobranza" class="table table-hover" role="main">
			<table class="table table-hover" id="tablaAbonos">
				<thead>
				<tr>
					<th>${message(code: 'abono.fecha.label', default: 'Fecha')}</th>

					<th>${message(code: 'abono.metodoPago.label', default: 'Metodo de Pago')}</th>

					<th>${message(code: 'abono.referencia.label', default: 'Referencia')}</th>

					<th>${message(code: 'abono.antes.label', default: 'Antes')}</th>

					<th>${message(code: 'abono.abono.label', default: 'Abono')}</th>

					<th>${message(code: 'abono.despues.label', default: 'Despues')}</th>

				</tr>
				</thead>
				<tbody>
				<g:each in="${abonos}" status="i" var="abonosInstance">
					<tr class="${(i % 2) == 0 ? 'even' : 'odd'}">

						<td><g:formatDate date="${abonosInstance?.fecha}" format="dd-mm-yyyy" /></td>

						<g:if test="${abonosInstance?.abono.metodoPago == 1}">
							<td>${message(code: 'abono.efectivo.label', default: 'Efectivo')}</td>
						</g:if>
						<g:elseif test="${abonosInstance?.abono.metodoPago == 2}">
							<td>${message(code: 'abono.tarjeta.label', default: 'Tarjeta')}</td>
						</g:elseif>

						<td>${fieldValue(bean: abonosInstance, field: "abono.referencia")}</td>

						<td><g:formatNumber number="${abonosInstance?.saldo}" type="currency" currencyCode="USD" locale="en_US"/></td>

						<td><g:formatNumber number="${abonosInstance?.abono.monto}" type="currency" currencyCode="USD" locale="en_US"/></td>

						<td><g:formatNumber number="${abonosInstance?.saldoAbono}" type="currency" currencyCode="USD" locale="en_US"/></td>


					</tr>
				</g:each>
				</tbody>
			</table>

		</div>
	</div>

	<g:javascript>

		$(document).ready(function () {
			var tablaPuntoVenta = $("#tablaAbonos").dataTable({
			   "sPaginationType": "full_numbers",
				"iDisplayLengthChange": 10,
				"bLengthChange": false,
				"bStateSave": true,
				"language": {
			       "url": "${resource(dir: 'javascripts', file:'spanish.json')}"
				}
			});
		});

	</g:javascript>

	</body>
</html>
