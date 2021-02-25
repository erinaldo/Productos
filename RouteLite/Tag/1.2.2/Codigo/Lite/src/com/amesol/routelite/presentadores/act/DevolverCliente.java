package com.amesol.routelite.presentadores.act;

import java.text.DecimalFormat;
import java.text.NumberFormat;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.concurrent.atomic.AtomicReference;

import android.database.Cursor;
import android.util.Log;

import com.amesol.routelite.actividades.Inventario;
import com.amesol.routelite.actividades.ListaPrecio;
import com.amesol.routelite.actividades.Recibos;
import com.amesol.routelite.actividades.Transacciones;
import com.amesol.routelite.actividades.TransaccionesDetalle;
import com.amesol.routelite.actividades.ValoresReferencia;
import com.amesol.routelite.datos.Cliente;
import com.amesol.routelite.datos.ModuloMovDetalle;
import com.amesol.routelite.datos.Precio;
import com.amesol.routelite.datos.Producto;
import com.amesol.routelite.datos.TransProd;
import com.amesol.routelite.datos.TransProdDetalle;
import com.amesol.routelite.datos.Visita;
import com.amesol.routelite.datos.basedatos.BDVend;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.basedatos.Consultas.ConsultasCantidad;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.CONHist;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.Presentador;
import com.amesol.routelite.presentadores.interfaces.IDevolucionCliente;
import com.amesol.routelite.utilerias.ControlError;

public class DevolverCliente extends Presentador
{

	IDevolucionCliente mVista;
	String mAccion;
	TransProd transProdGeneral;
	ModuloMovDetalle moduloMovDetalle;
	CONHist oConHist;
	String sClienteClave;
	HashMap<String, TransProd> transacciones = new HashMap<String, TransProd>();

	public DevolverCliente(IDevolucionCliente vista, String accion)
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
		if (transProdGeneral != null)
		{
			mVista.setFolio(transProdGeneral.Folio);
			mVista.setFecha(new SimpleDateFormat("dd/MM/yyyy").format(transProdGeneral.FechaCaptura));
			mVista.setListaPrecio(transProdGeneral.ListaPrecios.Nombre);
			if (!mVista.getEsNuevo())
				mVista.setFactura(transProdGeneral.Notas);
		}
	}

	public void guardarNotas(String notas)
	{
		try
		{
			transProdGeneral.Notas = notas;
			BDVend.guardarInsertar(transProdGeneral);
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
			if (byRefMensaje.length()>0){
				mVista.mostrarAdvertencia(byRefMensaje.toString());
			}
			byRefMensaje = null;
			transProdGeneral.CFVTipo = (Short) null;
			transProdGeneral.ClienteClave = null;

			transProdGeneral.TipoPedido = (Short) null;
			transProdGeneral.SubTDetalle = (Float) null;
			transProdGeneral.DescVendPor = (Float) null;
			transProdGeneral.DescuentoVendedor = (Float) null;
			transProdGeneral.DescuentoImp = (Float) null;
			transProdGeneral.Subtotal = (Float) null;
			transProdGeneral.Impuesto = (Float) null;
			transProdGeneral.Promocion = (Boolean) null;
			transProdGeneral.Descuento = (Boolean) null;
			transProdGeneral.TipoTurno = (Short) null;
			transProdGeneral.DiasCredito = (Short) null;

			/*
			 * Calendar cal = Calendar.getInstance();
			 * cal.setTime(Generales.getFechaActual()); cal.add(Calendar.DATE,
			 * Integer.parseInt(oConHist.get("DiasSurtido").toString()));
			 */
			transProdGeneral.FechaEntrega = null;

			transProdGeneral.FechaCobranza = null;
			transProdGeneral.FechaFacturacion = null;
			transProdGeneral.FechaSurtido = null;
			transProdGeneral.FechaCancelacion = null;

			BDVend.recuperar(transProdGeneral, TransProdDetalle.class);
			transacciones.put(transProdGeneral.SubEmpresaId, transProdGeneral);
			mVista.setParametrosCaptura(transProdGeneral.PCEPrecioClave, getTransaccionesIds());
			BDVend.guardarInsertar(transProdGeneral);
	}

	public void recuperarTransProd(String transProdID)
	{
		try
		{
			//if(mAccion.equals(Enumeradores.Acciones.ACCION_CAMBIOS_PRODUCTO_ENTRADA)){
			Precio oPrecio = ListaPrecio.Determinar(sClienteClave, moduloMovDetalle);
			transProdGeneral = new TransProd();
			transProdGeneral.TransProdID = transProdID;
			BDVend.recuperar(transProdGeneral);
			transProdGeneral.ListaPrecios = oPrecio;
			transProdGeneral.PCEPrecioClave = oPrecio.PrecioClave;
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
			/*
			 * }else if(mAccion.equals(Enumeradores.Acciones.
			 * ACCION_CAMBIAR_PRODUCTO_SALIDA)){ //obtener el transprod de
			 * sesion ArrayList<TransProd> otrp = (ArrayList<TransProd>)
			 * Sesion.get(Campo.ArrayTransProd); transProdGeneral = otrp.get(0);
			 * }
			 */

			transacciones.put(transProdGeneral.SubEmpresaId, transProdGeneral);
			mVista.setParametrosCaptura(transProdGeneral.PCEPrecioClave, getTransaccionesIds());
		}
		catch (Exception e)
		{
			mVista.mostrarError(e.getMessage());
		}
	}

	public TransProd getTransProd()
	{
		return transProdGeneral;
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

	public void obtenerTotales(String TransProdID)
	{
		try
		{
			//String res = "0";
			ISetDatos setDatos = Consultas.ConsultasTransProdDetalle.obtenerTotales(TransProdID);
			if (setDatos.moveToNext())
			{
				//res = setDatos.getString(1);
				mVista.setTotal(setDatos.getString(1) == null ? "0" : setDatos.getString(1));
				mVista.setProductosDev(setDatos.getString(0));
			}
			//mVista.startManagingCursor((Cursor) setDatos.getOriginal());
			setDatos.close();

			//return res == null ? "0" : res;
		}
		catch (Exception e)
		{
			//return "0";
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

	/*private void validarExistencia(String productoClave, Float cantidad, int tipoUnidad) throws Exception
	{
		//TODO: validar existencia
		Log.d("CambiosProducto", "Validar existencia, Producto: " + productoClave + ", Cantidad: " + cantidad);
		//si no hay existencia suficiente mostrar mensaje E0029 y asignar cantidad disponible
		AtomicReference<Float> existencia = null;
		StringBuilder error = null;
		boolean validar = Inventario.ValidarExistencia(productoClave, tipoUnidad, cantidad, Float.valueOf(0), transProdGeneral.TipoMovimiento, moduloMovDetalle.TipoTransProd, false, existencia, error);

	}*/

	public void actualizarCantidad(TransProdDetalle tpd, Float cantidad)
	{
		try
		{
			/*if (!tpd.recienAgregado)
			{
				validarExistencia(tpd.ProductoClave, tpd.Cantidad, tpd.TipoUnidad);
			}*/

			//cancelar inventario actual
			TransProdDetalle res;
			res = TransaccionesDetalle.ActualizarTipoMotivoTransaccion(tpd, tpd.TipoMotivo, moduloMovDetalle.TipoTransProd, cantidad, true);
			if (res == null) return;
			tpd.Cantidad = cantidad;
			tpd = TransaccionesDetalle.DevolucionesCliente.calcularTotales(tpd);
			//entrada
			TransaccionesDetalle.ActualizarTipoMotivoTransaccion(tpd, tpd.TipoMotivo, moduloMovDetalle.TipoTransProd,cantidad, false);

			BDVend.guardarInsertar(tpd);
			mVista.setHuboCambios(true);
			mVista.refrescarProductos(getTransaccionesIds());
		}
		catch (Exception e)
		{
			mVista.mostrarError(e.getMessage());
		}
	}

	public boolean actualizarMotivo(TransProdDetalle tpd, short motivo)
	{
		try
		{
			/*if (!tpd.recienAgregado)
			{
				validarExistencia(tpd.ProductoClave, tpd.Cantidad, tpd.TipoUnidad);
			}*/
			TransProdDetalle res;
			res = TransaccionesDetalle.ActualizarTipoMotivoTransaccion(tpd, tpd.TipoMotivo, moduloMovDetalle.TipoTransProd, Float.valueOf(0), true); //salida
			if (res == null) return false ;
			
			tpd = TransaccionesDetalle.ActualizarTipoMotivoTransaccion(tpd, motivo, moduloMovDetalle.TipoTransProd, tpd.Cantidad, false); //entrada
			
			
			boolean refrescar = false;
			//recorrer todos los detalle para actualizar los que tengan motivo no definido
			for (TransProdDetalle tpd1 : getTransProd().TransProdDetalle)
			{
				if (tpd1.TipoMotivo == 0)
				{
					// cancelar el inventario del motivo actual 
					TransProdDetalle otpd = TransaccionesDetalle.ActualizarTipoMotivoTransaccion(tpd1, tpd1.TipoMotivo, moduloMovDetalle.TipoTransProd, Float.valueOf(0), true); //salida
					// actualizar inventario con motivo nuevo
					otpd = TransaccionesDetalle.ActualizarTipoMotivoTransaccion(tpd1, motivo, moduloMovDetalle.TipoTransProd, tpd1.Cantidad,false);
					BDVend.guardarInsertar(otpd);
					refrescar = true;
				}
			}
			if (refrescar)
				mVista.refrescarProductos(getTransaccionesIds());

			mVista.setHuboCambios(true);
			mVista.setTipoMotivo(motivo);
			return true;
		}
		catch (Exception e)
		{
			mVista.mostrarError(e.getMessage());
		}
		return false;
	}

	public void agregarProductoUnidad(Producto producto, int TipoUnidad, Float Cantidad, short TipoMotivo)
	{
		try
		{
			TransProdDetalle oTpd = null;
			oTpd = generarDetalle(producto, TipoUnidad, Cantidad, TipoMotivo);
			if (oTpd != null)
			{
				oTpd = TransaccionesDetalle.ActualizarTipoMotivoTransaccion(oTpd, TipoMotivo,  moduloMovDetalle.TipoTransProd, oTpd.Cantidad, false); //entrada
				BDVend.guardarInsertar(oTpd);
				mVista.setHuboCambios(true);
				mVista.refrescarProductos(getTransaccionesIds());
			}
		}
		catch (Exception e)
		{
			mVista.mostrarError(e.getMessage());
		}
	}

	public void agregarProductoUnidad(Producto producto, TransProdDetalle transProdDetalle, short tipoMotivo)
	{
		agregarProductoUnidad(producto, transProdDetalle.TipoUnidad, transProdDetalle.Cantidad, tipoMotivo);
	}

	public void eliminarDetalle(TransProdDetalle tpd)
	{
		try
		{
			//cancelar inventario del detalle
			TransProdDetalle res;
			res = TransaccionesDetalle.ActualizarTipoMotivoTransaccion(tpd, tpd.TipoMotivo, moduloMovDetalle.TipoTransProd, Float.valueOf(0), true);
			if (res == null) return;
			Consultas.ConsultasTPDImpuesto.eliminarImpuestosPorDetalle(tpd.TransProdID, tpd.TransProdDetalleID);

			transProdGeneral.TransProdDetalle.remove(tpd);
			BDVend.eliminar(tpd);
			mVista.setHuboCambios(true);
			mVista.refrescarProductos(getTransaccionesIds());
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
			TransProdDetalle transProdDetalle = TransaccionesDetalle.DevolucionesCliente.GenerarDetalleDevolucion(transProdGeneral.TransProdID, producto.ProductoClave, TipoUnidad, Cantidad, 0, transProdGeneral.ListaPrecios.PrecioClave, !(Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.PREVENTA));
			if (transProdDetalle == null)
				throw new ControlError("MDB042302");

			transProdDetalle.producto = producto;
			transProdDetalle.recienAgregado = true;
			transProdDetalle.TipoMotivo = TipoMotivo;
			transProdGeneral.TransProdDetalle.add(transProdDetalle);

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
			for (TransProdDetalle tpd : transProdGeneral.TransProdDetalle)
			{
				// cancelar inventario				
				if (TransaccionesDetalle.ActualizarTipoMotivoTransaccion(tpd, tpd.TipoMotivo, moduloMovDetalle.TipoTransProd, Float.valueOf(0), true) == null){
					return false;
				}
			}

			Consultas.ConsultasTPDImpuesto.eliminarImpuestos(transProdGeneral.TransProdID);
			TransaccionesDetalle.EliminarDetalle(transProdGeneral.TransProdID);
			BDVend.eliminar(transProdGeneral);
			return true;

		}
		catch (Exception e)
		{
			mVista.mostrarError(e.getMessage());
			return false;
		}
	}

	public void imprimirTicket()
	{
		try
		{
			Recibos recibo = new Recibos();
			recibo.imprimirRecibos(generarDocsAImprimir(), false, mVista);
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

	private List<Map<String, String>> generarDocsAImprimir()
	{
		//String lstTrpTipo = ValoresReferencia.getStringVAVClave("TRPTIPO", "Visita");

		/*ISetDatos datos = Consultas.ConsultasTransProd.obtenerTransProdAImprimir(lstTrpTipo,
				Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()),
				((Cliente) Sesion.get(Campo.ClienteActual)).ClienteClave,
				((Visita) Sesion.get(Campo.VisitaActual)).VisitaClave,
				((Visita) Sesion.get(Campo.VisitaActual)).DiaClave,
				//transacciones.toString().replace("[", "'").replace("]", "'").replace(", ", "','"));
				"'" + transProdGeneral.TransProdID + "'");*/
		ISetDatos datos = Consultas.ConsultasTransProd.obtenerTransProdAImprimir("'" + transProdGeneral.TransProdID + "'");
		
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
