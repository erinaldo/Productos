package com.amesol.pruebaandroid.act;

import java.util.Calendar;
import java.util.GregorianCalendar;
import java.util.Timer;
import java.util.TimerTask;

import com.amesol.pruebaandroid.R;

import android.app.Activity;
import android.app.AlertDialog;
import android.app.DatePickerDialog;
import android.app.Dialog;
import android.app.ProgressDialog;
import android.content.DialogInterface;
import android.os.Bundle;
import android.text.format.DateFormat;
import android.util.Log;
import android.view.KeyEvent;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;
import android.widget.DatePicker;
import android.widget.Spinner;
import android.widget.TextView;

public class Actualizar extends Activity {

	
	
	@Override
	public void onCreate(Bundle savedInstanceState){
		super.onCreate(savedInstanceState);		
		setContentView(R.layout.act_actualizar);
		
		Button act = (Button) findViewById(R.id.actualizar);
		act.setOnClickListener(mEvento);
		
		Calendar cal = GregorianCalendar.getInstance();
		java.text.DateFormat formato = android.text.format.DateFormat.getDateFormat(getApplicationContext());
		
		Button fi = (Button) findViewById(R.id.fecha_inicial);
		fi.setOnClickListener(mCamFecha);
		fi.setText(formato.format(cal.getTime()));
		fi.setTag(cal);
		
		cal = GregorianCalendar.getInstance();
		Button ff = (Button) findViewById(R.id.fecha_final);
		ff.setOnClickListener(mCamFecha);
		ff.setText(formato.format(cal.getTime()));
		ff.setTag(cal);
	}
	
	@Override
	public boolean onKeyDown(int keyCode,KeyEvent event){
		if(keyCode == KeyEvent.KEYCODE_SEARCH)
			return true;
		if(keyCode == KeyEvent.KEYCODE_HOME)
			return true;
		return super.onKeyDown(keyCode, event);
	}
	
	private OnClickListener mCamFecha = new OnClickListener() {
		
		public void onClick(View v) {
			showDialog(v.getId());
		}
	};
	
	@Override
	protected Dialog onCreateDialog(int id) {
		if(id > 0){
			Button fecha = (Button)findViewById(id);
			Calendar cal = (Calendar) fecha.getTag();
			if(id == R.id.fecha_inicial){
				return new DatePickerDialog(this,
						mDateSetListenerInicial,
						cal.getTime().getYear()+1900, cal.getTime().getMonth(), cal.getTime().getDate());
			}else{
				return new DatePickerDialog(this,
						mDateSetListenerFinal,
						cal.getTime().getYear()+1900, cal.getTime().getMonth(), cal.getTime().getDate());

			}
		}else{
			
		}
		return null;
	}
	
	private DatePickerDialog.OnDateSetListener mDateSetListenerInicial =
			new DatePickerDialog.OnDateSetListener() {

		public void onDateSet(DatePicker view, int year,
				int monthOfYear, int dayOfMonth) {					
			Button fecha = (Button)findViewById(R.id.fecha_inicial);
			Calendar cal = (Calendar) fecha.getTag();
			cal.set(year, monthOfYear, dayOfMonth);
			java.text.DateFormat formato = android.text.format.DateFormat.getDateFormat(getApplicationContext());			
			fecha.setText(formato.format(cal.getTime()));
		}


	};
	private DatePickerDialog.OnDateSetListener mDateSetListenerFinal =
			new DatePickerDialog.OnDateSetListener() {

		public void onDateSet(DatePicker view, int year,
				int monthOfYear, int dayOfMonth) {					
			Button fecha = (Button)findViewById(R.id.fecha_final);
			Calendar cal = (Calendar) fecha.getTag();
			cal.set(year, monthOfYear, dayOfMonth);
			java.text.DateFormat formato = android.text.format.DateFormat.getDateFormat(getApplicationContext());			
			fecha.setText(formato.format(cal.getTime()));
		}


	};
		
	
	private ProgressDialog pro= null;
	private OnClickListener mEvento = new OnClickListener() {
		
		public void onClick(View v) {
			pro = ProgressDialog.show(Actualizar.this, "", "Solicitando datos de jornada", true);
			pro.setOnDismissListener(new DialogInterface.OnDismissListener() {
				
				public void onDismiss(DialogInterface dialog) {
					//Actualizar.this.showDialog(0);
					
					AlertDialog.Builder dialogo = new AlertDialog.Builder(Actualizar.this);
					dialogo.setMessage("Los datos fueron actualizados con exito");
					dialogo.setPositiveButton("Ok", new DialogInterface.OnClickListener() {

						public void onClick(DialogInterface dialog, int which) {
							Actualizar.this.finish();

						}
					});
					try{
						dialogo.create();
					}catch(RuntimeException e){
						Log.e("", e.getMessage());
					}
					dialogo.show();
				}
			});
			
			Timer tmr = new Timer();
			tmr.schedule(new TimerTask() {
				
				@Override
				public void run() {
					pro.dismiss();
					
					
				}
			}, 5000);
		}
	};
		
	
}
