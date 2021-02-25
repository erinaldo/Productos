package com.amesol.routelite.actividades;

import java.util.ArrayList;
import java.util.Date;
import java.util.Iterator;

import com.amesol.routelite.datos.ABNDetalle;
import com.amesol.routelite.datos.AbnTrp;
import com.amesol.routelite.datos.AbnTrpHist;
import com.amesol.routelite.datos.Abono;
import com.amesol.routelite.datos.AbonoHist;
import com.amesol.routelite.datos.Cliente;
import com.amesol.routelite.datos.Dia;
import com.amesol.routelite.datos.PreLiquidacion;
import com.amesol.routelite.datos.TRPCheque;
import com.amesol.routelite.datos.Usuario;
import com.amesol.routelite.datos.Vendedor;
import com.amesol.routelite.datos.Visita;
import com.amesol.routelite.datos.basedatos.BDVend;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.CONHist;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
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

		public VistaCobranza(String abnid, String folio, Date fecha, float total)
		{
			ABNId = abnid;
			Folio = folio;
			Fecha = fecha;
			Total = total;
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
	}

	public static class VistaDocumentos
	{
		private String TransprodID;
		private String Folio;
		private Date Fecha;
		private float Total;
		private float Saldo;

		public VistaDocumentos(String transprodid, String folio, Date fecha, float total, float saldo)
		{
			TransprodID = transprodid;
			Folio = folio;
			Fecha = fecha;
			Total = total;
			Saldo = saldo;
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

		public VistaDetalle(String abdid, int tipopago, String pago, String monedaid, String moneda, float importe, int tipobanco, String banco, String referencia, Date fechacheque)
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

	public static void guardarDocumento(Abono abono, String transProdId, float importe, boolean buscar) throws Exception
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
		detalle.Referencia = vistaDet.Referencia;
		detalle.FechaCheque = vistaDet.FechaCheque;
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

			String criterioOrdenacion = "";
			String vistaCampos = "";
			Consultas.ConsultasAbono.obtenerCriteriosCobranza(criterioOrdenacion, vistaCampos);

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
					VistaDocumentos doc = new VistaDocumentos(dsDocs.getString("TransProdID"), "", dsDocs.getDate("Fecha"), 0, Generales.getRound(dsDocs.getFloat("Saldo"), 2));
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

						if (doc.getSaldo() <= dTotalDecr)
						{
							guardarDocumento(abono, doc.getTransprodID(), doc.getSaldo(), false);
							Transacciones.Pedidos.ActualizarSaldo(doc.getTransprodID(), -doc.getSaldo());

							dTotalDecr = Generales.getRound(dTotalDecr - doc.getSaldo(), 2);
							doc.setSaldo(0);

						}
						else
						{
							guardarDocumento(abono, doc.getTransprodID(), dTotalDecr, false);
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
						if (doc.getSaldo() > 0)
						{

							if (doc.getSaldo() <= dTotalDecrChequeNormal)
							{
								guardarDocumento(abono, doc.getTransprodID(), doc.getSaldo(), blnHuboPrevios);
								Transacciones.Pedidos.ActualizarSaldo(doc.getTransprodID(), -doc.getSaldo());
								guardarCheque(abono, doc.getTransprodID(), doc.getSaldo(), 0, false);

								dTotalDecrChequeNormal = Generales.getRound(dTotalDecrChequeNormal - doc.getSaldo(), 2);
								doc.setSaldo(0);
							}
							else
							{
								guardarDocumento(abono, doc.getTransprodID(), dTotalDecrChequeNormal, blnHuboPrevios);
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
						if (doc.getSaldo() > 0)
						{

							if (doc.getSaldo() <= dTotalDecrChequePosfechado)
							{
								guardarDocumento(abono, doc.getTransprodID(), doc.getSaldo(), blnHuboPrevios);
								// No actualiza el saldo del transprod porque es
								// posfechado
								guardarCheque(abono, doc.getTransprodID(), 0, doc.getSaldo(), true);

								dTotalDecrChequePosfechado = Generales.getRound(dTotalDecrChequePosfechado - doc.getSaldo(), 2);
								doc.setSaldo(0);
							}
							else
							{
								guardarDocumento(abono, doc.getTransprodID(), dTotalDecrChequePosfechado, blnHuboPrevios);
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

				// Actualizar saldo del documento
				Transacciones.Pedidos.ActualizarSaldo(abt.TransProdID, abt.Importe - nAbnChequePosfechado);
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
			Clientes.actualizarSaldoCteActual((!cliente.ActualizaSaldoCheque ? nAbonoTotal - nAbnCheque : nAbonoTotal));

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
