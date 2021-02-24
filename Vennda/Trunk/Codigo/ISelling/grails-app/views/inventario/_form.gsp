<%@ page import="mx.elephantworks.iselling.Inventario" %>

<style>
.row{
	margin-bottom: .5em;
}
.imageInButton{
	width:25px;
}
.imageMas{
	width: 30px;
	margin: auto;
}
.imageMas:hover{
	width: 35px;

}

thead{
	background-color: #1c94c4;
	text-align: center;

}
thead tr th{
	font-family: "Arial";
	font-size: 14px;
	color:#FFF;
	text-align: center;
}
tbody tr{
	background-color: #D8DFE5;
	font-family: "Arial";
	font-size: 12px;
	color:#000;
	text-align: center;
}
tbody tr td{
	border-bottom: 1px solid #9B9B9B;
}
</style>

<div class="row">
	<div class="col-md-12">
		<div class="fieldcontain ${hasErrors(bean: inventarioInstance, field: 'puntoVenta', 'error')} required">
			<label for="puntoVenta">
				<g:message code="inventario.puntoVenta.label" default="Punto Venta" />
				<span class="required-indicator">*</span>
			</label>
			<g:select id="puntoVenta" name="puntoVenta.id" from="${puntoVentas.toList()}" optionKey="id" optionValue="nombreNegocio" value="${punto?.id}" noSelection="['0':'Selecciona ...']" class="many-to-one form-control" disabled="true"/>
			<g:hiddenField name="puntoVenta.id" value="${punto?.id}"/>
		</div>
	</div>
</div>

<div class="row">
	<div class="col-md-12">
		<div class="fieldcontain ${hasErrors(bean: inventarioInstance, field: 'produto', 'error')} required">
			<label for="produto">
				<g:message code="inventario.produto.label" default="Produto" />
				<span class="required-indicator">*</span>
			</label>
			<g:select id="producto" name="producto.id" from="${productos.toList()}" optionKey="id" optionValue="nombre" required="" value="${inventarioInstance?.producto?.id}" noSelection="['0':'Selecciona ...']" class="many-to-one form-control"/>
		</div>
	</div>
</div>

<div class="row">
	<div class="col-md-10">
		<div class="fieldcontain ${hasErrors(bean: inventarioInstance, field: 'cantidad', 'error')} required">
			<label for="cantidad">
				<g:message code="inventario.cantidad.label" default="Cantidad" />
				<span class="required-indicator">*</span>
			</label>
			<g:textField class="form-control" id="cantidad" name="cantidad" value="${inventarioInstance.cantidad}" required="" onkeypress="return soloNumerosPunto(event);"/>
		</div>
	</div>
	<div class="col-md-2" style="padding-top: 1.7em;">
		<image class="imageInButton imageMas" id="agregarFila" src="${resource(dir:"images", file: "anadir.png")}"></image>
	</div>
</div>

<div class="row" style="padding-top: 2em;">
	<div class="col-md-12">
		<table id="cantidades" class="display table table-hover">
			<thead>
				<tr>
					<th><g:message code="inventario.puntoVenta.label" default="Punto de Venta" />

					<th><g:message code="inventario.producto.label" default="Producto" />

					<th><g:message code="inventario.cantidad.label" default="Cantidad" />

					<th>${message(code: 'default.button.delete.label', default: 'Eliminar', args: [""])}</th>
				</tr>
			</thead>
			<tbody>
			</tbody>
		</table>
	</div>
</div>

<g:hiddenField id="contador" name="contador" value="" />
<g:hiddenField name="idPuntoVenta" value="${punto?.id}" />


<g:javascript>
	$( document ).ready(function() {

	    var contador = 0;

		$("#agregarFila").click(function(){
		    var puntoVenta = $("#puntoVenta option:selected").text();
		    var puntoVentaID = $("#puntoVenta").val();
		    var producto = $("#producto option:selected").text();
		    var productoID = $("#producto").val();
		    var cantidad = $("#cantidad").val();

		    var pasa = true;

		    if(puntoVentaID == 0){
		        pasa = false;
		    }

		    if(productoID == 0){
		        pasa = false;
		    }

		    if(cantidad == ""){
		        pasa = false;
		    }

		    if(!pasa){
		        alert("Es necesario llenar todo los campos para agregar un nuevo inventario.");
		    }else{

		        if(!buscarTabla(puntoVenta, producto)){
		            contador ++;
					var filaNombre = "fila"+contador;
					var nuevaFila="<tr id='fila"+contador+"'>";

					nuevaFila+="<td id='puntoVentaTD'>"+puntoVenta +" <input type='hidden' id='valores"+contador+"puntoVenta' name= 'valores["+contador+"].puntoVenta' value='"+puntoVentaID+"' />";
					nuevaFila+="<td id='productoTD'>"+producto +" <input type='hidden' id='valores"+contador+"producto' name= 'valores["+contador+"].producto' value='"+productoID+"' />";;
					nuevaFila+="<td><input class='form-control' style='text-align: right; width:5em; margin: auto;' type='text' id='valores"+contador+"cantidad' name='valores["+contador+"].cantidad' value='"+cantidad+"' onkeypress='return soloNumerosPunto(event);'>";
					nuevaFila+="<td><a  onclick='eliminarFila("+filaNombre+")'> <image class='imageInButton' src='${resource(dir: "images", file: "eliminar.png")}'></image> </a>";
					nuevaFila+="</tr>";
					$("#cantidades").append(nuevaFila);
		        }else{
		            alert("Ya existe el punto de venta "+puntoVenta+" y el producto "+producto+" en la tabla.")
		        }

		    }

		    $("#contador").val(contador);
		});

	});


	function eliminarFila(valor) {

	    valor.remove();

	}

	function buscarTabla(puntoventa, producto){
	    console.log("pasa");
	    var pasa = false;
        $("#cantidades tbody tr").each(function () {

              var punt = $(this).find('td')[0].innerText;
              var prod = $(this).find('td')[1].innerText;

              console.log(punt);
              console.log(prod);

               if(punt == puntoventa && prod == producto){
                   console.log("hay uno igual");
                   pasa = true;
               }

        });
        return pasa;
	}



</g:javascript>






