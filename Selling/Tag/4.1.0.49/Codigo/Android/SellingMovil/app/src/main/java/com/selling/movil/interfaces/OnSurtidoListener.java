package com.selling.movil.interfaces;

/**
 * Created by Eduardo on 20/07/16.
 */
public interface OnSurtidoListener {
    void onItemListClick(String...parametros);
    void onStandBySuccess(String...parametros);
    void onSolicitarPedido(String...parametros);
    void onDocumentoTerminado();
    void onRefrescarPedidos(String...parametros);
}
