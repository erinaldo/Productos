package com.amesol.routelite.datos;

import com.amesol.routelite.datos.annotations.Campo;
import com.amesol.routelite.datos.annotations.Llave;
import com.amesol.routelite.datos.annotations.TablaDef;
import com.amesol.routelite.datos.generales.Entidad;
@TablaDef
public class ModuloTerm extends Entidad{
@Llave 
public String ModuloClave;
@Campo
public String Nombre;
@Campo
public short TipoIndice;
@Campo
public int Orden;
@Campo
public short Tipo;


}
