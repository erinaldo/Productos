
<%@ page import="mx.elephantworks.iselling.Inventario" %>
<!DOCTYPE html>
<html>
	<head>
		<meta name="layout" content="main">
		<g:set var="entityName" value="${message(code: 'inventario.label', default: 'Inventario')}" />
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
					<div class="col-md-4">
						<label class="mensaje">
							<image class="imageInButton" src="${resource(dir: "images", file: "Inventario/EnvioGris.png")}"></image>
							Inventario
							<g:if test="${puntoVenta}">
								- ${puntoVenta.nombreNegocio}
							</g:if>
						</label>
					</div>
					<div class="col-md-8" style="text-align: right">

						<g:form name="myForm" action="create">

							<button type="button" class="btn btn-primary color-vennda" data-toggle="modal" data-target=".bs-example-modal-lg1">
								<image class="imageInButton" src="${resource(dir:"images", file: "importar.png")}"></image>
								Importar
							</button>

							<button type="button" class="btn btn-primary color-vennda" data-toggle="modal" data-target=".bs-example-modal-lg">
								<image class="imageInButton" src="${resource(dir:"images", file: "importar.png")}"></image>
								Masivo
							</button>

							<g:hiddenField name="idPuntoVenta" />

							<button class="btn btn-primary color-vennda">
								<image class="imageInButton" src="${resource(dir: "images", file: "Inventario/EnvioBlanco.png")}"></image>
								<g:message code="inventario.manual.label" default="Manual"/>
							</button>
						</g:form>

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


		<br>
		<div class="row">
			<g:form name="myForm" action="index">
				<div class="col-md-3">
					<label for="puntoVenta">
						<g:message code="inventario.puntoVenta.label" default="Punto de Venta" />
					</label>
					<g:select id="puntoVenta" name="puntoVentaId" from="${mx.elephantworks.iselling.PuntoVenta.list()}" noSelection="['0':'Selecciona ...']"
							  optionKey="id"
							  optionValue="nombreNegocio"
							  class="form-control"/>
				</div>
				<div class="col-md-2" style="margin-top: 2em;">
					<g:submitButton name="buscar" value="Buscar" class="btn btn-primary color-vennda"/>
				</div>
			</g:form>
		</div>



		<div class="table-responsive" style="margin-top: 3%">
			<div id="list-inventario" class="content scaffold-list" role="main">
				<table id="tablaInventario" class="display table table-hover">
				<thead>
						<tr>


							<th><g:message code="inventario.puntoVenta.label" default="Punto de Venta" /></th>

							<th><g:message code="inventario.clave.label" default="Clave" /></th>

							<th><g:message code="inventario.producto.label" default="Producto" /></th>

							<th><g:message code="inventario.cantidad.label" default="Cantidad" /></th>

							<th>${message(code: 'default.edit.label', default: 'Editar', args: [""])}</th>

						</tr>
					</thead>
					<tbody>
						<g:each in="${inventarioInstanceList}" status="i" var="inventarioInstance">
							<tr class="${(i % 2) == 0 ? 'even' : 'odd'}">



								<td>${fieldValue(bean: inventarioInstance, field: "puntoVenta.nombreNegocio")}</td>

								<td>${fieldValue(bean: inventarioInstance, field: "producto.clave")}</td>

								<td>${fieldValue(bean: inventarioInstance, field: "producto.nombre")}</td>

								<td><g:formatNumber number="${inventarioInstance?.cantidad}" format="0.00" locale="en_US"/></td>

								<td>
									<g:link action="edit" id="${inventarioInstance.id}" >
										<image class="imageInButton" src="${resource(dir: "images", file: "editar.png")}"></image>
									</g:link>
								</td>

							</tr>
						</g:each>
					</tbody>
				</table>
			</div>
		</div>

	<%-- inicia modal Exportar --%>
	<div class="modal fade bs-example-modal-lg" tabindex="0" role="dialog" aria-labelledby="myLargeModalLabel">
		<div class="modal-dialog" role="document">
			<div class="modal-content">

				<div class="modal-header color-vennda">
					<button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
					<h4 class="modal-title color-blanco">Exportar Inventarios</h4>
				</div>
				<g:form action="exportarInventario" name="importarProductos" method="post">

					<div class="modal-body">
						<div class="contenedor">
							<div class="row">
								<div class="col-md-12">
									%{--<input type="file" accept="application/vnd.openxmlformats-officedocument.spreadsheetml.sheet" name="listaProductos"/>--}%
									%{--<g:hiddenField name="secure" value="true"></g:hiddenField>--}%
									<h4>Lista Productos</h4>
									<g:checkBox id="seleccionarTodos" name="seleccionarTodos"/> <b>Seleccionar todos</b><br><br>

									<g:each in="${productosEmpresa}" var="producto">
										%{--${producto.nombre} <br>--}%
										<g:checkBox class="checkProducto" name="producto.${producto.id}" /> ${producto.nombre} <br>
									</g:each>

								</div>
							</div>
						</div>
					</div>

					<div class="modal-footer">
						<g:submitButton class="btn btn-primary color-vennda" name="doUpload" value="Exportar" />
					</div>
				</g:form>
			</div>
		</div>
	</div>
	<%-- Fin modal Exportar --%>


	<%-- inicia modal Importar --%>
	<div class="modal fade bs-example-modal-lg1" tabindex="0" role="dialog" aria-labelledby="myLargeModalLabel">
		<div class="modal-dialog" role="document">
			<div class="modal-content">

				<div class="modal-header color-vennda">
					<button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
					<h4 class="modal-title color-blanco">Importar Productos</h4>
				</div>
				<g:uploadForm action="importarInventarioExcel" name="importarInventario" method="post">
					<g:hiddenField id="puntoVentaID" name="idPuntoVenta" />

					<div class="modal-body">

						<br>
						<div class="contenedor">
							<div class="row">
								<div class="col-md-12">
									<input type="file" accept="application/vnd.openxmlformats-officedocument.spreadsheetml.sheet" name="listaInventario"/>
									<g:hiddenField name="secure" value="true"></g:hiddenField>
								</div>
							</div>
						</div>
					</div>

					<div class="modal-footer">
						<g:submitButton class="btn btn-primary color-vennda" name="doUpload" value="Importar" />
					</div>
				</g:uploadForm>


			</div>
		</div>
	</div>
	<%-- Fin modal Importar --%>

	<g:javascript>

		$(document).ready(function () {
			var tablaPuntoVenta = $("#tablaInventario").dataTable({
			   "sPaginationType": "full_numbers",
				"iDisplayLengthChange": 10,
				"bLengthChange": false,
				"bStateSave": true,
				"language": {
			       "url": "${resource(dir: 'javascripts', file:'spanish.json')}"
				}
			});

			$( "#puntoVenta" ).change(function () {
			    var valor = $( "#puntoVenta option:selected").val();
			    console.log(valor);
			    $("#idPuntoVenta").val(valor);
			    $("#puntoVentaID").val(valor);
			});

			$( '#seleccionarTodos' ).on( 'click', function() {
				if( $(this).is(':checked') ){
					// Hacer algo si el checkbox ha sido seleccionado
					$( ".checkProducto" ).prop( "checked", true );
				} else {
					// Hacer algo si el checkbox ha sido deseleccionado
					$( ".checkProducto" ).prop( "checked", false );
				}
			});
		});

	</g:javascript>

	</body>
</html>
