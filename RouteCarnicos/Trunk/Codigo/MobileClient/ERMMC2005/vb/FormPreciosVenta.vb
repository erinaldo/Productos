Public Class FormPreciosVenta

#Region "Variables"
    Dim refaVista As Vista
    Private sTransProdID As String
#End Region

#Region "Propiedades"
    Public Property Transaccion() As SqlServerCe.SqlCeTransaction
        Get
            Return oDBVen.Transaccion
        End Get
        Set(ByVal Value As SqlServerCe.SqlCeTransaction)
            oDBVen.Transaccion = Value
        End Set
    End Property

#End Region


#Region "Eventos"


    Private Sub ButtonRegresar_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonRegresar.Click
        Me.Close()
    End Sub

    Private Sub FormPreciosVenta_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        Me.Transaccion = Nothing
        If oDBVen.oConexion.State = ConnectionState.Open Then
            oDBVen.oConexion.Close()
        End If
    End Sub


    Private Sub FormPreciosVenta_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        [Global].ObtenerFactores(Me)
        [Global].EscalarFuente(Me)
        [Global].EscalarForma(Me)

        If Not Vista.Buscar("FormPrecioVenta", refaVista) Then
            Cursor.Current = System.Windows.Forms.Cursors.Default
            Exit Sub
        End If

        refaVista.ColocarEtiquetasForma(Me)

        If oDBVen.oConexion.State = ConnectionState.Closed Then
            oDBVen.oConexion.Open()
        End If
        Me.Transaccion = oDBVen.oConexion.BeginTransaction()

        ConfiguraGrid()
        fgMovimientos.Rows.Count = 1
        Dim dt As DataTable = oDBVen.RealizarConsultaSQL("select Producto.ProductoClave,Producto.Nombre,ProductoUnidad.PRUTipoUnidad from productoUnidad inner join Producto on  productoUnidad.ProductoClave =  producto.ProductoClave where TipoEstado = 1 order by Producto.ProductoClave ", "ProductoUnidad")
        Dim sProductoClave As String = ""
        fgMovimientos.Redraw = False
        Dim r As C1.Win.C1FlexGrid.Row
        Dim cs As C1.Win.C1FlexGrid.CellStyle = fgMovimientos.Styles.Add("padres")
        cs.BackColor = Drawing.Color.Aqua

        For Each dr As DataRow In dt.Rows
            If sProductoClave <> dr("ProductoClave").ToString Then
                sProductoClave = dr("ProductoClave").ToString
                r = fgMovimientos.Rows.Add
                r.IsNode = True
                r.Node.Level = 0
                r.AllowEditing = False
                r.Style = cs


                With fgMovimientos
                    .Item(r.Index, 0) = dr("ProductoClave")
                    .Item(r.Index, 1) = dr("Nombre")
                End With
            End If
            Dim r2 As C1.Win.C1FlexGrid.Row = fgMovimientos.Rows.Add
            r2.IsNode = True
            r2.Node.Level = 1
            With fgMovimientos
                .Item(r2.Index, 0) = ValorReferencia.BuscarEquivalente("UNIDADV", dr("PRUTipoUnidad"))
                .Item(r2.Index, 1) = 0
                .Item(r2.Index, 2) = 0
                .Item(r2.Index, 3) = False
            End With
        Next
        dt.Dispose()
        fgMovimientos.Redraw = True
        Cursor.Current = System.Windows.Forms.Cursors.Default
    End Sub
    Private Sub fgMovimientos_KeyPressEdit(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.KeyPressEditEventArgs) Handles fgMovimientos.KeyPressEdit
        If fgMovimientos.Rows(fgMovimientos.Row).Node.Level = 1 And (e.Col = 1 Or e.Col = 2) Then
            If Char.IsLetter(e.KeyChar) = True Then
                e.Handled = True
            End If
        End If
    End Sub

    'Private Sub fgMovimientos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles fgMovimientos.KeyDown
    '    MsgBox(e.KeyCode)
    'End Sub
    Private Sub fgMovimientos_RowColChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles fgMovimientos.RowColChange
        If fgMovimientos.Row <= 0 Then Exit Sub

        Try
            If fgMovimientos.Rows(fgMovimientos.Row).Node.Level = 0 Then
                fgMovimientos.AutoSearch = C1.Win.C1FlexGrid.AutoSearchEnum.FromCursor
                'ModuleMain.msgWin.CambiarAlpha()
            Else
                fgMovimientos.AutoSearch = C1.Win.C1FlexGrid.AutoSearchEnum.None
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ButtonContinuar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonContinuar.Click
        GuardarEncabezado()
        Dim i As Integer
        For i = 0 To fgMovimientos.Rows.Count - 1
            If fgMovimientos.Rows(i).Node.Level = 1 Then

            End If
        Next
    End Sub

#End Region

#Region "Metodos"

    Private Function GuardarEncabezado() As Boolean
        Dim sComandoSQL As New System.Text.StringBuilder
        Try
            ' Buscar el TransProdId, para ver si ya existia
            Dim DataTableTrans As DataTable
            DataTableTrans = oDBVen.RealizarConsultaSQL("SELECT TransProdId FROM TransProd WHERE TransProdId='" & sTransProdID & "'", "TransProd")
            If DataTableTrans.Rows.Count > 0 Then
                ' Ya existe, actualizar
                sComandoSQL.Append("UPDATE TransProd SET ")
                sComandoSQL.Append("Folio='" & Me.TextBoxFolio.Text & "',")
                'sComandoSQL.Append("PCEModuloMovDetClave='" & Me.ModuloMovDetalle.ModuloMovDetalleClave & "',")
                sComandoSQL.Append("TipoFase=" & ServicesCentral.TiposFasesPedidos.Captura & ",")
                'sComandoSQL.Append("Notas='" & Me.TextBoxNotas.Text & "',")
                sComandoSQL.Append("MFechaHora=" & UniFechaSQL(Now) & ",")
                sComandoSQL.Append("MUsuarioID='" & oVendedor.UsuarioId & "',Enviado=0 ")
                sComandoSQL.Append("WHERE TransProdId='" & sTransProdID & "'")
            Else
                ' No existe, crear
                sComandoSQL.Append("INSERT INTO TransProd (TransProdID,DiaClave, Folio, Tipo,  TipoFase, TipoMovimiento, FechaCaptura, FechaHoraAlta,Total, MFechaHora, MUsuarioID) VALUES (")
                sComandoSQL.Append("'" & sTransProdID & "',")
                sComandoSQL.Append("'" & oDia.DiaActual & "',")
                'sComandoSQL.Append("'" & Me.ModuloMovDetalle.ModuloMovDetalleClave & "',")
                sComandoSQL.Append("'" & Me.TextBoxFolio.Text & "',")
                sComandoSQL.Append("17,")
                sComandoSQL.Append(ServicesCentral.TiposFasesPedidos.Captura & ",")
                sComandoSQL.Append("0,")
                sComandoSQL.Append(UniFechaSQL(PrimeraHora(Now)) & ",")
                sComandoSQL.Append(UniFechaSQL(Now) & ",")
                sComandoSQL.Append("0,")
                'sComandoSQL.Append("'" & Me.TextBoxNotas.Text & "',")
                sComandoSQL.Append(UniFechaSQL(Now) & ",")
                sComandoSQL.Append("'" & oVendedor.UsuarioId & "'")
                sComandoSQL.Append(")")
                'Folio.Confirmar(ServicesCentral.TiposFolios.General, oModuloMovDetalle.ModuloMovDetalleClave)
            End If
            DataTableTrans.Dispose()
            oDBVen.EjecutarComandoSQL(sComandoSQL.ToString)
            Return True
        Catch ExcA As SqlServerCe.SqlCeException
            MsgBox(ExcA.Message & ": " & sComandoSQL.ToString, MsgBoxStyle.Critical, "AgregarProducto")
        Catch ExcB As Exception
            MsgBox(ExcB.Message & ": " & sComandoSQL.ToString, MsgBoxStyle.Critical, "AgregarProducto")
        End Try
    End Function

    'Private Sub GuardarDetalleProductos(ByVal pariSemilla As Integer, ByVal parsTransProdDetalleID As String, ByVal parsProductoClave As String, ByVal pariTipoUnidad As Integer, ByVal pardCantidad As Double, ByVal pardPrecio As Double, ByVal parbPromocion As Boolean)
    '    Dim sComandoSQL As New System.Text.StringBuilder
    '    Dim blnNuevo As Boolean
    '    Try
    '        'If refparoFormPedirProducto.Partida = 0 Then
    '        '    ' Es una nueva partida, obtenerla
    '        '    If Not Folio.ObtenerTransProdPartida(refparoFormPedirProducto.TransProdId, refparoFormPedirProducto.Producto.ProductoClave, refparoFormPedirProducto.Partida) Then
    '        '        Exit Try
    '        '    End If
    '        '    blnNuevo = True
    '        'Else
    '        '    blnNuevo = False
    '        'End If
    '        'Dim nPrecio As Single = 0
    '        'Dim iCantidad As Integer
    '        'Dim nImpuesto As Single = 15
    '        ' Obtener los productos a actualizar
    '        'For Each refProducto In refparoFormPedirProducto.DetailViewUnidades.Items
    '        'With refProducto
    '        sComandoSQL = New System.Text.StringBuilder
    '        'If IsNumeric(.Text) Then
    '        'iCantidad = refProducto.Value
    '        ' Si la cantidad es cero
    '        'If pariPartida = 0 Then
    '        '    ' Si ya estaba capturado
    '        '    If .TransProdDetalleID <> "" Then
    '        '        ' Borrarlo
    '        '        sComandoSQL.Append("DELETE FROM TransProdDetalle WHERE TransProdId='" & refparoFormPedirProducto.TransProdId & "' AND TransProdDetalleID='" & .TransProdDetalleID & "'")
    '        '    End If
    '        'Else
    '        ' La cantidad es valida, guardarla. Si no estaba capturada
    '        If parsTransProdDetalleID = "" Then
    '            ' Obtener un nuevo folio
    '            'If Not Folio.ObtenerTransProdDetalleId(refparoFormPedirProducto.TransProdId, .TransProdDetalleID) Then
    '            '    Exit For
    '            'End If
    '            ' Crear la cadena para insertar el valor
    '            sComandoSQL.Append("INSERT INTO TransProdDetalle (TransProdID, TransProdDetalleID, ProductoClave, TipoUnidad, Partida, Cantidad, Precio, Subtotal, Total, MFechaHora, MUsuarioID) VALUES (")
    '            sComandoSQL.Append("'" & sTransProdID & "',")
    '            sComandoSQL.Append("'" & oApp.KEYGEN(pariSemilla) & "',")
    '            sComandoSQL.Append("'" & parsProductoClave & "',")
    '            sComandoSQL.Append(pariTipoUnidad & ",") ' TipoUnidad
    '            sComandoSQL.Append(pardCantidad & ",") ' Cantidad
    '            sComandoSQL.Append(pardPrecio & ",") ' Precio
    '            sComandoSQL.Append("0,") ' Subtotal
    '            sComandoSQL.Append("0,")   ' Total
    '            sComandoSQL.Append(UniFechaSQL(Now) & ",")
    '            sComandoSQL.Append("'" & oVendedor.UsuarioId & "')")
    '        Else
    '            ' Actualizar el registro
    '            sComandoSQL.Append("UPDATE TransProdDetalle SET ")
    '            sComandoSQL.Append("DescuentoClave=NULL,")
    '            sComandoSQL.Append("Cantidad=" & iCantidad & ",")
    '            sComandoSQL.Append("Precio=" & (nPrecio * .Factor) & ",")
    '            sComandoSQL.Append("DescuentoPor=" & nImpuesto & ",")
    '            sComandoSQL.Append("DescuentoImp=" & ((iCantidad * nPrecio) * .Factor * (nImpuesto / 100)) & ",")
    '            sComandoSQL.Append("Subtotal=" & (iCantidad * nPrecio) * .Factor & ",")
    '            sComandoSQL.Append("Total=" & ((iCantidad * nPrecio * (1 + (nImpuesto / 100)))) * .Factor & ",")
    '            sComandoSQL.Append("MFechaHora=" & UniFechaSQL(Now) & ",")
    '            sComandoSQL.Append("MUsuarioID='" & oVendedor.UsuarioId & "',Enviado=0 ")
    '            sComandoSQL.Append("WHERE TransProdID='" & refparoFormPedirProducto.TransProdId & "' AND TransProdDetalleID='" & .TransProdDetalleID & "'")
    '        End If
    '        'End If
    '        'End If
    '        'End With
    '        ' Guardar los productos
    '        Try
    '            If sComandoSQL.ToString <> "" Then
    '                oDBVen.EjecutarComandoSQL(sComandoSQL.ToString)
    '            End If
    '        Catch ex As Exception
    '            MsgBox(ex.Message, MsgBoxStyle.Information, "GuardarProducto")
    '        End Try
    '        'Next
    '        ' Actualizar el inventario
    '        'Dim iCantidadAnterior As Integer = 0
    '        'For Each refProducto In refparoFormPedirProducto.DetailViewUnidades.Items
    '        '    With refProducto
    '        '        iCantidad = refProducto.Value
    '        '        If Not (blnNuevo And iCantidad = 0) Then
    '        '            iCantidadAnterior = refProducto.ValorAnterior
    '        '            Inventario.ObtenerCantidadAActualizar(oModuloMovDetalle.TipoMovimiento, iCantidad, iCantidadAnterior)
    '        '            Inventario.ActualizarInventario(refparoFormPedirProducto.Producto.ProductoClave, .TipoUnidad, iCantidad, oModuloMovDetalle.TipoTransProd, oModuloMovDetalle.TipoMovimiento, oVendedor.AlmacenId)
    '        '        End If
    '        '    End With
    '        'Next
    '    Catch ExcA As SqlCeException
    '        MsgBox(ExcA.Message & ": " & sComandoSQL.ToString, MsgBoxStyle.Critical, "GuardarProducto")
    '    Catch ExcB As Exception
    '        MsgBox(ExcB.Message & ": " & sComandoSQL.ToString, MsgBoxStyle.Critical, "GuardarProducto")
    '    End Try
    '    sComandoSQL = Nothing
    'End Sub
    Private Sub ConfiguraGrid()
        With fgMovimientos
            .Redraw = False
            Dim f As Drawing.Font = .Font
            .Styles.Normal.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.None
            .Styles.Normal.Trimming = Drawing.StringTrimming.EllipsisCharacter
            .AllowEditing = True
            .Rows.Count = 1
            .Cols.Fixed = 0
            .Cols.Count = 4
            .Cols(0).Width = 70
            .Cols(0).Caption = "Unidad"
            .Cols(0).AllowEditing = False
            .Cols(1).Width = 70
            .Cols(1).Caption = "Cantidad"
            .Cols(2).Width = 100
            .Cols(2).Caption = "Precio"
            .Cols(3).Caption = "Promocion"
            .Cols(3).DataType = GetType(Boolean)

            .SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
            .ExtendLastCol = True
            .Styles.Normal.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.LeftCenter
            .Styles.Normal.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.None
            ' initialize outline tree
            .Tree.Column = 0
            .Tree.Style = C1.Win.C1FlexGrid.TreeStyleFlags.SimpleLeaf
            .AutoResize = True
            .Redraw = True
        End With
    End Sub
#End Region




End Class