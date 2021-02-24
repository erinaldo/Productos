<%@ page import="mx.elephantworks.iselling.ValoresImpuesto; mx.elephantworks.iselling.Impuesto" %>
<style>
.imageMas{
	width: 30px;
	margin: auto;
}
.imageMas:hover{
	width: 35px;
}
.row{
	margin-bottom: .5em;
}
</style>

<div class="row">
	<div class="col-md-12">
		<div class="form-group  ${hasErrors(bean: impuestoInstance, field: 'identificador', 'error')} required">
			<label for="identificador">
				<g:message code="impuesto.identificador.label" default="Identificador" />
				<span class="required-indicator">*</span>
			</label>
			<g:textField name="identificador" required="" value="${impuestoInstance?.identificador}" class="form-control"/>
		</div>
	</div>
</div>

<div class="row">
	<div class="col-md-12">
		<div class="form-group  ${hasErrors(bean: impuestoInstance, field: 'tipoAplicacion', 'error')} required">
			<label for="tipoAplicacion">
				<g:message code="impuesto.tipoAplicacion.label" default="Tipo Aplicacion" />
				<span class="required-indicator">*</span>
			</label>
			<g:select name="tipoAplicacion" from="${mx.elephantworks.iselling.TipoAplicacion?.values()}"
					  keys="${mx.elephantworks.iselling.TipoAplicacion.values()*.name()}" required=""
					  value="${impuestoInstance?.tipoAplicacion?.name()}" class="form-control"/>
		</div>
	</div>
</div>


<div class="row">
	<div class="col-md-12">
		<div class="form-group  ${hasErrors(bean: impuestoInstance, field: 'despuesDeImpuesto', 'error')} ">
			<label for="despuesDeImpuesto">
				<%--<g:checkBox name="despuesDeImpuesto" value="${impuestoInstance?.despuesDeImpuesto}" class="checkbox"/>--%>
				<g:message code="impuesto.despuesDeImpuesto.label" default="Calcular después de impuestos" />
			</label>
			<br>
			<label class="switch">
				<g:checkBox name="despuesDeImpuesto" id="despuesDeImpuesto" value="${impuestoInstance?.despuesDeImpuesto}" />
				<div class="slider round"></div>
			</label>

		</div>
	</div>
</div>

<div class="row">
	<div class="col-md-12">
		<div class="form-group  ${hasErrors(bean: impuestoInstance, field: 'jerarquia', 'error')}">
			<label for="jerarquia">
				<g:message code="impuesto.jerarquia.label" default="Jerarquia" />
			</label>
			<g:field name="jerarquia" type="number" value="${impuestoInstance.jerarquia}" class="form-control"/>
		</div>
	</div>
</div>

<hr>


<div class="row">
	<div class="col-md-12">
		<div class="panel-body" id="panelBodyImpuesto">
			<div class="form-group ${hasErrors(bean: impuestoInstance, field: 'valores', 'error')} ">
				<label for="valores"></label>
				<%-- codigo hansel
				<image class="imageInButton imageMas" onclick="debounce(addValorImpuestoForm($('#panelBodyImpuesto'),contador++));" src="${resource(dir:"images", file: "anadir.png")}"></image>
				--%>
				<div class="row">
					<div class="col-md-4">
						<label for="tasa">
							<g:message code="impuesto.tasa.label" default="Tasa" />
						</label>
						<input type='number' id='tasa' name='tasa' class='form-control' required/>
					</div>
					<div class="col-md-4">
						<label for="fechaInicio">
							<g:message code="impuesto.fechaInicio.label" default="Fecha" />
						</label>
						<input type='text' id='fechaInicio' name='fechaInicio' class='form-control fechaInicio' required/>
					</div>
					<div class="col-md-4">
						<image class="imageInButton imageMas" onclick="agregarImpuesto();" src="${resource(dir:"images", file: "anadir.png")}"></image>
						<image class="imageInButton imageMas" onclick="quitarImpuesto();" src="${resource(dir:"images", file: "boton-eliminar.png")}"></image>
					</div>
				</div>


			</div>

			<div id="listaImpuestos">

			</div>
		</div>
	</div>
</div>

<g:hiddenField name="contadorImpuesto"/>

<g:if test="${editable}">
	<g:javascript>
		$( document ).ready(function() {
			cargarImpuestos();
			$("#fechaInicio").datepicker({
				dateFormat: "dd-mm-yy",
				minDate: 0
			});
			$("#fechaFin").datepicker({
				dateFormat: "dd-mm-yy",
				minDate: 0
			});
		});

		function cargarImpuestos() {
			var URL="${createLink(controller:'ajax',action:'impuestos')}";
			var id = ${impuestoInstance.id};

			$.ajax({
				url:URL,
				data: {id:id},
				success: function(resp){

				var datos = resp.toString().replace("[","").replace("]","");
					if(datos.length > 0){
						var lista = datos.toString().split(",");

						for (var i=0; i < lista.length; i++){
							var datos2 = lista[i].toString().split("|");

							var tasa = datos2[0].toString().replace("'","");
							var inicio = datos2[1].toString().replace("'","");
							var fin = datos2[2].toString().replace("'","");

							var contenedor = $('#listaImpuestos');
							var diseño = "<div class='row' id='eliminarImpuesto" + contadorImpuesto + "'>" +
											"<div class='col-md-4' style='margin-bottom: 10px;'>" +
											"<input type='text' id='tasa" + contadorImpuesto + "' name='impuestos[" + contadorImpuesto + "].tasa' class='form-control' value='"+tasa+"' readonly/>" +
											"</div>" +
											"<div class='col-md-4' style='margin-bottom: 10px;'>" +
											"<input type='text' id='fechaInicio" + contadorImpuesto+"' name='impuestos[" + contadorImpuesto + "].fechaInicio' class='form-control fechaInicio' value='"+inicio+"' readonly/>" +
											"</div>" +
											"<div class='col-md-4' style='margin-bottom: 10px;'>" +
											"<input type='text' id='fechaFin" + contadorImpuesto + "' name='impuestos[" + contadorImpuesto + "].fechaFin' class='form-control fechaFin' value='"+fin+"' readonly/>" +
											"</div>" +
											"</div>";
							$(contenedor).append(diseño);

							contadorImpuesto ++;

							$("#contadorImpuesto").val(contadorImpuesto);

						}
					}
				}
			});


		}

	</g:javascript>
</g:if>
<g:javascript>

	$( document ).ready(function() {
		var inicio = $("#fechaInicio").datepicker({
			dateFormat: "dd-mm-yy",
			minDate: 0
		});
		var fin = $("#fechaFin").datepicker({
			dateFormat: "dd-mm-yy",
			minDate: 0
		});

	});

	var contadorImpuesto = 0;
	var max = 4;

	function agregarImpuesto() {


		if (contadorImpuesto <= max) {

		    var tasa = $('#tasa').val();
		    var fechaInicio = $('#fechaInicio').val();
		    var fechaFin = "30-12-2099";
		    var existe = false;

		    if(tasa && fechaInicio){
				if(contadorImpuesto > 0){

					existe = validarFecha();

					if(!existe){
						var inicio = fechaInicio.split("-");
						var dInicio = new Date(inicio[2], inicio[1] - 1, inicio[0] - 1);

						var monthNames = [
							"01", "02", "03",
							"04", "05", "06", "07",
							"08", "09", "10",
							"11", "12"
						];

						var day = dInicio.getDate();
						var monthIndex = dInicio.getMonth();
						var year = dInicio.getFullYear();

						var strFecha = day + '-' + monthNames[monthIndex] + '-' + year;

						var conta = contadorImpuesto -1;
						$('#fechaFin' + conta).val(strFecha);

					}
				}

				if(!existe){
					var contenedor = $('#listaImpuestos');
					var diseño = "<div class='row' id='eliminarImpuesto" + contadorImpuesto + "'>" +
							"<div class='col-md-4' style='margin-bottom: 10px;'>" +
							"<input type='text' id='tasa" + contadorImpuesto + "' name='impuestos[" + contadorImpuesto + "].tasa' class='form-control' value='"+tasa+"' readonly/>" +
							"</div>" +
							"<div class='col-md-4' style='margin-bottom: 10px;'>" +
							"<input type='text' id='fechaInicio" + contadorImpuesto+"' name='impuestos[" + contadorImpuesto + "].fechaInicio' class='form-control' value='"+fechaInicio+"' readonly/>" +
							"</div>" +
							"<div class='col-md-4' style='margin-bottom: 10px;'>" +
							"<input type='text' id='fechaFin" + contadorImpuesto + "' name='impuestos[" + contadorImpuesto + "].fechaFin' class='form-control' value='"+fechaFin+"' readonly/>" +
							"</div>" +
							"</div>";
					$(contenedor).append(diseño);

					$("#contadorImpuesto").val(contadorImpuesto);
					contadorImpuesto++;
				}else{
					alert("Ya existe la fecha seleccionada en los rangos");
				}

			}else{
				alert("Es necesario la tasa y le fecha para poder registrar un rango");
			}

		}
	}

	function quitarImpuesto(){
			if(contadorImpuesto > 0){

				contadorImpuesto --;
				var bloqueImpuesto = $("#listaImpuestos").find("#eliminarImpuesto"+contadorImpuesto);
				bloqueImpuesto.remove();
				var x = contadorImpuesto -1;
				if(x >= 0){
				    $("#eliminarImpuesto"+x+" :input#fechaFin"+x).val("30-12-2099");
				}

				$("#contadorImpuesto").val(contadorImpuesto);
			}
	}
	
	function validarFecha() {
	    var existe = false;
		for(var x=0; x <= contadorImpuesto -1; x++){
			var fechaInicio = $('#fechaInicio').val();
			var inicio = $("#eliminarImpuesto"+x+" :input#fechaInicio"+x).val();
			var fin = $("#eliminarImpuesto"+x+" :input#fechaFin"+x).val();

			var strFechaInicio = fechaInicio.split("-");
			var dFechaInicio = new Date(strFechaInicio[2], strFechaInicio[1] - 1, strFechaInicio[0]);

			var strInicio = inicio.split("-");
			var dInicio = new Date(strInicio[2], strInicio[1] - 1, strInicio[0]);

			var strFin = fin.split("-");
			var dFin = new Date(strFin[2], strFin[1] - 1, strFin[0]);

			if(fin == "30-12-2099"){
				dFin = new Date(strFechaInicio[2], strFechaInicio[1] - 1, strFechaInicio[0] -1);
			}

			existe = validarRango(dInicio,dFin,dFechaInicio);

			if(existe){
				break;
			}
		}

		return existe;
	}
	
	function validarRango(inicio, fin, dia) {

		console.log(inicio);
		console.log(fin);
		console.log(dia);

		var pasa = false;
		var dateStart=new Date(inicio);
		var dateEnd=new Date(fin);
		var dateDay=new Date(dia);


		if(dateStart >= dateDay && dateDay <= dateEnd)
		{
			pasa = true
		}

		console.log(pasa);
		return pasa;
	}

</g:javascript>
