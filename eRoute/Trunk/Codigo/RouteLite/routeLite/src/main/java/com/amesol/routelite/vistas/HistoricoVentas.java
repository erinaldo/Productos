package com.amesol.routelite.vistas;

import android.app.AlertDialog;
import android.app.DatePickerDialog;
import android.app.Dialog;
import android.app.SearchManager;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.database.Cursor;
import android.os.Bundle;
import android.view.ContextMenu;
import android.view.Gravity;
import android.view.KeyEvent;
import android.view.LayoutInflater;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.widget.AdapterView;
import android.widget.Button;
import android.widget.DatePicker;
import android.widget.ListView;
import android.widget.SimpleCursorAdapter;
import android.widget.Spinner;
import android.widget.TextView;
import android.view.ViewGroup;

import com.amesol.routelite.R;
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.actividades.ValoresReferencia;
import com.amesol.routelite.datos.Cliente;
import com.amesol.routelite.datos.Dia;
import com.amesol.routelite.datos.TransProd;
import com.amesol.routelite.datos.TransProdDetalle;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.CONHist;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.act.HistoricosVentas;
import com.amesol.routelite.presentadores.interfaces.ICapturaPedidoSugerido;
import com.amesol.routelite.presentadores.interfaces.IHistoricoEstadisticas;
import com.amesol.routelite.presentadores.interfaces.IHistoricoVentas;
import com.amesol.routelite.utilerias.Generales;

import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.Date;
import java.util.HashMap;
import java.util.Iterator;
import java.util.Map;

public class HistoricoVentas extends Vista implements IHistoricoVentas {

    HistoricosVentas mPresenta;
    String mAccion;
    ISetDatos filtrosFecha;
    ISetDatos stTransProds;
    private Date fechaIni;
    private Date fechaFin;
    private ListView mLvVentas = null;
    private Button btnAceptar=null;

    @SuppressWarnings("deprecation")
    @Override
    public void onCreate(Bundle savedInstanceState) {
        try {
            super.onCreate(savedInstanceState);
            mAccion = getIntent().getAction();

            setContentView(R.layout.consulta_historico_ventas);
            deshabilitarBarra(true);
            setTitulo(Mensajes.get("MDBHistorico"));

            TextView mTexto;
            mTexto = (TextView) findViewById(R.id.lblFecha);
            mTexto.setVisibility(View.VISIBLE);
            mTexto.setText(Mensajes.get("XFecha"));

            Button btn = (Button) findViewById(R.id.btnFechaIni);
            //btn.setText(Mensajes.get("XFechaInicial"));
            btn.setOnClickListener(mFechaIni);
            fechaIni = ((Dia) Sesion.get(Sesion.Campo.DiaActual)).FechaCaptura;
            btn.setText(new SimpleDateFormat("dd/MMM/yyyy").format(fechaIni));

            btn = (Button) findViewById(R.id.btnFechaFin);
            btn.setEnabled(false);
            //btn.setText(Mensajes.get("XFechaFinal"));
            btn.setOnClickListener(mFechaFin);
            fechaFin = ((Dia) Sesion.get(Sesion.Campo.DiaActual)).FechaCaptura;
            btn.setText(new SimpleDateFormat("dd/MMM/yyyy").format(fechaFin));

            mTexto = (TextView) findViewById(R.id.txtCol1);
            mTexto.setVisibility(View.GONE);

            mTexto = (TextView) findViewById(R.id.txtCol2);
            mTexto.setVisibility(View.VISIBLE);
            mTexto.setText(Mensajes.get("XVenta"));
            mTexto.setGravity(Gravity.CENTER);

            mTexto = (TextView) findViewById(R.id.txtCol3);
            mTexto.setVisibility(View.VISIBLE);
            mTexto.setText(Mensajes.get("XFecha"));
            mTexto.setGravity(Gravity.CENTER);

            mTexto = (TextView) findViewById(R.id.txtCol4);
            mTexto.setVisibility(View.VISIBLE);
            mTexto.setText(Mensajes.get("XTotalMin"));
            mTexto.setGravity(Gravity.CENTER);

            mTexto = (TextView) findViewById(R.id.txtCol5);
            mTexto.setVisibility(View.VISIBLE);
            mTexto.setText(Mensajes.get("XSaldo"));
            mTexto.setGravity(Gravity.CENTER);

            mTexto = (TextView) findViewById(R.id.txtCol6);
            mTexto.setVisibility(View.GONE);

            btn = (Button) findViewById(R.id.btnEstadisticas);
            btn.setText(Mensajes.get("ERMHIS_FormHistoricoVtasE"));
            btn.setEnabled(false);
            btn.setOnClickListener(mEstadisticas);

            obtenerValoresPorReferencia();
            cargarFiltroFecha();

            mLvVentas = (ListView) findViewById(R.id.lv_ventas);
            mLvVentas.setItemsCanFocus(false);
            mLvVentas.setOnItemLongClickListener(menu);
            registerForContextMenu(mLvVentas);

            mPresenta = new HistoricosVentas(this, mAccion);
            mPresenta.iniciar();
        } catch (Exception e) {
            mostrarError(e.getMessage() + ". " + e.getCause().getMessage());
            e.printStackTrace();
        }
    }

    @Override
    public void iniciar() {
    }

    @Override
    public void resultadoActividad(int requestCode, int resultCode, Intent data) {
        if (requestCode == Enumeradores.Solicitudes.SOLICITUD_MOSTRAR_ESTADISTICAS){
            if (resultCode == Enumeradores.Resultados.RESULTADO_BIEN){
                if (Sesion.get(Sesion.Campo.ResultadoActividad) != null){
                    Sesion.remove(Sesion.Campo.ResultadoActividad);
                }
            }else if (resultCode == Enumeradores.Resultados.RESULTADO_MAL){
                if (data != null){
                    String mensajeError = (String) data.getExtras().getString("mensajeIniciar");
                    if (!mensajeError.equals("")){
                        mostrarError(mensajeError);
                    }
                }
            }
        }
    }

    @Override
    public void respuestaMensaje(Enumeradores.RespuestaMsg respuesta, int tipoMensaje) {
    }

    private void salir() {
            setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
            finalizar();
    }

    @Override
    public boolean onKeyDown(int keyCode, KeyEvent event) {
        switch (keyCode) {
            case KeyEvent.KEYCODE_BACK:
                salir();
                return true;
        }
        return super.onKeyDown(keyCode, event);
    }

    private void obtenerValoresPorReferencia() throws Exception {
        filtrosFecha = Consultas.ConsultasValorReferencia.obtenerValoresReferencia("BFNUMERI", "");
        startManagingCursor((Cursor) filtrosFecha.getOriginal());
    }

    private void cargarFiltroFecha() {
        Spinner spin = (Spinner) findViewById(R.id.spFiltroFecha);
        SimpleCursorAdapter adapterFiltroFecha = new SimpleCursorAdapter(this, android.R.layout.simple_spinner_item, (Cursor) filtrosFecha.getOriginal(), new String[]
                {SearchManager.SUGGEST_COLUMN_TEXT_1 }, new int[]
                { android.R.id.text1 });
        adapterFiltroFecha .setDropDownViewResource(android.R.layout.simple_spinner_item);
        spin.setAdapter(adapterFiltroFecha);
        spin.setOnItemSelectedListener(mTipoFiltroFecha);
    }

    private AdapterView.OnItemSelectedListener mTipoFiltroFecha = new AdapterView.OnItemSelectedListener() {
        @Override
        public void onItemSelected(AdapterView<?> arg0, View arg1, int arg2, long arg3) {
            Cursor item = (Cursor) arg0.getItemAtPosition(arg2);

            if (item.getInt(0) == Enumeradores.BFNUMERI.ENTRE){
                Button btnFechaFin = (Button) findViewById(R.id.btnFechaFin);
                btnFechaFin.setEnabled(true);
            } else {
                Button btnFechaFin = (Button) findViewById(R.id.btnFechaFin);
                btnFechaFin.setEnabled(false);
            }

            ActualizaLVVentas();
        }
        @Override
        public void onNothingSelected(AdapterView<?> arg0) {
        }
    };

    private DatePickerDialog.OnDateSetListener mFechaIniListener = new DatePickerDialog.OnDateSetListener(){
        @SuppressWarnings("deprecation")
        @Override
        public void onDateSet(DatePicker view, int selectedYear, int selectedMonth, int selectedDay) {
            try {
                Calendar tmp = Calendar.getInstance();
                tmp.setTime((new SimpleDateFormat("dd/MM/yyyy")).parse(new SimpleDateFormat("dd/MM/").format(new Date(selectedYear, selectedMonth, selectedDay)) + (new Date(selectedYear, selectedMonth, selectedDay)).getYear()));

                fechaIni = tmp.getTime();
                Button btnFechaIni = (Button) findViewById(R.id.btnFechaIni);
                btnFechaIni.setText(new SimpleDateFormat("dd/MMM/yyyy").format(fechaIni));

                ActualizaLVVentas();

            } catch (Exception ex) {
                mostrarError(ex.getMessage());
            }
        }

    };

    static final int DATE_DIALOG_INI = 998;
    private View.OnClickListener mFechaIni = new View.OnClickListener() {
        @SuppressWarnings("deprecation")
        @Override
        public void onClick(View v) {
            showDialog(DATE_DIALOG_INI);
        }
    };

    private DatePickerDialog.OnDateSetListener mFechaFinListener = new DatePickerDialog.OnDateSetListener()
    {
        @SuppressWarnings("deprecation")
        @Override
        public void onDateSet(DatePicker view, int selectedYear, int selectedMonth, int selectedDay) {
            try {
                Calendar tmp = Calendar.getInstance();
                tmp.setTime((new SimpleDateFormat("dd/MM/yyyy")).parse(new SimpleDateFormat("dd/MM/").format(new Date(selectedYear, selectedMonth, selectedDay)) + (new Date(selectedYear, selectedMonth, selectedDay)).getYear()));

                if (tmp.getTime().before(fechaIni)){
                    mostrarAdvertencia(Mensajes.get("E0352").replace("$0$", new SimpleDateFormat("dd/MMM/yyyy").format(fechaIni)));
                    return;
                }

                fechaFin = tmp.getTime();
                Button btnFechaFin = (Button) findViewById(R.id.btnFechaFin);
                btnFechaFin.setText(new SimpleDateFormat("dd/MMM/yyyy").format(fechaFin));

                ActualizaLVVentas();

            } catch (Exception ex) {
                mostrarError(ex.getMessage());
            }
        }
    };

    static final int DATE_DIALOG_FIN = 999;
    private View.OnClickListener mFechaFin = new View.OnClickListener() {
        @SuppressWarnings("deprecation")
        @Override
        public void onClick(View v) {
            showDialog(DATE_DIALOG_FIN);
        }
    };

    @SuppressWarnings("deprecation")
    @Override
    protected Dialog onCreateDialog(int id) {
        switch (id) {
            case DATE_DIALOG_INI:
                int anio = fechaIni.getYear() + 1900;
                int mes = fechaIni.getMonth();
                int dia = fechaIni.getDate();
                return new DatePickerDialog(this, mFechaIniListener, anio, mes, dia);
            case DATE_DIALOG_FIN:
                int anio2 = fechaFin.getYear() + 1900;
                int mes2 = fechaFin.getMonth();
                int dia2 = fechaFin.getDate();
                return new DatePickerDialog(this, mFechaFinListener, anio2, mes2, dia2);
        }
        return null;
    }

    @SuppressWarnings("deprecation")
    @Override
    protected void onPrepareDialog(int id, Dialog dialog) {
        switch (id) {
            case DATE_DIALOG_INI:
                int anio = fechaIni.getYear() + 1900;
                int mes = fechaIni.getMonth();
                int dia = fechaIni.getDate();
                ((DatePickerDialog) dialog).updateDate(anio, mes, dia);
                break;
            case DATE_DIALOG_FIN:
                int anio2 = fechaFin.getYear() + 1900;
                int mes2 = fechaFin.getMonth();
                int dia2 = fechaFin.getDate();
                ((DatePickerDialog) dialog).updateDate(anio2, mes2, dia2);
                break;
        }
    }

    @Override
    @SuppressWarnings("deprecation")
    public void ActualizaLVVentas(){
        try{
            stTransProds = Consultas.ConsultaHistoricoVentas.obtenerVentas(getFiltroFecha(),fechaIni,fechaFin);
            Cursor cProductos = (Cursor) stTransProds.getOriginal();
            startManagingCursor(cProductos);
            try{
                SimpleCursorAdapter adapter = new SimpleCursorAdapter(this, R.layout.lista_simple_hor6, cProductos, new String[]
                        { "_id", "Venta", "Fecha", "Total", "Saldo" }, new int[]
                        { R.id.txtCol1, R.id.txtCol2, R.id.txtCol3, R.id.txtCol4, R.id.txtCol5 });
                adapter.setViewBinder(new vistaVentas());
                mLvVentas.setAdapter(adapter);

                Button btn = (Button) findViewById(R.id.btnEstadisticas);
                if (mLvVentas.getCount()>0) {
                    btn.setEnabled(true);
                }else{
                    btn.setEnabled(false);
                }

            }catch (Exception e){
                mostrarError(e.getMessage());
            }
        }catch (Exception ex){
            mostrarError(ex.getMessage());
        }
    }

    private class vistaVentas implements SimpleCursorAdapter.ViewBinder{
        @Override
        public boolean setViewValue(View view, Cursor cursor, int columnIndex){
            int viewId = view.getId();
            switch (viewId){
                case R.id.txtCol1:
                    TextView combo = (TextView) view;
                    combo.setText(cursor.getString(cursor.getColumnIndex("_id")));
                    combo.setVisibility(View.GONE);
                    break;
                case R.id.txtCol2:
                    combo = (TextView) view;
                    combo.setText(cursor.getString(cursor.getColumnIndex("Venta")));
                    break;
                case R.id.txtCol3:
                    combo = (TextView) view;
                    combo.setText(cursor.getString(cursor.getColumnIndex("Fecha")));
                    break;
                case R.id.txtCol4:
                    view.setVisibility(View.VISIBLE);
                    combo = (TextView) view;
                    combo.setText(Generales.getFormatoDecimal(cursor.getFloat(cursor.getColumnIndex("Total")), "#,##0.00"));
                    combo.setGravity(Gravity.RIGHT);
                    break;
                case R.id.txtCol5:
                    view.setVisibility(View.VISIBLE);
                    combo = (TextView) view;
                    combo.setText(Generales.getFormatoDecimal(cursor.getFloat(cursor.getColumnIndex("Saldo")), "#,##0.00"));
                    combo.setGravity(Gravity.RIGHT);
                    break;
                case R.id.txtCol6:
                    view.setVisibility(View.INVISIBLE);
                    break;
                default:
                    TextView texto = (TextView) view;
                    texto.setText(cursor.getString(columnIndex));
                    break;
            }
            return true;
        }
    }

    public Integer getFiltroFecha() {
        Spinner spnFiltroFecha = (Spinner) findViewById(R.id.spFiltroFecha);
        Integer FiltroFecha = null;
        if (spnFiltroFecha.getSelectedItem() != null) {
            Cursor c = (Cursor) ((SimpleCursorAdapter) spnFiltroFecha.getAdapter()).getItem(spnFiltroFecha.getSelectedItemPosition());
            FiltroFecha = c.getInt(1);
        }
        if (!(spnFiltroFecha.getCount() > 1))
            spnFiltroFecha.setEnabled(false);
        return FiltroFecha;
    }

    public AdapterView.OnItemLongClickListener menu = new AdapterView.OnItemLongClickListener(){
        @Override
        public boolean onItemLongClick(AdapterView<?> arg0, View arg1, int arg2, long arg3){
            openContextMenu(mLvVentas);
            return true;
        }
    };

    @Override
    public void onCreateContextMenu(ContextMenu menu, View v, ContextMenu.ContextMenuInfo menuInfo){
        super.onCreateContextMenu(menu, v, menuInfo);
        MenuInflater inflater = getMenuInflater();
        inflater.inflate(R.menu.context_historicoventas, menu);

        menu.getItem(0).setTitle(Mensajes.get("XDetalle"));
    }

    @Override
    public boolean onContextItemSelected(MenuItem item){
        switch (item.getItemId()){
            case R.id.detalles:
                try{
                    Cursor ventas = (Cursor) (((SimpleCursorAdapter) mLvVentas.getAdapter()).getCursor());
                    String stransprodid = "";
                    if( ((CONHist) Sesion.get(Sesion.Campo.CONHist)).get("TipoCobranza").equals("1") || ((((CONHist) Sesion.get(Sesion.Campo.CONHist)).get("TipoCobranza").equals("2") && ((Cliente) Sesion.get(Sesion.Campo.ClienteActual)).TipoFiscal==1))){
                        stransprodid = getTransProdFacturas("'"+ventas.getString(ventas.getColumnIndex("_id"))+"'");
                    }
                    else {
                        stransprodid = getTransProdFacturas("'"+ventas.getString(ventas.getColumnIndex("_id"))+"'");
                    }
                    if (stransprodid.length() > 0) {
                        stransprodid = stransprodid.substring(1, stransprodid.length() - 1);
                    }
                    LayoutInflater inflater = (LayoutInflater) HistoricoVentas.this
                            .getSystemService(Context.LAYOUT_INFLATER_SERVICE);

                    View dialogViewVentaDetalle = inflater.inflate(R.layout.dialog_simple_hor6, null);
                    AlertDialog.Builder builder = new AlertDialog.Builder(HistoricoVentas.this);
                    TextView mTexto;
                    mTexto = (TextView) dialogViewVentaDetalle.findViewById(R.id.txtCol1);
                    mTexto.setVisibility(View.GONE);

                    mTexto = (TextView) dialogViewVentaDetalle.findViewById(R.id.txtCol2);
                    mTexto.setVisibility(View.VISIBLE);
                    mTexto.setText(Mensajes.get("XProducto"));
                    mTexto.setGravity(Gravity.CENTER);
                    ViewGroup.LayoutParams param = mTexto.getLayoutParams();
                    param.width = 50;
                    mTexto.setLayoutParams(param);

                    mTexto = (TextView) dialogViewVentaDetalle.findViewById(R.id.txtCol3);
                    mTexto.setVisibility(View.VISIBLE);
                    mTexto.setText(Mensajes.get("XCantidad"));
                    mTexto.setGravity(Gravity.CENTER);

                    mTexto = (TextView) dialogViewVentaDetalle.findViewById(R.id.txtCol4);
                    mTexto.setVisibility(View.VISIBLE);
                    mTexto.setText(Mensajes.get("XUnidad"));
                    mTexto.setGravity(Gravity.CENTER);

                    mTexto = (TextView) dialogViewVentaDetalle.findViewById(R.id.txtCol5);
                    mTexto.setVisibility(View.VISIBLE);
                    mTexto.setText(Mensajes.get("XPrecio"));
                    mTexto.setGravity(Gravity.CENTER);

                    ListView lista_ventas = (ListView) dialogViewVentaDetalle.findViewById(R.id.lstAgenda);

                    ISetDatos detalle = Consultas.ConsultaHistoricoVentas.obtenerDetalleVenta(stransprodid);

                    Cursor cVentasDetalle = (Cursor) detalle.getOriginal();
                    startManagingCursor(cVentasDetalle);
                    SimpleCursorAdapter adapter = new SimpleCursorAdapter(this, R.layout.lista_simple_hor6, cVentasDetalle, new String[] { "_id", "Producto", "Cantidad", "Unidad", "Precio" }, new int[]
                            { R.id.txtCol1, R.id.txtCol2, R.id.txtCol3, R.id.txtCol4, R.id.txtCol5 });
                    adapter.setViewBinder(new vistaVentasDetalle());
                    lista_ventas.setAdapter(adapter);

                    builder.setNegativeButton(Mensajes.get("XCancelar"),new DialogInterface.OnClickListener(){
                        @Override
                        public void onClick(DialogInterface dialog, int which){
                            dialog.dismiss();
                        }

                    });
                    builder.setView(dialogViewVentaDetalle);
                    final Dialog dialog = builder.create();
                    dialog.setOnShowListener(new DialogInterface.OnShowListener() {
                        @Override
                        public void onShow(DialogInterface dialog) {
                            btnAceptar = ((AlertDialog) dialog)
                                    .getButton(AlertDialog.BUTTON_NEGATIVE);
                        }
                    });

                    dialog.show();
                }
                catch (Exception ex){
                    mostrarError(ex.getMessage());
                }

                return true;
            default:
                return super.onOptionsItemSelected(item);
        }
    }

    private class vistaVentasDetalle implements SimpleCursorAdapter.ViewBinder{
        @Override
        public boolean setViewValue(View view, Cursor cursor, int columnIndex){
            int viewId = view.getId();
            switch (viewId){
                case R.id.txtCol1:
                    TextView combo = (TextView) view;
                    combo.setText(cursor.getString(cursor.getColumnIndex("_id")));
                    combo.setVisibility(View.GONE);
                    break;
                case R.id.txtCol2:
                    combo = (TextView) view;
                    combo.setText(cursor.getString(cursor.getColumnIndex("Producto")));
                    combo.setVisibility(View.VISIBLE);
                    ViewGroup.LayoutParams param = combo.getLayoutParams();
                    param.width = 50;
                    combo.setLayoutParams(param);
                    combo.setMaxLines(2);
                    break;
                case R.id.txtCol3:
                    combo = (TextView) view;
                    combo.setText(cursor.getString(cursor.getColumnIndex("Cantidad")));
                    combo.setVisibility(View.VISIBLE);
                    break;
                case R.id.txtCol4:
                    combo = (TextView) view;
                    String mUnidad = ValoresReferencia.getDescripcion("UNIDADV", cursor.getString(cursor.getColumnIndex("Unidad")));
                    combo.setText(mUnidad);
                    combo.setVisibility(View.VISIBLE);
                    break;
                case R.id.txtCol5:
                    view.setVisibility(View.VISIBLE);
                    combo = (TextView) view;
                    combo.setText(Generales.getFormatoDecimal(cursor.getFloat(cursor.getColumnIndex("Precio")), "#,##0.00"));
                    combo.setGravity(Gravity.RIGHT);
                    break;
                default:
                    TextView texto = (TextView) view;
                    texto.setText(cursor.getString(columnIndex));
                    texto.setVisibility(View.INVISIBLE);
                    break;
            }
            return true;
        }
    }

    private View.OnClickListener mEstadisticas = new View.OnClickListener(){

        @Override
        public void onClick(View v){
            final HashMap<String, Object> parametros = new HashMap<String, Object>();
            parametros.put("Transprods", getTransProdIds());
            parametros.put("NoDocumentos", mLvVentas.getCount());

            iniciarActividadConResultado(IHistoricoEstadisticas.class, Enumeradores.Solicitudes.SOLICITUD_MOSTRAR_ESTADISTICAS, Enumeradores.Acciones.ACCION_MOSTRAR_ESTADISTICAS, parametros);
        }
    };

    public String getTransProdIds(){
        String TransProdIds = "";
        stTransProds.moveToFirst();
        do{
            TransProdIds += "'" + stTransProds.getString("_id") + "',";
        }while(stTransProds.moveToNext());

        if (TransProdIds.length() > 0){
            TransProdIds = TransProdIds.substring(0, TransProdIds.length() - 1);
        }

        TransProdIds = getTransProdFacturas(TransProdIds);

        return TransProdIds;
    }

    public String getTransProdFacturas(String facturaID){
        String TransProdIds = facturaID;

        if( ((CONHist) Sesion.get(Sesion.Campo.CONHist)).get("TipoCobranza").equals("1") || ((((CONHist) Sesion.get(Sesion.Campo.CONHist)).get("TipoCobranza").equals("2") && ((Cliente) Sesion.get(Sesion.Campo.ClienteActual)).TipoFiscal==1))){
            return TransProdIds;
            /*try{
                ISetDatos transProd = Consultas.ConsultaHistoricoVentas.obtenerTransProdPedido(facturaID);
                TransProdIds = "";
                while(transProd.moveToNext()){
                    TransProdIds += "'" + transProd.getString("TransProdID") + "',";
                }

                if (TransProdIds.length() > 0){
                    TransProdIds = TransProdIds.substring(0, TransProdIds.length() - 1);
                }

            }catch(Exception ex){
                mostrarError(ex.getMessage());
            }*/
        }
        else {
            try{
                ISetDatos transProd = Consultas.ConsultaHistoricoVentas.obtenerTransProdFactura(facturaID);
                TransProdIds = "";
                while(transProd.moveToNext()){
                    TransProdIds += "'" + transProd.getString("TransProdID") + "',";
                }

                if (TransProdIds.length() > 0){
                    TransProdIds = TransProdIds.substring(0, TransProdIds.length() - 1);
                }

            }catch(Exception ex){
                mostrarError(ex.getMessage());
            }
        }

        return TransProdIds;
    }
}
