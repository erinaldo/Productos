#If DEBUG Then
Public Class Prueba
    Public Shared Sub Main(ByVal args As String())
        Dim oMensaje As BASMENLOG.CMensaje
        Dim oConexion As LbConexion.cConexion = LbConexion.cConexion.Instancia
        oConexion.Conectar("Provider=SQLOLEDB;User ID=sa;password=dbsa;Initial Catalog=Route;Data Source=192.168.0.68\SQL2008")
        oMensaje = New BASMENLOG.CMensaje
        oMensaje.LlenarDataSet()
        'lbGeneral.cParametros.UsuarioID = "Admin"
        lbGeneral.cParametros.UsuarioID = "26PKB2C2AHNRELF"
        Dim ventas As New IVentas()
        Dim t As New ERMTRPLOG.cTransProd()
        Dim tabla As DataTable = t.ObtenerVentasCliente("0000100059", DateTime.Now, DateTime.Now, -1)

        ventas.Seleccionar("0000100059", tabla)
    End Sub
End Class
#End If
