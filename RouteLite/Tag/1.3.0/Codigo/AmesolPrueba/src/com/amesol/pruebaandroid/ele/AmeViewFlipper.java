package com.amesol.pruebaandroid.ele;

import android.content.Context;
import android.util.AttributeSet;
import android.widget.ViewFlipper;

public class AmeViewFlipper extends ViewFlipper {

	public AmeViewFlipper(Context context, AttributeSet attrs) {
		super(context, attrs);
	}

	@Override
	protected void onDetachedFromWindow() {
	    try {
	        super.onDetachedFromWindow();
	    }
	    catch (IllegalArgumentException e) {
	        stopFlipping();
	    }
	}
	

}
