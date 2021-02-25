package com.amesol.routelite.actividades;

import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;

public class ValorReferencia implements Comparable<ValorReferencia>{
	private String varcodigo;
	private String vavclave;
	private String descripcion;
	private String grupo;
	private String claveSAT;
	private String descripcionSAT;
	
	public ValorReferencia(String varcodigo,String vavclave,String descripcion,String grupo,String claveSAT, String descripcionSAT ){
		this.setVarcodigo(varcodigo);
		this.setVavclave(vavclave);
		this.setDescripcion(descripcion);
		this.setGrupo(grupo);
		this.setClaveSAT(claveSAT);
		this.setDescripcionSAT(descripcionSAT);
	}

	public String getVarcodigo() {
		return varcodigo;
	}

	private void setVarcodigo(String varcodigo) {
		this.varcodigo = varcodigo;
	}

	public String getVavclave() {
		return vavclave;
	}

	private void setVavclave(String vavclave) {
		this.vavclave = vavclave;
	}

	public String getDescripcion() {
		return descripcion;
	}

	private void setDescripcion(String descripcion) {
		this.descripcion = descripcion;
	}

	public String getGrupo() {
		return grupo;
	}

	private void setGrupo(String grupo) {
		this.grupo = grupo;
	}

	public String getClaveSAT() {
		return claveSAT;
	}

	private void setClaveSAT(String sClaveSAT) {
		this.claveSAT = sClaveSAT;
	}

	public String getDescripcionSAT() {
		return descripcionSAT;
	}

	private void setDescripcionSAT(String sDescripcionSAT) {
		this.descripcionSAT = sDescripcionSAT;
	}

	public int compareTo(ValorReferencia valorReferencia) {
		Integer claveV1 = null;		
		boolean bien = false;
		try{
			claveV1 = Integer.parseInt(getVavclave());
			bien = true;
		}catch(NumberFormatException e){}
		if(bien){
			bien = false;
			Integer claveV2 = null;
			try{
				claveV2 = Integer.parseInt(valorReferencia.getVavclave());
				bien = true;
			}catch(NumberFormatException e){}
			if(bien){
				return claveV1.compareTo(claveV2);
			}
		}		
		return getDescripcion().compareTo(valorReferencia.getDescripcion());
	}	
}