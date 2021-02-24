<%@ page import="mx.elephantworks.iselling.Staff" %>
<style>
.row{
	margin-bottom: .5em;
}
</style>

<div class="row">
	<div class="col-md-12">
		<div class="form-group ${hasErrors(bean: staffInstance, field: 'numEmpleado', 'error')} required">
			<label for="numEmpleado">
				<g:message code="staff.numEmpleado.label" default="Número de empleado" />
				<span class="required-indicator">*</span>
			</label>
			<g:textField name="numEmpleado" maxlength="20" required="" value="${staffInstance?.numEmpleado}" class="form-control" onkeypress="return soloNumeros(event);"/>
		</div>
	</div>
</div>

<div class="row">
	<div class="col-md-12">
		<div class="form-group ${hasErrors(bean: staffInstance, field: 'nombre', 'error')} required">
			<label for="nombre">
				<g:message code="staff.nombre.label" default="Nombre(s)" />
				<span class="required-indicator">*</span>
			</label>
			<g:textField name="nombre" maxlength="100" required="" value="${staffInstance?.nombre}" class="form-control"/>
		</div>
	</div>
</div>

<div class="row">
	<div class="col-md-12">
		<div class="form-group ${hasErrors(bean: staffInstance, field: 'apellidos', 'error')} required">
			<label for="apellidos">
				<g:message code="staff.apellidos.label" default="Apellidos" />
				<span class="required-indicator">*</span>
			</label>
			<g:textField name="apellidos" maxlength="100" required="" value="${staffInstance?.apellidos}" class="form-control"/>
		</div>
	</div>
</div>

<div class="row">
	<div class="col-md-12">
		<div class="form-group has-info has-feedback ${hasErrors(bean: staffInstance, field: 'email', 'error')} required">
			<label for="email">
				<g:message code="staff.email.label" default="Email" />
				<span class="required-indicator">*</span>
			</label>
			<div class="input-group">
				<span class="input-group-addon">@</span>
				<g:textField id="email" name="email" maxlength="250" required="" value="${staffInstance?.email}" class="form-control" placeholder="example@gmail.com"/>
			</div>
		</div>
	</div>
</div>

<div class="row">
	<div class="col-md-12">
		<div class="form-group ${hasErrors(bean: staffInstance, field: 'pin', 'error')} required">
			<label for="pin">
				<g:message code="staff.pin.label" default="Pin" />
				<span class="required-indicator">*</span>
			</label>
			<g:textField name="pin" maxlength="4" required="" value="${staffInstance?.pin}" class="form-control" onkeypress="return soloNumeros(event);"/>
		</div>
	</div>
</div>

<div class="row">
	<div class="col-md-12">
		<div class="form-group ${hasErrors(bean: staffInstance, field: 'autorizaCancelacion', 'error')} required">
			<label for="pin">
				<g:message code="staff.autorizaCancelacion.label" default="Autorizar cancelación / devolución" />
			</label>
			<br>
			<label class="switch">
				<g:checkBox name="autorizaCancelacion" value="${staffInstance?.autorizaCancelacion}" class="form-control" />
				<div class="slider round"></div>
			</label>
		</div>
	</div>
</div>

<div class="row">
	<div class="col-md-12">
		<div class="form-group ${hasErrors(bean: staffInstance, field: 'porcentajeDescuento', 'error')} required">
			<label for="pin">
				<g:message code="staff.porcentajeDescuento.label" default="Porcentaje de descuento máximo" />
			</label>
			<g:textField name="porcentajeDescuento" required="" value="${staffInstance?.porcentajeDescuento}" class="form-control" onkeypress="return soloNumerosPunto(event);"/>
		</div>
	</div>
</div>


