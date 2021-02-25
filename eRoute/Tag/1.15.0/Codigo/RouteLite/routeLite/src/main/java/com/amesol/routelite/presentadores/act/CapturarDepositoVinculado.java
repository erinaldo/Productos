package com.amesol.routelite.presentadores.act;

import android.content.Context;
import android.util.Log;
import android.view.inputmethod.InputMethodManager;

import com.amesol.routelite.R;
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.actividades.Transacciones;
import com.amesol.routelite.datos.ABNDetalle;
import com.amesol.routelite.datos.AbdDep;
import com.amesol.routelite.datos.Deposito;
import com.amesol.routelite.datos.basedatos.BDVend;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.generales.Entidad;
import com.amesol.routelite.presentadores.Presentador;
import com.amesol.routelite.presentadores.interfaces.ICapturaDepositoVinculado;
import com.amesol.routelite.utilerias.Generales;
import com.amesol.routelite.vistas.CapturaDepositoVinculado;
import com.amesol.routelite.vistas.CapturaPreLiquidacion;

import java.util.ArrayList;
import java.util.List;

public class CapturarDepositoVinculado  extends Presentador
{
    private ICapturaDepositoVinculado mVista;
    String mAccion;

    public CapturarDepositoVinculado(ICapturaDepositoVinculado vista, String accion)
    {
        mVista = vista;
        mAccion = accion;
    }

    @Override
    public void iniciar() {
        cargaPedidos(false);
        mVista.refrescarDeposito();
    }



    public void cargaPedidos(boolean soloLectura)
    {
        List<ABNDetalle> pedidos = null;
        try
        {
            pedidos = Consultas.ConsultasAbono.obtenerAbonosConSaldoDeposito();

            mVista.initAdapterView(((CapturaDepositoVinculado) mVista).new AdapterABNDetalle(R.layout.lista_abonos_deposito, pedidos,false), R.id.lstDocumentos, null);

        }
        catch (Exception e)
        {
            //Log.e(TAG, "Error", e);
            mVista.mostrarError(e.getMessage());
        }
    }

    public void AgregarDeposito(String TipoBanco, String Cuenta, String Ficha, float Deposito, ArrayList<ABNDetalle> abdVinculados)
    {
    try
    {
        com.amesol.routelite.datos.Deposito mGenerarDeposito = Transacciones.Deposito.GenerarDeposito(Integer.parseInt(TipoBanco),Cuenta, Ficha, Deposito, abdVinculados);
        BDVend.guardarInsertar(mGenerarDeposito);
        //guardar saldos

        if(abdVinculados.size()>0) {
            for (int x = 0; x < abdVinculados.size(); x++) {
                BDVend.guardarInsertar(abdVinculados.get(x));
            }
        }
        BDVend.commit();
        mVista.setLimpiarDeposito();
        mVista.refrescarDeposito();
        cargaPedidos(false);
        mVista.HideKeyboard();

    }
    catch (Exception ex)
    {
        if (ex != null && ex.getMessage() != null) {
            mVista.mostrarError(ex.getMessage());
        }else{
            mVista.mostrarError("Error al guardar el depósito");
        }
    }

}
    public void eliminarDeposito(String DEPId)
    {
        try
        {
            Deposito mDeposito = new Deposito();
            mDeposito.DEPId = DEPId;
            BDVend.recuperar(mDeposito);
            BDVend.recuperar(mDeposito, AbdDep.class);
            if (mDeposito.isRecuperado() && !mDeposito.Enviado) {
                BDVend.eliminar(mDeposito);
                for (int x = 0; x < mDeposito.AbdDep.size(); x++) {
                    ABNDetalle abn = new ABNDetalle();
                    abn.ABNId = mDeposito.AbdDep.get(x).ABNId;
                    abn.ABDId = mDeposito.AbdDep.get(x).ABDId;
                    BDVend.recuperar(abn);
                    if (abn.isRecuperado()){
                        abn.SaldoDeposito = abn.SaldoDeposito + mDeposito.AbdDep.get(x).Importe;
                        abn.MFechaHora = Generales.getFechaHoraActual();
                        abn.Enviado = false;
                        BDVend.guardarInsertar(abn);
                    }
                }
                BDVend.commit();
                mVista.refrescarDeposito();
                cargaPedidos(false);
            }else{
                mVista.mostrarError(Mensajes.get("ME0837","depósito"));
            }
        }
        catch (Exception e)
        {
            if ( e != null && e.getMessage() != null){
                mVista.mostrarError(e.getMessage());
            }else{
                mVista.mostrarError("Error al eliminar el depósito");
            }
            try{
                BDVend.rollback();
            }catch (Exception ex){

            }
        }
    }
}
