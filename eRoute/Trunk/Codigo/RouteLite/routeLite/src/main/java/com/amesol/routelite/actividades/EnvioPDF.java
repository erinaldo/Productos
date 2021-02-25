package com.amesol.routelite.actividades;

import android.app.AlertDialog;
import android.app.Dialog;
import android.content.ContentValues;
import android.content.Context;
import android.content.DialogInterface;
import android.content.pm.PackageInstaller;
import android.graphics.Color;
import android.view.KeyEvent;
import android.view.LayoutInflater;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ListView;
import android.widget.TextView;

import com.amesol.routelite.R;
import com.amesol.routelite.datos.*;
import com.amesol.routelite.datos.basedatos.BDVend;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.basedatos.Consultas2;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.ArchivoConfiguracion;
import com.amesol.routelite.datos.utilerias.CONHist;
import com.amesol.routelite.datos.utilerias.ConfiguracionLocal;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.presentadores.*;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.act.ServirComunicaciones;
import com.amesol.routelite.presentadores.interfaces.IServidorComunicaciones;
import com.amesol.routelite.utilerias.EnvioEmail;
import com.amesol.routelite.utilerias.EnvioSMS;
import com.amesol.routelite.utilerias.Generales;
import com.amesol.routelite.utilerias.KeyGen;
import com.amesol.routelite.vistas.Vista;
import com.amesol.routelite.vistas.generico.DialogoAlerta;
import com.amesol.routelite.vistas.utilerias.Dispositivo;

import java.io.File;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.Hashtable;
import java.util.Iterator;
import java.util.List;
import java.util.Map;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

/**
 * Created by Adriana on 29/12/2016.
 */
public class EnvioPDF{
    public static void enviarTicketPDF(final Vista vista, short tipoEnvio){
        try {

            //tipoEnvio = 3;
            final Cliente oClienteAct = (Cliente) Sesion.get(Sesion.Campo.ClienteActual);
            final short nTipoEnvio = tipoEnvio;
            final String sValorInicial = (nTipoEnvio == 2 ? (oClienteAct.CorreoElectronico == null ? "" : oClienteAct.CorreoElectronico) : (oClienteAct.TelefonoContacto == null ? "" : oClienteAct.TelefonoContacto));

            LayoutInflater inflater = (LayoutInflater) vista
                    .getSystemService(Context.LAYOUT_INFLATER_SERVICE);

            final View dialogView = inflater.inflate(R.layout.dialog_enviar_pdf, null);

            AlertDialog.Builder builder = new AlertDialog.Builder(vista);
            TextView lblTitulo = (TextView) dialogView.findViewById(R.id.lblTitulo);
            final TextView lblSolicitud = (TextView) dialogView.findViewById(R.id.lblSolicitud);
            final EditText txtSolicitud = (EditText) dialogView.findViewById(R.id.txtSolicitud);
            txtSolicitud.setEnabled(false);
            final Button btnEditar = (Button) dialogView.findViewById(R.id.btnEditar);
            final Button btnGuardar = (Button) dialogView.findViewById(R.id.btnGuardar);
            btnGuardar.setEnabled(false);
            btnEditar.setOnClickListener(new View.OnClickListener() {
                public void onClick(View v)
                {
                    btnEditar.setEnabled(false);
                    btnGuardar.setEnabled(true);
                    txtSolicitud.setEnabled(true);
                    txtSolicitud.requestFocus();
                }
            });

            btnGuardar.setOnClickListener(new View.OnClickListener() {
                public void onClick(View v)
                {
                    if (txtSolicitud.getText().toString().trim().equals("")) {
                        vista.mostrarError(Mensajes.get("BE0001").replace("$0$", lblSolicitud.getText().toString()));
                        txtSolicitud.requestFocus();
                        return;
                    }

                    if (!validarFormato(txtSolicitud.getText().toString().trim(), nTipoEnvio)){
                        if (nTipoEnvio == 2 || nTipoEnvio == 4)
                            vista.mostrarError(Mensajes.get("E0816"));
                        else
                            vista.mostrarError(Mensajes.get("E0964").replace("$0$", "10"));

                        txtSolicitud.requestFocus();
                        return;
                    }

                    btnEditar.setEnabled(true);
                    btnGuardar.setEnabled(false);
                    txtSolicitud.setEnabled(false);
                }
            });

            String sEnviar = "";
            if (tipoEnvio == 2 || tipoEnvio == 4) {
                lblTitulo.setText(Mensajes.get("XEnvioCorreo"));
                lblSolicitud.setText(Mensajes.get("XCorreoCliente"));
                sEnviar = Mensajes.get("BTEnviarCorreo");
                txtSolicitud.setText(oClienteAct.CorreoElectronico);
            }else if (tipoEnvio == 3){
                lblTitulo.setText(Mensajes.get("XEnvioSMS"));
                lblSolicitud.setText(Mensajes.get("XCelularCliente"));
                sEnviar = Mensajes.get("BTEnviarSMS");
                txtSolicitud.setText(oClienteAct.TelefonoContacto);
            }
            btnEditar.setText(Mensajes.get("BTEditar"));
            btnGuardar.setText(Mensajes.get("BTGuardar"));

            /*builder.setPositiveButton("sEnviar",
                    new DialogInterface.OnClickListener()
                    {
                        @Override
                        public void onClick(DialogInterface dialog, int which)
                        {
                            //Do nothing here because we override this button later to change the close behaviour.
                            //However, we still need this because on older versions of Android unless we
                            //pass a handler the button doesn't get instantiated
                        }
                    });*/

            builder.setPositiveButton(sEnviar, new DialogInterface.OnClickListener() {
                public void onClick(DialogInterface dialog, int id) {
                    try {
                        if (txtSolicitud.getText().toString().trim().equals("")) {
                            vista.mostrarError(Mensajes.get("BE0001").replace("$0$", lblSolicitud.getText().toString()), 100);
                            txtSolicitud.requestFocus();
                            return;
                        }
                        if (!validarFormato(txtSolicitud.getText().toString().trim(), nTipoEnvio)){
                            if (nTipoEnvio == 2 || nTipoEnvio == 4)
                                vista.mostrarError(Mensajes.get("E0816"), 100);
                            else
                                vista.mostrarError(Mensajes.get("E0964").replace("$0$", "10"), 100);

                            txtSolicitud.requestFocus();
                            return;
                        }

                        if (nTipoEnvio == 2 || nTipoEnvio == 4)
                            oClienteAct.CorreoElectronico = txtSolicitud.getText().toString();
                        else
                            oClienteAct.TelefonoContacto = txtSolicitud.getText().toString();

                        BDVend.guardarInsertar(oClienteAct);
                        BDVend.commit();
                        vista.resultadoActividad(Enumeradores.Solicitudes.SOLICITUD_ENVIAR_PDF, Enumeradores.Resultados.RESULTADO_BIEN, null);
                        //vista.setResultado(Enumeradores.Resultados.RESULTADO_ENVIAR);
                        dialog.dismiss();
                    }catch (Exception e){
                        e.printStackTrace();
                    }
                }
            });

            builder.setNegativeButton(Mensajes.get("XCancelar"), new DialogInterface.OnClickListener() {
                public void onClick(DialogInterface dialog, int id) {
                    vista.resultadoActividad(Enumeradores.Solicitudes.SOLICITUD_ENVIAR_PDF, Enumeradores.Resultados.RESULTADO_MAL, null);
                    dialog.dismiss();
                    //dialog.cancel();
                }
            });

            builder.setView(dialogView);
            final AlertDialog dialog = builder.create();

            dialog.setOnKeyListener(new DialogInterface.OnKeyListener() {
                @Override
                public boolean onKey(final DialogInterface dialog, int keyCode, KeyEvent event) {
                    if (event.getAction() == KeyEvent.ACTION_DOWN) {
                        if (keyCode == KeyEvent.KEYCODE_BACK) {
                            //return false;
                            if (!sValorInicial.equals(txtSolicitud.getText().toString())) {
                                vista.mostrarPreguntaSiNo(Mensajes.get("BP0002"), 3);
                                return false;
                            } else {
                                dialog.cancel();
                                return true;
                            }
                        }
                    }
                    return false;
                }
            });

            /*dialog.getButton(AlertDialog.BUTTON_POSITIVE).setOnClickListener(new View.OnClickListener()
            {
                @Override
                public void onClick(View v)
                {
                    try {
                        if (txtSolicitud.getText().equals("")) {
                            vista.mostrarError(Mensajes.get("BE0001").replace("$0$", lblSolicitud.getText().toString()), 100);
                            txtSolicitud.requestFocus();
                            return;
                        }
                        if (!validarFormato(txtSolicitud.getText().toString().trim(), nTipoEnvio)){
                            if (nTipoEnvio == 2)
                                vista.mostrarError(Mensajes.get("E0816"), 100);
                            else
                                vista.mostrarError(Mensajes.get("E0964"), 100);

                            txtSolicitud.requestFocus();

                            return;
                        }

                        if (nTipoEnvio == 2)
                            oClienteAct.CorreoElectronico = txtSolicitud.getText().toString();
                        else
                            oClienteAct.TelefonoContacto = txtSolicitud.getText().toString();

                        BDVend.guardarInsertar(oClienteAct);
                        BDVend.commit();
                        vista.resultadoActividad(Enumeradores.Solicitudes.SOLICITUD_ENVIAR_PDF, Enumeradores.Resultados.RESULTADO_BIEN, null);
                        //vista.setResultado(Enumeradores.Resultados.RESULTADO_ENVIAR);
                        dialog.dismiss();
                    }catch (Exception e){
                        e.printStackTrace();
                    }
                }
            });*/

            dialog.setOnCancelListener(new DialogInterface.OnCancelListener() {
                @Override
                public void onCancel(DialogInterface dialog) {
                    vista.setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
                    vista.finalizar();
                }
            });


            dialog.show();

        } catch (Exception ex) {
            ex.printStackTrace();
        }
    }

    public static boolean validarFormato(String sDato, short tipoEnvio) {

        String regex;
        if (tipoEnvio == 2 || tipoEnvio == 4)
            regex = "^[\\w!#$%&'*+/=?`{|}~^-]+(?:\\.[\\w!#$%&'*+/=?`{|}~^-]+)*@(?:[a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$";
        else
            regex = "^[0-9]{10}$";
        Pattern pattern = Pattern.compile(regex);
        Matcher matcher = pattern.matcher(sDato);
        return matcher.matches();
    }

    public static boolean validarEmail(String sEmail) {
        String regex = "^[\\w!#$%&'*+/=?`{|}~^-]+(?:\\.[\\w!#$%&'*+/=?`{|}~^-]+)*@(?:[a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$";
        Pattern pattern = Pattern.compile(regex);
        Matcher matcher = pattern.matcher(sEmail);
        return matcher.matches();
    }

    public static boolean validarTelefono(String sTelefono){
        String regex = "^[0-9]{10}$";
        Pattern pattern = Pattern.compile(regex);
        Matcher matcher = pattern.matcher(sTelefono);
        return matcher.matches();
    }

    public static void enviarArchivos(final Vista vista){
        vista.iniciarActividadConResultado(IServidorComunicaciones.class, Enumeradores.Solicitudes.SOLICITUD_ENVIAR_PDF_SERVER, Enumeradores.Acciones.ACCION_ENVIAR_ARCHIVO_PDF);
    }

    public static void enviarArchivo(final Vista vista, short tipoEnvio, final String sArchivo, ContentValues oValoresPDF, boolean bPrimeraVez){
        try{
            //tipoEnvio = 3;
            Sesion.set(Sesion.Campo.ArchivoPDF, sArchivo);
            Sesion.set(Sesion.Campo.TransaccionActualPDF, oValoresPDF);

            if (tipoEnvio == 2) {
                ConfiguracionLocal conf = (ConfiguracionLocal) Sesion.get(Sesion.Campo.ConfiguracionLocal);
                if (bPrimeraVez) {
                    if (Boolean.parseBoolean(conf.get(ArchivoConfiguracion.CampoConfiguracion.WIFI).toString())) {
                        Dispositivo.EncenderApagarWiFi(vista, true, 4);
                    }
                }

                EnvioEmail envioEmail = new EnvioEmail(vista) {
                    public void envioFinalizado(boolean exito) {
                        vista.setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
                        vista.finalizar();
                    }
                };

                Cliente oClienteAct = (Cliente) Sesion.get(Sesion.Campo.ClienteActual);
                ISetDatos encabezado = Consultas.ConsultasImpresionTicket.obtenerEncabezado();
                encabezado.moveToFirst();

                //for (String sArchivo : lstArchivos) {
                String asunto = encabezado.getString("NombreEmpresa") + " " + sArchivo;
                String cuerpo = "Estimado Cliente: \n\n";
                cuerpo += "Anexo encontrará su ticket en formato PDF.\n";
                cuerpo += "Favor de conservarlo para futuras aclaraciones.\n\n";
                cuerpo += "Este es un mensaje generado automáticamente por el sistema. Favor de no responder al mismo.";

                File archivoPDF = new File(conf.get(ArchivoConfiguracion.CampoConfiguracion.DIRECTORIO_TRABAJO).toString() + "/TicketsPDF/" + sArchivo + ".pdf");
                if (archivoPDF.exists()) {
                    envioEmail.enviarMail(oClienteAct.CorreoElectronico, asunto, cuerpo, archivoPDF);
                }

            }
            else if (tipoEnvio == 3){
                //Sesion.set(Sesion.Campo.FolioPDF, oValoresPDF.get("Folio"));
                //Sesion.set(Sesion.Campo.TotalPDF, oValoresPDF.get("Total"));
                vista.iniciarActividadConResultado(IServidorComunicaciones.class, Enumeradores.Solicitudes.SOLICITUD_ENVIAR_PDF_SERVER, Enumeradores.Acciones.ACCION_ENVIAR_ARCHIVO_PDF);
            }

        } catch (Exception ex) {
            vista.mostrarError(ex.getMessage());
            vista.resultadoActividad(Enumeradores.Solicitudes.SOLICITUD_ENVIAR_PDF, Enumeradores.Resultados.RESULTADO_MAL, null);
        }
    }

    public static void enviarSMS(final Vista vista) {
        Cliente oClienteAct = (Cliente) Sesion.get(Sesion.Campo.ClienteActual);
        String sArchivoPDF = Sesion.get(Sesion.Campo.ArchivoPDF).toString();
        ContentValues oValoresPDF = (ContentValues) Sesion.get(Sesion.Campo.TransaccionActualPDF);
        String sURLServer = Sesion.get(Sesion.Campo.URLServerPDF).toString();
        String sFolio = oValoresPDF.get("Folio").toString();
        String sTotal = oValoresPDF.get("Total").toString();

        /*String sMensaje = "Folio: " + sFolio + " \n";
        sMensaje += "Total: " + sTotal + " \n";
        sMensaje += "Estimado Cliente: \n";
        sMensaje += "En el siguiente link podrá consultar y/o descargar su ticket en formato PDF: " + sURLServer + sArchivoPDF + ".pdf";*/

        String sMensaje = "Estimado Cliente: ";
        sMensaje += "En el siguiente link puede consultar y/o descargar su ticket: " + sURLServer + sArchivoPDF + ".pdf";

        //String sMensaje =  sURLServer + sArchivoPDF;

        EnvioSMS.enviarSMS(vista, oClienteAct.TelefonoContacto, sMensaje);
    }

    public static void agregarArchivoEnviado(){
        List<String> lstEnviados;
        if (Sesion.get(Sesion.Campo.ArchivosPDFEnviados) != null)
            lstEnviados = (List<String>)Sesion.get(Sesion.Campo.ArchivosPDFEnviados);
        else
            lstEnviados = new ArrayList<>();

        lstEnviados.add(Sesion.get(Sesion.Campo.ArchivoPDF).toString());
        Sesion.set(Sesion.Campo.ArchivosPDFEnviados, lstEnviados);
    }

    public static String obtenerSiguienteArchivo(){
        Hashtable<String, ContentValues> htArchivosPDF = (Hashtable<String, ContentValues>)Sesion.get(Sesion.Campo.ArchivosPDFxEnviar);
        List<String> lstEnviados = (List<String>)Sesion.get(Sesion.Campo.ArchivosPDFEnviados);

        Iterator<Map.Entry<String, ContentValues>> it =  htArchivosPDF.entrySet().iterator();

        String sArchivoPDF = "";
        while (it.hasNext()){
            Map.Entry<String, ContentValues> entry = it.next();
            sArchivoPDF = entry.getKey();
            if (!lstEnviados.contains(sArchivoPDF))
                return sArchivoPDF;
        }

        return "";
    }

    public static void guardarArchivosNoEnviados(){
        try {
            Hashtable<String, ContentValues> htArchivosPDF = (Hashtable<String, ContentValues>)Sesion.get(Sesion.Campo.ArchivosPDFxEnviar);
            List<String> lstEnviados = (List<String>)Sesion.get(Sesion.Campo.ArchivosPDFEnviados);
            //String sClienteClave = ((Cliente) Sesion.get(Sesion.Campo.ClienteActual)).ClienteClave;

            Iterator<Map.Entry<String, ContentValues>> it =  htArchivosPDF.entrySet().iterator();

            String sArchivoPDF = "";
            while (it.hasNext()){
                Map.Entry<String, ContentValues> entry = it.next();
                sArchivoPDF = entry.getKey();
                if (lstEnviados == null || !lstEnviados.contains(sArchivoPDF)){
                    ContentValues oValoresPDF = entry.getValue();
                    String sId = oValoresPDF.get("Id").toString();
                    String sTipo = oValoresPDF.get("Tipo").toString();
                    String sClienteClave = oValoresPDF.get("ClienteClave").toString();

                    String sEnvioID = Consultas2.ConsultasEnvioPendientePDF.obtenerIdEnvioPendiente(sClienteClave, sId, sTipo);

                    EnvioPendientePDF oEnvioPendientePDF = new EnvioPendientePDF();
                    if (sEnvioID == "") {
                        oEnvioPendientePDF.EnvioID = KeyGen.getId();
                        oEnvioPendientePDF.ClienteClave = sClienteClave;
                        oEnvioPendientePDF.Archivo = sArchivoPDF;
                        if (sTipo == "10")
                            oEnvioPendientePDF.ABNId = sId;
                        else
                            oEnvioPendientePDF.TransProdID = sId;
                    }
                    else{
                        oEnvioPendientePDF.EnvioID = sEnvioID;
                        BDVend.recuperar(oEnvioPendientePDF);
                        oEnvioPendientePDF.Archivo = sArchivoPDF;
                    }
                    oEnvioPendientePDF.MFechaHora = Generales.getFechaHoraActual();
                    oEnvioPendientePDF.MUsuarioId = ((Usuario) Sesion.get(Sesion.Campo.UsuarioActual)).USUId;
                    oEnvioPendientePDF.Enviado = false;
                    BDVend.guardarInsertar(oEnvioPendientePDF);
                }
            }
            BDVend.commit();
        }catch (Exception e)
        {
            e.printStackTrace();
        }

    }

    public static void EnviarSiguiente(Vista vista, String sArchivoPDF){
        Hashtable<String, ContentValues> htArchivosPDF = (Hashtable<String, ContentValues>)Sesion.get(Sesion.Campo.ArchivosPDFxEnviar);
        ContentValues oValoresPDF = htArchivosPDF.get(sArchivoPDF);

        Sesion.set(Sesion.Campo.ArchivoPDF, sArchivoPDF);
        Sesion.set(Sesion.Campo.TransaccionActualPDF, oValoresPDF);
        EnvioPDF.enviarSMS(vista);
    }


    public static void guardarArchivosNoGenerados(){
        try {
            Hashtable<String, String> htArchivosPDF = (Hashtable<String, String>)Sesion.get(Sesion.Campo.ArchivosPDFxGenerar);
            String sClienteClave = ((Cliente) Sesion.get(Sesion.Campo.ClienteActual)).ClienteClave;

            Iterator<Map.Entry<String, String>> it =  htArchivosPDF.entrySet().iterator();

            String sId = "";
            String sTipo = "";
            String sEnvioID = "";
            while (it.hasNext()){
                Map.Entry<String, String> entry = it.next();
                sId = entry.getKey();
                sTipo = entry.getValue();

                sEnvioID = Consultas2.ConsultasEnvioPendientePDF.obtenerIdEnvioPendiente(sClienteClave, sId, sTipo);
                EnvioPendientePDF oEnvioPendientePDF = new EnvioPendientePDF();
                if (sEnvioID == "") {
                    oEnvioPendientePDF.EnvioID = KeyGen.getId();
                    oEnvioPendientePDF.ClienteClave = sClienteClave;
                    if (sTipo == "10")
                        oEnvioPendientePDF.ABNId = sId;
                    else
                        oEnvioPendientePDF.TransProdID = sId;
                    oEnvioPendientePDF.Enviado = false;
                }
                else{
                    oEnvioPendientePDF.EnvioID = sEnvioID;
                    BDVend.recuperar(oEnvioPendientePDF);
                    oEnvioPendientePDF.Archivo = null;
                    oEnvioPendientePDF.Enviado = false;
                }
                BDVend.guardarInsertar(oEnvioPendientePDF);
            }
            BDVend.commit();
        }catch (Exception e)
        {
            e.printStackTrace();
        }
    }

}
