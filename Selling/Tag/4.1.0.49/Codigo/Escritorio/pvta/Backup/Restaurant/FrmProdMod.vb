Public Class FrmProdMod
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
    Friend WithEvents BtnEliminar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnAgregar As Janus.Windows.EditControls.UIButton
    Friend WithEvents GrpProductos As System.Windows.Forms.GroupBox
    Friend WithEvents GridProductos As Janus.Windows.GridEX.GridEX
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmProdMod))
        Me.BtnEliminar = New Janus.Windows.EditControls.UIButton
        Me.BtnAgregar = New Janus.Windows.EditControls.UIButton
        Me.GrpProductos = New System.Windows.Forms.GroupBox
        Me.GridProductos = New Janus.Windows.GridEX.GridEX
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton
        Me.GrpProductos.SuspendLayout()
        CType(Me.GridProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnEliminar
        '
        Me.BtnEliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnEliminar.Image = CType(resources.GetObject("BtnEliminar.Image"), System.Drawing.Image)
        Me.BtnEliminar.Location = New System.Drawing.Point(495, 322)
        Me.BtnEliminar.Name = "BtnEliminar"
        Me.BtnEliminar.Size = New System.Drawing.Size(90, 37)
        Me.BtnEliminar.TabIndex = 20
        Me.BtnEliminar.Text = "&Eliminar"
        Me.BtnEliminar.ToolTipText = "Eliminar"
        Me.BtnEliminar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnAgregar
        '
        Me.BtnAgregar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAgregar.Image = CType(resources.GetObject("BtnAgregar.Image"), System.Drawing.Image)
        Me.BtnAgregar.Location = New System.Drawing.Point(591, 322)
        Me.BtnAgregar.Name = "BtnAgregar"
        Me.BtnAgregar.Size = New System.Drawing.Size(90, 37)
        Me.BtnAgregar.TabIndex = 19
        Me.BtnAgregar.Text = "&Agregar "
        Me.BtnAgregar.ToolTipText = "Agregar"
        Me.BtnAgregar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GrpProductos
        '
        Me.GrpProductos.Controls.Add(Me.BtnCancelar)
        Me.GrpProductos.Controls.Add(Me.GridProductos)
        Me.GrpProductos.Controls.Add(Me.BtnEliminar)
        Me.GrpProductos.Controls.Add(Me.BtnAgregar)
        Me.GrpProductos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrpProductos.Location = New System.Drawing.Point(0, 0)
        Me.GrpProductos.Name = "GrpProductos"
        Me.GrpProductos.Size = New System.Drawing.Size(688, 365)
        Me.GrpProductos.TabIndex = 18
        Me.GrpProductos.TabStop = False
        Me.GrpProductos.Text = "Productos"
        '
        'GridProductos
        '
        Me.GridProductos.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridProductos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridProductos.ColumnAutoResize = True
        Me.GridProductos.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridProductos.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridProductos.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridProductos.Location = New System.Drawing.Point(7, 15)
        Me.GridProductos.Name = "GridProductos"
        Me.GridProductos.RecordNavigator = True
        Me.GridProductos.Size = New System.Drawing.Size(674, 301)
        Me.GridProductos.TabIndex = 2
        Me.GridProductos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(399, 322)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancelar.TabIndex = 21
        Me.BtnCancelar.Text = "&Salir"
        Me.BtnCancelar.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'FrmProdMod
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(688, 365)
        Me.Controls.Add(Me.GrpProductos)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(580, 364)
        Me.Name = "FrmProdMod"
        Me.GrpProductos.ResumeLayout(False)
        CType(Me.GridProductos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public MODClave As String = ""

    Private sProductoSelected As String = ""
    Private sClave As String = ""
    Private dtProductos As DataTable


    Public Sub ActualizaGrid()

        dtProductos = ModPOS.Recupera_Tabla("sp_muestra_prodmod", "@MODClave", MODClave)
        GridProductos.DataSource = dtProductos
        GridProductos.RetrieveStructure(True)
        GridProductos.GroupByBoxVisible = False
        GridProductos.RootTable.Columns("PROClave").Visible = False
    End Sub


    Private Sub FrmProdMod_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ActualizaGrid()
    End Sub

    Private Sub FrmProdMod_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.ProdMod.Dispose()
        ModPOS.ProdMod = Nothing
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub BtnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminar.Click
        If sProductoSelected <> "" Then
            Beep()
            Select Case MessageBox.Show("Se removera el producto con clave:" & sClave & " del modificador actual", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Case DialogResult.Yes

                    Dim foundRows() As System.Data.DataRow
                    foundRows = dtProductos.Select("PROClave Like '" & sProductoSelected & "'")

                    If foundRows.Length <> 0 Then
                        ModPOS.Ejecuta("sp_elimina_prodmod", "@PROClave", foundRows(0)("PROClave"), "@MODClave", MODClave)
                        foundRows(0).Delete()
                    End If
            End Select
        End If
    End Sub

    Private Sub BtnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregar.Click
        If ModPOS.AddProdMod Is Nothing Then
            ModPOS.AddProdMod = New FrmAddProdMod
            With ModPOS.AddProdMod
                .Text = "Agregar productos al Modificador"
                .StartPosition = FormStartPosition.CenterScreen
                .MODClave = MODClave
            End With
        End If
        ModPOS.AddProdMod.StartPosition = FormStartPosition.CenterScreen
        ModPOS.AddProdMod.Show()
        ModPOS.AddProdMod.BringToFront()

    End Sub

    Private Sub GridProductos_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridProductos.SelectionChanged
        If Not Me.GridProductos.GetValue(0) Is Nothing Then
            Me.BtnEliminar.Enabled = True
            Me.sProductoSelected = GridProductos.GetValue("PROClave")
            Me.sClave = GridProductos.GetValue("Clave")
        Else
            Me.sProductoSelected = ""
            Me.sClave = ""
            Me.BtnEliminar.Enabled = False
        End If
    End Sub
End Class
