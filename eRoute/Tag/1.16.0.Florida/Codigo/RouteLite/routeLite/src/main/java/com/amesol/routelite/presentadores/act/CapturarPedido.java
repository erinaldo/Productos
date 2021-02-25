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
import com.amesol.routelite.actividades.InventarioDobleUnidad;
import com.amesol.routelite.actividades.ListaPrecio;
import com.amesol.routelite.actividades.ManejoEnvase;
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.actividades.Promociones2;
import com.amesol.routelite.actividades.Transacciones;
import com.amesol.routelite.actividades.TransaccionesDetalle;
import com.amesol.routelite.actividades.ValorReferencia;
import com.amesol.routelite.actividades.ValoresReferencia;
import com.amesol.routelite.controles.CapturaProducto;
import com.amesol.routelite.datos.Cliente;
import com.amesol.routelite.datos.Dia;
import com.amesol.routelite.datos.ModuloMovDetalle;
import com.amesol.routelite.datos.PedidoModificado;
import com.amesol.routelite.datos.Precio;
import com.amesol.routelite.datos.Producto;
import com.amesol.routelite.datos.ProductoDetalle;
import com.amesol.routelite.datos.ProductoPrestamoCli;
import com.amesol.routelite.datos.ProductoUnidad;
import com.amesol.routelite.datos.Ruta;
import com.amesol.routelite.datos.TPDDatosExtra;
import com.amesol.routelite.datos.TransProd;
import com.amesol.routelite.datos.TransProdDetalle;
import com.amesol.routelite.datos.Usuario;
import com.amesol.routelite.datos.Vendedor;
import com.amesol.routelite.datos.basedatos.BDVend;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.basedatos.Consultas2;
import com.amesol.routelite.datos.basedatos.Consultas.ConsultasCantidad;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.CONHist;
import com.amesol.routelite.datos.utilerias.ConfigParametro;
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
            BDVend.setOrigenLog("CapturarPedido:iniciar");
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
				HashMap<Integer, Precio> listasPrecio;

				if (((MOTConfiguracion)Sesion.get(Campo.MOTConfiguracion)).get("PrecioSegunCFVTipo").equals("1") ){
					Short iCFVTipo = 0;
					for(TransProd tran : transacciones.values()){
						iCFVTipo = tran.CFVTipo;
					}
					listasPrecio = ListaPrecio.Determinar(sClienteClave, moduloMovDetalle,iCFVTipo );
				}else {

					listasPrecio = ListaPrecio.Determinar(sClienteClave, moduloMovDetalle);
				}
                //recorrer todas las transacciones, parte de agrupar transacciones
				for(TransProd tran : transacciones.values()){

					transProdGeneral = tran;
					transProdGeneral.setListaPrecios(listasPrecio);
					transProdGeneral.PCEPrecioClave = listasPrecio.get(0).PrecioClave ;
					nTotalInicial += transProdGeneral.Total;
                    tran.TotalInicial = tran.Total;

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
                    if ( tran.TipoFase == TiposFasesDocto.SURTIDO ) {
                        Cuotas.CalcularCuotasXEfectivo(transProdGeneral, true);
                        Iterator<TransProdDetalle> it = transProdGeneral.TransProdDetalle.iterator();
                        while (it.hasNext()) {
                            TransProdDetalle oTpd = it.next();
                            actualizarCuotas(oTpd, true);
                        }
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
				String sOrganizacionVentas = "";
				if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).existeParametro("OrganizacionVentas")) {
					sOrganizacionVentas = ((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("OrganizacionVentas");
				}
				if (sOrganizacionVentas.length() > 0 && oCliente.Clave.startsWith(sOrganizacionVentas)) {
					if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).existeParametro("MaxVentasOportuno") && ((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("MaxVentasOportuno",((MOTConfiguracion)Sesion.get(Campo.MOTConfiguracion)).get("MCNClave").toString()) != null && Integer.parseInt(((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("MaxVentasOportuno",((MOTConfiguracion)Sesion.get(Campo.MOTConfiguracion)).get("MCNClave").toString()).toString())>0) {
						//((MOTConfiguracion)Sesion.get(Campo.MOTConfiguracion)).get("MCNClave")
						ISetDatos sdPedidosOportuno = null;
						int numPedidosOportuno = 0;
						int maxVentasOportuno = Integer.parseInt(((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("MaxVentasOportuno",((MOTConfiguracion)Sesion.get(Campo.MOTConfiguracion)).get("MCNClave").toString()).toString());
						String modulo = "";
						if (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.VENTA || Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO){
							sdPedidosOportuno =  Consultas.ConsultasTransProd.obtenerVentasOp();
							modulo = "ventas";
						}else if (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.PREVENTA){
							modulo = "pedidos";
							sdPedidosOportuno =  Consultas.ConsultasTransProd.obtenerPedidosOp();
						}
						if (sdPedidosOportuno.getCount()>0){
							sdPedidosOportuno.moveToFirst();
							numPedidosOportuno = sdPedidosOportuno.getInt("TotalPedidos");
						}
						if (sdPedidosOportuno != null){
							sdPedidosOportuno.close();
						}
						if (numPedidosOportuno >= maxVentasOportuno ){
							if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).existeParametro("PermiteExcederMaxOportuno", ((MOTConfiguracion)Sesion.get(Campo.MOTConfiguracion)).get("MCNClave").toString()) && ((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("PermiteExcederMaxOportuno", ((MOTConfiguracion)Sesion.get(Campo.MOTConfiguracion)).get("MCNClave").toString()).equals("1")) {
								mVista.mostrarAdvertencia(Mensajes.get("E0967",modulo, "Cliente Oportuno"));
							}else{
								throw new Exception(Mensajes.get("E0967",modulo, "Cliente Oportuno"));
							}
						}
					}
				}

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
        BDVend.setOrigenLog("CapturarPedido:actualizarCuotas");
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

    public String getListasPreciosPedido()
	{
		return transProdGeneral.PCEPrecioClave ;
	}

	public String getNombreListaPrecioInicial()
	{
		if (transProdGeneral.getListaPrecios().size()>0) {
			return transProdGeneral.getListaPrecios().get(0).PrecioClave + "-" + transProdGeneral.getListaPrecios().get(0).Nombre;
		}
		return "";
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
        BDVend.setOrigenLog("CapturarPedido:agregarProductoUnidad_1");
		generarDetalle(producto, transProdDetalle, refrescarListado);
	}
	
	/*public void agregarProductoUnidad(String subEmpresaID, TransProdDetalle transProdDetalle, boolean refrescarListado)
	{
		generarDetalle(subEmpresaID, transProdDetalle, refrescarListado);
	}*/

	public void agregarProductoUnidad(String productoClave, String subEmpresaId, int TipoUnidad, Float Cantidad, Float PrecioEspecial, Boolean modificacionPrecio, String ListaPrecioEspecial)
	{
		BDVend.setOrigenLog("CapturarPedido:agregarProductoUnidad_2");
		if (modificacionPrecio){
			generarDetalle(productoClave, subEmpresaId, TipoUnidad, Cantidad, PrecioEspecial, false, (float) 0, null,ListaPrecioEspecial,0);
		}else{
			generarDetalle(productoClave, subEmpresaId, TipoUnidad, Cantidad, PrecioEspecial, false, (float) 0, null,null,0);
		}

	}

	public void agregarProductoUnidad(String productoClave, String subEmpresaId, int TipoUnidad, Float Cantidad, Float PrecioEspecial)
	{
        BDVend.setOrigenLog("CapturarPedido:agregarProductoUnidad_2");
		generarDetalle(productoClave, subEmpresaId, TipoUnidad, Cantidad, PrecioEspecial, false, (float) 0, null,null,0);
	}
	
	public void agregarProductoUnidad(String productoClave, String subEmpresaId, int TipoUnidad, Float Cantidad, Float PrecioEspecial, Float CantidadOriginal)
	{
        BDVend.setOrigenLog("CapturarPedido:agregarProductoUnidad_3");
		generarDetalle(productoClave, subEmpresaId, TipoUnidad, Cantidad, PrecioEspecial, true, CantidadOriginal, null,null,0);
	} 
	
	public void agregarProductoUnidad(String productoClave, String subEmpresaId, int TipoUnidad, Float Cantidad, Float PrecioEspecial, String TransProdDetalleID)
	{
        BDVend.setOrigenLog("CapturarPedido:agregarProductoUnidad_4");
		generarDetalle(productoClave, subEmpresaId, TipoUnidad, Cantidad, PrecioEspecial, false, (float) 0, TransProdDetalleID,null,0);
	}
	
	public void agregarProductoUnidad(String productoClave, String subEmpresaId, int TipoUnidad, Float Cantidad, Float PrecioEspecial, Float CantidadOriginal, String TransProdDetalleID, int Partida)
	{
        BDVend.setOrigenLog("CapturarPedido:agregarProductoUnidad_5");
		generarDetalle(productoClave, subEmpresaId, TipoUnidad, Cantidad, PrecioEspecial, true, CantidadOriginal, TransProdDetalleID,null,Partida);
	}

	public void agregarProductoDobleUnidad(HashMap<Short, InventarioDobleUnidad.DetalleProductoDobleUnidad> hmDetalleDobleUnidad, String productoClave,  String subEmpresaId, String TransProdDetalleID){
        BDVend.setOrigenLog("CapturarPedido:agregarProductoDobleUnidad");
		generarDetalleDobleUnidad(productoClave, hmDetalleDobleUnidad, subEmpresaId,   TransProdDetalleID);
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
        BDVend.setOrigenLog("CapturarPedido:validarProductoContenido");
		Producto oProducto = Consultas.ConsultasProducto.obtenerProducto(ProductoClave);

		if (oProducto.Contenido && !oProducto.Venta)
		{
			throw new ControlError("E0725");
		}

		return true;
	}

    public float obtenerSaldoDeEnvase(String ProductoClave){
        BDVend.setOrigenLog("CapturarPedido:obtenerSaldoDeEnvase");
        try {
            return Consultas2.ConsultasProductoPrestamoCli.obtenerSaldoEnvase(((Cliente) Sesion.get(Campo.ClienteActual)).ClienteClave, ProductoClave);
        }catch (Exception e)
        {
            return 0;
        }
    }

	@SuppressWarnings("rawtypes")
	public void eliminarPromos()
	{
        BDVend.setOrigenLog("CapturarPedido:eliminarPromos");
        if ((!mVista.getSoloLectura() && !mVista.getSurtir()) || (mVista.getSurtir() && mVista.getModificandoPedidoReparto())) {
            try {
                Iterator it = transacciones.entrySet().iterator();
                TransProd oTRP;
                while (it.hasNext()) {
                    Map.Entry e = (Map.Entry) it.next();
                    oTRP = (TransProd) e.getValue();
                    Promociones2 promociones = new Promociones2(oTRP, mVista.getModificandoPedidoReparto());
                    promociones.Preparar();
                }
            } catch (Exception e) {
                //mVista.mostrarError(e);
                mVista.mostrarError(e.getMessage());
            }
        }
	}
	
	//private void generarDetalle(String subEmpresaId, TransProdDetalle transProdDetalle, boolean refrescarListado)
	@SuppressWarnings("unused")
	private void generarDetalle(Producto producto, TransProdDetalle transProdDetalle, boolean refrescarListado)
	{
        BDVend.setOrigenLog("CapturarPedido:generarDetalle_1");
		try
		{
            producto.obtenerExcepcionSubEmpresaID(((Cliente)Sesion.get(Campo.ClienteActual)).ClienteClave);
			String subEmpresaId = producto.SubEmpresaId;
			StringBuilder byRefMensaje = new StringBuilder();

			transProdGeneral = Transacciones.Pedidos.ActualizarGenerarPedido(transacciones, subEmpresaId,  moduloMovDetalle, mVista.getModificandoPedidoNoReparto(), byRefMensaje);
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
            if (transProdDetalle.TPDDatosExtra != null && transProdDetalle.TPDDatosExtra.size()>0){
                if (transProdDetalle.TPDDatosExtra.get(0).TransProdID == null || transProdDetalle.TPDDatosExtra.get(0).TransProdID.length()<=0){
                    transProdDetalle.TPDDatosExtra.get(0).TransProdID = transProdDetalle.TransProdID;
                }
            }
			TransaccionesDetalle.Pedidos.CalcularTotalesDetallePedido(transProdDetalle);

			if (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.VENTA || Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO || (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.PREVENTA && ((Ruta) Sesion.get(Campo.RutaActual)).Inventario))
			{
                if (!(producto.Contenido && producto.Venta)){
                    Inventario.ActualizarInventario(transProdDetalle.ProductoClave, transProdDetalle.TipoUnidad, transProdDetalle.Cantidad, moduloMovDetalle.TipoTransProd, moduloMovDetalle.TipoMovimiento, vendedor.AlmacenID);
                }
			}
			
			Cliente cli = ((Cliente)Sesion.get(Campo.ClienteActual));
			if((Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.VENTA || Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO) &&
                    cli.Prestamo && (transProdGeneral.Tipo == TiposTransProd.PEDIDO || transProdGeneral.Tipo == TiposTransProd.VENTA_CONSIGNACION)){
				ManejoEnvase.manejoEnvase(producto, transProdDetalle.TipoUnidad, transProdDetalle.Cantidad, transProdDetalle, transProdGeneral);
			}

			if (transProdDetalle == null) {
                if (Transacciones.Pedidos.EliminarSiNoHayDetalle(transProdGeneral.TransProdID)) {
                    TransProd trp = transacciones.get(subEmpresaId);//Transacciones.Pedidos.ObtenerPedido(transProdId);
                    if (transacciones.size() > 1) { //si hay mas de una transaccion eliminar la que no tiene detalle
                        //Consultas.ConsultasTRPGrupo.eliminarTransaccionGrupo(trp.TransProdID); //eliminar el registro del grupo antes de eliminar el transprod
                        BDVend.eliminar(trp);
                        if (transacciones.containsKey(trp.SubEmpresaId))
                            transacciones.remove(trp.SubEmpresaId);
                    } else { //si es la unica y ya no tiene detalle, borrar subempresa
                        trp.SubEmpresaId = "";
                        BDVend.guardarInsertar(trp);
                    }
                }
                throw new ControlError("MDB042302");
            }
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

	private void generarDetalle(String productoClave, String subEmpresaId, int TipoUnidad, Float Cantidad, Float PrecioEspecial, boolean setCantidadOriginal, Float CantidadOriginal, String TransProdDetalleID, String ListaPrecioEspecial, int Partida)
	{
        BDVend.setOrigenLog("CapturarPedido:generarDetalle_2");
		try
		{
 
			StringBuilder byRefMensaje = new StringBuilder();
			transProdGeneral = Transacciones.Pedidos.ActualizarGenerarPedido(transacciones, subEmpresaId, moduloMovDetalle, mVista.getModificandoPedidoNoReparto(), byRefMensaje);
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
			String CadenaListasPrecios = transProdGeneral.CadenaListasPrecios;
			if (ListaPrecioEspecial !=null && ListaPrecioEspecial.length()>0){
				CadenaListasPrecios = "'" + ListaPrecioEspecial + "'";
			}

			TransProdDetalle transProdDetalle = TransaccionesDetalle.Pedidos.GenerarDetallePedido(transProdGeneral.TransProdID, productoClave, TipoUnidad, Cantidad, 0, CadenaListasPrecios, PrecioEspecial, TransProdDetalleID);

			if (transProdDetalle == null){
                if (Transacciones.Pedidos.EliminarSiNoHayDetalle(transProdGeneral.TransProdID)) {
                    TransProd trp = transacciones.get(subEmpresaId);//Transacciones.Pedidos.ObtenerPedido(transProdId);
                    if (transacciones.size() > 1) { //si hay mas de una transaccion eliminar la que no tiene detalle
                        //Consultas.ConsultasTRPGrupo.eliminarTransaccionGrupo(trp.TransProdID); //eliminar el registro del grupo antes de eliminar el transprod
                        BDVend.eliminar(trp);
                        if (transacciones.containsKey(trp.SubEmpresaId))
                            transacciones.remove(trp.SubEmpresaId);
                    } else { //si es la unica y ya no tiene detalle, borrar subempresa
                        trp.SubEmpresaId = "";
                        BDVend.guardarInsertar(trp);
                    }
                }
                throw new ControlError("MDB042302");
            }
			else
			{
                if(setCantidadOriginal) {
					transProdDetalle.CantidadOriginal = CantidadOriginal;
					transProdDetalle.Partida = Partida;
				}

                if (tipoValidacionExistencia != TiposValidacionInventario.NoValidar)
                {
                    Producto oProd = new Producto();
                    oProd.ProductoClave = productoClave;
                    BDVend.recuperar(oProd);
                    if (!(oProd.Contenido && oProd.Venta)){
                        //Solo si realmente es un reparto. Si es venta directa en reparto debe entrar al segundo actualizar.
                        if (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO && mVista.getReparto())
                            //Inventario.ActualizarInventario(productoClave, TipoUnidad, Cantidad, moduloMovDetalle.TipoTransProd, TiposMovimientos.ENTRADA, vendedor.AlmacenID);
                            Inventario.ActualizarInventario(productoClave, TipoUnidad, Cantidad, moduloMovDetalle.TipoTransProd, TiposMovimientos.ENTRADA, vendedor.AlmacenID, null, false, null, 0, true);
                        else
                            Inventario.ActualizarInventario(productoClave, TipoUnidad, Cantidad, moduloMovDetalle.TipoTransProd, moduloMovDetalle.TipoMovimiento, vendedor.AlmacenID);
                    }

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

	private void generarDetalleDobleUnidad(String productoClave,HashMap<Short,InventarioDobleUnidad.DetalleProductoDobleUnidad>hmDetallesDobleUnidad , String subEmpresaId, String TransProdDetalleID)
	{
        BDVend.setOrigenLog("CapturarPedido:generarDetalleDobleUnidad");
		try
		{

			StringBuilder byRefMensaje = new StringBuilder();
			transProdGeneral = Transacciones.Pedidos.ActualizarGenerarPedido(transacciones, subEmpresaId, moduloMovDetalle, mVista.getModificandoPedidoNoReparto(), byRefMensaje);
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

			TransProdDetalle transProdDetalle = TransaccionesDetalle.Pedidos.GenerarDetallePedidoDobleUnidad(transProdGeneral.TransProdID, productoClave, hmDetallesDobleUnidad, transProdGeneral.CadenaListasPrecios, TransProdDetalleID, Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO && (mVista.getSurtir() || mVista.getModificandoPedidoReparto()));

			if (transProdDetalle == null) {
                if (Transacciones.Pedidos.EliminarSiNoHayDetalle(transProdGeneral.TransProdID)) {
                    TransProd trp = transacciones.get(subEmpresaId);//Transacciones.Pedidos.ObtenerPedido(transProdId);
                    if (transacciones.size() > 1) { //si hay mas de una transaccion eliminar la que no tiene detalle
                        //Consultas.ConsultasTRPGrupo.eliminarTransaccionGrupo(trp.TransProdID); //eliminar el registro del grupo antes de eliminar el transprod
                        BDVend.eliminar(trp);
                        if (transacciones.containsKey(trp.SubEmpresaId))
                            transacciones.remove(trp.SubEmpresaId);
                    } else { //si es la unica y ya no tiene detalle, borrar subempresa
                        trp.SubEmpresaId = "";
                        BDVend.guardarInsertar(trp);
                    }
                }
                throw new ControlError("MDB042302");
            }
			else
			{
                if (tipoValidacionExistencia != TiposValidacionInventario.NoValidar)
                {
                    //Solo si realmente es un reparto. Si es venta directa en reparto debe entrar al segundo actualizar.
                    if(Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO && mVista.getReparto())
                        //Inventario.ActualizarInventario(productoClave, TipoUnidad, Cantidad, moduloMovDetalle.TipoTransProd, TiposMovimientos.ENTRADA, vendedor.AlmacenID);
                        InventarioDobleUnidad.ActualizarInventario(productoClave, hmDetallesDobleUnidad, moduloMovDetalle.TipoTransProd, TiposMovimientos.ENTRADA,null,false, null,true);
                    else
                        InventarioDobleUnidad.ActualizarInventario(productoClave, hmDetallesDobleUnidad, moduloMovDetalle.TipoTransProd, moduloMovDetalle.TipoMovimiento);

				/*No se maneja envase con la doble Unidad*/
                }

				BDVend.guardarInsertar(transProdDetalle);
				mVista.setHuboCambios(true);
				mVista.refrescarProductos(getTransaccionesIds());
				//posicionar la lista en el producto que se agrego para capturar cantidad
				//mVista.seleccionarProducto(productoClave, String.valueOf(TipoUnidad));
			}


		}
		catch (Exception ex)
		{
			//mVista.mostrarError(ex);
			mVista.mostrarError(ex.getMessage() == null ? ex.getCause().getMessage() : ex.getMessage());
		}

	}

    public void eliminarDetalle(String transProdId, String transProdDetalleId, String subEmpresaId, String productoClave, int TipoUnidad, float Cantidad){
        BDVend.setOrigenLog("CapturarPedido:eliminarDetalle_1");
        eliminarDetalle(transProdId, transProdDetalleId, subEmpresaId, productoClave, TipoUnidad, Cantidad, true);
    }
	//Se usa tambien para la doble unidad. Si hay cambios que afecten, se tendra que hacer otra funcion
	public void eliminarDetalle(String transProdId, String transProdDetalleId, String subEmpresaId, String productoClave, int TipoUnidad, float Cantidad, boolean validarTrpSinDetalle)
	{
        BDVend.setOrigenLog("CapturarPedido:eliminarDetalle_2");
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
                        if(((Cliente) Sesion.get(Campo.ClienteActual)).Prestamo){
                            if(tpd.PrestamoVendido != cantidadUM)
                                Inventario.ActualizarInventario(productoClave, TipoUnidad, Cantidad, moduloMovDetalle.TipoTransProd, TiposMovimientos.ENTRADA, vendedor.AlmacenID, true, tpd.PrestamoVendido);
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
                        if(((Cliente) Sesion.get(Campo.ClienteActual)).Prestamo){
                            if(tpd.PrestamoVendido != cantidadUM)
                                Inventario.ActualizarInventario(productoClave, TipoUnidad, Cantidad, moduloMovDetalle.TipoTransProd, moduloMovDetalle.TipoMovimiento, vendedor.AlmacenID, true, tpd.PrestamoVendido);
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

	public void eliminarDetalleDobleUnidad(String transProdId, String transProdDetalleId, String subEmpresaId, String productoClave, HashMap<Short, InventarioDobleUnidad.DetalleProductoDobleUnidad> hmCantidadDobleUnidad, boolean validarTrpSinDetalle)
	{
        BDVend.setOrigenLog("CapturarPedido:eliminarDetalleDobleUnidad");
		try
		{
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
						InventarioDobleUnidad.ActualizarInventario(productoClave, hmCantidadDobleUnidad, moduloMovDetalle.TipoTransProd, TiposMovimientos.ENTRADA, vendedor.AlmacenID, true);
				}else{
						InventarioDobleUnidad.ActualizarInventario(productoClave, hmCantidadDobleUnidad, moduloMovDetalle.TipoTransProd, moduloMovDetalle.TipoMovimiento, vendedor.AlmacenID, true);
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
        BDVend.setOrigenLog("CapturarPedido:consultarPromociones");
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
        BDVend.setOrigenLog("CapturarPedido:obtenerInventarioEnLinea");
		HashMap<String, String> parametros = new HashMap<String, String>();
		String tablasActualizar = "''Inventario''";
		parametros.put("Tablas", tablasActualizar);
		mVista.iniciarActividadConResultado(IServidorComunicaciones.class, Enumeradores.Solicitudes.SOLICITUD_SERVIDOR_COMUNICACIONES, Enumeradores.Acciones.ACCION_RECIBIR_INFO_INVENTARIO, parametros);
	}

	public String consultarUnidadProductoExistente(String TransProdID, String ProductoClave)
	{
        BDVend.setOrigenLog("CapturarPedido:consultarUnidadProductoExistente");
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
        BDVend.setOrigenLog("CapturarPedido:validarInventarioASurtir");
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

	public ArrayList<TransProdDetalle> validarInventarioASurtirDobleUnidad() throws Exception {
        BDVend.setOrigenLog("CapturarPedido:validarInventarioASurtirDobleUnidad");
		ArrayList<TransProdDetalle> aRes = new ArrayList<TransProdDetalle>();
		Iterator<TransProd> docsTransProd = getHashMapTransacciones().values().iterator();
		if (docsTransProd.hasNext())
		{
			Iterator<TransProdDetalle> oTpd = docsTransProd.next().getTransProdDetalle().iterator();
			ArrayList<String> productos = new ArrayList<>();
			while(oTpd.hasNext()){
				AtomicReference<Float> existencia = new AtomicReference<Float>();
				StringBuilder error = new StringBuilder();
				TransProdDetalle tpd = oTpd.next();

				if(!InventarioDobleUnidad.ValidarExistenciaDifNoDisponible(tpd.ProductoClave, Short.parseShort(String.valueOf(tpd.TipoUnidad)), tpd.Cantidad, existencia, error)){
					if(!productos.contains(tpd.ProductoClave)){
						aRes.add(tpd);
						productos.add(tpd.ProductoClave);
					}
				}

				BDVend.recuperar(tpd, TPDDatosExtra.class);
				if (tpd.isRecuperado() && tpd.TPDDatosExtra !=null && tpd.TPDDatosExtra.size()>0 && tpd.TPDDatosExtra.get(0).UnidadAlterna != null && tpd.TPDDatosExtra.get(0).UnidadAlterna >0){
					if(!InventarioDobleUnidad.ValidarExistenciaDifNoDisponible(tpd.ProductoClave, Short.parseShort(String.valueOf(tpd.TPDDatosExtra.get(0).UnidadAlterna)), tpd.TPDDatosExtra.get(0).CantidadAlterna, existencia, error)){
						if(!productos.contains(tpd.ProductoClave)){
							aRes.add(tpd);
							productos.add(tpd.ProductoClave);
						}
					}
				}
			}
		}
		return aRes;
	}

	public ArrayList<TransProdDetalle> validarInventarioASurtirModificar() throws Exception{
        BDVend.setOrigenLog("CapturarPedido:validarInventarioASurtirModificar");
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

	public ArrayList<TransProdDetalle> validarInventarioASurtirModificarDobleUnidad() throws Exception{
        BDVend.setOrigenLog("CapturarPedido:validarInventarioASurtirModificarDobleUnidad");
		ArrayList<TransProdDetalle> aRes = new ArrayList<TransProdDetalle>();
		Iterator<TransProd> docsTransProd = getHashMapTransacciones().values().iterator();
		if (docsTransProd.hasNext())
		{
			Iterator<TransProdDetalle> oTpd = docsTransProd.next().getTransProdDetalle().iterator();
			ArrayList<String> aProductoSinExistencia = new ArrayList<>();
			while(oTpd.hasNext()){
				boolean existeUnidadAlterna = false;
				AtomicReference<Float> existencia = new AtomicReference<Float>();
				StringBuilder error = new StringBuilder();
				TransProdDetalle tpd = oTpd.next();
				BDVend.recuperar(tpd, TPDDatosExtra.class);
				HashMap<Short, InventarioDobleUnidad.DetalleProductoDobleUnidad> hmDetalleUnidades = new HashMap<Short, InventarioDobleUnidad.DetalleProductoDobleUnidad>();
				hmDetalleUnidades.put(Short.parseShort(String.valueOf(tpd.TipoUnidad)), new InventarioDobleUnidad.DetalleProductoDobleUnidad(Short.parseShort(String.valueOf(tpd.TipoUnidad)), null,tpd.Cantidad, null, null,null,null));
				if(tpd.TPDDatosExtra.size() >0 && tpd.TPDDatosExtra.get(0).UnidadAlterna != null && tpd.TPDDatosExtra.get(0).UnidadAlterna>0){
					existeUnidadAlterna = true;
					hmDetalleUnidades.put(tpd.TPDDatosExtra.get(0).UnidadAlterna, new InventarioDobleUnidad.DetalleProductoDobleUnidad(tpd.TPDDatosExtra.get(0).UnidadAlterna,null,tpd.TPDDatosExtra.get(0).CantidadAlterna, null,null,null,null ));
				}

				boolean productoSinExistencia = false;
				if(!InventarioDobleUnidad.ValidarExistenciaDifNoDisponible(tpd.ProductoClave,Short.parseShort(String.valueOf(tpd.TipoUnidad)), tpd.Cantidad, existencia, error)){

					tpd.Cantidad = existencia.get();
					tpd.MFechaHora = Generales.getFechaHoraActual();
					tpd.MUsuarioID = ((Usuario)Sesion.get(Campo.UsuarioActual)).USUId;
					tpd.Enviado = false;
					productoSinExistencia =true;
					if(!aProductoSinExistencia.contains(tpd.ProductoClave)){
						aRes.add(tpd);
						aProductoSinExistencia.add(tpd.ProductoClave);
					}
				}

				if(existeUnidadAlterna){
					if(!InventarioDobleUnidad.ValidarExistenciaDifNoDisponible(tpd.ProductoClave,Short.parseShort(String.valueOf(tpd.TPDDatosExtra.get(0).UnidadAlterna)), tpd.TPDDatosExtra.get(0).CantidadAlterna, existencia, error)){
						tpd.TPDDatosExtra.get(0).CantidadAlterna = existencia.get();
						tpd.TPDDatosExtra.get(0).MFechaHora = Generales.getFechaHoraActual();
						tpd.TPDDatosExtra.get(0).MUsuarioID = ((Usuario)Sesion.get(Campo.UsuarioActual)).USUId;
						tpd.TPDDatosExtra.get(0).Enviado = false;
						productoSinExistencia =true;
						if(!aProductoSinExistencia.contains(tpd.ProductoClave)){
							aRes.add(tpd);
							aProductoSinExistencia.add(tpd.ProductoClave);
						}
					}
				}

				if(productoSinExistencia){
					InventarioDobleUnidad.ActualizarInventario(tpd.ProductoClave, hmDetalleUnidades, TiposTransProd.PEDIDO, TiposMovimientos.ENTRADA,  true);

					//Se agrega la nueva cantidad de acuerdo a la existencia, para actualizar el inventario
					hmDetalleUnidades.get(Short.parseShort(String.valueOf(tpd.TipoUnidad))).Cantidad = tpd.Cantidad;
					if (existeUnidadAlterna && hmDetalleUnidades.containsKey(tpd.TPDDatosExtra.get(0).UnidadAlterna)){

						hmDetalleUnidades.get(tpd.TPDDatosExtra.get(0).UnidadAlterna).Cantidad = tpd.TPDDatosExtra.get(0).CantidadAlterna;
					}

					boolean errorPeso = false;
					if(tpd.Cantidad > 0 || (existeUnidadAlterna && tpd.TPDDatosExtra.get(0).CantidadAlterna >0)){
						String sValores = ValoresReferencia.getStringVAVClave("UNIDADV", "VARIABLE");

						if (existeUnidadAlterna){
							String[] aValoresXRef = sValores.split(",");
							ProductoUnidad pruTpd = new ProductoUnidad();
							pruTpd.ProductoClave = tpd.ProductoClave;
							pruTpd.PRUTipoUnidad = Short.parseShort(String.valueOf(tpd.TipoUnidad));
							BDVend.recuperar(pruTpd);

							if (hmDetalleUnidades.containsKey(pruTpd.PRUTipoUnidad)){
								hmDetalleUnidades.get(pruTpd.PRUTipoUnidad).DecimalProducto = Short.parseShort(String.valueOf(pruTpd.DecimalProducto)) ;
							}
							ProductoUnidad pruAlt = new ProductoUnidad();
							pruAlt.ProductoClave = tpd.ProductoClave;
							pruAlt.PRUTipoUnidad = Short.parseShort(String.valueOf(tpd.TPDDatosExtra.get(0).UnidadAlterna));
							BDVend.recuperar(pruAlt);
							if (hmDetalleUnidades.containsKey(pruAlt.PRUTipoUnidad)){
								hmDetalleUnidades.get(pruAlt.PRUTipoUnidad).DecimalProducto = Short.parseShort(String.valueOf(pruAlt.DecimalProducto)) ;
							}
							if (tpd.TipoUnidad == Short.parseShort(String.valueOf(aValoresXRef[0]))){
								Float cantidadCalculada = (pruAlt.KgLts * tpd.TPDDatosExtra.get(0).CantidadAlterna);
								Float variacionKilos = (cantidadCalculada * pruTpd.PorcentajeVariacion ) / 100;
								int decimales = pruTpd.DecimalProducto;
								if ((Generales.getRound(tpd.Cantidad,decimales) >   Generales.getRound(cantidadCalculada + variacionKilos,decimales)) || (Generales.getRound(tpd.Cantidad,decimales) <   Generales.getRound(cantidadCalculada - variacionKilos,decimales)) ){
									errorPeso = true;
								}
							}else if (tpd.TPDDatosExtra.get(0).UnidadAlterna == Short.parseShort(String.valueOf(aValoresXRef[0]))){
								Float cantidadCalculada = (pruTpd.KgLts * tpd.Cantidad);
								Float variacionKilos = (cantidadCalculada * pruAlt.PorcentajeVariacion) / 100;
								int decimales = pruAlt.DecimalProducto;
								if ((Generales.getRound(tpd.TPDDatosExtra.get(0).CantidadAlterna, decimales ) >   Generales.getRound(cantidadCalculada + variacionKilos, decimales)) || (Generales.getRound(tpd.TPDDatosExtra.get(0).CantidadAlterna, decimales) <   Generales.getRound(cantidadCalculada - variacionKilos,decimales)) ){
									errorPeso = true;
								}
							}
							if(errorPeso){
								tpd.Cantidad = 0;
								tpd.TPDDatosExtra.get(0).CantidadAlterna = 0f;
							}
						}
						//String productoClave, int tipoUnidad, float cantidad, int tipoTransProd, int tipoMovimiento, String almacenID, String grupoMotivo, boolean cancelacion, String clienteClave, float prestamoVendido, boolean surtirPedido
						if (!errorPeso) {
							InventarioDobleUnidad.ActualizarInventario(tpd.ProductoClave, hmDetalleUnidades, TiposTransProd.PEDIDO, TiposMovimientos.ENTRADA, "", false, transProdGeneral.ClienteClave, true);
						}else{
							mVista.mostrarError(Mensajes.get("E0957") + " " + Mensajes.get("XProducto") + ": " + tpd.ProductoClave );
						}
					}
				}/*else{
					InventarioDobleUnidad.ActualizarInventario(tpd.ProductoClave, hmDetalleUnidades, TiposTransProd.PEDIDO, TiposMovimientos.SALIDA, "",false,"",0,mVista.getSurtir() || mVista.getModificando());
				}*/
				//No se implemento manejo de envase en la doble Unidad
			}
		}
		return aRes;
	}

	public void modificarPedido(){
        BDVend.setOrigenLog("CapturarPedido:modificarPedido");
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

	public void modificarPedidoDobleUnidad(){
        BDVend.setOrigenLog("CapturarPedido:modificarPedidoDobleUnidad");
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
				BDVend.recuperar(oTpd,TPDDatosExtra.class);
				if (oTpd.TPDDatosExtra !=null && oTpd.TPDDatosExtra.size()>0 && oTpd.TPDDatosExtra.get(0).UnidadAlterna != null && oTpd.TPDDatosExtra.get(0).UnidadAlterna >0){
					oTpd.TPDDatosExtra.get(0).CantidadAlternaOriginal = oTpd.TPDDatosExtra.get(0).CantidadAlterna;
					oTpd.TPDDatosExtra.get(0).MFechaHora =  Generales.getFechaHoraActual();
					oTpd.TPDDatosExtra.get(0).MUsuarioID = ((Usuario)Sesion.get(Campo.UsuarioActual)).USUId;
					oTpd.TPDDatosExtra.get(0).Enviado = false;
				}
				BDVend.guardarInsertar(oTpd);
			}

			if(faseAnterior != TiposFasesDocto.CAPTURA_ESCRITORIO){
				HashMap<Integer,Precio> listasPrecios = ListaPrecio.Determinar(sClienteClave, moduloMovDetalle);
				transProdGeneral.setListaPrecios(listasPrecios);
				mVista.setListaPrecios(transProdGeneral.getListaPrecios().get(0).PrecioClave + "-" + transProdGeneral.getListaPrecios().get(0).Nombre);
				eliminarPromos();
				mVista.setEsNuevo(true);
			}

			ArrayList<TransProdDetalle> prodSinExistencia = validarInventarioASurtirModificarDobleUnidad();

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
        BDVend.setOrigenLog("CapturarPedido:obtenerTotalesDetallePedidoEscritorio");
		for(TransProdDetalle oTpd : transProdGeneral.TransProdDetalle){
			if(oTpd.Promocion != 2 && oTpd.Promocion != 3){
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
				if (((MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion)).get("ManejoDobleUnidad").toString().equals("1")) {
					TransaccionesDetalle.Reparto.ActualizarDobleUnidad(oTpd, transProdGeneral.CadenaListasPrecios);
				}else{
					TransaccionesDetalle.Reparto.Actualizar(oTpd, transProdGeneral.CadenaListasPrecios);
				}

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
        BDVend.setOrigenLog("CapturarPedido:obtenerSaldoEnvase");
        ISetDatos saldo = Consultas.ConsultasProductoPrestamoCli.obtenerSaldoEnvase(((Cliente)Sesion.get(Campo.ClienteActual)).ClienteClave);
        return (Cursor) saldo.getOriginal();
    }
}
