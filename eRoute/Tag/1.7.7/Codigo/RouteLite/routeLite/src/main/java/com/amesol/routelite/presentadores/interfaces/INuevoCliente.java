package com.amesol.routelite.presentadores.interfaces;

import java.util.Date;

import com.amesol.routelite.presentadores.IVista;

public interface INuevoCliente extends IVista {

	String getClave();
	void setClave(String clave);
	String getRazonSocial();
	String getRFC();
	String getNombre();
	String getCodigoBarras();
	Date getFechaRegistro();
	Date getFechaNacimiento();
	String getContacto();
	String getTelefono();
	boolean getExigirOrdenCompra();
	boolean getDesglosaImpuestos();
	String getCallePE();
	String getMunicipioPE();
	String getPaisPE();
	String getNumeroExtPE();
	String getNumeroIntPE();
	String getColoniaPE();
	String getCodigoPostalPE();
	String getReferenciaPE();
	String getEntidadPE();
	String getCalleDF();
	String getMunicipioDF();
	String getPaisDF();
	String getNumeroExtDF();
	String getNumeroIntDF();
	String getColoniaDF();
	String getCodigoPostalDF();
	String getReferenciaDF();
	String getEntidadDF();
	boolean getPrestamoEnvase();
	boolean getExclusividad();
	Date getVigExclusividad();
	boolean getCapturoPuntoEntrega();
	boolean getCapturoDomFiscal();

}
