<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class FormVisitaDetalle
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If Not Me.MenuItemRegresar Is Nothing Then Me.MenuItemRegresar.Dispose()
        If Not Me.mainMenu1 Is Nothing Then Me.mainMenu1.Dispose()
        If Not Me.GridDetalles Is Nothing Then Me.GridDetalles.Dispose()
        Me.GridDetalles = Nothing
        If Not Me.GridMovimientos Is Nothing Then Me.GridMovimientos.Dispose()
        Me.GridMovimientos = Nothing
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormVisitaDetalle))
        Me.mainMenu1 = New System.Windows.Forms.MainMenu
        Me.MenuItemRegresar = New System.Windows.Forms.MenuItem
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.GridDetalles = New C1.Win.C1FlexGrid.C1FlexGrid
        Me.GridMovimientos = New C1.Win.C1FlexGrid.C1FlexGrid
        Me.LabelDetalleVisita = New System.Windows.Forms.Label
        Me.Panel1.SuspendLayout()
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
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.GridDetalles)
        Me.Panel1.Controls.Add(Me.GridMovimientos)
        Me.Panel1.Controls.Add(Me.LabelDetalleVisita)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(242, 295)
        '
        'GridDetalles
        '
        Me.GridDetalles.AllowEditing = False
        Me.GridDetalles.AutoResize = True
        Me.GridDetalles.AutoSearchDelay = 1
        Me.GridDetalles.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GridDetalles.Clip = ""
        Me.GridDetalles.ClipSeparators = "" & Global.Microsoft.VisualBasic.ChrW(9) & Global.Microsoft.VisualBasic.ChrW(13)
        Me.GridDetalles.Col = 1
        Me.GridDetalles.ColSel = 1
        Me.GridDetalles.ComboList = Nothing
        Me.GridDetalles.EditMask = Nothing
        Me.GridDetalles.ExtendLastCol = False
        Me.GridDetalles.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.GridDetalles.LeftCol = 1
        Me.GridDetalles.Location = New System.Drawing.Point(3, 158)
        Me.GridDetalles.Name = "GridDetalles"
        Me.GridDetalles.Redraw = True
        Me.GridDetalles.Row = 1
        Me.GridDetalles.RowSel = 1
        Me.GridDetalles.ScrollPosition = New System.Drawing.Point(0, 0)
        Me.GridDetalles.ScrollTrack = True
        Me.GridDetalles.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.GridDetalles.ShowCursor = False
        Me.GridDetalles.ShowSort = True
        Me.GridDetalles.Size = New System.Drawing.Size(231, 131)
        Me.GridDetalles.StyleInfo = resources.GetString("GridDetalles.StyleInfo")
        Me.GridDetalles.SupportInfo = "5QAEAeIANAHKAE8BJQFtAUEB4gCnAKsAvgBkABEBxACkAMwAHwGrAK0ABwFGAGsAygBpAM8ASwDkAG0Ah" & _
            "wC3AA=="
        Me.GridDetalles.TabIndex = 7
        Me.GridDetalles.Text = "C1FlexGrid1"
        Me.GridDetalles.TopRow = 1
        '
        'GridMovimientos
        '
        Me.GridMovimientos.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.GridMovimientos.AllowEditing = False
        Me.GridMovimientos.AutoResize = True
        Me.GridMovimientos.AutoSearchDelay = 1
        Me.GridMovimientos.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GridMovimientos.Clip = ""
        Me.GridMovimientos.ClipSeparators = "" & Global.Microsoft.VisualBasic.ChrW(9) & Global.Microsoft.VisualBasic.ChrW(13)
        Me.GridMovimientos.Col = 1
        Me.GridMovimientos.ColSel = 1
        Me.GridMovimientos.ComboList = Nothing
        Me.GridMovimientos.EditMask = Nothing
        Me.GridMovimientos.ExtendLastCol = False
        Me.GridMovimientos.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.GridMovimientos.LeftCol = 1
        Me.GridMovimientos.Location = New System.Drawing.Point(3, 25)
        Me.GridMovimientos.Name = "GridMovimientos"
        Me.GridMovimientos.Redraw = True
        Me.GridMovimientos.Row = 1
        Me.GridMovimientos.RowSel = 1
        Me.GridMovimientos.ScrollPosition = New System.Drawing.Point(0, 0)
        Me.GridMovimientos.ScrollTrack = True
        Me.GridMovimientos.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.GridMovimientos.ShowCursor = False
        Me.GridMovimientos.ShowSort = True
        Me.GridMovimientos.Size = New System.Drawing.Size(231, 129)
        Me.GridMovimientos.StyleInfo = resources.GetString("GridMovimientos.StyleInfo")
        Me.GridMovimientos.SupportInfo = "vAAzAYsBnQAxABYBoABAAXoAIQFgAMsAdAGRAFwBbABHAdUAFgFSAacAVQCrAOsA2gAMAVsAHgE+APYA2" & _
            "QDEAP0AvAA="
        Me.GridMovimientos.TabIndex = 6
        Me.GridMovimientos.Text = "C1FlexGrid1"
        Me.GridMovimientos.TopRow = 1
        '
        'LabelDetalleVisita
        '
        Me.LabelDetalleVisita.Location = New System.Drawing.Point(3, 4)
        Me.LabelDetalleVisita.Name = "LabelDetalleVisita"
        Me.LabelDetalleVisita.Size = New System.Drawing.Size(234, 18)
        Me.LabelDetalleVisita.Text = "LabelDetalleVisita"
        '
        'FormVisitaDetalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(242, 295)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Location = New System.Drawing.Point(0, 0)
        Me.Menu = Me.mainMenu1
        Me.MinimizeBox = False
        Me.Name = "FormVisitaDetalle"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MenuItemRegresar As System.Windows.Forms.MenuItem
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GridDetalles As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents GridMovimientos As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents LabelDetalleVisita As System.Windows.Forms.Label
End Class
