Public Class FormasVentaConsignacion
    Implements IDisposable
    Private disposedValue As Boolean = False        ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free unmanaged resources when explicitly called
            End If

            ' TODO: free shared unmanaged resources
        End If
        Me.disposedValue = True
    End Sub

#Region " IDisposable Support "
    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region


    Private oTransProd As TransProd
    Private sVisitaActual As String

    Private Property VisitaActual() As String
        Get
            Return sVisitaActual
        End Get
        Set(ByVal Value As String)
            sVisitaActual = Value
        End Set
    End Property

    Public Sub Capturar(ByVal paroModuloMovDetActual As Modulos.GrupoModuloMovDetalle, ByVal paroCliente As Cliente, ByVal parsVisitaClave As String)
        sVisitaActual = parsVisitaClave
        Me.oTransProd = New TransProd()
        With Me.oTransProd
            .TransProdId = ""
            .VisitaActual = parsVisitaClave
            .ClienteActual = paroCliente
            .ClienteClave = paroCliente.ClienteClave
            .ModuloMovDetalle = paroModuloMovDetActual
            .Tipo = paroModuloMovDetActual.TipoTransProd
            .TipoMovimiento = paroModuloMovDetActual.TipoMovimiento
        End With
        Dim ventaConsig As New FormVentaConsignacion(sVisitaActual)
        ventaConsig.oTransProd = oTransProd
        FormProcesando.PubSubTitulo(oVendedor.NombreModulo)
        If ExistenMovimientos() Then
            FormProcesando.PubSubInformar(gVista.BuscarMensaje("MsgBoxConexion", "Abriendo"), Me.oTransProd.ModuloMovDetalle.Nombre)
            Application.DoEvents()
            ventaConsig.oNavegacion = FormVentaConsignacion.Navegacion.MostrarNavegacion
        Else
            FormProcesando.PubSubInformar(gVista.BuscarMensaje("Procesando", "Creando"), Me.oTransProd.ModuloMovDetalle.Nombre)
            Application.DoEvents()
            ventaConsig.oNavegacion = FormVentaConsignacion.Navegacion.IrACrear
        End If
        If ventaConsig.ShowDialog() = DialogResult.OK Then

        End If
        Me.oTransProd = Nothing
        ventaConsig.Dispose()
        ventaConsig = Nothing
    End Sub
    Private Function ExistenMovimientos() As Boolean
        Dim sConsulta As String
        Dim nMovs As Integer
        sConsulta = "select count(*) as Movs from TransProd "
        sConsulta &= "where ClienteClave='" & Me.oTransProd.ClienteClave & "' and Tipo=" & Me.oTransProd.Tipo
        nMovs = oDBVen.RealizarScalarSQL(sConsulta)
        Return (nMovs > 0)
    End Function
End Class
