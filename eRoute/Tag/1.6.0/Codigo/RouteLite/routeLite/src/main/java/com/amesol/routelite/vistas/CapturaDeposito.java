package com.amesol.routelite.vistas;

import java.text.SimpleDateFormat;
import java.util.Date;

import android.annotation.SuppressLint;
import android.content.Intent;
import android.database.Cursor;
import android.os.Bundle;
import android.text.Editable;
import android.text.TextWatcher;
import android.util.Log;
import android.view.ContextMenu;
import android.view.ContextMenu.ContextMenuInfo;
import android.view.Gravity;
import android.view.KeyEvent;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.view.View.OnKeyListener;
import android.widget.AdapterView;
import android.widget.AdapterView.OnItemClickListener;
import android.widget.AdapterView.OnItemSelectedListener;
import android.widget.CheckBox;
import android.widget.CompoundButton;
import android.widget.CompoundButton.OnCheckedChangeListener;
import android.widget.EditText;
import android.widget.ListView;
import android.widget.SimpleCursorAdapter;
import android.widget.SimpleCursorAdapter.ViewBinder;
import android.widget.Spinner;
import android.widget.TextView;

import com.amesol.routelite.R;
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.actividades.ValoresReferencia;
import com.amesol.routelite.controles.NumberPicker;
import com.amesol.routelite.controles.NumberPicker.OnChangedListener;
import com.amesol.routelite.controles.NumberPicker.OnEnterListener;
import com.amesol.routelite.datos.Dia;
import com.amesol.routelite.datos.Ruta;
import com.amesol.routelite.datos.basedatos.BDVend;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.ConfigParametro;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.Enumeradores.RespuestaMsg;
import com.amesol.routelite.presentadores.act.CapturarDeposito;
import com.amesol.routelite.presentadores.interfaces.ICapturaDeposito;
import com.amesol.routelite.utilerias.ControlError;
import com.amesol.routelite.utilerias.Generales;

public class CapturaDeposito extends Vista implements ICapturaDeposito
{

	private CapturarDeposito mPresenta;
	private String mAccion;
	private boolean huboCambios = false;
	private Spinner spBanco = null;
	private EditText txtFicha = null;
	//private EditText mTxtDeposito = null;
	private ListView mLvDeposito = null;
	private boolean isCheck = false;
	
	private NumberPicker mTxtDeposito = null;

	@SuppressLint("SimpleDateFormat")
	@Override
	public void onCreate(Bundle savedInstanceState)
	{
		super.onCreate(savedInstanceState);
		setContentView(R.layout.captura_deposito);
		//		deshabilitarBarra(true);
		try
		{
			mAccion = getIntent().getAction();
			lblTitle.setText("Depositos");
			mPresenta = new CapturarDeposito(this, mAccion);

			TextView mTexto = (TextView) findViewById(R.id.lblRuta);
			mTexto.setText(Mensajes.get("XRuta") + ": " + ((Ruta) Sesion.get(Campo.RutaActual)).Descripcion);
			mTexto = (TextView) findViewById(R.id.lblDia);
			mTexto.setText(Mensajes.get("XDiaTrabajo") + ": " + ((Dia) Sesion.get(Campo.DiaActual)).DiaClave);
			mTexto = (TextView) findViewById(R.id.lblTotalEfyDep);
			mTexto.setText("Total de Efectivo y Cheques");
			mTexto = (TextView) findViewById(R.id.lblDev);
			mTexto.setText("Total de Devoluciones");
			mTexto = (TextView) findViewById(R.id.lblTotalaDepositar);
			mTexto.setText("Total a Depositar");
			mTexto = (TextView) findViewById(R.id.lblMaxaDepositar);
			mTexto.setText("Maximo a Depositar");
			mTexto = (TextView) findViewById(R.id.lblFechaDeposito);
			mTexto.setText(Mensajes.get("XFechaDeposito"));
			mTexto = (TextView) findViewById(R.id.lblBanco);
			mTexto.setText(Mensajes.get("XBanco"));
			mTexto = (TextView) findViewById(R.id.lblFicha);
			mTexto.setText(Mensajes.get("XFichaCheque"));
			mTexto = (TextView) findViewById(R.id.lblDeposito);
			mTexto.setText("Deposito");
			mTexto = (TextView) findViewById(R.id.txtCol1);
			mTexto.setText(Mensajes.get("XFolio"));
			mTexto = (TextView) findViewById(R.id.txtCol2);
			mTexto.setText(Mensajes.get("XFicha"));
			mTexto = (TextView) findViewById(R.id.txtCol3);
			mTexto.setText(Mensajes.get("XFecha"));
			mTexto = (TextView) findViewById(R.id.txtCol4);
			mTexto.setText(Mensajes.get("XTotal"));
			mTexto = (TextView) findViewById(R.id.txtCol5);
			mTexto.setVisibility(View.VISIBLE);
			mTexto.setText(Mensajes.get("XBanco"));

			SimpleDateFormat format = new SimpleDateFormat("dd/MM/yyyy");
			final TextView txtDate = (TextView) findViewById(R.id.txtFechaDeposito);
			txtDate.setText(format.format(new Date()));
			txtDate.setEnabled(false);
			spBanco = (Spinner) findViewById(R.id.spBanco);
			ISetDatos valores;
			valores = Consultas.ConsultasValorReferencia.obtenerValores("TBANCO", null);
			mLvDeposito = (ListView) findViewById(R.id.lv_deposito);
			llenarSpinerBanco(spBanco, valores);

			spBanco.setOnItemSelectedListener(new OnItemSelectedListener()
			{

				@Override
				public void onItemSelected(AdapterView<?> arg0, View arg1, int arg2, long arg3)
				{
					if (arg2 != 0)
					{
						Log.e("", "Entro En Spinner");
						huboCambios = true;
					}
				}

				@Override
				public void onNothingSelected(AdapterView<?> arg0)
				{
					// TODO Auto-generated method stub

				}
			});

			txtFicha = (EditText) findViewById(R.id.txtFicha);
			txtFicha.addTextChangedListener(new TextWatcher()
			{
				@Override
				public void afterTextChanged(Editable arg0)
				{
					huboCambios = true;
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
			//mTxtDeposito = (EditText) findViewById(R.id.txtDeposito);
			mTxtDeposito = (NumberPicker) findViewById(R.id.txtDeposito);
			mTxtDeposito.ocultarBotones(true);
			mTxtDeposito.setEditeTextBackgroundToNull();
			mTxtDeposito.setDecimal(2);
			mTxtDeposito.setStep(1);
			mTxtDeposito.setWrap(false);
			mTxtDeposito.setRangeDecimal(0, (float) 999999.99);
			
			mTxtDeposito.setOnChangeListener(new OnChangedListener()
			{
				
				@Override
				public void onChanged(NumberPicker picker, int oldVal, int newVal)
				{
					huboCambios = true;
				}
			});

			/*mTxtDeposito.addTextChangedListener(new TextWatcher()
			{
				@Override
				public void afterTextChanged(Editable arg0)
				{
					huboCambios = true;
				}

				@Override
				public void beforeTextChanged(CharSequence arg0, int arg1, int arg2, int arg3)
				{

				}

				@Override
				public void onTextChanged(CharSequence arg0, int arg1, int arg2, int arg3)
				{

				}
			});*/
			
			mTxtDeposito.setOnEnterListener(new OnEnterListener()
			{
				@Override
				public void OnEnterPressed()
				{
					if (txtFicha.getText().toString().equals(""))
					{
						mostrarAdvertencia(Mensajes.get("BE0001").replace("$0$", "Ficha"));
						return;
					}
					if (mTxtDeposito.getCurrentDecimal() == 0)
					{
						mostrarAdvertencia(Mensajes.get("BE0001").replace("$0$", "Deposito"));
						return;
					}
					if (spBanco.getSelectedItemPosition() == 0)
					{
						mostrarAdvertencia(Mensajes.get("BE0001").replace("$0$", "Banco"));
						return;
					}
					if (mTxtDeposito.getCurrentDecimal() <= 0)
					{
						mostrarAdvertencia(Mensajes.get("E0041"));
						return;
					}
					EditText mTexto = (EditText) findViewById(R.id.txtMaxaDepositar);
					if (mTxtDeposito.getCurrentDecimal() > (Generales.getRound(Float.parseFloat(mTexto.getText().toString().replace("$", "").trim()),2)))
					{
						mostrarAdvertencia(Mensajes.get("E0906"));
						return;
					}
					mPresenta.AgregarDeposito(String.valueOf(spBanco.getSelectedItemId()), txtFicha.getText().toString(), mTxtDeposito.getCurrentDecimal(), isCheck);
				}
			});
			
			/*mTxtDeposito.setOnKeyListener(new OnKeyListener()
			{
				@Override
				public boolean onKey(View v, int keyCode, KeyEvent event)
				{
					if (event.getAction() == KeyEvent.ACTION_UP)
					{
						if (keyCode == KeyEvent.KEYCODE_ENTER)
						{

							if (txtFicha.getText().toString().equals(""))
							{

								mostrarAdvertencia(Mensajes.get("BE0001").replace("$0$", "Ficha"));
								return false;
							}
							//if (mTxtDeposito.getText().toString().equals(""))
							if (mTxtDeposito.getCurrentDecimal() == 0)
							{
								mostrarAdvertencia(Mensajes.get("BE0001").replace("$0$", "Deposito"));
								return false;
							}
							if (spBanco.getSelectedItemPosition() == 0)
							{
								mostrarAdvertencia(Mensajes.get("BE0001").replace("$0$", "Banco"));
								return false;
							}
							//if (Integer.parseInt(mTxtDeposito.getText().toString()) <= 0)
							if (mTxtDeposito.getCurrentDecimal() <= 0)
							{
								mostrarAdvertencia(Mensajes.get("E0041"));
								return false;
							}
							EditText mTexto = (EditText) findViewById(R.id.txtMaxaDepositar);
							//if (Integer.parseInt(mTxtDeposito.getText().toString()) > (Float.parseFloat(mTexto.getText().toString().replace("$", "").trim())))
							if (mTxtDeposito.getCurrentDecimal() > (Float.parseFloat(mTexto.getText().toString().replace("$", "").trim())))
							{
								mostrarAdvertencia(Mensajes.get("E0906"));
								return false;
							}

							//							if (Integer.valueOf(mTxtDeposito.getText().toString()) > 0)
							//							{
							//mPresenta.AgregarDeposito(String.valueOf(spBanco.getSelectedItemId()), txtFicha.getText().toString(), Float.parseFloat(mTxtDeposito.getText().toString()), isCheck);
							mPresenta.AgregarDeposito(String.valueOf(spBanco.getSelectedItemId()), txtFicha.getText().toString(), mTxtDeposito.getCurrentDecimal(), isCheck);
							//							}
							//							else
							//								mostrarError(Mensajes.get("E0334").replace("$0$", "Total"));
						}
					}
					return false;
				}
			});*/
			CheckBox mCkbDev = (CheckBox) findViewById(R.id.ckbDev);
			mCkbDev.setOnCheckedChangeListener(new OnCheckedChangeListener()
			{

				@Override
				public void onCheckedChanged(CompoundButton buttonView, boolean isChecked)
				{
					isCheck = isChecked;
					if (isChecked)
					{
						//isCheck = true;
						mPresenta.activarDevoluciones();
					}
					else
					{
						EditText mTexto = (EditText) findViewById(R.id.txtDev);
						mTexto.setText("");
						mTexto.setEnabled(false);
						mPresenta.iniciar();
					}
				}
			});
			registerForContextMenu(mLvDeposito);
			mPresenta.iniciar();
		}
		catch (Exception e)
		{
			e.printStackTrace();
		}
	}

	public boolean getAplicaDevoluciones(){
		return isCheck;
	}
	
	@Override
	public void iniciar()
	{

	}

	@Override
	public void resultadoActividad(int requestCode, int resultCode, Intent data)
	{
		if (requestCode == REQUEST_ENABLE_BT)
		{
			if (resultCode == RESULT_OK)
			{
				try
				{
					mPresenta.imprimirTicket();
				}
				catch (Exception e)
				{
					getVista().mostrarError(e.getMessage());
				}
			}
			else
			{
				mostrarError("No se pudo encender el BT");
			}

			return;
		}
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

		}
		else if (tipoMensaje == 2)
		{
			if (respuesta == RespuestaMsg.Si)
			{
				Cursor transacciones = (Cursor) (((SimpleCursorAdapter) mLvDeposito.getAdapter()).getCursor());
				mPresenta.eliminarDeposito(transacciones.getString(transacciones.getColumnIndex("_id")), isCheck);
			}
		}
	}

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

	@Override
	@SuppressWarnings("deprecation")
	public void refrescarDeposito()
	{
		try
		{
			huboCambios = false;
			ISetDatos stTransProdDetalle = Consultas.ConsultaDeposito.obtenerDepositosRealizados();
			Cursor cProductos = (Cursor) stTransProdDetalle.getOriginal();
			startManagingCursor(cProductos);
			try
			{
				SimpleCursorAdapter adapter = new SimpleCursorAdapter(this, R.layout.lista_simple_hor6, cProductos, new String[]
				{ "_id", "Ficha", "FechaDeposito", "Total", "TipoBanco" }, new int[]
				{ R.id.txtCol1, R.id.txtCol2, R.id.txtCol3, R.id.txtCol4, R.id.txtCol5 });
				adapter.setViewBinder(new vistaDeposito());
				mLvDeposito.setAdapter(adapter);

				mLvDeposito.setOnItemClickListener(new OnItemClickListener()
				{

					public void onItemClick(AdapterView<?> arg0, View v, int pos, long arg3)
					{
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
					combo.setText(cursor.getString(cursor.getColumnIndex("_id")));
					break;
				case R.id.txtCol2:
					combo = (TextView) view;
					combo.setText(cursor.getString(cursor.getColumnIndex("Ficha")));
					break;
				case R.id.txtCol3:
					combo = (TextView) view;
					combo.setText(cursor.getString(cursor.getColumnIndex("FechaDeposito")));
					break;
				case R.id.txtCol4:
					combo = (TextView) view;
					combo.setText(cursor.getString(cursor.getColumnIndex("Total")));
					break;
				case R.id.txtCol5:
					view.setVisibility(View.VISIBLE);
					combo = (TextView) view;
					String mCantidad = ValoresReferencia.getDescripcion("TBANCO", cursor.getString(cursor.getColumnIndex("TipoBanco")));
					combo.setText(mCantidad);
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

		if (huboCambios)
			mostrarPreguntaSiNo(Mensajes.get("BP0002"), 3);
		else
		{
			setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
			finalizar();
		}

	}

	private void regresar()
	{
		try
		{

			if (huboCambios)
				BDVend.rollback();

			setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
			finalizar();
		}
		catch (Exception ex)
		{
			mostrarError(ex.getMessage());
		}
	}

	@Override
	public void setTotalEfyDep(float Total)
	{

		EditText mTexto = (EditText) findViewById(R.id.txtTotalEfyDep);
		mTexto.setText("$" + Generales.getRound(Total, 2));
		mTexto.setEnabled(false);

	}

	@Override
	public void setTotalDevoluciones(float Total)
	{
		EditText mTexto = (EditText) findViewById(R.id.txtDev);
		mTexto.setText("$" + Total);
		mTexto.setEnabled(false);

	}

	@Override
	public void setTotalDeposito(float Total)
	{
		EditText mTexto = (EditText) findViewById(R.id.txtTotalaDepositar);
		mTexto.setText("$" + Total);
		mTexto.setEnabled(false);

	}

	@Override
	public void setTotalDepositar(float Total)
	{
		EditText mTexto = (EditText) findViewById(R.id.txtMaxaDepositar);
		mTexto.setText("$" + Math.abs(Generales.getRound(Total, 2)));
		mTexto.setEnabled(false);

	}

	public void setLimpiarDeposito()
	{
		spBanco.setSelection(0);
		txtFicha.setText("");
		//mTxtDeposito.setText("");
		mTxtDeposito.setCurrentDecimal(0);
	}

	@SuppressWarnings("deprecation")
	public void llenarSpinerBanco(Spinner control, ISetDatos valores)
	{
		try
		{
			Cursor unidad = (Cursor) valores.getOriginal();
			startManagingCursor(unidad);
			SimpleCursorAdapter adapter = new SimpleCursorAdapter(CapturaDeposito.this, android.R.layout.simple_spinner_item, unidad, new String[]
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
					combo.setGravity(Gravity.CENTER);
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

	@Override
	public boolean onCreateOptionsMenu(Menu menu)
	{
		MenuInflater inflater = getMenuInflater();
		inflater.inflate(R.menu.menu_captura_deposito, menu);
		menu.getItem(0).setTitle("Imprimir");
		return true;
	}

	@Override
	public boolean onOptionsItemSelected(MenuItem item)
	{
		switch (item.getItemId())
		{
			case R.id.menu1:
				// Imprimir ticket
				try
				{
					if (!bluetoothEncendido())
					{
						encenderBluetooth();
					}
					else
					{
						mPresenta.imprimirTicket();
					}
				}
				catch (ControlError e)
				{
					e.Mostrar(getVista());
				}
				catch (Exception e)
				{
					getVista().mostrarError(e.getMessage());
				}
				return true;
		}
		return true;
	}

	private Vista getVista()
	{
		return this;
	}
	
	@Override
	public void impresionFinalizada(boolean impresionExitosa,String mensajeError)
	{
		if (mensajeError.equals(""))
			setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
		else			
			setResultado(Enumeradores.Resultados.RESULTADO_MAL, mensajeError);
		
		quitarProgreso();

        /*try {
            if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).existeParametro("NumImpresiones", Sesion.get(Campo.ModuloMovDetalleClave).toString())) {
                if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("NumImpresiones", Sesion.get(Campo.ModuloMovDetalleClave).toString()).equals("0")) {
                    mostrarPreguntaSiNo(Mensajes.get("P0103"), 8);
                } else {
                    finalizar();
                }
            } else {
                mostrarPreguntaSiNo(Mensajes.get("P0103"), 8);
            }
        }catch(Exception ex){
            mostrarPreguntaSiNo(Mensajes.get("P0103"), 8);
        }*/
	}
}
