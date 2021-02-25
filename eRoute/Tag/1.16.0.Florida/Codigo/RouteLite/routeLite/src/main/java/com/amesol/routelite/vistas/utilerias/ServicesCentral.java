package com.amesol.routelite.vistas.utilerias;

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

import org.w3c.dom.Document;
import org.w3c.dom.Node;

import android.net.Uri;

import com.amesol.routelite.datos.Cliente;
import com.amesol.routelite.datos.Usuario;
import com.amesol.routelite.datos.Vendedor;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.utilerias.ArchivoConfiguracion.CampoConfiguracion;
import com.amesol.routelite.datos.utilerias.ConfiguracionLocal;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.utilerias.DeviceControl;
import com.amesol.routelite.utilerias.Generales;
import com.amesol.routelite.vistas.ConfiguracionTerminal;

public class ServicesCentral
{

	public enum TipoLicencia
	{
		ErrorRegistro("ErrorRegistro"),
		Nuevo("Nuevo"),
		Pendiente("Pendiente"),
		Trial("Trial"),
		Definitivo("Definitivo"),
		TrialTerminado("TrialTerminado");

		@SuppressWarnings("unused")
		private String value;

		TipoLicencia(String v)
		{
			this.value = v;
		}
	}

	public enum TiposEsquemas
	{
		NoDefinido(0),
		Clientes(1),
		Productos(2),
		Impuestos(3);
		public int value;

		TiposEsquemas(int v)
		{
			this.value = v;
		}
	}

	public enum TiposValoresAplicacionImpuestos
	{
		NoDefinido(0),
		Porcentaje(1),
		Importe(2);

		public int value;

		TiposValoresAplicacionImpuestos(int v)
		{
			this.value = v;
		}
	}

	public enum TiposDescuento
	{
		NoDefinido(0),
		Inmediato(1),
		Programado(2);

		public int value;

		TiposDescuento(int v)
		{
			this.value = v;
		}
	}

	public enum TiposValoresDescuentos
	{
		NoDefinido(0),
		Importe(1),
		Porcentaje(2);

		public int value;

		TiposValoresDescuentos(int v)
		{
			this.value = v;
		}
	}

	public enum TiposAplicacionImpuestos
	{
		NoDefinido(0),
		SubtotalSinImpuestos(1),
		SubtotalConImpuestos(2);

		public int value;

		TiposAplicacionImpuestos(int v)
		{
			this.value = v;
		}
	}

	public enum TiposSincronizacion
	{
		NoDefinido(0),
		Terminal(1),
		Vendedor(2);

		public int value;

		TiposSincronizacion(int v)
		{
			this.value = v;
		}
	}
	public enum TiposActualizacion
	{
		NoDefinido(0),
		ConfirmacionPedidosCos(1);

		public int value;

		TiposActualizacion(int v)
		{
			this.value = v;
		}
	}

	public static String WSAplicacionObtenerBDSqLite() throws Exception
	{
		String nombreArchivo = "";

		HttpURLConnection hc;
		ConfiguracionLocal config = (ConfiguracionLocal) Sesion.get(Campo.ConfiguracionLocal);

		String message = "<soap:Envelope xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\" " +
				"xmlns:tem=\"http://tempuri.org/services/MobileClient\">" +
				"<soap:Body>" +
				"<WSAplicacionObtenerBDSqLite xmlns=\"http://tempuri.org/services/MobileClient\">" +
				"<parsTerminalNumeroSerie>" + config.get(CampoConfiguracion.NUMERO_SERIE) + "</parsTerminalNumeroSerie><parsUsuarioClave>" + config.get(CampoConfiguracion.USUARIO) + "</parsUsuarioClave><refparsMensaje></refparsMensaje>" +
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

	/*
	 * public static boolean SubirBD(Configuracion config, String nombreArchivo)
	 * throws Exception{ URL url; URLConnection urlConn; DataOutputStream dos;
	 * DataInputStream dis;
	 * 
	 * String sUrl =
	 * Uri.withAppendedPath(Uri.parse(config.getValor(CampoConfiguracion
	 * .URL).toString()) , "Upload.aspx").toString() ;
	 * 
	 * url = new URL(sUrl); urlConn = url.openConnection();
	 * urlConn.setDoInput(true); urlConn.setDoOutput(true);
	 * urlConn.setUseCaches(false); urlConn.setRequestProperty ("Content-Type",
	 * "application/x-www-form-urlencoded");
	 * 
	 * dos = new DataOutputStream (urlConn.getOutputStream()); String message =
	 * "NEW_ITEM=" + URLEncoder.encode("Prueba"); dos.writeBytes(message);
	 * dos.flush(); dos.close();
	 * 
	 * // the server responds by saying // "SUCCESS" or "FAILURE"
	 * 
	 * dis = new DataInputStream(urlConn.getInputStream()); String s =
	 * dis.readLine(); dis.close();
	 * 
	 * if (s.equals("SUCCESS")) { return true; } else { return false; }
	 * 
	 * }
	 * 
	 * public static boolean SubirBD2(Configuracion config) throws Exception{
	 * HttpURLConnection connection = null; DataOutputStream outputStream =
	 * null; DataInputStream inputStream = null;
	 * 
	 * String pathToOurFile = Environment.getExternalStorageDirectory() +
	 * "/envio.xml"; String urlServer =
	 * Uri.withAppendedPath(Uri.parse(config.getValor
	 * (CampoConfiguracion.URL).toString()) , "bases").toString() ;
	 * 
	 * String lineEnd = "\r\n"; String twoHyphens = "--"; String boundary =
	 * "*****";
	 * 
	 * int bytesRead, bytesAvailable, bufferSize; byte[] buffer; int
	 * maxBufferSize = 1*1024*1024;
	 * 
	 * FileInputStream fileInputStream = new FileInputStream(new
	 * File(pathToOurFile));
	 * 
	 * URL url = new URL(urlServer); connection = (HttpURLConnection)
	 * url.openConnection();
	 * 
	 * // Allow Inputs & Outputs connection.setDoInput(true);
	 * connection.setDoOutput(true); connection.setUseCaches(false);
	 * 
	 * // Enable POST method connection.setRequestMethod("POST");
	 * 
	 * connection.setRequestProperty("Connection", "Keep-Alive");
	 * connection.setRequestProperty("Content-Type",
	 * "multipart/form-data;boundary="+boundary);
	 * 
	 * outputStream = new DataOutputStream( connection.getOutputStream() );
	 * outputStream.writeBytes(twoHyphens + boundary + lineEnd);
	 * outputStream.writeBytes
	 * ("Content-Disposition: form-data; name=\"uploadedfile\";filename=\"" +
	 * pathToOurFile +"\"" + lineEnd); outputStream.writeBytes(lineEnd);
	 * 
	 * bytesAvailable = fileInputStream.available(); bufferSize =
	 * Math.min(bytesAvailable, maxBufferSize); buffer = new byte[bufferSize];
	 * 
	 * // Read file bytesRead = fileInputStream.read(buffer, 0, bufferSize);
	 * 
	 * while (bytesRead > 0) { outputStream.write(buffer, 0, bufferSize);
	 * bytesAvailable = fileInputStream.available(); bufferSize =
	 * Math.min(bytesAvailable, maxBufferSize); bytesRead =
	 * fileInputStream.read(buffer, 0, bufferSize); }
	 * 
	 * outputStream.writeBytes(lineEnd); outputStream.writeBytes(twoHyphens +
	 * boundary + twoHyphens + lineEnd);
	 * 
	 * // Responses from the server (code and message) int serverResponseCode =
	 * connection.getResponseCode(); String serverResponseMessage =
	 * connection.getResponseMessage();
	 * 
	 * fileInputStream.close(); outputStream.flush(); outputStream.close();
	 * 
	 * 
	 * return true; }
	 */

	/*
	 * public void sendSOAPMessage(String SOAPmessage, String serviceLocation,
	 * String remoteMethod, String nameSpace, String characterEncoding) {
	 * //Create new URL object and HttpURLConnection object //String urlServer =
	 * Uri
	 * .withAppendedPath(Uri.parse(config.getValor(CampoConfiguracion.URL).toString
	 * ()) , "bases").toString() ;
	 * 
	 * URL url = new URL(serviceLocation); HttpURLConnection httpConnection =
	 * (HttpURLConnection) url.openConnection();
	 * 
	 * //Convert the message to a byte array byte[] messageBytes =
	 * SOAPmessage.getBytes();
	 * 
	 * //Set headers httpConnection.setRequestProperty("Content-Length",
	 * String.valueOf(messageBytes.length));
	 * httpConnection.setRequestProperty("Content-Type","text/xml; charset=" +
	 * characterEncoding + "\"");
	 * httpConnection.setRequestProperty("SOAPAction", nameSpace +
	 * remoteMethod); httpConnection.setRequestMethod("POST");
	 * httpConnection.setDoInput(true); httpConnection.setDoOutput(true);
	 * 
	 * //Write and send the SOAP message OutputStream out =
	 * httpConnection.getOutputStream(); out.write(messageBytes); out.close();
	 * 
	 * //Read server response BufferedReader in = new BufferedReader(new
	 * InputStreamReader(httpConnection.getInputStream()));
	 * 
	 * String inputLine; while((inputLine = in.readLine()) != null) {
	 * System.out.println(inputLine); } }
	 */

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

	@SuppressWarnings("static-access")
	public static TipoLicencia WSTipo_Licencia() throws Exception
	{
		TipoLicencia tipoLicencia = TipoLicencia.ErrorRegistro;

		ConfiguracionLocal config = (ConfiguracionLocal) Sesion.get(Campo.ConfiguracionLocal);

		HttpURLConnection hc;

		String message = "<soap:Envelope xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\" " +
				"xmlns:tem=\"http://tempuri.org/services/MobileClient\">" +
				"<soap:Body>" +
				"<WSTipo_Licencia xmlns=\"http://tempuri.org/services/MobileClient\">" +
				"<pvDeviceID>" + config.get(CampoConfiguracion.NUMERO_SERIE) + "</pvDeviceID><pvDeviceName>" + Dispositivo.obtenerNombre() + "</pvDeviceName><pvSO>Android</pvSO>" +
				"</WSTipo_Licencia>" +
				"</soap:Body>" +
				"</soap:Envelope>";

		String url = Uri.withAppendedPath(Uri.parse(config.get(CampoConfiguracion.URL).toString()), "ServiceMobileClient.asmx").toString();

		hc = (HttpURLConnection) new URL(url).openConnection();
		/** Some web servers requires these properties */
		hc.setRequestMethod("POST");
		hc.setRequestProperty("SOAPAction", "http://tempuri.org/services/MobileClient/WSTipo_Licencia");
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

		isr = new InputStreamReader(hc.getInputStream());
		in = new BufferedReader(isr);
		while ((responseString = in.readLine()) != null)
		{
			outputString = outputString + responseString;
		}
		isr.close();

		Document doc = DocumentoXML.XMLfromString(outputString);
		Node nodo = doc.getElementsByTagName("WSTipo_LicenciaResult").item(0);
		if (nodo.getChildNodes().item(0) != null)
		{
			tipoLicencia = tipoLicencia.valueOf(nodo.getChildNodes().item(0).getNodeValue());
		}

		hc.disconnect();
		return tipoLicencia;
	}

	@SuppressWarnings("static-access")
	public static boolean WSLicenciamientoVigente() throws Exception
	{
		boolean licenciaVigente = false;
		ConfiguracionLocal config = (ConfiguracionLocal) Sesion.get(Campo.ConfiguracionLocal);

		HttpURLConnection hc;

		String message = "<soap:Envelope xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\" " +
				"xmlns:tem=\"http://tempuri.org/services/MobileClient\">" +
				"<soap:Body>" +
				"<WSLicenciamientoVigente xmlns=\"http://tempuri.org/services/MobileClient\">" +
				"</WSLicenciamientoVigente>" +
				"</soap:Body>" +
				"</soap:Envelope>";

		String url = Uri.withAppendedPath(Uri.parse(config.get(CampoConfiguracion.URL).toString()), "ServiceMobileClient.asmx").toString();

		hc = (HttpURLConnection) new URL(url).openConnection();
		/** Some web servers requires these properties */
		hc.setRequestMethod("POST");
		hc.setRequestProperty("SOAPAction", "http://tempuri.org/services/MobileClient/WSLicenciamientoVigente");
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
			//TODO: Arrendamiento
			Node nodo = doc.getElementsByTagName("WSLicenciamientoVigenteResult").item(0);
			if (nodo.getChildNodes().item(0) != null)
			{
				licenciaVigente = Boolean.parseBoolean(nodo.getChildNodes().item(0).getNodeValue());
			}
		}catch(Exception ex){
			licenciaVigente = false;
		}
		hc.disconnect();
		return licenciaVigente;

	}

	@SuppressWarnings("static-access")
	public static void WSActualizarFechaVencimiento() throws Exception
	{
		ConfiguracionLocal config = (ConfiguracionLocal) Sesion.get(Campo.ConfiguracionLocal);

		HttpURLConnection hc;

		String message = "<soap:Envelope xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\" " +
				"xmlns:tem=\"http://tempuri.org/services/MobileClient\">" +
				"<soap:Body>" +
				"<WSActualizarFechaVencimiento xmlns=\"http://tempuri.org/services/MobileClient\">" +
				"</WSActualizarFechaVencimiento>" +
				"</soap:Body>" +
				"</soap:Envelope>";

		String url = Uri.withAppendedPath(Uri.parse(config.get(CampoConfiguracion.URL).toString()), "ServiceMobileClient.asmx").toString();

		hc = (HttpURLConnection) new URL(url).openConnection();
		/** Some web servers requires these properties */
		hc.setRequestMethod("POST");
		hc.setRequestProperty("SOAPAction", "http://tempuri.org/services/MobileClient/WSActualizarFechaVencimiento");
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
			//TODO: Arrendamiento
			Node nodo = doc.getElementsByTagName("WSActualizarFechaVencimientoResult").item(0);
			if (nodo.getChildNodes().item(0) != null)
			{
				String resultado = nodo.getChildNodes().item(0).getNodeValue();
			}
		}catch(Exception ex){
			//No se envia nada porque si no se actualiza la fecha en el SC no tiene repercusiones.
			String resultado = ex.getMessage();
		}
		hc.disconnect();

	}

	@SuppressWarnings("static-access")
	public static String WSFechaVencimientoUltimaFactura() throws Exception
	{
		String fechaVencimiento = "";
		ConfiguracionLocal config = (ConfiguracionLocal) Sesion.get(Campo.ConfiguracionLocal);

		HttpURLConnection hc;

		String message = "<soap:Envelope xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\" " +
				"xmlns:tem=\"http://tempuri.org/services/MobileClient\">" +
				"<soap:Body>" +
				"<WSFechaVencimientoUltimaFactura xmlns=\"http://tempuri.org/services/MobileClient\">" +
				"</WSFechaVencimientoUltimaFactura>" +
				"</soap:Body>" +
				"</soap:Envelope>";

		String url = Uri.withAppendedPath(Uri.parse(config.get(CampoConfiguracion.URL).toString()), "ServiceMobileClient.asmx").toString();

		hc = (HttpURLConnection) new URL(url).openConnection();
		/** Some web servers requires these properties */
		hc.setRequestMethod("POST");
		hc.setRequestProperty("SOAPAction", "http://tempuri.org/services/MobileClient/WSFechaVencimientoUltimaFactura");
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
			//TODO: Arrendamiento
			Node nodo = doc.getElementsByTagName("WSFechaVencimientoUltimaFacturaResult").item(0);
			if (nodo.getChildNodes().item(0) != null)
			{
				fechaVencimiento = nodo.getChildNodes().item(0).getNodeValue();
			}
		}catch(Exception ex){
			fechaVencimiento = "";
		}
		hc.disconnect();
		return fechaVencimiento;

	}
	public static void WSObtenerUsuarioContrasena(Object[] params) throws Exception
	{
		HttpURLConnection hc;
		String usuario = params[0].toString();
		String contrasena = params[1].toString();
		String mensaje = params[2].toString();
		boolean vendedor = (Boolean) params[3];
		boolean modulo = (Boolean) params[4];
		String servicio = params[5].toString();
		int timeOut = (Integer) params[6];

		String message = "<soap:Envelope xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\" " +
				"xmlns:tem=\"http://tempuri.org/services/MobileClient\">" +
				"<soap:Body>" +
				"<WSObtenerUsuarioContrasena xmlns=\"http://tempuri.org/services/MobileClient\">" +
				"<pvUsuario>" + usuario + "</pvUsuario><pvContrasena>" + contrasena + "</pvContrasena>" + "<prMensaje>" + mensaje + "</prMensaje>" + "<prVendedor>" + vendedor + "</prVendedor>" + "<prModulo>" + modulo + "</prModulo>" +
				"</WSObtenerUsuarioContrasena>" +
				"</soap:Body>" +
				"</soap:Envelope>";

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
			params[2] = doc.getElementsByTagName("prMensaje").item(0).getChildNodes().item(0).getNodeValue();
		}
		if (doc.getElementsByTagName("prVendedor").item(0) != null)
		{
			params[3] = doc.getElementsByTagName("prVendedor").item(0).getChildNodes().item(0).getNodeValue();
		}
		if (doc.getElementsByTagName("prModulo").item(0) != null)
		{
			params[4] = doc.getElementsByTagName("prModulo").item(0).getChildNodes().item(0).getNodeValue();
		}

		hc.disconnect();
	}

	public static boolean WSAuditoriaVerificar() throws Exception
	{
		boolean auditoriaCorrecta = false;
		ConfiguracionLocal config = (ConfiguracionLocal) Sesion.get(Campo.ConfiguracionLocal);

		HttpURLConnection hc;

		String message = "<soap:Envelope xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\" " +
				"xmlns:tem=\"http://tempuri.org/services/MobileClient\">" +
				"<soap:Body>" +
				"<WSAuditoriaVerificar xmlns=\"http://tempuri.org/services/MobileClient\">" +
				"</WSAuditoriaVerificar>" +
				"</soap:Body>" +
				"</soap:Envelope>";

		String url = Uri.withAppendedPath(Uri.parse(config.get(CampoConfiguracion.URL).toString()), "ServiceMobileClient.asmx").toString();

		hc = (HttpURLConnection) new URL(url).openConnection();
		/** Some web servers requires these properties */
		hc.setRequestMethod("POST");
		hc.setRequestProperty("SOAPAction", "http://tempuri.org/services/MobileClient/WSAuditoriaVerificar");
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

		isr = new InputStreamReader(hc.getInputStream());
		in = new BufferedReader(isr);
		while ((responseString = in.readLine()) != null)
		{
			outputString = outputString + responseString;
		}
		isr.close();

		Document doc = DocumentoXML.XMLfromString(outputString);
		Node nodo = doc.getElementsByTagName("WSAuditoriaVerificarResult").item(0);
		if (nodo.getChildNodes().item(0) != null)
		{
			auditoriaCorrecta = Boolean.parseBoolean(nodo.getChildNodes().item(0).getNodeValue());
		}
		hc.disconnect();
		return auditoriaCorrecta;
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

	public static boolean WSActualizarFechaTablas(TiposSincronizacion tipoSincronizacion, String sTablas) throws Exception
	{
		HttpURLConnection hc;

		String id = "";
		if (tipoSincronizacion == TiposSincronizacion.Vendedor)
			id = ((Vendedor)Sesion.get(Campo.VendedorActual)).VendedorId;
		else
			id = ((ConfiguracionLocal) Sesion.get(Campo.ConfiguracionLocal)).get(CampoConfiguracion.NUMERO_SERIE).toString();

		String message = "<soap:Envelope xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\" " +
				"xmlns:tem=\"http://tempuri.org/services/MobileClient\">" +
				"<soap:Body>" +
				"<WSActualizarFechaTablas xmlns=\"http://tempuri.org/services/MobileClient\">" +
				"<pariTipoSincronizacion>" + tipoSincronizacion + "</pariTipoSincronizacion>" +
				"<parsID>" + id + "</parsID>" +
				"<parsTablas>" + sTablas + "</parsTablas>" +
				"</WSActualizarFechaTablas>" +
				"</soap:Body>" +
				"</soap:Envelope>";

		ConfiguracionLocal config = (ConfiguracionLocal) Sesion.get(Campo.ConfiguracionLocal);
		String url = Uri.withAppendedPath(Uri.parse(config.get(CampoConfiguracion.URL).toString()), "ServiceMobileClient.asmx").toString();

		try{
			hc = (HttpURLConnection) new URL(url).openConnection();
			/** Some web servers requires these properties */
			hc.setRequestMethod("POST");
			hc.setRequestProperty("SOAPAction", "http://tempuri.org/services/MobileClient/WSActualizarFechaTablas");
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

	public static boolean WSMarcarRegistrosActualizados(TiposActualizacion tipoActualizacion, String sIdsCargados) throws Exception
	{
		HttpURLConnection hc;

		String message = "<soap:Envelope xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\" " +
				"xmlns:tem=\"http://tempuri.org/services/MobileClient\">" +
				"<soap:Body>" +
				"<WSMarcarRegistrosActualizados xmlns=\"http://tempuri.org/services/MobileClient\">" +
				"<pariTipoActualizacion>" + tipoActualizacion + "</pariTipoActualizacion>" +
				"<parsIdsCargados>" + sIdsCargados + "</parsIdsCargados>" +
				"</WSMarcarRegistrosActualizados>" +
				"</soap:Body>" +
				"</soap:Envelope>";

		ConfiguracionLocal config = (ConfiguracionLocal) Sesion.get(Campo.ConfiguracionLocal);
		String url = Uri.withAppendedPath(Uri.parse(config.get(CampoConfiguracion.URL).toString()), "ServiceMobileClient.asmx").toString();

		try{
			hc = (HttpURLConnection) new URL(url).openConnection();
			/** Some web servers requires these properties */
			hc.setRequestMethod("POST");
			hc.setRequestProperty("SOAPAction", "http://tempuri.org/services/MobileClient/WSMarcarRegistrosActualizados");
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
	public static boolean WSActualizarCapturaSQLite(String vendedorID, Date fechaInicial, Date fechaPrimerDia, Boolean reintentar, String archInfoEnvio) throws Exception
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
				"<parsVendedorID>" + vendedorID + "</parsVendedorID>" +
				"<bytes>" + parametroByte + "</bytes>" +
				"<pardFechaInicial>" + formato.format(fechaInicial) + "</pardFechaInicial>" +
				"<pardFechaPrimerDia>" + formato.format(fechaPrimerDia) + "</pardFechaPrimerDia>" +
				"<parsNombreZip>" + archZIP.getName() + "</parsNombreZip>" +
				"<refparsMensaje></refparsMensaje>" +
				"<refparbReintentar>" + reintentar.toString() + "</refparbReintentar>" +
				"</WSActualizarCapturaSQLite>" +
				"</soap:Body>" +
				"</soap:Envelope>";

		/*
		 * StringBuilder message = new StringBuilder(); message.append(
		 * "<soap:Envelope xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\" "
		 * ) ;
		 * message.append("xmlns:tem=\"http://tempuri.org/services/MobileClient\">"
		 * ); message.append(
		 * "<soap:Body><WSActualizarCapturaSQLite xmlns=\"http://tempuri.org/services/MobileClient\"><parsVendedorID>"
		 * + vendedorID + "</parsVendedorID>" ); message.append("<bytes>"); for
		 * (int i=0; i<fileContent.length; i=i+maxBufferSize){ if (maxBufferSize
		 * > fileContent.length - i ){ leer = fileContent.length - i; }else{
		 * leer = maxBufferSize; }
		 * message.append(android.util.Base64.encodeToString(fileContent,i,
		 * leer, 0)); } message.append("</bytes>");
		 * message.append("<pardFechaInicial>" + formato.format(fechaInicial) +
		 * "</pardFechaInicial>" ); message.append("<pardFechaPrimerDia>" +
		 * formato.format(fechaPrimerDia) + "</pardFechaPrimerDia>");
		 * message.append("<refparsMensaje></refparsMensaje>");
		 * message.append("<refparbReintentar>" + reintentar.toString() +
		 * "</refparbReintentar>" );
		 * message.append("</WSActualizarCapturaSQLite>" );
		 * message.append("</soap:Body>" ); message.append("</soap:Envelope>");
		 */

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

	@SuppressWarnings("deprecation")
	public static String WSVendedorObtenerBDSQLite(Date fechaIni, Date fechaFin) throws Exception
	{
		String nombreArchivo = "";

		HttpURLConnection hc;
		fechaFin.setHours(23);
		fechaFin.setMinutes(59);

		SimpleDateFormat formato = new SimpleDateFormat("yyyy-MM-dd'T'HH:mm:ss'Z'");

		ConfiguracionLocal config = (ConfiguracionLocal) Sesion.get(Campo.ConfiguracionLocal);
		String message = "<soap:Envelope xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\" " +
				"xmlns:tem=\"http://tempuri.org/services/MobileClient\">" +
				"<soap:Body>" +
				"<WSVendedorObtenerBDSQLite xmlns=\"http://tempuri.org/services/MobileClient\">" +
				"<parsTerminalNumeroSerie>" + config.get(CampoConfiguracion.NUMERO_SERIE).toString() + "</parsTerminalNumeroSerie><parsUsuarioClave>" + config.get(CampoConfiguracion.USUARIO) + "</parsUsuarioClave><parsContrasena>" + config.get(CampoConfiguracion.PASSWORD) + "</parsContrasena><pardFechaIni>" + formato.format(fechaIni) + "</pardFechaIni><pardFechaFin>" + formato.format(fechaFin) + "</pardFechaFin><parsTiposConsulta>1,3,6,10</parsTiposConsulta><refparsMensaje></refparsMensaje><parbLlamadoDesdeServer>false</parbLlamadoDesdeServer>" +
				"</WSVendedorObtenerBDSQLite>" +
				"</soap:Body>" +
				"</soap:Envelope>";
		String url = Uri.withAppendedPath(Uri.parse(config.get(CampoConfiguracion.URL).toString()), "ServiceMobileClient.asmx").toString();

		hc = (HttpURLConnection) new URL(url).openConnection();
		/** Some web servers requires these properties */
		hc.setRequestMethod("POST");
		hc.setRequestProperty("SOAPAction", "http://tempuri.org/services/MobileClient/WSVendedorObtenerBDSQLite");
		hc.setRequestProperty("User-Agent", "Profile/MIDP-1.0 Configuration/CLDC-1.0");
		hc.setRequestProperty("Content-Type", "text/xml;charset=utf-8");
		hc.setRequestProperty("Content-Length", Integer.toString(message.length()));
		hc.setRequestProperty("Connection", "close");
		hc.setConnectTimeout((Integer) config.get(CampoConfiguracion.TIMEOUT)); //multiplicar para convertir en milis
		hc.setAllowUserInteraction(true);
		hc.setDoOutput(true);
		hc.setDoInput(true);
		hc.setChunkedStreamingMode(0);
		OutputStream os = hc.getOutputStream();
		os.write(message.getBytes("UTF-8"));
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
			Node nodo = doc.getElementsByTagName("WSVendedorObtenerBDSQLiteResponse").item(0);
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

	public static String WSVendedorObtenerClientesNuevos(Date fechaIni, Date fechaFin) throws Exception {
		String nombreArchivo = "";

		HttpURLConnection hc;
		SimpleDateFormat formato = new SimpleDateFormat("yyyy-MM-dd'T'HH:mm:ss'Z'");

		ConfiguracionLocal config = (ConfiguracionLocal) Sesion.get(Campo.ConfiguracionLocal);
		String message = "<soap:Envelope xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\" " +
				"xmlns:tem=\"http://tempuri.org/services/MobileClient\">" +
				"<soap:Body>" +
				"<WSVendedorObtenerClientesNuevos xmlns=\"http://tempuri.org/services/MobileClient\">" +
				"<parsTerminalNumeroSerie>" + config.get(CampoConfiguracion.NUMERO_SERIE).toString() + "</parsTerminalNumeroSerie>" +
				"<parsUsuarioClave>" + config.get(CampoConfiguracion.USUARIO) + "</parsUsuarioClave>" +
				"<parsContrasena>" + config.get(CampoConfiguracion.PASSWORD) + "</parsContrasena>" +
				"<pardFechaIni>" + formato.format(fechaIni) + "</pardFechaIni>" +
				"<pardFechaFin>" + formato.format(fechaFin) + "</pardFechaFin>" +
				"<parsTiposConsulta>10</parsTiposConsulta>" +
				"<refparsMensaje></refparsMensaje>" +
				"<parbLlamadoDesdeServer>false</parbLlamadoDesdeServer>" +
				"</WSVendedorObtenerClientesNuevos>" +
				"</soap:Body>" +
				"</soap:Envelope>";
		String url = Uri.withAppendedPath(Uri.parse(config.get(CampoConfiguracion.URL).toString()), "ServiceMobileClient.asmx").toString();

		hc = (HttpURLConnection) new URL(url).openConnection();
		/** Some web servers requires these properties */
		hc.setRequestMethod("POST");
		hc.setRequestProperty("SOAPAction", "http://tempuri.org/services/MobileClient/WSVendedorObtenerClientesNuevos");
		hc.setRequestProperty("User-Agent", "Profile/MIDP-1.0 Configuration/CLDC-1.0");
		hc.setRequestProperty("Content-Type", "text/xml;charset=utf-8");
		hc.setRequestProperty("Content-Length", Integer.toString(message.length()));
		hc.setRequestProperty("Connection", "close");
		hc.setConnectTimeout((Integer) config.get(CampoConfiguracion.TIMEOUT)); //multiplicar para convertir en milis
		hc.setAllowUserInteraction(true);
		hc.setDoOutput(true);
		hc.setDoInput(true);
		hc.setChunkedStreamingMode(0);
		OutputStream os = hc.getOutputStream();
		os.write(message.getBytes("UTF-8"));
		os.close();

		String outputString = "";
		InputStreamReader isr = null;
		BufferedReader in = null;
		String responseString = null;

		if (hc.getResponseCode() == 200) {
			isr = new InputStreamReader(hc.getInputStream());
			in = new BufferedReader(isr);
			while ((responseString = in.readLine()) != null) {
				outputString = outputString + responseString;
			}
			isr.close();
			Document doc = DocumentoXML.XMLfromString(outputString);
			Node nodo = doc.getElementsByTagName("WSVendedorObtenerClientesNuevosResponse").item(0);
			if (nodo.getChildNodes().item(0).getChildNodes().item(0) == null) {
				if (nodo.getChildNodes().item(1).getChildNodes().item(0) != null) {
					String msgError = nodo.getChildNodes().item(1).getChildNodes().item(0).getNodeValue();
					throw new Exception(msgError);
				} else {
					throw new Exception("Estructura de respuesta incorrecta");
				}
			} else {
				nombreArchivo = nodo.getChildNodes().item(0).getChildNodes().item(0).getNodeValue();
			}
		} else {
			InputStream es = hc.getErrorStream();
			throw new Exception(ObtenerErrorSOAP(es));
		}

		hc.disconnect();
		return nombreArchivo;
	}

	public static boolean WSGuardarAgendaClientesNuevos() throws Exception
	{
		HttpURLConnection hc;
		ConfiguracionLocal config = (ConfiguracionLocal) Sesion.get(Campo.ConfiguracionLocal);
		String message = "<soap:Envelope xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\" " +
				"xmlns:tem=\"http://tempuri.org/services/MobileClient\">" +
				"<soap:Body>" +
				"<WSGuardarAgendaClientesNuevos xmlns=\"http://tempuri.org/services/MobileClient\">" +
				"<parsUsuarioClave>" + config.get(CampoConfiguracion.USUARIO) + "</parsUsuarioClave>" +
				"</WSGuardarAgendaClientesNuevos>" +
				"</soap:Body>" +
				"</soap:Envelope>";

		String url = Uri.withAppendedPath(Uri.parse(config.get(CampoConfiguracion.URL).toString()), "ServiceMobileClient.asmx").toString();

		try{
			hc = (HttpURLConnection) new URL(url).openConnection();
			/** Some web servers requires these properties */
			hc.setRequestMethod("POST");
			hc.setRequestProperty("SOAPAction", "http://tempuri.org/services/MobileClient/WSGuardarAgendaClientesNuevos");
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

	public static String WSActualizarClientesAgenda(Date fechaIni, Date fechaFin) throws Exception{
		String nombreArchivo = "";

		HttpURLConnection hc;
		//Text text = new Text();
		ConfiguracionLocal config = (ConfiguracionLocal) Sesion.get(Campo.ConfiguracionLocal);
		String vendedorID = ((Vendedor)Sesion.get(Campo.VendedorActual)).VendedorId;

		SimpleDateFormat formato = new SimpleDateFormat("yyyy-MM-dd'T'HH:mm:ss'Z'");

		String message = "<soap:Envelope xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\" " +
				"xmlns:tem=\"http://tempuri.org/services/MobileClient\">" +
				"<soap:Body>" +
				"<WSActualizarClientesAgenda xmlns=\"http://tempuri.org/services/MobileClient\">" +
				"<parsVendedorID>" + vendedorID + "</parsVendedorID>" +
				"<pardFechaIni>" + formato.format(fechaIni) + "</pardFechaIni><pardFechaFin>" + formato.format(fechaFin) + "</pardFechaFin>" +
				"</WSActualizarClientesAgenda>" +
				"</soap:Body>" +
				"</soap:Envelope>";

		String url = Uri.withAppendedPath(Uri.parse(config.get(CampoConfiguracion.URL).toString()), "ServiceMobileClient.asmx").toString();

		hc = (HttpURLConnection) new URL(url).openConnection();
		/** Some web servers requires these properties */
		hc.setRequestMethod("POST");

		hc.setRequestProperty("SOAPAction", "http://tempuri.org/services/MobileClient/WSActualizarClientesAgenda");
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
			Node nodo = doc.getElementsByTagName("WSActualizarClientesAgendaResponse").item(0);
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

	public static String WSObtenerActualizacionPreciosSQLite(Date fechaIni, Date fechaFin) throws Exception
	{
		String listasCargadas = Consultas.ConsultasPrecio.obtenerListasCargadas();

		String nombreArchivo = "";

		HttpURLConnection hc;
		//Text text = new Text();
		ConfiguracionLocal config = (ConfiguracionLocal) Sesion.get(Campo.ConfiguracionLocal);
		String vendedorID = ((Vendedor)Sesion.get(Campo.VendedorActual)).VendedorId;

		SimpleDateFormat formato = new SimpleDateFormat("yyyy-MM-dd'T'HH:mm:ss'Z'");

		String message = "<soap:Envelope xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\" " +
				"xmlns:tem=\"http://tempuri.org/services/MobileClient\">" +
				"<soap:Body>" +
				"<WSObtenerActualizacionPreciosSQLite xmlns=\"http://tempuri.org/services/MobileClient\">" +
				"<parsVendedorID>" + vendedorID + "</parsVendedorID>" +
				"<pardFechaIni>" + formato.format(fechaIni) + "</pardFechaIni><pardFechaFin>" + formato.format(fechaFin) + "</pardFechaFin>" +
				"<parsListasCargadas>" + listasCargadas + "</parsListasCargadas>" +
				"</WSObtenerActualizacionPreciosSQLite>" +
				"</soap:Body>" +
				"</soap:Envelope>";

		String url = Uri.withAppendedPath(Uri.parse(config.get(CampoConfiguracion.URL).toString()), "ServiceMobileClient.asmx").toString();

		hc = (HttpURLConnection) new URL(url).openConnection();
		/** Some web servers requires these properties */
		hc.setRequestMethod("POST");

		hc.setRequestProperty("SOAPAction", "http://tempuri.org/services/MobileClient/WSObtenerActualizacionPreciosSQLite");
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
			Node nodo = doc.getElementsByTagName("WSObtenerActualizacionPreciosSQLiteResponse").item(0);
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

	public static String WSVendedorObtenerTimbradoCFDIs(String listadoFacturas ) throws Exception
	{
		String nombreArchivo = "";

		HttpURLConnection hc;
		ConfiguracionLocal config = (ConfiguracionLocal) Sesion.get(Campo.ConfiguracionLocal);
		String vendedorID = ((Vendedor)Sesion.get(Campo.VendedorActual)).VendedorId;

		String message = "<soap:Envelope xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\" " +
				"xmlns:tem=\"http://tempuri.org/services/MobileClient\">" +
				"<soap:Body>" +
				"<WSVendedorObtenerTimbradoCFDIs xmlns=\"http://tempuri.org/services/MobileClient\">" +
				"<parsVendedorID>" + vendedorID + "</parsVendedorID>" +
				"<parsListadoFacturas>" + listadoFacturas + "</parsListadoFacturas>" +
				"</WSVendedorObtenerTimbradoCFDIs>" +
				"</soap:Body>" +
				"</soap:Envelope>";

		String url = Uri.withAppendedPath(Uri.parse(config.get(CampoConfiguracion.URL).toString()), "ServiceMobileClient.asmx").toString();

		hc = (HttpURLConnection) new URL(url).openConnection();
		/** Some web servers requires these properties */
		hc.setRequestMethod("POST");

		hc.setRequestProperty("SOAPAction", "http://tempuri.org/services/MobileClient/WSVendedorObtenerTimbradoCFDIs");
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
			Node nodo = doc.getElementsByTagName("WSVendedorObtenerTimbradoCFDIsResponse").item(0);
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

	public static String WSObtenerDocumentoSQLite(String sFolio) throws Exception
	{
		String nombreArchivo = "";

		HttpURLConnection hc;
		//Text text = new Text();
		ConfiguracionLocal config = (ConfiguracionLocal) Sesion.get(Campo.ConfiguracionLocal);
		String vendedorID = ((Vendedor)Sesion.get(Campo.VendedorActual)).VendedorId;
		String clienteClave = ((Cliente)Sesion.get(Campo.ClienteActual)).ClienteClave;

		String message = "<soap:Envelope xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\" " +
				"xmlns:tem=\"http://tempuri.org/services/MobileClient\">" +
				"<soap:Body>" +
				"<WSObtenerDocumentoSQLite xmlns=\"http://tempuri.org/services/MobileClient\">" +
				"<parsVendedorID>" + vendedorID + "</parsVendedorID>" +
				"<parsClienteClave>" + clienteClave + "</parsClienteClave><parsFolio>" + sFolio + "</parsFolio>" +
				"</WSObtenerDocumentoSQLite>" +
				"</soap:Body>" +
				"</soap:Envelope>";

		String url = Uri.withAppendedPath(Uri.parse(config.get(CampoConfiguracion.URL).toString()), "ServiceMobileClient.asmx").toString();

		hc = (HttpURLConnection) new URL(url).openConnection();
		/** Some web servers requires these properties */
		hc.setRequestMethod("POST");

		hc.setRequestProperty("SOAPAction", "http://tempuri.org/services/MobileClient/WSObtenerDocumentoSQLite");
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
			Node nodo = doc.getElementsByTagName("WSObtenerDocumentoSQLiteResponse").item(0);
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

	public static String WSObtenerActualizacionPorSPSQLite(TiposActualizacion tipoActualizacion,Date fechaIni, Date fechaFin, String listaIds) throws Exception
	{
		String nombreArchivo = "";

		HttpURLConnection hc;
		//Text text = new Text();
		ConfiguracionLocal config = (ConfiguracionLocal) Sesion.get(Campo.ConfiguracionLocal);
		String vendedorID = ((Vendedor)Sesion.get(Campo.VendedorActual)).VendedorId;

		SimpleDateFormat formato = new SimpleDateFormat("yyyy-MM-dd'T'HH:mm:ss'Z'");

		String message = "<soap:Envelope xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\" " +
				"xmlns:tem=\"http://tempuri.org/services/MobileClient\">" +
				"<soap:Body>" +
				"<WSObtenerActualizacionPorSPSQLite xmlns=\"http://tempuri.org/services/MobileClient\">" +
				"<pariTipoActualizacion>" + tipoActualizacion + "</pariTipoActualizacion>" +
				"<parsVendedorID>" + vendedorID + "</parsVendedorID>" +
				"<pardFechaIni>" + formato.format(fechaIni) + "</pardFechaIni><pardFechaFin>" + formato.format(fechaFin) + "</pardFechaFin>" +
				"<parsIdsCargados>" + listaIds + "</parsIdsCargados>" +
				"</WSObtenerActualizacionPorSPSQLite>" +
				"</soap:Body>" +
				"</soap:Envelope>";

		String url = Uri.withAppendedPath(Uri.parse(config.get(CampoConfiguracion.URL).toString()), "ServiceMobileClient.asmx").toString();

		hc = (HttpURLConnection) new URL(url).openConnection();
		/** Some web servers requires these properties */
		hc.setRequestMethod("POST");

		hc.setRequestProperty("SOAPAction", "http://tempuri.org/services/MobileClient/WSObtenerActualizacionPorSPSQLite");
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
			Node nodo = doc.getElementsByTagName("WSObtenerActualizacionPorSPSQLiteResponse").item(0);
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

	public static String WSAplicacionObtenerActualizacionSQLiteMetodo2(String condicionesTablas ) throws Exception
	{
		String nombreArchivo = "";

		HttpURLConnection hc;
		//Text text = new Text();
		ConfiguracionLocal config = (ConfiguracionLocal) Sesion.get(Campo.ConfiguracionLocal);
		String numeroSerie = ((ConfiguracionLocal) Sesion.get(Campo.ConfiguracionLocal)).get(CampoConfiguracion.NUMERO_SERIE).toString();

		SimpleDateFormat formato = new SimpleDateFormat("yyyy-MM-dd'T'HH:mm:ss'Z'");

		String message = "<soap:Envelope xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\" " +
				"xmlns:tem=\"http://tempuri.org/services/MobileClient\">" +
				"<soap:Body>" +
				"<WSAplicacionObtenerActualizacionSQLiteMetodo2 xmlns=\"http://tempuri.org/services/MobileClient\">" +
				"<parsNumeroSerie>" + numeroSerie + "</parsNumeroSerie>" +
				"<parsCondicionTablas>" + condicionesTablas + "</parsCondicionTablas>" +
				"</WSAplicacionObtenerActualizacionSQLiteMetodo2>" +
				"</soap:Body>" +
				"</soap:Envelope>";

		String url = Uri.withAppendedPath(Uri.parse(config.get(CampoConfiguracion.URL).toString()), "ServiceMobileClient.asmx").toString();

		hc = (HttpURLConnection) new URL(url).openConnection();
		/** Some web servers requires these properties */
		hc.setRequestMethod("POST");

		hc.setRequestProperty("SOAPAction", "http://tempuri.org/services/MobileClient/WSAplicacionObtenerActualizacionSQLiteMetodo2");
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
			Node nodo = doc.getElementsByTagName("WSAplicacionObtenerActualizacionSQLiteMetodo2Response").item(0);
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

	public static String WSAplicacionObtenerActualizacion(String dataSetActualiza, String condicionesTablas) throws Exception
	{
		String nombreArchivo = "";

		HttpURLConnection hc;
		//Text text = new Text();	 	   

		String message = "<soap:Envelope xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\" " +
				"xmlns:tem=\"http://tempuri.org/services/MobileClient\">" +
				"<soap:Body>" +
				"<WSAplicacionObtenerActualizacionSQLite xmlns=\"http://tempuri.org/services/MobileClient\">" +
				dataSetActualiza +
				//"<pardXMLUltActualizacion>" + archivoXML  + "</pardXMLUltActualizacion>" +
				"<parsCondicionTablas>" + condicionesTablas + "</parsCondicionTablas>" +
				"</WSAplicacionObtenerActualizacionSQLite>" +
				"</soap:Body>" +
				"</soap:Envelope>";

		ConfiguracionLocal config = (ConfiguracionLocal) Sesion.get(Campo.ConfiguracionLocal);
		String url = Uri.withAppendedPath(Uri.parse(config.get(CampoConfiguracion.URL).toString()), "ServiceMobileClient.asmx").toString();

		hc = (HttpURLConnection) new URL(url).openConnection();
		/** Some web servers requires these properties */
		hc.setRequestMethod("POST");

		hc.setRequestProperty("SOAPAction", "http://tempuri.org/services/MobileClient/WSAplicacionObtenerActualizacionSQLite");
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
			Node nodo = doc.getElementsByTagName("WSAplicacionObtenerActualizacionSQLiteResponse").item(0);
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

	public static String WSVendedorObtenerActualizacionSQLite(String dataSetActualiza, String condicionesTablas, String IdsCargas, Date fechaIni, Date fechaFin ) throws Exception
	{
		String nombreArchivo = "";

		HttpURLConnection hc;
		//Text text = new Text();
		ConfiguracionLocal config = (ConfiguracionLocal) Sesion.get(Campo.ConfiguracionLocal);
		Usuario usu = Consultas.ConsultasUsuario.obtenerUsuarioPorClave(config.get(CampoConfiguracion.USUARIO).toString());

		SimpleDateFormat formato = new SimpleDateFormat("yyyy-MM-dd'T'HH:mm:ss'Z'");

		String message = "<soap:Envelope xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\" " +
				"xmlns:tem=\"http://tempuri.org/services/MobileClient\">" +
				"<soap:Body>" +
				"<WSVendedorObtenerActualizacionSQLite xmlns=\"http://tempuri.org/services/MobileClient\">" +
				dataSetActualiza +
				//"<pardXMLUltActualizacion>" + archivoXML  + "</pardXMLUltActualizacion>" +
				"<parsUsuarioID>" + usu.USUId + "</parsUsuarioID>" +
				"<parsCondicionTablas>" + condicionesTablas + "</parsCondicionTablas>" +
				"<parsIdsCargasEnMovil>" + IdsCargas + "</parsIdsCargasEnMovil>" +
				"<pardFechaIni>" + formato.format(fechaIni) + "</pardFechaIni><pardFechaFin>" + formato.format(fechaFin) + "</pardFechaFin>" +
				"</WSVendedorObtenerActualizacionSQLite>" +
				"</soap:Body>" +
				"</soap:Envelope>";

		String url = Uri.withAppendedPath(Uri.parse(config.get(CampoConfiguracion.URL).toString()), "ServiceMobileClient.asmx").toString();

		hc = (HttpURLConnection) new URL(url).openConnection();
		/** Some web servers requires these properties */
		hc.setRequestMethod("POST");

		hc.setRequestProperty("SOAPAction", "http://tempuri.org/services/MobileClient/WSVendedorObtenerActualizacionSQLite");
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
			Node nodo = doc.getElementsByTagName("WSVendedorObtenerActualizacionSQLiteResponse").item(0);
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

	public static String WSVendedorObtenerActualizacionPromociones(String dataSetActualiza, String condicionesTablas, Date fechaIni, Date fechaFin ) throws Exception
	{
		String nombreArchivo = "";

		HttpURLConnection hc;
		//Text text = new Text();
		ConfiguracionLocal config = (ConfiguracionLocal) Sesion.get(Campo.ConfiguracionLocal);
		Usuario usu = Consultas.ConsultasUsuario.obtenerUsuarioPorClave(config.get(CampoConfiguracion.USUARIO).toString());

		SimpleDateFormat formato = new SimpleDateFormat("yyyy-MM-dd'T'HH:mm:ss'Z'");

		String message = "<soap:Envelope xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\" " +
				"xmlns:tem=\"http://tempuri.org/services/MobileClient\">" +
				"<soap:Body>" +
				"<WSVendedorObtenerActualizacionPromociones xmlns=\"http://tempuri.org/services/MobileClient\">" +
				dataSetActualiza +
				//"<pardXMLUltActualizacion>" + archivoXML  + "</pardXMLUltActualizacion>" +
				"<parsUsuarioID>" + usu.USUId + "</parsUsuarioID>" +
				"<parsCondicionTablas>" + condicionesTablas + "</parsCondicionTablas>" +
				"<pardFechaIni>" + formato.format(fechaIni) + "</pardFechaIni><pardFechaFin>" + formato.format(fechaFin) + "</pardFechaFin>" +
				"</WSVendedorObtenerActualizacionPromociones>" +
				"</soap:Body>" +
				"</soap:Envelope>";

		String url = Uri.withAppendedPath(Uri.parse(config.get(CampoConfiguracion.URL).toString()), "ServiceMobileClient.asmx").toString();

		hc = (HttpURLConnection) new URL(url).openConnection();
		/** Some web servers requires these properties */
		hc.setRequestMethod("POST");

		hc.setRequestProperty("SOAPAction", "http://tempuri.org/services/MobileClient/WSVendedorObtenerActualizacionPromociones");
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
			Node nodo = doc.getElementsByTagName("WSVendedorObtenerActualizacionPromocionesResponse").item(0);
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

	public static String WSVendedorObtenerActualizacionProductos(String dataSetActualiza, String condicionesTablas, Date fechaIni, Date fechaFin ) throws Exception
	{
		String nombreArchivo = "";

		HttpURLConnection hc;
		//Text text = new Text();
		ConfiguracionLocal config = (ConfiguracionLocal) Sesion.get(Campo.ConfiguracionLocal);
		Usuario usu = Consultas.ConsultasUsuario.obtenerUsuarioPorClave(config.get(CampoConfiguracion.USUARIO).toString());

		SimpleDateFormat formato = new SimpleDateFormat("yyyy-MM-dd'T'HH:mm:ss'Z'");

		String message = "<soap:Envelope xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\" " +
				"xmlns:tem=\"http://tempuri.org/services/MobileClient\">" +
				"<soap:Body>" +
				"<WSVendedorObtenerActualizacionProductos xmlns=\"http://tempuri.org/services/MobileClient\">" +
				dataSetActualiza +
				//"<pardXMLUltActualizacion>" + archivoXML  + "</pardXMLUltActualizacion>" +
				"<parsUsuarioID>" + usu.USUId + "</parsUsuarioID>" +
				"<parsCondicionTablas>" + condicionesTablas + "</parsCondicionTablas>" +
				"<pardFechaIni>" + formato.format(fechaIni) + "</pardFechaIni><pardFechaFin>" + formato.format(fechaFin) + "</pardFechaFin>" +
				"</WSVendedorObtenerActualizacionProductos>" +
				"</soap:Body>" +
				"</soap:Envelope>";

		String url = Uri.withAppendedPath(Uri.parse(config.get(CampoConfiguracion.URL).toString()), "ServiceMobileClient.asmx").toString();

		hc = (HttpURLConnection) new URL(url).openConnection();
		/** Some web servers requires these properties */
		hc.setRequestMethod("POST");

		hc.setRequestProperty("SOAPAction", "http://tempuri.org/services/MobileClient/WSVendedorObtenerActualizacionProductos");
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
			Node nodo = doc.getElementsByTagName("WSVendedorObtenerActualizacionProductosResponse").item(0);
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

	public static String WSVendedorObtenerCobranzaSQLite(String dataSetActualiza, String condicionesTablas, Date fechaIni, Date fechaFin ) throws Exception
	{
		String nombreArchivo = "";

		HttpURLConnection hc;
		//Text text = new Text();
		ConfiguracionLocal config = (ConfiguracionLocal) Sesion.get(Campo.ConfiguracionLocal);
		Usuario usu = Consultas.ConsultasUsuario.obtenerUsuarioPorClave(config.get(CampoConfiguracion.USUARIO).toString());

		SimpleDateFormat formato = new SimpleDateFormat("yyyy-MM-dd'T'HH:mm:ss'Z'");

		String message = "<soap:Envelope xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\" " +
				"xmlns:tem=\"http://tempuri.org/services/MobileClient\">" +
				"<soap:Body>" +
				"<WSVendedorObtenerCobranzaSQLite xmlns=\"http://tempuri.org/services/MobileClient\">" +
				dataSetActualiza +
				//"<pardXMLUltActualizacion>" + archivoXML  + "</pardXMLUltActualizacion>" +
				"<parsUsuarioID>" + usu.USUId + "</parsUsuarioID>" +
				"<parsCondicionTablas>" + condicionesTablas + "</parsCondicionTablas>" +
				"<pardFechaIni>" + formato.format(fechaIni) + "</pardFechaIni>" +
				"<pardFechaFin>" + formato.format(fechaFin) + "</pardFechaFin>" +
				"</WSVendedorObtenerCobranzaSQLite>" +
				"</soap:Body>" +
				"</soap:Envelope>";

		String url = Uri.withAppendedPath(Uri.parse(config.get(CampoConfiguracion.URL).toString()), "ServiceMobileClient.asmx").toString();

		hc = (HttpURLConnection) new URL(url).openConnection();
		/** Some web servers requires these properties */
		hc.setRequestMethod("POST");

		hc.setRequestProperty("SOAPAction", "http://tempuri.org/services/MobileClient/WSVendedorObtenerCobranzaSQLite");
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
			Node nodo = doc.getElementsByTagName("WSVendedorObtenerCobranzaSQLiteResponse").item(0);
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

	public static String WSVendedorObtenerActualizacionInventario(String dataSetActualiza, String vendedorID) throws Exception
	{
		String nombreArchivo = "";

		HttpURLConnection hc;
		//Text text = new Text();	 	   

		String message = "<soap:Envelope xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\" " +
				"xmlns:tem=\"http://tempuri.org/services/MobileClient\">" +
				"<soap:Body>" +
				"<WSVendedorObtenerActualizacionInventario xmlns=\"http://tempuri.org/services/MobileClient\">" +
				dataSetActualiza +
				"<parsVendedorID>" + vendedorID + "</parsVendedorID>" +
				"</WSVendedorObtenerActualizacionInventario>" +
				"</soap:Body>" +
				"</soap:Envelope>";

		ConfiguracionLocal config = (ConfiguracionLocal) Sesion.get(Campo.ConfiguracionLocal);
		String url = Uri.withAppendedPath(Uri.parse(config.get(CampoConfiguracion.URL).toString()), "ServiceMobileClient.asmx").toString();

		hc = (HttpURLConnection) new URL(url).openConnection();
		/** Some web servers requires these properties */
		hc.setRequestMethod("POST");

		hc.setRequestProperty("SOAPAction", "http://tempuri.org/services/MobileClient/WSVendedorObtenerActualizacionInventario");
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
			Node nodo = doc.getElementsByTagName("WSVendedorObtenerActualizacionInventarioResponse").item(0);
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

	public static boolean WSEjecutarInterfaces(String vendedorID, Date fechaInicial, Date fechaPrimerDia, Boolean reintentar) throws Exception
	{
		boolean res = false;

		SimpleDateFormat formato = new SimpleDateFormat("yyyy-MM-dd'T'HH:mm:ss'Z'");

		String message = "<soap:Envelope xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\" " +
				"xmlns:tem=\"http://tempuri.org/services/MobileClient\">" +
				"<soap:Body>" +
				"<WSEjecutarInterfaces xmlns=\"http://tempuri.org/services/MobileClient\">" +
				"<parsVendedorID>" + vendedorID + "</parsVendedorID>" +
				"<pardFechaInicial>" + formato.format(fechaInicial) + "</pardFechaInicial>" +
				"<pardFechaPrimerDia>" + formato.format(fechaPrimerDia) + "</pardFechaPrimerDia>" +
				"<refparsMensaje></refparsMensaje>" +
				"<refparbReintentar>" + reintentar.toString() + "</refparbReintentar>" +
				"</WSEjecutarInterfaces>" +
				"</soap:Body>" +
				"</soap:Envelope>";

		ConfiguracionLocal config = (ConfiguracionLocal) Sesion.get(Campo.ConfiguracionLocal);
		String url = Uri.withAppendedPath(Uri.parse(config.get(CampoConfiguracion.URL).toString()), "ServiceMobileClient.asmx").toString();

		HttpURLConnection hc = (HttpURLConnection) new URL(url).openConnection();

		hc.setRequestMethod("POST");

		hc.setRequestProperty("SOAPAction", "http://tempuri.org/services/MobileClient/WSEjecutarInterfaces");
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
			Node nodo = doc.getElementsByTagName("WSEjecutarInterfacesResult").item(0);
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

	public static boolean WSActualizarSincronizacion(String vendedorID, Date fechaHoraActual) throws Exception
	{
		boolean res = false;

		SimpleDateFormat formato = new SimpleDateFormat("yyyy-MM-dd'T'HH:mm:ss'Z'");

		String message = "<soap:Envelope xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\" " +
				"xmlns:tem=\"http://tempuri.org/services/MobileClient\">" +
				"<soap:Body>" +
				"<WSActualizarSincronizacion xmlns=\"http://tempuri.org/services/MobileClient\">" +
				"<parsVendedorID>" + vendedorID + "</parsVendedorID>" +
				"<pardFechaHoraDispositivo>" + formato.format(fechaHoraActual) + "</pardFechaHoraDispositivo>" +
				"</WSActualizarSincronizacion>" +
				"</soap:Body>" +
				"</soap:Envelope>";

		ConfiguracionLocal config = (ConfiguracionLocal) Sesion.get(Campo.ConfiguracionLocal);
		String url = Uri.withAppendedPath(Uri.parse(config.get(CampoConfiguracion.URL).toString()), "ServiceMobileClient.asmx").toString();

		HttpURLConnection hc = (HttpURLConnection) new URL(url).openConnection();

		hc.setRequestMethod("POST");

		hc.setRequestProperty("SOAPAction", "http://tempuri.org/services/MobileClient/WSActualizarSincronizacion");
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
			Node nodo = doc.getElementsByTagName("WSActualizarSincronizacionResult").item(0);
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

	@SuppressWarnings("resource")
	public static boolean WSEnviarArchivoZip(String pathArchivo, int tipoArchivo) throws Exception
	{
		//Log.v("Path de imagenes", pathImagenes);
		boolean res = false;
		File archZIP = new File(pathArchivo);
		//Log.v("Path Absoluta",archZIP.getAbsolutePath());

		String pathToOurFile = archZIP.getAbsolutePath();

		FileInputStream fileInputStream = new FileInputStream(new File(pathToOurFile));

		// fileInputStream.read(fileContent);
		//Log.v("Maximo del archivo:", "Maximo: "+Integer.MAX_VALUE+" Maximo del path: "+archZIP.length());

		if (archZIP.length() > Integer.MAX_VALUE)
		{
			throw new Exception("Archivo demasiado grande");
		}

		byte fileContent[] = new byte[(int) archZIP.length()];
		// Create the byte array to hold the data

		// Read in the bytes
		int offset = 0;
		int numRead = 0;
		while (offset < fileContent.length && (numRead = fileInputStream.read(fileContent, offset, fileContent.length - offset)) >= 0)
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


		String parametroByte = android.util.Base64.encodeToString(fileContent, 0);

		String message = "<soap:Envelope xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\" " +
				"xmlns:tem=\"http://tempuri.org/services/MobileClient\">" +
				"<soap:Body>" +
				"<WSObtenerArchivoZipAndroid xmlns=\"http://tempuri.org/services/MobileClient\">" +
				"<parByteArchivo>" + parametroByte + "</parByteArchivo>" +
				"<parTipoArchivo>" + tipoArchivo + "</parTipoArchivo>" +
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
			//Log.v("Resultado", outputString);
			Node nodo = doc.getElementsByTagName("WSObtenerArchivoZipAndroidResult").item(0);

			if (nodo.getChildNodes().item(0) != null)
			{
				//Log.v("Nodo", nodo.getChildNodes().item(0).getNodeValue());
				res = Boolean.parseBoolean(nodo.getChildNodes().item(0).getNodeValue());
				if (!res)
				{
					//nodo = doc.getElementsByTagName("refparsMensaje").item(0);
					//if (nodo.getChildNodes().item(0) != null)
					//{

					//throw new Exception(nodo.getChildNodes().item(0).getNodeValue());
					//	}
					//Log.v("False", "Falso");
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
			//Log.v("Error de mensaje ", ex.getMessage());
			throw ex;
		}

		archZIP.delete();
		return res;
	}

	public static String WSVendedorNotificarModContrasena(String UsuarioMod, String ContrasenaMod) throws Exception{
		String ModificacionExitosa = "";
		ConfiguracionLocal config = (ConfiguracionLocal) Sesion.get(Campo.ConfiguracionLocal);

		HttpURLConnection hc;

		String message = "<soap:Envelope xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\" " +
				"xmlns:tem=\"http://tempuri.org/services/MobileClient\">" +
				"<soap:Body>" +
				"<WSVendedorNotificarModContrasena xmlns=\"http://tempuri.org/services/MobileClient\">" +
				"<pvUsuarioMod>" + UsuarioMod + "</pvUsuarioMod>" +
				"<pvContrasenaMod>" + ContrasenaMod + "</pvContrasenaMod>" +
				"</WSVendedorNotificarModContrasena>" +
				"</soap:Body>" +
				"</soap:Envelope>";

		String url = Uri.withAppendedPath(Uri.parse(config.get(CampoConfiguracion.URL).toString()), "ServiceMobileClient.asmx").toString();

		hc = (HttpURLConnection) new URL(url).openConnection();
		/** Some web servers requires these properties */
		hc.setRequestMethod("POST");
		hc.setRequestProperty("SOAPAction", "http://tempuri.org/services/MobileClient/WSVendedorNotificarModContrasena");
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

			Node nodo = doc.getElementsByTagName("WSVendedorNotificarModContrasenaResult").item(0);
			if (nodo.getChildNodes().item(0) != null)
			{
				ModificacionExitosa = nodo.getChildNodes().item(0).getNodeValue();
			}
		}catch(Exception ex){
			ModificacionExitosa = "";
		}
		hc.disconnect();
		return ModificacionExitosa;
	}

	public static boolean WSUsuarioRecibirConfigFechasAgendas() throws Exception
	{
		HttpURLConnection hc;

		String id = "";

		boolean res = false;
		ConfiguracionLocal config = (ConfiguracionLocal) Sesion.get(Campo.ConfiguracionLocal);

		String message = "<soap:Envelope xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\" " +
				"xmlns:tem=\"http://tempuri.org/services/MobileClient\">" +
				"<soap:Body>" +
				"<WSUsuarioRecibirConfigFechasAgendas xmlns=\"http://tempuri.org/services/MobileClient\">" +
				"<pvUsuario>" + config.get(CampoConfiguracion.USUARIO) + "</pvUsuario>" +
				"<refparsMensaje></refparsMensaje>" +
				"</WSUsuarioRecibirConfigFechasAgendas>" +
				"</soap:Body>" +
				"</soap:Envelope>";

		String url = Uri.withAppendedPath(Uri.parse(config.get(CampoConfiguracion.URL).toString()), "ServiceMobileClient.asmx").toString();

		hc = (HttpURLConnection) new URL(url).openConnection();
		/** Some web servers requires these properties */
		hc.setRequestMethod("POST");
		hc.setRequestProperty("SOAPAction", "http://tempuri.org/services/MobileClient/WSUsuarioRecibirConfigFechasAgendas");
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
			Node nodo = doc.getElementsByTagName("WSUsuarioRecibirConfigFechasAgendasResult").item(0);
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

	public static boolean WSUsuarioRecibirConfigFechaInicialAgendaNoMenor() throws Exception
	{
		HttpURLConnection hc;

		String id = "";

		boolean res = false;
		ConfiguracionLocal config = (ConfiguracionLocal) Sesion.get(Campo.ConfiguracionLocal);

		String message = "<soap:Envelope xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\" " +
				"xmlns:tem=\"http://tempuri.org/services/MobileClient\">" +
				"<soap:Body>" +
				"<WSFechaInicialAgendaNoMenor xmlns=\"http://tempuri.org/services/MobileClient\">" +
				"<parsClaveUsuario>" + config.get(CampoConfiguracion.USUARIO) + "</parsClaveUsuario>" +
				"</WSFechaInicialAgendaNoMenor>" +
				"</soap:Body>" +
				"</soap:Envelope>";

		String url = Uri.withAppendedPath(Uri.parse(config.get(CampoConfiguracion.URL).toString()), "ServiceMobileClient.asmx").toString();

		hc = (HttpURLConnection) new URL(url).openConnection();
		/** Some web servers requires these properties */
		hc.setRequestMethod("POST");
		hc.setRequestProperty("SOAPAction", "http://tempuri.org/services/MobileClient/WSFechaInicialAgendaNoMenor");
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
			Node nodo = doc.getElementsByTagName("WSFechaInicialAgendaNoMenorResult").item(0);
			if (nodo.getChildNodes().item(0) != null)
			{
				res = Boolean.parseBoolean(nodo.getChildNodes().item(0).getNodeValue());
			}
		}
		catch (Exception ex)
		{
			res = false;
		}
		hc.disconnect();
		return res;
	}

	public static boolean WSLimpiarClaveAcceso() throws Exception
	{
		boolean res = false;

		String message = "<soap:Envelope xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\" " +
				"xmlns:tem=\"http://tempuri.org/services/MobileClient\">" +
				"<soap:Body>" +
				"<WSLimpiarClaveAcceso xmlns=\"http://tempuri.org/services/MobileClient\">" +
				"</WSLimpiarClaveAcceso>" +
				"</soap:Body>" +
				"</soap:Envelope>";

		ConfiguracionLocal config = (ConfiguracionLocal) Sesion.get(Campo.ConfiguracionLocal);
		String url = Uri.withAppendedPath(Uri.parse(config.get(CampoConfiguracion.URL).toString()), "ServiceMobileClient.asmx").toString();

		HttpURLConnection hc = (HttpURLConnection) new URL(url).openConnection();

		hc.setRequestMethod("POST");

		hc.setRequestProperty("SOAPAction", "http://tempuri.org/services/MobileClient/WSLimpiarClaveAcceso");
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
			Node nodo = doc.getElementsByTagName("WSLimpiarClaveAccesoResult").item(0);
			if (nodo.getChildNodes().item(0) != null)
			{
				res = Boolean.parseBoolean(nodo.getChildNodes().item(0).getNodeValue());
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

	@SuppressWarnings("resource")
	public static String WSAlmacenarTicketPDF(String sClienteClave, String sArchivoPDFEnvio) throws Exception
	{
		boolean res = false;
		String sURLServer = "";

		File archZIP = new File(sArchivoPDFEnvio);

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
				"<WSAlmacenarTicketPDF xmlns=\"http://tempuri.org/services/MobileClient\">" +
				"<parsClienteClave>" + sClienteClave + "</parsClienteClave>" +
				"<parByteArchivo>" + parametroByte + "</parByteArchivo>" +
				"<refparsURL></refparsURL>" +
				"</WSAlmacenarTicketPDF>" +
				"</soap:Body>" +
				"</soap:Envelope>";


		fileContent = null;

		ConfiguracionLocal config = (ConfiguracionLocal) Sesion.get(Campo.ConfiguracionLocal);
		String url = Uri.withAppendedPath(Uri.parse(config.get(CampoConfiguracion.URL).toString()), "ServiceMobileClient.asmx").toString();

		HttpURLConnection hc = (HttpURLConnection) new URL(url).openConnection();

		hc.setRequestMethod("POST");

		hc.setRequestProperty("SOAPAction", "http://tempuri.org/services/MobileClient/WSAlmacenarTicketPDF");
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
			Node nodo = doc.getElementsByTagName("WSAlmacenarTicketPDFResult").item(0);
			if (nodo.getChildNodes().item(0) != null)
			{
				res = Boolean.parseBoolean(nodo.getChildNodes().item(0).getNodeValue());
				if (res)
				{
					nodo = doc.getElementsByTagName("refparsURL").item(0);
					if (nodo.getChildNodes().item(0) != null)
					{
						sURLServer = nodo.getChildNodes().item(0).getNodeValue();
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
		return sURLServer;
	}

	public static void WSEnviarCorreoArchivosPDF(String sVendedorID, String sClienteClave, String sCorreoCliente, String sIDs, String sTipos, String sFolios, String sArchivosPDF) throws Exception
	{
		String message = "<soap:Envelope xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\" " +
				"xmlns:tem=\"http://tempuri.org/services/MobileClient\">" +
				"<soap:Body>" +
				"<WSEnviarCorreoArchivosPDF xmlns=\"http://tempuri.org/services/MobileClient\">" +
				"<parsVendedorID>" + sVendedorID + "</parsVendedorID>" +
				"<parsClienteClave>" + sClienteClave + "</parsClienteClave>" +
				"<parsCorreoCliente>" + sCorreoCliente + "</parsCorreoCliente>" +
				"<parsIDs>" + sIDs + "</parsIDs>" +
				"<parsTipos>" + sTipos + "</parsTipos>" +
				"<parsFolios>" + sFolios + "</parsFolios>" +
				"<parsArchivosPDF>" + sArchivosPDF + "</parsArchivosPDF>" +
				"</WSEnviarCorreoArchivosPDF>" +
				"</soap:Body>" +
				"</soap:Envelope>";

		ConfiguracionLocal config = (ConfiguracionLocal) Sesion.get(Campo.ConfiguracionLocal);
		String url = Uri.withAppendedPath(Uri.parse(config.get(CampoConfiguracion.URL).toString()), "ServiceMobileClient.asmx").toString();

		HttpURLConnection hc = (HttpURLConnection) new URL(url).openConnection();

		hc.setRequestMethod("POST");

		hc.setRequestProperty("SOAPAction", "http://tempuri.org/services/MobileClient/WSEnviarCorreoArchivosPDF");
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
			//TODO: Arrendamiento
			Node nodo = doc.getElementsByTagName("WSEnviarCorreoArchivosPDFResult").item(0);
			if (nodo.getChildNodes().item(0) != null)
			{
				String resultado = nodo.getChildNodes().item(0).getNodeValue();
			}
		}catch(Exception ex){
			String resultado = ex.getMessage();
		}
		hc.disconnect();

	}

	public static void WSOrganizarArchivosPDFxCliente() throws Exception
	{
		String message = "<soap:Envelope xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\" " +
				"xmlns:tem=\"http://tempuri.org/services/MobileClient\">" +
				"<soap:Body>" +
				"<WSOrganizarArchivosPDFxCliente xmlns=\"http://tempuri.org/services/MobileClient\">" +
				"</WSOrganizarArchivosPDFxCliente>" +
				"</soap:Body>" +
				"</soap:Envelope>";

		ConfiguracionLocal config = (ConfiguracionLocal) Sesion.get(Campo.ConfiguracionLocal);
		String url = Uri.withAppendedPath(Uri.parse(config.get(CampoConfiguracion.URL).toString()), "ServiceMobileClient.asmx").toString();

		HttpURLConnection hc = (HttpURLConnection) new URL(url).openConnection();

		hc.setRequestMethod("POST");

		hc.setRequestProperty("SOAPAction", "http://tempuri.org/services/MobileClient/WSOrganizarArchivosPDFxCliente");
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
			//TODO: Arrendamiento
			Node nodo = doc.getElementsByTagName("WSOrganizarArchivosPDFxClienteResult").item(0);
			if (nodo.getChildNodes().item(0) != null)
			{
				String resultado = nodo.getChildNodes().item(0).getNodeValue();
			}
		}catch(Exception ex){
			String resultado = ex.getMessage();
		}
		hc.disconnect();

	}

	public static String WSObtenerEstadoCuentaCliente(String clienteClave, Date fechaIni, Date fechaFin) throws Exception
	{
		String nombreArchivo = "";

		HttpURLConnection hc;
		ConfiguracionLocal config = (ConfiguracionLocal) Sesion.get(Campo.ConfiguracionLocal);


		SimpleDateFormat formato = new SimpleDateFormat("yyyy-MM-dd'T'HH:mm:ss'Z'");

		String message = "<soap:Envelope xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\" " +
				"xmlns:tem=\"http://tempuri.org/services/MobileClient\">" +
				"<soap:Body>" +
				"<WSObtenerEstadoCuentaCliente xmlns=\"http://tempuri.org/services/MobileClient\">" +
				"<parsClienteClave>" + clienteClave + "</parsClienteClave>" +
				"<pardFechaIni>" + formato.format(fechaIni) + "</pardFechaIni>" +
				"<pardFechaFin>" + Generales.getUltimaHora(fechaFin, "yyyy-MM-dd'T'HH:mm:ss'Z'") + "</pardFechaFin>" +
				"<refparsMensaje></refparsMensaje>" +
				"</WSObtenerEstadoCuentaCliente>" +
				"</soap:Body>" +
				"</soap:Envelope>";

		String url = Uri.withAppendedPath(Uri.parse(config.get(CampoConfiguracion.URL).toString()), "ServiceMobileClient.asmx").toString();

		hc = (HttpURLConnection) new URL(url).openConnection();
		/** Some web servers requires these properties */

		hc.setRequestMethod("POST");
		hc.setRequestProperty("SOAPAction", "http://tempuri.org/services/MobileClient/WSObtenerEstadoCuentaCliente");
		hc.setRequestProperty("User-Agent", "Profile/MIDP-1.0 Configuration/CLDC-1.0");
		hc.setRequestProperty("Content-Type", "text/xml;charset=utf-8");
		hc.setRequestProperty("Content-Length", Integer.toString(message.length()));
		hc.setRequestProperty("Connection", "close");
		hc.setConnectTimeout((Integer) config.get(CampoConfiguracion.TIMEOUT)); //multiplicar para convertir en milis
		hc.setAllowUserInteraction(true);
		hc.setDoOutput(true);
		hc.setDoInput(true);
		hc.setChunkedStreamingMode(0);
		OutputStream os = hc.getOutputStream();
		os.write(message.getBytes("UTF-8"));
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
			Node nodo = doc.getElementsByTagName("WSObtenerEstadoCuentaClienteResponse").item(0);
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
}