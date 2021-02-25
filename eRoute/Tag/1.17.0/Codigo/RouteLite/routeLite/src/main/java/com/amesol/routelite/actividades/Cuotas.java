package com.amesol.routelite.actividades;

import java.util.ArrayList;
import java.util.Date;
import java.util.Iterator;

import com.amesol.routelite.datos.CUOCliente;
import com.amesol.routelite.datos.CUOEsquema;
import com.amesol.routelite.datos.CUOProducto;
import com.amesol.routelite.datos.CUOVendedor;
import com.amesol.routelite.datos.Cliente;
import com.amesol.routelite.datos.CucCcu;
import com.amesol.routelite.datos.CueCcu;
import com.amesol.routelite.datos.Cuota;
import com.amesol.routelite.datos.CuotaCumplida;
import com.amesol.routelite.datos.CupCcu;
import com.amesol.routelite.datos.DESCliente;
import com.amesol.routelite.datos.Esquema;
import com.amesol.routelite.datos.Producto;
import com.amesol.routelite.datos.TransProd;
import com.amesol.routelite.datos.TransProdDetalle;
import com.amesol.routelite.datos.Usuario;
import com.amesol.routelite.datos.Vendedor;
import com.amesol.routelite.datos.basedatos.BDTerm;
import com.amesol.routelite.datos.basedatos.BDVend;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.utilerias.Generales;

public class Cuotas {

	public static int CantidadInicial = 0;


	public static void VerificarCuotas(String vendedorID, int tipo, float cantidad, String ProductoClave) throws Exception{

		ReiniciarCuotas(vendedorID);

		ISetDatos cuotas = Consultas.ConsultasCuotas.obtenerCuotasAsigVendedor(vendedorID);

		String clienteClave = ((Cliente)Sesion.get(Campo.ClienteActual)).ClienteClave;
		while(cuotas.moveToNext()){
			Cuota cuota = new Cuota();
			cuota.CUOClave = cuotas.getString("CUOClave");
			BDVend.recuperar(cuota);

			if(cuota.FechaInicio.compareTo(Generales.getFechaActual()) <= 0 && cuota.FechaFin.compareTo(Generales.getFechaActual()) >= 0){
				//fecha inicio menor o igual a fecha actual y fecha fin mayor o igual a fecha actual
				ISetDatos cuotasCumplidas = Consultas.ConsultasCuotas.obtenerCuotaCumplida(cuota.CUOClave, vendedorID, tipo);
				while(cuotasCumplidas.moveToNext()){
					if(cuotasCumplidas.getInt("Tipo") == tipo){
						CuotaCumplida cuoCumplida = (CuotaCumplida) BDVend.instanciar(CuotaCumplida.class, cuotasCumplidas);
						cuoCumplida.Cantidad += cantidad;
						cuoCumplida.MFechaHora = Generales.getFechaHoraActual();
						cuoCumplida.MUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;
						cuoCumplida.Enviado = false;
						BDVend.guardarInsertar(cuoCumplida);
					}
				}
				cuotasCumplidas.close();

				//obtener los esquemas relacionados al cliente
				String esquemasCliente = "";
				//String clienteClave = ((Cliente)Sesion.get(Campo.ClienteActual)).ClienteClave.toString();
				ISetDatos esquemasCli = Consultas.ConsultasClienteEsquema.obtenerIdEsquemaCte(clienteClave);
				while(esquemasCli.moveToNext()){
					esquemasCliente += "'" + esquemasCli.getString("EsquemaId") + "',";
					Esquemas.ObtenerEsquemasPadre(esquemasCliente, esquemasCli.getString("EsquemaId"));
				}
				if(esquemasCliente.length() > 0){
					esquemasCliente = esquemasCliente.substring(0, esquemasCliente.length() - 1);
				}
				esquemasCli.close();

				if(ProductoClave != null || ProductoClave != ""){
					//obtener los esquemas relacionados al producto
					String esquemasProducto = "";
					ISetDatos esquemasProd = Consultas.ConsultasProductoEsquema.obtenerIdEsquemaProducto(ProductoClave);
					while(esquemasProd.moveToNext()){
						esquemasProducto += "'" + esquemasProd.getString("EsquemaId") + "',";
						Esquemas.ObtenerEsquemasPadre(esquemasProducto, esquemasProd.getString("EsquemaId"));
					}
					if(esquemasProducto.length() > 0){
						esquemasProducto = esquemasProducto.substring(0, esquemasProducto.length() - 1);
					}
					esquemasProd.close();

					//esquemas de producto
					ISetDatos esquemas = Consultas.ConsultasCuotas.obtenerCUOEsquemasPorEsquemas(cuota.CUOClave, esquemasProducto, tipo);
					while(esquemas.moveToNext()){
						CueCcu cue = new CueCcu();
						cue.CUOClave = cuota.CUOClave;
						cue.EsquemaId = esquemas.getString("EsquemaId");
						cue.VendedorId = vendedorID;
						BDVend.recuperar(cue);
						cue.Cantidad += cantidad;
						cue.MFechaHora = Generales.getFechaHoraActual();
						cue.MUsuarioID = ((Usuario)Sesion.get(Campo.UsuarioActual)).USUId;
						cue.Enviado = false;
						BDVend.guardarInsertar(cue);
					}
					esquemas.close();

					//producto
					ISetDatos productos = Consultas.ConsultasCuotas.obtenerCUOProductoPorProductoClaveTipo(cuota.CUOClave, ProductoClave, tipo);
					while(productos.moveToNext()){
						CupCcu cup = new CupCcu();
						cup.CUOClave = cuota.CUOClave;
						cup.VendedorId = vendedorID;
						cup.ProductoClave = ProductoClave;
						BDVend.recuperar(cup);
						cup.Cantidad += cantidad;
						cup.MFechaHora = Generales.getFechaHoraActual();
						cup.MUsuarioID = ((Usuario)Sesion.get(Campo.UsuarioActual)).USUId;
						cup.Enviado = false;
						BDVend.guardarInsertar(cup);
					}
					productos.close();
				}

				//esquemas de cliente
				ISetDatos esquemas = Consultas.ConsultasCuotas.obtenerCUOEsquemasPorEsquemas(cuota.CUOClave, esquemasCliente, tipo);
				while(esquemas.moveToNext()){
					CueCcu cue = new CueCcu();
					cue.CUOClave = cuota.CUOClave;
					cue.EsquemaId = esquemas.getString("EsquemaId");
					cue.VendedorId = vendedorID;
					BDVend.recuperar(cue);
					cue.Cantidad += cantidad;
					cue.MFechaHora = Generales.getFechaHoraActual();
					cue.MUsuarioID = ((Usuario)Sesion.get(Campo.UsuarioActual)).USUId;
					cue.Enviado = false;
					BDVend.guardarInsertar(cue);
				}
				esquemas.close();

				//cliente
				ISetDatos clientes = Consultas.ConsultasCuotas.obtenerCUOClientePorClienteClaveTipo(cuota.CUOClave, clienteClave, tipo);
				while(clientes.moveToNext()){
					CucCcu cup = new CucCcu();
					cup.CUOClave = cuota.CUOClave;
					cup.VendedorId = vendedorID;
					cup.ClienteClave = clienteClave;
					BDVend.recuperar(cup);
					cup.Cantidad += cantidad;
					cup.MFechaHora = Generales.getFechaHoraActual();
					cup.MUsuarioID = ((Usuario)Sesion.get(Campo.UsuarioActual)).USUId;
					cup.Enviado = false;
					BDVend.guardarInsertar(cup);
				}
				clientes.close();
			}
			BDVend.guardarInsertar(cuota);
		}
		cuotas.close();
	}

	public static void ReiniciarCuotas(String vendedorID) throws Exception{


		ISetDatos cuotas = Consultas.ConsultasCuotas.obtenerCuotasAsigVendedor(vendedorID);

		String clienteClave = ((Cliente)Sesion.get(Campo.ClienteActual)).ClienteClave;
		while(cuotas.moveToNext()){
			Cuota cuota = new Cuota();
			cuota.CUOClave = cuotas.getString("CUOClave");
			BDVend.recuperar(cuota);

			ISetDatos UnidadReinicio = Consultas.ConsultasCuotas.obtenerUnidadReinicio(cuota.CUOClave);
			String FechaReinicio = "";
			while(UnidadReinicio.moveToNext()){
				FechaReinicio = UnidadReinicio.getString("FechaCaptura");
			}
			UnidadReinicio.close();

			String FechaHoy = Generales.getPrimerHora(Generales.getFechaActual());
			String DiaMes = (String) android.text.format.DateFormat.format("dd", Generales.getFechaActual());
			if(cuota.ReinicioAplicado == 1 && ((cuota.TipoReinicio == 1 && cuota.UnidadReinicio == 1) || (cuota.TipoReinicio == 2 && FechaReinicio.compareTo(FechaHoy) == 0) || (cuota.TipoReinicio == 3 && cuota.UnidadReinicio == Integer.parseInt(DiaMes)))){
				if(cuota.FechaInicio.compareTo(Generales.getFechaActual()) <= 0 && cuota.FechaFin.compareTo(Generales.getFechaActual()) >= 0){
					ISetDatos cuotasCumplidas = Consultas.ConsultasCuotas.obtenerCuotaCumplida(cuota.CUOClave, vendedorID);
					while(cuotasCumplidas.moveToNext()){
						if(1 == 1){
							CuotaCumplida cuoCumplida = (CuotaCumplida) BDVend.instanciar(CuotaCumplida.class, cuotasCumplidas);
							cuoCumplida.Cantidad = CantidadInicial + 0;
							cuoCumplida.MFechaHora = Generales.getFechaHoraActual();
							cuoCumplida.MUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;
							cuoCumplida.Enviado = false;
							BDVend.guardarInsertar(cuoCumplida);
						}
					}
					cuotasCumplidas.close();

					//esquemas de producto
					ISetDatos esquemas = Consultas.ConsultasCuotas.obtenerCUOEsquemasPorEsquemas(cuota.CUOClave);
					while(esquemas.moveToNext()){
						CueCcu cue = new CueCcu();
						cue.CUOClave = cuota.CUOClave;
						cue.EsquemaId = esquemas.getString("EsquemaId");
						cue.VendedorId = vendedorID;
						BDVend.recuperar(cue);
						cue.Cantidad = CantidadInicial + 0;
						cue.MFechaHora = Generales.getFechaHoraActual();
						cue.MUsuarioID = ((Usuario)Sesion.get(Campo.UsuarioActual)).USUId;
						cue.Enviado = false;
						BDVend.guardarInsertar(cue);
					}
					esquemas.close();

					//producto
					ISetDatos productos = Consultas.ConsultasCuotas.obtenerCUOProductoPorProductoClaveTipo(cuota.CUOClave);
					while(productos.moveToNext()){
						CupCcu cup = new CupCcu();
						cup.CUOClave = cuota.CUOClave;
						cup.VendedorId = vendedorID;
						cup.ProductoClave = productos.getString("ProductoClave");
						BDVend.recuperar(cup);
						cup.Cantidad = CantidadInicial + 0;
						cup.MFechaHora = Generales.getFechaHoraActual();
						cup.MUsuarioID = ((Usuario)Sesion.get(Campo.UsuarioActual)).USUId;
						cup.Enviado = false;
						BDVend.guardarInsertar(cup);
					}
					productos.close();

					//esquemas de cliente
					esquemas = Consultas.ConsultasCuotas.obtenerCUOEsquemasPorEsquemas(cuota.CUOClave);
					while(esquemas.moveToNext()){
						CueCcu cue = new CueCcu();
						cue.CUOClave = cuota.CUOClave;
						cue.EsquemaId = esquemas.getString("EsquemaId");
						cue.VendedorId = vendedorID;
						BDVend.recuperar(cue);
						cue.Cantidad = CantidadInicial + 0;
						cue.MFechaHora = Generales.getFechaHoraActual();
						cue.MUsuarioID = ((Usuario)Sesion.get(Campo.UsuarioActual)).USUId;
						cue.Enviado = false;
						BDVend.guardarInsertar(cue);
					}
					esquemas.close();

					//cliente
					ISetDatos clientes = Consultas.ConsultasCuotas.obtenerCUOClientePorClienteClaveTipo(cuota.CUOClave, clienteClave);
					while(clientes.moveToNext()){
						CucCcu cup = new CucCcu();
						cup.CUOClave = cuota.CUOClave;
						cup.VendedorId = vendedorID;
						cup.ClienteClave = clienteClave;
						BDVend.recuperar(cup);
						cup.Cantidad = CantidadInicial + 0;
						cup.MFechaHora = Generales.getFechaHoraActual();
						cup.MUsuarioID = ((Usuario)Sesion.get(Campo.UsuarioActual)).USUId;
						cup.Enviado = false;
						BDVend.guardarInsertar(cup);
					}
					clientes.close();
				}
				cuota.ReinicioAplicado = 0;
				BDVend.guardarInsertar(cuota);
			}
		}
		cuotas.close();
	}
	
	public static void CalcularCuotasXEfectivo(TransProd oTransprod, boolean bRestar) throws Exception{
		Iterator<TransProdDetalle> it = oTransprod.TransProdDetalle.iterator();
		while(it.hasNext()){
			TransProdDetalle oTPD = it.next();
			int iFactor = 1;
			float nSTCD = 0;
			float nCantidad = 0;
			
			if(oTPD.getSubTotal() > 0){
				//descuentos del cliente
				nSTCD = oTPD.getSubTotal();
				ISetDatos descCli = Consultas.ConsultasDescuentos.obtenerDescuentosClientePorTPD(oTransprod.TransProdID, oTPD.TransProdDetalleID);
				while(descCli.moveToNext()){
					nSTCD -= descCli.getFloat("DescuentoCliente");
				}
				descCli.close();
				
				//descuentos del vendedor
				nSTCD -= nSTCD * (oTransprod.DescVendPor / 100);
				//subtotal con descuentos
				
				if(bRestar)
					nCantidad = -1 * nSTCD;
				else
					nCantidad = nSTCD;
				
				String vendedorID = ((Vendedor)Sesion.get(Campo.VendedorActual)).VendedorId;
				VerificarCuotas(vendedorID, 2, nCantidad, oTPD.ProductoClave);
			}
		}
	}

	public static Cuota[] ObtenerCuotasAsigVendedor(String vendedorID) throws Exception{
		ArrayList<Cuota> resultado = new ArrayList<Cuota>(); 
		ISetDatos cuotas = Consultas.ConsultasCuotas.obtenerCuotasAsigVendedor(vendedorID);
		while(cuotas.moveToNext()){
			Cuota cuota = new Cuota();
			cuota.CUOClave = cuotas.getString("CUOClave");
			BDVend.recuperar(cuota);
			resultado.add(cuota);
		}
		cuotas.close();
		return resultado.toArray(new Cuota[resultado.size()]);
	}
	
	public static void obtenerCuotasCliente(Cuota cuota) throws Exception{
		ISetDatos cuocli = Consultas.ConsultasCuotas.obtenerCUOCliente(cuota.CUOClave);
		while(cuocli.moveToNext()){
			CUOCliente cuoCliente = new CUOCliente();
			cuoCliente.CUOClave = cuocli.getString("CUOClave");
			cuoCliente.ClienteClave = cuocli.getString("ClienteClave");
			cuoCliente.Minimo = cuocli.getFloat("Minimo");
			cuoCliente.Tipo = cuocli.getShort("Tipo");
			cuoCliente.Estado = cuocli.getShort("Estado");
			cuota.CUOCliente.add(cuoCliente);
			
			Cliente cliente = new Cliente();
			cliente.ClienteClave = cuoCliente.ClienteClave;
			BDVend.recuperar(cliente);
			cuoCliente.DescripcionCuota = cuota.Descripcion;
			cuoCliente.NombreCliente = cliente.RazonSocial;
			cuoCliente.ClaveCliente = cliente.Clave;
		}
		cuocli.close();
	}
	
	public static void obtenerCuotasCliente(Cuota cuota, String clienteClave, int tipo) throws Exception{
		ISetDatos cuocli = Consultas.ConsultasCuotas.obtenerCUOCliente(cuota.CUOClave, clienteClave, tipo );
		while(cuocli.moveToNext()){
			CUOCliente cuoCliente = new CUOCliente();
			cuoCliente.CUOClave = cuocli.getString("CUOClave");
			cuoCliente.ClienteClave = cuocli.getString("ClienteClave");
			cuoCliente.Minimo = cuocli.getFloat("Minimo");
			cuoCliente.Tipo = cuocli.getShort("Tipo");
			cuoCliente.Estado = cuocli.getShort("Estado");
			cuota.CUOCliente.add(cuoCliente);
		}
		cuocli.close();
	}
	
	public static ISetDatos obtenerCuotasCliente() throws Exception{
		return Consultas.ConsultasCuotas.obtenerCuotasCliente();
	}
	
	public static void obtenerCuotasEsquema(Cuota cuota) throws Exception{
		ISetDatos cuoesq = Consultas.ConsultasCuotas.obtenerCUOEsquema(cuota.CUOClave);
		while(cuoesq.moveToNext()){
			CUOEsquema cuoEsquema = new CUOEsquema();
			cuoEsquema.CUOClave = cuoesq.getString("CUOClave");
			cuoEsquema.EsquemaId = cuoesq.getString("EsquemaId");
			cuoEsquema.Minimo = cuoesq.getFloat("Minimo");
			cuoEsquema.Tipo = cuoesq.getShort("Tipo");
			cuoEsquema.Estado = cuoesq.getShort("Estado");
			cuota.CUOEsquema.add(cuoEsquema);
			
			cuoEsquema.DescripcionCuota = cuota.Descripcion;
		}
		cuoesq.close();
	}
	
	public static ISetDatos obtenerCuotasEsquemaProducto() throws Exception{
		return Consultas.ConsultasCuotas.obtenerCuotasEsquemaProducto();
	}
	
	public static ISetDatos obtenerCuotasEsquemaCliente() throws Exception{
		return Consultas.ConsultasCuotas.obtenerCuotasEsquemaCliente();
	}
	
	public static void obtenerCuotasProducto(Cuota cuota) throws Exception{
		ISetDatos cuopro = Consultas.ConsultasCuotas.obtenerCUOProducto(cuota.CUOClave);
		while(cuopro.moveToNext()){
			CUOProducto cuoProducto = new CUOProducto();
			cuoProducto.CUOClave = cuopro.getString("CUOClave");
			cuoProducto.ProductoClave = cuopro.getString("ProductoClave");
			cuoProducto.Minimo = cuopro.getFloat("Minimo");
			cuoProducto.Tipo = cuopro.getShort("Tipo");
			cuoProducto.Estado = cuopro.getShort("Estado");
			
			Producto producto = new Producto();
			producto.ProductoClave = cuoProducto.ProductoClave;
			BDVend.recuperar(producto);
			cuoProducto.DescripcionCuota = cuota.Descripcion;
			cuoProducto.NombreProducto = producto.Nombre;
			cuota.CUOProducto.add(cuoProducto);
		}
		cuopro.close();
	}
	
	public static ISetDatos obtenerCuotasProducto() throws Exception{
		return Consultas.ConsultasCuotas.obtenerCuotasProducto();
	}
	
	public static void obtenerCuotasVendedor(Cuota cuota) throws Exception{
		ISetDatos cuoven = Consultas.ConsultasCuotas.obtenerCUOVendedor(cuota.CUOClave);
		while(cuoven.moveToNext()){
			CUOVendedor cuoVendedor = new CUOVendedor();
			cuoVendedor.CUOClave = cuoven.getString("CUOClave");
			cuoVendedor.Minimo = cuoven.getFloat("Minimo");
			cuoVendedor.Tipo = cuoven.getShort("Tipo");
			cuoVendedor.Estado = cuoven.getShort("Estado");
			cuota.CUOVendedor.add(cuoVendedor);
			
			cuoVendedor.DescripcionCuota = cuota.Descripcion;
			Vendedor vend = (Vendedor)Sesion.get(Campo.VendedorActual);
			cuoVendedor.NombreVendedor = vend.Nombre;
			Usuario usuario = (Usuario) Sesion.get(Campo.UsuarioActual); 
			cuoVendedor.ClaveVendedor = usuario.Clave; 
		}
		cuoven.close();
	}
	
	public static ISetDatos obtenerCuotasVendedor() throws Exception{
		return Consultas.ConsultasCuotas.obtenerCuotasVendedor();
	}
	
}
