package com.amesol.pruebaandroid.prov;

import java.util.ArrayList;
import java.util.List;
import java.util.Random;

import com.amesol.pruebaandroid.dat.SesionBD;

import android.app.SearchManager;
import android.content.ContentProvider;
import android.content.ContentResolver;
import android.content.ContentValues;
import android.database.CharArrayBuffer;
import android.database.ContentObserver;
import android.database.Cursor;
import android.database.DataSetObserver;
import android.database.MatrixCursor;
import android.net.Uri;
import android.os.Bundle;
import android.util.Log;

public class ProductoProvider extends ContentProvider {

	SesionBD sesion;
	
	private class Elemento{
		private Integer id;
		private String nombre;
		private Random valor;
		
		public Integer getId(){
			return id;
		}
		public String getNombre(){
			return nombre;
		}
		public Random getValor(){
			return valor;
		}
		public Elemento(Integer id, Random valor){
			this.id = id;
			this.nombre = String.valueOf(valor.nextFloat());
			this.valor = valor;
		}
	}
	
	private List<Elemento> lista = new ArrayList<Elemento>();
	
	@Override
	public int delete(Uri uri, String selection, String[] selectionArgs) {
		// TODO Auto-generated method stub
		return 0;
	}

	@Override
	public String getType(Uri uri) {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public Uri insert(Uri uri, ContentValues values) {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public boolean onCreate() {
		sesion = new SesionBD(getContext());
		return true;
	}

	@Override
	public Cursor query(Uri uri, String[] projection, String selection,
			String[] selectionArgs, String sortOrder) {
		
		 String cons = null;
         if (uri.getPathSegments().size() > 1) {
        	 cons = uri.getLastPathSegment();
         }
         if(cons!= null){
        	 
        	 /*MatrixCursor cursor = new MatrixCursor(
        			 new String[]{
        					 "_id",
        					 SearchManager.SUGGEST_COLUMN_TEXT_1,
        					 SearchManager.SUGGEST_COLUMN_TEXT_2,
        					 SearchManager.SUGGEST_COLUMN_INTENT_DATA
        			 });
        	 for(Elemento i: lista){
        		 if(i.getNombre().contains(query) || i.getId().toString().contains(query))
        			 cursor.addRow(new Object[]{i.getId(), String.valueOf(i.getId()), i.getNombre(),String.valueOf(i.getId())});
        	 }*/
        	 Cursor cursor = null;
        	 try{
        		 cursor = sesion.consultar("Producto", new String[]{
        				 "rowid AS _id", 
        				 "ProductoClave AS "+ SearchManager.SUGGEST_COLUMN_TEXT_1,
        				 "Descripcion AS "+ SearchManager.SUGGEST_COLUMN_TEXT_2,
        				 "ProductoClave AS "+ SearchManager.SUGGEST_COLUMN_INTENT_DATA
        		 }, "ProductoClave LIKE %?%", new String[]{cons});
        		 sesion.dispose();
        	 }catch(Exception e){
        		 Log.d("dd", e.getMessage());
        	 }
        	 return cursor;
         }
         return null;
	}

	@Override
	public int update(Uri uri, ContentValues values, String selection,
			String[] selectionArgs) {
		// TODO Auto-generated method stub
		return 0;
	}

}
