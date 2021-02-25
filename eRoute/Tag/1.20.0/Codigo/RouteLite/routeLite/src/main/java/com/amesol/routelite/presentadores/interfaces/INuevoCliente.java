package com.amesol.routelite.presentadores.interfaces;

import java.util.Date;
import java.util.HashMap;
import java.util.List;

import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.presentadores.IVista;

public interface INuevoCliente extends IVista {

	String getClave();
	void setClave(String clave);
	String getRazonSocial();
	String getNombre();
	String getCodigoBarras();
	Date getFechaRegistro();
	Date getFechaNacimiento();
	String getContacto();
	String getTelefono();
	String getDatosExtra();
    boolean getRequiereFactura();
    String getCorreoElectronico();
    String getRFC();
	boolean getExigirOrdenCompra();
	boolean getDesglosaImpuestos();
    float getLatitudPE();
    float getLongitudPE();
	String getCallePE();
	String getMunicipioPE();
	String getPoblacionPE();
	String getPaisPE();
	String getNumeroExtPE();
	String getNumeroIntPE();
	String getColoniaPE();
	String getCodigoPostalPE();
	String getReferenciaPE();
	String getEntidadPE();
	String getCalleDF();
	String getMunicipioDF();
	String getPoblacionDF();
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
	List<String> getFrecuenciasSeleccionadas();
	HashMap<String,Integer> getSecuenciaOrden();
    void setEsquemas(ISetDatos esquemas);
    List<String> getEsquemasSeleccionados();
}
