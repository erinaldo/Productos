package com.duxstar.dacza.datos.basedatos;

import android.content.ContentValues;
import android.util.Log;
import android.util.Xml;

import com.duxstar.dacza.actividades.Inventario;
import com.duxstar.dacza.datos.Articulo;
import com.duxstar.dacza.datos.ODTDetalle;
import com.duxstar.dacza.datos.Recarga;
import com.duxstar.dacza.datos.TRPDetalle;
import com.duxstar.dacza.datos.Traspaso;
import com.duxstar.dacza.datos.Usuario;
import com.duxstar.dacza.datos.generales.Entidad;
import com.duxstar.dacza.datos.generales.ISetDatos;
import com.duxstar.dacza.datos.utilerias.ArchivoConfiguracion.CampoConfiguracion;
import com.duxstar.dacza.datos.utilerias.ConfiguracionLocal;
import com.duxstar.dacza.datos.utilerias.Sesion;
import com.duxstar.dacza.datos.utilerias.Sesion.Campo;
import com.duxstar.dacza.presentadores.Enumeradores;
import com.duxstar.dacza.utilerias.Generales;

import org.w3c.dom.Document;
import org.w3c.dom.NodeList;
import org.xmlpull.v1.XmlPullParser;

import java.io.BufferedInputStream;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.io.PushbackInputStream;
import java.io.Reader;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Calendar;
import java.util.Date;
import java.util.GregorianCalendar;
import java.util.List;

import javax.xml.transform.Transformer;
import javax.xml.transform.TransformerFactory;
import javax.xml.transform.dom.DOMSource;
import javax.xml.transform.stream.StreamResult;

/**
 * Created by Adriana on 11/07/2016.
 */
public class Recepcion {


    public static final List<String> TABLAS_TRASPASO = Arrays.asList("Traspaso", "TRPDetalle");

    public static boolean procesarDataSetTraspaso(String nombreArchivo, Document xmlActualiza) throws Exception
    {
        try
        {
            ConfiguracionLocal conf = (ConfiguracionLocal) Sesion.get(Campo.ConfiguracionLocal);
            File archivoBD = new File(conf.get(CampoConfiguracion.DIRECTORIO_TRABAJO).toString());
            archivoBD = new File(archivoBD, "bd");

            File dataset = new File(archivoBD, nombreArchivo);
            File dirXml;

            dirXml = new File(archivoBD, BDTerm.nombreBaseDatos().replace(".db", ".xml"));

            XmlPullParser parser = Xml.newPullParser();
            try
            {
                InputStream is = new FileInputStream(dataset);

                Reader reader = new InputStreamReader(checkForUtf8BOMAndDiscardIfAny(is));
                parser.setInput(reader);

                int eventType = 0;
                for (int type = parser.getEventType(); type != XmlPullParser.START_TAG; type = parser.next())
                {
                    Log.e("", "" + type);
                }

                //Category currentCategory = null;
                boolean done = false;

                String nombreTabla = "";
                String nombreCampoActual = "";
                String valorCampoActual = "";
                String listadoCampos = "";
                boolean bTablaNueva = false;
                ContentValues valoresCampos = new ContentValues();

                Class tablaClase;
                Entidad entidad = null;
                SimpleDateFormat df = new SimpleDateFormat("yyyy-MM-dd'T'HH:mm:ss'Z'");
                boolean tablaLimpia = false;

                ContentValues fechasActualizacion = new ContentValues();

                while (eventType != XmlPullParser.END_DOCUMENT && !done)
                {
                    switch (eventType)
                    {
                        case XmlPullParser.START_DOCUMENT:
                            break;
                        case XmlPullParser.TEXT:
                            valorCampoActual = parser.getText();
                            break;
                        case XmlPullParser.START_TAG:
                            //Si es tabla
                            if (parser.getDepth() == 2)
                            {
                                if (!nombreTabla.equals(parser.getName()))
                                {
                                    bTablaNueva = true;
                                    listadoCampos = "";
                                    nombreTabla = parser.getName();
                                    tablaClase = Class.forName("com.duxstar.dacza.datos." + nombreTabla);
                                    entidad = (Entidad) tablaClase.newInstance();
                                    tablaLimpia = false;
                                }
                                valoresCampos.clear();
                            }
                            else if (parser.getDepth() == 3)
                            {
                                nombreCampoActual = parser.getName();
                            }
                            break;
                        case XmlPullParser.END_TAG:
                            if (parser.getDepth() == 2)
                            {
                                bTablaNueva = false;
                                entidad.setValores(valoresCampos);

                                if (entidad.getClass().equals(Articulo.class)){
                                    Articulo oArticuloDS = ((Articulo)entidad);
                                    Articulo oArticulo = new Articulo();
                                    oArticulo.ArticuloId = oArticuloDS.ArticuloId;
                                    BDTerm.recuperar(oArticulo);
                                    if (!BDTerm.existe(oArticulo)){
                                        oArticulo.Clave = oArticuloDS.Clave;
                                        oArticulo.Descripcion = oArticuloDS.Descripcion;
                                        oArticulo.Grupo = oArticuloDS.Grupo;
                                        oArticulo.Unidad = oArticuloDS.Unidad;
                                        oArticulo.Tipo = oArticuloDS.Tipo;

                                        BDTerm.guardarInsertar(oArticulo);
                                    }
                                }

                                if (entidad.getClass().equals(Traspaso.class))
                                {
                                    Traspaso oTraspDS = ((Traspaso)entidad);
                                    Traspaso oTrasp = new Traspaso();
                                    oTrasp.TraspasoId = oTraspDS.TraspasoId;
                                    //oTrasp.RecargaId = oTraspDS.RecargaId;
                                    oTrasp.Fecha = oTraspDS.Fecha;
                                    oTrasp.Folio = oTraspDS.Folio;

                                    BDTerm.guardarInsertar(oTrasp);

                                    /*Recarga oRecarga = new Recarga();
                                    //oRecarga.RecargaId = oTrasp.RecargaId;
                                    BDTerm.recuperar(oRecarga);
                                    if (BDTerm.existe(oRecarga))
                                    {
                                        oRecarga.Fase = Enumeradores.TiposFasesDocto.SURTIDO;
                                        oRecarga.MFechaHora = Generales.getFechaHoraActual();
                                        oRecarga.MUsuarioId = ((Usuario)Sesion.get(Campo.UsuarioActual)).UsuarioId;

                                        BDTerm.guardarInsertar(oRecarga);
                                    }*/
                                }

                                if (entidad.getClass().equals(TRPDetalle.class))
                                {
                                    TRPDetalle oDetalleDS = ((TRPDetalle)entidad);
                                    TRPDetalle oDetalle = new TRPDetalle();
                                    oDetalle.TraspasoId = oDetalleDS.TraspasoId;
                                    oDetalle.ArticuloId = oDetalleDS.ArticuloId;
                                    oDetalle.Cantidad = oDetalleDS.Cantidad;
                                    oDetalle.Partida = oDetalleDS.Partida;

                                    BDTerm.guardarInsertar(oDetalle);

                                    Inventario.ActualizarInventario(oDetalle.ArticuloId, oDetalle.Cantidad, Enumeradores.TiposMovimientoInv.ENTRADA);
                                }


                            }
                            else if (parser.getDepth() == 3)
                            {
                                if (bTablaNueva)
                                {
                                    listadoCampos += "\"" + nombreCampoActual + "\",";
                                }
                                if (valorCampoActual.equalsIgnoreCase("true") || valorCampoActual.equalsIgnoreCase("false"))
                                {
                                    valoresCampos.put(nombreCampoActual, (valorCampoActual.equalsIgnoreCase("true") ? 1 : 0));
                                }
                                else
                                {
                                    valoresCampos.put(nombreCampoActual, valorCampoActual);
                                }

                            }

                            break;
                    }

                    //Falla Aqui
                    eventType = parser.next();
                }

                if (!nombreTabla.equals(""))
                {
                    Calendar cal = new GregorianCalendar();
                    Date date = cal.getTime();
                    String formatteDate = df.format(date);
                    fechasActualizacion.put(nombreTabla, formatteDate);
                }

                NodeList tablas = xmlActualiza.getFirstChild().getChildNodes();

                for (int i = 0; i <= tablas.getLength() - 1; i++)
                {
                    nombreTabla = tablas.item(i).getChildNodes().item(0).getTextContent();
                    if (fechasActualizacion.containsKey(nombreTabla))
                    {
                        tablas.item(i).getChildNodes().item(1).setTextContent(fechasActualizacion.get(nombreTabla).toString());
                    }
                }
                BDTerm.commit();

                TransformerFactory transformerFactory = TransformerFactory.newInstance();
                Transformer transformer = transformerFactory.newTransformer();
                DOMSource source = new DOMSource(xmlActualiza);
                StreamResult result = new StreamResult(dirXml);

                //				fIn.close();
                transformer.transform(source, result);
                return true;
            }

            catch (FileNotFoundException e)
            {
                BDTerm.rollback();
                throw e;
            }
            catch (IOException e)
            {
                BDTerm.rollback();
                throw e;
            }
            catch (Exception e)
            {
                BDTerm.rollback();
                throw e;
            }

        }
        catch (Exception e)
        {
            throw e;
        }

    }

    private static InputStream checkForUtf8BOMAndDiscardIfAny(InputStream inputStream) throws IOException
    {
        PushbackInputStream pushbackInputStream = new PushbackInputStream(new BufferedInputStream(inputStream), 3);
        byte[] bom = new byte[3];
        if (pushbackInputStream.read(bom) != -1)
        {
            if (!(bom[0] == (byte) 0xEF && bom[1] == (byte) 0xBB && bom[2] == (byte) 0xBF))
            {
                pushbackInputStream.unread(bom);
            }
        }
        return pushbackInputStream;
    }
}
