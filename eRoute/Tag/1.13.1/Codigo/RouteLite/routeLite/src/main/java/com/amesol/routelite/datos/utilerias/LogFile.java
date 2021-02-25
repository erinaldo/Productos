package com.amesol.routelite.datos.utilerias;

import com.amesol.routelite.datos.Usuario;
import com.amesol.routelite.datos.basedatos.Consultas;

import java.io.BufferedWriter;
import java.io.File;
import java.io.FileWriter;
import java.io.IOException;

/**
 * Created by Adriana on 23/08/2017.
 */
public class LogFile {
    String fileName;

    public LogFile(String sFileName){
        if (Sesion.get(Sesion.Campo.ConfiguracionLocal) != null) { //throw new Exception(NO_CONF);
            ConfiguracionLocal conf = (ConfiguracionLocal) Sesion.get(Sesion.Campo.ConfiguracionLocal);

            fileName = conf.get(ArchivoConfiguracion.CampoConfiguracion.DIRECTORIO_TRABAJO).toString() + "/bd/" + sFileName + ".log";
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

        }
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
