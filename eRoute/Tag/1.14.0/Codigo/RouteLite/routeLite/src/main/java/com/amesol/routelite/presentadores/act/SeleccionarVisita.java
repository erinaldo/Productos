package com.amesol.routelite.presentadores.act;

import android.database.Cursor;
import android.location.Location;

import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.datos.AseguramientoVisita;
import com.amesol.routelite.datos.Cliente;
import com.amesol.routelite.datos.ClienteDomicilio;
import com.amesol.routelite.datos.Dia;
import com.amesol.routelite.datos.Vendedor;
import com.amesol.routelite.datos.Visita;
import com.amesol.routelite.datos.basedatos.BDVend;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.CONHist;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.Presentador;
import com.amesol.routelite.presentadores.interfaces.IObtencionGPS;
import com.amesol.routelite.presentadores.interfaces.IResumenMovVisita;
import com.amesol.routelite.presentadores.interfaces.ISeleccionActividadesVisita;
import com.amesol.routelite.presentadores.interfaces.ISeleccionVisita;
import com.amesol.routelite.presentadores.parcelables.DatosGPS;
import com.amesol.routelite.utilerias.Generales;

import java.util.HashMap;

public class SeleccionarVisita extends Presentador {

	ISeleccionVisita mVista;
	String mAccion;
	String ClienteDomicilioID;
	Boolean bTieneCoordenadas=false;
	HashMap<String, Object> oParametros;
	Vendedor oVendedor;
	boolean Aseguramientogps;
	
	public SeleccionarVisita(ISeleccionVisita vista, String accion){
		mVista = vista;
		mAccion = accion;
		oParametros = new HashMap<String, Object>();
	}
	
	public void setParametros(	HashMap<String, Object> parametros)
	{
		oParametros=parametros;
	}
	
	@Override
	public void iniciar() {
		try{
			
			mVista.iniciar();
			if((mAccion != null) && (mAccion.equals(Enumeradores.Acciones.ACCION_VISITAR_CLIENTE_VISITA))){

				
				if((Boolean)oParametros.get("bVisitado")){
					Dia dia = (Dia)Sesion.get(Campo.DiaActual);
					Cliente cliente = (Cliente)Sesion.get(Campo.ClienteActual);

					ISetDatos visitas = Consultas.ConsultasVisita.obtenerVisitas(dia, cliente); 
					
					mVista.mostrarVisitasCliente(visitas);
				}else{
					
					oParametros.put("nuevaVisita", true);
					mVista.finalizar();
					//mVista.iniciarActividadConResultado(IVisitaCliente.class, 0, Enumeradores.Acciones.ACCION_VISITAR_CLIENTE_CLIENTE, parametros);
					mVista.iniciarActividadConResultado(ISeleccionActividadesVisita.class, 0, Enumeradores.Acciones.ACCION_VISITAR_CLIENTE_CLIENTE, oParametros);
				}
				
			}
		}catch(Exception ex){
			mVista.mostrarError(ex.getMessage() + ". " + ex.getCause().getMessage());
			ex.printStackTrace();
		}
	}

	/*private boolean validarMostrarVisitas(ISetDatos visita){
		boolean bMostrar = true;
		if(visita.getCount() <= 0)
			bMostrar = false;
		else
			bMostrar = true;
		return bMostrar;
	}*/
	
	public void seleccionarVisita(String visitaClave){		
		oParametros.put("visitaClave", visitaClave);
		mVista.finalizar();
		mVista.iniciarActividadConResultado(ISeleccionActividadesVisita.class, 0, Enumeradores.Acciones.ACCION_VISITAR_CLIENTE_CLIENTE, oParametros);
	}
	
	public void seleccionarNueva(){
		/*HashMap<String, String> parametros =  new HashMap<String, String>();
		parametros.put("nuevaVisita", "true");
		mVista.finalizar();
		mVista.iniciarActividadConResultado(IVisitaCliente.class, 0, Enumeradores.Acciones.ACCION_VISITAR_CLIENTE_CLIENTE, parametros);*/
		ReiniciarParametrosHash();
		oParametros.put("nuevaVisita", "true");
		
		boolean[] array = {true,false};
		oVendedor = (Vendedor) Sesion.get(Campo.VendedorActual);
		
		if (oVendedor.GPS){
			IniciarGPS();
			return;
		}

		
		iniciarVisita();
		//mVista.iniciarActividadConResultado(ISeleccionActividadesVisita.class, 0, Enumeradores.Acciones.ACCION_VISITAR_CLIENTE_CLIENTE, oParametros);
	}
	
	public void iniciarVisita()
	{
		mVista.finalizar();
		//mVista.iniciarActividad(ISeleccionVisita.class, Enumeradores.Acciones.ACCION_VISITAR_CLIENTE_VISITA, null, false,oParametros);
		mVista.iniciarActividadConResultado(ISeleccionActividadesVisita.class, 0, Enumeradores.Acciones.ACCION_VISITAR_CLIENTE_CLIENTE, oParametros);
	}
	
	private void ReiniciarParametrosHash()
	{
		
		
		
		oParametros.put("GPSLeido", false);
		oParametros.put("DistanciaGPS", 0.0f);
		oParametros.put("LatitudGPS",0d);
		oParametros.put("LongitudGPS", 0d);
		oParametros.put("TieneCoordenadas", false);
		oParametros.put("LatitudCliente", 0f);
		oParametros.put("LongitudCliente", 0f);
	
	}
	
	public void IniciarGPS()
	{
		mVista.iniciarActividadConResultado(IObtencionGPS.class, Enumeradores.Solicitudes.SOLICITUD_GPS, Enumeradores.Acciones.ACCION_OBTENER_GPS);
	}
	
	private Boolean ObtenerCoordenadasCliente()
	{
			try 
			{
				ISetDatos cli =Consultas.ConsultasCliente.obtenerCoordenadasCliente(((Cliente)Sesion.get(Campo.ClienteActual)).ClienteClave);
							
				if(cli.getCount()>0){
					
					cli.moveToNext();
				
					if(!(cli.isNull(0) || cli.getFloat(0)==0))
					{
						
						
						oParametros.put("LongitudCliente", cli.getFloat(0));
					}
					if(!(cli.isNull(1) || cli.getFloat(1)==0))
					{
						oParametros.put("LatitudCliente", cli.getFloat(1));

					}
					if(!(cli.isNull(2)))
					{
						ClienteDomicilioID=cli.getString(2);
					}
					
					if(	(Float)oParametros.get("LongitudCliente") != 0 && (Float)oParametros.get("LatitudCliente") != 0)
					{
						return true;
					}
				}
					return false;
				
			} catch (Exception e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
			return false;
	}
	
	public void ValidarDatosGPS(DatosGPS datosGPS) {	
		
		
		oParametros.put("LongitudGPS", datosGPS.getLongitud());
		oParametros.put("LatitudGPS",  datosGPS.getLatitud());
		
		oParametros.put("TieneCoordenadas", ObtenerCoordenadasCliente());
		if((Boolean)oParametros.get("TieneCoordenadas")  && ((Cliente) (Sesion.get(Campo.ClienteActual))).PublicoGeneral == 0)
		{
			AseguramientoVisita aseguramiento = obtenerAseguramiento();
			if (aseguramiento.TipoAseguramiento==2 || aseguramiento.TipoAseguramiento==3 || aseguramiento.TipoAseguramiento == 5)
			{
				Location Puntoleido = new Location("");
				Puntoleido.setLatitude(datosGPS.getLatitud());
				Puntoleido.setLongitude(datosGPS.getLongitud());
				Location PuntoCliente = new Location("");
				PuntoCliente.setLatitude(((Float) oParametros.get("LatitudCliente")).doubleValue());
				
				PuntoCliente.setLongitude(((Float) oParametros.get("LongitudCliente")).doubleValue());
				oParametros.put("DistanciaGPS", Puntoleido.distanceTo(PuntoCliente));
				
				CONHist oConHist =(CONHist)Sesion.get(Campo.CONHist);
				

			
				
				
				if((Float)oParametros.get("DistanciaGPS") >aseguramiento.LimiteGPS)
				{
					mVista.mostrarPreguntaSiNo(Mensajes.get("P0207"), 1);
					
					return;
				}
				else
				{
					oParametros.put("GPSLeido", true);
					iniciarVisita();
					//mVista.iniciarActividad(ISeleccionVisita.class, Enumeradores.Acciones.ACCION_VISITAR_CLIENTE_VISITA, null, false);
					
				}
				
			}
			else
			{
				oParametros.put("GPSLeido", true);
				iniciarVisita();
				//mVista.iniciarActividad(ISeleccionVisita.class, Enumeradores.Acciones.ACCION_VISITAR_CLIENTE_VISITA, null, false);
			}
				
		}
		else
		{
			oParametros.put("GPSLeido", true);
			//if((Boolean)oParametros.get("CodigoLeido") ==true)
			if (Integer.parseInt(oParametros.get("CodigoLeido").toString()) == 1)
			{ 
				ClienteDomicilio clidom = new ClienteDomicilio();
				clidom.ClienteClave=((Cliente)Sesion.get(Campo.ClienteActual)).ClienteClave;
				clidom.ClienteDomicilioId=ClienteDomicilioID;
				try {
					BDVend.recuperar(clidom);
					clidom.CoordenadaX=(float) datosGPS.getLongitud();
					clidom.CoordenadaY=(float) datosGPS.getLatitud();
					clidom.MFechaHora = Generales.getFechaHoraActual();
					clidom.Enviado=false;
					BDVend.guardarInsertar(clidom);
					BDVend.commit();
				} catch (Exception e) {
					// TODO Auto-generated catch block
					mVista.mostrarError(e.getMessage());
				}
				
			}
			else
			{
				ClienteDomicilio clidom = new ClienteDomicilio();
				clidom.ClienteClave=((Cliente)Sesion.get(Campo.ClienteActual)).ClienteClave;
				clidom.ClienteDomicilioId=ClienteDomicilioID;
				try {
					BDVend.recuperar(clidom);
					clidom.CoordenadaX=(float) datosGPS.getLongitud();
					clidom.CoordenadaY=(float) datosGPS.getLatitud();
					clidom.MFechaHora = Generales.getFechaHoraActual();
					clidom.Enviado=false;
					BDVend.guardarInsertar(clidom);
					BDVend.commit();
				} catch (Exception e) {
					// TODO Auto-generated catch block
					mVista.mostrarError(e.getMessage());
				}
				
				
			}
			iniciarVisita();
		}
		
	}
	
	private AseguramientoVisita obtenerAseguramiento(){
		try {
			Vendedor vendedor = (Vendedor)Sesion.get(Sesion.Campo.VendedorActual);
			return Consultas.ConsultarAseguramientoVisita.obtenerAseguramientoPorVendedor(vendedor);
		} catch (Exception e) {
			e.printStackTrace();
			return null;
		}
	}
	
	public boolean validarMostrarAutorizacion(boolean[] array)
	{
		AseguramientoVisita aseguramiento = obtenerAseguramiento();
		if (!aseguramiento.EdoContraFija || aseguramiento.TipoAseguramiento == 0)
		{
			return false;
		}
		else
		{
			if (((aseguramiento.TipoAseguramiento == 1 || aseguramiento.TipoAseguramiento == 3 || aseguramiento.TipoAseguramiento == 4 || aseguramiento.TipoAseguramiento == 5)) && Integer.parseInt(oParametros.get("CodigoLeido").toString()) == 0)
			{// !(Boolean)oParametros.get("CodigoLeido")){

				if (aseguramiento.TipoAseguramiento == 3 || aseguramiento.TipoAseguramiento == 5)
					array[1] = true;

				if (aseguramiento.TipoContrasena == 2)
					return true;
				else if (aseguramiento.EdoContraFija && (aseguramiento.TipoContrasena == 1 || aseguramiento.TipoContrasena == 0))
				{
					mVista.mostrarError(Mensajes.get("E0783"));
					array[0] = false;
					return false;
				}

			}
			else
			{
				if (aseguramiento.TipoAseguramiento != 2 && (aseguramiento.TipoAseguramiento != 3 || aseguramiento.TipoAseguramiento != 5) && aseguramiento.TipoContrasena == 2 && Integer.parseInt(oParametros.get("CodigoLeido").toString()) == 0)
					return true;
				else
					array[1] = true;
				return false;
			}
		}
		return true;
	}
	
	public void mostrarResumen(Cursor visita){
		try{
			//asignar la visita seleccionada como actual
            Dia dia = (Dia)Sesion.get(Campo.DiaActual);
			Visita visit = new Visita();
			visit.VisitaClave = visita.getString(0);
            visit.DiaClave = dia.DiaClave;
			BDVend.recuperar(visit);
			Sesion.set(Campo.VisitaActual, visit);
			
			oParametros.put("visita", visita.getString(2));
            mVista.iniciarActividad(IResumenMovVisita.class,"",null,true,oParametros);
		}catch(Exception ex){
			mVista.mostrarError(ex.getMessage());
		}
	}

    public boolean existeImproductividadEnVisita(String visitaClave){
        try {
            return Consultas.ConsultasImproductividades.existeImproductividadEnVisita(visitaClave, ((Dia)Sesion.get(Campo.DiaActual)).DiaClave);
        }catch(Exception ex){
            ex.printStackTrace();
            return false;
        }

    }

    public boolean existeVisitaPosterior(String visitaClave){
        try {
            return Consultas.ConsultasVisita.existeVisitaPosterior(visitaClave, ((Dia)Sesion.get(Campo.DiaActual)).DiaClave);
        }catch(Exception ex){
            ex.printStackTrace();
            return false;
        }
    }
	
}
