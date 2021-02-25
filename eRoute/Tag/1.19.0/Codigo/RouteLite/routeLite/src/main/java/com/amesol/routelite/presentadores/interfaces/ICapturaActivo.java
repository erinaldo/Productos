package com.amesol.routelite.presentadores.interfaces;

import com.amesol.routelite.datos.annotations.Campo;
import com.amesol.routelite.presentadores.IVista;

import java.util.Date;

public interface ICapturaActivo extends IVista {
    void setIdElectronico(String idElectronico);
    void setAltura(float altura);
    void setAncho(float ancho);
    void setProfundidad(float profundidad);
    void setComentario(String comentario);
    void setNotaAsignacion(String clienteClave);
    void setImagen(String idImagen);

    short getTipoFase();
    String getComentario();

    String getClave();
    short getTipo();
    boolean getTomoFoto();
    //Float getAltura();
    void setFocus(String nombreCampo);
}

