package com.amesol.routelite.presentadores.act;

import android.database.Cursor;
import android.graphics.Bitmap;

import com.amesol.routelite.actividades.Folios;
import com.amesol.routelite.actividades.Impuestos;
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.actividades.ModuloMovDetalle;
import com.amesol.routelite.actividades.QRCode;
import com.amesol.routelite.actividades.Recibos;
import com.amesol.routelite.actividades.Transacciones;
import com.amesol.routelite.actividades.TransaccionesDetalle;
import com.amesol.routelite.actividades.ValorReferencia;
import com.amesol.routelite.actividades.ValoresReferencia;
import com.amesol.routelite.datos.Cliente;
import com.amesol.routelite.datos.Dia;
import com.amesol.routelite.datos.Impuesto;
import com.amesol.routelite.datos.TransProd;
import com.amesol.routelite.datos.TransProdDetalle;
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
import com.amesol.routelite.presentadores.Enumeradores.Acciones;
import com.amesol.routelite.presentadores.Enumeradores.Solicitudes;
import com.amesol.routelite.presentadores.Enumeradores.TiposFasesDocto;
import com.amesol.routelite.presentadores.Enumeradores.TiposModulos;
import com.amesol.routelite.presentadores.Presentador;
import com.amesol.routelite.presentadores.interfaces.IAutorizaMovimiento;
import com.amesol.routelite.presentadores.interfaces.ICambiaProducto;
import com.amesol.routelite.presentadores.interfaces.ICapturaCanje;
import com.amesol.routelite.presentadores.interfaces.ICapturaMovConInventario;
import com.amesol.routelite.presentadores.interfaces.ICapturaMovSinInventario;
import com.amesol.routelite.presentadores.interfaces.ICapturaPedido;
import com.amesol.routelite.presentadores.interfaces.IDevolucionCliente;
import com.amesol.routelite.presentadores.interfaces.ISeleccionPedidoBackOrder;
import com.amesol.routelite.utilerias.ControlError;
import com.amesol.routelite.utilerias.Generales;
import com.amesol.routelite.vistas.utilerias.ServicesCentral;

import java.text.DecimalFormat;
import java.text.NumberFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.HashMap;
import java.util.Iterator;
import java.util.List;
import java.util.Map;

public class SeleccionarPedidoBackOrder extends Presentador
{

	public static class VistaPedidos
	{
		private String TransprodID;
		private String Folio;
		private int TipoFase;
		private String Fase;
		private String Fecha;
		private int Cantidad;
		private String Descripcion;
		private String Extras;
		private String FolioConfirmado;
		private int TipoPedido;

		public VistaPedidos(String transprodid, String folio, int tipofase, String fase, String fecha, int cantidad, String descripcion)
		{
			TransprodID = transprodid;
			Folio = folio;
			TipoFase = tipofase;
			Fase = fase;
			Fecha = fecha;
			Cantidad = cantidad;
			Descripcion = descripcion;
			Extras = "";
			TipoPedido = 0;
			FolioConfirmado = "";
		}

		public VistaPedidos(String transprodid, String folio, int tipofase, String fase, String fecha, int cantidad, String descripcion, int tipoPedido, String folioConfirmado)
		{
			TransprodID = transprodid;
			Folio = folio;
			TipoFase = tipofase;
			Fase = fase;
			Fecha = fecha;
			Cantidad = cantidad;
			Descripcion = descripcion;
			Extras = "";
			TipoPedido = tipoPedido;
			FolioConfirmado = folioConfirmado;
		}

		public String getTransprodID()
		{
			return TransprodID;
		}
		public void setTransprodID(String transprodID)
		{
			TransprodID = transprodID;
		}
		public String getFolio()
		{
			return Folio;
		}
		public void setFolio(String folio)
		{
			Folio = folio;
		}
		public int getTipoFase()
		{
			return TipoFase;
		}
		public void setTipoFase(int tipoFase)
		{
			TipoFase = tipoFase;
		}
		public String getFase()
		{
			return Fase;
		}
		public void setFase(String fase)
		{
			Fase = fase;
		}
		public String getFecha() {
			return Fecha;
		}
		public int getCantidad()
		{
			return Cantidad;
		}
		public void setCantidad(String cantidad)
		{
			TransprodID = cantidad;
		}
		public String getDescripcion()
		{
			return Descripcion;
		}
		public void setDescripcion(String descripcion)
		{
			TransprodID = descripcion;
		}
		public String getExtras()
		{
			return Extras;
		}
		public void setFecha(String fecha)
		{
			Fecha = fecha;
		}
		public void setExtras(String extras)
		{
			Extras = extras;
		}
		public void setFolioConfirmado(String folioConfirmado){ FolioConfirmado = folioConfirmado; }
		public String getFolioConfirmado() { return FolioConfirmado; }
		public int getTipoPedido()
		{
			return TipoPedido;
		}
		public void setTipoPedido(int tipoPedido)
		{
			TipoPedido = tipoPedido;
		}
	}

	ISeleccionPedidoBackOrder mVista;
	String mAccion;

	boolean iniciarActividad;
	Class<?> actvdd;
	String sTransProdIdSeleccionado;

	public SeleccionarPedidoBackOrder(ISeleccionPedidoBackOrder vista, String accion)
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

			if (mVista.obtenerPedidos().length > 0)
			{
				iniciarActividad = false;
				mVista.mostrarPedidosBOCliente(mVista.obtenerPedidos());
			}
		}
		catch (Exception e)
		{
			mVista.mostrarError(e.getMessage());
		}
	}

	public void cancelar(SeleccionarPedidoBackOrder.VistaPedidos pedido)
	{
		try
		{
			if (pedido.getTipoFase() == 0)
			{
				mVista.mostrarError(Mensajes.get("E0032", mVista.getDescripcionFase(pedido.getTipoFase())));
			}
			else
			{
				CONHist c = (CONHist) Sesion.get(Campo.CONHist);
				TransProd oTpd = new TransProd();
				oTpd.TransProdID = pedido.getTransprodID();
				BDVend.recuperar(oTpd);

				//Cancelar Pedido
				Visita oVisita = (Visita)Sesion.get(Campo.VisitaActual);
				oTpd.TipoFase = 0;
				oTpd.VisitaClave1 = oVisita.VisitaClave;
				oTpd.DiaClave1 = oVisita.DiaClave;
				oTpd.FechaCancelacion = Generales.getFechaHoraActual();
				oTpd.MFechaHora = Generales.getFechaHoraActual();
				oTpd.MUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;
				oTpd.Enviado = false;
				BDVend.guardarInsertar(oTpd);

				BDVend.commit();
			}
		}
		catch (Exception ex)
		{
			mVista.mostrarError(ex.getMessage());
		}

	}

	public void confirmar(VistaPedidos pedido, Cliente cliente){
		try{
			String mensaje = "";
			ArrayList<String> folios = new ArrayList<String>();
			Sesion.set(Campo.TipoIndiceModuloMovDetalleClave, Enumeradores.TiposModuloMovDetalle.PEDIDO);
			ModuloMovDetalle mmd = Consultas.ConsultasModuloMovDetalle.obtenerModuloMovDetallePorIndice(Enumeradores.TiposModuloMovDetalle.PEDIDO);
			Sesion.set(Campo.ModuloMovDetalleClave, mmd.getModuloMovDetalleClave());
			folios = Folios.ObtenerVarios(mmd.getModuloMovDetalleClave(), 1, mensaje);

			TransProd oTpd = new TransProd();
			oTpd.TransProdID = pedido.getTransprodID();
			BDVend.recuperar(oTpd);
			BDVend.recuperar(oTpd, TransProdDetalle.class);

			if(folios.size() > 0){
				oTpd.Folio = folios.get(0);
				oTpd.FechaSurtido = Generales.getFechaHoraActual();
				oTpd.MFechaHora = Generales.getFechaHoraActual();
				oTpd.MUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;
				oTpd.Enviado = false;

				Iterator<TransProdDetalle> oTpdIt = oTpd.TransProdDetalle.iterator();
				while (oTpdIt.hasNext())
				{
					TransProdDetalle detalle = oTpdIt.next();
					detalle.CantidadOriginal = detalle.Cantidad;
					TransaccionesDetalle.Pedidos.CalcularTotalesDetallePedido(detalle);
					detalle.Enviado = false;
				}

				Transacciones.Pedidos.CalcularTotalesPedido(oTpd);
			}

			//Confirmar Pedido
			oTpd.FacturaID = "1";
			BDVend.guardarInsertar(oTpd);

			BDVend.commit();

			HashMap<String, String> oParametros = new HashMap<String, String>();
			oParametros.put("TransProdId", oTpd.TransProdID);
			mVista.iniciarActividadConResultado(ICapturaPedido.class, 0, null, oParametros);
			mVista.finalizar();

		}catch(Exception ex){
			mVista.mostrarError(ex.getMessage());
		}
	}

	public void CalcularImpDesGlb(TransProd oTransProd, float sDescVendPor,Boolean[] aplicoRangos ){
		BDVend.setOrigenLog("CapturarTotales:CalcularImpDesGlb");
		try{
			aplicoRangos[0] = false;
			if ( Consultas.ConsultasImpuesto.ExistenImpuestosConRango()){
				Impuestos.RecalcularRangos(oTransProd);
				aplicoRangos[0] = true;
			}
			Cliente oCliente = (Cliente) Sesion.get(Campo.ClienteActual);
			//ISetDatos TransprodDetalle = Consultas.ConsultasTransProdDetalle.obtenerDetallesDesctosVendedorCliente(oTransProd.TransProdID);

			for (int i = 0; i < oTransProd.TransProdDetalle.size(); i++)
			{
				Impuesto[] arrayImpuestos;
				TransProdDetalle oTransProdDetalle = oTransProd.TransProdDetalle.get(i);

				if (aplicoRangos[0]){
					arrayImpuestos= Impuestos.BuscarPorProductoYRango(oTransProdDetalle.ProductoClave, oCliente.TipoImpuesto,oTransProd.Subtotal);
				}else{
					arrayImpuestos= Impuestos.BuscarPorProducto(oTransProdDetalle.ProductoClave, oCliente.TipoImpuesto);
				}

				float SubTotalConDesc = (oTransProdDetalle.Subtotal-oTransProdDetalle.DesImporteT);;

				Impuesto[] arrayImpuestosCalculados = CalcularImp(arrayImpuestos,(SubTotalConDesc - (SubTotalConDesc * (sDescVendPor / 100))),oTransProdDetalle.Precio,oTransProdDetalle.Cantidad);

				for (int j = 0; j < arrayImpuestosCalculados.length; j++){
					Consultas.ConsultasImpuesto.ActualizaImpDesGlb(oTransProdDetalle.TransProdID, oTransProdDetalle.TransProdDetalleID,arrayImpuestosCalculados[j].ImpuestoClave, arrayImpuestosCalculados[j].Importe,  arrayImpuestosCalculados[j].RedondeoDecimales);
				}
			}
			if (aplicoRangos[0]) {
				if (oTransProd.DescVendPor != null && oTransProd.DescVendPor >0){
					oTransProd.DescuentoImpuestoVendedor = (oTransProd.Impuesto == null ? 0 : oTransProd.Impuesto) * (oTransProd.DescVendPor == null ? 0 : oTransProd.DescVendPor / 100);
					oTransProd.Impuesto = oTransProd.Impuesto - oTransProd.DescuentoImpuestoVendedor;
					oTransProd.Total = oTransProd.Subtotal + oTransProd.Impuesto;
					BDVend.guardarInsertar(oTransProd);
				}
			}
		}
		catch (Exception ex){
			mVista.mostrarError(ex.getMessage());
		}
	}

	public Impuesto[] CalcularImp(Impuesto[] Impuestos, float pvBase, float pvPU, float pvCantidadUnitaria){
		BDVend.setOrigenLog("CapturarTotales:CalcularImp");
		float nTotalImpuesto=0;
		float nTotalImpuestoPU=0;

		for (int i = 0; i < Impuestos.length; i++){
			if (Impuestos[i].TipoValor == ServicesCentral.TiposValoresAplicacionImpuestos.Porcentaje.value){
				if(Impuestos[i].TipoAplicacion == ServicesCentral.TiposAplicacionImpuestos.SubtotalConImpuestos.value){
					if (Impuestos[i].RedondeoDecimales != null &&  Impuestos[i].RedondeoDecimales >0) {
						Impuestos[i].Importe = Generales.getRound((pvBase + nTotalImpuesto) * (Impuestos[i].Valor / 100),Impuestos[i].RedondeoDecimales ) ;
						Impuestos[i].ImportePU = Generales.getRound((pvPU + nTotalImpuestoPU) * (Impuestos[i].Valor / 100),Impuestos[i].RedondeoDecimales) ;
					}else{
						Impuestos[i].Importe = (float)((pvBase + nTotalImpuesto) * (Impuestos[i].Valor / 100));
						Impuestos[i].ImportePU = (float)((pvPU + nTotalImpuestoPU) * (Impuestos[i].Valor / 100));
					}

				}else if(Impuestos[i].TipoAplicacion == ServicesCentral.TiposAplicacionImpuestos.SubtotalSinImpuestos.value){
					if (Impuestos[i].RedondeoDecimales != null &&  Impuestos[i].RedondeoDecimales >0) {
						Impuestos[i].Importe = Generales.getRound(pvBase * (Impuestos[i].Valor / 100),Impuestos[i].RedondeoDecimales );
						Impuestos[i].ImportePU = Generales.getRound(pvPU * (Impuestos[i].Valor / 100),Impuestos[i].RedondeoDecimales);
					}else{
						Impuestos[i].Importe = (float)(pvBase * (Impuestos[i].Valor / 100));
						Impuestos[i].ImportePU = (float)(pvPU * (Impuestos[i].Valor / 100));
					}
				}
			}else if (Impuestos[i].TipoValor == ServicesCentral.TiposValoresAplicacionImpuestos.Importe.value){
				if (Impuestos[i].RedondeoDecimales != null &&  Impuestos[i].RedondeoDecimales >0) {
					Impuestos[i].Importe = Generales.getRound((Impuestos[i].Valor * pvCantidadUnitaria), Impuestos[i].RedondeoDecimales);
					Impuestos[i].ImportePU = Generales.getRound ((Impuestos[i].Valor), Impuestos[i].RedondeoDecimales) ;
				}else{
					Impuestos[i].Importe = (float)((Impuestos[i].Valor * pvCantidadUnitaria));
					Impuestos[i].ImportePU = (float)((Impuestos[i].Valor));
				}
			}
			if (Impuestos[i].RedondeoDecimales != null &&  Impuestos[i].RedondeoDecimales >0) {
				nTotalImpuesto += Generales.getRound(Impuestos[i].Importe, Impuestos[i].RedondeoDecimales);
				nTotalImpuestoPU += Generales.getRound(Impuestos[i].ImportePU, Impuestos[i].RedondeoDecimales);
			}else{
				nTotalImpuesto += Impuestos[i].Importe;
				nTotalImpuestoPU += Impuestos[i].ImportePU;
			}

		}

		return Impuestos;
	}

}
