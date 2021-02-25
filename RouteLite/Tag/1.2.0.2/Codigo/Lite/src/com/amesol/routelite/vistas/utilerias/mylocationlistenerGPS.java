package com.amesol.routelite.vistas.utilerias;

import android.location.Location;
import android.location.LocationListener;
import android.os.Bundle;


public class mylocationlistenerGPS implements LocationListener {
		
		public interface OnGPSLocationChangedListener
		{
		  public abstract void onLocationChanged(Location location);
		}
	

		
		private OnGPSLocationChangedListener onLocationChangedListener = null;
		public void setOnGPSLocationChangedListener(OnGPSLocationChangedListener l)
		{
			onLocationChangedListener = l;
		}
		

		
		@Override
	    public void onLocationChanged(Location location) {
 if (location != null) {
//	        	
//	        Log.d("LOCATION CHANGED", location.getLatitude() + "");
//	        Log.d("LOCATION CHANGED", location.getLongitude() + "");
//	        Toast.makeText(AmesolBarcodeActivity.this,
//	            location.getLatitude() + "" + location.getLongitude(),
//	            Toast.LENGTH_LONG).show();
		if(onLocationChangedListener != null)
		{
					onLocationChangedListener.onLocationChanged(location);
		}else
		{
			
		}
		
	        }
	        
			//location.setDescription(taskEditText.getText().toString());
		
		    //dismiss dialog
		    
	        
	    }
	    @Override
	    public void onProviderDisabled(String provider) {
	    }
	    @Override
	    public void onProviderEnabled(String provider) {
	    }
	    @Override
	    public void onStatusChanged(String provider, int status, Bundle extras) {
	    	
	    }
	
    }