package com.amesol.routelite.vistas;

import java.text.DecimalFormat;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;

import android.annotation.SuppressLint;
import android.app.DatePickerDialog;
import android.app.Dialog;
import android.content.Context;
import android.content.Intent;
import android.content.res.Resources;
import android.database.Cursor;
import android.os.Bundle;
import android.text.Editable;
import android.text.TextWatcher;
import android.util.Log;
import android.view.ContextMenu;
import android.view.ContextMenu.ContextMenuInfo;
import android.view.KeyEvent;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.view.View.OnClickListener;
import android.view.View.OnKeyListener;
import android.view.WindowManager;
import android.view.inputmethod.InputMethodManager;
import android.widget.AdapterView;
import android.widget.AdapterView.OnItemClickListener;
import android.widget.AdapterView.OnItemLongClickListener;
import android.widget.AdapterView.OnItemSelectedListener;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.DatePicker;
import android.widget.EditText;
import android.widget.ImageButton;
import android.widget.ListView;
import android.widget.SimpleCursorAdapter;
import android.widget.SimpleCursorAdapter.ViewBinder;
import android.widget.Spinner;
import android.widget.TabHost;
import android.widget.TabHost.OnTabChangeListener;
import android.widget.TextView;

import com.amesol.routelite.R;
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.actividades.ValoresReferencia;
import com.amesol.routelite.datos.PLBPLE;
import com.amesol.routelite.datos.basedatos.BDVend;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.Enumeradores.RespuestaMsg;
import com.amesol.routelite.presentadores.act.CapturarPreLiquidacion;
import com.amesol.routelite.presentadores.interfaces.ICapturaPreLiquidacion;
import com.amesol.routelite.utilerias.Constants;
import com.amesol.routelite.utilerias.Generales;

public class CapturaPreLiquidacion extends Vista implements ICapturaPreLiquidacion
{

	CapturarPreLiquidacion mPresenta;
	private String mAccion;
	private boolean esNuevo = true;
	private boolean soloLectura = true;
	private boolean hayProductos = false;
	private ListView mLvEfectivo = null;
	private ListView mLvDeposito = null;
	private Spinner mSpTipo = null;
	private Spinner mSpDenomi = null;
	private EditText mTotal = null;
	private EditText txtCantidad = null;
	private Spinner spBanco = null;
	private boolean hayError = false;
	private boolean isEfectivo = false;
	private Cursor transacciones = null;
	private TextView txtFecha = null;
	private EditText txtReferencia = null;
	private EditText txtTotalDep = null;
	private EditText txtFicha = null;
	private String sPBEId = "";
	static final int DATE_DIALOG_ID = 0;
	short tipoFecha;
	Date fecha = null;
	private int Position = 0;

	@Override
	public void onCreate(Bundle savedInstanceState)
	{
		super.onCreate(savedInstanceState);
		setContentView(R.layout.captura_pre_liquidacion);
		//		deshabilitarBarra(true);

		getWindow().setSoftInputMode(WindowManager.LayoutParams.SOFT_INPUT_STATE_ALWAYS_HIDDEN);
		mAccion = getIntent().getAction();
		lblTitle.setText("Pre-Liquidacion");
		mPresenta = new CapturarPreLiquidacion(this, mAccion);

		mLvEfectivo = (ListView) findViewById(R.id.lv_efectivo);
		mLvDeposito = (ListView) findViewById(R.id.lv_deposito);
		registerForContextMenu(mLvEfectivo);
		registerForContextMenu(mLvDeposito);
		mLvEfectivo.setOnItemLongClickListener(menuEf);
		mLvDeposito.setOnItemLongClickListener(menuDep);

		TextView texto = (TextView) findViewById(R.id.lblFechaPre);
		texto.setText(Mensajes.get("XFechaPreLiquidacion"));
		texto = (TextView) findViewById(R.id.lblTotalaDeposito);
		texto.setText(Mensajes.get("XTotalDepositar"));
		texto = (TextView) findViewById(R.id.lblTotalEfectivo);
		texto.setText(Mensajes.get("XTotalEfectivo"));
		texto = (TextView) findViewById(R.id.lblTotalDepositos);
		texto.setText(Mensajes.get("XTOTALDEPOSITOS"));
		texto = (TextView) findViewById(R.id.lblTipo);
		texto.setText(Mensajes.get("XTipo"));
		texto = (TextView) findViewById(R.id.lblDenominacion);
		texto.setText(Mensajes.get("XDenominacion"));
		texto = (TextView) findViewById(R.id.lblCantidad);
		texto.setText(Mensajes.get("XCantidad"));
		texto = (TextView) findViewById(R.id.lblTotal);
		texto.setText(Mensajes.get("XTotal"));
 
		mTotal = (EditText) findViewById(R.id.txtTotal);
		mSpDenomi = (Spinner) findViewById(R.id.spDenominacion);
		mSpTipo = (Spinner) findViewById(R.id.spTipo);
		txtCantidad = (EditText) findViewById(R.id.txtCantidad);
		txtFecha = (TextView) findViewById(R.id.txtFecha);
		txtFecha.setOnClickListener(mExpandirFechaRegistro);
		txtReferencia = (EditText) findViewById(R.id.txtReferencia);
		txtTotalDep = (EditText) findViewById(R.id.txtTotalDep);
		txtFicha = (EditText) findViewById(R.id.txtFicha);
		ImageButton mAgregarEf = (ImageButton) findViewById(R.id.btnAgregarEfectivo);
		mAgregarEf.setOnClickListener(new OnClickListener()
		{

			@Override
			public void onClick(View v)
			{
				if (mSpTipo.getSelectedItemPosition() == 0)
				{
					mostrarError(Mensajes.get("BE0001").replace("$0$", "Tipo"));
					return;
				}

				try
				{
					if (Float.parseFloat(txtCantidad.getText().toString()) > 0)
					{
						soloLectura = false;
						if (esNuevo)
						{
							PLBPLE mPLBPLE = Consultas.ConsultaPreLiquidacion.obtenerPreLiquidacionUnidad(mPresenta.PLIId(), String.valueOf(mSpDenomi.getSelectedItemId()));
							if (mPLBPLE == null)
								mPresenta.AgregarEfectivo(mSpTipo.getSelectedItemPosition(), "", String.valueOf(mSpDenomi.getSelectedItemId()), Float.parseFloat(mTotal.getText().toString().replace("$", "").trim()), esNuevo);
							else
							{
								mPresenta.eliminarDetalle(mPLBPLE.PLIId, sPBEId);
								mPresenta.AgregarEfectivo(mSpTipo.getSelectedItemPosition(), sPBEId, String.valueOf(mSpDenomi.getSelectedItemId()), Float.parseFloat(mTotal.getText().toString().replace("$", "").trim()), esNuevo);
								esNuevo = true;
							}
						}
						else
						{
							mPresenta.eliminarDetalle(transacciones.getString(transacciones.getColumnIndex("_id")),sPBEId);
							mPresenta.AgregarEfectivo(mSpTipo.getSelectedItemPosition(), sPBEId, String.valueOf(mSpDenomi.getSelectedItemId()), Float.parseFloat(mTotal.getText().toString().replace("$", "").trim()), esNuevo);
							esNuevo = true;
						}
						HideKeyboard();
						mSpTipo.setEnabled(true);
					}
					else
						mostrarError(Mensajes.get("E0334").replace("$0$", "Cantidad"));
				}
				catch (Throwable e)
				{
					mostrarError(Mensajes.get("E0334").replace("$0$", "Cantidad"));
				}

			}
		});
		ImageButton mAgregarDep = (ImageButton) findViewById(R.id.btnAgregarDeposito);
		mAgregarDep.setOnClickListener(new OnClickListener()
		{
			@Override
			public void onClick(View v)
			{
				if (txtFecha.getText().toString().equals(""))
				{
					mostrarError(Mensajes.get("BE0001").replace("$0$", "Fecha"));
					return;
				}
				if (txtReferencia.getText().toString().equals(""))
				{
					mostrarError(Mensajes.get("BE0001").replace("$0$", "Referencia"));
					return;
				}
				if (txtTotalDep.getText().toString().equals(""))
				{
					mostrarError(Mensajes.get("BE0001").replace("$0$", "Total"));
					return;
				}
				if (txtFicha.getText().toString().equals(""))
				{
					mostrarError(Mensajes.get("BE0001").replace("$0$", "Ficha"));
					return;
				}
				if (spBanco.getSelectedItemPosition() == 0)
				{
					mostrarError(Mensajes.get("BE0001").replace("$0$", "Banco"));
					return;
				}
				if (Double.parseDouble(txtTotalDep.getText().toString()) > 0)
				{
					soloLectura = false;
					if (esNuevo)
						mPresenta.AgregarDeposito(txtFecha.getText().toString(), "", String.valueOf(spBanco.getSelectedItemId()), txtReferencia.getText().toString(), txtTotalDep.getText().toString(), txtFicha.getText().toString());
					else
					{
						mPresenta.eliminarDetalle(transacciones.getString(transacciones.getColumnIndex("_id")), transacciones.getString(transacciones.getColumnIndex("PBEId")));
						mPresenta.AgregarDeposito(txtFecha.getText().toString(), "", String.valueOf(spBanco.getSelectedItemId()), txtReferencia.getText().toString(), txtTotalDep.getText().toString(), txtFicha.getText().toString());
						esNuevo = true;
					}
					HideKeyboard();
				}
				else
					mostrarError(Mensajes.get("E0334").replace("$0$", "Total"));

			}
		});
		Button boton = (Button) findViewById(R.id.btnContinuar);
		boton.setText(Mensajes.get("XContinuar"));
		boton.setOnClickListener(mContinuar);

		Resources res = getResources();

		TabHost tabs = (TabHost) findViewById(android.R.id.tabhost);
		tabs.setup();

		TabHost.TabSpec spec = tabs.newTabSpec("Efectivo");
		spec.setContent(R.id.tab1);
		spec.setIndicator("Efectivo",
				res.getDrawable(android.R.drawable.ic_btn_speak_now));
		tabs.addTab(spec);

		spec = tabs.newTabSpec("Deposito");
		spec.setContent(R.id.tab2);
		spec.setIndicator("Deposito",
				res.getDrawable(android.R.drawable.ic_dialog_map));
		tabs.addTab(spec);
		tabs.setCurrentTabByTag("Efectivo");

		tabs.setOnTabChangedListener(new OnTabChangeListener()
		{
			@SuppressLint("SimpleDateFormat")
			@Override
			public void onTabChanged(String tabId)
			{
				if (tabId.equals("Efectivo"))
				{
					CargarEfectivo();
				}
				else if (tabId.equals("Deposito"))
				{
					try
					{
						TextView texto = (TextView) findViewById(R.id.lblFecha);
						texto.setText(Mensajes.get("XFecha"));
						texto = (TextView) findViewById(R.id.lblBanco);
						texto.setText(Mensajes.get("XBanco"));
						texto = (TextView) findViewById(R.id.lblReferencia);
						texto.setText(Mensajes.get("XReferencia"));
						texto = (TextView) findViewById(R.id.lblTotalDep);
						texto.setText("Total");
						texto = (TextView) findViewById(R.id.lblFicha);
						texto.setText(Mensajes.get("XFicha"));
						spBanco = (Spinner) findViewById(R.id.spBanco);
						ISetDatos valores = Consultas.ConsultasValorReferencia.obtenerValores("TBANCO", null);
						llenarSpinerBanco(spBanco, valores);
						SimpleDateFormat format = new SimpleDateFormat("dd/MM/yyyy");
						TextView etDate = (TextView) findViewById(R.id.txtFecha);
						etDate.setText(format.format(new Date()));
					}
					catch (Exception e)
					{
						e.printStackTrace();
					}

				}
			}
		});

		txtCantidad.setOnKeyListener(new OnKeyListener()
		{
			@Override
			public boolean onKey(View v, int keyCode, KeyEvent event)
			{
				if (event.getAction() == KeyEvent.ACTION_UP)
				{
					if (keyCode == KeyEvent.KEYCODE_ENTER)
					{
						if (mSpTipo.getSelectedItemPosition() == 0)
						{
							mostrarError(Mensajes.get("BE0001").replace("$0$", "Tipo"));
							return false;
						}

						try
						{
							if (Integer.parseInt(txtCantidad.getText().toString()) > 0)
							{
								soloLectura = false;
								if (esNuevo)
								{
									PLBPLE mPLBPLE = Consultas.ConsultaPreLiquidacion.obtenerPreLiquidacionUnidad(mPresenta.PLIId(), String.valueOf(mSpDenomi.getSelectedItemId()));
									if (mPLBPLE == null)
										mPresenta.AgregarEfectivo(mSpTipo.getSelectedItemPosition(), "", String.valueOf(mSpDenomi.getSelectedItemId()), Float.parseFloat(mTotal.getText().toString().replace("$", "").trim()), esNuevo);
									else
									{
										mPresenta.eliminarDetalle(mPLBPLE.PLIId, mPLBPLE.PBEId);
										mPresenta.AgregarEfectivo(mSpTipo.getSelectedItemPosition(), mPLBPLE.PBEId, String.valueOf(mSpDenomi.getSelectedItemId()), Float.parseFloat(mTotal.getText().toString().replace("$", "").trim()), esNuevo);
										esNuevo = true;
									}
								}
								else
								{
									transacciones.moveToPosition(Position);
									Log.e("", "" + transacciones.getPosition());
									mPresenta.eliminarDetalle(transacciones.getString(transacciones.getColumnIndex("_id")), transacciones.getString(transacciones.getColumnIndex("PBEId")));
									mPresenta.AgregarEfectivo(mSpTipo.getSelectedItemPosition(), transacciones.getString(transacciones.getColumnIndex("PBEId")), String.valueOf(mSpDenomi.getSelectedItemId()), Float.parseFloat(mTotal.getText().toString().replace("$", "").trim()), esNuevo);
									esNuevo = true;
								}
								mSpTipo.setEnabled(true);
								HideKeyboard();
							}
							else
								mostrarError(Mensajes.get("E0334").replace("$0$", "Cantidad"));
						}
						catch (Throwable e)
						{
							mostrarError(Mensajes.get("E0334").replace("$0$", "Cantidad"));
						}
						return true;
					}
				}
				return false;
			}
		});

		txtCantidad.addTextChangedListener(new TextWatcher()
		{
			@Override
			public void afterTextChanged(Editable arg0)
			{
				try
				{
					EditText texto = (EditText) findViewById(R.id.txtCantidad);
					if (mSpTipo.getSelectedItemPosition() != 0)
						if (!mSpDenomi.getAdapter().isEmpty())
							if (!texto.getText().toString().equals(""))
							{
								float mDenominacion = Float.parseFloat(ValoresReferencia.getDescripcion("DENOMINA", String.valueOf(mSpDenomi.getSelectedItemId())));
								mDenominacion = mDenominacion * Float.parseFloat(texto.getText().toString());
								mTotal.setText("$ " + mDenominacion);
							}
							else
								mTotal.setText("");
				}
				catch (Throwable e)
				{
					mostrarError(Mensajes.get("E0334").replace("$0$", "Cantidad"));
					txtCantidad.setText("");
				}

			}

			@Override
			public void beforeTextChanged(CharSequence arg0, int arg1, int arg2, int arg3)
			{
			}

			@Override
			public void onTextChanged(CharSequence arg0, int arg1, int arg2, int arg3)
			{
			}

		});

		txtFicha.setOnKeyListener(new OnKeyListener()
		{

			@Override
			public boolean onKey(View v, int keyCode, KeyEvent event)
			{
				if (event.getAction() == KeyEvent.ACTION_UP)
				{
					if (keyCode == KeyEvent.KEYCODE_ENTER)
					{
						if (txtFecha.getText().toString().equals(""))
						{
							mostrarError(Mensajes.get("BE0001").replace("$0$", "Fecha"));
							return false;
						}
						if (txtReferencia.getText().toString().equals(""))
						{
							mostrarError(Mensajes.get("BE0001").replace("$0$", "Referencia"));
							return false;
						}
						if (txtTotalDep.getText().toString().equals(""))
						{
							mostrarError(Mensajes.get("BE0001").replace("$0$", "Total"));
							return false;
						}
						if (txtFicha.getText().toString().equals(""))
						{
							mostrarError(Mensajes.get("BE0001").replace("$0$", "Ficha"));
							return false;
						}
						if (spBanco.getSelectedItemPosition() == 0)
						{
							mostrarError(Mensajes.get("BE0001").replace("$0$", "Banco"));
							return false;
						}
						if (Integer.parseInt(txtTotalDep.getText().toString()) > 0)
						{
							soloLectura = false;
							if (esNuevo)
								mPresenta.AgregarDeposito(txtFecha.getText().toString(), "", String.valueOf(spBanco.getSelectedItemId()), txtReferencia.getText().toString(), txtTotalDep.getText().toString(), txtFicha.getText().toString());
							else
							{
								mPresenta.eliminarDetalle(transacciones.getString(transacciones.getColumnIndex("_id")), transacciones.getString(transacciones.getColumnIndex("PBEId")));
								mPresenta.AgregarDeposito(txtFecha.getText().toString(), "", String.valueOf(spBanco.getSelectedItemId()), txtReferencia.getText().toString(), txtTotalDep.getText().toString(), txtFicha.getText().toString());
								esNuevo = true;
							}
							HideKeyboard();
						}
						else
							mostrarError(Mensajes.get("E0334").replace("$0$", "Total"));

						return true;
					}
				}
				return false;
			}
		});

		CargarEfectivo();
		mPresenta.iniciar();
	}

	public void CargarEfectivo()
	{
		TextView texto = (TextView) findViewById(R.id.lblTipo);
		texto.setText(Mensajes.get("XTipo"));
		texto = (TextView) findViewById(R.id.lblDenominacion);
		texto.setText(Mensajes.get("XDenominacion"));
		texto = (TextView) findViewById(R.id.lblCantidad);
		texto.setText(Mensajes.get("XCantidad"));
		texto = (TextView) findViewById(R.id.lblTotal);
		texto.setText(Mensajes.get("XTotal"));
		ArrayList<String> mTipo = new ArrayList<String>();
		mTipo.add("<Ninguno>");
		mTipo.add("Billete");
		mTipo.add("Moneda");

		ArrayAdapter<String> adapter = new ArrayAdapter<String>(CapturaPreLiquidacion.this, android.R.layout.simple_spinner_item, mTipo);
		adapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
		mSpTipo.setOnItemSelectedListener(new OnItemSelectedListener()
		{
			@Override
			public void onItemSelected(AdapterView<?> arg0, View view, int position, long id)
			{
				mSpDenomi = (Spinner) findViewById(R.id.spDenominacion);
				try
				{
					if (esNuevo)
					{
						if (position == 0)
						{
							mSpDenomi.setEnabled(false);
							mTotal.setText("");
						}
						else
						{
							mSpDenomi.setEnabled(true);
							ISetDatos valores = Consultas.ConsultasValorReferencia.obtenerValoresPorGrupo("DENOMINA", String.valueOf(position), "", false);
							llenarSpiner(mSpDenomi, valores);
							float mDenominacion = Float.parseFloat(ValoresReferencia.getDescripcion("DENOMINA", String.valueOf(mSpDenomi.getSelectedItemId())));
							EditText texto = (EditText) findViewById(R.id.txtCantidad);
							if (!texto.getText().toString().equals(""))
							{
								mDenominacion = mDenominacion * Float.parseFloat(texto.getText().toString());
								mTotal.setText("$ " + mDenominacion);
							}
							else
							{
								mTotal.setText("");
							}
						}
					}
				}
				catch (Exception e)
				{
					e.printStackTrace();
				}
			}

			@Override
			public void onNothingSelected(AdapterView<?> arg0)
			{
			}
		});
		mSpTipo.setAdapter(adapter);

		mSpDenomi.setOnItemSelectedListener(new OnItemSelectedListener()
		{
			@Override
			public void onItemSelected(AdapterView<?> arg0, View view, int position, long id)
			{
				float mDenominacion = Float.parseFloat(ValoresReferencia.getDescripcion("DENOMINA", String.valueOf(mSpDenomi.getSelectedItemId())));
				EditText texto = (EditText) findViewById(R.id.txtCantidad);
				if (!texto.getText().toString().equals(""))
				{
					mDenominacion = mDenominacion * Float.parseFloat(texto.getText().toString());
					mTotal.setText("$ " + mDenominacion);
				}
				else
					mTotal.setText("");
			}

			@Override
			public void onNothingSelected(AdapterView<?> arg0)
			{
			}

		});
	}

	@Override
	public void iniciar()
	{
	}

	@Override
	public void resultadoActividad(int requestCode, int resultCode, Intent data)
	{
	}

	@Override
	public void respuestaMensaje(RespuestaMsg respuesta, int tipoMensaje)
	{
		if (tipoMensaje == 3)
		{
			if (respuesta == RespuestaMsg.Si)
				regresar();
		}
		else if (tipoMensaje == 0)
		{
			//Finalizar sin guardar cambios
			if (hayError)
				if (respuesta.equals(RespuestaMsg.OK))
					this.finish();
		}
		else if (tipoMensaje == 2)
		{
			if (respuesta == RespuestaMsg.Si)
			{
				if (isEfectivo)
					transacciones = (Cursor) (((SimpleCursorAdapter) mLvEfectivo.getAdapter()).getCursor());
				else
					transacciones = (Cursor) (((SimpleCursorAdapter) mLvDeposito.getAdapter()).getCursor());

				mPresenta.eliminarDetalle(transacciones.getString(transacciones.getColumnIndex("_id")), transacciones.getString(transacciones.getColumnIndex("PBEId")));
				soloLectura = false;
			}
		}

	}

	private OnClickListener mContinuar = new OnClickListener()
	{

		@Override
		public void onClick(View v)
		{
			Button boton = (Button) findViewById(R.id.btnContinuar);
			try
			{
				if (!hayProductos)
					mostrarError(Mensajes.get("MDBAsignarProducto"));
				else
				{
					if (mPresenta.validarTotal())
					{
						hayError = false;
						if (!soloLectura)
						{ // no modificar si esta solo lectura
							boton.setEnabled(false);
							mPresenta.asignarGuardarValores();

						}
						setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
						finalizar();
					}
				}
			}
			catch (Exception ex)
			{
				mostrarError(ex.getMessage());
				boton.setEnabled(true);
			}
		}

	};

	@Override
	public boolean onKeyDown(int keyCode, KeyEvent event)
	{
		switch (keyCode)
		{
			case KeyEvent.KEYCODE_BACK:
				salir();
				return true;
		}
		return super.onKeyDown(keyCode, event);
	}

	private void salir()
	{
		if (hayProductos)
			if (!soloLectura)
				mostrarPreguntaSiNo(Mensajes.get("BP0002"), 3);
			else
			{
				setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
				finalizar();
			}
		else
			regresar();
	}

	private void regresar()
	{
		try
		{
			BDVend.rollback();
			setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
			finalizar();
		}
		catch (Exception ex)
		{
			mostrarError(ex.getMessage());
		}
	}

	@SuppressWarnings("deprecation")
	@Override
	public void refrescarEfectivo(String PLIId)
	{
		try
		{
			hayProductos = true;
			ISetDatos stTransProdDetalle = Consultas.ConsultaPreLiquidacion.obtenerDetallePreLiquidacion(PLIId, true, true);
			Cursor cProductos = (Cursor) stTransProdDetalle.getOriginal();
			startManagingCursor(cProductos);
			try
			{
				SimpleCursorAdapter adapter = new SimpleCursorAdapter(this, R.layout.lista_simple_hor6, cProductos, new String[]
				{ "_id", "PBEId", "Enviado", "Total", "TipoEfectivo" }, new int[]
				{ R.id.txtCol1, R.id.txtCol2, R.id.txtCol3, R.id.txtCol4 });
				adapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
				adapter.setViewBinder(new vistaEfectivo());
				mLvEfectivo.setAdapter(adapter);
				mLvEfectivo.setOnItemClickListener(new OnItemClickListener()
				{

					public void onItemClick(AdapterView<?> arg0, View v, int pos, long arg3)
					{
						try
						{
							transacciones = (Cursor) (((SimpleCursorAdapter) mLvEfectivo.getAdapter()).getCursor());
							mLvEfectivo.requestFocusFromTouch();
							mLvEfectivo.setSelection(pos);
							esNuevo = false;
							Position = pos;
							mTotal.setText("" + transacciones.getFloat(transacciones.getColumnIndex("Total")));
							String Tipo = Consultas.ConsultasValorReferencia.obtenerGrupo("DENOMINA", transacciones.getString(transacciones.getColumnIndex("TipoEfectivo")));
							mSpTipo.setSelection(Integer.parseInt(Tipo));
							mSpTipo.setEnabled(false);
							ISetDatos valores = Consultas.ConsultasValorReferencia.obtenerValoresPorGrupo("DENOMINA", Tipo, "", false);
							llenarSpiner(mSpDenomi, valores);
							txtCantidad.setText("" + (transacciones.getFloat(transacciones.getColumnIndex("Total"))) / (Float.parseFloat(ValoresReferencia.getDescripcion("DENOMINA", transacciones.getString(transacciones.getColumnIndex("TipoEfectivo"))))));
							Generales.SelectSpinnerItemByValue(mSpDenomi, transacciones.getInt(transacciones.getColumnIndex("TipoEfectivo")));
							mSpDenomi.setEnabled(true);
							sPBEId = transacciones.getString(transacciones.getColumnIndex("PBEId"));
						}
						catch (NumberFormatException e)
						{
							e.printStackTrace();
						}
						catch (Exception e)
						{
							e.printStackTrace();
						}

					}
				}
						);

			}
			catch (Exception e)
			{
				mostrarError(e.getMessage());
			}

		}
		catch (Exception ex)
		{
			mostrarError(ex.getMessage());
		}
	}

	@SuppressWarnings("deprecation")
	public void refrescarDeposito(String PLIId)
	{
		try
		{
			hayProductos = true;
			ISetDatos stTransProdDetalle = Consultas.ConsultaPreLiquidacion.obtenerDetallePreLiquidacion(PLIId, false, true);
			Cursor cProductos = (Cursor) stTransProdDetalle.getOriginal();
			startManagingCursor(cProductos);
			try
			{
				SimpleCursorAdapter adapter = new SimpleCursorAdapter(this, R.layout.lista_simple_hor6, cProductos, new String[]
				{ "FechaDeposito", "TipoBanco", "Referencia", "Total", "Ficha" }, new int[]
				{ R.id.txtCol1, R.id.txtCol2, R.id.txtCol3, R.id.txtCol4, R.id.txtCol5 });
				adapter.setViewBinder(new vistaDeposito());
				mLvDeposito.setAdapter(adapter);

				mLvDeposito.setOnItemClickListener(new OnItemClickListener()
				{

					public void onItemClick(AdapterView<?> arg0, View v, int pos, long arg3)
					{
						transacciones = (Cursor) (((SimpleCursorAdapter) mLvDeposito.getAdapter()).getCursor());
						mLvDeposito.requestFocusFromTouch();
						mLvDeposito.setSelection(pos);
						esNuevo = false;

						txtTotalDep.setText("" + transacciones.getFloat(transacciones.getColumnIndex("Total")));
						txtFecha.setText(transacciones.getString(transacciones.getColumnIndex("FechaDeposito")).replace(" 00:00:00", "").replace("-", "/"));
						txtFicha.setText(transacciones.getString(transacciones.getColumnIndex("Ficha")));
						txtReferencia.setText(transacciones.getString(transacciones.getColumnIndex("Referencia")));
						Generales.SelectSpinnerItemByValue(spBanco, transacciones.getInt(transacciones.getColumnIndex("TipoBanco")));

					}
				}
						);

			}
			catch (Exception e)
			{
				mostrarError(e.getMessage());
			}

		}
		catch (Exception ex)
		{
			mostrarError(ex.getMessage());
		}
	}

	private class vistaEfectivo implements ViewBinder
	{

		@Override
		public boolean setViewValue(View view, Cursor cursor, int columnIndex)
		{
			int viewId = view.getId();
			switch (viewId)
			{
				case R.id.txtCol1: // para llenar el combo	
					TextView combo = (TextView) view;
					try
					{
						if (Consultas.ConsultasValorReferencia.obtenerGrupo("DENOMINA", cursor.getString(cursor.getColumnIndex("TipoEfectivo"))).equals("1"))
							combo.setText("Billete");
						else
							combo.setText("Moneda");
					}
					catch (Exception e)
					{
						e.printStackTrace();
					}

					break;
				case R.id.txtCol2: // para llenar el combo
					combo = (TextView) view;
					String mCantidad = ValoresReferencia.getDescripcion("DENOMINA", cursor.getString(cursor.getColumnIndex("TipoEfectivo")));
					combo.setText(mCantidad);
					break;
				case R.id.txtCol3: // para llenar el combo	
					combo = (TextView) view;
					Float mTotal = (cursor.getFloat(cursor.getColumnIndex("Total"))) / (Float.parseFloat(ValoresReferencia.getDescripcion("DENOMINA", cursor.getString(cursor.getColumnIndex("TipoEfectivo")))));
					combo.setText("" + mTotal);
					break;
				case R.id.txtCol4: // para llenar el combo	
					combo = (TextView) view;
					combo.setText(cursor.getString(cursor.getColumnIndex("Total")));
					break;

				default:
					TextView texto = (TextView) view;
					texto.setText(cursor.getString(columnIndex));
					break;
			}
			return true;
		}
	}

	private class vistaDeposito implements ViewBinder
	{

		@Override
		public boolean setViewValue(View view, Cursor cursor, int columnIndex)
		{
			int viewId = view.getId();
			switch (viewId)
			{
				case R.id.txtCol1:
					TextView combo = (TextView) view;
					combo.setText(cursor.getString(cursor.getColumnIndex("FechaDeposito")));
					break;
				case R.id.txtCol2:
					combo = (TextView) view;
					String mCantidad = ValoresReferencia.getDescripcion("TBANCO", cursor.getString(cursor.getColumnIndex("TipoBanco")));
					combo.setText(mCantidad);
					break;
				case R.id.txtCol3:
					combo = (TextView) view;
					combo.setText(cursor.getString(cursor.getColumnIndex("Referencia")));
					break;
				case R.id.txtCol4:
					combo = (TextView) view;
					combo.setText(cursor.getString(cursor.getColumnIndex("Total")));
					break;
				case R.id.txtCol5:
					combo = (TextView) view;
					view.setVisibility(View.VISIBLE);
					combo.setText(cursor.getString(cursor.getColumnIndex("Ficha")));
					break;
				default:
					TextView texto = (TextView) view;
					texto.setText(cursor.getString(columnIndex));
					break;
			}
			return true;
		}
	}

	private class llenarSpinner implements ViewBinder
	{

		@Override
		public boolean setViewValue(View view, Cursor cursor, int columnIndex)
		{
			int viewId = view.getId();
			switch (viewId)
			{
				case android.R.id.text1: // para llenar el combo de la unidad
					TextView combo = (TextView) view;
					combo.setText(ValoresReferencia.getDescripcion("DENOMINA", cursor.getString(cursor.getColumnIndex("suggest_intent_data"))));
					break;
				default:
					TextView texto = (TextView) view;
					texto.setText(cursor.getString(columnIndex));
					break;
			}
			return true;
		}
	}

	@Override
	public void llenarValores(String Fecha, String Total)
	{

		TextView texto = (TextView) findViewById(R.id.lblFechaPreRow);
		texto.setText(Fecha.replace(" 00:00:00", ""));
		texto = (TextView) findViewById(R.id.lblTotalaDepositoRow);
		texto.setText(Generales.getFormatoDecimal(Double.parseDouble(Total), 2) );

	}

	@Override
	public void setTotales(float Efectivo, float Deposito)
	{
		double mTotalRow = 0;
		TextView txtTotalE = (TextView) findViewById(R.id.lblTotalEfectivoRow);
		TextView txtTotalD = (TextView) findViewById(R.id.lblTotalDepositosRow);
		if (Efectivo != 0.0)
		{
			mTotalRow = Efectivo;
			txtTotalE.setText(Constants.SIMBOLOMONEDA + Generales.getFormatoDecimal(mTotalRow, 2));
		}
		else
		{
			txtTotalE.setText("$ 0.00");
		}
		mTotalRow = 0;
		if (Deposito != 0.0)
		{
			mTotalRow = Deposito;
			txtTotalD.setText(Constants.SIMBOLOMONEDA + Generales.getFormatoDecimal(mTotalRow, 2));
		}
		else
		{
			txtTotalD.setText("$ 0.00");
		}

	}


	@SuppressWarnings("deprecation")
	public void llenarSpiner(Spinner control, ISetDatos valores)
	{

		try
		{

			Cursor unidad = (Cursor) valores.getOriginal();
			startManagingCursor(unidad);
			SimpleCursorAdapter adapter = new SimpleCursorAdapter(CapturaPreLiquidacion.this, android.R.layout.simple_spinner_item, unidad, new String[]
			{ "suggest_intent_data" }, new int[]
			{ android.R.id.text1 });
			adapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
			adapter.setViewBinder(new llenarSpinner());
			control.setAdapter(adapter);
		}
		catch (Exception e)
		{

			e.printStackTrace();
		}

	}

	private class llenarSpinnerBanco implements ViewBinder
	{

		@Override
		public boolean setViewValue(View view, Cursor cursor, int columnIndex)
		{
			int viewId = view.getId();
			switch (viewId)
			{
				case android.R.id.text1: // para llenar el combo de la unidad
					TextView combo = (TextView) view;
					combo.setText(ValoresReferencia.getDescripcion("TBANCO", cursor.getString(cursor.getColumnIndex("VAVClave"))));
					break;
				default:
					TextView texto = (TextView) view;
					texto.setText(cursor.getString(columnIndex));
					break;
			}
			return true;
		}
	}

	@SuppressWarnings("deprecation")
	public void llenarSpinerBanco(Spinner control, ISetDatos valores)
	{

		try
		{

			Cursor unidad = (Cursor) valores.getOriginal();
			startManagingCursor(unidad);
			SimpleCursorAdapter adapter = new SimpleCursorAdapter(CapturaPreLiquidacion.this, android.R.layout.simple_spinner_item, unidad, new String[]
			{ "VAVClave" }, new int[]
			{ android.R.id.text1 });
			adapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
			adapter.setViewBinder(new llenarSpinnerBanco());
			control.setAdapter(adapter);
		}
		catch (Exception e)
		{

			e.printStackTrace();
		}

	}

	public void setLimpiarEfectivo()
	{
		if (mSpDenomi.getAdapter() != null)
		{
			((SimpleCursorAdapter) mSpDenomi.getAdapter()).getCursor().close();
		}
		esNuevo = true;
		mSpTipo.setSelection(0);
		mSpTipo.setEnabled(true);
		mSpDenomi.setEnabled(false);
		mSpDenomi.setSelection(0);
		mTotal.setText("");
		txtCantidad.setText("");

	}

	@SuppressLint("SimpleDateFormat")
	@Override
	public void setLimpiarDeposito()
	{
		SimpleDateFormat format = new SimpleDateFormat("dd/MM/yyyy");
		spBanco.setSelection(0);
		txtFecha.setText(format.format(new Date()));
		txtReferencia.setText("");
		txtTotalDep.setText("");
		txtFicha.setText("");

	}

	@Override
	public void setError(boolean isError)
	{
		hayError = isError;

	}

	public OnItemLongClickListener menuEf = new OnItemLongClickListener()
	{

		@Override
		public boolean onItemLongClick(AdapterView<?> arg0, View arg1, int arg2, long arg3)
		{
			isEfectivo = true;
			openContextMenu(mLvEfectivo);
			return true;
		}
	};

	public OnItemLongClickListener menuDep = new OnItemLongClickListener()
	{

		@Override
		public boolean onItemLongClick(AdapterView<?> arg0, View arg1, int arg2, long arg3)
		{
			isEfectivo = false;
			openContextMenu(mLvDeposito);
			return true;
		}
	};

	private OnClickListener mExpandirFechaRegistro = new OnClickListener()
	{
		@SuppressWarnings("deprecation")
		public void onClick(View v)
		{
			showDialog(DATE_DIALOG_ID, null);
		}
	};

	private DatePickerDialog.OnDateSetListener mDateSetListener = new DatePickerDialog.OnDateSetListener()
	{
		@SuppressWarnings("deprecation")
		public void onDateSet(DatePicker view, int year, int monthOfYear, int dayOfMonth)
		{
			Date fecha = new Date(year - 1900, monthOfYear, dayOfMonth);
			ActualizaFecha(fecha);

		}
	};

	@Override
	public void onCreateContextMenu(ContextMenu menu, View v, ContextMenuInfo menuInfo)
	{
		super.onCreateContextMenu(menu, v, menuInfo);
		MenuInflater inflater = getMenuInflater();
		inflater.inflate(R.menu.context_transaccion_detalle, menu);
		menu.getItem(0).setTitle(Mensajes.get("XEliminar"));
	}

	@Override
	public boolean onContextItemSelected(MenuItem item)
	{
		mostrarPreguntaSiNo(Mensajes.get("P0112").replace("$0$", "registro"), 2);
		return true;
	}

	@SuppressLint("SimpleDateFormat")
	private void ActualizaFecha(Date fecha)
	{
		this.fecha = fecha;
		SimpleDateFormat formato = new SimpleDateFormat("dd/MM/yyy");
		txtFecha.setText(formato.format(fecha));
	}

	@SuppressWarnings("deprecation")
	@Override
	protected Dialog onCreateDialog(int id)
	{

		if (fecha == null)
			fecha = new Date();
		return new DatePickerDialog(this, mDateSetListener, fecha.getYear() + 1900, fecha.getMonth(), fecha.getDate());
	}

	public void HideKeyboard()
	{
		InputMethodManager inputManager =
				(InputMethodManager) CapturaPreLiquidacion.this.
						getSystemService(Context.INPUT_METHOD_SERVICE);
		inputManager.hideSoftInputFromWindow(
				CapturaPreLiquidacion.this.getCurrentFocus().getWindowToken(),
				InputMethodManager.HIDE_NOT_ALWAYS);
	}

}
