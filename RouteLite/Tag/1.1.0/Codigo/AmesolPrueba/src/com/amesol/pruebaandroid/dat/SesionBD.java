package com.amesol.pruebaandroid.dat;

import java.io.File;

import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteException;
import android.database.sqlite.SQLiteOpenHelper;
import android.os.Environment;
import android.util.Log;


public class SesionBD {
		
	private Context contexto; 
	
	private static class bdSingleton{
		
		private static SQLiteDatabase instancia = null;
		
		private synchronized static void crearInstancia(Context contexto){
			File archivo =  contexto.getDatabasePath("data.db");			
			/*if(!archivo.exists())
				archivo = new File("/sdcard/others/data.db");
			if(!archivo.exists()){
				File dir = Environment.getDataDirectory();				
				String[] d = dir.list();*/				
			archivo = new File(Environment.getExternalStorageDirectory().getPath()+"/download/data.db");
			//}

			try{
				instancia = SQLiteDatabase.openOrCreateDatabase(archivo, null);
			}catch(SQLiteException ex){
				Log.d("", ex.getMessage());
			} 
		}
		public static SQLiteDatabase getBD(Context contexto){
			if(instancia == null)crearInstancia(contexto);
				return instancia;
		}
	}
	private SQLiteDatabase getBD(){
		return bdSingleton.getBD(contexto);
	}
	
	public SesionBD(Context context) {
		//super(context, "data.db", null, 1);
		contexto = context;
	}
	
	
	public void insertar(Entidad e){
		if(!getBD().inTransaction())
			getBD().beginTransaction();
		
		String sql = "";
		Object[] args= null;
		e.insertar(sql,args);
		getBD().execSQL(sql, args);
	}
	public Cursor consultar(String table, String[] columns, String selection, String[] selectionArgs){
		return getBD().query(table, columns, selection, selectionArgs, null, null, null);
	}
	public Cursor consultar(String consulta, String[] selectionArgs){
		return getBD().rawQuery(consulta, selectionArgs);
	}
	
	public void rollback(){
		if(getBD().inTransaction())
			getBD().endTransaction();
	}
	public void commit(){
		if(getBD().inTransaction()){
			try{
				getBD().setTransactionSuccessful();
			}catch(Exception e){
				Log.e("Error en commit",e.toString());
			}finally{
				getBD().endTransaction();
			}
		}
	}
	
	
	
	public void dispose(){
		rollback();
	}
	/*@Override
	public void onCreate(SQLiteDatabase db) {
		
	}
	@Override
	public void onUpgrade(SQLiteDatabase db, int oldVersion, int newVersion) {
		
	}*/
	
}
