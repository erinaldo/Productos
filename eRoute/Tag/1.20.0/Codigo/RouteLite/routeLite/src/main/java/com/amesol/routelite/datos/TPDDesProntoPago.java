package com.amesol.routelite.datos;

import java.util.Date;

import com.amesol.routelite.datos.annotations.Campo;
import com.amesol.routelite.datos.annotations.Llave;
import com.amesol.routelite.datos.annotations.LlaveForanea;
import com.amesol.routelite.datos.annotations.TablaDef;
import com.amesol.routelite.datos.generales.Entidad;

@TablaDef(orden=15)
public class TPDDesProntoPago extends Entidad {
    @Llave
    @LlaveForanea(nombreCampoForaneo = "TransProdID", tablaPadre = TransProdDetalle.class)
    public String TransProdID;

    @Llave
    @LlaveForanea(nombreCampoForaneo = "TransProdDetalleID", tablaPadre = TransProdDetalle.class)
    public String TransProdDetalleID;

    @LlaveForanea(nombreCampoForaneo = "PromocionClave", tablaPadre = Promocion.class)
    public String PromocionClave;

    @Campo
    public float Porcentaje;

    @Campo
    public Date MFechaHora;

    @Campo
    public String MUsuarioID;

    @Campo
    public boolean Enviado;

    @Override
    public boolean equals (Object object) {
        boolean result = false;
        if (object == null || object.getClass() != getClass()) {
            result = false;
        } else {
            TPDDesProntoPago tpdDesProntoPago = (TPDDesProntoPago) object;
            if (this.TransProdID.equals(tpdDesProntoPago.TransProdID) && this.TransProdDetalleID.equals(tpdDesProntoPago.TransProdDetalleID)) {
                result = true;
            }
        }
        return result;
    }
}
