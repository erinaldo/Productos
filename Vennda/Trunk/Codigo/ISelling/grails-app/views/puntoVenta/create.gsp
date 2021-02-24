<!DOCTYPE html>
<html>
	<head>
		<meta name="layout" content="main">
		<g:set var="entityName" value="${message(code: 'puntoVenta.label', default: 'PuntoVenta')}" />
		<title><g:message code="default.create.label" args="[entityName]" /></title>
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
					<image width="25px" class="imageInButton" src="${resource(dir: "images", file: "PuntoVenta/PuntoVentaBlanco.png")}"></image>
					<g:message code="puntoVenta.crear.label" default="Crear Punto de Venta"/>
				</div>

				<g:if test="${flash.message}">
					<div class="alert alert-info" role="status">${flash.message}</div>
				</g:if>

				<g:if test="${flash.error}">
					<div class="alert alert-info" role="status">${flash.error}</div>
				</g:if>

				<g:hasErrors bean="${puntoVentaInstance}">
					<ul class="alert alert-info" role="alert">
						<g:eachError bean="${puntoVentaInstance}" var="error">
							<li <g:if test="${error in org.springframework.validation.FieldError}">data-field-id="${error.field}"</g:if>><g:message error="${error}"/></li>
						</g:eachError>
					</ul>
				</g:hasErrors>

				<div class="contenedor" style="margin-top: 3%; margin-bottom: 3%">
					<g:form url="[resource:puntoVentaInstance, action:'save']" onsubmit="return validaFormulario()">
						<fieldset class="form">
							<g:render template="form" model="[editable: false]"/>
						</fieldset>
						<fieldset class="buttons" style="text-align: right">
							<g:submitButton name="create" class="btn btn-primary color-vennda" value="${message(code: 'default.button.create.label', default: 'Create')}" />
						</fieldset>
					</g:form>
				</div>
			</div>
		</div>
	</div>

	<g:javascript>

		var mapa;
		var generaUbicacion = false;

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

			var mexico = {lat: 23.6345501, lng: -102.55278399999997}
			mapa = new google.maps.Map(document.getElementById('mapa'), {
				center: mexico,
				zoom: 4
			});
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
