Public Class FrmBuscaCorte
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents GrpTickets As System.Windows.Forms.GroupBox
    Friend WithEvents GridCorte As Janus.Windows.GridEX.GridEX
    Friend WithEvents BtnGuardar As Janus.Windows.EditControls.UIButton
    Friend WithEvents cmbInicial As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbFinal As System.Windows.Forms.DateTimePicker
    Friend WithEvents BtnSalir As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmBuscaCorte))
        Me.GrpTickets = New System.Windows.Forms.GroupBox()
        Me.cmbFinal = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbInicial = New System.Windows.Forms.DateTimePicker()
        Me.GridCorte = New Janus.Windows.GridEX.GridEX()
        Me.BtnSalir = New Janus.Windows.EditControls.UIButton()
        Me.BtnGuardar = New Janus.Windows.EditControls.UIButton()
        Me.GrpTickets.SuspendLayout()
        CType(Me.GridCorte, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpTickets
        '
        Me.GrpTickets.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpTickets.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GrpTickets.Controls.Add(Me.cmbFinal)
        Me.GrpTickets.Controls.Add(Me.Label1)
        Me.GrpTickets.Controls.Add(Me.cmbInicial)
        Me.GrpTickets.Controls.Add(Me.GridCorte)
        Me.GrpTickets.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpTickets.ForeColor = System.Drawing.Color.Black
        Me.GrpTickets.Location = New System.Drawing.Point(7, 7)
        Me.GrpTickets.Name = "GrpTickets"
        Me.GrpTickets.Size = New System.Drawing.Size(778, 420)
        Me.GrpTickets.TabIndex = 1
        Me.GrpTickets.TabStop = False
        Me.GrpTickets.Text = "Busqueda"
        '
        'cmbFinal
        '
        Me.cmbFinal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbFinal.CustomFormat = "yyyyMMdd"
        Me.cmbFinal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.cmbFinal.Location = New System.Drawing.Point(653, 17)
        Me.cmbFinal.MinDate = New Date(1990, 1, 1, 0, 0, 0, 0)
        Me.cmbFinal.Name = "cmbFinal"
        Me.cmbFinal.Size = New System.Drawing.Size(119, 22)
        Me.cmbFinal.TabIndex = 73
        Me.cmbFinal.Value = New Date(2000, 2, 2, 0, 0, 0, 0)
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(628, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(19, 16)
        Me.Label1.TabIndex = 72
        Me.Label1.Text = "al"
        '
        'cmbInicial
        '
        Me.cmbInicial.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbInicial.CustomFormat = "yyyyMMdd"
        Me.cmbInicial.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.cmbInicial.Location = New System.Drawing.Point(503, 17)
        Me.cmbInicial.MinDate = New Date(1990, 1, 1, 0, 0, 0, 0)
        Me.cmbInicial.Name = "cmbInicial"
        Me.cmbInicial.Size = New System.Drawing.Size(119, 22)
        Me.cmbInicial.TabIndex = 70
        Me.cmbInicial.Value = New Date(2000, 2, 2, 0, 0, 0, 0)
        '
        'GridCorte
        '
        Me.GridCorte.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridCorte.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridCorte.ColumnAutoResize = True
        Me.GridCorte.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridCorte.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridCorte.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridCorte.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown
        Me.GridCorte.GroupByBoxVisible = False
        Me.GridCorte.Location = New System.Drawing.Point(7, 47)
        Me.GridCorte.Name = "GridCorte"
        Me.GridCorte.RecordNavigator = True
        Me.GridCorte.Size = New System.Drawing.Size(765, 367)
        Me.GridCorte.TabIndex = 2
        Me.GridCorte.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'BtnSalir
        '
        Me.BtnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSalir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnSalir.Image = CType(resources.GetObject("BtnSalir.Image"), System.Drawing.Image)
        Me.BtnSalir.Location = New System.Drawing.Point(599, 433)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(90, 37)
        Me.BtnSalir.TabIndex = 45
        Me.BtnSalir.Text = "Cancelar"
        Me.BtnSalir.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnSalir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGuardar.Image = CType(resources.GetObject("BtnGuardar.Image"), System.Drawing.Image)
        Me.BtnGuardar.Location = New System.Drawing.Point(695, 433)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(90, 37)
        Me.BtnGuardar.TabIndex = 44
        Me.BtnGuardar.Text = "&Aceptar"
        Me.BtnGuardar.ToolTipText = "Mostrar corte de caja seleccionado"
        Me.BtnGuardar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'FrmBuscaCorte
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(792, 473)
        Me.Controls.Add(Me.BtnSalir)
        Me.Controls.Add(Me.GrpTickets)
        Me.Controls.Add(Me.BtnGuardar)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.ForeColor = System.Drawing.Color.Black
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(667, 464)
        Me.Name = "FrmBuscaCorte"
        Me.Text = "Corte de Caja"
        Me.GrpTickets.ResumeLayout(False)
        Me.GrpTickets.PerformLayout()
        CType(Me.GridCorte, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region


    Public bRetirosCaja As Boolean = False
    Public SUCClave As String = ""
    Public CAJClave As String
    Public IdCorte As String
    Public sp As String = "st_recupera_cortes"
    Public inicio, fin As Date
    Private bload As Boolean = False

    Private Sub FrmBuscaCorte_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        Me.StartPosition = FormStartPosition.CenterScreen

        cmbInicial.Value = inicio
        cmbFinal.Value = fin

        bload = True

        RefrescaGrid()
    End Sub

    Public Sub RefrescaGrid()

        If bRetirosCaja = True Then
            ModPOS.ActualizaGrid(False, Me.GridCorte, sp, "@SUCClave", SUCClave, "@Inicio", inicio.Date, "@Fin", fin.Date.AddHours(23.9999))
        Else
            ModPOS.ActualizaGrid(False, Me.GridCorte, sp, "@CAJClave", CAJClave, "@Inicio", inicio.Date, "@Fin", fin.Date.AddHours(23.9999))
        End If
        Me.GridCorte.RootTable.Columns("ID").Visible = False

    End Sub

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        If Not GridCorte.DataSource Is Nothing Then
            If Not GridCorte.GetValue(0) Is Nothing Then
                IdCorte = GridCorte.GetValue(0)
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                IdCorte = ""
            End If
            Me.Close()
        Else
            Beep()
            MessageBox.Show("¡No ha seleccionado algun registro!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub GridCorte_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridCorte.DoubleClick
        If Not GridCorte.GetValue(0) Is Nothing Then
            Me.BtnGuardar.PerformClick()
        End If
    End Sub

    Private Sub GridCorte_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridCorte.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.BtnGuardar.PerformClick()
        End If
    End Sub

    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub cmbInicial_ValueChanged(sender As Object, e As EventArgs) Handles cmbInicial.ValueChanged
        If bload Then
            inicio = cmbInicial.Value
            RefrescaGrid()
        End If
    End Sub

    Private Sub cmbFinal_ValueChanged(sender As Object, e As EventArgs) Handles cmbFinal.ValueChanged
        If bload Then
            fin = cmbFinal.Value
            RefrescaGrid()
        End If
    End Sub
End Class
