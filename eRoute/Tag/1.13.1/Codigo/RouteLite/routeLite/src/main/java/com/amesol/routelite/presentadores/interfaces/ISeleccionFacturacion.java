package com.amesol.routelite.presentadores.interfaces;

import java.util.List;
import java.util.Map;

import android.widget.AdapterView.OnItemSelectedListener;
import android.widget.ArrayAdapter;
import android.widget.Spinner;

import com.amesol.routelite.datos.Cliente;
import com.amesol.routelite.datos.ClienteDomicilio;
import com.amesol.routelite.datos.FolioFiscal;
import com.amesol.routelite.datos.SEMHist;
import com.amesol.routelite.datos.TransProd;
import com.amesol.routelite.datos.generales.Entidad;
import com.amesol.routelite.presentadores.IVista;
import com.amesol.routelite.presentadores.act.SeleccionarFacturacion.TransProdFactura;
import com.amesol.routelite.utilerias.ControlError;
import com.amesol.routelite.vistas.TRPDatoFiscal;

public interface ISeleccionFacturacion extends IVista
{
	public void mostrarFacturas(List<TransProdFactura> facturas);
	public void iniciaNuevaFactura();
	public void initSpinners();
	public OnItemSelectedListener getListenerSpinners();
	public void setContinuar(boolean continuar);
	public void initAdapterView(ArrayAdapter<? extends Entidad> adapter, int idList);
	public SEMHist getSubEmpresaSeleccionada();
	public int getFormaDeVentaSeleccionada();
	public void actualizaTotalFactura(float total);
	public void setVisivilityTotalFactura(int visibility);
	public void setEnabledControles(int panelIndice, boolean enabled);
	public void cargaDatosDeFacturacion(Cliente cliente, ClienteDomicilio domicilioFiscal, TRPDatoFiscal...datoFiscal);
	public FolioFiscal getFolio();
	public float getTotalFactura();
	public String getOrdenCompra();
	public List<? extends Entidad> getPedidosParaFactura();
	public String[] getMetodosPagoSeleccionados();
	public void setSoloLectura(boolean b);
	public void cargarDetalleFactura(TransProd factura, TRPDatoFiscal datoFiscal);
	public List<? extends Entidad> getPedidosDeFactura();
}
