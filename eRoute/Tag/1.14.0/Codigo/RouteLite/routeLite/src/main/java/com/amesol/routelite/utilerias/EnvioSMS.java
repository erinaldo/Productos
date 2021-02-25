package com.amesol.routelite.utilerias;

import android.app.Activity;
import android.app.PendingIntent;
import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.Intent;
import android.content.IntentFilter;
import android.os.Bundle;
import android.telephony.SmsManager;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.vistas.Vista;

/**
 * Created by Adriana on 04/01/2017.
 */
public class EnvioSMS {

    public static void enviarSMS(final Activity activity, String phoneNumber, String message)
    {
        String SENT = "SMS_SENT";
        String DELIVERED = "SMS_DELIVERED";

        PendingIntent sentPI = PendingIntent.getBroadcast(activity, 0, new Intent(SENT), 0);

        PendingIntent deliveredPI = PendingIntent.getBroadcast(activity, 0, new Intent(DELIVERED), 0);

        //---when the SMS has been sent---
        activity.registerReceiver(new BroadcastReceiver(){
            @Override
            public void onReceive(Context arg0, Intent arg1) {
                switch (getResultCode())
                {
                    case Activity.RESULT_OK:
                        //Toast.makeText(activity.getBaseContext(), "SMS sent", Toast.LENGTH_SHORT).show();
                        ((Vista)activity).resultadoActividad(Enumeradores.Solicitudes.SOLICITUD_ENVIAR_SMS, Enumeradores.Resultados.RESULTADO_BIEN, null);
                        break;
                    case SmsManager.RESULT_ERROR_GENERIC_FAILURE:
                        //Toast.makeText(activity.getBaseContext(), "Generic failure", Toast.LENGTH_SHORT).show();
                        ((Vista)activity).resultadoActividad(Enumeradores.Solicitudes.SOLICITUD_ENVIAR_SMS, Enumeradores.Resultados.RESULTADO_MAL, null);
                        break;
                    case SmsManager.RESULT_ERROR_NO_SERVICE:
                        //Toast.makeText(activity.getBaseContext(), "No service", Toast.LENGTH_SHORT).show();
                        ((Vista)activity).resultadoActividad(Enumeradores.Solicitudes.SOLICITUD_ENVIAR_SMS, Enumeradores.Resultados.RESULTADO_MAL, null);
                        break;
                    case SmsManager.RESULT_ERROR_NULL_PDU:
                        //Toast.makeText(activity.getBaseContext(), "Null PDU", Toast.LENGTH_SHORT).show();
                        ((Vista)activity).resultadoActividad(Enumeradores.Solicitudes.SOLICITUD_ENVIAR_SMS, Enumeradores.Resultados.RESULTADO_MAL, null);
                        break;
                    case SmsManager.RESULT_ERROR_RADIO_OFF:
                        //Toast.makeText(activity.getBaseContext(), "Radio off", Toast.LENGTH_SHORT).show();
                        ((Vista)activity).resultadoActividad(Enumeradores.Solicitudes.SOLICITUD_ENVIAR_SMS, Enumeradores.Resultados.RESULTADO_MAL, null);
                        break;
                }
            }
        }, new IntentFilter(SENT));

        //---when the SMS has been delivered---
        activity.registerReceiver(new BroadcastReceiver(){
            @Override
            public void onReceive(Context arg0, Intent arg1) {
                switch (getResultCode())
                {
                    case Activity.RESULT_OK:
                        //Toast.makeText(activity.getBaseContext(), "SMS delivered", Toast.LENGTH_SHORT).show();
                        break;
                    case Activity.RESULT_CANCELED:
                        //Toast.makeText(activity.getBaseContext(), "SMS not delivered", Toast.LENGTH_SHORT).show();
                        break;
                }
            }
        }, new IntentFilter(DELIVERED));

        SmsManager sms = SmsManager.getDefault();
        sms.sendTextMessage(phoneNumber, null, message, sentPI, deliveredPI);
    }
}
