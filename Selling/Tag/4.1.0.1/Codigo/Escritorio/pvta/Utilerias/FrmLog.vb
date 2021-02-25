Public Class FrmLog
    Inherits System.Windows.Forms.Form

    Private dtCatalogos As DataTable

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
    Friend WithEvents UiTabUbica As Janus.Windows.UI.Tab.UITab
    Friend WithEvents UiTabLog As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtpFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GridConsulta As Janus.Windows.GridEX.GridEX
    Friend WithEvents BtnActualizar As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmLog))
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.BtnActualizar = New Janus.Windows.EditControls.UIButton()
        Me.UiTabUbica = New Janus.Windows.UI.Tab.UITab()
        Me.UiTabLog = New Janus.Windows.UI.Tab.UITabPage()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtpFin = New System.Windows.Forms.DateTimePicker()
        Me.dtpInicio = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GridConsulta = New Janus.Windows.GridEX.GridEX()
        CType(Me.UiTabUbica, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiTabUbica.SuspendLayout()
        Me.UiTabLog.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.GridConsulta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.BackColor = System.Drawing.SystemColors.Control
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.BtnCancelar.Location = New System.Drawing.Point(788, 519)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancelar.TabIndex = 4
        Me.BtnCancelar.Text = "&Salir"
        Me.BtnCancelar.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnActualizar
        '
        Me.BtnActualizar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnActualizar.Image = CType(resources.GetObject("BtnActualizar.Image"), System.Drawing.Image)
        Me.BtnActualizar.Location = New System.Drawing.Point(884, 519)
        Me.BtnActualizar.Name = "BtnActualizar"
        Me.BtnActualizar.Size = New System.Drawing.Size(90, 37)
        Me.BtnActualizar.TabIndex = 3
        Me.BtnActualizar.Text = "Ejecutar"
        Me.BtnActualizar.ToolTipText = "Ejecuta Corte de Información al Periodo y Mes indicado"
        Me.BtnActualizar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'UiTabUbica
        '
        Me.UiTabUbica.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UiTabUbica.Location = New System.Drawing.Point(6, 6)
        Me.UiTabUbica.Name = "UiTabUbica"
        Me.UiTabUbica.Size = New System.Drawing.Size(968, 501)
        Me.UiTabUbica.TabIndex = 135
        Me.UiTabUbica.TabPages.AddRange(New Janus.Windows.UI.Tab.UITabPage() {Me.UiTabLog})
        Me.UiTabUbica.VisualStyle = Janus.Windows.UI.Tab.TabVisualStyle.Office2007
        '
        'UiTabLog
        '
        Me.UiTabLog.Controls.Add(Me.GroupBox2)
        Me.UiTabLog.Location = New System.Drawing.Point(1, 21)
        Me.UiTabLog.Name = "UiTabLog"
        Me.UiTabLog.Size = New System.Drawing.Size(966, 479)
        Me.UiTabLog.TabStop = True
        Me.UiTabLog.Text = "Log "
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.dtpFin)
        Me.GroupBox2.Controls.Add(Me.dtpInicio)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.GridConsulta)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(951, 473)
        Me.GroupBox2.TabIndex = 6
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Consulta"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(145, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(36, 15)
        Me.Label3.TabIndex = 97
        Me.Label3.Text = "Fin"
        '
        'dtpFin
        '
        Me.dtpFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFin.Location = New System.Drawing.Point(187, 17)
        Me.dtpFin.Name = "dtpFin"
        Me.dtpFin.Size = New System.Drawing.Size(93, 20)
        Me.dtpFin.TabIndex = 96
        '
        'dtpInicio
        '
        Me.dtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpInicio.Location = New System.Drawing.Point(50, 18)
        Me.dtpInicio.Name = "dtpInicio"
        Me.dtpInicio.Size = New System.Drawing.Size(89, 20)
        Me.dtpInicio.TabIndex = 95
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(9, 22)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(36, 15)
        Me.Label4.TabIndex = 94
        Me.Label4.Text = "Inicio"
        '
        'GridConsulta
        '
        Me.GridConsulta.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridConsulta.ColumnAutoResize = True
        Me.GridConsulta.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridConsulta.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridConsulta.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridConsulta.GroupByBoxVisible = False
        Me.GridConsulta.Location = New System.Drawing.Point(6, 43)
        Me.GridConsulta.Name = "GridConsulta"
        Me.GridConsulta.RecordNavigator = True
        Me.GridConsulta.Size = New System.Drawing.Size(939, 424)
        Me.GridConsulta.TabIndex = 50
        Me.GridConsulta.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'FrmLog
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(984, 561)
        Me.Controls.Add(Me.UiTabUbica)
        Me.Controls.Add(Me.BtnActualizar)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmLog"
        Me.Text = "Sincronización"
        CType(Me.UiTabUbica, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiTabUbica.ResumeLayout(False)
        Me.UiTabLog.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.GridConsulta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region


    Private Sub FrmSync_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.LogError.Dispose()
        ModPOS.LogError = Nothing
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub



    Private Sub BtnActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnActualizar.Click

        If UiTabUbica.SelectedTab.Name = "UiTabLog" Then
            If dtpInicio.Value > dtpFin.Value Then
                MessageBox.Show("La fecha fin es menor a la fecha inicial", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            Cursor.Current = Cursors.WaitCursor
            ActualizaGrid(False, GridConsulta, "st_consulta_error", "@Inicio", dtpInicio.Value, "@Fin", dtpFin.Value.AddHours(23.9999))

            If GridConsulta.RowCount = 0 Then
                MessageBox.Show("No se encontraron registros en el rango de fechas seleccionado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            Cursor.Current = Cursors.Default
        End If
    End Sub

    Private Sub FrmSync_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtpInicio.Value = Today.Date
        dtpFin.Value = Today.Date
    End Sub
End Class
