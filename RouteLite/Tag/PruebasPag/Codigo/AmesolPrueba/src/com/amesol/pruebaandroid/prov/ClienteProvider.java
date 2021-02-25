package com.amesol.pruebaandroid.prov;

import com.amesol.pruebaandroid.ctrl.AdministrarCliente;
import com.amesol.pruebaandroid.dat.SesionBD;

import android.content.ContentProvider;
import android.content.ContentValues;
import android.database.Cursor;
import android.net.Uri;

public class ClienteProvider extends ContentProvider {

	SesionBD sesionBD;
	AdministrarCliente admCliente;
	
	@Override
	public boolean onCreate() {
		sesionBD = new SesionBD(getContext());
		admCliente= new AdministrarCliente(sesionBD);
		return true;
	}

	@Override
	public Cursor query(Uri uri, String[] projection, String selection,
			String[] selectionArgs, String sortOrder) {
		String cons = null;
		if (uri.getPathSegments().size() > 1)
			cons = uri.getLastPathSegment();
		if((cons!=null)&&(cons.length()> 2))
			return admCliente.obtenerClientes(cons);
		return null;
	}

	@Override
	public int delete(Uri uri, String selection, String[] selectionArgs) {
		// TODO Auto-generated method stub
		return 0;
	}

	@Override
	public String getType(Uri uri) {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public Uri insert(Uri uri, ContentValues values) {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public int update(Uri uri, ContentValues values, String selection,
			String[] selectionArgs) {
		// TODO Auto-generated method stub
		return 0;
	}

}
