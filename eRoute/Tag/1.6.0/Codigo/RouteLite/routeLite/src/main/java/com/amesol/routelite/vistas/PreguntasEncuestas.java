package com.amesol.routelite.vistas;

import android.app.AlertDialog;
import android.app.FragmentTransaction;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.graphics.Color;
import android.graphics.Matrix;
import android.location.Criteria;
import android.location.Location;
import android.location.LocationListener;
import android.location.LocationManager;
import android.net.Uri;
import android.os.Bundle;
import android.os.Environment;
import android.provider.MediaStore;
import android.support.v4.app.FragmentActivity;
import android.text.InputFilter;
import android.text.InputType;
import android.util.Log;
import android.view.ContextThemeWrapper;
import android.view.Gravity;
import android.view.KeyEvent;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.view.View.OnClickListener;
import android.view.ViewGroup.LayoutParams;
import android.widget.Button;
import android.widget.CheckBox;
import android.widget.DatePicker;
import android.widget.EditText;
import android.widget.HorizontalScrollView;
import android.widget.ImageButton;
import android.widget.LinearLayout;
import android.widget.RadioButton;
import android.widget.RadioGroup;
import android.widget.ScrollView;
import android.widget.TableLayout;
import android.widget.TableRow;
import android.widget.TextView;

import com.amesol.routelite.R;
import com.amesol.routelite.R.drawable;
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.datos.Dia;
import com.amesol.routelite.datos.ENCPregunta;
import com.amesol.routelite.datos.ENPRespCodigo;
import com.amesol.routelite.datos.ENPRespGPS;
import com.amesol.routelite.datos.ENPRespImagen;
import com.amesol.routelite.datos.ENPRespMatricial;
import com.amesol.routelite.datos.ENPRespNumero;
import com.amesol.routelite.datos.ENPRespOpcional;
import com.amesol.routelite.datos.ENPRespTexto;
import com.amesol.routelite.datos.Encuesta;
import com.amesol.routelite.datos.Usuario;
import com.amesol.routelite.datos.Visita;
import com.amesol.routelite.datos.basedatos.BDVend;
import com.amesol.routelite.datos.basedatos.Consultas2;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.utilerias.KeyGen;
import com.google.android.gms.maps.CameraUpdateFactory;
import com.google.android.gms.maps.GoogleMap;
import com.google.android.gms.maps.MapFragment;
import com.google.android.gms.maps.OnMapReadyCallback;
import com.google.android.gms.maps.model.LatLng;
import com.google.android.gms.maps.model.MarkerOptions;
import com.google.zxing.integration.android.IntentIntegrator;
import com.google.zxing.integration.android.IntentResult;

import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.IOException;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Date;

public class PreguntasEncuestas extends FragmentActivity implements OnClickListener, LocationListener, OnMapReadyCallback
{
	public static int ID_CONTINUAR = 1045564;
	public static int ID_DINAMICO = 1045565;
	public static int ID_SCANNER = 1045566;
	public static int ID_FOTO = 1045567;
	public static int ID_REFRESCAR = 1045569;
    //creamos una ruta para guardar las fotos
    private final String ruta_fotos = Environment.getExternalStoragePublicDirectory("routelite") + "/ImagenEncuesta/";
    private File file = new File(ruta_fotos);
    ISetDatos preguntas; // variable para cargar las preguntas
	String clave;
	boolean respReq = true;// variable para validar respuesta requerida
	int habilitarSalir = 0;// variable para validar si sale de la encuesta
	//Variables para las inserciones
	//tabla Encuesta
	String ENCId;
	String sUsuarioID;
	String sDiaClave;
	String sVisitaClave;
	Date sFechaInicio;
	Date sHoraInicio;
	Date sHoraFin;
	String sMFechaHora;
	//tabla ENCPregunta
	String ENPId;
	int CEPNumero;
	//variables estaticas
	LinearLayout llRespuesta;
	TextView tvNombreEncuesta;
	TextView tvPregunta;
	//variables dinamicos
	EditText etDinamico; //este componente es dinamico, cambia desde el metodo configTexto
	DatePicker dpDinamico; //este componente es dinamico, cambia desde el metodo configTexto
	EditText[] etDinamico2;
	RadioButton[] rbDinamico;
	CheckBox[] cbDinamico;
	DatePicker[] dtDinamico;
	TextView[] tvDinamico;
	EditText etScanner;//esto es para la configuracion de escaner
	ImageButton btScanner;//esto es para la configuracion de escaner
	ImageButton ibFotos;//esto es para la configuracion de imagen
	TextView tvLongitud;//esto es solo para GPS
	TextView tvLatitud;//esto es solo para GPS
	TextView tvAltitud;//esto es solo para GPS
	MapFragment mapaFragmento;//esto es solo para gps
	CheckBox[] checkMatricial;//esto es solo para matricial
	EditText[] textoMatricial;//esto es solo para matricial
	EditText[] numeroMatricial;//esto es solo para matricial
	Button btContinuar;
	int contadorPregunta = -1;
	int contadorEPID = -1;
	//variables de configuracion en general
	int tipoRespuesta = 0;
	int respuestaRequerida = 0;
	int confirmacion = 0;
	int tipoConversion = 0;
	int tipoLimite = 0;
	int minimo = 0;
	int maximo = 0;
	int cantidadRequerida = 0;
	int tipoSeleccionOpcional = 0;//solo se utiliza en opcional
	int rotativa = 0;//solo se utiliza en opcional
	int condicion = 0;//solo se utiliza en opcional
	int tipoLimite2 = 0;//solo se utiliza en opcional
	int minimo2 = 0;//solo se utiliza en opcional
	int maximo2 = 0;//solo se utiliza en opcional
    ISetDatos configuracionOpcional;//solo se utiliza en opcional
    String CROId;//solo se utiliza en opcional
    String COOId[];
	int tipoCodigo = 0;//solo se utliza en tipo codigo de barras
	int calidad = 0;//solo se utiliza en tipo imagen
	double altitudGps;//solo se utiliza en tipo GPS
	double longitudGps;//solo se utiliza en tipo GPS
	double latitudGps;//solo se utiliza en tipo GPS
	Date fechaGps;//solo se utiliza en tipo GPS
	Date horaGps;//solo se utiliza en tipo GPS
	Location loc;//solo se utiliza en tipo GPS
	int respuestasCount, preguntasCount;//solo funciona para matricial sirve para optener los numero que se utilizaron para guardar los campos
	int tipoValorCount[];//solo funciona para matricial sirve para guardar los tipo de valor
	int CPMNumero[], CRMNumero[]; //solo funciona en matricial y sirve para guardar los id de cada tabla para poder insertar en matricial
	//solo se utiliza en salto y esto se configura en siguientePregunta
	int CEPNumero1 = 0;
	int CEPNumero2 = 0;
	int CEPNumero3 = 0;
	int tipoOperadorSig = 0;
	int tipoCondicion = 0;
	String valor = "";
	int tipoValor = 0;
	int tipoCanOpcion = 0;
	int terminar = 0;
	//esta variable la utilizo para saber cuantos registro trajo
	int configComponentes = 0;
    //parametros para los componentes
    LayoutParams parametros = new LayoutParams(LayoutParams.FILL_PARENT, LayoutParams.WRAP_CONTENT);
    String fileFoto;
	String tituloFoto;
	boolean tomoFoto = false;

	//variables para llevar el control de mostrar lo que se acaba de contestar
	String[] enpid;//tabla ENCPregunta
	boolean saltoActivo = false;
	
	@Override
	public void onCreate(Bundle savedInstanceState)
	{
		// TODO Auto-generated method stub
		super.onCreate(savedInstanceState);
		setContentView(R.layout.preguntas_encuestas);
		setTitle(Mensajes.get("XEncuestas"));//Cambiamos el titulo
		//obtenemos los datos que mandamos desde el otro layout
		Bundle recogerDato = getIntent().getExtras();
		String titulo = recogerDato.getString("titulo");
		clave = recogerDato.getString("id");
		

		/*
		 * SimpleDateFormat fechaFormato = new SimpleDateFormat("yyyy-MM-dd");
		 * SimpleDateFormat horaFormato = new SimpleDateFormat("hh:mm:ss");
		 */
		
		sUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;
		sDiaClave = ((Dia) Sesion.get(Campo.DiaActual)).DiaClave;
		sVisitaClave = ((Visita) Sesion.get(Campo.VisitaActual)).VisitaClave;
		sFechaInicio = new Date();
		sHoraInicio = new Date();

		

		try
		{
			
			habilitarSalir = Consultas2.ConsultasEncuestas.obtenerHabilitarSalir(clave);
			ISetDatos encuestaContestada = Consultas2.ConsultasEncuestas.obtenerEncuestaContestada(clave,sVisitaClave, sDiaClave);
			
			if (encuestaContestada != null)
			{
				
				
				enpid = new String[encuestaContestada.getCount()];
			
				for (int x = 0; x < encuestaContestada.getCount(); x++)
				{
                    encuestaContestada.moveToNext();
                  
                    enpid[x] = encuestaContestada.getString("ENPId").toString();
				}
				
				ENCId = encuestaContestada.getString("ENCId");
				
				preguntas = Consultas2.ConsultasEncuestas.obtenerPreguntas(clave, true, ENCId);
						
			}
			else
			{
				preguntas = Consultas2.ConsultasEncuestas.obtenerPreguntas(clave, false, ENCId);
				ENCId = KeyGen.getId();
				insertarEncuesta();
				enpid = new String[preguntas.getCount()];//ponemos cuanto de index va tener este arreglo, en este caso seran el numero de preguntas
				saltoActivo = true;
			}
			
			
			
			//nos traemos las preguntas desde la BD
			
		}
		catch (Exception e)
		{
			e.printStackTrace();
		}

		//Cargamos los componentes a java
		tvNombreEncuesta = (TextView) findViewById(R.id.tvNombreEncuesta);
		tvPregunta = (TextView) findViewById(R.id.tvPregunta);
		btContinuar = (Button) findViewById(R.id.btContinuar);
		llRespuesta = (LinearLayout) findViewById(R.id.llRespuesta);

		
 
		tvNombreEncuesta.setText(titulo);
		tvNombreEncuesta.setTextSize(chequeoPregunta(titulo, 2));
		siguientePregunta();

		btContinuar.setId(ID_CONTINUAR);
		btContinuar.setText(Mensajes.get("BTContinuar"));
		btContinuar.setOnClickListener(this);
		
	}

	@Override
	public boolean onKeyDown(int keyCode, KeyEvent event) //atrapar el evento de retroceso
	{
		switch (keyCode)
		{
			case KeyEvent.KEYCODE_BACK: //cacho el valor del "regreso"

				anteriorPregunta();
				return false;

		}
		// TODO Auto-generated method stub
		return super.onKeyDown(keyCode, event);
	}

	@Override
	public void onClick(View v) //Este metodo lo uitlizo para identificar el id de todos los botones
	{

		if (v.getId() == ID_CONTINUAR)
		{

			if (respReq)
			{
				
				if (confirmacion == 1) // verificamos si tiene confirmacion
				{
				
					if (validarMaxMin(tipoRespuesta))
					{
					
						mensajeDialogo(Mensajes.get("P0049"), 0);
					}
				}
				else
				{
					
					if (validarMaxMin(tipoRespuesta))
					{
						
						contestarPregunta(tipoRespuesta);
						siguientePregunta();
					}
				}
			}
			else
			{
				
				if (validarCampoVacio(tipoRespuesta))//el metedo verifica si el componente viene vacio, manda una variable de tipo boolean si es verdadera entra y no deja pasar a la otra pregunta hasta que este lleno el componente 
				{
					
					mensajeSimple(Mensajes.get("E0308"));
				}
				else
				{
					
					if (confirmacion == 1) // verificamos si tiene confirmacion
					{
						
						if (validarMaxMin(tipoRespuesta))
						{
							
							mensajeDialogo(Mensajes.get("P0049"), 0);
						}
					}
					else
					{
					
						if (validarMaxMin(tipoRespuesta))
						{
							
							contestarPregunta(tipoRespuesta);
							siguientePregunta();
						}
					}
				}
			}
		}

		if (v.getId() == ID_SCANNER)
		{
			IntentIntegrator scanIntegrator = new IntentIntegrator(this);
			scanIntegrator.initiateScan();
		}

		if (v.getId() == ID_FOTO)
		{

			//si no existe crea la carpeta donde se guardaran las fotos
			file.mkdir();
			/* Tomamos la fecha para agregarla al titulo de la foto */
			SimpleDateFormat formatoFecha = new SimpleDateFormat("yyyyMMddhhmmss");
			String fecha = formatoFecha.format(new Date());
			tituloFoto = clave + "_" + fecha;
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

		if (v.getId() == ID_REFRESCAR)
		{
			obtenerCordenadas();
			mapaFragmento.getMapAsync(this);
		}

	}

	public void onActivityResult(int requestCode, int resultCode, Intent intent)
	{ //con este metodo cacho el valor que trae desde el scanner
		//retrieve scan result
		boolean pasa = true;
		IntentResult scanningResult = IntentIntegrator.parseActivityResult(requestCode, resultCode, intent);

		if (scanningResult != null)
		{
			etScanner.setText(scanningResult.getContents());
			pasa = false;
		}

		if (requestCode == 1 && resultCode == RESULT_OK)
		{

			Bitmap bmap = BitmapFactory.decodeFile(fileFoto);

			Bitmap map = redimensionarImagenMaximo(bmap, 1000, 1000);

			ibFotos.setImageBitmap(map);
			tomoFoto = true;

			File foto1 = new File(fileFoto);
			foto1.delete();

			FileOutputStream fos = null;
			try
			{
				fos = new FileOutputStream(fileFoto);
				map.compress(Bitmap.CompressFormat.JPEG, calidad, fos);
				fos.flush();
			}
			catch (FileNotFoundException ex)
			{
				ex.printStackTrace();
			}
			catch (IOException ex)
			{
				ex.printStackTrace();
			}

		}
		else
		{

			if (pasa)
			{
				if (fileFoto != "")
				{
					File fotito = new File(fileFoto);
					if (fotito.delete())
					{
						
						tituloFoto = "";

					}
					else
					{
					
					}
				}
			}
		}

	}

	@Override
	public void onLocationChanged(Location location)
	{
		// TODO Auto-generated method stub

	}

	@Override
	public void onStatusChanged(String provider, int status, Bundle extras)
	{
		// TODO Auto-generated method stub

	}

	@Override
	public void onProviderEnabled(String provider)
	{
		// TODO Auto-generated method stub

	}

	@Override
	public void onProviderDisabled(String provider)
	{
		// TODO Auto-generated method stub

	}

	@Override
	public void onMapReady(GoogleMap mapa)
	{
		// TODO Auto-generated method stub
		mapa.clear();
		LatLng posicion = new LatLng(latitudGps, longitudGps);

		mapa.setMyLocationEnabled(true);
		if (latitudGps != 0 && longitudGps != 0)
		{ 
			mapa.moveCamera(CameraUpdateFactory.newLatLngZoom(posicion, 15));
			mapa.addMarker(new MarkerOptions().position(posicion).title("Ubicación").snippet("Lat: " + latitudGps + " \nLng: " + longitudGps));
		}

	}

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        MenuInflater inflater = getMenuInflater();
        inflater.inflate(R.menu.menu_encuestas, menu);
        if (habilitarSalir == 1) {
            menu.getItem(0).setTitle(Mensajes.get("BTSalir"));
            menu.getItem(0).setEnabled(true);
        } else {
            menu.getItem(0).setVisible(false);
        }

        return true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        switch (item.getItemId()) {
            case R.id.salir:
                mensajeDialogo("¿Desea salir de la encuesta?", 1);
                break;

        }
        return true;
    }

    public void siguientePregunta() {

		contadorPregunta++;
		
		
		if(saltoActivo)
		{
			contadorEPID = contadorPregunta;
		}
		else
		{
			contadorEPID++;
		}
	//	Log.i(null,"Contador: "+contadorEPID);
		//  limpiarVariables();

		if (contadorPregunta >= 0 && contadorPregunta < preguntas.getCount())
		{
			preguntas.moveToPosition(contadorPregunta);

            if (preguntas.getInt("TipoRespuesta") == 7) {
                contadorPregunta = contadorPregunta + 1;
                if (contadorPregunta < preguntas.getCount()) {
                    preguntas.moveToPosition(contadorPregunta);
                }
            }

			tvPregunta.setTextSize(chequeoPregunta(preguntas.getString("Descripcion"),1));//mandamos el tamaño de la pregunta
			tvPregunta.setText(preguntas.getString("Descripcion"));//mostramos la pregunta
			//cargamos el tipo de pregunta
			pintarComponentes(preguntas.getInt("TipoRespuesta"), preguntas.getInt("CEPNumero"));
			//pasamos la configuracion de la pregunta
			tipoRespuesta = preguntas.getInt("TipoRespuesta");
			respuestaRequerida = preguntas.getInt("RespuestaRequerida");
			confirmacion = preguntas.getInt("Confirmacion");
			cantidadRequerida = preguntas.getInt("CantidadRequerida");

		}

		if (contadorPregunta >= preguntas.getCount())
		{
			contadorPregunta = preguntas.getCount() - 1;
			contadorEPID = contadorPregunta;
			try
			{
				//antes de que termine la encuesta modificaremos la horaFin de la encuesta
				Encuesta encuesta = new Encuesta();
				encuesta.ENCId = ENCId;
				encuesta.CENClave = sDiaClave;
				encuesta.VisitaClave = sVisitaClave;
				encuesta.DiaClave = sDiaClave;

				BDVend.recuperar(encuesta);
				
				encuesta.HoraFin = new Date();
				
				BDVend.guardarInsertar(encuesta);
				BDVend.commit();

			}
			catch (Exception e)
			{
				// TODO Auto-generated catch block
				e.printStackTrace();
			}

			//mensajeDialogo("¿Termino la encuesta?", 1);
			PreguntasEncuestas.this.finish();
			preguntas.close();
		}
		

		if (respuestaRequerida == 1)
		{
			respReq = false;
		}
		else
		{
			respReq = true;
		}

	}

	public void anteriorPregunta()
	{

		contadorPregunta--;
		if(saltoActivo)
		{
			contadorEPID = contadorPregunta;
		}
		else
		{
			contadorEPID--;
		}
		//Log.i(null,"Contador: "+contadorEPID);
		//limpiarVariables();

		if (contadorPregunta >= 0 && contadorPregunta < preguntas.getCount())
		{
			preguntas.moveToPosition(contadorPregunta);

            if (preguntas.getInt("TipoRespuesta") == 7) {
                contadorPregunta = contadorPregunta - 1;
                preguntas.moveToPosition(contadorPregunta);
            }

			tvPregunta.setTextSize(chequeoPregunta(preguntas.getString("Descripcion"),1));//mandamos el tamaño de la pregunta
			tvPregunta.setText(preguntas.getString("Descripcion"));//mostramos la pregunta
			//cargamos el tipo de respuesta
			pintarComponentes(preguntas.getInt("TipoRespuesta"), preguntas.getInt("CEPNumero"));
			//pasamos la configuracion de la pregunta
			tipoRespuesta = preguntas.getInt("TipoRespuesta");
			respuestaRequerida = preguntas.getInt("RespuestaRequerida");
			confirmacion = preguntas.getInt("Confirmacion");
			cantidadRequerida = preguntas.getInt("CantidadRequerida");
		}
		
		if (contadorPregunta < 0)
		{
			contadorPregunta = 0;
			contadorEPID = 0;
            /*if (habilitarSalir == 1)
            {
				try
				{
					BDVend.rollback();
				}
				catch (Exception e)
				{
					// TODO Auto-generated catch block
					e.printStackTrace();
				}
				mensajeDialogo("¿Desea salir de la encuesta?", 1);
			}*/
		}

		if (respuestaRequerida == 1)
		{
			respReq = false;
		}
		else
		{
			respReq = true;
		}

	
	}

	public void mensajeDialogo(String mensaje, final int apagar)
	{
		AlertDialog.Builder dialog = new AlertDialog.Builder(this);

		dialog.setMessage(mensaje);
		dialog.setCancelable(false);
		dialog.setPositiveButton(Mensajes.get("XSi"), new DialogInterface.OnClickListener()
		{

			@Override
			public void onClick(DialogInterface dialog, int which)
			{

				if (apagar == 0)
				{
					contestarPregunta(tipoRespuesta);
					siguientePregunta();
				}
				if (apagar == 1)
				{
                    try {
                        //mensajeDialogo("¿Desea salir de la encuesta?", 1);
                        BDVend.rollback();
                        PreguntasEncuestas.this.finish();
                        preguntas.close();
                    } catch (Exception e) {
                        // TODO Auto-generated catch block
                        e.printStackTrace();
                    }

                }
				if(apagar == 2)
				{
					startActivity(new Intent(android.provider.Settings.ACTION_LOCATION_SOURCE_SETTINGS));
				}
				

			}
		});
		dialog.setNegativeButton(Mensajes.get("XNo"), new DialogInterface.OnClickListener()
		{

			@Override
			public void onClick(DialogInterface dialog, int which)
			{
				dialog.cancel();

			}
		});
		dialog.show();
	}

	public void mensajeSimple(String mensaje)
	{
		AlertDialog.Builder dialog = new AlertDialog.Builder(this);

		dialog.setMessage(mensaje);
		dialog.setCancelable(false);
		dialog.setPositiveButton(Mensajes.get("XAceptar"), new DialogInterface.OnClickListener()
		{

			@Override
			public void onClick(DialogInterface dialog, int which)
			{
				dialog.cancel();
			}
		});
		dialog.show();

	}

	public void pintarComponentes(int tipoRespuesta, int cEPNumero)
	{
		llRespuesta.removeAllViews();

		CEPNumero = cEPNumero;

		switch (tipoRespuesta)
		{
			case 1: // si es tipo texto

				configTexto(CEPNumero, tipoRespuesta);

				break;

			case 2: // si es tipo numero
				configNumero(CEPNumero, tipoRespuesta);
				break;

			case 3://si es tipo opcional
				configOpcional(CEPNumero, tipoRespuesta);

				break;

			case 4:
				configCodigo(CEPNumero, tipoRespuesta);
				break;

			case 5:
				configImagen(CEPNumero, tipoRespuesta);

				break;

			case 6:
				configMatricial(CEPNumero, tipoRespuesta);
				break;

			case 7:

				break;

			case 8:
				configGPS(CEPNumero, tipoRespuesta);
				break;

		}
	}

	public void configTexto(int CEPNumero, int respuesta)
	{ //obtenemos la configuracion del componente
		ISetDatos configuracion = null;

		String CRTId;
		//int tipoConversion = 0; 
		String mascara;

		try
		{
			configuracion = Consultas2.ConsultasEncuestas.obtenerConfiguraciones("Select * from CEPRespTexto where CENClave = '" + clave + "' and CEPNumero='" + CEPNumero + "'");
			configuracion.moveToNext();
			CRTId = configuracion.getString("CRTId");
			tipoConversion = configuracion.getInt("TipoConversion");
			mascara = configuracion.getString("Mascara");
			tipoLimite = configuracion.getInt("TipoLimite");
			minimo = configuracion.getInt("Minimo");
			maximo = configuracion.getInt("Maximo");
		}
		catch (Exception e)
		{
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		//creamos el componente y agregamos la configuracion
		llRespuesta.setOrientation(LinearLayout.VERTICAL);

		if (tipoConversion != 4)
		{
			EditText edTexto = new EditText(llRespuesta.getContext());
			edTexto.setId(ID_DINAMICO);
			edTexto.setLayoutParams(new LayoutParams(LayoutParams.FILL_PARENT, LayoutParams.WRAP_CONTENT));
			edTexto.setTextColor(Color.BLACK);
			edTexto.setSingleLine(true);
			edTexto.setMaxLines(1);
			edTexto.setSelectAllOnFocus(true);
			
			llRespuesta.addView(edTexto);
			etDinamico = (EditText) findViewById(ID_DINAMICO); // tomamos las propiedades del texto que creamo y lo ponemos en el dinamico

			if (tipoLimite == 2) // si tipo limite es igual a dos entonces ponemos el maximo, despues se valua que no sobre pase el limite en el metodo validarMaxMIn
			{
				edTexto.setFilters(new InputFilter[]
				{ new InputFilter.LengthFilter(maximo) });
			}

			if (tipoConversion == 3)
			{
				edTexto.setInputType(InputType.TYPE_TEXT_FLAG_CAP_WORDS);

			}

			
		}
		else if (tipoConversion == 4)//si tiene una conversion tipo fecha pasa por aqui
		{

			DatePicker dpTexto = new DatePicker(llRespuesta.getContext());
			dpTexto.setId(ID_DINAMICO);
			dpTexto.setLayoutParams(parametros);
			dpTexto.setCalendarViewShown(false);
			llRespuesta.addView(dpTexto);
			dpDinamico = (DatePicker) findViewById(ID_DINAMICO);
		}
       
		if(configSalto(CEPNumero) && saltoActivo == false)// se valida que tenga salto, si es asi los componentes se bloquean
		{
			etDinamico.setEnabled(false);
		}
		
		if (enpid[contadorEPID] != null)
		{
			mostrarRespuesta(respuesta);
		}
		
		configuracion.close();

	}

	public void configNumero(int CEPNumero, int respuesta)
	{
		ISetDatos configuracion = null;
		String CRNId;

		try
		{
			configuracion = Consultas2.ConsultasEncuestas.obtenerConfiguraciones("Select * from CEPRespNumero where CENClave = '" + clave + "' and CEPNumero='" + CEPNumero + "'");
			configuracion.moveToNext();
			CRNId = configuracion.getString("CRNId");
			tipoLimite = configuracion.getInt("TipoLimite");
			minimo = configuracion.getInt("Minimo");
			maximo = configuracion.getInt("Maximo");
		}
		catch (Exception e)
		{
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
	
		llRespuesta.setOrientation(LinearLayout.VERTICAL);
		EditText edNumero = new EditText(llRespuesta.getContext());
		edNumero.setId(ID_DINAMICO);
		edNumero.setLayoutParams(parametros);
		edNumero.setTextColor(Color.BLACK);
		edNumero.setInputType(InputType.TYPE_CLASS_NUMBER);
		edNumero.setSelectAllOnFocus(true);
		llRespuesta.addView(edNumero);
		etDinamico = (EditText) findViewById(ID_DINAMICO);
		
		if (tipoLimite == 2) // si tipo limite es igual a dos entonces ponemos el maximo, despues se valua que no sobre pase el limite en el metodo validarMaxMIn
		{
            String lengthMaximo = String.valueOf(maximo);
            edNumero.setFilters(new InputFilter[]
                    {new InputFilter.LengthFilter(lengthMaximo.length())});
        }
		
		if(configSalto(CEPNumero) && saltoActivo == false)// se valida que tenga salto, si es asi los componentes se bloquean
		{
			etDinamico.setEnabled(false);
		}

		if (enpid[contadorEPID] != null)
		{
			
			mostrarRespuesta(respuesta);
		}
		
		configuracion.close();
	}

	public void configOpcional(int CEPNumero, int respuesta)
	{
		ISetDatos configuracion = null;

		try
		{ //nos traemos las configuraciones de la tabla CEPRespOpcional 
			configuracion = Consultas2.ConsultasEncuestas.obtenerConfiguraciones("Select * from CEPRespOpcional where CENClave = '" + clave + "' and CEPNumero='" + CEPNumero + "'");
			configuracion.moveToNext();
			CROId = configuracion.getString("CROId");
			tipoSeleccionOpcional = configuracion.getInt("TipoSeleccion");
			tipoLimite = configuracion.getInt("TipoLimite");
			minimo = configuracion.getInt("Minimo");
			maximo = configuracion.getInt("Maximo");
			rotativa = configuracion.getInt("Rotativa");
			condicion = configuracion.getInt("Condicion");
			tipoLimite2 = configuracion.getInt("TipoLimite1");
			minimo2 = configuracion.getInt("Minimo1");
			maximo2 = configuracion.getInt("Maximo1");
			tipoConversion = configuracion.getInt("TipoConversion");

			//con la variable CROId la utilizaremos para filtrar los comnponentes de la pregunta

			configuracionOpcional = Consultas2.ConsultasEncuestas.obtenerConfiguraciones("Select * from CROOpcion where CENClave = '" + clave + "' and CEPNumero='" + CEPNumero + "' and CROId= '" + CROId + "' order by Orden");
			configuracionOpcional.moveToNext();
			COOId = new String[configuracionOpcional.getCount()];// llenamos el arreglo con el numero de opciones que tiene

			llRespuesta.removeAllViewsInLayout();
			LinearLayout llOpcional = new LinearLayout(llRespuesta.getContext());
			llOpcional.setOrientation(LinearLayout.VERTICAL);
			ScrollView svOpcional = new ScrollView(llRespuesta.getContext());
			svOpcional.setLayoutParams(new LayoutParams(LayoutParams.MATCH_PARENT, LayoutParams.MATCH_PARENT));
			svOpcional.addView(llOpcional);
			llRespuesta.addView(svOpcional);
			llRespuesta.setOrientation(LinearLayout.VERTICAL);

			//validamos que tipo de seleccion es
			if (tipoSeleccionOpcional == 1)// validamos que el tipo de seleccion sea opcional
			{

				if (configuracionOpcional.getCount() == 2)//si solo trae dos opciones entonces se utilizara radio button, de lo contario check
				{
					configComponentes = configuracionOpcional.getCount();// asignamos aqui el valor  de los componentes que tiene
					RadioGroup rgOpcional = new RadioGroup(llOpcional.getContext());
					rgOpcional.setLayoutParams(parametros);
					rgOpcional.setOrientation(RadioGroup.VERTICAL);

					rbDinamico = new RadioButton[configuracionOpcional.getCount()];

					for (int x = 0; x < configuracionOpcional.getCount(); x++)
					{
						
						rbDinamico[x] = new RadioButton(rgOpcional.getContext());
						rbDinamico[x].setText(configuracionOpcional.getString("Descripcion").toString());
						rbDinamico[x].setId(Integer.parseInt(configuracionOpcional.getString("Numero")));
						rgOpcional.addView(rbDinamico[x]);
						COOId[x] = configuracionOpcional.getString("COOId");
						configuracionOpcional.moveToNext();
						
						if(configSalto(CEPNumero) && saltoActivo == false)// se valida que tenga salto, si es asi los componentes se bloquean
						{
							rbDinamico[x].setEnabled(false);
						}
					}

					llOpcional.addView(rgOpcional);

				}
				else
				//de lo contrario va ser checkbox
				{
					configComponentes = configuracionOpcional.getCount();// asignamos aqui el valor  de los componentes que tiene
					cbDinamico = new CheckBox[configuracionOpcional.getCount()];
					for (int x = 0; x < configuracionOpcional.getCount(); x++)
					{

						cbDinamico[x] = new CheckBox(llOpcional.getContext());
						cbDinamico[x].setLayoutParams(parametros);
						cbDinamico[x].setText(configuracionOpcional.getString("Descripcion").toString());
						llOpcional.addView(cbDinamico[x]);
						COOId[x] = configuracionOpcional.getString("COOId");
						configuracionOpcional.moveToNext();
					}

				}
			}

			if (tipoSeleccionOpcional == 2)//validamos que sea de tipo texto
			{

				etDinamico2 = new EditText[configuracionOpcional.getCount()];
				dtDinamico = new DatePicker[configuracionOpcional.getCount()];
				tvDinamico = new TextView[configuracionOpcional.getCount()];
				configComponentes = configuracionOpcional.getCount();
				
				for (int x = 0; x < configuracionOpcional.getCount(); x++)
				{ //primero agregamos los titulos
					tvDinamico[x] = new TextView(llOpcional.getContext());
					tvDinamico[x].setLayoutParams(parametros);
					tvDinamico[x].setText(configuracionOpcional.getString("Descripcion").toString());
					llOpcional.addView(tvDinamico[x]);

					if (tipoConversion != 4) // validamos que el tipo conversion no sea fecha 
					{
						etDinamico2[x] = new EditText(llOpcional.getContext());
						etDinamico2[x].setLayoutParams(parametros);
						etDinamico2[x].setTextColor(Color.BLACK);
						etDinamico2[x].setSingleLine(true);
						etDinamico2[x].setMaxLines(1);
						etDinamico2[x].setSelectAllOnFocus(true);
						
						if (tipoLimite2 == 2) // si tipo limite es igual a dos entonces ponemos el maximo, despues se valua que no sobre pase el limite en el metodo validarMaxMIn
						{
							etDinamico2[x].setFilters(new InputFilter[]
							{ new InputFilter.LengthFilter(maximo2) });
						}
					
						if (tipoConversion == 3)
						{
							etDinamico2[x].setInputType(InputType.TYPE_TEXT_FLAG_CAP_WORDS);
						}
						llOpcional.addView(etDinamico2[x]);
					}
					else
					// aqui es fecha
					{
						dtDinamico[x] = new DatePicker(llOpcional.getContext());
						dtDinamico[x].setLayoutParams(parametros);
						dtDinamico[x].setCalendarViewShown(false);
						llOpcional.addView(dtDinamico[x]);
					}
					COOId[x] = configuracionOpcional.getString("COOId");
					configuracionOpcional.moveToNext();

				}

			}

			if (tipoSeleccionOpcional == 3)//Validamos que sean de tipo numero
			{
				etDinamico2 = new EditText[configuracionOpcional.getCount()];
				tvDinamico = new TextView[configuracionOpcional.getCount()];
				configComponentes = configuracionOpcional.getCount();
				
				for (int x = 0; x < configuracionOpcional.getCount(); x++)
				{

					//primero agregamos los titulos
					tvDinamico[x] = new TextView(llOpcional.getContext());
					tvDinamico[x].setLayoutParams(parametros);
					tvDinamico[x].setText(configuracionOpcional.getString("Descripcion").toString());
					llOpcional.addView(tvDinamico[x]);

					etDinamico2[x] = new EditText(llOpcional.getContext());
					etDinamico2[x].setLayoutParams(parametros);
					etDinamico2[x].setTextColor(Color.BLACK);
					etDinamico2[x].setInputType(InputType.TYPE_CLASS_NUMBER);
					etDinamico2[x].setSelectAllOnFocus(true);
					if (tipoLimite == 2) // si tipo limite es igual a dos entonces ponemos el maximo, despues se valua que no sobre pase el limite en el metodo validarMaxMIn
					{
						etDinamico2[x].setFilters(new InputFilter[]
						{ new InputFilter.LengthFilter(maximo) });
					}
					llOpcional.addView(etDinamico2[x]);

					COOId[x] = configuracionOpcional.getString("COOId");
					configuracionOpcional.moveToNext();

				}
			}

		}
		catch (Exception e)
		{
			// TODO Auto-generated catch block
			
			e.printStackTrace();
		}
		
		
		if (enpid[contadorEPID] != null)
		{

			mostrarRespuesta(respuesta);
		}
		
		configuracion.close();

	}
	
	public void configCodigo(int CEPNumero, int respuesta)
	{
		ISetDatos configuracion = null;
		String CRCId = "";

		try
		{
			configuracion = Consultas2.ConsultasEncuestas.obtenerConfiguraciones("Select * from CEPRespCodigo where CENClave = '" + clave + "' and CEPNumero='" + CEPNumero + "'");
			configuracion.moveToNext();
			CRCId = configuracion.getString("CRCId");
			tipoCodigo = configuracion.getInt("TipoCodigo");
		}
		catch (Exception e)
		{
			// TODO Auto-generated catch block
			e.printStackTrace();
		}

		/* codigo para crear los componentes del escaner */
		llRespuesta.setOrientation(LinearLayout.HORIZONTAL); //CHECA ESTO SI TIENES EL ERROR DE QUE NO SE PUEDEN ACOMODAR BIEN LOS COMPONENTES
		llRespuesta.setWeightSum(1f);

		LinearLayout ll1 = new LinearLayout(llRespuesta.getContext());
		LinearLayout.LayoutParams p1 = new LinearLayout.LayoutParams(0, LinearLayout.LayoutParams.WRAP_CONTENT);
		p1.weight = .85f;

		LinearLayout ll2 = new LinearLayout(llRespuesta.getContext());
		LinearLayout.LayoutParams p2 = new LinearLayout.LayoutParams(0, LinearLayout.LayoutParams.WRAP_CONTENT);
		p2.weight = .15f;
		ll2.setGravity(Gravity.RIGHT);

		llRespuesta.addView(ll1, p1);
		llRespuesta.addView(ll2, p2);

		etScanner = new EditText(new ContextThemeWrapper(llRespuesta.getContext(), R.style.GeneralEditText));
		etScanner.setLayoutParams(new LayoutParams(LayoutParams.MATCH_PARENT, LayoutParams.WRAP_CONTENT));
		etScanner.setSelectAllOnFocus(true);
		etScanner.setSingleLine(true);
		etScanner.setMaxLines(1);
		ll1.addView(etScanner);

		btScanner = new ImageButton(llRespuesta.getContext());
		btScanner.setId(ID_SCANNER);
		btScanner.setLayoutParams(new LayoutParams(LayoutParams.MATCH_PARENT, LayoutParams.WRAP_CONTENT));
		btScanner.setImageResource(drawable.codigo_barras);
		btScanner.setBackgroundColor(Color.TRANSPARENT);
		ll2.addView(btScanner);

		btScanner.setOnClickListener(this);

		if (enpid[contadorEPID] != null)
		{
		
			mostrarRespuesta(respuesta);
		}
		
		configuracion.close();
	}
	
	public void configImagen(int CEPNumero, int respuesta)
	{
		ISetDatos configuracion = null;
		String CRIId = "";
		tomoFoto = false;
		try
		{
			configuracion = Consultas2.ConsultasEncuestas.obtenerConfiguraciones("Select * from CEPRespImagen where CENClave = '" + clave + "' and CEPNumero = '" + CEPNumero + "'");
			configuracion.moveToNext();
			CRIId = configuracion.getString("CRIId");
			calidad = configuracion.getInt("Calidad");

			
		}
		catch (Exception e)
		{
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		llRespuesta.setOrientation(LinearLayout.VERTICAL);
		ibFotos = new ImageButton(llRespuesta.getContext());
		ibFotos.setId(ID_FOTO);
		ibFotos.setImageResource(drawable.camara);
		ibFotos.setLayoutParams(new LayoutParams(LayoutParams.MATCH_PARENT, LayoutParams.MATCH_PARENT));
		ibFotos.setBackgroundColor(Color.parseColor("#F5F5F5"));
		ibFotos.setAdjustViewBounds(true);
		ibFotos.setDrawingCacheEnabled(true);
		ibFotos.buildDrawingCache();

		llRespuesta.addView(ibFotos);

		ibFotos.setOnClickListener(this);

		if (enpid[contadorEPID] != null)
		{
			
			mostrarRespuesta(respuesta);
		}
        
		configuracion.close();
	}
	
	public void configGPS(int CEPNumero, int respuesta)
	{
		ISetDatos configuracion = null;
		String CRGId;
		int altitud = 0;
		int longitud = 0;
		int latitud = 0;
		int fecha = 0;
		int hora = 0;

		try
		{
			configuracion = Consultas2.ConsultasEncuestas.obtenerConfiguraciones("Select * From CEPRespGPS where CENClave = '" + clave + "' and CEPNumero = '" + CEPNumero + "'");
			configuracion.moveToNext();
			altitud = configuracion.getInt("Altitud");
			latitud = configuracion.getInt("Latitud");
			longitud = configuracion.getInt("Longitud");
			fecha = configuracion.getInt("Fecha");
			hora = configuracion.getInt("Hora");

		}
		catch (Exception e)
		{
			// TODO Auto-generated catch block
			e.printStackTrace();
		}

		llRespuesta.setOrientation(LinearLayout.VERTICAL);

		//Codigo para crear un mapa dinamicamente 
		mapaFragmento = MapFragment.newInstance(); //Inicializamos el fragmento para reutilizarlo 
		FragmentTransaction transacion = getFragmentManager().beginTransaction();
		transacion.add(R.id.llRespuesta, mapaFragmento);
		transacion.commit();
		mapaFragmento.getMapAsync(this);

		Button btRefrescar = new Button(llRespuesta.getContext());
		btRefrescar.setText("Actualizar posición");
		btRefrescar.setId(ID_REFRESCAR);

		llRespuesta.addView(btRefrescar);
		btRefrescar.setOnClickListener(this);

		LocationManager locali;
		String provider;

		locali = (LocationManager) getSystemService(Context.LOCATION_SERVICE);
		Criteria c = new Criteria();
		c.setAccuracy(Criteria.ACCURACY_FINE);
		provider = locali.getBestProvider(c, true);

		locali.requestLocationUpdates(provider, 10000, 1, (LocationListener) llRespuesta.getContext());
		loc = locali.getLastKnownLocation(provider);

		latitudGps = 0;
		longitudGps = 0;
		altitudGps = 0;

		if (locali.isProviderEnabled(LocationManager.GPS_PROVIDER))
		{

			if (loc != null)
			{
				int mapaChequeo = 0;

				if (altitud != 0)
				{
					//tvAltitud.setText("Altitud: " + String.valueOf(loc.getAltitude()));
					altitudGps = loc.getAltitude();
				}

				if (longitud != 0)
				{
					//tvLongitud.setText("Longitud: " + String.valueOf(loc.getLongitude()));
					longitudGps = loc.getLongitude();
					mapaChequeo++;
				}

				if (latitud != 0)
				{
					//tvLatitud.setText("Latitud: " + String.valueOf(loc.getLatitude()));
					latitudGps = loc.getLatitude();
					mapaChequeo++;
				}
				if (fecha != 0)
				{

					try
					{
						SimpleDateFormat formatoFecha = new SimpleDateFormat("dd/MM/yyyy");
						String fechaString = formatoFecha.format(new Date());

						
						fechaGps = formatoFecha.parse(fechaString);
						

					}
					catch (ParseException e)
					{
						// TODO Auto-generated catch block
						e.printStackTrace();
					}

				}

				if (hora != 0)
				{

					try
					{
						SimpleDateFormat formatoFecha = new SimpleDateFormat("hh:mm:ss");
						String horaString = formatoFecha.format(new Date());

						
						horaGps = formatoFecha.parse(horaString);
						

					}
					catch (ParseException e)
					{
						// TODO Auto-generated catch block
						e.printStackTrace();
					}

				}

				if (mapaChequeo == 2)
				{
					//btMapa.setEnabled(true);
				}
				if (mapaChequeo < 2)
				{
					btRefrescar.setEnabled(false);
				}
			}

		  configuracion.close();

		}
		else
		{
		
			mensajeDialogo(Mensajes.get("P0236"), 2);
			/*
			 * tvLongitud.setText("Longitud: "); tvLatitud.setText("Latitud: ");
			 * tvAltitud.setText("Altitud: ");
			 */
			//btMapa.setEnabled(false);
		}

		if (enpid[contadorEPID] != null)
		{
			
			mostrarRespuesta(respuesta);
		}

	}
	
	public void configMatricial(int CEPNumero, int respuesta)
	{
		ISetDatos preguntas = null;
		ISetDatos respuestas = null;

		int numCheckBox = 0;
		int numTexto = 0;
		int numNumero = 0;
		

		try
		{
			preguntas = Consultas2.ConsultasEncuestas.obtenerConfiguraciones("Select * from CEPPregMatricial where CENClave = '" + clave + "' and CEPNumero = " + CEPNumero + " order by Orden");
			respuestas = Consultas2.ConsultasEncuestas.obtenerConfiguraciones("Select * from CEPRespMatricial where CENClave = '" + clave + "' and CEPNumero = " + CEPNumero + " order by Orden");
			numCheckBox = Consultas2.ConsultasEncuestas.obtenerTotalCompMatricial(clave, CEPNumero, 1);
			numTexto = Consultas2.ConsultasEncuestas.obtenerTotalCompMatricial(clave, CEPNumero, 2);
			numNumero = Consultas2.ConsultasEncuestas.obtenerTotalCompMatricial(clave, CEPNumero, 3);

		}
		catch (Exception e)
		{
			// TODO Auto-generated catch block
			e.printStackTrace();
		}

		//empecemaos creando los componentes necesarios para crear la tabla
		llRespuesta.setOrientation(LinearLayout.VERTICAL);

		LayoutParams parametrosTabla = new LayoutParams(new LayoutParams(LayoutParams.MATCH_PARENT, LayoutParams.MATCH_PARENT));

		HorizontalScrollView hsvTabla = new HorizontalScrollView(llRespuesta.getContext()); //creamos un scroll horizontal
		ScrollView vsvTabla = new ScrollView(llRespuesta.getContext());//creamos un scroll vertical
		TableLayout tblMatricial = new TableLayout(llRespuesta.getContext());
		tblMatricial.setLayoutParams(parametrosTabla);
		hsvTabla.setFocusable(false);
		hsvTabla.setFocusableInTouchMode(false);
		/*
		 * hsvTabla.addView(tblMatricial);//ponemos la tabla en el horizontal
		 * primero vsvTabla.addView(hsvTabla);// depues lo ponemos en el
		 * vertical
		 */
		vsvTabla.addView(tblMatricial);
		hsvTabla.addView(vsvTabla);

		TableRow.LayoutParams layoutCabecera = new TableRow.LayoutParams(TableRow.LayoutParams.WRAP_CONTENT, TableRow.LayoutParams.WRAP_CONTENT);
		TableRow.LayoutParams layoutCelda = new TableRow.LayoutParams(TableRow.LayoutParams.WRAP_CONTENT, TableRow.LayoutParams.WRAP_CONTENT);

		TableRow fila = new TableRow(llRespuesta.getContext());
		fila.setLayoutParams(layoutCabecera);

		CPMNumero = new int[preguntas.getCount()];

		for (int y = 0; y <= preguntas.getCount(); y++)
		{//columnas
			TextView txtId; // creamos un textView para colocar los titulos

			if (y == 0)
			{ // si es igual a 0 difujara solo un separador / para llenar ese espacio vacio

				txtId = new TextView(this); // lo inicializamos

				//le ponemos las propiedades
				txtId.setText("/");
				txtId.setGravity(Gravity.CENTER_HORIZONTAL);
				txtId.setTextAppearance(this, R.style.titulos);
				txtId.setBackgroundResource(R.drawable.tabla_cabecera);
				txtId.setLayoutParams(layoutCelda);

				fila.addView(txtId); // lo agregamos a la columna
			}
			else
			// de lo contrario empezara a llenar los titulos de manera concecutiva
			{

				txtId = new TextView(this); // inicializamos de nuevo la variable para colocar otro

				//ponemos las propiedades
				preguntas.moveToNext();

				CPMNumero[y - 1] = preguntas.getInt("CPMNumero");
			
				txtId.setText(preguntas.getString("Descripcion"));
				txtId.setGravity(Gravity.CENTER_HORIZONTAL);
				txtId.setTextAppearance(this, R.style.titulos);
				txtId.setBackgroundResource(R.drawable.tabla_cabecera);
				txtId.setLayoutParams(layoutCelda);
				fila.addView(txtId);// lo agregamos a la columna
			}

		}

		tblMatricial.addView(fila);// por ultimo agregamos la columna a la tabla

		//la siguiente es la tabla donde ira las preguntas y las respuestas, se hace de esta manera
		//por que queremos que se valla por filas y no por columnas como se hiso en el otro metodo
		TableRow fila2;//se crea una variable de tipo tabla fila
		TextView txtId2;// se genera el componente donde ira escrito

		checkMatricial = new CheckBox[numCheckBox];
		textoMatricial = new EditText[numTexto];
		numeroMatricial = new EditText[numNumero];

		respuestasCount = respuestas.getCount();
		preguntasCount = preguntas.getCount();

		int indiceCheck = 0;
		int indiceTexto = 0;
		int indiceNumero = 0;
		tipoValorCount = new int[respuestas.getCount()];
		
		CRMNumero = new int[respuestas.getCount()];

		for (int i = 1; i <= respuestas.getCount(); i++)
		{ //el for recorrera todas las filas de la tabla de los datos 
			fila2 = new TableRow(llRespuesta.getContext());

			txtId2 = new TextView(llRespuesta.getContext());
			int tipoValor = 0;

			for (int x = 0; x <= preguntas.getCount(); x++)
			{ //este for se utiliza para poner exactamente el valor (columnas)

				txtId2.setGravity(Gravity.CENTER_HORIZONTAL);
				txtId2.setLayoutParams(layoutCelda);

				if (x == 0)
				{ // aqui se ponen las preguntas
					respuestas.moveToNext();
					tipoValor = respuestas.getInt("TipoValor");
					
					CRMNumero[i - 1] = respuestas.getInt("CRMNumero");

					tipoValorCount[i - 1] = respuestas.getInt("TipoValor");
					txtId2.setText(respuestas.getString("Descripcion"));
					txtId2.setTextAppearance(this, R.style.etiqueta);
					txtId2.setBackgroundResource(R.drawable.tabla_celda);
					txtId2.setTextColor(Color.WHITE);
					txtId2.setBackgroundColor(Color.parseColor("#ce260b"));
					fila2.addView(txtId2);
				}
				else
				{//aqui se ponen los componentes
					if (tipoValor == 1)
					{
						checkMatricial[indiceCheck] = new CheckBox(llRespuesta.getContext());
						checkMatricial[indiceCheck].setBackgroundResource(R.drawable.tabla_celda);
						checkMatricial[indiceCheck].setPadding(0, 13, 0, 10);
						fila2.addView(checkMatricial[indiceCheck]);
						indiceCheck++;
					}
					if (tipoValor == 2)
					{
						textoMatricial[indiceTexto] = new EditText(llRespuesta.getContext());
						textoMatricial[indiceTexto].setGravity(Gravity.CENTER);
						textoMatricial[indiceTexto].setLayoutParams(layoutCelda);
						textoMatricial[indiceTexto].setBackgroundResource(R.drawable.tabla_celda);
						textoMatricial[indiceTexto].setSingleLine(true);
						textoMatricial[indiceTexto].setMaxLines(1);
						textoMatricial[indiceTexto].selectAll();
						textoMatricial[indiceTexto].setSelectAllOnFocus(true);
						textoMatricial[indiceTexto].setFilters(new InputFilter[]{ new InputFilter.LengthFilter(50) });
						fila2.addView(textoMatricial[indiceTexto]);
						indiceTexto++;
					}
					if (tipoValor == 3)
					{
						numeroMatricial[indiceNumero] = new EditText(llRespuesta.getContext());
						numeroMatricial[indiceNumero].setInputType(InputType.TYPE_CLASS_NUMBER);
						numeroMatricial[indiceNumero].setGravity(Gravity.CENTER);
						numeroMatricial[indiceNumero].setLayoutParams(layoutCelda);
						numeroMatricial[indiceNumero].setBackgroundResource(R.drawable.tabla_celda);
						numeroMatricial[indiceNumero].setSelectAllOnFocus(true);
						numeroMatricial[indiceNumero].setFilters(new InputFilter[]{ new InputFilter.LengthFilter(50) });
						fila2.addView(numeroMatricial[indiceNumero]);
						indiceNumero++;
					}
				}

				txtId2 = null;// borramos lo que tenga dentro para reutilizarlo
				txtId2 = new TextView(this);//lo inicializamos de nuevo para que genere nueva memoria

			}

			tblMatricial.addView(fila2);//por ultimo cargamos a la tabla
		}

		llRespuesta.addView(hsvTabla);

		
		if (enpid[contadorEPID] != null)
		{
		
			mostrarRespuesta(respuesta);
		}
		
		preguntas.close();
		respuestas.close();

	}
	
	public boolean configSalto(int CEPNumero)
	{
		ISetDatos configuracion = null;
		String CRSId = "";
		boolean hayRegistros = false;

		try
		{
			configuracion = Consultas2.ConsultasEncuestas.obtenerConfiguraciones("Select * from CEPRespSalto where CENClave = '" + clave + "' and CEPNumero1 = '" + CEPNumero + "'");
			
			if (configuracion.getCount() > 0)
			{
				configuracion.moveToNext();
				CEPNumero1 = configuracion.getInt("CEPNumero1");
				CEPNumero2 = configuracion.getInt("CEPNumero2");
				CEPNumero3 = configuracion.getInt("CEPNumero3");
				tipoOperadorSig = configuracion.getInt("TipoOperadorSig");
				tipoCondicion = configuracion.getInt("TipoCondicion");
				valor = configuracion.getString("Valor");
				tipoValor = configuracion.getInt("TipoValor");
				tipoCanOpcion = configuracion.getInt("TipoCanOpcion");
				terminar = configuracion.getInt("Terminar");
				hayRegistros = true;
				
			}

		}
		catch (Exception e)
		{
			// TODO Auto-generated catch block
			
			e.printStackTrace();
		}
        
		configuracion.close();
		return hayRegistros;

	}
	
	public boolean validarCampoVacio(int tipoRespuesta)

	{
		boolean vacio = false;

		switch (tipoRespuesta)
		{
			case 1:
				if (etDinamico.getText().toString().equals(""))
				{
					vacio = true;
				}
				if (tipoConversion == 4)
				{
					vacio = false;
				}

				break;
			case 2:

				if (etDinamico.getText().toString().equals(""))
				{
					vacio = true;
				}
				break;
			case 3:

				int checarVacio = 0;//esta variable se utiliza para checar si tiene vacios los componentes, si se queda en 0 es que estan vacios todos lo componentes

				if (tipoSeleccionOpcional == 1) //radio button y check box
				{
					if (configComponentes == 2)
					{

						
						for (int x = 0; x <= configComponentes - 1; x++)
						{
							if (rbDinamico[x].isChecked())
							{
								checarVacio++;
							}
							if (checarVacio > 0)
							{
								vacio = false;
							}
							else
							{
								vacio = true;
							}
						}
					}
					else
					{
						
						for (int x = 0; x <= configComponentes - 1; x++)
						{
							if (cbDinamico[x].isChecked())
							{
								checarVacio++;
							}
							if (checarVacio > 0)
							{
								vacio = false;
							}
							else
							{
								vacio = true;
							}
						}
					}
				}
				if (tipoSeleccionOpcional == 2)
				{
					if (tipoConversion != 4) // validamos que el tipo conversion no sea fecha 
					{
						for (int x = 0; x <= configComponentes - 1; x++)
						{

							if (!etDinamico2[x].getText().toString().equals(""))
							{
								checarVacio++;
							}
							if (checarVacio > 0)
							{
								vacio = false;
							}
							else
							{
								vacio = true;
							}
						}
					}
					else
					{
						vacio = false;
					}
				}
				if (tipoSeleccionOpcional == 3)
				{
					for (int x = 0; x <= configComponentes - 1; x++)
					{

						if (!etDinamico2[x].getText().toString().equals(""))
						{
							checarVacio++;
						}
						if (checarVacio > 0)
						{
							vacio = false;
						}
						else
						{
							vacio = true;
						}
					}
				}
				break;
			case 4:
				if (etScanner.getText().toString().equals(""))
				{
					vacio = true;
				}

				break;
			case 5:
				if (!tomoFoto)
				{
					vacio = true;
				}

				break;
			case 6:
				vacio = false;
				break;
			case 7:

				break;
			case 8:
				vacio = false;
				break;

		}

		return vacio;
	}
	
	public boolean validarMaxMin(int tipoRespuesta)
	{
		boolean validar = false;
		
		switch (tipoRespuesta)
		{
			case 1:
				
				if (tipoLimite == 2)
				{
					if (etDinamico.getText().length() >= minimo && etDinamico.getText().length() <= maximo)
					{
						validar = true;
					}
					else
					{
						//mensajeSimple("E0309 - La respuesta se encuentra fuera del Rango, Mínimo " + minimo + " y Máximo " + maximo);
						mensajeSimple(Mensajes.get("E0309",String.valueOf(minimo),String.valueOf(maximo)));
					}
				}
				else
				{
					validar = true;
				}

				break;
			case 2:
				
			
				if (tipoLimite == 2)
				{

                    // if (minimo >= Integer.parseInt(etDinamico.getText().toString()) && maximo <= Integer.parseInt(etDinamico.getText().toString()) ) {
                    if (etDinamico.getText().equals("") || etDinamico.getText().length() <= 0) {
                        etDinamico.setText("0");
                    }

                    if (Integer.parseInt(etDinamico.getText().toString()) >= minimo && Integer.parseInt(etDinamico.getText().toString()) <= maximo) {
                        validar = true;
                    } else
					{
						//mensajeSimple("E0309 - La respuesta se encuentra fuera del Rango, Mínimo " + minimo + " y Máximo " + maximo);
						mensajeSimple(Mensajes.get("E0309",String.valueOf(minimo),String.valueOf(maximo)));
					}
				}
				else
				{
					validar = true;
				}
				break;
			case 3:
				
			
				int chequeo = 0;
				int checar = 0;
				int checarLosDos = 0;
				
				Log.i(null,"Tipo limite: "+tipoLimite+" Tipo limite 2: "+tipoLimite2);
				
				if(tipoLimite == 2)//seccion para validar el limite de opciones
				{

					for(int y = 0; y <=configComponentes -1; y++) // este for sirve para ver cuantos compnentes fueron contestados y la variable chequeo se suma por cada componente con respuesta.
					{
						if (tipoSeleccionOpcional == 1) //radio button y check box
						{
							if (configComponentes == 2)
							{
							    if (rbDinamico[y].isChecked())
								{
									chequeo++;

								}
							}
							else
							{

								if (cbDinamico[y].isChecked())
								{

									chequeo++;
								}

							}
						}

						if (tipoSeleccionOpcional == 2)//texto
						{
							if (tipoConversion != 4) // validamos que el tipo conversion no sea fecha 
							{

								if (!etDinamico2[y].getText().toString().equals(""))
								{
                                   chequeo++;
								}

							}

						}

						if (tipoSeleccionOpcional == 3)//numero
						{
							if (!etDinamico2[y].getText().toString().equals(""))
							{
                                chequeo++;
							}

						}
					}
					
					if(chequeo >= minimo && chequeo <= maximo)
					{
						
						if(tipoLimite2 == 2)
						{
							validar = false;
							checarLosDos++;
						}
						else
						{
							validar = true;
						}
					
					}
					else
					{
						mensajeSimple(Mensajes.get("E0311",String.valueOf(minimo),String.valueOf(maximo)));
						
					}
						
				}				
				
				
				if (tipoLimite2 == 2) //seccion para validar el limite de letras
				{
					
          
					for (int x = 0; x <= configComponentes - 1; x++)
					{
						if (tipoLimite == 2)
						{
							if (tipoSeleccionOpcional == 2 || tipoSeleccionOpcional == 3 )//texto
							{
								if (tipoConversion != 4) // validamos que el tipo conversion no sea fecha 
								{

									if (!etDinamico2[x].getText().toString().equals(""))
									{
										if (etDinamico2[x].getText().length() >= minimo2 && etDinamico2[x].getText().length() <= maximo2)
										{
											checar++;
										}
									}

								}

							}
                            
						}
						else
						{
							if (etDinamico2[x].getText().length() >= minimo2 && etDinamico2[x].getText().length() <= maximo2)
							{
								checar++;
							}
							else
							{
								checar = 0;
								break;
							}
						}
					}
					
					if (checar <= 0)
					{			
						mensajeSimple(Mensajes.get("E0309",String.valueOf(minimo2),String.valueOf(maximo2)));
					}
					else
					{
						if(tipoLimite == 2)
						{
							checarLosDos++;
							validar = false;
						}
						else
						{
							validar = true;
						}
					}
				}
				
				
			   if(checarLosDos == 2)
			   {
				   validar = true;
				   Log.i(null, "Es verdadero");
				   
			   }
				
				
				if(tipoLimite == 1 && tipoLimite2 == 1)
				{
				  validar = true;
				}
				

				// validar = true;
				break;
			case 4:
				validar = true;
				break;
			case 5:
				validar = true;
				break;
			case 6:
				Log.i(null,"Respuesta requerida: "+respuestaRequerida+" Cantidad requerida: "+cantidadRequerida);
				int indiceCheck = 0;
				int indiceTexto = 0;
				int indiceNumero = 0;
				int conteo = 0;

				for (int x = 0; x < respuestasCount; x++)
				{
					
					
					for (int y = 0; y < preguntasCount; y++)
					{
						//Log.i(null,"Conteo tipo valor "+ tipoValorCount[y]);
						
						if (tipoValorCount[x] == 1)
						{
							
							if (checkMatricial[indiceCheck] != null)
							{
								//Log.i(null,"Length: "+checkMatricial.length+" indice: "+indiceCheck);
								if (checkMatricial[indiceCheck].isChecked())
								{
									//Log.i(null, "Pasa 1 true");
									conteo++;
									//Log.i(null, "Conteo: "+conteo);
								}
								else
								{
									//Log.i(null, "No pasa 1");
								}
							}

							indiceCheck++;
						}
						
						if (tipoValorCount[x] == 2)
						{
							if (textoMatricial[indiceTexto] != null)
							{
						
								if (textoMatricial[indiceTexto].getText().toString().trim().length() > 0)
								{
									//Log.i(null, "Pasa 2 "+textoMatricial[indiceTexto].getText());
									conteo++;
									//Log.i(null, "Conteo: "+conteo);
								}
								else
								{
								//	Log.i(null, "No pasa 2");
								}
							}
							indiceTexto++;
						}
						
						if (tipoValorCount[x] == 3)
						{

							if (numeroMatricial[indiceNumero] != null)
							{
								
								if (numeroMatricial[indiceNumero].getText().toString().trim().length() > 0 )
								{
									//Log.i(null, "Pasa 3 "+numeroMatricial[indiceNumero].getText());
									conteo++;
									//Log.i(null, "Conteo: "+conteo);
								}
								else
								{
									//Log.i(null, "No pasa 3");
								}
							}
							indiceNumero++;
						}
                       
						
					}
					
					//Log.i(null,"el conteo de la vuelta "+x+" es de "+conteo+"____________________");
					//conteo = 0;
				}
				//validar = true;
				//Log.i(null, "cantidad requerida: "+cantidadRequerida+" conte: "+conteo);
				if(respuestaRequerida == 1)
				{
					if(conteo >= cantidadRequerida )
					{
						validar = true;
					}
					else
					{
						mensajeSimple("Mensaje");
					}
				}
				else
				{
					validar = true;
				}

				break;
			case 7:

				break;
			case 8:
				validar = true;
				break;

		}

		return validar;
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
	
	public void obtenerCordenadas()
	{
		LocationManager locali;
		String provider;

		locali = (LocationManager) getSystemService(Context.LOCATION_SERVICE);
		Criteria c = new Criteria();
		c.setAccuracy(Criteria.ACCURACY_FINE);
		provider = locali.getBestProvider(c, true);

		locali.requestLocationUpdates(provider, 10000, 1, (LocationListener) llRespuesta.getContext());
		loc = locali.getLastKnownLocation(provider);

		if (locali.isProviderEnabled(LocationManager.GPS_PROVIDER))
		{
			if (loc != null)
			{
				
				if (latitudGps != loc.getLatitude() && altitudGps != loc.getLongitude())
				{
			

					latitudGps = loc.getLatitude();
					longitudGps = loc.getLongitude();
					altitudGps = loc.getAltitude();

				}
				else
				{
					mensajeSimple(Mensajes.get("I0291"));

				}
			}
			else
			{
				mensajeSimple(Mensajes.get("I0292"));
			}
		}
		else
		{
			mensajeDialogo(Mensajes.get("P0236"), 2);

		}
	}
	
	public void contestarPregunta(int tipoRespuesta)
	{
		
		switch (tipoRespuesta)
		{
			case 1:

				insertarENCPregunta(CEPNumero, contadorPregunta); // primero insertamos en ENCPregunta

				if (tipoConversion != 4)
				{
					String contenido = etDinamico.getText().toString();
					
					if (tipoConversion == 1)
					{
				       contenido = contenido.toLowerCase();
					}
					if (tipoConversion == 2)
					{
						contenido = contenido.toUpperCase();
					}
					
					insertarTexto(contenido);
				

				}
				else
				{
					int day = dpDinamico.getDayOfMonth();
					int month = dpDinamico.getMonth();
					int year = dpDinamico.getYear();

					//Calendar fecha = Calendar.getInstance();
					//fecha.set(year, month, day);
					SimpleDateFormat formatoFecha = new SimpleDateFormat("dd/MM/yyyy");
					@SuppressWarnings("deprecation")
					String fechaFormato = formatoFecha.format(new Date(year - 1900, month, day));

					insertarTexto(fechaFormato);
					
				}

				if (configSalto(preguntas.getInt("CEPNumero")) && saltoActivo == true )
				{

					if (validacionesSalto(etDinamico.getText().toString(), valor))//checar antes
					{
						
						if (terminar == 1)
						{
							//mensajeDialogo("¿Termino la encuesta?", 1);
							PreguntasEncuestas.this.finish();
							preguntas.close();
						}
						else
						{

                            try {
                                contadorPregunta = Consultas2.ConsultasEncuestas.obtenerOrdenSalto(CEPNumero2, clave) - 2;
                                if (contadorPregunta < 0) {
                                    contadorPregunta = -1;
                                }
                            } catch (Exception e) {
                                // TODO Auto-generated catch block

                                e.printStackTrace();
                            }

                        }

                    }
                }


                break;
            case 2:

                insertarENCPregunta(CEPNumero, contadorPregunta); // primero insertamos en ENCPregunta

                Log.i(null, "Pasa: " + etDinamico.getText().toString());
                if (etDinamico.getText().toString().equals("")) {
                    insertarNumero(0);
                } else {
                    insertarNumero(Float.parseFloat(etDinamico.getText().toString()));
                }

                if (configSalto(preguntas.getInt("CEPNumero")) && saltoActivo == true) {
                    if (validacionesSalto(String.valueOf(etDinamico.getText().toString()), valor)) {

                        if (terminar == 1) {
                            //mensajeDialogo("¿Termino la encuesta?", 1);
                            PreguntasEncuestas.this.finish();
                            preguntas.close();
                        } else {

                            try {
                                contadorPregunta = Consultas2.ConsultasEncuestas.obtenerOrdenSalto(CEPNumero2, clave) - 2;
                                if (contadorPregunta < 0) {
                                    contadorPregunta = -1;
                                }
                            } catch (Exception e) {
                                // TODO Auto-generated catch block

                                e.printStackTrace();
                            }

                        }
                    }
                }


                break;
            case 3:
				insertarENCPregunta(CEPNumero, contadorPregunta);

				if (tipoSeleccionOpcional == 1) //radio button y check box
				{
					if (configComponentes == 2)
					{
						
						for (int x = 0; x <= configComponentes - 1; x++)
						{

							if (rbDinamico[x].isChecked())
							{
								insertarOpcional("1", COOId[x]);
								
								if (configSalto(preguntas.getInt("CEPNumero")) && saltoActivo == true)
								{

									if (validacionesSalto(String.valueOf(rbDinamico[x].getId()), valor))
									{
										
										if (terminar == 1)
										{
											//mensajeDialogo("¿Termino la encuesta?", 1);
											PreguntasEncuestas.this.finish();
											preguntas.close();
										}
										else
										{

                                            try {
                                                contadorPregunta = Consultas2.ConsultasEncuestas.obtenerOrdenSalto(CEPNumero2, clave) - 2;
                                                if (contadorPregunta < 0) {
                                                    contadorPregunta = -1;
                                                }
                                            } catch (Exception e) {
                                                // TODO Auto-generated catch block

                                                e.printStackTrace();
                                            }

                                        }
                                    }
                                }
                            } else
							{
								insertarOpcional("0", COOId[x]);
							}
							
							
						}

					}
					else
					{

                        int saltoCheck = 0;

                        for (int x = 0; x <= configComponentes - 1; x++) {
                            if (cbDinamico[x].isChecked()) {

                                saltoCheck = x + 1;

                                insertarOpcional("1", COOId[x]);
                            } else {
                                insertarOpcional("0", COOId[x]);
                            }

                        }

                        if (configSalto(preguntas.getInt("CEPNumero")) && saltoActivo == true) {

                            if (validacionesSalto(String.valueOf(saltoCheck), valor)) {

                                if (terminar == 1) {
                                    //mensajeDialogo("¿Termino la encuesta?", 1);
                                    PreguntasEncuestas.this.finish();
                                    preguntas.close();
                                } else {
                                    try {
                                        contadorPregunta = Consultas2.ConsultasEncuestas.obtenerOrdenSalto(CEPNumero2, clave) - 2;
                                        if (contadorPregunta < 0) {
                                            contadorPregunta = -1;
                                        }
                                    } catch (Exception e) {
                                        // TODO Auto-generated catch block

                                        e.printStackTrace();
                                    }


                                }
                            }
                        }


                    }
                }

				if (tipoSeleccionOpcional == 2)//texto
				{
					if (tipoConversion != 4) // validamos que el tipo conversion no sea fecha 
					{
						for (int x = 0; x <= configComponentes - 1; x++)
						{

							//if (!etDinamico2[x].getText().toString().equals(""))
							//{
								String contenidoOpcional = etDinamico2[x].getText().toString();
								
								if (tipoConversion == 1)
								{
									contenidoOpcional = contenidoOpcional.toLowerCase();
								}
								if (tipoConversion == 2)
								{
									contenidoOpcional = contenidoOpcional.toUpperCase();
								}
								
								insertarOpcional(contenidoOpcional, COOId[x]);
						//	}

						}
					}
					else
					{
						for (int x = 0; x <= configComponentes - 1; x++)
						{
							//aqui va las fechas
							int day = dtDinamico[x].getDayOfMonth();
							int month = dtDinamico[x].getMonth();
							int year = dtDinamico[x].getYear();

							SimpleDateFormat formatoFecha = new SimpleDateFormat("yyyy/MM/dd");
							@SuppressWarnings("deprecation")
							String fechaFormato = formatoFecha.format(new Date(year - 1900, month, day));

							insertarOpcional(fechaFormato, COOId[x]);
						

						}
					}
				}
				if (tipoSeleccionOpcional == 3)//numero
				{
					for (int x = 0; x <= configComponentes - 1; x++)
					{

					//	if (!etDinamico2[x].getText().toString().equals(""))
					//	{
						
							insertarOpcional(etDinamico2[x].getText().toString(), COOId[x]);
						//}

					}
				}
				break;
			case 4:

				insertarENCPregunta(CEPNumero, contadorPregunta);
				insertarCodigo(etScanner.getText().toString());
				

				if (configSalto(preguntas.getInt("CEPNumero")))
				{

					if (validacionesSalto(etScanner.getText().toString(), valor))//checar antes
					{
						if (terminar == 1)
						{
						//	mensajeDialogo("¿Termino la encuesta?", 1);
							PreguntasEncuestas.this.finish();
							preguntas.close();
						}
						else
						{
                            try {
                                contadorPregunta = Consultas2.ConsultasEncuestas.obtenerOrdenSalto(CEPNumero2, clave) - 2;
                                if (contadorPregunta < 0) {
                                    contadorPregunta = -1;
                                }
                            } catch (Exception e) {
                                // TODO Auto-generated catch block

                                e.printStackTrace();
                            }

                        }

                    }
                }


                break;

			case 5:

				
				if (tituloFoto == null)
				{
					tituloFoto = "";
					insertarENCPregunta(CEPNumero, contadorPregunta);
					insertarImagen(tituloFoto);
				}
				else
				{
					insertarENCPregunta(CEPNumero, contadorPregunta);
					insertarImagen(tituloFoto);
				}
				break;

			case 6:

				insertarENCPregunta(CEPNumero, contadorPregunta);

				int indiceCheck = 0;
				int indiceTexto = 0;
				int indiceNumero = 0;

				for (int x = 0; x < respuestasCount; x++)
				{
					
					for (int y = 0; y < preguntasCount; y++)
					{
						if (tipoValorCount[x] == 1)
						{
							if (checkMatricial[indiceCheck] != null)
							{
								if (checkMatricial[indiceCheck].isChecked())
								{
									insertarMatricial("1", CEPNumero, CPMNumero[y], CRMNumero[x]);
								}
								else
								{
									insertarMatricial("0", CEPNumero, CPMNumero[y], CRMNumero[x]);
								}
							}
							indiceCheck++;
						}
						else if (tipoValorCount[x] == 2)
						{
							if (textoMatricial[indiceTexto] != null)
							{
						
								if (!textoMatricial[indiceTexto].getText().equals(""))
								{
									insertarMatricial(textoMatricial[indiceTexto].getText().toString(), CEPNumero, CPMNumero[y], CRMNumero[x]);
									
								}
							}
							indiceTexto++;
						}
						else if (tipoValorCount[x] == 3)
						{

							if (numeroMatricial[indiceNumero] != null)
							{
								if (!numeroMatricial[indiceNumero].getText().equals(""))
								{
									insertarMatricial(numeroMatricial[indiceNumero].getText().toString(), CEPNumero, CPMNumero[y], CRMNumero[x]);
									
								}
							}
							indiceNumero++;
						}
                       
						
					}
				}

				break;
			case 7:

				break;
			case 8:
		
				insertarENCPregunta(CEPNumero, contadorPregunta);
				insertarGPS(altitudGps, longitudGps, latitudGps, fechaGps, horaGps);
				
				break;
		}
	}
	
	public boolean validacionesSalto(String valor1, String valor2)
	{
		boolean valor = false;
      // Log.i(null,"numero de condicion: "+tipoCondicion+" Valor 1: "+valor1+" Valor 2: "+valor2);
		switch (tipoCondicion)
		{
			case 1:

                if (valor1.toUpperCase().equals(valor2.toUpperCase())) {
					valor = true;
				}
				break;

			case 2:
                if (valor1.toUpperCase() != valor2.toUpperCase()) {
					valor = true;
				}
				break;
			case 3:

				break;

			case 4:
				int v1 = Integer.parseInt(valor1);
				int v2 = Integer.parseInt(valor2);
				if (v1 == v2)
				{
					valor = true;
				}
				break;

			case 5:
				int v3 = Integer.parseInt(valor1);
				int v4 = Integer.parseInt(valor2);
				if (v3 > v4)
				{
					valor = true;
				}
				break;
			case 6:
				int v5 = Integer.parseInt(valor1);
				int v6 = Integer.parseInt(valor2);
				if (v5 >= v6)
				{
					valor = true;
				}
				break;
			case 7:
				int v7 = Integer.parseInt(valor1);
				int v8 = Integer.parseInt(valor2);

				if (v7 < v8)
				{
					valor = true;
				}

				break;
			case 8:
				int v9 = Integer.parseInt(valor1);
				int v10 = Integer.parseInt(valor2);
				if (v9 <= v10)
				{
					valor = true;
				}
				break;
			case 9:
				int v11 = Integer.parseInt(valor1);
				int v12 = Integer.parseInt(valor2);
				if (v11 != v12)
				{
					valor = true;
				}
				break;
			case 10:
				int v13 = Integer.parseInt(valor1);
				int v14 = Integer.parseInt(valor2);
				if (v13 == v14)
				{
					valor = true;
				}

				break;
			case 11:
				int v15 = Integer.parseInt(valor1);
				int v16 = Integer.parseInt(valor2);
				if (v15 != v16)
				{
					valor = true;
				}

				break;

		}
		return valor;
	}
	
	public void insertarEncuesta()
	{

		Encuesta nuevaEncuesta = new Encuesta();
		nuevaEncuesta.ENCId = ENCId;
		nuevaEncuesta.CENClave = clave;
		nuevaEncuesta.VisitaClave = sVisitaClave;
		nuevaEncuesta.DiaClave = sDiaClave;
		nuevaEncuesta.Fase = 1;
		nuevaEncuesta.Fecha = sFechaInicio;
		nuevaEncuesta.HoraInicio = sHoraInicio;
		nuevaEncuesta.HoraFin = sHoraInicio;
		nuevaEncuesta.MFechaHora = new Date();
		nuevaEncuesta.MUsuarioId = sUsuarioID;

		try
		{
			BDVend.guardarInsertar(nuevaEncuesta);
			//BDVend.commit();
			
		}
		catch (Exception e)
		{
			// TODO Auto-generated catch block
			e.printStackTrace();
		}

	}
	
	public void insertarENCPregunta(int CEPNumero, int ordenAplicacion)
		{
			if (enpid[contadorEPID] == null)
			{
				ENPId = KeyGen.getId();
				ENCPregunta encPregunta = new ENCPregunta();
				encPregunta.ENCId = ENCId;
				encPregunta.ENPId = ENPId;
				encPregunta.CENClave = clave;
				encPregunta.CEPNumero = CEPNumero;
				encPregunta.OrdenAplicacion = ordenAplicacion + 1;
				encPregunta.MFechaHora = new Date();
				encPregunta.MUsuarioId = sUsuarioID;
	
				try
				{
					BDVend.guardarInsertar(encPregunta);
					//BDVend.commit();
				}
				catch (Exception e)
				{
					// TODO Auto-generated catch block
					e.printStackTrace();
				}
	
				enpid[contadorEPID] = ENPId;
				
			}
		}
		
	public void insertarTexto(String descripcion)
		{
			String ERTId = "";
			try
			{
				if (enpid[contadorEPID] != null)
				{
					
					ERTId = Consultas2.ConsultasEncuestas.obtenerIdRespuesta("ENPRespTexto", "ERTId", enpid[contadorEPID]);

				}
	
				ENPRespTexto enpRespTexto = new ENPRespTexto();
	
				if (ERTId != "")
				{
					enpRespTexto.ENCId = ENCId;
					enpRespTexto.ENPId = enpid[contadorEPID];
					enpRespTexto.ERTId = ERTId;
	
					BDVend.recuperar(enpRespTexto);
	
					enpRespTexto.Descripcion = descripcion;
					enpRespTexto.MFechaHora = new Date();
					enpRespTexto.MUsuarioId = sUsuarioID;
	
				}
				else
				{
					enpRespTexto.ENCId = ENCId;
					enpRespTexto.ENPId = ENPId;
					enpRespTexto.ERTId = KeyGen.getId();
					enpRespTexto.Descripcion = descripcion;
					enpRespTexto.MFechaHora = new Date();
					enpRespTexto.MUsuarioId = sUsuarioID;
				}
	
				BDVend.guardarInsertar(enpRespTexto);
				//BDVend.commit();
			}
			catch (Exception e)
			{
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
	
		}
	
	public void insertarNumero(float valor)
	{
		String ERNId = "";
		try
		{
			if (enpid[contadorEPID] != null)
			{
				
				ERNId = Consultas2.ConsultasEncuestas.obtenerIdRespuesta("ENPRespNumero", "ERNId", enpid[contadorEPID]);
				
			}

			ENPRespNumero enpRespNumero = new ENPRespNumero();


			if (ERNId != "")
			{
				enpRespNumero.ENCId = ENCId;
				enpRespNumero.ENPId = enpid[contadorEPID];
				enpRespNumero.ERNId = ERNId;

				BDVend.recuperar(enpRespNumero);

				enpRespNumero.Valor = valor;
				enpRespNumero.MFechaHora = new Date();
				enpRespNumero.MUsuarioId = sUsuarioID;

			}
			else
			{
				enpRespNumero.ENCId = ENCId;
				enpRespNumero.ENPId = ENPId;
				enpRespNumero.ERNId = KeyGen.getId();
				enpRespNumero.Valor = valor;
				enpRespNumero.MFechaHora = new Date();
				enpRespNumero.MUsuarioId = sUsuarioID;
			}

			BDVend.guardarInsertar(enpRespNumero);
			//BDVend.commit();

		}
		catch (Exception e)
		{
			// TODO Auto-generated catch block
			e.printStackTrace();
		}

	
	}
	
	public void insertarOpcional(String valor, String cooid)
	{

		String EROId = "";
		try
		{
			if (enpid[contadorEPID] != null)
			{
				
				String where = enpid[contadorEPID] + "' and COOId = '" + cooid;
				EROId = Consultas2.ConsultasEncuestas.obtenerIdRespuesta("ENPRespOpcional", "EROId", where);
			
			}

			ENPRespOpcional enpRespOpcional = new ENPRespOpcional();

	
			if (EROId != "")
			{

				enpRespOpcional.ENCId = ENCId;
				enpRespOpcional.ENPId = enpid[contadorEPID];
				enpRespOpcional.EROId = EROId;
				enpRespOpcional.CENClave = clave;
				enpRespOpcional.CEPNumero = CEPNumero;
				enpRespOpcional.CROId = CROId;
				enpRespOpcional.COOId = cooid;

				BDVend.recuperar(enpRespOpcional);

				enpRespOpcional.Valor = valor;
				enpRespOpcional.MFechaHora = new Date();
				enpRespOpcional.MUsuarioId = sUsuarioID;

			}
			else
			{
				enpRespOpcional.ENCId = ENCId;
				enpRespOpcional.ENPId = enpid[contadorEPID];
				enpRespOpcional.EROId = KeyGen.getId();
				enpRespOpcional.CENClave = clave;
				enpRespOpcional.CEPNumero = CEPNumero;
				enpRespOpcional.CROId = CROId;
				enpRespOpcional.COOId = cooid;
				enpRespOpcional.Valor = valor;
				enpRespOpcional.MFechaHora = new Date();
				enpRespOpcional.MUsuarioId = sUsuarioID;
			}

			BDVend.guardarInsertar(enpRespOpcional);
			//BDVend.commit();

		}
		catch (Exception e)
		{
			// TODO Auto-generated catch block
			e.printStackTrace();
		}

	}
	
	public void insertarCodigo(String codigo)
	{
		String ERCId = "";

		try
		{
			if (enpid[contadorEPID] != null)
			{
				
				ERCId = Consultas2.ConsultasEncuestas.obtenerIdRespuesta("ENPRespCodigo", "ERCId", enpid[contadorEPID]);
			
			}

			ENPRespCodigo enpRespCodigo = new ENPRespCodigo();

		
			if (ERCId != "")
			{
				enpRespCodigo.ENCId = ENCId;
				enpRespCodigo.ENPId = enpid[contadorEPID];
				enpRespCodigo.ERCId = ERCId;

				BDVend.recuperar(enpRespCodigo);

				enpRespCodigo.Codigo = codigo;
				enpRespCodigo.MFechaHora = new Date();
				enpRespCodigo.MUsuarioId = sUsuarioID;

			}
			else
			{

				enpRespCodigo.ENCId = ENCId;
				enpRespCodigo.ENPId = ENPId;
				enpRespCodigo.ERCId = KeyGen.getId();
				enpRespCodigo.Codigo = codigo;
				enpRespCodigo.MFechaHora = new Date();
				enpRespCodigo.MUsuarioId = sUsuarioID;

			}

			BDVend.guardarInsertar(enpRespCodigo);
			//BDVend.commit();
		}
		catch (Exception e)
		{
			// TODO Auto-generated catch block
			e.printStackTrace();
		}


	}
	
	public void insertarMatricial(String valor, int CEPNumero, int CPMNumero, int CRMNumero)
	{
		
		
		
		String ERMId = "";

		try
		{
			if (enpid[contadorEPID] != null)
			{
	
				String where = enpid[contadorEPID] + "' and CPMNumero = " + CPMNumero + " and CRMNumero = '"+CRMNumero;
				ERMId = Consultas2.ConsultasEncuestas.obtenerIdRespuesta("ENPRespMatricial", "ERMId", where);
		
			}

			ENPRespMatricial enpRespMatricial = new ENPRespMatricial();

			if (ERMId != "")
			{	
				enpRespMatricial.ENCId = ENCId;
				enpRespMatricial.ENPId = enpid[contadorEPID];
				enpRespMatricial.ERMId = ERMId;
				enpRespMatricial.CENClave = clave;
				enpRespMatricial.CEPNumero = CEPNumero;
				enpRespMatricial.CPMNumero = CPMNumero;
				enpRespMatricial.CENClave1 = clave;
				enpRespMatricial.CEPNumero1 = CEPNumero;
				enpRespMatricial.CRMNumero = CRMNumero;
			
				BDVend.recuperar(enpRespMatricial);
				
				enpRespMatricial.Valor = valor;
				enpRespMatricial.MFechaHora = new Date();
				enpRespMatricial.MUsuarioId = sUsuarioID;

			}
			else
			{
				enpRespMatricial.ENCId = ENCId;
				enpRespMatricial.ENPId = ENPId;
				enpRespMatricial.ERMId = KeyGen.getId();
				enpRespMatricial.CENClave = clave;
				enpRespMatricial.CEPNumero = CEPNumero;
				enpRespMatricial.CPMNumero = CPMNumero;
				enpRespMatricial.CENClave1 = clave;
				enpRespMatricial.CEPNumero1 = CEPNumero;
				enpRespMatricial.CRMNumero = CRMNumero;
				enpRespMatricial.Valor = valor;
				enpRespMatricial.MFechaHora = new Date();
				enpRespMatricial.MUsuarioId = sUsuarioID;

			}

			BDVend.guardarInsertar(enpRespMatricial);
			//BDVend.commit();
		}
		catch (Exception e)
		{
			// TODO Auto-generated catch block
			e.printStackTrace();
		}

	}
	
	public void insertarGPS(double alt, double lon, double lat, Date fecha, Date hora)
	{
		String ERGId = "";
		try
		{
			if (enpid[contadorEPID] != null)
			{
			
				ERGId = Consultas2.ConsultasEncuestas.obtenerIdRespuesta("ENPRespGPS", "ERGId", enpid[contadorEPID]);

			}

			ENPRespGPS enpRespGps = new ENPRespGPS();

			if (ERGId != "")
			{
				enpRespGps.ENCId = ENCId;
				enpRespGps.ENPId = ENPId;
				enpRespGps.ERGId = ERGId;

				BDVend.recuperar(enpRespGps);

				enpRespGps.Altitud = alt;
				enpRespGps.Latitud = lat;
				enpRespGps.Longitud = lon;
				enpRespGps.Fecha = fecha;
				enpRespGps.Hora = hora;
				enpRespGps.MFechaHora = new Date();
				enpRespGps.MUsuarioId = sUsuarioID;

			}
			else
			{
				enpRespGps.ENCId = ENCId;
				enpRespGps.ENPId = ENPId;
				enpRespGps.ERGId = KeyGen.getId();
				enpRespGps.Altitud = alt;
				enpRespGps.Latitud = lat;
				enpRespGps.Longitud = lon;
				enpRespGps.Fecha = fecha;
				enpRespGps.Hora = hora;
				enpRespGps.MFechaHora = new Date();
				enpRespGps.MUsuarioId = sUsuarioID;
			}

			BDVend.guardarInsertar(enpRespGps);
			//BDVend.commit();

		}
		catch (Exception e)
		{
			// TODO Auto-generated catch block
			e.printStackTrace();
		}

	}
	
	public void insertarImagen(String foto)
	{
		String ERIId = "";
		try
		{
			if (enpid[contadorEPID] != null)
			{
			
				ERIId = Consultas2.ConsultasEncuestas.obtenerIdRespuesta("ENPRespImagen", "ERIId", enpid[contadorEPID]);

			}

			ENPRespImagen enpRespImagen = new ENPRespImagen();


			if (ERIId != "")
			{
				enpRespImagen.ENCId = ENCId;
				enpRespImagen.ENPId = enpid[contadorEPID];
				enpRespImagen.ERIId = ERIId;

				BDVend.recuperar(enpRespImagen);

				enpRespImagen.Imagen = foto;
				enpRespImagen.MFechaHora = new Date();
				enpRespImagen.MUsuarioId = sUsuarioID;

			}
			else
			{

				enpRespImagen.ENCId = ENCId;
				enpRespImagen.ENPId = ENPId;
				enpRespImagen.ERIId = KeyGen.getId();
				enpRespImagen.Imagen = foto;
				enpRespImagen.MFechaHora = new Date();
				enpRespImagen.MUsuarioId = sUsuarioID;

			}
			BDVend.guardarInsertar(enpRespImagen);
			//BDVend.commit();
		}
		catch (Exception e)
		{
			// TODO Auto-generated catch block
			e.printStackTrace();
		}

	}
	
	public void mostrarRespuesta(int tipoRes)
	{
		ISetDatos traerDatos = null;
		String consulta = "";

		switch (tipoRes)
		{
			case 1://Texto
				consulta = "Select Descripcion from ENPRespTexto where ENPId = '" + enpid[contadorEPID] + "'";
				try
				{
					traerDatos = Consultas2.ConsultasEncuestas.obtenerConfiguraciones(consulta);
					traerDatos.moveToNext();

					if (tipoConversion == 4)
					{

						TextView tvFecha = new TextView(llRespuesta.getContext());
						tvFecha.setText(traerDatos.getString("Descripcion"));
						tvFecha.setLayoutParams(parametros);
						tvFecha.setTextSize(20);
						tvFecha.setGravity(Gravity.CENTER);
						llRespuesta.addView(tvFecha);

					}
					else
					{
						etDinamico.setText(traerDatos.getString("Descripcion"));
					}
				}
				catch (Exception e)
				{
					// TODO Auto-generated catch block
					e.printStackTrace();
				}
				break;

			case 2://Numero

				consulta = "Select Valor from ENPRespNumero where ENPId = '" + enpid[contadorEPID] + "'";

				try
				{
					traerDatos = Consultas2.ConsultasEncuestas.obtenerConfiguraciones(consulta);
					traerDatos.moveToNext();
					etDinamico.setText(traerDatos.getString("Valor"));

				}
				catch (Exception e)
				{
					// TODO Auto-generated catch block
					e.printStackTrace();
				}

				break;

			case 3://opcional

				consulta = "Select Valor from ENPRespOpcional where ENPId = '" + enpid[contadorEPID] + "'";
				try
				{
					traerDatos = Consultas2.ConsultasEncuestas.obtenerConfiguraciones(consulta);
					traerDatos.moveToNext();
				}
				catch (Exception e1)
				{
					// TODO Auto-generated catch block
					e1.printStackTrace();
				}

				if (tipoSeleccionOpcional == 1) //radio button y check box
				{
					if (configComponentes == 2)
					{
			
						for (int x = 0; x <= configComponentes - 1; x++)
						{
							
							if (Integer.parseInt(traerDatos.getString("Valor")) == 1)
							{
						
								rbDinamico[x].setChecked(true);
							}
						
							traerDatos.moveToNext();
							

						}

					}
					else
					{
					
						for (int x = 0; x <= configComponentes - 1; x++)
						{

							if (Integer.parseInt(traerDatos.getString("Valor")) == 1)
							{
								cbDinamico[x].setChecked(true);
							}

							traerDatos.moveToNext();
						}
					}
				}

				if (tipoSeleccionOpcional == 2)//texto
				{
					if (tipoConversion != 4) // validamos que el tipo conversion no sea fecha 
					{
						
						for (int x = 0; x <= configComponentes - 1; x++)
						{

							etDinamico2[x].setText(traerDatos.getString("Valor"));

							traerDatos.moveToNext();

						}
					}
					else
					{
				
						for (int x = 0; x <= configComponentes - 1; x++)
						{
							//aqui va codigo 
							String texto = tvDinamico[x].getText().toString();

							texto = texto + "  " + traerDatos.getString("Valor");
							tvDinamico[x].setText(texto);

							traerDatos.moveToNext();

						}
					}
				}
				if (tipoSeleccionOpcional == 3)//numero
				{
			
					for (int x = 0; x <= configComponentes - 1; x++)
					{

						etDinamico2[x].setText(traerDatos.getString("Valor"));

						traerDatos.moveToNext();

					}
				}
				break;

			case 4://codigo
				consulta = "Select Codigo from ENPRespCodigo where ENPId = '" + enpid[contadorEPID] + "'";

				try
				{
					traerDatos = Consultas2.ConsultasEncuestas.obtenerConfiguraciones(consulta);
					traerDatos.moveToNext();
					etScanner.setText(traerDatos.getString("Codigo"));
				}
				catch (Exception e)
				{
					// TODO Auto-generated catch block
					e.printStackTrace();
				}
				break;

			case 5://foto
				consulta = "Select Imagen from ENPRespImagen where ENPId = '" + enpid[contadorEPID] + "'";

				try
				{
					traerDatos = Consultas2.ConsultasEncuestas.obtenerConfiguraciones(consulta);
					traerDatos.moveToNext();
					if (!traerDatos.getString("Imagen").equals(""))
					{
						tituloFoto = traerDatos.getString("Imagen");
						String imagen = ruta_fotos + tituloFoto + ".jpg";
						
						Bitmap bmap = BitmapFactory.decodeFile(imagen);
						ibFotos.setImageBitmap(bmap);
						tomoFoto = true;
					}
				}
				catch (Exception e)
				{
					// TODO Auto-generated catch block
					e.printStackTrace();
				}

				break;
			case 6://matricial
				consulta = "Select Valor from ENPRespMatricial where ENPId = '" + enpid[contadorEPID] + "'";
				try
				{
					traerDatos = Consultas2.ConsultasEncuestas.obtenerConfiguraciones(consulta);
					traerDatos.moveToNext();
				}
				catch (Exception e1)
				{
					// TODO Auto-generated catch block
					e1.printStackTrace();
				}
				
				int indiceCheck = 0;
				int indiceTexto = 0;
				int indiceNumero = 0;

			

				for (int x = 0; x < respuestasCount; x++)
				{
					
					for (int y = 0; y < preguntasCount; y++)
					{


						if (tipoValorCount[x] == 1)
						{
					
							if(Integer.parseInt(traerDatos.getString("Valor")) == 1)
							{
								checkMatricial[indiceCheck].setChecked(true);
							}
							traerDatos.moveToNext();
							indiceCheck++;
						}
						else if (tipoValorCount[x] == 2)
						{
							
							textoMatricial[indiceTexto].setText(traerDatos.getString("Valor"));
							traerDatos.moveToNext();
							indiceTexto++;
						}
						else if (tipoValorCount[x] == 3)
						{

						
							numeroMatricial[indiceNumero].setText(traerDatos.getString("Valor"));
							traerDatos.moveToNext();
							indiceNumero++;
						}

					}
				}
				break;
			case 7://salto
				consulta = "Select Descripcion from ENPRespTexto where ENPId = '" + enpid[contadorEPID] + "'";
				break;
			case 8://GPS
				consulta = "Select Altitud, Latitud, Longitud, Fecha, Hora from ENPRespGPS where ENPId = '" + enpid[contadorEPID] + "'";
				try
				{
					traerDatos = Consultas2.ConsultasEncuestas.obtenerConfiguraciones(consulta);
					traerDatos.moveToNext();
					latitudGps = traerDatos.getFloat("Latitud");
					longitudGps = traerDatos.getFloat("Longitud");
					mapaFragmento.getMapAsync(this);

				}
				catch (Exception e)
				{
					// TODO Auto-generated catch block
					e.printStackTrace();
				}
				break;
		}
	}

	public float chequeoPregunta(String pregunta, int accion)
	{

		float tamaño = 0;
		if (accion == 1)
		{
			if (pregunta.length() > 0 && pregunta.length() <= 50)
			{
				tamaño = 24;
			}
			if (pregunta.length() > 50 && pregunta.length() <= 100)
			{
				tamaño = 22;
			}
			if (pregunta.length() > 100 && pregunta.length() <= 150)
			{
				tamaño = 20;
			}
			if (pregunta.length() > 150 && pregunta.length() <= 200)
			{
				tamaño = 18;
			}
		}
		if(accion == 2)
		{
			
			if (pregunta.length() > 0 && pregunta.length() <= 20)
			{
				tamaño = 24;
			}
			if (pregunta.length() > 20 && pregunta.length() <= 40)
			{
				tamaño = 22;
			}
			if (pregunta.length() > 40 && pregunta.length() <= 60)
			{
				tamaño = 20;
			}
			if (pregunta.length() > 60 && pregunta.length() <= 80)
			{
				tamaño = 18;
			}
		}
		return tamaño;
	}
	

}
