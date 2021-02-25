package com.amesol.routelite.presentadores.act;

import android.annotation.SuppressLint;
import android.database.Cursor;

import com.amesol.routelite.actividades.Enumeradores.Inventario.TiposValidacionInventario;
import com.amesol.routelite.actividades.Folios;
import com.amesol.routelite.actividades.Inventario;
import com.amesol.routelite.actividades.InventarioDobleUnidad;
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.actividades.Recibos;
import com.amesol.routelite.actividades.Transacciones;
import com.amesol.routelite.actividades.TransaccionesDetalle;
import com.amesol.routelite.actividades.ValorReferencia;
import com.amesol.routelite.actividades.ValoresReferencia;
import com.amesol.routelite.datos.Dia;
import com.amesol.routelite.datos.InventarioTraspaso;
import com.amesol.routelite.datos.ModuloMovDetalle;
import com.amesol.routelite.datos.Producto;
import com.amesol.routelite.datos.TRPVtaAcreditada;
import com.amesol.routelite.datos.TransProd;
import com.amesol.routelite.datos.TransProdDetalle;
import com.amesol.routelite.datos.Usuario;
import com.amesol.routelite.datos.Vendedor;
import com.amesol.routelite.datos.basedatos.BDVend;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.basedatos.Consultas.ConsultasCantidad;
import com.amesol.routelite.datos.basedatos.Consultas2;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.CONHist;
import com.amesol.routelite.datos.utilerias.ConfigParametro;
import com.amesol.routelite.datos.utilerias.MOTConfiguracion;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.Enumeradores.TiposMovimientos;
import com.amesol.routelite.presentadores.Presentador;
import com.amesol.routelite.presentadores.interfaces.ICapturaFirma;
import com.amesol.routelite.presentadores.interfaces.ICapturaMovConInventario;
import com.amesol.routelite.presentadores.interfaces.IDevolucionCliente;
import com.amesol.routelite.utilerias.ControlError;
import com.amesol.routelite.utilerias.Generales;
import com.amesol.routelite.utilerias.KeyGen;

import java.text.DecimalFormat;
import java.text.NumberFormat;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.Iterator;
import java.util.List;
import java.util.Map;

public class CapturarMovimientosConInventario extends Presentador
{

	private ICapturaMovConInventario mVista;
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
	boolean validarExistencia = false;
	int tipoValidacionExistencia = 0;

	//
	IDevolucionCliente mDev;
	CONHist oConHist;
	boolean bManejarInventario = true;
	String  sGrupoTipoMotivo = "";
	//

	public CapturarMovimientosConInventario(ICapturaMovConInventario vista, String accion)
	{
		mVista = vista;
		mAccion = accion;
	}

	@SuppressLint("SimpleDateFormat")
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
			if ((mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_AJUSTES)) || (mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_DESCARGA)) || (mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_DEVOLUCION)) || (mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_CARGAS)) || (mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_TRASPASO)))
			//if ((mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_AJUSTES)) || (mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_DESCARGA)) || (mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_DEVOLUCION)))
			{ //cargas no valida existencia
				tipoValidacionExistencia = TiposValidacionInventario.ValidacionRestrictiva;
			}
			if (transacciones.size() == 1)
			{ //se paso como parametro un TransProdId, cargar el pedido
				bEsNuevo = false;
				transProdGeneral = (TransProd) transacciones.values().toArray()[0];
				BDVend.recuperar(transProdGeneral, TransProdDetalle.class);
				if(transProdGeneral.TipoMotivo != 0)
					mVista.setMotivo(transProdGeneral.TipoMotivo);
				if((mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_DEVOLUCION)) || (mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_DESCARGA))){
					mVista.setFolio(transProdGeneral.Folio);
					mVista.setFecha(new SimpleDateFormat("dd/MM/yyyy").format(transProdGeneral.FechaCaptura));
				}
			}
			else
			{ //generar uno nuevo
				bEsNuevo = true;
				StringBuilder byRefMensaje = new StringBuilder();
				if ((mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_AJUSTES)))
				{
					transProdGeneral = Transacciones.Inventario.generarMovConInventario(moduloMovDetalle, 6, 2, byRefMensaje);
				}
				else if ((mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_DESCARGA)))
				{
					transProdGeneral = Transacciones.Inventario.generarMovConInventario(moduloMovDetalle, 7, 2, byRefMensaje);
				}
				else if ((mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_DEVOLUCION)))
				{
					transProdGeneral = Transacciones.Inventario.generarMovConInventario(moduloMovDetalle, 4, 2, byRefMensaje);
				}
				else if ((mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_CARGAS)))
				{
					transProdGeneral = Transacciones.Inventario.generarMovConInventario(moduloMovDetalle, 2, 2, byRefMensaje);

				}
				if (byRefMensaje.length() >0){
					mVista.mostrarAdvertencia(byRefMensaje.toString());
				}
				byRefMensaje = null;
				
				/*mVista.setFolio(transProdGeneral.Folio);
				mVista.setFecha(new SimpleDateFormat("dd/MM/yyyy").format(transProdGeneral.FechaCaptura));*/

				if(!(mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_TRASPASO))){
					BDVend.guardarInsertar(transProdGeneral);

					//agregar el transprodId al array
					transacciones.put("MovConVisita", transProdGeneral);
					
					mVista.setFolio(transProdGeneral.Folio);
					mVista.setFecha(new SimpleDateFormat("dd/MM/yyyy").format(transProdGeneral.FechaCaptura));
				}				

			}
		}
		catch (Exception e)
		{
			mVista.mostrarError(e.getMessage());
		}

	}

	@SuppressWarnings("rawtypes")
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
			mVista.mostrarError(e.getMessage());
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

	public String getPCEPrecioClave()
	{
		return transProdGeneral.PCEPrecioClave;
	}
	public int getTipoValidacionExistencia()
	{
		return tipoValidacionExistencia;
	}

	public ModuloMovDetalle getModuloMovDetalle()
	{
		return moduloMovDetalle;
	}

	public void eliminarTraspaso(String InventarioTraspasoID) throws Exception{
		InventarioTraspaso traspaso = new InventarioTraspaso();
		traspaso.InventarioTraspasoId = InventarioTraspasoID;
		BDVend.recuperar(traspaso);
		
		if (tipoValidacionExistencia != TiposValidacionInventario.NoValidar)
		{
			String grupoMotivoOrigen = "";
			String grupoMotivoDestino = "";
			//String grupoMotivo = "";
			if(traspaso.Origen == 1){
                grupoMotivoOrigen = "Venta";
                grupoMotivoDestino = "No Venta";
				//grupoMotivo = "No Venta";
				//Inventario.ActualizarInventario(traspaso.ProductoClave, traspaso.TipoUnidad, traspaso.Cantidad, 0, TiposMovimientos.ENTRADA, vendedor.AlmacenID, grupoMotivo, true);
			}
			else if (traspaso.Origen == 2){
                grupoMotivoOrigen = "No Venta";
                grupoMotivoDestino = "Venta";
				//grupoMotivo = "No Venta";
				//Inventario.ActualizarInventario(traspaso.ProductoClave, traspaso.TipoUnidad, traspaso.Cantidad, 0, TiposMovimientos.SALIDA, vendedor.AlmacenID, grupoMotivo, true);
			}
			Inventario.ActualizarInventario(traspaso.ProductoClave, traspaso.TipoUnidad, traspaso.Cantidad, 0, TiposMovimientos.SALIDA, vendedor.AlmacenID, grupoMotivoOrigen, true);
			Inventario.ActualizarInventario(traspaso.ProductoClave, traspaso.TipoUnidad, traspaso.Cantidad, 0, TiposMovimientos.ENTRADA, vendedor.AlmacenID, grupoMotivoDestino, true);
		}
		
		BDVend.eliminar(traspaso);
	}
	
	public void agregarProductoUnidadTraspaso(String productoClave, int TipoUnidad, Float Cantidad, int Motivo, int Origen, int Destino) throws Exception{
		InventarioTraspaso traspaso = new InventarioTraspaso();
		traspaso.InventarioTraspasoId = KeyGen.getId();
		traspaso.DiaClave = ((Dia)Sesion.get(Campo.DiaActual)).DiaClave;
		traspaso.VendedorId = ((com.amesol.routelite.datos.Vendedor)Sesion.get(Campo.VendedorActual)).VendedorId;
		traspaso.ProductoClave = productoClave;
		traspaso.TipoUnidad = TipoUnidad;
		traspaso.Cantidad = Cantidad;
		traspaso.TipoMotivo = Motivo;
		traspaso.Origen = Origen;
		traspaso.Destino = Destino;
		traspaso.MFechaHora = Generales.getFechaHoraActual();
		traspaso.MUsuarioID = ((com.amesol.routelite.datos.Usuario)Sesion.get(Campo.UsuarioActual)).USUId;
		traspaso.Enviado = false;
		if (tipoValidacionExistencia != TiposValidacionInventario.NoValidar)
		{
			String grupoMotivoOrigen = "";
			String grupoMotivoDestino = "";
			//String grupoMotivo = "";
			if(traspaso.Origen == 1){
				grupoMotivoOrigen = "Venta";
                grupoMotivoDestino = "No Venta";
				//grupoMotivo = "No Venta";
				//Inventario.ActualizarInventario(productoClave, TipoUnidad, Cantidad, 0, TiposMovimientos.ENTRADA, vendedor.AlmacenID, grupoMotivo, false);
			}
			else if (traspaso.Origen == 2){
				grupoMotivoOrigen = "No Venta";
				grupoMotivoDestino = "Venta";
                //grupoMotivo = "No Venta";
				//Inventario.ActualizarInventario(productoClave, TipoUnidad, Cantidad, 0, TiposMovimientos.SALIDA, vendedor.AlmacenID, grupoMotivo, false);
			}
			Inventario.ActualizarInventario(productoClave, TipoUnidad, Cantidad, 0, TiposMovimientos.SALIDA, vendedor.AlmacenID, grupoMotivoOrigen, false);
			Inventario.ActualizarInventario(productoClave, TipoUnidad, Cantidad, 0, TiposMovimientos.ENTRADA, vendedor.AlmacenID, grupoMotivoDestino, false);
		}
		BDVend.guardarInsertar(traspaso);
		mVista.refrescarProductos("");
	}

	public void agregarProductoUnidad(String productoClave, int TipoUnidad, Float Cantidad, Float CantidadOriginal, String Motivo)
	{
		generarDetalle(productoClave, TipoUnidad, Cantidad,CantidadOriginal, Motivo);
	}

	public void agregarProductoDobleUnidad(String productoClave, HashMap<Short, InventarioDobleUnidad.DetalleProductoDobleUnidad> hmDetalleUnidades, String Motivo)
	{
		generarDetalleDobleUnidad(productoClave, hmDetalleUnidades, Motivo);
	}

	public void agregarProductoUnidad(TransProdDetalle transProdDetalle, boolean refrescarListado)
	{
		generarDetalle(transProdDetalle, refrescarListado);
	}

	public void agregarTransaccion(String transProdId) throws Exception
	{
		TransProd trp = Transacciones.Pedidos.ObtenerPedido(transProdId);
		transacciones.put("MovConVisita", trp);
	}

	private void generarDetalle(String productoClave, int TipoUnidad, Float Cantidad, Float CantidadOriginal, String Motivo)
	{

		String byRefMensaje = "";
		try
		{
			transProdGeneral = Transacciones.Pedidos.ActualizarMovimientoInventario(getTransaccionesIds(), moduloMovDetalle, byRefMensaje, Integer.parseInt(Motivo), transProdGeneral);
			if (transProdGeneral.PCEPrecioClave == null || transProdGeneral.PCEPrecioClave.length()<=0){
				if (((Vendedor)Sesion.get(Campo.VendedorActual)).ListaPrecioBase != null) {
					transProdGeneral.PCEPrecioClave = ((Vendedor) Sesion.get(Campo.VendedorActual)).ListaPrecioBase;
					transProdGeneral.CadenaListasPrecios = "'" + transProdGeneral.PCEPrecioClave + "'";
				}
			}
			transacciones.put("MovConVisita", transProdGeneral);
			BDVend.guardarInsertar(transProdGeneral);
		}
		catch (Exception ex)
		{
			mVista.mostrarError(ex.getMessage() == null ? ex.getCause().getMessage() : ex.getMessage());
		}

		try
		{
			StringBuilder byRefError = new StringBuilder();
			TransProdDetalle transProdDetalle = TransaccionesDetalle.Pedidos.GenerarDetalleMovsGenerales(transProdGeneral.TransProdID, productoClave, TipoUnidad, Cantidad, null, transProdGeneral.CadenaListasPrecios, byRefError);
			if (CantidadOriginal != null && CantidadOriginal >0){
				transProdDetalle.CantidadOriginal = CantidadOriginal;
			}
			if ( byRefError.length()>0){
				mVista.mostrarAdvertencia(byRefError.toString());
			}
			if (tipoValidacionExistencia != TiposValidacionInventario.NoValidar)
			{
				boolean actualizarInventario = true;
				if ((mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_CARGAS) && mVista.getManejarConfirmarCarga()) || (mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_DESCARGA) && mVista.getConfirmaDescarga()) || (mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_DEVOLUCION) && mVista.getConfirmaDevAlmacen())){
					actualizarInventario = false;
				}
				if (actualizarInventario) {
					Inventario.ActualizarInventario(productoClave, TipoUnidad, Cantidad, moduloMovDetalle.TipoTransProd, moduloMovDetalle.TipoMovimiento, vendedor.AlmacenID);
				}
			}
			if (transProdDetalle == null)
				throw new ControlError("MDB042302");
			else
			{
				BDVend.guardarInsertar(transProdDetalle);
				mVista.refrescarProductos(transProdGeneral.TransProdID);
				/*if ((mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_AJUSTES)))
				{
					mVista.setLimpiarMotivo();
				}*/

				//posicionar la lista en el producto que se agrego para capturar cantidad
				//mVista.seleccionarProducto(productoClave, String.valueOf(TipoUnidad));
			}
		}
		catch (Exception ex)
		{
			mVista.mostrarError(ex.getMessage() == null ? ex.getCause().getMessage() : ex.getMessage());
		}

		//validar si se genero un nuevo encabezado para agregar al array

	}

	private void generarDetalleDobleUnidad(String productoClave, HashMap<Short, InventarioDobleUnidad.DetalleProductoDobleUnidad> hmDetalleUnidades, String Motivo)
	{

		String byRefMensaje = "";
		try
		{
			transProdGeneral = Transacciones.Pedidos.ActualizarMovimientoInventario(getTransaccionesIds(), moduloMovDetalle, byRefMensaje, Integer.parseInt(Motivo), transProdGeneral);
			if (transProdGeneral.PCEPrecioClave == null || transProdGeneral.PCEPrecioClave.length()<=0){
				if (((Vendedor)Sesion.get(Campo.VendedorActual)).ListaPrecioBase != null) {
					transProdGeneral.PCEPrecioClave = ((Vendedor) Sesion.get(Campo.VendedorActual)).ListaPrecioBase;
					transProdGeneral.CadenaListasPrecios = "'" + transProdGeneral.PCEPrecioClave + "'";
				}
			}
			transacciones.put("MovConVisita", transProdGeneral);
			BDVend.guardarInsertar(transProdGeneral);
		}
		catch (Exception ex)
		{
			mVista.mostrarError(ex.getMessage() == null ? ex.getCause().getMessage() : ex.getMessage());
		}

		try
		{
			StringBuilder byRefError = new StringBuilder();
			TransProdDetalle transProdDetalle = TransaccionesDetalle.Pedidos.GenerarDetalleMovsDobleUnidad(transProdGeneral.TransProdID, productoClave, hmDetalleUnidades, null, transProdGeneral.CadenaListasPrecios, byRefError);
			if ( byRefError.length()>0){
				mVista.mostrarAdvertencia(byRefError.toString());
			}
			if (tipoValidacionExistencia != TiposValidacionInventario.NoValidar)
			{
				InventarioDobleUnidad.ActualizarInventario(productoClave, hmDetalleUnidades, moduloMovDetalle.TipoTransProd, moduloMovDetalle.TipoMovimiento);
			}
			if (transProdDetalle == null)
				throw new ControlError("MDB042302");
			else
			{
				BDVend.guardarInsertar(transProdDetalle);
				mVista.refrescarProductos(transProdGeneral.TransProdID);
			}
		}
		catch (Exception ex)
		{
			mVista.mostrarError(ex.getMessage() == null ? ex.getCause().getMessage() : ex.getMessage());
		}

		//validar si se genero un nuevo encabezado para agregar al array

	}

	private void generarDetalle(TransProdDetalle transProdDetalle, boolean refrescarListado)
	{
		try
		{
			String byRefMensaje = "";

			transProdGeneral = Transacciones.Pedidos.ActualizarMovimientoInventario(getTransaccionesIds(), moduloMovDetalle, byRefMensaje, 0, transProdGeneral);
			if (transProdGeneral.PCEPrecioClave == null || transProdGeneral.PCEPrecioClave.length()<=0){
				if (((Vendedor)Sesion.get(Campo.VendedorActual)).ListaPrecioBase != null) {
					transProdGeneral.PCEPrecioClave = ((Vendedor) Sesion.get(Campo.VendedorActual)).ListaPrecioBase;
					transProdGeneral.CadenaListasPrecios = "'" + transProdGeneral.PCEPrecioClave + "'";
				}
			}
			transacciones.put("MovConVisita", transProdGeneral);

			BDVend.guardarInsertar(transProdGeneral);

			transProdDetalle.TransProdID = transProdGeneral.TransProdID;
			transProdDetalle = TransaccionesDetalle.Pedidos.GenerarDetalleMovGenerales(transProdDetalle, transProdGeneral.CadenaListasPrecios) ;
			if (tipoValidacionExistencia != TiposValidacionInventario.NoValidar)
			{
				boolean actualizarInventario = true;
				if ((mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_CARGAS) && mVista.getManejarConfirmarCarga()) || (mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_DESCARGA) && mVista.getConfirmaDescarga()) || (mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_DEVOLUCION) && mVista.getConfirmaDevAlmacen())){
					actualizarInventario = false;
				}
				if (actualizarInventario) {
					Inventario.ActualizarInventario(transProdDetalle.ProductoClave, transProdDetalle.TipoUnidad, transProdDetalle.Cantidad, moduloMovDetalle.TipoTransProd, moduloMovDetalle.TipoMovimiento, vendedor.AlmacenID);
				}
			}

			if (transProdDetalle == null)
				throw new ControlError("MDB042302");
			BDVend.guardarInsertar(transProdDetalle);
			mVista.refrescarProductos(getTransaccionesIds());

		}
		catch (Exception ex)
		{
			mVista.mostrarError(ex.getMessage() == null ? ex.getCause().getMessage() : ex.getMessage());
		}

	}

	public void eliminarDetalle(String transProdId, int TipoUnidad, String transProdDetalleId, String productoClave, float Cantidad)
	{
		try
		{
			TransaccionesDetalle.Pedidos.EliminarDetalleSinMov(transProdId, transProdDetalleId);
			if (tipoValidacionExistencia != TiposValidacionInventario.NoValidar)
			{
				boolean actualizarInventario = true;
				if ((mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_CARGAS) && mVista.getManejarConfirmarCarga()) || (mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_DESCARGA) && mVista.getConfirmaDescarga()) || (mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_DEVOLUCION) && mVista.getConfirmaDevAlmacen())){
					actualizarInventario = false;
				}
				if (actualizarInventario){
					Inventario.ActualizarInventario(productoClave, TipoUnidad, Cantidad, moduloMovDetalle.TipoTransProd, moduloMovDetalle.TipoMovimiento, vendedor.AlmacenID, true);
				}
			}
			mVista.refrescarProductos(getTransaccionesIds());
		}
		catch (Exception e)
		{
			mVista.mostrarError(e.getMessage());
		}
	}

	public void eliminarDetalleDobleUnidad(String transProdId, String transProdDetalleId, String productoClave, HashMap<Short,InventarioDobleUnidad.DetalleProductoDobleUnidad>hmDetalleUnidades)
	{
		try
		{
			TransaccionesDetalle.Pedidos.EliminarDetalleSinMovDobleUnidad(transProdId, transProdDetalleId);
			if (tipoValidacionExistencia != TiposValidacionInventario.NoValidar)
			{
				InventarioDobleUnidad.ActualizarInventario(productoClave, hmDetalleUnidades, moduloMovDetalle.TipoTransProd, moduloMovDetalle.TipoMovimiento, true);
			}
			mVista.refrescarProductos(getTransaccionesIds());
		}
		catch (Exception e)
		{
			mVista.mostrarError(e.getMessage());
		}
	}

	public void asignarGuardarValores(String sNombre, String sNombreArchivo) throws Exception
	{
        String idCarga;
		if ((mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_AJUSTES))){
			for(TransProd trp : transacciones.values()){
				BDVend.recuperar(trp);
				trp.TipoMotivo = mVista.getMotivo();
                if( mVista.esTraspasoRuta() ){
                    if(trp.FacturaID != null && trp.FacturaID != ""){
                        idCarga = trp.FacturaID;
                    }else {
                        idCarga = KeyGen.getId();
                        trp.FacturaID = idCarga;
                    }
                    trp.Notas = mVista.getDestino();
                }
				if(trp.PCEPrecioClave != null && trp.PCEPrecioClave.length()>0) {
					Transacciones.calcularTotalesTransaccion(trp);
				}
				BDVend.guardarInsertar(trp);

                if (!sNombre.equals("") && !sNombreArchivo.equals("")) {
                    TRPVtaAcreditada firmaDigital = new TRPVtaAcreditada();
                    firmaDigital.TransProdID = trp.TransProdID;
                    BDVend.recuperar(firmaDigital);
                    firmaDigital.NombreFirma = sNombre;
                    firmaDigital.IdImagenFirma = sNombreArchivo;
                    firmaDigital.MFechaHora = Generales.getFechaHoraActual();
                    firmaDigital.MUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;
                    firmaDigital.Enviado = false;
                    BDVend.guardarInsertar(firmaDigital);
                }
			}	
		}else{
            if (transProdGeneral != null) {
                if (transProdGeneral.PCEPrecioClave != null && transProdGeneral.PCEPrecioClave.length() > 0) {
                    Transacciones.calcularTotalesTransaccion(transProdGeneral);
                }
				if ((mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_CARGAS) && mVista.getManejarConfirmarCarga()) || (mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_DESCARGA) && mVista.getConfirmaDescarga()) || (mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_DEVOLUCION) && mVista.getConfirmaDevAlmacen())){
					if ( !mVista.getConfirmando()){
						transProdGeneral.TipoFase = 15;
					}else{
						transProdGeneral.TipoFase = 1;
					}
					//Fase Por Confirmar

				}
                BDVend.guardarInsertar(transProdGeneral);
            }
		}

		if (!(mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_TRASPASO))){
			MOTConfiguracion motConfig = (MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion);

			Folios.confirmar(Sesion.get(Campo.ModuloMovDetalleClave).toString());

            if (!mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_AJUSTES))
            {
                if (!sNombre.equals("") && !sNombreArchivo.equals("")) {
                    TRPVtaAcreditada firmaDigital = new TRPVtaAcreditada();
                    firmaDigital.TransProdID = transProdGeneral.TransProdID;
                    BDVend.recuperar(firmaDigital);
                    firmaDigital.NombreFirma = sNombre;
                    firmaDigital.IdImagenFirma = sNombreArchivo;
                    firmaDigital.MFechaHora = Generales.getFechaHoraActual();
                    firmaDigital.MUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;
                    firmaDigital.Enviado = false;
                    BDVend.guardarInsertar(firmaDigital);
                }
            }

			BDVend.commit();

			if (motConfig.get("MensajeImpresion").equals("1"))
			{
				mVista.mostrarPreguntaSiNo(Mensajes.get("P0103"), 8);
			}else if (motConfig.get("MensajeImpresion").equals("2")){
                mVista.mostrarToast(Mensajes.get("E0934"));
                mVista.setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
                mVista.finalizar();
            }
		}else if ((mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_TRASPASO))){
			BDVend.commit();
			mVista.finalizar();
		}
	}

	public void imprimirTicket() throws Exception
	{
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
		recibo.imprimirRecibos(generarDocsAImprimir(), true, mVista, numImpresiones);

	}

	public List<Map<String, String>> generarDocsAImprimir()
	{

		ISetDatos datos = null;

		if ((mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_AJUSTES)))
		{
			ValorReferencia VRlstTrpTipo = ValoresReferencia.getValor("TRPTIPO", "6");
			String lstTrpTipo = VRlstTrpTipo.getVavclave();
			datos = Consultas.ConsultasTransProd.obtenerTransProdAImprimirMovInventario(lstTrpTipo, ((Dia) Sesion.get(Campo.DiaActual)).DiaClave, getTransaccionesIds());
		}
		else if ((mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_DESCARGA)))
		{
			ValorReferencia VRlstTrpTipo = ValoresReferencia.getValor("TRPTIPO", "7");
			String lstTrpTipo = VRlstTrpTipo.getVavclave();
			datos = Consultas.ConsultasTransProd.obtenerTransProdAImprimirMovInventario(lstTrpTipo, ((Dia) Sesion.get(Campo.DiaActual)).DiaClave, getTransaccionesIds());
		}
		else if ((mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_DEVOLUCION)))
		{
			ValorReferencia VRlstTrpTipo = ValoresReferencia.getValor("TRPTIPO", "4");
			String lstTrpTipo = VRlstTrpTipo.getVavclave();
			datos = Consultas.ConsultasTransProd.obtenerTransProdAImprimirMovInventario(lstTrpTipo, ((Dia) Sesion.get(Campo.DiaActual)).DiaClave, getTransaccionesIds());
		}
		else if ((mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_CARGAS)))
		{
			ValorReferencia VRlstTrpTipo = ValoresReferencia.getValor("TRPTIPO", "2");
			String lstTrpTipo = VRlstTrpTipo.getVavclave();
			datos = Consultas.ConsultasTransProd.obtenerTransProdAImprimirMovInventario(lstTrpTipo, ((Dia) Sesion.get(Campo.DiaActual)).DiaClave, getTransaccionesIds());
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
			registro.put("TraspasoRutas", String.valueOf(mVista.esTraspasoRuta()));
			registro.put("TransProdId", c.getString(c.getColumnIndex("_Id")));
			registro.put("Folio",  c.getString(c.getColumnIndex("Folio")));
			if ((mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_CARGAS))) {
                int ticketConfigCarga = 0;
                try {
                    if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).existeParametro("TicketConfigCarga"))
                        ticketConfigCarga = Integer.parseInt(((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("TicketConfigCarga").toString());
                }catch(Exception e){}
                if (ticketConfigCarga != 0) {
                    registro.put("_Id", String.valueOf(ticketConfigCarga));
                    registro.put("TipoRecibo", String.valueOf(ticketConfigCarga));
                    registro.put("TipoTicket", "Carga");
                }
			}

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

    public void solicitarFirma()
    {
        if (Consultas2.ConsultasPerfil.validarPermisoFirma(moduloMovDetalle.TipoIndice)) {
            HashMap<String, Object> oParametros = new HashMap<String, Object>();
            oParametros.put("TransProdID", transProdGeneral.TransProdID);
            mVista.iniciarActividadConResultado(ICapturaFirma.class, Enumeradores.Solicitudes.SOLICITUD_CAPTURAR_FIRMA, Enumeradores.Acciones.ACCION_CAPTURAR_FIRMA, oParametros);
        }else{
            mVista.guardar("", "");
        }
    }

	public void agregarCantidadOriginal(){
		try{
			for(TransProdDetalle oTpd : transProdGeneral.TransProdDetalle){
				oTpd.CantidadOriginal = oTpd.Cantidad;
				oTpd.MFechaHora = Generales.getFechaHoraActual();
				oTpd.MUsuarioID = ((Usuario)Sesion.get(Campo.UsuarioActual)).USUId;
				oTpd.Enviado = false;
				BDVend.guardarInsertar(oTpd);
			}
		}catch(Exception ex){
			if (ex != null && ex.getMessage()!=null){
				mVista.mostrarError(ex.getMessage());
			}else{
				mVista.mostrarError("Error al obtener ");
			}
		}
	}

	public boolean ValidarAfectarInventarioConfirmacionCarga(){
		try{
			if (transProdGeneral.TransProdDetalle.size() <=0){
				BDVend.recuperar(transProdGeneral, TransProdDetalle.class);
			}
			for(TransProdDetalle oTpd : transProdGeneral.TransProdDetalle){
				Inventario.ActualizarInventario(oTpd.ProductoClave, oTpd.TipoUnidad, oTpd.Cantidad, moduloMovDetalle.TipoTransProd, moduloMovDetalle.TipoMovimiento, vendedor.AlmacenID);
			}
			return true;
		}catch(Exception ex){
			if (ex != null && ex.getMessage()!=null){
				mVista.mostrarError(ex.getMessage());
			}else{
				mVista.mostrarError("Error al obtener ");
			}
			return false;
		}

}
	//
	public boolean actualizarMotivo(String[] tpd, short motivo) throws Exception {
		BDVend.recuperar(transProdGeneral, TransProdDetalle.class);
		transacciones.put(transProdGeneral.SubEmpresaId, transProdGeneral);
		TransProdDetalle mtpdDev = new TransProdDetalle();
		try {
			for (TransProdDetalle mtpd : transProdGeneral.TransProdDetalle)
			{
				if((mtpd.TransProdDetalleID).compareTo(tpd[7])==0){
					mtpdDev = mtpd;
				}
			}

			TransProdDetalle res;
			res = TransaccionesDetalle.ActualizarTipoMotivoTransaccion(mtpdDev, Short.parseShort(tpd[4]), moduloMovDetalle.TipoTransProd, Float.valueOf(0), true, bManejarInventario); //salida
			if (res == null) return false ;
			mtpdDev = TransaccionesDetalle.ActualizarTipoMotivoTransaccion(mtpdDev, motivo, moduloMovDetalle.TipoTransProd, Float.parseFloat(tpd[4]), false, bManejarInventario); //entrada
			BDVend.guardarInsertar(mtpdDev);
			boolean refrescar = false;
			//recorrer todos los detalle para actualizar los que tengan motivo no definido
			for (TransProdDetalle tpd1 : getTransProd().TransProdDetalle)
			{
				if (tpd1.TipoMotivo == 0)
				{
					// cancelar el inventario del motivo actual
					TransProdDetalle otpd = TransaccionesDetalle.ActualizarTipoMotivoTransaccion(tpd1, tpd1.TipoMotivo, moduloMovDetalle.TipoTransProd, Float.valueOf(0), true, bManejarInventario); //salida
					// actualizar inventario con motivo nuevo
					otpd = TransaccionesDetalle.ActualizarTipoMotivoTransaccion(tpd1, motivo, moduloMovDetalle.TipoTransProd, tpd1.Cantidad,false, bManejarInventario);
					BDVend.guardarInsertar(otpd);
					refrescar = true;
				}
			}
			if (refrescar)
				mVista.refrescarProductos(getTransaccionesIds());
			return true;
		}
		catch (Exception e)
		{
			mVista.mostrarError(e.getMessage());
		}
		return false;
	}

	public TransProd getTransProd()
	{
		return transProdGeneral;
	}

	public void setGrupoTipoMotivo(String sTipoMotivo){
		try {
			if (sTipoMotivo.equals("0"))
				sGrupoTipoMotivo = "";
			else
				sGrupoTipoMotivo = Consultas.ConsultasValorReferencia.obtenerGrupo("TRPMOT", sTipoMotivo);
		}catch(Exception e){}
	}

	public String getGrupoTipoMotivo(){
		return sGrupoTipoMotivo;
	}

	public HashMap<String, TransProd> getTransacciones(){
		return transacciones;
	}
	//
}
