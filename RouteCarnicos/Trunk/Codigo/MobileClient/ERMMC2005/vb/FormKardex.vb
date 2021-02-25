Public Class FormKardex
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

        With ListViewProductos
            .Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold)
            .Activation = oApp.TipoSeleccion
            .CheckBoxes = True
        End With


        With ListViewMovimientos
            .Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold)
            .Activation = oApp.TipoSeleccion
            '.CheckBoxes = True
        End With
    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If (Not IsNothing(MenuItemRegresar)) Then
            MenuItemRegresar.Dispose()
            MenuItemRegresar = Nothing
        End If
        If Not Me.MainMenuKardex Is Nothing Then Me.MainMenuKardex.Dispose()
        If (Not IsNothing(ListViewMovimientos)) Then
            If Me.ListViewMovimientos.Columns.Count > 0 Then
                Me.ListViewMovimientos.Columns.Clear()
            End If
            ListViewMovimientos.Dispose()
            ListViewMovimientos = Nothing
        End If
        If (Not IsNothing(ListViewProductos)) Then
            If Me.ListViewProductos.Columns.Count > 0 Then
                Me.ListViewProductos.Columns.Clear()
            End If
            ListViewProductos.Dispose()
            ListViewProductos = Nothing
        End If
        MyBase.Dispose(disposing)
    End Sub

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents MenuItemRegresar As System.Windows.Forms.MenuItem
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TabKardex As System.Windows.Forms.TabControl
    Friend WithEvents TabPageProductos As System.Windows.Forms.TabPage
    Friend WithEvents ButtonBuscarProd As System.Windows.Forms.Button
    Friend WithEvents ListViewProductos As System.Windows.Forms.ListView
    Friend WithEvents LabelPrincipal As System.Windows.Forms.Label
    Friend WithEvents ButtonContinuarProd As System.Windows.Forms.Button
    Friend WithEvents ButtonRegresarProd As System.Windows.Forms.Button
    Friend WithEvents TabPageMovimientos As System.Windows.Forms.TabPage
    Friend WithEvents ButtonBuscarMov As System.Windows.Forms.Button
    Friend WithEvents ListViewMovimientos As System.Windows.Forms.ListView
    Friend WithEvents ButtonRegresarMov As System.Windows.Forms.Button
    Friend WithEvents MainMenuKardex As System.Windows.Forms.MainMenu
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.MainMenuKardex = New System.Windows.Forms.MainMenu
        Me.MenuItemRegresar = New System.Windows.Forms.MenuItem
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.TabKardex = New System.Windows.Forms.TabControl
        Me.TabPageProductos = New System.Windows.Forms.TabPage
        Me.ButtonBuscarProd = New System.Windows.Forms.Button
        Me.ListViewProductos = New System.Windows.Forms.ListView
        Me.LabelPrincipal = New System.Windows.Forms.Label
        Me.ButtonContinuarProd = New System.Windows.Forms.Button
        Me.ButtonRegresarProd = New System.Windows.Forms.Button
        Me.TabPageMovimientos = New System.Windows.Forms.TabPage
        Me.ButtonBuscarMov = New System.Windows.Forms.Button
        Me.ListViewMovimientos = New System.Windows.Forms.ListView
        Me.ButtonRegresarMov = New System.Windows.Forms.Button
        Me.Panel1.SuspendLayout()
        Me.TabKardex.SuspendLayout()
        Me.TabPageProductos.SuspendLayout()
        Me.TabPageMovimientos.SuspendLayout()
        Me.SuspendLayout()
        '
        'MainMenuKardex
        '
        Me.MainMenuKardex.MenuItems.Add(Me.MenuItemRegresar)
        '
        'MenuItemRegresar
        '
        Me.MenuItemRegresar.Text = "MenuItemRegresar"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.TabKardex)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(242, 295)
        '
        'TabKardex
        '
        Me.TabKardex.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabKardex.Controls.Add(Me.TabPageProductos)
        Me.TabKardex.Controls.Add(Me.TabPageMovimientos)
        Me.TabKardex.Dock = System.Windows.Forms.DockStyle.None
        Me.TabKardex.Location = New System.Drawing.Point(0, 3)
        Me.TabKardex.Name = "TabKardex"
        Me.TabKardex.SelectedIndex = 0
        Me.TabKardex.Size = New System.Drawing.Size(242, 292)
        Me.TabKardex.TabIndex = 1
        '
        'TabPageProductos
        '
        Me.TabPageProductos.Controls.Add(Me.ButtonBuscarProd)
        Me.TabPageProductos.Controls.Add(Me.ListViewProductos)
        Me.TabPageProductos.Controls.Add(Me.LabelPrincipal)
        Me.TabPageProductos.Controls.Add(Me.ButtonContinuarProd)
        Me.TabPageProductos.Controls.Add(Me.ButtonRegresarProd)
        Me.TabPageProductos.Location = New System.Drawing.Point(0, 0)
        Me.TabPageProductos.Name = "TabPageProductos"
        Me.TabPageProductos.Size = New System.Drawing.Size(242, 272)
        Me.TabPageProductos.Text = "TabPageProductos"
        '
        'ButtonBuscarProd
        '
        Me.ButtonBuscarProd.Location = New System.Drawing.Point(155, 237)
        Me.ButtonBuscarProd.Name = "ButtonBuscarProd"
        Me.ButtonBuscarProd.Size = New System.Drawing.Size(74, 24)
        Me.ButtonBuscarProd.TabIndex = 0
        Me.ButtonBuscarProd.Text = "ButtonBuscarProd"
        '
        'ListViewProductos
        '
        Me.ListViewProductos.CheckBoxes = True
        Me.ListViewProductos.FullRowSelect = True
        Me.ListViewProductos.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.ListViewProductos.Location = New System.Drawing.Point(3, 7)
        Me.ListViewProductos.Name = "ListViewProductos"
        Me.ListViewProductos.Size = New System.Drawing.Size(228, 229)
        Me.ListViewProductos.TabIndex = 1
        Me.ListViewProductos.View = System.Windows.Forms.View.Details
        '
        'LabelPrincipal
        '
        Me.LabelPrincipal.Location = New System.Drawing.Point(4, 4)
        Me.LabelPrincipal.Name = "LabelPrincipal"
        Me.LabelPrincipal.Size = New System.Drawing.Size(230, 20)
        '
        'ButtonContinuarProd
        '
        Me.ButtonContinuarProd.Location = New System.Drawing.Point(3, 237)
        Me.ButtonContinuarProd.Name = "ButtonContinuarProd"
        Me.ButtonContinuarProd.Size = New System.Drawing.Size(74, 24)
        Me.ButtonContinuarProd.TabIndex = 3
        Me.ButtonContinuarProd.Text = "ButtonContinuarProd"
        '
        'ButtonRegresarProd
        '
        Me.ButtonRegresarProd.Location = New System.Drawing.Point(80, 237)
        Me.ButtonRegresarProd.Name = "ButtonRegresarProd"
        Me.ButtonRegresarProd.Size = New System.Drawing.Size(74, 24)
        Me.ButtonRegresarProd.TabIndex = 4
        Me.ButtonRegresarProd.Text = "ButtonRegresarProd"
        '
        'TabPageMovimientos
        '
        Me.TabPageMovimientos.Controls.Add(Me.ButtonBuscarMov)
        Me.TabPageMovimientos.Controls.Add(Me.ListViewMovimientos)
        Me.TabPageMovimientos.Controls.Add(Me.ButtonRegresarMov)
        Me.TabPageMovimientos.Location = New System.Drawing.Point(0, 0)
        Me.TabPageMovimientos.Name = "TabPageMovimientos"
        Me.TabPageMovimientos.Size = New System.Drawing.Size(242, 269)
        Me.TabPageMovimientos.Text = "TabPageMovimientos"
        '
        'ButtonBuscarMov
        '
        Me.ButtonBuscarMov.Location = New System.Drawing.Point(3, 237)
        Me.ButtonBuscarMov.Name = "ButtonBuscarMov"
        Me.ButtonBuscarMov.Size = New System.Drawing.Size(74, 24)
        Me.ButtonBuscarMov.TabIndex = 0
        Me.ButtonBuscarMov.Text = "ButtonBuscarMov"
        '
        'ListViewMovimientos
        '
        Me.ListViewMovimientos.FullRowSelect = True
        Me.ListViewMovimientos.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.ListViewMovimientos.Location = New System.Drawing.Point(3, 7)
        Me.ListViewMovimientos.Name = "ListViewMovimientos"
        Me.ListViewMovimientos.Size = New System.Drawing.Size(228, 229)
        Me.ListViewMovimientos.TabIndex = 1
        Me.ListViewMovimientos.View = System.Windows.Forms.View.Details
        '
        'ButtonRegresarMov
        '
        Me.ButtonRegresarMov.Location = New System.Drawing.Point(80, 237)
        Me.ButtonRegresarMov.Name = "ButtonRegresarMov"
        Me.ButtonRegresarMov.Size = New System.Drawing.Size(74, 24)
        Me.ButtonRegresarMov.TabIndex = 2
        Me.ButtonRegresarMov.Text = "ButtonRegresarMov"
        '
        'FormKardex
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(242, 295)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.Menu = Me.MainMenuKardex
        Me.MinimizeBox = False
        Me.Name = "FormKardex"
        Me.Text = "Amesol Route"
        Me.Panel1.ResumeLayout(False)
        Me.TabKardex.ResumeLayout(False)
        Me.TabPageProductos.ResumeLayout(False)
        Me.TabPageMovimientos.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region


    Private refaVista As Vista
    Private blnSeleccionManual As Boolean = False
    Private dCantidadAnterior As Decimal = 0
    Private sProductoClaveSeleccionado As String = ""

#Region "Forma"

    Private Sub FormKardex_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        [Global].ObtenerFactores(Me)
        [Global].EscalarFuente(Me)
        [Global].EscalarForma(Me)
        ListViewProductos.Activation = oApp.TipoSeleccion
        ' Recuperar los demás componentes de la forma
        If Not Vista.Buscar("FormKardex", refaVista) Then
            Exit Sub
        End If
        refaVista.CrearListView(ListViewProductos, "ListViewProductos")

        refaVista.CrearListView(ListViewMovimientos, "ListViewMovimientos")

        ' Recuperar los rótulos y elementos de la pantalla desde la base de datos Sys
        refaVista.ColocarEtiquetasForma(Me)
        ButtonBuscarProd_Click(Nothing, Nothing)

        With ListViewProductos
            If .Items.Count > 0 Then
                .Items(0).Selected = True
                .Focus()
            End If
        End With

    End Sub




#End Region

    Private Sub AgregarItemListView(ByRef refparoListViewItem As System.Windows.Forms.ListViewItem, ByRef refparoDataRow As System.Data.DataRow)

        With refparoDataRow
            .Item("Existencia") = dCantidadAnterior + .Item("Entrada") - .Item("Salida")
            dCantidadAnterior = .Item("Existencia")
        End With
        refparoListViewItem.SubItems(3).Text = dCantidadAnterior

    End Sub

    Private Sub ButtonBuscarProd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBuscarProd.Click
        Dim oKardexBuscar As New FormKardexBusqueda(FormKardexBusqueda.TipoBusqueda.Producto)
        If oKardexBuscar.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim sQuery As String = ""
            If oKardexBuscar.Cadena <> "" Then
                sQuery = " WHERE " & oKardexBuscar.Cadena
            End If
            refaVista.PoblarListView(ListViewProductos, oDBVen, "ListViewProductos", sQuery)
        End If
        oKardexBuscar.Dispose()
    End Sub

    Private Sub ButtonBuscarMov_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonBuscarMov.Click
        Dim oKardexBuscar As New FormKardexBusqueda(FormKardexBusqueda.TipoBusqueda.Movimiento)
        oKardexBuscar.ProductoClave = sProductoClaveSeleccionado
        If oKardexBuscar.ShowDialog() = Windows.Forms.DialogResult.OK Then
            dCantidadAnterior = 0
            If oKardexBuscar.Cadena <> "" Then
                If oKardexBuscar.Cadena.IndexOf("<") <= 0 Then
                    dCantidadAnterior = oDBVen.EjecutarCmdScalarIntSQL("Select SUM(CASE TipoMovimiento WHEN 1 THEN Cantidad ELSE 0 END)- SUM(CASE TipoMovimiento WHEN 2 THEN Cantidad ELSE 0 END) as SaldoInicial from TransProdDetalle inner join TransProd on TransProdDetalle.TransProdID = TransProd.TransProdID where TransProdDetalle.ProductoClave  ='" & sProductoClaveSeleccionado & "' AND TransProd.DiaClave in(SELECT DiaClave FROM Agenda) and TipoFase <> 0 and Tipo <> 19 AND TransProdDetalle.MFechaHora<" & UniFechaSQL(oKardexBuscar.FechaIni))
                End If
            End If
            AddHandler refaVista.AgregarItemListView, AddressOf AgregarItemListView
            refaVista.PoblarListView(ListViewMovimientos, oDBVen, "ListViewMovimientos", "WHERE TransProdDetalle.ProductoClave ='" & sProductoClaveSeleccionado & "' AND TransProd.DiaClave in(SELECT DiaClave FROM Agenda) and TipoFase <> 0 and Tipo <> 19 " & oKardexBuscar.Cadena)
            RemoveHandler refaVista.AgregarItemListView, AddressOf AgregarItemListView
        End If
        oKardexBuscar.Dispose()
    End Sub

    Private Sub ButtonContinuarProd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonContinuarProd.Click
        If ListViewProductos.SelectedIndices.Count <= 0 Then
            MsgBox("Debe seleccionar al menos un producto para consultar")
            Exit Sub
        End If
        Me.TabKardex.SelectedIndex = 1

        Dim refListViewItemSel As ListViewItem = ListViewProductos.Items(ListViewProductos.SelectedIndices(0))
        refListViewItemSel.Checked = True
        sProductoClaveSeleccionado = refListViewItemSel.SubItems(0).Text

        dCantidadAnterior = 0
        AddHandler refaVista.AgregarItemListView, AddressOf AgregarItemListView
        refaVista.PoblarListView(ListViewMovimientos, oDBVen, "ListViewMovimientos", "WHERE TransProdDetalle.ProductoClave ='" & sProductoClaveSeleccionado & "' AND TransProd.DiaClave in(SELECT DiaClave FROM Agenda) and TipoFase <> 0 and Tipo <> 19")
        RemoveHandler refaVista.AgregarItemListView, AddressOf AgregarItemListView
    End Sub

    Private Sub ListViewProductos_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles ListViewProductos.ItemCheck
        If blnSeleccionManual Then Exit Sub
        blnSeleccionManual = True
        MarcarElemento(ListViewProductos, e.NewValue, e.Index)
        blnSeleccionManual = False
        If ListViewProductos.SelectedIndices.Count <= 0 Then Exit Sub
        If e.NewValue = CheckState.Unchecked Then
            blnSeleccionManual = True
            ListViewProductos.Items(ListViewProductos.SelectedIndices(0)).Selected = False
            blnSeleccionManual = False
        End If
    End Sub

    Private Sub ListViewProductos_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListViewProductos.SelectedIndexChanged
        If blnSeleccionManual Then Exit Sub
        If ListViewProductos.SelectedIndices.Count <= 0 Then Exit Sub
        blnSeleccionManual = True
        MarcarElemento(ListViewProductos, CheckState.Checked, ListViewProductos.SelectedIndices(0))
        blnSeleccionManual = False
    End Sub

    Private Sub ButtonRegresarProd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonRegresarProd.Click
        Me.Close()
    End Sub

    Private Sub ButtonRegresarMov_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonRegresarMov.Click
        blnSeleccionManual = True
        Me.TabKardex.SelectedIndex = 0
        blnSeleccionManual = False
    End Sub

    Private Sub MenuItemRegresar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuItemRegresar.Click
        If Me.TabKardex.SelectedIndex = 0 Then
            Me.ButtonRegresarProd_Click(Nothing, Nothing)
        Else
            Me.ButtonRegresarMov_Click(Nothing, Nothing)
        End If
    End Sub
End Class
