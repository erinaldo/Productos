package com.amesol.routelite.controles;

import android.app.Activity;
import android.content.Context;
import android.content.Intent;
import android.media.AudioManager;
import android.media.ToneGenerator;
import android.util.AttributeSet;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.view.WindowManager;
import android.widget.ImageButton;
import android.widget.LinearLayout;

import com.amesol.routelite.R;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.vistas.Vista;
import com.google.zxing.integration.android.IntentIntegrator;
import com.google.zxing.integration.android.IntentResult;
import com.rscja.deviceapi.Barcode2D;
import com.rscja.deviceapi.exception.ConfigurationException;

public class CargasTextBoxScanner extends LinearLayout
{

	public CargasTextBoxScanner(Context context, AttributeSet attrs)
	{
		super(context, attrs);
		inicializar();
	}

	public CargasTextBoxScanner(Context context)
	{
		super(context);
		inicializar();
	}

	ImageButton btnScanner;
    boolean booCodigoLeido=false;
    String etCodeALPS;

	private void inicializar()
	{
		// Utilizamos el layout como interfaz del control
		String infService = Context.LAYOUT_INFLATER_SERVICE;
		LayoutInflater li = (LayoutInflater) getContext().getSystemService(infService);
		li.inflate(R.layout.cargas_textbox_scanner, this, true);

		if (this.isInEditMode())
			return;
		// Obtenemoslas referencias a los distintos control
		btnScanner = (ImageButton) findViewById(R.id.btnScanner);

		// Se obtiene la Actividad que contiene el control para mandar llamar el
		// intent Del Scanner y para poder cachar desde Vista El Evento del
		// resultado del Intent (onActivityResult)
		Act = ((Activity) li.getContext());
		((Vista) Act).setControlScanner(this);

		// Asociamos los eventos necesarios
		asignarEventos();
	}

	public interface OnCodigoIngresadoListener
	{
		// void OnCodigoIngresado(String Codigo);
		void OnCodigoIngresado(String Codigo, int codigoLeido);

	}

	private OnCodigoIngresadoListener listener;

	// ...

	public void setOnCodigoIngresado(OnCodigoIngresadoListener l)
	{
		listener = l;
	}

	private void asignarEventos()
	{

		btnScanner.setOnClickListener(mEventoScan);

	}

	Activity Act;

	public static void changeVGstate(ViewGroup current, boolean enable)
	{
		current.setFocusable(enable);
		current.setClickable(enable);
		current.setEnabled(enable);

		for (int i = 0; i < current.getChildCount(); i++)
		{
			View v = current.getChildAt(i);
			if (v instanceof ViewGroup)
				changeVGstate((ViewGroup) v, enable);
			else
			{
				v.setFocusable(enable);
				v.setClickable(enable);
				v.setEnabled(enable);
			}
		}
	}

	private OnClickListener mEventoScan = new OnClickListener()
	{

		public void onClick(View v)
		{
            switch(Sesion.get(Sesion.Campo.ModeloDispositivo).toString()){
                case "ALPS":
                    habilitarScannerALPS();
                    if (booCodigoLeido){
                        listener.OnCodigoIngresado(etCodeALPS.toString(), 1);
                    }
                    break;
                default:
			        IntentIntegrator intent = new IntentIntegrator(Act);
			        // changeVGstate(Act,false);
			        intent.initiateScan();
            }
		}
	};

	public void onActivityResult(int requestCode, int resultCode, Intent intent)
	{
		IntentResult scanResult = IntentIntegrator.parseActivityResult(requestCode, resultCode, intent);
		if (scanResult != null)
		{

			listener.OnCodigoIngresado(scanResult.getContents(), 1);
		}
		//		Act.setTheme(R.style.routelite);

		Act.getWindow().setFlags(WindowManager.LayoutParams.FLAG_FORCE_NOT_FULLSCREEN, WindowManager.LayoutParams.FLAG_FORCE_NOT_FULLSCREEN);
	}

	public void habilitarBotonScanner(boolean habilitar)
	{
		btnScanner.setEnabled(habilitar);
	}

    public void habilitarScannerALPS()
    {
        Barcode2D mInstance;

        try {
            mInstance = Barcode2D.getInstance();

            mInstance.open();

            etCodeALPS= mInstance.scan();

            if (etCodeALPS.equals("")){
                SonidoNoCodigoLeidoALPS();
            }else{
                SonidoCodigoLeidoALPS();
                booCodigoLeido=true;
            }

            mInstance.close();

        } catch (ConfigurationException e) {
            e.printStackTrace();

            return;
        }
    }

    public void SonidoCodigoLeidoALPS(){
        final ToneGenerator tg = new ToneGenerator(AudioManager.STREAM_NOTIFICATION, 100);
        tg.startTone(ToneGenerator.TONE_PROP_BEEP);
    }

    public void SonidoNoCodigoLeidoALPS(){
        final ToneGenerator tg = new ToneGenerator(AudioManager.STREAM_NOTIFICATION, 100);
        tg.startTone(ToneGenerator.TONE_PROP_BEEP2);
    }
}
