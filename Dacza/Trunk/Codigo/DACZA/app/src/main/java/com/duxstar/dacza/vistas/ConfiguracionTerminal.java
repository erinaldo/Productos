package com.duxstar.dacza.vistas;

import java.io.File;
import java.io.IOException;
import java.lang.reflect.InvocationTargetException;
import java.lang.reflect.Method;
import java.text.DateFormat;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.Date;
import java.util.Map;
import java.util.UUID;

import android.app.AlertDialog;
import android.bluetooth.BluetoothAdapter;
import android.bluetooth.BluetoothDevice;
import android.bluetooth.BluetoothSocket;
import android.content.BroadcastReceiver;
import android.content.ComponentName;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.content.IntentFilter;
import android.os.Bundle;
import android.os.Handler;
import android.text.Editable;
import android.text.TextWatcher;
import android.view.KeyEvent;
import android.view.LayoutInflater;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;
import android.widget.CheckBox;
import android.widget.DatePicker;
import android.widget.EditText;
import android.widget.LinearLayout;
import android.widget.TextView;

import com.duxstar.dacza.R;
//import com.amesol.routelite.actividades.Mensajes;
//import com.amesol.routelite.actividades.ValorReferencia;
//import com.amesol.routelite.actividades.ValoresReferencia;
//import com.amesol.routelite.datos.AseguramientoVisita;
//import com.amesol.routelite.datos.Usuario;
//import com.amesol.routelite.datos.Vendedor;
//import com.amesol.routelite.datos.basedatos.BDVend;
//import com.amesol.routelite.datos.basedatos.Consultas;
import com.duxstar.dacza.datos.utilerias.ArchivoConfiguracion.CampoConfiguracion;
import com.duxstar.dacza.datos.utilerias.ConfiguracionLocal;
import com.duxstar.dacza.datos.utilerias.Sesion;
import com.duxstar.dacza.datos.utilerias.Sesion.Campo;
import com.duxstar.dacza.presentadores.Enumeradores;
import com.duxstar.dacza.presentadores.Enumeradores.RespuestaMsg;
import com.duxstar.dacza.presentadores.act.ConfigurarTerminal;
import com.duxstar.dacza.presentadores.interfaces.IConfiguracionTerminal;
import com.duxstar.dacza.vistas.generico.DialogoProgreso;
import com.duxstar.dacza.vistas.utilerias.Dispositivo;
import com.duxstar.dacza.vistas.utilerias.ServicesCentral;
//import com.duxstar.dacza.vistas.utilerias.ServicesCentral;

public class ConfiguracionTerminal extends Vista implements IConfiguracionTerminal
{

	private static final int REQUEST_BT_SETTINGS = 777;
	private ConfigurarTerminal mPresenta;
	//private BluetoothAdapter mBluetoothAdapter;
	//private ArrayList<BluetoothDevice> mListaDispositivos = new ArrayList<BluetoothDevice>();

	private boolean recibidor = false;
	//private boolean buscandoDispositivos = false;
	//private AseguramientoVisita aseguramiento = null;
	private Handler handler;

	private boolean huboCambios;
	private String address,clave;

	/* Patron para validar la IP */
	private final String IP_PATTERN = "^([01]?\\d\\d?|2[0-4]\\d|25[0-5])\\." +
	        "([01]?\\d\\d?|2[0-4]\\d|25[0-5])\\." +
	        "([01]?\\d\\d?|2[0-4]\\d|25[0-5])\\." +
	        "([01]?\\d\\d?|2[0-4]\\d|25[0-5])$";
	
	
	@Override
	public void onCreate(Bundle savedInstanceState)
	{
		super.onCreate(savedInstanceState);

		setContentView(R.layout.configuracion_terminal);

		String accion = getIntent().getAction();

		setTitulo("Configuración");

		TextView texto = (TextView) findViewById(R.id.lblServicio);
		texto.setText("Servicio");

		texto = (TextView) findViewById(R.id.lblAlmacen);
		texto.setText("Almacen");

        /*texto = (TextView) findViewById(R.id.lblFecha);
        texto.setText("Fecha de Inicio de Jornada");*/

		texto = (TextView) findViewById(R.id.lblAgente);
		texto.setText("Agente");

        texto = (TextView) findViewById(R.id.lblPassword);
        texto.setText("Contraseña");

		texto = (TextView) findViewById(R.id.lblDirectorio);
		texto.setText("Directorio de Almacenamiento");

		texto = (TextView) findViewById(R.id.lblTimeOut);
		texto.setText("Timeout (minutos)");

		CheckBox check = (CheckBox) findViewById(R.id.chkWireless);
		check.setText("Administrar WiFi");
		
		check = (CheckBox) findViewById(R.id.chkEnvioIndividual);
		check.setText("Enviar Orden de Trabajo individual");

		Button boton = (Button) findViewById(R.id.btnGuardar);
		boton.setOnClickListener(mEventoGuardar);
		// boton.setWidth(getDisplayWidth()/3);
		// boton.setHeight(getDisplayHeight()/12);
		// boton.setTextSize((boton.getTextSize() / getMetrics().density) - 6);

		mPresenta = new ConfigurarTerminal(this, accion);

		mPresenta.iniciar();

		// agregar el listener a los campos para saber cuando hubo cambios
		EditText campo = (EditText) findViewById(R.id.txtServicio);
		campo.addTextChangedListener(mHuboCambios);
		campo = (EditText) findViewById(R.id.txtAlmacen);
		campo.addTextChangedListener(mHuboCambios);
		campo = (EditText) findViewById(R.id.txtAgente);
		campo.addTextChangedListener(mHuboCambios);
		huboCambios = false;
	}

	@Override
	protected void onActivityResult(int requestCode, int resultCode, Intent data)
	{
		super.onActivityResult(requestCode, resultCode, data);
	}

	private TextWatcher mHuboCambios = new TextWatcher()
	{

		@Override
		public void onTextChanged(CharSequence s, int start, int before, int count)
		{
			huboCambios = true;
		}

		@Override
		public void beforeTextChanged(CharSequence s, int start, int count, int after)
		{
		}

		@Override
		public void afterTextChanged(Editable s)
		{
		}
	};



	@Override
	public void onDestroy()
	{
//		if (mBluetoothAdapter != null)
//		{
//			if (mBluetoothAdapter.isDiscovering())
//				mBluetoothAdapter.cancelDiscovery();
//			if (mBluetoothAdapter.isEnabled())
//				mBluetoothAdapter.disable();
//			if (recibidor && mReceiver != null)
//				unregisterReceiver(mReceiver);
//		}
		super.onDestroy();
	}

	@Override
	public boolean onKeyDown(int keyCode, KeyEvent event)
	{
		switch (keyCode)
		{
			case KeyEvent.KEYCODE_BACK:
				mPresenta.anterior();
				return true;
		}
		return super.onKeyDown(keyCode, event);
	}

	public void iniciar()
	{

	}

	private OnClickListener mEventoGuardar = new OnClickListener()
	{

		public void onClick(View arg0)
		{
			if (huboCambios)
				validarAsync();
			else
				mPresenta.continuar();
		}
	};

	private void validarAsync()
	{
		// final ProgressDialog dialog = ProgressDialog.show(this, "",
		// "Conectando ...", true);
        try {

            final DialogoProgreso dialog = new DialogoProgreso(this);
            dialog.setProgressStyle(DialogoProgreso.STYLE_SPINNER);
            dialog.setMessage("Conectando al servicio ...");
            dialog.setCancelable(false);
            dialog.show();

            handler = new Handler();
            Runnable accion = new Runnable() {
                public void run() {
                    if (validarDatosConfiguracion() && validarUsuario())
                        mPresenta.continuar();
                }
            };

            final Thread valida = new Thread(accion);

            Runnable mensaje = new Runnable() {
                public void run() {
                    while (valida.isAlive()) {
                    }
                    dialog.dismiss();
                }
            };
            new Thread(mensaje).start();
            valida.start();
        }catch (Exception e){
            e.printStackTrace();
        }
	}

	private boolean validarUsuario()
	{
		try {
            CheckBox wireless = (CheckBox) findViewById(R.id.chkWireless);
            if (wireless.isChecked())
                Dispositivo.EncenderApagarWiFi((Context) this, true, 4);

            if (!ServicesCentral.ProbarAccesoServicio(getServicio())) {
                handler.post(new Runnable() {
                    @Override
                    public void run() {
                        mostrarError("No se puede establecer conexión de Área Local. Avisar a Soporte Técnico");
                    }
                });

                return false;
            }
			else
            {
                String almacen = getAlmacen();
                String agente = getAgente();
                String password = getPassword();
                String url = getServicio();
                String terminal = Dispositivo.obtenerNumeroSerie(this);
                Object params[] = new Object[]
                        {almacen, agente, password, terminal, "", url, getTimeOut()};
                ServicesCentral.WSObtenerUsuarioContrasena(params);
                final String mensaje = params[4].toString();
                if (mensaje.equals("Usuario y Contraseña valida")) {
                    return true;
                } else {
                    handler.post(new Runnable() { // el hilo principal ejecuta este codigo
                        public void run() {
                            mostrarAdvertencia(mensaje);
                        }
                    });
                    return false;
                }
            }
		}
		catch (Exception e)
		{
            final String mensaje = e.getMessage();
            handler.post(new Runnable() { // el hilo principal ejecuta este codigo
                public void run() {
                    mostrarError(mensaje);
                }
            });

			return false;
		}
	}

	@Override
	public boolean onCreateOptionsMenu(Menu menu)
	{

		String accion = getIntent().getAction();
		MenuInflater inflater = getMenuInflater();
		inflater.inflate(R.menu.menu_configuracion_terminal, menu);
		if ((accion != null) && (accion.equals(Enumeradores.Acciones.ACCION_CONFIGURAR)))
			menu.getItem(0).setVisible(false);
        else
		    menu.getItem(0).setTitle("Salir");
		menu.getItem(1).setTitle("De fabrica");
		return true;
	}

	@Override
	public boolean onOptionsItemSelected(MenuItem item)
	{

		switch (item.getItemId())
		{
			case R.id.salir:
                mPresenta.intentarSalir();
                return true;
			case R.id.defabrica:
				mPresenta.deFabrica();
			default:
				return super.onOptionsItemSelected(item);
		}
	}

	public void setServicio(String valor)
	{
		EditText texto = (EditText) findViewById(R.id.txtServicio);
		texto.setText(valor);
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

	public void setDirectorio(String valor)
	{
		EditText texto = (EditText) findViewById(R.id.txtDirectorio);
		texto.setText(valor);
	}

	public void setTimeOut(int valor)
	{
		EditText texto = (EditText) findViewById(R.id.txtTimeOut);
		texto.setText(String.valueOf(valor / 60000));
	}

	public int getTimeOut()
	{
		EditText texto = (EditText) findViewById(R.id.txtTimeOut);
		return Integer.parseInt(texto.getText().toString()) * 60000;
	}

	public String getServicio()
	{
		EditText texto = (EditText) findViewById(R.id.txtServicio);
		return texto.getText().toString();
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
		return texto.getText().toString();
	}

	public String getAgente()
	{
		EditText texto = (EditText) findViewById(R.id.txtAgente);
		return texto.getText().toString();
	}

    public String getPassword()
    {
        EditText texto = (EditText) findViewById(R.id.txtPassword);
        return texto.getText().toString();
    }

	public String getDirectorio()
	{
		EditText texto = (EditText) findViewById(R.id.txtDirectorio);
		return texto.getText().toString();
	}

	private boolean validarDatosConfiguracion()
	{
		LinearLayout lista = (LinearLayout) findViewById(android.R.id.list);
		String nombreCampo = "";
		for (int i = 0; i < lista.getChildCount(); i++)
		{
			View elemento = lista.getChildAt(i);
			if (elemento.getClass().equals(TextView.class))
			{
				TextView etiqueta = (TextView) elemento;
				nombreCampo = etiqueta.getText().toString();
			}
			else if (elemento.getClass().equals(EditText.class))
			{
				final EditText texto = (EditText) elemento;
				final String campo = nombreCampo;
				if (texto.getText().length() == 0)
				{
					handler.post(new Runnable()
					{ // el hilo principal ejecuta este codigo
						public void run()
						{
							mostrarAdvertencia("El campo " + campo + " es requerido");
							texto.requestFocus();
						}
					});
					return false;
				}
			}
		}
		return true;
	}

	@Override
	public void resultadoActividad(int requestCode, int resultCode, Intent data)
	{
		if (requestCode == REQUEST_ENABLE_BT)
		{
			if (resultCode == RESULT_OK)
			{
//				buscarDispositivosBT();
			}
		}

	}

	@Override
	public void respuestaMensaje(RespuestaMsg respuesta, int tipoMensaje)
	{
        if ((tipoMensaje == 1) && (respuesta == RespuestaMsg.Si))
            mPresenta.salir();
	}

	public Boolean isWireless()
	{
		CheckBox check = (CheckBox) findViewById(R.id.chkWireless);
		return check.isChecked();
	}
	
	public Boolean isEnvioIndividual()
	{
		CheckBox check = (CheckBox) findViewById(R.id.chkEnvioIndividual);
		return check.isChecked();
	}

	public void setWireless(Boolean valor)
	{
		CheckBox check = (CheckBox) findViewById(R.id.chkWireless);
		check.setChecked(valor);
	}

	public void setEnvioIndividual(Boolean valor)
	{
		CheckBox check = (CheckBox) findViewById(R.id.chkEnvioIndividual);
		check.setChecked(valor);
	}
}
