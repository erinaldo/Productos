package com.amesol.routelite.vistas;

import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.Date;
import java.util.HashMap;
import java.util.LinkedList;

import android.annotation.SuppressLint;
import android.app.AlertDialog;
import android.app.DatePickerDialog;
import android.app.Dialog;
import android.bluetooth.BluetoothAdapter;
import android.content.Context;
import android.content.Intent;
import android.content.IntentFilter;
import android.os.Bundle;
import android.text.Editable;
import android.text.TextWatcher;
import android.view.KeyEvent;
import android.view.LayoutInflater;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.AdapterView;
import android.widget.AdapterView.OnItemSelectedListener;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.DatePicker;
import android.widget.EditText;
import android.widget.Spinner;
import android.widget.TableRow;
import android.widget.TextView;
import android.widget.Toast;

import com.amesol.routelite.R;
import com.amesol.routelite.actividades.Cobranza;
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.datos.Cliente;
import com.amesol.routelite.datos.Vendedor;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.Enumeradores.RespuestaMsg;
import com.amesol.routelite.presentadores.act.CapturarDetalleCobranza;
import com.amesol.routelite.presentadores.interfaces.IElementoCobranzaDet;
import com.amesol.routelite.presentadores.parcelables.DatosAbnDetalle;
import com.amesol.routelite.utilerias.ControlError;
import com.amesol.routelite.utilerias.Generales;

@SuppressLint("SimpleDateFormat")
public class ElementoCobranzaDet extends Vista implements IElementoCobranzaDet
{

	// String mAccion;
	CapturarDetalleCobranza mPresenta;
	static final int DATE_DIALOG_ID = 0;
	int tipoPago;
	String monedaId;
	int tipoBanco;
    String cuenta = "";
	String referencia = "";
	Date fechaCheque;
    String observaciones;
	ArrayList<Integer> tiposCP;
	boolean cuentaStatus = true;
	//Billpocket
	private final int CREDIT_CARD_INTENT = 1000;

	@SuppressLint("CutPasteId")
	@SuppressWarnings("unchecked")
	@Override
	public void onCreate(Bundle savedInstanceState)
	{
		try
		{
			super.onCreate(savedInstanceState);
			// mAccion = getIntent().getAction();

			fechaCheque = Generales.getFechaActual();

			setContentView(R.layout.elemento_cobranza_det);
			deshabilitarBarra(true);

			setTitulo(Mensajes.get("XCobranza"));

			TextView lbSaldoIni = (TextView) findViewById(R.id.lblSaldoIni);
			lbSaldoIni.setText(Mensajes.get("XSaldoInicial"));

			TextView lbSaldoFin = (TextView) findViewById(R.id.lblSaldoFin);
			lbSaldoFin.setText(Mensajes.get("XSaldoRestante"));

            TextView lbSaldoDescIni = (TextView) findViewById(R.id.lblSaldoDescIni);
            lbSaldoDescIni.setText(Mensajes.get("XSaldoInicialDesc"));

            TextView lbSaldoDescFin = (TextView) findViewById(R.id.lblSaldoDescFin);
            lbSaldoDescFin.setText(Mensajes.get("XSaldoRestanteDesc"));

			TextView lbFormaPago = (TextView) findViewById(R.id.lblFormaPago);
			lbFormaPago.setText(Mensajes.get("XFormaPago"));

			Spinner spnFormaPago = (Spinner) findViewById(R.id.spnFormaPago);
			spnFormaPago.setOnItemSelectedListener(mSeleccionSpinner);

			TextView lbMoneda = (TextView) findViewById(R.id.lblMoneda);
			lbMoneda.setText(Mensajes.get("XMoneda"));

			Spinner spnMoneda = (Spinner) findViewById(R.id.spnMoneda);
			spnMoneda.setOnItemSelectedListener(mSeleccionSpinner);

			TextView lbImporte = (TextView) findViewById(R.id.lblImporte);
			lbImporte.setText(Mensajes.get("XImporte"));

			TextView lbBanco = (TextView) findViewById(R.id.lblBanco);
			lbBanco.setText(Mensajes.get("XBanco"));

			Spinner spnBanco = (Spinner) findViewById(R.id.spnBanco);
			spnBanco.setOnItemSelectedListener(mSeleccionSpinner);

            TextView lbCuenta = (TextView) findViewById(R.id.lblCuenta);
            lbCuenta.setText(Mensajes.get("XNoCuenta"));

			TextView lbReferencia = (TextView) findViewById(R.id.lblReferencia);
			lbReferencia.setText(Mensajes.get("XReferencia"));

			TextView lbFechaCheque = (TextView) findViewById(R.id.lblFechaCheque);
			lbFechaCheque.setText(Mensajes.get("XFecha"));

            TextView lbObservaciones = (TextView) findViewById(R.id.lblObservaciones);
            lbObservaciones.setText(Mensajes.get("XObservaciones"));

            TextView txtFechaCheque = (TextView) findViewById(R.id.txtFechaCheque);
			txtFechaCheque.setOnClickListener(mSeleccionarFecha);

            EditText txtCuenta = (EditText) findViewById(R.id.txtCuenta);
            txtCuenta.addTextChangedListener(new TextWatcher()
            {

                @Override
                public void onTextChanged(CharSequence s, int start, int before, int count)
                {
                    // TODO Auto-generated method stub
                }

                @Override
                public void beforeTextChanged(CharSequence s, int start, int count, int after)
                {
                    // TODO Auto-generated method stub

                }

                @Override
                public void afterTextChanged(Editable s)
                {
                    cuenta = s.toString();
                }
            });

			EditText txtReferencia = (EditText) findViewById(R.id.txtReferencia);
			txtReferencia.addTextChangedListener(new TextWatcher()
			{

				@Override
				public void onTextChanged(CharSequence s, int start, int before, int count)
				{
					// TODO Auto-generated method stub
				}

				@Override
				public void beforeTextChanged(CharSequence s, int start, int count, int after)
				{
					// TODO Auto-generated method stub

				}

				@Override
				public void afterTextChanged(Editable s)
				{
					referencia = s.toString();
				}
			});

            EditText txtObservaciones = (EditText) findViewById(R.id.txtObservaciones);
            txtObservaciones.addTextChangedListener(new TextWatcher()
            {

                @Override
                public void onTextChanged(CharSequence s, int start, int before, int count)
                {
                    // TODO Auto-generated method stub
                }

                @Override
                public void beforeTextChanged(CharSequence s, int start, int count, int after)
                {
                    // TODO Auto-generated method stub

                }

                @Override
                public void afterTextChanged(Editable s)
                {
                    observaciones= s.toString();
                }
            });


            Button btnContinuar = (Button) findViewById(R.id.btnContinuar);
			btnContinuar.setText(Mensajes.get("XContinuar"));
			btnContinuar.setOnClickListener(mGuardarPago);

			mPresenta = new CapturarDetalleCobranza(this);
			if (getIntent().getSerializableExtra("parametros") != null)
			{
				HashMap<String, Float> oParam = null;
				oParam = (HashMap<String, Float>) getIntent().getSerializableExtra("parametros");

				mPresenta.setSaldoInicial(oParam.get("saldoInicial"));
				mPresenta.setSaldoResto(oParam.get("saldoResto"));
                if (oParam.containsKey("saldoInicialDesc")) {
                    mPresenta.setAplicarDescProntoPago(true);
                    mPresenta.setSaldoInicialDesc(oParam.get("saldoInicialDesc"));
                    mPresenta.setSaldoRestoDesc(oParam.get("saldoRestoDesc"));
                }
			}
			mPresenta.iniciar();

		}
		catch (Exception e)
		{
			mostrarError(e.getMessage() + ". " + e.getCause().getMessage());
			e.printStackTrace();
		}

		Spinner spinners = (Spinner) findViewById(R.id.spnFormaPago);

		if (!(spinners.getCount() > 1))
			spinners.setEnabled(false);

		spinners = (Spinner) findViewById(R.id.spnMoneda);
		if (!(spinners.getCount() > 1))
			spinners.setEnabled(false);

		spinners = (Spinner) findViewById(R.id.spnBanco);
		if (!(spinners.getCount() > 1))
			spinners.setEnabled(false);
	}

	@SuppressWarnings("deprecation")
	@Override
	protected Dialog onCreateDialog(int id)
	{
		Date fecha = null;
		fecha = fechaCheque;

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
		fecha = fechaCheque;

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
				this.finish();
				return true;
		}
		return super.onKeyDown(keyCode, event);
	}

	private OnClickListener mGuardarPago = new OnClickListener()
	{

		@Override
		public void onClick(View v)
		{
			try
			{
				mPresenta.validarDetalle();
				if(((Vendedor) Sesion.get(Sesion.Campo.VendedorActual)).PagoConTarjeta && (tipoPago == 3 || tipoPago == 4)){
					//if(tipoPago == 28 || tipoPago == 4){
						try {
							if (!bluetoothEncendido()) {
								onBluetoothOtherDevices();
							} else {
								dialogBillPocket();
							}
							// getVista().mostrarAdvertencia("Recibos generados");
						} catch (ControlError e) {
							e.Mostrar(getVista());
						} catch (Exception e) {
							mostrarError(e.getMessage());
						}

					//}
				}else {
					//mPresenta.validarDetalle();
					DatosAbnDetalle datosABD = new DatosAbnDetalle();
					datosABD.setTipoPago(tipoPago);
					datosABD.setMonedaId(monedaId);
					datosABD.setImporte(getImporte());
					datosABD.setTipoBanco(tipoBanco);
					datosABD.setCuenta(cuenta);
					datosABD.setReferencia(referencia);
					datosABD.setObservaciones(observaciones);
					datosABD.setPagoBillpocket(true);

					if (fechaCheque != null)
						datosABD.setFechaCheque(fechaCheque.getTime());
					setResultadoParcelable(Enumeradores.Resultados.RESULTADO_BIEN, "false", datosABD);
					finalizar();
				}
			}
			catch (Exception e)
			{
				mostrarError(e.getMessage());
			}
		}
	};

	private OnClickListener mSeleccionarFecha = new OnClickListener()
	{

		@SuppressWarnings("deprecation")
		@Override
		public void onClick(View v)
		{
			if (tiposCP.contains(tipoPago))
				showDialog(DATE_DIALOG_ID);
		}
	};

	@SuppressLint("SimpleDateFormat")
	private DatePickerDialog.OnDateSetListener mDateSetListener = new DatePickerDialog.OnDateSetListener()
	{
		@SuppressWarnings("deprecation")
		public void onDateSet(DatePicker view, int year, int monthOfYear, int dayOfMonth)
		{
			try
			{
				Calendar tmp = Calendar.getInstance();
				tmp.setTime((new SimpleDateFormat("dd/MM/yyyy")).parse(new SimpleDateFormat("dd/MM/").format(new Date(year, monthOfYear, dayOfMonth)) + (new Date(year, monthOfYear, dayOfMonth)).getYear()));
				String grupo = Consultas.ConsultasValorReferencia.obtenerGrupo("PAGO", String.valueOf(tipoPago));
				if(grupo.equals("TR")){
					if (tmp.getTime().compareTo(Generales.getFechaActual()) > 0)
					{ // la fecha seleccionada es menor a la de captura
						return;
					}
				}else{
					if (tmp.getTime().compareTo(Generales.getFechaActual()) < 0)
					{ // la fecha seleccionada es menor a la de captura
						return;
					}
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



	private void ActualizaFecha(Date fecha)
	{
		SimpleDateFormat formato = new SimpleDateFormat("dd/MM/yyy");

		TextView txtFecha = null;

		txtFecha = (TextView) findViewById(R.id.txtFechaCheque);
		if (txtFecha != null)
			txtFecha.setText(formato.format(fecha));

		fechaCheque = fecha;
	}

	private OnItemSelectedListener mSeleccionSpinner = new OnItemSelectedListener()
	{

		@SuppressLint("SimpleDateFormat")
		public void onItemSelected(AdapterView<?> parent, View view, int pos, long id)
		{

			if (parent.getId() == R.id.spnFormaPago)
			{
				/*
				 * Cursor dato; dato = (Cursor)parent.getItemAtPosition(pos);
				 * dato.moveToPosition(pos);
				 */
				tipoPago = Integer.parseInt(((Cobranza.VistaSpinner) parent.getItemAtPosition(pos)).getId());

				Spinner spnBanco = (Spinner) findViewById(R.id.spnBanco);
                EditText txtCuenta = (EditText) findViewById(R.id.txtCuenta);
				EditText txtReferencia = (EditText) findViewById(R.id.txtReferencia);
				TextView txtFechaCheque = (TextView) findViewById(R.id.txtFechaCheque);

				if (tipoPago == 1)
				{
					tipoBanco = 0;
                    cuenta = "";
					referencia = "";
					fechaCheque = null;

					spnBanco.setEnabled(false);
					spnBanco.setSelection(0);

                    txtCuenta.setEnabled(false);
                    txtCuenta.setFocusable(false);
                    txtCuenta.setText("");

					txtReferencia.setEnabled(false);
					txtReferencia.setFocusable(false);
					txtReferencia.setText("");

					txtFechaCheque.setText("");

				}
				else
				{
					spnBanco.setEnabled(true);
					// spnBanco.setFocusable(true);
                    txtCuenta.setEnabled(true);
                    txtCuenta.setFocusable(true);
                    txtCuenta.setFocusableInTouchMode(true);

					txtReferencia.setEnabled(true);
					txtReferencia.setFocusable(true);
					txtReferencia.setFocusableInTouchMode(true);
					cuentaStatus = true;
					try {
						String cuenta = Consultas.ConsultasClientePago.obtenerCuentaFormaPago(((Cliente)Sesion.get(Sesion.Campo.ClienteActual)).ClienteClave, Integer.toString(tipoPago));
						if(cuenta.length() > 0){
							txtCuenta.setText(cuenta);
							txtCuenta.setEnabled(false);
							cuentaStatus = false;
						}

					}catch(Exception ex){
						mostrarError(ex.getMessage());
					}
					/*
					 * if (!tiposCP.contains(tipoPago)) { // fechaCheque = null;
					 * 
					 * txtFechaCheque.setText(""); } else
					 */
					{
						fechaCheque = Generales.getFechaActual();
						SimpleDateFormat formato = new SimpleDateFormat("dd/MM/yyy");
						txtFechaCheque.setText(formato.format(fechaCheque));
					}
				}
			}
			else if (parent.getId() == R.id.spnMoneda)
			{
				monedaId = ((Cobranza.VistaSpinner) parent.getItemAtPosition(pos)).getId();
			}
			if (parent.getId() == R.id.spnBanco)
			{
				/*
				 * Cursor dato; dato = (Cursor)parent.getItemAtPosition(pos);
				 * dato.moveToPosition(pos); tipoBanco = dato.getInt(0);
				 */
				tipoBanco = Integer.parseInt(((Cobranza.VistaSpinner) parent.getItemAtPosition(pos)).getId());
			}
		}

		public void onNothingSelected(AdapterView<?> parent)
		{
			// Do nothing.
		}
	};

	@Override
	public void iniciar()
	{
		// TODO Auto-generated method stub

	}

	@Override
	public void capturarCobranzaDet(ArrayList<Integer> tiposCP)
	{
		// TODO Auto-generated method stub

	}

	@Override
	public void poblarFormaPago(LinkedList<Cobranza.VistaSpinner> oPagos)
	{
		Spinner spnFormaPago = (Spinner) findViewById(R.id.spnFormaPago);
		poblarSpinner(spnFormaPago, oPagos);
	}

	@Override
	public void poblarMoneda(LinkedList<Cobranza.VistaSpinner> oMonedas)
	{
		Spinner spnMoneda = (Spinner) findViewById(R.id.spnMoneda);
		poblarSpinner(spnMoneda, oMonedas);
	}

	@Override
	public void poblarBanco(LinkedList<Cobranza.VistaSpinner> oBancos)
	{
		Spinner spnBanco = (Spinner) findViewById(R.id.spnBanco);
		poblarSpinner(spnBanco, oBancos);
	}

	private void poblarSpinner(Spinner control, LinkedList<Cobranza.VistaSpinner> oValores)
	{
		ArrayAdapter<Cobranza.VistaSpinner> adapter = new ArrayAdapter<Cobranza.VistaSpinner>(this, android.R.layout.simple_spinner_item, oValores);
		adapter.setDropDownViewResource(android.R.layout.simple_spinner_item);
		control.setAdapter(adapter);
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
    public void mostrarDescuento(){
        TableRow rowLabelDescuento = (TableRow) findViewById(R.id.rowLabelDescuento);
        TableRow rowTextDescuento = (TableRow) findViewById(R.id.rowTextDescuento);
        rowLabelDescuento.setVisibility(View.VISIBLE);
        rowTextDescuento.setVisibility(View.VISIBLE);
    }

    @Override
    public void setSaldoDescIni(float saldoDescIni)
    {
        EditText txtSaldoIni = (EditText) findViewById(R.id.txtSaldoDescIni);
        txtSaldoIni.setText(String.format("$ %.2f", saldoDescIni));
        txtSaldoIni.setEnabled(false);
    }

    @Override
    public void setSaldoDescFin(float saldoDescFin)
    {
        EditText txtSaldoFin = (EditText) findViewById(R.id.txtSaldoDescFin);
        txtSaldoFin.setText(String.format("$ %.2f", saldoDescFin));
        txtSaldoFin.setEnabled(false);
    }

	@Override
	public void setImporte(float importe)
	{
		EditText txtImporte = (EditText) findViewById(R.id.txtImporte);
		txtImporte.setText(String.format("$ %.2f", importe));
	}

	@Override
	public void setTiposCP(ArrayList<Integer> tiposCP)
	{
		this.tiposCP = tiposCP;
	}

	@Override
	public int getTipoPago()
	{
		return tipoPago;
	}

	@Override
	public String getMonedaId()
	{
		return monedaId;
	}

	@Override
	public float getImporte()
	{
		EditText txtImporte = (EditText) findViewById(R.id.txtImporte);
		String sImporte = txtImporte.getText().toString();
		sImporte = sImporte.trim();
		if (sImporte.length() == 0)
			return 0;
		else
			return Generales.getRound(Float.parseFloat(sImporte), 2);
	}

	@Override
	public int getTipoBanco()
	{
		return tipoBanco;
	}

	@Override
	public String getReferencia()
	{
		return referencia;
	}

	@Override
	public Date getFechaCheque()
	{
		return fechaCheque;
	}

	@Override
	public void resultadoActividad(int requestCode, int resultCode, Intent data)
	{
		// TODO Auto-generated method stub
		if(requestCode == CREDIT_CARD_INTENT){

			if(data != null) {
				Bundle extras = data.getExtras();

				if (extras == null){
					return;
				}

				String result = extras.getString("result");
				String statusinfo = extras.getString("statusinfo");

				String message = result + ( statusinfo != null ? ": "+extras.getString("statusinfo"):"");
				//mostrarToast(message);

				if(result.equalsIgnoreCase(BILLPOCKET_RESULTS.APROBADA.getVal())) {
					//Aprobado
					try{
						mPresenta.validarDetalle();
						DatosAbnDetalle datosABD = new DatosAbnDetalle();
						datosABD.setTipoPago(tipoPago);
						datosABD.setMonedaId(monedaId);
						datosABD.setImporte(getImporte());
						datosABD.setTipoBanco(tipoBanco);
						datosABD.setCuenta(cuenta);
						datosABD.setReferencia(referencia);
						datosABD.setObservaciones(observaciones);
						datosABD.setPagoBillpocket(true);
						if (fechaCheque != null)
							datosABD.setFechaCheque(fechaCheque.getTime());
						setResultadoParcelable(Enumeradores.Resultados.RESULTADO_BIEN, "true", datosABD);
						mostrarMensaje(Mensajes.get("I0337").replace("$0$", message),0,0);
						finalizar();
					}catch(Exception ex){
						mostrarError(ex.getMessage());
					}
				}
				else{
					//No aprobado
					mostrarError(Mensajes.get("E1009").replace("$0$", message.replace("error:", "")));
				}
			}

		}

	}

	@Override
	public void respuestaMensaje(RespuestaMsg respuesta, int tipoMensaje)
	{
		// TODO Auto-generated method stub

	}

    public void habilitarCuenta(boolean habilitar){
        TableRow tableRowCta = (TableRow) findViewById(R.id.tableRowCta);
        if (!habilitar)
            tableRowCta.setVisibility(View.GONE);
        else
            tableRowCta.setVisibility(View.VISIBLE);
    }

    public void setCuenta(String cuenta){
        EditText txtCuenta = (EditText) findViewById(R.id.txtCuenta);
        txtCuenta.setText(cuenta);
    }

    public String getCuenta(){
        return cuenta;
    }

	public boolean getStatusCuenta(){
		return cuentaStatus;
	}

	public void dialogBillPocket(){

		final Context ctx = this;

		LayoutInflater inflater = getLayoutInflater();

		View dialogView = inflater.inflate(R.layout.dialog_billpocket, null);

		final AlertDialog.Builder builder = new AlertDialog.Builder(this);

		TextView lblTituloGeneral = (TextView) dialogView.findViewById(R.id.lblTituloBillPocket);
		lblTituloGeneral.setText("Billpocket");

		//TextView label = (TextView) dialogView.findViewById(R.id.lblUsuario);
		//label.setText(Mensajes.get("XUsuario"));

		TextView label = (TextView) dialogView.findViewById(R.id.lblPin);
		label.setText("PIN");

		//final EditText etUsuario = (EditText) dialogView.findViewById(R.id.etUsuario);
		final EditText etPin = (EditText) dialogView.findViewById(R.id.etPin);


		builder.setView(dialogView);
		final Dialog dialog = builder.create();

		Button btnSalir = (Button) dialogView.findViewById(R.id.btnAceptar);
		btnSalir.setText(Mensajes.get("BTAceptar"));
		btnSalir.setOnClickListener(new OnClickListener() {
			@Override
			public void onClick(View v) {
				if(etPin.getText().toString().equals("")){
					mostrarError(Mensajes.get("BE0001").replace("$0$", "Pin"));
				}else if (etPin.getText().length() != 4) {
					mostrarError("El PIN debe tener 4 digitos");
				}else{
					creditCardTransaction(Double.toString(getImporte()),etPin.getText().toString(),"venta","0001", "");
					dialog.dismiss();
				}
			}
		});


		dialog.show();
	}

	public void creditCardTransaction(String importe,String pin,String transaccion,String identificador, String usuario){

		//Intent intent = new Intent("billpocket.payments.START");
		Intent intent = new Intent("com.billpocket.payments.START");

		intent.putExtra("amount", importe);
		intent.putExtra("pin", pin);
		intent.putExtra("transaction", transaccion);
		intent.putExtra("identifier", identificador);
		//intent.putExtra("email", usuario);


		if (intent.resolveActivity(this.getPackageManager()) != null){
			this.startActivityForResult(intent, CREDIT_CARD_INTENT);
		}else {
			mostrarError("Para hacer el pago con tarjeta es neceario tener instalada la aplicación BillPocket");
		}
	}

	public enum BILLPOCKET_RESULTS{
		APROBADA("Aprobada"),
		RECHAZADA("Rechazada"),
		DENEGADA("Error");

		public String getVal() {
			return val;
		}

		String val;
		private BILLPOCKET_RESULTS(String val){this.val = val;}

	}

	public Vista getVista() {
		return this;
	}


}
