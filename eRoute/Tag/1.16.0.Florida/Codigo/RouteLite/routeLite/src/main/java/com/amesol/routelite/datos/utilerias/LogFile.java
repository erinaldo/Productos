package com.amesol.routelite.datos.utilerias;

import android.content.ContentValues;
import android.os.AsyncTask;
import android.os.NetworkOnMainThreadException;
import android.widget.Toast;

import com.amesol.routelite.actividades.GMailSender;
import com.amesol.routelite.datos.Cliente;
import com.amesol.routelite.datos.Usuario;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.interfaces.IServidorComunicaciones;
import com.amesol.routelite.utilerias.ControlError;
import com.amesol.routelite.utilerias.EnvioEmail;
import com.amesol.routelite.utilerias.Generales;
import com.amesol.routelite.vistas.Vista;
import com.amesol.routelite.vistas.utilerias.Dispositivo;

import java.io.BufferedWriter;
import java.io.File;
import java.io.FileWriter;
import java.io.FilenameFilter;
import java.io.IOException;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Collections;

/**
 * Created by Adriana on 23/08/2017.
 */
public class LogFile {
    String fileName;
    String dirHistoricos;
    public LogFile(String sFileName){
        if (Sesion.get(Sesion.Campo.ConfiguracionLocal) != null) { //throw new Exception(NO_CONF);
            ConfiguracionLocal conf = (ConfiguracionLocal) Sesion.get(Sesion.Campo.ConfiguracionLocal);

            fileName = conf.get(ArchivoConfiguracion.CampoConfiguracion.DIRECTORIO_TRABAJO).toString() + "/bd/" + sFileName +"_"+ Generales.getFormatoFecha(Generales.getFechaActual(), "yyyy-MM-dd")+ ".log";
            File logFile = new File(fileName);

            if (!logFile.exists())
            {
                try
                {
                    logFile.createNewFile();
                }
                catch (IOException e)
                {
                    // TODO Auto-generated catch block
                    e.printStackTrace();
                }
            }

            String directorio = conf.get(ArchivoConfiguracion.CampoConfiguracion.DIRECTORIO_TRABAJO).toString() + "/bd/";
            File file = new File(directorio);
            File[] arrFile = file.listFiles();
            if(arrFile.length > 8){
                ArrayList<String> fechas = new ArrayList<String>();
                int cuantos = 0;
                for(File inFile : arrFile) {
                    if(inFile.getName().contains(".log")) {
                        if(inFile.getName().length() > 14)
                            fechas.add(inFile.getName().substring(inFile.getName().length() - 14, inFile.getName().length() - 4));
                    }
                }
                if(fechas.size() > 2)
                {
                    Collections.sort(fechas);
                    logFile = new File(directorio + sFileName +"_"+ fechas.get(0) + ".log");
                    logFile.delete();
                }
            }
            //Directorio para historico de recibos
            try {

                File impresion = new File(conf.get(ArchivoConfiguracion.CampoConfiguracion.DIRECTORIO_TRABAJO).toString());
                impresion = new File(impresion, "Historico");
                impresion = new File(impresion, "Historico_" + Generales.getFormatoFecha(Generales.getFechaActual(), "yyyy-MM-dd"));
                if (!impresion.exists()) {
                    if (!impresion.mkdirs()) {

                    }
                }
                File dirHistorico = new File(conf.get(ArchivoConfiguracion.CampoConfiguracion.DIRECTORIO_TRABAJO).toString());
                dirHistorico = new File(dirHistorico, "Historico");
                FilenameFilter filter = new FilenameFilter() {

                    public boolean accept(File f, String name)
                    {
                        return name.startsWith("Historico_");
                    }
                };
                dirHistoricos = impresion.getPath() ;
                File[] directoriosHist = dirHistorico.listFiles(filter);
                    for(File inFile : directoriosHist) {
                        //Si no es el directorio actual, se borra
                        if(!inFile.getName().equals(impresion.getName())&& inFile.isDirectory()) {
                            for(File inFile2 : inFile.listFiles()) {
                                inFile2.delete();
                            }
                            inFile.delete();
                        }
                    }
            }catch(Exception e){
                e.printStackTrace();
            }


            if (!logFile.exists())
            {
                try
                {
                    logFile.createNewFile();
                }
                catch (IOException e)
                {
                    // TODO Auto-generated catch block
                    e.printStackTrace();
                }
            }


        }
    }
public String getDirHistoricos(){
    return dirHistoricos;
}
    public void appendLog(String text)
    {
        File logFile = new File(fileName);
        if (!logFile.exists())
        {
            try
            {
                logFile.createNewFile();
            }
            catch (IOException e)
            {
                // TODO Auto-generated catch block
                e.printStackTrace();
            }
        }
        try
        {

            //BufferedWriter for performance, true to set append to file flag
            BufferedWriter buf = new BufferedWriter(new FileWriter(logFile, true));
            buf.append(text);
            buf.append(System.lineSeparator());
            buf.newLine();
            buf.close();
        }
        catch (IOException e)
        {
            // TODO Auto-generated catch block
            e.printStackTrace();
        }
    }

    public void enviarLogXCorreo(final Vista vista){
        try{

                ConfiguracionLocal conf = (ConfiguracionLocal) Sesion.get(Sesion.Campo.ConfiguracionLocal);
                if (Boolean.parseBoolean(conf.get(ArchivoConfiguracion.CampoConfiguracion.WIFI).toString())) {
                    Dispositivo.EncenderApagarWiFi(vista, true, 4);
                }

            /*EnvioEmail envioEmail = new EnvioEmail(vista) {
                public void envioFinalizado(boolean exito) {
                }
            };

            File logFile = new File(fileName);
            if (logFile.exists()) {
                envioEmail.enviarMail("projas@duxstar.com.mx", "Log Error", "Se adjunta el log de errores para busqueda de escenario", logFile);
            }*/

            try {

                AsyncTask.execute(new Runnable() {
                    @Override
                    public void run() {
                        try {
                            GMailSender m = new GMailSender("soporte@duxstar.com.mx", "Duxstar.2020");

                            String[] toArr = {"projas@duxstar.com.mx", "jrodriguez@duxstar.com.mx"};
                            m.setTo(toArr);
                            m.setFrom("soporte@duxstar.com.mx");
                            m.setSubject("Log Error");
                            m.setBody("Se adjunta el log de errores para busqueda de escenario");
                            m.addAttachment(fileName);
                            if(m.send()) {
                                //Toast.makeText(vista.getApplicationContext() , "Email was sent successfully.", Toast.LENGTH_LONG).show();
                            } else {
                                //Toast.makeText(vista.getApplicationContext(), "Email was not sent.", Toast.LENGTH_LONG).show();
                            }

                        }catch(NetworkOnMainThreadException nEx){
                            nEx.printStackTrace();
                       }catch (IOException e) {
                            e.printStackTrace();
                        }catch(Exception e){
                           e.printStackTrace();
                        }
                    }
                });

            }catch(NetworkOnMainThreadException nEx){
                //Toast.makeText(vista.getApplicationContext(), "There was a problem sending the email.", Toast.LENGTH_LONG).show();
            }
            catch(Exception e) {
                //Toast.makeText(vista.getApplicationContext(), "There was a problem sending the email.", Toast.LENGTH_LONG).show();
               // Log.e("MailApp", "Could not send email", e);
            }

        } catch (Exception ex) {
            Toast.makeText(vista.getApplicationContext(), "There was a problem sending the email.", Toast.LENGTH_LONG).show();

        }
    }

}
