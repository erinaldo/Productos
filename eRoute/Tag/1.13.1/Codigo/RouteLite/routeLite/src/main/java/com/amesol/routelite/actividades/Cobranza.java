package com.amesol.routelite.actividades;

import java.util.ArrayList;
import java.util.Date;
import java.util.Iterator;
import java.util.List;

import com.amesol.routelite.datos.ABNDetalle;
import com.amesol.routelite.datos.AbnTrp;
import com.amesol.routelite.datos.AbnTrpHist;
import com.amesol.routelite.datos.Abono;
import com.amesol.routelite.datos.AbonoHist;
import com.amesol.routelite.datos.Cliente;
import com.amesol.routelite.datos.Dia;
import com.amesol.routelite.datos.PreLiquidacion;
import com.amesol.routelite.datos.TRPCheque;
import com.amesol.routelite.datos.TransProd;
import com.amesol.routelite.datos.Usuario;
import com.amesol.routelite.datos.Vendedor;
import com.amesol.routelite.datos.Visita;
import com.amesol.routelite.datos.basedatos.BDVend;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.CONHist;
import com.amesol.routelite.datos.utilerias.ConfigParametro;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.*;
import com.amesol.routelite.presentadores.Enumeradores.TiposModulos;
import com.amesol.routelite.utilerias.ControlError;
import com.amesol.routelite.utilerias.Generales;
import com.amesol.routelite.utilerias.KeyGen;

public class Cobranza
{
	public static class VistaCobranza implements java.io.Serializable
	{
		/**
		 * 
		 */
		private static final long serialVersionUID = 1L;
		private String ABNId;
		private String Folio;
		private Date Fecha;
		private float Total;
		private String VisitaClave;
		private String DiaClave;

		public VistaCobranza(String abnid, String folio, Date fecha, float total, String visitaClave, String diaClave)
		{
			ABNId = abnid;
			Folio = folio;
			Fecha = fecha;
			Total = total;
			VisitaClave = visitaClave;
			DiaClave = diaClave;
		}

		public String getABNId()
		{
			return ABNId;
		}

		public void setABNID(String abnid)
		{
			ABNId = abnid;
		}

		public String getFolio()
		{
			return Folio;
		}

		public void setFolio(String folio)
		{
			Folio = folio;
		}

		public Date getFecha()
		{
			return Fecha;
		}

		public void setFecha(Date fecha)
		{
			Fecha = fecha;
		}

		public float getTotal()
		{
			return Total;
		}

		public void setTotal(float total)
		{
			Total = total;
		}

		public String getVisitaclave()
		{
			return VisitaClave;
		}

		public void setVisitaClave(String visitaClave)
		{
			VisitaClave= visitaClave;
		}

		public String getDiaclave()
		{
			return DiaClave;
		}

		public void setDiaClave(String diaClave)
		{
			VisitaClave= diaClave;
		}
	}

	public static class VistaDocumentos
	{
		private String TransprodID;
		private String Folio;
		private Date Fecha;
		private float Total;
		private float Saldo;
		private Date FechaCobranza;
		private float DescuentoProntoPago;
        private float ImporteDescPP;
        private String Referencia;

		public VistaDocumentos(String transprodid, String folio, Date fecha, float total, float saldo, Date fechaCobranza, float descuentoProntoPago, float importeDescPP, String referencia)
		{
			TransprodID = transprodid;
			Folio = folio;
			Fecha = fecha;
			Total = total;
			Saldo = saldo;
			FechaCobranza = fechaCobranza;
			DescuentoProntoPago = descuentoProntoPago;
            ImporteDescPP = importeDescPP;
            Referencia = referencia;
		}

		public String getTransprodID()
		{
			return TransprodID;
		}

		public void setTransprodID(String transprodID)
		{
			TransprodID = transprodID;
		}

		public String getFolio()
		{
			return Folio;
		}

		public void setFolio(String folio)
		{
			Folio = folio;
		}

		public Date getFecha()
		{
			return Fecha;
		}

		public void setFecha(Date fecha)
		{
			Fecha = fecha;
		}

		public float getTotal()
		{
			return Total;
		}

		public void setTotal(float total)
		{
			Total = total;
		}

		public float getSaldo()
		{
			return Saldo;
		}

		public void setSaldo(float saldo)
		{
			Saldo = saldo;
		}

		public Date getFechaCobranza()
		{
			return FechaCobranza;
		}

		public void setFechaCobranza(Date fechaCobranza)
		{
			FechaCobranza = fechaCobranza;
		}

		public float getDescuentoProntoPago()
		{
			return DescuentoProntoPago;
		}

		public void setDescuentoProntoPago(float descuentoProntoPago)
		{
			DescuentoProntoPago= descuentoProntoPago;
		}

        public float getImporteDescPP()
        {
            return ImporteDescPP;
        }

        public void setImporteDescPP(float importeDescPP)
        {
            ImporteDescPP = importeDescPP;
        }

        public String getReferencia()
        {
            return Referencia;
        }

        public void setReferencia(String referencia)
        {
            Referencia = referencia;
        }
	}

	public static class VistaDetalle
	{
		private String ABDId;
		private int TipoPago;
		private String Pago;
		private String MonedaId;
		private String Moneda;
		private float Importe;
		private int TipoBanco;
		private String Banco;
		private String Referencia;
		private Date FechaCheque;
        private String Observaciones;

		public VistaDetalle(String abdid, int tipopago, String pago, String monedaid, String moneda, float importe, int tipobanco, String banco, String referencia, Date fechacheque, String observaciones)
		{
			ABDId = abdid;
			TipoPago = tipopago;
			Pago = pago;
			MonedaId = monedaid;
			Moneda = moneda;
			Importe = importe;
			Banco = banco;
			TipoBanco = tipobanco;
			Referencia = referencia;
			FechaCheque = fechacheque;
            Observaciones = observaciones;
		}

		public String getABDId()
		{
			return ABDId;
		}

		public void setABDId(String abdid)
		{
			ABDId = abdid;
		}

		public int getTipoPago()
		{
			return TipoPago;
		}

		public void setTipoPago(int tipopago)
		{
			TipoPago = tipopago;
		}

		public String getPago()
		{
			return Pago;
		}

		public void setPago(String pago)
		{
			Pago = pago;
		}

		public String getMonedaId()
		{
			return MonedaId;
		}

		public void setMonedaId(String monedaid)
		{
			MonedaId = monedaid;
		}

		public String getMoneda()
		{
			return Moneda;
		}

		public void setMoneda(String moneda)
		{
			Moneda = moneda;
		}

		public float getImporte()
		{
			return Importe;
		}

		public void setImporte(float importe)
		{
			Importe = importe;
		}

		public int getTipoBanco()
		{
			return TipoBanco;
		}

		public void setTipoBanco(int tipobanco)
		{
			TipoBanco = tipobanco;
		}

		public String getBanco()
		{
			return Banco;
		}

		public void setBanco(String banco)
		{
			Banco = banco;
		}

		public String getReferencia()
		{
			return Referencia;
		}

		public void setReferencia(String referencia)
		{
			Referencia = referencia;
		}

		public Date getFechaCheque()
		{
			return FechaCheque;
		}

		public void setFechaCheque(Date fechacheque)
		{
			FechaCheque = fechacheque;
		}

        public String getObservaciones()
        {
            return Observaciones;
        }

        public void setObservaciones(String observaciones)
        {
            Observaciones = observaciones;
        }

    }

	public static class VistaSpinner
	{
		String id;
		String nombre;

		// Constructor
		public VistaSpinner(String id, String nombre)
		{
			super();
			this.id = id;
			this.nombre = nombre;
		}

		@Override
		public String toString()
		{
			return nombre;
		}

		public String getId()
		{
			return id;
		}
	}

	public static Abono generarCobranza() throws ControlError, Exception
	{
		String sUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;
		String sDiaClave = ((Dia) Sesion.get(Campo.DiaActual)).DiaClave;
		String sVisitaClave = ((Visita) Sesion.get(Campo.VisitaActual)).VisitaClave;

		Abono abono = new Abono();

		//		abono.ABNId = KeyGen.getId();
		//		abono.Folio = Folios.Obtener((String) Sesion.get(Campo.ModuloMovDetalleClave), byRefMensaje);
		abono.FechaAbono = Generales.getFechaActual();
		abono.FechaCreacion = Generales.getFechaHoraActual();
		abono.VisitaClave = sVisitaClave;
		abono.DiaClave = sDiaClave;
		abono.Total = 0;
		abono.Saldo = 0;
		abono.MFechaHora = Generales.getFechaHoraActual();
		abono.MUsuarioID = sUsuarioID;
		abono.Enviado = false;

		return abono;
	}

	public static void guardarDocumento(Abono abono, String transProdId, float importe, boolean buscar, boolean grabarVisita) throws Exception
	{
		String sUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;
		AbnTrp docto;
		boolean nuevo = true;

		if (buscar)
		{
			Iterator<AbnTrp> itABT = abono.AbnTrp.iterator();
			while (itABT.hasNext())
			{
				docto = itABT.next();
				if (docto.TransProdID.equals(transProdId))
				{
					docto.Importe = Generales.getRound(docto.Importe + importe, 2);
					docto.MFechaHora = Generales.getFechaHoraActual();
					docto.MUsuarioID = sUsuarioID;
					docto.Enviado = false;
					nuevo = false;
					break;
				}
			}
		}

		if (nuevo)
		{
			docto = new AbnTrp();
			docto.ABNId = abono.ABNId;
			docto.TransProdID = transProdId;
			docto.FechaHora = Generales.getFechaHoraActual();
			docto.Importe = importe;
			if (grabarVisita && Sesion.get(Campo.VisitaActual) != null){
				docto.VisitaClave = ((Visita)Sesion.get(Campo.VisitaActual)).VisitaClave;
				docto.DiaClave = ((Visita)Sesion.get(Campo.VisitaActual)).DiaClave;
			}
			docto.MFechaHora = Generales.getFechaHoraActual();
			docto.MUsuarioID = sUsuarioID;
			docto.Enviado = false;

			abono.AbnTrp.add(docto);
		}
	}

	public static void agregarDetalle(Abono abono, VistaDetalle vistaDet)
	{

		ABNDetalle detalle = new ABNDetalle();
		String sUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;

		detalle.ABNId = abono.ABNId;
		detalle.ABDId = vistaDet.ABDId;
		detalle.TipoPago = vistaDet.TipoPago;
		detalle.Importe = vistaDet.Importe;
		detalle.SaldoDeposito = vistaDet.Importe;
		detalle.MonedaID = vistaDet.MonedaId;
		detalle.TipoBanco = vistaDet.TipoBanco;
        if (vistaDet.Referencia.length()>0) {
            detalle.Referencia = vistaDet.Referencia;
        }
		detalle.FechaCheque = vistaDet.FechaCheque;
        if (vistaDet.Observaciones != null && vistaDet.Observaciones.length() >0) {
            detalle.Observaciones = vistaDet.Observaciones;
        }
		detalle.SaldoCarga = 0;
		detalle.MFechaHora = Generales.getFechaHoraActual();
		detalle.MUsuarioID = sUsuarioID;

		detalle.Enviado = false;

		abono.ABNDetalle.add(detalle);
	}

	public static void guardarCheque(Abono abono, String transProdId, float importe, float importePos, boolean buscar)
	{
		String sUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;
		TRPCheque cheque;
		boolean nuevo = true;

		if (buscar)
		{
			Iterator<TRPCheque> itCheque = abono.TRPCheque.iterator();
			while (itCheque.hasNext())
			{
				cheque = itCheque.next();
				if (cheque.TransProdID.equals(transProdId))
				{
					cheque.AbnCheque = Generales.getRound(cheque.AbnCheque + importe, 2);
					cheque.AbnChequePosfechado = Generales.getRound(cheque.AbnChequePosfechado + importePos, 2);
					cheque.MFechaHora = Generales.getFechaHoraActual();
					cheque.MUsuarioID = sUsuarioID;
					cheque.Enviado = false;
					nuevo = false;
					break;
				}
			}
		}

		if (nuevo)
		{
			cheque = new TRPCheque();
			cheque.ABNId = abono.ABNId;
			cheque.TransProdID = transProdId;
			cheque.AbnCheque = importe;
			cheque.AbnChequePosfechado = importePos;
			cheque.MFechaHora = Generales.getFechaHoraActual();
			cheque.MUsuarioID = sUsuarioID;
			cheque.Enviado = false;

			abono.TRPCheque.add(cheque);
		}
	}

	public static void guardarCobranza(Abono abono, String Folio, ArrayList<String> transProdIds, VistaDetalle det) throws Exception
	{
		try
		{

			Cliente cliente = (Cliente) Sesion.get(Campo.ClienteActual);
			// cobrarVentas its not busy
			abono.setValoresOriginales(null);
			float dPagoCheque = 0;
			float dTotalDecrChequeNormal = 0;
			float dTotalDecrChequePosfechado = 0;
			float dTotalDecr = 0;
            float dDescuentoAplicado = 0;
			ValorReferencia valores[] = ValoresReferencia.getValores("PAGO", "CP");
			ArrayList<Integer> aVarPosfechados = new ArrayList<Integer>();
			for (int i = 0; i < valores.length; i++)
			{
				aVarPosfechados.add(Integer.parseInt(valores[i].getVavclave()));
			}

			VistaDetalle vistaDet;
			abono.Total = 0;
			abono.Saldo = 0;

			vistaDet = det;

			if (aVarPosfechados.contains(vistaDet.TipoPago))
			{
				dTotalDecrChequePosfechado += vistaDet.Importe;
				dPagoCheque += vistaDet.Importe;
			}
			else if (vistaDet.TipoPago == 2)
			{
				if (!cliente.ActualizaSaldoCheque)
					dPagoCheque += vistaDet.Importe;
				dTotalDecrChequeNormal += vistaDet.Importe;
			}
			else
			{
				dTotalDecr += vistaDet.Importe;
			}
			abono.Total += vistaDet.Importe;
			abono.ABNId = KeyGen.getId();
			abono.Folio = Folio;
			abono.ABNDetalle.clear();
			agregarDetalle(abono, vistaDet);

			dTotalDecrChequePosfechado = Generales.getRound(dTotalDecrChequePosfechado, 2);
			dTotalDecrChequeNormal = Generales.getRound(dTotalDecrChequeNormal, 2);
			dTotalDecr = Generales.getRound(dTotalDecr, 2);
			dPagoCheque = Generales.getRound(dPagoCheque, 2);

			Clientes.actualizarSaldoCteActual(-Generales.getRound((abono.Total - dPagoCheque), 2));

			String[] resultados = Consultas.ConsultasAbono.obtenerCriteriosCobranza();
			String criterioOrdenacion = resultados[0];
			String vistaCampos = resultados[1];

			ISetDatos dsDocs;
			if (!criterioOrdenacion.equals(""))
			{
				dsDocs = Consultas.ConsultasAbono.obtenerDocumentosCriterio(transProdIds, vistaCampos, criterioOrdenacion);

				if (!dsDocs.moveToFirst())
				{
					dsDocs = Consultas.ConsultasAbono.obtenerDocumentosCriterio(transProdIds, (short) Integer.parseInt((String) ((CONHist) Sesion.get(Campo.CONHist)).get("TipoCobranza")));
					criterioOrdenacion = "Fecha,Saldo";
				}

			}
			else
			{
				dsDocs = Consultas.ConsultasAbono.obtenerDocumentosCriterio(transProdIds, (short) Integer.parseInt((String) ((CONHist) Sesion.get(Campo.CONHist)).get("TipoCobranza")));
				criterioOrdenacion = "Fecha,Saldo";
			}

			ArrayList<VistaDocumentos> listaDocs = new ArrayList<Cobranza.VistaDocumentos>();
			if (dsDocs.moveToFirst())
			{

				do
				{
                    VistaDocumentos doc = new VistaDocumentos(dsDocs.getString("TransProdID"), "", dsDocs.getDate("Fecha"), 0, Generales.getRound(dsDocs.getFloat("Saldo"), 2), dsDocs.getDate("FechaCobranza"),(dsDocs.getColumnIndex("DescProntoPago") >0 ? dsDocs.getFloat(dsDocs.getColumnIndex("DescProntoPago")):0 ), (dsDocs.getColumnIndex("ImporteDescPP") >0 ? dsDocs.getFloat(dsDocs.getColumnIndex("ImporteDescPP")):0 ), "");
					listaDocs.add(doc);
				}
				while (dsDocs.moveToNext());
			}
			dsDocs.close();

			boolean blnHuboPrevios = false;
			Iterator<VistaDocumentos> itDocs;

			if (listaDocs.toArray().length > 0)
			{
				// Repartir el Total de abonos que no son cheque
				if (dTotalDecr > 0)
				{
					itDocs = listaDocs.iterator();
					while (itDocs.hasNext())
					{
						VistaDocumentos doc = itDocs.next();

						if (Generales.getRound(doc.getSaldo() - doc.getImporteDescPP(), 2) <= dTotalDecr)
						{
							guardarDocumento(abono, doc.getTransprodID(), doc.getSaldo() - doc.getImporteDescPP(), false,false);
							Transacciones.Pedidos.ActualizarSaldo(doc.getTransprodID(), -doc.getSaldo());

							dTotalDecr = Generales.getRound(dTotalDecr - (doc.getSaldo() - doc.getImporteDescPP()), 2);
							doc.setSaldo(0);

                            if (doc.getImporteDescPP() > 0){
                                dDescuentoAplicado += doc.getImporteDescPP();
                                Consultas.ConsultasAbono.ActualizaDescProntoPagoAplicado(doc.getTransprodID(), true);
                            }
						}
						else
						{
							guardarDocumento(abono, doc.getTransprodID(), dTotalDecr, false,false);
							Transacciones.Pedidos.ActualizarSaldo(doc.getTransprodID(), -dTotalDecr);

							doc.setSaldo(Generales.getRound(doc.getSaldo() - dTotalDecr, 2));
							dTotalDecr = 0;
						}

						if (dTotalDecr <= 0)
							break;
					}

					blnHuboPrevios = true;
				}

				// Repartir el Total de Abonos Cheque Normal
				if (dTotalDecrChequeNormal > 0)
				{

					itDocs = listaDocs.iterator();
					while (itDocs.hasNext())
					{
						VistaDocumentos doc = itDocs.next();
						if (Generales.getRound(doc.getSaldo() - doc.getImporteDescPP(), 2) > 0)
						{

							if (Generales.getRound(doc.getSaldo() - doc.getImporteDescPP(), 2) <= dTotalDecrChequeNormal)
							{
								guardarDocumento(abono, doc.getTransprodID(), doc.getSaldo() - doc.getImporteDescPP(), blnHuboPrevios, false);
								Transacciones.Pedidos.ActualizarSaldo(doc.getTransprodID(), -doc.getSaldo());
								guardarCheque(abono, doc.getTransprodID(), doc.getSaldo() - doc.getImporteDescPP(), 0, false);

								dTotalDecrChequeNormal = Generales.getRound(dTotalDecrChequeNormal - (doc.getSaldo() - doc.getImporteDescPP()), 2);
								doc.setSaldo(0);

                                if (doc.getImporteDescPP() > 0){
                                    dDescuentoAplicado += doc.getImporteDescPP();
                                    Consultas.ConsultasAbono.ActualizaDescProntoPagoAplicado(doc.getTransprodID(), true);
                                }
							}
							else
							{
								guardarDocumento(abono, doc.getTransprodID(), dTotalDecrChequeNormal, blnHuboPrevios, false);
								Transacciones.Pedidos.ActualizarSaldo(doc.getTransprodID(), -dTotalDecrChequeNormal);
								guardarCheque(abono, doc.getTransprodID(), dTotalDecrChequeNormal, 0, false);

								doc.setSaldo(Generales.getRound(doc.getSaldo() - dTotalDecrChequeNormal, 2));
								dTotalDecrChequeNormal = 0;
							}

							if (dTotalDecrChequeNormal <= 0)
								break;
						}
					}

					blnHuboPrevios = true;
				}

				// Repartir el Total de Abonos Cheque Posfechado
				if (dTotalDecrChequePosfechado > 0)
				{
					itDocs = listaDocs.iterator();
					while (itDocs.hasNext())
					{
						VistaDocumentos doc = itDocs.next();
						if (Generales.getRound(doc.getSaldo() - doc.getImporteDescPP(), 2) > 0)
						{

							if (Generales.getRound(doc.getSaldo() - doc.getImporteDescPP(), 2) <= dTotalDecrChequePosfechado)
							{
								guardarDocumento(abono, doc.getTransprodID(), doc.getSaldo() - doc.getImporteDescPP(), blnHuboPrevios, false);
								// No actualiza el saldo del transprod porque es
								// posfechado
								guardarCheque(abono, doc.getTransprodID(), 0, doc.getSaldo() - doc.getImporteDescPP(), true);

								dTotalDecrChequePosfechado = Generales.getRound(dTotalDecrChequePosfechado - (doc.getSaldo() - doc.getImporteDescPP()), 2);
								doc.setSaldo(0);

                                if (doc.getImporteDescPP() > 0){
                                    dDescuentoAplicado += doc.getImporteDescPP();
                                    Consultas.ConsultasAbono.ActualizaDescProntoPagoAplicado(doc.getTransprodID(), true);
                                }
							}
							else
							{
								guardarDocumento(abono, doc.getTransprodID(), dTotalDecrChequePosfechado, blnHuboPrevios, false);
								// No actualiza el saldo del transprod porque es
								// posfechado
								guardarCheque(abono, doc.getTransprodID(), 0, dTotalDecrChequePosfechado, true);

								doc.setSaldo(Generales.getRound(doc.getSaldo() - dTotalDecrChequePosfechado, 2));
								dTotalDecrChequePosfechado = 0;
							}

							if (dTotalDecrChequePosfechado <= 0)
								break;
						}
					}
				}

                //Descontar del saldo del cliente el descuento aplicado por pronto pago
                if (dDescuentoAplicado > 0)
                    Clientes.actualizarSaldoCteActual(-Generales.getRound(dDescuentoAplicado, 2));

				// Guardar el saldo que quedo del abono si fue el caso
				if ((dTotalDecr + dTotalDecrChequeNormal + dTotalDecrChequePosfechado) > 0)
					abono.Saldo = (dTotalDecr + dTotalDecrChequeNormal + dTotalDecrChequePosfechado);

				// Actualizar cuota de cobranza
				String vendedorID = ((Vendedor) Sesion.get(Campo.VendedorActual)).VendedorId;
				Cuotas.VerificarCuotas(vendedorID, 4, abono.Total, null);
			}

			BDVend.guardarInsertar(abono);
			Folios.confirmar((String) Sesion.get(Campo.ModuloMovDetalleClave));

			BDVend.commit();

		}
		catch (Exception e)
		{
			e.printStackTrace();
			try
			{
				BDVend.rollback();
			}
			catch (Exception ex)
			{
				e.printStackTrace();
			}
			throw new Exception(e.getMessage());
			// return false;
		}
	}

    public static void guardarCobranzaPagoAnticipado(Abono abono, TransProd transProd, Visita visita) throws Exception
    {
        try
        {
            Cliente cliente = (Cliente) Sesion.get(Campo.ClienteActual);

            abono.setValoresOriginales(null);
            float dTotalDecr = 0;
            ValorReferencia valores[] = ValoresReferencia.getValores("PAGO", "CP");
            ArrayList<Integer> aVarPosfechados = new ArrayList<Integer>();
            for (int i = 0; i < valores.length; i++)
            {
                aVarPosfechados.add(Integer.parseInt(valores[i].getVavclave()));
            }

            if (abono.ABNDetalle.size()<=0){
                throw new Exception(Mensajes.get("E0053"));
            }

            ABNDetalle abd = abono.ABNDetalle.get(0);
            if (aVarPosfechados.contains(abd.TipoPago))
            {
                throw new Exception("No se puede capturar cheque posfechado");
            }
            else
            {
                dTotalDecr += abd.Importe;
            }
            abono.Total += Generales.getRound(abd.Importe,2);
            abono.MFechaHora = Generales.getFechaHoraActual();
            abono.Enviado = false;

            AbnTrp abt = new AbnTrp();
            abt.ABNId = abono.ABNId;
            abt.TransProdID = transProd.TransProdID;
            abt.FechaHora = Generales.getFechaHoraActual();
            abt.Importe = Generales.getRound(abd.Importe,2);
            abt.MFechaHora = Generales.getFechaHoraActual();
            abt.MUsuarioID = abono.MUsuarioID;
            abt.Enviado = false;
            abono.AbnTrp.add(abt);

            transProd.Saldo = Generales.getRound(Generales.getRound(transProd.Saldo,2) - Generales.getRound(abd.Importe,2),2) ;
            transProd.MFechaHora = Generales.getFechaHoraActual();
            transProd.MUsuarioID = abono.MUsuarioID;
            transProd.Enviado = false;

            BDVend.guardarInsertar(abono);
            BDVend.guardarInsertar(transProd);
            Folios.confirmar(com.amesol.routelite.presentadores.Enumeradores.TiposModuloMovDetalle.PAGOS);

            BDVend.commit();

        }
        catch (Exception e)
        {
            e.printStackTrace();
            try
            {
                BDVend.rollback();
            }
            catch (Exception ex)
            {
                e.printStackTrace();
            }
            throw new Exception(e.getMessage());
        }
    }
	public static boolean asociarAbonosDisponibles(List<Abono> abonos, ArrayList<String> transProdIds, List<Abono> abonosAsociados) throws Exception
	{
		try
		{
			/*Se considera que cada abono contiene solo un ABNDetalle, por eso solo se toma el primero
			* Esto debido a que cada abono representa una nota de crédito
			* Si se cambian las condiciones, se tendra que cambiar el algoritmo
			* No se hizo para los demas tipos de pago porque habia que considerar los cheques*/
			boolean seAsocioAlgunAbono = false;
			for (Abono abono: abonos){
				Cliente cliente = (Cliente) Sesion.get(Campo.ClienteActual);

				BDVend.recuperar(abono);
				BDVend.recuperar(abono, ABNDetalle.class);

				float dTotalDecr = 0;
				ValorReferencia valores[] = ValoresReferencia.getValores("PAGO", "NC");
				ArrayList<Integer> aVarNotaCredito = new ArrayList<Integer>();
				for (int i = 0; i < valores.length; i++)
				{
					aVarNotaCredito.add(Integer.parseInt(valores[i].getVavclave()));
				}

				if (abono.ABNDetalle.size()>0 && aVarNotaCredito.contains(abono.ABNDetalle.get(0).TipoPago)) {
					dTotalDecr += abono.Saldo;
				}else{
					throw new Exception("Los abonos deben ser tipo Nota de Crédito");
				}
				dTotalDecr = Generales.getRound(dTotalDecr, 2);

				/*ver que hacer con el saldo del cliente*/
				//Clientes.actualizarSaldoCteActual(-Generales.getRound((abono.Total), 2));

				String[] resultados = Consultas.ConsultasAbono.obtenerCriteriosCobranza();
				String criterioOrdenacion = resultados[0];
				String vistaCampos = resultados[1];

				ISetDatos dsDocs;
				if (!criterioOrdenacion.equals(""))
				{
					dsDocs = Consultas.ConsultasAbono.obtenerDocumentosCriterio(transProdIds, vistaCampos, criterioOrdenacion);

					if (!dsDocs.moveToFirst())
					{
						dsDocs = Consultas.ConsultasAbono.obtenerDocumentosCriterio(transProdIds, (short) Integer.parseInt((String) ((CONHist) Sesion.get(Campo.CONHist)).get("TipoCobranza")));
						//criterioOrdenacion = "Fecha,Saldo";
					}

				}
				else
				{
					dsDocs = Consultas.ConsultasAbono.obtenerDocumentosCriterio(transProdIds, (short) Integer.parseInt((String) ((CONHist) Sesion.get(Campo.CONHist)).get("TipoCobranza")));
					//criterioOrdenacion = "Fecha,Saldo";
				}

				ArrayList<VistaDocumentos> listaDocs = new ArrayList<Cobranza.VistaDocumentos>();
				if (dsDocs.moveToFirst())
				{
					do
					{
						//Se verifica si tiene un saldo, porque se repasa los documentos por cada abono, y
						//puede ser que alguno de los documentos se haya quedado sin saldo
						if (Generales.getRound(dsDocs.getFloat("Saldo"), 2) >0) {
							VistaDocumentos doc = new VistaDocumentos(dsDocs.getString("TransProdID"), "", dsDocs.getDate("Fecha"), 0, Generales.getRound(dsDocs.getFloat("Saldo"), 2),dsDocs.getDate("FechaCobranza"),(dsDocs.getColumnIndex("DescProntoPago") >0 ? dsDocs.getFloat(dsDocs.getColumnIndex("DescProntoPago")):0), 0, "");
							listaDocs.add(doc);
						}
					}
					while (dsDocs.moveToNext());
				}
				dsDocs.close();

				boolean blnHuboPrevios = false;
				Iterator<VistaDocumentos> itDocs;

				if (listaDocs.toArray().length > 0)
				{
					// Repartir el Total de abonos que no son cheque
					if (dTotalDecr > 0)
					{
						itDocs = listaDocs.iterator();
						while (itDocs.hasNext())
						{
							VistaDocumentos doc = itDocs.next();

							if (doc.getSaldo() <= dTotalDecr)
							{
								guardarDocumento(abono, doc.getTransprodID(), doc.getSaldo(), false, true);
								Transacciones.Pedidos.ActualizarSaldo(doc.getTransprodID(), -doc.getSaldo());

								dTotalDecr = Generales.getRound(dTotalDecr - doc.getSaldo(), 2);
								doc.setSaldo(0);
								seAsocioAlgunAbono = true;
								if (!abonosAsociados.contains(abono)){
									abonosAsociados.add(abono);
								}
							}
							else
							{
								guardarDocumento(abono, doc.getTransprodID(), dTotalDecr, false, true);
								Transacciones.Pedidos.ActualizarSaldo(doc.getTransprodID(), -dTotalDecr);

								doc.setSaldo(Generales.getRound(doc.getSaldo() - dTotalDecr, 2));
								dTotalDecr = 0;
								seAsocioAlgunAbono = true;
								if (!abonosAsociados.contains(abono)){
									abonosAsociados.add(abono);
								}
							}

							if (dTotalDecr <= 0)
								break;
						}

						blnHuboPrevios = true;
					}

					// Guardar el saldo que quedo del abono si fue el caso
					abono.MFechaHora = Generales.getFechaHoraActual();
					abono.MUsuarioID = ((Usuario)Sesion.get(Campo.UsuarioActual)).USUId;
					abono.Saldo = dTotalDecr ;
					abono.Enviado = false;

					// Actualizar cuota de cobranza
					String vendedorID = ((Vendedor) Sesion.get(Campo.VendedorActual)).VendedorId;
					Cuotas.VerificarCuotas(vendedorID, 4, abono.Total, null);
				}

				BDVend.guardarInsertar(abono);
				//Folios.confirmar((String) Sesion.get(Campo.ModuloMovDetalleClave));

			}
			BDVend.commit();

			return seAsocioAlgunAbono;
		}
		catch (Exception e)
		{
			e.printStackTrace();
			try
			{
				BDVend.rollback();
			}
			catch (Exception ex)
			{
				e.printStackTrace();
			}
			throw new Exception(e.getMessage());
			// return false;
		}
	}

	public static void eliminarCobranza(String abnid) throws Exception
	{
		short trueType;
		if ((short) Integer.parseInt((String) ((CONHist) Sesion.get(Campo.CONHist)).get("TipoCobranza")) == 2)
			trueType = Consultas.ConsultasTransProd.getTipoFiscalCliente(((Cliente) Sesion.get(Campo.ClienteActual)).ClienteClave);
		else
			trueType = (short) Integer.parseInt((String) ((CONHist) Sesion.get(Campo.CONHist)).get("TipoCobranza"));
		// boolean cobrarVentas = (((CONHist)
		// Sesion.get(Campo.CONHist)).get("CobrarVentas").equals("1") ? true :
		// false);
		Cliente cliente = (Cliente) Sesion.get(Campo.ClienteActual);

		Abono abono = new Abono();
		abono.ABNId = abnid;
		BDVend.recuperar(abono);
		BDVend.recuperar(abono, AbnTrp.class);
		BDVend.recuperar(abono, ABNDetalle.class);
		BDVend.recuperar(abono, TRPCheque.class);

		if (trueType == 1)
		{
			if (Consultas.ConsultasAbono.tieneDocumentosFacturados(abnid))
				throw new Exception(Mensajes.get("E0744").replace("$0$", Mensajes.get("XEliminar")));
		}

		if (!Clientes.validarLimiteCredito(cliente, abono))
			throw new Exception(Mensajes.get("I0224"));

		Iterator<ABNDetalle> detalles = abono.ABNDetalle.iterator();
		ABNDetalle detalle;
		while (detalles.hasNext())
		{
			detalle = (ABNDetalle) detalles.next();
			if (detalle.Importe != detalle.SaldoDeposito)
				throw new Exception(Mensajes.get("E0547"));
		}

		if (!Clientes.validarVencimientoVenta(cliente, abono))
			throw new Exception(Mensajes.get("E0752").replace("$0$", (trueType == 1 ? Mensajes.get("XVenta") : Mensajes.get("XFactura"))));

		try
		{
            boolean aplicarDescProntoPago = false;
            float descuentoProntoPago = 0;
            if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).existeParametro("AplicarDescProntoPago"))
                aplicarDescProntoPago =  ((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("AplicarDescProntoPago").toString().equals("1");


			generarHistorico(abono);

			float nAbnChequePosfechado;
			float nAbnCheque = 0;
			float nAbonoTotal = 0;

			Iterator<AbnTrp> itABT = abono.AbnTrp.iterator();
			while (itABT.hasNext())
			{
				AbnTrp abt = itABT.next();
				nAbnChequePosfechado = 0;

				Iterator<TRPCheque> itTRP = abono.TRPCheque.iterator();
				while (itTRP.hasNext())
				{
					TRPCheque trp = itTRP.next();
					if (trp.TransProdID.equals(abt.TransProdID))
					{
						nAbnChequePosfechado += trp.AbnChequePosfechado;
						nAbnCheque += trp.AbnCheque;
					}
				}

				nAbonoTotal += abt.Importe - nAbnChequePosfechado;

				if ((Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == TiposModulos.VENTA) || (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == TiposModulos.REPARTO))
				{
					if (((CONHist) Sesion.get(Campo.CONHist)).get("Preliquidacion").equals("1"))
					{
						ISetDatos mObtenerPreliquidacion = Consultas.ConsultaPreLiquidacion.obtenerPreLiquidacion();
						mObtenerPreliquidacion.moveToFirst();
						if (mObtenerPreliquidacion.getFloat(3) > abt.Importe)
							throw new Exception(Mensajes.get("ME0590"));

						PreLiquidacion mPreLiquidacion = new PreLiquidacion();
						mPreLiquidacion.PLIId = mObtenerPreliquidacion.getString(0);
						BDVend.recuperar(mPreLiquidacion);
						mPreLiquidacion.MontoTotal = Consultas.ConsultasTransProd.obtenerEfectivo() - abt.Importe;

						if (mPreLiquidacion.MontoTotal <= 0
								& Consultas.ConsultasTransProd.obtenerPreLiquidacionTrans(mPreLiquidacion.PLIId).equals("")
								& Consultas.ConsultasTransProd.obtenerPreLiquidacionPLBPLE(mPreLiquidacion.PLIId).equals(""))
						{
							BDVend.eliminar(mPreLiquidacion);
						}
						else
						{
							BDVend.guardarInsertar(mPreLiquidacion);
						}

					}
				}

                //Obtener descuento aplicado por pronto pago
                float descPP = 0;
                if (aplicarDescProntoPago){
                    descPP = Consultas.ConsultasAbono.ObtenerDescProntoPagoAplicado(abt.TransProdID);
                    if (descPP > 0) {
                        descuentoProntoPago += descPP;
                        Consultas.ConsultasAbono.ActualizaDescProntoPagoAplicado(abt.TransProdID, false);
                    }
                }

				// Actualizar saldo del documento
				Transacciones.Pedidos.ActualizarSaldo(abt.TransProdID, (abt.Importe + descPP) - nAbnChequePosfechado);
				BDVend.eliminar(abt);
			}

			Iterator<ABNDetalle> itABD = abono.ABNDetalle.iterator();
			while (itABD.hasNext())
			{
				BDVend.eliminar(itABD.next());
			}

			Iterator<TRPCheque> itTRP = abono.TRPCheque.iterator();
			while (itTRP.hasNext())
			{
				BDVend.eliminar(itTRP.next());
			}

			BDVend.eliminar(abono);

			// Actualizar saldo del cliente
			Clientes.actualizarSaldoCteActual((!cliente.ActualizaSaldoCheque ? (nAbonoTotal + descuentoProntoPago) - nAbnCheque : nAbonoTotal + descuentoProntoPago));

			// Actualizar cuota de cobranza
			String vendedorID = ((Vendedor) Sesion.get(Campo.VendedorActual)).VendedorId;
			Cuotas.VerificarCuotas(vendedorID, 4, -abono.Total, null);

			BDVend.commit();
		}
		catch (Exception e)
		{
			try
			{
				BDVend.rollback();
			}
			catch (Exception ex)
			{
				e.printStackTrace();
			}
			throw e;
		}

	}

	public static void quitarAsociacionCobranza(String abnid) throws Exception
	{

		try{
			Abono abono = new Abono();
			abono.ABNId = abnid;
			BDVend.recuperar(abono);
			BDVend.recuperar(abono, AbnTrp.class);
			BDVend.recuperar(abono, ABNDetalle.class);
			BDVend.recuperar(abono, TRPCheque.class);

			float nAbonoTotal = 0;

			Iterator<AbnTrp> itABT = abono.AbnTrp.iterator();
			while (itABT.hasNext())
			{
				AbnTrp abt = itABT.next();

				nAbonoTotal += abt.Importe;

				// Actualizar saldo del documento
				Transacciones.Pedidos.ActualizarSaldo(abt.TransProdID, abt.Importe);
				BDVend.eliminar(abt);
			}
			abono.Saldo +=nAbonoTotal;
			abono.Enviado = false;
			String vendedorID = ((Vendedor) Sesion.get(Campo.VendedorActual)).VendedorId;
			Cuotas.VerificarCuotas(vendedorID, 4, -abono.Total, null);
			BDVend.guardarInsertar(abono);
			BDVend.commit();
		}
		catch (Exception e)
		{
			try
			{
				BDVend.rollback();
			}
			catch (Exception ex)
			{
				e.printStackTrace();
			}
			throw e;
		}

	}
    public static void eliminarPagoAnticipado(String transProdId) throws Exception
    {
        try
        {
            /*TransProd trp = new TransProd();
            trp.TransProdID = transProdId;
            BDVend.recuperar(trp);*/

            ISetDatos sdAbnTrp = Consultas.ConsultasAbnTrp.obtenerAbonos(transProdId);
            while (sdAbnTrp.moveToNext())
            {
                Abono abono = new Abono();
                abono.ABNId = sdAbnTrp.getString("ABNId");
                BDVend.recuperar(abono);
                BDVend.recuperar(abono, AbnTrp.class);
                BDVend.recuperar(abono, ABNDetalle.class);
                BDVend.recuperar(abono, TRPCheque.class);

                Iterator<ABNDetalle> detalles = abono.ABNDetalle.iterator();
                ABNDetalle detalle;
                while (detalles.hasNext())
                {
                    detalle = (ABNDetalle) detalles.next();
                    if (detalle.Importe != detalle.SaldoDeposito)
                        throw new Exception(Mensajes.get("E0547"));
                }

                generarHistorico(abono);

                Iterator<AbnTrp> itABT = abono.AbnTrp.iterator();
                while (itABT.hasNext())
                {
                    AbnTrp abt = itABT.next();

                    //nAbonoTotal += abt.Importe;

                    // Actualizar saldo del documento
                    Transacciones.Pedidos.ActualizarSaldo(abt.TransProdID, abt.Importe);
                    BDVend.eliminar(abt);
                }

                Iterator<ABNDetalle> itABD = abono.ABNDetalle.iterator();
                while (itABD.hasNext())
                {
                    BDVend.eliminar(itABD.next());
                }

                Iterator<TRPCheque> itTRP = abono.TRPCheque.iterator();
                while (itTRP.hasNext())
                {
                    BDVend.eliminar(itTRP.next());
                }

                BDVend.eliminar(abono);
            }
            sdAbnTrp.close();
            // Actualizar saldo del cliente
            //Clientes.actualizarSaldoCteActual((!cliente.ActualizaSaldoCheque ? nAbonoTotal - nAbnCheque : nAbonoTotal));

            // Actualizar cuota de cobranza
            //String vendedorID = ((Vendedor) Sesion.get(Campo.VendedorActual)).VendedorId;
            //Cuotas.VerificarCuotas(vendedorID, 4, -abono.Total, null);

            BDVend.commit();
        }
        catch (Exception e)
        {
            try
            {
                BDVend.rollback();
            }
            catch (Exception ex)
            {
                e.printStackTrace();
            }
            throw e;
        }

    }

	public static void generarHistorico(Abono abono) throws Exception
	{
		String sUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;

		AbonoHist abnHist = new AbonoHist();
		abnHist.ABNId = abono.ABNId;
		abnHist.Folio = abono.Folio;
		abnHist.FechaHoraCreacion = abono.FechaCreacion;
		abnHist.VisitaClave = abono.VisitaClave;
		abnHist.DiaClave = abono.DiaClave;
		abnHist.Total = abono.Total;
		abnHist.FechaHoraElim = Generales.getFechaHoraActual();
		abnHist.MFechaHora = Generales.getFechaHoraActual();
		abnHist.MUsuarioID = sUsuarioID;
		abnHist.Enviado = false;

		Iterator<AbnTrp> itABT = abono.AbnTrp.iterator();
		while (itABT.hasNext())
		{
			AbnTrp abt = itABT.next();
			AbnTrpHist abtHist = new AbnTrpHist();
			abtHist.ABNId = abt.ABNId;
			abtHist.TransProdID = abt.TransProdID;
			abtHist.MFechaHora = Generales.getFechaHoraActual();
			abtHist.MUsuarioID = sUsuarioID;
			abtHist.Enviado = false;
			abnHist.AbnTrpHist.add(abtHist);
		}

		BDVend.guardarInsertar(abnHist);
	}
}
