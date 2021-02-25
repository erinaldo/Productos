package com.amesol.routelite.datos;

import android.os.Parcel;
import android.os.Parcelable;

import com.amesol.routelite.datos.annotations.Campo;
import com.amesol.routelite.datos.annotations.Llave;
import com.amesol.routelite.datos.annotations.LlaveForanea;
import com.amesol.routelite.datos.annotations.TablaDef;
import com.amesol.routelite.datos.generales.Entidad;
import com.amesol.routelite.presentadores.parcelables.DatosAbnDetalle;

@TablaDef(orden=2)
public class ModuloMovDetalle extends Entidad implements Parcelable {

	@Llave()	
	public String ModuloMovDetalleClave;
	
	@LlaveForanea( nombreCampoForaneo="ModuloClave", tablaPadre=ModuloMov.class)
	public String ModuloClave;
	
	@LlaveForanea( nombreCampoForaneo="ModuloMovClave", tablaPadre=ModuloMov.class)
	public String ModuloMovClave;
	
	@Campo
	public String Nombre;
	
	@Campo
	public short TipoIndice;
	
	@Campo
	public int Orden;
	
	@Campo
	public short TipoTransProd;
	
	@Campo
	public short TipoPedido;
	
	@Campo
	public short TipoMovimiento;
	
	@Campo
	public short TipoEstado;
	
	@Campo
	public boolean Baja;
	
	public ModuloMovDetalle(Parcel in) {
		readFromParcel(in);
	}
	public ModuloMovDetalle() {	;}
	@Override
	public int describeContents() {
		// TODO Auto-generated method stub
		return 0;
	}

	@Override
	public void writeToParcel(Parcel arg0, int arg1) {
		arg0.writeString(ModuloMovDetalleClave);
		arg0.writeString(ModuloClave);
		arg0.writeString(ModuloMovClave);
		arg0.writeString(Nombre);
		arg0.writeInt(TipoIndice);
		arg0.writeInt(Orden);
		arg0.writeInt(TipoTransProd);
		arg0.writeInt(TipoPedido);
		arg0.writeInt(TipoMovimiento);
		arg0.writeInt(TipoEstado);
		arg0.writeByte((byte) (Baja ? 1 : 0)); 
	}
	
	private void readFromParcel(Parcel in) {		 
		this.ModuloMovDetalleClave= in.readString();
		this.ModuloClave = in.readString();
		this.ModuloMovClave = in.readString();
		this.Nombre = in.readString();
		this.TipoIndice=(short) in.readInt();
		this.Orden = (short)in.readInt();
		this.TipoTransProd =(short) in.readInt();
		this.TipoPedido  = (short)in.readInt();
		this.TipoMovimiento = (short)in.readInt();
		this.TipoEstado = (short)in.readInt();
		this.Baja = in.readByte() == 1;
	}
	
	
	@SuppressWarnings("rawtypes")
	public static final  Parcelable.Creator CREATOR =
		    	new Parcelable.Creator() {
		            public ModuloMovDetalle createFromParcel(Parcel in) {
		                return new ModuloMovDetalle(in);
		            }
		 
		           public ModuloMovDetalle[] newArray(int size) {
		                return new ModuloMovDetalle[size];
		            }
		        };
	
}
