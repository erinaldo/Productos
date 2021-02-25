package com.amesol.routelite.actividades;

import java.util.Date;

import com.amesol.routelite.actividades.Enumeradores.Esquema;
import com.amesol.routelite.datos.Cliente;
import com.amesol.routelite.datos.Descuento;
import com.amesol.routelite.datos.Impuesto;
import com.amesol.routelite.datos.TpdDes;
import com.amesol.routelite.datos.TransProd;
import com.amesol.routelite.datos.TransProdDetalle;
import com.amesol.routelite.datos.Usuario;
import com.amesol.routelite.datos.Vendedor;
import com.amesol.routelite.datos.basedatos.BDVend;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.basedatos.Consultas.ConsultasDescuentos;

import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.ConfigParametro;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.utilerias.ControlError;
import com.amesol.routelite.utilerias.Generales;
import com.amesol.routelite.utilerias.KeyGen;
import com.amesol.routelite.vistas.utilerias.ServicesCentral;
import com.amesol.routelite.vistas.utilerias.ServicesCentral.TiposAplicacionImpuestos;
import com.amesol.routelite.vistas.utilerias.ServicesCentral.TiposValoresAplicacionImpuestos;

public class Descuentos {
	
	private static Boolean bEsNuevo=false;

	protected Boolean getEsNuevo() {
		return bEsNuevo;
	}
	public static void setEsNuevo(Boolean bEsNuevo) {
		Descuentos.bEsNuevo = bEsNuevo;
	}
	
	public static boolean ValidarAplicacion(String CampoAplicacion) throws Exception{
		boolean resultado;
		String sModuloMovDetalleClave = (String)Sesion.get(Campo.ModuloMovDetalleClave);
		Vendedor vendedor = (Vendedor) Sesion.get(Campo.VendedorActual);
		ISetDatos datos = Consultas.ConsultasDescuentos.obtenerAplicacionPorModulo(sModuloMovDetalleClave, vendedor.VendedorId, CampoAplicacion);
		
		if(datos.getCount() == 0){
			datos.close();
			return false;
		}
		
		datos.moveToNext();
		int aplicacion = datos.getInt(CampoAplicacion);
		datos.close();
		
		resultado = aplicacion == 1;
		
		return resultado;
	}
	
	
	public static Boolean CalcularDescuentosClientes(Descuento[] oDescuentos,float Impuestos,float Subtotal,TransProd oTransprod,Cliente oCliente) throws Exception  {
		//try {

		boolean marcarDescuento = false;
		
			if(!ValidarAplicacion("AplicaCliente"))
				return true;
			
			for(int i =0; i<oTransprod.TransProdDetalle.size();i++)
			{
				oTransprod.TransProdDetalle.get(i).DesImpuestoT=0;
				oTransprod.TransProdDetalle.get(i).DesImporteT=0;
				for(int j =0; j<oTransprod.TransProdDetalle.get(i).TpdDes.size();j++)
				{


					BDVend.eliminar(oTransprod.TransProdDetalle.get(i).TpdDes.get(j));


				}
				oTransprod.TransProdDetalle.get(i).TpdDes.clear();
			}
			boolean bAplicoDescuento = false;
			for(int i =0;i<oDescuentos.length ;i++)
			{
				if(oDescuentos[i].Tipo==ServicesCentral.TiposDescuento.Inmediato.value)
				{
					if(oDescuentos[i].TipoValor==ServicesCentral.TiposValoresDescuentos.Importe.value)
					{
						float nPorcentaje ;
						nPorcentaje = (oDescuentos[i].ValorAplicacion * 100) / Subtotal;
						for(int j =0; j<oTransprod.TransProdDetalle.size();j++)
						{
							//select TPD.TransProdID, TPD.TransProdDetalleID,'" & refDescuento.DescuentoClave & "'," & nPorcentaje & ", TPD.Subtotal  * " & (nPorcentaje / 100) & ", TPD.Impuesto * " & (nPorcentaje / 100) & "," & refDescuento.Jerarquia & " , 0, getdate(),'" & oVendedor.UsuarioId & "',0 from TransProdDetalle TPD where TPD.TransProdID ='" & parsTransProdID & "' and TPD.Subtotal>0 ")
							if(oTransprod.TransProdDetalle.get(j).getSubTotal()>0)
							{
								oTransprod.TransProdDetalle.get(j).DesImpuestoT=oTransprod.TransProdDetalle.get(j).DesImpuestoT+(oTransprod.TransProdDetalle.get(j).Impuesto * nPorcentaje/100 );
								oTransprod.TransProdDetalle.get(j).DesImporteT=oTransprod.TransProdDetalle.get(j).DesImporteT+(oTransprod.TransProdDetalle.get(j).getSubTotal() * nPorcentaje/100);

								TpdDes oTpdDes = new TpdDes(oTransprod.TransProdDetalle.get(j).TransProdID,
										oTransprod.TransProdDetalle.get(j).TransProdDetalleID,
										oDescuentos[i].DescuentoClave,
										nPorcentaje,
										oTransprod.TransProdDetalle.get(j).getSubTotal() *(nPorcentaje/100),
										oTransprod.TransProdDetalle.get(j).Impuesto*(nPorcentaje/100),
										(short) oDescuentos[i].Jerarquia,
										(short) 0,
										Generales.getFechaHoraActual(),
										((Usuario)Sesion.get(Campo.UsuarioActual)).USUId,
										false
										);
								BDVend.guardarInsertar(oTransprod.TransProdDetalle.get(j));
								BDVend.guardarInsertar(oTpdDes);
								oTransprod.TransProdDetalle.get(j).TpdDes.add(oTpdDes);
								marcarDescuento = true;
								bAplicoDescuento = true;

							}
						}

					}
					//Porcentaje
					else
					{

						if(oDescuentos[i].PermiteCascada==0) //!=0)
						{
							for(int j =0; j<oTransprod.TransProdDetalle.size();j++)
							{
								// oDBVen.EjecutarComandoSQL("INSERT INTO TpdDes select TPD.TransProdID, TPD.TransProdDetalleID,'" & refDescuento.DescuentoClave & "'," & refDescuento.ValorAplicacion & ", TPD.Subtotal  * " & (refDescuento.ValorAplicacion / 100) & ", TPD.Impuesto * " & (refDescuento.ValorAplicacion / 100) & "," & refDescuento.Jerarquia & " , 0, getdate(),'" & oVendedor.UsuarioId & "',0 from TransProdDetalle TPD where TransProdID ='" & parsTransProdID & "' and Subtotal>0")
								//oDBVen.EjecutarComandoSQL("UPDATE TransProdDetalle set DesImporteT = DesImporteT + (Subtotal  * " & (refDescuento.ValorAplicacion / 100) & "), DesImpuestoT = DesImpuestoT + (Impuesto  * " & (refDescuento.ValorAplicacion / 100) & ") where TransProdID ='" & parsTransProdID & "' and Subtotal>0")
								if(oTransprod.TransProdDetalle.get(j).getSubTotal()>0)
								{
									oTransprod.TransProdDetalle.get(j).DesImpuestoT=oTransprod.TransProdDetalle.get(j).DesImpuestoT+(oTransprod.TransProdDetalle.get(j).Impuesto * (oDescuentos[i].ValorAplicacion/100));
									oTransprod.TransProdDetalle.get(j).DesImporteT=oTransprod.TransProdDetalle.get(j).DesImporteT+(oTransprod.TransProdDetalle.get(j).getSubTotal() * (oDescuentos[i].ValorAplicacion/100));

									TpdDes oTpdDes = new TpdDes(oTransprod.TransProdDetalle.get(j).TransProdID,
											oTransprod.TransProdDetalle.get(j).TransProdDetalleID,
											oDescuentos[i].DescuentoClave,
											oDescuentos[i].ValorAplicacion,
											oTransprod.TransProdDetalle.get(j).getSubTotal()*(oDescuentos[i].ValorAplicacion/100),
											oTransprod.TransProdDetalle.get(j).Impuesto*(oDescuentos[i].ValorAplicacion/100),
											(short) oDescuentos[i].Jerarquia,
											(short) 0,
											Generales.getFechaHoraActual(),
											((Usuario)Sesion.get(Campo.UsuarioActual)).USUId,
											false
											);
									BDVend.guardarInsertar(oTransprod.TransProdDetalle.get(j));
									BDVend.guardarInsertar(oTpdDes);
									oTransprod.TransProdDetalle.get(j).TpdDes.add(oTpdDes);
									marcarDescuento = true;
									bAplicoDescuento = true;

								}
							}
						}
						else
						{
							for(int j =0; j<oTransprod.TransProdDetalle.size();j++)
							{
								//oDBVen.EjecutarComandoSQL("INSERT INTO TpdDes select TPD.TransProdID, TPD.TransProdDetalleID,'" & refDescuento.DescuentoClave & "'," & refDescuento.ValorAplicacion & ", (TPD.Subtotal - TPD.DesImporteT) * " & (refDescuento.ValorAplicacion / 100) & ", (TPD.Impuesto - TPD.DesImpuestoT) * " & (refDescuento.ValorAplicacion / 100) & " ," & refDescuento.Jerarquia & " ,1,getdate(),'" & oVendedor.UsuarioId & "',0 from TransProdDetalle TPD where TransProdID ='" & parsTransProdID & "' and Subtotal>0")
								//oDBVen.EjecutarComandoSQL("UPDATE TransProdDetalle set DesImporteT = DesImporteT + ((Subtotal - DesImporteT) * " & (refDescuento.ValorAplicacion / 100) & "), DesImpuestoT = DesImpuestoT + ((Impuesto - DesImpuestoT) * " & (refDescuento.ValorAplicacion / 100) & ") where TransProdID ='" & parsTransProdID & "' and Subtotal>0")
								if(oTransprod.TransProdDetalle.get(j).getSubTotal()>0)
								{
									//Se cambió el orden porque se descontaba doble el descuento en este caso
									TpdDes oTpdDes = new TpdDes(oTransprod.TransProdDetalle.get(j).TransProdID,
											oTransprod.TransProdDetalle.get(j).TransProdDetalleID,
											oDescuentos[i].DescuentoClave,
											oDescuentos[i].ValorAplicacion,
											(oTransprod.TransProdDetalle.get(j).getSubTotal()-oTransprod.TransProdDetalle.get(j).DesImporteT)*(oDescuentos[i].ValorAplicacion/100),
											(oTransprod.TransProdDetalle.get(j).Impuesto-oTransprod.TransProdDetalle.get(j).DesImpuestoT)*(oDescuentos[i].ValorAplicacion/100),
											(short) oDescuentos[i].Jerarquia,
											(short) 0,
											Generales.getFechaHoraActual(),
											((Usuario)Sesion.get(Campo.UsuarioActual)).USUId,
											false
											);
									
									oTransprod.TransProdDetalle.get(j).DesImpuestoT=oTransprod.TransProdDetalle.get(j).DesImpuestoT+((oTransprod.TransProdDetalle.get(j).Impuesto-oTransprod.TransProdDetalle.get(j).DesImpuestoT) * (oDescuentos[i].ValorAplicacion/100));
									oTransprod.TransProdDetalle.get(j).DesImporteT=oTransprod.TransProdDetalle.get(j).DesImporteT+((oTransprod.TransProdDetalle.get(j).getSubTotal()-oTransprod.TransProdDetalle.get(j).DesImporteT) * (oDescuentos[i].ValorAplicacion/100));									
									
									BDVend.guardarInsertar(oTransprod.TransProdDetalle.get(j));
									BDVend.guardarInsertar(oTpdDes);
									oTransprod.TransProdDetalle.get(j).TpdDes.add(oTpdDes);
									marcarDescuento = true;
									bAplicoDescuento = true;

								}
							}

						}
					}
				}
				try{
					if (((ConfigParametro) Sesion.get(Sesion.Campo.ConfigParametro)).existeParametro("AplicarSoloPrimerDescuentoCte")&& ((ConfigParametro) Sesion.get(Sesion.Campo.ConfigParametro)).get("AplicarSoloPrimerDescuentoCte").equals("1") && bAplicoDescuento){
						break;
					}
				}catch(Exception ex){

				}
			}
		//} catch (Exception e) {
			//e.printStackTrace();
			//return false;

		//}
		if(marcarDescuento){
			oTransprod.Descuento = true;
			BDVend.guardarInsertar(oTransprod);
		}

		return true;
	}
	//Public Function CalcularAplicablesAlCliente(ByRef refparaDescuentos As ArrayList, ByVal parnSubTotal As Decimal, ByVal parnImpuesto As Decimal, ByVal parsTransProdID As String) As Boolean
	public static Descuento[] BuscarDescuentosClientes(Cliente oCliente) throws Exception {
	
		 Descuento[] Descuentos= 	ConsultasDescuentos.BuscarDescuentosCliente(oCliente.ClienteClave,bEsNuevo);
		 if(Descuentos==null || Descuentos.length ==0)
		 {
			String sEsquemas= Esquemas.ObtenerEsquemas(oCliente.ClienteClave,Enumeradores.Esquema.TipoEsquema.Cliente);
			 Descuentos= ConsultasDescuentos.BuscarDescuentosClientePorEsquema(oCliente.ClienteClave,sEsquemas,bEsNuevo);
		 }
			return 	Descuentos; 
	}

	
	public static Descuento BuscarDescuentosProductos(String ProductoClave) throws Exception {
		Descuento oDescuentos = null;

		if (ValidarAplicacion("AplicaProducto"))
		{
			//Descuento  oDescuentos= 	ConsultasDescuentos.BuscarDescuentosProducto(ProductoClave);
			oDescuentos = ConsultasDescuentos.BuscarDescuentosProducto(ProductoClave);
			if (oDescuentos == null)
			{
				String sEsquemas = Esquemas.ObtenerEsquemas(ProductoClave, Enumeradores.Esquema.TipoEsquema.Producto);
				oDescuentos = ConsultasDescuentos.BuscarDescuentosProductoPorEsquema(sEsquemas, bEsNuevo);
			}
		}
		return oDescuentos;
	}
	
	public static float CalcularDescuentosProducto(Descuento oDescuento,float subtotal,float cantidad) throws Exception
	{
//		
//	    		refparoDescuento.PorcentajeCalculado = 0
//                refparoDescuento.ImporteCalculado = refparoDescuento.ValorAplicacion
//            Case ServicesCentral.TiposValoresDescuentos.Porcentaje
//                refparoDescuento.PorcentajeCalculado = refparoDescuento.ValorAplicacion
//                refparoDescuento.ImporteCalculado = nBase * (refparoDescuento.ValorAplicacion / 100)
//        End Select
//        refparImporteDescuento = refparoDescuento.ImporteCalculado
	
	if(oDescuento == null)
		return 0;
	
	if(!ValidarAplicacion("AplicaProducto"))
		return 0;
	
	if(oDescuento.TipoValor==ServicesCentral.TiposValoresDescuentos.Importe.value)
	{
		
		oDescuento.PorcentajeCalculado =0;
		oDescuento.ImporteCalculado =oDescuento.ValorAplicacion;
		
	}
	else
	{
		oDescuento.ImporteCalculado =oDescuento.ValorAplicacion;
		oDescuento.ImporteCalculado =subtotal * (oDescuento.ValorAplicacion/100);
	
	}
	
		return oDescuento.ImporteCalculado;
	}
	
	
	

	





}
