package com.amesol.routelite.presentadores.interfaces;

import com.amesol.routelite.datos.Cliente;
import com.amesol.routelite.datos.Dia;
import com.amesol.routelite.datos.TransProd;
import com.amesol.routelite.presentadores.IVista;

public interface IAplicacionPromocion extends IVista {
	public void mostrarProductosPromocion();
	public void setFolioRazonSocial(Cliente oCliente, TransProd oTRP);
	public void setErrorInventario(boolean ErrorInventario);
	//public void setDiaClave(Dia oDia);
	
	/*public Runnable getHiloPausa();
	public void setHiloPausa(Runnable hiloPausa);
	public Thread getPregunta();
	public void setPregunta(Thread pregunta);
	public Object getmPausa();
	public void setmPausa(Object mPausa);
	public boolean getContinuar();
	public void setContinuar(boolean bcontinuar);
		public boolean getTerminar();*/
	//public boolean getAplicarPromo();
	//public void setAplicarPromo(boolean aplicarPromo);

	//public void setTerminar(boolean bterminar);
	//public void mostrarPreguntaOpcional(String Mensaje);
}
