<%@ page import="mx.elephantworks.iselling.Empresa" %>




<g:hiddenField id="logo" name="logo" value="${empresaInstance?.logo}" class="form-control"></g:hiddenField>
<g:hiddenField  name="logoHidden" value="${empresaInstance?.logo}" class="form-control"></g:hiddenField>

<div class="row">
	<div class="col-md-12">
		<div class="form-group ${hasErrors(bean: empresaInstance, field: 'username', 'error')} required">
			<label for="username">
				<g:message code="usuario.username.label" default="Email" />
				<span class="required-indicator">*</span>
			</label>
			<g:textField name="username" required="" value="${empresaInstance?.username}" class="form-control"/>
		</div>
	</div>
</div>

<div class="row">
	<div class="col-md-12">
		<div class="form-group ${hasErrors(bean: empresaInstance, field: 'tipoCuenta', 'error')} ">
			<label for="tipoCuenta">
				<g:message code="empresa.tipoCuenta.label" default="Tipo Cuenta" />
			</label>
			<g:select id="tipoCuenta" name="tipoCuenta.id" from="${mx.elephantworks.iselling.TipoCuenta.list()}" optionKey="id" value="${empresaInstance?.tipoCuenta?.id}" noSelection="['null': '']" class="form-control"/>
		</div>
	</div>
</div>

<div class="row">
	<div class="col-md-12">
		<div class="form-group ${hasErrors(bean: empresaInstance, field: 'nombreEmpresa', 'error')} required">
			<label for="nombreEmpresa">
				<g:message code="empresa.nombreEmpresa.label" default="Nombre Empresa" />
				<span class="required-indicator">*</span>
			</label>
			<g:textField name="nombreEmpresa" required="" value="${empresaInstance?.nombreEmpresa}" class="form-control"/>
		</div>
	</div>
</div>

<div class="row">
	<div class="col-md-12">
		<div class="form-group ${hasErrors(bean: empresaInstance, field: 'nombre', 'error')} ">
			<label for="nombre">
				<g:message code="empresa.nombre.label" default="Nombre" />
			</label>
			<g:textField name="nombre" value="${empresaInstance?.nombre}" class="form-control"/>
		</div>
	</div>
</div>

<div class="row">
	<div class="col-md-12">
		<div class="form-group ${hasErrors(bean: empresaInstance, field: 'apellidoPaterno', 'error')} ">
			<label for="apellidoPaterno">
				<g:message code="empresa.apellidoPaterno.label" default="Apellido Paterno" />
			</label>
			<g:textField name="apellidoPaterno" value="${empresaInstance?.apellidoPaterno}" class="form-control"/>
		</div>
	</div>
</div>

<div class="row">
	<div class="col-md-12">
		<div class="form-group ${hasErrors(bean: empresaInstance, field: 'apellidoMaterno', 'error')} ">
			<label for="apellidoMaterno">
				<g:message code="empresa.apellidoMaterno.label" default="Apellido Materno" />
			</label>
			<g:textField name="apellidoMaterno" value="${empresaInstance?.apellidoMaterno}" class="form-control"/>
		</div>
	</div>
</div>

<div class="row">
	<div class="col-md-12">
		<div class="form-group ${hasErrors(bean: empresaInstance, field: 'curp', 'error')} ">
			<label for="curp">
				<g:message code="empresa.curp.label" default="Curp" />
			</label>
			<g:textField name="curp" value="${empresaInstance?.curp}" class="form-control"/>
		</div>
	</div>
</div>

<div class="row">
	<div class="col-md-12">
		<div class="form-group ${hasErrors(bean: empresaInstance, field: 'rfc', 'error')} ">
			<label for="rfc">
				<g:message code="empresa.rfc.label" default="RFC" />
			</label>
			<g:textField name="rfc" value="${empresaInstance?.rfc}" class="form-control"/>
		</div>
	</div>
</div>

<div class="row">
	<div class="col-md-12">
		<div class="form-group ${hasErrors(bean: empresaInstance, field: 'direccion', 'error')} ">
			<label for="direccion">
				<g:message code="empresa.direccion.label" default="Direccion" />
			</label>
			<g:textField name="direccion" value="${empresaInstance?.direccion}" class="form-control"/>
		</div>
	</div>
</div>

<div class="row">
	<div class="col-md-6">
		<div class="form-group ${hasErrors(bean: empresaInstance, field: 'cp', 'error')} ">
			<label for="cp">
				<g:message code="empresa.cp.label" default="Cp" />
			</label>
			<g:textField name="cp" value="${empresaInstance?.cp}" class="form-control" class="form-control"/>
		</div>
	</div>
	<div class="col-md-6">
		<div class="form-group ${hasErrors(bean: empresaInstance, field: 'colonia', 'error')} ">
			<label for="colonia">
				<g:message code="empresa.colonia.label" default="Colonia" />
			</label>
			<g:textField name="colonia" value="${empresaInstance?.colonia}" class="form-control"/>
		</div>
	</div>
</div>


<div class="row">
	<div class="col-md-12">
		<div class="fieldcontain ${hasErrors(bean: empresaInstance, field: 'pais', 'error')} required">
			<label for="pais">
				<g:message code="empresa.pais.label" default="País" />
				<span class="required-indicator">*</span>
			</label>
			<g:select id="pais" name="pais" required="" value="${empresaInstance?.pais?.id}" noSelection="['0':'Selecciona ...']" class="form-control"
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
		<div class="fieldcontain ${hasErrors(bean: empresaInstance, field: 'entidad', 'error')} required">
			<label for="entidad">
				<g:message code="empresa.entidad.label" default="Entidad" />
				<span class="required-indicator">*</span>
			</label>

			<g:if test="${entidades}">
				<g:select id="entidad" name="entidad" from="${entidades.toList()}" required="" value="${empresaInstance?.entidad?.id}" class="form-control"
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
		<div class="fieldcontain ${hasErrors(bean: empresaInstance, field: 'ciudad', 'error')} required">
			<label for="ciudad">
				<g:message code="puntoVenta.ciudad.label" default="Ciudad" />
				<span class="required-indicator">*</span>
			</label>
			<g:if test="${ciudades}">
				<g:select id="ciudad" name="ciudad" from="${ciudades.toList()}" optionKey="id" optionValue="nombreCiudad" required="" value="${empresaInstance?.ciudad?.id}" noSelection="['0':'Selecciona ...']" class="form-control"/>
			</g:if>
			<g:else>
				<g:select id="ciudad" name="ciudad" from="" optionKey="id" optionValue="nombreCiudad" required="" noSelection="['0':'Selecciona ...']" class="form-control"/>
			</g:else>

		</div>
	</div>
</div>

<%--
<div class="form-group ${hasErrors(bean: empresaInstance, field: 'ciudad', 'error')} ">
	<label for="ciudad">
		<g:message code="empresa.ciudad.label" default="Ciudad" />

	</label>
	<g:textField name="ciudad" value="${empresaInstance?.ciudad}" class="form-control"/>

</div>

<div class="form-group ${hasErrors(bean: empresaInstance, field: 'estado', 'error')} ">
	<label for="estado">
		<g:message code="empresa.estado.label" default="Estado" />

	</label>
	<g:textField name="estado" value="${empresaInstance?.estado}" class="form-control"/>
</div>
--%>


<script type="text/javascript">
    $( document ).ready(function() {
        $("#btnUpload").css("visibility", "hidden");

        $("#fileInput").change(function() {

            var UrlIdEmpresa = "${createLink(controller:'Empresa',action:'obtenerCodigoBarrasID',id:empresaInstance?.id)}";


            var jsonData = $.ajax({
                url:UrlIdEmpresa,
                dataType: "json",
                async: false
            }).responseText;

            var objResponseRcv = JSON.parse(jsonData);

            var img = $('input[type=file]').val().replace(/C:\\fakepath\\/i, '');
            //Validar que sea un archivo con extensiòn png, jpg o gif
            var ImgRcv = img.toLowerCase();
            var longitudImg = ImgRcv.length;
            var extension = ImgRcv.substring(longitudImg-3,longitudImg);

            if(extension == "png" || extension == "jpg" || extension == "gif"){

                document.cookie = objResponseRcv["idEmpresa"]+".png";
                $("#btnUpload").click();
            }else{
                alert("Eliga un archivo con extensión (PNG, JGP o GIF)");
            }

        });

        var x = document.cookie;

        if(x){

            $("#imgDiv").attr("src","../../imgLogo/"+x);
		}else{
            var logoHidden = $("#logoHidden").val();

            if(logoHidden){
                $("#imgDiv").attr("src","../../imgLogo/"+logoHidden);
			}else{
                $("#imgDiv").attr("src","../../assets/camara.png");
			}

		}
        $("#actualizarPerfil").click(function() {
            $("#logo").val(x);

        });
        document.cookie = "";

    });

</script>




