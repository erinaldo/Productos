package com.amesol.routelite.presentadores.act;

import java.text.DecimalFormat;
import java.text.NumberFormat;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.HashMap;
import java.util.Iterator;
import java.util.List;
import java.util.Map;
import java.util.concurrent.atomic.AtomicReference;

import android.database.Cursor;
import android.util.Log;

import com.amesol.routelite.actividades.Folios;
import com.amesol.routelite.actividades.Inventario;
import com.amesol.routelite.actividades.ListaPrecio;
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.actividades.Recibos;
import com.amesol.routelite.actividades.Transacciones;
import com.amesol.routelite.actividades.TransaccionesDetalle;
import com.amesol.routelite.actividades.ValoresReferencia;
import com.amesol.routelite.actividades.Enumeradores.Inventario.TiposValidacionInventario;
import com.amesol.routelite.datos.Cliente;
import com.amesol.routelite.datos.ModuloMovDetalle;
import com.amesol.routelite.datos.Precio;
import com.amesol.routelite.datos.Producto;
import com.amesol.routelite.datos.SaldoCambiosVendedor;
import com.amesol.routelite.datos.TransProd;
import com.amesol.routelite.datos.TransProdDetalle;
import com.amesol.routelite.datos.Vendedor;
import com.amesol.routelite.datos.Visita;
import com.amesol.routelite.datos.basedatos.BDVend;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.basedatos.Consultas.ConsultasCantidad;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.CONHist;
import com.amesol.routelite.datos.utilerias.ConfigParametro;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.Enumeradores.TiposMovimientos;
import com.amesol.routelite.presentadores.Presentador;
import com.amesol.routelite.presentadores.interfaces.ICambiaProducto;
import com.amesol.routelite.utilerias.ControlError;
import com.amesol.routelite.utilerias.Generales;

public class CambiarProducto extends Presentador
{

	ICambiaProducto mVista;
	String mAccion;
	String sClienteClave;
	HashMap<String, TransProd> transacciones = new HashMap<String, TransProd>();
	TransProd transProdGeneral;
	TransProd transProdSalida;
	ModuloMovDetalle moduloMovDetalle;
	private CONHist oConHist;

	public CambiarProducto(ICambiaProducto vista, String accion)
	{
		mVista = vista;
		mAccion = accion;
		sClienteClave = ((Cliente) Sesion.get(Campo.ClienteActual)).ClienteClave;
		String sModuloMovDetalleClave = (String) Sesion.get(Campo.ModuloMovDetalleClave);
		moduloMovDetalle = new ModuloMovDetalle();
		moduloMovDetalle.ModuloMovDetalleClave = sModuloMovDetalleClave;
		try
		{
			BDVend.recuperar(moduloMovDetalle);
		}
		catch (Exception e)
		{
			mVista.mostrarError(e.getMessage());
		}
		oConHist = (CONHist) Sesion.get(Campo.CONHist);
	}

	@Override
	public void iniciar()
	{
		try
		{
			mVista.iniciar();

			if (mAccion.equals(Enumeradores.Acciones.ACCION_CAMBIOS_PRODUCTO_ENTRADA))
			{
				mVista.setFolio(transProdGeneral.Folio);
				mVista.setFecha(new SimpleDateFormat("dd/MM/yyyy").format(transProdGeneral.FechaCaptura));
			}

		}
		catch (Exception e)
		{
			mVista.mostrarError(e.getMessage());
		}
	}

	
	public void guardarEntradaYMostrarSalida(boolean esNuevo, boolean confirmarFolio, boolean soloLectura) throws Exception
	{
		TransProd trp = null;
		HashMap<String, String> oParametros = new HashMap<String, String>();
		if (esNuevo)
		{
			if (confirmarFolio)
				Folios.confirmar(Sesion.get(Campo.ModuloMovDetalleClave).toString());
			trp = crearTransProdSalida();
			oParametros.put("TransProdId", trp.TransProdID);
		}
		else
		{
			oParametros.put("TransProdId", recuperarTransProdIdSalida());
			oParametros.put("Eliminar", String.valueOf(soloLectura));
			trp = transProdSalida;
		}
		oParametros.put("esNuevo", esNuevo ? "true" : "false");
		oParametros.put("Importe", obtenerTotales(getTransaccionesIds()));
		oParametros.put("Cambios", mVista.getHuboCambios() ? "true" : "false");

		if (Sesion.get(Campo.ArrayTransProd) == null)
		{
			ArrayList<TransProd> atrp = new ArrayList<TransProd>();
			atrp.add(trp);
			Sesion.set(Campo.ArrayTransProd, atrp);
		}

		mVista.iniciarActividadConResultado(ICambiaProducto.class, Enumeradores.Solicitudes.SOLICITUD_CAMBIAR_PRODUCTO_SALIDA, Enumeradores.Acciones.ACCION_CAMBIAR_PRODUCTO_SALIDA, oParametros);
	}

	public String obtenerTotales(String TransProdID)
	{
		try
		{
			String res = "0";
			ISetDatos setDatos = Consultas.ConsultasTransProdDetalle.obtenerTotales(TransProdID);
			if (setDatos.moveToNext())
			{
				res = setDatos.getString(1);
			}
			setDatos.close();
			return res == null ? "0" : res;
		}
		catch (Exception e)
		{
			return "0";
		}
	}

/*	public void generarSalida(boolean esNuevo) throws Exception
	{
		if (esNuevo)
			Folios.confirmar(Sesion.get(Campo.ModuloMovDetalleClave).toString());

		TransProd trp = crearTransProdSalida();
		if (esNuevo)
			Folios.confirmar(Sesion.get(Campo.ModuloMovDetalleClave).toString());
		for (TransProdDetalle tpd : getTransProd().TransProdDetalle)
		{
			//if (tpd.recienAgregado)
			//{ //solo generar detalle para los productos recien agregados
				TransProdDetalle otpd = existeSalida(tpd.producto, tpd.TipoUnidad);
				if (otpd == null){
					generarDetalleSalida(tpd.producto, tpd.TipoUnidad, tpd.Cantidad);
					BDVend.guardarInsertar(otpd);
				}
			//}
			else if (tpd.cantidadModificada)
			{
				TransProdDetalle otpd = existeSalida(tpd.producto, tpd.TipoUnidad);
				//actualizar inventario (No envía Motivo para afectar el Disponible)
				//Log.d("CambiosProducto", "Actualizar inventario " + (trp.TipoMovimiento == 1 ? "entrada" : "salida") + ", Producto: " + otpd.ProductoClave + ", Cantidad: " + otpd.Cantidad);
				actualizarInventarioSinMotivo(otpd, trp.TipoMovimiento);
			}
		}
	}*/

/*	public void darSalida()
	{
		try
		{
			for (TransProdDetalle tpd : getTransProd().TransProdDetalle)
			{
				if (tpd.recienAgregado || tpd.cantidadModificada) //solo dar salida a los nuevos y modificados
					//actualizar inventario (No envía Motivo para afectar el Disponible)
					//Log.d("CambiosProducto", "Actualizar inventario " + (getTipoMovimiento() == 1 ? "entrada" : "salida") + ", Producto: " + tpd.ProductoClave + ", Cantidad: " + tpd.Cantidad);
					actualizarInventarioSinMotivo(tpd, getTipoMovimiento());
			}
		}
		catch (Exception e)
		{
			mVista.mostrarError(e.getMessage());
		}
	}*/

	@SuppressWarnings("unchecked")
	public void recuperarTransProd(String transProdID)
	{
		try
		{
			if (mAccion.equals(Enumeradores.Acciones.ACCION_CAMBIOS_PRODUCTO_ENTRADA))
			{
				HashMap<Integer,Precio> listasPrecios = ListaPrecio.Determinar(sClienteClave, moduloMovDetalle);
				transProdGeneral = new TransProd();
				transProdGeneral.TransProdID = transProdID;
				BDVend.recuperar(transProdGeneral);
				transProdGeneral.setListaPrecios(listasPrecios);
				transProdGeneral.PCEPrecioClave = listasPrecios.get(0).PrecioClave;
				BDVend.recuperar(transProdGeneral, TransProdDetalle.class);

				for (TransProdDetalle tpd : transProdGeneral.TransProdDetalle)
				{
					Producto pro = new Producto();
					pro.ProductoClave = tpd.ProductoClave;
					BDVend.recuperar(pro);
					tpd.producto = pro;
					tpd.recienAgregado = false;
					tpd.cantidadModificada = false;
				}
			}
			else if (mAccion.equals(Enumeradores.Acciones.ACCION_CAMBIAR_PRODUCTO_SALIDA))
			{
				//obtener el transprod de sesion
				ArrayList<TransProd> otrp = (ArrayList<TransProd>) Sesion.get(Campo.ArrayTransProd);
				transProdGeneral = otrp.get(0);
			}

			transacciones.put(transProdGeneral.SubEmpresaId, transProdGeneral);
			mVista.setParametrosCaptura(transProdGeneral.CadenaListasPrecios, getTransaccionesIds());
		}
		catch (Exception e)
		{
			mVista.mostrarError(e.getMessage());
		}
	}

	public void crearTransProd() throws ControlError, Exception
	{
		StringBuilder byRefMensaje = new StringBuilder();
		transProdGeneral = Transacciones.generarTransaccion(moduloMovDetalle, byRefMensaje);
		if (byRefMensaje.length() >0){
			mVista.mostrarAdvertencia(byRefMensaje.toString());
		}
		byRefMensaje = null;
		transProdGeneral.CFVTipo = (Short) null;
		transProdGeneral.ClienteClave = null;

		Calendar cal = Calendar.getInstance();
		cal.setTime(Generales.getFechaActual());
		cal.add(Calendar.DATE, Integer.parseInt(oConHist.get("DiasSurtido").toString()));
		transProdGeneral.FechaEntrega = cal.getTime();

		transProdGeneral.FechaCobranza = Generales.getFechaActual();
		transProdGeneral.FechaFacturacion = Generales.getMinFecha();
		transProdGeneral.FechaSurtido = Generales.getMinFecha();
		transProdGeneral.FechaCancelacion = Generales.getMinFecha();

		BDVend.recuperar(transProdGeneral, TransProdDetalle.class);
		transacciones.put(transProdGeneral.SubEmpresaId, transProdGeneral);
		mVista.setParametrosCaptura(transProdGeneral.CadenaListasPrecios , getTransaccionesIds());
		BDVend.guardarInsertar(transProdGeneral);
	}

	public TransProd crearTransProdSalida()
	{
		try
		{
			if (transProdSalida == null)
			{
				StringBuilder byRefMensaje = new StringBuilder();
				transProdSalida = Transacciones.generarTransaccion(moduloMovDetalle, byRefMensaje);
				if (byRefMensaje.length() >0){
					mVista.mostrarAdvertencia(byRefMensaje.toString());
				}
				byRefMensaje = null;
				transProdSalida.CFVTipo = (Short) null;
				transProdSalida.ClienteClave = null;
				transProdSalida.TipoMovimiento = 2;

				Calendar cal = Calendar.getInstance();
				cal.setTime(Generales.getFechaActual());
				cal.add(Calendar.DATE, Integer.parseInt(oConHist.get("DiasSurtido").toString()));
				transProdSalida.FechaEntrega = cal.getTime();

				transProdSalida.FechaCobranza = Generales.getFechaActual();
				transProdSalida.FechaFacturacion = Generales.getMinFecha();
				transProdSalida.FechaSurtido = Generales.getMinFecha();
				transProdSalida.FechaCancelacion = Generales.getMinFecha();

				BDVend.guardarInsertar(transProdSalida);
				actualizarFacturaId(transProdSalida.TransProdID);
				
				Folios.confirmar(Sesion.get(Campo.ModuloMovDetalleClave).toString());
			}
			return transProdSalida;
		}
		catch (Exception e)
		{
			mVista.mostrarError(e.getMessage());
			return null;
		}
	}

	public short getTipoMovimiento()
	{
		return transProdGeneral.TipoMovimiento;
	}

	public TransProd getTransProd()
	{
		return transProdGeneral;
	}

	public TransProd getSalida()
	{
		return transProdSalida;
	}

	public String recuperarTransProdIdSalida()
	{
		try
		{

			if (transProdSalida == null)
			{
				HashMap<Integer,Precio> listasPrecios = ListaPrecio.Determinar(sClienteClave, moduloMovDetalle);
				transProdSalida = new TransProd();
				transProdSalida.TransProdID = transProdGeneral.FacturaID;
				BDVend.recuperar(transProdSalida);
				transProdSalida.setListaPrecios(listasPrecios);
				transProdSalida.PCEPrecioClave = listasPrecios.get(0).PrecioClave;
				BDVend.recuperar(transProdSalida, TransProdDetalle.class);

				for (TransProdDetalle tpd : transProdSalida.TransProdDetalle)
				{
					Producto pro = new Producto();
					pro.ProductoClave = tpd.ProductoClave;
					BDVend.recuperar(pro);
					tpd.producto = pro;
					tpd.recienAgregado = false;
					tpd.cantidadModificada = false;
				}
			}

			return transProdGeneral.FacturaID;
		}
		catch (Exception e)
		{
			mVista.mostrarError(e.getMessage());
			return null;
		}
	}

	private void actualizarFacturaId(String FacturaId)
	{
		try
		{
			transProdGeneral.FacturaID = FacturaId;
			BDVend.guardarInsertar(transProdGeneral);
		}
		catch (Exception e)
		{
			mVista.mostrarError(e.getMessage());
		}
	}

	public boolean validarProductoContenido(Producto producto) throws Exception
	{
		if (producto.Contenido && !producto.Venta)
		{
			throw new ControlError("E0725");
		}
		return true;
	}

	public String getTransaccionesIds()
	{
		String Ids = "";
		for (final Object transProd : transacciones.values().toArray())
		{
			Ids = Ids + "'" + (((TransProd) transProd).TransProdID) + "',";
		}
		if (Ids.length() > 0)
		{
			Ids = Ids.substring(0, Ids.length() - 1);
		}
		return Ids;
	}

	public short getTipoFase()
	{
		return transProdGeneral.TipoFase;
	}


	/*private void actualizarInventarioSinMotivo(TransProdDetalle oTpd, short tipoMovimiento) throws Exception
	{
		//TODO: actualizar inventario (No envía Motivo para afectar el Disponible)
		Log.d("CambiosProducto", "Actualizar inventario " + (tipoMovimiento == 1 ? "entrada" : "salida") + ", Producto: " + oTpd.ProductoClave + ", Cantidad: " + oTpd.Cantidad);
		Vendedor vendedor = (Vendedor) Sesion.get(Campo.VendedorActual);
		Inventario.ActualizarInventario(oTpd.ProductoClave, oTpd.TipoUnidad, oTpd.Cantidad, moduloMovDetalle.TipoTransProd, tipoMovimiento, vendedor.AlmacenID, false);
	}*/

/*	private void apartarInventarioEntrada(String productoClave, float cantidad)
	{
		//TODO: apartar inventario (entrada)
		Log.d("CambiosProducto", "Apartar inventario, Producto: " + productoClave + ", Cantidad: " + cantidad);
	}

	private void apartarInventarioSalida(String productoClave, float cantidad)
	{
		//TODO: apartar inventario (salida)
		Log.d("CambiosProducto", "Apartar inventario, Producto: " + productoClave + ", Cantidad: " + cantidad);
	}

	private void deshacerApartadoEntrada(String productoClave, float cantidad)
	{
		//TODO: deshacer apartado (entrada)
		Log.d("CambiosProducto", "Apartar inventario (deshacer), Producto: " + productoClave + ", Cantidad: " + cantidad);
	}*/

	public boolean agregarProductoUnidad(Producto producto, int TipoUnidad, Float Cantidad, short TipoMotivo, boolean busqueda, final StringBuilder refError)
	{
		try
		{
			TransProdDetalle transProdDetalle = null;
			if (mVista.getCambioAutomatico())
			{
				if (!busqueda && mVista.getTipoValidacionInventario() != TiposValidacionInventario.NoValidar)
				{
					AtomicReference<Float> existencia = new AtomicReference<Float>();
					//Verificar la salida de inventario disponible
					if (!Inventario.ValidarExistencia(producto.ProductoClave, TipoUnidad, Cantidad, Float.valueOf(0), (short)TiposMovimientos.SALIDA, (short)moduloMovDetalle.TipoTransProd, false,existencia, refError))
					{
						if (mVista.getTipoValidacionInventario() == TiposValidacionInventario.ValidacionRestrictiva)
						{
							if (existencia.get() != null && existencia.get() > 0)
							{
								mVista.setCantidadCaptura(existencia.get());
							}else{
								mVista.setCantidadCaptura(Cantidad);
							}
							return false;
						}
					}
				}

				generarDetalleSalida(producto, TipoUnidad, Cantidad);
				Inventario.ActualizarInventario(producto.ProductoClave, TipoUnidad, Cantidad, moduloMovDetalle.TipoTransProd, TiposMovimientos.SALIDA,((Vendedor) Sesion.get(Campo.VendedorActual)).AlmacenID);
				
				transProdDetalle = generarDetalle(producto, TipoUnidad, Cantidad, TipoMotivo);
				if (transProdDetalle == null)
					return false;
				// actualizar motivo (entrada)
				transProdDetalle = TransaccionesDetalle.ActualizarTipoMotivoTransaccion(transProdDetalle, TipoMotivo, moduloMovDetalle.TipoTransProd, transProdDetalle.Cantidad, false);
			}
			else
			{
				if (mAccion.equals(Enumeradores.Acciones.ACCION_CAMBIAR_PRODUCTO_SALIDA))
				{
					if (!busqueda && mVista.getTipoValidacionInventario() != TiposValidacionInventario.NoValidar)
					{
						AtomicReference<Float> existencia = new AtomicReference<Float>();
						//Verificar la salida de inventario disponible
						if (!Inventario.ValidarExistencia(producto.ProductoClave, TipoUnidad, Cantidad,  Float.valueOf(0), (short)TiposMovimientos.SALIDA, (short)moduloMovDetalle.TipoTransProd, false, existencia, refError))
						{
							if (mVista.getTipoValidacionInventario() == TiposValidacionInventario.ValidacionRestrictiva)
							{
								if (existencia.get() != null && existencia.get() > 0)
								{
									mVista.setCantidadCaptura(existencia.get());
								}else{
									mVista.setCantidadCaptura(Cantidad);
								}
								return false;
							}
						}
					}
					
					transProdDetalle = generarDetalle(producto, TipoUnidad, Cantidad, TipoMotivo);
					if (transProdDetalle == null)
						return false;
					Inventario.ActualizarInventario(producto.ProductoClave, TipoUnidad, Cantidad, moduloMovDetalle.TipoTransProd, TiposMovimientos.SALIDA, ((Vendedor) Sesion.get(Campo.VendedorActual)).AlmacenID);
				}
				else if (mAccion.equals(Enumeradores.Acciones.ACCION_CAMBIOS_PRODUCTO_ENTRADA))
				{
					transProdDetalle = generarDetalle(producto, TipoUnidad, Cantidad, TipoMotivo);
					//actualizar motivo (entrada)
					if (transProdDetalle == null)
						return false;
					transProdDetalle = TransaccionesDetalle.ActualizarTipoMotivoTransaccion(transProdDetalle, TipoMotivo, moduloMovDetalle.TipoTransProd, transProdDetalle.Cantidad, false);
				}
			}
			BDVend.guardarInsertar(transProdDetalle);
			mVista.setHuboCambios(true);
			mVista.refrescarProductos(getTransaccionesIds());
			return true;
		}
		catch (Exception e)
		{
			mVista.mostrarError(e.getMessage());
		}
		return false;
	}

	public boolean agregarProductoUnidad(Producto producto, TransProdDetalle transProdDetalle, short tipoMotivo, boolean busqueda)
	{
		StringBuilder error = new StringBuilder();
		return agregarProductoUnidad(producto, transProdDetalle.TipoUnidad, transProdDetalle.Cantidad, tipoMotivo, busqueda, error );
	}

	public boolean actualizarCantidad(TransProdDetalle tpd, Float cantidad, final StringBuilder refError)
	{
		try
		{
			tpd.cantidadModificada = true;
			//if (mVista.getEsNuevo() || tpd.recienAgregado)
			//{

				if (mAccion.equals(Enumeradores.Acciones.ACCION_CAMBIAR_PRODUCTO_SALIDA))
				{
					
					if (mVista.getTipoValidacionInventario() != TiposValidacionInventario.NoValidar)
					{
						AtomicReference<Float> existencia = new AtomicReference<Float>();
						//Verificar la salida de inventario disponible
						if (!Inventario.ValidarExistencia(tpd.ProductoClave, tpd.TipoUnidad, cantidad, tpd.Cantidad, (short)TiposMovimientos.SALIDA , moduloMovDetalle.TipoTransProd, false, existencia, refError))
						{
							if (mVista.getTipoValidacionInventario() == TiposValidacionInventario.ValidacionRestrictiva)
							{
								if (existencia.get() != null && existencia.get() > 0)
								{
									mVista.setCantidadCaptura(tpd.Cantidad +  existencia.get());
								}else{
									mVista.setCantidadCaptura(tpd.Cantidad);
								}
								return false;
							}

						}
					}

					//Cancelar la salida
					Inventario.ActualizarInventario(tpd.ProductoClave, tpd.TipoUnidad, tpd.Cantidad, moduloMovDetalle.TipoTransProd, TiposMovimientos.SALIDA, ((Vendedor)Sesion.get(Campo.VendedorActual)).AlmacenID, true);
					tpd.Cantidad = cantidad;
					tpd = TransaccionesDetalle.Cambios.CalcularTotales(tpd);
					BDVend.guardarInsertar(tpd);
					//Dar salida a la nueva cantidad
					Inventario.ActualizarInventario(tpd.ProductoClave, tpd.TipoUnidad, tpd.Cantidad, moduloMovDetalle.TipoTransProd, TiposMovimientos.SALIDA, ((Vendedor)Sesion.get(Campo.VendedorActual)).AlmacenID,false);
				}
				else
				{
					if (mVista.getCambioAutomatico())
					{
						if (mVista.getTipoValidacionInventario() != TiposValidacionInventario.NoValidar)
						{
							AtomicReference<Float> existencia = new AtomicReference<Float>();
							//Verificar la salida de inventario disponible
							if (!Inventario.ValidarExistencia(tpd.ProductoClave, tpd.TipoUnidad, cantidad, tpd.Cantidad, (short) TiposMovimientos.SALIDA,  moduloMovDetalle.TipoTransProd, false, existencia, refError))
							{
								if (mVista.getTipoValidacionInventario() == TiposValidacionInventario.ValidacionRestrictiva)
								{
									if (existencia.get() != null && existencia.get() > 0)
									{
										mVista.setCantidadCaptura(tpd.Cantidad+  existencia.get());
									}else{
										mVista.setCantidadCaptura(tpd.Cantidad);
									}
									return false;
								}
							}
						}

					}

					// actualiza tipo motivo (salida)
					TransProdDetalle res;
					res = TransaccionesDetalle.ActualizarTipoMotivoTransaccion(tpd, tpd.TipoMotivo, moduloMovDetalle.TipoTransProd, cantidad, true);
					if(res == null) return false;
					
					tpd.Cantidad = cantidad;
					tpd = TransaccionesDetalle.Cambios.CalcularTotales(tpd);
					BDVend.guardarInsertar(tpd);
					// actualizar tipo motivo (entrada)
					TransaccionesDetalle.ActualizarTipoMotivoTransaccion(tpd, tpd.TipoMotivo, moduloMovDetalle.TipoTransProd, cantidad, false);


					if (mVista.getCambioAutomatico())
					{
						tpd = existeSalida(tpd.producto, tpd.TipoUnidad);
						if (tpd != null){
						//Dar entrada a la cantidad original 
							Inventario.ActualizarInventario(tpd.ProductoClave, tpd.TipoUnidad, tpd.Cantidad, moduloMovDetalle.TipoTransProd, TiposMovimientos.SALIDA, ((Vendedor)Sesion.get(Campo.VendedorActual)).AlmacenID, true);
							tpd.Cantidad = cantidad;
							tpd = TransaccionesDetalle.Cambios.CalcularTotales(tpd);
							BDVend.guardarInsertar(tpd);
							//Dar salida a la nueva cantidad
							Inventario.ActualizarInventario(tpd.ProductoClave, tpd.TipoUnidad, tpd.Cantidad, moduloMovDetalle.TipoTransProd, TiposMovimientos.SALIDA, ((Vendedor)Sesion.get(Campo.VendedorActual)).AlmacenID);
						}
					}
					
				}

			mVista.setHuboCambios(true);
			mVista.refrescarProductos(getTransaccionesIds());
			return true;
		}
		catch (Exception e)
		{
			mVista.mostrarError(e.getMessage());
		}
		return false;
	}

	public TransProdDetalle existe(Producto producto, int tipoUnidad)
	{
		for (TransProdDetalle trp : transProdGeneral.TransProdDetalle)
		{
			if (trp.ProductoClave.equals(producto.ProductoClave) && trp.TipoUnidad == tipoUnidad)
				return trp;
			else if (trp.ProductoClave.compareToIgnoreCase(producto.ProductoClave) > 0) //si la clave es mayor a la que se busca salir para no recorrer todo el array
				return null;
		}
		return null;
	}

	public TransProdDetalle existeSalida(Producto producto, int tipoUnidad)
	{
		for (TransProdDetalle trp : transProdSalida.TransProdDetalle)
		{
			if (trp.ProductoClave.equals(producto.ProductoClave) && trp.TipoUnidad == tipoUnidad)
				return trp;
		}
		return null;
	}


	public void eliminarDetalle(TransProdDetalle tpd)
	{
		try
		{
			if (mAccion.equals(Enumeradores.Acciones.ACCION_CAMBIOS_PRODUCTO_ENTRADA))
			{
				// actualizar tipo motivo (salida)
				if (TransaccionesDetalle.ActualizarTipoMotivoTransaccion(tpd, tpd.TipoMotivo,  moduloMovDetalle.TipoTransProd, Float.valueOf(0), true) == null){
					return;
				}
				
				if (mVista.getCambioAutomatico())
				{
					//volver a meter el inventario del producto que se cambio
					Inventario.ActualizarInventario(tpd.ProductoClave, tpd.TipoUnidad, tpd.Cantidad, moduloMovDetalle.TipoTransProd, TiposMovimientos.SALIDA,   ((Vendedor) Sesion.get(Campo.VendedorActual)).AlmacenID, true);						

					TransProdDetalle otpdSal = existeSalida(tpd.producto, tpd.TipoUnidad);
					transProdSalida.TransProdDetalle.remove(otpdSal);
					BDVend.eliminar(otpdSal);
				}
			}
			else if (mAccion.equals(Enumeradores.Acciones.ACCION_CAMBIAR_PRODUCTO_SALIDA))
			{
				Inventario.ActualizarInventario(tpd.ProductoClave, tpd.TipoUnidad, tpd.Cantidad, moduloMovDetalle.TipoTransProd, TiposMovimientos.SALIDA,   ((Vendedor) Sesion.get(Campo.VendedorActual)).AlmacenID,true);
			}
			//Se elimina el movimiento seleccionado
			transProdGeneral.TransProdDetalle.remove(tpd);
			BDVend.eliminar(tpd);
			mVista.setHuboCambios(true);
		}
		catch (Exception e)
		{
			mVista.mostrarError(e.getMessage());
		}
	}

	private TransProdDetalle generarDetalle(Producto producto, int TipoUnidad, Float Cantidad, short TipoMotivo)
	{
		try
		{
			TransProdDetalle transProdDetalle = TransaccionesDetalle.Cambios.GenerarDetalleCambio(transProdGeneral.TransProdID, producto.ProductoClave, TipoUnidad, Cantidad, 0, transProdGeneral.CadenaListasPrecios);
			if (transProdDetalle == null)
				throw new ControlError("MDB042302");

			transProdDetalle.producto = producto;
			transProdDetalle.recienAgregado = true;

			if (mAccion.equals(Enumeradores.Acciones.ACCION_CAMBIAR_PRODUCTO_SALIDA))
			{
				transProdDetalle.TipoMotivo = (Short) null;
			}
			else if (mAccion.equals(Enumeradores.Acciones.ACCION_CAMBIOS_PRODUCTO_ENTRADA))
			{
				transProdDetalle.TipoMotivo = TipoMotivo;
				/*if (TipoMotivo != 0)
				{
					
				}*/
			}

			transProdGeneral.TransProdDetalle.add(transProdDetalle);
			mVista.setHuboCambios(true);
			mVista.refrescarProductos(getTransaccionesIds());

			return transProdDetalle;

		}
		catch (Exception ex)
		{
			mVista.mostrarError(ex.getMessage() == null ? ex.getCause().getMessage() : ex.getMessage());
			return null;
		}
	}

	private TransProdDetalle generarDetalleSalida(Producto producto, int TipoUnidad, Float Cantidad)
	{
		try
		{
			//Crear TransProdSalida si no existe
			crearTransProdSalida();
						
			TransProdDetalle transProdDetalle = TransaccionesDetalle.Cambios.GenerarDetalleCambio(transProdSalida.TransProdID, producto.ProductoClave, TipoUnidad, Cantidad, 0, transProdSalida.CadenaListasPrecios);
			if (transProdDetalle == null)
				throw new ControlError("MDB042302");

			transProdDetalle.producto = producto;
			transProdDetalle.TipoMotivo = (Short) null;

			transProdSalida.TransProdDetalle.add(transProdDetalle);

			// actualizar inventario (no envia motivo)
			//Log.d("CambiosProducto", "Actualizar inventario " + (transProdSalida.TipoMovimiento == 1 ? "entrada" : "salida") + ", Producto: " + transProdDetalle.ProductoClave + ", Cantidad: " + transProdDetalle.Cantidad);
			//actualizarInventario(transProdDetalle, transProdSalida.TipoMovimiento);
			//actualizarInventarioSinMotivo(transProdDetalle, transProdSalida.TipoMovimiento);
			BDVend.guardarInsertar(transProdDetalle);
			return transProdDetalle;
		}
		catch (Exception ex)
		{
			mVista.mostrarError(ex.getMessage() == null ? ex.getCause().getMessage() : ex.getMessage());
			return null;
		}
	}

	public boolean eliminarMovimiento()
	{
		try
		{	
			HashMap<Short,Float> saldoReversa = new HashMap<Short, Float>();
            Short clasificacion = 0;
			for (TransProdDetalle tpd : transProdGeneral.TransProdDetalle)
			{
				if (ValoresReferencia.getValor("TRPMOT",tpd.TipoMotivo.toString()).getGrupo().equalsIgnoreCase("Caducidad"))
				{
                    clasificacion =  Consultas.ConsultasProducto.obtenerClasificacionProducto(tpd.ProductoClave);
                    if (saldoReversa.containsKey(clasificacion)){
                        saldoReversa.put(clasificacion, saldoReversa.get(clasificacion) + tpd.Subtotal);
                    }else{
                        saldoReversa.put(clasificacion, tpd.Subtotal) ;
                    }
				}		
				// actualizar tipo motivo transaccion
				TransaccionesDetalle.ActualizarTipoMotivoTransaccion(tpd, tpd.TipoMotivo,  moduloMovDetalle.TipoTransProd, Float.valueOf(0), true);				
			}

            if (mVista.getSaldoCambiosVendedor() != null && mVista.getSaldoCambiosVendedor().size()>0 ) { //Si se esta manejando un saldo de cambios
                Iterator it = mVista.getSaldoCambiosVendedor().entrySet().iterator();
                while (it.hasNext()) {
                    Map.Entry<Short,SaldoCambiosVendedor> e = (Map.Entry<Short,SaldoCambiosVendedor>) it.next();
                    if (saldoReversa.containsKey(e.getKey())) {
                        mVista.getSaldoCambiosVendedor().get(e.getKey()).SaldoUsado -= saldoReversa.get(e.getKey());
                        BDVend.guardarInsertar(mVista.getSaldoCambiosVendedor().get(e.getKey()));
                    }
                }
            }
			
			recuperarTransProdIdSalida();

			for (TransProdDetalle tpd : transProdSalida.TransProdDetalle)
			{
				Inventario.ActualizarInventario(tpd.ProductoClave, tpd.TipoUnidad, tpd.Cantidad, moduloMovDetalle.TipoTransProd, TiposMovimientos.SALIDA, ((Vendedor)Sesion.get(Campo.VendedorActual)).AlmacenID, true);
			}

			TransaccionesDetalle.EliminarDetalle(transProdGeneral.TransProdID);
			BDVend.eliminar(transProdGeneral);

			TransaccionesDetalle.EliminarDetalle(transProdSalida.TransProdID);
			BDVend.eliminar(transProdSalida);
			return true;
		}
		catch (Exception e)
		{
			mVista.mostrarError(e.getMessage());
			return false;
		}
	}

	public boolean actualizarMotivo(TransProdDetalle tpd, short motivo)
	{
		try
		{
				TransProdDetalle res;
				// actualizar tipo motivo (salida)
				res = TransaccionesDetalle.ActualizarTipoMotivoTransaccion(tpd, tpd.TipoMotivo, moduloMovDetalle.TipoTransProd, Float.valueOf(0), true); //salida
				if (res == null) return false;
				// actualizar tipo motivo (entrada)
				tpd = TransaccionesDetalle.ActualizarTipoMotivoTransaccion(tpd, motivo,  moduloMovDetalle.TipoTransProd, tpd.Cantidad, false);

				boolean refrescar = false;
				//recorrer todos los detalle para actualizar los que tengan motivo no definido
				for (TransProdDetalle tpd1 : getTransProd().TransProdDetalle)
				{
					if (tpd1.TipoMotivo == 0)
					{
						// actualizar tipo motivo (salida)
						TransProdDetalle otpd = TransaccionesDetalle.ActualizarTipoMotivoTransaccion(tpd1, tpd1.TipoMotivo,  moduloMovDetalle.TipoTransProd, Float.valueOf(0), true); //salida
						// actualizar tipo motivo (entrada)
						otpd = TransaccionesDetalle.ActualizarTipoMotivoTransaccion(tpd1, motivo, moduloMovDetalle.TipoTransProd, tpd1.Cantidad, false);
						BDVend.guardarInsertar(otpd);
						refrescar = true;
					}
				}
				if (refrescar)
					mVista.refrescarProductos(getTransaccionesIds());

			mVista.setTipoMotivo(motivo);
			mVista.setHuboCambios(true);
			BDVend.guardarInsertar(tpd);
			
			return true;
		}
		catch (Exception e)
		{
			mVista.mostrarError(e.getMessage());
		}
		return false;
	}

	private List<Map<String, String>> generarDocsAImprimir()
	{
		//String lstTrpTipo = ValoresReferencia.getStringVAVClave("TRPTIPO", "Visita");

		/*ISetDatos datos = Consultas.ConsultasTransProd.obtenerTransProdAImprimir(lstTrpTipo,
				Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()),
				((Cliente) Sesion.get(Campo.ClienteActual)).ClienteClave,
				((Visita) Sesion.get(Campo.VisitaActual)).VisitaClave,
				((Visita) Sesion.get(Campo.VisitaActual)).DiaClave,
				//transacciones.toString().replace("[", "'").replace("]", "'").replace(", ", "','"));
				"'" + transProdGeneral.TransProdID + "','" + transProdSalida.TransProdID + "'");*/
		ISetDatos datos = Consultas.ConsultasTransProd.obtenerTransProdAImprimir("'" + transProdGeneral.TransProdID + "','" + transProdSalida.TransProdID + "'");
		Cursor c = (Cursor) datos.getOriginal();

		List<Map<String, String>> tabla = new ArrayList<Map<String, String>>();
		Map<String, String> registro;
		String descValor = "";
		while (c.moveToNext())
		{
			registro = new HashMap<String, String>();
			for (int i = 0; i < c.getColumnCount(); i++)
			{
				registro.put(c.getColumnName(i), c.getString(i));
			}
			NumberFormat numberFormat = new DecimalFormat("$#,##0.00");
			registro.put("Total", numberFormat.format(c.getDouble(c.getColumnIndex("Total"))));
			descValor = ValoresReferencia.getDescripcion(c.getString(c.getColumnIndex("VARCodigo")), c.getString(c.getColumnIndex("Tipo")));
			registro.put("DescTipo", descValor);
			registro.put("TipoRecibo", obtenerTipoRecibo(registro));
			tabla.add(registro);
		}

		datos.close();

		//aTransProdIds.toString().replace("[", "'").replace("]", "'").replace(", ", "','")
		return tabla;
	}

	private String obtenerTipoRecibo(Map<String, String> registro)
	{
		String tipoRecibo = "0";

		int tipo = Integer.parseInt(registro.get("Tipo"));
		if (registro.get("TipoRecibo").equals("TRP"))
		{
			if ((tipo == 3 && !registro.get("TipoFase").equals(3)) || (tipo != 3))
			{
				switch (tipo)
				{
					case 8:
						if (registro.get("FacElec").equals(1))
						{
							return "24"; // Facturacion Electronica
						}
						else
						{
							return "8"; // Facturacion
						}
					case 24:
						if (registro.get("TipoFase").equals(6))
						{
							return "26"; //Liquidacion
						}
						else
						{
							return "25"; //Consignación
						}
					case 1:
						if (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.VENTA)
						{
							return "1";
						}
						else if (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.PREVENTA)
						{
							return "27";
						}
						else if (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO)
						{
							return "28";
						}
					default:
						return registro.get("Tipo");
				}
			}
		}
		else if (registro.get("TipoRecibo").equals("ABN"))
		{
			return "10"; // Recibo de cobranza
		}
		return tipoRecibo;
	}

	public void imprimirTicket()
	{
		try
		{
			Recibos recibo = new Recibos();

            short numImpresiones = 0;
            try {
                if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).existeParametro("NumImpresiones", Sesion.get(Campo.ModuloMovDetalleClave).toString())) {
                    numImpresiones = Short.parseShort (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("NumImpresiones", Sesion.get(Campo.ModuloMovDetalleClave).toString()).toString());
                }
            }catch (Exception ex){
                mVista.mostrarError("Error al recuperar el parámetro NumImpresiones");
                numImpresiones = 0;
            }

			recibo.imprimirRecibos(generarDocsAImprimir(), false, mVista, numImpresiones);
		}
		catch (ControlError e)
		{
			mVista.mostrarError(e.getMessage());
		}
		catch (Exception e)
		{
			mVista.mostrarError(e.getMessage());
		}
	}

	public String consultarUnidadProductoExistente(String TransProdID, String ProductoClave)
	{
		String Cantidad = "0";
		String[] transProdID = TransProdID.split(",");
		try
		{
			for (int a = 0; a < transProdID.length; a++)
			{
				ISetDatos mManejo = ConsultasCantidad.OptenerCantidad(transProdID[a], ProductoClave);
				if (mManejo.getCount() != 0)
				{
					mManejo.moveToFirst();
					Cantidad = mManejo.getString(0);
				}
			}

		}
		catch (Exception e)
		{
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		return Cantidad;
	}
}
