package com.amesol.routelite.presentadores.interfaces;

import com.amesol.routelite.datos.annotations.Campo;
import com.amesol.routelite.presentadores.IVista;

import java.util.Date;

public interface ICapturaMercadeo extends IVista {
    void setCliente(String cliente);
    void setRuta(String ruta);
    void setDia(String dia);
    String getMPRId();
    void setMPRId(String pMPRId);
    String getProducto();
    String getMEMId();
    void setMEMId(String pMEMId);
    String getMarca();
    short getPresentacion();
    void setPresentacion(String pPresentacion);
    String getPresentacion2();
    short getTipo();
    void setTipo(String pTipo);
    String getTipo2();
    Float getPrecio();
    void setPrecio(Float pPrecio);
    Float getPrecioOferta();
    void setPrecioOferta(Float pPrecioOferta);
    Integer getCantidad();
    void setCantidad(Integer pCantidad);
    Date getVigenciaOferta();
    void setVigenciaOferta(Date pVigenciaOferta);
    String getNotas();
    void setNotas(String pNotas);
    String getMRDId();
    void setFocus(String nombreCampo);
}

