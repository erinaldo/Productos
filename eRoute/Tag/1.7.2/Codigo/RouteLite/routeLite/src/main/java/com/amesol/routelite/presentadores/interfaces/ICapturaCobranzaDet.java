package com.amesol.routelite.presentadores.interfaces;

import java.util.ArrayList;
import java.util.Date;
import java.util.LinkedList;

import android.database.Cursor;

import com.amesol.routelite.actividades.Cobranza;
import com.amesol.routelite.actividades.ValorReferencia;
import com.amesol.routelite.presentadores.IVista;

public interface ICapturaCobranzaDet extends IVista
{

	public void mostrarCobranzaDet(Cobranza.VistaCobranza oCobranza, ArrayList<Cobranza.VistaDetalle> oDetalles);

	public void actualizarListaDet(ArrayList<Cobranza.VistaDetalle> oDetalles);

	//public void actualizarListaDet(Cobranza.VistaDetalle oDetalle);

	public void capturarCobranzaDet(ArrayList<Integer> tiposCP);

	public void setFolio(String folio);

	public void setFecha(Date fecha);

	public void setSaldoIni(float saldoini);

	public void setSaldoFin(float saldofin);

	public void setTotal(float total);

	public float getTotal();

	//public int getTipoPago();

	//public String getMonedaId();

	//public float getImporte();

	//public int getTipoBanco();

	//public String getReferencia();

	//public Date getFechaCheque();

	public void setFormasPago(LinkedList<Cobranza.VistaSpinner> oPagos);

	public void setMonedas(LinkedList<Cobranza.VistaSpinner> oMonedas);

	public void setBancos(LinkedList<Cobranza.VistaSpinner> oBancos);

}
