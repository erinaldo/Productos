package com.amesol.routelite.presentadores.act;

import java.util.ArrayList;
import java.util.List;

import android.database.Cursor;

import com.amesol.routelite.actividades.Cuotas;
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.datos.CUOCliente;
import com.amesol.routelite.datos.CUOEsquema;
import com.amesol.routelite.datos.CUOProducto;
import com.amesol.routelite.datos.CUOVendedor;
import com.amesol.routelite.datos.Cuota;
import com.amesol.routelite.datos.Vendedor;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.Presentador;
import com.amesol.routelite.presentadores.interfaces.IConsultaIndicadores;

public class ConsultarIndicadores extends Presentador{

	IConsultaIndicadores mVista;
	ArrayList<CUOProducto> aCuoProducto = new ArrayList<CUOProducto>();
	ArrayList<CUOCliente> aCuoCliente = new ArrayList<CUOCliente>();
	ArrayList<CUOVendedor> aCuoVendedor = new ArrayList<CUOVendedor>();
	ArrayList<CUOEsquema> aCuoEsqProducto = new ArrayList<CUOEsquema>();
	ArrayList<CUOEsquema> aCuoEsqCliente = new ArrayList<CUOEsquema>();
	
	ISetDatos sdCuoProducto;
	ISetDatos sdCuoCliente;
	ISetDatos sdCuoVendedor;
	ISetDatos sdCuoEsqProducto;
	ISetDatos sdCuoEsqCliente;
	
	public ConsultarIndicadores(IConsultaIndicadores vista){
		mVista = vista;
	}
	
	/*public ArrayList<CUOProducto> getCuotasProducto(){
		return aCuoProducto;
	}*/
	public Cursor getCuotasProducto(){
		return (Cursor) sdCuoProducto.getOriginal();
	}
	
	/*public ArrayList<CUOVendedor> getCuotasVendedor(){
		return aCuoVendedor;
	}*/
	public Cursor getCuotasVendedor(){
		return (Cursor) sdCuoVendedor.getOriginal();
	}
	
	/*public ArrayList<CUOEsquema> getCuotasEsquemaCli(){
		return aCuoEsqCliente;
	}*/
	public Cursor getCuotasEsquemaCli(){
		return (Cursor) sdCuoEsqCliente.getOriginal();
	}
	
	/*public ArrayList<CUOEsquema> getCuotasEsquemaPro(){
		return aCuoEsqProducto;
	}*/
	public Cursor getCuotasEsquemaPro(){
		return (Cursor) sdCuoEsqProducto.getOriginal();
	}
	
	/*public ArrayList<CUOCliente> getCuotasCliente(){
		return aCuoCliente;
	}*/
	public Cursor getCuotasCliente(){
		return (Cursor) sdCuoCliente.getOriginal();
	}
	 
	@Override
	public void iniciar() {
		try{
			Vendedor vendedor = (Vendedor) Sesion.get(Campo.VendedorActual);
			Cuota[] cuotas = Cuotas.ObtenerCuotasAsigVendedor(vendedor.VendedorId);
			//agregar todas las cuotas del mismo tipo en arrays, MUY LENTO!
			/*for(int i = 0; i < cuotas.length; i++){
				Cuota cuota = cuotas[i];
				Cuotas.obtenerCuotasProducto(cuota);
				Cuotas.obtenerCuotasCliente(cuota);
				Cuotas.obtenerCuotasVendedor(cuota);
				Cuotas.obtenerCuotasEsquema(cuota);
				//cuotas producto
				if(cuota.CUOProducto.size() > 0){
					Iterator<CUOProducto> it = cuota.CUOProducto.iterator();
					while(it.hasNext()){
						aCuoProducto.add(it.next());
					}
				}
				//cuotas cliente
				if(cuota.CUOCliente.size() > 0){
					Iterator<CUOCliente> it = cuota.CUOCliente.iterator();
					while(it.hasNext()){
						aCuoCliente.add(it.next());
					}
				}
				//cuotas vendedor
				if(cuota.CUOVendedor.size() > 0){
					Iterator<CUOVendedor> it = cuota.CUOVendedor.iterator();
					while(it.hasNext()){
						aCuoVendedor.add(it.next());
					}
				}
				
				//esquemas
				if(cuota.CUOEsquema.size() > 0){
					Iterator<CUOEsquema> it = cuota.CUOEsquema.iterator();
					while(it.hasNext()){
						CUOEsquema esq = it.next();
						ISetDatos datos = Consultas.ConsultasEsquema.obtenerEsquemaPorId(esq.EsquemaId);
						if(datos.getCount() > 0)
							datos.moveToNext();
						Esquema esquema = (Esquema) BDVend.instanciar(Esquema.class, datos);
						esquema.EsquemaId = esq.EsquemaId;
						esq.NombreEsquema = esquema.Nombre;
						esq.ClaveEsquema = esquema.Clave;
						if(esquema.Tipo == 1){ //cliente
							aCuoEsqCliente.add(esq);
						}else if(esquema.Tipo == 2){ // producto
							aCuoEsqProducto.add(esq);
						}
						datos.close();
					}
				}
			}*/
			
			sdCuoProducto = Cuotas.obtenerCuotasProducto();
			sdCuoCliente = Cuotas.obtenerCuotasCliente();
			sdCuoVendedor = Cuotas.obtenerCuotasVendedor();
			sdCuoEsqCliente = Cuotas.obtenerCuotasEsquemaCliente();
			sdCuoEsqProducto = Cuotas.obtenerCuotasEsquemaProducto();
			
			List<String> titulos = new ArrayList<String>();
			//if(aCuoProducto.size() > 0)
			if(sdCuoProducto.getCount() > 0)
				titulos.add(Mensajes.get("XProducto"));
			//if(aCuoCliente.size() > 0)
			if(sdCuoCliente.getCount() > 0)
				titulos.add(Mensajes.get("XCliente"));
			//if(aCuoVendedor.size() > 0)
			if(sdCuoVendedor.getCount() > 0)
				titulos.add(Mensajes.get("XVendedor"));
			//if(aCuoEsqCliente.size() > 0)
			if(sdCuoEsqCliente.getCount() > 0)
				titulos.add(Mensajes.get("XEsquemasCliente"));
			//if(aCuoEsqProducto.size() > 0)
			if(sdCuoEsqProducto.getCount() > 0)
				titulos.add(Mensajes.get("XEsquemasProducto"));
			
			mVista.mostrarIndicadores(titulos.toArray(new String[titulos.size()]));
			
		}catch(Exception ex){
			mVista.mostrarError(ex.getMessage());
		}
	}
	
	

}
