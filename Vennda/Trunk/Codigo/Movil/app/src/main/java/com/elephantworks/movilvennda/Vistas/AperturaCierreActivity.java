package com.elephantworks.movilvennda.Vistas;

import android.app.AlertDialog;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.database.Cursor;
import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.view.ContextMenu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ImageButton;
import android.widget.ListView;
import android.widget.Spinner;
import android.widget.TextView;

import com.elephantworks.movilvennda.Adaptadores.DineroAdapter;
import com.elephantworks.movilvennda.Interfaces.IAperturaCierre;
import com.elephantworks.movilvennda.Presentadora.PresentadorAperturaCierre;
import com.elephantworks.movilvennda.R;
import com.elephantworks.movilvennda.Utilerias.MetodosEstaticos;

/**
 * Created by ldelatorre on 17/06/2017.
 */
public class AperturaCierreActivity extends AppCompatActivity implements IAperturaCierre, View.OnClickListener {

    private PresentadorAperturaCierre mPresentador;
    private Context context = AperturaCierreActivity.this;
    public TextView txtTitulo;
    public Spinner sDenominacion;
    public EditText etCantidad;
    public EditText etTotal;
    public ImageButton btnMas;
    public ImageButton btnMenos;
    public Button btnAceptar;
    public Button btnAgregar;
    public ListView lvDinero;
    public PresentadorAperturaCierre.Dinero lDinero;
    public boolean apertura; //variable para saber si es apertura o cierre
    public boolean vieneDePuntoVenta;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_apertura_cierre);

        mPresentador = new PresentadorAperturaCierre(this,context);
        this.inicializar();
    }

    public void inicializar(){
        txtTitulo = (TextView) findViewById(R.id.txtTitulo);
        sDenominacion = (Spinner) findViewById(R.id.sDenominacion);
        etCantidad = (EditText) findViewById(R.id.etCantidad);
        etTotal = (EditText) findViewById(R.id.etTotal);
        btnMas = (ImageButton) findViewById(R.id.btnMas);
        btnMenos = (ImageButton) findViewById(R.id.btnMenos);
        btnAceptar = (Button) findViewById(R.id.btnAceptar);
        btnAgregar = (Button) findViewById(R.id.btnAgregar);
        lvDinero = (ListView) findViewById(R.id.lvDinero);
        registerForContextMenu(lvDinero);
        mPresentador.llenarSpinnerDeniminacion();

        btnAceptar.setOnClickListener(this);
        btnAgregar.setOnClickListener(this);
        btnMas.setOnClickListener(this);
        btnMenos.setOnClickListener(this);

        apertura = getIntent().getExtras().getBoolean("apertura");
        vieneDePuntoVenta = getIntent().getExtras().getBoolean("vieneDePuntoVenta");

        if(apertura){
            if(mPresentador.existeApertura()){
                AlertDialog alertDialog = new AlertDialog.Builder(context).create();
                alertDialog.setTitle("Error");
                alertDialog.setMessage(this.getString(R.string.msjExisteApertura));
                alertDialog.setButton(AlertDialog.BUTTON_NEUTRAL, "OK", new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialog, int i) {
                        dialog.dismiss();
                        finish();
                    }
                });

                alertDialog.show();

            }
            txtTitulo.setText(this.getString(R.string.txtTitulo).replace("$0$", this.getString(R.string.txtApertura)));
        }else{

            txtTitulo.setText(this.getString(R.string.txtTitulo).replace("$0$", this.getString(R.string.txtCierre)));
        }


    }

    @Override
    public void onClick(View view) {
        if (view.getId() == findViewById(R.id.btnMas).getId()) {
            String cantidad = etCantidad.getText().toString();
            int cant = Integer.parseInt(cantidad);
            int total = cant + 1;
            etCantidad.setText(String.valueOf(total));
        }

        if (view.getId() == findViewById(R.id.btnMenos).getId()) {
            String cantidad = etCantidad.getText().toString();
            int cant = Integer.parseInt(cantidad);
            if(cant > 0){
                int total = cant - 1;
                etCantidad.setText(String.valueOf(total));
            }
        }

        if (view.getId() == findViewById(R.id.btnAgregar).getId()) {
            int denominacion = ((int)sDenominacion.getSelectedItemId());
            if(denominacion != 0){
                String cantidad = etCantidad.getText().toString();
                int cant = Integer.parseInt(cantidad);
                if(cant != 0){
                    double importe = mPresentador.obtenerValorDenominacion(denominacion) * cant;
                    mPresentador.agregarDenominacion(denominacion,cantidad,String.valueOf(importe));
                }else{
                    MetodosEstaticos.AlertDialogSimple(this,this.getString(R.string.msjCantidadRequerida));
                }

            }else {
                MetodosEstaticos.AlertDialogSimple(this,this.getString(R.string.msjDominacionRequerida));
            }

        }

        if (view.getId() == findViewById(R.id.btnAceptar).getId()) {
            if(lvDinero.getCount() > 0){
                String total = etTotal.getText().toString();
                mPresentador.guardarAperturaCierre(apertura,Double.parseDouble(total));

                if(vieneDePuntoVenta){
                    Intent i = new Intent(AperturaCierreActivity.this, MenuActivity.class);
                    startActivity(i);
                    this.finish();
                }

            }else {
                MetodosEstaticos.AlertDialogSimple(this,this.getString(R.string.msjListaVacia));
            }
        }
    }

    @Override
    public void cargarSpinnerDenominacion(ArrayAdapter adaptador) {
        sDenominacion.setAdapter(adaptador);
    }

    @Override
    public void cargarLista(DineroAdapter dineroAdapter) {
        lvDinero.setAdapter(dineroAdapter);
        mPresentador.mostrarTotal();
    }

    @Override
    public void cargarTotal(String total) {
        etTotal.setText(total);
    }

    @Override
    public void error(String mensaje) {
        MetodosEstaticos.AlertDialogSimple(this,mensaje);
    }

    @Override
    public void salir(String mensaje) {
        Intent i = new Intent(AperturaCierreActivity.this, MainActivity.class);
        i.putExtra("mensaje", mensaje);
        startActivity(i);
        finish();
    }

    @Override
    public void onCreateContextMenu(ContextMenu menu, View v, ContextMenu.ContextMenuInfo menuInfo) {
        super.onCreateContextMenu(menu, v, menuInfo);


        if(v.getId() == R.id.lvDinero){
            MenuInflater inflater = getMenuInflater();
            inflater.inflate(R.menu.menu_apertura_dinero, menu);
            /*Cambiar el nombre por codigo
            menu.getItem(0).setTitle(Mensajes.get("XModificar"));
            menu.getItem(1).setTitle(Mensajes.get("XEliminar"));*/
        }
    }

    @Override
    public boolean onContextItemSelected(MenuItem item) {
        AdapterView.AdapterContextMenuInfo info = null;

        if (item.getMenuInfo() != null) {
            info = (AdapterView.AdapterContextMenuInfo) item.getMenuInfo();
            lDinero = (PresentadorAperturaCierre.Dinero)  lvDinero.getItemAtPosition((int) info.position);
        }

        switch (item.getItemId()) {
            case R.id.eliminarDinero:
                mPresentador.eliminarDinero(lDinero.getDenominacion());

                return true;

        }

        return false;
    }
}
