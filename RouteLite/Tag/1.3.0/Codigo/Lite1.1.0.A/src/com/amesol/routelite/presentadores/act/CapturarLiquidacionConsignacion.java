package com.amesol.routelite.presentadores.act;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

import org.xml.sax.DTDHandler;

import com.amesol.routelite.actividades.Clientes;
import com.amesol.routelite.actividades.Cuotas;
import com.amesol.routelite.actividades.Folios;
import com.amesol.routelite.actividades.Impuestos;
import com.amesol.routelite.actividades.Inventario;
import com.amesol.routelite.actividades.ModuloMovDetalle;
import com.amesol.routelite.actividades.Transacciones;
import com.amesol.routelite.actividades.ValoresReferencia;
import com.amesol.routelite.datos.Cliente;
import com.amesol.routelite.datos.Dia;
import com.amesol.routelite.datos.Impuesto;
import com.amesol.routelite.datos.TransProd;
import com.amesol.routelite.datos.TransProdDetalle;
import com.amesol.routelite.datos.TrpTpd;
import com.amesol.routelite.datos.Vendedor;
import com.amesol.routelite.datos.Visita;
import com.amesol.routelite.datos.basedatos.BDVend;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.CONHist;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.Presentador;
import com.amesol.routelite.presentadores.act.SeleccionarConsignacion.VistaConsignacion;
import com.amesol.routelite.presentadores.interfaces.ICapturaLiquidacionConsignacion;
import com.amesol.routelite.utilerias.ControlError;
import com.amesol.routelite.utilerias.Generales;
import com.amesol.routelite.utilerias.KeyGen;

public class CapturarLiquidacionConsignacion extends Presentador
{

	public static final int LIQUIDACION_GENERA_DEVOLUCION = 1;
	public static final int LIQUIDACION_GENERA_CONSIGNACION = 2;
	
	private ICapturaLiquidacionConsignacion mVista;
	private TransProd consigna;
	private VistaConsignacionLiquidacion[] detalleProductos;
	private float numDevoluciones, importeLiquidar, importeDev;
	private Float importeSaldo;
	private boolean permiteCancelar;
	private int tipoLiquidacion = LIQUIDACION_GENERA_DEVOLUCION;
	
	public CapturarLiquidacionConsignacion(ICapturaLiquidacionConsignacion capturaLiquidacionConsignacion)
	{
		mVista = capturaLiquidacionConsignacion;
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
	
	private void cargaDetalleConsignacion() throws Exception{
		ISetDatos detalle = Consultas.ConsultasTransProdDetalle.obtenerDetalleLiquidacionConsignacion(consigna.TransProdID);
		List<VistaConsignacionLiquidacion> transProdDet = new ArrayList<CapturarLiquidacionConsignacion.VistaConsignacionLiquidacion>();
		importeLiquidar = consigna.Total;
		if(!consigna.Promocion){
			importeSaldo = consigna.Saldo;
		}else{
			importeSaldo = null;
		}
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
			vistaDetalle.Devoluciones = 0;
			vistaDetalle.Liquidar = vistaDetalle.Cantidad - vistaDetalle.Devoluciones;
			transProdDet.add(vistaDetalle);
		}
		detalle.close();
		mVista.cargaDetalle(transProdDet.toArray(new VistaConsignacionLiquidacion[transProdDet.size()]));
		mVista.setTotales(importeLiquidar, importeDev, importeSaldo);
	}
	
	public void calculaTotales(VistaConsignacionLiquidacion[] detalle) throws ControlError{
		this.detalleProductos = detalle;
		float importeProducto, importeDevProducto, impuestoProducto;
		Impuesto [] listaImpuestos;
		final short tipoImpuesto = ((Cliente)Sesion.get(Campo.ClienteActual)).TipoImpuesto;
		importeLiquidar = importeDev = 0;
		numDevoluciones = 0;
		for(VistaConsignacionLiquidacion producto : detalle){
			importeProducto = importeDevProducto = 0;
			listaImpuestos = null;
			if(producto.Liquidar * producto.Precio > 0)
			{
				listaImpuestos = Impuestos.Buscar(producto.ProductoClave, tipoImpuesto);
				impuestoProducto = Impuestos.Calcular(listaImpuestos, 
						producto.Liquidar * producto.Precio, 
						producto.Precio);
				importeProducto = producto.Liquidar * producto.Precio + Generales.getRound(impuestoProducto, 2);
				importeLiquidar+= importeProducto;
			}
			numDevoluciones+=producto.Devoluciones;
			if(producto.Devoluciones * producto.Precio > 0)
			{
				if(listaImpuestos == null)
				{
					listaImpuestos = Impuestos.Buscar(producto.ProductoClave, tipoImpuesto);
				}
				impuestoProducto = Impuestos.Calcular(listaImpuestos, 
						producto.Devoluciones * producto.Precio, 
						producto.Precio);
				importeDevProducto = producto.Devoluciones * producto.Precio + Generales.getRound(impuestoProducto, 2);
				importeDev+= importeDevProducto;
			}
		}
		importeSaldo = consigna.Saldo-importeDev;
		mVista.setTotales(importeLiquidar, importeDev, !consigna.Promocion ? importeSaldo:null);
	}

	public boolean hayDevoluciones()
	{
		return numDevoluciones > 0;
	}

	public void validaCapturaLiquidacion() throws ControlError{
		if(!consigna.Promocion)
		{
			if(importeSaldo < 0)
			{
				throw new ControlError("E0697");
			}
		}
		if(importeLiquidar == 0 && consigna.Total != consigna.Total)
		{
			throw new ControlError("E0697");
		}
		if(((CONHist)Sesion.get(Campo.CONHist)).get("CancConsigLiqui").equals("0"))
		{
			//Aqui comienza la liquidacion por devolucion
			permiteCancelar = false;
			try{
				liquidacionDevolucion();
			}catch(Exception ex){
				
			}
		}else
		{
			if(hayDevoluciones()){
				mVista.preguntarSiGeneraConsignacion();
			}
		}
	}
	
	public void setTipoLiquidacion(int tipoLiquidacion){
		this.tipoLiquidacion = tipoLiquidacion;
		liquidacionCancelacion();
	}
	
	private void liquidacionDevolucion() throws Exception{
		String transProdIdDev = null;
		Vendedor vendedor = (Vendedor)Sesion.get(Campo.VendedorActual);
		Cliente cliente = (Cliente)Sesion.get(Campo.ClienteActual);
		//Obtener TRpTpd, si existe una devolucion anterior
		List<TrpTpd> listTrpTpd = Consultas.ConsultasTrpTpd.obtenerTransProdDevolucionDeConsignacion(consigna.TransProdID);
		if(!listTrpTpd.isEmpty()){
			boolean exito;
			TrpTpd trptpd = listTrpTpd.get(0);
			Consultas.ConsultasTrpTpd.eliminaTrpTpdAsociadasAConsignacion(consigna.TransProdID);
			transProdIdDev = trptpd.TransProdID;
			TransProd transProdDev = new TransProd();
			transProdDev.TransProdID = transProdIdDev;
			BDVend.recuperar(transProdDev, TransProdDetalle.class);
			for(TransProdDetalle trDetalle : transProdDev.TransProdDetalle){
				if(!Inventario.ActualizarInventario(trDetalle.ProductoClave, trDetalle.TipoUnidad, trDetalle.Cantidad, 
						transProdDev.Tipo, transProdDev.TipoMovimiento, vendedor.AlmacenID, true)){
					throw new Exception("No se pudo actualizar inventario");
				}
				if(!Clientes.actualizarSaldoCteActual(trDetalle.Total)){
					throw new Exception("Error al actualizar saldo al cliente");
				}
				consigna.Saldo+= trDetalle.Total;
				ISetDatos prodDetalleSet = Consultas.ConsultasProducto.obtenerProductoDetalle(trDetalle.ProductoClave, trDetalle.TipoUnidad);
				short factor = prodDetalleSet.getShort(2);
				Cuotas.VerificarCuotas(vendedor.VendedorId, 1, trDetalle.Cantidad*factor*-1, trDetalle.ProductoClave);
				Cuotas.VerificarCuotas(vendedor.VendedorId, 3, trDetalle.Cantidad*factor*-1, trDetalle.ProductoClave);
			}
			Consultas.ConsultasTPDImpuesto.eliminarImpuestos(transProdIdDev);
			Consultas.ConsultasTrpPrp.eliminarPorTransProd(transProdIdDev);
			Consultas.ConsultasDescuentos.eliminarDescuentos(transProdIdDev);
			Consultas.ConsultasTPDDesVendedor.eliminarPorTransProd(transProdIdDev);
			Consultas.ConsultasTransProdDetalle.eliminarDetalle(transProdIdDev);
			transProdDev.FechaCaptura = ((Dia)Sesion.get(Campo.DiaActual)).FechaCaptura;
			transProdDev.FechaSurtido = Generales.getFechaHoraActual();
			transProdDev.FechaHoraAlta = Generales.getFechaHoraActual();
		}
		ModuloMovDetalle moduloDev = Consultas.ConsultasModuloMovDetalle.obtenerModuloMovDetallePorIndice(Enumeradores.TiposModuloMovDetalle.DEVOLUCIONCLIENTES);
		StringBuilder refMensaje = new StringBuilder();
		String folio = Folios.Obtener(moduloDev.getModuloMovDetalleClave(), refMensaje);
		TransProd nuevaDevolucion = new TransProd();
		nuevaDevolucion.TransProdID = KeyGen.getId();
		nuevaDevolucion.VisitaClave = ((Visita)Sesion.get(Campo.VisitaActual)).VisitaClave;
		nuevaDevolucion.DiaClave = ((Dia)Sesion.get(Campo.DiaActual)).DiaClave;
		nuevaDevolucion.PCEPrecioClave = consigna.PCEPrecioClave;
		nuevaDevolucion.PCEModuloMovDetClave = consigna.PCEModuloMovDetClave;
		nuevaDevolucion.ClienteClave = cliente.ClienteClave;
		nuevaDevolucion.Folio = folio;
		nuevaDevolucion.Tipo = (short)moduloDev.getTipoTransprod();
		nuevaDevolucion.TipoPedido = (short) moduloDev.getTipoPedido();
	}
	
	private void liquidacionCancelacion(){
		
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
