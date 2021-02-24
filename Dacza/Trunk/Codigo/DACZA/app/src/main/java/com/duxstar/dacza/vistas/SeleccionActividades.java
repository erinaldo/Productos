package com.duxstar.dacza.vistas;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashMap;

import android.app.AlertDialog;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.content.DialogInterface.OnKeyListener;
import android.os.Bundle;
import android.util.Log;
import android.view.KeyEvent;
import android.view.LayoutInflater;
import android.view.View;
import android.widget.AdapterView;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.AdapterView.OnItemClickListener;
import android.widget.ListView;

import com.duxstar.dacza.R;
import com.duxstar.dacza.actividades.ValorReferencia;
import com.duxstar.dacza.datos.utilerias.ArchivoConfiguracion.CampoConfiguracion;
import com.duxstar.dacza.datos.utilerias.ConfiguracionLocal;
import com.duxstar.dacza.datos.utilerias.Sesion;
import com.duxstar.dacza.datos.utilerias.Sesion.Campo;
import com.duxstar.dacza.presentadores.Enumeradores;
import com.duxstar.dacza.presentadores.Enumeradores.ACTIVIDADES;
import com.duxstar.dacza.presentadores.Enumeradores.RespuestaMsg;
import com.duxstar.dacza.presentadores.act.SeleccionarActividades;
import com.duxstar.dacza.presentadores.interfaces.IAccesoSistema;
import com.duxstar.dacza.presentadores.interfaces.ISeleccionActividades;
import com.duxstar.dacza.vistas.generico.ValorReferenciaAdapter;

public class SeleccionActividades extends Vista implements ISeleccionActividades
{
	SeleccionarActividades mPresenta;
	ValorReferencia val;
	HashMap<Integer,String> aActividades;
	HashMap<Integer,Integer> aTipoIndiceActividades;

	@Override
	public void onCreate(Bundle savedInstanceState)
	{
		super.onCreate(savedInstanceState);
		// super.onSaveInstanceState(savedInstanceState);
		setContentView(R.layout.seleccion_actividades);
		deshabilitarBarra(true);
		mPresenta = new SeleccionarActividades(this);
		mPresenta.iniciar();
	}

	@Override
	public void resultadoActividad(int requestCode, int resultCode, Intent data)
	{
        if ((requestCode == Enumeradores.Solicitudes.SOLICITUD_SERVIDOR_COMUNICACIONES) && (resultCode == Enumeradores.Resultados.RESULTADO_MAL))
        {
            String mensajeError = (String) data.getExtras().getString("mensajeIniciar");
            mostrarAdvertencia(mensajeError);
		}
        else
			iniciarActividad(ISeleccionActividades.class);
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

	public void mostrarActividades(ValorReferencia[] valores, String grupo) {
        aActividades = new HashMap<Integer, String>();
        aTipoIndiceActividades = new HashMap<Integer, Integer>();
        Arrays.sort(valores);

        if (grupo.equals("Agente")) {
            setTitulo("Actividades del Agente");
        }
        else if (grupo.equals("Inventario")) {
            setTitulo("Inventario");
        }

		ArrayList<ValorReferencia> Valores = new ArrayList<ValorReferencia>();
		for (int i = 0; i < valores.length; i++)
		{
			Valores.add(valores[i]);
		}

		ListView lista = (ListView) findViewById(android.R.id.list);
		lista.setTag(grupo);
		if(Valores.size() > 0){
			ValorReferenciaAdapter adapter = new ValorReferenciaAdapter(this, R.layout.elemento_imagen_texto, Valores);
			lista.setAdapter(adapter);
			lista.setOnItemClickListener(mSeleccionar);	
		}else{
			lista.setAdapter(null);
			lista.setOnItemClickListener(null);
		}
	}

	private OnItemClickListener mSeleccionar = new OnItemClickListener()
	{
		public void onItemClick(AdapterView<?> parent, View v, int position, long id)
		{
			val = (ValorReferencia) parent.getItemAtPosition(position);
//			if(aModuloMovDetalleClave != null && aTipoIndiceModuloMovDetalleClave != null){
//				if(aModuloMovDetalleClave.containsKey(Integer.parseInt(val.getVavclave())) && aTipoIndiceModuloMovDetalleClave.containsKey(Integer.parseInt(val.getVavclave()))){
//					Sesion.set(Campo.ModuloMovDetalleClave, aModuloMovDetalleClave.get(Integer.parseInt(val.getVavclave())));
//					Sesion.set(Campo.TipoIndiceModuloMovDetalleClave, aTipoIndiceModuloMovDetalleClave.get(Integer.parseInt(val.getVavclave())));
//				}
//			}
//
//			String tipoIndice = String.valueOf(aTipoIndiceModuloMovDetalleClave.get(Integer.parseInt(val.getVavclave())));
//			//Log.i(null, "val: "+ tipoIndice);
//			if (tipoIndice.equals("8") || tipoIndice.equals("15"))
//			{
//				validarPermisoAcceso(tipoIndice, Enumeradores.TipoPermiso.ACCESAR);
//			}
//			else
//			{
//
				mPresenta.seleccionar(val);
//			}
		}
	};

	@Override
	public Context getContext()
	{
		// TODO Auto-generated method stub E0487		
		return this;
	}

	
}
