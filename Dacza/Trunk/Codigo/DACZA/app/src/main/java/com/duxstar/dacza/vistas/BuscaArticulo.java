package com.duxstar.dacza.vistas;

import java.util.HashMap;
import java.util.concurrent.atomic.AtomicReference;

import android.annotation.SuppressLint;
import android.app.Fragment;
import android.content.Context;
import android.content.Intent;
import android.database.Cursor;
import android.os.Bundle;
import android.text.InputType;
import android.view.ContextMenu;
import android.view.ContextMenu.ContextMenuInfo;
import android.view.KeyEvent;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.MotionEvent;
import android.view.View;
import android.view.View.OnKeyListener;
import android.view.ViewGroup;
import android.widget.AdapterView.AdapterContextMenuInfo;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ListView;
import android.widget.SimpleCursorAdapter;
import android.widget.SimpleCursorAdapter.ViewBinder;
import android.widget.TextView;

import com.duxstar.dacza.R;
import com.duxstar.dacza.actividades.Devoluciones;
import com.duxstar.dacza.actividades.Inventario;
import com.duxstar.dacza.actividades.OrdenesTrabajo;
import com.duxstar.dacza.actividades.Recargas;
import com.duxstar.dacza.datos.DEVDetalle;
import com.duxstar.dacza.datos.ODTDetalle;
import com.duxstar.dacza.datos.RECDetalle;
import com.duxstar.dacza.datos.basedatos.Consultas;
import com.duxstar.dacza.datos.generales.ISetDatos;
import com.duxstar.dacza.datos.utilerias.Sesion;
import com.duxstar.dacza.datos.utilerias.Sesion.Campo;
import com.duxstar.dacza.presentadores.Enumeradores;
import com.duxstar.dacza.presentadores.Enumeradores.RespuestaMsg;
import com.duxstar.dacza.presentadores.act.BuscarArticulo;
import com.duxstar.dacza.presentadores.interfaces.IBuscaArticulo;
//import com.amesol.routelite.presentadores.interfaces.ISeleccionEsquemaProducto;
import com.duxstar.dacza.utilerias.ControlError;
import com.duxstar.dacza.utilerias.Generales;

public class BuscaArticulo extends Vista implements IBuscaArticulo
{

	private BuscarArticulo mPresenta;
	private String mAccion;
	private ListView listArticulos;
	private String filtro = "";
	private boolean errorDeCaptura = false;
	private int posicionError = -1;
	private Cursor articulos;
	private boolean cargando;
	private String movimientoId;
    //private String recargaId;

    private boolean bValidarExistencia = false;
    //private boolean bOrden = false;
    private int tipoMovimiento;


	private int selectedItem = 0;
	private EditText etCant;

	@SuppressLint("UseSparseArrays")
	private HashMap<Integer, EditText> eCantidades = new HashMap<Integer, EditText>();

	private HashMap<String, ODTDetalle> seleccionDetOrden = new HashMap<String, ODTDetalle>();
    private HashMap<String, RECDetalle> seleccionDetRecarga = new HashMap<String, RECDetalle>();
    private HashMap<String, DEVDetalle> seleccionDetDevolucion = new HashMap<String, DEVDetalle>();
	private boolean bEsVisible = false;
    private boolean bMostrandoError = false;

	@SuppressWarnings("unchecked")
	@Override
	public void onCreate(Bundle savedInstanceState)
	{
		try
		{
			super.onCreate(savedInstanceState);
			mAccion = getIntent().getAction();

			setContentView(R.layout.buscar_articulo);
			deshabilitarBarra(true);
			lblTitle.setText("Buscar Artículo");

			HashMap<String, Object> oParametros = null;
			if (getIntent().getSerializableExtra("parametros") != null)
			{
				oParametros = (HashMap<String, Object>) getIntent().getSerializableExtra("parametros");
			}

			Button btn = (Button) findViewById(R.id.btnAgregar);
			btn.setText("Agregar");
			btn.setOnClickListener(mAgregar);

			TextView texto = (TextView) findViewById(R.id.lblArticulo);
			texto.setText("Producto");

            texto = (TextView) findViewById(R.id.lblExist);
            texto.setText("E");

            texto = (TextView) findViewById(R.id.lblCant);
            texto.setText("C");

			cargando = true;

			EditText edit = (EditText) findViewById(R.id.txtArticulo);
			edit.setOnKeyListener(mFiltrarArticulo);
			edit.setSelectAllOnFocus(true);
			edit.setSingleLine(true);
			edit.setFocusable(true);
			/*
			 * edit.setOnFocusChangeListener(mFoco);
			 * edit.setOnTouchListener(mTouch);
			 */
			//edit.setOnFocusChangeListener(mFoco);
			//edit.addTextChangedListener(mFiltroProducto);
			if (oParametros != null) {
                if (oParametros.get("OrdenId") != null)
                {
                    movimientoId = oParametros.get("OrdenId").toString();
                    tipoMovimiento = Enumeradores.TiposMovimientos.ORDEN_TRABAJO;
                    bValidarExistencia = true;
                }
                else if (oParametros.get("RecargaId") != null) {
                    movimientoId = oParametros.get("RecargaId").toString();
                    tipoMovimiento = Enumeradores.TiposMovimientos.RECARGA_INVENTARIO;
                }
                else if (oParametros.get("DevolucionId") != null) {
                    movimientoId = oParametros.get("DevolucionId").toString();
                    tipoMovimiento = Enumeradores.TiposMovimientos.DEVOLUCION_INVENTARIO;
                    bValidarExistencia = true;
                }
			}

			if (oParametros != null && (!oParametros.get("Cadena").toString().trim().equals("")))
			{
				edit.setText(oParametros.get("Cadena").toString());
				edit.selectAll();
				//mandar un 'Enter' para que haga la busqueda
				edit.dispatchKeyEvent(new KeyEvent(KeyEvent.ACTION_UP, KeyEvent.KEYCODE_ENTER));
			}

            if(tipoMovimiento == Enumeradores.TiposMovimientos.ORDEN_TRABAJO)
                articulos = Consultas.ConsultasArticulo.obtenerArticulosParaOrden(filtro, movimientoId);
            else if (tipoMovimiento == Enumeradores.TiposMovimientos.RECARGA_INVENTARIO)
                articulos = Consultas.ConsultasArticulo.obtenerArticulosParaRecarga(filtro, movimientoId);
            else if (tipoMovimiento == Enumeradores.TiposMovimientos.DEVOLUCION_INVENTARIO)
                articulos = Consultas.ConsultasArticulo.obtenerArticulosParaDevolucion(filtro, movimientoId);

            if (articulos == null)
            {
                this.setResultado(Enumeradores.Resultados.RESULTADO_MAL, "No existen coincidencias de artículo o ya se encuentran todos capturados.");
                finalizar();
            }

            listArticulos = (ListView) findViewById(R.id.lstArticulos);
            listArticulos.setDescendantFocusability(ViewGroup.FOCUS_BEFORE_DESCENDANTS);
            listArticulos.setChoiceMode(1);
            listArticulos.setItemsCanFocus(true);
            listArticulos.setClickable(false);

			cargando = false;
			mPresenta = new BuscarArticulo(this, mAccion);
			mPresenta.iniciar();
		}
		catch (ControlError e)
		{
			mostrarError(e.getMessage());
			finalizar();
		}
		catch (Exception ex)
		{
			mostrarError(ex.getMessage().equals("") ? ex.getCause().getMessage() : ex.getMessage());
		}
	}

	  @Override
	    public void onDestroy() {
	        super.onDestroy();
			if (articulos != null && !articulos.isClosed()) {
                articulos.close();
			}
	    }
	  
	@Override
	public void onWindowFocusChanged(boolean hasFocus)
	{

		super.onWindowFocusChanged(hasFocus);

		if (hasFocus)
			if (!bEsVisible)
			{
                listArticulos.requestFocusFromTouch();
                listArticulos.setSelection(0);
				eCantidades.get(0).requestFocus();
				bEsVisible = true;
			}
	}

	private OnKeyListener mFiltrarArticulo = new OnKeyListener()
	{
		@Override
		public boolean onKey(View v, int keyCode, KeyEvent event)
		{
			if (event.getAction() == KeyEvent.ACTION_UP)
			{
				if (keyCode == KeyEvent.KEYCODE_ENTER)
				{
					try
					{
						String texto = ((TextView) v).getText().toString().trim();
						if (!texto.equals(""))
							filtro = texto; //" (PRO.Id LIKE '%" + texto + "%' or PRO.ProductoClave LIKE '%" + texto + "%' or PRO.Nombre LIKE '%" + texto + "%' or PRO.NombreLargo LIKE '%" + texto + "%')";
						else
							filtro = "";
                        if (tipoMovimiento == Enumeradores.TiposMovimientos.ORDEN_TRABAJO)
						    seleccionDetOrden.clear();
                        else if (tipoMovimiento == Enumeradores.TiposMovimientos.RECARGA_INVENTARIO)
                            seleccionDetRecarga.clear();
                        else if (tipoMovimiento == Enumeradores.TiposMovimientos.DEVOLUCION_INVENTARIO)
                            seleccionDetDevolucion.clear();
						if (!cargando)
						{
							if (articulos != null)
                                articulos.close();

                            if (tipoMovimiento == Enumeradores.TiposMovimientos.ORDEN_TRABAJO)
                                articulos = Consultas.ConsultasArticulo.obtenerArticulosParaOrden(filtro, movimientoId);
                            else if (tipoMovimiento == Enumeradores.TiposMovimientos.RECARGA_INVENTARIO)
                                articulos = Consultas.ConsultasArticulo.obtenerArticulosParaRecarga(filtro, movimientoId);
                            else if (tipoMovimiento == Enumeradores.TiposMovimientos.DEVOLUCION_INVENTARIO)
                                articulos = Consultas.ConsultasArticulo.obtenerArticulosParaDevolucion(filtro, movimientoId);
							mostrarArticulos(articulos);
						}
						return true;
					}
					catch (Exception e)
					{
						mostrarError(e.getMessage().equals("") ? e.getCause().getMessage() : e.getMessage());
					}
				}
			}
			return false;
		}
	};

	public Cursor obtenerArticulos()
	{
		return articulos;
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
		if (respuesta.equals(Enumeradores.RespuestaMsg.OK) && errorDeCaptura)
		{
			errorDeCaptura = false;
			//listProductos.setFocusableInTouchMode(true);
			if (posicionError >= 0)
			{
                listArticulos.setSelection(posicionError);
				eCantidades.get(posicionError).requestFocus();
			}
		}else if(tipoMensaje == 30){
			//cantidad maxima de producto
			if(respuesta == RespuestaMsg.Si){
                if (tipoMovimiento == Enumeradores.TiposMovimientos.ORDEN_TRABAJO)
				    aceptarCantidadOrden(etCant);
                else if (tipoMovimiento == Enumeradores.TiposMovimientos.RECARGA_INVENTARIO)
                    aceptarCantidadRecarga(etCant);
                else if (tipoMovimiento == Enumeradores.TiposMovimientos.DEVOLUCION_INVENTARIO)
                    aceptarCantidadDevolucion(etCant);
			}else if(respuesta == RespuestaMsg.No){
				//regresar el focus al producto
				int index = listArticulos.getPositionForView(etCant);
				if (eCantidades.containsKey(index))
				{
					eCantidades.get(index).requestFocus();
				}
			}
		}else if (tipoMensaje == 50 && bMostrandoError){
            if (posicionError >= 0)
            {
                listArticulos.requestFocusFromTouch();
                listArticulos.setSelection(posicionError);
                eCantidades.get(posicionError).requestFocus();

            }
            bMostrandoError = false;
        }
	}

	@SuppressWarnings("deprecation")
	public void mostrarArticulos(Cursor articulos)
	{
		//seleccion.clear(); //limpiar el hashmap cuando cambie el contenido de la lista
		//Handler handler = new Handler();
		this.articulos = articulos;
		//final ListView lista = (ListView) findViewById(R.id.lstProductos);

		if (articulos == null)
		{ //da problemas cuando el cursor es null, por eso solo se oculta la lista para no mostrar ningun resultado
            listArticulos.setVisibility(View.INVISIBLE);
			return;
		}
		else
		{
            listArticulos.setVisibility(View.VISIBLE);
		}

		startManagingCursor(articulos);
		try
		{
			final MySimpleCursorAdapter adapter = new MySimpleCursorAdapter(this, R.layout.lista_busqueda_articulo, articulos,
					new String[]
					{ "Grupo", "ArticuloId", "Clave", "Descripcion", "Existencia", "Cantidad" },
					new int[]
					{ R.id.txtGrupo, R.id.txtArticuloId, R.id.txtClave, R.id.txtDescripcion, R.id.txtExistencia, R.id.npCantidad });
			adapter.setViewBinder(new vista());

			listArticulos.setAdapter(adapter);

			eCantidades.clear();
            listArticulos.requestFocusFromTouch();
            listArticulos.setSelection(0);
		}
		catch (Exception e)
		{
			mostrarError(e.getMessage());
		}
	}

	private android.view.View.OnClickListener mAgregar = new android.view.View.OnClickListener()
	{
		@Override
		public void onClick(View v)
		{

			//final ListView lista = (ListView) findViewById(R.id.lstProductos);
            listArticulos.clearFocus();
			if (errorDeCaptura)
				return;
			if (listArticulos.getVisibility() == View.VISIBLE)
			{
                if (tipoMovimiento == Enumeradores.TiposMovimientos.ORDEN_TRABAJO)
				    Sesion.set(Campo.ResultadoActividad, seleccionDetOrden);
                else if (tipoMovimiento == Enumeradores.TiposMovimientos.RECARGA_INVENTARIO)
                    Sesion.set(Campo.ResultadoActividad, seleccionDetRecarga);
                else if (tipoMovimiento == Enumeradores.TiposMovimientos.DEVOLUCION_INVENTARIO)
                    Sesion.set(Campo.ResultadoActividad, seleccionDetDevolucion);

				setResultado(Enumeradores.Resultados.RESULTADO_BIEN, null);
			}

			finalizar();
		}
	};

	//	private android.view.View.OnClickListener mBuscarEsquemas = new android.view.View.OnClickListener()
	//	{
	//		@Override
	//		public void onClick(View v)
	//		{
	//			mostrarBusquedaEsquemas();
	//		}
	//	};

	private class MySimpleCursorAdapter extends SimpleCursorAdapter
	{
		Cursor c;
		
		@SuppressWarnings("deprecation")
		public MySimpleCursorAdapter(Context context, int layout, Cursor c, String[] from, int[] to)
		{
			super(context, layout, c, from, to);
			this.c = c;
		}

		@Override
		public View getView(final int pos, View v, ViewGroup parent)
		{
			v = super.getView(pos, v, parent);
			final EditText et = (EditText) v.findViewById(R.id.npCantidad);

			Cursor c = ((SimpleCursorAdapter) ((ListView) parent).getAdapter()).getCursor();
			String clave = (((TextView) v.findViewById(R.id.txtArticuloId)).getText().toString() + "|" +  ((TextView) v.findViewById(R.id.txtExistencia)).getText().toString() + "|" + pos);
			et.setTag(clave);
			et.setFocusable(true);
			et.setSelectAllOnFocus(true);
			et.setClickable(false);
			et.setFocusableInTouchMode(true);
			/*if (c.getInt(c.getColumnIndex("DecimalProducto")) == 0){
				et.setInputType(InputType.TYPE_CLASS_NUMBER);	
			}else{*/
				et.setInputType(InputType.TYPE_NUMBER_FLAG_DECIMAL|InputType.TYPE_CLASS_NUMBER);
			//}
			
			if (!eCantidades.containsKey(pos))
			{
				eCantidades.put(pos, et);
			}
			v.setLongClickable(true);
			v.setOnLongClickListener(new View.OnLongClickListener()
			{
				
				@Override
				public boolean onLongClick(View v)
				{
					selectedItem = pos;
					openContextMenu(listArticulos);
					return false;
				}
			});

			et.setOnKeyListener(new EditText.OnKeyListener()
			{
				@Override
				public boolean onKey(View v, int keyCode, KeyEvent event)
				{
					if (event.getAction() != KeyEvent.ACTION_UP)
						return true;

					switch (keyCode)
					{
						case KeyEvent.KEYCODE_ENTER:
							if (v.getParent().getParent().getParent().getParent() != null)
							{
								int index = listArticulos.getPositionForView(v) + 1;

								if (eCantidades.containsKey(index))
								{
									eCantidades.get(index).requestFocus();
								}
							}
							return false;
						case KeyEvent.KEYCODE_BACK:
							finalizar();
							return true;
					}
					return v.onKeyDown(keyCode, event);
				}
			});

			et.setOnFocusChangeListener(new View.OnFocusChangeListener()
			{
				@Override
				public void onFocusChange(View v, boolean hasFocus)
				{
					if (!hasFocus)
					{
						EditText et = (EditText) v;
						
						if (et.getText().toString().equals("")){
							et.setText("0");
						}
                        if (bMostrandoError) return;
                        if (cargando) return;

                        etCant = et;

                        if (tipoMovimiento == Enumeradores.TiposMovimientos.ORDEN_TRABAJO)
                            aceptarCantidadOrden(etCant);
                        else if (tipoMovimiento == Enumeradores.TiposMovimientos.RECARGA_INVENTARIO)
                            aceptarCantidadRecarga(etCant);
                        else if (tipoMovimiento == Enumeradores.TiposMovimientos.DEVOLUCION_INVENTARIO)
                            aceptarCantidadDevolucion(etCant);
					}
					else
					{
						EditText et = (EditText) v;
						et.selectAll();
					}

				}
			});

			et.setOnTouchListener(new View.OnTouchListener()
			{

				@Override
				public boolean onTouch(View v, MotionEvent event)
				{
					v.onTouchEvent(event);
					((EditText) v).selectAll();
					return true;
				}
			});
			return v;
		}

	}
	
	private void aceptarCantidadOrden(EditText et){
		//Estructura del tag ArticuloId|Existencia|pos
		String[] llave = et.getTag().toString().split("\\|");
		String articuloId = llave[0];
		AtomicReference<Float> existencia = new AtomicReference<Float>();
		existencia.set(Float.parseFloat(llave[1]));
		//Se agrego la posicion porque la funcion getPositionForView
		int pos = Integer.parseInt(llave[2]);
		StringBuilder error = new StringBuilder();
		try
		{
			if (seleccionDetOrden.containsKey(articuloId))
			{
				if ((seleccionDetOrden.get(articuloId)).Cantidad != Float.parseFloat(et.getText().toString()))
				{
					if (Float.parseFloat(et.getText().toString()) <= 0)
					{
                        seleccionDetOrden.remove(articuloId);
						et.setText(Generales.getFormatoDecimal(0, 2));
					}
					else
					{
                        if (bValidarExistencia) {
                            if (!Inventario.ValidarExistencia(articuloId, Float.parseFloat(et.getText().toString()), existencia, error)) {
                                errorDeCaptura = true;
                                posicionError = pos;
                                mostrarError(error.toString());
                                seleccionDetOrden.get(articuloId).Cantidad = Generales.getRound(existencia.get(), 2);
                                et.setText(Generales.getFormatoDecimal(existencia.get(), 2));
                                return;
                            }
                        }

                        seleccionDetOrden.get(articuloId).Cantidad = Generales.getRound(Float.parseFloat(et.getText().toString()), 2);
                        et.setText(Generales.getFormatoDecimal(seleccionDetOrden.get(articuloId).Cantidad, 2));
					}
				}
			}
			else if (et.getText().toString().length() > 0 && Float.parseFloat(et.getText().toString()) > 0)
			{
				//Dar de alta
                if (bValidarExistencia) {
                    if (!Inventario.ValidarExistencia(articuloId, Float.parseFloat(et.getText().toString()), existencia, error)) {
                        errorDeCaptura = true;
                        posicionError = pos;
                        mostrarError(error.toString());
                        et.setText(Generales.getFormatoDecimal(existencia.get(), 2));
                        return;
                    }
                }

                //aqui voy
                seleccionDetOrden.put(articuloId, OrdenesTrabajo.GenerarDetalleBusqueda(articuloId, Generales.getRound(Float.parseFloat(et.getText().toString()),2 )));
                et.setText(Generales.getFormatoDecimal(seleccionDetOrden.get(articuloId).Cantidad, 2));
			}
			else if (et.getText().toString().length() <= 0)
			{
				et.setText(Generales.getFormatoDecimal(0, 2));
			}

		}
		catch (Exception ex)
		{
			mostrarError(ex.getMessage());
		}
	}

    private void aceptarCantidadRecarga(EditText et){
        //Estructura del tag ArticuloId|Existencia|pos
        String[] llave = et.getTag().toString().split("\\|");
        String articuloId = llave[0];
        AtomicReference<Float> existencia = new AtomicReference<Float>();
        existencia.set(Float.parseFloat(llave[1]));
        //Se agrego la posicion porque la funcion getPositionForView
        int pos = Integer.parseInt(llave[2]);
        StringBuilder error = new StringBuilder();
        try
        {
            if (seleccionDetRecarga.containsKey(articuloId))
            {
                if ((seleccionDetRecarga.get(articuloId)).Cantidad != Float.parseFloat(et.getText().toString()))
                {
                    if (Float.parseFloat(et.getText().toString()) <= 0)
                    {
                        seleccionDetRecarga.remove(articuloId);
                        et.setText(Generales.getFormatoDecimal(0, 2));
                    }
                    else
                    {
                        seleccionDetRecarga.get(articuloId).Cantidad = Generales.getRound(Float.parseFloat(et.getText().toString()), 2);
                        et.setText(Generales.getFormatoDecimal(seleccionDetRecarga.get(articuloId).Cantidad, 2));
                    }
                }
            }
            else if (et.getText().toString().length() > 0 && Float.parseFloat(et.getText().toString()) > 0)
            {
                seleccionDetRecarga.put(articuloId, Recargas.GenerarDetalleBusqueda(articuloId, Generales.getRound(Float.parseFloat(et.getText().toString()), 2)));
                et.setText(Generales.getFormatoDecimal(seleccionDetRecarga.get(articuloId).Cantidad, 2));
            }
            else if (et.getText().toString().length() <= 0)
            {
                et.setText(Generales.getFormatoDecimal(0, 2));
            }

        }
        catch (Exception ex)
        {
            mostrarError(ex.getMessage());
        }
    }

    private void aceptarCantidadDevolucion(EditText et){
        //Estructura del tag ArticuloId|Existencia|pos
        String[] llave = et.getTag().toString().split("\\|");
        String articuloId = llave[0];
        AtomicReference<Float> existencia = new AtomicReference<Float>();
        existencia.set(Float.parseFloat(llave[1]));
        //Se agrego la posicion porque la funcion getPositionForView
        int pos = Integer.parseInt(llave[2]);
        StringBuilder error = new StringBuilder();
        try
        {
            if (seleccionDetDevolucion.containsKey(articuloId))
            {
                if ((seleccionDetDevolucion.get(articuloId)).Cantidad != Float.parseFloat(et.getText().toString()))
                {
                    if (Float.parseFloat(et.getText().toString()) <= 0)
                    {
                        seleccionDetDevolucion.remove(articuloId);
                        et.setText(Generales.getFormatoDecimal(0, 2));
                    }
                    else
                    {
                        if (bValidarExistencia) {
                            if (!Inventario.ValidarExistencia(articuloId, Float.parseFloat(et.getText().toString()), existencia, error)) {
                                errorDeCaptura = true;
                                posicionError = pos;
                                mostrarError(error.toString());
                                seleccionDetDevolucion.get(articuloId).Cantidad = Generales.getRound(existencia.get(), 2);
                                et.setText(Generales.getFormatoDecimal(existencia.get(), 2));
                                return;
                            }
                        }

                        seleccionDetDevolucion.get(articuloId).Cantidad = Generales.getRound(Float.parseFloat(et.getText().toString()), 2);
                        et.setText(Generales.getFormatoDecimal(seleccionDetDevolucion.get(articuloId).Cantidad, 2));
                    }
                }
            }
            else if (et.getText().toString().length() > 0 && Float.parseFloat(et.getText().toString()) > 0)
            {
                //Dar de alta
                if (bValidarExistencia) {
                    if (!Inventario.ValidarExistencia(articuloId, Float.parseFloat(et.getText().toString()), existencia, error)) {
                        errorDeCaptura = true;
                        posicionError = pos;
                        mostrarError(error.toString());
                        et.setText(Generales.getFormatoDecimal(existencia.get(), 2));
                        return;
                    }
                }

                seleccionDetDevolucion.put(articuloId, Devoluciones.GenerarDetalleBusqueda(articuloId, Generales.getRound(Float.parseFloat(et.getText().toString()), 2)));
                et.setText(Generales.getFormatoDecimal(seleccionDetDevolucion.get(articuloId).Cantidad, 2));
            }
            else if (et.getText().toString().length() <= 0)
            {
                et.setText(Generales.getFormatoDecimal(0, 2));
            }

        }
        catch (Exception ex)
        {
            mostrarError(ex.getMessage());
        }
    }

	private class vista implements ViewBinder
	{

		@Override
		public boolean setViewValue(View view, Cursor cursor, int columnIndex)
		{
			int viewId = view.getId();

			switch (viewId)
			{

				case R.id.txtExistencia:
					TextView existencia = (TextView) view;
					existencia.setText(Generales.getFormatoDecimal(cursor.getFloat(columnIndex), 2));
					break;

				default:
					if (viewId != R.id.npCantidad)
					{
						TextView texto = (TextView) view;
						if (!texto.getText().equals(cursor.getString(columnIndex)))
						{
							texto.setText(cursor.getString(columnIndex));
						}
					}
					else
					{
						EditText texto = (EditText) view;
						view.clearFocus();

						if (!Generales.isNumeric(texto.getText().toString()))
						{
							texto.setText(Generales.getFormatoDecimal(0, 2));
						}
						try
						{
                            if (tipoMovimiento == Enumeradores.TiposMovimientos.ORDEN_TRABAJO) {
                                if (seleccionDetOrden.containsKey(cursor.getString(cursor.getColumnIndex("ArticuloId")))) {
                                    if (seleccionDetOrden.get(cursor.getString(cursor.getColumnIndex("ArticuloId"))).Cantidad != Float.parseFloat(texto.getText().toString())) {
                                        texto.setText(Generales.getFormatoDecimal(seleccionDetOrden.get(cursor.getString(cursor.getColumnIndex("ArticuloId"))).Cantidad, 2));
                                    }
                                } else {
                                    texto.setText(Generales.getFormatoDecimal(0, 2));
                                }
                            }else if (tipoMovimiento == Enumeradores.TiposMovimientos.RECARGA_INVENTARIO){
                                if (seleccionDetRecarga.containsKey(cursor.getString(cursor.getColumnIndex("ArticuloId")))) {
                                    if (seleccionDetRecarga.get(cursor.getString(cursor.getColumnIndex("ArticuloId"))).Cantidad != Float.parseFloat(texto.getText().toString())) {
                                        texto.setText(Generales.getFormatoDecimal(seleccionDetRecarga.get(cursor.getString(cursor.getColumnIndex("ArticuloId"))).Cantidad, 2));
                                    }
                                } else {
                                    texto.setText(Generales.getFormatoDecimal(0, 2));
                                }
                            }else if (tipoMovimiento == Enumeradores.TiposMovimientos.DEVOLUCION_INVENTARIO){
                                if (seleccionDetDevolucion.containsKey(cursor.getString(cursor.getColumnIndex("ArticuloId")))) {
                                    if (seleccionDetDevolucion.get(cursor.getString(cursor.getColumnIndex("ArticuloId"))).Cantidad != Float.parseFloat(texto.getText().toString())) {
                                        texto.setText(Generales.getFormatoDecimal(seleccionDetDevolucion.get(cursor.getString(cursor.getColumnIndex("ArticuloId"))).Cantidad, 2));
                                    }
                                } else {
                                    texto.setText(Generales.getFormatoDecimal(0, 2));
                                }
                            }
						}
						catch (Exception ex)
						{
							mostrarError(ex.getMessage());
						}
					}

					break;
			}

			return true;
		}
	}
	
}

