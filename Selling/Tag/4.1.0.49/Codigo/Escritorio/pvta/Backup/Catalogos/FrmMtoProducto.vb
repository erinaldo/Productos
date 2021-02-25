Public Class FrmMtoProducto
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
    Friend WithEvents GrpProductos As System.Windows.Forms.GroupBox
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnModificar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnEliminar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnAgregar As Janus.Windows.EditControls.UIButton
    Friend WithEvents GridProductos As Janus.Windows.GridEX.GridEX
    Friend WithEvents TreeViewClass As System.Windows.Forms.TreeView
    Friend WithEvents TxtBuscar As System.Windows.Forms.TextBox
    Friend WithEvents BtnEtiquetas As Janus.Windows.EditControls.UIButton
    Friend WithEvents cmbGrupo As Selling.StoreCombo
    Friend WithEvents Clock As System.Windows.Forms.Timer
    Friend WithEvents CmbCampo As Selling.StoreCombo
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMtoProducto))
        Me.GrpClas = New System.Windows.Forms.GroupBox
        Me.cmbGrupo = New Selling.StoreCombo
        Me.TreeViewClass = New System.Windows.Forms.TreeView
        Me.GrpProductos = New System.Windows.Forms.GroupBox
        Me.CmbCampo = New Selling.StoreCombo
        Me.TxtBuscar = New System.Windows.Forms.TextBox
        Me.GridProductos = New Janus.Windows.GridEX.GridEX
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton
        Me.BtnModificar = New Janus.Windows.EditControls.UIButton
        Me.BtnEliminar = New Janus.Windows.EditControls.UIButton
        Me.BtnAgregar = New Janus.Windows.EditControls.UIButton
        Me.BtnEtiquetas = New Janus.Windows.EditControls.UIButton
        Me.Clock = New System.Windows.Forms.Timer(Me.components)
        Me.GrpClas.SuspendLayout()
        Me.GrpProductos.SuspendLayout()
        CType(Me.GridProductos, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.GrpClas.Size = New System.Drawing.Size(216, 425)
        Me.GrpClas.TabIndex = 1
        Me.GrpClas.TabStop = False
        Me.GrpClas.Text = "Clasificaciones"
        '
        'cmbGrupo
        '
        Me.cmbGrupo.BackColor = System.Drawing.SystemColors.Window
        Me.cmbGrupo.Location = New System.Drawing.Point(7, 14)
        Me.cmbGrupo.Name = "cmbGrupo"
        Me.cmbGrupo.Size = New System.Drawing.Size(203, 21)
        Me.cmbGrupo.TabIndex = 8
        '
        'TreeViewClass
        '
        Me.TreeViewClass.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TreeViewClass.Location = New System.Drawing.Point(7, 37)
        Me.TreeViewClass.Name = "TreeViewClass"
        Me.TreeViewClass.Size = New System.Drawing.Size(203, 381)
        Me.TreeViewClass.TabIndex = 0
        '
        'GrpProductos
        '
        Me.GrpProductos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpProductos.Controls.Add(Me.CmbCampo)
        Me.GrpProductos.Controls.Add(Me.TxtBuscar)
        Me.GrpProductos.Controls.Add(Me.GridProductos)
        Me.GrpProductos.Location = New System.Drawing.Point(229, 0)
        Me.GrpProductos.Name = "GrpProductos"
        Me.GrpProductos.Size = New System.Drawing.Size(503, 425)
        Me.GrpProductos.TabIndex = 0
        Me.GrpProductos.TabStop = False
        Me.GrpProductos.Text = "Productos"
        '
        'CmbCampo
        '
        Me.CmbCampo.BackColor = System.Drawing.SystemColors.Window
        Me.CmbCampo.Location = New System.Drawing.Point(7, 15)
        Me.CmbCampo.Name = "CmbCampo"
        Me.CmbCampo.Size = New System.Drawing.Size(166, 21)
        Me.CmbCampo.TabIndex = 7
        '
        'TxtBuscar
        '
        Me.TxtBuscar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtBuscar.Location = New System.Drawing.Point(173, 15)
        Me.TxtBuscar.Name = "TxtBuscar"
        Me.TxtBuscar.Size = New System.Drawing.Size(324, 20)
        Me.TxtBuscar.TabIndex = 1
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
        Me.GridProductos.Location = New System.Drawing.Point(7, 37)
        Me.GridProductos.Name = "GridProductos"
        Me.GridProductos.RecordNavigator = True
        Me.GridProductos.Size = New System.Drawing.Size(490, 381)
        Me.GridProductos.TabIndex = 2
        Me.GridProductos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(258, 431)
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
        Me.BtnModificar.Location = New System.Drawing.Point(546, 431)
        Me.BtnModificar.Name = "BtnModificar"
        Me.BtnModificar.Size = New System.Drawing.Size(90, 37)
        Me.BtnModificar.TabIndex = 3
        Me.BtnModificar.Text = "&Modificar"
        Me.BtnModificar.ToolTipText = "Modificar producto seleccionado"
        Me.BtnModificar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnEliminar
        '
        Me.BtnEliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnEliminar.Image = CType(resources.GetObject("BtnEliminar.Image"), System.Drawing.Image)
        Me.BtnEliminar.Location = New System.Drawing.Point(354, 431)
        Me.BtnEliminar.Name = "BtnEliminar"
        Me.BtnEliminar.Size = New System.Drawing.Size(90, 37)
        Me.BtnEliminar.TabIndex = 4
        Me.BtnEliminar.Text = "&Eliminar"
        Me.BtnEliminar.ToolTipText = "Eliminar producto seleccionado"
        Me.BtnEliminar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnAgregar
        '
        Me.BtnAgregar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAgregar.Image = CType(resources.GetObject("BtnAgregar.Image"), System.Drawing.Image)
        Me.BtnAgregar.Location = New System.Drawing.Point(642, 431)
        Me.BtnAgregar.Name = "BtnAgregar"
        Me.BtnAgregar.Size = New System.Drawing.Size(90, 37)
        Me.BtnAgregar.TabIndex = 2
        Me.BtnAgregar.Text = "&Agregar "
        Me.BtnAgregar.ToolTipText = "Agregar nuevo producto"
        Me.BtnAgregar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnEtiquetas
        '
        Me.BtnEtiquetas.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnEtiquetas.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnEtiquetas.Icon = CType(resources.GetObject("BtnEtiquetas.Icon"), System.Drawing.Icon)
        Me.BtnEtiquetas.ImageSize = New System.Drawing.Size(28, 28)
        Me.BtnEtiquetas.Location = New System.Drawing.Point(450, 431)
        Me.BtnEtiquetas.Name = "BtnEtiquetas"
        Me.BtnEtiquetas.Size = New System.Drawing.Size(90, 37)
        Me.BtnEtiquetas.TabIndex = 18
        Me.BtnEtiquetas.Text = "&Etiquetas"
        Me.BtnEtiquetas.TextHorizontalAlignment = Janus.Windows.EditControls.TextAlignment.Near
        Me.BtnEtiquetas.ToolTipText = "Imprime etiquetas de código de barras del producto seleccionado"
        Me.BtnEtiquetas.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'Clock
        '
        Me.Clock.Interval = 500
        '
        'FrmMtoProducto
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(742, 473)
        Me.Controls.Add(Me.BtnEtiquetas)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.BtnModificar)
        Me.Controls.Add(Me.BtnEliminar)
        Me.Controls.Add(Me.BtnAgregar)
        Me.Controls.Add(Me.GrpProductos)
        Me.Controls.Add(Me.GrpClas)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(625, 464)
        Me.Name = "FrmMtoProducto"
        Me.Text = "Mantenimiento de Productos"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GrpClas.ResumeLayout(False)
        Me.GrpProductos.ResumeLayout(False)
        Me.GrpProductos.PerformLayout()
        CType(Me.GridProductos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region


    Private sProdSelected As String
    Private sNombre As String
    Private sClave As String

    Private dataSetArbol As Data.DataSet
    Private bCargado As Boolean = False

    Public Sub actualizaTree(ByVal Tipo As Integer)
        TreeViewClass.Nodes.Clear()
        dataSetArbol = ModPOS.recuperaTabla_DTS("sp_recupera_clasificacion", "Clasificacion", "@Tipo", 3, "Grupo", Tipo, "@COMClave", ModPOS.CompanyActual)
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

    Private Sub FrmMtoProducto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        'Me.Size = My.Computer.Screen.WorkingArea.Size
        'Me.Location = New System.Drawing.Point(0, 0)

        Cursor.Current = Cursors.WaitCursor


        With Me.cmbGrupo
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_grupo"
            .NombreParametro1 = "Tipo"
            .Parametro1 = "3"
            .llenar()
        End With

        actualizaTree(IIf(cmbGrupo.SelectedValue Is Nothing, 0, cmbGrupo.SelectedValue))

        With Me.CmbCampo
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Producto"
            .NombreParametro2 = "campo"
            .Parametro2 = "Filtro"
            .llenar()
        End With

        bCargado = True

        ModPOS.ActualizaGrid(True, Me.GridProductos, "sp_muestra_productos", "@Class", TreeViewClass.TopNode.Tag, "@COMClave", ModPOS.CompanyActual)
        Me.GridProductos.RootTable.Columns("ID").Visible = False

        Me.GridProductos.RootTable.Columns("Clave").Width = 70
        Me.GridProductos.RootTable.Columns("C. BARRAS").Width = 50
        Me.GridProductos.RootTable.Columns("Num. de Parte").Width = 40
        Me.GridProductos.RootTable.Columns("Nombre Comun").Width = 270
        Me.GridProductos.RootTable.Columns("Tipo").Width = 45
        Me.GridProductos.RootTable.Columns("Origen").Width = 10
        Me.GridProductos.RootTable.Columns("Costo Vigente").Width = 40
        Me.GridProductos.RootTable.Columns("Costo Vigente").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.GridProductos.RootTable.Columns("Estado").Width = 25

        Cursor.Current = Cursors.Default
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub FrmMtoProducto_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.MtoProductos.Dispose()
        ModPOS.MtoProductos = Nothing
    End Sub

    Private Sub GridProductos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridProductos.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.BtnModificar.PerformClick()
        End If
    End Sub

    Private Sub GridProductos_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridProductos.SelectionChanged
        If Not GridProductos.GetValue(0) Is Nothing Then
            Me.BtnModificar.Enabled = True
            Me.BtnEliminar.Enabled = True
            Me.sProdSelected = GridProductos.GetValue(0)
            Me.sNombre = GridProductos.GetValue(1)
            sClave = GridProductos.GetValue("Clave")
        Else
            Me.sProdSelected = ""
            Me.sNombre = ""
            sClave = ""
            Me.BtnModificar.Enabled = False
            Me.BtnEliminar.Enabled = False
        End If
    End Sub

    Private Sub BtnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregar.Click
        If ModPOS.Producto Is Nothing Then
            ModPOS.Producto = New FrmProducto
            With ModPOS.Producto
                .Text = "Agregar Producto"
                .StartPosition = FormStartPosition.CenterScreen
                .Padre = "Agregar"
                .UiTabCosto.Enabled = False
                .UiTabKits.Enabled = True
                .UiTabEquivalentes.Enabled = True
                .ChkEstado.Enabled = False
                .TxtClave.Focus()
            End With
        End If
        ModPOS.Producto.StartPosition = FormStartPosition.CenterScreen
        ModPOS.Producto.Show()
        ModPOS.Producto.BringToFront()
    End Sub

    Public Sub modificarProd()
        If sProdSelected <> "" Then

            If ModPOS.Producto Is Nothing Then

                ModPOS.Producto = New FrmProducto
                With ModPOS.Producto
                    .Text = "Modificar Producto"
                    .StartPosition = FormStartPosition.CenterScreen
                    .Padre = "Modificar"
                    .TxtClave.ReadOnly = True
                    '.CmbTipo.Enabled = False

                    Dim dt As DataTable
                    dt = ModPOS.Recupera_Tabla("sp_recupera_producto", "@PROClave", Me.sProdSelected)

                    .Costo = dt.Rows(0)("CostoVigente")
                    .PROClave = dt.Rows(0)("PROClave")
                    .Clave = dt.Rows(0)("Clave")
                    .NumParte = IIf(dt.Rows(0)("NumParte").GetType.Name = "DBNull", "", dt.Rows(0)("NumParte"))
                    .Nombre = dt.Rows(0)("Nombre")
                    .Descripcion = dt.Rows(0)("Descripcion")
                    .Tipo = dt.Rows(0)("TProducto")
                    .TOrigen = dt.Rows(0)("TOrigen")
                    .TRotacion = dt.Rows(0)("TRotacion")
                    .Estado = dt.Rows(0)("Estado")
                    .Seguimiento = dt.Rows(0)("Seguimiento")
                    .DiasGarantia = dt.Rows(0)("DiasGarantia")
                    .Minimo = dt.Rows(0)("Minimo")
                    .Maximo = dt.Rows(0)("Maximo")
                    .Reorden = dt.Rows(0)("Reorden")
                    .Marca = IIf(dt.Rows(0)("Marca").GetType.Name = "DBNull", 0, dt.Rows(0)("Marca"))
                    .Linea = IIf(dt.Rows(0)("Linea").GetType.Name = "DBNull", 0, dt.Rows(0)("Linea"))
                    .Sublinea = IIf(dt.Rows(0)("Sublinea").GetType.Name = "DBNull", 0, dt.Rows(0)("Sublinea"))
                    .NumDecimales = dt.Rows(0)("Num_Decimales")
                    .Nota = IIf(dt.Rows(0)("Nota").GetType.FullName = "System.DBNull", "", dt.Rows(0)("Nota"))
                    .CMIClave = IIf(dt.Rows(0)("CMIClave").GetType.FullName = "System.DBNull", "", dt.Rows(0)("CMIClave"))

                    .Pedimento = IIf(dt.Rows(0)("Pedimento").GetType.FullName = "System.DBNull", "", dt.Rows(0)("Pedimento"))
                    .Alterno1 = IIf(dt.Rows(0)("Alterno1").GetType.FullName = "System.DBNull", "", dt.Rows(0)("Alterno1"))
                    .Alterno2 = IIf(dt.Rows(0)("Alterno2").GetType.FullName = "System.DBNull", "", dt.Rows(0)("Alterno2"))
                    .Alterno3 = IIf(dt.Rows(0)("Alterno3").GetType.FullName = "System.DBNull", "", dt.Rows(0)("Alterno3"))
                    .Escala = IIf(dt.Rows(0)("Escala").GetType.FullName = "System.DBNull", 0, dt.Rows(0)("Escala"))
                    .KgLt = IIf(dt.Rows(0)("KgLt").GetType.FullName = "System.DBNull", 0, dt.Rows(0)("KgLt"))

                    .TImpuesto = IIf(dt.Rows(0)("TImpuesto").GetType.Name = "DBNull", 0, dt.Rows(0)("TImpuesto"))

                    dt.Dispose()
                    .UiTab1.Enabled = True
                    .TxtNumParte.Focus()
                End With
            End If

            ModPOS.Producto.StartPosition = FormStartPosition.CenterScreen
            ModPOS.Producto.Show()
            ModPOS.Producto.BringToFront()

        End If
    End Sub

    Private Sub BtnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnModificar.Click
        modificarProd()

    End Sub

    Private Sub GridProductos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridProductos.DoubleClick
        modificarProd()
    End Sub

    Private Sub BtnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminar.Click
        If sProdSelected <> "" Then
            Beep()
            Select Case MessageBox.Show("Se eliminara el Producto :" & sNombre, "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Case DialogResult.Yes

                    Dim dExistencia As Double

                    Dim dt As DataTable
                    dt = ModPOS.Recupera_Tabla("sp_recupera_existencia", "@PROClave", sProdSelected)
                    dExistencia = dt.Rows(0)("Existencia")
                    dt.Dispose()

                    If dExistencia <= 0 Then
                        ModPOS.Ejecuta("sp_elimina_prod", "@PROClave", sProdSelected, "@Usuario", ModPOS.UsuarioActual)

                        If Not TreeViewClass.SelectedNode Is Nothing Then
                            If Not TreeViewClass.SelectedNode.Tag Is Nothing Then
                                ModPOS.ActualizaGrid(True, Me.GridProductos, "sp_muestra_productos", "@Class", TreeViewClass.SelectedNode.Tag, "@COMClave", ModPOS.CompanyActual)
                                Me.GridProductos.RootTable.Columns("ID").Visible = False

                                Me.GridProductos.RootTable.Columns("Clave").Width = 70
                                Me.GridProductos.RootTable.Columns("C. BARRAS").Width = 50
                                Me.GridProductos.RootTable.Columns("Num. de Parte").Width = 40
                                Me.GridProductos.RootTable.Columns("Nombre Comun").Width = 270
                                Me.GridProductos.RootTable.Columns("Tipo").Width = 45
                                Me.GridProductos.RootTable.Columns("Origen").Width = 10
                                Me.GridProductos.RootTable.Columns("Costo Vigente").Width = 40
                                Me.GridProductos.RootTable.Columns("Costo Vigente").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
                                Me.GridProductos.RootTable.Columns("Estado").Width = 25


                            End If
                        End If
                    Else
                        MessageBox.Show("No es posible eliminar el producto debido a que tiene existencia en por lo menos un almacén o sucursal", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If

                Case DialogResult.No
            End Select
        End If
    End Sub

    Private Sub TxtBuscar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtBuscar.KeyDown
        Clock.Stop()
    End Sub

    Private Sub TxtBuscar_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtBuscar.KeyUp
        Clock.Start()
    End Sub

    Public Sub actGrid(ByVal tag As String)

        ModPOS.ActualizaGrid(True, Me.GridProductos, "sp_muestra_productos", "@Class", tag, "@COMClave", ModPOS.CompanyActual)
        Me.GridProductos.RootTable.Columns("ID").Visible = False

        Me.GridProductos.RootTable.Columns("Clave").Width = 70
        Me.GridProductos.RootTable.Columns("C. BARRAS").Width = 50
        Me.GridProductos.RootTable.Columns("Num. de Parte").Width = 40
        Me.GridProductos.RootTable.Columns("Nombre Comun").Width = 270
        Me.GridProductos.RootTable.Columns("Tipo").Width = 45
        Me.GridProductos.RootTable.Columns("Origen").Width = 10
        Me.GridProductos.RootTable.Columns("Costo Vigente").Width = 40
        Me.GridProductos.RootTable.Columns("Costo Vigente").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.GridProductos.RootTable.Columns("Estado").Width = 25

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

    Private Sub BtnEtiquetas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEtiquetas.Click
        If sProdSelected <> "" Then
            If ModPOS.PrintLabel Is Nothing Then
                ModPOS.PrintLabel = New FrmPrintLabel
                With ModPOS.PrintLabel
                    .StartPosition = FormStartPosition.CenterScreen
                    .Clave = sClave
                End With
            End If
            ModPOS.PrintLabel.StartPosition = FormStartPosition.CenterScreen
            ModPOS.PrintLabel.Show()
            ModPOS.PrintLabel.BringToFront()
        End If
    End Sub

    Private Sub cmbGrupo_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbGrupo.SelectedValueChanged
        If Not cmbGrupo.SelectedValue Is Nothing AndAlso bCargado = True Then

            actualizaTree(IIf(cmbGrupo.SelectedValue Is Nothing, 0, cmbGrupo.SelectedValue))

        End If
    End Sub

    Private Sub Clock_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Clock.Tick
        Clock.Stop()
        If Not CmbCampo.SelectedValue Is Nothing Then
            If TxtBuscar.Text <> "" Then
                ModPOS.ActualizaGrid(True, Me.GridProductos, "sp_busca_productos", "@Campo", CmbCampo.SelectedValue, "@Busca", TxtBuscar.Text.ToUpper.Trim.Replace("'", "''"), "@COMClave", ModPOS.CompanyActual)
                Me.GridProductos.RootTable.Columns("ID").Visible = False


                Me.GridProductos.RootTable.Columns("Clave").Width = 70
                Me.GridProductos.RootTable.Columns("C. BARRAS").Width = 50
                Me.GridProductos.RootTable.Columns("Num. de Parte").Width = 40
                Me.GridProductos.RootTable.Columns("Nombre Comun").Width = 270
                Me.GridProductos.RootTable.Columns("Tipo").Width = 45
                Me.GridProductos.RootTable.Columns("Origen").Width = 10
                Me.GridProductos.RootTable.Columns("Costo Vigente").Width = 40
                Me.GridProductos.RootTable.Columns("Costo Vigente").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
                Me.GridProductos.RootTable.Columns("Estado").Width = 25

            End If
        Else
            Beep()
            MessageBox.Show("¡No esta el filtro seleccionado!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub
End Class
