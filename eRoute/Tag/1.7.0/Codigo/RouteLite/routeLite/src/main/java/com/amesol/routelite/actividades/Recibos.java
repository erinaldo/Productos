package com.amesol.routelite.actividades;

import android.app.Activity;
import android.bluetooth.BluetoothAdapter;
import android.bluetooth.BluetoothDevice;
import android.content.ContentValues;
import android.content.Context;
import android.content.Intent;
import android.content.pm.ActivityInfo;
import android.database.Cursor;
import android.database.DatabaseUtils;
import android.net.Uri;
import android.os.Bundle;
import android.os.Handler;
import android.os.Message;
import android.serialport.SerialPort;
import android.util.Log;
import android.widget.Toast;

import com.amesol.routelite.actividades.Enumeradores.msgTypes;
import com.amesol.routelite.datos.CORTabla;
import com.amesol.routelite.datos.COTCampo;
import com.amesol.routelite.datos.Cliente;
import com.amesol.routelite.datos.ClienteDomicilio;
import com.amesol.routelite.datos.ConfiguracionRecibo;
import com.amesol.routelite.datos.Dia;
import com.amesol.routelite.datos.Precio;
import com.amesol.routelite.datos.Recibo;
import com.amesol.routelite.datos.Ruta;
import com.amesol.routelite.datos.TransProd;
import com.amesol.routelite.datos.Usuario;
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
import com.amesol.routelite.datos.utilerias.ConfigParametro;
import com.amesol.routelite.datos.utilerias.ConfiguracionLocal;
import com.amesol.routelite.datos.utilerias.MOTConfiguracion;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.IVista;
import com.amesol.routelite.presentadores.interfaces.ICapturaDeposito;
import com.amesol.routelite.utilerias.ControlError;
import com.amesol.routelite.utilerias.DeviceControl;
import com.amesol.routelite.utilerias.Generales;
import com.amesol.routelite.utilerias.Print;
import com.amesol.routelite.vistas.ImpresionTicket;
import com.amesol.routelite.vistas.PDFViewer;
import com.amesol.routelite.vistas.Vista;
import com.amesol.routelite.vistas.utilerias.NumeroALetra;
import com.itextpdf.text.BaseColor;
import com.itextpdf.text.Document;
import com.itextpdf.text.Element;
import com.itextpdf.text.Font;
import com.itextpdf.text.Paragraph;
import com.itextpdf.text.Phrase;
import com.itextpdf.text.Rectangle;
import com.itextpdf.text.pdf.PdfPCell;
import com.itextpdf.text.pdf.PdfPHeaderCell;
import com.itextpdf.text.pdf.PdfPTable;
import com.itextpdf.text.pdf.PdfWriter;

import org.apache.commons.lang3.StringUtils;

import java.io.BufferedReader;
import java.io.ByteArrayOutputStream;
import java.io.DataInputStream;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.OutputStream;
import java.lang.reflect.Method;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Calendar;
import java.util.Collections;
import java.util.Date;
import java.util.Enumeration;
import java.util.HashMap;
import java.util.Hashtable;
import java.util.List;
import java.util.Locale;
import java.util.Map;

public class Recibos
{

    public static final int MESSAGE_STATE_CHANGE = 1;
    public static final int MESSAGE_READ = 2;
    public static final int MESSAGE_WRITE = 3;
    public static final int MESSAGE_DEVICE_NAME = 4;
    public static final int MESSAGE_TOAST = 5;
    public static final String TOAST = "toast";
    private static final int REQUEST_BT_SETTINGS = 777;
    private static final String CAMPOS_PRELIQUIDACION_DEPOSITOS = "FechaPreliquidacion, FechaDeposito, TipoBanco, Referencia, Total, Ficha";
    private static final String CAMPOS_PRELIQUIDACION_NODEPOSITOS = "FechaPreliquidacion, TipoEfectivo, Total";
    private static final Map<Integer, TamanioLetra> TAMANIOS_LETRA = llenarTamanios();
    //ClienteActual
    private static Cliente oClienteAct;
    //Tamaños default
    private static TamanioLetra tamanioDefault = new TamanioLetra(50, 48, 0);
    //Tamaño actual de letra
    private static TamanioLetra mTamanioActual = new TamanioLetra(50, 48, 0);
    private static Font tituloRojo = new Font(Font.FontFamily.COURIER, 22, Font.BOLD, BaseColor.RED);
    private static Font textoNegrita = new Font(Font.FontFamily.COURIER, 17, Font.BOLD);
    private static Font tituloSubrayado = new Font(Font.FontFamily.COURIER, 17, Font.BOLD + Font.UNDERLINE);
    public IVista vistaActual;
    private static int orientacion  = ActivityInfo.SCREEN_ORIENTATION_PORTRAIT;

    //variables globales para usar en cada impresion
    //cuidar donde se inicializan y donde se terminan
    btPrintFile btPrintService = null;
    BluetoothAdapter btAdapter = null;
    BluetoothDevice device;
    String fileName = "";
    boolean intentosConexion[] =
            {false};
    short numCopias = 0;
    boolean mostrarLogo = false;
    Short tipoPapel = 0;
    short reintentosOcultos = 0;
    boolean doorOpen = false;
    boolean desconexionManual = false;
    private final Handler mHandler = new Handler() {
        @Override
        public void handleMessage(Message msg) {
            super.handleMessage(msg);
            switch (msg.what) {
                case msgTypes.MESSAGE_STATE_CHANGE:
                    Bundle bundle = msg.getData();
                    int status = bundle.getInt("state");
                    //if (D)
                    //Log.i("eRoutePrinting", "handleMessage: MESSAGE_STATE_CHANGE: " + msg.arg1);  //arg1 was not used! by btPrintFile
                    //setConnectState(msg.arg1);
                    switch (msg.arg1) {
                        case btPrintFile.STATE_CONNECTED:
                            try {
                                iniciarImpresion();
                            } catch (Exception ex) {
                                if (vistaActual != null)
                                    vistaActual.mostrarError(ex.getMessage());
                            }

                            //addLog("connected to: " + mConnectedDeviceName);
                            //mConversationArrayAdapter.clear();
                            //Log.i("eRoutePrinting", "handleMessage: STATE_CONNECTED: " + mConnectedDeviceName);
                            break;
                        case btPrintFile.STATE_CONNECTING:
                            if (vistaActual != null) {
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
                            if (doorOpen) {
                                doorOpen = false;
                                intentosConexion[0] = false;
                                if (vistaActual != null) {
                                    vistaActual.mostrarPreguntaReintentarConexionImpresora("La puerta de la impresora esta abierta. Favor de cerrala. ¿Desea reintentar?", btPrintService, device, intentosConexion);
                                }
                            } else if (intentosConexion[0]) {
                                intentosConexion[0] = false;
                                if (reintentosOcultos < 3) {
                                    reintentosOcultos += 1;
                                    try {
                                        Method m = device.getClass()
                                                .getMethod("createBond", (Class[]) null);
                                        m.invoke(device, (Object[]) null);

                                        Thread.sleep(3000);
                                    } catch (Exception ex) {
                                        if (vistaActual != null) {
                                            Toast.makeText((Activity) vistaActual, ex.getMessage(), Toast.LENGTH_LONG).show();
                                        }
                                    }
                                    intentosConexion[0] = true;
                                    btPrintService.connect(device);
                                    break;
                                }
                                if (vistaActual != null) {
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
                    if (vistaActual != null) {
                        if (reintentosOcultos >= 3 && !desconexionManual) {
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
    private Context context;

    public Recibos() {
    }

    public Recibos(Context context) {
        this.context = context;
    }

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

        //Zebra Termica 3"
        result.put(55, new TamanioLetra(0, 48, 24));
        result.put(56, new TamanioLetra(1, 48, 48));


        return Collections.unmodifiableMap(result);
    }

    private static void setTamanioDefault(int partTipoPapel) {
        switch (partTipoPapel) {
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
            case TipoPapel.SPEEDDATA_TT35:
                tamanioDefault = new TamanioLetra(6, 32, 20);
                break;
            case TipoPapel.SEWOO:
                tamanioDefault = new TamanioLetra(0, 32, 0);
                break;
            case TipoPapel.ZEBRA_TERMICA3:
                tamanioDefault = new TamanioLetra(0, 48, 24);
                break;
        }
    }

    private static String generarArchivoRecibo(Map<String, String> datosTicket, String directorioArchivo, Recibo recibo, ConfiguracionRecibo configuracionRecibo, boolean imprimeLogo, String[] byRefMsgError) throws Exception {
        String nombreArchivo = "";

        try {
            nombreArchivo = "Recibos" + Short.toString(recibo.TipoPapel);
            File archivoRecibo = new File(directorioArchivo, nombreArchivo);
            if (!archivoRecibo.exists()) {
                if (!archivoRecibo.createNewFile()) {
                    //TODO Paula, cambiar mensaje
                    byRefMsgError[0] = "El archivo no se pudo crear";
                    return "";
                }
            }

            //Valores default
            int columnasRecibo = 48;
            StringBuilder cadenaRecibo = new StringBuilder();

            if (imprimeLogo) {
                cadenaRecibo.append("IMPRIME_LOGO\r\n");
            }

            if (Short.parseShort(datosTicket.get("Tipo")) == 8 && Short.parseShort(datosTicket.get("TipoRecibo")) == 24) {
                if (Short.parseShort(datosTicket.get("TipoFase")) == 0) {
                    cadenaRecibo.append("\r\n");
                    cadenaRecibo.append(textoCentradoConSimbolo(Mensajes.get("XCancelada"), '*', columnasRecibo) + "\r\n");
                }
            }

            String campoLlave = "";
            if (Short.parseShort(datosTicket.get("TipoRecibo")) == 10) {
                campoLlave = "ABNId";
            } else if (Short.parseShort(datosTicket.get("TipoRecibo")) == 13) {
                campoLlave = "PLIId";
            } else {
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

        } catch (Exception ex) {
            //TODO Paula, cambiar mensaje
            throw new Exception("Error al generar ticket:" + ex.getMessage());
        }

        return nombreArchivo;
    }

    private static String generarArchivoRecibo(Map<String, String> datosTicket, String directorioArchivo, Recibo recibo, boolean imprimeLogo, boolean aplicaDevolucion, String[] byRefMsgError) throws Exception {
        String nombreArchivo = "";

        try {
            nombreArchivo = "Recibos" + Short.toString(recibo.TipoPapel);
            File archivoRecibo = new File(directorioArchivo, nombreArchivo);
            if (!archivoRecibo.exists()) {
                if (!archivoRecibo.createNewFile()) {
                    //TODO Paula, cambiar mensaje
                    byRefMsgError[0] = "El archivo no se pudo crear";
                    return "";
                }
            }

            //Valores default
            int columnasRecibo = 48;
            StringBuilder cadenaRecibo = new StringBuilder();

            if (imprimeLogo) {
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
            if (Short.parseShort(datosTicket.get("TipoRecibo")) == 10) {
                campoLlave = "ABNId";
            } else if (Short.parseShort(datosTicket.get("TipoRecibo")) == 13) {
                campoLlave = "PLIId";
            } else {
                campoLlave = "TransProdID";
            }

            if (datosTicket.get("TipoRecibo").equals(TRECIBO.DEPOSITOS_MANUALES)) {
                imprimirDepositosManuales(recibo, cadenaRecibo, aplicaDevolucion);
            }else if(datosTicket.get("TipoRecibo").equals(TRECIBO.TOMA_DE_INVENTARIO)) {
                imprimirTomaInventario(recibo, datosTicket.get("_Id"), cadenaRecibo);
            }else
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

        } catch (Exception ex) {
            //TODO Paula, cambiar mensaje
            throw new Exception("Error al generar ticket:" + ex.getMessage());
        }

        return nombreArchivo;
    }

    private static String generarArchivoRecibo(Map<String, String> datosTicket, String directorioArchivo, Recibo recibo, boolean imprimeLogo, int ticketConfigurado, String[] byRefMsgError, boolean reimpresion) throws Exception {
        String nombreArchivo = "";

        try {
            nombreArchivo = "Recibos" + Short.toString(recibo.TipoPapel);
            File archivoRecibo = new File(directorioArchivo, nombreArchivo);
            if (!archivoRecibo.exists()) {
                if (!archivoRecibo.createNewFile()) {
                    //TODO Paula, cambiar mensaje
                    byRefMsgError[0] = "El archivo no se pudo crear";
                    return "";
                }
			}

            //Valores default
            //int columnasRecibo  = 48;
            StringBuilder cadenaRecibo = new StringBuilder();

            if (imprimeLogo) {
                cadenaRecibo.append("IMPRIME_LOGO\r\n");
            }

            switch (ticketConfigurado) {
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

        } catch (Exception ex) {
            //TODO Paula, cambiar mensaje
            throw new Exception("Error al generar ticket:" + ex.getMessage());
        }

        return nombreArchivo;
    }

    private static void imprimirTomaInventario(Recibo recibo, String inventarioID, StringBuilder cadenaRecibo) throws Exception {

        String cadena = "";

        TamanioLetra tamanioLetra;
        tamanioLetra = tamanioDefault;

        int col1 = 0;
        int col2 = 0;
        int col3 = 0;
        switch (recibo.TipoPapel) {
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
            case TipoPapel.EXTECH_TERMICA2:
                col1 = 8;
                col2 = 18;
                col3 = 6;
                tamanioDefault.mLongTotal = 30;
                tamanioLetra.mLongTotal = 30;
                break;
            default:
                col1 = 10;
                col2 = 20;
                col3 = 10;
                tamanioDefault.mLongTotal = 30;
                tamanioLetra.mLongTotal = 30;
                break;
        }
        crearEncabezado(recibo, cadenaRecibo, tamanioLetra);

        cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, Mensajes.get("XTomaInventario"), tamanioLetra.mLongTotal);
        cadenaRecibo.append(cadena + "\r\n");

        cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, Mensajes.get("XImpresion") + ": " + Generales.getFechaHoraActualStr("dd/MM/yyyy hh:mm:ss"), tamanioLetra.mLongTotal);
        cadenaRecibo.append(cadena + "\r\n");
        cadenaRecibo.append("\r\n");

        cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, Mensajes.get("XCliente") + ": " + oClienteAct.Clave + "-" + oClienteAct.RazonSocial, tamanioLetra.mLongTotal);
        cadenaRecibo.append(cadena + "\r\n");

        imprimeLineaPunteada(cadenaRecibo, tamanioLetra.mLongTotal);

        cadena = completaHasta(Mensajes.get("XProducto"), col1 + col2, TipoAlineacion.IZQUIERDA, false);
        cadena += completaHasta(Mensajes.get("XInventario"), col3, TipoAlineacion.DERECHA, true);
        cadenaRecibo.append(cadena + "\r\n");

        imprimeLineaPunteada(cadenaRecibo, tamanioLetra.mLongTotal);

        ISetDatos invMercDet = Consultas.ConsultasInventarioMercadeo.obtenerDetalle(inventarioID);

        int cont = 1;
        while (invMercDet.moveToNext()) {
            cadena = completaHasta(invMercDet.getString("ProductoClave") + " - " + invMercDet.getString("Descripcion"), col1 + col2, TipoAlineacion.IZQUIERDA, false);
            cadena += completaHasta(Generales.getFormatoDecimal(invMercDet.getFloat("Inventario"), "#,##0.##"), col3, TipoAlineacion.DERECHA, true);
            cadenaRecibo.append(cadena + "\r\n");
            cont++;
        }

        invMercDet.close();

        cadenaRecibo.append("\r\n");
        cadenaRecibo.append("\r\n");
        cadenaRecibo.append("\r\n");
        cadenaRecibo.append("\r\n");
        cadenaRecibo.append("\r\n");
    }

    private static void imprimirDepositosManuales(Recibo recibo, StringBuilder cadenaRecibo, boolean aplicaDevolucion) throws Exception {

        String cadena = "";

        TamanioLetra tamanioLetra;
        tamanioLetra = tamanioDefault;

        int col1 = 0;
        int col2 = 0;
        int col3 = 0;
        switch (recibo.TipoPapel) {
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
            case TipoPapel.EXTECH_TERMICA2:
                col1 = 8;
                col2 = 18;
                col3 = 6;
                tamanioDefault.mLongTotal = 30;
                tamanioLetra.mLongTotal = 30;
                break;
            default:
                col1 = 10;
                col2 = 20;
                col3 = 10;
                tamanioDefault.mLongTotal = 30;
                tamanioLetra.mLongTotal = 30;
                break;
        }
        crearEncabezado(recibo, cadenaRecibo, tamanioLetra);

        cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, Mensajes.get("XDepositos"), tamanioLetra.mLongTotal);
        cadenaRecibo.append(cadena + "\r\n");

        cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, Mensajes.get("XImpresion") + ": " + Generales.getFechaHoraActualStr("dd/MM/yyyy hh:mm:ss"), tamanioLetra.mLongTotal);
        cadenaRecibo.append(cadena + "\r\n");

        imprimeLineaPunteada(cadenaRecibo, tamanioLetra.mLongTotal);

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
        while (depositos.moveToNext()) {
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

    private static void imprimirPedidoCostena(Recibo recibo, StringBuilder cadenaRecibo, String TransProdID, boolean reimpresion, int tipo) throws Exception {

        TransProd trp = new TransProd();
        trp.TransProdID = TransProdID;
        BDVend.recuperar(trp);

        Cliente cli = new Cliente();
        cli.ClienteClave = trp.ClienteClave;
        BDVend.recuperar(cli);
        BDVend.recuperar(cli, ClienteDomicilio.class);

        if (trp.CadenaListasPrecios.length() <= 0) {
            com.amesol.routelite.datos.ModuloMovDetalle moduloMovDetalle;
            moduloMovDetalle = new com.amesol.routelite.datos.ModuloMovDetalle();
            moduloMovDetalle.ModuloMovDetalleClave = trp.PCEModuloMovDetClave;
            BDVend.recuperar(moduloMovDetalle);
            HashMap<Integer, Precio> listasPrecios = ListaPrecio.Determinar(trp.ClienteClave, moduloMovDetalle);
            trp.setListaPrecios(listasPrecios);
        }
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

        if (((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.ZEBRA_TERMICA2 || ((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.ZEBRA_CAMEO2) {
            cadena = "{" + tamanioLetra.mTamanio + " " + tamanioLetra.mAlto + "}";
        } else if (((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.INTERMEC_PR2 || ((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.INTERMEC_PR3) {
            //Se usa el mAlto para indentificar si la letra es normal o doble 0= normal 1= doble
            //En la cadena de los bytes no se debe dejar espacios, si no falla y se consideran hasta el momento
            //3 bytes en el mensaje, por lo que si se mete menos o mas, hay que cambiar el codigo en BluetoothPrint
            if (tamanioLetra.mAlto != 0) {
                cadena = "{27,33," + tamanioLetra.mTamanio + "}";
            } else {
                cadena = "{27,119," + tamanioLetra.mTamanio + "}";
            }
        } else if( ((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.ZEBRA_TERMICA3 ) {
            cadena = "! U1 SETLP 7 " + tamanioLetra.mTamanio + " " + tamanioLetra.mAlto + " ";
        } else {
            cadena = "{" + tamanioLetra.mTamanio + "}";
        }

        cadenaRecibo.append(cadena);

        crearEncabezadoSimple(recibo, cadenaRecibo, tamanioLetra);

        cadena = "";

        cadena = cadena + Mensajes.get("XRuta") + ": " + ruta.RUTClave;
        cadenaRecibo.append(cadena + "\r\n");

        if (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.PREVENTA || tipo == 21) {
            cadena = Mensajes.get("XPedido") + ": " + trp.Folio;
        } else {
            cadena = "# " + Mensajes.get("XNotaDeVenta") + ": " + trp.Folio;
        }
        cadenaRecibo.append(cadena + "\r\n");

        cadena = Mensajes.get("XFecha") + ": " + Generales.getFormatoFecha(trp.FechaHoraAlta, "dd/MM/yyyy");
        cadenaRecibo.append(cadena + "\r\n");

        cadena = Mensajes.get("XHora") + ": " + Generales.getFormatoFecha(trp.FechaHoraAlta, "hh:mm");
        cadenaRecibo.append(cadena + "\r\n");

        if (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.PREVENTA || tipo == 21) {
            cadena = Mensajes.get("XFechaEntrega") + ": " + Generales.getFormatoFecha(trp.FechaEntrega, "dd/MM/yyyy");
            cadenaRecibo.append(cadena + "\r\n");
        }
        cadenaRecibo.append("\r\n");

        if (reimpresion) {
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
        if (cli.ClienteDomicilio.size() > 0) {
            ClienteDomicilio cld = cli.ClienteDomicilio.get(0);
            cadena += cld.Calle + " #" + cld.Numero + " " + Mensajes.get("XCol") + " " + cld.Colonia;
        }
        cadenaRecibo.append(cadena + "\r\n");
        cadenaRecibo.append("\r\n");

        if (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.PREVENTA || tipo == 21) {
            cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, Mensajes.get("XPedido").toUpperCase(), tamanioLetra.mLongTotal);
        } else {
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
        while (detalles.moveToNext()) {
            cadena = completaHasta(String.valueOf(iPartida), col11, TipoAlineacion.IZQUIERDA, false);
            cadena += completaHasta(detalles.getString("ProductoClave"), col12, TipoAlineacion.IZQUIERDA, false);
            //cadena += completaHasta(detalles.getString("Descripcion"), col13, TipoAlineacion.IZQUIERDA, ( iTipoPapel != TipoPapel.INTERMEC_PR2));
            cadena += completaHasta(detalles.getString("Descripcion"), col13, TipoAlineacion.IZQUIERDA, true);
            cadenaRecibo.append(cadena + "\r\n");

            //cadena = completaHasta("   "+ValoresReferencia.getDescripcion("UNIDADV", detalles.getString("TipoUnidad")), col21, TipoAlineacion.IZQUIERDA, false);
            cadena = completaHasta((iTipoPapel != TipoPapel.INTERMEC_PR2 ? "   " : " ") + ValoresReferencia.getDescripcion("UNIDADV", detalles.getString("TipoUnidad")), col21, TipoAlineacion.IZQUIERDA, false);
            cadena += completaHasta(detalles.getString("Cantidad"), col22, TipoAlineacion.IZQUIERDA, false);
            cadena += completaHasta(Generales.getFormatoDecimal(detalles.getDouble("Precio"), 2), col23, TipoAlineacion.DERECHA, (iTipoPapel != TipoPapel.INTERMEC_PR2));
            cadena += completaHasta(Generales.getFormatoDecimal(ListaPrecio.obtenerPrecioSugerido(trp.CadenaListasPrecios, detalles.getString("ProductoClave"), detalles.getInt("TipoUnidad")), 2), col24, TipoAlineacion.DERECHA, true);
            //cadena += completaHasta("   ", col24, TipoAlineacion.DERECHA, true);
            cadena += completaHasta(Generales.getFormatoDecimal(detalles.getDouble("Importe"), 2), col25, TipoAlineacion.DERECHA, (iTipoPapel != TipoPapel.INTERMEC_PR2));
            cadena += " " + detalles.getString("Impuesto");
            cadenaRecibo.append(cadena + "\r\n");

            if (detalles.getInt("TipoUnidad") == 1 || detalles.getInt("TipoUnidad") == 2) {
                paquetes += detalles.getFloat("Cantidad");
            } else if (detalles.getInt("TipoUnidad") == 3) {
                cajas += detalles.getFloat("Cantidad");
            }
            articulos += detalles.getFloat("Cantidad");
            iPartida += 1;
        }
        detalles.close();

        //***************************

        imprimeLineaPunteada(cadenaRecibo, tamanioLetra.mLongTotal);
        cadenaRecibo.append("\r\n");

        if (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.PREVENTA || tipo == 21) {
            cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, Mensajes.get("XLeyendaPedidoCostena1"), tamanioLetra.mLongTotal);
            cadenaRecibo.append(cadena + "\r\n");
            cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, Mensajes.get("XLeyendaPedidoCostena2"), tamanioLetra.mLongTotal);
            cadenaRecibo.append(cadena + "\r\n");
            cadenaRecibo.append("\r\n");
        } else {
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
        for (String renglon : importeLetra) {
            cadenaRecibo.append(alineaTexto(BTIPALI.TipoAlineacion.CENTRO, renglon, tamanioLetra.mLongTotal) + "\r\n");
        }

        if (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.PREVENTA || tipo == 21) {
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
            for (String renglon : leyenda) {
                cadenaRecibo.append(alineaTexto(BTIPALI.TipoAlineacion.IZQUIERDA, renglon, tamanioLetra.mLongTotal) + "\r\n");
            }
        }

        cadenaRecibo.append("\r\n");
        cadenaRecibo.append("\r\n");
        cadenaRecibo.append("\r\n");
        cadenaRecibo.append("\r\n");
        cadenaRecibo.append("\r\n");
    }

    private static ArrayList<String> ajustarDividirCadena(String cadena, int totalLong) {
        ArrayList<String> cadenasAjustadas = new ArrayList<String>();
        String[] cadenas = cadena.split(" ");
        String ajusta = "";
        for (int i = 0; i < cadenas.length; i++) {
            //ajusta = cadenas[i];
            if (ajusta.length() + cadenas[i].length() + 1 <= totalLong) {
                ajusta += cadenas[i] + " ";
                if (i == cadenas.length - 1)
                    cadenasAjustadas.add(ajusta);
            } else {
                cadenasAjustadas.add(ajusta);
                ajusta = "";
                ajusta = cadenas[i] + " ";
                if (i == cadenas.length - 1)
                    cadenasAjustadas.add(ajusta);
            }
		}
        return cadenasAjustadas;
    }

    private static String textoCentradoConSimbolo(String texto, char simbolo, int longTotal) {
        String resultado = "";

        int i = 1;
        while (i < longTotal) {
            if (i == Math.round(longTotal / 2) - Math.round((texto.length() + 2) / 2)) {
                resultado = resultado.concat(" " + texto + " ");
            } else {
                resultado = resultado.concat(String.valueOf(simbolo));
            }
        }
        return resultado;
    }

    private static void crearEncabezado(Recibo recibo, StringBuilder cadenaRecibo) throws Exception {
        //metodo general para crear el encabezado de los tickets amarrados
        ISetDatos encabezado = ConsultasImpresionTicket.obtenerEncabezado();

        TamanioLetra tamanioLetra;
        setTamanioDefault(recibo.TipoPapel);
        tamanioLetra = tamanioDefault;

        while (encabezado.moveToNext()) {
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

    private static void crearEncabezado(Recibo recibo, StringBuilder cadenaRecibo, TamanioLetra tamanioLetra) throws Exception {
        //metodo general para crear el encabezado de los tickets amarrados
        ISetDatos encabezado = ConsultasImpresionTicket.obtenerEncabezado();

        // TamanioLetra tamanioLetra;
        setTamanioDefault(recibo.TipoPapel);
        // tamanioLetra = tamanioDefault;

        while (encabezado.moveToNext()) {
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

    private static void crearEncabezadoSimple(Recibo recibo, StringBuilder cadenaRecibo, TamanioLetra tamanioLetra) throws Exception {
        //metodo general para crear el encabezado de los tickets amarrados
        ISetDatos encabezado = ConsultasImpresionTicket.obtenerEncabezado();

		/*
         * TamanioLetra tamanioLetra; setTamanioDefault(recibo.TipoPapel);
		 * tamanioLetra = tamanioDefault;
		 */

        while (encabezado.moveToNext()) {
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

    private static void crearEncabezadoPie(Recibo recibo, short modoEncabezadoPie, Map<String, String> datosTicket, StringBuilder cadenaRecibo, boolean soloSubEmpresa) throws Exception {
        try {

            ISetDatos sdRECEncabezadoPie = ConsultasImpresionTicket.obtenerRECEncabezadoPiePorRECId(recibo.RECId, modoEncabezadoPie);
            cadenaRecibo.append("\r\n");

            TamanioLetra tamanioLetra;
            boolean cambiarLetra = false;
            int tipoFormato = 0;
            String cadena = "";

            if (modoEncabezadoPie == ModoEncabezadoPie.ENCABEZADO) {
                setTamanioDefault(recibo.TipoPapel);
                tamanioLetra = tamanioDefault;
                mTamanioActual = tamanioLetra;
                if (recibo.TipoPapel == TipoPapel.ZEBRA_TERMICA2 || recibo.TipoPapel == TipoPapel.ZEBRA_CAMEO2) {
                    cadena = "{" + tamanioLetra.mTamanio + " " + tamanioLetra.mAlto + "}" + cadena;
                } else if (recibo.TipoPapel == TipoPapel.INTERMEC_PR2 || recibo.TipoPapel == TipoPapel.INTERMEC_PR3) {
                    //Se usa el mAlto para indentificar si la letra es normal o doble 0= normal 1= doble
                    //En la cadena de los bytes no se debe dejar espacios, si no falla y se consideran hasta el momento
                    //3 bytes en el mensaje, por lo que si se mete menos o mas, hay que cambiar el codigo en BluetoothPrint
                    if (tamanioLetra.mAlto != 0) {
                        cadena = "{27,33," + tamanioLetra.mTamanio + "}" + cadena;
                    } else {
                        cadena = "{27,119," + tamanioLetra.mTamanio + "}" + cadena;
                    }
                }  else if( recibo.TipoPapel == TipoPapel.ZEBRA_TERMICA3 ) {
                    cadena = "! U1 SETLP 7 " + tamanioLetra.mTamanio + " " + tamanioLetra.mAlto + " " + cadena;
                }
                else {
                    cadena = "{" + tamanioLetra.mTamanio + "}" + cadena;
                }
                cadenaRecibo.append(cadena + "\r\n");
            }

            if (recibo.AgruparPorSubem && !soloSubEmpresa && modoEncabezadoPie == ModoEncabezadoPie.ENCABEZADO) {
                obtieneNotas(recibo, cadenaRecibo, modoEncabezadoPie);
            }

            while (sdRECEncabezadoPie.moveToNext()) {
                tamanioLetra = TAMANIOS_LETRA.get(sdRECEncabezadoPie.getInt(sdRECEncabezadoPie.getColumnIndex("TipoLetra")));
                cambiarLetra = (tamanioLetra.mTamanio != mTamanioActual.mTamanio);
                mTamanioActual = tamanioLetra;
                ContentValues mapRECEncabezadoPie = new ContentValues();
                DatabaseUtils.cursorRowToContentValues((Cursor) sdRECEncabezadoPie.getOriginal(), mapRECEncabezadoPie);
                tipoFormato = mapRECEncabezadoPie.getAsShort("TipoFormato");
                cadena = obtieneCadena(mapRECEncabezadoPie, datosTicket, soloSubEmpresa);
                if (!cadena.equals("")) {
                    cadena = alineaTexto(mapRECEncabezadoPie.getAsShort("TipoAlineacion"), cadena, tamanioLetra.mLongTotal);
                    if (cambiarLetra || recibo.TipoPapel == TipoPapel.EXTECH_IMPACTO2 || recibo.TipoPapel == TipoPapel.INTERMEC_PR2 || recibo.TipoPapel == TipoPapel.INTERMEC_PR3) {
                        if (recibo.TipoPapel == TipoPapel.ZEBRA_TERMICA2 || recibo.TipoPapel == TipoPapel.ZEBRA_CAMEO2) {
                            cadena = "{" + tamanioLetra.mTamanio + " " + tamanioLetra.mAlto + "}" + cadena;
                        } else if (recibo.TipoPapel == TipoPapel.INTERMEC_PR2 || recibo.TipoPapel == TipoPapel.INTERMEC_PR3) {
                            //Se usa el mAlto para indentificar si la letra es normal o doble 0= normal 1= doble
                            //En la cadena de los bytes no se debe dejar espacios, si no falla y se consideran hasta el momento
                            //3 bytes en el mensaje, por lo que si se mete menos o mas, hay que cambiar el codigo en BluetoothPrint
                            if (tamanioLetra.mAlto != 0) {
                                cadena = "{27,33," + tamanioLetra.mTamanio + "}" + cadena;
                            } else {
                                cadena = "{27,119," + tamanioLetra.mTamanio + "}" + cadena;
                            }
                        } else if( recibo.TipoPapel == TipoPapel.ZEBRA_TERMICA3 ) {
                            cadena = "! U1 SETLP 7 " + tamanioLetra.mTamanio + " " + tamanioLetra.mAlto + " " + cadena;
                        } else {
                            cadena = "{" + tamanioLetra.mTamanio + "}" + cadena;
                        }
                    }
                    cadenaRecibo.append(cadena + "\r\n");
                    //TODO falta toma de cadenas si el recibo es de facturacion
                }
            }

            sdRECEncabezadoPie.close();
            cadenaRecibo.append("\r\n");

            if (modoEncabezadoPie == ModoEncabezadoPie.PIE) {
                //TODO Paula, CrearEquivalencias......

            }

            if (!recibo.AgruparPorSubem && !soloSubEmpresa) {
                obtieneNotas(recibo, cadenaRecibo, modoEncabezadoPie);
            }

            if (modoEncabezadoPie == ModoEncabezadoPie.PIE) {
                for (int i = 0; i <= 8; i++) {
                    cadenaRecibo.append("\r\n");
                }
            }

        } catch (Exception ex) {
            throw new Exception("CrearEncabezadoPie:" + ex.getMessage());
        }
    }

    private static void crearGenerales(Recibo oRecibo, Map<String, String> datosTicket, StringBuilder cadenaRecibo, String campoLlave) throws Exception {
        int yActual = -1;
        int xMax = Integer.parseInt(ConsultasImpresionTicket.obtenerMaxOrdenXRECContenido(oRecibo.RECId));
        ;

        String cadena = "";

        ISetDatos sdRECContenido = ConsultasImpresionTicket.obtenerRECContenidoPorRECId(oRecibo.RECId);
        boolean cambiarLetra = false;
        TamanioLetra tamanioLetra = tamanioDefault;
        int anchoColumna = 0;
        String cadenaGenerales;
        while (sdRECContenido.moveToNext()) {

            if (yActual != sdRECContenido.getInt(sdRECContenido.getColumnIndex("OrdenY"))) {
                if (yActual != -1) {
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
            if (cambiarLetra || oRecibo.TipoPapel == TipoPapel.EXTECH_IMPACTO2 || oRecibo.TipoPapel == TipoPapel.INTERMEC_PR2 || oRecibo.TipoPapel == TipoPapel.INTERMEC_PR3) {
                if (oRecibo.TipoPapel == TipoPapel.ZEBRA_TERMICA2 || oRecibo.TipoPapel == TipoPapel.ZEBRA_CAMEO2) {
                    cadena = "{" + tamanioLetra.mTamanio + " " + tamanioLetra.mAlto + "}" + cadena;
                } else if (oRecibo.TipoPapel == TipoPapel.INTERMEC_PR2 || oRecibo.TipoPapel == TipoPapel.INTERMEC_PR3) {
                    //Se usa el mAlto para indentificar si la letra es normal o doble 0= normal 1= doble
                    //En la cadena de los bytes no se debe dejar espacios, si no falla y se consideran hasta el momento
                    //3 bytes en el mensaje, por lo que si se mete menos o mas, hay que cambiar el codigo en BluetoothPrint
                    if (tamanioLetra.mAlto != 0) {
                        cadena = "{27,33," + tamanioLetra.mTamanio + "}" + cadena;
                    } else {
                        cadena = "{27,119," + tamanioLetra.mTamanio + "}" + cadena;
                    }
                } else if( oRecibo.TipoPapel == TipoPapel.ZEBRA_TERMICA3 ) {
                    cadena = "! U1 SETLP 7 " + tamanioLetra.mTamanio + " " + tamanioLetra.mAlto + " " + cadena;
                }  else {
                    cadena = "{" + tamanioLetra.mTamanio + "}" + cadena;
                }
            }
            cadena = cadena.concat(cadenaGenerales);
        }

        sdRECContenido.close();
        if (yActual != -1) {
            cadenaRecibo.append(cadena + "\r\n");
        }

        cadenaRecibo.append("\r\n");
    }

    private static void crearDetalle(Recibo recibo, Map<String, String> datosTicket, StringBuilder cadenaRecibo, String campoLlave) throws Exception {
        if(recibo.SeccionProdPromo){
            seccionProdPromo(recibo, datosTicket, campoLlave, cadenaRecibo);
        }

        if (Short.parseShort(datosTicket.get("TipoRecibo")) != 13 && !recibo.AgruparPorSubem) {
            Boolean[] byRefImprimirEtiquetas = new Boolean[1];
            byRefImprimirEtiquetas[0] = new Boolean(false);
            if (!obtieneTitulos(recibo, cadenaRecibo, datosTicket, byRefImprimirEtiquetas)) {
                return;
            }
            if (byRefImprimirEtiquetas[0]) {
                imprimeLineaPunteada(cadenaRecibo, mTamanioActual.mLongTotal);
            }
        }

        int tipoImpuesto = 0;
        if (oClienteAct != null) {
            tipoImpuesto = oClienteAct.TipoImpuesto;
        }

        obtieneDetalles(recibo, datosTicket, campoLlave, cadenaRecibo);

        if (Short.parseShort(datosTicket.get("Tipo")) == 1 && recibo.AgruparPorPrecio) {
            imprimeLineaPunteada(cadenaRecibo, mTamanioActual.mLongTotal);
            cadenaRecibo.append(Mensajes.get("XTotalPrecio"));
            ISetDatos sdUnidadPrecioCantidad = ConsultasImpresionTicket.obtenerUnidadPrecioCantidad(datosTicket.get("_Id"));
            while (sdUnidadPrecioCantidad.moveToNext()) {
                String cad = completaHasta(ValoresReferencia.getDescripcion("UNIDADV", sdUnidadPrecioCantidad.getString(sdUnidadPrecioCantidad.getColumnIndex("TipoUnidad"))), 22, TipoAlineacion.IZQUIERDA, false);
                cad = cad.concat(completaHasta(Generales.getFormatoDecimal(sdUnidadPrecioCantidad.getDouble(sdUnidadPrecioCantidad.getColumnIndex("Precio")), "0.00"), 11, TipoAlineacion.DERECHA, false));
                cad = cad.concat(" = " + completaHasta(Generales.getFormatoDecimal(sdUnidadPrecioCantidad.getDouble(sdUnidadPrecioCantidad.getColumnIndex("CantidadProducto")), "0.##"), 5, TipoAlineacion.DERECHA, true));
            }
            sdUnidadPrecioCantidad.close();
        }
	}

    private static void seccionProdPromo(Recibo recibo, Map<String, String> datosTicket, String campoLlave, StringBuilder cadenaRecibo){
        ISetDatos prodPromo = ConsultasImpresionTicket.obtenerProductosPromo(datosTicket.get("_Id"));
        if(prodPromo.getCount() > 0){
            //se usan dos columnas grandes para la clave del producto y nombre
            //y tres pequeñas para unidad, cant y precio
            int columna = ( mTamanioActual.mLongTotal - ((mTamanioActual.mLongTotal/6) * 3))/2; //columnas grandes
            int columna6 = mTamanioActual.mLongTotal/6; //columnas pequeñas
            //titulos
            cadenaRecibo.append(completaHasta(Mensajes.get("XSecPromo"), mTamanioActual.mLongTotal, TipoAlineacion.IZQUIERDA,true));
            cadenaRecibo.append("\r\n");
            cadenaRecibo.append("\r\n");
            cadenaRecibo.append(completaHasta(Mensajes.get("XProducto"), columna, TipoAlineacion.IZQUIERDA, false));
            cadenaRecibo.append(completaHasta(Mensajes.get("XNombreCorto"), columna, TipoAlineacion.IZQUIERDA, false));
            cadenaRecibo.append(completaHasta(Mensajes.get("XUnidad"), columna6, TipoAlineacion.IZQUIERDA, false));
            cadenaRecibo.append(completaHasta(Mensajes.get("XCant."), columna6, TipoAlineacion.DERECHA, false));
            cadenaRecibo.append(completaHasta(Mensajes.get("XPrecio"), columna6, TipoAlineacion.DERECHA, true));
            cadenaRecibo.append("\r\n");
            imprimeLineaPunteada(cadenaRecibo, mTamanioActual.mLongTotal);

            while(prodPromo.moveToNext()){
                cadenaRecibo.append(completaHasta(prodPromo.getString("ProductoClave"), columna, TipoAlineacion.IZQUIERDA, false));
                cadenaRecibo.append(completaHasta(prodPromo.getString("Nombre"), columna, TipoAlineacion.IZQUIERDA, false));
                cadenaRecibo.append(completaHasta(ValoresReferencia.getDescripcion("UNIDADV",prodPromo.getString("TipoUnidad")), columna6, TipoAlineacion.IZQUIERDA, false));
                cadenaRecibo.append(completaHasta(prodPromo.getString("Cantidad"), columna6, TipoAlineacion.DERECHA, false));
                cadenaRecibo.append(completaHasta("0", columna6, TipoAlineacion.DERECHA, true));
                cadenaRecibo.append("\r\n");
            }
            imprimeLineaPunteada(cadenaRecibo, mTamanioActual.mLongTotal);
            cadenaRecibo.append("\r\n");
        }
    }

	/*
	 * private static String generarArchivoRecibo(Map<String,String>
	 * datosTicket, String directorioArchivo, Recibo recibo, boolean
	 * imprimeLogo, String[] byRefMsgError) throws Exception{ return
	 * generarArchivoRecibo(datosTicket, directorioArchivo, recibo, imprimeLogo,
	 * false, byRefMsgError); }
	 */

    private static void obtieneDetalles(Recibo recibo, Map<String, String> datosTicket, String campoLlave, StringBuilder cadenaRecibo) throws Exception {
		try
		{
            ISetDatos sdREODetalle = ConsultasImpresionTicket.obtenerREODetallePorRECId(recibo.RECId);

            COTCampo oCOTCampoOrden = null;
            if (recibo.CORId != null && recibo.COTId != null && recibo.COCId != null) {
                oCOTCampoOrden = new COTCampo();
                oCOTCampoOrden.CORId = recibo.CORId;
                oCOTCampoOrden.COTId = recibo.COTId;
                oCOTCampoOrden.COCId = recibo.COCId;
                BDTerm.recuperar(oCOTCampoOrden);
            }

            CORTabla oCORTablaOrden = null;
            if (recibo.COTId != null && recibo.CORId != null) {
                oCORTablaOrden = new CORTabla();
                oCORTablaOrden.COTId = recibo.COTId;
                oCORTablaOrden.CORId = recibo.CORId;
                BDTerm.recuperar(oCORTablaOrden);
            }

            Hashtable<String, ArrayList<Object>> htCampos = new Hashtable<String, ArrayList<Object>>();
            ArrayList<String> arrTablas = new ArrayList<String>();

            String nombresCampos = "";
            while (sdREODetalle.moveToNext()) {
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

                if (Integer.parseInt(datosTicket.get("Tipo")) == 13) {
                    if (oCOTCampo.Nombre.equalsIgnoreCase("FechaDeposito")) {
                        config.add(10);
                    } else if (oCOTCampo.Nombre.equalsIgnoreCase("TipoBanco")) {
                        config.add(9);
                    } else if (oCOTCampo.Nombre.equalsIgnoreCase("Referencia")) {
                        config.add(12);
                    } else if (oCOTCampo.Nombre.equalsIgnoreCase("Total")) {
                        config.add(7);
                    } else if (oCOTCampo.Nombre.equalsIgnoreCase("Ficha")) {
                        config.add(6);
                    } else if (oCOTCampo.Nombre.equalsIgnoreCase("TipoEfectivo")) {
                        config.add(20);
                    } else {
                        config.add(sdREODetalle.getInt(sdREODetalle.getColumnIndex("Tamanio")));
                    }
                } else {
                    config.add(sdREODetalle.getInt(sdREODetalle.getColumnIndex("Tamanio")));
                }
                config.add(sdREODetalle.getShort(sdREODetalle.getColumnIndex("CantidadEspacio")));
                config.add(sdREODetalle.getShort(sdREODetalle.getColumnIndex("TipoEspacio")));
                config.add(sdREODetalle.getShort(sdREODetalle.getColumnIndex("TipoFormato")));
                config.add(sdREODetalle.getInt(sdREODetalle.getColumnIndex("OrdenY")));
                if (!htCampos.contains(oCOTCampo.Nombre)) {
                    htCampos.put(oCOTCampo.Nombre, config);
                }
                if (!arrTablas.contains(oCORTabla.Nombre)) {
                    arrTablas.add(oCORTabla.Nombre);
                }
            }

            sdREODetalle.close();

            if (nombresCampos.length() > 0) {
                nombresCampos = nombresCampos.substring(0, nombresCampos.length() - 1);
            }

            String tablas = arrTablas.toString().replace("[", "");
            tablas = tablas.replace("]", "");

            if (Short.parseShort(datosTicket.get("TipoRecibo")) == 13) {
                //TODO Paula, Implementar el GuardaDetallesPreliquidacion cuando se necesite.
            }
			else
			{
                guardaDetalles(recibo, nombresCampos, datosTicket, tablas, campoLlave, (oCORTablaOrden != null ? oCORTablaOrden.Nombre : ""), (oCOTCampoOrden != null ? oCOTCampoOrden.Nombre : ""), cadenaRecibo, htCampos);
            }
        } catch (Exception ex) {
            throw new Exception("obtieneDetalles" + ex.getMessage());
        }
    }

    private static void guardaDetalles(Recibo recibo, String campos, Map<String, String> datosTicket, String tabla, String campoLlave, String tablaOrden, String campoOrden, StringBuilder cadenaRecibo, Hashtable<String, ArrayList<Object>> htCampos) throws Exception {
        boolean incluirSubEmpresa = false;
        boolean incluirClaveProducto = false;
        boolean incluirTRPId = false;
        boolean incluirTPDId = false;
        boolean incluirPrecio = false;
        boolean incluirDesImp = false;
        boolean incluirCant = false;

        if (recibo.AgruparPorSubem) {
            incluirSubEmpresa = campos.toUpperCase().contains("SUBEMPRESAID");
            campos = campos.concat(", Producto.SubEmpresaId ");
        }

        if (recibo.IncluirImpuestos || Short.parseShort(datosTicket.get("Tipo")) == 8) {
            incluirClaveProducto = campos.toUpperCase().contains("PRODUCTOCLAVE");
            if (!incluirClaveProducto)
                campos = campos.concat(", Producto.ProductoClave");

            if (Short.parseShort(datosTicket.get("Tipo")) == 8) {
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

        ISetDatos sdDetalleRecibo = ConsultasImpresionTicket.obtenerDetalleRecibo(datosTicket.get("_Id"), Short.parseShort(datosTicket.get("Tipo")), Short.parseShort(datosTicket.get("TipoRecibo")), tabla, campos, campoLlave, tablaOrden, campoOrden, recibo.AgruparPorSubem, recibo.SeccionProdPromo);

        String subEmpresaAct = "";
        int contador = 0;

        while (sdDetalleRecibo.moveToNext()) {
            if (recibo.AgruparPorSubem) {
                if (!subEmpresaAct.equalsIgnoreCase("SubEmpresaId")) {
                    cadenaRecibo.append("\r\n");
                    if (contador > 0) {
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
                    if (byRefImprimirEtiquetas[0]) {
                        imprimeLineaPunteada(cadenaRecibo, mTamanioActual.mLongTotal);
                    }
                }
                contador++;
            }

            int renglon = 0;
            String cadena = "";
            ArrayList<Object> config = new ArrayList<Object>();
            if (sdDetalleRecibo.getColumnCount() > 0) {
                config = htCampos.get(sdDetalleRecibo.getColumnName(0));
                renglon = Integer.parseInt(config.get(6).toString());
            }

            String tmpCadena = "";
            String nombreColumna = "";
            for (int i = 0; i < sdDetalleRecibo.getColumnCount(); i++) {
                nombreColumna = sdDetalleRecibo.getColumnName(i);
                if (nombreColumna.equalsIgnoreCase("SubEmpresaId") && !incluirSubEmpresa)
                    continue;
                if (nombreColumna.equalsIgnoreCase("ProductoClave") && recibo.IncluirImpuestos && !incluirClaveProducto)
                    continue;
                if (Short.parseShort(datosTicket.get("Tipo")) == 8) {
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

                if (campoLlave.equalsIgnoreCase("TransProdId") && nombreColumna.equalsIgnoreCase("TipoUnidad")) {
                    tmpCadena = ValoresReferencia.getDescripcion("UNIDADV", sdDetalleRecibo.getString(i));
                } else if (campoLlave.equalsIgnoreCase("ABNId") && nombreColumna.equalsIgnoreCase("TipoPago")) {
                    tmpCadena = ValoresReferencia.getDescripcion("PAGO", sdDetalleRecibo.getString(i));
                } else if (campoLlave.equalsIgnoreCase("ABNId") && nombreColumna.equalsIgnoreCase("TipoBanco")) {
                    tmpCadena = (sdDetalleRecibo.isNull(i) ? "" : ValoresReferencia.getDescripcion("TBANCO", sdDetalleRecibo.getString(i)));
                } else if (nombreColumna.equalsIgnoreCase("TipoMotivo")) {
                    tmpCadena = (sdDetalleRecibo.isNull(i) ? "" : ValoresReferencia.getDescripcion("TRPMOT", sdDetalleRecibo.getString(i)));
                } else if (nombreColumna.equalsIgnoreCase("Precio")) {
                    if (recibo.IncluirImpuestos) {
                        double preciosConImpuesto = Consultas.ConsultasTransProdDetalle.obtenerPrecioConImpuesto(datosTicket.get("_Id"), sdDetalleRecibo.getString("ProductoClave"));

                        tmpCadena = Generales.getFormatoDecimal(preciosConImpuesto,4);

                    } else if (Short.parseShort(datosTicket.get("Tipo")) == 8) {
                        //TODO: Paula, implementar cuando se incluya la factura
                    } else {
                        tmpCadena = sdDetalleRecibo.getString(i);
                    }
                } else if (Short.parseShort(datosTicket.get("Tipo")) == 8 && nombreColumna.equalsIgnoreCase("DescuentoImp")) {
                    //TODO: Paula, cuando se implemente la facturacion y los impuestos
                } else if (Short.parseShort(datosTicket.get("Tipo")) == 8 && nombreColumna.equalsIgnoreCase("SubTotal")) {
                    //TODO: Paula, cuando se implemente la facturacion y los impuestos
                } else {
                    if (sdDetalleRecibo.isNull(i)) {
                        tmpCadena = "";
                    } else {
                        tmpCadena = sdDetalleRecibo.getString(i).trim();
                    }
                }

                if (htCampos.containsKey(nombreColumna)) {
                    config = htCampos.get(nombreColumna);
                    tmpCadena = completaColumna(tmpCadena, Integer.parseInt(config.get(2).toString()), Integer.parseInt(config.get(0).toString()), Integer.parseInt(config.get(1).toString()), Integer.parseInt(config.get(5).toString()));
                    if (Integer.parseInt(config.get(3).toString()) > 0) {
                        tmpCadena = agregarEspaciosColumna(Integer.parseInt(config.get(4).toString()), tmpCadena, Integer.parseInt(config.get(3).toString()));
                    }

                    if (renglon != Integer.parseInt(config.get(6).toString())) {
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

    private static void imprimeLineaPunteada(StringBuilder cadenaRecibo, int longTotal) {
        char c = '-';
        char[] chars = new char[longTotal];
        Arrays.fill(chars, c);
        cadenaRecibo.append(String.valueOf(chars) + "\r\n");
    }

    private static void imprimeLineaContinua(StringBuilder cadenaRecibo, int longTotal) {
        char c = '_';
        char[] chars = new char[longTotal];
        Arrays.fill(chars, c);
        cadenaRecibo.append(String.valueOf(chars) + "\r\n");
    }

    private static boolean obtieneTitulos(Recibo recibo, StringBuilder cadenaRecibo, Map<String, String> datosTicket, Boolean[] byRefImprimioEtiquetas) throws Exception {
        return obtieneTitulos(recibo, cadenaRecibo, datosTicket, false, false, byRefImprimioEtiquetas);
    }

    private static boolean obtieneTitulos(Recibo recibo, StringBuilder cadenaRecibo, Map<String, String> datosTicket, boolean bPreliquidacion, boolean bDepositos, Boolean[] byRefImprimioEtiquetas) throws Exception {
        int yActual = -1;

        try {
            int xMax = ConsultasImpresionTicket.obtenerMaxOrdenXREODetalle(recibo.RECId);
            if (xMax <= 0) {
                return false;
            }

            ISetDatos sdREODetalle = ConsultasImpresionTicket.obtenerREODetallePorRECId(recibo.RECId);
            String cadena = "";
            boolean primerColumna = true;
            boolean cambiarLetra = false;
            TamanioLetra tamanioLetra = tamanioDefault;
            String cadenaDetallesT = "";
            while (sdREODetalle.moveToNext()) {
                if (yActual != sdREODetalle.getInt(sdREODetalle.getColumnIndex("OrdenY"))) {
                    if (yActual != -1) {
                        cadenaRecibo.append(cadena + "\r\n");
                    }
                    yActual = sdREODetalle.getInt(sdREODetalle.getColumnIndex("OrdenY"));
                    cadena = "";
                }
                if (primerColumna) {
                    tamanioLetra = TAMANIOS_LETRA.get(sdREODetalle.getInt(sdREODetalle.getColumnIndex("TipoLetra")));
                    cambiarLetra = (tamanioLetra.mTamanio != mTamanioActual.mTamanio);
                    mTamanioActual = tamanioLetra;
                    primerColumna = false;
                } else {
                    cambiarLetra = false;
                }
                ContentValues mapREODetalle = new ContentValues();
                DatabaseUtils.cursorRowToContentValues((Cursor) sdREODetalle.getOriginal(), mapREODetalle);
                cadenaDetallesT = obtieneCadenaDetallesT(datosTicket, mapREODetalle, bPreliquidacion, bDepositos, byRefImprimioEtiquetas);
                if (cambiarLetra || recibo.TipoPapel == TipoPapel.EXTECH_IMPACTO2) {
                    if (recibo.TipoPapel == TipoPapel.ZEBRA_TERMICA2 || recibo.TipoPapel == TipoPapel.ZEBRA_CAMEO2) {
                        cadenaDetallesT = "{" + tamanioLetra.mTamanio + " " + tamanioLetra.mAlto + "}" + cadenaDetallesT;
                    }  else if( recibo.TipoPapel == TipoPapel.ZEBRA_TERMICA3 ) {
                        cadena = "! U1 SETLP 7 " + tamanioLetra.mTamanio + " " + tamanioLetra.mAlto + " " + cadenaDetallesT;
                    } else {
                        cadenaDetallesT = "{" + tamanioLetra.mTamanio + "}" + cadenaDetallesT;
                    }
                }
                cadena = cadena.concat(cadenaDetallesT);
            }
            sdREODetalle.close();
            if (yActual != -1) {
                cadenaRecibo.append(cadena + "\r\n");
            }
        } catch (Exception ex) {
            throw new Exception(ex.getMessage());
            //MsgBox(ex.Message, MsgBoxStyle.Information, "ObtieneTitulos")
        }
        return true;
    }

    private static String obtieneCadenaDetallesT(Map<String, String> datosTicket, ContentValues mapREODetalle, boolean bPreliquidacion, boolean bDeposito, Boolean[] byRefImprimioEtiquetas) throws Exception {
        String cadena = "";
        boolean recuperar = true;
        if (mapREODetalle.getAsShort("TipoEtiqueta") == 1) {
            COTCampo oCOTCampo = new COTCampo();
            oCOTCampo.CORId = mapREODetalle.getAsString("CORId");
            oCOTCampo.COTId = mapREODetalle.getAsString("COTId");
            oCOTCampo.COCId = mapREODetalle.getAsString("COCId");
            BDTerm.recuperar(oCOTCampo);

            if (bPreliquidacion) {
                if (bDeposito) {
                    recuperar = (CAMPOS_PRELIQUIDACION_DEPOSITOS.contains(oCOTCampo.Nombre));
                } else {
                    recuperar = (CAMPOS_PRELIQUIDACION_NODEPOSITOS.contains(oCOTCampo.Nombre));
                }
            }
            if (recuperar) {
                int tamanio = 0;
                cadena = oCOTCampo.Descripcion;
                if (bPreliquidacion) {
                    if (oCOTCampo.Nombre.equalsIgnoreCase("FechaDeposito")) {
                        tamanio = 10;
                    } else if (oCOTCampo.Nombre.equalsIgnoreCase("TipoBanco")) {
                        tamanio = 9;
                    } else if (oCOTCampo.Nombre.equalsIgnoreCase("Referencia")) {
                        tamanio = 12;
                    } else if (oCOTCampo.Nombre.equalsIgnoreCase("Total")) {
                        tamanio = 7;
                    } else if (oCOTCampo.Nombre.equalsIgnoreCase("Ficha")) {
                        tamanio = 6;
                    } else if (oCOTCampo.Nombre.equalsIgnoreCase("TipoEfectivo")) {
                        tamanio = 19;
                    } else {
                        tamanio = mapREODetalle.getAsInteger("Tamanio");
                    }
                } else {
                    tamanio = mapREODetalle.getAsInteger("Tamanio");
                }
                cadena = completaColumna(cadena, tamanio);
                if (mapREODetalle.getAsShort("TipoSeparador") != 0) {
                    cadena = cadena.concat(ValoresReferencia.getDescripcion("SEPARADO", mapREODetalle.getAsString("TipoSeparador")));
                }
                cadena = agregarEspaciosColumna(mapREODetalle.getAsInteger("TipoEspacio"), cadena, mapREODetalle.getAsInteger("CantidadEspacio"));
            }
            byRefImprimioEtiquetas[0] = true;
        }
        return cadena;
    }

    private static String completaColumna(String texto, int anchoColumna, int alineacion, int separador, int tipoFormato) {
        String resCadena = texto;
        switch (tipoFormato) {
            case 1:
                resCadena = Generales.getFormatoDecimal(Double.parseDouble(resCadena), "#,##0");
                break;
            case 2:
                resCadena = Generales.getFormatoDecimal(Double.parseDouble(resCadena), "#,##0.00");
        }
        if (resCadena.length() > anchoColumna) {
            resCadena = resCadena.substring(0, anchoColumna);
        }
        int tamanioSeparador = 0;
        if (separador != 0) {
            tamanioSeparador = ValoresReferencia.getDescripcion("SEPARADO", Integer.toString(separador)).length();
        }

        if (alineacion == 0 || alineacion == 1) {
            int totalAncho = anchoColumna + tamanioSeparador;
            resCadena = String.format("%-" + totalAncho + "s", resCadena);
        } else if (alineacion == 2) {
            long tamanioIzquierdo = Math.round(Math.ceil(((anchoColumna + tamanioSeparador) - resCadena.length()) / 2));
            long tamanioDerecho = Math.round(Math.floor(((anchoColumna + tamanioSeparador) - resCadena.length()) / 2));
            long totalAncho = resCadena.length() + tamanioIzquierdo;
            resCadena = String.format("%-" + totalAncho + "s", resCadena);
            totalAncho = resCadena.length() + tamanioDerecho;
            resCadena = String.format("%" + totalAncho + "s", resCadena);
        } else if (alineacion == 3) {
            int totalAncho = anchoColumna + tamanioSeparador;
            resCadena = String.format("%" + totalAncho + "s", resCadena);
        }
        return resCadena;
    }

    private static String completaHasta(String texto, int espacios, short tipoAlineacion, boolean ultimaColumna) {
        String res = "";
        if (texto.length() >= espacios) {
            if (ultimaColumna) {
                return texto.substring(0, espacios);
            } else {
                return texto.substring(0, espacios - 1) + " ";
            }
        } else {
            if (tipoAlineacion == TipoAlineacion.IZQUIERDA) {
                return String.format("%-" + espacios + "s", texto);
                //return String.format("%" + (texto.length() + espacios) + "s", texto);
            } else if (tipoAlineacion == TipoAlineacion.DERECHA) {
                return String.format("%" + espacios + "s", texto);
                //return String.format("%-" + (texto.length() + espacios) + "s", texto);
            }
        }
        return res;
    }

    private static String agregarEspaciosColumna(int tipoEspacio, String texto, int cantidadEspacio) {
        if (cantidadEspacio > 0) {
            int longTotal = texto.length() + cantidadEspacio;
            switch (tipoEspacio) {
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

    private static String completaColumna(String texto, int anchoColumna) {
        int longTexto = texto.length();
        if (longTexto >= anchoColumna) {
            return texto.substring(0, anchoColumna);
        } else {

            return String.format("%-" + anchoColumna + "s", texto);
        }
    }

    private static String alineaTexto(short tipoAlineacion, String texto, int longTotal) {
        switch (tipoAlineacion) {
            case 2:
                return textoCentrado(texto, longTotal);
            case 3:
                return textoDerecha(texto, longTotal);
        }

        return texto;
    }

    private static String textoCentrado(String texto, int longTotal) {
        String espacios = "";
        int tamTexto = texto.length();

        for (int i = 1; i < Math.round((longTotal - tamTexto) / 2); i++) {
            espacios = espacios.concat(" ");
        }
        return espacios.concat(texto);
    }

    private static String textoDerecha(String texto, int longTotal) {
        String espacios = "";

        for (int i = 1; i < longTotal - texto.length(); i++) {
            espacios = espacios.concat(" ");
        }
        return espacios.concat(texto);
    }

    private static void obtieneNotas(Recibo recibo, StringBuilder cadenaRecibo, short modoEncabezadoPie) {

        ISetDatos sdRECNota = ConsultasImpresionTicket.obtenerRECNotaPorRECId(recibo.RECId, modoEncabezadoPie);
        String nota = "";
        TamanioLetra tamanioLetra = tamanioDefault;
        boolean cambiarLetra = false;
        while (sdRECNota.moveToNext()) {
            tamanioLetra = TAMANIOS_LETRA.get(sdRECNota.getInt(sdRECNota.getColumnIndex("TipoLetra")));
            cambiarLetra = (tamanioLetra.mTamanio != mTamanioActual.mTamanio);
            mTamanioActual = tamanioLetra;
            nota = alineaTexto(sdRECNota.getShort(sdRECNota.getColumnIndex("TipoAlineacion")), sdRECNota.getString(sdRECNota.getColumnIndex("Texto")), tamanioLetra.mLongTotal);
            if (cambiarLetra || recibo.TipoPapel == TipoPapel.EXTECH_IMPACTO2) {
                if (recibo.TipoPapel == TipoPapel.ZEBRA_CAMEO2 || recibo.TipoPapel == TipoPapel.ZEBRA_TERMICA2) {
                    //					nota = nota.concat("{" + tamanioLetra.mTamanio + " " + tamanioLetra.mAlto + "}" + nota + "\r\n");
                    nota = "{" + tamanioLetra.mTamanio + " " + tamanioLetra.mAlto + "}" + nota + "\r\n";
                }
                else if (recibo.TipoPapel == TipoPapel.INTERMEC_PR2 || recibo.TipoPapel == TipoPapel.INTERMEC_PR3)
                {
                    //Se usa el mAlto para indentificar si la letra es normal o doble 0= normal 1= doble
                    //En la cadena de los bytes no se debe dejar espacios, si no falla y se consideran hasta el momento
                    //3 bytes en el mensaje, por lo que si se mete menos o mas, hay que cambiar el codigo en BluetoothPrint
                    if (tamanioLetra.mAlto != 0)
                    {
                        nota = "{27,33," + tamanioLetra.mTamanio + "}" + nota;
                    }
                    else
                    {
                        nota = "{27,119," + tamanioLetra.mTamanio + "}" + nota;
                    }
                }   else if( recibo.TipoPapel == TipoPapel.ZEBRA_TERMICA3 ) {
                        nota = "! U1 SETLP 7 " + tamanioLetra.mTamanio + " " + tamanioLetra.mAlto + " " + nota;
                }
                else {
                    //					nota = nota.concat("{" + tamanioLetra.mTamanio + "}" + nota + "\r\n");
                    nota = "{" + tamanioLetra.mTamanio + "}" + nota + "\r\n";
                }
            }

            cadenaRecibo.append(nota + "\r\n");

            for (int i = 0; i < sdRECNota.getInt(sdRECNota.getColumnIndex("RenglonBlanco")); i++) {
                cadenaRecibo.append("\r\n");
            }
        }

        if (modoEncabezadoPie == ModoEncabezadoPie.ENCABEZADO) {
            cadenaRecibo.append(textoCentrado(Mensajes.get("Ximpresion") + ": " + Generales.getFechaHoraActualStr("dd/MM/yy HH:mm:ss"), tamanioLetra.mLongTotal) + "\r\n");
            cadenaRecibo.append("\r\n");
        }

        sdRECNota.close();
    }

    private static String obtieneCadena(ContentValues mapRECEncabezadoPie, Map<String, String> datosTicket, boolean soloSubempresa) throws Exception {
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

        if (mapRECEncabezadoPie.getAsShort("TipoEtiqueta") == 1) {
            cadena = cadena.concat(oCOTCampo.Descripcion);
            if (mapRECEncabezadoPie.getAsShort("TipoSeparador") != 0) {
                cadena = cadena.concat(ValoresReferencia.getDescripcion("SEPARADO", mapRECEncabezadoPie.getAsString("TipoSeparador")));
            }
        }

        String valorCampo = "";

        if (oCORTabla.Nombre.equalsIgnoreCase("Preliquidacion") && oCORTabla.Nombre.equalsIgnoreCase("Preliquidacion")) {
            if (datosTicket.containsKey("TotalPreliquidado")) {
                cadena = cadena.concat(Generales.getFormatoDecimal(Double.parseDouble(datosTicket.get("TotalPreliquidado")), "#,##0.00"));
            }
        } else if ((tipoRecibo == 24 || tipoRecibo == 8) && oCORTabla.Nombre.equalsIgnoreCase("TransProd") && oCOTCampo.Nombre.equalsIgnoreCase("Impuesto") && (oClienteAct != null && oClienteAct.DesgloseImpuesto)) {
            //TODO Pendiente Recibo Facturacion
        } else if ((tipoRecibo == 24 || tipoRecibo == 8) && oCORTabla.Nombre.equalsIgnoreCase("TransProd") && (oCOTCampo.Nombre.equalsIgnoreCase("DescuentoImp") || oCOTCampo.Nombre.equalsIgnoreCase("SubTDetalle")) && (oClienteAct != null && oClienteAct.DesgloseImpuesto)) {
            //TODO Pendiente Recibo Facturacion
        } else {
            if (oCORTabla.Nombre.equalsIgnoreCase("FolioFiscal") && tipoRecibo == 24) {
                //TODO Pendiente Recibo Facturacion
            } else if ((oCORTabla.Nombre.equalsIgnoreCase("TPDDes") || oCORTabla.Nombre.equalsIgnoreCase("TpdDesVendedor")) && oCOTCampo.Nombre.equalsIgnoreCase("desImorte") && tipoRecibo == 24) {
                //TODO Pendiente Recibo Facturacion
            } else if (oCORTabla.Nombre.equalsIgnoreCase("TransProd") && tipoRecibo == 26) {
                //TODO Pendiente Recibo Liquidacion de Consigna
            } else {
                String id = "";
                if (oCORTabla.Nombre.equalsIgnoreCase("Cliente") || oCORTabla.Nombre.equalsIgnoreCase("ClienteDomicilio")) {
                    id = datosTicket.get("ClienteClave");
                } else if (oCORTabla.Nombre.equalsIgnoreCase("SubEmpresa")) {
                    id = datosTicket.get("SubEmpresaID");
                } else {
                    id = datosTicket.get("_Id");
                }

                valorCampo = ConsultasImpresionTicket.obtenerValorCampo(id, oCOTCampo.Nombre, oCORTabla.Nombre, tipoRecibo, oCOTCampo.TipoCampo);
            }
        }
        if (mapRECEncabezadoPie.getAsShort("TipoFormato") == 1) {
            cadena = cadena.concat(Generales.getFormatoDecimal(Double.parseDouble(valorCampo), "#,##0"));
        } else if (mapRECEncabezadoPie.getAsShort("TipoFormato") == 2) {
            if (!valorCampo.isEmpty()) {
                cadena = cadena.concat(Generales.getFormatoDecimal(Double.parseDouble(valorCampo), "#,##0.00"));
            }
        } else {
            cadena = cadena.concat(valorCampo);
        }

        return cadena;

    }

    private static String obtieneCadenaGenerales(ContentValues mapRECContenido, Map<String, String> datosTicket, String campoLlave) throws Exception {
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

        if (mapRECContenido.getAsShort("TipoEtiqueta") == 1) {
            cadena = cadena.concat(oCOTCampo.Descripcion);
            if (mapRECContenido.getAsShort("TipoSeparador") != 0) {
                cadena = cadena.concat(ValoresReferencia.getDescripcion("SEPARADO", mapRECContenido.getAsString("TipoSeparador")));
            }
        }

        String valorCampo = "";
        if (campoLlave.equalsIgnoreCase("TransProdID") && oCOTCampo.Nombre.equalsIgnoreCase("DiasCredito") && Short.parseShort(datosTicket.get("Tipo")) == 8) {
            valorCampo = ConsultasImpresionTicket.obtenerDiasCredito(datosTicket.get("_Id"));
        } else {
            valorCampo = ConsultasImpresionTicket.obtenerValorCampo(datosTicket.get("_Id"), oCOTCampo.Nombre, oCORTabla.Nombre, tipoRecibo, oCOTCampo.TipoCampo);
        }

        if (campoLlave.equalsIgnoreCase("TransProdId")) {
            if (oCOTCampo.Nombre.equalsIgnoreCase("TipoMotivo")) {
                cadena = cadena.concat(ValoresReferencia.getDescripcion("TRPMOT", valorCampo));
            } else if (oCOTCampo.Nombre.equalsIgnoreCase("TipoFase")) {
                cadena = cadena.concat(ValoresReferencia.getDescripcion("TRPFASE", valorCampo));
            } else if (oCOTCampo.Nombre.equalsIgnoreCase("CFVTipo")) {
                cadena = cadena.concat(ValoresReferencia.getDescripcion("FVENTA", valorCampo));
            } else {
                cadena = cadena.concat(valorCampo);
            }
        } else {
            cadena = cadena.concat(valorCampo);
        }

        return cadena;
    }

    /*public static void imprimirReporte(int reporte, Boolean logoSoloPrimerRecibo, IVista vista) throws ControlError, Exception {
        imprimirReporte(reporte, null, logoSoloPrimerRecibo, vista);
    }*/

    public static void imprimirReporte(int reporte, Boolean logoSoloPrimerRecibo, IVista vista) throws ControlError, Exception {
        String nombreArchivo = "";
        Hashtable<String, ContentValues> archivosGenerados = new Hashtable<String, ContentValues>();

        ConfiguracionLocal conf = (ConfiguracionLocal) Sesion.get(Campo.ConfiguracionLocal);
        File impresion = new File(conf.get(CampoConfiguracion.DIRECTORIO_TRABAJO).toString());
        impresion = new File(impresion, "impresion");
        if (!impresion.exists()) {
            if (!impresion.mkdirs()) {
                //TODO Paula, crear mensaje, E0690 provisional
                throw new ControlError("E0690", impresion.getAbsolutePath());
            }
        }

        //Limpiar el directorio de impresion
        if (impresion.isDirectory()) {
            File[] files = impresion.listFiles();
            if (files != null) {
                for (File f : files) {
                    f.delete();
                }
            }
        }
        boolean imprimeLogo = true;
        String[] byRefMsgError =
                {""};
        Recibo reciboAct = new Recibo();
        reciboAct.Tipo = (short) reporte;
        reciboAct.TipoPapel = ((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp;

        nombreArchivo = generarArchivoReporte(reporte, impresion.getAbsolutePath(), reciboAct, imprimeLogo, byRefMsgError);

        if (!archivosGenerados.containsKey(nombreArchivo) && !nombreArchivo.equals("")) {
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
        intent.putExtra("orientacion", orientacion);
        intent.setDataAndType(Uri.fromFile(file), "application/pdf");
        intent.setClass(((Context) vista), PDFViewer.class);
        intent.setAction("android.intent.action.VIEW");
        ((Context) vista).startActivity(intent);
    }

    private static String generarArchivoReporte(int reporte, String directorioArchivo, Recibo recibo, boolean imprimeLogo, String[] byRefMsgError) throws Exception {
        String nombreArchivo = "";
        try {
            nombreArchivo = "Reportes" + Integer.toString(reporte);
            File archivoRecibo = new File(directorioArchivo, nombreArchivo);
            if (!archivoRecibo.exists()) {
                if (!archivoRecibo.createNewFile()) {
                    byRefMsgError[0] = "El archivo no se pudo crear";
                    return "";
                }
            }

            int tipoCobranza = Enumeradores.TIPOCOB.VENTAS;
            Cliente cliente;
            //crear el archivo PDF y pasarlo al metodo que genera el reporte para generar el pdf
            Document document = null;
            if (reporte == 5) {
                document = new Document(new Rectangle(1495, 595));
            } else if (reporte == Enumeradores.REPORTEA.COBRANZA_GONAC ) {
                //Cobranza Ventas
                if  (Integer.parseInt(((CONHist) Sesion.get(Campo.CONHist)).get("TipoCobranza").toString()) == Enumeradores.TIPOCOB.AMBAS )
                {
                    cliente = ((Cliente)Sesion.get(Campo.FiltroReporteCliente));
                    BDVend.recuperar(cliente);
                    if (cliente.TipoFiscal == Enumeradores.DOCFISC.NOTA_VENTA ){
                        tipoCobranza = Enumeradores.TIPOCOB.VENTAS;
                    }else{
                        tipoCobranza = Enumeradores.TIPOCOB.FACTURAS;
                    }
                }else{
                    tipoCobranza = Integer.parseInt(((CONHist) Sesion.get(Campo.CONHist)).get("TipoCobranza").toString());
                }
                    //if (tipoCobranza ==  Enumeradores.TIPOCOB.VENTAS) {
                        document = new Document(new Rectangle(1235, 595));
                        orientacion = ActivityInfo.SCREEN_ORIENTATION_LANDSCAPE;
                    /*}else{
                        document = new Document();
                        orientacion = ActivityInfo.SCREEN_ORIENTATION_PORTRAIT;*/
                    //}
            } else {
                document = new Document();
            }

            PdfWriter pdfWriter = PdfWriter.getInstance(document, new FileOutputStream(directorioArchivo + "/Reportes" + Integer.toString(reporte) + ".pdf"));
            document.open();

            //Valores default
            //int columnasRecibo  = 48;
            StringBuilder cadenaRecibo = new StringBuilder();

            if (imprimeLogo) {
                cadenaRecibo.append("IMPRIME_LOGO\r\n");
            }

            String filtroFechas;
            Date fechaIni;
            Date fechaFin;

            switch (reporte) {
                //resumen movimientos costeña
                case 1:
                    generarReporteResumenMovsCostena(reporte, cadenaRecibo, document);
                    //generarReporteResumenMovsGMCostena(reporte, cadenaRecibo, document);
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
                case 5:
                    generarReportePedidosPreventa(reporte, cadenaRecibo, document);
                    break;
                case Enumeradores.REPORTEA.COBRANZA_GONAC:
                    cliente = ((Cliente)Sesion.get(Campo.FiltroReporteCliente));
                    if (cliente != null) {
                        if (tipoCobranza == Enumeradores.TIPOCOB.VENTAS){
                            generarReporteCobranza(reporte, cadenaRecibo, document, cliente);
                        }else{
                            generarReporteCobranzaFacturas(reporte, cadenaRecibo,document,cliente);
                        }
                    }
                    break;
                case Enumeradores.REPORTEA.PEDIDOS_CONFIRMADOS_SAP:
                    cliente = ((Cliente)Sesion.get(Campo.FiltroReporteCliente));
                    filtroFechas = (Sesion.get(Campo.FiltroReporteFechas).toString());
                    fechaIni = ((Date)Sesion.get(Campo.FiltroReporteFechaIni));
                    fechaFin = ((Date)Sesion.get(Campo.FiltroReporteFechaFin));
                    generarReporteConfirmacionPedidosSAP(reporte, cadenaRecibo, document, cliente, filtroFechas, fechaIni, fechaFin);
                    break;
                case Enumeradores.REPORTEA.EFECTIVIDAD_RUTA:
                    generarReporteEfectividadRuta(reporte, cadenaRecibo, document);
                    break;
                case Enumeradores.REPORTEA.COBRANZA_GENERICO:
                    generarReporteCobranzaGenerico(reporte, cadenaRecibo, document);
                    break;
                case Enumeradores.REPORTEA.RESUMEN_MOV_MASIVO_COSTENA:
                    generarReporteResumenMovsGMCostena(reporte, cadenaRecibo, document);
                    break;
                case Enumeradores.REPORTEA.RESUMEN_COBRANZA_GENERICO:
                    generarReporteResumenCobranzaGenerico(reporte, cadenaRecibo, document);
                    break;
                case Enumeradores.REPORTEA.PREPEDIDO:
                    generarReportePrepedido(reporte, cadenaRecibo, document);
                    break;
                case Enumeradores.REPORTEA.INVENTARIO_GENERICO:
                    generarReporteInventarioGenerico(reporte, cadenaRecibo, document);
                    break;
                case Enumeradores.REPORTEA.RESUMEN_MOVIMIENTOS_GENERICO:
                    generarReporteResumenMovimientos(reporte, cadenaRecibo, document, (boolean) Sesion.get(Campo.FiltroVarioDetallado));
                    break;
                case Enumeradores.REPORTEA.CARGAS_GENERICO:
                    generarReporteCargas(reporte, cadenaRecibo, document);
                    break;
                case Enumeradores.REPORTEA.SALDO_CLIENTE_ENVASE:
                    generarReporteSaldoClienteEnvase(reporte, cadenaRecibo, document);
                    break;
                case Enumeradores.REPORTEA.RECOLECCION_ENVASE:
                    generarReporteRecoleccionEnvase(reporte, cadenaRecibo, document);
                    break;
                case Enumeradores.REPORTEA.VENTAS:
                    generarReporteVentas(reporte, cadenaRecibo, document, (boolean) Sesion.get(Campo.FiltroVarioDetallado),(boolean) Sesion.get(Campo.FiltroVarioTotalProductosPrecio));
                    break;
                case Enumeradores.REPORTEA.DESCARGAS_DEVOLUCIONES_ALMACEN:
                    filtroFechas = (Sesion.get(Campo.FiltroReporteFechas).toString());
                    fechaIni = ((Date)Sesion.get(Campo.FiltroReporteFechaIni));
                    fechaFin = ((Date)Sesion.get(Campo.FiltroReporteFechaFin));
                    generarReporteDescargasDevolucionAlmacen(reporte,cadenaRecibo,document, (boolean) Sesion.get(Campo.FiltroVarioDetallado), filtroFechas, fechaIni, fechaFin);
                    break;
            }

            document.close(); //cerrar el PDF

            OutputStream f1 = new FileOutputStream(archivoRecibo, true);
            f1.write(StringUtils.stripAccents(cadenaRecibo.toString()).getBytes());
            Log.d("ImpresioTicket", cadenaRecibo.toString());
            f1.close();

        } catch (Exception ex) {
            throw new Exception("Error al generar ticket:" + ex.getMessage());
        }
        return nombreArchivo;
    }
//region REPORTES

    private static void generarReporteRecoleccionEnvase(int reporte, StringBuilder cadenaRecibo, Document document) throws Exception {
        String cadena = "";
        String texto = "";
        int columna = 10;
        int max = 38;
        int max2 = 38;

        //filtros
        //boolean general = Boolean.parseBoolean(Sesion.get(Campo.FiltroVarioGeneral).toString());
        //boolean detallado = Boolean.parseBoolean(Sesion.get(Campo.FiltroVarioDetallado).toString());
        /*ArrayList<Cliente> clientes = (ArrayList<Cliente>) Sesion.get(Campo.FiltroReporteCliente);
        ArrayList<Cliente> clientesSeleccionados = new ArrayList<>();
        for(Cliente cliente : clientes){
            if(cliente.Enviado)
                clientesSeleccionados.add(cliente);
        }*/

        ISetDatos idataRuta = Consultas.ConsultasRuta.obtenerRutas();
        String rutas = "";
        while (idataRuta.moveToNext()){
            rutas += idataRuta.getString("RUTClave") + ",";
        }
        if(rutas.length() > 0)
            rutas = rutas.substring(0, rutas.length()-1);
        idataRuta.close();

        Paragraph reportePDF = new Paragraph();
        reportePDF.setFont(textoNegrita); //letra general para el reporte

        setTamanioDefault(((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp);
        TamanioLetra tamanioLetra;
        tamanioLetra = tamanioDefault;

        if (((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.ZEBRA_TERMICA2 || ((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.ZEBRA_CAMEO2) {
            cadena = "{" + tamanioLetra.mTamanio + " " + tamanioLetra.mAlto + "}";
        } else if (((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.INTERMEC_PR2 || ((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.INTERMEC_PR3) {
            //Se usa el mAlto para indentificar si la letra es normal o doble 0= normal 1= doble
            //En la cadena de los bytes no se debe dejar espacios, si no falla y se consideran hasta el momento
            //3 bytes en el mensaje, por lo que si se mete menos o mas, hay que cambiar el codigo en BluetoothPrint
            if (tamanioLetra.mAlto != 0) {
                cadena = "{27,33," + tamanioLetra.mTamanio + "}";
            }
            else
            {
                cadena = "{27,119," + tamanioLetra.mTamanio + "}";
            }
        }   else if( ((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.ZEBRA_TERMICA3 ) {
            cadena = "! U1 SETLP 7 " + tamanioLetra.mTamanio + " " + tamanioLetra.mAlto + " ";
        }
        else
        {
            cadena = "{" + tamanioLetra.mTamanio + "}";
            if (((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.SEWOO) {
                max2 = 32;
            }
        }
        columna = tamanioLetra.mLongTotal/3;

        ISetDatos encabezado = ConsultasImpresionTicket.obtenerEncabezado();
        encabezado.moveToFirst();

        texto = encabezado.getString("NombreEmpresa");
        cadena = cadena + alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, columna*3);
        cadenaRecibo.append(cadena + "\r\n");

        Paragraph empresa = new Paragraph(texto, textoNegrita);
        empresa.setAlignment(Element.ALIGN_CENTER);
        reportePDF.add(empresa);

        texto = encabezado.getString("RFC");
        cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, columna*3);
        cadenaRecibo.append(cadena + "\r\n");

        Paragraph rfc = new Paragraph(texto, textoNegrita);
        rfc.setAlignment(Element.ALIGN_CENTER);
        reportePDF.add(rfc);

        texto = encabezado.getString("Calle") + " " + encabezado.getString("Numero") + ", ";
        cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, columna*3);
        cadenaRecibo.append(cadena + "\r\n");

        Paragraph domicilio = new Paragraph(texto, textoNegrita);
        domicilio.setAlignment(Element.ALIGN_CENTER);
        reportePDF.add(domicilio);

        texto = Mensajes.get("XCol")+ " " + encabezado.getString("Colonia")+",";
        cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, columna*3);
        cadenaRecibo.append(cadena + "\r\n");

        Paragraph colonia = new Paragraph(texto, textoNegrita);
        colonia.setAlignment(Element.ALIGN_CENTER);
        reportePDF.add(colonia);

        texto = encabezado.getString("Ciudad") + ", " + encabezado.getString("Region");
        cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, columna*3);
        cadenaRecibo.append(cadena + "\r\n");

        Paragraph ciudad = new Paragraph(texto, textoNegrita);
        ciudad.setAlignment(Element.ALIGN_CENTER);
        reportePDF.add(ciudad);

        cadenaRecibo.append("\r\n");
        reportePDF.add(new Paragraph(" ")); //linea en blanco = \r\n

        texto = Mensajes.get("XImpresion") + ": " + Generales.getFechaHoraActualStr("dd/MM/yyyy hh:mm:ss");
        cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, columna*3);
        cadenaRecibo.append(cadena + "\r\n");

        Paragraph impresion = new Paragraph(texto, textoNegrita);
        impresion.setAlignment(Element.ALIGN_CENTER);
        reportePDF.add(impresion);

        texto = Mensajes.get("XVendedor") + ": " + ((Usuario) Sesion.get(Campo.UsuarioActual)).Nombre;
        cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, columna*3);
        cadenaRecibo.append(cadena + "\r\n");

        Paragraph ven = new Paragraph(texto, textoNegrita);
        ven.setAlignment(Element.ALIGN_CENTER);
        reportePDF.add(ven);

        texto = Mensajes.get("XRuta") + ": " + rutas;
        cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, columna*3);
        cadenaRecibo.append(cadena + "\r\n");

        Paragraph ruta = new Paragraph(texto, textoNegrita);
        ruta.setAlignment(Element.ALIGN_CENTER);
        reportePDF.add(ruta);

        cadenaRecibo.append("\r\n");
        reportePDF.add(new Paragraph(" ")); //linea en blanco = \r\n

        texto = ValoresReferencia.getDescripcion("REPORTEA", String.valueOf(reporte));
        //texto += " - " + (general ? Mensajes.get("XGeneral").toUpperCase() : Mensajes.get("XDetallado").toUpperCase());
        cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, columna*3);

        cadenaRecibo.append(cadena + "\r\n");
        //cadenaRecibo.append("\r\n");

        Paragraph titulo = new Paragraph(texto, tituloRojo);
        titulo.setAlignment(Element.ALIGN_CENTER);
        reportePDF.add(titulo);
        reportePDF.add(new Paragraph(" ")); //linea en blanco = \r\n

        encabezado.close();

        imprimeLineaPunteada(cadenaRecibo, columna*3);

        /*String clientesSel = "";
        for(Cliente cliente : clientesSeleccionados){
            clientesSel += "'" + cliente.ClienteClave + "',";
        }
        if(clientesSel.length() > 0)
            clientesSel = clientesSel.substring(0, clientesSel.length()-1);*/

        //obtener motivos
        ISetDatos motivosDev = Consultas.ConsultasValorReferencia.obtenerValoresPorGrupo("TRPMOT","'Venta','Recolección'","",false);
        String motivos = "";
        while(motivosDev.moveToNext()){
            motivos += "'" + motivosDev.getString("_id") + "',";
        }
        motivosDev.close();
        if(motivos.length() > 0)
            motivos = motivos.substring(0, motivos.length() - 1);

        //encabezado
        texto = Mensajes.get("XClave");
        cadena = completaHasta(texto, columna * 1, TipoAlineacion.IZQUIERDA, false);
        texto = Mensajes.get("XProducto");
        cadena += completaHasta(texto, columna * 1, TipoAlineacion.IZQUIERDA, false);
        texto = Mensajes.get("XCantidad");
        cadena += completaHasta(texto, columna * 1, TipoAlineacion.DERECHA, true);
        cadenaRecibo.append(cadena + "\r\n");
        Paragraph encabezado_1 = new Paragraph(cadena, textoNegrita);
        reportePDF.add(encabezado_1);
        reportePDF.add(new Paragraph(" ")); //linea en blanco = \r\n

        imprimeLineaPunteada(cadenaRecibo, columna * 3);

        //detalle clientes
        boolean primero = true;
        //float total = 0;
        String clienteActual = "";
        ISetDatos devs = Consultas.ConsultasTransProd.obtenerRecoleccionEnvase(motivos);
        while(devs.moveToNext()){
            if (!devs.getString("Cliente").equals(clienteActual)){
                if(!primero){
                    cadenaRecibo.append("\r\n");
                    reportePDF.add(new Paragraph(" ")); //linea en blanco = \r\n
                }
                texto = devs.getString("Cliente");
                cadena = completaHasta(texto, columna * 3, TipoAlineacion.IZQUIERDA, false);
                cadenaRecibo.append(cadena + "\r\n");
                reportePDF.add(cadena);
                clienteActual = devs.getString("Cliente");
                primero = false;
            }
            texto = devs.getString("ProductoClave");
            cadena = completaHasta(texto, columna * 1, TipoAlineacion.IZQUIERDA, false);
            texto = devs.getString("Nombre");
            cadena += completaHasta(texto, columna * 1, TipoAlineacion.IZQUIERDA, false);
            texto = devs.getString("Cantidad");
            //total += devs.getFloat("Cantidad");
            cadena += completaHasta(texto, columna * 1, TipoAlineacion.DERECHA, true);
            cadenaRecibo.append(cadena + "\r\n");
            reportePDF.add(cadena);
        }
        devs.close();

        //total
        //cadenaRecibo.append("\r\n");
        reportePDF.add(new Paragraph(" "));

        /*texto = Mensajes.get("XTotal") + ": " + String.valueOf(Generales.getFormatoDecimal(total,0));
        cadena = completaHasta(texto, columna * 3, TipoAlineacion.DERECHA, true);
        cadenaRecibo.append(cadena + "\r\n");
        reportePDF.add(cadena);
        reportePDF.add(new Paragraph(" "));*/

        imprimeLineaPunteada(cadenaRecibo, columna * 3);
        //cadenaRecibo.append("\r\n");
        reportePDF.add(new Paragraph(" "));

        texto = Mensajes.get("XProductoXClave").toUpperCase();
        cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, columna*3);
        cadenaRecibo.append(cadena + "\r\n");
        Paragraph res = new Paragraph(texto, textoNegrita);
        res.setAlignment(Element.ALIGN_CENTER);
        reportePDF.add(res);

        imprimeLineaPunteada(cadenaRecibo, columna * 3);
        reportePDF.add(new Paragraph(" "));

        //total = 0;
        ISetDatos totales = Consultas.ConsultasTransProd.obtenerRecoleccionEnvaseTotalesXClave(motivos);
        while(totales.moveToNext()){
            texto = totales.getString("ProductoClave");
            cadena = completaHasta(texto, columna * 1, TipoAlineacion.IZQUIERDA, false);
            texto = totales.getString("Nombre");
            cadena += completaHasta(texto, columna * 1, TipoAlineacion.IZQUIERDA, false);
            texto = totales.getString("Cantidad");
            //total += devs.getFloat("Cantidad");
            cadena += completaHasta(texto, columna * 1, TipoAlineacion.DERECHA, true);
            cadenaRecibo.append(cadena + "\r\n");
            reportePDF.add(cadena);
        }
        totales.close();

        cadenaRecibo.append("\r\n");
        reportePDF.add(new Paragraph(" "));

        //texto = Mensajes.get("XTotal") + ": " + String.valueOf(Generales.getFormatoDecimal(total,0));
        /*cadena = completaHasta(texto, columna * 3, TipoAlineacion.DERECHA, true);
        cadenaRecibo.append(cadena + "\r\n");
        reportePDF.add(cadena);
        reportePDF.add(new Paragraph(" "));*/

        document.add(reportePDF);
    }

    private static void generarReporteSaldoClienteEnvase(int reporte, StringBuilder cadenaRecibo, Document document) throws Exception {
        String cadena = "";
        String texto = "";
        int columna = 10;
        int max = 38;
        int max2 = 38;

        //filtros
        boolean general = Boolean.parseBoolean(Sesion.get(Campo.FiltroVarioGeneral).toString());
        boolean detallado = Boolean.parseBoolean(Sesion.get(Campo.FiltroVarioDetallado).toString());
        ArrayList<Cliente> clientes = (ArrayList<Cliente>) Sesion.get(Campo.FiltroReporteCliente);
        ArrayList<Cliente> clientesSeleccionados = new ArrayList<>();
        for(Cliente cliente : clientes){
            if(cliente.Enviado)
                clientesSeleccionados.add(cliente);
        }

        Paragraph reportePDF = new Paragraph();
        reportePDF.setFont(textoNegrita); //letra general para el reporte

        setTamanioDefault(((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp);
        TamanioLetra tamanioLetra;
        tamanioLetra = tamanioDefault;

        if (((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.ZEBRA_TERMICA2 || ((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.ZEBRA_CAMEO2) {
            cadena = "{" + tamanioLetra.mTamanio + " " + tamanioLetra.mAlto + "}";
        } else if (((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.INTERMEC_PR2 || ((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.INTERMEC_PR3) {
            //Se usa el mAlto para indentificar si la letra es normal o doble 0= normal 1= doble
            //En la cadena de los bytes no se debe dejar espacios, si no falla y se consideran hasta el momento
            //3 bytes en el mensaje, por lo que si se mete menos o mas, hay que cambiar el codigo en BluetoothPrint
            if (tamanioLetra.mAlto != 0) {
                cadena = "{27,33," + tamanioLetra.mTamanio + "}";
            }
            else
            {
                cadena = "{27,119," + tamanioLetra.mTamanio + "}";
            }
        }   else if( ((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.ZEBRA_TERMICA3 ) {
            cadena = "! U1 SETLP 7 " + tamanioLetra.mTamanio + " " + tamanioLetra.mAlto + " ";
        }
        else
        {
            cadena = "{" + tamanioLetra.mTamanio + "}";
            if (((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.SEWOO) {
                max2 = 32;
            }
        }
        columna = tamanioLetra.mLongTotal/3;

        ISetDatos encabezado = ConsultasImpresionTicket.obtenerEncabezado();
        encabezado.moveToFirst();

        texto = encabezado.getString("NombreEmpresa");
        cadena = cadena + alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, columna*3);
        cadenaRecibo.append(cadena + "\r\n");

        Paragraph empresa = new Paragraph(texto, textoNegrita);
        empresa.setAlignment(Element.ALIGN_CENTER);
        reportePDF.add(empresa);

        texto = encabezado.getString("RFC");
        cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, columna*3);
        cadenaRecibo.append(cadena + "\r\n");

        Paragraph rfc = new Paragraph(texto, textoNegrita);
        rfc.setAlignment(Element.ALIGN_CENTER);
        reportePDF.add(rfc);

        texto = encabezado.getString("Calle") + " " + encabezado.getString("Numero") + ", ";
        cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, columna*3);
        cadenaRecibo.append(cadena + "\r\n");

        Paragraph domicilio = new Paragraph(texto, textoNegrita);
        domicilio.setAlignment(Element.ALIGN_CENTER);
        reportePDF.add(domicilio);

        texto = Mensajes.get("XCol")+ " " + encabezado.getString("Colonia")+",";
        cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, columna*3);
        cadenaRecibo.append(cadena + "\r\n");

        Paragraph colonia = new Paragraph(texto, textoNegrita);
        colonia.setAlignment(Element.ALIGN_CENTER);
        reportePDF.add(colonia);

        texto = encabezado.getString("Ciudad") + ", " + encabezado.getString("Region");
        cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, columna*3);
        cadenaRecibo.append(cadena + "\r\n");

        Paragraph ciudad = new Paragraph(texto, textoNegrita);
        ciudad.setAlignment(Element.ALIGN_CENTER);
        reportePDF.add(ciudad);

        cadenaRecibo.append("\r\n");
        reportePDF.add(new Paragraph(" ")); //linea en blanco = \r\n

        texto = Mensajes.get("XImpresion") + ": " + Generales.getFechaHoraActualStr("dd/MM/yyyy hh:mm:ss");
        cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, columna*3);
        cadenaRecibo.append(cadena + "\r\n");

        Paragraph impresion = new Paragraph(texto, textoNegrita);
        impresion.setAlignment(Element.ALIGN_CENTER);
        reportePDF.add(impresion);

        texto = Mensajes.get("XVendedor") + ": " + ((Usuario) Sesion.get(Campo.UsuarioActual)).Nombre;
        cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, columna*3);
        cadenaRecibo.append(cadena + "\r\n");

        Paragraph ven = new Paragraph(texto, textoNegrita);
        ven.setAlignment(Element.ALIGN_CENTER);
        reportePDF.add(ven);

        cadenaRecibo.append("\r\n");
        reportePDF.add(new Paragraph(" ")); //linea en blanco = \r\n

        texto = ValoresReferencia.getDescripcion("REPORTEA", String.valueOf(reporte));
        texto += " - " + (general ? Mensajes.get("XGeneral").toUpperCase() : Mensajes.get("XDetallado").toUpperCase());
        cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, columna*3);

        cadenaRecibo.append(cadena + "\r\n");
        //cadenaRecibo.append("\r\n");

        Paragraph titulo = new Paragraph(texto, tituloRojo);
        titulo.setAlignment(Element.ALIGN_CENTER);
        reportePDF.add(titulo);
        reportePDF.add(new Paragraph(" ")); //linea en blanco = \r\n

        encabezado.close();

        imprimeLineaPunteada(cadenaRecibo, columna*3);

        String clientesSel = "";
        for(Cliente cliente : clientesSeleccionados){
            clientesSel += "'" + cliente.ClienteClave + "',";
        }
        if(clientesSel.length() > 0)
            clientesSel = clientesSel.substring(0, clientesSel.length()-1);

        if (general) {
            //encabezado
            texto = Mensajes.get("XCliente");
            cadena = completaHasta(texto, columna * 2, TipoAlineacion.IZQUIERDA, false);
            texto = Mensajes.get("XSaldo");
            cadena += completaHasta(texto, columna * 1, TipoAlineacion.DERECHA, true);
            cadenaRecibo.append(cadena + "\r\n");
            Paragraph encabezado_1 = new Paragraph(cadena, textoNegrita);
            reportePDF.add(encabezado_1);
            reportePDF.add(new Paragraph(" ")); //linea en blanco = \r\n

            imprimeLineaPunteada(cadenaRecibo, columna * 3);

            //detalle clientes
            float total = 0;
            ISetDatos saldo = Consultas.ConsultasProductoPrestamoCli.obtenerSaldoClienteGeneral(clientesSel);
            while(saldo.moveToNext()){
                texto = saldo.getString("RazonSocial");
                cadena = completaHasta(texto, columna * 2, TipoAlineacion.IZQUIERDA, false);
                texto = saldo.getString("Saldo");
                total += saldo.getFloat("Saldo");
                cadena += completaHasta(texto, columna * 1, TipoAlineacion.DERECHA, true);
                cadenaRecibo.append(cadena + "\r\n");
                reportePDF.add(cadena);
            }
            saldo.close();

            //total
            cadenaRecibo.append("\r\n");
            reportePDF.add(new Paragraph(" "));

            texto = Mensajes.get("XTotal") + ": " + String.valueOf(Generales.getFormatoDecimal(total,0));
            cadena = completaHasta(texto, columna * 3, TipoAlineacion.DERECHA, true);
            cadenaRecibo.append(cadena + "\r\n");
            reportePDF.add(cadena);
            reportePDF.add(new Paragraph(" "));
        }else if(detallado){
            //encabezado
            texto = Mensajes.get("XCliente");
            cadena = completaHasta(texto, columna * 1, TipoAlineacion.IZQUIERDA, false);
            texto = Mensajes.get("XEnvase");
            cadena += completaHasta(texto, columna * 1, TipoAlineacion.IZQUIERDA, false);
            texto = Mensajes.get("XSaldo");
            cadena += completaHasta(texto, columna * 1, TipoAlineacion.DERECHA, true);
            cadenaRecibo.append(cadena + "\r\n");
            Paragraph encabezado_1 = new Paragraph(cadena, textoNegrita);
            reportePDF.add(encabezado_1);
            reportePDF.add(new Paragraph(" ")); //linea en blanco = \r\n

            imprimeLineaPunteada(cadenaRecibo, columna * 3);

            //detalle clientes
            boolean primero = true;
            float total = 0;
            String clienteActual = "";
            ISetDatos saldo = Consultas.ConsultasProductoPrestamoCli.obtenerSaldoClienteDetallado(clientesSel);
            while(saldo.moveToNext()){
                if (!saldo.getString("RazonSocial").equals(clienteActual)){
                    if(!primero){
                        cadenaRecibo.append("\r\n");
                        reportePDF.add(new Paragraph(" ")); //linea en blanco = \r\n
                    }
                    texto = saldo.getString("RazonSocial");
                    cadena = completaHasta(texto, columna * 3, TipoAlineacion.IZQUIERDA, false);
                    cadenaRecibo.append(cadena + "\r\n");
                    reportePDF.add(cadena);
                    clienteActual = saldo.getString("RazonSocial");
                    primero = false;
                }
                cadena = completaHasta(agregarEspaciosColumna(1," ",columna), columna * 1, TipoAlineacion.IZQUIERDA, false);
                texto = saldo.getString("Nombre");
                cadena += completaHasta(texto, columna * 1, TipoAlineacion.IZQUIERDA, false);
                texto = saldo.getString("Saldo");
                total += saldo.getFloat("Saldo");
                cadena += completaHasta(texto, columna * 1, TipoAlineacion.DERECHA, true);
                cadenaRecibo.append(cadena + "\r\n");

                Paragraph detalle = new Paragraph(cadena, textoNegrita);
                ven.setAlignment(Element.ALIGN_RIGHT);
                reportePDF.add(detalle);
            }
            saldo.close();

            //total
            cadenaRecibo.append("\r\n");
            reportePDF.add(new Paragraph(" "));

            texto = Mensajes.get("XTotal") + ": " + String.valueOf(Generales.getFormatoDecimal(total,0));
            cadena = completaHasta(texto, columna * 3, TipoAlineacion.DERECHA, true);
            cadenaRecibo.append(cadena + "\r\n");
            reportePDF.add(cadena);
            reportePDF.add(new Paragraph(" "));

            imprimeLineaPunteada(cadenaRecibo, columna * 3);

            cadenaRecibo.append("\r\n");
            reportePDF.add(new Paragraph(" "));

            texto = Mensajes.get("XRESUMEN");
            cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, columna*3);
            cadenaRecibo.append(cadena + "\r\n");
            Paragraph res = new Paragraph(texto, textoNegrita);
            res.setAlignment(Element.ALIGN_CENTER);
            reportePDF.add(res);

            total = 0;
            ISetDatos resumen = Consultas.ConsultasProductoPrestamoCli.obtenerSaldoClienteDetalladoResumen(clientesSel);
            while(resumen.moveToNext()){
                texto = resumen.getString("Nombre");
                cadena = completaHasta(texto, tamanioLetra.mLongTotal / 2, TipoAlineacion.IZQUIERDA, false);
                texto = resumen.getString("Saldo");
                total += resumen.getFloat("Saldo");
                cadena += completaHasta(texto, tamanioLetra.mLongTotal / 2, TipoAlineacion.DERECHA, true);
                cadenaRecibo.append(cadena + "\r\n");
                reportePDF.add(cadena);
            }
            resumen.close();

            cadenaRecibo.append("\r\n");
            reportePDF.add(new Paragraph(" "));

            texto = Mensajes.get("XTotal") + ": " + String.valueOf(Generales.getFormatoDecimal(total,0));
            cadena = completaHasta(texto, columna * 3, TipoAlineacion.DERECHA, true);
            cadenaRecibo.append(cadena + "\r\n");
            reportePDF.add(cadena);
            reportePDF.add(new Paragraph(" "));
        }

        document.add(reportePDF);
    }

    private static void generarReporteInventarioGenerico(int reporte, StringBuilder cadenaRecibo, Document document) throws Exception{



        double totalUnidad = 0;

        boolean general = Boolean.parseBoolean(Sesion.get(Campo.FiltroVarioGeneral).toString());
        boolean totalizar = Boolean.parseBoolean(Sesion.get(Campo.FiltroVarioTotalizar).toString());
        String cadena = "";
        String texto = "";
        String texto2 = "";
        int max = 38;
        int col;

        short TipoImpresora=((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp;


        Paragraph reportePDF = new Paragraph();
        reportePDF.setFont(textoNegrita); //letra general para el reporte

        setTamanioDefault(((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp);
        TamanioLetra tamanioLetra = tamanioDefault;


        if (((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.ZEBRA_TERMICA2 || ((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.ZEBRA_CAMEO2) {
            cadena = "{" + tamanioLetra.mTamanio + " " + tamanioLetra.mAlto + "}";
        } else if (((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.INTERMEC_PR2 || ((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.INTERMEC_PR3) {
            //Se usa el mAlto para indentificar si la letra es normal o doble 0= normal 1= doble
            //En la cadena de los bytes no se debe dejar espacios, si no falla y se consideran hasta el momento
            //3 bytes en el mensaje, por lo que si se mete menos o mas, hay que cambiar el codigo en BluetoothPrint
            if (tamanioLetra.mAlto != 0) {
                cadena = "{27,33," + tamanioLetra.mTamanio + "}";
            }
            else
            {
                cadena = "{27,119," + tamanioLetra.mTamanio + "}";
            }
        }   else if( ((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.ZEBRA_TERMICA3 ) {
            cadena = "! U1 SETLP 7 " + tamanioLetra.mTamanio + " " + tamanioLetra.mAlto + " ";
            max = 48;
        }
        else
        {
            cadena = "{" + tamanioLetra.mTamanio + "}";
            if (((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.SEWOO) {
                max = 32;
            }
        }

        max = tamanioLetra.mLongTotal;
        col = max/5;

        ISetDatos subEmpresas = Consultas.ConsultasTransProd.obtenerSubEmpresas();

        while (subEmpresas.moveToNext()){

            texto = subEmpresas.getString("NombreEmpresa");
            cadena = cadena + alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, max);
            cadenaRecibo.append(cadena + "\r\n");

            Paragraph empresa = new Paragraph(texto, textoNegrita);
            empresa.setAlignment(Element.ALIGN_CENTER);
            reportePDF.add(empresa);

            texto = subEmpresas.getString("RFC");
            cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, max);
            cadenaRecibo.append(cadena + "\r\n");

            Paragraph rfc = new Paragraph(texto, textoNegrita);
            rfc.setAlignment(Element.ALIGN_CENTER);
            reportePDF.add(rfc);

            texto = subEmpresas.getString("Calle") + " " + subEmpresas.getString("Numero") + ", "+ Mensajes.get("XCol")+ " " + subEmpresas.getString("Colonia")+",";
            cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, max);
            cadenaRecibo.append(cadena + "\r\n");

            Paragraph domicilio = new Paragraph(texto, textoNegrita);
            domicilio.setAlignment(Element.ALIGN_CENTER);
            reportePDF.add(domicilio);

            texto = subEmpresas.getString("Ciudad") + ", " + subEmpresas.getString("Region");
            cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, max);
            cadenaRecibo.append(cadena + "\r\n");

            Paragraph ciudad = new Paragraph(texto, textoNegrita);
            ciudad.setAlignment(Element.ALIGN_CENTER);
            reportePDF.add(ciudad);

            cadenaRecibo.append("\r\n");
            reportePDF.add(new Paragraph(" "));

            texto = Mensajes.get("XImpresion") + ": " + Generales.getFechaHoraActualStr("dd/MM/yyyy hh:mm:ss");
            cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, max);
            cadenaRecibo.append(cadena + "\r\n");

            Paragraph impresion = new Paragraph(texto, textoNegrita);
            impresion.setAlignment(Element.ALIGN_CENTER);
            reportePDF.add(impresion);

            texto = Mensajes.get("XVendedor") + ": " + ((Usuario) Sesion.get(Campo.UsuarioActual)).Nombre;
            cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, max);
            cadenaRecibo.append(cadena + "\r\n");

            Paragraph ven = new Paragraph(texto, textoNegrita);
            ven.setAlignment(Element.ALIGN_CENTER);
            reportePDF.add(ven);

            cadenaRecibo.append("\r\n");
            reportePDF.add(new Paragraph(" "));

            texto = ValoresReferencia.getDescripcion("REPORTEA", String.valueOf(reporte));
            cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, max);

            cadenaRecibo.append(cadena + "\r\n");
            cadenaRecibo.append("\r\n");

            Paragraph titulo = new Paragraph(texto, tituloRojo);
            titulo.setAlignment(Element.ALIGN_CENTER);
            reportePDF.add(titulo);

            texto = general?Mensajes.get("XGeneral"):Mensajes.get("XDetallado");
            cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, max);

            cadenaRecibo.append(cadena + "\r\n");

            Paragraph tipoReporte = new Paragraph(texto, tituloRojo);
            tipoReporte.setAlignment(Element.ALIGN_CENTER);
            reportePDF.add(tipoReporte);

            cadenaRecibo.append("\r\n");
            reportePDF.add(new Paragraph(" ")); //linea en blanco = \r\n

            texto = completaHasta(Mensajes.get("XProducto"),20,TipoAlineacion.IZQUIERDA,false)+
                    completaHasta(Mensajes.get("XExist"),10,TipoAlineacion.DERECHA,false)+
                    completaHasta("Disp",10,TipoAlineacion.DERECHA,false)+
                    completaHasta("No D",10,TipoAlineacion.DERECHA,false);

            texto2 = completaHasta(Mensajes.get("XProducto"),TipoImpresora == TipoPapel.INTERMEC_PR3?34:col*2,TipoAlineacion.IZQUIERDA,false)+
                    completaHasta(Mensajes.get("XExist"),TipoImpresora == TipoPapel.INTERMEC_PR3?7:col,TipoAlineacion.DERECHA,false)+
                    completaHasta("Disp",TipoImpresora == TipoPapel.INTERMEC_PR3?7:col,TipoAlineacion.DERECHA,false)+
                    completaHasta("No D",TipoImpresora == TipoPapel.INTERMEC_PR3?7:col,TipoAlineacion.DERECHA,false);

            cadena = alineaTexto(BTIPALI.TipoAlineacion.IZQUIERDA,texto2,max);


            cadenaRecibo.append(cadena + "\r\n");

            Paragraph titulos = new Paragraph(texto, Recibos.textoNegrita);
            titulos.setAlignment(Element.ALIGN_CENTER);
            reportePDF.add(titulos);

            cadenaRecibo.append("\r\n");
            reportePDF.add(new Paragraph(" "));
            cadenaRecibo.append("\r\n");
            reportePDF.add(new Paragraph(" "));

            Paragraph row;

            if(general){

                ISetDatos inventario = Consultas.ConsultasTransProd.obtenerInventarioGeneral(subEmpresas.getString("SubEmpresaId"));

                while (inventario.moveToNext()){

                    texto = completaHasta(inventario.getString("ProductoClave")+"-"+inventario.getString("Nombre"),20,TipoAlineacion.IZQUIERDA,false)+
                            completaHasta(Generales.getFormatoDecimal(inventario.getDouble("Exis"),"#.##"),10,TipoAlineacion.DERECHA,false)+
                            completaHasta(Generales.getFormatoDecimal(inventario.getDouble("Disp"),"#.##"),10,TipoAlineacion.DERECHA,false)+
                            completaHasta(Generales.getFormatoDecimal(inventario.getDouble("No D"),"#.##"),10,TipoAlineacion.DERECHA,false);

                    texto2 = completaHasta(inventario.getString("ProductoClave")+"-"+inventario.getString("Nombre"),TipoImpresora == TipoPapel.INTERMEC_PR3?34:col*2,TipoAlineacion.IZQUIERDA,false)+
                            completaHasta(Generales.getFormatoDecimal(inventario.getDouble("Exis"),"#.##"),TipoImpresora == TipoPapel.INTERMEC_PR3?7:col,TipoAlineacion.DERECHA,false)+
                            completaHasta(Generales.getFormatoDecimal(inventario.getDouble("Disp"),"#.##"),TipoImpresora == TipoPapel.INTERMEC_PR3?7:col,TipoAlineacion.DERECHA,false)+
                            completaHasta(Generales.getFormatoDecimal(inventario.getDouble("No D"),"#.##"),TipoImpresora == TipoPapel.INTERMEC_PR3?7:col,TipoAlineacion.DERECHA,false);

                    cadena = alineaTexto(BTIPALI.TipoAlineacion.IZQUIERDA,texto2,max);

                    cadenaRecibo.append(cadena + "\r\n");

                    row = new Paragraph(texto, Recibos.textoNegrita);
                    row.setAlignment(Element.ALIGN_CENTER);
                    reportePDF.add(row);
                }


            } else {

                String productoClaveAnterior = null;
                String productoFactorAnterior = null;

                int existencia = 0;
                int disponible = 0;
                int noDisponible = 0;

                int existenciaRestante = 0;
                int disponibleRestante = 0;
                int noDisponibleRestante = 0;

                int factor;

                ISetDatos inventario = Consultas.ConsultasTransProd.obtenerInventarioDetallado(subEmpresas.getString("SubEmpresaId"));
                while (inventario.moveToNext()){


                    factor = Integer.parseInt(inventario.getString("Factor"));
                    if(productoClaveAnterior != null && productoClaveAnterior.equals(inventario.getString("ProductoClave"))){

                        existencia = existenciaRestante>0?(existenciaRestante/factor):0;
                        disponible = disponibleRestante>0?(disponibleRestante/factor):0;
                        noDisponible = noDisponibleRestante>0?(noDisponibleRestante/factor):0;

                        existenciaRestante = existenciaRestante>0?(existenciaRestante%factor):0;
                        disponibleRestante = disponibleRestante>0?(disponibleRestante%factor):0;
                        noDisponibleRestante = noDisponibleRestante>0?(noDisponibleRestante%factor):0;

                        texto = completaHasta(ValoresReferencia.getDescripcion("UNIDADV", inventario.getString("PRUTipoUnidad")),20,TipoAlineacion.DERECHA,false)+
                                completaHasta(Generales.getFormatoDecimal(existencia, "#.##"),10,TipoAlineacion.DERECHA,false)+
                                completaHasta(Generales.getFormatoDecimal(disponible, "#.##"),10,TipoAlineacion.DERECHA,false)+
                                completaHasta(Generales.getFormatoDecimal(noDisponible, "#.##"),10,TipoAlineacion.DERECHA,false);

                        texto2 = completaHasta(ValoresReferencia.getDescripcion("UNIDADV", inventario.getString("PRUTipoUnidad")),TipoImpresora == TipoPapel.INTERMEC_PR3?34:col*2,TipoAlineacion.DERECHA,false)+
                                completaHasta(Generales.getFormatoDecimal(existencia, "#.##"),TipoImpresora == TipoPapel.INTERMEC_PR3?7:col,TipoAlineacion.DERECHA,false)+
                                completaHasta(Generales.getFormatoDecimal(disponible, "#.##"),TipoImpresora == TipoPapel.INTERMEC_PR3?7:col,TipoAlineacion.DERECHA,false)+
                                completaHasta(Generales.getFormatoDecimal(noDisponible, "#.##"),TipoImpresora == TipoPapel.INTERMEC_PR3?7:col,TipoAlineacion.DERECHA,false);
                    } else {

                        existencia = Integer.parseInt(inventario.getString("Exis"))>0?(Integer.parseInt(inventario.getString("Exis"))/factor):0;
                        disponible = Integer.parseInt(inventario.getString("Disp"))>0?(Integer.parseInt(inventario.getString("Disp"))/factor):0;
                        noDisponible = Integer.parseInt(inventario.getString("No D"))>0?(Integer.parseInt(inventario.getString("No D"))/factor):0;

                        existenciaRestante = Integer.parseInt(inventario.getString("Exis"))>0?(Integer.parseInt(inventario.getString("Exis"))%factor):0;
                        disponibleRestante = Integer.parseInt(inventario.getString("Disp"))>0?(Integer.parseInt(inventario.getString("Disp"))%factor):0;
                        noDisponibleRestante = Integer.parseInt(inventario.getString("No D"))>0?(Integer.parseInt(inventario.getString("No D"))%factor):0;

                        texto = completaHasta(inventario.getString("ProductoClave")+"-"+inventario.getString("Nombre"),20,TipoAlineacion.IZQUIERDA,false)+
                                completaHasta(Generales.getFormatoDecimal(Integer.parseInt(inventario.getString("Exis")), "#.##"),10,TipoAlineacion.DERECHA,false)+
                                completaHasta(Generales.getFormatoDecimal(Integer.parseInt(inventario.getString("Disp")),"#.##"), 10, TipoAlineacion.DERECHA, false) +
                                completaHasta(Generales.getFormatoDecimal(Integer.parseInt(inventario.getString("No D")),"#.##"), 10, TipoAlineacion.DERECHA, false);
                        texto += "\r\n";
                        texto += completaHasta(ValoresReferencia.getDescripcion("UNIDADV", inventario.getString("PRUTipoUnidad")),20,TipoAlineacion.DERECHA,false)+
                                completaHasta(Generales.getFormatoDecimal(existencia, "#.##"),10,TipoAlineacion.DERECHA,false)+
                                completaHasta(Generales.getFormatoDecimal(disponible, "#.##"),10,TipoAlineacion.DERECHA,false)+
                                completaHasta(Generales.getFormatoDecimal(noDisponible, "#.##"),10,TipoAlineacion.DERECHA,false);

                        texto2 = completaHasta(inventario.getString("ProductoClave")+"-"+inventario.getString("Nombre"),TipoImpresora == TipoPapel.INTERMEC_PR3?34:col*2,TipoAlineacion.IZQUIERDA,false)+
                                completaHasta(Generales.getFormatoDecimal(Integer.parseInt(inventario.getString("Exis")), "#.##"),TipoImpresora == TipoPapel.INTERMEC_PR3?7:col,TipoAlineacion.DERECHA,false)+
                                completaHasta(Generales.getFormatoDecimal(Integer.parseInt(inventario.getString("Disp")),"#.##"), TipoImpresora == TipoPapel.INTERMEC_PR3?7:col, TipoAlineacion.DERECHA, false) +
                                completaHasta(Generales.getFormatoDecimal(Integer.parseInt(inventario.getString("No D")),"#.##"), TipoImpresora == TipoPapel.INTERMEC_PR3?7:col, TipoAlineacion.DERECHA, false);
                        texto2 += "\r\n";
                        texto2 += completaHasta(ValoresReferencia.getDescripcion("UNIDADV", inventario.getString("PRUTipoUnidad")),TipoImpresora == TipoPapel.INTERMEC_PR3?34:col*2,TipoAlineacion.DERECHA,false)+
                                completaHasta(Generales.getFormatoDecimal(existencia, "#.##"),TipoImpresora == TipoPapel.INTERMEC_PR3?7:col,TipoAlineacion.DERECHA,false)+
                                completaHasta(Generales.getFormatoDecimal(disponible, "#.##"),TipoImpresora == TipoPapel.INTERMEC_PR3?7:col,TipoAlineacion.DERECHA,false)+
                                completaHasta(Generales.getFormatoDecimal(noDisponible, "#.##"),TipoImpresora == TipoPapel.INTERMEC_PR3?7:col,TipoAlineacion.DERECHA,false);


                    }

                    if(inventario.getString("Precio") != null ) {

                        if(productoClaveAnterior == null && productoFactorAnterior == null)
                            totalUnidad += (inventario.getDouble("Precio") * existencia);
                        else if( !productoClaveAnterior.equals(inventario.getString("ProductoClave")) || !productoFactorAnterior.equals(inventario.getString("Factor")) )
                            totalUnidad += (inventario.getDouble("Precio") * existencia);

                    }


                    cadena = alineaTexto(BTIPALI.TipoAlineacion.IZQUIERDA,texto2,max);

                    cadenaRecibo.append(cadena + "\r\n");

                    row = new Paragraph(texto, Recibos.textoNegrita);
                    row.setAlignment(Element.ALIGN_CENTER);
                    reportePDF.add(row);

                    productoClaveAnterior = inventario.getString("ProductoClave");
                    productoFactorAnterior = inventario.getString("Factor");
                }


            }

            cadenaRecibo.append("\r\n");
            reportePDF.add(new Paragraph(" "));
            cadenaRecibo.append("\r\n");
            reportePDF.add(new Paragraph(" "));

            if(totalizar){

                int totalProductosExis = 0;
                int totalProductosDisp = 0;
                int totalProductosNoD = 0;

                ISetDatos totalProductos = Consultas.ConsultasTransProd.obtenerInventarioTotalProductos(subEmpresas.getString("SubEmpresaId"));
                totalProductos.moveToNext();

                totalProductosExis = totalProductos.getInt("Exis");
                totalProductosDisp = totalProductos.getInt("Disp");
                totalProductosNoD = totalProductos.getInt("No D");

                texto = completaHasta("Total de Productos",20,TipoAlineacion.DERECHA,false)+
                        completaHasta(Generales.getFormatoDecimal(totalProductosExis, "#.##"),10,TipoAlineacion.DERECHA,false)+
                        completaHasta(Generales.getFormatoDecimal(totalProductosDisp, "#.##"),10,TipoAlineacion.DERECHA,false)+
                        completaHasta(Generales.getFormatoDecimal(totalProductosNoD, "#.##"),10,TipoAlineacion.DERECHA,false);

                texto2 = completaHasta("Total de Productos",TipoImpresora == TipoPapel.INTERMEC_PR3?34:col*2,TipoAlineacion.DERECHA,false)+
                        completaHasta(Generales.getFormatoDecimal(totalProductosExis, "#.##"),TipoImpresora == TipoPapel.INTERMEC_PR3?7:col,TipoAlineacion.DERECHA,false)+
                        completaHasta(Generales.getFormatoDecimal(totalProductosDisp, "#.##"),TipoImpresora == TipoPapel.INTERMEC_PR3?7:col,TipoAlineacion.DERECHA,false)+
                        completaHasta(Generales.getFormatoDecimal(totalProductosNoD, "#.##"),TipoImpresora == TipoPapel.INTERMEC_PR3?7:col,TipoAlineacion.DERECHA,false);

                cadena = alineaTexto(BTIPALI.TipoAlineacion.IZQUIERDA, texto2, max);

                cadenaRecibo.append(cadena + "\r\n");

                Paragraph totalProductosP = new Paragraph(texto, Recibos.textoNegrita);
                totalProductosP.setAlignment(Element.ALIGN_CENTER);
                reportePDF.add(totalProductosP);


                double totalUnitario = 0;
                String productoClaveAnterior = null;

                ISetDatos totalUnitarioDatos = Consultas.ConsultasTransProd.obtenerInventarioTotalUnitario(subEmpresas.getString("SubEmpresaId"));
                while (totalUnitarioDatos.moveToNext()) {

                    if(productoClaveAnterior == null)
                        totalUnitario += totalUnitarioDatos.getDouble("Precio")*(totalUnitarioDatos.getDouble("Disponible")*totalUnitarioDatos.getDouble("Factor"));
                    else {
                        if(!productoClaveAnterior.equals(totalUnitarioDatos.getString("ProductoClave")))
                            totalUnitario += totalUnitarioDatos.getDouble("Precio")*(totalUnitarioDatos.getDouble("Disponible")*totalUnitarioDatos.getDouble("Factor"));
                    }

                    productoClaveAnterior = totalUnitarioDatos.getString("ProductoClave");
                }

                texto = completaHasta(Mensajes.get("XTotalUnitario"),20,TipoAlineacion.DERECHA,false)+
                        completaHasta(Generales.getFormatoDecimal(totalUnitario, "#.##"),30,TipoAlineacion.DERECHA,false);

                texto2 = completaHasta(Mensajes.get("XTotalUnitario"),TipoImpresora == TipoPapel.INTERMEC_PR3?34:col*2,TipoAlineacion.DERECHA,false)+
                        completaHasta(Generales.getFormatoDecimal(totalUnitario, "#.##"),TipoImpresora == TipoPapel.INTERMEC_PR3?21:col*3,TipoAlineacion.DERECHA,false);

                cadena = alineaTexto(BTIPALI.TipoAlineacion.IZQUIERDA, texto2, max);

                cadenaRecibo.append(cadena + "\r\n");

                Paragraph totalUnitarioP = new Paragraph(texto, Recibos.textoNegrita);
                totalUnitarioP.setAlignment(Element.ALIGN_CENTER);
                reportePDF.add(totalUnitarioP);

                /*if(!general){

                    texto = completaHasta(Mensajes.get("XTotalUnidad"),20,TipoAlineacion.DERECHA,false)+
                            completaHasta(Generales.getFormatoDecimal(totalUnidad, 2),30,TipoAlineacion.DERECHA,false);

                    texto2 = completaHasta(Mensajes.get("XTotalUnidad"),col*2,TipoAlineacion.DERECHA,false)+
                            completaHasta(Generales.getFormatoDecimal(totalUnidad, 2),col*3,TipoAlineacion.DERECHA,false);

                    cadena = alineaTexto(BTIPALI.TipoAlineacion.IZQUIERDA, texto2, max);

                    cadenaRecibo.append(cadena + "\r\n");

                    Paragraph totalUnidadP = new Paragraph(texto, Recibos.textoNegrita);
                    totalUnidadP.setAlignment(Element.ALIGN_CENTER);
                    reportePDF.add(totalUnidadP);

                }*/
            }
        }

        cadenaRecibo.append("\r\n");
        cadenaRecibo.append("\r\n");
        cadenaRecibo.append("\r\n");
        cadenaRecibo.append("\r\n");
        cadenaRecibo.append("\r\n");
        cadenaRecibo.append("\r\n");

        document.add(reportePDF);

    }
    private static void generarReporteCobranzaGenerico(int reporte, StringBuilder cadenaRecibo, Document document) throws Exception{

        String cadena = "";
        String cadena2 = "";
        String texto = "";
        String texto2 = "";
        int columna = 10;
        int max = 38;
        int max2 = 38;

        int mostrarCedi = Integer.parseInt(((CONHist) Sesion.get(Campo.CONHist)).get("MostrarCEDI").toString());

        Paragraph reportePDF = new Paragraph();
        reportePDF.setFont(textoNegrita); //letra general para el reporte

        setTamanioDefault(((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp);
        TamanioLetra tamanioLetra;
        tamanioLetra = tamanioDefault;



        if (((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.ZEBRA_TERMICA2 || ((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.ZEBRA_CAMEO2) {
            cadena = "{" + tamanioLetra.mTamanio + " " + tamanioLetra.mAlto + "}";
        } else if (((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.INTERMEC_PR2 || ((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.INTERMEC_PR3) {
            //Se usa el mAlto para indentificar si la letra es normal o doble 0= normal 1= doble
            //En la cadena de los bytes no se debe dejar espacios, si no falla y se consideran hasta el momento
            //3 bytes en el mensaje, por lo que si se mete menos o mas, hay que cambiar el codigo en BluetoothPrint
            if (tamanioLetra.mAlto != 0) {
                cadena = "{27,33," + tamanioLetra.mTamanio + "}";
            }
            else
            {
                cadena = "{27,119," + tamanioLetra.mTamanio + "}";
            }
        }   else if( ((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.ZEBRA_TERMICA3 ) {
            cadena = "! U1 SETLP 7 " + tamanioLetra.mTamanio + " " + tamanioLetra.mAlto + " ";
        }
        else
        {
            cadena = "{" + tamanioLetra.mTamanio + "}";
            if (((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.SEWOO) {
                max2 = 32;
            }
        }

        if(mostrarCedi == 0){

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

            Paragraph rfc = new Paragraph(texto, textoNegrita);
            rfc.setAlignment(Element.ALIGN_CENTER);
            reportePDF.add(rfc);

            texto = encabezado.getString("Calle") + " " + encabezado.getString("Numero") + ", "+ Mensajes.get("XCol")+ " " + encabezado.getString("Colonia")+",";
            cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, tamanioLetra.mLongTotal);
            cadenaRecibo.append(cadena + "\r\n");

            Paragraph domicilio = new Paragraph(texto, textoNegrita);
            domicilio.setAlignment(Element.ALIGN_CENTER);
            reportePDF.add(domicilio);

            texto = encabezado.getString("Ciudad") + ", " + encabezado.getString("Region");
            cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, tamanioLetra.mLongTotal);
            cadenaRecibo.append(cadena + "\r\n");

            Paragraph ciudad = new Paragraph(texto, textoNegrita);
            ciudad.setAlignment(Element.ALIGN_CENTER);
            reportePDF.add(ciudad);

            texto = encabezado.getString("Telefono");
            cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, tamanioLetra.mLongTotal);
            cadenaRecibo.append(cadena + "\r\n");

            Paragraph telefono = new Paragraph(texto, textoNegrita);
            telefono.setAlignment(Element.ALIGN_CENTER);
            reportePDF.add(telefono);

            cadenaRecibo.append("\r\n");
            reportePDF.add(new Paragraph(" ")); //linea en blanco = \r\n
            encabezado.close();

        } else {

            ISetDatos encabezado = Consultas.ConsultasTransProd.obtenerAlmacen();
            encabezado.moveToFirst();

            texto = encabezado.getString("Nombre");
            cadena = cadena + alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, tamanioLetra.mLongTotal);
            cadenaRecibo.append(cadena + "\r\n");

            Paragraph nombre = new Paragraph(texto, textoNegrita);
            nombre.setAlignment(Element.ALIGN_CENTER);
            reportePDF.add(nombre);

            texto = encabezado.getString("Domicilio");
            cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, tamanioLetra.mLongTotal);
            cadenaRecibo.append(cadena + "\r\n");

            Paragraph domicilio = new Paragraph(texto, textoNegrita);
            domicilio.setAlignment(Element.ALIGN_CENTER);
            reportePDF.add(domicilio);

            texto = encabezado.getString("Telefono");
            cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, tamanioLetra.mLongTotal);
            cadenaRecibo.append(cadena + "\r\n");

            Paragraph telefono = new Paragraph(texto, textoNegrita);
            telefono.setAlignment(Element.ALIGN_CENTER);
            reportePDF.add(telefono);

            cadenaRecibo.append("\r\n");
            reportePDF.add(new Paragraph(" ")); //linea en blanco = \r\n
            encabezado.close();
        }



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

        texto = Mensajes.get("XVendedor") + ": " + ((Usuario) Sesion.get(Campo.UsuarioActual)).Nombre;
        cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, tamanioLetra.mLongTotal);
        cadenaRecibo.append(cadena + "\r\n");
        cadenaRecibo.append("\r\n");

        Paragraph ven = new Paragraph(texto, textoNegrita);
        ven.setAlignment(Element.ALIGN_CENTER);
        reportePDF.add(ven);

        reportePDF.add(new Paragraph(" "));

        //////COLUMNA

        texto = StringUtils.rightPad(Mensajes.get("XFolio"),14);
        texto += StringUtils.rightPad(Mensajes.get("XFechaAlta"), 14);
        texto += StringUtils.rightPad(Mensajes.get("XImporte"),14);
        texto += Mensajes.get("XSaldo");

        texto2 = Mensajes.get("XFolio") + "      ";
        texto2 += Mensajes.get("XFechaAlta") + "   ";
        texto2 += Mensajes.get("XImporte") + "   ";
        texto2 += Mensajes.get("XSaldo");


        cadena = alineaTexto(BTIPALI.TipoAlineacion.IZQUIERDA, texto2, tamanioLetra.mLongTotal);
        cadenaRecibo.append(cadena + "\r\n");

        Paragraph encabezadoFolio = new Paragraph(texto, textoNegrita);
        encabezadoFolio.setAlignment(Element.ALIGN_LEFT);
        reportePDF.add(encabezadoFolio);

        imprimeLineaPunteada(cadenaRecibo, tamanioLetra.mLongTotal);

        ArrayList<Cliente> clientes = (ArrayList<Cliente>) Sesion.get(Campo.FiltroReporteCliente);
        ArrayList<Cliente> clientesSeleccionados = new ArrayList<>();
        for(Cliente cliente : clientes){
            if(cliente.Enviado)
                clientesSeleccionados.add(cliente);
        }

        double granTotal = 0;
        ISetDatos cobranzaCliente;

        String folio;
        String fecha;
        String importe;
        String saldo;

        SimpleDateFormat inputDate = new SimpleDateFormat("yyyy-MM-dd");
        SimpleDateFormat outputDate = new SimpleDateFormat("dd/MM/yyyy");

        for(Cliente cliente : clientesSeleccionados){

            boolean primeraIteracion = true;
            boolean hayCobranza = false;
            double totalSaldo = 0;
            cobranzaCliente = Consultas.ConsultasTransProd.obtenerCobranzaPorCliente(cliente.ClienteClave);

            while (cobranzaCliente.moveToNext()){

                if(primeraIteracion){
                    primeraIteracion = false;
                    texto = StringUtils.rightPad(cobranzaCliente.getString("Clave"),14) + cobranzaCliente.getString("NombreCorto");
                    texto2 = StringUtils.rightPad(cobranzaCliente.getString("Clave"),cobranzaCliente.getString("Clave").length()+2) + cobranzaCliente.getString("NombreCorto");

                    cadena = alineaTexto(BTIPALI.TipoAlineacion.IZQUIERDA, texto2, tamanioLetra.mLongTotal);
                    cadenaRecibo.append(cadena + "\r\n");
                    cadenaRecibo.append("\r\n");

                    Paragraph datosCliente = new Paragraph(texto, textoNegrita);
                    datosCliente.setAlignment(Element.ALIGN_LEFT);
                    reportePDF.add(datosCliente);
                    reportePDF.add(new Paragraph(" "));
                }

                folio = cobranzaCliente.getString("Folio");
                fecha = outputDate.format(inputDate.parse(cobranzaCliente.getString("FechaCaptura").split(" ")[0]));
                importe = "$"+cobranzaCliente.getString("Importe");
                saldo = "$"+Generales.getFormatoDecimal(Double.parseDouble(cobranzaCliente.getString("Saldo")), 2);


                texto = StringUtils.rightPad(folio,14) + StringUtils.rightPad(fecha,14) +
                        StringUtils.rightPad(importe,14) +  saldo;

                texto2 = folio + "  " + fecha +  "  " +
                        importe + "  " + saldo;

                cadena = alineaTexto(BTIPALI.TipoAlineacion.IZQUIERDA, texto2, tamanioLetra.mLongTotal);
                cadenaRecibo.append(cadena + "\r\n");

                Paragraph cobranzaRow = new Paragraph(texto, textoNegrita);
                cobranzaRow.setAlignment(Element.ALIGN_LEFT);
                reportePDF.add(cobranzaRow);

                totalSaldo += Double.parseDouble(cobranzaCliente.getString("Saldo"));
                hayCobranza = true;
            }

            if(hayCobranza){

                cobranzaCliente.close();
                texto =StringUtils.leftPad("",28) + StringUtils.rightPad(Mensajes.get("XTotalSaldo"),14) + "$"+Generales.getFormatoDecimal(totalSaldo, 2);

                texto2 = Mensajes.get("XTotalSaldo") + StringUtils.leftPad("$"+Generales.getFormatoDecimal(totalSaldo,2),8);

                cadena = alineaTexto(BTIPALI.TipoAlineacion.DERECHA, texto2, tamanioLetra.mLongTotal);
                cadenaRecibo.append(cadena + "\r\n");

                Paragraph totalSaldoP = new Paragraph(texto, textoNegrita);
                totalSaldoP.setAlignment(Element.ALIGN_LEFT);
                reportePDF.add(totalSaldoP);

                reportePDF.add(new Paragraph(" "));

                granTotal += totalSaldo;
            }

        }

        imprimeLineaPunteada(cadenaRecibo, tamanioLetra.mLongTotal);
        texto = StringUtils.leftPad("",28) + StringUtils.rightPad(Mensajes.get("XGRANTOTAL"),14) + "$"+Generales.getFormatoDecimal(granTotal,2);

        texto2 =  Mensajes.get("XGRANTOTAL") + StringUtils.leftPad("$" + Generales.getFormatoDecimal(granTotal,2),8);

        cadena = alineaTexto(BTIPALI.TipoAlineacion.DERECHA, texto2, tamanioLetra.mLongTotal);
        cadenaRecibo.append(cadena + "\r\n");

        Paragraph granTotalP = new Paragraph(texto, textoNegrita);
        granTotalP.setAlignment(Element.ALIGN_LEFT);
        reportePDF.add(granTotalP);

        document.add(reportePDF);

    }
    private static void generarReporteEfectividadRuta(int reporte, StringBuilder cadenaRecibo, Document document) throws Exception {

        String cadena = "";
        String cadena2 = "";
        String texto = "";
        String texto2 = "";
        int columna = 10;
        int max = 38;
        int max2 = 38;
        int maxPDF = 50;

        short TipoImpresora=((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp;

        String diaClave = Sesion.get(Campo.FiltroReporteDiaClave).toString();


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



        if (((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.ZEBRA_TERMICA2 || ((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.ZEBRA_CAMEO2) {
            cadena = "{" + tamanioLetra.mTamanio + " " + tamanioLetra.mAlto + "}";
        } else if (((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.INTERMEC_PR2 || ((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.INTERMEC_PR3) {
            //Se usa el mAlto para indentificar si la letra es normal o doble 0= normal 1= doble
            //En la cadena de los bytes no se debe dejar espacios, si no falla y se consideran hasta el momento
            //3 bytes en el mensaje, por lo que si se mete menos o mas, hay que cambiar el codigo en BluetoothPrint
            if (tamanioLetra.mAlto != 0) {
                cadena = "{27,33," + tamanioLetra.mTamanio + "}";
            }
            else
            {
                cadena = "{27,119," + tamanioLetra.mTamanio + "}";
            }
        } else if( ((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.ZEBRA_TERMICA3 ) {
            cadena = "! U1 SETLP 7 " + tamanioLetra.mTamanio + " " + tamanioLetra.mAlto + " ";
        }
        else
        {
            cadena = "{" + tamanioLetra.mTamanio + "}";
            if (((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.SEWOO) {
                max2 = 32;
            }
        }

        max = tamanioLetra.mLongTotal;

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

        Paragraph rfc = new Paragraph(texto, textoNegrita);
        rfc.setAlignment(Element.ALIGN_CENTER);
        reportePDF.add(rfc);

        texto = encabezado.getString("Calle") + " " + encabezado.getString("Numero") + ", "+ Mensajes.get("XCol")+ " " + encabezado.getString("Colonia")+",";
        cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, tamanioLetra.mLongTotal);
        cadenaRecibo.append(cadena + "\r\n");

        Paragraph domicilio = new Paragraph(texto, textoNegrita);
        domicilio.setAlignment(Element.ALIGN_CENTER);
        reportePDF.add(domicilio);

        texto = encabezado.getString("Ciudad") + ", " + encabezado.getString("Region");
        cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, tamanioLetra.mLongTotal);
        cadenaRecibo.append(cadena + "\r\n");

        Paragraph ciudad = new Paragraph(texto, textoNegrita);
        ciudad.setAlignment(Element.ALIGN_CENTER);
        reportePDF.add(ciudad);

        cadenaRecibo.append("\r\n");
        reportePDF.add(new Paragraph(" ")); //linea en blanco = \r\n
        encabezado.close();

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

        texto = Mensajes.get("XVendedor") + ": " + ((Usuario) Sesion.get(Campo.UsuarioActual)).Nombre;
        cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, tamanioLetra.mLongTotal);
        cadenaRecibo.append(cadena + "\r\n");

        Paragraph ven = new Paragraph(texto, textoNegrita);
        ven.setAlignment(Element.ALIGN_CENTER);
        reportePDF.add(ven);

        imprimeLineaPunteada(cadenaRecibo, tamanioLetra.mLongTotal);

        reportePDF.add(new Paragraph(" "));
        texto = Mensajes.get("XRuta") + ": " + ruta.RUTClave;
        cadena = alineaTexto(BTIPALI.TipoAlineacion.IZQUIERDA, texto, tamanioLetra.mLongTotal);
        cadenaRecibo.append(cadena + "\r\n");
        cadenaRecibo.append("\r\n");

        Paragraph rut = new Paragraph(texto, textoNegrita);
        rut.setAlignment(Element.ALIGN_LEFT);
        reportePDF.add(rut);
        reportePDF.add(new Paragraph(" ")); //linea en blanco = \r\n


        cadena = Mensajes.get("XCliente");
        cadena2 = Mensajes.get("XEncuesta");
        texto = completaHasta(cadena2, (maxPDF - cadena.length()), TipoAlineacion.DERECHA, true);
        texto2 = completaHasta(cadena2, TipoImpresora == TipoPapel.INTERMEC_PR3?(55-cadena.length()):(max - cadena.length()), TipoAlineacion.DERECHA, true);

        cadenaRecibo.append(cadena + texto2 + "\r\n");
        cadenaRecibo.append("\r\n");

        reportePDF.add(cadena + texto);

        imprimeLineaPunteada(cadenaRecibo, tamanioLetra.mLongTotal);

        ISetDatos clientes = Consultas.ConsultasTransProd.obtenerClientesEnAgenda(ruta.RUTClave,diaClave);
        while(clientes.moveToNext()){

            cadena = clientes.getString(0).toString();
            cadena2 = clientes.getString(1).toString();
            texto = completaHasta(cadena, maxPDF - cadena2.length(), TipoAlineacion.IZQUIERDA, true);
            texto2 = completaHasta(cadena, TipoImpresora == TipoPapel.INTERMEC_PR3?(55-cadena2.length()):(max  - cadena2.length()) , TipoAlineacion.IZQUIERDA, true);

            cadenaRecibo.append(texto2 + completaHasta(cadena2,4,TipoAlineacion.DERECHA,true) + "\r\n");
            cadenaRecibo.append("\r\n");

            Paragraph cliente = new Paragraph(texto + completaHasta(cadena2,2,TipoAlineacion.DERECHA,true), textoNegrita);
            cliente.setAlignment(Element.ALIGN_LEFT);
            reportePDF.add(cliente);

        }
        clientes.close();
        reportePDF.add(new Paragraph(" "));
        reportePDF.add(new Paragraph(" "));

        imprimeLineaPunteada(cadenaRecibo, tamanioLetra.mLongTotal);

        cadena = StringUtils.rightPad(Mensajes.get("XCant."), 10);
        cadena+= Mensajes.get("XPorcent.");

        cadenaRecibo.append(StringUtils.leftPad(cadena, max) + "\r\n");
        cadenaRecibo.append("\r\n");

        imprimeLineaPunteada(cadenaRecibo, tamanioLetra.mLongTotal);

        Paragraph encabezado2 = new Paragraph(cadena, textoNegrita);
        encabezado2.setAlignment(Element.ALIGN_RIGHT);
        reportePDF.add(encabezado2);

        reportePDF.add(new Paragraph(" "));

        texto = Mensajes.get("XClienteAgenda");
        cadena = StringUtils.center(Mensajes.get("XClienteAgenda"),max);
        cadenaRecibo.append(cadena + "\r\n");

        Paragraph encabezadoClientesAgenda = new Paragraph(texto,textoNegrita);
        encabezadoClientesAgenda.setAlignment(Element.ALIGN_CENTER);
        reportePDF.add(encabezadoClientesAgenda);

        reportePDF.add(new Paragraph(" "));


        //VISITAS
        ISetDatos clientesVisitados = Consultas.ConsultasTransProd.obtenerConteoVisitadosEnFrecuencia(ruta.RUTClave,diaClave);
        clientesVisitados.moveToNext();
        ISetDatos clientesNoVisitados = Consultas.ConsultasTransProd.obtenerConteoNoVisitadosEnFrecuencia(ruta.RUTClave, diaClave);
        clientesNoVisitados.moveToNext();

        String clientesVisitadosString =clientesVisitados.getString(0);
        String clientesNoVisitadosString =clientesNoVisitados.getString(0);
        int totalClientes = Integer.parseInt(clientesVisitadosString) + Integer.parseInt(clientesNoVisitadosString);

        cadena = StringUtils.rightPad(clientesVisitadosString, 9);
        cadena+= StringUtils.leftPad( (totalClientes != 0 ? Generales.getFormatoDecimal( ((Double.parseDouble(clientesVisitadosString) * 100) / totalClientes),"#.##") : "0") + "%", 7);
        texto = Mensajes.get("XVisitados") + StringUtils.leftPad(cadena,maxPDF - Mensajes.get("XVisitados").length());
        texto2 = Mensajes.get("XVisitados") + StringUtils.leftPad(cadena,max - Mensajes.get("XVisitados").length());

        cadenaRecibo.append(texto2 + "\r\n");

        Paragraph clientesVisitadosP = new Paragraph(texto,textoNegrita);
        clientesVisitadosP.setAlignment(Element.ALIGN_RIGHT);
        reportePDF.add(clientesVisitadosP);

        cadena = StringUtils.rightPad(clientesNoVisitadosString, 9);
        cadena+= StringUtils.leftPad( (totalClientes != 0 ? Generales.getFormatoDecimal( ((Double.parseDouble(clientesNoVisitadosString) * 100) / totalClientes),"#.##") : "0") + "%", 7);
        texto = Mensajes.get("XNoVisitados") + StringUtils.leftPad(cadena,maxPDF - Mensajes.get("XNoVisitados").length() );
        texto2 = Mensajes.get("XNoVisitados") + StringUtils.leftPad(cadena,max - Mensajes.get("XNoVisitados").length() );

        cadenaRecibo.append(texto2 + "\r\n");

        Paragraph clientesNoVisitadosP = new Paragraph(texto,textoNegrita);
        clientesNoVisitadosP.setAlignment(Element.ALIGN_RIGHT);
        reportePDF.add(clientesNoVisitadosP);


        cadena = StringUtils.rightPad(Integer.toString(totalClientes), 9);
        cadena+= StringUtils.leftPad("", 7);
        texto = Mensajes.get("XClientesTotal") + StringUtils.leftPad(cadena,maxPDF - Mensajes.get("XClientesTotal").length());
        texto2 = Mensajes.get("XClientesTotal") + StringUtils.leftPad(cadena,max - Mensajes.get("XClientesTotal").length());

        cadenaRecibo.append(texto2 + "\r\n");

        Paragraph totalClientesP = new Paragraph(texto,textoNegrita);
        totalClientesP.setAlignment(Element.ALIGN_RIGHT);
        reportePDF.add(totalClientesP);

        reportePDF.add(new Paragraph(" "));
        reportePDF.add(new Paragraph(" "));
        imprimeLineaPunteada(cadenaRecibo, tamanioLetra.mLongTotal);

        //////VISITAS VENTA
        ISetDatos clientesVisitadosConVenta = Consultas.ConsultasTransProd.obtenerConteoVisitadosConVenta(ruta.RUTClave,diaClave);
        clientesVisitadosConVenta.moveToNext();
        ISetDatos clientesVisitadosSinVenta = Consultas.ConsultasTransProd.obtenerConteoVisitadosSinVenta(ruta.RUTClave,diaClave);
        clientesVisitadosSinVenta.moveToNext();

        String clientesVisitadosVentaString =clientesVisitadosConVenta.getString(0);
        String clientesVisitadosSinVentaString =clientesVisitadosSinVenta.getString(0);
        int totalVisitados = Integer.parseInt(clientesVisitadosVentaString) + Integer.parseInt(clientesVisitadosSinVentaString);

        cadena = StringUtils.rightPad(clientesVisitadosVentaString, 9);
        cadena+= StringUtils.leftPad( (totalVisitados!=0?Generales.getFormatoDecimal( ((Double.parseDouble(clientesVisitadosVentaString) * 100) / totalVisitados),"#.##"):"0")+"%",7);
        texto = Mensajes.get("XVisitadosconVenta") + StringUtils.leftPad(cadena,maxPDF - Mensajes.get("XVisitadosconVenta").length());
        texto2 = Mensajes.get("XVisitadosconVenta") + StringUtils.leftPad(cadena,max - Mensajes.get("XVisitadosconVenta").length());

        cadenaRecibo.append(texto2 + "\r\n");

        Paragraph clientesVisitadosVentaP = new Paragraph(texto,textoNegrita);
        clientesVisitadosVentaP.setAlignment(Element.ALIGN_RIGHT);
        reportePDF.add(clientesVisitadosVentaP);

        cadena = StringUtils.rightPad(clientesVisitadosSinVentaString, 9);
        cadena+= StringUtils.leftPad( (totalVisitados != 0 ? Generales.getFormatoDecimal( ((Double.parseDouble(clientesVisitadosSinVentaString) * 100) / totalVisitados),"#.##") : "0") + "%",7);
        texto = Mensajes.get("XVisitadossinVenta") + StringUtils.leftPad(cadena,maxPDF - Mensajes.get("XVisitadossinVenta").length());
        texto2 = Mensajes.get("XVisitadossinVenta") + StringUtils.leftPad(cadena,max - Mensajes.get("XVisitadossinVenta").length());

        cadenaRecibo.append(texto2 + "\r\n");

        Paragraph clientesVisitadosSinVentaP = new Paragraph(texto,textoNegrita);
        clientesVisitadosSinVentaP.setAlignment(Element.ALIGN_RIGHT);
        reportePDF.add(clientesVisitadosSinVentaP);
        reportePDF.add(new Paragraph(" "));
        reportePDF.add(new Paragraph(" "));

        imprimeLineaPunteada(cadenaRecibo, tamanioLetra.mLongTotal);

        /////////ENCUESTAS
        ISetDatos encuestasAplicadas = Consultas.ConsultasTransProd.obtenerEncuestasAplicadas(ruta.RUTClave, diaClave);
        encuestasAplicadas.moveToNext();
        ISetDatos encuestasNoAplicadas = Consultas.ConsultasTransProd.obtenerEncuestasNoAplicadas(ruta.RUTClave, diaClave);
        encuestasNoAplicadas.moveToNext();

        String encuestasAplicadasString =encuestasAplicadas.getString(0);
        String encuestasNoAplicadasString =encuestasNoAplicadas.getString(0);
        int totalEncuestas = Integer.parseInt(encuestasAplicadasString) + Integer.parseInt(encuestasNoAplicadasString);

        cadena = StringUtils.rightPad(encuestasAplicadasString, 9);
        cadena+= StringUtils.leftPad( (totalEncuestas!=0?Generales.getFormatoDecimal( ((Double.parseDouble(encuestasAplicadasString) * 100) / totalEncuestas),"#.##"):"0")+"%",7);
        texto = Mensajes.get("XEncuestasAplicadas") + StringUtils.leftPad(cadena,maxPDF - Mensajes.get("XEncuestasAplicadas").length());
        texto2 = Mensajes.get("XEncuestasAplicadas") + StringUtils.leftPad(cadena,max - Mensajes.get("XEncuestasAplicadas").length());

        cadenaRecibo.append(texto2 + "\r\n");

        Paragraph encuestasAplicadasP = new Paragraph(texto,textoNegrita);
        encuestasAplicadasP.setAlignment(Element.ALIGN_RIGHT);
        reportePDF.add(encuestasAplicadasP);

        cadena = StringUtils.rightPad(encuestasNoAplicadasString, 9);
        cadena+= StringUtils.leftPad( (totalEncuestas!=0?Generales.getFormatoDecimal( ((Double.parseDouble(encuestasNoAplicadasString) * 100) / totalEncuestas),"#.##"):"0")+"%",7);
        texto = Mensajes.get("XEncuestasNoAplicadas") + StringUtils.leftPad(cadena,maxPDF - Mensajes.get("XEncuestasNoAplicadas").length());
        texto2 = Mensajes.get("XEncuestasNoAplicadas") + StringUtils.leftPad(cadena,max - Mensajes.get("XEncuestasNoAplicadas").length());

        cadenaRecibo.append(texto2 + "\r\n");

        Paragraph encuestasNoAplicadasP = new Paragraph(texto,textoNegrita);
        encuestasNoAplicadasP.setAlignment(Element.ALIGN_RIGHT);
        reportePDF.add(encuestasNoAplicadasP);

        cadena = StringUtils.rightPad(Integer.toString(totalEncuestas), 9);
        cadena+= StringUtils.leftPad("100%", 7);
        texto = Mensajes.get("XEncuestasTotal") + StringUtils.leftPad(cadena,maxPDF - Mensajes.get("XEncuestasTotal").length());
        texto2 = Mensajes.get("XEncuestasTotal") + StringUtils.leftPad(cadena,max - Mensajes.get("XEncuestasTotal").length());

        cadenaRecibo.append(texto2 + "\r\n");

        Paragraph totalEncuestasP = new Paragraph(texto,textoNegrita);
        totalEncuestasP.setAlignment(Element.ALIGN_RIGHT);
        reportePDF.add(totalEncuestasP);

        reportePDF.add(new Paragraph(" "));
        reportePDF.add(new Paragraph(" "));

        imprimeLineaPunteada(cadenaRecibo, tamanioLetra.mLongTotal);

        //CLIENTES ENCUESTADOS
        ISetDatos clientesEncuestados = Consultas.ConsultasTransProd.obtenerClientesEncuestados(ruta.RUTClave,diaClave);
        clientesEncuestados.moveToNext();
        ISetDatos clientesNoEncuestados = Consultas.ConsultasTransProd.obtenerClientesNoEncuestados(ruta.RUTClave,diaClave);
        clientesNoEncuestados.moveToNext();

        String clientesEncuestadosString =clientesEncuestados.getString(0);
        String clientesNoEncuestadosString =clientesNoEncuestados.getString(0);
        int totalClientesEncuestados = Integer.parseInt(clientesEncuestadosString) + Integer.parseInt(clientesNoEncuestadosString);

        cadena = StringUtils.rightPad(clientesEncuestadosString, 9);
        cadena+= StringUtils.leftPad( (totalClientesEncuestados!=0?Generales.getFormatoDecimal( ((Double.parseDouble(clientesEncuestadosString) * 100) / totalClientesEncuestados),"#.##"):"0")+"%",7);
        texto = Mensajes.get("XClientesEncuestados") + StringUtils.leftPad(cadena,maxPDF - Mensajes.get("XClientesEncuestados").length());
        texto2 = Mensajes.get("XClientesEncuestados") + StringUtils.leftPad(cadena,max - Mensajes.get("XClientesEncuestados").length());

        cadenaRecibo.append(texto2 + "\r\n");

        Paragraph clientesEncuestadosP = new Paragraph(texto,textoNegrita);
        clientesEncuestadosP.setAlignment(Element.ALIGN_RIGHT);
        reportePDF.add(clientesEncuestadosP);

        cadena = StringUtils.rightPad(clientesNoEncuestadosString, 9);
        cadena+= StringUtils.leftPad( (totalClientesEncuestados!=0?Generales.getFormatoDecimal( ((Double.parseDouble(clientesNoEncuestadosString) * 100) / totalClientesEncuestados),"#.##"):"0")+"%",7);
        texto = Mensajes.get("XClientesNoEncuestados") + StringUtils.leftPad(cadena,maxPDF - Mensajes.get("XClientesNoEncuestados").length());
        texto2 = Mensajes.get("XClientesNoEncuestados") + StringUtils.leftPad(cadena,max - Mensajes.get("XClientesNoEncuestados").length());

        cadenaRecibo.append(texto2 + "\r\n");

        Paragraph clientesNoEncuestadosP = new Paragraph(texto,textoNegrita);
        clientesNoEncuestadosP.setAlignment(Element.ALIGN_RIGHT);
        reportePDF.add(clientesNoEncuestadosP);


        cadena = StringUtils.rightPad(Integer.toString(totalClientesEncuestados), 9);
        cadena+= StringUtils.leftPad("100%", 7);
        texto = Mensajes.get("XClientesTotal") + StringUtils.leftPad(cadena,maxPDF - Mensajes.get("XClientesTotal").length());
        texto2 = Mensajes.get("XClientesTotal") + StringUtils.leftPad(cadena,max - Mensajes.get("XClientesTotal").length());

        cadenaRecibo.append(texto2 + "\r\n");

        Paragraph totalClientesEncuestadosP = new Paragraph(texto,textoNegrita);
        totalClientesEncuestadosP.setAlignment(Element.ALIGN_RIGHT);
        reportePDF.add(totalClientesEncuestadosP);

        reportePDF.add(new Paragraph(" "));
        reportePDF.add(new Paragraph(" "));

        imprimeLineaPunteada(cadenaRecibo, tamanioLetra.mLongTotal);

        /////////CODIGOS LEIDOS
        ISetDatos codigosLeidos = Consultas.ConsultasTransProd.obtenerCodigosLeidos(ruta.RUTClave,diaClave);
        codigosLeidos.moveToNext();
        ISetDatos codigosNoLeidos = Consultas.ConsultasTransProd.obtenerCodigosNoLeidos(ruta.RUTClave,diaClave);
        codigosNoLeidos.moveToNext();

        String codigosLeidosString =codigosLeidos.getString(0);
        String codigosNoLeidosString =codigosNoLeidos.getString(0);
        int totalCodigos = Integer.parseInt(codigosLeidosString) + Integer.parseInt(codigosNoLeidosString);

        cadena = StringUtils.rightPad(codigosLeidosString, 9);
        cadena+= StringUtils.leftPad( (totalCodigos!=0?Generales.getFormatoDecimal( ((Double.parseDouble(codigosLeidosString) * 100) / totalCodigos),"#.##"):"0")+"%",7);
        texto = "Código Barras Leídos" + StringUtils.leftPad(cadena,maxPDF - "Código Barras Leídos".length());
        texto2 = "Código Barras Leídos" + StringUtils.leftPad(cadena,max - "Código Barras Leídos".length());

        cadenaRecibo.append(texto2 + "\r\n");

        Paragraph codigosLeidosP = new Paragraph(texto,textoNegrita);
        codigosLeidosP.setAlignment(Element.ALIGN_RIGHT);
        reportePDF.add(codigosLeidosP);

        cadena = StringUtils.rightPad(codigosNoLeidosString, 9);
        cadena+= StringUtils.leftPad( (totalCodigos!=0?Generales.getFormatoDecimal( ((Double.parseDouble(codigosNoLeidosString) * 100) / totalCodigos),"#.##"):"0")+"%",7);
        texto = Mensajes.get("XClientesSeleccionados") + StringUtils.leftPad(cadena,maxPDF - Mensajes.get("XClientesSeleccionados").length());
        texto2 = Mensajes.get("XClientesSeleccionados") + StringUtils.leftPad(cadena,max - Mensajes.get("XClientesSeleccionados").length());

        cadenaRecibo.append(texto2 + "\r\n");

        Paragraph codigosNoLeidosP = new Paragraph(texto,textoNegrita);
        codigosNoLeidosP.setAlignment(Element.ALIGN_RIGHT);
        reportePDF.add(codigosNoLeidosP);

        cadena = StringUtils.rightPad(Integer.toString(totalCodigos), 9);
        cadena+= StringUtils.leftPad("", 7);
        texto2 = Mensajes.get("XClientesTotal") + StringUtils.leftPad(cadena,max - Mensajes.get("XClientesTotal").length());

        cadenaRecibo.append(texto2 + "\r\n");

        Paragraph totalCodigosP = new Paragraph(texto,textoNegrita);
        totalCodigosP.setAlignment(Element.ALIGN_RIGHT);
        reportePDF.add(totalCodigosP);

        reportePDF.add(new Paragraph(" "));
        reportePDF.add(new Paragraph(" "));

        imprimeLineaPunteada(cadenaRecibo, tamanioLetra.mLongTotal);

        //CLIENTES FUERA DE AGENDA

        texto = Mensajes.get("XClientesFueraAgenda");
        cadena = StringUtils.center(Mensajes.get("XClientesFueraAgenda"),max);
        cadenaRecibo.append(cadena + "\r\n");

        Paragraph encabezadoClientesFueraAgenda = new Paragraph(texto,textoNegrita);
        encabezadoClientesFueraAgenda.setAlignment(Element.ALIGN_CENTER);
        reportePDF.add(encabezadoClientesFueraAgenda);

        reportePDF.add(new Paragraph(" "));


        //VISITAS FUERA DE FRECUENCIA

        ISetDatos visitadosFueraFrecuencia = Consultas.ConsultasTransProd.obtenerConteoVisitadosNoFrecuencia(ruta.RUTClave,diaClave);
        visitadosFueraFrecuencia.moveToNext();
        ISetDatos visitadosVentaFueraFrecuencia = Consultas.ConsultasTransProd.obtenerConteoVisitadosConVentaFueraFrecuencia(ruta.RUTClave,diaClave);
        visitadosVentaFueraFrecuencia.moveToNext();
        ISetDatos visitadosSinVentaFueraFrecuencia = Consultas.ConsultasTransProd.obtenerConteoVisitadosSinVentaFueraFrecuencia(ruta.RUTClave,diaClave);
        visitadosSinVentaFueraFrecuencia.moveToNext();

        int visitadosFueraFrecuenciaTotal =Integer.parseInt(visitadosFueraFrecuencia.getString(0));
        String visitadosVentaFueraFrecuenciaString =visitadosVentaFueraFrecuencia.getString(0);
        String visitadosSinVentaFueraFrecuenciaString = visitadosSinVentaFueraFrecuencia.getString(0);

        cadena = StringUtils.rightPad(Integer.toString(visitadosFueraFrecuenciaTotal), 9);
        cadena+= StringUtils.leftPad("", 7);
        texto = Mensajes.get("XVisitados") + StringUtils.leftPad(cadena,maxPDF - Mensajes.get("XVisitados").length());
        texto2 = Mensajes.get("XVisitados") + StringUtils.leftPad(cadena,max - Mensajes.get("XVisitados").length());

        cadenaRecibo.append(texto2 + "\r\n");

        Paragraph visitadosFueraFrecuenciaP = new Paragraph(texto,textoNegrita);
        visitadosFueraFrecuenciaP.setAlignment(Element.ALIGN_RIGHT);
        reportePDF.add(visitadosFueraFrecuenciaP);


        cadena = StringUtils.rightPad(visitadosVentaFueraFrecuenciaString, 9);
        cadena+= StringUtils.leftPad( (visitadosFueraFrecuenciaTotal!=0?Generales.getFormatoDecimal( ((Double.parseDouble(visitadosVentaFueraFrecuenciaString) * 100) / visitadosFueraFrecuenciaTotal),"#.##"):"0")+"%",7);
        texto = Mensajes.get("XVisitadosconVenta") + StringUtils.leftPad(cadena,maxPDF - Mensajes.get("XVisitadosconVenta").length());
        texto2 = Mensajes.get("XVisitadosconVenta") + StringUtils.leftPad(cadena,max - Mensajes.get("XVisitadosconVenta").length());

        cadenaRecibo.append(texto2 + "\r\n");

        Paragraph visitadosVentaFueraFrecuenciaP = new Paragraph(texto,textoNegrita);
        visitadosVentaFueraFrecuenciaP.setAlignment(Element.ALIGN_RIGHT);
        reportePDF.add(visitadosVentaFueraFrecuenciaP);

        cadena = StringUtils.rightPad(visitadosSinVentaFueraFrecuenciaString, 9);
        cadena+= StringUtils.leftPad( ( visitadosFueraFrecuenciaTotal!=0?Generales.getFormatoDecimal( ((Double.parseDouble(visitadosSinVentaFueraFrecuenciaString) * 100) / visitadosFueraFrecuenciaTotal),"#.##"):"0")+"%",7);
        texto = Mensajes.get("XVisitadossinVenta") + StringUtils.leftPad(cadena,maxPDF - Mensajes.get("XVisitadossinVenta").length());
        texto2 = Mensajes.get("XVisitadossinVenta") + StringUtils.leftPad(cadena,max - Mensajes.get("XVisitadossinVenta").length());

        cadenaRecibo.append(texto2 + "\r\n");

        Paragraph visitadosSinVentaFueraFrecuenciaP = new Paragraph(texto,textoNegrita);
        visitadosSinVentaFueraFrecuenciaP.setAlignment(Element.ALIGN_RIGHT);
        reportePDF.add(visitadosSinVentaFueraFrecuenciaP);

        reportePDF.add(new Paragraph(" "));
        reportePDF.add(new Paragraph(" "));

        imprimeLineaPunteada(cadenaRecibo, tamanioLetra.mLongTotal);

        //ENCUESTAS FUERA DE FRECUENCIA

        ISetDatos encuestasAplicadasFueraFrecuencia = Consultas.ConsultasTransProd.obtenerEncuestasAplicadasFueraFrecuencia(ruta.RUTClave,diaClave);
        encuestasAplicadasFueraFrecuencia.moveToNext();
        ISetDatos clientesEncuestadosFueraFrecuencia = Consultas.ConsultasTransProd.obtenerClientesEncuestadosFueraFrecuencia(ruta.RUTClave,diaClave);
        clientesEncuestadosFueraFrecuencia.moveToNext();
        ISetDatos clientesNoEncuestadosFueraFrecuencia = Consultas.ConsultasTransProd.obtenerClientesNoEncuestadosFueraFrecuencia(ruta.RUTClave,diaClave);
        clientesNoEncuestadosFueraFrecuencia.moveToNext();

        String encuestasAplicadasFueraFrecuenciaString = encuestasAplicadasFueraFrecuencia.getString(0);
        String clientesEncuestadosFueraFrecuenciaString = clientesEncuestadosFueraFrecuencia.getString(0);
        String clientesNoEncuestadosFueraFrecuenciaString = clientesNoEncuestadosFueraFrecuencia.getString(0);
        int totalClientesEncuestadosFueraFrecuencia = Integer.parseInt(clientesEncuestadosFueraFrecuenciaString) + Integer.parseInt(clientesNoEncuestadosFueraFrecuenciaString) ;

        cadena = StringUtils.rightPad(encuestasAplicadasFueraFrecuenciaString, 9);
        cadena+= StringUtils.leftPad("", 7);
        texto = Mensajes.get("XEncuestasAplicadas") + StringUtils.leftPad(cadena,maxPDF - Mensajes.get("XEncuestasAplicadas").length());
        texto2 = Mensajes.get("XEncuestasAplicadas") + StringUtils.leftPad(cadena,max - Mensajes.get("XEncuestasAplicadas").length());

        cadenaRecibo.append(texto2 + "\r\n");

        Paragraph encuestasAplicadasFueraFrecuenciaP = new Paragraph(texto,textoNegrita);
        encuestasAplicadasFueraFrecuenciaP.setAlignment(Element.ALIGN_RIGHT);
        reportePDF.add(encuestasAplicadasFueraFrecuenciaP);


        cadena = StringUtils.rightPad(clientesEncuestadosFueraFrecuenciaString, 9);
        cadena+= StringUtils.leftPad( (totalClientesEncuestadosFueraFrecuencia != 0 ? Generales.getFormatoDecimal( ((Double.parseDouble(clientesEncuestadosFueraFrecuenciaString) * 100) / totalClientesEncuestadosFueraFrecuencia),"#.##") : "0") + "%", 7);
        texto = Mensajes.get("XClientesEncuestados") + StringUtils.leftPad(cadena,maxPDF - Mensajes.get("XClientesEncuestados").length());
        texto2 = Mensajes.get("XClientesEncuestados") + StringUtils.leftPad(cadena,max - Mensajes.get("XClientesEncuestados").length());

        cadenaRecibo.append(texto2 + "\r\n");

        Paragraph clientesEncuestadosFueraFrecuenciaP = new Paragraph(texto,textoNegrita);
        clientesEncuestadosFueraFrecuenciaP.setAlignment(Element.ALIGN_RIGHT);
        reportePDF.add(clientesEncuestadosFueraFrecuenciaP);

        cadena = StringUtils.rightPad(clientesNoEncuestadosFueraFrecuenciaString, 9);
        cadena+= StringUtils.leftPad( (totalClientesEncuestadosFueraFrecuencia != 0 ? Generales.getFormatoDecimal( ((Double.parseDouble(clientesNoEncuestadosFueraFrecuenciaString) * 100) / totalClientesEncuestadosFueraFrecuencia),"#.##") : "0") + "%", 7);
        texto = Mensajes.get("XClientesNoEncuestados") + StringUtils.leftPad(cadena,maxPDF - Mensajes.get("XClientesNoEncuestados").length());
        texto2 = Mensajes.get("XClientesNoEncuestados") + StringUtils.leftPad(cadena,max - Mensajes.get("XClientesNoEncuestados").length());

        cadenaRecibo.append(texto2 + "\r\n");

        Paragraph clientesNoEncuestadosFueraFrecuenciaP = new Paragraph(texto,textoNegrita);
        clientesNoEncuestadosFueraFrecuenciaP.setAlignment(Element.ALIGN_RIGHT);
        reportePDF.add(clientesNoEncuestadosFueraFrecuenciaP);


        cadena = StringUtils.rightPad(Integer.toString(totalClientesEncuestadosFueraFrecuencia), 9);
        cadena+= StringUtils.leftPad("100.0%", 7);
        texto = Mensajes.get("XClientesTotal") + StringUtils.leftPad(cadena,maxPDF - Mensajes.get("XClientesTotal").length());
        texto2 = Mensajes.get("XClientesTotal") + StringUtils.leftPad(cadena,max - Mensajes.get("XClientesTotal").length());

        cadenaRecibo.append(texto2 + "\r\n");

        Paragraph totalClientesEncuestadosFueraFrecuenciaP = new Paragraph(texto,textoNegrita);
        totalClientesEncuestadosFueraFrecuenciaP.setAlignment(Element.ALIGN_RIGHT);
        reportePDF.add(totalClientesEncuestadosFueraFrecuenciaP);

        reportePDF.add(new Paragraph(" "));
        reportePDF.add(new Paragraph(" "));

        imprimeLineaPunteada(cadenaRecibo, tamanioLetra.mLongTotal);

        //CODIGOS LEIDOS FUERA FRECUENCIA

        ISetDatos codigosLeidosFueraFrecuencia = Consultas.ConsultasTransProd.obtenerCodigosLeidosFueraFrecuencia(ruta.RUTClave,diaClave);
        codigosLeidosFueraFrecuencia.moveToNext();
        ISetDatos codigosNoLeidosFueraFrecuencia = Consultas.ConsultasTransProd.obtenerCodigosNoLeidosFueraFrecuencia(ruta.RUTClave,diaClave);
        codigosNoLeidosFueraFrecuencia.moveToNext();

        String codigosLeidosFueraFrecuenciaString =codigosLeidosFueraFrecuencia.getString(0);
        String codigosNoLeidosFueraFrecuenciaString =codigosNoLeidosFueraFrecuencia.getString(0);
        int totalCodigosFueraFrecuencia = Integer.parseInt(codigosLeidosFueraFrecuenciaString) + Integer.parseInt(codigosNoLeidosFueraFrecuenciaString);

        cadena = StringUtils.rightPad(codigosLeidosFueraFrecuenciaString, 9);
        cadena+= StringUtils.leftPad( (totalCodigosFueraFrecuencia!=0?Generales.getFormatoDecimal( ((Double.parseDouble(codigosLeidosFueraFrecuenciaString) * 100) / totalCodigosFueraFrecuencia),"#.##"):"0") +"%",7);
        texto = "Código Barras Leídos" + StringUtils.leftPad(cadena,maxPDF - "Código Barras Leídos".length());
        texto2 = "Código Barras Leídos" + StringUtils.leftPad(cadena,max - "Código Barras Leídos".length());

        cadenaRecibo.append(texto2 + "\r\n");

        Paragraph codigosLeidosFueraFrecuenciaP = new Paragraph(texto,textoNegrita);
        codigosLeidosFueraFrecuenciaP.setAlignment(Element.ALIGN_RIGHT);
        reportePDF.add(codigosLeidosFueraFrecuenciaP);

        cadena = StringUtils.rightPad(codigosNoLeidosFueraFrecuenciaString, 9);
        cadena+= StringUtils.leftPad( (totalCodigosFueraFrecuencia!=0?Generales.getFormatoDecimal( ((Double.parseDouble(codigosNoLeidosFueraFrecuenciaString) * 100) / totalCodigosFueraFrecuencia),"#.##"):"0") +"%",7);
        texto = Mensajes.get("XClientesSeleccionados") + StringUtils.leftPad(cadena,maxPDF - Mensajes.get("XClientesSeleccionados").length());
        texto2 = Mensajes.get("XClientesSeleccionados") + StringUtils.leftPad(cadena,max - Mensajes.get("XClientesSeleccionados").length());

        cadenaRecibo.append(texto2 + "\r\n");

        Paragraph codigosNoLeidosFueraFrecuenciaP = new Paragraph(texto,textoNegrita);
        codigosNoLeidosFueraFrecuenciaP.setAlignment(Element.ALIGN_RIGHT);
        reportePDF.add(codigosNoLeidosFueraFrecuenciaP);

        cadena = StringUtils.rightPad(Integer.toString(totalCodigosFueraFrecuencia), 9);
        cadena+= StringUtils.leftPad("", 7);
        texto = Mensajes.get("XClientesTotal") + StringUtils.leftPad(cadena,maxPDF - Mensajes.get("XClientesTotal").length());
        texto2 = Mensajes.get("XClientesTotal") + StringUtils.leftPad(cadena,max - Mensajes.get("XClientesTotal").length());

        cadenaRecibo.append(texto2 + "\r\n");

        Paragraph totalCodigosFueraFrecuenciaP = new Paragraph(texto,textoNegrita);
        totalCodigosFueraFrecuenciaP.setAlignment(Element.ALIGN_RIGHT);
        reportePDF.add(totalCodigosFueraFrecuenciaP);

        document.add(reportePDF);

        cadenaRecibo.append("\r\n");
        cadenaRecibo.append("\r\n");
        cadenaRecibo.append("\r\n");
        cadenaRecibo.append("\r\n");
        cadenaRecibo.append("\r\n");
        cadenaRecibo.append("\r\n");
    }

    private static void generarReporteResumenMovsCostena(int reporte, StringBuilder cadenaRecibo, Document document) throws Exception {
        String cadena = "";
        String texto = "";
        String texto2 = "";
        int columna = 10;
        int max = 38;
        int max2 = 38;
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

        if (((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.ZEBRA_TERMICA2 || ((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.ZEBRA_CAMEO2) {
            cadena = "{" + tamanioLetra.mTamanio + " " + tamanioLetra.mAlto + "}";
        } else if (((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.INTERMEC_PR2 || ((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.INTERMEC_PR3) {
            //Se usa el mAlto para indentificar si la letra es normal o doble 0= normal 1= doble
            //En la cadena de los bytes no se debe dejar espacios, si no falla y se consideran hasta el momento
            //3 bytes en el mensaje, por lo que si se mete menos o mas, hay que cambiar el codigo en BluetoothPrint
            if (tamanioLetra.mAlto != 0) {
                cadena = "{27,33," + tamanioLetra.mTamanio + "}";
            }
			else
			{
                cadena = "{27,119," + tamanioLetra.mTamanio + "}";
            }
		} else if( ((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.ZEBRA_TERMICA3 ) {
            cadena = "! U1 SETLP 7 " + tamanioLetra.mTamanio + " " + tamanioLetra.mAlto + " ";
        }
		else
		{
            cadena = "{" + tamanioLetra.mTamanio + "}";
            if (((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.SEWOO) {
                max2 = 32;
            }
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

        short tipoTransprod =0;
        if (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.PREVENTA) {
            tipoTransprod = 1;
        } else if (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO) {
            tipoTransprod = 21;
        }

        info = ConsultasTransProd.obtenerTotalPedidosCostena(tipoTransprod, "1",false);
        total = 0;
        /* Agrega las categorias */
        while (info.moveToNext()) {
            cadena = Mensajes.get("XTotalPedidos") + ": ";
            //cadena = cadena.replace("$0$", ValoresReferencia.getDescripcion("CESQUEMA", info.getString("Clasificacion")));
            String clasificacion = "";
            if (info.getString("Clasificacion") != null)
                clasificacion = ValoresReferencia.getDescripcion("CESQUEMA", info.getString("Clasificacion"));
            cadena = cadena.replace("$0$", clasificacion);
            texto = "$" + Generales.getFormatoDecimal(info.getFloat("Total"), "#,###,##0.00");

            if ((cadena.length() + texto.length()) > max2) {
                texto2 = completaHasta(texto, ((max2 * 2) - cadena.length()), TipoAlineacion.DERECHA, true);
            } else {
                texto2 = completaHasta(texto, (max2 - cadena.length()), TipoAlineacion.DERECHA, true);
            }
            texto = completaHasta(texto, (max - cadena.length()) + columna, TipoAlineacion.DERECHA, true);

            cadenaRecibo.append(cadena + texto2 + "\r\n");
            cadenaRecibo.append("\r\n");

            reportePDF.add(cadena + texto); //agregar texto al pdf
            reportePDF.add(new Paragraph(" ")); //linea en blanco = \r\n

            total += info.getFloat("Total");
        }
        info.close();
        /* Agrega total */
        cadena = (Mensajes.get("XTotalPedidos") + ": ").replace("$0$", "");
        texto = "$" + Generales.getFormatoDecimal(total, "#,###,##0.00");

        if ((cadena.length() + texto.length()) > max2) {
            texto2 = completaHasta(texto, ((max2 * 2) - cadena.length()), TipoAlineacion.DERECHA, true);
        } else {
            texto2 = completaHasta(texto, (max2 - cadena.length()), TipoAlineacion.DERECHA, true);
        }
        texto = completaHasta(texto, (max - cadena.length()) + columna, TipoAlineacion.DERECHA, true);

        cadenaRecibo.append(cadena + texto2 + "\r\n");
        cadenaRecibo.append("\r\n");

        reportePDF.add(cadena + texto); //agregar texto al pdf
        reportePDF.add(new Paragraph(" ")); //linea en blanco = \r\n

        info = ConsultasTransProd.obtenerPedidosContado();
        total = 0;
        while (info.moveToNext()) {
            total += info.getFloat("Total");
        }
        cadena = Mensajes.get("XTotalPedidosContado") + ": ";
        texto = "$" + Generales.getFormatoDecimal(total, "#,###,##0.00");

        if ((cadena.length() + texto.length()) > max2) {
            texto2 = completaHasta(texto, ((max2 * 2) - cadena.length()), TipoAlineacion.DERECHA, true);
        } else {
            texto2 = completaHasta(texto, (max2 - cadena.length()), TipoAlineacion.DERECHA, true);
            ;
        }
        texto = completaHasta(texto, (max - cadena.length()) + columna, TipoAlineacion.DERECHA, true);

        cadenaRecibo.append(cadena + texto2 + "\r\n");
        info.close();
        reportePDF.add(cadena + texto);
        reportePDF.add(new Paragraph(" ")); //linea en blanco = \r\n

        info = ConsultasTransProd.obtenerPedidosCredito();
        total = 0;
        while (info.moveToNext()) {
            total += info.getFloat("Total");
        }
        cadena = Mensajes.get("XTotalPedidosCredito") + ": ";
        texto = "$" + Generales.getFormatoDecimal(total, "#,###,##0.00");
        if ((cadena.length() + texto.length()) > max2) {
            texto2 = completaHasta(texto, ((max2 * 2) - cadena.length()), TipoAlineacion.DERECHA, true);
        } else {
            texto2 = completaHasta(texto, (max2 - cadena.length()), TipoAlineacion.DERECHA, true);
            ;
        }
        texto = completaHasta(texto, (max - cadena.length()) + columna, TipoAlineacion.DERECHA, true);

        cadenaRecibo.append(cadena + texto2 + "\r\n");
        cadenaRecibo.append("\r\n");
        info.close();
        reportePDF.add(cadena + texto);
        reportePDF.add(new Paragraph(" ")); //linea en blanco = \r\n

        info = ConsultasTransProd.obtenerPedidosCancelados();
        total = 0;
        count = 0;
        while (info.moveToNext()) {
            total += info.getFloat("Total");
            count += info.getInt("TotalPedidos");
        }
        cadena = Mensajes.get("XPedidosCancelados") + ": ";
        texto = "" + count;
        if ((cadena.length() + texto.length()) > max2) {
            texto2 = completaHasta(texto, ((max2 * 2) - cadena.length()), TipoAlineacion.DERECHA, true);
        } else {
            texto2 = completaHasta(texto, (max2 - cadena.length()), TipoAlineacion.DERECHA, true);
        }

        texto = completaHasta(texto, (max - cadena.length()) + columna, TipoAlineacion.DERECHA, true);

        cadenaRecibo.append(cadena + texto2 + "\r\n");
        reportePDF.add(cadena + texto);
        cadena = Mensajes.get("XTotalMin") + " " + Mensajes.get("XPedidosCancelados") + ": ";
        texto = "$" + Generales.getFormatoDecimal(total, "#,###,##0.00");
        if ((cadena.length() + texto.length()) > max2) {
            texto2 = completaHasta(texto, ((max2 * 2) - cadena.length()), TipoAlineacion.DERECHA, true);
        } else {
            texto2 = completaHasta(texto, (max2 - cadena.length()), TipoAlineacion.DERECHA, true);
        }
        texto = completaHasta(texto, (max - cadena.length()) + columna, TipoAlineacion.DERECHA, true);
        cadenaRecibo.append(cadena + texto2 + "\r\n");
        reportePDF.add(cadena + texto);
        cadenaRecibo.append("\r\n");
        info.close();
        reportePDF.add(new Paragraph(" ")); //linea en blanco = \r\n

        info = ConsultasTransProd.obtenerPedidosCanceladosOp();
        total = 0;
        count = 0;
        while (info.moveToNext()) {
            total += info.getFloat("Total");
            count += info.getInt("TotalPedidos");
        }
        cadena = Mensajes.get("XPedidosCanceladosOp") + ": ";
        texto = "" + count;
        if ((cadena.length() + texto.length()) > max2) {
            texto2 = completaHasta(texto, ((max2 * 2) - cadena.length()), TipoAlineacion.DERECHA, true);
        } else {
            texto2 = completaHasta(texto, (max2 - cadena.length()), TipoAlineacion.DERECHA, true);
            ;
        }
        texto = completaHasta(texto, (max - cadena.length()) + columna, TipoAlineacion.DERECHA, true);
        cadenaRecibo.append(cadena + texto2 + "\r\n");
        reportePDF.add(cadena + texto);
        cadena = Mensajes.get("XTotalMin") + " " + Mensajes.get("XPedidosCanceladosOp") + ": ";
        texto = "$" + Generales.getFormatoDecimal(total, "#,###,##0.00");
        if ((cadena.length() + texto.length()) > max2) {
            texto2 = completaHasta(texto, ((max2 * 2) - cadena.length()), TipoAlineacion.DERECHA, true);
        } else {
            texto2 = completaHasta(texto, (max2 - cadena.length()), TipoAlineacion.DERECHA, true);
            ;
        }
        texto = completaHasta(texto, (max - cadena.length()) + columna, TipoAlineacion.DERECHA, true);
        cadenaRecibo.append(cadena + texto2 + "\r\n");
        reportePDF.add(cadena + texto);
        cadenaRecibo.append("\r\n");
        info.close();
        reportePDF.add(new Paragraph(" ")); //linea en blanco = \r\n

        info = ConsultasTransProd.obtenerPedidosDelDia();
        total = 0;
        count = 0;
        while (info.moveToNext()) {
            total += info.getFloat("Total");
            count += info.getInt("TotalPedidos");
        }
        cadena = Mensajes.get("XPedidosDelDia") + ": ";
        texto = "" + count;
        if ((cadena.length() + texto.length()) > max2) {
            texto2 = completaHasta(texto, ((max2 * 2) - cadena.length()), TipoAlineacion.DERECHA, true);
        } else {
            texto2 = completaHasta(texto, (max2 - cadena.length()), TipoAlineacion.DERECHA, true);
            ;
        }
        texto = completaHasta(texto, (max - cadena.length()) + columna, TipoAlineacion.DERECHA, true);
        cadenaRecibo.append(cadena + texto2 + "\r\n");
        reportePDF.add(cadena + texto);
        cadena = Mensajes.get("XTotalMin") + " " + Mensajes.get("XPedidosDelDia") + ": ";
        texto = "$" + Generales.getFormatoDecimal(total, "#,###,##0.00");
        if ((cadena.length() + texto.length()) > max2) {
            texto2 = completaHasta(texto, ((max2 * 2) - cadena.length()), TipoAlineacion.DERECHA, true);
        } else {
            texto2 = completaHasta(texto, (max2 - cadena.length()), TipoAlineacion.DERECHA, true);
            ;
        }
        texto = completaHasta(texto, (max - cadena.length()) + columna, TipoAlineacion.DERECHA, true);
        cadenaRecibo.append(cadena + texto2 + "\r\n");
        reportePDF.add(cadena + texto);
        cadenaRecibo.append("\r\n");
        info.close();
        reportePDF.add(new Paragraph(" ")); //linea en blanco = \r\n

        info = ConsultasTransProd.obtenerPedidosOp();
        total = 0;
        count = 0;
        while (info.moveToNext()) {
            total += info.getFloat("Total");
            count += info.getInt("TotalPedidos");
        }
        cadena = Mensajes.get("XPedidosClienteOp") + ": ";
        texto = "" + count;
        if ((cadena.length() + texto.length()) > max2) {
            texto2 = completaHasta(texto, ((max2 * 2) - cadena.length()), TipoAlineacion.DERECHA, true);
        } else {
            texto2 = completaHasta(texto, (max2 - cadena.length()), TipoAlineacion.DERECHA, true);
            ;
        }
        texto = completaHasta(texto, (max - cadena.length()) + columna, TipoAlineacion.DERECHA, true);
        cadenaRecibo.append(cadena + texto2 + "\r\n");
        reportePDF.add(cadena + texto);
        cadena = Mensajes.get("XTotalMin") + " " + Mensajes.get("XPedidosClienteOp") + ": ";
        texto = "$" + Generales.getFormatoDecimal(total, "#,###,##0.00");
        if ((cadena.length() + texto.length()) > max2) {
            texto2 = completaHasta(texto, ((max2 * 2) - cadena.length()), TipoAlineacion.DERECHA, true);
        } else {
            texto2 = completaHasta(texto, (max2 - cadena.length()), TipoAlineacion.DERECHA, true);
            ;
        }
        texto = completaHasta(texto, (max - cadena.length()) + columna, TipoAlineacion.DERECHA, true);
        cadenaRecibo.append(cadena + texto2 + "\r\n");
        reportePDF.add(cadena + texto);
        cadenaRecibo.append("\r\n");
        info.close();
        reportePDF.add(new Paragraph(" ")); //linea en blanco = \r\n

        info = ConsultasTransProd.obtenerPedidosFueraFrecuencia();
        total = 0;
        count = 0;
        while (info.moveToNext()) {
            total += info.getFloat("Total");
            count += info.getInt("TotalPedidos");
        }
        cadena = Mensajes.get("XPedidosFueraFrecc") + ": ";
        texto = "" + count;
        if ((cadena.length() + texto.length()) > max2) {
            texto2 = completaHasta(texto, ((max2 * 2) - cadena.length()), TipoAlineacion.DERECHA, true);
        } else {
            texto2 = completaHasta(texto, (max2 - cadena.length()), TipoAlineacion.DERECHA, true);
            ;
        }
        texto = completaHasta(texto, (max - cadena.length()) + columna, TipoAlineacion.DERECHA, true);
        cadenaRecibo.append(cadena + texto2 + "\r\n");
        reportePDF.add(cadena + texto);
        cadena = Mensajes.get("XTotalMin") + " " + Mensajes.get("XPedidosFueraFrecc") + ": ";
        texto = "$" + Generales.getFormatoDecimal(total, "#,###,##0.00");
        if ((cadena.length() + texto.length()) > max2) {
            texto2 = completaHasta(texto, ((max2 * 2) - cadena.length()), TipoAlineacion.DERECHA, true);
        } else {
            texto2 = completaHasta(texto, (max2 - cadena.length()), TipoAlineacion.DERECHA, true);
            ;
        }
        texto = completaHasta(texto, (max - cadena.length()) + columna, TipoAlineacion.DERECHA, true);
        cadenaRecibo.append(cadena + texto2 + "\r\n");
        reportePDF.add(cadena + texto);
        cadenaRecibo.append("\r\n");
        info.close();

        if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).existeParametro("ConvertirProductos")) {
            info = Consultas.ConsultasConversionProducto.obtenerConsolidacionPedidosJornada();
            if (info != null && info.getCount() > 0) {
                reportePDF.add(new Paragraph(" "));
                cadenaRecibo.append("\r\n");
                texto = Impresion.completaHasta(Mensajes.get("XTarimas"), 8, Impresion.TipoAlineacion.DERECHA, false);
                texto += Impresion.completaHasta(ValoresReferencia.getDescripcion("UNIDADV", "6"), 7, Impresion.TipoAlineacion.DERECHA, false);
                texto += Impresion.completaHasta(ValoresReferencia.getDescripcion("UNIDADV", "4"), 6, Impresion.TipoAlineacion.DERECHA, false);
                texto += Impresion.completaHasta(ValoresReferencia.getDescripcion("UNIDADV", "3"),6, Impresion.TipoAlineacion.DERECHA, false);
                cadena = texto;
                texto += Impresion.completaHasta(Mensajes.get("XPeso"), 12, Impresion.TipoAlineacion.DERECHA, false);
                cadena += Impresion.completaHasta(Mensajes.get("XPeso"), max - 32, Impresion.TipoAlineacion.DERECHA, false);
                texto += Impresion.completaHasta(Mensajes.get("XVol"), 10, Impresion.TipoAlineacion.DERECHA, true);
                cadena += Impresion.completaHasta(Mensajes.get("XVol"), 5, Impresion.TipoAlineacion.DERECHA, true);

                cadenaRecibo.append(cadena + "\r\n");
                reportePDF.add(new Paragraph(texto, tituloSubrayado));
            }


            while (info.moveToNext()) {
                if (info.getInt("Clasificacion") == 5) {
                    texto = Impresion.completaHasta(ValoresReferencia.getDescripcion("CESQUEMA", "5").replace("Productos", "").trim().toUpperCase(), 8, Impresion.TipoAlineacion.IZQUIERDA, false);
                } else if (info.getInt("Clasificacion") == 4) {
                    texto = Impresion.completaHasta(ValoresReferencia.getDescripcion("CESQUEMA", "4").replace("Productos La", "").trim().toUpperCase(), 8, Impresion.TipoAlineacion.IZQUIERDA, false);
                }
                cadenaRecibo.append(texto + "\r\n");
                reportePDF.add(new Paragraph(texto, textoNegrita));

                texto = Impresion.completaHasta(Generales.getFormatoDecimal(Math.ceil(info.getFloat("Tarimas")),"##0"), 8, Impresion.TipoAlineacion.DERECHA, false);
                texto += Impresion.completaHasta(Generales.getFormatoDecimal(info.getFloat("Pallets"), "##0"), 7, Impresion.TipoAlineacion.DERECHA, false);
                texto += Impresion.completaHasta(Generales.getFormatoDecimal(info.getFloat("Camas"), "##0"), 6, Impresion.TipoAlineacion.DERECHA, false);
                texto += Impresion.completaHasta(Generales.getFormatoDecimal(info.getFloat("CajasSueltas"), "##0.##"), 6, Impresion.TipoAlineacion.DERECHA, false);
                cadena = texto;
                if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).existeParametro("PesoTarima")) {
                    texto += Impresion.completaHasta(Generales.getFormatoDecimal(info.getFloat("Peso") + (Math.ceil(info.getFloat("Tarimas")) * Float.parseFloat(((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("PesoTarima"))), "##0"), 12, Impresion.TipoAlineacion.DERECHA, false);
                    cadena += Impresion.completaHasta(Generales.getFormatoDecimal(info.getFloat("Peso") + (Math.ceil(info.getFloat("Tarimas")) * Float.parseFloat(((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("PesoTarima"))), "##0"), max - 32, Impresion.TipoAlineacion.DERECHA, false);
                }
                if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).existeParametro("VolumenTarima")) {
                    texto += Impresion.completaHasta(Generales.getFormatoDecimal(info.getFloat("Volumen") + (Math.ceil(info.getFloat("Tarimas")) * Float.parseFloat(((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("VolumenTarima"))), "##0.##"), 10, Impresion.TipoAlineacion.DERECHA, true);
                    cadena += Impresion.completaHasta(Generales.getFormatoDecimal(info.getFloat("Volumen") + (Math.ceil(info.getFloat("Tarimas")) * Float.parseFloat(((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("VolumenTarima"))), "##0.##"), 5, Impresion.TipoAlineacion.DERECHA, true);
                }

                cadenaRecibo.append(texto + "\r\n");
                reportePDF.add(new Paragraph(texto, textoNegrita));
            }
            info.close();
        }
        cadenaRecibo.append("\r\n");
        cadenaRecibo.append("\r\n");
        cadenaRecibo.append("\r\n");
        cadenaRecibo.append("\r\n");
        cadenaRecibo.append("\r\n");

        //Generales.remove1(cadenaRecibo);

        document.add(reportePDF);
    }

    private static void generarReporteResumenMovsGMCostena(int reporte, StringBuilder cadenaRecibo, Document document) throws Exception {
        String cadena = "";
        String texto = "";
        String texto2 = "";
        int columna = 10;
        int max = 38;
        int max2 = 38;
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

        if (((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.ZEBRA_TERMICA2 || ((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.ZEBRA_CAMEO2) {
            cadena = "{" + tamanioLetra.mTamanio + " " + tamanioLetra.mAlto + "}";
        } else if (((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.INTERMEC_PR2 || ((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.INTERMEC_PR3) {
            //Se usa el mAlto para indentificar si la letra es normal o doble 0= normal 1= doble
            //En la cadena de los bytes no se debe dejar espacios, si no falla y se consideran hasta el momento
            //3 bytes en el mensaje, por lo que si se mete menos o mas, hay que cambiar el codigo en BluetoothPrint
            if (tamanioLetra.mAlto != 0) {
                cadena = "{27,33," + tamanioLetra.mTamanio + "}";
            }
            else
            {
                cadena = "{27,119," + tamanioLetra.mTamanio + "}";
            }
        } else if( ((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.ZEBRA_TERMICA3 ) {
            cadena = "! U1 SETLP 7 " + tamanioLetra.mTamanio + " " + tamanioLetra.mAlto + " ";
        }
        else
        {
            cadena = "{" + tamanioLetra.mTamanio + "}";
            if (((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.SEWOO) {
                max2 = 32;
            }
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


        /*Titulos (Monto , Cajas)*/
        texto = Impresion.completaHasta(Mensajes.get("XMontos"), (max2 + columna) - 8, Impresion.TipoAlineacion.DERECHA, false);
        texto += Impresion.completaHasta(Mensajes.get("XCajas"), 8, Impresion.TipoAlineacion.DERECHA, true);
        texto2 = Impresion.completaHasta(Mensajes.get("XMontos"), max2 - 8, Impresion.TipoAlineacion.DERECHA, false);
        texto2 += Impresion.completaHasta(Mensajes.get("XCajas"), 8, Impresion.TipoAlineacion.DERECHA, true);

        cadena = texto2;
        cadenaRecibo.append(cadena + "\r\n");
        reportePDF.add(new Paragraph(texto, tituloSubrayado));


        ISetDatos info;
        float total = 0;
        int count = 0;

        //Se incluyen las fases de los pedidos de pago anticipado
        info = ConsultasTransProd.obtenerTotalPedidosCostena(Short.parseShort("1"),"1",true);
        total = 0;
        float cajas = 0;
        /* Agrega las categorias */
        while (info.moveToNext()) {
            cadena = Mensajes.get("XTotalPedidos") + ": ";
            //cadena = cadena.replace("$0$", ValoresReferencia.getDescripcion("CESQUEMA", info.getString("Clasificacion")));
            String clasificacion = "";
            if (info.getString("Clasificacion") != null)
                clasificacion = ValoresReferencia.getDescripcion("CESQUEMA", info.getString("Clasificacion"));
            cadena = cadena.replace("$0$", clasificacion);
            texto = completaHasta("$" + Generales.getFormatoDecimal(info.getFloat("Total"), "#,###,##0.00"), (max2 + columna) - 8, Impresion.TipoAlineacion.DERECHA, false);
            texto += completaHasta(Generales.getFormatoDecimal(info.getFloat("Cajas"), "##,##0"),8, Impresion.TipoAlineacion.DERECHA, true );
            texto2 = completaHasta("$" + Generales.getFormatoDecimal(info.getFloat("Total"), "#,###,##0.00"), max2 - 8, Impresion.TipoAlineacion.DERECHA, false);
            texto2 += completaHasta(Generales.getFormatoDecimal(info.getFloat("Cajas"), "##,##0"),8, Impresion.TipoAlineacion.DERECHA, true );

            cadenaRecibo.append(cadena + "\r\n");
            cadenaRecibo.append(texto2 + "\r\n");
            cadenaRecibo.append("\r\n");

            reportePDF.add(new Paragraph(cadena,textoNegrita)); //agregar texto al pdf
            reportePDF.add(new Paragraph(texto, textoNegrita));
            reportePDF.add(new Paragraph(" ")); //linea en blanco = \r\n

            total += info.getFloat("Total");
            cajas += info.getFloat("Cajas");
        }
        info.close();
        /* Agrega total */
        cadena = (Mensajes.get("XTotalPedidos") + ": ").replace("$0$", "");
        texto = completaHasta("$" + Generales.getFormatoDecimal(total, "#,###,##0.00"), (max2 + columna) - 8, Impresion.TipoAlineacion.DERECHA, false);
        texto +=completaHasta(Generales.getFormatoDecimal(cajas, "###,##0"), (max2 + columna) - 8, Impresion.TipoAlineacion.DERECHA, true);

        texto2 = completaHasta("$" + Generales.getFormatoDecimal(total, "#,###,##0.00"), max2 - 8, Impresion.TipoAlineacion.DERECHA, false);
        texto2 +=completaHasta(Generales.getFormatoDecimal(cajas, "###,##0"), max2 - 8, Impresion.TipoAlineacion.DERECHA, true);

        cadenaRecibo.append(cadena + "\r\n");
        cadenaRecibo.append(texto2 + "\r\n");
        cadenaRecibo.append("\r\n");

        reportePDF.add(new Paragraph(cadena,textoNegrita)); //agregar texto al pdf
        reportePDF.add(new Paragraph(texto,textoNegrita));
        reportePDF.add(new Paragraph(" ")); //linea en blanco = \r\n

        info = ConsultasTransProd.obtenerPedidosContado();
        total = 0;
        while (info.moveToNext()) {
            total += info.getFloat("Total");
        }
        cadena = Mensajes.get("XTotalPedidosContado") + ": ";
        texto = "$" + Generales.getFormatoDecimal(total, "#,###,##0.00");

        if ((cadena.length() + texto.length()) > max2) {
            texto2 = completaHasta(texto, ((max2 * 2) - cadena.length()), TipoAlineacion.DERECHA, true);
        } else {
            texto2 = completaHasta(texto, (max2 - cadena.length()), TipoAlineacion.DERECHA, true);
            ;
        }
        texto = completaHasta(texto, (max - cadena.length()) + columna, TipoAlineacion.DERECHA, true);

        cadenaRecibo.append(cadena + texto2 + "\r\n");
        info.close();
        reportePDF.add(cadena + texto);
        reportePDF.add(new Paragraph(" ")); //linea en blanco = \r\n

        info = ConsultasTransProd.obtenerPedidosCredito();
        total = 0;
        while (info.moveToNext()) {
            total += info.getFloat("Total");
        }
        cadena = Mensajes.get("XTotalPedidosCredito") + ": ";
        texto = "$" + Generales.getFormatoDecimal(total, "#,###,##0.00");
        if ((cadena.length() + texto.length()) > max2) {
            texto2 = completaHasta(texto, ((max2 * 2) - cadena.length()), TipoAlineacion.DERECHA, true);
        } else {
            texto2 = completaHasta(texto, (max2 - cadena.length()), TipoAlineacion.DERECHA, true);
            ;
        }
        texto = completaHasta(texto, (max - cadena.length()) + columna, TipoAlineacion.DERECHA, true);

        cadenaRecibo.append(cadena + texto2 + "\r\n");
        cadenaRecibo.append("\r\n");
        info.close();
        reportePDF.add(cadena + texto);
        reportePDF.add(new Paragraph(" ")); //linea en blanco = \r\n

        info = ConsultasTransProd.obtenerPedidosCancelados();
        total = 0;
        count = 0;
        while (info.moveToNext()) {
            total += info.getFloat("Total");
            count += info.getInt("TotalPedidos");
        }
        cadena = Mensajes.get("XPedidosCancelados") + ": ";
        texto = "" + count;
        if ((cadena.length() + texto.length()) > max2) {
            texto2 = completaHasta(texto, ((max2 * 2) - cadena.length()), TipoAlineacion.DERECHA, true);
        } else {
            texto2 = completaHasta(texto, (max2 - cadena.length()), TipoAlineacion.DERECHA, true);
        }

        texto = completaHasta(texto, (max - cadena.length()) + columna, TipoAlineacion.DERECHA, true);

        cadenaRecibo.append(cadena + texto2 + "\r\n");
        reportePDF.add(cadena + texto);
        cadena = Mensajes.get("XTotalMin") + " " + Mensajes.get("XPedidosCancelados") + ": ";
        texto = "$" + Generales.getFormatoDecimal(total, "#,###,##0.00");
        if ((cadena.length() + texto.length()) > max2) {
            texto2 = completaHasta(texto, ((max2 * 2) - cadena.length()), TipoAlineacion.DERECHA, true);
        } else {
            texto2 = completaHasta(texto, (max2 - cadena.length()), TipoAlineacion.DERECHA, true);
        }
        texto = completaHasta(texto, (max - cadena.length()) + columna, TipoAlineacion.DERECHA, true);
        cadenaRecibo.append(cadena + texto2 + "\r\n");
        reportePDF.add(cadena + texto);
        cadenaRecibo.append("\r\n");
        info.close();
        reportePDF.add(new Paragraph(" ")); //linea en blanco = \r\n

        info = ConsultasTransProd.obtenerPedidosCanceladosOp();
        total = 0;
        count = 0;
        while (info.moveToNext()) {
            total += info.getFloat("Total");
            count += info.getInt("TotalPedidos");
        }
        cadena = Mensajes.get("XPedidosCanceladosOp") + ": ";
        texto = "" + count;
        if ((cadena.length() + texto.length()) > max2) {
            texto2 = completaHasta(texto, ((max2 * 2) - cadena.length()), TipoAlineacion.DERECHA, true);
        } else {
            texto2 = completaHasta(texto, (max2 - cadena.length()), TipoAlineacion.DERECHA, true);
            ;
        }
        texto = completaHasta(texto, (max - cadena.length()) + columna, TipoAlineacion.DERECHA, true);
        cadenaRecibo.append(cadena + texto2 + "\r\n");
        reportePDF.add(cadena + texto);
        cadena = Mensajes.get("XTotalMin") + " " + Mensajes.get("XPedidosCanceladosOp") + ": ";
        texto = "$" + Generales.getFormatoDecimal(total, "#,###,##0.00");
        if ((cadena.length() + texto.length()) > max2) {
            texto2 = completaHasta(texto, ((max2 * 2) - cadena.length()), TipoAlineacion.DERECHA, true);
        } else {
            texto2 = completaHasta(texto, (max2 - cadena.length()), TipoAlineacion.DERECHA, true);
            ;
        }
        texto = completaHasta(texto, (max - cadena.length()) + columna, TipoAlineacion.DERECHA, true);
        cadenaRecibo.append(cadena + texto2 + "\r\n");
        reportePDF.add(cadena + texto);
        cadenaRecibo.append("\r\n");
        info.close();
        reportePDF.add(new Paragraph(" ")); //linea en blanco = \r\n

        info = ConsultasTransProd.obtenerPedidosDelDia();
        total = 0;
        count = 0;
        while (info.moveToNext()) {
            total += info.getFloat("Total");
            count += info.getInt("TotalPedidos");
        }
        cadena = Mensajes.get("XPedidosDelDia") + ": ";
        texto = "" + count;
        if ((cadena.length() + texto.length()) > max2) {
            texto2 = completaHasta(texto, ((max2 * 2) - cadena.length()), TipoAlineacion.DERECHA, true);
        } else {
            texto2 = completaHasta(texto, (max2 - cadena.length()), TipoAlineacion.DERECHA, true);
            ;
        }
        texto = completaHasta(texto, (max - cadena.length()) + columna, TipoAlineacion.DERECHA, true);
        cadenaRecibo.append(cadena + texto2 + "\r\n");
        reportePDF.add(cadena + texto);
        cadena = Mensajes.get("XTotalMin") + " " + Mensajes.get("XPedidosDelDia") + ": ";
        texto = "$" + Generales.getFormatoDecimal(total, "#,###,##0.00");
        if ((cadena.length() + texto.length()) > max2) {
            texto2 = completaHasta(texto, ((max2 * 2) - cadena.length()), TipoAlineacion.DERECHA, true);
        } else {
            texto2 = completaHasta(texto, (max2 - cadena.length()), TipoAlineacion.DERECHA, true);
            ;
        }
        texto = completaHasta(texto, (max - cadena.length()) + columna, TipoAlineacion.DERECHA, true);
        cadenaRecibo.append(cadena + texto2 + "\r\n");
        reportePDF.add(cadena + texto);
        cadenaRecibo.append("\r\n");
        info.close();
        reportePDF.add(new Paragraph(" ")); //linea en blanco = \r\n

        info = ConsultasTransProd.obtenerPedidosOp();
        total = 0;
        count = 0;
        while (info.moveToNext()) {
            total += info.getFloat("Total");
            count += info.getInt("TotalPedidos");
        }
        cadena = Mensajes.get("XPedidosClienteOp") + ": ";
        texto = "" + count;
        if ((cadena.length() + texto.length()) > max2) {
            texto2 = completaHasta(texto, ((max2 * 2) - cadena.length()), TipoAlineacion.DERECHA, true);
        } else {
            texto2 = completaHasta(texto, (max2 - cadena.length()), TipoAlineacion.DERECHA, true);
            ;
        }
        texto = completaHasta(texto, (max - cadena.length()) + columna, TipoAlineacion.DERECHA, true);
        cadenaRecibo.append(cadena + texto2 + "\r\n");
        reportePDF.add(cadena + texto);
        cadena = Mensajes.get("XTotalMin") + " " + Mensajes.get("XPedidosClienteOp") + ": ";
        texto = "$" + Generales.getFormatoDecimal(total, "#,###,##0.00");
        if ((cadena.length() + texto.length()) > max2) {
            texto2 = completaHasta(texto, ((max2 * 2) - cadena.length()), TipoAlineacion.DERECHA, true);
        } else {
            texto2 = completaHasta(texto, (max2 - cadena.length()), TipoAlineacion.DERECHA, true);
            ;
        }
        texto = completaHasta(texto, (max - cadena.length()) + columna, TipoAlineacion.DERECHA, true);
        cadenaRecibo.append(cadena + texto2 + "\r\n");
        reportePDF.add(cadena + texto);
        cadenaRecibo.append("\r\n");
        info.close();
        reportePDF.add(new Paragraph(" ")); //linea en blanco = \r\n

        info = ConsultasTransProd.obtenerPedidosFueraFrecuencia();
        total = 0;
        count = 0;
        while (info.moveToNext()) {
            total += info.getFloat("Total");
            count += info.getInt("TotalPedidos");
        }
        cadena = Mensajes.get("XPedidosFueraFrecc") + ": ";
        texto = "" + count;
        if ((cadena.length() + texto.length()) > max2) {
            texto2 = completaHasta(texto, ((max2 * 2) - cadena.length()), TipoAlineacion.DERECHA, true);
        } else {
            texto2 = completaHasta(texto, (max2 - cadena.length()), TipoAlineacion.DERECHA, true);
            ;
        }
        texto = completaHasta(texto, (max - cadena.length()) + columna, TipoAlineacion.DERECHA, true);
        cadenaRecibo.append(cadena + texto2 + "\r\n");
        reportePDF.add(cadena + texto);
        cadena = Mensajes.get("XTotalMin") + " " + Mensajes.get("XPedidosFueraFrecc") + ": ";
        texto = "$" + Generales.getFormatoDecimal(total, "#,###,##0.00");
        if ((cadena.length() + texto.length()) > max2) {
            texto2 = completaHasta(texto, ((max2 * 2) - cadena.length()), TipoAlineacion.DERECHA, true);
        } else {
            texto2 = completaHasta(texto, (max2 - cadena.length()), TipoAlineacion.DERECHA, true);
            ;
        }
        texto = completaHasta(texto, (max - cadena.length()) + columna, TipoAlineacion.DERECHA, true);
        cadenaRecibo.append(cadena + texto2 + "\r\n");
        reportePDF.add(cadena + texto);
        cadenaRecibo.append("\r\n");
        info.close();

        if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).existeParametro("ConvertirProductos")) {
            info = Consultas.ConsultasConversionProducto.obtenerConsolidacionPedidosJornada();
            if (info != null && info.getCount() > 0) {
                reportePDF.add(new Paragraph(" "));
                cadenaRecibo.append("\r\n");
                texto = Impresion.completaHasta(Mensajes.get("XTarimas"), 8, Impresion.TipoAlineacion.DERECHA, false);
                texto += Impresion.completaHasta(ValoresReferencia.getDescripcion("UNIDADV", "6"), 7, Impresion.TipoAlineacion.DERECHA, false);
                texto += Impresion.completaHasta(ValoresReferencia.getDescripcion("UNIDADV", "4"), 6, Impresion.TipoAlineacion.DERECHA, false);
                texto += Impresion.completaHasta(ValoresReferencia.getDescripcion("UNIDADV", "3"),6, Impresion.TipoAlineacion.DERECHA, false);
                cadena = texto;
                texto += Impresion.completaHasta(Mensajes.get("XPeso"), 12, Impresion.TipoAlineacion.DERECHA, false);
                cadena += Impresion.completaHasta(Mensajes.get("XPeso"), max - 32, Impresion.TipoAlineacion.DERECHA, false);
                texto += Impresion.completaHasta(Mensajes.get("XVol"), 10, Impresion.TipoAlineacion.DERECHA, true);
                cadena += Impresion.completaHasta(Mensajes.get("XVol"), 5, Impresion.TipoAlineacion.DERECHA, true);

                cadenaRecibo.append(cadena + "\r\n");
                reportePDF.add(new Paragraph(texto, tituloSubrayado));
            }


            while (info.moveToNext()) {
                if (info.getInt("Clasificacion") == 5) {
                    texto = Impresion.completaHasta(ValoresReferencia.getDescripcion("CESQUEMA", "5").replace("Productos", "").trim().toUpperCase(), 8, Impresion.TipoAlineacion.IZQUIERDA, false);
                } else if (info.getInt("Clasificacion") == 4) {
                    texto = Impresion.completaHasta(ValoresReferencia.getDescripcion("CESQUEMA", "4").replace("Productos La", "").trim().toUpperCase(), 8, Impresion.TipoAlineacion.IZQUIERDA, false);
                }
                cadenaRecibo.append(texto + "\r\n");
                reportePDF.add(new Paragraph(texto, textoNegrita));

                texto = Impresion.completaHasta(Generales.getFormatoDecimal(Math.ceil(info.getFloat("Tarimas")),"##0"), 8, Impresion.TipoAlineacion.DERECHA, false);
                texto += Impresion.completaHasta(Generales.getFormatoDecimal(info.getFloat("Pallets"), "##0"), 7, Impresion.TipoAlineacion.DERECHA, false);
                texto += Impresion.completaHasta(Generales.getFormatoDecimal(info.getFloat("Camas"), "##0"), 6, Impresion.TipoAlineacion.DERECHA, false);
                texto += Impresion.completaHasta(Generales.getFormatoDecimal(info.getFloat("CajasSueltas"), "##0.##"), 6, Impresion.TipoAlineacion.DERECHA, false);
                cadena = texto;
                if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).existeParametro("PesoTarima")) {
                    texto += Impresion.completaHasta(Generales.getFormatoDecimal(info.getFloat("Peso") + (Math.ceil(info.getFloat("Tarimas")) * Float.parseFloat(((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("PesoTarima"))), "##0"), 12, Impresion.TipoAlineacion.DERECHA, false);
                    cadena += Impresion.completaHasta(Generales.getFormatoDecimal(info.getFloat("Peso") + (Math.ceil(info.getFloat("Tarimas")) * Float.parseFloat(((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("PesoTarima"))), "##0"), max - 32, Impresion.TipoAlineacion.DERECHA, false);
                }
                if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).existeParametro("VolumenTarima")) {
                    texto += Impresion.completaHasta(Generales.getFormatoDecimal(info.getFloat("Volumen") + (Math.ceil(info.getFloat("Tarimas")) * Float.parseFloat(((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("VolumenTarima"))), "##0.##"), 10, Impresion.TipoAlineacion.DERECHA, true);
                    cadena += Impresion.completaHasta(Generales.getFormatoDecimal(info.getFloat("Volumen") + (Math.ceil(info.getFloat("Tarimas")) * Float.parseFloat(((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("VolumenTarima"))), "##0.##"), 5, Impresion.TipoAlineacion.DERECHA, true);
                }

                cadenaRecibo.append(texto + "\r\n");
                reportePDF.add(new Paragraph(texto, textoNegrita));
            }
            info.close();
        }
        cadenaRecibo.append("\r\n");
        cadenaRecibo.append("\r\n");
        cadenaRecibo.append("\r\n");
        cadenaRecibo.append("\r\n");
        cadenaRecibo.append("\r\n");

        //Generales.remove1(cadenaRecibo);

        document.add(reportePDF);
    }

    private static void generarReporteInventarioCosteña(int reporte, StringBuilder cadenaRecibo, Document document) throws Exception {
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
        Vendedor vendedor = (Vendedor) Sesion.get(Campo.VendedorActual);
        setTamanioDefault(vendedor.TipoModImp);
        TamanioLetra tamanioLetra;
        tamanioLetra = tamanioDefault;

        if (vendedor.TipoModImp == TipoPapel.ZEBRA_TERMICA2 || vendedor.TipoModImp == TipoPapel.ZEBRA_CAMEO2) {
            cadena = "{" + tamanioLetra.mTamanio + " " + tamanioLetra.mAlto + "}";
        } else if (vendedor.TipoModImp == TipoPapel.INTERMEC_PR2 || vendedor.TipoModImp == TipoPapel.INTERMEC_PR3) {
            //Se usa el mAlto para indentificar si la letra es normal o doble 0= normal 1= doble
            //En la cadena de los bytes no se debe dejar espacios, si no falla y se consideran hasta el momento
            //3 bytes en el mensaje, por lo que si se mete menos o mas, hay que cambiar el codigo en BluetoothPrint
            if (tamanioLetra.mAlto != 0) {
                cadena = "{27,33," + tamanioLetra.mTamanio + "}";
            } else {
                cadena = "{27,119," + tamanioLetra.mTamanio + "}";
            }
        } else if( vendedor.TipoModImp == TipoPapel.ZEBRA_TERMICA3 ) {
            cadena = "! U1 SETLP 7 " + tamanioLetra.mTamanio + " " + tamanioLetra.mAlto + " ";
        }
        else {
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
//		cadenaRecibo.append("\r\n");

        Paragraph rut = new Paragraph(texto, textoNegrita);
        rut.setAlignment(Element.ALIGN_CENTER);
        reportePDF.add(rut);
//		reportePDF.add(vacio);

        texto = Mensajes.get("XVendedor") + ": " + ((Usuario) Sesion.get(Campo.UsuarioActual)).Nombre;
        cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, tamanioLetra.mLongTotal);
        cadenaRecibo.append(cadena + "\r\n");
//		cadenaRecibo.append("\r\n");

        Paragraph ven = new Paragraph(texto, textoNegrita);
        ven.setAlignment(Element.ALIGN_CENTER);
        reportePDF.add(ven);
//		reportePDF.add(vacio);

        texto = "% ".concat(Mensajes.get("XTotalMin") + " ").concat(Mensajes.get("XCaducos")) + " = XCADX";
        cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, tamanioLetra.mLongTotal);
        cadenaRecibo.append(cadena + "\r\n");
        cadenaRecibo.append("\r\n");

        Paragraph cad = new Paragraph(texto, textoNegrita);
        cad.setAlignment(Element.ALIGN_CENTER);
        reportePDF.add(cad);
        reportePDF.add(vacio);

		/* Encabezado Linea 1 */
        texto = Mensajes.get("XCodigo");
        cadena = completaHasta(texto, 7, TipoAlineacion.IZQUIERDA, false);
        texto = Mensajes.get("XDescripcion");
        cadena += completaHasta(texto, 20, TipoAlineacion.IZQUIERDA, false);
        texto = Mensajes.get("XEmpaque");
        cadena += completaHasta(texto, 8, TipoAlineacion.DERECHA, true);

        cadenaRecibo.append(cadena + "\r\n");

        Paragraph encabezado_1 = new Paragraph(cadena, textoNegrita);
        reportePDF.add(encabezado_1);

		/* Encabezado Linea 2 */
        texto = Mensajes.get("XInventarioInicial");
        cadena = completaHasta(texto, 4, TipoAlineacion.IZQUIERDA, false);
        texto = Mensajes.get("XVta");
        cadena += completaHasta(texto, 4, TipoAlineacion.IZQUIERDA, false);
        texto = Mensajes.get("XInventarioBueno");
        cadena += completaHasta(texto, 4, TipoAlineacion.IZQUIERDA, false);
        texto = Mensajes.get("XInventarioMalo");
        cadena += completaHasta(texto, 4, TipoAlineacion.IZQUIERDA, false);
        texto = Mensajes.get("XInventarioFrio");
        cadena += completaHasta(texto, 4, TipoAlineacion.IZQUIERDA, false);
        texto = Mensajes.get("XInventarioTotal");
        cadena += completaHasta(texto, 4, TipoAlineacion.IZQUIERDA, false);
        texto = Mensajes.get("XPrecio");
        cadena += completaHasta(texto, 7, TipoAlineacion.IZQUIERDA, false);
        texto = Mensajes.get("XImpuesto");
        cadena += completaHasta(texto, 7, TipoAlineacion.IZQUIERDA, false);
        texto = Mensajes.get("XImporte");
        cadena += completaHasta(texto, 7, TipoAlineacion.DERECHA, true);

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
        float temp, totalCost = 0, totalTotis = 0, porcMalosCost = 0, porcMalosTotis = 0, porcFriosTotis = 0;

        info = Consultas.ConsultasInventario.obtenerInventarioParaReporte();
        /* Agrega los productos */
        while (info.moveToNext()) {
            texto = info.getString(0) + " " + info.getString(1);
            cadena = completaHasta(texto, 31, TipoAlineacion.IZQUIERDA, false);
            texto = ValoresReferencia.getDescripcion("UNIDADV", info.getString(2));
            cadena += completaHasta(texto, 4, TipoAlineacion.DERECHA, true);
            cadena += "\r\n";

            cadenaRecibo.append(cadena);
            reportePDF.add(cadena);
            cadena = "";
            for (int col = 0; col < totales.length; col++) {
                if (col >= 0 && col <= 4) {
                    temp = info.getFloat(keys[col]);
                    texto = Generales.getFormatoDecimal(temp, 0);
                    cadena += completaHasta(texto, 4, TipoAlineacion.IZQUIERDA, false);
                    totales[col] += temp;
                } else if (col == 5) {
                    temp = info.getFloat(keys[2]) + info.getFloat(keys[3]) + info.getFloat(keys[4]);
                    texto = Generales.getFormatoDecimal(temp, 0);
                    cadena += completaHasta(texto, 4, TipoAlineacion.IZQUIERDA, false);
                    totales[col] += temp;
                } else if (col == totales.length - 1) {
                    temp = info.getFloat(keys[1]) * info.getFloat(keys[6]) + info.getFloat(keys[7]);
                    texto = Generales.getFormatoDecimal(temp, 2);
                    cadena += completaHasta(texto, 7, TipoAlineacion.DERECHA, true);
                    totales[col] += temp;
                } else {
                    temp = info.getFloat(keys[col]);
                    texto = Generales.getFormatoDecimal(temp, 2);
                    cadena += completaHasta(texto, col == totales.length - 2 ? 7 : 6, TipoAlineacion.IZQUIERDA, false);
                }
            }
            cadena += "\r\n";
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
        cadena += completaHasta(texto, 7, TipoAlineacion.IZQUIERDA, false);
        texto = Generales.getFormatoDecimal(totales[2], 0);
        cadena += completaHasta(texto, 7, TipoAlineacion.IZQUIERDA, false);
        texto = Generales.getFormatoDecimal(totales[3], 0);
        cadena += completaHasta(texto, 7, TipoAlineacion.IZQUIERDA, false);
        texto = Generales.getFormatoDecimal(totales[4], 0);
        cadena += completaHasta(texto, 7, TipoAlineacion.IZQUIERDA, false);
        texto = Generales.getFormatoDecimal(totales[5], 0);
        cadena += completaHasta(texto, 7, TipoAlineacion.IZQUIERDA, false);

        cadenaRecibo.append(cadena + "\r\n");
        reportePDF.add(cadena);

        cadenaRecibo.append("\r\n");
        reportePDF.add(vacio);
        reportePDF.add(vacio);

		/* Total ventas */
        info = ConsultasTransProd.obtenerTotalVentasCostena();
        float total = 0;
        /* Agrega las categorias */
        while (info.moveToNext()) {
            total += info.getFloat("Total");
        }
        info.close();

        cadena = (Mensajes.get("XTotalVentas") + ": ").replace("$0$", "");
        texto = "$" + Generales.getFormatoDecimal(total, "#,###,##0.00");
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


        info = Consultas.ConsultasTransProd.obtenerTotalPedidosCostena(Short.parseShort("1"),"2",false);

		/* Agrega las categorias */
        String clasificacion;
        while (info.moveToNext()) {
            cadena = Mensajes.get("XTotalVentas") + " ";
            clasificacion = info.getString("Clasificacion");
            clasificacion = clasificacion != null ? clasificacion : "";
            cadena += ValoresReferencia.getDescripcion("CESQUEMA", clasificacion) + ":";
            texto = "$" + Generales.getFormatoDecimal(info.getFloat("Total"), "#,###,##0.00");
            texto = completaHasta(texto, (max - cadena.length()) + columna, TipoAlineacion.DERECHA, true);

            cadenaRecibo.append(cadena + texto + "\r\n");
            cadenaRecibo.append("\r\n");

            reportePDF.add(cadena + texto);
            reportePDF.add(vacio);

            if ("5".equals(clasificacion))
                totalTotis = info.getFloat("Total");
            else if ("4".equals(clasificacion))
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

		/* Agregar el total del titulo */
        String porcentaje = Generales.getFormatoDecimal(Float.isNaN(porcMalosTotis) || Float.isInfinite(porcMalosTotis) ? 0 : porcMalosTotis, "#,###,##0.00");
        int start = cadenaRecibo.indexOf("XCADX");
        cadenaRecibo.replace(start, start + "XCADX".length(), porcentaje);

        reportePDF.remove(8);
        cad = new Paragraph("% ".concat(Mensajes.get("XTotalMin") + " ").concat(Mensajes.get("XCaducos")) + " = " + porcentaje, textoNegrita);
        cad.setAlignment(Element.ALIGN_CENTER);
        reportePDF.add(8, cad);
        /**********************/

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
        cadena += ValoresReferencia.getDescripcion("CESQUEMA", "4") + ":";
        texto = Generales.getFormatoDecimal(Float.isNaN(porcMalosCost) || Float.isInfinite(porcMalosCost) ? 0 : porcMalosCost, "#,###,##0.00") + "%";
        texto = completaHasta(texto, (max - cadena.length()) + columna, TipoAlineacion.DERECHA, true);

        cadenaRecibo.append(cadena + texto + "\r\n");
        cadenaRecibo.append("\r\n");

        reportePDF.add(cadena + texto);
        reportePDF.add(vacio);

		/* Porcentaje malos totis */
        cadena = Mensajes.get("XPorcentajeMalos") + " ";
        cadena += ValoresReferencia.getDescripcion("CESQUEMA", "5") + ":";
        texto = Generales.getFormatoDecimal(Float.isNaN(porcMalosTotis) || Float.isInfinite(porcMalosTotis) ? 0 : porcMalosTotis, "#,###,##0.00") + "%";
        texto = completaHasta(texto, (max - cadena.length()) + columna, TipoAlineacion.DERECHA, true);

        cadenaRecibo.append(cadena + texto + "\r\n");
        cadenaRecibo.append("\r\n");

        reportePDF.add(cadena + texto);
        reportePDF.add(vacio);

		/* Porcentaje Frios totis */
        cadena = Mensajes.get("XPorcentajeFrios") + " ";
        cadena += ValoresReferencia.getDescripcion("CESQUEMA", "5") + ":";
        texto = Generales.getFormatoDecimal(Float.isNaN(porcFriosTotis) || Float.isNaN(porcFriosTotis) ? 0 : porcFriosTotis, "#,###,##0.00") + "%";
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

    private static void generarReporteCuadreDeCajaCostena(int reporte, StringBuilder cadenaRecibo, Document document) throws Exception {
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

        if (((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.ZEBRA_TERMICA2 || ((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.ZEBRA_CAMEO2) {
            cadena = "{" + tamanioLetra.mTamanio + " " + tamanioLetra.mAlto + "}";
        } else if (((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.INTERMEC_PR2 || ((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.INTERMEC_PR3) {
            //Se usa el mAlto para indentificar si la letra es normal o doble 0= normal 1= doble
            //En la cadena de los bytes no se debe dejar espacios, si no falla y se consideran hasta el momento
            //3 bytes en el mensaje, por lo que si se mete menos o mas, hay que cambiar el codigo en BluetoothPrint
            if (tamanioLetra.mAlto != 0) {
                cadena = "{27,33," + tamanioLetra.mTamanio + "}";
            } else {
                cadena = "{27,119," + tamanioLetra.mTamanio + "}";
            }
        } else if( ((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.ZEBRA_TERMICA3 ) {
            cadena = "! U1 SETLP 7 " + tamanioLetra.mTamanio + " " + tamanioLetra.mAlto + " ";
        }
        else {
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

    private static void generarReporteLiquidacionVtasCostena(int reporte, StringBuilder cadenaRecibo, Document document) throws Exception {
        String cadena = "";
        String texto = "";
        String texto2 = "";
        int columna = 10;
        int max = 38;
        int max2 = 38;
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

        if (((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.ZEBRA_TERMICA2 || ((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.ZEBRA_CAMEO2) {
            cadena = "{" + tamanioLetra.mTamanio + " " + tamanioLetra.mAlto + "}";
        } else if (((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.INTERMEC_PR2 || ((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.INTERMEC_PR3) {
            //Se usa el mAlto para indentificar si la letra es normal o doble 0= normal 1= doble
            //En la cadena de los bytes no se debe dejar espacios, si no falla y se consideran hasta el momento
            //3 bytes en el mensaje, por lo que si se mete menos o mas, hay que cambiar el codigo en BluetoothPrint
            if (tamanioLetra.mAlto != 0) {
                cadena = "{27,33," + tamanioLetra.mTamanio + "}";
            } else {
                cadena = "{27,119," + tamanioLetra.mTamanio + "}";
            }
        } else if (((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.EXTECH_TERMICA2) {
            //tamanioLetra.mLongTotal = tamanioLetra.mLongTotal - 1;
            max = 37;
            columna = 9;
            cadena = "{" + tamanioLetra.mTamanio + "}";
        } else if( ((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.ZEBRA_TERMICA3 ) {
            cadena = "! U1 SETLP 7 " + tamanioLetra.mTamanio + " " + tamanioLetra.mAlto + " ";
        }
        else {
            cadena = "{" + tamanioLetra.mTamanio + "}";
            if (((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.SEWOO) {
                max2 = 32;
            }
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
        while (info.moveToNext()) {
            cadena = Mensajes.get("XTotalVentas$0$") + ": ";
            //cadena = cadena.replace("$0$", ValoresReferencia.getDescripcion("CESQUEMA", info.getString("Clasificacion")));
            String clasificacion = "";
            if (info.getString("Clasificacion") != null)
                clasificacion = ValoresReferencia.getDescripcion("CESQUEMA", info.getString("Clasificacion"));
            cadena = cadena.replace("$0$", clasificacion);
            texto = "$" + Generales.getFormatoDecimal(info.getFloat("Total"), "#,###,##0.00");
            if ((cadena.length() + texto.length()) > max2) {
                texto2 = completaHasta(texto, ((max2 * 2) - cadena.length()), TipoAlineacion.DERECHA, true);
            } else {
                texto2 = completaHasta(texto, (max2 - cadena.length()), TipoAlineacion.DERECHA, true);
            }
            texto = completaHasta(texto, (max - cadena.length()) + columna, TipoAlineacion.DERECHA, true);

            cadenaRecibo.append(cadena + texto2 + "\r\n");
            cadenaRecibo.append("\r\n");

            reportePDF.add(cadena + texto); //agregar texto al pdf
            reportePDF.add(new Paragraph(" ")); //linea en blanco = \r\n

            total += info.getFloat("Total");
        }
        info.close();

        //total ventas contado
        info = ConsultasTransProd.obtenerVentasContado();
        total = 0;
        while (info.moveToNext()) {
            total += info.getFloat("Total");
        }
        cadena = Mensajes.get("XTotalVentas") + " " + Mensajes.get("XContado") + ": ";
        texto = "$" + Generales.getFormatoDecimal(total, "#,###,##0.00");
        if ((cadena.length() + texto.length()) > max2) {
            texto2 = completaHasta(texto, ((max2 * 2) - cadena.length()), TipoAlineacion.DERECHA, true);
        } else {
            texto2 = completaHasta(texto, (max2 - cadena.length()), TipoAlineacion.DERECHA, true);
        }
        texto = completaHasta(texto, (max - cadena.length()) + columna, TipoAlineacion.DERECHA, true);
        cadenaRecibo.append(cadena + texto2 + "\r\n");
        info.close();
        reportePDF.add(cadena + texto);
        //reportePDF.add(new Paragraph(" ")); //linea en blanco = \r\n

        //total ventas credito
        info = ConsultasTransProd.obtenerVentasCredito();
        total = 0;
        while (info.moveToNext()) {
            total += info.getFloat("Total");
        }
        cadena = Mensajes.get("XTotalVentas") + " " + Mensajes.get("XCredito") + ": ";
        texto = "$" + Generales.getFormatoDecimal(total, "#,###,##0.00");
        if ((cadena.length() + texto.length()) > max2) {
            texto2 = completaHasta(texto, ((max2 * 2) - cadena.length()), TipoAlineacion.DERECHA, true);
        } else {
            texto2 = completaHasta(texto, (max2 - cadena.length()), TipoAlineacion.DERECHA, true);
        }
        texto = completaHasta(texto, (max - cadena.length()) + columna, TipoAlineacion.DERECHA, true);
        cadenaRecibo.append(cadena + texto2 + "\r\n");
        cadenaRecibo.append("\r\n");
        info.close();
        reportePDF.add(cadena + texto);
        reportePDF.add(new Paragraph(" ")); //linea en blanco = \r\n

        //total a liquidar
        float totalliq = ConsultasAbono.obtenerTotalCobranza();
        cadena = Mensajes.get("XTotalALiquidar") + ": ";
        texto = "$" + Generales.getFormatoDecimal(totalliq, "#,###,##0.00");
        if ((cadena.length() + texto.length()) > max2) {
            texto2 = completaHasta(texto, ((max2 * 2) - cadena.length()), TipoAlineacion.DERECHA, true);
        } else {
            texto2 = completaHasta(texto, (max2 - cadena.length()), TipoAlineacion.DERECHA, true);
        }
        texto = completaHasta(texto, (max - cadena.length()) + columna, TipoAlineacion.DERECHA, true);
        //String texto_ticket = completaHasta("$" + Generales.getFormatoDecimal(totalliq, "#,###,##0.00"), (max - cadena.length()), TipoAlineacion.DERECHA, true);
        cadenaRecibo.append(cadena + texto2 + "\r\n");
        reportePDF.add(cadena + texto);
        //reportePDF.add(new Paragraph(" ")); //linea en blanco = \r\n

        //total pedidos
        info = ConsultasTransProd.obtenerTotalMSIEV();
        total = 0;
        while (info.moveToNext()) {
            total += info.getFloat("Total");
        }
        cadena = (Mensajes.get("XTotalPedidos") + ": ").replace("$0$", "");
        texto = "$" + Generales.getFormatoDecimal(total, "#,###,##0.00");
        if ((cadena.length() + texto.length()) > max2) {
            texto2 = completaHasta(texto, ((max2 * 2) - cadena.length()), TipoAlineacion.DERECHA, true);
        } else {
            texto2 = completaHasta(texto, (max2 - cadena.length()), TipoAlineacion.DERECHA, true);
        }
        texto = completaHasta(texto, (max - cadena.length()) + columna, TipoAlineacion.DERECHA, true);
        cadenaRecibo.append(cadena + texto2 + "\r\n");
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
        while (info.moveToNext()) {
            total += info.getFloat("TotalPedidos");
        }
        totalCanc += total;
        cadena = Mensajes.get("XNotaDeVenta") + ": ";
        texto = Generales.getFormatoDecimal(total, "##0");
        if ((cadena.length() + texto.length()) > max2) {
            texto2 = completaHasta(texto, ((max2 * 2) - cadena.length()), TipoAlineacion.DERECHA, true);
        } else {
            texto2 = completaHasta(texto, (max2 - cadena.length()), TipoAlineacion.DERECHA, true);
        }
        texto = completaHasta(texto, (max - cadena.length()) + columna, TipoAlineacion.DERECHA, true);
        cadenaRecibo.append(cadena + texto2 + "\r\n");
        //cadenaRecibo.append("\r\n");
        info.close();
        reportePDF.add(cadena + texto);
        //reportePDF.add(new Paragraph(" ")); //linea en blanco = \r\n

        //pedidos
        info = ConsultasTransProd.obtenerMSIEVCancelados();
        total = 0;
        while (info.moveToNext()) {
            total += info.getFloat("TotalPedidos");
        }
        totalCanc += total;
        cadena = Mensajes.get("XPedido") + "s: ";
        texto = Generales.getFormatoDecimal(total, "##0");
        if ((cadena.length() + texto.length()) > max2) {
            texto2 = completaHasta(texto, ((max2 * 2) - cadena.length()), TipoAlineacion.DERECHA, true);
        } else {
            texto2 = completaHasta(texto, (max2 - cadena.length()), TipoAlineacion.DERECHA, true);
        }
        texto = completaHasta(texto, (max - cadena.length()) + columna, TipoAlineacion.DERECHA, true);
        cadenaRecibo.append(cadena + texto2 + "\r\n");
        //cadenaRecibo.append("\r\n");
        info.close();
        reportePDF.add(cadena + texto);
        //reportePDF.add(new Paragraph(" ")); //linea en blanco = \r\n

        //entrega pedidos
        info = ConsultasTransProd.obtenerPedidosCanceladosCostena();
        total = 0;
        while (info.moveToNext()) {
            total += info.getFloat("TotalPedidos");
        }
        totalCanc += total;
        cadena = Mensajes.get("XEntregaPedidos") + ": ";
        texto = Generales.getFormatoDecimal(total, "##0");
        if ((cadena.length() + texto.length()) > max2) {
            texto2 = completaHasta(texto, ((max2 * 2) - cadena.length()), TipoAlineacion.DERECHA, true);
        } else {
            texto2 = completaHasta(texto, (max2 - cadena.length()), TipoAlineacion.DERECHA, true);
        }
        texto = completaHasta(texto, (max - cadena.length()) + columna, TipoAlineacion.DERECHA, true);
        cadenaRecibo.append(cadena + texto2 + "\r\n");
        //cadenaRecibo.append("\r\n");
        info.close();
        reportePDF.add(cadena + texto);
        //reportePDF.add(new Paragraph(" ")); //linea en blanco = \r\n

        //total cancelaciones
        cadena = Mensajes.get("XTotalMin") + " " + Mensajes.get("XCancelaciones") + ": ";
        texto = Generales.getFormatoDecimal(totalCanc, "##0");
        if ((cadena.length() + texto.length()) > max2) {
            texto2 = completaHasta(texto, ((max2 * 2) - cadena.length()), TipoAlineacion.DERECHA, true);
        } else {
            texto2 = completaHasta(texto, (max2 - cadena.length()), TipoAlineacion.DERECHA, true);
        }
        texto = completaHasta(texto, (max - cadena.length()) + columna, TipoAlineacion.DERECHA, true);
        cadenaRecibo.append(cadena + texto2 + "\r\n");
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
        while (info.moveToNext()) {
            total += info.getFloat("TotalPedidos");
        }
        totalCanc += total;
        cadena = Mensajes.get("XNotaDeVenta") + ": ";
        texto = Generales.getFormatoDecimal(total, "##0");
        if ((cadena.length() + texto.length()) > max2) {
            texto2 = completaHasta(texto, ((max2 * 2) - cadena.length()), TipoAlineacion.DERECHA, true);
        } else {
            texto2 = completaHasta(texto, (max2 - cadena.length()), TipoAlineacion.DERECHA, true);
        }
        texto = completaHasta(texto, (max - cadena.length()) + columna, TipoAlineacion.DERECHA, true);
        cadenaRecibo.append(cadena + texto2 + "\r\n");
        //cadenaRecibo.append("\r\n");
        info.close();
        reportePDF.add(cadena + texto);
        //reportePDF.add(new Paragraph(" ")); //linea en blanco = \r\n

        //pedidos
        info = ConsultasTransProd.obtenerMSIEVCanceladosOp();
        total = 0;
        while (info.moveToNext()) {
            total += info.getFloat("TotalPedidos");
        }
        totalCanc += total;
        cadena = Mensajes.get("XPedido") + "s: ";
        texto = Generales.getFormatoDecimal(total, "##0");
        if ((cadena.length() + texto.length()) > max2) {
            texto2 = completaHasta(texto, ((max2 * 2) - cadena.length()), TipoAlineacion.DERECHA, true);
        } else {
            texto2 = completaHasta(texto, (max2 - cadena.length()), TipoAlineacion.DERECHA, true);
        }
        texto = completaHasta(texto, (max - cadena.length()) + columna, TipoAlineacion.DERECHA, true);
        cadenaRecibo.append(cadena + texto2 + "\r\n");
        //cadenaRecibo.append("\r\n");
        info.close();
        reportePDF.add(cadena + texto);
        //reportePDF.add(new Paragraph(" ")); //linea en blanco = \r\n

        //entrega pedidos
        info = ConsultasTransProd.obtenerPedidosCanceladosCostenaOp();
        total = 0;
        while (info.moveToNext()) {
            total += info.getFloat("TotalPedidos");
        }
        totalCanc += total;
        cadena = Mensajes.get("XEntregaPedidos") + ": ";
        texto = Generales.getFormatoDecimal(total, "##0");
        if ((cadena.length() + texto.length()) > max2) {
            texto2 = completaHasta(texto, ((max2 * 2) - cadena.length()), TipoAlineacion.DERECHA, true);
        } else {
            texto2 = completaHasta(texto, (max2 - cadena.length()), TipoAlineacion.DERECHA, true);
        }
        texto = completaHasta(texto, (max - cadena.length()) + columna, TipoAlineacion.DERECHA, true);
        cadenaRecibo.append(cadena + texto2 + "\r\n");
        //cadenaRecibo.append("\r\n");
        info.close();
        reportePDF.add(cadena + texto);
        //reportePDF.add(new Paragraph(" ")); //linea en blanco = \r\n

        //total cancelaciones
        cadena = Mensajes.get("XTotalMin") + " " + Mensajes.get("XCancelacionesCliOp") + ": ";
        texto = Generales.getFormatoDecimal(totalCanc, "##0");
        if ((cadena.length() + texto.length()) > max2) {
            texto2 = completaHasta(texto, ((max2 * 2) - cadena.length()), TipoAlineacion.DERECHA, true);
        } else {
            texto2 = completaHasta(texto, (max2 - cadena.length()), TipoAlineacion.DERECHA, true);
        }
        texto = completaHasta(texto, (max - cadena.length()) + columna, TipoAlineacion.DERECHA, true);
        cadenaRecibo.append(cadena + texto2 + "\r\n");
        cadenaRecibo.append("\r\n");
        info.close();
        reportePDF.add(cadena + texto);
        reportePDF.add(new Paragraph(" ")); //linea en blanco = \r\n


        //idataRuta = Consultas.ConsultasRuta.obtenerRutas();
        String rutas = "";
        idataRuta.moveToPosition(-1);
        while (idataRuta.moveToNext()) {
            rutas += "'" + idataRuta.getString("RUTClave") + "',";
        }
        if (rutas.length() != 0)
            rutas = rutas.substring(0, rutas.length() - 1);

        //total ventas
        info = Consultas2.ConsultasTransProd.obtenerTotalVentas(rutas);
        total = 0;
        count = 0;
        while (info.moveToNext()) {
            total += info.getFloat("Total");
            count += info.getInt("TotalPedidos");
        }
        cadena = Mensajes.get("XTotalVentas") + ": ";
        texto = "" + count;
        if ((cadena.length() + texto.length()) > max2) {
            texto2 = completaHasta(texto, ((max2 * 2) - cadena.length()), TipoAlineacion.DERECHA, true);
        } else {
            texto2 = completaHasta(texto, (max2 - cadena.length()), TipoAlineacion.DERECHA, true);
        }
        texto = completaHasta(texto, (max - cadena.length()) + columna, TipoAlineacion.DERECHA, true);
        cadenaRecibo.append(cadena + texto2 + "\r\n");
        reportePDF.add(cadena + texto);
        info.close();
        reportePDF.add(new Paragraph(" ")); //linea en blanco = \r\n

        info = Consultas2.ConsultasTransProd.obtenerVentasOp(rutas);
        total = 0;
        count = 0;
        while (info.moveToNext()) {
            total += info.getFloat("Total");
            count += info.getInt("TotalPedidos");
        }
        cadena = Mensajes.get("XTotalMin") + " " + Mensajes.get("XVentasClienteOp") + ": ";
        texto = "" + count;
        if ((cadena.length() + texto.length()) > max2) {
            texto2 = completaHasta(texto, ((max2 * 2) - cadena.length()), TipoAlineacion.DERECHA, true);
        } else {
            texto2 = completaHasta(texto, (max2 - cadena.length()), TipoAlineacion.DERECHA, true);
        }
        texto = completaHasta(texto, (max - cadena.length()) + columna, TipoAlineacion.DERECHA, true);
        cadenaRecibo.append(cadena + texto2 + "\r\n");
        reportePDF.add(cadena + texto);
        info.close();
        reportePDF.add(new Paragraph(" ")); //linea en blanco = \r\n

        info = Consultas2.ConsultasTransProd.obtenerVentasFueraFrecuencia(rutas);
        total = 0;
        count = 0;
        while (info.moveToNext()) {
            total += info.getFloat("Total");
            count += info.getInt("TotalPedidos");
        }
        cadena = Mensajes.get("XTotalMin") + " " + Mensajes.get("XVentasFueraFrecc") + ": ";
        texto = "" + count;
        if ((cadena.length() + texto.length()) > max2) {
            texto2 = completaHasta(texto, ((max2 * 2) - cadena.length()), TipoAlineacion.DERECHA, true);
        } else {
            texto2 = completaHasta(texto, (max2 - cadena.length()), TipoAlineacion.DERECHA, true);
        }
        texto = completaHasta(texto, (max - cadena.length()) + columna, TipoAlineacion.DERECHA, true);
        cadenaRecibo.append(cadena + texto2 + "\r\n");
        reportePDF.add(cadena + texto);
        info.close();

        idataRuta.close();

        cadenaRecibo.append("\r\n");
        cadenaRecibo.append("\r\n");
        cadenaRecibo.append("\r\n");
        cadenaRecibo.append("\r\n");
        cadenaRecibo.append("\r\n");

        //Generales.remove1(cadenaRecibo);

        document.add(reportePDF);
    }

    private static void generarReportePedidosPreventa(int reporte, StringBuilder cadenaRecibo, Document document) throws Exception {
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
        Vendedor vendedor = (Vendedor) Sesion.get(Campo.VendedorActual);
        setTamanioDefault(vendedor.TipoModImp);
        TamanioLetra tamanioLetra;
        tamanioLetra = tamanioDefault;

        if (vendedor.TipoModImp == TipoPapel.ZEBRA_TERMICA2 || vendedor.TipoModImp == TipoPapel.ZEBRA_CAMEO2) {
            cadena = "{" + tamanioLetra.mTamanio + " " + tamanioLetra.mAlto + "}";
        } else if (vendedor.TipoModImp == TipoPapel.INTERMEC_PR2 || vendedor.TipoModImp == TipoPapel.INTERMEC_PR3) {
            //Se usa el mAlto para indentificar si la letra es normal o doble 0= normal 1= doble
            //En la cadena de los bytes no se debe dejar espacios, si no falla y se consideran hasta el momento
            //3 bytes en el mensaje, por lo que si se mete menos o mas, hay que cambiar el codigo en BluetoothPrint
            if (tamanioLetra.mAlto != 0) {
                cadena = "{27,33," + tamanioLetra.mTamanio + "}";
            } else {
                cadena = "{27,119," + tamanioLetra.mTamanio + "}";
            }
        } else if( vendedor.TipoModImp == TipoPapel.ZEBRA_TERMICA3 ) {
            cadena = "! U1 SETLP 7 " + tamanioLetra.mTamanio + " " + tamanioLetra.mAlto + " ";
        }
        else {
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
        reportePDF.add(vacio);

        ISetDatos pedidos = Consultas.ConsultasTransProd.obtenerPedidosPreventaParaReporte();
//		BaseFont bf = BaseFont.createFont(
//		           "KozMinPro-Regular", "Identity-V", BaseFont.NOT_EMBEDDED);
//		Font font = new Font(bf, 10, Font.BOLD, BaseColor.BLACK);

//		VerticalText vt = new VerticalText(pdfWriter.getDirectContent());
//		vt.setVerticalLayout(document.getPageSize().getWidth() - 40, document.getPageSize().getHeight() - 200, document.getPageSize().getHeight()-220, 40, 16);

        float volumen, total, peso;
        peso = volumen = total = 0;

		/* Encabezados */
        texto = Mensajes.get("XFolio");
        cadena = completaHasta(texto, 12, TipoAlineacion.IZQUIERDA, false);
        texto = Mensajes.get("XCliente");
        cadena += completaHasta(texto, 18, TipoAlineacion.IZQUIERDA, false);
        texto = Mensajes.get("XDomicilioEntrega");
        cadena += completaHasta(texto, 24, TipoAlineacion.IZQUIERDA, false);
        texto = Mensajes.get("TRPFechaCaptura");
        cadena += completaHasta(texto, 14, TipoAlineacion.IZQUIERDA, false);
        texto = Mensajes.get("XFase");
        cadena += completaHasta(texto, 10, TipoAlineacion.IZQUIERDA, false);
        texto = Mensajes.get("XFechaEntrega");
        cadena += completaHasta(texto, 14, TipoAlineacion.IZQUIERDA, false);
        texto = Mensajes.get("XRuta");
        cadena += completaHasta(texto, 14, TipoAlineacion.IZQUIERDA, false);
        texto = Mensajes.get("XVolumen");
        cadena += completaHasta(texto, 8, TipoAlineacion.DERECHA, false);
        texto = Mensajes.get("XKgLts");
        cadena += completaHasta(texto, 8, TipoAlineacion.DERECHA, false);
        texto = Mensajes.get("XMonto");
        cadena += completaHasta(texto, 12, TipoAlineacion.DERECHA, true);

        cadenaRecibo.append(cadena + "\r\n");
        cadenaRecibo.append("\r\n");

        Phrase headers = new Paragraph(cadena, textoNegrita);
        reportePDF.add(headers);
        reportePDF.add(vacio);
//		vt.addText(headers);
//		vt.go();
//		vt.addText(new Chunk("Hola"));
//		vt.go();

//		font = new Font(bf, 9, Font.NORMAL, BaseColor.BLACK);
//		cadena = "";
        Paragraph pedido;
        while (pedidos.moveToNext()) {
            cadena = completaHasta(pedidos.getString("Folio"), 12, TipoAlineacion.IZQUIERDA, false);
            cadena += completaHasta(pedidos.getString("Cliente"), 18, TipoAlineacion.IZQUIERDA, false);
            cadena += completaHasta(pedidos.getString("Domicilio"), 24, TipoAlineacion.IZQUIERDA, false);
            cadena += completaHasta(Generales.getFormatoFecha(pedidos.getDate("FechaCaptura"), "dd/MM/yyyy"), 14, TipoAlineacion.IZQUIERDA, false);
            cadena += completaHasta(pedidos.getString("Fase"), 10, TipoAlineacion.IZQUIERDA, false);
            cadena += completaHasta(Generales.getFormatoFecha(pedidos.getDate("FechaEntrega"), "dd/MM/yyyy"), 14, TipoAlineacion.IZQUIERDA, false);
            cadena += completaHasta(pedidos.getString("Ruta"), 14, TipoAlineacion.IZQUIERDA, false);
            volumen += pedidos.getFloat("Volumen");
            peso += pedidos.getFloat("Peso");
            total += pedidos.getFloat("Monto");
            cadena += completaHasta(Generales.getFormatoDecimal(pedidos.getFloat("Volumen"), 2), 8, TipoAlineacion.DERECHA, false);
            cadena += completaHasta(Generales.getFormatoDecimal(pedidos.getFloat("Peso"), 2), 8, TipoAlineacion.DERECHA, false);
            cadena += completaHasta("$ ".concat(Generales.getFormatoDecimal(pedidos.getFloat("Monto"), "#,###,##0.00")), 12, TipoAlineacion.DERECHA, true);
//			cadena+= "\r\n";
            cadenaRecibo.append(cadena).append("\r\n");

            pedido = new Paragraph(cadena, textoNegrita);
            reportePDF.add(pedido);
//			vt.setAlignment(Element.ALIGN_LEFT);
//			vt.addText(new Phrase(convertCIDs(cadena), font));
//			vt.go();
        }
        reportePDF.add(vacio);

        cadena = completaHasta(Generales.getFormatoDecimal(volumen, 2).concat("  "), 116, TipoAlineacion.DERECHA, false);
        cadena += completaHasta(Generales.getFormatoDecimal(peso, 2).concat("  "), 8, TipoAlineacion.DERECHA, false);
        cadena += completaHasta("$ ".concat(Generales.getFormatoDecimal(total, "#,###,##0.00")), 10, TipoAlineacion.DERECHA, true);

        pedido = new Paragraph(cadena, textoNegrita);
        reportePDF.add(pedido);

        document.add(reportePDF);
    }

    private static void generarReporteCobranza(int reporte, StringBuilder cadenaRecibo, Document document, Cliente cliente) throws Exception {
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

        if (((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.ZEBRA_TERMICA2 || ((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.ZEBRA_CAMEO2) {
            cadena = "{" + tamanioLetra.mTamanio + " " + tamanioLetra.mAlto + "}";
        } else if (((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.INTERMEC_PR2 || ((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.INTERMEC_PR3) {
            //Se usa el mAlto para indentificar si la letra es normal o doble 0= normal 1= doble
            //En la cadena de los bytes no se debe dejar espacios, si no falla y se consideran hasta el momento
            //3 bytes en el mensaje, por lo que si se mete menos o mas, hay que cambiar el codigo en BluetoothPrint
            if (tamanioLetra.mAlto != 0) {
                cadena = "{27,33," + tamanioLetra.mTamanio + "}";
            } else {
                cadena = "{27,119," + tamanioLetra.mTamanio + "}";
            }
        } else if (((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.EXTECH_TERMICA2) {
            //tamanioLetra.mLongTotal = tamanioLetra.mLongTotal - 1;
            max = 37;
            columna = 9;
            cadena = "{" + tamanioLetra.mTamanio + "}";
        } else if( ((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.ZEBRA_TERMICA3 ) {
            cadena = "! U1 SETLP 7 " + tamanioLetra.mTamanio + " " + tamanioLetra.mAlto + " ";
        }
        else {
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

        texto = Mensajes.get("XVendedor") + ": " + ((Usuario) Sesion.get(Campo.UsuarioActual)).Nombre;
        cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, tamanioLetra.mLongTotal);
        cadenaRecibo.append(cadena + "\r\n");

        Paragraph ven = new Paragraph(texto, textoNegrita);
        ven.setAlignment(Element.ALIGN_CENTER);
        reportePDF.add(ven);

        texto = Mensajes.get("XCliente") + ": " + (cliente.RazonSocial != null ? cliente.ClienteClave + " - " + cliente.RazonSocial : cliente.NombreCorto);
        cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, tamanioLetra.mLongTotal);
        cadenaRecibo.append(cadena + "\r\n");

        Paragraph cli = new Paragraph(texto, textoNegrita);
        cli.setAlignment(Element.ALIGN_CENTER);
        reportePDF.add(cli);
        reportePDF.add(new Paragraph(" "));
        reportePDF.add(new Paragraph(" "));

        Font textoDetalle = new Font(Font.FontFamily.COURIER, 19f, Font.BOLD);
        /* Encabezado Linea 1 */
        texto = Mensajes.get("XFolio");
        cadena = completaHasta(texto, 14, TipoAlineacion.IZQUIERDA, false);
        texto = Mensajes.get("XFactura");
        cadena += completaHasta(texto, 14, TipoAlineacion.IZQUIERDA, false);
        texto = Mensajes.get("XTotal");
        cadena += completaHasta(texto, 12, TipoAlineacion.IZQUIERDA, false);
        texto = Mensajes.get("XSaldo");
        cadena += completaHasta(texto, 12, TipoAlineacion.IZQUIERDA, false);
        texto = "   " + Mensajes.get("MDB031601");
        cadena += completaHasta(texto, 14, TipoAlineacion.IZQUIERDA, false);
        texto = Mensajes.get("MDB0314");
        cadena += completaHasta(texto, 12, TipoAlineacion.IZQUIERDA, false);
        texto = Mensajes.get("XFecha");
        cadena += completaHasta(texto, 12, TipoAlineacion.IZQUIERDA, false);
        texto = Mensajes.get("MDB0314");
        cadena += completaHasta(texto, 8, TipoAlineacion.DERECHA, true);

        cadenaRecibo.append(cadena + "\r\n");

        Paragraph encabezado_1 = new Paragraph(cadena, textoDetalle);
        reportePDF.add(encabezado_1);

		/* Encabezado Linea 2 */
        texto = Mensajes.get("XEntrega");
        cadena = completaHasta(texto, 60, TipoAlineacion.DERECHA, false);
        texto = Mensajes.get("XCredito");
        cadena += completaHasta(texto, 12, TipoAlineacion.DERECHA, false);
        texto = Mensajes.get("CLIDiasVencimiento").split(" ")[1];
        cadena += completaHasta(texto, 15, TipoAlineacion.DERECHA, false);
        texto = Mensajes.get("CLIDiasVencimiento").split(" ")[1];
        cadena += completaHasta(texto, 14, TipoAlineacion.DERECHA, true);

        cadenaRecibo.append(cadena + "\r\n");

        Paragraph encabezado_2 = new Paragraph(cadena, textoDetalle);
        reportePDF.add(encabezado_2);
        reportePDF.add(new Paragraph(" ")); //linea en blanco = \r\n

        ISetDatos info;

        info = ConsultasTransProd.obtenerDetalleReporteCobranza(cliente.ClienteClave);

        long dias = Calendar.getInstance().getTimeInMillis();
        Calendar cal;
		/* Agrega las categorias */
        textoDetalle = new Font(Font.FontFamily.COURIER, 19f, Font.NORMAL);
        while (info.moveToNext()) {
            texto = info.getString("Folio");
            cadena = completaHasta(texto, 14, TipoAlineacion.IZQUIERDA, false);
            texto = info.getString("FacturaID") == null ? "" : info.getString("FacturaID");
            cadena += completaHasta(texto, 12, TipoAlineacion.IZQUIERDA, false);
            texto = Generales.getFormatoDecimal(info.getFloat("Total"), "#,###,##0.00");
            cadena += completaHasta(texto, 11, TipoAlineacion.DERECHA, false);
            texto = Generales.getFormatoDecimal(info.getFloat("Saldo"), "#,###,##0.00");
            cadena += completaHasta(texto, 11, TipoAlineacion.DERECHA, false);
            texto = info.getDate("FechaEntrega") == null ? "" : Generales.getFormatoFecha(info.getDate("FechaEntrega"), "dd/MM/yyyy");
            cadena += completaHasta(texto, 14, TipoAlineacion.DERECHA, false);
            texto = String.valueOf(info.getInt("DiasCredito"));
            cadena += completaHasta(texto, 7, TipoAlineacion.DERECHA, false);
            texto = info.getDate("FechaCobranza") == null ? "" : Generales.getFormatoFecha(info.getDate("FechaCobranza"), "dd/MM/yyyy");
            cadena += completaHasta(texto, 17, TipoAlineacion.DERECHA, false);
            if (!texto.isEmpty()) {
                cal = Calendar.getInstance();
                cal.setTime(info.getDate("FechaCobranza"));
                texto = String.valueOf((cal.getTimeInMillis() - dias) / (1000 * 60 * 60 * 24));
            }
            cadena += completaHasta(texto, 10, TipoAlineacion.DERECHA, true);

            cadenaRecibo.append(cadena + "\r\n");
            cadenaRecibo.append("\r\n");

            reportePDF.add(new Paragraph(cadena, textoDetalle));

        }
        info.close();

        texto = Mensajes.get("XSALDOCLIENTE").concat(": $ ") + Generales.getFormatoDecimal(Consultas.ConsultasTransProd.obtenerTotalCobranza(cliente.ClienteClave), "#,###,##0.00");
        cadena = completaHasta(texto, 108, TipoAlineacion.DERECHA, true);

        cadenaRecibo.append(cadena + "\r\n");
        cadenaRecibo.append("\r\n");

        reportePDF.add(new Paragraph(" "));
        reportePDF.add(new Paragraph(cadena, textoNegrita));

        document.add(reportePDF);
    }

    private static void generarReporteCobranzaFacturas(int reporte, StringBuilder cadenaRecibo, Document document, Cliente cliente) throws Exception {
        String cadena = "";
        String cadenaPDF = "";
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

        if (((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.ZEBRA_TERMICA2 || ((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.ZEBRA_CAMEO2) {
            cadena = "{" + tamanioLetra.mTamanio + " " + tamanioLetra.mAlto + "}";
        } else if (((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.INTERMEC_PR2 || ((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.INTERMEC_PR3) {
            //Se usa el mAlto para indentificar si la letra es normal o doble 0= normal 1= doble
            //En la cadena de los bytes no se debe dejar espacios, si no falla y se consideran hasta el momento
            //3 bytes en el mensaje, por lo que si se mete menos o mas, hay que cambiar el codigo en BluetoothPrint
            if (tamanioLetra.mAlto != 0) {
                cadena = "{27,33," + tamanioLetra.mTamanio + "}";
            } else {
                cadena = "{27,119," + tamanioLetra.mTamanio + "}";
            }
        } else if (((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.EXTECH_TERMICA2) {
            //tamanioLetra.mLongTotal = tamanioLetra.mLongTotal - 1;
            max = 37;
            columna = 9;
            cadena = "{" + tamanioLetra.mTamanio + "}";
        } else if( ((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.ZEBRA_TERMICA3 ) {
            cadena = "! U1 SETLP 7 " + tamanioLetra.mTamanio + " " + tamanioLetra.mAlto + " ";
        }
        else {
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
        cadena = alineaTexto(BTIPALI.TipoAlineacion.IZQUIERDA, texto, tamanioLetra.mLongTotal);
        cadenaRecibo.append(cadena + "\r\n");

        Paragraph impresion = new Paragraph(texto, textoNegrita);
        impresion.setAlignment(Element.ALIGN_LEFT);
        reportePDF.add(impresion);

        texto = Mensajes.get("XRuta") + ": " + ruta.RUTClave;
        cadena = alineaTexto(BTIPALI.TipoAlineacion.IZQUIERDA, texto, tamanioLetra.mLongTotal);
        cadenaRecibo.append(cadena + "\r\n");
        cadenaRecibo.append("\r\n");

        Paragraph rut = new Paragraph(texto, textoNegrita);
        rut.setAlignment(Element.ALIGN_LEFT);
        reportePDF.add(rut);

        texto = Mensajes.get("XVendedor") + ": " + ((Usuario) Sesion.get(Campo.UsuarioActual)).Nombre;
        cadena = alineaTexto(BTIPALI.TipoAlineacion.IZQUIERDA, texto, tamanioLetra.mLongTotal);
        cadenaRecibo.append(cadena + "\r\n");

        Paragraph ven = new Paragraph(texto, textoNegrita);
        ven.setAlignment(Element.ALIGN_LEFT);
        reportePDF.add(ven);

        texto = Mensajes.get("XCliente") + ": " + (cliente.RazonSocial != null ? cliente.ClienteClave + " - " + cliente.RazonSocial : cliente.NombreCorto);
        cadena = alineaTexto(BTIPALI.TipoAlineacion.IZQUIERDA, texto, tamanioLetra.mLongTotal);
        cadenaRecibo.append(cadena + "\r\n");
        cadenaRecibo.append("\r\n");

        Paragraph cli = new Paragraph(texto, textoNegrita);
        cli.setAlignment(Element.ALIGN_LEFT);
        reportePDF.add(cli);
        reportePDF.add(new Paragraph(" "));

        Font textoDetalle = new Font(Font.FontFamily.COURIER, 19f, Font.BOLD);
        /* Encabezado Linea 1 */
        texto = Mensajes.get("XFactura");
        cadenaPDF = completaHasta(texto, 15, TipoAlineacion.IZQUIERDA, false);
        cadena = completaHasta(texto, 10, TipoAlineacion.IZQUIERDA, false);
        texto = Mensajes.get("XTotalMin");
        cadenaPDF += completaHasta(texto, 15, TipoAlineacion.DERECHA, false);
        cadena += completaHasta(texto, 12, TipoAlineacion.DERECHA, false);
        texto = Mensajes.get("XSaldo");
        cadenaPDF += completaHasta(texto, 15, TipoAlineacion.DERECHA, false);
        cadena += completaHasta(texto, 12, TipoAlineacion.DERECHA, false);
        texto = Mensajes.get("XFecha");
        cadenaPDF += completaHasta(texto, 15, TipoAlineacion.DERECHA, false);
        cadena += completaHasta(texto, 12, TipoAlineacion.DERECHA, false);
        texto = Mensajes.get("XFecha");
        cadenaPDF += completaHasta(texto, 15, TipoAlineacion.DERECHA, true);
        cadena += completaHasta(texto, 12, TipoAlineacion.DERECHA, false);

        cadenaRecibo.append(cadena + "\r\n");

        Paragraph encabezado_1 = new Paragraph(cadenaPDF, textoDetalle);
        reportePDF.add(encabezado_1);

        	/* Encabezado Linea 2 */
        texto = Mensajes.get("XFacturacion");
        cadena = completaHasta(texto, 46, TipoAlineacion.DERECHA, false);
        cadenaPDF = completaHasta(texto, 60, TipoAlineacion.DERECHA, false);
        texto = Mensajes.get("XVencimiento");
        cadena += completaHasta(texto, 12, TipoAlineacion.DERECHA, true);
        cadenaPDF += completaHasta(texto, 15, TipoAlineacion.DERECHA, true);

        cadenaRecibo.append(cadena + "\r\n");

        Paragraph encabezado_2 = new Paragraph(cadenaPDF, textoDetalle);
        reportePDF.add(encabezado_2);

        ISetDatos info;

        info = ConsultasTransProd.obtenerFacturasReporteCobranza(cliente.ClienteClave);

        long dias = Calendar.getInstance().getTimeInMillis();
        Calendar cal;
        float saldoCliente = 0;
		/* Agrega las categorias */
        textoDetalle = new Font(Font.FontFamily.COURIER, 19f, Font.NORMAL);
        while (info.moveToNext()) {
            texto = info.getString("Folio");
            cadenaPDF = completaHasta(texto, 15, TipoAlineacion.IZQUIERDA, false);
            cadena = completaHasta(texto, 10, TipoAlineacion.IZQUIERDA, false);
            texto = "$" + Generales.getFormatoDecimal(info.getFloat("Total"), "#,###,##0.00");
            cadenaPDF += completaHasta(texto, 15, TipoAlineacion.DERECHA, false);
            cadena += completaHasta(texto, 12, TipoAlineacion.DERECHA, false);
            texto = "$" + Generales.getFormatoDecimal(info.getFloat("Saldo"), "#,###,##0.00");
            cadenaPDF += completaHasta(texto, 15, TipoAlineacion.DERECHA, false);
            cadena += completaHasta(texto, 12, TipoAlineacion.DERECHA, false);
            texto = info.getDate("FechaFacturacion") == null ? "" : Generales.getFormatoFecha(info.getDate("FechaFacturacion"), "dd/MM/yyyy");
            cadenaPDF += completaHasta(texto, 15, TipoAlineacion.DERECHA, false);
            cadena += completaHasta(texto, 12, TipoAlineacion.DERECHA, false);
            texto = info.getDate("FechaCobranza") == null ? "" : Generales.getFormatoFecha(info.getDate("FechaCobranza"), "dd/MM/yyyy");
            cadenaPDF += completaHasta(texto, 15, TipoAlineacion.DERECHA, true);
            cadena += completaHasta(texto, 12, TipoAlineacion.DERECHA, true);

            cadenaRecibo.append(cadena + "\r\n");
            cadenaRecibo.append("\r\n");

            reportePDF.add(new Paragraph(cadenaPDF, textoDetalle));
            saldoCliente += info.getFloat("Saldo");
        }
        info.close();

        texto = Mensajes.get("XSALDOCLIENTE").concat(": $ ") + Generales.getFormatoDecimal(saldoCliente, "#,###,##0.00");
        cadena = completaHasta(texto, 58, TipoAlineacion.DERECHA, true);
        cadenaPDF = completaHasta(texto, 75, TipoAlineacion.DERECHA, true);

        cadenaRecibo.append(cadena + "\r\n");
        cadenaRecibo.append("\r\n");

        textoDetalle = new Font(Font.FontFamily.COURIER, 19f, Font.BOLD);
        reportePDF.add(new Paragraph(" "));
        reportePDF.add(new Paragraph(cadenaPDF, textoDetalle));

        document.add(reportePDF);
    }

    private static void generarReporteConfirmacionPedidosSAP(int reporte, StringBuilder cadenaRecibo, Document document, Cliente cliente, String filtroFechas, Date fechaIni, Date fechaFin) throws Exception {
        String cadena = "";
        String texto = "";
        int columna = 10;
        int max = 40;
        //Obtiene Rutas
        ISetDatos idataRuta = Consultas.ConsultasRuta.obtenerRutas();
        idataRuta.moveToFirst();
        Ruta ruta = new Ruta();
        ruta.RUTClave = idataRuta.getString("RUTClave");
        BDVend.recuperar(ruta);
        idataRuta.close();

        Paragraph reportePDF = new Paragraph();
        Paragraph vacio = new Paragraph(" ");
        reportePDF.setFont(textoNegrita);
        Vendedor vendedor = (Vendedor) Sesion.get(Campo.VendedorActual);
        setTamanioDefault(vendedor.TipoModImp);
        TamanioLetra tamanioLetra;
        tamanioLetra = tamanioDefault;

        if (vendedor.TipoModImp == TipoPapel.ZEBRA_TERMICA2 || vendedor.TipoModImp == TipoPapel.ZEBRA_CAMEO2) {
            cadena = "{" + tamanioLetra.mTamanio + " " + tamanioLetra.mAlto + "}";
        } else if (vendedor.TipoModImp == TipoPapel.INTERMEC_PR2 || vendedor.TipoModImp == TipoPapel.INTERMEC_PR3) {
            //Se usa el mAlto para indentificar si la letra es normal o doble 0= normal 1= doble
            //En la cadena de los bytes no se debe dejar espacios, si no falla y se consideran hasta el momento
            //3 bytes en el mensaje, por lo que si se mete menos o mas, hay que cambiar el codigo en BluetoothPrint
            if (tamanioLetra.mAlto != 0) {
                cadena = "{27,33," + tamanioLetra.mTamanio + "}";
            } else {
                cadena = "{27,119," + tamanioLetra.mTamanio + "}";
            }
        } else if( vendedor.TipoModImp == TipoPapel.ZEBRA_TERMICA3 ) {
            cadena = "! U1 SETLP 7 " + tamanioLetra.mTamanio + " " + tamanioLetra.mAlto + " ";
        }
        else {
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

        Paragraph rut = new Paragraph(texto, textoNegrita);
        rut.setAlignment(Element.ALIGN_CENTER);
        reportePDF.add(rut);

        texto = Mensajes.get("XCliente") + ": " + (cliente == null ? Mensajes.get("XTodos") : cliente.NombreCorto);
        cadena = alineaTexto(BTIPALI.TipoAlineacion.IZQUIERDA, texto, tamanioLetra.mLongTotal);
        cadenaRecibo.append(cadena + "\r\n");

        Paragraph filtroCte = new Paragraph(texto, textoNegrita);
        filtroCte.setAlignment(Element.ALIGN_LEFT);
        reportePDF.add(filtroCte);

        texto = Mensajes.get("XFecha") + ": " + (filtroFechas.equals("") ? Mensajes.get("XTodos") : Generales.getFormatoFecha(fechaIni, "dd/MM/yyyy") + ( fechaFin.compareTo(fechaIni) >0 ? " - " + Generales.getFormatoFecha(fechaFin, "dd/MM/yyyy") : ""));
        cadena = completaHasta(texto, tamanioLetra.mLongTotal, TipoAlineacion.IZQUIERDA, true);
        cadenaRecibo.append(cadena + "\r\n");

        Paragraph filtroFecha = new Paragraph(cadena, tituloSubrayado);
        filtroFecha.setAlignment(Element.ALIGN_LEFT);
        reportePDF.add(filtroFecha);
        reportePDF.add(" ");

        StringBuilder sbLinea = new StringBuilder();
        String lineapunteada = "";
        imprimeLineaPunteada(sbLinea,tamanioLetra.mLongTotal);
        cadena = alineaTexto(BTIPALI.TipoAlineacion.IZQUIERDA, sbLinea.toString(), tamanioLetra.mLongTotal);
        lineapunteada = cadena;
        cadenaRecibo.append(cadena + "\r\n");

        String cadenaTituloDetalle1 = "";
        texto = Mensajes.get("XCodigo");
        cadena = completaHasta(texto, 9, TipoAlineacion.IZQUIERDA, false);
        texto = Mensajes.get("XDescripcion");
        cadena += completaHasta(texto, tamanioLetra.mLongTotal - 19, TipoAlineacion.IZQUIERDA, false);
        texto = Mensajes.get("XUnidad");
        cadena += completaHasta(texto, 10, TipoAlineacion.DERECHA, true);

        cadenaTituloDetalle1 = cadena;

        Paragraph tituloDetalle1 = new Paragraph(cadena, tituloSubrayado);
        //reportePDF.add(tituloDetalle1);
        //reportePDF.add(linea);

        String cadenaTituloDetalle2 = "";
        texto = Mensajes.get("XCantOriginal");
        cadena = completaHasta(texto, 15, TipoAlineacion.DERECHA, false);
        texto = "Cant. Conf";
        cadena += completaHasta(texto, 11, TipoAlineacion.DERECHA, false);
        texto = Mensajes.get("XTotalMin");
        cadena += completaHasta(texto,tamanioLetra.mLongTotal - 26 , TipoAlineacion.DERECHA, true);

        cadenaTituloDetalle2 = cadena;

        Paragraph tituloDetalle2 = new Paragraph(cadena, tituloSubrayado);

        ISetDatos pedidosConfirmados = Consultas.ConsultasPedidosConfirmadosSAP.obtenerReporteConfirmadosSAP(filtroFechas, (cliente != null ? cliente.ClienteClave : ""));
        String clienteActual = "";
        String pedidoActual = "";
        while (pedidosConfirmados.moveToNext()){
            if (!pedidosConfirmados.getString("ClienteClave").equalsIgnoreCase(clienteActual)){
                if (!clienteActual.equals("")){
                    reportePDF.add(new Paragraph(completaHasta("",tamanioLetra.mLongTotal, TipoAlineacion.IZQUIERDA, true),tituloSubrayado));
                    cadenaRecibo.append(lineapunteada);
                }
                clienteActual = pedidosConfirmados.getString("ClienteClave");
                texto = Mensajes.get("XCliente") + ": " + clienteActual + "-" +pedidosConfirmados.getString("RazonSocial") ;
                cadena = completaHasta(texto, tamanioLetra.mLongTotal , TipoAlineacion.IZQUIERDA, true);
                cadenaRecibo.append(cadena + "\r\n");
                reportePDF.add(new Paragraph(cadena, textoNegrita));

                texto = Mensajes.get("XCliente") + " " +  Mensajes.get("XSAP") + ": " + pedidosConfirmados.getString("ClienteSAP");
                cadena = completaHasta(texto, tamanioLetra.mLongTotal, TipoAlineacion.IZQUIERDA, true);
                cadenaRecibo.append(cadena + "\r\n");
                cadenaRecibo.append("\r\n");
                reportePDF.add(new Paragraph(cadena, textoNegrita));
                reportePDF.add(" ");
            }

            if(!pedidosConfirmados.getString("PedidoSAP").equalsIgnoreCase(pedidoActual)) {
                pedidoActual =pedidosConfirmados.getString("PedidoSAP");

                texto = Mensajes.get("XFecha") + " " + Mensajes.get("XPedido") + ": " + Generales.getFormatoFecha(pedidosConfirmados.getDate("FechaPedido"), "dd/MM/yyyy") ;
                cadena = completaHasta(texto, tamanioLetra.mLongTotal, TipoAlineacion.IZQUIERDA, true);
                cadenaRecibo.append(cadena + "\r\n");
                reportePDF.add(new Paragraph(cadena, textoNegrita));

                texto = Mensajes.get("XFolioPedido") + " " + Mensajes.get("XSAP") +  ": " + pedidosConfirmados.getString("PedidoSAP");
                cadena = completaHasta(texto,tamanioLetra.mLongTotal , TipoAlineacion.IZQUIERDA, true);
                cadenaRecibo.append(cadena + "\r\n");
                reportePDF.add(new Paragraph(cadena, textoNegrita));

                texto = Mensajes.get("XPedidoeRoute") + ": " + pedidosConfirmados.getString("Folio");
                cadena = completaHasta(texto,tamanioLetra.mLongTotal , TipoAlineacion.IZQUIERDA, true);
                cadenaRecibo.append(cadena + "\r\n");
                reportePDF.add(new Paragraph(cadena, textoNegrita));

                texto = Mensajes.get("XImporteT") + ": $" + Generales.getFormatoDecimal(pedidosConfirmados.getFloat("ValorNeto"),"#,##0.00");  //Dar de alta mensaje
                cadena = completaHasta(texto, tamanioLetra.mLongTotal, TipoAlineacion.IZQUIERDA, true);
                cadenaRecibo.append(cadena + "\r\n");
                reportePDF.add(new Paragraph(cadena, textoNegrita));

                texto = Mensajes.get("XEstatus") + ": " +  pedidosConfirmados.getString("Estatus") ;   //cambiar el tipo del mensaje para que se suba
                cadena = completaHasta(texto, tamanioLetra.mLongTotal, TipoAlineacion.IZQUIERDA, true);
                cadenaRecibo.append(cadena + "\r\n");
                reportePDF.add(new Paragraph(cadena, textoNegrita));

                reportePDF.add(tituloDetalle1);
                reportePDF.add(tituloDetalle2);
                cadenaRecibo.append(cadenaTituloDetalle1 + "\r\n");
                cadenaRecibo.append(cadenaTituloDetalle2 + "\r\n");
                cadenaRecibo.append(lineapunteada);
            }

            texto = pedidosConfirmados.getString("ProductoClave");
            cadena = completaHasta(texto, 9, TipoAlineacion.IZQUIERDA, false);
            texto = pedidosConfirmados.getString("Nombre");
            cadena += completaHasta(texto, tamanioLetra.mLongTotal - 19, TipoAlineacion.IZQUIERDA, false);
            texto =ValoresReferencia.getDescripcion("UNIDADV", pedidosConfirmados.getString("TipoUnidad"));
            cadena += completaHasta(texto,10 , TipoAlineacion.DERECHA, true);

            cadenaRecibo.append(cadena + "\r\n");
            reportePDF.add(new Paragraph(cadena, textoNegrita));

            texto = pedidosConfirmados.getString("CantidadOriginal");
            cadena = completaHasta(texto, 15, TipoAlineacion.DERECHA, false);
            texto =  pedidosConfirmados.getString("Cantidad");
            cadena += completaHasta(texto, 11, TipoAlineacion.DERECHA, false);
            texto = "$" + Generales.getFormatoDecimal(pedidosConfirmados.getDouble("Total"), "#,##0.00");
            cadena += completaHasta(texto, tamanioLetra.mLongTotal - 26, TipoAlineacion.DERECHA, true);


            cadenaRecibo.append(cadena + "\r\n");
            reportePDF.add(new Paragraph(cadena, textoNegrita));
        }
        cadenaRecibo.append( "\r\n");
        cadenaRecibo.append( "\r\n");
        cadenaRecibo.append( "\r\n");
        cadenaRecibo.append( "\r\n");

        pedidosConfirmados.close();

//		reportePDF.add(vacio);
        document.add(reportePDF);

    }

    private static void generarReporteResumenCobranzaGenerico(int reporte, StringBuilder cadenaRecibo, Document document) throws Exception {
        String cadena = "";
        String cadena2 = "";
        String texto = "";
        String texto2 = "";
        int columna = 10;
        int max = 38;
        int max2 = 38;

        Paragraph reportePDF = new Paragraph();
        reportePDF.setFont(textoNegrita); //letra general para el reporte

        setTamanioDefault(((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp);
        TamanioLetra tamanioLetra;
        tamanioLetra = tamanioDefault;

        String diaClave = Sesion.get(Campo.FiltroReporteDiaClave).toString();

        if (((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.ZEBRA_TERMICA2 || ((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.ZEBRA_CAMEO2) {
            cadena = "{" + tamanioLetra.mTamanio + " " + tamanioLetra.mAlto + "}";
        } else if (((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.INTERMEC_PR2 || ((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.INTERMEC_PR3) {
            //Se usa el mAlto para indentificar si la letra es normal o doble 0= normal 1= doble
            //En la cadena de los bytes no se debe dejar espacios, si no falla y se consideran hasta el momento
            //3 bytes en el mensaje, por lo que si se mete menos o mas, hay que cambiar el codigo en BluetoothPrint
            if (tamanioLetra.mAlto != 0) {
                cadena = "{27,33," + tamanioLetra.mTamanio + "}";
            }
            else
            {
                cadena = "{27,119," + tamanioLetra.mTamanio + "}";
            }
        }   else if( ((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.ZEBRA_TERMICA3 ) {
            cadena = "! U1 SETLP 7 " + tamanioLetra.mTamanio + " " + tamanioLetra.mAlto + " ";
        }
        else
        {
            cadena = "{" + tamanioLetra.mTamanio + "}";
            if (((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.SEWOO) {
                max2 = 32;
            }
        }
        columna = tamanioLetra.mLongTotal/5 ;

        ISetDatos encabezado = ConsultasImpresionTicket.obtenerEncabezado();
        encabezado.moveToFirst();

        texto = encabezado.getString("NombreEmpresa");
        cadena = cadena + alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, columna*5);
        cadenaRecibo.append(cadena + "\r\n");

        Paragraph empresa = new Paragraph(texto, textoNegrita);
        empresa.setAlignment(Element.ALIGN_CENTER);
        reportePDF.add(empresa);

        texto = encabezado.getString("RFC");
        cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, columna*5);
        cadenaRecibo.append(cadena + "\r\n");

        Paragraph rfc = new Paragraph(texto, textoNegrita);
        rfc.setAlignment(Element.ALIGN_CENTER);
        reportePDF.add(rfc);

        texto = encabezado.getString("Calle") + " " + encabezado.getString("Numero") + ", "+ Mensajes.get("XCol")+ " " + encabezado.getString("Colonia")+",";
        cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, columna*5);
        cadenaRecibo.append(cadena + "\r\n");

        Paragraph domicilio = new Paragraph(texto, textoNegrita);
        domicilio.setAlignment(Element.ALIGN_CENTER);
        reportePDF.add(domicilio);

        texto = encabezado.getString("Ciudad") + ", " + encabezado.getString("Region");
        cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, columna*5);
        cadenaRecibo.append(cadena + "\r\n");

        Paragraph ciudad = new Paragraph(texto, textoNegrita);
        ciudad.setAlignment(Element.ALIGN_CENTER);
        reportePDF.add(ciudad);

        cadenaRecibo.append("\r\n");
        reportePDF.add(new Paragraph(" ")); //linea en blanco = \r\n

        texto = Mensajes.get("XImpresion") + ": " + Generales.getFechaHoraActualStr("dd/MM/yyyy hh:mm:ss");
        cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, columna*5);
        cadenaRecibo.append(cadena + "\r\n");

        Paragraph impresion = new Paragraph(texto, textoNegrita);
        impresion.setAlignment(Element.ALIGN_CENTER);
        reportePDF.add(impresion);

        texto = Mensajes.get("XVendedor") + ": " + ((Usuario) Sesion.get(Campo.UsuarioActual)).Nombre;
        cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, columna*5);
        cadenaRecibo.append(cadena + "\r\n");

        Paragraph ven = new Paragraph(texto, textoNegrita);
        ven.setAlignment(Element.ALIGN_CENTER);
        reportePDF.add(ven);

        cadenaRecibo.append("\r\n");
        reportePDF.add(new Paragraph(" ")); //linea en blanco = \r\n

        texto = ValoresReferencia.getDescripcion("REPORTEA", String.valueOf(reporte));
        cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, columna*5);

        cadenaRecibo.append(cadena + "\r\n");
        cadenaRecibo.append("\r\n");

        Paragraph titulo = new Paragraph(texto, tituloRojo);
        titulo.setAlignment(Element.ALIGN_CENTER);
        reportePDF.add(titulo);
        reportePDF.add(new Paragraph(" ")); //linea en blanco = \r\n

        encabezado.close();

        //////COLUMNA
        imprimeLineaPunteada(cadenaRecibo, columna*5);

        texto = StringUtils.rightPad(Mensajes.get("XFolio"), 16);
        texto += StringUtils.center(Mensajes.get("XFVenta"), 10);
        texto += StringUtils.center(Mensajes.get("XImporte"), 10);
        texto += StringUtils.center(Mensajes.get("XAbono"), 10);

        texto2 = StringUtils.rightPad(Mensajes.get("XFolio"), columna*2);
        texto2 += StringUtils.center(Mensajes.get("XFormaVenta"), columna);
        texto2 += StringUtils.center(Mensajes.get("XImporte"), columna);
        texto2 += StringUtils.center(Mensajes.get("XAbono"), columna);


        cadena = alineaTexto(BTIPALI.TipoAlineacion.IZQUIERDA, texto2, columna*5);
        cadenaRecibo.append(cadena + "\r\n");

        Paragraph encabezadoFolio = new Paragraph(texto, textoNegrita);
        encabezadoFolio.setAlignment(Element.ALIGN_LEFT);
        reportePDF.add(encabezadoFolio);

        imprimeLineaPunteada(cadenaRecibo, columna*5);

        ArrayList<Cliente> clientes = (ArrayList<Cliente>) Sesion.get(Campo.FiltroReporteCliente);
        ArrayList<Cliente> clientesSeleccionados = new ArrayList<>();
        for(Cliente cliente : clientes){
            if(cliente.Enviado)
                clientesSeleccionados.add(cliente);
        }

        double granTotal = 0;
        ISetDatos cobranzaCliente;

        String folio;
        String formaVenta;
        String importe;
        String abono;
        String saldo;

        for(Cliente cliente : clientesSeleccionados){

            boolean primeraIteracion = true;
            boolean hayCobranza = false;
            double totalAbono = 0;
            cobranzaCliente = Consultas.ConsultasTransProd.obtenerResumenCobranzaPorCliente(diaClave, cliente.ClienteClave);

            while (cobranzaCliente.moveToNext()){

                if(primeraIteracion){
                    primeraIteracion = false;
                    texto = StringUtils.rightPad(cobranzaCliente.getString("Clave"),14) + cobranzaCliente.getString("NombreCorto");
                    texto2 = StringUtils.rightPad(cobranzaCliente.getString("Clave"),cobranzaCliente.getString("Clave").length()+2) + cobranzaCliente.getString("NombreCorto");

                    cadena = alineaTexto(BTIPALI.TipoAlineacion.IZQUIERDA, texto2, columna*5);
                    cadenaRecibo.append(cadena + "\r\n");
                    cadenaRecibo.append("\r\n");

                    Paragraph datosCliente = new Paragraph(texto, textoNegrita);
                    datosCliente.setAlignment(Element.ALIGN_LEFT);
                    reportePDF.add(datosCliente);
                    reportePDF.add(new Paragraph(" "));
                }

                folio = cobranzaCliente.getString("Folio");
                formaVenta = ValoresReferencia.getDescripcion("FVENTA", cobranzaCliente.getString("FormaVenta"));
                importe = "$"+Generales.getFormatoDecimal(cobranzaCliente.getDouble("Importe"),2);
                abono = "$"+Generales.getFormatoDecimal(cobranzaCliente.getDouble("Abono"),2);
                saldo = "$"+Generales.getFormatoDecimal(cobranzaCliente.getDouble("Saldo"),2);


                texto = StringUtils.rightPad(folio,16) + StringUtils.center(formaVenta, 10) +
                        StringUtils.leftPad(importe, 10) +  StringUtils.leftPad(abono, 10);

                texto2 = StringUtils.rightPad(folio,columna*2) + StringUtils.center(formaVenta, columna) +
                        StringUtils.leftPad(importe, columna) +  StringUtils.leftPad(abono, columna);

                cadena = alineaTexto(BTIPALI.TipoAlineacion.IZQUIERDA, texto2, columna*5);
                cadenaRecibo.append(cadena + "\r\n");

                Paragraph cobranzaRow = new Paragraph(texto, textoNegrita);
                cobranzaRow.setAlignment(Element.ALIGN_LEFT);
                reportePDF.add(cobranzaRow);

                texto = StringUtils.leftPad(Mensajes.get("XSaldo"),26) + StringUtils.leftPad(saldo,20);

                texto2 = StringUtils.leftPad(Mensajes.get("XSaldo"),columna*3) + StringUtils.leftPad(saldo,columna*2);

                cadena = alineaTexto(BTIPALI.TipoAlineacion.IZQUIERDA, texto2, columna*5);
                cadenaRecibo.append(cadena + "\r\n");

                cobranzaRow = new Paragraph(texto, textoNegrita);
                cobranzaRow.setAlignment(Element.ALIGN_LEFT);
                reportePDF.add(cobranzaRow);

                totalAbono += Double.parseDouble(cobranzaCliente.getString("Abono"));
                hayCobranza = true;
            }

            if(hayCobranza){

                cobranzaCliente.close();
                texto =StringUtils.leftPad(Mensajes.get("XTotalAbonos"),26) + StringUtils.leftPad("$"+Generales.getFormatoDecimal(totalAbono, 2),20);

                texto2 = StringUtils.leftPad(Mensajes.get("XTotalAbonos"), columna * 3) + StringUtils.leftPad("$"+Generales.getFormatoDecimal(totalAbono, 2),columna*2);

                cadena = alineaTexto(BTIPALI.TipoAlineacion.IZQUIERDA, texto2, columna*5);
                cadenaRecibo.append(cadena + "\r\n");

                Paragraph totalSaldoP = new Paragraph(texto, textoNegrita);
                totalSaldoP.setAlignment(Element.ALIGN_LEFT);
                reportePDF.add(totalSaldoP);

                reportePDF.add(new Paragraph(" "));

                granTotal += totalAbono;
            }

        }

        imprimeLineaPunteada(cadenaRecibo, columna*5);
        texto = StringUtils.leftPad(Mensajes.get("XGRANTOTAL"),26) + StringUtils.leftPad("$"+Generales.getFormatoDecimal(granTotal,2),20);

        texto2 =  StringUtils.leftPad(Mensajes.get("XGRANTOTAL"), columna * 3) + StringUtils.leftPad("$"+Generales.getFormatoDecimal(granTotal, 2),columna*2);

        cadena = alineaTexto(BTIPALI.TipoAlineacion.IZQUIERDA, texto2, columna*5);
        cadenaRecibo.append(cadena + "\r\n");

        Paragraph granTotalP = new Paragraph(texto, textoNegrita);
        granTotalP.setAlignment(Element.ALIGN_LEFT);
        reportePDF.add(granTotalP);

        document.add(reportePDF);

	    cadenaRecibo.append("\r\n");
	    cadenaRecibo.append("\r\n");
	    cadenaRecibo.append("\r\n");
	    cadenaRecibo.append("\r\n");
	    cadenaRecibo.append("\r\n");
	    cadenaRecibo.append("\r\n");
    }

    private static void generarReportePrepedido(int reporte, StringBuilder cadenaRecibo, Document document) throws Exception {
        String cadena = "";
        String cadena2 = "";
        String texto = "";
        String texto2 = "";
        int columna = 10;
        int columnas;
        int max = 38;
        int max2 = 38;

        Paragraph reportePDF = new Paragraph();
        reportePDF.setFont(textoNegrita); //letra general para el reporte

        String diaClave = Sesion.get(Campo.FiltroReporteDiaClave).toString();
        Cliente cliente = (Cliente) Sesion.get(Campo.FiltroReporteCliente);

        setTamanioDefault(((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp);
        TamanioLetra tamanioLetra;
        tamanioLetra = tamanioDefault;

        if (((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.ZEBRA_TERMICA2 || ((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.ZEBRA_CAMEO2) {
            cadena = "{" + tamanioLetra.mTamanio + " " + tamanioLetra.mAlto + "}";
        } else if (((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.INTERMEC_PR2 || ((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.INTERMEC_PR3) {
            //Se usa el mAlto para indentificar si la letra es normal o doble 0= normal 1= doble
            //En la cadena de los bytes no se debe dejar espacios, si no falla y se consideran hasta el momento
            //3 bytes en el mensaje, por lo que si se mete menos o mas, hay que cambiar el codigo en BluetoothPrint
            if (tamanioLetra.mAlto != 0) {
                cadena = "{27,33," + tamanioLetra.mTamanio + "}";
            } else {
                cadena = "{27,119," + tamanioLetra.mTamanio + "}";
            }
        } else if (((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.ZEBRA_TERMICA3) {
            cadena = "! U1 SETLP 7 " + tamanioLetra.mTamanio + " " + tamanioLetra.mAlto + " ";
        } else {
            cadena = "{" + tamanioLetra.mTamanio + "}";
            if (((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.SEWOO) {
                max2 = 32;
            }
        }
        columnas = 12;
        columna = tamanioLetra.mLongTotal / columnas;

        ISetDatos encabezado = ConsultasImpresionTicket.obtenerEncabezado();
        encabezado.moveToFirst();

        texto = encabezado.getString("NombreEmpresa");
        cadena = cadena + alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, columna*columnas);
        cadenaRecibo.append(cadena + "\r\n");

        Paragraph empresa = new Paragraph(texto, textoNegrita);
        empresa.setAlignment(Element.ALIGN_CENTER);
        reportePDF.add(empresa);

        texto = encabezado.getString("RFC");
        cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, columna*columnas);
        cadenaRecibo.append(cadena + "\r\n");

        Paragraph rfc = new Paragraph(texto, textoNegrita);
        rfc.setAlignment(Element.ALIGN_CENTER);
        reportePDF.add(rfc);

        texto = encabezado.getString("Calle") + " " + encabezado.getString("Numero") + ", " + Mensajes.get("XCol") + " " + encabezado.getString("Colonia") + ",";
        cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, columna*columnas);
        cadenaRecibo.append(cadena + "\r\n");

        Paragraph domicilio = new Paragraph(texto, textoNegrita);
        domicilio.setAlignment(Element.ALIGN_CENTER);
        reportePDF.add(domicilio);

        texto = encabezado.getString("Ciudad") + ", " + encabezado.getString("Region");
        cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, columna*columnas);
        cadenaRecibo.append(cadena + "\r\n");

        Paragraph ciudad = new Paragraph(texto, textoNegrita);
        ciudad.setAlignment(Element.ALIGN_CENTER);
        reportePDF.add(ciudad);

        cadenaRecibo.append("\r\n");
        reportePDF.add(new Paragraph(" ")); //linea en blanco = \r\n

        texto = Mensajes.get("XImpresion") + ": " + Generales.getFechaHoraActualStr("dd/MM/yyyy hh:mm:ss");
        cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, columna*columnas);
        cadenaRecibo.append(cadena + "\r\n");

        Paragraph impresion = new Paragraph(texto, textoNegrita);
        impresion.setAlignment(Element.ALIGN_CENTER);
        reportePDF.add(impresion);

        texto = Mensajes.get("XVendedor") + ": " + ((Usuario) Sesion.get(Campo.UsuarioActual)).Nombre;
        cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, columna*columnas);
        cadenaRecibo.append(cadena + "\r\n");

        Paragraph ven = new Paragraph(texto, textoNegrita);
        ven.setAlignment(Element.ALIGN_CENTER);
        reportePDF.add(ven);

        cadenaRecibo.append("\r\n");
        reportePDF.add(new Paragraph(" ")); //linea en blanco = \r\n

        texto = ValoresReferencia.getDescripcion("REPORTEA", String.valueOf(reporte));
        cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, columna*columnas);

        cadenaRecibo.append(cadena + "\r\n");
        cadenaRecibo.append("\r\n");

        Paragraph titulo = new Paragraph(texto, tituloRojo);
        titulo.setAlignment(Element.ALIGN_CENTER);
        reportePDF.add(titulo);
        reportePDF.add(new Paragraph(" ")); //linea en blanco = \r\n

        encabezado.close();

        BDVend.recuperar(cliente);
        //datos del cliente
        texto = StringUtils.rightPad(Mensajes.get("XClave") + ":", 16) +StringUtils.rightPad(cliente.Clave, 32);

        texto2 = StringUtils.rightPad(Mensajes.get("XClave") + ":", columna*4) +StringUtils.rightPad(cliente.Clave, columna*8);

        cadena = alineaTexto(BTIPALI.TipoAlineacion.IZQUIERDA, texto2, columna*columnas);
        cadenaRecibo.append(cadena + "\r\n");

        Paragraph clienteClaveRow = new Paragraph(texto, textoNegrita);
        clienteClaveRow .setAlignment(Element.ALIGN_LEFT);
        reportePDF.add(clienteClaveRow);

        texto = StringUtils.rightPad(Mensajes.get("XRazonSocial") + ":", 16) +StringUtils.rightPad(cliente.RazonSocial, 32);

        texto2 = StringUtils.rightPad(Mensajes.get("XRazonSocial") + ":", columna*4) +StringUtils.rightPad(cliente.RazonSocial, columna*8);

        cadena = alineaTexto(BTIPALI.TipoAlineacion.IZQUIERDA, texto2, columna*columnas);
        cadenaRecibo.append(cadena + "\r\n");

        Paragraph razonSocialRow = new Paragraph(texto, textoNegrita);
        razonSocialRow .setAlignment(Element.ALIGN_LEFT);
        reportePDF.add(razonSocialRow);

        texto = StringUtils.rightPad(Mensajes.get("XNombreCorto") + ":", 16) +StringUtils.rightPad(cliente.NombreCorto, 32);

        texto2 = StringUtils.rightPad(Mensajes.get("XNombreCorto") + ":", columna*4) +StringUtils.rightPad(cliente.NombreCorto, columna*8);

        cadena = alineaTexto(BTIPALI.TipoAlineacion.IZQUIERDA, texto2, columna*columnas);
        cadenaRecibo.append(cadena + "\r\n");
        cadenaRecibo.append("\r\n");

        Paragraph nombreCortoRow = new Paragraph(texto, textoNegrita);
        nombreCortoRow .setAlignment(Element.ALIGN_LEFT);
        reportePDF.add(nombreCortoRow);

        //////COLUMNA
        ISetDatos prepedidos = Consultas.ConsultasTransProd.obtenerPrepedidos(diaClave, cliente.ClienteClave);
        String transProdIDActual = "";


        String prod;
        Date fechaCaptura;
        String nombreCorto;
        String unidad;
        String cant;
        String precio;

        while (prepedidos.moveToNext()){

            if(!StringUtils.equals(prepedidos.getString("TransProdID"),transProdIDActual)){

                fechaCaptura = prepedidos.getDate("FechaCaptura");

                texto = StringUtils.rightPad(Mensajes.get("TRPFechaCaptura") + ":", 12) +
                        StringUtils.rightPad(Generales.getFormatoFecha(fechaCaptura,"MM/dd/yy"), 12) +
                        StringUtils.leftPad(Mensajes.get("TRPFolio") + ":", 12) +
                        StringUtils.rightPad(prepedidos.getString("Folio"), 12);

                texto2 = StringUtils.rightPad(Mensajes.get("TRPFechaCaptura") + ":", columna*4) +
                        StringUtils.rightPad(Generales.getFormatoFecha(fechaCaptura, "MM/dd/yy"), columna*2) +
                        StringUtils.leftPad(Mensajes.get("TRPFolio") + ":", columna*2) +
                        StringUtils.rightPad(prepedidos.getString("Folio"), columna*4);

                cadena = alineaTexto(BTIPALI.TipoAlineacion.IZQUIERDA, texto2, columna*columnas);
                cadenaRecibo.append(cadena + "\r\n");

                Paragraph movimientoSinInventarioRow = new Paragraph(texto, textoNegrita);
                movimientoSinInventarioRow .setAlignment(Element.ALIGN_LEFT);
                reportePDF.add(movimientoSinInventarioRow);

                imprimeLineaPunteada(cadenaRecibo, columna*columnas);

                texto = StringUtils.rightPad(Mensajes.get("XProd"), 8);
                texto += StringUtils.rightPad(Mensajes.get("PRONombreCorto"), 20);
                texto += StringUtils.rightPad(Mensajes.get("XUnidad"), 8);
                texto += StringUtils.center(StringUtils.left(Mensajes.get("XCant."), 4), 4);
                texto += StringUtils.center(Mensajes.get("XPrecio"), 8);

                texto2 = StringUtils.rightPad(Mensajes.get("XProd"), columna*2);
                texto2 += StringUtils.rightPad(Mensajes.get("PRONombreCorto"), columna*5);
                texto2 += StringUtils.rightPad(Mensajes.get("XUnidad"), columna * 2);
                texto2 += StringUtils.center(StringUtils.left(Mensajes.get("XCant."), columna), columna);
                texto2 += StringUtils.center(Mensajes.get("XPrecio"), columna*2);

                cadena = alineaTexto(BTIPALI.TipoAlineacion.IZQUIERDA, texto2, columna*columnas);
                cadenaRecibo.append(cadena + "\r\n");

                Paragraph encabezadoFolio = new Paragraph(texto, textoNegrita);
                encabezadoFolio.setAlignment(Element.ALIGN_LEFT);
                reportePDF.add(encabezadoFolio);

                imprimeLineaPunteada(cadenaRecibo, columna*columnas);

            }
            transProdIDActual = prepedidos.getString("TransProdID");

            prod = prepedidos.getString("ProductoClave");
            nombreCorto = prepedidos.getString("Nombre") ;
            unidad = ValoresReferencia.getDescripcion("UNIDADV", prepedidos.getString("TipoUnidad"));
            cant = prepedidos.getString("Cantidad");
            precio = (prepedidos.getInt("Promocion") == 2 ? "*" : Generales.getFormatoDecimal(prepedidos.getDouble("Precio"),2));

            texto = StringUtils.rightPad(prod, 8) + StringUtils.abbreviate(StringUtils.rightPad(nombreCorto, 20),20) +
                    StringUtils.center(unidad, 8) + StringUtils.leftPad(cant, 4) + StringUtils.leftPad(precio, 8);

            texto2 = StringUtils.rightPad(prod, columna*2) + StringUtils.abbreviate(StringUtils.rightPad(nombreCorto, columna*5), columna*5) +
                    StringUtils.center(unidad, columna * 2) + StringUtils.leftPad(cant, columna) + StringUtils.leftPad(precio, columna*2);

            cadena = alineaTexto(BTIPALI.TipoAlineacion.IZQUIERDA, texto2, columna*columnas);
            cadenaRecibo.append(cadena + "\r\n");

            Paragraph ventasGeneralRow = new Paragraph(texto, textoNegrita);
            ventasGeneralRow .setAlignment(Element.ALIGN_LEFT);
            reportePDF.add(ventasGeneralRow );
        }

        prepedidos.close();
        document.add(reportePDF);

    }

	private static void generarReporteCargas(int reporte, StringBuilder cadenaRecibo, Document document) throws Exception {
		String cadena = "";
		String cadena2 = "";
		String texto = "";
		String texto2 = "";
		int columna = 10;
		int columnas;
		int max = 38;
		int max2 = 38;

		int mostrarCedi = Integer.parseInt(((CONHist) Sesion.get(Campo.CONHist)).get("MostrarCEDI").toString());
		String diaClave = Sesion.get(Campo.FiltroReporteDiaClave).toString();
		boolean filtroDetallado = (Boolean) Sesion.get(Campo.FiltroVarioDetallado);
		boolean filtroGeneral = (Boolean) Sesion.get(Campo.FiltroVarioGeneral);

        SimpleDateFormat inputDate = new SimpleDateFormat("dd/MM/yyyy");
        SimpleDateFormat outputDate = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss");
        diaClave= outputDate.format(inputDate.parse(diaClave));

		Paragraph reportePDF = new Paragraph();
		reportePDF.setFont(textoNegrita); //letra general para el reporte

		setTamanioDefault(((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp);
		TamanioLetra tamanioLetra;
		tamanioLetra = tamanioDefault;

		if (((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.ZEBRA_TERMICA2 || ((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.ZEBRA_CAMEO2) {
			cadena = "{" + tamanioLetra.mTamanio + " " + tamanioLetra.mAlto + "}";
		} else if (((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.INTERMEC_PR2 || ((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.INTERMEC_PR3) {
			//Se usa el mAlto para indentificar si la letra es normal o doble 0= normal 1= doble
			//En la cadena de los bytes no se debe dejar espacios, si no falla y se consideran hasta el momento
			//3 bytes en el mensaje, por lo que si se mete menos o mas, hay que cambiar el codigo en BluetoothPrint
			if (tamanioLetra.mAlto != 0) {
				cadena = "{27,33," + tamanioLetra.mTamanio + "}";
			} else {
				cadena = "{27,119," + tamanioLetra.mTamanio + "}";
			}
		} else if (((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.ZEBRA_TERMICA3) {
			cadena = "! U1 SETLP 7 " + tamanioLetra.mTamanio + " " + tamanioLetra.mAlto + " ";
		} else {
			cadena = "{" + tamanioLetra.mTamanio + "}";
			if (((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.SEWOO) {
				max2 = 32;
			}
		}
		columnas = 3;
		columna = tamanioLetra.mLongTotal / columnas;

		if(mostrarCedi == 1){

			ISetDatos encabezado = Consultas.ConsultasTransProd.obtenerAlmacen();
			encabezado.moveToFirst();

			texto = encabezado.getString("Nombre");
			cadena = cadena + alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, columna * columnas);
			cadenaRecibo.append(cadena + "\r\n");

			Paragraph nombre = new Paragraph(texto, textoNegrita);
			nombre.setAlignment(Element.ALIGN_CENTER);
			reportePDF.add(nombre);

			texto = encabezado.getString("Domicilio");
			cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, columna * columnas);
			cadenaRecibo.append(cadena + "\r\n");

			Paragraph domicilio = new Paragraph(texto, textoNegrita);
			domicilio.setAlignment(Element.ALIGN_CENTER);
			reportePDF.add(domicilio);

			texto = encabezado.getString("Telefono");
			cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, columna * columnas);
			cadenaRecibo.append(cadena + "\r\n");

			Paragraph telefono = new Paragraph(texto, textoNegrita);
			telefono.setAlignment(Element.ALIGN_CENTER);
			reportePDF.add(telefono);

			cadenaRecibo.append("\r\n");
			reportePDF.add(new Paragraph(" ")); //linea en blanco = \r\n
			encabezado.close();

		} else {

			ISetDatos encabezado = ConsultasImpresionTicket.obtenerEncabezado();
			encabezado.moveToFirst();

			texto = encabezado.getString("NombreEmpresa");
			cadena = cadena + alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, columna * columnas);
			cadenaRecibo.append(cadena + "\r\n");

			Paragraph empresa = new Paragraph(texto, textoNegrita);
			empresa.setAlignment(Element.ALIGN_CENTER);
			reportePDF.add(empresa);

			texto = encabezado.getString("RFC");
			cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, columna * columnas);
			cadenaRecibo.append(cadena + "\r\n");

			Paragraph rfc = new Paragraph(texto, textoNegrita);
			rfc.setAlignment(Element.ALIGN_CENTER);
			reportePDF.add(rfc);

			texto = encabezado.getString("Calle") + " " + encabezado.getString("Numero") + ", "+ Mensajes.get("XCol")+ " " + encabezado.getString("Colonia")+",";
			cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, columna * columnas);
			cadenaRecibo.append(cadena + "\r\n");

			Paragraph domicilio = new Paragraph(texto, textoNegrita);
			domicilio.setAlignment(Element.ALIGN_CENTER);
			reportePDF.add(domicilio);

			texto = encabezado.getString("Ciudad") + ", " + encabezado.getString("Region");
			cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, columna * columnas);
			cadenaRecibo.append(cadena + "\r\n");

			Paragraph ciudad = new Paragraph(texto, textoNegrita);
			ciudad.setAlignment(Element.ALIGN_CENTER);
			reportePDF.add(ciudad);

			cadenaRecibo.append("\r\n");
			reportePDF.add(new Paragraph(" ")); //linea en blanco = \r\n
			encabezado.close();

		}

		texto = Mensajes.get("XImpresion") + ": " + Generales.getFechaHoraActualStr("dd/MM/yyyy hh:mm:ss");
		cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, columna * columnas);
		cadenaRecibo.append(cadena + "\r\n");

		Paragraph impresion = new Paragraph(texto, textoNegrita);
		impresion.setAlignment(Element.ALIGN_CENTER);
		reportePDF.add(impresion);

		texto = Mensajes.get("XVendedor") + ": " + ((Usuario) Sesion.get(Campo.UsuarioActual)).Nombre;
		cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, columna*columnas);
		cadenaRecibo.append(cadena + "\r\n");

		Paragraph ven = new Paragraph(texto, textoNegrita);
		ven.setAlignment(Element.ALIGN_CENTER);
		reportePDF.add(ven);

		cadenaRecibo.append("\r\n");
		reportePDF.add(new Paragraph(" ")); //linea en blanco = \r\n

		//////COLUMNA
		if(filtroDetallado){

			texto = ValoresReferencia.getDescripcion("REPORTEA", String.valueOf(reporte)) + " - DETALLADO";
			cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, columna*columnas);

			cadenaRecibo.append(cadena + "\r\n");

			Paragraph titulo = new Paragraph(texto, tituloRojo);
			titulo.setAlignment(Element.ALIGN_CENTER);
			reportePDF.add(titulo);
			reportePDF.add(new Paragraph(" ")); //linea en blanco = \r\n

			ISetDatos cargasDetallado = Consultas.ConsultasTransProd.obtenerCargasDetallado(diaClave);

			imprimeLineaPunteada(cadenaRecibo, columna * columnas);

			texto = StringUtils.rightPad(Mensajes.get("XUnidad"), 23);
			texto += StringUtils.leftPad(Mensajes.get("XCantidad"), 23);

			texto2 = completaHasta(Mensajes.get("XUnidad"), columna, TipoAlineacion.IZQUIERDA, false);
			texto2 += completaHasta(" ", columna, TipoAlineacion.IZQUIERDA,false);
			texto2 += completaHasta(Mensajes.get("XCantidad"), columna, TipoAlineacion.DERECHA,true);

			cadena = alineaTexto(BTIPALI.TipoAlineacion.IZQUIERDA, texto2, columna * columnas);
			cadenaRecibo.append(cadena + "\r\n");

			Paragraph encabezadoFolio = new Paragraph(texto, textoNegrita);
			encabezadoFolio.setAlignment(Element.ALIGN_LEFT);
			reportePDF.add(encabezadoFolio);

			imprimeLineaPunteada(cadenaRecibo, columna * columnas);

			Integer carga = 0;
			String nombreProducto;
			String cantidad;
			String unidad;
			Paragraph ventasGeneralRow;
			String cargaActual = "";
			String transProdDetalleActual = "";

			while (cargasDetallado.moveToNext()){

				if(!StringUtils.equals(cargaActual, cargasDetallado.getString("TransProdID"))) {
					carga += 1;

					texto = StringUtils.rightPad(Mensajes.get("XCarga") + ": " + carga, 46);
					texto2 = completaHasta(Mensajes.get("XCarga") + ": " + carga, columna * columnas, TipoAlineacion.IZQUIERDA, false);

					cadena = alineaTexto(BTIPALI.TipoAlineacion.IZQUIERDA, texto2, columna * columnas);
					cadenaRecibo.append(cadena + "\r\n");

					Paragraph cargasEncabezado = new Paragraph(texto, textoNegrita);
					cargasEncabezado.setAlignment(Element.ALIGN_LEFT);
					reportePDF.add(cargasEncabezado);
				}
				cargaActual = cargasDetallado.getString("TransProdID");

				if(!StringUtils.equals(transProdDetalleActual, cargasDetallado.getString("TransProdDetalleID"))) {
					nombreProducto = cargasDetallado.getString("ProductoClave") + " " + cargasDetallado.getString("Nombre");

					texto = StringUtils.rightPad(nombreProducto, 46);

					texto2 = completaHasta(nombreProducto, columna * 3, TipoAlineacion.IZQUIERDA, true);

					cadena = alineaTexto(BTIPALI.TipoAlineacion.IZQUIERDA, texto2, columna * columnas);
					cadenaRecibo.append(cadena + "\r\n");

					ventasGeneralRow = new Paragraph(texto, textoNegrita);
					ventasGeneralRow.setAlignment(Element.ALIGN_LEFT);
					reportePDF.add(ventasGeneralRow);
				}

				unidad = ValoresReferencia.getDescripcion("UNIDADV", cargasDetallado.getString("TipoUnidad"));
				cantidad = Generales.getFormatoDecimal(cargasDetallado.getInt("Cantidad"), 2);

				texto = StringUtils.leftPad(unidad, 36) + StringUtils.leftPad(cantidad, 10);

				texto2 = completaHasta(unidad, columna * 2, TipoAlineacion.DERECHA, false) + completaHasta(cantidad, columna, TipoAlineacion.DERECHA, true);

				cadena = alineaTexto(BTIPALI.TipoAlineacion.IZQUIERDA, texto2, columna * columnas);
				cadenaRecibo.append(cadena + "\r\n");

				ventasGeneralRow = new Paragraph(texto, textoNegrita);
				ventasGeneralRow.setAlignment(Element.ALIGN_LEFT);
				reportePDF.add(ventasGeneralRow);
			}

			cargasDetallado.close();
		}

		if(filtroGeneral){

			texto = ValoresReferencia.getDescripcion("REPORTEA", String.valueOf(reporte)) + " - GENERAL";
			cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, columna*columnas);

			cadenaRecibo.append(cadena + "\r\n");

			Paragraph titulo = new Paragraph(texto, tituloRojo);
			titulo.setAlignment(Element.ALIGN_CENTER);
			reportePDF.add(titulo);
			reportePDF.add(new Paragraph(" ")); //linea en blanco = \r\n

			ISetDatos cargasGeneral = Consultas.ConsultasTransProd.obtenerCargasGeneral(diaClave);

			imprimeLineaPunteada(cadenaRecibo, columna * columnas);

			texto = StringUtils.rightPad(Mensajes.get("XUnidad"), 23);
			texto += StringUtils.leftPad(Mensajes.get("XCantidad"), 23);

			texto2 = completaHasta(Mensajes.get("XUnidad"), columna, TipoAlineacion.IZQUIERDA, false);
			texto2 += completaHasta(" ", columna, TipoAlineacion.IZQUIERDA,false);
			texto2 += completaHasta(Mensajes.get("XCantidad"), columna, TipoAlineacion.DERECHA,true);

			cadena = alineaTexto(BTIPALI.TipoAlineacion.IZQUIERDA, texto2, columna * columnas);
			cadenaRecibo.append(cadena + "\r\n");

			Paragraph encabezadoFolio = new Paragraph(texto, textoNegrita);
			encabezadoFolio.setAlignment(Element.ALIGN_LEFT);
			reportePDF.add(encabezadoFolio);

			imprimeLineaPunteada(cadenaRecibo, columna * columnas);

			double granTotal = 0;
			Integer carga = 0;
			Integer factorMinimo = 1;
			String nombreProducto;
			String cantidad;
			Paragraph cargasGeneralRow;
			String cargaActual = "";

			while (cargasGeneral.moveToNext()){

				if(!StringUtils.equals(cargaActual, cargasGeneral.getString("TransProdID"))) {
					carga += 1;

					texto = StringUtils.rightPad(Mensajes.get("XCarga") + carga, 46);
					texto2 = completaHasta(Mensajes.get("XCarga") + carga, columna * columnas, TipoAlineacion.IZQUIERDA, false);

					cadena = alineaTexto(BTIPALI.TipoAlineacion.IZQUIERDA, texto2, columna * columnas);
					cadenaRecibo.append(cadena + "\r\n");

					Paragraph cargasEncabezado = new Paragraph(texto, textoNegrita);
					cargasEncabezado.setAlignment(Element.ALIGN_LEFT);
					reportePDF.add(cargasEncabezado);
				}
				cargaActual = cargasGeneral.getString("TransProdID");

				factorMinimo = cargasGeneral.getInt("FactorMinimo") <=0 ? 1 : cargasGeneral.getInt("FactorMinimo");
				nombreProducto = cargasGeneral.getString("ProductoClave") + " " + cargasGeneral.getString("Nombre");
				cantidad = Generales.getFormatoDecimal(cargasGeneral.getInt("CantidadTotal") / factorMinimo, 2);

				texto = StringUtils.rightPad(nombreProducto, 36) + StringUtils.leftPad(cantidad, 10);

				texto2 = completaHasta(nombreProducto, columna * 2, TipoAlineacion.IZQUIERDA, false) + completaHasta(cantidad, columna, TipoAlineacion.DERECHA, true);

				cadena = alineaTexto(BTIPALI.TipoAlineacion.IZQUIERDA, texto2, columna * columnas);
				cadenaRecibo.append(cadena + "\r\n");

				cargasGeneralRow = new Paragraph(texto, textoNegrita);
				cargasGeneralRow.setAlignment(Element.ALIGN_LEFT);
				reportePDF.add(cargasGeneralRow);

				granTotal += cargasGeneral.getDouble("CantidadTotal") / factorMinimo;
			}

			imprimeLineaPunteada(cadenaRecibo, columna*columnas);
			texto = StringUtils.leftPad(Mensajes.get("XTotal"),26) + StringUtils.leftPad(Generales.getFormatoDecimal(granTotal,2),20);

			texto2 =  completaHasta(Mensajes.get("XTotal"), columna * 2, TipoAlineacion.DERECHA, false) + completaHasta(Generales.getFormatoDecimal(granTotal, 2), columna, TipoAlineacion.DERECHA, true);

			cadena = alineaTexto(BTIPALI.TipoAlineacion.IZQUIERDA, texto2, columna*columnas);
			cadenaRecibo.append(cadena + "\r\n");

			Paragraph granTotalP = new Paragraph(texto, textoNegrita);
			granTotalP.setAlignment(Element.ALIGN_LEFT);
			reportePDF.add(granTotalP);

			cargasGeneral.close();
		}

		ISetDatos cargasResumen = Consultas.ConsultasTransProd.obtenerCargasResumen(diaClave);

        cadenaRecibo.append("\r\n");
        reportePDF.add(new Paragraph(" "));

		imprimeLineaPunteada(cadenaRecibo, columna * columnas);

		texto = Mensajes.get("XRESUMEN");

		cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, columna * columnas);
		cadenaRecibo.append(cadena + "\r\n");

		Paragraph encabezadoFolio = new Paragraph(texto, textoNegrita);
		encabezadoFolio.setAlignment(Element.ALIGN_CENTER);
		reportePDF.add(encabezadoFolio);
        reportePDF.add(new Paragraph(" "));

		Integer factorMinimo = 1;
		String nombreProducto;
		String cantidad;
		Paragraph cargasResumenRow;

		while (cargasResumen.moveToNext()){

			factorMinimo = cargasResumen.getInt("FactorMinimo") <=0 ? 1 : cargasResumen.getInt("FactorMinimo");
			nombreProducto = cargasResumen.getString("ProductoClave") + " " + cargasResumen.getString("Nombre");
			cantidad = Generales.getFormatoDecimal(cargasResumen.getInt("CantidadTotal") / factorMinimo, 2);

			texto = StringUtils.rightPad(nombreProducto, 36) + StringUtils.leftPad(cantidad, 10);

			texto2 = completaHasta(nombreProducto, columna * 2, TipoAlineacion.IZQUIERDA, false) + completaHasta(cantidad, columna, TipoAlineacion.DERECHA, true);

			cadena = alineaTexto(BTIPALI.TipoAlineacion.IZQUIERDA, texto2, columna * columnas);
			cadenaRecibo.append(cadena + "\r\n");

			cargasResumenRow = new Paragraph(texto, textoNegrita);
			cargasResumenRow.setAlignment(Element.ALIGN_LEFT);
			reportePDF.add(cargasResumenRow);
		}

		cadenaRecibo.append("\r\n\n");
		reportePDF.add(new Paragraph(" "));

		document.add(reportePDF);

	}

    private static void generarReporteResumenMovimientos(int reporte, StringBuilder cadenaRecibo, Document document, boolean detalladoGeneral) throws Exception
    {
        String cadena = "";
        String texto = "";
        short TipoImpresora=((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp;

        Paragraph reportePDF = new Paragraph();
        reportePDF.setFont(textoNegrita);
        Vendedor vendedor = (Vendedor) Sesion.get(Campo.VendedorActual);
        setTamanioDefault(vendedor.TipoModImp);
        TamanioLetra tamanioLetra;
        tamanioLetra = tamanioDefault;

        if (((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.ZEBRA_TERMICA2 || ((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.ZEBRA_CAMEO2) {
            cadena = "{" + tamanioLetra.mTamanio + " " + tamanioLetra.mAlto + "}";
        } else if (((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.INTERMEC_PR2 || ((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.INTERMEC_PR3) {
            //Se usa el mAlto para indentificar si la letra es normal o doble 0= normal 1= doble
            //En la cadena de los bytes no se debe dejar espacios, si no falla y se consideran hasta el momento
            //3 bytes en el mensaje, por lo que si se mete menos o mas, hay que cambiar el codigo en BluetoothPrint
            if (tamanioLetra.mAlto != 0) {
                cadena = "{27,33," + tamanioLetra.mTamanio + "}";
            } else {
                cadena = "{27,119," + tamanioLetra.mTamanio + "}";
            }
        } else if (((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.ZEBRA_TERMICA3) {
            cadena = "! U1 SETLP 7 " + tamanioLetra.mTamanio + " " + tamanioLetra.mAlto + " ";
        } else {
            cadena = "{" + tamanioLetra.mTamanio + "}";
        }

        //Encabezado Reporte
        ISetDatos encabezado = ConsultasImpresionTicket.obtenerEncabezado();
        encabezado.moveToFirst();

        texto = encabezado.getString("NombreEmpresa");
        cadena = cadena + alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, tamanioLetra.mLongTotal);
        cadenaRecibo.append(cadena + "\r\n");

        Paragraph empresa = new Paragraph(texto, textoNegrita);
        empresa.setAlignment(Element.ALIGN_CENTER);
        reportePDF.add(empresa);

        texto = Mensajes.get("XRFC") + ": "+ encabezado.getString("RFC");
        cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, tamanioLetra.mLongTotal);
        cadenaRecibo.append(cadena + "\r\n");

        Paragraph rfc = new Paragraph(texto, textoNegrita);
        rfc.setAlignment(Element.ALIGN_CENTER);
        reportePDF.add(rfc);

        texto = encabezado.getString("Calle");
        cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, tamanioLetra.mLongTotal);
        cadenaRecibo.append(cadena + "\r\n");

        Paragraph calle = new Paragraph(texto, textoNegrita);
        calle.setAlignment(Element.ALIGN_CENTER);
        reportePDF.add(calle);

        texto = encabezado.getString("Numero");
        cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, tamanioLetra.mLongTotal);
        cadenaRecibo.append(cadena + "\r\n");

        Paragraph numero = new Paragraph(texto, textoNegrita);
        numero.setAlignment(Element.ALIGN_CENTER);
        reportePDF.add(numero);

        texto = encabezado.getString("Colonia");
        cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, tamanioLetra.mLongTotal);
        cadenaRecibo.append(cadena + "\r\n");

        Paragraph colonia = new Paragraph(texto, textoNegrita);
        colonia.setAlignment(Element.ALIGN_CENTER);
        reportePDF.add(colonia);

        texto = encabezado.getString("Ciudad")+", "+ encabezado.getString("Region");
        cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, tamanioLetra.mLongTotal);
        cadenaRecibo.append(cadena + "\r\n");
        cadenaRecibo.append("\r\n");

        Paragraph ciudad = new Paragraph(texto, textoNegrita);
        ciudad.setAlignment(Element.ALIGN_CENTER);
        reportePDF.add(ciudad);
        reportePDF.add(new Paragraph(" "));
        encabezado.close();

        //Detalle Encabezado
        texto = Mensajes.get("XImpresion") + ": " + Generales.getFechaHoraActualStr("dd/MM/yyyy hh:mm:ss");
        cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, tamanioLetra.mLongTotal);
        cadenaRecibo.append(cadena + "\r\n");

        Paragraph impresion = new Paragraph(texto, textoNegrita);
        impresion.setAlignment(Element.ALIGN_CENTER);
        reportePDF.add(impresion);

        texto = Mensajes.get("XVendedor") + ": " + ((Usuario) Sesion.get(Campo.UsuarioActual)).Nombre;
        cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, tamanioLetra.mLongTotal);
        cadenaRecibo.append(cadena + "\r\n");

        Paragraph ven = new Paragraph(texto, textoNegrita);
        ven.setAlignment(Element.ALIGN_CENTER);
        reportePDF.add(ven);
        reportePDF.add(new Paragraph(" "));

        String tipoReporte = "";
        if(detalladoGeneral){
            tipoReporte = Mensajes.get("XDetallado");
        }else {
            tipoReporte = Mensajes.get("XGeneral");
        }

        texto = ValoresReferencia.getDescripcion("REPORTEA", String.valueOf(reporte)) +" - "+ tipoReporte;
        cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, tamanioLetra.mLongTotal);
        cadenaRecibo.append(cadena + "\r\n");
        cadenaRecibo.append("\r\n");

        Paragraph titulo = new Paragraph(texto, tituloRojo);
        titulo.setAlignment(Element.ALIGN_CENTER);
        reportePDF.add(titulo);
        reportePDF.add(new Paragraph(" "));

        //Titulos
        texto = Mensajes.get("XProducto");
        cadena = completaHasta(texto, (((TipoImpresora == TipoPapel.EXTECH_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA3) ? 28 : ((TipoImpresora == TipoPapel.INTERMEC_PR3) ? 37 : 28))), TipoAlineacion.IZQUIERDA, false);
        texto = Mensajes.get("XUnidad");
        cadena += completaHasta(texto, (((TipoImpresora == TipoPapel.EXTECH_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA3) ? 10 : ((TipoImpresora == TipoPapel.INTERMEC_PR3) ? 10 : 10))), TipoAlineacion.IZQUIERDA, false);
        texto = Mensajes.get("XCantidad");
        cadena += completaHasta(texto, (((TipoImpresora == TipoPapel.EXTECH_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA3) ? 10 : ((TipoImpresora == TipoPapel.INTERMEC_PR3) ? 10 : 10))), TipoAlineacion.DERECHA, false);

        cadenaRecibo.append(cadena + "\r\n");
        StringBuilder sbLinea = new StringBuilder();
        imprimeLineaPunteada(sbLinea,tamanioLetra.mLongTotal);
        cadenaRecibo.append(sbLinea + "\r\n");

        Paragraph tituloDetalle1 = new Paragraph(cadena, tituloSubrayado);
        reportePDF.add(tituloDetalle1);

        //Detalle Reporte
        String diaClave = Sesion.get(Campo.FiltroReporteDiaClave).toString();
        ISetDatos isdMovimientos = Consultas.ConsultaResumenMovimientos.obtenerResumenMovimientos(diaClave, detalladoGeneral);
        int TotalFolio = 0;
        int contador = 0;
        String TipoDocumento="";
        String FolioDocumento="";
        String FDocumento [];
        String TipoMovimiento="";

        if (detalladoGeneral) {
            while (isdMovimientos.moveToNext()) {
                if (!TipoDocumento.equals(isdMovimientos.getString("Tipo"))) {
                    if (!TipoDocumento.equals(isdMovimientos.getString("Tipo")) && !TipoDocumento.equals("")){
                        texto = "";
                        cadena = completaHasta(texto, (((TipoImpresora == TipoPapel.EXTECH_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA3) ? 26 : ((TipoImpresora == TipoPapel.INTERMEC_PR3) ? 35 : 26))), TipoAlineacion.DERECHA, false);
                        texto = Mensajes.get("XTotalPiezas");
                        cadena += completaHasta(texto, (((TipoImpresora == TipoPapel.EXTECH_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA3) ? 12 : ((TipoImpresora == TipoPapel.INTERMEC_PR3) ? 12 : 12))), TipoAlineacion.DERECHA, false);
                        texto = String.valueOf(TotalFolio);
                        cadena += completaHasta(texto, (((TipoImpresora == TipoPapel.EXTECH_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA3) ? 10 : ((TipoImpresora == TipoPapel.INTERMEC_PR3) ? 10 : 10))), TipoAlineacion.DERECHA, true);

                        cadenaRecibo.append(cadena + "\r\n");
                        cadenaRecibo.append("\r\n");

                        Paragraph pTotalFolio = new Paragraph(cadena,textoNegrita);
                        reportePDF.add(pTotalFolio);
                        reportePDF.add(new Paragraph(" "));

                        TotalFolio = 0;
                        TipoDocumento="";
                    }
                    texto = ValoresReferencia.getDescripcion("TRPTIPO", isdMovimientos.getString("Tipo"));

                    cadenaRecibo.append(texto + "\r\n");
                    Paragraph pMovimiento = new Paragraph(texto, textoNegrita);
                    reportePDF.add(pMovimiento);

                    TipoDocumento=isdMovimientos.getString("Tipo");
                    FolioDocumento="";
                }

                FDocumento = isdMovimientos.getString("FolioMovimiento").split(" ");
                if(!FolioDocumento.equals(FDocumento[0])) {
                    if (!FolioDocumento.equals(FDocumento[0]) && !FolioDocumento.equals("")){
                        texto = "";
                        cadena = completaHasta(texto, (((TipoImpresora == TipoPapel.EXTECH_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA3) ? 26 : ((TipoImpresora == TipoPapel.INTERMEC_PR3) ? 35 : 26))), TipoAlineacion.DERECHA, false);
                        texto = Mensajes.get("XTotalPiezas");
                        cadena += completaHasta(texto, (((TipoImpresora == TipoPapel.EXTECH_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA3) ? 12 : ((TipoImpresora == TipoPapel.INTERMEC_PR3) ? 12 : 12))), TipoAlineacion.DERECHA, false);
                        texto = String.valueOf(TotalFolio);
                        cadena += completaHasta(texto, (((TipoImpresora == TipoPapel.EXTECH_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA3) ? 10 : ((TipoImpresora == TipoPapel.INTERMEC_PR3) ? 10 : 10))), TipoAlineacion.DERECHA, true);

                        cadenaRecibo.append(cadena + "\r\n");
                        cadenaRecibo.append("\r\n");

                        Paragraph pTotalFolio = new Paragraph(cadena,textoNegrita);
                        reportePDF.add(pTotalFolio);
                        reportePDF.add(new Paragraph(" "));

                        TotalFolio = 0;
                        FolioDocumento="";
                    }

                    if (!isdMovimientos.getString("Tipo").equals("9") || (isdMovimientos.getString("Tipo").equals("9") && isdMovimientos.getString("TipoMovimiento").equals("1"))){
                        texto = isdMovimientos.getString("FolioMovimiento");

                        cadenaRecibo.append(texto + "\r\n");
                        Paragraph pFolioMovimiento = new Paragraph(texto,textoNegrita);
                        reportePDF.add(pFolioMovimiento);
                    }

                    if (isdMovimientos.getString("Tipo").equals("9")){
                        if (isdMovimientos.getString("TipoMovimiento").equals("1")){
                            texto = "   " + Mensajes.get("XCambioMin") ;

                            cadenaRecibo.append(texto + "\r\n");
                            Paragraph pTipoMovimiento1 = new Paragraph(texto, textoNegrita);
                            reportePDF.add(pTipoMovimiento1);
                        }else{
                            texto = "   " + Mensajes.get("XPor");

                            cadenaRecibo.append(texto + "\r\n");
                            Paragraph pTipoMovimiento2 = new Paragraph(texto, textoNegrita);
                            reportePDF.add(pTipoMovimiento2);
                        }
                    }

                    FolioDocumento = FDocumento[0];
                }

                texto = isdMovimientos.getString("Producto");

                cadenaRecibo.append(texto + "\r\n");
                Paragraph pProducto = new Paragraph(texto, textoNegrita);
                reportePDF.add(pProducto);

                texto = "";
                cadena = completaHasta(texto, (((TipoImpresora == TipoPapel.EXTECH_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA3) ? 26 : ((TipoImpresora == TipoPapel.INTERMEC_PR3) ? 35 : 26))), TipoAlineacion.DERECHA, false);
                texto = ValoresReferencia.getDescripcion("UNIDADV", isdMovimientos.getString("TipoUnidad"));
                cadena += completaHasta(texto, (((TipoImpresora == TipoPapel.EXTECH_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA3) ? 12 : ((TipoImpresora == TipoPapel.INTERMEC_PR3) ? 12 : 12))), TipoAlineacion.IZQUIERDA, false);
                texto = isdMovimientos.getString("Cantidad");
                cadena += completaHasta(texto, (((TipoImpresora == TipoPapel.EXTECH_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA3) ? 10 : ((TipoImpresora == TipoPapel.INTERMEC_PR3) ? 10 : 10))), TipoAlineacion.DERECHA, true);

                cadenaRecibo.append(cadena + "\r\n");
                Paragraph pUnidadCantidad = new Paragraph(cadena,textoNegrita);
                reportePDF.add(pUnidadCantidad);

                TotalFolio += isdMovimientos.getInt("TotalPiezas");
                contador++;

                if(contador == isdMovimientos.getCount()){
                    texto = "";
                    cadena = completaHasta(texto, (((TipoImpresora == TipoPapel.EXTECH_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA3) ? 26 : ((TipoImpresora == TipoPapel.INTERMEC_PR3) ? 35 : 26))), TipoAlineacion.DERECHA, false);
                    texto = Mensajes.get("XTotalPiezas");
                    cadena += completaHasta(texto, (((TipoImpresora == TipoPapel.EXTECH_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA3) ? 12 : ((TipoImpresora == TipoPapel.INTERMEC_PR3) ? 12 : 12))), TipoAlineacion.DERECHA, false);
                    texto = String.valueOf(TotalFolio);
                    cadena += completaHasta(texto, (((TipoImpresora == TipoPapel.EXTECH_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA3) ? 10 : ((TipoImpresora == TipoPapel.INTERMEC_PR3) ? 10 : 10))), TipoAlineacion.DERECHA, true);

                    cadenaRecibo.append(cadena + "\r\n");
                    cadenaRecibo.append("\r\n");

                    Paragraph pTotalFolio = new Paragraph(cadena,textoNegrita);
                    reportePDF.add(pTotalFolio);
                    reportePDF.add(new Paragraph(" "));

                    TotalFolio = 0;
                }

            }
        }else{
            while (isdMovimientos.moveToNext()) {
                if (!TipoDocumento.equals(isdMovimientos.getString("Tipo"))) {
                    if (!TipoDocumento.equals(isdMovimientos.getString("Tipo")) && !TipoDocumento.equals("")){
                        texto = "";
                        cadena = completaHasta(texto, (((TipoImpresora == TipoPapel.EXTECH_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA3) ? 26 : ((TipoImpresora == TipoPapel.INTERMEC_PR3) ? 35 : 26))), TipoAlineacion.DERECHA, false);
                        texto = Mensajes.get("XTotalPiezas");
                        cadena += completaHasta(texto, (((TipoImpresora == TipoPapel.EXTECH_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA3) ? 12 : ((TipoImpresora == TipoPapel.INTERMEC_PR3) ? 12 : 12))), TipoAlineacion.DERECHA, false);
                        texto = String.valueOf(TotalFolio);
                        cadena += completaHasta(texto, (((TipoImpresora == TipoPapel.EXTECH_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA3) ? 10 : ((TipoImpresora == TipoPapel.INTERMEC_PR3) ? 10 : 10))), TipoAlineacion.DERECHA, true);

                        cadenaRecibo.append(cadena + "\r\n");
                        cadenaRecibo.append("\r\n");

                        Paragraph pTotalFolio = new Paragraph(cadena,textoNegrita);
                        reportePDF.add(pTotalFolio);
                        reportePDF.add(new Paragraph(" "));

                        TotalFolio = 0;
                        TipoDocumento="";
                    }
                    texto = ValoresReferencia.getDescripcion("TRPTIPO", isdMovimientos.getString("Tipo"));

                    cadenaRecibo.append(texto + "\r\n");
                    Paragraph pMovimiento = new Paragraph(texto, textoNegrita);
                    reportePDF.add(pMovimiento);

                    TipoDocumento=isdMovimientos.getString("Tipo");
                }

                if (isdMovimientos.getString("Tipo").equals("9") && !TipoMovimiento.equals(isdMovimientos.getString("TipoMovimiento"))){
                    if (isdMovimientos.getString("TipoMovimiento").equals("1")){
                        texto = "   " + Mensajes.get("XCambioMin") ;

                        cadenaRecibo.append(texto + "\r\n");
                        Paragraph pTipoMovimiento1 = new Paragraph(texto, textoNegrita);
                        reportePDF.add(pTipoMovimiento1);
                    }else{
                        texto = "";
                        cadena = completaHasta(texto, (((TipoImpresora == TipoPapel.EXTECH_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA3) ? 26 : ((TipoImpresora == TipoPapel.INTERMEC_PR3) ? 35 : 26))), TipoAlineacion.DERECHA, false);
                        texto = Mensajes.get("XTotalPiezas");
                        cadena += completaHasta(texto, (((TipoImpresora == TipoPapel.EXTECH_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA3) ? 12 : ((TipoImpresora == TipoPapel.INTERMEC_PR3) ? 12 : 12))), TipoAlineacion.DERECHA, false);
                        texto = String.valueOf(TotalFolio);
                        cadena += completaHasta(texto, (((TipoImpresora == TipoPapel.EXTECH_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA3) ? 10 : ((TipoImpresora == TipoPapel.INTERMEC_PR3) ? 10 : 10))), TipoAlineacion.DERECHA, true);

                        cadenaRecibo.append(cadena + "\r\n");
                        cadenaRecibo.append("\r\n");

                        Paragraph pTotalFolio = new Paragraph(cadena,textoNegrita);
                        reportePDF.add(pTotalFolio);
                        reportePDF.add(new Paragraph(" "));

                        TotalFolio = 0;

                        texto = "   " + Mensajes.get("XPor");

                        cadenaRecibo.append(texto + "\r\n");
                        Paragraph pTipoMovimiento2 = new Paragraph(texto, textoNegrita);
                        reportePDF.add(pTipoMovimiento2);
                    }
                }

                texto = isdMovimientos.getString("Producto");

                cadenaRecibo.append(texto + "\r\n");
                Paragraph pProducto = new Paragraph(texto, textoNegrita);
                reportePDF.add(pProducto);

                texto = "";
                cadena = completaHasta(texto, (((TipoImpresora == TipoPapel.EXTECH_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA3) ? 26 : ((TipoImpresora == TipoPapel.INTERMEC_PR3) ? 35 : 26))), TipoAlineacion.DERECHA, false);
                texto = ValoresReferencia.getDescripcion("UNIDADV", isdMovimientos.getString("TipoUnidad"));
                cadena += completaHasta(texto, (((TipoImpresora == TipoPapel.EXTECH_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA3) ? 12 : ((TipoImpresora == TipoPapel.INTERMEC_PR3) ? 12 : 12))), TipoAlineacion.IZQUIERDA, false);
                texto = isdMovimientos.getString("Cantidad");
                cadena += completaHasta(texto, (((TipoImpresora == TipoPapel.EXTECH_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA3) ? 10 : ((TipoImpresora == TipoPapel.INTERMEC_PR3) ? 10 : 10))), TipoAlineacion.DERECHA, true);

                cadenaRecibo.append(cadena + "\r\n");
                Paragraph pUnidadCantidad = new Paragraph(cadena,textoNegrita);
                reportePDF.add(pUnidadCantidad);

                TotalFolio += isdMovimientos.getInt("TotalPiezas");
                contador++;
                if (isdMovimientos.getString("Tipo").equals("9")){
                    TipoMovimiento=isdMovimientos.getString("TipoMovimiento");
                }

                if(contador == isdMovimientos.getCount()){
                    texto = "";
                    cadena = completaHasta(texto, (((TipoImpresora == TipoPapel.EXTECH_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA3) ? 26 : ((TipoImpresora == TipoPapel.INTERMEC_PR3) ? 35 : 26))), TipoAlineacion.DERECHA, false);
                    texto = Mensajes.get("XTotalPiezas");
                    cadena += completaHasta(texto, (((TipoImpresora == TipoPapel.EXTECH_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA3) ? 12 : ((TipoImpresora == TipoPapel.INTERMEC_PR3) ? 12 : 12))), TipoAlineacion.DERECHA, false);
                    texto = String.valueOf(TotalFolio);
                    cadena += completaHasta(texto, (((TipoImpresora == TipoPapel.EXTECH_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA3) ? 10 : ((TipoImpresora == TipoPapel.INTERMEC_PR3) ? 10 : 10))), TipoAlineacion.DERECHA, true);

                    cadenaRecibo.append(cadena + "\r\n");
                    cadenaRecibo.append("\r\n");

                    Paragraph pTotalFolio = new Paragraph(cadena,textoNegrita);
                    reportePDF.add(pTotalFolio);
                    reportePDF.add(new Paragraph(" "));

                    TotalFolio = 0;
                }

            }
        }
        isdMovimientos.close();
        document.add(reportePDF);
    }

    private static void generarReporteVentas(int reporte, StringBuilder cadenaRecibo, Document document, boolean detalladoGeneral, boolean TotalProductoPrecio) throws Exception
    {
        String cadena = "";
        String texto = "";
        short TipoImpresora=((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp;

        Paragraph reportePDF = new Paragraph();
        reportePDF.setFont(textoNegrita);
        Vendedor vendedor = (Vendedor) Sesion.get(Campo.VendedorActual);
        setTamanioDefault(vendedor.TipoModImp);
        TamanioLetra tamanioLetra;
        tamanioLetra = tamanioDefault;

        if (((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.ZEBRA_TERMICA2 || ((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.ZEBRA_CAMEO2) {
            cadena = "{" + tamanioLetra.mTamanio + " " + tamanioLetra.mAlto + "}";
        } else if (((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.INTERMEC_PR2 || ((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.INTERMEC_PR3) {
            //Se usa el mAlto para indentificar si la letra es normal o doble 0= normal 1= doble
            //En la cadena de los bytes no se debe dejar espacios, si no falla y se consideran hasta el momento
            //3 bytes en el mensaje, por lo que si se mete menos o mas, hay que cambiar el codigo en BluetoothPrint
            if (tamanioLetra.mAlto != 0) {
                cadena = "{27,33," + tamanioLetra.mTamanio + "}";
            } else {
                cadena = "{27,119," + tamanioLetra.mTamanio + "}";
            }
        } else if (((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.ZEBRA_TERMICA3) {
            cadena = "! U1 SETLP 7 " + tamanioLetra.mTamanio + " " + tamanioLetra.mAlto + " ";
        } else {
            cadena = "{" + tamanioLetra.mTamanio + "}";
        }

        //Encabezado Reporte
        ISetDatos encabezado = ConsultasImpresionTicket.obtenerEncabezado();
        encabezado.moveToFirst();

        texto = encabezado.getString("NombreEmpresa");
        cadena = cadena + alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, tamanioLetra.mLongTotal);
        cadenaRecibo.append(cadena + "\r\n");

        Paragraph empresa = new Paragraph(texto, textoNegrita);
        empresa.setAlignment(Element.ALIGN_CENTER);
        reportePDF.add(empresa);

        texto = Mensajes.get("XRFC") + ": "+ encabezado.getString("RFC");
        cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, tamanioLetra.mLongTotal);
        cadenaRecibo.append(cadena + "\r\n");

        Paragraph rfc = new Paragraph(texto, textoNegrita);
        rfc.setAlignment(Element.ALIGN_CENTER);
        reportePDF.add(rfc);

        texto = encabezado.getString("Calle");
        cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, tamanioLetra.mLongTotal);
        cadenaRecibo.append(cadena + "\r\n");

        Paragraph calle = new Paragraph(texto, textoNegrita);
        calle.setAlignment(Element.ALIGN_CENTER);
        reportePDF.add(calle);

        texto = encabezado.getString("Numero");
        cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, tamanioLetra.mLongTotal);
        cadenaRecibo.append(cadena + "\r\n");

        Paragraph numero = new Paragraph(texto, textoNegrita);
        numero.setAlignment(Element.ALIGN_CENTER);
        reportePDF.add(numero);

        texto = encabezado.getString("Colonia");
        cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, tamanioLetra.mLongTotal);
        cadenaRecibo.append(cadena + "\r\n");

        Paragraph colonia = new Paragraph(texto, textoNegrita);
        colonia.setAlignment(Element.ALIGN_CENTER);
        reportePDF.add(colonia);

        texto = encabezado.getString("Ciudad")+", "+ encabezado.getString("Region");
        cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, tamanioLetra.mLongTotal);
        cadenaRecibo.append(cadena + "\r\n");
        cadenaRecibo.append("\r\n");

        Paragraph ciudad = new Paragraph(texto, textoNegrita);
        ciudad.setAlignment(Element.ALIGN_CENTER);
        reportePDF.add(ciudad);
        reportePDF.add(new Paragraph(" "));
        encabezado.close();

        //Detalle Encabezado
        texto = Mensajes.get("XImpresion") + ": " + Generales.getFechaHoraActualStr("dd/MM/yyyy hh:mm:ss");
        cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, tamanioLetra.mLongTotal);
        cadenaRecibo.append(cadena + "\r\n");

        Paragraph impresion = new Paragraph(texto, textoNegrita);
        impresion.setAlignment(Element.ALIGN_CENTER);
        reportePDF.add(impresion);

        texto = Mensajes.get("XVendedor") + ": " + ((Usuario) Sesion.get(Campo.UsuarioActual)).Nombre;
        cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, tamanioLetra.mLongTotal);
        cadenaRecibo.append(cadena + "\r\n");

        Paragraph ven = new Paragraph(texto, textoNegrita);
        ven.setAlignment(Element.ALIGN_CENTER);
        reportePDF.add(ven);
        reportePDF.add(new Paragraph(" "));

        String tipoReporte = "";
        if(detalladoGeneral){
            tipoReporte = Mensajes.get("XDetallado");
        }else {
            tipoReporte = Mensajes.get("XGeneral");
        }

        texto = ValoresReferencia.getDescripcion("REPORTEA", String.valueOf(reporte)) +" - "+ tipoReporte;
        cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, tamanioLetra.mLongTotal);
        cadenaRecibo.append(cadena + "\r\n");
        cadenaRecibo.append("\r\n");

        Paragraph titulo = new Paragraph(texto, tituloRojo);
        titulo.setAlignment(Element.ALIGN_CENTER);
        reportePDF.add(titulo);
        reportePDF.add(new Paragraph(" "));

        //Detalle Reporte
        String diaClave = Sesion.get(Campo.FiltroReporteDiaClave).toString();
        /*ISetDatos isdMovimientos = Consultas.ConsultaResumenMovimientos.obtenerResumenMovimientos(diaClave, detalladoGeneral);
        int TotalFolio = 0;
        int contador = 0;
        String TipoDocumento="";
        String FolioDocumento="";
        String FDocumento [];
        String TipoMovimiento="";*/

        if (detalladoGeneral) {
            //Titulos
            texto = Mensajes.get("XProducto");
            cadena = completaHasta(texto, (((TipoImpresora == TipoPapel.EXTECH_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA3) ? 18 : ((TipoImpresora == TipoPapel.INTERMEC_PR3) ? 27 : ((TipoImpresora == TipoPapel.INTERMEC_PR2) ? 11 : 18)))), TipoAlineacion.IZQUIERDA, false);
            texto = Mensajes.get("XCant.");
            cadena += completaHasta(texto, (((TipoImpresora == TipoPapel.EXTECH_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA3) ? 10 : ((TipoImpresora == TipoPapel.INTERMEC_PR3) ? 10 : ((TipoImpresora == TipoPapel.INTERMEC_PR2) ? 9 : 10)))), TipoAlineacion.DERECHA, false);
            texto = Mensajes.get("XP.U.");
            cadena += completaHasta(texto, (((TipoImpresora == TipoPapel.EXTECH_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA3) ? 10 : ((TipoImpresora == TipoPapel.INTERMEC_PR3) ? 10 : ((TipoImpresora == TipoPapel.INTERMEC_PR2) ? 10 : 10)))), TipoAlineacion.DERECHA, false);
            texto = Mensajes.get("XTotalMin");
            cadena += completaHasta(texto, (((TipoImpresora == TipoPapel.EXTECH_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA3) ? 10 : ((TipoImpresora == TipoPapel.INTERMEC_PR3) ? 10 : ((TipoImpresora == TipoPapel.INTERMEC_PR2) ? 10 : 10)))), TipoAlineacion.DERECHA, false);

            cadenaRecibo.append(cadena + "\r\n");
            StringBuilder sbLinea = new StringBuilder();
            imprimeLineaPunteada(sbLinea,tamanioLetra.mLongTotal);
            cadenaRecibo.append(sbLinea + "\r\n");

            Paragraph tituloDetalle1 = new Paragraph(cadena, tituloSubrayado);
            reportePDF.add(tituloDetalle1);

            //Ventas Detalle
            ISetDatos isdVentasDetallado = Consultas.ConsultaReporteVentas.obtenerVentasDetallado(diaClave);
            float Total = 0;
            float TotalFolio = 0;
            String ClienteAnterior="";
            String FolioAnterior="";
            String ProductoAnterior="";

            while (isdVentasDetallado.moveToNext()) {
                if (!ClienteAnterior.equals(isdVentasDetallado.getString("Cliente"))){
                    if (!FolioAnterior.equals("")){
                        texto = Mensajes.get("XTotal")+":";
                        cadena = completaHasta(texto, (((TipoImpresora == TipoPapel.EXTECH_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA3) ? 38 : ((TipoImpresora == TipoPapel.INTERMEC_PR3) ? 47 : ((TipoImpresora == TipoPapel.INTERMEC_PR2) ? 28 : 38)))), TipoAlineacion.DERECHA, false);
                        texto = Generales.getFormatoDecimal(TotalFolio, "#,###,##0.00");
                        cadena += completaHasta(texto, (((TipoImpresora == TipoPapel.EXTECH_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA3) ? 10 : ((TipoImpresora == TipoPapel.INTERMEC_PR3) ? 10 : ((TipoImpresora == TipoPapel.INTERMEC_PR2) ? 10 : 10)))), TipoAlineacion.DERECHA, false);

                        cadenaRecibo.append(cadena + "\r\n");
                        Paragraph pTotalFolio = new Paragraph(cadena, textoNegrita);
                        reportePDF.add(pTotalFolio);

                        cadenaRecibo.append("\r\n");
                        reportePDF.add(new Paragraph(" "));

                        TotalFolio = 0;
                    }

                    texto = isdVentasDetallado.getString("Cliente");

                    cadenaRecibo.append(texto + "\r\n");
                    Paragraph pCliente = new Paragraph(texto, textoNegrita);
                    reportePDF.add(pCliente);
                }

                if (!FolioAnterior.equals(isdVentasDetallado.getString("Folio"))){
                    if (!FolioAnterior.equals("") && TotalFolio != 0){
                        texto = Mensajes.get("XTotal")+":";
                        cadena = completaHasta(texto, (((TipoImpresora == TipoPapel.EXTECH_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA3) ? 38 : ((TipoImpresora == TipoPapel.INTERMEC_PR3) ? 47 : ((TipoImpresora == TipoPapel.INTERMEC_PR2) ? 28 : 38)))), TipoAlineacion.DERECHA, false);
                        texto = Generales.getFormatoDecimal(TotalFolio, "#,###,##0.00");
                        cadena += completaHasta(texto, (((TipoImpresora == TipoPapel.EXTECH_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA3) ? 10 : ((TipoImpresora == TipoPapel.INTERMEC_PR3) ? 10 : ((TipoImpresora == TipoPapel.INTERMEC_PR2) ? 10 : 10)))), TipoAlineacion.DERECHA, false);

                        cadenaRecibo.append(cadena + "\r\n");
                        Paragraph pTotalFolio = new Paragraph(cadena, textoNegrita);
                        reportePDF.add(pTotalFolio);

                        cadenaRecibo.append("\r\n");
                        reportePDF.add(new Paragraph(" "));

                        TotalFolio = 0;
                    }

                    texto = ValoresReferencia.getDescripcion("TRPTIPO", isdVentasDetallado.getString("Tipo")).toUpperCase() + " " + Mensajes.get("XFolio")+":"+isdVentasDetallado.getString("Folio");

                    cadenaRecibo.append(texto + "\r\n");
                    Paragraph pFolio = new Paragraph(texto, textoNegrita);
                    reportePDF.add(pFolio);
                }

                if (!ProductoAnterior.equals(isdVentasDetallado.getString("Producto"))){
                    texto = isdVentasDetallado.getString("Producto");

                    cadenaRecibo.append(texto + "\r\n");
                    Paragraph pProducto = new Paragraph(texto, textoNegrita);
                    reportePDF.add(pProducto);
                }

                texto = " ";
                cadena = completaHasta(texto, (((TipoImpresora == TipoPapel.EXTECH_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA3) ? 5 : ((TipoImpresora == TipoPapel.INTERMEC_PR3) ? 8 : ((TipoImpresora == TipoPapel.INTERMEC_PR2) ? 2 : 5)))), TipoAlineacion.DERECHA, false);
                texto = "-"+ValoresReferencia.getDescripcion("UNIDADV", isdVentasDetallado.getString("TipoUnidad"));
                cadena += completaHasta(texto, (((TipoImpresora == TipoPapel.EXTECH_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA3) ? 13 : ((TipoImpresora == TipoPapel.INTERMEC_PR3) ? 19 : ((TipoImpresora == TipoPapel.INTERMEC_PR2) ? 7 : 13)))), TipoAlineacion.IZQUIERDA, false);
                texto = isdVentasDetallado.getString("Cantidad");
                cadena += completaHasta(texto, (((TipoImpresora == TipoPapel.EXTECH_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA3) ? 10 : ((TipoImpresora == TipoPapel.INTERMEC_PR3) ? 10 : ((TipoImpresora == TipoPapel.INTERMEC_PR2) ? 9 : 10)))), TipoAlineacion.DERECHA, false);
                texto = (isdVentasDetallado.getString("Precio").equals("*") ? isdVentasDetallado.getString("Precio") : Generales.getFormatoDecimal(isdVentasDetallado.getFloat("Precio"), "#,###,##0.00"));
                cadena += completaHasta(texto, (((TipoImpresora == TipoPapel.EXTECH_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA3) ? 10 : ((TipoImpresora == TipoPapel.INTERMEC_PR3) ? 10 : ((TipoImpresora == TipoPapel.INTERMEC_PR2) ? 10 : 10)))), TipoAlineacion.DERECHA, false);
                texto = (isdVentasDetallado.getString("Precio").equals("*") ? isdVentasDetallado.getString("Total") : Generales.getFormatoDecimal(isdVentasDetallado.getFloat("Total"), "#,###,##0.00"));
                cadena += completaHasta(texto, (((TipoImpresora == TipoPapel.EXTECH_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA3) ? 10 : ((TipoImpresora == TipoPapel.INTERMEC_PR3) ? 10 : ((TipoImpresora == TipoPapel.INTERMEC_PR2) ? 10 : 10)))), TipoAlineacion.DERECHA, false);

                cadenaRecibo.append(cadena + "\r\n");
                Paragraph pVentaDetalle = new Paragraph(cadena, textoNegrita);
                reportePDF.add(pVentaDetalle);

                Total += isdVentasDetallado.getFloat("Total");
                TotalFolio += isdVentasDetallado.getFloat("Total");
                ClienteAnterior = isdVentasDetallado.getString("Cliente");
                FolioAnterior = isdVentasDetallado.getString("Folio");
                ProductoAnterior = isdVentasDetallado.getString("Producto");
            }
            texto = Mensajes.get("XTotal")+":";
            cadena = completaHasta(texto, (((TipoImpresora == TipoPapel.EXTECH_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA3) ? 38 : ((TipoImpresora == TipoPapel.INTERMEC_PR3) ? 47 : ((TipoImpresora == TipoPapel.INTERMEC_PR2) ? 28 : 38)))), TipoAlineacion.DERECHA, false);
            texto = Generales.getFormatoDecimal(TotalFolio, "#,###,##0.00");
            cadena += completaHasta(texto, (((TipoImpresora == TipoPapel.EXTECH_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA3) ? 10 : ((TipoImpresora == TipoPapel.INTERMEC_PR3) ? 10 : ((TipoImpresora == TipoPapel.INTERMEC_PR2) ? 10 : 10)))), TipoAlineacion.DERECHA, false);

            cadenaRecibo.append(cadena + "\r\n");
            Paragraph pTotalFolio = new Paragraph(cadena, textoNegrita);
            reportePDF.add(pTotalFolio);

            cadenaRecibo.append("\r\n");
            reportePDF.add(new Paragraph(" "));

            texto = Mensajes.get("XGRANTOTAL")+":";
            cadena = completaHasta(texto, (((TipoImpresora == TipoPapel.EXTECH_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA3) ? 38 : ((TipoImpresora == TipoPapel.INTERMEC_PR3) ? 47 : ((TipoImpresora == TipoPapel.INTERMEC_PR2) ? 28 : 38)))), TipoAlineacion.DERECHA, false);
            texto = Generales.getFormatoDecimal(Total, "#,###,##0.00");
            cadena += completaHasta(texto, (((TipoImpresora == TipoPapel.EXTECH_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA3) ? 10 : ((TipoImpresora == TipoPapel.INTERMEC_PR3) ? 10 : ((TipoImpresora == TipoPapel.INTERMEC_PR2) ? 10 : 10)))), TipoAlineacion.DERECHA, false);

            cadenaRecibo.append(cadena + "\r\n");
            Paragraph pTotal = new Paragraph(cadena, textoNegrita);
            reportePDF.add(pTotal);

            cadenaRecibo.append("\r\n");
            reportePDF.add(new Paragraph(" "));

            //Ventas por Producto
            Total = 0;
            ProductoAnterior = "";

            texto = completaHasta(Mensajes.get("XVentasProducto").toUpperCase(), (((TipoImpresora == TipoPapel.EXTECH_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA3) ? 48 : ((TipoImpresora == TipoPapel.INTERMEC_PR3) ? 57 : ((TipoImpresora == TipoPapel.INTERMEC_PR2) ? 38 : 48)))), TipoAlineacion.IZQUIERDA, false);

            cadenaRecibo.append(texto + "\r\n");
            Paragraph pTituloTotalProductoPrecio = new Paragraph(texto, tituloSubrayado);
            reportePDF.add(pTituloTotalProductoPrecio);

            ISetDatos isdVentasPorProducto = Consultas.ConsultaReporteVentas.obtenerVentasPorProducto(diaClave);

            while (isdVentasPorProducto.moveToNext()) {
                if (!ProductoAnterior.equals(isdVentasPorProducto.getString("Producto"))){
                    texto = isdVentasPorProducto.getString("Producto");

                    cadenaRecibo.append(texto + "\r\n");
                    Paragraph pProducto = new Paragraph(texto, textoNegrita);
                    reportePDF.add(pProducto);
                }

                texto = " ";
                cadena = completaHasta(texto, (((TipoImpresora == TipoPapel.EXTECH_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA3) ? 5 : ((TipoImpresora == TipoPapel.INTERMEC_PR3) ? 8 : ((TipoImpresora == TipoPapel.INTERMEC_PR2) ? 2 : 5)))), TipoAlineacion.DERECHA, false);
                texto = "-"+ValoresReferencia.getDescripcion("UNIDADV", isdVentasPorProducto.getString("TipoUnidad"));
                cadena += completaHasta(texto, (((TipoImpresora == TipoPapel.EXTECH_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA3) ? 13 : ((TipoImpresora == TipoPapel.INTERMEC_PR3) ? 19 : ((TipoImpresora == TipoPapel.INTERMEC_PR2) ? 7 : 13)))), TipoAlineacion.IZQUIERDA, false);
                texto = isdVentasPorProducto.getString("Cantidad");
                cadena += completaHasta(texto, (((TipoImpresora == TipoPapel.EXTECH_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA3) ? 10 : ((TipoImpresora == TipoPapel.INTERMEC_PR3) ? 10 : ((TipoImpresora == TipoPapel.INTERMEC_PR2) ? 9 : 10)))), TipoAlineacion.DERECHA, false);
                texto = " ";
                cadena += completaHasta(texto, (((TipoImpresora == TipoPapel.EXTECH_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA3) ? 10 : ((TipoImpresora == TipoPapel.INTERMEC_PR3) ? 10 : ((TipoImpresora == TipoPapel.INTERMEC_PR2) ? 10 : 10)))), TipoAlineacion.DERECHA, false);
                texto = Generales.getFormatoDecimal(isdVentasPorProducto.getFloat("Total"), "#,###,##0.00");
                cadena += completaHasta(texto, (((TipoImpresora == TipoPapel.EXTECH_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA3) ? 10 : ((TipoImpresora == TipoPapel.INTERMEC_PR3) ? 10 : ((TipoImpresora == TipoPapel.INTERMEC_PR2) ? 10 : 10)))), TipoAlineacion.DERECHA, false);

                cadenaRecibo.append(cadena + "\r\n");
                Paragraph pVentaDetalle = new Paragraph(cadena, textoNegrita);
                reportePDF.add(pVentaDetalle);

                Total += isdVentasPorProducto.getFloat("Total");
                ProductoAnterior = isdVentasPorProducto.getString("Producto");
            }

            texto = Mensajes.get("XGRANTOTAL")+":";
            cadena = completaHasta(texto, (((TipoImpresora == TipoPapel.EXTECH_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA3) ? 38 : ((TipoImpresora == TipoPapel.INTERMEC_PR3) ? 47 : ((TipoImpresora == TipoPapel.INTERMEC_PR2) ? 28 : 38)))), TipoAlineacion.DERECHA, false);
            texto = Generales.getFormatoDecimal(Total, "#,###,##0.00");
            cadena += completaHasta(texto, (((TipoImpresora == TipoPapel.EXTECH_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA3) ? 10 : ((TipoImpresora == TipoPapel.INTERMEC_PR3) ? 10 : ((TipoImpresora == TipoPapel.INTERMEC_PR2) ? 10 : 10)))), TipoAlineacion.DERECHA, false);

            cadenaRecibo.append(cadena + "\r\n");
            Paragraph pTotalPorProducto = new Paragraph(cadena, textoNegrita);
            reportePDF.add(pTotalPorProducto);

            cadenaRecibo.append("\r\n");
            reportePDF.add(new Paragraph(" "));

            //Ventas Productos Promocionales
            Total = 0;
            ProductoAnterior = "";

            texto = completaHasta(Mensajes.get("XProductosPromocionales").toUpperCase(), (((TipoImpresora == TipoPapel.EXTECH_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA3) ? 48 : ((TipoImpresora == TipoPapel.INTERMEC_PR3) ? 57 : ((TipoImpresora == TipoPapel.INTERMEC_PR2) ? 38 : 48)))), TipoAlineacion.IZQUIERDA, false);

            cadenaRecibo.append(texto + "\r\n");
            Paragraph pTituloTotalProductoPromocional = new Paragraph(texto, tituloSubrayado);
            reportePDF.add(pTituloTotalProductoPromocional);

            ISetDatos isdVentasProductoPromocional = Consultas.ConsultaReporteVentas.obtenerVentasPromocionales(diaClave);

            while (isdVentasProductoPromocional.moveToNext()) {
                if (!ProductoAnterior.equals(isdVentasProductoPromocional.getString("Producto"))){
                    texto = isdVentasProductoPromocional.getString("Producto");

                    cadenaRecibo.append(texto + "\r\n");
                    Paragraph pProducto = new Paragraph(texto, textoNegrita);
                    reportePDF.add(pProducto);
                }

                texto = " ";
                cadena = completaHasta(texto, (((TipoImpresora == TipoPapel.EXTECH_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA3) ? 5 : ((TipoImpresora == TipoPapel.INTERMEC_PR3) ? 8 : ((TipoImpresora == TipoPapel.INTERMEC_PR2) ? 2 : 5)))), TipoAlineacion.DERECHA, false);
                texto = "-"+ValoresReferencia.getDescripcion("UNIDADV", isdVentasProductoPromocional.getString("TipoUnidad"));
                cadena += completaHasta(texto, (((TipoImpresora == TipoPapel.EXTECH_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA3) ? 13 : ((TipoImpresora == TipoPapel.INTERMEC_PR3) ? 19 : ((TipoImpresora == TipoPapel.INTERMEC_PR2) ? 7 : 13)))), TipoAlineacion.IZQUIERDA, false);
                texto = isdVentasProductoPromocional.getString("Cantidad");
                cadena += completaHasta(texto, (((TipoImpresora == TipoPapel.EXTECH_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA3) ? 10 : ((TipoImpresora == TipoPapel.INTERMEC_PR3) ? 10 : ((TipoImpresora == TipoPapel.INTERMEC_PR2) ? 9 : 10)))), TipoAlineacion.DERECHA, false);
                texto = " ";
                cadena += completaHasta(texto, (((TipoImpresora == TipoPapel.EXTECH_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA3) ? 10 : ((TipoImpresora == TipoPapel.INTERMEC_PR3) ? 10 : ((TipoImpresora == TipoPapel.INTERMEC_PR2) ? 10 : 10)))), TipoAlineacion.DERECHA, false);
                texto = Generales.getFormatoDecimal(isdVentasProductoPromocional.getFloat("Total"), "#,###,##0.00");
                cadena += completaHasta(texto, (((TipoImpresora == TipoPapel.EXTECH_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA3) ? 10 : ((TipoImpresora == TipoPapel.INTERMEC_PR3) ? 10 : ((TipoImpresora == TipoPapel.INTERMEC_PR2) ? 10 : 10)))), TipoAlineacion.DERECHA, false);

                cadenaRecibo.append(cadena + "\r\n");
                Paragraph pVentaDetalle = new Paragraph(cadena, textoNegrita);
                reportePDF.add(pVentaDetalle);

                Total += isdVentasProductoPromocional.getFloat("Total");
                ProductoAnterior = isdVentasProductoPromocional.getString("Producto");
            }

            texto = Mensajes.get("XGRANTOTAL")+":";
            cadena = completaHasta(texto, (((TipoImpresora == TipoPapel.EXTECH_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA3) ? 38 : ((TipoImpresora == TipoPapel.INTERMEC_PR3) ? 47 : ((TipoImpresora == TipoPapel.INTERMEC_PR2) ? 28 : 38)))), TipoAlineacion.DERECHA, false);
            texto = Generales.getFormatoDecimal(Total, "#,###,##0.00");
            cadena += completaHasta(texto, (((TipoImpresora == TipoPapel.EXTECH_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA3) ? 10 : ((TipoImpresora == TipoPapel.INTERMEC_PR3) ? 10 : ((TipoImpresora == TipoPapel.INTERMEC_PR2) ? 10 : 10)))), TipoAlineacion.DERECHA, false);

            cadenaRecibo.append(cadena + "\r\n");
            Paragraph pTotalProductoPromocional = new Paragraph(cadena, textoNegrita);
            reportePDF.add(pTotalProductoPromocional);

            cadenaRecibo.append("\r\n");
            reportePDF.add(new Paragraph(" "));

            //Ventas por Producto por Precio
            if (TotalProductoPrecio){
                texto = completaHasta(Mensajes.get("XTotalPrecio").toUpperCase(), (((TipoImpresora == TipoPapel.EXTECH_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA3) ? 48 : ((TipoImpresora == TipoPapel.INTERMEC_PR3) ? 57 : ((TipoImpresora == TipoPapel.INTERMEC_PR2) ? 38 : 48)))), TipoAlineacion.IZQUIERDA, false);

                cadenaRecibo.append(texto + "\r\n");
                Paragraph pTituloTotalProductoPrecio1 = new Paragraph(texto, tituloSubrayado);
                reportePDF.add(pTituloTotalProductoPrecio1);

                ISetDatos isdVentasProductoPrecio = Consultas.ConsultaReporteVentas.obtenerVentasPorProductoPorPrecio(diaClave);

                while (isdVentasProductoPrecio.moveToNext()) {
                    texto = ValoresReferencia.getDescripcion("UNIDADV", isdVentasProductoPrecio.getString("TipoUnidad"));
                    cadena = completaHasta(texto, (((TipoImpresora == TipoPapel.EXTECH_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA3) ? 16 : ((TipoImpresora == TipoPapel.INTERMEC_PR3) ? 16 : ((TipoImpresora == TipoPapel.INTERMEC_PR2) ? 16 : 16)))), TipoAlineacion.IZQUIERDA, false);
                    texto = Generales.getFormatoDecimal(isdVentasProductoPrecio.getFloat("Precio"), "#,###,##0.00")+ " =";
                    cadena += completaHasta(texto, (((TipoImpresora == TipoPapel.EXTECH_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA3) ? 22 : ((TipoImpresora == TipoPapel.INTERMEC_PR3) ? 31 : ((TipoImpresora == TipoPapel.INTERMEC_PR2) ? 12 : 22)))), TipoAlineacion.DERECHA, false);
                    texto = isdVentasProductoPrecio.getString("Cantidad");
                    cadena += completaHasta(texto, (((TipoImpresora == TipoPapel.EXTECH_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA3) ? 10 : ((TipoImpresora == TipoPapel.INTERMEC_PR3) ? 10 : ((TipoImpresora == TipoPapel.INTERMEC_PR2) ? 10 : 10)))), TipoAlineacion.DERECHA, false);

                    cadenaRecibo.append(cadena + "\r\n");
                    Paragraph pVenta = new Paragraph(cadena, textoNegrita);
                    reportePDF.add(pVenta);
                }

                cadenaRecibo.append("\r\n");
                reportePDF.add(new Paragraph(" "));

                isdVentasProductoPrecio.close();
            }

            //Ventas por KiloLitros
            ISetDatos isdVentasKiloLitros = Consultas.ConsultaReporteVentas.obtenerVentasKiloLitros(diaClave);

            while (isdVentasKiloLitros.moveToNext()) {
                texto =  Mensajes.get("XVentaTotalKgLts")+":   "+isdVentasKiloLitros.getString("KiloLitros");

                cadenaRecibo.append(texto + "\r\n");
                Paragraph pVentaKiloLitros = new Paragraph(texto, textoNegrita);
                reportePDF.add(pVentaKiloLitros);
            }

            isdVentasDetallado.close();
            isdVentasPorProducto.close();
            isdVentasProductoPromocional.close();
            isdVentasKiloLitros.close();
        }else{
            //Titulos
            texto = Mensajes.get("XFolio");
            cadena = completaHasta(texto, (((TipoImpresora == TipoPapel.EXTECH_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA3) ? 16 : ((TipoImpresora == TipoPapel.INTERMEC_PR3) ? 16 : ((TipoImpresora == TipoPapel.INTERMEC_PR2) ? 16 : 16)))), TipoAlineacion.IZQUIERDA, false);
            texto = Mensajes.get("XCliente");
            cadena += completaHasta(texto, (((TipoImpresora == TipoPapel.EXTECH_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA3) ? 22 : ((TipoImpresora == TipoPapel.INTERMEC_PR3) ? 31 : ((TipoImpresora == TipoPapel.INTERMEC_PR2) ? 12 : 22)))), TipoAlineacion.IZQUIERDA, false);
            texto = Mensajes.get("XTotalMin");
            cadena += completaHasta(texto, (((TipoImpresora == TipoPapel.EXTECH_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA3) ? 10 : ((TipoImpresora == TipoPapel.INTERMEC_PR3) ? 10 : ((TipoImpresora == TipoPapel.INTERMEC_PR2) ? 10 : 10)))), TipoAlineacion.DERECHA, false);

            cadenaRecibo.append(cadena + "\r\n");
            StringBuilder sbLinea = new StringBuilder();
            imprimeLineaPunteada(sbLinea,tamanioLetra.mLongTotal);
            cadenaRecibo.append(sbLinea + "\r\n");

            Paragraph tituloDetalle1 = new Paragraph(cadena, tituloSubrayado);
            reportePDF.add(tituloDetalle1);

            //Ventas General
            ISetDatos isdVentasGeneral = Consultas.ConsultaReporteVentas.obtenerVentasGeneral(diaClave);
            float Total = 0;

            while (isdVentasGeneral.moveToNext()) {
                texto = isdVentasGeneral.getString("Folio");
                cadena = completaHasta(texto, (((TipoImpresora == TipoPapel.EXTECH_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA3) ? 16 : ((TipoImpresora == TipoPapel.INTERMEC_PR3) ? 16 : ((TipoImpresora == TipoPapel.INTERMEC_PR2) ? 16 : 16)))), TipoAlineacion.IZQUIERDA, false);
                texto = isdVentasGeneral.getString("NombreCorto");
                cadena += completaHasta(texto, (((TipoImpresora == TipoPapel.EXTECH_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA3) ? 22 : ((TipoImpresora == TipoPapel.INTERMEC_PR3) ? 31 : ((TipoImpresora == TipoPapel.INTERMEC_PR2) ? 12 : 22)))), TipoAlineacion.IZQUIERDA, false);
                texto = Generales.getFormatoDecimal(isdVentasGeneral.getFloat("Total"), "#,###,##0.00");
                cadena += completaHasta(texto, (((TipoImpresora == TipoPapel.EXTECH_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA3) ? 10 : ((TipoImpresora == TipoPapel.INTERMEC_PR3) ? 10 : ((TipoImpresora == TipoPapel.INTERMEC_PR2) ? 10 : 10)))), TipoAlineacion.DERECHA, false);

                cadenaRecibo.append(cadena + "\r\n");
                Paragraph pVenta = new Paragraph(cadena, textoNegrita);
                reportePDF.add(pVenta);

                Total += isdVentasGeneral.getFloat("Total");
            }

            cadenaRecibo.append("\r\n");
            reportePDF.add(new Paragraph(" "));

            texto = Mensajes.get("XGranTotal")+":";
            cadena = completaHasta(texto, (((TipoImpresora == TipoPapel.EXTECH_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA3) ? 38 : ((TipoImpresora == TipoPapel.INTERMEC_PR3) ? 47 : ((TipoImpresora == TipoPapel.INTERMEC_PR2) ? 28 : 38)))), TipoAlineacion.DERECHA, false);
            texto = Generales.getFormatoDecimal(Total, "#,###,##0.00");
            cadena += completaHasta(texto, (((TipoImpresora == TipoPapel.EXTECH_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA3) ? 10 : ((TipoImpresora == TipoPapel.INTERMEC_PR3) ? 10 : ((TipoImpresora == TipoPapel.INTERMEC_PR2) ? 10 : 10)))), TipoAlineacion.DERECHA, true);

            cadenaRecibo.append(cadena + "\r\n");
            Paragraph pTotal = new Paragraph(cadena, textoNegrita);
            reportePDF.add(pTotal);

            cadenaRecibo.append("\r\n");
            reportePDF.add(new Paragraph(" "));

            //Ventas por Producto por Precio
            if (TotalProductoPrecio){
                texto = completaHasta(Mensajes.get("XTotalPrecio").toUpperCase(), (((TipoImpresora == TipoPapel.EXTECH_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA3) ? 48 : ((TipoImpresora == TipoPapel.INTERMEC_PR3) ? 57 : ((TipoImpresora == TipoPapel.INTERMEC_PR2) ? 38 : 48)))), TipoAlineacion.IZQUIERDA, false);

                cadenaRecibo.append(texto + "\r\n");
                Paragraph pTituloTotalProductoPrecio = new Paragraph(texto, tituloSubrayado);
                reportePDF.add(pTituloTotalProductoPrecio);

                ISetDatos isdVentasProductoPrecio = Consultas.ConsultaReporteVentas.obtenerVentasPorProductoPorPrecio(diaClave);

                while (isdVentasProductoPrecio.moveToNext()) {
                    texto = ValoresReferencia.getDescripcion("UNIDADV", isdVentasProductoPrecio.getString("TipoUnidad"));
                    cadena = completaHasta(texto, (((TipoImpresora == TipoPapel.EXTECH_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA3) ? 16 : ((TipoImpresora == TipoPapel.INTERMEC_PR3) ? 16 : ((TipoImpresora == TipoPapel.INTERMEC_PR2) ? 16 : 16)))), TipoAlineacion.IZQUIERDA, false);
                    texto = Generales.getFormatoDecimal(isdVentasProductoPrecio.getFloat("Precio"), "#,###,##0.00")+ " =";
                    cadena += completaHasta(texto, (((TipoImpresora == TipoPapel.EXTECH_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA3) ? 22 : ((TipoImpresora == TipoPapel.INTERMEC_PR3) ? 31 : ((TipoImpresora == TipoPapel.INTERMEC_PR2) ? 12 : 22)))), TipoAlineacion.DERECHA, false);
                    texto = isdVentasProductoPrecio.getString("Cantidad");
                    cadena += completaHasta(texto, (((TipoImpresora == TipoPapel.EXTECH_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA3) ? 10 : ((TipoImpresora == TipoPapel.INTERMEC_PR3) ? 10 : ((TipoImpresora == TipoPapel.INTERMEC_PR2) ? 10 : 10)))), TipoAlineacion.DERECHA, false);

                    cadenaRecibo.append(cadena + "\r\n");
                    Paragraph pVenta = new Paragraph(cadena, textoNegrita);
                    reportePDF.add(pVenta);
                }

                cadenaRecibo.append("\r\n");
                reportePDF.add(new Paragraph(" "));

                isdVentasProductoPrecio.close();
            }

            //Ventas por KiloLitros
            ISetDatos isdVentasKiloLitros = Consultas.ConsultaReporteVentas.obtenerVentasKiloLitros(diaClave);

            while (isdVentasKiloLitros.moveToNext()) {
                texto =  Mensajes.get("XVentaTotalKgLts")+":   "+isdVentasKiloLitros.getString("KiloLitros");

                cadenaRecibo.append(texto + "\r\n");
                Paragraph pVentaKiloLitros = new Paragraph(texto, textoNegrita);
                reportePDF.add(pVentaKiloLitros);
            }

            isdVentasGeneral.close();
            isdVentasKiloLitros.close();
        }
        document.add(reportePDF);
    }

    private static void generarReporteDescargasDevolucionAlmacen(int reporte, StringBuilder cadenaRecibo, Document document, boolean detalladoGeneral, String filtroFecha, Date fechaIni, Date fechaFin) throws Exception
    {
            String cadena = "";
            String texto = "";
            short TipoImpresora = ((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp;

            Paragraph reportePDF = new Paragraph();
            reportePDF.setFont(textoNegrita);
            Vendedor vendedor = (Vendedor) Sesion.get(Campo.VendedorActual);
            setTamanioDefault(vendedor.TipoModImp);
            TamanioLetra tamanioLetra;
            tamanioLetra = tamanioDefault;

            if (((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.ZEBRA_TERMICA2 || ((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.ZEBRA_CAMEO2) {
                cadena = "{" + tamanioLetra.mTamanio + " " + tamanioLetra.mAlto + "}";
            } else if (((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.INTERMEC_PR2 || ((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.INTERMEC_PR3) {
                //Se usa el mAlto para indentificar si la letra es normal o doble 0= normal 1= doble
                //En la cadena de los bytes no se debe dejar espacios, si no falla y se consideran hasta el momento
                //3 bytes en el mensaje, por lo que si se mete menos o mas, hay que cambiar el codigo en BluetoothPrint
                if (tamanioLetra.mAlto != 0) {
                    cadena = "{27,33," + tamanioLetra.mTamanio + "}";
                } else {
                    cadena = "{27,119," + tamanioLetra.mTamanio + "}";
                }
            } else if (((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp == TipoPapel.ZEBRA_TERMICA3) {
                cadena = "! U1 SETLP 7 " + tamanioLetra.mTamanio + " " + tamanioLetra.mAlto + " ";
            } else {
                cadena = "{" + tamanioLetra.mTamanio + "}";
            }

            //Encabezado Reporte

            //ISetDatos encabezado = ConsultasImpresionTicket.obtenerEncabezado();
            ISetDatos encabezado = ConsultasImpresionTicket.obtenerEncabezado();
            encabezado.moveToFirst();

            texto = encabezado.getString("NombreEmpresa");
            cadena = cadena + alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, tamanioLetra.mLongTotal);
            cadenaRecibo.append(cadena + "\r\n");

            Paragraph empresa = new Paragraph(texto, textoNegrita);
            empresa.setAlignment(Element.ALIGN_CENTER);
            reportePDF.add(empresa);

            texto = Mensajes.get("XRFC") + ": " + encabezado.getString("RFC");
            cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, tamanioLetra.mLongTotal);
            cadenaRecibo.append(cadena + "\r\n");

            Paragraph rfc = new Paragraph(texto, textoNegrita);
            rfc.setAlignment(Element.ALIGN_CENTER);
            reportePDF.add(rfc);

            texto = encabezado.getString("Calle");
            cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, tamanioLetra.mLongTotal);
            cadenaRecibo.append(cadena + "\r\n");

            Paragraph calle = new Paragraph(texto, textoNegrita);
            calle.setAlignment(Element.ALIGN_CENTER);
            reportePDF.add(calle);

            texto = encabezado.getString("Numero");
            cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, tamanioLetra.mLongTotal);
            cadenaRecibo.append(cadena + "\r\n");

            Paragraph numero = new Paragraph(texto, textoNegrita);
            numero.setAlignment(Element.ALIGN_CENTER);
            reportePDF.add(numero);

            texto = encabezado.getString("Colonia");
            cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, tamanioLetra.mLongTotal);
            cadenaRecibo.append(cadena + "\r\n");

            Paragraph colonia = new Paragraph(texto, textoNegrita);
            colonia.setAlignment(Element.ALIGN_CENTER);
            reportePDF.add(colonia);

            texto = encabezado.getString("Ciudad") + ", " + encabezado.getString("Region");
            cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, tamanioLetra.mLongTotal);
            cadenaRecibo.append(cadena + "\r\n");
            cadenaRecibo.append("\r\n");

            Paragraph ciudad = new Paragraph(texto, textoNegrita);
            ciudad.setAlignment(Element.ALIGN_CENTER);
            reportePDF.add(ciudad);
            reportePDF.add(new Paragraph(" "));
            encabezado.close();

            //Detalle Encabezado
            texto = Mensajes.get("XImpresion") + ": " + Generales.getFechaHoraActualStr("dd/MM/yyyy hh:mm:ss");
            cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, tamanioLetra.mLongTotal);
            cadenaRecibo.append(cadena + "\r\n");

            Paragraph impresion = new Paragraph(texto, textoNegrita);
            impresion.setAlignment(Element.ALIGN_CENTER);
            reportePDF.add(impresion);

            texto = Mensajes.get("XVendedor") + ": " + ((Usuario) Sesion.get(Campo.UsuarioActual)).Nombre;
            cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, tamanioLetra.mLongTotal);
            cadenaRecibo.append(cadena + "\r\n");

            Paragraph ven = new Paragraph(texto, textoNegrita);
            ven.setAlignment(Element.ALIGN_CENTER);
            reportePDF.add(ven);
            reportePDF.add(new Paragraph(" "));

            String tipoReporte = "";
            if (detalladoGeneral) {
                tipoReporte = Mensajes.get("XDetallado");
            } else {
                tipoReporte = Mensajes.get("XGeneral");
            }

            texto = ValoresReferencia.getDescripcion("REPORTEA", String.valueOf(reporte)) + " - " + tipoReporte;
            cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, tamanioLetra.mLongTotal);
            cadenaRecibo.append(cadena + "\r\n");
            cadenaRecibo.append("\r\n");

            Paragraph titulo = new Paragraph(texto, tituloRojo);
            titulo.setAlignment(Element.ALIGN_CENTER);
            reportePDF.add(titulo);
            reportePDF.add(new Paragraph(" "));

        //Cuerpo del reporte
        ISetDatos isdProductos = Consultas.ConsultaReporteDescargasDevolucion.obtenerProdcutos(filtroFecha);
        ISetDatos isdEnvaces = Consultas.ConsultaReporteDescargasDevolucion.obtenerEnvace(filtroFecha);
        ISetDatos isdProductosCopia = Consultas.ConsultaReporteDescargasDevolucion.obtenerProdcutos(filtroFecha);
        ISetDatos isdEnvacesCopia = Consultas.ConsultaReporteDescargasDevolucion.obtenerEnvace(filtroFecha);
        ISetDatos isdResumenGeneral = Consultas.ConsultaReporteDescargasDevolucion.obtenerResumenGeneral(filtroFecha);

        if (detalladoGeneral) {
            //Detallado
            //Titulos
            StringBuilder sbLinea = new StringBuilder();
            imprimeLineaPunteada(sbLinea, tamanioLetra.mLongTotal);
            cadenaRecibo.append(sbLinea);

            texto = Mensajes.get("XProducto");
            cadena = completaHasta(texto.toUpperCase(), (((TipoImpresora == TipoPapel.EXTECH_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA3) ? 18 : ((TipoImpresora == TipoPapel.INTERMEC_PR3) ? 27 : ((TipoImpresora == TipoPapel.INTERMEC_PR2) ? 11 : 18)))), TipoAlineacion.IZQUIERDA, false);
            texto = Mensajes.get("XUnidad");
            cadena += completaHasta(texto, (((TipoImpresora == TipoPapel.EXTECH_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA3) ? 15 : ((TipoImpresora == TipoPapel.INTERMEC_PR3) ? 10 : ((TipoImpresora == TipoPapel.INTERMEC_PR2) ? 9 : 10)))), TipoAlineacion.DERECHA, false);
            texto = Mensajes.get("XCantidad");
            cadena += completaHasta(texto, (((TipoImpresora == TipoPapel.EXTECH_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA3) ? 15 : ((TipoImpresora == TipoPapel.INTERMEC_PR3) ? 10 : ((TipoImpresora == TipoPapel.INTERMEC_PR2) ? 10 : 10)))), TipoAlineacion.DERECHA, true);

            cadenaRecibo.append(cadena + "\r\n");
            sbLinea = new StringBuilder();
            imprimeLineaPunteada(sbLinea, tamanioLetra.mLongTotal);
            cadenaRecibo.append(sbLinea);


            texto = Mensajes.get("XProducto");
            cadena = completaHasta(texto.toUpperCase(), 31, TipoAlineacion.IZQUIERDA, false);
            texto = Mensajes.get("XUnidad");
            cadena += completaHasta(texto, 10, TipoAlineacion.DERECHA, false);
            texto = Mensajes.get("XCantidad");
            cadena += completaHasta(texto, 10, TipoAlineacion.DERECHA, true);

            Paragraph tituloDetalle1 = new Paragraph(cadena, tituloSubrayado);
            reportePDF.add(tituloDetalle1);


            // Productos Unidades y Cantidades


            float sumaTotal = 0;
            String folio="";
            String productoClave = "";
            String cadenaPDF = ""; // esta variable sera para PDF

             while (isdProductos.moveToNext())
             {

                if (!folio.contains(isdProductos.getString("Folio")) )
                {
                    cadenaRecibo.append("\r\n");
                    reportePDF.add(new Paragraph(" "));
                    texto = isdProductos.getString("TipoTransaccion") +" "+ isdProductos.getString("Folio");
                    cadena = completaHasta(texto, (((TipoImpresora == TipoPapel.EXTECH_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA3) ? 38 : ((TipoImpresora == TipoPapel.INTERMEC_PR3) ? 47 : ((TipoImpresora == TipoPapel.INTERMEC_PR2) ? 28 : 38)))), TipoAlineacion.IZQUIERDA, false);
                    //cadena = completaHasta(texto, texto.length() , TipoAlineacion.IZQUIERDA, false);
                    cadenaPDF = completaHasta(texto, texto.length(),TipoAlineacion.DERECHA,true);

                    cadenaRecibo.append(cadena + "\r\n");
                     Paragraph pFolio = new Paragraph(cadenaPDF, textoNegrita);
                    reportePDF.add(pFolio);

                }

                 if(!productoClave.contains(isdProductos.getString("ProductoClave"))) {
                     texto = isdProductos.getString("ProductoClave") + " " + isdProductos.getString("Nombre");
                 } else {
                     texto = " ";
                 }
                 cadena = completaHasta(texto, (((TipoImpresora == TipoPapel.EXTECH_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA3) ? 25 : ((TipoImpresora == TipoPapel.INTERMEC_PR3) ? 47 : ((TipoImpresora == TipoPapel.INTERMEC_PR2) ? 28 : 38)))), TipoAlineacion.IZQUIERDA, true);
                 cadenaPDF = completaHasta(texto, texto.length() + (36 - texto.length()),TipoAlineacion.IZQUIERDA, false);
                 texto = ValoresReferencia.getDescripcion("UNIDADV", isdProductos.getString("TipoUnidad"));
                 cadena += completaHasta(texto, (((TipoImpresora == TipoPapel.EXTECH_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA3) ? 10 : ((TipoImpresora == TipoPapel.INTERMEC_PR3) ? 47 : ((TipoImpresora == TipoPapel.INTERMEC_PR2) ? 28 : 38)))), TipoAlineacion.DERECHA, true);
                 cadenaPDF += completaHasta(texto, texto.length() + 8,TipoAlineacion.IZQUIERDA, false);
                 texto = isdProductos.getString("Cantidad");
                 cadena += completaHasta(texto, (((TipoImpresora == TipoPapel.EXTECH_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA3) ? 10 : ((TipoImpresora == TipoPapel.INTERMEC_PR3) ? 47 : ((TipoImpresora == TipoPapel.INTERMEC_PR2) ? 28 : 38)))), TipoAlineacion.DERECHA, true);
                 cadenaPDF += completaHasta(texto, texto.length(),TipoAlineacion.DERECHA, true);

                 cadenaRecibo.append(cadena +"\r\n");
                 Paragraph pProducto = new Paragraph(cadenaPDF, textoNegrita);
                 reportePDF.add(pProducto);

                 folio += isdProductos.getString("Folio") + ", ";


            }

            cadenaRecibo.append("\r\n");
            reportePDF.add(new Paragraph(" "));

            sbLinea = new StringBuilder();
            imprimeLineaPunteada(sbLinea, tamanioLetra.mLongTotal);
            cadenaRecibo.append(sbLinea);

            //Envase
            texto = Mensajes.get("XEnvase");
            cadena = completaHasta(texto.toUpperCase(), (((TipoImpresora == TipoPapel.EXTECH_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA3) ? 18 : ((TipoImpresora == TipoPapel.INTERMEC_PR3) ? 27 : ((TipoImpresora == TipoPapel.INTERMEC_PR2) ? 11 : 18)))), TipoAlineacion.IZQUIERDA, false);
            texto = Mensajes.get("XUnidad");
            cadena += completaHasta(texto, (((TipoImpresora == TipoPapel.EXTECH_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA3) ? 15 : ((TipoImpresora == TipoPapel.INTERMEC_PR3) ? 10 : ((TipoImpresora == TipoPapel.INTERMEC_PR2) ? 9 : 10)))), TipoAlineacion.DERECHA, false);
            texto = Mensajes.get("XCantidad");
            cadena += completaHasta(texto, (((TipoImpresora == TipoPapel.EXTECH_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA3) ? 15 : ((TipoImpresora == TipoPapel.INTERMEC_PR3) ? 10 : ((TipoImpresora == TipoPapel.INTERMEC_PR2) ? 10 : 10)))), TipoAlineacion.DERECHA, true);

            cadenaRecibo.append(cadena + "\r\n");
            sbLinea = new StringBuilder();
            imprimeLineaPunteada(sbLinea, tamanioLetra.mLongTotal);
            cadenaRecibo.append(sbLinea);

            texto = Mensajes.get("XEnvase");
            cadena = completaHasta(texto.toUpperCase(), 31, TipoAlineacion.IZQUIERDA, false);
            texto = Mensajes.get("XUnidad");
            cadena += completaHasta(texto, 10, TipoAlineacion.DERECHA, false);
            texto = Mensajes.get("XCantidad");
            cadena += completaHasta(texto, 10, TipoAlineacion.DERECHA, true);

            tituloDetalle1 = new Paragraph(cadena, tituloSubrayado);
            reportePDF.add(tituloDetalle1);


            // Productos Unidades y Cantidades


            sumaTotal = 0;
            folio="";
            cadenaPDF = ""; // esta variable sera para PDF

            while (isdEnvaces.moveToNext()) {

                if (!folio.contains(isdEnvaces.getString("Folio")) )
                {
                    cadenaRecibo.append("\r\n");
                    reportePDF.add(new Paragraph(" "));
                    texto = isdEnvaces.getString("TipoTransaccion") +" "+ isdEnvaces.getString("Folio");
                    cadena = completaHasta(texto, (((TipoImpresora == TipoPapel.EXTECH_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA3) ? 38 : ((TipoImpresora == TipoPapel.INTERMEC_PR3) ? 47 : ((TipoImpresora == TipoPapel.INTERMEC_PR2) ? 28 : 38)))), TipoAlineacion.IZQUIERDA, false);
                    cadenaPDF = completaHasta(texto, texto.length(),TipoAlineacion.DERECHA,true);

                    cadenaRecibo.append(cadena + "\r\n");
                    Paragraph pFolio = new Paragraph(cadenaPDF, textoNegrita);
                    reportePDF.add(pFolio);

                }

                if(!productoClave.contains(isdEnvaces.getString("ProductoClave"))) {
                    texto = isdEnvaces.getString("ProductoClave") + " " + isdEnvaces.getString("Nombre");
                } else {
                    texto = " ";
                }
                cadena = completaHasta(texto, (((TipoImpresora == TipoPapel.EXTECH_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA3) ? 25 : ((TipoImpresora == TipoPapel.INTERMEC_PR3) ? 47 : ((TipoImpresora == TipoPapel.INTERMEC_PR2) ? 28 : 38)))), TipoAlineacion.IZQUIERDA, true);
                cadenaPDF = completaHasta(texto, texto.length() + (36 - texto.length()),TipoAlineacion.IZQUIERDA, false);
                texto = ValoresReferencia.getDescripcion("UNIDADV", isdEnvaces.getString("TipoUnidad"));
                cadena += completaHasta(texto, (((TipoImpresora == TipoPapel.EXTECH_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA3) ? 10 : ((TipoImpresora == TipoPapel.INTERMEC_PR3) ? 47 : ((TipoImpresora == TipoPapel.INTERMEC_PR2) ? 28 : 38)))), TipoAlineacion.DERECHA, true);
                cadenaPDF += completaHasta(texto, texto.length() + 8,TipoAlineacion.IZQUIERDA, false);
                texto = isdEnvaces.getString("Cantidad");
                cadena += completaHasta(texto, (((TipoImpresora == TipoPapel.EXTECH_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA3) ? 10 : ((TipoImpresora == TipoPapel.INTERMEC_PR3) ? 47 : ((TipoImpresora == TipoPapel.INTERMEC_PR2) ? 28 : 38)))), TipoAlineacion.DERECHA, true);
                cadenaPDF += completaHasta(texto, texto.length(),TipoAlineacion.DERECHA, true);

                cadenaRecibo.append(cadena +"\r\n");
                Paragraph pProducto = new Paragraph(cadenaPDF, textoNegrita);
                reportePDF.add(pProducto);

                folio += isdEnvaces.getString("Folio") + ", ";
            }

            cadenaRecibo.append("\r\n");
            reportePDF.add(new Paragraph(" "));

            // RESUMEN
            // Producto

            sbLinea = new StringBuilder();
            imprimeLineaPunteada(sbLinea, tamanioLetra.mLongTotal);
            cadenaRecibo.append(sbLinea);

            texto = Mensajes.get("XRESUMEN");
            cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, tamanioLetra.mLongTotal);
            cadenaRecibo.append(cadena + "\r\n");
            sbLinea = new StringBuilder();
            imprimeLineaPunteada(sbLinea, tamanioLetra.mLongTotal);
            cadenaRecibo.append(sbLinea);

            Paragraph pResumen = new Paragraph(texto, tituloSubrayado);
            pResumen.setAlignment(Element.ALIGN_CENTER);
            reportePDF.add(pResumen);

            reportePDF.add(new Paragraph(" "));

            texto = Mensajes.get("XProducto");
            cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, tamanioLetra.mLongTotal);
            cadenaRecibo.append(cadena + "\r\n");


            Paragraph pProducto = new Paragraph(texto, textoNegrita);
            pProducto.setAlignment(Element.ALIGN_CENTER);
            reportePDF.add(pProducto);

            reportePDF.add(new Paragraph(" "));

            folio = "";
            sumaTotal = 0;
            int totalSeccion = 0;
            boolean primeraVuelta = true;

            while (isdProductosCopia.moveToNext()) {

                if (!folio.contains(isdProductosCopia.getString("Folio")) )
                {
                    if(!primeraVuelta)
                    {
                        texto = Mensajes.get("XTotal");
                        cadena = completaHasta(texto, (((TipoImpresora == TipoPapel.EXTECH_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA3) ? 35 : ((TipoImpresora == TipoPapel.INTERMEC_PR3) ? 47 : ((TipoImpresora == TipoPapel.INTERMEC_PR2) ? 28 : 38)))), TipoAlineacion.DERECHA, true);
                        cadenaPDF = completaHasta(texto, texto.length() + (39 - texto.length()),TipoAlineacion.DERECHA, false);
                        texto = String.valueOf(totalSeccion);
                        cadena += completaHasta(texto, (((TipoImpresora == TipoPapel.EXTECH_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA3) ? 10 : ((TipoImpresora == TipoPapel.INTERMEC_PR3) ? 47 : ((TipoImpresora == TipoPapel.INTERMEC_PR2) ? 28 : 38)))), TipoAlineacion.DERECHA, true);
                        cadenaPDF += completaHasta(texto, texto.length() + 6,TipoAlineacion.DERECHA, true);

                        cadenaRecibo.append(cadena + "\r\n");
                        Paragraph pFolio = new Paragraph(cadenaPDF, textoNegrita);
                        reportePDF.add(pFolio);

                        totalSeccion = 0;

                    }

                    reportePDF.add(new Paragraph(" "));
                    texto = isdProductosCopia.getString("TipoTransaccion");
                    cadena = completaHasta(texto, 20, TipoAlineacion.IZQUIERDA, false);
                    cadenaPDF = completaHasta(texto, 20,TipoAlineacion.IZQUIERDA,false);

                    cadenaRecibo.append(cadena + "\r\n");
                    Paragraph pFolio = new Paragraph(cadenaPDF, textoNegrita);
                    reportePDF.add(pFolio);

                }


                texto = isdProductosCopia.getString("ProductoClave") + " " + isdProductosCopia.getString("Nombre");
                cadena = completaHasta(texto, (((TipoImpresora == TipoPapel.EXTECH_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA3) ? 25 : ((TipoImpresora == TipoPapel.INTERMEC_PR3) ? 47 : ((TipoImpresora == TipoPapel.INTERMEC_PR2) ? 28 : 38)))), TipoAlineacion.IZQUIERDA, true);
                cadenaPDF = completaHasta(texto, texto.length() + (49 - texto.length()),TipoAlineacion.IZQUIERDA, false);
                texto = isdProductosCopia.getString("Total");
                cadena += completaHasta(texto, (((TipoImpresora == TipoPapel.EXTECH_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA3) ? 20 : ((TipoImpresora == TipoPapel.INTERMEC_PR3) ? 47 : ((TipoImpresora == TipoPapel.INTERMEC_PR2) ? 28 : 38)))), TipoAlineacion.DERECHA, true);
                cadenaPDF += completaHasta(texto, texto.length(),TipoAlineacion.DERECHA, true);

                cadenaRecibo.append(cadena +"\r\n");
                pProducto = new Paragraph(cadenaPDF, textoNegrita);
                reportePDF.add(pProducto);

                folio += isdProductosCopia.getString("Folio") + ", ";
                sumaTotal += isdProductosCopia.getInt("Total");
                totalSeccion += isdProductosCopia.getInt("Total");
                primeraVuelta = false;

            }

            texto = Mensajes.get("XTotal");
            cadena = completaHasta(texto, (((TipoImpresora == TipoPapel.EXTECH_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA3) ? 35 : ((TipoImpresora == TipoPapel.INTERMEC_PR3) ? 47 : ((TipoImpresora == TipoPapel.INTERMEC_PR2) ? 28 : 38)))), TipoAlineacion.DERECHA, true);
            cadenaPDF = completaHasta(texto, texto.length() + (39 - texto.length()),TipoAlineacion.DERECHA, false);
            texto = String.valueOf(totalSeccion);
            cadena += completaHasta(texto, (((TipoImpresora == TipoPapel.EXTECH_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA3) ? 10 : ((TipoImpresora == TipoPapel.INTERMEC_PR3) ? 47 : ((TipoImpresora == TipoPapel.INTERMEC_PR2) ? 28 : 38)))), TipoAlineacion.DERECHA, true);
            cadenaPDF += completaHasta(texto, texto.length() + 6,TipoAlineacion.DERECHA, true);

            cadenaRecibo.append(cadena + "\r\n");
            Paragraph pFolio = new Paragraph(cadenaPDF, textoNegrita);
            reportePDF.add(pFolio);

            cadenaRecibo.append("\r\n");
            reportePDF.add(new Paragraph(""));

            texto = Mensajes.get("XTotal");
            cadena = completaHasta(texto, (((TipoImpresora == TipoPapel.EXTECH_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA3) ? 35 : ((TipoImpresora == TipoPapel.INTERMEC_PR3) ? 47 : ((TipoImpresora == TipoPapel.INTERMEC_PR2) ? 28 : 38)))), TipoAlineacion.DERECHA, true);
            cadenaPDF = completaHasta(texto, texto.length() + (39 - texto.length()),TipoAlineacion.DERECHA, false);
            texto = String.valueOf(sumaTotal);
            cadena += completaHasta(texto, (((TipoImpresora == TipoPapel.EXTECH_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA3) ? 10 : ((TipoImpresora == TipoPapel.INTERMEC_PR3) ? 47 : ((TipoImpresora == TipoPapel.INTERMEC_PR2) ? 28 : 38)))), TipoAlineacion.DERECHA, true);
            cadenaPDF += completaHasta(texto, texto.length() + 6, TipoAlineacion.DERECHA, true);

            cadenaRecibo.append(cadena +"\r\n");
            pProducto = new Paragraph(cadenaPDF, textoNegrita);
            reportePDF.add(pProducto);


            //RESUMEN
            //ENVASE

            reportePDF.add(new Paragraph(" "));
            cadenaRecibo.append("\r\n");

            texto = Mensajes.get("XEnvase");
            cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, tamanioLetra.mLongTotal);
            cadenaRecibo.append(cadena + "\r\n");


            Paragraph pEnvase = new Paragraph(texto, textoNegrita);
            pEnvase.setAlignment(Element.ALIGN_CENTER);
            reportePDF.add(pEnvase);

            reportePDF.add(new Paragraph(" "));

            folio = "";
            sumaTotal = 0;
            totalSeccion = 0;
            primeraVuelta = true;

            while (isdEnvacesCopia.moveToNext()) {

                if (!folio.contains(isdEnvacesCopia.getString("Folio")) )
                {
                    if(!primeraVuelta)
                    {
                        texto = Mensajes.get("XTotal");
                        cadena = completaHasta(texto, (((TipoImpresora == TipoPapel.EXTECH_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA3) ? 35 : ((TipoImpresora == TipoPapel.INTERMEC_PR3) ? 47 : ((TipoImpresora == TipoPapel.INTERMEC_PR2) ? 28 : 38)))), TipoAlineacion.DERECHA, true);
                        cadenaPDF = completaHasta(texto, texto.length() + (39 - texto.length()),TipoAlineacion.DERECHA, false);
                        texto = String.valueOf(totalSeccion);
                        cadena += completaHasta(texto, (((TipoImpresora == TipoPapel.EXTECH_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA3) ? 10 : ((TipoImpresora == TipoPapel.INTERMEC_PR3) ? 47 : ((TipoImpresora == TipoPapel.INTERMEC_PR2) ? 28 : 38)))), TipoAlineacion.DERECHA, true);
                        cadenaPDF += completaHasta(texto, texto.length() + 6,TipoAlineacion.DERECHA, true);

                        cadenaRecibo.append(cadena + "\r\n");
                        pFolio = new Paragraph(cadenaPDF, textoNegrita);
                        reportePDF.add(pFolio);

                        totalSeccion = 0;

                    }

                    reportePDF.add(new Paragraph(" "));
                    texto = isdEnvacesCopia.getString("TipoTransaccion");
                    cadena = completaHasta(texto, 20, TipoAlineacion.IZQUIERDA, false);
                    cadenaPDF = completaHasta(texto, 20,TipoAlineacion.IZQUIERDA,false);

                    cadenaRecibo.append(cadena + "\r\n");
                    pFolio = new Paragraph(cadenaPDF, textoNegrita);
                    reportePDF.add(pFolio);


                }


                texto = isdEnvacesCopia.getString("ProductoClave") + " " + isdEnvacesCopia.getString("Nombre");
                cadena = completaHasta(texto, (((TipoImpresora == TipoPapel.EXTECH_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA3) ? 25 : ((TipoImpresora == TipoPapel.INTERMEC_PR3) ? 47 : ((TipoImpresora == TipoPapel.INTERMEC_PR2) ? 28 : 38)))), TipoAlineacion.IZQUIERDA, true);
                cadenaPDF = completaHasta(texto, texto.length() + (49 - texto.length()),TipoAlineacion.IZQUIERDA, false);
                texto = isdEnvacesCopia.getString("Total");
                cadena += completaHasta(texto, (((TipoImpresora == TipoPapel.EXTECH_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA3) ? 20 : ((TipoImpresora == TipoPapel.INTERMEC_PR3) ? 47 : ((TipoImpresora == TipoPapel.INTERMEC_PR2) ? 28 : 38)))), TipoAlineacion.DERECHA, true);
                cadenaPDF += completaHasta(texto, texto.length(),TipoAlineacion.DERECHA, true);

                cadenaRecibo.append(cadena +"\r\n");
                pProducto = new Paragraph(cadenaPDF, textoNegrita);
                reportePDF.add(pProducto);

                folio += isdEnvacesCopia.getString("Folio") + ", ";
                sumaTotal += isdEnvacesCopia.getInt("Total");
                totalSeccion += isdEnvacesCopia.getInt("Total");
                primeraVuelta = false;


            }

            texto = Mensajes.get("XTotal");
            cadena = completaHasta(texto, (((TipoImpresora == TipoPapel.EXTECH_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA3) ? 35 : ((TipoImpresora == TipoPapel.INTERMEC_PR3) ? 47 : ((TipoImpresora == TipoPapel.INTERMEC_PR2) ? 28 : 38)))), TipoAlineacion.DERECHA, true);
            cadenaPDF = completaHasta(texto, texto.length() + (39 - texto.length()),TipoAlineacion.DERECHA, false);
            texto = String.valueOf(totalSeccion);
            cadena += completaHasta(texto, (((TipoImpresora == TipoPapel.EXTECH_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA3) ? 10 : ((TipoImpresora == TipoPapel.INTERMEC_PR3) ? 47 : ((TipoImpresora == TipoPapel.INTERMEC_PR2) ? 28 : 38)))), TipoAlineacion.DERECHA, true);
            cadenaPDF += completaHasta(texto, texto.length() + 6,TipoAlineacion.DERECHA, true);

            cadenaRecibo.append(cadena + "\r\n");
            pFolio = new Paragraph(cadenaPDF, textoNegrita);
            reportePDF.add(pFolio);

            //totalSeccion = 0;
            cadenaRecibo.append("\r\n");
            reportePDF.add(new Paragraph(""));

            texto = Mensajes.get("XTotal");
            cadena = completaHasta(texto, (((TipoImpresora == TipoPapel.EXTECH_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA3) ? 35 : ((TipoImpresora == TipoPapel.INTERMEC_PR3) ? 47 : ((TipoImpresora == TipoPapel.INTERMEC_PR2) ? 28 : 38)))), TipoAlineacion.DERECHA, true);
            cadenaPDF = completaHasta(texto, texto.length() + (39 - texto.length()),TipoAlineacion.DERECHA, false);
            texto = String.valueOf(sumaTotal);
            cadena += completaHasta(texto, (((TipoImpresora == TipoPapel.EXTECH_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA3) ? 10 : ((TipoImpresora == TipoPapel.INTERMEC_PR3) ? 47 : ((TipoImpresora == TipoPapel.INTERMEC_PR2) ? 28 : 38)))), TipoAlineacion.DERECHA, true);
            cadenaPDF += completaHasta(texto, texto.length() + 6,TipoAlineacion.DERECHA, true);

            cadenaRecibo.append(cadena +"\r\n");
            cadenaRecibo.append("\r\n");
            cadenaRecibo.append("\r\n");
            cadenaRecibo.append("\r\n");
            cadenaRecibo.append("\r\n");
            pProducto = new Paragraph(cadenaPDF, textoNegrita);
            reportePDF.add(pProducto);

        }
        else
        {
            int totalDescargas = 0;
            int totalDevoluciones = 0;
            // General
            //Titulos
            StringBuilder sbLinea = new StringBuilder();
            imprimeLineaPunteada(sbLinea, tamanioLetra.mLongTotal);
            cadenaRecibo.append(sbLinea);

            texto = Mensajes.get("XProducto");
            cadena = completaHasta(texto.toUpperCase(), (((TipoImpresora == TipoPapel.EXTECH_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA3) ? 35 : ((TipoImpresora == TipoPapel.INTERMEC_PR3) ? 27 : ((TipoImpresora == TipoPapel.INTERMEC_PR2) ? 11 : 18)))), TipoAlineacion.IZQUIERDA, false);
            texto = Mensajes.get("XCantidad");
            cadena += completaHasta(texto, (((TipoImpresora == TipoPapel.EXTECH_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA3) ? 10 : ((TipoImpresora == TipoPapel.INTERMEC_PR3) ? 10 : ((TipoImpresora == TipoPapel.INTERMEC_PR2) ? 10 : 10)))), TipoAlineacion.DERECHA, true);

            cadenaRecibo.append(cadena + "\r\n");
            sbLinea = new StringBuilder();
            imprimeLineaPunteada(sbLinea, tamanioLetra.mLongTotal);
            cadenaRecibo.append(sbLinea);

            texto = Mensajes.get("XProducto");
            cadena = completaHasta(texto.toUpperCase(), texto.length() + (43 - texto.length()), TipoAlineacion.IZQUIERDA, false);
            texto = Mensajes.get("XCantidad");
            cadena += completaHasta(texto, texto.length(), TipoAlineacion.DERECHA, true);

            Paragraph tituloDetalle1 = new Paragraph(cadena, tituloSubrayado);
            reportePDF.add(tituloDetalle1);


            // Productos Unidades y Cantidades


            float sumaTotal = 0;
            String folio="";
            String productoClave = "";
            String cadenaPDF = ""; // esta variable sera para PDF

            while (isdProductos.moveToNext())
            {

                if (!folio.contains(isdProductos.getString("Folio")) )
                {
                    cadenaRecibo.append("\r\n");
                    reportePDF.add(new Paragraph(" "));
                    texto = isdProductos.getString("TipoTransaccion") +" "+ isdProductos.getString("Folio");
                    cadena = completaHasta(texto, (((TipoImpresora == TipoPapel.EXTECH_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA3) ? 38 : ((TipoImpresora == TipoPapel.INTERMEC_PR3) ? 47 : ((TipoImpresora == TipoPapel.INTERMEC_PR2) ? 28 : 38)))), TipoAlineacion.IZQUIERDA, false);
                    cadenaPDF = completaHasta(texto, texto.length(),TipoAlineacion.DERECHA,true);

                    cadenaRecibo.append(cadena + "\r\n");
                    Paragraph pFolio = new Paragraph(cadenaPDF, textoNegrita);
                    reportePDF.add(pFolio);

                }

                if(!productoClave.contains(isdProductos.getString("ProductoClave"))) {
                    texto = isdProductos.getString("ProductoClave") + " " + isdProductos.getString("Nombre");
                } else {
                    texto = " ";
                }
                cadena = completaHasta(texto, (((TipoImpresora == TipoPapel.EXTECH_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA3) ? 35 : ((TipoImpresora == TipoPapel.INTERMEC_PR3) ? 47 : ((TipoImpresora == TipoPapel.INTERMEC_PR2) ? 28 : 38)))), TipoAlineacion.IZQUIERDA, true);
                cadenaPDF = completaHasta(texto, texto.length() + (45 - texto.length()),TipoAlineacion.IZQUIERDA, false);
                texto = isdProductos.getString("Cantidad");
                cadena += completaHasta(texto, (((TipoImpresora == TipoPapel.EXTECH_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA3) ? 10 : ((TipoImpresora == TipoPapel.INTERMEC_PR3) ? 47 : ((TipoImpresora == TipoPapel.INTERMEC_PR2) ? 28 : 38)))), TipoAlineacion.DERECHA, true);
                cadenaPDF += completaHasta(texto, texto.length(),TipoAlineacion.DERECHA, true);

                cadenaRecibo.append(cadena +"\r\n");
                Paragraph pProducto = new Paragraph(cadenaPDF, textoNegrita);
                reportePDF.add(pProducto);

                folio += isdProductos.getString("Folio") + ", ";

                if(isdProductos.getString("TipoTransaccion").equals("Descarga"))
                {
                    totalDescargas += isdProductos.getInt("Total");
                }
                else
                {
                    totalDevoluciones += isdProductos.getInt("Total");
                }


            }

            cadenaRecibo.append("\r\n");
            reportePDF.add(new Paragraph(" "));

            //Envase
            sbLinea = new StringBuilder();
            imprimeLineaPunteada(sbLinea, tamanioLetra.mLongTotal);
            cadenaRecibo.append(sbLinea);

            texto = Mensajes.get("XEnvase");
            cadena = completaHasta(texto.toUpperCase(), (((TipoImpresora == TipoPapel.EXTECH_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA3) ? 35 : ((TipoImpresora == TipoPapel.INTERMEC_PR3) ? 27 : ((TipoImpresora == TipoPapel.INTERMEC_PR2) ? 11 : 18)))), TipoAlineacion.IZQUIERDA, false);
            texto = Mensajes.get("XCantidad");
            cadena += completaHasta(texto, (((TipoImpresora == TipoPapel.EXTECH_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA3) ? 10 : ((TipoImpresora == TipoPapel.INTERMEC_PR3) ? 10 : ((TipoImpresora == TipoPapel.INTERMEC_PR2) ? 10 : 10)))), TipoAlineacion.DERECHA, true);

            cadenaRecibo.append(cadena + "\r\n");
            sbLinea = new StringBuilder();
            imprimeLineaPunteada(sbLinea, tamanioLetra.mLongTotal);
            cadenaRecibo.append(sbLinea );

            texto = Mensajes.get("XEnvase");
            cadena = completaHasta(texto.toUpperCase(), texto.length() + (43 - texto.length()), TipoAlineacion.IZQUIERDA, false);
            texto = Mensajes.get("XCantidad");
            cadena += completaHasta(texto, texto.length(), TipoAlineacion.DERECHA, true);

            tituloDetalle1 = new Paragraph(cadena, tituloSubrayado);
            reportePDF.add(tituloDetalle1);


            // Productos Unidades y Cantidades


            sumaTotal = 0;
            folio="";
            cadenaPDF = ""; // esta variable sera para PDF

            while (isdEnvaces.moveToNext()) {

                if (!folio.contains(isdEnvaces.getString("Folio")) )
                {
                    cadenaRecibo.append("\r\n");
                    reportePDF.add(new Paragraph(" "));
                    texto = isdEnvaces.getString("TipoTransaccion") +" "+ isdEnvaces.getString("Folio");
                    cadena = completaHasta(texto, (((TipoImpresora == TipoPapel.EXTECH_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA3) ? 38 : ((TipoImpresora == TipoPapel.INTERMEC_PR3) ? 47 : ((TipoImpresora == TipoPapel.INTERMEC_PR2) ? 28 : 38)))), TipoAlineacion.IZQUIERDA, false);
                    cadenaPDF = completaHasta(texto, texto.length(),TipoAlineacion.DERECHA,true);

                    cadenaRecibo.append(cadena + "\r\n");
                    Paragraph pFolio = new Paragraph(cadenaPDF, textoNegrita);
                    reportePDF.add(pFolio);

                }

                if(!productoClave.contains(isdEnvaces.getString("ProductoClave"))) {
                    texto = isdEnvaces.getString("ProductoClave") + " " + isdEnvaces.getString("Nombre");
                } else {
                    texto = " ";
                }
                cadena = completaHasta(texto, (((TipoImpresora == TipoPapel.EXTECH_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA3) ? 35 : ((TipoImpresora == TipoPapel.INTERMEC_PR3) ? 47 : ((TipoImpresora == TipoPapel.INTERMEC_PR2) ? 28 : 38)))), TipoAlineacion.IZQUIERDA, true);
                cadenaPDF = completaHasta(texto, texto.length() + (45 - texto.length()),TipoAlineacion.IZQUIERDA, false);
                texto = isdEnvaces.getString("Cantidad");
                cadena += completaHasta(texto, (((TipoImpresora == TipoPapel.EXTECH_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA3) ? 10 : ((TipoImpresora == TipoPapel.INTERMEC_PR3) ? 47 : ((TipoImpresora == TipoPapel.INTERMEC_PR2) ? 28 : 38)))), TipoAlineacion.DERECHA, true);
                cadenaPDF += completaHasta(texto, texto.length(),TipoAlineacion.DERECHA, true);

                cadenaRecibo.append(cadena +"\r\n");
                Paragraph pProducto = new Paragraph(cadenaPDF, textoNegrita);
                reportePDF.add(pProducto);

                folio += isdEnvaces.getString("Folio") + ", ";

                if(isdEnvaces.getString("TipoTransaccion").equals("Descarga"))
                {
                    totalDescargas += isdEnvaces.getInt("Total");
                }
                else
                {
                    totalDevoluciones += isdEnvaces.getInt("Total");
                }
            }

            cadenaRecibo.append("\r\n");
            reportePDF.add(new Paragraph(" "));

            // RESUMEN
            // Producto y Envace

            sbLinea = new StringBuilder();
            imprimeLineaPunteada(sbLinea, tamanioLetra.mLongTotal);
            cadenaRecibo.append(sbLinea);
            texto = Mensajes.get("XRESUMEN");
            cadena = alineaTexto(BTIPALI.TipoAlineacion.CENTRO, texto, tamanioLetra.mLongTotal);
            cadenaRecibo.append(cadena + "\r\n");
            sbLinea = new StringBuilder();
            imprimeLineaPunteada(sbLinea, tamanioLetra.mLongTotal);
            cadenaRecibo.append(sbLinea + "\r\n");

            Paragraph pResumen = new Paragraph(texto, tituloSubrayado);
            pResumen.setAlignment(Element.ALIGN_CENTER);
            reportePDF.add(pResumen);

            reportePDF.add(new Paragraph(" "));
            Paragraph pProducto = new Paragraph(texto, textoNegrita);
            reportePDF.add(new Paragraph(" "));

            folio = "";
            int total = 0;

            while (isdResumenGeneral.moveToNext()) {

                texto = isdResumenGeneral.getString("ProductoClave") + " " + isdResumenGeneral.getString("Nombre");
                cadena = completaHasta(texto, (((TipoImpresora == TipoPapel.EXTECH_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA3) ? 35 : ((TipoImpresora == TipoPapel.INTERMEC_PR3) ? 47 : ((TipoImpresora == TipoPapel.INTERMEC_PR2) ? 28 : 38)))), TipoAlineacion.IZQUIERDA, true);
                cadenaPDF = completaHasta(texto, texto.length() + (49 - texto.length()),TipoAlineacion.IZQUIERDA, false);
                texto = isdResumenGeneral.getString("Total");
                cadena += completaHasta(texto, (((TipoImpresora == TipoPapel.EXTECH_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA3) ? 10 : ((TipoImpresora == TipoPapel.INTERMEC_PR3) ? 47 : ((TipoImpresora == TipoPapel.INTERMEC_PR2) ? 28 : 38)))), TipoAlineacion.DERECHA, true);
                cadenaPDF += completaHasta(texto, texto.length(),TipoAlineacion.DERECHA, true);

                cadenaRecibo.append(cadena +"\r\n");
                pProducto = new Paragraph(cadenaPDF, textoNegrita);
                reportePDF.add(pProducto);

                sumaTotal += isdResumenGeneral.getInt("Total");

            }

            cadenaRecibo.append("\r\n");
            reportePDF.add(new Paragraph(" "));

            texto = Mensajes.get("XTotal");
            cadena = completaHasta(texto, (((TipoImpresora == TipoPapel.EXTECH_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA3) ? 35 : ((TipoImpresora == TipoPapel.INTERMEC_PR3) ? 47 : ((TipoImpresora == TipoPapel.INTERMEC_PR2) ? 28 : 38)))), TipoAlineacion.DERECHA, true);
            cadenaPDF = completaHasta(texto, texto.length() + (42 - texto.length()),TipoAlineacion.DERECHA, false);
            texto = String.valueOf(sumaTotal);
            cadena += completaHasta(texto, (((TipoImpresora == TipoPapel.EXTECH_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA3) ? 10 : ((TipoImpresora == TipoPapel.INTERMEC_PR3) ? 47 : ((TipoImpresora == TipoPapel.INTERMEC_PR2) ? 28 : 38)))), TipoAlineacion.DERECHA, true);
            cadenaPDF += completaHasta(texto, texto.length() + 3,TipoAlineacion.DERECHA, true);

            cadenaRecibo.append(cadena +"\r\n");
            pProducto = new Paragraph(cadenaPDF, textoNegrita);
            reportePDF.add(pProducto);

            cadenaRecibo.append("\r\n");
            reportePDF.add(new Paragraph(" "));

            texto = Mensajes.get("XDescarga");
            cadena = completaHasta(texto, (((TipoImpresora == TipoPapel.EXTECH_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA3) ? 35 : ((TipoImpresora == TipoPapel.INTERMEC_PR3) ? 47 : ((TipoImpresora == TipoPapel.INTERMEC_PR2) ? 28 : 38)))), TipoAlineacion.IZQUIERDA, true);
            cadenaPDF = completaHasta(texto, texto.length() + (45 - texto.length()),TipoAlineacion.IZQUIERDA, false);
            texto = String.valueOf(totalDescargas);
            cadena += completaHasta(texto, (((TipoImpresora == TipoPapel.EXTECH_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA3) ? 10 : ((TipoImpresora == TipoPapel.INTERMEC_PR3) ? 47 : ((TipoImpresora == TipoPapel.INTERMEC_PR2) ? 28 : 38)))), TipoAlineacion.DERECHA, true);
            cadenaPDF += completaHasta(texto, texto.length(),TipoAlineacion.IZQUIERDA, true);

            cadenaRecibo.append(cadena +"\r\n");
            Paragraph pDesacarga = new Paragraph(cadenaPDF, textoNegrita);
            reportePDF.add(pDesacarga);

            texto = Mensajes.get("XDevolucion");
            cadena = completaHasta(texto, (((TipoImpresora == TipoPapel.EXTECH_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA3) ? 35 : ((TipoImpresora == TipoPapel.INTERMEC_PR3) ? 47 : ((TipoImpresora == TipoPapel.INTERMEC_PR2) ? 28 : 38)))), TipoAlineacion.IZQUIERDA, true);
            cadenaPDF = completaHasta(texto, texto.length() + (45 - texto.length()),TipoAlineacion.IZQUIERDA, false);
            texto = String.valueOf(totalDevoluciones);
            cadena += completaHasta(texto, (((TipoImpresora == TipoPapel.EXTECH_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA2 || TipoImpresora == TipoPapel.ZEBRA_TERMICA3) ? 10 : ((TipoImpresora == TipoPapel.INTERMEC_PR3) ? 47 : ((TipoImpresora == TipoPapel.INTERMEC_PR2) ? 28 : 38)))), TipoAlineacion.DERECHA, true);
            cadenaPDF += completaHasta(texto, texto.length(),TipoAlineacion.IZQUIERDA, true);

            cadenaRecibo.append(cadena +"\r\n");
            Paragraph pDevolucion = new Paragraph(cadenaPDF, textoNegrita);
            reportePDF.add(pDevolucion);

        }

        isdProductos.close();
        isdEnvaces.close();
        isdProductosCopia.close();
        isdEnvacesCopia.close();
        isdResumenGeneral.close();
        document.add(reportePDF);

    }
    //endregion

    public static String convertCIDs(String text) {
        char cid[] = text.toCharArray();
        for (int k = 0; k < cid.length; ++k) {
            char c = cid[k];
            if (c == '\n')
                cid[k] = '\uff00';
            else
                cid[k] = (char) (c - ' ' + 8720);
        }
        return new String(cid);
    }

    public static File generaTicketPedido(String transpodId, String folio, Vista vista) throws Exception {
        ConfiguracionLocal conf = (ConfiguracionLocal) Sesion.get(Campo.ConfiguracionLocal);
        File folder = new File(conf.get(CampoConfiguracion.DIRECTORIO_TRABAJO).toString());
        folder = new File(folder, "PDF");
        if (!folder.exists())
		{
            if (!folder.mkdirs()) {
                //TODO Paula, crear mensaje, E0690 provisional
                throw new Exception(folder.getAbsolutePath());
            }
		}

        //Limpiar el directorio de impresion
        if (folder.isDirectory()) {
            File[] files = folder.listFiles();
            if (files != null) {
                for (File f : files) {
                    f.delete();
                }
			}
		}

        Document document = new Document();
        try {
            PdfWriter pdfWriter = PdfWriter.getInstance(document, new FileOutputStream(folder.getAbsolutePath().concat(File.separator).concat("Ticket_").concat(folio).concat(".pdf")));
            document.open();
            generaTicketPDF(document, transpodId);
            document.close();
        } catch (FileNotFoundException fnfe) {

        } catch (Exception de) {

        }
        return new File(folder.getAbsolutePath().concat(File.separator).concat("Ticket_").concat(folio).concat(".pdf"));
    }

    private static void generaTicketPDF(Document document, String transprodId) throws Exception {
        Paragraph line = new Paragraph(" ");
        final String decimalFormat = "#,##0.00";
        Font generalFont = new Font(Font.FontFamily.HELVETICA, 18f, Font.BOLD, BaseColor.RED);
        Font enterpriseFont = new Font(Font.FontFamily.HELVETICA, 15f, Font.BOLD, BaseColor.BLACK);
        String aux, folio, direccion, fechaCaptura, fechaCobranza, razonSocial, empresa;
        folio = "";
        direccion = "";
        fechaCaptura = "";
        fechaCobranza = "";
        razonSocial = "";
        empresa = "";
        float total, subtotal;
        ISetDatos headers = Consultas2.ConsultasTransProd.obtenerEncabezadoTicketPDF(transprodId);
        if (headers != null && headers.moveToNext()) {
            empresa = headers.getString("NombreEmpresa");
            Paragraph pEmpresa = new Paragraph(empresa, generalFont);
            pEmpresa.setAlignment(Element.ALIGN_CENTER);
            document.add(pEmpresa);
            document.add(line);
            aux = headers.getString("CalleEmp") != null ? headers.getString("CalleEmp") : "";
            aux += headers.getString("NumeroEmp") != null ? " ".concat(headers.getString("NumeroEmp")) : "";
            aux += headers.getString("NumIntEmp") != null ? " ".concat(headers.getString("NumIntEmp")) : "";
            aux += headers.getString("ColoniaEmp") != null ? ", ".concat(headers.getString("ColoniaEmp")) : "";
            pEmpresa = new Paragraph(aux, enterpriseFont);
            pEmpresa.setAlignment(Element.ALIGN_CENTER);
            document.add(pEmpresa);
            aux = Mensajes.get("XCPostal");
            aux += headers.getString("CPEmp") != null ? headers.getString("CPEmp") : "";
            aux += headers.getString("LocalidadEmp") != null ? " ".concat(headers.getString("LocalidadEmp")) : "";
            aux += headers.getString("Region") != null ? ", ".concat(headers.getString("Region")) : "";
            pEmpresa = new Paragraph(aux, enterpriseFont);
            pEmpresa.setAlignment(Element.ALIGN_CENTER);
            document.add(pEmpresa);

            aux = Mensajes.get("XTelefono");
            aux += ": ".concat(headers.getString("Telefono") != null ? headers.getString("Telefono") : "");
            pEmpresa = new Paragraph(aux, enterpriseFont);
            pEmpresa.setAlignment(Element.ALIGN_CENTER);
            document.add(pEmpresa);
            document.add(line);

            enterpriseFont.setStyle(Font.NORMAL);
            enterpriseFont.setSize(12.2f);
            enterpriseFont.setColor(BaseColor.BLACK);

            PdfPTable table = new PdfPTable(new float[]{65, 35});
            table.setWidthPercentage(97);
            table.getDefaultCell().setBorder(Rectangle.NO_BORDER);
            table.getDefaultCell().setVerticalAlignment(Element.ALIGN_CENTER);

            razonSocial = headers.getString("RazonSocial");
            table.addCell(createCell(razonSocial, PdfPCell.ALIGN_LEFT, enterpriseFont));
            folio = headers.getString("Folio");
            table.addCell(createCell(folio, PdfPCell.ALIGN_RIGHT, enterpriseFont));

            aux = headers.getString("CalleCliente") != null ? headers.getString("CalleCliente") : "";
            aux += headers.getString("NumeroCliente") != null ? " ".concat(headers.getString("NumeroCliente")) : "";
            aux += headers.getString("NumIntCliente") != null ? " ".concat(headers.getString("NumIntCliente")) : "";
            aux += headers.getString("ColoniaCliente") != null ? ", ".concat(headers.getString("ColoniaCliente")) : "";
            direccion = aux;
            table.addCell(createCell(direccion, PdfPCell.ALIGN_LEFT, enterpriseFont));

            aux = Mensajes.get("XEmision");
            fechaCaptura = headers.getDate("FechaCaptura") != null ? Generales.getFormatoFecha(headers.getDate("FechaCaptura"), "dd/MM/yyyy") : "";
            aux += ": ".concat(fechaCaptura);
            table.addCell(createCell(aux, PdfPCell.ALIGN_RIGHT, enterpriseFont));

            aux = Mensajes.get("XCPostal");
            aux += headers.getString("CPCliente") != null ? " ".concat(headers.getString("CPCliente")) : "";
            aux += headers.getString("LocalidadCliente") != null ? " ".concat(headers.getString("LocalidadCliente")) : "";
            aux += headers.getString("EntidadCliente") != null ? ", ".concat(headers.getString("EntidadCliente")) : "";

            table.addCell(createCell(aux, PdfPCell.ALIGN_LEFT, enterpriseFont));

            aux = Mensajes.get("XVencimiento");
            fechaCobranza = headers.getDate("FechaCobranza") != null ? Generales.getFormatoFecha(headers.getDate("FechaCobranza"), "dd/MM/yyyy") : "";
            aux += ": ".concat(fechaCobranza);
            table.addCell(createCell(aux, PdfPCell.ALIGN_RIGHT, enterpriseFont));

            aux = Mensajes.get("XTelefono");
            aux += " ".concat(headers.getString("TelefonoContacto") != null ? headers.getString("TelefonoContacto") : "");
            table.addCell(createCell(aux, PdfPCell.ALIGN_LEFT, enterpriseFont));

            aux = Mensajes.get("XVendedor");
            aux += ": ".concat(headers.getString("Nombre") != null ? headers.getString("Nombre") : "");
            table.addCell(createCell(aux, PdfPCell.ALIGN_RIGHT, enterpriseFont));
            document.add(table);
            document.add(line);
            document.add(line);

            subtotal = headers.getFloat("Subtotal");
            total = headers.getFloat("Total");
        } else {
            throw new Exception("No se pudo obtener el encabezado del ticket");
        }
        headers.close();

        /* Imprimir todos los productos */
        PdfPTable table = new PdfPTable(new float[]{18, 18, 48, 20, 20, 20});
        table.setWidthPercentage(97);
        table.getDefaultCell().setBorder(Rectangle.NO_BORDER);
        table.getDefaultCell().setVerticalAlignment(Element.ALIGN_CENTER);
        /* Header */
        generalFont.setStyle(Font.BOLD);
        generalFont.setSize(11f);
        generalFont.setColor(BaseColor.DARK_GRAY);

        createHeader(table, Mensajes.get("XCantidad"), PdfPHeaderCell.ALIGN_LEFT, generalFont);
        createHeader(table, Mensajes.get("XEmpaque"), PdfPHeaderCell.ALIGN_RIGHT, generalFont);
        createHeader(table, Mensajes.get("XNombre"), PdfPHeaderCell.ALIGN_RIGHT, generalFont);
        createHeader(table, Mensajes.get("XPrecio"), PdfPHeaderCell.ALIGN_RIGHT, generalFont);
        createHeader(table, Mensajes.get("XDescuento"), PdfPHeaderCell.ALIGN_RIGHT, generalFont);
        createHeader(table, Mensajes.get("XTotal"), PdfPHeaderCell.ALIGN_RIGHT, generalFont);

        generalFont.setSize(10f);
        generalFont.setStyle(Font.NORMAL);
        generalFont.setColor(BaseColor.BLACK);

        ISetDatos detalles = Consultas2.ConsultasProductoDetalle.obtenerDetallesTicketPedidoPDF(transprodId);
        if (detalles != null) {
            while (detalles.moveToNext()) {
                table.addCell(createCell(String.valueOf(detalles.getInt("Cantidad")), PdfPCell.ALIGN_RIGHT, generalFont));
                table.addCell(createCell(ValoresReferencia.getDescripcion("UNIDADV", detalles.getString("TipoUnidad")), PdfPCell.ALIGN_LEFT, generalFont));
                table.addCell(createCell(detalles.getString("NombreLargo"), PdfPCell.ALIGN_LEFT, generalFont));
                table.addCell(createCell(Generales.getFormatoDecimal(detalles.getFloat("Total") / detalles.getInt("Cantidad"), decimalFormat), PdfPCell.ALIGN_RIGHT, generalFont));
                table.addCell(createCell(Generales.getFormatoDecimal(detalles.getFloat("Total") - detalles.getFloat("Subtotal"), decimalFormat), PdfPCell.ALIGN_RIGHT, generalFont));
                table.addCell(createCell(Generales.getFormatoDecimal(detalles.getFloat("Total"), decimalFormat), PdfPCell.ALIGN_RIGHT, generalFont));
            }
            detalles.close();
        }
        document.add(table);
        generalFont.setSize(18f);
        generalFont.setStyle(Font.BOLD);
        /* Totals */
        document.add(line);
        document.add(line);

        aux = Mensajes.get("XSubtotal").concat(": ");
        aux += Generales.getFormatoDecimal(subtotal, decimalFormat);
        Paragraph pTotales = new Paragraph(aux);
        pTotales.setAlignment(Element.ALIGN_RIGHT);
        document.add(pTotales);
        aux = Mensajes.get("XTotal").concat(": ");
        aux += Generales.getFormatoDecimal(total, decimalFormat);
        pTotales = new Paragraph(aux);
        pTotales.setAlignment(Element.ALIGN_RIGHT);
        document.add(pTotales);
        aux = "(" + NumeroALetra.Convertir(Generales.getFormatoDecimal(total, 2), true) + ")";
        pTotales = new Paragraph(aux);
        pTotales.setAlignment(Element.ALIGN_LEFT);
        document.add(pTotales);
        document.add(line);

        generalFont.setSize(Font.NORMAL);
        generalFont.setSize(8f);

        String leyenda = "PAGARÉ CORRESPONDIENTE A  LA NOTA DE VENTA NO. " + folio + " Debo (emos) y pagare " +
                "(mos) en la ciudad de Celaya, Gto. A la orden " + empresa + " el día " + fechaCaptura + " la " +
                "cantidad de " + Generales.getFormatoDecimal(total, 2) + " " + NumeroALetra.Convertir(Generales.getFormatoDecimal(total, 2), true) + " Correspondiente al importe de mercancías y/o servicios " +
                "que he recibido de conformidad, siendo este pagaré mercantil en los términos de los " +
                "artículos 170, 173 y 174 en su parte final de la ley de títulos y operaciones de " +
                "crédito y de conformidad con el articulo 11 y demás relativos. Además de la ley ya " +
                "citada me obligo incondicionalmente  el importe de este pagaré (aun cuando sea su " +
                "nombre y representación por empleado o dependencia de mi negocio). En caso de mora el " +
                "pago requeriré (mos) con intereses  a la tasa del 15% mensual a partir de su vencimiento " +
                "el día " + fechaCobranza;

        pTotales = new Paragraph(leyenda, generalFont);
        pTotales.setAlignment(Element.ALIGN_JUSTIFIED);
        document.add(pTotales);

        pTotales = new Paragraph("NOTA: CADA CHEQUE DEVUELTO OCASIONARA UN 7% + IVA AL VALOR", generalFont);
        pTotales.setAlignment(Element.ALIGN_LEFT);
        document.add(pTotales);

        pTotales = new Paragraph("Nombre: ".concat(razonSocial), generalFont);
        pTotales.setAlignment(Element.ALIGN_LEFT);
        document.add(pTotales);

        pTotales = new Paragraph("Dirección: ".concat(direccion), generalFont);
        pTotales.setAlignment(Element.ALIGN_LEFT);
        document.add(pTotales);

        pTotales = new Paragraph("Acepto (mos) _____________________________________", generalFont);
        pTotales.setAlignment(Element.ALIGN_LEFT);
        document.add(pTotales);
    }

    private static void createHeader(PdfPTable table, String text, int alignment, Font generalFont) {
        PdfPHeaderCell header = new PdfPHeaderCell();
        header.addElement(new Paragraph(text, generalFont));
        header.setHorizontalAlignment(alignment);
        table.addCell(header);
    }

	//************************************************* reportes *************************************************************************

    private static PdfPCell createCell(String text, int alignment, Font generalFont) {
        PdfPCell cell = new PdfPCell();
        cell.setBorder(Rectangle.NO_BORDER);
        cell.setHorizontalAlignment(alignment);
        cell.addElement(new Paragraph(text, generalFont));
        return cell;
    }

    public void imprimirRecibos(List<Map<String, String>> listaTickets, Boolean logoSoloPrimerRecibo, IVista vista, short numCopias) throws ControlError, Exception {

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
        if (vista.getClass().equals(ImpresionTicket.class)) {
            reimpresion = true;
        }

        String[] byRefMsgError =
                {""};
        short numeroCopias = numCopias;
        for (int i = 0; i < listaTickets.size(); i++) {
            //TODO Paula, checar si tengo que enviar mensaje por cada recibo o si falla cualquier recibo parar.
            try {
                CONHist oConHist = (CONHist) Sesion.get(Campo.CONHist);
                int ticketConfigurado = Integer.parseInt(oConHist.get("TicketConfigurado").toString());
                if (ticketConfigurado == 15 && (Short.parseShort(listaTickets.get(i).get("Tipo")) == 1 || (Short.parseShort(listaTickets.get(i).get("Tipo")) == 21 && oMotConf.get("MSIEVPreventa").equals("1")))) {
                    //ticket pedido costeña, se revisa con Tipo, porque TipoRecibo  cambia dependiendo del modulo.
                    //Se imprime ticket de pedido para MSIEV cuando el parametro MSIEVPreventa esta activo CAI 3268
                    reciboAct = new Recibo();
                    reciboAct.Tipo = Short.parseShort(listaTickets.get(i).get("TipoRecibo"));
                    reciboAct.TipoPapel = ((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp;
                    /*if (Short.parseShort(listaTickets.get(i).get("Tipo")) == 21 || (Short.parseShort(listaTickets.get(i).get("Tipo")) == 1 && Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.PREVENTA)) {
                        //imprimir 2 copias en el caso de preventa y MSIEV
                        numeroCopias = 2;
                    } else {
                        //imprimir 2 copias en caso de modulo distinto a preventa
                        numeroCopias = 1;
                    }*/

                    nombreArchivo = generarArchivoRecibo(listaTickets.get(i), impresion.getAbsolutePath(), reciboAct, imprimeLogo, ticketConfigurado, byRefMsgError, reimpresion);
                } else if (listaTickets.get(i).get("TipoRecibo").equals(TRECIBO.DEPOSITOS_MANUALES)) { //ticket depositos manuales
                    if (vista instanceof ICapturaDeposito) {
                        reciboAct = new Recibo();
                        reciboAct.Tipo = Short.parseShort(listaTickets.get(i).get("TipoRecibo"));
                        reciboAct.TipoPapel = ((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp;
                        ICapturaDeposito vis = (ICapturaDeposito) vista;
                        vis.getAplicaDevoluciones();
                        boolean aplicaDev = vis.getAplicaDevoluciones();
                        nombreArchivo = generarArchivoRecibo(listaTickets.get(i), impresion.getAbsolutePath(), reciboAct, imprimeLogo, aplicaDev, byRefMsgError);
                    }
                }  else if (listaTickets.get(i).get("TipoRecibo").equals(TRECIBO.TOMA_DE_INVENTARIO)) { //ticket toma de inventario
                        reciboAct = new Recibo();
                        reciboAct.Tipo = Short.parseShort(listaTickets.get(i).get("TipoRecibo"));
                        reciboAct.TipoPapel = ((Vendedor) Sesion.get(Campo.VendedorActual)).TipoModImp;
                        nombreArchivo = generarArchivoRecibo(listaTickets.get(i), impresion.getAbsolutePath(), reciboAct, imprimeLogo, false, byRefMsgError);
                }else { //tickets configurables
                    //Si cambia el recibo Actual vuelvo a obtener la información
                    if (reciboAct == null || reciboAct.Tipo != Short.parseShort(listaTickets.get(i).get("TipoRecibo"))) {
                        if (Short.parseShort(listaTickets.get(i).get("Tipo")) == 21 && oMotConf.get("MSIEVPreventa").equals("1")) {
                            //Se imprime ticket de preventa para MSIEV cuando el parametro MSIEVPreventa esta activo CAI 3268
                            listaTickets.get(i).remove(listaTickets.get(i).get("Tipo"));
                            listaTickets.get(i).put("Tipo", "1");
                            listaTickets.get(i).remove(listaTickets.get(i).get("TipoRecibo"));
                            listaTickets.get(i).put("TipoRecibo", "1");
                        }

                        reciboAct = ConsultasImpresionTicket.obtenerReciboPorTipoRecibo(Short.parseShort(listaTickets.get(i).get("TipoRecibo")), vendedor.TipoModImp, byRefMsgError);

                        if (reciboAct == null) {
                            if (!byRefMsgError[0].equals("")) {
                                //Errores[0] = Errores[0].concat(byRefMsgError[0]);
                                throw new Exception(byRefMsgError[0]);
                            }
                        }

                        //recibos configurables
                        configuracionReciboAct = ConsultasImpresionTicket.obtenerConfiguracionReciboPorTipoRecibo(Short.parseShort(listaTickets.get(i).get("TipoRecibo")), byRefMsgError);
                        if (configuracionReciboAct == null) {
                            if (!byRefMsgError.equals("")) {
                                //Errores[0] = Errores[0].concat(byRefMsgError[0]);
                                throw new Exception(byRefMsgError[0]);
                            }
                        }
                    }
                    nombreArchivo = generarArchivoRecibo(listaTickets.get(i), impresion.getAbsolutePath(), reciboAct, configuracionReciboAct, imprimeLogo, byRefMsgError);
                    if (logoSoloPrimerRecibo) {
                        imprimeLogo = false;
                    }
                }
            } catch (Exception ex) {
                throw new Exception(ex.getMessage());
            }
            if (!archivosGenerados.containsKey(nombreArchivo) && !nombreArchivo.equals("")) {
                ContentValues valoresRecibo = new ContentValues();
                valoresRecibo.put("TipoPapel", reciboAct.TipoPapel);
                valoresRecibo.put("MostrarLogo", reciboAct.MostrarLogo);
                archivosGenerados.put(nombreArchivo, valoresRecibo);
            }
        }
        imprimirArchivos(archivosGenerados, impresion, vista, numeroCopias);
	}

    /* Separar la impresion de los archivos generales en este nuevo metodo */
    public void imprimirArchivos(Hashtable<String, ContentValues> archivosAImprimir, File impresion, IVista vista, short numeroCopias) throws Exception {
        //vistaActual = vista;
        Enumeration<String> e = archivosAImprimir.keys();
        String archivo = "";
        final boolean impresionConVista = vista != null;
        while (e.hasMoreElements()) {
            archivo = e.nextElement();
            try {
                short tipoPapel = archivosAImprimir.get(archivo).getAsShort("TipoPapel");
				/* En esta condicion se agregarian los diferenctes tipos de papel, de impresoras integradas */
                if (tipoPapel == TipoPapel.SPEEDDATA_TT35) {
                    impresionIntegrada(vista, new File(impresion, archivo).getAbsolutePath(), tipoPapel, archivosAImprimir.get(archivo).getAsBoolean("MostrarLogo"), numeroCopias);
                } else {
                    BluetoothPrint(vista, new File(impresion, archivo).getAbsolutePath(), tipoPapel, archivosAImprimir.get(archivo).getAsBoolean("MostrarLogo"), (numeroCopias == 0 ? 1 : numeroCopias ));
				}

            } catch (PrintException ex)
			{
                if (ex.getCodigo() == 1) {
                    vista.vincularImpresora(ex.getMessage(), archivosAImprimir, impresion);
                } else {
                    if (impresionConVista) {
                        vista.mostrarPreguntaReintentarImpresion(ex.getMessage().concat("\n¿Deseas intentar de nuevo?"), archivosAImprimir, impresion, numeroCopias);
                    } else {
                        throw ex;
                    }
                }
			}
		}
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

    void BluetoothPrint(IVista vista, String nombreArchivo, Short nTipoPapel, boolean bMostrarLogo, short numeroCopias) throws Exception {
        vistaActual = vista;
        fileName = nombreArchivo;
        numCopias = numeroCopias;
        mostrarLogo = bMostrarLogo;
        tipoPapel = nTipoPapel;

        reintentosOcultos = 0;
        try {

            btAdapter = BluetoothAdapter.getDefaultAdapter();
            if (btAdapter == null) {
                throw new Exception("Bluetooth no soportado");
            }

            if (!btAdapter.isEnabled()) {
                throw new Exception("El Bluetooth no esta encendido");
            }
            if (btPrintService == null)
                setupComm(vista);

            ConfiguracionLocal config = (ConfiguracionLocal) Sesion.get(Campo.ConfiguracionLocal);
            String puerto = (String) config.get(CampoConfiguracion.PUERTO + "_" + tipoPapel);

            if (puerto == null) {
                throw new Exception(Mensajes.get("E0708"));
            }

            String remote = puerto;
            if (remote.length() == 0)
                return;

            String sMacAddr = puerto.split("_")[0];


            try {
                device = btAdapter.getRemoteDevice(sMacAddr);
            } catch (Exception e) {
                throw new Exception(Mensajes.get("E0708"));
            }

            if (device != null) {
                while (device.getBondState() != BluetoothDevice.BOND_BONDED) {
                    Method m = device.getClass()
                            .getMethod("createBond", (Class[]) null);
                    m.invoke(device, (Object[]) null);

                    Thread.sleep(3000);
                }

                intentosConexion[0] = true;
                btPrintService.connect(device);
            } else {
                throw new Exception("Verifique que la impresora este encendida");
            }

            //addLog(String.format("printed " + totalWrite.toString() + " bytes"));
        } catch (IOException e) {
            throw new Exception("Impresión fallida");
        } catch (Exception e) {
            throw new Exception(e.getMessage());
        } finally {
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

    void impresionIntegrada(IVista vista, String nombreArchivo, Short nTipoPapel, boolean bMostrarLogo, short numeroCopias) throws Exception {

        vistaActual = vista;
        fileName = nombreArchivo;
        numCopias = numeroCopias;
        mostrarLogo = bMostrarLogo;
        tipoPapel = nTipoPapel;

        SerialPort barcode;
        DeviceControl DevCtr2 = null;
        Print pprint = null;
        Handler handler;
        byte letra = 06;
        ByteArrayOutputStream buffer = null;
        try {
            /*****/
            barcode = new SerialPort();// ("/dev/eser0",9600);
            try {
                barcode.OpenSerial("/dev/eser0", 9600);
                DevCtr2 = new DeviceControl("/proc/driver/scan");
            } catch (IOException e) {
                // TODO Auto-generated catch block
                e.printStackTrace();
            }

            pprint = new Print(vistaActual == null ? context : (Context) vistaActual);

            pprint.powerOnPrint();

            pprint.setHRI((byte) 2); //2
            pprint.setWide((byte) 2); //2
            pprint.setHight((byte) 55);  //2

            handler = new Handler() {
                @Override
                public void handleMessage(Message msg) {
                    super.handleMessage(msg);
                    if (msg.what == 1) {
                        Log.i("SERIAL PORT", msg.toString());// (buf1);
                    }
                }
            };
            /*******/
            for (int i = 0; i < numCopias; i++) {

                FileInputStream fstream = new FileInputStream(fileName);
                // Get the object of DataInputStream
                DataInputStream in = new DataInputStream(fstream);
                BufferedReader br = new BufferedReader(new InputStreamReader(in));
                String strLine;
                buffer = new ByteArrayOutputStream();
                //byte[] buffer;
                //Read File Line By Line
                String saltoLinea = "\r\n";
                while ((strLine = br.readLine()) != null) {
                    if (strLine.equalsIgnoreCase("IMPRIME_LOGO")) {
                        if (mostrarLogo) {
                            if (tipoPapel == TipoPapel.SPEEDDATA_TT35) {
//								buffer.write(new byte[]
//								{ 27, 76, 103, 48 });

                            }
                        }
                    } else if (strLine.startsWith("{")) {
                        if (tipoPapel == TipoPapel.SPEEDDATA_TT35) {
//							buffer.write(new byte[]
//							{ 27, 107, Byte.parseByte(strLine.substring(1, strLine.indexOf("}"))) });
                            letra = Byte.parseByte(strLine.substring(1, strLine.indexOf("}")));
                            pprint.setTextSize(letra);
                        }

                        if (strLine.indexOf("}") + 1 != strLine.length()) {
                            buffer.write(strLine.substring(strLine.indexOf("}") + 1, strLine.length()).getBytes());
                            //pprint.printString(strLine.substring(strLine.indexOf("}") + 1, strLine.length()));
                        }
                    } else {
                        buffer.write(strLine.getBytes());
//						pprint.printString(strLine);
                    }
                    buffer.write(saltoLinea.getBytes());
                }
                //Close the input stream
                in.close();

                pprint.printString(new String(buffer.toByteArray()));
                //closeBarcode(DevCtr2);
                if (i < (numeroCopias - 1))
                    Thread.sleep(500);
                //pprint.closePrint();
            }
			/* Esperar por cada byte 8 milisegundos para apagar el dispositivo */
            if (buffer != null)
                Thread.sleep(buffer.size() * 14);
            //archivosAImprimir.remove(archivo);
            //if(archivosAImprimir.isEmpty())
            //{
            if (vistaActual != null) {
                vistaActual.impresionFinalizada(true, "");
                //}
            }

        } catch (Exception ex) {
            throw ex;
        } finally {
            if (pprint != null) {
                pprint.closePrint();
            }
        }
    }

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

    private void closeBarcode(DeviceControl devCtr2) {
        try {
            devCtr2.PowerOffDevice();
            devCtr2.TriggerOffDevice();
            System.out.println("close barcode");
        } catch (IOException e) {
            // TODO Auto-generated catch block
            e.printStackTrace();
        }
	}

    void connectToDevice(BluetoothDevice _device, btPrintFile btPrintService) throws Exception {
        if (_device != null) {
            btPrintService.connect(_device);
        }
		else
		{
            throw new Exception("Verifique que la impresora este encendida");
        }
	}

    private void setupComm(IVista vista) throws Exception {
        // Initialize the array adapter for the conversation thread
        //mConversationArrayAdapter = new ArrayAdapter<String>(this, R.id.remote_device);
        //Log.d(TAG, "setupComm()");
        btPrintService = new btPrintFile((Activity) vista, mHandler);
        if (btPrintService == null)
            throw new Exception("Inicializacion del puerto fallida");
    }

    private void iniciarImpresion() throws Exception {
        intentosConexion[0] = false;
        String mensajeError = "";
        if (btPrintService.getState() != btPrintFile.STATE_CONNECTED) {
            // myToast("Please connect first!", "Error");
            return; //does not match file pattern for a print file
        }

        try {
                for (int i = 0; i < numCopias; i++) {
                    FileInputStream fstream = new FileInputStream(fileName);
                    // Get the object of DataInputStream
                    DataInputStream in = new DataInputStream(fstream);
                    BufferedReader br = new BufferedReader(new InputStreamReader(in));
                    String strLine;
                    ByteArrayOutputStream buffer = new ByteArrayOutputStream();
                    //byte[] buffer;
                    //Read File Line By Line
                    String saltoLinea = "\r\n";
                    if (tipoPapel == TipoPapel.SEWOO && i == 0) {
                        String escrito = " ";
                        buffer.write(escrito.getBytes());
                        buffer.write(saltoLinea.getBytes());
                        btPrintService.write(buffer.toByteArray());
                        Thread.sleep(2000);
                        buffer.reset();
                    }

                    while ((strLine = br.readLine()) != null) {
                        if (strLine.equalsIgnoreCase("IMPRIME_LOGO")) {
                            if (mostrarLogo) {
                                if (tipoPapel == TipoPapel.EXTECH_TERMICA2 || tipoPapel == TipoPapel.EXTECH_TERMICA3) {
                                    buffer.write(new byte[]
                                            {27, 76, 103, 48});
                                } else if (tipoPapel == TipoPapel.INTERMEC_PR2 || tipoPapel == TipoPapel.INTERMEC_PR3) {
                                    buffer.write(new byte[]
                                            {27, 69, 90});

                                    String sImagen = "{PRINT:@0,170:ALOGO,HMULT1,VMULT1|}";
                                    sImagen += "{LP}";
                                    buffer.write(sImagen.getBytes());
                                } else if (tipoPapel == TipoPapel.SEWOO) {

                                    buffer.write(new byte[]{28, 112, 1, 0});
                                    buffer.write(saltoLinea.getBytes());

                                } else if (tipoPapel == TipoPapel.ZEBRA_TERMICA3) {

                                    String sImagen = "! 0 200 200 100 1\n" +
                                            "PCX 0 0 !<ALOGO.PCX\n" +
                                            "PRINT";
                                    buffer.write(sImagen.getBytes());
                                }
                            }
                        } else if (strLine.startsWith("{")) {
                            if (tipoPapel == TipoPapel.EXTECH_TERMICA2 || tipoPapel == TipoPapel.EXTECH_TERMICA3) {
                                buffer.write(new byte[]
                                        {27, 107, Byte.parseByte(strLine.substring(1, strLine.indexOf("}")))});
                            } else if (tipoPapel == TipoPapel.INTERMEC_PR2 || tipoPapel == TipoPapel.INTERMEC_PR3) {
                                //buffer.write(new byte[]{27,119,Byte.parseByte(strLine.substring(1, strLine.indexOf("}")))});
                                //buffer.write(new byte[]{27,33,16});
                                buffer.write(new byte[]
                                        {Byte.parseByte(strLine.substring(1, strLine.indexOf("}")).split(",")[0]), Byte.parseByte(strLine.substring(1, strLine.indexOf("}")).split(",")[1]), Byte.parseByte(strLine.substring(1, strLine.indexOf("}")).split(",")[2])});
                            } else if (tipoPapel == TipoPapel.SEWOO) {
                                buffer.write(new byte[]
                                        {29, 33, Byte.parseByte(strLine.substring(1, strLine.indexOf("}")))});
                            }
                            if (strLine.indexOf("}") + 1 != strLine.length()) {
                                buffer.write(strLine.substring(strLine.indexOf("}") + 1, strLine.length()).getBytes());
                            }
                        } else {
                            buffer.write(strLine.getBytes());
                        }
                        buffer.write(saltoLinea.getBytes());
                    }
                    //Close the input stream
                    in.close();

                    btPrintService.write(buffer.toByteArray());
                    Thread.sleep(2000);

                }

                if (vistaActual != null ) {
                        vistaActual.impresionFinalizada(true, "");
                }

        } catch (Exception ex) {
            if (ex != null) {
                mensajeError = ex.getMessage();
            }else{
                mensajeError = "Error de nulos durante la impresión";
            }
        } finally {

            if (btPrintService.getState() == btPrintFile.STATE_CONNECTED) {
                desconexionManual = true;
                btPrintService.stop();
                if (vistaActual != null ) {
                    vistaActual.impresionFinalizada(true, mensajeError);
                    //}
                }
                return;
            }

		}
	}

    public HashMap<String, String> getDocumentoImpresion(String _id, String tipo, String varCodigo, String tipoRecibo, String folio, String descTipo, String fecha, String total, String tipoFase, String clienteClave, String diaClave, String subEmpresaID, String facElec) {
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

    public String obtenerTipoRecibo(Map<String, String> registro) {
        String tipoRecibo = "0";

        int tipo = Integer.parseInt(registro.get("Tipo"));
        //if ((mAccion!= null)&&(mAccion.equals(Enumeradores.Acciones.ACCION_IMPRIMIR_TICKET_CON_VISITA))){
        if (registro.get("TipoRecibo").equals("TRP")) {
            if ((tipo == 3 && !registro.get("TipoFase").equals(3)) || (tipo != 3)) {
                switch (tipo) {
                    case 8:
                        if (registro.get("FacElec").equals(1)) {
                            return "24"; // Facturacion Electronica
                        } else {
                            return "8"; // Facturacion
                        }
                    case 24:
                        if (registro.get("TipoFase").equals(6)) {
                            return "26"; //Liquidacion
                        } else {
                            return "25"; //Consignación
                        }
                    case 1:
                        if (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.VENTA) {
                            return "1";
                        } else if (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.PREVENTA) {
                            return "27";
                        } else if (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO) {
                            return "28";
                        }
                    default:
                        return registro.get("Tipo");
                }
            }
        } else if (registro.get("TipoRecibo").equals("ABN")) {
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

    private static class TamanioLetra {
        public int mTamanio;
        public int mLongTotal;
        public int mAlto;

        public TamanioLetra(int tamanio, int longTotal, int alto) {
            mTamanio = tamanio;
            mLongTotal = longTotal;
            mAlto = alto;
        }
    }

    //modoEncabezadoPie
    public final class ModoEncabezadoPie {
        private static final short ENCABEZADO = 1;
        private static final short PIE = 2;
    }

    //tipoPapel
    public final class TipoPapel {
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
        public final static short SPEEDDATA_TT35 = 13;
        public final static short SEWOO = 14;
        public final static short ZEBRA_TERMICA3 = 15;
    }

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

    public final class TipoAlineacion {
        public final static short IZQUIERDA = 0;
        public final static short DERECHA = 1;
    }

    public final class BTIPALI {
        public final class TipoAlineacion {
            public final static short NO_DEFINIDO = 0;
            public final static short IZQUIERDA = 1;
            public final static short CENTRO = 2;
            public final static short DERECHA = 3;
        }
    }

    public final class TRECIBO {
        public final static String DEPOSITOS_MANUALES = "100";
        public final static String TOMA_DE_INVENTARIO = "101";
    }

    public class PrintException extends Exception {
        private static final long serialVersionUID = 1L;

        private int iCodigo = 0;

        public PrintException(String mensaje, int numCodigo) {
            super(mensaje);
            iCodigo = numCodigo;
        }

        public int getCodigo() {
            return iCodigo;
        }
    }
}
