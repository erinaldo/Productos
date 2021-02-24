package com.elephantworks.movilvennda.Presentadora;

import android.content.Context;
import android.widget.Toast;

import com.elephantworks.movilvennda.Adaptadores.ClienteAdapter;
import com.elephantworks.movilvennda.Aplicacion;
import com.elephantworks.movilvennda.Interfaces.ICliente;
import com.elephantworks.movilvennda.Modelos.Clientes;
import com.elephantworks.movilvennda.Utilerias.MetodosEstaticos;

import io.realm.Realm;
import io.realm.RealmQuery;
import io.realm.RealmResults;

/**
 * Created by ldelatorre on 23/06/2017.
 */
public class PresentadorCliente {

    private ICliente mVista;
    private Context context;
    private Realm realm;
    private ClienteAdapter mCliente;


    public PresentadorCliente(ICliente mVista, Context context){
        this.mVista = mVista;
        this.context = context;
        realm = ((Aplicacion) context.getApplicationContext()).getRealmInstance();

    }

    public void cargarLista(){
        try {
            RealmQuery<Clientes> query = realm.where(Clientes.class);
            RealmResults<Clientes> listaClientes = query.findAll();

            ClienteAdapter adapter = new ClienteAdapter(context, listaClientes);
            mVista.cargarLista(adapter);
        }catch (Exception ex){
            mVista.error(ex.getMessage());
        }
    }

    public Boolean validarTipoCliente(final int idCliente){
        Boolean clienteMovil = false;
        try {
            RealmQuery<Clientes> query = realm.where(Clientes.class);
            RealmResults<Clientes> cliente = query.equalTo("idCliente", idCliente).findAll();

            for (Clientes clientes : cliente) {
                //Si trae 2 es movil, si es 1 es web
                if (clientes.getAlta() == 2) {
                    clienteMovil = true;
                }
            }
        }catch (Exception ex){
            mVista.error(ex.getMessage());
        }
        return clienteMovil;
    }

    public void eliminarCliente(final int idClienteInt){
        Boolean clienteMovil = validarTipoCliente(idClienteInt);
        if (clienteMovil.equals(true)) {
            realm.executeTransaction(new Realm.Transaction() {
                @Override
                public void execute(Realm realm2) {
                    try {
                        RealmQuery<Clientes> query = realm.where(Clientes.class);
                        Clientes clientes = query.equalTo("idCliente", idClienteInt).findFirst();
                        clientes.deleteFromRealm();
                        CharSequence text = "Se elimino un cliente";
                        int duration = Toast.LENGTH_SHORT;
                        Toast toast = Toast.makeText(context, text, duration);
                        toast.show();
                    } catch (Exception ex) {
                        mVista.error(ex.getMessage());
                    }
                }
            });
        }else{
            String text = "No es posible eliminar al cliente, debido a que ha sido creado en web";
            MetodosEstaticos.AlertDialogSimple(context, text, "Aviso");
        }
    }

    public void filtrarDatosLista(String nombreCliente) {
        try {
            RealmQuery<Clientes> query;
            if (nombreCliente.equals("")){
                query = realm.where(Clientes.class);
            }else{
                query = realm.where(Clientes.class).contains("razonSocial", nombreCliente);
            }
            RealmResults<Clientes> listaProductos = query.findAll();

            ClienteAdapter adapter = new ClienteAdapter(context, listaProductos);
            mVista.cargarLista(adapter);
        }catch (Exception ex){
            mVista.error(ex.getMessage());
        }
    }

}
