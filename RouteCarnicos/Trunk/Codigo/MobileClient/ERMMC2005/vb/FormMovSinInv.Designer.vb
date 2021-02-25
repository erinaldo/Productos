<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class FormMovSinInv
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If (Not IsNothing(ListViewMovSinInv)) Then
            If (ListViewMovSinInv.Columns.Count) Then
                ListViewMovSinInv.Columns.Clear()
                'For Each c As ColumnHeader In ListViewMovSinInv.Columns
                ' c.Dispose()
                ' Next
            End If
        End If
        If (Not IsNothing(fgDetalles)) Then
            fgDetalles.Clear()
            fgDetalles.ContextMenu = Nothing
            fgDetalles.Dispose()
        End If
        If Not Me.MenuItemEliminar Is Nothing Then Me.MenuItemEliminar.Dispose()
        If Not Me.MenuItemModificar Is Nothing Then Me.MenuItemModificar.Dispose()
        If Not Me.MenuItemRegresar Is Nothing Then Me.MenuItemRegresar.Dispose()
        If Not Me.MainMenu1 Is Nothing Then Me.MainMenu1.Dispose()
        If Not Me.ContextMenu1 Is Nothing Then
            Me.ContextMenu1.Dispose()
            Me.ContextMenu1 = Nothing
        End If
        If Not Me.ContextMenu2 Is Nothing Then
            Me.ContextMenu2.Dispose()
            Me.ContextMenu2 = Nothing
        End If
#If MOD_TERM <> "PALM" Then
        If Not Me.bScanner Is Nothing Then
            bScanner.Dispose()
            bScanner = Nothing
        End If
#End If
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)

    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMovSinInv))
        Me.PanelLista = New System.Windows.Forms.Panel
        Me.ListViewMovSinInv = New System.Windows.Forms.ListView
        Me.ButtonContinuar = New System.Windows.Forms.Button
        Me.ButtonRegresar = New System.Windows.Forms.Button
        Me.ButtonEliminar = New System.Windows.Forms.Button
        Me.PanelDetalle = New System.Windows.Forms.Panel
        Me.LabelListaPrecios = New System.Windows.Forms.Label
        Me.PanelPie = New System.Windows.Forms.Panel
        Me.LabelTotalProductos = New System.Windows.Forms.Label
        Me.LabelTotal = New System.Windows.Forms.Label
        Me.fgDetalles = New C1.Win.C1FlexGrid.C1FlexGrid
        Me.ContextMenu2 = New System.Windows.Forms.ContextMenu
        Me.TextBoxCodigo = New System.Windows.Forms.TextBox
        Me.LabelCodigo = New System.Windows.Forms.Label
        Me.ButtonContDet = New System.Windows.Forms.Button
        Me.ButtonRegDet = New System.Windows.Forms.Button
        Me.TextBoxProducto = New System.Windows.Forms.TextBox
        Me.ButtonBuscarProducto = New System.Windows.Forms.Button
        Me.LabelProducto = New System.Windows.Forms.Label
        Me.ContextMenu1 = New System.Windows.Forms.ContextMenu
        Me.MenuItemEliminar = New System.Windows.Forms.MenuItem
        Me.MenuItemModificar = New System.Windows.Forms.MenuItem
        Me.MainMenu1 = New System.Windows.Forms.MainMenu
        Me.MenuItemRegresar = New System.Windows.Forms.MenuItem
        Me.PanelLista.SuspendLayout()
        Me.PanelDetalle.SuspendLayout()
        Me.PanelPie.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelLista
        '
        Me.PanelLista.Controls.Add(Me.ListViewMovSinInv)
        Me.PanelLista.Controls.Add(Me.ButtonContinuar)
        Me.PanelLista.Controls.Add(Me.ButtonRegresar)
        Me.PanelLista.Controls.Add(Me.ButtonEliminar)
        Me.PanelLista.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelLista.Location = New System.Drawing.Point(0, 0)
        Me.PanelLista.Name = "PanelLista"
        Me.PanelLista.Size = New System.Drawing.Size(242, 295)
        '
        'ListViewMovSinInv
        '
        Me.ListViewMovSinInv.CheckBoxes = True
        Me.ListViewMovSinInv.FullRowSelect = True
        Me.ListViewMovSinInv.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.ListViewMovSinInv.Location = New System.Drawing.Point(3, 5)
        Me.ListViewMovSinInv.Name = "ListViewMovSinInv"
        Me.ListViewMovSinInv.Size = New System.Drawing.Size(234, 254)
        Me.ListViewMovSinInv.TabIndex = 10
        Me.ListViewMovSinInv.View = System.Windows.Forms.View.Details
        '
        'ButtonContinuar
        '
        Me.ButtonContinuar.Location = New System.Drawing.Point(3, 262)
        Me.ButtonContinuar.Name = "ButtonContinuar"
        Me.ButtonContinuar.Size = New System.Drawing.Size(72, 24)
        Me.ButtonContinuar.TabIndex = 9
        Me.ButtonContinuar.Text = "ButtonContinuar"
        '
        'ButtonRegresar
        '
        Me.ButtonRegresar.Location = New System.Drawing.Point(81, 262)
        Me.ButtonRegresar.Name = "ButtonRegresar"
        Me.ButtonRegresar.Size = New System.Drawing.Size(72, 24)
        Me.ButtonRegresar.TabIndex = 8
        Me.ButtonRegresar.Text = "ButtonRegresar"
        '
        'ButtonEliminar
        '
        Me.ButtonEliminar.Location = New System.Drawing.Point(159, 262)
        Me.ButtonEliminar.Name = "ButtonEliminar"
        Me.ButtonEliminar.Size = New System.Drawing.Size(72, 24)
        Me.ButtonEliminar.TabIndex = 7
        Me.ButtonEliminar.Text = "ButtonEliminar"
        '
        'PanelDetalle
        '
        Me.PanelDetalle.Controls.Add(Me.LabelListaPrecios)
        Me.PanelDetalle.Controls.Add(Me.PanelPie)
        Me.PanelDetalle.Controls.Add(Me.fgDetalles)
        Me.PanelDetalle.Controls.Add(Me.TextBoxCodigo)
        Me.PanelDetalle.Controls.Add(Me.LabelCodigo)
        Me.PanelDetalle.Controls.Add(Me.ButtonContDet)
        Me.PanelDetalle.Controls.Add(Me.ButtonRegDet)
        Me.PanelDetalle.Controls.Add(Me.TextBoxProducto)
        Me.PanelDetalle.Controls.Add(Me.ButtonBuscarProducto)
        Me.PanelDetalle.Controls.Add(Me.LabelProducto)
        Me.PanelDetalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelDetalle.Location = New System.Drawing.Point(0, 0)
        Me.PanelDetalle.Name = "PanelDetalle"
        Me.PanelDetalle.Size = New System.Drawing.Size(242, 295)
        '
        'LabelListaPrecios
        '
        Me.LabelListaPrecios.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.LabelListaPrecios.ForeColor = System.Drawing.Color.Navy
        Me.LabelListaPrecios.Location = New System.Drawing.Point(0, 8)
        Me.LabelListaPrecios.Name = "LabelListaPrecios"
        Me.LabelListaPrecios.Size = New System.Drawing.Size(236, 16)
        '
        'PanelPie
        '
        Me.PanelPie.BackColor = System.Drawing.Color.DarkBlue
        Me.PanelPie.Controls.Add(Me.LabelTotalProductos)
        Me.PanelPie.Controls.Add(Me.LabelTotal)
        Me.PanelPie.Location = New System.Drawing.Point(3, 237)
        Me.PanelPie.Name = "PanelPie"
        Me.PanelPie.Size = New System.Drawing.Size(237, 20)
        '
        'LabelTotalProductos
        '
        Me.LabelTotalProductos.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold)
        Me.LabelTotalProductos.ForeColor = System.Drawing.Color.GhostWhite
        Me.LabelTotalProductos.Location = New System.Drawing.Point(4, 0)
        Me.LabelTotalProductos.Name = "LabelTotalProductos"
        Me.LabelTotalProductos.Size = New System.Drawing.Size(118, 20)
        '
        'LabelTotal
        '
        Me.LabelTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold)
        Me.LabelTotal.ForeColor = System.Drawing.Color.GhostWhite
        Me.LabelTotal.Location = New System.Drawing.Point(133, 0)
        Me.LabelTotal.Name = "LabelTotal"
        Me.LabelTotal.Size = New System.Drawing.Size(100, 20)
        Me.LabelTotal.TextAlign = System.Drawing.ContentAlignment.TopRight
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
        Me.fgDetalles.ContextMenu = Me.ContextMenu2
        Me.fgDetalles.EditMask = Nothing
        Me.fgDetalles.ExtendLastCol = False
        Me.fgDetalles.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.fgDetalles.HighLight = C1.Win.C1FlexGrid.HighLightEnum.WithFocus
        Me.fgDetalles.LeftCol = 1
        Me.fgDetalles.Location = New System.Drawing.Point(7, 83)
        Me.fgDetalles.Name = "fgDetalles"
        Me.fgDetalles.Redraw = True
        Me.fgDetalles.Row = 1
        Me.fgDetalles.RowSel = 1
        Me.fgDetalles.ScrollPosition = New System.Drawing.Point(0, 0)
        Me.fgDetalles.ScrollTrack = True
        Me.fgDetalles.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.fgDetalles.ShowCursor = False
        Me.fgDetalles.ShowSort = True
        Me.fgDetalles.Size = New System.Drawing.Size(224, 148)
        Me.fgDetalles.StyleInfo = resources.GetString("fgDetalles.StyleInfo")
        Me.fgDetalles.SupportInfo = "AAH2AEgBNgHDABMBtACRAGwA9QBaAWYAHwFDAdoAGwGnANAAJQGKAMAA3ABzAAwBsAADARoBfgBNAA=="
        Me.fgDetalles.TabIndex = 28
        Me.fgDetalles.TopRow = 1
        '
        'ContextMenu2
        '
        '
        'TextBoxCodigo
        '
        Me.TextBoxCodigo.AcceptsReturn = True
        Me.TextBoxCodigo.Location = New System.Drawing.Point(87, 54)
        Me.TextBoxCodigo.Name = "TextBoxCodigo"
        Me.TextBoxCodigo.Size = New System.Drawing.Size(144, 21)
        Me.TextBoxCodigo.TabIndex = 14
        '
        'LabelCodigo
        '
        Me.LabelCodigo.Location = New System.Drawing.Point(7, 54)
        Me.LabelCodigo.Name = "LabelCodigo"
        Me.LabelCodigo.Size = New System.Drawing.Size(80, 16)
        Me.LabelCodigo.Text = "LabelCodigo"
        '
        'ButtonContDet
        '
        Me.ButtonContDet.Location = New System.Drawing.Point(3, 262)
        Me.ButtonContDet.Name = "ButtonContDet"
        Me.ButtonContDet.Size = New System.Drawing.Size(72, 24)
        Me.ButtonContDet.TabIndex = 11
        Me.ButtonContDet.Text = "ButtonContDet"
        '
        'ButtonRegDet
        '
        Me.ButtonRegDet.Location = New System.Drawing.Point(81, 262)
        Me.ButtonRegDet.Name = "ButtonRegDet"
        Me.ButtonRegDet.Size = New System.Drawing.Size(72, 24)
        Me.ButtonRegDet.TabIndex = 10
        Me.ButtonRegDet.Text = "ButtonRegDet"
        '
        'TextBoxProducto
        '
        Me.TextBoxProducto.Location = New System.Drawing.Point(87, 27)
        Me.TextBoxProducto.Name = "TextBoxProducto"
        Me.TextBoxProducto.Size = New System.Drawing.Size(118, 21)
        Me.TextBoxProducto.TabIndex = 6
        '
        'ButtonBuscarProducto
        '
        Me.ButtonBuscarProducto.Location = New System.Drawing.Point(207, 27)
        Me.ButtonBuscarProducto.Name = "ButtonBuscarProducto"
        Me.ButtonBuscarProducto.Size = New System.Drawing.Size(24, 21)
        Me.ButtonBuscarProducto.TabIndex = 7
        Me.ButtonBuscarProducto.Text = "..."
        '
        'LabelProducto
        '
        Me.LabelProducto.Location = New System.Drawing.Point(7, 27)
        Me.LabelProducto.Name = "LabelProducto"
        Me.LabelProducto.Size = New System.Drawing.Size(80, 16)
        Me.LabelProducto.Text = "LabelProducto"
        '
        'ContextMenu1
        '
        Me.ContextMenu1.MenuItems.Add(Me.MenuItemEliminar)
        Me.ContextMenu1.MenuItems.Add(Me.MenuItemModificar)
        '
        'MenuItemEliminar
        '
        Me.MenuItemEliminar.Text = "MenuItemEliminar"
        '
        'MenuItemModificar
        '
        Me.MenuItemModificar.Text = "MenuItemModificar"
        '
        'MainMenu1
        '
        Me.MainMenu1.MenuItems.Add(Me.MenuItemRegresar)
        '
        'MenuItemRegresar
        '
        Me.MenuItemRegresar.Text = "Regresar"
        '
        'FormMovSinInv
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(242, 295)
        Me.ControlBox = False
        Me.Controls.Add(Me.PanelLista)
        Me.Controls.Add(Me.PanelDetalle)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Menu = Me.MainMenu1
        Me.Name = "FormMovSinInv"
        Me.PanelLista.ResumeLayout(False)
        Me.PanelDetalle.ResumeLayout(False)
        Me.PanelPie.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelLista As System.Windows.Forms.Panel
    Friend WithEvents ButtonEliminar As System.Windows.Forms.Button
    Friend WithEvents ButtonRegresar As System.Windows.Forms.Button
    Friend WithEvents ButtonContinuar As System.Windows.Forms.Button
    Friend WithEvents PanelDetalle As System.Windows.Forms.Panel
    Friend WithEvents ButtonContDet As System.Windows.Forms.Button
    Friend WithEvents ButtonRegDet As System.Windows.Forms.Button
    Friend WithEvents TextBoxProducto As System.Windows.Forms.TextBox
    Friend WithEvents ButtonBuscarProducto As System.Windows.Forms.Button
    Friend WithEvents LabelProducto As System.Windows.Forms.Label
    Friend WithEvents TextBoxCodigo As System.Windows.Forms.TextBox
    Friend WithEvents LabelCodigo As System.Windows.Forms.Label
    Friend WithEvents fgDetalles As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents ListViewMovSinInv As System.Windows.Forms.ListView
    Friend WithEvents ContextMenu1 As System.Windows.Forms.ContextMenu
    Friend WithEvents MenuItemEliminar As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemModificar As System.Windows.Forms.MenuItem
    Friend WithEvents LabelListaPrecios As System.Windows.Forms.Label
    Friend WithEvents PanelPie As System.Windows.Forms.Panel
    Friend WithEvents LabelTotalProductos As System.Windows.Forms.Label
    Friend WithEvents LabelTotal As System.Windows.Forms.Label
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
    Friend WithEvents MenuItemRegresar As System.Windows.Forms.MenuItem
    Friend WithEvents ContextMenu2 As System.Windows.Forms.ContextMenu
End Class
