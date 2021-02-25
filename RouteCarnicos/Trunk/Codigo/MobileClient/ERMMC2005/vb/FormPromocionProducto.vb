Public Class FormPromocionProducto
    Inherits System.Windows.Forms.Form
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ButtonRegresar As System.Windows.Forms.Button
    Friend WithEvents ListViewPromociones As System.Windows.Forms.ListView
    Friend WithEvents TextBoxClave As System.Windows.Forms.TextBox
    Friend WithEvents LabelClave As System.Windows.Forms.Label
    Friend WithEvents fgDetalles As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents MenuItemRegresar As System.Windows.Forms.MenuItem

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal pvCliente As Cliente, ByVal pvVista As Vista, ByVal pvProdClave As String)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        oCliente = pvCliente
        oVista = pvVista
        sProductoClave = pvProdClave
    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If Not Me.MenuItemRegresar Is Nothing Then Me.MenuItemRegresar.Dispose()
        If Not Me.MainMenu1 Is Nothing Then Me.MainMenu1.Dispose()
        If Not Me.ListViewPromociones Is Nothing Then
            If Me.ListViewPromociones.Columns.Count > 0 Then
                Me.ListViewPromociones.Columns.Clear()
            End If
        End If
        If Not Me.fgDetalles Is Nothing Then Me.fgDetalles.Dispose()
        Me.fgDetalles = Nothing

        MyBase.Dispose(disposing)
    End Sub

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormPromocionProducto))
        Me.MainMenu1 = New System.Windows.Forms.MainMenu
        Me.MenuItemRegresar = New System.Windows.Forms.MenuItem
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.fgDetalles = New C1.Win.C1FlexGrid.C1FlexGrid
        Me.ButtonRegresar = New System.Windows.Forms.Button
        Me.ListViewPromociones = New System.Windows.Forms.ListView
        Me.TextBoxClave = New System.Windows.Forms.TextBox
        Me.LabelClave = New System.Windows.Forms.Label
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MainMenu1
        '
        Me.MainMenu1.MenuItems.Add(Me.MenuItemRegresar)
        '
        'MenuItemRegresar
        '
        Me.MenuItemRegresar.Text = "MenuItemRegresar"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.fgDetalles)
        Me.Panel1.Controls.Add(Me.ButtonRegresar)
        Me.Panel1.Controls.Add(Me.ListViewPromociones)
        Me.Panel1.Controls.Add(Me.TextBoxClave)
        Me.Panel1.Controls.Add(Me.LabelClave)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(242, 295)
        '
        'fgDetalles
        '
        Me.fgDetalles.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.fgDetalles.AllowEditing = False
        Me.fgDetalles.AutoResize = True
        Me.fgDetalles.AutoSearchDelay = 2
        Me.fgDetalles.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.fgDetalles.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.fgDetalles.Clip = ""
        Me.fgDetalles.ClipSeparators = "" & Global.Microsoft.VisualBasic.ChrW(9) & Global.Microsoft.VisualBasic.ChrW(13)
        Me.fgDetalles.Col = 1
        Me.fgDetalles.ColSel = 1
        Me.fgDetalles.ComboList = Nothing
        Me.fgDetalles.EditMask = Nothing
        Me.fgDetalles.ExtendLastCol = False
        Me.fgDetalles.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.fgDetalles.HighLight = C1.Win.C1FlexGrid.HighLightEnum.WithFocus
        Me.fgDetalles.LeftCol = 1
        Me.fgDetalles.Location = New System.Drawing.Point(7, 125)
        Me.fgDetalles.Name = "fgDetalles"
        Me.fgDetalles.Redraw = True
        Me.fgDetalles.Row = 1
        Me.fgDetalles.RowSel = 1
        Me.fgDetalles.ScrollPosition = New System.Drawing.Point(0, 0)
        Me.fgDetalles.ScrollTrack = True
        Me.fgDetalles.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.fgDetalles.ShowCursor = False
        Me.fgDetalles.ShowSort = True
        Me.fgDetalles.Size = New System.Drawing.Size(226, 126)
        Me.fgDetalles.StyleInfo = resources.GetString("fgDetalles.StyleInfo")
        Me.fgDetalles.SupportInfo = "0wCjAdEALQGFAAcBPAGXABYB6gAWAUMBJQGEAJQAmAA4AAMBsADlALYA3gCoAMIAYwAZAbkA7gB0ADwA"
        Me.fgDetalles.TabIndex = 25
        Me.fgDetalles.Text = "C1FlexGrid1"
        Me.fgDetalles.TopRow = 1
        '
        'ButtonRegresar
        '
        Me.ButtonRegresar.Location = New System.Drawing.Point(7, 262)
        Me.ButtonRegresar.Name = "ButtonRegresar"
        Me.ButtonRegresar.Size = New System.Drawing.Size(74, 24)
        Me.ButtonRegresar.TabIndex = 6
        Me.ButtonRegresar.Text = "ButtonRegresar"
        '
        'ListViewPromociones
        '
        Me.ListViewPromociones.FullRowSelect = True
        Me.ListViewPromociones.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.ListViewPromociones.Location = New System.Drawing.Point(7, 34)
        Me.ListViewPromociones.Name = "ListViewPromociones"
        Me.ListViewPromociones.Size = New System.Drawing.Size(226, 88)
        Me.ListViewPromociones.TabIndex = 7
        Me.ListViewPromociones.View = System.Windows.Forms.View.Details
        '
        'TextBoxClave
        '
        Me.TextBoxClave.Location = New System.Drawing.Point(107, 10)
        Me.TextBoxClave.MaxLength = 250
        Me.TextBoxClave.Name = "TextBoxClave"
        Me.TextBoxClave.Size = New System.Drawing.Size(126, 21)
        Me.TextBoxClave.TabIndex = 8
        '
        'LabelClave
        '
        Me.LabelClave.Location = New System.Drawing.Point(7, 10)
        Me.LabelClave.Name = "LabelClave"
        Me.LabelClave.Size = New System.Drawing.Size(100, 20)
        Me.LabelClave.Text = "LabelClave"
        '
        'FormPromocionProducto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(242, 295)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.Menu = Me.MainMenu1
        Me.MinimizeBox = False
        Me.Name = "FormPromocionProducto"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "VARIABLES"
    Private oCliente As Cliente
    Private oVista As Vista
    Private sProductoClave As String
    Private bFin As Boolean = False
#End Region

#Region "METODOS"
    Private Sub LlenarDetalles(ByVal pvPromocionClave As String)
        Dim sQuery As New System.Text.StringBuilder
        If Me.ListViewPromociones.SelectedIndices.Count > 0 Then
            Dim iTipoAplicacion As ServicesCentral.TiposAplicacionPromociones = CType(Me.ListViewPromociones.Items(Me.ListViewPromociones.SelectedIndices(0)).SubItems(4).Text, ServicesCentral.TiposAplicacionPromociones)
            Select Case iTipoAplicacion
                Case ServicesCentral.TiposAplicacionPromociones.Descuento
                    sQuery.Append("SELECT DISTINCT PR.Minimo, PR.Maximo, CONVERT(nvarchar, PR.Porcentaje) + ' %' ")
                    sQuery.Append("FROM PromocionRegla as PR, Promocion as P ")
                    sQuery.Append("WHERE P.PromocionClave=PR.PromocionClave ")
                    sQuery.Append("AND P.PromocionClave='" & pvPromocionClave & "'")
                    Dim dt As DataTable = oDBVen.RealizarConsultaSQL(sQuery.ToString, "Promocion")
                    Me.fgDetalles.DataSource = dt
                    ConfiguraGridDetalle(iTipoAplicacion)
                Case ServicesCentral.TiposAplicacionPromociones.Bonificacion
                    sQuery.Append("SELECT DISTINCT PR.Minimo, PR.Maximo, PR.Importe ")
                    sQuery.Append("FROM PromocionRegla as PR, Promocion as P ")
                    sQuery.Append("WHERE P.PromocionClave=PR.PromocionClave ")
                    sQuery.Append("AND P.PromocionClave='" & pvPromocionClave & "'")
                    Dim dt As DataTable = oDBVen.RealizarConsultaSQL(sQuery.ToString, "Promocion")
                    Me.fgDetalles.DataSource = dt
                    ConfiguraGridDetalle(iTipoAplicacion)
                Case ServicesCentral.TiposAplicacionPromociones.Precio
                    sQuery.Append("SELECT DISTINCT PR.Minimo, PR.Maximo, Precio.Nombre ")
                    sQuery.Append("FROM PromocionRegla as PR, Promocion as P, Precio ")
                    sQuery.Append("WHERE P.PromocionClave=PR.PromocionClave ")
                    sQuery.Append("AND PR.PrecioClave=Precio.PrecioClave ")
                    sQuery.Append("AND P.PromocionClave='" & pvPromocionClave & "'")
                    Dim dt As DataTable = oDBVen.RealizarConsultaSQL(sQuery.ToString, "Promocion")
                    Me.fgDetalles.DataSource = dt
                    ConfiguraGridDetalle(iTipoAplicacion)
                Case ServicesCentral.TiposAplicacionPromociones.Producto
                    sQuery.Append("SELECT DISTINCT PR.Minimo, PR.Maximo, PA.Cantidad, Producto.Nombre, PA.PRUTipoUnidad  ")
                    sQuery.Append("FROM PromocionRegla as PR inner join Promocion as P on PR.PromocionClave = P.PromocionClave ")
                    sQuery.Append("inner join PromocionAplicacion as PA on PR.PromocionClave = PA.PromocionClave AND PR.PromocionReglaID = PA.PromocionReglaID ")
                    sQuery.Append("inner join Producto on PA.ProductoClave = Producto.ProductoClave ")
                    sQuery.Append("WHERE P.PromocionClave='" & pvPromocionClave & "'")
                    Dim dt As DataTable = oDBVen.RealizarConsultaSQL(sQuery.ToString, "Promocion")
                    fgDetalles.DataSource = Nothing
                    ConfiguraGridDetalle(iTipoAplicacion)
                    CrearArbolDetalle(dt)
            End Select
        Else
            'Me.ListViewDetalles.Columns(2).Text = ""
        End If
        sQuery = Nothing
    End Sub

    Private Sub LlenaCampoProducto()
        Dim sNombre As String = oDBVen.RealizarConsultaSQL("SELECT Nombre FROM Producto WHERE ProductoClave='" & sProductoClave & "'", "Bla").Rows(0)(0)
        Me.TextBoxClave.Text = sProductoClave & " - " & sNombre
    End Sub

    Private Sub CrearArbolDetalle(ByVal parDt As DataTable)
        fgDetalles.Rows.Count = 1
        fgDetalles.Redraw = False
        Dim r As C1.Win.C1FlexGrid.Row

        Dim dr As DataRow
        Dim iMin As Integer = 0
        Dim iMax As Integer = 0
        Dim sProducto As String = ""
        For Each dr In parDt.Rows
            If iMin <> dr("Minimo").ToString Or iMax <> dr("Maximo").ToString Then
                iMin = dr("Minimo")
                iMax = dr("Maximo")
                r = fgDetalles.Rows.Add
                r.IsNode = True
                r.Node.Level = 0
                With fgDetalles
                    .Item(r.Index, 0) = dr("Minimo").ToString
                    .Item(r.Index, 1) = dr("Maximo").ToString
                End With
            End If
            Dim r2 As C1.Win.C1FlexGrid.Row = fgDetalles.Rows.Add
            r2.IsNode = True
            r2.Node.Level = 1
            With fgDetalles
                .Item(r2.Index, 0) = dr("Nombre")
                .Item(r2.Index, 1) = ValorReferencia.BuscarEquivalente("UNIDADV", dr("PRUTipoUnidad"))
                .Item(r2.Index, 2) = dr("Cantidad")
            End With
        Next
        fgDetalles.Redraw = True
    End Sub

    Private Sub ConfiguraGridDetalle(ByVal partTipoAplicacion As ServicesCentral.TiposAplicacionPromociones)
        With fgDetalles
            .Redraw = False
            Dim f As Drawing.Font = .Font
            .Styles.Normal.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.None
            .Styles.Normal.Trimming = Drawing.StringTrimming.EllipsisCharacter
            .Cols.Fixed = 0
            If Me.ListViewPromociones.Items(Me.ListViewPromociones.SelectedIndices(0)).SubItems(5).Text = "2" Then
                .Cols(0).Caption = oVista.BuscarMensaje("Mensajes", "XPorCada")
                .Cols(1).Visible = False
            Else
                .Cols(0).Caption = oVista.BuscarMensaje("Mensajes", "XDe")
            End If
            .Cols(0).Width = 70
            .Cols(1).Caption = oVista.BuscarMensaje("Mensajes", "XA")
            If partTipoAplicacion = ServicesCentral.TiposAplicacionPromociones.Producto Then
                .Cols(0).DataType = System.Type.GetType("System.String")
                .Cols(1).DataType = System.Type.GetType("System.String")
            End If
            '.Cols(1).Caption = "A" 'refaVista.BuscarMensaje("MsgBoxGral", "MDBNombre")
            '.Cols(1).Width = 100
            Select Case partTipoAplicacion
                Case ServicesCentral.TiposAplicacionPromociones.Descuento
                    .Cols(2).Caption = oVista.BuscarMensaje("Mensajes", "XPorcentaje")
                Case ServicesCentral.TiposAplicacionPromociones.Bonificacion
                    .Cols(2).Caption = oVista.BuscarMensaje("Mensajes", "XBonificacion")
                Case ServicesCentral.TiposAplicacionPromociones.Precio
                    .Cols(2).Caption = oVista.BuscarMensaje("Mensajes", "XListaPrecio")
                Case ServicesCentral.TiposAplicacionPromociones.Producto
                    .Cols.Count = 3
                    .Cols(2).Caption = ""
                    .Cols(0).Width = 110
                    .Tree.Column = 0
                    .Tree.Style = C1.Win.C1FlexGrid.TreeStyleFlags.SimpleLeaf
            End Select

            .SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
            .ExtendLastCol = True
            .Styles.Normal.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.LeftCenter
            .Styles.Normal.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.None

            .AutoResize = True
            .Redraw = True
        End With
    End Sub
#End Region


#Region "EVENTOS"
    Private Sub ButtonRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonRegresar.Click
        Me.Close()
    End Sub

    Private Sub MenuItemRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemRegresar.Click
        Me.Close()
    End Sub

    Private Sub FormPromocionProducto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cursor.Current = Cursors.WaitCursor
        [Global].ObtenerFactores(Me)
        [Global].EscalarFuente(Me)
        [Global].EscalarForma(Me)
        If Not Vista.Buscar("FormPromocionProducto", oVista) Then
            Cursor.Current = Cursors.Default
            Exit Sub
        End If
        oVista.CrearListView(Me.ListViewPromociones, "ListViewPromociones")
        'oVista.CrearListView(Me.ListViewDetalles, "ListViewDetalles")
        Dim sQuery As String = String.Empty
        If oVendedor.TipoModulo = ServicesCentral.TiposModulos.Preventa OrElse oVendedor.TipoModulo = ServicesCentral.TiposModulos.Venta Then
            sQuery = " AND " & UniFechaSQL(PrimeraHora(Now)) & " between p.fechainicial and p.fechafinal AND p.TipoEstado=1 AND productoclave='" & sProductoClave & "'"
        Else
            sQuery = " AND " & UniFechaSQL(PrimeraHora(Now)) & " between p.fechainicial and p.fechafinal AND productoclave='" & sProductoClave & "'"
        End If
        Me.LlenaCampoProducto()
        Me.fgDetalles.Rows.Count = 1
        oVista.PoblarListView(Me.ListViewPromociones, oDBVen, "ListViewPromociones", sQuery)
        oVista.ColocarEtiquetasForma(Me)
        bFin = True
        Cursor.Current = Cursors.Default

        With ListViewPromociones
            If .Items.Count > 0 Then
                .Items(0).Selected = True
                .Focus()
            Else
                Me.ButtonRegresar.Focus()
            End If
        End With

    End Sub

    Private Sub ListViewPromociones_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListViewPromociones.SelectedIndexChanged
        If bFin Then
            If Me.ListViewPromociones.SelectedIndices.Count > 0 Then
                Dim sPromClave As String = Me.ListViewPromociones.Items(Me.ListViewPromociones.SelectedIndices(0)).SubItems(3).Text
                Me.LlenarDetalles(sPromClave)
            End If
        End If
    End Sub
#End Region

End Class
