<%@ page import="mx.elephantworks.iselling.Producto" %>
<style>
.imageMas{
	width: 30px;
	margin: auto;
}
.imageMas:hover{
	width: 35px;
}
</style>
<style>
label span input {
	z-index: 999;
	line-height: 0;
	font-size: 50px;
	position: absolute;
	top: -2px;
	left: -700px;
	opacity: 0;
	filter: alpha(opacity = 0);
	-ms-filter: "alpha(opacity=0)";
	cursor: pointer;
	_cursor: hand;
	margin: 0;
	padding:0;
}
</style>
<g:hiddenField id="imagen" name="imagen" value="${productoInstance?.imagen}" class="form-control"></g:hiddenField>
<g:hiddenField  name="logoHidden" value="${productoInstance?.imagen}" class="form-control"></g:hiddenField>


<br>

<div class="row">
	<div class="col-md-6">
		<div class="form-group ${hasErrors(bean: productoInstance, field: 'codigoBarras', 'error')} ">
			<label for="codigoBarras">
				<g:message code="producto.codigoBarras.label" default="Codigo Barras" />
				<span class="required-indicator">*</span>
			</label>
			<g:textField name="codigoBarras" id="codigoBarras" value="${productoInstance?.codigoBarras}" class="form-control"/>
		</div>
	</div>
	<div class="col-md-6">
		<div class="form-group ${hasErrors(bean: productoInstance, field: 'clave', 'error')} required">
			<label for="clave">
				<g:message code="producto.clave.label" default="Clave" />
				<span class="required-indicator">*</span>
			</label>
			<g:textField name="clave" required="" value="${productoInstance?.clave}" class="form-control"/>
		</div>
	</div>
</div>

<div class="row">
	<div class="col-md-12">
		<div class="form-group ${hasErrors(bean: productoInstance, field: 'nombre', 'error')} required">
			<label for="nombre">
				<g:message code="producto.nombre.label" default="Nombre" />
				<span class="required-indicator">*</span>
			</label>
			<g:textField name="nombre" id="nombre" required="" value="${productoInstance?.nombre}" class="form-control" />
		</div>
	</div>
</div>

<div class="row">
	<div class="col-md-12">
		<div class="form-group ${hasErrors(bean: productoInstance, field: 'descripcion', 'error')} required">
			<label for="descripcion">
				<g:message code="producto.descripcion.label" default="Descripcion" />
				<span class="required-indicator">*</span>
			</label>
			<g:textArea name="descripcion" id="descripcion" required="" value="${productoInstance?.descripcion}" class="form-control" style="width: 500px; height: 105px; max-width: 500px; max-height: 105px;"/>
		</div>
	</div>
</div>

<div class="row">
	<div class="col-md-6">
		<div class="form-group ${hasErrors(bean: productoInstance, field: 'categoria', 'error')} required">
			<label for="categoria">
				<g:message code="producto.categoria.label" default="Categoría" />
				<span class="required-indicator">*</span>
			</label>
			<g:select
					id="categoria"
					name="categoria.id"
					from="${mx.elephantworks.iselling.Categoria.filtroEmpresa(params.usuario).list()}"
					optionKey="id"
					required=""
					value="${productoInstance?.categoria?.id}"
					class="many-to-one form-control"/>
		</div>
	</div>

	<div class="col-md-6">
		<div class="form-group ${hasErrors(bean: productoInstance, field: 'unidad', 'error')} required">
			<label for="unidad">
				<g:message code="producto.unidad.label" default="Unidad" />
				<span class="required-indicator">*</span>
			</label>
			<g:select
					id="unidad"
					name="unidad.id"
					from="${mx.elephantworks.iselling.Unidad.list()}"
					optionKey="id"
					optionValue="descripcion"
					required=""
					value="${productoInstance?.unidad?.id}"
					class="many-to-one form-control"/>
		</div>
	</div>
</div>

<hr>
<div class="row">
	<div class="col-md-9">
		<div class="form-group ${hasErrors(bean: productoInstance, field: 'impuesto', 'error')}">
			<label for="impuesto">
				<g:message code="producto.impuesto.label" default="Impuesto" />
			</label>
			<g:select id="impuesto"
					  name="impuestos"
					  from="${mx.elephantworks.iselling.Impuesto.activos().list()}"
					  optionKey="id"
					  optionValue="identificador"
					  required=""
					  value=""
					  class="form-control"/>

		</div>
	</div>

	<div class="col-md-3" style="margin: auto;">
		<br>
		<image class="imageInButton imageMas" onclick="agregarImpuesto();" src="${resource(dir:"images", file: "anadir.png")}"></image>
		<image class="imageInButton imageMas" onclick="quitarImpuesto();" src="${resource(dir:"images", file: "boton-eliminar.png")}"></image>
	</div>
</div>

<div id="listaImpuestos"></div>

<hr>
<div class="row">
	<div class="col-md-9">
		<div class="form-group ${hasErrors(bean: productoInstance, field: 'precio', 'error')} required">
			<label for="precio">
				<g:message code="producto.precio.label" default="Precio 1" />
				<span class="required-indicator">*</span>
			</label>
			<g:textField name="precio" value="${fieldValue(bean: productoInstance, field: 'precio').toString().replace(',','.')}" required="" class="form-control" onkeypress="return soloNumerosPunto(event);"/>
		</div>
	</div>
	<div class="col-md-3" style="margin: auto;">
		<br>
		<image class="imageInButton imageMas" onclick="agregarPrecio();" src="${resource(dir:"images", file: "anadir.png")}"></image>
		<image class="imageInButton imageMas" onclick="quitarPrecio();" src="${resource(dir:"images", file: "boton-eliminar.png")}"></image>

	</div>
</div>

<div id="listaPrecios"></div>

<hr>

<g:hiddenField name="contadorImpuesto"/>


<script type="text/javascript">
    $( document ).ready(function() {

        $("#btnUpload").css("visibility", "hidden");

        $("#fileInput").change(function() {

            var codigoBarras1 = $("#codigoBarras").val();

            if(codigoBarras1 == null || codigoBarras1 == ""){
                alert("Es necesario ingresar antes el código de barras");
            }else{


                var UrlIdEmpresa = "${createLink(controller:'Producto',action:'obtenerCodigoBarrasID')}";

                var jsonData = $.ajax({
                    url:UrlIdEmpresa,
                    data:{codigoBarras: codigoBarras1},
                    dataType: "json",
                    async: false
                }).responseText;

                var objResponseRcv = JSON.parse(jsonData);

                var idProducto = objResponseRcv["idProducto"];
                var codigoBarras = objResponseRcv["codigoBarras"];

                var nombreFinalProducto = idProducto + "_"+ codigoBarras1;


                var img = $('input[type=file]').val().replace(/C:\\fakepath\\/i, '');

                //Validar que sea un archivo con extensiòn png, jpg o gif
                var ImgRcv = img.toLowerCase();
                var longitudImg = ImgRcv.length;
                var extension = ImgRcv.substring(longitudImg-3,longitudImg);

                if(extension == "png" || extension == "jpg" || extension == "gif"){

                    nombreFinalProducto = nombreFinalProducto + ".png";
                    $("#txtCodigoBarras").val(nombreFinalProducto);
                    document.cookie = nombreFinalProducto;
                    $("#btnUpload").click();
                }else{
                    alert("Eliga un archivo con extensión (PNG, JGP o GIF)");
                }
            }



        });
        var x = document.cookie;
        var accionActual =  window.location.href;
        if(accionActual.includes("create")){
            var codigoBar = x;
            var guion = codigoBar.search("_");


            codigoBar = codigoBar.substring(guion+1,codigoBar.length);
            codigoBar = codigoBar.substring(0,codigoBar.length-4);

            $("#codigoBarras").val(codigoBar);
		}

        if(x){
            if(accionActual.includes("edit")){
                $("#imgDiv").attr("src", "../../imgProductos/" + x);
            }else {

                $("#imgDiv").attr("src", "../imgProductos/" + x);
            }
        }else{
            var logoHidden = $("#logoHidden").val();
            if(logoHidden){
                if(accionActual.includes("edit")){
                    $("#imgDiv").attr("src", "../../imgProductos/" + logoHidden);
                }else {
                    $("#imgDiv").attr("src", "../imgProductos/" + logoHidden);
                }
            }else{

                if(accionActual.includes("edit")){
                    $("#imgDiv").attr("src","../../assets/camara.png");
                }else{
                    $("#imgDiv").attr("src","../assets/camara.png");
                }
            }

        }
        $("#actualizarPerfil").click(function() {
            if(x != null || x != "" ){
                $("#imagen").val(x);
            }
        });
        document.cookie = "";

		/*$('#unidad').select2();
		$('#impuesto').select2();
		$('#categoria').select2({
			"language": {
				"noResults": function(){
					return "No Results Found <a href='#' class='btn btn-danger'>Use it anyway</a>";
				}
			},
			escapeMarkup: function (markup) {
				return markup;
			}
		});*/

		console.log("pasa");
		var inputCondigoBarras = $('#codigoBarras');

		inputCondigoBarras.focusout(function() {
			console.log("pasa");
			callAjax(inputCondigoBarras.val())
		});
    });





	//codigo ldelatorre

	function callAjax(codigoBarras){

		var inputNombre = $('#nombre');
		var inputDescripcion = $('#descripcion');

		var URL="${createLink(controller:'producto',action:'productoMasterAjax')}";

		$.ajax({
			url:URL,
			data: {codigoBarras:codigoBarras},
			success: function(resp){
				console.log(resp);
				inputNombre.val(resp.nombre);
				inputDescripcion.val(resp.descripcion);

			}
		});

	}

</script>


