package com.elephantworks.movilvennda.Vistas;

import android.content.Context;
import android.content.Intent;
import android.net.ConnectivityManager;
import android.net.NetworkInfo;
import android.os.Bundle;
import android.os.StrictMode;
import android.support.v7.app.AppCompatActivity;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Spinner;
import android.widget.TextView;

import com.elephantworks.movilvennda.Interfaces.IPuntoVenta;
import com.elephantworks.movilvennda.Modelos.AperturaCierre;
import com.elephantworks.movilvennda.R;
import com.elephantworks.movilvennda.Presentadora.PresentadorMainActivity;
import com.elephantworks.movilvennda.Presentadora.PresentadorPuntoVenta;
import com.elephantworks.movilvennda.Utilerias.MetodosEstaticos;

/**
 * Created by Elephant on 04/06/17.
 */

public class PuntoVentaActivity extends AppCompatActivity implements IPuntoVenta, View.OnClickListener {

    private PresentadorPuntoVenta mPresenator;
    private Context context = PuntoVentaActivity.this;
    TextView lblEmpresa;
    TextView lblBienvenida;
    Spinner sPuntoVenta;
    Button btnRegresa;
    Button btnIngresar;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_punto_venta);

        mPresenator = new PresentadorPuntoVenta(this,context);
        inicializar();
        mPresenator.llenarTitulos();
        mPresenator.llenarSpinner();

        btnIngresar.setOnClickListener(this);
        btnRegresa.setOnClickListener(this);


    }

    public void inicializar(){
        lblEmpresa = (TextView) findViewById(R.id.lblEmpresa);
        lblBienvenida = (TextView) findViewById(R.id.lblBienvenida);
        sPuntoVenta = (Spinner) findViewById(R.id.sPuntoVenta);
        btnRegresa = (Button) findViewById(R.id.btnRegresar);
        btnIngresar = (Button) findViewById(R.id.btnIngresar);
    }

    @Override
    public void mostrarTitulos(String empresa, String bienvenida) {
        lblEmpresa.setText(empresa);
        lblBienvenida.setText(bienvenida);
    }

    @Override
    public void cargarSpinnerPuntoVenta(ArrayAdapter adaptador) {
        sPuntoVenta.setAdapter(adaptador);
    }

    @Override
    public void ingresarMenu() {
        if(mPresenator.validarAperturaCaja()){
            Intent i = new Intent(PuntoVentaActivity.this, MenuActivity.class);
            startActivity(i);
        }else{
            Intent i = new Intent(PuntoVentaActivity.this, AperturaCierreActivity.class);
            i.putExtra("apertura", true);
            i.putExtra("vieneDePuntoVenta", true);
            startActivity(i);
        }

        //finish();
    }

    @Override
    public void error(String mensaje) {
        MetodosEstaticos.AlertDialogSimple(this,mensaje);
    }

    @Override
    public void onClick(View view) {

        if (view.getId() == findViewById(R.id.btnIngresar).getId()) {

            int id = ((int) sPuntoVenta.getSelectedItemId());
            if(id <= 0){
                MetodosEstaticos.AlertDialogSimple(this, this.getString(R.string.errorPuntoVenta));
            }else {
                mPresenator.ingresar(id);
            }

        }

        if (view.getId() == findViewById(R.id.btnRegresar).getId()) {
            finish();
        }
    }
}
