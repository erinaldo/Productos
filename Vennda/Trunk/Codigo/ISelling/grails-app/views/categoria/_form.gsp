<%@ page import="mx.elephantworks.iselling.Categoria" %>
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

<g:hiddenField id="imagen" name="imagen" value="${categoriaInstance?.imagen}" class="form-control"></g:hiddenField>
<g:hiddenField  name="logoHidden" value="${categoriaInstance?.imagen}" class="form-control"></g:hiddenField>


<br>

<div class="form-group ${hasErrors(bean: categoriaInstance, field: 'identificador', 'has-error')} required">
	<label for="identificador">
		<g:message code="categoria.identificador.label" default="Identificador" />
		<span class="required-indicator">*</span>
	</label>
	<g:textField id="identificador" name="identificador" required="" value="${categoriaInstance?.identificador}" class="form-control"/>

</div>

<div class="form-group ${hasErrors(bean: categoriaInstance, field: 'nombre', 'has-error')} required">
	<label for="nombre">
		<g:message code="categoria.nombre.label" default="Nombre" />
		<span class="required-indicator">*</span>
	</label>
	<g:textField name="nombre" required="" value="${categoriaInstance?.nombre}" class="form-control"/>

</div>

<script type="application/javascript">
	$("select[name=productos]").select2({multiple:true});
</script>

<script type="text/javascript">
	$( document ).ready(function() {

		$("#btnUpload").css("visibility", "hidden");

		$("#fileInput").change(function() {



			var identificador1 = $("#identificador").val();



			if(identificador1 == null || identificador1 == ""){
				alert("Es necesario ingresar antes el identificador de la categoría");
			}else{


				var UrlIdEmpresa = "${createLink(controller:'Categoria',action:'obtenerIdentificadorID')}";

				var jsonData = $.ajax({
					url:UrlIdEmpresa,
					data:{identificador: identificador1},
					dataType: "json",
					async: false
				}).responseText;

				var objResponseRcv = JSON.parse(jsonData);

				var idEmpresa = objResponseRcv["idEmpresa"];
				var identificador = objResponseRcv["identificador"];

				var nombreFinalCategoria = idEmpresa + "_"+ identificador;


				var img = $('input[type=file]').val().replace(/C:\\fakepath\\/i, '');

				//Validar que sea un archivo con extensiòn png, jpg o gif
				var ImgRcv = img.toLowerCase();
				var longitudImg = ImgRcv.length;
				var extension = ImgRcv.substring(longitudImg-3,longitudImg);

				if(extension == "png" || extension == "jpg" || extension == "gif"){

					nombreFinalCategoria = nombreFinalCategoria + ".png";

					$("#txtIdentificador").val(nombreFinalCategoria);
					document.cookie = nombreFinalCategoria;
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
			$("#identificador").val(codigoBar);
		}

		if(x){
			if(accionActual.includes("edit")){
				$("#imgDiv").attr("src", "../../imgCategorias/" + x);
			}else {

				$("#imgDiv").attr("src", "../imgCategorias/" + x);
			}
		}else{
			var logoHidden = $("#logoHidden").val();
			if(logoHidden){
				if(accionActual.includes("edit")){
					$("#imgDiv").attr("src", "../../imgCategorias/" + logoHidden);
				}else {
					$("#imgDiv").attr("src", "../imgCategorias/" + logoHidden);
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
	});

</script>
