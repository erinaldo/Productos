package com.amesol.routelite.vistas;

import android.app.Activity;
import android.app.AlertDialog;
import android.app.DatePickerDialog;
import android.app.Dialog;
import android.app.SearchManager;
import android.content.ContentValues;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.database.Cursor;
import android.graphics.Bitmap;
import android.graphics.Color;
import android.os.Bundle;
import android.text.Editable;
import android.text.TextWatcher;
import android.util.Log;
import android.view.ContextMenu;
import android.view.ContextMenu.ContextMenuInfo;
import android.view.KeyEvent;
import android.view.LayoutInflater;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.view.View.OnClickListener;
import android.view.View.OnLongClickListener;
import android.view.ViewGroup;
import android.view.inputmethod.InputMethodManager;
import android.widget.AdapterView;
import android.widget.AdapterView.AdapterContextMenuInfo;
import android.widget.AdapterView.OnItemSelectedListener;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.CheckBox;
import android.widget.CompoundButton;
import android.widget.DatePicker;
import android.widget.EditText;
import android.widget.LinearLayout;
import android.widget.ListView;
import android.widget.SimpleCursorAdapter;
import android.widget.Spinner;
import android.widget.TextView;

import com.amesol.routelite.R;
import com.amesol.routelite.actividades.Enumeradores.Inventario.TiposValidacionInventario;
import com.amesol.routelite.actividades.EnvioPDF;
import com.amesol.routelite.actividades.Folios;
import com.amesol.routelite.actividades.InventarioDobleUnidad;
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.actividades.Transacciones;
import com.amesol.routelite.actividades.ValoresReferencia;
import com.amesol.routelite.controles.CapturaProducto;
import com.amesol.routelite.controles.CapturaProducto.onAgregarProductoListener;
import com.amesol.routelite.datos.Cliente;
import com.amesol.routelite.datos.Dia;
import com.amesol.routelite.datos.ManejoLotesCaducidad;
import com.amesol.routelite.datos.ModuloMovDetalle;
import com.amesol.routelite.datos.Producto;
import com.amesol.routelite.datos.ProductoUnidad;
import com.amesol.routelite.datos.TPDDatosExtra;
import com.amesol.routelite.datos.TRPVtaAcreditada;
import com.amesol.routelite.datos.TransProd;
import com.amesol.routelite.datos.TransProdDetalle;
import com.amesol.routelite.datos.Usuario;
import com.amesol.routelite.datos.basedatos.BDVend;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.ConfigParametro;
import com.amesol.routelite.datos.utilerias.MOTConfiguracion;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.Enumeradores.RespuestaMsg;
import com.amesol.routelite.presentadores.Enumeradores.Resultados;
import com.amesol.routelite.presentadores.act.DevolverCliente;
import com.amesol.routelite.presentadores.interfaces.IDevolucionCliente;
import com.amesol.routelite.presentadores.interfaces.IServidorComunicaciones;
import com.amesol.routelite.utilerias.ControlError;
import com.amesol.routelite.utilerias.EncriptaDesencripta;
import com.amesol.routelite.utilerias.Generales;
import com.amesol.routelite.vistas.generico.DialogoAlerta;

import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Calendar;
import java.util.Collections;
import java.util.Date;
import java.util.GregorianCalendar;
import java.util.HashMap;
import java.util.Hashtable;
import java.util.Iterator;
import java.util.List;
import java.util.Locale;
import java.util.Map;
import java.util.logging.Handler;

public class DevolucionCliente extends Vista implements IDevolucionCliente
{

	private DevolverCliente mPresenta;
	private String mAccion;
	private HashMap<String, Object> oParametros = null;
	private boolean huboCambios = false;
	private boolean esNuevo = true;
	private boolean soloLectura = false;
	private CapturaProducto captura;
	private ListView lista;
	private Short tipoMotivo;
	private Cursor motivos;
	private TransProdDetalle productoEliminar;
	private EditText factura;
    private EditText comentarios;
    private boolean bCargandoComentarios = true;
	private Button btnContinuar;
	private boolean errorFinalizar = false;
	private EditText txtCantidad;
	boolean mensajeLimiteEnvase = false;
    /*Inicio Codigo Luis de la torre*/
	/*parametro CapturaPRecoleccion*/
    private ConfigParametro configParametro;
    private Spinner cboRecoleccion;
    private EditText txtTelefono;
    private TextView txtVolumenValor;
	/*Fin Codigo Luis de la torre*/
    private CheckBox chbFechaRecoleccion;
    private Button btnFechaRecoleccion;
	AlertDialog dialogoLoteCaducidad;
	String transProdIdDialogo;
    private boolean bImprimiendo = false;
	private boolean bValidarFactura = false;
    private boolean bDevolucionParaRecoleccion = false;
	private String transProdIDFac =  "";
	private HashMap<String,HashMap<Integer,Float>> hmDetallesFactura;
    private Date fechaRecoleccion;
    private boolean bRecolectando = false;
    private boolean bAdicionProducto = false;
    private boolean bConsultando = false;
	String contrasenaPara = "";
	String contrasena = "";
	private boolean vali = false; // esta variable se utiliza para regresar el booleano desde el dialogo para validar los permisos

	static final int DATE_DIALOG_RECOLECCION = 999;
    private OnClickListener mFechaRecoleccion = new OnClickListener() {
        @SuppressWarnings("deprecation")
        @Override
        public void onClick(View v) {
            showDialog(DATE_DIALOG_RECOLECCION);
        }
    };

	@SuppressWarnings(
	{ "deprecation", "unchecked" })
	@Override
	public void onCreate(Bundle savedInstanceState)
	{
		try
		{
			super.onCreate(savedInstanceState);
			mAccion = getIntent().getAction();

			setContentView(R.layout.devolucion_cliente);
			deshabilitarBarra(true);
			setTitulo(Mensajes.get("XDevolucionCliente"));

			TextView texto = (TextView) findViewById(R.id.lblFactura);
			texto.setText(Mensajes.get("XFactura"));
			factura = (EditText) findViewById(R.id.txtFactura);

            texto = (TextView) findViewById(R.id.lblComentarios);
            texto.setText(Mensajes.get("XComentarios"));
            comentarios = (EditText) findViewById(R.id.txtComentarios);
            comentarios.addTextChangedListener(new TextWatcher() {
                @Override
                public void beforeTextChanged(CharSequence s, int start, int count, int after){
                }

                @Override
                public void onTextChanged(CharSequence s, int start, int count, int after){
                }

                @Override
                public void afterTextChanged(Editable s) {
                    if (getbValidarFactura()) {
                        if (!btnContinuar.isEnabled() & !bCargandoComentarios) {
                            setHuboCambios(true);
                        }
                    }
                }
            });

			if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).existeParametro("ValidarFacturaDevolucion") && ((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("ValidarFacturaDevolucion").equals("1")) {
				bValidarFactura = true;
				factura.setEnabled(false);
			}


            if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).existeParametro("DevolucionParaRecoleccion", ((MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion)).get("MCNClave").toString()) && ((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("DevolucionParaRecoleccion", ((MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion)).get("MCNClave").toString()).equals("1")) {
                bDevolucionParaRecoleccion = true;
                chbFechaRecoleccion = (CheckBox) findViewById(R.id.chbFechaRecoleccion);
                chbFechaRecoleccion.setText(Mensajes.get("XProgramarParaRecoleccion"));
                chbFechaRecoleccion.setOnCheckedChangeListener(new CompoundButton.OnCheckedChangeListener() {
                    @Override
                    public void onCheckedChanged(CompoundButton buttonView, boolean isChecked) {
                        mPresenta.setManejarInventario(!isChecked);
                    }
                });

                btnFechaRecoleccion = (Button) findViewById(R.id.btnFechaRecoleccion);
                fechaRecoleccion = ((Dia) Sesion.get(Campo.DiaActual)).FechaCaptura;
                btnFechaRecoleccion.setText(new SimpleDateFormat("dd/MMM/yyyy").format(fechaRecoleccion.getTime()));
                btnFechaRecoleccion.setOnClickListener(mFechaRecoleccion);

            }else{
                LinearLayout layFechaRecoleccion = (LinearLayout)findViewById(R.id.layFechaRecoleccion);
                layFechaRecoleccion.setVisibility(View.GONE);
                bDevolucionParaRecoleccion = false;
            }

			texto = (TextView) findViewById(R.id.lblProducto);
			texto.setText(Mensajes.get("XProducto"));

			texto = (TextView) findViewById(R.id.lblUnidad);
			texto.setText(Mensajes.get("XUnidad"));

			texto = (TextView) findViewById(R.id.lblProductos);
			texto.setText(Mensajes.get("XProductos") + ": ");

			texto = (TextView) findViewById(R.id.txtProductos);
			texto.setText("0");

			texto = (TextView) findViewById(R.id.lblTotal);
			texto.setText(Mensajes.get("XGranTotal") + ": ");

			texto = (TextView) findViewById(R.id.txtTotal);
			texto.setText(Generales.getFormatoDecimal(0, "$ #,##0.00"));

			btnContinuar = (Button) findViewById(R.id.btnContinuar);
			btnContinuar.setText(Mensajes.get("XContinuar"));
			btnContinuar.setOnClickListener(mContinuar);


			//Inicio Codigo Luis de la torre
			texto = (TextView) findViewById(R.id.lblVolumen);
			texto.setText(Mensajes.get("XVolumen")+":");

			txtVolumenValor = (TextView) findViewById(R.id.txtVolumen);
			txtVolumenValor.setText("0");
			//Fin Codigo Luis de la torre

			captura = (CapturaProducto) findViewById(R.id.capturaProducto);
			String moduloMovDetClave = Sesion.get(Campo.ModuloMovDetalleClave).toString();
			ModuloMovDetalle modulo = new ModuloMovDetalle();
			modulo.ModuloMovDetalleClave = moduloMovDetClave;
			BDVend.recuperar(modulo);
			captura.setTipoMovimiento(modulo.TipoMovimiento);
			captura.setTipoTransProd(modulo.TipoTransProd);
			captura.setTipoValidacionExistencia(TiposValidacionInventario.NoValidar);
			if (((MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion)).get("ManejoDobleUnidad").toString().equals("1")) {
				captura.setOnAgregarProdDobleUnidadListener(mAgregarProdDobleUnidadListener);
			}else{
				captura.setOnAgregarProductoListener(mAgregar);
			}

			lista = (ListView) findViewById(R.id.lstTransProdDetalle);
			//registerForContextMenu(lista);

			ISetDatos mots = Consultas.ConsultasValorReferencia.obtenerValoresPorGrupo("TRPMOT", "'No Venta','Caducidad','Venta'", "", true);
			motivos = (Cursor) mots.getOriginal();
			startManagingCursor(motivos);

			tipoMotivo = 0;

			if (getIntent().getSerializableExtra("parametros") != null)
			{
				oParametros = (HashMap<String, Object>) getIntent().getSerializableExtra("parametros");
			}

			mPresenta = new DevolverCliente(this, mAccion);

			if (oParametros != null && (oParametros.get("Eliminar") != null))
			{
				soloLectura = Boolean.parseBoolean(oParametros.get("Eliminar").toString());
				if (soloLectura)
				{
					captura.setVisibility(View.GONE);
					factura.setEnabled(false);
				}
			}
			//bValidarFactura
			if (bValidarFactura) {
				if (oParametros != null && (oParametros.get("DetallesFactura") != null)) {
					hmDetallesFactura = (HashMap<String, HashMap<Integer, Float>>) oParametros.get("DetallesFactura");
				}
				if (oParametros != null && (oParametros.get("FolioFactura") != null)) {
					factura.setText(oParametros.get("FolioFactura").toString());
				}
				if (oParametros!=null && (oParametros.get("TransProdIDFac")!=null)){
					transProdIDFac = oParametros.get("TransProdIDFac").toString();
				}
			}else{
                texto = (TextView) findViewById(R.id.lblComentarios);
                texto.setVisibility(View.GONE);

                comentarios.setVisibility(View.GONE);
            }

			// si se paso como parametro el TransProdId, cargar el detalle
            configParametro = new ConfigParametro();
			if (oParametros != null && (oParametros.get("TransProdId") != null))
			{
				esNuevo = false;
                if(oParametros.containsKey("Recoleccion"))
                    if(oParametros.get("Recoleccion").equals("1")) {
                        bRecolectando = true;
                    }
                    else if (oParametros.get("Recoleccion").equals("2")) {
                        soloLectura = true;
                        bConsultando = true;
                    }

				mPresenta.recuperarTransProd(oParametros.get("TransProdId").toString());
                mPresenta.actualizarMotivos();
                if (soloLectura && bRecolectando) //Cancelar
                    llenarMotivosCancelacion();
				refrescarProductos(mPresenta.getTransaccionesIds());

                bAdicionProducto = (configParametro.existeParametro("AdicionProducto", Sesion.get(Campo.ModuloMovDetalleClave).toString()) && configParametro.get("AdicionProducto", Sesion.get(Campo.ModuloMovDetalleClave).toString()).equals("1"));
                if (!bAdicionProducto) {
                    captura.setEnabled(false);
                    captura.setEnableCantidadAgregar(true);
                }
                captura.setSurtir(bRecolectando);

				if(soloLectura)
					this.validarPermisos(Sesion.get(Campo.TipoIndiceModuloMovDetalleClave).toString(), Enumeradores.TipoPermiso.ELIMINAR);
				else
					this.validarPermisos(Sesion.get(Campo.TipoIndiceModuloMovDetalleClave).toString(), Enumeradores.TipoPermiso.MODIFICAR);

			}
			else
			{
				esNuevo = true;
				try
				{
					this.validarPermisos(Sesion.get(Campo.TipoIndiceModuloMovDetalleClave).toString(), Enumeradores.TipoPermiso.CREAR);
					mPresenta.crearTransProd();
				}
				catch (Exception e)
				{
					errorFinalizar = true;
					mostrarError(e.getMessage());
					return;
				}

			}

            if (!bRecolectando)
                registerForContextMenu(lista);

            if (bConsultando) {
                captura.setVisibility(View.GONE);
                factura.setEnabled(false);
            }

			if (!esNuevo && !soloLectura && !bRecolectando || bConsultando)
				btnContinuar.setEnabled(false);

            /*Inicio Codigo Luis de la torre*/
			/*Validar configuracion de parametros GONAC*/
			try
			{
				validarCapturaPRecoleccion(configParametro.get("CapturaPRecoleccion"));
			}
			catch (Exception e)
			{
				// TODO Auto-generated catch block
				//mostrarError(e.getMessage());
				e.printStackTrace();
				validarCapturaPRecoleccion("0");
			}
			/*Fin Codigo Luis de la torre*/

            mPresenta.setDevolucionParaRecoleccion(bDevolucionParaRecoleccion);
            mPresenta.setRecolectando(bRecolectando);
            mPresenta.setConsultando(bConsultando);
            mPresenta.setbSoloLectura(soloLectura);
			mPresenta.iniciar();
		}
		catch (Exception e)
		{
			mostrarError(e.getMessage());
		}

		final Spinner spinUnit = (Spinner) findViewById(R.id.cboUnidad);
		if (!(spinUnit.getCount() > 1))
			spinUnit.setEnabled(false);

		final EditText txtScaner = (EditText) findViewById(R.id.txtScanner);
		txtCantidad = (EditText) findViewById(R.id.txtCantidad);

		final InputMethodManager imm = (InputMethodManager) getSystemService(Context.INPUT_METHOD_SERVICE);

		txtCantidad.setOnFocusChangeListener(new View.OnFocusChangeListener() {
			@Override
			public void onFocusChange(View v, boolean hasFocus) {
				// TODO Auto-generated method stub
				if (hasFocus) {
					txtScaner.clearFocus();
					imm.showSoftInput(txtCantidad, InputMethodManager.SHOW_FORCED);
					if (!(spinUnit.getCount() > 1))
						spinUnit.setEnabled(false);

					String mCantidad = mPresenta.consultarUnidadProductoExistente(mPresenta.getTransaccionesIds(), txtScaner.getText().toString());
					if (!mCantidad.equals("0")) {
						txtCantidad.setText(mCantidad);
						txtCantidad.requestFocus();
						txtCantidad.selectAll();
						txtCantidad.setSelectAllOnFocus(true);
					}// getWindow().setSoftInputMode(WindowManager.LayoutParams.SOFT_INPUT_STATE_VISIBLE);

				}
			}
		});

		txtScaner.setOnFocusChangeListener(new View.OnFocusChangeListener() {
			@Override
			public void onFocusChange(View v, boolean hasFocus) {
				// TODO Auto-generated method stub
				if (hasFocus) {
					// getWindow().setSoftInputMode(WindowManager.LayoutParams.SOFT_INPUT_STATE_VISIBLE);
					txtCantidad.clearFocus();
					imm.showSoftInput(txtCantidad, InputMethodManager.SHOW_FORCED);
					if (!(spinUnit.getCount() > 1))
						spinUnit.setEnabled(false);
				}
			}
		});
	}


    public void setMotivos(String grupo){
        try {
            ISetDatos mots;
            if (grupo.equals(""))
                mots = Consultas.ConsultasValorReferencia.obtenerValoresPorGrupo("TRPMOT", "'No Venta','Caducidad','Venta'", "", true);
            else
                mots = Consultas.ConsultasValorReferencia.obtenerValoresPorGrupo("TRPMOT", "'" + grupo + "'", "", true);
            motivos = (Cursor) mots.getOriginal();
            startManagingCursor(motivos);
        }catch(Exception e){}
    }


	@Override
	public void iniciar()
	{

	}

    @SuppressWarnings("deprecation")
    @Override
    protected Dialog onCreateDialog(int id) {
        switch (id) {
            case DATE_DIALOG_RECOLECCION:
                int anio = fechaRecoleccion.getYear() + 1900;
                int mes = fechaRecoleccion.getMonth();
                int dia = fechaRecoleccion.getDate();
                return new DatePickerDialog(this, mFechaRecoleccionListener, anio, mes, dia);
        }
        return null;
    }

    private DatePickerDialog.OnDateSetListener mFechaRecoleccionListener = new DatePickerDialog.OnDateSetListener()
    {
        // when dialog box is closed, below method will be called.
        @SuppressWarnings("deprecation")
        @Override
        public void onDateSet(DatePicker view, int selectedYear, int selectedMonth, int selectedDay) {
            try {
                MOTConfiguracion motConf = (MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion);
                Calendar tmp = Calendar.getInstance();
                tmp.setTime((new SimpleDateFormat("dd/MM/yyyy")).parse(new SimpleDateFormat("dd/MM/").format(new Date(selectedYear, selectedMonth, selectedDay)) + (new Date(selectedYear, selectedMonth, selectedDay)).getYear()));

                if (tmp.getTime().compareTo(((Dia) Sesion.get(Campo.DiaActual)).FechaCaptura) < 0) { // la fecha seleccionada es menor a la de captura
                    return;
                }
                fechaRecoleccion = tmp.getTime();
                btnFechaRecoleccion.setText(new SimpleDateFormat("dd/MMM/yyyy").format(fechaRecoleccion));
                setHuboCambios(true);
            } catch (Exception ex) {
                mostrarError(ex.getMessage());
            }
        }

    };

	@Override
	public boolean onKeyDown(int keyCode, KeyEvent event)
	{
		switch (keyCode)
		{
			case KeyEvent.KEYCODE_BACK:
				if (!getImprimiendo())
					salir();
				return true;
		}
		return super.onKeyDown(keyCode, event);
	}

	@Override
	public void onCreateContextMenu(ContextMenu menu, View v, ContextMenuInfo menuInfo)
	{
		super.onCreateContextMenu(menu, v, menuInfo);
		MenuInflater inflater = getMenuInflater();
		inflater.inflate(R.menu.context_transaccion_detalle, menu);
		menu.getItem(0).setTitle(Mensajes.get("XEliminar"));
		try{
			if(configParametro.existeParametro("CapturaCadLote", Sesion.get(Campo.ModuloMovDetalleClave).toString()) && configParametro.get("CapturaCadLote", Sesion.get(Campo.ModuloMovDetalleClave).toString()).equals("1")) {
				MenuItem mItem = menu.findItem(R.id.modificarLoteCaducidad );
				mItem.setTitle("Modificar Lote-Caducidad");
				mItem.setVisible(true);
			}
		}catch (Exception ex){
			if (ex!=null && ex.getMessage() !=null) {
				mostrarError(ex.getMessage());
			}else{
				mostrarError("Error al mostrar menu");
			}
		}

	}

	@Override
	public boolean onContextItemSelected(MenuItem item)
	{
		AdapterContextMenuInfo info = (AdapterContextMenuInfo) item.getMenuInfo();
		productoEliminar = (TransProdDetalle) lista.getItemAtPosition(info.position);
		switch (item.getItemId())
		{
			case R.id.eliminar:
				try
				{
					mostrarPreguntaSiNo(Mensajes.get("P0233"), 5);
				}
				catch (Exception e)
				{
					mostrarError(e.getMessage());
				}
				return true;
			case R.id.modificarLoteCaducidad:
				mostrarDialogoLoteCaducidad(productoEliminar.TransProdDetalleID);
				return true;
		}
		return false;
	}

    @Override
    public boolean onCreateOptionsMenu(Menu menu)
    {
        MenuInflater inflater = getMenuInflater();
        inflater.inflate(R.menu.menu_devolucion_cliente, menu);
        menu.getItem(0).setTitle(Mensajes.get("XSaldoEnvases"));
        menu.getItem(0).setVisible(false);
        if ( (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.VENTA || Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO) && ((Cliente)Sesion.get(Campo.ClienteActual)).Prestamo ) {
            menu.getItem(0).setVisible(true);
        }
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item)
    {
        switch (item.getItemId())
        {
            case R.id.saldoEnvase:
                mostrarSaldoEnvase();
                return true;
            default:
                return super.onOptionsItemSelected(item);
        }
    }

    private void mostrarSaldoEnvase() {
        try{
            LayoutInflater inflater = (LayoutInflater) DevolucionCliente.this.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
            View dialogView = inflater.inflate(R.layout.dialog_saldoenvase, null);
            AlertDialog.Builder builder = new AlertDialog.Builder(this);

            TextView lbl = (TextView) dialogView.findViewById(R.id.lblTituloDialogoSaldoEnvase);
            lbl.setText(Mensajes.get("XSaldoEnvases"));

            lbl = (TextView) dialogView.findViewById(R.id.lblClave);
            lbl.setText(Mensajes.get("XClave"));

            lbl = (TextView) dialogView.findViewById(R.id.lblCargo);
            lbl.setText(Mensajes.get("XCargo"));

            lbl = (TextView) dialogView.findViewById(R.id.lblAbono);
            lbl.setText(Mensajes.get("XAbono"));

            lbl = (TextView) dialogView.findViewById(R.id.lblVenta);
            lbl.setText(Mensajes.get("XVenta"));

            lbl = (TextView) dialogView.findViewById(R.id.lblSaldo);
            lbl.setText(Mensajes.get("XSaldo"));

            ListView modeList = (ListView) dialogView.findViewById(R.id.lstSaldoEnvase);
            modeList.setBackgroundColor(Color.WHITE);

            Cursor cursor = mPresenta.obtenerSaldoEnvase();
            SimpleCursorAdapter adapter = new SimpleCursorAdapter(this,R.layout.lista_simple_hor5,cursor,
                    new String[]{"ProductoClave","Cargo","Abono","Venta","Saldo"},
                    new int[]{R.id.txtCol1,R.id.txtCol2,R.id.txtCol3,R.id.txtCol4,R.id.txtCol5});

            modeList.setAdapter(adapter);

            builder.setPositiveButton("Aceptar", new DialogInterface.OnClickListener() {
                public void onClick(DialogInterface dialog, int id) {
                    dialog.dismiss();
                }
            });
            builder.setView(dialogView);
            final Dialog dialog = builder.create();
            dialog.show();
        }catch(Exception e){
            mostrarError(e.getMessage());
            e.printStackTrace();
        }
    }

	private void salir()
	{
		if (!esNuevo)
		{
			if (!soloLectura && huboCambios)
				mostrarPreguntaSiNo(Mensajes.get("BP0002"), 3);
			else
			{
                if (bRecolectando)
                    regresar();
                else {
                    setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
                    finalizar();
                }
			}
		}
		else
		{
			if (hayProductos())
			{
				if (!soloLectura)
					mostrarPreguntaSiNo(Mensajes.get("BP0002"), 3);
				else
				{
					setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
					finalizar();
				}
			}
			else
			{ // no hay productos
				regresar();
			}
		}
	}

	private void regresar()
	{
		try
		{
			if (esNuevo)
			{
				BDVend.rollback();
			}
			else
			{
				if (huboCambios || bRecolectando)
					BDVend.rollback();
			}
			setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
			finalizar();
		}
		catch (Exception ex)
		{
			mostrarError(ex.getMessage());
		}
	}

	private void terminar()
	{
        MOTConfiguracion motConfig = (MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion);
        if (motConfig.get("MensajeImpresion").equals("0"))
        {
            // si no esta configurada la pregunta salir
            setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
            finalizar();
        }else if(motConfig.get("MensajeImpresion").equals("1")){
            mostrarPreguntaSiNo(Mensajes.get("P0103"), 8);
        }else if (motConfig.get("MensajeImpresion").equals("2") || motConfig.get("MensajeImpresion").equals("3")){
            EnvioPDF.enviarTicketPDF( DevolucionCliente.this, Short.valueOf(motConfig.get("MensajeImpresion").toString()));
        }
	}

    public void imprimir(){

    }

	private OnClickListener mContinuar = new OnClickListener()
	{
		@Override
		public void onClick(View v)
		{
            int resultado = 0;
			try
			{
				if (!soloLectura)
				{
					//Si se debería validar una factura para realizar la devolucion, marcar error cuando no esta capturada
					//En este escenario la factura debe solicitarse desde que se ingresa a la actividad
					if(((ConfigParametro)Sesion.get(Campo.ConfigParametro)).existeParametro("ValidarFacturaDevolucion") && ((ConfigParametro)Sesion.get(Campo.ConfigParametro)).get("ValidarFacturaDevolucion").equals("1")) {
						if (factura.getText().toString().length()<=0){
							throw new ControlError("BE0001", Mensajes.get("XFactura"));
						}
					}
					if (mPresenta.getDetalles().size() <= 0)
					throw new ControlError("E0044", Mensajes.get("XDevoluciones"));

					if (((MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion)).get("ManejoDobleUnidad").toString().equals("1")){
						DevolucionAdapterDobleUnidad cur = (DevolucionAdapterDobleUnidad) lista.getAdapter();
						for (int indice = 0; indice < cur.getCount(); indice = indice + 1)
						{
							if (cur.getItem(indice).TipoMotivo == 0)
							{
								throw new ControlError("E0161", Mensajes.get("XMotivo"));
							}
						}
					}else{
						DevolucionAdapter cur = (DevolucionAdapter) lista.getAdapter();
						for (int indice = 0; indice < cur.getCount(); indice = indice + 1)
						{
							if (cur.getItem(indice).TipoMotivo == 0)
							{
								throw new ControlError("E0161", Mensajes.get("XMotivo"));
							}
						}
					}

                    if(!esNuevo){ //modificando
                        //validacion limite prestamo envase
						mPresenta.validarLimitePrestamoEnvase();
                    }

                    if (bValidarFactura) {
                        mPresenta.guardarNotas(comentarios.getText().toString());
                    }else{
                        mPresenta.guardarNotas(factura.getText().toString());
                    }

					mPresenta.guardarNotas(factura.getText().toString());
					if (transProdIDFac.length()>0){
						mPresenta.guardarFacturaId(transProdIDFac);
					}

                    mPresenta.guardaTipoMotivo();

                    String telefono = "";
                    String recoleccion = "";
                    if(bDevolucionParaRecoleccion){
                        recoleccion = (chbFechaRecoleccion.isChecked() ? "1" : "0");
                        if (recoleccion.equals("1"))
                            mPresenta.guardarFechaRecoleccion(fechaRecoleccion);
                    }
                    /*Inicio Codigo Luis de la torre*/
                    if(configParametro.get("CapturaPRecoleccion").equals("1"))
                    {
                        String id = getIdDomicilioSpinner();
                        mPresenta.guardarDomicilioPE(id);
                        telefono = txtTelefono.getText().toString();
                        //mPresenta.guardarTelefono(txtTelefono.getText().toString());
                    }
                    if (telefono.length() > 0 || recoleccion.length() > 0)
                        mPresenta.guardarTRPVtaAcreditada(telefono, recoleccion);

                    if(configParametro.existeParametro("CapturaCadLote", Sesion.get(Campo.ModuloMovDetalleClave).toString()) && configParametro.get("CapturaCadLote", Sesion.get(Campo.ModuloMovDetalleClave).toString()).equals("1"))
                    {
                        resultado = guardarLoteCaducidad();

                        if(resultado == 1)
                            throw new ControlError("BE0001","Lote");

                        if(resultado == 2)
                            throw new ControlError("BE0001","Caducidad");

                        if(resultado == 3)
                            throw new ControlError("E0605", "yyyy-MM-dd");
                    }
					/*Fin Codigo Luis de la torre*/

					/*if (mPresenta.getTransProd() != null)
					{
						Transacciones.calcularTotalesTransaccion(mPresenta.getTransProd());
						BDVend.guardarInsertar(mPresenta.getTransProd());
					}*/

                    if (bRecolectando){
                        mPresenta.guardarDatosRecoleccion();
                    }

                    mPresenta.solicitarFirma();
				}
				else
				{
                    if (bRecolectando){
                        if (getTipoMotivoCancelacion() <= 0)
                            mostrarError(Mensajes.get("E0161", Mensajes.get("XMotivo")));
                        else
                            mostrarPreguntaSiNo(Mensajes.get("P0001"), 10);
                    }
                    else
					    mostrarPreguntaSiNo(Mensajes.get("P0001"), 10);
				}

			}
			catch (ControlError e)
			{
				mostrarError(e.getMessage());
			}
			catch (Exception e)
			{
				mostrarError(e.getMessage());
			}
		}
	};

    public void guardar(String sNombre, String sNombreArchivo){
        try {
            int cont = 0;

            ArrayList<String> folios = new ArrayList<String>();
            if (esNuevo) {
                //Folios.confirmar(Sesion.get(Campo.ModuloMovDetalleClave).toString());
                String mensaje = "";
                folios = Folios.ObtenerVarios(Sesion.get(Campo.ModuloMovDetalleClave).toString(), mPresenta.getTransacciones().size(), mensaje);
            }

            for (final Object transProd : mPresenta.getTransacciones().values().toArray()) {
                TransProd oTrp = (TransProd) transProd;
                if (esNuevo)
                    oTrp.Folio = folios.get(cont);
                Transacciones.calcularTotalesTransaccion(oTrp);

                if (!sNombre.equals("") && !sNombreArchivo.equals("")) {
                    TRPVtaAcreditada firmaDigital = new TRPVtaAcreditada();
                    firmaDigital.TransProdID = oTrp.TransProdID;
                    BDVend.recuperar(firmaDigital);
                    firmaDigital.NombreFirma = sNombre;
                    firmaDigital.IdImagenFirma = sNombreArchivo;
                    firmaDigital.MFechaHora = Generales.getFechaHoraActual();
                    firmaDigital.MUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;
                    firmaDigital.Enviado = false;
                    BDVend.guardarInsertar(firmaDigital);
                }

                BDVend.guardarInsertar(oTrp);
                if (esNuevo)
                    Folios.confirmar(Sesion.get(Campo.ModuloMovDetalleClave).toString());
                cont++;
            }

            BDVend.commit();
            //terminar();

            Runnable accion = new Runnable() {

                @Override
                public void run() {
                    while (getMensajeLimiteEnvase()) {
                        //esperar hasta que se quite el mensaje de validacion de credito para continuar
                    }
                    runOnUiThread(new Runnable() { //ejecutar en el thread de la ui para poder mostrar el mensaje de impresion
                        @Override
                        public void run() {
                            terminar();
                        }
                    });
                }
            };
            final Thread hilo = new Thread(accion);
            hilo.start();
        }
        catch (ControlError e)
        {
            mostrarError(e.getMessage());
        }
        catch (Exception e)
        {
            mostrarError(e.getMessage());
        }
    }

	private boolean hayProductos()
	{
		// TextView totalProductos = (TextView)
		// findViewById(R.id.txtTotalProductos);
		// if(totalProductos.getText().toString().trim().equals("") ||
		// Float.parseFloat(totalProductos.getText().toString().replace(",","").replace(",",
		// ".").replace("$","")) == 0)
		if (mPresenta.getTransProd().TransProdDetalle.size() <= 0)
			return false;
		else
			return true;
	}

	@SuppressWarnings("unchecked")
	@Override
	public void resultadoActividad(int requestCode, int resultCode, Intent data)
	{
		if (requestCode == Enumeradores.Solicitudes.SOLICITUD_BUSQUEDA_PRODUCTOS)
		{
			// si esta regresando de la busqueda de productos
			if (resultCode == Enumeradores.Resultados.RESULTADO_BIEN)
			{
				// si selecciono Agregar en la busqueda de productos, obtener la
				// seleccion y agregarlos al pedido
				if (Sesion.get(Campo.ResultadoActividad) != null)
				{
					insertarSeleccion((HashMap<String, TransProdDetalle>) Sesion.get(Campo.ResultadoActividad));
					Sesion.remove(Campo.ResultadoActividad);
                    captura.setFinBusqueda();
				}else{
					if (data != null) {
						txtScanner.setTexto(data.getStringExtra("mensajeIniciar"));
						captura.IngresaProductoBusquedaSimple(data.getStringExtra("mensajeIniciar"));
					}
                }
			}else if (resultCode == Enumeradores.Resultados.RESULTADO_MAL){
                if (data != null){
                    String mensajeError = (String) data.getExtras().getString("mensajeIniciar");
                    if (!mensajeError.equals("")){ // cuando se presiona back se manda el mensaje vacio
                        mostrarError(mensajeError);
                    }
                }
                captura.setFinBusqueda();
            }
			//captura.setFinBusqueda();
		}
		else if (requestCode == REQUEST_ENABLE_BT)
		{
			if (resultCode == RESULT_OK)
			{
				// imprimiendo = true;
				mPresenta.imprimirTicket();
				setResultado(Enumeradores.Resultados.RESULTADO_TERMINAR);
			}
			else
			{
				mostrarError("No se pudo encender el BT");
				finalizar();
			}
		}
        else if (requestCode == Enumeradores.Solicitudes.SOLICITUD_CAPTURAR_FIRMA)
        {
            if (resultCode == Enumeradores.Resultados.RESULTADO_BIEN) {
                String sNombre = "";
                String sNombreArchivo = "";
                if (data != null){
                    sNombre = (String) data.getExtras().getString("Nombre");
                    sNombreArchivo = (String) data.getExtras().getString("NombreArchivo");
                }
                guardar(sNombre, sNombreArchivo);
            }/*else
            {
                Button boton = (Button) findViewById(R.id.btnContinuar);
                boton.setEnabled(true);
            }*/
        }
        else if (requestCode == Enumeradores.Solicitudes.SOLICITUD_ENVIAR_PDF)
        {
            if (resultCode == Enumeradores.Resultados.RESULTADO_BIEN) {
                bImprimiendo = true;

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
                    EnvioPDF.enviarArchivos(DevolucionCliente.this);
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
                    EnvioPDF.enviarSMS(DevolucionCliente.this);
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
                    EnvioPDF.EnviarSiguiente(DevolucionCliente.this, sArchivoPDF);
                }
                else
                {
                    this.mostrarMensaje(Mensajes.get("I0307").replace("$0$", "SMS"), 0, 0);
                }
            }
            else {
                this.mostrarPreguntaSiNo(Mensajes.get("P0254"), 2);
            }
        }
	}

	@Override
	public void respuestaMensaje(RespuestaMsg respuesta, int tipoMensaje)
	{
		if(mensajeLimiteEnvase)
			mensajeLimiteEnvase = false;

		if (tipoMensaje == 3)
		{
			if (respuesta == RespuestaMsg.Si)
			{
				regresar();
			}
		}
		else if (tipoMensaje == 5)
		{ // eliminar producto
			if (respuesta.equals(RespuestaMsg.Si))
			{
				if (((MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion)).get("ManejoDobleUnidad").toString().equals("1")){
					mPresenta.eliminarDetalleDobleUnidad(productoEliminar);
				}else{
					mPresenta.eliminarDetalle(productoEliminar);
				}

				refrescarProductos(mPresenta.getTransaccionesIds());
				huboCambios = true;
			}
		}
		else if (tipoMensaje == 8)
		{ // imprimir recibo
			if (respuesta.equals(RespuestaMsg.Si))
			{
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
		else if (tipoMensaje == 10)
		{ // eliminar movimiento
			if (respuesta.equals(RespuestaMsg.Si))
			{
				try
				{

                    if (!bRecolectando) {
                        if (((MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion)).get("ManejoDobleUnidad").toString().equals("1")) {
                            if (!mPresenta.eliminarMovimientoDobleUnidad()) {
                                BDVend.rollback();
                                return;
                            }
                            ;

                        } else {
                            if (mPresenta.eliminarMovimiento()) {
                                //validacion limite prestamo envase
                                mPresenta.validarLimitePrestamoEnvase();
                            }
                        }

                    }else {
                        mPresenta.cancelarMovimiento();
                    }

                    Runnable accion = new Runnable()
                    {

                        @Override
                        public void run()
                        {
                            while(getMensajeLimiteEnvase()){
                                //esperar hasta que se quite el mensaje de validacion de credito para continuar
                            }
                            runOnUiThread(new Runnable()
                            { //ejecutar en el thread de la ui para poder mostrar el mensaje de impresion
                                @Override
                                public void run()
                                {
                                    try{
                                        BDVend.commit();
                                        setResultado(Resultados.RESULTADO_BIEN);
                                        finalizar();
                                    }catch(Exception ex){
                                        mostrarError(ex.getMessage());
                                        ex.printStackTrace();
                                    }
                                }
                            });
                        }
                    };
                    final Thread hilo = new Thread(accion);
                    hilo.start();

				}catch(ControlError ce){
					try{
						if(ce.getMessage().contains("E0917")){
							BDVend.rollback();
						}
						ce.Mostrar(this);
					}catch (Exception e){
						e.printStackTrace();
					}
				}
				catch (Exception e)
				{
					mostrarError(e.getMessage());
				}
			}
			else
			{
				// setResultado(Resultados.RESULTADO_TERMINAR);
				finalizar();
			}
		}
        else if (tipoMensaje == 2){
            if (respuesta.equals(RespuestaMsg.Si)) {
                EnvioPDF.enviarSMS(DevolucionCliente.this);
            }
            else{
                EnvioPDF.guardarArchivosNoEnviados();
                setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
                finalizar();
            }
        }
		else if (tipoMensaje == 0)
		{
			if (errorFinalizar)
				finalizar();
            else if (bImprimiendo)
            {
                setResultado(Resultados.RESULTADO_BIEN);
                finalizar();
            }
		}
	}

	private onAgregarProductoListener mAgregar = new onAgregarProductoListener()
	{
		@Override
		public void onAgregarProducto(Producto producto, int tipoUnidad, float cantidad)
		{
			try
			{


				if (bValidarFactura){
					ValidarProductoEnFactura(producto.ProductoClave, tipoUnidad, cantidad);
				}
				TransProdDetalle trp = mPresenta.existe(producto, tipoUnidad);
				if (trp != null)
				{ // si ya existe
                    if(bRecolectando == true && !bAdicionProducto){
                        if(trp.Cantidad < cantidad){
                            //captura.setEnableCantidadAgregar(false);
                            mostrarAdvertencia(Mensajes.get("E0908"));
                            return;
                        }
                    }

					if (trp.Cantidad != cantidad)
					{
						// actualizar la cantidad
						mPresenta.actualizarCantidad(trp, cantidad);
					}
				}
				else
				{
					// si no existe agregarlo con el ultimo motivo seleccionado
					trp = mPresenta.agregarProductoUnidad(producto, tipoUnidad, cantidad, tipoMotivo);
				}
				// btnContinuar.setEnabled(true);
			}
			catch (Exception e)
			{
				mostrarError(e.getMessage());
			}
		}
	};

	private CapturaProducto.onAgregarProdDobleUnidadListener mAgregarProdDobleUnidadListener = new CapturaProducto.onAgregarProdDobleUnidadListener()
	{     @Override
		public void onAgregarProdDobleUnidad(Producto producto, HashMap<Short, InventarioDobleUnidad.DetalleProductoDobleUnidad> hmDetalleUnidades) {
			try {
				TransProdDetalle tpd = null;
				for (Short unidad : hmDetalleUnidades.keySet()) {
					tpd = mPresenta.existe(producto, unidad);
					if (tpd != null) {
						break;
					}
				}
				if (tpd != null) { // si ya existe
					boolean actualizarCantidad = false;
					BDVend.recuperar(tpd, TPDDatosExtra.class);
					if (tpd.Cantidad != hmDetalleUnidades.get(Short.parseShort(String.valueOf(tpd.TipoUnidad))).Cantidad) {
						actualizarCantidad = true;
					}
					if (tpd.TPDDatosExtra != null && tpd.TPDDatosExtra.size() > 0 && tpd.TPDDatosExtra.get(0).UnidadAlterna != null && tpd.TPDDatosExtra.get(0).UnidadAlterna > 0 && tpd.TPDDatosExtra.get(0).CantidadAlterna != hmDetalleUnidades.get(tpd.TPDDatosExtra.get(0).UnidadAlterna).Cantidad) {
						actualizarCantidad = true;
					}

					if (actualizarCantidad) {
						mPresenta.actualizarCantidadDobleUnidad(tpd, hmDetalleUnidades);
					}
				} else {
					// si no existe agregarlo con el ultimo motivo seleccionado
					tpd = mPresenta.agregarProductoDobleUnidad(producto, hmDetalleUnidades, tipoMotivo);
				}
				if(configParametro.existeParametro("CapturaCadLote", Sesion.get(Campo.ModuloMovDetalleClave).toString()) && configParametro.get("CapturaCadLote", Sesion.get(Campo.ModuloMovDetalleClave).toString()).equals("1")) {
					if (tpd != null) {
						mostrarDialogoLoteCaducidad(tpd.TransProdDetalleID);
					}
				}
			} catch (Exception e) {
				mostrarError(e.getMessage());
			}
		}
	};



	@SuppressWarnings("rawtypes")
	public void insertarSeleccion(HashMap<String, TransProdDetalle> transProdDetalles)
	{
		try
		{
			Iterator it = transProdDetalles.entrySet().iterator();
			while (it.hasNext())
			{ // recorrer los productos
				Map.Entry producto = (Map.Entry) it.next();
				String productoClave = producto.getKey().toString();
				boolean validar = false;
				Producto oProducto = Consultas.ConsultasProducto.obtenerProducto(productoClave); // mPresenta.obtenerProducto(productoClave);
				try
				{
					validar = mPresenta.validarProductoContenido(oProducto);
				}
				catch (Exception ex)
				{
					mostrarError(ex.getMessage().equals("") ? ex.getCause().getMessage() : ex.getMessage());
				}
				if (bValidarFactura){
					try {
						ValidarProductoEnFactura(productoClave, ((TransProdDetalle) producto.getValue()).TipoUnidad, ((TransProdDetalle) producto.getValue()).Cantidad);
					}catch (Exception ex){
						mostrarError(ex.getMessage());
						validar = false;
					}
				}
				if (validar)
				{ // agregarlo solo si no existe
					try
					{
						mPresenta.agregarProductoUnidad(oProducto, ((TransProdDetalle) producto.getValue()), tipoMotivo);
					}
					catch (Exception ex)
					{
						mostrarError(ex.getMessage().equals("") ? ex.getCause().getMessage() : ex.getMessage());
					}
				}
			}
			refrescarProductos(mPresenta.getTransaccionesIds());
		}
		catch (Exception ex)
		{
			mostrarError(ex.getMessage());
		}
	}

	private void ValidarProductoEnFactura(String productoClave, Integer tipoUnidad, Float cantidad) throws Exception {
		if (hmDetallesFactura != null){
			if (!hmDetallesFactura.containsKey(productoClave)){
				throw new Exception(Mensajes.get("E0974", productoClave));
			}else{
				HashMap<Integer,Float> unidCant = hmDetallesFactura.get(productoClave);
				if (!unidCant.containsKey(tipoUnidad)){
					throw new Exception(Mensajes.get("E0974", productoClave));
				}else{
					if(cantidad >unidCant.get(tipoUnidad)){
						throw new Exception(Mensajes.get("E0974", productoClave));
					}
				}
			}
		}else{
			throw new Exception(Mensajes.get("E0974", productoClave));
		}
	}
	public void setFolio(String folio)
	{
		TextView texto = (TextView) findViewById(R.id.txtFolio);
		texto.setText(Mensajes.get("XFolio") + ": " + folio);
	}

	public void setFecha(String fecha)
	{
		TextView texto = (TextView) findViewById(R.id.txtFecha);
		texto.setText(Mensajes.get("XFecha") + ": " + fecha);
	}

	public void setFactura(String factura)
	{
		this.factura.setText(factura);
		try {
			if (bValidarFactura) {
				if (factura.length() > 0) {
					if (hmDetallesFactura == null) {
						hmDetallesFactura = new HashMap<String, HashMap<Integer, Float>>();
						Consultas.ConsultasTransProdDetalle.obtenerDetallesFactura(factura, hmDetallesFactura, mPresenta.getTransProd().TransProdID );
					}
					if (transProdIDFac.length() <= 0)
						transProdIDFac = Consultas.ConsultasTransProd.obtenerTransProdIdXFolio(factura);
				}
			}
		}catch (Exception ex){
			if (ex!=null && ex.getMessage() !=null) {
				mostrarError(ex.getMessage());
			}
		}
	}

    public void setComentarios(String comentarios){
        this.comentarios.setText(comentarios);
    }

	public void setListaPrecio(String lista)
	{
		TextView texto = (TextView) findViewById(R.id.txtListaPrecio);
		texto.setText(Mensajes.get("XListaPrecio") + ": " + lista);
	}

	public void setTotal(String total)
	{
		TextView texto = (TextView) findViewById(R.id.txtTotal);
		texto.setText(Generales.getFormatoDecimal(Float.parseFloat(total), "$ #,##0.00"));
	}

	public void setProductosDev(String productos)
	{
		TextView texto = (TextView) findViewById(R.id.txtProductos);
		texto.setText(productos);
	}

	public void setHuboCambios(boolean cambios)
	{
		huboCambios = cambios;
		if (!esNuevo)
			btnContinuar.setEnabled(true);
	}

	public void setTipoMotivo(short motivo)
	{
		tipoMotivo = motivo;
	}

	public void setParametrosCaptura(String listasPrecios, String transProdIds)
	{
		// asignar la lista de precios y los ids al control de captura
		captura.setCadenaListasPrecios(listasPrecios);
		captura.setTransProdIds(transProdIds);
	}

	public boolean getEsNuevo()
	{
		return esNuevo;
	}

    public boolean getbValidarFactura(){
        return bValidarFactura;
    }

    public void setbCargandoComentarios(boolean valor) {
        bCargandoComentarios = valor;
    }



	public void refrescarProductos(String TransProdId)
	{
		try
		{
			try
			{
				if (((MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion)).get("ManejoDobleUnidad").toString().equals("1")){
					refrescarProductosDobleUnidad(TransProdId);
					return;
				}

				obtenerTotales(TransProdId);
                List<TransProdDetalle> detalles = mPresenta.getDetalles();
				if (detalles.size() > 0)
				{
					Collections.sort(detalles, new TransProdDetalle.comparator());
					DevolucionAdapter adapter = new DevolucionAdapter(this, R.layout.elemento_devolucion_cliente, detalles.toArray(new TransProdDetalle[detalles.size()]));
					lista.setAdapter(adapter);
				}
				else
				{
					lista.setAdapter(null);
				}

                if (bDevolucionParaRecoleccion){
                    habilitarRecoleccion(detalles.size() == 0);
                }
			}
			catch (Exception e)
			{
				mostrarError(e.getMessage());
			}
			txtScanner.requestFocus();
		}
		catch (Exception ex)
		{
			mostrarError(ex.getMessage());
		}
	}

	public void refrescarProductosDobleUnidad(String TransProdId)
	{
		try
		{
			try
			{
				obtenerTotales(TransProdId);
				List<TransProdDetalle> detalles = mPresenta.getDetalles();
				if (detalles.size() > 0)
				{
					Collections.sort(detalles, new TransProdDetalle.comparator());
					DevolucionAdapterDobleUnidad adapter = new DevolucionAdapterDobleUnidad(this, R.layout.elemento_devolucion_cliente_dobleunidad, detalles.toArray(new TransProdDetalle[detalles.size()]));
					lista.setAdapter(adapter);
				}
				else
				{
					lista.setAdapter(null);
				}
			}
			catch (Exception e)
			{
				mostrarError(e.getMessage());
			}
			txtScanner.requestFocus();
		}
		catch (Exception ex)
		{
			mostrarError(ex.getMessage());
		}
	}

	private void obtenerTotales(String TransProdID)
	{
		try
		{
			// TextView texto = (TextView) findViewById(R.id.txtTotal);
			// texto.setText(Generales.getFormatoDecimal(Float.parseFloat(mPresenta.obtenerTotales(TransProdID)),
			// "$ #,##0.00"));
			mPresenta.obtenerTotales(TransProdID);
		}
		catch (Exception e)
		{
			mostrarError(e.getMessage());
		}
	}

	public void clickHandler(View v)
	{
		int viewId = v.getId();
		if (viewId != R.id.cboMotivo)
		{
			if (!soloLectura)
			{
				Spinner s = (Spinner) v.findViewById(R.id.cboMotivo);
				TransProdDetalle producto = (TransProdDetalle) lista.getItemAtPosition((Integer) s.getTag());
				if (((MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion)).get("ManejoDobleUnidad").toString().equals("1")) {
					HashMap<Short,Float> hmUnidades = new HashMap<Short,Float>();
					hmUnidades.put(Short.parseShort(String.valueOf(producto.TipoUnidad)), producto.Cantidad);
					if(producto.TPDDatosExtra!= null && producto.TPDDatosExtra.size()>0 && producto.TPDDatosExtra.get(0).UnidadAlterna>0 && producto.TPDDatosExtra.get(0).CantidadAlterna>0 ){
						hmUnidades.put(producto.TPDDatosExtra.get(0).UnidadAlterna , producto.TPDDatosExtra.get(0).CantidadAlterna);
					}
					captura.llenarProductoDobleUnidad(producto.producto, hmUnidades);
				}else{
					captura.llenarProductoUnidad(producto.producto, producto.TipoUnidad, producto.Cantidad);
				}
				txtCantidad.requestFocus();
				txtCantidad.selectAll();
				txtCantidad.setSelectAllOnFocus(true);

			}
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
            if (((ConfigParametro) Sesion.get(Sesion.Campo.ConfigParametro)).existeParametro("NumImpresiones", Sesion.get(Sesion.Campo.ModuloMovDetalleClave).toString())) {
                if (((ConfigParametro) Sesion.get(Sesion.Campo.ConfigParametro)).get("NumImpresiones", Sesion.get(Sesion.Campo.ModuloMovDetalleClave).toString()).equals("0")) {
                    mostrarPreguntaSiNo(Mensajes.get("P0103"), 8);
                } else {
                    finalizar();
                }
            } else {
                mostrarPreguntaSiNo(Mensajes.get("P0103"), 8);
            }
        }catch(Exception ex){
            mostrarPreguntaSiNo(Mensajes.get("P0103"), 8);
        }
	}

    private void llenarMotivosCancelacion(){
        try {
            ISetDatos motivos = Consultas.ConsultasValorReferencia.obtenerValoresPorGrupo("TRPMOT", "'CancelacionDev'", Mensajes.get("XSeleccionar", new String[]
                    {Mensajes.get("XMotivo")}), false);
            Cursor valores = (Cursor) motivos.getOriginal();
            startManagingCursor(valores);
            Spinner spin = (Spinner) findViewById(R.id.cboMotivoCancela);
            if (motivos.getCount() <= 1) //si no hay motivos, mostrar deshabilitado
                spin.setEnabled(false);
            else {
                SimpleCursorAdapter adapter = new SimpleCursorAdapter(this, android.R.layout.simple_spinner_item, valores,
                        new String[]
                                {SearchManager.SUGGEST_COLUMN_TEXT_1},
                        new int[]
                                {android.R.id.text1});
                adapter.setDropDownViewResource(android.R.layout.simple_spinner_item);
                spin.setAdapter(adapter);
            }
            TextView lblMotivoCancela = (TextView) findViewById(R.id.lblMotivoCancela);
            lblMotivoCancela.setText(Mensajes.get("XMotivo"));
            LinearLayout layMotivo = (LinearLayout)findViewById(R.id.layMotivoCancela);
            layMotivo.setVisibility(View.VISIBLE);
        }catch(Exception e){
            e.printStackTrace();
        }
    }


    @Override
    public short getTipoMotivoCancelacion()
    {
        Spinner spin = (Spinner) findViewById(R.id.cboMotivoCancela);
        if (spin.isEnabled())
            return (short) spin.getSelectedItemId();
        else
            return 0;
    }

	public class DevolucionAdapter extends ArrayAdapter<TransProdDetalle>
	{
		int textViewResourceId;
		Context context;
		TransProdDetalle objetos[];
        String mObjeto[][];
        int vueltas = 0;

		public DevolucionAdapter(Context context, int textViewResourceId, TransProdDetalle[] objects)
		{
			super(context, textViewResourceId, objects);
			this.textViewResourceId = textViewResourceId;
			this.context = context;
			objetos = objects;

            mObjeto = new String[objects.length][3];

            for (int i = 0; i < objects.length; i++)
            {
                mObjeto[i][0] = null;
                mObjeto[i][1] = null;
                mObjeto[i][2] = null;
            }
		}

		@Override
		public int getViewTypeCount()
		{
			return objetos.length;
		}

		@Override
		public int getItemViewType(int position)
		{
			return position;
		}

		@Override
		public View getView(int position, View convertView, ViewGroup parent)
		{

			View fila = convertView;
			Holder holder = null;
            final int posicion = position;

            //codigo luis de la torre
            mObjeto[posicion][0] = objetos[position].TransProdDetalleID;

			if (convertView == null)
			{
				LayoutInflater inflater = ((Activity) context).getLayoutInflater();
				fila = inflater.inflate(textViewResourceId, null);

				holder = new Holder();
				holder.ClaveProducto = (TextView) fila.findViewById(R.id.lblClave);
				holder.NombreProducto = (TextView) fila.findViewById(R.id.lblNombre);
				holder.Cantidad = (TextView) fila.findViewById(R.id.lblCantidad);
				holder.Unidad = (TextView) fila.findViewById(R.id.lblUnidad);
				holder.SubTotal = (TextView) fila.findViewById(R.id.lblSubtotal);
				holder.Impuesto = (TextView) fila.findViewById(R.id.lblImpuesto);
				holder.Total = (TextView) fila.findViewById(R.id.lblTotal);
				holder.Motivo = (TextView) fila.findViewById(R.id.lblMotivo);
				holder.TipoMotivo = (Spinner) fila.findViewById(R.id.cboMotivo);
                /*Incio codigo luis de la torre*/
                holder.Lote = (TextView) fila.findViewById(R.id.lblLote);
                holder.LoteEdit = (EditText) fila.findViewById(R.id.txtLote);
                holder.Caducidad = (TextView) fila.findViewById(R.id.lblCaducidad);
                holder.CaducidadEdit = (EditText) fila.findViewById(R.id.txtCaducidad);
				/*Fin codigo luis de la torre*/

				if (motivos.getCount() > 0)
				{
					@SuppressWarnings("deprecation")
					SimpleCursorAdapter adapter = new SimpleCursorAdapter(fila.getContext(), android.R.layout.simple_spinner_item, motivos, new String[]
					{ SearchManager.SUGGEST_COLUMN_TEXT_1 }, new int[]
					{ android.R.id.text1 });
					adapter.setDropDownViewResource(android.R.layout.simple_spinner_item);
					holder.TipoMotivo.setAdapter(adapter);
					holder.TipoMotivo.setOnItemSelectedListener(new OnItemSelectedListener()
					{
						@Override
						public void onItemSelected(AdapterView<?> arg0, View arg1, int arg2, long arg3)
						{
							try
							{
								if (arg1 == null)
									return;
								Spinner s = (Spinner) arg1.getParent();
								DevolucionAdapter ladapter = (DevolucionAdapter) lista.getAdapter();
								TransProdDetalle detalle = ladapter.getItem((Integer) s.getTag());
								Cursor item = (Cursor) arg0.getItemAtPosition(arg2);
								// actualizar solo si el motivo es diferente del
								// que tenia
								if (detalle.TipoMotivo != item.getShort(item.getColumnIndex(SearchManager.SUGGEST_COLUMN_INTENT_DATA)))
								{
									if (!mPresenta.actualizarMotivo(detalle, item.getShort(item.getColumnIndex(SearchManager.SUGGEST_COLUMN_INTENT_DATA))))
									{
										Generales.SelectSpinnerItemByValue(s, detalle.TipoMotivo);
									}
								}
							}
							catch (Exception e)
							{
								mostrarError(e.getMessage());
							}
						}

						@Override
						public void onNothingSelected(AdapterView<?> arg0)
						{
						}
					});

                    /*Inicio codigo Luis de la torre*/

                    holder.LoteEdit.addTextChangedListener(new TextWatcher()
                    {

                        @Override
                        public void onTextChanged(CharSequence s, int start, int before, int count){}

                        @Override
                        public void beforeTextChanged(CharSequence s, int start, int count, int after){}

                        @Override
                        public void afterTextChanged(Editable s)
                        {
                            // TODO Auto-generated method stub
                            //Log.e("VALOR DE LOTE", s.toString());
                            mObjeto[posicion][1] = s.toString();
                            //setHuboCambios(true);
                        }
                    });
                    holder.CaducidadEdit.addTextChangedListener(new TextWatcher()
                    {

                        @Override
                        public void onTextChanged(CharSequence s, int start, int before, int count){}

                        @Override
                        public void beforeTextChanged(CharSequence s, int start, int count, int after){}

                        @Override
                        public void afterTextChanged(Editable s)
                        {
                            // TODO Auto-generated method stub
                            //Log.e("VALOR DE CADUCIDAD", s.toString());
                            mObjeto[posicion][2] = s.toString();
                            //setHuboCambios(true);
                        }
                    });

					/*Fin codigo Luis de la torre*/
				}

                //Codigo luis de la torre
                if (soloLectura) // deshabilitar el spinner
                {
                    holder.TipoMotivo.setEnabled(false);
                    holder.CaducidadEdit.setEnabled(false);
                    holder.LoteEdit.setEnabled(false);
                }

				holder.TipoMotivo.setTag(position);

				// asignar el listener solo si no es solo lectura
				if (!soloLectura)
				{
					fila.setOnLongClickListener(new OnLongClickListener()
					{

						@Override
						public boolean onLongClick(View v)
						{
							Log.d("Item", "LongClick");
							return false;
						}
					});
				}

				fila.setTag(holder);
			}
			else
			{
				holder = (Holder) fila.getTag();
			}

			TransProdDetalle producto = getItem(position);
			holder.ClaveProducto.setText(producto.ProductoClave + " - ");
			holder.NombreProducto.setText(producto.producto.Nombre);
			holder.Cantidad.setText(Generales.getFormatoDecimal(producto.Cantidad, producto.producto.DecimalProducto));
			holder.Unidad.setText(ValoresReferencia.getDescripcion("UNIDADV", String.valueOf(producto.TipoUnidad)));
			//holder.SubTotal.setText(Mensajes.get("XSubtotal") + ": " + Generales.getFormatoDecimal(producto.Subtotal, "$ #,##0.00"));
			//holder.Impuesto.setText(Mensajes.get("XImpuesto") + ": " + Generales.getFormatoDecimal(producto.Impuesto, "$ #,##0.00"));
			//holder.Total.setText(Mensajes.get("XTotal") + ": " + Generales.getFormatoDecimal(producto.Total, "$ #,##0.00"));
			holder.SubTotal.setText(Generales.getFormatoDecimal(producto.Subtotal, "$ #,##0.00"));
			holder.Impuesto.setText(Generales.getFormatoDecimal(producto.Impuesto, "$ #,##0.00"));
			holder.Total.setText(Generales.getFormatoDecimal(producto.Total, "$ #,##0.00"));
			holder.Motivo.setText(Mensajes.get("XMotivo"));
			Generales.SelectSpinnerItemByValue(holder.TipoMotivo, producto.TipoMotivo);

            /*Incio codigo luis de la torre*/
            // Validar parametro CapturaCadLote de GONAC

            try
            {
                if((!configParametro.existeParametro("CapturaCadLote", Sesion.get(Campo.ModuloMovDetalleClave).toString()))||(configParametro.existeParametro("CapturaCadLote", Sesion.get(Campo.ModuloMovDetalleClave).toString()) && configParametro.get("CapturaCadLote", Sesion.get(Campo.ModuloMovDetalleClave).toString()).equals("0")))
                {
                    holder.Lote.setVisibility(View.GONE);
                    holder.Caducidad.setVisibility(View.GONE);
                    holder.CaducidadEdit.setVisibility(View.GONE);
                    holder.LoteEdit.setVisibility(View.GONE);
                }
                else
                {
                    ManejoLotesCaducidad mlc = mPresenta.traerLotesCaducidad(producto.TransProdDetalleID);
                    holder.Lote.setText(Mensajes.get("XLote"));
                    holder.Caducidad.setText(Mensajes.get("XCaducidad"));



                    if(mlc.Caducidad != null && mlc.Lote != " ")
                    {
                        if(vueltas == 0 && position == 0)
                        {
                            SimpleDateFormat df = new SimpleDateFormat("yyyy-MM-dd",Locale.getDefault());
                            holder.LoteEdit.setText(mlc.Lote);
                            holder.CaducidadEdit.setText(df.format(mlc.Caducidad));
                        }

                        if(position > 0)
                        {
                            SimpleDateFormat df = new SimpleDateFormat("yyyy-MM-dd", Locale.getDefault());
                            holder.LoteEdit.setText(mlc.Lote);
                            holder.CaducidadEdit.setText(df.format(mlc.Caducidad));
                        }

                    }
                    vueltas ++;
                }
            }
            catch (Exception e)
            {
                // TODO Auto-generated catch block
                e.printStackTrace();
                holder.Lote.setVisibility(View.GONE);
                holder.Caducidad.setVisibility(View.GONE);
                holder.CaducidadEdit.setVisibility(View.GONE);
                holder.LoteEdit.setVisibility(View.GONE);
            }
			/*Fin codigo luis de la torre*/

			return fila;
		}

        //inicio codigo Luis de la torre
        public String[][] getValuesLoteCaducidad()
        {
            return mObjeto;
        }
        //Fin inicio luis de la torre

	}

	/*Inicio Adapter Doble Unidad*/
	public class DevolucionAdapterDobleUnidad extends ArrayAdapter<TransProdDetalle>
	{
		int textViewResourceId;
		Context context;
		TransProdDetalle objetos[];
		String mObjeto[][];
		int vueltas = 0;

		public DevolucionAdapterDobleUnidad(Context context, int textViewResourceId, TransProdDetalle[] objects)
		{
			super(context, textViewResourceId, objects);
			this.textViewResourceId = textViewResourceId;
			this.context = context;
			objetos = objects;

			mObjeto = new String[objects.length][3];

			for (int i = 0; i < objects.length; i++)
			{
				mObjeto[i][0] = null;
				mObjeto[i][1] = null;
				mObjeto[i][2] = null;
			}
		}

		@Override
		public int getViewTypeCount()
		{
			return objetos.length;
		}

		@Override
		public int getItemViewType(int position)
		{
			return position;
		}

		@Override
		public View getView(int position, View convertView, ViewGroup parent)
		{

			View fila = convertView;
			HolderDobleUnidad holder = null;
			final int posicion = position;

			//codigo luis de la torre
			mObjeto[posicion][0] = objetos[position].TransProdDetalleID;

			if (convertView == null)
			{
				LayoutInflater inflater = ((Activity) context).getLayoutInflater();
				fila = inflater.inflate(textViewResourceId, null);

				holder = new HolderDobleUnidad();
				holder.ClaveProducto = (TextView) fila.findViewById(R.id.lblClave);
				holder.NombreProducto = (TextView) fila.findViewById(R.id.lblNombre);
				holder.Cantidad1 = (TextView) fila.findViewById(R.id.lblCantidad1);
				holder.Unidad1 = (TextView) fila.findViewById(R.id.lblUnidad1);
				holder.Cantidad2 = (TextView) fila.findViewById(R.id.lblCantidad2);
				holder.Unidad2 = (TextView) fila.findViewById(R.id.lblUnidad2);
				holder.SubTotal = (TextView) fila.findViewById(R.id.lblSubtotal);
				holder.Impuesto = (TextView) fila.findViewById(R.id.lblImpuesto);
				holder.Total = (TextView) fila.findViewById(R.id.lblTotal);
				holder.Motivo = (TextView) fila.findViewById(R.id.lblMotivo);
				holder.TipoMotivo = (Spinner) fila.findViewById(R.id.cboMotivo);
                /*Incio codigo luis de la torre*/
				holder.Lote = (TextView) fila.findViewById(R.id.lblLote);
				holder.LoteEdit = (EditText) fila.findViewById(R.id.txtLote);
				holder.Caducidad = (TextView) fila.findViewById(R.id.lblCaducidad);
				holder.CaducidadEdit = (EditText) fila.findViewById(R.id.txtCaducidad);
				/*Fin codigo luis de la torre*/

				if (motivos.getCount() > 0)
				{
					@SuppressWarnings("deprecation")
					SimpleCursorAdapter adapter = new SimpleCursorAdapter(fila.getContext(), android.R.layout.simple_spinner_item, motivos, new String[]
							{ SearchManager.SUGGEST_COLUMN_TEXT_1 }, new int[]
							{ android.R.id.text1 });
					adapter.setDropDownViewResource(android.R.layout.simple_spinner_item);
					holder.TipoMotivo.setAdapter(adapter);
					holder.TipoMotivo.setOnItemSelectedListener(new OnItemSelectedListener()
					{
						@Override
						public void onItemSelected(AdapterView<?> arg0, View arg1, int arg2, long arg3)
						{
							try
							{
								if (arg1 == null)
									return;
								Spinner s = (Spinner) arg1.getParent();
								DevolucionAdapterDobleUnidad ladapter = (DevolucionAdapterDobleUnidad) lista.getAdapter();
								TransProdDetalle detalle = ladapter.getItem((Integer) s.getTag());
								Cursor item = (Cursor) arg0.getItemAtPosition(arg2);
								// actualizar solo si el motivo es diferente del
								// que tenia
								if (detalle.TipoMotivo != item.getShort(item.getColumnIndex(SearchManager.SUGGEST_COLUMN_INTENT_DATA)))
								{
									if (!mPresenta.actualizarMotivoDobleUnidad(detalle, item.getShort(item.getColumnIndex(SearchManager.SUGGEST_COLUMN_INTENT_DATA))))
									{
										Generales.SelectSpinnerItemByValue(s, detalle.TipoMotivo);
									}
								}
							}
							catch (Exception e)
							{
								mostrarError(e.getMessage());
							}
						}

						@Override
						public void onNothingSelected(AdapterView<?> arg0)
						{
						}
					});

                    /*Inicio codigo Luis de la torre*/

					holder.LoteEdit.addTextChangedListener(new TextWatcher()
					{

						@Override
						public void onTextChanged(CharSequence s, int start, int before, int count){}

						@Override
						public void beforeTextChanged(CharSequence s, int start, int count, int after){}

						@Override
						public void afterTextChanged(Editable s)
						{
							// TODO Auto-generated method stub
							//Log.e("VALOR DE LOTE", s.toString());
							mObjeto[posicion][1] = s.toString();
							//setHuboCambios(true);
						}
					});
					holder.CaducidadEdit.addTextChangedListener(new TextWatcher()
					{

						@Override
						public void onTextChanged(CharSequence s, int start, int before, int count){}

						@Override
						public void beforeTextChanged(CharSequence s, int start, int count, int after){}

						@Override
						public void afterTextChanged(Editable s)
						{
							// TODO Auto-generated method stub
							//Log.e("VALOR DE CADUCIDAD", s.toString());
							mObjeto[posicion][2] = s.toString();
							//setHuboCambios(true);
						}
					});

					/*Fin codigo Luis de la torre*/
				}

				//Codigo luis de la torre
				if (soloLectura) // deshabilitar el spinner
				{
					holder.TipoMotivo.setEnabled(false);
					holder.CaducidadEdit.setEnabled(false);
					holder.LoteEdit.setEnabled(false);
				}

				holder.TipoMotivo.setTag(position);

				// asignar el listener solo si no es solo lectura
				if (!soloLectura)
				{
					fila.setOnLongClickListener(new OnLongClickListener()
					{

						@Override
						public boolean onLongClick(View v)
						{
							Log.d("Item", "LongClick");
							return false;
						}
					});
				}

				fila.setTag(holder);
			}
			else
			{
				holder = (HolderDobleUnidad) fila.getTag();
			}

			TransProdDetalle producto = getItem(position);
			holder.ClaveProducto.setText(producto.ProductoClave + " - ");
			holder.NombreProducto.setText(producto.producto.Nombre);
			ProductoUnidad pru = new ProductoUnidad();
			try{
				pru.ProductoClave = producto.ProductoClave;
				pru.PRUTipoUnidad = Short.parseShort(String.valueOf(producto.TipoUnidad));
				BDVend.recuperar(pru);
			}catch(Exception ex){
				ex.printStackTrace();
			}
			holder.Cantidad1.setText(Generales.getFormatoDecimal(producto.Cantidad, pru.DecimalProducto ));
			holder.Unidad1.setText(ValoresReferencia.getDescripcion("UNIDADV", String.valueOf(producto.TipoUnidad)));
			if(producto.TPDDatosExtra != null && producto.TPDDatosExtra.size()>0 && producto.TPDDatosExtra.get(0).UnidadAlterna != null && producto.TPDDatosExtra.get(0).UnidadAlterna >0){
				ProductoUnidad pru2 = new ProductoUnidad();
				try{
					pru2.ProductoClave = producto.ProductoClave;
					pru2.PRUTipoUnidad = Short.parseShort(String.valueOf(producto.TPDDatosExtra.get(0).UnidadAlterna));
					BDVend.recuperar(pru2);
				}catch(Exception ex){
					ex.printStackTrace();
				}
				holder.Cantidad2.setVisibility(View.VISIBLE);
				holder.Unidad2.setVisibility(View.VISIBLE);
				holder.Cantidad2.setText(Generales.getFormatoDecimal(producto.TPDDatosExtra.get(0).CantidadAlterna, pru2.DecimalProducto));
				holder.Unidad2.setText(ValoresReferencia.getDescripcion("UNIDADV", String.valueOf(producto.TPDDatosExtra.get(0).UnidadAlterna)));
			}else{
				holder.Cantidad2.setVisibility(View.GONE);
				holder.Unidad2.setVisibility(View.GONE);
			}
			//holder.SubTotal.setText(Mensajes.get("XSubtotal") + ": " + Generales.getFormatoDecimal(producto.Subtotal, "$ #,##0.00"));
			//holder.Impuesto.setText(Mensajes.get("XImpuesto") + ": " + Generales.getFormatoDecimal(producto.Impuesto, "$ #,##0.00"));
			//holder.Total.setText(Mensajes.get("XTotal") + ": " + Generales.getFormatoDecimal(producto.Total, "$ #,##0.00"));
			holder.SubTotal.setText(Generales.getFormatoDecimal(producto.Subtotal, "$ #,##0.00"));
			holder.Impuesto.setText(Generales.getFormatoDecimal(producto.Impuesto, "$ #,##0.00"));
			holder.Total.setText(Generales.getFormatoDecimal(producto.Total, "$ #,##0.00"));
			holder.Motivo.setText(Mensajes.get("XMotivo"));
			Generales.SelectSpinnerItemByValue(holder.TipoMotivo, producto.TipoMotivo);

            /*Incio codigo luis de la torre*/
			// Validar parametro CapturaCadLote de GONAC

			try
			{
				if((!configParametro.existeParametro("CapturaCadLote", Sesion.get(Campo.ModuloMovDetalleClave).toString()))||(configParametro.existeParametro("CapturaCadLote", Sesion.get(Campo.ModuloMovDetalleClave).toString()) && configParametro.get("CapturaCadLote", Sesion.get(Campo.ModuloMovDetalleClave).toString()).equals("0")))
				{
					holder.Lote.setVisibility(View.GONE);
					holder.Caducidad.setVisibility(View.GONE);
					holder.CaducidadEdit.setVisibility(View.GONE);
					holder.LoteEdit.setVisibility(View.GONE);
				}
				else
				{
					ManejoLotesCaducidad mlc = mPresenta.traerLotesCaducidad(producto.TransProdDetalleID);
					holder.Lote.setText(Mensajes.get("XLote"));
					holder.Caducidad.setText(Mensajes.get("XCaducidad"));



					if(mlc.Caducidad != null && mlc.Lote != " ")
					{
						if(vueltas == 0 && position == 0)
						{
							SimpleDateFormat df = new SimpleDateFormat("yyyy-MM-dd",Locale.getDefault());
							holder.LoteEdit.setText(mlc.Lote);
							holder.CaducidadEdit.setText(df.format(mlc.Caducidad));
						}

						if(position > 0)
						{
							SimpleDateFormat df = new SimpleDateFormat("yyyy-MM-dd", Locale.getDefault());
							holder.LoteEdit.setText(mlc.Lote);
							holder.CaducidadEdit.setText(df.format(mlc.Caducidad));
						}

					}
					vueltas ++;
				}
			}
			catch (Exception e)
			{
				// TODO Auto-generated catch block
				e.printStackTrace();
				holder.Lote.setVisibility(View.GONE);
				holder.Caducidad.setVisibility(View.GONE);
				holder.CaducidadEdit.setVisibility(View.GONE);
				holder.LoteEdit.setVisibility(View.GONE);
			}
			/*Fin codigo luis de la torre*/

			return fila;
		}

		//inicio codigo Luis de la torre
		public String[][] getValuesLoteCaducidad()
		{
			return mObjeto;
		}
		//Fin inicio luis de la torre

	}
	/*Fin Adapter Doble Unidad*/

	static class Holder
	{
		TextView ClaveProducto;
		TextView NombreProducto;
		TextView Cantidad;
		TextView Unidad;
		TextView SubTotal;
		TextView Impuesto;
		TextView Total;
		TextView Motivo;
		Spinner TipoMotivo;
        //Inicio codigo luis de la torre
        TextView Lote;
        EditText LoteEdit;
        TextView Caducidad;
        EditText CaducidadEdit;
        //Fin codigo luis de la torre
	}

	static class HolderDobleUnidad
	{
		TextView ClaveProducto;
		TextView NombreProducto;
		TextView Cantidad1;
		TextView Unidad1;
		TextView Cantidad2;
		TextView Unidad2;
		TextView SubTotal;
		TextView Impuesto;
		TextView Total;
		TextView Motivo;
		Spinner TipoMotivo;
		//Inicio codigo luis de la torre
		TextView Lote;
		EditText LoteEdit;
		TextView Caducidad;
		EditText CaducidadEdit;
		//Fin codigo luis de la torre
	}

	public void setMensajeLimiteEnvase(boolean mostrandoMensaje){
		mensajeLimiteEnvase = mostrandoMensaje;
	}

	public boolean getMensajeLimiteEnvase(){
		return mensajeLimiteEnvase;
	}

    /*Incio codigo luis de la torre*/
    @SuppressWarnings("deprecation")
    public void validarCapturaPRecoleccion(String valor)
    {

        TextView texto;
        cboRecoleccion = (Spinner) findViewById(R.id.cboRecoleccion);
        txtTelefono = (EditText) findViewById(R.id.txtTelefono);

        if(valor.equals("0"))
        {
            texto = (TextView) findViewById(R.id.lblRecoleccion);
            texto.setVisibility(View.GONE);

            cboRecoleccion.setVisibility(View.GONE);

            texto = (TextView) findViewById(R.id.lblTelefono);
            texto.setVisibility(View.GONE);

            txtTelefono.setVisibility(View.GONE);

            texto = (TextView) findViewById(R.id.lblVolumen);
            texto.setVisibility(View.GONE);

            texto = (TextView) findViewById(R.id.txtVolumen);
            texto.setVisibility(View.GONE);

        }else
        {
            texto = (TextView) findViewById(R.id.lblRecoleccion);
            texto.setText(Mensajes.get("XPuntoRec"));

            texto = (TextView) findViewById(R.id.lblTelefono);
            texto.setText(Mensajes.get("XTelefono"));

            Cliente cliente = (Cliente) Sesion.get(Campo.ClienteActual);
            String[] domicilios = mPresenta.obtenerDomicilio(cliente.ClienteClave);
            cboRecoleccion.setAdapter(new ArrayAdapter<String>(this, android.R.layout.simple_spinner_item, domicilios));

        }

        if(soloLectura)
        {
			if(chbFechaRecoleccion != null)
            	chbFechaRecoleccion.setEnabled(false);
			if(btnFechaRecoleccion != null)
            	btnFechaRecoleccion.setEnabled(false);
            txtTelefono.setEnabled(false);
            cboRecoleccion.setEnabled(false);
        }
    }

    @Override
    public void setVolumen(String volumen)
    {
        txtVolumenValor.setText(Generales.getFormatoDecimal(Float.parseFloat(volumen), "#,##0.00"));
    }

    public int guardarLoteCaducidad()
    {
        int resultado = 0;

		String[][] manejoLoteCaducidad = null;
		if (((MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion)).get("ManejoDobleUnidad").toString().equals("1")) {
			DevolucionAdapterDobleUnidad cur = (DevolucionAdapterDobleUnidad) lista.getAdapter();
			manejoLoteCaducidad = cur.getValuesLoteCaducidad();
		}else{
			DevolucionAdapter cur = (DevolucionAdapter) lista.getAdapter();
			manejoLoteCaducidad = cur.getValuesLoteCaducidad();
		}


        for (int i = 0; i < manejoLoteCaducidad.length; i++)
        {
            String transprodDetalleId = "";
            String lote = "";
            String caducidad = "";

            if(manejoLoteCaducidad[i][1] == null)
            {
                Log.e("LOTE", "ESTA NULL EL LOTE");
                resultado = 1;
                break;
            }

            if(manejoLoteCaducidad[i][2] == null)
            {
                Log.e("CADUCIDAD", "ESTA NULL EL CADUCIDAD");
                resultado = 2;
                break;
            }

            transprodDetalleId = manejoLoteCaducidad[i][0];
            lote = manejoLoteCaducidad[i][1];
            caducidad = manejoLoteCaducidad[i][2];

            try
            {
                SimpleDateFormat formatoDelTexto = new SimpleDateFormat("yyyy-MM-dd",Locale.getDefault());
                Date fecha = null;

                fecha = formatoDelTexto.parse(caducidad);

                mPresenta.guardarLoteCaducidad(transprodDetalleId, lote, fecha);

                //resultado = true;
            }
            catch (ParseException e)
            {
                // TODO Auto-generated catch block
                e.printStackTrace();
                resultado = 3;
                break;
            }

        }

        return resultado;
    }

    public String getIdDomicilioSpinner()
    {
        String domicilio = cboRecoleccion.getSelectedItem().toString();

        String[] partes = domicilio.split(" ");

        String id = partes[partes.length - 1];

        return id;

    }

    @Override
    public void setTelefono(String telefono)
    {
        // TODO Auto-generated method stub
        txtTelefono.setText(telefono);

    }

    @Override
    public void setDireccion(String direccion)
    {
        // TODO Auto-generated method stub
        int index = 0;

        for (int i=0;i < cboRecoleccion.getCount();i++)
        {
            String valor = cboRecoleccion.getItemAtPosition(i).toString();
            String[] partes = valor.split(" ");
            if (partes[partes.length - 1].equals(direccion))
            {
                index = i;
                break;
            }
        }

        cboRecoleccion.setSelection(index);

    }


    @Override
    public void setRecoleccion(boolean recoleccion){
        chbFechaRecoleccion.setChecked(recoleccion);
    }

    @Override
    public void setFechaRecoleccion(Date fechaRecoleccion){
        if (bRecolectando || bConsultando){
            TextView lblFechaRecoleccion = (TextView)findViewById(R.id.lblFechaRecoleccion);
            lblFechaRecoleccion.setText(Mensajes.get("XFechaRecoleccion") + ": " + new SimpleDateFormat("dd/MMM/yyyy").format(fechaRecoleccion));
        }
        else
            btnFechaRecoleccion.setText(new SimpleDateFormat("dd/MMM/yyyy").format(fechaRecoleccion));
    }

    @Override
    public void ocultarRecoleccion(){
        if (bRecolectando || bConsultando) {
            chbFechaRecoleccion.setVisibility(View.GONE);
            btnFechaRecoleccion.setVisibility(View.GONE);
            TextView lblFechaRecoleccion = (TextView)findViewById(R.id.lblFechaRecoleccion);
            lblFechaRecoleccion.setVisibility(View.VISIBLE);
        }else{
            LinearLayout layFechaRecoleccion = (LinearLayout) findViewById(R.id.layFechaRecoleccion);
            layFechaRecoleccion.setVisibility(View.GONE);
        }
    }

    @Override
    public void habilitarRecoleccion(boolean habilitar){
        chbFechaRecoleccion.setEnabled(habilitar);
    }

	/*Fin codigo luis de la torre*/

	public void mostrarDialogoLoteCaducidad(String transProdDetalleId){
		String lote = "";
		Date caducidad = null;
		try{
			ManejoLotesCaducidad manejoLoteCaducidad;
			manejoLoteCaducidad = new ManejoLotesCaducidad();
			manejoLoteCaducidad.TransProdID = mPresenta.getTransProd().TransProdID;
			manejoLoteCaducidad.TransProdDetalleID = transProdDetalleId;
			BDVend.recuperar(manejoLoteCaducidad);
			if (manejoLoteCaducidad.isRecuperado()){
				lote = manejoLoteCaducidad.Lote;
				caducidad = manejoLoteCaducidad.Caducidad;
			}
		}catch(Exception ex){
			if(ex!=null && ex.getMessage()!= null) {
				mostrarError(ex.getMessage());
			}else{
				mostrarError("Error al recuperar el LoteCaducidad");
			}
		}
		LayoutInflater factory = LayoutInflater.from(this);
		final View textEntryView = factory.inflate(R.layout.dialog_lote_caducidad, null);

		final TextView lblLote = (TextView) textEntryView.findViewById(R.id.lblLote);
		lblLote.setText(Mensajes.get("XLote"));

		final TextView lblFechaCaducidad = (TextView) textEntryView.findViewById(R.id.lblFechaCaducidad);
		lblFechaCaducidad.setText(Mensajes.get("XCaducidad"));

		final EditText txtLote = (EditText) textEntryView.findViewById(R.id.txtLote);
		if (lote.length()>0) {
			txtLote.setText(lote);
		}
		final DatePicker dpFechaCaducidad = (DatePicker) textEntryView.findViewById(R.id.dpFechaCaducidad);
		if(caducidad != null){
			Calendar now =new GregorianCalendar();
			now.setTime(caducidad);
			dpFechaCaducidad.updateDate(caducidad.getYear() + 1900, caducidad.getMonth(), caducidad.getDate());
		}
		transProdIdDialogo = transProdDetalleId;

		//txtLote.setText(lote);
		//txtUser.setEnabled(fechaCaducidad);

		final AlertDialog.Builder alert = new AlertDialog.Builder(this, R.style.MisClientes_CustomDialog);
		alert.setTitle("").setView(textEntryView).
				setPositiveButton(Mensajes.get("BTContinuar"), null).
				setNegativeButton(Mensajes.get("BTRegresar"), null);
		dialogoLoteCaducidad = alert.create();
		dialogoLoteCaducidad.show();
		dialogoLoteCaducidad.getButton(AlertDialog.BUTTON_POSITIVE).setOnClickListener(new OnClickListener(){
			public void onClick(View v){
				try{
					String loteDialogo = txtLote.getText().toString();
					Calendar tmp = Calendar.getInstance();
					tmp.setTime((new SimpleDateFormat("dd/MM/yyyy")).parse(new SimpleDateFormat("dd/MM/").format(new Date(dpFechaCaducidad.getYear(), dpFechaCaducidad.getMonth(), dpFechaCaducidad.getDayOfMonth())) + (new Date(dpFechaCaducidad.getYear(), dpFechaCaducidad.getMonth(), dpFechaCaducidad.getDayOfMonth())).getYear()));
					Date caducidadDialogo = tmp.getTime();

					if (loteDialogo.length() == 0){
						txtLote.requestFocus();
						mostrarAdvertencia(Mensajes.get("BE0001", lblLote.getText().toString()));
						return;
					}
					if(configParametro.existeParametro("CapturaCadLote", Sesion.get(Campo.ModuloMovDetalleClave).toString()) && configParametro.get("CapturaCadLote", Sesion.get(Campo.ModuloMovDetalleClave).toString()).equals("1")) {
						mPresenta.guardarLoteCaducidad(transProdIdDialogo, loteDialogo, caducidadDialogo);
						refrescarProductos(transProdIdDialogo);
					}
					dialogoLoteCaducidad.dismiss();
				}catch (Exception ex){
					if (ex != null && ex.getMessage() != null) {
						mostrarError(ex.getMessage());
					}else{
						mostrarError("Error al capturar Lote-Caducidad");
					}
				}
			}
		});
	}

	public void validarPermisos(String tipoIndice, int tipoPermiso) //Metodo que valida permisos ldelatorre
	{
		boolean validar = false;
		try {
			String id = "TINDMMD" + tipoIndice;
			String permiso = Consultas.ConsultasPermisos.validarPermisos(id);
			contrasenaPara = ValoresReferencia.getDescripcion("TINDMMD", String.valueOf(tipoIndice));
			Log.i(null, "Chequeo de variables id:" + id + " permiso: " + permiso);
			if (((ConfigParametro) Sesion.get(Sesion.Campo.ConfigParametro)).existeParametro("ValidarAcceso", tipoIndice)) {
				if (((ConfigParametro) Sesion.get(Sesion.Campo.ConfigParametro)).get("ValidarAcceso", tipoIndice).equals("1"))
				{
					switch (tipoPermiso) {
						case Enumeradores.TipoPermiso.ACCESAR:
							if (permiso.equals("")) {
								showAlertDialog(contrasenaPara);
							}
							break;

						case Enumeradores.TipoPermiso.CREAR:
							if (!lineaPermiso('C', permiso)) {

								showAlertDialog(contrasenaPara);
							}
							break;

						case Enumeradores.TipoPermiso.MODIFICAR:
							if (!lineaPermiso('U', permiso)) {

								showAlertDialog(contrasenaPara);
							}
							break;

						case Enumeradores.TipoPermiso.ELIMINAR:
							if (!lineaPermiso('D', permiso)) {
								showAlertDialog(contrasenaPara);
							}
							break;
					}
				}
			}
			validar = vali;

		}
		catch (Exception e)
		{
			// TODO Auto-generated catch block
			e.printStackTrace();
		}

		//return validar;
	}

	public void showAlertDialog(final String contrasenaPara)//Metodo que valida permisos ldelatorre
	{

		LayoutInflater factory = LayoutInflater.from(this);

		// text_entry is an Layout XML file containing two text field to display
		// in alert dialog

		contrasena = contrasenaPara;
		final View textEntryView = factory.inflate(R.layout.acceso_dia_diferente, null);

		final TextView lblLogin = (TextView) textEntryView.findViewById(R.id.lblAlertUser);
		lblLogin.setText(Mensajes.get("XUsuario"));

		final TextView lblPass = (TextView) textEntryView.findViewById(R.id.lblAlertPass);
		lblPass.setText(Mensajes.get("XContraseña"));

		final EditText txtUser = (EditText) textEntryView.findViewById(R.id.txtAlertUser);
		final EditText txtPass = (EditText) textEntryView.findViewById(R.id.txtAlertPass);

		final AlertDialog.Builder alert = new AlertDialog.Builder(this, R.style.MisClientes_CustomDialog);
		//Sin esta linea el dialogo se cierra al perder el foco
		alert.setCancelable(false);
		alert.setTitle(contrasenaPara).setView(textEntryView).setPositiveButton(Mensajes.get("BTContinuar"), new DialogInterface.OnClickListener()
		{
			public void onClick(DialogInterface dialog, int whichButton)
			{
				String clave = txtUser.getText().toString();
				String pass = txtPass.getText().toString();

				if (validarInformacion(clave, pass)) {
					Usuario usuario = null;
					try {
						usuario = Consultas.ConsultasUsuario.obtenerUsuarioPorClave(clave);
					} catch (Exception e) {
						e.printStackTrace();
						mostrarMensajeLocal(e.getMessage(),0,4,contrasena);
					}

					if ((usuario == null) || (!EncriptaDesencripta.encripta(pass).equals(usuario.ClaveAcceso))) {
						mostrarMensajeLocal(Mensajes.get("MDB050601"),0,4,contrasena);
					} else {
						String[] perfiles;
						List<String> listaPerfiles = new ArrayList();
						String perfilesAutorizados = "";
						try {
							if (((ConfigParametro) Sesion.get(Sesion.Campo.ConfigParametro)).existeParametro("PerfilContraseñaUsuario", Sesion.get(Sesion.Campo.ModuloMovDetalleClave).toString())) {
								perfiles = ((ConfigParametro) Sesion.get(Sesion.Campo.ConfigParametro)).get("PerfilContraseñaUsuario", Sesion.get(Sesion.Campo.ModuloMovDetalleClave).toString()).toString().toUpperCase().split("\\|");
								listaPerfiles = Arrays.asList(perfiles);
								perfilesAutorizados = ((ConfigParametro) Sesion.get(Sesion.Campo.ConfigParametro)).get("PerfilContraseñaUsuario", Sesion.get(Sesion.Campo.ModuloMovDetalleClave).toString()).toString().toUpperCase();
							}
						} catch (Exception ex) {
							if (ex != null && ex.getMessage() != null) {
								mostrarMensajeLocal(ex.getMessage(),0,4,contrasena);
							} else {
								mostrarMensajeLocal("Error al recuperar parámetro PerfilContraseñaUsuario",0,4,contrasena);
							}

						}

						if (listaPerfiles != null && listaPerfiles.size() > 0) {
							if (!listaPerfiles.contains(usuario.PERClave.toUpperCase())) {
								mostrarMensajeLocal(Mensajes.get("I0328",perfilesAutorizados.replace("|", ",")),0,4,contrasena);
							}
							vali = true;
						} else {
							if (!usuario.PERClave.equals("Admin"))
								mostrarMensajeLocal(Mensajes.get("I0271"),0,4,contrasena);
							else
								vali = true;
						}

					}
				}
			}
		}).setNegativeButton(Mensajes.get("BTRegresar"), new DialogInterface.OnClickListener()
		{
			public void onClick(DialogInterface dialog, int whichButton)
			{
				regresar();
			}
		}).setOnKeyListener(new DialogInterface.OnKeyListener()
		{

			@Override
			public boolean onKey(DialogInterface dialog, int keyCode, KeyEvent event)
			{
				switch (keyCode)
				{
					case KeyEvent.KEYCODE_BACK:
						regresar();
						break;
				}
				return false;
			}
		});

		alert.show();
		//return vali;
	}

	private boolean lineaPermiso(char per, String permisos)//Metodo que valida permisos ldelatorre
	{
		for(int x = 0; x < permisos.length(); x++)
		{
			char caracter = permisos.charAt(x);

			if(caracter == per)
			{
				return true;
			}
		}
		return false;
	}

	private boolean validarInformacion(String id, String pass)
	{
		if (id.length() == 0)
		{
			mostrarMensajeLocal(Mensajes.get("BE0001", Mensajes.get("XUsuario")),0,4, contrasena);
			return false;
		}
		if (pass.length() == 0)
		{
			mostrarMensajeLocal(Mensajes.get("BE0001", Mensajes.get("XContraseña")),0,4, contrasena);
			return false;
		}
		return true;
	}

	public void mostrarMensajeLocal(final String mensaje, final Integer icono, final Integer tipoMensaje, final String contrasena)
	{
		DialogoAlerta dialogo = new DialogoAlerta(this);
		dialogo.setMessage(mensaje);
		String msgSi = "Si";
		if (Mensajes.existe())
		{
			msgSi = Mensajes.get("XAceptar");
		}
		dialogo.setButton(msgSi, new DialogInterface.OnClickListener()
		{
			public void onClick(DialogInterface dialog, int id)
			{
				respuestaMensaje(RespuestaMsg.OK, tipoMensaje);
				dialog.dismiss();
				showAlertDialog(contrasena);
			}
		});
		if (icono != null)
			dialogo.setIcon(icono);

		dialogo.setCancelable(false);
		dialogo.setCanceledOnTouchOutside(false);
		dialogo.show();
	}

}
