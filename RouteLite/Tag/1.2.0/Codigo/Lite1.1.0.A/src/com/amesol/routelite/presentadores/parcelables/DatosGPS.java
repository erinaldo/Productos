package com.amesol.routelite.presentadores.parcelables;

import android.os.Parcel;
import android.os.Parcelable;

public class DatosGPS implements Parcelable
{
	private double latitud;
	private double longitud;
	private long fechaHora;
	private float presicion;
	
	public DatosGPS() { ; };
	
	public DatosGPS(Parcel in) {
		readFromParcel(in);
	}
	
	private void readFromParcel(Parcel in) {
		 
		// We just need to read back each
		// field in the order that it was
		// written to the parcel
		this.latitud= in.readDouble();
		this.longitud= in.readDouble();
		this.fechaHora= in.readLong();
		this.presicion= in.readFloat();
		
	}
	
	@Override
	public int describeContents() {
		// TODO Auto-generated method stub
		return 0;
	}

	@Override
	public void writeToParcel(Parcel arg0, int arg1) {
		// TODO Auto-generated method stub
		arg0.writeDouble(latitud);
		arg0.writeDouble(longitud);
		arg0.writeLong(fechaHora);
		arg0.writeFloat(presicion);
	}
	
	 public double getLatitud() {
		return latitud;
	}

	public void setLatitud(double latitud) {
		this.latitud = latitud;
	}

	public double getLongitud() {
		return longitud;
	}

	public void setLongitud(double longitud) {
		this.longitud = longitud;
	}

	public long getFechaHora() {
		return fechaHora;
	}

	public void setFechaHora(long fechaHora) {
		this.fechaHora = fechaHora;
	}

	public float getPresicion() {
		return presicion;
	}

	public void setPresicion(float presicion) {
		this.presicion = presicion;
	}

	@SuppressWarnings("rawtypes")
	public static final  Parcelable.Creator CREATOR =
		    	new Parcelable.Creator() {
		            public DatosGPS createFromParcel(Parcel in) {
		                return new DatosGPS(in);
		            }
		 
		            public DatosGPS[] newArray(int size) {
		                return new DatosGPS[size];
		            }
		        };
	
}