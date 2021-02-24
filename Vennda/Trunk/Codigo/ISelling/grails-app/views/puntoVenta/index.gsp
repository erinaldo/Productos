
<%@ page import="mx.elephantworks.iselling.PuntoVenta" %>
<!DOCTYPE html>
<html>
	<head>
		<meta name="layout" content="main">
		<g:set var="entityName" value="${message(code: 'puntoVenta.label', default: 'PuntoVenta')}" />
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
		.semi-circulo-abajo
		{
			display: none;
		}
		.semi-circulo-arriba
		{
			display: none;
		}
		.color-blanco{
			color: #fff;
		}
		</style>
	</head>
	<body>

	<div class="nav" role="navigation">
		<div class="row">
			<div class="col-md-12" style="margin-top: 3%">
				<div class="col-md-3">
					<label class="mensaje">
						<image class="imageInButton" src="${resource(dir: "images", file: "PuntoVenta/PuntoVentaGris.png")}"></image>
						Puntos de Venta
					</label>
				</div>
				<div class="col-md-9" style="text-align: right">
					<g:link action="create" class="btn btn-primary color-vennda">
						<image class="imageInButton" src="${resource(dir: "images", file: "PuntoVenta/PuntoVentaBlanco.png")}"></image>
						<g:message code="puntoVenta.nuevo.label" default="Nuevo Punto de Venta"/>
					</g:link>

				</div>
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

	<g:if test="${flash.error}">
		<div class="alert alert-danger alert-dismissible" role="alert">
			<button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
			<strong>Error!</strong> ${flash.error}
		</div>
	</g:if>

	<div class="table-responsive" style="margin-top: 3%">
		<div id="list-puntoVenta" class="content scaffold-list" role="main">
			<table id="tablaPuntoVenta" class="display table table-hover">
				<thead>
					<tr>
						<th>${message(code: 'puntoVenta.numNegocio.label', default: 'Numero de Negocio')}</th>

						<th>${message(code: 'puntoVenta.nombreNegocio.label', default: 'Nombre')}</th>

						<th>${message(code: 'puntoVenta.direccion.label', default: 'Dirección')}</th>

						<th>${message(code: 'default.edit.label', default: 'Editar', args: [""])}</th>

						<th>${message(code: 'default.button.delete.label', default: 'Eliminar', args: [""])}</th>
					</tr>
				</thead>
				<tbody>
					<g:each in="${puntoVentaInstanceList}" status="i" var="puntoVentaInstance">
						<tr class="${(i % 2) == 0 ? 'even' : 'odd'}">

							<td>${fieldValue(bean: puntoVentaInstance, field: "numeroNegocio")}</td>

							<td>${fieldValue(bean: puntoVentaInstance, field: "nombreNegocio")}</td>

							<td>${fieldValue(bean: puntoVentaInstance, field: "calle") + " #" + fieldValue(bean: puntoVentaInstance, field: "noExterior")}</td>

							<td>
								<g:link action="edit" id="${puntoVentaInstance.id}" >
									<image class="imageInButton" src="${resource(dir: "images", file: "editar.png")}"></image>
								</g:link>
							</td>

							<td>
								<g:form url="[resource:puntoVentaInstance, action:'delete']" method="DELETE">
									<g:actionSubmitImage width="25px" value="${message(code: 'default.button.delete.label', default: 'Eliminar', args: [""])}" src="${resource(dir: 'images', file: 'eliminar.png')}" action="delete" onclick="return confirm('${message(code: 'default.button.delete.confirm.message', default: 'Are you sure?')}');" />

								</g:form>
							</td>

						</tr>
					</g:each>
				</tbody>
			</table>
		</div>
	</div>
	<g:javascript>

		$(document).ready(function () {
			var tablaPuntoVenta = $("#tablaPuntoVenta").dataTable({
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
