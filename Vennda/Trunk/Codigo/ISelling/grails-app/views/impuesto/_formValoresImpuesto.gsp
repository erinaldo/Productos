<%@ page import="mx.elephantworks.iselling.ValoresImpuesto" %>

<g:set var="instanceName" value="valores[${indice}]."/>
<g:set var="instanceId" value="valores${indice}"/>

<div id="${instanceId}" class="valoresImpuestoInstance">

	<g:if test="${valoresImpuestoInstance?.id}">
		<g:hiddenField name="${instanceName}id" value="${valoresImpuestoInstance?.id}"/>
	</g:if>

	<div class="row">
		<div class="col-md-4">
			<div class="form-group  ${hasErrors(bean: valoresImpuestoInstance, field: 'tasa', 'error')} required">
				<label for="${instanceName}tasa">
					<g:message code="valoresImpuesto.tasa.label" default="Tasa" />
					<span class="required-indicator">*</span>
				</label>
				<g:field type="text" name="${instanceName}tasa" min="0" step="any"
						 required="" value="${valoresImpuestoInstance?.tasa}" class="form-control"/>

			</div>
		</div>
		<div class="col-md-4">
			<div class="form-group  ${hasErrors(bean: valoresImpuestoInstance, field: 'inicio', 'error')} required">
				<label for="${instanceName}inicio">
					<g:message code="valoresImpuesto.inicio.label" default="Fecha Inicio" />
					<span class="required-indicator">*</span>
				</label>
				<input type="text" name="${instanceName}inicio" id="${instanceId}inicio"
					   required="" class="form-control"/>

			</div>
		</div>
		<div class="col-md-4">
			<div class="form-group ${hasErrors(bean: valoresImpuestoInstance, field: 'fin', 'error')} required">
				<label for="${instanceId}fin">
					<g:message code="valoresImpuesto.fin.label" default="Fecha Fin" />
					<span class="required-indicator">*</span>
				</label>
				<input type="text" name="${instanceName}fin" id="${instanceId}fin"
					   required="" class="form-control">

			</div>
		</div>
	</div>





	<div class="row">
		<div class="col-md-12">

		<label for="${instanceId}Borrar"></label>

		<input type="button" name="${instanceName}Borrar" id="${instanceId}Borrar" style="display: none;"
			   data-valoresimpuestoid="${valoresImpuestoInstance?.id}" class="form-control btn btn-primary eliminarValoresImpuesto"
			   value="${message(code:'valoresImpuesto.borrar.label', default:'Borrar')}"/>
		</div>
	</div>
	<g:javascript>
		$(document).ready(function() {
			var previousDate = '${formatDate(format: "dd-MM-yyyy",date:valoresImpuestoInstance?.inicio?:new java.util.Date())}'
			var lastInicioDatepicker = $('#panelBodyImpuesto div:nth-last-child(1) input[name$="inicio"]');
			var previousInicioDatepicker = $('#panelBodyImpuesto div:nth-last-child(2) input[name$="inicio"]');
			var previousFinDatepicker = $('#panelBodyImpuesto div:nth-last-child(2) input[name$="fin"]');
			var previousBorrar = $('#panelBodyImpuesto div:nth-last-child(2) input[name$="Borrar"]:visible');

			//Pone por primera vez la fecha
			if(previousInicioDatepicker.length > 0){
				var newDate = previousInicioDatepicker.datepicker('getDate');
				if(newDate){
					previousDate = $.datepicker.formatDate('dd-mm-yy', newDate.plus(1));
				}
				previousInicioDatepicker.attr("readonly",true);
				previousInicioDatepicker.datepicker('destroy');
			}

			console.log("previousBorrar", previousBorrar);
			if(previousBorrar.length > 0){
				$(previousBorrar[0]).show();
				console.log("previousBorrar", previousBorrar[0]);
			}
			$('#panelBodyImpuesto div:last-child input[name$="Borrar"]').show();


			console.log("previousDate", previousDate);

			$("#${instanceId}inicio").datepicker({
				dateFormat: "dd-mm-yy",
				minDate: previousDate,
				onSelect: function () {
					var startDate = $.datepicker.formatDate('dd-mm-yy',$(this).datepicker('getDate').plus(-1));
					if(previousFinDatepicker.length > 0){
						$(previousFinDatepicker[0]).val(startDate);
					}
				}
			});

			$('#${instanceId}fin').datepicker({
				dateFormat: "dd-mm-yy",
			});

			$('#${instanceId}inicio').datepicker('setDate', previousDate);
			if(previousFinDatepicker.length > 0){
				console.log("previousFinDatepicker","previousFinDatepicker[0]",previousFinDatepicker[0]);
				var startDate = $.datepicker.formatDate('dd-mm-yy',$('#${instanceId}inicio').datepicker('getDate').plus(-1));
				$(previousFinDatepicker[0]).val(startDate);
			}

			$('#${instanceId}fin').datepicker('setDate', '${valoresImpuestoInstance?.fin ? formatDate(format: "dd-MM-yyyy",date:valoresImpuestoInstance?.fin) : "01-01-9999"}');
			$('#${instanceId}fin').datepicker('destroy');
			$('#${instanceId}fin').attr("readonly",true);


			if(lastInicioDatepicker.id != $("#${instanceId}inicio").id){
				$('#${instanceId}inicio').datepicker('destroy');
				$('#${instanceId}inicio').attr("readonly",true);
			}

		});
	</g:javascript>
</div>