package com.amesol.routelite.utilerias;

import android.util.Log;

public class Logger {
	/**
	 * Display an error in the logcat.
	 * @param tag - Tag to show.
	 * @param msg - The message to display.
	 */
	public static void Error(String tag, String msg) {
		if (Constants.DEBUGGER_MODE){
			Log.e(tag, msg);
		}
	}
	
	public static void Error(Throwable ex) {
		if (Constants.DEBUGGER_MODE){
			ex.printStackTrace();
		}
	}
	
	/**
	 * Display an error in the logcat.
	 * @param tag - Tag to show.
	 * @param msg - The message to display.
	 */
	public static void Warning(String tag, String msg){
		if (Constants.DEBUGGER_MODE){
			Log.w(tag, msg);
		}
	}	
	
	/**
	 * Display an info in the logcat.
	 * @param tag - Tag to show.
	 * @param msg - The message to display.
	 */
	public static void Info(String tag, String msg){
		if (Constants.DEBUGGER_MODE){
			Log.i(tag, msg);
		}
	}
}
