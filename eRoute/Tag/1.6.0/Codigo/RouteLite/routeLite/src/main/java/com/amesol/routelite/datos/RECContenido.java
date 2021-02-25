package com.amesol.routelite.datos;

import com.amesol.routelite.datos.annotations.Campo;
import com.amesol.routelite.datos.annotations.Llave;
import com.amesol.routelite.datos.annotations.TablaDef;
import com.amesol.routelite.datos.generales.Entidad;

@TablaDef
public class RECContenido extends Entidad{
@Llave
public String RECId;

@Llave
public String REOId;

@Campo
public String CORId;

@Campo
public String COTId;

@Campo
public String COCId;

@Campo
public int OrdenX;

@Campo
public int OrdenY;

@Campo
public short TipoEtiqueta;

@Campo 
public short TipoSeparador;

@Campo
public short TipoLetra;
}
