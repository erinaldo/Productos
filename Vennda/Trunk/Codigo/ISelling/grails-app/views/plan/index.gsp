
<%@ page import="mx.elephantworks.iselling.Plan" %>
<!DOCTYPE html>
<html>
	<head>
		<meta name="layout" content="main">
		<g:set var="entityName" value="${message(code: 'plan.label', default: 'Plan')}" />
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
		<div class="col-md-12" style="margin-top: 3%">
			<div class="col-md-3">
				<label class="mensaje">
					<image class="imageInButton" src="${resource(dir: "images", file: "Plan/planGris.png")}"></image>
					<g:message code="planes.plan.label" default="Planes" />
				</label>
			</div>
			<div class="col-md-9" style="text-align: right">
				<g:link action="create" class="btn btn-primary buttonImage">
					<image class="imageInButton" src="${resource(dir: "images", file: "Plan/planBlanco.png")}"></image>
					<g:message code="default.new.label" args="[entityName]"/>
				</g:link>
			</div>
		</div>
	</div>
	<br>
	<g:if test="${flash.message}">
		<div class="alert alert-info alert-dismissible" role="alert">
			<button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
			<strong>Aviso!</strong> ${flash.message}
		</div>
	</g:if>
	<div class="table-responsive" style="margin-top: 3%">
		<div class="table table-hover" id="list-cliente" role="main">
			<table id="tablaPlanes" class="table table-hover">
			<thead>
					<tr>
					
						<th>${message(code: 'plan.identificador.label', default: 'Identificador')}</th>

						<th>${message(code: 'plan.precio.label', default: 'Precio')}</th>
					
						<th>${message(code: 'plan.fechaInicio.label', default: 'Inicio')}</th>
					
						<th>${message(code: 'plan.fechaFin.label', default: 'Fin')}</th>

						<th>${message(code: 'default.edit.label', default: 'Editar', args: [""])}</th>
					
					</tr>
				</thead>
				<tbody>
				<g:each in="${planInstanceList}" status="i" var="planInstance">
					<tr class="${(i % 2) == 0 ? 'even' : 'odd'}">
					
						<td>${fieldValue(bean: planInstance, field: "identificador")}</td>

						<td>${fieldValue(bean: planInstance, field: "precio")}</td>
					
						<td><g:formatDate format="dd-mm-yyyy" date="${planInstance.fechaInicio}" /></td>
					
						<td><g:formatDate format="dd-mm-yyyy" date="${planInstance.fechaFin}" /></td>

						<td>
							<g:link action="edit" id="${planInstance.id}">
								<image class="imageInButton" src="${resource(dir: "images", file: "editar.png")}"></image>
							</g:link>
						</td>

					</tr>
				</g:each>
				</tbody>
			</table>
		</div>
		<g:javascript>

		$(document).ready(function () {
			var tablaPuntoVenta = $("#tablaPlanes").dataTable({
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
