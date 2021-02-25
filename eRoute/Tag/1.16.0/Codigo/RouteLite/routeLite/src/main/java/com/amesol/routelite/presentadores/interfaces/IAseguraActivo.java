package com.amesol.routelite.presentadores.interfaces;

import com.amesol.routelite.datos.annotations.Campo;
import com.amesol.routelite.presentadores.IVista;

import java.util.Date;

public interface IAseguraActivo extends IVista {
    void setCliente(String cliente);
    void setRuta(String ruta);
    void setDia(String dia);
    void setActivoClave(String activoClave);
    void setNombre(String nombre);
    void setTipo(String tipo);
    void setContador(String contador);

    void iniciarVisita(int asignados, int asegurados);
}

