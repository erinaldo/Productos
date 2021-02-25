package com.amesol.routelite.presentadores.interfaces;


import android.view.View;
import android.widget.ArrayAdapter;

import com.amesol.routelite.datos.generales.Entidad;
import com.amesol.routelite.presentadores.IVista;


public interface ICapturaDepositoVinculado extends IVista{
    public void initAdapterView(ArrayAdapter<? extends Entidad> adapter, int idList, View vista);
    public void refrescarDeposito();

    public void setLimpiarDeposito();
    public void HideKeyboard();
    public void mostrarSaldosDepositos(boolean mostrar);
}
