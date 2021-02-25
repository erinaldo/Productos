package com.amesol.routelite.presentadores.act;


import java.io.File;
import java.util.ArrayList;
import java.util.List;
import java.util.Map;

import android.database.Cursor;

import com.amesol.routelite.actividades.ValorReferencia;
import com.amesol.routelite.actividades.ValoresReferencia;
import com.amesol.routelite.datos.Cliente;
import com.amesol.routelite.datos.ClienteDomicilio;
import com.amesol.routelite.datos.ConfiguracionRecibo;
import com.amesol.routelite.datos.Dia;
import com.amesol.routelite.datos.Recibo;
import com.amesol.routelite.datos.Ruta;
import com.amesol.routelite.datos.Vendedor;
import com.amesol.routelite.datos.Visita;
import com.amesol.routelite.datos.basedatos.BDVend;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.basedatos.Consultas.ConsultasImpresionTicket;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.Presentador;
import com.amesol.routelite.presentadores.interfaces.IImpresionTicket;

public class ImprimirTicket extends Presentador {
	IImpresionTicket mVista;
	private String mAccion; 
		
		public ImprimirTicket(IImpresionTicket vista, String accion){
			mVista = vista;
			mAccion = accion;
		}
		@Override
		public void iniciar() {
			if((mAccion!= null)&&(mAccion.equals(Enumeradores.Acciones.ACCION_IMPRIMIR_TICKET_CON_VISITA))){
				Cliente cliente = (Cliente)Sesion.get(Campo.ClienteActual);
				
				Dia dia = (Dia) Sesion.get(Campo.DiaActual);
				Visita visita = (Visita)Sesion.get(Campo.VisitaActual);
				
				mVista.setCliente(cliente.Clave + " - " + cliente.RazonSocial);
				mVista.setRuta(((Ruta)Sesion.get(Campo.RutaActual)).Descripcion);			
				mVista.setDia(((Dia)Sesion.get(Campo.DiaActual)).DiaClave);
				
				Cursor datos = obtenerListaDocumentos();
				try{
					mVista.presentarDocumentos(mAccion, datos);
					datos.close();
				}catch (Exception ex){
					mVista.mostrarError(ex.getMessage());
				}
				
				
			}/*else if((mAccion!= null)&&(mAccion.equals(Enumeradores.Acciones.ACCION_RECIBIR_INFO_VENDEDOR))){
				mVista.presentarOpciones(ValoresReferencia.getValores("ACTROL","RecVendedor"),"RecVendedor");
			}*/
		}
		
		
		public IImpresionTicket getIVista(){
			return mVista;
		}
	
		
		private Cursor obtenerListaDocumentos(){
			try{
				String lstTrpTipo = "";
				if ((mAccion!= null)&&(mAccion.equals(Enumeradores.Acciones.ACCION_IMPRIMIR_TICKET_CON_VISITA))){
					lstTrpTipo = ValoresReferencia.getStringVAVClave("TRPTIPO", "Visita");
				}else{
					lstTrpTipo = ValoresReferencia.getStringVAVClave("TRPTIPO", "No Visita");
				}
				
				ISetDatos listaDoc = null;
				if ((mAccion!= null)&&(mAccion.equals(Enumeradores.Acciones.ACCION_IMPRIMIR_TICKET_CON_VISITA))){
					
					String sDiaClave = ((Dia)Sesion.get(Campo.DiaActual)).DiaClave;			
					String sVisitaClave = ((Visita)Sesion.get(Campo.VisitaActual)).VisitaClave;
					
					Sesion.get(Campo.VisitaActual);
					listaDoc = Consultas.ConsultasImpresionTicket.obtenerTicketsConVisita(lstTrpTipo,Integer.parseInt( Sesion.get(Campo.TipoModulo).toString()), ((Cliente) Sesion.get(Campo.ClienteActual)).ClienteClave,  sVisitaClave, sDiaClave);
				}else{
					//listaDoc = Consultas.ConsultasImpresionTicket.obtenerTicketsSinVisita(lstTrpTipo, tipoModulo, clienteClave, visitaClave, diaClave)							
				}

				return (Cursor)listaDoc.getOriginal();
			}
			catch(Exception e){
				return null;
			}
			
		}
		
		
		public String obtenerTipoRecibo(Map<String,String> registro){
			String tipoRecibo ="0";
			
			int tipo =Integer.parseInt(registro.get("Tipo"));
			if ((mAccion!= null)&&(mAccion.equals(Enumeradores.Acciones.ACCION_IMPRIMIR_TICKET_CON_VISITA))){
				if (registro.get("TipoRecibo").equals("TRP")){
					if ((tipo ==3 && !registro.get("TipoFase").equals(3)) || (tipo !=3)){					
						switch ( tipo){
						case 8:
							if (registro.get("FacElec").equals(1)){
								return "24"; // Facturacion Electronica
							}else{
								return "8";  // Facturacion
							}
						case 24:
							if (registro.get("TipoFase").equals(6)){
								return "26"; //Liquidacion
							}else{
								return "25"; //Consignación
							} 
						case 1:
							/* estaban mal los if
							if (Sesion.get(Campo.TipoModulo).equals(Enumeradores.TiposModulos.VENTA)){
								return "1";
							}else if (Sesion.get(Campo.TipoModulo).equals(Enumeradores.TiposModulos.PREVENTA)){
								return "27";
							}else if (Sesion.get(Campo.TipoModulo).equals(Enumeradores.TiposModulos.REPARTO)){
								return "28";
							}*/
							if (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.VENTA){
								return "1";
							}else if (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.PREVENTA){
								return "27";
							}else if (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO){
								return "28";
							}
						default:
							return registro.get("Tipo");					
						}
					}
				}else if (registro.get("TipoRecibo").equals("ABN")){
					return "10"; // Recibo de cobranza
				}
				
			}else if ((mAccion!= null)&&(mAccion.equals(Enumeradores.Acciones.ACCION_IMPRIMIR_TICKET_SIN_VISITA))){
				
			}
				
			/*  If oModo = ModoImpresion.ConVisita Then

		        Else
		                If (Dr("Tipo") = 3 AndAlso Dr("TipoFase") <> 4) OrElse Dr("Tipo") <> 3 Then
		                    'Dim LVI As New ListViewItem(Dr("Folio").ToString)
		                    Dim LVI As New ListViewItem(hHashTable(Dr("Tipo").ToString).ToString)
		                    LVI.Checked = False
		                    LVI.SubItems.Add(Dr("Folio").ToString)
		                    If Dr("tipo") = 8 Then
		                        LVI.SubItems.Add(Format(Dr("FechaFacturacion"), "dd/MM/yyyy"))
		                    ElseIf Dr("Tipo") = 24 Then
		                        If Dr("TipoFase") = 6 Then
		                            LVI.SubItems.Add("26") 'TipoRecibo Liquidacion
		                        Else
		                            LVI.SubItems.Add("25") 'TipoRecibo consignacion
		                        End If
		                    Else
		                        LVI.SubItems.Add(Format(Dr("FechaCaptura"), "dd/MM/yyyy"))
		                    End If
		                    LVI.SubItems.Add(FormatNumber(Dr("Total"), 2))
		                    LVI.SubItems.Add(Dr("TransProdId").ToString)
		                    LVI.SubItems.Add(Dr("Tipo").ToString) 'TipoMovimiento
		                    LVI.SubItems.Add(Dr("Tipo").ToString) 'TipoRecibo
		                    LVI.SubItems.Add("") 'SubEmpresaID
		                    ListViewMovtos.Items.Add(LVI)
		                End If
		            End If*/
			return  tipoRecibo;
		}
		
}
