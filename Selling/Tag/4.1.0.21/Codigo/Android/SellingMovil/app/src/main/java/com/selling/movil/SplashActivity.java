package com.selling.movil;

import android.app.Activity;
import android.content.Context;
import android.content.Intent;
import android.os.Bundle;
import android.widget.TextView;


import com.selling.movil.utilerias.MetodosEstaticos;
import com.selling.movil.utilerias.ValoresEstaticos;

/**
 * Created by Eduardo on 07/10/15.
 */
public class SplashActivity extends Activity {

    Context context = SplashActivity.this;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_splash);
        ((TextView) findViewById(R.id.versionLbl)).setText(getString(R.string.version_name_lbl) + BuildConfig.VERSION_NAME);

        Thread timerThread = new Thread(){
            public void run(){
                try{
                    sleep(3000);
                }catch(InterruptedException e){
                    e.printStackTrace();
                }finally{
                    Intent mainIntent;
                    if(MetodosEstaticos.checkToken(context) != null) {
                        mainIntent = new Intent(context, MainActivity.class);
                        ValoresEstaticos.ACTUAL_SERVIDOR = MetodosEstaticos.obtenerIP(context);
                    }
                    else
                        mainIntent = new Intent(context,LoginActivity.class);

                    finish();
                    startActivity(mainIntent);
                }
            }
        };
        timerThread.start();
    }

    @Override
    protected void onPause() {
        super.onPause();
        finish();
    }
}
