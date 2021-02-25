package com.amesol.routelite.presentadores;

import java.io.File;
import java.util.HashMap;
import java.util.Hashtable;

import com.amesol.routelite.actividades.btPrintFile;

import android.bluetooth.BluetoothDevice;
import android.content.ContentValues;
import android.content.Intent;
import android.os.Parcelable;

public interface IVista {	
	
	void finalizar();
	void iniciar();
	void iniciarActividad(Class<?> vista);
	void iniciarActividad(Class<?> vista, String mensajeError);
	void iniciarActividad(Class<?> vista,boolean finalizar);
	void iniciarActividad(Class<?> vista, String accion, String mensajeError, boolean finalizar);
	void iniciarActividad(Class<?> vista, String accion, String mensajeError, boolean finalizar, HashMap<?, ?> parametros);
	void iniciarActividadConResultado(Class<?> vista, int codigoSolicitud, String accion);
	void iniciarActividadConResultado(Class<?> vista, int codigoSolicitud, String accion, HashMap<?, ?> parametros);
	void mostrarError(String mensaje);
	void mostrarAdvertencia(String mensaje);
	void mostrarPreguntaSiNo(String mensaje, int tipoMensaje);
	void mostrarPreguntaReintentarImpresion(String mensaje, Hashtable<String, ContentValues> archivosAImprimir, File impresion, int numeroCopias);
	void mostrarPreguntaReintentarConexionImpresora(String mensaje, btPrintFile btPrintService, BluetoothDevice device,  boolean[]intentosConexion);
	void mostrarProgreso(String mensaje);
	void mostrarProgreso(String mensaje,Boolean cancelar);
	void mostrarProgreso(String mensaje,String titulo);
	void mostrarProgreso(String mensaje,String titulo,Boolean cancelar);
	void mostrarProgreso(String mensaje,String titulo,Integer avanceTotal);
	void mostrarProgreso(String mensaje,String titulo,Integer avanceTotal,Boolean cancelar);
	void mostrarProgreso(String mensaje,Integer avanceTotal);
	void mostrarProgreso(String mensaje,Integer avanceTotal,Boolean cancelar);
	void actualizarProgreso(String mensaje,Integer avance);
	void actualizarProgreso(Integer avance);
	void actualizarProgreso(String mensaje);
	void quitarProgreso();
	void setTitulo(String texto);
	void setResultado(int resultado);
	void setResultado(int resultado, String mensajeError);	
	void setResultadoParcelable(int resultado, String mensajeError, Parcelable objeto);	
	boolean encenderBluetooth() throws Exception;
	void impresionFinalizada(boolean impresionExitosa,String mensajeError);
	void vincularImpresora(String MACAdress, final Hashtable<String, ContentValues> archivosAImprimir, final File impresion) throws Exception;
}

