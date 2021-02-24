package com.duxstar.dacza.presentadores.act;

import android.os.Environment;
import android.text.TextUtils;

import java.io.File;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.io.OutputStream;
import java.util.Calendar;
import java.util.Collection;
import java.util.Date;
import java.util.Hashtable;
import java.util.zip.ZipEntry;
import java.util.zip.ZipInputStream;
import java.util.zip.ZipOutputStream;

import com.duxstar.dacza.datos.RECDetalle;
import com.duxstar.dacza.datos.Recarga;
import com.duxstar.dacza.datos.Taller;
import com.duxstar.dacza.datos.Usuario;
import com.duxstar.dacza.datos.basedatos.BDTerm;
import com.duxstar.dacza.datos.basedatos.Consultas;
import com.duxstar.dacza.datos.basedatos.Envio;
import com.duxstar.dacza.datos.basedatos.Recepcion;
import com.duxstar.dacza.datos.utilerias.ArchivoConfiguracion;
import com.duxstar.dacza.datos.utilerias.ArchivoConfiguracion.CampoConfiguracion;
import com.duxstar.dacza.datos.utilerias.ConfiguracionLocal;
import com.duxstar.dacza.datos.utilerias.Sesion;
import com.duxstar.dacza.datos.utilerias.Sesion.Campo;
import com.duxstar.dacza.presentadores.Enumeradores;
import com.duxstar.dacza.presentadores.Enumeradores.Acciones;
import com.duxstar.dacza.presentadores.Enumeradores.TipoEnvioInfo;
import com.duxstar.dacza.presentadores.Presentador;
import com.duxstar.dacza.presentadores.interfaces.IServidorComunicaciones;
import com.duxstar.dacza.vistas.utilerias.Dispositivo;
import com.duxstar.dacza.vistas.utilerias.DocumentoXML;
import com.duxstar.dacza.vistas.utilerias.ServicesCentral;

import org.w3c.dom.Document;
import org.w3c.dom.NodeList;

import javax.xml.parsers.DocumentBuilder;
import javax.xml.parsers.DocumentBuilderFactory;
import javax.xml.transform.Transformer;
import javax.xml.transform.TransformerFactory;
import javax.xml.transform.dom.DOMSource;
import javax.xml.transform.stream.StreamResult;

public class ServirComunicaciones extends Presentador
{
    private IServidorComunicaciones mVista;
    private String mAccion;
    private int tipoEnvioInfo = TipoEnvioInfo.ENVIO_AGENTE;
    private String idDocumento = "";


    public ServirComunicaciones(IServidorComunicaciones vista, String accion)
    {
        this.mVista = vista;
        this.mAccion = accion;
    }

    public ServirComunicaciones(IServidorComunicaciones vista, String accion, int tipoEnvioInfo)
    {
        this.mVista = vista;
        this.mAccion = accion;
        this.tipoEnvioInfo = tipoEnvioInfo;
    }

    public ServirComunicaciones(IServidorComunicaciones vista, String accion, int tipoEnvioInfo, String idDocumento)
    {
        this.mVista = vista;
        this.mAccion = accion;
        this.tipoEnvioInfo = tipoEnvioInfo;
        this.idDocumento = idDocumento;
    }

    /*public ServirComunicaciones(IServidorComunicaciones vista, String accion, String tablas)
    {
        this.mVista = vista;
        this.mAccion = accion;
        this.mTablas = tablas;
    }*/

    @Override
    public void iniciar()
    {
        Sesion.set(Campo.PermitirRecibir, true);
        mVista.iniciar();
        if (mAccion != null)
        {
            if (mAccion.equals(Acciones.ACCION_OBTENER_BD_TERMINAL))
            {
                obtenerBDAsync();
            }
            else if (mAccion.equals(Acciones.ACCION_ENVIAR_BD_TERMINAL))
            {
                enviarDatosAsync();
            }
            else if (mAccion.equals(Acciones.ACCION_RECIBIR_TRASPASOS))
            {
                recibirDatosAsync();
            }
        }
    }

    public void obtenerBDAsync()
    {
        Runnable obtenerBD = new Runnable()
        {
            public void run()
            {
                obtenerBD();
            }
        };
        new Thread(obtenerBD).start();
    }

    private void obtenerBD()
    {
        String nombreArchivo = "";
        ConfiguracionLocal conf = (ConfiguracionLocal) Sesion.get(Sesion.Campo.ConfiguracionLocal);
        try
        {
            mVista.setMaxPasos(4);
            mVista.setTextoPasos("Probando Acceso a Servicio");

            if (Boolean.parseBoolean(conf.get(CampoConfiguracion.WIFI).toString()))
            {
                Dispositivo.EncenderApagarWiFi(mVista, true, 4);
            }
            //Validar Conexion con el servicio
            if (!ServicesCentral.ProbarAccesoServicio())
            {
                mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, "No se puede establecer conexión de Area Local. Avisar a Soporte Técnico.");
                mVista.finalizar();
                return;
            }

            mVista.setProgresoPasos(1);
            mVista.setTextoPasos("Creando Base Datos");

            if (mAccion.equals(Enumeradores.Acciones.ACCION_OBTENER_BD_TERMINAL))
            {
                nombreArchivo = ServicesCentral.WSAplicacionObtenerBDSqLite();
            }
        }
        catch (Exception e)
        {
            e.printStackTrace();
            mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, e.getMessage());
            mVista.finalizar();
            return;
        }

        mVista.setProgresoPasos(2);
        mVista.setTextoPasos("Descargando Archivo");

        try
        {

            File destino = new File(conf.get(CampoConfiguracion.DIRECTORIO_TRABAJO).toString());
            destino = new File(destino, "bd");
            destino.mkdirs();
            String dirDestino = destino.getAbsolutePath();
            destino = new File(destino, nombreArchivo + ".zip");

            if (destino.exists())
                destino.delete();
            destino.createNewFile();

            int[] tamanioArchivo =
                    { 0 };

            InputStream in = ServicesCentral.DescargarBD(nombreArchivo, tamanioArchivo);
            OutputStream out = new FileOutputStream(destino);
            Integer total = (int) (tamanioArchivo[0] / 1024);
            mVista.setMaxDetallePasos(total);
            long actual = 0;
            byte[] buf = new byte[1024];
            int len;
            while ((len = in.read(buf)) > 0)
            {
                out.write(buf, 0, len);
                actual += len;
                Integer actualKB = (int) (actual / 1024);
                mVista.setProgresoDetallePasos(actualKB);
                mVista.setTextoProgreso("descargando base de datos (" + actualKB.toString() + " de " + total.toString() + ")");
            }
            in.close();
            out.close();

            mVista.setMaxDetallePasos(0);
            mVista.setTextoProgreso("");

            mVista.setProgresoPasos(3);
            mVista.setTextoPasos("Descomprimiendo Archivo");

            FileInputStream fin = new FileInputStream(destino.getAbsolutePath());
            ZipInputStream zin = new ZipInputStream(fin);
            ZipEntry ze = null;
            while ((ze = zin.getNextEntry()) != null)
            {
                File resFile = new File(dirDestino, ze.getName());
                if (resFile.exists())
                    resFile.delete();
                FileOutputStream fout = new FileOutputStream(resFile.getAbsolutePath());

                byte[] tempBuffer = new byte[8192 * 2];
                total = (int) (ze.getSize() / (8192 * 2));
                total = (total * 2);
                mVista.setMaxDetallePasos(total);
                actual = 0;
                while ((len = zin.read(tempBuffer)) != -1)
                {
                    fout.write(tempBuffer, 0, len);
                    actual += len;
                    Integer actualKB = (int) (actual / 8192 * 2);
                    mVista.setProgresoDetallePasos(actualKB);
                    mVista.setTextoProgreso("descomprimiendo base de datos (" + actualKB.toString() + " de " + total.toString() + ")");
                }

                zin.closeEntry();
                fout.close();
            }
            zin.close();
            fin.close();
            destino.delete();

            ServicesCentral.WSEliminarArchivoBases(nombreArchivo + ".zip");

            if (Boolean.parseBoolean(conf.get(CampoConfiguracion.WIFI).toString()))
            {
                Dispositivo.EncenderApagarWiFi(mVista, false, 0);
            }

            mVista.setProgresoPasos(4);
            mVista.setTextoPasos("Proceso Finalizado.....");

        }
        catch (FileNotFoundException e)
        {
            e.printStackTrace();
            mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, e.getMessage());
            mVista.finalizar();
            return;
        }
        catch (IOException e)
        {
            e.printStackTrace();
            mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, e.getMessage());
            mVista.finalizar();
            return;
        }
        catch (Exception e)
        {
            e.printStackTrace();
            mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, e.getMessage());
            mVista.finalizar();
            return;
        }

        mVista.setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
        mVista.finalizar();
    }

    private void enviarDatosAsync()
    {
        Runnable enviarDatos = new Runnable()
        {
            public void run()
            {
                enviarDatos();
            }
        };
        new Thread(enviarDatos).start();
    }

    private void enviarDatos()
    {
        ConfiguracionLocal conf = (ConfiguracionLocal) Sesion.get(Campo.ConfiguracionLocal);

        mVista.setMaxPasos(5);

        mVista.setTextoPasos("Preparando para enviar datos...");
        String nombreArchivo = "";
        try
        {
            mVista.setProgresoPasos(1);
            mVista.setTextoPasos("Probando Acceso al servicio");

            if (Boolean.parseBoolean(conf.get(CampoConfiguracion.WIFI).toString()))
                Dispositivo.EncenderApagarWiFi(mVista, true, 4);

            //Validar Conexion con el servicio
            if (!ServicesCentral.ProbarAccesoServicio())
            {
                mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, "No se puede establecer conexión de Área Local. Avisar a Soporte");
                mVista.finalizar();
                Sesion.set(Campo.PermitirRecibir, false);
                return;
            }

            mVista.setProgresoPasos(2);
            mVista.setTextoPasos("Preparando paquete de envio");


            StringBuilder sbMsgError = new StringBuilder();
            if (tipoEnvioInfo == TipoEnvioInfo.ENVIO_AGENTE)
                nombreArchivo = Envio.fileDatosEnviar( "", Envio.TABLAS_ENVIO_AGENTE );
            else if (tipoEnvioInfo == TipoEnvioInfo.ENVIO_ORDENES)
                nombreArchivo = Envio.fileDatosEnviar( "", Envio.TABLAS_ENVIO_ORDENES );
            else if (tipoEnvioInfo == TipoEnvioInfo.ENVIO_INVENTARIO)
                nombreArchivo = Envio.fileDatosEnviar( "", Envio.TABLAS_ENVIO_INVENTARIO );
            else if (tipoEnvioInfo == TipoEnvioInfo.ENVIO_RECARGAS)
                nombreArchivo = Envio.fileDatosEnviar( "", Envio.TABLAS_ENVIO_RECARGAS );
            else if (tipoEnvioInfo == TipoEnvioInfo.ENVIO_DEVOLUCIONES)
                nombreArchivo = Envio.fileDatosEnviar( "", Envio.TABLAS_ENVIO_DEVOLUCIONES );
            else if (tipoEnvioInfo == TipoEnvioInfo.ENVIO_ORDEN)
                nombreArchivo = Envio.fileDatosEnviar( idDocumento, Envio.TABLAS_ENVIO_ORDEN );
            else if (tipoEnvioInfo == TipoEnvioInfo.ENVIO_ORDEN_DETALLE)
                nombreArchivo = Envio.fileDatosEnviar( idDocumento, Envio.TABLAS_ENVIO_ORDEN_DETALLE );
            else if (tipoEnvioInfo == TipoEnvioInfo.ENVIO_RECARGA)
                nombreArchivo = Envio.fileDatosEnviar( idDocumento, Envio.TABLAS_ENVIO_RECARGA );
            else if (tipoEnvioInfo == TipoEnvioInfo.ENVIO_DEVOLUCION)
                nombreArchivo = Envio.fileDatosEnviar( idDocumento, Envio.TABLAS_ENVIO_DEVOLUCION );
        }
        catch (Exception e)
        {
            e.printStackTrace();
            mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, e.getMessage());
            mVista.finalizar();
            return;
        }
        mVista.setProgresoPasos(3);
        mVista.setTextoPasos("Creando ZIP");

        File zipSal = new File(conf.get(CampoConfiguracion.DIRECTORIO_TRABAJO).toString(), "bd");
        try
        {
            File bdComprimir = new File(zipSal.getAbsolutePath(), nombreArchivo);
            zipSal = new File(zipSal.getAbsolutePath(), nombreArchivo.replace(".db", ".zip"));

            byte[] buffer = new byte[1024];
            FileOutputStream fout = new FileOutputStream(zipSal.getAbsolutePath());
            ZipOutputStream zout = new ZipOutputStream(fout);
            FileInputStream fin = new FileInputStream(bdComprimir.getAbsolutePath());
            zout.putNextEntry(new ZipEntry(bdComprimir.getName()));
            int length;
            Integer total = (int) (bdComprimir.length() / 1024);
            mVista.setMaxDetallePasos(total);
            long actual = 0;
            while ((length = fin.read(buffer)) > 0)
            {
                zout.write(buffer, 0, length);
                actual += length;
                Integer actualKB = (int) (actual / 1024);
                mVista.setProgresoDetallePasos(actualKB);
                mVista.setTextoProgreso("Comprimiendo base de datos (" + actualKB.toString() + " de " + total.toString() + ")");
            }
            zout.closeEntry();
            fin.close();
            zout.close();
            bdComprimir.delete();
        }
        catch (IOException e)
        {
            e.printStackTrace();
            mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, e.getMessage());
            mVista.finalizar();
            return;
        }
        catch (Exception e)
        {
            e.printStackTrace();
            mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, e.getMessage());
            mVista.finalizar();
            return;
        }

        mVista.setProgresoPasos(4);
        mVista.setTextoPasos("Enviando Información");

        boolean enviarImagenes = false;
        String directorioImagenes = "";
        try
        {
            if (tipoEnvioInfo == TipoEnvioInfo.ENVIO_AGENTE || tipoEnvioInfo == TipoEnvioInfo.ENVIO_INVENTARIO || tipoEnvioInfo == TipoEnvioInfo.ENVIO_RECARGAS ) {
                directorioImagenes = imagenesRecargas("");
                enviarImagenes = true;
            }
            else if (tipoEnvioInfo == TipoEnvioInfo.ENVIO_RECARGA){
                directorioImagenes = imagenesRecargas(idDocumento);
                enviarImagenes = true;
            }
            if (enviarImagenes){
                if (directorioImagenes.length() > 0) {
                    ServicesCentral.WSEnviarImagenesRecargas(directorioImagenes); // llamamos el metodo para comprimir las imagenes
                }
            }

            ServicesCentral.WSActualizarCapturaSQLite(false, zipSal.getAbsolutePath());
            //mVista.mostrarError(Mensajes.get("MDBTodos"));
            zipSal.delete();
            zipSal = new File(conf.get(CampoConfiguracion.DIRECTORIO_TRABAJO).toString(), "bd");
            zipSal = new File(zipSal.getAbsolutePath(), nombreArchivo.replace(".db", ".db-journal"));

            zipSal.delete();
        }
        catch (Exception e)
        {
            mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, e.getMessage());
            zipSal.delete();
            zipSal = new File(conf.get(CampoConfiguracion.DIRECTORIO_TRABAJO).toString(), "bd");
            zipSal = new File(zipSal.getAbsolutePath(), nombreArchivo.replace(".db", ".db-journal"));
            zipSal.delete();
            mVista.finalizar();
            return;
        }
        mVista.setProgresoPasos(5);
        mVista.setTextoPasos("Enviando Información");
        try
        {
            if (tipoEnvioInfo == TipoEnvioInfo.ENVIO_AGENTE)
                Envio.marcarEnviados(Envio.TABLAS_ENVIO_AGENTE);
            else if (tipoEnvioInfo == TipoEnvioInfo.ENVIO_ORDENES)
                Envio.marcarEnviados(Envio.TABLAS_ENVIO_ORDENES);
            else if (tipoEnvioInfo == TipoEnvioInfo.ENVIO_INVENTARIO)
                Envio.marcarEnviados(Envio.TABLAS_ENVIO_INVENTARIO);
            else if (tipoEnvioInfo == TipoEnvioInfo.ENVIO_RECARGAS)
                Envio.marcarEnviados(Envio.TABLAS_ENVIO_RECARGAS);
            else if (tipoEnvioInfo == TipoEnvioInfo.ENVIO_DEVOLUCIONES)
                Envio.marcarEnviados(Envio.TABLAS_ENVIO_DEVOLUCIONES);
            else if (tipoEnvioInfo == TipoEnvioInfo.ENVIO_ORDEN)
                Envio.marcarEnviados(Envio.TABLAS_ENVIO_ORDEN);
            else if (tipoEnvioInfo == TipoEnvioInfo.ENVIO_ORDEN_DETALLE)
                Envio.marcarEnviados(Envio.TABLAS_ENVIO_ORDEN_DETALLE);
            else if (tipoEnvioInfo == TipoEnvioInfo.ENVIO_RECARGA)
                Envio.marcarEnviados(Envio.TABLAS_ENVIO_RECARGA);
            else if (tipoEnvioInfo == TipoEnvioInfo.ENVIO_DEVOLUCION)
                Envio.marcarEnviados(Envio.TABLAS_ENVIO_DEVOLUCION);

            if (tipoEnvioInfo == TipoEnvioInfo.ENVIO_AGENTE || tipoEnvioInfo == TipoEnvioInfo.ENVIO_INVENTARIO || tipoEnvioInfo == TipoEnvioInfo.ENVIO_RECARGAS || tipoEnvioInfo == TipoEnvioInfo.ENVIO_RECARGA ) {
                File zipImages = new File(directorioImagenes);
                if (zipImages.exists())
                    zipImages.delete();
            }

        }
        catch (Exception e)
        {
            e.printStackTrace();
            mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, e.getMessage());
            mVista.finalizar();
            return;
        }

        /*mVista.setProgresoPasos(6);
        mVista.setTextoPasos("Ejecutando Interfaces");
        try
        {
            ServicesCentral.WSEjecutarInterfaces(vendedor.VendedorId, vendedor.Fecha, Consultas.ConsultasServidorComunicaciones.obtenerFechaPrimerDia(), false);

        }
        catch (Exception e)
        {
            mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, e.getMessage());
            mVista.finalizar();
            return;
        }

        try
        {
            ServicesCentral.WSActualizarSincronizacion(vendedor.VendedorId, Generales.getFechaHoraActual());
        }
        catch (Exception e)
        {
            mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, e.getMessage());
            mVista.finalizar();
            return;
        }*/

        mVista.setProgresoPasos(6);
        mVista.setTextoPasos("Envío Finalizado.....");

        mVista.setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
        mVista.finalizar();
    }

    private void recibirDatosAsync()
    {
        Runnable recibirDatos = new Runnable()
        {
            public void run()
            {
                recibirDatos();
            }
        };
        new Thread(recibirDatos).start();
    }

    private void recibirDatos()
    {
        Sesion.set(Campo.PermitirRecibir, false);
        mVista.setMaxPasos(7);
        mVista.setTextoPasos("Preparando para recibir datos...");
        ConfiguracionLocal conf = (ConfiguracionLocal) Sesion.get(Campo.ConfiguracionLocal);
        String nombreArchivo = "";
        ArchivoConfiguracion configuracion;
        configuracion = new ArchivoConfiguracion(mVista);
        String sFechaInicio = configuracion.getValor(CampoConfiguracion.FECHA).toString();

        DocumentBuilderFactory dbf = DocumentBuilderFactory.newInstance();
        DocumentBuilder db;
        Document xmlActualiza;
        boolean archivosServerEliminados = true;
        try
        {
            File archXML = new File(conf.get(CampoConfiguracion.DIRECTORIO_TRABAJO).toString());
            archXML = new File(archXML, "bd");
            archXML = new File(archXML, conf.get(CampoConfiguracion.NUMERO_SERIE).toString() + ".xml");

            db = dbf.newDocumentBuilder();
            xmlActualiza = db.parse(new File(archXML.getAbsolutePath()));

            mVista.setProgresoPasos(1);
            mVista.setTextoPasos("Probando Acceso al servicio");

            if (Boolean.parseBoolean(conf.get(CampoConfiguracion.WIFI).toString()))
            {
                Dispositivo.EncenderApagarWiFi(mVista, true, 4);
            }

            //Validar Conexion con el servicio
            if (!ServicesCentral.ProbarAccesoServicio())
            {
                mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, "No se puede establecer conexión de Área Local. Avisar a Soporte ");
                mVista.finalizar();
                return;
            }

            mVista.setProgresoPasos(2);
            mVista.setTextoPasos("Solicitando información");

            if (mAccion.equals(Acciones.ACCION_RECIBIR_TRASPASOS))
            {
               nombreArchivo = ServicesCentral.WSTallerObtenerTraspasos(((Taller) Sesion.get(Campo.TallerActual)).TallerId, sFechaInicio);
            }

            if (nombreArchivo.equals(""))
            {
                if (Boolean.parseBoolean(conf.get(CampoConfiguracion.WIFI).toString()))
                {
                    Dispositivo.EncenderApagarWiFi(mVista, false, 4);
                }
                mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, "No existen datos para actualizar");
                mVista.finalizar();
                return;
            }

        }
        catch (Exception e)
        {
            e.printStackTrace();
            mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, e.getMessage());
            mVista.finalizar();
            return;
        }

        mVista.setProgresoPasos(3);
        mVista.setTextoPasos("Recibiendo datos");

        boolean archivosEliminados = true;
        archivosServerEliminados = false;
        String extensionBorrar="";
        String dirDestino="";
        try
        {

            File destino = new File(conf.get(CampoConfiguracion.DIRECTORIO_TRABAJO).toString());
            destino = new File(destino, "bd");
            destino.mkdirs();
            dirDestino = destino.getAbsolutePath();
            destino = new File(destino, nombreArchivo + ".zip");

            if (destino.exists())
                destino.delete();
            destino.createNewFile();

            int[] tamanioArchivo =
                    { 0 };
            InputStream in = ServicesCentral.DescargarBD(nombreArchivo, tamanioArchivo);
            OutputStream out = new FileOutputStream(destino);

            Integer total = (int) (tamanioArchivo[0] / 1024);
            mVista.setMaxDetallePasos(total);
            long actual = 0;
            byte[] buf = new byte[1024];
            int len;
            while ((len = in.read(buf)) > 0)
            {
                out.write(buf, 0, len);
                actual += len;
                Integer actualKB = (int) (actual / 1024);
                mVista.setProgresoDetallePasos(actualKB);
                mVista.setTextoProgreso("descargando base de datos (" + actualKB.toString() + " de " + total.toString() + ")");
            }
            in.close();
            out.close();

            mVista.setProgresoPasos(4);
            mVista.setTextoPasos("Descomprimiendo Archivo");

            FileInputStream fin = new FileInputStream(destino.getAbsolutePath());
            ZipInputStream zin = new ZipInputStream(fin);
            ZipEntry ze = null;
            while ((ze = zin.getNextEntry()) != null)
            {
                File resFile = new File(dirDestino, ze.getName());
                if (resFile.exists())
                    resFile.delete();
                FileOutputStream fout = new FileOutputStream(resFile.getAbsolutePath());

                byte[] tempBuffer = new byte[8192 * 2];
                total = (int) (ze.getSize() / (8192 * 2));
                total = (total * 2);
                mVista.setMaxDetallePasos(total);
                actual = 0;
                while ((len = zin.read(tempBuffer)) != -1)
                {
                    fout.write(tempBuffer, 0, len);
                    actual += len;
                    Integer actualKB = (int) (actual / 8192 * 2);
                    mVista.setProgresoDetallePasos(actualKB);
                    mVista.setTextoProgreso("descomprimiendo base de datos (" + actualKB.toString() + " de " + total.toString() + ")");
                }

                zin.closeEntry();
                fout.close();
            }
            zin.close();
            fin.close();
            destino.delete();

            mVista.setProgresoDetallePasos(0);
            mVista.setTextoProgreso("");

            mVista.setProgresoPasos(5);
            mVista.setTextoPasos("Procesando datos");
            archivosEliminados = false;
            if (mAccion.equals(Acciones.ACCION_RECIBIR_TRASPASOS))
            {
                extensionBorrar = ".xml";
                Recepcion.procesarDataSetTraspaso(nombreArchivo + ".xml", xmlActualiza);
                ServicesCentral.WSTallerMarcarTraspasosEnviados(((Taller) Sesion.get(Campo.TallerActual)).TallerId, sFechaInicio, ((Usuario)Sesion.get(Campo.UsuarioActual)).UsuarioId);
            }
            File dataSet = new File(dirDestino, nombreArchivo + extensionBorrar);
            dataSet.delete();
            if (extensionBorrar.equalsIgnoreCase(".db")){
                dataSet = new File(dirDestino, nombreArchivo + ".db-journal");
                dataSet.delete();
            }
            archivosEliminados = true;

            ServicesCentral.WSEliminarArchivoBases(nombreArchivo + ".zip");
            archivosServerEliminados = true;

            if (Boolean.parseBoolean(conf.get(CampoConfiguracion.WIFI).toString()))
            {
                Dispositivo.EncenderApagarWiFi(mVista, false, 0);
            }

            mVista.setProgresoPasos(6);
            mVista.setTextoPasos("Cargando datos");

            mVista.setProgresoPasos(7);
            mVista.setTextoPasos("Recepcion Finalizada.....");

        }
        catch (FileNotFoundException e)
        {
            if (!archivosEliminados){
                File dataSet = new File(dirDestino, nombreArchivo + extensionBorrar);
                dataSet.delete();
                if (extensionBorrar.equalsIgnoreCase(".db")){
                    dataSet = new File(dirDestino, nombreArchivo + ".db-journal");
                    dataSet.delete();
                }
            }
            if(!archivosServerEliminados){
                ServicesCentral.WSEliminarArchivoBases(nombreArchivo + ".zip");
            }
            mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, e.getMessage());
            mVista.finalizar();
            return;
        }
        catch (IOException e)
        {
            if (!archivosEliminados){
                File dataSet = new File(dirDestino, nombreArchivo + extensionBorrar);
                dataSet.delete();
                if (extensionBorrar.equalsIgnoreCase(".db")){
                    dataSet = new File(dirDestino, nombreArchivo + ".db-journal");
                    dataSet.delete();
                }
            }
            if(!archivosServerEliminados){
                ServicesCentral.WSEliminarArchivoBases(nombreArchivo + ".zip");
            }
            mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, e.getMessage());
            mVista.finalizar();
            return;
        }
        catch (NullPointerException e)
        {
            if (!archivosEliminados){
                File dataSet = new File(dirDestino, nombreArchivo + extensionBorrar);
                dataSet.delete();
                if (extensionBorrar.equalsIgnoreCase(".db")){
                    dataSet = new File(dirDestino, nombreArchivo + ".db-journal");
                    dataSet.delete();
                }
            }
            if(!archivosServerEliminados){
                ServicesCentral.WSEliminarArchivoBases(nombreArchivo + ".zip");
            }
            mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, "Error de nulos");
            mVista.finalizar();
            return;
        }
        catch (Exception e)
        {
            if (!archivosEliminados){
                File dataSet = new File(dirDestino, nombreArchivo + extensionBorrar);
                dataSet.delete();
                if (extensionBorrar.equalsIgnoreCase(".db")){
                    dataSet = new File(dirDestino, nombreArchivo + ".db-journal");
                    dataSet.delete();
                }
            }
            if(!archivosServerEliminados){
                ServicesCentral.WSEliminarArchivoBases(nombreArchivo + ".zip");
            }
            mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, e.getMessage());
            mVista.finalizar();
            return;
        }


        mVista.setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
        mVista.finalizar();
    }

    private String imagenesRecargas(String idDocumento)
    {
        File destino = new File(Environment.getExternalStoragePublicDirectory("dacza").toString());
        String directorio = destino.getAbsolutePath();
        File dire = new File(destino, "Imagenes");

        if(dire.isDirectory() && dire.exists())
        {
            try
            {
                Hashtable htImagenes = Consultas.ConsultasRecarga.obtenerImagenes(idDocumento);
                ZipOutputStream out = new ZipOutputStream(new FileOutputStream(directorio+"/ImagenRecarga.zip"));

                agregarDir(dire, out, htImagenes); // manda a llamar el metodo agregar Dir y mandamos el path donde estan las imagenes y donde se guardara el zip
                out.close();
                dire.delete();

                return directorio+"/ImagenRecarga.zip";
            }
            catch (FileNotFoundException e)
            {
                // TODO Auto-generated catch block
                e.printStackTrace();
            }
            catch (IOException e)
            {
                // TODO Auto-generated catch block
                e.printStackTrace();
            }
            catch (Exception e){
                e.printStackTrace();
            }

        }

        return "";
    }

    /*private String imagenesRecargas(String idDocumento)
    {
        File destino = new File(Environment.getExternalStoragePublicDirectory("dacza").toString());
        String directorio = destino.getAbsolutePath();
        File dire = new File(destino, "Imagenes");

        if(dire.isDirectory() && dire.exists())
        {
            try
            {
                Recarga recarga = new Recarga();
                recarga.RecargaId = idDocumento;
                BDTerm.recuperar(recarga);
                BDTerm.recuperar(recarga, RECDetalle.class);

                ZipOutputStream out = new ZipOutputStream(new FileOutputStream(directorio+"/ImagenRecarga.zip"));

                agregarDir(dire, out, recarga); // manda a llamar el metodo agregar Dir y mandamos el path donde estan las imagenes y donde se guardara el zip
                out.close();
                dire.delete();

                return directorio + "/ImagenRecarga.zip";
            }
            catch (FileNotFoundException e)
            {
                // TODO Auto-generated catch block
                e.printStackTrace();
            }
            catch (IOException e)
            {
                // TODO Auto-generated catch block
                e.printStackTrace();
            }
            catch (Exception e){
                e.printStackTrace();
            }

        }

        return "";
    }*/

    public void agregarDir(File dirObj, ZipOutputStream out, Hashtable htImagenes) throws IOException
    {
        File[] files = dirObj.listFiles();
        byte[] tmpBuf = new byte[1024];
        String fileName = "";

        for (int i = 0; i < files.length; i++) {
            //Log.v("Directorio", files[i].getName());
            if (files[i].isDirectory()) {
                agregarDir(files[i], out, htImagenes);
                continue;
            }
            fileName = files[i].getName().replace(".jpg", "");
            if (htImagenes.containsKey(fileName)) {

                FileInputStream in = new FileInputStream(files[i].getAbsolutePath());
                //Log.v(" Adding: ", "ImagenEncuesta/"+files[i].getName());


                out.putNextEntry(new ZipEntry("ImagenRecarga/" + files[i].getName()));
                int len;
                while ((len = in.read(tmpBuf)) > 0) {
                    out.write(tmpBuf, 0, len);
                }
                out.closeEntry();
                in.close();
            }
        }
    }

    /*public void agregarDir(File dirObj, ZipOutputStream out, Recarga recarga) throws IOException
    {
        File[] files = dirObj.listFiles();
        byte[] tmpBuf = new byte[1024];
        String fileName = "";

        for (int i = 0; i < files.length; i++) {
            //Log.v("Directorio", files[i].getName());
            if (files[i].isDirectory()) {
                agregarDir(files[i], out, recarga);
                continue;
            }
            FileInputStream in = new FileInputStream(files[i].getAbsolutePath());
            //Log.v(" Adding: ", "ImagenEncuesta/"+files[i].getName());
            fileName = files[i].getName().replace(".jpg", "");
            for (RECDetalle detalle : recarga.RECDetalle) {
                if (detalle.Imagen != null)
                    if (detalle.Imagen.equals(fileName)){
                        out.putNextEntry(new ZipEntry("ImagenRecarga/"+files[i].getName()));
                        break;
                    }
            }

            int len;
            while ((len = in.read(tmpBuf)) > 0) {
                out.write(tmpBuf, 0, len);
            }
            out.closeEntry();
            in.close();
        }
    }*/
}
