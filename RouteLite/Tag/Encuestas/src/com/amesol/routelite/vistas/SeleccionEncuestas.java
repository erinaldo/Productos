package com.amesol.routelite.vistas;

import java.io.UnsupportedEncodingException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;

import com.amesol.routelite.R;
import android.content.Intent;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.os.Bundle;
import android.text.format.DateFormat;
import android.util.Log;
import android.view.KeyEvent;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.AdapterView;
import android.widget.AdapterView.OnItemClickListener;
import android.widget.ImageView;
import android.widget.ListView;
import android.widget.TextView;
import android.widget.Toast;

import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.datos.Cliente;
import com.amesol.routelite.datos.Dia;
import com.amesol.routelite.datos.ItemEncuesta;

import com.amesol.routelite.datos.Visita;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.basedatos.Consultas2;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.Enumeradores.RespuestaMsg;
import com.amesol.routelite.presentadores.act.ObtenerGPS;
import com.amesol.routelite.presentadores.act.SeleccionarEncuesta;
import com.amesol.routelite.presentadores.interfaces.ISeleccionEncuestas;
import com.amesol.routelite.vistas.generico.ItemEncuestaAdaptador;


public class SeleccionEncuestas extends Vista implements ISeleccionEncuestas
{
	 //TextView tvLayout;
	// ISetDatos sdEncuestas[]; // se crea la variable de la instancia 
	 ISetDatos prueba;
	 SeleccionarEncuesta sEncuesta; // se crea una variable
	 Date fechaActual = new Date();
	 ListView lv;
	 String visitaSesion;
	 String diaSesion;

	@Override
	public void onCreate(Bundle savedInstanceState)
	{
		// TODO Auto-generated method stub
		super.onCreate(savedInstanceState);
		setContentView(R.layout.seleccion_encuestas);

		setTitulo(Mensajes.get("XEncuestas")); //Mandas el titulo
		
		sEncuesta = new SeleccionarEncuesta(); //incialisamos la variable para utilizar sus metodos
	
		traerEncuestas();

		// seleccion de encuesta
		
		lv.setOnItemClickListener(new OnItemClickListener()  //este metodo se convoca al ser precionado un elemento de la lista
		{

			@Override
			public void onItemClick(AdapterView<?> parent, View view, int position, long id)
			{
				ItemEncuesta item = (ItemEncuesta) parent.getItemAtPosition(position);
				Intent intent = new Intent(SeleccionEncuestas.this, PreguntasEncuestas.class);
				intent.putExtra("titulo", item.getTitulo());
				intent.putExtra("id", item.getIdString());
				startActivity(intent);

			}
		});

	}


	@Override
	public void resultadoActividad(int requestCode, int resultCode, Intent data)
	{
		// TODO Auto-generated method stub
	}

	@Override
	public void respuestaMensaje(RespuestaMsg respuesta, int tipoMensaje)
	{
		// TODO Auto-generated method stub

	}

	@Override
	public void iniciar()
	{
		// TODO Auto-generated method stub

	}

	@Override
	public boolean onKeyDown(int keyCode, KeyEvent event)
	{
		switch (keyCode)
		{
			case KeyEvent.KEYCODE_BACK: //cacho el valor del "regreso"

				finalizar(); //con este metodo me regreso al menu anterior

				break;

		}
		// TODO Auto-generated method stub
		return super.onKeyDown(keyCode, event);
	}

	@Override
	protected void onRestart()
	{
		// TODO Auto-generated method stub
		super.onRestart();
		traerEncuestas();	

	}

	public void traerEncuestas()
	{
		try
		{
			 visitaSesion = ((Visita) Sesion.get(Campo.VisitaActual)).VisitaClave; ////////
			 diaSesion =  ((Dia) Sesion.get(Campo.DiaActual)).DiaClave; ///////////////////Nos traemos los datos desde la clase sesion
			 String  clienteSesion = ((Cliente)  Sesion.get(Campo.ClienteActual)).ClienteClave;/// 
			 
			 prueba = Consultas2.ConsultasEncuestas.obtenerEncuestasHibrido(clienteSesion, visitaSesion);

			

		}
		catch (Exception e)
		{
			Log.i(null, e.toString());
		}

		lv = (ListView) findViewById(R.id.lvEncuesta); //nos traemos la list view
		ArrayList<ItemEncuesta> obtenerItem = obtenerItems(); //creamos una variable de tipo arraylist y llamamos el metodo obtenerItems()
		ItemEncuestaAdaptador adaptador = new ItemEncuestaAdaptador(this, obtenerItem);//cargamos la lista al adaptador

		lv.setAdapter(adaptador);//mandamos el adaptador a la listview
	}

	private ArrayList<ItemEncuesta> obtenerItems() //en este metodo cargamos los datos de la bd a la lista
	{
		ArrayList<ItemEncuesta> items = new ArrayList<ItemEncuesta>();
		

			while(prueba.moveToNext())
			{

			String id = prueba.getString("CENClave").toString();
			String descripcion = prueba.getString("Descripcion").toString();
			String fase = "Sin contestar";
			String horaFin = "";
			try
			{
				if (Consultas2.ConsultasEncuestas.verificarContestarEncuesta(diaSesion, visitaSesion))
				{
					if (prueba.getString("Fase") != null)
					{
						fase = sEncuesta.faseString(prueba.getInt("Fase"));
					}
				
					if (prueba.getDate("HoraFin") != null)
					{
						horaFin = sEncuesta.fechaString(prueba.getDate("HoraFin"));
					}
				}
			}
			catch (Exception e)
			{
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
			
		
			byte[] imagen = prueba.getBlob(2);

			items.add(new ItemEncuesta(1, imagen, descripcion, fase, horaFin, id));
			}
			
			prueba.close();
				
		return items;
	}

}
