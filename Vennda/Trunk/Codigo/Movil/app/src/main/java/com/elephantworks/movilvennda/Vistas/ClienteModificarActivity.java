package com.elephantworks.movilvennda.Vistas;

import android.app.Activity;
import android.content.Context;
import android.content.Intent;
import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Spinner;
import android.widget.Toast;

import com.elephantworks.movilvennda.Adaptadores.ClienteAdapter;
import com.elephantworks.movilvennda.Interfaces.IClienteModificar;
import com.elephantworks.movilvennda.Presentadora.PresentadorCliente;
import com.elephantworks.movilvennda.Presentadora.PresentadorClienteModificar;
import com.elephantworks.movilvennda.R;
import com.elephantworks.movilvennda.Utilerias.MetodosEstaticos;

/**
 * Created by ldelatorre on 01/07/2017.
 */
public class ClienteModificarActivity extends AppCompatActivity implements View.OnClickListener, IClienteModificar{

    String idCliente = "";
    EditText etClave;
    EditText etRazonSocial;
    Spinner sListaPrecio;
    EditText etDiasCredito;
    EditText etEmail;
    EditText etCelular;
    EditText etRfc;
    EditText etDomicilio;
    EditText etColonia;
    EditText etCodigoPostal;
    Button btnGuardarCliente;
    PresentadorClienteModificar mPresentador;
    private Context context = ClienteModificarActivity.this;

    @Override
    protected  void onCreate(Bundle savedInstanceState){
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_modificar_cliente);
        mPresentador = new PresentadorClienteModificar(this,context);

        Intent i = getIntent();
        idCliente = i.getStringExtra("idCliente");
        String clave = i.getStringExtra("clave");
        String razonSocial = i.getStringExtra("razonSocial");
        String listaPrecio = i.getStringExtra("listaPrecio");
        String diasCredito = i.getStringExtra("diasCredito");
        String email = i.getStringExtra("email");
        String celular = i.getStringExtra("celular");
        String rfc = i.getStringExtra("rfc");
        String domicilio = i.getStringExtra("domicilio");
        String colonia = i.getStringExtra("colonia");
        String codigoPostal = i.getStringExtra("codigoPostal");

        etClave = (EditText) findViewById(R.id.etClave);
        etClave.setText(clave);

        etRazonSocial = (EditText) findViewById(R.id.etRazonSocial);
        etRazonSocial.setText(razonSocial);


        //Lo comente porque no se como asignarle el valor al spinner
        sListaPrecio = (Spinner) findViewById(R.id.sListaPrecio);

        etDiasCredito = (EditText) findViewById(R.id.etDiasCredito);
        etDiasCredito.setText(diasCredito);


        etEmail = (EditText) findViewById(R.id.etEmail);
        etEmail.setText(email);


        etCelular = (EditText) findViewById(R.id.etCelular);
        etCelular.setText(celular);


        etRfc = (EditText) findViewById(R.id.etRFC);
        etRfc.setText(rfc);


        etDomicilio = (EditText) findViewById(R.id.etDomicilio);
        etDomicilio.setText(domicilio);


        etColonia = (EditText) findViewById(R.id.etColonia);
        etColonia.setText(colonia);


        etCodigoPostal = (EditText) findViewById(R.id.etCodigoPostal);
        etCodigoPostal.setText(codigoPostal);

        mPresentador.llenarSpinner();

        if(listaPrecio != null){
            if(!listaPrecio.equals("")){
                sListaPrecio.setSelection(Integer.parseInt(listaPrecio));
            }
        }


        btnGuardarCliente = (Button) findViewById(R.id.btnGuardarCliente);
        btnGuardarCliente.setOnClickListener(this);

    }

    public boolean validarEntero(String text){
        Boolean exito = false;

        try {
            int num = Integer.parseInt(text);
            exito = true;
        } catch (NumberFormatException e) {

        }
        return exito;
    }

    @Override
    public void onClick(View view) {
        try {
            if (view.getId() == findViewById(R.id.btnGuardarCliente).getId()) {

                int idClienteInt = 0;
                if (idCliente != null) {
                    idClienteInt = Integer.parseInt(idCliente);
                }
                String etclaveRcv = etClave.getText().toString().trim();
                String razonSocial = etRazonSocial.getText().toString().trim();
                String listaPrecio = String.valueOf(sListaPrecio.getSelectedItemId()); //Lo comente porque no se como obtener el valor del spinner  sListaPrecio.getTextAlignment()
                String diasCredito = etDiasCredito.getText().toString().trim();
                String email = etEmail.getText().toString().trim();
                String celular = etCelular.getText().toString().trim();
                String rfc = etCelular.getText().toString().trim();
                String domicilio = etDomicilio.getText().toString().trim();
                String colonia = etColonia.getText().toString().trim();
                String codigoPostal = etCodigoPostal.getText().toString().trim();
                //int listaPrecioId = ((int) sListaPrecio.getSelectedItemId());

                boolean exitoListaPrecio = validarEntero(listaPrecio);
                boolean exitoDiasCredito = validarEntero(diasCredito);

                //Validar que los campos requeridos vengan llenos
                if (idCliente != "" && idCliente != null) {
                    //Validar campos llenos
                    if (razonSocial != "" && razonSocial != null &&
                            listaPrecio != "" && listaPrecio != null &&
                            diasCredito != "" && diasCredito != null &&
                            rfc != "" && rfc != null &&
                            exitoListaPrecio == true && exitoDiasCredito == true) {
                        //Validar que haya sido creado en movil para poder modificar
                        Boolean clienteMovil = mPresentador.validarTipoCliente(Integer.parseInt(idCliente));
                        if (clienteMovil.equals(true)) {
                            mPresentador.modificarCliente(idClienteInt, etclaveRcv, razonSocial, listaPrecio, diasCredito, email, celular, rfc, domicilio, colonia, codigoPostal);
                            Intent modify_intent = new Intent(context, ClienteActivity.class);
                            startActivity(modify_intent);
                        } else {
                            //Context context = getApplicationContext();
                            String text = "No es posible modificar al cliente, debido a que ha sido creado en web";
                            MetodosEstaticos.AlertDialogSimple(context, text, "Aviso");
                        }
                    } else {
                        //Los campos están vacios o no tienen el tipo de valor requerido
                        //Context context = getApplicationContext();
                        String text = "¡Aviso! datos inválidos, favor de verificarlos";
                        MetodosEstaticos.AlertDialogSimple(context, text, "Aviso");
                    }
                } else if (idCliente == "" || idCliente == null) {
                    if (razonSocial != "" && razonSocial != null &&
                            listaPrecio != "" && listaPrecio != null &&
                            diasCredito != "" && diasCredito != null &&
                            rfc != "" && rfc != null &&
                            exitoListaPrecio == true && exitoDiasCredito == true) {
                        //Si la clave viene vacía, es porque se intenta registrar un nuevo cliente
                        mPresentador.agregarCliente(etclaveRcv, razonSocial, listaPrecio, diasCredito, email, celular, rfc, domicilio, colonia, codigoPostal);
                        Intent modify_intent = new Intent(context, ClienteActivity.class);
                        startActivity(modify_intent);
                    } else {
                        //Context context = getApplicationContext();
                        String text = "¡Aviso! datos inválidos, favor de verificarlos";
                        MetodosEstaticos.AlertDialogSimple(context, text, "Aviso");
                    }
                }
            }
        }catch (Exception ex){
            error(ex.getMessage());
        }
    }

    @Override
    public void error(String mensaje) {
        MetodosEstaticos.AlertDialogSimple(this,mensaje);
    }

    @Override
    public void cargarSpinnerListaPrecios(ArrayAdapter adapter) {
        sListaPrecio.setAdapter(adapter);
    }

    @Override
    public void salir() {
        finish();
    }
}
