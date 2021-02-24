
<%@ page import="mx.elephantworks.iselling.Cliente" %>
<!DOCTYPE html>
<html>
	<head>
		<meta name="layout" content="main">
		<g:set var="entityName" value="${message(code: 'cliente.label', default: 'Cliente')}" />
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
					<image class="imageInButton" src="${resource(dir: "images", file: "Cliente/clienteGris.png")}"></image>
					<g:message code="clientes.cliente.label" default="Clientes" />
				</label>
			</div>
			<div class="col-md-9" style="text-align: right">
				<g:link action="create" class="btn btn-primary buttonImage">
					<image class="imageInButton" src="${resource(dir: "images", file: "Cliente/clienteBlanco.png")}"></image>
					<g:message code="default.new.label" args="[entityName]"/>
				</g:link>
			</div>
		</div>
	</div>
	<br>
	<g:if test="${flash.message}">
		<div class="alert alert-info alert-dismissible" role="alert">
			<button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
			<strong><g:message code="alerta.title.label" default="Aviso!"></g:message> </strong> ${flash.message}
		</div>
	</g:if>
	<div class="table-responsive" style="margin-top: 3%">
		<div class="table table-hover" id="list-cliente" role="main">
			<table class="table table-hover" id="tablaCliente">
			<thead>
					<tr>

						<th>${message(code: 'cliente.clave.label', default: 'Clave')}</th>

						<th>${message(code: 'cliente.razonSocial.label', default: 'Razon Social')}</th>

						<th>${message(code: 'cliente.listaPrecio.label', default: 'Lista de Precio')}</th>

						<th>${message(code: 'cliente.limiteCredito.label', default: 'Límite de Crédito')}</th>

						<th>${message(code: 'default.edit.label', default: 'Editar', args: [""])}</th>

						<th>${message(code: 'default.button.delete.label', default: 'Eliminar', args: [""])}</th>

					</tr>
				</thead>
				<tbody>
				<g:each in="${clienteInstanceList}" status="i" var="clienteInstance">
					<tr class="${(i % 2) == 0 ? 'even' : 'odd'}">
					
						<td>${fieldValue(bean: clienteInstance, field: "clave")}</td>
					
						<td>${fieldValue(bean: clienteInstance, field: "razonSocial")}</td>
					
						<td>${fieldValue(bean: clienteInstance, field: "listaPrecios")}</td>
					
						<td>${fieldValue(bean: clienteInstance, field: "limiteCredito")}</td>


						<td>
							<g:link action="edit" id="${clienteInstance.id}">
								<image class="imageInButton" src="${resource(dir: "images", file: "editar.png")}"></image>
							</g:link>
						</td>

						<td>
							<g:form url="[resource:clienteInstance, action:'delete']" method="DELETE">
								<g:actionSubmitImage width="25px" value="${message(code: 'default.deleted.message', default: 'Eliminar', args: [""])}" src="${resource(dir: 'images', file: 'eliminar.png')}" action="delete" onclick="return confirm('${message(code: 'default.button.delete.confirm.message', default: 'Are you sure?')}');" />
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
			var tablaCliente = $("#tablaCliente").dataTable({
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
