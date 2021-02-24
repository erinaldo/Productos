package com.elephantworks.movilvennda.Vistas;

import android.content.Context;
import android.content.Intent;
import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.text.TextUtils;
import android.view.ContextMenu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.widget.AdapterView;
import android.widget.Button;
import android.widget.ListView;
import android.widget.SearchView;

import com.elephantworks.movilvennda.Adaptadores.ClienteAdapter;
import com.elephantworks.movilvennda.Interfaces.ICliente;
import com.elephantworks.movilvennda.Modelos.Clientes;
import com.elephantworks.movilvennda.Presentadora.PresentadorCliente;
import com.elephantworks.movilvennda.R;
import com.elephantworks.movilvennda.Utilerias.MetodosEstaticos;

/**
 * Created by ldelatorre on 23/06/2017.
 */
public class ClienteActivity extends AppCompatActivity implements View.OnClickListener,ICliente, SearchView.OnQueryTextListener {

    PresentadorCliente mPresentador;
    private Context context = ClienteActivity.this;
    public ListView lvCliente;
    Button btnAgregarCliente;
    SearchView searchView;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_cliente);
        mPresentador = new PresentadorCliente(this,context);
        lvCliente = (ListView)findViewById(R.id.lvCliente);
        registerForContextMenu(lvCliente);
        mPresentador.cargarLista();

        btnAgregarCliente  = (Button) findViewById(R.id.btnAgregarCliente);
        btnAgregarCliente.setOnClickListener(this);

        searchView = (SearchView) findViewById(R.id.busquedaClientes);
        searchView.setIconifiedByDefault(false);
        searchView.setOnQueryTextListener(this);
        searchView.setSubmitButtonEnabled(true);
        searchView.setQueryHint(getResources().getString(R.string.txtBuscarClientes));
    }

    @Override
    public void cargarLista(ClienteAdapter adapter) {
       lvCliente.setAdapter(adapter);
    }

    @Override
    public void onCreateContextMenu(ContextMenu menu, View v, ContextMenu.ContextMenuInfo menuInfo)
    {
        super.onCreateContextMenu(menu,v,menuInfo);
        MenuInflater inflater = new MenuInflater(this);
        switch(v.getId()){
            case R.id.lvCliente:
                inflater.inflate(R.menu.menu_clientes, menu);
                break;
        }
    }

    @Override
    public boolean onContextItemSelected(MenuItem item) {
        AdapterView.AdapterContextMenuInfo info = null;
        Clientes lClientes = null;
        if (item.getMenuInfo() != null) {
            info = (AdapterView.AdapterContextMenuInfo) item.getMenuInfo();
            lClientes = (Clientes) lvCliente.getItemAtPosition((int) info.position);
            String idCliente = String.valueOf(lClientes.getIdCliente());
            String clave = lClientes.getClave();
            String razonSocial = lClientes.getRazonSocial();
            String listaPrecio = String.valueOf(lClientes.getListaPrecios());
            //String limiteCredito = lClientes.getLimiteCredito();//Falta en el modelo
            String diasCredito = String.valueOf(lClientes.getDiasCredito());
            String email = lClientes.getEmail();
            //String correo = lClientes.getCorreoElectronico();//Falta en el modelo
            String celular = lClientes.getTelefonoCelular();
            String rfc = lClientes.getRfc();
            String domicilio = lClientes.getDomicilio();
            String colonia = lClientes.getColonia();
            String codigoPostal = lClientes.getCp();

            switch (item.getItemId()) {
                case R.id.eliminarCliente:
                    mPresentador.eliminarCliente(Integer.parseInt(idCliente));
                    mPresentador.cargarLista();
                    return true;
                case R.id.editarCliente:
                    this.salir();
                    Intent modify_intent = new Intent(getApplicationContext(), ClienteModificarActivity.class);

                    modify_intent.putExtra("idCliente",idCliente);
                    modify_intent.putExtra("clave",clave);
                    modify_intent.putExtra("razonSocial",razonSocial);
                    modify_intent.putExtra("listaPrecio",listaPrecio);
                    modify_intent.putExtra("diasCredito",diasCredito);
                    modify_intent.putExtra("email",email);
                    modify_intent.putExtra("celular",celular);
                    modify_intent.putExtra("rfc",rfc);
                    modify_intent.putExtra("domicilio",domicilio);
                    modify_intent.putExtra("colonia",colonia);
                    modify_intent.putExtra("codigoPostal",codigoPostal);
                    startActivity(modify_intent);
                    return true;
            }
        }
        return false;
    }

    @Override
    public void onClick(View view) {
        if (view.getId() == findViewById(R.id.btnAgregarCliente).getId()) {
            Intent modify_intent = new Intent(context, ClienteModificarActivity.class);
            startActivity(modify_intent);
            salir();
        }
    }

    @Override
    public void error(String mensaje) {
        MetodosEstaticos.AlertDialogSimple(this,mensaje);
    }

    @Override
    public void salir() {
        finish();
    }

    @Override
    public boolean onQueryTextSubmit(String texto) {
        mPresentador.filtrarDatosLista(texto);
        return true;
    }

    @Override
    public boolean onQueryTextChange(String texto) {
        mPresentador.filtrarDatosLista(texto);
        return false;
    }
}
