package com.amesol.routelite.presentadores.act;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.ListIterator;
import java.util.Map;

import android.R;
import android.app.SearchManager;
import android.widget.Adapter;
import android.widget.ListAdapter;
import android.widget.SimpleAdapter;


import com.amesol.routelite.actividades.Clientes;
import com.amesol.routelite.datos.Cliente;
import com.amesol.routelite.datos.ClienteDomicilio;
import com.amesol.routelite.datos.ClienteMensaje;
import com.amesol.routelite.datos.basedatos.BDVend;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.CONHist;
import com.amesol.routelite.datos.utilerias.MOTConfiguracion;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.Presentador;
import com.amesol.routelite.presentadores.interfaces.IConsultaCliente;

public class ConsultarCliente extends Presentador {
	IConsultaCliente mVista;
	
	public ConsultarCliente(IConsultaCliente vista){
		this.mVista = vista;
	}

	@Override
	public void iniciar() {		
		List<Map<String,String>> datos;
		datos = obtenerListaInfo();
		try
		{
			if (((MOTConfiguracion)Sesion.get(Campo.MOTConfiguracion)).get("MostrarMensajesCli").equals("1"))
			{
				ISetDatos mensajes = Consultas.ConsultasCliente.obtenerMensajesCliente(((Cliente)Sesion.get(Campo.ClienteActual)).ClienteClave, Sesion.get(Campo.TipoModulo).toString());
				mVista.mostrarDatosCliente(datos, mensajes);
			}else{
				mVista.mostrarDatosCliente(datos);
			}
			
		}catch(Exception e){
			e.printStackTrace();
		}		
	}
	
	private List<Map<String,String>> obtenerListaInfo(){
		try{
					
			Cliente cliente = (Cliente)Sesion.get(Campo.ClienteActual);
			
			try{			
				BDVend.recuperar(cliente, ClienteDomicilio.class);							
			}
			catch(Exception e){
				e.printStackTrace();
			}
			
			List<Map<String,String>> lista = Clientes.generarListaInfo(cliente);
			return lista;
		}
		catch(Exception e){
			return null;
		}
		
		/*ListAdapter adapter = new SimpleCursorAdapter(this, R.layout.simple_list_item_2, lista,
				new String[] { "descripcion", "valor" },
				new int[] { android.R.id.text1, android.R.id.text2 });*/ 
	}

}
