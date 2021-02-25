Public Class FrmMtoLabelSheet
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
    Friend WithEvents GrpUnidades As System.Windows.Forms.GroupBox
    Friend WithEvents GridLabelSheets As Janus.Windows.GridEX.GridEX
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMtoLabelSheet))
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.BtnModificar = New Janus.Windows.EditControls.UIButton()
        Me.BtnEliminar = New Janus.Windows.EditControls.UIButton()
        Me.GrpUnidades = New System.Windows.Forms.GroupBox()
        Me.GridLabelSheets = New Janus.Windows.GridEX.GridEX()
        Me.BtnAgregar = New Janus.Windows.EditControls.UIButton()
        Me.GrpUnidades.SuspendLayout()
        CType(Me.GridLabelSheets, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(271, 336)
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
        Me.BtnModificar.Location = New System.Drawing.Point(463, 336)
        Me.BtnModificar.Name = "BtnModificar"
        Me.BtnModificar.Size = New System.Drawing.Size(90, 37)
        Me.BtnModificar.TabIndex = 14
        Me.BtnModificar.Text = "&Modificar"
        Me.BtnModificar.ToolTipText = "Modificar Plantilla seleccionada"
        Me.BtnModificar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnEliminar
        '
        Me.BtnEliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnEliminar.Image = CType(resources.GetObject("BtnEliminar.Image"), System.Drawing.Image)
        Me.BtnEliminar.Location = New System.Drawing.Point(367, 336)
        Me.BtnEliminar.Name = "BtnEliminar"
        Me.BtnEliminar.Size = New System.Drawing.Size(90, 37)
        Me.BtnEliminar.TabIndex = 13
        Me.BtnEliminar.Text = "&Eliminar"
        Me.BtnEliminar.ToolTipText = "Eliminar Plantilla seleccionada"
        Me.BtnEliminar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GrpUnidades
        '
        Me.GrpUnidades.Controls.Add(Me.BtnCancelar)
        Me.GrpUnidades.Controls.Add(Me.GridLabelSheets)
        Me.GrpUnidades.Controls.Add(Me.BtnEliminar)
        Me.GrpUnidades.Controls.Add(Me.BtnModificar)
        Me.GrpUnidades.Controls.Add(Me.BtnAgregar)
        Me.GrpUnidades.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrpUnidades.Location = New System.Drawing.Point(0, 0)
        Me.GrpUnidades.Name = "GrpUnidades"
        Me.GrpUnidades.Size = New System.Drawing.Size(656, 380)
        Me.GrpUnidades.TabIndex = 11
        Me.GrpUnidades.TabStop = False
        Me.GrpUnidades.Text = "Plantillas de Etiquetas"
        '
        'GridLabelSheets
        '
        Me.GridLabelSheets.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridLabelSheets.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridLabelSheets.ColumnAutoResize = True
        Me.GridLabelSheets.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridLabelSheets.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridLabelSheets.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridLabelSheets.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown
        Me.GridLabelSheets.Location = New System.Drawing.Point(7, 15)
        Me.GridLabelSheets.Name = "GridLabelSheets"
        Me.GridLabelSheets.RecordNavigator = True
        Me.GridLabelSheets.Size = New System.Drawing.Size(643, 315)
        Me.GridLabelSheets.TabIndex = 1
        Me.GridLabelSheets.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'BtnAgregar
        '
        Me.BtnAgregar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAgregar.Image = CType(resources.GetObject("BtnAgregar.Image"), System.Drawing.Image)
        Me.BtnAgregar.Location = New System.Drawing.Point(559, 336)
        Me.BtnAgregar.Name = "BtnAgregar"
        Me.BtnAgregar.Size = New System.Drawing.Size(90, 37)
        Me.BtnAgregar.TabIndex = 12
        Me.BtnAgregar.Text = "&Agregar "
        Me.BtnAgregar.ToolTipText = "Agregar Nueva Plantilla"
        Me.BtnAgregar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'FrmMtoLabelSheet
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(656, 380)
        Me.Controls.Add(Me.GrpUnidades)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(553, 378)
        Me.Name = "FrmMtoLabelSheet"
        Me.Text = "Mantenimiento de Plantillas de Etiquetas"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GrpUnidades.ResumeLayout(False)
        CType(Me.GridLabelSheets, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private sLabelSheetSelected As String
    Private sNombre As String

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub FrmMtoLabelSheet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        Cursor.Current = Cursors.WaitCursor

        ModPOS.ActualizaGrid(True, Me.GridLabelSheets, "sp_consulta_labelsheet", Nothing)
        Me.GridLabelSheets.RootTable.Columns("ID").Visible = False
        Cursor.Current = Cursors.Default

    End Sub

    Private Sub GridLabelSheets_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridLabelSheets.SelectionChanged
        If Not GridLabelSheets.GetValue(0) Is Nothing Then
            Me.BtnModificar.Enabled = True
            Me.BtnEliminar.Enabled = True
            Me.sLabelSheetSelected = GridLabelSheets.GetValue(0)
            Me.sNombre = GridLabelSheets.GetValue("Nombre")

        Else
            Me.sLabelSheetSelected = ""
            Me.sNombre = ""

            Me.BtnModificar.Enabled = False
            Me.BtnEliminar.Enabled = False
        End If
    End Sub

    Private Sub BtnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregar.Click
        If ModPOS.LabelSheet Is Nothing Then
            ModPOS.LabelSheet = New FrmLabelSheet
            With ModPOS.LabelSheet
                .Text = "Agregar Plantilla"
                .StartPosition = FormStartPosition.CenterScreen
                .Padre = "Agregar"
                .ChkEstado.Enabled = False
            End With
        End If
        ModPOS.LabelSheet.StartPosition = FormStartPosition.CenterScreen
        ModPOS.LabelSheet.Show()
        ModPOS.LabelSheet.BringToFront()
    End Sub

    Private Sub BtnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnModificar.Click
        modificaPlantilla()
    End Sub

    Public Sub modificaPlantilla()
        If sLabelSheetSelected <> "" Then

            If ModPOS.LabelSheet Is Nothing Then

                ModPOS.LabelSheet = New FrmLabelSheet
                With ModPOS.LabelSheet
                    .Text = "Modificar Plantilla"
                    .StartPosition = FormStartPosition.CenterScreen
                    .Padre = "Modificar"

                    Dim dt As DataTable
                    dt = ModPOS.Recupera_Tabla("sp_recupera_labelsheet", "@IDSheet", Me.sLabelSheetSelected)

                    .IDSheet = dt.Rows(0)("IDSheet")
                    .Tipo = IIf(dt.Rows(0)("Tipo").GetType.Name = "DBNull", 0, dt.Rows(0)("Tipo"))
                    .Nombre = dt.Rows(0)("Nombre")
                    .AnchoPapel = dt.Rows(0)("AnchoPapel")
                    .AltoPapel = dt.Rows(0)("AltoPapel")
                    .mpSuperior = dt.Rows(0)("mpSuperior")
                    .mpInferior = dt.Rows(0)("mpInferior")
                    .mpIzquierdo = dt.Rows(0)("mpIzquierdo")
                    .mpDerecho = dt.Rows(0)("mpDerecho")
                    .Horizontal = dt.Rows(0)("Horizontal")
                    .Columnas = dt.Rows(0)("Columnas")
                    .Filas = dt.Rows(0)("Filas")
                    .EspacioColumna = dt.Rows(0)("EspacioColumna")
                    .EspacioFila = dt.Rows(0)("EspacioFila")
                    .AnchoEtiqueta = dt.Rows(0)("AnchoEtiqueta")
                    .AltoEtiqueta = dt.Rows(0)("AltoEtiqueta")
                    .meSuperior = dt.Rows(0)("meSuperior")
                    .meInferior = dt.Rows(0)("meInferior")
                    .meIzquierdo = dt.Rows(0)("meIzquierdo")
                    .meDerecho = dt.Rows(0)("meDerecho")
                    .TipoLetra = dt.Rows(0)("TipoLetra")
                    .SizeLetra = dt.Rows(0)("SizeLetra")
                    .SizeCodigo = dt.Rows(0)("SizeCodigo")
                    .Estado = dt.Rows(0)("Estado")
                    dt.Dispose()

                End With
            End If

            ModPOS.LabelSheet.StartPosition = FormStartPosition.CenterScreen
            ModPOS.LabelSheet.Show()
            ModPOS.LabelSheet.BringToFront()
        End If
    End Sub

    Private Sub GridLabelSheets_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridLabelSheets.DoubleClick
        modificaPlantilla()
    End Sub

    Private Sub BtnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminar.Click
        If sLabelSheetSelected <> "" Then
            Beep()
            Select Case MessageBox.Show("Se eliminara la Plantilla: " & sNombre, "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Case DialogResult.Yes
                    ModPOS.Ejecuta("sp_elimina_labelsheet", "@IDSheet", sLabelSheetSelected, "@Usuario", ModPOS.UsuarioActual)
                    ModPOS.ActualizaGrid(True, Me.GridLabelSheets, "sp_consulta_labelsheet", Nothing)
                    Me.GridLabelSheets.RootTable.Columns("ID").Visible = False

            End Select
        End If
    End Sub

    Private Sub FrmMtoLabelSheet_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.MtoLabelSheet.Dispose()
        ModPOS.MtoLabelSheet = Nothing
    End Sub

End Class
