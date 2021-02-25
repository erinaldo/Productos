package com.amesol.routelite.datos;

import com.amesol.routelite.datos.annotations.Campo;
import com.amesol.routelite.datos.annotations.Llave;
import com.amesol.routelite.datos.annotations.TablaDef;
import com.amesol.routelite.datos.generales.Entidad;

@TablaDef
public class COTCampo extends Entidad{
@Llave 
public String CORId;

@Llave
public String COTId;

@Llave
public String COCId;

@Campo 
public String Descripcion;

@Campo
public String Nombre;

@Campo
public short TipoCampo;
}
