package com.duxstar.dacza.vistas.utilerias;

import android.net.Uri;

import com.duxstar.dacza.datos.utilerias.ArchivoConfiguracion.CampoConfiguracion;
import com.duxstar.dacza.datos.utilerias.ConfiguracionLocal;
import com.duxstar.dacza.datos.utilerias.Sesion;
import com.duxstar.dacza.datos.utilerias.Sesion.Campo;

import org.w3c.dom.Document;
import org.w3c.dom.Node;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.io.OutputStream;
import java.net.HttpURLConnection;
import java.net.URL;
import java.net.URLConnection;
import java.text.SimpleDateFormat;
import java.util.Date;

public class ServicesCentral
{
    public static String WSAplicacionObtenerBDSqLite() throws Exception
    {
        String nombreArchivo = "";

        HttpURLConnection hc;
        ConfiguracionLocal config = (ConfiguracionLocal) Sesion.get(Sesion.Campo.ConfiguracionLocal);

        String message = "<soap:Envelope xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\" " +
                "xmlns:tem=\"http://tempuri.org/services/MobileClient\">" +
                "<soap:Body>" +
                "<WSAplicacionObtenerBDSqLite xmlns=\"http://tempuri.org/services/MobileClient\">" +
                "<parsTallerClave>" + config.get(CampoConfiguracion.ALMACEN) + "</parsTallerClave><parsUsuarioClave>" + config.get(CampoConfiguracion.AGENTE) + "</parsUsuarioClave>" +
                "<parsTerminalNumeroSerie>" + config.get(CampoConfiguracion.NUMERO_SERIE) + "</parsTerminalNumeroSerie><refparsMensaje></refparsMensaje>" +
                "</WSAplicacionObtenerBDSqLite>" +
                "</soap:Body>" +
                "</soap:Envelope>";

        String url = Uri.withAppendedPath(Uri.parse(config.get(CampoConfiguracion.URL).toString()), "ServiceMobileClient.asmx").toString();

        hc = (HttpURLConnection) new URL(url).openConnection();
        /** Some web servers requires these properties */
        hc.setRequestMethod("POST");

        hc.setRequestProperty("SOAPAction", "http://tempuri.org/services/MobileClient/WSAplicacionObtenerBDSqLite");
        hc.setRequestProperty("User-Agent", "Profile/MIDP-1.0 Configuration/CLDC-1.0");
        hc.setRequestProperty("Content-Type", "text/xml;charset=utf-8");
        hc.setRequestProperty("Content-Length", Integer.toString(message.length()));
        hc.setRequestProperty("Connection", "close");
        hc.setConnectTimeout((Integer) config.get(CampoConfiguracion.TIMEOUT));
        hc.setAllowUserInteraction(true);
        hc.setDoOutput(true);
        hc.setDoInput(true);
        hc.setChunkedStreamingMode(0);
        OutputStream os = hc.getOutputStream();
        os.write(message.getBytes());
        os.close();

        String outputString = "";
        InputStreamReader isr = null;
        BufferedReader in = null;
        String responseString = null;

        if (hc.getResponseCode() == 200)
        {
            isr = new InputStreamReader(hc.getInputStream());
            in = new BufferedReader(isr);
            while ((responseString = in.readLine()) != null)
            {
                outputString = outputString + responseString;
            }
            isr.close();
            Document doc = DocumentoXML.XMLfromString(outputString);
            Node nodo = doc.getElementsByTagName("WSAplicacionObtenerBDSqLiteResponse").item(0);
            if (nodo.getChildNodes().item(0).getChildNodes().item(0) == null)
            {
                if (nodo.getChildNodes().item(1).getChildNodes().item(0) != null)
                {
                    String msgError = nodo.getChildNodes().item(1).getChildNodes().item(0).getNodeValue();
                    throw new Exception(msgError);
                }
                else
                {
                    throw new Exception("Estructura de respuesta incorrecta");
                }
            }
            else
            {
                nombreArchivo = nodo.getChildNodes().item(0).getChildNodes().item(0).getNodeValue();
            }
        }
        else
        {
            InputStream es = hc.getErrorStream();
            throw new Exception(ObtenerErrorSOAP(es));
        }

        hc.disconnect();
        return nombreArchivo;
    }

    public static InputStream DescargarBD(String nombreArchivo, int[] tamanioArchivo) throws Exception
    {

        ConfiguracionLocal config = (ConfiguracionLocal) Sesion.get(Campo.ConfiguracionLocal);
        String sUrl = Uri.withAppendedPath(Uri.parse(config.get(CampoConfiguracion.URL).toString()), "bases").toString();
        sUrl = Uri.withAppendedPath(Uri.parse(sUrl), nombreArchivo + ".zip").toString();
        URL url = new URL(sUrl);
        URLConnection conexion = url.openConnection();
        conexion.connect();
        tamanioArchivo[0] = conexion.getContentLength();
        InputStream is = url.openStream();
        return is;

    }

    public static boolean ProbarAccesoServicio()
    {
        try
        {

            ConfiguracionLocal config = (ConfiguracionLocal) Sesion.get(Campo.ConfiguracionLocal);
            URL url = new URL(Uri.withAppendedPath(Uri.parse(config.get(CampoConfiguracion.URL).toString()), "ServiceMobileClient.asmx").toString());
            HttpURLConnection urlc = (HttpURLConnection) url.openConnection();
            urlc.setRequestProperty("User-Agent", "Profile/MIDP-1.0 Configuration/CLDC-1.0");
            urlc.setRequestProperty("Connection", "close");
            urlc.setConnectTimeout(1000 * 30); // mTimeout is in seconds
            urlc.connect();
            if (urlc.getResponseCode() == 200)
            {
                return true;
            }
        }
        catch (Exception ex)
        {
            return false;
        }
        return false;
    }

    public static boolean ProbarAccesoServicio(String pServicio)
    {
        try
        {
            //ConfiguracionLocal config = (ConfiguracionLocal) Sesion.get(Campo.ConfiguracionLocal);
            URL url = new URL(Uri.withAppendedPath(Uri.parse(pServicio), "ServiceMobileClient.asmx").toString());
            HttpURLConnection urlc = (HttpURLConnection) url.openConnection();
            urlc.setRequestProperty("User-Agent", "Profile/MIDP-1.0 Configuration/CLDC-1.0");
            urlc.setRequestProperty("Connection", "close");
            urlc.setConnectTimeout(1000 * 30);
            urlc.connect();
            if (urlc.getResponseCode() == 200)
            {
                return true;
            }
        }
        catch (Exception ex)
        {
            return false;
        }
        return false;
    }

    public static void WSObtenerUsuarioContrasena(Object[] params) throws Exception
    {
        HttpURLConnection hc;
        String taller = params[0].toString();
        String usuario = params[1].toString();
        String contrasena = params[2].toString();
        String terminal = params[3].toString();
        String mensaje = params[4].toString();

        String servicio = params[5].toString();
        int timeOut = (Integer) params[6];

        String message = "<soap:Envelope xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\" " +
                "xmlns:tem=\"http://tempuri.org/services/MobileClient\">" +
                "<soap:Body>" +
                "<WSObtenerUsuarioContrasena xmlns=\"http://tempuri.org/services/MobileClient\">" +
                "<pvTaller>" + taller + "</pvTaller><pvUsuario>" + usuario + "</pvUsuario><pvContrasena>" + contrasena + "</pvContrasena><pvNoSerieTerminal>" + terminal + "</pvNoSerieTerminal><prMensaje>" + mensaje + "</prMensaje>" +
                "</WSObtenerUsuarioContrasena>" +
                "</soap:Body>" +
                "</soap:Envelope>";

        //WSObtenerUsuarioContrasena(ByVal pvTaller As String, ByVal pvUsuario As String, ByVal pvContrasena As String, ByVal pvNoSerieTerminal As String, ByRef prMensaje As String) As Boolean

        String url = Uri.withAppendedPath(Uri.parse(servicio), "ServiceMobileClient.asmx").toString();

        hc = (HttpURLConnection) new URL(url).openConnection();
        /** Some web servers requires these properties */
        hc.setRequestMethod("POST");
        hc.setRequestProperty("SOAPAction", "http://tempuri.org/services/MobileClient/WSObtenerUsuarioContrasena");
        hc.setRequestProperty("User-Agent", "Profile/MIDP-1.0 Configuration/CLDC-1.0");
        hc.setRequestProperty("Content-Type", "text/xml;charset=utf-8");
        hc.setRequestProperty("Content-Length", Integer.toString(message.length()));
        hc.setRequestProperty("Connection", "close");
        hc.setConnectTimeout(timeOut);
        hc.setAllowUserInteraction(true);
        hc.setDoOutput(true);
        hc.setDoInput(true);
        hc.setChunkedStreamingMode(0);
        OutputStream os = hc.getOutputStream();
        os.write(message.getBytes());
        os.close();

        String outputString = "";
        InputStreamReader isr = null;
        BufferedReader in = null;
        String responseString = null;

        isr = new InputStreamReader(hc.getInputStream());
        in = new BufferedReader(isr);

        while ((responseString = in.readLine()) != null)
        {
            outputString = outputString + responseString;
        }
        isr.close();

        Document doc = DocumentoXML.XMLfromString(outputString);
        if (doc.getElementsByTagName("prMensaje").item(0) != null)
        {
            params[4] = doc.getElementsByTagName("prMensaje").item(0).getChildNodes().item(0).getNodeValue();
        }

        hc.disconnect();
    }

    public static boolean WSEliminarArchivoBases(String nombreArchivo)
    {

        HttpURLConnection hc;

        String message = "<soap:Envelope xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\" " +
                "xmlns:tem=\"http://tempuri.org/services/MobileClient\">" +
                "<soap:Body>" +
                "<WSEliminarArchivoBases xmlns=\"http://tempuri.org/services/MobileClient\">" +
                "<parsNombreArchivo>" + nombreArchivo + "</parsNombreArchivo>" +
                "</WSEliminarArchivoBases>" +
                "</soap:Body>" +
                "</soap:Envelope>";

        ConfiguracionLocal config = (ConfiguracionLocal) Sesion.get(Campo.ConfiguracionLocal);
        String url = Uri.withAppendedPath(Uri.parse(config.get(CampoConfiguracion.URL).toString()), "ServiceMobileClient.asmx").toString();

        try{
            hc = (HttpURLConnection) new URL(url).openConnection();
            /** Some web servers requires these properties */
            hc.setRequestMethod("POST");
            hc.setRequestProperty("SOAPAction", "http://tempuri.org/services/MobileClient/WSEliminarArchivoBases");
            hc.setRequestProperty("User-Agent", "Profile/MIDP-1.0 Configuration/CLDC-1.0");
            hc.setRequestProperty("Content-Type", "text/xml;charset=utf-8");
            hc.setRequestProperty("Content-Length", Integer.toString(message.length()));
            hc.setRequestProperty("Connection", "close");
            hc.setAllowUserInteraction(true);
            hc.setDoOutput(true);
            hc.setDoInput(true);
            hc.setChunkedStreamingMode(0);
            OutputStream os = hc.getOutputStream();
            os.write(message.getBytes());
            os.close();

            String outputString = "";
            InputStreamReader isr = null;
            BufferedReader in = null;
            String responseString = null;

            if (hc.getResponseCode() == 200)
            {
                hc.disconnect();
                return true;
            }
            else
            {
                hc.disconnect();
                return false;
            }
        }catch (Exception ex){
            return false;
        }
    }

    private static String ObtenerErrorSOAP(InputStream is) throws Exception
    {
        String error = "";

        int ret = 0;
        StringBuffer bufferRead = new StringBuffer();
        //read the response body
        while ((ret = is.read()) > 0)
        {
            bufferRead.append((char) ret);
        }
        Document doc = DocumentoXML.XMLfromString(bufferRead.toString());
        Node nodo = doc.getElementsByTagName("faultstring").item(0);
        if (nodo.getChildNodes().item(0) != null)
        {
            for (int i = 0; i < nodo.getChildNodes().getLength(); i++)
            {
                error += nodo.getChildNodes().item(i).getNodeValue();
            }
            //error  = nodo.getChildNodes().item(0).getNodeValue();
        }
        else
        {
            error = bufferRead.toString();
        }

        return error;
    }

    public static boolean WSActualizarCapturaSQLite(Boolean reintentar, String archInfoEnvio) throws Exception
    {
        boolean res = false;

        File archZIP = new File(archInfoEnvio);

        String pathToOurFile = archZIP.getAbsolutePath();

        FileInputStream fileInputStream = new FileInputStream(new File(pathToOurFile));

        // fileInputStream.read(fileContent);
        if (archZIP.length() > Integer.MAX_VALUE)
        {
            throw new Exception("Archivo demasiado grande");
        }

        byte fileContent[] = new byte[(int) archZIP.length()];
        // Create the byte array to hold the data

        // Read in the bytes
        int offset = 0;
        int numRead = 0;
        while (offset < fileContent.length
                && (numRead = fileInputStream.read(fileContent, offset, fileContent.length - offset)) >= 0)
        {
            offset += numRead;
        }

        // Ensure all the bytes have been read in
        if (offset < fileContent.length)
        {
            throw new IOException("No se pudo completar la lectura del archivo ");
        }

        fileInputStream.close();
        fileInputStream = null;
        //int maxBufferSize = 1024*100;
        //int leer = 0;

        SimpleDateFormat formato = new SimpleDateFormat("yyyy-MM-dd'T'HH:mm:ss'Z'");

        String parametroByte = android.util.Base64.encodeToString(fileContent, 0);

        String message = "<soap:Envelope xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\" " +
                "xmlns:tem=\"http://tempuri.org/services/MobileClient\">" +
                "<soap:Body>" +
                "<WSActualizarCapturaSQLite xmlns=\"http://tempuri.org/services/MobileClient\">" +
                "<bytes>" + parametroByte + "</bytes>" +
                "<parsNombreZip>" + archZIP.getName() + "</parsNombreZip>" +
                "<refparsMensaje></refparsMensaje>" +
                "<refparbReintentar>" + reintentar.toString() + "</refparbReintentar>" +
                "</WSActualizarCapturaSQLite>" +
                "</soap:Body>" +
                "</soap:Envelope>";

        fileContent = null;

        ConfiguracionLocal config = (ConfiguracionLocal) Sesion.get(Campo.ConfiguracionLocal);
        String url = Uri.withAppendedPath(Uri.parse(config.get(CampoConfiguracion.URL).toString()), "ServiceMobileClient.asmx").toString();

        HttpURLConnection hc = (HttpURLConnection) new URL(url).openConnection();

        hc.setRequestMethod("POST");

        hc.setRequestProperty("SOAPAction", "http://tempuri.org/services/MobileClient/WSActualizarCapturaSQLite");
        hc.setRequestProperty("User-Agent", "Profile/MIDP-1.0 Configuration/CLDC-1.0");
        hc.setRequestProperty("Content-Type", "text/xml;charset=utf-8");
        hc.setRequestProperty("Content-Length", Integer.toString(message.length()));
        hc.setRequestProperty("Connection", "close");
        hc.setAllowUserInteraction(true);
        hc.setDoOutput(true);
        hc.setDoInput(true);
        hc.setChunkedStreamingMode(0);
        OutputStream os = hc.getOutputStream();

        os.write(message.toString().getBytes());
        os.close();
        message = null;

        try
        {
            String outputString = "";
            InputStreamReader isr = null;
            BufferedReader in = null;
            String responseString = null;

            isr = new InputStreamReader(hc.getInputStream());
            in = new BufferedReader(isr);
            while ((responseString = in.readLine()) != null)
            {
                outputString = outputString + responseString;
            }
            isr.close();

            Document doc = DocumentoXML.XMLfromString(outputString);
            Node nodo = doc.getElementsByTagName("WSActualizarCapturaSQLiteResult").item(0);
            if (nodo.getChildNodes().item(0) != null)
            {
                res = Boolean.parseBoolean(nodo.getChildNodes().item(0).getNodeValue());
                if (!res)
                {
                    nodo = doc.getElementsByTagName("refparsMensaje").item(0);
                    if (nodo.getChildNodes().item(0) != null)
                    {
                        throw new Exception(nodo.getChildNodes().item(0).getNodeValue());
                    }
                }
            }
        }
        catch (Exception ex)
        {
            int i = hc.getResponseCode();
            if (i != 200)
            {
                InputStream isr = hc.getErrorStream();
                byte[] bytes = new byte[100];
                String tmp = "";
                while (isr.read(bytes) > 0)
                {
                    tmp += new String(bytes);
                }
                throw new Exception(tmp);
            }
            throw ex;
        }
        return res;
    }

    public static String WSTallerObtenerTraspasos(String tallerId, String fechaInicio) throws Exception
    {
        String nombreArchivo = "";

        HttpURLConnection hc;
        //Text text = new Text();

        String message = "<soap:Envelope xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\" " +
                "xmlns:tem=\"http://tempuri.org/services/MobileClient\">" +
                "<soap:Body>" +
                "<WSTallerObtenerTraspasos xmlns=\"http://tempuri.org/services/MobileClient\">" +
                "<parsTallerId>" + tallerId + "</parsTallerId>" +
                "<parsFechaInicio>" + fechaInicio + "</parsFechaInicio>" +
                "</WSTallerObtenerTraspasos>" +
                "</soap:Body>" +
                "</soap:Envelope>";

        ConfiguracionLocal config = (ConfiguracionLocal) Sesion.get(Campo.ConfiguracionLocal);
        String url = Uri.withAppendedPath(Uri.parse(config.get(CampoConfiguracion.URL).toString()), "ServiceMobileClient.asmx").toString();

        hc = (HttpURLConnection) new URL(url).openConnection();
        /** Some web servers requires these properties */
        hc.setRequestMethod("POST");

        hc.setRequestProperty("SOAPAction", "http://tempuri.org/services/MobileClient/WSTallerObtenerTraspasos");
        hc.setRequestProperty("User-Agent", "Profile/MIDP-1.0 Configuration/CLDC-1.0");
        hc.setRequestProperty("Content-Type", "text/xml;charset=utf-8");
        hc.setRequestProperty("Content-Length", Integer.toString(message.length()));
        hc.setRequestProperty("Connection", "close");
        hc.setAllowUserInteraction(true);
        hc.setDoOutput(true);
        hc.setDoInput(true);
        hc.setChunkedStreamingMode(0);

        OutputStream os = hc.getOutputStream();
        os.write(message.getBytes());
        os.close();

        String outputString = "";
        InputStreamReader isr = null;
        BufferedReader in = null;
        String responseString = null;

        if (hc.getResponseCode() == 200)
        {
            isr = new InputStreamReader(hc.getInputStream());
            in = new BufferedReader(isr);
            while ((responseString = in.readLine()) != null)
            {
                outputString = outputString + responseString;
            }
            isr.close();
            Document doc = DocumentoXML.XMLfromString(outputString);
            Node nodo = doc.getElementsByTagName("WSTallerObtenerTraspasosResponse").item(0);
            if (nodo.getChildNodes().item(0).getChildNodes().item(0) == null)
            {
                nombreArchivo = "";
            }
            else
            {
                nombreArchivo = nodo.getChildNodes().item(0).getChildNodes().item(0).getNodeValue();
            }
        }
        else
        {
            InputStream es = hc.getErrorStream();
            throw new Exception(ObtenerErrorSOAP(es));
        }

        hc.disconnect();
        return nombreArchivo;
    }

    public static boolean WSTallerMarcarTraspasosEnviados(String tallerId, String fechaInicio, String usuarioId)
    {

        HttpURLConnection hc;

        String message = "<soap:Envelope xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\" " +
                "xmlns:tem=\"http://tempuri.org/services/MobileClient\">" +
                "<soap:Body>" +
                "<WSTallerMarcarTraspasosEnviados xmlns=\"http://tempuri.org/services/MobileClient\">" +
                "<parsTallerId>" + tallerId + "</parsTallerId>" +
                "<parsFechaInicio>" + fechaInicio + "</parsFechaInicio>" +
                "<parsUsuarioId>" + usuarioId + "</parsUsuarioId>" +
                "</WSTallerMarcarTraspasosEnviados>" +
                "</soap:Body>" +
                "</soap:Envelope>";

        ConfiguracionLocal config = (ConfiguracionLocal) Sesion.get(Campo.ConfiguracionLocal);
        String url = Uri.withAppendedPath(Uri.parse(config.get(CampoConfiguracion.URL).toString()), "ServiceMobileClient.asmx").toString();

        try{
            hc = (HttpURLConnection) new URL(url).openConnection();
            /** Some web servers requires these properties */
            hc.setRequestMethod("POST");
            hc.setRequestProperty("SOAPAction", "http://tempuri.org/services/MobileClient/WSTallerMarcarTraspasosEnviados");
            hc.setRequestProperty("User-Agent", "Profile/MIDP-1.0 Configuration/CLDC-1.0");
            hc.setRequestProperty("Content-Type", "text/xml;charset=utf-8");
            hc.setRequestProperty("Content-Length", Integer.toString(message.length()));
            hc.setRequestProperty("Connection", "close");
            hc.setAllowUserInteraction(true);
            hc.setDoOutput(true);
            hc.setDoInput(true);
            hc.setChunkedStreamingMode(0);
            OutputStream os = hc.getOutputStream();
            os.write(message.getBytes());
            os.close();

            String outputString = "";
            InputStreamReader isr = null;
            BufferedReader in = null;
            String responseString = null;

            if (hc.getResponseCode() == 200)
            {
                hc.disconnect();
                return true;
            }
            else
            {
                hc.disconnect();
                return false;
            }
        }catch (Exception ex){
            return false;
        }
    }

    @SuppressWarnings("resource")
    public static boolean WSEnviarImagenesRecargas(String pathImagenes) throws Exception
    {
        try {
            //Log.v("Path de imagenes", pathImagenes);
            boolean res = false;
            File archZIP = new File(pathImagenes);
            //Log.v("Path Absoluta",archZIP.getAbsolutePath());

            String pathToOurFile = archZIP.getAbsolutePath();

            FileInputStream fileInputStream = new FileInputStream(new File(pathToOurFile));

            // fileInputStream.read(fileContent);
            //Log.v("Maximo del archivo:", "Maximo: "+Integer.MAX_VALUE+" Maximo del path: "+archZIP.length());

            if (archZIP.length() > Integer.MAX_VALUE) {
                throw new Exception("Archivo demasiado grande");
            }

            byte fileContent[] = new byte[(int) archZIP.length()];
            // Create the byte array to hold the data

            // Read in the bytes
            int offset = 0;
            int numRead = 0;
            while (offset < fileContent.length && (numRead = fileInputStream.read(fileContent, offset, fileContent.length - offset)) >= 0) {
                offset += numRead;
            }

            // Ensure all the bytes have been read in
            if (offset < fileContent.length) {
                throw new IOException("No se pudo completar la lectura del archivo ");
            }

            fileInputStream.close();
            fileInputStream = null;
            //int maxBufferSize = 1024*100;
            //int leer = 0;
            String parametroByte = "";
            try {
                parametroByte = android.util.Base64.encodeToString(fileContent, 0);
            } catch (Exception e) {
                throw new IOException("No se pudo completar la lectura del archivo ");
            }

            String message = "<soap:Envelope xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\" " +
                    "xmlns:tem=\"http://tempuri.org/services/MobileClient\">" +
                    "<soap:Body>" +
                    "<WSObtenerArchivoZipAndroid xmlns=\"http://tempuri.org/services/MobileClient\">" +
                    "<parByteArchivo>" + parametroByte + "</parByteArchivo>" +
                    "</WSObtenerArchivoZipAndroid>" +
                    "</soap:Body>" +
                    "</soap:Envelope>";

            //Log.v("Mensaje", message);

            fileContent = null;

            ConfiguracionLocal config = (ConfiguracionLocal) Sesion.get(Campo.ConfiguracionLocal);
            String url = Uri.withAppendedPath(Uri.parse(config.get(CampoConfiguracion.URL).toString()), "ServiceMobileClient.asmx").toString();

            HttpURLConnection hc = (HttpURLConnection) new URL(url).openConnection();

            hc.setRequestMethod("POST");

            hc.setRequestProperty("SOAPAction", "http://tempuri.org/services/MobileClient/WSObtenerArchivoZipAndroid");
            hc.setRequestProperty("User-Agent", "Profile/MIDP-1.0 Configuration/CLDC-1.0");
            hc.setRequestProperty("Content-Type", "text/xml;charset=utf-8");
            hc.setRequestProperty("Content-Length", Integer.toString(message.length()));
            hc.setRequestProperty("Connection", "close");
            hc.setAllowUserInteraction(true);
            hc.setDoOutput(true);
            hc.setDoInput(true);
            hc.setChunkedStreamingMode(0);
            OutputStream os = hc.getOutputStream();

            os.write(message.toString().getBytes());
            os.close();
            message = null;

            try {
                String outputString = "";
                InputStreamReader isr = null;
                BufferedReader in = null;
                String responseString = null;

                isr = new InputStreamReader(hc.getInputStream());
                in = new BufferedReader(isr);
                while ((responseString = in.readLine()) != null) {
                    outputString = outputString + responseString;
                }
                isr.close();

                Document doc = DocumentoXML.XMLfromString(outputString);
                //Log.v("Resultado", outputString);
                Node nodo = doc.getElementsByTagName("WSObtenerArchivoZipAndroidResult").item(0);

                if (nodo.getChildNodes().item(0) != null) {
                    //Log.v("Nodo", nodo.getChildNodes().item(0).getNodeValue());
                    res = Boolean.parseBoolean(nodo.getChildNodes().item(0).getNodeValue());
                    if (!res) {
                        //nodo = doc.getElementsByTagName("refparsMensaje").item(0);
                        //if (nodo.getChildNodes().item(0) != null)
                        //{

                        //throw new Exception(nodo.getChildNodes().item(0).getNodeValue());
                        //	}
                        //Log.v("False", "Falso");
                    }
                }
            } catch (Exception ex) {
                int i = hc.getResponseCode();
                if (i != 200) {
                    InputStream isr = hc.getErrorStream();
                    byte[] bytes = new byte[100];
                    String tmp = "";
                    while (isr.read(bytes) > 0) {
                        tmp += new String(bytes);
                    }
                    throw new Exception(tmp);
                }
                //Log.v("Error de mensaje ", ex.getMessage());
                throw ex;
            }
            return res;
        }catch (Exception ex){
            throw ex;
        }
    }
}
