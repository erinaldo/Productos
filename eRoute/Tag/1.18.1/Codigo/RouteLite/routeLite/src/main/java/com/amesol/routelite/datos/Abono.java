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
public class Abono extends Entidad {
	
	@Llave()
	@Requerido
	public String ABNId;
	
	@Campo
	@Requerido
	public String Folio;
	
	@Campo
	@Requerido
	public Date FechaCreacion;
	
	@Campo
	@Requerido
	public String VisitaClave;
	
	@Campo
	@Requerido
	public String DiaClave;

    @Campo
    @Requerido
    public String SubEmpresaId;
	
	@Campo
	@Requerido
	public Date FechaAbono;
	
	@Campo
	@Requerido
	public float Total;
	
	@Campo
	@Requerido
	public float Saldo;
	
	@Campo
	@Requerido
	public Date MFechaHora;
	
	@Campo
	@Requerido
	public String MUsuarioID;
	
	@Campo
	public float SaldoCarga;
	
	@Campo
	public boolean Enviado;
	
	@Hijos(tablaHijos=AbnTrp.class)
	public List<AbnTrp> AbnTrp;
	
	@Hijos(tablaHijos=ABNDetalle.class)
	public List<ABNDetalle> ABNDetalle;
	
	@Hijos(tablaHijos=TRPCheque.class)
	public List<TRPCheque> TRPCheque;
	
	public Abono(){		
		AbnTrp = new ArrayList<AbnTrp>();
		ABNDetalle = new ArrayList<ABNDetalle>();
		TRPCheque = new ArrayList<TRPCheque>();
	}
}
