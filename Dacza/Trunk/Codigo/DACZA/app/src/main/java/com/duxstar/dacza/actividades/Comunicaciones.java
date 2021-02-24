package com.duxstar.dacza.actividades;

import com.duxstar.dacza.datos.basedatos.Consultas;

/**
 * Created by Adriana on 30/06/2016.
 */
public class Comunicaciones {

    public static boolean ExistenDatosSinEnviar(){
        try {
            if (Consultas.ConsultasFolio.haySinEnviar())
                return true;
            if (Consultas.ConsultasInventario.haySinEnviar())
                return true;
            if (Consultas.ConsultasOrdenTrabajo.haySinEnviar())
                return true;
            if (Consultas.ConsultasRecarga.haySinEnviar())
                return true;
            if (Consultas.ConsultasDevolucion.haySinEnviar())
                return true;

            return false;
        }catch (Exception e)
        {
            e.printStackTrace();
            return true;
        }
    }
}
