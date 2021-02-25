Public Class FrmConsulta
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'UserControl overrides dispose to clean up the component list.
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
    Friend WithEvents BtnGuardar As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnSalir As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnPicking As Janus.Windows.EditControls.UIButton

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents GridConsultaGen As Janus.Windows.GridEX.GridEX
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmConsulta))
        Me.GridConsultaGen = New Janus.Windows.GridEX.GridEX()
        Me.BtnGuardar = New Janus.Windows.EditControls.UIButton()
        Me.btnSalir = New Janus.Windows.EditControls.UIButton()
        Me.BtnPicking = New Janus.Windows.EditControls.UIButton()
        CType(Me.GridConsultaGen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GridConsultaGen
        '
        Me.GridConsultaGen.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridConsultaGen.ColumnAutoResize = True
        Me.GridConsultaGen.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DisplayedCellsAndHeader
        Me.GridConsultaGen.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridConsultaGen.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridConsultaGen.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown
        Me.GridConsultaGen.FocusCellDisplayMode = Janus.Windows.GridEX.FocusCellDisplayMode.UseSelectedFormatStyle
        Me.GridConsultaGen.Location = New System.Drawing.Point(6, 6)
        Me.GridConsultaGen.Name = "GridConsultaGen"
        Me.GridConsultaGen.RecordNavigator = True
        Me.GridConsultaGen.Size = New System.Drawing.Size(873, 507)
        Me.GridConsultaGen.TabIndex = 3
        Me.GridConsultaGen.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGuardar.Image = CType(resources.GetObject("BtnGuardar.Image"), System.Drawing.Image)
        Me.BtnGuardar.Location = New System.Drawing.Point(789, 519)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(90, 37)
        Me.BtnGuardar.TabIndex = 119
        Me.BtnGuardar.Text = "&Aceptar"
        Me.BtnGuardar.ToolTipText = "Guardar cambios"
        Me.BtnGuardar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btnSalir
        '
        Me.btnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.Location = New System.Drawing.Point(693, 519)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(90, 37)
        Me.btnSalir.TabIndex = 120
        Me.btnSalir.Text = "&Salir"
        Me.btnSalir.ToolTipText = "Cancelar y cerrar nómina"
        Me.btnSalir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnPicking
        '
        Me.BtnPicking.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnPicking.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnPicking.Icon = CType(resources.GetObject("BtnPicking.Icon"), System.Drawing.Icon)
        Me.BtnPicking.Location = New System.Drawing.Point(597, 519)
        Me.BtnPicking.Name = "BtnPicking"
        Me.BtnPicking.Size = New System.Drawing.Size(90, 37)
        Me.BtnPicking.TabIndex = 134
        Me.BtnPicking.Text = "Pedido"
        Me.BtnPicking.ToolTipText = "Consulta del documento seleccionado"
        Me.BtnPicking.Visible = False
        Me.BtnPicking.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'FrmConsulta
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(884, 561)
        Me.Controls.Add(Me.BtnPicking)
        Me.Controls.Add(Me.BtnGuardar)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.GridConsultaGen)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(367, 386)
        Me.Name = "FrmConsulta"
        Me.Text = "Consulta "
        CType(Me.GridConsultaGen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region
    Public Intro As Boolean = True

    Public foundRows() As DataRow


    Private bError As Boolean = False
    Public ID As String
    Public Campo As String
    Public ID2 As String = ""
    Public Campo2 As String = ""
    Public AutoSizeForm As Boolean = True

    Private Sub FrmConsulta_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If bError Then
            e.Cancel = True
        End If
    End Sub

    Private Sub FrmConsulta_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        GridConsultaGen.ColumnAutoResize = AutoSizeForm
        If AutoSizeForm = True Then
            Me.GridConsultaGen.AutoSizeColumns()
        End If
    End Sub

    Private Sub GridConsultaGen_CurrentCellChanged(sender As Object, e As EventArgs) Handles GridConsultaGen.CurrentCellChanged
        If Not GridConsultaGen.CurrentColumn Is Nothing Then
            GridConsultaGen.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False
        End If
    End Sub

    Private Sub GridConsultaGen_DoubleClick(sender As Object, e As EventArgs) Handles GridConsultaGen.DoubleClick
        Me.BtnGuardar.PerformClick()
    End Sub

    Private Sub GridConsultaGen_KeyDown(sender As Object, e As KeyEventArgs) Handles GridConsultaGen.KeyDown
        If Intro = True AndAlso e.KeyCode = Keys.Enter Then
            Me.BtnGuardar.PerformClick()
        End If
    End Sub


    Private Sub GridConsultaGen_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridConsultaGen.SelectionChanged
        If Not GridConsultaGen.GetValue(0) Is Nothing Then
            ID = GridConsultaGen.GetValue(Campo)
            If Campo2 <> "" Then
                ID2 = GridConsultaGen.GetValue(Campo2)
            End If
        Else
            ID = ""
            ID2 = ""
        End If
    End Sub

    Private Sub BtnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        bError = False
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnSalir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        bError = False
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub BtnPicking_Click(sender As Object, e As EventArgs) Handles BtnPicking.Click
        If ID <> "" Then

            Dim frmStatusMessage As New frmStatus
            frmStatusMessage.Show("Solicitando Información...")
            'Recupera impresoras por area de surtido

            Dim OpenReport As New Report
            Dim pvtaDataSet As New DataSet
            pvtaDataSet.DataSetName = "reportDataSet"
            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_tmp_encabezado_ped", "@VENClave", ID))
            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_tmp_detalle_ped", "@VENClave", ID))
            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_tmp_obtener_envio", "@VENClave", ID))
            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_tmp_complemento", "@VENClave", ID))

            pvtaDataSet.DataSetName = "pvtaDataSet"

            Try
                OpenReport.PrintPreview("Pedido", "CRPicking.rpt", pvtaDataSet, "")
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

            frmStatusMessage.Dispose()

            bError = True

        Else
            bError = True
            Beep()
            MessageBox.Show("¡No ha seleccionado algun registro!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub
End Class
