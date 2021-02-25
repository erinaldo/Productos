Public Class FormListasPrecios
    Inherits System.Windows.Forms.Form

    Dim vlCTEActual As String = ""

#Region " Windows Form Designer generated code "

    Public Sub New(Optional ByVal pvCTEActual As String = "")
        MyBase.New()

        vlCTEActual = pvCTEActual

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        With ListViewListas
            .Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold)
            .Activation = oApp.TipoSeleccion
        End With
        With fgDetalles
            .Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold)
        End With
    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If Not Me.MenuItemOpciones Is Nothing Then Me.MenuItemOpciones.Dispose()
        If Not Me.MainMenuPrincipal Is Nothing Then Me.MainMenuPrincipal.Dispose()
        If Not Me.fgDetalles Is Nothing Then Me.fgDetalles.Dispose()
        Me.fgDetalles = Nothing
        MyBase.Dispose(disposing)
    End Sub

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents MainMenuPrincipal As System.Windows.Forms.MainMenu
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents LinkAnt As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkSig As System.Windows.Forms.LinkLabel
    Friend WithEvents fgDetalles As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents ButtonRegresar As System.Windows.Forms.Button
    Friend WithEvents ListViewListas As System.Windows.Forms.ListView
    Friend WithEvents TextBoxProducto As System.Windows.Forms.TextBox
    Friend WithEvents ButtonVer As System.Windows.Forms.Button
    Friend WithEvents LabelProducto As System.Windows.Forms.Label
    Friend WithEvents ButtonImprimir As System.Windows.Forms.Button
    Friend WithEvents MenuItemOpciones As System.Windows.Forms.MenuItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormListasPrecios))
        Me.MainMenuPrincipal = New System.Windows.Forms.MainMenu
        Me.MenuItemOpciones = New System.Windows.Forms.MenuItem
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.ButtonImprimir = New System.Windows.Forms.Button
        Me.LinkAnt = New System.Windows.Forms.LinkLabel
        Me.LinkSig = New System.Windows.Forms.LinkLabel
        Me.fgDetalles = New C1.Win.C1FlexGrid.C1FlexGrid
        Me.ButtonRegresar = New System.Windows.Forms.Button
        Me.ListViewListas = New System.Windows.Forms.ListView
        Me.TextBoxProducto = New System.Windows.Forms.TextBox
        Me.ButtonVer = New System.Windows.Forms.Button
        Me.LabelProducto = New System.Windows.Forms.Label
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MainMenuPrincipal
        '
        Me.MainMenuPrincipal.MenuItems.Add(Me.MenuItemOpciones)
        '
        'MenuItemOpciones
        '
        Me.MenuItemOpciones.Text = "MenuItemOpciones"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.ButtonImprimir)
        Me.Panel1.Controls.Add(Me.LinkAnt)
        Me.Panel1.Controls.Add(Me.LinkSig)
        Me.Panel1.Controls.Add(Me.fgDetalles)
        Me.Panel1.Controls.Add(Me.ButtonRegresar)
        Me.Panel1.Controls.Add(Me.ListViewListas)
        Me.Panel1.Controls.Add(Me.TextBoxProducto)
        Me.Panel1.Controls.Add(Me.ButtonVer)
        Me.Panel1.Controls.Add(Me.LabelProducto)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(242, 295)
        '
        'ButtonImprimir
        '
        Me.ButtonImprimir.Location = New System.Drawing.Point(88, 262)
        Me.ButtonImprimir.Name = "ButtonImprimir"
        Me.ButtonImprimir.Size = New System.Drawing.Size(72, 22)
        Me.ButtonImprimir.TabIndex = 28
        Me.ButtonImprimir.Text = "ButtonImprimir"
        '
        'LinkAnt
        '
        Me.LinkAnt.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.LinkAnt.Location = New System.Drawing.Point(164, 254)
        Me.LinkAnt.Name = "LinkAnt"
        Me.LinkAnt.Size = New System.Drawing.Size(33, 20)
        Me.LinkAnt.TabIndex = 26
        Me.LinkAnt.Text = "<<"
        '
        'LinkSig
        '
        Me.LinkSig.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.LinkSig.Location = New System.Drawing.Point(199, 254)
        Me.LinkSig.Name = "LinkSig"
        Me.LinkSig.Size = New System.Drawing.Size(33, 20)
        Me.LinkSig.TabIndex = 25
        Me.LinkSig.Text = ">>"
        Me.LinkSig.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'fgDetalles
        '
        Me.fgDetalles.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.fgDetalles.AllowEditing = False
        Me.fgDetalles.AutoSearchDelay = 2
        Me.fgDetalles.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.fgDetalles.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.fgDetalles.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.fgDetalles.HighLight = C1.Win.C1FlexGrid.HighLightEnum.WithFocus
        Me.fgDetalles.Location = New System.Drawing.Point(8, 118)
        Me.fgDetalles.Name = "fgDetalles"
        Me.fgDetalles.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.fgDetalles.Size = New System.Drawing.Size(223, 136)
        Me.fgDetalles.StyleInfo = resources.GetString("fgDetalles.StyleInfo")
        Me.fgDetalles.TabIndex = 24
        '
        'ButtonRegresar
        '
        Me.ButtonRegresar.Location = New System.Drawing.Point(7, 262)
        Me.ButtonRegresar.Name = "ButtonRegresar"
        Me.ButtonRegresar.Size = New System.Drawing.Size(74, 22)
        Me.ButtonRegresar.TabIndex = 20
        Me.ButtonRegresar.Text = "ButtonRegresar"
        '
        'ListViewListas
        '
        Me.ListViewListas.FullRowSelect = True
        Me.ListViewListas.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.ListViewListas.Location = New System.Drawing.Point(7, 30)
        Me.ListViewListas.Name = "ListViewListas"
        Me.ListViewListas.Size = New System.Drawing.Size(224, 86)
        Me.ListViewListas.TabIndex = 21
        Me.ListViewListas.View = System.Windows.Forms.View.Details
        '
        'TextBoxProducto
        '
        Me.TextBoxProducto.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Bold)
        Me.TextBoxProducto.Location = New System.Drawing.Point(88, 5)
        Me.TextBoxProducto.Name = "TextBoxProducto"
        Me.TextBoxProducto.Size = New System.Drawing.Size(95, 20)
        Me.TextBoxProducto.TabIndex = 22
        '
        'ButtonVer
        '
        Me.ButtonVer.Location = New System.Drawing.Point(184, 5)
        Me.ButtonVer.Name = "ButtonVer"
        Me.ButtonVer.Size = New System.Drawing.Size(48, 21)
        Me.ButtonVer.TabIndex = 23
        Me.ButtonVer.Text = "ButtonVer"
        '
        'LabelProducto
        '
        Me.LabelProducto.Location = New System.Drawing.Point(9, 8)
        Me.LabelProducto.Name = "LabelProducto"
        Me.LabelProducto.Size = New System.Drawing.Size(80, 16)
        Me.LabelProducto.Text = "LabelProducto"
        '
        'FormListasPrecios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(242, 295)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.Menu = Me.MainMenuPrincipal
        Me.MinimizeBox = False
        Me.Name = "FormListasPrecios"
        Me.Text = " "
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Const INCREMENTO = 10
    Private refaVista As Vista
    Private sProductoClave As String = ""
    Private iIndiceInicial As Integer = 1
    Private iIndiceMaximo As Integer = 0
    Private dtDetalles As DataTable

    Private Sub FormListasPrecios_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        [Global].ObtenerFactores(Me)
        [Global].EscalarFuente(Me)
        [Global].EscalarForma(Me)
        vListaPreciosCargada = True
        ' Recuperar los demás componentes de la forma
        If Not Vista.Buscar("FormListasPrecios", refaVista) Then
            Exit Sub
        End If
        refaVista.ColocarEtiquetasForma(Me)

        If vlCTEActual = String.Empty Then
            refaVista.CrearListView(ListViewListas, "ListViewListas")
            'TODO: Rango Fecha Eficiente
            'refaVista.PoblarListView(ListViewListas, oDBVen, "ListViewListas", " AND (" & UniFechaSQL(UltimaHora(Now)) & ">=PrecioProductoVig.PPVFechaInicio AND " & UniFechaSQL(PrimeraHora(Now)) & "<=PrecioProductoVig.FechaFin) ")
            refaVista.PoblarListView(ListViewListas, oDBVen, "ListViewListas", "")

        Else
            refaVista.CrearListView(ListViewListas, "ListViewListaCliente")
            'TODO: Rango Fecha Eficiente
            'refaVista.PoblarListView(ListViewListas, oDBVen, "ListViewListaCliente", " AND (" & UniFechaSQL(UltimaHora(Now)) & ">=PrecioProductoVig.PPVFechaInicio AND " & UniFechaSQL(PrimeraHora(Now)) & "<=PrecioProductoVig.FechaFin) " & String.Format("AND ClienteEsquema.clienteclave='{0}'", vlCTEActual))
            refaVista.PoblarListView(ListViewListas, oDBVen, "ListViewListaCliente", String.Format(" AND ClienteEsquema.clienteclave='{0}'", vlCTEActual))
        End If

        ConfiguraGridDetalle()

        ' Recuperar los rótulos y elementos de la pantalla desde la base de datos Sys

        If ListViewListas.Items.Count > 0 Then
            ListViewListas.Items(0).Selected = True
        End If
    End Sub

    Private Sub ButtonRegresar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonRegresar.Click
        Me.Close()
    End Sub

    Private Sub MenuItemOpciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemOpciones.Click
        Me.Close()
    End Sub

    Private Sub ListViewListas_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListViewListas.SelectedIndexChanged
        If ListViewListas.SelectedIndices.Count > 0 Then
            Dim refListViewItemSel As ListViewItem = ListViewListas.Items(ListViewListas.SelectedIndices(0))
            Dim sFiltro As String = String.Empty
            If sProductoClave <> "" Then
                'TODO: Rango Fecha Eficiente
                'sFiltro = " WHERE PrecioClave ='" & refListViewItemSel.SubItems(0).Text & "' AND PrecioProductoVig.ProductoClave='" & Me.TextBoxProducto.Text & "' AND (" & UniFechaSQL(UltimaHora(Now)) & ">=PrecioProductoVig.PPVFechaInicio AND " & UniFechaSQL(PrimeraHora(Now)) & "<=PrecioProductoVig.FechaFin) "
                sFiltro = " WHERE PrecioClave ='" & refListViewItemSel.SubItems(0).Text & "' AND PrecioProductoVig.ProductoClave='" & Me.TextBoxProducto.Text & "' AND (convert(nvarchar(10), getdate(), 112) between convert(nvarchar(10),PrecioProductoVig.PPVFechaInicio,112) and convert(nvarchar(10),PrecioProductoVig.Fechafin,112)) "
            Else
                'TODO: Rango Fecha Eficiente
                'sFiltro = " WHERE PrecioClave ='" & refListViewItemSel.SubItems(0).Text & "' AND (" & UniFechaSQL(UltimaHora(Now)) & ">=PrecioProductoVig.PPVFechaInicio AND " & UniFechaSQL(PrimeraHora(Now)) & "<=PrecioProductoVig.FechaFin )"
                sFiltro = " WHERE PrecioClave ='" & refListViewItemSel.SubItems(0).Text & "' AND (convert(nvarchar(10), getdate(), 112) between convert(nvarchar(10),PrecioProductoVig.PPVFechaInicio,112) and convert(nvarchar(10),PrecioProductoVig.Fechafin,112)) "
            End If
            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
            dtDetalles = refaVista.TablaListView(oDBVen, "ListViewDetalle", sFiltro)
            dtDetalles.Columns.Add("Id", GetType(Integer))
            Dim sProducto As String = ""
            Dim dr As DataRow
            iIndiceMaximo = 0
            iIndiceInicial = 1
            For Each dr In dtDetalles.Rows
                If sProducto <> dr("ProductoClave").ToString Then
                    sProducto = dr("ProductoClave")
                    iIndiceMaximo += 1
                End If
                dr("Id") = iIndiceMaximo
            Next
            PoblarGridDetalles()
            Cursor.Current = System.Windows.Forms.Cursors.Default
        End If
    End Sub

    Private Sub PoblarGridDetalles()
        fgDetalles.Rows.Count = 1
        fgDetalles.Redraw = False
        Dim r As C1.Win.C1FlexGrid.Row

        Dim drRango() As DataRow = dtDetalles.Select(" id>= " & iIndiceInicial & " and id< " & iIndiceInicial + INCREMENTO)
        Dim dr As DataRow
        Dim sProducto As String = ""
        For Each dr In drRango
            If sProducto <> dr("ProductoClave").ToString Then
                sProducto = dr("ProductoClave")
                r = fgDetalles.Rows.Add
                r.IsNode = True
                r.Node.Level = 0
                With fgDetalles
                    .Item(r.Index, 0) = dr("ProductoClave")
                    .Item(r.Index, 1) = dr("Nombre")
                End With
            End If
            Dim r2 As C1.Win.C1FlexGrid.Row = fgDetalles.Rows.Add
            r2.IsNode = True
            r2.Node.Level = 1
            With fgDetalles
                .Item(r2.Index, 0) = ValorReferencia.BuscarEquivalente("UCOBRA", dr("UnidadCobranza"))
                .Item(r2.Index, 1) = Format(dr("Precio"), oApp.FormatoDinero) & " " & ValorReferencia.BuscarEquivalente("CDGOMON", dr("MonedaID")) & "(" & dr("Minimo") & "-" & dr("Maximo") & ")"


            End With
        Next
        fgDetalles.Redraw = True
    End Sub
    Private Sub ConfiguraGridDetalle()
        With fgDetalles
            .Redraw = False
            Dim f As Drawing.Font = .Font
            .Styles.Normal.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.None
            .Styles.Normal.Trimming = Drawing.StringTrimming.EllipsisCharacter
            .Cols.Fixed = 0
            .Cols.Count = 2
            .Cols(0).Caption = refaVista.BuscarMensaje("MsgBoxGral", "MDBClave")
            .Cols(1).Caption = refaVista.BuscarMensaje("MsgBoxGral", "MDBNombre")
            .Cols(1).Width = 120
            .Rows.Count = 1
            .SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
            .ExtendLastCol = False
            .Styles.Normal.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.LeftCenter
            .Styles.Normal.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.None
            ' initialize outline tree
            .Tree.Column = 0
            .Tree.Style = C1.Win.C1FlexGrid.TreeStyleFlags.SimpleLeaf
            .AutoResize = True
            .Redraw = True
#If MOD_TERM = "IPAQ" Or MOD_TERM = "HHP9700" Then
            For Each col As C1.Win.C1FlexGrid.Column In .Cols
                col.Width = col.Width * 2
            Next
#End If
        End With
    End Sub

    Private Sub ButtonVer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonVer.Click
        Me.BuscarProducto()
    End Sub

    Private Sub FormListasPrecios_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        vListaPreciosCargada = False
    End Sub

    Private Sub MoverSiguiente()
        If iIndiceInicial + INCREMENTO < iIndiceMaximo Then
            iIndiceInicial += INCREMENTO
            PoblarGridDetalles()
        End If
    End Sub
    Private Sub MoverAnterior()
        If iIndiceInicial > 1 Then
            iIndiceInicial -= INCREMENTO
            PoblarGridDetalles()
        End If
    End Sub
    Private Sub LinkSig_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LinkSig.Click
        MoverSiguiente()
    End Sub

    Private Sub LinkAnt_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkAnt.Click
        MoverAnterior()
    End Sub

    Private Sub fgDetalles_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles fgDetalles.KeyUp
        Select Case e.KeyCode
            Case Keys.Space
                If fgDetalles.Rows(fgDetalles.Row).Node.Collapsed Then
                    fgDetalles.Rows(fgDetalles.Row).Node.Collapsed = False
                Else
                    fgDetalles.Rows(fgDetalles.Row).Node.Collapsed = True
                End If
            Case Keys.S, Keys.P
                MoverSiguiente()
            Case Keys.A
                MoverAnterior()
        End Select
    End Sub

    Private Sub TextBoxProducto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBoxProducto.KeyDown
        If e.KeyCode = Keys.Enter Then
            BuscarProducto()
        End If
    End Sub

    Private Sub BuscarProducto()
        If Me.TextBoxProducto.Text <> "" Then
            Dim oProducto As New Producto
            If Not oProducto.ExisteProducto(Me.TextBoxProducto.Text) Then
                MsgBox(refaVista.BuscarMensaje("MsgBoxGral", "E0005"))
                Me.TextBoxProducto.Focus()
            Else
                sProductoClave = Me.TextBoxProducto.Text
            End If
            If vlCTEActual = String.Empty Then
                'TODO: Rango Fecha Eficiente
                'refaVista.PoblarListView(ListViewListas, oDBVen, "ListViewListas", " AND (" & UniFechaSQL(UltimaHora(Now)) & ">=PrecioProductoVig.PPVFechaInicio AND " & UniFechaSQL(PrimeraHora(Now)) & "<=PrecioProductoVig.FechaFin) AND PrecioProductoVig.ProductoClave='" & Me.TextBoxProducto.Text & "'")
                refaVista.PoblarListView(ListViewListas, oDBVen, "ListViewListas", "")
            Else
                'TODO: Rango Fecha Eficiente
                'refaVista.PoblarListView(ListViewListas, oDBVen, "ListViewListaCliente", " AND (" & UniFechaSQL(UltimaHora(Now)) & ">=PrecioProductoVig.PPVFechaInicio AND " & UniFechaSQL(PrimeraHora(Now)) & "<=PrecioProductoVig.FechaFin) AND PrecioProductoVig.ProductoClave='" & Me.TextBoxProducto.Text & "' " & String.Format("AND ClienteEsquema.clienteclave='{0}'", vlCTEActual))
                refaVista.PoblarListView(ListViewListas, oDBVen, "ListViewListaCliente", String.Format("AND ClienteEsquema.clienteclave='{0}'", vlCTEActual))
            End If
        Else
            If vlCTEActual = String.Empty Then
                'TODO: Rango Fecha Eficiente
                'refaVista.PoblarListView(ListViewListas, oDBVen, "ListViewListas", " AND (" & UniFechaSQL(UltimaHora(Now)) & ">=PrecioProductoVig.PPVFechaInicio AND " & UniFechaSQL(PrimeraHora(Now)) & "<=PrecioProductoVig.FechaFin) ")
                refaVista.PoblarListView(ListViewListas, oDBVen, "ListViewListas", " ")
            Else
                'TODO: Rango Fecha Eficiente
                'refaVista.PoblarListView(ListViewListas, oDBVen, "ListViewListaCliente", " AND (" & UniFechaSQL(UltimaHora(Now)) & ">=PrecioProductoVig.PPVFechaInicio AND " & UniFechaSQL(PrimeraHora(Now)) & "<=PrecioProductoVig.FechaFin) " & String.Format("AND ClienteEsquema.clienteclave='{0}'", vlCTEActual))
                refaVista.PoblarListView(ListViewListas, oDBVen, "ListViewListaCliente", String.Format(" AND ClienteEsquema.clienteclave='{0}'", vlCTEActual))
            End If
            sProductoClave = ""
        End If
        If ListViewListas.Items.Count > 0 Then
            ListViewListas.Items(0).Selected = True
        Else
            fgDetalles.Rows.Count = 1
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonImprimir.Click
        If ListViewListas.SelectedIndices.Count <= 0 Then
            'MsgBox("E0046] Debe seleccionar un Registro", MsgBoxStyle.Information)
            MsgBox(refaVista.BuscarMensaje("MsgBoxGral", "E0046"), MsgBoxStyle.Information)
            Exit Sub
        End If


        Dim oFormaReportes As New FormReportes(oDia, "REPORTEM")
        oFormaReportes.ImprimirListaPrecios(ListViewListas.Items(ListViewListas.SelectedIndices(0)).SubItems(0).Text, ListViewListas.Items(ListViewListas.SelectedIndices(0)).SubItems(1).Text)
        oFormaReportes.Dispose()
        oFormaReportes = Nothing




    End Sub
End Class
