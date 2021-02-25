package com.amesol.routelite.vistas;

import android.app.SearchManager;
import android.content.Intent;
import android.database.Cursor;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.graphics.Matrix;
import android.net.Uri;
import android.os.Bundle;
import android.os.Environment;
import android.os.StrictMode;
import android.provider.MediaStore;
import android.text.Editable;
import android.text.TextWatcher;
import android.util.Log;
import android.view.KeyEvent;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.AdapterView;
import android.widget.AdapterView.OnItemSelectedListener;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ImageView;
import android.widget.SimpleCursorAdapter;
import android.widget.Spinner;
import android.widget.TextView;

import com.amesol.routelite.R;
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.datos.Cliente;
import com.amesol.routelite.datos.Dia;
import com.amesol.routelite.datos.Ruta;
import com.amesol.routelite.datos.Visita;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.ConfigParametro;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.Enumeradores.RespuestaMsg;
import com.amesol.routelite.presentadores.act.NoVisitarCliente;
import com.amesol.routelite.presentadores.interfaces.IAtencionClientes;
import com.amesol.routelite.presentadores.interfaces.INoVisitaCliente;
import com.amesol.routelite.utilerias.ControlError;
import com.amesol.routelite.utilerias.Generales;
import com.amesol.routelite.vistas.utilerias.ExifUtils;

import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.IOException;
import java.text.SimpleDateFormat;
import java.util.Date;

public class NoVisitaCliente extends Vista implements INoVisitaCliente
{

	private NoVisitarCliente mPresenta;
	private String mAccion;
	private Cliente cliente;
	private Dia dia;
	private Ruta ruta;
	private boolean salir;
	private boolean huboCambios;
	private boolean cargando;
    boolean imprimiendo;
    boolean errorFinalizar = false;
    ImageView ibFotos;

    private final String ruta_fotos = Environment.getExternalStoragePublicDirectory("routelite") + "/ImagenImproductividad/";
    private File file = new File(ruta_fotos);
    String fileFoto;
    String fileFotoTmp;
    String tituloFoto;
    boolean tomoFoto;
    boolean tomandoFoto = false;
    //boolean borrarImagen = true;

	@Override
	public void onCreate(Bundle savedInstanceState)
	{
        StrictMode.VmPolicy.Builder builder = new StrictMode.VmPolicy.Builder(); StrictMode.setVmPolicy(builder.build());
		try
		{
			super.onCreate(savedInstanceState);
			setContentView(R.layout.no_visitar_cliente);
			deshabilitarBarra(true);
			mAccion = getIntent().getAction();

			cargando = true;

			cliente = (Cliente) Sesion.get(Campo.ClienteActual);

			dia = (Dia) Sesion.get(Campo.DiaActual);
			ruta = (Ruta) Sesion.get(Campo.RutaActual);
			TextView texto = (TextView) findViewById(R.id.lblMotivoNoVisita);
            //TextView lblImagen = (TextView)findViewById(R.id.lblImagen);
            ibFotos = (ImageView)findViewById(R.id.ibFotos);
			if (mAccion.equals(Enumeradores.Acciones.ACCION_NO_VISITAR_CLIENTE))
			{
				setTitulo(Mensajes.get("XNoVisitar"));
				texto.setText(Mensajes.get("XMotivoNoVisita"));
                ibFotos.setVisibility(View.GONE);
                //lblImagen.setVisibility(View.GONE);
			}
			else if (mAccion.equals(Enumeradores.Acciones.ACCION_NO_VENTA))
			{
				setTitulo("No Venta");
				texto.setText(Mensajes.get("XMotivosVenta"));
                ibFotos.setVisibility(View.VISIBLE);
                //lblImagen.setVisibility(View.VISIBLE);
                //lblImagen.setText(Mensajes.get("XImagenEvidencia"));
                ibFotos.setOnClickListener(mTomarFoto);
			}

			texto = (TextView) findViewById(R.id.lblComentarios);
			texto.setText(Mensajes.get("XComentarios"));

			texto = (TextView) findViewById(R.id.lblCliente);
			texto.setText(cliente.Clave + " - " + cliente.RazonSocial);
			texto = (TextView) findViewById(R.id.lblRuta);
			texto.setText(Mensajes.get("XRuta") + ": " + ruta.Descripcion);
			texto = (TextView) findViewById(R.id.lblDia);
			texto.setText(Mensajes.get("XDiaTrabajo") + ": " + dia.DiaClave);

			Button btn = (Button) findViewById(R.id.btnContinuar);
			btn.setText(Mensajes.get("BTContinuar"));
			btn.setOnClickListener(mContinuar);

			EditText text = (EditText) findViewById(R.id.txtComentarios);
			text.addTextChangedListener(mComentarios);
			Spinner spin = (Spinner) findViewById(R.id.cmbMotivoNoVisita);
			spin.setOnItemSelectedListener(mMotivo);

			salir = false;
			huboCambios = false;

			mPresenta = new NoVisitarCliente(this, mAccion);
			mPresenta.iniciar();
            cargando = false;

            //if (mAccion.equals(Enumeradores.Acciones.ACCION_NO_VENTA))
            //    tomarFoto();
		}
		catch (Exception e)
		{
			mostrarError(e.getMessage());
			e.printStackTrace();
		}
	}

	@Override
	public boolean onKeyDown(int keyCode, KeyEvent event)
	{
		switch (keyCode)
		{
			case KeyEvent.KEYCODE_BACK:
                if (!getImprimiendo()) {
                    if (huboCambios)
                        mostrarPregunta();
                    else {
                        if (fileFoto != null && fileFoto != "") {
                            File fotito = new File(fileFoto);
                            if (fotito.exists()) {
                                fotito.delete();
                                tituloFoto = "";
                            }
                        }

                        this.finish();
                        if (mAccion.equals(Enumeradores.Acciones.ACCION_NO_VISITAR_CLIENTE))
                            iniciarActividad(IAtencionClientes.class, false);
                    }
                }
				return true;
		}
		return super.onKeyDown(keyCode, event);
	}

	private OnClickListener mContinuar = new OnClickListener()
	{
		public void onClick(View v)
		{
            if (Validar()) {
                try {
                    if ((mAccion != null)) {

                        //mPresenta.mContinuar();
                        if (mAccion.equals(Enumeradores.Acciones.ACCION_NO_VISITAR_CLIENTE)) {
                            mPresenta.mContinuar();
                            if (!mPresenta.imprimir()) {
                                setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
                                finalizar();
                                iniciarActividad(IAtencionClientes.class, false);
                            }
                        } else {
                            mPresenta.mContinuar();
                            if (!mPresenta.imprimir()) {
                                setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
                                finalizar();
                            }
                        }

                    }
                } catch (Exception e) {
                    mostrarError(e.getMessage());
                    e.printStackTrace();
                }
            }
		}
	};

    private boolean Validar(){
        if (getMotivoNoVisita() == -1)
        {
            mostrarMensajeRequerido();
            return false;
        }
        else
            return true;
    }

	private TextWatcher mComentarios = new TextWatcher()
	{
		public void afterTextChanged(Editable arg0)
		{
		}

		public void beforeTextChanged(CharSequence arg0, int arg1, int arg2, int arg3)
		{
		}

		public void onTextChanged(CharSequence arg0, int arg1, int arg2, int arg3)
		{
            if (!cargando)
                huboCambios = true;
		}
	};

	private OnItemSelectedListener mMotivo = new OnItemSelectedListener()
	{

		public void onItemSelected(AdapterView<?> arg0, View arg1, int arg2, long arg3)
		{
			if (!cargando && arg3 != -1)
				huboCambios = true;
		}

		public void onNothingSelected(AdapterView<?> arg0)
		{
		}
	};

	private void mostrarPregunta()
	{
		salir = true;
		mostrarPreguntaSiNo(Mensajes.get("BP0002"), 1);
	}

	public void iniciar()
	{
	}

    private View.OnClickListener mTomarFoto = new View.OnClickListener()
    {
        @Override
        public void onClick(View v)
        {
            tomarFoto();
        }
    };

    private void tomarFoto(){
        //si no existe crea la carpeta donde se guardaran las fotos
        file.mkdir();
            /* Tomamos la fecha para agregarla al titulo de la foto */
        //SimpleDateFormat formatoFecha = new SimpleDateFormat("yyyyMMddhhmmss");
        SimpleDateFormat formatoFecha = new SimpleDateFormat("yyyy-MM-dd'T'HH-mm");
        //String fecha = formatoFecha.format(((Dia) Sesion.get(Campo.DiaActual)).FechaCaptura);
        String fecha = formatoFecha.format(Generales.getFechaHoraActual());
        //tituloFoto = ((Visita) Sesion.get(Campo.VisitaActual)).VisitaClave + "_" + fecha;
        tituloFoto = cliente.Clave + "_" + fecha + "_"+ ((Visita) Sesion.get(Campo.VisitaActual)).VisitaClave;
        fileFoto = ruta_fotos + tituloFoto + ".jpg";
        fileFotoTmp = ruta_fotos + tituloFoto + "_tmp.jpg";
        File foto = new File(fileFotoTmp);

        try
        {
            if (foto.exists())
                foto.delete();
            foto.createNewFile();
        }
        catch (IOException e)
        {
            // TODO Auto-generated catch block
            Log.e("ERROR ", "Error:" + e);
        }

        tomandoFoto = true;
        //borrarImagen = true;
        Uri uri = Uri.fromFile(foto);
        Intent camaraIntent = new Intent(MediaStore.ACTION_IMAGE_CAPTURE);
        camaraIntent.putExtra(MediaStore.EXTRA_OUTPUT, uri);
        startActivityForResult(camaraIntent, 1);
    }

    public void setImagen(String idImagen){
        tituloFoto = idImagen;
        String imagen = ruta_fotos + tituloFoto + ".jpg";

        Bitmap bmap = ExifUtils.decodeFile(imagen);
        //Bitmap bmap = BitmapFactory.decodeFile(imagen);
        ibFotos.setImageBitmap(bmap);
        tomoFoto = true;
        //borrarImagen = false;
    }

	@Override
	public void resultadoActividad(int requestCode, int resultCode, Intent data)
	{
        try{
            if (requestCode == REQUEST_ENABLE_BT){
                if (resultCode == RESULT_OK){
                    try{
                        imprimiendo = true;
                        mPresenta.imprimirTicket();
                    }catch (ControlError e){
                        e.Mostrar(getVista());
                    }catch (Exception e){
                        getVista().mostrarError(e.getMessage());
                    }
                }else{
                    mostrarError("No se pudo encender el BT");
                }
                return;
            }
            else if (tomandoFoto) {
                tomandoFoto = false;
                if (requestCode == 1 && resultCode == RESULT_OK) {
                    Bitmap bmap = ExifUtils.decodeFile(fileFotoTmp);
                    //Bitmap bmap = BitmapFactory.decodeFile(fileFoto);
                    //Bitmap map = redimensionarImagenMaximo(bmap, bmap.getWidth() / 2, bmap.getHeight() / 2);

                    ibFotos.setImageBitmap(bmap);
                    tomoFoto = true;
                    huboCambios = true;

                    File foto1 = new File(fileFotoTmp);
                    foto1.delete();

                    FileOutputStream fos = null;
                    try {
                        fos = new FileOutputStream(fileFoto);
                        bmap.compress(Bitmap.CompressFormat.JPEG, 100, fos);
                        fos.flush();
                    } catch (FileNotFoundException ex) {
                        ex.printStackTrace();
                    } catch (IOException ex) {
                        ex.printStackTrace();
                    }
                } else {
                    if (fileFotoTmp != "") {
                        File fotito = new File(fileFotoTmp);
                        fotito.delete();
                        if (!tomoFoto)
                            tituloFoto = "";
                    }
                    //finish();
                }
            }
        }catch (Exception ex){
            mostrarError(ex.getMessage());
        }
	}

    public Bitmap redimensionarImagenMaximo(Bitmap mBitmap, float newWidth, float newHeigth)
    { //este metodo se utiliza para bajar la resolucion de la foto
        //Redimensionamos
        int width = mBitmap.getWidth();
        int height = mBitmap.getHeight();
        float scaleWidth = ((float) newWidth) / width;
        float scaleHeight = ((float) newHeigth) / height;
        // creamos una matrix para la manipulacion
        Matrix matrix = new Matrix();
        // mandamos el nuevo tamaño
        matrix.postScale(scaleWidth, scaleHeight);
        // creamo un nuevo bitmap
        return Bitmap.createBitmap(mBitmap, 0, 0, width, height, matrix, false);
    }

	@Override
	public void respuestaMensaje(RespuestaMsg respuesta, int tipoMensaje)
	{
        if (tipoMensaje == 1){
		    if ((respuesta.equals(RespuestaMsg.Si)) && salir)
		    {
			    this.finish();
			    if (mAccion.equals(Enumeradores.Acciones.ACCION_NO_VISITAR_CLIENTE))
				    iniciarActividad(IAtencionClientes.class, false);
		    }
        }else if (tipoMensaje == 2){
            if (respuesta.equals(RespuestaMsg.Si)){
                //Imprimir ticket
                try{
                    if (!bluetoothEncendido()){
                        encenderBluetooth();
                    }
                    else{
                        imprimiendo = true;
                        mPresenta.imprimirTicket();
                    }
                    //getVista().mostrarAdvertencia("Recibos generados");
                }
                catch (ControlError e){
                    e.Mostrar(getVista());
                }
                catch (Exception e){
                    getVista().mostrarError(e.getMessage());
                }
            }
            else{
                setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
                finalizar();
                if (mAccion.equals(Enumeradores.Acciones.ACCION_NO_VISITAR_CLIENTE)) {
                    iniciarActividad(IAtencionClientes.class, false);
                }
            }
        }else if (tipoMensaje == 0 && imprimiendo){
            setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
            finalizar();
            if (mAccion.equals(Enumeradores.Acciones.ACCION_NO_VISITAR_CLIENTE)) {
                iniciarActividad(IAtencionClientes.class, false);
            }
        }else if(tipoMensaje == 0 && errorFinalizar){
            finalizar();
            if (mAccion.equals(Enumeradores.Acciones.ACCION_NO_VISITAR_CLIENTE)) {
                iniciarActividad(IAtencionClientes.class, false);
            }
        }else if (tipoMensaje == 0){
            setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
            finalizar();
            if (mAccion.equals(Enumeradores.Acciones.ACCION_NO_VISITAR_CLIENTE)) {
                iniciarActividad(IAtencionClientes.class, false);
            }
        }
	}

	@SuppressWarnings("deprecation")
	public void mostrarMotivosNoVisita(String Grupo)
	{
		try
		{
			ISetDatos vis = Consultas.ConsultasValorReferencia.obtenerValoresPorGrupo("MOTIMPRO", Grupo, Mensajes.get("XSeleccionar", new String[]
			{ Mensajes.get("XMotivo") }), false);
			Cursor valores = (Cursor) vis.getOriginal();
			startManagingCursor(valores);
			Spinner s = (Spinner) findViewById(R.id.cmbMotivoNoVisita);
			SimpleCursorAdapter adapter = new SimpleCursorAdapter(this, android.R.layout.simple_spinner_item, valores,
					new String[]
					{ SearchManager.SUGGEST_COLUMN_TEXT_1 },
					new int[]
					{ android.R.id.text1 });
			adapter.setDropDownViewResource(android.R.layout.simple_spinner_item);
			s.setAdapter(adapter);
			//cargando = false;
		}
		catch (Exception e)
		{
			mostrarError(e.getMessage());
			e.printStackTrace();
		}
	}

	public short getMotivoNoVisita()
	{
		Spinner spin = (Spinner) findViewById(R.id.cmbMotivoNoVisita);
		return (short) spin.getSelectedItemId();
	}

    public void setMotivoNoVisita(short tipoMotivo){
        Spinner spin = (Spinner) findViewById(R.id.cmbMotivoNoVisita);
        Generales.SelectSpinnerItemByValue(spin, (long)tipoMotivo);
    }

	public String getComentario()
	{
		EditText texto = (EditText) findViewById(R.id.txtComentarios);
		return texto.getText().toString().trim();
	}

    public void setComentario(String comentario){
        EditText texto = (EditText) findViewById(R.id.txtComentarios);
        texto.setText(comentario);
    }

    public String getIdImagen(){
        return tituloFoto;
    }

	public void mostrarMensajeRequerido()
	{
		TextView texto = (TextView) findViewById(R.id.lblMotivoNoVisita);
		mostrarError(Mensajes.get("BE0001", new String[]
		{ texto.getText().toString() }), 3);
	}

    private Vista getVista()
    {
        return this;
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
            if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).existeParametro("NumImpresiones", Sesion.get(Campo.ModuloMovDetalleClave).toString())) {
                if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("NumImpresiones", Sesion.get(Campo.ModuloMovDetalleClave).toString()).equals("0")) {
                    mostrarPreguntaSiNo(Mensajes.get("P0103"), 2);
                } else {
                    finalizar();
                    if (mAccion.equals(Enumeradores.Acciones.ACCION_NO_VISITAR_CLIENTE)) {
                        iniciarActividad(IAtencionClientes.class, false);
                    }
                }
            } else {
                mostrarPreguntaSiNo(Mensajes.get("P0103"), 2);
            }
        }catch(Exception ex){
            mostrarPreguntaSiNo(Mensajes.get("P0103"), 2);
        }
    }
}
