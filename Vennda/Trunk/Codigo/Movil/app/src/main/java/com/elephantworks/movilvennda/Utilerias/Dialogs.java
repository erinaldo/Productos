package com.elephantworks.movilvennda.Utilerias;

import android.app.AlertDialog;
import android.app.ProgressDialog;
import android.content.Context;
import android.graphics.drawable.ColorDrawable;

import com.elephantworks.movilvennda.R;

/**
 * Created by ldelatorre on 29/05/2017.
 */
public class Dialogs {
    private static ProgressDialog progressDialog;

    public static void cargando(Context context){
        progressDialog = new ProgressDialog(context);
        progressDialog.show();
        progressDialog.getWindow().setBackgroundDrawable(new ColorDrawable(android.graphics.Color.TRANSPARENT));
        progressDialog.setContentView(R.layout.dialog_progress);
        progressDialog.setCancelable(false);

    }

    public static void confirmDialog(Context context, String msg, AlertDialog.OnClickListener positiveListener, AlertDialog.OnClickListener negativeListener){

        AlertDialog.Builder builder = new AlertDialog.Builder(context);

        builder.setTitle(context.getString(R.string.app_name));
        builder.setMessage(msg);
        builder.setCancelable(false);
        builder.setPositiveButton(context.getString(R.string.dialog_si_lbl),positiveListener);

        builder.setNegativeButton(context.getString(R.string.dialog_no_lbl), negativeListener);

        AlertDialog alert = builder.create();
        alert.show();

    }

    public static void dismiss(){
        if(progressDialog != null) {
            progressDialog.dismiss();
            progressDialog = null;
        }
    }
}
