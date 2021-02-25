package com.amesol.routelite.utilerias;

public class Log
{
	public static void e(String tag, String msg)
	{
		if (Constants.DEBUGGER_MODE)
		{
			android.util.Log.e(tag, msg);
		}
	}
	
	public static void e(Throwable ex)
	{
		if (Constants.DEBUGGER_MODE)
		{
			ex.printStackTrace();
		}
	}
	
	public static void w(String tag, String msg)
	{
		if (Constants.DEBUGGER_MODE)
		{
			android.util.Log.w(tag, msg);
		}
	}
	
	public static void i(String tag, String msg)
	{
		if (Constants.DEBUGGER_MODE)
		{
			android.util.Log.i(tag, msg);
		}
	}	
}
