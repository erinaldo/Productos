package com.elephantworks.movilvennda.Fragments;


import android.content.Context;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.text.TextUtils;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.ListView;
import android.widget.SearchView;

import com.elephantworks.movilvennda.Adaptadores.CategoriaAdapter;
import com.elephantworks.movilvennda.Interfaces.ICategoriasProductos;
import com.elephantworks.movilvennda.Interfaces.IListadoCategorias;
import com.elephantworks.movilvennda.Modelos.Categorias;
import com.elephantworks.movilvennda.Modelos.Clientes;
import com.elephantworks.movilvennda.Presentadora.PresentadorListadoCategorias;
import com.elephantworks.movilvennda.R;
import com.elephantworks.movilvennda.Utilerias.MetodosEstaticos;

/**
 * A simple {@link Fragment} subclass.
 */
public class FragmentListadoCategorias extends Fragment implements IListadoCategorias{

    private Context context = null;
    private PresentadorListadoCategorias mPresenator;
    ListView lvCategorias;
    private ICategoriasProductos listener;


    public FragmentListadoCategorias() {
        // Required empty public constructor
    }

    public void setCategoriasProductosListener(ICategoriasProductos listener){
        this.listener = listener;
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {

        View rootView = inflater.inflate(R.layout.fragment_listado_categorias, container, false);
        context = rootView.getContext();

        this.inicializar(rootView);
        mPresenator = new PresentadorListadoCategorias(this,context);

        mPresenator.cargarCategorias();

        return rootView;
    }

    public void inicializar(View view){
        lvCategorias = (ListView) view.findViewById(R.id.lvCategorias);
        lvCategorias.setEmptyView(view.findViewById(R.id.emptyListView));


        lvCategorias.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> adapterView, View view, int pos, long id) {

                if (listener != null){
                    Categorias categorias = (Categorias) lvCategorias.getItemAtPosition(pos);
                   listener.cambiarTexto(categorias.getIdCategoria());
                }
            }
        });
    }

    @Override
    public void llenarLista(CategoriaAdapter adapter) {
        lvCategorias.setAdapter(adapter);
    }

    @Override
    public void error(String mensaje) {
        MetodosEstaticos.AlertDialogSimple(context,mensaje);
    }

    public void cambiarLista(){
            mPresenator.cargarCategorias();
    }

}
