package com.duxstar.dacza.utilerias;

import java.util.ArrayList;

import android.view.View;

//import com.amesol.routelite.actividades.Mensajes;
import com.duxstar.dacza.vistas.Vista;

public class ControlError extends Exception{

	/*public final class Tipo{
		public final static short MOSTRAR=0;
		public final static short POSICIONAR=1;
	}*/
	
	private String codigo;
	//private ArrayList<ParametroMSG> parametros;
	private String tabla;
	private String campo;	
	private String msgProveedor;
	//private short tipo;
	private String mensaje;
	
	public String getTabla(){
		return this.tabla;
	}
	
	public String getCampo(){
		return this.campo;
	}
		
	public ControlError(String mensaje){
        this.mensaje = mensaje;
//		this.codigo = codigo;
//		this.parametros = null;
//		this.tabla = "";
//		this.campo = "";
//		this.msgProveedor = "";
//		//this.tipo = Tipo.MOSTRAR;
//		Traducir();
	}	
	
	/*public ControlError(String codigo, String... parametros){
		
		this.codigo = codigo;
		this.parametros = null;
		this.tabla = "";
		this.campo = "";
		this.msgProveedor = "";

		mensaje=Mensajes.get(codigo, parametros);
	}	
	
	public ControlError(String codigo, ArrayList<ParametroMSG> parametros){
		this.codigo = codigo;
		this.parametros = parametros;
		this.tabla = "";
		this.campo = "";
		this.msgProveedor = "";
		//this.tipo = Tipo.MOSTRAR;
		Traducir();
	}*/
	
	public ControlError(String mensaje, String tabla, String campo){ //, boolean posicionar){
		this.mensaje = mensaje;
		this.tabla = tabla;
		this.campo = campo;
		this.msgProveedor = "";		
		//this.tipo = (posicionar ? Tipo.POSICIONAR : Tipo.MOSTRAR);
		//Traducir();
	}
	
	public ControlError(String mensaje, String tabla, String campo, String msgProveedor){ //, boolean posicionar){
		this.mensaje = mensaje;
		this.campo = campo;
		this.msgProveedor = msgProveedor;
		//this.tipo = (posicionar ? Tipo.POSICIONAR : Tipo.MOSTRAR);
		//Traducir();
	}
		
	/*private void Traducir(){
		if (codigo == "")
			mensaje = "";
		else{
			if (parametros != null){
				for (ParametroMSG parametro : parametros){
					if (parametro.buscar)
						parametro.cadena = Mensajes.get(parametro.cadena);
				}
				String[] params = new String[parametros.size()];

				int cont = 0;
				for (ParametroMSG parametro : parametros){
					params[cont] = parametro.cadena;
					cont ++;
				}
				mensaje = Mensajes.get(codigo, params);
			}
			else
			{
				mensaje = Mensajes.get(codigo);
			}



		}
	}	*/
	
	public void Mostrar(Vista vista){
		vista.mostrarError(mensaje);
	}
	
public String getMessage()
{
	return mensaje;
	}
	
	/*public void Mostrar(Vista vista, View layout){
		vista.mostrarError(mensaje);
		if (tipo == Tipo.POSICIONAR){
			if (campo != ""){
				View objeto = (View)layout.findViewWithTag(campo);
				if (objeto != null){
					objeto.setFocusable(true);
					objeto.requestFocus();
				}
			}				
		}			
	}*/
	
}

