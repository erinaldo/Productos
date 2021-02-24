package com.duxstar.dacza.vistas;

import android.app.Activity;
import android.app.AlertDialog;
import android.content.ComponentName;
import android.content.Intent;
import android.os.Bundle;
import android.util.DisplayMetrics;
import android.util.Log;
import android.view.Display;
import android.view.LayoutInflater;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;
import android.widget.DatePicker;
import android.widget.EditText;
import android.widget.LinearLayout;
import android.widget.TextView;


import com.duxstar.dacza.R;
import com.duxstar.dacza.datos.utilerias.Sesion;
import com.duxstar.dacza.presentadores.Enumeradores;
import com.duxstar.dacza.presentadores.Enumeradores.RespuestaMsg;
import com.duxstar.dacza.presentadores.act.AccederSistema;
import com.duxstar.dacza.presentadores.interfaces.IAccesoSistema;
//import com.duxstar.dacza.presentadores.interfaces.IServidorComunicaciones;
import com.duxstar.dacza.utilerias.Constants;

import java.text.DateFormat;
import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.Date;
import java.util.HashMap;


public class AccesoSistema extends Vista implements IAccesoSistema
{
	AccederSistema mPresenta;
    //AlertDialog dialogoSustituto;
    //AlertDialog dialogoModificaContrasena;
    //String UsuarioDialogoSustituto;
    //String ContrasenaDialogoSustituto;
    //String UsuarioDialogoModContra;
    //String ContrasenaDialogoModContra;
    String VieneDe="";

	@Override
	public void onCreate(Bundle savedInstanceState)
	{
		super.onCreate(savedInstanceState);
		setContentView(R.layout.acceso_sistema);
		deshabilitarBarra(true);
		AutoSizeInit();

		mPresenta = new AccederSistema(this);
		mPresenta.iniciar();
	}
	
	@Override
	protected void onStart()
	{
		super.onStart();
		//mPresenta.cargaSustituto();
	}

	public void iniciar()
	{

	}

	public AccesoSistema getThisActivity()
	{
		return this;
	}

	@SuppressWarnings("deprecation")
	public void AutoSizeInit()
	{
		try
		{
			// display usage
			Display display = getWindowManager().getDefaultDisplay();
			DisplayMetrics metrics = getApplicationContext().getResources().getDisplayMetrics();

            /*TextView lblFecha = (TextView) findViewById(R.id.lblFecha);
            lblFecha.setText("Almacén");
            lblFecha.setWidth(display.getWidth() / Constants._LABELS_WIDTH);
            lblFecha.setHeight(display.getHeight() / Constants._LABELS_HEIGHT);
            lblFecha.setTextSize((lblFecha.getTextSize() / getMetrics().density) + 5);*/

            TextView lblAlmacen = (TextView) findViewById(R.id.lblAlmacen);
            lblAlmacen.setText("Almacén");
            lblAlmacen.setWidth(display.getWidth() / Constants._LABELS_WIDTH);
            lblAlmacen.setHeight(display.getHeight() / Constants._LABELS_HEIGHT);
            lblAlmacen.setTextSize((lblAlmacen.getTextSize() / getMetrics().density) + 5);

			TextView lblAgente = (TextView) findViewById(R.id.lblAgente);
            lblAgente.setText("Agente");
            lblAgente.setWidth(display.getWidth() / Constants._LABELS_WIDTH);
            lblAgente.setHeight(display.getHeight() / Constants._LABELS_HEIGHT);
            lblAgente.setTextSize((lblAgente.getTextSize() / getMetrics().density) + 5);

            TextView lblPassword = (TextView) findViewById(R.id.lblPassword);
            lblPassword.setText("Contraseña");
            lblPassword.setWidth(display.getWidth() / Constants._LABELS_WIDTH);
            lblPassword.setHeight(display.getHeight() / Constants._LABELS_HEIGHT);
            lblPassword.setTextSize((lblPassword.getTextSize() / getMetrics().density) + 5);

			EditText txtAlmacen = (EditText) findViewById(R.id.txtAlmacen);
            txtAlmacen.setWidth(display.getWidth() / 2);
            txtAlmacen.setHeight(display.getHeight() / 30);
            txtAlmacen.setTextSize((txtAlmacen.getTextSize() / getMetrics().density) + 3);

			EditText txtAgente = (EditText) findViewById(R.id.txtAgente);
            txtAgente.setWidth(display.getWidth() / 2);
            txtAgente.setHeight(display.getHeight() / 30);
            txtAgente.setTextSize((txtAgente.getTextSize() / getMetrics().density) + 3);

            EditText txtPass = (EditText) findViewById(R.id.txtPassword);
            txtPass.setWidth(display.getWidth() / 2);
            txtPass.setHeight(display.getHeight() / 30);
            txtPass.setTextSize((txtPass.getTextSize() / getMetrics().density) + 3);

			Button btnAceptar = (Button) findViewById(R.id.btnAceptar);
			btnAceptar.setWidth(display.getWidth() / 3);
			btnAceptar.setHeight(display.getHeight() / 14);
			btnAceptar.setText("Ingresar");
			btnAceptar.setTextSize((btnAceptar.getTextSize() / metrics.density) + 3);
			btnAceptar.setOnClickListener(mAcceder);
		}
		catch (Exception ex)
		{
			Log.i("Exception On Init", ex.getMessage());
		}
	}

	@Override
	public void resultadoActividad(int requestCode, int resultCode, Intent data)
	{
		if ((requestCode == Enumeradores.Solicitudes.SOLICITUD_CONFIGURACION) && (resultCode == Enumeradores.Resultados.RESULTADO_BIEN))
		{
			return;
		}
		else if(requestCode == Enumeradores.Solicitudes.SOLICITUD_SERVIDOR_COMUNICACIONES){
            if (resultCode == Enumeradores.Resultados.RESULTADO_BIEN) {
                if (VieneDe.equals("OpcionRecibir")) {
                    mPresenta.cargarDatos();
                    VieneDe = "";
                }
                if (VieneDe.equals("OpcionCambioTaller")) {
                    mPresenta.cargarDatos();
                    VieneDe = "";
                    mPresenta.acceder();
                }
            }else if (resultCode == Enumeradores.Resultados.RESULTADO_MAL){
                String mensajeError = (String) data.getExtras().getString("mensajeIniciar");
                mostrarAdvertencia(mensajeError);
            }
        }
	}

    /*public void setFecha(Date fecha)
    {
        DatePicker dpFecha = (DatePicker) findViewById(R.id.dpFecha);
        DateFormat dateFormat = new SimpleDateFormat("yyyy/MM/dd");
        String[] sFecha =  dateFormat.format(fecha).split("/");

        dpFecha.updateDate(Integer.parseInt(sFecha[0]), Integer.parseInt(sFecha[1]), Integer.parseInt(sFecha[2]));
    }*/

	public void setAlmacen(String valor)
	{
		EditText texto = (EditText) findViewById(R.id.txtAlmacen);
		texto.setText(valor);
	}

	public void setAgente(String valor)
	{
		EditText texto = (EditText) findViewById(R.id.txtAgente);
		texto.setText(valor);
	}

    public void setPassword(String valor)
    {
        EditText texto = (EditText) findViewById(R.id.txtPassword);
        texto.setText(valor);
    }

    /*public Date getFecha()
    {
        DatePicker dpFecha = (DatePicker) findViewById(R.id.dpFecha);
        Calendar oCal = Calendar.getInstance();
        oCal.set(dpFecha.getYear() - 1900, dpFecha.getMonth(), dpFecha.getDayOfMonth());
        return oCal.getTime();
    }*/

	public String getAlmacen()
	{
		EditText texto = (EditText) findViewById(R.id.txtAlmacen);
		return texto.getText().toString().trim();
	}

	public String getAgente()
	{
		EditText texto = (EditText) findViewById(R.id.txtAgente);
		return texto.getText().toString().trim();
	}

    public String getPassword()
    {
        EditText texto = (EditText) findViewById(R.id.txtPassword);
        return texto.getText().toString().trim();
    }

	@Override
	public boolean onCreateOptionsMenu(Menu menu)
	{
        try{
            menu.add(0, Enumeradores.ACTMENU.CONFIGURACION, Enumeradores.ACTMENU.CONFIGURACION, "Configuración");
            menu.add(0, Enumeradores.ACTMENU.RECIBIR, Enumeradores.ACTMENU.RECIBIR, "Actualizar Datos");
            menu.add(0, Enumeradores.ACTMENU.SALIR, Enumeradores.ACTMENU.SALIR, "Salir");
        }
        catch (Exception e){
            mostrarError(e.getMessage());
        }

        return true;
	}

	@Override
	public boolean onOptionsItemSelected(MenuItem item)
	{
		switch (item.getItemId())
		{
            case Enumeradores.ACTMENU.SALIR:
				mPresenta.intentarSalir();
				return true;
            case Enumeradores.ACTMENU.RECIBIR:
                VieneDe = "OpcionRecibir";
                if (!mPresenta.existenDatosSinEnviar(VieneDe))
                    mPresenta.confirmarActualizarDatos();
                return true;
            case Enumeradores.ACTMENU.CONFIGURACION:
				mPresenta.configuracion();
				return true;
			default:
				return super.onOptionsItemSelected(item);
		}
	}

	private OnClickListener mAcceder = new OnClickListener()
	{
		public void onClick(View v)
		{
			if (validarInformacion(null, null, null))
			{
                //VieneDe="BotonIngresar";
                mPresenta.acceder();
			}
		}
	};

	private boolean validarInformacion(String almacen, String usuario, String password)
	{
		TextView label = null;
		EditText textbox = null;

        if(almacen == null)
        {
            textbox = (EditText) findViewById(R.id.txtAlmacen);
            almacen = textbox.getText().toString().trim();
        }
        if (almacen.length() == 0)
        {
            label = (TextView) findViewById(R.id.lblAlmacen);
            if(textbox != null)textbox.requestFocus();
            mostrarAdvertencia("El campo " + label.getText().toString() + " es requerido. ");
            return false;
        }
		if(usuario == null)
		{
			textbox = (EditText) findViewById(R.id.txtAgente);
			usuario = textbox.getText().toString().trim();
		}
		if (usuario.length() == 0)
		{
			label = (TextView) findViewById(R.id.lblAgente);
			if(textbox != null)textbox.requestFocus();
			    mostrarAdvertencia("El campo " + label.getText().toString() + " es requerido. ");
			return false;
		}
		if(password == null){
			textbox = (EditText) findViewById(R.id.txtPassword);
			password = textbox.getText().toString().trim();
		}
        if (password.length() == 0)
        {
            label = (TextView) findViewById(R.id.lblPassword);
            if(textbox != null)textbox.requestFocus();
                mostrarAdvertencia("El campo " + label.getText().toString() + " es requerido. ");
            return false;
        }
		return true;
	}

	@Override
	public void respuestaMensaje(RespuestaMsg respuesta, int tipoMensaje)
	{
		if ((tipoMensaje == 0) && (respuesta == RespuestaMsg.Si))
            mPresenta.cambiarUsuario(true);
		if ((tipoMensaje == 1) && (respuesta == RespuestaMsg.Si))
            mPresenta.salir();
        if ((tipoMensaje == 2) && (respuesta == RespuestaMsg.Si))
            mPresenta.actualizarDatos();
        if ((tipoMensaje == 3) && (respuesta == RespuestaMsg.Si)) {
            VieneDe = "OpcionCambioTaller";
            //if (!mPresenta.existenDatosSinEnviar(VieneDe)) {
            mPresenta.cambiarUsuario(false);
            mPresenta.confirmarActualizarDatos();
            //}
        }
	}

	public void iniciarSelector()
	{
		Intent selector = new Intent("android.intent.action.MAIN");
		selector.addCategory("android.intent.category.HOME");
		selector.setComponent(new ComponentName("android", "com.android.internal.app.ResolverActivity"));
		startActivity(selector);
	}

	public Activity getActivity()
	{
		return this;
	}

}
