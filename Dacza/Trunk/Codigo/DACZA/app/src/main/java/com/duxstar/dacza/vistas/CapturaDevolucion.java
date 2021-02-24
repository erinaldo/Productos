package com.duxstar.dacza.vistas;

import android.content.Context;
import android.content.Intent;
import android.os.Bundle;
import android.view.ContextMenu;
import android.view.ContextMenu.ContextMenuInfo;
import android.view.KeyEvent;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.view.View.OnClickListener;
import android.view.inputmethod.InputMethodManager;
import android.widget.AdapterView.AdapterContextMenuInfo;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ListView;
import android.widget.TextView;

import com.duxstar.dacza.R;
import com.duxstar.dacza.controles.CapturaArticulo;
import com.duxstar.dacza.datos.Articulo;
import com.duxstar.dacza.datos.DEVDetalle;
import com.duxstar.dacza.datos.basedatos.BDTerm;
import com.duxstar.dacza.datos.utilerias.Sesion;
import com.duxstar.dacza.datos.utilerias.Sesion.Campo;
import com.duxstar.dacza.presentadores.Enumeradores;
import com.duxstar.dacza.presentadores.Enumeradores.RespuestaMsg;
import com.duxstar.dacza.presentadores.act.CapturarDevolucion;
import com.duxstar.dacza.presentadores.interfaces.ICapturaDevolucion;
import com.duxstar.dacza.utilerias.ControlError;
import com.duxstar.dacza.utilerias.Generales;
import com.duxstar.dacza.vistas.generico.DEVDetalleAdapter;

import java.util.Collections;
import java.util.HashMap;


public class CapturaDevolucion extends Vista implements ICapturaDevolucion
{
	CapturarDevolucion mPresenta;
	String mAccion;
	HashMap<String, String> oParametros = null;
	CapturaArticulo captura;
	ListView lista;
	boolean huboCambios = false;
	//boolean esNuevo = true;
	boolean soloLectura = false;
	Button btnContinuar;
    Button btnCerrar;
    String devolucionId;

    DEVDetalle detalleEliminar;

	@SuppressWarnings(
	{ "unchecked", "deprecation" })
	@Override
	public void onCreate(Bundle savedInstanceState)
	{
		try
		{
			super.onCreate(savedInstanceState);
			mAccion = getIntent().getAction();
			setContentView(R.layout.captura_articulo_devolucion);
			deshabilitarBarra(true);
			setTitulo("Devolucion");

            mPresenta = new CapturarDevolucion(this, mAccion);

            if (getIntent().getSerializableExtra("parametros") != null)
                oParametros = (HashMap<String, String>) getIntent().getSerializableExtra("parametros");

            if (oParametros != null && oParametros.get("SoloLectura") != null)
                soloLectura = true;


            if (oParametros != null && (oParametros.get("DevolucionId") != null))
            {
                huboCambios = false;
                devolucionId = oParametros.get("DevolucionId");
                mPresenta.setDevolucionId(devolucionId);
                Sesion.set(Campo.DevolucionActual, devolucionId);
            }

            btnCerrar = (Button) findViewById(R.id.btnCerrar);

			btnContinuar = (Button) findViewById(R.id.btnContinuar);
            lista = (ListView) findViewById(R.id.lstDetalle);
            captura = (CapturaArticulo) findViewById(R.id.capturaArticulo);

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

                lista.setClickable(true);
                registerForContextMenu(lista);

                captura.setOnAgregarArticuloListener(new CapturaArticulo.onAgregarArticuloListener() {
                    @Override
                    public void onAgregarArticulo(Articulo articulo, float cantidad) {
                        try {
                            DEVDetalle detalle = null;
                            if (articulo != null)
                                detalle = mPresenta.existe(articulo);

                            if (detalle != null) { //si ya existe
                                if (detalle.Cantidad != cantidad) {
                                    StringBuilder error = new StringBuilder();
                                    //actualizar la cantidad
                                    if (mPresenta.actualizarCantidad(detalle, cantidad, error)) {
                                        captura.setAdvertencia("");
                                    } else {
                                        captura.setError(error.toString());
                                    }
                                }
                            } else {
                                //si no existe agregarlo con el ultimo motivo seleccionado
                                StringBuilder error = new StringBuilder();
                                if (mPresenta.agregarArticulo(articulo, cantidad, error)) {
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

                captura.setOnArticuloNoEncontradoListener(new CapturaArticulo.onArticuloNoEncontradoListener() {

                    @Override
                    public void onArticuloNoEncontrado() {
                        //captura.setTransProdIds(mPresenta.getTransaccionesIds());
                    }
                });
            }

			mPresenta.iniciar();
            if (devolucionId != null)
                refrescarProductos(devolucionId);

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
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item)
    {
        return true;
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
                    Sesion.set(Campo.IdDocumentoEnviar, mPresenta.getDevolucion().DevolucionId);
                } else
                    setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
                finalizar();
            } else {
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
					mPresenta.insertarSeleccion((HashMap<String, DEVDetalle>) Sesion.get(Campo.ResultadoActividad));
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
	}

   	@Override
	public void respuestaMensaje(RespuestaMsg respuesta, int tipoMensaje)
	{
        if (tipoMensaje == 2) //cerrar recarga
        {
            if (respuesta == RespuestaMsg.Si) {
                try {
                    if (mPresenta.getDevolucion().DEVDetalle.size() <= 0)
                        throw new ControlError("Se debe asignar por lo menos un producto a la devolucion");

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
				refrescarProductos(devolucionId);
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
		inflater.inflate(R.menu.context_movimiento_detalle, menu);
		menu.getItem(0).setTitle("Eliminar");
	}

	@Override
	public boolean onContextItemSelected(MenuItem item)
	{
		AdapterContextMenuInfo info = (AdapterContextMenuInfo) item.getMenuInfo();
		detalleEliminar = (DEVDetalle) lista.getItemAtPosition(info.position);
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
                    if (mPresenta.getDevolucion().DEVDetalle.size() <= 0)
                        throw new ControlError("Se debe asignar por lo menos un producto a la devolución");

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
                mostrarPreguntaSiNo("¿Desea cerrar la devolución?", 2);
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

            if (mPresenta.getDevolucion().DEVDetalle.size() > 0)
            {
                Collections.sort(mPresenta.getDevolucion().DEVDetalle, new DEVDetalle.comparator());
                DEVDetalleAdapter adapter = new DEVDetalleAdapter(this, R.layout.elemento_articulo_orden, mPresenta.getDevolucion().DEVDetalle.toArray(new DEVDetalle[mPresenta.getDevolucion().DEVDetalle.size()]));
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

    public void modificarProducto(String clave,float cantidad){
        captura.setEnableCantidadAgregar(true);
        captura.setValoresProductoModificar(clave, cantidad);
    }
}
