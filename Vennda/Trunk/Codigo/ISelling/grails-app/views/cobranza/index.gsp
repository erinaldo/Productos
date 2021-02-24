
<%@ page import="mx.elephantworks.iselling.Cobranza" %>
<!DOCTYPE html>
<html>
	<head>
		<meta name="layout" content="main">
		<g:set var="entityName" value="${message(code: 'cobranza.label', default: 'Cobranza')}" />
		<title><g:message code="default.list.label" args="[entityName]" /></title>
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
	<div class="row">
		<div class="col-md-6" style="margin-top: 3%">
			<div class="col-md-3">
				<label class="mensaje">
					<image class="imageInButton" src="${resource(dir: "images", file: "Cobranza/cobranzaGris.png")}"></image>
					<g:message code="cobranza.cobranza.label" default="Cobranza" />
				</label>
			</div>
		</div>

		<div class="col-md-6" style="margin-top: 3%; text-align: center;">
			<g:if test="${cobranzaInstanceList}">
				<div>
					<b><g:message code="cobranza.cliente.label" default="Cliente" />:</b> ${cobranzaInstanceList[0].cliente.razonSocial}<br>
					<b><g:message code="cobranza.diasCredito.label" default="Dias de credito" />:</b> ${cobranzaInstanceList[0].cliente.diasCredito}<br>
					<b><g:message code="cobranza.diasCredito.label" default="Limite de credito" />:</b> ${cobranzaInstanceList[0].cliente.limiteCredito}<br>
					<b><g:message code="cobranza.diasCredito.label" default="Credito actual" />:</b> ${cobranzaInstanceList[0].cliente.creditoActual}
				</div>
			</g:if>
		</div>
	</div>
	<br>
	<g:if test="${flash.message}">
		<div class="alert alert-info alert-dismissible" role="alert">
			<button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
			<strong><g:message code="alerta.title.label" default="Aviso!"></g:message> </strong> ${flash.message}
		</div>
		<br>
	</g:if>

	<div class="row">
		<g:form name="myForm" action="index">
			<div class="col-md-3">
				<label for="puntoVenta">
					<g:message code="cobranza.cliente.label" default="Cliente" />
				</label>
				<g:select id="cliente" name="clienteId" from="${mx.elephantworks.iselling.Cliente.filtroEmpresa(params.usuario).list()}" noSelection="['0':'Selecciona ...']"
						  optionKey="id"
						  optionValue="razonSocial"
						  class="form-control"/>
			</div>
			<div class="col-md-2" style="margin-top: 2em;">
				<g:submitButton name="buscar" value="Buscar" class="btn btn-primary color-vennda"/>
			</div>
		</g:form>
	</div>

	<div class="table-responsive" style="margin-top: 3%">
		<div id="list-cobranza" class="table table-hover" role="main">
			<table class="table table-hover" id="tablaCobranza">
			<thead>
					<tr>
						<th>${message(code: 'cobranza.folio.label', default: 'Folio')}</th>
					
						%{--<th>${message(code: 'cobranza.folio.label', default: 'Folio')}</th>--}%
					
						<th>${message(code: 'cobranza.fecha.label', default: 'Fecha')}</th>
					
						<th>${message(code: 'cobranza.importe.label', default: 'Importe')}</th>
					
						<th>${message(code: 'cobranza.saldo.label', default: 'Saldo')}</th>

						<th>${message(code: 'default.ver.label', default: 'Abonos')}</th>
					
					</tr>
				</thead>
				<tbody>
				<g:each in="${cobranzaInstanceList}" status="i" var="cobranzaInstance">
					<tr class="${(i % 2) == 0 ? 'even' : 'odd'}">

						<td>${fieldValue(bean: cobranzaInstance, field: "folio")}</td>

						%{--<td>${fieldValue(bean: cobranzaInstance, field: "folio")}</td>--}%
					
						<td><g:formatDate date="${cobranzaInstance?.fechaCreacion}" format="dd/mm/yyyy" /></td>
					
						<td><g:formatNumber number="${cobranzaInstance?.total}" type="currency" currencyCode="USD" locale="en_US"/></td>

						<td><g:formatNumber number="${cobranzaInstance?.saldo}" type="currency" currencyCode="USD" locale="en_US"/></td>

						<td>
							<g:link action="show" id="${cobranzaInstance.id}">
								VER
							</g:link>
						</td>
					
					</tr>
				</g:each>
				</tbody>
			</table>

		</div>
	</div>

		<g:javascript>

		$(document).ready(function () {
			var tablaPuntoVenta = $("#tablaCobranza").dataTable({
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
