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
import com.duxstar.dacza.actividades.Observaciones;
import com.duxstar.dacza.controles.CapturaArticulo;
import com.duxstar.dacza.datos.Articulo;
import com.duxstar.dacza.datos.ODTDetalle;
import com.duxstar.dacza.datos.basedatos.BDTerm;
import com.duxstar.dacza.datos.utilerias.Sesion;
import com.duxstar.dacza.datos.utilerias.Sesion.Campo;
import com.duxstar.dacza.presentadores.Enumeradores;
import com.duxstar.dacza.presentadores.Enumeradores.RespuestaMsg;
import com.duxstar.dacza.presentadores.act.CapturarArticuloOrden;
import com.duxstar.dacza.presentadores.interfaces.ICapturaArticuloOrden;
import com.duxstar.dacza.utilerias.ControlError;
import com.duxstar.dacza.utilerias.Generales;
import com.duxstar.dacza.vistas.generico.ODTDetalleAdapter;


public class CapturaArticuloOrden extends Vista implements ICapturaArticuloOrden
{
	CapturarArticuloOrden mPresenta;
	String mAccion;
	HashMap<String, String> oParametros = null;
	CapturaArticulo captura;
	ListView lista;
	boolean huboCambios = false;
	//boolean esNuevo = true;
	boolean soloLectura = false;
	Button btnContinuar;
    Button btnCerrar;
    Button btnObservacion;
    String ordenId;
	/*
	 * Variables para manejar el porcentaje permitido para cambios de caducidad. 
	 * */

	ODTDetalle detalleEliminar;

	@SuppressWarnings(
	{ "unchecked", "deprecation" })
	@Override
	public void onCreate(Bundle savedInstanceState)
	{
		try
		{
			super.onCreate(savedInstanceState);
			mAccion = getIntent().getAction();
			setContentView(R.layout.captura_articulo_orden);
			deshabilitarBarra(true);
			setTitulo("Orden de Trabajo");

            btnObservacion = (Button) findViewById(R.id.btnObservacion);
            btnObservacion.setText("Observaciones");
            btnObservacion.setOnClickListener(mCapturarObservacion);

            btnCerrar = (Button) findViewById(R.id.btnCerrar);
            btnCerrar.setText("Cerrar");
            btnCerrar.setOnClickListener(mCerrar);

			btnContinuar = (Button) findViewById(R.id.btnContinuar);
			btnContinuar.setText("Continuar");
			btnContinuar.setOnClickListener(mContinuar);

			lista = (ListView) findViewById(R.id.lstDetalle);
            lista.setClickable(true);
            registerForContextMenu(lista);

			captura = (CapturaArticulo) findViewById(R.id.capturaArticulo);
			captura.setOnAgregarArticuloListener(new CapturaArticulo.onAgregarArticuloListener()
			{
				@Override
				public void onAgregarArticulo(Articulo articulo, float cantidad)
				{
					try
					{
                        ODTDetalle detalle = mPresenta.existe(articulo);
						if (detalle != null)
						{ //si ya existe
							if (detalle.Cantidad != cantidad)
							{
								StringBuilder error = new StringBuilder();
								//actualizar la cantidad
								if (mPresenta.actualizarCantidad(detalle, cantidad, error))
								{
									captura.setAdvertencia("");
								}
								else
								{
									captura.setError(error.toString());
								}
							}
						}
						else
						{
							//si no existe agregarlo con el ultimo motivo seleccionado
							StringBuilder error = new StringBuilder();
							if (mPresenta.agregarArticulo(articulo, cantidad, error))
							{
								captura.setAdvertencia("");
							}
							else
							{
								captura.setError(error.toString());
							}
						}
						btnContinuar.setEnabled(true);
                        btnCerrar.setEnabled(true);
					}
					catch (Exception e)
					{
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

			mPresenta = new CapturarArticuloOrden(this, mAccion);

			if (getIntent().getSerializableExtra("parametros") != null)
			{
				oParametros = (HashMap<String, String>) getIntent().getSerializableExtra("parametros");
			}

			if (oParametros != null && (oParametros.get("Eliminar") != null))
			{
				soloLectura = Boolean.parseBoolean(oParametros.get("Eliminar").toString());
			}

			//si se paso como parametro el TransProdId, cargar el detalle
			if (oParametros != null && (oParametros.get("OrdenId") != null))
			{
				huboCambios = false;
                ordenId = oParametros.get("OrdenId");
                Sesion.set(Campo.OrdenTrabajoActual, ordenId);
				mPresenta.recuperarDetalle(ordenId);
				refrescarProductos(ordenId);
			}

			if (soloLectura) {
                //btnObservacion.setEnabled(false);
                btnContinuar.setEnabled(false);
                btnCerrar.setEnabled(false);
                captura.setVisibility(View.GONE);
            }

			mPresenta.iniciar();
            //captura.setFocus();

		}
		catch (Exception ex)
		{
			mostrarError(ex.getMessage().equals("") ? ex.getCause().getMessage() : ex.getMessage());
		}

		final EditText txtScaner = (EditText) findViewById(R.id.txtScanner);
		final EditText txtCantidad = (EditText) findViewById(R.id.txtCantidad);

	    final InputMethodManager imm = (InputMethodManager) getSystemService(Context.INPUT_METHOD_SERVICE);

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
					// getWindow().setSoftInputMode(WindowManager.LayoutParams.SOFT_INPUT_STATE_VISIBLE);
					txtCantidad.clearFocus();
				}
			}
		});

	}

	@Override
	public void iniciar()
	{
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
            if (enviar) {
                setResultado(Enumeradores.Resultados.RESULTADO_ENVIAR);
                Sesion.set(Campo.IdDocumentoEnviar, mPresenta.getOrdenTrabajo().OrdenId);
            }
            else
			    setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
			finalizar();
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
					mPresenta.insertarSeleccion((HashMap<String, ODTDetalle>) Sesion.get(Campo.ResultadoActividad));
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
        else if (requestCode == Enumeradores.Solicitudes.SOLICITUD_CAPTURA_OBSERVACIONES){
            if (resultCode == Enumeradores.Resultados.RESULTADO_BIEN){
                mPresenta.actualizaObservaciones(Sesion.get(Campo.Observaciones).toString());
                huboCambios = true;
            }
        }
	}

   	@Override
	public void respuestaMensaje(RespuestaMsg respuesta, int tipoMensaje)
	{
        if (tipoMensaje == 2) //cerrar orden
        {
            if (respuesta == RespuestaMsg.Si) {
                try {
                    if (mPresenta.getOrdenTrabajo().ODTDetalle.size() <= 0)
                        throw new ControlError("Se debe asignar por lo menos un producto a la orden de trabajo");

                    mPresenta.actualizarOrdenTrabajo(true);
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
				refrescarProductos(ordenId);
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
		detalleEliminar = (ODTDetalle) lista.getItemAtPosition(info.position);
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
                    if (mPresenta.getOrdenTrabajo().ODTDetalle.size() <= 0)
                        throw new ControlError("Se debe asignar por lo menos un producto a la orden de trabajo");

                    mPresenta.actualizarOrdenTrabajo(false);
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
                mostrarPreguntaSiNo("¿Desea cerrar la orden de trabajo?", 2);
            }
            catch (Exception e)
            {
                mostrarError(e.getMessage());
            }
        }
    };

    private OnClickListener mCapturarObservacion = new OnClickListener()
    {

        @Override
        public void onClick(View v)
        {
            try
            {
                Observaciones.capturarObservaciones(CapturaArticuloOrden.this, mPresenta.getOrdenTrabajo().Folio, mPresenta.getOrdenTrabajo().Observacion, soloLectura);

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

            if (mPresenta.getOrdenTrabajo().ODTDetalle.size() > 0)
            {
                Collections.sort(mPresenta.getOrdenTrabajo().ODTDetalle, new ODTDetalle.comparator());
                ODTDetalleAdapter adapter = new ODTDetalleAdapter(this, R.layout.elemento_articulo_orden, mPresenta.getOrdenTrabajo().ODTDetalle.toArray(new ODTDetalle[mPresenta.getOrdenTrabajo().ODTDetalle.size()]));
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
