Public Class FormSeleccionarPromociones
#Region "Variables"
    Dim refaVista As Vista
    Dim dtProductos As DataTable
    Dim dCantidadMaxima As Double
    Dim dTotal As Double = 0
    Dim blnSeleccionarProducto As Boolean
    Dim blnCapturaCantidad As Boolean
    Dim sPromocionNombre As String = String.Empty
    Dim iCantidadxGrupo As Integer
    Dim blnCambiosManuales As Boolean = False
    Dim blnPendienteEntrega As Boolean = False
    Dim blnValidarExistencia As Boolean = False
#End Region

    Public Sub New(ByRef refpardtProductos As DataTable, ByVal pardCantidadMaxima As Double, ByVal parbSeleccionarProducto As Boolean, ByVal parbCapturaCantidad As Boolean, ByVal parsPromocionNombre As String, ByVal parbPendienteEntrega As Boolean, ByVal parbValidarExistencia As Boolean, Optional ByVal pariCantidadxGrupo As Integer = 1)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        dtProductos = refpardtProductos
        dCantidadMaxima = pardCantidadMaxima
        blnSeleccionarProducto = parbSeleccionarProducto
        blnCapturaCantidad = parbCapturaCantidad
        sPromocionNombre = parsPromocionNombre
        Me.LabelNombre.Text = parsPromocionNombre
        iCantidadxGrupo = pariCantidadxGrupo

        Me.LabelTotal.Visible = blnSeleccionarProducto
        Me.TextBoxTotal.Visible = blnSeleccionarProducto

        Me.LabelMaximo.Visible = blnSeleccionarProducto
        Me.lblMaximo.Visible = blnSeleccionarProducto
        blnPendienteEntrega = parbPendienteEntrega
        blnValidarExistencia = parbValidarExistencia
    End Sub

    Private Sub ConfiguraGridPromociones()
        With fgPromociones
            .Redraw = False
            Dim f As Drawing.Font = .Font
            .Styles.Normal.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.None
            .Styles.Normal.Trimming = Drawing.StringTrimming.EllipsisCharacter

            .Cols.Count = 9
            .Cols.Fixed = 0
            .Rows.Count = 1
            .AllowEditing = True

            .Cols(0).DataType = GetType(Boolean)
            .Cols(0).Caption = ""
            .Cols(0).Width = 20
            .Cols(0).Name = "Seleccionar"
            .Cols(0).AllowEditing = blnSeleccionarProducto
            .Cols(1).Caption = refaVista.BuscarMensaje("MsgBox", "Clave")
            .Cols(1).Name = "ProductoClave"
            .Cols(1).Width = 50
            .Cols(1).AllowEditing = False
            .Cols(2).Caption = refaVista.BuscarMensaje("MsgBox", "Nombre")
            .Cols(2).Name = "Nombre"
            .Cols(2).Width = 100
            .Cols(2).AllowEditing = False
            .Cols(3).Caption = refaVista.BuscarMensaje("MsgBox", "Cantidad")
            .Cols(3).Name = "Cantidad"
            .Cols(3).Width = 50
            .Cols(3).DataType = GetType(Double)
            If (blnSeleccionarProducto And blnCapturaCantidad) Then
                .Cols(3).AllowEditing = True
            Else
                .Cols(3).AllowEditing = False

            End If

            .Cols(4).Visible = True
            .Cols(4).Caption = refaVista.BuscarMensaje("MsgBox", "Existencia")
            .Cols(4).DataType = GetType(Double)
            .Cols(4).Width = 50
            .Cols(4).Name = "Existencia"
            .Cols(4).AllowEditing = False
            If Not blnValidarExistencia Then
                .Cols(4).Visible = False
            End If

            .Cols(5).Caption = refaVista.BuscarMensaje("MsgBox", "Unidad")
            .Cols(5).Name = "PRUTipoUnidad"
            .Cols(5).Width = 80
            .Cols(5).AllowEditing = False
            Dim ValoresTipo As New Hashtable
            'Dim aRows As DataRowCollection = ValorReferencia.RecuperarLista("UNIDADV", "").Rows
            Dim aRows As ArrayList = ValorReferencia.RecuperarListaArray("UNIDADV")
            'For Each dr As DataRow In aRows
            '    ValoresTipo.Add(dr(0), dr(1))
            'Next
            If Not IsNothing(aRows) AndAlso aRows.Count > 0 Then
                For Each oValor As ValorReferencia.Descripcion In aRows
                    ValoresTipo.Add(oValor.Id, oValor.Cadena)
                Next
                .Cols(5).DataMap = ValoresTipo
            End If
            aRows = Nothing

            .Cols(6).Visible = False
            .Cols(6).DataType = GetType(Double)
            .Cols(6).Name = "Factor"

            .Cols(7).Visible = False
            .Cols(7).DataType = GetType(Double)
            .Cols(7).Name = "CantidadAnterior"

            .Cols(8).Visible = False
            .Cols(8).DataType = GetType(Boolean)
            .Cols(8).Name = "Obligatorio"


            .SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
            .ExtendLastCol = True
            .Styles.Normal.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.LeftCenter
            .Styles.Normal.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.None
            ' initialize outline tree
            .Tree.Column = 0
            .Tree.Style = C1.Win.C1FlexGrid.TreeStyleFlags.SimpleLeaf
            .Redraw = True
        End With
    End Sub

    Private Sub FormSeleccionarPromociones_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        [Global].ObtenerFactores(Me)
        [Global].EscalarFuente(Me)
        [Global].EscalarForma(Me)
        If Not Vista.Buscar("FormSeleccionarPromociones", refaVista) Then
            Exit Sub
        End If
        ' Recuperar los rótulos y elementos de la pantalla desde la base de datos Sys
        refaVista.ColocarEtiquetasForma(Me)
        Me.MenuItemRegresar.Text = ButtonRegresar.Text
        blnCambiosManuales = True
        Me.fgPromociones.AutoResize = True
        ConfiguraGridPromociones()
        LlenaProductos()
        If blnCapturaCantidad Then
            lblMaximo.Text = dCantidadMaxima * iCantidadxGrupo
        Else
            LabelMaximo.Visible = False
            lblMaximo.Visible = False
        End If

        blnCambiosManuales = False
        'Me.fgPromociones.DataSource = dtProductos
        'ConfiguraGridPromociones()
    End Sub

    Private Sub LlenaProductos()
        With fgPromociones
            Dim i As Integer = 1
            Dim blnObligatorio As Boolean
            Dim fgRow As C1.Win.C1FlexGrid.Row
            For Each Dr As DataRow In dtProductos.Rows
                blnObligatorio = IIf(blnSeleccionarProducto And blnCapturaCantidad And Dr("Cantidad") > 0, True, False)
                fgRow = .Rows.Add()
                If blnObligatorio Then
                    .Item(fgRow.Index, .Cols("Seleccionar").Index) = blnObligatorio
                    dTotal = dTotal + (Dr("Cantidad") * iCantidadxGrupo) * Dr("Factor")
                    fgRow.AllowEditing = False
                Else
                    .Item(fgRow.Index, .Cols("Seleccionar").Index) = Dr("Seleccionar")
                    If Dr("Seleccionar") = True Then
                        dTotal = dTotal + (Dr("Cantidad") * iCantidadxGrupo) * Dr("Factor")
                    End If
                    fgRow.AllowEditing = True
                End If
                .Item(fgRow.Index, .Cols("ProductoClave").Index) = Dr("ProductoClave")
                .Item(fgRow.Index, .Cols("Nombre").Index) = Dr("Nombre")
                .Item(fgRow.Index, .Cols("Cantidad").Index) = Dr("Cantidad") * iCantidadxGrupo
                .Item(fgRow.Index, .Cols("PRUTipoUnidad").Index) = Dr("PRUTipoUnidad").ToString
                .Item(fgRow.Index, .Cols("Factor").Index) = Dr("Factor")
                .Item(fgRow.Index, .Cols("CantidadAnterior").Index) = Dr("Cantidad") * iCantidadxGrupo
                .Item(fgRow.Index, .Cols("Obligatorio").Index) = blnObligatorio
                If blnValidarExistencia Then
                    .Item(fgRow.Index, .Cols("Existencia").Index) = Fix(IIf(IsDBNull(Dr("Existencia")), 0, Dr("Existencia")) / Dr("Factor"))
                End If
            Next

            Me.TextBoxTotal.Text = dTotal
        End With
    End Sub

    Private Sub ButtonContinuarPromociones_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonContinuar.Click
        If blnSeleccionarProducto And blnCapturaCantidad Then
            If dTotal > (dCantidadMaxima * iCantidadxGrupo) Then
                MsgBox(refaVista.BuscarMensaje("MsgBox", "E0503").Replace("$0$", sPromocionNombre), MsgBoxStyle.Information)
                Exit Sub
            End If
        End If
        Dim i As Integer = 0
        Dim drprod As DataRow()
        Dim sMensajes As String = String.Empty
        Dim nCantidadSel As Integer = 0
        Dim nExistenciaSel As Integer = 0
        For i = 1 To fgPromociones.Rows.Count - 1
            If fgPromociones.GetData(i, "Seleccionar") = True Then
                If fgPromociones.GetData(i, "Cantidad") <= 0 And blnSeleccionarProducto And blnCapturaCantidad Then
                    MsgBox(refaVista.BuscarMensaje("MsgBox", "E0012"), MsgBoxStyle.Information)
                    fgPromociones.Row = i
                    fgPromociones.Col = 3
                    fgPromociones.Focus()
                    Exit Sub
                End If

                If blnValidarExistencia Then
                    If blnCapturaCantidad Then
                        nCantidadSel = fgPromociones.GetData(i, "Cantidad") * fgPromociones.GetData(i, "Factor")
                        nExistenciaSel = fgPromociones.GetData(i, "Existencia") * fgPromociones.GetData(i, "Factor")
                    Else
                        nCantidadSel = fgPromociones.GetData(i, "Cantidad")
                        nExistenciaSel = fgPromociones.GetData(i, "Existencia")
                    End If
                    
                    'If blnPendienteEntrega AndAlso Not (blnSeleccionarProducto OrElse blnCapturaCantidad) Then
                    If nCantidadSel > nExistenciaSel Then
                        If fgPromociones.GetData(i, "Existencia") <= 0 Then
                            sMensajes &= "-" & refaVista.BuscarMensaje("MsgBox", "E0029").Replace(".", "") & " " & fgPromociones.GetData(i, "ProductoClave") & vbCr
                            'fgPromociones.SetData(i, "Cantidad", 0)
                        End If

                        If fgPromociones.GetData(i, "Existencia") > 0 Then
                            sMensajes &= "-" & refaVista.BuscarMensaje("MsgBox", "E0591").Replace("$0$", nExistenciaSel).Replace("$1$", fgPromociones.GetData(i, "ProductoClave"))
                            'fgPromociones.SetData(i, "Cantidad", fgPromociones.GetData(i, "Existencia"))
                        End If
                    End If
                    'End If
                End If
                drprod = dtProductos.Select("ProductoClave= '" & fgPromociones.GetData(i, "ProductoClave") & "' and PRUTipoUnidad='" & fgPromociones.GetData(i, "PRUTipoUnidad") & "'")
                drprod(0)("Seleccionar") = fgPromociones.GetData(i, "Seleccionar")
                drprod(0)("Cantidad") = fgPromociones.GetData(i, "Cantidad")
            End If
        Next
        If sMensajes <> String.Empty Then
            MsgBox(sMensajes, MsgBoxStyle.Information)
        End If
        dtProductos.AcceptChanges()
        Me.Close()
    End Sub

    Private Sub ButtonRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonRegresar.Click
        If MsgBox(refaVista.BuscarMensaje("MsgBox", "BP0002"), MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation) = MsgBoxResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub fgPromociones_AfterEdit(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs) Handles fgPromociones.AfterEdit
        If blnCambiosManuales Then Exit Sub
        Dim nCantidadSel As Integer = 0
        Dim nExistenciaSel As Integer = 0
        If e.Col = 0 Then
            If fgPromociones.GetData(e.Row, "Seleccionar") = False Then
                'dTotal = dTotal - (fgPromociones.GetData(e.Row, "Cantidad") * fgPromociones.GetData(e.Row, "Factor"))
                dTotal = CalcularTotal()
                Me.TextBoxTotal.Text = dTotal
                blnCambiosManuales = True
                fgPromociones.SetData(e.Row, fgPromociones.Cols("CantidadAnterior").Index, fgPromociones.GetData(e.Row, "Cantidad"))
                blnCambiosManuales = False
            Else
                If blnValidarExistencia Then
                    If blnCapturaCantidad Then
                        nCantidadSel = fgPromociones.GetData(e.Row, "Cantidad") * fgPromociones.GetData(e.Row, "Factor")
                        nExistenciaSel = fgPromociones.GetData(e.Row, "Existencia") * fgPromociones.GetData(e.Row, "Factor")
                    Else
                        nCantidadSel = fgPromociones.GetData(e.Row, "Cantidad")
                        nExistenciaSel = fgPromociones.GetData(e.Row, "Existencia")
                    End If

                    If nCantidadSel > nExistenciaSel Then
                        If fgPromociones.GetData(e.Row, "Existencia") <= 0 Then
                            MsgBox(refaVista.BuscarMensaje("MsgBox", "E0029").Replace(".", "") & " " & fgPromociones.GetData(e.Row, "ProductoClave"), MsgBoxStyle.Information)
                            If blnCapturaCantidad Then
                                blnCambiosManuales = True
                                If Not blnPendienteEntrega Then
                                    fgPromociones.SetData(e.Row, fgPromociones.Cols("Cantidad").Index, 0)
                                End If
                                blnCambiosManuales = False
                            End If
                        End If

                        If fgPromociones.GetData(e.Row, "Existencia") > 0 Then
                            MsgBox(refaVista.BuscarMensaje("MsgBox", "E0591").Replace("$0$", nExistenciaSel).Replace("$1$", fgPromociones.GetData(e.Row, "ProductoClave")), MsgBoxStyle.Information)
                            If blnCapturaCantidad Then
                                blnCambiosManuales = True
                                If Not blnPendienteEntrega Then
                                    fgPromociones.SetData(e.Row, fgPromociones.Cols("Cantidad").Index, fgPromociones.GetData(e.Row, "Existencia"))
                                End If
                                blnCambiosManuales = False
                            End If
                        End If
                    End If
                End If
                'dTotal = dTotal + (fgPromociones.GetData(e.Row, "Cantidad") * fgPromociones.GetData(e.Row, "Factor"))
                dTotal = CalcularTotal()
                Me.TextBoxTotal.Text = dTotal
                blnCambiosManuales = True
                fgPromociones.SetData(e.Row, fgPromociones.Cols("CantidadAnterior").Index, fgPromociones.GetData(e.Row, "Cantidad"))
                blnCambiosManuales = False
            End If
        ElseIf e.Col = 3 Then
            If fgPromociones.GetData(e.Row, "Seleccionar") = True Then
                If fgPromociones.GetData(e.Row, "Cantidad") <= 0 Then
                    e.Cancel = True
                    MsgBox(refaVista.BuscarMensaje("MsgBox", "E0012"), MsgBoxStyle.Information)
                    dTotal = CalcularTotal()
                    Me.TextBoxTotal.Text = dTotal
                    Exit Sub
                End If

                If blnValidarExistencia Then
                    If blnCapturaCantidad Then
                        nCantidadSel = fgPromociones.GetData(e.Row, "Cantidad") * fgPromociones.GetData(e.Row, "Factor")
                        nExistenciaSel = fgPromociones.GetData(e.Row, "Existencia") * fgPromociones.GetData(e.Row, "Factor")
                    Else
                        nCantidadSel = fgPromociones.GetData(e.Row, "Cantidad")
                        nExistenciaSel = fgPromociones.GetData(e.Row, "Existencia")
                    End If
                    If nCantidadSel > nExistenciaSel Then
                        If fgPromociones.GetData(e.Row, "Existencia") <= 0 Then
                            MsgBox(refaVista.BuscarMensaje("MsgBox", "E0029").Replace(".", "") & " " & fgPromociones.GetData(e.Row, "ProductoClave"), MsgBoxStyle.Information)
                            blnCambiosManuales = True
                            If Not blnPendienteEntrega Then
                                fgPromociones.SetData(e.Row, fgPromociones.Cols("Cantidad").Index, 0)
                            End If
                            blnCambiosManuales = False
                        End If

                        If fgPromociones.GetData(e.Row, "Existencia") > 0 Then
                            MsgBox(refaVista.BuscarMensaje("MsgBox", "E0591").Replace("$0$", nExistenciaSel).Replace("$1$", fgPromociones.GetData(e.Row, "ProductoClave")), MsgBoxStyle.Information)
                            blnCambiosManuales = True
                            If Not blnPendienteEntrega Then
                                fgPromociones.SetData(e.Row, fgPromociones.Cols("Cantidad").Index, fgPromociones.GetData(e.Row, "Existencia"))
                            End If
                            blnCambiosManuales = False
                        End If
                    End If
                End If

                'dTotal = dTotal + ((fgPromociones.GetData(e.Row, "Cantidad") - fgPromociones.GetData(e.Row, "CantidadAnterior")) * fgPromociones.GetData(e.Row, "Factor"))
                dTotal = CalcularTotal()
                Me.TextBoxTotal.Text = dTotal
                blnCambiosManuales = True
                fgPromociones.SetData(e.Row, fgPromociones.Cols("CantidadAnterior").Index, fgPromociones.GetData(e.Row, "Cantidad"))
                blnCambiosManuales = False
            End If
        End If
    End Sub

    Private Function CalcularTotal() As Double
        Dim t As Double = 0
        For r As Integer = 0 To fgPromociones.Rows.Count - 1
            If fgPromociones.GetData(r, "Seleccionar").ToString() <> "" And fgPromociones.GetData(r, "Seleccionar").ToString().ToUpper().Trim() <> "FALSE" Then
                If blnCapturaCantidad Then
                    t += fgPromociones.GetData(r, "Cantidad") * fgPromociones.GetData(r, "Factor")
                Else
                    t += fgPromociones.GetData(r, "Cantidad")
                End If
            End If
        Next
        Return t
    End Function

    Private Sub MenuItemRegresar_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemRegresar.Click
        ButtonRegresar_Click(Nothing, Nothing)
    End Sub
End Class