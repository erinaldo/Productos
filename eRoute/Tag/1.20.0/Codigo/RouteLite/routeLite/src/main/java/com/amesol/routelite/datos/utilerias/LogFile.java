package com.amesol.routelite.datos.utilerias;

import com.amesol.routelite.datos.Usuario;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.utilerias.Generales;

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

            File destino = new File(conf.get(ArchivoConfiguracion.CampoConfiguracion.DIRECTORIO_TRABAJO).toString());
            destino = new File(destino, "bd");
            destino.mkdirs();

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

}
