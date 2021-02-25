package com.amesol.routelite.vistas;

import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Collection;
import java.util.Date;
import java.util.HashMap;
import java.util.Iterator;
import java.util.List;
import java.util.ListIterator;
import java.util.Map;

import android.annotation.SuppressLint;
import android.app.Activity;
import android.app.AlertDialog;
import android.app.DatePickerDialog;
import android.app.Dialog;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.database.Cursor;
import android.os.Bundle;
import android.support.annotation.NonNull;
import android.text.InputType;
import android.text.method.DigitsKeyListener;
import android.util.Log;
import android.view.Gravity;
import android.view.KeyEvent;
import android.view.LayoutInflater;
import android.view.MotionEvent;
import android.view.View;
import android.view.View.OnClickListener;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.CheckBox;
import android.widget.CompoundButton;
import android.widget.DatePicker;
import android.widget.EditText;
import android.widget.ImageButton;
import android.widget.LinearLayout;
import android.widget.ListView;
import android.widget.SimpleAdapter;
import android.widget.SimpleCursorAdapter;
import android.widget.TextView;
import android.widget.Toast;

import com.amesol.routelite.R;
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.actividades.PromocionDetalle;
import com.amesol.routelite.actividades.ValoresReferencia;
import com.amesol.routelite.datos.Cliente;
import com.amesol.routelite.datos.Secuencia;
import com.amesol.routelite.datos.Vendedor;
import com.amesol.routelite.datos.basedatos.BDVend;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.generales.Entidad;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.Enumeradores.RespuestaMsg;
import com.amesol.routelite.presentadores.act.CrearCliente;
import com.amesol.routelite.presentadores.interfaces.INuevoCliente;
import com.amesol.routelite.presentadores.interfaces.ISeleccionEsquemaProducto;
import com.amesol.routelite.utilerias.ControlError;
import com.amesol.routelite.utilerias.Generales;
import com.amesol.routelite.vistas.generico.AplicaPromoDetalleAdapter;

@SuppressLint("DefaultLocale")
public class NuevoCliente extends Vista implements INuevoCliente
{
	public final class TipoFecha
	{
		public final static short REGISTRO = 0;
		public final static short NACIMIENTO = 1;
		public final static short VIGENCIA = 2;
	}

	CrearCliente mPresenta;
	String tablaRequerido;
	String campoRequerido;
	boolean datoRequerido;
	short tipoFecha;
	Date fechaRegistro;
	Date fechaNacimiento;
	Date fechaVigencia;
	boolean huboCambios;
	static final int DATE_DIALOG_ID = 0;

	// DomicilioPE
	TextView txtCallePE;
	TextView txtMunicipioPE;
	TextView txtPaisPE;
	TextView txtNumeroExtPE;
	TextView txtNumeroIntPE;
	TextView txtColoniaPE;
	TextView txtCodigoPostalPE;
	TextView txtReferenciaPE;
	TextView txtEntidadPE;

	// DomicFiscal
	TextView txtCalleDF;
	TextView txtMunicipioDF;
	TextView txtPaisDF;
	TextView txtNumeroExtDF;
	TextView txtNumeroIntDF;
	TextView txtColoniaDF;
	TextView txtCodigoPostalDF;
	TextView txtReferenciaDF;
	TextView txtEntidadDF;

	boolean esNuevo = true;
	boolean soloLectura = false;

	HashMap<String,Boolean> frecuencias = new HashMap<String,Boolean>();
	HashMap<String,Integer> secuenciaOrden= new HashMap<String,Integer>();

	@Override
	public void onCreate(Bundle savedInstanceState)
	{
		super.onCreate(savedInstanceState);

		try
		{
			setContentView(R.layout.nuevo_cliente);
			deshabilitarBarra(true);
			lblTitle.setText(Mensajes.get("BTNuevo") + " " + Mensajes.get("XCliente"));
			/*
			 * // Aquí se pone en marcha el timer cada segundo. Timer timer =
			 * new Timer(); // Dentro de 0 milisegundos avísame cada 800
			 * milisegundos timer.scheduleAtFixedRate(timerTask, 0, 800);
			 */

			ImageButton btnGeneralMas = (ImageButton) findViewById(R.id.btnGeneralesMas);
			ImageButton btnGeneralMenos = (ImageButton) findViewById(R.id.btnGeneralesMenos);
			ImageButton btnDomicilioPEMas = (ImageButton) findViewById(R.id.btnDomicilioPEMas);
			ImageButton btnDomicilioPEMenos = (ImageButton) findViewById(R.id.btnDomicilioPEMenos);
			ImageButton btnDomicilioDFMas = (ImageButton) findViewById(R.id.btnDomicilioDFMas);
			ImageButton btnDomicilioDFMenos = (ImageButton) findViewById(R.id.btnDomicilioDFMenos);
			TextView lblFechaRegistro = (TextView) findViewById(R.id.lblFechaRegistroCli);
			TextView lblFechaNacimiento = (TextView) findViewById(R.id.lblFechaNacimientoCli);
			// TextView lblVigExclusividad = (TextView)
			// findViewById(R.id.lblVigExclusividadCli);
			ImageButton btnCopyyDomicilio = (ImageButton) findViewById(R.id.imgCopyDomicilio);
			ImageButton btnPasteDomicilio = (ImageButton) findViewById(R.id.imgPasteDomicilio);
			ImageButton btnCopyyFiscal = (ImageButton) findViewById(R.id.imgCopyDFiscal);
			ImageButton btnPasteFiscal = (ImageButton) findViewById(R.id.imgPasteDFiscal);

			// DisableCopyPasteButtons(btnCopyyDomicilio, btnPasteDomicilio,
			// btnCopyyFiscal, btnPasteFiscal);

			Button btnContinuar = (Button) findViewById(R.id.btnContinuar);
			// CheckBox chkDesglose =
			// (CheckBox)findViewById(R.id.chkDesgloseImpuestos);

			btnGeneralMas.setOnClickListener(mExpandirGenerales);
			btnGeneralMenos.setOnClickListener(mContraerGenerales);
			btnDomicilioPEMas.setOnClickListener(mExpandirPuntoEntrega);
			btnDomicilioPEMenos.setOnClickListener(mContraerPuntoEntrega);
			// chkDesglose.setOnCheckedChangeListener(mExpandirDomicilioFiscal);
			btnDomicilioDFMas.setOnClickListener(mExpandirDomicilioFiscal);
			btnDomicilioDFMenos.setOnClickListener(mContraerDomicilioFiscal);
			lblFechaRegistro.setOnClickListener(mExpandirFechaRegistro);
			lblFechaNacimiento.setOnClickListener(mExpandirFechaNacimiento);
			// lblVigExclusividad.setOnClickListener(mExpandirFechaVigencia);
			// elopez listeners

			txtCallePE = (TextView) findViewById(R.id.txtCallePE);
			txtMunicipioPE = (TextView) findViewById(R.id.txtMunicipioPE);
			txtPaisPE = (TextView) findViewById(R.id.txtPaisPE);
			txtNumeroExtPE = (TextView) findViewById(R.id.txtNumeroExtPE);
			txtNumeroIntPE = (TextView) findViewById(R.id.txtNumeroIntPE);
			txtColoniaPE = (TextView) findViewById(R.id.txtColoniaPE);
			txtCodigoPostalPE = (TextView) findViewById(R.id.txtCodigoPostalPE);
			txtReferenciaPE = (TextView) findViewById(R.id.txtReferenciaPE);
			txtEntidadPE = (TextView) findViewById(R.id.txtEntidadPE);

			txtCalleDF = (TextView) findViewById(R.id.txtCalleDF);
			txtMunicipioDF = (TextView) findViewById(R.id.txtMunicipioDF);
			txtPaisDF = (TextView) findViewById(R.id.txtPaisDF);
			txtNumeroExtDF = (TextView) findViewById(R.id.txtNumeroExtDF);
			txtNumeroIntDF = (TextView) findViewById(R.id.txtNumeroIntDF);
			txtColoniaDF = (TextView) findViewById(R.id.txtColoniaDF);
			txtCodigoPostalDF = (TextView) findViewById(R.id.txtCodigoPostalDF);
			txtReferenciaDF = (TextView) findViewById(R.id.txtReferenciaDF);
			txtEntidadDF = (TextView) findViewById(R.id.txtEntidadDF);

			btnCopyyDomicilio.setOnClickListener(mCopyDomicilio);
			btnPasteDomicilio.setOnClickListener(mPasteDomicilio);
			btnCopyyFiscal.setOnClickListener(mCopyFiscal);
			btnPasteFiscal.setOnClickListener(mPasteFiscal);

			btnContinuar.setOnClickListener(mGuardarCliente);
			TextView lblFrecuencias = (TextView) findViewById(R.id.lblFrecuencia);
			lblFrecuencias.setText(Mensajes.get("XDiaVisita"));
			ListView lvFrecuencias = (ListView) findViewById(R.id.lstFrecuencias);
			ISetDatos sdFrecuencias = Consultas.ConsultasFrecuencias.recuperarFrecuenciasOrden();
			MySimpleCursorAdapter adapter = new MySimpleCursorAdapter(this, R.layout.lista_check_edittext, (Cursor)sdFrecuencias.getOriginal(), new String[]
					{ "ClaveDescripcion", "Tipo","SigOrden","SigOrden" }, new int[]
					{ R.id.chk1, R.id.lbl1, R.id.txt,R.id.lbl2 });
			adapter.setViewBinder(new vistaFrecuencias());
			lvFrecuencias.setAdapter(adapter);
			setListViewHeightBasedOnChildren(lvFrecuencias);
			/*
			 * EditText txtClave = (EditText)findViewById(R.id.txtClave);
			 * txtClave.addTextChangedListener(new TextWatcher()){ public void
			 * onTextChanged(CharSequence s, int start, int before, int count) {
			 * huboCambios = true; }
			 * 
			 * public void afterTextChanged(Editable arg0) { // TODO
			 * Auto-generated method stub
			 * 
			 * }
			 * 
			 * public void beforeTextChanged(CharSequence s, int start, int
			 * count, int after) { // TODO Auto-generated method stub
			 * 
			 * } })
			 */;

			ConfigurarLayout();
		}
		catch (Exception e)
		{
			e.printStackTrace();
		}

		mPresenta = new CrearCliente(this);
		mPresenta.iniciar();
	}


	public void EnableCopyPasteButton(ImageButton cpButton, int visibility)
	{
		cpButton.setVisibility(visibility);
	}

	public void DisableCopyPasteButtons(ImageButton... cpButtons)
	{
		for (int i = 0; i < cpButtons.length; i++)
		{
			cpButtons[i].setVisibility(View.GONE);
		}
	}

	@Override
	public boolean onKeyDown(int keyCode, KeyEvent event)
	{
		switch (keyCode)
		{
			case KeyEvent.KEYCODE_BACK:
				boolean FlagDominicEntregaFiscal = false;
				try{

					for (int i = 0; i < getDomicilioPE().length; i++)
					{
						if (getDomicilioPE()[i] != null && getDomicilioPE()[i].length() > 0)
						{
							FlagDominicEntregaFiscal = true;
							break;
						}
					}
				}catch(Exception ex){
					mostrarError(ex.getMessage());
				}

				try
				{
					if (getRazonSocial() != null || getRFC() != null || getNombre() != null || getContacto() != null || getTelefono() != null || FlagDominicEntregaFiscal)
					{
						final AlertDialog.Builder alert = new AlertDialog.Builder(this, R.style.MisClientes_CustomDialog);
						alert.setTitle(Mensajes.get("BP0002")).setPositiveButton("Si", new DialogInterface.OnClickListener()
						{
							public void onClick(DialogInterface dialog, int whichButton)
							{
								try {
									BDVend.rollback();
									TerminateThis();
								}catch (Exception ex){
									mostrarError("Error al terminar la actividad");
								}
							}
						}).setNegativeButton("No", new DialogInterface.OnClickListener()
						{
							public void onClick(DialogInterface dialog, int whichButton)
							{

							}
						});
						alert.show();
					}
					else
						TerminateThis();
				}
				catch (Exception e)
				{
					Log.e("elopez", e.getMessage());
				}
				return true;
		}
		return super.onKeyDown(keyCode, event);
	}

	public void TerminateThis()
	{


		this.finish();
	}

	@SuppressWarnings("deprecation")
	@Override
	protected Dialog onCreateDialog(int id)
	{
		Date fecha = null;
		switch (tipoFecha)
		{
			case TipoFecha.REGISTRO:
				fecha = fechaRegistro;
				break;
			case TipoFecha.NACIMIENTO:
				fecha = fechaNacimiento;
				break;
			case TipoFecha.VIGENCIA:
				fecha = fechaVigencia;
				break;
			default:
				break;
		}

		try
		{
			if (fecha != null)
				return new DatePickerDialog(this, mDateSetListener, fecha.getYear() + 1900, fecha.getMonth(), fecha.getDate());
			else
				return null;
		}
		catch (Exception e)
		{
			e.printStackTrace();
			return null;
		}
	}

	@SuppressWarnings("deprecation")
	@Override
	protected void onPrepareDialog(int id, Dialog dialog)
	{
		Date fecha = null;
		switch (tipoFecha)
		{
			case TipoFecha.REGISTRO:
				fecha = fechaRegistro;
				break;
			case TipoFecha.NACIMIENTO:
				fecha = fechaNacimiento;
				break;
			case TipoFecha.VIGENCIA:
				fecha = fechaVigencia;
				break;
			default:
				break;
		}

		try
		{
			if (fecha != null)
				((DatePickerDialog) dialog).updateDate(fecha.getYear() + 1900, fecha.getMonth(), fecha.getDate());
		}
		catch (Exception e)
		{
			e.printStackTrace();
		}
	}

	public void iniciar()
	{
		// TODO Auto-generated method stub
	}

	@Override
	public void resultadoActividad(int requestCode, int resultCode, Intent data)
	{
		// TODO Auto-generated method stub

	}

	@SuppressLint("DefaultLocale")
	@Override
	public void respuestaMensaje(RespuestaMsg respuesta, int tipoMensaje)
	{
		if (datoRequerido)
		{
			if (tablaRequerido.toUpperCase().equals("CLIENTEDOMICILIO"))
			{
				if (mPresenta.getErrPuntoEntrega())
					tablaRequerido += "PE";
				else
					tablaRequerido += "DF";

				if (campoRequerido.toUpperCase().equals("POBLACION"))
					campoRequerido = "Localidad";
			}
			SeleccionarRequerido((LinearLayout) findViewById(R.id.layCliente));
		}
	}

	private OnClickListener mContraerGenerales = new OnClickListener()
	{
		public void onClick(View v)
		{
			MostrarLayout(R.id.layGeneralesMas, false, R.id.btnGeneralesMas);
		}
	};

	private OnClickListener mExpandirGenerales = new OnClickListener()
	{
		public void onClick(View v)
		{
			MostrarLayout(R.id.layGeneralesMas, true, R.id.btnGeneralesMas);
		}
	};

	private OnClickListener mContraerPuntoEntrega = new OnClickListener()
	{
		public void onClick(View v)
		{
			MostrarLayout(R.id.layDomicilioPEMas, false, R.id.btnDomicilioPEMas);
		}
	};

	private OnClickListener mExpandirPuntoEntrega = new OnClickListener()
	{
		public void onClick(View v)
		{
			MostrarLayout(R.id.layDomicilioPEMas, true, R.id.btnDomicilioPEMas);
		}
	};

	private OnClickListener mContraerDomicilioFiscal = new OnClickListener()
	{
		public void onClick(View v)
		{
			MostrarLayout(R.id.layDomicilioDFMas, false, R.id.btnDomicilioDFMas);
		}
	};

	private OnClickListener mExpandirDomicilioFiscal = new OnClickListener()
	{
		public void onClick(View v)
		{
			MostrarLayout(R.id.layDomicilioDFMas, true, R.id.btnDomicilioDFMas);
		}
	};

	private OnClickListener mExpandirFechaRegistro = new OnClickListener()
	{
		@SuppressWarnings("deprecation")
		public void onClick(View v)
		{
			tipoFecha = TipoFecha.REGISTRO;
			showDialog(DATE_DIALOG_ID);
		}
	};

	private OnClickListener mExpandirFechaNacimiento = new OnClickListener()
	{
		@SuppressWarnings("deprecation")
		public void onClick(View v)
		{
			tipoFecha = TipoFecha.NACIMIENTO;
			showDialog(DATE_DIALOG_ID);
		}
	};

	//	private OnClickListener mExpandirFechaVigencia = new OnClickListener()
	//	{
	//		public void onClick(View v)
	//		{
	//			tipoFecha = TipoFecha.VIGENCIA;
	//			showDialog(DATE_DIALOG_ID);
	//		}
	//	};

	private DatePickerDialog.OnDateSetListener mDateSetListener = new DatePickerDialog.OnDateSetListener()
	{
		@SuppressWarnings("deprecation")
		public void onDateSet(DatePicker view, int year, int monthOfYear, int dayOfMonth)
		{
			Date fecha = new Date(year - 1900, monthOfYear, dayOfMonth);
			;
			ActualizaFecha(fecha);
			huboCambios = true;
		}
	};

	// ___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---
	/*
	 * edit texts onChange listener
	 */
	// EditText

	/*
	 * TimerTask timerTask = new TimerTask() { public void run() { if
	 * (txtCallePE.toString().length() > 0) {
	 * EnableCopyPasteButton((ImageButton)findViewById(R.id.imgCopyDomicilio),
	 * View.VISIBLE); } else {
	 * EnableCopyPasteButton((ImageButton)findViewById(R.id.imgCopyDomicilio),
	 * View.INVISIBLE); } } };
	 */

	/*	 
	 */
	// Copy Paste Buttons begin
	private OnClickListener mCopyDomicilio = new OnClickListener()
	{
		@Override
		public void onClick(View v)
		{
			// TODO Auto-generated method stub
			sendTopMessage("Domicilio Punto Entrega Copiado");
		}
	};

	private OnClickListener mPasteDomicilio = new OnClickListener()
	{
		@Override
		public void onClick(View v)
		{
			// TODO Auto-generated method stub
			txtCallePE.setText(getDomFiscal()[0]);
			txtMunicipioPE.setText(getDomFiscal()[1]);
			txtPaisPE.setText(getDomFiscal()[2]);
			txtNumeroExtPE.setText(getDomFiscal()[3]);
			txtNumeroIntPE.setText(getDomFiscal()[4]);
			txtColoniaPE.setText(getDomFiscal()[5]);
			txtCodigoPostalPE.setText(getDomFiscal()[6]);
			txtReferenciaPE.setText(getDomFiscal()[7]);
			txtEntidadPE.setText(getDomFiscal()[8]);
		}
	};

	/*
	 * --------------------------------------------------------------------------
	 * ---------------------
	 */
	private OnClickListener mCopyFiscal = new OnClickListener()
	{
		@Override
		public void onClick(View v)
		{
			// TODO Auto-generated method stub
			sendTopMessage("Domicilio Fiscal Copiado");
		}
	};

	private OnClickListener mPasteFiscal = new OnClickListener()
	{
		@Override
		public void onClick(View v)
		{
			// TODO Auto-generated method stub
			txtCalleDF.setText(getDomicilioPE()[0]);
			txtMunicipioDF.setText(getDomicilioPE()[1]);
			txtPaisDF.setText(getDomicilioPE()[2]);
			txtNumeroExtDF.setText(getDomicilioPE()[3]);
			txtNumeroIntDF.setText(getDomicilioPE()[4]);
			txtColoniaDF.setText(getDomicilioPE()[5]);
			txtCodigoPostalDF.setText(getDomicilioPE()[6]);
			txtReferenciaDF.setText(getDomicilioPE()[7]);
			txtEntidadDF.setText(getDomicilioPE()[8]);
		}
	};

	// $$$ Syntax location
	public void sendTopMessage(String Message)
	{
		Context context = getApplicationContext();
		CharSequence text = Message;
		int duration = Toast.LENGTH_SHORT;

		Toast toast = Toast.makeText(context, text, duration);
		toast.show();
		toast.setGravity(Gravity.CENTER_HORIZONTAL | Gravity.CENTER_VERTICAL | Gravity.CENTER, 0, 0);
	}

	public String[] getDomicilioPE()
	{
		String[] arrayDomicilioPE =
		{ txtCallePE.getText().toString(), txtMunicipioPE.getText().toString(), txtPaisPE.getText().toString(), txtNumeroExtPE.getText().toString(), txtNumeroIntPE.getText().toString(), txtColoniaPE.getText().toString(), txtCodigoPostalPE.getText().toString(), txtReferenciaPE.getText().toString(), txtEntidadPE.getText().toString() };

		return arrayDomicilioPE;
	}

	public String[] getDomFiscal()
	{
		String[] arrayDomicFiscal =
		{ txtCalleDF.getText().toString(), txtMunicipioDF.getText().toString(), txtPaisDF.getText().toString(), txtNumeroExtDF.getText().toString(), txtNumeroIntDF.getText().toString(), txtColoniaDF.getText().toString(), txtCodigoPostalDF.getText().toString(), txtReferenciaDF.getText().toString(), txtEntidadDF.getText().toString() };

		return arrayDomicFiscal;
	}

	// Copy Paste Buttons end

	// ___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---

	private OnClickListener mGuardarCliente = new OnClickListener()
	{
		public void onClick(View v)
		{
			try
			{
				datoRequerido = false;
				tablaRequerido = "";
				campoRequerido = "";
				mPresenta.GuardarCliente();
			}
			catch (ControlError e)
			{
				MostrarError(e);
			}
		}
	};

	@SuppressLint("SimpleDateFormat")
	private void ActualizaFecha(Date fecha)
	{
		SimpleDateFormat formato = new SimpleDateFormat("dd/MM/yyy");
		TextView lblFecha = null;

		switch (tipoFecha)
		{
			case TipoFecha.REGISTRO:
				lblFecha = (TextView) findViewById(R.id.lblFechaRegistroCli);
				fechaRegistro = fecha;
				break;
			case TipoFecha.NACIMIENTO:
				lblFecha = (TextView) findViewById(R.id.lblFechaNacimientoCli);
				fechaNacimiento = fecha;
				break;
			/*
			 * case TipoFecha.VIGENCIA: lblFecha = (TextView)
			 * findViewById(R.id.lblVigExclusividadCli); fechaVigencia = fecha;
			 * break;
			 */
			default:
				break;
		}

		if (lblFecha != null)
			lblFecha.setText(formato.format(fecha));
	}

	private void MostrarError(ControlError e)
	{

		tablaRequerido = e.getTabla();
		campoRequerido = e.getCampo();
		datoRequerido = (!(tablaRequerido.equals("") || campoRequerido.equals("")));
		e.Mostrar(this);

	}

	@SuppressWarnings("rawtypes")
	private void SeleccionarRequerido(LinearLayout vista)
	{
		for (int i = 0; i < vista.getChildCount(); i++)
		{
			View objeto = vista.getChildAt(i);
			Class clase = objeto.getClass();
			if (clase == LinearLayout.class)
				SeleccionarHijoRequerido((LinearLayout) objeto);
			else if (objeto.getTag() != null && objeto.getTag().toString().equals(tablaRequerido + "." + campoRequerido))
			{
				objeto.setFocusable(true);
				objeto.requestFocus();
				return;
			}
		}

	}

	private void SeleccionarHijoRequerido(LinearLayout vista)
	{
		SeleccionarRequerido(vista);
	}

	private void MostrarLayout(int layout, boolean visible, int button)
	{
		try
		{
			View vwLayout = (View) findViewById(layout);
			ImageButton btHide = (ImageButton) findViewById(button);

			if (visible)
			{
				vwLayout.setVisibility(View.VISIBLE);
				btHide.setVisibility(View.INVISIBLE);
			}
			else
			{
				vwLayout.setVisibility(View.GONE);
				btHide.setVisibility(View.VISIBLE);
			}
		}
		catch (Exception e)
		{
			e.printStackTrace();
		}
	}

	private void ConfigurarLayout()
	{
		EditText texto = (EditText) findViewById(R.id.txtClave);
		texto.setEnabled(false);
		AsignarTitulos();
		OcultarLayouts();
		AsignarDefaults();
	}

	private void OcultarLayouts()
	{
		/*
		 * MostrarLayout(R.id.layFechaRegistro, false);
		 * MostrarLayout(R.id.layFechaNacimiento, false);
		 * MostrarLayout(R.id.layFechaVigencia, false);
		 */
		MostrarLayout(R.id.layGeneralesMas, false, R.id.btnGeneralesMas);
		MostrarLayout(R.id.layDomicilioPEMas, false, R.id.btnDomicilioPEMas);
		MostrarLayout(R.id.layDomicilioDFMas, false, R.id.btnDomicilioDFMas);
	}

	private void AsignarTitulos()
	{
		TextView label;
		CheckBox check;

		// Datos generales
		label = (TextView) findViewById(R.id.lblDatosGenerales);
		label.setText(Mensajes.get("XDatosGenerales"));
		label = (TextView) findViewById(R.id.lblClave);
		label.setText(Mensajes.get("XClave"));
		label = (TextView) findViewById(R.id.lblRazonSocial);
		label.setText(Mensajes.get("XRazonSocial"));
		label = (TextView) findViewById(R.id.lblRFC);
		label.setText(Mensajes.get("XRFC"));
		label = (TextView) findViewById(R.id.lblNombre);
		label.setText(Mensajes.get("XNombre"));
		label = (TextView) findViewById(R.id.lblCodigoBarras);
		label.setText(Mensajes.get("XCodigodeBarras"));
		label = (TextView) findViewById(R.id.lblFechaRegistro);
		label.setText(Mensajes.get("CLIFechaRegistroSistema"));
		label = (TextView) findViewById(R.id.lblFechaNacimiento);
		label.setText(Mensajes.get("CLIFechaNacimiento"));
		label = (TextView) findViewById(R.id.lblContacto);
		label.setText(Mensajes.get("XContacto"));
		label = (TextView) findViewById(R.id.lblTelefono);
		label.setText(Mensajes.get("XTelefono"));
		label = (TextView) findViewById(R.id.lblDatosExtra);
		label.setText(Mensajes.get("CLIDatosExtra"));
		check = (CheckBox) findViewById(R.id.chkExigirOrdenCompra);
		check.setText(Mensajes.get("CLIExigirOrdenCompra"));
		check = (CheckBox) findViewById(R.id.chkDesgloseImpuestos);
		check.setText(Mensajes.get("XDesglosaImpuestos"));

		// Punto de Entrega
		label = (TextView) findViewById(R.id.lblDomicilio);
		label.setText(Mensajes.get("XDomicilio"));
		label = (TextView) findViewById(R.id.lblPuntoEntrega);
		label.setText(Mensajes.get("XVisita"));
		label = (TextView) findViewById(R.id.lblCallePE);
		label.setText(Mensajes.get("XCalle"));
		label = (TextView) findViewById(R.id.lblMunicipioPE);
		label.setText(Mensajes.get("XMunicipio"));
		label = (TextView) findViewById(R.id.lblPaisPE);
		label.setText(Mensajes.get("XPais"));
		label = (TextView) findViewById(R.id.lblNumeroExtPE);
		label.setText(Mensajes.get("COMNumeroExt"));
		label = (TextView) findViewById(R.id.lblNumeroIntPE);
		label.setText(Mensajes.get("COMNumeroInt"));
		label = (TextView) findViewById(R.id.lblColoniaPE);
		label.setText(Mensajes.get("XColonia"));
		label = (TextView) findViewById(R.id.lblCodigoPostalPE);
		label.setText(Mensajes.get("XCodigoPostal"));
		label = (TextView) findViewById(R.id.lblReferenciaPE);
		label.setText(Mensajes.get("XReferencia"));
		label = (TextView) findViewById(R.id.lblEntidadPE);
		label.setText(Mensajes.get("XEntidad"));

		// Punto de Entrega
		label = (TextView) findViewById(R.id.lblDomicilioFiscal);
		label.setText(Mensajes.get("XDomFiscal"));
		label = (TextView) findViewById(R.id.lblCalleDF);
		label.setText(Mensajes.get("XCalle"));
		label = (TextView) findViewById(R.id.lblMunicipioDF);
		label.setText(Mensajes.get("XMunicipio"));
		label = (TextView) findViewById(R.id.lblPaisDF);
		label.setText(Mensajes.get("XPais"));
		label = (TextView) findViewById(R.id.lblNumeroExtDF);
		label.setText(Mensajes.get("COMNumeroExt"));
		label = (TextView) findViewById(R.id.lblNumeroIntDF);
		label.setText(Mensajes.get("COMNumeroInt"));
		label = (TextView) findViewById(R.id.lblColoniaDF);
		label.setText(Mensajes.get("XColonia"));
		label = (TextView) findViewById(R.id.lblCodigoPostalDF);
		label.setText(Mensajes.get("XCodigoPostal"));
		label = (TextView) findViewById(R.id.lblReferenciaDF);
		label.setText(Mensajes.get("XReferencia"));
		label = (TextView) findViewById(R.id.lblEntidadDF);
		label.setText(Mensajes.get("XEntidad"));

		// Configuracion
		/*
		 * label = (TextView) findViewById(R.id.lblConfiguracion);
		 * label.setText(Mensajes.get("XConfiguracion")); check = (CheckBox)
		 * findViewById(R.id.chkPrestamoEnvase);
		 * check.setText(Mensajes.get("XPrestamoEnvase")); check = (CheckBox)
		 * findViewById(R.id.chkExclusividad);
		 * check.setText(Mensajes.get("CLIExclusividad")); label = (TextView)
		 * findViewById(R.id.lblVigExclusividad);
		 * label.setText(Mensajes.get("XVigenciaExclusividad"));
		 */

		Button boton = (Button) findViewById(R.id.btnContinuar);
		boton.setText(Mensajes.get("BTContinuar"));

	}

	private void AsignarDefaults()
	{
		TextView lblFechaRegistro = (TextView) findViewById(R.id.lblFechaRegistroCli);
		TextView lblFechaNacimiento = (TextView) findViewById(R.id.lblFechaNacimientoCli);
		// TextView lblVigExclusividad = (TextView)
		// findViewById(R.id.lblVigExclusividadCli);

		lblFechaRegistro.setText(Generales.getFechaActualStr());
		lblFechaNacimiento.setText(lblFechaRegistro.getText());
		// lblVigExclusividad.setText(lblFechaRegistro.getText());

		fechaRegistro = Generales.getFechaActual();
		fechaNacimiento = fechaRegistro;
		fechaVigencia = fechaRegistro;
	}

	public String getClave()
	{
		EditText texto = (EditText) findViewById(R.id.txtClave);
		return (texto.getText().toString().equals("") ? null : texto.getText().toString());
	}

	public String getRazonSocial()
	{
		EditText texto = (EditText) findViewById(R.id.txtRazonSocial);
		return (texto.getText().toString().equals("") ? null : texto.getText().toString());
	}

	public String getRFC()
	{
		EditText texto = (EditText) findViewById(R.id.txtRFC);
		return (texto.getText().toString().equals("") ? null : texto.getText().toString());
	}

	public String getNombre()
	{
		EditText texto = (EditText) findViewById(R.id.txtNombre);
		return (texto.getText().toString().equals("") ? null : texto.getText().toString());
	}

	public String getCodigoBarras()
	{
		EditText texto = (EditText) findViewById(R.id.txtCodigoBarras);
		return (texto.getText().toString().equals("") ? null : texto.getText().toString());
	}

	public Date getFechaRegistro()
	{
		return fechaRegistro;
	}

	public Date getFechaNacimiento()
	{
		return fechaNacimiento;
	}

	public String getContacto()
	{
		EditText texto = (EditText) findViewById(R.id.txtContacto);
		return (texto.getText().toString().equals("") ? null : texto.getText().toString());
	}

	public String getTelefono()
	{
		EditText texto = (EditText) findViewById(R.id.txtTelefono);
		return (texto.getText().toString().equals("") ? null : texto.getText().toString());
	}

	public String getDatosExtra()
	{
		EditText texto = (EditText) findViewById(R.id.txtDatosExtra);
		return (texto.getText().toString().equals("") ? null : texto.getText().toString());
	}

	public boolean getExigirOrdenCompra()
	{
		CheckBox check = (CheckBox) findViewById(R.id.chkExigirOrdenCompra);
		return check.isChecked();
	}

	public boolean getDesglosaImpuestos()
	{
		CheckBox check = (CheckBox) findViewById(R.id.chkDesgloseImpuestos);
		return check.isChecked();
	}

	public String getCallePE()
	{
		EditText texto = (EditText) findViewById(R.id.txtCallePE);
		return (texto.getText().toString().equals("") ? null : texto.getText().toString());
	}

	public String getMunicipioPE()
	{
		EditText texto = (EditText) findViewById(R.id.txtMunicipioPE);
		return (texto.getText().toString().equals("") ? null : texto.getText().toString());
	}

	public String getPaisPE()
	{
		EditText texto = (EditText) findViewById(R.id.txtPaisPE);
		return (texto.getText().toString().equals("") ? null : texto.getText().toString());
	}

	public String getNumeroExtPE()
	{
		EditText texto = (EditText) findViewById(R.id.txtNumeroExtPE);
		return (texto.getText().toString().equals("") ? null : texto.getText().toString());
	}

	public String getNumeroIntPE()
	{
		EditText texto = (EditText) findViewById(R.id.txtNumeroIntPE);
		return (texto.getText().toString().equals("") ? null : texto.getText().toString());
	}

	public String getColoniaPE()
	{
		EditText texto = (EditText) findViewById(R.id.txtColoniaPE);
		return (texto.getText().toString().equals("") ? null : texto.getText().toString());
	}

	public String getCodigoPostalPE()
	{
		EditText texto = (EditText) findViewById(R.id.txtCodigoPostalPE);
		return (texto.getText().toString().equals("") ? null : texto.getText().toString());
	}

	public String getReferenciaPE()
	{
		EditText texto = (EditText) findViewById(R.id.txtReferenciaPE);
		return (texto.getText().toString().equals("") ? null : texto.getText().toString());
	}

	public String getEntidadPE()
	{
		EditText texto = (EditText) findViewById(R.id.txtEntidadPE);
		return (texto.getText().toString().equals("") ? null : texto.getText().toString());
	}

	public String getCalleDF()
	{
		EditText texto = (EditText) findViewById(R.id.txtCalleDF);
		return (texto.getText().toString().equals("") ? null : texto.getText().toString());
	}

	public String getMunicipioDF()
	{
		EditText texto = (EditText) findViewById(R.id.txtMunicipioDF);
		return (texto.getText().toString().equals("") ? null : texto.getText().toString());
	}

	public String getPaisDF()
	{
		EditText texto = (EditText) findViewById(R.id.txtPaisDF);
		return (texto.getText().toString().equals("") ? null : texto.getText().toString());
	}

	public String getNumeroExtDF()
	{
		EditText texto = (EditText) findViewById(R.id.txtNumeroExtDF);
		return (texto.getText().toString().equals("") ? null : texto.getText().toString());
	}

	public String getNumeroIntDF()
	{
		EditText texto = (EditText) findViewById(R.id.txtNumeroIntDF);
		return (texto.getText().toString().equals("") ? null : texto.getText().toString());
	}

	public String getColoniaDF()
	{
		EditText texto = (EditText) findViewById(R.id.txtColoniaDF);
		return (texto.getText().toString().equals("") ? null : texto.getText().toString());
	}

	public String getCodigoPostalDF()
	{
		EditText texto = (EditText) findViewById(R.id.txtCodigoPostalDF);
		return (texto.getText().toString().equals("") ? null : texto.getText().toString());
	}

	public String getReferenciaDF()
	{
		EditText texto = (EditText) findViewById(R.id.txtReferenciaDF);
		return (texto.getText().toString().equals("") ? null : texto.getText().toString());
	}

	public String getEntidadDF()
	{
		EditText texto = (EditText) findViewById(R.id.txtEntidadDF);
		return (texto.getText().toString().equals("") ? null : texto.getText().toString());
	}

	/*
	 * public boolean getPrestamoEnvase() { CheckBox check = (CheckBox)
	 * findViewById(R.id.chkPrestamoEnvase); return check.isChecked(); }
	 * 
	 * public boolean getExclusividad() { CheckBox check = (CheckBox)
	 * findViewById(R.id.chkExclusividad); return check.isChecked(); }
	 */

	public Date getVigExclusividad()
	{
		return fechaVigencia;
	}

	public void setClave(String clave)
	{
		EditText texto = (EditText) findViewById(R.id.txtClave);
		texto.setText(clave);
	}

	public boolean getCapturoDomFiscal()
	{
		if (getCalleDF() != null || getMunicipioDF() != null || getPaisDF() != null || getNumeroExtDF() != null || getNumeroIntDF() != null || getColoniaDF() != null || getCodigoPostalDF() != null || getReferenciaDF() != null || getEntidadDF() != null)
			return true;
		return false;
	}

	public boolean getCapturoPuntoEntrega()
	{
		if (getCallePE() != null || getMunicipioPE() != null || getPaisPE() != null || getNumeroExtPE() != null || getNumeroIntPE() != null || getColoniaPE() != null || getCodigoPostalPE() != null || getReferenciaPE() != null || getEntidadPE() != null)
			return true;
		return false;
	}

	@Override
	public boolean getPrestamoEnvase()
	{
		// TODO Auto-generated method stub
		return false;
	}

	@Override
	public boolean getExclusividad()
	{
		// TODO Auto-generated method stub
		return false;
	}

	@Override
	public List<String> getFrecuenciasSeleccionadas()
	{
		List<String>frecuenciasSelec = new ArrayList<String>();
		Iterator<Map.Entry<String, Boolean>> entries = frecuencias.entrySet().iterator();
		while (entries.hasNext()) {
			Map.Entry<String, Boolean> entry = entries.next();
			if (entry.getValue()){
				frecuenciasSelec.add(entry.getKey());
			}
		}
		return frecuenciasSelec;
	}

	@Override
	public HashMap<String,Integer> getSecuenciaOrden()
	{
		return secuenciaOrden;
	}

	public static void setListViewHeightBasedOnChildren(ListView listView) {
		SimpleCursorAdapter listAdapter = (SimpleCursorAdapter) listView.getAdapter();
		if (listAdapter == null)
			return;

		int desiredWidth = View.MeasureSpec.makeMeasureSpec(listView.getWidth(), View.MeasureSpec.UNSPECIFIED);
		int totalHeight = 0;
		View view = null;
		int max = listAdapter.getCount();
		//if (max >5) max = 5;
		for (int i = 0; i < max; i++) {
			view = listAdapter.getView(i, view, listView);
			if (i == 0)
				view.setLayoutParams(new ViewGroup.LayoutParams(desiredWidth, ViewGroup.LayoutParams.WRAP_CONTENT));

			view.measure(desiredWidth, View.MeasureSpec.UNSPECIFIED);
			totalHeight += view.getMeasuredHeight();
		}
		ViewGroup.LayoutParams params = listView.getLayoutParams();
		params.height = totalHeight + (listView.getDividerHeight() * (listAdapter.getCount() - 1));
		listView.setLayoutParams(params);
	}
	private class MySimpleCursorAdapter extends SimpleCursorAdapter
	{
		Cursor c;

		public MySimpleCursorAdapter(Context context, int layout, Cursor c, String[] from, int[] to)
		{
			super(context, layout, c, from, to);
			this.c = c;
		}

		@Override
		public View getView(final int pos, View v, ViewGroup parent)
		{
			v = super.getView(pos, v, parent);
			final CheckBox chb = (CheckBox) v.findViewById(R.id.chk1);
			if (!frecuencias.containsKey(c.getString(c.getColumnIndex("_id")))) {
				frecuencias.put(c.getString(c.getColumnIndex("_id")),false);
			}
			chb.setTag(c.getString(c.getColumnIndex("_id")));

			chb.setOnCheckedChangeListener(new CompoundButton.OnCheckedChangeListener()
			{
				@Override
				public void onCheckedChanged(CompoundButton check, boolean checked)
				{
					String frecuenciaClave = check.getTag().toString();
					if (frecuencias.containsKey(frecuenciaClave)){
						frecuencias.put(frecuenciaClave, checked);
					}
				}
			});

			final EditText et= (EditText) v.findViewById(R.id.txt);
			et.setFocusable(true);
			et.setSelectAllOnFocus(true);
			et.setClickable(false);
			et.setFocusableInTouchMode(true);
			et.setInputType(InputType.TYPE_CLASS_NUMBER);
			et.setKeyListener(DigitsKeyListener.getInstance("0123456789"));

			if (!secuenciaOrden.containsKey(c.getString(c.getColumnIndex("_id")))) {
				secuenciaOrden.put(c.getString(c.getColumnIndex("_id")),c.getInt(c.getColumnIndex("SigOrden")));
			}
			et.setTag(c.getString(c.getColumnIndex("_id")));

			et.setOnFocusChangeListener(new View.OnFocusChangeListener()
			{
				@Override
				public void onFocusChange(View v, boolean hasFocus)
				{
					if (!hasFocus)
					{
						EditText et = (EditText) v;

						if (et.getText().toString().equals("")){
							et.setText("1");
						}
						String frecuenciaClave = et.getTag().toString();
						if (secuenciaOrden.containsKey(frecuenciaClave)){
							if (et.getText().toString() != null) {
								secuenciaOrden.put(frecuenciaClave, Integer.parseInt(et.getText().toString()));
							}
						}
					}
					else
					{
						EditText et = (EditText) v;
						et.selectAll();
					}

				}
			});

			et.setOnTouchListener(new View.OnTouchListener()
			{

				@Override
				public boolean onTouch(View v, MotionEvent event)
				{
					v.onTouchEvent(event);
					((EditText) v).selectAll();
					return true;
				}
			});

			return v;
		}

	}
	private class vistaFrecuencias implements SimpleCursorAdapter.ViewBinder
	{

		@Override
		public boolean setViewValue(View view, Cursor cursor, int columnIndex)
		{
			int viewId = view.getId();

			switch (viewId)
			{
				case R.id.lbl2:
					TextView tituloOrden = (TextView) view;
					tituloOrden.setText(Mensajes.get("XOrdenVisita"));
					tituloOrden.setGravity(Gravity.RIGHT);
					//unidad.setTag(cursor.getInt(columnIndex));
					break;
				case R.id.lbl1:
					TextView tipo = (TextView) view;
					tipo.setText(ValoresReferencia.getDescripcion("FRETIPO", cursor.getString(cursor.getColumnIndex("Tipo"))));
					break;
				case R.id.txt:
					EditText orden = (EditText) view;
					orden.setText(cursor.getString(cursor.getColumnIndex("SigOrden")));
					break;
				default:
					TextView texto = (TextView) view;
					texto.setText(cursor.getString(columnIndex));
					break;
			}

			return true;
		}
	}
}
