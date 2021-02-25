package com.selling.movil.utilerias;

import android.app.AlertDialog;
import android.app.ProgressDialog;
import android.content.Context;
import android.content.DialogInterface;
import android.graphics.drawable.ColorDrawable;
import android.util.Log;
import android.view.View;

import com.selling.movil.R;


/**
 * Created by Eduardo on 05/10/15.
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

    public static void confirmDialog(Context context,String msg,AlertDialog.OnClickListener positiveListener, AlertDialog.OnClickListener negativeListener){

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
