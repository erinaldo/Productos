package com.amesol.routelite.datos;

import java.util.ArrayList;
import java.util.Date;
import java.util.List;

import com.amesol.routelite.datos.annotations.Campo;
import com.amesol.routelite.datos.annotations.Hijos;
import com.amesol.routelite.datos.annotations.Llave;
import com.amesol.routelite.datos.annotations.Requerido;
import com.amesol.routelite.datos.annotations.TablaDef;
import com.amesol.routelite.datos.generales.Entidad;

@TablaDef(orden=1)
public class AbonoHist extends Entidad {

    @Llave()
    @Requerido
    public String ABNHistId;

	@Llave()
	@Requerido
	public String ABNId;
	
	@Campo
	@Requerido
	public String Folio;
	
	@Campo
	@Requerido
	public Date FechaHoraCreacion;
	
	@Campo
	@Requerido
	public String VisitaClave;
	
	@Campo
	@Requerido
	public String DiaClave;
		
	@Campo
	@Requerido
	public float Total;
	
	@Campo
	@Requerido
	public Date FechaHoraElim;
	
	@Campo
	@Requerido
	public Date MFechaHora;
	
	@Campo
	@Requerido
	public String MUsuarioID;
		
	@Campo
	public boolean Enviado;
	
	@Hijos(tablaHijos=AbnTrpHist.class)
	public List<AbnTrpHist> AbnTrpHist;
	
	public AbonoHist(){		
		AbnTrpHist = new ArrayList<AbnTrpHist>();
	}
}
