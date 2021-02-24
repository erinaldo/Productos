<%@ page import="mx.elephantworks.iselling.PuntoVenta" %>
<!DOCTYPE html>
<html>
	<head>
		<meta name="layout" content="main">
		<g:set var="entityName" value="${message(code: 'puntoVenta.label', default: 'PuntoVenta')}" />
		<title><g:message code="default.edit.label" args="[entityName]" /></title>
		<style>
		.texto-derecha{
			text-align: right;
		}
		.color-blanco{
			color: #FFFFFF;
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
					<div class="row">
						<div class="col-md-6">
							<image width="25px" class="imageInButton" src="${resource(dir: "images", file: "PuntoVenta/PuntoVentaBlanco.png")}"></image>
							<g:message code="puntoVenta.crear.label" default="Crear Punto de Venta"/>
						</div>
						<div class="col-md-6 texto-derecha">
							<button type="button" class="btn btn-primary color-vennda" data-toggle="modal" data-target="#modalConfiguraciones">
								<image class="imageInButton" src="${resource(dir: "images", file: "editar-documento.png")}" width="20"></image>
								<g:message code="puntoVenta.configuraciones.label" default="Configuración Avanzada"/>
							</button>
						</div>
					</div>
				</div>

				<g:if test="${flash.message}">
					<div class="alert alert-info alert-dismissible" role="alert">
						<button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
						<strong>Aviso!</strong> ${flash.message}
					</div>
				</g:if>

				<g:hasErrors bean="${productoInstance}">
					<ul class="alert alert-info" role="alert">
						<g:eachError bean="${productoInstance}" var="error">
							<li <g:if test="${error in org.springframework.validation.FieldError}">data-field-id="${error.field}"</g:if>><g:message error="${error}"/></li>
						</g:eachError>
					</ul>
				</g:hasErrors>

				<div class="contenedor" style="margin-top: 3%; margin-bottom: 3%">
					<g:form url="[resource:puntoVentaInstance, action:'update']" method="PUT" >
						<g:hiddenField name="version" value="${puntoVentaInstance?.version}" />
						<fieldset class="form">
							<g:render template="form" model="[editable: true]"/>
						</fieldset>
						<fieldset class="buttons" style="text-align: right">
							<g:actionSubmit class="btn btn-primary color-vennda" action="update" value="${message(code: 'default.button.update.label', default: 'Update')}" />
						</fieldset>
					</g:form>
				</div>
			</div>
		</div>
	</div>

	<%-- Inicia Modal Configuraciones --%>
	<div class="modal fade" id="modalConfiguraciones" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
		<div class="modal-dialog" role="document">
			<div class="modal-content">
				<div class="modal-header color-vennda">
					<button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
					<h4 class="modal-title color-blanco" id="myModalLabel">Configuraciones Avanzadas</h4>
				</div>
				<g:form url="[resource:puntoVentaInstance, action:'guardarConfiguraciones']" method="POST" >
					<div class="modal-body">
						<div class="contenedor">
							<fieldset class="form">
								<g:render template="configuraciones"/>
							</fieldset>
						</div>
					</div>
					<div class="modal-footer">
						<button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
						<g:actionSubmit class="btn btn-primary color-vennda" action="guardarConfiguraciones" value="Guardar Cambios" />
					</div>
				</g:form>
			</div>
		</div>
	</div>

	<%-- Termina Modal Configuraciones --%>

	<g:javascript>

		var mapa;
		var generaUbicacion = false;

		$(document).ready(function () {

		    $("#calle").on('input',cambiosDomicilio);
		    $("#noExterior").on('input',cambiosDomicilio);
		    $("#pais").on('input',cambiosDomicilio);
		    $("#entidad").on('input',cambiosDomicilio);
		    $("#ciudad").on('input',cambiosDomicilio);
		});

		function cambiosDomicilio() {
			generaUbicacion = true;
		}

		function validaFormulario(){
			console.log("pasa");

			var pasa = true;

			if(!generaUbicacion){
				alert("Es necesario generar ubicación para poder guardar un punto de venta");
				pasa = false;
			}

			return pasa;
		}

		function initMap() {

		   /* var latitud = parseFloat($("#latitud").val().replace(',', '.'));
		    var longitud = parseFloat($("#longitud").val().replace(',', '.'));
		    var zomm = 17;

			console.log(latitud+" "+longitud);

		    if(latitud == 0 && longitud == 0){
		        latitud = 23.6345501;
		        longitud = -102.55278399999997;
		        zomm = 4;
			}*/


			var ubicacion = {lat:23.6345501, lng: -102.55278399999997};

			mapa = new google.maps.Map(document.getElementById('mapa'), {
				center: ubicacion,
				zoom: 17
			});

			generarUbicacion();

			/*var marker = new google.maps.Marker({
			   position: ubicacion,
				map: mapa
			});*/
		}

		function generarUbicacion() {
			var calle = $("#calle").val();
			var noExterior = $("#noExterior").val();
			var ciudad = $("#ciudad").val();
			var entidad = $("#entidad").val();
			var pais = $("#pais").val();
			var todoOk = true;

			if(calle == ""){
				todoOk = false;
			}
			if(noExterior == ""){
				todoOk = false;
			}
			if(ciudad.toString() == "0"){
				todoOk = false;
			}
			if(entidad.toString() == "0"){
				todoOk = false;
			}
			if(pais.toString() == "0"){
				todoOk = false;
			}
			if(!todoOk){
				alert("Es necesario completar los siguientes campos: Calle, Numero Exterior, Pais, Entidad y Ciudad. Por favor verifique sus datos.");
				return;
			}

			var domicilio = calle + " " + noExterior + ", "+ $("#ciudad option:selected").text() + ", " + $("#entidad option:selected").text() + ", " + $("#pais option:selected").text();

			var ubicacionVacante = new google.maps.Geocoder();

			ubicacionVacante.geocode({"address": domicilio}, function (results, status) {
				if(status == google.maps.GeocoderStatus.OK){
					mapa.setCenter(results[0].geometry.location);
					mapa.setZoom(17);

					var marker = new google.maps.Marker({
						position: results[0].geometry.location,
						map: mapa,
						draggable: true
					});

					$("#latitud").attr('value', marker.position.lat());
					$("#longitud").attr('value', marker.position.lng());
					generaUbicacion = true;
				}else{
					alert("Su dirección no se encuntra en el mapa, por favor verifique sus datos.");
				}
			});

		}
	</g:javascript>

	<script async defer
			src="https://maps.googleapis.com/maps/api/js?key=AIzaSyBw5F8ImtGOrW3wD8c5hERR0RwznlYLo0U&callback=initMap">
	</script>
	</body>
</html>
