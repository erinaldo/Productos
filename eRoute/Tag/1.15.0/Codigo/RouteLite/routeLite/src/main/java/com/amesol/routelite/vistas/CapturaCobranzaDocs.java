package com.amesol.routelite.vistas;

import java.util.ArrayList;
import java.util.Collection;
import java.util.HashMap;
import java.util.Iterator;
import java.util.List;
import java.util.ListIterator;

import android.app.AlertDialog;
import android.app.Dialog;
import android.app.SearchManager;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.database.Cursor;
import android.graphics.Color;
import android.os.Bundle;
import android.support.annotation.NonNull;
import android.view.KeyEvent;
import android.view.LayoutInflater;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.view.View.OnClickListener;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.CheckBox;
import android.widget.CompoundButton;
import android.widget.CompoundButton.OnCheckedChangeListener;
import android.widget.LinearLayout;
import android.widget.ListView;
import android.widget.SimpleCursorAdapter;
import android.widget.Spinner;
import android.widget.SpinnerAdapter;
import android.widget.TextView;

import com.amesol.routelite.R;
import com.amesol.routelite.actividades.Cobranza;
import com.amesol.routelite.actividades.EnvioPDF;
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.actividades.Recibos;
import com.amesol.routelite.actividades.ValoresReferencia;
import com.amesol.routelite.datos.Abono;
import com.amesol.routelite.datos.Cliente;
import com.amesol.routelite.datos.SEMHist;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.ConfigParametro;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.Enumeradores.RespuestaMsg;
import com.amesol.routelite.presentadores.Enumeradores.Resultados;
import com.amesol.routelite.presentadores.act.CapturarCobranzaDocs;
import com.amesol.routelite.presentadores.interfaces.ICapturaCobranzaDet;
import com.amesol.routelite.presentadores.interfaces.ICapturaCobranzaDocs;
import com.amesol.routelite.utilerias.ControlError;
import com.amesol.routelite.utilerias.Generales;
import com.amesol.routelite.vistas.generico.CobranzaDocsAdapter;

public class CapturaCobranzaDocs extends Vista implements ICapturaCobranzaDocs
{

	String mAccion;
	CapturarCobranzaDocs mPresenta;
	Cobranza.VistaDocumentos[] oDocumentos;
	HashMap<String, Cobranza.VistaCobranza> oParametros = null;
	Boolean imprimiendo = false;

	@SuppressWarnings("unchecked")
	@Override
	public void onCreate(Bundle savedInstanceState)
	{
		try
		{
			super.onCreate(savedInstanceState);
			mAccion = getIntent().getAction();

			setContentView(R.layout.seleccion_transaccion);
			deshabilitarBarra(true);

			setTitulo(Mensajes.get("XCobranza"));

            TextView texto = (TextView) findViewById(R.id.lblSubEmpresa);
            texto.setText(Mensajes.get("SEMNombreEmpresa"));
            texto.setVisibility(View.VISIBLE);
            cargarSubEmpresas();
            Spinner spin = (Spinner) findViewById(R.id.cboSubEmpresa);
            spin.setVisibility(View.VISIBLE);

			Button btn = (Button) findViewById(R.id.btnContinuar);
			btn.setText(Mensajes.get("XContinuar"));
			btn.setOnClickListener(mContinuar);

			mPresenta = new CapturarCobranzaDocs(this, mAccion);
			if (getIntent().getSerializableExtra("parametros") != null)
				oParametros = (HashMap<String, Cobranza.VistaCobranza>) getIntent().getSerializableExtra("parametros");

			if (oParametros != null && (!((Cobranza.VistaCobranza) oParametros.get("Abono")).getABNId().trim().equals("")))
				mPresenta.setABNId(((Cobranza.VistaCobranza) oParametros.get("Abono")).getABNId());
			mPresenta.iniciar();
		}
		catch (Exception e)
		{
			mostrarError(e.getMessage() + ". " + e.getCause().getMessage());
			e.printStackTrace();
		}
	}

	@Override
	public boolean onKeyDown(int keyCode, KeyEvent event)
	{
		switch (keyCode)
		{
			case KeyEvent.KEYCODE_BACK:
				if (!getImprimiendo()) {
					setResult(Resultados.RESULTADO_TERMINAR);
					this.finish();
				}
				return true;
		}
		return super.onKeyDown(keyCode, event);
	}

	private OnClickListener mContinuar = new OnClickListener()
	{
		public void onClick(View v)
		{
			if (mAccion.equals(Enumeradores.Acciones.ACCION_CONSULTAR_COBRANZA))
				consultarDetalleCobranza();
			else if (mAccion.equals(Enumeradores.Acciones.ACCION_GENERAR_COBRANZA) || mAccion.equals(Enumeradores.Acciones.ACCION_GENERAR_COBRANZA_SIMPLE))
				capturarDetalleCobranza();
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
		if (resultCode == Enumeradores.Resultados.RESULTADO_BIEN)
		{
			setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
			//si selecciono terminar, finalizar la captura del abono
			finalizar();
		}else if (requestCode == REQUEST_ENABLE_BT) {
			if (resultCode == RESULT_OK) {
				try {
					imprimiendo = true;
                    switch (Sesion.get(Campo.ImpresionEnCurso).toString()){
                        case "COBRANZA_GONAC":
                            Sesion.set(Campo.FiltroReporteCliente, (Cliente) Sesion.get(Campo.ClienteActual));
                            Recibos.imprimirReporte(Enumeradores.REPORTEA.COBRANZA_GONAC, false, this);
                            break;
                        case "VISTA_DOCS_COBRANZA":
                            Sesion.set(Campo.FiltroReporteCliente, (Cliente) Sesion.get(Campo.ClienteActual));
                            Recibos.imprimirReporte(Enumeradores.REPORTEA.VISTA_DOCS_COBRANZA, false, this);
                            break;
                        case "TICKET":
                            mPresenta.imprimirTicket(mPresenta.getAbonosAsociados());
                            break;
                    }
				} catch (ControlError e) {
					e.Mostrar(this);
				} catch (Exception e) {
					mostrarError(e.getMessage());
				}
			} else {
				mostrarError("No se pudo encender el BT");
			}
		}
		return;
	}

	@Override
	public void respuestaMensaje(RespuestaMsg respuesta, int tipoMensaje)
	{
		// Se asociaron los abonos exitosamente
		if (tipoMensaje == 1)
		{
			//Finalizar sin guardar cambios
			if (mPresenta.getAbonosAsociados() != null && mPresenta.getAbonosAsociados().size()>0) {
				if (!mPresenta.imprimir()) {
					setResultado(Resultados.RESULTADO_BIEN);
					finalizar();
				}
			}
		}else if (tipoMensaje == 2)
		{
			if (respuesta.equals(RespuestaMsg.Si))
			{
				//Imprimir ticket
				try
				{
                    Sesion.set(Campo.ImpresionEnCurso, "TICKET");
					if (!bluetoothEncendido())
					{
						encenderBluetooth();
					}
					else
					{
						imprimiendo = true;
						mPresenta.imprimirTicket(mPresenta.getAbonosAsociados());
					}
					//getVista().mostrarAdvertencia("Recibos generados");
				}
				catch (ControlError e)
				{
					e.Mostrar(this);
				}
				catch (Exception e)
				{
					mostrarError(e.getMessage());
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
				EnvioPDF.enviarSMS(CapturaCobranzaDocs.this);
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
	}
	
	@Override
	public boolean onCreateOptionsMenu(Menu menu)
	{
		MenuInflater inflater = getMenuInflater();
		inflater.inflate(R.menu.menu_captura_totales, menu);

        if (ValoresReferencia.getValor("REPORTEA", "6") != null)
		    menu.getItem(0).setTitle(ValoresReferencia.getDescripcion("REPORTEA", "6"));
        else
            menu.getItem(0).setVisible(false);

        if (ValoresReferencia.getValor("REPORTEA", "30") != null)
            menu.getItem(1).setTitle(Mensajes.get("BTImprimir"));
        else
            menu.getItem(1).setVisible(false);

        menu.getItem(2).setVisible(false);

		return true;
	}
	
	@Override
	public boolean onOptionsItemSelected(MenuItem item)
	{
		switch (item.getItemId())
		{
			case R.id.vista_previa:
				try{
                    Sesion.set(Campo.ImpresionEnCurso, "COBRANZA_GONAC");
                    if (!bluetoothEncendido()) {
                        encenderBluetooth();
                    }
                    else {
                        Sesion.set(Campo.FiltroReporteCliente, (Cliente) Sesion.get(Campo.ClienteActual));
                        Recibos.imprimirReporte(Enumeradores.REPORTEA.COBRANZA_GONAC, false, this);
                    }
				}catch(Exception ex){
					mostrarError("Error al generar reporte de cobranza: " + ex.getMessage());
				}
				break;
            case R.id.calcular_promocion:
                try{
                    Sesion.set(Campo.ImpresionEnCurso, "VISTA_DOCS_COBRANZA");
                    if (!bluetoothEncendido()) {
                        encenderBluetooth();
                    }
                    else {
                        Sesion.set(Campo.FiltroReporteCliente, (Cliente) Sesion.get(Campo.ClienteActual));
                        Recibos.imprimirReporte(Enumeradores.REPORTEA.VISTA_DOCS_COBRANZA, false, this);
                    }
                }catch(Exception ex){
                    mostrarError("Error al imprimir la vista de cobranza: " + ex.getMessage());
                }
                break;
			default:
				break;
		}
		return true;
	}

	@Override
	public void mostrarCobranzaDocs(Cobranza.VistaDocumentos[] oDocumentos)
	{
		try
		{
			//if (oDocumentos.length > 0){
			ListView lista = (ListView) findViewById(R.id.lstTransaccion);
			boolean habilitar = (mAccion.equals(Enumeradores.Acciones.ACCION_GENERAR_COBRANZA) || mAccion.equals(Enumeradores.Acciones.ACCION_GENERAR_COBRANZA_SIMPLE) ? true : false);
			CobranzaDocsAdapter adapter = new CobranzaDocsAdapter(this, R.layout.lista_div2_check, oDocumentos, habilitar, mSeleccion);
			lista.setAdapter(adapter);
			/*
			 * }else{ setResultado(Resultados.RESULTADO_MAL); //,
			 * Mensajes.get("E0558").replace("$0$",
			 * (((String)oConHist.get("CobrarVentas")).equals("1") ?
			 * Mensajes.get("XVenta") : Mensajes.get("XFactura"))))
			 * //mostrarError("No hay documentos por cobrar"); //); finalizar();
			 * }
			 */

		}
		catch (Exception e)
		{
			mostrarError(e.getMessage() + ". " + e.getCause().getMessage());
			e.printStackTrace();
		}
	}

	@Override
	public void setCliente(String cliente)
	{
		TextView texto = (TextView) findViewById(R.id.lblCliente);
		texto.setText(cliente);
	}

	@Override
	public void setRuta(String ruta)
	{
		TextView texto = (TextView) findViewById(R.id.lblRuta);
		texto.setText(Mensajes.get("XRuta") + ": " + ruta);
	}

	@Override
	public void setDia(String dia)
	{
		TextView texto = (TextView) findViewById(R.id.lblDia);
		texto.setText(Mensajes.get("XDiaTrabajo") + ": " + dia);
	}

	private void consultarDetalleCobranza()
	{
		iniciarActividadConResultado(ICapturaCobranzaDet.class, 0, Enumeradores.Acciones.ACCION_CONSULTAR_COBRANZA, oParametros);
	}

	private void capturarDetalleCobranza()
	{
		HashMap<String, ArrayList<String>> oParam = new HashMap<String, ArrayList<String>>();
		ArrayList<String> trpIds = mPresenta.getTransProdIds();

		if (trpIds == null || trpIds.size() == 0)
		{
			mostrarError(Mensajes.get("E0039"));
			return;
		}
        else if (mAccion.equals(Enumeradores.Acciones.ACCION_GENERAR_COBRANZA_SIMPLE)){
            if (trpIds.size() > 1)
            {
                mostrarError(Mensajes.get("E0932"));
                return;
            }
        }
		try{
			List<Abono> sdAbonosConSaldoNotaCredito = Consultas.ConsultasAbono.AbonosConSaldoTipoNotaCredito();
			if (sdAbonosConSaldoNotaCredito.size()>0){
				mostrarNotasCredito(sdAbonosConSaldoNotaCredito);
			}else {
				oParam.put("TransProdIds", trpIds);
				//iniciarActividadConResultado(ICapturaCobranzaDet.class, 0, Enumeradores.Acciones.ACCION_GENERAR_COBRANZA, oParam);
                iniciarActividadConResultado(ICapturaCobranzaDet.class, 0, mAccion, oParam);
			}
		}catch (Exception ex){
			if (ex.getMessage() != null) {
				mostrarError(ex.getMessage());
			}else{
				mostrarError("Error al iniciar cobranza");
			}
		}
}

	public OnCheckedChangeListener mSeleccion = new OnCheckedChangeListener()
	{

		@Override
		public void onCheckedChanged(CompoundButton buttonView, boolean isChecked)
		{
            ListView lista = (ListView) findViewById(R.id.lstTransaccion);
            if (((CobranzaDocsAdapter)lista.getAdapter()).getCargandoLista()){
                return;
            }
			if (isChecked)
				mPresenta.insertTransProdId((String) buttonView.getTag());
			else
				mPresenta.removeTransProdId((String) buttonView.getTag());


            if(lista.getAdapter() != null){
                ((CobranzaDocsAdapter)lista.getAdapter()).setEstatus((String) buttonView.getTag(), isChecked);
            }

		}
	};

	@Override
	public void mostrarNotasCredito(List<Abono> sdNotasCredito){
		LayoutInflater inflater = (LayoutInflater) CapturaCobranzaDocs.this
				.getSystemService(Context.LAYOUT_INFLATER_SERVICE);

		View dialogView = inflater.inflate(R.layout.dialogo_grid, null);

		AlertDialog.Builder builder = new AlertDialog.Builder(this);
		TextView lblTituloGeneral = (TextView) dialogView.findViewById(R.id.lblTituloDialogo);
		lblTituloGeneral.setText("Notas de crédito disponibles"/*Mensajes.get("XDesgloseImpPromo")*/);

		((LinearLayout)dialogView.findViewById(R.id.layout_titulos)).setVisibility(View.INVISIBLE);

		final ListView modeList = (ListView) dialogView.findViewById(R.id.lstGrid);
		modeList.setBackgroundColor(Color.WHITE);


		modeList.setAdapter(new AdapterAbonosXAplicar(dialogView.getContext(), R.layout.lista_abonos_nota_credito, sdNotasCredito ));


		builder.setPositiveButton(Mensajes.get("BTAceptar"), new DialogInterface.OnClickListener() {
			public void onClick(DialogInterface dialog, int id) {
				try {
					List<Abono> lstSeleccionados = ((AdapterAbonosXAplicar) modeList.getAdapter()).getSeleccionados();
					if (lstSeleccionados.size()>0){
						mPresenta.asociarCobranza(lstSeleccionados);
					}else{
						mostrarAdvertencia(Mensajes.get("E0161", Mensajes.get("XAbono")));
					}
				}catch (Exception ex){
					if (ex.getMessage() != null) {
						mostrarError(ex.getMessage());
					}else{
						mostrarError("Error al asociar el abono");
					}
				}
			}
		});
		builder.setNeutralButton(Mensajes.get("BTCancelar"), new DialogInterface.OnClickListener() {
			public void onClick(DialogInterface dialog, int id) {
				try {
					HashMap<String, ArrayList<String>> oParam = new HashMap<String, ArrayList<String>>();
					oParam.put("TransProdIds", mPresenta.getTransProdIds());
					//iniciarActividadConResultado(ICapturaCobranzaDet.class, 0, Enumeradores.Acciones.ACCION_GENERAR_COBRANZA, oParam);
                    iniciarActividadConResultado(ICapturaCobranzaDet.class, 0, mAccion, oParam);
				}catch (Exception ex){
					if (ex.getMessage() != null) {
						mostrarError(ex.getMessage());
					}else{
						mostrarError("Error al asociar el abono");
					}
				}
				dialog.dismiss();
			}
		});
		builder.setView(dialogView);
		final Dialog dialog = builder.create();

		dialog.show();

	}

	public class AdapterAbonosXAplicar extends ArrayAdapter<Abono> {

		private int idLayout;
		private HashMap<Abono,Boolean> seleccionados;
		private float total;
		Context contexto;
		//private CONHist conHist;
		private List<Abono> abonos;

		public AdapterAbonosXAplicar(Context context, int idResource, List<Abono> abonos){
			super(context, idResource, abonos);
			contexto = context;
			idLayout = idResource;
			this.abonos = abonos;
			seleccionados = new HashMap<Abono, Boolean>();
		}

		public float getTotal(){
			return total;
		}

		public List<Abono> getSeleccionados(){
			List<Abono> lstSeleccionados= new ArrayList<Abono>();
			for (Abono key : seleccionados.keySet()) {
				if (seleccionados.get(key)) {
					lstSeleccionados.add(key);
				}
			}
			return lstSeleccionados;
		}

		public List<Abono> getItems(){
			return abonos;
		}

		@Override
		public View getView(final int position, View convertView, ViewGroup parent)
		{
			View fila = convertView;

			if (convertView == null)
			{
				LayoutInflater inflater = (CapturaCobranzaDocs.this).getLayoutInflater();
				fila = inflater.inflate(idLayout, null);
			}
			final Abono abono= getItem(position);
			if (!seleccionados.containsKey(abono)){
				seleccionados.put(abono,false);
			}

			((TextView)fila.findViewById(R.id.lblFolio)).setText(abono.Folio);
			((TextView)fila.findViewById(R.id.lblFecha)).setText(Generales.getFormatoFecha(abono.FechaCreacion, "dd/MM/yyyy"));
			((TextView)fila.findViewById(R.id.lblSaldo)).setText("$ ".concat(Generales.getFormatoDecimal(abono.Saldo, "#,###,##0.00")));
			((CheckBox) fila.findViewById(R.id.chkSeleccion)).setChecked(seleccionados.get(abono));

			((CheckBox)fila.findViewById(R.id.chkSeleccion)).setOnCheckedChangeListener(new CompoundButton.OnCheckedChangeListener()
			{

				@Override
				public void onCheckedChanged(CompoundButton check, boolean checked)
				{
					if (seleccionados.containsKey(abono) &&  seleccionados.get(abono) != checked ){
						seleccionados.put(abono, checked);
						notifyDataSetChanged();
					}
				}
			});

			return fila;
		}
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
		EnvioPDF.enviarTicketPDF(CapturaCobranzaDocs.this, tipoMensaje);
	}

    private void cargarSubEmpresas() {
        try{
            ISetDatos isSubEmpresas;
            isSubEmpresas = Consultas.ConsultasTransProd.obtenerSubEmpresasSpinner();

            Spinner spin = (Spinner) findViewById(R.id.cboSubEmpresa);
            SimpleCursorAdapter adapterSubEmpresa = new SimpleCursorAdapter(this, android.R.layout.simple_spinner_item, (Cursor) isSubEmpresas.getOriginal(), new String[]
                    {SearchManager.SUGGEST_COLUMN_TEXT_1}, new int[]
                    {android.R.id.text1});
            adapterSubEmpresa.setDropDownViewResource(android.R.layout.simple_spinner_item);
            spin.setAdapter(adapterSubEmpresa);
            spin.setOnItemSelectedListener(mSubEmpresa);
        }catch (Exception ex){
            mostrarError(ex.getMessage() + ". " + ex.getCause().getMessage());
            ex.printStackTrace();
        }

    }

    public String getcboSubEmpresId() {
        Spinner spSubEmpresa = (Spinner) findViewById(R.id.cboSubEmpresa);
        String sSubEmpresaId = null;
        if (spSubEmpresa.getSelectedItem() != null) {
            Cursor c = (Cursor) ((SimpleCursorAdapter) spSubEmpresa.getAdapter()).getItem(spSubEmpresa.getSelectedItemPosition());
            sSubEmpresaId = c.getString(1);
        }

        return sSubEmpresaId;
    }

    private AdapterView.OnItemSelectedListener mSubEmpresa = new AdapterView.OnItemSelectedListener() {
        @Override
        public void onItemSelected(AdapterView<?> arg0, View arg1, int arg2, long arg3) {
            mPresenta.ObtenerDocumentosSubEmpresa(String.valueOf(getcboSubEmpresId()));
        }

        @Override
        public void onNothingSelected(AdapterView<?> arg0) {
        }
    };
}
