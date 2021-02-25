package com.selling.movil.modelos;

import io.realm.RealmList;
import io.realm.RealmObject;

/**
 * Created by Eduardo on 18/07/16.
 */
public class Pedido extends RealmObject {

    private int TipoDocumento;
    private String DOCClave;
    private String Cliente;
    private String Folio;
    private int Prioridad;
    private String Stage;
    private String StageClave;
    private String stageComparar;
    private String Estado;
    private RealmList<PedidoDetalle> detalles;


    public int getTipoDocumento() {
        return TipoDocumento;
    }

    public void setTipoDocumento(int tipoDocumento) {
        TipoDocumento = tipoDocumento;
    }

    public String getDOCClave() {
        return DOCClave;
    }

    public void setDOCClave(String DOCClave) {
        this.DOCClave = DOCClave;
    }

    public String getCliente() {
        return Cliente;
    }

    public void setCliente(String cliente) {
        Cliente = cliente;
    }

    public String getFolio() {
        return Folio;
    }

    public void setFolio(String folio) {
        Folio = folio;
    }

    public int getPrioridad() {
        return Prioridad;
    }

    public void setPrioridad(int prioridad) {
        Prioridad = prioridad;
    }

    public String getStage() {
        return Stage;
    }

    public void setStage(String stage) {
        Stage = stage;
    }

    public String getStageClave() {
        return StageClave;
    }

    public void setStageClave(String stageClave) {
        StageClave = stageClave;
    }

    public String getStageComparar() {
        return stageComparar;
    }

    public void setStageComparar(String stageComparar) {
        this.stageComparar = stageComparar;
    }

    public String getEstado() {
        return Estado;
    }

    public void setEstado(String estado) {
        Estado = estado;
    }

    public RealmList<PedidoDetalle> getDetalles() {
        return detalles;
    }

    public void setDetalles(RealmList<PedidoDetalle> detalles) {
        this.detalles = detalles;
    }
}
