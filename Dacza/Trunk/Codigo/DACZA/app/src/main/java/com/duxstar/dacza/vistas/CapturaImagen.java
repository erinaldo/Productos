package com.duxstar.dacza.vistas;

import android.content.Intent;
import android.content.pm.LabeledIntent;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.graphics.Color;
import android.graphics.Matrix;
import android.location.LocationListener;
import android.net.Uri;
import android.os.Bundle;
import android.os.Environment;
import android.provider.MediaStore;
import android.support.v4.app.FragmentActivity;
import android.util.Log;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.ImageButton;
import android.widget.ImageView;
import android.widget.LinearLayout;
import android.widget.TextView;

import com.duxstar.dacza.R;
import com.duxstar.dacza.datos.utilerias.Sesion;
import com.duxstar.dacza.presentadores.Enumeradores;
import com.duxstar.dacza.utilerias.ControlError;
import com.duxstar.dacza.utilerias.KeyGen;
import com.google.android.gms.maps.OnMapReadyCallback;
import com.google.zxing.integration.android.IntentIntegrator;

import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.IOException;
import java.text.SimpleDateFormat;
import java.util.Date;

/**
 * Created by Adriana on 14/07/2016.
 */
public class CapturaImagen extends FragmentActivity
{
    private final String ruta_fotos = Environment.getExternalStoragePublicDirectory("dacza") + "/Imagenes/";
    private File file = new File(ruta_fotos);
    String fileFoto;
    String tituloFoto;
    boolean tomoFoto;

    LinearLayout llCapturaImg;
    ImageView ibFotos;
    Button btContinuar;
    String sFolio;
    boolean bSoloLectura;

    @Override
    public void onCreate(Bundle savedInstanceState)
    {
        // TODO Auto-generated method stub
        super.onCreate(savedInstanceState);
        setContentView(R.layout.captura_imagen);
        setTitle("Solicitud de Traspaso");//Cambiamos el titulo

        if (getIntent().getExtras().containsKey("folio")) {
            sFolio = getIntent().getExtras().getString("folio");
            bSoloLectura = false;
        }
        if (getIntent().getExtras().containsKey("tituloFoto")){
            tituloFoto = getIntent().getExtras().getString("tituloFoto");
            bSoloLectura = true;
        }

        //btContinuar = (Button) findViewById(R.id.btContinuar);
        ibFotos = (ImageView) findViewById(R.id.ibFotos);

        if (!bSoloLectura) {
           tomarFoto();
            //btContinuar.setText("Continuar");
            //btContinuar.setOnClickListener(mContinuar);
            //ibFotos.setOnClickListener(mTomarFoto);
        }else{
            //btContinuar.setVisibility(View.GONE);
            mostrarFoto();
        }

        tomoFoto = false;

    }

    private View.OnClickListener mContinuar = new View.OnClickListener()
    {

        @Override
        public void onClick(View v)
        {
            if (tomoFoto) {
                setResult(Enumeradores.Resultados.RESULTADO_BIEN);
                Sesion.set(Sesion.Campo.ResultadoActividad, tituloFoto);
                CapturaImagen.this.finish();
            }
        }
    };

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
        SimpleDateFormat formatoFecha = new SimpleDateFormat("yyyyMMddhhmmss");
        String fecha = formatoFecha.format(new Date());
        tituloFoto = sFolio + "_" + fecha;
        fileFoto = ruta_fotos + tituloFoto + ".jpg";
        File foto = new File(fileFoto);

        try
        {
            foto.createNewFile();
        }
        catch (IOException e)
        {
            // TODO Auto-generated catch block
            Log.e("ERROR ", "Error:" + e);
        }

        Uri uri = Uri.fromFile(foto);
        Intent camaraIntent = new Intent(MediaStore.ACTION_IMAGE_CAPTURE);
        camaraIntent.putExtra(MediaStore.EXTRA_OUTPUT, uri);
        startActivityForResult(camaraIntent, 1);
    }

    public void onActivityResult(int requestCode, int resultCode, Intent intent) {
        if (requestCode == 1 && resultCode == RESULT_OK)
        {
            /*File file = new File(fileFoto);
            long ini = file.length();*/

            Bitmap bmap = BitmapFactory.decodeFile(fileFoto);

            //Bitmap map = redimensionarImagenMaximo(bmap, 1000, 1000);

            //ibFotos.setImageBitmap(map);
            tomoFoto = true;

            File foto1 = new File(fileFoto);
            foto1.delete();

            FileOutputStream fos = null;
            try
            {
                fos = new FileOutputStream(fileFoto);
                bmap.compress(Bitmap.CompressFormat.JPEG, 50, fos);
                fos.flush();

                /*File file2 = new File(fileFoto);
                long fin = file.length();*/
            }
            catch (FileNotFoundException ex)
            {
                ex.printStackTrace();
            }
            catch (IOException ex)
            {
                ex.printStackTrace();
            }

            setResult(Enumeradores.Resultados.RESULTADO_BIEN);
            Sesion.set(Sesion.Campo.ResultadoActividad, tituloFoto);
            CapturaImagen.this.finish();

        }
        else{
            if (fileFoto != "")
            {
                File fotito = new File(fileFoto);
                if (fotito.delete())
                    tituloFoto = "";
            }
            finish();
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

    public void mostrarFoto(){
        String imagen = ruta_fotos + tituloFoto + ".jpg";

        llCapturaImg = (LinearLayout)findViewById(R.id.llCapturaImagen);
        llCapturaImg.setOrientation(LinearLayout.HORIZONTAL);
        Bitmap bmap = BitmapFactory.decodeFile(imagen);
        //Bitmap map = redimensionarImagenMaximo(bmap, 1000, 1000);

        ibFotos.setImageBitmap(bmap);

        tomoFoto = true;
    }
}
