package com.amesol.routelite.vistas;

import android.app.Activity;
import android.app.AlertDialog;
import android.content.ComponentName;
import android.content.Intent;
import android.os.Bundle;
import android.text.Layout;
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
import android.widget.EditText;
import android.widget.LinearLayout;
import android.widget.TextView;

import com.amesol.routelite.R;
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.actividades.ValorReferencia;
import com.amesol.routelite.actividades.ValoresReferencia;
import com.amesol.routelite.datos.PoliticaContrasenaHist;
import com.amesol.routelite.datos.Ruta;
import com.amesol.routelite.datos.Usuario;
import com.amesol.routelite.datos.utilerias.ArchivoConfiguracion;
import com.amesol.routelite.datos.utilerias.ConfiguracionLocal;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.Enumeradores.RespuestaMsg;
import com.amesol.routelite.presentadores.act.AccederSistema;
import com.amesol.routelite.presentadores.act.ServirComunicaciones;
import com.amesol.routelite.presentadores.interfaces.IAccesoSistema;
import com.amesol.routelite.presentadores.interfaces.IAtencionClientes;
import com.amesol.routelite.presentadores.interfaces.IServidorComunicaciones;
import com.amesol.routelite.presentadores.parcelables.DatosGPS;
import com.amesol.routelite.utilerias.Constants;
import com.amesol.routelite.vistas.utilerias.Dispositivo;
import com.amesol.routelite.vistas.utilerias.ServicesCentral;

import java.util.HashMap;


public class AccesoSistema extends Vista implements IAccesoSistema
{
	AccederSistema mPresenta;
    AlertDialog dialogoSustituto;
    AlertDialog dialogoModificaContrasena;
    String UsuarioDialogoSustituto;
    String ContrasenaDialogoSustituto;
    String UsuarioDialogoModContra;
    String ContrasenaDialogoModContra;
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
		mPresenta.cargaSustituto();
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

			// label of user
			TextView lblLogin = (TextView) findViewById(R.id.lblLogin);
			lblLogin.setText(Mensajes.get("XUsuario"));
			lblLogin.setWidth(display.getWidth() / Constants._LABELS_WIDTH);
			lblLogin.setHeight(display.getHeight() / Constants._LABELS_HEIGHT);
			lblLogin.setTextSize((lblLogin.getTextSize() / getMetrics().density) + 5);

			// label of password
			TextView lblPassword = (TextView) findViewById(R.id.lblPassword);
			lblPassword.setText(Mensajes.get("XContraseña"));
			lblPassword.setWidth(display.getWidth() / Constants._LABELS_WIDTH);
			lblPassword.setHeight(display.getHeight() / Constants._LABELS_HEIGHT);
			lblPassword.setTextSize((lblPassword.getTextSize() / getMetrics().density) + 5);

			// text editor of login
			EditText txtLogin = (EditText) findViewById(R.id.txtLogin);
			txtLogin.setWidth(display.getWidth() / 2);
			txtLogin.setHeight(display.getHeight() / 30);
			txtLogin.setTextSize((lblPassword.getTextSize() / getMetrics().density) + 3);

			// text editor on password
			EditText txtPass = (EditText) findViewById(R.id.txtPassword);
			txtPass.setWidth(display.getWidth() / 2);
			txtPass.setHeight(display.getHeight() / 30);
			txtPass.setTextSize((lblPassword.getTextSize() / getMetrics().density) + 3);

			// button to Sign In
			Button btnAceptar = (Button) findViewById(R.id.btnAceptar);
			btnAceptar.setWidth(display.getWidth() / 3);
			btnAceptar.setHeight(display.getHeight() / 14);
			btnAceptar.setText(Mensajes.get("BTIngresar"));
			btnAceptar.setTextSize((btnAceptar.getTextSize() / metrics.density) + 3);
			btnAceptar.setOnClickListener(mAcceder);
		}
		catch (Exception ex)
		{
			Log.i("Exception On Init -- elopez --", ex.getMessage());
		}
	}

	@Override
	public void resultadoActividad(int requestCode, int resultCode, Intent data)
	{
		if ((requestCode == Enumeradores.Solicitudes.SOLICITUD_CONFIGURACION) && (resultCode == Enumeradores.Resultados.RESULTADO_BIEN))
		{
			return;
		}
		else if ((requestCode == Enumeradores.Solicitudes.SOLICITUD_AGENDA) && (resultCode == Enumeradores.Resultados.RESULTADO_BIEN))
		{
			mPresenta.acceder();
		}
		else if ((requestCode == Enumeradores.Solicitudes.SOLICITUD_RECIBIR) && (resultCode == Enumeradores.Resultados.RESULTADO_BIEN))
		{
			// TODO:no se que se hace
		}else if(requestCode == Enumeradores.Solicitudes.SOLICITUD_SERVIDOR_COMUNICACIONES){
            if (resultCode == Enumeradores.Resultados.RESULTADO_BIEN){
                String mensaje = (String) data.getExtras().getString("mensajeIniciar");

                dialogoModificaContrasena.dismiss();
                if (dialogoSustituto != null){
                    dialogoSustituto.dismiss();
                }
                if(VieneDe.equals("DialogoSustituto")){
                    mPresenta.acceder(UsuarioDialogoModContra, ContrasenaDialogoModContra, true);
                    VieneDe="";
                    Sesion.set(Sesion.Campo.MensajeEntrePantalla,mensaje);
                }else if(VieneDe.equals("BotonIngresar")){
                    mPresenta.acceder(UsuarioDialogoModContra, ContrasenaDialogoModContra, false);
                    VieneDe="";
                    Sesion.set(Sesion.Campo.MensajeEntrePantalla,mensaje);
                }else if(VieneDe.equals("SubMenu")){
                    mostrarAdvertencia(mensaje);
                    VieneDe="";
                }
            }else if (resultCode == Enumeradores.Resultados.RESULTADO_MAL){
                String mensajeError = (String) data.getExtras().getString("mensajeIniciar");
                mostrarAdvertencia(mensajeError);
            }
        }
    }

	public void setPassword(String valor)
	{
		EditText texto = (EditText) findViewById(R.id.txtPassword);
		texto.setText(valor);
	}

	public void setUsuario(String valor)
	{
		EditText texto = (EditText) findViewById(R.id.txtLogin);
		texto.setText(valor);
	}

	public String getUsuario()
	{
		EditText texto = (EditText) findViewById(R.id.txtLogin);
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
//		MenuInflater inflater = getMenuInflater();
//		inflater.inflate(R.menu.menu_acceso_sistema, menu);
//		// menu.add(groupId, itemId, order, title)
//		menu.getItem(0).setTitle("Ingresar Usuario  Sustituto"/*Mensajes.get("USUARIO_SUSTITUTO_CLVE")*/);
//		menu.getItem(1).setTitle(Mensajes.get("MDB0210"));
//		menu.getItem(2).setTitle(Mensajes.get("MDB0212"));
//		menu.getItem(3).setTitle(Mensajes.get("MDB0503"));
		/*
		 * getLayoutInflater().setFactory(new Factory() {
		 * 
		 * @Override public View onCreateView(String name, Context context,
		 * AttributeSet attrs) { // TODO Auto-generated method stub if
		 * (name.equalsIgnoreCase
		 * ("com.android.internal.view.menu.IconMenuItemView")) { try {
		 * LayoutInflater li = LayoutInflater.from(context); final View view =
		 * li.createView(name, null, attrs); new Handler().post(new Runnable() {
		 * public void run() { // set the background drawable if you want that
		 * // or keep it default -- either an image, border // gradient,
		 * drawable, etc. // view.setBackgroundResource(R.drawable.myimage);
		 * ((TextView) view).setTextSize(20);
		 * 
		 * // set the text color // Typeface face =
		 * Typeface.createFromAsset(getAssets(), "OldeEnglish.ttf"); //
		 * ((TextView) view).setTypeface(face); // ((TextView)
		 * view).setTextColor(Color.RED); } }); return view; } catch
		 * (InflateException e) { // Handle any inflation exception here } catch
		 * (ClassNotFoundException e) { // Handle any ClassNotFoundException
		 * here } } return null; }
		 * 
		 * }); return super.onCreateOptionsMenu(menu);
		 */
		// menu.addSubMenu(0, 1, 1, title)

        try{
            ValorReferencia[] mAcceso = ValoresReferencia.getValores("ACTSMLO");

            for (int a = 0; a < mAcceso.length; a++)
            {
                menu.add(0, Integer.parseInt( mAcceso[a].getVavclave().toString()),Integer.parseInt( mAcceso[a].getVavclave().toString()),mAcceso[a].getDescripcion());
            }
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
			//case R.id.salir:
            case Enumeradores.ACTSMLO.SALIR:
				if(mPresenta.existeSustituto()){
					mostrarDialogoSalirUsuarioSustituto();
				}else{
					mPresenta.intentarSalir(getUsuario(), getPassword());
				}
				return true;
			//case R.id.configuracion:
            case Enumeradores.ACTSMLO.CONFIGURACION:
				mPresenta.configuracion();
				return true;
			//case R.id.recibir:
            case Enumeradores.ACTSMLO.RECIBIR:
				mPresenta.recibir();
				return true;
			//case R.id.usuario_sustituto:
            case Enumeradores.ACTSMLO.USUARIO_SUSTITUTO:
				mPresenta.usuarioSustituto();
                return true;
            case Enumeradores.ACTSMLO.MODIFICAR_CONTRASEÑA:
                VieneDe="SubMenu";
                mPresenta.ModificarUsuario(false,"","","","");
                return true;
			default:
				return super.onOptionsItemSelected(item);
		}
	}

	private OnClickListener mAcceder = new OnClickListener()
	{
		public void onClick(View v)
		{
			if(mPresenta.existeSustituto()){
				mostrarDialogoUsuarioSustituto(mPresenta.getSustituto().Clave, "");
			}else				
			if (validarInformacion(null, null))
			{
                if (mPresenta.ModificarUsuarioActivo()){
                    VieneDe="BotonIngresar";
                    mPresenta.ModificarUsuario(true, mPresenta.getClaveUsuario(),VieneDe,"","");
                }else{
                    mPresenta.acceder();
                }
			}
		}
	};

	private boolean validarInformacion(String usuario, String password)
	{
		TextView label = null;
		EditText textbox = null;
		if(usuario == null)
		{
			textbox = (EditText) findViewById(R.id.txtLogin);
			usuario = textbox.getText().toString().trim();
		}
		if (usuario.length() == 0)
		{
			label = (TextView) findViewById(R.id.lblLogin);
			if(textbox != null)textbox.requestFocus();
			mostrarAdvertencia(Mensajes.get("BE0001", label.getText().toString()));
			return false;
		}
		if(password == null){
			textbox = (EditText) findViewById(R.id.txtPassword);
			password = textbox.getText().toString().trim();
		}

        PoliticaContrasenaHist politica =  mPresenta.getPoliticaContrasena(usuario);
        if (!mPresenta.ModificarUsuarioActivo()){
            if (password.length() == 0)
            {
                label = (TextView) findViewById(R.id.lblPassword);
                if(textbox != null)textbox.requestFocus();
                mostrarAdvertencia(Mensajes.get("BE0001", label.getText().toString()));
                return false;
            }
        }else if(politica==null){
            if (password.length() == 0)
            {
                label = (TextView) findViewById(R.id.lblPassword);
                if(textbox != null)textbox.requestFocus();
                mostrarAdvertencia(Mensajes.get("BE0001", label.getText().toString()));
                return false;
            }
        }
        return true;
	}

	@Override
	public void respuestaMensaje(RespuestaMsg respuesta, int tipoMensaje)
	{
		if ((tipoMensaje == 0) && (respuesta == RespuestaMsg.Si))
			mPresenta.cambiarUsuario();
		if ((tipoMensaje == 1) && (respuesta == RespuestaMsg.Si))
			mPresenta.salir();
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
	
	public void mostrarDialogoUsuarioSustituto(String usuario, String contrasenia){
		boolean enabled = usuario == null || usuario.isEmpty();
		LayoutInflater factory = LayoutInflater.from(this);

		// text_entry is an Layout XML file containing two text field to display
		// in alert dialog
		final View textEntryView = factory.inflate(R.layout.acceso_dia_diferente, null);

		final TextView lblLogin = (TextView) textEntryView.findViewById(R.id.lblAlertUser);
		lblLogin.setText(Mensajes.get("XUsuario"));

		final TextView lblPass = (TextView) textEntryView.findViewById(R.id.lblAlertPass);
		lblPass.setText(Mensajes.get("XContraseña"));

		final EditText txtUser = (EditText) textEntryView.findViewById(R.id.txtAlertUser);
		final EditText txtPass = (EditText) textEntryView.findViewById(R.id.txtAlertPass);
		txtUser.setText(usuario);
		txtUser.setEnabled(enabled);
		txtPass.setText(contrasenia);
		final AlertDialog.Builder alert = new AlertDialog.Builder(this, R.style.MisClientes_CustomDialog);
		alert.setTitle(Mensajes.get("MDB050402")).setView(textEntryView).
		setPositiveButton(Mensajes.get("BTContinuar"), null).
		setNegativeButton(Mensajes.get("BTRegresar"), null);
		//final AlertDialog dialogoSustituto = alert.create();
        dialogoSustituto = alert.create();
        dialogoSustituto.show();
        dialogoSustituto.getButton(AlertDialog.BUTTON_POSITIVE).setOnClickListener(new OnClickListener()
		{
			public void onClick(View v)
			{
				UsuarioDialogoSustituto = txtUser.getText().toString();
				ContrasenaDialogoSustituto = txtPass.getText().toString();
				if(validarInformacion(UsuarioDialogoSustituto, ContrasenaDialogoSustituto)){
                    if (mPresenta.ModificarUsuarioActivo()){
                        VieneDe="DialogoSustituto";
                        mPresenta.ModificarUsuario(true,UsuarioDialogoSustituto,VieneDe,UsuarioDialogoSustituto,ContrasenaDialogoSustituto);
                    }else{
                        dialogoSustituto.dismiss();
                        mPresenta.acceder(UsuarioDialogoSustituto, ContrasenaDialogoSustituto, true);
                    }
				}
			}
		});
        dialogoSustituto.getButton(AlertDialog.BUTTON_NEGATIVE).setOnClickListener(new OnClickListener()
        {
            public void onClick(View v)
            {
                if(!mPresenta.existeSustituto()){
                    Sesion.set(Sesion.Campo.UsuarioSustitutoPendiente,false);
                }
                dialogoSustituto.dismiss();
            }
        });
	}
	
	public void mostrarDialogoSalirUsuarioSustituto(){
		LayoutInflater factory = LayoutInflater.from(this);

		// text_entry is an Layout XML file containing two text field to display
		// in alert dialog
		final View textEntryView = factory.inflate(R.layout.acceso_dia_diferente, null);

		final TextView lblLogin = (TextView) textEntryView.findViewById(R.id.lblAlertUser);
		lblLogin.setText(Mensajes.get("XUsuario"));

		final TextView lblPass = (TextView) textEntryView.findViewById(R.id.lblAlertPass);
		lblPass.setText(Mensajes.get("XContraseña"));

		final EditText txtUser = (EditText) textEntryView.findViewById(R.id.txtAlertUser);
		final EditText txtPass = (EditText) textEntryView.findViewById(R.id.txtAlertPass);
		txtUser.setEnabled(true);
		final AlertDialog.Builder alert = new AlertDialog.Builder(this, R.style.MisClientes_CustomDialog);
		alert.setTitle(Mensajes.get("XContrasenaPara", Mensajes.get("BASESalir"))).setView(textEntryView).
		setPositiveButton(Mensajes.get("BTContinuar"), null).
		setNegativeButton(Mensajes.get("BTRegresar"), null);
		final AlertDialog dialogo = alert.create();
		dialogo.show();
		dialogo.getButton(AlertDialog.BUTTON_POSITIVE).setOnClickListener(new OnClickListener()
		{
			public void onClick(View v)
			{
				String clave = txtUser.getText().toString();
				String pass = txtPass.getText().toString();
				if(validarInformacion(clave, pass)){
					dialogo.dismiss();
					mPresenta.intentarSalir(clave, pass);
				}
			}
		});
	}
	
	@Override
	public void setUsuarioSustituto(Usuario usuarioSustituto)
	{
		boolean existeSustituto = usuarioSustituto != null;
		findViewById(R.id.txtLogin).setEnabled(!existeSustituto);
		findViewById(R.id.txtPassword).setEnabled(!existeSustituto);
		TextView lblUsuarioSust = (TextView) findViewById(R.id.lblUsuarioSustituto);
		lblUsuarioSust.setVisibility(existeSustituto ? View.VISIBLE : View.INVISIBLE);
		if(existeSustituto)
			lblUsuarioSust.setText("Usuario Sustituto: "/*Mensajes.get("XUsusarioSust")*/.concat(usuarioSustituto.Clave));
	}
	
	@Override
	public void borrarSustituto()
	{
		findViewById(R.id.txtLogin).setEnabled(true);
		EditText txtPass = (EditText) findViewById(R.id.txtPassword);
		txtPass.setEnabled(true);
		txtPass.setText("");
		TextView lblUsuarioSust = (TextView) findViewById(R.id.lblUsuarioSustituto);
		lblUsuarioSust.setText("");
		lblUsuarioSust.setVisibility(View.GONE);
	}

    public void mostrarDialogoModificacionUsuario(String usuario, String contrasenia, boolean contrasenaanterior){
        boolean enabled = usuario == null || usuario.isEmpty();
        LayoutInflater factory = LayoutInflater.from(this);
        final View textEntryView = factory.inflate(R.layout.acceso_dia_diferente, null);
        final LinearLayout lytPassAnt =  (LinearLayout)textEntryView.findViewById(R.id.lytAlertPassAnt);

        if (contrasenaanterior){
            lytPassAnt.setVisibility(View.VISIBLE);
        }

        final TextView lblLogin = (TextView) textEntryView.findViewById(R.id.lblAlertUser);
        lblLogin.setText(Mensajes.get("XUsuario"));

        final TextView lblPassAnt = (TextView) textEntryView.findViewById(R.id.lblAlertPassAnt);
        lblPassAnt.setText(Mensajes.get("XContraseñaAnt"));

        final TextView lblPass = (TextView) textEntryView.findViewById(R.id.lblAlertPass);
        lblPass.setText(Mensajes.get("XNuevaContraseña"));

        final EditText txtUser = (EditText) textEntryView.findViewById(R.id.txtAlertUser);
        final EditText txtPassAnt = (EditText) textEntryView.findViewById(R.id.txtAlertPassAnt);
        final EditText txtPass = (EditText) textEntryView.findViewById(R.id.txtAlertPass);

        txtUser.setText(usuario);
        txtUser.setEnabled(enabled);

        final AlertDialog.Builder alert = new AlertDialog.Builder(this, R.style.MisClientes_CustomDialog);
        alert.setTitle(Mensajes.get("XModificarContraseña")).setView(textEntryView).
                setPositiveButton(Mensajes.get("BTContinuar"), null).
                setNegativeButton(Mensajes.get("BTRegresar"), null);
        dialogoModificaContrasena = alert.create();
        dialogoModificaContrasena.show();
        dialogoModificaContrasena.getButton(AlertDialog.BUTTON_POSITIVE).setOnClickListener(new OnClickListener(){
            public void onClick(View v){
                UsuarioDialogoModContra = txtUser.getText().toString();
                ContrasenaDialogoModContra = txtPass.getText().toString();
                final LinearLayout lytPassAnt =  (LinearLayout)textEntryView.findViewById(R.id.lytAlertPassAnt);
                int contrasenaanterior= lytPassAnt.getVisibility();
                String clave = txtUser.getText().toString();
                String passant="";

                if (contrasenaanterior==0){
                    passant = txtPassAnt.getText().toString();
                }else{
                    passant = mPresenta.ObtenerContrasenaUsuario(clave);
                }

                String pass = txtPass.getText().toString();
                TextView label = null;
                EditText textbox = null;

                if (clave.length() == 0){
                    label = (TextView) findViewById(R.id.lblAlertUser);
                    if(textbox != null)textbox.requestFocus();
                    mostrarAdvertencia(Mensajes.get("BE0001", lblLogin.getText().toString()));
                    return;
                }

                if (contrasenaanterior==0 && passant.length() == 0)
                {
                    label = (TextView) findViewById(R.id.lblAlertPassAnt);
                    if(textbox != null)textbox.requestFocus();
                    mostrarAdvertencia(Mensajes.get("BE0001", lblPassAnt.getText().toString()));
                    return;
                }

                if (pass.length() == 0)
                {
                    label = (TextView) findViewById(R.id.lblPassword);
                    if(textbox != null)textbox.requestFocus();
                    mostrarAdvertencia(Mensajes.get("BE0001", lblPass.getText().toString()));
                    return;
                }

                if(mPresenta.validarDatosUsuario(clave, passant)){
                    try{
                        HashMap<String, Object> parametros = new HashMap<String,Object>();
                        parametros.put("ModificacionUsuario", true);
                        parametros.put("UsuarioMod", clave);
                        parametros.put("ContrasenaMod", pass);
                        iniciarActividadConResultado(IServidorComunicaciones.class, Enumeradores.Solicitudes.SOLICITUD_SERVIDOR_COMUNICACIONES, Enumeradores.Acciones.ACCION_MODIFICAR_CONTRASENA_USUARIO, parametros);
                    }
                    catch (Exception e){
                        e.printStackTrace();
                        mostrarAdvertencia(e.toString());
                    }
                }else{
                    return;
                }
            }
        });
    }
}
