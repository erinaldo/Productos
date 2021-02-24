package com.elephantworks.movilvennda;

import android.annotation.SuppressLint;
import android.app.Application;
import android.util.Log;

import com.elephantworks.movilvennda.Modelos.Categorias;
import com.elephantworks.movilvennda.Modelos.Clientes;
import com.elephantworks.movilvennda.Modelos.Empresa;
import com.elephantworks.movilvennda.Modelos.ImpresoraHomologada;
import com.elephantworks.movilvennda.Modelos.Impuesto;
import com.elephantworks.movilvennda.Modelos.Inventario;
import com.elephantworks.movilvennda.Modelos.ModulosVennda;
import com.elephantworks.movilvennda.Modelos.Plan;
import com.elephantworks.movilvennda.Modelos.Productos;
import com.elephantworks.movilvennda.Modelos.PuntoVenta;
import com.elephantworks.movilvennda.Modelos.Staff;
import com.elephantworks.movilvennda.Utilerias.Constantes;
import com.elephantworks.movilvennda.Utilerias.Migracion;

import io.realm.Realm;
import io.realm.RealmConfiguration;


/**
 * Created by ldelatorre on 04/06/2017.
 */
public class Aplicacion extends Application {

    private static Realm realm;
    @SuppressLint("LongLogTag")
    @Override
    public void onCreate() {
        super.onCreate();

        Log.d("PATH donde se guarda archivo realm", getApplicationContext().getFilesDir().toString());
        Realm.init(this);

        RealmConfiguration config = new RealmConfiguration.Builder()
                .name("RealmSarcire")
                .modules(new ModulosVennda())
                .schemaVersion(Constantes.REALM_BD_VERSION)
                .migration(new Migracion())
                .build();

        realm = Realm.getInstance(config);

    }


    public Realm getRealmInstance()
    {
        return realm;
    }
}
