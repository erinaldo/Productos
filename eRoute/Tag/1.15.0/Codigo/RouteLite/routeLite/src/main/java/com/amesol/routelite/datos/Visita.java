package com.amesol.routelite.datos;

import java.util.ArrayList;
import java.util.Date;
import java.util.List;

import com.amesol.routelite.datos.annotations.Campo;
import com.amesol.routelite.datos.annotations.Hijos;
import com.amesol.routelite.datos.annotations.Llave;
import com.amesol.routelite.datos.annotations.LlaveForanea;
import com.amesol.routelite.datos.annotations.Requerido;
import com.amesol.routelite.datos.annotations.TablaDef;
import com.amesol.routelite.datos.generales.Entidad;

@TablaDef(orden = 3)
public class Visita extends Entidad{

	@Llave
	public String VisitaClave;
	
	@Llave
	public String DiaClave;
	
	@Campo
	@LlaveForanea(nombreCampoForaneo = "ClienteClave", tablaPadre = Cliente.class)
	public String ClienteClave;
	
	@Campo
	@LlaveForanea(nombreCampoForaneo = "VendedorId", tablaPadre = Vendedor.class)
	public String VendedorId;
	
	@Campo
	@LlaveForanea(nombreCampoForaneo = "RUTClave", tablaPadre = Ruta.class)
	public String RUTClave;
	
	@Campo
	public int Numero;
	
	@Campo
	public Date FechaHoraInicial;
	
	@Campo
	public Date FechaHoraFinal;
	
	@Campo
	public Short TipoEstado;
	
	@Campo
	public boolean FueraFrecuencia;
	
	@Campo
	public int CodigoLeido;
	
	@Campo
	public boolean GPSLeido;
	
	@Campo
	public float DistanciaGPS;

    @Campo
    public String Token;

    @Campo
    public int ActivosAsignados;

    @Campo
    public int ActivosAsegurados;
	
	@Campo
	public Date MFechaHora;
	
	@Campo
	public String MUsuarioID;
	
	@Campo
	public boolean Enviado;
	
	@Hijos(tablaHijos = VisitaHist.class)
	public List<VisitaHist> VisitaHist;
	
	public Visita(){
		VisitaHist = new ArrayList<VisitaHist>();
	}
	
}
