<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class FormDepositosGarantia
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If Not Me.mainMenu1 Is Nothing Then Me.mainMenu1.Dispose()
        If Not Me.FlexGridDepositos Is Nothing Then Me.FlexGridDepositos.Dispose()
        Me.FlexGridDepositos = Nothing
        If Not Me.FlexGridProductos Is Nothing Then Me.FlexGridProductos.Dispose()
        Me.FlexGridProductos = Nothing
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormDepositosGarantia))
        Me.mainMenu1 = New System.Windows.Forms.MainMenu
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.btRegresar = New System.Windows.Forms.Button
        Me.btContinuar = New System.Windows.Forms.Button
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.tpProductos = New System.Windows.Forms.TabPage
        Me.FlexGridProductos = New C1.Win.C1FlexGrid.C1FlexGrid
        Me.lbTotalDep = New System.Windows.Forms.Label
        Me.TextBoxTotalDep = New System.Windows.Forms.TextBox
        Me.tpDeposito = New System.Windows.Forms.TabPage
        Me.TextBoxTipoDep = New System.Windows.Forms.TextBox
        Me.lbTotalDep2 = New System.Windows.Forms.Label
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
        Me.FlexGridDepositos = New C1.Win.C1FlexGrid.C1FlexGrid
        Me.TextBoxCuotas = New System.Windows.Forms.TextBox
        Me.lbCuotas = New System.Windows.Forms.Label
        Me.lbFechaVenc = New System.Windows.Forms.Label
        Me.lbTipoDep = New System.Windows.Forms.Label
        Me.tpPropios = New System.Windows.Forms.TabPage
        Me.ButtonBuscar = New System.Windows.Forms.Button
        Me.TextBoxProductoNombre = New System.Windows.Forms.TextBox
        Me.TextBoxTotalPropios = New System.Windows.Forms.TextBox
        Me.TextBoxCantidad = New System.Windows.Forms.TextBox
        Me.TextBoxPrecio = New System.Windows.Forms.TextBox
        Me.TextBoxProductoClave = New System.Windows.Forms.TextBox
        Me.lbTotalPropios = New System.Windows.Forms.Label
        Me.lbCantidad = New System.Windows.Forms.Label
        Me.lbPrecio = New System.Windows.Forms.Label
        Me.lbClave = New System.Windows.Forms.Label
        Me.Panel1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.tpProductos.SuspendLayout()
        Me.tpDeposito.SuspendLayout()
        Me.tpPropios.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btRegresar)
        Me.Panel1.Controls.Add(Me.btContinuar)
        Me.Panel1.Controls.Add(Me.TabControl1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(242, 295)
        '
        'btRegresar
        '
        Me.btRegresar.Location = New System.Drawing.Point(81, 262)
        Me.btRegresar.Name = "btRegresar"
        Me.btRegresar.Size = New System.Drawing.Size(72, 24)
        Me.btRegresar.TabIndex = 2
        Me.btRegresar.Text = "btRegresar"
        '
        'btContinuar
        '
        Me.btContinuar.Location = New System.Drawing.Point(3, 262)
        Me.btContinuar.Name = "btContinuar"
        Me.btContinuar.Size = New System.Drawing.Size(72, 24)
        Me.btContinuar.TabIndex = 1
        Me.btContinuar.Text = "btContinuar"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tpProductos)
        Me.TabControl1.Controls.Add(Me.tpDeposito)
        Me.TabControl1.Controls.Add(Me.tpPropios)
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(242, 256)
        Me.TabControl1.TabIndex = 0
        '
        'tpProductos
        '
        Me.tpProductos.Controls.Add(Me.FlexGridProductos)
        Me.tpProductos.Controls.Add(Me.lbTotalDep)
        Me.tpProductos.Controls.Add(Me.TextBoxTotalDep)
        Me.tpProductos.Location = New System.Drawing.Point(0, 0)
        Me.tpProductos.Name = "tpProductos"
        Me.tpProductos.Size = New System.Drawing.Size(242, 233)
        Me.tpProductos.Text = "tpProductos"
        '
        'FlexGridProductos
        '
        Me.FlexGridProductos.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.FlexGridProductos.AllowEditing = True
        Me.FlexGridProductos.AutoResize = True
        Me.FlexGridProductos.AutoSearchDelay = 1
        Me.FlexGridProductos.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.FlexGridProductos.Clip = ""
        Me.FlexGridProductos.ClipSeparators = "" & Global.Microsoft.VisualBasic.ChrW(9) & Global.Microsoft.VisualBasic.ChrW(13)
        Me.FlexGridProductos.Col = 1
        Me.FlexGridProductos.ColSel = 1
        Me.FlexGridProductos.ComboList = Nothing
        Me.FlexGridProductos.EditMask = Nothing
        Me.FlexGridProductos.ExtendLastCol = False
        Me.FlexGridProductos.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.FlexGridProductos.LeftCol = 1
        Me.FlexGridProductos.Location = New System.Drawing.Point(9, 9)
        Me.FlexGridProductos.Name = "FlexGridProductos"
        Me.FlexGridProductos.Redraw = True
        Me.FlexGridProductos.Row = 1
        Me.FlexGridProductos.RowSel = 1
        Me.FlexGridProductos.ScrollPosition = New System.Drawing.Point(0, 0)
        Me.FlexGridProductos.ScrollTrack = True
        Me.FlexGridProductos.ShowCursor = False
        Me.FlexGridProductos.ShowSort = True
        Me.FlexGridProductos.Size = New System.Drawing.Size(223, 194)
        Me.FlexGridProductos.StyleInfo = resources.GetString("FlexGridProductos.StyleInfo")
        Me.FlexGridProductos.SupportInfo = "6QBNAY0BnQBOAEgB5ADGANkACgEjAUkB3ACbADoBQgEIAdQAiACFAIMAwwDOAFUADAEwAMcAegBvAKcAj" & _
            "QD2AEMA2AB8AA=="
        Me.FlexGridProductos.TabIndex = 3
        Me.FlexGridProductos.Text = "C1FlexGrid2"
        Me.FlexGridProductos.TopRow = 1
        '
        'lbTotalDep
        '
        Me.lbTotalDep.Location = New System.Drawing.Point(37, 209)
        Me.lbTotalDep.Name = "lbTotalDep"
        Me.lbTotalDep.Size = New System.Drawing.Size(100, 20)
        Me.lbTotalDep.Text = "lbTotalDep"
        Me.lbTotalDep.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'TextBoxTotalDep
        '
        Me.TextBoxTotalDep.Location = New System.Drawing.Point(143, 209)
        Me.TextBoxTotalDep.Name = "TextBoxTotalDep"
        Me.TextBoxTotalDep.ReadOnly = True
        Me.TextBoxTotalDep.Size = New System.Drawing.Size(90, 21)
        Me.TextBoxTotalDep.TabIndex = 1
        Me.TextBoxTotalDep.Text = "0.00"
        '
        'tpDeposito
        '
        Me.tpDeposito.Controls.Add(Me.TextBoxTipoDep)
        Me.tpDeposito.Controls.Add(Me.lbTotalDep2)
        Me.tpDeposito.Controls.Add(Me.TextBox1)
        Me.tpDeposito.Controls.Add(Me.DateTimePicker1)
        Me.tpDeposito.Controls.Add(Me.FlexGridDepositos)
        Me.tpDeposito.Controls.Add(Me.TextBoxCuotas)
        Me.tpDeposito.Controls.Add(Me.lbCuotas)
        Me.tpDeposito.Controls.Add(Me.lbFechaVenc)
        Me.tpDeposito.Controls.Add(Me.lbTipoDep)
        Me.tpDeposito.Location = New System.Drawing.Point(0, 0)
        Me.tpDeposito.Name = "tpDeposito"
        Me.tpDeposito.Size = New System.Drawing.Size(232, 230)
        Me.tpDeposito.Text = "tpDeposito"
        '
        'TextBoxTipoDep
        '
        Me.TextBoxTipoDep.Location = New System.Drawing.Point(108, 4)
        Me.TextBoxTipoDep.Name = "TextBoxTipoDep"
        Me.TextBoxTipoDep.ReadOnly = True
        Me.TextBoxTipoDep.Size = New System.Drawing.Size(125, 21)
        Me.TextBoxTipoDep.TabIndex = 12
        '
        'lbTotalDep2
        '
        Me.lbTotalDep2.Location = New System.Drawing.Point(37, 209)
        Me.lbTotalDep2.Name = "lbTotalDep2"
        Me.lbTotalDep2.Size = New System.Drawing.Size(100, 20)
        Me.lbTotalDep2.Text = "lbTotalDep2"
        Me.lbTotalDep2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(143, 209)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(90, 21)
        Me.TextBox1.TabIndex = 9
        Me.TextBox1.Text = "0.00"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Location = New System.Drawing.Point(108, 30)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(125, 22)
        Me.DateTimePicker1.TabIndex = 8
        '
        'FlexGridDepositos
        '
        Me.FlexGridDepositos.AllowEditing = False
        Me.FlexGridDepositos.AutoResize = True
        Me.FlexGridDepositos.AutoSearchDelay = 1
        Me.FlexGridDepositos.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.FlexGridDepositos.Clip = ""
        Me.FlexGridDepositos.ClipSeparators = "" & Global.Microsoft.VisualBasic.ChrW(9) & Global.Microsoft.VisualBasic.ChrW(13)
        Me.FlexGridDepositos.Col = 1
        Me.FlexGridDepositos.ColSel = 1
        Me.FlexGridDepositos.ComboList = Nothing
        Me.FlexGridDepositos.EditMask = Nothing
        Me.FlexGridDepositos.ExtendLastCol = False
        Me.FlexGridDepositos.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.FlexGridDepositos.LeftCol = 1
        Me.FlexGridDepositos.Location = New System.Drawing.Point(7, 86)
        Me.FlexGridDepositos.Name = "FlexGridDepositos"
        Me.FlexGridDepositos.Redraw = True
        Me.FlexGridDepositos.Row = 1
        Me.FlexGridDepositos.RowSel = 1
        Me.FlexGridDepositos.ScrollPosition = New System.Drawing.Point(0, 0)
        Me.FlexGridDepositos.ScrollTrack = True
        Me.FlexGridDepositos.ShowCursor = False
        Me.FlexGridDepositos.ShowSort = True
        Me.FlexGridDepositos.Size = New System.Drawing.Size(226, 118)
        Me.FlexGridDepositos.StyleInfo = resources.GetString("FlexGridDepositos.StyleInfo")
        Me.FlexGridDepositos.SupportInfo = "fADQADwB3wBpAP8A6wBfARYB5AAXAVsBkwB3AHUAggAmATIBlgBZAQAB2QCmAIgAfQAiAdwArgD/AEEAn" & _
            "gDrAEcADwFFAA4B"
        Me.FlexGridDepositos.TabIndex = 6
        Me.FlexGridDepositos.Text = "C1FlexGrid1"
        Me.FlexGridDepositos.TopRow = 1
        '
        'TextBoxCuotas
        '
        Me.TextBoxCuotas.Location = New System.Drawing.Point(108, 58)
        Me.TextBoxCuotas.Name = "TextBoxCuotas"
        Me.TextBoxCuotas.Size = New System.Drawing.Size(125, 21)
        Me.TextBoxCuotas.TabIndex = 5
        '
        'lbCuotas
        '
        Me.lbCuotas.Location = New System.Drawing.Point(7, 63)
        Me.lbCuotas.Name = "lbCuotas"
        Me.lbCuotas.Size = New System.Drawing.Size(100, 20)
        Me.lbCuotas.Text = "lbCuotas"
        '
        'lbFechaVenc
        '
        Me.lbFechaVenc.Location = New System.Drawing.Point(7, 33)
        Me.lbFechaVenc.Name = "lbFechaVenc"
        Me.lbFechaVenc.Size = New System.Drawing.Size(100, 20)
        Me.lbFechaVenc.Text = "lbFechaVenc"
        '
        'lbTipoDep
        '
        Me.lbTipoDep.Location = New System.Drawing.Point(7, 4)
        Me.lbTipoDep.Name = "lbTipoDep"
        Me.lbTipoDep.Size = New System.Drawing.Size(100, 20)
        Me.lbTipoDep.Text = "lbTipoDep"
        '
        'tpPropios
        '
        Me.tpPropios.Controls.Add(Me.ButtonBuscar)
        Me.tpPropios.Controls.Add(Me.TextBoxProductoNombre)
        Me.tpPropios.Controls.Add(Me.TextBoxTotalPropios)
        Me.tpPropios.Controls.Add(Me.TextBoxCantidad)
        Me.tpPropios.Controls.Add(Me.TextBoxPrecio)
        Me.tpPropios.Controls.Add(Me.TextBoxProductoClave)
        Me.tpPropios.Controls.Add(Me.lbTotalPropios)
        Me.tpPropios.Controls.Add(Me.lbCantidad)
        Me.tpPropios.Controls.Add(Me.lbPrecio)
        Me.tpPropios.Controls.Add(Me.lbClave)
        Me.tpPropios.Location = New System.Drawing.Point(0, 0)
        Me.tpPropios.Name = "tpPropios"
        Me.tpPropios.Size = New System.Drawing.Size(232, 230)
        Me.tpPropios.Text = "tpPropios"
        '
        'ButtonBuscar
        '
        Me.ButtonBuscar.Location = New System.Drawing.Point(205, 14)
        Me.ButtonBuscar.Name = "ButtonBuscar"
        Me.ButtonBuscar.Size = New System.Drawing.Size(27, 20)
        Me.ButtonBuscar.TabIndex = 13
        Me.ButtonBuscar.Text = "..."
        '
        'TextBoxProductoNombre
        '
        Me.TextBoxProductoNombre.Location = New System.Drawing.Point(110, 41)
        Me.TextBoxProductoNombre.Name = "TextBoxProductoNombre"
        Me.TextBoxProductoNombre.ReadOnly = True
        Me.TextBoxProductoNombre.Size = New System.Drawing.Size(123, 21)
        Me.TextBoxProductoNombre.TabIndex = 12
        '
        'TextBoxTotalPropios
        '
        Me.TextBoxTotalPropios.Location = New System.Drawing.Point(110, 128)
        Me.TextBoxTotalPropios.Name = "TextBoxTotalPropios"
        Me.TextBoxTotalPropios.ReadOnly = True
        Me.TextBoxTotalPropios.Size = New System.Drawing.Size(123, 21)
        Me.TextBoxTotalPropios.TabIndex = 7
        '
        'TextBoxCantidad
        '
        Me.TextBoxCantidad.Location = New System.Drawing.Point(110, 98)
        Me.TextBoxCantidad.Name = "TextBoxCantidad"
        Me.TextBoxCantidad.Size = New System.Drawing.Size(123, 21)
        Me.TextBoxCantidad.TabIndex = 6
        '
        'TextBoxPrecio
        '
        Me.TextBoxPrecio.Location = New System.Drawing.Point(110, 68)
        Me.TextBoxPrecio.Name = "TextBoxPrecio"
        Me.TextBoxPrecio.ReadOnly = True
        Me.TextBoxPrecio.Size = New System.Drawing.Size(123, 21)
        Me.TextBoxPrecio.TabIndex = 5
        '
        'TextBoxProductoClave
        '
        Me.TextBoxProductoClave.Location = New System.Drawing.Point(110, 14)
        Me.TextBoxProductoClave.Name = "TextBoxProductoClave"
        Me.TextBoxProductoClave.Size = New System.Drawing.Size(89, 21)
        Me.TextBoxProductoClave.TabIndex = 4
        '
        'lbTotalPropios
        '
        Me.lbTotalPropios.Location = New System.Drawing.Point(8, 130)
        Me.lbTotalPropios.Name = "lbTotalPropios"
        Me.lbTotalPropios.Size = New System.Drawing.Size(95, 20)
        Me.lbTotalPropios.Text = "lbTotalPropios"
        '
        'lbCantidad
        '
        Me.lbCantidad.Location = New System.Drawing.Point(8, 100)
        Me.lbCantidad.Name = "lbCantidad"
        Me.lbCantidad.Size = New System.Drawing.Size(95, 20)
        Me.lbCantidad.Text = "lbCantidad"
        '
        'lbPrecio
        '
        Me.lbPrecio.Location = New System.Drawing.Point(8, 70)
        Me.lbPrecio.Name = "lbPrecio"
        Me.lbPrecio.Size = New System.Drawing.Size(95, 20)
        Me.lbPrecio.Text = "lbPrecio"
        '
        'lbClave
        '
        Me.lbClave.Location = New System.Drawing.Point(8, 16)
        Me.lbClave.Name = "lbClave"
        Me.lbClave.Size = New System.Drawing.Size(95, 20)
        Me.lbClave.Text = "lbClave"
        '
        'FormDepositosGarantia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(242, 295)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.Menu = Me.mainMenu1
        Me.Name = "FormDepositosGarantia"
        Me.Panel1.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.tpProductos.ResumeLayout(False)
        Me.tpDeposito.ResumeLayout(False)
        Me.tpPropios.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tpProductos As System.Windows.Forms.TabPage
    Friend WithEvents tpDeposito As System.Windows.Forms.TabPage
    Friend WithEvents tpPropios As System.Windows.Forms.TabPage
    Friend WithEvents lbClave As System.Windows.Forms.Label
    Friend WithEvents TextBoxTotalPropios As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxCantidad As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxPrecio As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxProductoClave As System.Windows.Forms.TextBox
    Friend WithEvents lbTotalPropios As System.Windows.Forms.Label
    Friend WithEvents lbCantidad As System.Windows.Forms.Label
    Friend WithEvents lbPrecio As System.Windows.Forms.Label
    Friend WithEvents btRegresar As System.Windows.Forms.Button
    Friend WithEvents btContinuar As System.Windows.Forms.Button
    Friend WithEvents lbTotalDep As System.Windows.Forms.Label
    Friend WithEvents TextBoxTotalDep As System.Windows.Forms.TextBox
    Friend WithEvents FlexGridDepositos As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents TextBoxCuotas As System.Windows.Forms.TextBox
    Friend WithEvents lbCuotas As System.Windows.Forms.Label
    Friend WithEvents lbFechaVenc As System.Windows.Forms.Label
    Friend WithEvents lbTipoDep As System.Windows.Forms.Label
    Friend WithEvents FlexGridProductos As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents lbTotalDep2 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents ButtonBuscar As System.Windows.Forms.Button
    Friend WithEvents TextBoxProductoNombre As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxTipoDep As System.Windows.Forms.TextBox
End Class
