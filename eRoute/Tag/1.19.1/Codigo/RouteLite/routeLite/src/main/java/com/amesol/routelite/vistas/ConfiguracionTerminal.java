package com.amesol.routelite.vistas;

import java.io.File;
import java.io.IOException;
import java.lang.reflect.InvocationTargetException;
import java.lang.reflect.Method;
import java.util.ArrayList;
import java.util.Map;
import java.util.Set;
import java.util.UUID;

import android.Manifest;
import android.annotation.TargetApi;
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
import android.content.pm.PackageManager;
import android.os.Build;
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
import android.widget.EditText;
import android.widget.LinearLayout;
import android.widget.TextView;

import com.amesol.routelite.R;
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.actividades.ValorReferencia;
import com.amesol.routelite.actividades.ValoresReferencia;
import com.amesol.routelite.datos.AseguramientoVisita;
import com.amesol.routelite.datos.Usuario;
import com.amesol.routelite.datos.Vendedor;
import com.amesol.routelite.datos.basedatos.BDVend;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.utilerias.ArchivoConfiguracion.CampoConfiguracion;
import com.amesol.routelite.datos.utilerias.ConfiguracionLocal;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.Enumeradores.RespuestaMsg;
import com.amesol.routelite.presentadores.act.ConfigurarTerminal;
import com.amesol.routelite.presentadores.interfaces.IConfiguracionTerminal;
import com.amesol.routelite.vistas.generico.DialogoProgreso;
import com.amesol.routelite.vistas.utilerias.Dispositivo;
import com.amesol.routelite.vistas.utilerias.ServicesCentral;

public class ConfiguracionTerminal extends Vista implements IConfiguracionTerminal
{

	private static final int REQUEST_BT_SETTINGS = 777;
	private ConfigurarTerminal mPresenta;
	private BluetoothAdapter mBluetoothAdapter;
	private ArrayList<BluetoothDevice> mListaDispositivos = new ArrayList<BluetoothDevice>();

	private boolean recibidor = false;
	//private boolean buscandoDispositivos = false;
	private AseguramientoVisita aseguramiento = null;
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

		setTitulo("Configuracion de Conexión");

		TextView texto = (TextView) findViewById(R.id.lblServicio);
		texto.setText("Servicio");

		texto = (TextView) findViewById(R.id.lblUsuario);
		texto.setText("Usuario");

		texto = (TextView) findViewById(R.id.lblPassword);
		texto.setText("Contraseña");

		texto = (TextView) findViewById(R.id.lblDirectorio);
		texto.setText("Directorio de Almacenamiento");

		texto = (TextView) findViewById(R.id.lblTimeOut);
		texto.setText("Timeout (minutos)");

		texto = (TextView) findViewById(R.id.lblContrasenaFija);
		texto.setText(Mensajes.get("XContraseniaAseguramiento"));
		EditText pass = (EditText) findViewById(R.id.txtContrasenaFija);
		pass.addTextChangedListener(mContraFija);
		CheckBox chk = (CheckBox) findViewById(R.id.ChkAseguramientoVisita);
		chk.setText(Mensajes.get("XAseguramientoVisita"));
		chk.setVisibility(View.GONE);
		texto.setVisibility(View.GONE);
		pass.setVisibility(View.GONE);

		/*
		 * if(accion != null){ if(existeBDVendedor()){
		 * if(aseguramiento.TipoContrasena == 1){
		 * texto.setVisibility(View.VISIBLE); pass.setVisibility(View.VISIBLE);
		 * } } }
		 */

		texto = (TextView) findViewById(R.id.lblImpresoras);
		if ((accion != null) && (accion == Enumeradores.Acciones.ACCION_CONFIGURAR_PUERTOS))
			texto.setText(Mensajes.get("XConfigurarImpresora"));
		else
			texto.setVisibility(View.GONE);

		CheckBox check = (CheckBox) findViewById(R.id.chkWireless);
		check.setText("Administrar WiFi");
		
		check = (CheckBox) findViewById(R.id.chkBluetooth);
		check.setText("Administrar Bluetooth");

        check = (CheckBox) findViewById(R.id.chkHabilitarLog);
        check.setText("Habilitar Log de Transacciones");

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
		campo = (EditText) findViewById(R.id.txtUsuario);
		campo.addTextChangedListener(mHuboCambios);
		campo = (EditText) findViewById(R.id.txtPassword);
		campo.addTextChangedListener(mHuboCambios);
		huboCambios = false;
	}

	public boolean obtenerAseguramientoVisita()
	{
		try
		{
			// Vendedor vendedor =
			// (Vendedor)Sesion.get(Sesion.Campo.VendedorActual);
			// aseguramiento =
			// Consultas.ConsultarAseguramientoVisita.obtenerAseguramientoPorVendedor(vendedor);
			return aseguramiento.EdoContraFija;
		}
		catch (Exception ex)
		{
			ex.printStackTrace();
			return false;
		}
	}

	@Override
	protected void onActivityResult(int requestCode, int resultCode, Intent data)
	{
		super.onActivityResult(requestCode, resultCode, data);
		if(requestCode == REQUEST_BT_SETTINGS){
			BluetoothDevice dispositivo = mBluetoothAdapter.getRemoteDevice(address);
			if(dispositivo.getBondState() == BluetoothDevice.BOND_BONDED){
				mPresenta.agregarPuerto(clave, dispositivo.getAddress() + "_" + dispositivo.getName());
				LinearLayout lista = (LinearLayout) findViewById(android.R.id.list);
				for (int i = 0; i < lista.getChildCount(); i++)
				{
					View elemento = lista.getChildAt(i);
					if ((elemento.getClass().equals(Button.class)) && (elemento.getTag() != null) && (elemento.getTag().toString().equals(clave)))
					{
						Button etiqueta = (Button) elemento;
						etiqueta.setText(dispositivo.getName() + "\n" + dispositivo.getAddress());
						break;
					}
				}
			}
		}
	}
	
	public boolean existeBDVendedor()
	{
		try
		{
			ConfiguracionLocal conf = (ConfiguracionLocal) Sesion.get(Campo.ConfiguracionLocal);
			Usuario usuario = Consultas.ConsultasUsuario.obtenerUsuarioPorClave(conf.get(CampoConfiguracion.USUARIO).toString());
			File archivoBD = new File(conf.get(CampoConfiguracion.DIRECTORIO_TRABAJO).toString());
			archivoBD = new File(archivoBD, "bd");
			String nombreBD = usuario.USUId + ".db";
			archivoBD = new File(archivoBD, nombreBD);
			if (!archivoBD.exists())
				return false;

			BDVend.cerrar();
			Sesion.set(Sesion.Campo.UsuarioActual, usuario);
			BDVend.Iniciar();
			Vendedor vendedor = (Vendedor) Sesion.get(Sesion.Campo.VendedorActual);
			aseguramiento = Consultas.ConsultarAseguramientoVisita.obtenerAseguramientoPorVendedor(vendedor);
			if (aseguramiento.TipoContrasena == 1)
			{
				TextView texto = (TextView) findViewById(R.id.lblContrasenaFija);
				EditText pass = (EditText) findViewById(R.id.txtContrasenaFija);
				texto.setVisibility(View.VISIBLE);
				pass.setVisibility(View.VISIBLE);
			}
			return true;
		}
		catch (Exception e)
		{
			e.printStackTrace();
			return false;
		}
	}

	private TextWatcher mContraFija = new TextWatcher()
	{

		public void afterTextChanged(Editable arg0)
		{
		}

		public void beforeTextChanged(CharSequence arg0, int arg1, int arg2, int arg3)
		{
		}

		public void onTextChanged(CharSequence arg0, int arg1, int arg2, int arg3)
		{
			CheckBox chk = (CheckBox) findViewById(R.id.ChkAseguramientoVisita);
			huboCambios = true;
			if (arg0.toString().equals(aseguramiento.ContrasenaFija))
			{
				chk.setVisibility(View.VISIBLE);
			}
			else
			{
				chk.setVisibility(View.GONE);
			}
		}
	};

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

	public void guardarAseguramiento()
	{
		try
		{
			CheckBox chk = (CheckBox) findViewById(R.id.ChkAseguramientoVisita);
			aseguramiento.EdoContraFija = chk.isChecked();
			BDVend.guardarInsertar(aseguramiento);
			BDVend.commit();
		}
		catch (Exception e)
		{
			e.printStackTrace();
		}
	}

	@Override
	public void onDestroy()
	{
		if (mBluetoothAdapter != null)
		{
			if (mBluetoothAdapter.isDiscovering())
				mBluetoothAdapter.cancelDiscovery();
			if (mBluetoothAdapter.isEnabled())
				mBluetoothAdapter.disable();
			if (recibidor && mReceiver != null)
				unregisterReceiver(mReceiver);
		}
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
			if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.M){
				verifyPermission();
			}
			else {
				if (huboCambios)
					validarAsync();
				else
					mPresenta.continuar();
			}
//			if (huboCambios)
//				validarAsync();
//			else
//				mPresenta.continuar();
		}
	};

	@TargetApi(Build.VERSION_CODES.M)
	private void verifyPermission() {
		int permissionCheck = checkSelfPermission(Manifest.permission.READ_PHONE_STATE);
		int permsRequestCode = 100;
		String[] perms = {Manifest.permission.READ_PHONE_STATE, Manifest.permission.INTERNET, Manifest.permission.WRITE_EXTERNAL_STORAGE, Manifest.permission.READ_EXTERNAL_STORAGE, Manifest.permission.ACCESS_COARSE_LOCATION, Manifest.permission.ACCESS_FINE_LOCATION, Manifest.permission.CAMERA};
		int ReadPhonePermision = checkSelfPermission(Manifest.permission.READ_PHONE_STATE);
		int InternetPermision = checkSelfPermission(Manifest.permission.INTERNET);
		int WritePhonePermision = checkSelfPermission(Manifest.permission.WRITE_EXTERNAL_STORAGE);
		int ReadExPhonePermision = checkSelfPermission(Manifest.permission.READ_EXTERNAL_STORAGE);
		int CoarseLocationPermision = checkSelfPermission(Manifest.permission.ACCESS_COARSE_LOCATION);
		int FineLocationPermision = checkSelfPermission(Manifest.permission.ACCESS_FINE_LOCATION);
		int CameraPermision = checkSelfPermission(Manifest.permission.CAMERA);

		if (ReadPhonePermision == PackageManager.PERMISSION_GRANTED && InternetPermision == PackageManager.PERMISSION_GRANTED && WritePhonePermision == PackageManager.PERMISSION_GRANTED && ReadExPhonePermision == PackageManager.PERMISSION_GRANTED && CoarseLocationPermision == PackageManager.PERMISSION_GRANTED && FineLocationPermision == PackageManager.PERMISSION_GRANTED && CameraPermision == PackageManager.PERMISSION_GRANTED) {
			//se realiza metodo si es necesario...
			if (huboCambios)
				validarAsync();
			else
				mPresenta.continuar();
		} else {
			requestPermissions(perms, permsRequestCode);
		}
	}

	@Override
	public void onRequestPermissionsResult(int requestCode, String permissions[], int[] grantResults) {
		switch (requestCode) {
			case 100:
				//acción o método a realizar.
//				mPresenta.continuar();
				if (huboCambios)
					validarAsync();
				else
					mPresenta.continuar();
				break;
		}
	}

	private void validarAsync()
	{
		// final ProgressDialog dialog = ProgressDialog.show(this, "",
		// "Conectando ...", true);

		final DialogoProgreso dialog = new DialogoProgreso(this);
		dialog.setProgressStyle(DialogoProgreso.STYLE_SPINNER);
		dialog.setMessage("Conectando al servicio ...");
		dialog.setCancelable(false);
		dialog.show();

		handler = new Handler();
		Runnable accion = new Runnable()
		{
			public void run()
			{
				if (validarDatosConfiguracion() && validarUsuarioContrasena()){
//					//Prueba permisos
//					if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.M){
//						verifyPermission();
//					}
					mPresenta.continuar();
				}
			}
		};

		final Thread valida = new Thread(accion);

		Runnable mensaje = new Runnable()
		{
			public void run()
			{
				while (valida.isAlive())
				{
				}
				dialog.dismiss();
			}
		};
		new Thread(mensaje).start();
		valida.start();
	}

	private boolean validarUsuarioContrasena()
	{
		try
		{
			CheckBox wireless = (CheckBox) findViewById(R.id.chkWireless);
			if (wireless.isChecked())
				Dispositivo.EncenderApagarWiFi((Context)this, true, 4);

			if (!ServicesCentral.ProbarAccesoServicio(getServicio()))
			{
				handler.post(new Runnable()
				{ // el hilo principal ejecuta este codigo
					public void run()
					{
						mostrarError("No se puede establecer conexión de Área Local. Avisar a Soporte Técnico");
					}
				});
				return false;
			}
			else
			{
				String usuario = getUsuario();
				String contrasena = getContrasenia();
				// final String mensaje = "";
				boolean vendedor = false;
				boolean modulo = false;
				String url = getServicio();
				Object params[] = new Object[]
				{ usuario, contrasena, "", vendedor, modulo, url, getTimeOut() };
				ServicesCentral.WSObtenerUsuarioContrasena(params);
				final String mensaje = params[2].toString();
				vendedor = Boolean.parseBoolean(params[3].toString());
				modulo = Boolean.parseBoolean(params[4].toString());
				if (mensaje.equals("Usuario y Contraseña valida") || vendedor || modulo)
				{
					return true;
				}
				else
				{
					handler.post(new Runnable()
					{ // el hilo principal ejecuta este codigo
						public void run()
						{
							mostrarAdvertencia(mensaje);
						}
					});
					return false;
				}
			}
		}
		catch (Exception e)
		{
			mostrarError(e.getMessage());
			return false;
		}
	}

	public void presentarTiposPapel(ValorReferencia[] papeles)
	{
		if (papeles != null)
		{
			LinearLayout lista = (LinearLayout) findViewById(android.R.id.list);

			for (ValorReferencia valor : papeles)
			{
				TextView etiqueta = new TextView(this);
				etiqueta.setText(valor.getDescripcion());
				etiqueta.setTextAppearance(this, android.R.style.TextAppearance_Small);
				Button boton = new Button(this);
				boton.setTag(valor.getVavclave());
				boton.setOnClickListener(new OnClickListener()
				{

					public void onClick(View v)
					{
						seleccionarPuerto(v.getTag().toString());

					}
				});
				lista.addView(etiqueta, lista.getChildCount() - 1);
				lista.addView(boton, lista.getChildCount() - 1);

			}
		}
	}

	private void seleccionarPuerto(final String VAVClave)
	{
		//if (buscandoDispositivos) return;
		if (mListaDispositivos.size() == 0 && (!VAVClave.equals("12") && !VAVClave.equals("13")))
		{
			/*if (mBluetoothAdapter.isDiscovering())
				mBluetoothAdapter.cancelDiscovery();
			
			buscandoDispositivos = true;
			mBluetoothAdapter.startDiscovery();*/
			
			mostrarAdvertencia("No se han encontrado dispositivos, intente mas tarde");
			return;
		}
		/* Para la impresora fija */
		if("12".equals(VAVClave)){
			/* Mostrar el dialog para la captura de la ip */
			LayoutInflater factory = LayoutInflater.from(this);

			// text_entry is an Layout XML file containing two text field to display
			// in alert dialog
			final View textEntryView = factory.inflate(R.layout.captura_ip, null);

			final EditText txtIP = (EditText) textEntryView.findViewById(R.id.txtAlertIP);
			txtIP.setText(mPresenta.existePuerto(VAVClave));
			final AlertDialog.Builder alert = new AlertDialog.Builder(this, R.style.MisClientes_CustomDialog);
			final String titulo = ValoresReferencia.getDescripcion("TPAPEL", VAVClave);
			alert.setTitle(titulo).setView(textEntryView).
			setPositiveButton(Mensajes.get("BTContinuar"), null).
			setNegativeButton(Mensajes.get("BTRegresar"), null);
			final AlertDialog dialogo = alert.create();
			dialogo.show();
			dialogo.getButton(AlertDialog.BUTTON_POSITIVE).setOnClickListener(new OnClickListener()
			{
				public void onClick(View v)
				{
					String ip = txtIP.getText().toString();
					if(ip.isEmpty()){
						dialogo.dismiss();
						mPresenta.eliminarPuerto(VAVClave);
					}
					else if(ip.matches(IP_PATTERN)){
						dialogo.dismiss();
						mPresenta.agregarPuerto(VAVClave, ip);
						LinearLayout lista = (LinearLayout) findViewById(android.R.id.list);
						for (int i = 0; i < lista.getChildCount(); i++)
						{
							View elemento = lista.getChildAt(i);
							if ((elemento.getClass().equals(Button.class)) && (elemento.getTag() != null) && (elemento.getTag().toString().equals(VAVClave)))
							{
								Button etiqueta = (Button) elemento;
								etiqueta.setText(ip);
								break;
							}
						}
					}else{
						mostrarAdvertencia(Mensajes.get("E0593", titulo, "XXX.XXX.XXX.XXX"));
//						mPresenta.eliminarPuerto(VAVClave);
					}
				}
			});
		/* Impresion integrada */	
		}else if("13".equals(VAVClave)){
			String tag = "PUERTO SERIAL";
			if(!mPresenta.existePuerto(VAVClave).toString().isEmpty()){
				mPresenta.eliminarPuerto(VAVClave);
				tag = "";
			} else {
				mPresenta.agregarPuerto(VAVClave, tag);
			}
			LinearLayout lista = (LinearLayout) findViewById(android.R.id.list);
			for (int i = 0; i < lista.getChildCount(); i++)
			{
				View elemento = lista.getChildAt(i);
				if ((elemento.getClass().equals(Button.class)) && (elemento.getTag() != null) && (elemento.getTag().toString().equals(VAVClave)))
				{
					Button etiqueta = (Button) elemento;
					etiqueta.setText(tag);
					break;
				}
			}
		}else{
			final CharSequence[] lista = new CharSequence[mListaDispositivos.size() + 1];
			lista[0] = "Ninguno";
			for (int i = 0; i < lista.length - 1; i++)
			{
				BluetoothDevice d = mListaDispositivos.get(i);
				lista[i + 1] = d.getName() + "\n" + d.getAddress();
			}
			AlertDialog.Builder builder = new AlertDialog.Builder(this);
			builder.setTitle("Selecciona un puerto");
			builder.setSingleChoiceItems(lista, -1, new DialogInterface.OnClickListener()
			{
				public void onClick(DialogInterface dialog, int item)
				{
					if (item != 0)
					{
						String elemento = lista[item].toString();
						String address = elemento.split("\n")[1];
						relacionarBT(address, VAVClave);
						dialog.dismiss();
					}
					else
					{
	
						mPresenta.eliminarPuerto(VAVClave);
						LinearLayout lista = (LinearLayout) findViewById(android.R.id.list);
						for (int i = 0; i < lista.getChildCount(); i++)
						{
							View elemento = lista.getChildAt(i);
							if ((elemento.getClass().equals(Button.class)) && (elemento.getTag() != null) && (elemento.getTag().toString().equals(VAVClave)))
							{
								Button etiqueta = (Button) elemento;
								etiqueta.setText("Ninguno");
								break;
							}
						}
						dialog.dismiss();
					}
	
				}
			});
			AlertDialog alert = builder.create();
			alert.show();
		}
	}

	// private void relacionarBT(BluetoothDevice dispositivo, String VAVClave){
	private void relacionarBT(String address, String VAVClave)
	{
		if(mBluetoothAdapter.isDiscovering()){
			mBluetoothAdapter.cancelDiscovery();
		}
		boolean bien = false;
		BluetoothSocket mmSocket;
		BluetoothDevice dispositivo = mBluetoothAdapter.getRemoteDevice(address);
		if (dispositivo == null)
		{
			Mensajes.get("BTnoEncontrado");
			return;
		}
        if (dispositivo.getBondState() != BluetoothDevice.BOND_BONDED ) {
            try {
                Method m = dispositivo.getClass().getMethod("createRfcommSocket", new Class[]
                        {int.class});
                mmSocket = (BluetoothSocket) m.invoke(dispositivo, 1);
                try {
                    // Connect the device through the socket. This will block
                    // until it succeeds or throws an exception
                    mmSocket.connect();
                    bien = true;
                } catch (IOException connectException) {
                    try {

                        mmSocket = dispositivo.createRfcommSocketToServiceRecord(UUID.fromString("00001101-0000-1000-8000-00805f9b34fb"));
                        mmSocket.connect();
                    } catch (Exception e2) {
                        mostrarError(connectException.getMessage());
                    }
                } finally {
                    try {
                        mmSocket.close();
                    } catch (IOException closeException) {
                    }
                }
            } catch (SecurityException e) {
                e.printStackTrace();
                mostrarError(e.getMessage());
            } catch (NoSuchMethodException e) {
                e.printStackTrace();
                mostrarError(e.getMessage());
            } catch (IllegalArgumentException e) {
                e.printStackTrace();
                mostrarError(e.getMessage());
            } catch (IllegalAccessException e) {
                e.printStackTrace();
                mostrarError(e.getMessage());
            } catch (InvocationTargetException e) {
                e.printStackTrace();
                mostrarError(e.getMessage());
            } finally {
                mBluetoothAdapter.startDiscovery();
            }
        }else{
            bien = true;
        }
		if (bien)
		{
			if(dispositivo.getBondState() == BluetoothDevice.BOND_BONDED){
				mPresenta.agregarPuerto(VAVClave, dispositivo.getAddress() + "_" + dispositivo.getName());
				LinearLayout lista = (LinearLayout) findViewById(android.R.id.list);
				for (int i = 0; i < lista.getChildCount(); i++)
				{
					View elemento = lista.getChildAt(i);
					if ((elemento.getClass().equals(Button.class)) && (elemento.getTag() != null) && (elemento.getTag().toString().equals(VAVClave)))
					{
						Button etiqueta = (Button) elemento;
						etiqueta.setText(dispositivo.getName() + "\n" + dispositivo.getAddress());
						break;
					}
				}
			}else{
				this.address = address;
				clave = VAVClave;
				final Intent intent = new Intent(Intent.ACTION_MAIN);
                final ComponentName cn = new ComponentName("com.android.settings", "com.android.settings.bluetooth.BluetoothSettings");
                intent.setComponent(cn);
                startActivityForResult(intent, REQUEST_BT_SETTINGS);
			}
		}

	}

	@Override
	public boolean onCreateOptionsMenu(Menu menu)
	{

		String accion = getIntent().getAction();
		MenuInflater inflater = getMenuInflater();
		inflater.inflate(R.menu.menu_configuracion_terminal, menu);
		if ((accion != null) && (accion.equals(Enumeradores.Acciones.ACCION_CONFIGURAR_PUERTOS)))
			menu.getItem(0).setVisible(false);
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
				finish();
				System.exit(0);
				return false;
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

	public void setUsuario(String valor)
	{
		EditText texto = (EditText) findViewById(R.id.txtUsuario);
		texto.setText(valor);
	}

	public void setContrasenia(String valor)
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

	public String getUsuario()
	{
		EditText texto = (EditText) findViewById(R.id.txtUsuario);
		return texto.getText().toString();
	}

	public String getContrasenia()
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
				if (texto.getText().length() == 0 && texto.getId() != R.id.txtContrasenaFija)
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
				buscarDispositivosBT();
			}
		}

	}

	private void buscarDispositivosBT()
	{
		IntentFilter filter = new IntentFilter(BluetoothDevice.ACTION_FOUND);
		filter.addAction(BluetoothAdapter.ACTION_DISCOVERY_FINISHED);
		registerReceiver(mReceiver, filter); // Don't forget to unregister
												// during onDestroy
		recibidor = true;
		//buscandoDispositivos = true;
		if (!mBluetoothAdapter.startDiscovery()){
			buscarDispositivosEmparejados();
		}
	}

	private void buscarDispositivosEmparejados()
	{
		BluetoothAdapter mBluetoothAdapter = BluetoothAdapter.getDefaultAdapter();
		Set<BluetoothDevice> pairedDevicesList = mBluetoothAdapter.getBondedDevices();

		for(BluetoothDevice pairedDevice : pairedDevicesList) {
			if (!mListaDispositivos.contains(pairedDevice))
				mListaDispositivos.add(pairedDevice);

		}
	}
	// Create a BroadcastReceiver for ACTION_FOUND
	private final BroadcastReceiver mReceiver = new BroadcastReceiver()
	{
		public void onReceive(Context context, Intent intent)
		{
			String action = intent.getAction();
			if (BluetoothDevice.ACTION_FOUND.equals(action))
			{
				BluetoothDevice device = intent.getParcelableExtra(BluetoothDevice.EXTRA_DEVICE);
				if (!mListaDispositivos.contains(device))
					mListaDispositivos.add(device);
			}else if (BluetoothAdapter.ACTION_DISCOVERY_FINISHED.equals(action)){
				
				//buscandoDispositivos = false;
			}
		}
	};

	public void setConfiguracionPuerto(Map<String, String> configuracion)
	{
		LinearLayout lista = (LinearLayout) findViewById(android.R.id.list);
		for (int i = 0; i < lista.getChildCount(); i++)
		{
			View elemento = lista.getChildAt(i);
			String llave = (String) elemento.getTag();
			if (llave != null)
			{
				String texto = configuracion.get(llave);
				Button boton = (Button) elemento;
				if("12".equals(llave) || "13".equals(llave)){// IP Fija
					boton.setText(texto);
				}else{
					if (texto != null)
					{
						int index = texto.indexOf("_");
						String nombre = texto.substring(index + 1);
						String address = texto.substring(0, index);
						boton.setText(nombre + "\n" + address);
					}
				else
					boton.setText("");
				}
			}
		}

	}

	public void mostrarOpcionesPuerto()
	{
		mBluetoothAdapter = BluetoothAdapter.getDefaultAdapter();
		if (mBluetoothAdapter == null)
		{
			mostrarAdvertencia(Mensajes.get("NoExisteBT"));
			return;
		}
		if (!mBluetoothAdapter.isEnabled())
		{
			if(mBluetoothAdapter.enable()){
				IntentFilter filter = new IntentFilter(BluetoothAdapter.ACTION_STATE_CHANGED);
				registerReceiver(mReceiverBT, filter);
			}
		}
		else
			buscarDispositivosBT();
	}

	@Override
	public void respuestaMensaje(RespuestaMsg respuesta, int tipoMensaje)
	{

	}

	public Boolean isWireless()
	{
		CheckBox check = (CheckBox) findViewById(R.id.chkWireless);
		return check.isChecked();
	}
	
	public Boolean isBluetooth()
	{
		CheckBox check = (CheckBox) findViewById(R.id.chkBluetooth);
		return check.isChecked();
	}

	public void setWireless(Boolean valor)
	{
		CheckBox check = (CheckBox) findViewById(R.id.chkWireless);
		check.setChecked(valor);
	}

	public void setBluetooth(Boolean valor)
	{
		CheckBox check = (CheckBox) findViewById(R.id.chkBluetooth);
		check.setChecked(valor);
	}
	public void setAseguramientoVisita(boolean valor)
	{
		CheckBox check = (CheckBox) findViewById(R.id.ChkAseguramientoVisita);
		check.setChecked(valor);
	}

    public void setHabilitarLog(Boolean valor){
        CheckBox check = (CheckBox) findViewById(R.id.chkHabilitarLog);
        check.setChecked(valor);
    }

    public Boolean isHabilitarLog()
    {
        CheckBox check = (CheckBox) findViewById(R.id.chkHabilitarLog);
        return check.isChecked();
    }
}
