package com.amesol.routelite.vistas;

import android.app.DatePickerDialog;
import android.app.Dialog;
import android.app.SearchManager;
import android.content.Intent;
import android.database.Cursor;
import android.graphics.Bitmap;
import android.net.Uri;
import android.os.Bundle;
import android.os.Environment;
import android.os.StrictMode;
import android.provider.MediaStore;
import android.text.InputType;
import android.util.Log;
import android.view.KeyEvent;
import android.view.View;
import android.widget.AdapterView;
import android.widget.Button;
import android.widget.DatePicker;
import android.widget.EditText;
import android.widget.ImageButton;
import android.widget.ImageView;
import android.widget.SimpleCursorAdapter;
import android.widget.Spinner;
import android.widget.TextView;

import com.amesol.routelite.R;
import com.amesol.routelite.actividades.Mensajes;

import com.amesol.routelite.datos.Dia;
import com.amesol.routelite.datos.MERDetalle;
import com.amesol.routelite.datos.Visita;
import com.amesol.routelite.datos.annotations.Campo;
import com.amesol.routelite.datos.basedatos.BDVend;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.act.CapturarActivo;
import com.amesol.routelite.presentadores.act.CapturarMercadeo;
import com.amesol.routelite.presentadores.interfaces.ICapturaActivo;
import com.amesol.routelite.presentadores.interfaces.ICapturaMercadeo;
import com.amesol.routelite.utilerias.ControlError;
import com.amesol.routelite.utilerias.Generales;
import com.amesol.routelite.vistas.utilerias.ExifUtils;

import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.IOException;
import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.Date;
import java.util.HashMap;

public class CapturaActivo extends Vista implements ICapturaActivo {
    String mAccion;
    CapturarActivo mPresenta;

    Boolean modificando = false;

    EditText txtIdElectronico;
    EditText txtAltura;
    EditText txtAncho;
    EditText txtProfundidad;
    EditText txtComentario;
    Spinner spnTipo;
    Spinner spnNombre;
    Spinner spnEstado;
    private boolean huboCambios;

    ImageView ibFotos;
    private final String ruta_fotos = Environment.getExternalStoragePublicDirectory("routelite") + "/ImagenActivo/";
    private File file = new File(ruta_fotos);
    String fileFoto;
    String fileFotoTmp;
    String tituloFoto;
    boolean tomoFoto;
    boolean tomandoFoto = false;

    //Boolean imprimiendo = false;
    final int MENSAJE_CAMBIOS = 1;

    boolean IntentoFoto = false;


    @SuppressWarnings("unchecked")
    @Override
    public void onCreate(Bundle savedInstanceState) {

        StrictMode.VmPolicy.Builder builder = new StrictMode.VmPolicy.Builder(); StrictMode.setVmPolicy(builder.build());

        super.onCreate(savedInstanceState);
        setContentView(R.layout.captura_activo);
        deshabilitarBarra(true);

        mAccion = getIntent().getAction();
        mPresenta = new CapturarActivo(this, mAccion);
        HashMap<String, Object> oParametros;
        if (getIntent().getSerializableExtra("parametros") != null)
        {
            oParametros = (HashMap<String, Object>) getIntent().getSerializableExtra("parametros");
            if (oParametros != null)
            {
                try {
                    if (mAccion.equals(Enumeradores.Acciones.ACCION_MODIFICAR_ACTIVO)){
                        if (oParametros.containsKey("ActivoDetalleID")) {
                            modificando = true;
                            mPresenta.setActivoDetalleID(oParametros.get("ActivoDetalleID").toString());
                        }
                    }
                    else {
                        if (oParametros.containsKey("IdElectronico")) {
                            modificando = false;
                            mPresenta.setIdElectronico(oParametros.get("IdElectronico").toString());
                        }
                    }
                }catch (Exception ex){
                    mostrarError("Error al recuperar parámetros");
                }
            }
        }
        String MensajeAux;

        TextView texto = (TextView) findViewById(R.id.lblIdElectronico);
        texto.setText(Mensajes.get("ACIIdElectronico"));

        texto = (TextView) findViewById(R.id.lblTipo);
        MensajeAux = Mensajes.get("ACITipo") + ":";
        texto.setText(MensajeAux);

        texto = (TextView) findViewById(R.id.lblNombre);
        MensajeAux = Mensajes.get("ACINombre") + ":";
        texto.setText(MensajeAux);

        texto = (TextView) findViewById(R.id.lblAltura);
        MensajeAux = Mensajes.get("ACIAltura") + ":";
        texto.setText(MensajeAux);

        texto = (TextView) findViewById(R.id.lblAncho);
        MensajeAux = Mensajes.get("ACIAncho") + ":";
        texto.setText(MensajeAux);

        texto = (TextView) findViewById(R.id.lblProfundidad);
        MensajeAux = Mensajes.get("ACIProfundidad") + ":";
        texto.setText(MensajeAux);

        texto = (TextView) findViewById(R.id.lblEstado);
        MensajeAux = Mensajes.get("ACITipoFase") + ":";
        texto.setText(MensajeAux);

        texto = (TextView) findViewById(R.id.lblComentario);
        MensajeAux = Mensajes.get("ACIComentario") + ":";
        texto.setText(MensajeAux);

        ibFotos = (ImageView) findViewById(R.id.ibFotos);
        ibFotos.setOnClickListener(mTomarFoto);

        Button boton = (Button) findViewById(R.id.btnContinuar);
        boton.setText(Mensajes.get("XContinuar"));
        boton.setOnClickListener(mContinuar);

        txtIdElectronico = (EditText) findViewById(R.id.txtIdElectronico);
        txtAltura = (EditText) findViewById(R.id.txtAltura);
        txtAncho = (EditText) findViewById(R.id.txtAncho);
        txtProfundidad = (EditText) findViewById(R.id.txtProfundidad);
        txtComentario = (EditText) findViewById(R.id.txtComentario);
        spnTipo = (Spinner) findViewById(R.id.spnTipo);
        spnTipo.setOnItemSelectedListener(mTipoActivo);
        spnNombre = (Spinner) findViewById(R.id.spnNombre);
        spnNombre.setOnItemSelectedListener(mNombreActivo);
        spnEstado = (Spinner) findViewById(R.id.spnEstado);

        ImageButton btnBuscar = (ImageButton) findViewById(R.id.btnBuscar);
        if (modificando)
            btnBuscar.setVisibility(View.GONE);

        mPresenta.iniciar();
        mPresenta.initSpinner(spnTipo);
        mPresenta.initSpinner(spnEstado);
        if (modificando) {
            mPresenta.initSpinner(spnNombre);
        }
        else{
            spnTipo.setEnabled(true);
            spnNombre.setEnabled(true);
        }
    }

    @Override
    public void iniciar()
    {

    }

    @Override
    public void respuestaMensaje(Enumeradores.RespuestaMsg respuesta, int tipoMensaje) {
        if (tipoMensaje == MENSAJE_CAMBIOS && respuesta == Enumeradores.RespuestaMsg.Si){
            try {
                BDVend.rollback();
                setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
                finalizar();
            }catch(Exception ex){
                if (ex.getMessage()!= null)
                    mostrarError(ex.getMessage());
            }

        }
    }

    @Override
    public void setIdElectronico(String idElectronico)
    {
        txtIdElectronico.setText(idElectronico);
    }

    @Override
    public void setAltura(float altura)
    {
        txtAltura.setText(Generales.getFormatoDecimal(altura, "#,##0.00"));
    }

    @Override
    public void setAncho(float ancho)
    {
        txtAncho.setText(Generales.getFormatoDecimal(ancho, "#,##0.00"));
    }

    @Override
    public void setProfundidad(float profundidad)
    {
        txtProfundidad.setText(Generales.getFormatoDecimal(profundidad, "#,##0.00"));
    }

    @Override
    public short getTipoFase(){
        Object x = spnEstado.getSelectedItem();
        return ( x == null ? 0 : Short.parseShort(((CapturarActivo.VistaSpinner) x).getId()));
    }

    @Override
    public void setComentario(String comentario)
    {
        txtComentario.setText(comentario);
    }

    @Override
    public String getComentario(){
        return txtComentario.getText().toString();
    }

    @Override
    public void setNotaAsignacion(String cliente){
        TextView txtNota = (TextView) findViewById(R.id.lblNotaAsignacion);
        if (!cliente.equals(""))
            txtNota.setText(Mensajes.get("I0329").replace("$0$", cliente));
        else
            txtNota.setVisibility(View.GONE);
    }

    @Override
    public String getClave(){
        CapturarActivo.VistaSpinner item = (CapturarActivo.VistaSpinner)spnNombre.getSelectedItem();
        return (item == null ? "" : item.getId());
    }

    @Override
    public short getTipo(){
        Object x = spnTipo.getSelectedItem();
        return ( x == null ? 0 : Short.parseShort(((CapturarActivo.VistaSpinner) x).getId()));
    }

    public boolean getTomoFoto(){
        return huboCambios;
    }



    private View.OnClickListener mContinuar = new View.OnClickListener() {
        public void onClick(View v) {
            if (mPresenta.validarCaptura()) {
                if (mPresenta.grabar()) {
                    setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
                    finalizar();
                }
            }
        }
    };

    @Override
    public void setFocus(String nombreCampo) {
        switch (nombreCampo.toUpperCase()){
            case "TIPO":
                spnTipo.requestFocus();
                break;
            case "NOMBRE":
                spnNombre.requestFocus();
                break;
            case "TIPOFASE":
                spnEstado.requestFocus();
                break;
        }
    }


    @Override
    public boolean onKeyDown(int keyCode, KeyEvent event)
    {
        try {
            switch (keyCode) {
                case KeyEvent.KEYCODE_BACK:
                    if (mPresenta.huboCambios()){
                        mostrarPreguntaSiNo(Mensajes.get("BP0002"), MENSAJE_CAMBIOS);
                    }else {
                        setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
                        finalizar();
                        return true;
                    }
            }
        }catch (Exception ex){
            mostrarError(ex.getMessage());
        }
        return super.onKeyDown(keyCode, event);
    }

    private Spinner.OnItemSelectedListener mTipoActivo = new Spinner.OnItemSelectedListener() {

        @Override
        public void onItemSelected(AdapterView<?> arg0, View arg1, int arg2, long arg3) {
            CapturarActivo.VistaSpinner item = (CapturarActivo.VistaSpinner)arg0.getItemAtPosition(arg2);
            mPresenta.setTipoActivo(Short.parseShort(item.getId()));
            mPresenta.initSpinner(spnNombre);
        }

        @Override
        public void onNothingSelected(AdapterView<?> parent) {

        }
    };

    private Spinner.OnItemSelectedListener mNombreActivo = new Spinner.OnItemSelectedListener() {

        @Override
        public void onItemSelected(AdapterView<?> arg0, View arg1, int arg2, long arg3) {
            CapturarActivo.VistaSpinner item = (CapturarActivo.VistaSpinner)arg0.getItemAtPosition(arg2);
            //mPresenta.setActivoClave(Short.parseShort(item.getId()));
            mPresenta.obtenerDatosActivo(item.getId());
        }

        @Override
        public void onNothingSelected(AdapterView<?> parent) {

        }
    };

    private View.OnClickListener mTomarFoto = new View.OnClickListener()
    {
        @Override
        public void onClick(View v)
        {
//            tomarFoto();
            if(IntentoFoto) {
                return;
            }
            IntentoFoto = true;
            v.postDelayed(new Runnable() {

                @Override
                public void run() {
                    tomarFoto();
                    IntentoFoto = false;
                }
            }, 2000);

        }
    };

    private void tomarFoto(){
        //si no existe crea la carpeta donde se guardaran las fotos
        file.mkdir();
            /* Tomamos la fecha para agregarla al titulo de la foto */
        //SimpleDateFormat formatoFecha = new SimpleDateFormat("yyyyMMddhhmmss");
        //String fecha = formatoFecha.format(Generales.getFechaHoraActual());

        tituloFoto = mPresenta.getActivoDetalleID();
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
            if (tomandoFoto) {
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

}
