Public Class FrmMtoValor
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
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnModificar As Janus.Windows.EditControls.UIButton
    Friend WithEvents GrpValor As System.Windows.Forms.GroupBox
    Friend WithEvents GridValores As Janus.Windows.GridEX.GridEX
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMtoValor))
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton
        Me.BtnModificar = New Janus.Windows.EditControls.UIButton
        Me.GrpValor = New System.Windows.Forms.GroupBox
        Me.GridValores = New Janus.Windows.GridEX.GridEX
        Me.GrpValor.SuspendLayout()
        CType(Me.GridValores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(462, 337)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancelar.TabIndex = 15
        Me.BtnCancelar.Text = "&Salir"
        Me.BtnCancelar.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnModificar
        '
        Me.BtnModificar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnModificar.Image = CType(resources.GetObject("BtnModificar.Image"), System.Drawing.Image)
        Me.BtnModificar.Location = New System.Drawing.Point(558, 337)
        Me.BtnModificar.Name = "BtnModificar"
        Me.BtnModificar.Size = New System.Drawing.Size(90, 37)
        Me.BtnModificar.TabIndex = 14
        Me.BtnModificar.Text = "&Modificar"
        Me.BtnModificar.ToolTipText = "Modifica Valor seleccionado"
        Me.BtnModificar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GrpValor
        '
        Me.GrpValor.Controls.Add(Me.BtnCancelar)
        Me.GrpValor.Controls.Add(Me.GridValores)
        Me.GrpValor.Controls.Add(Me.BtnModificar)
        Me.GrpValor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrpValor.Location = New System.Drawing.Point(0, 0)
        Me.GrpValor.Name = "GrpValor"
        Me.GrpValor.Size = New System.Drawing.Size(656, 380)
        Me.GrpValor.TabIndex = 11
        Me.GrpValor.TabStop = False
        Me.GrpValor.Text = "Valores por Referencia"
        '
        'GridValores
        '
        Me.GridValores.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridValores.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridValores.ColumnAutoResize = True
        Me.GridValores.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridValores.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridValores.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridValores.Location = New System.Drawing.Point(7, 15)
        Me.GridValores.Name = "GridValores"
        Me.GridValores.RecordNavigator = True
        Me.GridValores.Size = New System.Drawing.Size(642, 316)
        Me.GridValores.TabIndex = 1
        Me.GridValores.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'FrmMtoValor
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(656, 380)
        Me.Controls.Add(Me.GrpValor)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(553, 378)
        Me.Name = "FrmMtoValor"
        Me.Text = "Mantenimiento de Valores por Referencia"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GrpValor.ResumeLayout(False)
        CType(Me.GridValores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private sTabla As String
    Private sCampo As String
    Private sTipo As String

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub FrmMtoValor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        Cursor.Current = Cursors.WaitCursor
        ModPOS.ActualizaGrid(False, Me.GridValores, "sp_recupera_valores", Nothing)
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub GridValores_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridValores.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.BtnModificar.PerformClick()
        End If
    End Sub

    Private Sub GridValores_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridValores.SelectionChanged
        If Not GridValores.GetValue(0) Is Nothing Then
            Me.BtnModificar.Enabled = True
            Me.sTabla = GridValores.GetValue("Tabla")
            Me.sCampo = GridValores.GetValue("Campo")
            sTipo = GridValores.GetValue("Tipo")
        Else
            Me.sTabla = ""
            Me.sCampo = ""
            sTipo = ""

            Me.BtnModificar.Enabled = False
        End If
    End Sub

    Private Sub BtnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnModificar.Click
        modificar()
    End Sub

    Public Sub modificar()
        If sTabla <> "" AndAlso sCampo <> "" Then
            If ModPOS.Valores Is Nothing Then
                ModPOS.Valores = New FrmValores
                With ModPOS.Valores
                    .Tabla = sTabla
                    .Campo = sCampo
                    .Tipo = sTipo
                End With
            End If
            ModPOS.Valores.StartPosition = FormStartPosition.CenterScreen
            ModPOS.Valores.Show()
            ModPOS.Valores.BringToFront()
        End If
    End Sub

    Private Sub GridBancos_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridValores.DoubleClick
        modificar()
    End Sub

    Private Sub FrmMtoValor_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.MtoValor.Dispose()
        ModPOS.MtoValor = Nothing
    End Sub

End Class
