package com.amesol.routelite.presentadores.act;

import java.util.List;

import android.app.Activity;
import android.app.SearchManager;
import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.ListView;
import android.widget.TextView;

import com.amesol.routelite.R;
import com.amesol.routelite.actividades.Recibos;
import com.amesol.routelite.datos.Cliente;
import com.amesol.routelite.datos.Dia;
import com.amesol.routelite.datos.Ruta;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.Presentador;
import com.amesol.routelite.presentadores.interfaces.IConsultaReporte;

public class ConsultarReporte extends Presentador
{
	IConsultaReporte mVista;
	
	public ConsultarReporte(IConsultaReporte vista){
		mVista = vista;
	}

	@Override
	public void iniciar()
	{
		
	}
	
	public void generarReporte(Cliente cliente){
		try{
			int reporte = mVista.getReporteId();
			//Recibos recibo = new Recibos();
			//recibo.imprimirReporte(reporte, false, mVista);
			if(reporte == 6 && cliente != null){
				Recibos.imprimirReporte(reporte, cliente, false, mVista);
			}
			else{
				Recibos.imprimirReporte(reporte, false, mVista);
			}
		}catch(Exception e){
			mVista.mostrarAdvertencia(e.getMessage());
			e.printStackTrace();
		}
		
		/*File file = new File(Environment.getExternalStorageDirectory().getAbsolutePath()+"/example.pdf");
		Intent intent = new Intent();
		intent.setDataAndType(Uri.fromFile(file), "application/pdf");
		intent.setClass(this, PDFViewer.class);
		intent.setAction("android.intent.action.VIEW");
		this.startActivity(intent);*/
	}

	public void cargaClientes(ListView list)
	{
		try{
			ISetDatos setDatos = Consultas.ConsultasCliente.obtenerTodos(null, (Ruta)Sesion.get(Campo.RutaActual), null);
			Cliente[] clientes = new Cliente[setDatos.getCount()];
			int i = 0;
			Cliente cliente;
			while(setDatos.moveToNext()){
				cliente = new Cliente();
				cliente.ClienteClave = setDatos.getString(SearchManager.SUGGEST_COLUMN_INTENT_DATA);
				cliente.NombreCorto = setDatos.getString(SearchManager.SUGGEST_COLUMN_TEXT_1);
				cliente.NombreContacto = setDatos.getString(SearchManager.SUGGEST_COLUMN_TEXT_2);
				clientes[i++] = cliente;
			}
			setDatos.close();
			ArrayAdapter<Cliente> adapter = new ArrayAdapter<Cliente>((Context)mVista, R.layout.lista_simple3, clientes){
				@Override
				public View getView(int position, View convertView, ViewGroup parent)
				{
					View fila = convertView;

					if (convertView == null)
					{
						LayoutInflater inflater = ((Activity) mVista).getLayoutInflater();
						fila = inflater.inflate(R.layout.lista_simple3, null);
					}
					Cliente cliente = getItem(position);
					((TextView)fila.findViewById(R.id.texto1)).setText(cliente.NombreCorto);
					((TextView)fila.findViewById(R.id.texto2)).setText(cliente.NombreContacto);
					((TextView)fila.findViewById(R.id.texto3)).setText("");
					return fila;
				}
			};
			list.setAdapter(adapter);
		}catch(NullPointerException ex){
			mVista.mostrarError("Error al obtener los clientes");
		}catch(Exception ex){
			mVista.mostrarError(ex.getMessage());
		}
	}

}
