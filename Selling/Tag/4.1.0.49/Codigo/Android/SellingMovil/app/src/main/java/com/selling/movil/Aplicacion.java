package com.selling.movil;

import android.app.Application;
import android.util.Log;

import com.intermec.aidc.AidcManager;
import com.intermec.aidc.BarcodeReader;
import com.selling.movil.utilerias.MetodosEstaticos;
import com.selling.movil.utilerias.Migration;
import com.selling.movil.utilerias.ValoresEstaticos;
import com.splunk.mint.Mint;
import io.realm.Realm;
import io.realm.RealmConfiguration;


/**
 * Created by Eduardo on 08/10/15.
 */
public class Aplicacion extends Application{

    private final String TAG = Aplicacion.class.getName();
    private static BarcodeReader barcodeReader;
    private static Realm realm;

    @Override
    public void onCreate() {
        super.onCreate();

        //Inicializar splunk mint
        Mint.initAndStartSession(this, "7b1f890f");

        //Inicializar realm
        RealmConfiguration realmConfig = new RealmConfiguration.Builder(this)
                .schemaVersion(ValoresEstaticos.REALM_SCHEMA_VERSION)
                .migration(new Migration())
                .build();
        Realm.setDefaultConfiguration(realmConfig);

        if(MetodosEstaticos.obtenerTerminal(getApplicationContext()) == null)
            MetodosEstaticos.guardarTerminal(getApplicationContext(),ValoresEstaticos.PREFERENCES_TERMINAL_GENERICA);

        if(MetodosEstaticos.obtenerTerminal(getApplicationContext()).equalsIgnoreCase(ValoresEstaticos.PREFERENCES_TERMINAL_INT_CN51)){
            try{
                AidcManager.connectService(this, new AidcManager.IServiceListener() {
                    public void onConnect() {

                        // The depended service is connected and it is ready
                        // to receive bar code requests and virtual wedge
                        try {
                            //Initial bar code reader instance
                            barcodeReader = new BarcodeReader();

                        } catch (Exception e) {
                            Log.e(TAG, e.getMessage(), e);
                        }
                    }

                    public void onDisconnect() {
                        //add disconnect message/action here
                    }

                });
            } catch (Exception e){
                Log.e(TAG,e.getMessage(),e);
            }
        }

        RealmConfiguration config = new RealmConfiguration.Builder(getApplicationContext())
                .schemaVersion(ValoresEstaticos.REALM_SCHEMA_VERSION)
                .migration(new Migration())
                .build();

        realm = Realm.getInstance(config);

    }

    public BarcodeReader getBarcodeReader(){
        return barcodeReader;
    }
    public Realm getRealmInstance(){ return realm; }
}
