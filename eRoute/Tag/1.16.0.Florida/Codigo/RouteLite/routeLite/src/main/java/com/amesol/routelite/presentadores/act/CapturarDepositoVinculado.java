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
import com.amesol.routelite.datos.Dia;
import com.amesol.routelite.datos.SaldoDeposito;
import com.amesol.routelite.datos.Usuario;
import com.amesol.routelite.datos.basedatos.BDVend;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.generales.Entidad;
import com.amesol.routelite.datos.utilerias.Sesion;
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
    boolean capturaAdicional;

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

    public void setCapturaAdicional(boolean adicional){
        capturaAdicional = adicional;
    }

    public void cargaPedidos(boolean soloLectura)
    {
        List<ABNDetalle> pedidos = null;
        try
        {
            pedidos = Consultas.ConsultasAbono.obtenerAbonosConSaldoDeposito();
            mVista.initAdapterView(((CapturaDepositoVinculado) mVista).new AdapterABNDetalle(R.layout.lista_abonos_deposito, pedidos, false), R.id.lstDocumentos, null);

            if(capturaAdicional){
                List<SaldoDeposito> saldos = Consultas.ConsultasSaldoDeposito.obtenerSaldosPorAplicar();
                if (saldos.size() > 0) {
                    mVista.initAdapterView(((CapturaDepositoVinculado) mVista).new AdapterSaldoDeposito(R.layout.lista_saldos_deposito, saldos, false), R.id.lstSaldos, null);
                    mVista.mostrarSaldosDepositos(true);
                }else
                    mVista.mostrarSaldosDepositos(false);
            }
        }
        catch (Exception e)
        {
            //Log.e(TAG, "Error", e);
            mVista.mostrarError(e.getMessage());
        }
    }

    public void AgregarDeposito(String TipoBanco, String Cuenta, String Ficha, float Deposito, float DepositoAdicional, ArrayList<ABNDetalle> abdVinculados, ArrayList<SaldoDeposito> saldosVinculados)
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

        if (capturaAdicional){
            if (DepositoAdicional > 0) {
                SaldoDeposito saldoDeposito = Transacciones.Deposito.GenerarSaldoDeposito(mGenerarDeposito.DEPId, DepositoAdicional, ((Dia) Sesion.get(Sesion.Campo.DiaActual)).DiaClave);
                BDVend.guardarInsertar(saldoDeposito);
            }

            if (saldosVinculados != null) {
                if (saldosVinculados.size() > 0) {
                    for (int x = 0; x < saldosVinculados.size(); x++) {
                        BDVend.recuperar(saldosVinculados.get(x));
                        saldosVinculados.get(x).Aplicado = 1;
                        saldosVinculados.get(x).FechaAplicacion = Generales.getFechaHoraActual();
                        saldosVinculados.get(x).DepositoAplicadoID = mGenerarDeposito.DEPId;
                        saldosVinculados.get(x).MFechaHora = Generales.getFechaHoraActual();
                        saldosVinculados.get(x).MUsuarioID = ((Usuario) Sesion.get(Sesion.Campo.UsuarioActual)).USUId;
                        saldosVinculados.get(x).Enviado = false;
                        BDVend.guardarInsertar(saldosVinculados.get(x));
                    }
                }
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

                if (capturaAdicional) {
                    SaldoDeposito adicional = Consultas.ConsultasSaldoDeposito.obtenerDepositoAdicional(mDeposito.DEPId);
                    if (adicional != null)
                        BDVend.eliminar(adicional);

                    List<SaldoDeposito> saldos = Consultas.ConsultasSaldoDeposito.obtenerSaldosAplicados(mDeposito.DEPId);
                    if (saldos.size() > 0) {
                        for (int x = 0; x < saldos.size(); x++) {
                            saldos.get(x).Aplicado = 0;
                            saldos.get(x).FechaAplicacion = null;
                            saldos.get(x).DepositoAplicadoID = null;
                            saldos.get(x).MFechaHora = Generales.getFechaHoraActual();
                            saldos.get(x).MUsuarioID = ((Usuario) Sesion.get(Sesion.Campo.UsuarioActual)).USUId;
                            saldos.get(x).Enviado = false;
                            BDVend.guardarInsertar(saldos.get(x));
                        }
                    }
                }

                BDVend.commit();
                mVista.refrescarDeposito();
                cargaPedidos(false);
            }else{
                mVista.mostrarError(Mensajes.get("ME0837", "depósito"));
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
