package com.amesol.routelite.vistas;

import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.Date;
import java.util.HashMap;
import java.util.LinkedList;

import android.annotation.SuppressLint;
import android.app.DatePickerDialog;
import android.app.Dialog;
import android.content.Intent;
import android.os.Bundle;
import android.text.format.DateFormat;
import android.view.ContextMenu;
import android.view.ContextMenu.ContextMenuInfo;
import android.view.KeyEvent;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.AdapterView.AdapterContextMenuInfo;
import android.widget.Button;
import android.widget.DatePicker;
import android.widget.EditText;
import android.widget.ImageButton;
import android.widget.ListView;
import android.widget.TextView;

import com.amesol.routelite.R;
import com.amesol.routelite.actividades.Cobranza;
import com.amesol.routelite.actividades.Cobranza.VistaDetalle;
import com.amesol.routelite.actividades.Folios;
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.datos.utilerias.ConfigParametro;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.Enumeradores.RespuestaMsg;
import com.amesol.routelite.presentadores.act.CapturarCobranzaDet;
import com.amesol.routelite.presentadores.interfaces.ICapturaCobranzaDet;
import com.amesol.routelite.presentadores.parcelables.DatosAbnDetalle;
import com.amesol.routelite.utilerias.ControlError;
import com.amesol.routelite.utilerias.Generales;
import com.amesol.routelite.vistas.generico.CobranzaDetAdapter;

public class CapturaCobranzaDet extends Vista implements ICapturaCobranzaDet
{

	String mAccion;
	CapturarCobranzaDet mPresenta;
	static final int DATE_DIALOG_ID = 0;

	LinkedList<Cobranza.VistaSpinner> pagos;
	LinkedList<Cobranza.VistaSpinner> monedas;
	LinkedList<Cobranza.VistaSpinner> bancos;
	ArrayList<Integer> tiposCP;

	boolean imprimiendo;
	boolean errorFinalizar = false;

	@SuppressWarnings("unchecked")
	@Override
	public void onCreate(Bundle savedInstanceState)
	{
		try
		{
			super.onCreate(savedInstanceState);
			imprimiendo = false;

			mAccion = getIntent().getAction();

			setContentView(R.layout.captura_cobranza_det);
			deshabilitarBarra(true);

			setTitulo(Mensajes.get("XCobranza"));

			TextView lbFolio = (TextView) findViewById(R.id.lblFolio);
			lbFolio.setText(Mensajes.get("XFolio"));

			TextView lbFecha = (TextView) findViewById(R.id.lblFecha);
			lbFecha.setText(Mensajes.get("XFecha"));

			TextView lbSaldoIni = (TextView) findViewById(R.id.lblSaldoIni);
			lbSaldoIni.setText(Mensajes.get("XSaldoInicial"));

			TextView lbSaldoFin = (TextView) findViewById(R.id.lblSaldoFin);
			lbSaldoFin.setText(Mensajes.get("XSaldoRestante"));

			TextView lbFormaPagoTit = (TextView) findViewById(R.id.lblFormaPagoTit);
			lbFormaPagoTit.setText(Mensajes.get("XFormaPago"));

			TextView lbTotal = (TextView) findViewById(R.id.lblTotal);
			lbTotal.setText(Mensajes.get("ABNTotal"));

			ImageButton btnAgregar = (ImageButton) findViewById(R.id.btnAgregarPago);
			btnAgregar.setOnClickListener(mAgregar);

			Button btnContinuar = (Button) findViewById(R.id.btnContinuar);
			btnContinuar.setText(Mensajes.get("XContinuar"));
			btnContinuar.setOnClickListener(mContinuar);

			//			TableLayout layEncabezado = (TableLayout) findViewById(R.id.layEncabezado);
			//layEncabezado.setVisibility(View.GONE); 

			final ListView lista = (ListView) findViewById(R.id.lstPagos);
			if (mAccion.equals(Enumeradores.Acciones.ACCION_GENERAR_COBRANZA))
				registerForContextMenu(lista);
			//lista.addHeaderView(layEncabezado);

			mPresenta = new CapturarCobranzaDet(this, mAccion);
			if (getIntent().getSerializableExtra("parametros") != null)
			{
				if (mAccion.equals(Enumeradores.Acciones.ACCION_CONSULTAR_COBRANZA))
				{
					HashMap<String, Cobranza.VistaCobranza> oParam1 = null;
					oParam1 = (HashMap<String, Cobranza.VistaCobranza>) getIntent().getSerializableExtra("parametros");
					mPresenta.setAbono((Cobranza.VistaCobranza) oParam1.get("Abono"));
				}
				else if (mAccion.equals(Enumeradores.Acciones.ACCION_GENERAR_COBRANZA))
				{
					HashMap<String, ArrayList<String>> oParam2 = null;
					oParam2 = (HashMap<String, ArrayList<String>>) getIntent().getSerializableExtra("parametros");
					mPresenta.setTransProdIds((ArrayList<String>) oParam2.get("TransProdIds"));
				}
			}
			StringBuilder byRefError = new StringBuilder();
			String Folio = "";
			try{
				 Folio= Folios.Obtener((String) Sesion.get(Campo.ModuloMovDetalleClave), byRefError);

			}catch(Exception ex){
				errorFinalizar = true;
				mostrarError(ex.getMessage());
				return;
			}
			if (byRefError.length() >0){
				mostrarAdvertencia(byRefError.toString());
			}
			byRefError = null;
			
			mPresenta.setFolio(Folio);
			mPresenta.iniciar();

		}
		catch (Exception e)
		{
			if (e.getCause() != null){
				mostrarError(e.getMessage() + ". " + e.getCause().getMessage());
			}else{
				mostrarError(e.getMessage());
			}
				
		}
	}

	@SuppressWarnings("deprecation")
	@Override
	protected Dialog onCreateDialog(int id)
	{
		Date fecha = null;
		ListView lista = (ListView) findViewById(R.id.lstPagos);
		CobranzaDetAdapter adapter = (CobranzaDetAdapter) lista.getAdapter();

		fecha = adapter.getDetalle().getFechaCheque();
		if (fecha == null)
			fecha = Generales.getFechaActual();

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
		ListView lista = (ListView) findViewById(R.id.lstPagos);
		CobranzaDetAdapter adapter = (CobranzaDetAdapter) lista.getAdapter();
		fecha = adapter.getDetalle().getFechaCheque();
		if (fecha == null)
			fecha = Generales.getFechaActual();

		try
		{
			if (fecha != null)
			{
				((DatePickerDialog) dialog).updateDate(fecha.getYear() + 1900, fecha.getMonth(), fecha.getDate());
			}
		}
		catch (Exception e)
		{
			e.printStackTrace();
		}

	}

	@Override
	public boolean onKeyDown(int keyCode, KeyEvent event)
	{
		switch (keyCode)
		{
			case KeyEvent.KEYCODE_BACK:
				if (mPresenta.terminarCaptura())
				{
					this.finish();
					return true;
				}
				else
					return false;
		}
		return super.onKeyDown(keyCode, event);
	}

	@Override
	public void onCreateContextMenu(ContextMenu menu, View v, ContextMenuInfo menuInfo)
	{
		super.onCreateContextMenu(menu, v, menuInfo);
		MenuInflater inflater = getMenuInflater();
		inflater.inflate(R.menu.context_abono_detalle, menu);

		menu.getItem(0).setTitle(Mensajes.get("XEliminar"));
	}

	@Override
	public boolean onContextItemSelected(MenuItem item)
	{
		AdapterContextMenuInfo info = (AdapterContextMenuInfo) item.getMenuInfo();
		ListView lista = (ListView) findViewById(R.id.lstPagos);

		//CobranzaDetAdapter adapter = (CobranzaDetAdapter) lista.getAdapter();
		VistaDetalle detalle = (VistaDetalle) lista.getItemAtPosition((int) info.position);

		mPresenta.eliminarDetallePago(detalle.getImporte());

		((CobranzaDetAdapter) lista.getAdapter()).remove(detalle);
		((CobranzaDetAdapter) lista.getAdapter()).notifyDataSetChanged();

		return true;
	}

	private OnClickListener mAgregar = new OnClickListener()
	{

		@Override
		public void onClick(View v)
		{
			mPresenta.iniciarCapturaDetalle();
		}
	};

	private OnClickListener mContinuar = new OnClickListener()
	{

		@Override
		public void onClick(View v)
		{
			if (mAccion.equals(Enumeradores.Acciones.ACCION_GENERAR_COBRANZA))
			{
				Button btnContinuar = (Button) findViewById(R.id.btnContinuar);
				btnContinuar.setEnabled(false);
				try
				{
					if (mPresenta.guardarAbono())
					{
						if (!mPresenta.imprimir())
						{
							setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
							finalizar();
						}
					}
					else
					{
						btnContinuar.setEnabled(true);
					}
				}
				catch (Exception e)
				{
					// TODO Auto-generated catch block
					e.printStackTrace();
				}
			}
			else
			{
				setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
				finalizar();
			}
		}
	};

	private DatePickerDialog.OnDateSetListener mDateSetListener = new DatePickerDialog.OnDateSetListener()
	{
		@SuppressLint("SimpleDateFormat")
		@SuppressWarnings("deprecation")
		public void onDateSet(DatePicker view, int year, int monthOfYear, int dayOfMonth)
		{
			try
			{
				Calendar tmp = Calendar.getInstance();
				tmp.setTime((new SimpleDateFormat("dd/MM/yyyy")).parse(new SimpleDateFormat("dd/MM/").format(new Date(year, monthOfYear, dayOfMonth)) + (new Date(year, monthOfYear, dayOfMonth)).getYear()));
				if (tmp.getTime().compareTo(Generales.getFechaActual()) < 0)
				{ //la fecha seleccionada es menor a la de captura
					return;
				}

				Date fecha = new Date(year - 1900, monthOfYear, dayOfMonth);
				;
				ActualizaFecha(fecha);
			}
			catch (Exception ex)
			{
				mostrarError(ex.getMessage());
			}
		}
	};

	@Override
	public void iniciar()
	{
		// TODO Auto-generated method stub

	}

	@Override
	public void resultadoActividad(int requestCode, int resultCode, Intent data)
	{
		try
		{
			if (requestCode == Enumeradores.Solicitudes.SOLICITUD_ABONO_DETALLE && resultCode == Enumeradores.Resultados.RESULTADO_BIEN)
			{
				DatosAbnDetalle datosABD;
				datosABD = (DatosAbnDetalle) data.getExtras().getParcelable("Objeto");

				mPresenta.guardarDetallePago(datosABD);
			}
			else if (requestCode == REQUEST_ENABLE_BT)
			{
				if (resultCode == RESULT_OK)
				{
					try
					{
						imprimiendo = true;
						mPresenta.imprimirTicket();
					}
					catch (ControlError e)
					{
						e.Mostrar(getVista());
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
		catch (Exception ex)
		{
			mostrarError(ex.getMessage());
		}
	}

	@Override
	public void respuestaMensaje(RespuestaMsg respuesta, int tipoMensaje)
	{
		if (tipoMensaje == 1)
		{
			//Finalizar sin guardar cambios
			if (respuesta.equals(RespuestaMsg.Si))
			{
				this.finish();
			}
		}
		else if (tipoMensaje == 2)
		{
			if (respuesta.equals(RespuestaMsg.Si))
			{
				//Imprimir ticket
				try
				{
					/*if (!bluetoothEncendido())
					{
						encenderBluetooth();
					}
					else
					{*/
						imprimiendo = true;
						mPresenta.imprimirTicket();
					//}
					//getVista().mostrarAdvertencia("Recibos generados");
				}
				catch (ControlError e)
				{
					e.Mostrar(getVista());
				}
				catch (Exception e)
				{
					getVista().mostrarError(e.getMessage());
				}
			}
			else
			{
				setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
				finalizar();
			}
		}
		else if (tipoMensaje == 0 && imprimiendo)
		{
			setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
			finalizar();
		}
		else if(tipoMensaje == 0 && errorFinalizar){
			finalizar();
		}
	}

	@Override
	public void mostrarCobranzaDet(Cobranza.VistaCobranza oCobranza, ArrayList<Cobranza.VistaDetalle> oDetalles)
	{
		try
		{
			EditText txtFolio = (EditText) findViewById(R.id.txtFolio);
			txtFolio.setText(oCobranza.getFolio());
			txtFolio.setEnabled(false);

			EditText txtFecha = (EditText) findViewById(R.id.txtFecha);
			txtFecha.setText(DateFormat.format("dd/MM/yyyy", oCobranza.getFecha()));
			txtFecha.setEnabled(false);

			EditText txtTotal = (EditText) findViewById(R.id.txtTotal);
			txtTotal.setText(String.format("$ %.2f", oCobranza.getTotal()));
			txtTotal.setEnabled(false);

			ListView lista = (ListView) findViewById(R.id.lstPagos);
			CobranzaDetAdapter adapter = new CobranzaDetAdapter(this, R.layout.lista_cobranza_det, mPresenta, oDetalles, null, null, null, null, false);
			lista.setAdapter(adapter);
			lista.setClickable(true);

			TextView lbSaldoIni = (TextView) findViewById(R.id.lblSaldoIni);
			lbSaldoIni.setVisibility(View.GONE);

			EditText txtSaldoIni = (EditText) findViewById(R.id.txtSaldoIni);
			txtSaldoIni.setVisibility(View.GONE);

			TextView lbSaldoFin = (TextView) findViewById(R.id.lblSaldoFin);
			lbSaldoFin.setVisibility(View.GONE);

			EditText txtSaldoFin = (EditText) findViewById(R.id.txtSaldoFin);
			txtSaldoFin.setVisibility(View.GONE);

			TextView lblFormaPagoTit = (TextView) findViewById(R.id.lblFormaPagoTit);
			lblFormaPagoTit.setVisibility(View.GONE);

			ImageButton btnAgregarPago = (ImageButton) findViewById(R.id.btnAgregarPago);
			btnAgregarPago.setVisibility(View.GONE);

		}
		catch (Exception e)
		{
			mostrarError(e.getMessage() + ". " + e.getCause().getMessage());
			e.printStackTrace();
		}
	}

	@Override
	public void actualizarListaDet(ArrayList<Cobranza.VistaDetalle> oDetalles)
	{
		ListView lista = (ListView) findViewById(R.id.lstPagos);
		CobranzaDetAdapter adapter = (CobranzaDetAdapter) lista.getAdapter();

		if (adapter == null)
		{
			adapter = new CobranzaDetAdapter(this, R.layout.lista_cobranza_det, mPresenta, oDetalles, pagos, monedas, bancos, tiposCP, true);
			lista.setAdapter(adapter);
			lista.setClickable(true);
		}
		else
		{
			adapter.notifyDataSetChanged();
		}
	}

	@Override
	public void capturarCobranzaDet(ArrayList<Integer> tiposCP)
	{
		EditText txtTotal = (EditText) findViewById(R.id.txtTotal);
		txtTotal.setText(String.format("$ %.2f", 0.0));
		txtTotal.setEnabled(false);

		this.tiposCP = tiposCP;
	}

	@Override
	public void setFolio(String folio)
	{
		EditText txtFolio = (EditText) findViewById(R.id.txtFolio);
		txtFolio.setText(folio);
		txtFolio.setEnabled(false);
	}

	@Override
	public void setFecha(Date fecha)
	{
		EditText txtFecha = (EditText) findViewById(R.id.txtFecha);
		txtFecha.setText(DateFormat.format("dd/MM/yyyy", fecha));
		txtFecha.setEnabled(false);
	}

	@Override
	public void setSaldoIni(float saldoini)
	{
		EditText txtSaldoIni = (EditText) findViewById(R.id.txtSaldoIni);
		txtSaldoIni.setText(String.format("$ %.2f", saldoini));
		txtSaldoIni.setEnabled(false);
	}

	@Override
	public void setSaldoFin(float saldofin)
	{
		EditText txtSaldoFin = (EditText) findViewById(R.id.txtSaldoFin);
		txtSaldoFin.setText(String.format("$ %.2f", saldofin));
		txtSaldoFin.setEnabled(false);
	}

	@Override
	public void setTotal(float total)
	{
		EditText txtTotal = (EditText) findViewById(R.id.txtTotal);
		txtTotal.setText(String.format("$ %.2f", total));
		txtTotal.setEnabled(false);
	}

	@Override
	public float getTotal()
	{
		EditText txtTotal = (EditText) findViewById(R.id.txtTotal);
		return Float.valueOf(txtTotal.getText().toString());
	}

	@Override
	public void setFormasPago(LinkedList<Cobranza.VistaSpinner> oPagos)
	{
		pagos = oPagos;
	}

	@Override
	public void setMonedas(LinkedList<Cobranza.VistaSpinner> oMonedas)
	{
		monedas = oMonedas;
	}

	@Override
	public void setBancos(LinkedList<Cobranza.VistaSpinner> oBancos)
	{
		bancos = oBancos;
	}

	private void ActualizaFecha(Date fecha)
	{
		ListView lista = (ListView) findViewById(R.id.lstPagos);

		CobranzaDetAdapter adapter = (CobranzaDetAdapter) lista.getAdapter();
		adapter.getDetalle().setFechaCheque(fecha);
		adapter.notifyDataSetChanged();

	}

	private Vista getVista()
	{
		return this;
	}
	
	@Override
	public void impresionFinalizada(boolean impresionExitosa, String mensajeError)
	{
		if (mensajeError.equals(""))
			setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
		else			
			setResultado(Enumeradores.Resultados.RESULTADO_MAL, mensajeError);
		
    	quitarProgreso();

        try {
            if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).existeParametro("NumImpresiones", Sesion.get(Campo.ModuloMovDetalleClave).toString())) {
                if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("NumImpresiones", Sesion.get(Campo.ModuloMovDetalleClave).toString()).equals("0")) {
                    mostrarPreguntaSiNo(Mensajes.get("P0103"), 2);
                } else {
                    finalizar();
                }
            } else {
                mostrarPreguntaSiNo(Mensajes.get("P0103"), 2);
            }
        }catch(Exception ex){
            mostrarPreguntaSiNo(Mensajes.get("P0103"), 2);
        }
	}
}
