<%@ page import="mx.elephantworks.iselling.Unidad" %>



<div class="form-group ${hasErrors(bean: unidadInstance, field: 'abreviatura', 'error')} required">
	<label for="abreviatura">
		<g:message code="unidad.abreviatura.label" default="Abreviatura" />
		<span class="required-indicator">*</span>
	</label>
	<g:textField name="abreviatura" required="" value="${unidadInstance?.abreviatura}" class="form-control"/>

</div>

<div class="form-group ${hasErrors(bean: unidadInstance, field: 'descripcion', 'error')} required">
	<label for="descripcion">
		<g:message code="unidad.descripcion.label" default="Descripcion" />
		<span class="required-indicator">*</span>
	</label>
	<g:textField name="descripcion" required="" value="${unidadInstance?.descripcion}" class="form-control"/>

</div>



