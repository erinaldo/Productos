package com.amesol.routelite.utilerias;

import java.text.DecimalFormat;
import java.text.DecimalFormatSymbols;
import java.text.Normalizer;
import java.text.NumberFormat;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.Date;
import android.widget.SimpleCursorAdapter;
import android.widget.Spinner;

public class Generales
{

	public static Date getMinFecha() throws ParseException
	{
		return new SimpleDateFormat("dd/MM/yyyy").parse("01/01/1900");
	}

	public static Date getFechaActual()
	{
		Calendar c = Calendar.getInstance();
		int mYear = c.get(Calendar.YEAR);
		int mMonth = c.get(Calendar.MONTH);
		int mDay = c.get(Calendar.DAY_OF_MONTH);

		return new Date(mYear - 1900, mMonth, mDay);
	}

	public static Date getFechaHoraActual()
	{
		Calendar c = Calendar.getInstance();
		int mYear = c.get(Calendar.YEAR);
		int mMonth = c.get(Calendar.MONTH);
		int mDay = c.get(Calendar.DAY_OF_MONTH);
		int mHour = c.getTime().getHours();
		int mMinute = c.getTime().getMinutes();
		int mSecond = c.getTime().getSeconds();

		return new Date(mYear - 1900, mMonth, mDay, mHour, mMinute, mSecond);
	}

	public static String getFechaActualStr()
	{
		Calendar c = Calendar.getInstance();
		int mYear = c.get(Calendar.YEAR);
		int mMonth = c.get(Calendar.MONTH);
		int mDay = c.get(Calendar.DAY_OF_MONTH);

		Date fecha = new Date(mYear - 1900, mMonth, mDay);
		;

		SimpleDateFormat formato = new SimpleDateFormat("dd/MM/yyy");

		return formato.format(fecha);
	}

	public static String getFechaHoraActualStr(String formato)
	{
		Calendar c = Calendar.getInstance();
		int mYear = c.get(Calendar.YEAR);
		int mMonth = c.get(Calendar.MONTH);
		int mDay = c.get(Calendar.DAY_OF_MONTH);
		int mHour = c.getTime().getHours();
		int mMinute = c.getTime().getMinutes();
		int mSecond = c.getTime().getSeconds();

		Date fecha = new Date(mYear - 1900, mMonth, mDay, mHour, mMinute, mSecond);

		SimpleDateFormat sdf = new SimpleDateFormat(formato);

		return sdf.format(fecha);
	}

	public static String getUltimaHora(Date Fecha)
	{

		Fecha.setHours(23);
		Fecha.setMinutes(59);
		Fecha.setSeconds(59);
		SimpleDateFormat destino = new SimpleDateFormat("yyyy-MM-dd'T'HH:mm:ss");
		return destino.format(Fecha);
	}

	public static String getUltimaHora(Date Fecha, String formato)
	{

		Fecha.setHours(23);
		Fecha.setMinutes(59);
		Fecha.setSeconds(59);
		SimpleDateFormat destino = new SimpleDateFormat(formato);
		return destino.format(Fecha);
	}
	
	public static String getPrimerHora(Date Fecha)
	{

		Fecha.setHours(0);
		Fecha.setMinutes(0);
		Fecha.setSeconds(0);
		SimpleDateFormat destino = new SimpleDateFormat("yyyy-MM-dd'T'HH:mm:ss");
		return destino.format(Fecha);
	}

	public static String getFormatoDecimal(double numero, String formato)
	{
		DecimalFormatSymbols dfs = new DecimalFormatSymbols();
		dfs.setDecimalSeparator('.');
		dfs.setGroupingSeparator(',');
		NumberFormat numberFormat = new DecimalFormat(formato, dfs);
		return numberFormat.format(numero);
	}

	public static String getFormatoDecimal(double numero, int numDecimales)
	{
		DecimalFormatSymbols dfs = new DecimalFormatSymbols();
		dfs.setDecimalSeparator('.');
		dfs.setGroupingSeparator(',');
		String formato;
		if (numDecimales > 0)
		{
			formato = "0." + stringRepeat("0", numDecimales);
		}
		else
		{
			formato = "0";
		}
		NumberFormat numberFormat = new DecimalFormat(formato, dfs);
		return numberFormat.format(numero);
	}

	public static String getFormatoFecha(Date fecha, String formato)
	{
		SimpleDateFormat sdf = new SimpleDateFormat(formato);

		return sdf.format(fecha);
	}

	public static String getFechaHoraMilisegundos()
	{
		SimpleDateFormat sdf = new SimpleDateFormat("yyyyMMddHHmmss.SSS");
		String currentDateTimeString = sdf.format(new Date());

		return currentDateTimeString;
	}

	/*
	 * public static float getRound(float numero, int decimales){ int
	 * temp=(int)((numero*Math.pow(10,decimales)));
	 * 
	 * return (float) (((float)temp)/Math.pow(10,decimales)); }
	 */

	public static float getFloat(String numero, int decimales)
	{
		DecimalFormatSymbols dfs = new DecimalFormatSymbols();
		dfs.setDecimalSeparator('.');
		dfs.setGroupingSeparator(',');
		//generar la cadena con los decimales requeridos, por alguna razon la genera con 2 decimales menos, por eso se le suman 2
		DecimalFormat twoDForm = new DecimalFormat(postpad(decimales > 0 ? "#." : "#", decimales + 2, '#'), dfs);
		try
		{
			return twoDForm.parse(numero).floatValue();
		}
		catch (ParseException e)
		{
			// TODO Auto-generated catch block
			e.printStackTrace();
			return 0;
		}
	}

	public static float getRound(float numero, int decimales)
	{
		DecimalFormatSymbols dfs = new DecimalFormatSymbols();
		dfs.setDecimalSeparator('.');
		dfs.setGroupingSeparator(',');
		//generar la cadena con los decimales requeridos, por alguna razon la genera con 2 decimales menos, por eso se le suman 2
		DecimalFormat twoDForm = new DecimalFormat(postpad(decimales > 0 ? "#." : "#", decimales + 2, '#'), dfs);
		return Float.parseFloat(twoDForm.format(numero));
	}

	private static String postpad(String s, int length, char c)
	{
		int needed = length - s.length();
		if (needed <= 0)
		{
			return s;
		}
		char padding[] = new char[needed];
		java.util.Arrays.fill(padding, c);
		StringBuffer sb = new StringBuffer(length);
		sb.append(s);
		sb.append(padding);
		return sb.toString();
	}

	private static String prepad(String s, int length, char c)
	{
		int needed = length - s.length();
		if (needed <= 0)
		{
			return s;
		}
		char padding[] = new char[needed];
		java.util.Arrays.fill(padding, c);
		StringBuffer sb = new StringBuffer(length);
		sb.append(padding);
		sb.append(s);
		return sb.toString();
	}

	public static boolean isNumeric(String s)
	{
		if (s.matches("((-|\\+)?[0-9]+(\\.[0-9]+)?)+"))
		{
			return true;
		}
		else
		{
			return false;
		}
	}

	public static void SelectSpinnerItemByValue(Spinner spnr, long IdValue)
	{
		SimpleCursorAdapter adapter = (SimpleCursorAdapter) spnr.getAdapter();
		for (int position = 0; position < adapter.getCount(); position++)
		{
			if (adapter.getItemId(position) == IdValue)
			{
				spnr.setSelection(position);
				return;
			}
		}
	}

	public static String stringRepeat(String str, int times)
	{
		return new String(new char[times]).replace("\0", str);
	}

	public static boolean validarFecha(String fecha)
	{

		if (fecha == null)
			return false;

		SimpleDateFormat dateFormat = new SimpleDateFormat("dd/MM/yyyy");

		if (fecha.trim().length() != dateFormat.toPattern().length())
			return false;

		dateFormat.setLenient(false);

		try
		{
			dateFormat.parse(fecha.trim());
		}
		catch (ParseException pe)
		{
			return false;
		}
		return true;
	}

	public static boolean validarFechaActual(String fecha)
	{
		Calendar c = Calendar.getInstance();
		SimpleDateFormat dateFormat = new SimpleDateFormat("dd/MM/yyyy");
		String formattedDate2 = dateFormat.format(c.getTime());
		if (fecha.equals(formattedDate2))
			return true;
		else
			return false;
	}

    public static void remove1(StringBuilder input) {
        // Cadena de caracteres original a sustituir.
        String original = "áàäéèëíìïóòöúùuñÁÀÄÉÈËÍÌÏÓÒÖÚÙÜÑçÇ";
        // Cadena de caracteres ASCII que reemplazarán los originales.
        String ascii = "aaaeeeiiiooouuunAAAEEEIIIOOOUUUNcC";
        String output = input.toString();
        for (int i=0; i<original.length(); i++) {
            // Reemplazamos los caracteres especiales.
            output = output.replace(original.charAt(i), ascii.charAt(i));
        }//for i
        if (!input.toString().equals(output)){
            input.replace(0,input.length(),output);
        }

    }//remove1
    public static String remove2(String input) {
        // Descomposición canónica
        String normalized = Normalizer.normalize(input, Normalizer.Form.NFD);
        // Nos quedamos únicamente con los caracteres ASCII
        java.util.regex.Pattern pattern =  java.util.regex.Pattern.compile("\\p{ASCII}+");
        return pattern.matcher(normalized).replaceAll("");
    }//remove2

}
