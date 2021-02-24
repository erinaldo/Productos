package com.duxstar.dacza.datos.basedatos;

import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.net.Uri;
import android.os.Environment;

import com.duxstar.dacza.datos.Inventario;
import com.duxstar.dacza.datos.DEVDetalle;
import com.duxstar.dacza.datos.Devolucion;
import com.duxstar.dacza.datos.Folio;
import com.duxstar.dacza.datos.FolioDetalle;
import com.duxstar.dacza.datos.ODTDetalle;
import com.duxstar.dacza.datos.OrdenTrabajo;
import com.duxstar.dacza.datos.RECDetalle;
import com.duxstar.dacza.datos.Recarga;
import com.duxstar.dacza.datos.Taller;
import com.duxstar.dacza.datos.annotations.Hijos;
import com.duxstar.dacza.datos.annotations.TablaDef;
import com.duxstar.dacza.datos.generales.ISetDatos;
import com.duxstar.dacza.datos.utilerias.ArchivoConfiguracion.CampoConfiguracion;
import com.duxstar.dacza.datos.utilerias.ConfiguracionLocal;
import com.duxstar.dacza.datos.utilerias.Sesion;
import com.duxstar.dacza.datos.utilerias.Sesion.Campo;

import java.io.File;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.IOException;
import java.lang.reflect.Field;
import java.net.URL;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.Enumeration;
import java.util.zip.ZipEntry;
import java.util.zip.ZipOutputStream;


public class Envio {
	
	public static final Class<?>[] TABLAS_ENVIO_AGENTE = new Class<?>[]{Taller.class, Folio.class, Inventario.class, OrdenTrabajo.class, ODTDetalle.class, Recarga.class, RECDetalle.class, Devolucion.class, DEVDetalle.class};
	public static final Class<?>[] TABLAS_ENVIO_ORDENES = new Class<?>[]{Taller.class, Folio.class, Inventario.class, OrdenTrabajo.class, ODTDetalle.class};
	public static final Class<?>[] TABLAS_ENVIO_INVENTARIO = new Class<?>[]{Taller.class, Folio.class, Inventario.class, Recarga.class, RECDetalle.class, Devolucion.class, DEVDetalle.class};
    public static final Class<?>[] TABLAS_ENVIO_RECARGAS = new Class<?>[]{Taller.class, Folio.class, Inventario.class, Recarga.class, RECDetalle.class};
    public static final Class<?>[] TABLAS_ENVIO_DEVOLUCIONES = new Class<?>[]{Taller.class, Folio.class, Inventario.class, Devolucion.class, DEVDetalle.class};
    public static final Class<?>[] TABLAS_ENVIO_ORDEN = new Class<?>[]{Taller.class, Folio.class, OrdenTrabajo.class};
    public static final Class<?>[] TABLAS_ENVIO_ORDEN_DETALLE = new Class<?>[]{Taller.class, Folio.class, Inventario.class, OrdenTrabajo.class, ODTDetalle.class};
    public static final Class<?>[] TABLAS_ENVIO_RECARGA = new Class<?>[]{Taller.class, Folio.class, Inventario.class, Recarga.class, RECDetalle.class};
    public static final Class<?>[] TABLAS_ENVIO_DEVOLUCION = new Class<?>[]{Taller.class, Folio.class, Inventario.class, Devolucion.class, DEVDetalle.class};

    public static String fileDatosEnviar( String idDocumento, Class<?>... clases ) throws Exception{
		String nombreBD = "";
		if((clases == null)||(clases.length == 0)){
			String ruta = "com.amesol.routelite.datos";
			Enumeration<URL> elementos = Thread.currentThread().getContextClassLoader().getResources(ruta.replace('.', '/'));
			ArrayList<Class<?>> arrClases = new ArrayList<Class<?>>();
			if(elementos != null){
				while(elementos.hasMoreElements()){
					String nombreClase = elementos.nextElement().getFile();
					if(nombreClase.endsWith(".class")){
						nombreClase = nombreClase.substring(0,nombreClase.length()-6);
						try{
							Class<?> clase = Class.forName(ruta + "." + nombreClase);
							arrClases.add(clase);
						} catch (ClassNotFoundException  e){}						
					}
				}
				
			}
			if(arrClases.size()> 0){
				clases = arrClases.toArray(new Class<?>[arrClases.size()]);
			}
		}
		if((clases == null)||(clases.length == 0)) throw new Exception("Al menos tiene que existir una entidad a enviar");
		ArrayList<EntidadEnvio> entidades = new ArrayList<EntidadEnvio>();
		for(Class<?> clase: clases){
			if(clase.isAnnotationPresent(TablaDef.class)){
				TablaDef anotacion = clase.getAnnotation(TablaDef.class);
				if(anotacion.orden() > 0){
					for(Field campo: clase.getFields()){
						if (!campo.isAnnotationPresent(Hijos.class)){
							String nombreCampo = BaseDatos.obtenerNombreCampoSolo(campo).toUpperCase();
							if(nombreCampo.equals("ENVIADO")){
								entidades.add(new EntidadEnvio(clase, anotacion.orden()));
								break;
							}	
						}
					}
				}
			}
		}
		
		if(entidades.size() == 0) throw new Exception("Al menos tiene que existir una entidad a enviar");		
		EntidadEnvio[] entidadesEnviar = entidades.toArray(new EntidadEnvio[entidades.size()]);	
		
		if (!hayDatosSinEnviar(entidadesEnviar, idDocumento)){
			throw new Exception("No hay información pendiente de Enviar");
		}

        TablaDef annTaller = Taller.class.getAnnotation(TablaDef.class);
        EntidadEnvio entTaller = new EntidadEnvio(Taller.class, annTaller.orden());
        if(!entidades.contains(entTaller)) {
            entidades.add(entTaller);
            entidadesEnviar = entidades.toArray(new EntidadEnvio[entidades.size()]);
        }


		ConfiguracionLocal conf = (ConfiguracionLocal) Sesion.get(Campo.ConfiguracionLocal);
		File archivoBD = new File(conf.get(CampoConfiguracion.DIRECTORIO_TRABAJO).toString());
		archivoBD = new File(archivoBD, "bd");
	
		SimpleDateFormat sdf = new SimpleDateFormat("yyyyMMddHHmmss");    
		String currentDateTimeString = sdf.format(new Date()); 
		nombreBD =  BDTerm.nombreBaseDatos().replace(".db", "-" + currentDateTimeString + ".db");
		File BDOrig = new File(archivoBD, BDTerm.nombreBaseDatos());
		archivoBD = new File(archivoBD,nombreBD);
		
		SQLiteDatabase db;
		db = SQLiteDatabase.openOrCreateDatabase(archivoBD.getAbsolutePath() , null);
		db.execSQL("ATTACH DATABASE '" + BDOrig.getAbsolutePath() + "' AS 'original'");
		db.beginTransaction();
		for(EntidadEnvio e: entidadesEnviar){
			Cursor cur = db.rawQuery("Select sql from 'original'.sqlite_master  where name = '" + e.getNombreTabla() + "'", null);
			SetDatos sd = new SetDatos();
			sd.iniciar(cur);
			//ISetDatos result = BDVend.consultar("Select sql from sqlite_master  where name = '" + e.getNombreTabla() + "'");
			String consultaCreate = ""; 
			if (sd.moveToFirst()){
				consultaCreate = sd.getString(0);
			}
			sd.close();
		
			db.execSQL(consultaCreate);
			db.execSQL( "INSERT into " + e.getNombreTabla() + " " +  obtenerConsulta(e.getEntidad(), true, idDocumento));
		}
		db.setTransactionSuccessful();
		db.endTransaction();
		db.execSQL("DETACH DATABASE 'original'");
		return nombreBD;
	}
	
	public static boolean hayDatosSinEnviar(EntidadEnvio[] entidadesEnviar, String idDocumento) throws Exception{
		//Arrays.sort(entidadesEnviar);
		for(EntidadEnvio e: entidadesEnviar){
            if (!e.getEntidad().equals(Taller.class)) {
                ISetDatos sd = obtenerDatos(e.getEntidad(), idDocumento);
                if (sd.moveToNext()) {
                    sd.close();
                    return true;
                } else {
                    sd.close();
                }
            }
		}
		return false;
	}
	
	private static ISetDatos obtenerDatos(Class<?> clase, String idDocumento) throws Exception{
        String sQuery = obtenerConsulta(clase, false, idDocumento);
        return BDTerm.consultar(sQuery);
	}

    private static String obtenerConsulta(Class<?> clase, boolean original, String idDocumento) throws Exception{
        StringBuilder sQuery = new StringBuilder();

        if(clase.equals(Taller.class)) {
            sQuery.append("select * from " + (original ? "original." : "") + "Taller ");
        }
        else if(clase.equals(OrdenTrabajo.class)){
            sQuery.append("select * from " + (original ? "original." : "") + "OrdenTrabajo where (Enviado is null or Enviado = 0) ");
            if (!idDocumento.equals(""))
                sQuery.append("and OrdenId = '" + idDocumento + "'");
        }
        else if(clase.equals(ODTDetalle.class)) {
            sQuery.append("select d.* ");
            sQuery.append("from " + (original ? "original." : "") + "ODTDetalle d ");
            sQuery.append("inner join " + (original ? "original." : "") + "OrdenTrabajo o on d.OrdenId = o.OrdenId ");
            sQuery.append("where (o.Enviado is null or o.Enviado = 0) ");
            sQuery.append("and o.Fase in (0, 2) ");
            if (!idDocumento.equals(""))
                sQuery.append("and o.OrdenId = '" + idDocumento + "'");
        }
        else if(clase.equals(Recarga.class)){
            sQuery.append("select * from " + (original ? "original." : "") + "Recarga where (Enviado is null or Enviado = 0) and Fase in (0, 2, 3) ");
            if (!idDocumento.equals(""))
                sQuery.append("and RecargaId = '" + idDocumento + "'");
        }
        else if(clase.equals(RECDetalle.class)) {
            sQuery.append("select d.* ");
            sQuery.append("from " + (original ? "original." : "") + "RECDetalle d ");
            sQuery.append("inner join " + (original ? "original." : "") + "Recarga r on d.RecargaId = r.RecargaId ");
            sQuery.append("where (r.Enviado is null or r.Enviado = 0) ");
            sQuery.append("and r.Fase in (0, 2) ");
            if (!idDocumento.equals(""))
                sQuery.append("and r.RecargaId = '" + idDocumento + "'");
        }
        else if(clase.equals(Devolucion.class)){
            sQuery.append("select * from " + (original ? "original." : "") + "Devolucion where (Enviado is null or Enviado = 0) and Fase in (0, 2) ");
            if (!idDocumento.equals(""))
                sQuery.append("and DevolucionId = '" + idDocumento + "'");
        }
        else if(clase.equals(DEVDetalle.class)) {
            sQuery.append("select dd.* ");
            sQuery.append("from " + (original ? "original." : "") + "DEVDetalle dd ");
            sQuery.append("inner join " + (original ? "original." : "") + "Devolucion d on dd.DevolucionId= d.DevolucionId ");
            sQuery.append("where (d.Enviado is null or d.Enviado = 0) ");
            sQuery.append("and d.Fase in (0, 2) ");
            if (!idDocumento.equals(""))
                sQuery.append("and d.DevolucionId = '" + idDocumento + "'");
        }
        else
		    sQuery.append( "select * from " + (original ? "original." : "") + clase.getSimpleName() + " where Enviado = 0 or Enviado is null ");

        return sQuery.toString();
	}

	public static void marcarEnviados(Class<?>... clases) throws Exception {
		ArrayList<EntidadEnvio> entidades = new ArrayList<EntidadEnvio>();
		for(Class<?> clase: clases){
            if (!clase.equals(Taller.class)) {
                if (clase.isAnnotationPresent(TablaDef.class)) {
                    TablaDef anotacion = clase.getAnnotation(TablaDef.class);
                    if (anotacion.orden() > 0) {
                        for (Field campo : clase.getFields()) {
                            if (!campo.isAnnotationPresent(Hijos.class)) {
                                String nombreCampo = BaseDatos.obtenerNombreCampoSolo(campo).toUpperCase();
                                if (nombreCampo.equals("ENVIADO")) {
                                    entidades.add(new EntidadEnvio(clase, anotacion.orden()));
                                    break;
                                }
                            }
                        }
                    }
                }
            }
		}
		for(EntidadEnvio entidad:entidades){
            BDTerm.ejecutarComando("UPDATE " + entidad.getNombreTabla() + " SET Enviado = 1");
        }
        BDTerm.commit();
	}


}
