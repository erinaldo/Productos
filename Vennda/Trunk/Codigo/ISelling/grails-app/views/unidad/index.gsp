
<%@ page import="mx.elephantworks.iselling.Unidad" %>
<!DOCTYPE html>
<html>
	<head>
		<meta name="layout" content="main">
		<g:set var="entityName" value="${message(code: 'unidad.label', default: 'Unidad')}" />
		<title><g:message code="default.list.label" args="[entityName]" /></title>
		<style>
			.imageInButton{
				width:25px;
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
		</style>
	</head>
	<body>

	<div class="nav" role="navigation">
		<div class="row">
			<div class="col-md-12" style="margin-top: 3%">
				<div class="col-md-3">
					<label class="mensaje">
						<image class="imageInButton" src="${resource(dir: "images", file: "Unidad/unidadGris.png")}"></image>
						Unidades
					</label>
				</div>
				<div class="col-md-9" style="text-align: right">
					<g:link action="create" class="btn btn-primary buttonImage">
						<image class="imageInButton" src="${resource(dir: "images", file: "Unidad/unidadBlanco.png")}"></image>
						<g:message code="default.new.label" args="[entityName]"/>
					</g:link>
				</div>
			</div>
		</div>
	</div>

	<br>
	<br>
	<g:if test="${flash.message}">
		<div class="alert alert-info alert-dismissible" role="alert">
			<button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
			<strong>Aviso!</strong> ${flash.message}
		</div>
	</g:if>

		<div class="table-responsive" style="margin-top: 3%">
			<div id="list-unidad" class="table table-hover" role="main">
				<table id="tablaUnidad" class="table table-hover">
				<thead>
						<tr>
							<th>${message(code: 'unidad.abreviatura.label', default: 'Abreviatura')}</th>

							<th>${message(code: 'unidad.descripcion.label', default: 'Descripcion')}</th>

							<th>${message(code: 'default.edit.label', default: 'Editar', args: [""])}</th>

						</tr>
					</thead>
					<tbody>
					<g:each in="${unidadInstanceList}" status="i" var="unidadInstance">
						<tr class="${(i % 2) == 0 ? 'even' : 'odd'}">

							<td>${fieldValue(bean: unidadInstance, field: "abreviatura")}</td>

							<td>${fieldValue(bean: unidadInstance, field: "descripcion")}</td>

							<td>
								<g:link action="edit" id="${unidadInstance.id}" >
									<image class="imageInButton" src="${resource(dir: "images", file: "editar.png")}"></image>
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
			var tablaPuntoVenta = $("#tablaUnidad").dataTable({
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
