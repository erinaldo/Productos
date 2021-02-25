package com.amesol.routelite.controles;

import java.util.HashMap;

import android.app.Activity;
import android.content.Context;
import android.content.Intent;
import android.database.Cursor;
import android.text.InputType;
import android.util.AttributeSet;
import android.util.Log;
import android.view.KeyEvent;
import android.view.LayoutInflater;
import android.view.View;
import android.view.WindowManager;
import android.widget.EditText;
import android.widget.ImageButton;
import android.widget.LinearLayout;
import android.widget.SimpleCursorAdapter;
import android.widget.SimpleCursorAdapter.ViewBinder;
import android.widget.Spinner;
import android.widget.TextView;

import com.amesol.routelite.R;
import com.amesol.routelite.actividades.Enumeradores.Inventario.TiposValidacionInventario;
import com.amesol.routelite.actividades.InventarioDobleUnidad;
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.actividades.ValoresReferencia;
import com.amesol.routelite.controles.TextBoxScanner.OnCodigoIngresadoListener;
import com.amesol.routelite.controles.TextBoxScanner.OnTextChangedListener;
import com.amesol.routelite.datos.Cliente;
import com.amesol.routelite.datos.ModuloMovDetalle;
import com.amesol.routelite.datos.Producto;
import com.amesol.routelite.datos.basedatos.BDVend;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.basedatos.Consultas2;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.CONHist;
import com.amesol.routelite.datos.utilerias.ConfigParametro;
import com.amesol.routelite.datos.utilerias.MOTConfiguracion;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.interfaces.IBuscaProducto;
import com.amesol.routelite.utilerias.ControlError;
import com.amesol.routelite.utilerias.Generales;
import com.amesol.routelite.vistas.Vista;


import org.apache.commons.lang3.StringUtils;

public class CapturaProducto extends LinearLayout {


    // controles
    TextBoxScanner txtScanner;
    //LinearLayout btnBuscar;
    ImageButton btnBuscar;
    Spinner cboUnidad;
    EditText txtCantidad;
	EditText txtCantidad1;
	EditText txtCantidad2;
    ImageButton btnAgregar;
    TextView lblProDescripcion;
    TextView lblProExistencia;
    LinearLayout laySaldoEnvase;
    TextView lblSaldoEnvase;

    // variables
    Producto oProducto = null;
    Vista mVista = null;

    // parametros para la busquedaoParametros
    //String PCEPrecioClave = null;
    String CadenaListasPrecios = "";
    String TransProdIds = null;
    String moduloEsquemas = "";
    String nombreModulo = "";
	int tipoValidacionExistencia = TiposValidacionInventario.NoValidar;
	short tipoMovimiento;
	short tipoTransProd;
	//ModuloMovDetalle moduloMovDetalle = null;
	boolean mDevolucionesManuales = false;
	Context context;

	boolean bClaveManual = false;
	boolean bMostrandoBusqueda = false;
	boolean bAdvertencia = false;
	String error = "";
	
	int ubicacionExistencia; //variable para los traspasos de inventario (diponible o no disponible)
	boolean TraspasoInventario = false;
	boolean origenDestinoOk = false;
	boolean tipoMotivoOK = false;
    boolean surtir = false;

    String sMsgValidaEnvase="";//Envase Devolucion Cliente
    boolean bSoloEnvase= false;//Envase Devolucion Cliente
    boolean excluirCanjes = false; //Excluir productos tipo Canje de la busqueda
    boolean manejoDobleUnidad = false;
    int DigitoClaveProd=0;

	// ************************************************ constructores
	// ************************************************
	public CapturaProducto(Context context, AttributeSet attrs)
	{
		super(context, attrs);
		inicializar();
	}

	public CapturaProducto(Context context)
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
		li.inflate(R.layout.captura_producto, this, true);

		if (this.isInEditMode()) // para que no truene cuando se agrega al
									// layout en vista de diseño
			return;

        if (((MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion)).get("ManejoDobleUnidad").toString().equals("1"))
        {
            manejoDobleUnidad = true;
            LinearLayout lay = (LinearLayout) findViewById(R.id.layUnidadCantidad);
            lay.setVisibility(View.GONE);
        }
		// Obtenemos las referencias a los distintos controles
		txtScanner = (TextBoxScanner) findViewById(R.id.textBoxScanner);

        if(((CONHist) Sesion.get(Campo.CONHist)).get("TipoClaveProducto").toString().equals("2")){
            txtScanner.setTecladoNumerico();
            DigitoClaveProd = Integer.parseInt(((CONHist) Sesion.get(Campo.CONHist)).get("DigitoClaveProd").toString());
        }

		txtScanner.setOnCodigoIngresado(mCodigoBarras);
		txtScanner.setOnTextChanged(new OnTextChangedListener()
		{
			@Override
			public void OnTextChanged(CharSequence s)
			{
				if (bClaveManual)
					return;
				if (cboUnidad.getAdapter() != null)
				{
					((SimpleCursorAdapter) cboUnidad.getAdapter()).getCursor().close();
				}
				txtCantidad.setText("");
				lblProDescripcion.setText("");
				lblProExistencia.setText("");

				oProducto = null;
                if(manejoDobleUnidad){
                    LinearLayout lay = (LinearLayout) findViewById(R.id.layDobleUnidad);
                    lay.setVisibility(View.GONE);
					txtCantidad1.setText("");
					txtCantidad2.setText("");
                }
			}
		});

		//btnBuscar = (LinearLayout) findViewById(R.id.btnBuscarProducto); //se cambio el id al ImageButton en el layout (captura_producto.xml), con el LinearLayout daba problemas al darle click
		btnBuscar = (ImageButton) findViewById(R.id.btnBuscarProducto);
		btnBuscar.setOnClickListener(mBuscarProducto);

		cboUnidad = (Spinner) findViewById(R.id.cboUnidad);
		txtCantidad = (EditText) findViewById(R.id.txtCantidad);
		txtCantidad.selectAll();
		txtCantidad.setSelectAllOnFocus(true);

		lblProDescripcion = (TextView) findViewById(R.id.lblProDescripcion);
		lblProExistencia = (TextView) findViewById(R.id.lblProExistencia);
        laySaldoEnvase = (LinearLayout) findViewById(R.id.laySaldoEnvase);
        lblSaldoEnvase = (TextView) findViewById(R.id.lblSaldoEnvase);

		// final InputMethodManager imm = (InputMethodManager)
		// context.getSystemService(Context.INPUT_METHOD_SERVICE);

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
		btnAgregar.setOnClickListener(mAgregarProducto);

		if (manejoDobleUnidad){
			btnAgregar  = (ImageButton) findViewById(R.id.btnAgregarDobleUnidad);
			btnAgregar.setOnClickListener(mAgregarProductoDobleUnidad);

			txtCantidad2 = (EditText) findViewById(R.id.txtCantidad2);
			txtCantidad2.selectAll();
			txtCantidad2.setSelectAllOnFocus(true);
			txtCantidad2.setOnKeyListener(new OnKeyListener()
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

			txtCantidad1 = (EditText) findViewById(R.id.txtCantidad1);
			txtCantidad1.selectAll();
			txtCantidad1.setSelectAllOnFocus(true);
			txtCantidad1.setOnKeyListener(new OnKeyListener()
			{

				@Override
				public boolean onKey(View v, int keyCode, KeyEvent event)
				{
			if (event.getAction() == KeyEvent.ACTION_UP)
					{
						// check if the right key was pressed
						if (keyCode == KeyEvent.KEYCODE_ENTER )
						{
							if (txtCantidad2.isShown() && txtCantidad1.getText().toString().length()>0) {
									if (((InventarioDobleUnidad.DetalleProductoDobleUnidad)txtCantidad1.getTag()).KgLts != null && ((InventarioDobleUnidad.DetalleProductoDobleUnidad)txtCantidad1.getTag()).KgLts >0 ) {
											Float equivalencia = Float.parseFloat(txtCantidad1.getText().toString()) * ((InventarioDobleUnidad.DetalleProductoDobleUnidad)txtCantidad1.getTag()).KgLts;
											txtCantidad2.setText(Generales.getFormatoDecimal(Generales.getRound(equivalencia, ((InventarioDobleUnidad.DetalleProductoDobleUnidad) txtCantidad2.getTag()).DecimalProducto), "#######0.#####"));
									}
								if (txtCantidad2.isEnabled()) {
									txtCantidad2.requestFocus();
								}else{
									btnAgregar.performClick();
								}

							}else{
								btnAgregar.performClick();
							}
							return true;
						}
					}
					return false;
				}
			});

			txtCantidad1.setOnFocusChangeListener(new OnFocusChangeListener() {
				@Override
				public void onFocusChange(View view, boolean b) {
					if (!b){
						if (txtCantidad2.isShown() && txtCantidad1.getText().toString().length()>0) {
								if (((InventarioDobleUnidad.DetalleProductoDobleUnidad)txtCantidad1.getTag()).KgLts != null && ((InventarioDobleUnidad.DetalleProductoDobleUnidad)txtCantidad1.getTag()).KgLts >0 ) {
									Float equivalencia = Float.parseFloat(txtCantidad1.getText().toString()) * ((InventarioDobleUnidad.DetalleProductoDobleUnidad)txtCantidad1.getTag()).KgLts;
									txtCantidad2.setText(Generales.getFormatoDecimal(Generales.getRound(equivalencia, ((InventarioDobleUnidad.DetalleProductoDobleUnidad) txtCantidad2.getTag()).DecimalProducto), "#######0.#####"));
								}
						}
					}
				}
			});
		}

        try {
            String moduloMovDetalleClave = (String) Sesion.get(Campo.ModuloMovDetalleClave);
            ModuloMovDetalle mmd = new ModuloMovDetalle();
            mmd.ModuloMovDetalleClave = moduloMovDetalleClave;
            BDVend.recuperar(mmd);
            nombreModulo = mmd.Nombre;
            mmd = null;
        }catch(Exception ex){
            nombreModulo = "Error al recuperar el módulo";
        }

		Activity act = (Activity) li.getContext();
		mVista = (Vista) act;
	}

	public void limpiarProducto()
	{
		try
		{
			txtScanner.BorrarTexto();
			if (cboUnidad.getAdapter() != null)
			{
				((SimpleCursorAdapter) cboUnidad.getAdapter()).getCursor().close();
			}
			cboUnidad.setEnabled(false);
			txtCantidad.setText("");
			lblProDescripcion.setText("");
			lblProExistencia.setText("");
            laySaldoEnvase.setVisibility(GONE);
            lblSaldoEnvase.setText("");
			oProducto = null;
			txtScanner.requestFocus();
            if (manejoDobleUnidad){
                LinearLayout lay = (LinearLayout) findViewById(R.id.layDobleUnidad);
                lay.setVisibility(View.GONE);
            }
		}
		catch (Exception e)
		{
			Log.e("", "" + e);

		}

	}

	public void llenarProductoUnidad(Producto producto, int tipoUnidad, Float cantidad)
	{

		txtScanner.setTexto(producto.ProductoClave);
		oProducto = producto;
		try
		{
			if (oProducto.isRecuperado() == false){
				BDVend.recuperar(producto);
			}
			
			obtenerDetallesProducto(oProducto);
			Generales.SelectSpinnerItemByValue(cboUnidad, tipoUnidad);

			txtCantidad.setText(Generales.getFormatoDecimal(cantidad, producto.DecimalProducto ) );
			if (cboUnidad.getCount() > 1)
			{
				cboUnidad.requestFocus();
			}
			else
			{
				cboUnidad.setEnabled(false);
				txtCantidad.requestFocus();
				txtCantidad.selectAll();
				txtCantidad.setSelectAllOnFocus(true);
			}
			
			if (oProducto.DecimalProducto == 0){
				txtCantidad.setInputType(InputType.TYPE_CLASS_NUMBER);
			}else{
				txtCantidad.setInputType(InputType.TYPE_NUMBER_FLAG_DECIMAL|InputType.TYPE_CLASS_NUMBER);
			}
		}
		catch (Exception e)
		{
			mVista.mostrarError(e.getMessage());
		}
	}

	public void llenarProductoDobleUnidad(Producto producto, HashMap<Short, Float> hmUnidades)
	{

		txtScanner.setTexto(producto.ProductoClave);
		oProducto = producto;
		try
		{
			if (oProducto.isRecuperado() == false){
				BDVend.recuperar(producto);
			}

			obtenerDetallesProducto(oProducto);

			InventarioDobleUnidad.DetalleProductoDobleUnidad Unidad1 =(InventarioDobleUnidad.DetalleProductoDobleUnidad)txtCantidad1.getTag();
			txtCantidad1.setText(Generales.getFormatoDecimal(hmUnidades.get(Unidad1.PRUTipoUnidad),Unidad1.DecimalProducto));

			if (txtCantidad2.isShown()) {
				InventarioDobleUnidad.DetalleProductoDobleUnidad Unidad2 = (InventarioDobleUnidad.DetalleProductoDobleUnidad) txtCantidad2.getTag();
				if (hmUnidades.containsKey(Unidad2.PRUTipoUnidad)) {
					txtCantidad2.setText(Generales.getFormatoDecimal(hmUnidades.get(Unidad2.PRUTipoUnidad), Unidad2.DecimalProducto));
				}
			}

			txtCantidad1.requestFocus();
			txtCantidad1.selectAll();
			txtCantidad1.setSelectAllOnFocus(true);

			if (Unidad1.DecimalProducto == 0){
				txtCantidad1.setInputType(InputType.TYPE_CLASS_NUMBER);
			}else{
				txtCantidad1.setInputType(InputType.TYPE_NUMBER_FLAG_DECIMAL|InputType.TYPE_CLASS_NUMBER);
			}
			txtCantidad1.requestFocus();

		}
		catch (Exception e)
		{
			mVista.mostrarError(e.getMessage());
		}
	}

	// ***************************************************************************************************************

	// ****************************** setters para los parametros de la busqueda
	// *************************************
	public void setCadenaListasPrecios(String listasPrecios)
	{
		CadenaListasPrecios = listasPrecios;
	}
	public void setTransProdIds(String transProdIds)
	{
		TransProdIds = transProdIds;
	}

	public void setModuloEsquemas(String pModuloEsquemas)
	{
		moduloEsquemas = pModuloEsquemas;
	}
	public void setTipoValidacionExistencia(int tipoValidaExistencia)
	{
		tipoValidacionExistencia = tipoValidaExistencia;
	}

	public void setTipoMovimiento(short pTipoMovimiento)
	{
		tipoMovimiento = pTipoMovimiento;
	}

	public void setTipoTransProd(short pTipoTransProd)
	{
		tipoTransProd = pTipoTransProd;
	}

	public void setDevolucionesManuales(boolean Devolucion)
	{
		mDevolucionesManuales = Devolucion;
	}
	
	public void setTraspasoInventario(boolean Traspaso)
	{
		TraspasoInventario = Traspaso;
	}
	
	public void setOrigenDestinoOk(boolean ok){
		origenDestinoOk = ok;
	}
	
	public void setTipoMotivoOk(boolean ok){
		tipoMotivoOK = ok;
	}
	
	public void setUbicacionExistencia(short ubicacionExistencia)
	{
		this.ubicacionExistencia = ubicacionExistencia;
	}

    public void setSurtir(boolean bSurtir){
        surtir = bSurtir;
    }

    public void setExcluirCanjes(boolean bExcluirCanjes){
        excluirCanjes = bExcluirCanjes;
    }

	// *******Asignación de valores a las
	// propiedades************************************************
	public void setCantidad(Float cantidad)
	{
		txtCantidad.setText(cantidad.toString());
	}

	public void setCantidad(Float cantidad, Short TipoUnidad)
	{
		if(!manejoDobleUnidad) return;
		if (((InventarioDobleUnidad.DetalleProductoDobleUnidad)txtCantidad1.getTag()).PRUTipoUnidad == TipoUnidad){
			txtCantidad1.setText(cantidad.toString());
		}else if (((InventarioDobleUnidad.DetalleProductoDobleUnidad)txtCantidad2.getTag()).PRUTipoUnidad == TipoUnidad){
			txtCantidad2.setText(cantidad.toString());
		}
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

	// *************************************************************************************************
	public void setEnabled(boolean habilitar)
	{
		txtScanner.setEnabled(habilitar);
		btnBuscar.setEnabled(habilitar);
		cboUnidad.setEnabled(habilitar);
		txtCantidad.setEnabled(habilitar);
		btnAgregar.setEnabled(habilitar);
		txtScanner.habilitarBotonScanner(habilitar);
		/*
		 * if (!habiliar){
		 * 
		 * }
		 */
	}

    public Spinner getSpinnerUnidad(){
        return cboUnidad;
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

	private android.view.View.OnClickListener mBuscarProducto = new android.view.View.OnClickListener()
	{
		@Override
		public void onClick(View v)
		{
            if(txtScanner.getTexto().length() != 0 && ((CONHist) Sesion.get(Campo.CONHist)).get("TipoClaveProducto").toString().equals("2")){
                txtScanner.setTexto(StringUtils.leftPad(txtScanner.getTexto(),DigitoClaveProd,"0"));
                buscarProducto(StringUtils.leftPad(txtScanner.getTexto(),DigitoClaveProd,"0"), false);
            }else {
                buscarProducto(txtScanner.getTexto(), false);
            }
		}
	};

	private OnCodigoIngresadoListener mCodigoBarras = new OnCodigoIngresadoListener()
	{
		public void OnCodigoIngresado(String Codigo, int codigoLeido)
		{
			if (bClaveManual)
				return;
			if (Codigo.length() == 0)
				return;

            if(((CONHist) Sesion.get(Campo.CONHist)).get("TipoClaveProducto").toString().equals("2")){
                txtScanner.setTexto(StringUtils.leftPad(Codigo.replace("\n",""),DigitoClaveProd,"0"));
                buscarProducto(StringUtils.leftPad(txtScanner.getTexto(),DigitoClaveProd,"0"), false);
            }else {
                buscarProducto(Codigo, codigoLeido == 1 ? true : false);
            }
		}
	};

	private void buscarProducto(String cadenaBusqueda, boolean codigoLeido)
	{

		try
		{
			if (bClaveManual)
				return;

            //Este tipo de validaciones no deberian estar en esta parte de código
            //ya que teoricamente este control es general
            //Se podrian usar mas bien los eventos para realizarlas en la clase que corresponda.
            if(TraspasoInventario){
				if(!origenDestinoOk){
					mVista.mostrarAdvertencia(Mensajes.get("E0926"));
					return;
				}
				if(!tipoMotivoOK){
					mVista.mostrarAdvertencia(Mensajes.get("E0161").replace("$0$", Mensajes.get("XMotivo")));
					return;
				}
			}
			//WEHRE
			if (cadenaBusqueda.equals(""))
			{
				if (bMostrandoBusqueda)
					return;
				if (buscarListener != null)
				{
					buscarListener.onProductoNoEncontrado();
				}

					final HashMap<String, Object> parametros = new HashMap<String, Object>();
					parametros.put("Esquema", "Todos");
					parametros.put("Cadena", cadenaBusqueda);
					parametros.put("ListaPrecios", CadenaListasPrecios);
					parametros.put("TransProd", TransProdIds);
					parametros.put("TipoValidarExistencia", tipoValidacionExistencia);
					parametros.put("TipoMovimiento", tipoMovimiento);
					parametros.put("TipoTransProd", tipoTransProd);
					parametros.put("ModuloEsquemas", moduloEsquemas);
					parametros.put("UbicacionExistencia", ubicacionExistencia);
                    parametros.put("SoloEnvase", bSoloEnvase);//Envase Devolucion Cliente
                    parametros.put("ExcluirCanjes", excluirCanjes);

                bMostrandoBusqueda = true;
                if (!manejoDobleUnidad){
                    mVista.iniciarActividadConResultado(IBuscaProducto.class, Enumeradores.Solicitudes.SOLICITUD_BUSQUEDA_PRODUCTOS, Enumeradores.Acciones.ACCION_OBTENER_PRODUCTOS_SELECCIONADOS, parametros);
                }else{
                    mVista.iniciarActividadConResultado(IBuscaProducto.class, Enumeradores.Solicitudes.SOLICITUD_BUSQUEDA_PRODUCTOS, Enumeradores.Acciones.ACCION_OBTENER_BUSQUEDA_SIMPLE, parametros);
                }
				//}
			}
			else
			{
				oProducto = null;
				if (!codigoLeido)
				{
					oProducto = Consultas.ConsultasProducto.obtenerProductoIdentico(cadenaBusqueda);
					if (oProducto == null)
					{
						// Buscar codigo barras
						ISetDatos unidades = Consultas.ConsultasProducto.buscarCodigoBarras(cadenaBusqueda, CadenaListasPrecios);
						if (unidades != null && unidades.getCount() > 0)
						{
							if (unidades.moveToFirst())
							{
								bClaveManual = true;
								txtScanner.txtScanner.setText(unidades.getString("ProductoClave"));
								txtCantidad.requestFocus();
								bClaveManual = false;
								oProducto = Consultas.ConsultasProducto.obtenerProducto(unidades.getString("ProductoClave"));
								if (oProducto != null)
								{
									if (moduloEsquemas.length()>0){
										if (!Consultas.ConsultasProductoEsquema.productoEsquemaValido(oProducto.ProductoClave, moduloEsquemas)){
											mVista.mostrarError(Mensajes.get("E0923", nombreModulo));
											oProducto = null;
											unidades.close();
											return;
										}
									}else if(excluirCanjes && oProducto.Tipo == Enumeradores.PROTipo.CANJE ){
                                        mVista.mostrarError(Mensajes.get("E0773","Linea, Linea/Canje"));
                                        unidades.close();
                                        oProducto = null;
                                        return;
                                    }
                                    sMsgValidaEnvase=ValidarSoloEnvase(oProducto);//Envase Devolucion Cliente
                                    if (sMsgValidaEnvase.length()>0){//Envase Devolucion Cliente
                                        if(sMsgValidaEnvase == "E0773")
                                            mVista.mostrarError(Mensajes.get(sMsgValidaEnvase).replace("$0$","Envase"));//Envase Devolucion Cliente
                                        else
                                            mVista.mostrarError(Mensajes.get(sMsgValidaEnvase));//Envase Devolucion Cliente
                                        oProducto = null;//Envase Devolucion Cliente
                                        unidades.close();//Envase Devolucion Cliente
                                        sMsgValidaEnvase="";//Envase Devolucion Cliente
                                        return;//Envase Devolucion Cliente
                                    }//Envase Devolucion Cliente
									obtenerDetallesProducto(oProducto);
									//mostrarUnidades(unidades);
									cboUnidad.setEnabled(false);
									mVista.getWindow().setSoftInputMode(WindowManager.LayoutParams.SOFT_INPUT_STATE_ALWAYS_VISIBLE );
									unidades.close();
									return;
								}
							}
						}
						else
						{
							if (bMostrandoBusqueda)
								return;
							if (buscarListener != null)
							{
								buscarListener.onProductoNoEncontrado();
							}
							final HashMap<String, Object> parametros = new HashMap<String, Object>();
							parametros.put("Esquema", "Todos");
							parametros.put("Cadena", cadenaBusqueda);
							parametros.put("ListaPrecios", CadenaListasPrecios);
							parametros.put("TransProd", TransProdIds);
							parametros.put("TipoValidarExistencia", tipoValidacionExistencia);
							parametros.put("TipoMovimiento", tipoMovimiento);
							parametros.put("TipoTransProd", tipoTransProd);
							parametros.put("ModuloEsquemas", moduloEsquemas);
							parametros.put("UbicacionExistencia", ubicacionExistencia);
                            parametros.put("SoloEnvase", bSoloEnvase);//Envase Devolucion Cliente
                            parametros.put("ExcluirCanjes",excluirCanjes);
							bMostrandoBusqueda = true;
                            if (((MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion)).get("ManejoDobleUnidad").toString().equals("0")){
                                mVista.iniciarActividadConResultado(IBuscaProducto.class, Enumeradores.Solicitudes.SOLICITUD_BUSQUEDA_PRODUCTOS, Enumeradores.Acciones.ACCION_OBTENER_PRODUCTOS_SELECCIONADOS, parametros);
                            }else{
                                mVista.iniciarActividadConResultado(IBuscaProducto.class, Enumeradores.Solicitudes.SOLICITUD_BUSQUEDA_PRODUCTOS, Enumeradores.Acciones.ACCION_OBTENER_BUSQUEDA_SIMPLE, parametros);
                            }
						}
					}
					else
					{
						/*
						 * Se encontró el producto, buscar que pertenezca a los esquemas válidos
						 * para el módulo actual
						 */
						if (moduloEsquemas.length()>0){
							if (!Consultas.ConsultasProductoEsquema.productoEsquemaValido(oProducto.ProductoClave, moduloEsquemas)){
                                mVista.mostrarError(Mensajes.get("E0923", nombreModulo));
								oProducto = null;
								return;
							}
						}else if(excluirCanjes && oProducto.Tipo == Enumeradores.PROTipo.CANJE ){
                            mVista.mostrarError(Mensajes.get("E0773","Linea, Linea/Canje"));
                            oProducto = null;
                            return;
                        }
                        sMsgValidaEnvase=ValidarSoloEnvase(oProducto);//Envase Devolucion Cliente
                        if (sMsgValidaEnvase.length()>0){//Envase Devolucion Cliente
                            if(sMsgValidaEnvase == "E0773")
                                mVista.mostrarError(Mensajes.get(sMsgValidaEnvase).replace("$0$","Envase"));//Envase Devolucion Cliente
                            else
                                mVista.mostrarError(Mensajes.get(sMsgValidaEnvase));//Envase Devolucion Cliente
                            oProducto = null;//Envase Devolucion Cliente
                            sMsgValidaEnvase="";//Envase Devolucion Cliente
                            return;//Envase Devolucion Cliente
                        }//Envase Devolucion Cliente
						obtenerDetallesProducto(oProducto);
					}
				}
				else
				{
					ISetDatos unidades = Consultas.ConsultasProducto.buscarCodigoBarras(cadenaBusqueda, CadenaListasPrecios);
					if (unidades != null)
					{
						if (unidades.moveToFirst())
						{
							bClaveManual = true;
							txtScanner.txtScanner.setText(unidades.getString("ProductoClave"));
							txtCantidad.requestFocus();
							bClaveManual = false;
							oProducto = Consultas.ConsultasProducto.obtenerProducto(unidades.getString("ProductoClave"));
							if (oProducto != null)
							{
								if (moduloEsquemas.length()>0){
									if (!Consultas.ConsultasProductoEsquema.productoEsquemaValido(oProducto.ProductoClave, moduloEsquemas)){
										mVista.mostrarError(Mensajes.get("E0923", nombreModulo));
										oProducto = null;
										unidades.close();
										return;
									}
								}else if(excluirCanjes && oProducto.Tipo == Enumeradores.PROTipo.CANJE ){
                                    mVista.mostrarError(Mensajes.get("E0773","Linea, Linea/Canje"));
                                    unidades.close();
                                    oProducto = null;
                                    return;
                                }
                                sMsgValidaEnvase=ValidarSoloEnvase(oProducto);//Envase Devolucion Cliente
                                if (sMsgValidaEnvase.length()>0){//Envase Devolucion Cliente
                                    if(sMsgValidaEnvase == "E0773")
                                        mVista.mostrarError(Mensajes.get(sMsgValidaEnvase).replace("$0$","Envase"));//Envase Devolucion Cliente
                                    else
                                        mVista.mostrarError(Mensajes.get(sMsgValidaEnvase));//Envase Devolucion Cliente
                                    oProducto = null;//Envase Devolucion Cliente
                                    unidades.close();//Envase Devolucion Cliente
                                    sMsgValidaEnvase="";//Envase Devolucion Cliente
                                    return;//Envase Devolucion Cliente
                                }//Envase Devolucion Cliente
								obtenerDetallesProducto(oProducto);
								//mostrarUnidades(unidades);
								cboUnidad.setEnabled(false);							
								mVista.getWindow().setSoftInputMode(WindowManager.LayoutParams.SOFT_INPUT_STATE_ALWAYS_VISIBLE );
								unidades.close();
								return;
							}
						}
					}
					mVista.mostrarError(Mensajes.get("E0863"));
					txtScanner.BorrarTexto();

				}
			}
		}
		catch (Exception ex)
		{
			mVista.mostrarError(ex.getMessage());
		}
	}

	public void obtenerDetallesProducto(Producto producto)
	{
		try
		{
			validarProductoContenido(producto);
			lblProDescripcion.setText(producto.Nombre);
			if (manejoDobleUnidad){
				lblProExistencia.setVisibility(View.GONE);
                laySaldoEnvase.setVisibility(View.GONE);
			}else {
				if (tipoValidacionExistencia != TiposValidacionInventario.NoValidar) {
					if (TraspasoInventario) {
						//traspaso de inventario
						lblProExistencia.setText(Mensajes.get("XExist") + ": " + Generales.getFormatoDecimal(Consultas.ConsultasInventario.obtenerExistencia(producto.ProductoClave, ubicacionExistencia), producto.DecimalProducto));
					} else
                        if (tipoTransProd == Enumeradores.TiposTransProd.DESCARGAS && Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO)
                            lblProExistencia.setText(Mensajes.get("XExist") + ": " + Generales.getFormatoDecimal(Consultas.ConsultasInventario.obtenerExistenciaDifNoDisponible(producto.ProductoClave, CadenaListasPrecios), producto.DecimalProducto));
                        else
                            lblProExistencia.setText(Mensajes.get("XExist") + ": " + Generales.getFormatoDecimal(Consultas.ConsultasInventario.obtenerExistencia(producto.ProductoClave, CadenaListasPrecios, mDevolucionesManuales), producto.DecimalProducto));
				} else {
					lblProExistencia.setVisibility(View.GONE);
				}

                //Si es envase que permite venta
                if ((tipoTransProd == Enumeradores.TiposTransProd.PEDIDO || tipoTransProd == Enumeradores.TiposTransProd.VENTA_CONSIGNACION) && Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) != Enumeradores.TiposModulos.PREVENTA) {
                    if (producto.Contenido && producto.Venta) {
                        laySaldoEnvase.setVisibility(View.VISIBLE);
                        lblSaldoEnvase.setText(Mensajes.get("XSaldoEnvase") + ": " + Generales.getFormatoDecimal(Consultas2.ConsultasProductoPrestamoCli.obtenerSaldoEnvase(((Cliente)Sesion.get(Campo.ClienteActual)).ClienteClave, producto.ProductoClave), producto.DecimalProducto));
                    } else
                        laySaldoEnvase.setVisibility(View.GONE);
                }
			}


            ISetDatos unidades = Consultas.ConsultasProducto.obtenerUnidadesProducto(producto.ProductoClave, CadenaListasPrecios, manejoDobleUnidad);
            if (unidades.getCount() <= 0) {
                unidades.close();
                mVista.mostrarError("El producto no tiene unidades definidas");
            } else {
                if (manejoDobleUnidad){
                    mostrarDobleUnidad(unidades);
                }else {
                    mostrarUnidades(unidades);
                }
            }

            if (manejoDobleUnidad) {
				Short decimales = 0;
				if (txtCantidad1.getTag() != null){
					decimales = ((InventarioDobleUnidad.DetalleProductoDobleUnidad) txtCantidad1.getTag()).DecimalProducto;
				}
				if(txtCantidad1 == null)
				{
					txtCantidad1 = (EditText) findViewById(R.id.txtCantidad1);
				}
				if (decimales == 0) {
					txtCantidad1.setInputType(InputType.TYPE_CLASS_NUMBER);
				} else {
					txtCantidad1.setInputType(InputType.TYPE_NUMBER_FLAG_DECIMAL | InputType.TYPE_CLASS_NUMBER);
				}
            }
			
		}
		catch (Exception ex)
		{
			mVista.mostrarError(ex.getMessage().equals("") ? ex.getCause().getMessage() : ex.getMessage());
		}
	}

	@SuppressWarnings("deprecation")
	public void mostrarUnidades(ISetDatos unidades)
	{
		try
		{
			Cursor unidad = (Cursor) unidades.getOriginal();
			mVista.startManagingCursor(unidad);
			SimpleCursorAdapter adapter = new SimpleCursorAdapter(mVista, android.R.layout.simple_spinner_item, unidad, new String[]
			{ "PRUTipoUnidad" }, new int[]
			{ android.R.id.text1 });
			adapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
			adapter.setViewBinder(new vista());
			cboUnidad.setAdapter(adapter);
			if (cboUnidad.getCount() > 0)
			{
				cboUnidad.setSelection(0);
				cboUnidad.setEnabled(true);
				txtCantidad.requestFocus();
			}
            mVista.stopManagingCursor(unidad);
		}
		catch (Exception e)
		{
			mVista.mostrarError(e.getMessage());
		}
	}

    public void mostrarDobleUnidad(ISetDatos unidades)
    {
        try
        {
            LinearLayout lay = (LinearLayout) findViewById(R.id.layDobleUnidad);
            lay.setVisibility(View.VISIBLE);
            //LinearLayout layUnidad2 = (LinearLayout) findViewById(R.id.layUnidad2);
            TextView lblUnidad1 = (TextView) findViewById(R.id.lblUnidad1);
            EditText txtCantidad1 = (EditText) findViewById(R.id.txtCantidad1);
            TextView lblUnidad2 = (TextView) findViewById(R.id.lblUnidad2);
            EditText txtCantidad2 = (EditText) findViewById(R.id.txtCantidad2);

            if (unidades.getCount()==1){
                if (unidades.moveToFirst()) {
                    lblUnidad2.setVisibility(View.GONE);
                    txtCantidad2.setVisibility(View.GONE);
					Float existencia = 0f;
					if (tipoTransProd == Enumeradores.TiposTransProd.DEVOLUCIONES_MANUALES){
						existencia= Consultas.ConsultasInventario.obtenerExistenciaDobleUnidad(oProducto.ProductoClave, unidades.getShort("PRUTipoUnidad"),  InventarioDobleUnidad.TiposInventario.NODISPONIBLE );
					}else{
						existencia =Consultas.ConsultasInventario.obtenerExistenciaDobleUnidad(oProducto.ProductoClave, unidades.getShort("PRUTipoUnidad"),  InventarioDobleUnidad.TiposInventario.DISPONIBLE );
					}
					if (tipoValidacionExistencia != TiposValidacionInventario.NoValidar) {
						lblUnidad1.setText(ValoresReferencia.getDescripcion("UNIDADV", unidades.getString("PRUTipoUnidad")) + "(" + Generales.getFormatoDecimal(existencia, "#,##0.#####") + ")");
					}else {
						lblUnidad1.setText(ValoresReferencia.getDescripcion("UNIDADV", unidades.getString("PRUTipoUnidad")));
					}
					txtCantidad1.setTag(new InventarioDobleUnidad.DetalleProductoDobleUnidad(unidades.getShort("PRUTipoUnidad"),unidades.getFloat("KgLts"),null, null, unidades.getShort("TipoEstado"), unidades.getShort("DecimalProducto"), unidades.getFloat("PorcentajeVariacion")));
                    //txtCantidad1.setTag(  + "|" +  + "|" +  + "|" +   );
					if (unidades.getShort("DecimalProducto") == 0){
						txtCantidad1.setInputType(InputType.TYPE_CLASS_NUMBER);
					}else{
						txtCantidad1.setInputType(InputType.TYPE_NUMBER_FLAG_DECIMAL|InputType.TYPE_CLASS_NUMBER);
					}
					txtCantidad1.requestFocus();
                }
            }else if (unidades.getCount()>1){
                if (unidades.moveToFirst()) {
                    lblUnidad2.setVisibility(View.VISIBLE);
                    txtCantidad2.setVisibility(View.VISIBLE);
					Float existencia = 0f;
					if (tipoTransProd == Enumeradores.TiposTransProd.DEVOLUCIONES_MANUALES){
						existencia = Consultas.ConsultasInventario.obtenerExistenciaDobleUnidad(oProducto.ProductoClave, unidades.getShort("PRUTipoUnidad"),  InventarioDobleUnidad.TiposInventario.NODISPONIBLE );
					}else{
						existencia =  Consultas.ConsultasInventario.obtenerExistenciaDobleUnidad(oProducto.ProductoClave, unidades.getShort("PRUTipoUnidad"),  InventarioDobleUnidad.TiposInventario.DISPONIBLE );
					}
					if (tipoValidacionExistencia != TiposValidacionInventario.NoValidar) {
						lblUnidad1.setText(ValoresReferencia.getDescripcion("UNIDADV", unidades.getString("PRUTipoUnidad")) + "(" + Generales.getFormatoDecimal(existencia,"#,##0.#####") + ")");
					}else{
						lblUnidad1.setText(ValoresReferencia.getDescripcion("UNIDADV", unidades.getString("PRUTipoUnidad")));
					}
					txtCantidad1.setTag(new InventarioDobleUnidad.DetalleProductoDobleUnidad(unidades.getShort("PRUTipoUnidad"),unidades.getFloat("KgLts"),null, null, unidades.getShort("TipoEstado"), unidades.getShort("DecimalProducto"), unidades.getFloat("PorcentajeVariacion")));
					if (unidades.getShort("DecimalProducto") == 0){
						txtCantidad1.setInputType(InputType.TYPE_CLASS_NUMBER);
					}else{
						txtCantidad1.setInputType(InputType.TYPE_NUMBER_FLAG_DECIMAL|InputType.TYPE_CLASS_NUMBER);
					}

					if (((MOTConfiguracion)Sesion.get(Campo.MOTConfiguracion)).get("ModificarUnidadAlterna").equals(unidades.getString("PRUTipoUnidad"))){
						txtCantidad1.setEnabled(false);
					}

                    if (unidades.moveToNext()){
						if (tipoTransProd == Enumeradores.TiposTransProd.DEVOLUCIONES_MANUALES){
							existencia = Consultas.ConsultasInventario.obtenerExistenciaDobleUnidad(oProducto.ProductoClave, unidades.getShort("PRUTipoUnidad"),  InventarioDobleUnidad.TiposInventario.NODISPONIBLE);
						}else{
							existencia = Consultas.ConsultasInventario.obtenerExistenciaDobleUnidad(oProducto.ProductoClave, unidades.getShort("PRUTipoUnidad"),  InventarioDobleUnidad.TiposInventario.DISPONIBLE );
						}
						if (tipoValidacionExistencia != TiposValidacionInventario.NoValidar) {
							lblUnidad2.setText(ValoresReferencia.getDescripcion("UNIDADV", unidades.getString("PRUTipoUnidad")) + "(" + Generales.getFormatoDecimal(existencia,"#,##0.#####") + ")");
						}else {
							lblUnidad2.setText(ValoresReferencia.getDescripcion("UNIDADV", unidades.getString("PRUTipoUnidad")));
						}
                        /*Tag compuesto por PRUTipoUnidad|DecimalProducto|Factor|TipoEstado*/
						txtCantidad2.setTag(new InventarioDobleUnidad.DetalleProductoDobleUnidad(unidades.getShort("PRUTipoUnidad"),unidades.getFloat("KgLts"),null, null, unidades.getShort("TipoEstado"), unidades.getShort("DecimalProducto"), unidades.getFloat("PorcentajeVariacion")));
						if (((MOTConfiguracion)Sesion.get(Campo.MOTConfiguracion)).get("ModificarUnidadAlterna").equals(unidades.getString("PRUTipoUnidad"))){
							txtCantidad2.setEnabled(false);
						}
						if (unidades.getShort("DecimalProducto") == 0){
							txtCantidad2.setInputType(InputType.TYPE_CLASS_NUMBER);
						}else{
							txtCantidad2.setInputType(InputType.TYPE_NUMBER_FLAG_DECIMAL|InputType.TYPE_CLASS_NUMBER);
						}
					}
					txtCantidad1.requestFocus();
                }
            }
            unidades.close();

        }
        catch (Exception e)
        {
            mVista.mostrarError(e.getMessage());
        }
    }

	public boolean validarProductoContenido(Producto producto) throws Exception
	{
		if (producto.Contenido && !producto.Venta)
		{
			throw new ControlError("E0725");
		}
		return true;
	}

	public boolean validarCaptura()
	{
		if (oProducto == null)
		{
			mVista.mostrarError(Mensajes.get("BE0001", Mensajes.get("XProducto")));
			txtScanner.requestFocus();
			return false;
		}
		if (manejoDobleUnidad){
			if (txtCantidad1.getText().toString().trim().equals("")) {
				TextView lblUnidad1 = (TextView) findViewById(R.id.lblUnidad1);
				mVista.mostrarError(Mensajes.get("BE0001", lblUnidad1.getText().toString()));
				txtCantidad1.requestFocus();
				return false;
			}
			if (txtCantidad2.isShown() && txtCantidad2.getText().toString().trim().equals("")) {
				TextView lblUnidad2 = (TextView) findViewById(R.id.lblUnidad2);
				mVista.mostrarError(Mensajes.get("BE0001", lblUnidad2.getText().toString()));
				txtCantidad2.requestFocus();
				return false;
			}
			if (tipoTransProd != Enumeradores.TiposTransProd.DESCARGAS && tipoTransProd != Enumeradores.TiposTransProd.DEVOLUCIONES_MANUALES){
				String sValores = ValoresReferencia.getStringVAVClave("UNIDADV", "VARIABLE");
				if (txtCantidad2.isShown() && sValores !=null && sValores.length()>0){
					String[] aValoresXRef = sValores.split(",");
					if (((InventarioDobleUnidad.DetalleProductoDobleUnidad)txtCantidad1.getTag()).PRUTipoUnidad == Short.parseShort(String.valueOf(aValoresXRef[0]))){
						Float cantidadCalculada = ((InventarioDobleUnidad.DetalleProductoDobleUnidad)txtCantidad2.getTag()).KgLts * Float.parseFloat(txtCantidad2.getText().toString());
						Float variacionKilos = (cantidadCalculada * ((InventarioDobleUnidad.DetalleProductoDobleUnidad)txtCantidad1.getTag()).PorcentajeVariacion) / 100;
						int decimales = ((InventarioDobleUnidad.DetalleProductoDobleUnidad)txtCantidad1.getTag()).DecimalProducto;
						if ((Generales.getRound(Float.parseFloat(txtCantidad1.getText().toString()),decimales) >   Generales.getRound(cantidadCalculada + variacionKilos,decimales)) || (Generales.getRound(Float.parseFloat(txtCantidad1.getText().toString()),decimales) <   Generales.getRound(cantidadCalculada - variacionKilos,decimales)) ){
							mVista.mostrarError(Mensajes.get("E0957"));
							txtCantidad1.requestFocus();
							return false;
						}
					}else if (((InventarioDobleUnidad.DetalleProductoDobleUnidad)txtCantidad2.getTag()).PRUTipoUnidad == Short.parseShort(String.valueOf(aValoresXRef[0]))){
						Float cantidadCalculada = ((InventarioDobleUnidad.DetalleProductoDobleUnidad)txtCantidad1.getTag()).KgLts * Float.parseFloat(txtCantidad1.getText().toString());
						Float variacionKilos = (cantidadCalculada * ((InventarioDobleUnidad.DetalleProductoDobleUnidad)txtCantidad2.getTag()).PorcentajeVariacion) / 100;
						int decimales = ((InventarioDobleUnidad.DetalleProductoDobleUnidad)txtCantidad2.getTag()).DecimalProducto;
						if ((Generales.getRound(Float.parseFloat(txtCantidad2.getText().toString()), decimales ) >   Generales.getRound(cantidadCalculada + variacionKilos, decimales)) || (Generales.getRound(Float.parseFloat(txtCantidad2.getText().toString()), decimales) <   Generales.getRound(cantidadCalculada - variacionKilos,decimales)) ){
							mVista.mostrarError(Mensajes.get("E0957"));
							txtCantidad2.requestFocus();
							return false;
						}
					}
				}
			}
		}else {
			if (cboUnidad.getSelectedItemPosition() < 0) {
				mVista.mostrarError(Mensajes.get("BE0001", Mensajes.get("XUnidad")));
				cboUnidad.requestFocus();
				return false;
			}
			if (txtCantidad.getText().toString().trim().equals("")) {
				mVista.mostrarError(Mensajes.get("BE0001", Mensajes.get("XCantidad")));
				txtCantidad.requestFocus();
				return false;
			}

			if (tipoTransProd == Enumeradores.TiposTransProd.PEDIDO || tipoTransProd == Enumeradores.TiposTransProd.MOV_SIN_INV_EV) {
				try {
					if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("ValidarVtaMultiplo").length() > 0) {
						if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("ValidarVtaMultiplo").equals("1")) {
							if (oProducto.CantidadProduccion > 0) {
								if ((Float.parseFloat(Generales.getFormatoDecimal(Float.parseFloat(txtCantidad.getText().toString()), oProducto.DecimalProducto)) % oProducto.CantidadProduccion) != 0) {
									mVista.mostrarError(Mensajes.get("E0935", String.valueOf(oProducto.CantidadProduccion)));
									txtCantidad.requestFocus();
									return false;
								}
							}
						}
					}
				} catch (Exception ex) {
					mVista.mostrarError(ex.getMessage());
					return false;
				}

			}
		}

		return true;
	}

	private class vista implements ViewBinder
	{
		@Override
		public boolean setViewValue(View view, Cursor cursor, int columnIndex)
		{
			int viewId = view.getId();
			switch (viewId)
			{
				case android.R.id.text1: // para llenar el combo de la unidad
					TextView combo = (TextView) view;
					Log.e("", ValoresReferencia.getDescripcion("UNIDADV", cursor.getString(cursor.getColumnIndex("PRUTipoUnidad"))));
					combo.setText(ValoresReferencia.getDescripcion("UNIDADV", cursor.getString(cursor.getColumnIndex("PRUTipoUnidad"))));
					break;
				default:
					TextView texto = (TextView) view;
					texto.setText(cursor.getString(columnIndex));
					break;
			}
			return true;
		}
	}

	public String getCantidad()
	{
		return txtCantidad.getText().toString();
	}

	private OnClickListener mAgregarProducto = new OnClickListener()
	{
		@Override
		public void onClick(View v)
		{
			// solo se dispara el listener cuando esta el producto capturado y
			// tiene cantidad > 0
			if (agregarListener == null)
				return;
			// if(agregarListener != null && oProducto != null &&
			// !txtCantidad.getText().toString().equals("")){
			if (validarCaptura())
			{
				//permitir capturar cero en reparto, ya que la opcion de eliminar no existe, se eliminan con cero
				if (Float.parseFloat(txtCantidad.getText().toString()) > 0 || (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO && Float.parseFloat(txtCantidad.getText().toString()) == 0 && tipoTransProd == 1 && surtir ))
				{
					//ajustar la cantidad capturada al numero de decimales configurados para el producto
					float cantidad = Float.parseFloat(Generales.getFormatoDecimal(Float.parseFloat(txtCantidad.getText().toString()), oProducto.DecimalProducto));
					agregarListener.onAgregarProducto(oProducto, Short.parseShort(String.valueOf(cboUnidad.getSelectedItemId())), cantidad);
					//agregarListener.onAgregarProducto(oProducto, Integer.parseInt(String.valueOf(cboUnidad.getSelectedItemId())), Float.parseFloat(txtCantidad.getText().toString()));
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
				else
				{
					mVista.mostrarError(Mensajes.get("E0012"));
				}
			}
		}
	};

	private OnClickListener mAgregarProductoDobleUnidad = new OnClickListener()
	{
		@Override
		public void onClick(View v)
		{
			// solo se dispara el listener cuando esta el producto capturado y
			// tiene cantidad > 0
			if (agregarDobleUnidadListener == null)
				return;

			try {
				if(txtCantidad1.hasFocus()) {
					txtCantidad1.clearFocus();
				}
				btnAgregar.requestFocus();
				if (validarCaptura()) {
					boolean cantidadesValidas = false;
					//permitir capturar cero en reparto, ya que la opcion de eliminar no existe, se eliminan con cero
					if(tipoTransProd == Enumeradores.TiposTransProd.DESCARGAS || tipoTransProd == Enumeradores.TiposTransProd.DEVOLUCIONES_MANUALES){
						if(Float.parseFloat(txtCantidad1.getText().toString()) > 0 || (txtCantidad2.isShown() && Float.parseFloat(txtCantidad2.getText().toString()) > 0 )){
							cantidadesValidas = true;
						}
					}else if ((Float.parseFloat(txtCantidad1.getText().toString()) > 0 || (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO && Float.parseFloat(txtCantidad1.getText().toString()) == 0 && tipoTransProd == 1 && surtir)) &&
							(!txtCantidad2.isShown() || Float.parseFloat(txtCantidad2.getText().toString()) > 0 || (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO && Float.parseFloat(txtCantidad2.getText().toString()) == 0 && tipoTransProd == 1 && surtir))) {
						cantidadesValidas = true;
					}

					if(!cantidadesValidas){
						mVista.mostrarError(Mensajes.get("E0012"));
						return;
					}

					//ajustar la cantidad capturada al numero de decimales configurados para el producto
					HashMap<Short, InventarioDobleUnidad.DetalleProductoDobleUnidad> hmDetalleUnidades = new HashMap<Short, InventarioDobleUnidad.DetalleProductoDobleUnidad>();

					InventarioDobleUnidad.DetalleProductoDobleUnidad Cant1 = (InventarioDobleUnidad.DetalleProductoDobleUnidad) txtCantidad1.getTag();
					Cant1.Cantidad = Generales.getRound(Float.parseFloat(txtCantidad1.getText().toString()), Cant1.DecimalProducto);
					hmDetalleUnidades.put(Cant1.PRUTipoUnidad,Cant1);

					if(txtCantidad2.isShown()) {
						InventarioDobleUnidad.DetalleProductoDobleUnidad Cant2 = (InventarioDobleUnidad.DetalleProductoDobleUnidad) txtCantidad2.getTag();
						Cant2.Cantidad = Generales.getRound(Float.parseFloat(txtCantidad2.getText().toString()), Cant2.DecimalProducto);
						hmDetalleUnidades.put(Cant2.PRUTipoUnidad, Cant2);
					}

					agregarDobleUnidadListener.onAgregarProdDobleUnidad(oProducto, hmDetalleUnidades);
					if (error == "") {
						limpiarProducto();
					} else {
						mVista.mostrarError(error);
						error = "";
						if (bAdvertencia) {
							limpiarProducto();
							bAdvertencia = false;
						}
					}
				}
			}catch (Exception ex){
				if (ex!=null && ex.getMessage() != null) {
					mVista.mostrarError(ex.getMessage());
				}else{
					mVista.mostrarError("Error al agregar Producto");
				}

			}
		}
	};
	// ***************************** listener para agregar producto
	// **************************************
	public interface onAgregarProductoListener
	{
		void onAgregarProducto(Producto producto, int tipoUnidad, float cantidad);
	}

	private onAgregarProductoListener agregarListener = null;

	public void setOnAgregarProductoListener(onAgregarProductoListener l)
	{
		agregarListener = l;
	}

	// ***************************** listener para agregar producto con doble unidad
	// **************************************
	public interface onAgregarProdDobleUnidadListener
	{
		void onAgregarProdDobleUnidad(Producto producto, HashMap<Short, InventarioDobleUnidad.DetalleProductoDobleUnidad> hmDetalleUnidades);
	}

	private onAgregarProdDobleUnidadListener agregarDobleUnidadListener = null;

	public void setOnAgregarProdDobleUnidadListener(onAgregarProdDobleUnidadListener l)
	{
		agregarDobleUnidadListener = l;
	}

	// ***************************************************************************************************

	// ***************************** listener para buscar producto
	// ***************************************
	public interface onProductoNoEncontradoListener
	{
		void onProductoNoEncontrado();
	}

	private onProductoNoEncontradoListener buscarListener = null;

	public void setOnProductoNoEncontradoListener(onProductoNoEncontradoListener l)
	{
		buscarListener = l;
	}
    
	public String ValidarSoloEnvase(Producto producto){//Envase Devolucion Cliente
        MOTConfiguracion motConfig = (MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion);
        //Log.i(null, "pasa 1 transprod: "+tipoTransProd);

        if (oProducto != null){
            //Log.i(null,Integer.parseInt(Sesion.get(Campo.TipoModulo).toString())+" == "+TiposModulos.REPARTO );
            //Log.i(null,Enumeradores.TiposTransProd.PEDIDO+" == "+tipoTransProd);
            if (tipoTransProd == Enumeradores.TiposTransProd.PEDIDO  && Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO){
                if (motConfig.get("SoloVentaEnvase").equals("1") && !producto.Contenido && !producto.Venta){
                    bSoloEnvase = true;
                    //return Mensajes.get("E0907");
                    return "E0907";
                }
            }
            else if(tipoTransProd == Enumeradores.TiposTransProd.DEVOLUCIONES_CLIENTE ){
                if (motConfig.get("RecoleccionEnvase").equals("1") && !producto.Contenido){
                    bSoloEnvase=true;
                    //return Mensajes.get("E0773").replace("$0$","Envase");
                    return "E0773";
                }
            }
        }
        return "";
	}

    public void setEnableCantidadAgregar(boolean habilita)
	{
    	txtCantidad.setEnabled(habilita);
    	btnAgregar.setEnabled(habilita);
    }

    public void IngresaProductoBusquedaSimple (String sProductoClave){
        try{
            if (sProductoClave != null){
				if(!sProductoClave.equals("")) {
					bMostrandoBusqueda = false;
					oProducto = Consultas.ConsultasProducto.obtenerProductoIdentico(sProductoClave);
					obtenerDetallesProducto(oProducto);
				}
            }
        }catch (Exception ex){
            mVista.mostrarError(ex.getMessage());
        }
    }
}

