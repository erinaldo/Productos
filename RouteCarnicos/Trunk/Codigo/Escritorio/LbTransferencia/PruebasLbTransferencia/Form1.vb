Public Class Form1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim oTrans As New LbTransferencia.cTransferencia
        oTrans.TransferirAddenda("http://www2.soriana.com/integracion/recibecfd/wseDocRecibo.asmx", "CT005598.xml", "C:\Facturacion Electronica\JerseyF3\XML", LbTransferencia.cTransferencia.TipoAddenda.Soriana)
    End Sub
End Class
