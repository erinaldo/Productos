package com.selling.movil.listeners;

import com.intermec.aidc.BarcodeReadEvent;
import com.intermec.aidc.BarcodeReadListener;
import com.selling.movil.interfaces.OnAceptarListener;
import com.selling.movil.interfaces.OnBarcodeReadListener;

/**
 * Created by Eduardo on 07/01/16.
 */
public class BarcodeListener implements BarcodeReadListener {

    OnBarcodeReadListener listener;

    public BarcodeListener(OnBarcodeReadListener listener) {
        this.listener = listener;
    }

    @Override
    public void barcodeRead(BarcodeReadEvent barcodeReadEvent) {
        listener.onBarcodeReaded(barcodeReadEvent.getBarcodeData());
    }
}
