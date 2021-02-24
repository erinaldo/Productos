package com.duxstar.dacza.presentadores.act;

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


//import com.amesol.routelite.actividades.Clientes;
import com.duxstar.dacza.actividades.Clientes;
import com.duxstar.dacza.datos.Cliente;
import com.duxstar.dacza.datos.ClienteDomicilio;
import com.duxstar.dacza.datos.ClienteTelefono;
import com.duxstar.dacza.datos.basedatos.BDTerm;
import com.duxstar.dacza.datos.basedatos.Consultas;
import com.duxstar.dacza.datos.generales.ISetDatos;
import com.duxstar.dacza.datos.utilerias.Sesion;
import com.duxstar.dacza.datos.utilerias.Sesion.Campo;
import com.duxstar.dacza.presentadores.Presentador;
import com.duxstar.dacza.presentadores.interfaces.IConsultaCliente;

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
            mVista.mostrarDatosCliente(datos);
		}catch(Exception e){
			e.printStackTrace();
		}		
	}
	
	private List<Map<String,String>> obtenerListaInfo(){
		try{
					
			Cliente cliente = (Cliente)Sesion.get(Campo.ClienteActual);
			
			try{			
				BDTerm.recuperar(cliente, ClienteDomicilio.class);
                BDTerm.recuperar(cliente, ClienteTelefono.class);
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
