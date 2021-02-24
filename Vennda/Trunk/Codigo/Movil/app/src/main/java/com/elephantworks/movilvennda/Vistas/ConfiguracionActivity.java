package com.elephantworks.movilvennda.Vistas;

import android.bluetooth.BluetoothAdapter;
import android.bluetooth.BluetoothDevice;
import android.content.Intent;
import android.os.Bundle;
import android.provider.SyncStateContract;
import android.support.v7.app.AppCompatActivity;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.Spinner;
import android.widget.Toast;

import com.elephantworks.movilvennda.Aplicacion;
import com.elephantworks.movilvennda.Modelos.ImpresoraHomologada;
import com.elephantworks.movilvennda.R;

import java.util.ArrayList;
import java.util.Set;

import io.realm.Realm;

/**
 * Created by elephantworkss.adec.v on 03/09/17.
 */

public class ConfiguracionActivity extends AppCompatActivity implements View.OnClickListener {

    private Spinner sImpresora;
    private Button btnGuardar;
    private Realm realm;
    private BluetoothAdapter mBluetoothAdapter;
    private ArrayList<String> deviceNames;
    private ArrayList<String> deviceAddress;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_configuracion);
        realm = ((Aplicacion) this.getApplicationContext()).getRealmInstance();
        sImpresora = (Spinner) findViewById(R.id.sImpresoras);
        btnGuardar = (Button) findViewById(R.id.btnGuargarConfiguracion);
        btnGuardar.setOnClickListener(this);

        ImpresoraHomologada impresoraHomologada = realm.where(ImpresoraHomologada.class).findFirst();

        if(impresoraHomologada != null){
            cargarBluetoothLista(impresoraHomologada);
        }else{
            Toast.makeText(this, this.getString(R.string.imprimir_no_configurado), Toast.LENGTH_SHORT).show();
        }


    }

    public void cargarBluetoothLista(ImpresoraHomologada impresoraHomologada){

        mBluetoothAdapter = BluetoothAdapter.getDefaultAdapter();

        if(mBluetoothAdapter == null){
            sImpresora.setVisibility(View.GONE);
        } else if(!mBluetoothAdapter.isEnabled()) {
            sImpresora.setVisibility(View.GONE);
            Toast.makeText(this, this.getString(R.string.imprimir_bluetooth_activar), Toast.LENGTH_SHORT).show();
        } else {

            Set<BluetoothDevice> pairedDevices = mBluetoothAdapter.getBondedDevices();

            if (pairedDevices.size() > 0) {


                deviceNames = new ArrayList<String>();
                deviceAddress = new ArrayList<String>();
                //deviceModels = new ArrayList<String>();

                //Configuracion Spinner Nombres
                for (BluetoothDevice device : pairedDevices) {
                    deviceNames.add(device.getName());
                    deviceAddress.add(device.getAddress());
                }

                ArrayAdapter<String> namesAdapter = new ArrayAdapter<String>(this,android.R.layout.simple_spinner_dropdown_item,deviceNames);
                namesAdapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
                sImpresora.setAdapter(namesAdapter);

                if(impresoraHomologada.getNombreDispositivo() != null) {
                    if(deviceNames.contains(impresoraHomologada.getNombreDispositivo())){
                        sImpresora.setSelection(deviceNames.indexOf(impresoraHomologada.getNombreDispositivo()));
                    }
                }

            } else {
                Toast.makeText(this, this.getString(R.string.imprimir_bluetooth_no_disp), Toast.LENGTH_SHORT).show();
                sImpresora.setVisibility(View.GONE);
            }

        }

    }

    @Override
    public void onClick(View view) {
        if (view.getId() == findViewById(R.id.btnGuargarConfiguracion).getId()) {

            guardarImpresora();

            finish();
        }
    }


    public void guardarImpresora(){

        if(deviceNames != null ) {
            realm.executeTransaction(new Realm.Transaction() {
                @Override
                public void execute(Realm realm2) {
                    ImpresoraHomologada impresoraHomologada = realm2.where(ImpresoraHomologada.class).findFirst();
                    impresoraHomologada.setMacImpresora(deviceAddress.get(sImpresora.getSelectedItemPosition()));
                    impresoraHomologada.setNombreDispositivo(sImpresora.getSelectedItem().toString());
                }
            });
        }

    }
}
