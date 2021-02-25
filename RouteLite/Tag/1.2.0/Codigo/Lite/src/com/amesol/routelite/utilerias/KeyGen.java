package com.amesol.routelite.utilerias;

import java.util.UUID;

public class KeyGen {

	public static String getId(){
		int length = 16;
		String idResult = "";
		
		while (idResult.length() < length)		{
			idResult += Integer.toHexString(UUID.randomUUID().hashCode());
		}
		
		return idResult.substring(0, length).toUpperCase();		
	}
}
