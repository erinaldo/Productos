Public Class FrmSugerido
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
    Friend WithEvents BtnAgregar As Janus.Windows.EditControls.UIButton
    Friend WithEvents TreeViewClass As System.Windows.Forms.TreeView
    Friend WithEvents GrpClientes As System.Windows.Forms.GroupBox
    Friend WithEvents GridProductos As Janus.Windows.GridEX.GridEX
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSugerido))
        Me.GrpClas = New System.Windows.Forms.GroupBox
        Me.TreeViewClass = New System.Windows.Forms.TreeView
        Me.GrpClientes = New System.Windows.Forms.GroupBox
        Me.GridProductos = New Janus.Windows.GridEX.GridEX
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton
        Me.BtnAgregar = New Janus.Windows.EditControls.UIButton
        Me.GrpClas.SuspendLayout()
        Me.GrpClientes.SuspendLayout()
        CType(Me.GridProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpClas
        '
        Me.GrpClas.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GrpClas.Controls.Add(Me.TreeViewClass)
        Me.GrpClas.Location = New System.Drawing.Point(7, 0)
        Me.GrpClas.Name = "GrpClas"
        Me.GrpClas.Size = New System.Drawing.Size(164, 425)
        Me.GrpClas.TabIndex = 0
        Me.GrpClas.TabStop = False
        Me.GrpClas.Text = "Portafolios"
        '
        'TreeViewClass
        '
        Me.TreeViewClass.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TreeViewClass.Location = New System.Drawing.Point(7, 15)
        Me.TreeViewClass.Name = "TreeViewClass"
        Me.TreeViewClass.Size = New System.Drawing.Size(152, 403)
        Me.TreeViewClass.TabIndex = 0
        '
        'GrpClientes
        '
        Me.GrpClientes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpClientes.Controls.Add(Me.GridProductos)
        Me.GrpClientes.Location = New System.Drawing.Point(171, 0)
        Me.GrpClientes.Name = "GrpClientes"
        Me.GrpClientes.Size = New System.Drawing.Size(567, 425)
        Me.GrpClientes.TabIndex = 1
        Me.GrpClientes.TabStop = False
        Me.GrpClientes.Text = "Productos"
        '
        'GridProductos
        '
        Me.GridProductos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridProductos.ColumnAutoResize = True
        Me.GridProductos.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridProductos.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridProductos.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridProductos.GroupByBoxVisible = False
        Me.GridProductos.Location = New System.Drawing.Point(7, 19)
        Me.GridProductos.Name = "GridProductos"
        Me.GridProductos.RecordNavigator = True
        Me.GridProductos.Size = New System.Drawing.Size(554, 399)
        Me.GridProductos.TabIndex = 2
        Me.GridProductos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(552, 430)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancelar.TabIndex = 5
        Me.BtnCancelar.Text = "&Salir"
        Me.BtnCancelar.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnAgregar
        '
        Me.BtnAgregar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAgregar.Image = CType(resources.GetObject("BtnAgregar.Image"), System.Drawing.Image)
        Me.BtnAgregar.Location = New System.Drawing.Point(648, 430)
        Me.BtnAgregar.Name = "BtnAgregar"
        Me.BtnAgregar.Size = New System.Drawing.Size(90, 37)
        Me.BtnAgregar.TabIndex = 2
        Me.BtnAgregar.Text = "&Agregar "
        Me.BtnAgregar.ToolTipText = "Agregar Productos"
        Me.BtnAgregar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'FrmSugerido
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(742, 473)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.BtnAgregar)
        Me.Controls.Add(Me.GrpClientes)
        Me.Controls.Add(Me.GrpClas)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(625, 464)
        Me.Name = "FrmSugerido"
        Me.Text = "Productos Sugeridos"
        Me.GrpClas.ResumeLayout(False)
        Me.GrpClientes.ResumeLayout(False)
        CType(Me.GridProductos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public ALMClave As String
    Public VENClave As String
    Public Picking As Boolean = False
    Public ListaPrecio As String
    Public dataSetPortafolio As Data.DataSet

    Private dtProductos As DataTable

    Private Sub ActualizaGrid(ByVal tag As String)
        If Not dtProductos Is Nothing Then
            dtProductos.Dispose()
        End If

        dtProductos = ModPOS.Recupera_Tabla("sp_muestra_sugerido", "@PORClave", tag, "@ALMClave", ALMClave, "@VENClave", VENClave)

        If Not dtProductos Is Nothing Then
            GridProductos.DataSource = dtProductos
            GridProductos.RetrieveStructure()
            '  GridClientes.AutoSizeColumns()
            GridProductos.RootTable.Columns("PROClave").Visible = False
            GridProductos.CurrentTable.Columns("Disp").Selectable = False
            GridProductos.CurrentTable.Columns("Sug").Selectable = False
            GridProductos.CurrentTable.Columns("Clave").Selectable = False
            GridProductos.CurrentTable.Columns("Nombre").Selectable = False
            Me.GridProductos.RootTable.Columns("Clave").Width = 50
            Me.GridProductos.RootTable.Columns("Disp").Width = 15
            Me.GridProductos.RootTable.Columns("Sug").Width = 15
            Me.GridProductos.RootTable.Columns("Cant").Width = 15
        End If
    End Sub

    Private Sub CrearNodos(ByVal dataSetArbol As DataSet)
        Dim dataViewHijos As DataView
        ' Crear un DataView con los Nodos que dependen del Nodo padre pasado como parámetro.
        dataViewHijos = New DataView(dataSetArbol.Tables("Portafolio"))
        ' dataViewHijos.RowFilter = dataSetArbol.Tables("Portafolio").Columns("PORClave").ColumnName + " = " + indicePadre.ToString()
        ' Agregar al TreeView los nodos Hijos que se han obtenido en el DataView.
        For Each dataRowCurrent As DataRowView In dataViewHijos
            Dim nuevoNodo As New TreeNode
            nuevoNodo.Text = dataRowCurrent("Descripcion").ToString().Trim()
            nuevoNodo.Tag = dataRowCurrent("PORClave").ToString().Trim()
            TreeViewClass.Nodes.Add(nuevoNodo)
        Next dataRowCurrent
    End Sub

    Private Sub FrmSugerido_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        Cursor.Current = Cursors.WaitCursor
        Me.CrearNodos(dataSetPortafolio)
        ActualizaGrid(TreeViewClass.TopNode.Tag)
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub


    Private Sub BtnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregar.Click
        If Not dtProductos Is Nothing AndAlso dtProductos.Rows.Count > 0 Then
            Dim foundRows() As DataRow
            foundRows = dtProductos.Select("Cant > 0")
            If foundRows.GetLength(0) > 0 Then
                Dim i As Integer
                Dim dt As DataTable
                For i = 0 To foundRows.GetUpperBound(0)
                    ' ModPOS.Promocion.addProductoPromocion(foundRows(i)("ID"), foundRows(i)("Clave").ToString, foundRows(i)("Nombre Comun"))
                    dt = ModPOS.SiExisteRecupera("sp_venta_producto", "@Tipo", 1, "@Busca", foundRows(i)("Clave"), "@ListaPrecio", ListaPrecio, "@Cantidad", foundRows(i)("Cant"))
                    ModPOS.Venta.AgregaPartida(dt)
                    dt.Dispose()
                Next
                Me.Close()
            Else
                MessageBox.Show("¡Debe indicar la cantidad de los productos que desea agregar!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If


    End Sub


    Private Sub TreeViewClass_NodeMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles TreeViewClass.NodeMouseClick
        If Not e.Node.Tag Is Nothing Then
            ActualizaGrid(e.Node.Tag)
        End If
    End Sub

    Private Sub GridProductos_CellEdited(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles GridProductos.CellEdited
        If GridProductos.CurrentColumn.Caption = "Cant" Then
            If IsNumeric(GridProductos.GetValue("Cant")) Then
                If GridProductos.GetValue("Cant") > 0 Then
                    If GridProductos.GetValue("Cant") > GridProductos.GetValue("Disp") AndAlso Picking = True Then
                        GridProductos.SetValue("Cant", GridProductos.GetValue("Disp"))
                    End If
                Else
                    GridProductos.SetValue("Cant", 1)
                End If
            Else
                GridProductos.SetValue("Cant", 1)
            End If
        End If

    End Sub
End Class
