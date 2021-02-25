package com.amesol.routelite.presentadores.act;

import java.text.DecimalFormat;
import java.text.NumberFormat;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.Iterator;
import java.util.List;
import java.util.Map;

import android.database.Cursor;

import com.amesol.routelite.actividades.Enumeradores.Inventario.TiposValidacionInventario;
import com.amesol.routelite.actividades.Folios;
import com.amesol.routelite.actividades.Inventario;
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.actividades.Recibos;
import com.amesol.routelite.actividades.Transacciones;
import com.amesol.routelite.actividades.TransaccionesDetalle;
import com.amesol.routelite.actividades.ValoresReferencia;
import com.amesol.routelite.datos.Dia;
import com.amesol.routelite.datos.ModuloMovDetalle;
import com.amesol.routelite.datos.Producto;
import com.amesol.routelite.datos.Ruta;
import com.amesol.routelite.datos.TransProd;
import com.amesol.routelite.datos.TransProdDetalle;
import com.amesol.routelite.datos.Vendedor;
import com.amesol.routelite.datos.basedatos.BDVend;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.basedatos.Consultas.ConsultasCantidad;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.ConfigParametro;
import com.amesol.routelite.datos.utilerias.MOTConfiguracion;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.Presentador;
import com.amesol.routelite.presentadores.interfaces.ICapturaMovSinInventario;
import com.amesol.routelite.utilerias.ControlError;

public class CapturarMovSinInventario extends Presentador
{
	private ICapturaMovSinInventario mVista;
	String mAccion;
	String sClienteClave;
	//String sUsuarioID;
	//String sDiaClave;
	TransProd transProdGeneral;
	ModuloMovDetalle moduloMovDetalle;
	Producto oProducto;
	HashMap<String, TransProd> transacciones = new HashMap<String, TransProd>(); //array para manejar todos los ids que genere la transaccion por las diferentes subempresas
	boolean bEsNuevo;
	Vendedor vendedor;
	boolean bEsSugerido;
	boolean validarExistencia = false;
	int tipoValidacionExistencia;

	public CapturarMovSinInventario(ICapturaMovSinInventario vista, String accion)
	{
		mVista = vista;
		mAccion = accion;
	}

	@Override
	public void iniciar()
	{
		try
		{
			mVista.iniciar();

			vendedor = (Vendedor) Sesion.get(Campo.VendedorActual);

			String sModuloMovDetalleClave = (String) Sesion.get(Campo.ModuloMovDetalleClave);
			moduloMovDetalle = new ModuloMovDetalle();
			moduloMovDetalle.ModuloMovDetalleClave = sModuloMovDetalleClave;
			BDVend.recuperar(moduloMovDetalle);

			if (transacciones.size() == 1)
			{ //se paso como parametro un TransProdId, cargar el pedido
				bEsNuevo = false;
				bEsSugerido = false;
				transProdGeneral = (TransProd) transacciones.values().toArray()[0];
				BDVend.recuperar(transProdGeneral, TransProdDetalle.class);
				mVista.setTipoMotivo(transProdGeneral.TipoMotivo);
			}
			else
			{ //generar uno nuevo
				bEsNuevo = true;
				StringBuilder byRefMensaje = new StringBuilder();
				transProdGeneral = Transacciones.Inventario.generarMovSinVista(moduloMovDetalle, byRefMensaje);
				if (byRefMensaje.length() >0){
					mVista.mostrarAdvertencia(byRefMensaje.toString());
				}
				byRefMensaje = null;
				mVista.setFolio(transProdGeneral.Folio);
				mVista.setFecha(new SimpleDateFormat("dd/MM/yyyy").format(transProdGeneral.FechaCaptura));

				BDVend.guardarInsertar(transProdGeneral);

				//agregar el transprodId al array
				transacciones.put("MovSinVisita", transProdGeneral);

			}

		}
		catch (Exception e)
		{
			mVista.mostrarError(e.getMessage());
		}

	}

	public String getTransProdIds()
	{
		String TransProdIds = "";

		Iterator it = transacciones.entrySet().iterator();
		while (it.hasNext())
		{
			Map.Entry e = (Map.Entry) it.next();
			TransProdIds += "'" + ((TransProd) e.getValue()).TransProdID + "',";
		}
		if (TransProdIds.length() > 0)
		{
			TransProdIds = TransProdIds.substring(0, TransProdIds.length() - 1);
		}
		return TransProdIds;
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

	public String getTransaccionesIds()
	{
		String Ids = "";
		for (final Object transProd : transacciones.values().toArray())
		{
			Ids = (((TransProd) transProd).TransProdID);
		}
		return Ids;
	}

	public short getTipoFase()
	{
		return transProdGeneral.TipoFase;
	}

	public int getTipoValidacionExistencia()
	{
		return tipoValidacionExistencia;
	}

	public String getListasPrecios()
	{
		return transProdGeneral.CadenaListasPrecios;
	}

	public boolean getEsNuevo()
	{
		return bEsNuevo;
	}

	public ModuloMovDetalle getModuloMovDetalle()
	{
		return moduloMovDetalle;
	}

	public int getTipoIndiceModuloMovDetalle()
	{
		return moduloMovDetalle.TipoIndice;
	}

	public void agregarProductoUnidad(String productoClave, int TipoUnidad, Float Cantidad, Short Motivo)
	{
		generarDetalle(productoClave, TipoUnidad, Cantidad, Motivo);
	}

	public void agregarProductoUnidad(TransProdDetalle transProdDetalle, boolean refrescarListado, Short Motivo)
	{
		generarDetalle(transProdDetalle, refrescarListado, Motivo);
	}

	public void agregarTransaccion(String transProdId) throws Exception
	{
		TransProd trp = Transacciones.Pedidos.ObtenerPedido(transProdId);
		transacciones.put("MovSinVisita", trp);
	}

	private void generarDetalle(String productoClave, int TipoUnidad, Float Cantidad, Short Motivo)
	{
		try
		{

			StringBuilder byRefMensaje = new StringBuilder();
			transProdGeneral = Transacciones.Pedidos.ActualizarGenerarPedido(getTransaccionesIds(), moduloMovDetalle, byRefMensaje, Motivo);
			if (byRefMensaje.length() >0){
				mVista.mostrarAdvertencia(byRefMensaje.toString());
			}
			byRefMensaje= null;
			//validar si se genero un nuevo encabezado para agregar al array
			transacciones.put("MovSinVisita", transProdGeneral);
			BDVend.guardarInsertar(transProdGeneral);

			TransProdDetalle transProdDetalle = TransaccionesDetalle.Pedidos.GenerarDetallePedido(transProdGeneral.TransProdID, productoClave, TipoUnidad, Cantidad, Motivo);
			if (tipoValidacionExistencia != TiposValidacionInventario.NoValidar)
			{
				Inventario.ActualizarInventario(productoClave, TipoUnidad, Cantidad, moduloMovDetalle.TipoTransProd, moduloMovDetalle.TipoMovimiento, vendedor.AlmacenID);
			}

			if (transProdDetalle == null)
				throw new ControlError("MDB042302");
			else
			{
				BDVend.guardarInsertar(transProdDetalle);
				mVista.setHuboCambios(true);
				mVista.refrescarProductos(transProdGeneral.TransProdID);
				//mVista.setLimpiarMotivo();
				//posicionar la lista en el producto que se agrego para capturar cantidad
				//mVista.seleccionarProducto(productoClave, String.valueOf(TipoUnidad));
			}

		}
		catch (Exception ex)
		{
			mVista.mostrarError(ex.getMessage() == null ? ex.getCause().getMessage() : ex.getMessage());
		}

	}

	private void generarDetalle(TransProdDetalle transProdDetalle, boolean refrescarListado, Short Motivo)
	{
		try
		{
			StringBuilder byRefMensaje = new StringBuilder();

			transProdGeneral = Transacciones.Pedidos.ActualizarGenerarPedido(getTransaccionesIds(), moduloMovDetalle, byRefMensaje, Motivo);
			if (byRefMensaje.length() >0){
				mVista.mostrarAdvertencia(byRefMensaje.toString());
			}
			byRefMensaje = null;
			//validar si se genero un nuevo encabezado para agregar al array
			transacciones.put("MovSinVisita", transProdGeneral);

			BDVend.guardarInsertar(transProdGeneral);

			transProdDetalle.TransProdID = transProdGeneral.TransProdID;
			transProdDetalle = TransaccionesDetalle.Pedidos.GenerarDetallePedido(transProdDetalle);

			if (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.VENTA || (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.PREVENTA && ((Ruta) Sesion.get(Campo.RutaActual)).Inventario))
			{
				Inventario.ActualizarInventario(transProdDetalle.ProductoClave, transProdDetalle.TipoUnidad, transProdDetalle.Cantidad, moduloMovDetalle.TipoTransProd, moduloMovDetalle.TipoMovimiento, vendedor.AlmacenID);
			}

			if (transProdDetalle == null)
				throw new ControlError("MDB042302");
			else
			{
				BDVend.guardarInsertar(transProdDetalle);
				mVista.setHuboCambios(true);
				if (refrescarListado)
				{
					mVista.refrescarProductos(getTransaccionesIds());
				}
			}

		}
		catch (Exception ex)
		{
			mVista.mostrarError(ex.getMessage() == null ? ex.getCause().getMessage() : ex.getMessage());
		}

	}

	public void eliminarDetalle(String transProdId, String transProdDetalleId, String productoClave, float Cantidad)
	{
		try
		{
			TransaccionesDetalle.Pedidos.EliminarDetalleSinMov(transProdId, transProdDetalleId);
			mVista.setHuboCambios(true);

			mVista.refrescarProductos(getTransaccionesIds());
		}
		catch (Exception e)
		{
			mVista.mostrarError(e.getMessage());
		}
	}

public void eliminarMovimiento(){
	try{
		try{
		
			for (final Object transProd : transacciones.values().toArray())
			{
				TransaccionesDetalle.Pedidos.EliminarDetalleSinMovPedido(((TransProd) transProd).TransProdID);
				
			}
		}catch (Exception ex){
				mVista.mostrarError(ex.getMessage());
				BDVend.rollback();
				return;
		}
		BDVend.commit();
	}catch(Exception ex){
		mVista.mostrarError(ex.getMessage());
	}
}
	
	public void asignarGuardarValores() throws Exception
	{

		MOTConfiguracion motConfig = (MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion);
		if (mVista.getTipoMotivo() !=null){
			transProdGeneral.TipoMotivo = mVista.getTipoMotivo();
		}
		BDVend.guardarInsertar(transProdGeneral);
		Folios.confirmar(Sesion.get(Campo.ModuloMovDetalleClave).toString());
		BDVend.commit();

		if (motConfig.get("MensajeImpresion").equals("1"))
		{
			mVista.mostrarPreguntaSiNo(Mensajes.get("P0103"), 8);
		}else if (motConfig.get("MensajeImpresion").equals("2")){
            mVista.mostrarToast(Mensajes.get("E0934"));
            mVista.setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
            mVista.finalizar();
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

	public void imprimirTicket() 
	{
		try{
			Recibos recibo = new Recibos();
            short numImpresiones = 0;
            try {
                if (((ConfigParametro) Sesion.get(Sesion.Campo.ConfigParametro)).existeParametro("NumImpresiones", Sesion.get(Sesion.Campo.ModuloMovDetalleClave).toString())) {
                    numImpresiones = Short.parseShort (((ConfigParametro) Sesion.get(Sesion.Campo.ConfigParametro)).get("NumImpresiones", Sesion.get(Sesion.Campo.ModuloMovDetalleClave).toString()).toString());
                }
            }catch (Exception ex){
                mVista.mostrarError("Error al recuperar el parámetro NumImpresiones");
                numImpresiones = 0;
            }
			recibo.imprimirRecibos(generarDocsAImprimir(), false, mVista, numImpresiones);
		}catch (ControlError e)
		{
			mVista.mostrarError(e.getMessage());
		}
		catch (Exception e)
		{
			mVista.mostrarError(e.getMessage());
		}
	}

	public List<Map<String, String>> generarDocsAImprimir()
	{
		String lstTrpTipo = ValoresReferencia.getStringVAVClave("TRPTIPO", "No Visita");

		ISetDatos datos = Consultas.ConsultasTransProd.obtenerTransProdAImprimirMovInventario(lstTrpTipo, ((Dia) Sesion.get(Campo.DiaActual)).DiaClave, getTransaccionesIds());
		if (datos == null){
			return null;
		}
		if (datos.getCount() <=0) {			
			datos.close();
			return null;
		}
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

		// aTransProdIds.toString().replace("[", "'").replace("]",
		// "'").replace(", ", "','")
		return tabla;
	}

	public String obtenerTipoRecibo(Map<String, String> registro)
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
							return "26"; // Liquidacion
						}
						else
						{
							return "25"; // Consignación
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

}
