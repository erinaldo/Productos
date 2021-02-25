package com.amesol.routelite.vistas;

import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.Date;
import java.util.HashMap;
import java.util.Hashtable;
import java.util.Iterator;
import java.util.LinkedList;
import java.util.Map;

import android.annotation.SuppressLint;
import android.app.Activity;
import android.app.AlertDialog;
import android.app.DatePickerDialog;
import android.app.Dialog;
import android.content.ContentValues;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.graphics.Color;
import android.os.Bundle;
import android.text.format.DateFormat;
import android.view.ContextMenu;
import android.view.ContextMenu.ContextMenuInfo;
import android.view.KeyEvent;
import android.view.LayoutInflater;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.view.View.OnClickListener;
import android.view.ViewGroup;
import android.widget.AdapterView.AdapterContextMenuInfo;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.DatePicker;
import android.widget.EditText;
import android.widget.ImageButton;
import android.widget.ListAdapter;
import android.widget.ListView;
import android.widget.TableRow;
import android.widget.TextView;

import com.amesol.routelite.R;
import com.amesol.routelite.actividades.Cobranza;
import com.amesol.routelite.actividades.Cobranza.VistaDetalle;
import com.amesol.routelite.actividades.EnvioPDF;
import com.amesol.routelite.actividades.Folios;
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.controles.NumberPicker;
import com.amesol.routelite.datos.TransProdDetalle;
import com.amesol.routelite.datos.utilerias.ConfigParametro;
import com.amesol.routelite.datos.utilerias.MOTConfiguracion;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.Enumeradores.RespuestaMsg;
import com.amesol.routelite.presentadores.act.CapturarCobranzaDet;
import com.amesol.routelite.presentadores.interfaces.ICapturaCobranzaDet;
import com.amesol.routelite.presentadores.interfaces.ICapturaInventario;
import com.amesol.routelite.presentadores.interfaces.ICapturaMontoPorDoc;
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

	HashMap<String,Float > hmDesgloseImporte = null;
	boolean bDesglosarImporteDoctos = false;

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

            TextView lbSaldoDescIni = (TextView) findViewById(R.id.lblSaldoDescIni);
            lbSaldoDescIni.setText(Mensajes.get("XSaldoInicialDesc"));

            TextView lbSaldoDescFin = (TextView) findViewById(R.id.lblSaldoDescFin);
            lbSaldoDescFin.setText(Mensajes.get("XSaldoRestanteDesc"));

			TextView lbFormaPagoTit = (TextView) findViewById(R.id.lblFormaPagoTit);
			lbFormaPagoTit.setText(Mensajes.get("XFormaPago"));

			TextView lbTotal = (TextView) findViewById(R.id.lblTotal);
			lbTotal.setText(Mensajes.get("ABNTotal"));

			ImageButton btnAgregar = (ImageButton) findViewById(R.id.btnAgregarPago);
			btnAgregar.setOnClickListener(mAgregar);

            Button btnDescuento = (Button) findViewById(R.id.btnDescuentos);
            btnDescuento.setText(Mensajes.get("XDescProntoPago"));
            btnDescuento.setOnClickListener(mVerDescuentos);

			Button btnContinuar = (Button) findViewById(R.id.btnContinuar);
			btnContinuar.setText(Mensajes.get("XContinuar"));
			btnContinuar.setOnClickListener(mContinuar);

			if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).existeParametro("DesglosarImpDoctosCobranza"))
				bDesglosarImporteDoctos =  ((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("DesglosarImpDoctosCobranza").toString().equals("1");


			Button btnDesglosarImporte = (Button) findViewById(R.id.btnDesglosarImporte );
			if (bDesglosarImporteDoctos){
				btnDesglosarImporte.setVisibility(View.VISIBLE);
				btnDesglosarImporte.setText(Mensajes.get("BTDesglosarImporte"));
				btnDesglosarImporte.setOnClickListener(mDesglosarImporte);
			}else{
				btnDesglosarImporte.setVisibility(View.GONE);
			}


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

    private OnClickListener mVerDescuentos = new OnClickListener()
    {
        @Override
        public void onClick(View v)
        {
            try {

                LayoutInflater inflater = (LayoutInflater) CapturaCobranzaDet.this
                        .getSystemService(Context.LAYOUT_INFLATER_SERVICE);

                View dialogView = inflater.inflate(R.layout.dialog_desc_pp_cobranza, null);

                AlertDialog.Builder builder = new AlertDialog.Builder(v.getContext());
                TextView lblTituloGeneral = (TextView) dialogView.findViewById(R.id.lblTituloDialogo);
                lblTituloGeneral.setText(Mensajes.get("XDescuentosProntoPago"));

                ListView lstPromoProntoPago = (ListView) dialogView.findViewById(R.id.lstDescProntoPago);
                lstPromoProntoPago.setBackgroundColor(Color.WHITE);
                @SuppressWarnings("unchecked")
                ArrayList<vistaDesgloseProntoPago> desgloseProntoPago = mPresenta.obtenerDesgloseProntoPago();

                if (desgloseProntoPago != null) {
                    final adapterDesgloseProntoPago adapter = new adapterDesgloseProntoPago(v.getContext(), R.layout.elemento_desc_pp_cobranza, desgloseProntoPago);
                    lstPromoProntoPago.setAdapter(adapter);
                    setListViewHeightBasedOnChildren(lstPromoProntoPago);
                }

                builder.setPositiveButton("Aceptar", new DialogInterface.OnClickListener() {
                    public void onClick(DialogInterface dialog, int id) {
                        dialog.dismiss();
                    }
                });
                builder.setView(dialogView);
                final Dialog dialog = builder.create();

                dialog.show();

            } catch (Exception ex) {
                mostrarError(ex.getMessage());
            }
        }
    };

	private OnClickListener mContinuar = new OnClickListener()
	{

		@Override
		public void onClick(View v)
		{
			if (mAccion.equals(Enumeradores.Acciones.ACCION_GENERAR_COBRANZA))
			{
				if (bDesglosarImporteDoctos){
					if (hmDesgloseImporte==null || hmDesgloseImporte.size()<=0){
						mostrarAdvertencia(Mensajes.get("I0319"));
						return;
					}else{
						mPresenta.setImportesxDoc(hmDesgloseImporte);
					}
				}
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

	private OnClickListener mDesglosarImporte = new OnClickListener()
	{

		@Override
		public void onClick(View v)
		{
			if (mPresenta.getTotalAbonos() <=0){
				mostrarAdvertencia(Mensajes.get("E0173","Pago"));
				return;
			}
			HashMap<String, Object> oParametros = new HashMap<String, Object>();
			oParametros.put("TransProdIds", mPresenta.getTransProdIds());
			oParametros.put("PorAplicar", mPresenta.getTotalAbonos());
			//oParametros.put("PorAplicar", )
			/*oParametros.put("TipoValidarExistencia", mPresenta.getTipoValidacionExistencia());
			if (inventarioID!= null && !inventarioID.equals("")) {
				oParametros.put("InventarioID", inventarioID);
			}*/
			iniciarActividadConResultado(ICapturaMontoPorDoc.class, Enumeradores.Solicitudes.SOLICITUD_CAPTURAR_MONTO_POR_DOC_COBRANZA, Enumeradores.Acciones.ACCION_CAPTURA_MONTO_POR_DOC_COBRANZA,oParametros);

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
            else if (requestCode == Enumeradores.Solicitudes.SOLICITUD_ENVIAR_PDF)
            {
                if (resultCode == Enumeradores.Resultados.RESULTADO_BIEN) {
                    imprimiendo = true;

                    Sesion.remove(Campo.ArchivoPDF);
                    Sesion.remove(Campo.ArchivosPDFxEnviar);
                    Sesion.remove(Campo.ArchivosPDFxGenerar);

                    try
                    {
                        mPresenta.imprimirTicket();
                    }
                    catch (Exception e)
                    {
                        EnvioPDF.guardarArchivosNoGenerados();
                        this.mostrarError(e.getMessage(), 0);
                    }

                    if (Sesion.get(Campo.ArchivosPDFxEnviar) != null)
                    {
                        EnvioPDF.enviarArchivos(CapturaCobranzaDet.this);
                    }
                    else {
                        this.setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
                        this.finalizar();
                    }
                }
                else{
                    this.setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
                    this.finalizar();
                }
            }
            else if (requestCode == Enumeradores.Solicitudes.SOLICITUD_ENVIAR_PDF_SERVER){
                if (resultCode == Enumeradores.Resultados.RESULTADO_BIEN) {
                    if (Short.valueOf(((MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion)).get("MensajeImpresion").toString()) == 3) {
                        String sURLServer = Sesion.get(Campo.URLServerPDF).toString();
                        Hashtable<String, ContentValues> htArchivosPDF = (Hashtable<String, ContentValues>)Sesion.get(Campo.ArchivosPDFxEnviar);
                        Iterator<Map.Entry<String, ContentValues>> it =  htArchivosPDF.entrySet().iterator();
                        Map.Entry<String, ContentValues> entry = it.next();
                        Sesion.set(Campo.ArchivoPDF, entry.getKey());
                        Sesion.set(Campo.TransaccionActualPDF, entry.getValue());
                        EnvioPDF.enviarSMS(CapturaCobranzaDet.this);
                    }
                    else{
                        this.mostrarMensaje(Mensajes.get("I0307").replace("$0$", Mensajes.get("XCorreoElectronico")), 0, 0);
                    }
                }
                else{
                    EnvioPDF.guardarArchivosNoEnviados();
                    if (data != null) {
                        String mensajeError = (String) data.getExtras().getString("mensajeIniciar");
                        if (mensajeError != null) {
                            this.mostrarError(mensajeError, 0);
                        }
                    }
                    else {
                        this.setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
                        this.finalizar();
                    }
                }
            }
            else if (requestCode == Enumeradores.Solicitudes.SOLICITUD_ENVIAR_SMS){
                if (resultCode == Enumeradores.Resultados.RESULTADO_BIEN) {
                    EnvioPDF.agregarArchivoEnviado();

                    Sesion.remove(Campo.ArchivoPDF);
                    String sArchivoPDF = EnvioPDF.obtenerSiguienteArchivo();
                    if (sArchivoPDF != "")
                    {
                        EnvioPDF.EnviarSiguiente(CapturaCobranzaDet.this, sArchivoPDF);
                    }
                    else
                    {
                        this.mostrarMensaje(Mensajes.get("I0307").replace("$0$", "SMS"), 0, 0);
                    }
                }
                else {
                    this.mostrarPreguntaSiNo(Mensajes.get("P0254"), 3);
                }
            }else if(requestCode == Enumeradores.Solicitudes.SOLICITUD_CAPTURAR_MONTO_POR_DOC_COBRANZA){
				if(resultCode == Enumeradores.Resultados.RESULTADO_BIEN){
					if (Sesion.get(Campo.ResultadoActividad) != null)
					{
						hmDesgloseImporte=(HashMap<String, Float>) Sesion.get(Campo.ResultadoActividad);
						Sesion.remove(Campo.ResultadoActividad);
						//captura.setFinBusqueda();
					}
				}
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
					if (!bluetoothEncendido())
					{
						encenderBluetooth();
					}
					else
					{
						imprimiendo = true;
						mPresenta.imprimirTicket();
					}
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
        else if (tipoMensaje == 3){
            if (respuesta.equals(RespuestaMsg.Si)) {
                EnvioPDF.enviarSMS(CapturaCobranzaDet.this);
            }
            else{
                EnvioPDF.guardarArchivosNoEnviados();
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

    @Override
    public void mostrarDescuento(){
        //rowLabelDescuento
        TableRow rowLabelDescuento = (TableRow)findViewById(R.id.rowLabelDescuento);
        TableRow rowTextDescuento = (TableRow)findViewById(R.id.rowTextDescuento);
        Button btnDescuentos = (Button)findViewById(R.id.btnDescuentos);

        rowLabelDescuento.setVisibility(View.VISIBLE);
        rowTextDescuento.setVisibility(View.VISIBLE);
        btnDescuentos.setVisibility(View.VISIBLE);
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

    @Override
    public void imprimirPDF(short tipoMensaje){
        EnvioPDF.enviarTicketPDF(CapturaCobranzaDet.this, tipoMensaje);
    }

    public static class vistaDesgloseProntoPago {
        private String Folio;
        private String Total;
        private String Saldo;
        private String FechaCobranza;
        private String Descuento;
        private String Importe;
        private String SaldoDesc;

        public vistaDesgloseProntoPago(String folio, String total, String saldo, String fechaCobranza,String descuento, String importe, String saldoDesc){
            Folio = folio;
            Total = total;
            Saldo = saldo;
            FechaCobranza = fechaCobranza;
            Descuento = descuento;
            Importe = importe;
            SaldoDesc = saldoDesc;

        }
        public String getFolio() {
            return Folio;
        }

        public String getTotal() {
            return Total;
        }

        public String getSaldo() {
            return Saldo;
        }

        public String getFechaCobranza() {
            return FechaCobranza;
        }

        public String getDescuento() {
            return Descuento;
        }

        public String getImporte() {
            return Importe;
        }

    }

    private class adapterDesgloseProntoPago extends ArrayAdapter<vistaDesgloseProntoPago> {
        int textViewResourceId;
        Context context;

        public adapterDesgloseProntoPago(Context context, int textViewResourceId, ArrayList<vistaDesgloseProntoPago> objects) {
            super(context, textViewResourceId, objects);
            this.textViewResourceId = textViewResourceId;
            this.context = context;
        }

        @Override
        public View getView(int position, View convertView, ViewGroup parent) {
            View fila = convertView;

            if (convertView == null) {
                LayoutInflater inflater = ((Activity) context).getLayoutInflater();
                fila = inflater.inflate(textViewResourceId, null);
            }
            vistaDesgloseProntoPago documento = getItem(position);

            TextView texto = (TextView) fila.findViewById(R.id.lblFolio);
            texto.setText(documento.Folio);

            texto = (TextView) fila.findViewById(R.id.lblTotal);
            texto.setText(Mensajes.get("XTotalMin") + ":");

            texto = (TextView) fila.findViewById(R.id.lblTotalValue);
            texto.setText(documento.Total);

            texto = (TextView) fila.findViewById(R.id.lblSaldo);
            texto.setText(Mensajes.get("XSaldo") + ":");

            texto = (TextView) fila.findViewById(R.id.lblSaldoValue);
            texto.setText(documento.Saldo);

            texto = (TextView) fila.findViewById(R.id.lblDescuento);
            texto.setText(Mensajes.get("XDescuento") + ":");

            texto = (TextView) fila.findViewById(R.id.lblDescuentoValue);
            texto.setText(documento.Descuento);

            texto = (TextView) fila.findViewById(R.id.lblImporte);
            texto.setText(Mensajes.get("XImporte") + ":");

            texto = (TextView) fila.findViewById(R.id.lblImporteValue);
            texto.setText(documento.Importe);

            texto = (TextView) fila.findViewById(R.id.lblFechaCobranza);
            texto.setText(Mensajes.get("XCobranza") + ":");

            texto = (TextView) fila.findViewById(R.id.lblFechaCobranzaValue);
            texto.setText(documento.FechaCobranza);

            texto = (TextView) fila.findViewById(R.id.lblSaldoDesc);
            texto.setText("Saldo Desc:"); //Mensajes.get("XSaldoDesc") + ":");

            texto = (TextView) fila.findViewById(R.id.lblSaldoDescValue);
            texto.setText(documento.SaldoDesc);


            return fila;
        }
    }

    private void setListViewHeightBasedOnChildren(ListView listView) {
        ListAdapter listAdapter = listView.getAdapter();
        if (listAdapter == null) {
            // pre-condition
            return;
        }

        int totalHeight = 0;
        int desiredWidth = View.MeasureSpec.makeMeasureSpec(listView.getWidth(), View.MeasureSpec.AT_MOST);
        for (int i = 0; i < listAdapter.getCount(); i++) {
            View listItem = listAdapter.getView(i, null, listView);
            listItem.measure(View.MeasureSpec.makeMeasureSpec(0, View.MeasureSpec.UNSPECIFIED), View.MeasureSpec.makeMeasureSpec(0, View.MeasureSpec.UNSPECIFIED));
            totalHeight += listItem.getMeasuredHeight();
        }

        ViewGroup.LayoutParams params = listView.getLayoutParams();
        params.height = totalHeight + (listView.getDividerHeight() * (listAdapter.getCount() - 1));

        listView.setLayoutParams(params);
        listView.requestLayout();
        listView.setTag(true);
    }
}
