Public Class FrmLiberarPOS
    Inherits System.Windows.Forms.Form
    Private sSUCClave As String
    Private sPOSSelected As String
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents CmbSucursal As Selling.StoreCombo
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Private sReferencia As String
    Private bload As Boolean = False

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
    Friend WithEvents BtnModificar As Janus.Windows.EditControls.UIButton
    Friend WithEvents GrpLiberarPOS As System.Windows.Forms.GroupBox
    Friend WithEvents GridPOS As Janus.Windows.GridEX.GridEX
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmLiberarPOS))
        Me.GrpLiberarPOS = New System.Windows.Forms.GroupBox()
        Me.CmbSucursal = New Selling.StoreCombo()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.GridPOS = New Janus.Windows.GridEX.GridEX()
        Me.BtnModificar = New Janus.Windows.EditControls.UIButton()
        Me.GrpLiberarPOS.SuspendLayout()
        CType(Me.GridPOS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpLiberarPOS
        '
        Me.GrpLiberarPOS.Controls.Add(Me.CmbSucursal)
        Me.GrpLiberarPOS.Controls.Add(Me.Label1)
        Me.GrpLiberarPOS.Controls.Add(Me.BtnCancelar)
        Me.GrpLiberarPOS.Controls.Add(Me.GridPOS)
        Me.GrpLiberarPOS.Controls.Add(Me.BtnModificar)
        Me.GrpLiberarPOS.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrpLiberarPOS.Location = New System.Drawing.Point(0, 0)
        Me.GrpLiberarPOS.Name = "GrpLiberarPOS"
        Me.GrpLiberarPOS.Size = New System.Drawing.Size(784, 561)
        Me.GrpLiberarPOS.TabIndex = 0
        Me.GrpLiberarPOS.TabStop = False
        Me.GrpLiberarPOS.Text = "Puntos de Venta"
        '
        'CmbSucursal
        '
        Me.CmbSucursal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmbSucursal.BackColor = System.Drawing.SystemColors.Window
        Me.CmbSucursal.Location = New System.Drawing.Point(59, 15)
        Me.CmbSucursal.Name = "CmbSucursal"
        Me.CmbSucursal.Size = New System.Drawing.Size(507, 21)
        Me.CmbSucursal.TabIndex = 38
        '
        'Label1
        '
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(4, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 14)
        Me.Label1.TabIndex = 37
        Me.Label1.Text = "Sucursal"
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Icon = CType(resources.GetObject("BtnCancelar.Icon"), System.Drawing.Icon)
        Me.BtnCancelar.Location = New System.Drawing.Point(592, 525)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 30)
        Me.BtnCancelar.TabIndex = 5
        Me.BtnCancelar.Text = "&Salir"
        Me.BtnCancelar.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GridPOS
        '
        Me.GridPOS.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridPOS.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridPOS.ColumnAutoResize = True
        Me.GridPOS.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridPOS.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridPOS.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridPOS.Location = New System.Drawing.Point(7, 42)
        Me.GridPOS.Name = "GridPOS"
        Me.GridPOS.RecordNavigator = True
        Me.GridPOS.Size = New System.Drawing.Size(771, 477)
        Me.GridPOS.TabIndex = 0
        Me.GridPOS.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'BtnModificar
        '
        Me.BtnModificar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnModificar.Icon = CType(resources.GetObject("BtnModificar.Icon"), System.Drawing.Icon)
        Me.BtnModificar.Location = New System.Drawing.Point(688, 525)
        Me.BtnModificar.Name = "BtnModificar"
        Me.BtnModificar.Size = New System.Drawing.Size(90, 30)
        Me.BtnModificar.TabIndex = 2
        Me.BtnModificar.Text = "&Liberar"
        Me.BtnModificar.ToolTipText = "Liberar Punto de Venta"
        Me.BtnModificar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'FrmLiberarPOS
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(784, 561)
        Me.Controls.Add(Me.GrpLiberarPOS)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(500, 305)
        Me.Name = "FrmLiberarPOS"
        Me.Text = "Liberar Punto de Venta"
        Me.GrpLiberarPOS.ResumeLayout(False)
        CType(Me.GridPOS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub FrmLiberarPOS_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.LiberaPOS.Dispose()
        ModPOS.LiberaPOS = Nothing
    End Sub

    Public Sub refrescaGrid()

        If CmbSucursal.SelectedValue Is Nothing Then
            sSUCClave = ""
        Else
            sSUCClave = CmbSucursal.SelectedValue
        End If

        ModPOS.ActualizaGrid(False, GridPOS, "st_recupera_pdv", "@SUCClave", sSUCClave)
        Me.GridPOS.RootTable.Columns("PDVClave").Visible = False
       
    End Sub

    Private Sub FrmLiberarPOS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' 'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)

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

        bload = True
        refrescaGrid()
    End Sub

    Private Sub BtnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnModificar.Click
        Modificar()
    End Sub

    Private Sub GridPOS_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridPOS.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.BtnModificar.PerformClick()
        End If
    End Sub

    Private Sub GridPOS_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridPOS.SelectionChanged
        If Not Me.GridPOS.GetValue(0) Is Nothing Then
            sPOSSelected = Me.GridPOS.GetValue("PDVClave")
            sReferencia = Me.GridPOS.GetValue("Referencia")
            ModPOS.LiberaPOS.BtnModificar.Enabled = True
          
        Else
            sPOSSelected = ""
            sReferencia = ""
            ModPOS.LiberaPOS.BtnModificar.Enabled = False
        End If
    End Sub

    Private Sub GridAlmacen_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridPOS.DoubleClick
        Modificar()
    End Sub

     Private Sub Modificar()
        If Me.sPOSSelected <> "" Then
            Dim dt As DataTable
            Dim Fase As Integer
            dt = ModPOS.Recupera_Tabla("sp_recupera_pdv", "@PDV", Me.sPOSSelected)
            Fase = dt.Rows(0)("Fase")
            dt.Dispose()

            If Fase = 1 Then
                ModPOS.Ejecuta("sp_actualiza_fase", "@Clave", sPOSSelected, "@Tipo", 1)
                MessageBox.Show("El Punto de Venta ha sido liberado exitosamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Else
                MessageBox.Show("El Punto de Venta seleccionado no puede ser liberado debido a que su Fase actual ha sido modificada previamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            refrescaGrid()
        End If
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub CmbSucursal_SelectedValueChanged(sender As Object, e As EventArgs) Handles CmbSucursal.SelectedValueChanged
        If bLoad Then
            refrescaGrid()
        End If
    End Sub
End Class
