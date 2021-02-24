package com.elephantworks.movilvennda.Presentadora;

import android.content.Context;
import android.widget.ArrayAdapter;

import com.elephantworks.movilvennda.Adaptadores.CategoriaAdapter;
import com.elephantworks.movilvennda.Aplicacion;
import com.elephantworks.movilvennda.Interfaces.IListadoCategorias;
import com.elephantworks.movilvennda.Modelos.Categorias;
import com.elephantworks.movilvennda.Modelos.ValoresReferencia;
import com.elephantworks.movilvennda.Utilerias.Session;

import java.util.LinkedList;

import io.realm.Realm;
import io.realm.RealmQuery;
import io.realm.RealmResults;

/**
 * Created by ldelatorre on 02/07/2017.
 */
public class PresentadorListadoCategorias {

    private IListadoCategorias mVistas;
    private Context context;
    private Session session;
    private Realm realm;

    public PresentadorListadoCategorias(IListadoCategorias mVistas, Context context) {
        this.mVistas = mVistas;
        this.context = context;
        realm = ((Aplicacion) context.getApplicationContext()).getRealmInstance();
        session = new Session(context);
    }

    public void cargarCategorias(){

        try {
            RealmQuery<Categorias> query = realm.where(Categorias.class);
            RealmResults<Categorias> listaClientes = query.findAll();

            CategoriaAdapter adapter = new CategoriaAdapter(context, listaClientes);
            mVistas.llenarLista(adapter);
        }catch (Exception ex){
            mVistas.error(ex.getMessage());
        }

    }
}
