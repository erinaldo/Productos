package com.amesol.routelite.actividades;

import java.io.BufferedReader;
import java.io.ByteArrayOutputStream;
import java.io.DataInputStream;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.OutputStream;
import java.lang.reflect.Method;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Collections;
import java.util.Enumeration;
import java.util.HashMap;
import java.util.Hashtable;
import java.util.List;
import java.util.Locale;
import java.util.Map;

import android.app.Activity;
import android.bluetooth.BluetoothAdapter;
import android.bluetooth.BluetoothDevice;
import android.content.ContentValues;
import android.content.Context;
import android.content.Intent;
import android.database.Cursor;
import android.database.DatabaseUtils;
import android.net.Uri;
import android.os.Bundle;
import android.os.Handler;
import android.os.Message;
import android.util.Log;
import android.widget.Toast;

import com.amesol.routelite.actividades.Enumeradores.msgTypes;
import com.amesol.routelite.datos.CORTabla;
import com.amesol.routelite.datos.COTCampo;
import com.amesol.routelite.datos.Cliente;
import com.amesol.routelite.datos.ClienteDomicilio;
import com.amesol.routelite.datos.ConfiguracionRecibo;
import com.amesol.routelite.datos.Dia;
import com.amesol.routelite.datos.Recibo;
import com.amesol.routelite.datos.Ruta;
import com.amesol.routelite.datos.TransProd;
import com.amesol.routelite.datos.Vendedor;
import com.amesol.routelite.datos.basedatos.BDTerm;
import com.amesol.routelite.datos.basedatos.BDVend;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.basedatos.Consultas.ConsultasAbono;
import com.amesol.routelite.datos.basedatos.Consultas.ConsultasImpresionTicket;
import com.amesol.routelite.datos.basedatos.Consultas.ConsultasTPDImpuesto;
import com.amesol.routelite.datos.basedatos.Consultas.ConsultasTransProd;
import com.amesol.routelite.datos.basedatos.Consultas.ConsultasTransProdDetalle;
import com.amesol.routelite.datos.basedatos.Consultas2;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.ArchivoConfiguracion.CampoConfiguracion;
import com.amesol.routelite.datos.utilerias.CONHist;
import com.amesol.routelite.datos.utilerias.ConfiguracionLocal;
import com.amesol.routelite.datos.utilerias.MOTConfiguracion;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.IVista;
import com.amesol.routelite.presentadores.interfaces.ICapturaDeposito;
import com.amesol.routelite.utilerias.ControlError;
import com.amesol.routelite.utilerias.Generales;
import com.amesol.routelite.vistas.ImpresionTicket;
import com.amesol.routelite.vistas.PDFViewer;
import com.amesol.routelite.vistas.utilerias.NumeroALetra;
import com.itextpdf.text.BaseColor;
import com.itextpdf.text.Document;
import com.itextpdf.text.Element;
import com.itextpdf.text.Font;
import com.itextpdf.text.Paragraph;
import com.itextpdf.text.pdf.PdfWriter;
//import com.intermec.print.lp.LinePrinter;
//import com.intermec.print.lp.LinePrinterException;

public class Recibos
{

	//ClienteActual
	private static Cliente oClienteAct;
	public IVista vistaActual;

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

	//modoEncabezadoPie
	public final class ModoEncabezadoPie
	{
		private static final short ENCABEZADO = 1;
		private static final short PIE = 2;
	}

	//tipoPapel	
	public final class TipoPapel
	{
		public final static short EXTECH_TERMICA2 = 1;
		public final static short EXTECH_TERMICA3 = 2;
		public final static short EXTECH_IMPACTO2 = 3;
		public final static short ZEBRA_TERMICA2 = 4;
		public final static short TEC_TERMICA2 = 5;
		public final static short CITIZEN2 = 6;
		public final static short ZEBRA_CAMEO2 = 7;
		public final static short STAR_DP8340 = 8;
		public final static short INTERMEC_PR3 = 9;
		public final static short INTERMEC_PR2 = 11;
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
	private static TamanioLetra tamanioDefault = new TamanioLetra(50, 48, 0);
	//Tamaño actual de letra
	private static TamanioLetra mTamanioActual = new TamanioLetra(50, 48, 0);

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
		return Collections.unmodifiableMap(result);
	}

	private static void setTamanioDefault(int partTipoPapel)
	{
		switch (partTipoPapel)
		{
			case TipoPapel.EXTECH_TERMICA2:
				tamanioDefault = new TamanioLetra(53, 48, 0);
				break;
			case TipoPapel.EXTECH_TERMICA3:
				tamanioDefault = new TamanioLetra(53, 72, 0);
				break;
			case TipoPapel.EXTECH_IMPACTO2:
				tamanioDefault = new TamanioLetra(14, 20, 0);
				break;
			case TipoPapel.ZEBRA_TERMICA2:
				tamanioDefault = new TamanioLetra(0, 48, 9);
				break;
			case TipoPapel.TEC_TERMICA2:
				tamanioDefault = new TamanioLetra(0, 24, 0);
				break;
			case TipoPapel.CITIZEN2:
				tamanioDefault = new TamanioLetra(17, 42, 0);
				break;
			case TipoPapel.ZEBRA_CAMEO2:
				tamanioDefault = new TamanioLetra(2, 44, 18);
				break;
			case TipoPapel.STAR_DP8340:
				tamanioDefault = new TamanioLetra(0, 60, 0);
				break;
			case TipoPapel.INTERMEC_PR2:
				tamanioDefault = new TamanioLetra(33, 38, 0);
				break;
			case TipoPapel.INTERMEC_PR3:
				tamanioDefault = new TamanioLetra(33, 57, 0);
				break;
		}
	}

	public static final int MESSAGE_STATE_CHANGE = 1;
	public static final int MESSAGE_READ = 2;
	public static final int MESSAGE_WRITE = 3;
	public static final int MESSAGE_DEVICE_NAME = 4;
	public static final int MESSAGE_TOAST = 5;

	public static final String TOAST = "toast";

	public void imprimirRecibos(List<Map<String, String>> listaTickets, Boolean logoSoloPrimerRecibo, IVista vista) throws ControlError, Exception
	{

		//vistaActual = vista;
		Hashtable<String, ContentValues> archivosGenerados = new Hashtable<String, ContentValues>();

		String nombreArchivo = "";

		Vendedor vendedor = (Vendedor) Sesion.get(Campo.VendedorActual);

		ConfiguracionLocal conf = (ConfiguracionLocal) Sesion.get(Campo.ConfiguracionLocal);
		File impresion = new File(conf.get(CampoConfiguracion.DIRECTORIO_TRABAJO).toString());
		impresion = new File(impresion, "impresion");
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

		//String[] Errores ={""};
		Recibo reciboAct = null;
		ConfiguracionRecibo configuracionReciboAct = null;
		//ISetDatos sdCOTCampo = null;
		//ISetDatos sdCORTabla = null;
		boolean imprimeLogo = true;

		oClienteAct = (Cliente) Sesion.get(Campo.ClienteActual);
		MOTConfiguracion oMotConf = (MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion);

		boolean reimpresion = false;
		if (vista.getClass().equals(ImpresionTicket.class))
		{
			reimpresion = true;
		}

		String[] byRefMsgError =
		{ "" };
		short numeroCopias = 1;
		for (int i = 0; i < listaTickets.size(); i++)
		{
			//TODO Paula, checar si tengo que enviar mensaje por cada recibo o si falla cualquier recibo parar.
			try
			{
				CONHist oConHist = (CONHist) Sesion.get(Campo.CONHist);
				int ticketConfigurado = Integer.parseInt(oConHist.get("TicketConfigurado").toString());
				if (ticketConfigurado == 15 && (Short.parseShort(listaTickets.get(i).get("Tipo")) == 1 || (Short.parseShort(listaTickets.get(i).get("Tipo")) == 21 && oMotConf.get("MSIEVPreventa").equals("1"))))
				{
					//ticket pedido costeña, se revisa con Tipo, porque TipoRecibo  cambia dependiendo del modulo.
					//Se imprime ticket de pedido para MSIEV cuando el parametro MSIEVPreventa esta activo CAI 3268
					reciboAct = new Recibo();
					reciboAct.Tipo = Short.parseShort(listaTickets.get(i).get("TipoRecibo"));
					reciboAct.TipoPapel = ((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp;
					if (Short.parseShort(listaTickets.get(i).get("Tipo")) == 21 || (Short.parseShort(listaTickets.get(i).get("Tipo")) == 1 && Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.PREVENTA)){
						//imprimir 2 copias en el caso de preventa y MSIEV
						numeroCopias = 2;	
					}else{
						//imprimir 2 copias en caso de modulo distinto a preventa
						numeroCopias = 1;
					}
				
					nombreArchivo = generarArchivoRecibo(listaTickets.get(i), impresion.getAbsolutePath(), reciboAct, imprimeLogo, ticketConfigurado, byRefMsgError, reimpresion);
				}
				else if (listaTickets.get(i).get("TipoRecibo").equals(TRECIBO.DEPOSITOS_MANUALES))
				{ //ticket depositos manuales
					if (vista instanceof ICapturaDeposito)
					{
						reciboAct = new Recibo();
						reciboAct.Tipo = Short.parseShort(listaTickets.get(i).get("TipoRecibo"));
						reciboAct.TipoPapel = ((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp;
						ICapturaDeposito vis = (ICapturaDeposito) vista;
						vis.getAplicaDevoluciones();
						boolean aplicaDev = vis.getAplicaDevoluciones();
						nombreArchivo = generarArchivoRecibo(listaTickets.get(i), impresion.getAbsolutePath(), reciboAct, imprimeLogo, aplicaDev, byRefMsgError);
					}
				}
				else
				{ //tickets configurables
					//Si cambia el recibo Actual vuelvo a obtener la información
					if (reciboAct == null || reciboAct.Tipo != Short.parseShort(listaTickets.get(i).get("TipoRecibo")))
					{
						if (Short.parseShort(listaTickets.get(i).get("Tipo")) == 21 && oMotConf.get("MSIEVPreventa").equals("1"))
						{
							//Se imprime ticket de preventa para MSIEV cuando el parametro MSIEVPreventa esta activo CAI 3268
							listaTickets.get(i).remove(listaTickets.get(i).get("Tipo"));
							listaTickets.get(i).put("Tipo", "1");
							listaTickets.get(i).remove(listaTickets.get(i).get("TipoRecibo"));
							listaTickets.get(i).put("TipoRecibo", "1");
						}

						reciboAct = ConsultasImpresionTicket.obtenerReciboPorTipoRecibo(Short.parseShort(listaTickets.get(i).get("TipoRecibo")), vendedor.TipoModImp, byRefMsgError);

						if (reciboAct == null)
						{
							if (!byRefMsgError[0].equals(""))
							{
								//Errores[0] = Errores[0].concat(byRefMsgError[0]);
								throw new Exception(byRefMsgError[0]);
							}
						}

						//if(reciboAct.Tipo < 100){
						//recibos configurables
						configuracionReciboAct = ConsultasImpresionTicket.obtenerConfiguracionReciboPorTipoRecibo(Short.parseShort(listaTickets.get(i).get("TipoRecibo")), byRefMsgError);
						if (configuracionReciboAct == null)
						{
							if (!byRefMsgError.equals(""))
							{
								//Errores[0] = Errores[0].concat(byRefMsgError[0]);
								throw new Exception(byRefMsgError[0]);
							}
						}
						/*
						 * }else{ //recibos amarrados configuracionReciboAct =
						 * null; }
						 */

						/*
						 * if (sdCOTCampo !=null) sdCOTCampo.close(); if
						 * (sdCORTabla !=null) sdCORTabla.close();
						 * 
						 * sdCOTCampo =
						 * ConsultasImpresionTicket.obtenerCOTCampoPorCORId
						 * (configuracionReciboAct.CORId); sdCORTabla =
						 * ConsultasImpresionTicket
						 * .obtenerCORTablaPorCORId(configuracionReciboAct
						 * .CORId);
						 */
					}
					//if(configuracionReciboAct == null){
					//tickets amarrados
					/*
					 * if(vista instanceof ICapturaDeposito){ ICapturaDeposito
					 * vis = (ICapturaDeposito) vista;
					 * vis.getAplicaDevoluciones(); boolean aplicaDev =
					 * vis.getAplicaDevoluciones(); nombreArchivo =
					 * generarArchivoRecibo(
					 * listaTickets.get(i),impresion.getAbsolutePath(),
					 * reciboAct, imprimeLogo, aplicaDev, byRefMsgError); }else{
					 * nombreArchivo = generarArchivoRecibo(
					 * listaTickets.get(i),impresion.getAbsolutePath(),
					 * reciboAct, imprimeLogo, byRefMsgError); }
					 */
					//}else if(configuracionReciboAct != null){
					//tickets configurables
					nombreArchivo = generarArchivoRecibo(listaTickets.get(i), impresion.getAbsolutePath(), reciboAct, configuracionReciboAct, imprimeLogo, byRefMsgError);
					//}
					if (logoSoloPrimerRecibo)
					{
						imprimeLogo = false;
					}
				}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.getMessage());
			}
			if (!archivosGenerados.containsKey(nombreArchivo) && !nombreArchivo.equals(""))
			{
				ContentValues valoresRecibo = new ContentValues();
				valoresRecibo.put("TipoPapel", reciboAct.TipoPapel);
				valoresRecibo.put("MostrarLogo", reciboAct.MostrarLogo);
				archivosGenerados.put(nombreArchivo, valoresRecibo);
			}
		}
		imprimirArchivos(archivosGenerados, impresion, vista, numeroCopias);
	}

	/* Separar la impresion de los archivos generales en este nuevo metodo */
	public void imprimirArchivos(Hashtable<String, ContentValues> archivosAImprimir, File impresion, IVista vista, short numeroCopias) throws Exception
	{
		//vistaActual = vista;
		Enumeration<String> e = archivosAImprimir.keys();
		String archivo = "";
		final boolean impresionConVista = vista != null;
		while (e.hasMoreElements())
		{
			archivo = e.nextElement();
			try
			{
				/* Si se detiene, reintentar con el resto */
				/*
				 * if (archivosAImprimir.get(archivo).getAsShort("TipoPapel") ==
				 * TipoPapel.INTERMEC_PR2){ PrintTask task = new PrintTask();
				 * ConfiguracionLocal config = (ConfiguracionLocal)
				 * Sesion.get(Campo.ConfiguracionLocal );
				 * task.execute(config.get
				 * (CampoConfiguracion.DIRECTORIO_TRABAJO).toString());
				 * 
				 * }else{
				 */
				BluetoothPrint(vista, new File(impresion, archivo).getAbsolutePath(), archivosAImprimir.get(archivo).getAsShort("TipoPapel"), archivosAImprimir.get(archivo).getAsBoolean("MostrarLogo"), numeroCopias);
				/* Quitarlo de la lista de archivos a imprimir */
				/*
				 * archivosAImprimir.remove(archivo);
				 * if(archivosAImprimir.isEmpty()) { if (impresionConVista){
				 * vista.impresionFinalizada(true, ""); } }
				 */
				//}
			}
			catch (PrintException ex)
			{
				if (ex.getCodigo() == 1)
				{
					vista.vincularImpresora(ex.getMessage(), archivosAImprimir, impresion);
				}
				else
				{
					if (impresionConVista)
					{
						vista.mostrarPreguntaReintentarImpresion(ex.getMessage().concat("\n¿Deseas intentar de nuevo?"), archivosAImprimir, impresion, numeroCopias);
					}
					else
					{
						throw ex;
					}
				}

				/*
				 * Si no se encuentra el dispositivo, reintentar con los
				 * pendientes
				 */
			}
		}
	}

	void BluetoothPrint(IVista vista, String nombreArchivo, Short nTipoPapel, boolean bMostrarLogo, short numeroCopias) throws Exception
	{
		vistaActual = vista;
		fileName = nombreArchivo;
		numCopias = numeroCopias;
		mostrarLogo = bMostrarLogo;
		tipoPapel = nTipoPapel;

		reintentosOcultos = 0;
		try
		{

			btAdapter = BluetoothAdapter.getDefaultAdapter();
			if (btAdapter == null)
			{
				throw new Exception("Bluetooth no soportado");
			}

			if (!btAdapter.isEnabled())
			{
				throw new Exception("El Bluetooth no esta encendido");
			}
			if (btPrintService == null)
				setupComm(vista);

			ConfiguracionLocal config = (ConfiguracionLocal) Sesion.get(Campo.ConfiguracionLocal);
			String puerto = (String) config.get(CampoConfiguracion.PUERTO + "_" + tipoPapel);

			if (puerto == null)
			{
				throw new Exception(Mensajes.get("E0708"));
			}

			String remote = puerto;
			if (remote.length() == 0)
				return;

			String sMacAddr = puerto.split("_")[0];
			;

			try
			{
				device = btAdapter.getRemoteDevice(sMacAddr);
			}
			catch (Exception e)
			{
				throw new Exception(Mensajes.get("E0708"));
			}

			if (device != null)
			{
				while (device.getBondState() != BluetoothDevice.BOND_BONDED)
				{
					Method m = device.getClass()
							.getMethod("createBond", (Class[]) null);
					m.invoke(device, (Object[]) null);

					Thread.sleep(3000);
				}

				intentosConexion[0] = true;
				btPrintService.connect(device);
			}
			else
			{
				throw new Exception("Verifique que la impresora este encendida");
			}

			//addLog(String.format("printed " + totalWrite.toString() + " bytes"));
		}
		catch (IOException e)
		{
			throw new Exception("Impresión fallida");
		}
		catch (Exception e)
		{
			throw new Exception(e.getMessage());
		}
		finally
		{
			/*
			 * if (inStream != null) { try { inStream.close(); inStream = null;
			 * } catch (IOException e) { } }
			 */

			/*
			 * if (btPrintService.getState() == btPrintFile.STATE_CONNECTED) {
			 * btPrintService.stop();
			 * //setConnectState(btPrintFile.STATE_DISCONNECTED); return; }
			 */
		}
		return;
	}//BluetoothPrint() 

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

	private void setupComm(IVista vista) throws Exception
	{
		// Initialize the array adapter for the conversation thread
		//mConversationArrayAdapter = new ArrayAdapter<String>(this, R.id.remote_device);
		//Log.d(TAG, "setupComm()");
		btPrintService = new btPrintFile((Activity) vista, mHandler);
		if (btPrintService == null)
			throw new Exception("Inicializacion del puerto fallida");
	}

	private void iniciarImpresion() throws Exception
	{
		intentosConexion[0] = false;
		if (btPrintService.getState() != btPrintFile.STATE_CONNECTED)
		{
			// myToast("Please connect first!", "Error");
			return; //does not match file pattern for a print file
		}

		try
		{

			for (int i = 0; i < numCopias; i++)
			{

				/*
				 * InputStream inputStream = null; ByteArrayInputStream
				 * byteArrayInputStream; //[4] Integer totalWrite = 0;
				 * StringBuffer sb = new StringBuffer(); try { if (vistaActual
				 * == null) return; inputStream = new
				 * FileInputStream(fileName);/
				 * /((Activity)vistaActual).getAssets().open(fileName); //[5]
				 * 
				 * byte[] buf = new byte[2048]; int readCount = 0; do {
				 * readCount = inputStream.read(buf); if (readCount > 0) {
				 * totalWrite += readCount; byte[] bufOut = new byte[readCount];
				 * System.arraycopy(buf, 0, bufOut, 0, readCount);
				 * btPrintService.write(bufOut); } } while (readCount > 0);
				 * //[6] inputStream.close(); //addLog(String.format("printed "
				 * + totalWrite.toString() + " bytes")); } catch (IOException e)
				 * { Log.e("nada", "Exception in printFile: " + e.getMessage());
				 * //addLog("printing failed!"); //Toast.makeText(this,
				 * "printing failed!", Toast.LENGTH_LONG);
				 * //myToast("Printing failed","Error"); }
				 * 
				 * }
				 */

				FileInputStream fstream = new FileInputStream(fileName);
				// Get the object of DataInputStream
				DataInputStream in = new DataInputStream(fstream);
				BufferedReader br = new BufferedReader(new InputStreamReader(in));
				String strLine;
				ByteArrayOutputStream buffer = new ByteArrayOutputStream();
				//byte[] buffer;
				//Read File Line By Line
				String saltoLinea = "\r\n";
				while ((strLine = br.readLine()) != null)
				{
					if (strLine.equalsIgnoreCase("IMPRIME_LOGO"))
					{
						if (mostrarLogo)
						{
							if (tipoPapel == TipoPapel.EXTECH_TERMICA2 || tipoPapel == TipoPapel.EXTECH_TERMICA3)
							{
								buffer.write(new byte[]
								{ 27, 76, 103, 48 });
							}
							else if (tipoPapel == TipoPapel.INTERMEC_PR2 || tipoPapel == TipoPapel.INTERMEC_PR3)
							{
								buffer.write(new byte[]
								{ 27, 69, 90 });

								String sImagen = "{PRINT:@0,170:ALOGO,HMULT1,VMULT1|}";
								sImagen += "{LP}";
								buffer.write(sImagen.getBytes());
							}
						}
					}
					else if (strLine.startsWith("{"))
					{
						if (tipoPapel == TipoPapel.EXTECH_TERMICA2 || tipoPapel == TipoPapel.EXTECH_TERMICA3)
						{
							buffer.write(new byte[]
							{ 27, 107, Byte.parseByte(strLine.substring(1, strLine.indexOf("}"))) });
						}
						else if (tipoPapel == TipoPapel.INTERMEC_PR2 || tipoPapel == TipoPapel.INTERMEC_PR3)
						{
							//buffer.write(new byte[]{27,119,Byte.parseByte(strLine.substring(1, strLine.indexOf("}")))});
							//buffer.write(new byte[]{27,33,16});
							buffer.write(new byte[]
							{ Byte.parseByte(strLine.substring(1, strLine.indexOf("}")).split(",")[0]), Byte.parseByte(strLine.substring(1, strLine.indexOf("}")).split(",")[1]), Byte.parseByte(strLine.substring(1, strLine.indexOf("}")).split(",")[2]) });
						}

						if (strLine.indexOf("}") + 1 != strLine.length())
						{
							buffer.write(strLine.substring(strLine.indexOf("}") + 1, strLine.length()).getBytes());
						}
					}
					else
					{
						buffer.write(strLine.getBytes());
					}
					buffer.write(saltoLinea.getBytes());
				}
				//Close the input stream
				in.close();

				btPrintService.write(buffer.toByteArray());
				Thread.sleep(2000);
			}

			//archivosAImprimir.remove(archivo);
			//if(archivosAImprimir.isEmpty())
			//{
			if (vistaActual != null)
			{
				vistaActual.impresionFinalizada(true, "");
				//}
			}

		}
		catch (Exception ex)
		{
			throw ex;
		}
		finally
		{

			if (btPrintService.getState() == btPrintFile.STATE_CONNECTED)
			{
				desconexionManual = true;
				btPrintService.stop();
				return;
			}

		}
	}

	public HashMap<String, String> getDocumentoImpresion(String _id, String tipo, String varCodigo, String tipoRecibo, String folio, String descTipo, String fecha, String total, String tipoFase, String clienteClave, String diaClave, String subEmpresaID, String facElec)
	{
		HashMap<String, String> documento = new HashMap<String, String>();

		documento.put("_Id", _id);
		documento.put("Tipo", String.valueOf(tipo));
		documento.put("VARCodigo", varCodigo);
		documento.put("TipoRecibo", tipoRecibo);
		documento.put("Folio", folio);
		documento.put("DescTipo", ValoresReferencia.getDescripcion(varCodigo, String.valueOf(tipo)));
		documento.put("Fecha", fecha);
		documento.put("Total", total);
		documento.put("TipoFase", String.valueOf(tipoFase));
		documento.put("ClienteClave", clienteClave);
		documento.put("DiaClave", diaClave);
		documento.put("SubEmpresaID", subEmpresaID);
		documento.put("FacElec", facElec);

		documento.put("TipoRecibo", obtenerTipoRecibo(documento));
		return documento;
	}

	public String obtenerTipoRecibo(Map<String, String> registro)
	{
		String tipoRecibo = "0";

		int tipo = Integer.parseInt(registro.get("Tipo"));
		//if ((mAccion!= null)&&(mAccion.equals(Enumeradores.Acciones.ACCION_IMPRIMIR_TICKET_CON_VISITA))){
		if (registro.get("TipoRecibo").equals("TRP"))
		{
			if ((tipo == 3 && !registro.get("TipoFase").equals(3)) || (tipo != 3))
			{
				switch (tipo)
				{
					case 8:
						if (registro.get("FacElec").equals(1))
						{
							return "24"; // Facturacion Electronica
						}
						else
						{
							return "8"; // Facturacion
						}
					case 24:
						if (registro.get("TipoFase").equals(6))
						{
							return "26"; //Liquidacion
						}
						else
						{
							return "25"; //Consignación
						}
					case 1:
						if (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.VENTA)
						{
							return "1";
						}
						else if (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.PREVENTA)
						{
							return "27";
						}
						else if (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO)
						{
							return "28";
						}
					default:
						return registro.get("Tipo");
				}
			}
		}
		else if (registro.get("TipoRecibo").equals("ABN"))
		{
			return "10"; // Recibo de cobranza
		}

		/*
		 * }else if ((mAccion!= null)&&(mAccion.equals(Enumeradores.Acciones.
		 * ACCION_IMPRIMIR_TICKET_SIN_VISITA))){
		 * 
		 * }
		 */
		return tipoRecibo;
	}

	private static String generarArchivoRecibo(Map<String, String> datosTicket, String directorioArchivo, Recibo recibo, ConfiguracionRecibo configuracionRecibo, boolean imprimeLogo, String[] byRefMsgError) throws Exception
	{
		String nombreArchivo = "";

		try
		{
			nombreArchivo = "Recibos" + Short.toString(recibo.TipoPapel);
			File archivoRecibo = new File(directorioArchivo, nombreArchivo);
			if (!archivoRecibo.exists())
			{
				if (!archivoRecibo.createNewFile())
				{
					//TODO Paula, cambiar mensaje
					byRefMsgError[0] = "El archivo no se pudo crear";
					return "";
				}
			}

			//Valores default
			int columnasRecibo = 48;
			StringBuilder cadenaRecibo = new StringBuilder();

			if (imprimeLogo)
			{
				cadenaRecibo.append("IMPRIME_LOGO\r\n");
			}

			if (Short.parseShort(datosTicket.get("Tipo")) == 8 && Short.parseShort(datosTicket.get("TipoRecibo")) == 24)
			{
				if (Short.parseShort(datosTicket.get("TipoFase")) == 0)
				{
					cadenaRecibo.append("\r\n");
					cadenaRecibo.append(textoCentradoConSimbolo(Mensajes.get("XCancelada"), '*', columnasRecibo) + "\r\n");
				}
			}

			String campoLlave = "";
			if (Short.parseShort(datosTicket.get("TipoRecibo")) == 10)
			{
				campoLlave = "ABNId";
			}
			else if (Short.parseShort(datosTicket.get("TipoRecibo")) == 13)
			{
				campoLlave = "PLIId";
			}
			else
			{
				campoLlave = "TransProdID";
			}

			crearEncabezadoPie(recibo, ModoEncabezadoPie.ENCABEZADO, datosTicket, cadenaRecibo, false);
			crearGenerales(recibo, datosTicket, cadenaRecibo, campoLlave);
			crearDetalle(recibo, datosTicket, cadenaRecibo, campoLlave);
			crearEncabezadoPie(recibo, ModoEncabezadoPie.PIE, datosTicket, cadenaRecibo, false);

			OutputStream f1 = new FileOutputStream(archivoRecibo, true);
			f1.write(cadenaRecibo.toString().getBytes());
			Log.d("ImpresioTicket", cadenaRecibo.toString());
			f1.close();

		}
		catch (Exception ex)
		{
			//TODO Paula, cambiar mensaje
			throw new Exception("Error al generar ticket:" + ex.getMessage());
		}

		return nombreArchivo;
	}

	/*
	 * private static String generarArchivoRecibo(Map<String,String>
	 * datosTicket, String directorioArchivo, Recibo recibo, boolean
	 * imprimeLogo, String[] byRefMsgError) throws Exception{ return
	 * generarArchivoRecibo(datosTicket, directorioArchivo, recibo, imprimeLogo,
	 * false, byRefMsgError); }
	 */

	private static String generarArchivoRecibo(Map<String, String> datosTicket, String directorioArchivo, Recibo recibo, boolean imprimeLogo, boolean aplicaDevolucion, String[] byRefMsgError) throws Exception
	{
		String nombreArchivo = "";

		try
		{
			nombreArchivo = "Recibos" + Short.toString(recibo.TipoPapel);
			File archivoRecibo = new File(directorioArchivo, nombreArchivo);
			if (!archivoRecibo.exists())
			{
				if (!archivoRecibo.createNewFile())
				{
					//TODO Paula, cambiar mensaje
					byRefMsgError[0] = "El archivo no se pudo crear";
					return "";
				}
			}

			//Valores default
			int columnasRecibo = 48;
			StringBuilder cadenaRecibo = new StringBuilder();

			if (imprimeLogo)
			{
				cadenaRecibo.append("IMPRIME_LOGO\r\n");
			}

			/*
			 * if (Short.parseShort(datosTicket.get("Tipo")) == 8 &&
			 * Short.parseShort(datosTicket.get("TipoRecibo"))== 24){ if
			 * (Short.parseShort(datosTicket.get("TipoFase")) == 0){
			 * cadenaRecibo.append("\r\n");
			 * cadenaRecibo.append(textoCentradoConSimbolo
			 * (Mensajes.get("XCancelada"), '*', columnasRecibo) + "\r\n"); } }
			 */

			String campoLlave = "";
			if (Short.parseShort(datosTicket.get("TipoRecibo")) == 10)
			{
				campoLlave = "ABNId";
			}
			else if (Short.parseShort(datosTicket.get("TipoRecibo")) == 13)
			{
				campoLlave = "PLIId";
			}
			else
			{
				campoLlave = "TransProdID";
			}

			if (datosTicket.get("TipoRecibo").equals(TRECIBO.DEPOSITOS_MANUALES))
			{
				imprimirDepositosManuales(recibo, cadenaRecibo, aplicaDevolucion);
			}
			else
			{
				crearEncabezadoPie(recibo, ModoEncabezadoPie.ENCABEZADO, datosTicket, cadenaRecibo, false);
				crearGenerales(recibo, datosTicket, cadenaRecibo, campoLlave);
				crearDetalle(recibo, datosTicket, cadenaRecibo, campoLlave);
				crearEncabezadoPie(recibo, ModoEncabezadoPie.PIE, datosTicket, cadenaRecibo, false);
			}

			OutputStream f1 = new FileOutputStream(archivoRecibo, true);
			f1.write(cadenaRecibo.toString().getBytes());
			Log.d("ImpresioTicket", cadenaRecibo.toString());
			f1.close();

		}
		catch (Exception ex)
		{
			//TODO Paula, cambiar mensaje
			throw new Exception("Error al generar ticket:" + ex.getMessage());
		}

		return nombreArchivo;
	}

	private static String generarArchivoRecibo(Map<String, String> datosTicket, String directorioArchivo, Recibo recibo, boolean imprimeLogo, int ticketConfigurado, String[] byRefMsgError, boolean reimpresion) throws Exception
	{
		String nombreArchivo = "";

		try
		{
			nombreArchivo = "Recibos" + Short.toString(recibo.TipoPapel);
			File archivoRecibo = new File(directorioArchivo, nombreArchivo);
			if (!archivoRecibo.exists())
			{
				if (!archivoRecibo.createNewFile())
				{
					//TODO Paula, cambiar mensaje
					byRefMsgError[0] = "El archivo no se pudo crear";
					return "";
				}
			}

			//Valores default
			//int columnasRecibo  = 48;
			StringBuilder cadenaRecibo = new StringBuilder();

			if (imprimeLogo)
			{
				cadenaRecibo.append("IMPRIME_LOGO\r\n");
			}

			switch (ticketConfigurado)
			{
				case 15:
					/*
					 * boolean reimpresion = false; if
					 * (IVista.class.equals(IImpresionTicket.class)){
					 * reimpresion = true; }
					 */
					imprimirPedidoCostena(recibo, cadenaRecibo, datosTicket.get("_Id"), reimpresion, Integer.parseInt(datosTicket.get("Tipo").toString()));
					break;
			}

			OutputStream f1 = new FileOutputStream(archivoRecibo, true);
			f1.write(cadenaRecibo.toString().getBytes());
			Log.d("ImpresioTicket", cadenaRecibo.toString());
			f1.close();

		}
		catch (Exception ex)
		{
			//TODO Paula, cambiar mensaje
			throw new Exception("Error al generar ticket:" + ex.getMessage());
		}

		return nombreArchivo;
	}

	private static void imprimirDepositosManuales(Recibo recibo, StringBuilder cadenaRecibo, boolean aplicaDevolucion) throws Exception
	{
		crearEncabezado(recibo, cadenaRecibo);

		String cadena = "";

		TamanioLetra tamanioLetra;
		tamanioLetra = tamanioDefault;

		cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, Mensajes.get("XDepositos"), tamanioLetra.mLongTotal);
		cadenaRecibo.append(cadena + "\r\n");

		cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, Mensajes.get("XImpresion") + ": " + Generales.getFechaHoraActualStr("dd/MM/yyyy hh:mm:ss"), tamanioLetra.mLongTotal);
		cadenaRecibo.append(cadena + "\r\n");

		imprimeLineaPunteada(cadenaRecibo, tamanioLetra.mLongTotal);

		int col1 = 0;
		int col2 = 0;
		int col3 = 0;
		switch (recibo.TipoPapel)
		{
		//calcular los tamaños de las columnas en el ticket
			case TipoPapel.CITIZEN2:
			case TipoPapel.ZEBRA_CAMEO2:
				col1 = 8;
				col2 = 20;
				col3 = 10;
				break;
			case TipoPapel.STAR_DP8340:
				col1 = 20;
				col2 = 24;
				col3 = 12;
				break;
			default:
				col1 = 12;
				col2 = 22;
				col3 = 10;
				break;
		}
		cadena = completaHasta(Mensajes.get("XFolio"), col1, TipoAlineacion.IZQUIERDA, false);
		cadena += completaHasta(Mensajes.get("XMovimiento"), col2, TipoAlineacion.IZQUIERDA, false);
		cadena += completaHasta(Mensajes.get("XTotalMin"), col3, TipoAlineacion.DERECHA, true);
		cadenaRecibo.append(cadena + "\r\n");

		imprimeLineaPunteada(cadenaRecibo, tamanioLetra.mLongTotal);

		float totalVenta = Consultas.ConsultaDeposito.obtenerTotalVenta();
		float totalDev = Consultas.ConsultaDeposito.obtenerTotalDev();
		float totalGeneral = 0;
		float sumDep = 0;

		cadena = completaHasta("  ", col1, TipoAlineacion.IZQUIERDA, false);
		cadena += completaHasta(Mensajes.get("XTotalEfectivoCheques"), col2 + 4, TipoAlineacion.IZQUIERDA, false);
		cadena += completaHasta(Generales.getFormatoDecimal(totalVenta, "#,###,##0.00"), col3, TipoAlineacion.DERECHA, true);
		cadenaRecibo.append(cadena + "\r\n");

		cadena = completaHasta("  ", col1, TipoAlineacion.IZQUIERDA, false);
		cadena += completaHasta(Mensajes.get("XTotalDevoluciones"), col2, TipoAlineacion.IZQUIERDA, false);
		cadena += completaHasta(Generales.getFormatoDecimal(totalDev, "#,###,##0.00"), col3 + 4, TipoAlineacion.DERECHA, true);
		cadenaRecibo.append(cadena + "\r\n");

		if (aplicaDevolucion)
			totalGeneral = totalVenta - totalDev;
		else
			totalGeneral = totalVenta;

		cadena = completaHasta("  ", col1, TipoAlineacion.IZQUIERDA, false);
		cadena += completaHasta(Mensajes.get("XTotalGeneral"), col2, TipoAlineacion.IZQUIERDA, false);
		cadena += completaHasta(Generales.getFormatoDecimal(totalGeneral, "#,###,##0.00"), col3 + 4, TipoAlineacion.DERECHA, true);
		cadenaRecibo.append(cadena + "\r\n");

		imprimeLineaPunteada(cadenaRecibo, tamanioLetra.mLongTotal);

		ISetDatos depositos = Consultas.ConsultaDeposito.obtenerDepositosRealizados();

		int cont = 1;
		while (depositos.moveToNext())
		{
			cadena = completaHasta(String.format("%04d", cont), col1, TipoAlineacion.IZQUIERDA, false);
			cadena += completaHasta(Mensajes.get("XDeposito") + " " + cont, col2, TipoAlineacion.IZQUIERDA, false);
			cadena += completaHasta(Generales.getFormatoDecimal(depositos.getFloat("Total"), "#,##0.00"), col3 + 4, TipoAlineacion.DERECHA, true);
			cadenaRecibo.append(cadena + "\r\n");
			cont++;
			sumDep += depositos.getFloat("Total");
		}

		imprimeLineaPunteada(cadenaRecibo, tamanioLetra.mLongTotal);

		float maximo = 0;
		if (aplicaDevolucion)
			maximo = totalVenta - totalDev - sumDep;
		else
			maximo = totalVenta - sumDep;

		cadena = completaHasta("  ", col1, TipoAlineacion.IZQUIERDA, false);
		cadena += completaHasta(Mensajes.get("XMaximoDepositar"), col2, TipoAlineacion.IZQUIERDA, false);
		cadena += completaHasta(Generales.getFormatoDecimal(maximo, "#,###,##0.00"), col3 + 4, TipoAlineacion.DERECHA, true);
		cadenaRecibo.append(cadena + "\r\n");

		cadenaRecibo.append("\r\n");
		cadenaRecibo.append("\r\n");
		cadenaRecibo.append("\r\n");
		cadenaRecibo.append("\r\n");
		cadenaRecibo.append("\r\n");
	}
	
	private static void imprimirPedidoCostena(Recibo recibo, StringBuilder cadenaRecibo, String TransProdID, boolean reimpresion, int tipo) throws Exception
	{

		TransProd trp = new TransProd();
		trp.TransProdID = TransProdID;
		BDVend.recuperar(trp);

		Cliente cli = new Cliente();
		cli.ClienteClave = trp.ClienteClave;
		BDVend.recuperar(cli);
		BDVend.recuperar(cli, ClienteDomicilio.class);

		/*
		 * Dia dia = new Dia(); dia.DiaClave = trp.DiaClave;
		 * BDVend.recuperar(dia);
		 */

		Ruta ruta = ((Ruta) Sesion.get(Campo.RutaActual));

		//Agenda agenda = Consultas.ConsultasAgenda.obtenerAgendaPorDiaClienteRutaVendedor(dia, ruta, ven, cli);

		String cadena = "";

		short iTipoPapel = ((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp;

		setTamanioDefault(((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp);
		TamanioLetra tamanioLetra;
		tamanioLetra = tamanioDefault;

		if (((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.ZEBRA_TERMICA2 || ((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.ZEBRA_CAMEO2)
		{
			cadena = "{" + tamanioLetra.mTamanio + " " + tamanioLetra.mAlto + "}";
		}
		else if (((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.INTERMEC_PR2 || ((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.INTERMEC_PR3)
		{
			//Se usa el mAlto para indentificar si la letra es normal o doble 0= normal 1= doble
			//En la cadena de los bytes no se debe dejar espacios, si no falla y se consideran hasta el momento
			//3 bytes en el mensaje, por lo que si se mete menos o mas, hay que cambiar el codigo en BluetoothPrint
			if (tamanioLetra.mAlto != 0)
			{
				cadena = "{27,33," + tamanioLetra.mTamanio + "}";
			}
			else
			{
				cadena = "{27,119," + tamanioLetra.mTamanio + "}";
			}
		}
		else
		{
			cadena = "{" + tamanioLetra.mTamanio + "}";
		}

		cadenaRecibo.append(cadena);

		crearEncabezadoSimple(recibo, cadenaRecibo, tamanioLetra);

		cadena = "";

		cadena = cadena + Mensajes.get("XRuta") + ": " + ruta.RUTClave;
		cadenaRecibo.append(cadena + "\r\n");

		if (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.PREVENTA || tipo == 21)
		{
			cadena = Mensajes.get("XPedido") + ": " + trp.Folio;
		}
		else
		{
			cadena = "# " + Mensajes.get("XNotaDeVenta") + ": " + trp.Folio;
		}
		cadenaRecibo.append(cadena + "\r\n");

		cadena = Mensajes.get("XFecha") + ": " + Generales.getFormatoFecha(trp.FechaHoraAlta, "dd/MM/yyyy");
		cadenaRecibo.append(cadena + "\r\n");

		cadena = Mensajes.get("XHora") + ": " + Generales.getFormatoFecha(trp.FechaHoraAlta, "hh:mm");
		cadenaRecibo.append(cadena + "\r\n");

		if (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.PREVENTA || tipo == 21)
		{
			cadena = Mensajes.get("XFechaEntrega") + ": " + Generales.getFormatoFecha(trp.FechaEntrega, "dd/MM/yyyy");
			cadenaRecibo.append(cadena + "\r\n");
		}
		cadenaRecibo.append("\r\n");

		if (reimpresion)
		{
			cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, Mensajes.get("XHoraReimpresion") + ": " + Generales.getFormatoFecha(Generales.getFechaHoraActual(), "hh:mm"), tamanioLetra.mLongTotal);
			//			cadena = Mensajes.get("XHoraReimpresion") + ": " + Generales.getFormatoFecha(Generales.getFechaHoraActual(), "hh:mm");
			cadenaRecibo.append(cadena + "\r\n");
			cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, Mensajes.get("XReimpresion").toUpperCase(), tamanioLetra.mLongTotal);
			cadenaRecibo.append(cadena + "\r\n");
			cadenaRecibo.append("\r\n");
		}

		cadena = Mensajes.get("XNegocio") + ": " + cli.RazonSocial;
		cadenaRecibo.append(cadena + "\r\n");

		cadena = Mensajes.get("XEncargado") + ": " + cli.NombreContacto;
		cadenaRecibo.append(cadena + "\r\n");

		cadena = Mensajes.get("XNumeroCliente") + ": " + cli.Clave;
		cadenaRecibo.append(cadena + "\r\n");

		cadena = Mensajes.get("XRFC") + ": " + cli.IdFiscal;
		cadenaRecibo.append(cadena + "\r\n");

		cadena = Mensajes.get("XDiaVisita") + ": " + new SimpleDateFormat("EEEE", new Locale("es", "ES")).format(((Dia) Sesion.get(Campo.DiaActual)).FechaCaptura);
		cadenaRecibo.append(cadena + "\r\n");

		cadena = Mensajes.get("XDireccion") + ": ";
		if (cli.ClienteDomicilio.size() > 0)
		{
			ClienteDomicilio cld = cli.ClienteDomicilio.get(0);
			cadena += cld.Calle + " #" + cld.Numero + " " + Mensajes.get("XCol") + " " + cld.Colonia;
		}
		cadenaRecibo.append(cadena + "\r\n");
		cadenaRecibo.append("\r\n");

		if (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.PREVENTA || tipo == 21)
		{
			cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, Mensajes.get("XPedido").toUpperCase(), tamanioLetra.mLongTotal);
		}
		else
		{
			cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, Mensajes.get("XNotaDeVenta").toUpperCase(), tamanioLetra.mLongTotal);
		}
		cadenaRecibo.append(cadena + "\r\n");
		cadenaRecibo.append("\r\n");

		int col11 = 3;
		int col12 = 11;
		int col13 = (tamanioLetra.mLongTotal - (col11 + col12 + 2));

		int col21 = (iTipoPapel != TipoPapel.INTERMEC_PR2 ? 8 : 6);
		int col22 = 5;
		int col23 = 8;
		int col24 = 8;
		int col25 = 8;

		cadena = completaHasta("#", col11, TipoAlineacion.IZQUIERDA, false);
		cadena += completaHasta(Mensajes.get("XCodigo"), col12, TipoAlineacion.IZQUIERDA, false);
		cadena += completaHasta(Mensajes.get("XDescripcion"), col13, TipoAlineacion.IZQUIERDA, (iTipoPapel != TipoPapel.INTERMEC_PR2));
		cadenaRecibo.append(cadena + "\r\n");

		cadena = completaHasta(Mensajes.get("XEmpaque") + " ", col21, TipoAlineacion.DERECHA, false);
		cadena += completaHasta(Mensajes.get("XCant."), col22, TipoAlineacion.IZQUIERDA, false);
		cadena += completaHasta(Mensajes.get("XPrecio"), col23, TipoAlineacion.IZQUIERDA, false);
		cadena += completaHasta(Mensajes.get("XSuge."), col24, TipoAlineacion.IZQUIERDA, true);
		//cadena += completaHasta("   ", col24, TipoAlineacion.IZQUIERDA, true);
		cadena += completaHasta(Mensajes.get("XImporte"), col25, TipoAlineacion.IZQUIERDA, (iTipoPapel != TipoPapel.INTERMEC_PR2));
		cadenaRecibo.append(cadena + "\r\n");

		imprimeLineaPunteada(cadenaRecibo, tamanioLetra.mLongTotal);

		//******** detalles *********

		ISetDatos detalles = ConsultasTransProdDetalle.obtenerDetallesTicketCostena(trp.TransProdID);
		float paquetes = 0;
		float cajas = 0;
		float articulos = 0;
		int iPartida = 1;
		while (detalles.moveToNext())
		{
			cadena = completaHasta(String.valueOf(iPartida), col11, TipoAlineacion.IZQUIERDA, false);
			cadena += completaHasta(detalles.getString("ProductoClave"), col12, TipoAlineacion.IZQUIERDA, false);
			//cadena += completaHasta(detalles.getString("Descripcion"), col13, TipoAlineacion.IZQUIERDA, ( iTipoPapel != TipoPapel.INTERMEC_PR2));
			cadena += completaHasta(detalles.getString("Descripcion"), col13, TipoAlineacion.IZQUIERDA, true);
			cadenaRecibo.append(cadena + "\r\n");

			//cadena = completaHasta("   "+ValoresReferencia.getDescripcion("UNIDADV", detalles.getString("TipoUnidad")), col21, TipoAlineacion.IZQUIERDA, false);
			cadena = completaHasta((iTipoPapel != TipoPapel.INTERMEC_PR2 ? "   " : " ") + ValoresReferencia.getDescripcion("UNIDADV", detalles.getString("TipoUnidad")), col21, TipoAlineacion.IZQUIERDA, false);
			cadena += completaHasta(detalles.getString("Cantidad"), col22, TipoAlineacion.IZQUIERDA, false);
			cadena += completaHasta(Generales.getFormatoDecimal(detalles.getDouble("Precio"), 2), col23, TipoAlineacion.DERECHA, (iTipoPapel != TipoPapel.INTERMEC_PR2));
			cadena += completaHasta(Generales.getFormatoDecimal(ListaPrecio.obtenerPrecioSugerido(trp.PCEPrecioClave, detalles.getString("ProductoClave"), detalles.getInt("TipoUnidad")), 2), col24, TipoAlineacion.DERECHA, true);
			//cadena += completaHasta("   ", col24, TipoAlineacion.DERECHA, true);
			cadena += completaHasta(Generales.getFormatoDecimal(detalles.getDouble("Importe"), 2), col25, TipoAlineacion.DERECHA, (iTipoPapel != TipoPapel.INTERMEC_PR2));
			cadena += " " + detalles.getString("Impuesto");
			cadenaRecibo.append(cadena + "\r\n");

			if (detalles.getInt("TipoUnidad") == 1 || detalles.getInt("TipoUnidad") == 2)
			{
				paquetes += detalles.getFloat("Cantidad");
			}
			else if (detalles.getInt("TipoUnidad") == 3)
			{
				cajas += detalles.getFloat("Cantidad");
			}
			articulos += detalles.getFloat("Cantidad");
			iPartida += 1;
		}
		detalles.close();

		//***************************

		imprimeLineaPunteada(cadenaRecibo, tamanioLetra.mLongTotal);
		cadenaRecibo.append("\r\n");

		if (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.PREVENTA || tipo == 21)
		{
			cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, Mensajes.get("XLeyendaPedidoCostena1"), tamanioLetra.mLongTotal);
			cadenaRecibo.append(cadena + "\r\n");
			cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, Mensajes.get("XLeyendaPedidoCostena2"), tamanioLetra.mLongTotal);
			cadenaRecibo.append(cadena + "\r\n");
			cadenaRecibo.append("\r\n");
		}
		else
		{
			cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, Mensajes.get("XLeyendaPedidoCostena5").toUpperCase(), tamanioLetra.mLongTotal);
			cadenaRecibo.append(cadena + "\r\n");
			cadenaRecibo.append("\r\n");
		}

		//Se comentan hasta que el cliente haga el cambio de sus valores por referencia
		//se quito el comentario, los valores por referencia son correctos
		cadena = Mensajes.get("XTotalPaquetes") + ":";
		cadena += completaHasta(Generales.getFormatoDecimal(paquetes, 0), 7, TipoAlineacion.DERECHA, false);
		cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, cadena, tamanioLetra.mLongTotal);
		cadenaRecibo.append(cadena + "\r\n");

		cadena = Mensajes.get("XTotalCajas") + ":";
		cadena += completaHasta(Generales.getFormatoDecimal(cajas, 0), 10, TipoAlineacion.DERECHA, false);
		cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, cadena, tamanioLetra.mLongTotal);
		cadenaRecibo.append(cadena + "\r\n");
		//********************************************************************************

		cadena = Mensajes.get("XTotalArticulos") + ":";
		cadena += completaHasta(Generales.getFormatoDecimal(articulos, 0), 6, TipoAlineacion.DERECHA, false);
		cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, cadena, tamanioLetra.mLongTotal);
		cadenaRecibo.append(cadena + "\r\n");
		cadenaRecibo.append("\r\n");

		cadena = Mensajes.get("XSubtotal") + ":";
		cadena += completaHasta(Generales.getFormatoDecimal(trp.Subtotal, "$#,##0.00"), 13, TipoAlineacion.DERECHA, false);
		cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, cadena, tamanioLetra.mLongTotal);
		cadenaRecibo.append(cadena + "\r\n");

		float ieps = ConsultasTPDImpuesto.obtenerIEPS(trp.TransProdID);
		cadena = Mensajes.get("XIEPS") + ":";
		cadena += completaHasta(Generales.getFormatoDecimal(ieps, "$#,##0.00"), 17, TipoAlineacion.DERECHA, false);
		cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, cadena, tamanioLetra.mLongTotal);
		cadenaRecibo.append(cadena + "\r\n");

		float iva = ConsultasTPDImpuesto.obtenerIVA(trp.TransProdID);
		cadena = Mensajes.get("XIVA") + ":";
		cadena += completaHasta(Generales.getFormatoDecimal(iva, "$#,##0.00"), 18, TipoAlineacion.DERECHA, false);
		cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, cadena, tamanioLetra.mLongTotal);
		cadenaRecibo.append(cadena + "\r\n");

		cadena = Mensajes.get("XTotalMin") + ":";
		cadena += completaHasta(Generales.getFormatoDecimal(trp.Subtotal + ieps + iva, "$#,##0.00"), 16, TipoAlineacion.DERECHA, false);
		cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, cadena, tamanioLetra.mLongTotal);
		cadenaRecibo.append(cadena + "\r\n");
		cadenaRecibo.append("\r\n");
		cadenaRecibo.append("\r\n");

		cadena = NumeroALetra.Convertir(Generales.getFormatoDecimal(trp.Subtotal + ieps + iva, "###0.00"), (iTipoPapel != TipoPapel.INTERMEC_PR2));
		ArrayList<String> importeLetra = ajustarDividirCadena(cadena, tamanioLetra.mLongTotal);
		for (String renglon : importeLetra)
		{
			cadenaRecibo.append(alineaTexto(BTIPALI.TipoAlineacion.CENTRO, renglon, tamanioLetra.mLongTotal) + "\r\n");
		}

		if (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.PREVENTA || tipo == 21)
		{
			cadenaRecibo.append("\r\n");
			cadenaRecibo.append("\r\n");
			cadenaRecibo.append("\r\n");
			cadenaRecibo.append("\r\n");
			cadenaRecibo.append("\r\n");
			cadenaRecibo.append("\r\n");

			cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, "______________________________", tamanioLetra.mLongTotal);
			cadenaRecibo.append(cadena + "\r\n");

			cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, Mensajes.get("XFirmaCliente"), tamanioLetra.mLongTotal);
			cadenaRecibo.append(cadena + "\r\n");
			cadenaRecibo.append("\r\n");

			cadena = alineaTexto(BTIPALI.TipoAlineacion.IZQUIERDA, Mensajes.get("XLeyendaPedidoCostena3"), tamanioLetra.mLongTotal);
			//cadenaRecibo.append(cadena + "\r\n");
			/*
			 * cadena = Mensajes.get("XLeyendaPedidoCostena3");
			 * ArrayList<String> leyenda = ajustarDividirCadena(cadena);
			 * for(String renglon : leyenda){
			 * cadenaRecibo.append(alineaTexto(BTIPALI.TipoAlineacion.CENTRO,
			 * renglon, tamanioLetra.mLongTotal) + "\r\n"); }
			 */

			//cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, Mensajes.get("XLeyendaPedidoCostena4"), tamanioLetra.mLongTotal);
			//cadenaRecibo.append(cadena + "\r\n");
			cadena += " " + Mensajes.get("XLeyendaPedidoCostena4");
			ArrayList<String> leyenda = ajustarDividirCadena(cadena, tamanioLetra.mLongTotal);
			for (String renglon : leyenda)
			{
				cadenaRecibo.append(alineaTexto(BTIPALI.TipoAlineacion.IZQUIERDA, renglon, tamanioLetra.mLongTotal) + "\r\n");
			}
		}

		cadenaRecibo.append("\r\n");
		cadenaRecibo.append("\r\n");
		cadenaRecibo.append("\r\n");
		cadenaRecibo.append("\r\n");
		cadenaRecibo.append("\r\n");
	}

	private static ArrayList<String> ajustarDividirCadena(String cadena, int totalLong)
	{
		ArrayList<String> cadenasAjustadas = new ArrayList<String>();
		String[] cadenas = cadena.split(" ");
		String ajusta = "";
		for (int i = 0; i < cadenas.length; i++)
		{
			//ajusta = cadenas[i];
			if (ajusta.length() + cadenas[i].length() + 1 <= totalLong)
			{
				ajusta += cadenas[i] + " ";
				if (i == cadenas.length - 1)
					cadenasAjustadas.add(ajusta);
			}
			else
			{
				cadenasAjustadas.add(ajusta);
				ajusta = "";
				ajusta = cadenas[i] + " ";
				if (i == cadenas.length - 1)
					cadenasAjustadas.add(ajusta);
			}
		}
		return cadenasAjustadas;
	}

	private static String textoCentradoConSimbolo(String texto, char simbolo, int longTotal)
	{
		String resultado = "";

		int i = 1;
		while (i < longTotal)
		{
			if (i == Math.round(longTotal / 2) - Math.round((texto.length() + 2) / 2))
			{
				resultado = resultado.concat(" " + texto + " ");
			}
			else
			{
				resultado = resultado.concat(String.valueOf(simbolo));
			}
		}
		return resultado;
	}

	private static void crearEncabezado(Recibo recibo, StringBuilder cadenaRecibo) throws Exception
	{
		//metodo general para crear el encabezado de los tickets amarrados
		ISetDatos encabezado = ConsultasImpresionTicket.obtenerEncabezado();

		TamanioLetra tamanioLetra;
		setTamanioDefault(recibo.TipoPapel);
		tamanioLetra = tamanioDefault;

		while (encabezado.moveToNext())
		{
			String cadena = "";

			cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, encabezado.getString("NombreEmpresa"), tamanioLetra.mLongTotal);
			cadenaRecibo.append(cadena + "\r\n");

			cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, encabezado.getString("RFC"), tamanioLetra.mLongTotal);
			cadenaRecibo.append(cadena + "\r\n");

			cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, encabezado.getString("Calle") + " " + encabezado.getString("Numero"), tamanioLetra.mLongTotal);
			cadenaRecibo.append(cadena + "\r\n");

			cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, encabezado.getString("Colonia"), tamanioLetra.mLongTotal);
			cadenaRecibo.append(cadena + "\r\n");

			cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, encabezado.getString("Ciudad"), tamanioLetra.mLongTotal);
			cadenaRecibo.append(cadena + "\r\n");

			cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, encabezado.getString("Region"), tamanioLetra.mLongTotal);
			cadenaRecibo.append(cadena + "\r\n");

			cadenaRecibo.append("\r\n");
			cadenaRecibo.append("\r\n");

			cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, ((Vendedor) Sesion.get(Campo.VendedorActual)).Nombre, tamanioLetra.mLongTotal);
			cadenaRecibo.append(cadena + "\r\n");
		}

		encabezado.close();
	}

	private static void crearEncabezadoSimple(Recibo recibo, StringBuilder cadenaRecibo, TamanioLetra tamanioLetra) throws Exception
	{
		//metodo general para crear el encabezado de los tickets amarrados
		ISetDatos encabezado = ConsultasImpresionTicket.obtenerEncabezado();

		/*
		 * TamanioLetra tamanioLetra; setTamanioDefault(recibo.TipoPapel);
		 * tamanioLetra = tamanioDefault;
		 */

		while (encabezado.moveToNext())
		{
			String cadena = "";

			cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, encabezado.getString("NombreEmpresa"), tamanioLetra.mLongTotal);
			cadenaRecibo.append(cadena + "\r\n");

			cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, encabezado.getString("RFC"), tamanioLetra.mLongTotal);
			cadenaRecibo.append(cadena + "\r\n");

			cadenaRecibo.append("\r\n");
			cadenaRecibo.append("\r\n");
		}

		encabezado.close();
	}

	private static void crearEncabezadoPie(Recibo recibo, short modoEncabezadoPie, Map<String, String> datosTicket, StringBuilder cadenaRecibo, boolean soloSubEmpresa) throws Exception
	{
		try
		{

			ISetDatos sdRECEncabezadoPie = ConsultasImpresionTicket.obtenerRECEncabezadoPiePorRECId(recibo.RECId, modoEncabezadoPie);
			cadenaRecibo.append("\r\n");

			TamanioLetra tamanioLetra;
			boolean cambiarLetra = false;
			int tipoFormato = 0;
			String cadena = "";

			if (modoEncabezadoPie == ModoEncabezadoPie.ENCABEZADO)
			{
				setTamanioDefault(recibo.TipoPapel);
				tamanioLetra = tamanioDefault;
				mTamanioActual = tamanioLetra;
				if (recibo.TipoPapel == TipoPapel.ZEBRA_TERMICA2 || recibo.TipoPapel == TipoPapel.ZEBRA_CAMEO2)
				{
					cadena = "{" + tamanioLetra.mTamanio + " " + tamanioLetra.mAlto + "}" + cadena;
				}
				else if (recibo.TipoPapel == TipoPapel.INTERMEC_PR2 || recibo.TipoPapel == TipoPapel.INTERMEC_PR3)
				{
					//Se usa el mAlto para indentificar si la letra es normal o doble 0= normal 1= doble
					//En la cadena de los bytes no se debe dejar espacios, si no falla y se consideran hasta el momento
					//3 bytes en el mensaje, por lo que si se mete menos o mas, hay que cambiar el codigo en BluetoothPrint
					if (tamanioLetra.mAlto != 0)
					{
						cadena = "{27,33," + tamanioLetra.mTamanio + "}" + cadena;
					}
					else
					{
						cadena = "{27,119," + tamanioLetra.mTamanio + "}" + cadena;
					}
				}
				else
				{
					cadena = "{" + tamanioLetra.mTamanio + "}" + cadena;
				}
				cadenaRecibo.append(cadena + "\r\n");
			}

			if (recibo.AgruparPorSubem && !soloSubEmpresa && modoEncabezadoPie == ModoEncabezadoPie.ENCABEZADO)
			{
				obtieneNotas(recibo, cadenaRecibo, modoEncabezadoPie);
			}

			while (sdRECEncabezadoPie.moveToNext())
			{
				tamanioLetra = TAMANIOS_LETRA.get(sdRECEncabezadoPie.getInt(sdRECEncabezadoPie.getColumnIndex("TipoLetra")));
				cambiarLetra = (tamanioLetra.mTamanio != mTamanioActual.mTamanio);
				mTamanioActual = tamanioLetra;
				ContentValues mapRECEncabezadoPie = new ContentValues();
				DatabaseUtils.cursorRowToContentValues((Cursor) sdRECEncabezadoPie.getOriginal(), mapRECEncabezadoPie);
				tipoFormato = mapRECEncabezadoPie.getAsShort("TipoFormato");
				cadena = obtieneCadena(mapRECEncabezadoPie, datosTicket, soloSubEmpresa);
				if (!cadena.equals(""))
				{
					cadena = alineaTexto(mapRECEncabezadoPie.getAsShort("TipoAlineacion"), cadena, tamanioLetra.mLongTotal);
					if (cambiarLetra || recibo.TipoPapel == TipoPapel.EXTECH_IMPACTO2 || recibo.TipoPapel == TipoPapel.INTERMEC_PR2 || recibo.TipoPapel == TipoPapel.INTERMEC_PR3)
					{
						if (recibo.TipoPapel == TipoPapel.ZEBRA_TERMICA2 || recibo.TipoPapel == TipoPapel.ZEBRA_CAMEO2)
						{
							cadena = "{" + tamanioLetra.mTamanio + " " + tamanioLetra.mAlto + "}" + cadena;
						}
						else if (recibo.TipoPapel == TipoPapel.INTERMEC_PR2 || recibo.TipoPapel == TipoPapel.INTERMEC_PR3)
						{
							//Se usa el mAlto para indentificar si la letra es normal o doble 0= normal 1= doble
							//En la cadena de los bytes no se debe dejar espacios, si no falla y se consideran hasta el momento
							//3 bytes en el mensaje, por lo que si se mete menos o mas, hay que cambiar el codigo en BluetoothPrint
							if (tamanioLetra.mAlto != 0)
							{
								cadena = "{27,33," + tamanioLetra.mTamanio + "}" + cadena;
							}
							else
							{
								cadena = "{27,119," + tamanioLetra.mTamanio + "}" + cadena;
							}
						}
						else
						{
							cadena = "{" + tamanioLetra.mTamanio + "}" + cadena;
						}
					}
					cadenaRecibo.append(cadena + "\r\n");
					//TODO falta toma de cadenas si el recibo es de facturacion	       
				}
			}

			sdRECEncabezadoPie.close();
			cadenaRecibo.append("\r\n");

			if (modoEncabezadoPie == ModoEncabezadoPie.PIE)
			{
				//TODO Paula, CrearEquivalencias......
			}

			if (!recibo.AgruparPorSubem && !soloSubEmpresa)
			{
				obtieneNotas(recibo, cadenaRecibo, modoEncabezadoPie);
			}

			if (modoEncabezadoPie == ModoEncabezadoPie.PIE)
			{
				for (int i = 0; i <= 8; i++)
				{
					cadenaRecibo.append("\r\n");
				}
			}

		}
		catch (Exception ex)
		{
			throw new Exception("CrearEncabezadoPie:" + ex.getMessage());
		}
	}

	private static void crearGenerales(Recibo oRecibo, Map<String, String> datosTicket, StringBuilder cadenaRecibo, String campoLlave) throws Exception
	{
		int yActual = -1;
		int xMax = Integer.parseInt(ConsultasImpresionTicket.obtenerMaxOrdenXRECContenido(oRecibo.RECId));
		;

		String cadena = "";

		ISetDatos sdRECContenido = ConsultasImpresionTicket.obtenerRECContenidoPorRECId(oRecibo.RECId);
		boolean cambiarLetra = false;
		TamanioLetra tamanioLetra = tamanioDefault;
		int anchoColumna = 0;
		String cadenaGenerales;
		while (sdRECContenido.moveToNext())
		{

			if (yActual != sdRECContenido.getInt(sdRECContenido.getColumnIndex("OrdenY")))
			{
				if (yActual != -1)
				{
					cadenaRecibo.append(cadena + "\r\n");
				}
				yActual = sdRECContenido.getInt(sdRECContenido.getColumnIndex("OrdenY"));
				cadena = "";
			}
			tamanioLetra = TAMANIOS_LETRA.get(sdRECContenido.getInt(sdRECContenido.getColumnIndex("TipoLetra")));
			cambiarLetra = (tamanioLetra.mTamanio != mTamanioActual.mTamanio);
			mTamanioActual = tamanioLetra;
			anchoColumna = Math.round(tamanioLetra.mLongTotal / xMax);
			ContentValues mapRECContenido = new ContentValues();
			DatabaseUtils.cursorRowToContentValues((Cursor) sdRECContenido.getOriginal(), mapRECContenido);
			cadenaGenerales = obtieneCadenaGenerales(mapRECContenido, datosTicket, campoLlave);
			cadenaGenerales = completaColumna(cadenaGenerales, anchoColumna);
			if (cambiarLetra || oRecibo.TipoPapel == TipoPapel.EXTECH_IMPACTO2 || oRecibo.TipoPapel == TipoPapel.INTERMEC_PR2 || oRecibo.TipoPapel == TipoPapel.INTERMEC_PR3)
			{
				if (oRecibo.TipoPapel == TipoPapel.ZEBRA_TERMICA2 || oRecibo.TipoPapel == TipoPapel.ZEBRA_CAMEO2)
				{
					cadena = "{" + tamanioLetra.mTamanio + " " + tamanioLetra.mAlto + "}" + cadena;
				}
				else if (oRecibo.TipoPapel == TipoPapel.INTERMEC_PR2 || oRecibo.TipoPapel == TipoPapel.INTERMEC_PR3)
				{
					//Se usa el mAlto para indentificar si la letra es normal o doble 0= normal 1= doble
					//En la cadena de los bytes no se debe dejar espacios, si no falla y se consideran hasta el momento
					//3 bytes en el mensaje, por lo que si se mete menos o mas, hay que cambiar el codigo en BluetoothPrint
					if (tamanioLetra.mAlto != 0)
					{
						cadena = "{27,33," + tamanioLetra.mTamanio + "}" + cadena;
					}
					else
					{
						cadena = "{27,119," + tamanioLetra.mTamanio + "}" + cadena;
					}
				}
				else
				{
					cadena = "{" + tamanioLetra.mTamanio + "}" + cadena;
				}
			}
			cadena = cadena.concat(cadenaGenerales);
		}

		sdRECContenido.close();
		if (yActual != -1)
		{
			cadenaRecibo.append(cadena + "\r\n");
		}

		cadenaRecibo.append("\r\n");
	}

	private static void crearDetalle(Recibo recibo, Map<String, String> datosTicket, StringBuilder cadenaRecibo, String campoLlave) throws Exception
	{
		if (Short.parseShort(datosTicket.get("TipoRecibo")) != 13 && !recibo.AgruparPorSubem)
		{
			Boolean[] byRefImprimirEtiquetas = new Boolean[1];
			byRefImprimirEtiquetas[0] = new Boolean(false);
			if (!obtieneTitulos(recibo, cadenaRecibo, datosTicket, byRefImprimirEtiquetas))
			{
				return;
			}
			if (byRefImprimirEtiquetas[0])
			{
				imprimeLineaPunteada(cadenaRecibo, mTamanioActual.mLongTotal);
			}
		}

		int tipoImpuesto = 0;
		if (oClienteAct != null)
		{
			tipoImpuesto = oClienteAct.TipoImpuesto;
		}

		obtieneDetalles(recibo, datosTicket, campoLlave, cadenaRecibo);

		if (Short.parseShort(datosTicket.get("Tipo")) == 1 && recibo.AgruparPorPrecio)
		{
			imprimeLineaPunteada(cadenaRecibo, mTamanioActual.mLongTotal);
			cadenaRecibo.append(Mensajes.get("XTotalPrecio"));
			ISetDatos sdUnidadPrecioCantidad = ConsultasImpresionTicket.obtenerUnidadPrecioCantidad(datosTicket.get("_Id"));
			while (sdUnidadPrecioCantidad.moveToNext())
			{
				String cad = completaHasta(ValoresReferencia.getDescripcion("UNIDADV", sdUnidadPrecioCantidad.getString(sdUnidadPrecioCantidad.getColumnIndex("TipoUnidad"))), 22, TipoAlineacion.IZQUIERDA, false);
				cad = cad.concat(completaHasta(Generales.getFormatoDecimal(sdUnidadPrecioCantidad.getDouble(sdUnidadPrecioCantidad.getColumnIndex("Precio")), "0.00"), 11, TipoAlineacion.DERECHA, false));
				cad = cad.concat(" = " + completaHasta(Generales.getFormatoDecimal(sdUnidadPrecioCantidad.getDouble(sdUnidadPrecioCantidad.getColumnIndex("CantidadProducto")), "0.##"), 5, TipoAlineacion.DERECHA, true));
			}
			sdUnidadPrecioCantidad.close();
		}
	}

	private static void obtieneDetalles(Recibo recibo, Map<String, String> datosTicket, String campoLlave, StringBuilder cadenaRecibo) throws Exception
	{
		try
		{
			ISetDatos sdREODetalle = ConsultasImpresionTicket.obtenerREODetallePorRECId(recibo.RECId);

			COTCampo oCOTCampoOrden = null;
			if (recibo.CORId != null && recibo.COTId != null && recibo.COCId != null)
			{
				oCOTCampoOrden = new COTCampo();
				oCOTCampoOrden.CORId = recibo.CORId;
				oCOTCampoOrden.COTId = recibo.COTId;
				oCOTCampoOrden.COCId = recibo.COCId;
				BDTerm.recuperar(oCOTCampoOrden);
			}

			CORTabla oCORTablaOrden = null;
			if (recibo.COTId != null && recibo.CORId != null)
			{
				oCORTablaOrden = new CORTabla();
				oCORTablaOrden.COTId = recibo.COTId;
				oCORTablaOrden.CORId = recibo.CORId;
				BDTerm.recuperar(oCORTablaOrden);
			}

			Hashtable<String, ArrayList<Object>> htCampos = new Hashtable<String, ArrayList<Object>>();
			ArrayList<String> arrTablas = new ArrayList<String>();

			String nombresCampos = "";
			while (sdREODetalle.moveToNext())
			{
				ArrayList<Object> config = new ArrayList<Object>();

				COTCampo oCOTCampo = new COTCampo();
				oCOTCampo.CORId = sdREODetalle.getString(sdREODetalle.getColumnIndex("CORId"));
				oCOTCampo.COTId = sdREODetalle.getString(sdREODetalle.getColumnIndex("COTId"));
				oCOTCampo.COCId = sdREODetalle.getString(sdREODetalle.getColumnIndex("COCId"));
				BDTerm.recuperar(oCOTCampo);

				CORTabla oCORTabla = new CORTabla();
				oCORTabla.COTId = sdREODetalle.getString(sdREODetalle.getColumnIndex("COTId"));
				oCORTabla.CORId = sdREODetalle.getString(sdREODetalle.getColumnIndex("CORId"));
				BDTerm.recuperar(oCORTabla);

				nombresCampos = nombresCampos.concat(oCORTabla.Nombre + "." + oCOTCampo.Nombre + ",");

				config.add(sdREODetalle.getShort(sdREODetalle.getColumnIndex("TipoAlineacion")));
				config.add(sdREODetalle.getShort(sdREODetalle.getColumnIndex("TipoSeparador")));

				if (Integer.parseInt(datosTicket.get("Tipo")) == 13)
				{
					if (oCOTCampo.Nombre.equalsIgnoreCase("FechaDeposito"))
					{
						config.add(10);
					}
					else if (oCOTCampo.Nombre.equalsIgnoreCase("TipoBanco"))
					{
						config.add(9);
					}
					else if (oCOTCampo.Nombre.equalsIgnoreCase("Referencia"))
					{
						config.add(12);
					}
					else if (oCOTCampo.Nombre.equalsIgnoreCase("Total"))
					{
						config.add(7);
					}
					else if (oCOTCampo.Nombre.equalsIgnoreCase("Ficha"))
					{
						config.add(6);
					}
					else if (oCOTCampo.Nombre.equalsIgnoreCase("TipoEfectivo"))
					{
						config.add(20);
					}
					else
					{
						config.add(sdREODetalle.getInt(sdREODetalle.getColumnIndex("Tamanio")));
					}
				}
				else
				{
					config.add(sdREODetalle.getInt(sdREODetalle.getColumnIndex("Tamanio")));
				}
				config.add(sdREODetalle.getShort(sdREODetalle.getColumnIndex("CantidadEspacio")));
				config.add(sdREODetalle.getShort(sdREODetalle.getColumnIndex("TipoEspacio")));
				config.add(sdREODetalle.getShort(sdREODetalle.getColumnIndex("TipoFormato")));
				config.add(sdREODetalle.getInt(sdREODetalle.getColumnIndex("OrdenY")));
				if (!htCampos.contains(oCOTCampo.Nombre))
				{
					htCampos.put(oCOTCampo.Nombre, config);
				}
				if (!arrTablas.contains(oCORTabla.Nombre))
				{
					arrTablas.add(oCORTabla.Nombre);
				}
			}

			sdREODetalle.close();

			if (nombresCampos.length() > 0)
			{
				nombresCampos = nombresCampos.substring(0, nombresCampos.length() - 1);
			}

			String tablas = arrTablas.toString().replace("[", "");
			tablas = tablas.replace("]", "");

			if (Short.parseShort(datosTicket.get("TipoRecibo")) == 13)
			{
				//TODO Paula, Implementar el GuardaDetallesPreliquidacion cuando se necesite.
			}
			else
			{
				guardaDetalles(recibo, nombresCampos, datosTicket, tablas, campoLlave, (oCORTablaOrden != null ? oCORTablaOrden.Nombre : ""), (oCOTCampoOrden != null ? oCOTCampoOrden.Nombre : ""), cadenaRecibo, htCampos);
			}
		}
		catch (Exception ex)
		{
			throw new Exception("obtieneDetalles" + ex.getMessage());
		}
	}

	private static void guardaDetalles(Recibo recibo, String campos, Map<String, String> datosTicket, String tabla, String campoLlave, String tablaOrden, String campoOrden, StringBuilder cadenaRecibo, Hashtable<String, ArrayList<Object>> htCampos) throws Exception
	{
		boolean incluirSubEmpresa = false;
		boolean incluirClaveProducto = false;
		boolean incluirTRPId = false;
		boolean incluirTPDId = false;
		boolean incluirPrecio = false;
		boolean incluirDesImp = false;
		boolean incluirCant = false;

		if (recibo.AgruparPorSubem)
		{
			incluirSubEmpresa = campos.toUpperCase().contains("SUBEMPRESAID");
			campos = campos.concat(", Producto.SubEmpresaId ");
		}

		if (recibo.IncluirImpuestos || Short.parseShort(datosTicket.get("Tipo")) == 8)
		{
			incluirClaveProducto = campos.toUpperCase().contains("PRODUCTOCLAVE");
			if (!incluirClaveProducto)
				campos = campos.concat(", Producto.ProductoClave");

			if (Short.parseShort(datosTicket.get("Tipo")) == 8)
			{
				incluirTRPId = campos.toUpperCase().contains("TRANSPRODID");
				if (!incluirTRPId)
					campos = campos.concat(", TransProdDetalle.TransProdID");

				incluirTPDId = campos.toUpperCase().contains("TRANSPRODDETALLEID");
				if (!incluirTPDId)
					campos = campos.concat(", TransProdDetalle.TransProdDetalleID");

				incluirPrecio = campos.toUpperCase().contains("PRECIO");
				if (!incluirPrecio)
					campos = campos.concat(", TransProdDetalle.Precio");

				incluirDesImp = campos.toUpperCase().contains("DESCUENTOIMP");
				if (!incluirDesImp)
					campos = campos.concat(", TransProdDetalle.DescuentoImp");

				incluirCant = campos.toUpperCase().contains("CANTIDAD");
				if (!incluirCant)
					campos = campos.concat(", TransProdDetalle.Cantidad");
			}
		}

		ISetDatos sdDetalleRecibo = ConsultasImpresionTicket.obtenerDetalleRecibo(datosTicket.get("_Id"), Short.parseShort(datosTicket.get("Tipo")), Short.parseShort(datosTicket.get("TipoRecibo")), tabla, campos, campoLlave, tablaOrden, campoOrden, recibo.AgruparPorSubem);

		String subEmpresaAct = "";
		int contador = 0;

		while (sdDetalleRecibo.moveToNext())
		{
			if (recibo.AgruparPorSubem)
			{
				if (!subEmpresaAct.equalsIgnoreCase("SubEmpresaId"))
				{
					cadenaRecibo.append("\r\n");
					if (contador > 0)
					{
						cadenaRecibo.append("\r\n");
						cadenaRecibo.append("\r\n");
					}
					subEmpresaAct = sdDetalleRecibo.getString(sdDetalleRecibo.getColumnIndex("SubEmpresaId"));

					Map<String, String> datosDetalle = new HashMap<String, String>();

					datosDetalle.put("_Id", datosTicket.get("_Id"));
					datosDetalle.put("TipoRecibo", datosTicket.get("TipoRecibo"));
					datosDetalle.put("ClienteClave", datosTicket.get("ClienteClave"));
					datosDetalle.put("SubEmpresaId", subEmpresaAct);
					crearEncabezadoPie(recibo, ModoEncabezadoPie.ENCABEZADO, datosDetalle, cadenaRecibo, true);
					Boolean[] byRefImprimirEtiquetas = new Boolean[1];
					byRefImprimirEtiquetas[0] = new Boolean(false);
					obtieneTitulos(recibo, cadenaRecibo, datosTicket, byRefImprimirEtiquetas);
					if (byRefImprimirEtiquetas[0])
					{
						imprimeLineaPunteada(cadenaRecibo, mTamanioActual.mLongTotal);
					}
				}
				contador++;
			}

			int renglon = 0;
			String cadena = "";
			ArrayList<Object> config = new ArrayList<Object>();
			if (sdDetalleRecibo.getColumnCount() > 0)
			{
				config = htCampos.get(sdDetalleRecibo.getColumnName(0));
				renglon = Integer.parseInt(config.get(6).toString());
			}

			String tmpCadena = "";
			String nombreColumna = "";
			for (int i = 0; i < sdDetalleRecibo.getColumnCount(); i++)
			{
				nombreColumna = sdDetalleRecibo.getColumnName(i);
				if (nombreColumna.equalsIgnoreCase("SubEmpresaId") && !incluirSubEmpresa)
					continue;
				if (nombreColumna.equalsIgnoreCase("ProductoClave") && recibo.IncluirImpuestos && !incluirClaveProducto)
					continue;
				if (Short.parseShort(datosTicket.get("Tipo")) == 8)
				{
					if (nombreColumna.equalsIgnoreCase("TransProdId") && !incluirTRPId)
						continue;
					if (nombreColumna.equalsIgnoreCase("TransProdDetalleId") && !incluirTPDId)
						continue;
					if (nombreColumna.equalsIgnoreCase("Precio") && !incluirPrecio)
						continue;
					if (nombreColumna.equalsIgnoreCase("DescuentoImp") && !incluirDesImp)
						continue;
					if (nombreColumna.equalsIgnoreCase("Cantidad") && !incluirCant)
						continue;
				}

				if (campoLlave.equalsIgnoreCase("TransProdId") && nombreColumna.equalsIgnoreCase("TipoUnidad"))
				{
					tmpCadena = ValoresReferencia.getDescripcion("UNIDADV", sdDetalleRecibo.getString(i));
				}
				else if (campoLlave.equalsIgnoreCase("ABNId") && nombreColumna.equalsIgnoreCase("TipoPago"))
				{
					tmpCadena = ValoresReferencia.getDescripcion("PAGO", sdDetalleRecibo.getString(i));
				}
				else if (campoLlave.equalsIgnoreCase("ABNId") && nombreColumna.equalsIgnoreCase("TipoBanco"))
				{
					tmpCadena = (sdDetalleRecibo.isNull(i) ? "" : ValoresReferencia.getDescripcion("TBANCO", sdDetalleRecibo.getString(i)));
				}else if (nombreColumna.equalsIgnoreCase("TipoMotivo")){
					tmpCadena = (sdDetalleRecibo.isNull(i) ? "" : ValoresReferencia.getDescripcion("TRPMOT", sdDetalleRecibo.getString(i)));
				}
				else if (nombreColumna.equalsIgnoreCase("Precio"))
				{
					if (recibo.IncluirImpuestos)
					{
						//TODO: Paula, implementar cuando este la parte de los impuestos
					}
					else if (Short.parseShort(datosTicket.get("Tipo")) == 8)
					{
						//TODO: Paula, implementar cuando se incluya la factura
					}
					else
					{
						tmpCadena = sdDetalleRecibo.getString(i);
					}
				}
				else if (Short.parseShort(datosTicket.get("Tipo")) == 8 && nombreColumna.equalsIgnoreCase("DescuentoImp"))
				{
					//TODO: Paula, cuando se implemente la facturacion y los impuestos
				}
				else if (Short.parseShort(datosTicket.get("Tipo")) == 8 && nombreColumna.equalsIgnoreCase("SubTotal"))
				{
					//TODO: Paula, cuando se implemente la facturacion y los impuestos
				}
				else
				{
					if (sdDetalleRecibo.isNull(i))
					{
						tmpCadena = "";
					}
					else
					{
						tmpCadena = sdDetalleRecibo.getString(i).trim();
					}
				}

				if (htCampos.containsKey(nombreColumna))
				{
					config = htCampos.get(nombreColumna);
					tmpCadena = completaColumna(tmpCadena, Integer.parseInt(config.get(2).toString()), Integer.parseInt(config.get(0).toString()), Integer.parseInt(config.get(1).toString()), Integer.parseInt(config.get(5).toString()));
					if (Integer.parseInt(config.get(3).toString()) > 0)
					{
						tmpCadena = agregarEspaciosColumna(Integer.parseInt(config.get(4).toString()), tmpCadena, Integer.parseInt(config.get(3).toString()));
					}

					if (renglon != Integer.parseInt(config.get(6).toString()))
					{
						cadenaRecibo.append(cadena + "\r\n");
						cadena = "";
					}
					renglon = Integer.parseInt(config.get(6).toString());
				}
				cadena = cadena.concat(tmpCadena);
			}
			cadenaRecibo.append(cadena + "\r\n");
		}

		sdDetalleRecibo.close();
	}

	private static void imprimeLineaPunteada(StringBuilder cadenaRecibo, int longTotal)
	{
		char c = '-';
		char[] chars = new char[longTotal];
		Arrays.fill(chars, c);
		cadenaRecibo.append(String.valueOf(chars) + "\r\n");
	}

	private static boolean obtieneTitulos(Recibo recibo, StringBuilder cadenaRecibo, Map<String, String> datosTicket, Boolean[] byRefImprimioEtiquetas) throws Exception
	{
		return obtieneTitulos(recibo, cadenaRecibo, datosTicket, false, false, byRefImprimioEtiquetas);
	}

	private static boolean obtieneTitulos(Recibo recibo, StringBuilder cadenaRecibo, Map<String, String> datosTicket, boolean bPreliquidacion, boolean bDepositos, Boolean[] byRefImprimioEtiquetas) throws Exception
	{
		int yActual = -1;

		try
		{
			int xMax = ConsultasImpresionTicket.obtenerMaxOrdenXREODetalle(recibo.RECId);
			if (xMax <= 0)
			{
				return false;
			}

			ISetDatos sdREODetalle = ConsultasImpresionTicket.obtenerREODetallePorRECId(recibo.RECId);
			String cadena = "";
			boolean primerColumna = true;
			boolean cambiarLetra = false;
			TamanioLetra tamanioLetra = tamanioDefault;
			String cadenaDetallesT = "";
			while (sdREODetalle.moveToNext())
			{
				if (yActual != sdREODetalle.getInt(sdREODetalle.getColumnIndex("OrdenY")))
				{
					if (yActual != -1)
					{
						cadenaRecibo.append(cadena + "\r\n");
					}
					yActual = sdREODetalle.getInt(sdREODetalle.getColumnIndex("OrdenY"));
					cadena = "";
				}
				if (primerColumna)
				{
					tamanioLetra = TAMANIOS_LETRA.get(sdREODetalle.getInt(sdREODetalle.getColumnIndex("TipoLetra")));
					cambiarLetra = (tamanioLetra.mTamanio != mTamanioActual.mTamanio);
					mTamanioActual = tamanioLetra;
					primerColumna = false;
				}
				else
				{
					cambiarLetra = false;
				}
				ContentValues mapREODetalle = new ContentValues();
				DatabaseUtils.cursorRowToContentValues((Cursor) sdREODetalle.getOriginal(), mapREODetalle);
				cadenaDetallesT = obtieneCadenaDetallesT(datosTicket, mapREODetalle, bPreliquidacion, bDepositos, byRefImprimioEtiquetas);
				if (cambiarLetra || recibo.TipoPapel == TipoPapel.EXTECH_IMPACTO2)
				{
					if (recibo.TipoPapel == TipoPapel.ZEBRA_TERMICA2 || recibo.TipoPapel == TipoPapel.ZEBRA_CAMEO2)
					{
						cadenaDetallesT = "{" + tamanioLetra.mTamanio + " " + tamanioLetra.mAlto + "}" + cadenaDetallesT;
					}
					else
					{
						cadenaDetallesT = "{" + tamanioLetra.mTamanio + "}" + cadenaDetallesT;
					}
				}
				cadena = cadena.concat(cadenaDetallesT);
			}
			sdREODetalle.close();
			if (yActual != -1)
			{
				cadenaRecibo.append(cadena + "\r\n");
			}
		}
		catch (Exception ex)
		{
			throw new Exception(ex.getMessage());
			//MsgBox(ex.Message, MsgBoxStyle.Information, "ObtieneTitulos")
		}
		return true;
	}

	private static String obtieneCadenaDetallesT(Map<String, String> datosTicket, ContentValues mapREODetalle, boolean bPreliquidacion, boolean bDeposito, Boolean[] byRefImprimioEtiquetas) throws Exception
	{
		String cadena = "";
		boolean recuperar = true;
		if (mapREODetalle.getAsShort("TipoEtiqueta") == 1)
		{
			COTCampo oCOTCampo = new COTCampo();
			oCOTCampo.CORId = mapREODetalle.getAsString("CORId");
			oCOTCampo.COTId = mapREODetalle.getAsString("COTId");
			oCOTCampo.COCId = mapREODetalle.getAsString("COCId");
			BDTerm.recuperar(oCOTCampo);

			if (bPreliquidacion)
			{
				if (bDeposito)
				{
					recuperar = (CAMPOS_PRELIQUIDACION_DEPOSITOS.contains(oCOTCampo.Nombre));
				}
				else
				{
					recuperar = (CAMPOS_PRELIQUIDACION_NODEPOSITOS.contains(oCOTCampo.Nombre));
				}
			}
			if (recuperar)
			{
				int tamanio = 0;
				cadena = oCOTCampo.Descripcion;
				if (bPreliquidacion)
				{
					if (oCOTCampo.Nombre.equalsIgnoreCase("FechaDeposito"))
					{
						tamanio = 10;
					}
					else if (oCOTCampo.Nombre.equalsIgnoreCase("TipoBanco"))
					{
						tamanio = 9;
					}
					else if (oCOTCampo.Nombre.equalsIgnoreCase("Referencia"))
					{
						tamanio = 12;
					}
					else if (oCOTCampo.Nombre.equalsIgnoreCase("Total"))
					{
						tamanio = 7;
					}
					else if (oCOTCampo.Nombre.equalsIgnoreCase("Ficha"))
					{
						tamanio = 6;
					}
					else if (oCOTCampo.Nombre.equalsIgnoreCase("TipoEfectivo"))
					{
						tamanio = 19;
					}
					else
					{
						tamanio = mapREODetalle.getAsInteger("Tamanio");
					}
				}
				else
				{
					tamanio = mapREODetalle.getAsInteger("Tamanio");
				}
				cadena = completaColumna(cadena, tamanio);
				if (mapREODetalle.getAsShort("TipoSeparador") != 0)
				{
					cadena = cadena.concat(ValoresReferencia.getDescripcion("SEPARADO", mapREODetalle.getAsString("TipoSeparador")));
				}
				cadena = agregarEspaciosColumna(mapREODetalle.getAsInteger("TipoEspacio"), cadena, mapREODetalle.getAsInteger("CantidadEspacio"));
			}
			byRefImprimioEtiquetas[0] = true;
		}
		return cadena;
	}

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

	private static String completaHasta(String texto, int espacios, short tipoAlineacion, boolean ultimaColumna)
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

	private static void obtieneNotas(Recibo recibo, StringBuilder cadenaRecibo, short modoEncabezadoPie)
	{

		ISetDatos sdRECNota = ConsultasImpresionTicket.obtenerRECNotaPorRECId(recibo.RECId, modoEncabezadoPie);
		String nota = "";
		TamanioLetra tamanioLetra = tamanioDefault;
		boolean cambiarLetra = false;
		while (sdRECNota.moveToNext())
		{
			tamanioLetra = TAMANIOS_LETRA.get(sdRECNota.getInt(sdRECNota.getColumnIndex("TipoLetra")));
			cambiarLetra = (tamanioLetra.mTamanio != mTamanioActual.mTamanio);
			mTamanioActual = tamanioLetra;
			nota = alineaTexto(sdRECNota.getShort(sdRECNota.getColumnIndex("TipoAlineacion")), sdRECNota.getString(sdRECNota.getColumnIndex("Texto")), tamanioLetra.mLongTotal);
			if (cambiarLetra || recibo.TipoPapel == TipoPapel.EXTECH_IMPACTO2)
			{
				if (recibo.TipoPapel == TipoPapel.ZEBRA_CAMEO2 || recibo.TipoPapel == TipoPapel.ZEBRA_TERMICA2)
				{
					//					nota = nota.concat("{" + tamanioLetra.mTamanio + " " + tamanioLetra.mAlto + "}" + nota + "\r\n");
					nota = "{" + tamanioLetra.mTamanio + " " + tamanioLetra.mAlto + "}" + nota + "\r\n";
				}
				else
				{
					//					nota = nota.concat("{" + tamanioLetra.mTamanio + "}" + nota + "\r\n");
					nota = "{" + tamanioLetra.mTamanio + "}" + nota + "\r\n";
				}
			}

			cadenaRecibo.append(nota + "\r\n");

			for (int i = 0; i < sdRECNota.getInt(sdRECNota.getColumnIndex("RenglonBlanco")); i++)
			{
				cadenaRecibo.append("\r\n");
			}
		}

		if (modoEncabezadoPie == ModoEncabezadoPie.ENCABEZADO)
		{
			cadenaRecibo.append(textoCentrado(Mensajes.get("Ximpresion") + ": " + Generales.getFechaHoraActualStr("dd/MM/yy HH:mm:ss"), tamanioLetra.mLongTotal) + "\r\n");
			cadenaRecibo.append("\r\n");
		}

		sdRECNota.close();
	}

	private static String obtieneCadena(ContentValues mapRECEncabezadoPie, Map<String, String> datosTicket, boolean soloSubempresa) throws Exception
	{
		String cadena = "";
		COTCampo oCOTCampo = new COTCampo();
		oCOTCampo.CORId = mapRECEncabezadoPie.getAsString("CORId");
		oCOTCampo.COTId = mapRECEncabezadoPie.getAsString("COTId");
		oCOTCampo.COCId = mapRECEncabezadoPie.getAsString("COCId");
		BDTerm.recuperar(oCOTCampo);

		CORTabla oCORTabla = new CORTabla();
		oCORTabla.COTId = mapRECEncabezadoPie.getAsString("COTId");
		oCORTabla.CORId = mapRECEncabezadoPie.getAsString("CORId");
		BDTerm.recuperar(oCORTabla);
		short tipoRecibo = Short.parseShort(datosTicket.get("TipoRecibo"));

		if (soloSubempresa && !oCORTabla.Nombre.equalsIgnoreCase("SubEmpresa"))
			return "";
		if (oCORTabla.Nombre.equalsIgnoreCase("SubEmpresa") && datosTicket.get("SubEmpresaID").toString().equals(""))
			return "";

		if (mapRECEncabezadoPie.getAsShort("TipoEtiqueta") == 1)
		{
			cadena = cadena.concat(oCOTCampo.Descripcion);
			if (mapRECEncabezadoPie.getAsShort("TipoSeparador") != 0)
			{
				cadena = cadena.concat(ValoresReferencia.getDescripcion("SEPARADO", mapRECEncabezadoPie.getAsString("TipoSeparador")));
			}
		}

		String valorCampo = "";

		if (oCORTabla.Nombre.equalsIgnoreCase("Preliquidacion") && oCORTabla.Nombre.equalsIgnoreCase("Preliquidacion"))
		{
			if (datosTicket.containsKey("TotalPreliquidado"))
			{
				cadena = cadena.concat(Generales.getFormatoDecimal(Double.parseDouble(datosTicket.get("TotalPreliquidado")), "#,##0.00"));
			}
		}
		else if ((tipoRecibo == 24 || tipoRecibo == 8) && oCORTabla.Nombre.equalsIgnoreCase("TransProd") && oCOTCampo.Nombre.equalsIgnoreCase("Impuesto") && (oClienteAct != null && oClienteAct.DesgloseImpuesto))
		{
			//TODO Pendiente Recibo Facturacion
		}
		else if ((tipoRecibo == 24 || tipoRecibo == 8) && oCORTabla.Nombre.equalsIgnoreCase("TransProd") && (oCOTCampo.Nombre.equalsIgnoreCase("DescuentoImp") || oCOTCampo.Nombre.equalsIgnoreCase("SubTDetalle")) && (oClienteAct != null && oClienteAct.DesgloseImpuesto))
		{
			//TODO Pendiente Recibo Facturacion
		}
		else
		{
			if (oCORTabla.Nombre.equalsIgnoreCase("FolioFiscal") && tipoRecibo == 24)
			{
				//TODO Pendiente Recibo Facturacion
			}
			else if ((oCORTabla.Nombre.equalsIgnoreCase("TPDDes") || oCORTabla.Nombre.equalsIgnoreCase("TpdDesVendedor")) && oCOTCampo.Nombre.equalsIgnoreCase("desImorte") && tipoRecibo == 24)
			{
				//TODO Pendiente Recibo Facturacion
			}
			else if (oCORTabla.Nombre.equalsIgnoreCase("TransProd") && tipoRecibo == 26)
			{
				//TODO Pendiente Recibo Liquidacion de Consigna
			}
			else
			{
				String id = "";
				if (oCORTabla.Nombre.equalsIgnoreCase("Cliente"))
				{
					id = datosTicket.get("ClienteClave");
				}
				else if (oCORTabla.Nombre.equalsIgnoreCase("SubEmpresa"))
				{
					id = datosTicket.get("SubEmpresaID");
				}
				else
				{
					id = datosTicket.get("_Id");
				}

				valorCampo = ConsultasImpresionTicket.obtenerValorCampo(id, oCOTCampo.Nombre, oCORTabla.Nombre, tipoRecibo, oCOTCampo.TipoCampo);
			}
		}
		if (mapRECEncabezadoPie.getAsShort("TipoFormato") == 1)
		{
			cadena = cadena.concat(Generales.getFormatoDecimal(Double.parseDouble(valorCampo), "#,##0"));
		}
		else if (mapRECEncabezadoPie.getAsShort("TipoFormato") == 2)
		{
			cadena = cadena.concat(Generales.getFormatoDecimal(Double.parseDouble(valorCampo), "#,##0.00"));
		}
		else
		{
			cadena = cadena.concat(valorCampo);
		}

		return cadena;

	}

	private static String obtieneCadenaGenerales(ContentValues mapRECContenido, Map<String, String> datosTicket, String campoLlave) throws Exception
	{
		String cadena = "";

		COTCampo oCOTCampo = new COTCampo();
		oCOTCampo.CORId = mapRECContenido.getAsString("CORId");
		oCOTCampo.COTId = mapRECContenido.getAsString("COTId");
		oCOTCampo.COCId = mapRECContenido.getAsString("COCId");
		BDTerm.recuperar(oCOTCampo);

		CORTabla oCORTabla = new CORTabla();
		oCORTabla.COTId = mapRECContenido.getAsString("COTId");
		oCORTabla.CORId = mapRECContenido.getAsString("CORId");
		BDTerm.recuperar(oCORTabla);

		short tipoRecibo = Short.parseShort(datosTicket.get("TipoRecibo"));

		if (mapRECContenido.getAsShort("TipoEtiqueta") == 1)
		{
			cadena = cadena.concat(oCOTCampo.Descripcion);
			if (mapRECContenido.getAsShort("TipoSeparador") != 0)
			{
				cadena = cadena.concat(ValoresReferencia.getDescripcion("SEPARADO", mapRECContenido.getAsString("TipoSeparador")));
			}
		}

		String valorCampo = "";
		if (campoLlave.equalsIgnoreCase("TransProdID") && oCOTCampo.Nombre.equalsIgnoreCase("DiasCredito") && Short.parseShort(datosTicket.get("Tipo")) == 8)
		{
			valorCampo = ConsultasImpresionTicket.obtenerDiasCredito(datosTicket.get("_Id"));
		}
		else
		{
			valorCampo = ConsultasImpresionTicket.obtenerValorCampo(datosTicket.get("_Id"), oCOTCampo.Nombre, oCORTabla.Nombre, tipoRecibo, oCOTCampo.TipoCampo);
		}

		if (campoLlave.equalsIgnoreCase("TransProdId"))
		{
			if (oCOTCampo.Nombre.equalsIgnoreCase("TipoMotivo"))
			{
				cadena = cadena.concat(ValoresReferencia.getDescripcion("TRPMOT", valorCampo));
			}
			else if (oCOTCampo.Nombre.equalsIgnoreCase("TipoFase"))
			{
				cadena = cadena.concat(ValoresReferencia.getDescripcion("TRPFASE", valorCampo));
			}
			else if (oCOTCampo.Nombre.equalsIgnoreCase("CFVTipo"))
			{
				cadena = cadena.concat(ValoresReferencia.getDescripcion("FVENTA", valorCampo));
			}
			else
			{
				cadena = cadena.concat(valorCampo);
			}
		}
		else
		{
			cadena = cadena.concat(valorCampo);
		}

		return cadena;
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

	//************************************************* reportes *************************************************************************

	public static void imprimirReporte(int reporte, Boolean logoSoloPrimerRecibo, IVista vista) throws ControlError, Exception
	{
		String nombreArchivo = "";
		Hashtable<String, ContentValues> archivosGenerados = new Hashtable<String, ContentValues>();

		ConfiguracionLocal conf = (ConfiguracionLocal) Sesion.get(Campo.ConfiguracionLocal);
		File impresion = new File(conf.get(CampoConfiguracion.DIRECTORIO_TRABAJO).toString());
		impresion = new File(impresion, "impresion");
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
		Recibo reciboAct = new Recibo();
		reciboAct.Tipo = (short) reporte;
		reciboAct.TipoPapel = ((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp;

		nombreArchivo = generarArchivoReporte(reporte, impresion.getAbsolutePath(), reciboAct, imprimeLogo, byRefMsgError);

		if (!archivosGenerados.containsKey(nombreArchivo) && !nombreArchivo.equals(""))
		{
			ContentValues valoresRecibo = new ContentValues();
			valoresRecibo.put("TipoPapel", reciboAct.TipoPapel);
			valoresRecibo.put("MostrarLogo", reciboAct.MostrarLogo);
			archivosGenerados.put(nombreArchivo, valoresRecibo);
		}

		//imprimir txt generado
		/*
		 * Enumeration<String> e = archivosGenerados.keys(); String archivo =
		 * ""; while (e.hasMoreElements()){ archivo = e.nextElement();
		 * BluetoothPrint(vista, new File(impresion,
		 * archivo).getAbsolutePath(),archivosGenerados
		 * .get(archivo).getAsShort("TipoPapel"),
		 * archivosGenerados.get(archivo).getAsBoolean("MostrarLogo")); }
		 */

		Sesion.set(Campo.ArchivosGenerados, archivosGenerados);
		//mostrar vista previa PDF
		File file = new File(impresion.getAbsolutePath() + "/" + nombreArchivo + ".pdf");
		Intent intent = new Intent();
		intent.putExtra("idReporte", reporte);
		intent.setDataAndType(Uri.fromFile(file), "application/pdf");
		intent.setClass(((Context) vista), PDFViewer.class);
		intent.setAction("android.intent.action.VIEW");
		((Context) vista).startActivity(intent);
	}

	private static String generarArchivoReporte(int reporte, String directorioArchivo, Recibo recibo, boolean imprimeLogo, String[] byRefMsgError) throws Exception
	{
		String nombreArchivo = "";
		try
		{
			nombreArchivo = "Reportes" + Integer.toString(reporte);
			File archivoRecibo = new File(directorioArchivo, nombreArchivo);
			if (!archivoRecibo.exists())
			{
				if (!archivoRecibo.createNewFile())
				{
					byRefMsgError[0] = "El archivo no se pudo crear";
					return "";
				}
			}

			//crear el archivo PDF y pasarlo al metodo que genera el reporte para generar el pdf
			Document document = new Document();
			PdfWriter.getInstance(document, new FileOutputStream(directorioArchivo + "/Reportes" + Integer.toString(reporte) + ".pdf"));
			document.open();

			//Valores default
			//int columnasRecibo  = 48;
			StringBuilder cadenaRecibo = new StringBuilder();

			if (imprimeLogo)
			{
				cadenaRecibo.append("IMPRIME_LOGO\r\n");
			}

			switch (reporte)
			{
			//resumen movimientos costeña
				case 1:
					generarReporteResumenMovsCostena(reporte, cadenaRecibo, document);
					break;
				case 2:
					generarReporteInventarioCosteña(reporte, cadenaRecibo, document);
					break;
				case 3:
					generarReporteCuadreDeCajaCostena(reporte, cadenaRecibo, document);
					break;
				case 4:
					generarReporteLiquidacionVtasCostena(reporte, cadenaRecibo, document);
					break;
			}

			OutputStream f1 = new FileOutputStream(archivoRecibo, true);
			f1.write(cadenaRecibo.toString().getBytes());
			Log.d("ImpresioTicket", cadenaRecibo.toString());
			f1.close();

			document.close(); //cerrar el PDF

		}
		catch (Exception ex)
		{
			throw new Exception("Error al generar ticket:" + ex.getMessage());
		}
		return nombreArchivo;
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

	/*public static String ImprimirReporteCosteña(StringBuilder byRefMsgError, int reporte) throws Exception
	{
		String nombreArchivo = "";

		try
		{
			nombreArchivo = "Recibos" + Short.toString(((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp);
			ConfiguracionLocal conf = (ConfiguracionLocal) Sesion.get(Campo.ConfiguracionLocal);
			File impresion = new File(conf.get(CampoConfiguracion.DIRECTORIO_TRABAJO).toString());
			impresion = new File(impresion, "impresion");
			if (!impresion.exists())
			{
				if (!impresion.mkdirs())
				{
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

			File archivoRecibo = new File(impresion.getAbsolutePath(), nombreArchivo);
			if (!archivoRecibo.exists())
			{
				if (!archivoRecibo.createNewFile())
				{
					//TODO Paula, cambiar mensaje
					byRefMsgError.append("El archivo no se pudo crear");
					return "";
				}
			}

			//Valores default
			//int columnasRecibo  = 48;
			StringBuilder cadenaRecibo = new StringBuilder();

			String cadena = "";
			String texto = "";
			int columna = 10;
			int max = 38;
			ISetDatos idataRuta = Consultas.ConsultasRuta.obtenerRutas();
			idataRuta.moveToFirst();
			Ruta ruta = new Ruta();
			ruta.RUTClave = idataRuta.getString("RUTClave");
			BDVend.recuperar(ruta);
			idataRuta.close();

			setTamanioDefault(((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp);
			TamanioLetra tamanioLetra;
			tamanioLetra = tamanioDefault;

			if (((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.ZEBRA_TERMICA2 || ((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.ZEBRA_CAMEO2)
			{
				cadena = "{" + tamanioLetra.mTamanio + " " + tamanioLetra.mAlto + "}";
			}
			else if (((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.INTERMEC_PR2 || ((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.INTERMEC_PR3)
			{
				//Se usa el mAlto para indentificar si la letra es normal o doble 0= normal 1= doble
				//En la cadena de los bytes no se debe dejar espacios, si no falla y se consideran hasta el momento
				//3 bytes en el mensaje, por lo que si se mete menos o mas, hay que cambiar el codigo en BluetoothPrint
				if (tamanioLetra.mAlto != 0)
				{
					cadena = "{27,33," + tamanioLetra.mTamanio + "}";
				}
				else
				{
					cadena = "{27,119," + tamanioLetra.mTamanio + "}";
				}
			}
			else
			{
				cadena = "{" + tamanioLetra.mTamanio + "}";
			}
			texto = ValoresReferencia.getDescripcion("REPORTEA", String.valueOf(reporte));
			cadena = cadena + alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, tamanioLetra.mLongTotal);

			cadenaRecibo.append(cadena + "\r\n");
			cadenaRecibo.append("\r\n");

			texto = Mensajes.get("XImpresion") + ": " + Generales.getFechaHoraActualStr("dd/MM/yyyy hh:mm:ss");
			cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, tamanioLetra.mLongTotal);
			cadenaRecibo.append(cadena + "\r\n");

			texto = Mensajes.get("XRuta") + ": " + ruta.RUTClave;
			cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, tamanioLetra.mLongTotal);
			cadenaRecibo.append(cadena + "\r\n");
			cadenaRecibo.append("\r\n");

			ISetDatos info;
			float total = 0;
			int count = 0;

			//			info = ConsultasTransProd.obtenerTotalPedidosCostena();
			//			cadena = Mensajes.get("XTotalPedidos") + ": ";
			//			if(info.getCount() == 1){
			//				info.moveToNext();
			//				cadena = cadena.replace("$0$", ValoresReferencia.getDescripcion("CESQUEMA", info.getString("Clasificacion")));
			//				texto = "$" + Generales.getFormatoDecimal(info.getFloat("Total"), "#,###,##0.00");
			//			}else{
			//				total = 0;
			//				while(info.moveToNext()){
			//					total += info.getFloat("Total");
			//				}
			//				cadena = cadena.replace("$0$", "");
			//				texto = "$" + Generales.getFormatoDecimal(total, "#,###,##0.00");
			//			}
			//			texto = completaHasta(texto, (max - cadena.length()) + columna, TipoAlineacion.DERECHA, true);
			//			
			//			cadenaRecibo.append(cadena + texto + "\r\n");
			//			cadenaRecibo.append("\r\n");
			//			info.close();
			info = ConsultasTransProd.obtenerTotalPedidosCostena();
			total = 0;
			// Agrega las categorias 
			while (info.moveToNext())
			{
				cadena = Mensajes.get("XTotalPedidos") + ": ";
				//cadena = cadena.replace("$0$", ValoresReferencia.getDescripcion("CESQUEMA", info.getString("Clasificacion")));
				String clasificacion = "";
				if(info.getString("Clasificacion") != null)
					clasificacion = ValoresReferencia.getDescripcion("CESQUEMA", info.getString("Clasificacion"));
				cadena = cadena.replace("$0$", clasificacion);
				texto = "$" + Generales.getFormatoDecimal(info.getFloat("Total"), "#,###,##0.00");
				texto = completaHasta(texto, (max - cadena.length()) + columna, TipoAlineacion.DERECHA, true);

				cadenaRecibo.append(cadena + texto + "\r\n");
				cadenaRecibo.append("\r\n");

				total += info.getFloat("Total");
			}
			info.close();
			/* Agrega total 
			cadena = (Mensajes.get("XTotalPedidos") + ": ").replace("$0$", "");
			texto = "$" + Generales.getFormatoDecimal(total, "#,###,##0.00");
			texto = completaHasta(texto, (max - cadena.length()) + columna, TipoAlineacion.DERECHA, true);

			cadenaRecibo.append(cadena + texto + "\r\n");
			cadenaRecibo.append("\r\n");

			info = ConsultasTransProd.obtenerPedidosContado();
			total = 0;
			while (info.moveToNext())
			{
				total += info.getFloat("Total");
			}
			cadena = Mensajes.get("XTotalPedidosContado") + ": ";
			texto = "$" + Generales.getFormatoDecimal(total, "#,###,##0.00");
			texto = completaHasta(texto, (max - cadena.length()) + columna, TipoAlineacion.DERECHA, true);
			cadenaRecibo.append(cadena + texto + "\r\n");
			info.close();

			info = ConsultasTransProd.obtenerPedidosCredito();
			total = 0;
			while (info.moveToNext())
			{
				total += info.getFloat("Total");
			}
			cadena = Mensajes.get("XTotalPedidosCredito") + ": ";
			texto = "$" + Generales.getFormatoDecimal(total, "#,###,##0.00");
			texto = completaHasta(texto, (max - cadena.length()) + columna, TipoAlineacion.DERECHA, true);
			cadenaRecibo.append(cadena + texto + "\r\n");
			cadenaRecibo.append("\r\n");
			info.close();

			info = ConsultasTransProd.obtenerPedidosCancelados();
			total = 0;
			count = 0;
			while (info.moveToNext())
			{
				total += info.getFloat("Total");
				count += info.getInt("TotalPedidos");
			}
			cadena = Mensajes.get("XPedidosCancelados") + ": ";
			texto = "" + count;
			texto = completaHasta(texto, (max - cadena.length()) + columna, TipoAlineacion.DERECHA, true);
			cadenaRecibo.append(cadena + texto + "\r\n");
			cadena = Mensajes.get("XTotalMin") + " " + Mensajes.get("XPedidosCancelados") + ": ";
			texto = "$" + Generales.getFormatoDecimal(total, "#,###,##0.00");
			texto = completaHasta(texto, (max - cadena.length()) + columna, TipoAlineacion.DERECHA, true);
			cadenaRecibo.append(cadena + texto + "\r\n");
			cadenaRecibo.append("\r\n");
			info.close();

			info = ConsultasTransProd.obtenerPedidosCanceladosOp();
			total = 0;
			count = 0;
			while (info.moveToNext())
			{
				total += info.getFloat("Total");
				count += info.getInt("TotalPedidos");
			}
			cadena = Mensajes.get("XPedidosCanceladosOp") + ": ";
			texto = "" + count;
			texto = completaHasta(texto, (max - cadena.length()) + columna, TipoAlineacion.DERECHA, true);
			cadenaRecibo.append(cadena + texto + "\r\n");
			cadena = Mensajes.get("XTotalMin") + " " + Mensajes.get("XPedidosCanceladosOp") + ": ";
			texto = "$" + Generales.getFormatoDecimal(total, "#,###,##0.00");
			texto = completaHasta(texto, (max - cadena.length()) + columna, TipoAlineacion.DERECHA, true);
			cadenaRecibo.append(cadena + texto + "\r\n");
			cadenaRecibo.append("\r\n");
			info.close();

			info = ConsultasTransProd.obtenerPedidosDelDia();
			total = 0;
			count = 0;
			while (info.moveToNext())
			{
				total += info.getFloat("Total");
				count += info.getInt("TotalPedidos");
			}
			cadena = Mensajes.get("XPedidosDelDia") + ": ";
			texto = "" + count;
			texto = completaHasta(texto, (max - cadena.length()) + columna, TipoAlineacion.DERECHA, true);
			cadenaRecibo.append(cadena + texto + "\r\n");
			cadena = Mensajes.get("XTotalMin") + " " + Mensajes.get("XPedidosDelDia") + ": ";
			texto = "$" + Generales.getFormatoDecimal(total, "#,###,##0.00");
			texto = completaHasta(texto, (max - cadena.length()) + columna, TipoAlineacion.DERECHA, true);
			cadenaRecibo.append(cadena + texto + "\r\n");
			cadenaRecibo.append("\r\n");
			info.close();

			info = ConsultasTransProd.obtenerPedidosOp();
			total = 0;
			count = 0;
			while (info.moveToNext())
			{
				total += info.getFloat("Total");
				count += info.getInt("TotalPedidos");
			}
			cadena = Mensajes.get("XPedidosClienteOp") + ": ";
			texto = "" + count;
			texto = completaHasta(texto, (max - cadena.length()) + columna, TipoAlineacion.DERECHA, true);
			cadenaRecibo.append(cadena + texto + "\r\n");
			cadena = Mensajes.get("XTotalMin") + " " + Mensajes.get("XPedidosClienteOp") + ": ";
			texto = "$" + Generales.getFormatoDecimal(total, "#,###,##0.00");
			texto = completaHasta(texto, (max - cadena.length()) + columna, TipoAlineacion.DERECHA, true);
			cadenaRecibo.append(cadena + texto + "\r\n");
			cadenaRecibo.append("\r\n");
			info.close();

			info = ConsultasTransProd.obtenerPedidosFueraFrecuencia();
			total = 0;
			count = 0;
			while (info.moveToNext())
			{
				total += info.getFloat("Total");
				count += info.getInt("TotalPedidos");
			}
			cadena = Mensajes.get("XPedidosFueraFrecc") + ": ";
			texto = "" + count;
			texto = completaHasta(texto, (max - cadena.length()) + columna, TipoAlineacion.DERECHA, true);
			cadenaRecibo.append(cadena + texto + "\r\n");
			cadena = Mensajes.get("XTotalMin") + " " + Mensajes.get("XPedidosFueraFrecc") + ": ";
			texto = "$" + Generales.getFormatoDecimal(total, "#,###,##0.00");
			texto = completaHasta(texto, (max - cadena.length()) + columna, TipoAlineacion.DERECHA, true);
			cadenaRecibo.append(cadena + texto + "\r\n");
			cadenaRecibo.append("\r\n");
			info.close();

			cadenaRecibo.append("\r\n");
			cadenaRecibo.append("\r\n");
			cadenaRecibo.append("\r\n");
			cadenaRecibo.append("\r\n");
			cadenaRecibo.append("\r\n");

			OutputStream f1 = new FileOutputStream(archivoRecibo, true);
			f1.write(cadenaRecibo.toString().getBytes());
			f1.close();

			return archivoRecibo.getName();
		}
		catch (Exception ex)
		{
			throw new Exception("Error al generar ticket:" + ex.getMessage());
		}

	}*/

	private static void generarReporteResumenMovsCostena(int reporte, StringBuilder cadenaRecibo, Document document) throws Exception
	{
		String cadena = "";
		String texto = "";
		int columna = 10;
		int max = 38;
		ISetDatos idataRuta = Consultas.ConsultasRuta.obtenerRutas();
		idataRuta.moveToFirst();
		Ruta ruta = new Ruta();
		ruta.RUTClave = idataRuta.getString("RUTClave");
		BDVend.recuperar(ruta);
		idataRuta.close();
		Paragraph reportePDF = new Paragraph();
		reportePDF.setFont(textoNegrita); //letra general para el reporte
		
		setTamanioDefault(((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp);
		TamanioLetra tamanioLetra;
		tamanioLetra = tamanioDefault;

		if (((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.ZEBRA_TERMICA2 || ((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.ZEBRA_CAMEO2)
		{
			cadena = "{" + tamanioLetra.mTamanio + " " + tamanioLetra.mAlto + "}";
		}
		else if (((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.INTERMEC_PR2 || ((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.INTERMEC_PR3)
		{
			//Se usa el mAlto para indentificar si la letra es normal o doble 0= normal 1= doble
			//En la cadena de los bytes no se debe dejar espacios, si no falla y se consideran hasta el momento
			//3 bytes en el mensaje, por lo que si se mete menos o mas, hay que cambiar el codigo en BluetoothPrint
			if (tamanioLetra.mAlto != 0)
			{
				cadena = "{27,33," + tamanioLetra.mTamanio + "}";
			}
			else
			{
				cadena = "{27,119," + tamanioLetra.mTamanio + "}";
			}
		}
		else
		{
			cadena = "{" + tamanioLetra.mTamanio + "}";
		}
		texto = ValoresReferencia.getDescripcion("REPORTEA", String.valueOf(reporte));
		cadena = cadena + alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, tamanioLetra.mLongTotal);

		cadenaRecibo.append(cadena + "\r\n");
		cadenaRecibo.append("\r\n");

		//de aqui para arriba es codigo nuevo a ver si funciona!
		
		/*TamanioLetra tamanioLetra;
		tamanioLetra = tamanioDefault;*/

		/*texto = ValoresReferencia.getDescripcion("REPORTEA", String.valueOf(reporte));
		cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, tamanioLetra.mLongTotal);

		cadenaRecibo.append(cadena + "\r\n");
		cadenaRecibo.append("\r\n");*/

		Paragraph titulo = new Paragraph(texto, tituloRojo);
		titulo.setAlignment(Element.ALIGN_CENTER);
		reportePDF.add(titulo);
		reportePDF.add(new Paragraph(" ")); //linea en blanco = \r\n

		texto = Mensajes.get("XImpresion") + ": " + Generales.getFechaHoraActualStr("dd/MM/yyyy hh:mm:ss");
		cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, tamanioLetra.mLongTotal);
		cadenaRecibo.append(cadena + "\r\n");

		Paragraph impresion = new Paragraph(texto, textoNegrita);
		impresion.setAlignment(Element.ALIGN_CENTER);
		reportePDF.add(impresion);

		texto = Mensajes.get("XRuta") + ": " + ruta.RUTClave;
		cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, tamanioLetra.mLongTotal);
		cadenaRecibo.append(cadena + "\r\n");
		cadenaRecibo.append("\r\n");

		Paragraph rut = new Paragraph(texto, textoNegrita);
		rut.setAlignment(Element.ALIGN_CENTER);
		reportePDF.add(rut);
		reportePDF.add(new Paragraph(" ")); //linea en blanco = \r\n

		ISetDatos info;
		float total = 0;
		int count = 0;

		info = ConsultasTransProd.obtenerTotalPedidosCostena("1");
		total = 0;
		/* Agrega las categorias */
		while (info.moveToNext())
		{
			cadena = Mensajes.get("XTotalPedidos") + ": ";
			//cadena = cadena.replace("$0$", ValoresReferencia.getDescripcion("CESQUEMA", info.getString("Clasificacion")));
			String clasificacion = "";
			if(info.getString("Clasificacion") != null)
				clasificacion = ValoresReferencia.getDescripcion("CESQUEMA", info.getString("Clasificacion"));
			cadena = cadena.replace("$0$", clasificacion);
			texto = "$" + Generales.getFormatoDecimal(info.getFloat("Total"), "#,###,##0.00");
			texto = completaHasta(texto, (max - cadena.length()) + columna, TipoAlineacion.DERECHA, true);

			cadenaRecibo.append(cadena + texto + "\r\n");
			cadenaRecibo.append("\r\n");

			reportePDF.add(cadena + texto); //agregar texto al pdf
			reportePDF.add(new Paragraph(" ")); //linea en blanco = \r\n

			total += info.getFloat("Total");
		}
		info.close();
		/* Agrega total */
		cadena = (Mensajes.get("XTotalPedidos") + ": ").replace("$0$", "");
		texto = "$" + Generales.getFormatoDecimal(total, "#,###,##0.00");
		texto = completaHasta(texto, (max - cadena.length()) + columna, TipoAlineacion.DERECHA, true);

		cadenaRecibo.append(cadena + texto + "\r\n");
		cadenaRecibo.append("\r\n");

		reportePDF.add(cadena + texto); //agregar texto al pdf
		reportePDF.add(new Paragraph(" ")); //linea en blanco = \r\n

		info = ConsultasTransProd.obtenerPedidosContado();
		total = 0;
		while (info.moveToNext())
		{
			total += info.getFloat("Total");
		}
		cadena = Mensajes.get("XTotalPedidosContado") + ": ";
		texto = "$" + Generales.getFormatoDecimal(total, "#,###,##0.00");
		texto = completaHasta(texto, (max - cadena.length()) + columna, TipoAlineacion.DERECHA, true);
		cadenaRecibo.append(cadena + texto + "\r\n");
		info.close();
		reportePDF.add(cadena + texto);
		reportePDF.add(new Paragraph(" ")); //linea en blanco = \r\n

		info = ConsultasTransProd.obtenerPedidosCredito();
		total = 0;
		while (info.moveToNext())
		{
			total += info.getFloat("Total");
		}
		cadena = Mensajes.get("XTotalPedidosCredito") + ": ";
		texto = "$" + Generales.getFormatoDecimal(total, "#,###,##0.00");
		texto = completaHasta(texto, (max - cadena.length()) + columna, TipoAlineacion.DERECHA, true);
		cadenaRecibo.append(cadena + texto + "\r\n");
		cadenaRecibo.append("\r\n");
		info.close();
		reportePDF.add(cadena + texto);
		reportePDF.add(new Paragraph(" ")); //linea en blanco = \r\n

		info = ConsultasTransProd.obtenerPedidosCancelados();
		total = 0;
		count = 0;
		while (info.moveToNext())
		{
			total += info.getFloat("Total");
			count += info.getInt("TotalPedidos");
		}
		cadena = Mensajes.get("XPedidosCancelados") + ": ";
		texto = "" + count;
		texto = completaHasta(texto, (max - cadena.length()) + columna, TipoAlineacion.DERECHA, true);
		cadenaRecibo.append(cadena + texto + "\r\n");
		reportePDF.add(cadena + texto);
		cadena = Mensajes.get("XTotalMin") + " " + Mensajes.get("XPedidosCancelados") + ": ";
		texto = "$" + Generales.getFormatoDecimal(total, "#,###,##0.00");
		texto = completaHasta(texto, (max - cadena.length()) + columna, TipoAlineacion.DERECHA, true);
		cadenaRecibo.append(cadena + texto + "\r\n");
		reportePDF.add(cadena + texto);
		cadenaRecibo.append("\r\n");
		info.close();
		reportePDF.add(new Paragraph(" ")); //linea en blanco = \r\n

		info = ConsultasTransProd.obtenerPedidosCanceladosOp();
		total = 0;
		count = 0;
		while (info.moveToNext())
		{
			total += info.getFloat("Total");
			count += info.getInt("TotalPedidos");
		}
		cadena = Mensajes.get("XPedidosCanceladosOp") + ": ";
		texto = "" + count;
		texto = completaHasta(texto, (max - cadena.length()) + columna, TipoAlineacion.DERECHA, true);
		cadenaRecibo.append(cadena + texto + "\r\n");
		reportePDF.add(cadena + texto);
		cadena = Mensajes.get("XTotalMin") + " " + Mensajes.get("XPedidosCanceladosOp") + ": ";
		texto = "$" + Generales.getFormatoDecimal(total, "#,###,##0.00");
		texto = completaHasta(texto, (max - cadena.length()) + columna, TipoAlineacion.DERECHA, true);
		cadenaRecibo.append(cadena + texto + "\r\n");
		reportePDF.add(cadena + texto);
		cadenaRecibo.append("\r\n");
		info.close();
		reportePDF.add(new Paragraph(" ")); //linea en blanco = \r\n

		info = ConsultasTransProd.obtenerPedidosDelDia();
		total = 0;
		count = 0;
		while (info.moveToNext())
		{
			total += info.getFloat("Total");
			count += info.getInt("TotalPedidos");
		}
		cadena = Mensajes.get("XPedidosDelDia") + ": ";
		texto = "" + count;
		texto = completaHasta(texto, (max - cadena.length()) + columna, TipoAlineacion.DERECHA, true);
		cadenaRecibo.append(cadena + texto + "\r\n");
		reportePDF.add(cadena + texto);
		cadena = Mensajes.get("XTotalMin") + " " + Mensajes.get("XPedidosDelDia") + ": ";
		texto = "$" + Generales.getFormatoDecimal(total, "#,###,##0.00");
		texto = completaHasta(texto, (max - cadena.length()) + columna, TipoAlineacion.DERECHA, true);
		cadenaRecibo.append(cadena + texto + "\r\n");
		reportePDF.add(cadena + texto);
		cadenaRecibo.append("\r\n");
		info.close();
		reportePDF.add(new Paragraph(" ")); //linea en blanco = \r\n

		info = ConsultasTransProd.obtenerPedidosOp();
		total = 0;
		count = 0;
		while (info.moveToNext())
		{
			total += info.getFloat("Total");
			count += info.getInt("TotalPedidos");
		}
		cadena = Mensajes.get("XPedidosClienteOp") + ": ";
		texto = "" + count;
		texto = completaHasta(texto, (max - cadena.length()) + columna, TipoAlineacion.DERECHA, true);
		cadenaRecibo.append(cadena + texto + "\r\n");
		reportePDF.add(cadena + texto);
		cadena = Mensajes.get("XTotalMin") + " " + Mensajes.get("XPedidosClienteOp") + ": ";
		texto = "$" + Generales.getFormatoDecimal(total, "#,###,##0.00");
		texto = completaHasta(texto, (max - cadena.length()) + columna, TipoAlineacion.DERECHA, true);
		cadenaRecibo.append(cadena + texto + "\r\n");
		reportePDF.add(cadena + texto);
		cadenaRecibo.append("\r\n");
		info.close();
		reportePDF.add(new Paragraph(" ")); //linea en blanco = \r\n

		info = ConsultasTransProd.obtenerPedidosFueraFrecuencia();
		total = 0;
		count = 0;
		while (info.moveToNext())
		{
			total += info.getFloat("Total");
			count += info.getInt("TotalPedidos");
		}
		cadena = Mensajes.get("XPedidosFueraFrecc") + ": ";
		texto = "" + count;
		texto = completaHasta(texto, (max - cadena.length()) + columna, TipoAlineacion.DERECHA, true);
		cadenaRecibo.append(cadena + texto + "\r\n");
		reportePDF.add(cadena + texto);
		cadena = Mensajes.get("XTotalMin") + " " + Mensajes.get("XPedidosFueraFrecc") + ": ";
		texto = "$" + Generales.getFormatoDecimal(total, "#,###,##0.00");
		texto = completaHasta(texto, (max - cadena.length()) + columna, TipoAlineacion.DERECHA, true);
		cadenaRecibo.append(cadena + texto + "\r\n");
		reportePDF.add(cadena + texto);
		cadenaRecibo.append("\r\n");
		info.close();

		cadenaRecibo.append("\r\n");
		cadenaRecibo.append("\r\n");
		cadenaRecibo.append("\r\n");
		cadenaRecibo.append("\r\n");
		cadenaRecibo.append("\r\n");

		document.add(reportePDF);
	}
	
	private static void generarReporteInventarioCosteña(int reporte, StringBuilder cadenaRecibo, Document document) throws Exception{
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
		Paragraph reportePDF = new Paragraph();
		Paragraph vacio = new Paragraph(" ");
		reportePDF.setFont(textoNegrita);
		
		setTamanioDefault(((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp);
		TamanioLetra tamanioLetra;
		tamanioLetra = tamanioDefault;

		if (((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.ZEBRA_TERMICA2 || ((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.ZEBRA_CAMEO2)
		{
			cadena = "{" + tamanioLetra.mTamanio + " " + tamanioLetra.mAlto + "}";
		}
		else if (((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.INTERMEC_PR2 || ((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.INTERMEC_PR3)
		{
			//Se usa el mAlto para indentificar si la letra es normal o doble 0= normal 1= doble
			//En la cadena de los bytes no se debe dejar espacios, si no falla y se consideran hasta el momento
			//3 bytes en el mensaje, por lo que si se mete menos o mas, hay que cambiar el codigo en BluetoothPrint
			if (tamanioLetra.mAlto != 0)
			{
				cadena = "{27,33," + tamanioLetra.mTamanio + "}";
			}
			else
			{
				cadena = "{27,119," + tamanioLetra.mTamanio + "}";
			}
		}
		else
		{
			cadena = "{" + tamanioLetra.mTamanio + "}";
		}	
		
		ISetDatos encabezado = ConsultasImpresionTicket.obtenerEncabezado();
		encabezado.moveToFirst();

		texto = encabezado.getString("NombreEmpresa");
		cadena = cadena + alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, tamanioLetra.mLongTotal);
		cadenaRecibo.append(cadena + "\r\n");

		Paragraph empresa = new Paragraph(texto, textoNegrita);
		empresa.setAlignment(Element.ALIGN_CENTER);
		reportePDF.add(empresa);

		texto = encabezado.getString("RFC");
		cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, tamanioLetra.mLongTotal);
		cadenaRecibo.append(cadena + "\r\n");
		cadenaRecibo.append("\r\n");

		encabezado.close();

		Paragraph rfc = new Paragraph(texto, textoNegrita);
		rfc.setAlignment(Element.ALIGN_CENTER);
		reportePDF.add(rfc);
		reportePDF.add(new Paragraph(" ")); //linea en blanco = \r\n
		
		texto = ValoresReferencia.getDescripcion("REPORTEA", String.valueOf(reporte));
		cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, tamanioLetra.mLongTotal);	
		
		cadenaRecibo.append(cadena + "\r\n");
		cadenaRecibo.append("\r\n");
		
		Paragraph titulo = new Paragraph(texto, tituloRojo);
		titulo.setAlignment(Element.ALIGN_CENTER);
		reportePDF.add(titulo);
		reportePDF.add(vacio);
		
		texto = Mensajes.get("XImpresion") + ": " + Generales.getFechaHoraActualStr("dd/MM/yyyy hh:mm:ss");
		cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, tamanioLetra.mLongTotal);
		cadenaRecibo.append(cadena + "\r\n");		
		Paragraph impresion = new Paragraph(texto, textoNegrita);
		impresion.setAlignment(Element.ALIGN_CENTER);
		reportePDF.add(impresion);
		
		texto = Mensajes.get("XRuta") + ": " + ruta.RUTClave;
		cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, tamanioLetra.mLongTotal);
		cadenaRecibo.append(cadena + "\r\n");
		cadenaRecibo.append("\r\n");
		
		Paragraph rut = new Paragraph(texto, textoNegrita);
		rut.setAlignment(Element.ALIGN_CENTER);
		reportePDF.add(rut);
		reportePDF.add(vacio);
		
		/* Encabezado Linea 1 */
		texto = Mensajes.get("XCodigo");
		cadena = completaHasta(texto, 7, TipoAlineacion.IZQUIERDA, false);
		texto = Mensajes.get("XDescripcion");
		cadena+= completaHasta(texto, 20, TipoAlineacion.IZQUIERDA, false);
		texto = Mensajes.get("XEmpaque");
		cadena+= completaHasta(texto, 8, TipoAlineacion.DERECHA, true);
		
		cadenaRecibo.append(cadena + "\r\n");
		
		Paragraph encabezado_1 = new Paragraph(cadena, textoNegrita);
		reportePDF.add(encabezado_1);
		
		/* Encabezado Linea 2 */
		texto = Mensajes.get("XInventarioInicial");
		cadena = completaHasta(texto, 4, TipoAlineacion.IZQUIERDA, false);
		texto = Mensajes.get("XVta");
		cadena+= completaHasta(texto, 4, TipoAlineacion.IZQUIERDA, false);
		texto = Mensajes.get("XInventarioBueno");
		cadena+= completaHasta(texto, 4, TipoAlineacion.IZQUIERDA, false);
		texto = Mensajes.get("XInventarioMalo");
		cadena+= completaHasta(texto, 4, TipoAlineacion.IZQUIERDA, false);
		texto = Mensajes.get("XInventarioFrio");
		cadena+= completaHasta(texto, 4, TipoAlineacion.IZQUIERDA, false);
		texto = Mensajes.get("XInventarioTotal");
		cadena+= completaHasta(texto, 4, TipoAlineacion.IZQUIERDA, false);
		texto = Mensajes.get("XPrecio");
		cadena+= completaHasta(texto, 7, TipoAlineacion.IZQUIERDA, false);
		texto = Mensajes.get("XImpuesto");
		cadena+= completaHasta(texto, 7, TipoAlineacion.IZQUIERDA, false);
		texto = Mensajes.get("XImporte");
		cadena+= completaHasta(texto, 7, TipoAlineacion.DERECHA, true);
		
		cadenaRecibo.append(cadena + "\r\n");
		cadenaRecibo.append("\r\n");
		
		Paragraph encabezado_2 = new Paragraph(cadena, textoNegrita);
		reportePDF.add(encabezado_2);
		reportePDF.add(vacio); //linea en blanco = \r\n
		
		ISetDatos info;
		float totales[] = new float[9];
		String keys[] = new String[]{
				"II", "Vta", "IB", "IM", "IF", "IT", "Precio", "Imp", "Importe"
		};
		float temp, totalCost=0, totalTotis=0, porcMalosCost=0, porcMalosTotis=0, porcFriosTotis=0;
		
		info = Consultas.ConsultasInventario.obtenerInventarioParaReporte();
		/* Agrega los productos */
		while(info.moveToNext()){
			cadena = completaHasta(info.getString(0), 7, TipoAlineacion.IZQUIERDA, false);
			cadena+= completaHasta(info.getString(1), 24, TipoAlineacion.IZQUIERDA, false);
			texto = ValoresReferencia.getDescripcion("UNIDADV", info.getString(2));
			cadena+= completaHasta(texto, 4, TipoAlineacion.DERECHA, true);
			cadena+= "\r\n";
		
			cadenaRecibo.append(cadena);
			reportePDF.add(cadena);
			cadena = "";
			for(int col = 0; col < totales.length; col++){
				if(col >= 0 && col <= 4){
					temp = info.getFloat(keys[col]);
					texto = Generales.getFormatoDecimal(temp, 0);
					cadena+= completaHasta(texto, 4, TipoAlineacion.IZQUIERDA, false);
					totales[col]+= temp;
				}else if(col == 5){
					temp = info.getFloat(keys[2]) + info.getFloat(keys[3]) + info.getFloat(keys[4]);
					texto = Generales.getFormatoDecimal(temp, 0);
					cadena+= completaHasta(texto, 4, TipoAlineacion.IZQUIERDA, false);
					totales[col]+= temp;
				}else if(col == totales.length -1){
					temp = info.getFloat(keys[1]) * info.getFloat(keys[6]) + info.getFloat(keys[7]);
					texto = Generales.getFormatoDecimal(temp, 2);
					cadena+= completaHasta(texto, 7, TipoAlineacion.DERECHA, true);
					totales[col]+= temp;
				}else{
					temp = info.getFloat(keys[col]);
					texto = Generales.getFormatoDecimal(temp, 2);
					cadena+= completaHasta(texto, col == totales.length -2 ? 7: 6, TipoAlineacion.IZQUIERDA, false);
				}
			}
			cadena+= "\r\n";
			cadenaRecibo.append(cadena);
			reportePDF.add(cadena);
		}
		info.close();
		cadenaRecibo.append("\r\n");
		reportePDF.add(vacio);
		
		cadena = Mensajes.get("XTOTALES") + ": ";
		
		cadenaRecibo.append(cadena + "\r\n");
		cadenaRecibo.append("\r\n");
		
		reportePDF.add(cadena);
		reportePDF.add(vacio);
		
		/* Agrega totales */
		texto = Generales.getFormatoDecimal(totales[0], 0);
		cadena = completaHasta(texto, 7, TipoAlineacion.IZQUIERDA, false);
		texto = Generales.getFormatoDecimal(totales[1], 0);
		cadena+= completaHasta(texto, 7, TipoAlineacion.IZQUIERDA, false);
		texto = Generales.getFormatoDecimal(totales[2], 0);
		cadena+= completaHasta(texto, 7, TipoAlineacion.IZQUIERDA, false);
		texto = Generales.getFormatoDecimal(totales[3], 0);
		cadena+= completaHasta(texto, 7, TipoAlineacion.IZQUIERDA, false);
		texto = Generales.getFormatoDecimal(totales[4], 0);
		cadena+= completaHasta(texto, 7, TipoAlineacion.IZQUIERDA, false);
		texto = Generales.getFormatoDecimal(totales[5], 0);
		cadena+= completaHasta(texto, 7, TipoAlineacion.IZQUIERDA, false);
		
		cadenaRecibo.append(cadena+"\r\n");
		reportePDF.add(cadena);
		
		cadenaRecibo.append("\r\n");
		reportePDF.add(vacio);
		reportePDF.add(vacio);
		
		/* Total ventas */
		cadena = (Mensajes.get("XTotalVentas") + ": ").replace("$0$", "");
		texto = "$" + Generales.getFormatoDecimal(totales[8], "#,###,##0.00");
		texto = completaHasta(texto, (max - cadena.length()) + columna, TipoAlineacion.DERECHA, true);
		
		cadenaRecibo.append(cadena + texto + "\r\n");
		cadenaRecibo.append("\r\n");
		
		reportePDF.add(cadena + texto);
		reportePDF.add(vacio);
		
		/* Total cobranza */
		temp = Consultas.ConsultasAbono.obtenerTotalCobranza();
		cadena = (Mensajes.get("XTOTALCOBRANZA") + ": ").replace("$0$", "");
		texto = "$" + Generales.getFormatoDecimal(temp, "#,###,##0.00");
		texto = completaHasta(texto, (max - cadena.length()) + columna, TipoAlineacion.DERECHA, true);
		cadenaRecibo.append(cadena + texto + "\r\n");
		cadenaRecibo.append("\r\n");
		
		reportePDF.add(cadena + texto);
		reportePDF.add(vacio);
		
		/* Total pedidos posfechados */
		temp = Consultas.ConsultasTransProd.obtenerTotalPedidosPosfechados();
		//TODO Agregar el mensaje Posfechados
		cadena = Mensajes.get("XTotalPedidos").replace("$0$", Mensajes.get("XPosfechados")) + ":";
		texto = "$" + Generales.getFormatoDecimal(temp, "#,###,##0.00");
		texto = completaHasta(texto, (max - cadena.length()) + columna, TipoAlineacion.DERECHA, true);
		cadenaRecibo.append(cadena + texto + "\r\n");
		cadenaRecibo.append("\r\n");
		
		reportePDF.add(cadena + texto);
		reportePDF.add(vacio); 
		
		info = Consultas.ConsultasTransProd.obtenerTotalPedidosCostena("2");
		
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
			cadenaRecibo.append("\r\n");
			
			reportePDF.add(cadena + texto);
			reportePDF.add(vacio);
			
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
		cadenaRecibo.append("\r\n");
		
		reportePDF.add(cadena + texto);
		reportePDF.add(vacio);
		
		/* Total Malos totis */
		temp = Consultas.ConsultasInventario.obtenerTotalProductosPorEsquemaClasificacionYTipoMotivo(5, 200, 210);
		porcMalosTotis = (temp / totalTotis) * 100;
		cadena = Mensajes.get("XTotalMalos") + " " + ValoresReferencia.getDescripcion("CESQUEMA", "5") + ":";
		texto = "$" + Generales.getFormatoDecimal(temp, "#,###,##0.00");
		texto = completaHasta(texto, (max - cadena.length()) + columna, TipoAlineacion.DERECHA, true);
		
		cadenaRecibo.append(cadena + texto + "\r\n");
		cadenaRecibo.append("\r\n");
		
		reportePDF.add(cadena + texto);
		reportePDF.add(vacio);
		
		/* Total Frios totis */
		temp = Consultas.ConsultasInventario.obtenerTotalProductosPorEsquemaClasificacionYTipoMotivo(5, 211);
		porcFriosTotis = (temp / totalTotis) * 100;
		cadena = Mensajes.get("XTotalFrios") + " " + ValoresReferencia.getDescripcion("CESQUEMA", "5") + ":";
		texto = "$" + Generales.getFormatoDecimal(temp, "#,###,##0.00");
		texto = completaHasta(texto, (max - cadena.length()) + columna, TipoAlineacion.DERECHA, true);
		
		cadenaRecibo.append(cadena + texto + "\r\n");
		cadenaRecibo.append("\r\n");
		
		reportePDF.add(cadena + texto);
		reportePDF.add(vacio);
		
		/* Porcentaje malos la costeña */
		cadena = Mensajes.get("XPorcentajeMalos") + " ";
		cadena+= ValoresReferencia.getDescripcion("CESQUEMA", "4") + ":";
		texto = Generales.getFormatoDecimal(Float.isNaN(porcMalosCost) ? 0:porcMalosCost, "#,###,##0.00") + "%";
		texto = completaHasta(texto, (max - cadena.length()) + columna, TipoAlineacion.DERECHA, true);
		
		cadenaRecibo.append(cadena + texto + "\r\n");
		cadenaRecibo.append("\r\n");
		
		reportePDF.add(cadena + texto);
		reportePDF.add(vacio);
		
		/* Porcentaje malos totis */
		cadena = Mensajes.get("XPorcentajeMalos") + " ";
		cadena+= ValoresReferencia.getDescripcion("CESQUEMA", "5")+ ":";
		texto = Generales.getFormatoDecimal(Float.isNaN(porcMalosTotis) ? 0:porcMalosTotis, "#,###,##0.00") + "%";
		texto = completaHasta(texto, (max - cadena.length()) + columna, TipoAlineacion.DERECHA, true);
		
		cadenaRecibo.append(cadena + texto + "\r\n");
		cadenaRecibo.append("\r\n");
		
		reportePDF.add(cadena + texto);
		reportePDF.add(vacio);
		
		/* Porcentaje Frios totis */
		cadena = Mensajes.get("XPorcentajeFrios") + " ";
		cadena+= ValoresReferencia.getDescripcion("CESQUEMA", "5")+ ":";
		texto = Generales.getFormatoDecimal(Float.isNaN(porcFriosTotis) ? 0:porcFriosTotis, "#,###,##0.00") + "%";
		texto = completaHasta(texto, (max - cadena.length()) + columna, TipoAlineacion.DERECHA, true);
		
		cadenaRecibo.append(cadena + texto + "\r\n");
		cadenaRecibo.append("\r\n");
		
		reportePDF.add(cadena + texto);
		reportePDF.add(vacio);
		
		/* Total cajas la costeña */
		temp = Consultas.ConsultasInventario.obtenerTotalCajasVendidasPorEsquemaClasificacion("4");
		cadena = Mensajes.get("XTotalCajas") + " " + ValoresReferencia.getDescripcion("CESQUEMA", "4") + ":";
		texto = Generales.getFormatoDecimal(temp, "#,###,##0.00");
		texto = completaHasta(texto, (max - cadena.length()) + columna, TipoAlineacion.DERECHA, true);
		
		cadenaRecibo.append(cadena + texto + "\r\n");
		cadenaRecibo.append("\r\n");
		
		reportePDF.add(cadena + texto);
		reportePDF.add(vacio);
		
		/* Total cajas totis */
		temp = Consultas.ConsultasInventario.obtenerTotalCajasVendidasPorEsquemaClasificacion("5");
		cadena = Mensajes.get("XTotalCajas") + " " + ValoresReferencia.getDescripcion("CESQUEMA", "5") + ":";
		texto = Generales.getFormatoDecimal(temp, "#,###,##0.00");
		texto = completaHasta(texto, (max - cadena.length()) + columna, TipoAlineacion.DERECHA, true);
		
		cadenaRecibo.append(cadena + texto + "\r\n");
		cadenaRecibo.append("\r\n");
		
		reportePDF.add(cadena + texto);
		reportePDF.add(vacio);
		
		/* Firmas */
		cadenaRecibo.append("\r\n");
		reportePDF.add(vacio);
		cadenaRecibo.append("\r\n");
		reportePDF.add(vacio);
		cadenaRecibo.append("\r\n");
		reportePDF.add(vacio);
		
		texto = "____________________________________";
		cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, tamanioLetra.mLongTotal);
		cadenaRecibo.append(cadena + "\r\n");		
		Paragraph firma = new Paragraph(texto, textoNegrita);
		firma.setAlignment(Element.ALIGN_CENTER);
		reportePDF.add(firma);
		
		cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, Mensajes.get("XAlmacen"), tamanioLetra.mLongTotal);
		cadenaRecibo.append(cadena + "\r\n");		
		Paragraph firmaTitulo = new Paragraph(Mensajes.get("XAlmacen"), textoNegrita);
		firmaTitulo.setAlignment(Element.ALIGN_CENTER);
		reportePDF.add(firmaTitulo);
		
		cadenaRecibo.append("\r\n");
		reportePDF.add(vacio);
		cadenaRecibo.append("\r\n");
		reportePDF.add(vacio);
		cadenaRecibo.append("\r\n");
		reportePDF.add(vacio);
		cadenaRecibo.append("\r\n");
		reportePDF.add(vacio);
		
		cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, tamanioLetra.mLongTotal);
		cadenaRecibo.append(cadena + "\r\n");		

		reportePDF.add(firma);
		
		cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, Mensajes.get("XVendedor"), tamanioLetra.mLongTotal);
		cadenaRecibo.append(cadena + "\r\n");		
		firmaTitulo = new Paragraph(Mensajes.get("XVendedor"), textoNegrita);
		firmaTitulo.setAlignment(Element.ALIGN_CENTER);
		reportePDF.add(firmaTitulo);
		
		/* Fin del reporte */
		cadenaRecibo.append("\r\n");
		cadenaRecibo.append("\r\n");
		cadenaRecibo.append("\r\n");
		cadenaRecibo.append("\r\n");
		cadenaRecibo.append("\r\n");
		
		document.add(reportePDF);
	}

	private static void generarReporteCuadreDeCajaCostena(int reporte, StringBuilder cadenaRecibo, Document document) throws Exception
	{
		String cadena = "";
		String texto = "";
		int columna = 10;
		int max = 38;
		ISetDatos idataRuta = Consultas.ConsultasRuta.obtenerRutas();
		idataRuta.moveToFirst();
		Ruta ruta = new Ruta();
		ruta.RUTClave = idataRuta.getString("RUTClave");
		BDVend.recuperar(ruta);
		idataRuta.close();
		Paragraph reportePDF = new Paragraph();
		reportePDF.setFont(textoNegrita); //letra general para el reporte

		setTamanioDefault(((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp);
		TamanioLetra tamanioLetra;
		tamanioLetra = tamanioDefault;

		if (((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.ZEBRA_TERMICA2 || ((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.ZEBRA_CAMEO2)
		{
			cadena = "{" + tamanioLetra.mTamanio + " " + tamanioLetra.mAlto + "}";
		}
		else if (((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.INTERMEC_PR2 || ((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.INTERMEC_PR3)
		{
			//Se usa el mAlto para indentificar si la letra es normal o doble 0= normal 1= doble
			//En la cadena de los bytes no se debe dejar espacios, si no falla y se consideran hasta el momento
			//3 bytes en el mensaje, por lo que si se mete menos o mas, hay que cambiar el codigo en BluetoothPrint
			if (tamanioLetra.mAlto != 0)
			{
				cadena = "{27,33," + tamanioLetra.mTamanio + "}";
			}
			else
			{
				cadena = "{27,119," + tamanioLetra.mTamanio + "}";
			}
		}
		else
		{
			cadena = "{" + tamanioLetra.mTamanio + "}";
		}

		ISetDatos encabezado = ConsultasImpresionTicket.obtenerEncabezado();
		encabezado.moveToFirst();

		texto = encabezado.getString("NombreEmpresa");
		cadena = cadena + alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, tamanioLetra.mLongTotal);
		cadenaRecibo.append(cadena + "\r\n");

		Paragraph empresa = new Paragraph(texto, textoNegrita);
		empresa.setAlignment(Element.ALIGN_CENTER);
		reportePDF.add(empresa);

		texto = encabezado.getString("RFC");
		cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, tamanioLetra.mLongTotal);
		cadenaRecibo.append(cadena + "\r\n");
		cadenaRecibo.append("\r\n");

		encabezado.close();

		Paragraph rfc = new Paragraph(texto, textoNegrita);
		rfc.setAlignment(Element.ALIGN_CENTER);
		reportePDF.add(rfc);
		reportePDF.add(new Paragraph(" ")); //linea en blanco = \r\n

		texto = ValoresReferencia.getDescripcion("REPORTEA", String.valueOf(reporte));
		cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, tamanioLetra.mLongTotal);

		cadenaRecibo.append(cadena + "\r\n");
		cadenaRecibo.append("\r\n");

		Paragraph titulo = new Paragraph(texto, tituloRojo);
		titulo.setAlignment(Element.ALIGN_CENTER);
		reportePDF.add(titulo);
		reportePDF.add(new Paragraph(" ")); //linea en blanco = \r\n

		texto = Mensajes.get("XImpresion") + ": " + Generales.getFechaHoraActualStr("dd/MM/yyyy hh:mm:ss");
		cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, tamanioLetra.mLongTotal);
		cadenaRecibo.append(cadena + "\r\n");

		Paragraph impresion = new Paragraph(texto, textoNegrita);
		impresion.setAlignment(Element.ALIGN_CENTER);
		reportePDF.add(impresion);

		texto = Mensajes.get("XRuta") + ": " + ruta.RUTClave;
		cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, tamanioLetra.mLongTotal);
		cadenaRecibo.append(cadena + "\r\n");
		cadenaRecibo.append("\r\n");

		Paragraph rut = new Paragraph(texto, textoNegrita);
		rut.setAlignment(Element.ALIGN_CENTER);
		reportePDF.add(rut);
		reportePDF.add(new Paragraph(" ")); //linea en blanco = \r\n

		float total = ConsultasAbono.obtenerTotalCobranza();
		cadena = Mensajes.get("XTotalALiquidar") + ": ";
		texto = "$" + Generales.getFormatoDecimal(total, "#,###,##0.00");
		texto = completaHasta(texto, (max - cadena.length()) + columna, TipoAlineacion.DERECHA, true);
		String texto_ticket = completaHasta("$" + Generales.getFormatoDecimal(total, "#,###,##0.00"), (max - cadena.length()), TipoAlineacion.DERECHA, true);
		cadenaRecibo.append(cadena + texto_ticket + "\r\n");
		reportePDF.add(cadena + texto);

		cadenaRecibo.append("\r\n");
		cadenaRecibo.append("\r\n");
		cadenaRecibo.append("\r\n");
		cadenaRecibo.append("\r\n");
		cadenaRecibo.append("\r\n");

		document.add(reportePDF);
	}
	
	private static void generarReporteLiquidacionVtasCostena(int reporte, StringBuilder cadenaRecibo, Document document) throws Exception
	{
		String cadena = "";
		String texto = "";
		int columna = 10;
		int max = 38; 
		ISetDatos idataRuta = Consultas.ConsultasRuta.obtenerRutas();
		idataRuta.moveToFirst();
		Ruta ruta = new Ruta();
		ruta.RUTClave = idataRuta.getString("RUTClave");
		BDVend.recuperar(ruta);
		//idataRuta.close();
		Paragraph reportePDF = new Paragraph();
		reportePDF.setFont(textoNegrita); //letra general para el reporte
		
		setTamanioDefault(((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp);
		TamanioLetra tamanioLetra;
		tamanioLetra = tamanioDefault;

		if (((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.ZEBRA_TERMICA2 || ((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.ZEBRA_CAMEO2)
		{
			cadena = "{" + tamanioLetra.mTamanio + " " + tamanioLetra.mAlto + "}";
		}
		else if (((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.INTERMEC_PR2 || ((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.INTERMEC_PR3)
		{
			//Se usa el mAlto para indentificar si la letra es normal o doble 0= normal 1= doble
			//En la cadena de los bytes no se debe dejar espacios, si no falla y se consideran hasta el momento
			//3 bytes en el mensaje, por lo que si se mete menos o mas, hay que cambiar el codigo en BluetoothPrint
			if (tamanioLetra.mAlto != 0)
			{
				cadena = "{27,33," + tamanioLetra.mTamanio + "}";
			}
			else
			{
				cadena = "{27,119," + tamanioLetra.mTamanio + "}";
			}
		}else if(((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.EXTECH_TERMICA2){
			//tamanioLetra.mLongTotal = tamanioLetra.mLongTotal - 1;
			max = 37;
			columna = 9;
			cadena = "{" + tamanioLetra.mTamanio + "}";
		}
		else
		{
			cadena = "{" + tamanioLetra.mTamanio + "}";
		}
		
		ISetDatos encabezado = ConsultasImpresionTicket.obtenerEncabezado();
		encabezado.moveToFirst();

		texto = encabezado.getString("NombreEmpresa");
		cadena = cadena + alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, tamanioLetra.mLongTotal);
		cadenaRecibo.append(cadena + "\r\n");

		Paragraph empresa = new Paragraph(texto, textoNegrita);
		empresa.setAlignment(Element.ALIGN_CENTER);
		reportePDF.add(empresa);

		texto = encabezado.getString("RFC");
		cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, tamanioLetra.mLongTotal);
		cadenaRecibo.append(cadena + "\r\n");
		cadenaRecibo.append("\r\n");

		encabezado.close();

		Paragraph rfc = new Paragraph(texto, textoNegrita);
		rfc.setAlignment(Element.ALIGN_CENTER);
		reportePDF.add(rfc);
		reportePDF.add(new Paragraph(" ")); //linea en blanco = \r\n

		texto = ValoresReferencia.getDescripcion("REPORTEA", String.valueOf(reporte));
		cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, tamanioLetra.mLongTotal);

		cadenaRecibo.append(cadena + "\r\n");
		cadenaRecibo.append("\r\n");

		Paragraph titulo = new Paragraph(texto, tituloRojo);
		titulo.setAlignment(Element.ALIGN_CENTER);
		reportePDF.add(titulo);
		reportePDF.add(new Paragraph(" ")); //linea en blanco = \r\n

		texto = Mensajes.get("XImpresion") + ": " + Generales.getFechaHoraActualStr("dd/MM/yyyy hh:mm:ss");
		cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, tamanioLetra.mLongTotal);
		cadenaRecibo.append(cadena + "\r\n");

		Paragraph impresion = new Paragraph(texto, textoNegrita);
		impresion.setAlignment(Element.ALIGN_CENTER);
		reportePDF.add(impresion);

		texto = Mensajes.get("XRuta") + ": " + ruta.RUTClave;
		cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, tamanioLetra.mLongTotal);
		cadenaRecibo.append(cadena + "\r\n");
		cadenaRecibo.append("\r\n");

		Paragraph rut = new Paragraph(texto, textoNegrita);
		rut.setAlignment(Element.ALIGN_CENTER);
		reportePDF.add(rut);
		reportePDF.add(new Paragraph(" ")); //linea en blanco = \r\n

		ISetDatos info;
		float total = 0;
		int count = 0;

		info = ConsultasTransProd.obtenerTotalVentasCostena();
		total = 0;
		/* Agrega las categorias */
		while (info.moveToNext())
		{
			cadena = Mensajes.get("XTotalVentas$0$") + ": ";
			//cadena = cadena.replace("$0$", ValoresReferencia.getDescripcion("CESQUEMA", info.getString("Clasificacion")));
			String clasificacion = "";
			if(info.getString("Clasificacion") != null)
				clasificacion = ValoresReferencia.getDescripcion("CESQUEMA", info.getString("Clasificacion"));
			cadena = cadena.replace("$0$", clasificacion);
			texto = "$" + Generales.getFormatoDecimal(info.getFloat("Total"), "#,###,##0.00");
			texto = completaHasta(texto, (max - cadena.length()) + columna, TipoAlineacion.DERECHA, true);

			cadenaRecibo.append(cadena + texto + "\r\n");
			cadenaRecibo.append("\r\n");

			reportePDF.add(cadena + texto); //agregar texto al pdf
			reportePDF.add(new Paragraph(" ")); //linea en blanco = \r\n

			total += info.getFloat("Total");
		}
		info.close();

		//total ventas contado
		info = ConsultasTransProd.obtenerVentasContado();
		total = 0;
		while (info.moveToNext())
		{
			total += info.getFloat("Total");
		}
		cadena = Mensajes.get("XTotalVentas") + " " + Mensajes.get("XContado") + ": ";
		texto = "$" + Generales.getFormatoDecimal(total, "#,###,##0.00");
		texto = completaHasta(texto, (max - cadena.length()) + columna, TipoAlineacion.DERECHA, true);
		cadenaRecibo.append(cadena + texto + "\r\n");
		info.close();
		reportePDF.add(cadena + texto);
		//reportePDF.add(new Paragraph(" ")); //linea en blanco = \r\n

		//total ventas credito
		info = ConsultasTransProd.obtenerVentasCredito();
		total = 0;
		while (info.moveToNext())
		{
			total += info.getFloat("Total");
		}
		cadena = Mensajes.get("XTotalVentas") + " " + Mensajes.get("XCredito") + ": ";
		texto = "$" + Generales.getFormatoDecimal(total, "#,###,##0.00");
		texto = completaHasta(texto, (max - cadena.length()) + columna, TipoAlineacion.DERECHA, true);
		cadenaRecibo.append(cadena + texto + "\r\n");
		cadenaRecibo.append("\r\n");
		info.close();
		reportePDF.add(cadena + texto);
		reportePDF.add(new Paragraph(" ")); //linea en blanco = \r\n
		
		//total a liquidar
		float totalliq = ConsultasAbono.obtenerTotalCobranza();
		cadena = Mensajes.get("XTotalALiquidar") + ": ";
		texto = "$" + Generales.getFormatoDecimal(totalliq, "#,###,##0.00");
		texto = completaHasta(texto, (max - cadena.length()) + columna, TipoAlineacion.DERECHA, true);
		//String texto_ticket = completaHasta("$" + Generales.getFormatoDecimal(totalliq, "#,###,##0.00"), (max - cadena.length()), TipoAlineacion.DERECHA, true);
		cadenaRecibo.append(cadena + texto + "\r\n");
		reportePDF.add(cadena + texto);
		//reportePDF.add(new Paragraph(" ")); //linea en blanco = \r\n
		
		//total pedidos
		info = ConsultasTransProd.obtenerTotalMSIEV();
		total = 0;
		while (info.moveToNext())
		{
			total += info.getFloat("Total");
		}
		cadena = (Mensajes.get("XTotalPedidos") + ": ").replace("$0$", "");
		texto = "$" + Generales.getFormatoDecimal(total, "#,###,##0.00");
		texto = completaHasta(texto, (max - cadena.length()) + columna, TipoAlineacion.DERECHA, true);
		cadenaRecibo.append(cadena + texto + "\r\n");
		cadenaRecibo.append("\r\n");
		info.close();
		reportePDF.add(cadena + texto);
		reportePDF.add(new Paragraph(" ")); //linea en blanco = \r\n
		
		//************ cancelaciones
		texto = Mensajes.get("XCancelaciones").toUpperCase();
		cadenaRecibo.append(texto + "\r\n");
		cadenaRecibo.append("\r\n");
		reportePDF.add(texto);
		reportePDF.add(new Paragraph(" ")); //linea en blanco = \r\n
		
		int totalCanc = 0;

		//nota de venta
		info = ConsultasTransProd.obtenerNotasVentaCanceladas();
		total = 0;
		while (info.moveToNext())
		{
			total += info.getFloat("TotalPedidos");
		}
		totalCanc += total;
		cadena = Mensajes.get("XNotaDeVenta") + ": ";
		texto = Generales.getFormatoDecimal(total, "##0");
		texto = completaHasta(texto, (max - cadena.length()) + columna, TipoAlineacion.DERECHA, true);
		cadenaRecibo.append(cadena + texto + "\r\n");
		//cadenaRecibo.append("\r\n");
		info.close();
		reportePDF.add(cadena + texto);
		//reportePDF.add(new Paragraph(" ")); //linea en blanco = \r\n
		
		//pedidos
		info = ConsultasTransProd.obtenerMSIEVCancelados();
		total = 0;
		while (info.moveToNext())
		{
			total += info.getFloat("TotalPedidos");
		}
		totalCanc += total;
		cadena = Mensajes.get("XPedido") + "s: ";
		texto = Generales.getFormatoDecimal(total, "##0");
		texto = completaHasta(texto, (max - cadena.length()) + columna, TipoAlineacion.DERECHA, true);
		cadenaRecibo.append(cadena + texto + "\r\n");
		//cadenaRecibo.append("\r\n");
		info.close();
		reportePDF.add(cadena + texto);
		//reportePDF.add(new Paragraph(" ")); //linea en blanco = \r\n
		
		//entrega pedidos
		info = ConsultasTransProd.obtenerPedidosCanceladosCostena();
		total = 0;
		while (info.moveToNext())
		{
			total += info.getFloat("TotalPedidos");
		}
		totalCanc += total;
		cadena = Mensajes.get("XEntregaPedidos") + ": ";
		texto = Generales.getFormatoDecimal(total, "##0");
		texto = completaHasta(texto, (max - cadena.length()) + columna, TipoAlineacion.DERECHA, true);
		cadenaRecibo.append(cadena + texto + "\r\n");
		//cadenaRecibo.append("\r\n");
		info.close();
		reportePDF.add(cadena + texto);
		//reportePDF.add(new Paragraph(" ")); //linea en blanco = \r\n
		
		//total cancelaciones
		cadena = Mensajes.get("XTotalMin") + " " + Mensajes.get("XCancelaciones") + ": ";
		texto = Generales.getFormatoDecimal(totalCanc, "##0");
		texto = completaHasta(texto, (max - cadena.length()) + columna, TipoAlineacion.DERECHA, true);
		cadenaRecibo.append(cadena + texto + "\r\n");
		cadenaRecibo.append("\r\n");
		info.close();
		reportePDF.add(cadena + texto);
		reportePDF.add(new Paragraph(" ")); //linea en blanco = \r\n
		
		//************************** cancelaciones op
		texto = Mensajes.get("XCancelacionesCliOp").toUpperCase();
		cadenaRecibo.append(texto + "\r\n");
		cadenaRecibo.append("\r\n");
		reportePDF.add(texto);
		reportePDF.add(new Paragraph(" ")); //linea en blanco = \r\n
		
		totalCanc = 0;

		//nota de venta
		info = ConsultasTransProd.obtenerNotasVentaCanceladasOp();
		total = 0;
		while (info.moveToNext())
		{
			total += info.getFloat("TotalPedidos");
		}
		totalCanc += total;
		cadena = Mensajes.get("XNotaDeVenta") + ": ";
		texto = Generales.getFormatoDecimal(total, "##0");
		texto = completaHasta(texto, (max - cadena.length()) + columna, TipoAlineacion.DERECHA, true);
		cadenaRecibo.append(cadena + texto + "\r\n");
		//cadenaRecibo.append("\r\n");
		info.close();
		reportePDF.add(cadena + texto);
		//reportePDF.add(new Paragraph(" ")); //linea en blanco = \r\n
		
		//pedidos
		info = ConsultasTransProd.obtenerMSIEVCanceladosOp();
		total = 0;
		while (info.moveToNext())
		{
			total += info.getFloat("TotalPedidos");
		}
		totalCanc += total;
		cadena = Mensajes.get("XPedido") + "s: ";
		texto = Generales.getFormatoDecimal(total, "##0");
		texto = completaHasta(texto, (max - cadena.length()) + columna, TipoAlineacion.DERECHA, true);
		cadenaRecibo.append(cadena + texto + "\r\n");
		//cadenaRecibo.append("\r\n");
		info.close();
		reportePDF.add(cadena + texto);
		//reportePDF.add(new Paragraph(" ")); //linea en blanco = \r\n
		
		//entrega pedidos
		info = ConsultasTransProd.obtenerPedidosCanceladosCostenaOp();
		total = 0;
		while (info.moveToNext())
		{
			total += info.getFloat("TotalPedidos");
		}
		totalCanc += total;
		cadena = Mensajes.get("XEntregaPedidos") + ": ";
		texto = Generales.getFormatoDecimal(total, "##0");
		texto = completaHasta(texto, (max - cadena.length()) + columna, TipoAlineacion.DERECHA, true);
		cadenaRecibo.append(cadena + texto + "\r\n");
		//cadenaRecibo.append("\r\n");
		info.close();
		reportePDF.add(cadena + texto);
		//reportePDF.add(new Paragraph(" ")); //linea en blanco = \r\n
		
		//total cancelaciones
		cadena = Mensajes.get("XTotalMin") + " " + Mensajes.get("XCancelacionesCliOp") + ": ";
		texto = Generales.getFormatoDecimal(totalCanc, "##0");
		texto = completaHasta(texto, (max - cadena.length()) + columna, TipoAlineacion.DERECHA, true);
		cadenaRecibo.append(cadena + texto + "\r\n");
		cadenaRecibo.append("\r\n");
		info.close();
		reportePDF.add(cadena + texto);
		reportePDF.add(new Paragraph(" ")); //linea en blanco = \r\n
		
		
		//idataRuta = Consultas.ConsultasRuta.obtenerRutas();
		String rutas = "";
		idataRuta.moveToPosition(-1);
		while(idataRuta.moveToNext()){
			rutas += "'"+idataRuta.getString("RUTClave")+"',";
		}
		if(rutas.length() != 0)
			rutas = rutas.substring(0, rutas.length()-1);
		
		//total ventas
		info = Consultas2.ConsultasTransProd.obtenerTotalVentas(rutas);
		total = 0;
		count = 0;
		while (info.moveToNext())
		{
			total += info.getFloat("Total");
			count += info.getInt("TotalPedidos");
		}
		cadena = Mensajes.get("XTotalVentas") + ": ";
		texto = "" + count;
		texto = completaHasta(texto, (max - cadena.length()) + columna, TipoAlineacion.DERECHA, true);
		cadenaRecibo.append(cadena + texto + "\r\n");
		reportePDF.add(cadena + texto);
		info.close();
		reportePDF.add(new Paragraph(" ")); //linea en blanco = \r\n

		info = Consultas2.ConsultasTransProd.obtenerVentasOp(rutas);
		total = 0;
		count = 0;
		while (info.moveToNext())
		{
			total += info.getFloat("Total");
			count += info.getInt("TotalPedidos");
		}
		cadena = Mensajes.get("XTotalMin") + " " + Mensajes.get("XVentasClienteOp") + ": ";
		texto = "" + count;
		texto = completaHasta(texto, (max - cadena.length()) + columna, TipoAlineacion.DERECHA, true);
		cadenaRecibo.append(cadena + texto + "\r\n");
		reportePDF.add(cadena + texto);
		info.close();
		reportePDF.add(new Paragraph(" ")); //linea en blanco = \r\n

		info = Consultas2.ConsultasTransProd.obtenerVentasFueraFrecuencia(rutas);
		total = 0;
		count = 0;
		while (info.moveToNext())
		{
			total += info.getFloat("Total");
			count += info.getInt("TotalPedidos");
		}
		cadena = Mensajes.get("XTotalMin") + " " + Mensajes.get("XVentasFueraFrecc") + ": ";
		texto = "" + count;
		texto = completaHasta(texto, (max - cadena.length()) + columna, TipoAlineacion.DERECHA, true);
		cadenaRecibo.append(cadena + texto + "\r\n");
		reportePDF.add(cadena + texto);
		info.close();

		idataRuta.close();
		
		cadenaRecibo.append("\r\n");
		cadenaRecibo.append("\r\n");
		cadenaRecibo.append("\r\n");
		cadenaRecibo.append("\r\n");
		cadenaRecibo.append("\r\n");

		document.add(reportePDF);
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

	private final Handler mHandler = new Handler()
	{
		@Override
		public void handleMessage(Message msg)
		{
			super.handleMessage(msg);
			switch (msg.what)
			{
				case msgTypes.MESSAGE_STATE_CHANGE:
					Bundle bundle = msg.getData();
					int status = bundle.getInt("state");
					//if (D)
					//Log.i("eRoutePrinting", "handleMessage: MESSAGE_STATE_CHANGE: " + msg.arg1);  //arg1 was not used! by btPrintFile
					//setConnectState(msg.arg1);
					switch (msg.arg1)
					{
						case btPrintFile.STATE_CONNECTED:
							try
							{
								iniciarImpresion();
							}
							catch (Exception ex)
							{
								if (vistaActual != null)
									vistaActual.mostrarError(ex.getMessage());
							}

							//addLog("connected to: " + mConnectedDeviceName);
							//mConversationArrayAdapter.clear();
							//Log.i("eRoutePrinting", "handleMessage: STATE_CONNECTED: " + mConnectedDeviceName);
							break;
						case btPrintFile.STATE_CONNECTING:
							if (vistaActual != null)
							{
								vistaActual.quitarProgreso();
								vistaActual.mostrarProgreso("Imprimiendo...");
							}
							//addLog("connecting...");
							//Log.i("eRoutePrinting", "handleMessage: STATE_CONNECTING: " + mConnectedDeviceName);
							break;
						case btPrintFile.STATE_LISTEN:
							//addLog("connection ready");

							Log.i("eRoutePrinting", "handleMessage: STATE_LISTEN");
							break;
						case btPrintFile.STATE_IDLE:
							//addLog("STATE_NONE");
							//Log.i("eRoutePrinting", "handleMessage: STATE_NONE: not connected");
							/*
							 * if (intentosConexion){ intentosConexion = false;
							 * if (vistaActual != null){ vistaActual.
							 * mostrarPreguntaReintentarConexionImpresora(
							 * "No se encontró la impresora. Verificar que este encendida.¿Desea reintentar?"
							 * , btPrintService, device, new
							 * boolean[]{intentosConexion}); } }
							 */
							break;
						case btPrintFile.STATE_DISCONNECTED:
							if (doorOpen)
							{
								doorOpen = false;
								intentosConexion[0] = false;
								if (vistaActual != null)
								{
									vistaActual.mostrarPreguntaReintentarConexionImpresora("La puerta de la impresora esta abierta. Favor de cerrala. ¿Desea reintentar?", btPrintService, device, intentosConexion);
								}
							}
							else if (intentosConexion[0])
							{
								intentosConexion[0] = false;
								if (reintentosOcultos < 3)
								{
									reintentosOcultos += 1;
									try
									{
										Method m = device.getClass()
												.getMethod("createBond", (Class[]) null);
										m.invoke(device, (Object[]) null);

										Thread.sleep(3000);
									}
									catch (Exception ex)
									{
										if (vistaActual != null)
										{
											Toast.makeText((Activity) vistaActual, ex.getMessage(), Toast.LENGTH_LONG).show();
										}
									}
									intentosConexion[0] = true;
									btPrintService.connect(device);
									break;
								}
								if (vistaActual != null)
								{
									reintentosOcultos = 0;
									vistaActual.mostrarPreguntaReintentarConexionImpresora("No se encontró la impresora; Favor de verificar que este encendida o reiniciarla. ¿Desea reintentar?", btPrintService, device, intentosConexion);
								}
							}

							break;
					}
					break;
				case msgTypes.MESSAGE_WRITE:
					byte[] writeBuf = (byte[]) msg.obj;
					// construct a string from the buffer
					String writeMessage = new String(writeBuf);
					//mConversationArrayAdapter.add("Me:  " + writeMessage);
					break;
				case msgTypes.MESSAGE_READ:
					byte[] readBuf = (byte[]) msg.obj;
					// construct a string from the valid bytes in the buffer
					String readMessage = new String(readBuf, 0, msg.arg1);
					if (readMessage.toUpperCase().contains("DOOR") || readMessage.toUpperCase().contains("OPEN"))
						doorOpen = true;
					//mConversationArrayAdapter.add(mConnectedDeviceName + ":  " + readMessage);
					//addLog("recv>>>" + readMessage);
					break;
				case msgTypes.MESSAGE_DEVICE_NAME:
					// save the connected device's name
					//mConnectedDeviceName = msg.getData().getString(msgTypes.DEVICE_NAME);
					//Toast.makeText(getApplicationContext(), "Connected to " + mConnectedDeviceName, Toast.LENGTH_SHORT).show();
					//myToast(mConnectedDeviceName, "Connected");
					Log.i("eRoutePrinting", "handleMessage: CONNECTED TO: " + msg.getData().getString(msgTypes.DEVICE_NAME));
					//printESCP();
					//updateConnectButton(false);

					break;
				case msgTypes.MESSAGE_TOAST:
					if (vistaActual != null)
					{
						if (reintentosOcultos >= 3 && !desconexionManual)
						{
							desconexionManual = false;
							Toast.makeText(((Activity) vistaActual).getBaseContext(), msg.getData().getString(msgTypes.TOAST), Toast.LENGTH_LONG).show();
						}
					}
					//                    Toast toast = Toast.makeText(getApplicationContext(), msg.getData().getString(msgTypes.TOAST), Toast.LENGTH_SHORT);//.show();
					//                    toast.setGravity(Gravity.CENTER,0,0);
					//                    toast.show();
					//myToast(msg.getData().getString(msgTypes.TOAST));
					//	if (msg.getData() == ""){

					//}
					//if (msg.getData().getString(msgTypes.TOAST).equalsIgnoreCase("Toast: connectionFailed")){

					//}
					//Log.i("eRoutePrinting", "handleMessage: TOAST: " + msg.getData().getString(msgTypes.TOAST));
					//addLog(msg.getData().getString(msgTypes.TOAST));
					break;
				case msgTypes.MESSAGE_INFO:
					//addLog(msg.getData().getString(msgTypes.INFO));
					//mLog.append(msg.getData().getString(msgTypes.INFO));
					//mLog.refreshDrawableState();
					String s = msg.getData().getString(msgTypes.INFO);
					if (s.length() == 0)
						s = String.format("int: %i" + msg.getData().getInt(msgTypes.INFO));
					Log.i("eRoutePrinting", "handleMessage: INFO: " + s);
					break;
			}
		}
	};

	/*
	 * public class PrintTask extends AsyncTask<String, Integer, String> {
	 * private static final String PROGRESS_CANCEL_MSG = "Printing cancelled\n";
	 * private static final String PROGRESS_COMPLETE_MSG =
	 * "Printing completed\n"; private static final String PROGRESS_ENDDOC_MSG =
	 * "End of document\n"; private static final String PROGRESS_FINISHED_MSG =
	 * "Printer connection closed\n"; private static final String
	 * PROGRESS_NONE_MSG = "Unknown progress message\n"; private static final
	 * String PROGRESS_STARTDOC_MSG = "Start printing document\n";
	 * 
	 * 
	 * 
	 * @Override protected void onPreExecute() { // Clears the Progress and
	 * Status text box. //textMsg.setText("");
	 * 
	 * // Disables the Print button. //buttonPrint.setEnabled(false);
	 * 
	 * // Shows a progress icon on the title bar to indicate // it is working on
	 * something. //setProgressBarIndeterminateVisibility(true); }
	 * 
	 * @Override protected String doInBackground(String... args) {
	 * 
	 * 
	 * String sResult = null; String sMacAddr = "00:1D:DF:55:6B:5E"; String path
	 * = args[0]; if (sMacAddr.contains(":") == false && sMacAddr.length() ==
	 * 12) { // If the MAC address only contains hex digits without the // ":"
	 * delimiter, then add ":" to the MAC address string. char[] cAddr = new
	 * char[17];
	 * 
	 * for (int i=0, j=0; i < 12; i += 2) { sMacAddr.getChars(i, i+2, cAddr, j);
	 * j += 2; if (j < 17) { cAddr[j++] = ':'; } }
	 * 
	 * sMacAddr = new String(cAddr); }
	 * 
	 * String sPrinterURI = "bt://" + sMacAddr; //String sUserText =
	 * editUserText.getText().toString();
	 * 
	 * LinePrinter.ExtraSettings exSettings = new LinePrinter.ExtraSettings();
	 * 
	 * exSettings.setContext(vistaActual);
	 * 
	 * try { BluetoothAdapter btAdapter = BluetoothAdapter.getDefaultAdapter();
	 * if (btAdapter==null) { throw new Exception("Bluetooth no soportado"); }
	 * 
	 * if (!btAdapter.isEnabled()){ throw new
	 * Exception("El Bluetooth no esta encendido"); }
	 * 
	 * File profiles = new File (path, "printer_profiles.JSON");
	 * 
	 * LinePrinter lp = new LinePrinter( profiles.getPath(), "PR2", sPrinterURI,
	 * exSettings);
	 * 
	 * // Registers to listen for the print progress events.
	 * 
	 * 
	 * //A retry sequence in case the bluetooth socket is temporarily not ready
	 * int numtries = 0; int maxretry = 2; while(numtries < maxretry) { try{
	 * lp.connect(); // Connects to the printer break; }
	 * catch(LinePrinterException ex){ numtries++; Thread.sleep(1000); } } if
	 * (numtries == maxretry) lp.connect();//Final retry
	 * 
	 * // Set font style to Bold + Double Wide + Double High. lp.setBold(true);
	 * lp.setDoubleWide(true); lp.setDoubleHigh(true); lp.write("SALES ORDER");
	 * lp.setDoubleWide(false); lp.setDoubleHigh(false); lp.newLine(2);
	 * 
	 * // The following text shall be printed in Bold font style.
	 * lp.write("CUSTOMER: Casual Step"); lp.setBold(false); // Returns to
	 * normal font. lp.newLine(2);
	 * 
	 * // Set font style to Compressed + Double High. lp.setDoubleHigh(true);
	 * lp.setCompress(true); lp.write("DOCUMENT# 123456789012");
	 * lp.setCompress(false); lp.setDoubleHigh(false); lp.newLine(2);
	 * 
	 * // The following text shall be printed in Normal font style.
	 * lp.write(" PRD. DESCRIPT.   PRC.  QTY.    NET."); lp.newLine(2);
	 * 
	 * lp.write(" 1501 Timer-Md1  13.15     1   13.15"); lp.newLine(1);
	 * lp.write(" 1502 Timer-Md2  13.15     3   39.45"); lp.newLine(1);
	 * lp.write(" 1503 Timer-Md3  13.15     1   13.15"); lp.newLine(1);
	 * lp.write(" 1504 Timer-Md4  13.15     4   52.60"); lp.newLine(1);
	 * lp.write(" 1505 Timer-Md5  13.15     5   65.75"); lp.newLine(1);
	 * lp.write("                        ----  ------"); lp.newLine(1);
	 * lp.write("              SUBTOTAL    15  197.25"); lp.newLine(2);
	 * 
	 * lp.write("                        ----  ------"); lp.newLine(1);
	 * lp.write("           TOTAL SALES    15  197.15"); lp.newLine(4);
	 * lp.write("               PRODUCT        179.25"); lp.newLine(1);
	 * lp.write("               DEPOSIT         18.00"); lp.newLine(1);
	 * lp.write("                              ------"); lp.newLine(1);
	 * lp.write("              SUBTOTAL        197.25"); lp.newLine(1);
	 * lp.write("      SUBTOTAL CREDITS          0.00"); lp.newLine(1);
	 * lp.write("           OTHER ITEMS          2.14"); lp.newLine(1);
	 * lp.write("                 LABOR          4.44"); lp.newLine(1);
	 * lp.write("          5% State Tax          9.86"); lp.newLine(2);
	 * 
	 * lp.write("                              ------"); lp.newLine(1);
	 * lp.write("           BALANCE DUE        213.74"); lp.newLine(1);
	 * lp.newLine(1);
	 * 
	 * lp.write(" PAYMENT TYPE: CASH"); lp.newLine(2);
	 * 
	 * lp.setDoubleHigh(true); lp.write("       SIGNATURE / STORE STAMP");
	 * lp.setDoubleHigh(false); lp.newLine(2);
	 * 
	 * // Print a signature file if it exists
	 * 
	 * lp.setBold(true);
	 * 
	 * 
	 * lp.write("          ORIGINAL"); lp.setBold(false); lp.newLine(4);
	 * 
	 * sResult = "Number of bytes sent to printer: " + lp.getBytesWritten();
	 * 
	 * lp.disconnect(); // Disconnects from the printer
	 * 
	 * lp.close(); // Releases resources } catch (LinePrinterException ex) {
	 * sResult = "LinePrinterException: " + ex.getMessage(); } catch (Exception
	 * ex) { if (ex.getMessage() != null) sResult = "Unexpected exception: " +
	 * ex.getMessage(); else sResult = "Unexpected exception."; }
	 * 
	 * // The result string will be passed to the onPostExecute method // for
	 * display in the the Progress and Status text box. return sResult; }
	 * 
	 * @Override protected void onPostExecute(String result) { // Displays the
	 * result (number of bytes sent to the printer or // exception message) in
	 * the Progress and Status text box. if (result != null) { if (vistaActual
	 * != null){ vistaActual.impresionFinalizada(true,result); } }else{ if
	 * (vistaActual != null){ vistaActual.impresionFinalizada(true,""); } } } }
	 * //endofclass PrintTask
	 */
}
