package com.amesol.routelite.datos;

import com.amesol.routelite.datos.annotations.Campo;
import com.amesol.routelite.datos.annotations.Llave;
import com.amesol.routelite.datos.annotations.TablaDef;
import com.amesol.routelite.datos.generales.Entidad;

@TablaDef
public class RECNota extends Entidad{
@Llave
public String RECId;

@Llave
public short Tipo;

@Llave
public String RENId;

@Campo 
public int Orden;

@Campo
public String Texto;

@Campo
public int RenglonBlanco;

@Campo 
public short TipoAlineacion;

@Campo
public short TipoLetra;
}
