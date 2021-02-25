package com.amesol.routelite.presentadores.parcelables;

import java.util.ArrayList;
import java.util.HashMap;

import android.os.Bundle;
import android.os.Parcel;
import android.os.Parcelable;

public class DatosProductos implements Parcelable {

	private HashMap<String, HashMap<Integer, Float>> productos = new HashMap<String, HashMap<Integer, Float>>();
	
	public DatosProductos() {  };
	
	public DatosProductos(Parcel in){
		readFromParcel(in);
	}

	private void readFromParcel(Parcel in) {
		 
		// We just need to read back each
		// field in the order that it was
		// written to the parcel
		Bundle bundle = in.readBundle();
		this.productos = (HashMap<String, HashMap<Integer,Float>>) bundle.getSerializable("Objeto");
		
	}
	
	@Override
	public int describeContents() {
		// TODO Auto-generated method stub
		return 0;
	}

	@Override
	public void writeToParcel(Parcel dest, int flags) {
		Bundle bundle = new Bundle();
		bundle.putSerializable("Objeto", productos);
		dest.writeBundle(bundle);
	}
	
	public HashMap<String, HashMap<Integer,Float>> getProductos() {
		return productos;
	}

	public void setProductos(HashMap<String, HashMap<Integer,Float>> productos) {
		this.productos = productos;
	}

	@SuppressWarnings("rawtypes")
	public static final  Parcelable.Creator CREATOR =
		    	new Parcelable.Creator() {
		            public DatosProductos createFromParcel(Parcel in) {
		                return new DatosProductos(in);
		            }
		 
		            public DatosProductos[] newArray(int size) {
		                return new DatosProductos[size];
		            }
		        };
}
