package com.duxstar.dacza.datos.basedatos;

import java.io.File;

import com.duxstar.dacza.datos.generales.Entidad;
import com.duxstar.dacza.datos.generales.ISetDatos;
import com.duxstar.dacza.datos.utilerias.ArchivoConfiguracion.CampoConfiguracion;
import com.duxstar.dacza.datos.utilerias.ConfiguracionLocal;
import com.duxstar.dacza.datos.utilerias.Sesion;
import com.duxstar.dacza.datos.utilerias.Sesion.Campo;
import com.duxstar.dacza.vistas.ConfiguracionTerminal;

public class BDTerm  {
	
	private static final String NO_CONF ="no existe archivo de configuracion";
	public static final String NO_BD_TERM ="no existe la base de datos de la aplicacion";
	protected static BaseDatos bd = null;
	private static String nombreBD="";
	
	protected static synchronized BaseDatos getBD() throws Exception{
		if(bd == null) throw new Exception(NO_BD_TERM);
		return bd;
	}
	
	private static synchronized void crearInstancia() throws Exception{
		if (Sesion.get(Campo.ConfiguracionLocal) == null) throw new Exception(NO_CONF);
		ConfiguracionLocal conf =(ConfiguracionLocal)Sesion.get(Campo.ConfiguracionLocal);

        File archivoBD = new File(conf.get(CampoConfiguracion.DIRECTORIO_TRABAJO).toString());
		archivoBD = new File(archivoBD, "bd");
		nombreBD =  conf.get(CampoConfiguracion.NUMERO_SERIE)+".db";
		archivoBD = new File(archivoBD,nombreBD);


		bd = new BaseDatos(archivoBD.getAbsolutePath());
		bd.crearInstancia();		
	}

	public static void Iniciar() throws Exception {
		crearInstancia();
	}
	
	public static synchronized void cerrar() throws Exception{
		if((bd != null)&&(bd.estaAbierta())){
			bd.cerrar();
			bd = null;			
		}
	}
	
	public static String nombreBaseDatos(){
		return nombreBD;
	}
	public static synchronized boolean estaAbierta() {
		boolean abierta = false;
		try {
			if(bd == null) return false;
			abierta = bd.estaAbierta();
		} catch (Exception e) {			
			e.printStackTrace();
			return false;
		}
		return abierta;
	}
	
	
	public static void recuperar(Entidad entidad, Class<?> tipoHijos) throws Exception{
		getBD().recuperar(entidad, tipoHijos);		
	}	
	public static void recuperar(Entidad entidad) throws Exception {
		getBD().recuperar(entidad);
	}
	public static void guardarInsertar(Entidad entidad) throws Exception{
		getBD().guardarInsertar(entidad);		
	}
	public static void eliminar(Entidad entidad) throws Exception{
		getBD().eliminar(entidad);
	}
	public static void commit() throws Exception{
		getBD().commit();
	}
	public static void rollback() throws Exception{
		getBD().rollback();
	}	
	public static boolean existe(Entidad entidad) throws Exception{
		return getBD().existe(entidad);	
	}
	public static ISetDatos consultar(Class<?> tabla) throws Exception{
		return getBD().consultar(tabla);
	}
	public static ISetDatos consultar(Class<?> tabla, String[] columnas) throws Exception{
		 return getBD().consultar(tabla, columnas);
	}
	public static ISetDatos consultar(Class<?> tabla, String[] columnas, String filtro, Object[] parametros) throws Exception{
		 return getBD().consultar(tabla, columnas, filtro, parametros);
	}
	public static ISetDatos consultar(Class<?> tabla, String[] columnas, String filtro, Object[] parametros, String agrupador) throws Exception{
		 return getBD().consultar(tabla, columnas, filtro, parametros, agrupador);
	}
	public static ISetDatos consultar(Class<?> tabla, String[] columnas, String filtro, Object[] parametros, String agrupador, String having) throws Exception{
		return getBD().consultar(tabla, columnas, filtro, parametros, agrupador, having);
	}
	public static ISetDatos consultar(Class<?> tabla, String[] columnas, String filtro, Object[] parametros, String agrupador, String having, String ordenamiento) throws Exception{
		 return getBD().consultar(tabla, columnas, filtro, parametros, agrupador, having, ordenamiento);
	}	
	protected static ISetDatos consultar(String consultaSQL) throws Exception{
		return getBD().consultar(consultaSQL);
	}
	protected static ISetDatos consultar(String consultaSQL, Object[] parametros) throws Exception{
		return getBD().consultar(consultaSQL, parametros);
	}
	
	protected static ISetDatos consultar(Class<?> tabla, String[] columnas, String filtro, Object[] parametros, String agrupador, String having, String ordenamiento, String cantidad ) throws Exception{
		return getBD().consultar(tabla, columnas, filtro, parametros, agrupador, having, ordenamiento, cantidad);
	}
	
	public static Object instanciar(Class<?> tabla, ISetDatos setDatos) throws Exception{
		return getBD().instanciar(tabla, setDatos);
	}	
	
	protected static void ejecutarComando(String comando) throws Exception{
		getBD().ejecutarComando(comando);
	}
}
