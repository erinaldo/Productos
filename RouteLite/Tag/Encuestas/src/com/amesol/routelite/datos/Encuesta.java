package com.amesol.routelite.datos;

import java.util.Date;

import com.amesol.routelite.datos.generales.Entidad;
import com.amesol.routelite.datos.annotations.*;

@TablaDef(orden=1)
public class Encuesta extends Entidad
{
	
		@Llave()
		@Campo
		public String ENCId;
		
		@Campo
		public String CENClave;
		
		@Campo
		public String VisitaClave;
		
		@Campo
		public String DiaClave;
		
		@Campo
		public int Fase;
		
		@Campo
		public Date Fecha;
		
		@Campo
		public Date HoraInicio;
		
		@Campo
		public Date HoraFin;
		
		@Campo 
		public Date MFechaHora;
		
		@Campo 
		public String MUsuarioId;

}