package com.amesol.routelite.datos.basedatos;

import java.io.File;
import java.util.List;

import com.amesol.routelite.datos.ModuloTerm;
import com.amesol.routelite.datos.Usuario;
import com.amesol.routelite.datos.Vendedor;
import com.amesol.routelite.datos.generales.Entidad;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.ArchivoConfiguracion.CampoConfiguracion;
import com.amesol.routelite.datos.utilerias.CONHist;
import com.amesol.routelite.datos.utilerias.ConfigParametro;
import com.amesol.routelite.datos.utilerias.ConfiguracionLocal;
import com.amesol.routelite.datos.utilerias.MOTConfiguracion;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;

public class BDVend{
	private static final String NO_CONF ="no existe archivo de configuracion";
	private static final String NO_VEND ="usuario no seleccionado";
	public static final String NO_BD_VEND ="no existe la base de datos del vendedor";
	private static String nombreBD="";
	protected static BaseDatos bd = null;
	
	protected static synchronized BaseDatos getBD() throws Exception{
		if(bd == null) throw new Exception(NO_BD_VEND);
		return bd;
	}
	
	public static void Iniciar() throws Exception{
		crearInstancia();
		obtenerDatosSesion();
	}	
	
	private static void obtenerDatosSesion() throws Exception{
		if (BDVend.estaAbierta()){
			Vendedor vendedor = null;
			vendedor = Consultas.ConsultasVendedor.obtenerVendedorPorUsuario(getUsuarioTitular());
			if(vendedor == null) throw new Exception("vendedor no corresponde al usuario");
			Sesion.set(Campo.VendedorActual, vendedor);
			Sesion.set(Campo.CONHist, new CONHist());
			Sesion.set(Campo.MOTConfiguracion, new MOTConfiguracion());
			Sesion.set(Campo.ConfigParametro, new ConfigParametro());
			//Obtener el tipo de módulo para guardarlo en la sesion
			MOTConfiguracion motConfiguracion = (MOTConfiguracion)Sesion.get(Campo.MOTConfiguracion);
			ModuloTerm moduloTerm = new ModuloTerm();				
			moduloTerm.ModuloClave = motConfiguracion.get("ModuloClave").toString();
			BDVend.recuperar(moduloTerm);
			Sesion.set(Campo.TipoModulo, moduloTerm.TipoIndice);
		}
	}
	private static synchronized void crearInstancia() throws Exception{
		if (Sesion.get(Campo.ConfiguracionLocal) == null) throw new Exception(NO_CONF);
		ConfiguracionLocal conf =(ConfiguracionLocal)Sesion.get(Campo.ConfiguracionLocal);
		
		Usuario usuario = getUsuarioTitular();
		
		if(usuario == null) throw new Exception(NO_VEND);
		
		File archivoBD = new File(conf.get(CampoConfiguracion.DIRECTORIO_TRABAJO).toString());
		archivoBD = new File(archivoBD, "bd");		
		nombreBD = usuario.USUId + ".db";
		archivoBD = new File(archivoBD,nombreBD);		
		if(!archivoBD.exists()) return;
		bd = new BaseDatos(archivoBD.getAbsolutePath());
		bd.crearInstancia();		
	}
	
	public static synchronized void cerrar() throws Exception{
		if((bd != null)&&(bd.estaAbierta())){
			bd.cerrar();
			bd = null;			
		}
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
	
	public static String nombreBaseDatos(){
		return nombreBD;
	}
	public static void recuperar(Entidad entidad, Class<?> tipoHijos, String condicion) throws Exception{
		getBD().recuperar(entidad, tipoHijos, condicion);		
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
	public static void eliminar(List<Entidad> entidades) throws Exception{
		getBD().eliminar(entidades);
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
	
	private static Usuario getUsuarioTitular() throws Exception{
		Usuario usuario = (Usuario) Sesion.get(Campo.UsuarioActual);
		String claveTitular = ((ConfiguracionLocal)Sesion.get(Campo.ConfiguracionLocal)).get(CampoConfiguracion.USUARIO).toString();
		if(usuario == null || !usuario.Clave.equalsIgnoreCase(claveTitular)){
			return Consultas.ConsultasUsuario.obtenerUsuarioPorClave(claveTitular);
		}
		return usuario;
	}
}
