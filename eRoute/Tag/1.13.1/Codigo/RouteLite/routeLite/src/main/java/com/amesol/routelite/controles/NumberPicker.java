/*
 * Copyright 2008 The Android Open Source Project
 * Copyright 2011-2012 Michael Novak <michael.novakjr@gmail.com>.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
package com.amesol.routelite.controles;


import android.content.Context;
import android.content.res.TypedArray;
import android.os.Bundle;
import android.os.Handler;
import android.os.Parcelable;
import android.text.InputFilter;
import android.text.InputType;
import android.text.Spanned;
import android.text.method.NumberKeyListener;
import android.util.AttributeSet;
import android.util.Log;
import android.view.KeyEvent;
import android.view.LayoutInflater;
import android.view.View;
import android.view.View.OnClickListener;
import android.view.View.OnFocusChangeListener;
import android.view.View.OnLongClickListener;
import android.widget.EditText;
import android.widget.LinearLayout;
import android.widget.TextView;
import android.widget.TextView.OnEditorActionListener;

import com.amesol.routelite.R;

/**
 * This class has been pulled from the Android platform source code, its an internal widget that hasn't been
 * made public so its included in the project in this fashion for use with the preferences screen; I have made
 * a few slight modifications to the code here, I simply put a MAX and MIN default in the code but these values
 * can still be set publicly by calling code.
 *
 * @author Google
 */
public class NumberPicker extends LinearLayout implements OnClickListener,
        OnEditorActionListener, OnFocusChangeListener, OnLongClickListener {

    private static final String TAG = "NumberPicker";
    private static final int DEFAULT_MAX = 200;
    private static final int DEFAULT_MIN = 0;
    private static final int DEFAULT_VALUE = 0;
    private static final boolean DEFAULT_WRAP = true;

    public interface OnChangedListener {
        void onChanged(NumberPicker picker, int oldVal, int newVal);
    }

    public interface Formatter {
        String toString(int value);
    }

    /*
     * Use a custom NumberPicker formatting callback to use two-digit
     * minutes strings like "01".  Keeping a static formatter etc. is the
     * most efficient way to do this; it avoids creating temporary objects
     * on every call to format().
     */
    public static final NumberPicker.Formatter TWO_DIGIT_FORMATTER =
            new NumberPicker.Formatter() {
                final StringBuilder mBuilder = new StringBuilder();
                final java.util.Formatter mFmt = new java.util.Formatter(mBuilder);
                final Object[] mArgs = new Object[1];
                public String toString(int value) {
                    mArgs[0] = value;
                    mBuilder.delete(0, mBuilder.length());
                    mFmt.format("%02d", mArgs);
                    return mFmt.toString();
                }
            };

    private final Handler mHandler;
    private final Runnable mRunnable = new Runnable() {
        public void run() {
            if (mIncrement) {
                changeCurrent(mCurrent + mStep);
                mHandler.postDelayed(this, mSpeed);
            } else if (mDecrement) {
                changeCurrent(mCurrent - mStep);
                mHandler.postDelayed(this, mSpeed);
            }
        }
    };

    private final EditText mText;
    private final InputFilter mNumberInputFilter;

    private String[] mDisplayedValues;
    protected int mStart;
    protected int mEnd;
    protected int mCurrent;
    protected int mPrevious;
    protected OnChangedListener mListener;
    protected Formatter mFormatter;
    protected boolean mWrap;
    protected long mSpeed = 300;
    private int mDecimal;
    private int mStep = 1;

    private boolean mIncrement;
    private boolean mDecrement;
    
    protected boolean mPreguntar = false;
    protected boolean mPermiteCero = true;

    public NumberPicker(Context context) {
        this(context, null);
    }

    public NumberPicker(Context context, AttributeSet attrs) {
        this(context, attrs, 0);
    }

    @SuppressWarnings({"UnusedDeclaration"})
    public NumberPicker(Context context, AttributeSet attrs, int defStyle) {
        super(context, attrs);
        
        TypedArray a = context.obtainStyledAttributes( attrs, R.styleable.numberpicker );
        mStart = a.getInt( R.styleable.numberpicker_startRange, DEFAULT_MIN );
        mEnd = a.getInt( R.styleable.numberpicker_endRange, DEFAULT_MAX );
        mWrap = a.getBoolean( R.styleable.numberpicker_wrap, DEFAULT_WRAP );
        mCurrent = 	a.getInt( R.styleable.numberpicker_defaultValue, DEFAULT_VALUE );
        mCurrent = Math.max( mStart, Math.min( mCurrent, mEnd ) );
    	int tmpDecimal =  a.getInt( R.styleable.numberpicker_decimal, DEFAULT_VALUE );
    	mStep    =  a.getInt( R.styleable.numberpicker_step, 1 );
    	a.recycle();

        
        setOrientation(VERTICAL);
        LayoutInflater inflater = (LayoutInflater) context.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
        inflater.inflate(R.layout.number_picker, this, true);
        mHandler = new Handler();
        InputFilter inputFilter = new NumberPickerInputFilter();
        mNumberInputFilter = new NumberRangeKeyListener();
        mIncrementButton = (NumberPickerButton) findViewById(R.id.increment);
        mIncrementButton.setOnClickListener(this);
        mIncrementButton.setOnLongClickListener(this);
        mIncrementButton.setNumberPicker(this);
        mDecrementButton = (NumberPickerButton) findViewById(R.id.decrement);
        mDecrementButton.setOnClickListener(this);
        mDecrementButton.setOnLongClickListener(this);
        mDecrementButton.setNumberPicker(this);

        mText = (EditText) findViewById(R.id.timepicker_input);
        
      	// Set the id to 'nothing', so that the framework
       	// doesn't try to restore/save it.
        mText.setId( NO_ID );
        
        Log.d(TAG, "mText id: " + mText.getId() );
        
        mText.setOnFocusChangeListener(this);
        mText.setOnEditorActionListener(this);
        mText.setFilters(new InputFilter[] {inputFilter});
        //mText.setRawInputType(InputType.TYPE_CLASS_NUMBER);
        	mText.setInputType(InputType.TYPE_CLASS_NUMBER | InputType.TYPE_NUMBER_FLAG_DECIMAL );

        
        	mText.setSelectAllOnFocus(true);
        
        // Following needs to be called after text control has been created.
        setDecimal(tmpDecimal);
        
        if (!isEnabled()) {
            setEnabled(false);
        }
        
        //mText.setText( "" + mCurrent );

    }

    @Override
    public void setEnabled(boolean enabled) {
        super.setEnabled(enabled);
        mIncrementButton.setEnabled(enabled);
        mDecrementButton.setEnabled(enabled);
        mText.setEnabled(enabled);
    }

    public void setOnChangeListener(OnChangedListener listener) {
        mListener = listener;
    }

    public void setFormatter(Formatter formatter) {
        mFormatter = formatter;
    }

    /**
     * Set the range of numbers allowed for the number picker. The current
     * value will be automatically set to the start.
     *
     * @param start the start of the range (inclusive)
     * @param end the end of the range (inclusive)
     */
    public void setRange(int start, int end) {
        mStart = start;
        mEnd = end;
        mCurrent = start;
        updateView();
    }
    
    /**
     * Rango aceptado en el picker. Deben estar 
     * asignada antes la propiedad setDecimal()
     * y setStep() para que funcione correctamente.
     *
     * @param start the start of the range (inclusive)
     * @param end the end of the range (inclusive)
     */
    public void setRangeDecimal(float start, float end){
    	mStart = (int) (start * mStep);
    	mEnd = (int) (end * mStep);
    	mCurrent = mStart;
    	updateView();
    }

    /**
     * Specify if numbers should wrap after the edge has been reached.
     *
     * @param wrap values
     */
    public void setWrap( boolean wrap ) {
        mWrap = wrap;
    }

    /**
     * Set the range of numbers allowed for the number picker. The current
     * value will be automatically set to the start. Also provide a mapping
     * for values used to display to the user.
     *
     * @param start the start of the range (inclusive)
     * @param end the end of the range (inclusive)
     * @param displayedValues the values displayed to the user.
     */
    public void setRange(int start, int end, String[] displayedValues) {
        mDisplayedValues = displayedValues;
        mStart = start;
        mEnd = end;
        mCurrent = start;
        updateView();
    }

    public void setCurrent(int current) {
        if (mEnd < current) //return; //throw new IllegalArgumentException("Current value cannot be greater than the range end.");
        	mCurrent = mEnd;
        else
        	mCurrent = current;
        updateView();
    }
    
    public void setCurrentDecimal(float current){
    	float number = current * mStep;
    	
    	if (mEnd < number) //return; //throw new IllegalArgumentException("Current value cannot be greater than the range end.");
    		mCurrent = mEnd;
    	else
    		mCurrent = (int) number;
        updateView();
    }

    public void setCurrentAndNotify(int current) {
        mCurrent = current;
        notifyChange();
        updateView();
    }


    /**
     * The speed (in milliseconds) at which the numbers will scroll
     * when the the +/- buttons are longpressed. Default is 300ms.
     */
    public void setSpeed(long speed) {
        mSpeed = speed;
    }

    public void onClick(View v) {
        validateInput(mText);
        if (!mText.hasFocus()) mText.requestFocus();

        // now perform the increment/decrement
        if (R.id.increment == v.getId()) {
            changeCurrent(mCurrent + mStep);
        } else if (R.id.decrement == v.getId()) {
            changeCurrent(mCurrent - mStep);
        }
    }

    protected String formatNumber(int value) {
        return (mFormatter != null)
                ? mFormatter.toString(value)
                : String.valueOf(value);
    }

    public float getCurrentDecimal(){
    	String number = (mFormatter != null)
                ? mFormatter.toString(mCurrent)
                : String.valueOf(mCurrent);
    	return Float.parseFloat(number);
    }
    
    protected void changeCurrent(int current) {
        // Wrap around the values if we go past the start or end
        if (current > mEnd) {
            current = mWrap ? mStart : mEnd;
        } else if (current < mStart) {
            current = mWrap ? mEnd : mStart;
        }
        
        if(current <= 0){
			current = 0;
			if(mPreguntar)
				listener.OnZeroReached(this);
		}
        
        mPrevious = mCurrent;
        mCurrent = current;

        notifyChange();
        updateView();
    }

    protected void notifyChange() {
        if (mListener != null) {
            mListener.onChanged(this, mPrevious, mCurrent);
        }
    }

    protected void updateView() {

        /* If we don't have displayed values then use the
         * current number else find the correct value in the
         * displayed values for the current number.
         */
        if (mDisplayedValues == null) {
            if(mFormatter == null)
            	mText.setText(formatNumber(mCurrent));
            else
            	mText.setText(mFormatter.toString(mCurrent));
        } else {
            mText.setText(mDisplayedValues[mCurrent - mStart]);
        }
        mText.setSelection(mText.getText().length());
    }
    
    protected void updateView(int value) {

        /* If we don't have displayed values then use the
         * current number else find the correct value in the
         * displayed values for the current number.
         */
        if (mDisplayedValues == null) {
            if(mFormatter == null)
            	mText.setText(formatNumber(value));
            else
            	mText.setText(mFormatter.toString(value));
        } else {
            mText.setText(mDisplayedValues[value - mStart]);
        }
        mText.setSelection(mText.getText().length());
    }

    private void validateCurrentView(CharSequence str) {
        int val;
        if(mDecimal > 0)
        	val = (int) (Float.parseFloat(str.toString()) * mStep);
        else
        	val = getSelectedPos(str.toString());
        if ((val >= mStart) && (val <= mEnd)) {
            if (mCurrent != val) {
                mPrevious = mCurrent;
                mCurrent = val;
                notifyChange();
            }
        }else{ //el valor es mayor que el limite, asignar al actual el limite y notificar el cambio
        	mPrevious = val;
        	mCurrent = mEnd;
        	notifyChange();
        }
        updateView();
    }

    public void onFocusChange(View v, boolean hasFocus) {

        /* When focus is lost check that the text field
         * has valid values.
         */
    	EditText text = (EditText) v;
    	//float original = (float)mCurrent / mStep;
    	//original = Float.parseFloat(text.getText().toString().equals("") ? String.valueOf(original) : text.getText().toString());
    	
        if (!hasFocus) {
            validateInput(v);
            
            float original = Float.parseFloat(text.getText().toString());
            if(mDecimal > 0 && (original <= ((float)mEnd / mStep)))
    			setCurrentDecimal(original);
            if(mIncrementButton.getVisibility() == View.GONE)
            	notifyChange();
        }else{
        	text.selectAll();
        }
    }

    
    /**
     * This callback triggers when a return is pressed, but not if 
     * you leave the keyboard without a return. Perhaps there is a better
     * callback to use (on key input?).
     */
    //@Override
    public boolean onEditorAction(TextView v, int actionId, KeyEvent event) {
        if (v == mText) {
    		Log.d(TAG, "onEditorAction() called.");
    		//float original = (float)mStart / mStep;
    		//original = Float.parseFloat(v.getText().toString().equals("") ? String.valueOf(original) : v.getText().toString());
    		//float original = Float.parseFloat(v.getText().toString());
            validateInput(v);
            
            float original = Float.parseFloat(v.getText().toString());
            
            // Update the internal int value after change in the edit field.
    		CharSequence val = v.getText();
    		if(mDecimal > 0 && (original <= ((float)mEnd / mStep)))
    			setCurrentDecimal(original);
    		else
    			changeCurrent(getSelectedPos( val.toString() ));
            
    		if(enter != null)
    			enter.OnEnterPressed();
            // Don't return true, let Android handle the soft keyboard
        }
        return false;
    }

    
    private void validateInput(View v) {
        String str = String.valueOf(((TextView) v).getText());
        if ("".equals(str)) {
        	mPrevious = 1; 
            // Restore to the old value as we don't allow empty values
            updateView(mStart);
        } else {

            // Check the new value and ensure it's in range
            validateCurrentView(str);
        }
    }

    /**
     * We start the long click here but rely on the {@link NumberPickerButton}
     * to inform us when the long click has ended.
     */
    public boolean onLongClick(View v) {

        /* The text view may still have focus so clear it's focus which will
         * trigger the on focus changed and any typed values to be pulled.
         */
        mText.clearFocus();
        mText.requestFocus();
        if (R.id.increment == v.getId()) {
            mIncrement = true;
            mHandler.post(mRunnable);
        } else if (R.id.decrement == v.getId()) {
            mDecrement = true;
            mHandler.post(mRunnable);
        }

        return true;
    }

    public void cancelIncrement() {
        mIncrement = false;
    }

    public void cancelDecrement() {
        mDecrement = false;
    }

    private static final char[] DIGIT_CHARACTERS = new char[] {
            '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'
    };
    
    private static final char[] DIGIT_CHARACTERS_POINT = new char[] {
        '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '.'
    };


    private NumberPickerButton mIncrementButton;
    private NumberPickerButton mDecrementButton;

    private class NumberPickerInputFilter implements InputFilter {
        public CharSequence filter(CharSequence source, int start, int end,
                                   Spanned dest, int dstart, int dend) {
            if (mDisplayedValues == null) {
                return mNumberInputFilter.filter(source, start, end, dest, dstart, dend);
            }
            CharSequence filtered = String.valueOf(source.subSequence(start, end));
            String result = String.valueOf(dest.subSequence(0, dstart))
                    + filtered
                    + dest.subSequence(dend, dest.length());
            String str = String.valueOf(result).toLowerCase();
            for (String val : mDisplayedValues) {
                val = val.toLowerCase();
                if (val.startsWith(str)) {
                    return filtered;
                }
            }
            return "";
        }
    }

    private class NumberRangeKeyListener extends NumberKeyListener {

        // XXX This doesn't allow for range limits when controlled by a
        // soft input method!
        public int getInputType() {
        	return InputType.TYPE_CLASS_NUMBER | InputType.TYPE_NUMBER_FLAG_DECIMAL;        		
        }

        @Override
        protected char[] getAcceptedChars() {
        	if ( NumberPicker.this.mDecimal > 0 ) {
                return DIGIT_CHARACTERS_POINT;
        	} else {
                return DIGIT_CHARACTERS;
        	}
       }

        private int countDots(String str ) {
        	int count = 0;
        	char[] arr = str.toCharArray();

        	for ( int i = 0; i < arr.length; ++i ) {
        		if ( arr[i] == '.' ) count += 1;
        	}
        	
        	return count;
        }

        @Override
        public CharSequence filter(CharSequence source, int start, int end,
                                   Spanned dest, int dstart, int dend) {

            CharSequence filtered = super.filter(source, start, end, dest, dstart, dend);
            if (filtered == null) {
                filtered = source.subSequence(start, end);
            }

            String result = String.valueOf(dest.subSequence(0, dstart))
                    + filtered
                    + dest.subSequence(dend, dest.length());

            if ("".equals(result)) {
                return result;
            }
                        
            // Disallow more than one dot in the result
            int dot_count = countDots( result );
        	Log.d(TAG, "Result: " + result + "; Dot count: " + dot_count);
            if ( mDecimal == 0 ) {
            	// no dot at all
            	if ( dot_count > 0 ) return "";
            } else {
            	// at most one dot
            	if ( dot_count > 1 ) {
                	Log.d(TAG, "Too many dots!");
            		return "";
            	}
            }
            
            int val = getSelectedPos(result);

            /* Ensure the user can't type in a value greater
             * than the max allowed. We have to allow less than min
             * as the user might want to delete some numbers
             * and then type a new number.
             */
            if (val > mEnd) {
                return "";
            } else {
            	setCurrentNoUpdate(val); //fix para cambiar el valor actual al estar escribiendo con el teclado
                return filtered;
            }
        }
        
        private void setCurrentNoUpdate(int val){        	
        	int dot_count = countDots(mText.getText().toString()); //validar si existe punto decimal
        	if(dot_count <= 0){
        		if(mDecimal > 0)
        			val *= mStep;
        	}
        	if(mPermiteCero)
        		mCurrent = val;
        	else
        		if(val > 0)
        			mCurrent = val;
        }
    }

    private int getSelectedPos(String str) {
        if (mDisplayedValues == null) {
        	// Remove point, if any, from the string
        	String tmp = str.replaceAll("[.]", "");
        	try {
        		return Integer.parseInt(tmp);
        	} catch( NumberFormatException e) {
        		// This apparently happens on empty strings also
        		// return an invalid value
        		return mEnd + 1;
        	}
        } else {
            for (int i = 0; i < mDisplayedValues.length; i++) {

                /* Don't force the user to type in jan when ja will do */
                str = str.toLowerCase();
                if (mDisplayedValues[i].toLowerCase().startsWith(str)) {
                    return mStart + i;
                }
            }

            /* The user might have typed in a number into the month field i.e.
             * 10 instead of OCT so support that too.
             */
            try {
                return Integer.parseInt(str);
            } catch (NumberFormatException e) {

                /* Ignore as if it's not a number we don't care */
            }
        }
        return mStart;
    }

    /**
     * @return the current value.
     */
    public int getCurrent() {
        return mCurrent;
    }
    
    
    ////////////////////////////////////////
    // Decimal point and step support
    ////////////////////////////////////////

    private class DecimalFormatter implements Formatter {
        final StringBuilder mBuilder = new StringBuilder();
        final java.util.Formatter mFmt = new java.util.Formatter(mBuilder);
        final Object[] mArgs = new Object[2];
        
        private int step;
        private String format;
    	
    	public DecimalFormatter( int decimal_pos) {
    		// Create a new formatting string
    		format = "%d.%0" + decimal_pos + "d";
    		
        	step = 10;
        	
        	// Math.pow() does doubles, I want to keep it 
        	// strictly int.
        	for ( int i = 1; i < decimal_pos; ++ i) {
        		step *= 10;
        	}
    	}
    	
        public String toString(int value) {
            mArgs[0] = value/step;
            mArgs[1] = value % step;
            mBuilder.delete(0, mBuilder.length());
            mFmt.format( format , mArgs);
            
            return mFmt.toString();
        }
    }

    
    /**
     * Specify on which position decimal point should be displayed.
     * 
     * If value is zero (default), no point will be displayed
     * 
     * @param value
     */
    public void setDecimal(int value) {
    	if ( value < 0 ) return;
    	
    	mDecimal = value;
    	
    	if ( value == 0 ) {
    		setFormatter( null ) ;
    	} else {
    		setFormatter( new DecimalFormatter( value) ) ;
    	}
    	
    	updateView();
    }    

    
    public void setStep( int value ) {
    	if ( value < 1 ) return;
    	Log.d( TAG, "step new value: " + value );
    	
    	if(mDecimal > 0){
    		String valorDecimal = String.format("%-" + (mDecimal + 1) + "s", String.valueOf(value));
    		valorDecimal = valorDecimal.replace(" ", "0");
    		mStep = Integer.parseInt(valorDecimal);
    	}
    	else
    		mStep = value;
    }

    
    /**
     * Retrieve the current value as displayed on-screen.
     * 
     * The decimal point, if any, will be present in the result.
     */
    public String getString() {
    	return formatNumber(mCurrent);
    }

    
    public double getDouble() {
    	String val = getString();
    	try {
    		return Double.parseDouble( val );
    	} catch( NumberFormatException e ) {
    		Log.d(TAG, "Error converting '" + val + "' return zero from getDouble().");
    		return 0.0;
    	}
    }
    
    /**
     * Overridden to save instance state when device orientation changes.
     * 
     * This method is called automatically if you assign an id to the 
     * widget using the {@link #setId(int)} method. 
     */
    @Override
    protected Parcelable onSaveInstanceState() {
    		Parcelable p = super.onSaveInstanceState();
            Bundle bundle = new Bundle();
            
            Log.d(TAG, "Have id: " + getId() );
  
            bundle.putInt("MSTART", mStart);
            bundle.putInt("MEND", mEnd);
            bundle.putInt("MCURRENT", mCurrent);
            bundle.putInt("MPREVIOUS", mPrevious);
            bundle.putBoolean("MWRAP", mWrap);
            bundle.putLong("MSPEED", mSpeed);
            bundle.putInt("MDECIMAL", mDecimal);
            bundle.putInt("MSTEP", mStep);
            bundle.putParcelable("SUPER", p);

            // Other members of this class don't need to be saved.
            return bundle;
    }

    
    /**
     * Overridden to restore instance state when device orientation changes. 
     * 
     * This method is called automatically if you assign an id to the widget
     * widget using the {@link #setId(int)} method. 
     */
    @Override
    protected void onRestoreInstanceState(Parcelable parcel) {
    	Bundle bundle = (Bundle) parcel;

    	mStart    = bundle.getInt("MSTART");
    	mEnd      = bundle.getInt("MEND");
    	mPrevious = bundle.getInt("MPREVIOUS");
    	mWrap     = bundle.getBoolean("MWRAP");
    	mSpeed    = bundle.getLong("MSPEED");
    	mStep     = bundle.getInt("MSTEP");
    	
    	// setCurrent() will call updateView(), which will properly 
    	// set the editText field.
    	setCurrent(bundle.getInt("MCURRENT"));
    	setDecimal( bundle.getInt("MDECIMAL") );
    	
        Log.d(TAG, "Restored for id: " + getId() + "; mCurrent: " + mCurrent );
    	super.onRestoreInstanceState(bundle.getParcelable("SUPER"));
    }
    
    public void ocultarBotones(boolean ocultar){
    	if(ocultar){
    		mIncrementButton.setVisibility(View.GONE);
            mDecrementButton.setVisibility(View.GONE);	
    	}else{
    		mIncrementButton.setVisibility(View.VISIBLE);
            mDecrementButton.setVisibility(View.VISIBLE);
    	}
    }
    
    /*public void setMediumTextSize(){
    	mText.setTextAppearance(getContext(), android.R.attr.textAppearanceMedium);
    }*/
    
    public void setEditeTextBackgroundToNull(){
    	mText.setBackgroundResource(android.R.drawable.edit_text);
    	//mText.setBackgroundDrawable(null);
    }
    
    public void setTextSize(float size){
    	mText.setTextSize(size);
    }
    
    //Listener utilizado en el cuadro de dialogo para cerrar al presionar 'enter'
    private OnEnterListener enter = null;
    public interface OnEnterListener{
    	void OnEnterPressed();
    }
    
    public void setOnEnterListener(OnEnterListener l){
    	enter = l;
    }
    
  //Listener para saber cuando llego a cero
    private OnZeroListener listener = null;
    public interface OnZeroListener{
    	void OnZeroReached(NumberPicker picker);
    }
    
    public void setOnZeroListener(OnZeroListener l){
    	listener = l;
    	mPreguntar = true;
    }
    
    public void setPermiteCero(boolean permitir){
    	mPermiteCero = permitir;
    }
    
}
