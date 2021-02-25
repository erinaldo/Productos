package com.amesol.routelite.utilerias;

import android.content.Intent;
import android.net.Uri;

import com.amesol.routelite.R;
import com.amesol.routelite.vistas.Vista;

import java.io.File;
import java.util.ArrayList;
import java.util.List;

/**
 * Created by alex.jmnz on 15/06/15.
 */
public abstract class EnvioEmail {

    public static final int MAIL_REQUEST_CODE = 0x7263;

    private Vista vista;

    public EnvioEmail(Vista vista) {
        this.vista = vista;
    }

    public void enviarMail(String mail, String asunto, String cuerpo, File...adjuntos){
        Intent emailIntent = new Intent(Intent.ACTION_SEND);
        emailIntent.setType("plain/text");
        //emailIntent.putExtra(Intent.EXTRA_EMAIL, new String[]{mail});

        int ContadorCorreos = 0;
        for (String correo : mail.split(";")) {
            ContadorCorreos++;
        }
        String[] correos = new String[ContadorCorreos];
        ContadorCorreos = 0;
        for (String correo : mail.split(";")) {
            correos[ContadorCorreos] = correo.trim();
            ContadorCorreos++;
        }
        emailIntent.putExtra(Intent.EXTRA_EMAIL, correos);

        emailIntent.putExtra(Intent.EXTRA_SUBJECT, asunto);
        emailIntent.putExtra(Intent.EXTRA_TEXT, cuerpo);
        for (File file : adjuntos) {
            emailIntent.putExtra(Intent.EXTRA_STREAM, Uri.fromFile(file));
        }
        emailIntent.addFlags(Intent.FLAG_GRANT_READ_URI_PERMISSION);
        vista.startActivityForResult(Intent.createChooser(emailIntent, vista.getString(R.string.send_email)), MAIL_REQUEST_CODE);
    }

    public abstract void envioFinalizado(boolean exito);

}
