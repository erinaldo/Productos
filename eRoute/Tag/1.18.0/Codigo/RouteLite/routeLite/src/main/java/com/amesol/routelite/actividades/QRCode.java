package com.amesol.routelite.actividades;

import android.graphics.Bitmap;
import android.graphics.Color;

import com.amesol.routelite.datos.TransProd;
import com.amesol.routelite.datos.TransProdDetalle;
import com.amesol.routelite.datos.basedatos.BDVend;
import com.amesol.routelite.utilerias.Generales;
import com.google.zxing.BarcodeFormat;
import com.google.zxing.MultiFormatWriter;
import com.google.zxing.common.BitMatrix;

/**
 * Created by Sergio-Lap on 7/30/2016.
 */
public class QRCode {

    public static String generarCadenaQRdeTransprod(String TransProdId){
        String cadenaQR = "";
        try{
            TransProd oTrp = new TransProd();
            oTrp.TransProdID = TransProdId;
            BDVend.recuperar(oTrp);
            BDVend.recuperar(oTrp, TransProdDetalle.class);
            cadenaQR += "|" + oTrp.FacturaID; //id
            cadenaQR += "|" + oTrp.Notas; //usuid
            cadenaQR += "|TR001"; //folio generico
            cadenaQR += "|" + Generales.getFechaActualStr() + "|"; //fecha actual
            for(TransProdDetalle oTpd : oTrp.TransProdDetalle){
                cadenaQR += oTpd.ProductoClave + ",";
                cadenaQR += oTpd.TipoUnidad + ",";
                cadenaQR += oTpd.Cantidad + "|";
            }
        }catch (Exception e){
        }
        return cadenaQR;
    }

    public static Bitmap generarQR(String cadenaQR) {
        return generarQR(cadenaQR, 500);
    }

    public static Bitmap generarQR(String cadenaQR, int size){
        //int size=500;
        BitMatrix result;
        try {
            result = new MultiFormatWriter().encode(cadenaQR,
                    BarcodeFormat.QR_CODE, size, size, null);
        } catch (IllegalArgumentException iae) {
            // Unsupported format
            return null;
        } catch (Exception e){
            return null;
        }
        int w = result.getWidth();
        int h = result.getHeight();
        int[] pixels = new int[w * h];
        for (int y = 0; y < h; y++) {
            int offset = y * w;
            for (int x = 0; x < w; x++) {
                pixels[offset + x] = result.get(x, y) ? Color.parseColor("#000000") : Color.parseColor("#ffffff"); //BLACK : WHITE;
            }
        }
        Bitmap bitmap = Bitmap.createBitmap(w, h, Bitmap.Config.ARGB_8888);
        bitmap.setPixels(pixels, 0, size, 0, 0, w, h);
        return bitmap;
    }
}

