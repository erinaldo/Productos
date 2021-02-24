
<%@ page import="mx.elephantworks.iselling.Categoria" %>
<!DOCTYPE html>
<html>
	<head>
		<meta name="layout" content="main">
		<g:set var="entityName" value="${message(code: 'categoria.label', default: 'Categoría')}" />
		<title>Categorías</title>
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
			</style>
	</head>
	<body>
		<div class="nav" role="navigation">
			<div class="row">
				<div class="col-md-12" style="margin-top: 3%">
					<div class="col-md-3">
						<label class="mensaje">
							<image class="imageInButton" src="${resource(dir: "images", file: "Categoria/categoriaGris.png")}"></image>
							<g:message code="categorias.title.label" default="Categorías"/>
						</label>
					</div>

					<div class="col-md-9" style="text-align: right">
						<g:link action="create" class="btn btn-primary buttonImage">
							<image class="imageInButton" src="${resource(dir: "images", file: "Categoria/categoriaBlanco.png")}"></image>
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
			<strong><g:message code="alerta.title.label" default="Aviso!"></g:message></strong> ${flash.message}
		</div>
	</g:if>

		<div class="table-responsive" style="margin-top: 3%">
			<div id="list-categoria" class="table table-hover" role="main">
			<table id="tablaCategorias" class="table table-hover">
			    <thead>
					<tr>
						<th width="20%">${message(code: 'categoria.identificador.label', default: 'Identificador')}</th>

						<th>${message(code: 'categoria.imagen.label', default: 'Imagen')}</th>

						<th width="60%">${message(code: 'categoria.nombre.label', default: 'Nombre')}</th>

						<th>${message(code: 'default.edit.label', default: 'Editar', args: [""])}</th>

						<th>${message(code: 'default.button.delete.label', default: 'Eliminar', args: [""])}</th>

					</tr>
				</thead>
				<tbody>
				<g:each in="${categoriaInstanceList}" status="i" var="categoriaInstance">
					<tr class="${(i % 2) == 0 ? 'even' : 'odd'}">
					
						<td>
                            ${fieldValue(bean: categoriaInstance, field: "identificador")}
                        </td>

						<td style="    width: 30%;">
							<g:if test="${categoriaInstance.imagen != null}">
								<image src="${resource(dir: 'imgCategorias', file: categoriaInstance?.imagen)}" style="width: 10%"/>
							</g:if>
							<g:else>
								<image src="${resource(dir: 'images', file: 'camara.png')}" style="width: 10%"/>
							</g:else>
						</td>

						<td>${fieldValue(bean: categoriaInstance, field: "nombre")}</td>

						<td>
							<g:link action="edit" id="${categoriaInstance.id}" >
								<image class="imageInButton" src="${resource(dir: "images", file: "editar.png")}"></image>
							</g:link>
						</td>

						<td>
						<g:form url="[resource:categoriaInstance, action:'delete']" method="DELETE">
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
			var tablaPuntoVenta = $("#tablaCategorias").dataTable({
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
