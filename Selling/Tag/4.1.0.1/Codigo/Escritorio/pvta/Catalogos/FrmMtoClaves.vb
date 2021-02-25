Public Class FrmMtoClaves
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
    Friend WithEvents BtnEliminar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnAgregar As Janus.Windows.EditControls.UIButton
    Friend WithEvents GrpClave As System.Windows.Forms.GroupBox
    Friend WithEvents GridClaves As Janus.Windows.GridEX.GridEX
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMtoClaves))
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.BtnModificar = New Janus.Windows.EditControls.UIButton()
        Me.BtnEliminar = New Janus.Windows.EditControls.UIButton()
        Me.GrpClave = New System.Windows.Forms.GroupBox()
        Me.GridClaves = New Janus.Windows.GridEX.GridEX()
        Me.BtnAgregar = New Janus.Windows.EditControls.UIButton()
        Me.GrpClave.SuspendLayout()
        CType(Me.GridClaves, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(270, 336)
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
        Me.BtnModificar.Location = New System.Drawing.Point(462, 336)
        Me.BtnModificar.Name = "BtnModificar"
        Me.BtnModificar.Size = New System.Drawing.Size(90, 37)
        Me.BtnModificar.TabIndex = 14
        Me.BtnModificar.Text = "&Modificar"
        Me.BtnModificar.ToolTipText = "Modificar claves de cliente seleccionado"
        Me.BtnModificar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnEliminar
        '
        Me.BtnEliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnEliminar.Image = CType(resources.GetObject("BtnEliminar.Image"), System.Drawing.Image)
        Me.BtnEliminar.Location = New System.Drawing.Point(366, 336)
        Me.BtnEliminar.Name = "BtnEliminar"
        Me.BtnEliminar.Size = New System.Drawing.Size(90, 37)
        Me.BtnEliminar.TabIndex = 13
        Me.BtnEliminar.Text = "&Eliminar"
        Me.BtnEliminar.ToolTipText = "Elimina todas claves del cliente seleccionado"
        Me.BtnEliminar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GrpClave
        '
        Me.GrpClave.Controls.Add(Me.GridClaves)
        Me.GrpClave.Controls.Add(Me.BtnAgregar)
        Me.GrpClave.Controls.Add(Me.BtnModificar)
        Me.GrpClave.Controls.Add(Me.BtnCancelar)
        Me.GrpClave.Controls.Add(Me.BtnEliminar)
        Me.GrpClave.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrpClave.Location = New System.Drawing.Point(0, 0)
        Me.GrpClave.Name = "GrpClave"
        Me.GrpClave.Size = New System.Drawing.Size(656, 380)
        Me.GrpClave.TabIndex = 11
        Me.GrpClave.TabStop = False
        Me.GrpClave.Text = "Claves de Clientes"
        '
        'GridClaves
        '
        Me.GridClaves.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridClaves.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridClaves.ColumnAutoResize = True
        Me.GridClaves.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridClaves.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridClaves.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridClaves.Location = New System.Drawing.Point(6, 15)
        Me.GridClaves.Name = "GridClaves"
        Me.GridClaves.RecordNavigator = True
        Me.GridClaves.Size = New System.Drawing.Size(642, 315)
        Me.GridClaves.TabIndex = 1
        Me.GridClaves.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'BtnAgregar
        '
        Me.BtnAgregar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAgregar.Image = CType(resources.GetObject("BtnAgregar.Image"), System.Drawing.Image)
        Me.BtnAgregar.Location = New System.Drawing.Point(558, 336)
        Me.BtnAgregar.Name = "BtnAgregar"
        Me.BtnAgregar.Size = New System.Drawing.Size(90, 37)
        Me.BtnAgregar.TabIndex = 12
        Me.BtnAgregar.Text = "&Agregar "
        Me.BtnAgregar.ToolTipText = "Agregar claves de clientes"
        Me.BtnAgregar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'FrmMtoClaves
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(656, 380)
        Me.Controls.Add(Me.GrpClave)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(553, 378)
        Me.Name = "FrmMtoClaves"
        Me.Text = "Mantenimiento de Claves de Clientes"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GrpClave.ResumeLayout(False)
        CType(Me.GridClaves, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private sClavesCliente As String
    Private sNombre As String
    
    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub FrmMtoClaves_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        Cursor.Current = Cursors.WaitCursor
        ModPOS.ActualizaGrid(False, Me.GridClaves, "st_muestra_claves_cte", "@COMClave", ModPOS.CompanyActual)
        Me.GridClaves.RootTable.Columns("CTEClave").Visible = False
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub GridClaves_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridClaves.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.BtnModificar.PerformClick()
        End If
    End Sub


    Private Sub GridClaves_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridClaves.SelectionChanged
        If Not GridClaves.GetValue(0) Is Nothing Then
            Me.BtnModificar.Enabled = True
            Me.BtnEliminar.Enabled = True
            Me.sClavesCliente = GridClaves.GetValue("CTEClave")
            Me.sNombre = GridClaves.GetValue("Razón Social")

        Else
            Me.sClavesCliente = ""
            Me.sNombre = ""
            Me.BtnModificar.Enabled = False
            Me.BtnEliminar.Enabled = False
        End If
    End Sub

    Private Sub BtnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregar.Click
        If ModPOS.Claves Is Nothing Then
            ModPOS.Claves = New FrmClaves
            With ModPOS.Claves
                .Text = "Agregar Claves de Cliente"
                .StartPosition = FormStartPosition.CenterScreen
                .Padre = "Agregar"

            End With
        End If
        ModPOS.Claves.StartPosition = FormStartPosition.CenterScreen
        ModPOS.Claves.Show()
        ModPOS.Claves.BringToFront()
    End Sub

    Private Sub BtnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnModificar.Click
        modificarClaves()
    End Sub

    Public Sub modificarClaves()
        If sClavesCliente <> "" Then

            If ModPOS.Claves Is Nothing Then

                ModPOS.Claves = New FrmClaves

                With ModPOS.Claves
                    .Text = "Modificar Claves de Cliente"
                    .Padre = "Modificar"
                    .CTEClave = sClavesCliente
                End With
            End If
            ModPOS.Claves.StartPosition = FormStartPosition.CenterScreen
            ModPOS.Claves.Show()
            ModPOS.Claves.BringToFront()
        End If
    End Sub

    Private Sub GridClaves_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridClaves.DoubleClick
        modificarClaves()
    End Sub

    Private Sub BtnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminar.Click
        If sClavesCliente <> "" Then
            Beep()

            Select Case MessageBox.Show("Se eliminara las Claves de Material del Cliente: " & sNombre, "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Case DialogResult.Yes

                   

                    ModPOS.Ejecuta("st_elimina_claves_cte", "@CTEClave", sClavesCliente, "@Usuario", ModPOS.UsuarioActual)

                    ModPOS.ActualizaGrid(False, Me.GridClaves, "st_muestra_claves_cte", "@COMClave", ModPOS.CompanyActual)
                    Me.GridClaves.RootTable.Columns("CTEClave").Visible = False


              
            End Select

        End If
    End Sub

    Private Sub FrmMtoClaves_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.MtoClaves.Dispose()
        ModPOS.MtoClaves = Nothing
    End Sub



End Class
