Public Class FrmSync
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
    Friend WithEvents GrpConfiguracion As System.Windows.Forms.GroupBox
    Friend WithEvents dInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GridCatalogos As Janus.Windows.GridEX.GridEX
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents BtnActualizar As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSync))
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton
        Me.GrpConfiguracion = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.dFin = New System.Windows.Forms.DateTimePicker
        Me.dInicio = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.BtnActualizar = New Janus.Windows.EditControls.UIButton
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GridCatalogos = New Janus.Windows.GridEX.GridEX
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.GrpConfiguracion.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.GridCatalogos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.BackColor = System.Drawing.SystemColors.Control
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.BtnCancelar.Location = New System.Drawing.Point(406, 343)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancelar.TabIndex = 4
        Me.BtnCancelar.Text = "&Salir"
        Me.BtnCancelar.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GrpConfiguracion
        '
        Me.GrpConfiguracion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpConfiguracion.Controls.Add(Me.Label1)
        Me.GrpConfiguracion.Controls.Add(Me.PictureBox2)
        Me.GrpConfiguracion.Controls.Add(Me.dFin)
        Me.GrpConfiguracion.Controls.Add(Me.dInicio)
        Me.GrpConfiguracion.Controls.Add(Me.Label2)
        Me.GrpConfiguracion.Location = New System.Drawing.Point(12, 13)
        Me.GrpConfiguracion.Name = "GrpConfiguracion"
        Me.GrpConfiguracion.Size = New System.Drawing.Size(580, 49)
        Me.GrpConfiguracion.TabIndex = 0
        Me.GrpConfiguracion.TabStop = False
        Me.GrpConfiguracion.Text = "Periodo de Sincronización "
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(189, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 15)
        Me.Label1.TabIndex = 92
        Me.Label1.Text = "Fin"
        '
        'dFin
        '
        Me.dFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dFin.Location = New System.Drawing.Point(230, 18)
        Me.dFin.Name = "dFin"
        Me.dFin.Size = New System.Drawing.Size(93, 20)
        Me.dFin.TabIndex = 91
        '
        'dInicio
        '
        Me.dInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dInicio.Location = New System.Drawing.Point(54, 19)
        Me.dInicio.Name = "dInicio"
        Me.dInicio.Size = New System.Drawing.Size(89, 20)
        Me.dInicio.TabIndex = 90
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(13, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(36, 15)
        Me.Label2.TabIndex = 89
        Me.Label2.Text = "Inicio"
        '
        'BtnActualizar
        '
        Me.BtnActualizar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnActualizar.Image = CType(resources.GetObject("BtnActualizar.Image"), System.Drawing.Image)
        Me.BtnActualizar.Location = New System.Drawing.Point(502, 343)
        Me.BtnActualizar.Name = "BtnActualizar"
        Me.BtnActualizar.Size = New System.Drawing.Size(90, 37)
        Me.BtnActualizar.TabIndex = 3
        Me.BtnActualizar.Text = "Ejecutar"
        Me.BtnActualizar.ToolTipText = "Ejecuta Corte de Información al Periodo y Mes indicado"
        Me.BtnActualizar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.GridCatalogos)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 68)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(580, 269)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Sincronizar"
        '
        'GridCatalogos
        '
        Me.GridCatalogos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridCatalogos.ColumnAutoResize = True
        Me.GridCatalogos.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridCatalogos.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridCatalogos.GroupByBoxVisible = False
        Me.GridCatalogos.Location = New System.Drawing.Point(7, 17)
        Me.GridCatalogos.Name = "GridCatalogos"
        Me.GridCatalogos.RecordNavigator = True
        Me.GridCatalogos.Size = New System.Drawing.Size(568, 246)
        Me.GridCatalogos.TabIndex = 50
        Me.GridCatalogos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'PictureBox2
        '
        Me.PictureBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(329, 19)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox2.TabIndex = 48
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'FrmSync
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(602, 385)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.BtnActualizar)
        Me.Controls.Add(Me.GrpConfiguracion)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmSync"
        Me.Text = "Sincronización"
        Me.GrpConfiguracion.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.GridCatalogos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region


    Private Sub FrmSync_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.Sync.Dispose()
        ModPOS.Sync = Nothing
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub


 
    Private Sub BtnActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnActualizar.Click

        Dim i As Integer
        Dim frmStatusMessage As New frmStatus
        Dim foundRows() As DataRow

        foundRows = dtCatalogos.Select("Estado='Activa'")

        Cursor.Current = Cursors.WaitCursor
        For i = 0 To foundRows.GetUpperBound(0)

            frmStatusMessage.Show("Sincronizando " & foundRows(i)("Catálogo") & "...")

            ModPOS.Ejecuta(foundRows(i)("sp"), "@Inicio", dInicio.Value, "@Fin", dFin.Value, "@Server", foundRows(i)("Server"))

        Next

        frmStatusMessage.Dispose()
        Cursor.Current = Cursors.Default

        dtCatalogos = ModPOS.Recupera_Tabla("sp_recupera_sync", Nothing)
        If dtCatalogos.Rows.Count > 0 Then
            GridCatalogos.DataSource = dtCatalogos
            GridCatalogos.RetrieveStructure(True)
            GridCatalogos.RootTable.Columns("sp").Visible = False
        End If
    End Sub

    Private Sub FrmSync_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dt As DataTable
        dt = ModPOS.Recupera_Tabla("sp_recupera_sincronizacion", Nothing)
        dInicio.Value = IIf(dt.Rows(0)("MFechaHora").GetType.Name = "DBNull", "", dt.Rows(0)("MFechaHora"))
        dt.Dispose()

        dFin.Value = Today.Date

        dtCatalogos = ModPOS.Recupera_Tabla("sp_recupera_sync", Nothing)
        If dtCatalogos.Rows.Count > 0 Then
            GridCatalogos.DataSource = dtCatalogos
            GridCatalogos.RetrieveStructure(True)
            GridCatalogos.RootTable.Columns("sp").Visible = False
        End If

    End Sub
End Class
