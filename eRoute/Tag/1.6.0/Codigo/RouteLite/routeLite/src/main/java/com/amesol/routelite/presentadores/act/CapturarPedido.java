package com.amesol.routelite.presentadores.act;
 
import java.util.ArrayList;
import java.util.HashMap;
import java.util.Iterator;
import java.util.Map;
import java.util.concurrent.atomic.AtomicReference;

import android.database.Cursor;
import android.util.Log;

import com.amesol.routelite.actividades.Cuotas;
import com.amesol.routelite.actividades.Enumeradores.Inventario.TiposValidacionInventario;
import com.amesol.routelite.actividades.Inventario;
import com.amesol.routelite.actividades.ListaPrecio;
import com.amesol.routelite.actividades.ManejoEnvase;
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.actividades.Promociones2;
import com.amesol.routelite.actividades.Transacciones;
import com.amesol.routelite.actividades.TransaccionesDetalle;
import com.amesol.routelite.actividades.ValorReferencia;
import com.amesol.routelite.actividades.ValoresReferencia;
import com.amesol.routelite.datos.Cliente;
import com.amesol.routelite.datos.Dia;
import com.amesol.routelite.datos.ModuloMovDetalle;
import com.amesol.routelite.datos.PedidoModificado;
import com.amesol.routelite.datos.Precio;
import com.amesol.routelite.datos.Producto;
import com.amesol.routelite.datos.ProductoDetalle;
import com.amesol.routelite.datos.ProductoPrestamoCli;
import com.amesol.routelite.datos.Ruta;
import com.amesol.routelite.datos.TransProd;
import com.amesol.routelite.datos.TransProdDetalle;
import com.amesol.routelite.datos.Usuario;
import com.amesol.routelite.datos.Vendedor;
import com.amesol.routelite.datos.basedatos.BDVend;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.basedatos.Consultas2;
import com.amesol.routelite.datos.basedatos.Consultas.ConsultasCantidad;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.MOTConfiguracion;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.Enumeradores.TipoEnvioInfo;
import com.amesol.routelite.presentadores.Enumeradores.TiposFasesDocto;
import com.amesol.routelite.presentadores.Enumeradores.TiposModulos;
import com.amesol.routelite.presentadores.Enumeradores.TiposMovimientos;
import com.amesol.routelite.presentadores.Enumeradores.TiposTransProd;
import com.amesol.routelite.presentadores.Presentador;
import com.amesol.routelite.presentadores.interfaces.ICapturaPedido;
import com.amesol.routelite.presentadores.interfaces.IConsultaPromociones;
import com.amesol.routelite.presentadores.interfaces.IServidorComunicaciones;
import com.amesol.routelite.utilerias.ControlError;
import com.amesol.routelite.utilerias.Generales;

public class CapturarPedido extends Presentador
{

	ICapturaPedido mVista;
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
	float nTotalInicial =0;
	float saldoPrestamoIni = 0;
	
	public boolean errorFinalizar = false;

	public CapturarPedido(ICapturaPedido vista, String accion)
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

			//sUsuarioID = ((Usuario)Sesion.get(Campo.UsuarioActual)).USUId;
            Cliente oCliente = ((Cliente) Sesion.get(Campo.ClienteActual));
			sClienteClave = oCliente.ClienteClave;
			//sDiaClave = ((Dia)Sesion.get(Campo.DiaActual)).DiaClave;
			vendedor = (Vendedor) Sesion.get(Campo.VendedorActual);

			String sModuloMovDetalleClave = (String) Sesion.get(Campo.ModuloMovDetalleClave);
			moduloMovDetalle = new ModuloMovDetalle();
			moduloMovDetalle.ModuloMovDetalleClave = sModuloMovDetalleClave;
			BDVend.recuperar(moduloMovDetalle);

            if(!Consultas.ConsultasCliente.existeCFVTipo(sClienteClave)){
                throw new Exception(Mensajes.get("E0358"));
            }

			if (transacciones.size() >= 1)
			{ //se paso como parametro un TransProdId, cargar el pedido
				if(Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == TiposModulos.REPARTO 
						|| moduloMovDetalle.TipoTransProd == TiposTransProd.VENTA_CONSIGNACION)
					mVista.ocultarPedidoSugerido();
				bEsNuevo = false;
				bEsSugerido = false;
				HashMap<Integer,Precio> listasPrecio = ListaPrecio.Determinar(sClienteClave, moduloMovDetalle);

                //recorrer todas las transacciones, parte de agrupar transacciones
				for(TransProd tran : transacciones.values()){

					transProdGeneral = tran;
					transProdGeneral.setListaPrecios(listasPrecio);
					transProdGeneral.PCEPrecioClave = listasPrecio.get(0).PrecioClave ;
					nTotalInicial += transProdGeneral.Total;

                    MOTConfiguracion oMC = (MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion);
                    if(( (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO && tran.TipoFase == TiposFasesDocto.SURTIDO) || Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.VENTA)
                            //&& mPresenta.getTipoTransProd() == 1 && oCliente.Prestamo && oCliente.LimiteEnvase == 0 ){
                            && getTipoTransProd() == TiposTransProd.PEDIDO && oMC.get("CuadreDeEnvase").toString().equals("1") && oCliente.Prestamo ){
                        if(tran.DevolucionID != null && tran.DevolucionID != ""){
                            TransProd dev = Transacciones.Pedidos.ObtenerPedido(tran.DevolucionID);
                            BDVend.recuperar(dev,TransProdDetalle.class);
							String grupoMotivo = null;
                            for(TransProdDetalle tpd : dev.getTransProdDetalle()){
                                AtomicReference<Float> existencia = new AtomicReference<>();
                                StringBuilder error = new StringBuilder();
                                for(ValorReferencia v : ValoresReferencia.getValores("TRPMOT", "Recolección")){
                                    if(dev.TipoMotivo == Short.parseShort(v.getVavclave())){
                                        grupoMotivo = "Venta";
                                    }
                                }
                                if(grupoMotivo == null)
                                    grupoMotivo = "No Venta";

                                boolean ok = Inventario.ValidarExistencia(tpd.getProductoClave(),tpd.TipoUnidad,tpd.Cantidad,dev.Tipo,grupoMotivo,existencia,error);
                                if(!ok){
                                    errorFinalizar = true;
                                }else{
                                    Producto prod = new Producto();
                                    prod.ProductoClave = tpd.ProductoClave;
                                    BDVend.recuperar(prod);
                                    tpd.producto = prod;
                                }
                            }

							if(!errorFinalizar){ //si hay existencia para todos los detalles
								for(TransProdDetalle tpd : dev.getTransProdDetalle()){
									Inventario.ActualizarInventario(tpd.ProductoClave, tpd.TipoUnidad, tpd.Cantidad, dev.Tipo, dev.TipoMovimiento, vendedor.AlmacenID, grupoMotivo, true);
                                    ManejoEnvase.manejoEnvaseEliminar(tpd.producto, tpd.TipoUnidad, tpd.Cantidad, tpd, dev);
								}
								TransaccionesDetalle.EliminarDetalle(dev.TransProdID);
								tran.DevolucionID = null;
								Transacciones.EliminarTransaccion(dev.TransProdID);
							}
                            mVista.setHuboCambios(true);
                        }
                    }

                    BDVend.recuperar(transProdGeneral, TransProdDetalle.class);
                    //restar las cuotas para calcular otra vez en la pantalla de totales
                    Cuotas.CalcularCuotasXEfectivo(transProdGeneral, true);
                    Iterator<TransProdDetalle> it = transProdGeneral.TransProdDetalle.iterator();
                    while (it.hasNext())
                    {
                        TransProdDetalle oTpd = it.next();
                        actualizarCuotas(oTpd, true);
                    }
                }
				/*
                transProdGeneral = (TransProd) transacciones.values().toArray()[0];
				transProdGeneral.setListaPrecios(listasPrecio);
				transProdGeneral.PCEPrecioClave = listasPrecio.get(0).PrecioClave ;
				//if (transProdGeneral.ClientePagoId.equals("1") && transProdGeneral.CFVTipo == 1 && !mVista.getSurtir()){
				nTotalInicial = transProdGeneral.Total;
				//}
				//If oTransProdGenerico.TransProdId <> "" And oTransProdGenerico.ClientePagoId = "1" And oTransProdGenerico.CFVTipo = "1" Then
						
				BDVend.recuperar(transProdGeneral, TransProdDetalle.class);
				//restar las cuotas para calcular otra vez en la pantalla de totales
				Cuotas.CalcularCuotasXEfectivo(transProdGeneral, true);
				Iterator<TransProdDetalle> it = transProdGeneral.TransProdDetalle.iterator();
				while (it.hasNext())
				{
					TransProdDetalle oTpd = it.next();
					actualizarCuotas(oTpd, true);
				}
                */
			}
			else
			{ //generar uno nuevo
				bEsNuevo = true;
				bEsSugerido = false;
				StringBuilder byRefMensaje = new StringBuilder();
				transProdGeneral = Transacciones.Pedidos.generarPedido(moduloMovDetalle, byRefMensaje);
				if (byRefMensaje.length()>0){
					mVista.mostrarAdvertencia(byRefMensaje.toString());
				}
				byRefMensaje = null;
				BDVend.guardarInsertar(transProdGeneral);

				//agregar el transprodId al array
				transacciones.put(transProdGeneral.SubEmpresaId, transProdGeneral);

				if (((MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion)).get("PedidoSugerido").equals("0")
						|| moduloMovDetalle.TipoTransProd == TiposTransProd.VENTA_CONSIGNACION)
				{
					mVista.ocultarPedidoSugerido();
					/*
					 * ArrayList<Integer> tipoPedido = new ArrayList<Integer>();
					 * 
					 * if
					 * (Transacciones.Pedidos.GenerarPedidoSugerido(transProdGeneral
					 * , transacciones, tipoPedido, moduloMovDetalle)){
					 * bEsSugerido = true; if (tipoPedido.get(0) == 2)
					 * mVista.mostrarAdvertencia
					 * (Mensajes.get("I0248").replace("$0$", ((Cliente)
					 * Sesion.get(Campo.ClienteActual)).Clave)); }else
					 * mVista.mostrarAdvertencia
					 * (Mensajes.get("I0249").replace("$0$", ((Cliente)
					 * Sesion.get(Campo.ClienteActual)).Clave));
					 */
				}
			}

			if (transProdGeneral.getListaPrecios().size() >0){
				mVista.setListaPrecios(transProdGeneral.getListaPrecios().get(0).PrecioClave + "-" + transProdGeneral.getListaPrecios().get(0).Nombre);				
			}else{
				mVista.setListaPrecios("No existe Lista de Precios asignada");
			}
			
			if (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.PREVENTA && mAccion == null)
			{
				if (((Ruta) Sesion.get(Campo.RutaActual)).Inventario)
				{
					tipoValidacionExistencia = TiposValidacionInventario.ValidacionInformativa;
				}
				else
				{
					tipoValidacionExistencia = TiposValidacionInventario.NoValidar;
				}
				validarExistencia = false;
			}else if(mAccion != null){ //movimiento sin inventario en visita
				if(mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_MOV_SIN_INV_EN_VISITA)){
					tipoValidacionExistencia = TiposValidacionInventario.NoValidar;
					validarExistencia = false;	
				}
				else if(mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_CONSIGNACIONES)){
					tipoValidacionExistencia = TiposValidacionInventario.ValidacionRestrictiva;
					validarExistencia = true;	
				}
			}else
			{
				tipoValidacionExistencia = TiposValidacionInventario.ValidacionRestrictiva;
				validarExistencia = true;
			}

		}
		catch (Exception e)
		{
			errorFinalizar = true;
			//mVista.mostrarError(e);
			mVista.mostrarError(e.getMessage());
		}
	}

	private void actualizarCuotas(TransProdDetalle oTpd, boolean restar) throws Exception
	{
		float factor = Consultas.ConsultasProducto.obtenerFactor(oTpd.ProductoClave, oTpd.TipoUnidad);
		float cantidadUnitaria = oTpd.Cantidad * factor;
		if (restar)
		{
			Cuotas.VerificarCuotas(vendedor.VendedorId, 1, cantidadUnitaria * -1, oTpd.ProductoClave);
			Cuotas.VerificarCuotas(vendedor.VendedorId, 3, cantidadUnitaria * -1, oTpd.ProductoClave);
		}
		else
		{
			Cuotas.VerificarCuotas(vendedor.VendedorId, 1, cantidadUnitaria, oTpd.ProductoClave);
			Cuotas.VerificarCuotas(vendedor.VendedorId, 3, cantidadUnitaria, oTpd.ProductoClave);
		}

	}

	public String getListasPrecios()
	{
		return transProdGeneral.CadenaListasPrecios ;
	}
	
	public boolean getEsNuevo()
	{
		return bEsNuevo;
	}

	public boolean getValidarExistencia()
	{
		return validarExistencia;
	}

	public int getTipoValidacionExistencia()
	{
		return tipoValidacionExistencia;
	}

	public ModuloMovDetalle getModuloMovDetalle()
	{
		return moduloMovDetalle;
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

	public int getTipoIndiceModuloMovDetalle()
	{
		return moduloMovDetalle.TipoIndice;
	}

	public void agregarProductoUnidad(Producto producto, TransProdDetalle transProdDetalle, boolean refrescarListado){
		generarDetalle(producto, transProdDetalle, refrescarListado);
	}
	
	/*public void agregarProductoUnidad(String subEmpresaID, TransProdDetalle transProdDetalle, boolean refrescarListado)
	{
		generarDetalle(subEmpresaID, transProdDetalle, refrescarListado);
	}*/

	public void agregarProductoUnidad(String productoClave, String subEmpresaId, int TipoUnidad, Float Cantidad, Float PrecioEspecial)
	{
		generarDetalle(productoClave, subEmpresaId, TipoUnidad, Cantidad, PrecioEspecial, false, (float) 0, null);
	}
	
	public void agregarProductoUnidad(String productoClave, String subEmpresaId, int TipoUnidad, Float Cantidad, Float PrecioEspecial, Float CantidadOriginal)
	{
		generarDetalle(productoClave, subEmpresaId, TipoUnidad, Cantidad, PrecioEspecial, true, CantidadOriginal, null);
	} 
	
	public void agregarProductoUnidad(String productoClave, String subEmpresaId, int TipoUnidad, Float Cantidad, Float PrecioEspecial, String TransProdDetalleID)
	{
		generarDetalle(productoClave, subEmpresaId, TipoUnidad, Cantidad, PrecioEspecial, false, (float) 0, TransProdDetalleID);
	}
	
	public void agregarProductoUnidad(String productoClave, String subEmpresaId, int TipoUnidad, Float Cantidad, Float PrecioEspecial, Float CantidadOriginal, String TransProdDetalleID)
	{
		generarDetalle(productoClave, subEmpresaId, TipoUnidad, Cantidad, PrecioEspecial, true, CantidadOriginal, TransProdDetalleID);
	}
	
	public boolean validarCantMax(float cantidad){
		MOTConfiguracion oMot = ((MOTConfiguracion)Sesion.get(Campo.MOTConfiguracion));
		if(Integer.parseInt(oMot.get("CantidadMaxProd").toString()) > 0){
			if(cantidad > Integer.parseInt(oMot.get("CantidadMaxProd").toString())){
				mVista.mostrarPreguntaSiNo(Mensajes.get("P0245").replace("$0$", oMot.get("CantidadMaxProd").toString()), 30);
				return true;
			}
		}
		return false;
	}

	public boolean validarProductoContenido(Producto producto) throws Exception
	{

		if (producto.Contenido && !producto.Venta)
		{
			throw new ControlError("E0725");
		}

		return true;
	}

	public boolean validarProductoContenido(String ProductoClave) throws Exception
	{
		Producto oProducto = Consultas.ConsultasProducto.obtenerProducto(ProductoClave);

		if (oProducto.Contenido && !oProducto.Venta)
		{
			throw new ControlError("E0725");
		}

		return true;
	}

	@SuppressWarnings("rawtypes")
	public void eliminarPromos()
	{
		try
		{
			Iterator it = transacciones.entrySet().iterator();
			TransProd oTRP;
			while (it.hasNext())
			{
				Map.Entry e = (Map.Entry) it.next();
				oTRP = (TransProd) e.getValue();
				Promociones2 promociones = new Promociones2(oTRP);
				promociones.Preparar();
			}
		}
		catch (Exception e)
		{
			//mVista.mostrarError(e);
			mVista.mostrarError(e.getMessage());
		}
	}
	
	//private void generarDetalle(String subEmpresaId, TransProdDetalle transProdDetalle, boolean refrescarListado)
	@SuppressWarnings("unused")
	private void generarDetalle(Producto producto, TransProdDetalle transProdDetalle, boolean refrescarListado)
	{
		try
		{
			String subEmpresaId = producto.SubEmpresaId;
			StringBuilder byRefMensaje = new StringBuilder();

			transProdGeneral = Transacciones.Pedidos.ActualizarGenerarPedido(transacciones, subEmpresaId, moduloMovDetalle, byRefMensaje);
			if (byRefMensaje.length()>0){
				mVista.mostrarAdvertencia(byRefMensaje.toString());
			}
			byRefMensaje=null;
			
			//validar si se genero un nuevo encabezado para agregar al array
			if (!transacciones.containsKey(subEmpresaId))
			{
				transacciones.put(subEmpresaId, transProdGeneral);
			}
			
			BDVend.guardarInsertar(transProdGeneral);

			transProdDetalle.TransProdID = transProdGeneral.TransProdID;
			TransaccionesDetalle.Pedidos.CalcularTotalesDetallePedido(transProdDetalle);

			if (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.VENTA || Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO || (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.PREVENTA && ((Ruta) Sesion.get(Campo.RutaActual)).Inventario))
			{
				Inventario.ActualizarInventario(transProdDetalle.ProductoClave, transProdDetalle.TipoUnidad, transProdDetalle.Cantidad, moduloMovDetalle.TipoTransProd, moduloMovDetalle.TipoMovimiento, vendedor.AlmacenID);
			}
			
			Cliente cli = ((Cliente)Sesion.get(Campo.ClienteActual));
			if((Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.VENTA || Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO) &&
                    cli.Prestamo && (transProdGeneral.Tipo == TiposTransProd.PEDIDO || transProdGeneral.Tipo == TiposTransProd.VENTA_CONSIGNACION)){
				ManejoEnvase.manejoEnvase(producto, transProdDetalle.TipoUnidad, transProdDetalle.Cantidad, transProdDetalle, transProdGeneral);
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
				//posicionar la lista en el producto que se agrego para capturar cantidad
				//mVista.seleccionarProducto(productoClave, String.valueOf(TipoUnidad));
			}

			//actualizar cuotas
			//final TransProdDetalle oTpd = transProdDetalle;
			//actualizarCuotas(oTpd, false);

			/*
			 * float factor =
			 * Consultas.ConsultasProducto.obtenerFactor(ProductoClave,
			 * TipoUnidad); float cantidadUnitaria = transProdDetalle.Cantidad *
			 * factor; Cuotas.VerificarCuotas(vendedor.VendedorId, 1,
			 * cantidadUnitaria, ProductoClave);
			 * Cuotas.VerificarCuotas(vendedor.VendedorId, 3, cantidadUnitaria,
			 * ProductoClave);
			 */

		}
		catch (Exception ex)
		{
			//mVista.mostrarError(ex);
			mVista.mostrarError(ex.getMessage() == null ? ex.getCause().getMessage() : ex.getMessage());
		}

	}

	private void generarDetalle(String productoClave, String subEmpresaId, int TipoUnidad, Float Cantidad, Float PrecioEspecial, boolean setCantidadOriginal, Float CantidadOriginal, String TransProdDetalleID)
	{
		try
		{
 
			StringBuilder byRefMensaje = new StringBuilder();
			transProdGeneral = Transacciones.Pedidos.ActualizarGenerarPedido(transacciones, subEmpresaId, moduloMovDetalle, byRefMensaje);
			if (byRefMensaje.length()>0){
				mVista.mostrarAdvertencia(byRefMensaje.toString());
			}
			byRefMensaje = null;
			
			//validar si se genero un nuevo encabezado para agregar al array
			if (!transacciones.containsKey(subEmpresaId))
			{
				transacciones.put(subEmpresaId, transProdGeneral);
			}

			BDVend.guardarInsertar(transProdGeneral);

			TransProdDetalle transProdDetalle = TransaccionesDetalle.Pedidos.GenerarDetallePedido(transProdGeneral.TransProdID, productoClave, TipoUnidad, Cantidad, 0, transProdGeneral.CadenaListasPrecios, PrecioEspecial, TransProdDetalleID);
			
			if(setCantidadOriginal)
				transProdDetalle.CantidadOriginal = CantidadOriginal;
			
			if (tipoValidacionExistencia != TiposValidacionInventario.NoValidar)
			{
				//Solo si realmente es un reparto. Si es venta directa en reparto debe entrar al segundo actualizar.
				if(Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO && mVista.getReparto())
					//Inventario.ActualizarInventario(productoClave, TipoUnidad, Cantidad, moduloMovDetalle.TipoTransProd, TiposMovimientos.ENTRADA, vendedor.AlmacenID);
					Inventario.ActualizarInventario(productoClave, TipoUnidad, Cantidad, moduloMovDetalle.TipoTransProd, TiposMovimientos.ENTRADA, vendedor.AlmacenID, null, false, null, 0, true);
				else
					Inventario.ActualizarInventario(productoClave, TipoUnidad, Cantidad, moduloMovDetalle.TipoTransProd, moduloMovDetalle.TipoMovimiento, vendedor.AlmacenID);
				
				Cliente cli = ((Cliente)Sesion.get(Campo.ClienteActual));
				if((Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.VENTA || Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO) &&
                        cli.Prestamo && (transProdGeneral.Tipo == TiposTransProd.PEDIDO || transProdGeneral.Tipo == TiposTransProd.VENTA_CONSIGNACION)){
					//validaciones de prestamo envase
					Producto producto = new Producto();
					producto.ProductoClave = productoClave;
					BDVend.recuperar(producto);
					ManejoEnvase.manejoEnvase(producto, TipoUnidad, Cantidad, transProdDetalle, transProdGeneral);
				}
			}	

			if (transProdDetalle == null)
				throw new ControlError("MDB042302");
			else
			{
				BDVend.guardarInsertar(transProdDetalle);
				mVista.setHuboCambios(true);
				mVista.refrescarProductos(getTransaccionesIds());
				//posicionar la lista en el producto que se agrego para capturar cantidad
				//mVista.seleccionarProducto(productoClave, String.valueOf(TipoUnidad));
			}

			//actualizar cuotas
			//final TransProdDetalle oTpd = transProdDetalle;
			//actualizarCuotas(oTpd, false);

			/*
			 * float factor =
			 * Consultas.ConsultasProducto.obtenerFactor(ProductoClave,
			 * TipoUnidad); float cantidadUnitaria = transProdDetalle.Cantidad *
			 * factor; Cuotas.VerificarCuotas(vendedor.VendedorId, 1,
			 * cantidadUnitaria, ProductoClave);
			 * Cuotas.VerificarCuotas(vendedor.VendedorId, 3, cantidadUnitaria,
			 * ProductoClave);
			 */

		}
		catch (Exception ex)
		{
			//mVista.mostrarError(ex);
			mVista.mostrarError(ex.getMessage() == null ? ex.getCause().getMessage() : ex.getMessage());
		}

	}

	public void actualizarDetalle(String transProdId, String transProdDetalleID, float Cantidad)
	{
		try
		{
			TransProdDetalle transProdDetalle = TransaccionesDetalle.Pedidos.ActualizarDetallePedido(transProdId, transProdDetalleID, Cantidad);

			//actualizar cuotas
			//actualizarCuotas(transProdDetalle, false);
			/*
			 * float factor =
			 * Consultas.ConsultasProducto.obtenerFactor(transProdDetalle
			 * .ProductoClave, transProdDetalle.TipoUnidad); float
			 * cantidadUnitaria = transProdDetalle.Cantidad * factor;
			 * Cuotas.VerificarCuotas(vendedor.VendedorId, 1, cantidadUnitaria,
			 * transProdDetalle.ProductoClave);
			 * Cuotas.VerificarCuotas(vendedor.VendedorId, 3, cantidadUnitaria,
			 * transProdDetalle.ProductoClave);
			 */

			BDVend.guardarInsertar(transProdDetalle);
			mVista.setHuboCambios(true);

			mVista.refrescarProductos(getTransaccionesIds());

		}
		catch (Exception e)
		{
			//mVista.mostrarError(e);
			mVista.mostrarError(e.getMessage());
		}
	}

    public void eliminarDetalle(String transProdId, String transProdDetalleId, String subEmpresaId, String productoClave, int TipoUnidad, float Cantidad){
        eliminarDetalle(transProdId, transProdDetalleId, subEmpresaId, productoClave, TipoUnidad, Cantidad, true);
    }

	public void eliminarDetalle(String transProdId, String transProdDetalleId, String subEmpresaId, String productoClave, int TipoUnidad, float Cantidad, boolean validarTrpSinDetalle)
	{
		try
		{
			//TransaccionesDetalle.Pedidos.EliminarDetalle(transProdId, transProdDetalleId);

			TransProdDetalle tpd = transacciones.get(subEmpresaId).getTransProdDetalle(transProdDetalleId);
			if (tpd != null)
			{
				transacciones.get(subEmpresaId).TransProdDetalle.remove(tpd);
			}else{
				tpd = new TransProdDetalle();
				tpd.TransProdID = transProdId;
				tpd.TransProdDetalleID = transProdDetalleId;
				BDVend.recuperar(tpd);
			}
			TransaccionesDetalle.Pedidos.EliminarDetalle(transProdId, transProdDetalleId);
			
			if (tipoValidacionExistencia != TiposValidacionInventario.NoValidar)
			{
				Producto producto = new Producto();
				producto.ProductoClave = productoClave;
				BDVend.recuperar(producto);
				if((Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO) && mVista.getReparto() && !mVista.getSurtir() ){
					float cantidadUM = 0;
					if(producto.Contenido){
						ProductoDetalle prd = new ProductoDetalle();
						prd.ProductoClave = productoClave;
						prd.ProductoDetClave = productoClave;
						prd.PRUTipoUnidad = (short) TipoUnidad;
						BDVend.recuperar(prd);
						cantidadUM = tpd.Cantidad * prd.Factor;
						if(((Cliente) Sesion.get(Campo.ClienteActual)).Prestamo && transProdGeneral.Tipo == TiposTransProd.PEDIDO){
							if(tpd.PrestamoVendido != cantidadUM)
								Inventario.ActualizarInventario(productoClave, TipoUnidad, Cantidad, moduloMovDetalle.TipoTransProd, TiposMovimientos.ENTRADA, vendedor.AlmacenID, true);	
						}else
							Inventario.ActualizarInventario(productoClave, TipoUnidad, Cantidad, moduloMovDetalle.TipoTransProd, TiposMovimientos.ENTRADA, vendedor.AlmacenID, true);
					}else{
						Inventario.ActualizarInventario(productoClave, TipoUnidad, Cantidad, moduloMovDetalle.TipoTransProd, TiposMovimientos.ENTRADA, vendedor.AlmacenID, true);
					}
					
					//Inventario.ActualizarInventario(productoClave, TipoUnidad, Cantidad, moduloMovDetalle.TipoTransProd, TiposMovimientos.ENTRADA, vendedor.AlmacenID, true);
				}else{
					float cantidadUM = 0;
					if(producto.Contenido){
						ProductoDetalle prd = new ProductoDetalle();
						prd.ProductoClave = productoClave;
						prd.ProductoDetClave = productoClave;
						prd.PRUTipoUnidad = (short) TipoUnidad;
						BDVend.recuperar(prd);
						cantidadUM = tpd.Cantidad * prd.Factor;
						if(((Cliente) Sesion.get(Campo.ClienteActual)).Prestamo && transProdGeneral.Tipo == TiposTransProd.PEDIDO){
							if(tpd.PrestamoVendido != cantidadUM)
								Inventario.ActualizarInventario(productoClave, TipoUnidad, Cantidad, moduloMovDetalle.TipoTransProd, moduloMovDetalle.TipoMovimiento, vendedor.AlmacenID, true);	
						}else
							Inventario.ActualizarInventario(productoClave, TipoUnidad, Cantidad, moduloMovDetalle.TipoTransProd, moduloMovDetalle.TipoMovimiento, vendedor.AlmacenID, true);
					}else{
						Inventario.ActualizarInventario(productoClave, TipoUnidad, Cantidad, moduloMovDetalle.TipoTransProd, moduloMovDetalle.TipoMovimiento, vendedor.AlmacenID, true);
					}
					
					//Inventario.ActualizarInventario(productoClave, TipoUnidad, Cantidad, moduloMovDetalle.TipoTransProd, moduloMovDetalle.TipoMovimiento, vendedor.AlmacenID, true);
				}
				
				if((Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.VENTA || Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO) &&
                        ((Cliente) Sesion.get(Campo.ClienteActual)).Prestamo && (transProdGeneral.Tipo == TiposTransProd.PEDIDO || transProdGeneral.Tipo == TiposTransProd.VENTA_CONSIGNACION)){
					ManejoEnvase.manejoEnvaseEliminar(producto, TipoUnidad, Cantidad, tpd, transProdGeneral);
				}
			}
			mVista.setHuboCambios(true);

            if(validarTrpSinDetalle){
                if (Transacciones.Pedidos.EliminarSiNoHayDetalle(transProdId))
                {
                    TransProd trp =  transacciones.get(subEmpresaId);//Transacciones.Pedidos.ObtenerPedido(transProdId);
                    if (transacciones.size() > 1)
                    { //si hay mas de una transaccion eliminar la que no tiene detalle
                        //Consultas.ConsultasTRPGrupo.eliminarTransaccionGrupo(trp.TransProdID); //eliminar el registro del grupo antes de eliminar el transprod
                        BDVend.eliminar(trp);
                        if (transacciones.containsKey(trp.SubEmpresaId))
                            transacciones.remove(trp.SubEmpresaId);
                    }
                    else
                    { //si es la unica y ya no tiene detalle, borrar subempresa
                        trp.SubEmpresaId = "";
                        BDVend.guardarInsertar(trp);
                    }
                }
            }

			mVista.refrescarProductos(getTransaccionesIds());
		}
		catch (Exception e)
		{
			//mVista.mostrarError(e);
			mVista.mostrarError(e.getMessage());
		}
	}

	/*
	 * private void actualizarCuotas(TransProdDetalle oTpd, boolean restar)
	 * throws Exception{ float factor =
	 * Consultas.ConsultasProducto.obtenerFactor(oTpd.ProductoClave,
	 * oTpd.TipoUnidad); float cantidadUnitaria = oTpd.Cantidad * factor;
	 * if(restar){ Cuotas.VerificarCuotas(vendedor.VendedorId, 1,
	 * cantidadUnitaria * -1, oTpd.ProductoClave);
	 * Cuotas.VerificarCuotas(vendedor.VendedorId, 3, cantidadUnitaria * -1,
	 * oTpd.ProductoClave); }else{ Cuotas.VerificarCuotas(vendedor.VendedorId,
	 * 1, cantidadUnitaria, oTpd.ProductoClave);
	 * Cuotas.VerificarCuotas(vendedor.VendedorId, 3, cantidadUnitaria,
	 * oTpd.ProductoClave); }
	 * 
	 * }
	 */

	public boolean getPedidoSugerido()
	{
		return bEsSugerido;
	}

	public Producto getProductoActual()
	{
		return oProducto;
	}

	public void setProductoActual(Producto producto)
	{
		oProducto = producto;
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

	public void agregarTransaccion(String subEmpresaId, TransProd transProd)
	{
		transacciones.put(subEmpresaId, transProd);
	}

	public void agregarTransaccion(String transProdId) throws Exception
	{
		TransProd trp = Transacciones.Pedidos.ObtenerPedido(transProdId);
		transacciones.put(trp.SubEmpresaId, trp);
	}

	
	public HashMap<String, TransProd> getHashMapTransacciones()
	{
		return transacciones;
	}

	public short getTipoFase()
	{
		return transProdGeneral.TipoFase;
	}
	
	public short getTipoTransProd(){
		return transProdGeneral.Tipo;
	}

	public float getTotalInicial()
	{
		return nTotalInicial;
	}
	
	public void consultarPromociones()
	{
		HashMap<String, String> oParametros = new HashMap<String, String>();
		oParametros.put("ListaPrecios", getListasPrecios());

		mVista.iniciarActividad(IConsultaPromociones.class, null, null, false, oParametros);
	}
	
	/*public void actualizarInventario(){
		//llamar envio parcial antes de sincronizar inventario
		HashMap<String, String> oParametros = new HashMap<String, String>();
		oParametros.put("TipoEnvioInfo", String.valueOf(TipoEnvioInfo.ENVIO_PARCIAL));
		oParametros.put("Continuar", "true"); 
		mVista.iniciarActividadConResultado(IServidorComunicaciones.class, Enumeradores.Solicitudes.SOLICITUD_SERVIDOR_COMUNICACIONES_ENVIO_PARCIAL, Enumeradores.Acciones.ACCION_ENVIAR_BD_VENDEDOR, oParametros);
	}*/
	
	public void obtenerInventarioEnLinea(){
		HashMap<String, String> parametros = new HashMap<String, String>();
		String tablasActualizar = "''Inventario''";
		parametros.put("Tablas", tablasActualizar);
		mVista.iniciarActividadConResultado(IServidorComunicaciones.class, Enumeradores.Solicitudes.SOLICITUD_SERVIDOR_COMUNICACIONES, Enumeradores.Acciones.ACCION_RECIBIR_INFO_INVENTARIO, parametros);
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
			e.printStackTrace();
		}
		return Cantidad;
	}
	 
	public ArrayList<TransProdDetalle> validarInventarioASurtir(){
		ArrayList<TransProdDetalle> aRes = new ArrayList<TransProdDetalle>();
		Iterator<TransProd> docsTransProd = getHashMapTransacciones().values().iterator();
		if (docsTransProd.hasNext())
		{
			Iterator<TransProdDetalle> oTpd = docsTransProd.next().getTransProdDetalle().iterator();
			while(oTpd.hasNext()){
				AtomicReference<Float> existencia = new AtomicReference<Float>();
				StringBuilder error = new StringBuilder();
				TransProdDetalle tpd = oTpd.next();
				if(!Inventario.ValidarExistenciaDifNoDisponible(tpd.ProductoClave, tpd.TipoUnidad, tpd.Cantidad, existencia, error)){
					if(!aRes.contains(oTpd)){
						aRes.add(tpd);
					}
				}				
			}
		}
		return aRes;
	}
	
	public ArrayList<TransProdDetalle> validarInventarioASurtirModificar() throws Exception{
		ArrayList<TransProdDetalle> aRes = new ArrayList<TransProdDetalle>();
		Iterator<TransProd> docsTransProd = getHashMapTransacciones().values().iterator();
		if (docsTransProd.hasNext())
		{
			Iterator<TransProdDetalle> oTpd = docsTransProd.next().getTransProdDetalle().iterator();
			while(oTpd.hasNext()){
				AtomicReference<Float> existencia = new AtomicReference<Float>();
				StringBuilder error = new StringBuilder();
				TransProdDetalle tpd = oTpd.next();
				if(!Inventario.ValidarExistenciaDifNoDisponible(tpd.ProductoClave, tpd.TipoUnidad, tpd.Cantidad, existencia, error)){
					Inventario.ActualizarInventario(tpd.ProductoClave, tpd.TipoUnidad, tpd.Cantidad, TiposTransProd.PEDIDO, TiposMovimientos.NO_DEFINIDO, ((Vendedor)Sesion.get(Campo.VendedorActual)).AlmacenID, true);
					
					if(existencia.get() > 0){
						Inventario.ActualizarInventario(tpd.ProductoClave, tpd.TipoUnidad, existencia.get() < tpd.Cantidad ? existencia.get() : tpd.Cantidad, TiposTransProd.PEDIDO, TiposMovimientos.ENTRADA, ((Vendedor)Sesion.get(Campo.VendedorActual)).AlmacenID, "", false, transProdGeneral.ClienteClave, tpd.PrestamoVendido, false);
					}
					
					tpd.Cantidad = existencia.get();
					tpd.MFechaHora = Generales.getFechaHoraActual();
					tpd.MUsuarioID = ((Usuario)Sesion.get(Campo.UsuarioActual)).USUId;
					tpd.Enviado = false;
					
					if(!aRes.contains(oTpd)){
						aRes.add(tpd);
					}
				}
				
				Cliente cli = ((Cliente)Sesion.get(Campo.ClienteActual));
				if((Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.VENTA || Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO) &&
                        cli.Prestamo && transProdGeneral.Tipo == TiposTransProd.PEDIDO ){
					Producto producto = new Producto();
					producto.ProductoClave = tpd.ProductoClave;
					BDVend.recuperar(producto);
					ManejoEnvase.manejoEnvase(producto, tpd.TipoUnidad, tpd.Cantidad, tpd, transProdGeneral);
				}
			}
		}
		return aRes;
	}
	
	public void modificarPedido(){
		try
		{
			int faseAnterior = 0; 
			mVista.setSurtir(false);
			mVista.setSoloLectura(false);
			mVista.setHuboCambios(true);
			
			//TODO: checar cual es el parametro que deshabilita la captura de productos
			//en mobile parece ser SoloVentaEnvase y el doc dice NoAdicionProducto
			/*if(Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO && ((MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion)).get("SoloVentaEnvase").equals("1")){
				mVista.setCapturaEnabled(false);
			}*/
			// la validacion esta mal echa ya que solo se debe bloquar todos los campos cuando el campo NoAdicionProducto = 1 pero al quere modificar se debe desbloquear el campo cantidad y ahi validar que no se mayor de la cantidad que tiene 
			if(Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO && ((MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion)).get("NoAdicionProducto").equals("1"))
			{
				mVista.setCapturaEnabled(false);
			}
			//TODO: checar tabla pedido modificado
			//Consultas.ConsultasReparto.insertarPedidoModificado(transProdGeneral.TransProdID);
			PedidoModificado pedidoMod = new PedidoModificado();
			pedidoMod.TransProdId = transProdGeneral.TransProdID;
			pedidoMod.MFechaHora = Generales.getFechaHoraActual();
			pedidoMod.MUsuarioID = ((Usuario)Sesion.get(Campo.UsuarioActual)).USUId;
			pedidoMod.Enviado = false;
			BDVend.guardarInsertar(pedidoMod);
			
			faseAnterior = transProdGeneral.TipoFase;
			transProdGeneral.TipoFase = TiposFasesDocto.CAPTURA;
			transProdGeneral.TipoMovimiento = TiposMovimientos.SALIDA;
			transProdGeneral.FechaEntrega = ((Dia)Sesion.get(Campo.DiaActual)).FechaCaptura; //Generales.getFechaActual();
			transProdGeneral.FechaCobranza = ((Dia)Sesion.get(Campo.DiaActual)).FechaCaptura; //Generales.getFechaActual();
			
			for(TransProdDetalle oTpd : transProdGeneral.TransProdDetalle){
				oTpd.CantidadOriginal = oTpd.Cantidad;
				oTpd.MFechaHora = Generales.getFechaHoraActual();
				oTpd.MUsuarioID = ((Usuario)Sesion.get(Campo.UsuarioActual)).USUId;
				oTpd.Enviado = false;
				BDVend.guardarInsertar(oTpd);
			}
			
			if(faseAnterior != TiposFasesDocto.CAPTURA_ESCRITORIO){
				HashMap<Integer,Precio> listasPrecios = ListaPrecio.Determinar(sClienteClave, moduloMovDetalle);
				transProdGeneral.setListaPrecios(listasPrecios);
				mVista.setListaPrecios(transProdGeneral.getListaPrecios().get(0).PrecioClave + "-" + transProdGeneral.getListaPrecios().get(0).Nombre);
				eliminarPromos();
				mVista.setEsNuevo(true);
			}
			
			ArrayList<TransProdDetalle> prodSinExistencia = validarInventarioASurtirModificar();
			
			if(prodSinExistencia.size() != 0){
				String productos = "";
				
				for(TransProdDetalle oTpd : prodSinExistencia){
						productos += oTpd.ProductoClave + ", ";
				}
				if(productos != ""){
					productos = productos.substring(0, productos.length() - 2);
				}
				
				if(productos != ""){
					mVista.mostrarAdvertencia(Mensajes.get("I0229").replace("$0$", productos));
					//return;
				}
		 	}
			
			if(!obtenerTotalesDetallePedidoEscritorio(faseAnterior == TiposFasesDocto.CAPTURA_ESCRITORIO)){
				//config grid
				//poblar movs
			}else{
				//terminar
			}
			mVista.refrescarProductos(getTransaccionesIds());
			
		}
		catch (Exception e)
		{
			//mVista.mostrarError(e);
			mVista.mostrarError(e.getMessage());
		}
	}
	
	public boolean obtenerTotalesDetallePedidoEscritorio(boolean soloModificados) throws Exception{
		
		for(TransProdDetalle oTpd : transProdGeneral.TransProdDetalle){
			if(oTpd.Promocion != 2){
				if(soloModificados)
					oTpd.modificado = oTpd.CantidadOriginal != 0 && oTpd.CantidadOriginal != oTpd.Cantidad;
				else
					oTpd.modificado = true;
			}
		}
		
		for(TransProdDetalle oTpd : transProdGeneral.TransProdDetalle){
			if(oTpd.modificado){
				if(TransaccionesDetalle.Reparto.GenerarDetalleReparto(oTpd, transProdGeneral.CadenaListasPrecios) == null){
					//no tiene precio
					mVista.mostrarAdvertencia(Mensajes.get("NoExistePrecio")+" "+oTpd.ProductoClave);
					return false;
				}
				TransaccionesDetalle.Reparto.Actualizar(oTpd, transProdGeneral.CadenaListasPrecios);
				if(oTpd.CantidadOriginal != oTpd.Cantidad){
					float cantidadUnitaria = 0;
					float factor = Consultas.ConsultasProducto.obtenerFactor(oTpd.ProductoClave, oTpd.TipoUnidad);
					if(oTpd.CantidadOriginal > 0){
						//verificar cuotas
						cantidadUnitaria = oTpd.CantidadOriginal * factor;
						Cuotas.VerificarCuotas(vendedor.VendedorId, 1, cantidadUnitaria * -1, oTpd.ProductoClave);
						Cuotas.VerificarCuotas(vendedor.VendedorId, 3, cantidadUnitaria * -1, oTpd.ProductoClave);
					}
					cantidadUnitaria = oTpd.Cantidad * factor;
					Cuotas.VerificarCuotas(vendedor.VendedorId, 1, cantidadUnitaria, oTpd.ProductoClave);
					Cuotas.VerificarCuotas(vendedor.VendedorId, 3, cantidadUnitaria, oTpd.ProductoClave);
				}
			}
		}
		
		return true;
	}

    public Cursor obtenerSaldoEnvase() throws Exception{
        ISetDatos saldo = Consultas.ConsultasProductoPrestamoCli.obtenerSaldoEnvase(((Cliente)Sesion.get(Campo.ClienteActual)).ClienteClave);
        return (Cursor) saldo.getOriginal();
    }
	
}
