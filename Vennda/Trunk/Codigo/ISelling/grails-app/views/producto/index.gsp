
<%@ page import="mx.elephantworks.iselling.Producto" %>
<!DOCTYPE html>
<html>
	<head>
		<meta name="layout" content="main">
		<g:set var="entityName" value="${message(code: 'producto.label', default: 'Producto')}" />
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
							<image class="imageInButton" src="${resource(dir: "images", file: "producto-lista.png")}"></image>
							Productos
						</label>
					</div>
					<div class="col-md-9" style="text-align: right">
						<button class="btn btn-primary color-vennda" data-toggle="modal" data-target=".bs-example-modal-lg">
							<image class="imageInButton" src="${resource(dir:"images", file: "importar.png")}"></image>
							Importar
						</button>
						<g:link action="create" class="btn btn-primary color-vennda">
							<image class="imageInButton" src="${resource(dir: "images", file: "producto-boton.png")}"></image>
							<g:message code="default.new.label" args="[entityName]"/>
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
		<div id="list-producto" class="content scaffold-list" role="main">
			<table id="tablaInventario" class="display table table-hover">
				<thead>
					<tr>

						<th>${message(code: 'producto.codigoBarras.label', default: 'Código Barras')}</th>

						<th>${message(code: 'producto.clave.label', default: 'Clave')}</th>

						<th>${message(code: 'producto.nombre.label', default: 'Nombre')}</th>

						<th>${message(code: 'producto.imagen.label', default: 'Imagen')}</th>

						<th>${message(code: 'default.edit.label', default: 'Editar', args: [""])}</th>

						<th>${message(code: 'default.button.delete.label', default: 'Eliminar', args: [""])}</th>

					</tr>
				</thead>
				<tbody>
					<g:each in="${productoInstanceList}" status="i" var="productoInstance">
						<tr class="${(i % 2) == 0 ? 'even' : 'odd'}">

							<td>${fieldValue(bean: productoInstance, field: "codigoBarras")}</td>

							<td>${fieldValue(bean: productoInstance, field: "clave")}</td>

							<td>${fieldValue(bean: productoInstance, field: "nombre")}</td>

							<td style="    width: 30%;">
								<g:if test="${productoInstance.imagen != null}">
								   <image src="${resource(dir: 'imgProductos', file: productoInstance?.imagen)}" style="width: 10%"/>
							    </g:if>
								<g:else>
									<image src="${resource(dir: 'images', file: 'camara.png')}" style="width: 10%"/>
								</g:else>
							</td>

							<td>
								<g:link action="edit" id="${productoInstance.id}" >
									<image  class="imageInButton" src="${resource(dir: "images", file: "editar.png")}"></image>
								</g:link>
							</td>

							<td>
								<g:form url="[resource:productoInstance, action:'delete']" method="DELETE">
									<g:actionSubmitImage width="25px" value="${message(code: 'default.button.delete.label', default: 'Eliminar', args: [""])}" src="${resource(dir: 'images', file: 'eliminar.png')}" action="delete" onclick="return confirm('${message(code: 'default.button.delete.confirm.message', default: 'Are you sure?')}');" />

								</g:form>
							</td>

						</tr>
					</g:each>
				</tbody>
			</table>
		</div>
	</div>





	<%-- inicia modal Importar --%>
	<div class="modal fade bs-example-modal-lg" tabindex="0" role="dialog" aria-labelledby="myLargeModalLabel">
		<div class="modal-dialog" role="document">
			<div class="modal-content">

				<div class="modal-header color-vennda">
					<button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
					<h4 class="modal-title color-blanco">Importar Productos</h4>
				</div>
				<g:uploadForm action="cargarProductosExcel" name="importarProductos" method="post">

					<div class="modal-body">
						<div class="alert alert-success" role="alert" style="text-align: center; color: #31708f;">
							<p> <strong>Aqui</strong> podras importar tus productos que tengas registrados en archivos de excel 2007 o versiones mas recientes.</p>
						</div>
						<div class="alert alert-success" role="alert" style="text-align: center; color: #31708f;">
							<p> Primero tienes que descargar la plantilla oficial de vennda para subir tus productos dando click en el boton <strong>Descargar plantilla</strong>,
							una vez descargado es necesario <strong>llenar todos las columnas</strong> de la tabla para no generar errores,
							como paso final deberas buscar tu archivo dando click en el boton <strong>Seleccionar archivo</strong> y precionar el boton de importar.</p>
						</div>


						<br>
						<div class="contenedor">
							<div class="row">
								<div class="col-md-12">
									<input type="file" accept="application/vnd.openxmlformats-officedocument.spreadsheetml.sheet" name="listaProductos"/>
									<g:hiddenField name="secure" value="true"></g:hiddenField>
								</div>
							</div>
						</div>
					</div>

					<div class="modal-footer">
						<a href='${resource(dir:"plantilla", file: "plantilla_productos_vennda.xlsx")}' download="plantilla_productos_vennda.xlsx" class="btn btn-primary color-vennda"> Descargar Plantilla</a>
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
		});
	</g:javascript>

	</body>
</html>
