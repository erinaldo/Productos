package com.amesol.routelite.presentadores.parcelables;

import android.os.Parcel;
import android.os.Parcelable;

public class DatosAbnDetalle implements Parcelable
{	
	private int tipoPago;
	private String monedaId;
	private float importe;
	private int tipoBanco;
	private String referencia;
	private long fechaCheque;
    private String observaciones;
	
	public DatosAbnDetalle() { ; };
	
	public DatosAbnDetalle(Parcel in) {
		readFromParcel(in);
	}
	
	private void readFromParcel(Parcel in) {
		 
		// We just need to read back each
		// field in the order that it was
		// written to the parcel
		this.tipoPago= in.readInt();
		this.monedaId= in.readString();
		this.importe= in.readFloat();
		this.tipoBanco= in.readInt();
		this.referencia = in.readString();
		this.fechaCheque = in.readLong();
		this.observaciones = in.readString();
	}
	
	@Override
	public int describeContents() {
		// TODO Auto-generated method stub
		return 0;
	}

	@Override
	public void writeToParcel(Parcel arg0, int arg1) {
		// TODO Auto-generated method stub
		arg0.writeInt(tipoPago);
		arg0.writeString(monedaId);
		arg0.writeFloat(importe);
		arg0.writeInt(tipoBanco);
		arg0.writeString(referencia);
		arg0.writeLong(fechaCheque);
        arg0.writeString(observaciones);
	}
	
	public int getTipoPago() {
		return tipoPago;
	}

	public void setTipoPago(int tipoPago) {
		this.tipoPago = tipoPago;
	}

	public String getMonedaId() {
		return monedaId;
	}

	public void setMonedaId(String monedaId) {
		this.monedaId = monedaId;
	}
	
	public float getImporte() {
		return importe;
	}

	public void setImporte(float importe) {
		this.importe = importe;
	}
	
	public int getTipoBanco() {
		return tipoBanco;
	}

	public void setTipoBanco(int tipoBanco) {
		this.tipoBanco = tipoBanco;
	}
	
	public String getReferencia() {
		return referencia;
	}

	public void setReferencia(String referencia) {
		this.referencia = referencia;
	}

	public long getFechaCheque() {
		return fechaCheque;
	}

	public void setFechaCheque(long fechaCheque) {
		this.fechaCheque = fechaCheque;
	}

    public String getObservaciones() {
        return observaciones;
    }

    public void setObservaciones(String observaciones) {
        this.observaciones = observaciones;
    }
	

	@SuppressWarnings("rawtypes")
	public static final  Parcelable.Creator CREATOR =
		    	new Parcelable.Creator() {
		            public DatosAbnDetalle createFromParcel(Parcel in) {
		                return new DatosAbnDetalle(in);
		            }
		 
		            public DatosAbnDetalle[] newArray(int size) {
		                return new DatosAbnDetalle[size];
		            }
		        };
	
}