<%@ page import="mx.elephantworks.iselling.Cliente" %>

<style>
.row{
	margin-bottom: .5em;
}
</style>


<div class="row">
	<div class="col-md-12">
		<div class="form-group ${hasErrors(bean: clienteInstance, field: 'clave', 'error')} required">
			<label for="clave">
				<g:message code="cliente.clave.label" default="Clave" />
				<span class="required-indicator">*</span>
			</label>
			<g:textField name="clave" required=""  value="${clienteInstance?.clave}" class="form-control"/>
		</div>
	</div>
</div>

<div class="row">
	<div class="col-md-12">
		<div class="form-group ${hasErrors(bean: clienteInstance, field: 'razonSocial', 'error')} required">
			<label for="razonSocial">
				<g:message code="cliente.razonSocial.label" default="Nombre o Razón Social" />
				<span class="required-indicator">*</span>
			</label>
			<g:textField name="razonSocial" required="" value="${clienteInstance?.razonSocial}" class="form-control"/>
		</div>
	</div>
</div>

<div class="row">
	<div class="col-md-6">
		<div class="fieldcontain $${hasErrors(bean: clienteInstance, field: 'listaPrecio', 'error')}required">
			<label for="listaPrecio">
				<g:message code="cliente.listaPrecio.label" default="Lista de Precio" />
				<span class="required-indicator">*</span>
			</label>
			<g:field name="listaPrecios" type="number" max="5" min="1" value="${clienteInstance?.listaPrecios}" required="" class="form-control"/>
		</div>
	</div>
	<div class="col-md-6">
		<div class="fieldcontain ${hasErrors(bean: clienteInstance, field: 'limiteCredito', 'error')} required">
			<label for="limiteCredito">
				<g:message code="cliente.limiteCredito.label" default="Límite de Crédito" />
			</label>
			<g:textField name="limiteCredito" type="number" value="${fieldValue(bean: clienteInstance, field: 'limiteCredito')}" class="form-control" onkeypress="return soloNumerosPunto(event);"/>
		</div>
	</div>
</div>


<div class="row">
	<div class="col-md-12">
		<div class="form-group ${hasErrors(bean: clienteInstance, field: 'diasCredito', 'error')}">
			<label for="diasCredito">
				<g:message code="cliente.diasCredito.label" default="Días de Crédito" />
			</label>
			<g:field name="diasCredito" type="number" value="${clienteInstance?.diasCredito}" required="" class="form-control"/>
		</div>
	</div>
</div>

<div class="row">
	<div class="col-md-12">
		<div class="form-group ${hasErrors(bean: clienteInstance, field: 'email', 'error')}">
			<label for="email">
				<g:message code="cliente.email.label" default="Correo electrónico" />
			</label>
			<g:textField name="email" value="${clienteInstance?.email}" class="form-control"/>
		</div>
	</div>
</div>

<div class="row">
	<div class="col-md-12">
		<div class="form-group ${hasErrors(bean: clienteInstance, field: 'celular', 'error')}">
			<label for="email">
				<g:message code="cliente.celular.label" default="Celular" />
			</label>
			<g:textField name="telefonoCelular" value="${clienteInstance?.telefonoCelular}" class="form-control" onkeypress="return soloNumeros(event);"/>
		</div>
	</div>
</div>

<hr>

<div class="row">
	<div class="col-md-12">
		<div class="form-group ${hasErrors(bean: clienteInstance, field: 'rfc', 'error')}">
			<label for="rfc">
				<g:message code="cliente.rfc.label" default="Rfc" />
			</label>
			<g:textField name="rfc" value="${clienteInstance?.rfc}" class="form-control"/>
		</div>
	</div>
</div>

<div class="row">
	<div class="col-md-12">
		<div class="form-group ${hasErrors(bean: clienteInstance, field: 'domicilio', 'error')}">
			<label for="domicilio">
				<g:message code="cliente.domicilio.label" default="Domicilio" />
			</label>
			<g:textField name="domicilio" value="${clienteInstance?.domicilio}" class="form-control"/>
		</div>
	</div>
</div>

<div class="row">
	<div class="col-md-6">
		<div class="fieldcontain ${hasErrors(bean: clienteInstance, field: 'colonia', 'error')}">
			<label for="colonia">
				<g:message code="cliente.colonia.label" default="Colonia" />
			</label>
			<g:textField name="colonia" value="${clienteInstance?.colonia}" class="form-control"/>
		</div>
	</div>
	<div class="col-md-6">
		<div class="fieldcontain ${hasErrors(bean: clienteInstance, field: 'cp', 'error')}">
			<label for="cp">
				<g:message code="cliente.cp.label" default="Código Postal" />
			</label>
			<g:textField name="cp" value="${clienteInstance?.cp}" class="form-control" onkeypress="return soloNumeros(event);"/>
		</div>
	</div>
</div>


<%--
	<div class="form-group">
		<div class="col-md-6 ${hasErrors(bean: clienteInstance, field: 'estado', 'error')}" style="margin: 0px;padding: 0px">
			<label for="estado">
				<g:message code="cliente.estado.label" default="Estado" />
				<g:textField name="estado" value="${clienteInstance?.estado}" class="form-control"/>
			</label>
		</div>
--%>
<%--
		<div class="col-md-6 ${hasErrors(bean: clienteInstance, field: 'municipio', 'error')}" style="margin: 0px;padding: 0px;text-align: right">
			<label for="municipio">
				<g:message code="cliente.municipio.label" default="Municipio" />
				<g:textField name="municipio" value="${clienteInstance?.municipio}" class="form-control"/>
			</label>
		</div>
	</div>
--%>

	<div class="row">
		<div class="col-md-12">
			<div class="fieldcontain ${hasErrors(bean: clienteInstance, field: 'pais', 'error')} required">
				<label for="pais">
					<g:message code="puntoVenta.pais.label" default="País" />
					<span class="required-indicator">*</span>
				</label>
				<g:select id="pais" name="pais" required="" value="${clienteInstance?.pais?.id}" noSelection="['0':'Selecciona ...']" class="form-control"
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
			<div class="fieldcontain ${hasErrors(bean: clienteInstance, field: 'entidad', 'error')} required">
				<label for="entidad">
					<g:message code="puntoVenta.entidad.label" default="Entidad" />
					<span class="required-indicator">*</span>
				</label>

				<g:if test="${editable}">
					<g:select id="entidad" name="entidad" from="${entidades.toList()}" required="" value="${clienteInstance?.entidad?.id}" class="form-control"
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
			<div class="fieldcontain ${hasErrors(bean: clienteInstance, field: 'ciudad', 'error')} required">
				<label for="ciudad">
					<g:message code="puntoVenta.ciudad.label" default="Ciudad" />
					<span class="required-indicator">*</span>
				</label>
				<g:if test="${editable}">
					<g:select id="ciudad" name="ciudad" from="${ciudades.toList()}" optionKey="id" optionValue="nombreCiudad" required="" value="${clienteInstance?.ciudad?.id}" noSelection="['0':'Selecciona ...']" class="form-control"/>
				</g:if>
				<g:else>
					<g:select id="ciudad" name="ciudad" from="" optionKey="id" optionValue="nombreCiudad" required="" noSelection="['0':'Selecciona ...']" class="form-control"/>
				</g:else>

			</div>
		</div>
	</div>

