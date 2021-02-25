package com.amesol.routelite.vistas;

import android.app.ActionBar;
import android.content.Context;
import android.content.Intent;
import android.graphics.Bitmap;
import android.graphics.Canvas;
import android.graphics.Color;
import android.graphics.Paint;
import android.graphics.Path;
import android.graphics.RectF;
import android.os.Bundle;
import android.os.Environment;
import android.provider.MediaStore;
import android.util.AttributeSet;
import android.view.KeyEvent;
import android.view.MotionEvent;
import android.view.View;
import android.view.ViewGroup.LayoutParams;
import android.view.WindowManager;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ImageButton;
import android.widget.LinearLayout;
import android.widget.TextView;

import com.amesol.routelite.R;
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.datos.utilerias.ArchivoConfiguracion;
import com.amesol.routelite.datos.utilerias.ConfiguracionLocal;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.act.CapturarFirma;
import com.amesol.routelite.presentadores.interfaces.ICapturaFirma;

import java.io.File;
import java.io.FileOutputStream;
import java.util.HashMap;

import cx.hell.android.pdfview.BitmapCacheValue;

/**
 * Created by Adriana on 08/11/2016.
 */
public class CapturaFirma extends Vista implements ICapturaFirma {

    CapturarFirma mPresenta;
    private String mAccion;
    private EditText txtNombre;
    private Bitmap mBitmap;
    LinearLayout layFirma;
    File myFile;
    Signature mSignature;
    Button btnContinuar;
    View mView;
    String sTransProdId;

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.captura_firma);

        getWindow().setSoftInputMode(WindowManager.LayoutParams.SOFT_INPUT_STATE_ALWAYS_HIDDEN);
        mAccion = getIntent().getAction();
        lblTitle.setText(Mensajes.get("XFirma"));
        //mPresenta = new CapturarKilometraje(this, mAccion);
        //mPresenta.iniciar();
        TextView texto = (TextView) findViewById(R.id.lblNombre);
        texto.setText(Mensajes.get("XNombre"));
        texto = (TextView) findViewById(R.id.lblFirma);
        texto.setText(Mensajes.get("XFirma"));

        txtNombre = (EditText) findViewById(R.id.txtNombre);
        txtNombre.requestFocus();

        ConfiguracionLocal conf = (ConfiguracionLocal) Sesion.get(Sesion.Campo.ConfiguracionLocal);
        String sRuta = conf.get(ArchivoConfiguracion.CampoConfiguracion.DIRECTORIO_TRABAJO).toString() + "/ImagenFirma/";
        File fDir = new File(sRuta);
        fDir.mkdir(); //Crea la ruta si no existe

        HashMap<String, Object> oParametros;
        oParametros = (HashMap<String, Object>) getIntent().getSerializableExtra("parametros");
        sTransProdId = oParametros.get("TransProdID").toString();
        String sNombre = sTransProdId + ".png";
        myFile = new File(sRuta, sNombre);

        layFirma = (LinearLayout)findViewById(R.id.llFirma);
        mSignature = new Signature(this, null);
        mSignature.setBackgroundColor(Color.WHITE);
        layFirma.addView(mSignature, LayoutParams.MATCH_PARENT, LayoutParams.MATCH_PARENT);
        mView = layFirma;

        btnContinuar = (Button) findViewById(R.id.btnAceptar);
        btnContinuar.setText(Mensajes.get("XContinuar"));
        btnContinuar.setOnClickListener(mContinuar);
        btnContinuar.setEnabled(false);

        ImageButton btnLimpiar = (ImageButton) findViewById(R.id.btnLimpiar);
        btnLimpiar.setOnClickListener(mLimpiar);
    }

    @Override
    public void iniciar()
    {
    }

    @Override
    public void resultadoActividad(int requestCode, int resultCode, Intent data)
    {
    }

    @Override
    public void respuestaMensaje(Enumeradores.RespuestaMsg respuesta, int tipoMensaje)
    {
    }

    @Override
    public boolean onKeyDown(int keyCode, KeyEvent event)
    {
        switch (keyCode)
        {
            case KeyEvent.KEYCODE_BACK:
                setResultado(Enumeradores.Resultados.RESULTADO_TERMINAR);
                finalizar();
                return true;
        }
        return super.onKeyDown(keyCode, event);
    }

    private View.OnClickListener mContinuar = new View.OnClickListener() {

        @Override
        public void onClick(View v) {
            try {
                if (txtNombre.getText().toString().trim().equals("")) {
                    mostrarError(Mensajes.get("BE0001").replace("$0$", Mensajes.get("XNombre")));
                    return;
                }

                mView.setDrawingCacheEnabled(true);
                mSignature.save(mView);

                Intent data = new Intent();
                data.putExtra("Nombre", getNombre());
                data.putExtra("NombreArchivo", getNombreArchivo());
                setResult(Enumeradores.Resultados.RESULTADO_BIEN, data);
                //setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
                finalizar();
            } catch (Exception ex) {
                mostrarError(ex.getMessage());
                setResultado(Enumeradores.Resultados.RESULTADO_MAL);
                finalizar();
            }
        }

    };

    private View.OnClickListener mLimpiar = new View.OnClickListener() {

        @Override
        public void onClick(View v) {
            mSignature.clear();
            btnContinuar.setEnabled(false);
        }

    };

    public String getNombre(){
        return txtNombre.getText().toString().trim();
    }

    public String getNombreArchivo(){
        return myFile.getName();
    }

    public class Signature extends View
    {
        private static final float STROKE_WIDTH = 5f;
        private static final float HALF_STROKE_WIDTH = STROKE_WIDTH / 2;
        private Paint paint = new Paint();
        private Path path = new Path();

        private float lastTouchX;
        private float lastTouchY;
        private final RectF dirtyRect = new RectF();

        public Signature(Context context, AttributeSet attrs)
        {
            super(context, attrs);
            paint.setAntiAlias(true);
            paint.setColor(Color.BLACK);
            paint.setStyle(Paint.Style.STROKE);
            paint.setStrokeJoin(Paint.Join.ROUND);
            paint.setStrokeWidth(STROKE_WIDTH);
        }

        public void save(View v)
        {
            //Log.v("log_tag", "Width: " + v.getWidth());
            //Log.v("log_tag", "Height: " + v.getHeight());
            if(mBitmap == null)
            {
                mBitmap =  Bitmap.createBitmap (layFirma.getWidth(), layFirma.getHeight(), Bitmap.Config.RGB_565);;
            }
            Canvas canvas = new Canvas(mBitmap);
            try
            {
                FileOutputStream mFileOutStream = new FileOutputStream(myFile);

                v.draw(canvas);
                mBitmap.compress(Bitmap.CompressFormat.PNG, 90, mFileOutStream);
                mFileOutStream.flush();
                mFileOutStream.close();
                //String url = MediaStore.Images.Media.insertImage(getContentResolver(), mBitmap, "title", null);

                //Log.v("log_tag","url: " + url);
                //In case you want to delete the file
                //boolean deleted = mypath.delete();
                //Log.v("log_tag","deleted: " + mypath.toString() + deleted);
                //If you want to convert the image to string use base64 converter

            }
            catch(Exception e)
            {
                //Log.v("log_tag", e.toString());
            }
        }

        public void clear()
        {
            path.reset();
            invalidate();
        }

        @Override
        protected void onDraw(Canvas canvas)
        {
            canvas.drawPath(path, paint);
        }

        @Override
        public boolean onTouchEvent(MotionEvent event)
        {

            float eventX = event.getX();
            float eventY = event.getY();
            btnContinuar.setEnabled(true);

            switch (event.getAction())
            {
                case MotionEvent.ACTION_DOWN:
                    path.moveTo(eventX, eventY);
                    lastTouchX = eventX;
                    lastTouchY = eventY;
                    return true;

                case MotionEvent.ACTION_MOVE:

                case MotionEvent.ACTION_UP:

                    resetDirtyRect(eventX, eventY);
                    int historySize = event.getHistorySize();
                    for (int i = 0; i < historySize; i++)
                    {
                        float historicalX = event.getHistoricalX(i);
                        float historicalY = event.getHistoricalY(i);
                        expandDirtyRect(historicalX, historicalY);
                        path.lineTo(historicalX, historicalY);
                    }
                    path.lineTo(eventX, eventY);
                    break;

                default:
                    debug("Ignored touch event: " + event.toString());
                    return false;
            }

            invalidate((int) (dirtyRect.left - HALF_STROKE_WIDTH),
                    (int) (dirtyRect.top - HALF_STROKE_WIDTH),
                    (int) (dirtyRect.right + HALF_STROKE_WIDTH),
                    (int) (dirtyRect.bottom + HALF_STROKE_WIDTH));

            lastTouchX = eventX;
            lastTouchY = eventY;

            return true;
        }

        private void debug(String string){
        }

        private void expandDirtyRect(float historicalX, float historicalY)
        {
            if (historicalX < dirtyRect.left)
            {
                dirtyRect.left = historicalX;
            }
            else if (historicalX > dirtyRect.right)
            {
                dirtyRect.right = historicalX;
            }

            if (historicalY < dirtyRect.top)
            {
                dirtyRect.top = historicalY;
            }
            else if (historicalY > dirtyRect.bottom)
            {
                dirtyRect.bottom = historicalY;
            }
        }

        private void resetDirtyRect(float eventX, float eventY)
        {
            dirtyRect.left = Math.min(lastTouchX, eventX);
            dirtyRect.right = Math.max(lastTouchX, eventX);
            dirtyRect.top = Math.min(lastTouchY, eventY);
            dirtyRect.bottom = Math.max(lastTouchY, eventY);
        }

    }
}
