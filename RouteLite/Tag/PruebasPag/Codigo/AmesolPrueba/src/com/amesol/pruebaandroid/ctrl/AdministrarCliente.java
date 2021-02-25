package com.amesol.pruebaandroid.ctrl;

import android.app.SearchManager;
import android.database.Cursor;
import android.database.sqlite.SQLiteQueryBuilder;
import android.util.Log;

import com.amesol.pruebaandroid.dat.SesionBD;

public class AdministrarCliente {

	SesionBD sesion;
	public AdministrarCliente(SesionBD sesion){
		this.sesion = sesion;
	}
	
	public class Cliente{
		
		private String clienteClave;
		private String clave;
		private String idElectronico;
		private String nombreCorto;
		private String razonSocial;
		private String nombreContacto;
		private float saldoEfectivo;
		private String calle;
		private String numero;
		private String colonia;
		private String entidad;
		private String localidad;

		

		public String getNombreContacto() {
			return nombreContacto;
		}

		public void setNombreContacto(String nombreContacto) {
			this.nombreContacto = nombreContacto;
		}

		public float getSaldoEfectivo() {
			return saldoEfectivo;
		}

		public void setSaldoEfectivo(float saldoEfectivo) {
			this.saldoEfectivo = saldoEfectivo;
		}

		public String getCalle() {
			return calle;
		}

		public void setCalle(String calle) {
			this.calle = calle;
		}

		public String getNumero() {
			return numero;
		}

		public void setNumero(String numero) {
			this.numero = numero;
		}

		public String getColonia() {
			return colonia;
		}

		public void setColonia(String colonia) {
			this.colonia = colonia;
		}

		public String getEntidad() {
			return entidad;
		}

		public void setEntidad(String entidad) {
			this.entidad = entidad;
		}

		public String getLocalidad() {
			return localidad;
		}

		public void setLocalidad(String localidad) {
			this.localidad = localidad;
		}



		public String getClienteClave() {
			return clienteClave;
		}



		public void setClienteClave(String clienteClave) {
			this.clienteClave = clienteClave;
		}



		public String getClave() {
			return clave;
		}



		public void setClave(String clave) {
			this.clave = clave;
		}



		public String getIdElectronico() {
			return idElectronico;
		}



		public void setIdElectronico(String idElectronico) {
			this.idElectronico = idElectronico;
		}



		public String getNombreCorto() {
			return nombreCorto;
		}



		public void setNombreCorto(String nombreCorto) {
			this.nombreCorto = nombreCorto;
		}



		public String getRazonSocial() {
			return razonSocial;
		}



		public void setRazonSocial(String razonSocial) {
			this.razonSocial = razonSocial;
		}
	}
	
	public Cliente obtenerCliente(String clienteClave){
		Cursor cursor = null;
	   	 try{
	   		 
	   		 cursor = sesion.consultar(
	   				 "SELECT * FROM Cliente WHERE ClienteClave = ?"
	   				 , new String[]{clienteClave});
	   	 }catch(Exception e){
	   		 Log.d("dd", e.getMessage());
	   	 }
	   	 cursor.moveToFirst();
		Cliente cli = new Cliente();
		cli.setClienteClave(clienteClave);
		cli.setClave(cursor.getString(cursor.getColumnIndex("Clave")));
		cli.setIdElectronico(cursor.getString(cursor.getColumnIndex("IdElectronico")));
		cli.setNombreCorto(cursor.getString(cursor.getColumnIndex("NombreCorto")));
		cli.setRazonSocial(cursor.getString(cursor.getColumnIndex("RazonSocial")));
		cli.setNombreContacto(cursor.getString(cursor.getColumnIndex("NombreContacto")));
		cli.setSaldoEfectivo(cursor.getFloat(cursor.getColumnIndex("SaldoEfectivo")));
		cli.setCalle(cursor.getString(cursor.getColumnIndex("Calle")));
		cli.setNumero(cursor.getString(cursor.getColumnIndex("Numero")));
		cli.setColonia(cursor.getString(cursor.getColumnIndex("Colonia")));
		cli.setEntidad(cursor.getString(cursor.getColumnIndex("Entidad")));
		cli.setLocalidad(cursor.getString(cursor.getColumnIndex("Localidad")));
		return cli;
	}
	
	public Cursor obtenerClientes(String valor){
		Cursor cursor = null;
		try{
			if(valor != null)
				valor = valor.replace("'", "\'");

			cursor = sesion.consultar(
					"SELECT rowid AS _id,Clave || '-' || NombreCorto AS "+ SearchManager.SUGGEST_COLUMN_TEXT_1+
					",RazonSocial AS "+ SearchManager.SUGGEST_COLUMN_TEXT_2 +
					",ClienteClave AS "+ SearchManager.SUGGEST_COLUMN_INTENT_DATA +
					" FROM Cliente "+
					(valor != null?
							" WHERE NombreCorto like '%"+valor+"%' OR RazonSocial like '%"+valor+"%' OR Clave like '%"+valor+"%'":
							" WHERE SaldoEfectivo > 0 ")

							, null);
		}catch(Exception e){
			Log.d("dd", e.getMessage());
		}
		return cursor;
	}
}
