Public Class FormDepositosGarantia

    Sub New(ByRef prTransProd As TransProd)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        oTransProd = prTransProd
    End Sub

    Private refaVista As Vista
    Private oTransProd As TransProd

#Region "FUNCIONES"

#End Region

#Region "METODOS"
    Private Sub PrepararGrids()
        Dim htTipoDep As New Hashtable
        Dim htUVenta As New Hashtable
        With Me.FlexGridProductos
            .ClipSeparators = vbTab + vbLf
            .Rows.Count = 1
            .Rows.Fixed = 1
            .Cols.Count = 9
            .Cols.Fixed = 0
            .Cols(0).Name = "Clave"
            .Cols(0).AllowEditing = False
            .Cols(0).Width = 60
            .Cols(1).Name = "Nombre"
            .Cols(1).AllowEditing = False
            .Cols(1).Width = 120
            .Cols(2).Name = "CantUnit"
            .Cols(2).Visible = False
            .Cols(3).Name = "UnidadVenta"
            Dim aValores As ArrayList = ValorReferencia.RecuperarLista("UNIDADV")
            If Not IsNothing(aValores) AndAlso aValores.Count > 0 Then
                For Each refDesc As ValorReferencia.Descripcion In aValores
                    htUVenta.Add(refDesc.Id, refDesc.Cadena)
                Next
                'For Each oDr As DataRow In ValorReferencia.RecuperarLista("UNIDADV").Rows
                '    htUVenta.Add(oDr(0), oDr(1))
                'Next
                .Cols(3).DataMap = htUVenta
            End If
            .Cols(3).Width = 100
            .Cols(4).Name = "Factor"
            .Cols(4).Visible = False
            .Cols(5).Name = "Cantidad"
            .Cols(5).AllowEditing = False
            .Cols(5).Width = 80
            .Cols(6).Name = "Precio"
            .Cols(6).Width = 90
            .Cols(7).Name = "TotalRequerido"
            .Cols(7).Format = "c"
            .Cols(7).AllowEditing = False
            .Cols(7).Width = 90
            .Cols(8).Name = "TipoDeposito"
            aValores = ValorReferencia.RecuperarLista("TDEPGARP")
            If Not IsNothing(aValores) AndAlso aValores.Count > 0 Then
                For Each refDesc As ValorReferencia.Descripcion In aValores
                    htTipoDep.Add(refDesc.Id, refDesc.Cadena)
                Next
                'For Each oDr As DataRow In ValorReferencia.RecuperarLista("TDEPGARP").Rows
                '    htTipoDep.Add(oDr(0), oDr(1))
                'Next
                .Cols(8).DataMap = htTipoDep
            End If
            .Cols(8).Width = 100
            aValores = Nothing
        End With
        htTipoDep = Nothing
        With Me.FlexGridDepositos
            .ClipSeparators = vbTab + vbLf
            .Rows.Count = 1
            .Rows.Fixed = 1
            .Cols.Count = 5
            .Cols.Fixed = 0
            .Cols(0).Name = "Clave"
            .Cols(0).Width = 60
            .Cols(1).Name = "Nombre"
            .Cols(1).Width = 120
            .Cols(2).Name = "Precio"
            .Cols(2).Format = "c"
            .Cols(2).Width = 90
            .Cols(3).Name = "Cantidad"
            .Cols(3).Width = 80
            .Cols(4).Name = "Total"
            .Cols(4).Format = "c"
            .Cols(4).Width = 90
        End With
    End Sub

    Private Sub LlenarGridProducto()
        Dim sQuery As New Text.StringBuilder
        sQuery.Append("select PRD.ProductoClave, PRO.Nombre, TPD.Partida, TPD.TipoUnidad, ")
        sQuery.Append("TPD.Cantidad * PRD.Factor as CantUnit, PRD.Factor, TPD.Cantidad ")
        sQuery.Append("from transproddetalle TPD inner join Producto PRO on tpd.productoclave=pro.productoclave ")
        sQuery.Append("inner join ProductoDetalle PRD on PRO.ProductoClave=PRD.ProductoClave and PRD.ProductoClave <> PRD.ProductoDetClave ")
        sQuery.Append("and TPD.TipoUnidad=PRD.PRUTipoUnidad where TransProdId='" & oTransProd.TransProdId & "' and PRO.DepGarantia=1")
        Dim oDt As DataTable = oDBVen.RealizarConsultaSQL(sQuery.ToString, "Productos")
        If oDt.Rows.Count > 0 Then
            With Me.FlexGridProductos
                For Each oDr As DataRow In oDt.Rows
                    'Clave, nombre, cantunit, unidad venta, factor, cantidad, precio, totalrequerido, tipodeposito
                    Dim dPrecio As Double = Me.ObtenerPrecio(oDr("productoClave"), oDr("Partida"), oDr("TipoUnidad"))
                    .AddItem(oDr("ProductoClave").ToString + vbTab + oDr("Nombre").ToString + vbTab + oDr("CantUnit").ToString + vbTab + oDr("TipoUnidad").ToString + vbTab + oDr("Factor").ToString + vbTab + oDr("Cantidad").ToString + vbTab + FormatNumber(dPrecio, 2, , , TriState.True) + vbTab + FormatNumber(oDr("Cantidad") * dPrecio, 2, , , TriState.True) + vbTab + "6")
                Next
            End With
        End If
        oDt.Dispose()
    End Sub
#End Region

#Region "EVENTOS"

#End Region
    Private Sub FormDepositosGarantia_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        [Global].ObtenerFactores(Me)
        [Global].EscalarFuente(Me)
        [Global].EscalarForma(Me)
        If Not Vista.Buscar("FormDepositosGarantia", refaVista) Then
            Exit Sub
        End If

        Me.PrepararGrids()
        Me.LlenarGridProducto()

    End Sub


    Private Sub FlexGridProductos_AfterEdit(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs) Handles FlexGridProductos.AfterEdit
        Select Case e.Col
            Case 3 'Unidad de Venta
                Dim sQuery As New Text.StringBuilder
                sQuery.Append("Select ")
            Case 5 'Cantidad

            Case 8 'Tipo Depósito
        End Select
    End Sub

    Private Function ObtenerPrecio(ByVal pvProductoClave As String, ByVal pvPartida As Integer, ByVal pvTipoUnidad As Integer) As Double
        Dim dPrecio As Double = 0
        Try
            Dim oTPD As New TransProdDetalle(oTransProd.TransProdId, pvProductoClave, pvPartida)
            Dim oLista As New ListasPreciosCliente
            oLista.BuscarPrecio(pvProductoClave, pvTipoUnidad, dPrecio)
        Catch ex As Exception

        End Try
        Return dPrecio
    End Function

    Private Sub FlexGridProductos_ValidateEdit(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.ValidateEditEventArgs) Handles FlexGridProductos.ValidateEdit
        Select Case e.Col
            Case 3 'Unidad Venta
                Dim sQuery As New Text.StringBuilder
                sQuery.Append("Select Distinct PRUTipoUnidad From ProductoDetalle Where ProductoClave='" & Me.FlexGridDepositos.Item(e.Row, "Clave") & "' AND ProductoClave=ProductoDetClave")
                If oDBVen.RealizarConsultaSQL(sQuery.ToString, "Uventa").Select("PRUTipoUnidad=" & Me.FlexGridDepositos.Item(e.Row, e.Col)).Length <= 0 Then
                    e.Cancel = True
                    Exit Sub
                End If

            Case 5 'Cantidad
            Case 8 'Tipo Depósito
        End Select
    End Sub
End Class