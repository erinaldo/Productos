package com.amesol.routelite.datos;

import android.graphics.Bitmap;

public class ItemEncuesta
{
	protected long id;
	protected byte[] rutaImagen;
	protected String titulo;
	protected String estatus;
	protected String fecha;
	protected String idString;
    protected int puntos;
	
	
   public ItemEncuesta()
   {
	   this.rutaImagen = null;
	   this.titulo = "";
	   this.estatus = "";
	   this.fecha = "";
	   this.idString = "";
       this.puntos = 0;
   }

	public ItemEncuesta(long id, byte[] rutaImagen, String titulo, String estatus, String fecha, String idString, int puntos)
	{
		super();
		this.id = id;
		this.rutaImagen = rutaImagen;
		this.titulo = titulo;
		this.estatus = estatus;
		this.fecha = fecha;
		this.idString = idString;
        this.puntos = puntos;
	}
	
	public long getId()
	{
		return id;
	}
	public void setId(long id)
	{
		this.id = id;
	}
	public byte[] getRutaImagen()
	{
		return rutaImagen;
	}
	public void setRutaImagen(byte[] rutaImagen)
	{
		this.rutaImagen = rutaImagen;
	}
	public String getTitulo()
	{
		return titulo;
	}
	public void setTitulo(String titulo)
	{
		this.titulo = titulo;
	}
	public String getEstatus()
	{
		return estatus;
	}
	public void setEstatus(String estatus)
	{
		this.estatus = estatus;
	}
	public String getFecha()
	{
		return fecha;
	}
	public void setFecha(String fecha)
	{
		this.fecha = fecha;
	}
	
	public String getIdString()
	{
		return idString;
	}
	public void setIdString(String idString){
		this.idString = idString;
	}

    public int getPuntos(){ return puntos; }
    public void setPuntos(int puntos){ this.puntos = puntos; }
}
