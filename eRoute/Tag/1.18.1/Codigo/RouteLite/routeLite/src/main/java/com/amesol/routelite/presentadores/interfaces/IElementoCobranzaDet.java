package com.amesol.routelite.presentadores.interfaces;

import java.util.ArrayList;
import java.util.Date;
import java.util.LinkedList;

import com.amesol.routelite.actividades.Cobranza;
import com.amesol.routelite.presentadores.IVista;

public interface IElementoCobranzaDet extends IVista {
	
	public void capturarCobranzaDet(ArrayList<Integer> tiposCP);	
	
	public void poblarFormaPago(LinkedList<Cobranza.VistaSpinner> oPagos);
	
	public void poblarMoneda(LinkedList<Cobranza.VistaSpinner> oMonedas);
	
	public void poblarBanco(LinkedList<Cobranza.VistaSpinner> oBancos);
	
	public void setSaldoIni(float saldoini);
	
	public void setSaldoFin(float saldofin);

    public void setSaldoDescIni(float saldoDescIni);

    public void setSaldoDescFin(float saldoDescFin);
	
	public void setImporte(float importe);
	
	public void setTiposPagoConFecha(ArrayList<Integer> tiposPagoConFecha);
	
	public int getTipoPago();
	
	public String getMonedaId();
	
	public float getImporte();
	
	public int getTipoBanco();
	
	public String getReferencia();
	
	public Date getFechaCheque();

    public void mostrarDescuento();

    public void habilitarCuenta(boolean habilitar);

    public void setCuenta(String cuenta);

    public String getCuenta();

	public boolean getStatusCuenta();
}
