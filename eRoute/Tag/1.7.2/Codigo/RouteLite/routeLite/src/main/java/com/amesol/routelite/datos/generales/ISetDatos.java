package com.amesol.routelite.datos.generales;

import java.util.Date;

/**
 * Interfaz para mostrar el cursor que recorre las consultas de datos
 * 
 * @author Igor Avilés
 * 
 */
public interface ISetDatos {
	void close();
	void deactivate();
	byte[] getBlob(int columnIndex);
	int getColumnCount();
	int getColumnIndex(String columnName);
	int getColumnIndexOrThrow(String columnName);
	String getColumnName(int columnIndex);
	String[] getColumnNames();
	int getCount();
	
	double getDouble(int columnIndex);
	double getDouble(String columnName);
	
	float getFloat(int columnIndex);
	float getFloat(String columnName);
	
	int getInt(int columnIndex);
	int getInt(String columnName);
	
	long getLong(int columnIndex);
	long getLong(String columnName);
	
	int getPosition();
	
	short getShort(int columnIndex);
	short getShort(String columnName);
	
	String getString(int columnIndex);
	String getString(String columnName);
	
	Date getDate(int columnIndex);
	Date getDate(String columnName);
	
	boolean getBoolean(int columnIndex); 
	boolean getBoolean(String columnName); 
	
	
	
	int getType(int columnIndex);
	boolean getWantsAllOnMoveCalls();
	boolean isAfterLast();
	boolean isBeforeFirst();
	boolean isClosed();
	boolean isFirst();
	boolean isLast();
	boolean	isNull(int columnIndex);
	boolean	move(int offset);
	boolean	moveToFirst();
	boolean	moveToLast();
	boolean	moveToNext();
	boolean	moveToPosition(int position);
	boolean	moveToPrevious();
	boolean	requery();
	/**
	 * Obtiene el objeto original de la consulta dependiendo del tipo de base de datos que se utilize,
	 * para ser utilizado en la capa de vista
	 * 
	 * @return 
	 * Para android regresa objeto de tipo Cursor
	 */
	Object getOriginal();
}
