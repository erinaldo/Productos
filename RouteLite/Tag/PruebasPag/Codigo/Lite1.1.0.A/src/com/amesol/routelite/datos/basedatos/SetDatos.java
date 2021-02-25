package com.amesol.routelite.datos.basedatos;

import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Date;

import android.database.Cursor;
import android.os.Bundle;

import com.amesol.routelite.datos.generales.ISetDatos;

public class SetDatos implements ISetDatos
{

	Cursor cursor = null;

	protected void iniciar(Cursor cursor)
	{
		this.cursor = cursor;
	}

	public void close()
	{
		cursor.close();

	}

	public void deactivate()
	{
		cursor.deactivate();
	}

	public byte[] getBlob(int columnIndex)
	{
		return cursor.getBlob(columnIndex);
	}

	public int getColumnCount()
	{
		return cursor.getColumnCount();

	}

	public int getColumnIndex(String columnName)
	{
		return cursor.getColumnIndex(columnName);
	}

	public int getColumnIndexOrThrow(String columnName)
	{
		return cursor.getColumnIndexOrThrow(columnName);
	}

	public String getColumnName(int columnIndex)
	{
		return cursor.getColumnName(columnIndex);
	}

	public String[] getColumnNames()
	{
		return cursor.getColumnNames();
	}

	public int getCount()
	{
		return cursor.getCount();
	}

	public double getDouble(int columnIndex)
	{
		return cursor.getDouble(columnIndex);
	}

	public double getDouble(String columnName)
	{
		return cursor.getDouble(cursor.getColumnIndex(columnName));
	}

	public float getFloat(int columnIndex)
	{
		return cursor.getFloat(columnIndex);
	}

	public float getFloat(String columnName)
	{
		return cursor.getFloat(cursor.getColumnIndex(columnName));
	}

	public int getInt(int columnIndex)
	{
		return cursor.getInt(columnIndex);
	}

	public int getInt(String columnName)
	{
		return cursor.getInt(cursor.getColumnIndex(columnName));
	}

	public long getLong(int columnIndex)
	{
		return cursor.getLong(columnIndex);
	}

	public long getLong(String columnName)
	{
		return cursor.getLong(cursor.getColumnIndex(columnName));
	}

	public int getPosition()
	{
		return cursor.getPosition();
	}

	public short getShort(int columnIndex)
	{
		return cursor.getShort(columnIndex);
	}

	public short getShort(String columnName)
	{
		return cursor.getShort(cursor.getColumnIndex(columnName));
	}

	public String getString(int columnIndex)
	{
		return cursor.getString(columnIndex);
	}

	public String getString(String columnName)
	{
		return cursor.getString(cursor.getColumnIndex(columnName));
	}

	public int getType(int columnIndex)
	{
		return 0;
	}

	public boolean getWantsAllOnMoveCalls()
	{
		return cursor.getWantsAllOnMoveCalls();
	}

	public boolean isAfterLast()
	{
		return cursor.isAfterLast();
	}

	public boolean isBeforeFirst()
	{
		return cursor.isBeforeFirst();
	}

	public boolean isClosed()
	{
		return cursor.isClosed();
	}

	public boolean isFirst()
	{
		return cursor.isFirst();
	}

	public boolean isLast()
	{
		return cursor.isLast();
	}

	public boolean isNull(int columnIndex)
	{
		return cursor.isNull(columnIndex);
	}

	public boolean move(int offset)
	{
		return cursor.move(offset);
	}

	public boolean moveToFirst()
	{
		return cursor.moveToFirst();
	}

	public boolean moveToLast()
	{
		return cursor.moveToLast();
	}

	public boolean moveToNext()
	{
		return cursor.moveToNext();
	}

	public boolean moveToPosition(int position)
	{
		return cursor.moveToPosition(position);
	}

	public boolean moveToPrevious()
	{
		return cursor.moveToPrevious();
	}

	public boolean requery()
	{
		return cursor.requery();

	}

	/**
	 * Obtiene el objeto original <br>
	 * <br>
	 * En el caso de Android el objeto original es Cursor, por lo que en la capa
	 * de vista se puede usar para listar por ejemplo: <br>
	 * Cursor cursor = (Cursor)setdatos.getOriginal();
	 * 
	 */
	public Object getOriginal()
	{
		return cursor;
	}

	public void dispose()
	{
		if (cursor != null)
		{
			if (!cursor.isClosed())
				cursor.close();
			cursor = null;
		}
	}

	public Date getDate(int columnIndex)
	{
		SimpleDateFormat formato = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss");
		String sFecha = getString(columnIndex);
		Date fecha = null;
		if (sFecha != null)
		{
			try
			{
				fecha = formato.parse(sFecha);
			}
			catch (ParseException e)
			{
				e.printStackTrace();
			}
		}
		return fecha;
	}

	public Date getDate(String columnName)
	{
		return getDate(this.getColumnIndex(columnName));
	}

	public boolean getBoolean(int columnIndex)
	{
		return cursor.getInt(columnIndex) == 1;
	}

	public boolean getBoolean(String columnName)
	{
		return cursor.getInt(cursor.getColumnIndex(columnName)) == 1;
	}
}
