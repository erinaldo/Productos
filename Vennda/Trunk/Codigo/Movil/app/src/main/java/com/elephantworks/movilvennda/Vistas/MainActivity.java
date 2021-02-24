package com.elephantworks.movilvennda.Vistas;

import android.app.AlertDialog;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;

import com.elephantworks.movilvennda.Interfaces.IMainActivity;
import com.elephantworks.movilvennda.R;
import com.elephantworks.movilvennda.Presentadora.PresentadorMainActivity;
import com.elephantworks.movilvennda.Utilerias.MetodosEstaticos;

public class MainActivity extends AppCompatActivity implements IMainActivity, View.OnClickListener{

    PresentadorMainActivity mPresenta;
    EditText etUsuario;
    EditText etContrasena;
    Button btnIngresar;
    Context context = MainActivity.this;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        mPresenta = new PresentadorMainActivity(this,context);
        etUsuario = (EditText) findViewById(R.id.txtUsuario);
        etContrasena = (EditText) findViewById(R.id.txtContrasena);
        btnIngresar = (Button) findViewById(R.id.btnIngresar);

        btnIngresar.setOnClickListener(this);

        String mensaje = getIntent().getExtras().getString("mensaje");
        if(mensaje != null && !mensaje.equals("")){
            MetodosEstaticos.AlertDialogSimple(context, mensaje, "Exito");
        }
    }

    @Override
    public void usuarioCorrecto() {
        Intent i = new Intent(MainActivity.this, PuntoVentaActivity.class);
        startActivity(i);
        finish();
    }

    @Override
    public void usuarioIncorrecto() {

        AlertDialog alertDialog = new AlertDialog.Builder(this).create();
        alertDialog.setTitle("Usuario incorrecto");
        alertDialog.setMessage("El usuario es incorrecto, por favor verifique sus datos.");
        alertDialog.setButton(AlertDialog.BUTTON_NEUTRAL, "OK", new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int i) {
                dialog.dismiss();
            }
        });

        alertDialog.show();
    }

    @Override
    public void error(String mensaje) {

        AlertDialog alertDialog = new AlertDialog.Builder(this).create();
        alertDialog.setTitle("Error");
        alertDialog.setMessage(mensaje);
        alertDialog.setButton(AlertDialog.BUTTON_NEUTRAL, "OK", new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int i) {
                dialog.dismiss();
            }
        });

        alertDialog.show();
    }

    @Override
    public void onClick(View view) {
        if (view.getId() == findViewById(R.id.btnIngresar).getId()) {
            String usu = etUsuario.getText().toString().trim();
            String con = etContrasena.getText().toString();
            mPresenta.validarUsuario(usu,con);
        }
    }
}
