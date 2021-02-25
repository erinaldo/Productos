package com.amesol.routelite.presentadores.act;

import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.presentadores.Presentador;
import com.amesol.routelite.presentadores.interfaces.ICapturaFirma;

/**
 * Created by Adriana on 08/11/2016.
 */
public class CapturarFirma extends Presentador {

    private ICapturaFirma mVista;

    public CapturarFirma(ICapturaFirma vista, String accion)
    {
        mVista = vista;
    }

    @Override
    public void iniciar()
    {
//        try
//        {
//
//            if (mCamionVendedor.KmInicial == 0 && mCamionVendedor.KmFinal == 0)
//            {
//                mVista.setCapturaInicial(false);
//            }
//            else if (mCamionVendedor.KmInicial != 0 && mCamionVendedor.KmFinal == 0)
//            {
//                mVista.setCapturaInicial(true);
//                CamionVendedor mCamion = Consultas.ConsultasKilometraje.obtenerCamion(mCamionVendedor.Placa);
//                //mVista.setValores(mCamionVendedor.Placa, mCamion.Clave, String.valueOf(mCamionVendedor.KmInicial));
//                mVista.setValores(mCamionVendedor.Placa, mCamion.Clave, String.valueOf((int) mCamionVendedor.KmInicial));
//            }
//        }
//        catch (Exception e)
//        {
//            e.printStackTrace();
//        }
    }

    public void asignaValores(){
        mVista.getNombre();
        mVista.getNombreArchivo();
    }
}
