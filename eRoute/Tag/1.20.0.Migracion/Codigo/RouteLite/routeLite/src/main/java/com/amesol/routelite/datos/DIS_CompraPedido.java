package com.amesol.routelite.datos;

import com.amesol.routelite.datos.annotations.Campo;
import com.amesol.routelite.datos.annotations.Llave;
import com.amesol.routelite.datos.annotations.TablaDef;
import com.amesol.routelite.datos.generales.Entidad;

/**
 * Created by ldelatorre on 04/03/2018.
 */

@TablaDef(orden=1)
public class DIS_CompraPedido extends Entidad {

    @Llave
    @Campo
    public String ClienteClave;

    public float CaM_CajasMensual;
    public float Mes_DescMensual;
    public float CaM_VicCuaMed;
    public float CaM_CorCuaMed;
    public float CaM_Ocer;
    public float CaM_CorVicModBote;
    public float CaM_CorVicFamMega;
    public float CaM_CerBarril;
    public float CaM_Agua1L;
    public float CaM_OtrosPro;
    public float CaM_Agua600;
    public float CaM_AguaTot;
    public float CaM_CerTot;
    public float CaA_CajasMensual;
    public float Act_DescMensual;
    public float CaA_VicCuaMed;
    public float CaA_CorCuaMed;
    public float CaA_Ocer;
    public float CaA_CorVicModBote;
    public float CaA_CorVicFamMega;
    public float CaA_CerBarril;
    public float CaA_Agua1L;
    public float CaA_OtrosPro;
    public float CaA_Agua600;
    public float CaA_AguaTot;
    public float CaA_CerTot;
    public String Fe_VicCuaMed;
    public String Fe_CorCuaMed;
    public String Fe_OCer;
    public String Fe_CorVicModBote;
    public String Fe_CorVicFamMega;
    public String Fe_CerBarril;
    public String Fe_Agua1L;
    public String Fe_OtrosPro;
    public String Fe_Agua600;
    public float CaU_VicCuaMed;
    public float CaU_CorCuaMed;
    public float CaU_Ocer;
    public float CaU_CorVicModBote;
    public float CaU_CorVicFamMega;
    public float CaU_CerBarril;
    public float CaU_Agua1L;
    public float CaU_OtrosPro;
    public float CaU_Agua600;

}
