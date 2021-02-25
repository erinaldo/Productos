package com.amesol.routelite.presentadores.act;

import java.util.Iterator;

import android.app.AlertDialog;
import android.content.DialogInterface;
import android.util.Log;

import com.amesol.routelite.actividades.Clientes;
import com.amesol.routelite.actividades.Cobranza;
import com.amesol.routelite.actividades.Inventario;
import com.amesol.routelite.actividades.ManejoEnvase;
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.actividades.Transacciones;
import com.amesol.routelite.datos.ABNDetalle;
import com.amesol.routelite.datos.AbnTrp;
import com.amesol.routelite.datos.Abono;
import com.amesol.routelite.datos.Dia;
import com.amesol.routelite.datos.ModuloTerm;
import com.amesol.routelite.datos.PreLiquidacion;
import com.amesol.routelite.datos.Producto;
import com.amesol.routelite.datos.TransProd;
import com.amesol.routelite.datos.TransProdDetalle;
import com.amesol.routelite.datos.Usuario;
import com.amesol.routelite.datos.Cliente;
import com.amesol.routelite.datos.Vendedor;
import com.amesol.routelite.datos.Visita;
import com.amesol.routelite.datos.basedatos.BDVend;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.CONHist;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.Enumeradores.TiposFasesDocto;
import com.amesol.routelite.presentadores.Enumeradores.TiposMovimientos;
import com.amesol.routelite.presentadores.Enumeradores.TiposTransProd;
import com.amesol.routelite.presentadores.Presentador;
import com.amesol.routelite.presentadores.act.SeleccionarPedido.VistaPedidos;
import com.amesol.routelite.presentadores.interfaces.ICancelaPedido;
import com.amesol.routelite.utilerias.Generales;

public class CancelarPedido extends Presentador
{

	ICancelaPedido mVista;
	String mAccion;
	short trueType;

	public CancelarPedido(ICancelaPedido vista, String accion)
	{
		mVista = vista;
		mAccion = accion;
	}

	@Override
	public void iniciar()
	{
		mVista.iniciar(); 
	}

	public boolean cancelarPedido(TransProd pedido)
	{
		boolean validarPreliquidacion = false;
		try
		{
	
			// TODO: falta el manejo de los pedidos agrupados con subempres
			// TODO: falta el manejo de las devoluciones automaticas de envase
			// TODO: falta el manejo correcto de las cuotas y puntos
		    CONHist conhist = (CONHist) Sesion.get(Campo.CONHist);

			//Dar reversa al inventario
			//TODO: Falta el manejo de envase en inventario
			
			if (pedido.Tipo != Enumeradores.TiposTransProd.MOV_SIN_INV_EV && Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) != Enumeradores.TiposModulos.REPARTO )
			{
				BDVend.recuperar(pedido, TransProdDetalle.class);
				Iterator<TransProdDetalle> it = pedido.TransProdDetalle.iterator();
				while (it.hasNext())
				{
					TransProdDetalle oTpd = it.next();
					Inventario.ActualizarInventario(oTpd.ProductoClave, oTpd.TipoUnidad, oTpd.Cantidad, pedido.Tipo, pedido.TipoMovimiento, ((Vendedor)Sesion.get(Campo.VendedorActual)).AlmacenID, true);
					
					Cliente cli = ((Cliente)Sesion.get(Campo.ClienteActual));
					if((Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.VENTA || Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO) && cli.Prestamo && pedido.Tipo == TiposTransProd.PEDIDO){
						Producto producto = new Producto();
						producto.ProductoClave = oTpd.ProductoClave;
						BDVend.recuperar(producto);
						ManejoEnvase.manejoEnvaseEliminar(producto, oTpd.TipoUnidad, oTpd.Cantidad, oTpd, pedido);	
					}
				}
				
			}else if(pedido.Tipo != Enumeradores.TiposTransProd.MOV_SIN_INV_EV && Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO){
				/*if (conhist.get("Preliquidacion").equals("1")){
					PreLiquidacion Pli = new PreLiquidacion();
					Pli.PLIId = pedido.PLIId;
					BDVend.recuperar(Pli);
					
					if(Pli.isRecuperado()){
						if(pedido.Total > Pli.MontoTotal){
							mVista.mostrarError(Mensajes.get("E0590"));
							return;
						}else{
							Pli.MontoTotal -= pedido.Total;
							
							if(Pli.MontoTotal == 0){
								//TODO: validar relacion con movimientos y/o depositos y eliminar fisicamente
								pedido.PLIId = "";
								BDVend.eliminar(Pli);
							}else
								BDVend.guardarInsertar(Pli);
						}
					}
				}*/
			
			    Consultas.ConsultasTPDDesVendedor.eliminarPorTransProd(pedido.TransProdID); 
				
				//if(!pedido.VisitaClave1.equals(((Visita) Sesion.get(Campo.VisitaActual)).VisitaClave) && !pedido.DiaClave1.equals(((Dia) Sesion.get(Campo.DiaActual)).DiaClave)){
				if(Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO && (pedido.TipoFase == TiposFasesDocto.CAPTURA || pedido.TipoFase == TiposFasesDocto.CAPTURA_ESCRITORIO)){
						//pedido subido para repartir
						//actualizar inventario, restar apartado y pedido
						BDVend.recuperar(pedido, TransProdDetalle.class);
						Iterator<TransProdDetalle> it = pedido.TransProdDetalle.iterator();
						while (it.hasNext())
						{
							TransProdDetalle oTpd = it.next();
							//Inventario.ActualizarInventario(oTpd.ProductoClave, oTpd.TipoUnidad, oTpd.Cantidad, pedido.Tipo, TiposMovimientos.NO_DEFINIDO, ((Vendedor)Sesion.get(Campo.VendedorActual)).AlmacenID, true);
							Inventario.ActualizarInventario(oTpd.ProductoClave, oTpd.TipoUnidad, oTpd.Cantidad, pedido.Tipo, TiposMovimientos.ENTRADA, ((Vendedor)Sesion.get(Campo.VendedorActual)).AlmacenID, true);
						} Log.i(null, "Pasa 5");
				}else if (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO && pedido.TipoFase == TiposFasesDocto.SURTIDO){
					//pedido creado en visita
					//actualizar inventario, entrada
					BDVend.recuperar(pedido, TransProdDetalle.class);
					Iterator<TransProdDetalle> it = pedido.TransProdDetalle.iterator();
					while (it.hasNext())
					{
						TransProdDetalle oTpd = it.next();
						Inventario.ActualizarInventario(oTpd.ProductoClave, oTpd.TipoUnidad, oTpd.Cantidad, pedido.Tipo, TiposMovimientos.ENTRADA, ((Vendedor)Sesion.get(Campo.VendedorActual)).AlmacenID, true, pedido.TipoFase);
						
						Cliente cli = ((Cliente)Sesion.get(Campo.ClienteActual));
						if((Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.VENTA || Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO) && cli.Prestamo && pedido.Tipo == TiposTransProd.PEDIDO){
							Producto producto = new Producto();
							producto.ProductoClave = oTpd.ProductoClave;
							BDVend.recuperar(producto);
							ManejoEnvase.manejoEnvaseEliminar(producto, oTpd.TipoUnidad, oTpd.Cantidad, oTpd, pedido);	
						}
					}
				} 
			}else if(pedido.Tipo == TiposTransProd.MOV_SIN_INV_EV){
				Consultas.ConsultasTPDDesVendedor.eliminarPorTransProd(pedido.TransProdID);
				if(pedido.VisitaClave == ((Visita)Sesion.get(Campo.VisitaActual)).VisitaClave){
					//TODO: CUOTAS AL CANCELAR MSIEV
					//Cuotas.RestarCuotasXProducto(oTransProd)
	                //Cuotas.CalcularCuotasxEfectivo(oTransProd, True)
				}
			}
			

			// forma venta contado, forma pago efectivo, cobranza sobre ventas y
			// pago automatico
			if ((short) Integer.parseInt((String) ((CONHist) Sesion.get(Campo.CONHist)).get("TipoCobranza")) == 2)
				trueType = Consultas.ConsultasTransProd.getTipoFiscalCliente(((Cliente) Sesion.get(Campo.ClienteActual)).ClienteClave);
			else
				trueType = (short) Integer.parseInt((String) ((CONHist) Sesion.get(Campo.CONHist)).get("TipoCobranza"));
			
			if (pedido.Tipo == Enumeradores.TiposTransProd.PEDIDO && (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.VENTA || (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO && pedido.TipoFase == TiposFasesDocto.SURTIDO && pedido.VisitaClave == ((Visita) Sesion.get(Campo.VisitaActual)).VisitaClave))){
				EliminarPagoAutomatico(pedido);
				if (conhist.get("Preliquidacion").equals("1"))
				{ // y si <el importe de venta a liquidar es mayor al monto por
					// liquidar>
					// mVista.mostrarError(Mensajes.get("E0590"));
					// TODO: calcular monto total de la pre-liquidacion
					
				}
			}
			

			//Si es venta directa en reparto
			if (pedido.Tipo == Enumeradores.TiposTransProd.PEDIDO && Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO && pedido.TipoFase == TiposFasesDocto.SURTIDO && pedido.DiaClave1 == null){
				EliminarPagoAutomatico(pedido);
				if (conhist.get("Preliquidacion").equals("1"))
				{ // y si <el importe de venta a liquidar es mayor al monto por
					// liquidar>
					// mVista.mostrarError(Mensajes.get("E0590"));
					// TODO: calcular monto total de la pre-liquidacion
					
				}
			}
			
			if (trueType == 1 && pedido.TipoFase != TiposFasesDocto.CAPTURA && pedido.TipoFase != TiposFasesDocto.CAPTURA_ESCRITORIO)
			{
					// restar el total al saldo del cliente
					Transacciones.Pedidos.ActualizarSaldoCliente(((Cliente) Sesion.get(Campo.ClienteActual)).ClienteClave, pedido.Total * -1);
			}
		
			if (pedido.TipoMovimiento == Enumeradores.TiposTransProd.MOV_SIN_INV_EV)
			{ // y asignacion de puntos (3)
				// TODO: administrar puntos
				// calcular puntos
				// eliminar tpddesvendedor
				// Consultas.ConsultasTPDDesVendedor.eliminarPorTransProd(pedido.TransProdID);
			}
			
			if (pedido.Tipo != Enumeradores.TiposTransProd.MOV_SIN_INV_EV && Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO && pedido.TipoFase == 1){
				//solo se marcan los pedidos que se suben para reparto, las ventas no se marcan
				pedido.DiaClave1 = ((Dia) Sesion.get(Campo.DiaActual)).DiaClave;
				pedido.VisitaClave1 =  ((Visita) Sesion.get(Campo.VisitaActual)).VisitaClave;
			} 
			
	
			
		    pedido.TipoFase = 0;
			pedido.TipoMotivo = mVista.getTipoMotivo();
			pedido.FechaCancelacion = Generales.getFechaHoraActual();
			pedido.MFechaHora = Generales.getFechaHoraActual();
			pedido.MUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;
			BDVend.guardarInsertar(pedido);

			
			
			//Eliminar preloquidacion ldelatorre
			//int preLiquidacion = Consultas.ConsultasValidacionPreliquidacion.getCONHist();
			
			int tipoModulo = Integer.parseInt((Sesion.get(Campo.TipoModulo).toString()));
			int tipoIndice = Consultas.ConsultasValidacionPreliquidacion.getModuloMovDetalleTipoIndice((String) Sesion.get(Campo.ModuloMovDetalleClave));
			int CFVTipo = Consultas.ConsultasValidacionPreliquidacion.getTransProdCFVTipo(((Visita) Sesion.get(Campo.VisitaActual)).VisitaClave, ((Dia) Sesion.get(Campo.DiaActual)).DiaClave);
			int clientePagoID = Consultas.ConsultasValidacionPreliquidacion.getTransProdClientePago(((Visita) Sesion.get(Campo.VisitaActual)).VisitaClave, ((Dia) Sesion.get(Campo.DiaActual)).DiaClave);
			int preLiquidacion = (short) Integer.parseInt((String) ((CONHist) Sesion.get(Campo.CONHist)).get("Preliquidacion"));

		//	Log.i(null, "Pre: " + preLiquidacion + " Modulo: " + tipoModulo + " Tipo Indice: " + tipoIndice + " CFVTipo: " + CFVTipo + " ClientePagoID: " + clientePagoID);
			
			if (preLiquidacion == 1)// tiene que estar activado la opcion de PreLiquidacion
			{
				if ((Enumeradores.TiposModulos.VENTA == tipoModulo || Enumeradores.TiposModulos.REPARTO == tipoModulo) && Enumeradores.TiposModuloMovDetalle.PEDIDO == tipoIndice)
				{
					if (Enumeradores.FormasDeVenta.CONTADO == CFVTipo && Enumeradores.FormasDePago.EFECTIVO == clientePagoID)
					{
						if (Consultas.ConsultasValidacionPreliquidacion.validarTotal(((Visita) Sesion.get(Campo.VisitaActual)).VisitaClave, ((Dia) Sesion.get(Campo.DiaActual)).DiaClave))
						{
							//Log.i(null, "Es mayor");
							validarPreliquidacion = true;
							BDVend.commit(); 
						}
						else
						{
							//mVista.mostrarError(Mensajes.get("E0590"));
							//Log.i(null, Mensajes.get("E0590"));
							
							BDVend.rollback();
						}
					}
				}
			}
			
			return validarPreliquidacion;
		}
		catch (Exception e)
		{
			mVista.mostrarError(e.getMessage());
		}
		return validarPreliquidacion;
	}
	
	private void EliminarPagoAutomatico(TransProd oTransProd) throws Exception{
		if(oTransProd.CFVTipo == Enumeradores.FormasDeVenta.CONTADO && Integer.parseInt(oTransProd.ClientePagoId) == Enumeradores.FormasDePago.EFECTIVO){
			if ((short) Integer.parseInt((String) ((CONHist) Sesion.get(Campo.CONHist)).get("TipoCobranza")) == 2)
				trueType = Consultas.ConsultasTransProd.getTipoFiscalCliente(((Cliente) Sesion.get(Campo.ClienteActual)).ClienteClave);
			else
				trueType = (short) Integer.parseInt((String) ((CONHist) Sesion.get(Campo.CONHist)).get("TipoCobranza"));

			if (trueType == 1 && ((CONHist) Sesion.get(Campo.CONHist)).get("PagoAutomatico").equals("1"))
			{
				ISetDatos abonos = Consultas.ConsultasAbnTrp.obtenerAbonos(oTransProd.TransProdID);
				if (abonos.getCount() > 0){
					abonos.moveToFirst(); 
					Abono oAbn = new Abono();
					oAbn.ABNId = abonos.getString("ABNId");
					BDVend.recuperar(oAbn);
					BDVend.recuperar(oAbn, ABNDetalle.class);
					BDVend.recuperar(oAbn, AbnTrp.class);
					
					Cobranza.generarHistorico(oAbn);
					
					Iterator<ABNDetalle> itABD = oAbn.ABNDetalle.iterator();
					while (itABD.hasNext())
					{
						BDVend.eliminar(itABD.next());
					}

					Iterator<AbnTrp> itABT = oAbn.AbnTrp.iterator();
					while (itABT.hasNext())
					{
						BDVend.eliminar(itABT.next());
					}

					BDVend.eliminar(oAbn);	
					Clientes.actualizarSaldoCteActual((oTransProd.Total));
				}
				abonos.close();
			}
		}
	
	}
}
