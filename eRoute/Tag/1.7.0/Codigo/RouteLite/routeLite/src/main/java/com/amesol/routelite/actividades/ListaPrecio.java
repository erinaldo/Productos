package com.amesol.routelite.actividades;

import java.util.ArrayList;
import java.util.HashMap;

import com.amesol.routelite.datos.Cliente;
import com.amesol.routelite.datos.Precio;
import com.amesol.routelite.datos.basedatos.BDVend;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.basedatos.Consultas.*;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.utilerias.ControlError;
import com.amesol.routelite.vistas.utilerias.ServicesCentral;
import com.amesol.routelite.datos.ModuloMovDetalle; 

public class ListaPrecio {

	public static HashMap<Integer,Precio> Determinar(String ClienteClave,ModuloMovDetalle moduloMovDetalle ) throws ControlError, Exception
	{
		
		ISetDatos IClienteEsquema;
		IClienteEsquema = ConsultasClienteEsquema.obtenerIdEsquemaCte(ClienteClave);
		if(IClienteEsquema.getCount()==0)
		{
			IClienteEsquema.close();
			throw new ControlError("E0873");	
			
			//return null;
		}
		
		ISetDatos IEsquemas;
		IEsquemas = ConsultasEsquema.obtenerEsquemasPorTipo(ServicesCentral.TiposEsquemas.Clientes);
		if(IEsquemas.getCount()==0)
		{
			IClienteEsquema.close();
			IEsquemas.close();
			throw new ControlError("E0874");	
			//return null;
		}
		
		ISetDatos IPrecioClienteEsquema;
		IPrecioClienteEsquema = ConsultasPrecioClienteEsquema.obtenerIdEsquemaCte(moduloMovDetalle.ModuloMovDetalleClave);
		if(IPrecioClienteEsquema.getCount()==0)
		{
			IClienteEsquema.close();
			IEsquemas.close();
			IPrecioClienteEsquema.close();
			
			/*ModuloMovDetalle moduloMovDetalle = new ModuloMovDetalle();
			moduloMovDetalle.ModuloMovDetalleClave = ModuloMovDetalleClave;
			BDVend.recuperar(moduloMovDetalle);
				*/
			throw new ControlError("E0875", moduloMovDetalle.Nombre );	
			//return null;
		}
		
		String EsquemaID;
		String sLista;
		 ArrayList<String> aLista = new ArrayList<String>();
	  while(IClienteEsquema.moveToNext())
	  {
		  EsquemaID=IClienteEsquema.getString("EsquemaId");
		 ArrayList<String> aPrecioClave = new ArrayList<String>();
		 
		 IPrecioClienteEsquema.moveToFirst();
		do
		{
			
			  if(IPrecioClienteEsquema.getString(0).equals(EsquemaID) )
			  {
				  aPrecioClave.add(IPrecioClienteEsquema.getString(2));
			  }
		}
		while(IPrecioClienteEsquema.moveToNext());
		
		for(int i =0 ;i<aPrecioClave.size();i++)
		{
			sLista=aPrecioClave.get(i);
			
			if(!sLista.equals("")) 
			{
				if(!aLista.contains(sLista))
				{
					aLista.add(sLista);
				}
			}
			
			
			
		}
		
	  
		  
	  }
	  
	  if(aLista.size()==0)
	  {
	
		  String sEsquema ="";
		  IClienteEsquema.moveToFirst();
		  do
		  {
			  
			  sEsquema= IClienteEsquema.getString(IClienteEsquema.getColumnIndex("EsquemaId"));
			  sLista=BuscarGrupo(IEsquemas, IPrecioClienteEsquema,sEsquema);
			  if(!sLista.equals(""))
			  {
					if(!aLista.contains(sLista))
					{
						aLista.add(sLista);
					}
			  }
		  }
		  while(IClienteEsquema.moveToNext());
	  }
	  
	  IPrecioClienteEsquema.close();
	  IClienteEsquema.close();
	  IEsquemas.close();
	  
	  if(aLista.size()>0)
	  {
		  String PrecioClave="";
		  ISetDatos IPrecio;
		try {
			IPrecio = ConsultasPrecio.OrdenarPrecios(aLista);
			IPrecio.moveToFirst();
			HashMap<Integer,Precio> listasPrecios = new HashMap<Integer,Precio>();
			Integer i = 0;
		    do
		    {			  
		    	PrecioClave=IPrecio.getString(0);
		    	Precio oPrecio = new Precio();
		    	oPrecio.PrecioClave=PrecioClave;
		    	BDVend.recuperar(oPrecio);
		    	listasPrecios.put(i, oPrecio);
		    	i += 1;
		    			    	
		    }while(IPrecio.moveToNext());
		    IPrecio.close();
		    
			return listasPrecios;
		} catch (Exception e) {
			// TODO Auto-generated catch block
			throw new ControlError(e.getMessage());
		}				  		  		  		  
	  }else{
		   //No se encontró al menos una lista de precios
			throw new ControlError("E0757");	
	  }

	}
	
	


	private static String BuscarGrupo(ISetDatos IEsquemas,ISetDatos IPrecioClienteEsquema,String Esquema)
	{
		
		
		String Slista="";
		IEsquemas.moveToFirst();
		IPrecioClienteEsquema.moveToFirst();
		int indice=0;
		Boolean bExiste=false;
		
		do 
		{
			if(IEsquemas.getString(IEsquemas.getColumnIndex("EsquemaId")).equals(Esquema) && !IEsquemas.isNull(IEsquemas.getColumnIndex("EsquemaIdPadre")))
			{
				
				IPrecioClienteEsquema.moveToFirst();
				do 
				{
					if (IEsquemas.isAfterLast()){
						return Slista;
					}
					if(IPrecioClienteEsquema.getString(IEsquemas.getColumnIndex("EsquemaId")).equals(IEsquemas.getString(IEsquemas.getColumnIndex("EsquemaIdPadre"))))
					{
					
						Slista = IPrecioClienteEsquema.getString(IPrecioClienteEsquema.getColumnIndex("PrecioClave"));
						
						break;
					
					}
					if(IPrecioClienteEsquema.isLast())
					{
						Slista =  BuscarGrupo(IEsquemas,IPrecioClienteEsquema,IEsquemas.getString(IEsquemas.getColumnIndex("EsquemaIdPadre")));
					}
				}
				while(IPrecioClienteEsquema.moveToNext());
				
				
				
				break;
			}
			
			//Slista=BuscarGrupo(IEsquemas,IPrecioClienteEsquema,Esquema);
		}
		while(IEsquemas.moveToNext());
		
		
		return Slista;
	}

	public static float BuscarPrecio(String ProductoClave, short TipoUnidad, String listasPrecios,StringBuilder PrecioClave)
	{				
		return ConsultasPrecioProductoVig.obtenerPrecioProducto(ProductoClave, TipoUnidad, listasPrecios, PrecioClave);
	}
	
	public static Float ObtenerPecioMinimo(String listasPrecios,String ProductoClave, int PRUTipoUnidad) throws Exception{
		return ConsultasPrecioProductoVig.obtenerPrecioMinimo(listasPrecios, ProductoClave, PRUTipoUnidad);
	}
	
	public static Float obtenerPrecioSugerido(String listasPrecios,String ProductoClave, int PRUTipoUnidad) throws Exception{
		return ConsultasPrecioProductoVig.obtenerPrecioSugerido(listasPrecios, ProductoClave, PRUTipoUnidad);
	}
	
}


