package com.amesol.routelite.presentadores.act;

import com.amesol.routelite.actividades.Cobranza;
import com.amesol.routelite.datos.ABNDetalle;
import com.amesol.routelite.datos.AbnTrp;
import com.amesol.routelite.datos.AbnTrpHist;
import com.amesol.routelite.datos.Abono;
import com.amesol.routelite.datos.TransProd;
import com.amesol.routelite.datos.Usuario;
import com.amesol.routelite.datos.basedatos.BDVend;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.Presentador;
import com.amesol.routelite.presentadores.interfaces.ISeleccionPedidosPagoAnticipado;
import com.amesol.routelite.utilerias.Generales;
import com.amesol.routelite.vistas.CapturaCobranzaPedidoAnticipado;
import com.amesol.routelite.vistas.SeleccionPedidosPagoAnticipado;

import java.util.HashMap;
import java.util.Iterator;

/**
 * Created by projas on 06/10/2015.
 */
public class SeleccionarPedidosPagoAnticipado  extends Presentador {

    ISeleccionPedidosPagoAnticipado mVista;
    @Override
    public void iniciar() {

    }

    public SeleccionarPedidosPagoAnticipado(SeleccionPedidosPagoAnticipado seleccionPedidosPagoAnticipado)
    {
        mVista = seleccionPedidosPagoAnticipado;
    }

    public boolean cancelarPedido(String transProdId, short tipoMotivo) {
        try {
            TransProd trp = new TransProd();
            trp.TransProdID = transProdId;
            BDVend.recuperar(trp);

            ISetDatos abt = Consultas.ConsultasAbnTrp.obtenerAbonos(transProdId);

            while (abt.moveToNext()) {
                Abono abn = new Abono();
                abn.ABNId = abt.getString("ABNId");
                BDVend.recuperar(abn);
                BDVend.recuperar(abn, AbnTrp.class);
                BDVend.recuperar(abn, ABNDetalle.class);

                Cobranza.generarHistorico(abn);

                Iterator<ABNDetalle> itABD = abn.ABNDetalle.iterator();
                while (itABD.hasNext()) {
                    BDVend.eliminar(itABD.next());
                }

                Iterator<AbnTrp> itABT = abn.AbnTrp.iterator();
                while (itABT.hasNext()) {
                    BDVend.eliminar(itABT.next());
                }

                BDVend.eliminar(abn);

                trp.Saldo = Generales.getRound(trp.Saldo, 2) + Generales.getRound(abt.getFloat("Importe"), 2);
            }
            abt.close();

            trp.TipoFase = 0;
            trp.FechaCancelacion = Generales.getFechaHoraActual();
            trp.TipoMotivo = tipoMotivo;
            trp.MFechaHora = Generales.getFechaHoraActual();
            trp.MUsuarioID = ((Usuario) Sesion.get(Sesion.Campo.UsuarioActual)).USUId;
            trp.Enviado = false;

            BDVend.guardarInsertar(trp);
            return true;
        } catch (NullPointerException ex2) {
            mVista.mostrarError("Cancelar Pedido: Error de null");
        } catch (Exception ex) {
            mVista.mostrarError("Cancelar Pedido: " + ex.getMessage());
        }
        return false;
    }

    public void confirmarPedido(String transProdId) throws Exception {
        try {
            TransProd transProd = new TransProd();
            transProd.TransProdID = transProdId;
            BDVend.recuperar(transProd);
            transProd.TipoFase = Enumeradores.TiposFasesDocto.CONFIRMADO_POR_EL_VENDEDOR;
            transProd.MFechaHora = Generales.getFechaHoraActual();
            transProd.MUsuarioID = ((Usuario)Sesion.get(Sesion.Campo.UsuarioActual )).USUId;
            transProd.Enviado = false;
            BDVend.guardarInsertar(transProd);

            mVista.mostrarDocumentos();
            BDVend.commit();
        }catch (NullPointerException ex){
            try{
                BDVend.rollback() ;
            }catch(Exception ex2){
                ex.printStackTrace();
            }
            throw new Exception("Confirmar Pedido: Error de null");
        }catch(Exception ex){
            try{
                BDVend.rollback() ;
            }catch(Exception ex2){
                ex.printStackTrace();
            }
            throw new Exception("Confirmar Pedido: " + ex.getMessage());
        }
    }
}
