<%@ page import="mx.elephantworks.iselling.PuntoVenta" %>
<style>
	.row{
		margin-bottom: .5em;
	}
</style>

<div class="row">
	<div class="col-md-6">
		<div class="fieldcontain ${hasErrors(bean: puntoVentaInstance, field: 'numeroNegocio', 'error')} required">
			<label for="numeroNegocio">
				<g:message code="puntoVenta.numeroNegocio.label" default="Numero de punto de venta" />
				<span class="required-indicator">*</span>
			</label>
			<g:textField name="numeroNegocio" maxlength="4" required="" value="${puntoVentaInstance?.numeroNegocio}" class="form-control" onkeypress="return soloNumeros(event);"/>
		</div>
	</div>
</div>

<div class="row">
	<div class="col-md-12">
		<div class="fieldcontain ${hasErrors(bean: puntoVentaInstance, field: 'nombreNegocio', 'error')} required">
			<label for="nombreNegocio">
				<g:message code="puntoVenta.nombreNegocio.label" default="Nombre de punto de venta" />
				<span class="required-indicator">*</span>
			</label>
			<g:textField name="nombreNegocio" required="" value="${puntoVentaInstance?.nombreNegocio}" class="form-control"/>
		</div>
	</div>
</div>

<div class="row">
	<div class="col-md-6">
		<div class="fieldcontain ${hasErrors(bean: puntoVentaInstance, field: 'telefono', 'error')} required">
			<label for="telefono">
				<g:message code="puntoVenta.telefono.label" default="Telefono" />
			</label>
			<g:textField name="telefono" value="${puntoVentaInstance?.telefono}" class="form-control"/>
		</div>
	</div>
	<div class="col-md-6">
		<div class="fieldcontain ${hasErrors(bean: puntoVentaInstance, field: 'celular', 'error')} required">
			<label for="celular">
				<g:message code="puntoVenta.celular.label" default="Celular" />
			</label>
			<g:textField name="celular" value="${puntoVentaInstance?.celular}" class="form-control"/>
		</div>
	</div>
</div>

<div class="row">
	<div class="col-md-12">
		<div class="fieldcontain ${hasErrors(bean: puntoVentaInstance, field: 'correoElectronico', 'error')} required">
			<label for="correoElectronico">
				<g:message code="puntoVenta.correoElectronico.label" default="Correo Electronico" />
			</label>
			<g:textField name="correoElectronico" value="${puntoVentaInstance?.correoElectronico}" class="form-control"/>
		</div>
	</div>
</div>

<div class="row">
	<div class="col-md-12">
		<div class="fieldcontain ${hasErrors(bean: puntoVentaInstance, field: 'calle', 'error')} required">
			<label for="calle">
				<g:message code="puntoVenta.calle.label" default="Calle" />
				<span class="required-indicator">*</span>
			</label>
			<g:textField id="calle" name="calle" required="" value="${puntoVentaInstance?.calle}" class="form-control"/>
		</div>
	</div>
</div>

<div class="row">
	<div class="col-md-6">
		<div class="fieldcontain ${hasErrors(bean: puntoVentaInstance, field: 'noExterior', 'error')} required">
			<label for="noExterior">
				<g:message code="puntoVenta.noExterior.label" default="No Exterior" />
				<span class="required-indicator">*</span>
			</label>
			<g:field id="noExterior" name="noExterior" type="number" value="${puntoVentaInstance.noExterior}" required="" class="form-control"/>
		</div>
	</div>
	<div class="col-md-6">
		<div class="fieldcontain ${hasErrors(bean: puntoVentaInstance, field: 'noInterior', 'error')} required">
			<label for="noInterior">
				<g:message code="puntoVenta.noInterior.label" default="No Interior" />
			</label>
			<g:field name="noInterior" type="number" value="${puntoVentaInstance.noInterior}" class="form-control"/>
		</div>
	</div>

</div>

<div class="row">
	<div class="col-md-6">
		<div class="fieldcontain ${hasErrors(bean: puntoVentaInstance, field: 'colonia', 'error')} required">
			<label for="colonia">
				<g:message code="puntoVenta.colonia.label" default="Colonia" />
				<span class="required-indicator">*</span>
			</label>
			<g:textField name="colonia" required="" value="${puntoVentaInstance?.colonia}" class="form-control"/>
		</div>
	</div>
	<div class="col-md-6">
		<div class="fieldcontain ${hasErrors(bean: puntoVentaInstance, field: 'codigoPostal', 'error')} required">
			<label for="codigoPostal">
				<g:message code="puntoVenta.codigoPostal.label" default="Codigo Postal" />
				<span class="required-indicator">*</span>
			</label>
			<g:textField name="codigoPostal" required="" value="${puntoVentaInstance?.codigoPostal}" class="form-control"/>
		</div>
	</div>
</div>

<div class="row">
	<div class="col-md-12">
		<div class="fieldcontain ${hasErrors(bean: puntoVentaInstance, field: 'pais', 'error')} required">
			<label for="pais">
				<g:message code="puntoVenta.pais.label" default="Pais" />
				<span class="required-indicator">*</span>
			</label>
			<g:select id="pais" name="pais" required="" value="${puntoVentaInstance?.pais?.id}" noSelection="['0':'Selecciona ...']" class="form-control"
					  from="${mx.elephantworks.iselling.Pais.list()}"
					  optionKey="id"
					  optionValue="nombrePais"
					  onchange="${remoteFunction(
							  controller: 'ajax',
							  action: 'cargarEntidades',
							  params: '\'id=\' + escape(this.value)',
							  onSuccess: 'cargarEntidades(data,textStatus)'
					  )}"
			/>
		</div>
	</div>
</div>


<div class="row">
	<div class="col-md-12">
		<div class="fieldcontain ${hasErrors(bean: puntoVentaInstance, field: 'entidad', 'error')} required">
			<label for="entidad">
				<g:message code="puntoVenta.entidad.label" default="Entidad" />
				<span class="required-indicator">*</span>
			</label>

			<g:if test="${editable}">
				<g:select id="entidad" name="entidad" from="${entidades.toList()}" required="" value="${puntoVentaInstance?.entidad?.id}" class="form-control"
						  optionKey="id"
						  optionValue="nombreEntidad"
						  noSelection="['0':'Selecciona ...']"
						  onchange="${remoteFunction(
								  controller: 'ajax',
								  action: 'cargarCiudades',
								  params:'\'id=\' + escape(this.value)',
								  onSuccess: 'cargarCiudades(data,textStatus)'
						  )}"/>
			</g:if>
			<g:else>
				<g:select id="entidad" name="entidad" from="" required="" class="form-control"
						  optionKey="id"
						  optionValue="nombreEntidad"
						  noSelection="['0':'Selecciona ...']"
						  onchange="${remoteFunction(
								  controller: 'ajax',
								  action: 'cargarCiudades',
								  params:'\'id=\' + escape(this.value)',
								  onSuccess: 'cargarCiudades(data,textStatus)'
						  )}"/>
			</g:else>

		</div>
	</div>
</div>


<div class="row">
	<div class="col-md-12">
		<div class="fieldcontain ${hasErrors(bean: puntoVentaInstance, field: 'ciudad', 'error')} required">
			<label for="ciudad">
				<g:message code="puntoVenta.ciudad.label" default="Ciudad" />
				<span class="required-indicator">*</span>
			</label>
			<g:if test="${editable}">
				<g:select id="ciudad" name="ciudad" from="${ciudades.toList()}" optionKey="id" optionValue="nombreCiudad" required="" value="${puntoVentaInstance?.ciudad?.id}" noSelection="['0':'Selecciona ...']" class="form-control"/>
			</g:if>
			<g:else>
				<g:select id="ciudad" name="ciudad" from="" optionKey="id" optionValue="nombreCiudad" required="" noSelection="['0':'Selecciona ...']" class="form-control"/>
			</g:else>

		</div>
	</div>
</div>
<br>

<div class="row">
	<div class="col-md-12">
		<center>
			<button type="button" class="btn btn-primary color-vennda" onclick="generarUbicacion();">
				<image style="width: 25px;" src="${resource(dir: "images", file: "PuntoVenta/PuntoVentaBlanco.png")}"></image>
				<g:message code="puntoVenta.marcarUbicacion.label" default="Marcar ubicación"/>
			</button>
		</center>
	</div>
</div>

<div class="row">
	<div class="col-md-12">
		<div id="mapa" style="width: 100%; height: 300px;"> </div>
	</div>
</div>

<g:hiddenField name="latitud" value="${editable ? puntoVentaInstance.latitud : 0 }"/>
<g:hiddenField name="longitud" value="${editable ? puntoVentaInstance.longitud : 0 }"/>
