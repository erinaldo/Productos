package com.amesol.routelite.vistas;

import java.util.HashMap;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.view.KeyEvent;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.widget.AdapterView;
import android.widget.AdapterView.OnItemClickListener;
import android.widget.GridView;
import android.widget.TextView;

import com.amesol.routelite.R;
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.actividades.ModuloMov;
import com.amesol.routelite.actividades.ModuloMovDetalle;
import com.amesol.routelite.datos.Agenda;
import com.amesol.routelite.datos.Cliente;
import com.amesol.routelite.datos.Dia;
import com.amesol.routelite.datos.PuntoGPS;
import com.amesol.routelite.datos.Ruta;
import com.amesol.routelite.datos.Usuario;
import com.amesol.routelite.datos.Vendedor;
import com.amesol.routelite.datos.Visita;
import com.amesol.routelite.datos.VisitaHist;
import com.amesol.routelite.datos.basedatos.BDVend;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.basedatos.Consultas.ConsultasVisita;
import com.amesol.routelite.datos.utilerias.MOTConfiguracion;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.Enumeradores.RespuestaMsg;
import com.amesol.routelite.presentadores.Enumeradores.Resultados;
import com.amesol.routelite.presentadores.Enumeradores.TiposModuloMovDetalle;
import com.amesol.routelite.presentadores.act.SeleccionarActividadesVisita;
import com.amesol.routelite.presentadores.interfaces.IAtencionClientes;
import com.amesol.routelite.presentadores.interfaces.ICapturaPedido;
import com.amesol.routelite.presentadores.interfaces.IResumenMovVisita;
import com.amesol.routelite.presentadores.interfaces.ISeleccionActividadesVisita;
import com.amesol.routelite.utilerias.Generales;
import com.amesol.routelite.utilerias.KeyGen;
import com.amesol.routelite.vistas.generico.ModuloGridAdapter;

public class SeleccionActividadesVisita extends Vista implements ISeleccionActividadesVisita, OnItemClickListener
{
	SeleccionarActividadesVisita mPresenta;
	String visitaClave;
	Visita visita;
	VisitaHist visitaHist;
	PuntoGPS puntoGPS;
	HashMap<String, Object> parametros;
	ModuloMovDetalle actividad = null;
	ModuloGridAdapter gridAdapter = null;

	@SuppressWarnings("unchecked")
	@Override
	public void onCreate(Bundle savedInstanceState)
	{
		super.onCreate(savedInstanceState);
		String accion = getIntent().getAction();
		if (getIntent().getSerializableExtra("parametros") != null)
			parametros = (HashMap<String, Object>) getIntent().getSerializableExtra("parametros");
		setContentView(R.layout.seleccion_actividades_visita);
		deshabilitarBarra(true);
		crearVisita();
		mPresenta = new SeleccionarActividadesVisita(this, accion);
		mPresenta.iniciar();

		TextView lblDia = (TextView) findViewById(R.id.txtDia);
		TextView lblRuta = (TextView) findViewById(R.id.txtRuta);
		TextView lblCliente = (TextView) findViewById(R.id.txtCliente);

		lblDia.setText(Mensajes.get("XDiaTrabajo") + ": " + ((Dia) Sesion.get(Campo.DiaActual)).DiaClave);
		lblRuta.setText(Mensajes.get("XRuta") + ": " + ((Ruta) Sesion.get(Campo.RutaActual)).Descripcion);

		Cliente oClienteAct = (Cliente) Sesion.get(Campo.ClienteActual);

		lblCliente.setText(Mensajes.get("XCliente") + ": " + oClienteAct.RazonSocial);
	}

	@Override
	public boolean onKeyDown(int keyCode, KeyEvent event)
	{
		switch (keyCode)
		{
			case KeyEvent.KEYCODE_BACK:
				guardarVisita();
				finalizar();
				iniciarActividad(IAtencionClientes.class, false);
				return true;
				/*
				 * case KeyEvent.KEYCODE_SEARCH: //temporal, quitar de aqui
				 * HashMap<String, String> parametros = new HashMap<String,
				 * String>(); parametros.put("Esquema", Mensajes.get("XTodos"));
				 * parametros.put("Producto", ""); //pasarle el producto que se
				 * va a buscar
				 * iniciarActividadConResultado(IBuscaProducto.class, 0, "",
				 * parametros); //iniciarActividad(IBuscaProducto.class, false);
				 */
		}
		return super.onKeyDown(keyCode, event);
	}

	@Override
	public boolean onCreateOptionsMenu(Menu menu)
	{
		MenuInflater inflater = getMenuInflater();
		inflater.inflate(R.menu.menu_actividades_visita, menu);
		menu.getItem(0).setTitle(Mensajes.get("XTerminarVisita"));
		return true;
	}

	@Override
	public boolean onOptionsItemSelected(MenuItem item)
	{
		switch (item.getItemId())
		{
			case R.id.terminar:
				try
				{
					guardarVisita();
					finalizar();
					iniciarActividad(IAtencionClientes.class, false);
				}
				catch (Exception ex)
				{
					ex.printStackTrace();
				}
				return true;
			default:
				return super.onOptionsItemSelected(item);
		}
	}

	public void iniciar()
	{
	}

	public void mostrarActividades(ModuloMovDetalle[] modulosDetalle)
	{
		GridView gridview = (GridView) findViewById(R.id.gridVisitaAct);
		gridAdapter = new ModuloGridAdapter(this, R.layout.lista_grid_cliente, modulosDetalle);
		gridview.setAdapter(gridAdapter);
		gridview.setOnItemClickListener(this);
	}

	public Activity getActivity()
	{
		return this;
	}

	@Override
	public void resultadoActividad(int requestCode, int resultCode, Intent data)
	{
		if (actividad.getTipoIndice() == TiposModuloMovDetalle.COBRANZAMULTIPLE)
		{ // Cobranza
			if (resultCode == Resultados.RESULTADO_MAL)
			{
				String mensajeError = (String) data.getExtras().getString("mensajeIniciar");
				mostrarError(mensajeError);
			}
		}
		else if (actividad.getTipoIndice() == TiposModuloMovDetalle.PEDIDO)
		{
			if (resultCode == Resultados.RESULTADO_MAL)
			{
				// if(data.getExtras() != null){
				String mensajeError = (String) data.getExtras().getString("mensajeIniciar");
				if(mensajeError.startsWith("[P0086]"))
					mostrarPreguntaSiNo(mensajeError, 20);
				else
					mostrarError(mensajeError);
				// }
			}
		}
	}

	@Override
	public void respuestaMensaje(RespuestaMsg respuesta, int tipoMensaje)
	{
		if (tipoMensaje == 20 && respuesta == RespuestaMsg.Si){
			//no hay pedidos por surtir y contesto SI, ir a captura de pedido
			iniciarActividadConResultado(ICapturaPedido.class, 0, null);
		}
	}

	//	private OnClickListener mSelectActView = new OnClickListener()
	//	{
	//
	//		@Override
	//		public void onClick(DialogInterface dialog, int which)
	//		{
	//			// TODO Auto-generated method stub
	//			mPresenta.seleccionar();
	//		}
	//	};

	//	private OnItemClickListener mSeleccion = new OnItemClickListener()
	//	{
	//		public void onItemClick(AdapterView<?> parent, View v, int position, long id)
	//		{
	//			actividad = (ModuloMovDetalle) parent.getItemAtPosition(position);
	//			mPresenta.seleccionar();
	//		}
	//	};

	public ModuloMovDetalle getActividad()
	{
		return actividad;
	}

	private void crearVisita()
	{
		try
		{
			visita = new Visita();
			visitaHist = new VisitaHist();

			if (parametros.containsKey("visitaClave"))
			{
				visitaClave = (String) parametros.get("visitaClave");
				visita.VisitaClave = visitaClave;
				BDVend.recuperar(visita);
			}
			else
			{
				if (parametros.containsKey("nuevaVisita"))
				{
					Cliente cliente = (Cliente) Sesion.get(Campo.ClienteActual);

					Agenda agenda = Consultas.ConsultasAgenda.obtenerAgendaPorDiaClienteRutaVendedor((Dia) Sesion.get(Campo.DiaActual), (Ruta) Sesion.get(Campo.RutaActual), (Vendedor) Sesion.get(Campo.VendedorActual), cliente);
					if (agenda != null)
					{
						agenda.Visitado = 1; // marcar como visitado
						BDVend.guardarInsertar(agenda);
					}
				}

				visita.VisitaClave = KeyGen.getId();
				visita.DiaClave = ((Dia) Sesion.get(Campo.DiaActual)).DiaClave;
				visita.ClienteClave = ((Cliente) Sesion.get(Campo.ClienteActual)).ClienteClave;
				visita.VendedorId = ((Vendedor) Sesion.get(Campo.VendedorActual)).VendedorId;
				visita.RUTClave = ((Ruta) Sesion.get(Campo.RutaActual)).RUTClave;
				visita.Numero = Consultas.ConsultasVisita.obtenerConsecutivo((Dia) Sesion.get(Campo.DiaActual));
				visita.FechaHoraInicial = Generales.getFechaHoraActual();
				visita.FechaHoraFinal = visita.FechaHoraInicial;
				visita.TipoEstado = 1; // activo
				visita.FueraFrecuencia = (Boolean) parametros.get("FueraFrecuencia");
				visita.CodigoLeido = Integer.parseInt(parametros.get("CodigoLeido").toString()); // (Boolean)parametros.get("CodigoLeido");
				visita.GPSLeido = (Boolean) parametros.get("GPSLeido");
				visita.DistanciaGPS = (Float) parametros.get("DistanciaGPS");
				visita.Enviado = false;
				visita.MFechaHora = Generales.getFechaHoraActual();
				visita.MUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;
				BDVend.guardarInsertar(visita);

				if (visita.GPSLeido)
				{
					puntoGPS = new PuntoGPS();
					puntoGPS.PuntoGPSId = KeyGen.getId();
					puntoGPS.CoordenadaX = ((Double) parametros.get("LongitudGPS")).floatValue();
					puntoGPS.CoordenadaY = ((Double) parametros.get("LatitudGPS")).floatValue();
					puntoGPS.DiaClave = ((Dia) Sesion.get(Campo.DiaActual)).DiaClave;
					puntoGPS.DiaClave1 = ((Dia) Sesion.get(Campo.DiaActual)).DiaClave;
					puntoGPS.RUTClave = ((Ruta) Sesion.get(Campo.RutaActual)).RUTClave;
					puntoGPS.VisitaClave = visita.VisitaClave;
					puntoGPS.MFechaHora = Generales.getFechaHoraActual();
					puntoGPS.MUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;
					puntoGPS.Enviado = false;
					BDVend.guardarInsertar(puntoGPS);
				}

				BDVend.commit();
			}

			visitaHist.VisitaHistId = KeyGen.getId();
			visitaHist.VisitaClave = visita.VisitaClave;
			visitaHist.FechaHoraInicial = Generales.getFechaHoraActual();
			visitaHist.FechaHoraFinal = visitaHist.FechaHoraInicial;
			visitaHist.Enviado = false;

			visita.VisitaHist.add(visitaHist);

			Sesion.set(Campo.VisitaActual, visita);

		}
		catch (Exception e)
		{
			mostrarError(e.getMessage());
			e.printStackTrace();
		}
	}

	private void guardarVisita()
	{
		try
		{
			if (Consultas.ConsultasVisita.hayMovimientos(((Visita) Sesion.get(Campo.VisitaActual)).VisitaClave))
			{
				// si hay movimientos guardar la visita
				Usuario usuario = (Usuario) Sesion.get(Campo.UsuarioActual);
				/*
				 * if(parametros.containsKey("nuevaVisita")){ Cliente cliente =
				 * new Cliente(); cliente.ClienteClave =
				 * Sesion.get(Campo.ClienteActual).toString();
				 * BDVend.recuperar(cliente); Agenda agenda =
				 * Consultas.ConsultasAgenda
				 * .obtenerAgendaPorDiaClienteRutaVendedor
				 * ((Dia)Sesion.get(Campo.DiaActual),
				 * (Ruta)Sesion.get(Campo.RutaActual),
				 * (Vendedor)Sesion.get(Campo.VendedorActual), cliente);
				 * if(agenda!=null){ agenda.Visitado = 1; //marcar como visitado
				 * BDVend.guardarInsertar(agenda); } }
				 */

				visita.FechaHoraFinal = Generales.getFechaHoraActual();
				visita.MFechaHora = Generales.getFechaHoraActual();
				visita.MUsuarioID = usuario.USUId;
				visita.VisitaHist.get(visita.VisitaHist.size() - 1).MFechaHora = visita.MFechaHora;
				visita.VisitaHist.get(visita.VisitaHist.size() - 1).MUsuarioID = visita.MUsuarioID;
				visita.VisitaHist.get(visita.VisitaHist.size() - 1).FechaHoraFinal = visita.FechaHoraFinal;
				BDVend.guardarInsertar(visita);

				if (visita.GPSLeido)
				{
					if (!parametros.containsKey("visitaClave"))
					{
						puntoGPS.MFechaHora = Generales.getFechaHoraActual();
						puntoGPS.MUsuarioID = usuario.USUId;
						BDVend.guardarInsertar(puntoGPS);
					}
				}

				MOTConfiguracion motConf = (MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion);
				if (motConf.get("ResumenMovimientos").equals("1"))
				{
					HashMap<String, Object> oParametros = new HashMap<String, Object>();
					oParametros.put("visita", Mensajes.get("XVisita") + " " + visita.Numero);
					iniciarActividadConResultado(IResumenMovVisita.class, 0, "", oParametros);
				}

			}
			else
			{
				// si no hay movimientos, eliminar la visita
				BDVend.eliminar(visita);
				BDVend.eliminar(visita.VisitaHist.get(visita.VisitaHist.size() - 1));
				if (visita.GPSLeido)
					BDVend.eliminar(puntoGPS);

				Cliente cliente = (Cliente) Sesion.get(Campo.ClienteActual);

				Agenda agenda = Consultas.ConsultasAgenda.obtenerAgendaPorDiaClienteRutaVendedor((Dia) Sesion.get(Campo.DiaActual), (Ruta) Sesion.get(Campo.RutaActual), (Vendedor) Sesion.get(Campo.VendedorActual), cliente);
				if (agenda != null && !ConsultasVisita.existenVisitas((Dia) Sesion.get(Campo.DiaActual), cliente))
				{
					// solo marcar como no visitado si no existen mas visitas
					agenda.Visitado = 2; // marcar como no visitado
					BDVend.guardarInsertar(agenda);
				}
			}

			BDVend.commit();
		}
		catch (Exception e)
		{
			mostrarError(e.getMessage());
			e.printStackTrace();
		}
	}

	@Override
	public void mostrarActividades(ModuloMov[] modulos)
	{
		// TODO Auto-generated method stub
		// ListView lista = (ListView) findViewById(R.id.list);
		// ModulosAdapter adapter = new ModulosAdapter(this,R.layout,
		// modulos,mSeleccion);
		// lista.setAdapter(adapter);
	}

	@Override
	public void onItemClick(AdapterView<?> adapter, View arg1, int position, long arg3)
	{
		actividad = (ModuloMovDetalle) gridAdapter.getItem(position);
		mPresenta.seleccionar();
	}
}
