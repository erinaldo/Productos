Public Class FrmMtoProveedor
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
    Friend WithEvents GrpClas As System.Windows.Forms.GroupBox
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnModificar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnEliminar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnAgregar As Janus.Windows.EditControls.UIButton
    Friend WithEvents TreeViewClass As System.Windows.Forms.TreeView
    Friend WithEvents GrpProveedores As System.Windows.Forms.GroupBox
    Friend WithEvents BtnReimpresion As Janus.Windows.EditControls.UIButton
    Friend WithEvents CmbCampo As Selling.StoreCombo
    Friend WithEvents TxtBuscar As System.Windows.Forms.TextBox
    Friend WithEvents BtnListado As Janus.Windows.EditControls.UIButton
    Friend WithEvents cmbGrupo As Selling.StoreCombo
    Friend WithEvents GridProveedores As Janus.Windows.GridEX.GridEX
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMtoProveedor))
        Me.GrpClas = New System.Windows.Forms.GroupBox
        Me.TreeViewClass = New System.Windows.Forms.TreeView
        Me.GrpProveedores = New System.Windows.Forms.GroupBox
        Me.CmbCampo = New Selling.StoreCombo
        Me.TxtBuscar = New System.Windows.Forms.TextBox
        Me.GridProveedores = New Janus.Windows.GridEX.GridEX
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton
        Me.BtnModificar = New Janus.Windows.EditControls.UIButton
        Me.BtnEliminar = New Janus.Windows.EditControls.UIButton
        Me.BtnAgregar = New Janus.Windows.EditControls.UIButton
        Me.BtnReimpresion = New Janus.Windows.EditControls.UIButton
        Me.BtnListado = New Janus.Windows.EditControls.UIButton
        Me.cmbGrupo = New Selling.StoreCombo
        Me.GrpClas.SuspendLayout()
        Me.GrpProveedores.SuspendLayout()
        CType(Me.GridProveedores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpClas
        '
        Me.GrpClas.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GrpClas.Controls.Add(Me.cmbGrupo)
        Me.GrpClas.Controls.Add(Me.TreeViewClass)
        Me.GrpClas.Location = New System.Drawing.Point(7, 0)
        Me.GrpClas.Name = "GrpClas"
        Me.GrpClas.Size = New System.Drawing.Size(200, 425)
        Me.GrpClas.TabIndex = 0
        Me.GrpClas.TabStop = False
        Me.GrpClas.Text = "Clasificaciones"
        '
        'TreeViewClass
        '
        Me.TreeViewClass.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TreeViewClass.Location = New System.Drawing.Point(7, 36)
        Me.TreeViewClass.Name = "TreeViewClass"
        Me.TreeViewClass.Size = New System.Drawing.Size(186, 381)
        Me.TreeViewClass.TabIndex = 0
        '
        'GrpProveedores
        '
        Me.GrpProveedores.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpProveedores.Controls.Add(Me.CmbCampo)
        Me.GrpProveedores.Controls.Add(Me.TxtBuscar)
        Me.GrpProveedores.Controls.Add(Me.GridProveedores)
        Me.GrpProveedores.Location = New System.Drawing.Point(207, 0)
        Me.GrpProveedores.Name = "GrpProveedores"
        Me.GrpProveedores.Size = New System.Drawing.Size(531, 425)
        Me.GrpProveedores.TabIndex = 1
        Me.GrpProveedores.TabStop = False
        Me.GrpProveedores.Text = "Proveedores"
        '
        'CmbCampo
        '
        Me.CmbCampo.BackColor = System.Drawing.SystemColors.Window
        Me.CmbCampo.Location = New System.Drawing.Point(7, 14)
        Me.CmbCampo.Name = "CmbCampo"
        Me.CmbCampo.Size = New System.Drawing.Size(166, 21)
        Me.CmbCampo.TabIndex = 9
        '
        'TxtBuscar
        '
        Me.TxtBuscar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtBuscar.Location = New System.Drawing.Point(173, 14)
        Me.TxtBuscar.Name = "TxtBuscar"
        Me.TxtBuscar.Size = New System.Drawing.Size(352, 20)
        Me.TxtBuscar.TabIndex = 8
        '
        'GridProveedores
        '
        Me.GridProveedores.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridProveedores.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridProveedores.ColumnAutoResize = True
        Me.GridProveedores.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridProveedores.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridProveedores.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridProveedores.Location = New System.Drawing.Point(7, 36)
        Me.GridProveedores.Name = "GridProveedores"
        Me.GridProveedores.RecordNavigator = True
        Me.GridProveedores.Size = New System.Drawing.Size(518, 381)
        Me.GridProveedores.TabIndex = 2
        Me.GridProveedores.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(168, 431)
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
        Me.BtnModificar.ToolTipText = "Modificar proveedor seleccionado"
        Me.BtnModificar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnEliminar
        '
        Me.BtnEliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnEliminar.Image = CType(resources.GetObject("BtnEliminar.Image"), System.Drawing.Image)
        Me.BtnEliminar.Location = New System.Drawing.Point(264, 431)
        Me.BtnEliminar.Name = "BtnEliminar"
        Me.BtnEliminar.Size = New System.Drawing.Size(90, 37)
        Me.BtnEliminar.TabIndex = 4
        Me.BtnEliminar.Text = "&Eliminar"
        Me.BtnEliminar.ToolTipText = "Eliminar proveedor seleccionado"
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
        Me.BtnAgregar.ToolTipText = "Agregar nuevo proveedor"
        Me.BtnAgregar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnReimpresion
        '
        Me.BtnReimpresion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnReimpresion.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnReimpresion.Image = CType(resources.GetObject("BtnReimpresion.Image"), System.Drawing.Image)
        Me.BtnReimpresion.ImageSize = New System.Drawing.Size(28, 28)
        Me.BtnReimpresion.Location = New System.Drawing.Point(456, 431)
        Me.BtnReimpresion.Name = "BtnReimpresion"
        Me.BtnReimpresion.Size = New System.Drawing.Size(90, 37)
        Me.BtnReimpresion.TabIndex = 10
        Me.BtnReimpresion.Text = "&Edo. Cuenta"
        Me.BtnReimpresion.ToolTipText = "Impresión de Edo. Cta de proveedor seleccionado"
        Me.BtnReimpresion.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnListado
        '
        Me.BtnListado.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnListado.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnListado.Image = CType(resources.GetObject("BtnListado.Image"), System.Drawing.Image)
        Me.BtnListado.ImageSize = New System.Drawing.Size(28, 28)
        Me.BtnListado.Location = New System.Drawing.Point(360, 431)
        Me.BtnListado.Name = "BtnListado"
        Me.BtnListado.Size = New System.Drawing.Size(90, 37)
        Me.BtnListado.TabIndex = 12
        Me.BtnListado.Text = "&Listado"
        Me.BtnListado.ToolTipText = "Impresión de Listado de Clientes"
        Me.BtnListado.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'cmbGrupo
        '
        Me.cmbGrupo.BackColor = System.Drawing.SystemColors.Window
        Me.cmbGrupo.Location = New System.Drawing.Point(7, 14)
        Me.cmbGrupo.Name = "cmbGrupo"
        Me.cmbGrupo.Size = New System.Drawing.Size(186, 21)
        Me.cmbGrupo.TabIndex = 9
        '
        'FrmMtoProveedor
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(742, 473)
        Me.Controls.Add(Me.BtnListado)
        Me.Controls.Add(Me.BtnReimpresion)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.BtnModificar)
        Me.Controls.Add(Me.BtnEliminar)
        Me.Controls.Add(Me.BtnAgregar)
        Me.Controls.Add(Me.GrpProveedores)
        Me.Controls.Add(Me.GrpClas)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(625, 464)
        Me.Name = "FrmMtoProveedor"
        Me.Text = "Mantenimiento de Proveedores"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GrpClas.ResumeLayout(False)
        Me.GrpProveedores.ResumeLayout(False)
        Me.GrpProveedores.PerformLayout()
        CType(Me.GridProveedores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region


    Private sPrvSelected As String
    Private sNombre As String
    Private dSaldo As Double
    Private bCargado As Boolean = False
    Private dataSetArbol As Data.DataSet

    Public Sub actualizaTree(ByVal Tipo As Integer)
        TreeViewClass.Nodes.Clear()
        dataSetArbol = ModPOS.recuperaTabla_DTS("sp_recupera_clasificacion", "Clasificacion", "@Tipo", 2, "Grupo", Tipo, "@COMClave", ModPOS.CompanyActual)
        CrearNodosDelPadre(0, Nothing)
        Dim nuevoNodoSinClas As New TreeNode
        nuevoNodoSinClas.Text = "SIN CLASIFICACIÓN"
        nuevoNodoSinClas.Tag = "0"
        TreeViewClass.Nodes.Add(nuevoNodoSinClas)
        dataSetArbol.Dispose()


    End Sub

    Private Sub CrearNodosDelPadre(ByVal indicePadre As Integer, ByVal nodePadre As TreeNode)

        Dim dataViewHijos As DataView

        ' Crear un DataView con los Nodos que dependen del Nodo padre pasado como parámetro.
        dataViewHijos = New DataView(dataSetArbol.Tables("Clasificacion"))

        dataViewHijos.RowFilter = dataSetArbol.Tables("Clasificacion").Columns("IdentificadorPadre").ColumnName + " = " + indicePadre.ToString()

        ' Agregar al TreeView los nodos Hijos que se han obtenido en el DataView.
        For Each dataRowCurrent As DataRowView In dataViewHijos

            Dim nuevoNodo As New TreeNode
            nuevoNodo.Text = dataRowCurrent("NombreNodo").ToString().Trim()
            nuevoNodo.Tag = dataRowCurrent("IdentificadorNodo").ToString().Trim()
            ' si el parámetro nodoPadre es nulo es porque es la primera llamada, son los Nodos
            ' del primer nivel que no dependen de otro nodo.
            If nodePadre Is Nothing Then
                TreeViewClass.Nodes.Add(nuevoNodo)
            Else
                ' se añade el nuevo nodo al nodo padre.
                nodePadre.Nodes.Add(nuevoNodo)
            End If

            ' Llamada recurrente al mismo método para agregar los Hijos del Nodo recién agregado.
            CrearNodosDelPadre(Int32.Parse(dataRowCurrent("IdentificadorNodo").ToString()), nuevoNodo)
        Next dataRowCurrent



    End Sub

    Private Sub FrmMtoProveedor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        Cursor.Current = Cursors.WaitCursor

        With Me.CmbCampo
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Proveedor"
            .NombreParametro2 = "campo"
            .Parametro2 = "Filtro"
            .llenar()
        End With

        With Me.cmbGrupo
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_grupo"
            .NombreParametro1 = "Tipo"
            .Parametro1 = "2"
            .llenar()
        End With

        actualizaTree(IIf(cmbGrupo.SelectedValue Is Nothing, 0, cmbGrupo.SelectedValue))


        ModPOS.ActualizaGrid(True, Me.GridProveedores, "sp_muestra_proveedores", "@Class", TreeViewClass.TopNode.Tag, "@COMClave", ModPOS.CompanyActual)
        Me.GridProveedores.RootTable.Columns("ID").Visible = False
        Cursor.Current = Cursors.Default

        bCargado = True

    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub FrmMtoProveedor_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.MtoProveedor.Dispose()
        ModPOS.MtoProveedor = Nothing
    End Sub

    Private Sub GridProveedores_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridProveedores.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.BtnModificar.PerformClick()
        End If
    End Sub

    Private Sub GridProveedores_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridProveedores.SelectionChanged
        If Not GridProveedores.GetValue(0) Is Nothing Then
            Me.BtnModificar.Enabled = True
            Me.sPrvSelected = GridProveedores.GetValue(0)
            Me.sNombre = GridProveedores.GetValue(1)
            Me.dSaldo = GridProveedores.GetValue("Saldo")

            If sPrvSelected = GridProveedores.GetValue("Clave") Then
                Me.BtnEliminar.Enabled = False
            Else
                Me.BtnEliminar.Enabled = True
            End If
        Else
            Me.sPrvSelected = ""
            Me.sNombre = ""
            Me.dSaldo = 0
            Me.BtnModificar.Enabled = False
            Me.BtnEliminar.Enabled = False
        End If
    End Sub

    Private Sub BtnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregar.Click
        If ModPOS.Proveedor Is Nothing Then
            ModPOS.Proveedor = New FrmProveedor
            With ModPOS.Proveedor
                .Text = "Agregar Proveedor"
                .StartPosition = FormStartPosition.CenterScreen
                .Padre = "Agregar"
                .UiTabSaldos.Enabled = False
            End With
        End If
        ModPOS.Proveedor.StartPosition = FormStartPosition.CenterScreen
        ModPOS.Proveedor.Show()
        ModPOS.Proveedor.BringToFront()
    End Sub

    Public Sub modificarProd()
        If sPrvSelected <> "" Then
            If ModPOS.Proveedor Is Nothing Then
                ModPOS.Proveedor = New FrmProveedor
                With ModPOS.Proveedor
                    .Text = "Modificar Proveedor"
                    .StartPosition = FormStartPosition.CenterScreen
                    .Padre = "Modificar"
                    .TxtClave.ReadOnly = True

                    Dim dt As DataTable
                    dt = ModPOS.Recupera_Tabla("sp_recupera_proveedor", "@PRVClave", Me.sPrvSelected)

                    .PRVClave = dt.Rows(0)("PRVClave")
                    .Clave = dt.Rows(0)("Clave")
                    .FechaReg = dt.Rows(0)("FechaRegistro")
                    .NombreCorto = dt.Rows(0)("NombreCorto")
                    .RazonSocial = dt.Rows(0)("RazonSocial")
                    .RFC = dt.Rows(0)("id_Fiscal")
                    .LCredito = dt.Rows(0)("LimiteCredito")
                    .DiasCredito = dt.Rows(0)("DiasCredito")
                    .DiasEntrega = dt.Rows(0)("DiasEntrega")
                    .Saldo = dt.Rows(0)("Saldo")
                    .Contacto = dt.Rows(0)("Contacto")
                    .Tel1 = dt.Rows(0)("Tel1")
                    .Tel2 = dt.Rows(0)("Tel2")
                    .email = dt.Rows(0)("Email")
                    .Estado = dt.Rows(0)("Estado")
                    .CreditoDisponible = dt.Rows(0)("Disponible")
                    .PaisF = dt.Rows(0)("Pais")
                    .EstadoF = dt.Rows(0)("Entidad")
                    .MnpioF = dt.Rows(0)("Municipio")
                    .Colonia = dt.Rows(0)("Colonia")
                    .CalleF = dt.Rows(0)("Calle")
                    .Referencia = dt.Rows(0)("referencia")
                    .Localidad = dt.Rows(0)("Localidad")
                    .CodigoPostal = dt.Rows(0)("codigoPostal")
                    .noExterior = dt.Rows(0)("noExterior")
                    .noInterior = dt.Rows(0)("noInterior")
                    .TImpuesto = dt.Rows(0)("TImpuesto")
                    .CURP = dt.Rows(0)("CURP")
                    .CtaContable = IIf(dt.Rows(0)("CtaContable").GetType.Name = "DBNull", "", dt.Rows(0)("CtaContable"))
                    .NoCliente = IIf(dt.Rows(0)("NoCliente").GetType.Name = "DBNull", "", dt.Rows(0)("NoCliente"))
                    .ProveedorSAP = IIf(dt.Rows(0)("ProveedorSAP").GetType.Name = "DBNull", "", dt.Rows(0)("ProveedorSAP"))

                    dt.Dispose()

                End With
            End If

            ModPOS.Proveedor.StartPosition = FormStartPosition.CenterScreen
            ModPOS.Proveedor.Show()
            ModPOS.Proveedor.BringToFront()

        End If
    End Sub

    Private Sub BtnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnModificar.Click
        modificarProd()

    End Sub

    Private Sub GridProductos_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridProveedores.DoubleClick
        modificarProd()
    End Sub



    Private Sub BtnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminar.Click
        If sPrvSelected <> "" Then
            If dSaldo = 0 Then
                Beep()
                Select Case MessageBox.Show("Se eliminara el Proveedor :" & sNombre, "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                    Case DialogResult.Yes

                        ModPOS.Ejecuta("sp_elimina_prv", "@PRVClave", sPrvSelected, "@Usuario", ModPOS.UsuarioActual)

                        If Not TreeViewClass.SelectedNode.Tag Is Nothing Then

                            ModPOS.ActualizaGrid(True, Me.GridProveedores, "sp_muestra_proveedores", "@Class", TreeViewClass.SelectedNode.Tag, "@COMClave", ModPOS.CompanyActual)
                            Me.GridProveedores.RootTable.Columns("ID").Visible = False

                        End If
                    Case DialogResult.No

                End Select
            Else
                MessageBox.Show("No es posible eliminar el proveedor selecionado ya que cuenta con saldo pendiente de cobro", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub BtnReimpresion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnReimpresion.Click
        If sPrvSelected <> "" Then
            Dim a As New MeFiltro
            a.ShowDialog()
            If a.DialogResult = DialogResult.OK Then
                Dim OpenReport As New Report
                Dim pvtaDataSet As New DataSet
                pvtaDataSet.DataSetName = "pvtaDataSet"
                pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_edoprv_enc", "@PRVClave", Me.sPrvSelected))
                pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_edoprv_detalle", "@PRVClave", Me.sPrvSelected, "@Inicial", CDate(a.FechaInicio), "@Final", CDate(a.FechaFinal)))
                pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_rango", "@Inicial", CDate(a.FechaInicio), "@Final", CDate(a.FechaFinal)))
                OpenReport.PrintPreview("Reporte de Estado de Cuenta del Proveedor", "CREdoPRV.rpt", pvtaDataSet, "")
            End If
        Else
            MessageBox.Show("¡No se ha seleccionado un Proveedor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub TxtBuscar_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtBuscar.KeyUp
        If Not CmbCampo.SelectedValue Is Nothing Then
            If TxtBuscar.Text <> "" Then
                ModPOS.ActualizaGrid(True, Me.GridProveedores, "sp_busca_proveedores", "@Campo", CmbCampo.SelectedValue, "@Busca", TxtBuscar.Text.ToUpper.Trim.Replace("'", "''"), "@COMClave", ModPOS.CompanyActual)
                Me.GridProveedores.RootTable.Columns("ID").Visible = False
            End If
        Else
            Beep()
            MessageBox.Show("¡No esta el filtro seleccionado!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Public Sub actGrid(ByVal tag As String)
        ModPOS.ActualizaGrid(True, Me.GridProveedores, "sp_muestra_proveedores", "@Class", tag, "@COMClave", ModPOS.CompanyActual)
        Me.GridProveedores.RootTable.Columns("ID").Visible = False
    End Sub

    Private Sub TreeViewClass_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TreeViewClass.KeyUp
        If e.KeyCode = Keys.Enter AndAlso Not TreeViewClass.SelectedNode.Tag Is Nothing Then
            actGrid(TreeViewClass.SelectedNode.Tag)
        End If
    End Sub

    Private Sub TreeViewClass_NodeMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles TreeViewClass.NodeMouseClick
        If Not e.Node.Tag Is Nothing Then
            actGrid(e.Node.Tag)
        End If
    End Sub

    Private Sub BtnListado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnListado.Click
        Dim a As New FiltroProveedor
        a.Titulo = "Listado de Proveedores"
        a.ShowDialog()
        If a.DialogResult = DialogResult.OK Then
            Dim OpenReport As New Report
            Dim pvtaDataSet As New DataSet
            pvtaDataSet.DataSetName = "reportDataSet"
            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_listadoproveedor", "@Proveedor", a.Proveedor))
            OpenReport.PrintPreview("Reporte de Listado de Proveedores", "CRListadoPrv.rpt", pvtaDataSet, "")
        End If
    End Sub

    Private Sub cmbGrupo_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbGrupo.SelectedValueChanged
        If Not cmbGrupo.SelectedValue Is Nothing AndAlso bCargado = True Then

            actualizaTree(IIf(cmbGrupo.SelectedValue Is Nothing, 0, cmbGrupo.SelectedValue))

        End If
    End Sub
End Class
