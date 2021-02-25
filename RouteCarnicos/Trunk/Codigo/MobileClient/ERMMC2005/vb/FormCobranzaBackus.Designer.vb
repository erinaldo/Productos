<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class FormCobranzaBackus
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If Not IsNothing(Me.ListViewCobranza) Then
            If Me.ListViewCobranza.Columns.Count > 0 Then
                Me.ListViewCobranza.Columns.Clear()
            End If
        End If
        If Not IsNothing(Me.MenuItemBorrar) Then Me.MenuItemBorrar.Dispose()
        If Not IsNothing(Me.MenuItemCrear) Then Me.MenuItemCrear.Dispose()
        If Not IsNothing(Me.MenuItemRegresar) Then Me.MenuItemRegresar.Dispose()
        If Not IsNothing(Me.mainMenu1) Then Me.mainMenu1.Dispose()
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer
    Private mainMenu1 As System.Windows.Forms.MainMenu

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormCobranzaBackus))
        Me.mainMenu1 = New System.Windows.Forms.MainMenu
        Me.MenuItemRegresar = New System.Windows.Forms.MenuItem
        Me.ContextMenuAgregarPago = New System.Windows.Forms.ContextMenu
        Me.MenuItemCrear = New System.Windows.Forms.MenuItem
        Me.MenuItemBorrar = New System.Windows.Forms.MenuItem
        Me.PanelCobranzaDetalles = New System.Windows.Forms.Panel
        Me.LabelFolio = New System.Windows.Forms.Label
        Me.C1FlexGridMonedaSaldo = New C1.Win.C1FlexGrid.C1FlexGrid
        Me.C1FlexGridCobranzaPagos = New C1.Win.C1FlexGrid.C1FlexGrid
        Me.TextBoxTotal = New System.Windows.Forms.TextBox
        Me.TextBoxFechaFactura = New System.Windows.Forms.TextBox
        Me.TextBoxSaldoFactura = New System.Windows.Forms.TextBox
        Me.TextBoxFolio = New System.Windows.Forms.TextBox
        Me.ButtonRegresarDetalles = New System.Windows.Forms.Button
        Me.ButtonContinuarDetalles = New System.Windows.Forms.Button
        Me.LabelTotal = New System.Windows.Forms.Label
        Me.LabelFecha = New System.Windows.Forms.Label
        Me.LabelCargo = New System.Windows.Forms.Label
        Me.ButtonContinuar = New System.Windows.Forms.Button
        Me.ButtonRegresar = New System.Windows.Forms.Button
        Me.LabelSeleccionar = New System.Windows.Forms.Label
        Me.ListViewCobranza = New System.Windows.Forms.ListView
        Me.PanelCobranza = New System.Windows.Forms.Panel
        Me.ButtonEliminar = New System.Windows.Forms.Button
        Me.PanelCobranzaDetalles.SuspendLayout()
        Me.PanelCobranza.SuspendLayout()
        Me.SuspendLayout()
        '
        'mainMenu1
        '
        Me.mainMenu1.MenuItems.Add(Me.MenuItemRegresar)
        '
        'MenuItemRegresar
        '
        Me.MenuItemRegresar.Text = "MenuItemRegresar"
        '
        'ContextMenuAgregarPago
        '
        Me.ContextMenuAgregarPago.MenuItems.Add(Me.MenuItemCrear)
        Me.ContextMenuAgregarPago.MenuItems.Add(Me.MenuItemBorrar)
        '
        'MenuItemCrear
        '
        Me.MenuItemCrear.Text = "Crear"
        '
        'MenuItemBorrar
        '
        Me.MenuItemBorrar.Text = "Borrar"
        '
        'PanelCobranzaDetalles
        '
        Me.PanelCobranzaDetalles.Controls.Add(Me.LabelFolio)
        Me.PanelCobranzaDetalles.Controls.Add(Me.C1FlexGridMonedaSaldo)
        Me.PanelCobranzaDetalles.Controls.Add(Me.C1FlexGridCobranzaPagos)
        Me.PanelCobranzaDetalles.Controls.Add(Me.TextBoxTotal)
        Me.PanelCobranzaDetalles.Controls.Add(Me.TextBoxFechaFactura)
        Me.PanelCobranzaDetalles.Controls.Add(Me.TextBoxSaldoFactura)
        Me.PanelCobranzaDetalles.Controls.Add(Me.TextBoxFolio)
        Me.PanelCobranzaDetalles.Controls.Add(Me.ButtonRegresarDetalles)
        Me.PanelCobranzaDetalles.Controls.Add(Me.ButtonContinuarDetalles)
        Me.PanelCobranzaDetalles.Controls.Add(Me.LabelTotal)
        Me.PanelCobranzaDetalles.Controls.Add(Me.LabelFecha)
        Me.PanelCobranzaDetalles.Controls.Add(Me.LabelCargo)
        Me.PanelCobranzaDetalles.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelCobranzaDetalles.Location = New System.Drawing.Point(0, 0)
        Me.PanelCobranzaDetalles.Name = "PanelCobranzaDetalles"
        Me.PanelCobranzaDetalles.Size = New System.Drawing.Size(242, 295)
        '
        'LabelFolio
        '
        Me.LabelFolio.Location = New System.Drawing.Point(12, 20)
        Me.LabelFolio.Name = "LabelFolio"
        Me.LabelFolio.Size = New System.Drawing.Size(72, 20)
        Me.LabelFolio.Text = "Folio"
        '
        'C1FlexGridMonedaSaldo
        '
        Me.C1FlexGridMonedaSaldo.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.C1FlexGridMonedaSaldo.Font = New System.Drawing.Font("Tahoma", 9.0!, Drawing.FontStyle.Regular)
        Me.C1FlexGridMonedaSaldo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.C1FlexGridMonedaSaldo.Location = New System.Drawing.Point(5, 87)
        Me.C1FlexGridMonedaSaldo.Name = "C1FlexGridMonedaSaldo"
        Me.C1FlexGridMonedaSaldo.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.C1FlexGridMonedaSaldo.Size = New System.Drawing.Size(231, 60)
        Me.C1FlexGridMonedaSaldo.StyleInfo = resources.GetString("C1FlexGridMonedaSaldo.StyleInfo")
        Me.C1FlexGridMonedaSaldo.TabIndex = 23
        '
        'C1FlexGridCobranzaPagos
        '
        Me.C1FlexGridCobranzaPagos.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.C1FlexGridCobranzaPagos.ContextMenu = Me.ContextMenuAgregarPago
        Me.C1FlexGridCobranzaPagos.Font = New System.Drawing.Font("Tahoma", 9.0!, Drawing.FontStyle.Regular)
        Me.C1FlexGridCobranzaPagos.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.C1FlexGridCobranzaPagos.Location = New System.Drawing.Point(5, 153)
        Me.C1FlexGridCobranzaPagos.Name = "C1FlexGridCobranzaPagos"
        Me.C1FlexGridCobranzaPagos.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.C1FlexGridCobranzaPagos.Size = New System.Drawing.Size(231, 105)
        Me.C1FlexGridCobranzaPagos.StyleInfo = resources.GetString("C1FlexGridCobranzaPagos.StyleInfo")
        Me.C1FlexGridCobranzaPagos.TabIndex = 19
        '
        'TextBoxTotal
        '
        Me.TextBoxTotal.Enabled = False
        Me.TextBoxTotal.Location = New System.Drawing.Point(106, 235)
        Me.TextBoxTotal.Name = "TextBoxTotal"
        Me.TextBoxTotal.Size = New System.Drawing.Size(66, 23)
        Me.TextBoxTotal.TabIndex = 9
        '
        'TextBoxFechaFactura
        '
        Me.TextBoxFechaFactura.Enabled = False
        Me.TextBoxFechaFactura.Location = New System.Drawing.Point(136, 39)
        Me.TextBoxFechaFactura.Name = "TextBoxFechaFactura"
        Me.TextBoxFechaFactura.Size = New System.Drawing.Size(100, 23)
        Me.TextBoxFechaFactura.TabIndex = 3
        '
        'TextBoxSaldoFactura
        '
        Me.TextBoxSaldoFactura.Enabled = False
        Me.TextBoxSaldoFactura.Location = New System.Drawing.Point(136, 61)
        Me.TextBoxSaldoFactura.Name = "TextBoxSaldoFactura"
        Me.TextBoxSaldoFactura.Size = New System.Drawing.Size(100, 23)
        Me.TextBoxSaldoFactura.TabIndex = 2
        '
        'TextBoxFolio
        '
        Me.TextBoxFolio.AcceptsReturn = True
        Me.TextBoxFolio.Enabled = False
        Me.TextBoxFolio.Location = New System.Drawing.Point(136, 17)
        Me.TextBoxFolio.Name = "TextBoxFolio"
        Me.TextBoxFolio.Size = New System.Drawing.Size(100, 23)
        Me.TextBoxFolio.TabIndex = 1
        '
        'ButtonRegresarDetalles
        '
        Me.ButtonRegresarDetalles.Location = New System.Drawing.Point(83, 259)
        Me.ButtonRegresarDetalles.Name = "ButtonRegresarDetalles"
        Me.ButtonRegresarDetalles.Size = New System.Drawing.Size(72, 24)
        Me.ButtonRegresarDetalles.TabIndex = 11
        Me.ButtonRegresarDetalles.Text = "ButtonRegresarDetalles"
        '
        'ButtonContinuarDetalles
        '
        Me.ButtonContinuarDetalles.Location = New System.Drawing.Point(5, 259)
        Me.ButtonContinuarDetalles.Name = "ButtonContinuarDetalles"
        Me.ButtonContinuarDetalles.Size = New System.Drawing.Size(72, 24)
        Me.ButtonContinuarDetalles.TabIndex = 10
        Me.ButtonContinuarDetalles.Text = "ButtonContinuarDetalles"
        '
        'LabelTotal
        '
        Me.LabelTotal.Location = New System.Drawing.Point(65, 235)
        Me.LabelTotal.Name = "LabelTotal"
        Me.LabelTotal.Size = New System.Drawing.Size(45, 20)
        Me.LabelTotal.Text = "LabelTotal"
        '
        'LabelFecha
        '
        Me.LabelFecha.Location = New System.Drawing.Point(12, 42)
        Me.LabelFecha.Name = "LabelFecha"
        Me.LabelFecha.Size = New System.Drawing.Size(72, 20)
        Me.LabelFecha.Text = "LabelFecha"
        '
        'LabelCargo
        '
        Me.LabelCargo.Location = New System.Drawing.Point(12, 64)
        Me.LabelCargo.Name = "LabelCargo"
        Me.LabelCargo.Size = New System.Drawing.Size(123, 20)
        Me.LabelCargo.Text = "LabelCargo"
        '
        'ButtonContinuar
        '
        Me.ButtonContinuar.Location = New System.Drawing.Point(5, 264)
        Me.ButtonContinuar.Name = "ButtonContinuar"
        Me.ButtonContinuar.Size = New System.Drawing.Size(72, 24)
        Me.ButtonContinuar.TabIndex = 10
        Me.ButtonContinuar.Text = "ButtonContinuar"
        '
        'ButtonRegresar
        '
        Me.ButtonRegresar.Location = New System.Drawing.Point(83, 264)
        Me.ButtonRegresar.Name = "ButtonRegresar"
        Me.ButtonRegresar.Size = New System.Drawing.Size(72, 24)
        Me.ButtonRegresar.TabIndex = 9
        Me.ButtonRegresar.Text = "ButtonRegresar"
        '
        'LabelSeleccionar
        '
        Me.LabelSeleccionar.Location = New System.Drawing.Point(5, 17)
        Me.LabelSeleccionar.Name = "LabelSeleccionar"
        Me.LabelSeleccionar.Size = New System.Drawing.Size(232, 20)
        Me.LabelSeleccionar.Text = "LabelSeleccionar"
        '
        'ListViewCobranza
        '
        Me.ListViewCobranza.CheckBoxes = True
        Me.ListViewCobranza.FullRowSelect = True
        Me.ListViewCobranza.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.ListViewCobranza.Location = New System.Drawing.Point(3, 36)
        Me.ListViewCobranza.Name = "ListViewCobranza"
        Me.ListViewCobranza.Size = New System.Drawing.Size(232, 226)
        Me.ListViewCobranza.TabIndex = 8
        Me.ListViewCobranza.View = System.Windows.Forms.View.Details

        '
        'PanelCobranza
        '
        Me.PanelCobranza.Controls.Add(Me.ListViewCobranza)
        Me.PanelCobranza.Controls.Add(Me.ButtonEliminar)
        Me.PanelCobranza.Controls.Add(Me.LabelSeleccionar)
        Me.PanelCobranza.Controls.Add(Me.ButtonRegresar)
        Me.PanelCobranza.Controls.Add(Me.ButtonContinuar)
        Me.PanelCobranza.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelCobranza.Location = New System.Drawing.Point(0, 0)
        Me.PanelCobranza.Name = "PanelCobranza"
        Me.PanelCobranza.Size = New System.Drawing.Size(242, 295)
        '
        'ButtonEliminar
        '
        Me.ButtonEliminar.Location = New System.Drawing.Point(161, 264)
        Me.ButtonEliminar.Name = "ButtonEliminar"
        Me.ButtonEliminar.Size = New System.Drawing.Size(72, 24)
        Me.ButtonEliminar.TabIndex = 11
        Me.ButtonEliminar.Text = "ButtonEliminar"
        '
        'FormCobranzaBackus
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(242, 295)
        Me.ControlBox = False
        Me.Controls.Add(Me.PanelCobranzaDetalles)
        Me.Controls.Add(Me.PanelCobranza)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Menu = Me.mainMenu1
        Me.MinimizeBox = False
        Me.Name = "FormCobranzaBackus"
        Me.Text = "Amesol Route"
        Me.PanelCobranzaDetalles.ResumeLayout(False)
        Me.PanelCobranza.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MenuItemRegresar As System.Windows.Forms.MenuItem
    Friend WithEvents ContextMenuAgregarPago As System.Windows.Forms.ContextMenu
    Friend WithEvents MenuItemCrear As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemBorrar As System.Windows.Forms.MenuItem
    Friend WithEvents PanelCobranzaDetalles As System.Windows.Forms.Panel
    Friend WithEvents C1FlexGridCobranzaPagos As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents TextBoxTotal As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxFechaFactura As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxSaldoFactura As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxFolio As System.Windows.Forms.TextBox
    Friend WithEvents ButtonRegresarDetalles As System.Windows.Forms.Button
    Friend WithEvents ButtonContinuarDetalles As System.Windows.Forms.Button
    Friend WithEvents LabelTotal As System.Windows.Forms.Label
    Friend WithEvents LabelFecha As System.Windows.Forms.Label
    Friend WithEvents LabelCargo As System.Windows.Forms.Label
    Friend WithEvents ButtonContinuar As System.Windows.Forms.Button
    Friend WithEvents ButtonRegresar As System.Windows.Forms.Button
    Friend WithEvents LabelSeleccionar As System.Windows.Forms.Label
    Friend WithEvents ListViewCobranza As System.Windows.Forms.ListView
    Friend WithEvents PanelCobranza As System.Windows.Forms.Panel
    Friend WithEvents ButtonEliminar As System.Windows.Forms.Button
    Friend WithEvents C1FlexGridMonedaSaldo As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents LabelFolio As System.Windows.Forms.Label
End Class
