package com.amesol.routelite.actividades;

import java.util.ArrayList;
import java.util.Collections;
import java.util.Comparator;
import java.util.Enumeration;
import java.util.HashMap;
import java.util.Hashtable;
import java.util.ListIterator;

import android.content.DialogInterface;
import android.content.Intent;
import android.database.Cursor;

import com.amesol.routelite.controles.CapturaProducto.onAgregarProductoListener;
import com.amesol.routelite.datos.Cliente;
import com.amesol.routelite.datos.Descuento;
import com.amesol.routelite.datos.Impuesto;
import com.amesol.routelite.datos.Producto;
import com.amesol.routelite.datos.ProductoDetalle;
import com.amesol.routelite.datos.Promocion;
import com.amesol.routelite.datos.PromocionAplicacion;
import com.amesol.routelite.datos.PromocionProducto;
import com.amesol.routelite.datos.PromocionRegla;
import com.amesol.routelite.datos.TpdPun;
import com.amesol.routelite.datos.TransProd;
import com.amesol.routelite.datos.TransProdDetalle;
import com.amesol.routelite.datos.TrpPrp;
import com.amesol.routelite.datos.Usuario;
import com.amesol.routelite.datos.basedatos.BDVend;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.actividades.Enumeradores;
import com.amesol.routelite.presentadores.Enumeradores.Acciones;
import com.amesol.routelite.presentadores.Enumeradores.RespuestaMsg;
import com.amesol.routelite.presentadores.Enumeradores.Solicitudes;
import com.amesol.routelite.presentadores.interfaces.IAplicacionPromocion;
import com.amesol.routelite.utilerias.Generales;
import com.amesol.routelite.utilerias.KeyGen;
import com.amesol.routelite.vistas.CapturaPedido;
import com.amesol.routelite.vistas.Vista;
import com.amesol.routelite.vistas.generico.DialogoAlerta;

public class Promociones {
	private TransProd oTransProd;
	//private String sPrecioClave;
	private Cursor dsProductosTRP;	
	private ISetDatos dsPromocion;
	private Cursor dsPromocionProducto;
	private Hashtable<String, Promocion> oPromociones;
	private Cliente oCliente;
	private boolean AfectoImpuestos;
	private String sUsuarioId;
	public Hashtable<String, Promocion> PRMProductoApp;
	public Promocion promocionActual; 
	
	public Regla reglaActual;
	public ReglaAcumulado reglaAcumActual;
	
	private CapturaPedido mVista;
	
		
	public Promociones(TransProd oTransProd) throws Exception{
		this.oTransProd = oTransProd;

		this.AfectoImpuestos = false;
		this.PRMProductoApp = new Hashtable<String, Promocion>();
		Usuario oUsuario = (Usuario) Sesion.get(Campo.UsuarioActual);
		sUsuarioId = oUsuario.USUId;
		
		oCliente = (Cliente)Sesion.get(Campo.ClienteActual);
	}
	
	public Promociones(TransProd oTransProd, Vista vista) throws Exception{
		this.oTransProd = oTransProd;
				
		this.AfectoImpuestos = false;
		this.PRMProductoApp = new Hashtable<String, Promocion>();
		Usuario oUsuario = (Usuario) Sesion.get(Campo.UsuarioActual);
		sUsuarioId = oUsuario.USUId;
		
		oCliente = (Cliente)Sesion.get(Campo.ClienteActual);
		
		mVista = (CapturaPedido) vista;
	}
	
	

	
	//Regresa false si no se cambio nada, porque no habia promociones
	public boolean Preparar() throws Exception
	{
		boolean bHuboPromociones = false;
		boolean bHuboRegalados = false;
		//Recuperar productos que otorgaron una promocion
		ListIterator<TransProdDetalle> oDetalles = oTransProd.TransProdDetalle.listIterator();
		//ListaPrecio oPrecio = new ListaPrecio();
		//Impuestos oImpuesto = new Impuestos();
		Descuento oDescuento = new Descuento();
		Impuesto[] oImpuestos;
		//String sTransProdID = null;
		//String sTransProdIDFondoCristal = null;
		ArrayList<TransProdDetalle> tpdEliminados = new ArrayList<TransProdDetalle>();
		while (oDetalles.hasNext()){
			TransProdDetalle oTPD = oDetalles.next();
			if (oTPD.Promocion == 1 && oTPD.Total != 0){
				bHuboPromociones = true;
				float nPrecio = ListaPrecio.BuscarPrecio(oTPD.ProductoClave, (short) oTPD.TipoUnidad, oTransProd.PCEPrecioClave);
				if (nPrecio >= 0){				
					oTPD.Precio = nPrecio;
					if(oTPD.Cantidad == 0){
						Consultas.ConsultasTPDImpuesto.eliminarImpuestosPorDetalle(oTPD.TransProdID, oTPD.TransProdDetalleID);
						Consultas.ConsultasDescuentos.eliminarDescuentosPorDetalle(oTPD.TransProdID, oTPD.TransProdDetalleID);
						Consultas.ConsultasTPDDesVendedor.eliminarDescuentoPorDetalle(oTPD.TransProdID, oTPD.TransProdDetalleID);
						Consultas.ConsultasTrpPrp.eliminarPorDetalle(oTPD.TransProdID, oTPD.TransProdDetalleID);
						
						//if eliminarcero then
						//BDVend.eliminar(oTPD);
						//else
						oTPD.DescuentoClave = null;
						oTPD.Promocion = 0;
						oTPD.Cantidad = 0;
						oTPD.DescuentoPor = (float) 0;
						oTPD.DescuentoImp = (float) 0;
						oTPD.Impuesto = (float) 0;
						oTPD.Subtotal = 0;
						oTPD.Total = 0;
						oTPD.Enviado = false;
						oTPD.MFechaHora = Generales.getFechaActual();
						oTPD.MUsuarioID = ((Usuario)Sesion.get(Campo.UsuarioActual)).USUId;
						
					}else{
						oImpuestos = Impuestos.Buscar(oTPD.ProductoClave, oCliente.TipoImpuesto);
						oDescuento = Descuentos.BuscarDescuentosProductos(oTPD.ProductoClave);
						
						oTPD.DescuentoImp = Descuentos.CalcularDescuentosProducto(oDescuento, oTPD.Cantidad * oTPD.Precio, oTPD.Cantidad);
						oTPD.DescuentoPor = oTPD.DescuentoImp;
						oTPD.setSubTotal( ((oTPD.Cantidad * oTPD.Precio) - oTPD.DescuentoImp) < 0 ? 0 : (oTPD.Cantidad * oTPD.Precio) - oTPD.DescuentoImp);
						oTPD.Impuesto = Impuestos.Calcular(oImpuestos, oTPD.getSubTotal(), oTPD.Precio, oTPD.Cantidad);
						oTPD.Total = oTPD.getSubTotal() + oTPD.Impuesto;
						Impuestos.GuardarDetalle(oTPD, oImpuestos);
						BDVend.guardarInsertar(oTPD);
					}
				}
			}else if (oTPD.Promocion == 2){ 
				bHuboPromociones = true;
				bHuboRegalados = true;
				tpdEliminados.add(oTPD);
			}
		}
		
		if (bHuboRegalados){
			//eliminar los detalles del objeto
			ListIterator<TransProdDetalle> eliminar = tpdEliminados.listIterator();
			while(eliminar.hasNext()){
				TransProdDetalle oTPD = eliminar.next();
				oTransProd.TransProdDetalle.remove(oTPD);
			}
			
			//Dar salida del inventario de productos de regalo
			//TODO: Pendiente actualizar inventario
			
			//Borrar los registros creados con los productos regalados
			Consultas.ConsultasTPDImpuesto.eliminarImpuestosPromocion(oTransProd.TransProdID);
			Consultas.ConsultasTransProdDetalle.eliminarRegalados(oTransProd.TransProdID);
		}

		if (bHuboPromociones){
			//Quitar la marca de promoción a los demas productos
			Consultas.ConsultasTransProdDetalle.actualizarMarcaPromocion(oTransProd.TransProdID);
		}
		//Borrar productosNegados por promociones
		Consultas.ConsultasProductoNegado.eliminarProductosNegadosXPromocion(oTransProd.TransProdID);
		
		//Borrar el pedido relacionado de FondoCristal
		/*ISetDatos fondoCristal = Consultas.ConsultasTransProd.obtenerPorTipo(oTransProd.TransProdID, com.amesol.routelite.presentadores.Enumeradores.TiposTransProd.FONDO_CRISTAL);
		if(fondoCristal.moveToNext())
			sTransProdIDFondoCristal = fondoCristal.getString(0);
		if(oTransProd.Tipo != com.amesol.routelite.presentadores.Enumeradores.TiposTransProd.MOV_SIN_INV_EV){
			do{
				//TODO: Pendiente actualizar inventario
			}while(fondoCristal.moveToNext());
		}
		
		//Borrar los registros creados con los productos de Fondo Cristal
		if(sTransProdIDFondoCristal != null && sTransProdIDFondoCristal != ""){
			Consultas.ConsultasTransProdDetalle.eliminarDetalle(sTransProdIDFondoCristal);
			Consultas.ConsultasTransProd.eliminarPorFacturaId(oTransProd.TransProdID);
		}*/
		
		//Borrar los registros creados con promociones de tipo aplicacion Puntos
		if(Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == com.amesol.routelite.presentadores.Enumeradores.TiposModulos.VENTA || Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == com.amesol.routelite.presentadores.Enumeradores.TiposModulos.REPARTO){
			float nPuntos = Consultas.ConsultasTpdPun.obtenerPuntos(oTransProd.TransProdID);
			if (nPuntos > 0){
				bHuboPromociones = true;
				nPuntos = Math.round(nPuntos);
				Consultas.ConsultasTpdPun.actualizarSaldo(nPuntos);
			}
		}
		if (bHuboPromociones){
			Consultas.ConsultasTpdPun.eliminar(oTransProd.TransProdID);
			BDVend.guardarInsertar(oTransProd);	
		}
				
		return bHuboPromociones;
	}

	public void Aplicar() throws Exception
	{		
		
		
			//Eliminar los registros de TrpPrp asociados al pedido		 
			ListIterator<TransProdDetalle> oDetalles = oTransProd.TransProdDetalle.listIterator();
			while (oDetalles.hasNext()){
				TransProdDetalle oTPD = oDetalles.next();
				ListIterator<TrpPrp> oTrpPrp = oTPD.TrpPrp.listIterator();
				while (oTrpPrp.hasNext()){
					TrpPrp oTPP = oTrpPrp.next();
					BDVend.eliminar(oTPP);
				}			
				oTPD.TrpPrp.clear();			
			}
			
			//Seleccionar los productos que no se otorgaron por una promoción		
			dsProductosTRP = (Cursor)Consultas.ConsultasTransProd.obtenerProductosSinPromocion(oTransProd.TransProdID).getOriginal();
			if (dsProductosTRP.getCount() == 0) {
				terminarAplicacionListener.onTerminarAplicacion();
				return ;
			}
				
			//Obtener los esquemas del cliente
			String sClienteClave = ((Cliente) Sesion.get(Campo.ClienteActual)).ClienteClave.toString();
			String sEsquemasCte = Esquemas.ObtenerEsquemas(sClienteClave, com.amesol.routelite.actividades.Enumeradores.Esquema.TipoEsquema.Cliente);
			
			//Obtener las promociones que aplican para la actividad y esquema del cliente
			dsPromocion = Consultas.ConsultasPromocion.obtenerAplicables(oTransProd.PCEModuloMovDetClave, sEsquemasCte);
			if (dsPromocion.getCount() == 0){
				terminarAplicacionListener.onTerminarAplicacion();
				return ;
			}
			String sPromociones = "";
			while(dsPromocion.moveToNext()){
				sPromociones += "'" + dsPromocion.getString("PromocionClave") + "',";
			}		
			sPromociones = sPromociones.substring(0, sPromociones.length()-1);
			
			//Obtener los productos para los que aplican las promociones y que se encuentran en la transaccion
			dsPromocionProducto = (Cursor)Consultas.ConsultasPromocion.obtenerProductosTrans(sPromociones, oTransProd.TransProdID).getOriginal();
			//DatabaseUtils.dumpCursor((Cursor) dsPromocionProducto.getOriginal());
			if (dsPromocionProducto.getCount() == 0){
				terminarAplicacionListener.onTerminarAplicacion();
				return ;
			}
				
			//Recuperar las promociones aplicables		
			oPromociones = new Hashtable<String, Promocion>(); 
			dsPromocion.moveToFirst();
			//while (dsPromocion.moveToNext()){
			do{
				Promocion oPromocion = new Promocion();
				oPromocion.PromocionClave = dsPromocion.getString("PromocionClave");			
				BDVend.recuperar(oPromocion);
				BDVend.recuperar(oPromocion, PromocionRegla.class);
				oPromociones.put(oPromocion.PromocionClave, oPromocion);
			}while(dsPromocion.moveToNext());
			
			try{
				Enumeration<String> oProms = oPromociones.keys();
				//boolean bPrimeraPromocion = true;
				
				//Acumular por promocion las cantidades, importes y claves de los productos que aplican para esta (Producto Acumulado)
				while (oProms.hasMoreElements()){
					Promocion oProm = (Promocion) oPromociones.get(oProms.nextElement());
					dsPromocionProducto.moveToFirst();
					do{
						if (dsPromocionProducto.getString(dsPromocionProducto.getColumnIndex("PromocionClave")).equals(oProm.PromocionClave)){
							ISetDatos dsCantProd = Consultas.ConsultasTransProd.obtenerCantidadesPorProducto(oTransProd.TransProdID, dsPromocionProducto.getString(dsPromocionProducto.getColumnIndex( "ProductoClave")));
							dsCantProd.moveToFirst();
							oProm.CantidadAcumulado += dsCantProd.getFloat("Cantidad");
							oProm.ImporteAcumulado += dsCantProd.getFloat("Subtotal");
							oProm.ListadoProductosAcumulados +=  dsPromocionProducto.getString(dsPromocionProducto.getColumnIndex( "ProductoClave")) + ",";
							dsCantProd.close();
						}
					} while (dsPromocionProducto.moveToNext());
				}
							
				// Para cada producto en la transaccion
				dsProductosTRP.moveToFirst();
				dsPromocionProducto.moveToFirst();
			}catch(Exception ex){
				mVista.mostrarError(ex.getMessage());
			}
			
			
			ObtenerPromocionesAAplicar();
			
			
			/*if (AfectoImpuestos){
				Impuestos.Recalcular(oTransProd);
			}
			
			PRMProductoApp.clear();
			oPromociones.clear();
			dsProductosTRP.close();
			dsPromocion.close();
			dsPromocionProducto.close();
			
			*/
			return;
		
		
	}
	
	private void ObtenerPromocionesAAplicar() throws Exception{					
						
									try{

										if (dsProductosTRP == null) return;

										if (dsPromocionProducto.getString(dsPromocionProducto.getColumnIndex("ProductoClave")).equals(dsProductosTRP.getString(dsProductosTRP.getColumnIndex("ProductoClave")))){	
													
											promocionActual = (Promocion) oPromociones.get(dsPromocionProducto.getString(dsPromocionProducto.getColumnIndex("PromocionClave")));
		
											if (promocionActual.Tipo == Enumeradores.Promocion.Tipo.ProductoAcumulado && 
													promocionActual.TipoAplicacion == Enumeradores.Promocion.TipoAplicacion.Producto && 
													PRMProductoApp.containsKey(promocionActual.PromocionClave)){
												SiguientePromocion();
												return;
											}
														
													
											ISetDatos dsCantProd = Consultas.ConsultasTransProd.obtenerCantidadesPorProducto(oTransProd.TransProdID, dsProductosTRP.getString(dsProductosTRP.getColumnIndex("ProductoClave")));
											dsCantProd.moveToFirst();
											ProductoPRM oProducto = new ProductoPRM(dsProductosTRP.getString(dsProductosTRP.getColumnIndex("ProductoClave")), dsCantProd.getFloat("Cantidad"), dsCantProd.getFloat("Subtotal"));
											dsCantProd.close();
											if (promocionActual.Tipo == Enumeradores.Promocion.Tipo.ProductoAcumulado){
												reglaActual = null;
												reglaAcumActual  = new ReglaAcumulado(oTransProd, oProducto, promocionActual);
												reglaAcumActual.ObtenerAplicarRango();

											}
											else{
												reglaAcumActual = null;
												reglaActual = new Regla(oTransProd, oProducto, promocionActual);
												reglaActual.ObtenerAplicarRango();						
											}
										}else{
											SiguientePromocion();
											return;
										}
									}catch(Exception ex){
										mVista.mostrarError(ex.getMessage());
									}
		
	}
	
	public void SiguientePromocion() throws Exception{
		if (!dsPromocionProducto.moveToNext()){
			if (!dsProductosTRP.moveToNext()){
				TerminarAplicacion();
				return; 
			}else{
				promocionActual = null;
				dsPromocionProducto.moveToFirst();
			}
		}
		if (promocionActual != null && promocionActual.Tipo  != Enumeradores.Promocion.Tipo.ProductoAcumulado){
			if (!promocionActual.PermiteCascada){
				if (!dsProductosTRP.moveToNext()){
					TerminarAplicacion();
					return;
				}else{
					promocionActual =null;
					dsPromocionProducto.moveToFirst();
				}
			}
		}
		ObtenerPromocionesAAplicar();
	}
	
	public void TerminoPromocionRegalo() throws Exception{
		if (reglaActual != null){
			ActualizaProducto(reglaActual.oProducto.ProductoClave, reglaActual.oPromocion.PromocionClave );

		}else if (reglaAcumActual != null){
			ActualizaProducto(reglaAcumActual.oProducto.ProductoClave, reglaAcumActual.oPromocion.PromocionClave);
		}
		SiguientePromocion();
	}
	
	private void TerminarAplicacion() throws Exception{
		if (AfectoImpuestos){
			Impuestos.RecalcularPromocionales(oTransProd);
		}
		
		PRMProductoApp.clear();
		oPromociones.clear();
		dsProductosTRP.close();
		dsPromocion.close();
		dsPromocionProducto.close();
		
		terminarAplicacionListener.onTerminarAplicacion();
	}
			
	private void ActualizarDescBonif(String PromocionClave, String ProductoClave, float Porcentaje) throws Exception{		
		ListIterator<TransProdDetalle> oDetalles = oTransProd.TransProdDetalle.listIterator();
		while (oDetalles.hasNext()){
			TransProdDetalle oTPD = oDetalles.next();
			if (ProductoClave.equals(oTPD.ProductoClave) && oTPD.Promocion != 2 && oTPD.getSubTotal() > 0){
				float nSubtotal = oTPD.getSubTotal();
				oTransProd.Promocion = true;
				oTPD.Promocion = 1;
				oTPD.DescuentoImp = Generales.getRound( oTPD.DescuentoImp +  (oTPD.Subtotal * Porcentaje), 2) ;
				oTPD.Subtotal  =  Generales.getRound( oTPD.Subtotal - (oTPD.Subtotal * Porcentaje), 2);
				oTPD.MFechaHora = Generales.getFechaHoraActual();
				oTPD.MUsuarioID = sUsuarioId;
				oTPD.Enviado = false;
				//BDVend.guardarInsertar(oTPD);
				
				TrpPrp oTPP = new TrpPrp();
				oTPP.TransProdID = oTPD.TransProdID;
				oTPP.TransProdDetalleID = oTPD.TransProdDetalleID;
				oTPP.PromocionClave = PromocionClave;
				oTPP.PromocionImp = Generales.getRound(nSubtotal * Porcentaje, 2) ;
				oTPP.MFechaHora = Generales.getFechaHoraActual();
				oTPP.MUsuarioID = sUsuarioId;
				oTPP.Enviado = false;
				oTPD.TrpPrp.add(oTPP);
				
				BDVend.guardarInsertar(oTPD);
			}
		}
	}
	
	private void ActualizaPuntos(String PromocionClave, int TipoRango, String ProductoClave, float Porcentaje) throws Exception{
		ListIterator<TransProdDetalle> oDetalles = oTransProd.TransProdDetalle.listIterator();
		while (oDetalles.hasNext()){
			TransProdDetalle oTPD = oDetalles.next();
			if (ProductoClave.equals(oTPD.ProductoClave) && oTPD.Promocion != 2 && oTPD.getSubTotal() > 0){
				
				oTPD.Promocion = 1;		
				oTransProd.Promocion = true;
				oTPD.MFechaHora = Generales.getFechaHoraActual();
				oTPD.MUsuarioID = sUsuarioId;
				oTPD.Enviado = false;
				
				ProductoDetalle oPRD = new ProductoDetalle();
				oPRD.ProductoClave = oTPD.ProductoClave;
				oPRD.PRUTipoUnidad = (short) oTPD.TipoUnidad;
				oPRD.ProductoDetClave = oTPD.ProductoClave;
				BDVend.recuperar(oPRD);
				
				
				TpdPun oTPP = new TpdPun();
				oTPP.TransProdID = oTPD.TransProdID;
				oTPP.TransProdDetalleID = oTPD.TransProdDetalleID;
				oTPP.PromocionClave = PromocionClave;
				if (TipoRango == Enumeradores.Promocion.TipoRango.Cantidad)
					oTPP.Puntos = (oTPD.Cantidad * oPRD.Factor) * Porcentaje;
				else if (TipoRango == Enumeradores.Promocion.TipoRango.Importe)
					oTPP.Puntos = (oTPD.getSubTotal() * Porcentaje);					
				oTPP.MFechaHora = Generales.getFechaHoraActual();
				oTPP.MUsuarioID = sUsuarioId;
				oTPP.Enviado = false;
				oTPD.TpdPun.add(oTPP);
				
				BDVend.guardarInsertar(oTPD);
			}
		}
	}
	
	private void ActualizaProducto(String productoClave, String promocionClave) throws Exception{
		ListIterator<TransProdDetalle> oDetalles = oTransProd.TransProdDetalle.listIterator();	
		
		while (oDetalles.hasNext()){
			TransProdDetalle oTPD = oDetalles.next();
			if (productoClave.equals(oTPD.ProductoClave) && oTPD.Promocion != 2 && oTPD.getSubTotal() > 0){
				oTPD.Promocion = 1;
				oTransProd.Promocion = true;
				oTPD.MFechaHora = Generales.getFechaHoraActual();
				oTPD.MUsuarioID = sUsuarioId;
				oTPD.Enviado = false;
				
				TrpPrp oTPP = new TrpPrp();
				oTPP.TransProdID = oTPD.TransProdID;
				oTPP.TransProdDetalleID = oTPD.TransProdDetalleID;
				oTPP.PromocionClave = promocionClave;
				//oTPP.PromocionImp = Generales.getRound(nSubtotal * Porcentaje, 2) ;
				oTPP.MFechaHora = Generales.getFechaHoraActual();
				oTPP.MUsuarioID = sUsuarioId;
				oTPP.Enviado = false;
				oTPD.TrpPrp.add(oTPP);
				
				BDVend.guardarInsertar(oTPD);
			}
		}				
	}
	
	public Regla getReglaActual(){
		return reglaActual ;
	}
	
	public ReglaAcumulado getReglaAcumActual(){
		return reglaAcumActual ;
	}

	
	public class Regla{
		TransProd oTransProd;
		ProductoPRM oProducto;
		Promocion oPromocion;
		PromocionRegla oReglaApp;
		int nCantidadGrupo;
		
		public Regla(TransProd oTransProd, ProductoPRM oProducto, Promocion oPromocion){
			this.oTransProd = oTransProd;
			this.oProducto = oProducto;
			this.oPromocion = oPromocion;
		}
		
		public void ObtenerAplicarRango() throws Exception{
			//Si el subtotal del producto es 0 y el tipo de aplicacion es descuento, bonificacion o puntos no aplicar la promocion
			if (oProducto.Subtotal == 0 && 
			(oPromocion.TipoAplicacion == Enumeradores.Promocion.TipoAplicacion.Descuento || 
			 oPromocion.TipoAplicacion == Enumeradores.Promocion.TipoAplicacion.Bonificacion ||
			 oPromocion.TipoAplicacion == Enumeradores.Promocion.TipoAplicacion.Puntos)){
				SiguientePromocion();
				return;
			}
		
			if (ObtenerRango()){
				
				/*if(!oPromoAplicadas.containsKey(oPromocion.PromocionClave)){
					ArrayList<Promocion> promo = new ArrayList<Promocion>();
					promo.add(oPromocion);
					oPromoAplicadas.put(oPromocion.PromocionClave, promo);
				}else{
					ArrayList<Promocion> promo = oPromoAplicadas.get(oPromocion.PromocionClave);
					promo.add(oPromocion);
				}*/
				
				//TODO: Validacion de promocion obligatoria, preguntar al vendedor
				if (!oPromocion.Obligatoria && promocionActual.TipoAplicacion != Enumeradores.Promocion.TipoAplicacion.Producto){
						mVista.mostrarObligatorio(Mensajes.get("P0104", oPromocion.PromocionClave + " - " + oPromocion.Nombre + "\n", oProducto.ProductoClave + "\n", (oPromocion.TipoRango == Enumeradores.Promocion.TipoRango.Cantidad ? Mensajes.get("XCantidad") : Mensajes.get("XSubTotal")) ,(oPromocion.TipoRango == Enumeradores.Promocion.TipoRango.Cantidad ? String.valueOf(oProducto.Cantidad) : String.valueOf(oProducto.Subtotal)) ), 99);
						return;
				}else{
					Aplicar();
					if (promocionActual.TipoAplicacion != Enumeradores.Promocion.TipoAplicacion.Producto){
						SiguientePromocion();
					}
					return;
				}
			}
			
			SiguientePromocion();
		}
		
		public void Aplicar() throws Exception{
			switch (oPromocion.TipoAplicacion){
			case Enumeradores.Promocion.TipoAplicacion.Descuento:
				OtorgarDescuento();
				break;
			case Enumeradores.Promocion.TipoAplicacion.Bonificacion:
				OtorgarBonificacion();
				break;
			case Enumeradores.Promocion.TipoAplicacion.Precio:
				OtorgarPrecio();
				break;
			case Enumeradores.Promocion.TipoAplicacion.Producto:
				OtorgarProducto();
				break;
			case Enumeradores.Promocion.TipoAplicacion.Puntos:
				OtorgarPuntos();
				break;
			}
			
		}
		private boolean ObtenerRango(){

			//Recupera los rangos que aplican para la promocion (ordenados por el Minimo)
			ReglaComparator oComp = new ReglaComparator();
			Collections.sort(oPromocion.PromocionRegla, oComp);
			
			boolean bTerminar = false;
			float nCantidad = 0;
			nCantidadGrupo = 0;
			
			//Determinar el rango en que entra la cantidad o subtotal del producto, y el numero de veces que se aplicara la promocion
			ListIterator<PromocionRegla> oReglas = oPromocion.PromocionRegla.listIterator();
			while (oReglas.hasNext() && !bTerminar){
				PromocionRegla oRegla = oReglas.next();
								
				switch(oPromocion.TipoRango){
					case Enumeradores.Promocion.TipoRango.Cantidad:
						nCantidad = oProducto.Cantidad;
						break;
					case Enumeradores.Promocion.TipoRango.Importe:
						nCantidad = oProducto.Subtotal;
						break;
				}
				
				switch (oPromocion.TipoRegla){
					case Enumeradores.Promocion.TipoRegla.Rango:
						if (nCantidad >= oRegla.Minimo && nCantidad <= oRegla.Maximo)									
							nCantidadGrupo = 1;
						break;
					case Enumeradores.Promocion.TipoRegla.Grupo:
						nCantidadGrupo = (int) (nCantidad/oRegla.Minimo);
						break;
				}	
				
				bTerminar = (nCantidadGrupo != 0);
				if (bTerminar)
					oReglaApp = oRegla;
			}
			
			return (nCantidadGrupo != 0);
		}
	
		private boolean OtorgarDescuento() throws Exception{
			float nPorcentaje = 0;			
			float nImpPorProducto = 0;
			
			switch (oPromocion.TipoRegla){
			case Enumeradores.Promocion.TipoRegla.Rango:
				nPorcentaje = Generales.getRound(oReglaApp.Porcentaje/100, 4) ;
				break;
			case Enumeradores.Promocion.TipoRegla.Grupo:
				float nPorc = 0;
				switch (oPromocion.TipoRango){
				case Enumeradores.Promocion.TipoRango.Cantidad:
					nImpPorProducto = oProducto.Subtotal/oProducto.Cantidad;
					nPorc = (nImpPorProducto*oReglaApp.Minimo)* (oReglaApp.Porcentaje/100);
					break;
				case Enumeradores.Promocion.TipoRango.Importe:
					nPorc = oReglaApp.Minimo*(oReglaApp.Porcentaje/100);
					break;
				}
				nPorcentaje = nPorc * nCantidadGrupo;
				nPorcentaje =Generales.getRound( Generales.getRound(((nPorcentaje*100)/oProducto.Subtotal), 4) /100, 4);
				break;
			}
			
			ActualizarDescBonif(oPromocion.PromocionClave, oProducto.ProductoClave, nPorcentaje);
			
			//Asignar a la variable AfectoImpuestos el valor True, para que al finalizar la aplicación de la promocion se haga el recalculo de los impuestos
			AfectoImpuestos = true;
			return true;
		}
		
		private boolean OtorgarBonificacion() throws Exception{
			float nPorcentaje = 0;			
			float nImpPorProducto = 0;
			float nPorc = 0;
			float nImporteDesc = 0;
			switch (oPromocion.TipoRegla){
			case Enumeradores.Promocion.TipoRegla.Rango:
				nPorcentaje = ((oReglaApp.Importe*100)/oProducto.Subtotal)/100;
				break;
			case Enumeradores.Promocion.TipoRegla.Grupo:
				switch (oPromocion.TipoRango){
				case Enumeradores.Promocion.TipoRango.Cantidad:
					nImpPorProducto = oProducto.Subtotal/oProducto.Cantidad;
					nPorc = (oReglaApp.Importe*100)/(nImpPorProducto*oReglaApp.Minimo);
					nImporteDesc = (nImpPorProducto*oReglaApp.Minimo)* (nPorc/100);
					break;
				case Enumeradores.Promocion.TipoRango.Importe:
					nPorc = (oReglaApp.Importe*100)/oReglaApp.Minimo;
					nImporteDesc = oReglaApp.Minimo*(nPorc/100);
					break;
				}
				nPorcentaje = nImporteDesc*nCantidadGrupo;
				nPorcentaje = ((nPorcentaje*100)/oProducto.Subtotal)/100;
				break;
			}
			
			ActualizarDescBonif(oPromocion.PromocionClave, oProducto.ProductoClave, nPorcentaje);
			
			//Asignar a la variable AfectoImpuestos el valor True, para que al finalizar la aplicación de la promocion se haga el recalculo de los impuestos
			AfectoImpuestos = true;
			return true;
		}
					
		private boolean OtorgarPrecio() throws Exception{
			//ListaPrecio oListaPrecio = new ListaPrecio();
			float nPrecio = 0;
			ListIterator<TransProdDetalle> oDetalles = oTransProd.TransProdDetalle.listIterator();
			while (oDetalles.hasNext()){
				TransProdDetalle oTPD = oDetalles.next();
				if (oProducto.ProductoClave.equals(oTPD.ProductoClave) && oTPD.Promocion != 2 && oTPD.getSubTotal() > 0){
					nPrecio = ListaPrecio.BuscarPrecio(oProducto.ProductoClave, (short)oTPD.TipoUnidad, oReglaApp.PrecioClave);
					if(nPrecio >= 0){
						oTPD.Promocion = 1;		
						oTransProd.Promocion = true;
						oTPD.DescuentoImp = (nPrecio * oTPD.DescuentoImp) / oTPD.Precio;
						oTPD.setSubTotal((oTPD.Cantidad * nPrecio) - ((nPrecio * oTPD.DescuentoImp) / oTPD.Precio)) ;
						oTPD.Precio = nPrecio;
						oTPD.MFechaHora = Generales.getFechaHoraActual();
						oTPD.MUsuarioID = sUsuarioId;
						oTPD.Enviado = false;
						
						TrpPrp oTPP = new TrpPrp();
						oTPP.TransProdID = oTPD.TransProdID;
						oTPP.TransProdDetalleID = oTPD.TransProdDetalleID;
						oTPP.PromocionClave = oPromocion.PromocionClave;
						oTPP.MFechaHora = Generales.getFechaHoraActual();
						oTPP.MUsuarioID = sUsuarioId;
						oTPP.Enviado = false;
						oTPD.TrpPrp.add(oTPP);
						
						BDVend.guardarInsertar(oTPD);
					}
				}
			}
			
			//Asignar a la variable AfectoImpuestos el valor True, para que al finalizar la aplicación de la promocion se haga el recalculo de los impuestos
			AfectoImpuestos = true;
			return true;
		}
		
		private boolean OtorgarProducto() throws Exception{
			oPromocion.PromocionReglaIdApp = oReglaApp.PromocionReglaID;
			oPromocion.CantidadGrupoApp = nCantidadGrupo;
			
			PRMProductoApp.put(oPromocion.PromocionClave, oPromocion);
			
			mVista.mostrarPromocionProducto( oPromocion.PromocionClave, oReglaApp.PromocionReglaID, oPromocion.CantidadGrupoApp, oTransProd.SubEmpresaId, oReglaApp.Cantidad);

			/*HashMap<String, Object>	oParametros = new HashMap<String, Object>();
			oParametros.put("PromocionClave", oPromocion.PromocionClave);
			oParametros.put("PromocionReglaID", oReglaApp.PromocionReglaID);		
			oParametros.put("CantidadGrupo", oPromocion.CantidadGrupoApp);
			oParametros.put("SubEmpresaID", oTransProd.SubEmpresaId);
			mVista.iniciarActividadConResultado(IAplicacionPromocion.class, Solicitudes.SOLICITUD_MOSTRAR_PROMOCIONES_APLICADAS, Acciones.ACCION_APLICAR_PROMOCIONES, oParametros);		
				*/	
			return true;
		}
		
		/*public boolean GuardarProductoRegalado(){
		return false; 
		}*/
		
		private boolean OtorgarPuntos() throws Exception{
			float nPorcentaje = 0;
			switch (oPromocion.TipoRango){
			case Enumeradores.Promocion.TipoRango.Cantidad:
				nPorcentaje = (oReglaApp.Cantidad * nCantidadGrupo) / oProducto.Cantidad;
				break;
			case Enumeradores.Promocion.TipoRango.Importe:
				nPorcentaje = (oReglaApp.Cantidad * nCantidadGrupo) / oProducto.Subtotal;
				break;
			}
			
			ActualizaPuntos(oPromocion.PromocionClave, oPromocion.TipoRango, oProducto.ProductoClave, nPorcentaje);
						
			return true;
		}			
		
	}
	
	public class ReglaAcumulado{
		TransProd oTransProd;
		ProductoPRM oProducto;
		Promocion oPromocion;
		PromocionRegla oReglaApp;
		int nCantidadGrupo;
				
		public ReglaAcumulado(TransProd oTransProd, ProductoPRM oProducto, Promocion oPromocion){
			this.oTransProd = oTransProd;
			this.oProducto = oProducto;
			this.oPromocion = oPromocion;
		}
		
		public void ObtenerAplicarRango() throws Exception{
			
			
				//Si el subtotal del producto es 0 y el tipo de aplicacion es descuento, bonificacion o puntos no aplicar la promocion
				if (oPromocion.ImporteAcumulado == 0 && 
				(oPromocion.TipoAplicacion == Enumeradores.Promocion.TipoAplicacion.Descuento || 
				 oPromocion.TipoAplicacion == Enumeradores.Promocion.TipoAplicacion.Bonificacion ||
				 oPromocion.TipoAplicacion == Enumeradores.Promocion.TipoAplicacion.Puntos)){
					SiguientePromocion();
					return;
				}
					
			
				if (ObtenerRango()){
					if (!oPromocion.Obligatoria && promocionActual.TipoAplicacion != Enumeradores.Promocion.TipoAplicacion.Producto){
						if(oPromocion.PrimeraVez){
                            //Replace("$0$", Me.PromocionClave & "-" & Me.Nombre & vbCrLf).Replace("$1$", parsListadoProductosAcumulados & vbCrLf).Replace("$2$", IIf(TipoRango = ServicesCentral.TiposRangosPromociones.PorCantidad, "Cantidad", "Importe")).Replace("$3$", IIf(TipoRango = ServicesCentral.TiposRangosPromociones.PorCantidad, Me.Cantidad, Me.Importe)), MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
							mVista.mostrarObligatorio(Mensajes.get("P0104", oPromocion.PromocionClave + " - " + oPromocion.Nombre + "\n", oPromocion.ListadoProductosAcumulados + "\n", (oPromocion.TipoRango == Enumeradores.Promocion.TipoRango.Cantidad ? Mensajes.get("XCantidad") : Mensajes.get("XSubTotal")) ,(oPromocion.TipoRango == Enumeradores.Promocion.TipoRango.Cantidad ? String.valueOf(oPromocion.CantidadAcumulado) : String.valueOf(oPromocion.ImporteAcumulado)) ), 99);

							//mostrarObligatorio("Aplicar?", 99);
							oPromocion.PrimeraVez = false;
							return;
						}else{
							if (oPromocion.SeAcepto){
								Aplicar();
								SiguientePromocion();
								return;
							}
						}
					}else {
						Aplicar();
						if (promocionActual.TipoAplicacion != Enumeradores.Promocion.TipoAplicacion.Producto){
							SiguientePromocion();
						}
						return;
					}
				}				
				SiguientePromocion();			
		}
		
		public void Aplicar() throws Exception{
			switch (oPromocion.TipoAplicacion){
			case Enumeradores.Promocion.TipoAplicacion.Descuento:
				OtorgarDescuento();
				break;
			case Enumeradores.Promocion.TipoAplicacion.Bonificacion:
				OtorgarBonificacion();
				break;
			case Enumeradores.Promocion.TipoAplicacion.Producto:
				OtorgarProducto();
				break;
			case Enumeradores.Promocion.TipoAplicacion.Puntos:
				OtorgarPuntos();
				break;
			}
		}
		private boolean ObtenerRango(){
			//Recupera los rangos que aplican para la promocion (ordenados por el Minimo)
			ReglaComparator oComp = new ReglaComparator();
			Collections.sort(oPromocion.PromocionRegla, oComp);
			

			boolean bTerminar = false;
			float nCantidad = 0;
			nCantidadGrupo = 0;
			
			//Determinar el rango en que entra la cantidad o subtotal del producto, y el numero de veces que se aplicara la promocion
			ListIterator<PromocionRegla> oReglas = oPromocion.PromocionRegla.listIterator();
			while (oReglas.hasNext() && !bTerminar){
				PromocionRegla oRegla = oReglas.next();
								
				switch(oPromocion.TipoRango){
					case Enumeradores.Promocion.TipoRango.Cantidad:
						nCantidad = oPromocion.CantidadAcumulado;
						break;
					case Enumeradores.Promocion.TipoRango.Importe:
						nCantidad = oPromocion.ImporteAcumulado;
						break;
				}
				
				switch (oPromocion.TipoRegla){
					case Enumeradores.Promocion.TipoRegla.Rango:
						if (nCantidad >= oRegla.Minimo && nCantidad <= oRegla.Maximo)									
							nCantidadGrupo = 1;
						break;
					case Enumeradores.Promocion.TipoRegla.Grupo:
						nCantidadGrupo = (int) (nCantidad/oRegla.Minimo);
						break;
				}	
				
				bTerminar = (nCantidadGrupo != 0);
				if (bTerminar)
					oReglaApp = oRegla;
			}
			
			return (nCantidadGrupo != 0);
		}
		
		private boolean OtorgarDescuento() throws Exception{
			float nPorcentaje = 0;
			float nImpPorProducto = 0;
			
			if (oPromocion.PrimeraVez){
				oPromocion.RestoAcumulado = oReglaApp.Minimo * nCantidadGrupo;
				oPromocion.PrimeraVez = false;
			}
			
			switch (oPromocion.TipoRegla){
			case Enumeradores.Promocion.TipoRegla.Rango:
				nPorcentaje = Generales.getRound(oReglaApp.Porcentaje / 100, 4) ;
				break;
			case Enumeradores.Promocion.TipoRegla.Grupo:
				float nCantidad = 0;
				
				if (oPromocion.TipoRango == Enumeradores.Promocion.TipoRango.Cantidad)
					nCantidad = oProducto.Cantidad;
				else //Enumeradores.Promocion.TipoRango.Importe
					nCantidad = oProducto.Subtotal;					
								
				if (nCantidad > oPromocion.RestoAcumulado)
					nCantidad = oPromocion.RestoAcumulado;
				
				oPromocion.RestoAcumulado -= nCantidad;
				
				switch (oPromocion.TipoRango){
				case Enumeradores.Promocion.TipoRango.Cantidad:
					nImpPorProducto = oProducto.Subtotal/oProducto.Cantidad;
					nPorcentaje = (nImpPorProducto * nCantidad) * (oReglaApp.Porcentaje / 100);
					break;
				case Enumeradores.Promocion.TipoRango.Importe:
					nPorcentaje = nCantidad * (oReglaApp.Porcentaje / 100);
					break;
				}						
				nPorcentaje = Generales.getRound(Generales.getRound(((nPorcentaje * 100) / oProducto.Subtotal),8) / 100, 8);
				break;
			}
			
			ActualizarDescBonif(oPromocion.PromocionClave, oProducto.ProductoClave, nPorcentaje);
			
			//Asignar a la variable AfectoImpuestos el valor True, para que al finalizar la aplicación de la promocion se haga el recalculo de los impuestos
			AfectoImpuestos = true;
			
			return true;
		}
		
		private boolean OtorgarBonificacion() throws Exception{
			float nPorcentaje; 
			nPorcentaje = (oReglaApp.Importe * nCantidadGrupo)/ oPromocion.CantidadAcumulado;
			
			ActualizarDescBonif(oPromocion.PromocionClave, oProducto.ProductoClave, nPorcentaje);
			
			//Asignar a la variable AfectoImpuestos el valor True, para que al finalizar la aplicación de la promocion se haga el recalculo de los impuestos
			AfectoImpuestos = true;
			
			return true;
		}

		private boolean OtorgarProducto() throws Exception{
			oPromocion.PromocionReglaIdApp = oReglaApp.PromocionReglaID;
			oPromocion.CantidadGrupoApp = nCantidadGrupo;
			
			PRMProductoApp.put(oPromocion.PromocionClave, oPromocion);
			
			mVista.mostrarPromocionProducto( oPromocion.PromocionClave, oReglaApp.PromocionReglaID, oPromocion.CantidadGrupoApp, oTransProd.SubEmpresaId, oReglaApp.Cantidad);
			/*HashMap<String, Object>	oParametros = new HashMap<String, Object>();
			oParametros.put("PromocionClave", oPromocion.PromocionClave);
			oParametros.put("PromocionReglaID", oReglaApp.PromocionReglaID);		
			oParametros.put("CantidadGrupo", oPromocion.CantidadGrupoApp);
			oParametros.put("SubEmpresaID", oTransProd.SubEmpresaId);
			mVista.iniciarActividadConResultado(IAplicacionPromocion.class, Solicitudes.SOLICITUD_MOSTRAR_PROMOCIONES_APLICADAS, Acciones.ACCION_APLICAR_PROMOCIONES, oParametros);		
				*/	
			return true;
		}
		
		private boolean OtorgarPuntos() throws Exception{
			float nCantidad = 0;
			float nCantidadProd = 0;
			float nPuntos = 0;
			float nPuntosAplicar = 0;
			float nPorcentaje = 0;
			
			if (oPromocion.PrimeraVez){
				oPromocion.RestoAcumulado = oReglaApp.Minimo * nCantidadGrupo;
				oPromocion.PrimeraVez = false;						
			}
			
			if (oPromocion.TipoRango == Enumeradores.Promocion.TipoRango.Cantidad)
				nCantidad = oProducto.Cantidad;
			else //Enumeradores.Promocion.TipoRango.Importe
				nCantidad = oProducto.Subtotal;
			
			if (nCantidad > oPromocion.RestoAcumulado)
				nCantidadProd = oPromocion.RestoAcumulado;
			else
				nCantidadProd = nCantidad;
			
			nPuntos = (oReglaApp.Cantidad * nCantidadGrupo) - oPromocion.PuntosAcumulado;
			nPuntosAplicar = (nCantidadProd * nPuntos) / oPromocion.RestoAcumulado;
			nPorcentaje = nPuntosAplicar / nCantidad;
			
			if (nPuntosAplicar > 0){
				ActualizaPuntos(oPromocion.PromocionClave, oPromocion.TipoRango, oProducto.ProductoClave, nPorcentaje);
			}
			
			oPromocion.RestoAcumulado -= nCantidadProd;
			
			return true;
		}
	}	
			
	
	public static class ProductoPRM{
		public String ProductoClave;
		public float Cantidad;
		public float Subtotal;
		
	    public ProductoPRM (String sProductoClave, float nCantidad, float nSubtotal){
	    	this.ProductoClave = sProductoClave;
	    	this.Cantidad = nCantidad;
	    	this.Subtotal = nSubtotal;
	    }
	}
	
	public static class ReglaComparator implements Comparator<PromocionRegla>{
		@Override
		public int compare(PromocionRegla a, PromocionRegla b) {
			return (int) (a.Minimo - b.Minimo);
		}
	}

	
	/****************Eventos****************************************/
	public interface onTerminarAplicacionListener{
		void onTerminarAplicacion();
	}
	
	private onTerminarAplicacionListener terminarAplicacionListener = null;
	
	public void setOnTerminarAplicacionListener(onTerminarAplicacionListener l){
		terminarAplicacionListener = l;
	}
}
