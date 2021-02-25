<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class FormPreliquidacion
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If Not Me.C1FlexGridDeposito Is Nothing Then Me.C1FlexGridDeposito.Dispose()
        Me.C1FlexGridDeposito = Nothing
        If Not Me.C1FlexGridEfectivo Is Nothing Then Me.C1FlexGridEfectivo.Dispose()
        Me.C1FlexGridEfectivo = Nothing
        If Not Me.MenuItemRegresar Is Nothing Then Me.MenuItemRegresar.Dispose()
        If Not Me.mainMenuPreliq Is Nothing Then Me.mainMenuPreliq.Dispose()
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub
    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        If g_SO = SO.WindowsCE Then
            Call InTheHand.Windows.Forms.ContextMenuHelper.HookAllControls(Me.Controls)
        End If
    End Sub

    'Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
    '    If Not Me.C1FlexGridDeposito Is Nothing Then Me.C1FlexGridDeposito.Dispose()
    '    Me.C1FlexGridDeposito = Nothing
    '    If Not Me.C1FlexGridEfectivo Is Nothing Then Me.C1FlexGridEfectivo.Dispose()
    '    Me.C1FlexGridEfectivo = Nothing
    '    If Not Me.MenuItemRegresar Is Nothing Then Me.MenuItemRegresar.Dispose()
    '    If Not Me.mainMenuPreliq Is Nothing Then Me.mainMenuPreliq.Dispose()
    '    If disposing AndAlso components IsNot Nothing Then
    '        components.Dispose()
    '    End If
    '    MyBase.Dispose(disposing)
    'End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer
    Private mainMenuPreliq As System.Windows.Forms.MainMenu

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormPreliquidacion))
        Me.mainMenuPreliq = New System.Windows.Forms.MainMenu
        Me.MenuItemRegresar = New System.Windows.Forms.MenuItem
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.TextBoxFecha = New System.Windows.Forms.TextBox
        Me.TabControlPreliq = New System.Windows.Forms.TabControl
        Me.TabPageDeposito = New System.Windows.Forms.TabPage
        Me.C1FlexGridDepositoMoneda = New C1.Win.C1FlexGrid.C1FlexGrid
        Me.TextBoxTotalDeposito = New System.Windows.Forms.TextBox
        Me.LabelTotalDeposito = New System.Windows.Forms.Label
        Me.C1FlexGridDeposito = New C1.Win.C1FlexGrid.C1FlexGrid
        Me.ContextMenuPreliq = New System.Windows.Forms.ContextMenu
        Me.MenuItemEliminar = New System.Windows.Forms.MenuItem
        Me.LabelPrincipal = New System.Windows.Forms.Label
        Me.TabPageEfectivo = New System.Windows.Forms.TabPage
        Me.C1FlexGridEfectivoMoneda = New C1.Win.C1FlexGrid.C1FlexGrid
        Me.C1FlexGridEfectivo = New C1.Win.C1FlexGrid.C1FlexGrid
        Me.TextBoxTotalEfectivo = New System.Windows.Forms.TextBox
        Me.LabelTotalEfectivo = New System.Windows.Forms.Label
        Me.LabelFechaPago = New System.Windows.Forms.Label
        Me.ButtonContinuarDep = New System.Windows.Forms.Button
        Me.ButtonRegresarDep = New System.Windows.Forms.Button
        Me.Panel1.SuspendLayout()
        Me.TabControlPreliq.SuspendLayout()
        Me.TabPageDeposito.SuspendLayout()
        Me.TabPageEfectivo.SuspendLayout()
        Me.SuspendLayout()
        '
        'mainMenuPreliq
        '
        Me.mainMenuPreliq.MenuItems.Add(Me.MenuItemRegresar)
        '
        'MenuItemRegresar
        '
        Me.MenuItemRegresar.Text = "MenuItemRegresar"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.TextBoxFecha)
        Me.Panel1.Controls.Add(Me.TabControlPreliq)
        Me.Panel1.Controls.Add(Me.LabelFechaPago)
        Me.Panel1.Controls.Add(Me.ButtonContinuarDep)
        Me.Panel1.Controls.Add(Me.ButtonRegresarDep)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(242, 295)
        '
        'TextBoxFecha
        '
        Me.TextBoxFecha.Enabled = False
        Me.TextBoxFecha.Location = New System.Drawing.Point(149, 3)
        Me.TextBoxFecha.Name = "TextBoxFecha"
        Me.TextBoxFecha.Size = New System.Drawing.Size(86, 23)
        Me.TextBoxFecha.TabIndex = 19
        '
        'TabControlPreliq
        '
        Me.TabControlPreliq.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControlPreliq.Controls.Add(Me.TabPageDeposito)
        Me.TabControlPreliq.Controls.Add(Me.TabPageEfectivo)
        Me.TabControlPreliq.Location = New System.Drawing.Point(0, 32)
        Me.TabControlPreliq.Name = "TabControlPreliq"
        Me.TabControlPreliq.SelectedIndex = 0
        Me.TabControlPreliq.Size = New System.Drawing.Size(242, 233)
        Me.TabControlPreliq.TabIndex = 1
        '
        'TabPageDeposito
        '
        Me.TabPageDeposito.Controls.Add(Me.C1FlexGridDepositoMoneda)
        Me.TabPageDeposito.Controls.Add(Me.TextBoxTotalDeposito)
        Me.TabPageDeposito.Controls.Add(Me.LabelTotalDeposito)
        Me.TabPageDeposito.Controls.Add(Me.C1FlexGridDeposito)
        Me.TabPageDeposito.Controls.Add(Me.LabelPrincipal)
        Me.TabPageDeposito.Location = New System.Drawing.Point(4, 25)
        Me.TabPageDeposito.Name = "TabPageDeposito"
        Me.TabPageDeposito.Size = New System.Drawing.Size(234, 204)
        Me.TabPageDeposito.Text = "TabPageDeposito"
        '
        'C1FlexGridDepositoMoneda
        '
        Me.C1FlexGridDepositoMoneda.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.C1FlexGridDepositoMoneda.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.C1FlexGridDepositoMoneda.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.C1FlexGridDepositoMoneda.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.C1FlexGridDepositoMoneda.Location = New System.Drawing.Point(3, 4)
        Me.C1FlexGridDepositoMoneda.Name = "C1FlexGridDepositoMoneda"
        Me.C1FlexGridDepositoMoneda.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.C1FlexGridDepositoMoneda.Size = New System.Drawing.Size(225, 80)
        Me.C1FlexGridDepositoMoneda.StyleInfo = resources.GetString("C1FlexGridDepositoMoneda.StyleInfo")
        Me.C1FlexGridDepositoMoneda.SupportInfo = "TQC1AOEAAQFzADsBrQBsAJ4AIAEfARUB+wA9Ad4ArQB4ABkBnQAAAYMAogA0Ab0AcwABAUYBjgDmAJcAA" & _
            "wF3AIcAPQDaAFkAvQCyAJcAlgB3AA=="
        Me.C1FlexGridDepositoMoneda.TabIndex = 24
        '
        'TextBoxTotalDeposito
        '
        Me.TextBoxTotalDeposito.Enabled = False
        Me.TextBoxTotalDeposito.Location = New System.Drawing.Point(120, 213)
        Me.TextBoxTotalDeposito.Name = "TextBoxTotalDeposito"
        Me.TextBoxTotalDeposito.Size = New System.Drawing.Size(110, 23)
        Me.TextBoxTotalDeposito.TabIndex = 7
        '
        'LabelTotalDeposito
        '
        Me.LabelTotalDeposito.Location = New System.Drawing.Point(4, 216)
        Me.LabelTotalDeposito.Name = "LabelTotalDeposito"
        Me.LabelTotalDeposito.Size = New System.Drawing.Size(119, 20)
        Me.LabelTotalDeposito.Text = "LabelTotalDeposito"
        '
        'C1FlexGridDeposito
        '
        Me.C1FlexGridDeposito.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.C1FlexGridDeposito.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.C1FlexGridDeposito.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.C1FlexGridDeposito.ContextMenu = Me.ContextMenuPreliq
        Me.C1FlexGridDeposito.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.C1FlexGridDeposito.Location = New System.Drawing.Point(3, 90)
        Me.C1FlexGridDeposito.Name = "C1FlexGridDeposito"
        Me.C1FlexGridDeposito.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.C1FlexGridDeposito.Size = New System.Drawing.Size(225, 117)
        Me.C1FlexGridDeposito.StyleInfo = resources.GetString("C1FlexGridDeposito.StyleInfo")
        Me.C1FlexGridDeposito.SupportInfo = "yQClAMQAuwBvAEgBfwCUAIcAYgFIAewAlACuABMB/wAVAa4AAwFlAf8ATwEGAfQA0wBFAKcA1QBuABkBJ" & _
            "AGYAO4ABAHTABwBkAA="
        Me.C1FlexGridDeposito.TabIndex = 5
        '
        'ContextMenuPreliq
        '
        Me.ContextMenuPreliq.MenuItems.Add(Me.MenuItemEliminar)
        '
        'MenuItemEliminar
        '
        Me.MenuItemEliminar.Text = "MenuItemEliminar"
        '
        'LabelPrincipal
        '
        Me.LabelPrincipal.Location = New System.Drawing.Point(4, 1)
        Me.LabelPrincipal.Name = "LabelPrincipal"
        Me.LabelPrincipal.Size = New System.Drawing.Size(230, 20)
        '
        'TabPageEfectivo
        '
        Me.TabPageEfectivo.Controls.Add(Me.C1FlexGridEfectivoMoneda)
        Me.TabPageEfectivo.Controls.Add(Me.C1FlexGridEfectivo)
        Me.TabPageEfectivo.Controls.Add(Me.TextBoxTotalEfectivo)
        Me.TabPageEfectivo.Controls.Add(Me.LabelTotalEfectivo)
        Me.TabPageEfectivo.Location = New System.Drawing.Point(4, 25)
        Me.TabPageEfectivo.Name = "TabPageEfectivo"
        Me.TabPageEfectivo.Size = New System.Drawing.Size(234, 204)
        Me.TabPageEfectivo.Text = "TabPageEfectivo"
        '
        'C1FlexGridEfectivoMoneda
        '
        Me.C1FlexGridEfectivoMoneda.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.C1FlexGridEfectivoMoneda.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.C1FlexGridEfectivoMoneda.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.C1FlexGridEfectivoMoneda.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.C1FlexGridEfectivoMoneda.Location = New System.Drawing.Point(3, 4)
        Me.C1FlexGridEfectivoMoneda.Name = "C1FlexGridEfectivoMoneda"
        Me.C1FlexGridEfectivoMoneda.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.C1FlexGridEfectivoMoneda.Size = New System.Drawing.Size(225, 80)
        Me.C1FlexGridEfectivoMoneda.StyleInfo = resources.GetString("C1FlexGridEfectivoMoneda.StyleInfo")
        Me.C1FlexGridEfectivoMoneda.SupportInfo = "pACgAfwA9QDlAGQBDwGrADUB6gDiANwAGAGZAFABGwGTADwB8ADmAMgAGQGJANUAzABSAQgB+QA8AQQBT" & _
            "wBtALMABwG9AFEA8wCsAL0ACAFuAA=="
        Me.C1FlexGridEfectivoMoneda.TabIndex = 25
        '
        'C1FlexGridEfectivo
        '
        Me.C1FlexGridEfectivo.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.C1FlexGridEfectivo.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.C1FlexGridEfectivo.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.C1FlexGridEfectivo.ContextMenu = Me.ContextMenuPreliq
        Me.C1FlexGridEfectivo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.C1FlexGridEfectivo.Location = New System.Drawing.Point(3, 90)
        Me.C1FlexGridEfectivo.Name = "C1FlexGridEfectivo"
        Me.C1FlexGridEfectivo.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.C1FlexGridEfectivo.Size = New System.Drawing.Size(225, 117)
        Me.C1FlexGridEfectivo.StyleInfo = resources.GetString("C1FlexGridEfectivo.StyleInfo")
        Me.C1FlexGridEfectivo.SupportInfo = "cwAqATsBFAEAAWsB9gCaACMBJQFMAWoBuABWAZ8AiQD4AGsAJgE2AR8BGAGRAAsB4gAvAdwAHgFxAJ4AX" & _
            "wCMAMYAMgDXANcA7gA="
        Me.C1FlexGridEfectivo.TabIndex = 0
        '
        'TextBoxTotalEfectivo
        '
        Me.TextBoxTotalEfectivo.Enabled = False
        Me.TextBoxTotalEfectivo.Location = New System.Drawing.Point(120, 213)
        Me.TextBoxTotalEfectivo.Name = "TextBoxTotalEfectivo"
        Me.TextBoxTotalEfectivo.Size = New System.Drawing.Size(110, 23)
        Me.TextBoxTotalEfectivo.TabIndex = 3
        '
        'LabelTotalEfectivo
        '
        Me.LabelTotalEfectivo.Location = New System.Drawing.Point(5, 216)
        Me.LabelTotalEfectivo.Name = "LabelTotalEfectivo"
        Me.LabelTotalEfectivo.Size = New System.Drawing.Size(115, 20)
        Me.LabelTotalEfectivo.Text = "LabelTotalEfectivo"
        '
        'LabelFechaPago
        '
        Me.LabelFechaPago.Location = New System.Drawing.Point(8, 3)
        Me.LabelFechaPago.Name = "LabelFechaPago"
        Me.LabelFechaPago.Size = New System.Drawing.Size(153, 31)
        Me.LabelFechaPago.Text = "LabelFechaPago"
        '
        'ButtonContinuarDep
        '
        Me.ButtonContinuarDep.Location = New System.Drawing.Point(3, 267)
        Me.ButtonContinuarDep.Name = "ButtonContinuarDep"
        Me.ButtonContinuarDep.Size = New System.Drawing.Size(74, 24)
        Me.ButtonContinuarDep.TabIndex = 3
        Me.ButtonContinuarDep.Text = "ButtonContinuarDep"
        '
        'ButtonRegresarDep
        '
        Me.ButtonRegresarDep.Location = New System.Drawing.Point(90, 267)
        Me.ButtonRegresarDep.Name = "ButtonRegresarDep"
        Me.ButtonRegresarDep.Size = New System.Drawing.Size(74, 24)
        Me.ButtonRegresarDep.TabIndex = 4
        Me.ButtonRegresarDep.Text = "ButtonRegresarDep"
        '
        'FormPreliquidacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(242, 295)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Menu = Me.mainMenuPreliq
        Me.MinimizeBox = False
        Me.Name = "FormPreliquidacion"
        Me.Text = "FormPreliquidacion"
        Me.Panel1.ResumeLayout(False)
        Me.TabControlPreliq.ResumeLayout(False)
        Me.TabPageDeposito.ResumeLayout(False)
        Me.TabPageEfectivo.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MenuItemRegresar As System.Windows.Forms.MenuItem
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TabControlPreliq As System.Windows.Forms.TabControl
    Friend WithEvents TabPageDeposito As System.Windows.Forms.TabPage
    Friend WithEvents LabelPrincipal As System.Windows.Forms.Label
    Friend WithEvents ButtonContinuarDep As System.Windows.Forms.Button
    Friend WithEvents ButtonRegresarDep As System.Windows.Forms.Button
    Friend WithEvents TabPageEfectivo As System.Windows.Forms.TabPage
    Friend WithEvents C1FlexGridEfectivo As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents TextBoxTotalEfectivo As System.Windows.Forms.TextBox
    Friend WithEvents LabelTotalEfectivo As System.Windows.Forms.Label
    Friend WithEvents C1FlexGridDeposito As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents TextBoxTotalDeposito As System.Windows.Forms.TextBox
    Friend WithEvents LabelTotalDeposito As System.Windows.Forms.Label
    Friend WithEvents TextBoxFecha As System.Windows.Forms.TextBox
    Friend WithEvents LabelFechaPago As System.Windows.Forms.Label
    Friend WithEvents ContextMenuPreliq As System.Windows.Forms.ContextMenu
    Friend WithEvents MenuItemEliminar As System.Windows.Forms.MenuItem
    Friend WithEvents C1FlexGridDepositoMoneda As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents C1FlexGridEfectivoMoneda As C1.Win.C1FlexGrid.C1FlexGrid
End Class
