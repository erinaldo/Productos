package com.amesol.routelite.vistas;

import java.io.File;
import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.Date;
import java.util.Enumeration;
import java.util.Hashtable;
import java.util.List;

import android.app.DatePickerDialog;
import android.app.Dialog;
import android.content.ContentValues;
import android.content.Intent;
import android.database.Cursor;
import android.net.Uri;
import android.os.Bundle;
import android.os.Environment;
import android.view.Gravity;
import android.view.KeyEvent;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.DatePicker;
import android.widget.ListView;
import android.widget.SimpleCursorAdapter;
import android.widget.SimpleCursorAdapter.ViewBinder;
import android.widget.Spinner;
import android.widget.TextView;

import com.amesol.routelite.R;
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.actividades.Recibos;
import com.amesol.routelite.actividades.ValoresReferencia;
import com.amesol.routelite.datos.Cliente;
import com.amesol.routelite.datos.Dia;
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

import cx.hell.android.pdfview.ChooseFileActivity;

public class ConsultaReporte extends Vista implements IConsultaReporte
{
	
	ConsultarReporte mPresenta;
	Spinner spReporte;
    Spinner spFecha;
	private ListView listClientes;
    Button btFechaIni;
    private Date fechaIni;
    private Cliente clienteSeleccionado;
    ConsultarReporte.TiposFiltroCliente tipoFiltroCliente = ConsultarReporte.TiposFiltroCliente.NoUsado;
    int reporteIDActual; //Esta variable se usa para conservar los filtros al regresar

    boolean vieneDeImprimir = false;
    Button btFechaFin;
    private Date fechaFin;

    static final int DATE_DIALOG_FECHAINI = 999;
    static final int DATE_DIALOG_FECHAFIN = 998;


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
					generarReporte();
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

            tipoFiltroCliente = ConsultarReporte.TiposFiltroCliente.NoUsado  ;

            boolean filtroFecha  = false;
            if(getReporteId() ==Enumeradores.REPORTEA.COBRANZA_GONAC){ // Si es un reporte de cobranza
                ((Button) findViewById(R.id.btnContinuar)).setVisibility(View.INVISIBLE);
                tipoFiltroCliente = ConsultarReporte.TiposFiltroCliente.SeleccionUnicaSinCheck;
            }else if(getReporteId() ==Enumeradores.REPORTEA.PEDIDOS_CONFIRMADOS_SAP) {
                ((Button) findViewById(R.id.btnContinuar)).setVisibility(View.VISIBLE);
                tipoFiltroCliente = ConsultarReporte.TiposFiltroCliente.SeleccionUnicaConCheck;
                filtroFecha = true;
            }else{
                ((Button) findViewById(R.id.btnContinuar)).setVisibility(View.VISIBLE);
                findViewById(R.id.layout_filtro_clientes).setVisibility(View.GONE);
                findViewById(R.id.layout_filtro_fecha).setVisibility(View.GONE);
            }
            //generales
            if (tipoFiltroCliente != ConsultarReporte.TiposFiltroCliente.NoUsado ){
                mPresenta.limpiarChecksCtes(listClientes);
                findViewById(R.id.layout_filtro_clientes).setVisibility(View.VISIBLE);
                mPresenta.setTiposFiltroCliente(tipoFiltroCliente);
                if(listClientes == null){
                    listClientes = (ListView) findViewById(R.id.listClientes);
                    mPresenta.cargaClientes(listClientes);
                    ((TextView)findViewById(R.id.textCliente)).setText(Mensajes.get("XClientes"));
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

    public ListView getListaCtes(){return listClientes;}
    public void setVieneDeImpresion(Boolean vieneDeImpresion){vieneDeImprimir = vieneDeImpresion;}

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


}
