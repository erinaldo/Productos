package com.amesol.routelite.presentadores.interfaces;

import com.amesol.routelite.actividades.Cobranza;
import com.amesol.routelite.presentadores.IVista;

import java.util.ArrayList;
import java.util.Date;
import java.util.LinkedList;

/**
 * Created by projas on 08/10/2015.
 */
public interface ICapturaCobranzaPedidoAnticipado  extends IVista {

    //public void mostrarCobranzaDet(Cobranza.VistaCobranza oCobranza, ArrayList<Cobranza.VistaDetalle> oDetalles);

    //public void capturarCobranzaDet(ArrayList<Integer> tiposCP);

    public void setFolio(String folio);

    public void setFecha(Date fecha);

    public void setSaldoIni(float saldoini);

    public void setSaldoFin(float saldofin);

    //public void setTotal(float total);

    //public float getTotal();

    public float getImporte();

    public String getMonedaId();

    public short getTipoBanco();

    public short getTipoPago();

    public String getReferencia();

    public Date getFechaCheque();

    public void setFormasPago(LinkedList<Cobranza.VistaSpinner> oPagos);

    public void setMonedas(LinkedList<Cobranza.VistaSpinner> oMonedas);

    public void setBancos(LinkedList<Cobranza.VistaSpinner> oBancos);

}
