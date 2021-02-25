package com.amesol.routelite.presentadores.interfaces;

import com.amesol.routelite.datos.TransProd;
import com.amesol.routelite.presentadores.IVista;

import java.util.Date;
import java.util.HashMap;

public interface ICapturaTotales extends IVista {
	public void setFolio(String Folio);
	public void setTipoPedido(int TipoPedido);
	public void setFormaVenta(int FormaVenta);
	public void setFormaPago(String clientePagoId);
    public void setTipoTurno(int TipoTurno);
	public void setFechaEntrega(Date FechaEntrega);
	public void setFechaEntregaDefault();
	public void setFechaCobranza(Date FechaCobranza);
	public void recalcularTotales(TransProd oTrp) throws Exception;
	public void setSubTProducto(float subTProducto);
	public void setDescYBonif(float descYBonif);
	public void setSubTotal(float subTotal);
	public void setImpuesto(float impuesto);
	public void setTotal(float total);
	public void setImpDescVendedor(float descuento);
	public void setPorDescVendedor(float porcentaje);
	public void setPedidoAdicional(String pedidoAdicional);
	public void setRemision(String remision);
	public void setNotas(String notas);
	public void setPuntoEntrega(String clienteDomicilioId);
	public void setObservaciones(String observaciones);
    public void setObservaciones2(String observaciones2);
	public void setMensajeLimiteCredito(boolean mensaje);
	public boolean getMensajeLimiteCredito();
    public void setMensajeLimiteEnvase(boolean mostrandoMensaje);
    public boolean getMensajeLimiteEnvase();
	
	
	public short getTipoPedido();
	public short getFormaVenta();
	public short getFormaVentaInicial();
	public boolean getEsNuevo();
	public boolean getSurtir();
	public float getTotalInicial();
	public String getFormaPago();
    public short getTipoTurno();
	public String getNotas();
	public String getPedidoAdicional();
	public String getRemision();
	public int getDiasCredito();
	public Date getFechaCobranza();
	public Date getFechaEntrega();
	public String getPuntoEntrega();
	public String getObservaciones();
    public String getObservaciones2();
	public void setFocus(String campo);
	public boolean getModificando();
    public boolean getModificandoAutoventa();
    public boolean getSepararTotalesSubEmpresa();
    public String getFolioNegociacion();
    public void setFolioNegociacion(String folioNegociacion);
	
	public void setSoloLectura(boolean bsoloLectura);
	public void validarDesctoVendedor(float subTDetalle, float descuentoImp) throws Exception;
	//public int SeleccionaMoneda(String TransProdID) throws Exception;
	public void enableTipoPedido(boolean habilitar);
    public HashMap<String, Boolean> getTransProdTotalizados();

    public void solicitarImprimirTicket();
	public void calcularPromocionesConsigna(TransProd transProd);
}
