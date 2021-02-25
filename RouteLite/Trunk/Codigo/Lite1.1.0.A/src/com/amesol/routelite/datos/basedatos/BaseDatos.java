package com.amesol.routelite.datos.basedatos;

import java.io.File;
import java.lang.reflect.Field;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.HashMap;
import java.util.Iterator;
import java.util.List;

import android.content.ContentValues;
import android.database.Cursor;
import android.database.sqlite.SQLiteConstraintException;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteException;
import android.util.Log;

import com.amesol.routelite.datos.annotations.Campo;
import com.amesol.routelite.datos.annotations.Hijos;
import com.amesol.routelite.datos.annotations.Llave;
import com.amesol.routelite.datos.annotations.LlaveForanea;
import com.amesol.routelite.datos.annotations.TablaDef;
import com.amesol.routelite.datos.generales.Entidad;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.utilerias.Generales;

public class BaseDatos
{

	private List<Entidad> mEntidadesPendientes = new ArrayList<Entidad>();
	private SQLiteDatabase instancia = null;
	private String mCadenaConexion;

	public BaseDatos(String cadenaConexion)
	{
		mCadenaConexion = cadenaConexion;
	}

	private SQLiteDatabase getBD()
	{
		return instancia;
	}

	public synchronized void crearInstancia() throws Exception
	{
		File archivo = null;
		if (mCadenaConexion != null)
			archivo = new File(mCadenaConexion);

		if ((archivo == null) || (!archivo.exists()))
			throw new Exception("Base de datos inexistente");
		try
		{
			instancia = SQLiteDatabase.openOrCreateDatabase(archivo, null);
			instancia.execSQL("PRAGMA foreign_keys=ON;");
		}
		catch (SQLiteException ex)
		{
			Log.d("", ex.getMessage());
			throw new Exception(ex);
		}
	}

	public synchronized void crearInstanciaSinRelaciones() throws Exception
	{
		File archivo = null;
		if (mCadenaConexion != null)
			archivo = new File(mCadenaConexion);

		if ((archivo == null) || (!archivo.exists()))
			throw new Exception("Base de datos inexistente");
		try
		{
			instancia = SQLiteDatabase.openOrCreateDatabase(archivo, null);
			instancia.execSQL("PRAGMA foreign_keys=OFF;");
		}
		catch (SQLiteException ex)
		{
			Log.d("", ex.getMessage());
			throw new Exception(ex);
		}
	}

	public void cerrar()
	{
		SQLiteDatabase bd = getBD();
		bd.close();
		bd = null;
	}

	public synchronized boolean estaAbierta()
	{
		if (instancia == null)
			return false;
		return instancia.isOpen();
	}

	public static String obtenerNombreCampo(Field campo)
	{
		return "\"" + obtenerNombreCampoSolo(campo) + "\"";
	}

	public static String obtenerNombreCampoSolo(Field campo)
	{

		if (campo.isAnnotationPresent(Campo.class))
		{
			Campo c = campo.getAnnotation(Campo.class);
			if (c.nombreCampo().length() != 0)
				return c.nombreCampo();
			else
				return campo.getName();
		}
		else if (campo.isAnnotationPresent(Llave.class))
		{
			Llave c = campo.getAnnotation(Llave.class);
			;
			if (c.nombreCampo().length() != 0)
				return c.nombreCampo();
			else
				return campo.getName();
		}
		else if (campo.isAnnotationPresent(LlaveForanea.class))
		{
			LlaveForanea c = campo.getAnnotation(LlaveForanea.class);
			;
			if (c.nombreCampo().length() != 0)
				return c.nombreCampo();
			else
				return campo.getName();
		}
		//return null; //truena con el null?
		return "";
	}

	public static String obtenerNombreTabla(Class<?> tabla) throws Exception
	{
		return "\"" + obtenerNombreTablaSolo(tabla) + "\"";
	}

	public static String obtenerNombreTablaSolo(Class<?> tabla) throws Exception
	{
		if (!tabla.isAnnotationPresent(TablaDef.class))
			throw new Exception("la entidad " + tabla.getName() + " no es una entidad de Base de datos");
		String nombreTabla = tabla.getSimpleName();

		TablaDef anotacion = tabla.getAnnotation(TablaDef.class);
		if ((anotacion != null) && (anotacion.nombreTabla() != ""))
			nombreTabla = anotacion.nombreTabla();

		return nombreTabla;
	}

	private String obtenerInnerJoin(Class<?> tablaPadre, Class<?> tablaRelacionada) throws Exception
	{
		StringBuffer inner = new StringBuffer();
		String nombreTablaRelacionada = obtenerNombreTabla(tablaRelacionada);
		String nombreTablaPadre = obtenerNombreTabla(tablaPadre);
		inner.append(" INNER JOIN ");
		inner.append(nombreTablaRelacionada);
		inner.append(" ON ");
		boolean bandera = false;
		for (Field campo : tablaRelacionada.getFields())
		{
			if (campo.isAnnotationPresent(LlaveForanea.class))
			{
				LlaveForanea ll = campo.getAnnotation(LlaveForanea.class);
				if (ll.tablaPadre().equals(tablaPadre))
				{
					if (bandera)
						inner.append(" AND ");
					bandera = true;
					inner.append(nombreTablaRelacionada);
					inner.append(".");
					inner.append(obtenerNombreCampo(campo));
					inner.append("=");
					inner.append(nombreTablaPadre);
					inner.append(".\"");
					inner.append(ll.nombreCampoForaneo());
					inner.append("\"");
				}
			}
		}
		inner.append(" ");
		return inner.toString();
	}

	public void recuperar(Entidad entidad, Class<?> tipoHijos, String condicion) throws Exception
	{

		Class<?> clase = entidad.getClass();
		StringBuffer qry = new StringBuffer();
		qry.append("SELECT ");

		String nombreTabla = obtenerNombreTabla(tipoHijos);
		String nombreTablaPadre = obtenerNombreTabla(clase);

		boolean bandera = false;
		for (Field campo : tipoHijos.getFields())
		{
			if ((campo.isAnnotationPresent(Campo.class)) || (campo.isAnnotationPresent(Llave.class)) || (campo.isAnnotationPresent(LlaveForanea.class)))
			{
				if (bandera)
					qry.append(", ");
				qry.append(nombreTabla);
				qry.append(".");
				qry.append(obtenerNombreCampo(campo));
				bandera = true;
			}
		}
		qry.append(" FROM ");
		qry.append(nombreTablaPadre);
		qry.append(obtenerInnerJoin(clase, tipoHijos));
		qry.append(" WHERE ");

		Field hijosPadre = null;
		List<String> valores = new ArrayList<String>();
		bandera = false;
		for (Field campo : clase.getFields())
		{
			if (campo.isAnnotationPresent(Llave.class))
			{
				if (bandera)
					qry.append(" AND ");
				bandera = true;
				qry.append(nombreTablaPadre);
				qry.append(".");
				qry.append(obtenerNombreCampo(campo));
				qry.append("=?");
				valores.add(obtenerValor(campo.get(entidad)));
			}
			if (campo.isAnnotationPresent(Hijos.class))
			{
				Hijos h = campo.getAnnotation(Hijos.class);
				if (h.tablaHijos().equals(tipoHijos))
				{
					hijosPadre = campo;
				}
			}
		}

		if (condicion != "")
			qry.append(" AND " + condicion);

		Cursor cursor = getBD().rawQuery(qry.toString(), valores.toArray(new String[valores.size()]));

		boolean varios = false;

		Object hijos = hijosPadre.get(entidad);
		if (hijosPadre.getType().equals(List.class))
			varios = true;

		if ((varios) && (hijos == null))
			hijos = new ArrayList<Object>();
		else if (varios)
			((List<?>) hijos).clear();

		while (cursor.moveToNext())
		{
			Object hijo = tipoHijos.newInstance();
			llenarDatosEntidad((Entidad) hijo, cursor);
			if (varios)
				((List<Object>) hijos).add(hijo);
			else
			{
				hijos = hijo;
				break;
			}
		}
		cursor.close();
		hijosPadre.set(entidad, hijos);

	}

	public void recuperar(Entidad entidad, Class<?> tipoHijos) throws Exception
	{

		Class<?> clase = entidad.getClass();
		StringBuffer qry = new StringBuffer();
		qry.append("SELECT ");

		String nombreTabla = obtenerNombreTabla(tipoHijos);
		String nombreTablaPadre = obtenerNombreTabla(clase);

		boolean bandera = false;
		for (Field campo : tipoHijos.getFields())
		{
			if ((campo.isAnnotationPresent(Campo.class)) || (campo.isAnnotationPresent(Llave.class)) || (campo.isAnnotationPresent(LlaveForanea.class)))
			{
				if (bandera)
					qry.append(", ");
				qry.append(nombreTabla);
				qry.append(".");
				qry.append(obtenerNombreCampo(campo));
				bandera = true;
			}
		}
		qry.append(" FROM ");
		qry.append(nombreTablaPadre);
		qry.append(obtenerInnerJoin(clase, tipoHijos));
		qry.append(" WHERE ");

		Field hijosPadre = null;
		List<String> valores = new ArrayList<String>();
		for (Field campo : clase.getFields())
		{
			if (campo.isAnnotationPresent(Llave.class))
			{
				if (valores.size() > 0)
					qry.append(" AND ");
				qry.append(nombreTablaPadre);
				qry.append(".");
				qry.append(obtenerNombreCampo(campo));
				qry.append("=?");
				valores.add(obtenerValor(campo.get(entidad)));
			}
			if (campo.isAnnotationPresent(Hijos.class))
			{
				Hijos h = campo.getAnnotation(Hijos.class);
				if (h.tablaHijos().equals(tipoHijos))
				{
					hijosPadre = campo;
				}
			}
		}

		Cursor cursor = getBD().rawQuery(qry.toString(), valores.toArray(new String[valores.size()]));

		boolean varios = false;

		Object hijos = hijosPadre.get(entidad);
		if (hijosPadre.getType().equals(List.class))
			varios = true;

		if ((varios) && (hijos == null))
			hijos = new ArrayList<Object>();
		else if (varios)
			((List<?>) hijos).clear();

		while (cursor.moveToNext())
		{
			Object hijo = tipoHijos.newInstance();
			llenarDatosEntidad((Entidad) hijo, cursor);
			if (varios)
				((List<Object>) hijos).add(hijo);
			else
			{
				hijos = hijo;
				break;
			}
		}
		cursor.close();
		hijosPadre.set(entidad, hijos);

	}

	public void recuperar(Entidad entidad) throws Exception
	{
		String nombre = entidad.getClass().getSimpleName();
		List<String> campos = new ArrayList<String>();

		Class<?> clase = entidad.getClass();
		for (Field campo : clase.getFields())
		{
			String nombreCampo = obtenerNombreCampo(campo);
			if ((campo.isAnnotationPresent(Campo.class)) || (campo.isAnnotationPresent(Llave.class)) || (campo.isAnnotationPresent(LlaveForanea.class)))
			{
				if (!campos.contains(nombreCampo))
				{
					campos.add(nombreCampo);
				}
			}
		}
		List<String> valores = new ArrayList<String>();
		String filtro = obtenerCamposWhereLlavePrincipal(entidad, valores);

		Cursor cursor = getBD().query(nombre, campos.toArray(new String[campos.size()]), filtro, valores.toArray(new String[valores.size()]), null, null, null);
		if (cursor.moveToFirst())
		{
			llenarDatosEntidad(entidad, cursor);
		}
		cursor.close();
	}

	private void llenarDatosEntidad(Entidad entidad, Cursor cursor) throws IllegalArgumentException, IllegalAccessException
	{
		HashMap<String, Object> original = new HashMap<String, Object>();

		for (Field campo : entidad.getClass().getFields())
		{
			if ((campo.isAnnotationPresent(Campo.class)) || (campo.isAnnotationPresent(Llave.class)) || (campo.isAnnotationPresent(LlaveForanea.class)))
			{
				String nombreCampo = obtenerNombreCampoSolo(campo);
				int columna = cursor.getColumnIndex(nombreCampo);
				if (columna <0) continue;
				Object valor = null;
				if (campo.getType().equals(String.class))
				{
					valor = cursor.getString(columna);
					campo.set(entidad, valor);
				}
				else if (campo.getType().equals(Integer.class))
				{
					valor = cursor.getInt(columna);
					campo.set(entidad, valor);
				}
				else if (campo.getType().equals(int.class))
				{
					valor = cursor.getInt(columna);
					campo.setInt(entidad, (Integer) valor);
				}
				else if (campo.getType().equals(Float.class))
				{
					valor = cursor.getFloat(columna);
					campo.set(entidad, valor);
				}
				else if (campo.getType().equals(float.class))
				{
					valor = cursor.getFloat(columna);
					campo.setFloat(entidad, (Float) valor);
				}
				else if (campo.getType().equals(Double.class))
				{
					valor = cursor.getDouble(columna);
					campo.set(entidad, valor);
				}
				else if (campo.getType().equals(double.class))
				{
					valor = cursor.getDouble(columna);
					campo.setDouble(entidad, (Double) valor);
				}
				else if (campo.getType().equals(Byte[].class))
				{
					valor = cursor.getBlob(columna);
					campo.set(entidad, valor);
				}
				else if (campo.getType().equals(byte[].class))
				{
					valor = cursor.getBlob(columna);
					campo.set(entidad, valor);
				}
				else if (campo.getType().equals(Long.class))
				{
					valor = cursor.getLong(columna);
					campo.set(entidad, valor);
				}
				else if (campo.getType().equals(long.class))
				{
					valor = cursor.getLong(columna);
					campo.setLong(entidad, (Long) valor);
				}
				else if (campo.getType().equals(Short.class))
				{
					valor = cursor.getShort(columna);
					campo.set(entidad, valor);
				}
				else if (campo.getType().equals(short.class))
				{
					valor = cursor.getShort(columna);
					campo.setShort(entidad, (Short) valor);
				}
				else if (campo.getType().equals(Date.class))
				{
					SimpleDateFormat origen = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss");
					Date fecha = null;
					try
					{
						if (cursor.getString(columna) != null)
							fecha = origen.parse(cursor.getString(columna));
					}
					catch (ParseException e)
					{
						// TODO Auto-generated catch block
						e.printStackTrace();
					}
					campo.set(entidad, fecha);
				}
				else if (campo.getType().equals(Boolean.class) || campo.getType().equals(boolean.class))
				{
					valor = ((cursor.getShort(columna) == 1) ? true : false);
					campo.set(entidad, valor);
				}
				else
				{
					valor = cursor.getString(columna);
					campo.set(entidad, valor);
				}
				original.put(nombreCampo, valor);
			}
		}
		entidad.setValoresOriginales(original);
	}

	public void COMInsertarSinHijos(String nombreTabla, String campos, ContentValues contenido) throws Exception
	{
		iniciarTransaccion();

		try
		{
			//String campos = obtenerCamposInsert(entidad, contenido);
			getBD().insert(nombreTabla, campos, contenido);
		}
		catch (SQLiteConstraintException e1)
		{
			throw new Exception(e1.getMessage() + " :" + nombreTabla);
		}
	}

	public void COMguardarSinHijos(Entidad entidad) throws Exception
	{

		Class<?> clase = entidad.getClass();
		String nombreTabla = obtenerNombreTabla(clase);
		ContentValues contenido = new ContentValues();
		iniciarTransaccion();

		try
		{
			contenido = obtenerCamposUpdate(entidad);
			if (contenido.size() > 0)
			{
				List<String> valores = new ArrayList<String>();
				getBD().update(nombreTabla, contenido, obtenerCamposWhereLlavePrincipal(entidad, valores), valores.toArray(new String[valores.size()]));
			}
		}
		catch (SQLiteConstraintException e1)
		{
			throw new Exception(e1.getMessage() + " :" + nombreTabla);
		}
		guardarInsertarHijos(entidad);
	}

	public void guardarInsertar(Entidad entidad) throws Exception
	{

		boolean existe = existe(entidad);
		if ((existe) && (!entidad.isRecuperado()))
			//throw new Exception("Para modificar un registro existente, es nesesario recuperarlo primero");
			return;
		else if ((!existe) && (entidad.isRecuperado()))
			throw new Exception("No se puede modificar un registro inexistente");

		Class<?> clase = entidad.getClass();
		String nombreTabla = obtenerNombreTabla(clase);
		ContentValues contenido = new ContentValues();
		iniciarTransaccion();

		try
		{
			if (existe)
			{
				contenido = obtenerCamposUpdate(entidad);
				if (contenido.size() > 0)
				{
					List<String> valores = new ArrayList<String>();
					getBD().update(nombreTabla, contenido, obtenerCamposWhereLlavePrincipal(entidad, valores), valores.toArray(new String[valores.size()]));
					mEntidadesPendientes.add(entidad);
				}
			}
			else
			{
				String campos = obtenerCamposInsert(entidad, contenido);
				if (contenido.size() > 0)
				{
					long res = getBD().insertOrThrow(nombreTabla, campos, contenido);
					if (res < 0)
					{
						throw new Exception("Error al insertar el registro");
					}
					mEntidadesPendientes.add(entidad);
					regenerarOriginales(entidad);
				}
			}
		}
		catch (SQLiteConstraintException e1)
		{
			throw new Exception(e1.getMessage() + " :" + nombreTabla);
		}
		guardarInsertarHijos(entidad);
	}

	private void guardarInsertarHijos(Entidad entidad) throws Exception
	{
		for (Field campo : entidad.getClass().getFields())
		{
			if (campo.isAnnotationPresent(Hijos.class))
			{
				Object obj = campo.get(entidad);
				if (obj != null)
				{
					List<Entidad> hijos = (List<Entidad>) obj;
					for (Entidad ent : hijos)
					{
						guardarInsertar(ent);
					}
				}
			}
		}
	}

	public void eliminar(Entidad entidad, String filtro) throws Exception
	{
		Class<?> clase = entidad.getClass();
		String nombreTabla = obtenerNombreTabla(clase);

		iniciarTransaccion();
		try
		{
			getBD().delete(nombreTabla, filtro, null);
		}
		catch (SQLiteConstraintException e1)
		{
			throw new Exception(e1.getMessage() + " :" + nombreTabla);
		}
	}

	public void eliminar(Entidad entidad) throws Exception
	{
		Class<?> clase = entidad.getClass();
		String nombreTabla = obtenerNombreTabla(clase);
		List<String> valores = new ArrayList<String>();
		String filtro = "";

		filtro = obtenerCamposWhereLlavePrincipal(entidad, valores);
		if (valores.size() > 0)
		{
			iniciarTransaccion();
			try
			{
				getBD().delete(nombreTabla, filtro, valores.toArray(new String[valores.size()]));
			}
			catch (SQLiteConstraintException e1)
			{
				throw new Exception(e1.getMessage() + " :" + nombreTabla);
			}
		}
	}

	public void eliminar(List<Entidad> entidades) throws Exception
	{
		Iterator<Entidad> itEntidad = entidades.iterator();
		Entidad entidad;
		boolean primero = true;
		Class<?> clase;
		String nombreTabla = "";
		List<String> valores;
		String filtro = "";

		while (itEntidad.hasNext())
		{
			entidad = itEntidad.next();

			if (primero)
			{
				clase = entidad.getClass();
				nombreTabla = obtenerNombreTabla(clase);
			}

			valores = new ArrayList<String>();
			filtro = obtenerCamposWhereLlavePrincipal(entidad, valores);
			if (valores.size() > 0)
			{
				iniciarTransaccion();
				try
				{
					getBD().delete(nombreTabla, filtro, valores.toArray(new String[valores.size()]));
				}
				catch (SQLiteConstraintException e1)
				{
					throw new Exception(e1.getMessage() + " :" + nombreTabla);
				}
			}
		}
	}

	public void eliminarTodo(Entidad entidad) throws Exception
	{
		Class<?> clase = entidad.getClass();
		String nombreTabla = obtenerNombreTabla(clase);

		iniciarTransaccion();
		try
		{
			getBD().delete(nombreTabla, null, null);
		}
		catch (SQLiteConstraintException e1)
		{
			throw new Exception(e1.getMessage() + " :" + nombreTabla);
		}
	}

	public void eliminarTodo(Class<?> clase) throws Exception
	{
		String nombreTabla = obtenerNombreTabla(clase);

		iniciarTransaccion();
		try
		{
			getBD().delete(nombreTabla, null, null);
		}
		catch (SQLiteConstraintException e1)
		{
			throw new Exception(e1.getMessage() + " :" + nombreTabla);
		}
	}
	
	private void iniciarTransaccion() throws Exception
	{
		if (!getBD().inTransaction())
		{
			getBD().beginTransaction();

		}
	}

	public void commit() throws Exception
	{
		if (!getBD().inTransaction())
			return;

		getBD().setTransactionSuccessful();
		getBD().endTransaction();
		for (Entidad entidad : mEntidadesPendientes)
		{
			regenerarOriginales(entidad);
		}
		mEntidadesPendientes.clear();
	}

	private void regenerarOriginales(Entidad entidad) throws IllegalArgumentException, IllegalAccessException
	{
		HashMap<String, Object> original = new HashMap<String, Object>();
		for (Field campo : entidad.getClass().getFields())
		{
			if ((campo.isAnnotationPresent(Campo.class)) || (campo.isAnnotationPresent(Llave.class)) || (campo.isAnnotationPresent(LlaveForanea.class)))
			{
				String nombreCampo = obtenerNombreCampoSolo(campo);
				Object valor = campo.get(entidad);
				original.put(nombreCampo, valor);
			}
		}
		entidad.setValoresOriginales(original);
	}

	public void rollback() throws Exception
	{
		if (!getBD().inTransaction())
			return;

		getBD().endTransaction();
		mEntidadesPendientes.clear();
	}

	private ContentValues obtenerCamposUpdate(Entidad entidad) throws IllegalArgumentException, IllegalAccessException
	{
		HashMap<String, Object> ori = entidad.getOriginales();
		ContentValues valores = new ContentValues();

		for (Field campo : entidad.getClass().getFields())
		{
			if ((campo.isAnnotationPresent(Campo.class)) || (campo.isAnnotationPresent(LlaveForanea.class)))
			{
				String nombreCampo = obtenerNombreCampoSolo(campo);
				Object valor = campo.get(entidad);
				//if((((ori== null)&&(valor!=null))||(ori!=null && !ori.containsKey(nombreCampo))&&(valor != null))||(ori!=null && !ori.get(nombreCampo).equals(valor))){
				if ((((ori == null) && (valor != null)) || (ori != null && !ori.containsKey(nombreCampo)) && (valor != null)) || (ori != null && !(ori.get(nombreCampo) == valor)))
				{

					valores.put(nombreCampo, obtenerValor(valor));
				}
			}
		}
		return valores;
	}

	private String obtenerValor(Object valor)
	{
		if (valor.getClass().equals(Date.class))
		{
			SimpleDateFormat formatoSQLite = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss");
			return formatoSQLite.format((Date) valor);
		}
		else if (valor.getClass().equals(Boolean.class))
		{
			return (boolean) valor.equals(true) ? "1" : "0";
		}
		return valor.toString();
	}

	private String obtenerCamposInsert(Entidad entidad, ContentValues valores) throws IllegalArgumentException, IllegalAccessException
	{
		HashMap<String, Object> ori = entidad.getOriginales();
		if (valores == null)
			valores = new ContentValues();
		StringBuffer sb = new StringBuffer();
		for (Field campo : entidad.getClass().getFields())
		{
			if ((campo.isAnnotationPresent(Campo.class)) || (campo.isAnnotationPresent(LlaveForanea.class)) || (campo.isAnnotationPresent(Llave.class)))
			{
				String nombreCampo = obtenerNombreCampoSolo(campo);
				Object valor = campo.get(entidad);
				if ((((ori == null) && (valor != null)) || (ori != null && !ori.containsKey(nombreCampo)) && (valor != null)) || (ori != null && !ori.get(nombreCampo).equals(valor)))
				{
					valores.put(nombreCampo, obtenerValor(valor));
					if (sb.length() != 0)
						sb.append(",");
					sb.append("\"");
					sb.append(nombreCampo);
					sb.append("\"");
				}
			}
		}
		return sb.toString();
	}

	private String obtenerCamposWhereLlavePrincipal(Entidad entidad, List<String> valores) throws Exception
	{
		StringBuffer qry = new StringBuffer();
		if (valores == null)
			valores = new ArrayList<String>();
		String nombreTabla = obtenerNombreTabla(entidad.getClass());
		for (Field campo : entidad.getClass().getFields())
		{
			if (campo.isAnnotationPresent(Llave.class))
			{
				String nombreCampo = obtenerNombreCampoSolo(campo);
				Object valor = campo.get(entidad);
				if (qry.length() > 0)
					qry.append(" AND ");
				qry.append(nombreTabla);
				qry.append(".\"");
				qry.append(nombreCampo);
				qry.append("\" = ?");
				valores.add(obtenerValor(valor));
			}
		}
		return qry.toString();
	}

	public boolean existe(Entidad entidad) throws Exception
	{
		Class<?> clase = entidad.getClass();
		String nombreTabla = obtenerNombreTabla(clase);
		StringBuffer qry = new StringBuffer();
		qry.append("SELECT 1 FROM ");
		qry.append(nombreTabla);
		qry.append(" WHERE ");
		List<String> valores = new ArrayList<String>();
		qry.append(obtenerCamposWhereLlavePrincipal(entidad, valores));
		qry.append(" LIMIT 1 ");
		Cursor cursor = getBD().rawQuery(qry.toString(), valores.toArray(new String[valores.size()]));
		boolean res = (cursor.getCount() > 0);
		cursor.close();
		return res;
	}

	protected ISetDatos consultar(String consultaSQL) throws Exception
	{
		return consultar(consultaSQL, null);
	}

	protected ISetDatos consultar(String consultaSQL, Object[] parametros) throws Exception
	{
		try
		{
			String[] stringPar = null;
			if (parametros != null)
			{
				stringPar = new String[parametros.length];
				for (int i = 0; i < parametros.length; i++)
					stringPar[i] = parametros[i].toString();
			}

			Cursor cur = getBD().rawQuery(consultaSQL, stringPar);
			SetDatos sd = new SetDatos();
			sd.iniciar(cur);
			return (ISetDatos) sd;
		}
		catch (Exception ex)
		{
			ex.printStackTrace();
			return null;
		}
	}

	public ISetDatos consultar(Class<?> tabla) throws Exception
	{
		return consultar(tabla, null, null, null, null, null, null, null);
	}

	public ISetDatos consultar(Class<?> tabla, String[] columnas) throws Exception
	{
		return consultar(tabla, columnas, null, null, null, null, null, null);
	}

	public ISetDatos consultar(Class<?> tabla, String[] columnas, String filtro, Object[] parametros) throws Exception
	{
		return consultar(tabla, columnas, filtro, parametros, null, null, null, null);
	}

	public ISetDatos consultar(Class<?> tabla, String[] columnas, String filtro, Object[] parametros, String agrupador) throws Exception
	{
		return consultar(tabla, columnas, filtro, parametros, agrupador, null, null, null);
	}

	public ISetDatos consultar(Class<?> tabla, String[] columnas, String filtro, Object[] parametros, String agrupador, String having) throws Exception
	{
		return consultar(tabla, columnas, filtro, parametros, agrupador, having, null, null);
	}

	public ISetDatos consultar(Class<?> tabla, String[] columnas, String filtro, Object[] parametros, String agrupador, String having, String ordenamiento) throws Exception
	{
		return consultar(tabla, columnas, filtro, parametros, agrupador, having, ordenamiento, null);
	}

	protected ISetDatos consultar(Class<?> tabla, String[] columnas, String filtro, Object[] parametros, String agrupador, String having, String ordenamiento, String cantidad) throws Exception
	{
		String[] stringPar = null;
		if (parametros != null)
		{
			stringPar = new String[parametros.length];
			for (int i = 0; i < parametros.length; i++)
				stringPar[i] = parametros[i].toString();
		}
		String nombreTabla = obtenerNombreTabla(tabla);
		Cursor cur = getBD().query(nombreTabla, columnas, filtro, stringPar, agrupador, having, ordenamiento, cantidad);
		SetDatos sd = new SetDatos();
		sd.iniciar(cur);
		return (ISetDatos) sd;
	}

	public String ejecutarEscalar(String consultaSQL) throws Exception
	{
		return ejecutarEscalar(consultaSQL, null);
	}

	public String ejecutarEscalar(String consultaSQL, Object[] parametros) throws Exception
	{
		String[] stringPar = null;
		if (parametros != null)
		{
			stringPar = new String[parametros.length];
			for (int i = 0; i < parametros.length; i++)
				stringPar[i] = parametros[i].toString();
		}

		Cursor cur = getBD().rawQuery(consultaSQL, stringPar);
		SetDatos sd = new SetDatos();
		sd.iniciar(cur);

		String result = "";
		if (sd.getCount() > 0)
		{
			sd.moveToFirst();
			result = (sd.getString(0) == null ? "" : sd.getString(0));
		}
		sd.close();
		return result;
	}

	public Date ejecutarEscalarDate(String consultaSQL) throws Exception
	{
		Cursor cur = getBD().rawQuery(consultaSQL, null);
		SetDatos sd = new SetDatos();
		sd.iniciar(cur);

		Date result = Generales.getFechaActual();
		if (sd.getCount() > 0)
		{
			sd.moveToFirst();
			result = (sd.isNull(0) ? Generales.getFechaActual() : sd.getDate(0));
		}
		sd.close();
		return result;
	}

	public int ejecutarEscalarInteger(String consultaSQL) throws Exception
	{
		Cursor cur = getBD().rawQuery(consultaSQL, null);
		SetDatos sd = new SetDatos();
		sd.iniciar(cur);

		int result = 0;
		if (sd.getCount() > 0)
		{
			sd.moveToFirst();
			result = (sd.isNull(0) ? 0 : sd.getInt(0));
		}
		sd.close();
		return result;
	}

	public Object ejecutarEscalarObject(String consultaSQL) throws Exception
	{
		Cursor cur = getBD().rawQuery(consultaSQL, null);
		SetDatos sd = new SetDatos();
		sd.iniciar(cur);

		Object result = null;
		if (sd.getCount() > 0)
		{
			sd.moveToFirst();
			result = (sd.isNull(0) ? null : sd.getFloat(0));
		}
		sd.close();
		return result;
	}

	public Object instanciar(Class<?> tabla, ISetDatos setDatos) throws Exception
	{
		Object objeto = tabla.newInstance();
		Entidad entidad = (Entidad) objeto;
		Cursor cursor = (Cursor) setDatos.getOriginal();
		llenarDatosEntidad(entidad, cursor);
		return entidad;
	}

	protected void ejecutarComando(String comando)
	{
		getBD().execSQL(comando);
	}

}
