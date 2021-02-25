Public Class FrmMtoPaqueteria
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
    Friend WithEvents GrpPaqueterias As System.Windows.Forms.GroupBox
    Friend WithEvents GridPaqueterias As Janus.Windows.GridEX.GridEX
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMtoPaqueteria))
        Me.GrpPaqueterias = New System.Windows.Forms.GroupBox()
        Me.GridPaqueterias = New Janus.Windows.GridEX.GridEX()
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.BtnModificar = New Janus.Windows.EditControls.UIButton()
        Me.BtnEliminar = New Janus.Windows.EditControls.UIButton()
        Me.BtnAgregar = New Janus.Windows.EditControls.UIButton()
        Me.GrpPaqueterias.SuspendLayout()
        CType(Me.GridPaqueterias, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpPaqueterias
        '
        Me.GrpPaqueterias.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpPaqueterias.Controls.Add(Me.GridPaqueterias)
        Me.GrpPaqueterias.Location = New System.Drawing.Point(2, 0)
        Me.GrpPaqueterias.Name = "GrpPaqueterias"
        Me.GrpPaqueterias.Size = New System.Drawing.Size(736, 425)
        Me.GrpPaqueterias.TabIndex = 1
        Me.GrpPaqueterias.TabStop = False
        Me.GrpPaqueterias.Text = "Paqueterias"
        '
        'GridPaqueterias
        '
        Me.GridPaqueterias.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridPaqueterias.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridPaqueterias.ColumnAutoResize = True
        Me.GridPaqueterias.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridPaqueterias.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridPaqueterias.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridPaqueterias.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown
        Me.GridPaqueterias.Location = New System.Drawing.Point(7, 19)
        Me.GridPaqueterias.Name = "GridPaqueterias"
        Me.GridPaqueterias.RecordNavigator = True
        Me.GridPaqueterias.Size = New System.Drawing.Size(723, 398)
        Me.GridPaqueterias.TabIndex = 2
        Me.GridPaqueterias.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(360, 431)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancelar.TabIndex = 5
        Me.BtnCancelar.Text = "&Salir"
        Me.BtnCancelar.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnModificar
        '
        Me.BtnModificar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnModificar.Image = CType(resources.GetObject("BtnModificar.Image"), System.Drawing.Image)
        Me.BtnModificar.Location = New System.Drawing.Point(552, 431)
        Me.BtnModificar.Name = "BtnModificar"
        Me.BtnModificar.Size = New System.Drawing.Size(90, 37)
        Me.BtnModificar.TabIndex = 3
        Me.BtnModificar.Text = "&Modificar"
        Me.BtnModificar.ToolTipText = "Modificar paqueteria seleccionada"
        Me.BtnModificar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnEliminar
        '
        Me.BtnEliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnEliminar.Image = CType(resources.GetObject("BtnEliminar.Image"), System.Drawing.Image)
        Me.BtnEliminar.Location = New System.Drawing.Point(456, 431)
        Me.BtnEliminar.Name = "BtnEliminar"
        Me.BtnEliminar.Size = New System.Drawing.Size(90, 37)
        Me.BtnEliminar.TabIndex = 4
        Me.BtnEliminar.Text = "&Eliminar"
        Me.BtnEliminar.ToolTipText = "Eliminar paqueteria seleccionada"
        Me.BtnEliminar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnAgregar
        '
        Me.BtnAgregar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAgregar.Image = CType(resources.GetObject("BtnAgregar.Image"), System.Drawing.Image)
        Me.BtnAgregar.Location = New System.Drawing.Point(648, 431)
        Me.BtnAgregar.Name = "BtnAgregar"
        Me.BtnAgregar.Size = New System.Drawing.Size(90, 37)
        Me.BtnAgregar.TabIndex = 2
        Me.BtnAgregar.Text = "&Agregar "
        Me.BtnAgregar.ToolTipText = "Agregar nueva paqueteria"
        Me.BtnAgregar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'FrmMtoPaqueteria
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(742, 473)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.BtnModificar)
        Me.Controls.Add(Me.BtnEliminar)
        Me.Controls.Add(Me.BtnAgregar)
        Me.Controls.Add(Me.GrpPaqueterias)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(625, 464)
        Me.Name = "FrmMtoPaqueteria"
        Me.Text = "Mantenimiento de Paqueterias"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GrpPaqueterias.ResumeLayout(False)
        CType(Me.GridPaqueterias, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region


    Private sPaqSelected As String
    Private sNombre As String
  
    Public Sub refrescaGrid()
        Cursor.Current = Cursors.WaitCursor

        ModPOS.ActualizaGrid(True, Me.GridPaqueterias, "st_muestra_paqueteria", "@COMClave", ModPOS.CompanyActual)
        Me.GridPaqueterias.RootTable.Columns("PAQClave").Visible = False
        Cursor.Current = Cursors.Default

    End Sub

    Private Sub FrmMtoPaqueteria_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        refrescaGrid()
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub FrmMtoPaqueteria_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.MtoPaqueteria.Dispose()
        ModPOS.MtoPaqueteria = Nothing
    End Sub

    Private Sub GridPaqueterias_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridPaqueterias.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.BtnModificar.PerformClick()
        End If
    End Sub

    Private Sub GridPaqueterias_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridPaqueterias.SelectionChanged
        If Not GridPaqueterias.GetValue(0) Is Nothing Then
            Me.BtnModificar.Enabled = True
            Me.sPaqSelected = GridPaqueterias.GetValue("PAQClave")
            Me.sNombre = GridPaqueterias.GetValue("Nombre")
          
            If sPaqSelected = GridPaqueterias.GetValue("Clave") Then
                Me.BtnEliminar.Enabled = False
            Else
                Me.BtnEliminar.Enabled = True
            End If
        Else
            Me.sPaqSelected = ""
            Me.sNombre = ""
            Me.BtnModificar.Enabled = False
            Me.BtnEliminar.Enabled = False
        End If
    End Sub

    Private Sub BtnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregar.Click
        If ModPOS.Paqueteria Is Nothing Then
            ModPOS.Paqueteria = New FrmPaqueteria
            With ModPOS.Paqueteria
                .Text = "Agregar Paqueteria"
                .StartPosition = FormStartPosition.CenterScreen
                .Padre = "Agregar"
            End With
        End If
        ModPOS.Paqueteria.StartPosition = FormStartPosition.CenterScreen
        ModPOS.Paqueteria.Show()
        ModPOS.Paqueteria.BringToFront()
    End Sub

    Public Sub modificarPaqueteria()
        If sPaqSelected <> "" Then
            If ModPOS.Paqueteria Is Nothing Then
                ModPOS.Paqueteria = New FrmPaqueteria
                With ModPOS.Paqueteria
                    .Text = "Modificar Paqueteria"
                    .StartPosition = FormStartPosition.CenterScreen
                    .Padre = "Modificar"
                    .TxtClave.ReadOnly = True

                    Dim dt As DataTable
                    dt = ModPOS.Recupera_Tabla("st_recupera_paqueteria", "@PAQClave", Me.sPaqSelected)

                    .PAQClave = dt.Rows(0)("PAQClave")
                    .Clave = dt.Rows(0)("Clave")
                    .Nombre = dt.Rows(0)("Nombre")
                    .formaEnvio = dt.Rows(0)("formaEnvio")
                    .productoFlete = dt.Rows(0)("productoFlete")
                    .porSeguro = dt.Rows(0)("porSeguro")
                    .productoSeguro = IIf(dt.Rows(0)("productoSeguro").GetType.Name = "DBNull", "", dt.Rows(0)("productoSeguro"))
                    .volMaxCaja = dt.Rows(0)("volMaxCaja")
                    .porCombustible = dt.Rows(0)("porCombustible")
                    .Estado = dt.Rows(0)("Estado")
                    .PaqueteriaGenerica = IIf(dt.Rows(0)("paqueteriaGenerica").GetType.Name = "DBNull", 0, dt.Rows(0)("paqueteriaGenerica"))
                    .TarifaPesoMin = IIf(dt.Rows(0)("tarifaPesoMinimo").GetType.Name = "DBNull", 0, dt.Rows(0)("tarifaPesoMinimo"))

                    dt.Dispose()

                End With
            End If

            ModPOS.Paqueteria.StartPosition = FormStartPosition.CenterScreen
            ModPOS.Paqueteria.Show()
            ModPOS.Paqueteria.BringToFront()

        End If
    End Sub

    Private Sub BtnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnModificar.Click
        modificarPaqueteria()
    End Sub

    Private Sub GridPaqueterias_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridPaqueterias.DoubleClick
        modificarPaqueteria()
    End Sub

    Private Sub BtnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminar.Click
        If sPaqSelected <> "" Then
                Beep()
            Select Case MessageBox.Show("Se eliminara la Paquetería :" & sNombre, "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Case DialogResult.Yes
                    ModPOS.Ejecuta("st_elimina_paqueteria", "@PAQClave", sPaqSelected, "@Usuario", ModPOS.UsuarioActual)
                    refrescaGrid()
            End Select
           
        End If
    End Sub

 End Class
