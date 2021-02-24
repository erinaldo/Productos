package com.elephantworks.movilvennda.Fragments;

import android.content.Intent;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Toast;

import com.elephantworks.movilvennda.Interfaces.IProductosVentas;
import com.elephantworks.movilvennda.Interfaces.IVentasMaster;
import com.elephantworks.movilvennda.Modelos.Productos;
import com.elephantworks.movilvennda.R;

/**
 * Created by ldelatorre on 10/06/2017.
 */
public class FragmentVentas extends Fragment implements IVentasMaster{

    private boolean esViewActivo = false;

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {

        View rootView = inflater.inflate(R.layout.fragment_ventas, container, false);
        setUserVisibleHint(false);

        FragmentListaVenta frgListadoVenta = (FragmentListaVenta) getChildFragmentManager().findFragmentById(R.id.frgListadoVentas);
        frgListadoVenta.setVentasMasterListener(this);

        FragmnetVentaMenu frgVentaMenu = (FragmnetVentaMenu) getChildFragmentManager().findFragmentById(R.id.frgVentasMenu);
        frgVentaMenu.setVentasMasterListener(this);

        return rootView;

    }


    @Override
    public void setUserVisibleHint(boolean isVisibleToUser) {
        super.setUserVisibleHint(isVisibleToUser);
        if (getView() != null){
            //esViewActivo = true;
            if(isVisibleToUser){

                refrescarLista();
                refrescarTotales();
            }
        }else{
            esViewActivo = false;
        }
    }

    @Override
    public void actualizarTotales() {
        refrescarTotales();
    }

    @Override
    public void limpiarListas() {
        refrescarLista();
    }

    public void refrescarTotales(){
        boolean hayListado2 = (getChildFragmentManager().findFragmentById(R.id.frgVentasMenu) != null);

        if(hayListado2){
            ((FragmnetVentaMenu) getChildFragmentManager().findFragmentById(R.id.frgVentasMenu)).refrescarTotales();
        }
    }

    public void refrescarLista(){
        boolean hayListado = (getChildFragmentManager().findFragmentById(R.id.frgListadoVentas) != null);

        if(hayListado){
            ((FragmentListaVenta) getChildFragmentManager().findFragmentById(R.id.frgListadoVentas)).agregarProductoLista();
        }
    }

}
