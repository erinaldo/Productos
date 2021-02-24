package com.elephantworks.movilvennda.Presentadora;

import android.content.Context;
import android.content.Intent;
import android.widget.ArrayAdapter;

import com.elephantworks.movilvennda.Aplicacion;
import com.elephantworks.movilvennda.Interfaces.IClienteModificar;
import com.elephantworks.movilvennda.Modelos.Clientes;
import com.elephantworks.movilvennda.R;
import com.elephantworks.movilvennda.Vistas.ClienteActivity;

import java.util.LinkedList;

import io.realm.Realm;
import io.realm.RealmQuery;
import io.realm.RealmResults;

/**
 * Created by ldelatorre on 01/07/2017.
 */
public class PresentadorClienteModificar {
    private IClienteModificar mVista;
    private Context context;
    private Realm realm;

    public PresentadorClienteModificar(IClienteModificar mVista, Context context){
        this.mVista = mVista;
        this.context = context;
        realm = ((Aplicacion) context.getApplicationContext()).getRealmInstance();

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

    public void modificarCliente(final int idClienteInt, final String clave,final String razonSocial, final String listaPrecio,final String diasCredito,final String email,final String celular,final String rfc,final String domicilio,final String colonia,final String codigoPostal){

        realm.executeTransaction(new Realm.Transaction() {
            @Override
            public void execute(Realm realm2) {
                try {
                    RealmQuery<Clientes> query = realm.where(Clientes.class);
                    Clientes clientes = query.equalTo("idCliente", idClienteInt).findFirst();
                    clientes.setClave(clave);
                    clientes.setRazonSocial(razonSocial);
                    clientes.setListaPrecios(Integer.parseInt(listaPrecio));
                    clientes.setDiasCredito(Integer.parseInt(diasCredito));
                    clientes.setEmail(email);
                    clientes.setTelefonoCelular(celular);
                    clientes.setRfc(rfc);
                    clientes.setDomicilio(domicilio);
                    clientes.setColonia(colonia);
                    clientes.setCp(codigoPostal);
                    mVista.salir();

                } catch (Exception ex) {
                    mVista.error(ex.getMessage());
                }
            }
        });
    }
    public int obtenerUltimoId(){

        Number ultimoId = realm.where(Clientes.class).max("idCliente");
        int id;
        if(ultimoId == null) {
            id = 1;
        } else {
            id = ultimoId.intValue() + 1;
        }
        return id;
    }
    public void agregarCliente(final String clave,final String razonSocial, final String listaPrecio,final String diasCredito,final String email,final String celular,final String rfc,final String domicilio,final String colonia,final String codigoPostal){
        realm.executeTransaction(new Realm.Transaction() {
            @Override
            public void execute(Realm realm2) {
                try {
                    int ultimoId = obtenerUltimoId();
                    Clientes clientes = realm2.createObject(Clientes.class,ultimoId); // Create a new object
                    clientes.setClave(clave);
                    clientes.setRazonSocial(razonSocial);
                    clientes.setListaPrecios(Integer.parseInt(listaPrecio));
                    clientes.setDiasCredito(Integer.parseInt(diasCredito));
                    clientes.setEmail(email);
                    clientes.setTelefonoCelular(celular);
                    clientes.setRfc(rfc);
                    clientes.setDomicilio(domicilio);
                    clientes.setColonia(colonia);
                    clientes.setCp(codigoPostal);
                    clientes.setAlta(2);
                    clientes.setEnvio(0);
                    mVista.salir();
                }catch (Exception ex){
                    mVista.error(ex.getMessage());
                }
            }

        });
    }


    public void llenarSpinner(){

        LinkedList lista = new LinkedList();

        lista.add(new ObjetosListaPrecios(0, context.getResources().getString(R.string.spinnerSeleccionar)));

        for(int x = 1; x <= 5; x++){
            lista.add(new ObjetosListaPrecios(x,context.getResources().getString(R.string.listaPrecios).replace("$0$", String.valueOf(x)) ));
        }

        ArrayAdapter spinner_adapter = new ArrayAdapter(context, android.R.layout.simple_spinner_item, lista);
        spinner_adapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);

        mVista.cargarSpinnerListaPrecios(spinner_adapter);
    }
    public class ObjetosListaPrecios{
        int id;
        String nombre;
        //Constructor
        public ObjetosListaPrecios(int id, String nombre) {
            super();
            this.id = id;
            this.nombre = nombre;
        }
        @Override
        public String toString() {
            return nombre;
        }
        public int getId() {
            return id;
        }
    }
}
