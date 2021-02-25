<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class FormConfiguracionCliente
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If Not IsNothing(Me.MenuItem1) Then Me.MenuItem1.Dispose()
        If Not IsNothing(Me.mainMenu1) Then Me.mainMenu1.Dispose()
        If Not Me.FG Is Nothing Then Me.FG.Dispose()
        Me.FG = Nothing
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormConfiguracionCliente))
        Me.mainMenu1 = New System.Windows.Forms.MainMenu
        Me.MenuItem1 = New System.Windows.Forms.MenuItem
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.FG = New C1.Win.C1FlexGrid.C1FlexGrid
        Me.btRegresar = New System.Windows.Forms.Button
        Me.lbTitulo = New System.Windows.Forms.Label
        Me.btContinuar = New System.Windows.Forms.Button
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'mainMenu1
        '
        Me.mainMenu1.MenuItems.Add(Me.MenuItem1)
        '
        'MenuItem1
        '
        Me.MenuItem1.Text = "MenuItemRegresar"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.FG)
        Me.Panel1.Controls.Add(Me.btRegresar)
        Me.Panel1.Controls.Add(Me.lbTitulo)
        Me.Panel1.Controls.Add(Me.btContinuar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(242, 295)
        '
        'FG
        '
        Me.FG.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.FG.AllowEditing = False
        Me.FG.AutoResize = True
        Me.FG.AutoSearchDelay = 1
        Me.FG.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.FG.Clip = ""
        Me.FG.ClipSeparators = "" & Global.Microsoft.VisualBasic.ChrW(9) & Global.Microsoft.VisualBasic.ChrW(13)
        Me.FG.Col = 1
        Me.FG.ColSel = 1
        Me.FG.ComboList = Nothing
        Me.FG.EditMask = Nothing
        Me.FG.ExtendLastCol = True
        Me.FG.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.FG.LeftCol = 1
        Me.FG.Location = New System.Drawing.Point(3, 31)
        Me.FG.Name = "FG"
        Me.FG.Redraw = True
        Me.FG.Row = 1
        Me.FG.RowSel = 1
        Me.FG.ScrollPosition = New System.Drawing.Point(0, 0)
        Me.FG.ScrollTrack = True
        Me.FG.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.FG.ShowCursor = False
        Me.FG.ShowSort = True
        Me.FG.Size = New System.Drawing.Size(234, 225)
        Me.FG.StyleInfo = resources.GetString("FG.StyleInfo")
        Me.FG.SupportInfo = "IgFIAWkBswAuAEABQAFFAdIARAC+AGsAbQCnAKAAegAJAfQAJQHSAKIA"
        Me.FG.TabIndex = 4
        Me.FG.Text = "C1FlexGrid1"
        Me.FG.TopRow = 1
        '
        'btRegresar
        '
        Me.btRegresar.Location = New System.Drawing.Point(86, 262)
        Me.btRegresar.Name = "btRegresar"
        Me.btRegresar.Size = New System.Drawing.Size(74, 24)
        Me.btRegresar.TabIndex = 5
        Me.btRegresar.Text = "btRegresar"
        '
        'lbTitulo
        '
        Me.lbTitulo.Location = New System.Drawing.Point(3, 8)
        Me.lbTitulo.Name = "lbTitulo"
        Me.lbTitulo.Size = New System.Drawing.Size(234, 20)
        Me.lbTitulo.Text = "lbTitulo"
        Me.lbTitulo.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btContinuar
        '
        Me.btContinuar.Location = New System.Drawing.Point(3, 262)
        Me.btContinuar.Name = "btContinuar"
        Me.btContinuar.Size = New System.Drawing.Size(74, 24)
        Me.btContinuar.TabIndex = 7
        Me.btContinuar.Text = "btContinuar"
        '
        'FormConfiguracionCliente
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(242, 295)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Menu = Me.mainMenu1
        Me.MinimizeBox = False
        Me.Name = "FormConfiguracionCliente"
        Me.Text = "Amesol Route"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents FG As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents btRegresar As System.Windows.Forms.Button
    Friend WithEvents lbTitulo As System.Windows.Forms.Label
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents btContinuar As System.Windows.Forms.Button
End Class
