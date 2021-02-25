<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class FormSeleccionarPromociones
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        If Not IsNothing(Me.fgPromociones) Then
            fgPromociones.Dispose()
            fgPromociones = Nothing
        End If
        If Not IsNothing(Me.MenuItemRegresar) Then MenuItemRegresar.Dispose()
        If Not IsNothing(Me.MainMenuAgenda) Then MainMenuAgenda.Dispose()

        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormSeleccionarPromociones))
        Me.PanelSeleccionarPromociones = New System.Windows.Forms.Panel
        Me.lblMaximo = New System.Windows.Forms.Label
        Me.LabelMaximo = New System.Windows.Forms.Label
        Me.LabelNombre = New System.Windows.Forms.Label
        Me.ButtonRegresar = New System.Windows.Forms.Button
        Me.TextBoxTotal = New System.Windows.Forms.TextBox
        Me.LabelTotal = New System.Windows.Forms.Label
        Me.ButtonContinuar = New System.Windows.Forms.Button
        Me.fgPromociones = New C1.Win.C1FlexGrid.C1FlexGrid
        Me.MainMenuAgenda = New System.Windows.Forms.MainMenu
        Me.MenuItemRegresar = New System.Windows.Forms.MenuItem
        Me.PanelSeleccionarPromociones.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelSeleccionarPromociones
        '
        Me.PanelSeleccionarPromociones.Controls.Add(Me.lblMaximo)
        Me.PanelSeleccionarPromociones.Controls.Add(Me.LabelMaximo)
        Me.PanelSeleccionarPromociones.Controls.Add(Me.LabelNombre)
        Me.PanelSeleccionarPromociones.Controls.Add(Me.ButtonRegresar)
        Me.PanelSeleccionarPromociones.Controls.Add(Me.TextBoxTotal)
        Me.PanelSeleccionarPromociones.Controls.Add(Me.LabelTotal)
        Me.PanelSeleccionarPromociones.Controls.Add(Me.ButtonContinuar)
        Me.PanelSeleccionarPromociones.Controls.Add(Me.fgPromociones)
        Me.PanelSeleccionarPromociones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelSeleccionarPromociones.Location = New System.Drawing.Point(0, 0)
        Me.PanelSeleccionarPromociones.Name = "PanelSeleccionarPromociones"
        Me.PanelSeleccionarPromociones.Size = New System.Drawing.Size(242, 295)
        '
        'lblMaximo
        '
        Me.lblMaximo.Location = New System.Drawing.Point(71, 232)
        Me.lblMaximo.Name = "lblMaximo"
        Me.lblMaximo.Size = New System.Drawing.Size(34, 20)
        Me.lblMaximo.Text = "0"
        '
        'LabelMaximo
        '
        Me.LabelMaximo.Location = New System.Drawing.Point(7, 232)
        Me.LabelMaximo.Name = "LabelMaximo"
        Me.LabelMaximo.Size = New System.Drawing.Size(59, 20)
        Me.LabelMaximo.Text = "LabelMaximo"
        '
        'LabelNombre
        '
        Me.LabelNombre.ForeColor = System.Drawing.Color.Navy
        Me.LabelNombre.Location = New System.Drawing.Point(7, 4)
        Me.LabelNombre.Name = "LabelNombre"
        Me.LabelNombre.Size = New System.Drawing.Size(226, 20)
        '
        'ButtonRegresar
        '
        Me.ButtonRegresar.Location = New System.Drawing.Point(87, 262)
        Me.ButtonRegresar.Name = "ButtonRegresar"
        Me.ButtonRegresar.Size = New System.Drawing.Size(74, 24)
        Me.ButtonRegresar.TabIndex = 31
        Me.ButtonRegresar.Text = "ButtonRegresar"
        '
        'TextBoxTotal
        '
        Me.TextBoxTotal.Enabled = False
        Me.TextBoxTotal.Location = New System.Drawing.Point(174, 230)
        Me.TextBoxTotal.Name = "TextBoxTotal"
        Me.TextBoxTotal.Size = New System.Drawing.Size(58, 21)
        Me.TextBoxTotal.TabIndex = 30
        Me.TextBoxTotal.Text = "0.00"
        '
        'LabelTotal
        '
        Me.LabelTotal.Location = New System.Drawing.Point(111, 232)
        Me.LabelTotal.Name = "LabelTotal"
        Me.LabelTotal.Size = New System.Drawing.Size(59, 20)
        Me.LabelTotal.Text = "LabelTotal"
        '
        'ButtonContinuar
        '
        Me.ButtonContinuar.Location = New System.Drawing.Point(7, 262)
        Me.ButtonContinuar.Name = "ButtonContinuar"
        Me.ButtonContinuar.Size = New System.Drawing.Size(74, 24)
        Me.ButtonContinuar.TabIndex = 27
        Me.ButtonContinuar.Text = "ButtonContinuar"
        '
        'fgPromociones
        '
        Me.fgPromociones.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.fgPromociones.AllowEditing = False
        Me.fgPromociones.AutoResize = True
        Me.fgPromociones.AutoSearchDelay = 2
        Me.fgPromociones.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.fgPromociones.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.fgPromociones.Clip = ""
        Me.fgPromociones.ClipSeparators = "" & Global.Microsoft.VisualBasic.ChrW(9) & Global.Microsoft.VisualBasic.ChrW(13)
        Me.fgPromociones.Col = 1
        Me.fgPromociones.ColSel = 1
        Me.fgPromociones.ComboList = Nothing
        Me.fgPromociones.EditMask = Nothing
        Me.fgPromociones.ExtendLastCol = False
        Me.fgPromociones.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.fgPromociones.HighLight = C1.Win.C1FlexGrid.HighLightEnum.WithFocus
        Me.fgPromociones.LeftCol = 1
        Me.fgPromociones.Location = New System.Drawing.Point(6, 27)
        Me.fgPromociones.Name = "fgPromociones"
        Me.fgPromociones.Redraw = True
        Me.fgPromociones.Row = 1
        Me.fgPromociones.RowSel = 1
        Me.fgPromociones.ScrollPosition = New System.Drawing.Point(0, 0)
        Me.fgPromociones.ScrollTrack = True
        Me.fgPromociones.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.fgPromociones.ShowCursor = False
        Me.fgPromociones.ShowSort = True
        Me.fgPromociones.Size = New System.Drawing.Size(226, 200)
        Me.fgPromociones.StyleInfo = resources.GetString("fgPromociones.StyleInfo")
        Me.fgPromociones.SupportInfo = "nAAmARwB8AAAAZUBvgCaAHAADwG0AOEAUwEnAeAAiAA8AWsA6QBsACcB7QCEAEkA6wDxADwAAwEXAb0AO" & _
            "gBrAA=="
        Me.fgPromociones.TabIndex = 25
        Me.fgPromociones.Text = "C1FlexGrid1"
        Me.fgPromociones.TopRow = 1
        '
        'MainMenuAgenda
        '
        Me.MainMenuAgenda.MenuItems.Add(Me.MenuItemRegresar)
        '
        'MenuItemRegresar
        '
        Me.MenuItemRegresar.Text = "MenuItemRegresar"
        '
        'FormSeleccionarPromociones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(242, 295)
        Me.ControlBox = False
        Me.Controls.Add(Me.PanelSeleccionarPromociones)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.Menu = Me.MainMenuAgenda
        Me.MinimizeBox = False
        Me.Name = "FormSeleccionarPromociones"
        Me.Text = "FormSeleccionarPromociones"
        Me.PanelSeleccionarPromociones.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelSeleccionarPromociones As System.Windows.Forms.Panel
    Friend WithEvents ButtonContinuar As System.Windows.Forms.Button
    Friend WithEvents fgPromociones As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents LabelTotal As System.Windows.Forms.Label
    Friend WithEvents TextBoxTotal As System.Windows.Forms.TextBox
    Friend WithEvents ButtonRegresar As System.Windows.Forms.Button
    Friend WithEvents LabelNombre As System.Windows.Forms.Label
    Friend WithEvents MainMenuAgenda As System.Windows.Forms.MainMenu
    Friend WithEvents MenuItemRegresar As System.Windows.Forms.MenuItem
    Friend WithEvents lblMaximo As System.Windows.Forms.Label
    Friend WithEvents LabelMaximo As System.Windows.Forms.Label
End Class
