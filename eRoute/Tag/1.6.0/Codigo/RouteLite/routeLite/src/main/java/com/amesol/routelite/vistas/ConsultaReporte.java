package com.amesol.routelite.vistas;

import java.io.File;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.Date;
import java.util.Enumeration;
import java.util.Hashtable;
import java.util.List;

import android.app.DatePickerDialog;
import android.app.Dialog;
import android.app.SearchManager;
import android.content.ContentValues;
import android.content.Intent;
import android.database.Cursor;
import android.net.Uri;
import android.os.Bundle;
import android.os.Environment;
import android.util.Log;
import android.view.Gravity;
import android.view.KeyEvent;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.CheckBox;
import android.widget.CompoundButton;
import android.widget.DatePicker;
import android.widget.LinearLayout;
import android.widget.ListView;
import android.widget.RadioButton;
import android.widget.SimpleCursorAdapter;
import android.widget.SimpleCursorAdapter.ViewBinder;
import android.widget.Spinner;
import android.widget.TextView;
import android.widget.Toast;

import com.amesol.routelite.R;
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.actividades.Recibos;
import com.amesol.routelite.actividades.ValoresReferencia;
import com.amesol.routelite.datos.Cliente;
import com.amesol.routelite.datos.Dia;
import com.amesol.routelite.datos.Ruta;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.ConfigParametro;
import com.amesol.routelite.datos.utilerias.ConfiguracionLocal;
import com.amesol.routelite.datos.utilerias.MOTConfiguracion;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.ArchivoConfiguracion.CampoConfiguracion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.Enumeradores.RespuestaMsg;
import com.amesol.routelite.presentadores.IVista;
import com.amesol.routelite.presentadores.act.ConsultarReporte;
import com.amesol.routelite.presentadores.interfaces.IConsultaReporte;
import com.amesol.routelite.utilerias.Generales;
import com.amesol.routelite.vistas.generico.DialogoProgreso;

import org.apache.commons.lang3.StringUtils;

import cx.hell.android.pdfview.ChooseFileActivity;

public class ConsultaReporte extends Vista implements IConsultaReporte
{
	
	ConsultarReporte mPresenta;
	Spinner spReporte;
    Spinner spFecha;
    Spinner spDiaClave;
	private ListView listClientes;
    Button btFechaIni;
    private Date fechaIni;
    private Cliente clienteSeleccionado;
    ConsultarReporte.TiposFiltroCliente tipoFiltroCliente = ConsultarReporte.TiposFiltroCliente.NoUsado;
    int reporteIDActual; //Esta variable se usa para conservar los filtros al regresar
    RadioButton rbGeneral;
    RadioButton rbDetallado;

    boolean vieneDeImprimir = false;
    Button btFechaFin;
    private Date fechaFin;

    static final int DATE_DIALOG_FECHAINI = 999;
    static final int DATE_DIALOG_FECHAFIN = 998;

    private ArrayList<Cliente> clientes;


	@Override
	public void onCreate(Bundle savedInstanceState)
	{	
		try{
			super.onCreate(savedInstanceState);

			setContentView(R.layout.consulta_reporte);
			deshabilitarBarra(true);
			
			setTitulo(Mensajes.get("XReportes"));
			
			TextView texto = (TextView) this.findViewById(R.id.txtReporte);
			texto.setText(Mensajes.get("XReporte"));


			Button btn = (Button) this.findViewById(R.id.btnContinuar);
			btn.setText(Mensajes.get("BTContinuar"));
			btn.setOnClickListener(new OnClickListener(){
				@Override
				public void onClick(View v)
				{
                    try {
                        if(reporteIDActual == Enumeradores.REPORTEA.COBRANZA_GENERICO) {
                            if (mPresenta.clienteSeleccionado(clientes))
                                if(mPresenta.existenDatosReporteCobranza(clientes))
                                    generarReporte();
                                else
                                    mostrarAdvertencia(Mensajes.get("E0034"));
                            else
                                mostrarAdvertencia(Mensajes.get("E0215",Mensajes.get("XCliente")));
                        } else
                            generarReporte();
                    } catch (Exception e){
                        mostrarError(e.getMessage());
                        e.printStackTrace();
                    }

				}
			});
			
			spReporte = (Spinner) this.findViewById(R.id.SpReporte);
			llenarSpiner(spReporte, "REPORTEA");
            spReporte.setOnItemSelectedListener(mSeleccionaReporte);

            texto = (TextView) this.findViewById(R.id.textFecha);
            texto.setText(Mensajes.get("XFecha"));

            spFecha = (Spinner)  this.findViewById(R.id.SpComparador);
            llenarSpiner(spFecha, "BFNUMERI");
            spFecha.setOnItemSelectedListener(mSeleccionaComparadorFecha);

            btFechaIni = (Button) this.findViewById(R.id.btnFechaIni);
            btFechaIni.setOnClickListener(mFechaIni);
            fechaIni = Generales.getFechaActual();
            btFechaIni.setText(new SimpleDateFormat("dd/MMM/yyyy").format(fechaIni.getTime()));

            btFechaFin = (Button)this.findViewById(R.id.btnFechaFin);
            btFechaFin.setOnClickListener(mFechaFin);
            fechaFin = Generales.getFechaActual();
            btFechaFin.setText(new SimpleDateFormat("dd/MMM/yyyy").format(fechaFin.getTime()));

            rbGeneral = (RadioButton) this.findViewById(R.id.rbGeneral);
            rbGeneral.setText(Mensajes.get("XGeneral"));

            rbDetallado = (RadioButton) this.findViewById(R.id.rbDetallado);
            rbDetallado.setText(Mensajes.get("XDetallado"));



			mPresenta = new ConsultarReporte(this);
			mPresenta.iniciar();

		}catch(Exception e){
			mostrarError(e.getMessage());
			e.printStackTrace();
		}
	}

    @Override
    public void onDestroy(){
        super.onDestroy();
        //limpiar las variables de sesion de reportes
        Sesion.remove(Campo.FiltroReporteCliente);
        Sesion.remove(Campo.FiltroReporteFechas);
        Sesion.remove(Campo.FiltroReporteFechaIni);
        Sesion.remove(Campo.FiltroReporteFechaFin);
    }
    public void onWindowFocusChanged(boolean hasFocus)
    {

        super.onWindowFocusChanged(hasFocus);
        if (hasFocus)
        {
            if (vieneDeImprimir) {
                if (listClientes != null && listClientes.getAdapter() != null) {

                    if(listClientes.getCount() >0){
                        listClientes.smoothScrollToPositionFromTop(0,0);
                    }
                    ((ArrayAdapter) listClientes.getAdapter()).notifyDataSetChanged();
                }
                vieneDeImprimir = false;
            }

        }
        // Toast.makeText(context, text, duration).show();
    }

    private AdapterView.OnItemSelectedListener mSeleccionaReporte = new AdapterView.OnItemSelectedListener()
    {
        @Override
        public void onItemSelected(AdapterView<?> arg0, View arg1, int arg2, long arg3)
        {
            if (reporteIDActual == getReporteId()){
                return;
            }

            reporteIDActual = getReporteId();
            //limpiar variables de filtros
            clienteSeleccionado = null;
            fechaIni = Generales.getFechaActual();
            fechaFin = Generales.getFechaActual();

            tipoFiltroCliente = ConsultarReporte.TiposFiltroCliente.NoUsado;
            findViewById(R.id.layout_filtro_todos_clientes).setVisibility(View.GONE);

            boolean filtroFecha  = false;
            if(getReporteId() ==Enumeradores.REPORTEA.COBRANZA_GONAC){ // Si es un reporte de cobranza
                ((Button) findViewById(R.id.btnContinuar)).setVisibility(View.INVISIBLE);
                tipoFiltroCliente = ConsultarReporte.TiposFiltroCliente.SeleccionUnicaSinCheck;
            }else if(getReporteId() ==Enumeradores.REPORTEA.PEDIDOS_CONFIRMADOS_SAP) {
                ((Button) findViewById(R.id.btnContinuar)).setVisibility(View.VISIBLE);
                tipoFiltroCliente = ConsultarReporte.TiposFiltroCliente.SeleccionUnicaConCheck;
                filtroFecha = true;
            }else if(getReporteId() == Enumeradores.REPORTEA.EFECTIVIDAD_RUTA) {
                ((Button) findViewById(R.id.btnContinuar)).setVisibility(View.VISIBLE);
                findViewById(R.id.layout_filtro_detallado_general).setVisibility(View.GONE);
                validarFueraFrecuencia();
            }else if(getReporteId() == Enumeradores.REPORTEA.COBRANZA_GENERICO) {
                findViewById(R.id.layout_filtro_todos_clientes).setVisibility(View.VISIBLE);
                ((Button) findViewById(R.id.btnContinuar)).setVisibility(View.VISIBLE);
                tipoFiltroCliente = ConsultarReporte.TiposFiltroCliente.MultiSeleccion;
            }else if(getReporteId() == Enumeradores.REPORTEA.RESUMEN_MOVIMIENTOS_GENERICO){
                findViewById(R.id.layout_filtro_detallado_general).setVisibility(View.VISIBLE);
                validarFueraFrecuencia();
                ((Button) findViewById(R.id.btnContinuar)).setVisibility(View.VISIBLE);
            }
            else{
                ((Button) findViewById(R.id.btnContinuar)).setVisibility(View.VISIBLE);
                findViewById(R.id.layout_filtro_clientes).setVisibility(View.GONE);
                findViewById(R.id.layout_filtro_fecha).setVisibility(View.GONE);
                findViewById(R.id.layout_filtro_dia_clave).setVisibility(View.GONE);
                findViewById(R.id.layout_filtro_detallado_general ).setVisibility(View.GONE);
            }
            //generales
            if (tipoFiltroCliente != ConsultarReporte.TiposFiltroCliente.NoUsado ){
                mPresenta.limpiarChecksCtes(listClientes,clientes);
                findViewById(R.id.layout_filtro_clientes).setVisibility(View.VISIBLE);
                mPresenta.setTiposFiltroCliente(tipoFiltroCliente);
                    listClientes = (ListView) findViewById(R.id.listClientes);
                    clientes = obtenerClientes();
                    mPresenta.cargaClientes(listClientes,clientes);
                    ((TextView)findViewById(R.id.textCliente)).setText(Mensajes.get("XClientes"));
                    if(tipoFiltroCliente != ConsultarReporte.TiposFiltroCliente.MultiSeleccion){
                        listClientes.setOnItemClickListener(new AdapterView.OnItemClickListener() {
                            @Override
                            public void onItemClick(AdapterView<?> arg0, View arg1, int arg2, long arg3) {
                                // Continuar con el reporte
                                if (tipoFiltroCliente == ConsultarReporte.TiposFiltroCliente.SeleccionUnicaSinCheck) {
                                    clienteSeleccionado = (Cliente) arg0.getAdapter().getItem(arg2);
                                    generarReporte();
                                }
                            }
                        });
                    } else {
                        listClientes.setOnItemClickListener(new AdapterView.OnItemClickListener() {
                            @Override
                            public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
                                clientes.get(position).Enviado = !clientes.get(position).Enviado;
                                ((ArrayAdapter<Cliente>) listClientes.getAdapter()).notifyDataSetChanged();
                            }
                        });
                        ((CheckBox) findViewById(R.id.seleccionarTodosCheck)).setText(Mensajes.get("MDB0125"));
                        ((CheckBox) findViewById(R.id.seleccionarTodosCheck)).setOnCheckedChangeListener(new CompoundButton.OnCheckedChangeListener() {
                            @Override
                            public void onCheckedChanged(CompoundButton buttonView, boolean isChecked) {
                                mPresenta.seleccionarTodos(listClientes, clientes, isChecked);
                            }
                        });
                    }
                listClientes.setClickable(tipoFiltroCliente == ConsultarReporte.TiposFiltroCliente.SeleccionUnicaSinCheck);
            }else{
                findViewById(R.id.layout_filtro_clientes).setVisibility(View.GONE);
            }

            if (filtroFecha ){
                btFechaIni.setText(new SimpleDateFormat("dd/MMM/yyyy").format(fechaIni.getTime()));
                btFechaFin.setText(new SimpleDateFormat("dd/MMM/yyyy").format(fechaFin.getTime()));
                findViewById(R.id.layout_filtro_fecha).setVisibility(View.VISIBLE);
            }else{
                findViewById(R.id.layout_filtro_fecha).setVisibility(View.GONE);
            }
        }
        @Override
        public void onNothingSelected(AdapterView<?> arg0)
        {
            findViewById(R.id.layout_filtro_clientes).setVisibility(View.GONE);
            findViewById(R.id.layout_filtro_fecha).setVisibility(View.GONE);
            findViewById(R.id.layout_filtro_dia_clave).setVisibility(View.GONE);
            findViewById(R.id.layout_filtro_detallado_general ).setVisibility(View.GONE);
        }
    };

    private AdapterView.OnItemSelectedListener mSeleccionaComparadorFecha = new AdapterView.OnItemSelectedListener()
    {
        @Override
        public void onItemSelected(AdapterView<?> arg0, View arg1, int arg2, long arg3)
        {
            switch ((int)spFecha.getSelectedItemId()){
                    case Enumeradores.BFNUMERI.ENTRE:
                    btFechaFin.setEnabled(true);
                    break;
                default:
                    btFechaFin.setEnabled(false);
                    break;
            }
        }
        @Override
        public void onNothingSelected(AdapterView<?> arg0)
        {
            btFechaFin.setEnabled(false);
        }
    };

    private OnClickListener mFechaIni = new OnClickListener()
    {

        @SuppressWarnings("deprecation")
        @Override
        public void onClick(View v)
        {
            showDialog(DATE_DIALOG_FECHAINI);
        }
    };

    private OnClickListener mFechaFin = new OnClickListener()
    {

        @SuppressWarnings("deprecation")
        @Override
        public void onClick(View v)
        {
            showDialog(DATE_DIALOG_FECHAFIN);
        }
    };

    @SuppressWarnings("deprecation")
    @Override
    protected Dialog onCreateDialog(int id)
    {
        switch (id)
        {
            case DATE_DIALOG_FECHAINI:
                return new DatePickerDialog(this, mFechaIniListener,  fechaIni.getYear() + 1900, fechaIni.getMonth(), fechaIni.getDate());
            case DATE_DIALOG_FECHAFIN:
                return new DatePickerDialog(this, mFechaFinListener,  fechaFin.getYear() + 1900, fechaFin.getMonth(), fechaFin.getDate());
        }
        return null;
    }

    @SuppressWarnings("deprecation")
    @Override
    protected void onPrepareDialog(int id, Dialog dialog)
    {
        switch (id)
        {
            case DATE_DIALOG_FECHAINI:
                ((DatePickerDialog) dialog).updateDate(fechaIni.getYear() + 1900, fechaIni.getMonth(), fechaIni.getDate());
                break;
            case DATE_DIALOG_FECHAFIN:
                ((DatePickerDialog) dialog).updateDate(fechaFin.getYear() + 1900, fechaFin.getMonth(), fechaFin.getDate());
                break;

        }
    }

    private DatePickerDialog.OnDateSetListener mFechaIniListener = new DatePickerDialog.OnDateSetListener()
    {
        // when dialog box is closed, below method will be called.
        @SuppressWarnings("deprecation")
        @Override
        public void onDateSet(DatePicker view, int selectedYear, int selectedMonth, int selectedDay)
        {
            try
            {

                Calendar tmp = Calendar.getInstance();
                tmp.setTime((new SimpleDateFormat("dd/MM/yyyy")).parse(new SimpleDateFormat("dd/MM/").format(new Date(selectedYear, selectedMonth, selectedDay)) + (new Date(selectedYear, selectedMonth, selectedDay)).getYear()));
                fechaIni = tmp.getTime();
                btFechaIni.setText(new SimpleDateFormat("dd/MMM/yyyy").format(fechaIni.getTime()) );
            }
            catch (Exception ex)
            {
                mostrarError(ex.getMessage());
            }
        }
    };

    private DatePickerDialog.OnDateSetListener mFechaFinListener = new DatePickerDialog.OnDateSetListener()
    {
        // when dialog box is closed, below method will be called.
        @SuppressWarnings("deprecation")
        @Override
        public void onDateSet(DatePicker view, int selectedYear, int selectedMonth, int selectedDay)
        {
            try
            {
                Calendar tmp = Calendar.getInstance();
                tmp.setTime((new SimpleDateFormat("dd/MM/yyyy")).parse(new SimpleDateFormat("dd/MM/").format(new Date(selectedYear, selectedMonth, selectedDay)) + (new Date(selectedYear, selectedMonth, selectedDay)).getYear()));
                fechaFin = tmp.getTime();
                btFechaFin.setText(new SimpleDateFormat("dd/MMM/yyyy").format(fechaFin.getTime()) );
            }
            catch (Exception ex)
            {
                mostrarError(ex.getMessage());
            }
        }
    };


	private void generarReporte(){
		if(spReporte.getSelectedItemPosition() == 0){
			mostrarAdvertencia(Mensajes.get("BE0001").replace("$0$", Mensajes.get("XReporte")));
			return;
		}
        if(findViewById(R.id.layout_filtro_fecha).getVisibility() == View.VISIBLE){
            if ((int)spFecha.getSelectedItemId() == Enumeradores.BFNUMERI.ENTRE){
                if (fechaFin.compareTo(fechaIni) < 0){
                    mostrarError(Mensajes.get("E0377"));
                    return;
                }
            }
        }

		mPresenta.generarReporte();
	}
	
/*	private void generarReporteAsync(){
		final DialogoProgreso dialog = new DialogoProgreso(this);
		dialog.setProgressStyle(DialogoProgreso.STYLE_SPINNER);
		dialog.setMessage("Generando reporte ...");
		dialog.setCancelable(false);
		dialog.show();

		Runnable accion = new Runnable()
		{
			public void run()
			{
				//runOnUiThread(new Runnable()
				//{
					//public void run()
					//{
						mPresenta.generarReporte(null);	
					//}
				//});
			}
		};
		final Thread reporte = new Thread(accion);
		
		Runnable mensaje = new Runnable()
		{
			public void run()
			{
				while (reporte.isAlive())
				{
				}
				dialog.dismiss();
				runOnUiThread(new Runnable()
				{
					public void run()
					{
						Enumeration<String> e = ((Hashtable<String, ContentValues>) Sesion.get(Campo.ArchivosGenerados)).keys();
						String archivo = "";
						while (e.hasMoreElements()){
							archivo = e.nextElement();	
						}
						ConfiguracionLocal conf = (ConfiguracionLocal) Sesion.get(Campo.ConfiguracionLocal);
						File impresion = new File(conf.get(CampoConfiguracion.DIRECTORIO_TRABAJO).toString());
						File file = new File(impresion.getAbsolutePath()+"/"+""+".pdf");
						Intent intent = new Intent();
						intent.setDataAndType(Uri.fromFile(file), "application/pdf");
						//intent.setClass(((Context) this), PDFViewer.class);
						intent.setClassName("com.amesol.routelite.vistas", "PDFViewer");
						intent.setAction("android.intent.action.VIEW");
						startActivity(intent);
					}
				});
			}
		};
		new Thread(mensaje).start();
		reporte.start();
	}*/
	//region IMPLEMENTACIONES ICONSULTAREPORTE
	public int getReporteId(){
		return (int) spReporte.getSelectedItemId();
	}

    public Date getFechaIni(){
        return fechaIni;
    }

    public Date getFechaFin(){
        return fechaFin;
    }

    public int getBFNUMERI(){
        return (int) spFecha.getSelectedItemId();
    }

    public Cliente getCliente(){
    return clienteSeleccionado;
}

    @Override
    public ArrayList<Cliente> getClientes() {
        return clientes;
    }

    @Override
    public String getDiaClave() {
        return spDiaClave.getSelectedItem().toString();
    }

    public ListView getListaCtes(){return listClientes;}
    public void setVieneDeImpresion(Boolean vieneDeImpresion){vieneDeImprimir = vieneDeImpresion;}

    @Override
    public int getGeneralDetallado() {
        int seleccion = 0;

        if(rbGeneral.isChecked() == true)
            seleccion = 1;

        return seleccion;
    }

    public void setCliente(Cliente cliente){
        clienteSeleccionado = cliente;
    }
    //endregion
	
	@Override
	public boolean onKeyDown(int keyCode, KeyEvent event)
	{
		switch (keyCode){
			case KeyEvent.KEYCODE_BACK:
				finalizar();
				return true;
		}
		return super.onKeyDown(keyCode, event);
	}

	@Override
	public void resultadoActividad(int requestCode, int resultCode, Intent data)
	{

	}

	@Override
	public void respuestaMensaje(RespuestaMsg respuesta, int tipoMensaje)
	{
		
	}
	
	@SuppressWarnings("deprecation")
	public void llenarSpiner(Spinner control,String nombreValor)
	{
		try
		{
            ISetDatos valores = Consultas.ConsultasValorReferencia.obtenerValores(nombreValor, null);
			Cursor unidad = (Cursor) valores.getOriginal();
			startManagingCursor(unidad);
			SimpleCursorAdapter adapter = new SimpleCursorAdapter(this, android.R.layout.simple_spinner_item, unidad, new String[]
			{ "VAVClave" }, new int[]
			{ android.R.id.text1 });
			adapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
			adapter.setViewBinder(new llenarSpinner(nombreValor));
			control.setAdapter(adapter);

		}
		catch (Exception e)
		{
			e.printStackTrace();
		}

	}

	private class llenarSpinner implements ViewBinder
	{

        String nombreVAR = "";

        public llenarSpinner(String valorReferencia){
            nombreVAR = valorReferencia;
        }

		@Override
		public boolean setViewValue(View view, Cursor cursor, int columnIndex)
		{
			int viewId = view.getId();
			switch (viewId)
			{
				case android.R.id.text1:
					TextView combo = (TextView) view;
					combo.setGravity(Gravity.CENTER);
					combo.setText(ValoresReferencia.getDescripcion(nombreVAR, cursor.getString(cursor.getColumnIndex("VAVClave"))));
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
	public void iniciar()
	{

	}

    private void validarFueraFrecuencia(){

        try {
            ArrayList<String> diasClaveArray = new ArrayList<>();
            ISetDatos diasClave = Consultas.ConsultasTransProd.obtenerDiasFrecuencia();
            while (diasClave.moveToNext())
                diasClaveArray.add(diasClave.getString(0));

            if(diasClaveArray.size() > 0) {
                spDiaClave = (Spinner) this.findViewById(R.id.SpDiaClave);
                ArrayAdapter<String> diaClaveAdapter = new ArrayAdapter<String>(this,android.R.layout.simple_spinner_item,diasClaveArray);
                diaClaveAdapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
                spDiaClave.setAdapter(diaClaveAdapter);
                this.findViewById(R.id.layout_filtro_dia_clave).setVisibility(View.VISIBLE);

                if(diasClaveArray.size() < 2)
                    spDiaClave.setEnabled(false);
                else
                    spDiaClave.setEnabled(true);
            }

        } catch (Exception e){
            Log.e(ConsultaReporte.class.getName(), e.getMessage(), e);
        }
    }

    private ArrayList<Cliente> obtenerClientes(){

        try {
            ArrayList<Cliente> clientes = new ArrayList<>();

            ISetDatos setDatos = Consultas.ConsultasCliente.obtenerTodos(null, (Ruta) Sesion.get(Campo.RutaActual), null);
            Cliente cliente;
            while(setDatos.moveToNext()){
                cliente = new Cliente();
                cliente.ClienteClave = setDatos.getString(SearchManager.SUGGEST_COLUMN_INTENT_DATA);
                cliente.NombreCorto = setDatos.getString(SearchManager.SUGGEST_COLUMN_TEXT_1);
                cliente.NombreContacto = setDatos.getString(SearchManager.SUGGEST_COLUMN_TEXT_2);
                cliente.Enviado = false; //Se reutiliza el campo para no crear otra clase, pero se usa para algo distinto
                clientes.add(cliente);
            }
            setDatos.close();

            return clientes;
        } catch (Exception e) {
            Log.e(ConsultaReporte.class.getName(),e.getMessage(),e);
            return null;
        }

    }

    @Override
    protected void onResume() {
        super.onResume();
        if(clientes != null) {
            mPresenta.limpiarChecksCtes(listClientes, clientes);
            ((CheckBox) findViewById(R.id.seleccionarTodosCheck)).setChecked(false);
        }
    }

}
