Imports System.Data.SqlClient

Public Class FrmMtoEstructura
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
    Friend WithEvents GrpEstructuras As System.Windows.Forms.GroupBox
    Friend WithEvents BtnAgregar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnEliminar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnModificar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents LblAlmacen As System.Windows.Forms.Label
    Friend WithEvents GridEstructuras As Janus.Windows.GridEX.GridEX
    Friend WithEvents BtnEtiquetas As Janus.Windows.EditControls.UIButton
    Friend WithEvents CmbSucursal As Selling.StoreCombo
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CmbAlmacen As Selling.StoreCombo
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMtoEstructura))
        Me.GrpEstructuras = New System.Windows.Forms.GroupBox()
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.BtnEtiquetas = New Janus.Windows.EditControls.UIButton()
        Me.BtnEliminar = New Janus.Windows.EditControls.UIButton()
        Me.CmbAlmacen = New Selling.StoreCombo()
        Me.LblAlmacen = New System.Windows.Forms.Label()
        Me.BtnModificar = New Janus.Windows.EditControls.UIButton()
        Me.GridEstructuras = New Janus.Windows.GridEX.GridEX()
        Me.BtnAgregar = New Janus.Windows.EditControls.UIButton()
        Me.CmbSucursal = New Selling.StoreCombo()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GrpEstructuras.SuspendLayout()
        CType(Me.GridEstructuras, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpEstructuras
        '
        Me.GrpEstructuras.Controls.Add(Me.CmbSucursal)
        Me.GrpEstructuras.Controls.Add(Me.Label1)
        Me.GrpEstructuras.Controls.Add(Me.BtnCancelar)
        Me.GrpEstructuras.Controls.Add(Me.BtnEtiquetas)
        Me.GrpEstructuras.Controls.Add(Me.BtnEliminar)
        Me.GrpEstructuras.Controls.Add(Me.CmbAlmacen)
        Me.GrpEstructuras.Controls.Add(Me.LblAlmacen)
        Me.GrpEstructuras.Controls.Add(Me.BtnModificar)
        Me.GrpEstructuras.Controls.Add(Me.GridEstructuras)
        Me.GrpEstructuras.Controls.Add(Me.BtnAgregar)
        Me.GrpEstructuras.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrpEstructuras.Location = New System.Drawing.Point(0, 0)
        Me.GrpEstructuras.Name = "GrpEstructuras"
        Me.GrpEstructuras.Size = New System.Drawing.Size(656, 380)
        Me.GrpEstructuras.TabIndex = 0
        Me.GrpEstructuras.TabStop = False
        Me.GrpEstructuras.Text = "Estructuras"
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Icon = CType(resources.GetObject("BtnCancelar.Icon"), System.Drawing.Icon)
        Me.BtnCancelar.Location = New System.Drawing.Point(175, 337)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancelar.TabIndex = 7
        Me.BtnCancelar.Text = "&Salir"
        Me.BtnCancelar.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnEtiquetas
        '
        Me.BtnEtiquetas.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnEtiquetas.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnEtiquetas.Icon = CType(resources.GetObject("BtnEtiquetas.Icon"), System.Drawing.Icon)
        Me.BtnEtiquetas.ImageSize = New System.Drawing.Size(28, 28)
        Me.BtnEtiquetas.Location = New System.Drawing.Point(367, 337)
        Me.BtnEtiquetas.Name = "BtnEtiquetas"
        Me.BtnEtiquetas.Size = New System.Drawing.Size(90, 37)
        Me.BtnEtiquetas.TabIndex = 21
        Me.BtnEtiquetas.Text = "&Etiquetas"
        Me.BtnEtiquetas.TextHorizontalAlignment = Janus.Windows.EditControls.TextAlignment.Near
        Me.BtnEtiquetas.ToolTipText = "Imprime etiquetas de código de barras de las ubicaciones"
        Me.BtnEtiquetas.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnEliminar
        '
        Me.BtnEliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnEliminar.Icon = CType(resources.GetObject("BtnEliminar.Icon"), System.Drawing.Icon)
        Me.BtnEliminar.Location = New System.Drawing.Point(271, 337)
        Me.BtnEliminar.Name = "BtnEliminar"
        Me.BtnEliminar.Size = New System.Drawing.Size(90, 37)
        Me.BtnEliminar.TabIndex = 4
        Me.BtnEliminar.Text = "&Eliminar"
        Me.BtnEliminar.ToolTipText = "Elimina la estructura seleccionada"
        Me.BtnEliminar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'CmbAlmacen
        '
        Me.CmbAlmacen.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmbAlmacen.Location = New System.Drawing.Point(383, 19)
        Me.CmbAlmacen.Name = "CmbAlmacen"
        Me.CmbAlmacen.Size = New System.Drawing.Size(266, 21)
        Me.CmbAlmacen.TabIndex = 20
        '
        'LblAlmacen
        '
        Me.LblAlmacen.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblAlmacen.Location = New System.Drawing.Point(330, 22)
        Me.LblAlmacen.Name = "LblAlmacen"
        Me.LblAlmacen.Size = New System.Drawing.Size(84, 22)
        Me.LblAlmacen.TabIndex = 8
        Me.LblAlmacen.Text = "Almacén"
        '
        'BtnModificar
        '
        Me.BtnModificar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnModificar.Icon = CType(resources.GetObject("BtnModificar.Icon"), System.Drawing.Icon)
        Me.BtnModificar.Location = New System.Drawing.Point(463, 337)
        Me.BtnModificar.Name = "BtnModificar"
        Me.BtnModificar.Size = New System.Drawing.Size(90, 37)
        Me.BtnModificar.TabIndex = 5
        Me.BtnModificar.Text = "&Modificar"
        Me.BtnModificar.ToolTipText = "Modifica la estructura seleccionada"
        Me.BtnModificar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GridEstructuras
        '
        Me.GridEstructuras.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridEstructuras.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridEstructuras.ColumnAutoResize = True
        Me.GridEstructuras.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridEstructuras.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridEstructuras.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridEstructuras.Location = New System.Drawing.Point(7, 46)
        Me.GridEstructuras.Name = "GridEstructuras"
        Me.GridEstructuras.RecordNavigator = True
        Me.GridEstructuras.Size = New System.Drawing.Size(642, 285)
        Me.GridEstructuras.TabIndex = 2
        Me.GridEstructuras.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'BtnAgregar
        '
        Me.BtnAgregar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAgregar.Icon = CType(resources.GetObject("BtnAgregar.Icon"), System.Drawing.Icon)
        Me.BtnAgregar.Location = New System.Drawing.Point(559, 337)
        Me.BtnAgregar.Name = "BtnAgregar"
        Me.BtnAgregar.Size = New System.Drawing.Size(90, 37)
        Me.BtnAgregar.TabIndex = 3
        Me.BtnAgregar.Text = "&Nuevo"
        Me.BtnAgregar.ToolTipText = "Crear nueva estructura al almacén seleccionado"
        Me.BtnAgregar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'CmbSucursal
        '
        Me.CmbSucursal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmbSucursal.BackColor = System.Drawing.SystemColors.Window
        Me.CmbSucursal.Location = New System.Drawing.Point(55, 19)
        Me.CmbSucursal.Name = "CmbSucursal"
        Me.CmbSucursal.Size = New System.Drawing.Size(262, 21)
        Me.CmbSucursal.TabIndex = 40
        '
        'Label1
        '
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(7, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 14)
        Me.Label1.TabIndex = 39
        Me.Label1.Text = "Sucursal"
        '
        'FrmMtoEstructura
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(656, 380)
        Me.Controls.Add(Me.GrpEstructuras)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(553, 378)
        Me.Name = "FrmMtoEstructura"
        Me.Text = "Mantenimiento de Estructuras"
        Me.GrpEstructuras.ResumeLayout(False)
        CType(Me.GridEstructuras, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private sSeleccionado As String
    Private sNombreEst As String
    Private bLoad As Boolean = False

    Private Sub FrmMtoEstructura_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPos.MtoEstructura.Dispose()
        ModPos.MtoEstructura = Nothing
    End Sub

    Private Sub BtnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregar.Click
        If Not CmbAlmacen.SelectedValue Is Nothing Then
            If ModPOS.Almacen_Activo = CmbAlmacen.SelectedValue Then
                If ModPOS.Estructuras Is Nothing Then
                    ModPOS.Estructuras = New FrmEstructura
                    With ModPOS.Estructuras
                        .StartPosition = FormStartPosition.CenterScreen
                        .UiTabPageUbc.Enabled = False
                        .Text = "Nueva Estructura de Almacenaje"
                        .Padre = "Nuevo"
                        .MdiParent = ModPOS.Principal
                        .sAlmacen = CmbAlmacen.SelectedValue
                    End With
                End If
                With ModPOS.Estructuras
                    .StartPosition = FormStartPosition.CenterScreen
                    .Show()
                    .BringToFront()
                End With
            Else
                MessageBox.Show("No es posible crear una estructura en un almacén que se encuentra cerrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            MessageBox.Show("No se encuentro un almacén seleccionado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Public Sub refrescaGrid()

        Dim sALMClave As String

        If CmbAlmacen.SelectedValue Is Nothing Then
            sALMClave = ""
        Else
            sALMClave = CmbAlmacen.SelectedValue
        End If

        ModPOS.ActualizaGrid(True, GridEstructuras, "sp_muestra_estructuras", "@Almacen", sALMClave, "@Area", "Todos")
        Me.GridEstructuras.RootTable.Columns("ESTClave").Visible = False

    End Sub

    Private Sub FrmMtoEstructura_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
      
        With CmbSucursal
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_sucursal"
            .NombreParametro1 = "USRClave"
            .Parametro1 = ModPOS.UsuarioActual
            .NombreParametro2 = "COMClave"
            .Parametro2 = ModPOS.CompanyActual
            .llenar()
        End With

      
        If ModPOS.SucursalPredeterminada <> "" Then
            CmbSucursal.SelectedValue = ModPOS.SucursalPredeterminada
        End If

        With CmbAlmacen
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_almsuc"
            .NombreParametro1 = "SUCClave"
            .Parametro1 = CmbSucursal.SelectedValue
            .llenar()
        End With

        If ModPOS.AlmacenPredeterminado <> "" Then
            CmbAlmacen.SelectedValue = ModPOS.AlmacenPredeterminado
        End If

        bLoad = True

        refrescaGrid()
      
        If ModPOS.Superficie Is Nothing Then
            Me.BtnAgregar.Enabled = False
        End If

    End Sub

    Private Sub GridEstructuras_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridEstructuras.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.BtnModificar.PerformClick()
        End If
    End Sub

    Private Sub GridEstructuras_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridEstructuras.SelectionChanged
        If Not Me.GridEstructuras.GetValue(0) Is Nothing Then
            sSeleccionado = Me.GridEstructuras.GetValue("ESTClave")
            sNombreEst = Me.GridEstructuras.GetValue(1)
            ModPos.MtoEstructura.BtnModificar.Enabled = True
            ModPos.MtoEstructura.BtnEliminar.Enabled = True
        Else
            sSeleccionado = ""
            sNombreEst = ""
            ModPos.MtoEstructura.BtnModificar.Enabled = False
            ModPos.MtoEstructura.BtnEliminar.Enabled = False
        End If
    End Sub

    Private Sub BtnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnModificar.Click
        modificar()
    End Sub


    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()

    End Sub

    Private Sub GridEstructuras_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridEstructuras.DoubleClick
        modificar()

    End Sub

    Private Sub BtnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminar.Click
        Beep()
        Select Case MessageBox.Show("Se eliminara la estructura de almacenaje :" & sNombreEst, "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            Case DialogResult.Yes
                Dim Con As String = ModPOS.BDConexion
                If ModPOS.SiExite(Con, "sp_estructura_vacia", "@Estructura", sSeleccionado) <> 0 Then
                    MessageBox.Show("La estructura seleccionada no puede ser eliminada ya que existen ubicaciones ocupadas o apartadas", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else

                    ModPOS.Elimina_Estructura(sSeleccionado)
                    If Not ModPOS.Superficie Is Nothing Then
                        If ModPOS.Superficie.ALMClave = Me.CmbAlmacen.SelectedValue Then
                            Dim i As Integer = 0
                            While i <= ModPOS.numEst_Vector
                                If ModPOS.vector(i).Name = sSeleccionado Then
                                    ModPOS.vector(i).Visible = False
                                    ModPOS.Superficie.Refresh()
                                    Exit While
                                End If
                                i += 1
                            End While

                        End If
                    End If
                End If

                refrescaGrid()
            Case DialogResult.No
        End Select

    End Sub

    Private Sub modificar()
        If Me.sSeleccionado <> "" Then
            If ModPos.Estructuras Is Nothing Then
                Dim dt As DataTable
                dt = ModPOS.Recupera_Tabla("sp_recupera_est", "@Estructura", sSeleccionado)

                ModPos.Estructuras = New FrmEstructura

                With ModPos.Estructuras
                    .StartPosition = FormStartPosition.CenterScreen
                    .Padre = "Modificar"
                    .UiTabPageUbc.Enabled = True
                    .Text = "Modificar Estructura de Almacenaje"
                    .StartPosition = FormStartPosition.CenterScreen
                    .MdiParent = ModPos.Principal
                    .sAlmacen = dt.Rows(0)("ALMClave")

                    .Clave = dt.Rows(0)("ESTClave")
                    .ID = IIf(dt.Rows(0)("Clave").GetType.Name = "DBNull", dt.Rows(0)("ESTClave"), dt.Rows(0)("Clave"))
                    .sArea = IIf(dt.Rows(0)("AREClave").GetType.Name = "DBNull", "", dt.Rows(0)("AREClave"))
                    .iTESTClave = dt.Rows(0)("TESTClave")
                    .sColoca = IIf(dt.Rows(0)("PasilloColoca").GetType.Name = "DBNull", "", dt.Rows(0)("PasilloColoca"))
                    .sRecoge = IIf(dt.Rows(0)("PasilloRecoge").GetType.Name = "DBNull", "", dt.Rows(0)("PasilloRecoge"))
                    .iRotacion = dt.Rows(0)("TipoRotacion")
                    .dAlto = dt.Rows(0)("Alto")
                    .dLargo = dt.Rows(0)("Largo")
                    .dAncho = dt.Rows(0)("Ancho")
                    .dX = dt.Rows(0)("OrigenX")
                    .dY = dt.Rows(0)("OrigenY")
                    .iColumna = dt.Rows(0)("Columnas")
                    .iNiveles = dt.Rows(0)("Niveles")
                    .iformaEnvioInicial = IIf(dt.Rows(0)("formaEnvioInicial").GetType.Name <> "DBNull", dt.Rows(0)("formaEnvioInicial"), 0)
                    .iformaEnviofinal = IIf(dt.Rows(0)("formaEnvioFinal").GetType.Name <> "DBNull", dt.Rows(0)("formaEnvioFinal"), 99)

                    .iSecuenciaRecoleccion = IIf(dt.Rows(0)("SecuenciaRecoleccion").GetType.Name <> "DBNull", dt.Rows(0)("SecuenciaRecoleccion"), 0)

                    If dt.Rows(0)("Rotada") = 1 Then
                        .Rotada = True
                    Else
                        .Rotada = False
                    End If
                    .iColor = dt.Rows(0)("Color")
                    .Show()
                    .BringToFront()

                End With

                dt.Dispose()

            End If
            With ModPos.Estructuras
                .StartPosition = FormStartPosition.CenterScreen
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub BtnEtiquetas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEtiquetas.Click
        If Me.sSeleccionado <> "" Then
            Dim a As New FrmPrintLabelCode
            a.COMClave = Me.sSeleccionado
            a.iTipoDOc = 3
            a.ShowDialog()
            a.Dispose()
        Else
            MessageBox.Show("¡No se ha seleccionado una Estructura", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub CmbSucursal_SelectedValueChanged(sender As Object, e As EventArgs) Handles CmbSucursal.SelectedValueChanged
        If Not CmbSucursal.SelectedValue Is Nothing AndAlso bLoad Then

            With CmbAlmacen
                .Conexion = ModPOS.BDConexion
                .ProcedimientoAlmacenado = "sp_filtra_almsuc"
                .NombreParametro1 = "SUCClave"
                .Parametro1 = CmbSucursal.SelectedValue
                .llenar()
            End With

        End If

    End Sub

    Private Sub CmbAlmacen_SelectedValueChanged(sender As Object, e As EventArgs) Handles CmbAlmacen.SelectedValueChanged
        If bLoad AndAlso Not CmbAlmacen.SelectedValue Is Nothing Then
            refrescaGrid()
        End If
    End Sub
End Class
