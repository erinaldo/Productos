package com.duxstar.dacza.utilerias;

import java.util.UUID;

public class KeyGen {

    public static String getId(){
        int length = 8;
        String idResult = "";

        while (idResult.length() < length)		{
            idResult += Integer.toHexString(UUID.randomUUID().hashCode());
        }

        return idResult.substring(0, length).toUpperCase();
    }
}