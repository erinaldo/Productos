package com.duxstar.dacza.vistas;

import java.util.ArrayList;
import java.util.Collections;
import java.util.HashMap;
import java.util.Hashtable;
import java.util.Iterator;
import java.util.Map;
import java.util.ResourceBundle;

import android.app.Activity;
import android.app.SearchManager;
import android.content.Context;
import android.content.Intent;
import android.database.Cursor;
import android.os.Bundle;
import android.text.TextUtils;
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
import android.widget.EditText;
import android.widget.ListView;
import android.widget.SimpleCursorAdapter;
import android.widget.Spinner;
import android.widget.TextView;
import android.widget.Toast;

import com.duxstar.dacza.R;
import com.duxstar.dacza.controles.CapturaArticulo;
import com.duxstar.dacza.controles.CapturaArticuloDesc;
import com.duxstar.dacza.datos.Articulo;
import com.duxstar.dacza.datos.ODTDetalle;
import com.duxstar.dacza.datos.RECDetalle;
import com.duxstar.dacza.datos.basedatos.BDTerm;
import com.duxstar.dacza.datos.utilerias.Sesion;
import com.duxstar.dacza.datos.utilerias.Sesion.Campo;
import com.duxstar.dacza.presentadores.Enumeradores;
import com.duxstar.dacza.presentadores.Enumeradores.RespuestaMsg;
import com.duxstar.dacza.presentadores.act.CapturarArticuloOrden;
import com.duxstar.dacza.presentadores.act.CapturarRecarga;
import com.duxstar.dacza.presentadores.interfaces.ICapturaArticuloOrden;
import com.duxstar.dacza.presentadores.interfaces.ICapturaRecarga;
import com.duxstar.dacza.utilerias.ControlError;
import com.duxstar.dacza.utilerias.Generales;
import com.duxstar.dacza.vistas.generico.ODTDetalleAdapter;
import com.duxstar.dacza.vistas.generico.RECDetalleAdapter;


public class CapturaRecarga extends Vista implements ICapturaRecarga
{
	CapturarRecarga mPresenta;
	String mAccion;
	HashMap<String, String> oParametros = null;
	CapturaArticuloDesc captura;
	ListView lista;
	boolean huboCambios = false;
	//boolean esNuevo = true;
	boolean soloLectura = false;
    boolean mostrarTransferencia = false;
	Button btnContinuar;
    Button btnCerrar;
    String recargaId;
    String tituloFoto;

    RECDetalle detalleEliminar;

	@SuppressWarnings(
	{ "unchecked", "deprecation" })
	@Override
	public void onCreate(Bundle savedInstanceState)
	{
		try
		{
			super.onCreate(savedInstanceState);
			mAccion = getIntent().getAction();
			setContentView(R.layout.captura_articulo_recarga);
			deshabilitarBarra(true);
			setTitulo("Solicitud de Traspaso");
            tituloFoto = "";

            mPresenta = new CapturarRecarga(this, mAccion);

            if (getIntent().getSerializableExtra("parametros") != null)
                oParametros = (HashMap<String, String>) getIntent().getSerializableExtra("parametros");

            if (oParametros != null && oParametros.get("SoloLectura") != null)
                soloLectura = true;

            if (oParametros != null && oParametros.get("MostrarTransferencia") != null)
                mostrarTransferencia = true;

            if (oParametros != null && (oParametros.get("RecargaId") != null))
            {
                huboCambios = false;
                recargaId = oParametros.get("RecargaId");
                mPresenta.setRecargaId(recargaId);
                Sesion.set(Campo.RecargaActual, recargaId);
            }

            btnCerrar = (Button) findViewById(R.id.btnCerrar);

			btnContinuar = (Button) findViewById(R.id.btnContinuar);
            lista = (ListView) findViewById(R.id.lstDetalle);
            captura = (CapturaArticuloDesc) findViewById(R.id.capturaArticulo);

            lista.setClickable(true);
            registerForContextMenu(lista);

            if (soloLectura) {
                btnContinuar.setVisibility(View.GONE);
                btnCerrar.setVisibility(View.GONE);
                captura.setVisibility(View.GONE);
            }
            else {
                btnCerrar.setText("Cerrar");
                btnCerrar.setOnClickListener(mCerrar);

                btnContinuar.setText("Continuar");
                btnContinuar.setOnClickListener(mContinuar);

                //lista.setClickable(true);
                //registerForContextMenu(lista);

                captura.setOnAgregarArticuloListener(new CapturaArticuloDesc.onAgregarArticuloListener() {
                    @Override
                    public void onAgregarArticulo(Articulo articulo, String articuloDesc, float cantidad) {
                        try {
                            RECDetalle detalle = null;
                            if (articulo != null)
                                detalle = mPresenta.existe(articulo);
                            else
                                detalle = mPresenta.existe(articuloDesc);

                            if (detalle != null) { //si ya existe
                                if (detalle.Cantidad != cantidad) {
                                    StringBuilder error = new StringBuilder();
                                    //actualizar la cantidad
                                    if (mPresenta.actualizarDetalle(detalle, cantidad, tituloFoto, error)) {
                                        tituloFoto = "";
                                        captura.setAdvertencia("");
                                    } else {
                                        captura.setError(error.toString());
                                    }

                                }
                            } else {
                                //si no existe agregarlo con el ultimo motivo seleccionado
                                StringBuilder error = new StringBuilder();
                                if (mPresenta.agregarArticulo(articulo, articuloDesc, cantidad, tituloFoto, error)) {
                                    tituloFoto = "";
                                    captura.setAdvertencia("");
                                } else {
                                    captura.setError(error.toString());
                                }
                            }
                            btnContinuar.setEnabled(true);
                            btnCerrar.setEnabled(true);
                        } catch (Exception e) {
                            mostrarError(e.getMessage());
                        }
                    }
                });

                captura.setOnArticuloNoEncontradoListener(new CapturaArticuloDesc.onArticuloNoEncontradoListener() {

                    @Override
                    public void onArticuloNoEncontrado() {
                        //captura.setTransProdIds(mPresenta.getTransaccionesIds());
                    }
                });

                captura.setOnCapturarImagenListener(new CapturaArticuloDesc.onCapturarImagenListener(){
                    @Override
                    public void onCapturarImagen(){
                        tituloFoto = "";
                        Intent intent = new Intent(CapturaRecarga.this, CapturaImagen.class);
                        intent.putExtra("folio", mPresenta.getRecarga().Folio);
                        startActivityForResult(intent, Enumeradores.Solicitudes.SOLICITUD_CAPTURA_IMAGEN);
                    }
                });
            }

			mPresenta.iniciar();
            if (recargaId != null)
                refrescarProductos(recargaId);

		}
		catch (Exception ex)
		{
			mostrarError(ex.getMessage().equals("") ? ex.getCause().getMessage() : ex.getMessage());
		}

        final InputMethodManager imm = (InputMethodManager) getSystemService(Context.INPUT_METHOD_SERVICE);

        if (soloLectura){
            lista.requestFocus();
            imm.hideSoftInputFromWindow(this.getCurrentFocus().getWindowToken(), InputMethodManager.HIDE_IMPLICIT_ONLY);
        }
        else {
            final EditText txtScaner = (EditText) findViewById(R.id.txtScanner);
            final EditText txtCantidad = (EditText) findViewById(R.id.txtCantidad);

            txtCantidad.setOnFocusChangeListener(new View.OnFocusChangeListener()
            {
                @Override
                public void onFocusChange(View v, boolean hasFocus)
                {
                    // TODO Auto-generated method stub
                    if (hasFocus)
                    {
                        // getWindow().setSoftInputMode(WindowManager.LayoutParams.SOFT_INPUT_STATE_VISIBLE);
                        txtScaner.clearFocus();
                        imm.showSoftInput(txtCantidad, InputMethodManager.SHOW_FORCED);

                        Float mCantidad = mPresenta.consultarArticuloExistente();
                        if (mCantidad != (float)0)
                        {
                            txtCantidad.setText(Generales.getFormatoDecimal(mCantidad, 2));
                            txtCantidad.requestFocus();
                            txtCantidad.selectAll();
                            txtCantidad.setSelectAllOnFocus(true);
                        }
                    }
                }
            });

            txtScaner.setOnFocusChangeListener(new View.OnFocusChangeListener()
            {
                @Override
                public void onFocusChange(View v, boolean hasFocus)
                {

                    if (hasFocus)
                    {
                        txtCantidad.clearFocus();
                    }
                }
            });
        }
	}

	@Override
	public void iniciar()
	{
	}

    @Override
    public boolean onCreateOptionsMenu(Menu menu)
    {
        /*if (mostrarTransferencia) {
            try {
                menu.add(0, Enumeradores.ACTMENU.VER_TRASPASO, Enumeradores.ACTMENU.VER_TRASPASO, "Consultar Traspaso");
            } catch (Exception e) {
                mostrarError(e.getMessage());
            }
        }*/

        return true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item)
    {
        switch (item.getItemId())
        {
            case Enumeradores.ACTMENU.VER_TRASPASO:
                mPresenta.consultarTraspasos();
                return true;
            default:
                return super.onOptionsItemSelected(item);
        }
    }

	@Override
	public boolean onKeyDown(int keyCode, KeyEvent event)
	{
		switch (keyCode)
		{
			case KeyEvent.KEYCODE_BACK:
				salir(false);
				return true;
		}
        //return true;
		return super.onKeyDown(keyCode, event);
	}

	private void salir(boolean enviar)
	{
        if (!soloLectura && huboCambios && !enviar)
            mostrarPreguntaSiNo("Se perderán los cambios. ¿Está seguro de regresar?", 3);
		else
		{
            if (huboCambios) {
                if (enviar) {
                    setResultado(Enumeradores.Resultados.RESULTADO_ENVIAR);
                    Sesion.set(Campo.IdDocumentoEnviar, mPresenta.getRecarga().RecargaId);
                } else
                    setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
                finalizar();
            }else {
                huboCambios = true;
                regresar();
            }
		}
	}

	private void regresar()
	{
		try
		{
            if (huboCambios)
                BDTerm.rollback();
			setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
			finalizar();
		}
		catch (Exception ex)
		{
			mostrarError(ex.getMessage());
		}
	}

	@SuppressWarnings("unchecked")
	@Override
	public void resultadoActividad(int requestCode, int resultCode, Intent data)
	{
		if (requestCode == Enumeradores.Solicitudes.SOLICITUD_BUSQUEDA_ARTICULOS)
		{
			//si esta regresando de la busqueda de productos
			if (resultCode == Enumeradores.Resultados.RESULTADO_BIEN)
			{
				//si selecciono Agregar en la busqueda de productos, obtener la seleccion y agregarlos al pedido
				if (Sesion.get(Campo.ResultadoActividad) != null)
				{
					mPresenta.insertarSeleccion((HashMap<String, RECDetalle>) Sesion.get(Campo.ResultadoActividad));
					Sesion.remove(Campo.ResultadoActividad);
				}
			}else if (resultCode == Enumeradores.Resultados.RESULTADO_MAL)
			{
				if (data != null)
				{
					String mensajeError = (String) data.getExtras().getString("mensajeIniciar");
					if (!mensajeError.equals(""))
					{ // cuando se presiona back se manda el mensaje vacio
						mostrarError(mensajeError);
					}
				}
			}
			captura.setFinBusqueda();
		}
        else if(requestCode == Enumeradores.Solicitudes.SOLICITUD_CAPTURA_IMAGEN && resultCode == Enumeradores.Resultados.RESULTADO_BIEN){
            if (Sesion.get(Campo.ResultadoActividad) != null)
            {
                tituloFoto = (String)Sesion.get(Campo.ResultadoActividad);
                captura.setTituloImagen(tituloFoto);
                Sesion.remove(Campo.ResultadoActividad);
            }
        }
	}

   	@Override
	public void respuestaMensaje(RespuestaMsg respuesta, int tipoMensaje)
	{
        if (tipoMensaje == 2) //cerrar recarga
        {
            if (respuesta == RespuestaMsg.Si) {
                try {
                    if (mPresenta.getRecarga().RECDetalle.size() <= 0)
                        throw new ControlError("Se debe asignar por lo menos un producto a la solicitud de traspaso");

                    mPresenta.guardar(true);
                    huboCambios = true;
                    salir(true);
                } catch (Exception e) {
                    mostrarError(e.getMessage());
                }
            }
        }
        else if (tipoMensaje == 3)
		{
			if (respuesta == RespuestaMsg.Si)
			{
				regresar();
			}
		}
		else if (tipoMensaje == 5)
		{ //eliminar producto
			if (respuesta.equals(RespuestaMsg.Si))
			{
				mPresenta.eliminarDetalle(detalleEliminar);
				refrescarProductos(recargaId);
				huboCambios = true;
                btnContinuar.setEnabled(true);
                btnCerrar.setEnabled(true);
			}
		}
	}

	@Override
	public void onCreateContextMenu(ContextMenu menu, View v, ContextMenuInfo menuInfo)
	{
		super.onCreateContextMenu(menu, v, menuInfo);
		MenuInflater inflater = getMenuInflater();
		inflater.inflate(R.menu.context_recarga_detalle, menu);
        if (!soloLectura)
		    menu.getItem(0).setTitle("Eliminar");
        else
            menu.getItem(0).setVisible(false);

        AdapterContextMenuInfo info = (AdapterContextMenuInfo) menuInfo;
        //ListView lista = (ListView) findViewById(R.id.lstOrdenes);
        RECDetalle detalle = (RECDetalle)lista.getItemAtPosition(info.position);
        if (detalle.Imagen != null) {
            if (detalle.Imagen.equals(""))
                    menu.getItem(1).setVisible(false);
            else
                menu.getItem(1).setTitle("Ver Imagen");
        }else
            menu.getItem(1).setVisible(false);

	}

	@Override
	public boolean onContextItemSelected(MenuItem item)
	{
		AdapterContextMenuInfo info = (AdapterContextMenuInfo) item.getMenuInfo();
		detalleEliminar = (RECDetalle) lista.getItemAtPosition(info.position);
		switch (item.getItemId())
		{
			case R.id.eliminar:
				try
				{
					mostrarPreguntaSiNo("El artículo será eliminado de la lista. ¿Desea Continuar?", 5);
				}
				catch (Exception e)
				{
					mostrarError(e.getMessage());
				}
				return true;
            case R.id.imagen:
                Intent intent = new Intent(CapturaRecarga.this, CapturaImagen.class);
                intent.putExtra("tituloFoto", detalleEliminar.Imagen);
                startActivityForResult(intent, Enumeradores.Solicitudes.SOLICITUD_CAPTURA_IMAGEN);
                return true;
		}
		return false;
	}

	public void setFolio(String folio)
	{
		TextView texto = (TextView) findViewById(R.id.lblFolio);
		texto.setText("Folio: " + folio);
	}

	public void setFecha(String fecha)
	{
		TextView texto = (TextView) findViewById(R.id.lblFecha);
		texto.setText("Fecha: " + fecha);
	}

	public void setHuboCambios(boolean cambio)
	{
		huboCambios = cambio;
	}

	public boolean getHuboCambios()
	{
		return huboCambios;
	}

	public void setCantidadCaptura(Float cantidad)
	{
		captura.setCantidad(cantidad);
	}

	private OnClickListener mContinuar = new OnClickListener()
	{

		@Override
		public void onClick(View v)
		{
			try
			{
                if (!soloLectura)
                { //nuevo y modificar
                    if (mPresenta.getRecarga().RECDetalle.size() <= 0)
                        throw new ControlError("Se debe asignar por lo menos un producto a la solicitud de traspaso");

                    mPresenta.guardar(false);
                    huboCambios = false;
                    salir(false);
                }
			}
			catch (Exception e)
			{
				mostrarError(e.getMessage());
			}
		}
	};

    private OnClickListener mCerrar = new OnClickListener()
    {

        @Override
        public void onClick(View v)
        {
            try
            {
                mostrarPreguntaSiNo("¿Desea cerrar la solicitud de traspaso?", 2);
            }
            catch (Exception e)
            {
                mostrarError(e.getMessage());
            }
        }
    };

	public void refrescarProductos(String TransProdId)
	{

        try
        {

            if (mPresenta.getRecarga().RECDetalle.size() > 0)
            {
                Collections.sort(mPresenta.getRecarga().RECDetalle, new RECDetalle.comparator());
                RECDetalleAdapter adapter = new RECDetalleAdapter(this, R.layout.elemento_articulo_recarga, mPresenta.getRecarga().RECDetalle.toArray(new RECDetalle[mPresenta.getRecarga().RECDetalle.size()]));
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

    public void modificarProducto(String clave,float cantidad, boolean descripcion){
        captura.setEnableCantidadAgregar(true);
        captura.setValoresProductoModificar(clave, cantidad, descripcion);
    }
}
