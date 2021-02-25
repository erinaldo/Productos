package com.amesol.routelite.vistas.generico;

import java.lang.reflect.Method;

import android.app.ProgressDialog;
import android.content.Context;
import android.view.KeyEvent;

public class DialogoProgreso extends ProgressDialog
{

	private Context _context;

	public DialogoProgreso(Context context, int theme)
	{
		super(context, theme);
		_context = context;
		// TODO Auto-generated constructor stub
	}

	public DialogoProgreso(Context context)
	{
		super(context);
		_context = context;
		// TODO Auto-generated constructor stub
	}

	@Override
	public boolean onKeyDown(int keyCode, KeyEvent event)
	{
		switch (keyCode)
		{
			case KeyEvent.KEYCODE_HOME:
			case KeyEvent.KEYCODE_CALL:
				return true;
		}
		return super.onKeyDown(keyCode, event);
	}

	@Override
	public void onWindowFocusChanged(boolean hasFocus) //bloquear barra del sistema
	{
		try
		{
			if (!hasFocus)
			{
				Object service = _context.getSystemService("statusbar");
				Class<?> statusbarManager = Class.forName("android.app.StatusBarManager");
				Method collapse = statusbarManager.getMethod("collapse");
				collapse.setAccessible(true);
				collapse.invoke(service);

				/*
				 * Method collapse = statusbarManager.getMethod("disable",
				 * Integer.TYPE); collapse .setAccessible(true);
				 * collapse.invoke(service, new Integer(0x00010000));
				 */
			}
		}
		catch (Exception ex)
		{
			ex.printStackTrace();
		}
	}
}
