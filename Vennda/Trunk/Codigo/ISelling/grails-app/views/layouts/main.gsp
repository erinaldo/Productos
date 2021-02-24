<!DOCTYPE html>
<!--[if lt IE 7 ]> <html lang="en" class="no-js ie6"> <![endif]-->
<!--[if IE 7 ]>    <html lang="en" class="no-js ie7"> <![endif]-->
<!--[if IE 8 ]>    <html lang="en" class="no-js ie8"> <![endif]-->
<!--[if IE 9 ]>    <html lang="en" class="no-js ie9"> <![endif]-->
<!--[if (gt IE 9)|!(IE)]><!--> <html lang="en" class="no-js"><!--<![endif]-->
<head>

	<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
	<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
	<title><g:layoutTitle default="Grails"/></title>
	<meta name="viewport" content="width=device-width, initial-scale=1.0">
	<link rel="shortcut icon" href="${assetPath(src: 'favicon.ico')}" type="image/x-icon">
	<link rel="apple-touch-icon" href="${assetPath(src: 'apple-touch-icon.png')}">
	<link rel="apple-touch-icon" sizes="114x114" href="${assetPath(src: 'apple-touch-icon-retina.png')}">

	<!-- Latest compiled and minified CSS -->
	<link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
	<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css" integrity="sha384-1q8mTJOASx8j1Au+a5WDVnPi2lkFfwwEAa8hDDdjZlpLegxhjVME1fgjWPGmkzs7" crossorigin="anonymous">

	<!-- Mensajes -->
	<g:javascript>
			globalMessages = new Array();
				globalMessages['default.button.delete.confirm.message'] = '${message(code: 'default.button.delete.confirm.message', default: 'Are you sure?')}';

			globalUrls = new Array();
				globalUrls['ajax.productosEmpresa'] = '${createLink(controller: "ajax", action: 'productosEmpresa')}';
				globalUrls['ajax.crearProductoPrecio'] = '${createLink(controller: "ajax", action: 'crearProductoPrecio')}';
				globalUrls['ajax.eliminarProductoPrecio'] = '${createLink(controller: "ajax", action: 'eliminarProductoPrecio')}';
				globalUrls['ajax.actualizarProductoPrecio'] = '${createLink(controller: "ajax", action: 'actualizarProductoPrecio')}';
				globalUrls['ajax.addValorImpuestoForm'] = '${createLink(controller: "ajax", action: 'addValorImpuestoForm')}';
				globalUrls['ajax.removeValorImpuesto'] = '${createLink(controller: "ajax", action: 'removeValorImpuesto')}';
	</g:javascript>

	<!-- jQuery -->
	<script   src="https://code.jquery.com/jquery-1.12.4.min.js"   integrity="sha256-ZosEbRLbNQzLpnKIkEdrPv7lOy9C27hHQ+Xp8a4MxAQ="   crossorigin="anonymous"></script>
	<script   src="https://code.jquery.com/ui/1.12.1/jquery-ui.min.js"   integrity="sha256-VazP97ZCwtekAsvgPBSUwPFKdrwD3unUfSGVYrahUqU="   crossorigin="anonymous"></script>

	<!-- Latest compiled and minified JavaScript -->
	<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js" integrity="sha384-0mSbJDEHialfmuBBQP6A4Qrprq5OVfW37PRR3j5ELqxss1yVqOtnepnHVP9aJ7xS" crossorigin="anonymous"></script>


	<!-- Select2 -->
	<script src="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.3/js/select2.min.js"></script>
	<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.3/css/select2.min.css">
	<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/select2-bootstrap-theme/0.1.0-beta.6/select2-bootstrap.min.css">

	<!-- Java script para pais, entidades y ciudad-->
	<asset:javascript src="direccion.js"></asset:javascript>

	<!-- plugin para tablas -->
	<link rel="stylesheet" href="${resource(dir: "stylesheets", file: "jquery.dataTables.min.css")}">
	<link rel="stylesheet" href="${resource(dir: "stylesheets", file: "jquery.dataTables_themeroller.css")}">
	<asset:javascript src="jquery.dataTables.min.js"></asset:javascript>
	<asset:javascript src="dataTables.bootstrap.min.js"></asset:javascript>
	<asset:javascript src="jquery-ui.js"></asset:javascript>
	<g:layoutHead/>


	<style>
		.semi-circulo-arriba {
			border-radius: 50% / 100%;
			border-top-left-radius: 0;
			border-top-right-radius: 0;
		}

		.semi-circulo-abajo {
			border-radius: 50% / 100%;
			border-bottom-left-radius: 0;
			border-bottom-right-radius: 0;

			width: 100%;
			position: absolute;
			bottom: 0;
			left: 0;
		}

		.color-vennda{
			background-color: #48BFE6;
		}

		.banner-estilo{
			height: 3.5em;
			border-bottom: 2px solid #48BFE6;
			-webkit-box-shadow: 0px 13px 18px -10px rgba(72,191,230,1);
			-moz-box-shadow: 0px 13px 18px -10px rgba(72,191,230,1);
			box-shadow: 0px 13px 18px -10px rgba(72,191,230,1);
			background-color: #FFFFFF;

		}
		.encabezadoPanelFormulario{
			font-family: "Arial";
			font-size: 20px;
			color:#FFF;
			text-align: left;
		}
		.mensaje{
			font-family: "Arial";
			font-size: 20px;
			color: #666666;
		}

		.contenedor{
			margin: auto;
			width: 60%;
			color: #31708f;
		}
		.contenido{
			color: #666666;
		}
		.nav-tabs {
			border-bottom: 0px;
		}
		.SubMenu{
			background-color: #FFFFFF;
			border:0px;
		}
		li:hover .imgCliente{
			width: 50px;
		}
		li:hover .imgCerrarSesion{
			width: 45px;
		}
		.iconoVennda:hover{
			background-color: #FFFFFF;
		}
		.separador{
			border-bottom: 2px solid #48BFE6;
			box-shadow: 0px 0px 20px 6px #48BFE6;
		}
		hr{
			border: 1px solid #48BFE6;
		}
		/*Estilo para radio button si o no*/
		.switch {
			position: relative;
			display: inline-block;
			width: 60px;
			height: 34px;
		}

		.switch input {display:none;}

		.slider {
			position: absolute;
			cursor: pointer;
			top: 0;
			left: 0;
			right: 0;
			bottom: 0;
			background-color: #ccc;
			-webkit-transition: .4s;
			transition: .4s;
		}

		.slider:before {
			position: absolute;
			content: "";
			height: 26px;
			width: 26px;
			left: 4px;
			bottom: 4px;
			background-color: white;
			-webkit-transition: .4s;
			transition: .4s;
		}

		input:checked + .slider {
			background-color: #48BFE6;
		}

		input:focus + .slider {
			box-shadow: 0 0 1px #48BFE6;
		}

		input:checked + .slider:before {
			-webkit-transform: translateX(26px);
			-ms-transform: translateX(26px);
			transform: translateX(26px);
		}

		/* Rounded sliders */
		.slider.round {
			border-radius: 34px;
		}

		.slider.round:before {
			border-radius: 50%;
		}
		/*Fin estilo de radio button*/

		.table-responsive{
			overflow: hidden;
		}

	</style>
	<script>
        // Solo permite ingresar numeros.
        function soloNumeros(e){
            var key = window.Event ? e.which : e.keyCode;
            return (key >= 48 && key <= 57)
        }
        var nav4 = window.Event ? true : false;
        function soloNumerosPunto(evt){
            /*console.log(valor);
			var pasa = true;
            var regex  = /^\d+(?:\.\d{0,2})$/;

            if (regex.test(valor))
                pasa = false;

            return pasa*/

            // NOTE: Backspace = 8, Enter = 13, '0' = 48, '9' = 57, '.' = 46
            var key = nav4 ? evt.which : evt.keyCode;
            return (key <= 13 || (key >= 48 && key <= 57) || key == 46);
        }
	</script>
</head>
<body style="background-color: #F5F5F5">
<div class="row">
	<div class="nav nav-pills separador" style="background-color: #FFFFFF">
		<ul class="nav nav-pills">
			<div class="nav nav-pills col-md-2">
				<li role="presentation" class="iconoVennda" style="">
					<a  style="padding: 0;margin-left: 2em;"  href="${createLink(uri: '/')}" >
						<image src="${resource(dir: "images", file: "grails_logo.png")}"></image>
					</a>
				</li>
			</div>
		<sec:ifLoggedIn>
			<%-- Menu Empresa Inicio --%>
			<div class="nav nav-pills col-md-10" style="margin-top: 10px;">
				<sec:ifAllGranted roles="ROLE_EMPRESA">
					<li id="liCliente" class="dropdown Menu">
						<a style="margin: 0px; padding: 0px;padding-right: 30px;"  class="dropdown-toggle" data-toggle="dropdown" href="#" role="button" aria-haspopup="true" aria-expanded="false">
							<image class="imgCliente" width="40px" alt="Cuentas" src="${resource(dir: "images", file: "Cuenta.png")}"></image>
							Cuenta <span class="caret"></span>
						</a>
						<ul class="dropdown-menu SubMenu">
							<li>
								<g:link controller="empresa" action="index">Mi Perfil</g:link>
							</li>
						</ul>
					</li>
					<li class="dropdown">
						<a style="margin: 0px; padding: 0px;padding-right: 30px;"  class="dropdown-toggle" data-toggle="dropdown" href="#" role="button" aria-haspopup="true" aria-expanded="false">
							<image class="imgCliente" width="40px" alt="Ventas" src="${resource(dir: "images", file: "Ventas.png")}"></image>
							Ventas <span class="caret"></span>
						</a>

					</li>
					<li class="dropdown">
						<a style="margin: 0px; padding: 0px;padding-right: 30px;"  class="dropdown-toggle" data-toggle="dropdown" href="#" role="button" aria-haspopup="true" aria-expanded="false">
							<image class="imgCliente" width="40px" alt="Ventas" src="${resource(dir: "images", file: "Productos.png")}"></image>
							Productos <span class="caret"></span>
						</a>
						<ul class="dropdown-menu">
							<li>
								<g:link controller="producto" action="index">Productos</g:link>
							</li>
							<li>
								<g:link controller="categoria" action="index">Categorias</g:link>
							</li>
						</ul>
					</li>
					<li class="dropdown">
						<a style="margin: 0px; padding: 0px;padding-right: 30px;"  class="dropdown-toggle" data-toggle="dropdown" href="#" role="button" aria-haspopup="true" aria-expanded="false">
							<image class="imgCliente" width="40px" alt="Clientes" src="${resource(dir: "images", file: "cliente/clienteAzul.png")}"></image>
							Clientes <span class="caret"></span>
						</a>
						<ul class="dropdown-menu">
							<li>
								<g:link resource="cliente">Clientes</g:link>
							</li>
							<li>
								<g:link controller="cobranza" action="index">Cobranza</g:link>
							</li>
						</ul>
					</li>
					<li class="dropdown">
						<a style="margin: 0px; padding: 0px;padding-right: 30px;"  class="dropdown-toggle" data-toggle="dropdown" href="#" role="button" aria-haspopup="true" aria-expanded="false">
							<image class="imgCliente" width="40px" alt="Puntos de venta" src="${resource(dir: "images", file: "PuntoVenta.png")}"></image>
							Puntos de venta <span class="caret"></span>
						</a>
						<ul class="dropdown-menu">
							<li>
								<g:link controller="puntoVenta" action="index">Punto de venta</g:link>
							</li>
							<li>
								<g:link controller="inventario" action="index">Inventario</g:link>
							</li>
							<li>
								<g:link controller="staff" action="index">Staff</g:link>
							</li>

						</ul>
					</li>
			    </sec:ifAllGranted>
				<sec:ifAllGranted roles="ROLE_SUPERADMIN">
					<li class="dropdown">
						<g:link controller="unidad" style="margin: 0px; padding: 0px;padding-right: 30px;"  class="dropdown-toggle"  role="button" aria-haspopup="true" aria-expanded="false">
							<image class="imgCliente" width="40px" alt="Unidades" src="${resource(dir: "images", file: "Unidad/unidadAzul.png")}"></image>
							Unidades
						</g:link>
					</li>
					<li class="dropdown">
						<g:link controller="impuesto" style="margin: 0px; padding: 0px;padding-right: 30px;"  class="dropdown-toggle"  role="button" aria-haspopup="true" aria-expanded="false">
							<image class="imgCliente" width="40px" alt="Impuesto" src="${resource(dir: "images", file: "Impuesto/impuestoAzul.png")}"></image>
							Impuestos
						</g:link>
					</li>
					<li class="dropdown">
						<g:link controller="plan" style="margin: 0px; padding: 0px;padding-right: 30px;"  class="dropdown-toggle"  role="button" aria-haspopup="true" aria-expanded="false">
							<image class="imgCliente" width="40px" alt="Plan" src="${resource(dir: "images", file: "Plan/planAzul.png")}"></image>
							Planes
						</g:link>
					</li>
				</sec:ifAllGranted>

				<%-- Menu Empresa Fin --%>

				<li class="dropdown">
					<g:link controller="logout" style="margin: 0px; padding: 0px;padding-right: 30px;"  class="dropdown-toggle"  role="button" aria-haspopup="true" aria-expanded="false">
						<image class="imgCliente" width="40px" alt="Salir" src="${resource(dir: "images", file: "logout.png")}"></image>
						Cerrar Sesión
					</g:link>
				</li>
			</div>
		</ul>
		</sec:ifLoggedIn>
	</div>
</div>
<div class="container-fluid">
	<g:layoutBody/>
</div>
<br>
<div id="spinner" class="spinner" style="display:none;"><g:message code="spinner.alt" default="Loading&hellip;"/></div>
</body>
</html>
