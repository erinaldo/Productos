package com.duxstar.dacza.controles;

import java.util.HashMap;

import android.app.Activity;
import android.content.Context;
import android.content.Intent;
import android.support.v4.app.FragmentActivity;
import android.text.InputType;
import android.util.AttributeSet;
import android.util.Log;
import android.view.KeyEvent;
import android.view.LayoutInflater;
import android.view.View;
import android.view.WindowManager;
import android.widget.CheckBox;
import android.widget.EditText;
import android.widget.ImageButton;
import android.widget.LinearLayout;
import android.widget.TextView;

import com.duxstar.dacza.R;
import com.duxstar.dacza.controles.TextBoxScanner.OnCodigoIngresadoListener;
import com.duxstar.dacza.controles.TextBoxScanner.OnTextChangedListener;
import com.duxstar.dacza.datos.Articulo;
import com.duxstar.dacza.datos.basedatos.Consultas;
import com.duxstar.dacza.datos.utilerias.Sesion;
import com.duxstar.dacza.datos.utilerias.Sesion.Campo;
import com.duxstar.dacza.presentadores.Enumeradores;
import com.duxstar.dacza.presentadores.interfaces.IBuscaArticulo;
import com.duxstar.dacza.utilerias.Generales;
import com.duxstar.dacza.vistas.Vista;

public class CapturaArticuloDesc extends LinearLayout {

    // controles
    CheckBox chkClave;
    TextBoxScanner txtScanner;
    ImageButton btnBuscar;
    EditText txtCantidad;
    ImageButton btnAgregar;
    TextView lblArtDescripcion;
    TextView lblArtExistencia;
    LinearLayout layArticulo;

    // variables
    Articulo oArticulo = null;
    Vista mVista = null;
	Context context;

	boolean bClaveManual = false;
	boolean bMostrandoBusqueda = false;
	boolean bAdvertencia = false;
    boolean bDescripcion = false;
    boolean bCapturaImagen = false;
	String error = "";

	public CapturaArticuloDesc(Context context, AttributeSet attrs)
	{
		super(context, attrs);
		inicializar();
	}

	public CapturaArticuloDesc(Context context)
	{
		super(context);
		inicializar();
	}

	// ***************************************************************************************************************

	// ****************************************** funciones generales
	// ************************************************
	private void inicializar()
	{
		// Utilizamos el layout como interfaz del control
		String infService = Context.LAYOUT_INFLATER_SERVICE;
		LayoutInflater li = (LayoutInflater) getContext().getSystemService(infService);
		li.inflate(R.layout.captura_articulo_desc, this, true);
        bCapturaImagen = false;

		if (this.isInEditMode()) // para que no truene cuando se agrega al
									// layout en vista de diseño
			return;

		// Obtenemos las referencias a los distintos controles
        TextView texto =  (TextView) findViewById(R.id.lblCantidad);
        texto.setText("Cantidad");

        layArticulo = (LinearLayout) findViewById(R.id.layArticulo);

        chkClave = (CheckBox) findViewById(R.id.chkClave);
        chkClave.setText("Clave");
        chkClave.setOnClickListener(new OnClickListener() {
            @Override
            public void onClick(View v) {
                   habilitarScaner(((CheckBox) v).isChecked());
            }
        });

		txtScanner = (TextBoxScanner) findViewById(R.id.textBoxScanner);
		txtScanner.setOnCodigoIngresado(mCodigoBarras);
        txtScanner.tipoCodigo = Enumeradores.TIPOCODIGO.ARTICULO;
		txtScanner.setOnTextChanged(new OnTextChangedListener()
		{
			@Override
			public void OnTextChanged(CharSequence s)
			{
				if (bClaveManual)
					return;
				txtCantidad.setText("");
                if (!bCapturaImagen)
				    lblArtDescripcion.setText("");
				lblArtExistencia.setText("");

				oArticulo = null;
			}
		});

		btnBuscar = (ImageButton) findViewById(R.id.btnBuscarArticulo);
		btnBuscar.setOnClickListener(mBuscarArticulo);

		txtCantidad = (EditText) findViewById(R.id.txtCantidad);
		txtCantidad.selectAll();
		txtCantidad.setSelectAllOnFocus(true);

		lblArtDescripcion = (TextView) findViewById(R.id.lblArtDescripcion);
		lblArtExistencia = (TextView) findViewById(R.id.lblArtExistencia);

		txtCantidad.setOnKeyListener(new OnKeyListener()
		{

			@Override
			public boolean onKey(View v, int keyCode, KeyEvent event)
			{
				if (event.getAction() == KeyEvent.ACTION_UP)
				{
					// check if the right key was pressed
					if (keyCode == KeyEvent.KEYCODE_ENTER)
					{
						btnAgregar.performClick();
						return true;
					}
				}
				return false;
			}
		});

		btnAgregar = (ImageButton) findViewById(R.id.btnAgregar);
		btnAgregar.setOnClickListener(mAgregarArticulo);

		Activity act = (Activity) li.getContext();
		mVista = (Vista) act;
	}

    private void habilitarScaner(boolean habilitar){
        if (habilitar) {
            bCapturaImagen = false;
            txtScanner.mostrarScaner();
            btnBuscar.setVisibility(VISIBLE);
            bDescripcion = false;
        }
        else {
            bCapturaImagen = true;
            txtScanner.mostrarCamera();
            btnBuscar.setVisibility(GONE);
            bDescripcion = true;
        }
    }

	public void limpiarProducto()
	{
		try
		{
			txtScanner.BorrarTexto();
			txtCantidad.setText("");
			lblArtDescripcion.setText("");
			lblArtExistencia.setText("");
			oArticulo = null;
			txtScanner.requestFocus();
		}
		catch (Exception e)
		{
			Log.e("", "" + e);

		}

	}

	// *******Asignación de valores a las
	// propiedades************************************************
	public void setCantidad(Float cantidad)
	{
		txtCantidad.setText(cantidad.toString());
	}

	public void setError(String Error)
	{
		error = Error;
	}

	public void setAdvertencia(String Advertencia)
	{
		bAdvertencia = true;
		error = Advertencia;
	}

    public void setTituloImagen(String tituloImagen) {
        lblArtDescripcion.setText(tituloImagen);
    }

	// *************************************************************************************************
	public void setEnabled(boolean habilitar)
	{
		txtScanner.setEnabled(habilitar);
		btnBuscar.setEnabled(habilitar);
		txtCantidad.setEnabled(habilitar);
		btnAgregar.setEnabled(habilitar);
		txtScanner.habilitarBotonScanner(habilitar);
	}

	public void onActivityResult(int requestCode, int resultCode, Intent intent)
	{
		// pasar a la vista el manejo
		mVista.resultadoActividad(requestCode, resultCode, intent);
	}

	public void setFinBusqueda()
	{
		limpiarProducto();
		bMostrandoBusqueda = false;
	}

	private android.view.View.OnClickListener mBuscarArticulo = new android.view.View.OnClickListener()
	{
		@Override
		public void onClick(View v)
		{
			buscarArticulo(txtScanner.getTexto(), false);
		}
	};

	private OnCodigoIngresadoListener mCodigoBarras = new OnCodigoIngresadoListener() {
        public void OnCodigoIngresado(String Codigo, int codigoLeido) {
            if (codigoLeido == 3){ //Camera
                if (capturarImagenListener != null)
                    capturarImagenListener.onCapturarImagen();
                return;
            }
			if (bClaveManual)
				return;
			if (Codigo.length() == 0)
				return;
		    buscarArticulo(Codigo, codigoLeido == 1 ? true : false);
		}
	};

	private void buscarArticulo(String cadenaBusqueda, boolean codigoLeido)
	{
		try
		{
			if (bClaveManual)
				return;

            Sesion.remove(Campo.ArticuloActual);
            Sesion.remove(Campo.ArticuloDescActual);

            if (bDescripcion)
            {
                oArticulo = null;
                Sesion.set(Campo.ArticuloDescActual, cadenaBusqueda);
                txtCantidad.setInputType(InputType.TYPE_NUMBER_FLAG_DECIMAL|InputType.TYPE_CLASS_NUMBER);
                txtScanner.clearFocus();
                txtCantidad.requestFocus();
                txtCantidad.selectAll();
                txtCantidad.setSelectAllOnFocus(true);

                return;
            }

			if (cadenaBusqueda.equals(""))
			{
				if (bMostrandoBusqueda)
					return;
				if (buscarListener != null)
				{
					buscarListener.onArticuloNoEncontrado();
				}

                bMostrandoBusqueda = true;
                if (Sesion.get(Campo.RecargaActual) != null)
                {
                    final HashMap<String, Object> parametros = new HashMap<String, Object>();
                    parametros.put("RecargaId", Sesion.get(Campo.RecargaActual));
                    parametros.put("Cadena", "");
                    mVista.iniciarActividadConResultado(IBuscaArticulo.class, Enumeradores.Solicitudes.SOLICITUD_BUSQUEDA_ARTICULOS, Enumeradores.Acciones.ACCION_OBTENER_ARTICULOS_SELECCIONADOS, parametros);
                }
                else
                    mVista.iniciarActividadConResultado(IBuscaArticulo.class, Enumeradores.Solicitudes.SOLICITUD_BUSQUEDA_ARTICULOS, Enumeradores.Acciones.ACCION_OBTENER_ARTICULOS_SELECCIONADOS, null);
			}
			else
			{
				oArticulo = null;
				if (!codigoLeido)
				{
                    oArticulo = Consultas.ConsultasArticulo.obtenerArticuloIdentico(cadenaBusqueda);
					if (oArticulo == null)
					{
						// Buscar codigo barras
                        oArticulo = Consultas.ConsultasArticulo.obtenerArticulo(cadenaBusqueda);
						if (oArticulo != null)
						{
							bClaveManual = true;
							txtScanner.txtScanner.setText(oArticulo.Clave);
							txtCantidad.requestFocus();
							bClaveManual = false;

                            obtenerDetallesArticulo(oArticulo);
							mVista.getWindow().setSoftInputMode(WindowManager.LayoutParams.SOFT_INPUT_STATE_ALWAYS_VISIBLE );
							return;
						}
						else
						{
							if (bMostrandoBusqueda)
								return;
							if (buscarListener != null)
							{
								buscarListener.onArticuloNoEncontrado();
							}
							final HashMap<String, Object> parametros = new HashMap<String, Object>();
							parametros.put("Cadena", cadenaBusqueda);
                            if (Sesion.get(Campo.RecargaActual) != null)
                            {
                                parametros.put("RecargaId", Sesion.get(Campo.RecargaActual));
                            }
							bMostrandoBusqueda = true;
                            mVista.iniciarActividadConResultado(IBuscaArticulo.class, Enumeradores.Solicitudes.SOLICITUD_BUSQUEDA_ARTICULOS, Enumeradores.Acciones.ACCION_OBTENER_ARTICULOS_SELECCIONADOS, parametros);
						}
					}
					else
					{
						obtenerDetallesArticulo(oArticulo);
					}
				}
				else
				{
                    oArticulo = Consultas.ConsultasArticulo.obtenerArticulo(cadenaBusqueda);
                    if (oArticulo != null)
					{
					    bClaveManual = true;
						txtScanner.txtScanner.setText(oArticulo.Clave);
						txtCantidad.requestFocus();
						bClaveManual = false;

                        obtenerDetallesArticulo(oArticulo);
                        mVista.getWindow().setSoftInputMode(WindowManager.LayoutParams.SOFT_INPUT_STATE_ALWAYS_VISIBLE );
                        return;
					}

					mVista.mostrarError("El código no corresponde a un artículo existente");
					txtScanner.BorrarTexto();
				}
			}
		}
		catch (Exception ex)
		{
			mVista.mostrarError(ex.getMessage());
		}
	}



	public void obtenerDetallesArticulo(Articulo articulo)
	{
		try
		{
            Sesion.set(Campo.ArticuloActual, articulo);
			lblArtDescripcion.setText(articulo.Descripcion);
            lblArtExistencia.setText("Exist: " + Generales.getFormatoDecimal(Consultas.ConsultasInventario.obtenerExistencia(articulo.ArticuloId), 2));


//			if (producto.DecimalProducto == 0){
//				txtCantidad.setInputType(InputType.TYPE_CLASS_NUMBER);
//			}else{
				txtCantidad.setInputType(InputType.TYPE_NUMBER_FLAG_DECIMAL|InputType.TYPE_CLASS_NUMBER);
//			}

            txtScanner.clearFocus();
            txtCantidad.requestFocus();
            txtCantidad.selectAll();
            txtCantidad.setSelectAllOnFocus(true);

		}
		catch (Exception ex)
		{
			mVista.mostrarError(ex.getMessage().equals("") ? ex.getCause().getMessage() : ex.getMessage());
		}
	}

	public boolean validarCaptura()
	{
        if (bDescripcion)
        {
            if (txtScanner.getTexto().trim().equals(""))
            {
                mVista.mostrarError("El campo Artículo es requerido");
                txtCantidad.requestFocus();
                return false;
            }
        }
        else
        {
            if (oArticulo == null) {
                mVista.mostrarError("El campo Artículo es requerido");
                txtScanner.requestFocus();
                return false;
            }
        }

		if (txtCantidad.getText().toString().trim().equals(""))
		{
			mVista.mostrarError("El campo Cantidad es requerido");
			txtCantidad.requestFocus();
			return false;
		}

        if (Float.parseFloat(txtCantidad.getText().toString()) <= 0 )
        {
            mVista.mostrarError("La cantidad debe ser mayor a cero");
            txtCantidad.requestFocus();
            return false;
        }

		return true;
	}

	public String getCantidad()
	{
		return txtCantidad.getText().toString();
	}

	private OnClickListener mAgregarArticulo = new OnClickListener()
	{
		@Override
		public void onClick(View v)
		{
			// solo se dispara el listener cuando esta el producto capturado y
			// tiene cantidad > 0
			if (agregarListener == null)
				return;

			if (validarCaptura())
			{
                String descripcion = txtScanner.getTexto();
                float cantidad = Float.parseFloat(Generales.getFormatoDecimal(Float.parseFloat(txtCantidad.getText().toString()), 2));
                agregarListener.onAgregarArticulo(oArticulo, descripcion, cantidad);

                if (error == "")
                {
                    limpiarProducto();
                }
                else
                {
                    mVista.mostrarError(error);
                    error = "";
                    if (bAdvertencia)
                    {
                        limpiarProducto();
                        bAdvertencia = false;
                    }
                }
			}
		}
	};

    /*public void setFocus()
    {
        txtCantidad.clearFocus();

        txtScanner.setFocusable(true);
        txtScanner.requestFocus();
    }*/

	// ***************************** listener para agregar producto
	// **************************************
	public interface onAgregarArticuloListener
	{
		void onAgregarArticulo(Articulo articulo, String descripcion, float cantidad);
	}

	private onAgregarArticuloListener agregarListener = null;

	public void setOnAgregarArticuloListener(onAgregarArticuloListener l)
	{
		agregarListener = l;
	}

	// ***************************************************************************************************

	// ***************************** listener para buscar producto
	// ***************************************
	public interface onArticuloNoEncontradoListener
	{
		void onArticuloNoEncontrado();
	}

	private onArticuloNoEncontradoListener buscarListener = null;

	public void setOnArticuloNoEncontradoListener(onArticuloNoEncontradoListener l)
	{
		buscarListener = l;
	}
    
	public void setEnableCantidadAgregar(boolean habilita)
    {
    	txtCantidad.setEnabled(habilita);
    	btnAgregar.setEnabled(habilita);
    }

    public void setValoresProductoModificar(String clave, Float cantidad, boolean descripcion)
    {
        try {
            bClaveManual = true;
            if (!descripcion) {
                bDescripcion = false;
                chkClave.setChecked(true);
                habilitarScaner(true);
                oArticulo = Consultas.ConsultasArticulo.obtenerArticulo(clave);
                txtScanner.setTexto(clave);
                obtenerDetallesArticulo(oArticulo);
            }else{
                bDescripcion = true;
                oArticulo = null;
                chkClave.setChecked(false);
                habilitarScaner(false);
                txtScanner.setTexto(clave);
                lblArtDescripcion.setText("");
            }
            txtCantidad.setText(cantidad.toString());
            bClaveManual = false;
        }catch(Exception e){
            e.printStackTrace();
        }

    }

    // ***************************** listener para capturar imagen
    // **************************************
    public interface onCapturarImagenListener
    {
        void onCapturarImagen();
    }

    private onCapturarImagenListener capturarImagenListener = null;

    public void setOnCapturarImagenListener(onCapturarImagenListener l)
    {
        capturarImagenListener = l;
    }

    // ***************************************************************************************************
}
