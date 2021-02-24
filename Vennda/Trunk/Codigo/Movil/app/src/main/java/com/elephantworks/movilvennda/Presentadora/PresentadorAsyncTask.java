package com.elephantworks.movilvennda.Presentadora;

import android.content.Context;
import android.os.AsyncTask;

import com.elephantworks.movilvennda.Interfaces.IAsyncTask;
import com.elephantworks.movilvennda.Utilerias.Dialogs;

/**
 * Created by ldelatorre on 29/05/2017.
 */
public class PresentadorAsyncTask extends AsyncTask<Void,Void,String> {
    Context context;
    private IAsyncTask mVista;

    public PresentadorAsyncTask(Context context,IAsyncTask mVista){
        this.context = context;
        this.mVista = mVista;
    }

    @Override
    protected void onPreExecute() {
        Dialogs.cargando(context);
        mVista.before();
        super.onPreExecute();
    }

    @Override
    protected String doInBackground(Void... params) {

        return mVista.toDo();
    }

    @Override
    protected void onPostExecute(String result) {

        mVista.after(result);
        Dialogs.dismiss();

        super.onPostExecute(result);
    }
}
