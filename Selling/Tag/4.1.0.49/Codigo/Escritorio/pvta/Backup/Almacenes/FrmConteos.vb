Public Class FrmConteos
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
    Friend WithEvents GridProductos As Janus.Windows.GridEX.GridEX
    Friend WithEvents TreeViewClass As System.Windows.Forms.TreeView
    Friend WithEvents TxtBuscar As System.Windows.Forms.TextBox
    Friend WithEvents CmbTipo As Selling.StoreCombo
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CmbAlmacen As Selling.StoreCombo
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents ChkMarcaTodos As System.Windows.Forms.CheckBox
    Friend WithEvents BtnGuardar As Janus.Windows.EditControls.UIButton
    Friend WithEvents PBar As System.Windows.Forms.ProgressBar
    Friend WithEvents lblPorc As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CmbTipoConteo As Selling.StoreCombo
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents LblClave As System.Windows.Forms.Label
    Friend WithEvents TxtClave As System.Windows.Forms.TextBox
    Friend WithEvents cmbGrupo As Selling.StoreCombo
    Friend WithEvents CmbCampo As Selling.StoreCombo
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmConteos))
        Me.GrpClas = New System.Windows.Forms.GroupBox
        Me.TreeViewClass = New System.Windows.Forms.TreeView
        Me.GrpProductos = New System.Windows.Forms.GroupBox
        Me.LblClave = New System.Windows.Forms.Label
        Me.TxtClave = New System.Windows.Forms.TextBox
        Me.CmbTipoConteo = New Selling.StoreCombo
        Me.Label3 = New System.Windows.Forms.Label
        Me.lblPorc = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.PBar = New System.Windows.Forms.ProgressBar
        Me.BtnGuardar = New Janus.Windows.EditControls.UIButton
        Me.CmbTipo = New Selling.StoreCombo
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton
        Me.Label1 = New System.Windows.Forms.Label
        Me.CmbAlmacen = New Selling.StoreCombo
        Me.Label9 = New System.Windows.Forms.Label
        Me.ChkMarcaTodos = New System.Windows.Forms.CheckBox
        Me.CmbCampo = New Selling.StoreCombo
        Me.TxtBuscar = New System.Windows.Forms.TextBox
        Me.GridProductos = New Janus.Windows.GridEX.GridEX
        Me.cmbGrupo = New Selling.StoreCombo
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
        Me.GrpClas.Size = New System.Drawing.Size(216, 457)
        Me.GrpClas.TabIndex = 1
        Me.GrpClas.TabStop = False
        Me.GrpClas.Text = "Clasificaciones"
        '
        'TreeViewClass
        '
        Me.TreeViewClass.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TreeViewClass.Location = New System.Drawing.Point(7, 42)
        Me.TreeViewClass.Name = "TreeViewClass"
        Me.TreeViewClass.Size = New System.Drawing.Size(203, 408)
        Me.TreeViewClass.TabIndex = 0
        '
        'GrpProductos
        '
        Me.GrpProductos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpProductos.Controls.Add(Me.LblClave)
        Me.GrpProductos.Controls.Add(Me.TxtClave)
        Me.GrpProductos.Controls.Add(Me.CmbTipoConteo)
        Me.GrpProductos.Controls.Add(Me.Label3)
        Me.GrpProductos.Controls.Add(Me.lblPorc)
        Me.GrpProductos.Controls.Add(Me.Label2)
        Me.GrpProductos.Controls.Add(Me.PBar)
        Me.GrpProductos.Controls.Add(Me.BtnGuardar)
        Me.GrpProductos.Controls.Add(Me.CmbTipo)
        Me.GrpProductos.Controls.Add(Me.BtnCancelar)
        Me.GrpProductos.Controls.Add(Me.Label1)
        Me.GrpProductos.Controls.Add(Me.CmbAlmacen)
        Me.GrpProductos.Controls.Add(Me.Label9)
        Me.GrpProductos.Controls.Add(Me.ChkMarcaTodos)
        Me.GrpProductos.Controls.Add(Me.CmbCampo)
        Me.GrpProductos.Controls.Add(Me.TxtBuscar)
        Me.GrpProductos.Controls.Add(Me.GridProductos)
        Me.GrpProductos.Location = New System.Drawing.Point(229, 0)
        Me.GrpProductos.Name = "GrpProductos"
        Me.GrpProductos.Size = New System.Drawing.Size(558, 457)
        Me.GrpProductos.TabIndex = 0
        Me.GrpProductos.TabStop = False
        Me.GrpProductos.Text = "Productos"
        '
        'LblClave
        '
        Me.LblClave.Location = New System.Drawing.Point(8, 15)
        Me.LblClave.Name = "LblClave"
        Me.LblClave.Size = New System.Drawing.Size(71, 15)
        Me.LblClave.TabIndex = 126
        Me.LblClave.Text = "Clave"
        '
        'TxtClave
        '
        Me.TxtClave.Enabled = False
        Me.TxtClave.Location = New System.Drawing.Point(103, 12)
        Me.TxtClave.Name = "TxtClave"
        Me.TxtClave.Size = New System.Drawing.Size(153, 20)
        Me.TxtClave.TabIndex = 125
        '
        'CmbTipoConteo
        '
        Me.CmbTipoConteo.Location = New System.Drawing.Point(104, 85)
        Me.CmbTipoConteo.Name = "CmbTipoConteo"
        Me.CmbTipoConteo.Size = New System.Drawing.Size(197, 21)
        Me.CmbTipoConteo.TabIndex = 123
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(7, 87)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(102, 15)
        Me.Label3.TabIndex = 124
        Me.Label3.Text = "Forma de Contar"
        '
        'lblPorc
        '
        Me.lblPorc.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPorc.Location = New System.Drawing.Point(316, 430)
        Me.lblPorc.Name = "lblPorc"
        Me.lblPorc.Size = New System.Drawing.Size(37, 16)
        Me.lblPorc.TabIndex = 122
        Me.lblPorc.Text = "100 %"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.Location = New System.Drawing.Point(4, 430)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 16)
        Me.Label2.TabIndex = 121
        Me.Label2.Text = "Guardando"
        '
        'PBar
        '
        Me.PBar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PBar.Location = New System.Drawing.Point(73, 427)
        Me.PBar.Name = "PBar"
        Me.PBar.Size = New System.Drawing.Size(237, 21)
        Me.PBar.TabIndex = 120
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGuardar.Image = CType(resources.GetObject("BtnGuardar.Image"), System.Drawing.Image)
        Me.BtnGuardar.Location = New System.Drawing.Point(462, 414)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(90, 37)
        Me.BtnGuardar.TabIndex = 119
        Me.BtnGuardar.Text = "&Aceptar"
        Me.BtnGuardar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'CmbTipo
        '
        Me.CmbTipo.Location = New System.Drawing.Point(103, 60)
        Me.CmbTipo.Name = "CmbTipo"
        Me.CmbTipo.Size = New System.Drawing.Size(197, 21)
        Me.CmbTipo.TabIndex = 116
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(366, 414)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancelar.TabIndex = 5
        Me.BtnCancelar.Text = "&Salir"
        Me.BtnCancelar.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(7, 61)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(90, 15)
        Me.Label1.TabIndex = 117
        Me.Label1.Text = "Tipo de Conteo"
        '
        'CmbAlmacen
        '
        Me.CmbAlmacen.Location = New System.Drawing.Point(103, 35)
        Me.CmbAlmacen.Name = "CmbAlmacen"
        Me.CmbAlmacen.Size = New System.Drawing.Size(306, 21)
        Me.CmbAlmacen.TabIndex = 114
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(7, 38)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(72, 15)
        Me.Label9.TabIndex = 115
        Me.Label9.Text = "Almacén"
        '
        'ChkMarcaTodos
        '
        Me.ChkMarcaTodos.Enabled = False
        Me.ChkMarcaTodos.Location = New System.Drawing.Point(8, 132)
        Me.ChkMarcaTodos.Name = "ChkMarcaTodos"
        Me.ChkMarcaTodos.Size = New System.Drawing.Size(124, 19)
        Me.ChkMarcaTodos.TabIndex = 113
        Me.ChkMarcaTodos.Text = "Seleccionar Todos"
        '
        'CmbCampo
        '
        Me.CmbCampo.BackColor = System.Drawing.SystemColors.Window
        Me.CmbCampo.Location = New System.Drawing.Point(7, 110)
        Me.CmbCampo.Name = "CmbCampo"
        Me.CmbCampo.Size = New System.Drawing.Size(166, 21)
        Me.CmbCampo.TabIndex = 7
        '
        'TxtBuscar
        '
        Me.TxtBuscar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtBuscar.Location = New System.Drawing.Point(173, 110)
        Me.TxtBuscar.Name = "TxtBuscar"
        Me.TxtBuscar.Size = New System.Drawing.Size(379, 20)
        Me.TxtBuscar.TabIndex = 1
        '
        'GridProductos
        '
        Me.GridProductos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridProductos.ColumnAutoResize = True
        Me.GridProductos.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridProductos.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridProductos.GroupByBoxVisible = False
        Me.GridProductos.Location = New System.Drawing.Point(7, 153)
        Me.GridProductos.Name = "GridProductos"
        Me.GridProductos.RecordNavigator = True
        Me.GridProductos.Size = New System.Drawing.Size(545, 255)
        Me.GridProductos.TabIndex = 2
        Me.GridProductos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmbGrupo
        '
        Me.cmbGrupo.BackColor = System.Drawing.SystemColors.Window
        Me.cmbGrupo.Location = New System.Drawing.Point(6, 18)
        Me.cmbGrupo.Name = "cmbGrupo"
        Me.cmbGrupo.Size = New System.Drawing.Size(204, 21)
        Me.cmbGrupo.TabIndex = 9
        '
        'FrmConteos
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(792, 473)
        Me.Controls.Add(Me.GrpProductos)
        Me.Controls.Add(Me.GrpClas)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(667, 464)
        Me.Name = "FrmConteos"
        Me.Text = "Configurar Conteo"
        Me.GrpClas.ResumeLayout(False)
        Me.GrpProductos.ResumeLayout(False)
        Me.GrpProductos.PerformLayout()
        CType(Me.GridProductos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region


    Private sProdSelected As String
    Private sNombre As String
    Public Clave As String
    Private dtConteo As DataTable
    Public CONClave As String = ""
    Public Tipo As Integer
    Public TipoConteo As Integer
    Public Almacen As String
    Public Padre As String
    Private Cargado As Boolean = False

    Private dataSetArbol As Data.DataSet

    Private Sub ActualizaDetalle(ByVal Tipo As Integer)

        If Not dtConteo Is Nothing Then
            dtConteo.Dispose()
        End If

        If Tipo = 1 Then
            If TreeViewClass.SelectedNode Is Nothing Then
                dtConteo = ModPOS.Recupera_Tabla("sp_conteo_productos", "@Class", TreeViewClass.TopNode.Tag, "@CONClave", CONClave, "@ALMClave", Almacen)
            Else
                dtConteo = ModPOS.Recupera_Tabla("sp_conteo_productos", "@Class", TreeViewClass.SelectedNode.Tag, "@CONClave", CONClave, "@ALMClave", Almacen)
            End If
        Else
            dtConteo = ModPOS.Recupera_Tabla("sp_busca_prod_conteo", "@Campo", CmbCampo.SelectedValue, "@Busca", TxtBuscar.Text.ToUpper.Trim, "@CONClave", CONClave, "@ALMClave", Almacen)
        End If

        If dtConteo.Rows.Count > 0 Then

            GridProductos.DataSource = dtConteo
            GridProductos.RetrieveStructure()
            GridProductos.AutoSizeColumns()
            GridProductos.RootTable.Columns("ID").Visible = False
            GridProductos.RootTable.Columns("Origen").Visible = False
            GridProductos.RootTable.Columns("Exist").Visible = False
            GridProductos.RootTable.Columns("Fecha").Visible = False
            GridProductos.CurrentTable.Columns(3).Selectable = False
            GridProductos.CurrentTable.Columns(4).Selectable = False
            GridProductos.CurrentTable.Columns(5).Selectable = False
            GridProductos.CurrentTable.Columns(6).Selectable = False

            PBar.Value = 0
            lblPorc.Text = "0 %"
        End If
    End Sub

    Private Sub actualizaTree(ByVal Tipo As Integer)
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

    Private Sub FrmConteos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        Cursor.Current = Cursors.WaitCursor

        TxtClave.Text = Clave

        If Padre = "Nuevo" Then
            CONClave = ModPOS.obtenerLlave
        End If

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

        With CmbAlmacen
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_almacen"
            .NombreParametro1 = "USRClave"
            .Parametro1 = ModPOS.UsuarioActual
            .NombreParametro2 = "COMClave"
            .Parametro2 = ModPOS.CompanyActual
            .llenar()
        End With

        If ModPOS.AlmacenPredeterminado <> "" Then
            CmbAlmacen.SelectedValue = ModPOS.AlmacenPredeterminado
        End If

        With Me.CmbTipo
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Conteo"
            .NombreParametro2 = "campo"
            .Parametro2 = "Tipo"
            .llenar()
        End With


        With Me.CmbTipoConteo
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Conteo"
            .NombreParametro2 = "campo"
            .Parametro2 = "TipoConteo"
            .llenar()
        End With

        Cargado = True
        ActualizaDetalle(1)

        If Padre = "Modificar" Then
            CmbAlmacen.SelectedValue = Almacen
            CmbTipo.SelectedValue = Tipo
            CmbTipoConteo.SelectedValue = TipoConteo
            TxtClave.Enabled = False
        End If

        If CmbTipo.SelectedValue = 2 Then
            ChkMarcaTodos.Enabled = True
            GridProductos.Enabled = True
            TreeViewClass.Enabled = True

        Else
            ChkMarcaTodos.Enabled = False
            GridProductos.Enabled = False
            TreeViewClass.Enabled = False
        End If
        Cursor.Current = Cursors.Default

    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub FrmConteos_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If Not ModPOS.MtoConteo Is Nothing Then
            If Not ModPOS.MtoConteo.CmbAlmacen.SelectedValue Is Nothing AndAlso ModPOS.MtoConteo.Periodo > 0 AndAlso ModPOS.MtoConteo.Mes > 0 Then
                ModPOS.MtoConteo.ActualizarGrid()
            End If
        End If
        ModPOS.Conteo.Dispose()
        ModPOS.Conteo = Nothing
    End Sub

    Private Sub GridProductos_CellValueChanged(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles GridProductos.CellValueChanged
        PBar.Value = 0
        lblPorc.Text = "0 %"
    End Sub

    Private Sub GridProductos_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridProductos.SelectionChanged
        If Not GridProductos.GetValue(0) Is Nothing Then
            Me.sProdSelected = GridProductos.GetValue(0)
            Me.sNombre = GridProductos.GetValue(1)
        Else
            Me.sProdSelected = ""
            Me.sNombre = ""
        End If
    End Sub

    Private Sub TxtBuscar_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtBuscar.KeyUp
        If Not CmbCampo.SelectedValue Is Nothing Then
            If TxtBuscar.Text <> "" Then
                ActualizaDetalle(2)
            End If
        Else
            Beep()
            MessageBox.Show("¡No esta el filtro seleccionado!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub


    Private Sub insertaConteoDetalle()
        If Not dtConteo Is Nothing Then
            Dim foundRows() As DataRow
            foundRows = dtConteo.Select("Origen <> Marca")
            Cursor.Current = Cursors.WaitCursor
            If foundRows.GetLength(0) > 0 Then
                Dim i As Integer
                PBar.Maximum = foundRows.GetLength(0)
                PBar.Value = 0
                For i = 0 To foundRows.GetUpperBound(0)
                    If foundRows(i)("Marca") = True Then
                        ModPOS.Ejecuta("sp_actualiza_conteo_config", "@CONClave", CONClave, "@PROClave", foundRows(i)("ID"), "@Usuario", ModPOS.UsuarioActual, "@Tipo", 1, "@Existencia", foundRows(i)("Exist"), "@Fecha", foundRows(i)("Fecha"))
                        foundRows(i)("Origen") = True
                    Else
                        ModPOS.Ejecuta("sp_actualiza_conteo_config", "@CONClave", CONClave, "@PROClave", foundRows(i)("ID"), "@Usuario", ModPOS.UsuarioActual, "@Tipo", 2, "@Existencia", foundRows(i)("Exist"), "@Fecha", foundRows(i)("Fecha"))
                        foundRows(i)("Origen") = False
                    End If
                    PBar.Value = i + 1
                    lblPorc.Text = CStr(Redondear(((i + 1) * 100) / PBar.Maximum, 2)) & "%"
                    lblPorc.Refresh()
                Next
            End If
            Cursor.Current = Cursors.Default
        End If
    End Sub


    Private Sub BtnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click

        If Padre = "Nuevo" Then

            If TxtClave.Text = "" Then
                MessageBox.Show("Debe asignar una Clave que identifique al Conteo dentro del sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            ElseIf ModPOS.SiExite(ModPOS.BDConexion, "sp_valida_PK", "@tabla", "Conteo", "@clave", UCase(Trim(Me.TxtClave.Text)), "@COMClave", ModPOS.CompanyActual) > 0 Then
                MessageBox.Show("La Clave que intenta agregar ya existe en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If

            If CmbAlmacen.SelectedValue Is Nothing OrElse CmbTipo.SelectedValue Is Nothing OrElse CmbTipo.SelectedValue Is Nothing Then
                MessageBox.Show("¡Verifique que el Almacén, Tipo y Forma de conteo esten correctamente seleccionados!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            Else
                ModPOS.Ejecuta("sp_crea_conteo", "@CONClave", CONClave, "@Clave", TxtClave.Text.Trim.ToUpper, "@ALMClave", CmbAlmacen.SelectedValue, "@Usuario", ModPOS.UsuarioActual, "@Tipo", CmbTipo.SelectedValue, "@Forma", CmbTipoConteo.SelectedValue)

                Padre = "Modificar"

                If CmbTipo.SelectedValue = 1 And (CmbTipoConteo.SelectedValue = 1 OrElse CmbTipoConteo.SelectedValue = 2) Then
                    dtConteo = ModPOS.Recupera_Tabla("sp_obtener_conteodet", "@CONClave", CONClave, "@ALMClave", Almacen)
                    insertaConteoDetalle()
                    Close()
                End If

            End If

        End If

        If CmbTipo.SelectedValue = 2 Then
            insertaConteoDetalle()
        End If

    End Sub

    Private Sub ChkMarcaTodos_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkMarcaTodos.CheckedChanged
        If dtConteo.Rows.Count > 0 Then
            Dim i As Integer

            Cursor.Current = Cursors.WaitCursor
            If ChkMarcaTodos.Checked Then
                For i = 0 To dtConteo.Rows.Count - 1
                    dtConteo.Rows(i)("Marca") = True
                Next
            Else
                For i = 0 To dtConteo.Rows.Count - 1
                    dtConteo.Rows(i)("Marca") = False
                Next

            End If
            PBar.Value = 0
            lblPorc.Text = "0 %"
            Cursor.Current = Cursors.Default
        End If
    End Sub

    Private Sub CmbTipoConteo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbTipo.SelectedIndexChanged
        If Cargado = True AndAlso Not CmbTipo.SelectedValue Is Nothing Then
            If CmbTipo.SelectedValue = 2 Then
                ChkMarcaTodos.Enabled = True
                GridProductos.Enabled = True
                TreeViewClass.Enabled = True
            Else
                ChkMarcaTodos.Enabled = False
                GridProductos.Enabled = False
                TreeViewClass.Enabled = False
            End If
        End If
    End Sub

    Private Sub actGrid(ByVal tag As String)
        If Not dtConteo Is Nothing Then
            dtConteo.Dispose()
        End If

        dtConteo = ModPOS.Recupera_Tabla("sp_conteo_productos", "@Class", tag, "@CONClave", CONClave, "@ALMClave", Almacen)

        If dtConteo.Rows.Count > 0 Then

            GridProductos.DataSource = dtConteo
            GridProductos.RetrieveStructure()
            GridProductos.AutoSizeColumns()
            GridProductos.RootTable.Columns("ID").Visible = False
            GridProductos.RootTable.Columns("Origen").Visible = False
            GridProductos.RootTable.Columns("Exist").Visible = False
            GridProductos.RootTable.Columns("Fecha").Visible = False
            GridProductos.CurrentTable.Columns(3).Selectable = False
            GridProductos.CurrentTable.Columns(4).Selectable = False
            GridProductos.CurrentTable.Columns(5).Selectable = False

            PBar.Value = 0
            lblPorc.Text = "0 %"
        End If

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


    Private Sub cmbGrupo_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbGrupo.SelectedValueChanged
        If Not cmbGrupo.SelectedValue Is Nothing AndAlso Cargado = True Then

            actualizaTree(IIf(cmbGrupo.SelectedValue Is Nothing, 0, cmbGrupo.SelectedValue))

        End If
    End Sub
End Class
