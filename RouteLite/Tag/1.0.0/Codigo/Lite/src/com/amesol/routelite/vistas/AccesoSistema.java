package com.amesol.routelite.vistas;

import android.app.Activity;
import android.content.ComponentName;
import android.content.Intent;
import android.os.Bundle;
import android.util.DisplayMetrics;
import android.util.Log;
import android.view.Display;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;

import com.amesol.routelite.R;
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.Enumeradores.RespuestaMsg;
import com.amesol.routelite.presentadores.act.AccederSistema;
import com.amesol.routelite.presentadores.interfaces.IAccesoSistema;
import com.amesol.routelite.utilerias.Constants;

public class AccesoSistema extends Vista implements IAccesoSistema
{
	AccederSistema mPresenta;

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
		}
		// else if (())
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
		MenuInflater inflater = getMenuInflater();
		inflater.inflate(R.menu.menu_acceso_sistema, menu);
		// menu.add(groupId, itemId, order, title)
		menu.getItem(0).setTitle(Mensajes.get("MDB0210"));
		menu.getItem(1).setTitle(Mensajes.get("MDB0212"));
		menu.getItem(2).setTitle(Mensajes.get("MDB0503"));
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
			case R.id.configuracion:
				mPresenta.configuracion();
				return true;
			case R.id.recibir:
				mPresenta.recibir();
				return true;
			default:
				return super.onOptionsItemSelected(item);
		}
	}

	private OnClickListener mAcceder = new OnClickListener()
	{
		public void onClick(View v)
		{
			if (validarInformacion())
			{
				mPresenta.acceder();
			}
		}
	};

	private boolean validarInformacion()
	{
		EditText textbox = (EditText) findViewById(R.id.txtLogin);
		TextView label = null;
		String usuario = textbox.getText().toString().trim();
		if (usuario.length() == 0)
		{
			label = (TextView) findViewById(R.id.lblLogin);
			textbox.requestFocus();
			mostrarAdvertencia(Mensajes.get("BE0001", label.getText().toString()));
			return false;
		}
		textbox = (EditText) findViewById(R.id.txtPassword);
		label = null;
		String password = textbox.getText().toString().trim();
		if (password.length() == 0)
		{
			label = (TextView) findViewById(R.id.lblPassword);
			textbox.requestFocus();
			mostrarAdvertencia(Mensajes.get("BE0001", label.getText().toString()));
			return false;
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
}
