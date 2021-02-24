package com.elephantworks.movilvennda.Fragments;

import android.app.Activity;
import android.content.Context;
import android.support.v4.app.Fragment;
import android.os.Bundle;
import android.support.v4.app.FragmentActivity;
import android.support.v4.app.FragmentTransaction;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import com.elephantworks.movilvennda.Interfaces.ICategoriasProductos;
import com.elephantworks.movilvennda.Interfaces.IProductos;
import com.elephantworks.movilvennda.R;
import com.elephantworks.movilvennda.Utilerias.Constantes;

/**
 * Created by ldelatorre on 10/06/2017.
 */
public class FragmentProductos extends Fragment implements ICategoriasProductos{


    public static FragmentProductos newInstance(){
        FragmentProductos fragmentt = new FragmentProductos();
        return fragmentt;
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {

        View rootView = inflater.inflate(R.layout.fragment_productos, container, false);
        setUserVisibleHint(false);

        FragmentListadoCategorias frgListadoCat = (FragmentListadoCategorias) getChildFragmentManager().findFragmentById(R.id.frgListadoCategorias);
        frgListadoCat.setCategoriasProductosListener(this);
        return rootView;
    }


    @Override
    public void cambiarTexto(int id) {
        this.refrescarLista(id);
    }

    @Override
    public void setUserVisibleHint(boolean isVisibleToUser) {
        super.setUserVisibleHint(isVisibleToUser);
        if (getView() != null){
            //esViewActivo = true;
            if(isVisibleToUser){
                refrescarLista(Constantes.TodasCategorias.TODAS_CATEGORIAS);
                refrescarListaCat();
            }
        }
    }

    public void refrescarLista(int id){
        boolean hayListado = (getChildFragmentManager().findFragmentById(R.id.frgListadoProductos) != null);

        if(hayListado){
            ((FragmentListaProductos) getChildFragmentManager().findFragmentById(R.id.frgListadoProductos)).cambiarLista(id);
        }
    }

    public void refrescarListaCat(){
        boolean hayListado = (getChildFragmentManager().findFragmentById(R.id.frgListadoCategorias) != null);

        if(hayListado){
            ((FragmentListadoCategorias) getChildFragmentManager().findFragmentById(R.id.frgListadoCategorias)).cambiarLista();
        }
    }


}
