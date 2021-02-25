package com.amesol.routelite.datos;

import java.util.ArrayList;
import java.util.Date;
import java.util.Iterator;
import java.util.List;

import android.os.Parcel;
import android.os.Parcelable;

import com.amesol.routelite.datos.annotations.Campo;
import com.amesol.routelite.datos.annotations.Hijos;
import com.amesol.routelite.datos.annotations.Llave;
import com.amesol.routelite.datos.annotations.TablaDef;
import com.amesol.routelite.datos.generales.Entidad;

@TablaDef(orden = 8)
public class TransProd extends Entidad implements Parcelable
{
	@Llave
	public String TransProdID;
	@Campo
	public String VisitaClave;
	@Campo
	public String DiaClave;
	@Campo
	public String VisitaClave1;
	@Campo
	public String DiaClave1;
	@Campo
	public String PCEPrecioClave;
	@Campo
	public String PCEModuloMovDetClave;
	@Campo
	public String PCEEsquemaID;
	@Campo
	public String SubEmpresaId;
	@Campo
	public String FacturaID;
	@Campo
	public String ClienteClave;
	@Campo
	public String ClientePagoId;
	@Campo
	public Short CFVTipo;
	@Campo
	public String PLIId;
	@Campo
	public String Folio;
	@Campo
	public short Tipo;
	@Campo
	public Short TipoPedido;
	@Campo
	public short TipoFase;
	@Campo
	public short TipoMovimiento;
	@Campo
	public String ClienteClavePE;
	@Campo
	public String ClienteDomicilioIdPE;
	@Campo
	public Date FechaHoraAlta;
	@Campo
	public Date FechaCaptura;
	@Campo
	public Date FechaEntrega;
	@Campo
	public Date FechaFacturacion;
	@Campo
	public Date FechaSurtido;
	@Campo
	public Date FechaCancelacion;
	@Campo
	public short TipoMotivo;
	@Campo
	public Float SubTDetalle;
	@Campo
	public Float DescVendPor;
	@Campo
	public Float DescuentoVendedor;
	@Campo
	public Float DescuentoImp;
	@Campo
	public Float Subtotal;
	@Campo
	public Float Impuesto;
	@Campo
	public float Total;
	@Campo
	public float Saldo;
	@Campo
	public Boolean Promocion;
	@Campo
	public Boolean Descuento;
	@Campo
	public Short TipoTurno;
	@Campo
	public Date FechaCobranza;
	@Campo
	public Short DiasCredito;
	@Campo
	public String Notas;
	@Campo
	public Date MFechaHora;
	@Campo
	public String MUsuarioID;
	@Campo
	public float SaldoCarga;
	@Campo
	public boolean Enviado;
	@Campo
	public boolean Escritorio;
	@Campo
	public String DevolucionID;

	@Hijos(tablaHijos = TransProdDetalle.class)
	public List<TransProdDetalle> TransProdDetalle;

	public TransProd()
	{
		TransProdDetalle = new ArrayList<TransProdDetalle>();
	}

	public Precio ListaPrecios;
	public float DescuentoImpuestoCliente;
	public float DescuentoImpuestoVendedor;
	public TRPVtaAcreditada PedidoAdicional;

	public int describeContents()
	{
		return 0;
	}

	public TransProdDetalle getTransProdDetalle(String transProdDetalleID)
	{
		Iterator<TransProdDetalle> i = TransProdDetalle.iterator();
		TransProdDetalle tpd;
		while (i.hasNext())
		{
			tpd = i.next();
			if (tpd.TransProdDetalleID.equalsIgnoreCase(transProdDetalleID))
			{
				return tpd;
			}
		}

		return null;
	}

	public List<TransProdDetalle> getTransProdDetalle()
	{
		return TransProdDetalle;
	}

	public void writeToParcel(Parcel out, int flags)
	{
		out.writeString(TransProdID);
		out.writeString(VisitaClave);
		out.writeString(DiaClave);
		out.writeString(VisitaClave1);
		out.writeString(DiaClave1);
		out.writeString(PCEPrecioClave);
		out.writeString(PCEModuloMovDetClave);
		out.writeString(PCEEsquemaID);
		out.writeString(SubEmpresaId);
		out.writeString(FacturaID);
		out.writeString(ClienteClave);
		out.writeString(ClientePagoId);
		out.writeInt(CFVTipo);
		out.writeString(PLIId);
		out.writeString(Folio);
		out.writeInt(Tipo);
		out.writeInt(TipoPedido);
		out.writeInt(TipoFase);
		out.writeInt(TipoMovimiento);
		out.writeString(ClienteClavePE);
		out.writeString(ClienteDomicilioIdPE);
		out.writeLong(FechaHoraAlta.getTime());
		out.writeLong(FechaCaptura.getTime());
		out.writeLong(FechaEntrega.getTime());
		out.writeLong(FechaFacturacion.getTime());
		out.writeLong(FechaSurtido.getTime());
		out.writeLong(FechaCancelacion.getTime());
		out.writeInt(TipoMotivo);
		out.writeFloat(SubTDetalle);
		out.writeFloat(DescVendPor);
		out.writeFloat(DescuentoVendedor);
		out.writeFloat(DescuentoImp);
		out.writeFloat(Subtotal);
		out.writeFloat(Impuesto);
		out.writeFloat(Total);
		out.writeFloat(Saldo);
		out.writeByte((byte) (Promocion ? 1 : 0));
		out.writeByte((byte) (Descuento ? 1 : 0));
		out.writeInt(TipoTurno);
		out.writeLong(FechaCobranza.getTime());
		out.writeInt(DiasCredito);
		out.writeString(Notas);
		out.writeLong(MFechaHora.getTime());
		out.writeString(MUsuarioID);
		out.writeFloat(SaldoCarga);
		out.writeByte((byte) (Enviado ? 1 : 0));
		out.writeByte((byte) (Escritorio ? 1 : 0));
		out.writeString(DevolucionID);
	}

}
