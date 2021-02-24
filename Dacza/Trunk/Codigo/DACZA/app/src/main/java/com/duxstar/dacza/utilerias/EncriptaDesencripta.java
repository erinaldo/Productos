package com.duxstar.dacza.utilerias;

public class EncriptaDesencripta {

	public static String encripta(String texto){
		StringBuffer encripta = new StringBuffer();
		for(int i = 0; i< texto.length(); i++){
			char c = texto.charAt(i);			
			if(c < 128) c= (char) (c+128);
			else c=(char) (c-128);
			encripta.append(c);
			
		}
		return encripta.toString();
	}
}
