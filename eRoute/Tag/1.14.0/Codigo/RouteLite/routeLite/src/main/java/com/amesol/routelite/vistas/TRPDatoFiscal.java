package com.amesol.routelite.vistas;

import java.util.Date;

import com.amesol.routelite.datos.annotations.Campo;
import com.amesol.routelite.datos.annotations.Llave;
import com.amesol.routelite.datos.annotations.TablaDef;
import com.amesol.routelite.datos.generales.Entidad;

@TablaDef(nombreTabla="TRPDatoFiscal", orden=6)
public class TRPDatoFiscal extends Entidad
{
	@Llave
	public String TransProdID;
	
	@Campo
	public String FolioId;
	
	@Campo
	public String FOSId;
	
	@Campo
	public String RazonSocial;
	
	@Campo
	public String RFC;
	
	@Campo
	public String TelefonoContacto;
	
	@Campo
	public String Calle;
	
	@Campo
	public String NumExt;
	
	@Campo
	public String NumInt;
	
	@Campo
	public String Colonia;
	
	@Campo
	public String CodigoPostal;
	
	@Campo
	public String ReferenciaDom;
	
	@Campo
	public String Localidad;
	
	@Campo
	public String Municipio;
	
	@Campo
	public String Entidad;
	
	@Campo
	public String Pais;
	
	@Campo
	public String CadenaOriginal;
	
	@Campo
	public String SelloDigital;
	
	@Campo
	public String TelefonoEm;
	
	@Campo
	public String RFCEm;
	
	@Campo
	public String NombreEm;
	
	@Campo
	public String CalleEm;
	
	@Campo
	public String NumExtEm;
	
	@Campo
	public String NumIntEm;
	
	@Campo
	public String ColoniaEm;
	
	@Campo
	public String LocalidadEm;
	
	@Campo
	public String ReferenciaDomEm;
	
	@Campo
	public String MunicipioEm;
	
	@Campo
	public String RegionEm;
	
	@Campo
	public String PaisEm;
	
	@Campo
	public String CodigoPostalEm;
	
	@Campo
	public String CalleEx;
	
	@Campo
	public String NumExtEx;
	
	@Campo
	public String NumIntEx;
	
	@Campo
	public String ColoniaEx;
	
	@Campo
	public String CodigoPostalEx;
	
	@Campo
	public String ReferenciaDomEx;
	
	@Campo
	public String LocalidadEx;
	
	@Campo
	public String MunicipioEx;
	
	@Campo
	public String EntidadEx;
	
	@Campo
	public String PaisEx;
	
	@Campo
	public String TipoVersion;

	@Campo
	public String VersionTFD;

	@Campo
	public String UUID;

	@Campo
	public Date FechaTimbrado;

	@Campo
	public String NoCertificadoSAT;

	@Campo
	public String SelloSAT ;

	@Campo
	public String CadenaOriginalTFD;

	@Campo
	public String RFCProvCertif;

	@Campo
	public String MetodoPago;
	
	@Campo
	public String NumCtaPago;
	
	@Campo
	public String Banco;
	
	@Campo
	public Date MFechaHora;
	
	@Campo
	public String MUsuarioID;
	
	@Campo
	public boolean Enviado;
	
}
