<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class FormPreciosVenta
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If Not Me.mainMenu1 Is Nothing Then Me.mainMenu1.Dispose()
        If Not Me.fgMovimientos Is Nothing Then Me.fgMovimientos.Dispose()
        Me.fgMovimientos = Nothing
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormPreciosVenta))
        Me.mainMenu1 = New System.Windows.Forms.MainMenu
        Me.PanelDetalle = New System.Windows.Forms.Panel
        Me.TextBoxCodigo = New System.Windows.Forms.TextBox
        Me.LabelCodigo = New System.Windows.Forms.Label
        Me.fgMovimientos = New C1.Win.C1FlexGrid.C1FlexGrid
        Me.ButtonRegresar = New System.Windows.Forms.Button
        Me.ButtonContinuar = New System.Windows.Forms.Button
        Me.ButtonBuscar = New System.Windows.Forms.Button
        Me.TextBoxProducto = New System.Windows.Forms.TextBox
        Me.TextBoxFolio = New System.Windows.Forms.TextBox
        Me.LabelProducto = New System.Windows.Forms.Label
        Me.LabelFolio = New System.Windows.Forms.Label
        Me.PanelDetalle.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelDetalle
        '
        Me.PanelDetalle.Controls.Add(Me.TextBoxCodigo)
        Me.PanelDetalle.Controls.Add(Me.LabelCodigo)
        Me.PanelDetalle.Controls.Add(Me.fgMovimientos)
        Me.PanelDetalle.Controls.Add(Me.ButtonRegresar)
        Me.PanelDetalle.Controls.Add(Me.ButtonContinuar)
        Me.PanelDetalle.Controls.Add(Me.ButtonBuscar)
        Me.PanelDetalle.Controls.Add(Me.TextBoxProducto)
        Me.PanelDetalle.Controls.Add(Me.TextBoxFolio)
        Me.PanelDetalle.Controls.Add(Me.LabelProducto)
        Me.PanelDetalle.Controls.Add(Me.LabelFolio)
        Me.PanelDetalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelDetalle.Location = New System.Drawing.Point(0, 0)
        Me.PanelDetalle.Name = "PanelDetalle"
        Me.PanelDetalle.Size = New System.Drawing.Size(242, 295)
        '
        'TextBoxCodigo
        '
        Me.TextBoxCodigo.Location = New System.Drawing.Point(91, 69)
        Me.TextBoxCodigo.Name = "TextBoxCodigo"
        Me.TextBoxCodigo.Size = New System.Drawing.Size(144, 21)
        Me.TextBoxCodigo.TabIndex = 20
        '
        'LabelCodigo
        '
        Me.LabelCodigo.Location = New System.Drawing.Point(11, 69)
        Me.LabelCodigo.Name = "LabelCodigo"
        Me.LabelCodigo.Size = New System.Drawing.Size(80, 20)
        Me.LabelCodigo.Text = "LabelCodigo"
        '
        'fgMovimientos
        '
        Me.fgMovimientos.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.fgMovimientos.AllowEditing = False
        Me.fgMovimientos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fgMovimientos.AutoResize = True
        Me.fgMovimientos.AutoSearch = C1.Win.C1FlexGrid.AutoSearchEnum.FromCursor
        Me.fgMovimientos.AutoSearchDelay = 2
        Me.fgMovimientos.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.fgMovimientos.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.fgMovimientos.Clip = ""
        Me.fgMovimientos.ClipSeparators = "" & Global.Microsoft.VisualBasic.ChrW(9) & Global.Microsoft.VisualBasic.ChrW(13)
        Me.fgMovimientos.Col = 1
        Me.fgMovimientos.ColSel = 1
        Me.fgMovimientos.ComboList = Nothing
        Me.fgMovimientos.EditMask = Nothing
        Me.fgMovimientos.ExtendLastCol = False
        Me.fgMovimientos.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.fgMovimientos.HighLight = C1.Win.C1FlexGrid.HighLightEnum.WithFocus
        Me.fgMovimientos.LeftCol = 1
        Me.fgMovimientos.Location = New System.Drawing.Point(6, 92)
        Me.fgMovimientos.Name = "fgMovimientos"
        Me.fgMovimientos.Redraw = True
        Me.fgMovimientos.Row = 1
        Me.fgMovimientos.RowSel = 1
        Me.fgMovimientos.ScrollPosition = New System.Drawing.Point(0, 0)
        Me.fgMovimientos.ScrollTrack = True
        Me.fgMovimientos.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.fgMovimientos.ShowCursor = False
        Me.fgMovimientos.ShowSort = True
        Me.fgMovimientos.Size = New System.Drawing.Size(229, 168)
        Me.fgMovimientos.StyleInfo = resources.GetString("fgMovimientos.StyleInfo")
        Me.fgMovimientos.SupportInfo = "NgDCAGYB8QCzANUAuQBYAcYAkADPAJUAhgCcAGsAkgAWAbQA9wCqAHoA3gCWAO0AwQCbAD8AhABLADYAt" & _
            "gCWAA=="
        Me.fgMovimientos.TabIndex = 21
        Me.fgMovimientos.Text = "C1FlexGrid1"
        Me.fgMovimientos.TopRow = 1
        '
        'ButtonRegresar
        '
        Me.ButtonRegresar.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.ButtonRegresar.Location = New System.Drawing.Point(84, 262)
        Me.ButtonRegresar.Name = "ButtonRegresar"
        Me.ButtonRegresar.Size = New System.Drawing.Size(72, 24)
        Me.ButtonRegresar.TabIndex = 25
        Me.ButtonRegresar.Text = "ButtonRegresar"
        '
        'ButtonContinuar
        '
        Me.ButtonContinuar.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.ButtonContinuar.Location = New System.Drawing.Point(6, 262)
        Me.ButtonContinuar.Name = "ButtonContinuar"
        Me.ButtonContinuar.Size = New System.Drawing.Size(72, 24)
        Me.ButtonContinuar.TabIndex = 24
        Me.ButtonContinuar.Text = "ButtonContinuar"
        '
        'ButtonBuscar
        '
        Me.ButtonBuscar.Location = New System.Drawing.Point(211, 46)
        Me.ButtonBuscar.Name = "ButtonBuscar"
        Me.ButtonBuscar.Size = New System.Drawing.Size(24, 20)
        Me.ButtonBuscar.TabIndex = 18
        Me.ButtonBuscar.Text = "..."
        '
        'TextBoxProducto
        '
        Me.TextBoxProducto.Location = New System.Drawing.Point(91, 46)
        Me.TextBoxProducto.Name = "TextBoxProducto"
        Me.TextBoxProducto.Size = New System.Drawing.Size(118, 21)
        Me.TextBoxProducto.TabIndex = 17
        '
        'TextBoxFolio
        '
        Me.TextBoxFolio.Location = New System.Drawing.Point(91, 4)
        Me.TextBoxFolio.Name = "TextBoxFolio"
        Me.TextBoxFolio.Size = New System.Drawing.Size(118, 21)
        Me.TextBoxFolio.TabIndex = 14
        '
        'LabelProducto
        '
        Me.LabelProducto.Location = New System.Drawing.Point(11, 46)
        Me.LabelProducto.Name = "LabelProducto"
        Me.LabelProducto.Size = New System.Drawing.Size(80, 20)
        Me.LabelProducto.Text = "LabelProducto"
        '
        'LabelFolio
        '
        Me.LabelFolio.Location = New System.Drawing.Point(11, 4)
        Me.LabelFolio.Name = "LabelFolio"
        Me.LabelFolio.Size = New System.Drawing.Size(72, 24)
        Me.LabelFolio.Text = "LabelFolio"
        '
        'FormPreciosVenta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(242, 295)
        Me.ControlBox = False
        Me.Controls.Add(Me.PanelDetalle)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Menu = Me.mainMenu1
        Me.MinimizeBox = False
        Me.Name = "FormPreciosVenta"
        Me.PanelDetalle.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelDetalle As System.Windows.Forms.Panel
    Friend WithEvents TextBoxCodigo As System.Windows.Forms.TextBox
    Friend WithEvents LabelCodigo As System.Windows.Forms.Label
    Friend WithEvents fgMovimientos As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents ButtonRegresar As System.Windows.Forms.Button
    Friend WithEvents ButtonContinuar As System.Windows.Forms.Button
    Friend WithEvents ButtonBuscar As System.Windows.Forms.Button
    Friend WithEvents TextBoxProducto As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxFolio As System.Windows.Forms.TextBox
    Friend WithEvents LabelProducto As System.Windows.Forms.Label
    Friend WithEvents LabelFolio As System.Windows.Forms.Label
End Class
