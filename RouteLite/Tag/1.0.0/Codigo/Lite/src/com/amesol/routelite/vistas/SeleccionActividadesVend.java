package com.amesol.routelite.vistas;

import java.util.ArrayList;
import java.util.HashMap;

import android.content.Context;
import android.content.Intent;
import android.os.Bundle;
import android.view.KeyEvent;
import android.view.View;
import android.widget.AdapterView;
import android.widget.AdapterView.OnItemClickListener;
import android.widget.ListView;

import com.amesol.routelite.R;
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.actividades.ModuloMovDetalle;
import com.amesol.routelite.actividades.ValorReferencia;
import com.amesol.routelite.datos.Vendedor;

import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.utilerias.CONHist;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.Enumeradores.ACTROL;
import com.amesol.routelite.presentadores.Enumeradores.RespuestaMsg;
import com.amesol.routelite.presentadores.Enumeradores.TiposModuloMovDetalle;
import com.amesol.routelite.presentadores.act.SeleccionarActividadesVend;
import com.amesol.routelite.presentadores.interfaces.ISeleccionActividadesVend;
import com.amesol.routelite.vistas.generico.ValorReferenciaAdapter;

public class SeleccionActividadesVend extends Vista implements ISeleccionActividadesVend
{
	SeleccionarActividadesVend mPresenta;
	ValorReferencia val;
	HashMap<Integer,String> aModuloMovDetalleClave;
	HashMap<Integer,Integer> aTipoIndiceModuloMovDetalleClave;

	@Override
	public void onCreate(Bundle savedInstanceState)
	{
		super.onCreate(savedInstanceState);
		// super.onSaveInstanceState(savedInstanceState);
		setContentView(R.layout.seleccion_actividades_vend);
		deshabilitarBarra(true);
		mPresenta = new SeleccionarActividadesVend(this);
		mPresenta.iniciar();
	}

	@Override
	public void resultadoActividad(int requestCode, int resultCode, Intent data)
	{
		if ((requestCode == Enumeradores.Solicitudes.SOLICITUD_AGENDA) && (resultCode == Enumeradores.Resultados.RESULTADO_BIEN))
			atras();
		else if ((requestCode == Enumeradores.Solicitudes.SOLICITUD_RECIBIR) && (resultCode == Enumeradores.Resultados.RESULTADO_BIEN))
			atras();
		else if ((requestCode == Enumeradores.Solicitudes.SOLICITUD_SERVIDOR_COMUNICACIONES) && (resultCode == Enumeradores.Resultados.RESULTADO_BIEN))
			atras();
		/*else if ((requestCode == Enumeradores.Solicitudes.SOLICITUD_SERVIDOR_COMUNICACIONES_ENVIO_PARCIAL) && (resultCode == Enumeradores.Resultados.RESULTADO_BIEN))
			//si el envio parcial fue correcto, sincronizar el inventario
			mPresenta.obtenerInventarioEnLinea();*/
		//else if ((requestCode == Enumeradores.Solicitudes.SOLICITUD_SERVIDOR_COMUNICACIONES || requestCode == Enumeradores.Solicitudes.SOLICITUD_SERVIDOR_COMUNICACIONES_ENVIO_PARCIAL) && (resultCode == Enumeradores.Resultados.RESULTADO_MAL))
		else if ((requestCode == Enumeradores.Solicitudes.SOLICITUD_SERVIDOR_COMUNICACIONES) && (resultCode == Enumeradores.Resultados.RESULTADO_MAL))
		{
			if (data != null)
			{
				String mensajeError = (String) data.getExtras().getString("mensajeIniciar");
				if (mensajeError != null)
				{
					iniciarActividad(ISeleccionActividadesVend.class, mensajeError);
					return;
				}
			}
			iniciarActividad(ISeleccionActividadesVend.class);
		}
	}

	@Override
	public void respuestaMensaje(RespuestaMsg respuesta, int tipoMensaje)
	{
		// TODO Auto-generated method stub

	}

	@Override
	public boolean onKeyDown(int keyCode, KeyEvent event)
	{
		switch (keyCode)
		{
			case KeyEvent.KEYCODE_BACK:
				atras();
				return true;
		}
		return super.onKeyDown(keyCode, event);
	}

	private void atras()
	{
		ListView lista = (ListView) findViewById(android.R.id.list);
		mPresenta.atras(lista.getTag().toString());
	}

	public void iniciar()
	{
		// TODO Auto-generated method stub
	}

	public void mostrarActividades(ValorReferencia[] valores, String grupo)
	{
		aModuloMovDetalleClave = new HashMap<Integer,String>();
		aTipoIndiceModuloMovDetalleClave = new HashMap<Integer,Integer>();
		
		if (valores[0].getVavclave().equals("13"))
			setTitulo(Mensajes.get("XActividadesVendedor"));
		else if (valores[0].getVavclave().equals("14"))
			setTitulo(Mensajes.get("XInventario"));
		else
			setTitulo(Mensajes.get("XActualizar"));

		ArrayList<ValorReferencia> Valores = new ArrayList<ValorReferencia>();
		for (int i = 0; i < valores.length; i++)
		{
			Valores.add(valores[i]);
		}

		for (int i = 0; i < Valores.size(); i++)
		{
			if (!((Vendedor) Sesion.get(Campo.VendedorActual)).JornadaTrabajo && Valores.get(i).getVavclave().equals("28"))
			{
				Valores.remove(i);
				if (i == 0)
					i = 0;
				else
					i--;
			}
			if (!((Vendedor) Sesion.get(Campo.VendedorActual)).Kilometraje && Valores.get(i).getVavclave().equals("27"))
			{
				Valores.remove(i);
				if (i == 0)
					i = 0;
				else
					i--;
			}
			if (Boolean.parseBoolean(((CONHist) Sesion.get(Campo.CONHist)).get("Preliquidacion").toString()) && Valores.get(i).getVavclave().equals("22"))
			{
				Valores.remove(i);
				if (i == 0)
					i = 0;
				else
					i--;
			}
		}

		if (grupo.equals("Inventario"))
		{
			for (int i = 0; i < Valores.size(); i++)
			{
				if (Valores.get(i).getVavclave().equals(String.valueOf(ACTROL.MOV_SIN_INV_SIN_VISITA)) && !obtenerActividadesInventario(TiposModuloMovDetalle.MOV_SIN_INV_SIN_VISITA, ACTROL.MOV_SIN_INV_SIN_VISITA ))
				{
					Valores.remove(i);
					if (i == 0)
						i = 0;
					else
						i--;
				}

				if (Valores.get(i).getVavclave().equals(String.valueOf(ACTROL.AJUSTES)) && !obtenerActividadesInventario(TiposModuloMovDetalle.AJUSTES, ACTROL.AJUSTES) )
				{
					Valores.remove(i);
					if (i == 0)
						i = 0;
					else
						i--;
				}

				if (Valores.get(i).getVavclave().equals(String.valueOf(ACTROL.DESCARGAS)) && !obtenerActividadesInventario(TiposModuloMovDetalle.DESCARGAS, ACTROL.DESCARGAS))
				{
					Valores.remove(i);
					if (i == 0)
						i = 0;
					else
						i--;
				}

				if (Valores.get(i).getVavclave().equals(String.valueOf(ACTROL.DEVOLUCIONESALMACEN)) && !obtenerActividadesInventario(TiposModuloMovDetalle.DEVOLUCIONMANUALES, ACTROL.DEVOLUCIONESALMACEN) )
				{
					Valores.remove(i);
					if (i == 0)
						i = 0;
					else
						i--;
				}

				if (Valores.get(i).getVavclave().equals(String.valueOf(ACTROL.CARGAS)) && !obtenerActividadesInventario(TiposModuloMovDetalle.CARGAS, ACTROL.CARGAS ))
				{
					Valores.remove(i);
					if (i == 0)
						i = 0;
					else
						i--;
				}
			}

		}

		ListView lista = (ListView) findViewById(android.R.id.list);
		lista.setTag(grupo);
		ValorReferenciaAdapter adapter = new ValorReferenciaAdapter(this, R.layout.elemento_imagen_texto, Valores);
		lista.setAdapter(adapter);
		lista.setOnItemClickListener(mSeleccionar);
	}

	private OnItemClickListener mSeleccionar = new OnItemClickListener()
	{
		public void onItemClick(AdapterView<?> parent, View v, int position, long id)
		{
			val = (ValorReferencia) parent.getItemAtPosition(position);
			if(aModuloMovDetalleClave != null && aTipoIndiceModuloMovDetalleClave != null){
				if(aModuloMovDetalleClave.containsKey(Integer.parseInt(val.getVavclave())) && aTipoIndiceModuloMovDetalleClave.containsKey(Integer.parseInt(val.getVavclave()))){
					Sesion.set(Campo.ModuloMovDetalleClave, aModuloMovDetalleClave.get(Integer.parseInt(val.getVavclave())));
					Sesion.set(Campo.TipoIndiceModuloMovDetalleClave, aTipoIndiceModuloMovDetalleClave.get(Integer.parseInt(val.getVavclave())));	
				}
			}
			mPresenta.seleccionar(val);
		}
	};

	@Override
	public Context getContext()
	{
		// TODO Auto-generated method stub E0487		
		return this;
	}

	public boolean obtenerActividadesInventario(int TipoIndice, int indiceACTROL)
	{

		ModuloMovDetalle[] mModuloMovDetalle;
		try
		{
			mModuloMovDetalle = Consultas.ConsultasActividades.obtenerActividadesInventario((Vendedor) Sesion.get(Campo.VendedorActual), TipoIndice);
			for(ModuloMovDetalle oMMD : mModuloMovDetalle){
				if(!aModuloMovDetalleClave.containsKey(indiceACTROL))
					aModuloMovDetalleClave.put(indiceACTROL, oMMD.getModuloMovDetalleClave());
				if(!aTipoIndiceModuloMovDetalleClave.containsKey(indiceACTROL))
					aTipoIndiceModuloMovDetalleClave.put(indiceACTROL,oMMD.getTipoIndice());
			}

			if (mModuloMovDetalle.length > 0)
			{
				Sesion.set(Campo.ModuloMovDetalleClave, mModuloMovDetalle[0].getModuloMovDetalleClave());
				Sesion.set(Campo.TipoIndiceModuloMovDetalleClave, mModuloMovDetalle[0].getTipoIndice());
				return true;
			}
		}
		catch (Exception e)
		{
			mostrarError(e.getMessage());
		}
		return false;
	}
}
