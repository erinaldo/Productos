package com.amesol.routelite.actividades;

import java.util.Date;
import java.util.HashMap;
import java.util.concurrent.atomic.AtomicReference;

import com.amesol.routelite.actividades.Enumeradores.Folio;
import com.amesol.routelite.actividades.Enumeradores.Inventario.TipoEnvioMovimientosAutomaticos;
import com.amesol.routelite.datos.Impuesto;
import com.amesol.routelite.datos.Producto;
import com.amesol.routelite.datos.ProductoUnidad;
import com.amesol.routelite.datos.Ruta;
import com.amesol.routelite.datos.TransProd;
import com.amesol.routelite.datos.TransProdDetalle;
import com.amesol.routelite.datos.Usuario;
import com.amesol.routelite.datos.Vendedor;
import com.amesol.routelite.datos.utilerias.MOTConfiguracion;
import com.amesol.routelite.datos.basedatos.BDTerm;
import com.amesol.routelite.datos.basedatos.BDVend;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.basedatos.Consultas2;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.Enumeradores.TiposFasesDocto;
import com.amesol.routelite.presentadores.Enumeradores.TiposModulos;
import com.amesol.routelite.presentadores.Enumeradores.TiposMovimientos;
import com.amesol.routelite.presentadores.Enumeradores.TiposTransProd;
import com.amesol.routelite.utilerias.Generales;
import com.amesol.routelite.utilerias.KeyGen;

public class InventarioLotesKey{
	public String ProductoClave;
	public short TipoUnidad;
	public String Lote;

	public InventarioLotesKey(String productoClave, short tipoUnidad, String lote){
		ProductoClave = productoClave;
		TipoUnidad = tipoUnidad;
		Lote = lote;
	}
}
