package com.amesol.routelite.presentadores.act;

import java.text.DecimalFormat;
import java.text.NumberFormat;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import android.database.Cursor;

import com.amesol.routelite.actividades.Clientes;
import com.amesol.routelite.actividades.Cuotas;
import com.amesol.routelite.actividades.Folios;
import com.amesol.routelite.actividades.Impuestos;
import com.amesol.routelite.actividades.Inventario;
import com.amesol.routelite.actividades.ManejoEnvase;
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.actividades.ModuloMovDetalle;
import com.amesol.routelite.actividades.Promociones2;
import com.amesol.routelite.actividades.Promociones2.onTerminarAplicacionListener;
import com.amesol.routelite.actividades.Recibos;
import com.amesol.routelite.actividades.Transacciones;
import com.amesol.routelite.actividades.ValoresReferencia;
import com.amesol.routelite.datos.Cliente;
import com.amesol.routelite.datos.Dia;
import com.amesol.routelite.datos.Impuesto;
import com.amesol.routelite.datos.Producto;
import com.amesol.routelite.datos.TransProd;
import com.amesol.routelite.datos.TransProdDetalle;
import com.amesol.routelite.datos.TrpTpd;
import com.amesol.routelite.datos.Usuario;
import com.amesol.routelite.datos.Vendedor;
import com.amesol.routelite.datos.Visita;
import com.amesol.routelite.datos.basedatos.BDVend;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.CONHist;
import com.amesol.routelite.datos.utilerias.ConfigParametro;
import com.amesol.routelite.datos.utilerias.MOTConfiguracion;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.Presentador;
import com.amesol.routelite.presentadores.act.SeleccionarConsignacion.VistaConsignacion;
import com.amesol.routelite.presentadores.interfaces.ICapturaLiquidacionConsignacion;
import com.amesol.routelite.presentadores.interfaces.ICapturaTotalesConsignacion;
import com.amesol.routelite.utilerias.ControlError;
import com.amesol.routelite.utilerias.Generales;
import com.amesol.routelite.utilerias.KeyGen;
import com.amesol.routelite.vistas.CapturaLiquidacionConsignacion;
import com.amesol.routelite.vistas.Vista;

public class CapturarLiquidacionConsignacion extends Presentador
{

	public static final int LIQUIDACION_GENERA_DEVOLUCION = 1;
	public static final int LIQUIDACION_GENERA_CONSIGNACION = 2;
	
	private static final int CONTINUA_NUEVA_CONSIGNA = 0;
	private static final int CONTINUA_SIN_CONSIGNA = 1;
	private static final int CONTINUA_VTA = 2;
	private static final int CONTINUA_VTA_PROMOCIONES = 3;
	private static final int FINALIZA = 4;
	
	private ICapturaLiquidacionConsignacion mVista;
	private TransProd consigna;
	
	private TransProd transNuevaConsig;
	private TransProd transDev;
	private TransProd transVta;
	
	private VistaConsignacionLiquidacion[] detalleProductos;
	private float numDevoluciones, numLiquidaciones, importeLiquidar, importeDev, abonosAnteriores;
	private Float importeSaldo, importeDevAnteriores;
	private int tipoLiquidacion = LIQUIDACION_GENERA_DEVOLUCION;
	private List<String> transacciones;
	private Promociones2 promociones;
	
	public CapturarLiquidacionConsignacion(ICapturaLiquidacionConsignacion capturaLiquidacionConsignacion)
	{
		mVista = capturaLiquidacionConsignacion;
		transacciones = new ArrayList<String>();
	}

	@Override
	public void iniciar()
	{
		VistaConsignacion vConsignacion = (VistaConsignacion) Sesion.get(Campo.VistaConsignacion);
		
		consigna = new TransProd();
		consigna.TransProdID = vConsignacion.TransProdId;
		try{
			BDVend.recuperar(consigna);
			mVista.iniciar();
			mVista.setFolio(consigna.Folio);
			mVista.setFecha(Generales.getFormatoFecha(consigna.FechaCaptura, "dd/MM/yyyy"));
			cargaDetalleConsignacion();
		}catch(Exception ex){
			mVista.mostrarError(ex.getMessage());
		}
	}
	
	public Promociones2 getPromociones()
	{
		return promociones;
	}
	
	private void cargaDetalleConsignacion() throws Exception{
		ISetDatos detalle = Consultas.ConsultasTransProdDetalle.obtenerDetalleLiquidacionConsignacion(consigna.TransProdID);
		List<VistaConsignacionLiquidacion> transProdDet = new ArrayList<CapturarLiquidacionConsignacion.VistaConsignacionLiquidacion>();
		importeDevAnteriores = 0f;
		while(detalle.moveToNext()){
			VistaConsignacionLiquidacion vistaDetalle = new VistaConsignacionLiquidacion();
			vistaDetalle.TransProdDetalleId = detalle.getString(0);
			vistaDetalle.Nombre = detalle.getString(1);
			vistaDetalle.ProductoClave = detalle.getString(2);
			vistaDetalle.Cantidad = detalle.getFloat(3);
			vistaDetalle.Precio = detalle.getFloat(4);
			vistaDetalle.Total = detalle.getFloat(5);
			vistaDetalle.DecimalProducto = detalle.getInt(6);
			vistaDetalle.TipoUnidad = detalle.getInt(7);
			vistaDetalle.Unidad = ValoresReferencia.getDescripcion("UNIDADV", String.valueOf(vistaDetalle.TipoUnidad));
			vistaDetalle.Devoluciones = detalle.getFloat(8);
			vistaDetalle.Liquidar = vistaDetalle.Cantidad - vistaDetalle.Devoluciones;
			importeDevAnteriores+= detalle.getFloat(9);
			transProdDet.add(vistaDetalle);
		}
		mVista.cargaDetalle(transProdDet.toArray(new VistaConsignacionLiquidacion[transProdDet.size()]));
		if(!consigna.Promocion){
			importeSaldo = consigna.Saldo+importeDevAnteriores;
		}else{
			importeSaldo = null;
		}
		consigna.Saldo+= importeDevAnteriores;
		calculaTotales(transProdDet.toArray(new VistaConsignacionLiquidacion[transProdDet.size()]));
	}
	
	public void calculaTotales(VistaConsignacionLiquidacion[] detalle) throws ControlError{
		this.detalleProductos = detalle;
		float importeProducto, importeDevProducto, impuestoProducto;
		Impuesto [] listaImpuestos;
		final short tipoImpuesto = ((Cliente)Sesion.get(Campo.ClienteActual)).TipoImpuesto;
		importeLiquidar = importeDev = 0;
		numDevoluciones = numLiquidaciones = 0;
		for(VistaConsignacionLiquidacion producto : detalle){
			importeProducto = importeDevProducto = 0;
			listaImpuestos = null;
			if(producto.Liquidar * producto.Precio > 0)
			{
				listaImpuestos = Impuestos.Buscar(producto.ProductoClave, tipoImpuesto);
				impuestoProducto = Impuestos.Calcular(listaImpuestos, 
						producto.Liquidar * producto.Precio, 
						producto.Precio, producto.Liquidar);
				importeProducto = producto.Liquidar * producto.Precio + impuestoProducto;
				importeLiquidar+= importeProducto;
			}
			numDevoluciones+=producto.Devoluciones;
			numLiquidaciones+=producto.Liquidar;
			if(producto.Devoluciones * producto.Precio > 0)
			{
				if(listaImpuestos == null)
				{
					listaImpuestos = Impuestos.Buscar(producto.ProductoClave, tipoImpuesto);
				}
				impuestoProducto = Impuestos.Calcular(listaImpuestos, 
						producto.Devoluciones * producto.Precio, 
						producto.Precio, producto.Devoluciones);
				importeDevProducto = producto.Devoluciones * producto.Precio + impuestoProducto;
				importeDev+= importeDevProducto;
			}
		}
		importeSaldo = Generales.getRound(consigna.Saldo - importeDev, 2);
		importeLiquidar = Generales.getRound(importeLiquidar, 2);
		mVista.setTotales(importeLiquidar, importeDev, !consigna.Promocion ? importeSaldo:null);
	}

	public boolean hayDevoluciones()
	{
		return numDevoluciones > 0;
	}

	public boolean hayLiquidaciones()
	{
		return numLiquidaciones > 0;
	}
	
	public void validaCapturaLiquidacion() throws ControlError, Exception{
		if(!consigna.Promocion)
		{
			if(importeSaldo < 0)
			{
				throw new ControlError("E0697");
			}
		}
		if(importeLiquidar == 0 && consigna.Saldo != consigna.Total)
		{
			throw new ControlError("E0697");
		}
		if(((CONHist)Sesion.get(Campo.CONHist)).get("CancConsigLiqui").equals("0"))
		{
			//Aqui comienza la liquidacion por devolucion
			try{
				liquidacionDevolucion();
				BDVend.commit();
				preguntarImpresion();
			}catch(Exception ex){
				try
				{
					BDVend.rollback();
				}
				catch (Exception e)
				{
					
				}
				throw ex;
			}
		}else
		{
			if(hayDevoluciones()){
				mVista.preguntarSiGeneraConsignacion();
			}else{
				liquidacionCancelacion();
			}
		}
	}
	
	public void setTipoLiquidacion(int tipoLiquidacion){
		this.tipoLiquidacion = tipoLiquidacion;
		liquidacionCancelacion();
	}
	
	private void liquidacionDevolucion() throws Exception{
		TransProd transProdDev = null;
		Vendedor vendedor = (Vendedor)Sesion.get(Campo.VendedorActual);
		Cliente cliente = (Cliente)Sesion.get(Campo.ClienteActual);
		//Obtener TRpTpd, si existe una devolucion anterior
		List<TrpTpd> listTrpTpd = Consultas.ConsultasTrpTpd.obtenerTransProdDevolucionDeConsignacion(consigna.TransProdID);
		if(!listTrpTpd.isEmpty()){
			TrpTpd trptpd = listTrpTpd.get(0);
			Consultas.ConsultasTrpTpd.eliminaTrpTpdAsociadasAConsignacion(consigna.TransProdID);
			transProdDev = new TransProd();
			transProdDev.TransProdID = trptpd.TransProdID;
			BDVend.recuperar(transProdDev);
			BDVend.recuperar(transProdDev, TransProdDetalle.class);
			for(TransProdDetalle trDetalle : transProdDev.TransProdDetalle){
				if(!Inventario.ActualizarInventario(trDetalle.ProductoClave, trDetalle.TipoUnidad, trDetalle.Cantidad, 
						transProdDev.Tipo, transProdDev.TipoMovimiento, vendedor.AlmacenID, ValoresReferencia.getValor("TRPMOT", String.valueOf(transProdDev.TipoMotivo)).getGrupo(), true)){
					throw new Exception("No se pudo actualizar inventario");
				}
                if(cliente.Prestamo){
                    ManejoEnvase.manejoEnvaseEliminar(trDetalle.ProductoClave, trDetalle.TipoUnidad, trDetalle.Cantidad, trDetalle, transProdDev);
                }
				if(!Clientes.actualizarSaldoCteActual(trDetalle.Total)){
					throw new Exception("Error al actualizar saldo al cliente");
				}
//				consigna.Saldo+= trDetalle.Total;
				ISetDatos prodDetalleSet = Consultas.ConsultasProducto.obtenerProductoDetalle(trDetalle.ProductoClave, trDetalle.TipoUnidad);
				if(prodDetalleSet.moveToNext()){
					float factor = prodDetalleSet.getFloat(2);
					Cuotas.VerificarCuotas(vendedor.VendedorId, 1, trDetalle.Cantidad*factor*-1, trDetalle.ProductoClave);
					Cuotas.VerificarCuotas(vendedor.VendedorId, 3, trDetalle.Cantidad*factor*-1, trDetalle.ProductoClave);
				}
			}
			Consultas.ConsultasTPDImpuesto.eliminarImpuestos(transProdDev.TransProdID);
			Consultas.ConsultasTrpPrp.eliminarPorTransProd(transProdDev.TransProdID);
			Consultas.ConsultasDescuentos.eliminarDescuentos(transProdDev.TransProdID);
			Consultas.ConsultasTPDDesVendedor.eliminarPorTransProd(transProdDev.TransProdID);
			Consultas.ConsultasTransProdDetalle.eliminarDetalle(transProdDev.TransProdID);
			transProdDev.FechaCaptura = ((Dia)Sesion.get(Campo.DiaActual)).FechaCaptura;
			transProdDev.FechaSurtido = Generales.getFechaHoraActual();
			transProdDev.FechaHoraAlta = Generales.getFechaHoraActual();
		}

		ModuloMovDetalle moduloDev = null;
		TransProd nuevaDevolucion = null;
		if (hayDevoluciones()){
			moduloDev = Consultas.ConsultasModuloMovDetalle.obtenerModuloMovDetallePorIndice(Enumeradores.TiposModuloMovDetalle.DEVOLUCIONCLIENTES);
			StringBuilder refMensaje = new StringBuilder();
			nuevaDevolucion = transProdDev == null ?
					creaNuevaDevolucion(cliente, moduloDev, refMensaje) :
					transProdDev;
			nuevaDevolucion.TransProdDetalle.clear();
			BDVend.guardarInsertar(nuevaDevolucion);
		}
		/* Aqui se generaran los detalles */
		int partida = 0;
		float impuesto = 0;
		TransProdDetalle detalle = null;
		TrpTpd trpTpd = null;
		Impuesto[] impRelacionados = null;
		for(VistaConsignacionLiquidacion producto : detalleProductos){
			if (nuevaDevolucion != null){
				if(producto.Devoluciones > 0)
				{
					partida++;
					impRelacionados = Impuestos.Buscar(producto.ProductoClave, cliente.TipoImpuesto);
					impuesto = Impuestos.Calcular(impRelacionados,
							producto.Devoluciones * producto.Precio,
							producto.Precio, producto.Devoluciones);
					detalle = creaNuevoDetalle(nuevaDevolucion.TransProdID, producto, impuesto, partida, producto.Devoluciones, true);
					if(!Impuestos.GuardarDetalle(detalle, impRelacionados))
						throw new Exception("Error al calcular los impuestos");
					consigna.Saldo-= detalle.Total;
					trpTpd = creaTrpTpd(detalle);
					BDVend.guardarInsertar(detalle);
					BDVend.guardarInsertar(trpTpd);
				/* Actualizar inventario */
					if(!Inventario.ActualizarInventario(producto.ProductoClave, producto.TipoUnidad, producto.Devoluciones,
							nuevaDevolucion.Tipo, nuevaDevolucion.TipoMovimiento, vendedor.AlmacenID, ValoresReferencia.getValor("TRPMOT", String.valueOf(nuevaDevolucion.TipoMotivo)).getGrupo(), false)){
						throw new Exception("No se pudo actualizar inventario");
					}
					if(cliente.Prestamo){
						ManejoEnvase.manejoEnvase( detalle.producto, detalle.TipoUnidad, producto.Devoluciones, detalle, nuevaDevolucion);
					}
					if(!Clientes.actualizarSaldoCteActual(detalle.Total*-1)){
						throw new Exception("Error al actualizar saldo al cliente");
					}
				}
			}
			if(producto.Liquidar > 0)
			{
				ISetDatos prodDetalle = Consultas.ConsultasProducto.obtenerProductoDetalle(producto.ProductoClave, producto.TipoUnidad);
				float factor;
				if(prodDetalle.moveToNext()){
					factor = prodDetalle.getFloat(2);
					Cuotas.VerificarCuotas(vendedor.VendedorId, 1, producto.Cantidad*factor, producto.ProductoClave);
					Cuotas.VerificarCuotas(vendedor.VendedorId, 3, producto.Cantidad*factor, producto.ProductoClave);
				}
			}
		}
		if(partida > 0 && nuevaDevolucion != null)
		{
			Transacciones.calcularTotalesTransaccion(nuevaDevolucion);
			BDVend.guardarInsertar(nuevaDevolucion);
		}
		if(transProdDev == null && moduloDev != null)
		{
			Folios.confirmar(moduloDev.getModuloMovDetalleClave());
		}
		consigna.TipoFase = 6;
		consigna.FechaFacturacion = Generales.getFechaHoraActual();
		if (nuevaDevolucion != null) {
			consigna.VisitaClave1 = nuevaDevolucion.VisitaClave;
			consigna.DiaClave1 = nuevaDevolucion.DiaClave;
		}
		consigna.MFechaHora = Generales.getFechaHoraActual();
		consigna.MUsuarioID = ((Usuario)Sesion.get(Campo.UsuarioActual)).USUId;
        consigna.Enviado = false;
		BDVend.guardarInsertar(consigna);
		transacciones.add(consigna.TransProdID);

        //Vendedor vendedor = (Vendedor)Sesion.get(Campo.VendedorActual);
        //Cliente cliente = (Cliente) Sesion.get(Campo.ClienteActual);
        if (vendedor.ValidaLimiteConsignas == 1 && vendedor.LimiteConsignas > 0){
            if (!Consultas.ConsultasVendedor.validarClienteConConsignasAbiertas(vendedor, cliente)){
                Consultas.ConsultasVendedor.EliminarClienteConConsignaAb(vendedor, cliente);
            }
        }
	}
	
	private void liquidacionCancelacion(){
		try{
			Vendedor vendedor = (Vendedor)Sesion.get(Campo.VendedorActual);
			Cliente cliente = (Cliente)Sesion.get(Campo.ClienteActual);
			String folio = null;
			
			abonosAnteriores =  consigna.Total - consigna.Saldo;
			abonosAnteriores = Generales.getRound(abonosAnteriores, 2);
			Impuesto [] impuestos = null;
			int partidaVta, partidaDev;
			partidaDev = partidaVta = 0;
			float impuestoDetalle = 0f;
			TransProdDetalle detalleVta = null, detalleDev = null, detalleNuevaConsig = null;
			TrpTpd trpTpd = null;
			
			final ModuloMovDetalle moduloConsig, moduloDev, moduloVta;
			
			boolean generaConsignacion = tipoLiquidacion == LIQUIDACION_GENERA_CONSIGNACION;
			
			if(!Clientes.actualizarSaldoCteActual(consigna.Total*-1)){
				throw new Exception("Error al actualizar saldo al cliente");
			}
			if(hayDevoluciones())
			{
				if(generaConsignacion)
				{
					/* Generar nueva consignacion */
					moduloConsig = Consultas.ConsultasModuloMovDetalle.obtenerModuloMovDetallePorIndice(Enumeradores.TiposModuloMovDetalle.CONSIGNACION);
					StringBuilder stringBuilderRefC = new StringBuilder();
					folio = Folios.Obtener(moduloConsig.getModuloMovDetalleClave(), stringBuilderRefC);
					/* Crear Transpod Consignacion */
					transNuevaConsig = creaTransProd(folio, cliente);
					BDVend.guardarInsertar(transNuevaConsig);
				}else{
					moduloConsig = null;
					transNuevaConsig = null;
				}
				/* Generar devolucion */
				moduloDev = Consultas.ConsultasModuloMovDetalle.obtenerModuloMovDetallePorIndice(Enumeradores.TiposModuloMovDetalle.DEVOLUCIONCLIENTES);
				StringBuilder stringBuilderRefD = new StringBuilder();
				folio = Folios.Obtener(moduloDev.getModuloMovDetalleClave(), stringBuilderRefD);
				transDev = creaNuevaDevolucion(cliente, moduloDev, stringBuilderRefD);
				BDVend.guardarInsertar(transDev);
			}else{
				moduloConsig = null;
				transNuevaConsig = null;
				moduloDev = null;
			}
			if(hayLiquidaciones())
			{
				moduloVta = Consultas.ConsultasModuloMovDetalle.obtenerModuloMovDetallePorIndice(Enumeradores.TiposModuloMovDetalle.PEDIDO);
				StringBuilder stringBuilderRefP = new StringBuilder();
				folio = Folios.Obtener(moduloVta.getModuloMovDetalleClave(), stringBuilderRefP);
				transVta = creaTransProd(folio, cliente);
				transVta.ClientePagoId = "1";
				transVta.CFVTipo = 1;
				transVta.TipoMovimiento = (short) moduloVta.getTipoMovimiento();
				transVta.TipoPedido = (short) moduloVta.getTipoPedido();
				transVta.Tipo = (short) moduloVta.getTipoTransprod();
				BDVend.guardarInsertar(transVta);
			}else{
				transVta = null;
				moduloVta = null;
			}
			for(VistaConsignacionLiquidacion producto: detalleProductos){
				impuestos = Impuestos.Buscar(producto.ProductoClave, cliente.TipoImpuesto);
				if(producto.Liquidar > 0)
				{
					partidaVta++;
					impuestoDetalle = Impuestos.Calcular(impuestos, producto.Precio * producto.Liquidar, producto.Precio, producto.Liquidar);
					detalleVta = creaNuevoDetalle(transVta.TransProdID, producto, impuestoDetalle, partidaVta, producto.Liquidar, false);
					if(!Impuestos.GuardarDetalle(detalleVta, impuestos))
						throw new Exception("Error al calcular los impuestos");
					BDVend.guardarInsertar(detalleVta);
					ISetDatos prodDetalle = Consultas.ConsultasProducto.obtenerProductoDetalle(producto.ProductoClave, producto.TipoUnidad);
					float factor;
					if(prodDetalle.moveToNext()){
						factor = prodDetalle.getFloat(2);
						Cuotas.VerificarCuotas(vendedor.VendedorId, 1, producto.Cantidad*factor, producto.ProductoClave);
						Cuotas.VerificarCuotas(vendedor.VendedorId, 3, producto.Cantidad*factor, producto.ProductoClave);
					}
					transVta.TransProdDetalle.add(detalleVta);
				}
				if(producto.Devoluciones > 0)
				{
					partidaDev++;
					impuestoDetalle = Impuestos.Calcular(impuestos, producto.Precio * producto.Devoluciones, producto.Precio, producto.Devoluciones);
					detalleDev = creaNuevoDetalle(transDev.TransProdID, producto, impuestoDetalle, partidaDev, producto.Devoluciones, true);
					if(!Impuestos.GuardarDetalle(detalleDev, impuestos))
						throw new Exception("Error al calcular los impuestos");
					consigna.Saldo-= detalleDev.Total;
					trpTpd = creaTrpTpd(detalleDev);
					BDVend.guardarInsertar(detalleDev);
					BDVend.guardarInsertar(trpTpd);
					transDev.TransProdDetalle.add(detalleDev);
					if(cliente.Prestamo){
						ManejoEnvase.manejoEnvase(detalleDev.producto, detalleDev.TipoUnidad, producto.Devoluciones, detalleDev, transDev);
					}
					if(!generaConsignacion)
					{
						/* Actualizar inventario */
						if(!Inventario.ActualizarInventario(producto.ProductoClave, producto.TipoUnidad, producto.Devoluciones, 
								transDev.Tipo, transDev.TipoMovimiento, vendedor.AlmacenID, ValoresReferencia.getValor("TRPMOT", String.valueOf(transDev.TipoMotivo)).getGrupo(), false)){
							throw new Exception("No se pudo actualizar inventario");
						}
					}else
					{
						detalleNuevaConsig = creaNuevoDetalle(transNuevaConsig.TransProdID, producto, impuestoDetalle, partidaDev, producto.Devoluciones, false);
						if(!Impuestos.GuardarDetalle(detalleNuevaConsig, impuestos))
							throw new Exception("Error al calcular los impuestos");
						BDVend.guardarInsertar(detalleNuevaConsig);
						transNuevaConsig.TransProdDetalle.add(detalleNuevaConsig);
					}
				}
			}

			final boolean existeVenta = partidaVta > 0;
			if(generaConsignacion)
			{
				Transacciones.calcularTotalesTransaccion(transNuevaConsig);
				promociones = new Promociones2(transNuevaConsig, (Vista) mVista);
				promociones.Preparar();
				promociones.setOnTerminarAplicacionListener(new onTerminarAplicacionListener()
				{
					@Override
					public void onTerminarAplicacion()
					{
						try{
							continuaLiquidacion(CONTINUA_NUEVA_CONSIGNA, moduloConsig, moduloDev, moduloVta, existeVenta);
						}catch(Exception ex){
							terminarProceso(ex);
						}
					}
				});
				promociones.Aplicar();
			}else
				continuaLiquidacion(CONTINUA_SIN_CONSIGNA, moduloConsig, moduloDev, moduloVta, existeVenta);
			
		}catch(Exception ex){
			try{
				BDVend.rollback();
			}catch(Exception e){
				
			}
			mVista.mostrarError(ex.getMessage());
		}
	}
	
	private void terminarProceso(Exception e){
		try
		{
			BDVend.rollback();
		}
		catch (Exception e1)
		{
			
		}
		mVista.mostrarError(e.getMessage());
	}
	
	private void continuaLiquidacion(int paso, final ModuloMovDetalle moduloConsig, final ModuloMovDetalle moduloDev, final ModuloMovDetalle moduloVta, final boolean existeVenta) throws Exception{
		switch(paso)
		{
			case CONTINUA_NUEVA_CONSIGNA:
				Transacciones.calcularTotalesTransaccion(transNuevaConsig);
				transNuevaConsig.Saldo = transNuevaConsig.Total;
				transNuevaConsig.MFechaHora = Generales.getFechaHoraActual();
				transNuevaConsig.MUsuarioID = ((Usuario)Sesion.get(Campo.UsuarioActual)).USUId;
				
				Folios.confirmar(moduloConsig.getModuloMovDetalleClave());
				BDVend.guardarInsertar(transNuevaConsig);
			case CONTINUA_SIN_CONSIGNA:
				if(transDev != null)
					Folios.confirmar(moduloDev.getModuloMovDetalleClave());
			case CONTINUA_VTA:
				consigna.TipoFase = 8;
				consigna.FechaFacturacion = Generales.getFechaHoraActual();
				consigna.VisitaClave1 = ((Visita)Sesion.get(Campo.VisitaActual)).VisitaClave;
				consigna.DiaClave1 = ((Dia)Sesion.get(Campo.DiaActual)).DiaClave;;
				consigna.MFechaHora = Generales.getFechaHoraActual();
				consigna.MUsuarioID = ((Usuario)Sesion.get(Campo.UsuarioActual)).USUId;
				consigna.Saldo = 0;
				consigna.Enviado = false;
				if(existeVenta)

				{
					consigna.FacturaID = transVta.TransProdID;
					promociones = new Promociones2(transVta, (Vista) mVista);
					promociones.Preparar();
					promociones.setOnTerminarAplicacionListener(new onTerminarAplicacionListener()
					{
						
						@Override
						public void onTerminarAplicacion()
						{
							try
							{
								continuaLiquidacion(CONTINUA_VTA_PROMOCIONES, moduloConsig, moduloDev, moduloVta, existeVenta);
							}
							catch (Exception e)
							{
								terminarProceso(e);
							}
						}
					});
					promociones.Aplicar();
				}else
				{
					continuaLiquidacion(FINALIZA, moduloConsig, moduloDev, moduloVta, existeVenta);
				}
				break;
			case CONTINUA_VTA_PROMOCIONES:
				Transacciones.calcularTotalesTransaccion(transVta);
				Folios.confirmar(moduloVta.getModuloMovDetalleClave());
				BDVend.guardarInsertar(transVta);
			case FINALIZA:
				BDVend.guardarInsertar(consigna);
				if(transDev != null){
					BDVend.guardarInsertar(transDev);
					transacciones.add(transDev.TransProdID);
				}
				if(transNuevaConsig != null)
					transacciones.add(transNuevaConsig.TransProdID);
				if(transVta != null){
					transacciones.add(transVta.TransProdID);
					com.amesol.routelite.datos.ModuloMovDetalle movDetalle = new com.amesol.routelite.datos.ModuloMovDetalle();
					movDetalle.ModuloMovDetalleClave = moduloVta.getModuloMovDetalleClave();
					BDVend.recuperar(movDetalle);
					iniciaCapturaTotales(transVta, movDetalle, abonosAnteriores);
				}else
				{
					BDVend.commit();
                    Vendedor vendedor = (Vendedor)Sesion.get(Campo.VendedorActual);
                    Cliente cliente = (Cliente) Sesion.get(Campo.ClienteActual);
                    if (vendedor.ValidaLimiteConsignas == 1 && vendedor.LimiteConsignas > 0){
                        if (!Consultas.ConsultasVendedor.validarClienteConConsignasAbiertas(vendedor, cliente)){
                            Consultas.ConsultasVendedor.EliminarClienteConConsignaAb(vendedor, cliente);
                        }
                    }
					preguntarImpresion();
				}
		}
	}
	
	private void iniciaCapturaTotales(TransProd vta, com.amesol.routelite.datos.ModuloMovDetalle movDetalle, float abonosAnteriores){
		HashMap<String, Object> oParametros = new HashMap<String, Object>();
		
		ArrayList<String> nuevo = new ArrayList<String>();
		nuevo.add(String.valueOf(false));
		ArrayList<String> transprod = new ArrayList<String>();
		transprod.add(vta.TransProdID);
//		transprod.add(consigna.TransProdID);
		HashMap<String, TransProd> arrayTransProd = new HashMap<String, TransProd>();
		arrayTransProd.put(vta.TransProdID, vta);
		Sesion.set(Campo.ArrayTransProd, arrayTransProd);
		
		oParametros.put("TransProdId", transprod);
		oParametros.put("esNuevo", nuevo);
		oParametros.put("abonosAnteriores", abonosAnteriores);
		oParametros.put("ModuloMovDetalle", movDetalle);
		oParametros.put("TotalInicial", vta.Total);
		oParametros.put("Surtir",  Boolean.toString(true));
		oParametros.put("Modificando",  Boolean.toString(false));
		oParametros.put("ModificandoAutoventa",  Boolean.toString(false));

		
		mVista.iniciarActividadConResultado(ICapturaTotalesConsignacion.class, 
				Enumeradores.Solicitudes.SOLICITUD_MOSTRAR_TOTALES_CONSIGNACION, 
				Enumeradores.Acciones.ACCION_LIQUIDAR_CONSIGNACION,
				oParametros);
	}
	
	private TransProd creaTransProd(String folio, Cliente cliente) throws Exception{
		TransProd transProd = new TransProd();
		transProd.Folio = folio;
		transProd.TransProdID = KeyGen.getId();
		transProd.VisitaClave = ((Visita)Sesion.get(Campo.VisitaActual)).VisitaClave;
		transProd.DiaClave = ((Dia)Sesion.get(Campo.DiaActual)).DiaClave;
		transProd.PCEPrecioClave = consigna.PCEPrecioClave;
		transProd.PCEModuloMovDetClave = consigna.PCEModuloMovDetClave;
		transProd.SubEmpresaId = consigna.SubEmpresaId;
		transProd.ClienteClave = cliente.ClienteClave;
		transProd.Tipo = consigna.Tipo;
		transProd.TipoPedido = consigna.TipoPedido;
		transProd.TipoFase = 2; //Surtido
		transProd.TipoMovimiento = consigna.TipoMovimiento;
		transProd.FechaHoraAlta = transProd.FechaSurtido = Generales.getFechaHoraActual();
		transProd.FechaEntrega = transProd.FechaCaptura = ((Dia)Sesion.get(Campo.DiaActual)).FechaCaptura;
		transProd.FechaFacturacion = transProd.FechaCancelacion = Generales.getMinFecha();
		transProd.TipoMotivo = 12;
		transProd.Enviado = false;
		transProd.MFechaHora = Generales.getFechaHoraActual();
		transProd.MUsuarioID = ((Usuario)Sesion.get(Campo.UsuarioActual)).USUId;
		
		return transProd;
	}
	
	private TrpTpd creaTrpTpd(TransProdDetalle detalle)
	{
		TrpTpd trpTpd = new TrpTpd();
		trpTpd.TransProdDetalleID = detalle.TransProdDetalleID;
		trpTpd.TransProdID = detalle.TransProdID;
		trpTpd.TransProdID1 = consigna.TransProdID;
		trpTpd.Cantidad = detalle.Cantidad;
		trpTpd.Precio = detalle.Precio;
		trpTpd.Subtotal = detalle.Subtotal;
		trpTpd.Impuesto = detalle.Impuesto;
		trpTpd.Total = detalle.Total;
		trpTpd.MFechaHora = Generales.getFechaHoraActual();
		trpTpd.MUsuarioID = ((Usuario)Sesion.get(Campo.UsuarioActual)).USUId;
		return trpTpd;
	}

	private TransProdDetalle creaNuevoDetalle(String transProdId, VistaConsignacionLiquidacion producto, float impuesto, int partida, float cantidad, boolean mismoTransProdDetalleId)
	{
		TransProdDetalle detalle = new TransProdDetalle();
		detalle.TransProdID = transProdId;
		detalle.Impuesto = Generales.getRound(impuesto, 2);
		detalle.Partida = partida;
		
		detalle.Cantidad = cantidad;
		detalle.DescuentoImp = 0f;
		detalle.DescuentoPor = 0f;
		detalle.TransProdDetalleID = mismoTransProdDetalleId ? producto.TransProdDetalleId : KeyGen.getId();
		detalle.ProductoClave = producto.ProductoClave;
		detalle.TipoUnidad = producto.TipoUnidad;
		detalle.Precio = producto.Precio;
		detalle.Subtotal = detalle.Cantidad * detalle.Precio;
		detalle.Total = detalle.Subtotal + detalle.Impuesto;
		detalle.Promocion = 0;
		detalle.MFechaHora = Generales.getFechaHoraActual();
		detalle.MUsuarioID = ((Usuario)Sesion.get(Campo.UsuarioActual)).USUId;
		detalle.Enviado = false;

		try{
			Producto prod = new Producto();
			prod.ProductoClave = producto.ProductoClave;
			BDVend.recuperar(prod);
			detalle.producto = prod;
		}catch (Exception e){
			e.printStackTrace();
		}
		
		return detalle;
	}

	private TransProd creaNuevaDevolucion(Cliente cliente, ModuloMovDetalle moduloDev, StringBuilder refMensaje) throws Exception{
		String folio = Folios.Obtener(moduloDev.getModuloMovDetalleClave(), refMensaje);
		TransProd nuevaDev = new TransProd();
		nuevaDev.TransProdID = KeyGen.getId();
		nuevaDev.VisitaClave = ((Visita)Sesion.get(Campo.VisitaActual)).VisitaClave;
		nuevaDev.DiaClave = ((Dia)Sesion.get(Campo.DiaActual)).DiaClave;
		nuevaDev.PCEPrecioClave = consigna.PCEPrecioClave;
		nuevaDev.PCEModuloMovDetClave = consigna.PCEModuloMovDetClave;
		nuevaDev.ClienteClave = cliente.ClienteClave;
		nuevaDev.Folio = folio;
		nuevaDev.Tipo = (short)moduloDev.getTipoTransprod();
		nuevaDev.TipoPedido = (short) moduloDev.getTipoPedido();
		nuevaDev.TipoFase = 2; //Surtido
		nuevaDev.TipoMovimiento = (short) moduloDev.getTipoMovimiento();
		nuevaDev.FechaHoraAlta = nuevaDev.FechaSurtido = Generales.getFechaHoraActual();
		nuevaDev.FechaCaptura = nuevaDev.FechaEntrega = ((Dia)Sesion.get(Campo.DiaActual)).FechaCaptura;
		nuevaDev.FechaFacturacion = nuevaDev.FechaCancelacion = Generales.getMinFecha();
		nuevaDev.TipoMotivo = 12;
		nuevaDev.Enviado = false;
		nuevaDev.MFechaHora = Generales.getFechaHoraActual();
		nuevaDev.MUsuarioID = ((Usuario)Sesion.get(Campo.UsuarioActual)).USUId;
		return nuevaDev;
	}
	
	public void preguntarImpresion(){
		MOTConfiguracion motConfig = (MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion);
		if (motConfig.get("MensajeImpresion").equals("0"))
		{
			// si no esta configurada la pregunta salir
			mVista.setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
			mVista.finalizar();
		}else if(motConfig.get("MensajeImpresion").equals("1")){
			mVista.mostrarPreguntaSiNo(Mensajes.get("P0103"), CapturaLiquidacionConsignacion.PREGUNTA_IMPRIMIR);
		}else if (motConfig.get("MensajeImpresion").equals("2")){
            mVista.mostrarToast(Mensajes.get("E0934"));
            mVista.setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
            mVista.finalizar();
        }
	}

	public void imprimirDocumentos() throws ControlError, Exception{
		Recibos recibos = new Recibos();
        short numImpresiones = 0;
        try {
            if (((ConfigParametro) Sesion.get(Sesion.Campo.ConfigParametro)).existeParametro("NumImpresiones", Sesion.get(Sesion.Campo.ModuloMovDetalleClave).toString())) {
                numImpresiones = Short.parseShort (((ConfigParametro) Sesion.get(Sesion.Campo.ConfigParametro)).get("NumImpresiones", Sesion.get(Sesion.Campo.ModuloMovDetalleClave).toString()).toString());
            }
        }catch (Exception ex){
            mVista.mostrarError("Error al recuperar el parámetro NumImpresiones");
            numImpresiones = 0;
        }
		recibos.imprimirRecibos(generarDocsAImprimir(), true, mVista, numImpresiones);
	}
	
	private List<Map<String, String>> generarDocsAImprimir()
	{
		//String lstTrpTipo = ValoresReferencia.getStringVAVClave("TRPTIPO", "Visita");

		//ISetDatos datos = Consultas.ConsultasTransProd.obtenerTransProdAImprimir(lstTrpTipo, Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()), ((Cliente) Sesion.get(Campo.ClienteActual)).ClienteClave, ((Visita) Sesion.get(Campo.VisitaActual)).VisitaClave, ((Visita) Sesion.get(Campo.VisitaActual)).DiaClave, transacciones.toString().replace("[", "'").replace("]", "'").replace(", ", "','"));
		ISetDatos datos = Consultas.ConsultasTransProd.obtenerTransProdAImprimir(transacciones.toString().replace("[", "'").replace("]", "'").replace(", ", "','"));
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

		return tabla;
	}

	private String obtenerTipoRecibo(Map<String, String> registro)
	{
		String tipoRecibo = "0";

		int tipo = Integer.parseInt(registro.get("Tipo"));
		if (registro.get("TipoRecibo").equals("TRP"))
		{
			if ((tipo == 3 && !registro.get("TipoFase").equals("3")) || (tipo != 3))
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
						if (registro.get("TipoFase").equals("6"))
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
	
	public class VistaConsignacionLiquidacion{
		public String TransProdDetalleId;
		public String Nombre;
		public int DecimalProducto;
		public float Precio;
		public float Cantidad;
		public float Devoluciones;
		public float Liquidar;
		public String ProductoClave;
		public String Unidad;
		public float Total;
		public int TipoUnidad;
	}
}
