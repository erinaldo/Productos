<%@ page import="mx.elephantworks.iselling.Producto" %>
<!DOCTYPE html>
<html>
	<head>
		<meta name="layout" content="main">
		<g:set var="entityName" value="${message(code: 'producto.label', default: 'Producto')}" />
		<title><g:message code="default.edit.label" args="[entityName]" /></title>
		<style>
		label.filebutton {

			overflow:hidden;
			position:relative;

		}
		.custom-input-file .input-file{
			width: 65px;
			height: 65px;
			margin: 0px;
			padding: 0px;
			outline: 0;
			position: absolute;
			opacity: 0;
			filter: alpha(opacity=0);
		}
		</style>
	</head>
	<body>

		<div style="margin-top: 3%">
			<g:link action="index">
				<image width="30px" class="imageInButton" src="${resource(dir: "images", file: "volver.png")}"></image>
				<label class="mensaje">volver</label>
			</g:link>
		</div>


	<div class="row" style="margin-top: 3%">
		<div class="col-md-8 col-md-offset-2">
			<div class="panel panel-primary" style="border-color: #48BFE6">
				<div class="panel-heading encabezadoPanelFormulario" style="background-color: #48BFE6;border-color: #48BFE6;">
					<image width="25px" class="imageInButton" src="${resource(dir: "images", file: "producto-boton.png")}"></image>
					<g:message code="default.edit.label" args="[entityName]" />
				</div>

				<g:if test="${flash.message}">
					<div class="alert alert-info" role="status">${flash.message}</div>
				</g:if>
				<g:hasErrors bean="${productoInstance}">
					<ul class="alert alert-info" role="alert">
						<g:eachError bean="${productoInstance}" var="error">
							<li <g:if test="${error in org.springframework.validation.FieldError}">data-field-id="${error.field}"</g:if>><g:message error="${error}"/></li>
						</g:eachError>
					</ul>
				</g:hasErrors>

				<div class="contenedor" style="margin-top: 3%; margin-bottom: 3%">

					<g:form url="[resource:productoInstance, action:'uploadImageEdit']" method="POST" enctype="multipart/form-data">
						<div class="row">
							<g:hiddenField name="txtCodigoBarras" id="txtCodigoBarras" value="yfyf" class="form-control"></g:hiddenField>
							<div class="col-md-12 col-md-offset-4">
								<div class="custom-input-file">
									<input type="file" id="fileInput" name="fileInput" class="input-file">
									<image id="imgDiv" src="${resource(dir: 'imgProductos', file: productoInstance?.imagen)}" style="width: 65px;"/>
								</div>
								<g:actionSubmitImage  id="btnUpload" value="Editar"  action="uploadImageEdit" />
							</div>
						</div>
					</g:form>

					<g:form url="[resource:productoInstance, action:'update']" method="PUT" >
						<g:hiddenField name="version" value="${productoInstance?.version}" />
						<fieldset class="form">
							<g:render template="form"/>
						</fieldset>
						<fieldset class="buttons" style="text-align: right">
							<g:actionSubmit  id="actualizarPerfil"  class="btn btn-primary color-vennda" action="update" value="${message(code: 'default.button.update.label', default: 'Update')}" />
						</fieldset>
					</g:form>
				</div>
			</div>
		</div>
	</div>

	<g:javascript>
		$( document ).ready(function() {
			cargarListasPrecios();
			cargarImpuestos();
		});

		var contadorInput = 0;
		var contadorImpuesto = 1;
		var arregloImpuesto = [];

		function cargarListasPrecios(){
		    console.log("pasa");
		   var listasConteo = contarListas();
		   var id = 2;
		   for(var x = 0; x < listasConteo.length; x++){

		       //console.log("pasa");
		       console.log(listasConteo[x].toString().replace(",","."));
		       //console.log(listasConteo[x].toString().replace(",","."));
		       var contenedor = $('#listaPrecios');
		        var diseño = "<div class='row' id='eliminarPrecio"+id+"'>" +
						"<div class='col-md-9' style='margin-bottom: 10px;'>" +
						"<label for='precio"+x+"'>Precio "+id+"</label>" + //cambiar nombre
						"<input type='text' name='precio"+id+"' class='form-control' value='"+listasConteo[x]+"'/>" +
						"</div>" +
						"</div>";
			  $(contenedor).append(diseño);
			  id++;
		   }

		   contadorInput = id;
		}

		function contarListas() {
		     var conteo = [];
		     //<g:formatNumber number="${inventarioInstance?.cantidad}" format="0.00" locale="en_US"/>
		     var precio2 = ${(productoInstance.precio2 != null ? productoInstance.precio2 : 0)};
		     var precio3 = ${(productoInstance.precio3 != null ? productoInstance.precio3 : 0)};
		     var precio4 = ${(productoInstance.precio4 != null ? productoInstance.precio4 : 0)};
		     var precio5 = ${(productoInstance.precio5 != null ? productoInstance.precio5 : 0)};

			if( precio2 != 0){
		        conteo.push(precio2);
			}
			if( precio3 != 0){
		        conteo.push(precio3);
			}
			if( precio4 != 0){
		       conteo.push(precio4);
			}
			if( precio5 != 0){
		        conteo.push(precio5);
			}


			console.log(conteo);
			return conteo;

		}

		function agregarPrecio() {
			var max = 5;

			if(contadorInput <= max)
			{
				console.log("agregar precio "+contadorInput);
				var contenedor = $('#listaPrecios');
				var diseño = "<div class='row' id='eliminarPrecio"+contadorInput+"'>" +
				"<div class='col-md-9' style='margin-bottom: 10px;'>" +
				"<label for='precio'>Precio "+contadorInput+"</label>" + //cambiar nombre
				"<input type='text' name='precio"+contadorInput+"' class='form-control'/>" +
				"</div>" +
				"</div>";
				$(contenedor).append(diseño);

				contadorInput ++;
			}

		}

		function quitarPrecio(){

			if(contadorInput > 2){
			    var contenedor = $('#listaPrecios');

				contadorInput --;
				var bloquePrecio = $("#listaPrecios").find("#eliminarPrecio"+contadorInput);
				bloquePrecio.remove();

				var inputEliminar = "<input type='hidden' name='precio"+contadorInput+"' class='form-control' value = ''/>"
				$(contenedor).append(inputEliminar);

			}
		}

		function cargarImpuestos() {
			var URL="${createLink(controller:'ajax',action:'impuestosProducto')}";
			var id = ${productoInstance.id};

			$.ajax({
				url:URL,
				data: {id:id},
				success: function(resp){

				var datos = resp.toString().replace("[","").replace("]","");
					if(datos.length > 0){
						var lista = datos.toString().split(",");

						for (var i=0; i < lista.length; i++){
							var datos2 = lista[i].toString().split(".");
							var id = datos2[0].toString().replace("'","");
							var nombre = datos2[1].toString().replace("'","");

							var contenedor = $('#listaImpuestos');
							var diseño = "<div class='row' id='eliminarImpuesto"+contadorImpuesto+"'>" +
										"<div class='col-md-9' style='margin-bottom: 10px;'>" +
										"<label for='impuesto'>Impuesto "+contadorImpuesto+"</label>" + //cambiar nombre
										"<input type='text' id='impuestoTexto"+contadorImpuesto+"' class='form-control' value='"+nombre+"' disabled/>" +
										"<input type='hidden' name='impuestos["+contadorImpuesto+"].valor' value='"+id+"' />" +
										"</div>" +
										"</div>";
							$(contenedor).append(diseño);

							arregloImpuesto.push(nombre);
							contadorImpuesto ++;

							$("#contadorImpuesto").val(contadorImpuesto);

						}
					}
				}
			});


		}

		function agregarImpuesto() {
			var max = 5;

			if(contadorImpuesto <= max)
			{
			    var valor = $("#impuesto").val();
			    var texto = $("#impuesto option:selected").text();

			    if(!buscarImpuesto(texto) || arregloImpuesto.length == 0){
					var contenedor = $('#listaImpuestos');
					var diseño = "<div class='row' id='eliminarImpuesto"+contadorImpuesto+"'>" +
					"<div class='col-md-9' style='margin-bottom: 10px;'>" +
					"<label for='impuesto'>Impuesto "+contadorImpuesto+"</label>" + //cambiar nombre
					"<input type='text' id='impuestoTexto"+contadorImpuesto+"' class='form-control' value='"+texto+"' disabled/>" +
					"<input type='hidden' name='impuestos["+contadorImpuesto+"].valor' value='"+valor+"' />" +
					"</div>" +
					"</div>";
					$(contenedor).append(diseño);

					arregloImpuesto.push(texto);
					contadorImpuesto ++;

					$("#contadorImpuesto").val(contadorImpuesto);
				}else{
			        alert("Ya se asigno este impuesto.");
				}


			}
		}

		function quitarImpuesto(){

			if(contadorImpuesto > 1){
				contadorImpuesto --;
				var bloqueImpuesto = $("#listaImpuestos").find("#eliminarImpuesto"+contadorImpuesto);
				var bloqueTexto = bloqueImpuesto.find("#impuestoTexto"+contadorImpuesto);
				var texto = bloqueTexto.val();

				var x = arregloImpuesto.indexOf(texto);
				arregloImpuesto.splice(x,1);
				bloqueImpuesto.remove();

				$("#contadorImpuesto").val(contadorImpuesto);
			}
		}

		function buscarImpuesto(texto) {
		    var exito = true;
			var x = arregloImpuesto.indexOf(texto);
			if(x < 0){
			    exito = false;
			}
			return exito;
		}

	</g:javascript>

	</body>
</html>
