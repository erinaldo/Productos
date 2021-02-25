package com.amesol.routelite.actividades;

import java.io.BufferedInputStream;
import java.io.BufferedReader;
import java.io.ByteArrayOutputStream;
import java.io.DataInputStream;
import java.io.DataOutputStream;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.io.OutputStream;
import java.io.OutputStreamWriter;
import java.io.PrintWriter;
import java.lang.reflect.Array;
import java.net.SocketException;
import java.net.UnknownHostException;
import java.text.DecimalFormat;
import java.text.NumberFormat;
import java.util.ArrayList;

import java.util.Arrays;
import java.util.Collections;
import java.util.Enumeration;
import java.util.HashMap;
import java.util.Hashtable;
import java.util.List;
import java.util.Map;
import java.util.Set;
import java.util.UUID;


import android.bluetooth.BluetoothAdapter;
import android.bluetooth.BluetoothDevice;
import android.bluetooth.BluetoothSocket;
import android.content.ContentValues;
import android.content.Context;
import android.content.Intent;
import android.content.res.AssetManager;
import android.database.Cursor;
import android.database.DatabaseUtils;
import android.os.Handler;
import android.os.Looper;
import android.os.Message;
import android.util.Log;
import android.util.LogPrinter;
import android.widget.Toast;

import com.amesol.routelite.datos.CORTabla;
import com.amesol.routelite.datos.COTCampo;
import com.amesol.routelite.datos.Cliente;
import com.amesol.routelite.datos.ConfiguracionRecibo;
import com.amesol.routelite.datos.RECEncabezadoPie;
import com.amesol.routelite.datos.Recibo;
import com.amesol.routelite.datos.Vendedor;
import com.amesol.routelite.datos.basedatos.BDTerm;
import com.amesol.routelite.datos.basedatos.BDVend;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.basedatos.Consultas.ConsultasImpresionTicket;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.ArchivoConfiguracion.CampoConfiguracion;
import com.amesol.routelite.datos.utilerias.ConfiguracionLocal;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.IVista;
import com.amesol.routelite.utilerias.ControlError;
import com.amesol.routelite.utilerias.Generales;

public class Recibos {
	
	//ClienteActual
	private static Cliente oClienteAct;
	
	//modoEncabezadoPie
	public final  class ModoEncabezadoPie{
		private static final short ENCABEZADO = 1;
		private static final short PIE = 2;
	}
	
	//tipoPapel	
	public final  class TipoPapel{
		public final static short EXTECH_TERMICA2=1;
		public final static short EXTECH_TERMICA3=2;
		public final static short EXTECH_IMPACTO2 = 3;
		public final static short ZEBRA_TERMICA2 = 4;
		public final static short TEC_TERMICA2 = 5;
		public final static short CITIZEN2 = 6;
		public final static short ZEBRA_CAMEO2=7;
		public final static short STAR_DP8340 = 8;
	}

	public final class TipoAlineacion{
		public final static short IZQUIERDA = 0;
		public final static short DERECHA = 1;
		
	}
		
	
	private static final String CAMPOS_PRELIQUIDACION_DEPOSITOS = "FechaPreliquidacion, FechaDeposito, TipoBanco, Referencia, Total, Ficha" ;
	private static final String CAMPOS_PRELIQUIDACION_NODEPOSITOS = "FechaPreliquidacion, TipoEfectivo, Total";
	
	//Tamaños default
	private static TamanioLetra tamanioDefault = new TamanioLetra(50,48,0);
	//Tamaño actual de letra
	private static TamanioLetra mTamanioActual=new TamanioLetra(50,48,0);
	
	private static final Map<Integer,TamanioLetra> TAMANIOS_LETRA = llenarTamanios() ;
	
   private static Map<Integer, TamanioLetra> llenarTamanios() {         
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
	   return Collections.unmodifiableMap(result);     
	} 
   
   private static void setTamanioDefault(int partTipoPapel){
	   switch (partTipoPapel){
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
	   }
   }

   
   public static final int MESSAGE_STATE_CHANGE = 1;
   public static final int MESSAGE_READ = 2;
   public static final int MESSAGE_WRITE = 3;
   public static final int MESSAGE_DEVICE_NAME = 4;
   public static final int MESSAGE_TOAST = 5;
   
   public static final String TOAST = "toast";
   
   
	public  void imprimirRecibos(List<Map<String,String>> listaTickets, Boolean logoSoloPrimerRecibo, IVista vista) throws ControlError, Exception{
		Hashtable<String,ContentValues> archivosGenerados = new Hashtable<String,ContentValues>();
	
		String nombreArchivo = "";
		
		Vendedor vendedor = (Vendedor) Sesion.get(Campo.VendedorActual);
					
		ConfiguracionLocal conf = (ConfiguracionLocal) Sesion.get(Campo.ConfiguracionLocal);
		File impresion = new File(conf.get(CampoConfiguracion.DIRECTORIO_TRABAJO).toString());
		impresion = new File(impresion, "impresion");
		if (!impresion.exists()){
			if (!impresion.mkdirs()){
				//TODO Paula, crear mensaje, E0690 provisional
				throw new ControlError("E0690",impresion.getAbsolutePath());		
			}
		}

		//Limpiar el directorio de impresion			
		if (impresion.isDirectory()){
			File[] files = impresion.listFiles();         
			if(files != null) {             
				for(File f : files) {                    
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
		
		String[] byRefMsgError = {""};
		
		for (int i = 0; i<listaTickets.size(); i++){
			//TODO Paula, checar si tengo que enviar mensaje por cada recibo o si falla cualquier recibo parar.
			try{				
				//Si cambia el recibo Actual vuelvo a obtener la información
				if (reciboAct == null || reciboAct.Tipo != Short.parseShort(listaTickets.get(i).get("TipoRecibo")) ){
					reciboAct = ConsultasImpresionTicket.obtenerReciboPorTipoRecibo(Short.parseShort(listaTickets.get(i).get("TipoRecibo")), vendedor.TipoModImp, byRefMsgError);
					
					if (reciboAct == null){
						if (!byRefMsgError[0].equals("")){
							//Errores[0] = Errores[0].concat(byRefMsgError[0]);
							throw new Exception(byRefMsgError[0]);
						}
					}
					
					configuracionReciboAct =ConsultasImpresionTicket.obtenerConfiguracionReciboPorTipoRecibo(Short.parseShort(listaTickets.get(i).get("TipoRecibo")), byRefMsgError);
					if (configuracionReciboAct == null){
						if (!byRefMsgError.equals("")){
							//Errores[0] = Errores[0].concat(byRefMsgError[0]);
							throw new Exception( byRefMsgError[0]);
						}
					}
					/*if (sdCOTCampo !=null) sdCOTCampo.close();
					if (sdCORTabla !=null) sdCORTabla.close();
					
					sdCOTCampo = ConsultasImpresionTicket.obtenerCOTCampoPorCORId(configuracionReciboAct.CORId);
					sdCORTabla = ConsultasImpresionTicket.obtenerCORTablaPorCORId(configuracionReciboAct.CORId);
					*/
				}				
				nombreArchivo =  generarArchivoRecibo( listaTickets.get(i),impresion.getAbsolutePath(), reciboAct,configuracionReciboAct, imprimeLogo, byRefMsgError);
				if (logoSoloPrimerRecibo){
					imprimeLogo = false;
				}				
			}catch (Exception ex){
				throw new Exception(ex.getMessage());
			}							
			if (! archivosGenerados.containsKey(nombreArchivo) && !nombreArchivo.equals("")){
				ContentValues valoresRecibo = new ContentValues();
				valoresRecibo.put("TipoPapel", reciboAct.TipoPapel );
				valoresRecibo.put("MostrarLogo", reciboAct.MostrarLogo);
				archivosGenerados.put(nombreArchivo, valoresRecibo);
			}					
		}
		Enumeration<String> e = archivosGenerados.keys();
		String archivo = "";
		while (e.hasMoreElements()){
			archivo = e.nextElement();
			BluetoothPrint(vista, new File(impresion, archivo).getAbsolutePath(),archivosGenerados.get(archivo).getAsShort("TipoPapel"), archivosGenerados.get(archivo).getAsBoolean("MostrarLogo"));
		}
		
				
	}
	
	 void BluetoothPrint(IVista vista, String nombreArchivo, Short tipoPapel, boolean mostrarLogo ) throws Exception
	{
		
		BluetoothAdapter btAdapter = null;
		//BluetoothSocket btSocket =null;
		//final UUID MY_UUID = UUID.fromString("00001101-0000-1000-8000-00805f9b34fb");
		String MsgStr = "";
		InputStream inStream = null;
		BluetoothChatService BTService = null;

		try 
		{
			// file name to be printed
			String fileName =nombreArchivo;
			
			//Get BlueTooth Adapter
			btAdapter = BluetoothAdapter.getDefaultAdapter();
			if (btAdapter==null)
			{
				throw new Exception("Bluetooth no soportado");
			}
			
			if (!btAdapter.isEnabled()){
				throw new Exception("El Bluetooth no esta encendido");
			}
			//get the list of paired printer.
			Set<BluetoothDevice> pairedDevices = btAdapter.getBondedDevices();
			
			//if there is any paired device, get out
			if (pairedDevices.size()==0)
			{
				throw new Exception("No existe ningún dispositivo vinculado");
			}

			//verify the current selected printer is in the list of the paired printer.
			//tipoPapel = 1;
			ConfiguracionLocal config = (ConfiguracionLocal) Sesion.get(Campo.ConfiguracionLocal );
			String puerto = (String) config.get(CampoConfiguracion.PUERTO + "_" + tipoPapel);
			
			if (puerto == null){
				throw new Exception(Mensajes.get("E0708"));
			}
			
			BluetoothDevice selectedBTDevice = null;
			String deviceName = "";
			for( BluetoothDevice device : pairedDevices)
			{
				deviceName = device.getAddress() + "_" + device.getName();
				if (deviceName.compareTo(puerto)==0)
				{
					selectedBTDevice = device;
					break;
				}
			}
			
			//the current selected printer is not in the paired printer list
			if (selectedBTDevice==null)
			{
				throw new Exception("La impresora " +  deviceName + " no esta vinculado");
			}
			
			//create a BT Service object
			BTService = new BluetoothChatService( mHandler);
			
			//Start the BT Service
			BTService.start();
			
			//connecting to device - generate Bluetooth Socket, connecting to the device, and get the output stream for the socket.
			MsgStr = "connecting to " + selectedBTDevice.getName()+ "(" + selectedBTDevice.getAddress() + ")...";
			//DisplayPrintingStatusMessage(MsgStr);
			BTService.connect(selectedBTDevice);
			
			//wait for the connection has established
			 // Check that we're actually connected before trying anything
			int nWaitTime = 8;
	        while (BTService.getState() != BluetoothChatService.STATE_CONNECTED) 
	        {
	           Thread.sleep(1000);
	           nWaitTime--;
	           if (nWaitTime==0)
	           {
	        	   //DisplayPrintingStatusMessage("Unable to connect!");
	        	   throw( new Throwable("Unable To connect to " + selectedBTDevice.getName()+ "!"));
	           }
	        }
	        
			/*
			//read the data to be sent to printer
			// "Demo" is the folder (sub directory) we use to store the all
			// label sample file to be selected for printing.
	        inStream =  new BufferedInputStream(new FileInputStream(fileName));
			//inStream = assetManager.open("demo" + File.separator + fileName);

			// read data from file and save it into Byte Array Output Stream
			ByteArrayOutputStream bos = new ByteArrayOutputStream();
			//MsgStr = getString(R.string.read_data_from_file) + fileName;
			//DisplayPrintingStatusMessage(MsgStr);
			int nextByte = inStream.read();
			while (nextByte != -1) {
				bos.write(nextByte);
			
				nextByte = inStream.read();
			}
			
			byte[] finalArray = bos.toByteArray();
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
	        while ((strLine = br.readLine()) != null)   {
	        	if (strLine.equalsIgnoreCase("IMPRIME_LOGO")) {
	        		if (mostrarLogo){
	        			if (tipoPapel == TipoPapel.EXTECH_TERMICA2 || tipoPapel == TipoPapel.EXTECH_TERMICA3){
	        				buffer.write(new byte[]{27,76,103,48});
	        			}
	        		}
	        	}else if(strLine.startsWith("{")){
	        		if (tipoPapel == TipoPapel.EXTECH_TERMICA2 || tipoPapel == TipoPapel.EXTECH_TERMICA3){
	        			buffer.write(new byte[]{27,107,Byte.parseByte(strLine.substring(1, strLine.indexOf("}")))});
	        		}
	        		if (strLine.indexOf("}") + 1 != strLine.length()){
	        			buffer.write(strLine.substring(strLine.indexOf("}") + 1, strLine.length() -strLine.indexOf("}") + 1).getBytes());
	        		}
	        	}else{
	        		buffer.write(strLine.getBytes());
	        	}	        		      
	        	buffer.write(saltoLinea.getBytes());
	        }
	        //Close the input stream
	        in.close();
        
	        
			//Write data to the connected BT device
			//MsgStr = getString(R.string.send_data_to_printer);
			//DisplayPrintingStatusMessage(MsgStr);
			BTService.write(buffer.toByteArray());
			Thread.sleep(2000);						
			//MsgStr = getString(R.string.done_printing);

		} catch (SocketException e) {
			MsgStr = e.getMessage();
			throw new Exception( MsgStr);
		} catch (UnknownHostException e) {
			MsgStr = e.getMessage();
			throw new Exception( MsgStr);
		} catch (IOException e) {
			MsgStr = e.getMessage();
			throw new Exception( MsgStr);
		} catch (Throwable e) {
			MsgStr = e.getMessage();
			throw new Exception( MsgStr);
		} finally {
			if (inStream != null) {
				try {
					inStream.close();
					inStream = null;
				} catch (IOException e) { /* ignore */
				}
			}
						
			if (BTService!=null)
				BTService.stop();
			
		}

		// display the last result to the UI here
		//DisplayPrintingStatusMessage(MsgStr);
		return;
	}//BluetoothPrint()
	
	 // The Handler that gets information back from the BluetoothChatService
    private static final Handler mHandler = new Handler() {
        @Override
        public void handleMessage(Message msg) {
        	
        	switch (msg.what) 
            {
            case MESSAGE_STATE_CHANGE:
                Log.i("Recibos", "MESSAGE_STATE_CHANGE: " + msg.arg1);
                switch (msg.arg1) 
                {
                case BluetoothChatService.STATE_CONNECTED:
                	Log.i("Recibos","Connected");
                    break;
                case BluetoothChatService.STATE_CONNECTING:
                	//mConnectedBTDeviceName = msg.getData().getString(DEVICE_NAME);
                    Log.i("Recibos","Connecting...");
                    break;
                case BluetoothChatService.STATE_LISTEN:
                case BluetoothChatService.STATE_NONE:
                	Log.i("Recibos","Not Connected");
                    break;
                }
                break;
            case MESSAGE_WRITE:
                break;
            case MESSAGE_READ:
       
                break;
            case MESSAGE_DEVICE_NAME:
                // save the connected device's name
               // mConnectedBTDeviceName = msg.getData().getString(DEVICE_NAME);
                //Toast.makeText(getApplicationContext(), "Connected to "
                //        + mConnectedBTDeviceName, Toast.LENGTH_SHORT).show();
            	Log.i("Impresion", "Conectado...");
                break;
            case MESSAGE_TOAST:
                //Toast.makeText(getApplicationContext(), msg.getData().getString(TOAST),
                //               Toast.LENGTH_SHORT).show();
                break;
            }
        	
        }
    };
	/*private static void imprimirArchivo(String nombreArchivo){
						
		PrintWriter b = new PrintWriter();
		
	}*/
    
    public HashMap<String, String> getDocumentoImpresion(String _id, String tipo, String varCodigo, String tipoRecibo, String folio, String descTipo, String fecha, String total, String tipoFase, String clienteClave, String diaClave, String subEmpresaID, String facElec){
		HashMap<String, String> documento = new HashMap<String, String>();
		
		documento.put("_Id", _id);
		documento.put("Tipo", String.valueOf(tipo));
		documento.put("VARCodigo", varCodigo);
		documento.put("TipoRecibo", tipoRecibo);
		documento.put("Folio", folio);
		documento.put("DescTipo", ValoresReferencia.getDescripcion(varCodigo,String.valueOf(tipo)));
		documento.put("Fecha", fecha);
		documento.put("Total", total);
		documento.put("TipoFase", String.valueOf(tipoFase));
		documento.put("ClienteClave", clienteClave);
		documento.put("DiaClave", diaClave);
		documento.put("SubEmpresaID", subEmpresaID);
		documento.put("FacElec",  facElec);
		
		documento.put("TipoRecibo", obtenerTipoRecibo(documento));
		return documento;
	}
    
    public String obtenerTipoRecibo(Map<String,String> registro){
		String tipoRecibo ="0";
		
		int tipo =Integer.parseInt(registro.get("Tipo"));
		//if ((mAccion!= null)&&(mAccion.equals(Enumeradores.Acciones.ACCION_IMPRIMIR_TICKET_CON_VISITA))){
			if (registro.get("TipoRecibo").equals("TRP")){
				if ((tipo ==3 && !registro.get("TipoFase").equals(3)) || (tipo !=3)){					
					switch ( tipo){
					case 8:
						if (registro.get("FacElec").equals(1)){
							return "24"; // Facturacion Electronica
						}else{
							return "8";  // Facturacion
						}
					case 24:
						if (registro.get("TipoFase").equals(6)){
							return "26"; //Liquidacion
						}else{
							return "25"; //Consignación
						}
					case 1:
						if (Sesion.get(Campo.TipoModulo).equals(Enumeradores.TiposModulos.VENTA)){
							return "1";
						}else if (Sesion.get(Campo.TipoModulo).equals(Enumeradores.TiposModulos.PREVENTA)){
							return "27";
						}else if (Sesion.get(Campo.TipoModulo).equals(Enumeradores.TiposModulos.REPARTO)){
							return "28";
						}
					default:
						return registro.get("Tipo");					
					}
				}
			}else if (registro.get("TipoRecibo").equals("ABN")){
				return "10"; // Recibo de cobranza
			}
			
		/*}else if ((mAccion!= null)&&(mAccion.equals(Enumeradores.Acciones.ACCION_IMPRIMIR_TICKET_SIN_VISITA))){
			
		}*/
		return  tipoRecibo;
	}
    
	private static String generarArchivoRecibo(Map<String,String> datosTicket, String directorioArchivo, Recibo recibo, ConfiguracionRecibo configuracionRecibo, boolean imprimeLogo, String[] byRefMsgError) throws Exception{
		String nombreArchivo= "";
		
		try{
			nombreArchivo = "Recibos" +  Short.toString(recibo.TipoPapel);
			File archivoRecibo = new File(directorioArchivo, nombreArchivo);
			if (!archivoRecibo.exists()){
				if (!archivoRecibo.createNewFile()){
					//TODO Paula, cambiar mensaje
					byRefMsgError[0] =  "El archivo no se pudo crear";
					return "";
				}
			}
			
			//Valores default
			int columnasRecibo  = 48;
			StringBuilder  cadenaRecibo = new StringBuilder();

			if (imprimeLogo){
				cadenaRecibo.append("IMPRIME_LOGO\r\n");				
			}

			 if (Short.parseShort(datosTicket.get("Tipo")) == 8 && Short.parseShort(datosTicket.get("TipoRecibo"))== 24){
				 if (Short.parseShort(datosTicket.get("TipoFase")) == 0){
					   cadenaRecibo.append("\r\n");
					   cadenaRecibo.append(textoCentradoConSimbolo(Mensajes.get("XCancelada"), '*', columnasRecibo) + "\r\n");
				 }
			 }

			 String campoLlave = "";
		    if ( Short.parseShort(datosTicket.get("TipoRecibo")) == 10) {
		    	campoLlave = "ABNId";
		    }else if ( Short.parseShort(datosTicket.get("TipoRecibo")) == 13) {
		    	campoLlave = "PLIId";
		    }else{
		    	campoLlave = "TransProdID";
		    }
	               
			 crearEncabezadoPie(recibo, ModoEncabezadoPie.ENCABEZADO, datosTicket, cadenaRecibo, false);
			 crearGenerales(recibo, datosTicket, cadenaRecibo,  campoLlave );
			 crearDetalle(recibo, datosTicket, cadenaRecibo, campoLlave);
			 crearEncabezadoPie(recibo, ModoEncabezadoPie.PIE, datosTicket, cadenaRecibo, false);
			 
			 OutputStream f1 = new FileOutputStream(archivoRecibo,true); 
			 f1.write(cadenaRecibo.toString().getBytes()); 
			 Log.d("ImpresioTicket", cadenaRecibo.toString());
			 f1.close();
			 
		}catch (Exception ex){
			//TODO Paula, cambiar mensaje
			throw new Exception( "Error al generar ticket:" + ex.getMessage());
		}
		
		return nombreArchivo;
	}
	
	private static String textoCentradoConSimbolo(String texto, char simbolo, int longTotal){
		String resultado = "";
 
		int i = 1;
		while (i < longTotal){
			if(i == Math.round( longTotal/2) - Math.round((texto.length() + 2)/2)){
				resultado = resultado.concat(" " + texto + " ");
			}else{
				resultado = resultado.concat(String.valueOf(simbolo));
			}
		}	
		return resultado;
	}
	

	private static void crearEncabezadoPie(Recibo recibo, short modoEncabezadoPie, Map<String,String> datosTicket, StringBuilder cadenaRecibo, boolean soloSubEmpresa) throws Exception{
		try{
			
			ISetDatos sdRECEncabezadoPie = ConsultasImpresionTicket.obtenerRECEncabezadoPiePorRECId(recibo.RECId, modoEncabezadoPie);
			cadenaRecibo.append("\r\n");
			
			TamanioLetra tamanioLetra;
			boolean cambiarLetra = false;
			int tipoFormato = 0;
			String cadena ="";
			
			if (modoEncabezadoPie == ModoEncabezadoPie.ENCABEZADO){
				setTamanioDefault(recibo.TipoPapel);
				tamanioLetra = tamanioDefault;
				mTamanioActual = tamanioLetra;
				if ( recibo.TipoPapel  == TipoPapel.ZEBRA_TERMICA2  || recibo.TipoPapel  == TipoPapel.ZEBRA_CAMEO2  ) {
	                cadena = "{" + tamanioLetra.mTamanio  + " " + tamanioLetra.mAlto  + "}" + cadena;
	        	}
	            else{
	                cadena = "{" + tamanioLetra.mTamanio  + "}" + cadena;
	            }	
				cadenaRecibo.append(cadena + "\r\n");
			}			
			
			if (recibo.AgruparPorSubem && !soloSubEmpresa && modoEncabezadoPie == ModoEncabezadoPie.ENCABEZADO){
				 obtieneNotas(recibo, cadenaRecibo, modoEncabezadoPie);
			}			
				
			
			while (sdRECEncabezadoPie.moveToNext()){				
			    tamanioLetra =  TAMANIOS_LETRA.get(sdRECEncabezadoPie.getInt(sdRECEncabezadoPie.getColumnIndex("TipoLetra")));
				cambiarLetra = (tamanioLetra.mTamanio != mTamanioActual.mTamanio );
				mTamanioActual = tamanioLetra;
				ContentValues mapRECEncabezadoPie = new ContentValues();         
				DatabaseUtils.cursorRowToContentValues((Cursor)sdRECEncabezadoPie.getOriginal(), mapRECEncabezadoPie);                          
	            tipoFormato = mapRECEncabezadoPie.getAsShort("TipoFormato");
	            cadena = obtieneCadena(mapRECEncabezadoPie, datosTicket, soloSubEmpresa);
	            if (!cadena.equals("")){
	                cadena = alineaTexto( mapRECEncabezadoPie.getAsShort("TipoAlineacion") , cadena, tamanioLetra.mLongTotal);
	                if (cambiarLetra || recibo.TipoPapel == TipoPapel.EXTECH_IMPACTO2){
	                	if ( recibo.TipoPapel  == TipoPapel.ZEBRA_TERMICA2  || recibo.TipoPapel  == TipoPapel.ZEBRA_CAMEO2  ) {
	                        cadena = "{" + tamanioLetra.mTamanio  + " " + tamanioLetra.mAlto  + "}" + cadena;
	                	}
	                    else{
	                        cadena = "{" + tamanioLetra.mTamanio  + "}" + cadena;
	                    }
	                }
	                cadenaRecibo.append(cadena + "\r\n");
	            	//TODO falta toma de cadenas si el recibo es de facturacion	       
	            }
			}
			
			sdRECEncabezadoPie.close();
			cadenaRecibo.append("\r\n");
			
			if(modoEncabezadoPie == ModoEncabezadoPie.PIE){
				//TODO Paula, CrearEquivalencias......
			}
			
			if(!recibo.AgruparPorSubem && !soloSubEmpresa){
				obtieneNotas(recibo, cadenaRecibo, modoEncabezadoPie);
			}
			
			if (modoEncabezadoPie == ModoEncabezadoPie.PIE ){
				for (int i = 0; i<=8 ; i++){
					cadenaRecibo.append("\r\n");
				}
			}
			
		}catch(Exception ex){
			throw new Exception("CrearEncabezadoPie:" + ex.getMessage());
		}
	}
	
	private static void crearGenerales(Recibo oRecibo, Map<String,String> datosTicket, StringBuilder cadenaRecibo,  String campoLlave ) throws Exception{
		int yActual = -1;		
		int xMax = Integer.parseInt(ConsultasImpresionTicket.obtenerMaxOrdenXRECContenido(oRecibo.RECId));;

		String cadena ="";
		
		ISetDatos sdRECContenido = ConsultasImpresionTicket.obtenerRECContenidoPorRECId(oRecibo.RECId);
		boolean cambiarLetra = false;
		TamanioLetra tamanioLetra = tamanioDefault;
		int anchoColumna = 0;
		String cadenaGenerales;
		while (sdRECContenido.moveToNext()){
			
			if (yActual != sdRECContenido.getInt( sdRECContenido.getColumnIndex("OrdenY"))){
				if (yActual !=-1){
					cadenaRecibo.append(cadena + "\r\n"); 
				}
				yActual = sdRECContenido.getInt( sdRECContenido.getColumnIndex("OrdenY"));
				cadena = "";
			}
		    tamanioLetra =  TAMANIOS_LETRA.get(sdRECContenido.getInt(sdRECContenido.getColumnIndex("TipoLetra")));
			cambiarLetra = (tamanioLetra.mTamanio != mTamanioActual.mTamanio );
			mTamanioActual = tamanioLetra; 
			anchoColumna = Math.round(tamanioLetra.mLongTotal / xMax);
			ContentValues mapRECContenido = new ContentValues();         
			DatabaseUtils.cursorRowToContentValues((Cursor)sdRECContenido.getOriginal(), mapRECContenido);                          
			cadenaGenerales = obtieneCadenaGenerales(mapRECContenido, datosTicket, campoLlave);
			cadenaGenerales  = completaColumna(cadenaGenerales, anchoColumna);
			 if (cambiarLetra || oRecibo.TipoPapel == TipoPapel.EXTECH_IMPACTO2){
             	if ( oRecibo.TipoPapel  == TipoPapel.ZEBRA_TERMICA2  || oRecibo.TipoPapel  == TipoPapel.ZEBRA_CAMEO2  ) {
                     cadena = "{" + tamanioLetra.mTamanio  + " " + tamanioLetra.mAlto  + "}" + cadena;
             	}
                 else{
                     cadena = "{" + tamanioLetra.mTamanio  + "}" + cadena;
                 }
             }
			 cadena = cadena.concat(cadenaGenerales);
		}
		
		sdRECContenido.close();
		if (yActual != -1){
			cadenaRecibo.append(cadena + "\r\n");
		}
		
		cadenaRecibo.append("\r\n");
	}
	
	
	private static void crearDetalle(Recibo recibo, Map<String,String> datosTicket, StringBuilder cadenaRecibo, String campoLlave)throws Exception{		
		if (Short.parseShort(datosTicket.get("TipoRecibo")) != 13 && !recibo.AgruparPorSubem  ){		
			Boolean [] byRefImprimirEtiquetas = new Boolean[1];
			byRefImprimirEtiquetas[0] = new Boolean(false);
			if (!obtieneTitulos(recibo, cadenaRecibo, datosTicket, byRefImprimirEtiquetas)){
				return;
			}
			if (byRefImprimirEtiquetas[0]){
				imprimeLineaPunteada(cadenaRecibo, mTamanioActual.mLongTotal  );
			}
		}
		
		int tipoImpuesto = 0;
		if (oClienteAct != null){
			tipoImpuesto = oClienteAct.TipoImpuesto;
		}
		
		obtieneDetalles(recibo, datosTicket, campoLlave, cadenaRecibo);
		
		if (Short.parseShort(datosTicket.get("Tipo")) == 1 && recibo.AgruparPorPrecio ){
			imprimeLineaPunteada(cadenaRecibo, mTamanioActual.mLongTotal);
			cadenaRecibo.append(Mensajes.get("XTotalPrecio"));
			ISetDatos sdUnidadPrecioCantidad = ConsultasImpresionTicket.obtenerUnidadPrecioCantidad(datosTicket.get("_Id"));
			while (sdUnidadPrecioCantidad.moveToNext()){
				String cad = completaHasta(ValoresReferencia.getDescripcion("UNIDADV", sdUnidadPrecioCantidad.getString(sdUnidadPrecioCantidad.getColumnIndex("TipoUnidad"))), 22, TipoAlineacion.IZQUIERDA ,false );
				cad = cad.concat(completaHasta(Generales.getFormatoDecimal(sdUnidadPrecioCantidad.getDouble(sdUnidadPrecioCantidad.getColumnIndex("Precio")), "0.00") , 11, TipoAlineacion.DERECHA, false));
				cad = cad.concat(" = " + completaHasta(Generales.getFormatoDecimal(sdUnidadPrecioCantidad.getDouble(sdUnidadPrecioCantidad.getColumnIndex("CantidadProducto")), "0.##"),5, TipoAlineacion.DERECHA, true ));
			}
			sdUnidadPrecioCantidad.close();						
		}
	}
	
	private static void obtieneDetalles(Recibo recibo, Map<String,String> datosTicket, String campoLlave, StringBuilder cadenaRecibo)throws Exception {
		try{
			ISetDatos sdREODetalle =  ConsultasImpresionTicket.obtenerREODetallePorRECId(recibo.RECId );
		
			COTCampo oCOTCampoOrden = null;
			if (recibo.CORId != null && recibo.COTId != null && recibo.COCId != null){
				oCOTCampoOrden = new COTCampo();
				oCOTCampoOrden.CORId  = recibo.CORId;
				oCOTCampoOrden.COTId  = recibo.COTId;
				oCOTCampoOrden.COCId  = recibo.COCId;
				BDTerm.recuperar(oCOTCampoOrden);	
			}
			
			CORTabla oCORTablaOrden = null;
			if (recibo.COTId != null && recibo.CORId != null){
				oCORTablaOrden = new CORTabla();
				oCORTablaOrden.COTId = recibo.COTId;
				oCORTablaOrden.CORId = recibo.CORId;
				BDTerm.recuperar(oCORTablaOrden);
			}

		
			Hashtable<String, ArrayList<Object>> htCampos = new Hashtable<String, ArrayList<Object>>();
			ArrayList<String> arrTablas = new ArrayList<String>();
			
			String nombresCampos = "";
			while (sdREODetalle.moveToNext()){
				ArrayList<Object> config = new ArrayList<Object>();
				
				COTCampo oCOTCampo = new COTCampo();
				oCOTCampo.CORId  = sdREODetalle.getString(sdREODetalle.getColumnIndex("CORId"));
				oCOTCampo.COTId  = sdREODetalle.getString(sdREODetalle.getColumnIndex("COTId"));
				oCOTCampo.COCId  = sdREODetalle.getString(sdREODetalle.getColumnIndex("COCId"));
				BDTerm.recuperar(oCOTCampo);
				
				CORTabla oCORTabla = new CORTabla();
				oCORTabla.COTId = sdREODetalle.getString(sdREODetalle.getColumnIndex("COTId"));
				oCORTabla.CORId = sdREODetalle.getString(sdREODetalle.getColumnIndex("CORId"));
				BDTerm.recuperar(oCORTabla);
				
				nombresCampos = nombresCampos.concat(oCORTabla.Nombre + "." + oCOTCampo.Nombre + ",");
						
				config.add(sdREODetalle.getShort(sdREODetalle.getColumnIndex("TipoAlineacion")));
				config.add(sdREODetalle.getShort(sdREODetalle.getColumnIndex("TipoSeparador")));
				
				if(Integer.parseInt(datosTicket.get("Tipo")) == 13){
					if (oCOTCampo.Nombre.equalsIgnoreCase("FechaDeposito")){
						config.add(10);
					}else if(oCOTCampo.Nombre.equalsIgnoreCase("TipoBanco")){
						config.add(9);
					}else if (oCOTCampo.Nombre.equalsIgnoreCase("Referencia")){
						config.add(12);						
					}else if(oCOTCampo.Nombre.equalsIgnoreCase("Total")){
						config.add(7);						
					}else if(oCOTCampo.Nombre.equalsIgnoreCase("Ficha")){
						config.add(6);						
					}else if(oCOTCampo.Nombre.equalsIgnoreCase("TipoEfectivo")){
						config.add(20);
					}else{
						config.add(sdREODetalle.getInt(sdREODetalle.getColumnIndex("Tamanio")));
					}
				}else{
					config.add(sdREODetalle.getInt(sdREODetalle.getColumnIndex("Tamanio")));
				}
				config.add(sdREODetalle.getShort(sdREODetalle.getColumnIndex("CantidadEspacio")));
				config.add(sdREODetalle.getShort(sdREODetalle.getColumnIndex("TipoEspacio")));
				config.add(sdREODetalle.getShort(sdREODetalle.getColumnIndex("TipoFormato")));
				config.add(sdREODetalle.getInt(sdREODetalle.getColumnIndex("OrdenY")));
				if (!htCampos.contains(oCOTCampo.Nombre)){
					htCampos.put(oCOTCampo.Nombre, config);
				}
				if (!arrTablas.contains(oCORTabla.Nombre)){
					arrTablas.add(oCORTabla.Nombre );
				}
			}
			
			sdREODetalle.close();
			
			if (nombresCampos.length() >0){
				nombresCampos = nombresCampos.substring(0, nombresCampos.length() -1 );
			}
			
			String tablas= arrTablas.toString().replace("[", "");
			tablas = tablas.replace("]", "");
			
			if (Short.parseShort(datosTicket.get("TipoRecibo")) == 13){
				//TODO Paula, Implementar el GuardaDetallesPreliquidacion cuando se necesite.
			}else{
				guardaDetalles(recibo, nombresCampos, datosTicket, tablas, campoLlave, (oCORTablaOrden != null ? oCORTablaOrden.Nombre : "" ), (oCOTCampoOrden != null ? oCOTCampoOrden.Nombre : ""), cadenaRecibo, htCampos);
			}
		}catch (Exception ex){
			throw new Exception("obtieneDetalles" + ex.getMessage());
		}
	}
	
	private static void guardaDetalles(Recibo recibo, String campos, Map<String,String> datosTicket, String tabla, String campoLlave, String tablaOrden, String campoOrden, StringBuilder cadenaRecibo, Hashtable<String, ArrayList<Object>> htCampos) throws Exception{
		boolean incluirSubEmpresa = false;
		boolean incluirClaveProducto = false;
		boolean incluirTRPId = false;
		boolean incluirTPDId = false;
		boolean incluirPrecio = false;
		boolean incluirDesImp = false; 
		boolean incluirCant = false;
		
		if (recibo.AgruparPorSubem ){
			incluirSubEmpresa = campos.toUpperCase().contains("SUBEMPRESAID");
			campos = campos.concat(", Producto.SubEmpresaId ");
		}
		
		if (recibo.IncluirImpuestos || Short.parseShort(datosTicket.get("Tipo")) == 8){
			incluirClaveProducto = campos.toUpperCase().contains("PRODUCTOCLAVE");
			if (!incluirClaveProducto) campos = campos.concat(", Producto.ProductoClave");	
			
			if (Short.parseShort(datosTicket.get("Tipo")) == 8){
				incluirTRPId = campos.toUpperCase().contains("TRANSPRODID");
				if (!incluirTRPId)  campos = campos.concat(", TransProdDetalle.TransProdID");
				
				incluirTPDId = campos.toUpperCase().contains("TRANSPRODDETALLEID");
				if (!incluirTPDId) campos = campos.concat(", TransProdDetalle.TransProdDetalleID");
				
				incluirPrecio = campos.toUpperCase().contains("PRECIO");
				if(!incluirPrecio) campos = campos.concat(", TransProdDetalle.Precio");
				
				incluirDesImp = campos.toUpperCase().contains("DESCUENTOIMP");
				if (!incluirDesImp) campos = campos.concat(", TransProdDetalle.DescuentoImp");

				incluirCant = campos.toUpperCase().contains("CANTIDAD");
				if (!incluirCant) campos = campos.concat(", TransProdDetalle.Cantidad");				
			}			
		}
		
		ISetDatos sdDetalleRecibo = ConsultasImpresionTicket.obtenerDetalleRecibo(datosTicket.get("_Id"), Short.parseShort(datosTicket.get("Tipo")),  Short.parseShort(datosTicket.get("TipoRecibo")), tabla, campos, campoLlave, tablaOrden, campoOrden, recibo.AgruparPorSubem );

		String subEmpresaAct = "";
		int contador = 0;

		while (sdDetalleRecibo.moveToNext()){
			if (recibo.AgruparPorSubem ){
				if (!subEmpresaAct.equalsIgnoreCase("SubEmpresaId")){
					cadenaRecibo.append("\r\n");
					if (contador>0){
						cadenaRecibo.append("\r\n");
						cadenaRecibo.append("\r\n");
					}
					subEmpresaAct  = sdDetalleRecibo.getString(sdDetalleRecibo.getColumnIndex("SubEmpresaId"));
					
					Map<String,String> datosDetalle = new HashMap<String,String>();
					
					datosDetalle.put("_Id", datosTicket.get("_Id"));
					datosDetalle.put("TipoRecibo", datosTicket.get("TipoRecibo"));
					datosDetalle.put("ClienteClave", datosTicket.get("ClienteClave"));
					datosDetalle.put("SubEmpresaId", subEmpresaAct);
					crearEncabezadoPie(recibo, ModoEncabezadoPie.ENCABEZADO , datosDetalle, cadenaRecibo, true);
					Boolean [] byRefImprimirEtiquetas = new Boolean[1];
					byRefImprimirEtiquetas[0] = new Boolean(false);
					obtieneTitulos(recibo, cadenaRecibo, datosTicket, byRefImprimirEtiquetas);
					if (byRefImprimirEtiquetas[0]){
						imprimeLineaPunteada(cadenaRecibo, mTamanioActual.mLongTotal );
					}
				}
				contador ++;
			}
			
			int renglon = 0;
			String cadena = "";
			ArrayList<Object> config = new ArrayList<Object>();
			if (sdDetalleRecibo.getColumnCount()>0){
				config = htCampos.get(sdDetalleRecibo.getColumnName(0));
				renglon = Integer.parseInt(config.get(6).toString());
			}
			
			String tmpCadena = "";
			String nombreColumna = "";
			for(int i = 0; i < sdDetalleRecibo.getColumnCount(); i++){
				nombreColumna = sdDetalleRecibo.getColumnName(i);
				if (nombreColumna.equalsIgnoreCase("SubEmpresaId") && !incluirSubEmpresa) continue;
				if (nombreColumna.equalsIgnoreCase("ProductoClave") && recibo.IncluirImpuestos && !incluirClaveProducto) continue;
				if (Short.parseShort(datosTicket.get("Tipo")) == 8){
					if (nombreColumna.equalsIgnoreCase("TransProdId") && !incluirTRPId) continue;
					if (nombreColumna.equalsIgnoreCase("TransProdDetalleId") && !incluirTPDId) continue;
					if (nombreColumna.equalsIgnoreCase("Precio") && !incluirPrecio) continue;
					if (nombreColumna.equalsIgnoreCase("DescuentoImp") && !incluirDesImp) continue;
					if (nombreColumna.equalsIgnoreCase("Cantidad") && !incluirCant) continue;
				}
				
				if (campoLlave.equalsIgnoreCase("TransProdId") && nombreColumna.equalsIgnoreCase("TipoUnidad")){
					tmpCadena = ValoresReferencia.getDescripcion("UNIDADV", sdDetalleRecibo.getString(i));
				}else if(campoLlave.equalsIgnoreCase("ABNId") && nombreColumna.equalsIgnoreCase("TipoPago")){
					tmpCadena = ValoresReferencia.getDescripcion("PAGO", sdDetalleRecibo.getString(i));
				}else if (campoLlave.equalsIgnoreCase("ABNId") && nombreColumna.equalsIgnoreCase("TipoBanco")){				
					tmpCadena = ( sdDetalleRecibo.isNull(i) ? "" : ValoresReferencia.getDescripcion("TBANCO", sdDetalleRecibo.getString(i)));
				}else if(nombreColumna.equalsIgnoreCase("Precio")){
					if (recibo.IncluirImpuestos){
						//TODO: Paula, implementar cuando este la parte de los impuestos
					}else if(Short.parseShort(datosTicket.get("Tipo")) == 8){
						//TODO: Paula, implementar cuando se incluya la factura
					}else{
						tmpCadena = sdDetalleRecibo.getString(i);
					}
				}else if (Short.parseShort(datosTicket.get("Tipo")) == 8 && nombreColumna.equalsIgnoreCase("DescuentoImp") ){
					//TODO: Paula, cuando se implemente la facturacion y los impuestos
				}else if (Short.parseShort(datosTicket.get("Tipo")) == 8 && nombreColumna.equalsIgnoreCase("SubTotal") ){
					//TODO: Paula, cuando se implemente la facturacion y los impuestos
				}else{
					if (sdDetalleRecibo.isNull(i)){
						tmpCadena = "";
					}else{
						tmpCadena = sdDetalleRecibo.getString(i).trim();
					}
				}
				
				if (htCampos.containsKey(nombreColumna)){
					config = htCampos.get(nombreColumna);
					tmpCadena = completaColumna(tmpCadena, Integer.parseInt(config.get(2).toString()), Integer.parseInt(config.get(0).toString()), Integer.parseInt(config.get(1).toString()), Integer.parseInt(config.get(5).toString()));
					if (Integer.parseInt(config.get(3).toString()) > 0){
						tmpCadena = agregarEspaciosColumna(Integer.parseInt(config.get(4).toString()), tmpCadena, Integer.parseInt(config.get(3).toString()));
					}
					
					if(renglon != Integer.parseInt(config.get(6).toString())){
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
	
	private static void imprimeLineaPunteada(StringBuilder cadenaRecibo, int longTotal){
		char c = '-';           
		char[] chars = new char[longTotal]; 
		Arrays.fill(chars, c); 
		cadenaRecibo.append(String.valueOf(chars) + "\r\n"); 
	}

	private static boolean obtieneTitulos(Recibo recibo, StringBuilder cadenaRecibo, Map<String,String> datosTicket, Boolean [] byRefImprimioEtiquetas) throws Exception{
		return obtieneTitulos(recibo, cadenaRecibo, datosTicket,false, false, byRefImprimioEtiquetas);
	}
	
	private static boolean obtieneTitulos(Recibo recibo, StringBuilder cadenaRecibo, Map<String,String> datosTicket, boolean bPreliquidacion, boolean bDepositos, Boolean [] byRefImprimioEtiquetas) throws Exception{
		int yActual = -1;
		
		 try{
			 int xMax = ConsultasImpresionTicket.obtenerMaxOrdenXREODetalle(recibo.RECId);
			 if (xMax  <= 0){
				 return false;
			 }
			 
			 ISetDatos sdREODetalle = ConsultasImpresionTicket.obtenerREODetallePorRECId(recibo.RECId);
			 String cadena = "";
			 boolean primerColumna = true;
			 boolean cambiarLetra = false;
			TamanioLetra tamanioLetra = tamanioDefault;
			String cadenaDetallesT = "";	
			 while (sdREODetalle.moveToNext()){
				 if (yActual != sdREODetalle.getInt( sdREODetalle.getColumnIndex("OrdenY"))){
						if (yActual !=-1){
							cadenaRecibo.append(cadena + "\r\n"); 
						}
						yActual = sdREODetalle.getInt( sdREODetalle.getColumnIndex("OrdenY"));
						cadena = "";
					}
				 if (primerColumna){
					tamanioLetra =  TAMANIOS_LETRA.get(sdREODetalle.getInt(sdREODetalle.getColumnIndex("TipoLetra")));
					cambiarLetra = (tamanioLetra.mTamanio != mTamanioActual.mTamanio );
					mTamanioActual = tamanioLetra; 
					primerColumna = false;
				 }else{
					cambiarLetra = false;
				 }
				 ContentValues mapREODetalle = new ContentValues();         
				 DatabaseUtils.cursorRowToContentValues((Cursor)sdREODetalle.getOriginal(), mapREODetalle);            
				 cadenaDetallesT = obtieneCadenaDetallesT(datosTicket, mapREODetalle, bPreliquidacion, bDepositos, byRefImprimioEtiquetas);
				 if (cambiarLetra || recibo.TipoPapel == TipoPapel.EXTECH_IMPACTO2){
		             	if ( recibo.TipoPapel  == TipoPapel.ZEBRA_TERMICA2  || recibo.TipoPapel  == TipoPapel.ZEBRA_CAMEO2  ) {
		                     cadenaDetallesT = "{" + tamanioLetra.mTamanio  + " " + tamanioLetra.mAlto  + "}" + cadenaDetallesT;
		             	}
		                 else{
		                     cadenaDetallesT = "{" + tamanioLetra.mTamanio  + "}" + cadenaDetallesT;
		                 }
		             }
				 cadena = cadena.concat(cadenaDetallesT);				 				 
			 }
			 sdREODetalle.close();
			 if (yActual != -1){
				 cadenaRecibo.append(cadena + "\r\n");
			 }			 			
		 } catch (Exception ex){
			 throw new Exception (ex.getMessage());
         //MsgBox(ex.Message, MsgBoxStyle.Information, "ObtieneTitulos")
		 }
		 return true;
	}
	
	private static String obtieneCadenaDetallesT(Map<String,String> datosTicket,ContentValues mapREODetalle, boolean bPreliquidacion, boolean bDeposito, Boolean [] byRefImprimioEtiquetas) throws Exception{
		String cadena ="";
		boolean recuperar = true;
		if (mapREODetalle.getAsShort("TipoEtiqueta") == 1 ){
			COTCampo oCOTCampo = new COTCampo();
			oCOTCampo.CORId  = mapREODetalle.getAsString("CORId");
			oCOTCampo.COTId  = mapREODetalle.getAsString("COTId");
			oCOTCampo.COCId  = mapREODetalle.getAsString("COCId");
			BDTerm.recuperar(oCOTCampo);
			
			if (bPreliquidacion){				
				if (bDeposito){					
					recuperar = (CAMPOS_PRELIQUIDACION_DEPOSITOS.contains( oCOTCampo.Nombre));					
				}else{
					recuperar = (CAMPOS_PRELIQUIDACION_NODEPOSITOS.contains( oCOTCampo.Nombre));
				}
			}
			if (recuperar){
				int tamanio = 0;
				cadena = oCOTCampo.Descripcion;
				if (bPreliquidacion){
					if (oCOTCampo.Nombre.equalsIgnoreCase("FechaDeposito")){
						tamanio = 10;						
					}else if(oCOTCampo.Nombre.equalsIgnoreCase("TipoBanco")){
						tamanio = 9;
					}else if(oCOTCampo.Nombre.equalsIgnoreCase("Referencia")){
						tamanio = 12;
					}else if (oCOTCampo.Nombre.equalsIgnoreCase("Total")){
						tamanio = 7 ;						
					}else if (oCOTCampo.Nombre.equalsIgnoreCase("Ficha")){
						tamanio = 6;
					}else if (oCOTCampo.Nombre.equalsIgnoreCase("TipoEfectivo")){
						tamanio = 19;
					}else{
						tamanio = mapREODetalle.getAsInteger("Tamanio");
					}
				}else{
					tamanio = mapREODetalle.getAsInteger("Tamanio");
				}
				cadena =completaColumna(cadena, tamanio);
				if (mapREODetalle.getAsShort("TipoSeparador") != 0){
					cadena = cadena.concat(ValoresReferencia.getDescripcion("SEPARADO", mapREODetalle.getAsString("TipoSeparador")));					
				}
				cadena = agregarEspaciosColumna(mapREODetalle.getAsInteger("TipoEspacio"), cadena, mapREODetalle.getAsInteger("CantidadEspacio"));
			}			
			byRefImprimioEtiquetas[0] = true; 
		}
		return cadena;
	}
	
	private static String completaColumna(String texto, int anchoColumna, int alineacion, int separador, int tipoFormato ){
		String resCadena = texto;
		switch (tipoFormato){
			case 1: resCadena = Generales.getFormatoDecimal(Double.parseDouble(resCadena), "#,##0");
				break;
			case 2: resCadena = Generales.getFormatoDecimal(Double.parseDouble(resCadena), "#,##0.00");
		}
		if (resCadena.length() > anchoColumna){
			resCadena  = resCadena.substring(0, anchoColumna);
		}
		int tamanioSeparador = 0;
		if (separador !=0){
			tamanioSeparador = ValoresReferencia.getDescripcion("SEPARADO", Integer.toString(separador)).length();
		}
		
		if (alineacion == 0 || alineacion == 1){
			int totalAncho= anchoColumna + tamanioSeparador;
			resCadena = String.format("%-" + totalAncho + "s" , resCadena);
		}else if (alineacion ==2){
			long tamanioIzquierdo = Math.round(Math.ceil(((anchoColumna + tamanioSeparador) - resCadena.length())/2));
			long tamanioDerecho = Math.round(Math.floor(((anchoColumna + tamanioSeparador) - resCadena.length())/2));
			long totalAncho =  resCadena.length() + tamanioIzquierdo;
			resCadena = String.format("%-" + totalAncho + "s" , resCadena);
			totalAncho = resCadena.length() + tamanioDerecho;
			resCadena = String.format("%" + totalAncho + "s", resCadena); 
		}else if (alineacion == 3){
			int totalAncho = anchoColumna + tamanioSeparador;
			resCadena = String.format("%" + totalAncho + "s" , resCadena);
		}		
		return resCadena;
	}
	
	private static String completaHasta(String texto, int espacios, short tipoAlineacion, boolean ultimaColumna ){
		String res ="";
		if (texto.length() >= espacios){
			if (ultimaColumna){
				return texto.substring(0, espacios);
			}else{
				return texto.substring(0, espacios -1) + " ";
			}
		}else{
			if(tipoAlineacion == TipoAlineacion.IZQUIERDA ){
				return String.format("%" + (texto.length() + espacios) + "s", texto);
			}else if(tipoAlineacion == TipoAlineacion.DERECHA ){
				return String.format("%-" + (texto.length() + espacios) + "s", texto);
			}
		}
		return res;
	}
	
	private static String agregarEspaciosColumna(int tipoEspacio, String texto, int cantidadEspacio){
		if (cantidadEspacio > 0){
			int longTotal = texto.length() + cantidadEspacio;
			switch (tipoEspacio){
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

	private static String completaColumna(String texto, int anchoColumna){
		int longTexto = texto.length();
		if (longTexto >= anchoColumna){
			return texto.substring(0, anchoColumna);
		}else{
			
			return String.format("%-" + anchoColumna + "s", texto);
		}
	}
	
	
    private  static String  alineaTexto(short tipoAlineacion , String texto, int longTotal ){
    	switch (tipoAlineacion){
	    	case 2: return textoCentrado(texto,longTotal);
	    	case 3: return textoDerecha(texto, longTotal);
    	}
    	
    	return texto;
    }

private static String textoCentrado(String texto, int longTotal ){
	String espacios = "";
	int tamTexto  = texto.length();

	for (int i = 1;i < Math.round((longTotal - tamTexto)/2);i++){
		espacios = espacios.concat(" ");
	}	
    return espacios.concat(texto);
}
    
private static String textoDerecha(String texto, int longTotal ){
	String espacios = "";

	for (int i = 1;i < longTotal - texto.length();i++){
		espacios = espacios.concat(" ");
	}	
    return espacios.concat(texto);
}

	private static void obtieneNotas(Recibo recibo, StringBuilder cadenaRecibo, short modoEncabezadoPie){
		
		ISetDatos sdRECNota = ConsultasImpresionTicket.obtenerRECNotaPorRECId(recibo.RECId, modoEncabezadoPie);
		String nota = "";
		TamanioLetra tamanioLetra = tamanioDefault;
		boolean cambiarLetra = false;
		while (sdRECNota.moveToNext()){
			tamanioLetra = TAMANIOS_LETRA.get(sdRECNota.getInt(sdRECNota.getColumnIndex("TipoLetra")));
			cambiarLetra = (tamanioLetra.mTamanio != mTamanioActual.mTamanio );
			mTamanioActual = tamanioLetra; 
			nota = alineaTexto(sdRECNota.getShort(sdRECNota.getColumnIndex("TipoAlineacion")), sdRECNota.getString(sdRECNota.getColumnIndex("Texto")), tamanioLetra.mLongTotal);
			if (cambiarLetra || recibo.TipoPapel == TipoPapel.EXTECH_IMPACTO2 ){
				if (recibo.TipoPapel  == TipoPapel.ZEBRA_CAMEO2 || recibo.TipoPapel == TipoPapel.ZEBRA_TERMICA2 ){
					nota = nota.concat("{" + tamanioLetra.mTamanio + " " + tamanioLetra.mAlto + "}" + nota + "\r\n");
				}else{
					nota = nota.concat("{" + tamanioLetra.mTamanio + "}" + nota + "\r\n");
				}
			}
			
			cadenaRecibo.append(nota + "\r\n");
			
			for (int i = 0; i < sdRECNota.getInt(sdRECNota.getColumnIndex("RenglonBlanco")); i++){
				cadenaRecibo.append("\r\n");
			}
		}
		
		if (modoEncabezadoPie == ModoEncabezadoPie.ENCABEZADO){
			cadenaRecibo.append(textoCentrado(Mensajes.get("Ximpresion") + ": " + Generales.getFechaHoraActualStr("dd/MM/yy HH:mm:ss"), tamanioLetra.mLongTotal) + "\r\n");
			cadenaRecibo.append("\r\n");
		}

        sdRECNota.close();
	}
	
	private static String obtieneCadena(ContentValues mapRECEncabezadoPie, Map<String,String> datosTicket, boolean soloSubempresa) throws Exception{
		String cadena = "";
		COTCampo oCOTCampo = new COTCampo();
		oCOTCampo.CORId  = mapRECEncabezadoPie.getAsString("CORId");
		oCOTCampo.COTId  = mapRECEncabezadoPie.getAsString("COTId");
		oCOTCampo.COCId  = mapRECEncabezadoPie.getAsString("COCId");
		BDTerm.recuperar(oCOTCampo);
		
		CORTabla oCORTabla = new CORTabla();
		oCORTabla.COTId = mapRECEncabezadoPie.getAsString("COTId");
		oCORTabla.CORId = mapRECEncabezadoPie.getAsString("CORId");
		BDTerm.recuperar(oCORTabla);
		short tipoRecibo = Short.parseShort(datosTicket.get("TipoRecibo")) ;
		
		if (soloSubempresa && !oCORTabla.Nombre.equalsIgnoreCase("SubEmpresa")) return "";		
		if (oCORTabla.Nombre.equalsIgnoreCase("SubEmpresa") && datosTicket.get("SubEmpresaID").toString().equals("") )  return "";
		
		if (mapRECEncabezadoPie.getAsShort("TipoEtiqueta") == 1){
			cadena = cadena.concat(oCOTCampo.Descripcion);
			if (mapRECEncabezadoPie.getAsShort("TipoSeparador") != 0){
				cadena = cadena.concat( ValoresReferencia.getDescripcion("SEPARADO", mapRECEncabezadoPie.getAsString("TipoSeparador")));				
			}			
		}
		
		String valorCampo = "";
		
		if (oCORTabla.Nombre.equalsIgnoreCase("Preliquidacion") && oCORTabla.Nombre.equalsIgnoreCase("Preliquidacion")){
			if (datosTicket.containsKey("TotalPreliquidado")){
				cadena = cadena.concat(Generales.getFormatoDecimal(Double.parseDouble(datosTicket.get("TotalPreliquidado")), "#,##0.00"));
			}
		}else if ((tipoRecibo == 24 || tipoRecibo == 8)  &&  oCORTabla.Nombre.equalsIgnoreCase("TransProd") && oCOTCampo.Nombre.equalsIgnoreCase("Impuesto") && (oClienteAct != null && oClienteAct.DesgloseImpuesto )){
			//TODO Pendiente Recibo Facturacion
		}else if ((tipoRecibo == 24 || tipoRecibo == 8)  &&  oCORTabla.Nombre.equalsIgnoreCase("TransProd") && (oCOTCampo.Nombre.equalsIgnoreCase("DescuentoImp") || oCOTCampo.Nombre.equalsIgnoreCase("SubTDetalle")) && (oClienteAct != null && oClienteAct.DesgloseImpuesto )){
			//TODO Pendiente Recibo Facturacion
		}else{
			if (oCORTabla.Nombre.equalsIgnoreCase("FolioFiscal") && tipoRecibo == 24){
				//TODO Pendiente Recibo Facturacion
			}else if ((oCORTabla.Nombre.equalsIgnoreCase("TPDDes") || oCORTabla.Nombre.equalsIgnoreCase("TpdDesVendedor")) && oCOTCampo.Nombre.equalsIgnoreCase("desImorte")  && tipoRecibo == 24 ){
				//TODO Pendiente Recibo Facturacion
			}else if( oCORTabla.Nombre.equalsIgnoreCase("TransProd") && tipoRecibo == 26){
				//TODO Pendiente Recibo Liquidacion de Consigna
			}else{	
				String id = "";
				if (oCORTabla.Nombre.equalsIgnoreCase("Cliente")){
					id =datosTicket.get("ClienteClave") ;
				}else if (oCORTabla.Nombre.equalsIgnoreCase("SubEmpresa")) {
					id = datosTicket.get("SubEmpresaID") ;
				}else {
					id = datosTicket.get("_Id") ;
				}
				
				valorCampo = ConsultasImpresionTicket.obtenerValorCampo(id, oCOTCampo.Nombre , oCORTabla.Nombre , tipoRecibo, oCOTCampo.TipoCampo );
			}
		}
		if (mapRECEncabezadoPie.getAsShort("TipoFormato") == 1 ){
			cadena = cadena.concat(Generales.getFormatoDecimal(Double.parseDouble(valorCampo), "#,##0"));
		}else if (mapRECEncabezadoPie.getAsShort("TipoFormato") == 2){
			cadena =cadena.concat(Generales.getFormatoDecimal(Double.parseDouble(valorCampo), "#,##0.00"));			
		}else{
			cadena =cadena.concat(valorCampo);
		}		
		
		return cadena;
		
	}
	
	private static String obtieneCadenaGenerales(ContentValues mapRECContenido, Map<String,String> datosTicket, String campoLlave)throws Exception{
		String cadena = "";
		
		COTCampo oCOTCampo = new COTCampo();
		oCOTCampo.CORId  = mapRECContenido.getAsString("CORId");
		oCOTCampo.COTId  = mapRECContenido.getAsString("COTId");
		oCOTCampo.COCId  = mapRECContenido.getAsString("COCId");
		BDTerm.recuperar(oCOTCampo);
		
		CORTabla oCORTabla = new CORTabla();
		oCORTabla.COTId = mapRECContenido.getAsString("COTId");
		oCORTabla.CORId = mapRECContenido.getAsString("CORId");
		BDTerm.recuperar(oCORTabla);
		
		short tipoRecibo = Short.parseShort(datosTicket.get("TipoRecibo")) ;
		
		if (mapRECContenido.getAsShort("TipoEtiqueta")==1){
			cadena = cadena.concat(oCOTCampo.Descripcion);
			if (mapRECContenido.getAsShort("TipoSeparador") != 0 ){
				cadena = cadena.concat(ValoresReferencia.getDescripcion("SEPARADO", mapRECContenido.getAsString("TipoSeparador")));
			}
		}
		
		String valorCampo = "";
		 if ( campoLlave.equalsIgnoreCase("TransProdID") && oCOTCampo.Nombre.equalsIgnoreCase("DiasCredito") && Short.parseShort(datosTicket.get("Tipo"))==8 ) {
			 valorCampo = ConsultasImpresionTicket.obtenerDiasCredito(datosTicket.get("_Id"));
		 }else{
			 valorCampo = ConsultasImpresionTicket.obtenerValorCampo(datosTicket.get("_Id"), oCOTCampo.Nombre, oCORTabla.Nombre, tipoRecibo, oCOTCampo.TipoCampo );
		 }
		
		 if (campoLlave.equalsIgnoreCase("TransProdId")){
			 if (oCOTCampo.Nombre.equalsIgnoreCase("TipoMotivo")){
				cadena = cadena.concat(ValoresReferencia.getDescripcion("TRPMOT", valorCampo)); 
			 }else if (oCOTCampo.Nombre.equalsIgnoreCase("TipoFase")){
				cadena = cadena.concat(ValoresReferencia.getDescripcion("TRPFASE", valorCampo)); 
			 }else if(oCOTCampo.Nombre.equalsIgnoreCase("CFVTipo")){
				cadena = cadena.concat(ValoresReferencia.getDescripcion("FVENTA", valorCampo)); 
			 }else{
				 cadena = cadena.concat(valorCampo);
			 }
		 }else{
			 cadena = cadena.concat(valorCampo);
		 }
		 
		return cadena;
	}

	
	private static  class TamanioLetra{		
		public int mTamanio;
		public int mLongTotal;
		public int mAlto;
		
		public TamanioLetra(int tamanio, int longTotal, int alto){
			mTamanio = tamanio;
			mLongTotal = longTotal;
			mAlto = alto;			
		}
	}
}


