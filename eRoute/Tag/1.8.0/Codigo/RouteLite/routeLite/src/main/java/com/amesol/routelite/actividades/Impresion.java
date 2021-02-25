package com.amesol.routelite.actividades;

import java.io.DataOutputStream;
import java.io.File;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.OutputStream;
import java.net.InetSocketAddress;
import java.net.Socket;
import java.net.SocketAddress;
import java.util.Collections;
import java.util.HashMap;
import java.util.Map;

import android.app.Activity;
import android.bluetooth.BluetoothAdapter;
import android.bluetooth.BluetoothDevice;
import android.os.AsyncTask;

import com.amesol.routelite.datos.Cliente;
import com.amesol.routelite.datos.Ruta;
import com.amesol.routelite.datos.Usuario;
import com.amesol.routelite.datos.basedatos.BDVend;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.basedatos.Consultas.ConsultasImpresionTicket;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.ArchivoConfiguracion.CampoConfiguracion;
import com.amesol.routelite.datos.utilerias.ConfiguracionLocal;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.utilerias.ControlError;
import com.amesol.routelite.utilerias.Generales;
import com.amesol.routelite.vistas.PDFViewer;
import com.amesol.routelite.vistas.utilerias.Dispositivo;
import com.itextpdf.text.BaseColor;
import com.itextpdf.text.Font;

public class Impresion
{

	//ClienteActual
	private static Cliente oClienteAct;
	public Activity vistaActual;
	private String puerto_ip;

	//variables globales para usar en cada impresion
	//cuidar donde se inicializan y donde se terminan
	btPrintFile btPrintService = null;
	BluetoothAdapter btAdapter = null;
	BluetoothDevice device;
	String fileName = "";
	boolean intentosConexion[] =
	{ false };
	short numCopias = 0;
	boolean mostrarLogo = false;
	Short tipoPapel = 0;
	short reintentosOcultos = 0;
	boolean doorOpen = false;
	boolean desconexionManual = false;
	
	private static final String ESC = Character.toString((char) 27);

	//modoEncabezadoPie
	public final class ModoEncabezadoPie
	{
		private static final short ENCABEZADO = 1;
		private static final short PIE = 2;
	}

	//tipoPapel	
	public final class TipoPapel
	{
		public static final int CARTA = 12;
	}

	public final class TipoAlineacion
	{
		public final static short IZQUIERDA = 0;
		public final static short DERECHA = 1;
	}

	public final class BTIPALI
	{
		public final class TipoAlineacion
		{
			public final static short NO_DEFINIDO = 0;
			public final static short IZQUIERDA = 1;
			public final static short CENTRO = 2;
			public final static short DERECHA = 3;
		}
	}

	public final class TRECIBO
	{
		public final static String DEPOSITOS_MANUALES = "100";
	}

	private static final int REQUEST_BT_SETTINGS = 777;

	private static final String CAMPOS_PRELIQUIDACION_DEPOSITOS = "FechaPreliquidacion, FechaDeposito, TipoBanco, Referencia, Total, Ficha";
	private static final String CAMPOS_PRELIQUIDACION_NODEPOSITOS = "FechaPreliquidacion, TipoEfectivo, Total";

	//Tamaños default
	private static TamanioLetra tamanioDefault = new TamanioLetra(40, 82, 0);
	//Tamaño actual de letra
	private static TamanioLetra mTamanioTitulo = new TamanioLetra(40, 64, 0);
	private static TamanioLetra mTamanioSubTitulo = new TamanioLetra(40, 96, 0);
	
	private static TamanioLetra tamanioDefaultH = new TamanioLetra(40, 106, 0);
	//Tamaño actual de letra
	private static TamanioLetra mTamanioTituloH = new TamanioLetra(40, 80, 0);
	private static TamanioLetra mTamanioSubTituloH = new TamanioLetra(40, 122, 0);
	
	private static TamanioLetra mTamanioDetalle = new TamanioLetra(40, 112, 0);

	private static final Map<Integer, TamanioLetra> TAMANIOS_LETRA = llenarTamanios();

	private static Map<Integer, TamanioLetra> llenarTamanios()
	{
		Map<Integer, TamanioLetra> result = new HashMap<Integer, TamanioLetra>();
		//Extech Termica 2"
		result.put(1, new TamanioLetra(53, 48, 0));
		result.put(2, new TamanioLetra(52, 42, 0));
		result.put(3, new TamanioLetra(51, 38, 0));
		result.put(4, new TamanioLetra(50, 32, 0));
		result.put(5, new TamanioLetra(49, 24, 0));
		//Extech Termica 3"
		result.put(6, new TamanioLetra(53, 72, 0));
		result.put(7, new TamanioLetra(52, 64, 0));
		result.put(8, new TamanioLetra(51, 57, 0));
		result.put(9, new TamanioLetra(50, 48, 0));
		result.put(10, new TamanioLetra(49, 36, 0));
		//Extech Impacto 2"
		result.put(11, new TamanioLetra(14, 20, 0));
		result.put(12, new TamanioLetra(28, 40, 0));
		result.put(13, new TamanioLetra(0, 20, 0));
		result.put(14, new TamanioLetra(20, 40, 0));
		//Zebra Termica 2"
		result.put(15, new TamanioLetra(0, 48, 9));
		result.put(16, new TamanioLetra(1, 24, 9));
		result.put(17, new TamanioLetra(2, 48, 18));
		result.put(18, new TamanioLetra(3, 24, 28));
		result.put(19, new TamanioLetra(4, 12, 18));
		result.put(20, new TamanioLetra(5, 24, 36));
		result.put(21, new TamanioLetra(6, 12, 36));
		//Tec Termica 2"
		result.put(22, new TamanioLetra(0, 24, 0));
		result.put(23, new TamanioLetra(1, 32, 0));
		//Citizen CMP-10 2"
		result.put(24, new TamanioLetra(2, 32, 0));
		result.put(25, new TamanioLetra(16, 32, 0));
		result.put(26, new TamanioLetra(32, 16, 0));
		result.put(27, new TamanioLetra(48, 16, 0));
		result.put(28, new TamanioLetra(1, 42, 0));
		result.put(29, new TamanioLetra(17, 42, 0));
		result.put(30, new TamanioLetra(33, 21, 0));
		result.put(31, new TamanioLetra(49, 21, 0));
		//Zebra Cameo 2"
		result.put(32, new TamanioLetra(1, 22, 9));
		result.put(33, new TamanioLetra(2, 44, 18));
		result.put(34, new TamanioLetra(3, 22, 18));
		result.put(35, new TamanioLetra(4, 11, 18));
		result.put(36, new TamanioLetra(5, 22, 36));
		result.put(37, new TamanioLetra(6, 11, 36));
		//Star DP8340
		result.put(38, new TamanioLetra(0, 60, 0));
		//Intermec PR3
		result.put(39, new TamanioLetra(33, 57, 0));
		result.put(40, new TamanioLetra(16, 57, 1));
		result.put(41, new TamanioLetra(32, 26, 1));
		result.put(42, new TamanioLetra(48, 26, 1));
		//Intermec RP2
		result.put(48, new TamanioLetra(33, 38, 0));
		result.put(49, new TamanioLetra(16, 38, 1));
        //Sewoo
        result.put(51, new TamanioLetra(0, 32, 0));
        result.put(52, new TamanioLetra(1, 32, 0));
        result.put(53, new TamanioLetra(16, 16, 0));
        result.put(54, new TamanioLetra(32, 16, 0));

        //3" Zebra Termica
		result.put(55, new TamanioLetra(0, 48, 24));
		result.put(56, new TamanioLetra(1, 48, 48));

		//2" BIXOLON
		result.put(61, new TamanioLetra(0, 32, 0));
		result.put(62, new TamanioLetra(1, 42, 0));
		result.put(63, new TamanioLetra(2, 42, 0));


        return Collections.unmodifiableMap(result);
	}

	public static final int MESSAGE_STATE_CHANGE = 1;
	public static final int MESSAGE_READ = 2;
	public static final int MESSAGE_WRITE = 3;
	public static final int MESSAGE_DEVICE_NAME = 4;
	public static final int MESSAGE_TOAST = 5;

	public static final String TOAST = "toast";

	public Impresion(String puerto_ip){
		this.puerto_ip = puerto_ip;
	}
	
	/* Separar la impresion de los archivos generales en este nuevo metodo */
	public void imprimirArchivos(int idReporte, Activity vista, short numeroCopias) throws Exception
	{
		String reporte = "";
		vistaActual = vista; 
		
		ConfiguracionLocal conf = (ConfiguracionLocal) Sesion.get(Campo.ConfiguracionLocal);
		File impresion = new File(conf.get(CampoConfiguracion.DIRECTORIO_TRABAJO).toString());
		impresion = new File(impresion, "impresionCarta");
		if (!impresion.exists())
		{
			if (!impresion.mkdirs())
			{
				//TODO Paula, crear mensaje, E0690 provisional
				throw new ControlError("E0690", impresion.getAbsolutePath());
			}
		}

		//Limpiar el directorio de impresion			
		if (impresion.isDirectory())
		{
			File[] files = impresion.listFiles();
			if (files != null)
			{
				for (File f : files)
				{
					f.delete();
				}
			}
		}
		boolean imprimeLogo = true;
		String[] byRefMsgError =
		{ "" }; 
		reporte = generarArchivoReporteCarta(idReporte, impresion.getAbsolutePath(), imprimeLogo, byRefMsgError);

		if (reporte != null && !reporte.isEmpty())
		{
			/* Se crea el archivo */
			File archivo = new File(impresion, "Reporte"+idReporte);
			OutputStream stream = new FileOutputStream(archivo);
			stream.write(reporte.getBytes());
			stream.flush();
			stream.close();
			/* Se lleva a cabo la impresion */
			Print(reporte, numeroCopias);
		}	
	}
	
	void Print(String reporte, short noCopias){
		new AsyncTaskImpresion().execute(reporte);
	}
	
	private class AsyncTaskImpresion extends AsyncTask<String, Void, Exception>{

		@Override
		protected void onPreExecute()
		{
			if(vistaActual != null){
				if(vistaActual instanceof PDFViewer){
					((PDFViewer)vistaActual).mostrarProgreso(Mensajes.get("XImpresion"));
					ConfiguracionLocal conf = (ConfiguracionLocal) Sesion.get(Campo.ConfiguracionLocal);
					if (Boolean.parseBoolean(conf.get(CampoConfiguracion.WIFI).toString()))
					{
						try
						{
							Dispositivo.EncenderApagarWiFi(vistaActual.getApplicationContext(), true, 1);
						}
						catch (Exception e)
						{
							cancel(true);
						}
					}
				}
			}
		}
		
		@Override
		protected Exception doInBackground(String... params)
		{
			if(!isCancelled()){
				Socket clientSocket = null;
				SocketAddress address = new InetSocketAddress(puerto_ip, 9100);
				try {
				    clientSocket = new Socket();
				    clientSocket.connect(address, 10000);// 10 segundos para intentar abrir el socket
				} catch (Exception e) {
				    return e;
				}
	
				try {
				    DataOutputStream os = new DataOutputStream(clientSocket.getOutputStream());
				    String cadena = params[0].replace('ñ', 'n')
				    		.replace('Ñ', 'N')
				    		.replace('ó', 'o')
				    		.replace('Ó', 'O')
				    		.replace('á', 'a')
				    		.replace('Á', 'A')
				    		.replace('é', 'e')
				    		.replace('É', 'E')
				    		.replace('í', 'i')
				    		.replace('Í', 'I')
				    		.replace('ú', 'u')
				    		.replace('Ú', 'U');
				    os.write(cadena.getBytes());
				    os.flush();
				} catch (Exception e){
					return e;
				} finally {
				    try {
				    	if(clientSocket != null)
				    		clientSocket.close();
				    } catch (IOException e) {
				        e.printStackTrace();
				    }
				}
			}
			return null;
		}
		
		@Override
		protected void onPostExecute(Exception result)
		{
			if(vistaActual != null){
				if(vistaActual instanceof PDFViewer){
					((PDFViewer)vistaActual).quitarProgreso();
					String mensaje = Mensajes.get("I0001");
					if(result != null){
						mensaje = Mensajes.get("E0059") + "\n" + result.getMessage();
					}
					((PDFViewer)vistaActual).mostrarMensaje(mensaje);
					ConfiguracionLocal conf = (ConfiguracionLocal) Sesion.get(Campo.ConfiguracionLocal);
					if (Boolean.parseBoolean(conf.get(CampoConfiguracion.WIFI).toString()))
					{
						try
						{
							Dispositivo.EncenderApagarWiFi(vistaActual.getApplicationContext(), false, 1);
						}
						catch (Exception e)
						{}
					}
				}
			}
		}
		
		@Override
		protected void onCancelled(Exception result)
		{
			if(vistaActual != null)
				if(vistaActual instanceof PDFViewer){
					((PDFViewer)vistaActual).quitarProgreso();
					((PDFViewer)vistaActual).mostrarMensaje(Mensajes.get("F0008"));
				}
		}
		
	}

//	void BluetoothPrint(IVista vista, String nombreArchivo, Short nTipoPapel, boolean bMostrarLogo, short numeroCopias) throws Exception
//	{
//		vistaActual = vista;
//		fileName = nombreArchivo;
//		numCopias = numeroCopias;
//		mostrarLogo = bMostrarLogo;
//		tipoPapel = nTipoPapel;
//
//		reintentosOcultos = 0;
//		try
//		{
//
//			btAdapter = BluetoothAdapter.getDefaultAdapter();
//			if (btAdapter == null)
//			{
//				throw new Exception("Bluetooth no soportado");
//			}
//
//			if (!btAdapter.isEnabled())
//			{
//				throw new Exception("El Bluetooth no esta encendido");
//			}
//			if (btPrintService == null)
//				setupComm(vista);
//
//			ConfiguracionLocal config = (ConfiguracionLocal) Sesion.get(Campo.ConfiguracionLocal);
//			String puerto = (String) config.get(CampoConfiguracion.PUERTO + "_" + tipoPapel);
//
//			if (puerto == null)
//			{
//				throw new Exception(Mensajes.get("E0708"));
//			}
//
//			String remote = puerto;
//			if (remote.length() == 0)
//				return;
//
//			String sMacAddr = puerto.split("_")[0];
//			;
//
//			try
//			{
//				device = btAdapter.getRemoteDevice(sMacAddr);
//			}
//			catch (Exception e)
//			{
//				throw new Exception(Mensajes.get("E0708"));
//			}
//
//			if (device != null)
//			{
//				while (device.getBondState() != BluetoothDevice.BOND_BONDED)
//				{
//					Method m = device.getClass()
//							.getMethod("createBond", (Class[]) null);
//					m.invoke(device, (Object[]) null);
//
//					Thread.sleep(3000);
//				}
//
//				intentosConexion[0] = true;
//				btPrintService.connect(device);
//			}
//			else
//			{
//				throw new Exception("Verifique que la impresora este encendida");
//			}
//
//			//addLog(String.format("printed " + totalWrite.toString() + " bytes"));
//		}
//		catch (IOException e)
//		{
//			throw new Exception("Impresión fallida");
//		}
//		catch (Exception e)
//		{
//			throw new Exception(e.getMessage());
//		}
//		finally
//		{
//			/*
//			 * if (inStream != null) { try { inStream.close(); inStream = null;
//			 * } catch (IOException e) { } }
//			 */
//
//			/*
//			 * if (btPrintService.getState() == btPrintFile.STATE_CONNECTED) {
//			 * btPrintService.stop();
//			 * //setConnectState(btPrintFile.STATE_DISCONNECTED); return; }
//			 */
//		}
//		return;
//	}//BluetoothPrint() 

	void connectToDevice(BluetoothDevice _device, btPrintFile btPrintService) throws Exception
	{
		if (_device != null)
		{
			btPrintService.connect(_device);
		}
		else
		{
			throw new Exception("Verifique que la impresora este encendida");
		}
	}

//	private void setupComm(IVista vista) throws Exception
//	{
//		// Initialize the array adapter for the conversation thread
//		//mConversationArrayAdapter = new ArrayAdapter<String>(this, R.id.remote_device);
//		//Log.d(TAG, "setupComm()");
//		btPrintService = new btPrintFile((Activity) vista, mHandler);
//		if (btPrintService == null)
//			throw new Exception("Inicializacion del puerto fallida");
//	}

//	private void iniciarImpresion() throws Exception
//	{
//		intentosConexion[0] = false;
//		if (btPrintService.getState() != btPrintFile.STATE_CONNECTED)
//		{
//			// myToast("Please connect first!", "Error");
//			return; //does not match file pattern for a print file
//		}
//
//		try
//		{
//
//			for (int i = 0; i < numCopias; i++)
//			{
//
//				/*
//				 * InputStream inputStream = null; ByteArrayInputStream
//				 * byteArrayInputStream; //[4] Integer totalWrite = 0;
//				 * StringBuffer sb = new StringBuffer(); try { if (vistaActual
//				 * == null) return; inputStream = new
//				 * FileInputStream(fileName);/
//				 * /((Activity)vistaActual).getAssets().open(fileName); //[5]
//				 * 
//				 * byte[] buf = new byte[2048]; int readCount = 0; do {
//				 * readCount = inputStream.read(buf); if (readCount > 0) {
//				 * totalWrite += readCount; byte[] bufOut = new byte[readCount];
//				 * System.arraycopy(buf, 0, bufOut, 0, readCount);
//				 * btPrintService.write(bufOut); } } while (readCount > 0);
//				 * //[6] inputStream.close(); //addLog(String.format("printed "
//				 * + totalWrite.toString() + " bytes")); } catch (IOException e)
//				 * { Log.e("nada", "Exception in printFile: " + e.getMessage());
//				 * //addLog("printing failed!"); //Toast.makeText(this,
//				 * "printing failed!", Toast.LENGTH_LONG);
//				 * //myToast("Printing failed","Error"); }
//				 * 
//				 * }
//				 */
//
//				FileInputStream fstream = new FileInputStream(fileName);
//				// Get the object of DataInputStream
//				DataInputStream in = new DataInputStream(fstream);
//				BufferedReader br = new BufferedReader(new InputStreamReader(in));
//				String strLine;
//				ByteArrayOutputStream buffer = new ByteArrayOutputStream();
//				//byte[] buffer;
//				//Read File Line By Line
//				String saltoLinea = "\r\n";
//				while ((strLine = br.readLine()) != null)
//				{
//					if (strLine.equalsIgnoreCase("IMPRIME_LOGO"))
//					{
//						if (mostrarLogo)
//						{
//							if (tipoPapel == TipoPapel.EXTECH_TERMICA2 || tipoPapel == TipoPapel.EXTECH_TERMICA3)
//							{
//								buffer.write(new byte[]
//								{ 27, 76, 103, 48 });
//							}
//							else if (tipoPapel == TipoPapel.INTERMEC_PR2 || tipoPapel == TipoPapel.INTERMEC_PR3)
//							{
//								buffer.write(new byte[]
//								{ 27, 69, 90 });
//
//								String sImagen = "{PRINT:@0,170:ALOGO,HMULT1,VMULT1|}";
//								sImagen += "{LP}";
//								buffer.write(sImagen.getBytes());
//							}
//						}
//					}
//					else if (strLine.startsWith("{"))
//					{
//						if (tipoPapel == TipoPapel.EXTECH_TERMICA2 || tipoPapel == TipoPapel.EXTECH_TERMICA3)
//						{
//							buffer.write(new byte[]
//							{ 27, 107, Byte.parseByte(strLine.substring(1, strLine.indexOf("}"))) });
//						}
//						else if (tipoPapel == TipoPapel.INTERMEC_PR2 || tipoPapel == TipoPapel.INTERMEC_PR3)
//						{
//							//buffer.write(new byte[]{27,119,Byte.parseByte(strLine.substring(1, strLine.indexOf("}")))});
//							//buffer.write(new byte[]{27,33,16});
//							buffer.write(new byte[]
//							{ Byte.parseByte(strLine.substring(1, strLine.indexOf("}")).split(",")[0]), Byte.parseByte(strLine.substring(1, strLine.indexOf("}")).split(",")[1]), Byte.parseByte(strLine.substring(1, strLine.indexOf("}")).split(",")[2]) });
//						}
//
//						if (strLine.indexOf("}") + 1 != strLine.length())
//						{
//							buffer.write(strLine.substring(strLine.indexOf("}") + 1, strLine.length()).getBytes());
//						}
//					}
//					else
//					{
//						buffer.write(strLine.getBytes());
//					}
//					buffer.write(saltoLinea.getBytes());
//				}
//				//Close the input stream
//				in.close();
//
//				btPrintService.write(buffer.toByteArray());
//				Thread.sleep(2000);
//			}
//
//			//archivosAImprimir.remove(archivo);
//			//if(archivosAImprimir.isEmpty())
//			//{
//			if (vistaActual != null)
//			{
//				vistaActual.impresionFinalizada(true, "");
//				//}
//			}
//
//		}
//		catch (Exception ex)
//		{
//			throw ex;
//		}
//		finally
//		{
//
//			if (btPrintService.getState() == btPrintFile.STATE_CONNECTED)
//			{
//				desconexionManual = true;
//				btPrintService.stop();
//				return;
//			}
//
//		}
//	}

	private static String completaColumna(String texto, int anchoColumna, int alineacion, int separador, int tipoFormato)
	{
		String resCadena = texto;
		switch (tipoFormato)
		{
			case 1:
				resCadena = Generales.getFormatoDecimal(Double.parseDouble(resCadena), "#,##0");
				break;
			case 2:
				resCadena = Generales.getFormatoDecimal(Double.parseDouble(resCadena), "#,##0.00");
		}
		if (resCadena.length() > anchoColumna)
		{
			resCadena = resCadena.substring(0, anchoColumna);
		}
		int tamanioSeparador = 0;
		if (separador != 0)
		{
			tamanioSeparador = ValoresReferencia.getDescripcion("SEPARADO", Integer.toString(separador)).length();
		}

		if (alineacion == 0 || alineacion == 1)
		{
			int totalAncho = anchoColumna + tamanioSeparador;
			resCadena = String.format("%-" + totalAncho + "s", resCadena);
		}
		else if (alineacion == 2)
		{
			long tamanioIzquierdo = Math.round(Math.ceil(((anchoColumna + tamanioSeparador) - resCadena.length()) / 2));
			long tamanioDerecho = Math.round(Math.floor(((anchoColumna + tamanioSeparador) - resCadena.length()) / 2));
			long totalAncho = resCadena.length() + tamanioIzquierdo;
			resCadena = String.format("%-" + totalAncho + "s", resCadena);
			totalAncho = resCadena.length() + tamanioDerecho;
			resCadena = String.format("%" + totalAncho + "s", resCadena);
		}
		else if (alineacion == 3)
		{
			int totalAncho = anchoColumna + tamanioSeparador;
			resCadena = String.format("%" + totalAncho + "s", resCadena);
		}
		return resCadena;
	}

	public static String completaHasta(String texto, int espacios, short tipoAlineacion, boolean ultimaColumna)
	{
		String res = "";
		if (texto.length() >= espacios)
		{
			if (ultimaColumna)
			{
				return texto.substring(0, espacios);
			}
			else
			{
				return texto.substring(0, espacios - 1) + " ";
			}
		}
		else
		{
			if (tipoAlineacion == TipoAlineacion.IZQUIERDA)
			{
				return String.format("%-" + espacios + "s", texto);
				//return String.format("%" + (texto.length() + espacios) + "s", texto);
			}
			else if (tipoAlineacion == TipoAlineacion.DERECHA)
			{
				return String.format("%" + espacios + "s", texto);
				//return String.format("%-" + (texto.length() + espacios) + "s", texto);
			}
		}
		return res;
	}

	private static String agregarEspaciosColumna(int tipoEspacio, String texto, int cantidadEspacio)
	{
		if (cantidadEspacio > 0)
		{
			int longTotal = texto.length() + cantidadEspacio;
			switch (tipoEspacio)
			{
				case 1: //Antes
					return String.format("%" + longTotal + "s", texto);
				case 2: //Despues
					return String.format("%-" + longTotal + "s", texto);
				case 3: //Ambos
					texto = String.format("%" + longTotal + "s", texto);
					return String.format("%-" + longTotal + "s", texto);
			}
		}
		return texto;
	}

	private static String completaColumna(String texto, int anchoColumna)
	{
		int longTexto = texto.length();
		if (longTexto >= anchoColumna)
		{
			return texto.substring(0, anchoColumna);
		}
		else
		{

			return String.format("%-" + anchoColumna + "s", texto);
		}
	}

	private static String alineaTexto(short tipoAlineacion, String texto, int longTotal)
	{
		switch (tipoAlineacion)
		{
			case 2:
				return textoCentrado(texto, longTotal);
			case 3:
				return textoDerecha(texto, longTotal);
		}

		return texto;
	}

	private static String textoCentrado(String texto, int longTotal)
	{
		String espacios = "";
		int tamTexto = texto.length();

		for (int i = 1; i < Math.round((longTotal - tamTexto) / 2); i++)
		{
			espacios = espacios.concat(" ");
		}
		return espacios.concat(texto);
	}

	private static String textoDerecha(String texto, int longTotal)
	{
		String espacios = "";

		for (int i = 1; i < longTotal - texto.length(); i++)
		{
			espacios = espacios.concat(" ");
		}
		return espacios.concat(texto);
	}

	private static class TamanioLetra
	{
		public int mTamanio;
		public int mLongTotal;
		public int mAlto;

		public TamanioLetra(int tamanio, int longTotal, int alto)
		{
			mTamanio = tamanio;
			mLongTotal = longTotal;
			mAlto = alto;
		}
	}

	private static String generarArchivoReporteCarta(int reporte, String directorioArchivo, boolean imprimeLogo, String[] byRefMsgError) throws Exception
	{
		StringBuilder cadenaRecibo = new StringBuilder();
		try
		{
			switch (reporte)
			{
			//resumen movimientos costeña
				case 2:
					generarReporteInventarioCosteña(reporte, cadenaRecibo);
					break;
				case 5:
					generarReportePedidosPreventa(reporte, cadenaRecibo);
					break;
			}

		}
		catch (Exception ex)
		{
			throw new Exception("Error al generar ticket:" + ex.getMessage());
		}
		return cadenaRecibo.toString();
	}

	/*
	 * private static Font catFont = new Font(Font.FontFamily.TIMES_ROMAN,
	 * 18,Font.BOLD); private static Font redFont = new
	 * Font(Font.FontFamily.TIMES_ROMAN, 12,Font.NORMAL, BaseColor.RED); private
	 * static Font subFont = new Font(Font.FontFamily.TIMES_ROMAN,
	 * 16,Font.BOLD); private static Font smallBold = new
	 * Font(Font.FontFamily.TIMES_ROMAN, 12,Font.BOLD); private static Font
	 * smallFont = new Font(Font.FontFamily.TIMES_ROMAN, 12,Font.NORMAL);
	 */

	private static Font tituloRojo = new Font(Font.FontFamily.COURIER, 22, Font.BOLD, BaseColor.RED);
	private static Font textoNegrita = new Font(Font.FontFamily.COURIER, 17, Font.BOLD);
	
	private static void generarReporteInventarioCosteña(int reporte, StringBuilder cadenaRecibo) throws Exception{
		String cadena = null;
		String texto = null;
		int columna = 20;
		int max = 60;
		ISetDatos idataRuta = Consultas.ConsultasRuta.obtenerRutas();
		idataRuta.moveToFirst();
		Ruta ruta = new Ruta();
		ruta.RUTClave = idataRuta.getString("RUTClave");
		BDVend.recuperar(ruta);
		idataRuta.close();
		
		TamanioLetra tamanioLetra;
		tamanioLetra = tamanioDefault;
		
		ISetDatos encabezado = ConsultasImpresionTicket.obtenerEncabezado();
		encabezado.moveToFirst();
		
		
//		cadenaRecibo.append(ESC + "(8U");
		/* Comando PLC para modificar el estilo */
		cadenaRecibo.append(ESC + "(s0p10h12v0s3B");
		
		texto = encabezado.getString("NombreEmpresa");
		cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, tamanioLetra.mLongTotal);
		cadenaRecibo.append(cadena + "\r\n");

		texto = encabezado.getString("RFC");
		cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, tamanioLetra.mLongTotal);
		cadenaRecibo.append(cadena + "\r\n");
		cadenaRecibo.append("\r\n");
		
		encabezado.close();
		
		tamanioLetra = mTamanioTitulo;
		
		cadenaRecibo.append(ESC + "(s0p8h14v0s7B");
		
		texto = ValoresReferencia.getDescripcion("REPORTEA", String.valueOf(reporte));
		cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, tamanioLetra.mLongTotal);	
		
		cadenaRecibo.append(cadena + "\r\n");
		cadenaRecibo.append("\r\n");
		
		cadenaRecibo.append(ESC + "(s0p12h10v0s3B");
		
		tamanioLetra = mTamanioSubTitulo;
				
		texto = Mensajes.get("XImpresion") + ": " + Generales.getFechaHoraActualStr("dd/MM/yyyy hh:mm:ss");
		cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, tamanioLetra.mLongTotal);
		cadenaRecibo.append(cadena + "\r\n");		
		
		texto = Mensajes.get("XRuta") + ": " + ruta.RUTClave;
		cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, tamanioLetra.mLongTotal);
		cadenaRecibo.append(cadena + "\r\n");
//		cadenaRecibo.append("\r\n");
		
		texto = Mensajes.get("XVendedor") + ": " + ((Usuario) Sesion.get(Campo.UsuarioActual)).Nombre;
		cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, tamanioLetra.mLongTotal);
		cadenaRecibo.append(cadena + "\r\n");
		
		texto = "% ".concat(Mensajes.get("XTotalMin") + " ").concat(Mensajes.get("XCaducos")).concat(" = XCADX");
		cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, tamanioLetra.mLongTotal);
		cadenaRecibo.append(cadena + "\r\n");
		cadenaRecibo.append("\r\n");
		
		cadenaRecibo.append(ESC + "(s0p14h8v0s3B");
		
		tamanioLetra = mTamanioDetalle;
		
		/* Encabezado Linea 1 */
		texto = Mensajes.get("XCodigo");
		cadena = completaHasta(texto, 8, TipoAlineacion.IZQUIERDA, false);
		texto = Mensajes.get("XDescripcion");
		cadena+= completaHasta(texto, 38, TipoAlineacion.IZQUIERDA, false);
		texto = Mensajes.get("XEmpaque");
		cadena+= completaHasta(texto, 12, TipoAlineacion.IZQUIERDA, true);
		
//		cadenaRecibo.append(cadena + "\r\n");
		cadenaRecibo.append(cadena);
		
		/* Encabezado Linea 2 */
		texto = Mensajes.get("XInventarioInicial");
		cadena = completaHasta(texto, 5, TipoAlineacion.IZQUIERDA, false);
		texto = Mensajes.get("XVta");
		cadena+= completaHasta(texto, 5, TipoAlineacion.IZQUIERDA, false);
		texto = Mensajes.get("XInventarioBueno");
		cadena+= completaHasta(texto, 5, TipoAlineacion.IZQUIERDA, false);
		texto = Mensajes.get("XInventarioMalo");
		cadena+= completaHasta(texto, 5, TipoAlineacion.IZQUIERDA, false);
		texto = Mensajes.get("XInventarioFrio");
		cadena+= completaHasta(texto, 5, TipoAlineacion.IZQUIERDA, false);
		texto = Mensajes.get("XInventarioTotal");
		cadena+= completaHasta(texto, 5, TipoAlineacion.IZQUIERDA, false);
		texto = Mensajes.get("XPrecio");
		cadena+= completaHasta(texto, 8, TipoAlineacion.IZQUIERDA, false);
		texto = Mensajes.get("XImpuesto");
		cadena+= completaHasta(texto, 8, TipoAlineacion.IZQUIERDA, false);
		texto = Mensajes.get("XImporte");
		cadena+= completaHasta(texto, 8, TipoAlineacion.IZQUIERDA, true);
		
		cadenaRecibo.append(cadena + "\r\n");
		cadenaRecibo.append("\r\n");
		
		cadenaRecibo.append(ESC + "(s0p14h8v0s0B");
		
		ISetDatos info;
		float totales[] = new float[9];
		String keys[] = new String[]{
				"II", "Vta", "IB", "IM", "IF", "IT", "Precio", "Imp", "Importe"
		};
		float temp, totalCost=0, totalTotis=0, porcMalosCost=0, porcMalosTotis=0, porcFriosTotis=0;
		
		info = Consultas.ConsultasInventario.obtenerInventarioParaReporte();
		/* Agrega los productos */
		while(info.moveToNext()){
			cadena = completaHasta(info.getString(0), 8, TipoAlineacion.IZQUIERDA, false);
			cadena+= completaHasta(info.getString(1), 38, TipoAlineacion.IZQUIERDA, false);
			texto = ValoresReferencia.getDescripcion("UNIDADV", info.getString(2));
			cadena+= completaHasta(texto, 12, TipoAlineacion.IZQUIERDA, true);
			
//			cadenaRecibo.append(cadena + "\r\n");
			cadenaRecibo.append(cadena);
			cadena = "";
			for(int col = 0; col < totales.length; col++){
				if(col >= 0 && col <= 4){
					temp = info.getFloat(keys[col]);
					texto = Generales.getFormatoDecimal(temp, 0);
					cadena+= completaHasta(texto, 5, TipoAlineacion.IZQUIERDA, false);
					totales[col]+= temp;
				}else if(col == 5){
					temp = info.getFloat(keys[2]) + info.getFloat(keys[3]) + info.getFloat(keys[4]);
					texto = Generales.getFormatoDecimal(temp, 0);
					cadena+= completaHasta(texto, 5, TipoAlineacion.IZQUIERDA, false);
					totales[col]+= temp;
				}else if(col == totales.length -1){
					temp = info.getFloat(keys[1]) * info.getFloat(keys[6]) + info.getFloat(keys[7]);
					texto = Generales.getFormatoDecimal(temp, 2);
					cadena+= completaHasta(texto, 8, TipoAlineacion.IZQUIERDA, true);
					totales[col]+= temp;
				}else{
					temp = info.getFloat(keys[col]);
					texto = Generales.getFormatoDecimal(temp, 2);
					cadena+= completaHasta(texto, 8, TipoAlineacion.IZQUIERDA, false);
				}
			}
			cadenaRecibo.append(cadena + "\r\n");
		}
		info.close();
		cadenaRecibo.append("\r\n");
		
		tamanioLetra = mTamanioDetalle;
		cadenaRecibo.append(ESC + "(s0p14h8v0s3B");
		
		cadena = completaHasta(Mensajes.get("XTOTALES") + ":", 58, TipoAlineacion.IZQUIERDA, false);
		
		/* Agrega totales */
		texto = Generales.getFormatoDecimal(totales[0], 0);
		cadena+= completaHasta(texto, 5, TipoAlineacion.IZQUIERDA, false);
		texto = Generales.getFormatoDecimal(totales[1], 0);
		cadena+= completaHasta(texto, 5, TipoAlineacion.IZQUIERDA, false);
		texto = Generales.getFormatoDecimal(totales[2], 0);
		cadena+= completaHasta(texto, 5, TipoAlineacion.IZQUIERDA, false);
		texto = Generales.getFormatoDecimal(totales[3], 0);
		cadena+= completaHasta(texto, 5, TipoAlineacion.IZQUIERDA, false);
		texto = Generales.getFormatoDecimal(totales[4], 0);
		cadena+= completaHasta(texto, 5, TipoAlineacion.IZQUIERDA, false);
		texto = Generales.getFormatoDecimal(totales[5], 0);
		cadena+= completaHasta(texto, 5, TipoAlineacion.IZQUIERDA, false);
		
		cadenaRecibo.append(cadena+"\r\n");
		
		cadenaRecibo.append("\r\n");
		
		/* Total ventas */
		cadena = (Mensajes.get("XTotalVentas") + ": ").replace("$0$", "");
		texto = "$" + Generales.getFormatoDecimal(totales[8], "#,###,##0.00");
		texto = completaHasta(texto, (max - cadena.length()) + columna, TipoAlineacion.DERECHA, true);
		
		cadenaRecibo.append(cadena + texto + "\r\n");
//		cadenaRecibo.append("\r\n");
		
		/* Total cobranza */
		temp = Consultas.ConsultasAbono.obtenerTotalCobranza();
		cadena = (Mensajes.get("XTOTALCOBRANZA") + ": ").replace("$0$", "");
		texto = "$" + Generales.getFormatoDecimal(temp, "#,###,##0.00");
		texto = completaHasta(texto, (max - cadena.length()) + columna, TipoAlineacion.DERECHA, true);
		cadenaRecibo.append(cadena + texto + "\r\n");
//		cadenaRecibo.append("\r\n");
		
		/* Total pedidos posfechados */
		temp = Consultas.ConsultasTransProd.obtenerTotalPedidosPosfechados();
		cadena = Mensajes.get("XTotalPedidos").replace("$0$", Mensajes.get("XPosfechados")) + ":";
		texto = "$" + Generales.getFormatoDecimal(temp, "#,###,##0.00");
		texto = completaHasta(texto, (max - cadena.length()) + columna, TipoAlineacion.DERECHA, true);
		cadenaRecibo.append(cadena + texto + "\r\n");
//		cadenaRecibo.append("\r\n");
		
		info = Consultas.ConsultasTransProd.obtenerTotalPedidosCostena(Short.parseShort("1"), "2",false);
		
		/* Agrega las categorias */
		String clasificacion;
		while(info.moveToNext()){
			cadena = Mensajes.get("XTotalVentas") + " ";
			clasificacion = info.getString("Clasificacion");
			clasificacion = clasificacion != null ? clasificacion : "";
			cadena+= ValoresReferencia.getDescripcion("CESQUEMA", clasificacion) + ":";
			texto = "$" + Generales.getFormatoDecimal(info.getFloat("Total"), "#,###,##0.00");
			texto = completaHasta(texto, (max - cadena.length()) + columna, TipoAlineacion.DERECHA, true);
			
			cadenaRecibo.append(cadena + texto + "\r\n");
//			cadenaRecibo.append("\r\n");
	
			if("5".equals(clasificacion))
				totalTotis = info.getFloat("Total");
			else if("4".equals(clasificacion))
				totalCost = info.getFloat("Total");
		}
		info.close();
		
		/* Total Malos la costeña */
		temp = Consultas.ConsultasInventario.obtenerTotalProductosPorEsquemaClasificacionYTipoMotivo(4, 200, 210);
		porcMalosCost = (temp / totalCost) * 100;
		cadena = Mensajes.get("XTotalMalos") + " " + ValoresReferencia.getDescripcion("CESQUEMA", "4") + ":";
		texto = "$" + Generales.getFormatoDecimal(temp, "#,###,##0.00");
		texto = completaHasta(texto, (max - cadena.length()) + columna, TipoAlineacion.DERECHA, true);
		
		cadenaRecibo.append(cadena + texto + "\r\n");
//		cadenaRecibo.append("\r\n");
			
		/* Total Malos totis */
		temp = Consultas.ConsultasInventario.obtenerTotalProductosPorEsquemaClasificacionYTipoMotivo(5, 200, 210);
		porcMalosTotis = (temp / totalTotis) * 100;
		
		/* Agregar el total del titulo */
		int start = cadenaRecibo.indexOf("XCADX");
		cadenaRecibo.replace(start, start + "XCADX".length(), Generales.getFormatoDecimal(Float.isNaN(porcMalosTotis) || Float.isInfinite(porcMalosTotis) ? 0:porcMalosTotis, "#,###,##0.00"));
		/**********************/
		
		cadena = Mensajes.get("XTotalMalos") + " " + ValoresReferencia.getDescripcion("CESQUEMA", "5") + ":";
		texto = "$" + Generales.getFormatoDecimal(temp, "#,###,##0.00");
		texto = completaHasta(texto, (max - cadena.length()) + columna, TipoAlineacion.DERECHA, true);
		
		cadenaRecibo.append(cadena + texto + "\r\n");
//		cadenaRecibo.append("\r\n");
		
		/* Total Frios totis */
		temp = Consultas.ConsultasInventario.obtenerTotalProductosPorEsquemaClasificacionYTipoMotivo(5, 211);
		porcFriosTotis = (temp / totalTotis) * 100;
		cadena = Mensajes.get("XTotalFrios") + " " + ValoresReferencia.getDescripcion("CESQUEMA", "5") + ":";
		texto = "$" + Generales.getFormatoDecimal(temp, "#,###,##0.00");
		texto = completaHasta(texto, (max - cadena.length()) + columna, TipoAlineacion.DERECHA, true);
		
		cadenaRecibo.append(cadena + texto + "\r\n");
//		cadenaRecibo.append("\r\n");
		
		/* Porcentaje malos la costeña */
		cadena = Mensajes.get("XPorcentajeMalos") + " ";
		cadena+= ValoresReferencia.getDescripcion("CESQUEMA", "4") + ":";
		texto = Generales.getFormatoDecimal(Float.isNaN(porcMalosCost) || Float.isInfinite(porcMalosCost) ? 0:porcMalosCost, "#,###,##0.00") + "%";
		texto = completaHasta(texto, (max - cadena.length()) + columna, TipoAlineacion.DERECHA, true);
		
		cadenaRecibo.append(cadena + texto + "\r\n");
//		cadenaRecibo.append("\r\n");
		
		/* Porcentaje malos totis */
		cadena = Mensajes.get("XPorcentajeMalos") + " ";
		cadena+= ValoresReferencia.getDescripcion("CESQUEMA", "5")+ ":";
		texto = Generales.getFormatoDecimal(Float.isNaN(porcMalosTotis) || Float.isInfinite(porcMalosTotis) ? 0:porcMalosTotis, "#,###,##0.00") + "%";
		texto = completaHasta(texto, (max - cadena.length()) + columna, TipoAlineacion.DERECHA, true);
		
		cadenaRecibo.append(cadena + texto + "\r\n");
//		cadenaRecibo.append("\r\n");
			
		/* Porcentaje Frios totis */
		cadena = Mensajes.get("XPorcentajeFrios") + " ";
		cadena+= ValoresReferencia.getDescripcion("CESQUEMA", "5")+ ":";
		texto = Generales.getFormatoDecimal(Float.isNaN(porcFriosTotis)  || Float.isInfinite(porcFriosTotis) ? 0:porcFriosTotis, "#,###,##0.00") + "%";
		texto = completaHasta(texto, (max - cadena.length()) + columna, TipoAlineacion.DERECHA, true);
		
		cadenaRecibo.append(cadena + texto + "\r\n");
//		cadenaRecibo.append("\r\n");
		
		/* Total cajas la costeña */
		temp = Consultas.ConsultasInventario.obtenerTotalCajasVendidasPorEsquemaClasificacion("4");
		cadena = Mensajes.get("XTotalCajas") + " " + ValoresReferencia.getDescripcion("CESQUEMA", "4") + ":";
		texto = Generales.getFormatoDecimal(temp, "#,###,##0.00");
		texto = completaHasta(texto, (max - cadena.length()) + columna, TipoAlineacion.DERECHA, true);
		
		cadenaRecibo.append(cadena + texto + "\r\n");
//		cadenaRecibo.append("\r\n");
		
		/* Total cajas totis */
		temp = Consultas.ConsultasInventario.obtenerTotalCajasVendidasPorEsquemaClasificacion("5");
		cadena = Mensajes.get("XTotalCajas") + " " + ValoresReferencia.getDescripcion("CESQUEMA", "5") + ":";
		texto = Generales.getFormatoDecimal(temp, "#,###,##0.00");
		texto = completaHasta(texto, (max - cadena.length()) + columna, TipoAlineacion.DERECHA, true);
		
		cadenaRecibo.append(cadena + texto + "\r\n");
		cadenaRecibo.append("\r\n");
		
		tamanioLetra = tamanioDefault;
		cadenaRecibo.append(ESC + "(s0p10h12v0s3B");
		
		/* Firmas */
		cadenaRecibo.append("\r\n");
		cadenaRecibo.append("\r\n");
		cadenaRecibo.append("\r\n");
		
		texto = "________________________                ________________________";
		cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, tamanioLetra.mLongTotal);
		cadenaRecibo.append(cadena + "\r\n");		
		
		cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, Mensajes.get("XAlmacen").
				concat("                                ").concat(Mensajes.get("XVendedor")), tamanioLetra.mLongTotal);
		cadenaRecibo.append(cadena + "\r\n");		
	}
	
	private static void generarReportePedidosPreventa(int reporte, StringBuilder cadenaRecibo) throws Exception
	{
		String cadena = "";
		String texto = "";
		int columna = 10;
		int max = 40;
		ISetDatos idataRuta = Consultas.ConsultasRuta.obtenerRutas();
		idataRuta.moveToFirst();
		Ruta ruta = new Ruta();
		ruta.RUTClave = idataRuta.getString("RUTClave");
		BDVend.recuperar(ruta);
		idataRuta.close();
		
		TamanioLetra tamanioLetra;
		tamanioLetra = tamanioDefaultH;
		
		/* Mover la orientacion */
		cadenaRecibo.append(ESC + "&a90P");
		
		ISetDatos encabezado = ConsultasImpresionTicket.obtenerEncabezado();
		encabezado.moveToFirst();
		
		cadenaRecibo.append(ESC + "(s0p10h12v0s3B");

		texto = encabezado.getString("NombreEmpresa");
		cadena = cadena + alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, tamanioLetra.mLongTotal);
		cadenaRecibo.append(cadena + "\r\n");

		texto = encabezado.getString("RFC");
		cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, tamanioLetra.mLongTotal);
		cadenaRecibo.append(cadena + "\r\n");
		cadenaRecibo.append("\r\n");

		encabezado.close();
		
		tamanioLetra = mTamanioTituloH;

		cadenaRecibo.append(ESC + "(s0p8h14v0s7B");
		
		texto = ValoresReferencia.getDescripcion("REPORTEA", String.valueOf(reporte));
		cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, tamanioLetra.mLongTotal);	
		
		cadenaRecibo.append(cadena + "\r\n");
		cadenaRecibo.append("\r\n");
		
		tamanioLetra = mTamanioSubTituloH;
		
		cadenaRecibo.append(ESC + "(s0p12h10v0s3B");
		
		texto = Mensajes.get("XImpresion") + ": " + Generales.getFechaHoraActualStr("dd/MM/yyyy hh:mm:ss");
		cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, tamanioLetra.mLongTotal);
		cadenaRecibo.append(cadena + "\r\n");	
		
		tamanioLetra = mTamanioDetalle;
		
		cadenaRecibo.append(ESC + "(s0p14h8v0s3B");
		
		/* Encabezados */
		texto = Mensajes.get("XFolio");
		cadena = completaHasta(texto, 11, TipoAlineacion.IZQUIERDA, false);
		texto = Mensajes.get("XCliente");
		cadena+= completaHasta(texto, 18, TipoAlineacion.IZQUIERDA, false);
		texto = Mensajes.get("XDomicilioEntrega");
		cadena+= completaHasta(texto, 30, TipoAlineacion.IZQUIERDA, false);
		texto = Mensajes.get("TRPFechaCaptura");
		cadena+= completaHasta(texto, 14, TipoAlineacion.IZQUIERDA, false);
		texto = Mensajes.get("XFase");
		cadena+= completaHasta(texto, 10, TipoAlineacion.IZQUIERDA, false);
		texto = Mensajes.get("XFechaEntrega");
		cadena+= completaHasta(texto, 14, TipoAlineacion.IZQUIERDA, false);
		texto = Mensajes.get("XRuta");
		cadena+= completaHasta(texto, 14, TipoAlineacion.IZQUIERDA, false);
		texto = Mensajes.get("XVolumen");
		cadena+= completaHasta(texto, 8, TipoAlineacion.DERECHA, false);
		texto = Mensajes.get("XKgLts");
		cadena+= completaHasta(texto, 8, TipoAlineacion.DERECHA, false);
		texto = Mensajes.get("XMonto");
		cadena+= completaHasta(texto, 12, TipoAlineacion.DERECHA, true);
		
		cadenaRecibo.append(cadena + "\r\n");
		cadenaRecibo.append("\r\n");
		
		cadenaRecibo.append(ESC + "(s0p14h8v0s0B");	
		
		float volumen, monto, peso;
		peso = volumen = monto = 0;
		
		ISetDatos pedidos = Consultas.ConsultasTransProd.obtenerPedidosPreventaParaReporte();
		while(pedidos.moveToNext())
		{
			cadena = completaHasta(pedidos.getString("Folio"), 11, TipoAlineacion.IZQUIERDA, false);
			cadena+= completaHasta(pedidos.getString("Cliente"), 18, TipoAlineacion.IZQUIERDA, false);
			cadena+= completaHasta(pedidos.getString("Domicilio"), 30, TipoAlineacion.IZQUIERDA, false);
			cadena+= completaHasta(Generales.getFormatoFecha(pedidos.getDate("FechaCaptura"), "dd/MM/yyyy"), 14, TipoAlineacion.IZQUIERDA, false);
			cadena+= completaHasta(pedidos.getString("Fase"), 10, TipoAlineacion.IZQUIERDA, false);
			cadena+= completaHasta(Generales.getFormatoFecha(pedidos.getDate("FechaEntrega"), "dd/MM/yyyy"), 14, TipoAlineacion.IZQUIERDA, false);
			cadena+= completaHasta(pedidos.getString("Ruta"), 14, TipoAlineacion.IZQUIERDA, false);
			volumen+= pedidos.getFloat("Volumen");
			peso+= pedidos.getFloat("Peso");
			monto+= pedidos.getFloat("Monto");
			cadena+= completaHasta(Generales.getFormatoDecimal(pedidos.getFloat("Volumen"), 2), 8, TipoAlineacion.DERECHA, false);
			cadena+= completaHasta(Generales.getFormatoDecimal(pedidos.getFloat("Peso"), 2), 8, TipoAlineacion.DERECHA, false);
			cadena+= completaHasta("$ ".concat(Generales.getFormatoDecimal(pedidos.getFloat("Monto"), "#,###,##0.00")), 12, TipoAlineacion.DERECHA, true);
			
			cadena+= "\r\n";
			
			cadenaRecibo.append(cadena);
			
		}
		pedidos.close();
		cadenaRecibo.append("\r\n");
		
		cadena = completaHasta(Generales.getFormatoDecimal(volumen, 2), 116, TipoAlineacion.DERECHA, false);
		cadena = completaHasta(Generales.getFormatoDecimal(peso, 2), 8, TipoAlineacion.DERECHA, false);
		cadena+= completaHasta("$ ".concat(Generales.getFormatoDecimal(monto, "#,###,##0.00")), 10, TipoAlineacion.DERECHA, true);
		
		cadenaRecibo.append(cadena);
		
		cadenaRecibo.append("\r\n\r\n");	
	}

	public class PrintException extends Exception
	{
		private static final long serialVersionUID = 1L;

		private int iCodigo = 0;

		public PrintException(String mensaje, int numCodigo)
		{
			super(mensaje);
			iCodigo = numCodigo;
		}

		public int getCodigo()
		{
			return iCodigo;
		}
	}

//	private final Handler mHandler = new Handler()
//	{
//		@Override
//		public void handleMessage(Message msg)
//		{
//			super.handleMessage(msg);
//			switch (msg.what)
//			{
//				case msgTypes.MESSAGE_STATE_CHANGE:
//					Bundle bundle = msg.getData();
//					int status = bundle.getInt("state");
//					//if (D)
//					//Log.i("eRoutePrinting", "handleMessage: MESSAGE_STATE_CHANGE: " + msg.arg1);  //arg1 was not used! by btPrintFile
//					//setConnectState(msg.arg1);
//					switch (msg.arg1)
//					{
//						case btPrintFile.STATE_CONNECTED:
//							try
//							{
////								iniciarImpresion();
//							}
//							catch (Exception ex)
//							{
//								if (vistaActual != null)
//									vistaActual.mostrarError(ex.getMessage());
//							}
//
//							//addLog("connected to: " + mConnectedDeviceName);
//							//mConversationArrayAdapter.clear();
//							//Log.i("eRoutePrinting", "handleMessage: STATE_CONNECTED: " + mConnectedDeviceName);
//							break;
//						case btPrintFile.STATE_CONNECTING:
//							if (vistaActual != null)
//							{
//								vistaActual.quitarProgreso();
//								vistaActual.mostrarProgreso("Imprimiendo...");
//							}
//							//addLog("connecting...");
//							//Log.i("eRoutePrinting", "handleMessage: STATE_CONNECTING: " + mConnectedDeviceName);
//							break;
//						case btPrintFile.STATE_LISTEN:
//							//addLog("connection ready");
//
//							Log.i("eRoutePrinting", "handleMessage: STATE_LISTEN");
//							break;
//						case btPrintFile.STATE_IDLE:
//							//addLog("STATE_NONE");
//							//Log.i("eRoutePrinting", "handleMessage: STATE_NONE: not connected");
//							/*
//							 * if (intentosConexion){ intentosConexion = false;
//							 * if (vistaActual != null){ vistaActual.
//							 * mostrarPreguntaReintentarConexionImpresora(
//							 * "No se encontró la impresora. Verificar que este encendida.¿Desea reintentar?"
//							 * , btPrintService, device, new
//							 * boolean[]{intentosConexion}); } }
//							 */
//							break;
//						case btPrintFile.STATE_DISCONNECTED:
//							if (doorOpen)
//							{
//								doorOpen = false;
//								intentosConexion[0] = false;
//								if (vistaActual != null)
//								{
//									vistaActual.mostrarPreguntaReintentarConexionImpresora("La puerta de la impresora esta abierta. Favor de cerrala. ¿Desea reintentar?", btPrintService, device, intentosConexion);
//								}
//							}
//							else if (intentosConexion[0])
//							{
//								intentosConexion[0] = false;
//								if (reintentosOcultos < 3)
//								{
//									reintentosOcultos += 1;
//									try
//									{
//										Method m = device.getClass()
//												.getMethod("createBond", (Class[]) null);
//										m.invoke(device, (Object[]) null);
//
//										Thread.sleep(3000);
//									}
//									catch (Exception ex)
//									{
//										if (vistaActual != null)
//										{
//											Toast.makeText((Activity) vistaActual, ex.getMessage(), Toast.LENGTH_LONG).show();
//										}
//									}
//									intentosConexion[0] = true;
//									btPrintService.connect(device);
//									break;
//								}
//								if (vistaActual != null)
//								{
//									reintentosOcultos = 0;
//									vistaActual.mostrarPreguntaReintentarConexionImpresora("No se encontró la impresora; Favor de verificar que este encendida o reiniciarla. ¿Desea reintentar?", btPrintService, device, intentosConexion);
//								}
//							}
//
//							break;
//					}
//					break;
//				case msgTypes.MESSAGE_WRITE:
//					byte[] writeBuf = (byte[]) msg.obj;
//					// construct a string from the buffer
//					String writeMessage = new String(writeBuf);
//					//mConversationArrayAdapter.add("Me:  " + writeMessage);
//					break;
//				case msgTypes.MESSAGE_READ:
//					byte[] readBuf = (byte[]) msg.obj;
//					// construct a string from the valid bytes in the buffer
//					String readMessage = new String(readBuf, 0, msg.arg1);
//					if (readMessage.toUpperCase().contains("DOOR") || readMessage.toUpperCase().contains("OPEN"))
//						doorOpen = true;
//					//mConversationArrayAdapter.add(mConnectedDeviceName + ":  " + readMessage);
//					//addLog("recv>>>" + readMessage);
//					break;
//				case msgTypes.MESSAGE_DEVICE_NAME:
//					// save the connected device's name
//					//mConnectedDeviceName = msg.getData().getString(msgTypes.DEVICE_NAME);
//					//Toast.makeText(getApplicationContext(), "Connected to " + mConnectedDeviceName, Toast.LENGTH_SHORT).show();
//					//myToast(mConnectedDeviceName, "Connected");
//					Log.i("eRoutePrinting", "handleMessage: CONNECTED TO: " + msg.getData().getString(msgTypes.DEVICE_NAME));
//					//printESCP();
//					//updateConnectButton(false);
//
//					break;
//				case msgTypes.MESSAGE_TOAST:
//					if (vistaActual != null)
//					{
//						if (reintentosOcultos >= 3 && !desconexionManual)
//						{
//							desconexionManual = false;
//							Toast.makeText(((Activity) vistaActual).getBaseContext(), msg.getData().getString(msgTypes.TOAST), Toast.LENGTH_LONG).show();
//						}
//					}
//					//                    Toast toast = Toast.makeText(getApplicationContext(), msg.getData().getString(msgTypes.TOAST), Toast.LENGTH_SHORT);//.show();
//					//                    toast.setGravity(Gravity.CENTER,0,0);
//					//                    toast.show();
//					//myToast(msg.getData().getString(msgTypes.TOAST));
//					//	if (msg.getData() == ""){
//
//					//}
//					//if (msg.getData().getString(msgTypes.TOAST).equalsIgnoreCase("Toast: connectionFailed")){
//
//					//}
//					//Log.i("eRoutePrinting", "handleMessage: TOAST: " + msg.getData().getString(msgTypes.TOAST));
//					//addLog(msg.getData().getString(msgTypes.TOAST));
//					break;
//				case msgTypes.MESSAGE_INFO:
//					//addLog(msg.getData().getString(msgTypes.INFO));
//					//mLog.append(msg.getData().getString(msgTypes.INFO));
//					//mLog.refreshDrawableState();
//					String s = msg.getData().getString(msgTypes.INFO);
//					if (s.length() == 0)
//						s = String.format("int: %i" + msg.getData().getInt(msgTypes.INFO));
//					Log.i("eRoutePrinting", "handleMessage: INFO: " + s);
//					break;
//			}
//		}
//	};
}
