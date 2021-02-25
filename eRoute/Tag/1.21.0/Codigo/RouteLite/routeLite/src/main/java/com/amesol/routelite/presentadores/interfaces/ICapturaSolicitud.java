package com.amesol.routelite.presentadores.interfaces;

import com.amesol.routelite.presentadores.IVista;
import com.amesol.routelite.presentadores.act.CapturarSolicitud;

import java.util.LinkedList;

/**
 * Created by Adriana on 26/12/2016.
 */
public interface ICapturaSolicitud extends IVista {

    public void setFolio(String sFolio);
    public void setTipoPeticion(short nTipoPeticion);
    public void setTipoArea(short nTipoArea);
    public void setConcepto(String sConcepto);
    public void setComentario(String sComentario);

    public void setTiposPeticion(LinkedList<CapturarSolicitud.VistaSpinner> oPeticion);
    public void setTiposArea(LinkedList<CapturarSolicitud.VistaSpinner> oArea);

    public boolean getEsNuevo();
    public String getFolio();
    public short getTipoPeticion();
    public short getTipoArea();
    public String getConcepto();
    public String getComentario();
}
