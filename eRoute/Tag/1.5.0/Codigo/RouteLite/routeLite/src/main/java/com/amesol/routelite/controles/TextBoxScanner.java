package com.amesol.routelite.controles;

import android.app.Activity;
import android.content.Context;
import android.content.Intent;
import android.media.AudioManager;
import android.media.ToneGenerator;
import android.os.AsyncTask;
import android.text.Editable;
import android.text.TextWatcher;
import android.util.AttributeSet;
import android.view.KeyEvent;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.view.WindowManager;
import android.widget.EditText;
import android.widget.ImageButton;
import android.widget.LinearLayout;

import com.amesol.routelite.R;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.vistas.Vista;
import com.google.zxing.integration.android.IntentIntegrator;
import com.google.zxing.integration.android.IntentResult;

import com.rscja.deviceapi.Barcode1D;
import com.rscja.deviceapi.exception.ConfigurationException;

public class TextBoxScanner extends LinearLayout
{

	public TextBoxScanner(Context context, AttributeSet attrs)
	{
		super(context, attrs);
		inicializar();
	}

	public TextBoxScanner(Context context)
	{
		super(context);
		inicializar();
	}

	EditText txtScanner;
	ImageButton btnScanner;
    boolean booCodigoLeido=false;

	private void inicializar()
	{
		// Utilizamos el layout como interfaz del control
		String infService = Context.LAYOUT_INFLATER_SERVICE;
		LayoutInflater li = (LayoutInflater) getContext().getSystemService(infService);
		li.inflate(R.layout.textbox_scanner, this, true);

		if (this.isInEditMode())
			return;
		// Obtenemoslas referencias a los distintos control
		txtScanner = (EditText) findViewById(R.id.txtScanner);
		txtScanner.setSelectAllOnFocus(true);
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

	/************ OnTextChanged *******************************/
	public interface OnTextChangedListener
	{
		// void OnCodigoIngresado(String Codigo);
		void OnTextChanged(CharSequence s);

	}

	private OnTextChangedListener txtChangedlistener;

	// ...

	public void setOnTextChanged(OnTextChangedListener l)
	{
		txtChangedlistener = l;
	}

	/*********************************************************/

	public void setEnabled(boolean habilitado)
	{
		txtScanner.setEnabled(habilitado);
	}

	private void asignarEventos()
	{
		txtScanner.addTextChangedListener(new TextWatcher()
		{
			public void afterTextChanged(Editable s)
			{
			}

			public void beforeTextChanged(CharSequence s, int start, int count, int after)
			{
			}

			public void onTextChanged(CharSequence s, int start, int before, int count)
			{
				try
				{
					if (txtChangedlistener != null)
					{
						txtChangedlistener.OnTextChanged(s);
					}
				}
				catch (Exception ex)
				{
					String error = ex.getMessage();
				}

			}
		});

		txtScanner.setOnFocusChangeListener(new View.OnFocusChangeListener()
		{

			@Override
			public void onFocusChange(View v, boolean hasFocus)
			{
				// TODO Auto-generated method stub
				if (!hasFocus)
				{
					if (txtScanner.getText().length() > 0)
					{
						listener.OnCodigoIngresado(txtScanner.getText().toString(), 2);
					}
				}
			}
		});

		txtScanner.setOnKeyListener(new View.OnKeyListener()
		{
			public boolean onKey(View v, int keyCode, KeyEvent event)
			{
				if (event.getAction() == KeyEvent.ACTION_UP)
				{
					// check if the right key was pressed
					if (keyCode == KeyEvent.KEYCODE_ENTER)
					{

						listener.OnCodigoIngresado(txtScanner.getText().toString(), 2);
						return true;
					}
				}
				return false;
			}
		});

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
                        listener.OnCodigoIngresado(txtScanner.getText().toString(), 1);
                    }
                    break;
                case "FOXCONN INTERNATIONAL HOLDINGS LIMITED":

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

			// TEXT.setText(scanResult.toString().split("\\n",
			// 3)[1].replace("Contents: ",""));
			txtScanner.setText(scanResult.getContents());
			// txtScanner.dispatchKeyEvent(new KeyEvent(KeyEvent.ACTION_DOWN,
			// KeyEvent.KEYCODE_ENTER));
			listener.OnCodigoIngresado(txtScanner.getText().toString(), 1);
		}
		//		Act.setTheme(R.style.routelite);

		Act.getWindow().setFlags(WindowManager.LayoutParams.FLAG_FORCE_NOT_FULLSCREEN, WindowManager.LayoutParams.FLAG_FORCE_NOT_FULLSCREEN);
	}

	public void setTexto(String texto)
	{
		txtScanner.setText(texto);
	}

	public void BorrarTexto()
	{
		txtScanner.setText("");
	}

	public String getTexto()
	{
		return txtScanner.getText().toString().trim();
	}

	public void habilitarBotonScanner(boolean habilitar)
	{
		btnScanner.setEnabled(habilitar);
	}

    public void habilitarScannerALPS()
    {
        Barcode1D mInstance;
        String etCodeALPS;

        try {
            mInstance = Barcode1D.getInstance();

            mInstance.open();

            etCodeALPS= mInstance.scan();

            if (etCodeALPS.equals("")){
                SonidoNoCodigoLeidoALPS();
            }else{
                SonidoCodigoLeidoALPS();
                booCodigoLeido=true;
            }

            txtScanner.setText(etCodeALPS);

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
