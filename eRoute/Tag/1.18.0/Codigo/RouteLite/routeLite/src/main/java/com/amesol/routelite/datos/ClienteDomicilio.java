package com.amesol.routelite.datos;

import java.util.ArrayList;
import java.util.Date;

import com.amesol.routelite.datos.annotations.*;
import com.amesol.routelite.datos.generales.Entidad;
import com.amesol.routelite.utilerias.ControlError;
import com.amesol.routelite.utilerias.ParametroMSG;

@TablaDef(orden=2)
public class ClienteDomicilio extends Entidad {
	
	@Llave()
	@LlaveForanea( nombreCampoForaneo="ClienteClave", tablaPadre=Cliente.class)
	@Requerido
	public String ClienteClave;
	
	@Llave()
	@Requerido
	public String ClienteDomicilioId;

	@Campo
	@Requerido
	public short Tipo;
	
	@Campo(msgDescripcion="XCalle")
	@Requerido
	public String Calle;
	
	@Campo(msgDescripcion="COMNumeroExt")
	public String Numero;
	
	@Campo(msgDescripcion="COMNumeroInt")
	public String NumInt;
	
	@Campo(msgDescripcion="XCodigoPostal")
	public String CodigoPostal;
	
	@Campo(msgDescripcion="XReferencia")
	public String ReferenciaDom;
	
	@Campo(msgDescripcion="XColonia")
    @Requerido
	public String Colonia;
	
	@Campo(msgDescripcion="XMunicipio")
    @Requerido
	public String Localidad;
	
	@Campo(msgDescripcion="XMunicipio")
	@Requerido
	public String Poblacion;
	
	@Campo(msgDescripcion="XEntidad")
	public String Entidad;
	
	@Campo(msgDescripcion="XPais")
	@Requerido
	public String Pais;
	
	@Campo
	public float CoordenadaX;
	
	@Campo
	public float CoordenadaY;
	
	@Campo
	@Requerido
	public Date MFechaHora;
	
	@Campo
	@Requerido
	public String MUsuarioID;
	
	@Campo
	public boolean Enviado;
	
	public boolean RequeridosFiscal;
	
	@Override
	public void validar()throws ControlError{
		super.validar();
		if (Tipo == 1){
			if ((CodigoPostal == null || CodigoPostal.equals("")) && RequeridosFiscal){
				ArrayList<ParametroMSG> params =  new ArrayList<ParametroMSG>();
				params.add(new ParametroMSG("XCodigoPostal", true));
				throw new ControlError("BE0001", params, this.getClass().getSimpleName(), "CodigoPostal");
			}
		}
	}
}
