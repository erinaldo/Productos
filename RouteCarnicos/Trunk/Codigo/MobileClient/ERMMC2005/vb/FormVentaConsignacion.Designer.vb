<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class FormVentaConsignacion
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If oVendedor.motconfiguracion.Secuencia Then
            If Not ctrlSeguimiento.Parent Is Nothing Then
                RemoveHandler ctrlSeguimiento.NuevaSeleccion, AddressOf TerminarVisita
                RemoveHandler ctrlSeguimiento.TerminarVisitaMenu, AddressOf TerminarVisita
                ctrlSeguimiento.QuitarMenuItem(Me.MainMenuCargas)
                Me.Controls.Remove(ctrlSeguimiento)
            End If
        Else
            If Not Me.lbNombreActividad Is Nothing Then
                Me.lbNombreActividad.Dispose()
                Me.lbNombreActividad = Nothing
            End If
        End If

        If Not usoTransProd Is Nothing Then
            usoTransProd.Dispose()
            usoTransProd = Nothing
        End If
        If Not oImpuesto Is Nothing Then oImpuesto = Nothing
        If Not oVista Is Nothing Then oVista = Nothing

        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer
    Private MainMenuCargas As System.Windows.Forms.MainMenu

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormVentaConsignacion))
        Me.MainMenuCargas = New System.Windows.Forms.MainMenu
        Me.MenuItemRegresar = New System.Windows.Forms.MenuItem
        Me.PanelLista = New System.Windows.Forms.Panel
        Me.LabelTotalSaldoNF = New System.Windows.Forms.Label
        Me.LabelTotalSaldoN = New System.Windows.Forms.Label
        Me.ButtonEliminar = New System.Windows.Forms.Button
        Me.ButtonLiquidar = New System.Windows.Forms.Button
        Me.ListViewConsignacion = New System.Windows.Forms.ListView
        Me.ContextMenuNavegacion = New System.Windows.Forms.ContextMenu
        Me.MenuItemModificarN = New System.Windows.Forms.MenuItem
        Me.MenuItemLiquidarN = New System.Windows.Forms.MenuItem
        Me.MenuItemEliminarN = New System.Windows.Forms.MenuItem
        Me.MenuItemDetallesN = New System.Windows.Forms.MenuItem
        Me.ButtonContinuarLista = New System.Windows.Forms.Button
        Me.ButtonRegresarLista = New System.Windows.Forms.Button
        Me.PanelDetalle = New System.Windows.Forms.Panel
        Me.TabVentaConsignacion = New System.Windows.Forms.TabControl
        Me.TabPageDetalle = New System.Windows.Forms.TabPage
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.LabelGTotalImporte = New System.Windows.Forms.Label
        Me.LabelTotalImporteF = New System.Windows.Forms.Label
        Me.LabelTotalProductosF = New System.Windows.Forms.Label
        Me.LabelTotalProductos = New System.Windows.Forms.Label
        Me.CheckBoxProducto = New System.Windows.Forms.CheckBox
        Me.ButtonRegresarDet = New System.Windows.Forms.Button
        Me.ButtonContinuarDet = New System.Windows.Forms.Button
        Me.LabelListaPrecios = New System.Windows.Forms.Label
        Me.TextBoxCodigo = New System.Windows.Forms.TextBox
        Me.LabelCodigo = New System.Windows.Forms.Label
        Me.fgDetalles = New C1.Win.C1FlexGrid.C1FlexGrid
        Me.ContextMenu1 = New System.Windows.Forms.ContextMenu
        Me.TextBoxProducto = New System.Windows.Forms.TextBox
        Me.ButtonBuscarProducto = New System.Windows.Forms.Button
        Me.TabPageGeneral = New System.Windows.Forms.TabPage
        Me.ButtonGRegresar = New System.Windows.Forms.Button
        Me.ButtonGTerminar = New System.Windows.Forms.Button
        Me.TextBoxGComentarios = New System.Windows.Forms.TextBox
        Me.LabelGComentarios = New System.Windows.Forms.Label
        Me.TextBoxGTotal = New System.Windows.Forms.TextBox
        Me.LabelGTotal = New System.Windows.Forms.Label
        Me.TextBoxGImpuesto = New System.Windows.Forms.TextBox
        Me.LabelGImpuesto = New System.Windows.Forms.Label
        Me.TextBoxGSubTotal = New System.Windows.Forms.TextBox
        Me.LabelGSubTotal = New System.Windows.Forms.Label
        Me.TextBoxGListaPrecio = New System.Windows.Forms.TextBox
        Me.LabelGListaPrecio = New System.Windows.Forms.Label
        Me.TextBoxGFecha = New System.Windows.Forms.TextBox
        Me.LabelGFecha = New System.Windows.Forms.Label
        Me.TextBoxGFase = New System.Windows.Forms.TextBox
        Me.LabelGFase = New System.Windows.Forms.Label
        Me.TextBoxGFolio = New System.Windows.Forms.TextBox
        Me.LabelGFolio = New System.Windows.Forms.Label
        Me.ContextMenu2 = New System.Windows.Forms.ContextMenu
        Me.MenuItemBorrar = New System.Windows.Forms.MenuItem
        Me.MenuItemAgregar = New System.Windows.Forms.MenuItem
        Me.MenuItemModificar = New System.Windows.Forms.MenuItem
        Me.PanelLiquidacion = New System.Windows.Forms.Panel
        Me.ButtonLTerminar = New System.Windows.Forms.Button
        Me.ButtonLRegresar = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.LabelLTotDevF = New System.Windows.Forms.Label
        Me.LabelLTotDev = New System.Windows.Forms.Label
        Me.LabelLSaldoF = New System.Windows.Forms.Label
        Me.LabelLGTotalF = New System.Windows.Forms.Label
        Me.LabelLGTotal = New System.Windows.Forms.Label
        Me.LabelLSaldo = New System.Windows.Forms.Label
        Me.LabelLFolio = New System.Windows.Forms.Label
        Me.fgLiquida = New C1.Win.C1FlexGrid.C1FlexGrid
        Me.lbNombreActividad = New System.Windows.Forms.Label
        Me.PanelLista.SuspendLayout()
        Me.PanelDetalle.SuspendLayout()
        Me.TabVentaConsignacion.SuspendLayout()
        Me.TabPageDetalle.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.TabPageGeneral.SuspendLayout()
        Me.PanelLiquidacion.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MainMenuCargas
        '
        Me.MainMenuCargas.MenuItems.Add(Me.MenuItemRegresar)
        '
        'MenuItemRegresar
        '
        Me.MenuItemRegresar.Text = "MenuItemRegresar"
        '
        'PanelLista
        '
        Me.PanelLista.Controls.Add(Me.LabelTotalSaldoNF)
        Me.PanelLista.Controls.Add(Me.LabelTotalSaldoN)
        Me.PanelLista.Controls.Add(Me.ButtonEliminar)
        Me.PanelLista.Controls.Add(Me.ButtonLiquidar)
        Me.PanelLista.Controls.Add(Me.ListViewConsignacion)
        Me.PanelLista.Controls.Add(Me.ButtonContinuarLista)
        Me.PanelLista.Controls.Add(Me.ButtonRegresarLista)
        Me.PanelLista.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelLista.Location = New System.Drawing.Point(0, 0)
        Me.PanelLista.Name = "PanelLista"
        Me.PanelLista.Size = New System.Drawing.Size(242, 295)
        '
        'LabelTotalSaldoNF
        '
        Me.LabelTotalSaldoNF.Location = New System.Drawing.Point(152, 212)
        Me.LabelTotalSaldoNF.Name = "LabelTotalSaldoNF"
        Me.LabelTotalSaldoNF.Size = New System.Drawing.Size(82, 20)
        '
        'LabelTotalSaldoN
        '
        Me.LabelTotalSaldoN.Location = New System.Drawing.Point(46, 212)
        Me.LabelTotalSaldoN.Name = "LabelTotalSaldoN"
        Me.LabelTotalSaldoN.Size = New System.Drawing.Size(100, 20)
        Me.LabelTotalSaldoN.Text = "LabelTotalSaldoN"
        Me.LabelTotalSaldoN.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'ButtonEliminar
        '
        Me.ButtonEliminar.Enabled = False
        Me.ButtonEliminar.Location = New System.Drawing.Point(7, 263)
        Me.ButtonEliminar.Name = "ButtonEliminar"
        Me.ButtonEliminar.Size = New System.Drawing.Size(74, 24)
        Me.ButtonEliminar.TabIndex = 4
        Me.ButtonEliminar.Text = "ButtonEliminar"
        '
        'ButtonLiquidar
        '
        Me.ButtonLiquidar.Enabled = False
        Me.ButtonLiquidar.Location = New System.Drawing.Point(163, 235)
        Me.ButtonLiquidar.Name = "ButtonLiquidar"
        Me.ButtonLiquidar.Size = New System.Drawing.Size(74, 24)
        Me.ButtonLiquidar.TabIndex = 3
        Me.ButtonLiquidar.Text = "ButtonLiquidar"
        '
        'ListViewConsignacion
        '
        Me.ListViewConsignacion.ContextMenu = Me.ContextMenuNavegacion
        Me.ListViewConsignacion.FullRowSelect = True
        Me.ListViewConsignacion.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.ListViewConsignacion.Location = New System.Drawing.Point(7, 22)
        Me.ListViewConsignacion.Name = "ListViewConsignacion"
        Me.ListViewConsignacion.Size = New System.Drawing.Size(228, 189)
        Me.ListViewConsignacion.TabIndex = 0
        Me.ListViewConsignacion.View = System.Windows.Forms.View.Details
        '
        'ContextMenuNavegacion
        '
        Me.ContextMenuNavegacion.MenuItems.Add(Me.MenuItemModificarN)
        Me.ContextMenuNavegacion.MenuItems.Add(Me.MenuItemLiquidarN)
        Me.ContextMenuNavegacion.MenuItems.Add(Me.MenuItemEliminarN)
        Me.ContextMenuNavegacion.MenuItems.Add(Me.MenuItemDetallesN)
        '
        'MenuItemModificarN
        '
        Me.MenuItemModificarN.Text = "MenuItemModificarN"
        '
        'MenuItemLiquidarN
        '
        Me.MenuItemLiquidarN.Text = "MenuItemLiquidarN"
        '
        'MenuItemEliminarN
        '
        Me.MenuItemEliminarN.Text = "MenuItemEliminarN"
        '
        'MenuItemDetallesN
        '
        Me.MenuItemDetallesN.Text = "MenuItemDetallesN"
        '
        'ButtonContinuarLista
        '
        Me.ButtonContinuarLista.Location = New System.Drawing.Point(7, 235)
        Me.ButtonContinuarLista.Name = "ButtonContinuarLista"
        Me.ButtonContinuarLista.Size = New System.Drawing.Size(74, 24)
        Me.ButtonContinuarLista.TabIndex = 1
        Me.ButtonContinuarLista.Text = "ButtonContinuarLista"
        '
        'ButtonRegresarLista
        '
        Me.ButtonRegresarLista.Location = New System.Drawing.Point(86, 235)
        Me.ButtonRegresarLista.Name = "ButtonRegresarLista"
        Me.ButtonRegresarLista.Size = New System.Drawing.Size(74, 24)
        Me.ButtonRegresarLista.TabIndex = 2
        Me.ButtonRegresarLista.Text = "ButtonRegresarLista"
        '
        'PanelDetalle
        '
        Me.PanelDetalle.Controls.Add(Me.TabVentaConsignacion)
        Me.PanelDetalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelDetalle.Location = New System.Drawing.Point(0, 0)
        Me.PanelDetalle.Name = "PanelDetalle"
        Me.PanelDetalle.Size = New System.Drawing.Size(242, 295)
        '
        'TabVentaConsignacion
        '
        Me.TabVentaConsignacion.Controls.Add(Me.TabPageDetalle)
        Me.TabVentaConsignacion.Controls.Add(Me.TabPageGeneral)
        Me.TabVentaConsignacion.Location = New System.Drawing.Point(0, 0)
        Me.TabVentaConsignacion.Name = "TabVentaConsignacion"
        Me.TabVentaConsignacion.SelectedIndex = 0
        Me.TabVentaConsignacion.Size = New System.Drawing.Size(242, 291)
        Me.TabVentaConsignacion.TabIndex = 0
        '
        'TabPageDetalle
        '
        Me.TabPageDetalle.Controls.Add(Me.Panel2)
        Me.TabPageDetalle.Controls.Add(Me.CheckBoxProducto)
        Me.TabPageDetalle.Controls.Add(Me.ButtonRegresarDet)
        Me.TabPageDetalle.Controls.Add(Me.ButtonContinuarDet)
        Me.TabPageDetalle.Controls.Add(Me.LabelListaPrecios)
        Me.TabPageDetalle.Controls.Add(Me.TextBoxCodigo)
        Me.TabPageDetalle.Controls.Add(Me.LabelCodigo)
        Me.TabPageDetalle.Controls.Add(Me.fgDetalles)
        Me.TabPageDetalle.Controls.Add(Me.TextBoxProducto)
        Me.TabPageDetalle.Controls.Add(Me.ButtonBuscarProducto)
        Me.TabPageDetalle.Location = New System.Drawing.Point(0, 0)
        Me.TabPageDetalle.Name = "TabPageDetalle"
        Me.TabPageDetalle.Size = New System.Drawing.Size(242, 268)
        Me.TabPageDetalle.Text = "TabPageDetalle"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.DarkBlue
        Me.Panel2.Controls.Add(Me.LabelGTotalImporte)
        Me.Panel2.Controls.Add(Me.LabelTotalImporteF)
        Me.Panel2.Controls.Add(Me.LabelTotalProductosF)
        Me.Panel2.Controls.Add(Me.LabelTotalProductos)
        Me.Panel2.Location = New System.Drawing.Point(0, 194)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(234, 38)
        '
        'LabelGTotalImporte
        '
        Me.LabelGTotalImporte.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.LabelGTotalImporte.ForeColor = System.Drawing.Color.White
        Me.LabelGTotalImporte.Location = New System.Drawing.Point(0, 20)
        Me.LabelGTotalImporte.Name = "LabelGTotalImporte"
        Me.LabelGTotalImporte.Size = New System.Drawing.Size(114, 20)
        Me.LabelGTotalImporte.Text = "XTotalImporte"
        '
        'LabelTotalImporteF
        '
        Me.LabelTotalImporteF.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.LabelTotalImporteF.ForeColor = System.Drawing.Color.White
        Me.LabelTotalImporteF.Location = New System.Drawing.Point(120, 20)
        Me.LabelTotalImporteF.Name = "LabelTotalImporteF"
        Me.LabelTotalImporteF.Size = New System.Drawing.Size(109, 20)
        Me.LabelTotalImporteF.Text = "$0.00"
        Me.LabelTotalImporteF.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'LabelTotalProductosF
        '
        Me.LabelTotalProductosF.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.LabelTotalProductosF.ForeColor = System.Drawing.Color.White
        Me.LabelTotalProductosF.Location = New System.Drawing.Point(120, 0)
        Me.LabelTotalProductosF.Name = "LabelTotalProductosF"
        Me.LabelTotalProductosF.Size = New System.Drawing.Size(111, 20)
        Me.LabelTotalProductosF.Text = "0"
        Me.LabelTotalProductosF.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'LabelTotalProductos
        '
        Me.LabelTotalProductos.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.LabelTotalProductos.ForeColor = System.Drawing.Color.White
        Me.LabelTotalProductos.Location = New System.Drawing.Point(0, 0)
        Me.LabelTotalProductos.Name = "LabelTotalProductos"
        Me.LabelTotalProductos.Size = New System.Drawing.Size(114, 20)
        Me.LabelTotalProductos.Text = "LabelTotalProductos"
        '
        'CheckBoxProducto
        '
        Me.CheckBoxProducto.Location = New System.Drawing.Point(0, 34)
        Me.CheckBoxProducto.Name = "CheckBoxProducto"
        Me.CheckBoxProducto.Size = New System.Drawing.Size(85, 20)
        Me.CheckBoxProducto.TabIndex = 28
        Me.CheckBoxProducto.Text = "LabelProducto"
        '
        'ButtonRegresarDet
        '
        Me.ButtonRegresarDet.Location = New System.Drawing.Point(83, 235)
        Me.ButtonRegresarDet.Name = "ButtonRegresarDet"
        Me.ButtonRegresarDet.Size = New System.Drawing.Size(74, 24)
        Me.ButtonRegresarDet.TabIndex = 1
        Me.ButtonRegresarDet.Text = "ButtonRegresarDet"
        '
        'ButtonContinuarDet
        '
        Me.ButtonContinuarDet.Location = New System.Drawing.Point(3, 235)
        Me.ButtonContinuarDet.Name = "ButtonContinuarDet"
        Me.ButtonContinuarDet.Size = New System.Drawing.Size(74, 24)
        Me.ButtonContinuarDet.TabIndex = 2
        Me.ButtonContinuarDet.Text = "ButtonContinuarDet"
        '
        'LabelListaPrecios
        '
        Me.LabelListaPrecios.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.LabelListaPrecios.ForeColor = System.Drawing.Color.Navy
        Me.LabelListaPrecios.Location = New System.Drawing.Point(0, 16)
        Me.LabelListaPrecios.Name = "LabelListaPrecios"
        Me.LabelListaPrecios.Size = New System.Drawing.Size(236, 16)
        '
        'TextBoxCodigo
        '
        Me.TextBoxCodigo.AcceptsReturn = True
        Me.TextBoxCodigo.Location = New System.Drawing.Point(85, 59)
        Me.TextBoxCodigo.Name = "TextBoxCodigo"
        Me.TextBoxCodigo.Size = New System.Drawing.Size(144, 21)
        Me.TextBoxCodigo.TabIndex = 2
        '
        'LabelCodigo
        '
        Me.LabelCodigo.Location = New System.Drawing.Point(5, 59)
        Me.LabelCodigo.Name = "LabelCodigo"
        Me.LabelCodigo.Size = New System.Drawing.Size(80, 16)
        Me.LabelCodigo.Text = "LabelCodigo"
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
        Me.fgDetalles.ContextMenu = Me.ContextMenu1
        Me.fgDetalles.EditMask = Nothing
        Me.fgDetalles.ExtendLastCol = False
        Me.fgDetalles.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.fgDetalles.HighLight = C1.Win.C1FlexGrid.HighLightEnum.WithFocus
        Me.fgDetalles.LeftCol = 1
        Me.fgDetalles.Location = New System.Drawing.Point(8, 84)
        Me.fgDetalles.Name = "fgDetalles"
        Me.fgDetalles.Redraw = True
        Me.fgDetalles.Row = 1
        Me.fgDetalles.RowSel = 1
        Me.fgDetalles.ScrollPosition = New System.Drawing.Point(0, 0)
        Me.fgDetalles.ScrollTrack = True
        Me.fgDetalles.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.fgDetalles.ShowCursor = False
        Me.fgDetalles.ShowSort = True
        Me.fgDetalles.Size = New System.Drawing.Size(224, 106)
        Me.fgDetalles.StyleInfo = resources.GetString("fgDetalles.StyleInfo")
        Me.fgDetalles.SupportInfo = "PQBZAZwBvQCZACQBtACnAOcAggC3AAABFAH3AAkBXwESAQUBLwC+ALwAgACoAIMAggCOAAABmwDHAA=="
        Me.fgDetalles.TabIndex = 27
        Me.fgDetalles.TopRow = 1
        '
        'ContextMenu1
        '
        '
        'TextBoxProducto
        '
        Me.TextBoxProducto.Location = New System.Drawing.Point(85, 35)
        Me.TextBoxProducto.Name = "TextBoxProducto"
        Me.TextBoxProducto.Size = New System.Drawing.Size(118, 21)
        Me.TextBoxProducto.TabIndex = 0
        '
        'ButtonBuscarProducto
        '
        Me.ButtonBuscarProducto.Location = New System.Drawing.Point(205, 35)
        Me.ButtonBuscarProducto.Name = "ButtonBuscarProducto"
        Me.ButtonBuscarProducto.Size = New System.Drawing.Size(24, 21)
        Me.ButtonBuscarProducto.TabIndex = 1
        Me.ButtonBuscarProducto.Text = "..."
        '
        'TabPageGeneral
        '
        Me.TabPageGeneral.Controls.Add(Me.ButtonGRegresar)
        Me.TabPageGeneral.Controls.Add(Me.ButtonGTerminar)
        Me.TabPageGeneral.Controls.Add(Me.TextBoxGComentarios)
        Me.TabPageGeneral.Controls.Add(Me.LabelGComentarios)
        Me.TabPageGeneral.Controls.Add(Me.TextBoxGTotal)
        Me.TabPageGeneral.Controls.Add(Me.LabelGTotal)
        Me.TabPageGeneral.Controls.Add(Me.TextBoxGImpuesto)
        Me.TabPageGeneral.Controls.Add(Me.LabelGImpuesto)
        Me.TabPageGeneral.Controls.Add(Me.TextBoxGSubTotal)
        Me.TabPageGeneral.Controls.Add(Me.LabelGSubTotal)
        Me.TabPageGeneral.Controls.Add(Me.TextBoxGListaPrecio)
        Me.TabPageGeneral.Controls.Add(Me.LabelGListaPrecio)
        Me.TabPageGeneral.Controls.Add(Me.TextBoxGFecha)
        Me.TabPageGeneral.Controls.Add(Me.LabelGFecha)
        Me.TabPageGeneral.Controls.Add(Me.TextBoxGFase)
        Me.TabPageGeneral.Controls.Add(Me.LabelGFase)
        Me.TabPageGeneral.Controls.Add(Me.TextBoxGFolio)
        Me.TabPageGeneral.Controls.Add(Me.LabelGFolio)
        Me.TabPageGeneral.Location = New System.Drawing.Point(0, 0)
        Me.TabPageGeneral.Name = "TabPageGeneral"
        Me.TabPageGeneral.Size = New System.Drawing.Size(234, 265)
        Me.TabPageGeneral.Text = "TabPageGeneral"
        '
        'ButtonGRegresar
        '
        Me.ButtonGRegresar.Location = New System.Drawing.Point(83, 239)
        Me.ButtonGRegresar.Name = "ButtonGRegresar"
        Me.ButtonGRegresar.Size = New System.Drawing.Size(74, 24)
        Me.ButtonGRegresar.TabIndex = 31
        Me.ButtonGRegresar.Text = "ButtonGRegresar"
        '
        'ButtonGTerminar
        '
        Me.ButtonGTerminar.Location = New System.Drawing.Point(3, 239)
        Me.ButtonGTerminar.Name = "ButtonGTerminar"
        Me.ButtonGTerminar.Size = New System.Drawing.Size(74, 24)
        Me.ButtonGTerminar.TabIndex = 30
        Me.ButtonGTerminar.Text = "ButtonGTerminar"
        '
        'TextBoxGComentarios
        '
        Me.TextBoxGComentarios.Location = New System.Drawing.Point(101, 189)
        Me.TextBoxGComentarios.Multiline = True
        Me.TextBoxGComentarios.Name = "TextBoxGComentarios"
        Me.TextBoxGComentarios.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBoxGComentarios.Size = New System.Drawing.Size(127, 47)
        Me.TextBoxGComentarios.TabIndex = 21
        '
        'LabelGComentarios
        '
        Me.LabelGComentarios.Location = New System.Drawing.Point(-1, 192)
        Me.LabelGComentarios.Name = "LabelGComentarios"
        Me.LabelGComentarios.Size = New System.Drawing.Size(96, 20)
        Me.LabelGComentarios.Text = "LabelGComentarios"
        '
        'TextBoxGTotal
        '
        Me.TextBoxGTotal.Location = New System.Drawing.Point(101, 165)
        Me.TextBoxGTotal.Name = "TextBoxGTotal"
        Me.TextBoxGTotal.ReadOnly = True
        Me.TextBoxGTotal.Size = New System.Drawing.Size(127, 21)
        Me.TextBoxGTotal.TabIndex = 18
        '
        'LabelGTotal
        '
        Me.LabelGTotal.Location = New System.Drawing.Point(0, 168)
        Me.LabelGTotal.Name = "LabelGTotal"
        Me.LabelGTotal.Size = New System.Drawing.Size(95, 20)
        Me.LabelGTotal.Text = "LabelGTotal"
        '
        'TextBoxGImpuesto
        '
        Me.TextBoxGImpuesto.Location = New System.Drawing.Point(101, 141)
        Me.TextBoxGImpuesto.Name = "TextBoxGImpuesto"
        Me.TextBoxGImpuesto.ReadOnly = True
        Me.TextBoxGImpuesto.Size = New System.Drawing.Size(127, 21)
        Me.TextBoxGImpuesto.TabIndex = 13
        '
        'LabelGImpuesto
        '
        Me.LabelGImpuesto.Location = New System.Drawing.Point(0, 144)
        Me.LabelGImpuesto.Name = "LabelGImpuesto"
        Me.LabelGImpuesto.Size = New System.Drawing.Size(95, 20)
        Me.LabelGImpuesto.Text = "LabelGImpuesto"
        '
        'TextBoxGSubTotal
        '
        Me.TextBoxGSubTotal.Location = New System.Drawing.Point(101, 117)
        Me.TextBoxGSubTotal.Name = "TextBoxGSubTotal"
        Me.TextBoxGSubTotal.ReadOnly = True
        Me.TextBoxGSubTotal.Size = New System.Drawing.Size(127, 21)
        Me.TextBoxGSubTotal.TabIndex = 12
        '
        'LabelGSubTotal
        '
        Me.LabelGSubTotal.Location = New System.Drawing.Point(0, 120)
        Me.LabelGSubTotal.Name = "LabelGSubTotal"
        Me.LabelGSubTotal.Size = New System.Drawing.Size(95, 20)
        Me.LabelGSubTotal.Text = "LabelGSubTotal"
        '
        'TextBoxGListaPrecio
        '
        Me.TextBoxGListaPrecio.Location = New System.Drawing.Point(101, 93)
        Me.TextBoxGListaPrecio.Name = "TextBoxGListaPrecio"
        Me.TextBoxGListaPrecio.ReadOnly = True
        Me.TextBoxGListaPrecio.Size = New System.Drawing.Size(127, 21)
        Me.TextBoxGListaPrecio.TabIndex = 11
        '
        'LabelGListaPrecio
        '
        Me.LabelGListaPrecio.Location = New System.Drawing.Point(0, 96)
        Me.LabelGListaPrecio.Name = "LabelGListaPrecio"
        Me.LabelGListaPrecio.Size = New System.Drawing.Size(95, 20)
        Me.LabelGListaPrecio.Text = "LabelGListaPrecio"
        '
        'TextBoxGFecha
        '
        Me.TextBoxGFecha.Location = New System.Drawing.Point(101, 69)
        Me.TextBoxGFecha.Name = "TextBoxGFecha"
        Me.TextBoxGFecha.ReadOnly = True
        Me.TextBoxGFecha.Size = New System.Drawing.Size(127, 21)
        Me.TextBoxGFecha.TabIndex = 6
        '
        'LabelGFecha
        '
        Me.LabelGFecha.Location = New System.Drawing.Point(0, 72)
        Me.LabelGFecha.Name = "LabelGFecha"
        Me.LabelGFecha.Size = New System.Drawing.Size(95, 20)
        Me.LabelGFecha.Text = "LabelGFecha"
        '
        'TextBoxGFase
        '
        Me.TextBoxGFase.Location = New System.Drawing.Point(101, 45)
        Me.TextBoxGFase.Name = "TextBoxGFase"
        Me.TextBoxGFase.ReadOnly = True
        Me.TextBoxGFase.Size = New System.Drawing.Size(127, 21)
        Me.TextBoxGFase.TabIndex = 3
        '
        'LabelGFase
        '
        Me.LabelGFase.Location = New System.Drawing.Point(0, 48)
        Me.LabelGFase.Name = "LabelGFase"
        Me.LabelGFase.Size = New System.Drawing.Size(95, 20)
        Me.LabelGFase.Text = "LabelGFase"
        '
        'TextBoxGFolio
        '
        Me.TextBoxGFolio.Location = New System.Drawing.Point(101, 21)
        Me.TextBoxGFolio.Name = "TextBoxGFolio"
        Me.TextBoxGFolio.ReadOnly = True
        Me.TextBoxGFolio.Size = New System.Drawing.Size(127, 21)
        Me.TextBoxGFolio.TabIndex = 1
        '
        'LabelGFolio
        '
        Me.LabelGFolio.Location = New System.Drawing.Point(0, 24)
        Me.LabelGFolio.Name = "LabelGFolio"
        Me.LabelGFolio.Size = New System.Drawing.Size(95, 20)
        Me.LabelGFolio.Text = "LabelGFolio"
        '
        'ContextMenu2
        '
        Me.ContextMenu2.MenuItems.Add(Me.MenuItemBorrar)
        Me.ContextMenu2.MenuItems.Add(Me.MenuItemAgregar)
        Me.ContextMenu2.MenuItems.Add(Me.MenuItemModificar)
        '
        'MenuItemBorrar
        '
        Me.MenuItemBorrar.Text = "MenuItemBorrar"
        '
        'MenuItemAgregar
        '
        Me.MenuItemAgregar.Text = "MenuItemAgregar"
        '
        'MenuItemModificar
        '
        Me.MenuItemModificar.Text = "MenuItemModificar"
        '
        'PanelLiquidacion
        '
        Me.PanelLiquidacion.Controls.Add(Me.ButtonLTerminar)
        Me.PanelLiquidacion.Controls.Add(Me.ButtonLRegresar)
        Me.PanelLiquidacion.Controls.Add(Me.Panel1)
        Me.PanelLiquidacion.Controls.Add(Me.LabelLFolio)
        Me.PanelLiquidacion.Controls.Add(Me.fgLiquida)
        Me.PanelLiquidacion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelLiquidacion.Location = New System.Drawing.Point(0, 0)
        Me.PanelLiquidacion.Name = "PanelLiquidacion"
        Me.PanelLiquidacion.Size = New System.Drawing.Size(242, 295)
        '
        'ButtonLTerminar
        '
        Me.ButtonLTerminar.Location = New System.Drawing.Point(3, 264)
        Me.ButtonLTerminar.Name = "ButtonLTerminar"
        Me.ButtonLTerminar.Size = New System.Drawing.Size(74, 24)
        Me.ButtonLTerminar.TabIndex = 32
        Me.ButtonLTerminar.Text = "ButtonLTerminar"
        '
        'ButtonLRegresar
        '
        Me.ButtonLRegresar.Location = New System.Drawing.Point(83, 264)
        Me.ButtonLRegresar.Name = "ButtonLRegresar"
        Me.ButtonLRegresar.Size = New System.Drawing.Size(74, 24)
        Me.ButtonLRegresar.TabIndex = 33
        Me.ButtonLRegresar.Text = "ButtonLRegresar"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DarkBlue
        Me.Panel1.Controls.Add(Me.LabelLTotDevF)
        Me.Panel1.Controls.Add(Me.LabelLTotDev)
        Me.Panel1.Controls.Add(Me.LabelLSaldoF)
        Me.Panel1.Controls.Add(Me.LabelLGTotalF)
        Me.Panel1.Controls.Add(Me.LabelLGTotal)
        Me.Panel1.Controls.Add(Me.LabelLSaldo)
        Me.Panel1.Location = New System.Drawing.Point(3, 205)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(234, 58)
        '
        'LabelLTotDevF
        '
        Me.LabelLTotDevF.BackColor = System.Drawing.Color.DarkBlue
        Me.LabelLTotDevF.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.LabelLTotDevF.ForeColor = System.Drawing.Color.White
        Me.LabelLTotDevF.Location = New System.Drawing.Point(116, 20)
        Me.LabelLTotDevF.Name = "LabelLTotDevF"
        Me.LabelLTotDevF.Size = New System.Drawing.Size(115, 20)
        Me.LabelLTotDevF.Text = "$0.00"
        Me.LabelLTotDevF.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'LabelLTotDev
        '
        Me.LabelLTotDev.BackColor = System.Drawing.Color.DarkBlue
        Me.LabelLTotDev.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.LabelLTotDev.ForeColor = System.Drawing.Color.White
        Me.LabelLTotDev.Location = New System.Drawing.Point(0, 20)
        Me.LabelLTotDev.Name = "LabelLTotDev"
        Me.LabelLTotDev.Size = New System.Drawing.Size(115, 20)
        Me.LabelLTotDev.Text = "LabelLTotDev"
        '
        'LabelLSaldoF
        '
        Me.LabelLSaldoF.BackColor = System.Drawing.Color.DarkBlue
        Me.LabelLSaldoF.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.LabelLSaldoF.ForeColor = System.Drawing.Color.White
        Me.LabelLSaldoF.Location = New System.Drawing.Point(116, 40)
        Me.LabelLSaldoF.Name = "LabelLSaldoF"
        Me.LabelLSaldoF.Size = New System.Drawing.Size(115, 20)
        Me.LabelLSaldoF.Text = "$0.00"
        Me.LabelLSaldoF.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'LabelLGTotalF
        '
        Me.LabelLGTotalF.BackColor = System.Drawing.Color.DarkBlue
        Me.LabelLGTotalF.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.LabelLGTotalF.ForeColor = System.Drawing.Color.White
        Me.LabelLGTotalF.Location = New System.Drawing.Point(116, 0)
        Me.LabelLGTotalF.Name = "LabelLGTotalF"
        Me.LabelLGTotalF.Size = New System.Drawing.Size(115, 20)
        Me.LabelLGTotalF.Text = "$0.00"
        Me.LabelLGTotalF.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'LabelLGTotal
        '
        Me.LabelLGTotal.BackColor = System.Drawing.Color.DarkBlue
        Me.LabelLGTotal.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.LabelLGTotal.ForeColor = System.Drawing.Color.White
        Me.LabelLGTotal.Location = New System.Drawing.Point(0, 0)
        Me.LabelLGTotal.Name = "LabelLGTotal"
        Me.LabelLGTotal.Size = New System.Drawing.Size(115, 20)
        Me.LabelLGTotal.Text = "LabelLGTotal"
        '
        'LabelLSaldo
        '
        Me.LabelLSaldo.BackColor = System.Drawing.Color.DarkBlue
        Me.LabelLSaldo.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.LabelLSaldo.ForeColor = System.Drawing.Color.White
        Me.LabelLSaldo.Location = New System.Drawing.Point(0, 40)
        Me.LabelLSaldo.Name = "LabelLSaldo"
        Me.LabelLSaldo.Size = New System.Drawing.Size(115, 20)
        Me.LabelLSaldo.Text = "LabelLSaldo"
        '
        'LabelLFolio
        '
        Me.LabelLFolio.Location = New System.Drawing.Point(3, 16)
        Me.LabelLFolio.Name = "LabelLFolio"
        Me.LabelLFolio.Size = New System.Drawing.Size(200, 20)
        '
        'fgLiquida
        '
        Me.fgLiquida.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.fgLiquida.AllowEditing = False
        Me.fgLiquida.AutoResize = True
        Me.fgLiquida.AutoSearchDelay = 2
        Me.fgLiquida.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.fgLiquida.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.fgLiquida.Clip = ""
        Me.fgLiquida.ClipSeparators = "" & Global.Microsoft.VisualBasic.ChrW(9) & Global.Microsoft.VisualBasic.ChrW(13)
        Me.fgLiquida.Col = 1
        Me.fgLiquida.ColSel = 1
        Me.fgLiquida.ComboList = Nothing
        Me.fgLiquida.EditMask = Nothing
        Me.fgLiquida.ExtendLastCol = False
        Me.fgLiquida.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.fgLiquida.HighLight = C1.Win.C1FlexGrid.HighLightEnum.WithFocus
        Me.fgLiquida.LeftCol = 1
        Me.fgLiquida.Location = New System.Drawing.Point(3, 37)
        Me.fgLiquida.Name = "fgLiquida"
        Me.fgLiquida.Redraw = True
        Me.fgLiquida.Row = 1
        Me.fgLiquida.RowSel = 1
        Me.fgLiquida.ScrollPosition = New System.Drawing.Point(0, 0)
        Me.fgLiquida.ScrollTrack = True
        Me.fgLiquida.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.fgLiquida.ShowCursor = False
        Me.fgLiquida.ShowSort = True
        Me.fgLiquida.Size = New System.Drawing.Size(234, 165)
        Me.fgLiquida.StyleInfo = resources.GetString("fgLiquida.StyleInfo")
        Me.fgLiquida.SupportInfo = "jQBxAfIA2wDjADUBAgHvAIkAsQA9AfsAsQDhAFMB9gBDAPoAGAF8ABwBOwBQAHoAuQDaAMYAiQA="
        Me.fgLiquida.TabIndex = 28
        Me.fgLiquida.TopRow = 1
        '
        'lbNombreActividad
        '
        Me.lbNombreActividad.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lbNombreActividad.Location = New System.Drawing.Point(0, 0)
        Me.lbNombreActividad.Name = "lbNombreActividad"
        Me.lbNombreActividad.Size = New System.Drawing.Size(100, 17)
        Me.lbNombreActividad.Text = "lbNombreActividad"
        Me.lbNombreActividad.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'FormVentaConsignacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(242, 295)
        Me.ControlBox = False
        Me.Controls.Add(Me.lbNombreActividad)
        Me.Controls.Add(Me.PanelLista)
        Me.Controls.Add(Me.PanelDetalle)
        Me.Controls.Add(Me.PanelLiquidacion)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.Menu = Me.MainMenuCargas
        Me.MinimizeBox = False
        Me.Name = "FormVentaConsignacion"
        Me.Text = "FormVentaConsignacion"
        Me.PanelLista.ResumeLayout(False)
        Me.PanelDetalle.ResumeLayout(False)
        Me.TabVentaConsignacion.ResumeLayout(False)
        Me.TabPageDetalle.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.TabPageGeneral.ResumeLayout(False)
        Me.PanelLiquidacion.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MenuItemRegresar As System.Windows.Forms.MenuItem
    Friend WithEvents PanelLista As System.Windows.Forms.Panel
    Friend WithEvents ListViewConsignacion As System.Windows.Forms.ListView
    Friend WithEvents ButtonContinuarLista As System.Windows.Forms.Button
    Friend WithEvents ButtonRegresarLista As System.Windows.Forms.Button
    Friend WithEvents PanelDetalle As System.Windows.Forms.Panel
    Friend WithEvents TabVentaConsignacion As System.Windows.Forms.TabControl
    Friend WithEvents TabPageDetalle As System.Windows.Forms.TabPage
    Friend WithEvents TextBoxCodigo As System.Windows.Forms.TextBox
    Friend WithEvents LabelCodigo As System.Windows.Forms.Label
    Friend WithEvents fgDetalles As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents TextBoxProducto As System.Windows.Forms.TextBox
    Friend WithEvents ButtonBuscarProducto As System.Windows.Forms.Button
    Friend WithEvents ButtonRegresarDet As System.Windows.Forms.Button
    Friend WithEvents ButtonContinuarDet As System.Windows.Forms.Button
    Friend WithEvents ContextMenu1 As System.Windows.Forms.ContextMenu
    Friend WithEvents ContextMenu2 As System.Windows.Forms.ContextMenu
    Friend WithEvents MenuItemBorrar As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemModificar As System.Windows.Forms.MenuItem
    Friend WithEvents ButtonEliminar As System.Windows.Forms.Button
    Friend WithEvents ButtonLiquidar As System.Windows.Forms.Button
    Friend WithEvents MenuItemAgregar As System.Windows.Forms.MenuItem
    Friend WithEvents LabelTotalSaldoNF As System.Windows.Forms.Label
    Friend WithEvents LabelTotalSaldoN As System.Windows.Forms.Label
    Friend WithEvents TabPageGeneral As System.Windows.Forms.TabPage
    Friend WithEvents LabelListaPrecios As System.Windows.Forms.Label
    Friend WithEvents LabelTotalImporteF As System.Windows.Forms.Label
    Friend WithEvents LabelTotalProductos As System.Windows.Forms.Label
    Friend WithEvents LabelTotalProductosF As System.Windows.Forms.Label
    Friend WithEvents TextBoxGTotal As System.Windows.Forms.TextBox
    Friend WithEvents LabelGTotal As System.Windows.Forms.Label
    Friend WithEvents TextBoxGImpuesto As System.Windows.Forms.TextBox
    Friend WithEvents LabelGImpuesto As System.Windows.Forms.Label
    Friend WithEvents TextBoxGSubTotal As System.Windows.Forms.TextBox
    Friend WithEvents LabelGSubTotal As System.Windows.Forms.Label
    Friend WithEvents TextBoxGListaPrecio As System.Windows.Forms.TextBox
    Friend WithEvents LabelGListaPrecio As System.Windows.Forms.Label
    Friend WithEvents TextBoxGFecha As System.Windows.Forms.TextBox
    Friend WithEvents LabelGFecha As System.Windows.Forms.Label
    Friend WithEvents TextBoxGFase As System.Windows.Forms.TextBox
    Friend WithEvents LabelGFase As System.Windows.Forms.Label
    Friend WithEvents TextBoxGFolio As System.Windows.Forms.TextBox
    Friend WithEvents LabelGFolio As System.Windows.Forms.Label
    Friend WithEvents TextBoxGComentarios As System.Windows.Forms.TextBox
    Friend WithEvents LabelGComentarios As System.Windows.Forms.Label
    Friend WithEvents ButtonGRegresar As System.Windows.Forms.Button
    Friend WithEvents ButtonGTerminar As System.Windows.Forms.Button
    Friend WithEvents CheckBoxProducto As System.Windows.Forms.CheckBox
    Friend WithEvents ContextMenuNavegacion As System.Windows.Forms.ContextMenu
    Friend WithEvents MenuItemModificarN As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemLiquidarN As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemEliminarN As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemDetallesN As System.Windows.Forms.MenuItem
    Friend WithEvents PanelLiquidacion As System.Windows.Forms.Panel
    Friend WithEvents fgLiquida As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents ButtonLRegresar As System.Windows.Forms.Button
    Friend WithEvents ButtonLTerminar As System.Windows.Forms.Button
    Friend WithEvents LabelLFolio As System.Windows.Forms.Label
    Friend WithEvents LabelLGTotal As System.Windows.Forms.Label
    Friend WithEvents LabelLGTotalF As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents LabelGTotalImporte As System.Windows.Forms.Label
    Friend WithEvents LabelLSaldo As System.Windows.Forms.Label
    Friend WithEvents LabelLSaldoF As System.Windows.Forms.Label
    Friend WithEvents LabelLTotDevF As System.Windows.Forms.Label
    Friend WithEvents LabelLTotDev As System.Windows.Forms.Label
    Friend WithEvents lbNombreActividad As System.Windows.Forms.Label
End Class
